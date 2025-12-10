---
title: 将 Aspose.Slides 与 Google Slides 集成
linktitle: Google 幻灯片
type: docs
weight: 50
url: /zh/net/integrating-aspose-slides-with-google-slides/
keywords:
- 云平台
- 云集成
- Google 幻灯片
- Google 云端硬盘
- Google API
- Google 服务帐号
- SaaS 集成
- OAuth 2.0
- PPT 转 PDF
- PowerPoint 自动化
- 演示文稿处理
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "将 Aspose.Slides 与 Google Slides 连接，实现演示文稿的导入、同步和转换，自动化工作流，并在同一流程中保持 PowerPoint 与 OpenDocument。"
---

## **简介**

Aspose.Slides 现在通过其 [SaaS Integration API](https://www.nuget.org/packages/Aspose.Slides.SaaSIntegrations) 提供与 Google Slides 和 Google Drive 的集成。此集成使 .NET 应用程序能够转换、编辑、下载和上传 Google Slides 演示文稿。

## **什么是 Google Slides？**
[Google Slides](https://workspace.google.com/products/slides/) 是 Google 开发的免费基于网页的演示软件。它让用户在线创建、编辑和共享幻灯片演示，类似于 Microsoft PowerPoint。支持实时协作、云存储，并可在任何具备互联网访问的设备上使用。

## **Google API**
在使用 Aspose.Slides 操作 Google Slides 演示文稿之前，需要创建一个 Google API 项目并创建一个 [Google Cloud 项目](https://developers.google.com/workspace/guides/create-project)，随后启用所需的 API。

然后，需要选择访问 Google API 的方式——[Aspose.Slides Google Integration](https://www.nuget.org/packages/Aspose.Slides.SaaSIntegrations) 支持两种访问方式：
- `Google Service Account`
- `OAuth 2.0` 通过浏览器进行用户交互。

### **Google Service Account**
服务帐号是一种特殊的 Google 帐号，供应用程序或服务器在无需用户交互的情况下以编程方式访问 Google API。它通常用于后台系统或自动化任务。服务帐号使用 JSON 密钥文件进行身份验证，并拥有自己的电子邮件地址。可以通过 [Google Cloud IAM](https://cloud.google.com/iam/docs/overview) 为其分配特定权限，常与 Google Drive、Sheets 或 BigQuery 等 API 配合使用，以实现对资源的安全、自动化访问。

### **OAuth 2.0**
另一种常见的访问 Google API 的方式是通过 OAuth 2.0 在浏览器中进行用户交互。在此流程中，用户被重定向到 Google 登录页面并授予应用程序权限。批准后，应用程序收到授权码，并将其交换为访问令牌和刷新令牌。

访问令牌允许临时访问 Google API，而刷新令牌可存储并在后续请求中重新获取新的访问令牌，无需用户再次登录。这意味着浏览器交互只需进行一次，后续的 API 调用即可完全自动化。此方法通常用于需要在用户同意下访问其数据（如 Gmail、Calendar 或 Drive）的应用程序。

## **让我们开始编码**
首先，将 [Aspose.Slides SaaS Integration NuGet 包](https://www.nuget.org/packages/Aspose.Slides.SaaSIntegrations) 添加到项目中：
```
dotnet add package Aspose.Slides.SaaSIntegrations
```


### **示例 1**
以下示例演示如何从 Google Drive 下载 Google Slides 演示文稿并将其保存为本地 PDF 文件。我们将使用 Google Service Account 进行授权，假设已下载包含凭据的服务帐号 JSON 文件。
```csharp
// 创建外部管理的 HttpClient
HttpClient httpClient = new HttpClient();

// 使用服务帐户 JSON 文件创建授权提供程序
IGoogleAuthorizationProvider account = new GoogleServiceAccountAuthProvider(@"service_account_json_file.json", httpClient);

// 使用授权提供程序初始化 Google Slides 集成服务
GoogleSlidesIntegration googleSlidesIntegration = new GoogleSlidesIntegration(account, httpClient);

// 通过文件 ID 从 Google Drive 加载演示文稿到 Aspose.Slides IPresentation 实例
using IPresentation pres = await googleSlidesIntegration.LoadPresentationAsync("1A2B3C4D5E6F7G8H9I0J");

// 如有需要，修改演示文稿（例如，删除第二张幻灯片）
pres.Slides.RemoveAt(1);

// 将演示文稿本地保存为 PDF 文件
pres.Save(@"GoogleDriveDownload.pdf", SaveFormat.Pdf);
```


为方便起见，Aspose.Slides SaaS Integration 提供了列出用户可用所有文件的方法。返回的数据包括文件名、MIME 类型和文件 ID。
```csharp
// 获取提供的服务帐号可用的文件列表
var availableFiles = await googleSlidesIntegration.GetDriveFileInfosAsync();

foreach (GoogleDriveFileInfo googleDriveFileInfo in availableFiles)
{
    Console.WriteLine($"File name: {googleDriveFileInfo.Name}, File ID: {googleDriveFileInfo.Id}, MIME type: {googleDriveFileInfo.MimeType}");
}
```


获取文件 ID 的另一种方式是打开 Google Slides Web 应用中的演示文稿，并在 URL 中查找。

例如，在以下 URL 中：
```
https://docs.google.com/presentation/d/1A2B3C4D5E6F7G8H9I0J/edit
```


文件 ID 为：
```
1A2B3C4D5E6F7G8H9I0J
```


## **示例 2**
在下一个示例中，我们将从头创建一个 PowerPoint 演示文稿并以 Google Slides 格式上传到 Google Drive。授权方式使用 OAuth 2.0。
```csharp
// 创建外部管理的 HttpClient
HttpClient httpClient = new HttpClient();

// 使用客户端 ID 和客户端密钥的 OAuth 创建授权提供程序
IGoogleAuthorizationProvider account = new GoogleOAuthProvider("clientId", "clientSecret", httpClient);

// 使用授权提供程序初始化 Google Slides 集成服务
GoogleSlidesIntegration googleSlidesIntegration = new GoogleSlidesIntegration(account, httpClient);

// Create a sample presentation
using (var presentation = new Presentation())
{
    var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
    shape.TextFrame.Text = "Hello from Google Drive!";
    
    // 将演示文稿保存到 Google Drive 根文件夹，格式为 Google Slides
    // 也可以选择 Aspose.Slides 支持的其他导出格式
    var newFileId = await googleSlidesIntegration.SavePresentationAsync(presentation, "New presentation", GoogleSaveFormatType.GoogleSlides);
    Console.WriteLine($"Uploaded file ID: {newFileId}");
}
```


如果在应用程序中使用此类授权，`interaction with the browser is required`。您需要选择账户并确认允许应用访问您的 Google Drive API。仅在首次运行时需要进行此操作。

### **示例 3**
以下示例使用预先获取的访问令牌。`GoogleAccessTokenAuthProvider` 是 `IGoogleAuthorizationProvider` 接口的实现，它使用现有的 OAuth 2.0 访问令牌来授权对 Google API 的请求。与启动或管理 OAuth 流程的提供程序不同，此类依赖调用方提供有效的访问令牌。

当访问令牌由外部系统获取——通常是前端应用或其他服务——并传递给后端时，此提供程序非常有用。它特别适用于分布式环境，在服务器端管理刷新令牌会导致复杂性或因并发刷新尝试而导致令牌失效的风险。

本示例演示如何在保留文件 ID 的同时替换 Google Drive 上的文件并更新其名称。
```csharp
// 创建用于发出请求的 HTTP 客户端
using HttpClient httpClient = new HttpClient();

// 使用访问令牌设置 Google Drive 身份验证
GoogleAccessTokenAuthProvider accessTokenAuthProvider = new GoogleAccessTokenAuthProvider("access_token");

// 使用身份验证和 HTTP 客户端初始化 Google Slides/Drive 集成
GoogleSlidesIntegration googleSlidesIntegration =
    new GoogleSlidesIntegration(accessTokenAuthProvider, httpClient);

// 使用 Aspose.Slides 创建示例演示文稿
using (var presentation = new Presentation())
{
    // 在首张幻灯片上添加矩形形状并设置其文本
    var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
    shape.TextFrame.Text = "Hello from Google Drive!";

    // 定义具有特定质量和合规性设置的 PDF 保存选项
    ISaveOptions saveOptions = new PdfOptions()
    {
        JpegQuality = 50,
        Compliance = PdfCompliance.PdfA1b
    };

    // 按文件 ID 保存（替换）Google Drive 上的现有文件，更新其名称，并导出为 PDF
    await googleSlidesIntegration.SavePresentationToExistingFileAsync(
        presentation,
        "1A2B3C4D5E6F7G8H9I0J",            // Google Drive 上现有文件的 ID
        GoogleSaveFormatType.Pdf,         // 要保存的目标格式
        saveOptions,           
        "NewFileName.pdf"                 // 要分配给文件的新名称
    );
}
```


## **总结**
Aspose.Slides 现已支持另一种文件格式的管理，简化了基于云的工作流自动化，涵盖创建、共享和编辑演示文稿。

本文介绍了基本功能。您还可以将文件保存到子文件夹、替换现有文件，并以多种格式（不限于 Google Slides 演示文稿）导出到 Google Drive。

Aspose.Slides SaaS Integration 将继续扩展对演示文稿 SaaS 平台的支持，敬请关注后续更新。

## **常见问答**

**使用此集成是否需要 Google Workspace 帐户？**  
不需要。您可以使用免费 Google 帐户或 Google Workspace 帐户。所需的访问权限取决于您在 Google Drive 和 Slides 上的权限设置。

**应该选择哪种身份验证方式——服务帐号还是 OAuth 2.0？**  
后端或无需用户交互的自动化工作流使用 **Service Account**。  
如果需要在用户同意下访问特定用户的 Google Slides 或 Drive 文件，请使用 **OAuth 2.0**。

**我可以处理除 Google Slides 之外的格式吗？**  
可以。Aspose.Slides 允许将演示文稿保存为多种格式（如 PDF、PPTX、HTML），然后再上传到 Google Drive。

**如何获取 Google Slides 演示文稿的文件 ID？**  
可以使用 `GetDriveFileInfosAsync()` 方法获取，或从 Google Slides 中演示文稿的 URL 中复制。

**该集成是否支持在 Google Drive 上替换已存在的文件？**  
是的。使用 `SavePresentationToExistingFileAsync` 方法可在保留文件 ID 的同时更新文件。

**使用 OAuth 2.0 时是否每次都需要浏览器交互？**  
不需要。仅在首次授权时需要浏览器交互。之后使用存储的刷新令牌即可实现自动化访问。