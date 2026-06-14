---
title: 使用 JavaScript 管理簡報中的字體
linktitle: 管理字體
type: docs
weight: 10
url: /zh-hant/nodejs-java/manage-fonts/
keywords:
- 管理字體
- 字體屬性
- 段落
- 文字格式化
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js via Java 來控制字體：嵌入、替代並載入自訂字體，以確保 PPT、PPTX 與 ODP 簡報的清晰與一致性。"
---
## **簡介**

簡報通常同時包含文字與圖片。文字可以以多種方式格式化，無論是為了突顯特定段落與詞彙，或是符合企業樣式。文字格式化協助使用者變化簡報內容的外觀與感受。本文說明如何使用 Aspose.Slides for Node.js via Java 來設定投影片上段落文字的字型屬性。

## **管理字體相關屬性**

要使用 Aspose.Slides for Node.js via Java 管理段落的字體屬性：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation) 類別的實例。
2. 依索引取得投影片的參照。
3. 取得投影片中的 [Placeholder](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/placeholder/) 形狀，並將其型別轉換為 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape/)。
4. 從由 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape/) 所提供的 [TextFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/) 中取得 [Paragraph](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraph/)。
5. 對段落設定兩端對齊。
6. 取用 [Paragraph](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraph/) 內文字的 [Portion](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/portion/)。
7. 使用 [FontData](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fontdata/) 定義字型，並相應設定文字 [Portion](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/portion/) 的 **Font**。
   1. 設定字型為粗體。
   1. 設定字型為斜體。
8. 透過 [Portion](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/portion/) 物件所公開的 [FillFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fillformat/) 來設定字體顏色。
9. 將修改後的簡報儲存為 PPTX 檔案。

以下示範上述步驟的實作。它會接受一個未修改的簡報，並對其中一張投影片的字型進行格式化。下列截圖顯示輸入檔案以及程式碼片段如何改變它。程式碼會變更字型、顏色與字型樣式。

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**圖說：輸入檔案中的文字**|

|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**圖說：相同文字的更新後格式**|

```javascript
// 實例化一個代表 PPTX 檔案的 Presentation 物件
var pres = new aspose.slides.Presentation("FontProperties.pptx");
try {
    // 依照投影片位置取得投影片
    var slide = pres.getSlides().get_Item(0);
    // 取得投影片中的第一與第二個 placeholder，並將其轉型為 AutoShape
    var tf1 = slide.getShapes().get_Item(0).getTextFrame();
    var tf2 = slide.getShapes().get_Item(1).getTextFrame();
    // 取得第一個段落
    var para1 = tf1.getParagraphs().get_Item(0);
    var para2 = tf2.getParagraphs().get_Item(0);
    // 將段落設定為兩端對齊
    para2.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.JustifyLow);
    // 取得第一個 portion
    var port1 = para1.getPortions().get_Item(0);
    var port2 = para2.getPortions().get_Item(0);
    // 定義新字體
    var fd1 = new aspose.slides.FontData("Elephant");
    var fd2 = new aspose.slides.FontData("Castellar");
    // 將新字體指派給 portion
    port1.getPortionFormat().setLatinFont(fd1);
    port2.getPortionFormat().setLatinFont(fd2);
    // 設定字體為粗體
    port1.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    port2.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    // 設定字體為斜體
    port1.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    port2.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // 設定字體顏色
    port1.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    port2.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    // 將 PPTX 儲存至磁碟
    pres.save("WelcomeFont.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **設定文字字體屬性**
{{% alert color="primary" %}} 

如同 **管理字體相關屬性** 中所述，[Portion](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/portion/) 用於在段落中保存具有相同格式樣式的文字。本篇文章說明如何使用 Aspose.Slides for Node.js via Java 建立一個包含文字的文字方塊，然後為其定義特定字型以及字型族的各種其他屬性。

{{% /alert %}} 

建立文字方塊並設定其中文字的字型屬性：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation) 類別的實例。
2. 依索引取得投影片的參照。
3. 在投影片上新增類型為 **Rectangle** 的 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape/)。
4. 移除與該 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape/) 相關聯的填充樣式。
5. 取得該 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape/) 的 [TextFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/)。
6. 向 [TextFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/) 中加入文字。
7. 取得與 [TextFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/) 關聯的 [Portion](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/portion/) 物件。
8. 定義將用於該 [Portion](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/portion/) 的字型。
9. 使用 [Portion](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/portion/) 物件所公開的相關屬性，設定粗體、斜體、底線、顏色與高度等其他字型屬性。
10. 將修改後的簡報寫入為 PPTX 檔案。

以下示範上述步驟的實作。

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**圖說：文字的某些字體屬性已由 Aspose.Slides for Node.js via Java 設定**|

```javascript
// 實例化一個代表 PPTX 檔案的 Presentation 物件
var pres = new aspose.slides.Presentation();
try {
    // 取得第一張投影片
    var sld = pres.getSlides().get_Item(0);
    // 新增類型為 Rectangle 的 AutoShape
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 50);
    // 移除與 AutoShape 相關的任何填充樣式
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // 取得與 AutoShape 關聯的 TextFrame
    var tf = ashp.getTextFrame();
    tf.setText("Aspose TextBox");
    // 取得與 TextFrame 關聯的 Portion
    var port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
    // 為 Portion 設定字體
    port.getPortionFormat().setLatinFont(new aspose.slides.FontData("Times New Roman"));
    // 設定字體的粗體屬性
    port.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    // 設定字體的斜體屬性
    port.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // 設定字體的底線屬性
    port.getPortionFormat().setFontUnderline(aspose.slides.TextUnderlineType.Single);
    // 設定字體的高度
    port.getPortionFormat().setFontHeight(25);
    // 設定字體的顏色
    port.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    // 將簡報儲存至磁碟
    pres.save("pptxFont.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```