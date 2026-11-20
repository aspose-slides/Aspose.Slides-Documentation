---
title: 在 Android 上格式化簡報文字
linktitle: 文字格式化
type: docs
weight: 50
url: /zh-hant/androidjava/text-formatting/
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
- 文字定位點
- 預設語言
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java 於 PowerPoint 與 OpenDocument 簡報中格式化與樣式化文字。自訂字型、色彩、對齊方式等多項設定。"
---
## **概觀**

本篇說明如何使用 Aspose.Slides for Android via Java 來格式化 PowerPoint 與 OpenDocument 簡報中的文字。內容涵蓋背景色彩、透明度、字元間距、字型屬性、旋轉、段落間距、自動調整行為、文字錨點、定位點與語言設定。

除非另有說明，範例皆使用 [sample.pptx](sample.pptx)。第一張投影片的第一個圖形是一個文字方塊，且其第一段落包含以下文字。投影片與圖形的索引皆為零基礎。選取粗體部分的範例使用有效格式，包括繼承的粗體格式：

![範例文字](sample_text.png)

若要搜尋並標示文字或正規表示式匹配，請參閱 [搜尋與取代文字](/slides/zh-hant/androidjava/search-and-replace-text/)。

## **設定文字背景色彩**

使用 [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) 來設定段落的預設標示色彩，或使用 [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getHighlightColor--) 針對個別文字區段設定。

以下範例將第一段落的預設標示顏色設定為淡灰色。個別區段的明確標示色彩會覆蓋此預設值：

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 設定整個段落的標示顏色。
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LTGRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![灰色段落](gray_paragraph.png)

以下程式碼示範如何為 **粗體字型的文字區段** 設定背景色彩：

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // 設定文字區段的標示顏色。
            portion.getPortionFormat().getHighlightColor().setColor(Color.LTGRAY);
        }
    }

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![灰色文字區段](gray_text_portions.png)

## **對齊文字段落**

使用 [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) 來設定文字框內段落的對齊方式。可設定為置中、左對齊、右對齊、兩端對齊等。

以下程式碼示範如何將段落對齊至 **置中**：

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

![對齊的段落](aligned_paragraph.png)

## **在同一行內對齊字型**

使用 [IParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setFontAlignment-int-) 讓不同字型大小的文字區段在同一行內垂直對齊。此設定套用於整個段落，並控制每一行內的對齊方式。

以下獨立範例在同一張投影片上建立四個帶標籤的文字方塊。每個段落皆以 18、36、54 點字型顯示相同文字，並使用不同的字型對齊方式。使用 Arial、停用自動調整與換列，且保持文字框足以容納單行。

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

![基線、頂端、置中與底端字型對齊的比較（混合字型大小）](font_alignment.png)

字型對齊使用字型度量，所以個別字母的可見邊緣不一定完全對齊。範例同時包含大寫字母與下延字，以協助說明基線與底端對齊的差異。字型可用性與替代、所使用的字元以及字型大小差異皆會影響結果。框架尺寸、邊距、行距、換列與自動調整也會影響版面；比較模式時請使用相同的字型與版面設定。

此設定與 [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-)（水平段落對齊）以及 [ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAnchoringType-byte-)（在圖形內垂直定位文字區塊）不同。透過 [IBasePortionFormat.setEscapement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setEscapement-float-) 進行上標與下標格式化時，會相對於基線移動個別區段，而非設定段落行的字型對齊。

## **設定文字透明度**

文字透明度是透過指派給 [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--) 的顏色之 Alpha 成分來控制。在下列範例中，`alpha = 50` 為 ARGB 透明度通道值，範圍 0–255，並非透明百分比。

以下程式碼示範如何對 **整個段落** 套用透明度：

```java
import com.aspose.slides.*;
import android.graphics.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 設定文字的填充顏色為透明色。
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.argb(alpha, 0, 0, 0));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![透明段落](transparent_paragraph.png)

以下程式碼示範如何對 **粗體字型的文字區段** 套用透明度：

```java
import com.aspose.slides.*;
import android.graphics.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // 設定文字區段的透明度。
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

![透明文字區段](transparent_text_portions.png)

## **設定文字字元間距**

使用 [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setSpacing-float-) 來擴展或收縮文字方塊中字元之間的間距。以下範例增加 3 點間距；負值則會收縮文字。

