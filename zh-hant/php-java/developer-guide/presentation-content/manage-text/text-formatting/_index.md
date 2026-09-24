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
- 字型系列
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
description: "使用 Aspose.Slides for PHP via Java 在 PowerPoint 和 OpenDocument 簡報中格式化與造型文字。自訂字型、顏色、對齊方式等更多設定。"
---
## **概觀**

本文說明如何使用 Aspose.Slides for PHP via Java 在 PowerPoint 與 OpenDocument 簡報中格式化文字。內容涵蓋背景色、透明度、字元間距、字型屬性、旋轉、段落間距、自動調整行為、文字錨點、定位點以及語言設定。

在以下範例中，我們將使用名為「sample.pptx」的檔案，該檔案在第一張投影片的文字方塊內含有以下文字：

![範例文字](sample_text.png)

若要搜尋並標示純文字或正規表達式匹配項目，請參閱 [搜尋與取代文字](/slides/zh-hant/php-java/search-and-replace-text/)。

## **設定文字背景色彩**

使用 [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) 設定段落的預設突顯色彩，或使用 [BasePortionFormat::getHighlightColor](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseportionformat/#getHighlightColor) 為單一文字片段設定。

以下程式碼示範如何設定 **整個段落** 的背景色彩：

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $highlightColor = java("java.awt.Color")->LIGHT_GRAY;

    // 為整個段落設定突顯顏色。
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getHighlightColor()->setColor($highlightColor);

    $presentation->save("gray_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果：

![灰色段落](gray_paragraph.png)

以下程式碼示範如何為 **粗體字型的文字片段** 設定背景色彩：

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $highlightColor = java("java.awt.Color")->LIGHT_GRAY;

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // 設定文字片段的突顯顏色。
            $portion->getPortionFormat()->getHighlightColor()->setColor($highlightColor);
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

使用 [ParagraphFormat::setAlignment](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/#setAlignment) 設定文字框內段落的對齊方式。可設定為置中、左對齊、右對齊、兩端對齊等。

以下程式碼示範如何將段落 **置中**：

```php
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

![已對齊的段落](aligned_paragraph.png)

## **設定文字透明度**

文字透明度透過指派給 [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseportionformat/#getFillFormat) 的顏色之 alpha 成分來控制。以下範例中，`alpha = 50` 為 0–255 之間的 ARGB alpha 通道值，並非透明度百分比。

以下程式碼示範如何對 **整個段落** 套用透明度：

```php
$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $fillFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat();

    // 設定文字的填充顏色為透明顏色。
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

以下程式碼示範如何對 **粗體字型的文字片段** 套用透明度：

```php
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
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // 設定文字片段的透明度。
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

![透明文字片段](transparent_text_portions.png)

## **設定文字字元間距**

使用 [BasePortionFormat::setSpacing](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseportionformat/#setSpacing) 可在文字方塊內擴大或縮小字元之間的間距。

以下 PHP 程式碼示範如何在 **整個段落** 中擴大字元間距：

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // 注意：使用負值可壓縮字元間距。
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(3); // 展開字元間距。

    $presentation->save("character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果：

![段落中的字元間距](character_spacing_in_paragraph.png)

以下程式碼示範如何在 **粗體字型的文字片段** 中擴大字元間距：

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // 注意：使用負值可壓縮字元間距。
            $portion->getPortionFormat()->setSpacing(3); // 展開字元間距。
        }
    }

    $presentation->save("character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果：

![文字片段中的字元間距](character_spacing_in_text_portions.png)

### **停用特定字型的字距調整（Kerning）**

在某些情況下，Aspose.Slides 渲染的文字可能較 PowerPoint 顯示的文字稍微緊密。這可能是因為 PowerPoint 會忽略特定字型的字距調整資料，即使該字型本身包含有效的字距調整資訊且在 PowerPoint 設定中已啟用。

若要讓渲染結果更接近 PowerPoint，可對使用受影響字型的文字片段停用字距調整。將 [BasePortionFormat::setKerningMinimalSize](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseportionformat/#setKerningMinimalSize) 設為遠大於實際字型大小的值：

```php
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

此設定會阻止對匹配的文字片段套用字距調整，協助 Aspose.Slides 的渲染與 PowerPoint 在受此 PowerPoint 特定行為影響的字型上保持一致。

## **管理文字字型屬性**

可透過 [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) 在段落層級設定字型屬性，或透過 [PortionFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/portionformat/) 在單一文字片段設定。

以下程式碼為整個段落設定字型與文字樣式：套用字型大小、粗體、斜體、點線底線，以及 Times New Roman 字型至段落中的所有片段。

```php
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

以下程式碼為 **粗體字型的文字片段** 套用類似屬性：

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $font = new FontData("Times New Roman");

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // 設定文字片段的字型屬性。
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

![文字片段的字型屬性](font_properties_for_text_portions.png)

## **設定文字旋轉**

使用 [TextFrameFormat::setTextVerticalType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframeformat/#setTextVerticalType) 可在圖形內設定預設的文字方向。

以下程式碼將圖形內的文字方向設定為 `Vertical270`，即將文字 **逆時針旋轉 90 度**：

```php
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

![文字旋轉](text_rotation.png)

## **設定文字方塊的自訂旋轉角度**

使用 [TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframeformat/#setRotationAngle) 可為 [TextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/) 設定自訂旋轉角度。

以下程式碼在圖形內將文字方塊順時針旋轉 3 度：

```php
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

![自訂文字旋轉](custom_text_rotation.png)

## **設定段落的行距**

Aspose.Slides 提供 [ParagraphFormat::setSpaceAfter](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/#setSpaceAfter)、[ParagraphFormat::setSpaceBefore](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/#setSpaceBefore) 與 [ParagraphFormat::setSpaceWithin](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/#setSpaceWithin) 以控制段落間距。這些屬性的使用方式如下：

* 使用正值可將行距指定為行高的百分比。
* 使用負值可將行距指定為點數。

以下程式碼示範如何在段落內指定行距：

```php
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

## **設定文字方塊的自動調整類型**

[TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframeformat/#setAutofitType) 決定文字超出容器邊界時的行為。可用來控制文字是縮小、溢出，或自動調整圖形大小。

```php
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

若要在自動換行後計算行數並觀察文字或圖形寬度變化，請參閱 [計算已渲染的行數](/slides/zh-hant/php-java/manage-paragraph/)。僅行數並無法說明文字是否溢出容器。

## **設定文字方塊的錨點**

[TextFrameFormat::setAnchoringType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframeformat/#setAnchoringType) 定義文字在圖形內的垂直定位方式，例如置頂、置中或置底。

```php
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

## **設定文字定位點（Tab）**

使用 [ParagraphFormat::setDefaultTabSize](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/#setDefaultTabSize) 與 [ParagraphFormat::getTabs](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/#getTabs) 來配置段落的定位點。

```php
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

![段落的定位點](paragraph_tabs.png)

## **設定校對語言**

Aspose.Slides 提供 [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseportionformat/#setLanguageId)，可為文字片段設定校對語言。校對語言決定 PowerPoint 在拼寫與文法檢查時使用的語言。

以下程式碼示範如何為文字片段設定校對語言：

```php
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

    // 設定校對語言的 Id。
    $textPortion->getPortionFormat()->setLanguageId("zh-CN");

    $textPortion->setText("1。");
    $paragraph->getPortions()->add($textPortion);

    $presentation->save("proofing_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **設定預設語言**

使用 [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) 來定義載入或建立簡報時所建立文字的預設語言。

```php
$loadOptions = new LoadOptions();
$loadOptions->setDefaultTextLanguage("en-US");

$presentation = new Presentation($loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // 新增一個帶文字的矩形圖形。
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

若要在簡報層級套用預設文字格式，請使用 [Presentation::getDefaultTextStyle](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#getDefaultTextStyle)。

以下程式碼示範如何在新簡報的所有投影片中設定預設的粗體字型，字型大小為 14 點。

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

## **以全大寫效果擷取文字**

在 PowerPoint 中，套用 **全大寫** 字型效果會讓投影片上的文字以大寫形式顯示，即使原始輸入為小寫。當您使用 Aspose.Slides 取得此類文字片段時，函式庫會回傳原始輸入的文字。若要匹配顯示的文字，請檢查 [TextCapType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textcaptype/) 並在值為 `All` 時將回傳字串轉為大寫。

假設我們在 sample2.pptx 的第一張投影片上有以下文字方塊。

![全大寫效果](all_caps_effect.png)

以下程式碼示範如何擷取套用 **全大寫** 效果的文字：

```php
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

**如何在投影片的表格中修改文字？**

要在投影片的表格中修改文字，請使用 [Table](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/table/)。遍歷儲存格，並透過 [Cell::getTextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/cell/#getTextFrame) 以及 [Paragraph::getParagraphFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraph/#getParagraphFormat) 來更新每個儲存格的文字與段落格式。

**如何在 PowerPoint 投影片的文字上套用漸層色彩？**

要為文字套用漸層色彩，請使用 [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseportionformat/#getFillFormat)。將 [FillFormat::setFillType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fillformat/#setFillType) 設為 [FillType::Gradient](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/filltype/)，並設定漸層止點、方向與透明度。