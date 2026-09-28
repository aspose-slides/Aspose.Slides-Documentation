---
title: 在 JavaScript 中格式化簡報文字
linktitle: 文字格式化
type: docs
weight: 50
url: /zh-hant/nodejs-java/text-formatting/
keywords:
- 對齊段落
- 文字樣式
- 文字背景
- 文字透明度
- 字元間距
- 字型屬性
- 字型家族
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
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js via Java 在 PowerPoint 與 OpenDocument 簡報中格式化與樣式化文字。自訂字型、顏色、對齊方式等。"
---
## **概述**

本文說明如何使用 Aspose.Slides for Node.js via Java 來格式化 PowerPoint 與 OpenDocument 簡報中的文字。內容涵蓋背景顏色、透明度、字元間距、字型屬性、旋轉、段落間距、自動調整行為、文字錨定、定位點與語言設定。

除非另有說明，範例均使用 [sample.pptx](sample.pptx)。其第一張投影片的第一個圖案是一個文字方塊，第一段落包含下列文字。投影片與圖案索引皆從零開始。選取粗體部分的範例使用有效的格式設定，包括繼承的粗體格式：

![Sample text](sample_text.png)

若要搜尋並標示文字或正規表達式匹配項目，請參閱 [Search and Replace Text](/slides/zh-hant/nodejs-java/search-and-replace-text/)。

## **設定文字背景顏色**

