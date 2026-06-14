---
title: 在 PHP 中格式化簡報文字
linktitle: 文字格式化
type: docs
weight: 50
url: /zh-hant/php-java/text-formatting/
keywords:
- 突顯文字
- 正則表達式
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
- 自動適應屬性
- 文字框錨點
- 文字定位點
- 預設語言
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "在 PowerPoint 與 OpenDocument 簡報中使用 Aspose.Slides for PHP via Java 進行文字的格式化與樣式設定。自訂字型、顏色、對齊等。"
---
## **概述**

本文說明如何使用 Aspose.Slides for PHP via Java 於 PowerPoint 與 OpenDocument 簡報中格式化文字。內容涵蓋文字突顯、背景色彩、透明度、字元間距、字型屬性、旋轉、段落間距、自動適應行為、文字錨點、定位點以及語言設定。

在以下範例中，我們將使用名為「sample.pptx」的檔案，該檔案在第一張投影片上包含一個文字方塊，文字內容如下：

![範例文字](sample_text.png)

## **突顯文字**

當需要在文字方塊中突顯符合特定樣本的文字時，使用 [TextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/)`::highlightText` 方法。此方法會為符合的文字片段套用突顯顏色，並可搭配 [TextHighlightingOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/texthighlightingoptions/) 以控制搜尋方式，例如僅匹配完整單字。

以下程式碼範例先突顯所有 **"try"** 字元，接著僅突顯完整單字 **"to"**。

