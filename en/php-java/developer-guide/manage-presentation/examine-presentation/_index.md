---
title: Retrieve and Update Presentation Information in PHP
linktitle: Presentation Information
type: docs
weight: 30
url: /php-java/examine-presentation/
keywords:
- presentation format
- presentation properties
- document properties
- get properties
- read properties
- change properties
- modify properties
- update properties
- examine PPTX
- examine PPT
- examine ODP
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Explore slides, structure and metadata in PowerPoint and OpenDocument presentations using Aspose.Slides for PHP for faster insights and smarter content audits."
---

## **Overview**

Aspose.Slides can identify a presentation's format and read its document metadata without creating a complete presentation object model. This is useful when you need to classify files, build an inventory, or inspect properties before deciding whether to load and process the presentation content.

This article demonstrates lightweight inspection through [PresentationFactory](https://reference.aspose.com/slides/php-java/aspose.slides/presentationfactory/) and [PresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/), as well as targeted updates through [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/).

## **Check a Presentation Format**

Use [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/presentationfactory/) to inspect a file without creating a [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) instance. The [PresentationInfo::getLoadFormat](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/#getLoadFormat) method reports the detected format, such as PPTX, PPT, or ODP.

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

## **Build a Lightweight Presentation Inventory**

When you process many presentation files, you may need a compact inventory for validation, indexing, or a document-management system. In this scenario, use [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/presentationfactory/) to obtain a [PresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/) object, and then call [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/#readDocumentProperties) to read the document metadata. This approach does not create a [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) instance or require you to traverse the complete presentation object model.

The extended properties exposed by [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) provide the following inventory values:

| Method | Inventory value |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getSlides) | Total number of slides. |
| [getHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getHiddenSlides) | Number of hidden slides. |
| [getNotes](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getNotes) | Number of slides that contain notes. |
| [getParagraphs](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getParagraphs) | Total number of paragraphs, when available. |
| [getWords](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getWords) | Total number of words. |
| [getMultimediaClips](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getMultimediaClips) | Total number of audio and video clips. |

The following example reads these values without creating a [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) object and prints a compact inventory. It also combines [DocumentProperties::getHeadingPairs](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getHeadingPairs) with [DocumentProperties::getTitlesOfParts](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getTitlesOfParts) to display content groups such as fonts, themes, and slide titles.

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

Each [HeadingPair](https://reference.aspose.com/slides/php-java/aspose.slides/headingpair/) supplies a group name and the number of items in that group. [DocumentProperties::getTitlesOfParts](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getTitlesOfParts) returns a flat, ordered array, so consume the number of consecutive titles specified by each heading pair.

### **Stored Metadata and Format Limitations**

The inventory properties returned by [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/#readDocumentProperties) reflect metadata available in the source document. Aspose.Slides does not load and traverse the presentation object model to recalculate these values for this call. Missing properties are represented by default values, and stored values may be stale if the application that last saved the file did not update its document properties.

- **PPTX:** The format provides extended document properties for slide, note, hidden-slide, paragraph, word, and multimedia counts, as well as heading pairs and part titles. Availability depends on which properties were written by the document producer.
- **PPT:** The binary format can store corresponding document-summary properties. If a property is absent or was not refreshed by the document producer, Aspose.Slides returns its stored or default value rather than calculating it from the slides.
- **ODP:** OpenDocument metadata provides general document statistics, such as page, paragraph, and word counts, but these values do not map to every PowerPoint-specific extended property. Hidden-slide, notes-slide, multimedia, heading-pair, and part-title metadata may be unavailable, and the inventory properties may return default values. Do not treat a zero value or an empty array as authoritative proof that the corresponding content is absent.

Use the lightweight metadata approach for inventories and preliminary checks. Load the presentation and inspect its live object model when the result must reflect in-memory changes or when you need to verify the actual presentation content.

## **Update Presentation Properties**

The properties returned by [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/#readDocumentProperties) can also be changed without creating a [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) instance. Apply the changes with [PresentationInfo::updateDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/#updateDocumentProperties), and then write the bound presentation with [PresentationInfo::writeBindedPresentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/#writeBindedPresentation).

The following image shows the original document properties.

![Original document properties of the PowerPoint presentation](input_properties.png)

The following example changes the title and last-saved time and writes the result to a new file:

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

The following image shows the updated document properties.

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **Useful Links**

For related security checks and protection settings, see the following articles:

- [Password-Protect Presentations](/slides/php-java/password-protected-presentation/)
- [Write-Protect Presentations](/slides/php-java/write-protected-presentation/)

## **FAQ**

**How can I check whether fonts are embedded and which ones they are?**

Load the presentation and use [Presentation::getFontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getFontsManager). Call [FontsManager::getEmbeddedFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts) to obtain the embedded fonts and [FontsManager::getFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/#getFonts) to obtain the fonts used by the presentation. Compare the two results to find fonts that are required for rendering but are not embedded.

**How can I quickly tell if the file has hidden slides and how many?**

When stored document metadata is sufficient, read [DocumentProperties::getHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getHiddenSlides) through [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/presentationfactory/) and [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/#readDocumentProperties). This is suitable for a lightweight inventory. If the presentation has been modified in memory, the stored metadata may be missing or stale, or you need to verify live values, iterate through [Presentation::getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides) and inspect each slide's [Slide::getHidden](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getHidden) method instead.

**Can I detect whether custom slide size and orientation are used, and whether they differ from the defaults?**

Yes. Load the presentation and call [Presentation::getSlideSize](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlideSize). Use [SlideSize::getType](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/#getType), [SlideSize::getSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/#getSize), and [SlideSize::getOrientation](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/#getOrientation) to compare the current settings with the expected preset and dimensions.

**Is there a quick way to see if charts reference external data sources?**

Yes. Locate each [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/) and call [ChartData::getDataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/#getDataSourceType). For an external workbook, call [ChartData::getExternalWorkbookPath](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/#getExternalWorkbookPath). The data source type and path identify an external reference, but verifying whether the target is available requires a separate resource check.

**How can I assess 'heavy' slides that may slow rendering or PDF export?**

There is no single complexity property. Traverse [Presentation::getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides) and each slide's [BaseSlide::getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getShapes) collection. Use shape counts and the presence of large images, effects, animations, or multimedia as screening signals, and measure a representative render or export before treating a slide as a confirmed performance bottleneck.
