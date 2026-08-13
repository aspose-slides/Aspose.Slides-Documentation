---
title: 使用 Java 管理簡報中的字型
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
- 簡報
- Java
- Aspose.Slides
description: "使用 Aspose.Slides 在 Java 中控制字型：嵌入、替代及載入自訂字型，確保 PPT、PPTX 與 ODP 簡報保持清晰、符合品牌且一致。"
---
## **概觀**

Aspose.Slides 允許您直接從程式碼管理簡報文字的字型屬性。您可以透過圖形、文字框、段落和字串來存取投影片中的文字，然後對選取的文字套用格式設定。

本文說明如何為簡報中現有的文字設定字型相關屬性，包括字型系列、粗體與斜體樣式、段落對齊以及字型顏色。亦示範如何建立文字方塊、向其中加入文字，並在儲存為 PPTX 檔案之前設定字型系列、粗體、斜體、底線、字型大小與顏色等屬性。

## **管理字型相關屬性**
{{% alert color="info" %}} 

簡報通常同時包含文字與影像。文字可以以各種方式格式化，以突顯特定段落與單詞，或符合公司樣式。文字格式化協助使用者變化簡報內容的外觀與感受。本文展示如何使用 Aspose.Slides for Java 於投影片中的文字段落設定字型屬性。

{{% /alert %}} 

使用 Aspose.Slides for Java 管理段落的字型屬性步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation) 類別的實例。  
2. 依索引取得投影片的參考。  
3. 取得投影片中的 [Placeholder](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/placeholder/) 圖形，並將其類型轉換為 [AutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/autoshape/)。  
4. 從由 [AutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/autoshape/) 所公開的 [TextFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/textframe/) 取得 [Paragraph](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/paragraph/)。  
5. 使段落左右對齊。  
6. 取得 [Paragraph](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/paragraph/) 之文字 [Portion](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/portion/)。  
7. 使用 [FontData](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fontdata/) 定義字型，並相應設定文字 [Portion](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/portion/) 的 **Font**。  
   1. 設定字型為粗體。  
   2. 設定字型為斜體。  
8. 使用由 [Portion](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/portion/) 物件公開的 [FillFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fillformat/) 設定字型顏色。  
9. 將已修改的簡報儲存為 PPTX 檔案。

以下提供上述步驟的實作範例。它接收一個未加修飾的簡報，並對其中一張投影片的字型進行格式化。下方截圖展示輸入檔案以及程式碼如何變更它。程式碼會改變字型、顏色與字型樣式。

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**圖 1：輸入檔案中的文字**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**圖 2：相同文字的更新後格式**|

```java
import com.aspose.slides.*;
import java.awt.Color;

// 建立表示 PPTX 檔案的 Presentation 物件
Presentation pres = new Presentation("FontProperties.pptx");
try {
	// 使用投影片位置存取投影片
	ISlide slide = pres.getSlides().get_Item(0);

	// 存取投影片中的第一與第二個佔位符，並將其類型轉換為 AutoShape
	ITextFrame tf1 = ((IAutoShape) slide.getShapes().get_Item(0)).getTextFrame();
	ITextFrame tf2 = ((IAutoShape) slide.getShapes().get_Item(1)).getTextFrame();

	// 存取第一個段落
	IParagraph para1 = tf1.getParagraphs().get_Item(0);
	IParagraph para2 = tf2.getParagraphs().get_Item(0);

	// 將段落兩端對齊
	para2.getParagraphFormat().setAlignment(TextAlignment.JustifyLow);

	// 存取第一個字串
	IPortion port1 = para1.getPortions().get_Item(0);
	IPortion port2 = para2.getPortions().get_Item(0);

	// 定義新字型
	FontData fd1 = new FontData("Elephant");
	FontData fd2 = new FontData("Castellar");

	// 將新字型指派給字串
	port1.getPortionFormat().setLatinFont(fd1);
	port2.getPortionFormat().setLatinFont(fd2);

	// 將字型設定為粗體
	port1.getPortionFormat().setFontBold(NullableBool.True);
	port2.getPortionFormat().setFontBold(NullableBool.True);

	// 將字型設定為斜體
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
{{% alert color="info" %}} 

如同在 **管理字型相關屬性** 中所述，[Portion](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/portion/) 用於在段落中保存具有相同格式樣式的文字。本文示範如何使用 Aspose.Slides for Java 建立包含文字的文字方塊，然後為其定義特定字型以及字型系列類別的各種其他屬性。

{{% /alert %}} 

建立文字方塊並設定其中文字的字型屬性步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation) 類別的實例。  
2. 依索引取得投影片的參考。  
3. 在投影片上新增類型為 **Rectangle** 的 [AutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/autoshape/)。  
4. 移除與該 [AutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/autoshape/) 相關的填充樣式。  
5. 取得該 [AutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/autoshape/) 的 [TextFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/textframe/)。  
6. 向 [TextFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/textframe/) 新增一些文字。  
7. 取得與該 [TextFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/textframe/) 相關的 [Portion](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/portion/) 物件。  
8. 定義用於該 [Portion](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/portion/) 的字型。  
9. 透過該 [Portion](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/portion/) 物件公開的相關屬性，設定其他字型屬性，如粗體、斜體、底線、顏色與字高。  
10. 將修改後的簡報寫入為 PPTX 檔案。

以下提供上述步驟的實作範例。

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**圖 3：由 Aspose.Slides for Java 設定部分字型屬性的文字**|

```java
import com.aspose.slides.*;
import java.awt.Color;

// 建立表示 PPTX 檔案的 Presentation 物件
Presentation pres = new Presentation();
try {
	// 取得第一張投影片
	ISlide sld = pres.getSlides().get_Item(0);
	
	// 新增類型為 Rectangle 的 AutoShape
	IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
	
	// 移除與 AutoShape 相關的任何填充樣式
	ashp.getFillFormat().setFillType(FillType.NoFill);
	
	// 取得與 AutoShape 關聯的 TextFrame
	ITextFrame tf = ashp.getTextFrame();
	tf.setText("Aspose TextBox");
	
	// 取得與 TextFrame 關聯的 Portion
	IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
	
	// 設定 Portion 的字型
	port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
	
	// 設定字型的粗體屬性
	port.getPortionFormat().setFontBold(NullableBool.True);
	
	// 設定字型的斜體屬性
	port.getPortionFormat().setFontItalic(NullableBool.True);
	
	// 設定字型的底線屬性
	port.getPortionFormat().setFontUnderline(TextUnderlineType.Single);
	
	// 設定字型的字高
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