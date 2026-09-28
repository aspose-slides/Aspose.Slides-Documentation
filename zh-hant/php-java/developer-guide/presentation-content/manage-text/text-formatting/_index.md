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
- 文字定位
- 預設語言
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 在 PowerPoint 與 OpenDocument 簡報中格式化與樣式文字。自訂字型、顏色、對齊等。"
---
## **概述**

本文說明如何使用 Aspose.Slides for PHP via Java 來格式化 PowerPoint 和 OpenDocument 簡報中的文字。內容涵蓋背景顏色、透明度、字元間距、字型屬性、旋轉、段落間距、自動調整行為、文字錨點、定位點以及語言設定。

除非另有說明，範例均使用 [sample.pptx](sample.pptx)。第一張投影片的第一個圖形是一個文字方塊，其第一個段落包含下方所示的文字。投影片和圖形索引皆為零基礎。選取粗體部分的範例使用有效的格式，包括繼承的粗體格式：

![範例文字](sample_text.png)

要搜尋並突顯文字或正則表達式匹配，請參閱 [搜尋與取代文字](/slides/zh-hant/php-java/search-and-replace-text/)。

## **設定文字背景顏色**

使用 [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) 來設定段落的預設醒目顏色，或使用 [BasePortionFormat::getHighlightColor](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseportionformat/#getHighlightColor) 針對個別文字片段設定。

以下範例將淺灰色醒目標示設為第一段的預設。對個別片段的明確醒目顏色會優先於此預設：

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $highlightColor = java("java.awt.Color")->LIGHT_GRAY;

    // 設定整段的醒目顏色。
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
            // 設定文字片段的醒目顏色。
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

使用 [ParagraphFormat::setAlignment](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/#setAlignment) 來設定文字框內段落的對齊方式。此值可以是置中、左對齊、右對齊、兩端對齊等。

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

![已對齊的段落](aligned_paragraph.png)

## **設定文字透明度**

文字透明度透過指派給 [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseportionformat/#getFillFormat) 的色彩之 alpha 元件來控制。在以下範例中，`alpha = 50` 為 0–255 量表上的 ARGB alpha 通道值，並非透明度百分比。

以下程式碼範例示範如何將透明度套用於 **整段文字**：

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

以下程式碼範例示範如何將透明度套用於 **粗體字型的文字片段**：

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

使用 [BasePortionFormat::setSpacing](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseportionformat/#setSpacing) 來擴大或收縮文字方塊中字元之間的間距。範例中加入 3 點的間距；負值則會壓縮文字。

以下 PHP 程式碼示範如何在 **整段文字** 中擴大字元間距：

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

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

以下程式碼範例示範如何在 **粗體字型的文字片段** 中擴大字元間距：

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

### **停用特定字型的字距微調**

在某些情況下，Aspose.Slides 所呈現的文字看起來可能比 PowerPoint 中的相同文字稍微緊密。這可能是因為 PowerPoint 可能會忽略某些字型的字距微調資料，即使該字型包含有效的字距微調資訊且在 PowerPoint 設定中已啟用字距微調。

為了使此類情況下的呈現結果更接近 PowerPoint，您可以對使用受影響字型的文字片段停用字距微調。將 [BasePortionFormat::setKerningMinimalSize](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseportionformat/#setKerningMinimalSize) 設為大於實際字型大小的值。此範例需要「presentation.pptx」且第一張投影片的第一個圖形為文字方塊。它會檢查有效的字型名稱（包括繼承的字型），並為使用 Roboto 的片段設定 100 點的門檻。這會對字型大小低於 100 點的符合條件的片段停用字距微調：

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

對於符合門檻以下的文字，此設定會防止字距微調，並可協助使 Aspose.Slides 的渲染與受此 PowerPoint 特定行為影響的字型之 PowerPoint 視覺輸出保持一致。

## **管理文字字型屬性**

字型屬性可以透過 [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) 在段落層級設定，或透過 [PortionFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/portionformat/) 在個別片段上設定。

以下範例將第一段的預設字型設定為 12 點 Times New Roman，並套用粗體、斜體與點線底線格式。個別片段的明確格式會優先於這些預設值。

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

以下範例將 13 點 Times New Roman、斜體格式與點線底線套用於有效格式為粗體的片段：

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

使用 [TextFrameFormat::setTextVerticalType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframeformat/#setTextVerticalType) 來設定圖形內的預定文字方向。

以下程式碼範例將圖形中的文字方向設為 [TextVerticalType::Vertical270](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textverticaltype/)，此方向會使文字 **逆時針旋轉 90 度**：

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

![文字旋轉](text_rotation.png)

## **為文字框設定自訂旋轉**

使用 [TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframeformat/#setRotationAngle) 為 [TextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/) 設定自訂旋轉角度。

以下程式碼範例在圖形內將文字框順時針旋轉 3 度：

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

![自訂文字旋轉](custom_text_rotation.png)

## **設定段落的行距**

Aspose.Slides 提供 [ParagraphFormat::setSpaceAfter](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/#setSpaceAfter)、[ParagraphFormat::setSpaceBefore](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/#setSpaceBefore) 與 [ParagraphFormat::setSpaceWithin](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/#setSpaceWithin) 來控制段落間距。這些屬性的使用方式如下：

* 使用正值以段落高度的百分比指定行距。
* 使用負值以點數指定行距。

以下範例將第一段的行距設定為行高的 200%（雙倍行距）：

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

## **控制換行**

段落換行規則在窄文字區塊以及混合拉丁文與東亞文字的簡報中相當有用。以下方法屬於 [ParagraphFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/)，因此會套用於整段文字：

- [setLatinLineBreak](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/#setLatinLineBreak) 控制拉丁文換行規則。在混合文字中，變更它也可能影響相鄰東亞文字和標點的換行位置。
- [setEastAsianLineBreak](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) 控制東亞文字換行規則，包括行首與行尾字元的限制。

這些規則不會取代 [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframeformat/#setWrapText)，後者可在文字框內啟用自動換行。規則僅在換行發生時影響版面配置，並不會插入換行字元。明確的換行會在段落內強制換到新行，與可用寬度無關。

以下獨立範例建立包含中文與拉丁文的窄文字區塊，明確設定兩項換行選項，並儲存為 `line_breaking.pptx`。如要測試任一規則，只需變更對應的值，同時保持其他設定不變。範例使用 24 點 Arial 與 SimSun，框寬 160 點，水平文字框邊距為 0。呼叫 [TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframeformat/#setAutofitType) 並傳入 [TextAutofitType::None](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textautofittype/) 以固定文字大小與框尺寸。

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

[ParagraphFormat::setHangingPunctuation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/#setHangingPunctuation) 允許符合條件的標點超出文字行的右邊緣，而不是佔據下一行。它套用於整段文字，且與懸掛縮排不同。

以下獨立範例在寬度為 100 點的文字框中啟用懸掛標點，並儲存為 `hanging_punctuation.pptx`。使用 24 點 Arial 與水平文字框邊距為 0，最終的句點會留在「sentence」之後，並延伸至右側文字邊緣。將屬性設定為 [NullableBool::False](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/nullablebool/) 可作比較：此設定下句點會佔據單獨一行。啟用換行並停用自動調整，以固定可用寬度。

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

並非所有標點都能懸掛。可見結果取決於字型可用性與版面配置：變更字型、可用寬度、邊距或自動調整設定可能會消除可見差異。

## **設定文字框的自動調整類型**

[TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframeformat/#setAutofitType) 決定文字超出容器邊界時的行為。可用它來控制文字是縮小、溢出，或自動調整圖形大小。以下範例將圖形設定為依文字大小自動調整，並將結果儲存為 `autofit_type.pptx`。

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

若要在自動換行後計算行數並查看文字或圖形寬度變化對結果的影響，請參閱 [計算已呈現行數](/slides/zh-hant/php-java/manage-paragraph/)。僅行數不足以判斷文字是否溢出其容器。

## **設定文字框的錨點**

[TextFrameFormat::setAnchoringType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframeformat/#setAnchoringType) 定義文字在圖形內的垂直定位方式，例如置頂、置中或置底。以下範例將文字錨定於第一個圖形的底部，並將結果儲存為 `text_anchor.pptx`。

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

## **設定文字定位**

使用 [ParagraphFormat::setDefaultTabSize](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/#setDefaultTabSize) 與 [ParagraphFormat::getTabs](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/#getTabs) 來設定段落中的定位點。以下範例將預設定位間距設為 100 點，並在 30 點處加入左對齊的定位點。此設定會影響包含定位字元的文字。

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

![段落定位](paragraph_tabs.png)

## **設定校對語言**

Aspose.Slides 提供 [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseportionformat/#setLanguageId)，可為文字片段設定校對語言。校對語言決定 PowerPoint 中的拼寫與文法檢查所使用的語言。

以下範例需要「presentation.pptx」且第一張投影片的第一個圖形為文字方塊，且至少包含一個段落。它會將第一段的內容替換為「1。」、將字型設為 SimSun，並指派簡體中文校對語言 (`zh-CN`)。最後儲存為 `proofing_language.pptx`：

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

使用 [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) 來定義在載入或建立簡報時所建立文字的預設語言。以下範例建立一個以美式英語作為預設文字語言的簡報，新增文字方塊，並輸出其第一個文字片段的語言代碼 `en-US`。

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

    // 檢查第一個文字片段的語言。
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    echo $portion->getPortionFormat()->getLanguageId();
} finally {
    $presentation->dispose();
}
```

## **設定預設文字樣式**

若要在簡報層級套用預設文字格式，請使用 [Presentation::getDefaultTextStyle](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#getDefaultTextStyle)。

以下範例將新簡報中頂層段落的預設字型設定為 14 點粗體，並將結果儲存為 `default_text_style.pptx`。文字可繼承這些預設，除非有更具體的格式覆寫它們。

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

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

## **擷取套用全大寫效果的文字**

在 PowerPoint 中，套用 **All Caps** 字型效果會讓文字在投影片上顯示為全大寫，即使原始輸入為小寫。使用 Aspose.Slides 取得此類文字片段時，函式庫會回傳實際輸入的文字。若要符合顯示結果，請檢查 [TextCapType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textcaptype/) 並在值為 `All` 時將返回的字串轉為大寫。

此範例需要「sample2.pptx」且第一張投影片的第一個圖形為文字方塊。其第一段的第一個片段包含「Hello, Aspose!」且套用了 All Caps 效果，如下圖所示。

![全大寫效果](all_caps_effect.png)

以下程式碼範例示範如何擷取套用 **All Caps** 效果的文字：

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

## **常見問題**

**如何在投影片的表格中修改文字？**

要在投影片的表格中修改文字，請使用 [Table](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/table/)。遍歷儲存格，並透過 [Cell::getTextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/cell/#getTextFrame) 取得文字框，再使用 [Paragraph::getParagraphFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraph/#getParagraphFormat) 進行段落格式設定。

**如何在 PowerPoint 投影片的文字上套用漸層顏色？**

要為文字套用漸層顏色，請使用 [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseportionformat/#getFillFormat)。將 [FillFormat::setFillType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fillformat/#setFillType) 設為 [FillType::Gradient](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/filltype/)，並設定漸層停點、方向與透明度。