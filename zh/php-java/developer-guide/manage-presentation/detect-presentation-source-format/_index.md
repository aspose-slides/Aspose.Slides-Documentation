---
title: 在 PHP 中确定原始演示文稿格式
linktitle: 源格式
type: docs
weight: 35
url: /zh/php-java/detect-presentation-source-format/
keywords:
- 原始格式
- 检测演示文稿格式
- PowerPoint
- OpenDocument
- 演示文稿
- PPT
- PPTX
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 在 PHP 中读取已加载演示文稿的原始格式，比较检测 API，并处理文件、流和旧版格式。"
---
## **概览**

在加载演示文稿后，调用 [Presentation::getSourceFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/#getSourceFormat) 方法以确定其原始格式。当后续处理依赖于当前实例加载时的格式时，请使用它。

源格式不同于为输出文件选择的 [SaveFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/saveformat/)。将文件另存为其他格式不会更改现有实例的源格式。

## **读取文件的源格式**

此示例需要一个已有的 `sample.pptx` 文件。它加载该文件并使用 [Presentation::getSourceFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/#getSourceFormat) 来选择应用程序的处理策略，而不是使用文件名。更改输入路径以尝试其他格式。示例会打印所选策略；请用您的应用逻辑替换这些消息。

```php
use aspose\slides\Presentation;
use aspose\slides\SourceFormat;

$presentation = new Presentation("sample.pptx");
try {
    switch (java_values($presentation->getSourceFormat())) {
        case SourceFormat::Ppt:
        case SourceFormat::Pps:
        case SourceFormat::Pot:
            echo "Use the legacy PowerPoint processing policy." . PHP_EOL;
            break;
        case SourceFormat::Pptx:
            echo "Use the standard PPTX processing policy." . PHP_EOL;
            break;
        default:
            echo "Use the general policy for source format " . java_values($presentation->getSourceFormat()) . "." . PHP_EOL;
            break;
    }
} finally {
    $presentation->dispose();
}
```

## **识别受支持的值**

[SourceFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/sourceformat/) 类定义了区分以下演示文稿格式的整数常量。下表中的扩展名为常规扩展名，而非原始文件名的重建。

| SourceFormat 值 | 扩展名 | 格式 |
| --- | --- | --- |
| `Ppt` | `.ppt` | PowerPoint 97–2003 演示文稿 |
| `Pptx` | `.pptx` | Office Open XML 演示文稿 |
| `Pptm` | `.pptm` | 支持宏的 Office Open XML 演示文稿 |
| `Pps` | `.pps` | PowerPoint 97–2003 幻灯片放映 |
| `Ppsx` | `.ppsx` | Office Open XML 幻灯片放映 |
| `Ppsm` | `.ppsm` | 支持宏的 Office Open XML 幻灯片放映 |
| `Pot` | `.pot` | PowerPoint 97–2003 模板 |
| `Potx` | `.potx` | Office Open XML 模板 |
| `Potm` | `.potm` | 支持宏的 Office Open XML 模板 |
| `Odp` | `.odp` | OpenDocument 演示文稿 |
| `Otp` | `.otp` | OpenDocument 演示文稿模板 |
| `Fodp` | `.fodp` | Flat XML ODF 演示文稿 |
| `Xml` | `.xml` | PowerPoint XML 演示文稿 |

## **读取流的源格式**

此示例需要一个已有的 `sample.pps` 文件。将其字节读取到内存流中，以模拟没有文件名的输入，例如数据库值或上传的字节数组。[Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 构造函数仅接受该流。

```php
use aspose\slides\Presentation;

$inputFile = new Java("java.io.File", "sample.pps");
$bytes = java("java.nio.file.Files")->readAllBytes($inputFile->toPath());
$stream = new Java("java.io.ByteArrayInputStream", $bytes);
try {
    $presentation = new Presentation($stream);
    try {
        echo "Source format: " . java_values($presentation->getSourceFormat()) . PHP_EOL;
    } finally {
        $presentation->dispose();
    }
} finally {
    $stream->close();
}
```

PPT、PPS 和 POT 使用相同的底层二进制格式。通过文件路径加载时，扩展名可以帮助区分幻灯片放映或模板。没有文件名时，旧版 PPS 和 POT 内容可能被报告为 `SourceFormat::Ppt`；上述 PPS 示例会打印 `SourceFormat::Ppt` 的整数值。

如果您的应用程序必须保留此区分，请单独保存原始文件名或子类型元数据。扩展名对这些旧版子类型是有用的提示，但不应作为识别任意演示文稿内容的唯一依据。

## **比较加载前后的检测**

在需要在加载完整演示文稿对象模型之前检查文件时，请使用 [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentationfactory/#getPresentationInfo) 和 [PresentationInfo::getLoadFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentationinfo/#getLoadFormat)。当实例已经存在时，请使用 [Presentation::getSourceFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/#getSourceFormat)。

此示例需要 `sample.pptx`，分别打印 `LoadFormat::Pptx` 和 `SourceFormat::Pptx` 的整数值。在生产环境中，请根据处理阶段选择合适的 API；已加载的演示文稿无需再次检查仅获取其源格式。

```php
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;

$path = "sample.pptx";
$information = PresentationFactory::getInstance()->getPresentationInfo($path);
echo "Before loading: " . java_values($information->getLoadFormat()) . PHP_EOL;

$presentation = new Presentation($path);
try {
    echo "After loading: " . java_values($presentation->getSourceFormat()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

结果使用了来自不同类的常量：[LoadFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/loadformat/) 和 [SourceFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/sourceformat/)。不要比较它们的数值，也不要假设每种格式的检测结果相同。PowerPoint XML 在加载前可能报告为 `LoadFormat::Unknown`，加载后则为 `SourceFormat::Xml`。

## **保持源格式和输出格式分离**

此示例需要 `sample.pptx` 并写入 `converted.odp`。它在保存原始实例前后都会打印 `SourceFormat::Pptx` 的整数值。只有从 ODP 输出加载的新实例会报告 `Odp`。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    echo "Before saving: " . java_values($presentation->getSourceFormat()) . PHP_EOL;

    $presentation->save("converted.odp", SaveFormat::Odp);
    echo "After saving: " . java_values($presentation->getSourceFormat()) . PHP_EOL;

    $reopened = new Presentation("converted.odp");
    try {
        echo "Reopened output: " . java_values($reopened->getSourceFormat()) . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

使用 `new Presentation()` 从头创建的演示文稿报告 `SourceFormat::Pptx`。它没有输入文件：这是新创建实例的默认值，并不表示加载了 PPTX 文件。如果该区分重要，请在应用程序中单独跟踪是创建还是加载了实例。

## **将源格式映射到扩展名**

以下示例需要 `sample.pptx`。它将每个当前受支持的 [SourceFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/sourceformat/) 值映射到常规扩展名，而不解析输入文件名。回退机制避免对未识别的值悄悄分配扩展名。

```php
use aspose\slides\Presentation;
use aspose\slides\SourceFormat;

$presentation = new Presentation("sample.pptx");
try {
    $extension = null;
    switch (java_values($presentation->getSourceFormat())) {
        case SourceFormat::Ppt:
            $extension = ".ppt";
            break;
        case SourceFormat::Pptx:
            $extension = ".pptx";
            break;
        case SourceFormat::Pptm:
            $extension = ".pptm";
            break;
        case SourceFormat::Pps:
            $extension = ".pps";
            break;
        case SourceFormat::Ppsx:
            $extension = ".ppsx";
            break;
        case SourceFormat::Ppsm:
            $extension = ".ppsm";
            break;
        case SourceFormat::Pot:
            $extension = ".pot";
            break;
        case SourceFormat::Potx:
            $extension = ".potx";
            break;
        case SourceFormat::Potm:
            $extension = ".potm";
            break;
        case SourceFormat::Odp:
            $extension = ".odp";
            break;
        case SourceFormat::Otp:
            $extension = ".otp";
            break;
        case SourceFormat::Fodp:
            $extension = ".fodp";
            break;
        case SourceFormat::Xml:
            $extension = ".xml";
            break;
        default:
            $extension = null;
            break;
    }

    echo ($extension !== null ? $extension : "No extension mapping is available.") . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

此映射不会转换文件或恢复在流加载期间丢失的旧版 PPS/POT 子类型。实际保存时，请显式选择 [SaveFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/saveformat/)，或使用在 [以原始格式保存演示文稿](/slides/zh/php-java/save-presentation/#save-presentations-in-their-original-format) 中展示的转换。

## **通过保存和重新打开验证格式**

此独立示例创建一个演示文稿并在工作目录中写入三个文件，若同名文件会被覆盖。它分别通过路径和内存流重新打开每个输出。对于 PPTX 和 ODP，两种方式均报告保存的格式。对于 PPS，通过路径加载报告 `Pps`，而在没有文件名的情况下加载相同字节则报告 `Ppt`。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $formats = [SaveFormat::Pptx, SaveFormat::Odp, SaveFormat::Pps];
    $extensions = ["pptx", "odp", "pps"];

    foreach ($formats as $index => $format) {
        $path = "roundtrip." . $extensions[$index];
        $presentation->save($path, $format);

        $fromFile = new Presentation($path);
        try {
            $inputFile = new Java("java.io.File", $path);
            $bytes = java("java.nio.file.Files")->readAllBytes($inputFile->toPath());
            $stream = new Java("java.io.ByteArrayInputStream", $bytes);
            try {
                $fromStream = new Presentation($stream);
                try {
                    echo $extensions[$index] . ": file=" . java_values($fromFile->getSourceFormat()) . ", stream=" . java_values($fromStream->getSourceFormat()) . PHP_EOL;
                } finally {
                    $fromStream->dispose();
                }
            } finally {
                $stream->close();
            }
        } finally {
            $fromFile->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

下表汇总了具有匹配扩展名的演示文稿的源格式识别。名称表示常量，PHP 示例会打印它们的整数值：

| 保存的格式 | 文件路径的 SourceFormat | 无名流的 SourceFormat |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` 分别 | 与文件路径相同 |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` 分别 | 与文件路径相同 |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` 分别 | 与文件路径相同 |
| ODP, OTP | `Odp`, `Otp` 分别 | 与文件路径相同 |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

PPS/POT 内容在无名流中被识别为 `Ppt`。此表描述的是格式识别，而非转换过程中保留每个演示文稿特性的情况。

## **常见问题**

**将 PPTX 加载的演示文稿保存为 ODP 会改变其源格式吗？**

不会。原有实例仍报告 `Pptx`。从保存的 ODP 文件加载的实例则报告 `Odp`。

**流能否始终区分旧版演示文稿、幻灯片放映和模板？**

不能。PPT、PPS 和 POT 共享同一二进制格式。需要区分时请单独保存文件名或子类型元数据。

**如果演示文稿已经加载，应该使用哪个 API？**

读取 [Presentation::getSourceFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/#getSourceFormat)。在加载前检查时使用 [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentationfactory/#getPresentationInfo)。