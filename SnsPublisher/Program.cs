﻿using System.Text.Json;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using SnsPublisher;

var customer = new CustomerCreated
{
    Id  = Guid.NewGuid(),
    FullName = "Marcos Paulo Pacifico",
    Email = "paulopacific.pp@gmail.com",
    DateOfBirth = new DateTime(2000, 08, 11),
    GitHubUsername = "Marcos-Paulo-Pacifico"
};

var snsClient = new AmazonSimpleNotificationServiceClient();

var topicArnResponse = await snsClient.FindTopicAsync("customers");

var publishRequest = new PublishRequest
{
    TopicArn = topicArnResponse.TopicArn,
    Message = JsonSerializer.Serialize(customer),
    MessageAttributes = new Dictionary<string, MessageAttributeValue>
    {
        {
            "MessageType", new MessageAttributeValue
            {
                DataType = "String",
                StringValue = nameof(CustomerCreated)
            }
        }
    }
};

var response = await snsClient.PublishAsync(publishRequest);