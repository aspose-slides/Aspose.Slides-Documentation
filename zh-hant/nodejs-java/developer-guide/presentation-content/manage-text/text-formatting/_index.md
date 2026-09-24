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
- 字型族
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
description: "使用 Aspose.Slides for Node.js via Java 於 PowerPoint 與 OpenDocument 簡報中格式化與設計文字。自訂字型、顏色、對齊方式等。"
---
## **概觀**

本文說明如何使用 Aspose.Slides for Node.js via Java 來格式化 PowerPoint 與 OpenDocument 簡報中的文字。內容涵蓋背景色、透明度、字元間距、字型屬性、旋轉、段落間距、自動調整行為、文字錨點、定位點與語言設定。

以下範例中，我們將使用名為「sample.pptx」的檔案，該檔案在第一張投影片上包含一個文字方塊，內容如下：

![範例文字](sample_text.png)

若要尋找並突顯文字或正規表示式匹配項目，請參閱[搜尋與取代文字](/slides/zh-hant/nodejs-java/search-and-replace-text/)。

## **設定文字背景色**

使用 [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) 設定段落的預設突顯顏色，或使用 [BasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/baseportionformat/#getHighlightColor--) 為個別文字片段設定突顯顏色。

下列程式碼範例示範如何為 **整個段落** 設定背景色：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 設定整個段落的突顯顏色。
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    presentation.save("gray_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![灰色段落](gray_paragraph.png)

下面的程式碼範例示範如何為 **粗體字體的文字片段** 設定背景色：

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

![灰色文字片段](gray_text_portions.png)

## **對齊文字段落**

使用 [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) 設定文字框內段落的對齊方式。可設定為置中、左對齊、右對齊、兩端對齊等。

以下程式碼範例示範如何將段落對齊至 **置中**：

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

結果：

![對齊的段落](aligned_paragraph.png)

## **設定文字透明度**

文字透明度透過指派給 [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/baseportionformat/#getFillFormat--) 的顏色之 Alpha 成分來控制。在以下範例中，`alpha = 50` 為 0–255 範圍的 ARGB Alpha 通道值，而非透明度百分比。

下列程式碼範例示範如何對 **整個段落** 套用透明度：

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

    // 設定文字的填充顏色為透明色。
    fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
    fillFormat.getSolidFillColor().setColor(transparentBlack);

    presentation.save("transparent_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![透明段落](transparent_paragraph.png)

以下程式碼範例示範如何對 **粗體字體的文字片段** 套用透明度：

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

![透明文字片段](transparent_text_portions.png)

## **設定文字字元間距**

使用 [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/baseportionformat/#setSpacing-float-) 來擴大或縮小文字方塊中字元之間的間距。

以下 JavaScript 程式碼示範如何在 **整個段落** 中擴大字元間距：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 注意：使用負值來壓縮字元間距。
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // 擴大字元間距。

    presentation.save("character_spacing_in_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![段落中的字元間距](character_spacing_in_paragraph.png)

以下程式碼範例示範如何在 **粗體字體的文字片段** 中擴大字元間距：

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
            portion.getPortionFormat().setSpacing(3); // 擴大字元間距。
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![文字片段中的字元間距](character_spacing_in_text_portions.png)

### **停用特定字型的字距微調**

在某些情況下，Aspose.Slides 所渲染的文字可能比 PowerPoint 中的同一文字看起來稍微緊密。這可能是因為 PowerPoint 會忽略某些字型的字距微調資料，即使該字型包含有效的字距微調資訊且在 PowerPoint 設定中已啟用字距微調。

為了使渲染結果更接近 PowerPoint，您可以對使用受影響字型的文字片段停用字距微調。將 [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/baseportionformat/#setKerningMinimalSize-float-) 設為遠大於實際字型大小的值：

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

此設定可防止對符合條件的文字片段套用字距微調，並有助於使 Aspose.Slides 的渲染與受到此 PowerPoint 特定行為影響的字型之 PowerPoint 視覺輸出保持一致。

## **管理文字字型屬性**

字型屬性可透過 [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) 在段落層級設定，或透過 [PortionFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/portionformat/) 在個別文字片段設定。

以下程式碼為整個段落設定字型與文字樣式：它會對段落中所有文字片段套用字型大小、粗體、斜體、點狀底線以及 Times New Roman 字型。

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

結果：

![段落的字型屬性](font_properties_for_paragraph.png)

以下程式碼範例對 **粗體字體的文字片段** 套用類似的屬性：

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

![文字片段的字型屬性](font_properties_for_text_portions.png)

## **設定文字旋轉**

使用 [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) 設定形狀內的預定文字方向。

以下程式碼範例將形狀內的文字方向設定為 `Vertical270`，即將文字 **逆時針旋轉 90 度**：

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

結果：

![文字旋轉](text_rotation.png)

## **設定文字框的自訂旋轉**

使用 [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframeformat/#setRotationAngle-float-) 為 [TextFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/) 設定自訂旋轉角度。

以下程式碼範例將文字框在形狀內順時針旋轉 3 度：

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

結果：

![自訂文字旋轉](custom_text_rotation.png)

## **設定段落行距**

Aspose.Slides 提供 [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter-float-)、[ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore-float-) 與 [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraphformat/#setSpaceWithin-float-) 以控制段落間距。這些屬性的使用方式如下：

· 使用正值可將行距指定為行高的百分比。  
· 使用負值可將行距以點數指定。

以下程式碼範例示範如何在段落內指定行距：

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

結果：

![段落內的行距](line_spacing.png)

## **設定文字框的自動調整類型**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframeformat/#setAutofitType-byte-) 決定文字超出容器邊界時的行為。可使用它控制文字是否縮小、溢出或自動調整形狀大小。

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

若要在自動換行後計算行數並觀察文字或形狀寬度變化，請參閱[Count Rendered Lines](/slides/zh-hant/nodejs-java/manage-paragraph/)。僅靠行數無法判斷文字是否溢出容器。

## **設定文字框錨點**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframeformat/#setAnchoringType-byte-) 定義文字在形狀內的垂直定位方式，例如置頂、置中或置底。

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

## **設定文字定位點**

使用 [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraphformat/#setDefaultTabSize-float-) 與 [ParagraphFormat.getTabs](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraphformat/#getTabs--) 來設定段落中的定位點。

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

結果：

![段落定位點](paragraph_tabs.png)

## **設定校對語言**

Aspose.Slides 提供 [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-)，可為文字片段設定校對語言。校對語言決定 PowerPoint 進行拼寫與文法檢查時使用的語言。

以下程式碼範例示範如何為文字片段設定校對語言：

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

使用 [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) 定義在載入或建立簡報時所建立文字的預設語言。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

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

若要在簡報層級套用預設文字格式，請使用 [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/#getDefaultTextStyle--)。

以下程式碼範例示範如何在新簡報中為所有投影片的文字設定預設粗體、14 點大小的字型。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

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

## **擷取具有全大寫效果的文字**

在 PowerPoint 中，套用 **All Caps** 字型效果會使文字在投影片上以大寫顯示，即使原本是小寫。使用 Aspose.Slides 取得此類文字片段時，函式庫會回傳原始輸入的文字。若要與顯示的文字相符，請檢查 [TextCapType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textcaptype/)，當其值為 `All` 時將回傳的字串轉為大寫。

假設我們在 sample2.pptx 檔案的第一張投影片上有以下文字方塊。

![全大寫效果](all_caps_effect.png)

以下程式碼範例示範如何擷取已套用 **All Caps** 效果的文字：

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

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **常見問題**

**如何修改投影片中表格的文字？**

要修改投影片中表格的文字，請使用 [Table](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/table/)。遍歷儲存格，並透過 [Cell.getTextFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/cell/#getTextFrame--) 更新每個儲存格，並使用 [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraph/#getParagraphFormat--) 調整段落格式。

**如何在 PowerPoint 投影片的文字上套用漸層色彩？**

要為文字套用漸層色彩，請使用 [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/baseportionformat/#getFillFormat--)。將 [FillFormat.setFillType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fillformat/#setFillType-byte-) 設為 [FillType.Gradient](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/filltype/)，並設定漸層停止點、方向與透明度。