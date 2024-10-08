---
title: 将 PowerPoint 转换为 PDF
linktitle: 将 PowerPoint 转换为 PDF
type: docs
weight: 40
url: /php-java/convert-powerpoint-to-pdf/
keywords: "将 PowerPoint 转换, 演示文稿, PowerPoint 转 PDF, PPT 转 PDF, PPTX 转 PDF, 将 PowerPoint 保存为 PDF, PDF/A1a, PDF/A1b, PDF/UA, Java"
description: "将 PowerPoint 演示文稿转换为 PDF。将 PowerPoint 保存为符合标准或无障碍标准的 PDF"

---
## **概述**

本文解释了如何使用 PHP 将 PowerPoint 文件格式转换为 PDF。它涵盖了广泛的主题，例如：

- 将 PPT 转换为 PDF
- 将 PPTX 转换为 PDF
- 将 ODP 转换为 PDF
- 将 PowerPoint 转换为 PDF

## **Java PowerPoint 转 PDF 转换**

使用 Aspose.Slides，您可以将这些格式的演示文稿转换为 PDF：

* PPT
* PPTX
* ODP

要将演示文稿转换为 PDF，您只需将文件名作为参数传递给 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类，然后使用 [Save](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-) 方法将演示文稿保存为 PDF。[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类公开了通常用于将演示文稿转换为 PDF 的 [Save](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-) 方法。

{{%  alert title="注意"  color="warning"   %}} 

Aspose.Slides for PHP 通过 Java 直接在输出文档中写入 API 信息和版本号。例如，当它将演示文稿转换为 PDF 时，Aspose.Slides for PHP 通过 Java 将应用程序字段填入 '*Aspose.Slides*' 值，PDF 生产者字段填入 '*Aspose.Slides v XX.XX*' 形式的值。**注意**，您无法指示 Aspose.Slides for PHP 通过 Java 更改或删除输出文档中的此信息。

{{% /alert %}}

Aspose.Slides 允许您转换：

* 整个演示文稿为 PDF
* 演示文稿中特定的幻灯片为 PDF
* 一个演示文稿 

Aspose.Slides 将演示文稿导出为 PDF，使结果 PDF 的内容与原始演示文稿非常相似。以下已知元素和属性通常在演示文稿转换为 PDF 时正确呈现：

* 图片
* 文本框和其他形状
* 文本及其格式
* 段落及其格式
* 超链接
* 页眉和页脚
* 项目符号
* 表格

## **将 PowerPoint 转换为 PDF**

标准的 PowerPoint PDF 转换操作使用默认选项执行。在这种情况下，Aspose.Slides 尝试使用最佳设置在最高质量级别下将提供的演示文稿转换为 PDF。

以下 PHP 代码演示了如何将 PowerPoint 转换为 PDF：

```php
  # 实例化一个表示 PowerPoint 文件的 Presentation 类
  $pres = new Presentation("PowerPoint.ppt");
  try {
    # 将演示文稿保存为 PDF
    $pres->save("PPT-to-PDF.pdf", SaveFormat::Pdf);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{%  alert  color="primary"  %}} 

Aspose 提供了一个免费的在线 [**PowerPoint 转 PDF 转换器**](https://products.aspose.app/slides/conversion/ppt-to-pdf)，演示演示文稿到 PDF 的转换过程。要对这里描述的过程进行实时实现，您可以用该转换器进行测试。

{{% /alert %}}

## **带选项的 PowerPoint 转 PDF**

Aspose.Slides 提供自定义选项——[PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/PdfOptions) 类下的属性——允许您自定义 PDF（转换过程中生成的 PDF），为 PDF 设置密码保护，或甚至指定转换过程应如何进行。

### **带自定义选项的 PowerPoint 转 PDF**

使用自定义转换选项，您可以为 JPG 图像设置首选质量设置，指定如何处理元文件，设置文本的压缩级别等。

以下 PHP 代码演示了在多个自定义选项下将 PowerPoint 转换为 PDF 的操作：

```php
// 实例化一个表示 PowerPoint 文件的 Presentation 类
  $pres = new Presentation("PowerPoint.pptx");
  try {
    # 实例化 PdfOptions 类
    $pdfOptions = new PdfOptions();
    # 设置 JPEG 质量
    $pdfOptions->setJpegQuality(90);
    # 设置元文件的行为
    $pdfOptions->setSaveMetafilesAsPng(true);
    # 设置文本的压缩级别
    $pdfOptions->setTextCompression(PdfTextCompression::Flate);
    # 定义 PDF 标准
    $pdfOptions->setCompliance(PdfCompliance::Pdf15);
    # 将演示文稿保存为 PDF
    $pres->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **带隐藏幻灯片的 PowerPoint 转 PDF**

如果演示文稿包含隐藏幻灯片，您可以使用自定义选项——[ShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/IPdfOptions#getShowHiddenSlides--) 属性来自 [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/PdfOptions) 类——指示 Aspose.Slides 将隐藏幻灯片包含为结果 PDF 中的页面。

以下 PHP 代码展示了如何将 PowerPoint 演示文稿转换为包含隐藏幻灯片的 PDF：

```php
// 实例化一个表示 PowerPoint 文件的 Presentation 类
  $pres = new Presentation("PowerPoint.pptx");
  try {
    # 实例化 PdfOptions 类
    $pdfOptions = new PdfOptions();
    # 添加隐藏幻灯片
    $pdfOptions->setShowHiddenSlides(true);
    # 将演示文稿保存为 PDF
    $pres->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **将 PowerPoint 转换为受密码保护的 PDF**

以下 PHP 代码演示了如何将 PowerPoint 转换为受密码保护的 PDF（使用来自 [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/PdfOptions) 类的保护参数）：

```php
// 实例化一个表示 PowerPoint 文件的 Presentation 对象
  $pres = new Presentation("PowerPoint.pptx");
  try {
    # / 实例化 PdfOptions 类
    $pdfOptions = new PdfOptions();
    # 设置 PDF 密码和访问权限
    $pdfOptions->setPassword("password");
    $pdfOptions->setAccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);
    # 将演示文稿保存为 PDF
    $pres->save("PPTX-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **检测字体替代**

Aspose.Slides 在 [SaveOptions](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/) 类下提供 [getWarningCallback](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#getWarningCallback--) 方法，允许您在演示文稿到 PDF 转换过程中检测字体替代。

以下 PHP 代码演示了如何检测字体替代：

```php

class FontSubstSendsWarningCallback {
    function warning($warning)
    {
          if (java_values($warning->getWarningType() == WarningType::CompatibilityIssue)) {
            return ReturnAction::Continue;
          }
          if (java_values($warning->getWarningType() == WarningType::DataLoss && $warning->getDescription()->startsWith("Font will be substituted"))) {
            echo ("字体替代警告: " . $warning->getDescription());
          }
          return ReturnAction::Continue;
    }
}

  $loadOptions = new LoadOptions();
  $warningCallback = java_closure(new FontSubstSendsWarningCallback(), null, java("com.aspose.slides.IWarningCallback"));
  $loadOptions->setWarningCallback($warningCallback);
  $pres = new Presentation("pres.pptx", $loadOptions);
  try {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{%  alert color="primary"  %}} 

有关在渲染过程中获取字体替代的回调的更多信息，请参阅 [获取字体替代的警告回调](https://docs.aspose.com/slides/php-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/) 。

有关字体替代的更多信息，请参阅 [字体替代](https://docs.aspose.com/slides/php-java/font-substitution/) 文章。

{{% /alert %}} 

## **将 PowerPoint 中的选定幻灯片转换为 PDF**

以下 PHP 代码演示了如何将 PowerPoint 演示文稿中特定的幻灯片转换为 PDF：

```php
// 实例化一个表示 PowerPoint 文件的 Presentation 对象
  $pres = new Presentation("PowerPoint.pptx");
  try {
    # 设置幻灯片位置数组
    $slides = array(1, 3 );
    # 将演示文稿保存为 PDF
    $pres->save("PPTX-to-PDF.pdf", $slides, SaveFormat::Pdf);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **使用自定义幻灯片大小将 PowerPoint 转换为 PDF**

以下 PHP 代码演示了如何在指定幻灯片大小时将 PowerPoint 转换为 PDF：

```php
// 实例化一个表示 PowerPoint 文件的 Presentation 对象 
  $pres = new Presentation("SelectedSlides.pptx");
  try {
    $outPres = new Presentation();
    try {
      $slide = $pres->getSlides()->get_Item(0);
      $outPres->getSlides()->insertClone(0, $slide);
      # 设置幻灯片类型和大小
      $outPres->getSlideSize()->setSize(612.0, 792.0, SlideSizeScaleType::EnsureFit);
      $pdfOptions = new PdfOptions();
      $options = $pdfOptions->getNotesCommentsLayouting();
      $options->setNotesPosition(NotesPositions::BottomFull);
      $outPres->save("PDFnotes_out.pdf", SaveFormat::Pdf, $pdfOptions);
    } finally {
      if (!java_is_null($pres)) {
        $pres->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **在讲义幻灯片视图中将 PowerPoint 转换为 PDF**

以下 PHP 代码演示了如何将 PowerPoint 转换为 PDF 讲义：

```php
// 实例化一个表示 PowerPoint 文件的 Presentation 类
  $pres = new Presentation("SelectedSlides.pptx");
  try {
    $pdfOptions = new PdfOptions();
    $options = $pdfOptions->getNotesCommentsLayouting();
    $options->setNotesPosition(NotesPositions::BottomFull);
    $pres->save("Pdf_With_Notes.pdf", SaveFormat::Pdf, $pdfOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **PDF 的无障碍性和合规性标准**

Aspose.Slides 允许您使用符合 [网页内容无障碍指南 (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) 的转换程序。您可以使用以下合规标准之一将 PowerPoint 文档导出为 PDF：**PDF/A1a**，**PDF/A1b** 和 **PDF/UA**。

以下 PHP 代码演示了一个 PowerPoint 到 PDF 的转换操作，其中根据不同的合规标准获得多个 PDF：

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pdfOptions = new PdfOptions();
    $pdfOptions->setCompliance(PdfCompliance::PdfA1a);
    $pres->save("pres-a1a-compliance.pdf", SaveFormat::Pdf, $pdfOptions);
    $pdfOptions->setCompliance(PdfCompliance::PdfA1b);
    $pres->save("pres-a1b-compliance.pdf", SaveFormat::Pdf, $pdfOptions);
    $pdfOptions->setCompliance(PdfCompliance::PdfUa);
    $pres->save("pres-ua-compliance.pdf", SaveFormat::Pdf, $pdfOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="注意" color="warning" %}} 

Aspose.Slides 对 PDF 转换操作的支持扩展到允许您将 PDF 转换为最流行的文件格式。您可以进行 [PDF 转 HTML](https://products.aspose.com/slides/php-java/conversion/pdf-to-html/)，[PDF 转图像](https://products.aspose.com/slides/php-java/conversion/pdf-to-image/)，[PDF 转 JPG](https://products.aspose.com/slides/php-java/conversion/pdf-to-jpg/)，和 [PDF 转 PNG](https://products.aspose.com/slides/php-java/conversion/pdf-to-png/) 的转换。其他转换操作包括将 PDF 转换为专业格式——[PDF 转 SVG](https://products.aspose.com/slides/php-java/conversion/pdf-to-svg/)，[PDF 转 TIFF](https://products.aspose.com/slides/php-java/conversion/pdf-to-tiff/)，和 [PDF 转 XML](https://products.aspose.com/slides/php-java/conversion/pdf-to-xml/)。

{{% /alert %}}