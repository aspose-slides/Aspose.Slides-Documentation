---
title: 在 PHP 中保存演示文稿
linktitle: 保存演示文稿
type: docs
weight: 80
url: /zh/php-java/save-presentation/
keywords:
- 保存 PowerPoint
- 保存 OpenDocument
- 保存 演示文稿
- 保存 幻灯片
- 保存 PPT
- 保存 PPTX
- 保存 ODP
- 演示文稿 到 文件
- 演示文稿 到 流
- 预定义 视图 类型
- 严格的 Office Open XML 格式
- Zip64 模式
- 刷新 缩略图
- 保存 进度
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides 在 PHP 中将 PowerPoint 和 OpenDocument 演示文稿保存为文件或流，并配置 PPTX 输出和进度报告。"
---
## **概述**

创建演示文稿或[打开现有演示文稿](/slides/zh/php-java/open-presentation/)后，使用[Presentation::save](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/#save)方法写入结果。Aspose.Slides for PHP via Java 可以将演示文稿保存为文件或流，支持 PowerPoint、OpenDocument、PDF 等格式。以下各节介绍标准保存操作以及 PPTX 输出的可用选项。

## **将演示文稿保存到文件**

要将演示文稿保存为文件，请将输出路径和一个[SaveFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/saveformat/)值传递给[Presentation::save](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/#save)方法。该格式值决定 Aspose.Slides 创建的文件类型。

以下示例创建一个演示文稿并将其保存为 PPTX 文件：

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    // 在此添加或修改演示文稿内容。

    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **以原始格式保存演示文稿**

有关文件和流检测示例、新创建的演示文稿行为以及源格式和输出格式之间的区别，请参阅[确定原始演示文稿格式](/slides/zh/php-java/detect-presentation-source-format/)。

在批处理应用程序中，输入格式可能事先未知。加载文件后，可通过[Presentation::getSourceFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/#getSourceFormat)方法读取其原始格式。将得到的[SourceFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/sourceformat/)值传递给[SlideUtil::toSaveFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slideutil/#toSaveFormat)以获取相应的[SaveFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/saveformat/)值，然后使用[Presentation::save](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/#save)写入修改后的演示文稿。

以下完整示例处理输入目录中的每个文件，更新其标题，并以加载时的格式保存到输出目录：

```php
use aspose\slides\Presentation;
use aspose\slides\SlideUtil;

$inputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "Input";
$outputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "Output";

if (!is_dir($outputDirectory) && !mkdir($outputDirectory, 0777, true)) {
    echo("Cannot create the output directory." . PHP_EOL);
}

$inputFiles = is_dir($inputDirectory) ? scandir($inputDirectory) : false;
if ($inputFiles !== false && is_dir($outputDirectory)) {
    foreach ($inputFiles as $fileName) {
        $inputPath = $inputDirectory . DIRECTORY_SEPARATOR . $fileName;
        if (!is_file($inputPath)) {
            continue;
        }

        $presentation = null;
        $presentationLoaded = false;
        try {
            $presentation = new Presentation($inputPath);
            $presentationLoaded = true;
            $saveFormat = SlideUtil::toSaveFormat($presentation->getSourceFormat());
            $presentation->getDocumentProperties()->setTitle("Processed by the batch application");

            $outputPath = $outputDirectory . DIRECTORY_SEPARATOR . $fileName;
            $presentation->save($outputPath, $saveFormat);
        } catch (\Throwable $exception) {
            echo("Cannot process '" . $inputPath . "': " . $exception->getMessage() . PHP_EOL);
        } finally {
            if ($presentationLoaded) {
                $presentation->dispose();
            }
        }
    }
}
```

[SlideUtil::toSaveFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slideutil/#toSaveFormat) 将 PPT、PPTX、ODP、PPTM、PPSX、PPSM、POTX、POTM、PPS、POT、OTP、FODP 和 PowerPoint XML 映射到相应的演示文稿保存格式。它仅映射演示文稿源格式；并非用于选择如 PDF、HTML、TIFF 或图像等导出格式。传入不受支持或无效的[SourceFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/sourceformat/)值会导致[IllegalArgumentException](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/lang/IllegalArgumentException.html)。

传统的 PPT、PPS 和 POT 文件使用相同的二进制容器。从流中加载此类演示文稿且没有文件扩展名时，PPS 或 POT 文件可能会被识别为 PPT。如果需要保留这些传统子类型，请单独保留原始文件名或格式元数据，并在选择输出文件名和格式时使用它们。

## **将演示文稿保存到流**

要在不依赖最终文件路径的情况下写入演示文稿，请将可写流和一个[SaveFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/saveformat/)值传递给[Presentation::save](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/#save)方法。当输出需要从 Web 服务返回、存储到数据库或在内存中处理时，此方法非常有用。

以下示例将新演示文稿保存到文件流：

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $outputStream = new Java("java.io.FileOutputStream", "Output.pptx");
    try {
        $presentation->save($outputStream, SaveFormat::Pptx);
    } finally {
        $outputStream->close();
    }
} finally {
    $presentation->dispose();
}
```

## **使用预定义视图类型保存演示文稿**

您可以指定 PowerPoint 打开已保存演示文稿时的初始视图。在保存之前，使用带有[ViewType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/viewtype/)值的[ViewProperties::setLastView](https://reference.aspose.com/slides/zh/php-java/aspose.slides/viewproperties/#setLastView)方法。

以下示例将幻灯片母版视图配置为初始视图：

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ViewType;

$presentation = new Presentation();
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("SlideMasterView.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **以严格的 Office Open XML 格式保存演示文稿**

要创建符合 Office Open XML 严格配置文件的 PPTX 文件，请实例化一个[PptxOptions](https://reference.aspose.com/slides/zh/php-java/aspose.slides/pptxoptions/)对象，并使用其[PptxOptions::setConformance](https://reference.aspose.com/slides/zh/php-java/aspose.slides/pptxoptions/#setConformance)方法，传入[Conformance::Iso29500_2008_Strict](https://reference.aspose.com/slides/zh/php-java/aspose.slides/conformance/#Iso29500-2008-Strict)。随后将该选项传递给[Presentation::save](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/#save)方法。

```php
use aspose\slides\Conformance;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$options = new PptxOptions();
$options->setConformance(Conformance::Iso29500_2008_Strict);

$presentation = new Presentation();
try {
    $presentation->save("StrictOfficeOpenXml.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

## **在 Zip64 模式下以 Office Open XML 格式保存演示文稿**

标准 ZIP 存档限制每个条目的压缩和未压缩大小、整个存档的总大小以及条目数量。由于 PPTX 文件是 ZIP 存档，极大的演示文稿可能会超出这些限制。ZIP64 扩展提升了相应的大小和条目计数限制。

使用[PptxOptions::setZip64Mode](https://reference.aspose.com/slides/zh/php-java/aspose.slides/pptxoptions/#setZip64Mode)方法来控制 Aspose.Slides 是否写入 ZIP64 扩展：

- [IfNecessary](https://reference.aspose.com/slides/zh/php-java/aspose.slides/zip64mode/#IfNecessary) 仅在演示文稿超出标准 ZIP 限制时使用 ZIP64。这是默认模式。
- [Never](https://reference.aspose.com/slides/zh/php-java/aspose.slides/zip64mode/#Never) 禁用 ZIP64 扩展。
- [Always](https://reference.aspose.com/slides/zh/php-java/aspose.slides/zip64mode/#Always) 始终写入 ZIP64 扩展。

以下示例始终为输出演示文稿启用 ZIP64 扩展：

```php
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\Zip64Mode;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setZip64Mode(Zip64Mode::Always);

    $presentation->save("OutputZip64.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

{{% alert color="warning" title="Warning" %}}
如果使用[Zip64Mode::Never](https://reference.aspose.com/slides/zh/php-java/aspose.slides/zip64mode/#Never)且演示文稿无法在标准 ZIP 限制内容纳，则保存操作会抛出 [PptxException](https://reference.aspose.com/slides/zh/php-java/aspose.slides/pptxexception/)。
{{% /alert %}}

## **在 Office Open XML 格式中使用压缩级别保存演示文稿**

对于 PPTX 输出，您可以通过使用[PptxOptions::setCompressionLevel](https://reference.aspose.com/slides/zh/php-java/aspose.slides/pptxoptions/#setCompressionLevel)方法在保存速度与文件大小之间取得平衡。[CompressionLevel](https://reference.aspose.com/slides/zh/php-java/aspose.slides/compressionlevel/)类提供了以下取值：

- [None](https://reference.aspose.com/slides/zh/php-java/aspose.slides/compressionlevel/#None) 不进行压缩地存储数据。
- [Level1](https://reference.aspose.com/slides/zh/php-java/aspose.slides/compressionlevel/#Level1) 提供最快的压缩速度，但压缩后文件最大。
- [Level2](https://reference.aspose.com/slides/zh/php-java/aspose.slides/compressionlevel/#Level2) 到 [Level5](https://reference.aspose.com/slides/zh/php-java/aspose.slides/compressionlevel/#Level5) 逐步倾向于更小的输出而牺牲保存速度。
- [Level6](https://reference.aspose.com/slides/zh/php-java/aspose.slides/compressionlevel/#Level6) 在保存速度和文件大小之间取得平衡。这是默认级别。
- [Level7](https://reference.aspose.com/slides/zh/php-java/aspose.slides/compressionlevel/#Level7) 和 [Level8](https://reference.aspose.com/slides/zh/php-java/aspose.slides/compressionlevel/#Level8) 更进一步倾向于更小的输出而牺牲保存速度。
- [Level9](https://reference.aspose.com/slides/zh/php-java/aspose.slides/compressionlevel/#Level9) 提供最强的压缩率，但需要最长的处理时间。

以下示例在不进行压缩的情况下保存演示文稿：

```php
use aspose\slides\CompressionLevel;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setCompressionLevel(CompressionLevel::None);

    $presentation->save("OutputNoCompression.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

以下示例使用最高压缩级别：

```php
use aspose\slides\CompressionLevel;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setCompressionLevel(CompressionLevel::Level9);

    $presentation->save("OutputMaximumCompression.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

## **保存演示文稿时不刷新缩略图**

在将演示文稿保存为 PPTX 时，[PptxOptions::setRefreshThumbnail](https://reference.aspose.com/slides/zh/php-java/aspose.slides/pptxoptions/#setRefreshThumbnail) 方法控制文档缩略图：

- `true` 在保存过程中重新生成缩略图。这是默认值。
- `false` 保留现有缩略图。如果演示文稿没有缩略图，Aspose.Slides 不会生成。

以下示例在保存时不刷新其缩略图：

```php
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setRefreshThumbnail(false);

    $presentation->save("Output.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
禁用缩略图刷新可以减少保存 PPTX 文件所需的时间。
{{% /alert %}}

## **以百分比方式保存进度更新**

要监视保存操作，请提供一个实现了[IProgressCallback](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iprogresscallback/)接口的 Java 代理，并将该代理传递给[SaveOptions::setProgressCallback](https://reference.aspose.com/slides/zh/php-java/aspose.slides/saveoptions/#setProgressCallback)方法。Aspose.Slides 随后在导出期间调用[IProgressCallback::reporting](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iprogresscallback/#reporting-double-)方法并传入进度值。

以下示例将 PDF 导出的进度报告到控制台：

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

class ExportProgressHandler {
    function reporting($progressValue) {
        $progress = java("java.lang.Double")->valueOf($progressValue)->intValue();
        echo($progress . "% of the file has been converted." . PHP_EOL);
    }
}

$progressHandler = java_closure(new ExportProgressHandler(), null, java("com.aspose.slides.IProgressCallback"));

$options = new PdfOptions();
$options->setProgressCallback($progressHandler);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Output.pdf", SaveFormat::Pdf, $options);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose 提供了一个基于 Aspose.Slides API 的免费[PowerPoint Splitter](https://products.aspose.app/slides/zh/splitter)。它可将演示文稿中选定的幻灯片另存为独立的 PPT 或 PPTX 文件。
{{% /alert %}}

## **常见问题**

**Aspose.Slides 是否支持增量或“快速保存”？**

不。每次保存操作都会写入完整的输出文件，而不是仅更新已更改的部分。

**多个线程能保存同一个 Presentation 实例吗？**

不。[Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 实例[不是线程安全的](/slides/zh/php-java/multithreading/)。每次只能在单个线程中访问并保存该实例。

**保存演示文稿时，超链接和外部链接文件会怎样？**

[Hyperlinks](/slides/zh/php-java/manage-hyperlinks/) 会保留在演示文稿中。Aspose.Slides 不会复制外部链接的文件，因此保存后的演示文稿仍需能够访问这些位置。

**我可以保存文档元数据（如作者、标题、公司和创建日期）吗？**

可以。在保存之前设置相应的[文档属性](/slides/zh/php-java/presentation-properties/)，Aspose.Slides 会将其写入输出文件。