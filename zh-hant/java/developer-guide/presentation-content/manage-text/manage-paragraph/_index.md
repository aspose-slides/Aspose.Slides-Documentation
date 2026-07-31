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
  - 項目清單
  - 段落屬性
  - 匯入 HTML
  - 文字轉 HTML
  - 段落轉 HTML
  - 段落轉影像
  - 文字轉影像
  - 匯出段落
  - PowerPoint
  - OpenDocument
  - 簡報
  - Java
  - Aspose.Slides
description: "使用 Aspose.Slides for Java 精通段落格式設定 - 在 Java 中優化 PPT、PPTX 和 ODP 簡報的對齊、間距與樣式。"
---
## **簡介**

Aspose.Slides 提供了所有您在 Java 中處理 PowerPoint 文字、段落與部件所需的介面與類別。

* Aspose.Slides 提供 [ITextFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/) 介面，讓您可以新增代表段落的物件。`ITextFame` 物件可以包含一個或多個段落（每個段落透過換行字元建立）。
* Aspose.Slides 提供 [IParagraph](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraph/) 介面，讓您可以新增代表部件的物件。`IParagraph` 物件可以包含一個或多個部件（iPortions 物件的集合）。
* Aspose.Slides 提供 [IPortion](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iportion/) 介面，讓您可以新增代表文字及其格式屬性的物件。

`IParagraph` 物件能透過底層的 `IPortion` 物件處理具有不同格式屬性的文字。

## **新增多個段落且包含多個部件**

以下步驟示範如何新增一個包含 3 個段落且每個段落包含 3 個部件的文字框：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別的實例。
2. 透過索引取得相關投影片的參考。
3. 向投影片新增一個矩形 [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/)。
4. 取得與該 [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/) 相關聯的 ITextFrame。
5. 建立兩個 [IParagraph](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraph/) 物件，並將它們加入 [ITextFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/) 的 `IParagraphs` 集合中。
6. 為每個新 `IParagraph` 建立三個 [IPortion](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iportion/) 物件（預設段落建立兩個 Portion 物件），並將每個 `IPortion` 物件加入各自 `IParagraph` 的 IPortion 集合中。
7. 為每個部件設定文字。
8. 使用 `IPortion` 物件提供的格式屬性，為每個部件套用您偏好的格式設定。
9. 儲存已修改的簡報。

此 Java 程式碼實作了新增包含部件的段落的步驟：