使用 [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) 來設定段落的預設醒目顏色，或使用 [BasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/baseportionformat/#getHighlightColor--) 針對單一文字部分設定。

以下範例將淡灰色醒目作為第一段的預設。對各文字部分明確設定的醒目顏色會覆蓋此預設值：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 為整段設定醒目顏色。
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    presentation.save("gray_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果如下：

![灰色段落](gray_paragraph.png)

以下程式碼範例示範如何設定 **粗體字型的文字部分** 背景顏色：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // 設定文字部分的醒目顏色。
            portion.getPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
        }
    }

    presentation.save("gray_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果如下：

![灰色文字部分](gray_text_portions.png)

## **對齊文字段落**

使用 [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) 來設定文字框內段落的對齊方式。可設定為置中、左對齊、右對齊、兩端對齊等。

以下程式碼示範如何將段落對齊至 **置中**：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 設定段落的對齊方式為置中。
    paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果如下：

![已對齊的段落](aligned_paragraph.png)

## **設定文字透明度**

文字透明度透過指派給 [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/baseportionformat/#getFillFormat--) 的顏色之 alpha 成分來控制。以下範例中，`alpha = 50` 為 0–255 標度的 ARGB alpha 通道值，並非透明度百分比。

以下程式碼示範如何將透明度套用至 **整段文字**：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const alpha = 50;
const transparentBlack = java.newInstanceSync("java.awt.Color", 0, 0, 0, alpha);
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const fillFormat = paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat();

    // 設定文字的填色為透明顏色。
    fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
    fillFormat.getSolidFillColor().setColor(transparentBlack);

    presentation.save("transparent_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果如下：

![透明段落](transparent_paragraph.png)

以下程式碼示範如何將透明度套用至 **粗體字型的文字部分**：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const alpha = 50;
const transparentBlack = java.newInstanceSync("java.awt.Color", 0, 0, 0, alpha);
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            const fillFormat = portion.getPortionFormat().getFillFormat();

            // 設定文字部分的透明度。
            fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
            fillFormat.getSolidFillColor().setColor(transparentBlack);
        }
    }

    presentation.save("transparent_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果如下：

![透明文字部分](transparent_text_portions.png)

## **設定文字字元間距**

使用 [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/baseportionformat/#setSpacing-float-) 以擴張或緊縮文字方塊中字元之間的間距。範例中加入 3 點間距；負值則會壓縮文字。

以下 JavaScript 程式碼顯示如何在 **整段文字** 中擴大字元間距：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 注意：使用負值來壓縮字元間距。
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // 擴展字元間距。

    presentation.save("character_spacing_in_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果如下：

![段落字元間距](character_spacing_in_paragraph.png)

以下程式碼範例示範如何在 **粗體字型的文字部分** 中擴大字元間距：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // 注意：使用負值來壓縮字元間距。
            portion.getPortionFormat().setSpacing(3); // 擴展字元間距。
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果如下：

![文字部分字元間距](character_spacing_in_text_portions.png)

### **停用特定字型的字距微調**

在某些情況下，Aspose.Slides 所渲染的文字可能比 PowerPoint 中的相同文字顯得稍微緊縮。這可能是因為即使字型內含有效的字距微調資訊且在 PowerPoint 設定中已啟用字距微調，PowerPoint 仍可能忽略特定字型的字距微調資料。

為了讓渲染結果更接近 PowerPoint，您可以對使用受影響字型的文字部分停用字距微調。將 [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/baseportionformat/#setKerningMinimalSize-float-) 設為大於實際字型大小的值。本範例需要一個名為 "presentation.pptx"，其第一張投影片的第一個圖案為文字方塊。程式會檢查有效的字型名稱（包括繼承的字型），並對使用 Roboto 的文字部分設定 100 點的門檻。這會對字型大小低於 100 點的符合條件的部分停用字距微調：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraphs = autoShape.getTextFrame().getParagraphs();
    const paragraphCount = paragraphs.getCount();
    const targetFont = "Roboto";

    for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
        const portions = paragraphs.get_Item(paragraphIndex).getPortions();
        const portionCount = portions.getCount();

        for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
            const portion = portions.get_Item(portionIndex);
            const portionFormat = portion.getPortionFormat().getEffective();
            const latinFont = portionFormat.getLatinFont();
            const eastAsianFont = portionFormat.getEastAsianFont();
            const complexScriptFont = portionFormat.getComplexScriptFont();

            if ((latinFont !== null && latinFont.getFontName() === targetFont) ||
                (eastAsianFont !== null && eastAsianFont.getFontName() === targetFont) ||
                (complexScriptFont !== null && complexScriptFont.getFontName() === targetFont)) {
                portion.getPortionFormat().setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

對於符合條件且字型大小低於門檻的文字，此設定會阻止字距微調，並有助於使 Aspose.Slides 的渲染與 PowerPoint 針對受此 PowerPoint 特定行為影響之字型的視覺輸出保持一致。

## **管理文字字型屬性**

字型屬性可透過 [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) 在段落層級設定，或透過 [PortionFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/portionformat/) 在個別文字部分設定。

以下範例將第一段的預設字型設定為 12 點 Times New Roman，並套用粗體、斜體與點狀底線。個別文字部分的明確格式會優先於這些預設值：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const defaultPortionFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();

    // 設定段落的字型屬性。
    defaultPortionFormat.setFontHeight(12);
    defaultPortionFormat.setFontBold(java.newByte(aspose.slides.NullableBool.True));
    defaultPortionFormat.setFontItalic(java.newByte(aspose.slides.NullableBool.True));
    defaultPortionFormat.setFontUnderline(java.newByte(aspose.slides.TextUnderlineType.Dotted));
    defaultPortionFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));

    presentation.save("font_properties_for_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果如下：

![段落字型屬性](font_properties_for_paragraph.png)

以下範例將 13 點 Times New Roman、斜體與點狀底線套用至有效格式為粗體的文字部分：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            const portionFormat = portion.getPortionFormat();

            // 設定文字部分的字型屬性。
            portionFormat.setFontHeight(13);
            portionFormat.setFontItalic(java.newByte(aspose.slides.NullableBool.True));
            portionFormat.setFontUnderline(java.newByte(aspose.slides.TextUnderlineType.Dotted));
            portionFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));
        }
    }

    presentation.save("font_properties_for_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果如下：

![文字部分字型屬性](font_properties_for_text_portions.png)

## **設定文字旋轉**

使用 [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) 來設定形狀內的預定義文字方向。

以下程式碼範例將形狀中的文字方向設定為 [TextVerticalType.Vertical270](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textverticaltype/)，此設定會將文字 **逆時針旋轉 90 度**：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical270));

    presentation.save("text_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果如下：

![文字旋轉](text_rotation.png)

## **設定文字框的自訂旋轉**

使用 [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframeformat/#setRotationAngle-float-) 來為 [TextFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/) 設定自訂的旋轉角度。

以下程式碼將文字框在形狀內順時針旋轉 3 度：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setRotationAngle(3);

    presentation.save("custom_text_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果如下：

![自訂文字旋轉](custom_text_rotation.png)

## **設定段落行距**

Aspose.Slides 提供 [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter-float-)、[ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore-float-) 與 [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraphformat/#setSpaceWithin-float-) 來控制段落間距。這些屬性的使用方式如下：

* 使用正值可將行距指定為行高的百分比。
* 使用負值可以點為單位指定行距。

以下範例將第一段的行距設定為行高的 200%（雙倍行距）：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);

    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().setSpaceWithin(200);

    presentation.save("line_spacing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果如下：

![段落內的行距](line_spacing.png)

## **控制換行**

段落換行規則在狹窄文字區塊以及混合拉丁文字與東亞文字的簡報中很有用。以下方法屬於 [ParagraphFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraphformat/)，因此會套用於整個段落：

- [setLatinLineBreak](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraphformat/#setLatinLineBreak-byte-) 控制拉丁文字的換行規則。在混合文字中，變更此設定亦可能影響相鄰東亞文字與標點符號的換行位置。  
- [setEastAsianLineBreak](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraphformat/#setEastAsianLineBreak-byte-) 控制東亞文字的換行規則，包含行首與行尾字元的限制。

這些規則不會取代 [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframeformat/#setWrapText-byte-)，後者可在文字框內啟用自動換行。它們會在換行發生時影響版面配置；不會插入換行字元。明確的換行會在段落內強制產生新行，與可用寬度無關。

以下自包含範例建立一個含有中文與拉丁文字的狹窄文字區塊，明確設定兩項換行選項，並儲存為 "line_breaking.pptx"。若要測試任一規則，只需變更對應的值，同時保持另一設定不變。範例使用 24 點 Arial 與 SimSun，框寬 160 點，水平文字框邊距為 0。呼叫 [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframeformat/#setAutofitType-byte-) 並傳入 [TextAutofitType.None](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textautofittype/)，以使文字大小與框尺寸固定不變。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 160, 300);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.True));
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));
    textFrame.getTextFrameFormat().setMarginLeft(0);
    textFrame.getTextFrameFormat().setMarginRight(0);

    const paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.setText("中文排版测试，PowerPoint 中文演示。");

    const format = paragraph.getParagraphFormat();
    format.setAlignment(aspose.slides.TextAlignment.Left);
    format.getDefaultPortionFormat().setFontHeight(24);
    const latinFont = new aspose.slides.FontData("Arial");
    format.getDefaultPortionFormat().setLatinFont(latinFont);
    const eastAsianFont = new aspose.slides.FontData("SimSun");
    format.getDefaultPortionFormat().setEastAsianFont(eastAsianFont);
    format.getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
    format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(textColor);
    format.setLatinLineBreak(java.newByte(aspose.slides.NullableBool.False));
    format.setEastAsianLineBreak(java.newByte(aspose.slides.NullableBool.True));

    presentation.save("line_breaking.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **控制懸掛標點**

[ParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraphformat/#setHangingPunctuation-byte-) 允許符合條件的標點符號延伸至文字行右側邊緣，而不是佔據下一行。它套用於整個段落，且不同於懸掛縮排。

以下自包含範例在寬度 100 點的文字框中啟用懸掛標點，並儲存為 "hanging_punctuation.pptx"。使用 24 點 Arial 與水平文字框邊距為 0 時，最後的句點會保留在「sentence」之後，並延伸至文字右邊緣。將屬性設定為 [NullableBool.False](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/nullablebool/) 可進行比較：在此設定下，句點會佔據獨立的一行。已啟用換行且停用自動調整，以保持可用寬度固定。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 100, 200);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.True));
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));
    textFrame.getTextFrameFormat().setMarginLeft(0);
    textFrame.getTextFrameFormat().setMarginRight(0);

    const paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.setText("Simple text, next sentence.");

    const format = paragraph.getParagraphFormat();
    format.setAlignment(aspose.slides.TextAlignment.Left);
    format.getDefaultPortionFormat().setFontHeight(24);
    const latinFont = new aspose.slides.FontData("Arial");
    format.getDefaultPortionFormat().setLatinFont(latinFont);
    format.getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
    format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(textColor);
    format.setHangingPunctuation(java.newByte(aspose.slides.NullableBool.True));

    presentation.save("hanging_punctuation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

並非所有標點符號皆能懸掛。可見結果取決於字型可用性與版面配置：變更字型、可用寬度、邊距或自動調整設定，都可能消除可見差異。

## **設定文字框的自動調整類型**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframeformat/#setAutofitType-byte-) 決定文字超出容器邊界時的處理方式。可用於控制文字是縮小、溢出，或自動調整形狀大小。以下範例設定形狀自動調整以適應文字，並將結果儲存為 "autofit_type.pptx"。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));

    presentation.save("autofit_type.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

若要在自動換行後計算行數，並觀察文字或形狀寬度變化對結果的影響，請參閱 [Count Rendered Lines](/slides/zh-hant/nodejs-java/manage-paragraph/)。僅靠行數並無法判斷文字是否溢出其容器。

## **設定文字框的錨點**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframeformat/#setAnchoringType-byte-) 定義文字在形狀內的垂直定位方式，例如置頂、置中或置底。以下範例將文字錨定於第一個圖案的底部，並將結果儲存為 "text_anchor.pptx"。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Bottom));

    presentation.save("text_anchor.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **設定文字定位**

使用 [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraphformat/#setDefaultTabSize-float-) 與 [ParagraphFormat.getTabs](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraphformat/#getTabs--) 來配置段落中的定位點。以下範例將預設定位間距設定為 100 點，並在 30 點處新增左對齊的定位點。此設定會影響包含定位字元的文字。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);

    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().setDefaultTabSize(100);
    paragraph.getParagraphFormat().getTabs().add(30, java.newByte(aspose.slides.TabAlignment.Left));

    presentation.save("paragraph_tabs.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果如下：

![段落定位](paragraph_tabs.png)

## **設定校對語言**

Aspose.Slides 提供 [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-)，可為文字部分設定校對語言。校對語言決定 PowerPoint 中拼字與文法檢查所使用的語言。

以下範例需要一個名為 "presentation.pptx"，其第一張投影片的第一個圖案為文字方塊，且至少包含一個段落。範例將第一段的內容替換為 "1。"，將字型設定為 SimSun，並指派簡體中文校對語言 (`zh-CN`)。結果儲存為 "proofing_language.pptx"：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);

    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    const font = new aspose.slides.FontData("SimSun");
    const textPortion = new aspose.slides.Portion();
    textPortion.getPortionFormat().setComplexScriptFont(font);
    textPortion.getPortionFormat().setEastAsianFont(font);
    textPortion.getPortionFormat().setLatinFont(font);

    // 設定校對語言的 Id。
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **設定預設語言**

使用 [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) 來定義在載入或建立簡報時所建立文字的預設語言。以下範例建立一個預設文字語言為美式英語的簡報，加入文字方塊，並列印其第一個文字部分的語言代碼 `en-US`。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

const presentation = new aspose.slides.Presentation(loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);

    // 新增一個帶文字的矩形圖形。
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // 檢查第一個文字部分的語言。
    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    console.log(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **設定預設文字樣式**

要在簡報層級套用預設文字格式，請使用 [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/#getDefaultTextStyle--)。

以下範例將 14 點粗體字型設定為新簡報中頂層段落的預設，並儲存為 "default_text_style.pptx"。文字可以繼承這些預設值，除非有更具體的格式覆寫它們。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    // 取得最高層級的段落格式。
    const paragraphFormat = presentation.getDefaultTextStyle().getLevel(0);

    if (paragraphFormat !== null) {
        paragraphFormat.getDefaultPortionFormat().setFontHeight(14);
        paragraphFormat.getDefaultPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    }

    presentation.save("default_text_style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **擷取帶全部大寫效果的文字**

在 PowerPoint 中，套用 **All Caps** 字型效果會使文字在投影片上以全大寫顯示，即使原本是小寫輸入。使用 Aspose.Slides 取得此類文字部分時，函式庫會返回原始輸入的文字。若要匹配顯示的文字，請檢查 [TextCapType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textcaptype/)，當值為 `All` 時將回傳字串轉為大寫。

此範例需要 "sample2.pptx"，其第一張投影片的第一個圖案為文字方塊。其第一段的第一個文字部分包含套用 All Caps 效果的 "Hello, Aspose!"，如圖所示：

![全部大寫效果](all_caps_effect.png)

以下程式碼示範如何擷取帶 **All Caps** 效果的文字：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample2.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    
    const autoShape = slide.getShapes().get_Item(0);
    const textPortion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);

    console.log("Original text: " + textPortion.getText());

    const textFormat = textPortion.getPortionFormat().getEffective();
    if (textFormat.getTextCapType() === aspose.slides.TextCapType.All) {
        const text = textPortion.getText().toUpperCase();
        console.log("All-Caps effect: " + text);
    }
} finally {
    presentation.dispose();
}
```

輸出：

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **常見問題**

**要在投影片上的表格中修改文字，該怎麼做？**

要在投影片的表格中修改文字，請使用 [Table](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/table/)。遍歷儲存格，並透過 [Cell.getTextFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/cell/#getTextFrame--) 以及 [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraph/#getParagraphFormat--) 更新每個儲存格的文字框與段落格式。

**要在 PowerPoint 投影片的文字上套用漸層顏色，該怎麼做？**

要套用漸層顏色至文字，請使用 [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/baseportionformat/#getFillFormat--)。將 [FillFormat.setFillType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fillformat/#setFillType-byte-) 設為 [FillType.Gradient](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/filltype/)，並設定漸層停點、方向與透明度。