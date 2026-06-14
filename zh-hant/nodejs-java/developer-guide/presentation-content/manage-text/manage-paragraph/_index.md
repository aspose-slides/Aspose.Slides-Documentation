---
title: 在 JavaScript 中管理 PowerPoint 文本段落
linktitle: 管理段落
type: docs
weight: 40
url: /zh-hant/nodejs-java/manage-paragraph/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js (透過 Java) 完全掌握段落格式設定—在 JavaScript 中優化 PPT、PPTX 與 ODP 簡報的對齊、間距與樣式。"
---
## **簡介**

Aspose.Slides 提供您在 Java 中處理 PowerPoint 文字、段落與文字段所需的所有類別。

* Aspose.Slides 提供 [TextFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/) 類別，讓您可以加入代表段落的物件。`TextFame` 物件可以包含一個或多個段落（每個段落透過換行字元建立）。
* Aspose.Slides 提供 [Paragraph](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraph/) 類別，讓您可以加入代表文字段的物件。`Paragraph` 物件可以包含一個或多個文字段（文字段物件的集合）。
* Aspose.Slides 提供 [Portion](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/portion/) 類別，讓您可以加入代表文字及其格式屬性的物件。

`Paragraph` 物件能透過其底層的 `Portion` 物件處理具有不同格式屬性的文字。

## **新增包含多個文字段的多段落**

以下步驟說明如何新增一個包含 3 個段落且每個段落包含 3 個文字段的文字框：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別的實例。
2. 透過索引取得相關投影片的參考。
3. 在投影片上新增一個矩形 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape/)。
4. 取得與 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape/) 相關聯的 ITextFrame。
5. 建立兩個 [Paragraph](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraph/) 物件，並將它們加入 [TextFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/) 的 `IParagraphs` 集合中。
6. 為每個新建的 `Paragraph` 建立三個 [Portion](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/portion/) 物件（預設段落建立兩個 Portion 物件），並將每個 `Portion` 物件加入各自 `Paragraph` 的 IPortion 集合中。
7. 為每個文字段設定文字。
8. 使用 `Portion` 物件提供的格式屬性，將您偏好的格式套用到每個文字段上。
9. 儲存已修改的簡報。

