---
title: 如何在ASP.NET Core中运行后台任务
type: docs
weight: 300
url: /zh/net/how-to-run-background-tasks-in-asp-net-core/
---

## **概述**
文件处理（例如，将演示文稿导出为PDF）是一项典型的服务器端任务。在请求处理程序内部进行简单的文件处理（当客户端等待服务器完成工作时），存在以下缺点：

- *糟糕的用户界面*。页面会冻结，用户必须等待结果。页面重新加载将取消任务。
- *操作超时*。我们无法确保在固定时间内完成处理，因此用户迟早会看到“操作超时”。
- *低吞吐量和可扩展性*。ASP.NET Core设计用于异步处理许多请求。CPU密集型的长时间运行任务会阻塞线程并降低服务器吞吐量。
- *糟糕的容错能力*。当在长时间运行的任务中出现问题（例如，连接问题）时，处理会失败，我们必须从头开始重新运行处理。

一个[更好的方法](https://docs.microsoft.com/en-us/aspnet/core/performance/performance-best-practices#complete-long-running-tasks-outside-of-http-requests)是首先异步调度作业，其次在后台完成它，最后返回处理结果。

在这种情况下，用户可以看到实际状态（甚至可以离开或重新加载页面），服务器资源可以得到有效扩展和灵活调整。此外，还可以利用重试策略。

因此，典型的后台处理解决方案包括以下部分：
1. 用于调度作业的API。
2. 用于跟踪作业状态的API。
3. 背景工作者处理调度的作业。
4. 用于存储/获取结果的API。

## **后台任务示例**
为了演示这种方法，我们考虑[**示例ASP.NET Core 3.1 Web应用程序**](https://wiki.lutsk.dynabic.com/download/Aspose%20Slides/slidesnet/Discussion%20on%20Russian/Issues/Platform%20specific/How%20to%20run%20Background%20Tasks%20in%20ASP.NET%20Core/WebHome/BackgroundJobDemo.zip?rev=1.1)。该Web应用程序包含一个网页，用户可以上传演示文稿，按下“导出为PDF”按钮，然后演示文稿将被上传并由后台工作者转换为PDF格式。
## **Web应用程序**
示例Web应用程序（*BackgroundJobDemo*项目）包括：

- 上传文件页面（Razor页面Upload）。
- 进度页面（Razor页面Progress，包含一些JavaScript函数检查和显示状态）。
- 控制器（JobStatusController）提供处理状态（api/status/{jobId}）。
- 控制器（JobResultController）返回导出的PDF文件（api/result/{id}）。
- 基于ASP.NET Core托管服务的后台工作者（参见WorkerService类）。

Razor页面、控制器和后台工作者通过在*BackgroundJobDemo.Common*项目中定义的接口委派所有实际工作。作业管理和处理的具体实现定义在单独的项目中（*BackgroundJobDemo.Local*、*BackgroundJobDemo.Aws*等），可以在Startup.ConfigureServices方法中轻松切换。

出于演示目的，“上传”页面使用缓冲模型绑定，但对于大型文件的上传，推荐使用[无缓冲流](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads)。对于生产部署，应考虑[安全方面](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads#security-considerations)。 “进度”页面通过JavaScript每2秒轮询一次调度作业状态（可以修改此周期）。状态轮询是典型行为，但对于高级案例，可能需要通过WebSocket进行实时通知（实时通信超出了本文的范围）。[SignalR](https://dotnet.microsoft.com/apps/aspnet/signalr)是用于实时通信的简单但强大的工具。

在服务器进程中托管后台工作者对于简单应用程序非常方便，但具有[缺点](https://haacked.com/archive/2011/10/16/the-dangers-of-implementing-recurring-background-tasks-in-asp-net.aspx)。更健壮和可扩展的解决方案是在单独的进程中部署工作者（例如，*BackgroundJobDemo.Worker*控制台应用程序）。
## **基本实现**
*BackgroundJobDemo.Local*项目包含一个简单的作业管理实现，使用SQLite数据库（数据库文件的路径通过LocalConfig.DbFilePath指定，参见Startup.ConfigureServices）。上传和处理的文件存储在文件系统中（存储文件夹的路径通过LocalConfig.FileStorageFolderPath指定，参见Startup.ConfigureServices）。为了在实际应用程序中提高容错能力和性能，作业调度应通过消息队列实现（例如，RabbitMQ、AWS SQS、Azure Storage Queue）。
## **基于亚马逊网络服务的分布式实现**
*BackgroundJobDemo.Aws*项目通过亚马逊网络服务实现作业处理，并演示可以水平扩展的分布式架构。它包括以下组件：

- Web应用程序 - 与用户交互并调度PPTX到PDF的导出任务等。
- 工作者 - 处理导出（进程内，进程外或亚马逊Lambda）。
- 消息队列 - 存储待处理的任务（亚马逊SQS）。
- 文件存储 - 存储上传和处理的文件（亚马逊S3）。
- 键值存储 - 提供任务处理状态（亚马逊DynamoDB）。

典型的分布式架构基于[消息队列](https://aws.amazon.com/message-queue/)：Web应用程序将后台任务放入队列，后台工作者从队列中获取任务并执行所需工作。因此，系统组件（Web应用程序和后台工作者）是解耦的，处理是异步和可靠的。队列保证所有消息（任务）都被送达工作者。队列消息具有*可见性超时* - 当一个工作者获得消息进行处理时，该消息对其他工作者变得不可见，只有处理该消息的工作者才能将其从队列中删除。如果在可见性超时内未完成处理（例如，失败或网络问题） - 未处理的消息将再次对工作者可见。

我们的实现使用[亚马逊简单队列服务](https://aws.amazon.com/sqs/)（SQS） - 完全托管的微服务、分布式系统和无服务器应用程序的消息队列。

消息队列设计用于轻量级消息（例如，SQS消息大小限制为256 KB），因此它应仅包含任务描述。所有重量级数据（例如，待处理的文件）应放置到单独的存储中，并从消息中引用。[亚马逊S3](https://aws.amazon.com/s3/)是一个对象存储，旨在存储和检索来自任何地方的任意数量的数据。该服务用于存储上传和处理的文件。

键值存储用于按ID存储和检索作业处理结果。[亚马逊DynamoDB](https://aws.amazon.com/dynamodb/)（快速灵活的NoSQL数据库服务，适用于任何规模）在示例中被使用。

要运行带有亚马逊网络服务的演示应用程序：

1. 在同一AWS区域中创建和配置：
   1. SQS队列，
   1. S3桶，
   1. DynamoDB表。
1. 使用AddAws扩展方法将Web应用程序连接到创建的服务（SQS队列URL、S3桶名称、DynamoDB表名称和AWS区域），该方法来自Startup.ConfigureServices。
## **参考文献**
- ASP.NET Core性能最佳实践 <https://docs.microsoft.com/en-us/aspnet/core/performance/performance-best-practices>
- 在ASP.NET Core中上传文件 <https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads>
- 实时ASP.NET与SignalR <https://dotnet.microsoft.com/apps/aspnet/signalr>
- 消息队列 <https://aws.amazon.com/message-queue/>
- 亚马逊简单队列服务 <https://aws.amazon.com/sqs/>
- 亚马逊S3 <https://aws.amazon.com/s3/>
- 亚马逊DynamoDB <https://aws.amazon.com/dynamodb/>