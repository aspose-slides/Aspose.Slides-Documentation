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
description: "使用 Aspose.Slides for Android 在 Java 中快速将旧版 PPT 演示文稿转换为现代 PPTX — 教程清晰，提供免费代码示例，无需 Microsoft Office 依赖。"
---

## **概述**

本文说明如何使用 Java 和在线 PPT 转 PPTX 转换应用程序，将 PowerPoint 演示文稿的 PPT 格式转换为 PPTX 格式。涉及以下主题。

- 将 PPT 转换为 PPTX（Java）

## **在 Android 上将 PPT 转换为 PPTX**

有关将 PPT 转换为 PPTX 的 Java 示例代码，请参阅下面的章节，即[将 PPT 转换为 PPTX](#convert-ppt-to-pptx)。它仅加载 PPT 文件并以 PPTX 格式保存。通过指定不同的保存格式，还可以将 PPT 文件保存为 PDF、XPS、ODP、HTML 等多种格式，详见这些文章。

- [在 Android 上将 PPT 转换为 PDF](/slides/zh/androidjava/convert-powerpoint-to-pdf/)
- [在 Android 上将 PPT 转换为 XPS](/slides/zh/androidjava/convert-powerpoint-to-xps/)
- [在 Android 上将 PPT 转换为 HTML](/slides/zh/androidjava/convert-powerpoint-to-html/)
- [在 Android 上将 PPT 转换为 ODP](/slides/zh/androidjava/save-presentation/)
- [在 Android 上将 PPT 转换为 PNG](/slides/zh/androidjava/convert-powerpoint-to-png/)

## **关于 PPT 转 PPTX 转换**

使用 Aspose.Slides API 将旧的 PPT 格式转换为 PPTX。如果需要将成千上万的 PPT 演示文稿转换为 PPTX 格式，最好的解决方案是以编程方式完成。使用 Aspose.Slides API 可以仅用几行代码实现。该 API 完全兼容 PPT 转 PPTX，并能够：

- 转换复杂的母版、布局和幻灯片结构。
- 转换包含图表的演示文稿。
- 转换包含组合形状、自动形状（如矩形和椭圆）、自定义几何形状的演示文稿。
- 转换对自动形状使用纹理和图片填充样式的演示文稿。
- 转换包含占位符、文本框和文本持有者的演示文稿。

{{% alert color="primary" %}} 

查看[**Aspose.Slides PPT 转 PPTX 转换**](https://products.aspose.app/slides/conversion/ppt-to-pptx)应用程序：

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

该应用基于[**Aspose.Slides API**](https://products.aspose.com/slides/androidjava/)构建，您可以看到基本 PPT 转 PPTX 转换功能的实时示例。Aspose.Slides Conversion 是一个 Web 应用，允许将 PPT 格式的演示文件拖入并下载已转换为 PPTX 的文件。

查找其他实时的[**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/)示例。
{{% /alert %}} 

## **将 PPT 转换为 PPTX**

Aspose.Slides for Android via Java 现已为开发者提供通过[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation)类实例访问 PPT 并将其转换为相应的[PPTX](https://docs.fileformat.com/presentation/pptx/)格式的能力。目前，它支持将[PPT ](https://docs.fileformat.com/presentation/ppt/)部分转换为 PPTX。

Aspose.Slides for Android via Java 提供的[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation)类表示一个**PPTX**演示文稿文件。实例化对象后，Presentation 类也可以访问**PPT**。下面的示例演示了如何将 PPT 演示文稿转换为 PPTX 演示文稿。
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
|**图 1：源 PPT 演示文稿**|

上述代码片段在转换后生成了以下 PPTX 演示文稿

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**图 2：转换后生成的 PPTX 演示文稿**|

## **常见问题**

**PPT 与 PPTX 格式有什么区别？**

PPT 是 Microsoft PowerPoint 使用的较早的二进制文件格式，而 PPTX 是自 Microsoft Office 2007 起引入的基于 XML 的新格式。PPTX 文件具有更好的性能、更小的文件大小以及更完善的数据恢复能力。

**Aspose.Slides 是否支持批量将多个 PPT 文件转换为 PPTX？**

是的，您可以在循环中使用 Aspose.Slides 以编程方式批量将多个 PPT 文件转换为 PPTX，适用于批量转换场景。

**转换后内容和格式会被保留吗？**

Aspose.Slides 在转换演示文稿时保持高度保真。幻灯片布局、动画、形状、图表以及其他设计元素在 PPT 转 PPTX 的过程中都会得到保留。

**我可以将 PPT 文件转换为 PDF 或 HTML 等其他格式吗？**

可以，Aspose.Slides 支持将 PPT 文件转换为[多种格式](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveformat/)，包括 PDF、XPS、HTML、ODP，以及 PNG、JPEG 等图像格式。

**是否可以在未安装 Microsoft PowerPoint 的情况下将 PPT 转换为 PPTX？**

可以，Aspose.Slides 是独立的 API，无需安装 Microsoft PowerPoint 或任何第三方软件即可完成转换。

**是否有可用于 PPT 转 PPTX 转换的在线工具？**

可以使用免费[Aspose.Slides PPT 转 PPTX 转换器](https://products.aspose.app/slides/conversion/ppt-to-pptx) Web 应用，在浏览器中直接完成转换，无需编写任何代码。