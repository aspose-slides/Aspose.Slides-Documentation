---
title: 动态添加文本
type: docs
weight: 40
url: /zh/net/adding-text-dynamically/
---

这两种方法遵循以下步骤：

- 创建一个演示文稿。
- 添加一个空白幻灯片。
- 添加一个文本框。
- 设置一些文本。
- 撰写演示文稿。
## **VSTO**
``` csharp

 private void AddTextBox()

{

	//创建一个演示文稿

	PowerPoint.Presentation pres = Globals.ThisAddIn.Application

		.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

	//获取空白幻灯片布局

	PowerPoint.CustomLayout layout = pres.SlideMaster.

		CustomLayouts[7];

	//添加一个空白幻灯片

	PowerPoint.Slide sld = pres.Slides.AddSlide(1, layout);

	//添加文本

	PowerPoint.Shape shp =sld.Shapes.AddTextbox

	(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal,150, 100, 400, 100);

	//设置文本

	PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;

	txtRange.Text = "动态添加的文本";

	txtRange.Font.Name = "Arial";

	txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoTrue;

	txtRange.Font.Size = 32;

	//将输出写入磁盘

	pres.SaveAs("outVSTOAddingText.ppt",

		PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

		Microsoft.Office.Core.MsoTriState.msoFalse);

}

``` 
## **Aspose.Slides**
``` csharp

 static void AddTextBox()

{

	//创建一个演示文稿

	Presentation pres = new Presentation();

	//默认构造函数创建时会默认添加一个空白幻灯片

	//所以我们不需要添加任何空白幻灯片

	Slide sld = pres.GetSlideByPosition(1);

	//获取Arial字体索引

	//如果是从默认构造函数创建演示文稿，则始终为0

	int arialFontIndex = 0;

	//添加文本框

	//为了添加它，我们将首先添加一个矩形

	Shape shp = sld.Shapes.AddRectangle(1200, 800, 3200, 370);

	//隐藏其边框

	shp.LineFormat.ShowLines = false;

	//然后在其中添加一个文本框

	TextFrame tf = shp.AddTextFrame("");

	//设置文本

	tf.Text = "动态添加的文本";

	Portion port = tf.Paragraphs[0].Portions[0];

	port.FontIndex = arialFontIndex;

	port.FontBold = true;

	port.FontHeight = 32;

	//将输出写入磁盘

	pres.Write("outAspose.ppt");

}

``` 
## **下载示例代码**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/772947)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Adding.Text.Dynamically.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Text%20Dynamically%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Adding%20Text%20Dynamically%20\(Aspose.Slides\).zip)