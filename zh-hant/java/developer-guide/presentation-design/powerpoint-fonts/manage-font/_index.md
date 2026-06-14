---
title: 使用 Java 管理投影片字型
linktitle: 管理字型
type: docs
weight: 10
url: /zh-hant/java/manage-fonts/
keywords:
- 管理字型
- 字型屬性
- 段落
- 文字格式化
- PowerPoint
- OpenDocument
- 投影片
- Java
- Aspose.Slides
description: "在 Java 中使用 Aspose.Slides 控制字型：嵌入、替代並載入自訂字型，以確保 PPT、PPTX 與 ODP 投影片清晰、符合品牌且一致。"
---
## **概述**

Aspose.Slides 允許您直接從程式碼中管理投影片文字的字型屬性。您可以透過形狀、文字框、段落和文字區塊存取投影片中的文字，然後對所選文字套用格式設定。

本篇文章說明如何為投影片中現有的文字設定字型相關屬性，包括字型系列、粗體與斜體樣式、段落對齊方式以及字型顏色。它同時示範如何建立文字方塊、向其中加入文字，並在將結果儲存為 PPTX 檔案之前設定字型屬性，如字型系列、粗體、斜體、底線、字型大小與顏色。

## **管理字型相關屬性**
{{% alert color="primary" %}} 

投影片通常同時包含文字與圖片。文字可以以各種方式格式化，無論是強調特定段落與詞彙，或符合公司樣式。文字格式化協助使用者變化投影片內容的外觀與感受。本篇文章說明如何使用 Aspose.Slides for Java 來設定投影片上文字段落的字型屬性。

{{% /alert %}} 

使用 Aspose.Slides for Java 來管理段落的字型屬性：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation) 類別的實例。
1. 使用索引取得投影片的參考。
1. 存取投影片中的 [Placeholder](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/placeholder/) 形狀，並將其類型轉換為 [AutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/autoshape/)。
1. 從 [AutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/autoshape/) 所提供的 [TextFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/textframe/) 取得 [Paragraph](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/paragraph/)。
1. 將段落設定為兩端對齊。
1. 存取 [Paragraph](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/paragraph/) 的文字 [Portion](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/portion/)。
1. 使用 [FontData](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fontdata/) 定義字型，並相應設定文字 [Portion](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/portion/) 的 **Font**。
   1. 將字型設為粗體。
   1. 將字型設為斜體。
1. 使用由 [Portion](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/portion/) 物件提供的 [FillFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fillformat/) 設定字型顏色。
1. 將修改後的投影片儲存為 PPTX 檔案。

以下提供上述步驟的實作範例。它會取得未經修飾的投影片，並對其中一張投影片的字型進行格式化。下方的螢幕擷取顯示輸入檔案以及程式碼片段如何變更它。程式碼會變更字型、顏色與字型樣式。

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**圖示：輸入檔案中的文字**|

|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**圖示：相同文字的已更新格式**|

```java
// 實例化代表 PPTX 檔案的 Presentation 物件
Presentation pres = new Presentation("FontProperties.pptx");
try {
	// 使用投影片位置存取投影片
	ISlide slide = pres.getSlides().get_Item(0);

	// 存取投影片中的第一個和第二個 Placeholder，並將其類型轉換為 AutoShape
	ITextFrame tf1 = ((IAutoShape) slide.getShapes().get_Item(0)).getTextFrame();
	ITextFrame tf2 = ((IAutoShape) slide.getShapes().get_Item(1)).getTextFrame();

	// 存取第一個段落
	IParagraph para1 = tf1.getParagraphs().get_Item(0);
	IParagraph para2 = tf2.getParagraphs().get_Item(0);

	// 將段落設定為兩端對齊
	para2.getParagraphFormat().setAlignment(TextAlignment.JustifyLow);

	// 存取第一個文字區塊
	IPortion port1 = para1.getPortions().get_Item(0);
	IPortion port2 = para2.getPortions().get_Item(0);

	// 定義新字型
	FontData fd1 = new FontData("Elephant");
	FontData fd2 = new FontData("Castellar");

	// 將新字型指定給文字區塊
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

如同在 **管理字型相關屬性** 中提到的，[Portion](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/portion/) 用於在段落中容納具有相同格式樣式的文字。本篇文章說明如何使用 Aspose.Slides for Java 建立包含文字的文字方塊，然後定義特定的字型以及字型系列類別的各種其他屬性。

{{% /alert %}} 

建立文字方塊並設定其中文字的字型屬性：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation) 類別的實例。
1. 使用索引取得投影片的參照。
1. 在投影片上加入類型為 **Rectangle** 的 [AutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/autoshape/)。
1. 移除與 [AutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/autoshape/) 相關的填充樣式。
1. 存取 [AutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/autoshape/) 的 [TextFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/textframe/)。
1. 向 [TextFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/textframe/) 中加入一些文字。
1. 存取與 [TextFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/textframe/) 相關的 [Portion](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/portion/) 物件。
1. 定義要用於 [Portion](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/portion/) 的字型。
1. 使用 [Portion](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/portion/) 物件所提供的相關屬性，設定其他字型屬性，例如粗體、斜體、底線、顏色和高度。
1. 將修改後的投影片寫入為 PPTX 檔案。

以下提供上述步驟的實作範例。

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**圖示：由 Aspose.Slides for Java 設定的部分字型屬性文字**|

```java
// 實例化代表 PPTX 檔案的 Presentation 物件
Presentation pres = new Presentation();
try {
	// 取得第一張投影片
	ISlide sld = pres.getSlides().get_Item(0);
	
	// 新增類型為 Rectangle 的 AutoShape
	IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
	
	// 移除與 AutoShape 相關的所有填充樣式
	ashp.getFillFormat().setFillType(FillType.NoFill);
	
	// 存取與 AutoShape 關聯的 TextFrame
	ITextFrame tf = ashp.getTextFrame();
	tf.setText("Aspose TextBox");
	
	// 存取與 TextFrame 關聯的 Portion
	IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
	
	// 設定 Portion 的字型
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
	
	// 將投影片儲存至磁碟
	pres.save("pptxFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```