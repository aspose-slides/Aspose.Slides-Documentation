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
- 将演示文稿保存为文件
- 将演示文稿保存为流
- 预定义视图类型
- 严格的 Office Open XML 格式
- Zip64 模式
- 刷新缩略图
- 保存进度
- PHP
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for PHP via Java 将演示文稿保存——导出为 PowerPoint 或 OpenDocument，同时保留布局、字体和效果。"
---
## **概述**

[Open Presentations in PHP](/slides/zh/php-java/open-presentation/) 介绍了如何使用 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 类打开演示文稿。本文说明了如何创建和保存演示文稿。[Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 类包含演示文稿的内容。无论是从头创建演示文稿还是修改已有的，都需要在完成后保存。使用 Aspose.Slides for PHP，您可以保存为 **文件** 或 **流**。本文解释了保存演示文稿的不同方式。

## **将演示文稿保存为文件**

通过调用 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 类的 `save` 方法将演示文稿保存到文件。将文件名和保存格式作为参数传递给该方法。以下示例演示了如何使用 Aspose.Slides 保存演示文稿。

```php
// 实例化表示演示文稿文件的 Presentation 类。
$presentation = new Presentation();
try {
    // 在此进行一些工作...
    // 将演示文稿保存为文件。
    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **将演示文稿保存到流**

您可以通过将输出流传递给 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 类的 `save` 方法，将演示文稿保存到流。演示文稿可以写入多种流类型。下面的示例中，我们创建一个新演示文稿并将其保存到文件流。

```php
// 实例化表示演示文稿文件的 Presentation 类。
$presentation = new Presentation();
try {
    $fileStream = new Java("java.io.FileOutputStream", "Output.pptx");
    try {
        // 将演示文稿保存到流中。
        $presentation->save($fileStream, SaveFormat::Pptx);
    } finally {
        $fileStream->close();
    }
} finally {
    $presentation->dispose();
}
```

## **使用预定义视图类型保存演示文稿**

Aspose.Slides 允许您通过 [ViewProperties](https://reference.aspose.com/slides/zh/php-java/aspose.slides/viewproperties/) 类设置生成的演示文稿打开时 PowerPoint 使用的初始视图。使用 [setLastView](https://reference.aspose.com/slides/zh/php-java/aspose.slides/viewproperties/#setLastView) 方法，并传入来自 [ViewType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/viewtype/) 枚举的值。

```php
$presentation = new Presentation();
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("SlideMasterView.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **以严格的 Office Open XML 格式保存演示文稿**

Aspose.Slides 允许您以严格的 Office Open XML 格式保存演示文稿。保存时使用 [PptxOptions](https://reference.aspose.com/slides/zh/php-java/aspose.slides/pptxoptions/) 类并设置其 conformance 属性。如果将其设为 [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/zh/php-java/aspose.slides/conformance/#Iso29500_2008_Strict)，输出文件将以严格的 Office Open XML 格式保存。

下面的示例创建一个演示文稿并以严格的 Office Open XML 格式保存。

```php
$options = new PptxOptions();
$options->setConformance(Conformance::Iso29500_2008_Strict);

// 实例化表示演示文稿文件的 Presentation 类。
$presentation = new Presentation();
try {
    // 以严格的 Office Open XML 格式保存演示文稿。
    $presentation->save("StrictOfficeOpenXml.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

## **在 Zip64 模式下以 Office Open XML 格式保存演示文稿**

Office Open XML 文件是 ZIP 存档，对任何文件的未压缩大小、压缩后大小以及整个存档的总大小均限制为 4 GB（2^32 字节），并且存档中文件数量限制为 65 535（2^16‑1）个。ZIP64 格式扩展将这些限制提升至 2^64。

[PptxOptions.setZip64Mode](https://reference.aspose.com/slides/zh/php-java/aspose.slides/pptxoptions/#setZip64Mode) 方法让您在保存 Office Open XML 文件时选择是否使用 ZIP64 格式扩展。

此方法可与以下模式一起使用：

- [IfNecessary](https://reference.aspose.com/slides/zh/php-java/aspose.slides/zip64mode/#IfNecessary) 仅在演示文稿超出上述限制时使用 ZIP64 格式扩展。这是默认模式。
- [Never](https://reference.aspose.com/slides/zh/php-java/aspose.slides/zip64mode/#Never) 永不使用 ZIP64 格式扩展。
- [Always](https://reference.aspose.com/slides/zh/php-java/aspose.slides/zip64mode/#Always) 始终使用 ZIP64 格式扩展。

以下代码演示如何在启用 ZIP64 格式扩展的情况下将演示文稿保存为 PPTX 文件：

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
当您使用 [Zip64Mode.Never](https://reference.aspose.com/slides/zh/php-java/aspose.slides/zip64mode/#Never) 保存时，如果演示文稿无法以 ZIP32 格式保存，会抛出 [PptxException](https://reference.aspose.com/slides/zh/php-java/aspose.slides/pptxexception/)。
{{% /alert %}}

## **使用压缩级别在 Office Open XML 格式下保存演示文稿**

处理大型演示文稿时，您可以调整压缩级别，以在文件大小和处理时间之间取得平衡。根据需求，您可能更倾向于更快的处理速度或更小的输出文件。

Aspose.Slides 提供了 [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/zh/php-java/aspose.slides/pptxoptions/#setCompressionLevel) 方法，允许您指定在 Office Open XML 格式下保存演示文稿时使用的压缩级别。

可用的压缩级别如下：

- [**None**](https://reference.aspose.com/slides/zh/php-java/aspose.slides/compressionlevel/#None)：不进行压缩。文件保持原样存储。
- [**Level1**](https://reference.aspose.com/slides/zh/php-java/aspose.slides/compressionlevel/#Level1)：最快的压缩速度，压缩率最低。
- [**Level2**](https://reference.aspose.com/slides/zh/php-java/aspose.slides/compressionlevel/#Level2)：比 **Level1** 稍好一些的压缩率，压缩速度较快。
- [**Level3**](https://reference.aspose.com/slides/zh/php-java/aspose.slides/compressionlevel/#Level3)：提供比 **Level2** 更好的压缩，处理时间适中。
- [**Level4**](https://reference.aspose.com/slides/zh/php-java/aspose.slides/compressionlevel/#Level4)：提供比 **Level3** 更好的压缩。
- [**Level5**](https://reference.aspose.com/slides/zh/php-java/aspose.slides/compressionlevel/#Level5)：在 **Level4** 基础上改进压缩，但需要额外的处理时间。
- [**Level6**](https://reference.aspose.com/slides/zh/php-java/aspose.slides/compressionlevel/#Level6)：标准压缩，兼顾处理速度和文件大小。这是 *默认压缩级别*。
- [**Level7**](https://reference.aspose.com/slides/zh/php-java/aspose.slides/compressionlevel/#Level7)：提供比 **Level6** 更好的压缩，但处理更慢。
- [**Level8**](https://reference.aspose.com/slides/zh/php-java/aspose.slides/compressionlevel/#Level8)：提供比 **Level7** 更好的压缩。
- [**Level9**](https://reference.aspose.com/slides/zh/php-java/aspose.slides/compressionlevel/#Level9)：最高压缩。以最长的处理时间生成最小的文件大小。

以下示例演示如何在 *不进行压缩* 的情况下将演示文稿保存为 PPTX 文件：

```php
$pptxOptions = new PptxOptions();
$pptxOptions->setCompressionLevel(CompressionLevel::None);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Sample-out.pptx", SaveFormat::Pptx, $pptxOptions);
} finally {
    $presentation->dispose();
}
```

此示例展示如何在 *最大压缩* 的情况下将演示文稿保存为 PPTX 文件：

```php
$pptxOptions = new PptxOptions();
$pptxOptions->setCompressionLevel(CompressionLevel::Level9);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Sample-level9.pptx", SaveFormat::Pptx, $pptxOptions);
} finally {
    $presentation->dispose();
}
```

## **保存演示文稿时不刷新缩略图**

[PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/zh/php-java/aspose.slides/pptxoptions/#setRefreshThumbnail) 方法控制保存演示文稿为 PPTX 时的缩略图生成行为：

- 如果设置为 `true`，保存时会刷新缩略图。这是默认值。
- 如果设置为 `false`，保留当前缩略图。如果演示文稿没有缩略图，则不生成。

下面的代码将演示文稿保存为 PPTX，但不刷新其缩略图。

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
此选项有助于减少以 PPTX 格式保存演示文稿所需的时间。
{{% /alert %}}

## **以百分比形式保存进度更新**

通过在 [SaveOptions](https://reference.aspose.com/slides/zh/php-java/aspose.slides/saveoptions/) 及其子类上使用 [setProgressCallback](https://reference.aspose.com/slides/zh/php-java/aspose.slides/saveoptions/#setProgressCallback) 方法来配置保存进度报告。提供实现了 [IProgressCallback](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iprogresscallback/) 接口的 Java 代理；在导出期间，回调会定期接收百分比更新。

以下代码片段展示了如何使用 `IProgressCallback`。

```php
class ExportProgressHandler {
    function reporting($progressValue) {
        // 在此使用进度百分比值。
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
Aspose 使用其 API 开发了一个 [免费 PowerPoint Splitter 应用](https://products.aspose.app/slides/zh/splitter)。该应用可通过将选定的幻灯片保存为新的 PPTX 或 PPT 文件，将演示文稿拆分为多个文件。
{{% /alert %}}

## **常见问题**

**是否支持“快速保存”（增量保存），仅写入更改？**

不支持。每次保存都会创建完整的目标文件，未提供增量“快速保存”。

**从多个线程保存同一个 Presentation 实例是否线程安全？**

不安全。`[Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/)` 实例 **不是线程安全的**，请在单个线程中进行保存。

**保存时超链接和外部链接文件会怎样？**

[超链接](/slides/zh/php-java/manage-hyperlinks/) 会被保留。外部链接文件（例如通过相对路径引用的视频）不会自动复制——请确保引用的路径在保存后仍然可访问。

**我可以设置/保存文档元数据（作者、标题、公司、日期）吗？**

可以。标准的 [文档属性](/slides/zh/php-java/presentation-properties/) 受支持，保存时会写入文件。