```java
// 實例化表示 PPTX 檔案的 Presentation 類別
Presentation pres = new Presentation();
try {
    // 存取第一張投影片
    ISlide slide = pres.getSlides().get_Item(0);

    // 新增矩形類型的 AutoShape
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // 取得 AutoShape 的 TextFrame
    ITextFrame tf = ashp.getTextFrame();

    // 建立具有不同文字格式的段落與部件
    IParagraph para0 = tf.getParagraphs().get_Item(0);
    IPortion port01 = new Portion();
    IPortion port02 = new Portion();
    para0.getPortions().add(port01);
    para0.getPortions().add(port02);

    IParagraph para1 = new Paragraph();
    tf.getParagraphs().add(para1);
    IPortion port10 = new Portion();
    IPortion port11 = new Portion();
    IPortion port12 = new Portion();
    para1.getPortions().add(port10);
    para1.getPortions().add(port11);
    para1.getPortions().add(port12);

    IParagraph para2 = new Paragraph();
    tf.getParagraphs().add(para2);
    IPortion port20 = new Portion();
    IPortion port21 = new Portion();
    IPortion port22 = new Portion();
    para2.getPortions().add(port20);
    para2.getPortions().add(port21);
    para2.getPortions().add(port22);

    for (int i = 0; i < 3; i++) 
    {
        for (int j = 0; j < 3; j++) 
        {
            IPortion portion = tf.getParagraphs().get_Item(i).getPortions().get_Item(j); 
            portion.setText("Portion0" + j);
            if (j == 0) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
                portion.getPortionFormat().setFontBold(NullableBool.True);
                portion.getPortionFormat().setFontHeight(15);
            } else if (j == 1) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
                portion.getPortionFormat().setFontItalic(NullableBool.True);
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }

    // 將 PPTX 寫入磁碟
    pres.save("multiParaPort_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **管理段落項目符號**

項目清單可協助您快速且有效率地組織與呈現資訊。使用項目符號的段落總是更易閱讀與理解。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別的實例。
2. 透過索引取得相關投影片的參考。
3. 向選取的投影片新增一個 [autoshape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/)。
4. 取得該 autoshape 的 [TextFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/)。
5. 移除 `TextFrame` 中的預設段落。
6. 使用 [Paragraph](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/paragraph/) 類別建立第一個段落實例。
7. 將段落的項目符號 `Type` 設為 `Symbol`，並設定項目符號字元。
8. 設定段落的 `Text`。
9. 為項目符號設定段落的 `Indent`。
10. 為項目符號設定顏色。
11. 設定項目符號的高度。
12. 將新段落加入 `TextFrame` 的段落集合中。
13. 新增第二個段落，並重複第 7 步至第 13 步的流程。
14. 儲存簡報。

此 Java 程式碼示範了如何新增段落項目符號：

```java
// 實例化表示 PPTX 檔案的 Presentation 類別
Presentation pres = new Presentation();
try {
    // 存取第一張投影片
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 新增並存取 Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // 取得 Autoshape 的文字框
    ITextFrame txtFrm = aShp.getTextFrame();

    // 移除預設段落
    txtFrm.getParagraphs().removeAt(0);

    // 建立段落
    Paragraph para = new Paragraph();

    // 設定段落項目符號樣式與符號
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char)8226);

    // 設定段落文字
    para.setText("Welcome to Aspose.Slides");

    // 設定項目符號縮排
    para.getParagraphFormat().setIndent(25);

    // 設定項目符號顏色
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // 設定 IsBulletHardColor 為 true 以使用自訂項目符號顏色

    // 設定項目符號高度
    para.getParagraphFormat().getBullet().setHeight(100);

    // 將段落加入文字框
    txtFrm.getParagraphs().add(para);

    // 建立第二段落
    Paragraph para2 = new Paragraph();

    // 設定段落項目符號類型與樣式
    para2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);

    // 加入段落文字
    para2.setText("This is numbered bullet");

    // 設定項目符號縮排
    para2.getParagraphFormat().setIndent(25);

    para2.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // 設定 IsBulletHardColor 為 true 以使用自訂項目符號顏色

    // 設定項目符號高度
    para2.getParagraphFormat().getBullet().setHeight(100);

    // 將段落加入文字框
    txtFrm.getParagraphs().add(para2);
    
    // 儲存已修改的簡報
    pres.save("Bullet_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **管理圖片項目符號**

項目清單可協助您快速且有效率地組織與呈現資訊。圖片段落易於閱讀與理解。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別的實例。
2. 透過索引取得相關投影片的參考。
3. 向投影片新增一個 [autoshape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/)。
4. 取得該 autoshape 的 [TextFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/)。
5. 移除 `TextFrame` 中的預設段落。
6. 使用 [Paragraph](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/paragraph/) 類別建立第一個段落實例。
7. 透過 [IPPImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ippimage/) 載入圖片。
8. 將項目符號類型設定為 [Picture](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ippimage/)，並設定圖片。
9. 設定段落的 `Text`。
10. 為項目符號設定段落的 `Indent`。
11. 為項目符號設定顏色。
12. 設定項目符號的高度。
13. 將新段落加入 `TextFrame` 的段落集合中。
14. 新增第二個段落，並依照前述步驟重複處理。
15. 儲存已修改的簡報。

此 Java 程式碼示範了如何新增與管理圖片項目符號：

```java
// 實例化表示 PPTX 檔案的 Presentation 類別
Presentation presentation = new Presentation();
try {
    // 存取第一張投影片
    ISlide slide = presentation.getSlides().get_Item(0);

    // 實例化項目符號的影像
    IPPImage picture;
    IImage image = Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    // 新增並存取 Autoshape
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // 存取 Autoshape 的文字框
    ITextFrame textFrame = autoShape.getTextFrame();

    // 移除預設段落
    textFrame.getParagraphs().removeAt(0);

    // 建立新段落
    Paragraph paragraph = new Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");

    // 設定段落項目符號樣式與影像
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // 設定項目符號高度
    paragraph.getParagraphFormat().getBullet().setHeight(100);

    // 將段落加入文字框
    textFrame.getParagraphs().add(paragraph);

    // 將簡報寫入 PPTX 檔案
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

    // 將簡報寫入 PPT 檔案
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **管理多層級項目符號**

項目清單可協助您快速且有效率地組織與呈現資訊。多層級項目符號易於閱讀與理解。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別的實例。
2. 透過索引取得相關投影片的參考。
3. 在新投影片中新增一個 [autoshape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/)。
4. 取得該 autoshape 的 [TextFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/)。
5. 移除 `TextFrame` 中的預設段落。
6. 透過 [Paragraph](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/paragraph/) 類別建立第一個段落實例，並將深度設定為 0。
7. 透過 `Paragraph` 類別建立第二個段落實例，將深度設定為 1。
8. 透過 `Paragraph` 類別建立第三個段落實例，將深度設定為 2。
9. 透過 `Paragraph` 類別建立第四個段落實例，將深度設定為 3。
10. 將新段落加入 `TextFrame` 的段落集合中。
11. 儲存已修改的簡報。

此 Java 程式碼示範了如何新增與管理多層級項目符號：

```java
// 實例化表示 PPTX 檔案的 Presentation 類別
Presentation pres = new Presentation();
try {
    // 存取第一張投影片
    ISlide slide = pres.getSlides().get_Item(0);

    // 新增並存取 Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // 取得已建立 Autoshape 的文字框
    ITextFrame text = aShp.addTextFrame("");

    // 清除預設段落
    text.getParagraphs().clear();

    // 新增第一段落
    IParagraph para1 = new Paragraph();
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char)8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // 設定項目符號層級
    para1.getParagraphFormat().setDepth((short)0);

    // 新增第二段落
    IParagraph para2 = new Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // 設定項目符號層級
    para2.getParagraphFormat().setDepth((short)1);

    // 新增第三段落
    IParagraph para3 = new Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char)8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // 設定項目符號層級
    para3.getParagraphFormat().setDepth((short)2);

    // 新增第四段落
    IParagraph para4 = new Paragraph();
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // 設定項目符號層級
    para4.getParagraphFormat().setDepth((short)3);

    // 將段落加入集合
    text.getParagraphs().add(para1);
    text.getParagraphs().add(para2);
    text.getParagraphs().add(para3);
    text.getParagraphs().add(para4);

    // 將簡報寫入 PPTX 檔案
    pres.save("MultilevelBullet.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **管理自訂編號清單的段落**

[IBulletFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ibulletformat/) 介面提供 [NumberedBulletStartWith](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) 等屬性，讓您能管理具有自訂編號或格式的段落。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別的實例。
2. 取得包含目標段落的投影片。
3. 向投影片新增一個 [autoshape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/)。
4. 取得該 autoshape 的 [TextFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/)。
5. 移除 `TextFrame` 中的預設段落。
6. 透過 [Paragraph](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/paragraph/) 類別建立第一個段落實例，並將 [NumberedBulletStartWith](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) 設為 2。
7. 透過 `Paragraph` 類別建立第二個段落實例，將 `NumberedBulletStartWith` 設為 3。
8. 透過 `Paragraph` 類別建立第三個段落實例，將 `NumberedBulletStartWith` 設為 7。
9. 將新段落加入 `TextFrame` 的段落集合中。
10. 儲存已修改的簡報。

此 Java 程式碼示範了如何新增與管理具有自訂編號或格式的段落：

```java
Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // 存取已建立 Autoshape 的文字框
    ITextFrame textFrame = shape.getTextFrame();

    // 移除預設的現有段落
    textFrame.getParagraphs().removeAt(0);

    // 第一個清單
    Paragraph paragraph1 = new Paragraph();
    paragraph1.setText("bullet 2");
    paragraph1.getParagraphFormat().setDepth((short)4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)2);
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.setText("bullet 3");
    paragraph2.getParagraphFormat().setDepth((short)4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)3);
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph2);


    Paragraph paragraph5 = new Paragraph();
    paragraph5.setText("bullet 7");
    paragraph5.getParagraphFormat().setDepth((short)4);
    paragraph5.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)7);
    paragraph5.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph5);

    presentation.save("SetCustomBulletsNumber-slides.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **設定段落首行縮排**

使用 [IParagraphFormat.setIndent](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraphformat/#setIndent-float-) 方法可控制段落的首行縮排。此方法僅會移動相對於段落左邊界的第一行。正值會將第一行向右移動，而其餘行則保持與段落本體對齊。

若需要移動整個段落，請使用 [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-)。若只需移動第一行，請使用 [IParagraphFormat.setIndent](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraphformat/#setIndent-float-)。

下列範例建立多個段落，並套用不同的縮排值，以展示首行縮排如何影響段落版面配置。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別的實例。
2. 取得目標投影片。
3. 向投影片新增一個矩形 [AutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/autoshape/)。
4. 向形狀新增空的 [TextFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/textframe/)，並移除預設段落。
5. 建立多個段落，並為它們設定不同的 [Indent](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraphformat/#setIndent-float-) 值。
6. 將段落加入文字框。
7. 儲存已修改的簡報。

此程式碼示範了如何設定段落縮排：

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape rectangleShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(FillType.NoFill);
    rectangleShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().removeAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().setMarginLeft(20f);
    firstParagraph.getParagraphFormat().setIndent(0f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().setMarginLeft(20f);
    secondParagraph.getParagraphFormat().setIndent(20f);

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().setMarginLeft(20f);
    thirdParagraph.getParagraphFormat().setIndent(40f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

結果：

![段落的首行縮排](first_line_indent.png)

## **設定段落懸掛縮排**

懸掛縮排是一種段落版面配置，第一行位於其餘行的左側。在 Aspose.Slides 中，您可使用 [IParagraphFormat.setIndent](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraphformat/#setIndent-float-) 方法達成此效果。將縮排設定為負值，即可使第一行相對於段落本體向左移動。

實務上，[IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) 定義段落本體的左側位置，而 [IParagraphFormat.setIndent](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraphformat/#setIndent-float-) 定義第一行相對於該左側的位移。若要建立懸掛縮排，請將正值的 `MarginLeft` 與負值的 `Indent` 結合使用。

此格式特別適用於書目、參考文獻、詞彙表條目等需要讓換行後的行對齊於段落本體，而非首行第一個字元的情況。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別的實例。
2. 取得目標投影片。
3. 向投影片新增一個矩形 [AutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/autoshape/)。
4. 向形狀新增空的 [TextFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/textframe/)，並移除預設段落。
5. 建立段落，為每個段落設定正值的 [MarginLeft](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-)。
6. 設定負值的 [Indent](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraphformat/#setIndent-float-)，以產生懸掛縮排效果。
7. 將段落加入文字框。
8. 儲存已修改的簡報。

此程式碼示範了如何為段落設定懸掛縮排：

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape rectangleShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(FillType.NoFill);
    rectangleShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().removeAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().setMarginLeft(40f);
    firstParagraph.getParagraphFormat().setIndent(-20f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().setMarginLeft(60f);
    secondParagraph.getParagraphFormat().setIndent(-30f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

結果：

![段落的懸掛縮排](hanging_indent.png)

## **管理段落結尾執行屬性**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別的實例。  
1. 取得包含目標段落之投影片的參考（依其位置）。  
1. 向投影片新增一個矩形 [autoshape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/)。  
1. 向該矩形新增一個含兩個段落的 [TextFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/)。  
1. 為段落設定 `FontHeight` 與字型。  
1. 為段落設定結尾屬性。  
1. 將已修改的簡報寫入 PPTX 檔案。

此 Java 程式碼示範了如何為段落設定結尾屬性：

```java
Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);

    Paragraph para1 = new Paragraph();
    para1.getPortions().add(new Portion("Sample text"));

    Paragraph para2 = new Paragraph();
    para2.getPortions().add(new Portion("Sample text 2"));

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(48);
    portionFormat.setLatinFont(new FontData("Times New Roman"));
    para2.setEndParagraphPortionFormat(portionFormat);

    shape.getTextFrame().getParagraphs().add(para1);
    shape.getTextFrame().getParagraphs().add(para2);

    pres.save(resourcesOutputPath+"pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **將 HTML 文字匯入段落**

Aspose.Slides 提供加強的 HTML 文字匯入支援，可將 HTML 文字匯入段落。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別的實例。
2. 透過索引取得相關投影片的參考。
3. 向投影片新增一個 [autoshape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/)。
4. 新增並取得 `autoshape` 的 [ITextFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/)。
5. 移除 `ITextFrame` 中的預設段落。
6. 以 TextReader 讀取來源 HTML 檔案。
7. 透過 [Paragraph](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/paragraph/) 類別建立第一個段落實例。
8. 將讀取的 TextReader 內容加入 TextFrame 的 [ParagraphCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/paragraphcollection/)。
9. 儲存已修改的簡報。

此 Java 程式碼實作了將 HTML 文字匯入段落的步驟：

```java
// 建立空的簡報實例
Presentation pres = new Presentation();
try {
    // 存取簡報的預設第一張投影片
    ISlide slide = pres.getSlides().get_Item(0);

    // 新增 AutoShape 以容納 HTML 內容
    IAutoShape ashape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10,
            (float)pres.getSlideSize().getSize().getWidth() - 20, (float)pres.getSlideSize().getSize().getHeight() - 10);

    ashape.getFillFormat().setFillType(FillType.NoFill);

    // 為形狀新增文字框
    ashape.addTextFrame("");

    // 清除已新增文字框中的所有段落
    ashape.getTextFrame().getParagraphs().clear();

    // 使用流讀取器載入 HTML 檔案
    TextReader tr = new StreamReader("file.html");

    // 將 HTML 流讀取器的文字加入文字框
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());

    // 儲存簡報
    pres.save("output_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **將段落文字匯出為 HTML**

Aspose.Slides 提供加強的文字（包含於段落）匯出為 HTML 的支援。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別的實例，並載入目標簡報。
2. 透過索引取得相關投影片的參考。
3. 取得包含欲匯出為 HTML 文字的形狀。
4. 取得該形狀的 [TextFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/textframe/)。
5. 建立 `StreamWriter` 實例，並新增新的 HTML 檔案。
6. 為 StreamWriter 提供起始索引，並匯出您偏好的段落。

此 Java 程式碼示範了如何將 PowerPoint 段落文字匯出為 HTML：

```java
// 載入簡報檔案
Presentation pres = new Presentation("ExportingHTMLText.pptx");
try {
    // 存取簡報的預設第一張投影片
    ISlide slide = pres.getSlides().get_Item(0);

    // 期望的索引
    int index = 0;

    // 存取已新增的形狀
    IAutoShape ashape = (IAutoShape) slide.getShapes().get_Item(index);

    // 建立輸出 HTML 檔案
    OutputStream os = new FileOutputStream("output.html");
    Writer writer = new OutputStreamWriter(os, "UTF-8");

    // 將第一段落匯出為 HTML
    // 透過提供段落起始索引與要複製的段落總數，將段落資料寫入 HTML
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **將段落儲存為影像**

在本節中，我們將探討兩個示例，說明如何將由 [IParagraph](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraph/) 介面表示的文字段落儲存為影像。兩個示例皆包括使用 [IShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/) 介面的 `getImage` 方法取得包含段落的形狀影像、計算段落在形狀中的邊界，並將其匯出為位圖影像。這些方法允許您從 PowerPoint 簡報中提取特定文字部分，並將其另存為單獨的影像，適用於各種後續情境。

假設我們有一個名為 sample.pptx 的簡報檔，內含一張投影片，第一個形狀是一個包含三個段落的文字方塊。

![文字方塊包含三個段落](paragraph_to_image_input.png)

**範例 1**

在此範例中，我們取得第二個段落的影像。為此，我們先從簡報的第一張投影片取得形狀的影像，然後計算該形狀文字框中第二個段落的邊界。接著將段落重新繪製到新的位圖影像中，並以 PNG 格式儲存。此方法尤其適用於需要將特定段落另存為單獨影像，同時保留文字的精確尺寸與格式的情況。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // 將形狀儲存到記憶體中作為位圖。
    IImage shapeImage = firstShape.getImage();
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // 從記憶體建立形狀位圖。
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // 計算第二段落的邊界。
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    Rectangle2D paragraphRectangle = secondParagraph.getRect();

    // 計算輸出影像的座標與尺寸（最小尺寸為 1x1 像素）。
    int imageX = (int) Math.floor(paragraphRectangle.getX());
    int imageY = (int) Math.floor(paragraphRectangle.getY());
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.getWidth()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.getHeight()));

    // 裁切形狀位圖以僅取得段落位圖。
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

