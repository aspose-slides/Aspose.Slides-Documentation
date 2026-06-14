---
title: 在 Android 上格式化簡報文字
linktitle: 文字格式化
type: docs
weight: 50
url: /zh-hant/androidjava/text-formatting/
keywords:
- 突顯文字
- 正規表達式
- 段落對齊
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
- 自動適應屬性
- 文字框錨點
- 文字定位點
- 預設語言
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java 於 PowerPoint 與 OpenDocument 簡報中格式化與設定文字樣式。自訂字型、顏色、對齊方式等。"
---
## **概述**

本文說明如何使用 Aspose.Slides for Android via Java 來格式化 PowerPoint 和 OpenDocument 簡報中的文字。內容涵蓋突顯、背景色、透明度、字元間距、字型屬性、旋轉、段落間距、自動適應行為、文字錨點、定位點以及語言設定。

在以下範例中，我們會使用名為 **sample.pptx** 的檔案，該檔案的第一張投影片上有一個文字方塊，文字內容如下：

![範例文字](sample_text.png)

## **突顯文字**

當您需要突顯文字框中符合特定樣本的文字時，請使用 [ITextFrame.highlightText](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ITextFrame#highlightText-java.lang.String-java.lang.Integer-) 方法。此方法會對符合的文字片段套用突顯色，並可搭配 [ITextSearchOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ITextSearchOptions) 來控制搜尋方式，例如僅匹配完整單詞。

以下程式碼範例先突顯所有 **"try"** 字元，再僅突顯完整單詞 **"to"**。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    // 取得第一張投影片中的第一個形狀。
    IAutoShape shape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // 在形狀中突顯單字 "try"。
    shape.getTextFrame().highlightText("try", Color.rgb(173, 216, 230));

    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);

    // 在形狀中突顯單字 "to"。
    int violetColor = Color.rgb(238, 130, 238);
    shape.getTextFrame().highlightText("to", violetColor, searchOptions, null);

    presentation.save("highlighted_text.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![已突顯的文字](highlighted_text.png)

## **使用正規表示式突顯文字**

[ITextFrame.highlightRegex](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ITextFrame#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) 方法會突顯正規表示式找到的文字匹配項。

以下程式碼範例會突顯所有 **包含七個或以上字元的單詞**：

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape shape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    java.util.regex.Pattern regex = java.util.regex.Pattern.compile("\\b[^\\s]{7,}\\b");

    // 突顯所有含七個或以上字元的單詞。
    shape.getTextFrame().highlightRegex(regex, Color.YELLOW, null);

    presentation.save("highlighted_text_using_regex.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![使用正規表示式突顯的文字](highlighted_text_using_regex.png)

## **設定文字背景色**

使用 [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IParagraphFormat#getDefaultPortionFormat--) 可設定段落的預設突顯色，或使用 [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IBasePortionFormat#getHighlightColor--) 為個別文字片段設定。

下面的程式碼示範如何為 **整段文字** 設定背景色：

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 設定整段文字的突顯顏色。
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LTGRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![灰色段落](gray_paragraph.png)

以下程式碼示範如何為 **加粗字體的文字片段** 設定背景色：

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (int portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
        IPortion portion = paragraph.getPortions().get_Item(portionIndex);

        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // 設定文字片段的突顯顏色。
            portion.getPortionFormat().getHighlightColor().setColor(Color.LTGRAY);
        }
    }

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![灰色文字片段](gray_text_portions.png)

## **對齊文字段落**

使用 [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IParagraphFormat#setAlignment-byte-) 可設定文字框內段落的對齊方式。可設定為置中、左對齊、右對齊、兩端對齊等。

下面的程式碼示範如何將段落 **置中**：

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 設定段落的對齊方式為置中。
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![已置中段落](aligned_paragraph.png)

## **設定文字透明度**

文字透明度透過指派給 [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IBasePortionFormat#getFillFormat--) 之顏色的 Alpha 元件來控制。以下範例中的 `alpha = 50` 為 0‑255 範圍的 ARGB Alpha 值，並非透明度百分比。

下面的程式碼示範如何為 **整段文字** 套用透明度：

```java
int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 設定文字的填充顏色為透明顏色。
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.argb(alpha, 0, 0, 0));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![透明段落](transparent_paragraph.png)

以下程式碼示範如何為 **加粗字體的文字片段** 套用透明度：

```java
int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (int portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
        IPortion portion = paragraph.getPortions().get_Item(portionIndex);

        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // 設定文字片段的透明度。
            portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.argb(alpha, 0, 0, 0));
        }
    }

    presentation.save("transparent_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![透明文字片段](transparent_text_portions.png)

## **設定文字字元間距**

使用 [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IBasePortionFormat#setSpacing-float-) 可在文字方塊中擴展或收縮字元之間的間距。

以下 Java 程式碼示範如何在 **整段文字** 中擴展字元間距：

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 注意：使用負值可壓縮字元間距。
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // 展開字元間距。

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![段落中的字元間距](character_spacing_in_paragraph.png)

以下程式碼示範如何在 **加粗字體的文字片段** 中擴展字元間距：

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (int portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
        IPortion portion = paragraph.getPortions().get_Item(portionIndex);

        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // 注意：使用負值可壓縮字元間距。
            portion.getPortionFormat().setSpacing(3); // 展開字元間距。
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![文字片段中的字元間距](character_spacing_in_text_portions.png)

### **為特定字型停用字距調整（Kerning）**

在某些情況下，Aspose.Slides 渲染的文字可能比 PowerPoint 中顯示的略為緊密。這可能是因為 PowerPoint 會忽略某些字型的字距調整資料，即使字型本身具備有效的字距資訊且在 PowerPoint 設定中已啟用字距調整。

若要在此類情況下使渲染結果更接近 PowerPoint，您可以對使用受影響字型的文字片段停用字距調整。將 [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IBasePortionFormat#setKerningMinimalSize-float-) 設為遠大於實際字型大小的值：

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    String targetFont = "Roboto";

    for (int paragraphIndex = 0; paragraphIndex < autoShape.getTextFrame().getParagraphs().getCount(); paragraphIndex++) {
        IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(paragraphIndex);

        for (int portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
            IPortion portion = paragraph.getPortions().get_Item(portionIndex);
            IFontData latinFont = portion.getPortionFormat().getLatinFont();
            IFontData eastAsianFont = portion.getPortionFormat().getEastAsianFont();
            IFontData complexScriptFont = portion.getPortionFormat().getComplexScriptFont();

            boolean usesTargetFont =
                    latinFont != null && targetFont.equals(latinFont.getFontName()) ||
                    eastAsianFont != null && targetFont.equals(eastAsianFont.getFontName()) ||
                    complexScriptFont != null && targetFont.equals(complexScriptFont.getFontName());

            if (usesTargetFont) {
                portion.getPortionFormat().setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

此設定會阻止對符合條件的文字片段套用字距調整，協助讓 Aspose.Slides 的渲染結果與 PowerPoint 對受影響字型的視覺輸出保持一致。

## **管理文字字型屬性**

字型屬性可以透過 [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IParagraphFormat#getDefaultPortionFormat--) 在段落層級設定，或透過 [IPortionFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IPortionFormat) 在個別文字片段設定。

以下程式碼為整段文字設定字型與文字樣式：套用字型大小、粗體、斜體、點狀底線，以及 Times New Roman 字型至段落內所有片段。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 設定段落的字型屬性。
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(12);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontBold(NullableBool.True);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontItalic(NullableBool.True);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontUnderline(TextUnderlineType.Dotted);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new FontData("Times New Roman"));

    presentation.save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![段落的字型屬性](font_properties_for_paragraph.png)

以下程式碼示範對 **加粗字體的文字片段** 套用相同屬性：

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (int portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
        IPortion portion = paragraph.getPortions().get_Item(portionIndex);

        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // 設定文字片段的字型屬性。
            portion.getPortionFormat().setFontHeight(13);
            portion.getPortionFormat().setFontItalic(NullableBool.True);
            portion.getPortionFormat().setFontUnderline(TextUnderlineType.Dotted);
            portion.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
        }
    }

    presentation.save("font_properties_for_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![文字片段的字型屬性](font_properties_for_text_portions.png)

## **設定文字旋轉**

使用 [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ITextFrameFormat#setTextVerticalType-byte-) 可在形狀內設定預定義的文字方向。

以下程式碼將形狀內的文字方向設定為 `Vertical270`，即文字 **逆時針旋轉 90 度**：

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270);

    presentation.save("text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![文字旋轉](text_rotation.png)

## **為文字框設定自訂旋轉角度**

使用 [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ITextFrameFormat#setRotationAngle-float-) 可為 [ITextFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ITextFrame) 設定自訂旋轉角度。

以下程式碼在形狀內將文字框順時針旋轉 3 度：

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setRotationAngle(3);

    presentation.save("custom_text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![自訂文字旋轉](custom_text_rotation.png)

## **設定段落的行距**

Aspose.Slides 提供 [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IParagraphFormat#setSpaceAfter-float-)、[IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IParagraphFormat#setSpaceBefore-float-) 與 [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IParagraphFormat#setSpaceWithin-float-) 以控制段落間距。這些屬性的使用方式如下：

* 使用正值可將行距指定為行高的百分比。
* 使用負值則以點 (pt) 為單位指定行距。

以下程式碼示範如何在段落內指定行距：

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setSpaceWithin(200);

    presentation.save("line_spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![段落內的行距](line_spacing.png)

## **設定文字框的自動適應類型**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ITextFrameFormat#setAutofitType-byte-) 決定文字超出容器邊界時的行為。使用此屬性可控制文字是縮小、溢出，或自動調整形狀大小。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAutofitType(TextAutofitType.Shape);

    presentation.save("autofit_type.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **設定文字框的錨點**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ITextFrameFormat#setAnchoringType-byte-) 定義文字在形狀內的垂直定位方式，例如置頂、置中或置底。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom);

    presentation.save("text_anchor.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **設定文字定位點（Tab）**

使用 [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IParagraphFormat#setDefaultTabSize-float-) 以及 [IParagraphFormat.getTabs](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IParagraphFormat#getTabs--) 來配置段落的定位點。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setDefaultTabSize(100);
    paragraph.getParagraphFormat().getTabs().add(30, TabAlignment.Left);

    presentation.save("paragraph_tabs.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![段落定位點](paragraph_tabs.png)

## **設定校對語言**

Aspose.Slides 提供 [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-)，可為文字片段設定校對語言。校對語言決定 PowerPoint 進行拼寫與文法檢查時使用的語言。

以下程式碼示範如何為文字片段設定校對語言：

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    FontData font = new FontData("SimSun");

    Portion textPortion = new Portion();
    textPortion.getPortionFormat().setComplexScriptFont(font);
    textPortion.getPortionFormat().setEastAsianFont(font);
    textPortion.getPortionFormat().setLatinFont(font);

    // 設定校對語言的 ID。
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **設定預設語言**

使用 [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/LoadOptions#setDefaultTextLanguage-java.lang.String-) 可定義載入或建立簡報時所產生文字的預設語言。

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 新增一個帶文字的矩形形狀。
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // 檢查第一個文字片段的語言。
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    System.out.println(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **設定預設文字樣式**

若要在簡報層級套用預設文字格式，請使用 [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IPresentation#getDefaultTextStyle--)。

以下程式碼示範如何在新簡報中為所有投影片的文字設定 14 點大小、粗體的預設文字樣式。

```java
Presentation presentation = new Presentation();
try {
    // 取得頂層段落格式。
    IParagraphFormat paragraphFormat = presentation.getDefaultTextStyle().getLevel(0);

    if (paragraphFormat != null) {
        paragraphFormat.getDefaultPortionFormat().setFontHeight(14);
        paragraphFormat.getDefaultPortionFormat().setFontBold(NullableBool.True);
    }

    presentation.save("default_text_style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **擷取套用「全部大寫」效果的文字**

在 PowerPoint 中，套用 **All Caps** 字體效果會使文字在投影片上以大寫顯示，即使原始輸入為小寫。使用 Aspose.Slides 取得此類文字片段時，函式庫會回傳原始輸入的文字。若要與顯示結果相符，請檢查 [TextCapType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/TextCapType) 並在值為 `All` 時將回傳字串轉為大寫。

以下示例說明在 sample2.pptx 的第一張投影片中的文字方塊。

![全部大寫效果](all_caps_effect.png)

以下程式碼示範如何擷取套用 **All Caps** 效果的文字：

```java
Presentation presentation = new Presentation("sample2.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IPortion textPortion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);

    System.out.println("Original text: " + textPortion.getText());

    IPortionFormatEffectiveData textFormat = textPortion.getPortionFormat().getEffective();
    if (textFormat.getTextCapType() == TextCapType.All) {
        String text = textPortion.getText().toUpperCase();
        System.out.println("All-Caps effect: " + text);
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

## **常見問題集**

**如何修改投影片上表格中的文字？**

要修改投影片上表格的文字，請使用 [ITable](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ITable)。遍歷儲存格，並透過 [ICell.getTextFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ICell#getTextFrame--) 以及 [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IParagraph#getParagraphFormat--) 來更新每個儲存格的文字與段落格式。

**如何為 PowerPoint 投影片中的文字套用漸層色彩？**

要為文字套用漸層色彩，請使用 [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IBasePortionFormat#getFillFormat--)。將 [IFillFormat.setFillType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IFillFormat#setFillType-int-) 設為 [FillType.Gradient](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/FillType)，並配置漸層停點、方向與透明度。