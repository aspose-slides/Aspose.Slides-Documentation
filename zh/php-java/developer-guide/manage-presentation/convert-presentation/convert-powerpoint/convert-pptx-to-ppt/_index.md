---
title: 将PPTX转换为PPT
linktitle: 将PPTX转换为PPT
type: docs
weight: 21
url: /zh/php-java/convert-pptx-to-ppt/
keywords: "PHP 将PPTX转换为PPT, 转换PowerPoint演示文稿, PPTX到PPT, Java, Aspose.Slides"
description: "将PowerPoint PPTX转换为PPT "
---

## **概述**

本文说明如何使用PHP将PPTX格式的PowerPoint演示文稿转换为PPT格式。以下主题进行了介绍。

- 将PPTX转换为PPT

## **Java将PPTX转换为PPT**

有关将PPTX转换为PPT的Java示例代码，请参见下面的部分，即[将PPTX转换为PPT](#convert-pptx-to-ppt)。它仅加载PPTX文件并以PPT格式保存。通过指定不同的保存格式，您还可以将PPTX文件保存为许多其他格式，如PDF、XPS、ODP、HTML等，如这些文章中所讨论的。

- [Java将PPTX转换为PDF](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-pdf/)
- [Java将PPTX转换为XPS](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-xps/)
- [Java将PPTX转换为HTML](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-html/)
- [Java将PPTX转换为ODP](https://docs.aspose.com/slides/php-java/save-presentation/)
- [Java将PPTX转换为图像](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-png/)

## **将PPTX转换为PPT**
要将PPTX转换为PPT，只需将文件名和保存格式传递给[**Presentation**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)类的**Save**方法。以下PHP代码示例使用默认选项将PPTX演示文稿转换为PPT。

```php
  # 实例化表示PPTX文件的Presentation对象
  $presentation = new Presentation("template.pptx");
  # 将演示文稿保存为PPT
  $presentation->save("output.ppt", SaveFormat::Ppt);

```