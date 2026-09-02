---
title: 在 PHP 中檢索與更新簡報資訊
linktitle: 簡報資訊
type: docs
weight: 30
url: /zh-hant/php-java/examine-presentation/
keywords:
- 簡報格式
- 簡報屬性
- 文件屬性
- 取得屬性
- 讀取屬性
- 變更屬性
- 修改屬性
- 更新屬性
- 檢查 PPTX
- 檢查 PPT
- 檢查 ODP
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP 探索 PowerPoint 與 OpenDocument 簡報中的投影片、結構與中繼資料，以獲得更快速的洞察與更聰明的內容稽核。"
---
## **概觀**

Aspose.Slides 可以在不建立完整簡報物件模型的情況下辨識簡報的格式並讀取其文件中繼資料。這在您需要分類檔案、建立清單或在決定是否載入與處理簡報內容之前檢查屬性時非常有用。

本文說明如何透過 [PresentationFactory](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentationfactory/) 與 [PresentationInfo](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentationinfo/) 進行輕量檢查，以及透過 [DocumentProperties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/documentproperties/) 進行目標更新。

## **檢查簡報格式**

使用 [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentationfactory/) 檢查檔案而不建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 實例。[PresentationInfo::getLoadFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentationinfo/#getLoadFormat) 方法會回報偵測到的格式，例如 PPTX、PPT 或 ODP。

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

## **建立輕量簡報清單**

當您處理大量簡報檔案時，可能需要一個緊湊的清單以供驗證、索引或文件管理系統使用。在此情境下，使用 [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentationfactory/) 取得 [PresentationInfo](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentationinfo/) 物件，然後呼叫 [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentationinfo/#readDocumentProperties) 讀取文件中繼資料。此方式不會建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 實例，也不需遍歷完整的簡報物件模型。

[DocumentProperties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/documentproperties/) 所提供的擴充屬性可取得下列清單值：

| 方法 | 清單值 |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/documentproperties/#getSlides) | 投影片的總數。 |
| [getHiddenSlides](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/documentproperties/#getHiddenSlides) | 隱藏投影片的數量。 |
| [getNotes](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/documentproperties/#getNotes) | 包含註解的投影片數量。 |
| [getParagraphs](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/documentproperties/#getParagraphs) | 段落的總數（若有提供）。 |
| [getWords](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/documentproperties/#getWords) | 字數的總數。 |
| [getMultimediaClips](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/documentproperties/#getMultimediaClips) | 音訊與視訊剪輯的總數。 |

以下範例在不建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 物件的情況下讀取這些值，並列印緊湊的清單。它同時結合 [DocumentProperties::getHeadingPairs](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/documentproperties/#getHeadingPairs) 與 [DocumentProperties::getTitlesOfParts](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/documentproperties/#getTitlesOfParts) 以顯示如字型、主題與投影片標題等內容群組。

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

每個 [HeadingPair](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/headingpair/) 皆提供群組名稱與該群組項目的數量。[DocumentProperties::getTitlesOfParts](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/documentproperties/#getTitlesOfParts) 回傳一個平面且有序的陣列，因此請依照每個 heading pair 指定的連續標題數量逐一取用。

### **儲存的中繼資料與格式限制**

由 [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentationinfo/#readDocumentProperties) 回傳的清單屬性反映來源文件中可用的中繼資料。Aspose.Slides 不會載入並遍歷簡報物件模型以重新計算這些值。缺少的屬性以預設值表示，若最後一次儲存檔案的應用程式未更新其文件屬性，已儲存的值可能已過時。

- **PPTX:** 此格式提供投影片、註解、隱藏投影片、段落、字數與多媒體計數等擴充文件屬性，亦包括 heading pairs 與 part titles。可用性取決於文件產生者寫入了哪些屬性。
- **PPT:** 二進位格式可儲存對應的文件摘要屬性。如果屬性不存在或未由文件產生者重新整理，Aspose.Slides 會回傳其已儲存或預設的值，而不是自投影片重新計算。
- **ODP:** OpenDocument 中繼資料提供一般文件統計資訊，例如頁面、段落與字數，但這些值未必對應每個 PowerPoint 特定的擴充屬性。隱藏投影片、註解投影片、多媒體、heading‑pair 與 part‑title 中繼資料可能不存在，清單屬性可能回傳預設值。不要將零值或空陣列當作對應內容不存在的權威證明。

請在建立清單與初步檢查時使用輕量中繼資料方法。若結果必須反映記憶體中的變更，或需要驗證實際的簡報內容，請載入簡報並檢查其即時物件模型。

## **更新簡報屬性**

由 [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentationinfo/#readDocumentProperties) 回傳的屬性也可以在不建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 實例的情況下變更。使用 [PresentationInfo::updateDocumentProperties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentationinfo/#updateDocumentProperties) 套用變更，然後透過 [PresentationInfo::writeBindedPresentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentationinfo/#writeBindedPresentation) 寫入已綁定的簡報。

以下影像顯示 PowerPoint 簡報的原始文件屬性。

![PowerPoint簡報的原始文件屬性](input_properties.png)

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

以下範例變更標題與最後儲存時間，並將結果寫入新檔案：

![PowerPoint簡報的已變更文件屬性](output_properties.png)

## **相關連結**

有關相關的安全檢查與保護設定，請參閱以下文章：

- [密碼保護簡報](/slides/zh-hant/php-java/password-protected-presentation/)
- [寫入保護簡報](/slides/zh-hant/php-java/write-protected-presentation/)

## **常見問題**

**如何檢查是否已嵌入字型以及是哪一些字型？**

載入簡報並使用 [Presentation::getFontsManager](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#getFontsManager)。呼叫 [FontsManager::getEmbeddedFonts](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts) 取得已嵌入的字型，並呼叫 [FontsManager::getFonts](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fontsmanager/#getFonts) 取得簡報使用的字型。比較兩個結果即可找出需要呈現但未嵌入的字型。

**如何快速判斷檔案是否有隱藏投影片以及有多少？**

當儲存的文件中繼資料足夠時，透過 [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentationfactory/) 與 [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentationinfo/#readDocumentProperties) 讀取 [DocumentProperties::getHiddenSlides](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/documentproperties/#getHiddenSlides)。此方式適用於輕量清單。如果簡報已在記憶體中被修改，儲存的中繼資料可能缺失或過時，或需要驗證即時值，請遍歷 [Presentation::getSlides](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#getSlides) 並檢查每張投影片的 [Slide::getHidden](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slide/#getHidden) 方法。

**我能偵測是否使用自訂投影片大小與方向，且是否與預設不同嗎？**

可以。載入簡報並呼叫 [Presentation::getSlideSize](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#getSlideSize)。使用 [SlideSize::getType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slidesize/#getType)、[SlideSize::getSize](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slidesize/#getSize) 與 [SlideSize::getOrientation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slidesize/#getOrientation) 比對目前設定與預期的預設與尺寸。

**有沒有快速方式檢查圖表是否參考外部資料來源？**

有。找出每個 [Chart](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chart/) 並呼叫 [ChartData::getDataSourceType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdata/#getDataSourceType)。若為外部活頁簿，呼叫 [ChartData::getExternalWorkbookPath](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdata/#getExternalWorkbookPath)。資料來源類型與路徑可識別外部參照，但是否可用仍需另行檢查資源。

**我要如何評估可能會拖慢渲染或 PDF 匯出的「重」投影片？**

沒有單一的複雜度屬性。遍歷 [Presentation::getSlides](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#getSlides) 並檢查每張投影片的 [BaseSlide::getShapes](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseslide/#getShapes) 集合。使用形狀數量以及大型影像、特效、動畫或多媒體的存在作為篩選訊號，並在將投影片視為確定的效能瓶頸前，先測量具代表性的渲染或匯出時間。