結果：

![段落影像](paragraph_to_image_output.png)

**範例 2**

此範例在前一個方法的基礎上加入縮放因子。形狀影像以 `2` 的縮放因子儲存，這可在匯出段落時得到更高解析度的輸出。接著在考慮縮放比例的情況下計算段落邊界。縮放在需要更詳細影像的情境下特別有用，例如用於高品質印刷材料。

```java
float imageScaleX = 2f;
float imageScaleY = imageScaleX;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // 將形狀以縮放方式儲存至記憶體作為位圖。
    IImage shapeImage = firstShape.getImage(ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // 從記憶體建立形狀位圖。
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // 計算第二段落的邊界。
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    Rectangle2D paragraphRectangle = secondParagraph.getRect();
    paragraphRectangle.setRect(
            paragraphRectangle.getX() * imageScaleX,
            paragraphRectangle.getY() * imageScaleY,
            paragraphRectangle.getWidth() * imageScaleX,
            paragraphRectangle.getHeight() * imageScaleY
    );

    // 計算輸出影像的座標與尺寸（最低尺寸為 1x1 像素）。
    int imageX = (int) Math.floor(paragraphRectangle.getX());
    int imageY = (int) Math.floor(paragraphRectangle.getY());
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.getWidth()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.getHeight()));

    // 裁切形狀位圖以僅取得段落位圖。
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **常見問題**

**我可以完全停用文字框內的自動換行嗎？**

可以。使用文字框的換行設定（[setWrapText](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/textframeformat/#setWrapText-byte-)）可關閉換行，讓文字不會在框線處斷行。

**我要如何取得特定段落在投影片上的精確邊界？**

您可以取得段落（甚至單一部件）的邊界矩形，以了解其在投影片上的精確位置與大小。

**段落的對齊方式（左/右/置中/兩端對齊）在哪裡控制？**

[Alignment](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/paragraphformat/#setAlignment-int-) 是在 [ParagraphFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/paragraphformat/) 中的段落層級設定，會套用到整個段落，與個別部件的格式無關。

**我可以只針對段落中的部分文字（例如單個字詞）設定拼寫檢查語言嗎？**

可以。語言設定位於部件層級（[PortionFormat.setLanguageId](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-)），因此同一段落中可以同時存在多種語言。