```javascript
// 實例化一個代表 PPTX 檔案的 Presentation 類別
var pres = new aspose.slides.Presentation();
try {
    // 存取第一張投影片
    var slide = pres.getSlides().get_Item(0);
    // 新增一個矩形類型的 AutoShape
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 300, 150);
    // 取得 AutoShape 的 TextFrame
    var tf = ashp.getTextFrame();
    // 建立具有不同文字格式的段落與文字段
    var para0 = tf.getParagraphs().get_Item(0);
    var port01 = new aspose.slides.Portion();
    var port02 = new aspose.slides.Portion();
    para0.getPortions().add(port01);
    para0.getPortions().add(port02);
    var para1 = new aspose.slides.Paragraph();
    tf.getParagraphs().add(para1);
    var port10 = new aspose.slides.Portion();
    var port11 = new aspose.slides.Portion();
    var port12 = new aspose.slides.Portion();
    para1.getPortions().add(port10);
    para1.getPortions().add(port11);
    para1.getPortions().add(port12);
    var para2 = new aspose.slides.Paragraph();
    tf.getParagraphs().add(para2);
    var port20 = new aspose.slides.Portion();
    var port21 = new aspose.slides.Portion();
    var port22 = new aspose.slides.Portion();
    para2.getPortions().add(port20);
    para2.getPortions().add(port21);
    para2.getPortions().add(port22);
    for (var i = 0; i < 3; i++) {
        for (var j = 0; j < 3; j++) {
            var portion = tf.getParagraphs().get_Item(i).getPortions().get_Item(j);
            portion.setText("Portion0" + j);
            if (j == 0) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
                portion.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
                portion.getPortionFormat().setFontHeight(15);
            } else if (j == 1) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
                portion.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }
    // 將 PPTX 寫入磁碟
    pres.save("multiParaPort_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **管理段落項目符號**

項目符號清單可協助您快速且有效率地組織與呈現資訊。使用項目符號的段落更易閱讀與理解。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別的實例。
2. 透過索引取得相關投影片的參考。
3. 在選取的投影片上新增一個 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape/)。
4. 取得該自動圖形的 [TextFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/)。
5. 移除 `TextFrame` 中的預設段落。
6. 使用 [Paragraph](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraph/) 類別建立第一個段落實例。
7. 將段落的項目符號 `Type` 設為 `Symbol`，並設定項目符號字元。
8. 設定段落的 `Text`。
9. 為項目符號設定段落的 `Indent`。
10. 設定項目符號的顏色。
11. 設定項目符號的高度。
12. 將新段落加入 `TextFrame` 的段落集合中。
13. 加入第二個段落，並重複步驟 7 至 13 所述的流程。
14. 儲存簡報。

```javascript
// 實例化一個代表 PPTX 檔案的 Presentation 類別
var pres = new aspose.slides.Presentation();
try {
    // 存取第一張投影片
    var slide = pres.getSlides().get_Item(0);
    // 新增並存取 Autoshape
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // 存取 Autoshape 的文字框
    var txtFrm = aShp.getTextFrame();
    // 移除預設段落
    txtFrm.getParagraphs().removeAt(0);
    // 建立段落
    var para = new aspose.slides.Paragraph();
    // 設定段落項目符號樣式與符號
    para.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar(8226);
    // 設定段落文字
    para.setText("Welcome to Aspose.Slides");
    // 設定項目符號縮排
    para.getParagraphFormat().setIndent(25);
    // 設定項目符號顏色
    para.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    para.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True);// 將 IsBulletHardColor 設為 true 以使用自訂項目符號顏色
    // 設定項目符號高度
    para.getParagraphFormat().getBullet().setHeight(100);
    // 將段落加入文字框
    txtFrm.getParagraphs().add(para);
    // 建立第二個段落
    var para2 = new aspose.slides.Paragraph();
    // 設定段落項目符號類型與樣式
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(aspose.slides.NumberedBulletStyle.BulletCircleNumWDBlackPlain);
    // 加入段落文字
    para2.setText("This is numbered bullet");
    // 設定項目符號縮排
    para2.getParagraphFormat().setIndent(25);
    para2.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    para2.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True);// 將 IsBulletHardColor 設為 true 以使用自訂項目符號顏色
    // 設定項目符號高度
    para2.getParagraphFormat().getBullet().setHeight(100);
    // 將段落加入文字框
    txtFrm.getParagraphs().add(para2);
    // 儲存已修改的簡報
    pres.save("Bullet_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **管理圖片項目符號**

項目符號清單可協助您快速且有效率地組織與呈現資訊。圖片段落易於閱讀與理解。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別的實例。
2. 透過索引取得相關投影片的參考。
3. 在投影片上新增一個 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape/)。
4. 取得該自動圖形的 [TextFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/)。
5. 移除 `TextFrame` 中的預設段落。
6. 使用 [Paragraph](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraph/) 類別建立第一個段落實例。
7. 在 [PPImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ppimage/) 中載入圖片。
8. 將項目符號類型設定為 [Picture](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ppimage/)，並設定圖片。
9. 設定段落的 `Text`。
10. 為項目符號設定段落的 `Indent`。
11. 設定項目符號的顏色。
12. 設定項目符號的高度。
13. 將新段落加入 `TextFrame` 的段落集合中。
14. 加入第二個段落，並依照先前步驟重複操作。
15. 儲存已修改的簡報。

