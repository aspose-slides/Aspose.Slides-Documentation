---
title: 将PPT转换为PPTX
linktitle: 将PPT转换为PPTX
type: docs
weight: 20
url: /zh/php-java/convert-ppt-to-pptx/
keywords: "PHP 将PPT转换为PPTX, PowerPoint PPT到PPTX"
description: "将PowerPoint PPT转换为PPTX。"
---

## **概述**

本文解释了如何使用PHP和在线PPT到PPTX转换应用将PPT格式的PowerPoint演示文稿转换为PPTX格式。以下主题涵盖了。

- 将PPT转换为PPTX

## **Java将PPT转换为PPTX**

有关将PPT转换为PPTX的Java示例代码，请参见下面的部分，即[将PPT转换为PPTX](#convert-ppt-to-pptx)。它只需加载PPT文件并以PPTX格式保存。通过指定不同的保存格式，您还可以将PPT文件保存为许多其他格式，如PDF、XPS、ODP、HTML等，如这些文章中讨论的。

- [Java将PPT转换为PDF](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-pdf/)
- [Java将PPT转换为XPS](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-xps/)
- [Java将PPT转换为HTML](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-html/)
- [Java将PPT转换为ODP](https://docs.aspose.com/slides/php-java/save-presentation/)
- [Java将PPT转换为图像](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-png/)

## **关于PPT到PPTX的转换**
使用Aspose.Slides API将旧的PPT格式转换为PPTX。如果您需要将数千个PPT演示文稿转换为PPTX格式，最好以编程方式进行。借助Aspose.Slides API，只需几行代码即可实现。该API支持完全兼容性以将PPT演示文稿转换为PPTX，可以做到：

- 转换复杂的母版、布局和幻灯片结构。
- 转换带有图表的演示文稿。
- 转换带有组合形状、自动形状（如矩形和椭圆）、具有自定义几何形状的形状的演示文稿。
- 转换具有纹理和图片填充样式的自动形状的演示文稿。
- 转换具有占位符、文本框和文本持有者的演示文稿。

{{% alert color="primary" %}} 

请查看[**Aspose.Slides PPT到PPTX转换**](https://products.aspose.app/slides/conversion/ppt-to-pptx)应用：

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

此应用基于[**Aspose.Slides API**](https://products.aspose.com/slides/php-java/)构建，因此您可以看到基本PPT到PPTX转换能力的实时示例。Aspose.Slides转换是一个Web应用，允许将PPT格式的演示文稿文件拖放并下载转换为PPTX格式。

查找其他实时[**Aspose.Slides转换**](https://products.aspose.app/slides/conversion/)示例。
{{% /alert %}} 

## **将PPT转换为PPTX**
Aspose.Slides for PHP通过Java现在使开发人员能够使用[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)类实例访问PPT，并将其转换为相应的[PPTX](https://docs.fileformat.com/presentation/pptx/)格式。目前，它支持将[PPT](https://docs.fileformat.com/presentation/ppt/)部分转换为PPTX。有关PPT到PPTX转换中支持和不支持的功能的更多详细信息，请访问此文档[链接](/slides/zh/php-java/ppt-to-pptx-conversion/)。

Aspose.Slides for PHP通过Java提供了表示**PPTX**演示文稿文件的[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)类。现在，当实例化对象时，Presentation类也可以通过Presentation访问**PPT**。以下示例演示如何将PPT演示文稿转换为PPTX演示文稿。

```php
  # 实例化一个表示PPTX文件的Presentation对象
  $pres = new Presentation("Aspose.ppt");
  try {
    # 将PPTX演示文稿保存为PPTX格式
    $pres->save("ConvertedAspose.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**图：源PPT演示文稿**|

上述代码片段在转换后生成了以下PPTX演示文稿

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**图：转换后生成的PPTX演示文稿**|