---
title: 在Java中将PPT转换为PPTX
linktitle: 在Java中将PPT转换为PPTX
type: docs
weight: 20
url: /zh/java/convert-ppt-to-pptx/
keywords: "Java 将PPT转换为PPTX, PowerPoint PPT在Java中转换为PPTX"
description: "在Java中将PowerPoint PPT转换为PPTX。"
---

## **概述**

本文介绍如何使用Java将PPT格式的PowerPoint演示文稿转换为PPTX格式，以及使用在线PPT到PPTX转换应用。涵盖以下主题。

- 在Java中将PPT转换为PPTX

## **Java将PPT转换为PPTX**

有关将PPT转换为PPTX的Java示例代码，请参见以下部分，即[将PPT转换为PPTX](#convert-ppt-to-pptx)。它只需加载PPT文件并以PPTX格式保存。通过指定不同的保存格式，您还可以将PPT文件保存为PDF、XPS、ODP、HTML等多种其他格式，如这些文章中所讨论的。

- [Java将PPT转换为PDF](https://docs.aspose.com/slides/java/convert-powerpoint-to-pdf/)
- [Java将PPT转换为XPS](https://docs.aspose.com/slides/java/convert-powerpoint-to-xps/)
- [Java将PPT转换为HTML](https://docs.aspose.com/slides/java/convert-powerpoint-to-html/)
- [Java将PPT转换为ODP](https://docs.aspose.com/slides/java/save-presentation/)
- [Java将PPT转换为图像](https://docs.aspose.com/slides/java/convert-powerpoint-to-png/)

## **关于PPT到PPTX转换**
使用Aspose.Slides API将旧的PPT格式转换为PPTX。如果您需要将数千个PPT演示文稿转换为PPTX格式，最佳的解决方案是以编程方式进行。使用Aspose.Slides API，您可以仅用几行代码做到这一点。该API支持完全兼容性，以将PPT演示文稿转换为PPTX，您可以：

- 转换复杂的母版、布局和幻灯片结构。
- 转换包含图表的演示文稿。
- 转换包含组合形状、自动形状（如矩形和椭圆）、具有自定义几何形状的形状的演示文稿。
- 转换具有纹理和图像填充样式的自动形状的演示文稿。
- 转换具有占位符、文本框和文本持有者的演示文稿。

{{% alert color="primary" %}} 

查看[**Aspose.Slides PPT到PPTX转换**](https://products.aspose.app/slides/conversion/ppt-to-pptx)应用：

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

此应用是基于[**Aspose.Slides API**](https://products.aspose.com/slides/java/)构建的，因此您可以看到基本的PPT到PPTX转换功能的实时示例。Aspose.Slides转换是一个网络应用，允许将PPT格式的演示文稿文件拖放并下载转换为PPTX的文件。

查找其他实时[**Aspose.Slides转换**](https://products.aspose.app/slides/conversion/)示例。
{{% /alert %}} 

## **将PPT转换为PPTX**
Aspose.Slides for Java现在使开发人员可以通过[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation)类实例访问PPT，并将其转换为相应的[PPTX](https://docs.fileformat.com/presentation/pptx/)格式。目前，它支持对[PPT](https://docs.fileformat.com/presentation/ppt/)到PPTX的部分转换。有关PPT到PPTX转换支持和不支持的功能的更多详细信息，请访问此文档[链接](/slides/zh/java/ppt-to-pptx-conversion/)。

Aspose.Slides for Java提供了表示**PPTX**演示文稿文件的[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation)类。现在，实例化对象时，Presentation类也可以访问**PPT**。以下示例展示了如何将PPT演示文稿转换为PPTX演示文稿。

```java
// 实例化表示PPTX文件的Presentation对象
Presentation pres = new Presentation("Aspose.ppt");
try {
// 将PPTX演示文稿保存为PPTX格式
    pres.save("ConvertedAspose.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**图 : 源PPT演示文稿**|

上述代码段在转换后生成了以下PPTX演示文稿

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**图：转换后生成的PPTX演示文稿**|