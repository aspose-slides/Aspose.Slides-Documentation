---
title: 在 Java 中格式化簡報文字
linktitle: 文字格式化
type: docs
weight: 50
url: /zh-hant/java/text-formatting/
keywords:
- 突顯文字
- 正規表達式
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
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 於 PowerPoint 與 OpenDocument 簡報中格式化與樣式設定文字。自訂字型、顏色、對齊方式等。"
---
## **概述**

本文說明如何使用 Aspose.Slides for Java 在 PowerPoint 與 OpenDocument 簡報中格式化文字。內容涵蓋突出顯示、背景色、透明度、字元間距、字型屬性、旋轉、段落間距、自動縮放行為、文字錨點、定位點，以及語言設定。

以下範例中，我們將使用名為「sample.pptx」的檔案，該檔案在第一張投影片上包含一個文字方塊，文字如下：

![Sample text](sample_text.png)

## **突出顯示文字**

當需要在文字框中突出顯示符合特定樣本的文字時，請使用 [ITextFrame.highlightText](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-) 方法。此方法會為符合的文字片段套用突出顯示顏色，且可搭配 [TextSearchOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/textsearchoptions/) 來控制搜尋方式，例如只匹配完整單字。

以下程式碼範例會先突出顯示所有 **\"try\"** 字元的出現，接著只突出顯示完整單字 **\"to\"**。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    // 取得第一張投影片中的第一個圖形。
    IAutoShape shape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // 突顯圖形中的字詞「try」。
    shape.getTextFrame().highlightText("try", Color.LIGHT_GRAY);

    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);

    // 突顯圖形中的字詞「to」。
    shape.getTextFrame().highlightText("to", Color.MAGENTA, searchOptions, null);

    presentation.save("highlighted_text.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![已突出顯示的文字](highlighted_text.png)

## **使用正則表達式突出顯示文字**

[ITextFrame.highlightRegex](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) 方法會突顯正則表達式找到的文字匹配項目。在 Java 中，此 API 透過 [ITextFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/) 提供。

以下程式碼範例會突顯所有包含 **七個或以上字元** 的單字：

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape shape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    java.util.regex.Pattern regex = java.util.regex.Pattern.compile("\\b[^\\s]{7,}\\b");

    // 突顯所有字元數為七個或以上的單字。
    shape.getTextFrame().highlightRegex(regex, Color.YELLOW, null);

    presentation.save("highlighted_text_using_regex.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![使用正則表達式突顯的文字](highlighted_text_using_regex.png)

## **設定文字背景色**

使用 [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) 可為段落設定預設的突出顯示顏色，或使用 [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ibaseportionformat/#getHighlightColor--) 為單一文字片段設定。

以下程式碼範例示範如何為 **整段文字** 設定背景色：

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 設定整段文字的突出顯示顏色。
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![灰色段落](gray_paragraph.png)

以下程式碼範例示範如何為 **粗體字的文字片段** 設定背景色：

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // 設定文字片段的突出顯示顏色。
            portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);
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

使用 [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) 可在文字框內設定段落對齊方式。可設定為置中、左對齊、右對齊、兩端對齊等。

以下程式碼範例示範如何將段落對齊至 **置中**：

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 設定段落的對齊方式為置中。
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![已對齊的段落](aligned_paragraph.png)

## **設定文字透明度**

文字透明度透過指派給 [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ibaseportionformat/#getFillFormat--) 的顏色之 alpha 元件控制。在下列範例中，`alpha = 50` 為 0-255 之間的 ARGB alpha 通道值，並非透明度百分比。

以下程式碼範例示範如何為 **整段文字** 套用透明度：

```java
int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 設定文字的填充顏色為透明顏色。
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 0, alpha));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![透明段落](transparent_paragraph.png)

以下程式碼範例示範如何為 **粗體字的文字片段** 套用透明度：

```java
int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // 設定文字片段的透明度。
            portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 0, alpha));
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

使用 [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ibaseportionformat/#setSpacing-float-) 可在文字方塊中擴大或收縮字元之間的間距。

以下 Java 程式碼示範如何在 **整段文字** 中擴大字元間距：

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 注意: 使用負值來壓縮字元間距。
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // 展開字元間距。

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![段落中的字元間距](character_spacing_in_paragraph.png)

以下程式碼範例示範如何在 **粗體字的文字片段** 中擴大字元間距：

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // 注意: 使用負值來壓縮字元間距。
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

### **停用特定字型的字距微調**

在某些情況下，Aspose.Slides 所呈現的文字看起來會比 PowerPoint 中的相同文字略為緊密。這可能是因為 PowerPoint 會忽略某些字型的字距微調資料，即使該字型包含有效的字距微調資訊且在 PowerPoint 設定中已啟用字距微調。

若要在此類情況下使呈現的輸出更接近 PowerPoint，您可以為使用受影響字型的文字片段停用字距微調。將 [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) 設為遠大於實際字型大小的值：

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    String targetFont = "Roboto";

    for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) {
        for (IPortion portion : paragraph.getPortions()) {
            IPortionFormat portionFormat = portion.getPortionFormat();

            if ((portionFormat.getLatinFont() != null &&
                 portionFormat.getLatinFont().getFontName().equals(targetFont)) ||
                (portionFormat.getEastAsianFont() != null &&
                 portionFormat.getEastAsianFont().getFontName().equals(targetFont)) ||
                (portionFormat.getComplexScriptFont() != null &&
                 portionFormat.getComplexScriptFont().getFontName().equals(targetFont))) {
                portionFormat.setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

此設定會防止對符合條件的文字片段套用字距微調，協助使 Aspose.Slides 的渲染結果與 PowerPoint 針對受此 PowerPoint 特定行為影響之字型的視覺輸出保持一致。

## **管理文字字型屬性**

字型屬性可透過 [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) 在段落層級設定，或透過 [IPortionFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iportionformat/) 在個別片段層級設定。

以下程式碼為整段文字設定字型與文字樣式：為段落中的所有片段套用字型大小、粗體、斜體、點線底線，以及 Times New Roman 字型。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
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

以下程式碼範例將相似的屬性套用於 **粗體字的文字片段**：

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
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

使用 [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) 可在圖形內設定預定義的文字方向。

以下程式碼範例將圖形內的文字方向設定為 `Vertical270`，即文字 **逆時針旋轉 90 度**：

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270);

    presentation.save("text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![文字旋轉](text_rotation.png)

## **設定文字框自訂旋轉**

使用 [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) 可為 [ITextFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/) 設定自訂的旋轉角度。

以下程式碼範例將文字框在圖形內順時針旋轉 3 度：

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setRotationAngle(3);

    presentation.save("custom_text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![自訂文字旋轉](custom_text_rotation.png)

## **設定段落行距**

Aspose.Slides 提供 [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-)、[IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) 與 [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) 以控制段落間距。使用方式如下：

* 使用正值以指定行距為行高的百分比。
* 使用負值以點數指定行距。

以下程式碼範例示範如何在段落內指定行距：

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setSpaceWithin(200);

    presentation.save("line_spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![段落內的行距](line_spacing.png)

## **設定文字框的自動調整類型**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) 決定文字超出容器邊界時的行為。可用來控制文字是否縮小、溢出或自動調整圖形大小。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAutofitType(TextAutofitType.Shape);

    presentation.save("autofit_type.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **設定文字框錨點**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) 定義文字在圖形內的垂直定位方式，例如置頂、置中或置底。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom);

    presentation.save("text_anchor.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **設定文字定位**

使用 [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) 與 [IParagraphFormat.getTabs](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraphformat/#getTabs--) 可在段落中配置定位點。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
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

Aspose.Slides 提供 [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-)，可為文字片段設定校對語言。校對語言決定 PowerPoint 中的拼寫與文法檢查所使用的語言。

以下程式碼範例示範如何為文字片段設定校對語言：

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    FontData font = new FontData("SimSun");

    Portion textPortion = new Portion();
    textPortion.getPortionFormat().setComplexScriptFont(font);
    textPortion.getPortionFormat().setEastAsianFont(font);
    textPortion.getPortionFormat().setLatinFont(font);

    // 設定校對語言的 Id。
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1.");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **設定預設語言**

使用 [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) 可為載入或建立簡報時所產生的文字定義預設語言。

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

若要在簡報層級套用預設文字格式，請使用 [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipresentation/#getDefaultTextStyle--)。

以下程式碼範例示範如何在新簡報中的所有投影片上設定預設的粗體字型，字型大小為 14 pt：

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

## **擷取全大寫效果的文字**

在 PowerPoint 中，套用 **All Caps** 字型效果會使投影片上的文字以全大寫顯示，即使原始輸入為小寫。使用 Aspose.Slides 取得此類文字片段時，函式庫會回傳原始輸入的文字。若要與顯示的文字一致，請檢查 [TextCapType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/textcaptype/) 並在值為 `All` 時將回傳的字串轉為大寫。

假設我們在 sample2.pptx 檔案的第一張投影片上有下列文字方塊。

![全大寫效果](all_caps_effect.png)

以下程式碼範例示範如何擷取套用 **All Caps** 效果的文字：

```java
Presentation presentation = new Presentation("sample2.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
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

## **常見問答**

**如何在投影片的表格中修改文字？**

使用 [ITable](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itable/) 以遍歷儲存格，並透過 [ICell.getTextFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/icell/#getTextFrame--) 取得文字框，接著使用 [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraph/#getParagraphFormat--) 調整段落格式來更新每個儲存格的文字。

**如何在 PowerPoint 投影片的文字套用漸層色彩？**

使用 [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ibaseportionformat/#getFillFormat--) 取得填充格式，將 [IFillFormat.setFillType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ifillformat/#setFillType-byte-) 設為 [FillType.Gradient](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/filltype/)，並配置漸層停點、方向與透明度。