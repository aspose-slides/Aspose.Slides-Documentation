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
description: 瞭解如何使用 Aspose.Slides for Java 建立與格式化段落、文字片段、項目符號、編號清單、縮排、HTML 內容以及段落影像。
---
## **概觀**

Aspose.Slides for Java 將文字表示為文字框、段落和文字片段的層次結構：

* [ITextFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/) 代表形狀中的文字容器，並提供對其段落集合的存取。
* [IParagraph](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraph/) 代表文字框中的單一段落，並提供對其文字片段及段落層級格式的存取。
* [IPortion](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iportion/) 代表段落內的文字執行。每個文字片段可以擁有自己的文字與字符層級格式。

因此，一個段落可以透過多個文字片段來包含不同字型、顏色、大小及其他格式的文字。

## **建立與格式化段落**

### **建立含多個文字片段的段落**

以下步驟會建立一個包含三個段落、每個段落各有三個文字片段的文字框：

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別的實例。
2. 透過索引存取相關投影片。
3. 在投影片上新增一個矩形的 [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/)。
4. 取得形狀的 [ITextFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/)。
5. 使用預設段落，並再新增兩個 [IParagraph](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraph/) 物件到文字框中。
6. 為每個段落加入足夠的 [IPortion](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iportion/) 物件，以容納三個文字片段。預設段落已包含一個空的文字片段。
7. 設定每個文字片段的文字內容。
8. 透過 [IPortion.getPortionFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iportion/#getPortionFormat--) 套用字符層級格式。
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

項目符號與編號能讓相關項目更易於瀏覽。於 Aspose.Slides 中，清單設定是透過 [IBulletFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ibulletformat/) 定義的。

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別的實例。
2. 透過索引存取相關投影片。
3. 在選取的投影片上新增一個 [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/)。
4. 取得形狀的 [ITextFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/)。
5. 從文字框中移除預設段落。
6. 為符號項目符號建立一個 [Paragraph](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/paragraph/)。
7. 將 [IBulletFormat.setType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ibulletformat/#setType-int-) 設為 [BulletType.Symbol](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/bullettype/) 並指定項目符號字元。
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

圖片項目符號讓您可以使用自訂圖像取代符號或編號。

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別的實例。
2. 透過索引存取相關投影片。
3. 新增一個 [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/) 並取得其 [ITextFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/)。
4. 從文字框中移除預設段落。
5. 載入項目符號圖像，並以 [IPPImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ippimage/) 形式加入簡報的影像集合。
6. 建立一個 [Paragraph](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/paragraph/) 並設定其文字。
7. 將 [IBulletFormat.setType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ibulletformat/#setType-int-) 設為 [BulletType.Picture](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/bullettype/)。
8. 透過 [IBulletFormat.getPicture](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ibulletformat/#getPicture--) 指定圖像，並設定項目符號高度。
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

### **建立多層次清單**

將 [IParagraphFormat.setDepth](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraphformat/#setDepth-short-) 設為不同值，即可將段落放置於清單的不同層級。最高層的深度為 `0`。

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 並存取投影片。
2. 新增一個 [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/) 並從其文字框中清除預設段落。
3. 建立四個段落並設定其項目符號符號。
4. 將它們的 [IParagraphFormat.setDepth](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraphformat/#setDepth-short-) 設為 `0`、`1`、`2`、`3`。
5. 將段落加入文字框並儲存簡報。

此 Java 範例建立四層級的項目符號清單：

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

### **自訂編號清單起始值**

使用 [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) 可為編號段落設定初始顯示的數字。

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 並在投影片上新增一個 [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/)。
2. 清除形狀文字框中的預設段落。
3. 建立三個編號段落。
4. 將 [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) 分別設定為 `2`、`3`、`7`。
5. 將段落加入文字框並儲存簡報。

此 Java 範例為每個段落指定自訂的起始編號：

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

### **設定首行縮排**

使用 [IParagraphFormat.setIndent](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraphformat/#setIndent-float-) 來控制段落的首行縮排。此方法僅移動首行相對於段落左邊界的距離，正值會將首行向右移動，其他行則保持與段落正文對齊。

當需要整段移動時，請使用 [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-)。僅需移動首行時，則使用 [IParagraphFormat.setIndent](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraphformat/#setIndent-float-)。

以下範例建立多個段落，並套用不同的 [IParagraphFormat.setIndent](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraphformat/#setIndent-float-) 值，以示範首行縮排如何影響段落佈局。

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別的實例。
2. 取得目標投影片。
3. 在投影片上新增一個矩形的 [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/)。
4. 取得形狀的 [ITextFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/) 並移除預設段落。
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

懸掛縮排是指第一行向左縮進，而其餘行保持左對齊的段落佈局。在 Aspose.Slides 中，使用 [IParagraphFormat.setIndent](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraphformat/#setIndent-float-) 並傳入負值即可將第一行向左移動。

實務上，`setMarginLeft` 定義段落正文的左側位置，`setIndent` 定義第一行相對於該左邊界的位置。若要產生懸掛縮排，請對 `setMarginLeft` 給予正值，對 `setIndent` 給予負值。

此格式在書目、參考文獻、詞彙表條目等需要換行行對齊於段落正文而非第一行第一字元的情況下十分有用。

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別的實例。
2. 取得目標投影片。
3. 在投影片上新增一個矩形的 [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/)。
4. 取得形狀的 [ITextFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/) 並移除預設段落。
5. 為每個段落呼叫正值的 [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-)。
6. 呼叫負值的 [IParagraphFormat.setIndent](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraphformat/#setIndent-float-) 以產生懸掛縮排效果。
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

[IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) 控制段落結尾標記的格式。以下範例為第二段落的結尾標記指定字型大小與拉丁字型：

1. 載入一個 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 並取得投影片。
2. 新增一個 [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/)，並清除其預設段落。
3. 建立兩個段落，並為它們加入文字片段。
4. 為第二段落的結尾標記建立一個 [PortionFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/portionformat/)。
5. 設定 [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ibaseportionformat/#setFontHeight-float-) 與 [IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-)。
6. 使用 [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) 套用格式，並儲存簡報。

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

## **匯入與匯出段落內容**

### **將 HTML 文字匯入段落**

使用 [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) 可將 HTML 標記轉換為文字框中的段落與文字片段。

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別的實例。
2. 取得投影片並新增一個 [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/)。
3. 取得形狀的 [ITextFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/) 並清除預設段落。
4. 讀取來源 HTML 檔案。
5. 將 HTML 字串傳遞給 [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-)。
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

使用 [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) 可將選取的段落範圍匯出為 HTML。

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別的實例並載入目標簡報。
2. 取得投影片，並找出包含文字的 [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/)。
3. 取得形狀的 [ITextFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/)。
4. 呼叫 [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-)，傳入起始段落索引與欲匯出的段落數目。
5. 將回傳的 HTML 字串寫入檔案。

此 Java 範例匯出第一個文字形狀的所有段落：

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

### **將段落渲染為影像**

[IParagraph.getImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraph/#getImage--) 可直接渲染單一段落，並回傳 [IImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iimage/)。使用 [IImage.save](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iimage/#save-java.lang.String-int-) 將結果儲存為檔案或串流。您不需要渲染整個形狀或自行裁切位圖。

若段落無法於父集合中找到、沒有有效的渲染範圍，或無法渲染，[IParagraph.getImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraph/#getImage--) 可能會傳回 `null`，使用前請先檢查，並在使用完畢後釋放回傳的影像。

#### **以預設比例渲染段落**

假設我們有一個名為 `sample.pptx` 的簡報檔，內含一張投影片，第一個形狀是包含三個段落的文字方塊。

![包含三個段落的文字方塊](paragraph_to_image_input.png)

以下範例於預設比例下，將第二段落渲染為 PNG 影像，並在 `finally` 區塊中正確釋放影像。

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

#### **在表格儲存格中渲染段落並設定縮放**

使用接受 `float scaleX` 與 `float scaleY` 參數的 [IParagraph.getImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraph/#getImage-float-float-) 版本，可設定水平與垂直縮放係數。以下範例建立表格，於第一個儲存格中將段落以兩倍寬高渲染，並以 PNG 影像方式儲存。

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

縮放係數 `1` 代表使用預設像素尺寸。舉例而言，水平與垂直皆設為 `2` 時，產生的影像寬高約為預設的兩倍，像素數量約為四倍。較大的係數通常能在放大或高解析度輸出時提供更銳利的文字，但也會增加記憶體使用量與檔案大小。係數小於 `1` 則會產生較小且細節較少的影像。若要維持段落的長寬比，請使用相等的水平與垂直係數；若使用不同的係數，則會分別拉伸輸出。

在需要包含形狀填色、邊框或其他視覺上下文時，仍可使用 [IShape.getImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/#getImage--) 來渲染整個形狀。若僅需段落圖像，請使用 [IParagraph.getImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraph/#getImage--)。

## **常見問題集**

**我可以完全停用文字框內的換行嗎？**

可以。將 [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) 設為停用，即可關閉換行，使文字不會在文字框邊緣斷行。

**我如何取得特定段落在投影片上的精確邊界？**

使用 [IParagraph.getRect](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraph/#getRect--) 可取得段落的外框矩形。若要取得單一文字片段的邊界，則使用 [IPortion.getRect](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iportion/#getRect--)。

**段落對齊方式（左、右、置中或兩端對齊）在哪裡設定？**

[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) 為段落層級的設定，會套用於整個段落，與個別文字片段的格式無關。

**我能為段落的一部分設定校對語言嗎？**

可以。對個別文字片段使用 [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-)，即可讓同一段落內的文字使用多種語言的校對設定。