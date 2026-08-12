---
title: 在 Java 中格式化簡報文字
linktitle: 文字格式化
type: docs
weight: 50
url: /zh-hant/java/text-formatting/
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
- 自動適合屬性
- 文字框錨點
- 文字定位點
- 預設語言
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 在 PowerPoint 與 OpenDocument 簡報中格式化與樣式化文字。自訂字型、顏色、對齊方式等。"
---
## **概述**

本文說明如何使用 Aspose.Slides for Java 於 PowerPoint 與 OpenDocument 簡報中格式化文字。內容涵蓋背景色、透明度、字元間距、字型屬性、旋轉、段落間距、自動適合行為、文字錨點、定位點以及語言設定。

在下方範例中，我們將使用名為 **sample.pptx** 的檔案，該檔案的第一張投影片上有一個包含以下文字的文字方塊：

![範例文字](sample_text.png)

如需尋找並標示純文字或正規表示式匹配項目，請參閱[Search and Replace Text](/slides/zh-hant/java/search-and-replace-text/)。

## **設定文字背景色彩**

使用[IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) 設定段落的預設強調顏色，或使用[IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ibaseportionformat/#getHighlightColor--) 為單一文字段落設定。

以下程式碼示範如何設定 **整個段落** 的背景色彩：

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 設定整段落的強調顏色。
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![灰色段落](gray_paragraph.png)

下方程式碼示範如何為 **粗體字型的文字段落** 設定背景色彩：

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // 設定文字片段的高亮顏色。
            portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);
        }
    }

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![灰色文字段落](gray_text_portions.png)

## **對齊文字段落**

使用[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) 於文字框內設定段落對齊方式。可設定為置中、左對齊、右對齊、兩端對齊等。

以下程式碼示範如何將段落 **置中**：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
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

