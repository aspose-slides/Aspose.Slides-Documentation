---
title: 在 Android 上管理簡報字型
linktitle: 管理字型
type: docs
weight: 10
url: /zh-hant/androidjava/manage-fonts/
keywords:
- 管理字型
- 字型屬性
- 段落
- 文字格式化
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "在 Java 中使用 Aspose.Slides for Android 控制字型：嵌入、替代並載入自訂字型，以確保 PPT、PPTX 與 ODP 簡報清晰、符合品牌且一致。"
---
## **概述**

Aspose.Slides 允許您直接在程式碼中管理投影片文字的字型屬性。您可以透過形狀、文字框、段落與文字區段來存取投影片中的文字，然後對選取的文字套用格式設定。

本文說明如何為簡報中現有的文字設定與字型相關的屬性，包括字型族、粗體與斜體樣式、段落對齊方式以及字型顏色。亦示範如何建立文字方塊、向其中加入文字，並在將結果儲存為 PPTX 檔案之前，設定字型族、粗體、斜體、底線、字型大小與顏色等屬性。

## **管理字型相關屬性**
{{% alert color="primary" %}} 

簡報通常同時包含文字與圖像。文字可以以各種方式格式化，以突顯特定段落與字詞，或符合企業樣式。文字格式化協助使用者變化簡報內容的外觀與感受。本文說明如何使用 Aspose.Slides for Android via Java 來設定投影片上文字段落的字型屬性。

{{% /alert %}} 

使用 Aspose.Slides for Android via Java 來管理段落的字型屬性：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation) 類別的執行個體。
1. 以索引取得投影片的參考。
1. 取得投影片中的 [Placeholder](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/placeholder/) 形狀，並將其型別轉換為 [AutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/autoshape/)。
1. 從由 [AutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/autoshape/) 所公開的 [TextFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/textframe/) 取得 [Paragraph](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/paragraph/)。
1. 使段落兩端對齊。
1. 取得 [Paragraph](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/paragraph/) 文字的 [Portion](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/portion/)。
1. 使用 [FontData](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/fontdata/) 定義字型，並相應設定文字 [Portion](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/portion/) 的 **Font**。
   1. 設定字型為粗體。
   1. 設定字型為斜體。
1. 使用由 [Portion](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/portion/) 物件公開的 [FillFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/fillformat/) 設定字型顏色。
1. 將修改後的簡報儲存為 PPTX 檔案。

以下提供上述步驟的實作範例。它會取得一個未經裝飾的簡報，並對其中一張投影片的字型進行格式化。下列螢幕截圖顯示輸入檔案以及程式碼片段如何變更它。程式碼會變更字型、顏色與字型樣式。

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**圖示：輸入檔案中的文字**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**圖示：相同文字的更新後格式**|

```java
// 實例化一個表示 PPTX 檔案的 Presentation 物件
Presentation pres = new Presentation("FontProperties.pptx");
try {
	// 使用投影片位置存取投影片
	ISlide slide = pres.getSlides().get_Item(0);

	// 存取投影片中的第一與第二個占位符，並將其型別轉換為 AutoShape
	ITextFrame tf1 = ((IAutoShape) slide.getShapes().get_Item(0)).getTextFrame();
	ITextFrame tf2 = ((IAutoShape) slide.getShapes().get_Item(1)).getTextFrame();

	// 取得第一個段落
	IParagraph para1 = tf1.getParagraphs().get_Item(0);
	IParagraph para2 = tf2.getParagraphs().get_Item(0);

	// 將段落兩端對齊
	para2.getParagraphFormat().setAlignment(TextAlignment.JustifyLow);

	// 取得第一個文字區段
	IPortion port1 = para1.getPortions().get_Item(0);
	IPortion port2 = para2.getPortions().get_Item(0);

	// 定義新字型
	FontData fd1 = new FontData("Elephant");
	FontData fd2 = new FontData("Castellar");

	// 將新字型指派給文字區段
	port1.getPortionFormat().setLatinFont(fd1);
	port2.getPortionFormat().setLatinFont(fd2);

	// 將字型設為粗體
	port1.getPortionFormat().setFontBold(NullableBool.True);
	port2.getPortionFormat().setFontBold(NullableBool.True);

	// 將字型設為斜體
	port1.getPortionFormat().setFontItalic(NullableBool.True);
	port2.getPortionFormat().setFontItalic(NullableBool.True);

	// 設定字型顏色
	port1.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	port2.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

	// 將 PPTX 儲存至磁碟
	pres.save("WelcomeFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **設定文字字型屬性**
{{% alert color="primary" %}} 

如同 **管理字型相關屬性** 中所述，[Portion](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/portion/) 用於在段落中保存具有相似格式樣式的文字。本文說明如何使用 Aspose.Slides for Android via Java 建立含有文字的文字方塊，然後定義特定字型以及字型族類別的各種其他屬性。

{{% /alert %}} 

建立文字方塊並設定其中文字的字型屬性：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation) 類別的執行個體。
1. 以索引取得投影片的參考。
1. 向投影片加入類型為 **Rectangle** 的 [AutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/autoshape/)。
1. 移除與該 [AutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/autoshape/) 相關聯的填充樣式。
1. 取得該 [AutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/autoshape/) 的 [TextFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/textframe/)。
1. 向 [TextFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/textframe/) 中加入一些文字。
1. 取得與該 [TextFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/textframe/) 相關聯的 [Portion](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/portion/) 物件。
1. 定義用於該 [Portion](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/portion/) 的字型。
1. 使用 [Portion](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/portion/) 物件公開的相關屬性，設定粗體、斜體、底線、顏色與高度等其他字型屬性。
1. 將修改後的簡報寫入為 PPTX 檔案。

以下提供上述步驟的實作範例。

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**圖示：由 Aspose.Slides for Android via Java 設定部分字型屬性的文字**|

```java
// 實例化一個表示 PPTX 檔案的 Presentation 物件
Presentation pres = new Presentation();
try {
	// 取得第一張投影片
	ISlide sld = pres.getSlides().get_Item(0);
	
	// 新增類型為 Rectangle 的 AutoShape
	IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
	
	// 移除與 AutoShape 相關聯的任何填充樣式
	ashp.getFillFormat().setFillType(FillType.NoFill);
	
	// 存取與 AutoShape 相關聯的 TextFrame
	ITextFrame tf = ashp.getTextFrame();
	tf.setText("Aspose TextBox");
	
	// 存取與 TextFrame 相關聯的 Portion
	IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
	
	// 為 Portion 設定字型
	port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
	
	// 設定字型的粗體屬性
	port.getPortionFormat().setFontBold(NullableBool.True);
	
	// 設定字型的斜體屬性
	port.getPortionFormat().setFontItalic(NullableBool.True);
	
	// 設定字型的底線屬性
	port.getPortionFormat().setFontUnderline(TextUnderlineType.Single);
	
	// 設定字型的高度
	port.getPortionFormat().setFontHeight(25);
	
	// 設定字型的顏色
	port.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	
	// 將簡報儲存至磁碟
	pres.save("pptxFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```