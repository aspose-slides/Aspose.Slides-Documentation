---
title: 管理 Java 中的 PowerPoint 文字段落
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
description: "了解如何使用 Aspose.Slides for Java 建立與格式化段落、Portion、項目符號、編號清單、縮排、HTML 內容以及段落影像。"
---
## **概覽**

Aspose.Slides for Java 以文字框、段落與 Portion 的層級結構來表示文字：

* [ITextFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/) 代表形狀中的文字容器，並提供對其段落集合的存取。
* [IParagraph](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraph/) 代表文字框中的一個段落，並提供對其 Portion 與段落層級格式設定的存取。
* [IPortion](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iportion/) 代表段落內的文字執行單元。每個 Portion 可以擁有自己的文字與字元層級格式設定。

因此，一個段落可透過多個 Portion 來包含不同字型、顏色、大小與其他格式設定的文字。

## **建立與格式化段落**

### **使用多個 Portion 建立段落**

以下步驟會建立一個文字框，內含三個段落，每個段落都有三個 Portion：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別的實例。
2. 依索引存取目標投影片。
3. 在投影片上加入矩形的 [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/)。
4. 存取該形狀的 [ITextFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/)。
5. 使用預設段落，並再向文字框加入兩個 [IParagraph](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraph/) 物件。
6. 為每個段落加入足夠的 [IPortion](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iportion/) 物件，使其包含三個 Portion。預設段落已包含一個空的 Portion。
7. 設定每個 Portion 的文字。
8. 透過 [IPortion.getPortionFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iportion/#getPortionFormat--) 套用字元層級格式設定。
9. 儲存已修改的簡報。

此 Java 範例實作上述步驟：

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

### **建立項目符號或編號清單**

項目符號與編號可讓相關項目更易於掃描。於 Aspose.Slides 中，清單設定是透過 [IBulletFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ibulletformat/) 定義的。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別的實例。
2. 依索引存取目標投影片。
3. 在選取的投影片上加入 [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/)。
4. 存取該形狀的 [ITextFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/)。
5. 從文字框中移除預設段落。
6. 為符號項目符號建立一個 [Paragraph](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/paragraph/)。
7. 將 [IBulletFormat.setType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ibulletformat/#setType-int-) 設為 [BulletType.Symbol](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/bullettype/)，並指定項目符號字元。
8. 設定段落文字、縮排、項目符號顏色與項目符號高度。
9. 將段落加入文字框。
10. 建立第二個段落，並將 [IBulletFormat.setType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ibulletformat/#setType-int-) 設為 [BulletType.Numbered](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/bullettype/)。
11. 設定編號項目符號樣式，並將段落加入文字框。
12. 儲存簡報。

此 Java 範例建立符號項目符號與編號項目符號：

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

圖片項目符號允許使用自訂圖像取代符號或數字。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別的實例。
2. 依索引存取目標投影片。
3. 加入 [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/) 並存取其 [ITextFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/)。
4. 從文字框中移除預設段落。
5. 載入項目符號圖像，並以 [IPPImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ippimage/) 加入簡報的影像集合。
6. 建立一個 [Paragraph](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/paragraph/) 並設定其文字。
7. 將 [IBulletFormat.setType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ibulletformat/#setType-int-) 設為 [BulletType.Picture](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/bullettype/)。
8. 透過 [IBulletFormat.getPicture](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ibulletformat/#getPicture--) 指派圖像，並設定項目符號高度。
9. 將段落加入文字框。
10. 儲存已修改的簡報。

此 Java 範例建立圖片項目符號：

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

### **建立多階層清單**

將 [IParagraphFormat.setDepth](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraphformat/#setDepth-short-) 設為不同值，可將段落放置於清單的不同層級。最高層的深度為 `0`。

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 並存取投影片。
2. 加入 [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/) 並清除其文字框中的預設段落。
3. 建立四個段落並設定其項目符號符號。
4. 將它們的 [IParagraphFormat.setDepth](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraphformat/#setDepth-short-) 分別設為 `0`、`1`、`2`、`3`。
5. 將段落加入文字框並儲存簡報。

此 Java 範例建立四層的項目符號清單：

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

### **自訂編號清單的起始值**

使用 [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) 可為編號段落設定起始數字。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 並在投影片上加入 [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/)。
2. 清除該形狀文字框中的預設段落。
3. 建立三個編號段落。
4. 分別將 [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) 設為 `2`、`3`、`7`。
5. 將段落加入文字框並儲存簡報。

此 Java 範例為每個段落指派自訂的起始編號：

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

## **控制段落版面與結尾屬性**

### **設定首行縮排**

使用 [IParagraphFormat.setIndent](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraphformat/#setIndent-float-) 可控制段落的首行縮排。此方法僅移動第一行相對於段落左側邊界的距離。正值會將第一行向右移動，而其餘行則保持與段落主體對齊。

若需要整段移動，請使用 [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-)。若僅需移動首行，則使用 [IParagraphFormat.setIndent](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraphformat/#setIndent-float-)。

下列範例建立多個段落，並對每個段落套用不同的 [IParagraphFormat.setIndent](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraphformat/#setIndent-float-) 值，以示範首行縮排如何影響段落版面。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別的實例。
2. 存取目標投影片。
3. 在投影片上加入矩形的 [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/)。
4. 存取形狀的 [ITextFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/) 並移除預設段落。
5. 建立多個段落，為它們設定不同的 [IParagraphFormat.setIndent](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraphformat/#setIndent-float-) 值。
6. 將段落加入文字框。
7. 儲存已修改的簡報。

此程式碼示範如何設定段落縮排：

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

懸掛縮排是一種段落版面配置，第一行位於其餘行的左側。在 Aspose.Slides 中，可使用 [IParagraphFormat.setIndent](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraphformat/#setIndent-float-)，傳入負值即可將第一行向左移動。

實務上，[IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) 定義段落主體的左側位置，而 [IParagraphFormat.setIndent](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraphformat/#setIndent-float-) 定義第一行相對於該邊界的位置。若要建立懸掛縮排，請將正值傳給 `setMarginLeft`，並將負值傳給 `setIndent`。

此格式常用於書目、引用、詞彙表條目等需要讓換行後的文字對齊於段落主體而非首行第一個字元的情況。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別的實例。
2. 存取目標投影片。
3. 在投影片上加入矩形的 [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/)。
4. 存取形狀的 [ITextFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/) 并移除預設段落。
5. 為每個段落傳入正值至 [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-)。
6. 傳入負值至 [IParagraphFormat.setIndent](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraphformat/#setIndent-float-) 以產生懸掛縮排效果。
7. 將段落加入文字框。
8. 儲存已修改的簡報。

此程式碼示範如何為段落設定懸掛縮排：

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

[IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) 控制段落結尾標記的格式設定。以下範例為第二個段落的結尾標記指定字型大小與拉丁字型：

1. 載入一個 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 並存取投影片。
2. 加入 [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/) 並清除其預設段落。
3. 建立兩個段落並向其加入文字 Portion。
4. 為第二個段落的結尾標記建立 [PortionFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/portionformat/)。
5. 設定 [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ibaseportionformat/#setFontHeight-float-) 和 [IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-)。
6. 以 [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) 套用格式，並儲存簡報。

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

## **計算已呈現的行數**

使用 [IParagraph.getLinesCount](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraph/#getLinesCount--) 可取得段落在排版後佔用的行數，包括自動換行。此功能在檢查簡報樣板的文字長度與版面時相當有用。

段落是 [ITextFrame.getParagraphs](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/#getParagraphs--) 中的一個項目，且可能佔用多行已呈現的行。段落內的顯式換行字元會強制產生新行，但不會形成新段落。自動換行則依可用寬度產生行，且不會在文字中插入換行字元。因此，僅計算段落或換行字元並不能得到已呈現的行數。

下列範例建立一個文字形狀，計算其行數，縮小形狀寬度，然後以較短的字串取代文字。範例啟用換行且停用自動適應，讓形狀寬度決定換行行為，而不會自動縮小文字或調整形狀大小。形狀尺寸以點為單位。最後，範例再加入另一個段落，將文字框內所有段落的行數相加。

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

使用此文字與尺寸時，縮小形狀會增加行數，而以短字串取代文字則會減少行數。實際行數會因字型可用性與替代、字型大小、邊距、縮排、換行與自動適應設定而異；檢查樣板時請使用目標環境的字型與版面設定。

僅憑行數並無法判斷文字是否溢出其容器。可用的高度、行高、段落與行間距以及自動適應行為同樣重要；即使只有一行，在未啟用換行時也可能超過可用寬度。

## **匯入與匯出段落內容**

### **將 HTML 文字匯入段落**

使用 [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) 可將 HTML 標記轉換為文字框中的段落與 Portion。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別的實例。
2. 存取投影片並加入 [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/)。
3. 存取形狀的 [ITextFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/) 並清除預設段落。
4. 讀取來源 HTML 檔案。
5. 將 HTML 字串傳入 [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-)。
6. 儲存已修改的簡報。

此 Java 範例將 HTML 匯入文字框：

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

使用 [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) 可將選定範圍的段落匯出為 HTML。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別的實例並載入目標簡報。
2. 存取投影片，找出包含文字的 [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/)。
3. 存取形狀的 [ITextFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/)。
4. 以起始段落索引與欲匯出的段落數呼叫 [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-)。
5. 將回傳的 HTML 字串寫入檔案。

此 Java 範例匯出第一個文字形狀中的所有段落：

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("ExportingHTMLText.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (shape instanceof IAutoShape) {
        IAutoShape textShape = (IAutoShape) shape;
        ITextFrame textFrame = textShape.getTextFrame();
        if (textFrame != null) {
            IParagraphCollection paragraphs = textFrame.getParagraphs();
            String html = paragraphs.exportToHtml(0, paragraphs.getCount(), null);
            try {
                Files.write(Paths.get("paragraphs.html"), html.getBytes(StandardCharsets.UTF_8));
            } catch (IOException exception) {
                System.out.println("The HTML file could not be written: " + exception.getMessage());
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

### **將段落呈現為影像**

[IParagraph.getImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraph/#getImage--) 直接渲染單一段落並傳回 [IImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iimage/)。可使用 [IImage.save](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iimage/#save-java.lang.String-int-) 將結果儲存為檔案或串流，無需渲染整個形狀或手動裁切位圖。

若段落在其父集合中找不到、沒有有效的渲染邊界，或無法渲染，則 [IParagraph.getImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraph/#getImage--) 可能傳回 `null`。請在儲存前檢查結果，並於使用完畢後釋放返回的影像。

#### **以預設比例呈現段落**

假設我們有一個名為 sample.pptx 的簡報檔，內含一張投影片，第一個形狀為包含三個段落的文字方塊。

![包含三個段落的文字方塊](paragraph_to_image_input.png)

下列範例在預設比例下，於一般文字形狀中渲染第二個段落，並以 PNG 格式儲存返回的影像。`finally` 區塊確保影像被正確釋放。

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

![段落影像](paragraph_to_image_output.png)

#### **在表格儲存格中以比例呈現段落**

使用接受 `float scaleX` 與 `float scaleY` 參數的 [IParagraph.getImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraph/#getImage-float-float-) 版型，可設定水平與垂直的比例因子。以下範例建立表格，於第一個儲存格內以雙倍寬度與高度渲染段落，並將結果儲存為 PNG 影像。

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

比例因子 `1` 代表保持預設像素大小。例如，兩個因子皆設為 `2` 時，產生的影像寬高大約是預設的兩倍，像素數量則是四倍。較大的因子通常能提供較銳利的文字，適合放大或高解析度輸出，但會增加記憶體使用量與檔案大小。因子低於 `1` 會產生較小且細節較少的影像。使用相等的因子可保留段落的長寬比；若水平與垂直因子不同，則會分別拉伸輸出。

在需要包含形狀填色、邊框或其他視覺內容時，仍可使用 [IShape.getImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/#getImage--) 來渲染整個形狀。若僅需段落影像，請使用 [IParagraph.getImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraph/#getImage--)。

## **常見問題集**

**是否可以完全停用文字框內的換行？**

可以。將 [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) 設為停用，即可關閉換行，使行不會在文字框邊緣斷開。

**如何取得特定段落在投影片上的精確邊界？**

使用 [IParagraph.getRect](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraph/#getRect--) 可取得段落的外框矩形。[IPortion.getRect](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iportion/#getRect--) 則提供單一 Portion 的邊界。

**段落對齊方式（左、右、置中或分散對齊）在哪裡設定？**

[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) 為段落層級設定，會套用於整個段落，與個別 Portion 的格式無關。

**是否能為段落的部分文字設定校對語言？**

可以。對個別 Portion 使用 [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-)，即可在同一段落中混合多種語言。