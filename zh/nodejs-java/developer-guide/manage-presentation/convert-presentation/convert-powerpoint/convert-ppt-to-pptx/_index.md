---
title: 在 JavaScript 中将 PPT 转换为 PPTX
linktitle: 将 PPT 转换为 PPTX
type: docs
weight: 20
url: /zh/nodejs-java/convert-ppt-to-pptx/
keywords: "Java 将 PPT 转换为 PPTX, PowerPoint PPT 在 JavaScript 中转换为 PPTX"
description: "在 JavaScript 中将 PowerPoint PPT 转换为 PPTX。"
---

## **概述**

本文介绍如何使用 JavaScript 将 PowerPoint 演示文稿从 PPT 格式转换为 PPTX 格式，以及使用在线 PPT 转 PPTX 转换应用程序。涵盖以下主题。

- 在 JavaScript 中将 PPT 转换为 PPTX

## **Java 将 PPT 转换为 PPTX**

有关将 PPT 转换为 PPTX 的 JavaScript 示例代码，请参见下面的章节 [转换 PPT 为 PPTX](#convert-ppt-to-pptx)。它仅加载 PPT 文件并以 PPTX 格式保存。通过指定不同的保存格式，还可以将 PPT 文件保存为 PDF、XPS、ODP、HTML 等多种格式，详见这些文章。

- [Java 将 PPT 转换为 PDF](https://docs.aspose.com/slides/nodejs-java/convert-powerpoint-to-pdf/)
- [Java 将 PPT 转换为 XPS](https://docs.aspose.com/slides/nodejs-java/convert-powerpoint-to-xps/)
- [Java 将 PPT 转换为 HTML](https://docs.aspose.com/slides/nodejs-java/convert-powerpoint-to-html/)
- [Java 将 PPT 转换为 ODP](https://docs.aspose.com/slides/nodejs-java/save-presentation/)
- [Java 将 PPT 转换为图像](https://docs.aspose.com/slides/nodejs-java/convert-powerpoint-to-png/)

## **关于 PPT 转 PPTX 转换**
使用 Aspose.Slides API 将旧的 PPT 格式转换为 PPTX。如果需要将数千个 PPT 演示文稿转换为 PPTX 格式，最佳方案是以编程方式完成。借助 Aspose.Slides API，只需几行代码即可实现。该 API 完全兼容将 PPT 演示文稿转换为 PPTX，并且可以：

- 转换包含复杂母版、版式和幻灯片的结构。
- 转换包含图表的演示文稿。
- 转换包含组合形状、自动形状（如矩形和椭圆）、具有自定义几何形状的演示文稿。
- 转换具有纹理和图片填充样式的自动形状的演示文稿。
- 转换包含占位符、文本框和文本持有者的演示文稿。

{{% alert color="primary" %}} 

查看 [**Aspose.Slides PPT 转换为 PPTX**](https://products.aspose.app/slides/conversion/ppt-to-pptx) 应用：

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

此应用基于 [**Aspose.Slides API**](https://products.aspose.com/slides/nodejs-java/) 构建，您可以看到基本 PPT 转 PPTX 转换功能的实时示例。Aspose.Slides Conversion 是一个 Web 应用，允许将 PPT 格式的演示文件拖入并下载已转换为 PPTX 的文件。

查找其他实时 [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) 示例。
{{% /alert %}} 

## **将 PPT 转换为 PPTX**
Aspose.Slides for Node.js via Java 现已支持开发者使用 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) 类实例访问 PPT，并将其转换为相应的 [PPTX](https://docs.fileformat.com/presentation/pptx/) 格式。目前，它支持将 [PPT](https://docs.fileformat.com/presentation/ppt/) 部分转换为 PPTX。有关 PPT 转 PPTX 转换支持和不支持的功能的更多详细信息，请参阅此文档 [link](/slides/zh/nodejs-java/ppt-to-pptx-conversion/)。

Aspose.Slides for Node.js via Java 提供了表示 **PPTX** 演示文稿文件的 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) 类。当实例化对象时，Presentation 类现在也可以访问 **PPT**。下面的示例演示如何将 PPT 演示文稿转换为 PPTX 演示文稿。
```javascript
// 实例化一个表示 PPTX 文件的 Presentation 对象
var pres = new aspose.slides.Presentation("Aspose.ppt");
try {
    // 将 PPTX 演示文稿保存为 PPTX 格式
    pres.save("ConvertedAspose.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**图：源 PPT 演示文稿**|

上述代码片段在转换后生成了以下 PPTX 演示文稿

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**图：转换后生成的 PPTX 演示文稿**|

## **常见问题**

**PPT 和 PPTX 格式有什么区别？**

PPT 是 Microsoft PowerPoint 使用的旧二进制文件格式，而 PPTX 是随 Microsoft Office 2007 引入的基于 XML 的新格式。PPTX 文件提供更好的性能、更小的文件大小以及改进的数据恢复能力。

**Aspose.Slides 是否支持批量将多个 PPT 文件转换为 PPTX？**

是的，您可以在循环中使用 Aspose.Slides 以编程方式批量将多个 PPT 文件转换为 PPTX，适用于批量转换场景。

**转换后内容和格式会被保留吗？**

Aspose.Slides 在转换演示文稿时保持高度保真。幻灯片版式、动画、形状、图表和其他设计元素在 PPT 转 PPTX 转换过程中都会被保留。

**我可以将 PPT 文件转换为 PDF 或 HTML 等其他格式吗？**

是的，Aspose.Slides 支持将 PPT 文件转换为多种格式，包括 PDF、XPS、HTML、ODP 以及 PNG、JPEG 等图像格式。

**是否可以在未安装 Microsoft PowerPoint 的情况下将 PPT 转换为 PPTX？**

可以，Aspose.Slides 是独立的 API，无需 Microsoft PowerPoint 或任何第三方软件即可执行转换。

**是否有在线工具可用于 PPT 转 PPTX 转换？**

是的，您可以使用免费的 [Aspose.Slides PPT 转 PPTX 转换器](https://products.aspose.app/slides/conversion/ppt-to-pptx) Web 应用直接在浏览器中完成转换，无需编写任何代码。