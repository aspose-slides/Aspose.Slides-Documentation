---
title: 评估 Aspose.Slides
type: docs
weight: 120
url: /zh/net/evaluate-aspose-slides/
keywords:
- 评估 Aspose.Slides
- Aspose.Slides 评估
- 评估版本
- 完整功能
- 评估水印
- 购买 Aspose.Slides
- 限制
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "评估 .NET 平台的 Aspose.Slides 并探索针对 PowerPoint（PPT、PPTX）和 OpenDocument（ODP）演示文稿的 API 功能——开始您的免费试用。"
---
## **Aspose.Slides 评估版**

您可以下载 Aspose.Slides 进行评估。评估包与购买的包相同；在添加少量代码以应用许可证后，它将转为已授权。

在没有许可证的情况下，Aspose.Slides 仍提供完整功能，但在评估模式下有两个限制：它会在每个保存的演示文稿的每张幻灯片上添加一个评估水印文本框；以及代码从演示文稿读取的文本会被截断，只保留前几字符，并附加评估限制的提示。代码写入的文本会完整保存。

![带有评估水印的幻灯片](evaluate-aspose-slides_1.png)

{{% alert color="info" title="Note" %}}
如果您想在不受评估版本限制的情况下测试 Aspose.Slides，可以申请 **30 天临时许可证**。有关更多信息，请参阅 [如何获取临时许可证？](https://purchase.aspose.com/temporary-license)。
{{% /alert %}}

## **安装评估包**

```bash
dotnet add package Aspose.Slides.NET
```

在 Linux 和 macOS 上，您可以改用 Aspose.Slides.NET6.CrossPlatform 包；请参见 [安装](/slides/zh/net/installation/)。

## **应用许可证**

以下是将评估包转换为已授权版本的“少量代码”。请在应用程序启动时一次性应用许可证，在创建任何 `Presentation` 对象之前——早期构建的演示文稿会保留评估水印。

```csharp
using Aspose.Slides;

var license = new License();
license.SetLicense("Aspose.Slides.NET.lic");
```

`SetLicense` 还接受 `Stream`，当许可证作为嵌入资源而非磁盘文件提供时，这是更好的选择。如果路径错误或文件已过期，调用会抛出异常，从而在启动时立即显现错误，而不是静默回到评估模式。

许可证应用后，保存的演示文稿将不再带有水印，文本也会完整读取。

## **常见问题**

### 我可以在评估模式下跨不同线程并行测试多个演示文稿吗？

可以。您可以并行处理不同的文档；但不应在多个线程之间共享同一 `Presentation` 对象 [跨线程](/slides/zh/net/multithreading/)。评估模式不会对此产生影响。

### 我是否需要在服务器或 CI 环境中安装 Microsoft PowerPoint 来评估该库？

不需要。Aspose.Slides 是独立的引擎，无论是评估还是生产环境都不需要安装 PowerPoint。

### 我可以在评估模式下完整测试 PPT/PPTX 转 PDF 和图像的转换吗？

可以。[转换器](/slides/zh/net/convert-presentation/) 可以使用；输出中会包含水印。

### 我可以使用临时许可证进行负载测试而不出现水印吗？

可以。30 天的临时许可证会移除评估模式的限制，允许在没有水印的情况下进行测试。