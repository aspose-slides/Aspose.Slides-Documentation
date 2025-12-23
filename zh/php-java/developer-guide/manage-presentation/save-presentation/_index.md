---
title: 在 PHP 中保存演示文稿
linktitle: 保存演示文稿
type: docs
weight: 80
url: /zh/php-java/save-presentation/
keywords:
- 保存 PowerPoint
- 保存 OpenDocument
- 保存演示文稿
- 保存幻灯片
- 保存 PPT
- 保存 PPTX
- 保存 ODP
- 演示文稿到文件
- 演示文稿到流
- 预定义视图类型
- Strict Office Open XML 格式
- Zip64 模式
- 刷新缩略图
- 保存进度
- PHP
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for PHP（通过 Java）保存演示文稿——导出为 PowerPoint 或 OpenDocument，同时保留布局、字体和效果。"
---

## **概述**

[Open Presentations in PHP](/slides/zh/php-java/open-presentation/) 介绍了如何使用 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类打开演示文稿。本文说明如何创建和保存演示文稿。[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类包含演示文稿的内容。无论是从头创建演示文稿还是修改已有的，都需要在完成后保存。使用 Aspose.Slides for PHP，您可以保存到 **文件** 或 **流**。本文解释了保存演示文稿的不同方式。

## **将演示文稿保存到文件**

通过调用 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的 `save` 方法将演示文稿保存到文件。向该方法传递文件名和保存格式。以下示例展示了如何使用 Aspose.Slides 保存演示文稿。
```php
// 实例化表示演示文稿文件的 Presentation 类。
$presentation = new Presentation();
try {
    // 在此处执行一些工作...

    // 将演示文稿保存到文件。
    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


## **将演示文稿保存到流**

您可以通过向 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的 `save` 方法传递输出流来将演示文稿保存到流。演示文稿可以写入多种流类型。在下面的示例中，我们创建一个新的演示文稿并将其保存到文件流。
```php
// 实例化表示演示文稿文件的 Presentation 类。
$presentation = new Presentation();
try {
    $fileStream = new Java("java.io.FileOutputStream", "Output.pptx");
    try {
        // 将演示文稿保存到流。
        $presentation->save($fileStream, SaveFormat::Pptx);
    } finally {
        $fileStream->close();
    }
} finally {
    $presentation->dispose();
}
```


## **使用预定义视图类型保存演示文稿**

Aspose.Slides 允许您通过 [ViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/) 类设置 PowerPoint 打开生成的演示文稿时的初始视图。使用 [setLastView](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/#setLastView) 方法并提供来自 [ViewType](https://reference.aspose.com/slides/php-java/aspose.slides/viewtype/) 枚举的值。
```php
$presentation = new Presentation();
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("SlideMasterView.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


## **以 Strict Office Open XML 格式保存演示文稿**

Aspose.Slides 允许您以 Strict Office Open XML 格式保存演示文稿。使用 [PptxOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pptxoptions/) 类并在保存时设置其 conformance 属性。如果将 [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/php-java/aspose.slides/conformance/#Iso29500_2008_Strict) 设置为该值，则输出文件以 Strict Office Open XML 格式保存。

下面的示例创建一个演示文稿并以 Strict Office Open XML 格式保存它。
```php
$options = new PptxOptions();
$options->setConformance(Conformance::Iso29500_2008_Strict);

// 实例化表示演示文稿文件的 Presentation 类。
$presentation = new Presentation();
try {
    // 将演示文稿以 Strict Office Open XML 格式保存。
    $presentation->save("StrictOfficeOpenXml.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```


## **在 Zip64 模式下以 Office Open XML 格式保存演示文稿**

Office Open XML 文件是一个 ZIP 存档，对未压缩文件大小、压缩后文件大小以及存档总大小都有 4 GB (2^32 字节) 的限制，并且限制存档最多 65,535 (2^16-1) 个文件。ZIP64 格式扩展将这些限制提升至 2^64。

[PptxOptions.setZip64Mode](https://reference.aspose.com/slides/php-java/aspose.slides/pptxoptions/#setZip64Mode) 方法允许您在保存 Office Open XML 文件时选择何时使用 ZIP64 格式扩展。

此方法可与以下模式一起使用：

- [IfNecessary](https://reference.aspose.com/slides/php-java/aspose.slides/zip64mode/#IfNecessary) 仅在演示文稿超过上述限制时使用 ZIP64 格式扩展。这是默认模式。
- [Never](https://reference.aspose.com/slides/php-java/aspose.slides/zip64mode/#Never) 从不使用 ZIP64 格式扩展。
- [Always](https://reference.aspose.com/slides/php-java/aspose.slides/zip64mode/#Always) 始终使用 ZIP64 格式扩展。

以下代码演示如何在启用 ZIP64 格式扩展的情况下将演示文稿保存为 PPTX：
```php
$pptxOptions = new PptxOptions();
$pptxOptions->setZip64Mode(Zip64Mode::Always);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("OutputZip64.pptx", SaveFormat::Pptx, $pptxOptions);
} finally {
    $presentation->dispose();
}
```


{{% alert title="NOTE" color="warning" %}}
如果使用 [Zip64Mode.Never](https://reference.aspose.com/slides/php-java/aspose.slides/zip64mode/#Never) 保存，当演示文稿无法以 ZIP32 格式保存时，会抛出 [PptxException](https://reference.aspose.com/slides/php-java/aspose.slides/pptxexception/)。
{{% /alert %}}

## **保存演示文稿时不刷新缩略图**

[PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/php-java/aspose.slides/pptxoptions/#setRefreshThumbnail) 方法控制保存演示文稿为 PPTX 时的缩略图生成：

- 如果设置为 `true`，在保存期间刷新缩略图。这是默认值。
- 如果设置为 `false`，保留当前缩略图。如果演示文稿没有缩略图，则不会生成。

在下面的代码中，演示文稿保存为 PPTX 时不刷新其缩略图。
```php
$pptxOptions = new PptxOptions();
$pptxOptions->setRefreshThumbnail(false);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Output.pptx", SaveFormat::Pptx, $pptxOptions);
}
finally {
    $presentation->dispose();
}
```


{{% alert title="Info" color="info" %}}
此选项有助于缩短以 PPTX 格式保存演示文稿所需的时间。
{{% /alert %}}

## **以百分比形式保存进度更新**

保存进度报告通过在 [SaveOptions](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/) 及其子类上使用 [setProgressCallback](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setProgressCallback) 方法进行配置。提供实现了 [IProgressCallback](https://reference.aspose.com/slides/java/com.aspose.slides/iprogresscallback/) 接口的 Java 代理；在导出期间，回调会定期收到百分比更新。

以下代码片段展示如何使用 `IProgressCallback`。
```php
class ExportProgressHandler {
    function reporting($progressValue) {
        // 在此处使用进度百分比值。
        $progress = java("java.lang.Double")->valueOf($progressValue)->intValue();
        echo($progress . "% of the file has been converted.");
    }
}

$progressHandler = java_closure(new ExportProgressHandler(), null, java("com.aspose.slides.IProgressCallback"));

$saveOptions = new PdfOptions();
$saveOptions->setProgressCallback($progressHandler);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Output.pdf", SaveFormat::Pdf, $saveOptions);
} finally {
    $presentation->dispose();
}
```


{{% alert title="Info" color="info" %}}
Aspose 使用其自身 API 开发了一个 [免费 PowerPoint 拆分器应用](https://products.aspose.app/slides/splitter)。该应用可通过将选定的幻灯片保存为新的 PPTX 或 PPT 文件，将演示文稿拆分为多个文件。
{{% /alert %}}

## **常见问题**

**是否支持 “快速保存”（增量保存），仅写入更改的内容？**

否。每次保存都会生成完整的目标文件，不支持增量的“快速保存”。

**从多个线程保存同一个 Presentation 实例是否线程安全？**

否。[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 实例[不是线程安全的](/slides/zh/php-java/multithreading/)；请在单个线程中进行保存。

**保存时超链接和外部链接的文件会怎样？**

[超链接](/slides/zh/php-java/manage-hyperlinks/) 会被保留。外部链接的文件（例如通过相对路径引用的视频）不会自动复制——请确保引用的路径仍然可访问。

**我可以设置/保存文档元数据（作者、标题、公司、日期）吗？**

可以。标准[文档属性](/slides/zh/php-java/presentation-properties/) 被支持，并会在保存时写入文件。