以下 Java 程式碼示範如何在 **整個段落** 中擴展字元間距：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 注意：使用負值壓縮字元間距。
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // 展開字元間距。

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![段落中的字元間距](character_spacing_in_paragraph.png)

以下程式碼示範如何在 **粗體字型的文字區段** 中擴展字元間距：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // 注意：使用負值壓縮字元間距。
            portion.getPortionFormat().setSpacing(3); // 展開字元間距。
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![文字區段中的字元間距](character_spacing_in_text_portions.png)

### **為特定字型停用字距調整（Kerning）**

在某些情況下，Aspose.Slides 渲染的文字可能看起來比 PowerPoint 中的同樣文字稍微緊密。這可能是因為 PowerPoint 會忽略某些字型的字距調整資料，即使該字型包含有效的字距資訊且在 PowerPoint 設定中已啟用字距調整。

若要使渲染結果更接近 PowerPoint，可針對使用受影響字型的文字區段停用字距調整。將 [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) 設為大於實際字型大小的值。此範例需要「presentation.pptx」且第一張投影片的第一個圖形為文字方塊。它會檢查有效字型名稱（包括繼承的字型），並為使用 Roboto 的區段設定 100 點的門檻：低於 100 點的區段將停用字距調整。

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

對於符合門檻的文字，此設定會阻止字距調整，協助讓 Aspose.Slides 的渲染與 PowerPoint 的視覺輸出保持一致，針對受此 PowerPoint 特定行為影響的字型。

## **管理文字字型屬性**

字型屬性可透過 [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) 在段落層級設定，或透過 [IPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformat/) 在個別區段設定。

以下範例將第一段落的預設字型設定為 12 點 Times New Roman，並套用粗體、斜體與點狀底線。個別區段的明確格式會覆蓋這些預設值。

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

以下範例對有效格式為粗體的區段套用 13 點 Times New Roman、斜體與點狀底線：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // 設定文字區段的字型屬性。
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

![文字區段的字型屬性](font_properties_for_text_portions.png)

## **控制文字高度正規化**

在重新製作範本排版或調查字元高度差異時，可使用 [IBasePortionFormat.setNormaliseHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setNormaliseHeight-byte-)。在 PowerPoint 中，啟用正規化會垂直伸縮個別字元，使其在文字區段內呈現統一的可見高度，但不保證不同字型之間的文字高度相同。

