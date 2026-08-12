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
description: "使用 Aspose.Slides for PHP via Java 在 PowerPoint 與 OpenDocument 簡報中格式化與美化文字。自訂字型、顏色、對齊方式等。"
---
## **概觀**

本文說明如何使用 Aspose.Slides for PHP via Java 於 PowerPoint 和 OpenDocument 簡報中格式化文字。內容涵蓋背景顏色、透明度、字元間距、字型屬性、旋轉、段落間距、自動調整行為、文字錨點、定位點以及語言設定。

在下列範例中，我們將使用名為「sample.pptx」的檔案，該檔案在第一張投影片上包含一個文字盒，內有以下文字：

![範例文字](sample_text.png)

若要尋找並突出顯示文字字面值或正規表示式匹配，請參閱[搜尋與取代文字](/slides/zh-hant/php-java/search-and-replace-text/)。

## **設定文字背景顏色**

使用 [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) 設定段落的預設突出顯示顏色，或使用 [BasePortionFormat::getHighlightColor](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseportionformat/#getHighlightColor) 設定單一文字片段的顏色。

以下程式碼範例示範如何為 **整段文字** 設定背景顏色：

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $highlightColor = java("java.awt.Color")->LIGHT_GRAY;

    // 設定整段文字的突出顏色。
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getHighlightColor()->setColor($highlightColor);

    $presentation->save("gray_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果：

![灰色段落](gray_paragraph.png)

以下程式碼範例示範如何為 **粗體字型的文字片段** 設定背景顏色：

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
            // 設定文字片段的突出顏色。
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

以下程式碼範例示範如何將段落對齊至 **置中**：

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

文字透明度是透過指派給 [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseportionformat/#getFillFormat) 的顏色之 alpha 成分來控制。以下範例中，`alpha = 50` 為 0–255 之間的 ARGB alpha 通道值，非透明度百分比。

以下程式碼範例示範如何對 **整段文字** 套用透明度：

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

以下程式碼範例示範如何對 **粗體字型的文字片段** 套用透明度：

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

使用 [BasePortionFormat::setSpacing](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseportionformat/#setSpacing) 來擴大或收縮文字盒中字元之間的間距。

以下 PHP 程式碼示範如何在 **整段文字** 中擴大字元間距：

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // 注意：使用負值來壓縮字元間距。
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(3); // 擴大字元間距。

    $presentation->save("character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果：

![段落中的字元間距](character_spacing_in_paragraph.png)

以下程式碼範例示範如何在 **粗體字型的文字片段** 中擴大字元間距：

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
            // 注意：使用負值來壓縮字元間距。
            $portion->getPortionFormat()->setSpacing(3); // 擴大字元間距。
        }
    }

    $presentation->save("character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果：

![文字片段中的字元間距](character_spacing_in_text_portions.png)

### **停用特定字型的字距調整 (Kerning)**

在某些情況下，Aspose.Slides 所產生的文字渲染會較 PowerPoint 顯示的略為緊密。這可能是因為 PowerPoint 會忽略某些字型的字距調整資料，即使該字型本身包含有效的字距調整資訊且在 PowerPoint 設定中已啟用字距調整。

若要使渲染結果更貼近 PowerPoint，可對使用受影響字型的文字片段停用字距調整。將 [BasePortionFormat::setKerningMinimalSize](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseportionformat/#setKerningMinimalSize) 設為遠大於實際字型大小的數值：

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

此設定可防止對相符的文字片段套用字距調整，協助 Aspose.Slides 的渲染效果與 PowerPoint 針對此類字型的視覺輸出保持一致。

## **管理文字字型屬性**

字型屬性可透過 [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) 在段落層級設定，或透過 [PortionFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/portionformat/) 在個別片段上設定。

以下程式碼為整段文字設定字型與文字樣式：套用字型大小、粗體、斜體、點狀底線，以及 Times New Roman 字型至段落中所有片段。

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

以下程式碼範例在 **粗體字型的文字片段** 上套用相同屬性：

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

使用 [TextFrameFormat::setTextVerticalType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframeformat/#setTextVerticalType) 在形狀內設定預先定義的文字方向。

以下程式碼範例將形狀內的文字方向設為 `Vertical270`，即使文字 **逆時針旋轉 90 度**：

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

## **設定文字框的自訂旋轉角度**

使用 [TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframeformat/#setRotationAngle) 為 [TextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/) 設定自訂旋轉角度。

以下程式碼範例將文字框在形狀內順時針旋轉 3 度：

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

* 使用正值以段落高度的百分比指定行距。
* 使用負值以點數指定行距。

以下程式碼範例示篡如何在段落內指定行距：

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

## **設定文字框的自動調整類型**

[TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframeformat/#setAutofitType) 決定文字超出容器邊界時的行為。使用它可控制文字是縮小、溢出，或自動調整形狀大小。

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

## **設定文字框的錨點**

[TextFrameFormat::setAnchoringType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframeformat/#setAnchoringType) 定義文字在形狀內的垂直位置，例如置頂、置中或置底。

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

## **設定文字定位點 (Tab)**

使用 [ParagraphFormat::setDefaultTabSize](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/#setDefaultTabSize) 以及 [ParagraphFormat::getTabs](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/#getTabs) 來配置段落中的定位點。

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

![段落定位點](paragraph_tabs.png)

## **設定校對語言**

Aspose.Slides 提供 [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseportionformat/#setLanguageId)，可為文字片段設定校對語言。校對語言決定 PowerPoint 中拼寫與文法檢查所使用的語言。

以下程式碼範例示範如何為文字片段設定校對語言：

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

使用 [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) 定義載入或建立簡報時所建立文字的預設語言。

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

若要在簡報層級套用預設文字格式，請使用 [Presentation::getDefaultTextStyle](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#getDefaultTextStyle)。

以下程式碼範例示範如何在新簡報中為所有投影片的文字設定預設的粗體字型、大小為 14 pt：

```php
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

## **擷取具有全大寫效果的文字**

在 PowerPoint 中套用 **全部大寫** 字型效果會使投影片上的文字顯示為大寫，即使原始輸入為小寫。使用 Aspose.Slides 取得此類文字片段時，函式庫會返回原始輸入的文字。若要與顯示的文字一致，請檢查 [TextCapType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textcaptype/) 並在值為 `All` 時將返回的字串轉為大寫。

假設我們在 sample2.pptx 的第一張投影片上有以下文字盒：

![全部大寫效果](all_caps_effect.png)

以下程式碼範例示範如何擷取套用 **全部大寫** 效果的文字：

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

## **常見問題**  

**如何在投影片的表格中修改文字？**  

要在投影片的表格中修改文字，請使用 [Table](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/table/)。遍歷儲存格，並透過 [Cell::getTextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/cell/#getTextFrame) 更新每個儲存格，並透過 [Paragraph::getParagraphFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraph/#getParagraphFormat) 更新段落格式。

**如何在 PowerPoint 投影片的文字上套用漸層顏色？**  

要在文字上套用漸層顏色，請使用 [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseportionformat/#getFillFormat)。將 [FillFormat::setFillType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fillformat/#setFillType) 設為 [FillType::Gradient](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/filltype/)，並設定漸層停止點、方向與透明度。