---
title: 動態新增文字
type: docs
weight: 40
url: /zh-hant/net/adding-text-dynamically/
---
兩個方法遵循以下步驟：

- 建立簡報。
- 新增空白投影片。
- 新增文字方塊。
- 設定文字內容。
- 寫入簡報。

## **VSTO**
``` csharp

 private void AddTextBox()

{

	//建立簡報

	PowerPoint.Presentation pres = Globals.ThisAddIn.Application

		.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

	//取得空白投影片版面配置

	PowerPoint.CustomLayout layout = pres.SlideMaster.

		CustomLayouts[7];

	//新增空白投影片

	PowerPoint.Slide sld = pres.Slides.AddSlide(1, layout);

	//新增文字

	PowerPoint.Shape shp =sld.Shapes.AddTextbox

	(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal,150, 100, 400, 100);

	//設定文字

	PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;

	txtRange.Text = "Text added dynamically";

	txtRange.Font.Name = "Arial";

	txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoTrue;

	txtRange.Font.Size = 32;

	//將輸出寫入磁碟

	pres.SaveAs("outVSTOAddingText.ppt",

		PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

		Microsoft.Office.Core.MsoTriState.msoFalse);

}

```
## **Aspose.Slides**
``` csharp

 static void AddTextBox()

{

	//建立簡報

	Presentation pres = new Presentation();

	//預設情況下會新增空白投影片，當您建立
	//簡報時使用預設建構函式
	//因此，我們不需要再新增任何空白投影片

	Slide sld = pres.GetSlideByPosition(1);

	//取得 Arial 的字型索引
	//如果您使用預設建構函式建立簡報，則始終為 0
	//預設建構函式
	int arialFontIndex = 0;

	//新增文字方塊
	//為了新增它，我們會先新增一個矩形
	Shape shp = sld.Shapes.AddRectangle(1200, 800, 3200, 370);

	//隱藏其線條
	shp.LineFormat.ShowLines = false;

	//然後在其中新增文字框
	TextFrame tf = shp.AddTextFrame("");

	//設定文字
	tf.Text = "Text added dynamically";

	Portion port = tf.Paragraphs[0].Portions[0];

	port.FontIndex = arialFontIndex;

	port.FontBold = true;

	port.FontHeight = 32;

	//將輸出寫入磁碟
	pres.Write("outAspose.ppt");

}

```
## **下載範例程式碼**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Adding.Text.Dynamically.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Text%20Dynamically%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Text%20Dynamically%20using%20VSTO%20and%20Aspose.Slides/)