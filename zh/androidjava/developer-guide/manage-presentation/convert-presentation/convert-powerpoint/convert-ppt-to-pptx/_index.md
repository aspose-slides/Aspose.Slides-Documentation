---
title: 在 Android 上将 PPT 转换为 PPTX
linktitle: PPT 转 PPTX
type: docs
weight: 20
url: /zh/androidjava/convert-ppt-to-pptx/
keywords:
- 转换 PowerPoint
- 转换 演示文稿
- 转换 幻灯片
- 转换 PPT
- PPT 转 PPTX
- 将 PPT 保存为 PPTX
- 导出 PPT 为 PPTX
- PowerPoint
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android 在 Java 中快速将旧版 PPT 演示文稿转换为现代 PPTX — 清晰教程，免费代码示例，无需 Microsoft Office 依赖。"
---

## **概述**

本文介绍如何使用 Java 以及在线 PPT 转 PPTX 转换应用将 PPT 格式的 PowerPoint 演示文稿转换为 PPTX 格式。涵盖以下主题。

- 在 Java 中将 PPT 转换为 PPTX

## **在 Android 上将 PPT 转换为 PPTX**

有关将 PPT 转换为 PPTX 的 Java 示例代码，请参阅下文章节 [Convert PPT to PPTX](#convert-ppt-to-pptx)。该示例仅加载 PPT 文件并以 PPTX 格式保存。通过指定不同的保存格式，还可以将 PPT 文件保存为 PDF、XPS、ODP、HTML 等多种格式，详见以下文章。

- [Java 将 PPT 转换为 PDF](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-pdf/)
- [Java 将 PPT 转换为 XPS](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-xps/)
- [Java 将 PPT 转换为 HTML](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-html/)
- [Java 将 PPT 转换为 ODP](https://docs.aspose.com/slides/androidjava/save-presentation/)
- [Java 将 PPT 转换为 Image](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-png/)

## **关于 PPT 到 PPTX 的转换**
使用 Aspose.Slides API 将旧的 PPT 格式转换为 PPTX。如果需要将成千上万的 PPT 演示文稿批量转换为 PPTX 格式，最佳方案是通过编程实现。借助 Aspose.Slides API，只需几行代码即可完成。该 API 完全兼容 PPT 到 PPTX 的转换，并且能够：

- 转换复杂的母版、布局和幻灯片结构。
- 转换包含图表的演示文稿。
- 转换包含组合形状、AutoShape（如矩形和椭圆）以及自定义几何形状的演示文稿。
- 转换使用纹理和图片填充样式的 AutoShape 演示文稿。
- 转换包含占位符、文本框和文字占位符的演示文稿。

{{% alert color="primary" %}} 

请查看 [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/conversion/ppt-to-pptx) 应用：

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

此应用基于 [**Aspose.Slides API**](https://products.aspose.com/slides/androidjava/) 构建，可实时展示基本的 PPT 转 PPTX 转换功能。Aspose.Slides Conversion 是一款 Web 应用，用户可将 PPT 格式的演示文件拖入后下载已转换为 PPTX 的文件。

查找其他实时的 [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) 示例。
{{% /alert %}} 

## **将 PPT 转换为 PPTX**
Aspose.Slides for Android via Java 现在允许开发者使用 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) 类实例访问 PPT，并将其转换为相应的 [PPTX](https://docs.fileformat.com/presentation/pptx/) 格式。目前，它支持将 [PPT ](https://docs.fileformat.com/presentation/ppt/) 部分转换为 PPTX。如需了解 PPT 到 PPTX 转换支持和不支持的功能详情，请访问此文档 [link](/slides/zh/androidjava/ppt-to-pptx-conversion/)。

Aspose.Slides for Android via Java 提供的 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) 类表示一个 **PPTX** 演示文稿文件。该类现在也可以在实例化对象时通过 Presentation 访问 **PPT**。下面的示例展示了如何将 PPT 演示文稿转换为 PPTX 演示文稿。
```java
// 实例化一个表示 PPTX 文件的 Presentation 对象
Presentation pres = new Presentation("Aspose.ppt");
try {
    // 将 PPTX 演示文稿保存为 PPTX 格式
    pres.save("ConvertedAspose.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**图 : 源 PPT 演示文稿**|

上述代码片段在转换后生成了以下 PPTX 演示文稿

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**图: 转换后生成的 PPTX 演示文稿**|

## **常见问题**

**PPT 与 PPTX 格式有什么区别？**

PPT 是微软 PowerPoint 使用的较旧的二进制文件格式，而 PPTX 是自 Microsoft Office 2007 起引入的基于 XML 的新格式。PPTX 文件具备更好的性能、更小的文件体积以及更强的数据恢复能力。

**Aspose.Slides 是否支持批量将多个 PPT 文件转换为 PPTX？**

是的，您可以在循环中使用 Aspose.Slides 以编程方式批量将多个 PPT 文件转换为 PPTX，适用于批量转换场景。

**转换后内容和格式会被保留吗？**

Aspose.Slides 在转换演示文稿时保持高保真度。幻灯片布局、动画、形状、图表以及其他设计元素在 PPT 到 PPTX 的转换过程中都会被完整保留。

**我可以将 PPT 文件转换为 PDF 或 HTML 等其他格式吗？**

是的，Aspose.Slides 支持将 PPT 文件转换为 [多种格式](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveformat/)，包括 PDF、XPS、HTML、ODP 以及 PNG、JPEG 等图片格式。

**是否可以在未安装 Microsoft PowerPoint 的情况下将 PPT 转换为 PPTX？**

可以，Aspose.Slides 是独立的 API，无需 Microsoft PowerPoint 或任何第三方软件即可完成转换。

**是否有在线工具可用于 PPT 到 PPTX 的转换？**

可以，您可以使用免费的 [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/conversion/ppt-to-pptx) Web 应用直接在浏览器中完成转换，无需编写任何代码。