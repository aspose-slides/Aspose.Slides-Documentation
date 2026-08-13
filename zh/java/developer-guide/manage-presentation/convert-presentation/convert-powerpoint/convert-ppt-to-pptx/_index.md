---
title: 在 Java 中将 PPT 转换为 PPTX
linktitle: PPT 转 PPTX
type: docs
weight: 20
url: /zh/java/convert-ppt-to-pptx/
keywords:
- 转换 PowerPoint
- 转换演示文稿
- 转换幻灯片
- 转换 PPT
- PPT 转 PPTX
- 将 PPT 保存为 PPTX
- 导出 PPT 为 PPTX
- PowerPoint
- 演示文稿
- Java
- Aspose.Slides
description: "使用 Aspose.Slides 在 Java 中快速将传统 PPT 演示文稿转换为现代 PPTX —— 清晰教程、免费代码示例，无需 Microsoft Office 依赖。"
---
## **概述**

本文介绍如何使用 Java 以及在线 PPT 转 PPTX 转换应用将 PowerPoint 演示文稿的 PPT 格式转换为 PPTX 格式。涵盖以下主题。

- 在 Java 中将 PPT 转换为 PPTX

## **在 Java 中将 PPT 转换为 PPTX**

有关将 PPT 转换为 PPTX 的 Java 示例代码，请参见下面的章节，即 [Convert PPT to PPTX](#convert-ppt-to-pptx)。它仅加载 PPT 文件并保存为 PPTX 格式。通过指定不同的保存格式，还可以将 PPT 文件保存为 PDF、XPS、ODP、HTML 等多种格式，详见这些文章。

- [在 Java 中将 PPT 转换为 PDF](/slides/zh/java/convert-powerpoint-to-pdf/)
- [在 Java 中将 PPT 转换为 XPS](/slides/zh/java/convert-powerpoint-to-xps/)
- [在 Java 中将 PPT 转换为 HTML](/slides/zh/java/convert-powerpoint-to-html/)
- [在 Java 中将 PPT 转换为 ODP](/slides/zh/java/save-presentation/)
- [在 Java 中将 PPT 转换为 PNG](/slides/zh/java/convert-powerpoint-to-png/)

## **关于 PPT 到 PPTX 的转换**
使用 Aspose.Slides API 将旧的 PPT 格式转换为 PPTX。如果需要将成千上万的 PPT 演示文稿批量转换为 PPTX 格式，最佳方案是以编程方式完成。借助 Aspose.Slides API，只需几行代码即可实现。该 API 完全兼容将 PPT 演示文稿转换为 PPTX，能够：

- 转换母版、布局和幻灯片的复杂结构。
- 转换包含图表的演示文稿。
- 转换包含组形状、自动形状（如矩形和椭圆）、自定义几何形状的演示文稿。
- 转换在自动形状中具有纹理和图片填充样式的演示文稿。
- 转换包含占位符、文本框和文本持有者的演示文稿。

{{% alert color="info" %}} 

请查看 [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/zh/conversion/ppt-to-pptx) 应用程序：

[](https://products.aspose.app/slides/zh/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/zh/conversion/ppt-to-pptx)

此应用基于 [**Aspose.Slides API**](https://products.aspose.com/slides/zh/java/) 构建，您可以看到基本 PPT 转 PPTX 转换功能的实时示例。Aspose.Slides Conversion 是一个 Web 应用，允许将 PPT 格式的演示文件拖入并下载已转换为 PPTX 的文件。

查看其他实时的 [**Aspose.Slides Conversion**](https://products.aspose.app/slides/zh/conversion/) 示例。
{{% /alert %}} 

## **将 PPT 转换为 PPTX**
Aspose.Slides for Java 现在使开发者能够通过 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation) 类实例访问 PPT 并将其转换为相应的 [PPTX](https://docs.fileformat.com/presentation/pptx/) 格式。目前，它支持将 [PPT ](https://docs.fileformat.com/presentation/ppt/) 部分转换为 PPTX。有关 PPT 转 PPTX 转换支持和不支持的功能详情，请访问此文档 [link](/slides/zh/java/ppt-to-pptx-conversion/)。

Aspose.Slides for Java 提供了表示 **PPTX** 演示文稿文件的 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation) 类。实例化对象后，Presentation 类现在也可以访问 **PPT**。以下示例展示了如何将 PPT 演示文稿转换为 PPTX 演示文稿。

```java
import com.aspose.slides.*;

// 实例化一个表示 PPT 文件的 Presentation 对象
Presentation pres = new Presentation("Aspose.ppt");
try {
    // 将 PPT 演示文稿保存为 PPTX 格式
    pres.save("ConvertedAspose.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**图 1：源 PPT 演示文稿**|

上述代码片段在转换后生成了以下 PPTX 演示文稿

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**图 2：转换后生成的 PPTX 演示文稿**|

## **常见问题**

### PPT 和 PPTX 格式有什么区别？

PPT 是 Microsoft PowerPoint 使用的旧二进制文件格式，而 PPTX 是随 Microsoft Office 2007 引入的基于 XML 的新格式。PPTX 文件提供更好的性能、更小的文件体积以及更完善的数据恢复能力。

### Aspose.Slides 是否支持批量将多个 PPT 文件转换为 PPTX？

是的，您可以在循环中使用 Aspose.Slides 以编程方式批量将多个 PPT 文件转换为 PPTX，适用于批量转换场景。

### 转换后内容和格式会被保留吗？

Aspose.Slides 在转换演示文稿时保持高保真度。幻灯片布局、动画、形状、图表及其它设计元素在 PPT 转 PPTX 的过程中都会被完整保留。

### 我可以将 PPT 文件转换为其他格式，如 PDF 或 HTML 吗？

是的，Aspose.Slides 支持将 PPT 文件转换为 [多种格式](https://reference.aspose.com/slides/zh/java/com.aspose.slides/saveformat/)，包括 PDF、XPS、HTML、ODP，以及 PNG、JPEG 等图像格式。

### 在未安装 Microsoft PowerPoint 的情况下可以将 PPT 转换为 PPTX 吗？

可以，Aspose.Slides 是独立的 API，无需 Microsoft PowerPoint 或任何第三方软件即可执行转换。

### 是否有在线工具可用于 PPT 转换为 PPTX？

是的，您可以使用免费的 [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/zh/conversion/ppt-to-pptx) 网络应用直接在浏览器中完成转换，无需编写任何代码。