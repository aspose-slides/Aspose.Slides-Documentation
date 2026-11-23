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
- 字型族
- 文字旋轉
- 旋轉角度
- 文字框
- 行距
- 自動適應屬性
- 文字框錨點
- 文字定位
- 預設語言
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 在 PowerPoint 與 OpenDocument 簡報中格式化與樣式化文字。自訂字型、顏色、對齊方式等。"
---
## **概觀**

本文說明如何使用 Aspose.Slides for Java 在 PowerPoint 與 OpenDocument 簡報中格式化文字。內容涵蓋背景顏色、透明度、字距、字型屬性、旋轉、段落間距、自動適應行為、文字錨點、定位點與語言設定。

除非另有說明，範例均使用 [sample.pptx](sample.pptx)。第一張投影片的第一個圖形是一個文字方塊，其第一段落包含下列文字。投影片與圖形索引皆採零基底。選取粗體部份的範例使用有效格式，包括繼承的粗體格式：

![範例文字](sample_text.png)

如需尋找與突顯文字字面值或正規表達式符合項，請參閱 [搜尋與取代文字](/slides/zh-hant/java/search-and-replace-text/)。

## **設定文字背景色彩**

使用 [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) 來設定段落的預設醒目色，或使用 [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getHighlightColor--) 針對單一文字部份設定。

以下範例將第一段落的預設醒目色設為淡灰色。對個別部份設定的醒目色會覆蓋此預設值：

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 設定整個段落的醒目顏色。
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![灰色段落](gray_paragraph.png)

以下程式碼示範如何為 **粗體字型的文字部份** 設定背景色彩：

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
            // 設定文字部份的醒目顏色。
            portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);
        }
    }

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![灰色文字部份](gray_text_portions.png)

## **對齊文字段落**

使用 [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) 於文字框內設定段落對齊方式。可設定為置中、左對齊、右對齊、兩端對齊等。

以下程式碼示範如何將段落置中對齊：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 將段落的對齊方式設定為置中。
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![置中段落](aligned_paragraph.png)

## **在同一行內對齊字型**

使用 [IParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setFontAlignment-int-) 可在同一行內垂直對齊不同字型大小的文字部份。此設定適用於整個段落，並控制每一行內的對齊方式。