```php
$presentation = new Presentation("sample.pptx");
try {
    // 取得第一張投影片中的第一個形狀。
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $lightBlue = new Java("java.awt.Color", 173, 216, 230);
    $violet = new Java("java.awt.Color", 238, 130, 238);

    // 將形狀中的單字 "try" 突顯。
    $shape->getTextFrame()->highlightText("try", $lightBlue);

    $searchOptions = new TextHighlightingOptions();
    $searchOptions->setWholeWordsOnly(true);

    // 將形狀中的單字 "to" 突顯。
    $shape->getTextFrame()->highlightText("to", $violet, $searchOptions);

    $presentation->save("highlighted_text.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果：

![已突顯的文字](highlighted_text.png)

### **使用正則表達式突顯文字**

[TextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/)`::highlightRegex` 方法會突顯正則表達式找到的文字匹配項。

以下程式碼範例突顯所有包含 **七個或以上字元** 的單字：

```php
$presentation = new Presentation("sample.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // 突顯所有包含七個或以上字元的單字。
    $shape->getTextFrame()->highlightRegex("\\b[^\\s]{7,}\\b", java("java.awt.Color")->YELLOW, null);

    $presentation->save("highlighted_text_using_regex.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果：

![使用正則表達式突顯的文字](highlighted_text_using_regex.png)

## **設定文字背景色彩**

使用 [ParagraphFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/) 的預設段落格式設定段落的預設突顯顏色，或使用 [PortionFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/portionformat/) 為單一文字片段設定。

下列程式碼範例示範如何為 **整段文字** 設定背景色彩：

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // 設定整段文字的突顯顏色。
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getHighlightColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);

    $presentation->save("gray_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果：

![灰色段落](gray_paragraph.png)

以下程式碼範例示範如何為 **粗體字的文字片段** 設定背景色彩：

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // 為文字片段設定突顯顏色。
            $portion->getPortionFormat()->getHighlightColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
        }
    }

    $presentation->save("gray_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果：

![灰色文字片段](gray_text_portions.png)

## **對齊文字段落**

使用 [ParagraphFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/)`::setAlignment` 方法可設定文字方塊內段落的對齊方式，支援置中、左對齊、右對齊、兩端對齊等。

下列程式碼範例示範如何將段落置中對齊：

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // 設定段落的對齊方式為置中。
    $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Center);

    $presentation->save("aligned_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果：

![對齊的段落](aligned_paragraph.png)

## **設定文字透明度**

文字透明度透過指派給 [PortionFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/portionformat/) 填充格式的顏色的 Alpha 成分來控制。以下範例中的 `alpha = 50` 為 ARGB 透明度值，範圍 0-255，非百分比。

以下程式碼範例示範如何為 **整段文字** 套用透明度：

```php
$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $fillFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat();

    // 設定文字的填色為透明顏色。
    $fillFormat->setFillType(FillType::Solid);
    $fillFormat->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 0, 0, $alpha));

    $presentation->save("transparent_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果：

![透明段落](transparent_paragraph.png)

以下程式碼範例示範如何為 **粗體字的文字片段** 套用透明度：

```php
$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // 設定文字片段的透明度。
            $fillFormat = $portion->getPortionFormat()->getFillFormat();
            $fillFormat->setFillType(FillType::Solid);
            $fillFormat->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 0, 0, $alpha));
        }
    }

    $presentation->save("transparent_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果：

![透明的文字片段](transparent_text_portions.png)

## **設定文字字距**

使用 [BasePortionFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseportionformat/)`::setSpacing` 方法可在文字方塊中擴大或縮小字元間距。

以下 PHP 程式碼示範如何為 **整段文字** 展開字距：

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // 注意：使用負值來壓縮字元間距。
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(3); // 展開字元間距。

    $presentation->save("character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果：

![段落中的字距](character_spacing_in_paragraph.png)

以下程式碼範例示範如何為 **粗體字的文字片段** 展開字距：

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // 注意：使用負值來壓縮字元間距。
            $portion->getPortionFormat()->setSpacing(3); // 展開字元間距。
        }
    }

    $presentation->save("character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果：

![文字片段中的字距](character_spacing_in_text_portions.png)

### **停用特定字型的字距調整**

在某些情況下，Aspose.Slides 所渲染的文字看起來會比 PowerPoint 中的相同文字稍微緊湊。這可能是因為 PowerPoint 在某些字型上會忽略字距調整資料，即使該字型包含有效的字距資訊且在 PowerPoint 設定中已啟用字距調整。

若要使渲染結果更接近 PowerPoint，可對使用受影響字型的文字片段停用字距調整。將 [BasePortionFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseportionformat/)`::setKerningMinimalSize` 方法設定為遠大於實際字型大小的值：

```php
$presentation = new Presentation("presentation.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $targetFont = "Roboto";

    $paragraphCount = java_values($autoShape->getTextFrame()->getParagraphs()->getCount());
    for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
        $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item($paragraphIndex);
        $portionCount = java_values($paragraph->getPortions()->getCount());
        for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
            $portion = $paragraph->getPortions()->get_Item($portionIndex);
            $portionFormat = $portion->getPortionFormat();
            $latinFont = $portionFormat->getLatinFont();
            $eastAsianFont = $portionFormat->getEastAsianFont();
            $complexScriptFont = $portionFormat->getComplexScriptFont();

            if ((!java_is_null($latinFont) && $latinFont->getFontName() == $targetFont) ||
                (!java_is_null($eastAsianFont) && $eastAsianFont->getFontName() == $targetFont) ||
                (!java_is_null($complexScriptFont) && $complexScriptFont->getFontName() == $targetFont)) {
                $portionFormat->setKerningMinimalSize(100);
            }
        }
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

此設定會阻止對符合條件的文字片段套用字距調整，協助 Aspose.Slides 的渲染與受 PowerPoint 特定行為影響的字型的視覺輸出更為一致。

## **管理文字字型屬性**

字型屬性可透過 [ParagraphFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/) 的預設段落格式設定，或透過 [PortionFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/portionformat/) 為單一片段設定。

以下程式碼為整段文字設定字型與文字樣式：包括字型大小、粗體、斜體、點狀底線，以及 Times New Roman 字型。

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $defaultPortionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();

    // 設定段落的字型屬性。
    $defaultPortionFormat->setFontHeight(12);
    $defaultPortionFormat->setFontBold(NullableBool::True);
    $defaultPortionFormat->setFontItalic(NullableBool::True);
    $defaultPortionFormat->setFontUnderline(TextUnderlineType::Dotted);
    $defaultPortionFormat->setLatinFont(new FontData("Times New Roman"));

    $presentation->save("font_properties_for_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果：

![段落的字型屬性](font_properties_for_paragraph.png)

以下程式碼範例將類似的屬性套用於 **粗體字的文字片段**：

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // 為文字片段設定字型屬性。
            $portionFormat = $portion->getPortionFormat();
            $portionFormat->setFontHeight(13);
            $portionFormat->setFontItalic(NullableBool::True);
            $portionFormat->setFontUnderline(TextUnderlineType::Dotted);
            $portionFormat->setLatinFont(new FontData("Times New Roman"));
        }
    }

    $presentation->save("font_properties_for_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果：

![文字片段的字型屬性](font_properties_for_text_portions.png)

## **設定文字旋轉**

使用 [TextFrameFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframeformat/)`::setTextVerticalType` 方法可在形狀內設定預定義的文字方向。

以下程式碼範例將形狀內的文字方向設定為 `Vertical270`，使文字 **逆時針旋轉 90 度**：

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setTextVerticalType(TextVerticalType::Vertical270);

    $presentation->save("text_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果：

![文字旋轉](text_rotation.png)

## **為文字框設定自訂旋轉**

使用 [TextFrameFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframeformat/)`::setRotationAngle` 方法可為 [TextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/) 設定自訂旋轉角度。

以下程式碼範例在形狀內將文字框順時針旋轉 3 度：

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setRotationAngle(3);

    $presentation->save("custom_text_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果：

![自訂文字旋轉](custom_text_rotation.png)

## **設定段落行距**

Aspose.Slides 提供 [ParagraphFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/)`::setSpaceAfter`、`ParagraphFormat::setSpaceBefore` 與 `ParagraphFormat::setSpaceWithin` 方法以控制段落間距。使用方式如下：

* 正值表示以行高的百分比指定行距。
* 負值則以點數指定行距。

以下程式碼範例示範如何在段落內指定行距：

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $paragraph->getParagraphFormat()->setSpaceWithin(200);

    $presentation->save("line_spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果：

![段落內的行距](line_spacing.png)

## **設定文字框的自動適應類型**

[TextFrameFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframeformat/)`::setAutofitType` 方法決定文字超出容器邊界時的行為。使用此方法可控制文字是縮小、溢出，或自動調整形狀大小。

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);

    $presentation->save("autofit_type.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **設定文字框的錨點**

[TextFrameFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframeformat/)`::setAnchoringType` 方法定義文字在形狀內的垂直位置，例如置頂、置中或置底。

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setAnchoringType(TextAnchorType::Bottom);

    $presentation->save("text_anchor.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **設定文字定位點**

使用 [ParagraphFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/)`::setDefaultTabSize` 方法及其 tabs 集合，可在段落中設定定位點。

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $paragraph->getParagraphFormat()->setDefaultTabSize(100);
    $paragraph->getParagraphFormat()->getTabs()->add(30, TabAlignment::Left);

    $presentation->save("paragraph_tabs.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果：

![段落定位點](paragraph_tabs.png)

## **設定校對語言**

Aspose.Slides 提供 [BasePortionFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseportionformat/)`::setLanguageId` 方法，可為文字片段設定校對語言。校對語言決定 PowerPoint 在拼寫和文法檢查時使用的語言。

以下程式碼範例示範如何為文字片段設定校對語言：

```php
$presentation = new Presentation("presentation.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $font = new FontData("SimSun");

    $textPortion = new Portion();
    $textPortion->getPortionFormat()->setComplexScriptFont($font);
    $textPortion->getPortionFormat()->setEastAsianFont($font);
    $textPortion->getPortionFormat()->setLatinFont($font);

    // 設定校對語言的 ID。
    $textPortion->getPortionFormat()->setLanguageId("zh-CN");

    $textPortion->setText("1.");
    $paragraph->getPortions()->add($textPortion);

    $presentation->save("proofing_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **設定預設語言**

使用 [LoadOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/loadoptions/)`::setDefaultTextLanguage` 方法，可為載入或建立簡報時產生的文字定義預設語言。

```php
$loadOptions = new LoadOptions();
$loadOptions->setDefaultTextLanguage("en-US");

$presentation = new Presentation($loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // 新增一個帶文字的矩形形狀。
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 50);
    $shape->getTextFrame()->setText("Sample text");

    // 檢查第一個文字片段的語言。
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    echo $portion->getPortionFormat()->getLanguageId();
} finally {
    $presentation->dispose();
}
```

## **設定預設文字樣式**

若要在簡報層級套用預設文字格式，請使用 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 的預設文字樣式。

以下程式碼範例示範如何在新簡報中為所有投影片的文字設定預設粗體、14 點大小的字型。

```php
$presentation = new Presentation();
try {
    // 取得頂層段落格式。
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

## **擷取全大寫效果的文字**

在 PowerPoint 中，套用 **All Caps** 字型效果後，即使原始文字是小寫，投影片上仍會顯示為大寫。使用 Aspose.Slides 取得此類文字片段時，函式庫會回傳原始輸入的文字。若要與畫面顯示的文字相符，請檢查 [TextCapType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textcaptype/) 並在值為 `All` 時將回傳字串轉為大寫。

假設我們在 sample2.pptx 檔案的第一張投影片上有下列文字方塊。

![全大寫效果](all_caps_effect.png)

以下程式碼範例示範如何擷取套用 **All Caps** 效果的文字：

```php
$presentation = new Presentation("sample2.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $textPortion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);

    echo "Original text: ", $textPortion->getText(), "\n";

    $textFormat = $textPortion->getPortionFormat()->getEffective();
    if (java_values($textFormat->getTextCapType()) === TextCapType::All) {
        $text = strtoupper($textPortion->getText());
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

## **常見問題**

**如何在投影片的表格中修改文字？**

要在投影片的表格中修改文字，請使用 [Table](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/table/)。遍歷儲存格，並透過 [Cell](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/cell/) 的文字方塊以及 [Paragraph](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraph/) 的段落格式進行更新。

**如何在 PowerPoint 投影片的文字套用漸層顏色？**

要為文字套用漸層顏色，請使用 [PortionFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/portionformat/) 的填充格式。將 [FillFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fillformat/) 的填充類型設定為 [FillType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/filltype/) `Gradient`，並配置漸層定位點、方向與透明度。