將屬性設定為 [NullableBool.True 或 False](https://reference.aspose.com/slides/androidjava/com.aspose.slides/nullablebool/) 以明確啟用或停用正規化。`NullableBool.NotDefined` 代表保留本地設定未設定，讓區段繼承自段落的 [getDefaultPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--)，而不等同於 `False`。可使用 [IPortionFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformat/#getEffective--) 及 [IBasePortionFormatEffectiveData.getNormaliseHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformateffectivedata/#getNormaliseHeight--) 取得最終的布林值。

以下獨立範例需要安裝 **Arial**。它建立兩個文字區塊，內容相同，包含大寫字母、小寫字母、下延字與重音字元，字型大小為 54 點。兩段落預設皆啟用正規化；上方區段明確停用，下方區段繼承設定。框架尺寸、邊距與段落間距相同，且停用換列與自動調整以保證比較一致。範例會輸出 `False: false` 與 `NotDefined: true`，最後存為「text_height_normalization.pptx」。

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

以下比較圖自已儲存的簡報匯出。上排為正規化停用 (`False`)；下排為繼承啟用 (`NotDefined` → `True`)。請保留 Arial 安裝以重現此外觀。

![Arial 54 點文字，上方正規化停用、下方繼承啟用](text_height_normalization.png)

正規化會改變字元高度而不改變所指派的 [getFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getFontHeight--) 數值，該數值指定字型的點數大小。段落的 [setSpaceWithin](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) 控制行距，而文字框的 [setAutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) 控制文字或其容器的調整方式。這些設定各自服務不同目的，且會獨立影響整體版面。欲了解更多段落格式與繼承，請參閱 [管理段落](/slides/zh-hant/androidjava/manage-paragraph/)。

## **套用與移除刪除線**

對文字區段使用 [IBasePortionFormat.setStrikethroughType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setStrikethroughType-byte-) 可表示更正、取消的詞語或先前的價格，而不必刪除原始文字。設定為 [TextStrikethroughType.Single 或 Double](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textstrikethroughtype/) 以在文字上加一條或兩條線。

若要移除刪除線，傳入 [TextStrikethroughType.None](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textstrikethroughtype/#None)。這會明確停用效果，即使周圍的格式指定了刪除線。相較之下，[TextStrikethroughType.NotDefined](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textstrikethroughtype/#NotDefined) 則保持本地設定未定義，允許區段繼承段落的格式，並不保證刪除線已被移除。可使用 [IPortionFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformat/#getEffective--) 讀取最終格式，包括繼承值。

以下獨立範例建立三個價格比較。每段落都有獨立的標籤、先前價格與目前價格區段，僅先前價格會受影響。第一排先套用再移除刪除線；其餘排分別保留單線與雙線刪除線。變更此設定可保留文字與其他格式（例如粗體的先前價格）。

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

    // 套用刪除線，然後明確從第一個先前價格移除它。
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single);
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.None);

    paragraphs.get_Item(1).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single);
    paragraphs.get_Item(2).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Double);

    presentation.save("strikethrough.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果（由上至下）：無刪除線、單線刪除線、雙線刪除線。

![先前價格無刪除線、單線刪除線與雙線刪除線的比較](strikethrough.png)

## **設定文字旋轉**

使用 [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) 來設定形狀內文字的預設垂直方向。

以下程式碼將形狀內文字方向設定為 [TextVerticalType.Vertical270](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textverticaltype/)，即文字 **逆時針旋轉 90 度**：

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

## **設定文字框的自訂旋轉角度**

使用 [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setRotationAngle-float-) 為 [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) 設定自訂旋轉角度。

以下程式碼在形狀內將文字框順時針旋轉 3 度：

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

Aspose.Slides 提供 [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-)、[IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) 與 [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) 以控制段落間距。使用方式如下：

* 使用正值指定行距為行高的百分比。
* 使用負值指定行距的點數。

以下範例將第一段落的行內間距設定為行高的 200%（即雙倍行距）：

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

## **控制換列行為**

段落的換列規則在窄文字區塊以及混合拉丁與東亞文字的簡報中非常實用。以下方法屬於 [IParagraphFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/)，因此會套用於整個段落：

- [setLatinLineBreak](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setLatinLineBreak-byte-) 控制拉丁文字的換列規則。於混合文字中，變更此設定亦可能影響相鄰的東亞文字與標點換列位置。
- [setEastAsianLineBreak](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setEastAsianLineBreak-byte-) 控制東亞文字的換列規則，包含行首與行尾字元的限制。

這些規則不會取代 [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-)，後者啟用文字框內的自動換列。規則會影響換列發生時的版面配置；它們不會插入換列字元。明確的換列會在段落內強制換行，與可用寬度無關。

以下獨立範例建立包含中文與拉丁文字的窄文字區塊，明確設定兩項換列選項並儲存為「line_breaking.pptx」。若要實驗任一規則，只需變更相對應的值，同時保持其他設定不變。範例使用 24 點 Arial 與 SimSun，框寬 160 點，水平文字框邊距為 0。呼叫 [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) 並傳入 [TextAutofitType.None](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textautofittype/)，確保文字大小與框架尺寸保持固定。

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

[IParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setHangingPunctuation-byte-) 允許符合條件的標點符號延伸至文字行的右邊緣之外，而不是佔據下一行。它套用於整個段落，且不同於懸掛縮排。

以下獨立範例在寬度為 100 點的文字框內啟用懸掛標點，並儲存為「hanging_punctuation.pptx」。使用 24 點 Arial 且水平文字框邊距為 0 時，句點會留在「sentence」之後，並延伸至右側文字邊緣。將屬性設定為 [NullableBool.False](https://reference.aspose.com/slides/androidjava/com.aspose.slides/nullablebool/) 可比較：此設定下，句點會佔據獨立一行。為了保持可用寬度固定，啟用換列且停用自動調整。

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

並非所有標點都能懸掛。上述 [字型與版面條件](#control-line-breaking) 亦適用於此比較：變更字型、可用寬度、邊距或自動調整設定，都可能使可見差異消失。

## **設定文字框的自動調整類型**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) 決定文字在超出容器邊界時的行為。使用它可控制文字是縮小、溢出，或自動調整圖形大小。以下範例將圖形設定為自動調整以適應文字，並儲存為「autofit_type.pptx」。

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

若要在自動換列後統計行數，並觀察文字或圖形寬度變化，請參閱 [計算已渲染行數](/slides/zh-hant/androidjava/manage-paragraph/)。僅行數無法判斷文字是否溢出容器。

## **設定文字框的錨點**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) 定義文字在圖形內的垂直定位方式，例如置頂、置中或置底。以下範例將文字錨點設為第一個圖形的底部，並儲存為「text_anchor.pptx」。

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

## **設定文字定位點（Tab）**

使用 [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) 與 [IParagraphFormat.getTabs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getTabs--) 來配置段落的定位點。以下範例將預設定位間距設定為 100 點，並在 30 點處加入左對齊的定位點。此設定會影響包含定位字元的文字。

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

![段落的定位點](paragraph_tabs.png)

## **設定校對語言**

Aspose.Slides 提供 [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-)，可為文字區段設定校對語言。校對語言決定 PowerPoint 在拼寫與文法檢查時使用的語言。

以下範例需要「presentation.pptx」且第一張投影片的第一個圖形為文字方塊且至少有一段落。它會將第一段落的內容替換為「1。」、將字型設為 SimSun，並指派簡體中文校對語言 (`zh-CN`)。結果儲存為「proofing_language.pptx」：

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

在從範本複製多語言文字時，請同時保留 [IBasePortionFormat.getLanguageId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getLanguageId--) 與 [IBasePortionFormat.getAlternativeLanguageId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getAlternativeLanguageId--)。以下獨立範例在來源區段設定美式英語為主要語言、法語為替代語言，並將文字與識別碼複製到新簡報的區段中。

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
    // 如果來源沒有替代語言，null 會清除目的地的值。
    destination.getPortionFormat().setAlternativeLanguageId(source.getPortionFormat().getAlternativeLanguageId());
    paragraph.getPortions().add(destination);

    presentation.save("copied_language_metadata.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

若要測試沒有替代語言的來源，只需省略 `"fr-FR"` 的指派。此時替代識別碼為 `null`，相同的複製語句會保留其缺失，不會引入預設值，即使目標先前已指派替代語言。

這些識別碼屬於語言中繼資料。保留它們不會決定 PowerPoint 會使用哪個字典進行拼寫或文法檢查。

## **設定預設語言**

使用 [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) 來定義載入或建立簡報時文字的預設語言。以下範例建立一個簡報，將預設文字語言設為美式英語，新增文字方塊，並列印其第一文字區段的語言為 `en-US`。

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 新增帶文字的矩形圖形。
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // 檢查第一個文字區段的語言。
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    System.out.println(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **設定預設文字樣式**

若要在簡報層級套用預設文字格式，請使用 [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDefaultTextStyle--)。

以下範例將 14 點粗體字型設定為新簡報中最高層段落的預設樣式，並儲存為「default_text_style.pptx」。文字會繼承這些預設，除非更具體的格式覆寫它們。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // 取得最高層段落格式。
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

## **擷取帶全部大寫效果的文字**

在 PowerPoint 中，套用 **全部大寫** (All Caps) 字型效果會使投影片上顯示的文字為大寫，即使原始輸入為小寫。使用 Aspose.Slides 取得此類文字區段時，函式庫會回傳原始輸入的文字。若要符合顯示結果，可檢查 [TextCapType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textcaptype/) 並在值為 `All` 時將返回字串轉為大寫。

此範例需要「sample2.pptx」且第一張投影片的第一個圖形為文字方塊。其第一段落的第一區段包含「Hello, Aspose!」並套用了全部大寫效果，如下所示。

![全部大寫效果](all_caps_effect.png)

以下程式碼示範如何擷取套用 **全部大寫** 效果的文字：

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

使用 [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) 逐一遍歷儲存格，並透過 [ICell.getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getTextFrame--) 取得文字框，使用 [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getParagraphFormat--) 進行段落格式設定。

**如何在 PowerPoint 投影片的文字上套用漸層顏色？**

使用 [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--) 並將 [IFillFormat.setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) 設為 [FillType.Gradient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/)，再配置漸層停點、方向與透明度。