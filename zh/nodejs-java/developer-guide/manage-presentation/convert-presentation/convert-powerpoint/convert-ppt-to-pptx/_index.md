---
title: 在 JavaScript 中将 PPT 转换为 PPTX
linktitle: PPT 转 PPTX
type: docs
weight: 20
url: /zh/nodejs-java/convert-ppt-to-pptx/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js 将传统 PPT 演示文稿快速转换为现代 PPTX —— 清晰教程，免费代码示例，无需 Microsoft Office 依赖。"
---

## **概述**

本文说明如何使用 JavaScript 和在线 PPT 转 PPTX 转换应用将 PowerPoint 演示文稿的 PPT 格式转换为 PPTX 格式。涵盖以下主题。

- 在 JavaScript 中将 PPT 转换为 PPTX

## **Java 将 PPT 转换为 PPTX**

要查看用于将 PPT 转换为 PPTX 的 JavaScript 示例代码，请参见以下章节，即[Convert PPT to PPTX](#convert-ppt-to-pptx)。它仅加载 PPT 文件并以 PPTX 格式保存。通过指定不同的保存格式，还可以将 PPT 文件保存为 PDF、XPS、ODP、HTML 等多种格式，详见这些文章。

- [将 PPT 转换为 PDF（JavaScript）](/slides/zh/nodejs-java/convert-powerpoint-to-pdf/)
- [将 PPT 转换为 XPS（JavaScript）](/slides/zh/nodejs-java/convert-powerpoint-to-xps/)
- [将 PPT 转换为 HTML（JavaScript）](/slides/zh/nodejs-java/convert-powerpoint-to-html/)
- [将 PPT 转换为 ODP（JavaScript）](/slides/zh/nodejs-java/save-presentation/)
- [将 PPT 转换为 PNG（JavaScript）](/slides/zh/nodejs-java/convert-powerpoint-to-png/)

## **关于 PPT 转 PPTX 转换**

使用 Aspose.Slides API 将旧的 PPT 格式转换为 PPTX。如果需要将成千上万的 PPT 演示文稿批量转换为 PPTX 格式，最好的方案是以编程方式完成。借助 Aspose.Slides API，仅需几行代码即可实现。该 API 完全兼容 PPT 转 PPTX，并且可以：

- 转换包含复杂母版、布局和幻灯片的结构。
- 转换包含图表的演示文稿。
- 转换包含组合形状、自动形状（如矩形和椭圆）以及自定义几何形状的演示文稿。
- 转换对自动形状使用纹理和图片填充样式的演示文稿。
- 转换包含占位符、文本框和文字持有者的演示文稿。

{{% alert color="primary" %}} 

查看 [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/conversion/ppt-to-pptx) 应用：

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

此应用基于[**Aspose.Slides API**](https://products.aspose.com/slides/nodejs-java/)构建，您可以看到 PPT 转 PPTX 基本功能的实时示例。Aspose.Slides Conversion 是一个 Web 应用，允许将 PPT 格式的演示文件拖放进去并下载转换后的 PPTX。

查找其他实时的[**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) 示例。
{{% /alert %}} 

## **将 PPT 转换为 PPTX**
Aspose.Slides for Node.js via Java 现已帮助开发者使用[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation)类实例访问 PPT 并将其转换为相应的[PPTX](https://docs.fileformat.com/presentation/pptx/)格式。目前，它支持将[PPT ](https://docs.fileformat.com/presentation/ppt/)部分转换为 PPTX。

Aspose.Slides for Node.js via Java 提供了表示 **PPTX** 演示文稿文件的[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation)类。实例化对象后，Presentation 类同样可以访问 **PPT**。以下示例展示了如何将 PPT 演示文稿转换为 PPTX 演示文稿。
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
|**图 1：源 PPT 演示文稿**|

上述代码片段在转换后生成了以下 PPTX 演示文稿

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**图 2：转换后生成的 PPTX 演示文稿**|

## **常见问题**

**PPT 与 PPTX 格式有什么区别？**

PPT 是 Microsoft PowerPoint 使用的旧二进制文件格式，而 PPTX 是随 Microsoft Office 2007 引入的基于 XML 的新格式。PPTX 文件提供更好的性能、更小的文件尺寸以及改进的数据恢复能力。

**Aspose.Slides 是否支持批量将多个 PPT 文件转换为 PPTX？**

是的，您可以在循环中使用 Aspose.Slides 以编程方式批量将多个 PPT 文件转换为 PPTX，适用于批量转换场景。

**转换后内容和格式会被保留吗？**

Aspose.Slides 在转换演示文稿时保持高度保真。幻灯片布局、动画、形状、图表以及其他设计元素在 PPT 转 PPTX 过程中均会被保留。

**我可以将 PPT 文件转换为 PDF 或 HTML 等其他格式吗？**

是的，Aspose.Slides 支持将 PPT 文件转换为多种格式，包括 PDF、XPS、HTML、ODP 以及 PNG、JPEG 等图像格式。

**在未安装 Microsoft PowerPoint 的情况下可以将 PPT 转换为 PPTX 吗？**

可以，Aspose.Slides 是独立的 API，不需要 Microsoft PowerPoint 或任何第三方软件即可执行转换。

**是否有在线工具可用于 PPT 到 PPTX 的转换？**

是的，您可以使用免费的[Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/conversion/ppt-to-pptx)网络应用直接在浏览器中进行转换，无需编写任何代码。