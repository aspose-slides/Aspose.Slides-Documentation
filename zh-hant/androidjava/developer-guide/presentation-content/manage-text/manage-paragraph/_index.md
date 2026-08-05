---
title: 在 Android 上管理 PowerPoint 文字段落
linktitle: 管理段落
type: docs
weight: 40
url: /zh-hant/androidjava/manage-paragraph/
aliases:
  - /androidjava/paragraph/
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
- 段落轉圖像
- 文字轉圖像
- 匯出段落
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android 完全掌握段落格式——在 Java 中優化 PPT、PPTX 與 ODP 簡報的對齊、間距與樣式。"
---
## **簡介**

Aspose.Slides 提供您在 Java 中處理 PowerPoint 文字、段落與部件所需的所有介面與類別。

* Aspose.Slides 提供 [ITextFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itextframe/) 介面，讓您可以新增代表段落的物件。`ITextFame` 物件可以包含一個或多個段落（每個段落透過換行字元建立）。
* Aspose.Slides 提供 [IParagraph](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iparagraph/) 介面，讓您可以新增代表部件的物件。`IParagraph` 物件可以包含一個或多個部件（iPortions 物件的集合）。
* Aspose.Slides 提供 [IPortion](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iportion/) 介面，讓您可以新增代表文字及其格式屬性的物件。

`IParagraph` 物件可透過其底層的 `IPortion` 物件，處理具有不同格式屬性的文字。

## **新增多個段落且每個段落包含多個文字部件**

以下步驟示範如何加入包含 3 個段落且每個段落各有 3 個部件的文字框：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別的實例。
2. 依索引取得目標投影片的參考。
3. 在投影片上新增矩形 [IAutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iautoshape/)。
4. 取得與該 [IAutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iautoshape/) 關聯的 ITextFrame。
5. 建立兩個 [IParagraph](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iparagraph/) 物件，並將它們加入 [ITextFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itextframe/) 的 `IParagraphs` 集合。
6. 為每個新的 `IParagraph`（預設段落兩個部件）建立三個 [IPortion](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iportion/) 物件，並將每個 `IPortion` 加入其各自的 IPortion 集合。
7. 為每個部件設定文字。
8. 使用 `IPortion` 物件公開的格式屬性，為每個部件套用您偏好的格式設定。
9. 儲存已修改的簡報。

以下 Java 程式碼實作上述加入段落與部件的步驟：

