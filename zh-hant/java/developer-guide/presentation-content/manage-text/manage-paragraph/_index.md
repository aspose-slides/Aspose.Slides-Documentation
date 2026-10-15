---
title: 在 Java 中管理 PowerPoint 文字段落
linktitle: 管理段落
type: docs
weight: 40
url: /zh-hant/java/manage-paragraph/
aliases:
  - /java/paragraph/
  - /java/portion/
keywords:
- 新增文字
- 新增段落
- 管理文字
- 管理段落
- 管理項目符號
- 段落縮排
- 懸掛縮排
- 段落項目符號
- 編號清單
- 項目符號清單
- 段落屬性
- 匯入 HTML
- 文字轉 HTML
- 段落轉 HTML
- 段落轉影像
- 文字轉影像
- 匯出段落
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Java 建立與格式化段落、字串、項目符號、編號清單、縮排、HTML 內容以及段落影像。"
---
## **概覽**

Aspose.Slides for Java 將文字表示為文字框、段落和字串的層次結構：

* [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) 代表形狀中的文字容器，並提供對其段落集合的存取。
* [IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/) 代表文字框中的一個段落，並提供對其字串與段落層級格式的存取。
* [IPortion](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/) 代表段落內的文字執行。每個字串可以具有自己的文字和字元層級的格式。

因此，一個段落可以透過使用多個字串來包含具有不同字型、顏色、大小及其他格式的文字。

## **建立與格式化段落**

在形狀的文字框中建立段落，並使用字串來格式化單獨的文字執行。本節說明如何在每個段落中結合多個字串，並套用不同的顏色、字型大小與樣式。

### **使用多個字串建立段落**