以下自包含範例於同一投影片上建立四個標示文字方塊。每個段落的文字大小分別為 18、36 與 54 點，且使用不同的字型對齊方式。使用 Arial，停用自動適應與換行，並保持文字框足以容納單行文字。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int[] alignments = { FontAlignment.Baseline, FontAlignment.Top, FontAlignment.Center, FontAlignment.Bottom };
    String[] alignmentNames = { "Baseline", "Top", "Center", "Bottom" };
    float[] fontSizes = { 18f, 36f, 54f };

    for (int i = 0; i < alignments.length; i++) {
        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 20 + i * 130, 660, 120);
        shape.getFillFormat().setFillType(FillType.NoFill);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        ITextFrame textFrame = shape.getTextFrame();
        textFrame.getTextFrameFormat().setAnchoringType(TextAnchorType.Top);
        textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);
        textFrame.getTextFrameFormat().setWrapText(NullableBool.False);

        IParagraph label = textFrame.getParagraphs().get_Item(0);
        label.setText(alignmentNames[i]);
        label.getParagraphFormat().setAlignment(TextAlignment.Left);
        label.getParagraphFormat().getDefaultPortionFormat().setFontHeight(14);
        label.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new FontData("Arial"));
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

        Paragraph paragraph = new Paragraph();
        paragraph.getParagraphFormat().setFontAlignment(alignments[i]);
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left);
        paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new FontData("Arial"));
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        for (float fontSize : fontSizes) {
            Portion portion = new Portion("Ag ");
            portion.getPortionFormat().setFontHeight(fontSize);
            paragraph.getPortions().add(portion);
        }

        textFrame.getParagraphs().add(paragraph);
    }

    presentation.save("font_alignment.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![基線、上端、置中與下端字型對齊的比較（混合字型大小）](font_alignment.png)

字型對齊使用字型度量，因此個別字母的可見邊緣不一定完全對齊。範例同時包含大寫字母與下降部，以顯示基線與下端對齊的差異。字型的可用性與替代、使用的字元以及字型大小差異皆會影響結果。框架尺寸、邊距、行距、換行與自動適應亦會影響版面；比較模式時請使用相同的字型與版面設定。

此設定與 [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-)（水平段落對齊）以及 [ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-)（將文字區塊在圖形內垂直定位）不同。透過 [IBasePortionFormat.setEscapement](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setEscapement-float-) 進行的上標與下標格式會相對於基線移動個別部份，而非設定段落行的字型對齊。

## **設定文字透明度**

文字透明度透過指定給 [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getFillFormat--) 的顏色之 alpha 成分來控制。以下範例中，`alpha = 50` 為 ARGB alpha 通道值，範圍 0–255，非透明度百分比。

以下程式碼示範如何將 **整個段落** 設為透明：

```java
import com.aspose.slides.*;
import java.awt.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
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

以下程式碼示範如何將 **粗體字型的文字部份** 設為透明：

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
            // 設定文字部份的透明度。
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

![透明文字部份](transparent_text_portions.png)

## **設定文字字距**

使用 [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setSpacing-float-) 可在文字方塊中展開或縮緊字元間距。範例中加入 3 點的間距；負值則會縮緊文字。

以下 Java 程式碼示範如何在 **整個段落** 中展開字距：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 注意：使用負值來壓縮字元間距。
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // 展開字元間距。

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![段落中的字距](character_spacing_in_paragraph.png)

以下程式碼示範如何在 **粗體字型的文字部份** 中展開字距：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // 注意：使用負值來壓縮字元間距。
            portion.getPortionFormat().setSpacing(3); // 展開字元間距。
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![文字部份的字距](character_spacing_in_text_portions.png)

### **停用特定字型的字距調整（Kerning）**

在某些情況下，Aspose.Slides 渲染的文字可能較 PowerPoint 顯示的稍為緊密。這可能是因為 PowerPoint 會忽略某些字型的字距資料，即使該字型包含有效的字距資訊且在 PowerPoint 設定中已啟用字距。

若欲使渲染結果更接近 PowerPoint，可針對使用受影響字型的文字部份停用字距。將 [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) 設為大於實際字型大小的值。此範例需要「presentation.pptx」且第一張投影片的第一個圖形為文字方塊。它會檢查有效字型名稱（包括繼承的字型），並對使用 Roboto 且字型大小低於 100 點的部份設置 100 點門檻，從而停用字距：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    String targetFont = "Roboto";

    for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) {
        for (IPortion portion : paragraph.getPortions()) {
            IPortionFormatEffectiveData portionFormat = portion.getPortionFormat().getEffective();

            if ((portionFormat.getLatinFont() != null &&
                 portionFormat.getLatinFont().getFontName().equals(targetFont)) ||
                (portionFormat.getEastAsianFont() != null &&
                 portionFormat.getEastAsianFont().getFontName().equals(targetFont)) ||
                (portionFormat.getComplexScriptFont() != null &&
                 portionFormat.getComplexScriptFont().getFontName().equals(targetFont))) {
                portion.getPortionFormat().setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

對於低於門檻的符合文字，此設定會阻止字距調整，協助 Aspose.Slides 的渲染與 PowerPoint 在受此 PowerPoint 特定行為影響的字型顯示上保持一致。

## **管理文字字型屬性**

字型屬性可透過 [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) 在段落層級設定，或透過 [IPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformat/) 在單一部份設定。

以下範例將第一段落的預設字型設為 12 點 Times New Roman，並套用粗體、斜體與點狀底線。單一部份的顯式格式會覆蓋這些預設值：

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

以下範例對有效格式為粗體的部份套用 13 點 Times New Roman、斜體與點狀底線：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // 設定文字部份的字型屬性。
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

![文字部份的字型屬性](font_properties_for_text_portions.png)

## **控制文字高度正規化**

使用 [IBasePortionFormat.setNormaliseHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setNormaliseHeight-byte-) 以在重現範本排版或檢查字元高度差異時進行正規化。於 PowerPoint 中，啟用正規化會垂直拉伸或壓縮個別字元，使其在文字部份內具有統一的可見高度。它不保證不同字型之間的文字高度相等。

將屬性設為 [NullableBool.True 或 False](https://reference.aspose.com/slides/java/com.aspose.slides/nullablebool/) 以明確啟用或停用正規化。`NullableBool.NotDefined` 代表本地設定未設定，將由段落的 [getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) 繼承，並不等同於 `False`。使用 [IPortionFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformat/#getEffective--) 並讀取 [IBasePortionFormatEffectiveData.getNormaliseHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformateffectivedata/#getNormaliseHeight--) 以取得解析後的布林值。

以下自包含範例需要安裝 **Arial**。它建立兩個文字區塊，內容相同，包括大寫字母、小寫字母、下降部與重音字元，字型大小 54 點。兩段落預設皆啟用正規化。上方部份明確停用；下方部份則繼承。框架大小、邊距與段落間距相同，且皆停用換行與自動適應，以保持比較一致。程式會輸出 `False: false` 與 `NotDefined: true`，然後儲存為「text_height_normalization.pptx」。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] settings = { NullableBool.False, NullableBool.NotDefined };
    String[] settingNames = { "False", "NotDefined" };

    for (int i = 0; i < settings.length; i++) {
        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 60 + i * 200, 660, 150);
        shape.getFillFormat().setFillType(FillType.NoFill);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        ITextFrame textFrame = shape.getTextFrame();
        textFrame.setText("Hxgjpq ÅÉ 0123");
        textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);
        textFrame.getTextFrameFormat().setWrapText(NullableBool.False);
        textFrame.getTextFrameFormat().setAnchoringType(TextAnchorType.Top);
        textFrame.getTextFrameFormat().setMarginTop(0);
        textFrame.getTextFrameFormat().setMarginLeft(0);

        IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left);
        paragraph.getParagraphFormat().setSpaceBefore(0);
        paragraph.getParagraphFormat().setSpaceAfter(0);
        paragraph.getParagraphFormat().setSpaceWithin(100);
        paragraph.getParagraphFormat().getDefaultPortionFormat().setNormaliseHeight(NullableBool.True);

        IPortion portion = paragraph.getPortions().get_Item(0);
        FontData font = new FontData("Arial");
        portion.getPortionFormat().setLatinFont(font);
        portion.getPortionFormat().setFontHeight(54);
        portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
        portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
        portion.getPortionFormat().setNormaliseHeight(settings[i]);

        System.out.println(settingNames[i] + ": " + portion.getPortionFormat().getEffective().getNormaliseHeight());
    }

    presentation.save("text_height_normalization.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

以下比較圖自已儲存的簡報匯出。上排為正規化停用 (`False`)；下排為繼承啟用 (`NotDefined` → `True`)。請保留 Arial 以重現此外觀。

![Arial 54 點文字，上方正規化停用、下方繼承正規化啟用](text_height_normalization.png)

正規化會在不變更指派的 [getFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getFontHeight--) 值（字型大小）情況下變更字元高度。段落的 [setSpaceWithin](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) 控制行距；文字框的 [setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) 控制文字或其容器的調整方式。這些設定用途不同，會獨立影響整體版面。欲了解更多段落格式與繼承，請參閱 [管理段落](/slides/zh-hant/java/manage-paragraph/)。

## **套用與移除刪除線**

對文字部份使用 [IBasePortionFormat.setStrikethroughType](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setStrikethroughType-byte-) 可顯示更正、取消的詞彙或先前的價格，而不必刪除原始文字。可設定為 [TextStrikethroughType.Single 或 Double](https://reference.aspose.com/slides/java/com.aspose.slides/textstrikethroughtype/) 以在文字上方加一條或兩條線。

若要移除刪除線，傳入 [TextStrikethroughType.None](https://reference.aspose.com/slides/java/com.aspose.slides/textstrikethroughtype/#None)。此設定會明確停用效果，即使周圍的格式指定了刪除線。相比之下，[TextStrikethroughType.NotDefined](https://reference.aspose.com/slides/java/com.aspose.slides/textstrikethroughtype/#NotDefined) 會讓本地設定保持未定義，允許部份從段落等上層繼承格式，並不保證刪除線被移除。使用 [IPortionFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformat/#getEffective--) 可讀取最終格式，包括繼承值。

以下自包含範例建立三個價格比較。每個段落都有標籤、先前價格與目前價格的獨立部份，僅先前價格受刪除線影響。第一列先套用後移除刪除線；其餘列則保留單線與雙線刪除線。此設定會保留文字及其其他格式，包括粗體的先前價格。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 620, 220);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
    shape.getTextFrame().getParagraphs().clear();

    String[] labels = { "None: ", "Single: ", "Double: " };

    for (String label : labels) {
        Paragraph paragraph = new Paragraph();
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left);
        paragraph.getParagraphFormat().setSpaceAfter(20);

        IPortionFormat format = paragraph.getParagraphFormat().getDefaultPortionFormat();
        format.setFontHeight(28);
        FontData font = new FontData("Arial");
        format.setLatinFont(font);
        format.getFillFormat().setFillType(FillType.Solid);
        format.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        Portion labelPortion = new Portion(label);
        paragraph.getPortions().add(labelPortion);

        Portion previousPrice = new Portion("$100");
        previousPrice.getPortionFormat().setFontBold(NullableBool.True);
        paragraph.getPortions().add(previousPrice);
        Portion currentPrice = new Portion(" → $80");
        paragraph.getPortions().add(currentPrice);

        shape.getTextFrame().getParagraphs().add(paragraph);
    }

    IParagraphCollection paragraphs = shape.getTextFrame().getParagraphs();

    // 套用刪除線，然後明確地從第一個先前價格中移除它。
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single);
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.None);

    paragraphs.get_Item(1).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single);
    paragraphs.get_Item(2).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Double);

    presentation.save("strikethrough.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果（由上而下）：無刪除線、單線刪除線、雙線刪除線。

![先前價格無刪除線、單線刪除線與雙線刪除線的比較](strikethrough.png)

## **設定文字旋轉**

使用 [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) 可在圖形內設定預定義的文字方向。

以下程式碼將圖形內的文字方向設為 [TextVerticalType.Vertical270](https://reference.aspose.com/slides/java/com.aspose.slides/textverticaltype/)，即文字 **逆時針旋轉 90 度**：

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

## **在垂直文字中並排顯示數字**

若要在垂直的日文標籤中將兩位數字保留在一起，請將兩個數字放在同一文字部份，並對該部份呼叫 [IBasePortionFormat.setKumimoji](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setKumimoji-byte-)。範例使用 [TextVerticalType.EastAsianVertical](https://reference.aspose.com/slides/java/com.aspose.slides/textverticaltype/#EastAsianVertical) 以及 40 點 MS Gothic 作為兩個標籤的字型。傳入數字部份的 [NullableBool](https://reference.aspose.com/slides/java/com.aspose.slides/nullablebool/) 值不同。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] settings = { NullableBool.True, NullableBool.False };
    float x = 120;

    for (byte kumimoji : settings) {
        IAutoShape label = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, 48, 120, 420);
        label.getFillFormat().setFillType(FillType.NoFill);
        label.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        ITextFrame frame = label.addTextFrame("");
        frame.getTextFrameFormat().setTextVerticalType(TextVerticalType.EastAsianVertical);

        IParagraph paragraph = frame.getParagraphs().get_Item(0);
        IPortionFormat format = paragraph.getParagraphFormat().getDefaultPortionFormat();
        FontData font = new FontData("MS Gothic");
        format.setLatinFont(font);
        format.setEastAsianFont(font);
        format.setFontHeight(40);
        format.getFillFormat().setFillType(FillType.Solid);
        format.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        Portion digits = new Portion("12");
        digits.getPortionFormat().setKumimoji(kumimoji);
        
        paragraph.getPortions().clear();
        paragraph.getPortions().add(new Portion("令和"));
        paragraph.getPortions().add(digits);
        paragraph.getPortions().add(new Portion("年"));

        x += 240;
    }
    presentation.save("vertical_date.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

在 PowerPoint 中，左側標籤（`True`）的數字保持直立且相鄰顯示於 「和」 與 「年」 之間。右側標籤（`False`）的數字則順時針旋轉 90 度。周圍的日文字元在兩個標籤中皆保持直立。

![PowerPoint 中垂直日期標籤的比較：左側數字直立、右側數字旋轉](vertical_date.png)

## **為文字框設定自訂旋轉角度**

使用 [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) 可為 [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) 設定自訂旋轉角度。

以下程式碼將文字框在圖形內順時針旋轉 3 度：

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

Aspose.Slides 提供 [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-)、[IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) 與 [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) 以控制段落間距。使用方式如下：

* 正值表示以行高的百分比指定行距。
* 負值表示以點數指定行距。

以下範例將第一段落的行內間距設定為行高的 200%（雙倍行距）：

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

## **控制斷行規則**

段落的斷行規則在窄文字區塊以及混合拉丁文與東亞文字的簡報中相當有用。以下方法屬於 [IParagraphFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/)，因此會套用於整個段落：

- [setLatinLineBreak](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setLatinLineBreak-byte-) 控制拉丁文字的斷行規則。在混合文字中，變更此設定同時可能影響相鄰的東亞文字與標點的換行位置。
- [setEastAsianLineBreak](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setEastAsianLineBreak-byte-) 控制東亞文字的斷行規則，包括行首與行尾字元的限制。

這些規則不會取代 [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setWrapText-byte-)，後者會在文字框內啟用自動換行。斷行規則會在換行發生時影響版面，並不會插入換行字元。使用明確的換行字元則會在段落內強制另起一行，與可用寬度無關。

以下自包含範例建立一個包含中文與拉丁文字的窄文字區塊，明確設定兩個斷行選項，並儲存為「line_breaking.pptx」。若要實驗任一規則，只需變更對應的值，同時保持其他設定不變。範例使用 24 點 Arial 與 SimSun，框寬 160 點，水平文字框邊距為 0。呼叫 [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) 並使用 [TextAutofitType.None](https://reference.aspose.com/slides/java/com.aspose.slides/textautofittype/) 以固定文字大小與框架尺寸。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 160, 300);
    shape.getFillFormat().setFillType(FillType.NoFill);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(NullableBool.True);
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);
    textFrame.getTextFrameFormat().setMarginLeft(0);
    textFrame.getTextFrameFormat().setMarginRight(0);

    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.setText("中文排版测试，PowerPoint 中文演示。");

    IParagraphFormat format = paragraph.getParagraphFormat();
    format.setAlignment(TextAlignment.Left);
    format.getDefaultPortionFormat().setFontHeight(24);
    FontData latinFont = new FontData("Arial");
    format.getDefaultPortionFormat().setLatinFont(latinFont);
    FontData eastAsianFont = new FontData("SimSun");
    format.getDefaultPortionFormat().setEastAsianFont(eastAsianFont);
    format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    format.setLatinLineBreak(NullableBool.False);
    format.setEastAsianLineBreak(NullableBool.True);

    presentation.save("line_breaking.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **控制懸掛標點符號**

[IParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setHangingPunctuation-byte-) 允許符合條件的標點符號超出文字行的右邊緣，而不是占據下一行。它適用於整個段落，且與懸掛縮排不同。

以下自包含範例在寬度 100 點的文字框中啟用懸掛標點，並儲存為「hanging_punctuation.pptx」。使用 24 點 Arial 與水平文字框邊距為 0，最後的句號會位於「sentence」之後，並延伸至文字右邊緣之外。將屬性設為 [NullableBool.False](https://reference.aspose.com/slides/java/com.aspose.slides/nullablebool/) 以比較：在此設定下，句號會占據單獨一行。啟用換行且停用自動適應以保持可用寬度固定。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 200);
    shape.getFillFormat().setFillType(FillType.NoFill);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(NullableBool.True);
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);
    textFrame.getTextFrameFormat().setMarginLeft(0);
    textFrame.getTextFrameFormat().setMarginRight(0);

    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.setText("Simple text, next sentence.");

    IParagraphFormat format = paragraph.getParagraphFormat();
    format.setAlignment(TextAlignment.Left);
    format.getDefaultPortionFormat().setFontHeight(24);
    FontData latinFont = new FontData("Arial");
    format.getDefaultPortionFormat().setLatinFont(latinFont);
    format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    format.setHangingPunctuation(NullableBool.True);

    presentation.save("hanging_punctuation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

並非所有標點符號都能懸掛。上述 [字型與版面條件](#control-line-breaking) 亦適用於本比較：變更字型、可用寬度、邊距或自動適應設定，都可能使可見差異消失。

## **設定文字框的自動適應類型**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) 決定當文字超出其容器邊界時的行為。可用以控制文字是縮小、溢出，或自動調整圖形尺寸。以下範例將圖形設定為自動調整以適應文字，並將結果儲存為「autofit_type.pptx」。

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

若要在自動換行後計算行數，並查看文字或圖形寬度變化的結果，請參閱 [計算已呈現的行數](/slides/zh-hant/java/manage-paragraph/)。僅行數並不表示文字是否溢出其容器。

## **設定文字框的錨點**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) 定義文字在圖形內的垂直定位方式，例如置頂、置中或置底。以下範例將文字錨點設定於第一個圖形的底部，並將結果儲存為「text_anchor.pptx」。

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

## **設定文字定位點（Tabulation）**

使用 [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) 與 [IParagraphFormat.getTabs](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getTabs--) 來配置段落的定位點。以下範例將預設定位間距設為 100 點，並在 30 點處加入左對齊的定位點。此設定會影響包含定位字元的文字。

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

Aspose.Slides 提供 [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-)，可為文字部份設定校對語言。校對語言決定 PowerPoint 在拼寫與文法檢查時使用的語言。

以下範例需要「presentation.pptx」，其第一張投影片的第一個圖形為文字方塊，且至少有一個段落。它會將第一段落的內容替換為「1。」，將字型設為 SimSun，並指派簡體中文校對語言 (`zh-CN`)。結果儲存為「proofing_language.pptx」：

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

### **複製語言中繼資料**

在從範本複製多語言文字時，請同時保留 [IBasePortionFormat.getLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getLanguageId--) 與 [IBasePortionFormat.getAlternativeLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getAlternativeLanguageId--)。以下自包含範例建立一個來源部份，其語言為美式英語，備用語言為法語，並將文字與識別碼複製至新簡報中的部份。

```java
import com.aspose.slides.*;

Portion source = new Portion("Hello! Bonjour!");
source.getPortionFormat().setLanguageId("en-US");
source.getPortionFormat().setAlternativeLanguageId("fr-FR");

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 80);
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    Portion destination = new Portion();
    destination.setText(source.getText());
    destination.getPortionFormat().setLanguageId(source.getPortionFormat().getLanguageId());
    // 如果來源沒有備用語言，null 會清除目標的值。
    destination.getPortionFormat().setAlternativeLanguageId(source.getPortionFormat().getAlternativeLanguageId());
    paragraph.getPortions().add(destination);

    presentation.save("copied_language_metadata.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

若要測試沒有備用語言的來源，只需省略 `"fr-FR"` 的指派。此時備用識別碼為 `null`，相同的複製敘述會保留其缺失，而不會引入預設值，即使目標先前已指派備用語言。

這些識別碼屬於語言中繼資料。保留它們不會決定 PowerPoint 為拼寫或文法檢查選取哪個字典。

## **設定預設語言**

使用 [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) 可為載入或建立簡報時所建立的文字定義預設語言。以下範例建立一個簡報，預設文字語言為美式英語，加入文字方塊，並列印其第一個文字部份的語言為 `en-US`。

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 新增帶文字的矩形形狀。
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // 檢查第一個部份的語言。
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    System.out.println(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **設定預設文字樣式**

若要在簡報層級套用預設文字格式，使用 [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDefaultTextStyle--)。

以下範例將新簡報中頂層段落的預設字型設定為 14 點粗體，並儲存為「default_text_style.pptx」。文字會繼承這些預設值，除非更具體的格式覆寫它們。

```java
import com.aspose.slides.*;

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

## **擷取帶全大寫效果的文字**

在 PowerPoint 中，套用 **全大寫** 字型效果會使文字在投影片上顯示為大寫，即使原始輸入為小寫。使用 Aspose.Slides 取得此類文字部份時，函式庫會返回原始輸入的文字。若要匹配顯示的文字，請檢查 [TextCapType](https://reference.aspose.com/slides/java/com.aspose.slides/textcaptype/) 並在值為 `All` 時將返回的字串轉為大寫。

此範例需要「sample2.pptx」，其第一張投影片的第一個圖形為文字方塊。其第一段落的第一部份包含「Hello, Aspose!」並套用全大寫效果，如下圖所示。

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

## **常見問題集**

**如何在投影片的表格中修改文字？**

使用 [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) 迭代儲存格，並透過 [ICell.getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getTextFrame--) 更新每個儲存格的文字，並使用 [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getParagraphFormat--) 調整段落格式。

**如何在 PowerPoint 投影片的文字上套用漸層顏色？**

使用 [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getFillFormat--) 設定漸層顏色。將 [IFillFormat.setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) 設為 [FillType.Gradient](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/)，並配置漸層停止點、方向與透明度。

相關功能：[在投影片中格式化文字](/slides/zh-hant/features/text-formatting/).