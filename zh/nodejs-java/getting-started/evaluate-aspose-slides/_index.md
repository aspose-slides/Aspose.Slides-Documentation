---
title: 评估 Aspose.Slides
type: docs
weight: 120
url: /zh/nodejs-java/evaluate-aspose-slides/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "通过 Java 评估适用于 Node.js 的 Aspose.Slides，并探索针对 PowerPoint（PPT、PPTX）和 OpenDocument（ODP）演示文稿的 API 功能——开始您的免费试用。"
---
## **Aspose.Slides 评估**

您可以下载 Aspose.Slides 进行评估。评估包与购买的包相同；在添加几行代码以应用许可证后即可获得授权。有关安装方法，请参阅[安装](/slides/zh/nodejs-java/installation/)。

如果没有许可证，Aspose.Slides 在评估模式下提供完整功能，但有两个限制：它会在每个保存的演示文稿的每张幻灯片上添加一个评估水印文本框；以及代码从演示文稿读取的文本如果超过五个字符，则会被截断为前五个字符，并在其后追加`... text has been truncated due to evaluation version limitation.`。五个字符或更少的文本会原样返回，代码写入的文本会完整保存。每次保存都会添加水印，因此在评估模式下打开并再次保存的演示文稿每张幻灯片上会累计一个水印。

{{% alert color="info" title="Note" %}}

如果您想在不受评估版限制的情况下测试 Aspose.Slides，可以请求**30 天临时许可证**。有关更多信息，请参阅[如何获取临时许可证？](https://purchase.aspose.com/temporary-license)。

{{% /alert %}}

## **常见问题**

### 我可以在评估模式下并行在不同线程中测试多个演示文稿吗？

可以。您可以并行处理不同的文档；但不应在[跨线程](/slides/zh/nodejs-java/multithreading/)共享同一演示文稿对象。评估模式不会影响此行为。

### 在服务器或 CI 环境中评估该库是否需要安装 Microsoft PowerPoint？

不需要。Aspose.Slides 是独立的引擎，无论是评估还是生产环境都不需要安装 PowerPoint。

### 我能在评估模式下全面测试 PPT/PPTX 转 PDF 和图像的转换吗？

可以。[转换器](/slides/zh/nodejs-java/convert-presentation/)可以正常工作；输出中会包含水印。

### 我可以使用临时许可证进行负载测试而不出现水印吗？

可以。30 天临时许可证会移除评估模式限制，允许在不出现水印的情况下进行测试。