---
title: 在 PHP 中格式化簡報文字
linktitle: 文字格式化
type: docs
weight: 50
url: /zh-hant/php-java/text-formatting/
keywords:
- 對齊段落
- 文字樣式
- 文字背景
- 文字透明度
- 字元間距
- 字型屬性
- 字型族
- 文字旋轉
- 旋轉角度
- 文字框
- 行距
- 自動調整屬性
- 文字框錨點
- 文字定位點
- 預設語言
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 在 PowerPoint 與 OpenDocument 簡報中格式化與樣式化文字。自訂字型、顏色、對齊方式等更多設定。"
---
## **概觀**

本文說明如何使用 Aspose.Slides for PHP via Java 來設定 PowerPoint 與 OpenDocument 簡報中的文字格式。內容涵蓋背景色、透明度、字元間距、字型屬性、旋轉、段落間距、自動調整行為、文字錨點、定位點與語言設定等。

除非另有說明，範例均使用 [sample.pptx](sample.pptx)。第一張投影片的第一個圖形是一個文字方塊，其第一段落包含下列文字。投影片與圖形的索引皆為零基礎。選取粗體部份的範例使用有效格式化，包括繼承的粗體格式：

![範例文字](sample_text.png)

若要尋找並標示文字字面值或正規表達式匹配項目，請參閱 [搜尋與取代文字](/slides/zh-hant/php-java/search-and-replace-text/)。

## **設定文字背景色**

使用 [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) 來設定段落的預設醒目顏色，或使用 [BasePortionFormat::getHighlightColor](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getHighlightColor) 針對個別文字部份設定。

