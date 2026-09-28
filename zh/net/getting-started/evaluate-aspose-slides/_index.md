---
title: 评估 Aspose.Slides
type: docs
weight: 75
url: /zh/net/evaluate-aspose-slides/
keywords:
- 评估 Aspose.Slides
- Aspose.Slides 评估
- 评估版
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
description: "评估 .NET 版 Aspose.Slides 并探索针对 PowerPoint (PPT、PPTX) 和 OpenDocument (ODP) 演示文稿的 API 功能——开始免费试用。"
---
## **Aspose.Slides 评估版**

您可以下载 Aspose.Slides 进行评估。评估包与购买的包相同；在添加少量代码以应用许可证后即转为正式授权。

如果没有许可证，Aspose.Slides 在评估模式下提供全部功能，但有两项限制：它会在每个演示文稿保存的每张幻灯片上添加评估水印文本框；代码从演示文稿读取的文本会被截断为前几个字符，并附加评估限制的提示。代码写入的文本会完整保存。

![带有评估水印的幻灯片](evaluate-aspose-slides_1.png)

{{% alert color="info" title="Note" %}}
如果您想在没有评估版限制的情况下测试 Aspose.Slides，可以申请 **30 天临时许可证**。详细信息请参阅[How to get a Temporary License?](https://purchase.aspose.com/temporary-license)。
{{% /alert %}}

## **安装评估包**

```bash
dotnet add package Aspose.Slides.NET
```

在 Linux 和 macOS 上，您可以改用 Aspose.Slides.NET6.CrossPlatform 包；请参阅[Installation](/slides/zh/net/installation/)。

## **应用许可证**

下面的“少量代码”即可将评估包转换为正式授权。请在应用程序启动时一次性应用许可证，且在创建任何 `Presentation` 对象之前——之前构造的演示文稿会保留评估水印。

```csharp
using Aspose.Slides;

var license = new License();
license.SetLicense("Aspose.Slides.NET.lic");
```

`SetLicense` 也接受 `Stream`，当许可证以嵌入资源而非磁盘文件形式提供时，这是更好的选择。如果路径错误或文件已过期，调用会抛出异常，从而在启动时立即显现错误，而不是静默回退到评估模式。

许可证应用后，保存的演示文稿不再带有水印，文本也会完整读取。

## **FAQ**

### 我可以在评估模式下并行测试多个演示文稿吗？

可以。您可以并行处理不同的文档；但不应在[跨线程](/slides/zh/net/multithreading/)共享同一个演示文稿对象。评估模式不受此影响。

### 在服务器或 CI 环境中评估库是否需要安装 Microsoft PowerPoint？

不需要。Aspose.Slides 是独立的引擎，评估或生产环境都不需要安装 PowerPoint。

### 我可以在评估模式下完整测试 PPT/PPTX 到 PDF 和图像的转换吗？

可以。[转换器](/slides/zh/net/convert-presentation/)可以使用；输出会包含水印。

### 我可以使用临时许可证进行负载测试而不出现水印吗？

可以。30 天临时许可证会移除评估模式限制，允许在无水印的情况下进行测试。