以下 Java 範例建立三個段落，每個段落包含三個由 [IParagraph.getPortions](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getPortions--) 回傳的集合中的文字執行。它重複使用預設段落及其空白字串，然後加入其餘的段落和字串。格式化透過 [IPortion.getPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/#getPortionFormat--) 進行：每個段落的第一個字串為紅色、粗體、15 點；第二個為藍色、斜體、18 點。第三個字串保留預設格式：

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);
    ITextFrame textFrame = shape.getTextFrame();

    IParagraph firstParagraph = textFrame.getParagraphs().get_Item(0);
    firstParagraph.getPortions().add(new Portion());
    firstParagraph.getPortions().add(new Portion());

    IParagraph secondParagraph = new Paragraph();
    secondParagraph.getPortions().add(new Portion());
    secondParagraph.getPortions().add(new Portion());
    secondParagraph.getPortions().add(new Portion());
    textFrame.getParagraphs().add(secondParagraph);

    IParagraph thirdParagraph = new Paragraph();
    thirdParagraph.getPortions().add(new Portion());
    thirdParagraph.getPortions().add(new Portion());
    thirdParagraph.getPortions().add(new Portion());
    textFrame.getParagraphs().add(thirdParagraph);

    int paragraphCount = textFrame.getParagraphs().getCount();
    for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
        IParagraph paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
        int portionCount = paragraph.getPortions().getCount();
        for (int portionIndex = 0; portionIndex < portionCount; portionIndex++) {
            IPortion portion = paragraph.getPortions().get_Item(portionIndex);
            portion.setText("Portion " + (paragraphIndex + 1) + "." + (portionIndex + 1));

            if (portionIndex == 0) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
                portion.getPortionFormat().setFontBold(NullableBool.True);
                portion.getPortionFormat().setFontHeight(15);
            } else if (portionIndex == 1) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
                portion.getPortionFormat().setFontItalic(NullableBool.True);
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }

    presentation.save("paragraphs_with_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **建立項目符號與編號清單**

將段落文字組織為符號、數字或自訂圖片的清單。本節範例涵蓋項目符號格式、多層次清單以及自訂起始號碼。

### **建立項目符號或編號清單**

項目符號與編號能讓相關項目更易於掃描。在 Aspose.Slides 中，清單設定透過 [IBulletFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/) 定義。

此 Java 範例在同一文字框中加入符號項目符號與編號項目。 [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-byte-) 選擇項目符號類型，而 [IBulletFormat.setChar](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setChar-char-) 提供符號，[IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-) 選擇編號樣式。兩個項目均使用黑色項目符號，高度為 100%，段落縮排為 25 點：

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph symbolParagraph = new Paragraph();
    symbolParagraph.setText("Welcome to Aspose.Slides");
    symbolParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    symbolParagraph.getParagraphFormat().getBullet().setChar((char) 0x2022);
    symbolParagraph.getParagraphFormat().setIndent(25);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    symbolParagraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    symbolParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(symbolParagraph);

    Paragraph numberedParagraph = new Paragraph();
    numberedParagraph.setText("This is a numbered item");
    numberedParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    numberedParagraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);
    numberedParagraph.getParagraphFormat().setIndent(25);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    numberedParagraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    numberedParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(numberedParagraph);

    presentation.save("bulleted_and_numbered_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **使用圖片項目符號**

使用圖片項目符號可讓您以自訂圖像取代符號或編號。

此 Java 範例將圖像加入簡報的圖像集合，作為 [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) 使用，並將其作為段落項目符號。它呼叫 [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-byte-) 以使用圖片項目符號，並透過 [IBulletFormat.getPicture](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#getPicture--) 指派圖像。 [IBulletFormat.setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setHeight-float-) 設為 100% 以相對段落文字調整項目符號大小：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage bulletImage = Images.fromFile("bullets.png");
    IPPImage presentationImage;
    try {
        presentationImage = presentation.getImages().addImage(bulletImage);
    } finally {
        bulletImage.dispose();
    }

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph = new Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(presentationImage);
    paragraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(paragraph);

    presentation.save("picture_bullet.pptx", SaveFormat.Pptx);
    presentation.save("picture_bullet.ppt", SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```

### **建立多層次清單**

設定 [IParagraphFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setDepth-short-) 以將段落放置於清單的不同層級。最高層的深度為 `0`。

此 Java 範例將 [IParagraphFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setDepth-short-) 的值從 0 設為 3，套用於四個段落，於同一文字框內建立層次結構。每個段落使用符號項目符號，且 [IBulletFormat.setChar](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setChar-char-) 在圓形項目符號與連字號之間交替，以區分相鄰層級：

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    IParagraph firstParagraph = new Paragraph();
    firstParagraph.setText("Content");
    firstParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    firstParagraph.getParagraphFormat().getBullet().setChar((char) 0x2022);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.getParagraphFormat().setDepth((short) 0);

    IParagraph secondParagraph = new Paragraph();
    secondParagraph.setText("Second level");
    secondParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    secondParagraph.getParagraphFormat().getBullet().setChar('-');
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.getParagraphFormat().setDepth((short) 1);

    IParagraph thirdParagraph = new Paragraph();
    thirdParagraph.setText("Third level");
    thirdParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    thirdParagraph.getParagraphFormat().getBullet().setChar((char) 0x2022);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    thirdParagraph.getParagraphFormat().setDepth((short) 2);

    IParagraph fourthParagraph = new Paragraph();
    fourthParagraph.setText("Fourth level");
    fourthParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    fourthParagraph.getParagraphFormat().getBullet().setChar('-');
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    fourthParagraph.getParagraphFormat().setDepth((short) 3);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);
    textFrame.getParagraphs().add(fourthParagraph);

    presentation.save("multilevel_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **以自訂值開始編號清單項目**

使用 [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) 設定編號段落的起始顯示號碼。

此 Java 範例將 [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-byte-) 設為編號，並為三個段落分別指派 [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) 的值 2、3、7。起始值為每個段落單獨設定，允許編號跳過指定的數字：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.setText("Start at 2");
    firstParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    firstParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 2);
    textFrame.getParagraphs().add(firstParagraph);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("Start at 3");
    secondParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    secondParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 3);
    textFrame.getParagraphs().add(secondParagraph);

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.setText("Start at 7");
    thirdParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    thirdParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 7);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("custom_numbered_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **控制段落佈局與結尾屬性**

調整段落的邊距與縮排，以控制首行與換行行的位置。您亦可分別格式化段落的結尾標記，而不影響可見的文字字串。

### **設定首行縮排**

使用 [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) 方法控制段落的首行縮排。此設定僅移動相對於段落左邊距的第一行。正值會將第一行向右移動，剩餘行則保持與段落主體對齊。

若需移動整個段落，請使用 [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-)。若僅需移動第一行，則使用 [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-)。

以下範例將三個段落的 [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) 設為 20 點，並將 [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) 設為 0、20、40 點。首行因而以遞增的偏移開始，換行行則保留相同的左邊距：

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.getParagraphFormat().setMarginLeft(20f);
    firstParagraph.getParagraphFormat().setIndent(0f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.getParagraphFormat().setMarginLeft(20f);
    secondParagraph.getParagraphFormat().setIndent(20f);

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    thirdParagraph.getParagraphFormat().setMarginLeft(20f);
    thirdParagraph.getParagraphFormat().setIndent(40f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![段落的首行縮排](first_line_indent.png)

### **設定懸掛縮排**

懸掛縮排是一種段落佈局，首行從其餘行的左側開始。於 Aspose.Slides 中，可透過 [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) 屬性實作。將 `Indent` 設為負值，即可使首行相對於段落主體向左移動。

實務上，[IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) 定義段落主體的左側位置，而 [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) 定義首行相對於該左側邊距的位置。若要建立懸掛縮排，將正值的 `MarginLeft` 與負值的 `Indent` 結合使用。

此格式常用於書目、參考文獻、詞彙表等段落，需讓換行行對齊於段落主體而非首行的第一個字元。

以下 Java 範例將 [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) 設為 40 與 60 點，並將 [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) 設為 -20 與 -30 點。每個段落的首行皆位於換行行左側；第二段落的懸掛縮排更深：

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.getParagraphFormat().setMarginLeft(40f);
    firstParagraph.getParagraphFormat().setIndent(-20f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.getParagraphFormat().setMarginLeft(60f);
    secondParagraph.getParagraphFormat().setIndent(-30f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![段落的懸掛縮排](hanging_indent.png)

### **設定段落結尾執行屬性**

[IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) 方法控制段落結尾標記的格式。以下範例建立一個 [PortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/portionformat/) ，將 [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setFontHeight-float-) 設為 48 點，並將 [IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-) 設為 Times New Roman。此格式被指派給第二段落的結尾標記，而可見的文字字串保持不變：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Test.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.getPortions().add(new Portion("Sample text"));

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.getPortions().add(new Portion("Sample text 2"));

    PortionFormat endParagraphFormat = new PortionFormat();
    endParagraphFormat.setFontHeight(48);
    endParagraphFormat.setLatinFont(new FontData("Times New Roman"));
    secondParagraph.setEndParagraphPortionFormat(endParagraphFormat);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("end_paragraph_format.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **計算呈現的行數**

有關影響自動換行與行尾標點的段落規則，請參閱 [Control Line Breaking](/slides/zh-hant/java/text-formatting/#control-line-breaking) 與 [Control Hanging Punctuation](/slides/zh-hant/java/text-formatting/#control-hanging-punctuation)。

使用 [IParagraph.getLinesCount](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getLinesCount--) 可計算段落在文字布局後佔用的行數（包括自動換行）。此功能在檢查簡報模板的文字長度與布局時非常有用。

段落是 [ITextFrame.getParagraphs](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParagraphs--) 中的一個項目，可能佔用多行已呈現的行。段落內的明確換行符會強制換行但不會產生新段落。自動換行則根據可用寬度產生行數，而不會在文字中插入明確的換行符。因此，僅計算段落或換行字元並不能得到實際呈現的行數。

以下範例建立一個文字形狀，計算其行數，然後縮小形狀寬度，再將文字替換為較短的字串。範例啟用 [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) 以允許換行，並使用 [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) 停用自動適應，使形狀寬度控制換行而不會自動縮小文字或調整形狀大小。每次測量皆使用 [IParagraph.getLinesCount](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getLinesCount--)。形狀尺寸以點為單位。最後，範例再加入一個段落，並將整個文字框的行數相加：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(NullableBool.True);
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);

    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
    paragraph.setText("This text demonstrates how automatic wrapping changes the number of rendered lines.");
    System.out.println("Original width: " + paragraph.getLinesCount());

    shape.setWidth(150);
    System.out.println("Narrower shape: " + paragraph.getLinesCount());

    paragraph.setText("Short text.");
    System.out.println("Shorter text: " + paragraph.getLinesCount());

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("Another paragraph.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
    textFrame.getParagraphs().add(secondParagraph);

    int totalLineCount = 0;
    for (IParagraph currentParagraph : textFrame.getParagraphs()) {
        totalLineCount += currentParagraph.getLinesCount();
    }
    System.out.println("Total lines in the text frame: " + totalLineCount);
} finally {
    presentation.dispose();
}
```

使用此文字與這些尺寸時，縮小形狀會增加行數，而以短字串取代文字則會減少行數。精確計數會受字型可用性與替代、字型大小、邊距、縮排、換行與自動適應設定的影響。檢查模板時請使用目標環境的字型與布局設定。

僅依賴行數並不能判斷文字是否溢出容器。可用高度、行高、段落與行間距以及自動適應行為同樣重要；即使是單行，若停用換行也可能超出可用寬度。

## **匯入與匯出段落內容**

使用 HTML 將文字帶入簡報，或將現有段落匯出以供其他用途。本節亦說明如何將單獨段落渲染為影像，包括表格儲存格中的段落。

### **將 HTML 文字匯入段落**

使用 [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) 將 HTML 標記轉換為文字框中的段落與字串。

此 Java 範例從檔案讀取 HTML，並將標記傳遞給 [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-)。它會清除文字框的預設段落，使框中僅保留匯入的內容。矩形形狀在投影片的每側留下 10 點的邊距：

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    float shapeWidth = (float) presentation.getSlideSize().getSize().getWidth() - 20;
    float shapeHeight = (float) presentation.getSlideSize().getSize().getHeight() - 20;
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, shapeWidth, shapeHeight);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getTextFrame().getParagraphs().clear();

    try {
        byte[] htmlBytes = Files.readAllBytes(Paths.get("file.html"));
        String html = new String(htmlBytes, StandardCharsets.UTF_8);
        shape.getTextFrame().getParagraphs().addFromHtml(html);
        presentation.save("html_text.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("The HTML file could not be read: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

### **將段落文字匯出為 HTML**

使用 [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) 可將選取的段落範圍匯出為 HTML。當在網站上重利用簡報文字時，您可能希望保留本地強調效果，同時不帶入簡報的字型、大小或文字方塊樣式。將 [TextToHtmlConversionOptions.setTextInheritanceLimit](https://reference.aspose.com/slides/java/com.aspose.slides/texttohtmlconversionoptions/#setTextInheritanceLimit-int-) 設為適當值，可控制匯出器沿用格式繼承的深度。

下載 [範例簡報](text-inheritance.pptx) 並放置於應用程式的工作目錄。其第一張投影片包含一個文字形狀，文字為「Inherited text; explicit red 18pt」。輸入特意使用了多層格式：

- 簡報的預設文字樣式提供 Calibri 字型與 28 pt 大小。
- 文字框的第一層文字樣式提供藍色文字與斜體。
- 段落明確設定為粗體。
- 第二個字串「explicit red 18pt」明確設定為紅色文字與 18 pt 大小。

以下完整範例將相同段落匯出三次。它將 [TextToHtmlConversionOptions](https://reference.aspose.com/slides/java/com.aspose.slides/texttohtmlconversionoptions/) 傳遞給匯出方法，並將每個結果寫入獨立的 UTF-8 HTML 檔案：

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("text-inheritance.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (shape instanceof IAutoShape) {
        IAutoShape textShape = (IAutoShape) shape;
        ITextFrame textFrame = textShape.getTextFrame();
        if (textFrame != null) {
            IParagraphCollection paragraphs = textFrame.getParagraphs();
            
            int[] modes = { TextInheritanceLimit.All, TextInheritanceLimit.TextBox, TextInheritanceLimit.ParagraphOnly };
            String[] fileNames = { "All.html", "TextBox.html", "ParagraphOnly.html" };

            for (int i = 0; i < modes.length; i++) {
                TextToHtmlConversionOptions options = new TextToHtmlConversionOptions();
                options.setTextInheritanceLimit(modes[i]);

                String html = paragraphs.exportToHtml(0, paragraphs.getCount(), options);
                byte[] htmlBytes = html.getBytes(StandardCharsets.UTF_8);
                try {
                    Files.write(Paths.get(fileNames[i]), htmlBytes);
                } catch (IOException exception) {
                    System.out.println("The HTML file could not be written: " + exception.getMessage());
                }
            }
        } else {
            System.out.println("The first shape does not contain a text frame.");
        }
    } else {
        System.out.println("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

產生的 HTML 包含以下第一個字串「Inherited text; 」的 CSS。表格列出相關宣告；為了清晰起見，其他產生的屬性已省略。

| 輸出 | 第一個字串的相關 CSS | 外觀 |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | 藍色、粗體、斜體文字，28 pt，Calibri 字型（若可用） |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | 藍色、粗體、斜體文字；字體與大小由頁面或瀏覽器提供 |
| `ParagraphOnly.html` | `font-weight:bold` | 粗體文字；字體、大小、顏色與斜體樣式由頁面或瀏覽器提供 |

第二個字串在三個輸出中皆保留 `color:#ff0000`、`font-size:18pt` 與 `font-weight:bold`。在 `All` 與 `TextBox` 中仍保留斜體，而在 `ParagraphOnly` 中則不保留。限制繼承不會移除明確指派給段落或字串的格式。

在同一瀏覽器中開啟這些檔案以進行比較。於兩種受限模式下，省略的 CSS 屬性會由目標頁面的樣式或瀏覽器預設解析，因此最終外觀取決於 HTML 的使用環境。

### **將段落渲染為影像**

[IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage--) 直接渲染單一段落並回傳一個 [IImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/)。可使用 [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) 將結果儲存為檔案或串流。無需渲染包含的形狀或手動裁切位圖。

[IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage--) 可能回傳 `null`，情形包括段落未在其父集合中找到、沒有有效的渲染邊界，或無法渲染。使用前請檢查結果，使用完畢後釋放回傳的影像。

#### **以預設比例渲染段落**

範例使用一個投影片，第一個形狀為包含三個段落的文字方塊。

![包含三個段落的文字方塊](paragraph_to_image_input.png)

以下範例選取索引為 1 的第二段落，呼叫 [IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage--)（未傳入比例參數）。它先檢查形狀是否包含所需段落，且渲染返回影像，然後使用 [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) 將其以 PNG 格式儲存。`finally` 區塊負責釋放影像。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (shape instanceof IAutoShape) {
        IAutoShape textShape = (IAutoShape) shape;
        ITextFrame textFrame = textShape.getTextFrame();
        if (textFrame != null && textFrame.getParagraphs().getCount() > 1) {
            IParagraph paragraph = textFrame.getParagraphs().get_Item(1);
            IImage paragraphImage = paragraph.getImage();

            if (paragraphImage != null) {
                try {
                    paragraphImage.save("paragraph.png", ImageFormat.Png);
                } finally {
                    paragraphImage.dispose();
                }
            } else {
                System.out.println("The paragraph could not be rendered.");
            }
        } else {
            System.out.println("The expected paragraph was not found.");
        }
    } else {
        System.out.println("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

結果：

![段落圖像](paragraph_to_image_output.png)

#### **在表格儲存格中以縮放渲染段落**

使用接受 `float scaleX` 與 `float scaleY` 參數的 [IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage-float-float-) 版型，可設定水平與垂直縮放係數。以下範例建立一個表格，於第一個儲存格中以兩倍的寬度與高度渲染段落，並將結果儲存為 PNG 影像。

```java
import com.aspose.slides.*;

float scaleX = 2f;
float scaleY = 2f;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = slide.getShapes().addTable(50, 50, new double[] { 300 }, new double[] { 80 });
    IParagraph paragraph = table.get_Item(0, 0).getTextFrame().getParagraphs().get_Item(0);
    paragraph.setText("Text in a table cell");

    IImage paragraphImage = paragraph.getImage(scaleX, scaleY);
    if (paragraphImage != null) {
        try {
            paragraphImage.save("table_paragraph.png", ImageFormat.Png);
        } finally {
            paragraphImage.dispose();
        }
    } else {
        System.out.println("The paragraph could not be rendered.");
    }
} finally {
    presentation.dispose();
}
```

縮放係數為 `1` 時，該軸保持預設像素大小。例如，兩個係數皆為 `2` 時，產生的影像寬高約為預設尺寸的兩倍，像素數量為原來的四倍。較大的係數通常可在放大或高解析度輸出時產生較銳利的文字，但同時會增加記憶體使用與檔案大小。係數低於 `1` 會產生較小且細節較少的影像。使用相同的係數可保留段落的長寬比例；若水平與垂直係數不同，則會分別拉伸輸出。

在需要包含形狀填充、邊框或其他視覺上下文的情況下，使用 [IShape.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getImage--) 渲染整個形狀仍然有用。若僅需段落影像，請使用 [IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage--)。

## **常見問題**

**我可以完全停用文字框內的換行嗎？**

是。將 [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) 設為停用，即可關閉換行，使行不會在文字框邊緣斷開。

**如何取得特定段落在投影片上的精確邊界？**

使用 [IParagraph.getRect](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getRect--) 可取得段落的邊界矩形。 [IPortion.getRect](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/#getRect--) 則提供單一字串的邊界。

**段落對齊（左、右、置中或兩端對齊）在何處控制？**

[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) 為段落層級設定，會套用於整個段落，不受個別字串格式影響。

若要在每行內垂直對齊字體大小不同的字串，請參閱 [在行內對齊字體](/slides/zh-hant/java/text-formatting/#align-fonts-within-a-line)。

**我可以為段落的部分文字設定校對語言嗎？**

可以。為個別字串設定 [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-)，即可讓同一段落包含多種語言的文字。