```javascript
// 實例化一個代表 PPTX 檔案的 Presentation 類別
var presentation = new aspose.slides.Presentation();
try {
    // 存取第一張投影片
    var slide = presentation.getSlides().get_Item(0);
    // 實例化用於項目符號的影像
    var picture;
    var image = aspose.slides.Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // 新增並存取 Autoshape
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // 存取 Autoshape 的文字框
    var textFrame = autoShape.getTextFrame();
    // 移除預設段落
    textFrame.getParagraphs().removeAt(0);
    // 建立新段落
    var paragraph = new aspose.slides.Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    // 設定段落項目符號樣式與影像
    paragraph.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);
    // 設定項目符號高度
    paragraph.getParagraphFormat().getBullet().setHeight(100);
    // 將段落加入文字框
    textFrame.getParagraphs().add(paragraph);
    // 將簡報寫入為 PPTX 檔案
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", aspose.slides.SaveFormat.Pptx);
    // 將簡報寫入為 PPT 檔案
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", aspose.slides.SaveFormat.Ppt);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **管理多層級項目符號**

項目符號清單可協助您快速且有效率地組織與呈現資訊。多層級項目符號易於閱讀與理解。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別的實例。
2. 透過索引取得相關投影片的參考。
3. 在新投影片上新增一個 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape/)。
4. 取得該自動圖形的 [TextFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/)。
5. 移除 `TextFrame` 中的預設段落。
6. 使用 [Paragraph](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraph/) 類別建立第一個段落實例，並將深度設定為 0。
7. 使用 `Paragraph` 類別建立第二個段落實例，並將深度設定為 1。
8. 使用 `Paragraph` 類別建立第三個段落實例，並將深度設定為 2。
9. 使用 `Paragraph` 類別建立第四個段落實例，並將深度設定為 3。
10. 將新段落加入 `TextFrame` 的段落集合中。
11. 儲存已修改的簡報。

```javascript
// 實例化一個代表 PPTX 檔案的 Presentation 類別
var pres = new aspose.slides.Presentation();
try {
    // 存取第一張投影片
    var slide = pres.getSlides().get_Item(0);
    // 新增並存取 Autoshape
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // 存取已建立 Autoshape 的文字框
    var text = aShp.addTextFrame("");
    // 清除預設段落
    text.getParagraphs().clear();
    // 新增第一個段落
    var para1 = new aspose.slides.Paragraph();
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar(8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // 設定項目符號層級
    para1.getParagraphFormat().setDepth(0);
    // 新增第二個段落
    var para2 = new aspose.slides.Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // 設定項目符號層級
    para2.getParagraphFormat().setDepth(1);
    // 新增第三個段落
    var para3 = new aspose.slides.Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar(8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // 設定項目符號層級
    para3.getParagraphFormat().setDepth(2);
    // 新增第四個段落
    var para4 = new aspose.slides.Paragraph();
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // 設定項目符號層級
    para4.getParagraphFormat().setDepth(3);
    // 將段落加入集合
    text.getParagraphs().add(para1);
    text.getParagraphs().add(para2);
    text.getParagraphs().add(para3);
    text.getParagraphs().add(para4);
    // 將簡報寫入為 PPTX 檔案
    pres.save("MultilevelBullet.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **管理具有自訂編號清單的段落**

[BulletFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/bulletformat/) 類別提供 [NumberedBulletStartWith](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) 等屬性，讓您可管理具自訂編號或格式的段落。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別的實例。
2. 取得包含段落的投影片。
3. 在投影片上新增一個 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape/)。
4. 取得該自動圖形的 [TextFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/)。
5. 移除 `TextFrame` 中的預設段落。
6. 使用 [Paragraph](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraph/) 類別建立第一個段落實例，並將 [NumberedBulletStartWith](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) 設為 2。
7. 使用 `Paragraph` 類別建立第二個段落實例，並將 `NumberedBulletStartWith` 設為 3。
8. 使用 `Paragraph` 類別建立第三個段落實例，並將 `NumberedBulletStartWith` 設為 7。
9. 將新段落加入 `TextFrame` 的段落集合中。
10. 儲存已修改的簡報。

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // 存取已建立 Autoshape 的文字框
    var textFrame = shape.getTextFrame();
    // 移除預設的現有段落
    textFrame.getParagraphs().removeAt(0);
    // 第一個清單
    var paragraph1 = new aspose.slides.Paragraph();
    paragraph1.setText("bullet 2");
    paragraph1.getParagraphFormat().setDepth(4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith(2);
    paragraph1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph1);
    var paragraph2 = new aspose.slides.Paragraph();
    paragraph2.setText("bullet 3");
    paragraph2.getParagraphFormat().setDepth(4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith(3);
    paragraph2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph2);
    var paragraph5 = new aspose.slides.Paragraph();
    paragraph5.setText("bullet 7");
    paragraph5.getParagraphFormat().setDepth(4);
    paragraph5.getParagraphFormat().getBullet().setNumberedBulletStartWith(7);
    paragraph5.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph5);
    presentation.save("SetCustomBulletsNumber-slides.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **設定段落的首行縮排**

使用 [ParagraphFormat.setIndent](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraphformat/setindent/) 方法可控制段落的首行縮排。此方法僅移動第一行相對於段落左邊界的距離。正值會將第一行向右移動，而其餘行則保持與段落本體對齊。

需要移動整個段落時，請使用 [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraphformat/setmarginleft/)。僅需移動第一行時，請使用 [ParagraphFormat.setIndent](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraphformat/setindent/)。

以下範例建立多個段落，並套用不同的縮排值，以示範首行縮排對段落版面的影響。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別的實例。
2. 取得目標投影片。
3. 在投影片上新增一個矩形 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape/)。
4. 新增一個空的 [TextFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/) 到形狀，並移除預設段落。
5. 建立多個段落，並為它們設定不同的 [Indent](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraphformat/setindent/) 值。
6. 將段落加入文字框。
7. 儲存已修改的簡報。

```js
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let rectangleShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    rectangleShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    let textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().removeAt(0);

    let firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().setMarginLeft(20);
    firstParagraph.getParagraphFormat().setIndent(0);

    let secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().setMarginLeft(20);
    secondParagraph.getParagraphFormat().setIndent(20);

    let thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().setMarginLeft(20);
    thirdParagraph.getParagraphFormat().setIndent(40);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", aspose.slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

結果：

![The first-line indent of the paragraphs](first_line_indent.png)

## **設定段落的懸掛縮排**

懸掛縮排是一種段落版面配置，第一行位於其餘行的左側。於 Aspose.Slides 中，可使用 [ParagraphFormat.setIndent](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraphformat/setindent/) 方法達成此效果。將縮排設為負值，即可使第一行相對於段落本體向左移動。

實務上，[ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) 定義段落本體的左側位置，而 [ParagraphFormat.setIndent](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraphformat/setindent/) 定義第一行相對於該邊距的位置。若要建立懸掛縮排，請將 `MarginLeft` 設為正值，同時將 `Indent` 設為負值。

此格式常用於參考文獻、書目、詞彙表等，需要讓換行後的文字對齊於段落本體而非第一行首字的情況。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別的實例。
2. 取得目標投影片。
3. 在投影片上新增一個矩形 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape/)。
4. 新增一個空的 [TextFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/) 到形狀，並移除預設段落。
5. 建立段落，並為每個段落設定正值的 [MarginLeft]。
6. 設定負值的 [Indent] 以產生懸掛縮排效果。
7. 將段落加入文字框。
8. 儲存已修改的簡報。

```js
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let rectangleShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    rectangleShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    let textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().removeAt(0);

    let firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().setMarginLeft(40);
    firstParagraph.getParagraphFormat().setIndent(-20);

    let secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().setMarginLeft(60);
    secondParagraph.getParagraphFormat().setIndent(-30);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", aspose.slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

結果：

![The hanging indent of the paragraphs](hanging_indent.png)

## **管理段落結尾執行屬性**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別的實例。
2. 透過位置取得包含段落的投影片參考。
3. 在投影片上新增一個矩形 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape/)。
4. 在矩形中加入帶有兩個段落的 [TextFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/)。
5. 設定段落的 `FontHeight` 與字型。
6. 設定段落的 End 屬性。
7. 將已修改的簡報寫入為 PPTX 檔案。

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 200, 250);
    var para1 = new aspose.slides.Paragraph();
    para1.getPortions().add(new aspose.slides.Portion("Sample text"));
    var para2 = new aspose.slides.Paragraph();
    para2.getPortions().add(new aspose.slides.Portion("Sample text 2"));
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(48);
    portionFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));
    para2.setEndParagraphPortionFormat(portionFormat);
    shape.getTextFrame().getParagraphs().add(para1);
    shape.getTextFrame().getParagraphs().add(para2);
    pres.save(resourcesOutputPath + "pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **將 HTML 文字匯入段落**

Aspose.Slides 提供加強的支援，可將 HTML 文字匯入段落。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別的實例。
2. 透過索引取得相關投影片的參考。
3. 在投影片上新增一個 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape/)。
4. 新增並取得 `AutoShape` 的 [TextFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/)。
5. 移除 `TextFrame` 中的預設段落。
6. 使用 TextReader 讀取來源 HTML 檔案。
7. 使用 [Paragraph](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraph/) 類別建立第一個段落實例。
8. 將讀取的 TextReader 中的 HTML 檔案內容加入 TextFrame 的 [ParagraphCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraphcollection/)。
9. 儲存已修改的簡報。

