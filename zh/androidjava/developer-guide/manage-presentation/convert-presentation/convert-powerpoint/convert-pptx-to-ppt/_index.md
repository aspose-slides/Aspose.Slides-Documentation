---
title: 在 Java 中将 PPTX 转换为 PPT
linktitle: 在 Java 中将 PPTX 转换为 PPT
type: docs
weight: 21
url: /zh/androidjava/convert-pptx-to-ppt/
keywords: "Java 将 PPTX 转换为 PPT, 转换 PowerPoint 演示文稿, PPTX 转 PPT, Java, Aspose.Slides"
description: "在 Java 中将 PowerPoint PPTX 转换为 PPT"
---

## **概述**

本文解释了如何使用 Java 将 PPTX 格式的 PowerPoint 演示文稿转换为 PPT 格式。以下主题将被覆盖。

- 在 Java 中将 PPTX 转换为 PPT

## **Java 将 PPTX 转换为 PPT**

有关将 PPTX 转换为 PPT 的 Java 示例代码，请参见下面的部分，即 [将 PPTX 转换为 PPT](#convert-pptx-to-ppt)。它仅加载 PPTX 文件并以 PPT 格式保存。通过指定不同的保存格式，您还可以将 PPTX 文件保存为 PDF、XPS、ODP、HTML 等多种其他格式，如这些文章中所讨论的。

- [Java 将 PPTX 转换为 PDF](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-pdf/)
- [Java 将 PPTX 转换为 XPS](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-xps/)
- [Java 将 PPTX 转换为 HTML](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-html/)
- [Java 将 PPTX 转换为 ODP](https://docs.aspose.com/slides/androidjava/save-presentation/)
- [Java 将 PPTX 转换为图像](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-png/)

## **将 PPTX 转换为 PPT**
要将 PPTX 转换为 PPT，只需将文件名和保存格式传递给 [**Presentation**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的 **Save** 方法。下面的 Java 代码示例使用默认选项将演示文稿从 PPTX 转换为 PPT。

```java
// 实例化一个表示 PPTX 文件的 Presentation 对象
Presentation presentation = new Presentation("template.pptx");

// 将演示文稿保存为 PPT
presentation.save("output.ppt", SaveFormat.Ppt);  
```