以下範例將第一段落的預設醒目色設為淡灰色。個別部份的明確醒目色會優先於此預設值：

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $highlightColor = java("java.awt.Color")->LIGHT_GRAY;

    // 設定整段落的醒目顏色。
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getHighlightColor()->setColor($highlightColor);

    $presentation->save("gray_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果：

![灰色段落](gray_paragraph.png)

以下程式碼示範如何將 **粗體字** 的文字部份背景色設為灰色：

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $highlightColor = java("java.awt.Color")->LIGHT_GRAY;

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold())) {
            // 設定文字部份的醒目顏色。
            $portion->getPortionFormat()->getHighlightColor()->setColor($highlightColor);
        }
    }

    $presentation->save("gray_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果：

![灰色文字部份](gray_text_portions.png)

## **對齊文字段落**

使用 [ParagraphFormat::setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setAlignment) 來設定文字框內段落的對齊方式。可設定為置中、左對齊、右對齊、兩端對齊等。

以下程式碼範例示範如何將段落對齊至 **置中**：

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAlignment;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // 設定段落的對齊方式為置中。
    $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Center);

    $presentation->save("aligned_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果：

![置中段落](aligned_paragraph.png)

## **在同一行內對齊字型**

使用 [ParagraphFormat::setFontAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setFontAlignment) 以垂直方式對齊同一行中不同字型大小的文字部份。此設定套用於整個段落，並控制每一行內的對齊。

以下自行完整的範例會在同一張投影片上建立四個標記文字方塊。每個段落的文字大小分別為 18、36、54 點，且字型對齊方式各不相同。範例使用 Arial、停用自動調整與換行，且保持文字框足夠容納單行文字：

```php
use aspose\slides\FillType;
use aspose\slides\FontAlignment;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAnchorType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $alignments = [FontAlignment::Baseline, FontAlignment::Top, FontAlignment::Center, FontAlignment::Bottom];
    $alignmentNames = ["Baseline", "Top", "Center", "Bottom"];
    $fontSizes = [18, 36, 54];
    $font = new FontData("Arial");
    $gray = java("java.awt.Color")->GRAY;
    $black = java("java.awt.Color")->BLACK;

    for ($i = 0; $i < count($alignments); $i++) {
        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 20 + $i * 130, 660, 120);
        $shape->getFillFormat()->setFillType(FillType::NoFill);
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

        $textFrame = $shape->getTextFrame();
        $textFrame->getTextFrameFormat()->setAnchoringType(TextAnchorType::Top);
        $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::None);
        $textFrame->getTextFrameFormat()->setWrapText(NullableBool::False);

        $label = $textFrame->getParagraphs()->get_Item(0);
        $label->setText($alignmentNames[$i]);
        $label->getParagraphFormat()->setAlignment(TextAlignment::Left);
        $label->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(14);
        $label->getParagraphFormat()->getDefaultPortionFormat()->setLatinFont($font);
        $label->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
        $label->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($gray);

        $paragraph = new Paragraph();
        $paragraph->getParagraphFormat()->setFontAlignment($alignments[$i]);
        $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Left);
        $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setLatinFont($font);
        $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
        $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($black);

        foreach ($fontSizes as $fontSize) {
            $portion = new Portion("Ag ");
            $portion->getPortionFormat()->setFontHeight($fontSize);
            $paragraph->getPortions()->add($portion);
        }

        $textFrame->getParagraphs()->add($paragraph);
    }

    $presentation->save("font_alignment.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果：

![基線、上方、置中與下方字型對齊的比較 (混合字型大小)](font_alignment.png)

字型對齊使用字型度量，因此個別字母的可見邊緣不一定完全對齊。範例同時包含大寫字母與下伸筆劃，以協助說明基線與下方對齊的差異。字型可用性與替代、使用的字元以及字型大小差異皆會影響結果。框架尺寸、邊距、行距、換行與自動調整亦會影響版面配置；在比較模式時請使用相同的字型與版面設定。

此設定與 [ParagraphFormat::setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setAlignment)（控制水平段落對齊）以及 [TextFrameFormat::setAnchoringType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAnchoringType)（在圖形內垂直定位文字區塊）不同。透過 [BasePortionFormat::setEscapement](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setEscapement) 套用上標或下標會將個別部份相對於基線移動，而非為段落的行設定字型對齊。

## **設定文字透明度**

文字透明度透過指派給 [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getFillFormat) 的顏色之 alpha 參數控制。下列範例中，`alpha = 50` 為 0–255 之 ARGB alpha 通道值，並非透明度百分比。

以下程式碼示範如何將 **整段落** 設為透明：

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $fillFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat();

    // 設定文字的填充顏色為透明色。
    $fillFormat->setFillType(FillType::Solid);
    $transparentColor = new Java("java.awt.Color", 0, 0, 0, $alpha);
    $fillFormat->getSolidFillColor()->setColor($transparentColor);

    $presentation->save("transparent_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果：

![透明段落](transparent_paragraph.png)

以下程式碼示範如何將 **粗體字** 的文字部份設為透明：

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $transparentColor = new Java("java.awt.Color", 0, 0, 0, $alpha);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold())) {
            // 設定文字部份的透明度。
            $fillFormat = $portion->getPortionFormat()->getFillFormat();
            $fillFormat->setFillType(FillType::Solid);
            $fillFormat->getSolidFillColor()->setColor($transparentColor);
        }
    }

    $presentation->save("transparent_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果：

![透明文字部份](transparent_text_portions.png)

## **設定文字字元間距**

使用 [BasePortionFormat::setSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setSpacing) 以擴張或壓縮文字方塊中字元之間的間距。範例加入 3 點間距；負值則會壓縮文字。

以下 PHP 程式碼示範如何在 **整段落** 中擴張字元間距：

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // 註：使用負值可壓縮字元間距。
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(3); // 展開字元間距。

    $presentation->save("character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果：

![段落中的字元間距](character_spacing_in_paragraph.png)

以下程式碼示範如何在 **粗體字** 的文字部份中擴張字元間距：

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold())) {
            // 註：使用負值可壓縮字元間距。
            $portion->getPortionFormat()->setSpacing(3); // 展開字元間距。
        }
    }

    $presentation->save("character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果：

![文字部份中的字元間距](character_spacing_in_text_portions.png)

### **為特定字型停用字距微調 (Kerning)**

在某些情況下，Aspose.Slides 所渲染的文字看起來會比 PowerPoint 中稍微緊密。這可能發生在 PowerPoint 忽略了某些字型的字距微調資料，即使該字型本身具備有效的字距微調資訊且 PowerPoint 設定中已啟用字距微調。

若要在此類情況下使渲染結果更接近 PowerPoint，您可以為使用受影響字型的文字部份停用字距微調。將 [BasePortionFormat::setKerningMinimalSize](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setKerningMinimalSize) 設為大於實際字型尺寸的值。本範例需要一個「presentation.pptx」且第一張投影片的第一個圖形為文字方塊。它會檢查有效字型名稱（包括繼承的字型），並對使用 Roboto 的部份設置 100 點的門檻：若字型尺寸低於 100 點，則停用字距微調：

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $targetFont = "Roboto";

    $paragraphCount = java_values($autoShape->getTextFrame()->getParagraphs()->getCount());
    for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
        $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item($paragraphIndex);
        $portionCount = java_values($paragraph->getPortions()->getCount());
        for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
            $portion = $paragraph->getPortions()->get_Item($portionIndex);
            $portionFormat = $portion->getPortionFormat()->getEffective();
            $latinFont = $portionFormat->getLatinFont();
            $eastAsianFont = $portionFormat->getEastAsianFont();
            $complexScriptFont = $portionFormat->getComplexScriptFont();

            if ((!java_is_null($latinFont) && $latinFont->getFontName() == $targetFont) ||
                (!java_is_null($eastAsianFont) && $eastAsianFont->getFontName() == $targetFont) ||
                (!java_is_null($complexScriptFont) && $complexScriptFont->getFontName() == $targetFont)) {
                $portion->getPortionFormat()->setKerningMinimalSize(100);
            }
        }
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

對於低於門檻的匹配文字，此設定會阻止字距微調，並有助於使 Aspose.Slides 的渲染與 PowerPoint 在受此 PowerPoint 特定行為影響的字型上保持視覺一致。

## **管理文字字型屬性**

字型屬性可透過 [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) 在段落層級設定，或透過 [PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/) 在個別部份設定。

以下範例將第一段落的預設字型設定為 12 點 Times New Roman，且加上粗體、斜體與點線底線。個別部份的明確格式會優先於這些預設值：

```php
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextUnderlineType;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $defaultPortionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
    $font = new FontData("Times New Roman");

    // 設定段落的字型屬性。
    $defaultPortionFormat->setFontHeight(12);
    $defaultPortionFormat->setFontBold(NullableBool::True);
    $defaultPortionFormat->setFontItalic(NullableBool::True);
    $defaultPortionFormat->setFontUnderline(TextUnderlineType::Dotted);
    $defaultPortionFormat->setLatinFont($font);

    $presentation->save("font_properties_for_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果：

![段落的字型屬性](font_properties_for_paragraph.png)

以下範例對所有有效格式為粗體的部份套用 13 點 Times New Roman、斜體與點線底線：

```php
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextUnderlineType;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $font = new FontData("Times New Roman");

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold())) {
            // 為文字部份設定字型屬性。
            $portionFormat = $portion->getPortionFormat();
            $portionFormat->setFontHeight(13);
            $portionFormat->setFontItalic(NullableBool::True);
            $portionFormat->setFontUnderline(TextUnderlineType::Dotted);
            $portionFormat->setLatinFont($font);
        }
    }

    $presentation->save("font_properties_for_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果：

![文字部份的字型屬性](font_properties_for_text_portions.png)

## **控制文字高度正規化**

使用 [BasePortionFormat::setNormaliseHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setNormaliseHeight) 以在重現範本排版或檢查字元高度差異時進行正規化。於 PowerPoint 中，啟用正規化會垂直拉伸或壓縮單一字元，使其在文字部份內具有一致的可見高度。它不保證不同字型之間的文字高度相等。

將此屬性設定為 [NullableBool::True or False](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/) 以明確啟用或停用正規化。`NullableBool::NotDefined` 會讓本地設定保持未定，讓部份繼承其值，例如從段落的 [getDefaultPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) 繼承。這不等同於 `False`。使用 [PortionFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/#getEffective) 並讀取返回的有效格式資料之 `getNormaliseHeight` 可取得解析後的布林值。

以下自行完整的範例需要安裝 **Arial**。它會建立兩個文字區塊，內容相同，包含大寫字母、小寫字母、下伸筆劃與帶重音字元，字型大小為 54 點。兩個段落預設皆啟用正規化。上方部份明確停用，下方部份則繼承設定。框架尺寸、邊距與段落間距相同，且停用換行與自動調整以保持比較一致。範例會印出 `False: false` 與 `NotDefined: true`，最後儲存為「text_height_normalization.pptx」：

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAnchorType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $settings = [NullableBool::False, NullableBool::NotDefined];
    $settingNames = ["False", "NotDefined"];

    for ($i = 0; $i < count($settings); $i++) {
        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 60 + $i * 200, 660, 150);
        $shape->getFillFormat()->setFillType(FillType::NoFill);
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

        $textFrame = $shape->getTextFrame();
        $textFrame->setText("Hxgjpq ÅÉ 0123");
        $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::None);
        $textFrame->getTextFrameFormat()->setWrapText(NullableBool::False);
        $textFrame->getTextFrameFormat()->setAnchoringType(TextAnchorType::Top);
        $textFrame->getTextFrameFormat()->setMarginTop(0);
        $textFrame->getTextFrameFormat()->setMarginLeft(0);

        $paragraph = $textFrame->getParagraphs()->get_Item(0);
        $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Left);
        $paragraph->getParagraphFormat()->setSpaceBefore(0);
        $paragraph->getParagraphFormat()->setSpaceAfter(0);
        $paragraph->getParagraphFormat()->setSpaceWithin(100);
        $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setNormaliseHeight(NullableBool::True);

        $portion = $paragraph->getPortions()->get_Item(0);
        $font = new FontData("Arial");
        $portion->getPortionFormat()->setLatinFont($font);
        $portion->getPortionFormat()->setFontHeight(54);
        $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
        $black = java("java.awt.Color")->BLACK;
        $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($black);
        $portion->getPortionFormat()->setNormaliseHeight($settings[$i]);

        $normaliseHeight = java_values($portion->getPortionFormat()->getEffective()->getNormaliseHeight());
        echo $settingNames[$i], ": ", $normaliseHeight ? "true" : "false", PHP_EOL;
    }

    $presentation->save("text_height_normalization.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

下圖是從儲存的簡報匯出。上排為正規化停用 (`False`)；下排繼承已啟用的設定 (`NotDefined` → `True`)。請保留安裝 Arial 以重現此外觀。

![Arial 54 點文字，上方正規化停用、下方繼承正規化啟用](text_height_normalization.png)

正規化會在不變更指派的 [getFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getFontHeight) 值（即字型大小）的情況下變更字元高度。段落的 [setSpaceWithin](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceWithin) 控制行距，而文字框的 [setAutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAutofitType) 控制文字或其容器如何調整以適應。這些設定各自用途不同，可能獨立影響整體版面。欲了解更多段落格式與繼承，請參閱 [管理段落](/slides/zh-hant/php-java/manage-paragraph/)。

## **套用與移除刪除線**

對文字部份使用 [BasePortionFormat::setStrikethroughType](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setStrikethroughType) 可顯示更正、取消的詞語或先前價格，而不必刪除原始文字。將其設為 [TextStrikethroughType::Single or Double](https://reference.aspose.com/slides/php-java/aspose.slides/textstrikethroughtype/) 可在文字上繪製單線或雙線刪除線。

若要移除刪除線，傳入 [TextStrikethroughType::None](https://reference.aspose.com/slides/php-java/aspose.slides/textstrikethroughtype/#None)。即使周圍的格式指定了刪除線，也會明確停用此效果。相較之下，[TextStrikethroughType::NotDefined](https://reference.aspose.com/slides/php-java/aspose.slides/textstrikethroughtype/#NotDefined) 會讓本地設定保持未定，使文字部份得以繼承例如段落的格式，並不保證刪除線被移除。使用 [PortionFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/#getEffective) 可讀取最終的格式，包括繼承值。

以下自行完整的範例建立三個價格比較。每個段落分別包含標籤、先前價格與目前價格的部份，僅先前價格會受影響。第一列先套用後移除刪除線；其餘列則分別保留單線與雙線刪除線。變更此設定可在保留文字及其他格式（如粗體先前價格）的前提下，呈現不同的刪除線效果：

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextStrikethroughType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 620, 220);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getTextFrame()->getParagraphs()->clear();

    $labels = [ "None: ", "Single: ", "Double: " ];

    foreach ($labels as $label) {
        $paragraph = new Paragraph();
        $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Left);
        $paragraph->getParagraphFormat()->setSpaceAfter(20);

        $format = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
        $format->setFontHeight(28);
        $font = new FontData("Arial");
        $format->setLatinFont($font);
        $format->getFillFormat()->setFillType(FillType::Solid);
        $blackColor = java("java.awt.Color")->BLACK;
        $format->getFillFormat()->getSolidFillColor()->setColor($blackColor);

        $labelPortion = new Portion($label);
        $paragraph->getPortions()->add($labelPortion);

        $previousPrice = new Portion("$100");
        $previousPrice->getPortionFormat()->setFontBold(NullableBool::True);
        $paragraph->getPortions()->add($previousPrice);
        $currentPrice = new Portion(" → $80");
        $paragraph->getPortions()->add($currentPrice);

        $shape->getTextFrame()->getParagraphs()->add($paragraph);
    }

    $paragraphs = $shape->getTextFrame()->getParagraphs();

    // 套用刪除線，然後明確地從第一個先前價格中移除它。
    $paragraphs->get_Item(0)->getPortions()->get_Item(1)->getPortionFormat()->setStrikethroughType(TextStrikethroughType::Single);
    $paragraphs->get_Item(0)->getPortions()->get_Item(1)->getPortionFormat()->setStrikethroughType(TextStrikethroughType::None);

    $paragraphs->get_Item(1)->getPortions()->get_Item(1)->getPortionFormat()->setStrikethroughType(TextStrikethroughType::Single);
    $paragraphs->get_Item(2)->getPortions()->get_Item(1)->getPortionFormat()->setStrikethroughType(TextStrikethroughType::Double);

    $presentation->save("strikethrough.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果（由上至下）：無刪除線、單線刪除線、雙線刪除線。

![先前價格分別為無刪除線、單線刪除線與雙線刪除線的比較圖](strikethrough.png)

## **設定文字旋轉**

使用 [TextFrameFormat::setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setTextVerticalType) 以在圖形內設定預定義的文字方向。

以下程式碼範例將圖形內的文字方向設定為 [TextVerticalType::Vertical270](https://reference.aspose.com/slides/php-java/aspose.slides/textverticaltype/)，此方向會將文字 **逆時針旋轉 90 度**：

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextVerticalType;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $autoShape->getTextFrame()->getTextFrameFormat()->setTextVerticalType(TextVerticalType::Vertical270);

    $presentation->save("text_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果：

![文字旋轉示意圖](text_rotation.png)

## **在垂直文字中將數字並排顯示**

若要在垂直的日文標籤中保持兩位數字並排，請將兩個數字放在同一個文字部份，並對該部份呼叫 [BasePortionFormat::setKumimoji](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setKumimoji)。範例使用 [TextVerticalType::EastAsianVertical](https://reference.aspose.com/slides/php-java/aspose.slides/textverticaltype/#EastAsianVertical) 與 40 點 MS Gothic 於兩個標籤。唯一不同的是傳入數字部份的 [NullableBool](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/) 值。

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextVerticalType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $x = 120;

    foreach ([NullableBool::True, NullableBool::False] as $kumimoji) {
        $label = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $x, 48, 120, 420);
        $label->getFillFormat()->setFillType(FillType::NoFill);
        $label->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

        $frame = $label->addTextFrame("");
        $frame->getTextFrameFormat()->setTextVerticalType(TextVerticalType::EastAsianVertical);

        $paragraph = $frame->getParagraphs()->get_Item(0);
        $format = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
        $font = new FontData("MS Gothic");
        $format->setLatinFont($font);
        $format->setEastAsianFont($font);
        $format->setFontHeight(40);
        $format->getFillFormat()->setFillType(FillType::Solid);
        $black = java("java.awt.Color")->BLACK;
        $format->getFillFormat()->getSolidFillColor()->setColor($black);

        $digits = new Portion("12");
        $digits->getPortionFormat()->setKumimoji($kumimoji);

        $portions = $paragraph->getPortions();
        $portions->clear();
        $portions->add(new Portion("令和"));
        $portions->add($digits);
        $portions->add(new Portion("年"));

        $x += 240;
    }
    $presentation->save("vertical_date.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

在 PowerPoint 中，左側標籤 (`True`) 會使數字直立且與「和」與「年」之間並排顯示；右側標籤 (`False`) 則會將整組數字順時針旋轉 90 度。兩側的日文字元仍保持直立。

![PowerPoint 中垂直日期標籤的比較：左側數字直立，右側數字旋轉](vertical_date.png)

## **設定文字框的自訂旋轉**

使用 [TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setRotationAngle) 以為 [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) 設定自訂旋轉角度。

以下程式碼範例於圖形內將文字框順時針旋轉 3 度：

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $autoShape->getTextFrame()->getTextFrameFormat()->setRotationAngle(3);

    $presentation->save("custom_text_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果：

![自訂文字旋轉示意圖](custom_text_rotation.png)

## **設定段落的行距**

Aspose.Slides 提供 [ParagraphFormat::setSpaceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceAfter)、[ParagraphFormat::setSpaceBefore](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceBefore) 與 [ParagraphFormat::setSpaceWithin](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceWithin) 以控制段落間距。這些屬性的使用方式如下：

* 使用正值以段落高度的百分比指定行距。
* 使用負值以點數指定行距。

以下範例將第一段落的內部間距設為行高的 200%（即雙倍行距）：

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getParagraphFormat()->setSpaceWithin(200);

    $presentation->save("line_spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果：

![段落內的行距](line_spacing.png)

## **控制換行規則**

段落換行規則在窄文字區塊與混合拉丁與東亞文字的簡報中相當有用。以下方法屬於 [ParagraphFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/)，因此會套用於整個段落：

- [setLatinLineBreak](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setLatinLineBreak) 控制拉丁文字的換行規則。在混合文字中變更此設定亦可能影響相鄰的東亞文字與標點的換行位置。
- [setEastAsianLineBreak](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) 控制東亞文字的換行規則，包括行首與行尾字元的限制。

這些規則不會取代 [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setWrapText)，後者會在文字框內啟用自動換行。它們僅在換行發生時影響版面配置，並不會插入換行字元。明確的換行字元會強制在段落內另起新行，與可用寬度無關。

以下自行完整的範例建立一個包含中文與拉丁文字的窄文字區塊。它同時明確設定兩項換行選項，並儲存為「line_breaking.pptx」。若要實驗任一規則，只需在保持另一設定不變的情況下變更對應值。範例使用 24 點 Arial 與 SimSun，框寬 160 點，水平文字框邊距為 0。呼叫 [TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAutofitType) 並設定為 [TextAutofitType::None](https://reference.aspose.com/slides/php-java/aspose.slides/textautofittype/)，以固定文字大小與框架尺寸：

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 160, 300);
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setWrapText(NullableBool::True);
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::None);
    $textFrame->getTextFrameFormat()->setMarginLeft(0);
    $textFrame->getTextFrameFormat()->setMarginRight(0);

    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $paragraph->setText("中文排版测试，PowerPoint 中文演示。");

    $format = $paragraph->getParagraphFormat();
    $format->setAlignment(TextAlignment::Left);
    $format->getDefaultPortionFormat()->setFontHeight(24);
    $latinFont = new FontData("Arial");
    $format->getDefaultPortionFormat()->setLatinFont($latinFont);
    $eastAsianFont = new FontData("SimSun");
    $format->getDefaultPortionFormat()->setEastAsianFont($eastAsianFont);
    $format->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $blackColor = java("java.awt.Color")->BLACK;
    $format->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($blackColor);
    $format->setLatinLineBreak(NullableBool::False);
    $format->setEastAsianLineBreak(NullableBool::True);

    $presentation->save("line_breaking.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **控制懸掛標點**

[ParagraphFormat::setHangingPunctuation](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setHangingPunctuation) 允許符合條件的標點延伸至文字行右邊緣之外，而不是佔用下一行。它作用於整個段落，且不同於懸掛縮排。

以下自行完整的範例在寬度為 100 點的文字框內啟用懸掛標點，並儲存為「hanging_punctuation.pptx」。使用 24 點 Arial 與水平文字框邊距為 0，最終的句點會保留在「sentence」之後，並延伸至右側文字邊緣。若將屬性設為 [NullableBool::False](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/)，則句點會佔據獨立一行，以作比較。此範例同時啟用換行且停用自動調整，以固定可用寬度。

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 100, 200);
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setWrapText(NullableBool::True);
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::None);
    $textFrame->getTextFrameFormat()->setMarginLeft(0);
    $textFrame->getTextFrameFormat()->setMarginRight(0);

    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $paragraph->setText("Simple text, next sentence.");

    $format = $paragraph->getParagraphFormat();
    $format->setAlignment(TextAlignment::Left);
    $format->getDefaultPortionFormat()->setFontHeight(24);
    $latinFont = new FontData("Arial");
    $format->getDefaultPortionFormat()->setLatinFont($latinFont);
    $format->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $blackColor = java("java.awt.Color")->BLACK;
    $format->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($blackColor);
    $format->setHangingPunctuation(NullableBool::True);

    $presentation->save("hanging_punctuation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

並非所有標點皆能懸掛。上述 [控制換行規則](#control-line-breaking) 中提及的字型與版面條件同樣適用於此比較：變更字型、可用寬度、邊距或自動調整設定皆可能消除可見差異。

## **設定文字框的自動調整類型**

[TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAutofitType) 決定文字超出容器邊界時的行為。可用於控制文字是縮小、溢出，或自動調整圖形大小以容納文字。以下範例將圖形設定為自動調整以適應文字，並將結果儲存為「autofit_type.pptx」：

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAutofitType;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $autoShape->getTextFrame()->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);

    $presentation->save("autofit_type.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

若要在自動換行後計算行數並查看文字或圖形寬度變化對結果的影響，請參閱 [計算呈現行數](/slides/zh-hant/php-java/manage-paragraph/)。僅行數並不足以判斷文字是否溢出容器。

## **設定文字框的錨點**

[TextFrameFormat::setAnchoringType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAnchoringType) 定義文字在圖形內的垂直定位方式，例如置頂、置中或置底。以下範例將文字錨點設為第一個圖形的底部，並將結果儲存為「text_anchor.pptx」：

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAnchorType;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $autoShape->getTextFrame()->getTextFrameFormat()->setAnchoringType(TextAnchorType::Bottom);

    $presentation->save("text_anchor.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **設定文字定位點 (Tabulation)**

使用 [ParagraphFormat::setDefaultTabSize](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setDefaultTabSize) 與 [ParagraphFormat::getTabs](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getTabs) 以配置段落中的定位點。以下範例將預設定位間距設為 100 點，並在 30 點處新增左對齊的定位點。這些設定會影響包含定位字元的文字。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TabAlignment;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getParagraphFormat()->setDefaultTabSize(100);
    $paragraph->getParagraphFormat()->getTabs()->add(30, TabAlignment::Left);

    $presentation->save("paragraph_tabs.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果：

![段落定位點示意圖](paragraph_tabs.png)

## **設定校對語言**

Aspose.Slides 提供 [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId)，可為文字部份設定校對語言。校對語言決定 PowerPoint 在拼寫與文法檢查時使用的語言。

以下範例需「presentation.pptx」且第一張投影片的第一個圖形為文字方塊，且至少包含一個段落。它會將第一段落的內容取代為「1。」、將字型設定為 SimSun，並指定簡體中文校對語言 (`zh-CN`)。最後將結果儲存為「proofing_language.pptx」：

```php
use aspose\slides\FontData;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $font = new FontData("SimSun");

    $textPortion = new Portion();
    $textPortion->getPortionFormat()->setComplexScriptFont($font);
    $textPortion->getPortionFormat()->setEastAsianFont($font);
    $textPortion->getPortionFormat()->setLatinFont($font);

    // 設定校對語言的 ID。
    $textPortion->getPortionFormat()->setLanguageId("zh-CN");

    $textPortion->setText("1。");
    $paragraph->getPortions()->add($textPortion);

    $presentation->save("proofing_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **複製語言中繼資料**

在從範本複製多語言文字時，需保留 [BasePortionFormat::getLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getLanguageId) 與 [BasePortionFormat::getAlternativeLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getAlternativeLanguageId)。以下自行完整的範例會建立一個來源部份，其語言為美式英語，替代語言為法語，並將文字與識別碼複製至新簡報中的部份：

```php
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$source = new Portion("Hello! Bonjour!");
$source->getPortionFormat()->setLanguageId("en-US");
$source->getPortionFormat()->setAlternativeLanguageId("fr-FR");

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 80);
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $destination = new Portion();
    $destination->setText($source->getText());
    $destination->getPortionFormat()->setLanguageId($source->getPortionFormat()->getLanguageId());
    // 如果來源沒有替代語言，null 會清除目的端的值。
    $destination->getPortionFormat()->setAlternativeLanguageId($source->getPortionFormat()->getAlternativeLanguageId());
    $paragraph->getPortions()->add($destination);

    $presentation->save("copied_language_metadata.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

若要測試沒有替代語言的來源，只需省略 `"fr-FR"` 的指派。此時替代識別碼為 `null`，相同的複製語句會保留其缺失而不會引入預設值，即使目標之前已指派替代語言。

這些識別碼屬於語言中繼資料。保留它們不會決定 PowerPoint 為拼寫或文法檢查所選擇的字典。

## **設定預設語言**

使用 [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) 定義載入或建立簡報時所產生文字的預設語言。以下範例建立一個簡報，將預設文字語言設為美式英語，新增一個文字方塊，並輸出其第一個文字部份的語言為 `en-US`：

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$loadOptions = new LoadOptions();
$loadOptions->setDefaultTextLanguage("en-US");

$presentation = new Presentation($loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // 新增一個帶文字的矩形圖形。
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 50);
    $shape->getTextFrame()->setText("Sample text");

    // 檢查第一個文字部份的語言。
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    echo $portion->getPortionFormat()->getLanguageId();
} finally {
    $presentation->dispose();
}
```

## **設定預設文字樣式**

若要在簡報層級套用預設文字格式，請使用 [Presentation::getDefaultTextStyle](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getDefaultTextStyle)。

以下範例將新簡報中最高層級段落的預設字型設為 14 點粗體，並將之儲存為「default_text_style.pptx」。文字會繼承這些預設，除非更具體的格式覆寫它們。

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    // 取得最高層級的段落格式。
    $paragraphFormat = $presentation->getDefaultTextStyle()->getLevel(0);

    if (!java_is_null($paragraphFormat)) {
        $paragraphFormat->getDefaultPortionFormat()->setFontHeight(14);
        $paragraphFormat->getDefaultPortionFormat()->setFontBold(NullableBool::True);
    }

    $presentation->save("default_text_style.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **擷取帶全大寫效果的文字**

在 PowerPoint 中，套用 **全大寫** 字型效果會讓文字在投影片上顯示為大寫，即使原始輸入是小寫。使用 Aspose.Slides 取得此類文字部份時，函式庫會返回原始輸入的文字。若要與顯示的文字相符，請檢查 [TextCapType](https://reference.aspose.com/slides/php-java/aspose.slides/textcaptype/) 並在其值為 `All` 時將返回的字串轉換為大寫。

此範例需要「sample2.pptx」且第一張投影片的第一個圖形為文字方塊。其第一段落的第一部份包含「Hello, Aspose!」，並套用了全大寫效果，如下圖所示。

![全大寫效果示意圖](all_caps_effect.png)

以下程式碼示範如何擷取套用 **全大寫** 效果的文字：

```php
use aspose\slides\Presentation;
use aspose\slides\TextCapType;

$presentation = new Presentation("sample2.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $autoShape = $slide->getShapes()->get_Item(0);
    $textPortion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);

    $originalText = $textPortion->getText();
    echo "Original text: ", $originalText, "\n";

    $textFormat = $textPortion->getPortionFormat()->getEffective();
    if (java_values($textFormat->getTextCapType()) === TextCapType::All) {
        $text = strtoupper($originalText);
        echo "All-Caps effect: ", $text, "\n";
    }
} finally {
    $presentation->dispose();
}
```

輸出：

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **常見問題集**

**如何修改投影片中表格的文字？**

要修改投影片中表格的文字，請使用 [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/)。遍歷儲存格，透過 [Cell::getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/cell/#getTextFrame) 取得文字框，並使用 [Paragraph::getParagraphFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getParagraphFormat) 調整段落格式。

**如何在 PowerPoint 投影片的文字上套用漸層顏色？**

要套用漸層顏色，請使用 [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getFillFormat)。將 [FillFormat::setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#setFillType) 設為 [FillType::Gradient](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/)，並配置漸層停止點、方向與透明度。