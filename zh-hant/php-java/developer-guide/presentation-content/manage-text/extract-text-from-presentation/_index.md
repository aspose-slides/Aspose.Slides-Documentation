---
title: 在 PHP 中的簡報高階文字擷取
linktitle: 擷取文字
type: docs
weight: 90
url: /zh-hant/php-java/extract-text-from-presentation/
keywords:
- 擷取文字
- 從投影片擷取文字
- 從簡報擷取文字
- 從 PowerPoint 擷取文字
- 從 OpenDocument 擷取文字
- 從 PPT 擷取文字
- 從 PPTX 擷取文字
- 從 ODP 擷取文字
- 取得文字
- 從投影片取得文字
- 從簡報取得文字
- 從 PowerPoint 取得文字
- 從 OpenDocument 取得文字
- 從 PPT 取得文字
- 從 PPTX 取得文字
- 從 ODP 取得文字
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "快速使用 Aspose.Slides for PHP via Java 從 PowerPoint 與 OpenDocument 簡報擷取文字。遵循我們簡單、逐步的指南以節省時間。"
---
## **概觀**

從簡報中擷取文字是一項常見且重要的工作，適用於處理投影片內容的開發人員。無論您在處理 Microsoft PowerPoint 的 PPT 或 PPTX 檔案，或是 OpenDocument 簡報 (ODP)，存取和取得文字資料對於分析、自動化、索引或內容遷移等目的都可能是關鍵。

本文提供了使用 Aspose.Slides for PHP via Java 從各種簡報格式（包括 PPT、PPTX 與 ODP）有效擷取文字的完整指南。您將學習如何系統性地遍歷簡報元素，以準確取得所需的文字內容。

## **從投影片擷取文字**

Aspose.Slides for PHP via Java 提供了 [SlideUtil](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slideutil/) 類別。此類別暴露了多個重載的靜態方法，用於從簡報或投影片擷取所有文字。若要從簡報中的投影片擷取文字，請使用 [getAllTextBoxes](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slideutil/#getAllTextBoxes) 方法。此方法接受一個 [BaseSlide](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseslide/) 型別的物件作為參數。執行時，該方法會掃描整個投影片的文字，並回傳一個 [TextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/) 型別物件的陣列，保留任何文字格式。

以下程式碼片段會從簡報的第一張投影片擷取所有文字：

```php
$slideIndex = 0;

$presentation = new Presentation("demo.pptx");
$arrayClass = new java_class("java.lang.reflect.Array");

try {
    $slide = $presentation->getSlides()->get_Item($slideIndex);

    $textFrames = SlideUtil::getAllTextBoxes($slide);
    $textFrameCount = java_values($arrayClass->getLength($textFrames));

    for ($textFrameIndex = 0; $textFrameIndex < $textFrameCount; $textFrameIndex++) {
        foreach ($textFrames[$textFrameIndex]->getParagraphs() as $paragraph) {
            foreach ($paragraph->getPortions() as $portion) {
                $portionText = $portion->getText();
                echo($portionText);

                $portionFormat = $portion->getPortionFormat();
                $fontHeight = $portionFormat->getFontHeight();
                echo($fontHeight);

                $latinFont = $portionFormat->getLatinFont();
                if (!java_is_null($latinFont)) {
                    $fontName = $latinFont->getFontName();
                    echo($fontName);
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **從簡報擷取文字**

若要掃描整個簡報的文字，請使用由 [SlideUtil](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slideutil/) 類別所提供的 [getAllTextFrames](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slideutil/#getAllTextFrames) 靜態方法。它接受兩個參數：

1. 第一個參數為 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 物件，代表要從中擷取文字的 PowerPoint 或 OpenDocument 簡報。
1. 第二個參數為 `boolean` 值，指示在掃描簡報文字時是否應包含母版投影片。

此方法回傳一個 [TextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/) 型別物件的陣列，包含文字格式資訊。以下程式碼會掃描簡報的文字與格式細節，並包括母版投影片。

```php
$presentation = new Presentation("demo.pptx");
$arrayClass = new java_class("java.lang.reflect.Array");

try {
    $includeMasterSlides = true;
    $textFrames = SlideUtil::getAllTextFrames($presentation, $includeMasterSlides);
    $textFrameCount = java_values($arrayClass->getLength($textFrames));

    for ($textFrameIndex = 0; $textFrameIndex < $textFrameCount; $textFrameIndex++) {
        foreach ($textFrames[$textFrameIndex]->getParagraphs() as $paragraph) {
            foreach ($paragraph->getPortions() as $portion) {
                $portionText = $portion->getText();
                echo($portionText);

                $portionFormat = $portion->getPortionFormat();
                $fontHeight = $portionFormat->getFontHeight();
                echo($fontHeight);

                $latinFont = $portionFormat->getLatinFont();
                if (!java_is_null($latinFont)) {
                    $fontName = $latinFont->getFontName();
                    echo($fontName);
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **分類與快速文字擷取**

[PresentationFactory](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentationfactory/) 類別同樣提供從簡報擷取所有文字的方法：

```php
PresentationText getPresentationText(String, int);
PresentationText getPresentationText(InputStream, int);
PresentationText getPresentationText(InputStream, int, LoadOptions);
```

[TextExtractionArrangingMode](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textextractionarrangingmode/) 列舉參數表示文字擷取結果的組織模式，可設定為以下值：
- `Unarranged` - 未考慮投影片位置的原始文字。
- `Arranged` - 文字依投影片上的順序排列。

當速度至關重要時，可使用未排列模式；其速度快於已排列模式。

[PresentationText](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentationtext/) 代表從簡報擷取的原始文字。其 `getSlidesText` 方法回傳一個物件陣列，陣列中的每個物件代表對應投影片的文字。每個回傳的物件具有以下方法：

- `getText` - 投影片形狀內的文字。
- `getMasterText` - 與此投影片相關的母版投影片形狀內的文字。
- `getLayoutText` - 與此投影片相關的版面配置投影片形狀內的文字。
- `getNotesText` - 與此投影片相關的備註投影片形狀內的文字。
- `getCommentsText` - 與此投影片相關的批註內的文字。

```php
$presentationPath = "presentation.ppt";
$arrangingMode = TextExtractionArrangingMode::Unarranged;
$presentationText = PresentationFactory::getInstance()->getPresentationText($presentationPath, $arrangingMode);
$slidesText = $presentationText->getSlidesText();
$firstSlideText = $slidesText[0];

echo($firstSlideText->getText());
echo($firstSlideText->getLayoutText());
echo($firstSlideText->getMasterText());
echo($firstSlideText->getNotesText());
echo($firstSlideText->getCommentsText());
```

## **常見問題**

**Aspose.Slides 在文字擷取過程中處理大型簡報的速度如何？**

Aspose.Slides 已針對高效能進行最佳化，甚至能處理[大型簡報](/slides/zh-hant/php-java/open-presentation/)，使其適用於即時或批次處理情境。

**Aspose.Slides 能否從簡報中的表格和圖表擷取文字？**

可以。Aspose.Slides 能從多種投影片元素擷取文字，包括表格和圖表相關物件，讓您能存取與分析常見簡報結構中的文字內容。

**是否需要特殊的 Aspose.Slides 授權才能從簡報擷取文字？**

您可以使用 Aspose.Slides 的免費試用版進行文字擷取，儘管它會有[某些限制](/slides/zh-hant/php-java/licensing/)，例如只能處理有限數量的投影片。若需無限制使用且處理更大型的簡報，建議購買完整授權。