---
title: How to run Background Tasks in ASP.NET Core
type: docs
weight: 50
url: /net/how-to-run-background-tasks-in-asp-net-core/
---

## **Overview**
File processing (e.g. exporting presentation to PDF) is a typical server-side task. Simple file processing inside the request handler (when the client is waiting while the server is doing the job) has the following disadvantages:

- *Poor UI*. The page freezes and user has to wait for the result. The page reload will cancel the task.
- *Operation timeout*. We cannot ensure that processing is completed in a fixed period of time, so it means that user will see "operation timeout" sooner or later.  
- *Low throughput and scalability*. ASP.NET Core is designed to process many requests asynchronously. The CPU-bound long-running tasks blocks the threads and reduce server throughput. 
- *Bad fault tolerance*. When something goes wrong in the middle of a long-running task (e.g. connectivity issue), the processing just fails and we have to rerun the processing from the beginning once again.

A[ better approach](https://docs.microsoft.com/en-us/aspnet/core/performance/performance-best-practices#complete-long-running-tasks-outside-of-http-requests) is to schedule the job asynchronously firstly, complete it in the background secondly and return the result of the processing lastly.

In this case, user can see the actual status (and even leave or reload the page), the server resources can be efficiently scaled and flexibly tuned. Also, retry-policy can be utilized. 

So, the typical background processing solution includes the following parts:
1. API for scheduling the job.
2. API for tracking job status.
3. The background worker to process the scheduled jobs.
4. API for storing/getting the result.


## **Background Task Example**
To demonstrate this approach, let's consider the [**example ASP.NET Core 3.1 web application**](https://wiki.lutsk.dynabic.com/download/Aspose%20Slides/slidesnet/Discussion%20on%20Russian/Issues/Platform%20specific/How%20to%20run%20Background%20Tasks%20in%20ASP.NET%20Core/WebHome/BackgroundJobDemo.zip?rev=1.1). The web app contains a web page, where user can upload presentation, press "Export to PDF" button, then the presentation will be uploaded and converted to PDF format by a background worker.
## **Web App**
Example web app (*BackgroundJobDemo* project) includes:

- Upload file page (razor page Upload).
- Progress page (razor page Progress with few JavaScript functions checking and displaying the status).
- Controller (JobStatusController) providing processing status (api/status/{jobId}).
- Controller (JobResultController) returning exported PDF file (api/result/{id}).
- Background worker based on ASP.NET Core hosting service (see WorkerService class).

Razor pages, controllers and background worker delegate all actual work via interfaces, defined in *BackgroundJobDemo.Common* project. The concrete implementations of job management and processing are defined in the separate projects (*BackgroundJobDemo.Local*, *BackgroundJobDemo.Aws* etc) and can be easily switched in Startup.ConfigureServices method.

For demo purposes, "Upload" page uses buffered model binding, but for large files uploading unbuffered streaming is [recommended](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads). For production deployment, the [security aspects](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads#security-considerations) should be taken into account. The "Progress" page polls the scheduled job status via JavaScript every 2 seconds (the period can be modified). Status polling is typical behavior, but for advanced cases, real-time notifications (real-time communications are out of the scope of this article) via WebSocket can be required. [SignalR](https://dotnet.microsoft.com/apps/aspnet/signalr) is a simple yet powerful tool for real-time communications.

Background worker hosting in the server process is handy for simple applications, but has [disadvantages ](https://haacked.com/archive/2011/10/16/the-dangers-of-implementing-recurring-background-tasks-in-asp-net.aspx). The more robust and scalable solution is to deploy the worker in a separate process (see e.g. *BackgroundJobDemo.Worker* console application). 
## **Basic Implementation**
*BackgroundJobDemo.Local* project contains a simple implementation of job management with SQLite database (path to the database file is specified via LocalConfig.DbFilePath, see in Startup.ConfigureServices). The uploaded and processed files are stored on file system (path to the storage folder is specified via LocalConfig.FileStorageFolderPath, see in Startup.ConfigureServices). For better fault tolerance and performance in real-word applications the job scheduling should be implemented via message queues (e.g. RabbitMQ, AWS SQS, Azure Storage Queue).
## **Distributed Implementation Based on Amazon Web Services**
*BackgroundJobDemo.Aws* project implements job processing via Amazon Web Services and demonstrates the distributed architecture which can be horizontally scaled. It includes following components:

- Web app - interacts with user and schedules the PPTX to PDF export tasks, etc.
- Worker - processes export (in-process, out-of process or Amazon Lambda).
- Message queue - stores the tasks to be processed (Amazon SQS).
- File storage - keeps the uploaded and processed files (Amazon S3).
- Key-value storage - provides the task processing status (Amazon DynamoDB). 

The typical distributed architecture is based on [message queues](https://aws.amazon.com/message-queue/): web app puts the background tasks to queue, background worker gets the task from the queue and perform required work. So, system components (web app and background worker) are decoupled and the processing is asynchronous and reliable. The queue guarantees that all messages (tasks) are delivered to the workers. The queue messages have *visibility timeout* - when one worker gets the message for processing, the message becomes invisible for another workers and only worker processing the message removes it from the queue. If the processing is not completed during visibility timeout (e.g. failure or network issue) - the unprocessed message becomes visible for workers again.        

Our implementation uses [Amazon Simple Queue Service](https://aws.amazon.com/sqs/) (SQS) - fully managed message queues for microservices, distributed systems, and serverless applications.

The message queues are designed for lightweight messages (e.g. SQS message size limit is 256 KB), so it should contain only task description. All heavyweight data (e.g. files to be processed) should be placed to the separate storage and be referenced from the message. [Amazon S3](https://aws.amazon.com/s3/) is an object storage built to store and retrieve any amount of data from anywhere. This service is utilized for storing uploaded and processed files.

Key-value storage is required to store and retrieve job processing result by ID. [Amazon DynamoDB](https://aws.amazon.com/dynamodb/) (fast and flexible NoSQL database service for any scale) was utilized in the example.

To run demo app with Amazon Web Services:

1. Create and configure in the same AWS region:
   1. SQS queue,
   1. S3 bucket,
   1. DynamoDB table.
1. Connect web app to the created services with AddAws extension method (SQS queue URL, S3 bucket name, DynamoDB table name and AWS region) from Startup.ConfigureServices. 
## **References**
- ASP.NET Core Performance Best Practices <https://docs.microsoft.com/en-us/aspnet/core/performance/performance-best-practices>
- Upload files in ASP.NET Core <https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads>
- Real-time ASP.NET with SignalR <https://dotnet.microsoft.com/apps/aspnet/signalr>
- Message Queues <https://aws.amazon.com/message-queue/>
- Amazon Simple Queue Service <https://aws.amazon.com/sqs/>
- Amazon S3 <https://aws.amazon.com/s3/>
- Amazon DynamoDB <https://aws.amazon.com/dynamodb/>
