---
title: 在 VSTO 和 Aspose.Slides 中创建一个新演示文稿
type: docs
weight: 80
url: /net/create-a-new-presentation-in-vsto-and-aspose-slides/
---

下面是两个代码示例，展示了如何使用 VSTO 和 Aspose.Slides for .NET 实现相同的目标。
## **VSTO**
``` csharp

 private void CreatePresentation()

{

PowerPoint.Presentation pres = Globals.ThisAddIn.Application

	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//获取标题幻灯片布局

PowerPoint.CustomLayout layout = pres.SlideMaster.

	CustomLayouts[PowerPoint.PpSlideLayout.ppLayoutTitle];

//添加一个标题幻灯片。

PowerPoint.Slide slide=pres.Slides.AddSlide(1, layout);

//设置标题文本

slide.Shapes.Title.TextFrame.TextRange.Text = "幻灯片标题";

//设置副标题文本

slide.Shapes[2].TextFrame.TextRange.Text = "幻灯片标题副标题";

//将输出写入磁盘

pres.SaveAs("outVSTO.ppt", 

	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation, 

	Microsoft.Office.Core.MsoTriState.msoFalse);

}

``` 
## **Aspose.Slides**
``` csharp

 private static void CreatePresentation()

{

	//创建一个演示文稿

	Presentation pres = new Presentation();

	//添加标题幻灯片

	Slide slide = pres.AddTitleSlide();

	//设置标题文本

	((TextHolder)slide.Placeholders[0]).Text = "幻灯片标题";

	//设置副标题文本

	((TextHolder)slide.Placeholders[1]).Text = "幻灯片标题副标题";

	//写输出到磁盘

	pres.Write("outAsposeSlides.ppt");

}

``` 
## **下载示例代码**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/772949)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Create.a.New.Presentation.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20a%20New%20Presentation%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Create%20a%20New%20Presentation%20\(Aspose.Slides\).zip)