---
title: 评估 Aspose.Slides
type: docs
weight: 120
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
description: "评估 Aspose.Slides for .NET 并探索针对 PowerPoint (PPT、PPTX) 和 OpenDocument (ODP) 演示文稿的 API 功能——开启免费试用。"
---
## **Aspose.Slides 评估**

您可以轻松下载 Aspose.Slides 进行评估。评估包与购买的包相同。只需添加几行代码来应用许可证，评估版本即可转为正式授权。

Aspose.Slides 的评估版本（未指定许可证）提供完整的产品功能，但在打开和保存文档时会在文档顶部插入评估水印。提取演示文稿文本时也仅限于一张幻灯片。

![todo:image_alt_text](evaluate-aspose-slides_1.png)

{{% alert color="info" %}} 
如果希望在不受评估版限制的情况下测试 Aspose.Slides，您可以申请 **30 天临时许可证**。有关详细信息，请参阅[如何获取临时许可证?](https://purchase.aspose.com/temporary-license)。
{{% /alert %}}

## **安装评估包**

```bash
dotnet add package Aspose.Slides.NET
```

## **应用许可证**

以下是将评估包转换为正式授权的“几行代码”。在应用程序启动时一次性应用许可证，且在创建任何 `Presentation` 对象之前——早先构造的演示文稿会保留评估水印。

```csharp
using Aspose.Slides;

var license = new License();
license.SetLicense("Aspose.Slides.NET.lic");
```

`SetLicense` 还支持接受 `Stream`，当许可证作为嵌入资源而非磁盘文件时，这是更好的选择。如果路径错误或文件已过期，调用会抛出异常，导致启动时立即发现错误，而不会默默回退到评估模式。

一旦许可证生效，水印将消失，单张幻灯片的文本提取限制也将解除。

## **常见问题**

### 我可以在评估模式下跨多个线程并行测试多个演示文稿吗？

可以。您可以并行处理不同的文档；不应在 [跨线程](/slides/zh/net/multithreading/) 时共享同一个演示文稿对象。评估模式不会影响此行为。

### 在服务器或 CI 环境中评估库是否需要安装 Microsoft PowerPoint？

不需要。Aspose.Slides 是独立的引擎，无论是评估还是生产环境都不要求安装 PowerPoint。

### 我能在评估模式下完整测试 PPT/PPTX 转 PDF 和图像的转换吗？

可以。[转换器](/slides/zh/net/convert-presentation/) 能正常工作，只是输出中会包含水印。

### 我可以使用临时许可证进行负载测试，并且不出现水印吗？

可以。30 天临时许可证会移除评估模式的限制，允许在无水印的情况下进行测试。