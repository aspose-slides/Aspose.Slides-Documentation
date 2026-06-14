---
title: 在 JavaScript 中格式化簡報文字
linktitle: 文字格式化
type: docs
weight: 50
url: /zh-hant/nodejs-java/text-formatting/
keywords:
- 突顯文字
- 正則表達式
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
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js via Java 在 PowerPoint 與 OpenDocument 簡報中格式化與設計文字。自訂字型、顏色、對齊等多項設定。"
---
## **概覽**

本文說明如何使用 Aspose.Slides for Node.js via Java 在 PowerPoint 與 OpenDocument 簡報中格式化文字。內容涵蓋突顯、背景色、透明度、字元間距、字型屬性、旋轉、段落間距、自動調整行為、文字錨點、定位點以及語言設定。

在下列範例中，我們會使用名為 **sample.pptx** 的檔案，該檔案在第一張投影片上有一個文字方塊，內含以下文字：

![Sample text](sample_text.png)

## **突顯文字**

當需要在文字方塊中突顯符合特定樣本的文字時，使用 [TextFrame.highlightText](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-) 方法。該方法會將突顯色套用於匹配的文字片段，且可搭配 [TextSearchOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textsearchoptions/) 來控制搜尋方式，例如只匹配完整單字。

以下程式碼示範先突顯所有 **"try"** 字元，再只突顯完整單字 **"to"**。

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const textFrame = shape.getTextFrame();

    // 在形狀中突顯單字「try」。
    textFrame.highlightText("try", java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    const searchOptions = new aspose.slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);

    // 在形狀中突顯單字「to」。
    textFrame.highlightText("to", java.getStaticFieldValue("java.awt.Color", "MAGENTA"), searchOptions, null);

    presentation.save("highlighted_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![The highlighted text](highlighted_text.png)

## **使用正則表達式突顯文字**

[TextFrame.highlightRegex](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-aspose.slides.IFindResultCallback-) 方法會突顯正則表達式找到的文字匹配項目。在 Node.js via Java 中，此 API 於 [TextFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/) 顯示。

以下程式碼突顯所有包含 **七個以上字元** 的單字：

```javascript
const Pattern = java.import("java.util.regex.Pattern");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const regex = Pattern.compile("\\b[^\\s]{7,}\\b");

    // 突顯所有七個字元或以上的單字。
    shape.getTextFrame().highlightRegex(regex, java.getStaticFieldValue("java.awt.Color", "YELLOW"), null);

    presentation.save("highlighted_text_using_regex.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![The highlighted text using the regular expression](highlighted_text_using_regex.png)

## **設定文字背景色**

使用 [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) 來設定段落的預設突顯色，或使用 [PortionFormat.getHighlightColor](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/portionformat/#getHighlightColor--) 針對單一文字片段設定。

以下程式碼示範如何為 **整個段落** 設定背景色：

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 設定整個段落的突顯顏色。
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    presentation.save("gray_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![The gray paragraph](gray_paragraph.png)

以下程式碼示範如何為 **粗體字的文字片段** 設定背景色：

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // 設定文字片段的突顯顏色。
            portion.getPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
        }
    }

    presentation.save("gray_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![The gray text portions](gray_text_portions.png)

## **對齊文字段落**

使用 [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraphformat/#setAlignment-byte-) 來設定文字方塊內段落的對齊方式，可設定為置中、左對齊、右對齊、兩端對齊等。

以下程式碼示範如何將段落 **置中**：

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 將段落對齊方式設定為置中。
    paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![The aligned paragraph](aligned_paragraph.png)

## **設定文字透明度**

文字透明度透過指派給 [PortionFormat.getFillFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/portionformat/#getFillFormat--) 的顏色之 alpha 成分來控制。以下範例中的 `alpha = 50` 為 0‑255 之 ARGB alpha 通道值，非透明度百分比。

以下程式碼示範如何對 **整個段落** 套用透明度：

```javascript
const alpha = 50;
const transparentBlack = java.newInstanceSync("java.awt.Color", 0, 0, 0, alpha);
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const fillFormat = paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat();

    // 設定文字的填充顏色為透明顏色。
    fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
    fillFormat.getSolidFillColor().setColor(transparentBlack);

    presentation.save("transparent_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![The transparent paragraph](transparent_paragraph.png)

以下程式碼示範如何對 **粗體字的文字片段** 套用透明度：

```javascript
const alpha = 50;
const transparentBlack = java.newInstanceSync("java.awt.Color", 0, 0, 0, alpha);
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            const fillFormat = portion.getPortionFormat().getFillFormat();

            // 設定文字片段的透明度。
            fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
            fillFormat.getSolidFillColor().setColor(transparentBlack);
        }
    }

    presentation.save("transparent_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![The transparent text portions](transparent_text_portions.png)

## **設定文字字元間距**

使用 [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/baseportionformat/#setSpacing-float-) 可在文字方塊中擴展或壓縮字元間距。

以下 JavaScript 程式碼示範如何在 **整個段落** 中擴展字元間距：

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 注意：使用負值可壓縮字元間距。
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // 展開字元間距。

    presentation.save("character_spacing_in_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![The character spacing in the paragraph](character_spacing_in_paragraph.png)

以下程式碼示範如何在 **粗體字的文字片段** 中擴展字元間距：

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // 注意：使用負值可壓縮字元間距。
            portion.getPortionFormat().setSpacing(3); // 展開字元間距。
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![The character spacing in the text portions](character_spacing_in_text_portions.png)

### **停用特定字型的字距調整**

在某些情況下，Aspose.Slides 呈現的文字可能較 PowerPoint 顯示的稍微緊密。這可能是因為 PowerPoint 會忽略某些字型的字距調整資料，即使字型本身包含有效的字距資訊且在 PowerPoint 設定中已啟用字距調整。

為了使輸出更接近 PowerPoint，您可以對使用受影響字型的文字片段停用字距調整。將 [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/baseportionformat/#setKerningMinimalSize-float-) 設為遠大於實際字型大小的數值：

```javascript
const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraphs = autoShape.getTextFrame().getParagraphs();
    const paragraphCount = paragraphs.getCount();
    const targetFont = "Roboto";

    for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
        const portions = paragraphs.get_Item(paragraphIndex).getPortions();
        const portionCount = portions.getCount();

        for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
            const portion = portions.get_Item(portionIndex);
            const portionFormat = portion.getPortionFormat();
            const latinFont = portionFormat.getLatinFont();
            const eastAsianFont = portionFormat.getEastAsianFont();
            const complexScriptFont = portionFormat.getComplexScriptFont();

            if ((latinFont !== null && latinFont.getFontName() === targetFont) ||
                (eastAsianFont !== null && eastAsianFont.getFontName() === targetFont) ||
                (complexScriptFont !== null && complexScriptFont.getFontName() === targetFont)) {
                portionFormat.setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

此設定可避免對符合條件的文字片段套用字距調整，協助將 Aspose.Slides 的渲染與 PowerPoint 針對此類字型的視覺輸出保持一致。

## **管理文字字型屬性**

字型屬性可透過 [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) 在段落層級設定，或透過 [PortionFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/portionformat/) 在個別文字片段設定。

以下程式碼為整個段落設定字型與文字樣式：套用字型大小、粗體、斜體、點線底線，以及 Times New Roman 字型於段落內所有片段。

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
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

結果：

![The font properties for the paragraph](font_properties_for_paragraph.png)

以下程式碼將相同屬性套用至 **粗體字的文字片段**：

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            const portionFormat = portion.getPortionFormat();

            // 設定文字片段的字型屬性。
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

結果：

![The font properties for text portions](font_properties_for_text_portions.png)

## **設定文字旋轉**

使用 [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) 可以在圖形內設定預定義的文字方向。

以下程式碼將圖形內的文字方向設定為 `Vertical270`，即文字 **逆時針旋轉 90 度**：

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical270));

    presentation.save("text_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![The text rotation](text_rotation.png)

## **為文字框設定自訂旋轉角度**

使用 [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframeformat/#setRotationAngle-float-) 可為 [TextFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/) 設定自訂旋轉角度。

以下程式碼將文字框在圖形內順時針旋轉 3 度：

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setRotationAngle(3);

    presentation.save("custom_text_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![The custom text rotation](custom_text_rotation.png)

## **設定段落的行距**

Aspose.Slides 提供 [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter-float-)、[ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore-float-) 與 [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraphformat/#setSpaceWithin-float-) 來控制段落間距，使用方式如下：

* 正值表示以行高的百分比指定行距。
* 負值則以點為單位指定行距。

以下程式碼示範如何在段落內指定行距：

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setSpaceWithin(200);

    presentation.save("line_spacing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![The line spacing within the paragraph](line_spacing.png)

## **設定文字框的自動調整類型**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframeformat/#setAutofitType-byte-) 決定文字在超出容器邊界時的行為。使用它可控制文字是收縮、溢出或自動調整圖形大小。

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));

    presentation.save("autofit_type.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **設定文字框的錨點**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframeformat/#setAnchoringType-byte-) 定義文字在圖形內的垂直位置，例如置頂、置中或置底。

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Bottom));

    presentation.save("text_anchor.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **設定文字定位點**

使用 [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraphformat/#setDefaultTabSize-float-) 與 [ParagraphFormat.getTabs](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraphformat/#getTabs--) 來配置段落中的定位點。

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setDefaultTabSize(100);
    paragraph.getParagraphFormat().getTabs().add(30, java.newByte(aspose.slides.TabAlignment.Left));

    presentation.save("paragraph_tabs.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![The paragraph tabs](paragraph_tabs.png)

## **設定校對語言**

Aspose.Slides 提供 [PortionFormat.setLanguageId](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-)，可為文字片段設定校對語言。校對語言決定 PowerPoint 中拼寫與文法檢查使用的語言。

以下程式碼示範如何為文字片段設定校對語言：

```javascript
const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    const font = new aspose.slides.FontData("SimSun");
    const textPortion = new aspose.slides.Portion();
    textPortion.getPortionFormat().setComplexScriptFont(font);
    textPortion.getPortionFormat().setEastAsianFont(font);
    textPortion.getPortionFormat().setLatinFont(font);

    // 設定校對語言的 Id。
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1.");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **設定預設語言**

使用 [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) 來定義載入或建立簡報時所使用的預設文字語言。

```javascript
const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

const presentation = new aspose.slides.Presentation(loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);

    // 新增一個帶文字的矩形形狀。
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // 檢查第一個文字片段的語言。
    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    console.log(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **設定預設文字樣式**

若要在簡報層級套用預設文字格式，使用 [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/#getDefaultTextStyle--)。

以下程式碼示範如何在新簡報中，為所有投影片的文字設定預設的 **粗體、14 點** 字型。

```javascript
const presentation = new aspose.slides.Presentation();
try {
    // 取得最高層段落格式。
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

## **以全大寫效果擷取文字**

在 PowerPoint 中，套用 **All Caps** 字型效果會使投影片上顯示的大寫文字，即使原始輸入為小寫。使用 Aspose.Slides 取得此類文字片段時，函式庫會回傳原始輸入的文字。若要與顯示結果一致，請檢查 [TextCapType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textcaptype/) 並在值為 `All` 時將回傳字串轉為大寫。

假設在 sample2.pptx 檔案的第一張投影片上有如下文字方塊。

![The All Caps effect](all_caps_effect.png)

以下程式碼示範如何擷取套用 **All Caps** 效果的文字：

```javascript
const presentation = new aspose.slides.Presentation("sample2.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
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

## **常見問答**

**如何在投影片的表格中修改文字？**

要在投影片的表格中修改文字，請使用 [Table](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/table/)。遍歷儲存格，透過 [Cell.getTextFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/cell/#getTextFrame--) 取得文字框，並使用 [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraph/#getParagraphFormat--) 調整段落格式。

**如何在 PowerPoint 投影片的文字上套用漸層色彩？**

要為文字套用漸層色彩，請使用 [PortionFormat.getFillFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/portionformat/#getFillFormat--)。將 [FillFormat.setFillType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fillformat/#setFillType-byte-) 設為 [FillType.Gradient](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/filltype/)，並配置漸層停點、方向與透明度。