```java
// 實例化一個代表 PPTX 檔案的 Presentation 類別
Presentation pres = new Presentation();
try {
    // 取得第一張投影片
    ISlide slide = pres.getSlides().get_Item(0);

    // 新增一個矩形類型的 AutoShape
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

    //將 PPTX 寫入磁碟
    pres.save("multiParaPort_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **管理段落項目符號**

項目符號清單能協助您快速且有效率地組織與呈現資訊。使用項目符號的段落更易於閱讀與理解。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別的實例。
2. 依索引取得目標投影片的參考。
3. 在選取的投影片上新增 [autoshape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iautoshape/)。
4. 取得該 autoshape 的 [TextFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itextframe/)。
5. 移除 `TextFrame` 中的預設段落。
6. 使用 [Paragraph](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/paragraph/) 類別建立第一個段落實例。
7. 將段落的項目符號 `Type` 設為 `Symbol`，並設定項目符號字元。
8. 設定段落的 `Text`。
9. 為項目符號設定段落的 `Indent`。
10. 設定項目符號的顏色。
11. 設定項目符號的高度。
12. 將新段落加入 `TextFrame` 的段落集合。
13. 加入第二個段落，並重複第 7 步至第 12 步的程序。
14. 儲存簡報。

以下 Java 程式碼示範如何加入段落項目符號：

```java
// 實例化一個代表 PPTX 檔案的 Presentation 類別
Presentation pres = new Presentation();
try {
    // 取得第一張投影片
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 新增並取得 Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // 取得 Autoshape 的文字框
    ITextFrame txtFrm = aShp.getTextFrame();

    // 移除預設段落
    txtFrm.getParagraphs().removeAt(0);

    // 建立段落
    Paragraph para = new Paragraph();

    // 設定段落的項目符號樣式與符號
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

圖片清單能協助您快速且有效率地組織與呈現資訊。使用圖片項目的段落同樣易於閱讀與理解。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別的實例。
2. 依索引取得目標投影片的參考。
3. 在投影片上新增 [autoshape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iautoshape/)。
4. 取得該 autoshape 的 [TextFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itextframe/)。
5. 移除 `TextFrame` 中的預設段落。
6. 使用 [Paragraph](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/paragraph/) 類別建立第一個段落實例。
7. 於 [IPPImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ippimage/) 中載入圖片。
8. 將項目符號類型設定為 [Picture](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ippimage/)，並設定圖片。
9. 設定段落的 `Text`。
10. 為項目符號設定段落的 `Indent`。
11. 設定項目符號的顏色。
12. 設定項目符號的高度。
13. 將新段落加入 `TextFrame` 的段落集合。
14. 加入第二個段落，並依前述步驟重複操作。
15. 儲存已修改的簡報。

以下 Java 程式碼示範如何加入與管理圖片項目符號：

```java
// 實例化一個代表 PPTX 檔案的 Presentation 類別
Presentation presentation = new Presentation();
try {
    // 取得第一張投影片
    ISlide slide = presentation.getSlides().get_Item(0);

    // 實例化圖片作為項目符號
    IPPImage picture;
    IImage image = Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    // 新增並取得 Autoshape
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // 取得 Autoshape 的文字框
    ITextFrame textFrame = autoShape.getTextFrame();

    // 移除預設段落
    textFrame.getParagraphs().removeAt(0);

    // 建立新的段落
    Paragraph paragraph = new Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");

    // 設定段落的項目符號樣式與圖像
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // 設定項目符號高度
    paragraph.getParagraphFormat().getBullet().setHeight(100);

    // 將段落加入文字框
    textFrame.getParagraphs().add(paragraph);

    // 將簡報寫入為 PPTX 檔案
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

    // 將簡報寫入為 PPT 檔案
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **管理多層次項目符號**

多層次項目符號能協助您快速且有效率地組織與呈現資訊，且易於閱讀與理解。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別的實例。
2. 依索引取得目標投影片的參考。
3. 在新投影片中新增 [autoshape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iautoshape/)。
4. 取得該 autoshape 的 [TextFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itextframe/)。
5. 移除 `TextFrame` 中的預設段落。
6. 使用 [Paragraph](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/paragraph/) 類別建立第一個段落實例，並將深度設為 0。
7. 使用 `Paragraph` 類別建立第二個段落實例，並將深度設為 1。
8. 使用 `Paragraph` 類別建立第三個段落實例，並將深度設為 2。
9. 使用 `Paragraph` 類別建立第四個段落實例，並將深度設為 3。
10. 將新段落加入 `TextFrame` 的段落集合。
11. 儲存已修改的簡報。

以下 Java 程式碼示範如何加入與管理多層次項目符號：

```java
// 實例化一個代表 PPTX 檔案的 Presentation 類別
Presentation pres = new Presentation();
try {
    // 取得第一張投影片
    ISlide slide = pres.getSlides().get_Item(0);

    // 新增並取得 Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // 取得已建立 Autoshape 的文字框
    ITextFrame text = aShp.addTextFrame("");

    // 清除預設段落
    text.getParagraphs().clear();

    // 新增第一個段落
    IParagraph para1 = new Paragraph();
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char)8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // 設定項目符號層級
    para1.getParagraphFormat().setDepth((short)0);

    // 新增第二個段落
    IParagraph para2 = new Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // 設定項目符號層級
    para2.getParagraphFormat().setDepth((short)1);

    // 新增第三個段落
    IParagraph para3 = new Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char)8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // 設定項目符號層級
    para3.getParagraphFormat().setDepth((short)2);

    // 新增第四個段落
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

    // 將簡報寫入為 PPTX 檔案
    pres.save("MultilevelBullet.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **管理具有自訂編號清單的段落**

[IBulletFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ibulletformat/) 介面提供 [NumberedBulletStartWith](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) 屬性等，可讓您管理具有自訂編號或格式的段落。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別的實例。
2. 取得包含目標段落的投影片。
3. 在投影片上新增 [autoshape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iautoshape/)。
4. 取得該 autoshape 的 [TextFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itextframe/)。
5. 移除 `TextFrame` 中的預設段落。
6. 使用 [Paragraph](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/paragraph/) 類別建立第一個段落實例，並將 [NumberedBulletStartWith](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) 設為 2。
7. 使用 `Paragraph` 類別建立第二個段落實例，並將 `NumberedBulletStartWith` 設為 3。
8. 使用 `Paragraph` 類別建立第三個段落實例，並將 `NumberedBulletStartWith` 設為 7。
9. 將新段落加入 `TextFrame` 的段落集合。
10. 儲存已修改的簡報。

以下 Java 程式碼示範如何加入與管理自訂編號或格式的段落：

```java
Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // 取得已建立 Autoshape 的文字框
    ITextFrame textFrame = shape.getTextFrame();

    // 移除預設已存在的段落
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

## **設定段落的首行縮排**

使用 [IParagraphFormat.setIndent](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) 方法可控制段落的首行縮排。此方法僅移動段落第一行相對於左邊界的距離。正值會將第一行向右移動，其他行則保持與段落本體對齊。

若需整段移動，請使用 [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-)。若僅需移動第一行，則使用 `setIndent`。

以下範例建立多個段落，並套用不同的縮排值，以示範首行縮排對段落版面配置的影響。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別的實例。
2. 取得目標投影片。
3. 在投影片上新增矩形 [AutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/autoshape/)。
4. 為圖形新增空的 [TextFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/textframe/)，並移除預設段落。
5. 建立多個段落，並為每個段落設定不同的 [Indent](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) 值。
6. 將段落加入文字框。
7. 儲存已修改的簡報。

以下程式碼示範如何設定段落縮排：

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

## **設定段落的懸掛縮排**

懸掛縮排是一種段落排版方式，第一行位於其餘行的左側。於 Aspose.Slides 中，可使用 [IParagraphFormat.setIndent](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) 方法，將縮排設為負值，使第一行相對於段落本體向左移動。

實務上，`setMarginLeft` 定義段落本體的左側位置，`setIndent` 定義第一行相對於該左側的位移。若欲產生懸掛縮排，請將 `MarginLeft` 設為正值，`Indent` 設為負值。

此排版常用於書目、參考文獻、術語表等，需要讓換行後的行與段落本體左邊對齊的情況。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別的實例。
2. 取得目標投影片。
3. 在投影片上新增矩形 [AutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/autoshape/)。
4. 為圖形新增空的 [TextFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/textframe/)，並移除預設段落。
5. 建立段落，為每個段落設定正的 [MarginLeft](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) 值。
6. 設定負的 [Indent](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) 值，以產生懸掛縮排效果。
7. 將段落加入文字框。
8. 儲存已修改的簡報。

以下程式碼示範如何為段落設定懸掛縮排：

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

## **管理段落結束屬性**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別的實例。
1. 依其位置取得包含段落的投影片參考。
1. 在投影片上新增矩形 [autoshape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iautoshape/)。
1. 為矩形新增含兩個段落的 [TextFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itextframe/)。
1. 為段落設定 `FontHeight` 與字型。
1. 為段落設定結束屬性。
1. 將修改後的簡報寫入為 PPTX 檔案。

以下 Java 程式碼示範如何於 PowerPoint 中設定段落的結束屬性：

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

Aspose.Slides 提供增強的功能，將 HTML 文字匯入段落。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別的實例。
2. 依索引取得目標投影片的參考。
3. 在投影片上新增 [autoshape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iautoshape/)。
4. 為 `autoshape` 取得並使用 [ITextFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itextframe/)。
5. 移除 `ITextFrame` 中的預設段落。
6. 以 TextReader 讀取來源 HTML 檔案。
7. 使用 [Paragraph](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/paragraph/) 類別建立第一個段落實例。
8. 將讀取的 TextReader 內容加入 TextFrame 的 [ParagraphCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/paragraphcollection/)。
9. 儲存已修改的簡報。

以下 Java 程式碼實作將 HTML 文字匯入段落的步驟：

```java
// 建立空的 Presentation 實例
Presentation pres = new Presentation();
try {
    // 取得簡報的預設第一張投影片
    ISlide slide = pres.getSlides().get_Item(0);

    // 新增 AutoShape 以容納 HTML 內容
    IAutoShape ashape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10,
            (float)pres.getSlideSize().getSize().getWidth() - 20, (float)pres.getSlideSize().getSize().getHeight() - 10);

    ashape.getFillFormat().setFillType(FillType.NoFill);

    // 為圖形新增文字框
    ashape.addTextFrame("");

    // 清除新增文字框中的所有段落
    ashape.getTextFrame().getParagraphs().clear();

    // 使用流讀取器載入 HTML 檔案
    TextReader tr = new StreamReader("file.html");

    // 從 HTML 流讀取器將文字加入文字框
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());

    // 儲存簡報
    pres.save("output_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **將段落文字匯出為 HTML**

Aspose.Slides 提供增強的功能，將段落內的文字匯出為 HTML。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別的實例，並載入目標簡報。
2. 依索引取得目標投影片的參考。
3. 取得包含欲匯出為 HTML 文字的圖形。
4. 取得圖形的 [TextFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/textframe/)。
5. 建立 `StreamWriter` 實例，新增 HTML 檔案。
6. 為 StreamWriter 提供起始索引，並匯出您選擇的段落。

以下 Java 程式碼示範如何將 PowerPoint 段落文字匯出為 HTML：

```java
// 載入簡報檔案
Presentation pres = new Presentation("ExportingHTMLText.pptx");
try {
    // 取得簡報的預設第一張投影片
    ISlide slide = pres.getSlides().get_Item(0);

    // 目標索引
    int index = 0;

    // 取得已加入的圖形
    IAutoShape ashape = (IAutoShape) slide.getShapes().get_Item(index);

    // 建立輸出 HTML 檔案
    OutputStream os = new FileOutputStream("output.html");
    Writer writer = new OutputStreamWriter(os, "UTF-8");

    // 將第一段落匯出為 HTML
    // 透過提供段落起始索引與欲複製的段落總數，將段落資料寫入 HTML
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **將段落儲存為圖像**

本節將說明兩個範例，示範如何將由 [IParagraph](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iparagraph/) 介面表示的文字段落儲存為圖像。兩個範例皆包含使用 [IShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishape/) 介面的 `getImage` 方法取得包含段落的圖形圖像、計算段落在圖形內的邊界，並將其匯出為點陣圖。這些方法可讓您從 PowerPoint 簡報中擷取特定文字部份，並另存為圖像，以便在其他情境中使用。

假設我們有一個名為 sample.pptx 的簡報檔案，內含一張投影片，其第一個圖形為包含三個段落的文字方塊。

![包含三個段落的文字方塊](paragraph_to_image_input.png)

**範例 1**

本範例取得第二段落的圖像。首先從簡報的第一張投影片取得圖形影像，接著計算該圖形文字框中第二段落的邊界，然後將段落重新繪製至新的位圖圖像，最後以 PNG 格式儲存。此方法特別適合在需要將單一段落保存為獨立圖像，同時保留文字的精確尺寸與格式時使用。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // 將形狀儲存於記憶體中作為位圖。
    IImage shapeImage = firstShape.getImage();
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // 從記憶體建立形狀位圖。
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // 計算第二段落的邊界。
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    RectF paragraphRectangle = secondParagraph.getRect();

    // 計算輸出影像的座標與尺寸（最小尺寸為 1x1 像素）。
    int imageX = (int) Math.floor(paragraphRectangle.left);
    int imageY = (int) Math.floor(paragraphRectangle.top);
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.width()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.height()));

    // 裁切形狀位圖以取得僅含段落的位圖。
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

結果：

![段落圖像](paragraph_to_image_output.png)

**範例 2**

本範例在前一個方法的基礎上加入縮放因子。先以縮放係數 `2` 取得圖形影像，這可在匯出段落時產生更高解析度的輸出。然後依比例計算段落邊界。當需要更高解析度的圖像（例如用於高品質印刷）時，縮放特別有用。

```java
float imageScaleX = 2f;
float imageScaleY = imageScaleX;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // 將形狀以縮放方式儲存於記憶體中作為位圖。
    IImage shapeImage = firstShape.getImage(ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // 從記憶體建立形狀位圖。
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // 計算第二段落的邊界。
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    RectF paragraphRectangle = secondParagraph.getRect();
    paragraphRectangle.set(
            paragraphRectangle.left * imageScaleX,
            paragraphRectangle.top * imageScaleY,
            paragraphRectangle.right * imageScaleX,
            paragraphRectangle.bottom * imageScaleY
    );

    // 計算輸出影像的座標與尺寸（最小尺寸為 1x1 像素）。
    int imageX = (int) Math.floor(paragraphRectangle.left);
    int imageY = (int) Math.floor(paragraphRectangle.top);
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.width()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.height()));

    // 裁切形狀位圖以取得僅包含段落的位圖。
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **常見問題集**

**我可以完全停用文字框內的自動換行嗎？**

可以。使用文字框的換行設定（[setWrapText](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/textframeformat/#setWrapText-byte-))，將換行關閉，即可避免文字在框線處斷行。

**如何取得特定段落在投影片上的精確邊界？**

您可以取得段落（甚至單一部件）的外接矩形，藉此得知其在投影片上的精確位置與大小。

**段落的對齊方式（左/右/置中/兩端對齊）在哪裡設定？**

[Alignment](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/paragraphformat/#setAlignment-int-) 是在 [ParagraphFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/paragraphformat/) 中的段落層級設定，會套用於整個段落，與單一部件的格式無關。

**我可以只為段落中的部分文字（例如單一詞彙）設定拼寫檢查語言嗎？**

可以。語言屬性是在部件層級設定的（[PortionFormat.setLanguageId](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-))，因此同一段落中可同時存在多種語言。