```javascript
// 建立空的簡報實例
var pres = new aspose.slides.Presentation();
try {
    // 存取簡報的預設第一張投影片
    var slide = pres.getSlides().get_Item(0);
    // 新增 AutoShape 以容納 HTML 內容
    var ashape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, pres.getSlideSize().getSize().getWidth() - 20, pres.getSlideSize().getSize().getHeight() - 10);
    ashape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // 為形狀新增文字框
    ashape.addTextFrame("");
    // 清除已新增文字框中的所有段落
    ashape.getTextFrame().getParagraphs().clear();
    // 使用串流讀取器載入 HTML 檔案
    var tr = java.newInstanceSync("StreamReader", "file.html");
    // 從 HTML 串流讀取器將文字加入文字框
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());
    // 儲存簡報
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **匯出段落文字為 HTML**

Aspose.Slides 提供加強的支援，可將段落中的文字匯出為 HTML。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別的實例，並載入所需的簡報。
2. 透過索引取得相關投影片的參考。
3. 取得包含欲匯出為 HTML 文字的形狀。
4. 取得形狀的 [TextFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/)。
5. 建立 `StreamWriter` 實例，並新增新的 HTML 檔案。
6. 提供起始索引給 StreamWriter，並匯出您選擇的段落。

```javascript
// 載入簡報檔案
var pres = new aspose.slides.Presentation("ExportingHTMLText.pptx");
try {
    // 存取簡報的預設第一張投影片
    var slide = pres.getSlides().get_Item(0);
    // 目標索引
    var index = 0;
    // 存取已加入的圖形
    var ashape = slide.getShapes().get_Item(index);
    // 建立輸出 HTML 檔案
    var os = java.newInstanceSync("java.io.FileOutputStream", "output.html");
    var writer = java.newInstanceSync("java.io.OutputStreamWriter", os, "UTF-8");
    // 將第一段落匯出為 HTML
    // 透過提供段落起始索引與要複製的段落總數，將段落資料寫入 HTML
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **將段落儲存為影像**

本節將示範兩個範例，說明如何將由 [Paragraph](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraph/) 類別所代表的文字段落儲存為影像。兩個範例皆會取得包含段落的形狀影像（使用 [Shape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/) 類別的 `getImage` 方法），計算段落在形狀內文字框的邊界，並將其匯出為點陣圖影像。此作法可讓您從 PowerPoint 簡報中抽取特定文字段，並另存為獨立影像，以供其他情境使用。

假設我們有一個名為 sample.pptx 的簡報檔，內含一張投影片，第一個形狀是一個包含三個段落的文字方塊。

![The text box with three paragraphs](paragraph_to_image_input.png)

**範例 1**

此範例取得第二個段落的影像。先從簡報的第一張投影片中擷取形狀的影像，接著計算第二個段落在形狀文字框中的邊界，最後將段落重新繪製到新的位圖影像，並以 PNG 格式儲存。此方法特別適用於需要將特定段落另存為獨立影像，同時保留文字的精確尺寸與格式。

```java
const imageio = java.import("javax.imageio.ImageIO");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const firstShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // 將形狀儲存為記憶體中的位圖。
    const shapeImage = firstShape.getImage();
        
    const shapeImageStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    shapeImage.save(shapeImageStream, aspose.slides.ImageFormat.Png);
    shapeImage.dispose();
    shapeImageStream.flush();
    
    // 從記憶體建立形狀位圖。
    const byteBuffer = java.callMethodSync(shapeImageStream, "toByteArray");    
    const javaBytes = java.newArray("byte", Array.from(byteBuffer));
    const ByteArrayInputStream = java.import("java.io.ByteArrayInputStream");
    const shapeImageInputStream = new ByteArrayInputStream(javaBytes);
    const shapeBitmap = imageio.read(shapeImageInputStream);

    // 計算第二段的邊界。
    const secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    const paragraphRectangle = secondParagraph.getRect();

    // 計算輸出影像的座標與大小（最小尺寸為 1x1 像素）。
    const imageX = Math.floor(paragraphRectangle.getX());
    const imageY = Math.floor(paragraphRectangle.getY());
    const imageWidth = Math.max(1, Math.ceil(paragraphRectangle.getWidth()));
    const imageHeight = Math.max(1, Math.ceil(paragraphRectangle.getHeight()));

    // 裁切形狀位圖以僅取得段落位圖。
    const paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    const file = java.newInstanceSync("java.io.File", "paragraph.png");

    imageio.write(paragraphBitmap, "png", file);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

結果：

![The paragraph image](paragraph_to_image_output.png)

**範例 2**

此範例在前一個作法的基礎上加入縮放因子。形狀以縮放係數 `2` 的方式擷取為影像，讓匯出的段落擁有更高的解析度。計算段落邊界時會考慮此縮放比例。當需要更高細節的影像（例如高品質列印材料）時，縮放特別有用。

```java
const imageScaleX = 2;
const imageScaleY = imageScaleX;

const imageio = java.import("javax.imageio.ImageIO");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const firstShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // 將形狀以縮放後儲存為記憶體中的位圖。
    const shapeImage = firstShape.getImage(aspose.slides.ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
    const shapeImageStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    shapeImage.save(shapeImageStream, aspose.slides.ImageFormat.Png);
    shapeImage.dispose();

    // 從記憶體建立形狀位圖。
    const byteBuffer = java.callMethodSync(shapeImageStream, "toByteArray");    
    const javaBytes = java.newArray("byte", Array.from(byteBuffer));
    const ByteArrayInputStream = java.import("java.io.ByteArrayInputStream");
    const shapeImageInputStream = new ByteArrayInputStream(javaBytes);
    const shapeBitmap = imageio.read(shapeImageInputStream);

    // 計算第二段的邊界。
    const secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    const paragraphRectangle = secondParagraph.getRect();
    paragraphRectangle.setRect(
            paragraphRectangle.getX() * imageScaleX,
            paragraphRectangle.getY() * imageScaleY,
            paragraphRectangle.getWidth() * imageScaleX,
            paragraphRectangle.getHeight() * imageScaleY
    );

    // 計算輸出影像的座標與大小（最小尺寸為 1x1 像素）。
    const imageX = Math.floor(paragraphRectangle.getX());
    const imageY = Math.floor(paragraphRectangle.getY());
    const imageWidth = Math.max(1, Math.ceil(paragraphRectangle.getWidth()));
    const imageHeight = Math.max(1, Math.ceil(paragraphRectangle.getHeight()));

    // 裁切形狀位圖以僅取得段落位圖。
    const paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    const file = java.newInstanceSync("java.io.File", "paragraph.png");

    imageio.write(paragraphBitmap, "png", file);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **常見問題**

**我可以完全停用文字框內的換行嗎？**

可以。使用文字框的換行設定（[setWrapText](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframeformat/setwraptext/)）將換行關閉，即可避免文字在框邊緣斷行。

**我該如何取得特定段落在投影片上的精確邊界？**

您可以取得段落（甚至單一文字段）的邊界矩形，以得知其在投影片上的精確位置與尺寸。

**段落的對齊方式（左/右/置中/分散對齊）在何處設定？**

[setAlignment](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraphformat/setalignment/) 是 [ParagraphFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraphformat/) 中的段落層級設定方法，會套用於整個段落，與各文字段的個別格式無關。

**我能為段落的部分文字（例如單一單字）設定拼寫檢查語言嗎？**

可以。語言設定在文字段層級（[PortionFormat.setLanguageId](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/baseportionformat/#setLanguageId)），因此同一段落內可以同時存在多種語言。