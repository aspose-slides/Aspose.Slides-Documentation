---
title: 在 PHP 中检索和更新演示文稿信息
linktitle: 演示文稿信息
type: docs
weight: 30
url: /zh/php-java/examine-presentation/
keywords:
- 演示文稿格式
- 演示文稿属性
- 文档属性
- 获取属性
- 读取属性
- 更改属性
- 修改属性
- 更新属性
- 检查 PPTX
- 检查 PPT
- 检查 ODP
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP，深入探索 PowerPoint 和 OpenDocument 演示文稿中的幻灯片、结构和元数据，以获得更快速的洞察和更智能的内容审计。"
---
## **概览**

Aspose.Slides 可以识别演示文稿的格式并读取其文档元数据，而无需创建完整的演示文稿对象模型。当您需要对文件进行分类、构建清单或在决定是否加载和处理演示文稿内容之前检查属性时，这非常有用。

本文演示如何通过 [PresentationFactory](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentationfactory/) 和 [PresentationInfo](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentationinfo/) 进行轻量级检查，以及通过 [DocumentProperties](https://reference.aspose.com/slides/zh/php-java/aspose.slides/documentproperties/) 进行有针对性的更新。

## **检查演示文稿格式**

如果您已经加载了演示文稿，请参阅 [Determine the Original Presentation Format](/slides/zh/php-java/detect-presentation-source-format/) 以了解加载后检测以及旧版 PPT、PPS、POT 流的限制。

使用 [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentationfactory/) 可在不创建 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 实例的情况下检查文件。`[PresentationInfo::getLoadFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentationinfo/#getLoadFormat)` 方法报告检测到的格式，例如 PPTX、PPT 或 ODP。

```php
use aspose\slides\LoadFormat;
use aspose\slides\PresentationFactory;

$fileNames = ["pres.pptx", "pres.ppt", "pres.odp"];

foreach ($fileNames as $fileName) {
    $presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($fileName);
    $loadFormat = java_values($presentationInfo->getLoadFormat());
    $formatName = "Other (" . $loadFormat . ")";

    if ($loadFormat === LoadFormat::Pptx) {
        $formatName = "PPTX";
    } elseif ($loadFormat === LoadFormat::Ppt) {
        $formatName = "PPT";
    } elseif ($loadFormat === LoadFormat::Odp) {
        $formatName = "ODP";
    }

    echo $fileName . ": " . $formatName . PHP_EOL;
}
```

## **构建轻量级演示文稿清单**

当您处理大量演示文稿文件时，可能需要一个紧凑的清单用于验证、索引或文档管理系统。在此场景中，使用 [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentationfactory/) 获取 [PresentationInfo](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentationinfo/) 对象，然后调用 `[PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentationinfo/#readDocumentProperties)` 读取文档元数据。此方法不创建 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 实例，也不需要遍历完整的演示文稿对象模型。

[DocumentProperties](https://reference.aspose.com/slides/zh/php-java/aspose.slides/documentproperties/) 暴露的扩展属性提供以下清单值：

| 方法 | 清单值 |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/zh/php-java/aspose.slides/documentproperties/#getSlides) | 幻灯片总数。 |
| [getHiddenSlides](https://reference.aspose.com/slides/zh/php-java/aspose.slides/documentproperties/#getHiddenSlides) | 隐藏幻灯片的数量。 |
| [getNotes](https://reference.aspose.com/slides/zh/php-java/aspose.slides/documentproperties/#getNotes) | 含备注的幻灯片数量。 |
| [getParagraphs](https://reference.aspose.com/slides/zh/php-java/aspose.slides/documentproperties/#getParagraphs) | 可用时的段落总数。 |
| [getWords](https://reference.aspose.com/slides/zh/php-java/aspose.slides/documentproperties/#getWords) | 单词总数。 |
| [getMultimediaClips](https://reference.aspose.com/slides/zh/php-java/aspose.slides/documentproperties/#getMultimediaClips) | 音视频剪辑总数。 |

下面的示例在不创建 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 对象的情况下读取这些值并打印紧凑的清单。它还将 [DocumentProperties::getHeadingPairs](https://reference.aspose.com/slides/zh/php-java/aspose.slides/documentproperties/#getHeadingPairs) 与 [DocumentProperties::getTitlesOfParts](https://reference.aspose.com/slides/zh/php-java/aspose.slides/documentproperties/#getTitlesOfParts) 组合，以显示诸如字体、主题和幻灯片标题等内容分组。

```php
use aspose\slides\LoadFormat;
use aspose\slides\PresentationFactory;

$filePath = "sample.pptx";
$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($filePath);
$documentProperties = $presentationInfo->readDocumentProperties();

$loadFormat = java_values($presentationInfo->getLoadFormat());
$formatName = "Other (" . $loadFormat . ")";

if ($loadFormat === LoadFormat::Pptx) {
    $formatName = "PPTX";
} elseif ($loadFormat === LoadFormat::Ppt) {
    $formatName = "PPT";
} elseif ($loadFormat === LoadFormat::Odp) {
    $formatName = "ODP";
}

echo "File: " . basename($filePath) . PHP_EOL;
echo "Format: " . $formatName . PHP_EOL;
echo "Title: " . java_values($documentProperties->getTitle()) . PHP_EOL;
echo "Author: " . java_values($documentProperties->getAuthor()) . PHP_EOL;
echo "Statistics:" . PHP_EOL;
echo "  Slides: " . java_values($documentProperties->getSlides()) . PHP_EOL;
echo "  Hidden slides: " . java_values($documentProperties->getHiddenSlides()) . PHP_EOL;
echo "  Slides with notes: " . java_values($documentProperties->getNotes()) . PHP_EOL;
echo "  Paragraphs: " . java_values($documentProperties->getParagraphs()) . PHP_EOL;
echo "  Words: " . java_values($documentProperties->getWords()) . PHP_EOL;
echo "  Multimedia clips: " . java_values($documentProperties->getMultimediaClips()) . PHP_EOL;

$headingPairs = $documentProperties->getHeadingPairs();
$titlesOfParts = $documentProperties->getTitlesOfParts();

if (java_is_null($headingPairs) || java_is_null($titlesOfParts)) {
    echo "Content groups: not available" . PHP_EOL;
} else {
    $headingPairs = java_values($headingPairs);
    $titlesOfParts = java_values($titlesOfParts);
    $partIndex = 0;

    if (count($headingPairs) === 0 || count($titlesOfParts) === 0) {
        echo "Content groups: not available" . PHP_EOL;
    } else {
        echo "Content groups:" . PHP_EOL;

        foreach ($headingPairs as $headingPair) {
            $partCount = java_values($headingPair->getCount());
            echo "  " . java_values($headingPair->getName()) . " (" . $partCount . ")" . PHP_EOL;

            for ($partOffset = 0; $partOffset < $partCount && $partIndex < count($titlesOfParts); $partOffset++) {
                echo "    - " . $titlesOfParts[$partIndex] . PHP_EOL;
                $partIndex++;
            }
        }

        if ($partIndex < count($titlesOfParts)) {
            echo "  Other parts:" . PHP_EOL;

            while ($partIndex < count($titlesOfParts)) {
                echo "    - " . $titlesOfParts[$partIndex] . PHP_EOL;
                $partIndex++;
            }
        }
    }
}
```

每个 [HeadingPair](https://reference.aspose.com/slides/zh/php-java/aspose.slides/headingpair/) 提供组名及该组中项目的数量。`[DocumentProperties::getTitlesOfParts](https://reference.aspose.com/slides/zh/php-java/aspose.slides/documentproperties/#getTitlesOfParts)` 返回一个平铺的有序数组，因此请按每个 heading pair 指定的连续标题数量进行消费。

### **存储的元数据和格式限制**

由 `[PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentationinfo/#readDocumentProperties)` 返回的清单属性反映源文档中可用的元数据。Aspose.Slides 不会加载并遍历演示文稿对象模型来重新计算这些值。缺失的属性使用默认值表示，如果最后保存文件的应用程序未更新其文档属性，则存储的值可能已过时。

- **PPTX:** 该格式提供幻灯片、备注、隐藏幻灯片、段落、单词和多媒体计数的扩展文档属性，以及 heading pairs 和 part titles。其可用性取决于文档生成方写入了哪些属性。
- **PPT:** 二进制格式可以存储相应的文档摘要属性。如果属性缺失或未由文档生成方刷新，Aspose.Slides 将返回其存储的或默认值，而不是根据幻灯片重新计算。
- **ODP:** OpenDocument 元数据提供通用的文档统计信息，如页面、段落和单词计数，但这些值并不映射到每个 PowerPoint 特有的扩展属性。隐藏幻灯片、备注幻灯片、多媒体、heading‑pair 和 part‑title 元数据可能不可用，清单属性可能返回默认值。请勿将零值或空数组视为对应内容缺失的权威证明。

在进行清单和初步检查时使用轻量级元数据方法。若结果必须反映内存中的更改或需要验证实际的演示文稿内容，请加载演示文稿并检查其实时对象模型。

## **更新演示文稿属性**

由 `[PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentationinfo/#readDocumentProperties)` 返回的属性也可以在不创建 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 实例的情况下更改。使用 `[PresentationInfo::updateDocumentProperties](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentationinfo/#updateDocumentProperties)` 应用更改，然后使用 `[PresentationInfo::writeBindedPresentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentationinfo/#writeBindedPresentation)` 写入绑定的演示文稿。

以下图片显示了原始文档属性。

![PowerPoint 演示文稿的原始文档属性](input_properties.png)

以下示例更改标题和最后保存时间，并将结果写入新文件：

```php
use aspose\slides\PresentationFactory;

$sourceFile = "sample.pptx";
$outputFile = "sample_with_updated_properties.pptx";
$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($sourceFile);
$documentProperties = $presentationInfo->readDocumentProperties();

$documentProperties->setTitle("Quarterly sales report");
$documentProperties->setLastSavedTime(new Java("java.util.Date"));

$presentationInfo->updateDocumentProperties($documentProperties);
$outputStream = new Java("java.io.FileOutputStream", $outputFile);
try {
    $presentationInfo->writeBindedPresentation($outputStream);
} finally {
    $outputStream->close();
}
```

以下图片显示了更新后的文档属性。

![PowerPoint 演示文稿的已更改文档属性](output_properties.png)

## **有用的链接**

有关相关安全检查和保护设置，请参阅以下文章：

- [Password-Protect Presentations](/slides/zh/php-java/password-protected-presentation/)
- [Write-Protect Presentations](/slides/zh/php-java/write-protected-presentation/)

## **常见问题**

**如何检查字体是否已嵌入以及具体是哪几种？**

加载演示文稿并使用 [Presentation::getFontsManager](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/#getFontsManager)。调用 `[FontsManager::getEmbeddedFonts](https://reference.aspose.com/slides/zh/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts)` 获取嵌入的字体，调用 `[FontsManager::getFonts](https://reference.aspose.com/slides/zh/php-java/aspose.slides/fontsmanager/#getFonts)` 获取演示文稿使用的字体。比较这两个结果即可发现需要渲染但未嵌入的字体。

**如何快速判断文件是否包含隐藏幻灯片以及数量？**

当存储的文档元数据足够时，可通过 [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentationfactory/) 再调用 `[PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentationinfo/#readDocumentProperties)` 读取 `[DocumentProperties::getHiddenSlides](https://reference.aspose.com/slides/zh/php-java/aspose.slides/documentproperties/#getHiddenSlides)`。这适用于轻量级清单。如果演示文稿已在内存中修改，存储的元数据可能缺失或已过期，或者需要验证实时值，则遍历 `[Presentation::getSlides](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/#getSlides)` 并检查每个幻灯片的 `[Slide::getHidden](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slide/#getHidden)` 方法。

**我能检测自定义幻灯片大小和方向是否被使用，以及它们是否与默认值不同吗？**

可以。加载演示文稿并调用 `[Presentation::getSlideSize](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/#getSlideSize)`。使用 `[SlideSize::getType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slidesize/#getType)`、`[SlideSize::getSize](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slidesize/#getSize)` 和 `[SlideSize::getOrientation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slidesize/#getOrientation)` 将当前设置与预设的尺寸和方向进行比较。

**有没有快速方法查看图表是否引用外部数据源？**

有。定位每个 [Chart](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chart/) 并调用 `[ChartData::getDataSourceType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartdata/#getDataSourceType)`。对于外部工作簿，调用 `[ChartData::getExternalWorkbookPath](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartdata/#getExternalWorkbookPath)`。数据源类型和路径可以识别外部引用，但是否可用需要另行资源检查。

**如何评估可能导致渲染或 PDF 导出变慢的“重”幻灯片？**

没有单一的复杂度属性。遍历 `[Presentation::getSlides](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/#getSlides)` 并检查每个幻灯片的 `[BaseSlide::getShapes](https://reference.aspose.com/slides/zh/php-java/aspose.slides/baseslide/#getShapes)` 集合。使用形状计数以及是否包含大图片、效果、动画或多媒体作为筛选信号，并在确认某张幻灯片为性能瓶颈前进行代表性的渲染或导出测量。