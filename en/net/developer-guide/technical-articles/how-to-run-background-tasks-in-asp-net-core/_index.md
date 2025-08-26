---
title: How to Run Background Tasks in ASP.NET Core
type: docs
weight: 300
url: /net/how-to-run-background-tasks-in-asp-net-core/
keywords:
- ASP.NET Core
- background task
- background processing
- hosted service
- background worker
- job queue
- asynchronous job scheduling
- server-side file processing
- progress tracking
- status polling
- SignalR notifications
- AWS SQS
- Amazon S3
- Amazon DynamoDB
- scalable architecture
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Run background tasks in ASP.NET Core with Hosted Services, job queues and status updates – process and convert PPT, PPTX and ODP using Aspose.Slides."
---

## **Overview**

File processing (e.g., exporting a presentation to PDF) is a typical server-side task. Performing it inside the request handler (while the client waits) has the following disadvantages:

- *Poor UI.* The page freezes and the user has to wait for the result. Reloading the page cancels the task.
- *Operation timeouts.* We cannot ensure that processing will complete within a fixed period, so the user is likely to see an "operation timeout".
- *Low throughput and scalability.* ASP.NET Core is designed to process many requests asynchronously. CPU-bound, long-running tasks block threads and reduce server throughput.
- *Poor fault tolerance.* If something goes wrong during a long-running task (e.g., a connectivity issue), processing fails and must be restarted from the beginning.

A [better approach](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/best-practices?view=aspnetcore-9.0#complete-long-running-tasks-outside-of-http-requests) is to schedule the job asynchronously, process it in the background, and return the result when it’s ready.

In this model, the user can see the current status (and can leave or reload the page), server resources can be scaled efficiently and tuned flexibly, and a retry policy can be applied.

A typical background-processing solution includes:

1. An API for scheduling the job.
1. An API for tracking job status.
1. A background worker to process scheduled jobs.
1. An API for storing and retrieving the result.

## **Background Task Example**

To demonstrate this approach, consider the [sample ASP.NET Core 3.1 web application](./BackgroundJobDemo.zip). The app includes a page where a user can upload a presentation and click **Export to PDF**; the presentation is then uploaded and converted to PDF by a background worker.

## **Web App**

The sample web app (*BackgroundJobDemo* project) includes:

- File upload page (Razor page "Upload").
- Progress page (Razor page "Progress" with a few JavaScript functions that check and display status).
- Controller (`JobStatusController`) that provides processing status (`api/status/{jobId}`).
- Controller (`JobResultController`) that returns the exported PDF file (`api/result/{id}`).
- Background worker based on the ASP.NET Core hosting service (see the `WorkerService` class).

Razor pages, controllers, and the background worker delegate the actual work through interfaces defined in the *BackgroundJobDemo.Common* project. Concrete implementations of job management and processing are provided in separate projects (*BackgroundJobDemo.Local*, *BackgroundJobDemo.Aws*, etc.) and can be switched in the `Startup.ConfigureServices` method.

For demo purposes, the "Upload" page uses buffered model binding, but for large file uploads, unbuffered streaming is [recommended](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads). For production, consider the relevant [security aspects](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads#security-considerations). The "Progress" page polls the scheduled job status via JavaScript every two seconds (this interval is configurable). Polling is typical, but for more advanced scenarios you may require real-time notifications via WebSockets (real-time communications are outside the scope of this article). [SignalR](https://dotnet.microsoft.com/apps/aspnet/signalr) is a simple yet powerful tool for real-time communications.

Hosting the background worker in the server process is convenient for simple applications but has [drawbacks](https://haacked.com/archive/2011/10/16/the-dangers-of-implementing-recurring-background-tasks-in-asp-net.aspx). A more robust and scalable approach is to deploy the worker in a separate process (see, e.g., the *BackgroundJobDemo.Worker* console application).

## **Basic Implementation**

The *BackgroundJobDemo.Local* project provides a simple job-management implementation using an SQLite database (the database path is configured via `LocalConfig.DbFilePath`; see `Startup.ConfigureServices`). Uploaded and processed files are stored on the file system (the storage folder path is configured via `LocalConfig.FileStorageFolderPath`; see `Startup.ConfigureServices`). For better fault tolerance and performance in real-world applications, job scheduling should be implemented through message queues (e.g., RabbitMQ, AWS SQS, Azure Storage Queue).

## **Distributed Implementation Based on Amazon Web Services**

The *BackgroundJobDemo.Aws* project implements job processing on Amazon Web Services and demonstrates a horizontally scalable distributed architecture. It includes the following components:

- Web app — interacts with the user and schedules PPTX-to-PDF export tasks, etc.
- Worker — processes exports (in-process, out-of-process, or AWS Lambda).
- Message queue — stores tasks to be processed (Amazon SQS).
- File storage — stores uploaded and processed files (Amazon S3).
- Key–value store — tracks task processing status (Amazon DynamoDB).

A typical distributed architecture relies on [message queues](https://aws.amazon.com/message-queue/): the web app places background tasks into a queue; a background worker retrieves tasks from the queue and performs the required work. This decouples components and makes processing asynchronous and reliable. The queue guarantees delivery and uses a *visibility timeout*: when one worker takes a message, it becomes invisible to other workers; only the processing worker removes it upon completion. If processing does not finish within the visibility timeout (e.g., due to a failure or network issue), the unprocessed message becomes visible again.

Our implementation uses [Amazon Simple Queue Service](https://aws.amazon.com/sqs/) (SQS), a fully managed message queue for microservices, distributed systems, and serverless applications.

Message queues are intended for lightweight messages (e.g., the SQS message size limit is 256 KB), so a message should contain only the task description. Heavy data (such as files to be processed) should be stored separately and referenced from the message. [Amazon S3](https://aws.amazon.com/s3/) is used to store uploaded and processed files.

A key–value store is required to persist and retrieve job results by ID. The example uses [Amazon DynamoDB](https://aws.amazon.com/dynamodb/), a fast and flexible NoSQL database service.

To run the demo app with Amazon Web Services:

1. In the same AWS region, create and configure:
   1. an SQS queue,
   1. an S3 bucket,
   1. a DynamoDB table.
1. Connect the web app to these services by calling *AddAws* in `Startup.ConfigureServices`, providing the SQS queue URL, S3 bucket name, DynamoDB table name, and AWS region.

## **References**

- [ASP.NET Core Performance Best Practices](https://docs.microsoft.com/en-us/aspnet/core/performance/performance-best-practices)
- [Upload files in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads)
- [Real-time ASP.NET with SignalR](https://dotnet.microsoft.com/apps/aspnet/signalr)
- [Message Queues](https://aws.amazon.com/message-queue/)
- [Amazon Simple Queue Service](https://aws.amazon.com/sqs/)
- [Amazon S3](https://aws.amazon.com/s3/)
- [Amazon DynamoDB](https://aws.amazon.com/dynamodb/)
