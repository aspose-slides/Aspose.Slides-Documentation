---
title: 在 Java 中将 PPT 转换为 PPTX
linktitle: PPT 转 PPTX
type: docs
weight: 20
url: /zh/java/convert-ppt-to-pptx/
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
- Java
- Aspose.Slides
description: "使用 Aspose.Slides 在 Java 中快速将旧版 PPT 演示文稿转换为现代 PPTX —— 清晰的教程，免费代码示例，无需 Microsoft Office 依赖。"
---

## **概述**

本文解释了如何使用 Java 将 PPT 格式的 PowerPoint 演示文稿转换为 PPTX 格式，以及使用在线 PPT 转 PPTX 转换应用程序。涵盖以下主题。

- 在 Java 中将 PPT 转换为 PPTX

## **在 Java 中将 PPT 转换为 PPTX**

有关将 PPT 转换为 PPTX 的 Java 示例代码，请参见下方章节，即 [将 PPT 转换为 PPTX](#convert-ppt-to-pptx)。它仅加载 PPT 文件并以 PPTX 格式保存。通过指定不同的保存格式，您还可以将 PPT 文件保存为 PDF、XPS、ODP、HTML 等多种格式，详见这些文章。

- [将 PPT 转换为 PDF（Java）](/slides/zh/java/convert-powerpoint-to-pdf/)
- [将 PPT 转换为 XPS（Java）](/slides/zh/java/convert-powerpoint-to-xps/)
- [将 PPT 转换为 HTML（Java）](/slides/zh/java/convert-powerpoint-to-html/)
- [将 PPT 转换为 ODP（Java）](/slides/zh/java/save-presentation/)
- [将 PPT 转换为 PNG（Java）](/slides/zh/java/convert-powerpoint-to-png/)

## **关于 PPT 转换为 PPTX**

使用 Aspose.Slides API 将旧的 PPT 格式转换为 PPTX。如果您需要将成千上万的 PPT 演示文稿转换为 PPTX 格式，最佳解决方案是以编程方式进行。借助 Aspose.Slides API，只需几行代码即可完成。该 API 完全兼容将 PPT 演示文稿转换为 PPTX，并且可以：

- 转换复杂的母版、布局和幻灯片结构。
- 转换包含图表的演示文稿。
- 转换包含组合形状、自动形状（如矩形和椭圆）以及自定义几何形状的演示文稿。
- 转换在自动形状上具有纹理和图片填充样式的演示文稿。
- 转换包含占位符、文本框和文本持有者的演示文稿。

{{% alert color="primary" %}} 

请查看 [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/conversion/ppt-to-pptx) 应用程序：

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

此应用程序基于 [**Aspose.Slides API**](https://products.aspose.com/slides/java/) 构建，您可以看到基本 PPT 转换为 PPTX 功能的实时示例。Aspose.Slides Conversion 是一个网页应用，允许将 PPT 格式的演示文件拖放进去并下载转换后的 PPTX。

查找其他实时的 [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) 示例。

{{% /alert %}} 

## **将 PPT 转换为 PPTX**

Aspose.Slides for Java 现在让开发人员能够使用 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) 类实例访问 PPT 并将其转换为相应的 [PPTX](https://docs.fileformat.com/presentation/pptx/) 格式。目前，它支持对 [PPT ](https://docs.fileformat.com/presentation/ppt/) 的部分转换为 PPTX。有关 PPT 转换为 PPTX 支持和不支持的功能详情，请参阅此文档 [link](/slides/zh/java/ppt-to-pptx-conversion/)。

Aspose.Slides for Java 提供了表示 **PPTX** 演示文件的 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) 类。现在，实例化对象后，Presentation 类也可以访问 **PPT**。以下示例展示了如何将 PPT 演示文稿转换为 PPTX 演示文稿。

```java
// 实例化一个表示 PPTX 文件的 Presentation 对象
Presentation pres = new Presentation("Aspose.ppt");
try {
// 保存 PPTX 演示文稿为 PPTX 格式
    pres.save("ConvertedAspose.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**图示：源 PPT 演示文稿**|

上述代码片段在转换后生成下面的 PPTX 演示文稿

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**图示：转换后生成的 PPTX 演示文稿**|

## **常见问题**

**PPT 和 PPTX 格式有什么区别？**

PPT 是 Microsoft PowerPoint 使用的旧的二进制文件格式，而 PPTX 是随 Microsoft Office 2007 引入的基于 XML 的新格式。PPTX 文件提供更好的性能、更小的文件大小以及更好的数据恢复能力。

**Aspose.Slides 是否支持批量将多个 PPT 文件转换为 PPTX？**

是的，您可以在循环中使用 Aspose.Slides 以编程方式将多个 PPT 文件转换为 PPTX，适用于批量转换场景。

**转换后内容和格式会被保留吗？**

Aspose.Slides 在转换演示文稿时保持高保真度。幻灯片布局、动画、形状、图表和其他设计元素在 PPT 到 PPTX 的转换过程中都会被保留。

**我可以将 PPT 文件转换为 PDF 或 HTML 等其他格式吗？**

是的，Aspose.Slides 支持将 PPT 文件转换为[多种格式](https://reference.aspose.com/slides/java/com.aspose.slides/saveformat/)，包括 PDF、XPS、HTML、ODP，以及 PNG 和 JPEG 等图像格式。

**在未安装 Microsoft PowerPoint 的情况下可以将 PPT 转换为 PPTX 吗？**

是的，Aspose.Slides 是独立的 API，无需 Microsoft PowerPoint 或任何第三方软件即可执行转换。

**是否有在线工具可用于 PPT 转换为 PPTX？**

是的，您可以使用免费的 [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/conversion/ppt-to-pptx) 网页应用，在浏览器中直接进行转换，无需编写任何代码。