文字透明度透過指派給[IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ibaseportionformat/#getFillFormat--) 的顏色之 alpha 成分來控制。以下範例中的 `alpha = 50` 為 0–255 範圍的 ARGB 透明通道值，而非百分比。

以下程式碼示範如何對 **整個段落** 套用透明度：

```java
import com.aspose.slides.*;
import java.awt.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 設定文字的填色為透明顏色。
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 0, alpha));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![透明段落](transparent_paragraph.png)

以下程式碼示範如何對 **粗體字型的文字段落** 套用透明度：

```java
import com.aspose.slides.*;
import java.awt.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
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

![透明文字段落](transparent_text_portions.png)

## **設定文字字元間距**

使用[IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ibaseportionformat/#setSpacing-float-) 以擴大或縮小文字方塊中字元之間的間距。

以下 Java 程式碼示範如何在 **整個段落** 中擴大字元間距：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 註：使用負值壓縮字元間距。
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // 擴展字元間距。

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![段落中的字元間距](character_spacing_in_paragraph.png)

以下程式碼示範如何在 **粗體字型的文字段落** 中擴大字元間距：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // 註：使用負值壓縮字元間距。
            portion.getPortionFormat().setSpacing(3); // 擴展字元間距。
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![文字段落中的字元間距](character_spacing_in_text_portions.png)

### **停用特定字型的字距微調 (Kerning)**

在某些情況下，Aspose.Slides 所渲染的文字看起來可能比 PowerPoint 中的相同文字稍微緊密。這可能是因為 PowerPoint 會忽略某些字型的字距微調資料，即使該字型包含有效的字距微調資訊且在 PowerPoint 設定中已啟用。

若要使渲染結果更貼近 PowerPoint，可對使用受影響字型的文字段落停用字距微調。將[IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) 設為遠大於實際字型大小的值：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
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

此設定可防止對符合條件的文字段落套用字距微調，協助 Aspose.Slides 的渲染與 PowerPoint 針對特定字型的視覺輸出保持一致。

## **管理文字字型屬性**

字型屬性可透過[IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) 在段落層級設定，或透過[IPortionFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iportionformat/) 在個別段落設定。

以下程式碼為整個段落設定字型與文字樣式：套用字型大小、粗體、斜體、點狀底線，以及 Times New Roman 字型至段落中的所有段落。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
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

以下程式碼將相同屬性套用於 **粗體字型的文字段落**：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
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

![文字段落的字型屬性](font_properties_for_text_portions.png)

## **設定文字旋轉**

使用[ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) 設定形狀內的預先定義文字方向。

以下程式碼將文字方向設為 `Vertical270`，即將文字 **逆時針旋轉 90 度**：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270);

    presentation.save("text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![文字旋轉](text_rotation.png)

## **設定文字方塊的自訂旋轉**

使用[ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) 為[ITextFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/) 設定自訂旋轉角度。

以下程式碼將文字方塊在形狀內順時針旋轉 3 度：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setRotationAngle(3);

    presentation.save("custom_text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![自訂文字旋轉](custom_text_rotation.png)

## **設定段落的行距**

Aspose.Slides 提供[IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-)、[IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) 與[IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) 以控制段落間距。這些屬性的使用方式如下：

* 使用正值以百分比表示行高的行距。
* 使用負值以點 (pt) 表示行距。

以下程式碼示範如何在段落內設定行距：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setSpaceWithin(200);

    presentation.save("line_spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![段落內的行距](line_spacing.png)

## **設定文字方塊的自動適合類型**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) 決定文字超出容器範圍時的行為。可用來控制文字是否縮小、溢出或自動調整形狀大小。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAutofitType(TextAutofitType.Shape);

    presentation.save("autofit_type.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **設定文字方塊的錨點**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) 定義文字在形狀內的垂直對齊方式，例如頂部、中央或底部。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom);

    presentation.save("text_anchor.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **設定文字定位點**

使用[IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) 與[IParagraphFormat.getTabs](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraphformat/#getTabs--) 來設定段落的定位點。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
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

Aspose.Slides 提供[IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-)，可為文字段落設定校對語言。校對語言決定 PowerPoint 在拼寫與文法檢查時使用的語言。

以下程式碼示範如何為文字段落設定校對語言：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    FontData font = new FontData("SimSun");

    Portion textPortion = new Portion();
    textPortion.getPortionFormat().setComplexScriptFont(font);
    textPortion.getPortionFormat().setEastAsianFont(font);
    textPortion.getPortionFormat().setLatinFont(font);

    // 設定校對語言的 Id。
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **設定預設語言**

使用[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) 定義載入或建立簡報時所產生文字的預設語言。

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 新增一個帶文字的矩形形狀。
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // 檢查第一個文字段落的語言。
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    System.out.println(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **設定預設文字樣式**

若要在簡報層級套用預設文字格式，可使用[IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipresentation/#getDefaultTextStyle--)。

以下程式碼示範如何在新簡報的所有投影片中設定預設的 **粗體 14 點** 字型。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // 取得最高層級段落格式。
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

## **擷取帶有全大寫效果的文字**

在 PowerPoint 中，套用 **全大寫** 字型效果會使投影片上的文字即使原本輸入為小寫也以大寫顯示。使用 Aspose.Slides 取得此類文字段落時，函式庫會回傳原始輸入的文字。若要與顯示的文字一致，請檢查[TextCapType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/textcaptype/) 並在值為 `All` 時將回傳字串轉換為大寫。

假設在 sample2.pptx 的第一張投影片上有下列文字方塊。

![全大寫效果](all_caps_effect.png)

以下程式碼示範如何擷取套用 **全大寫** 效果的文字：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample2.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
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

**如何修改投影片上表格中的文字？**

要修改投影片上表格中的文字，請使用[ITable](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itable/)。遍歷儲存格，並透過[ICell.getTextFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/icell/#getTextFrame--) 取得文字方塊，使用[IParagraph.getParagraphFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraph/#getParagraphFormat--) 變更段落格式。

**如何在 PowerPoint 投影片的文字上套用漸層色彩？**

要為文字套用漸層色彩，請使用[IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ibaseportionformat/#getFillFormat--)。將[IFillFormat.setFillType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ifillformat/#setFillType-byte-) 設為[FillType.Gradient](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/filltype/)，並設定漸層停止點、方向與透明度。