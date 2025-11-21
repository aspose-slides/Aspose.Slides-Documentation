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
- Google 服务帐户
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
description: "将 Aspose.Slides 与 Google Slides 连接，以导入、同步和转换演示文稿，自动化工作流，并在同一流程中保持 PowerPoint 和 OpenDocument。"
---

# 将 Aspose.Slides 与 Google Slides 集成

Aspose.Slides 现在通过其[SaaS Integration API](https://www.nuget.org/packages/Aspose.Slides.SaaSIntegrations)提供对 Google Slides 和 Google Drive 的集成。此集成使 .NET 应用能够转换、编辑、下载和上传 Google Slides 演示文稿。

## 什么是 Google Slides？
[Google Slides](https://workspace.google.com/products/slides/) 是 Google 开发的免费基于网页的演示软件。它允许用户在线创建、编辑和共享幻灯片演示，类似于 Microsoft PowerPoint。支持实时协作、云存储，且可在任何具备互联网访问的设备上使用。

## Google API
在使用 Aspose.Slides 处理 Google Slides 演示文稿之前，需要创建 Google API 项目并[创建 Google Cloud 项目](https://developers.google.com/workspace/guides/create-project)，然后启用所需的 API。

随后需要选择访问 Google API 的方式——[Aspose.Slides Google Integration](https://www.nuget.org/packages/Aspose.Slides.SaaSIntegrations) 支持两种方式：
- `Google Service Account`
- `OAuth 2.0`（通过浏览器进行用户交互）

### Google Service Account
Service Account 是一种特殊的 Google 账户，供应用或服务器在无需用户交互的情况下以编程方式访问 Google API。通常用于后端系统或自动化任务。Service Account 通过 JSON 密钥文件进行身份验证，并拥有自己的电子邮件地址。可通过[Google Cloud IAM](https://cloud.google.com/iam/docs/overview)分配特定权限，常用于 Google Drive、Sheets、BigQuery 等 API，实现安全的自动化资源访问。

### OAuth 2.0
另一种常见的访问 Google API 方式是通过 OAuth 2.0 在浏览器中进行用户交互。在此流程中，用户被重定向到 Google 登录页面并授权应用。授权后，应用收到授权码，随后将其兑换为访问令牌和刷新令牌。

访问令牌允许临时访问 Google API，而刷新令牌可以存储并在需要时重新获取新的访问令牌，无需再次登录。这意味着浏览器交互仅在第一次需要，后续 API 访问即可完全自动化。此方法通常用于需要在用户同意下访问其数据（如 Gmail、Calendar 或 Drive）的应用。

## 让我们编写代码
首先，将[Aspose.Slides SaaS Integration NuGet 包](https://www.nuget.org/packages/Aspose.Slides.SaaSIntegrations)添加到项目中：
```
dotnet add package Aspose.Slides.SaaSIntegrations
```


### 示例 1
下面的示例演示如何从 Google Drive 下载 Google Slides 演示文稿并保存为本地 PDF 文件。我们将使用 Google Service Account 进行授权，假设已下载包含凭据的 Service Account JSON 文件。
```csharp
// 创建外部管理的 HttpClient
HttpClient httpClient = new HttpClient();

// 使用服务帐户 JSON 文件创建授权提供程序
IGoogleAuthorizationProvider account = new GoogleServiceAccountAuthProvider(@"service_account_json_file.json", httpClient);

// 使用授权提供程序初始化 Google Slides 集成服务
GoogleSlidesIntegration googleSlidesIntegration = new GoogleSlidesIntegration(account, httpClient);

// 根据文件 ID 从 Google Drive 加载演示文稿到 Aspose.Slides IPresentation 实例
using IPresentation pres = await googleSlidesIntegration.LoadPresentationAsync("1A2B3C4D5E6F7G8H9I0J");

// 如有需要修改演示文稿（例如，删除第二张幻灯片）
pres.Slides.RemoveAt(1);

// 将演示文稿本地保存为 PDF 文件
pres.Save(@"GoogleDriveDownload.pdf", SaveFormat.Pdf);
```


为方便起见，Aspose.Slides SaaS Integration 提供了列出用户可用全部文件的方法。返回的数据包括文件名、MIME 类型和文件 ID。
```csharp
// 获取提供的服务帐户可用的文件列表
var availableFiles = await googleSlidesIntegration.GetDriveFileInfosAsync();

foreach (GoogleDriveFileInfo googleDriveFileInfo in availableFiles)
{
    Console.WriteLine($"File name: {googleDriveFileInfo.Name}, File ID: {googleDriveFileInfo.Id}, MIME type: {googleDriveFileInfo.MimeType}");
}
```


另一种获取文件 ID 的方式是打开 Google Slides Web 应用中的演示文稿，并在 URL 中定位它。

例如，在以下 URL 中：
```
https://docs.google.com/presentation/d/1A2B3C4D5E6F7G8H9I0J/edit
```


文件 ID 为：
```
1A2B3C4D5E6F7G8H9I0J
```


## 示例 2
在下一个示例中，我们将从头创建一个 PowerPoint 演示文稿，并以 Google Slides 格式上传到 Google Drive。授权方式使用 OAuth 2.0。
```csharp
// 创建外部管理的 HttpClient
HttpClient httpClient = new HttpClient();

// 使用 OAuth 并使用客户端 ID 和客户端密钥创建授权提供程序
IGoogleAuthorizationProvider account = new GoogleOAuthProvider("clientId", "clientSecret", httpClient);

// 使用授权提供程序初始化 Google Slides 集成服务
GoogleSlidesIntegration googleSlidesIntegration = new GoogleSlidesIntegration(account, httpClient);

// 创建示例演示文稿
using (var presentation = new Presentation())
{
    var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
    shape.TextFrame.Text = "Hello from Google Drive!";
    
    // 将演示文稿保存到 Google Drive 根文件夹，使用 Google Slides 格式
    // 您也可以选择 Aspose.Slides 支持的其他导出格式
    var newFileId = await googleSlidesIntegration.SavePresentationAsync(presentation, "New presentation", GoogleSaveFormatType.GoogleSlides);
    Console.WriteLine($"Uploaded file ID: {newFileId}");
}
```


如果在应用中使用此类授权，`interaction with the browser is required`。需要选择账户并确认允许应用访问你的 Google Drive API。仅在首次运行时需要进行此操作。

### 示例 3
下面的示例使用预先获取的访问令牌。`GoogleAccessTokenAuthProvider` 是 `IGoogleAuthorizationProvider` 接口的实现，它使用现有的 OAuth 2.0 访问令牌对 Google API 请求进行授权。不同于启动或管理 OAuth 流程的提供程序，此类依赖调用方提供有效的访问令牌。

该提供程序适用于访问令牌由外部系统（通常是前端应用或其他服务）获取并传递给后端的场景。尤其适合分布式环境，在服务器端管理刷新令牌会增加复杂性或因并发刷新导致令牌失效的风险。

本示例演示如何在 Google Drive 上替换文件并更新其名称，同时保留文件 ID。
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
    // 向第一张幻灯片添加矩形形状并设置其文本
    var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
    shape.TextFrame.Text = "Hello from Google Drive!";

    // 定义具有特定质量和合规性设置的 PDF 保存选项
    ISaveOptions saveOptions = new PdfOptions()
    {
        JpegQuality = 50,
        Compliance = PdfCompliance.PdfA1b
    };

    // 保存（替换）Google Drive 上的现有文件（按文件 ID），更新其名称并导出为 PDF
    await googleSlidesIntegration.SavePresentationToExistingFileAsync(
        presentation,
        "1A2B3C4D5E6F7G8H9I0J",            // Google Drive 上现有文件的 ID
        GoogleSaveFormatType.Pdf,         // 想要保存的格式
        saveOptions,           
        "NewFileName.pdf"                 // 要分配给文件的新名称
    );
}
```


## 小结
Aspose.Slides 现在支持额外的文件格式管理，简化了基于云的工作流自动化，实现演示文稿的创建、共享和编辑。

本文介绍了基本功能。你还可以将文件保存到子文件夹、替换已有文件，并以多种格式导出到 Google Drive——不仅限于 Google Slides 演示文稿。

Aspose.Slides SaaS Integration 将继续扩展对演示文稿 SaaS 平台的支持，敬请关注后续更新。

## 常见问题

**问：使用此集成是否必须拥有 Google Workspace 账户？**  
答：不需要。既可以使用免费的 Google 账户，也可以使用 Google Workspace 账户。所需的访问权限取决于你的 Google Drive 和 Slides 权限。

**问：应该选择哪种身份验证方式——Service Account 还是 OAuth 2.0？**  
答：后端或无用户交互的自动化工作流请使用**Service Account**。  
如果需要在用户同意下访问特定用户的 Google Slides 或 Drive 文件，请使用**OAuth 2.0**。

**问：可以处理 Google Slides 之外的格式吗？**  
答：可以。Aspose.Slides 支持将演示文稿保存为多种格式（如 PDF、PPTX、HTML），然后再上传到 Google Drive。

**问：如何获取 Google Slides 演示文稿的文件 ID？**  
答：可以使用 `GetDriveFileInfosAsync()` 方法获取，或直接从 Google Slides 演示文稿的 URL 中复制。

**问：集成是否支持在 Google Drive 上替换已有文件？**  
答：支持。使用 `SavePresentationToExistingFileAsync` 方法可在保留文件 ID 的情况下更新文件。

**问：使用 OAuth 2.0 时是否每次都需要浏览器交互？**  
答：不需要。仅在首次授权时需要浏览器交互。之后使用存储的刷新令牌即可实现自动化访问。