---
title: Создание новой презентации в VSTO и Aspose.Slides
type: docs
weight: 80
url: /ru/net/create-a-new-presentation-in-vsto-and-aspose-slides/
---

Ниже приведены два примера кода, демонстрирующие, как VSTO и Aspose.Slides для .NET можно использовать для достижения одной и той же цели.
## **VSTO**
``` csharp

 private void CreatePresentation()

{

PowerPoint.Presentation pres = Globals.ThisAddIn.Application

	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Get the title slide layout

PowerPoint.CustomLayout layout = pres.SlideMaster.

	CustomLayouts[PowerPoint.PpSlideLayout.ppLayoutTitle];

//Add a title slide.

PowerPoint.Slide slide=pres.Slides.AddSlide(1, layout);

//Set the title text

slide.Shapes.Title.TextFrame.TextRange.Text = "Slide Title Heading";

//Set the sub title text

slide.Shapes[2].TextFrame.TextRange.Text = "Slide Title Sub-Heading";

//Write the output to disk

pres.SaveAs("outVSTO.ppt",

	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

	Microsoft.Office.Core.MsoTriState.msoFalse);

}

``` 
## **Aspose.Slides**
``` csharp

 private static void CreatePresentation()

{

	//Create a presentation

	Presentation pres = new Presentation();

	//Add the title slide

	Slide slide = pres.AddTitleSlide();

	//Set the title text

	((TextHolder)slide.Placeholders[0]).Text = "Slide Title Heading";

	//Set the sub title text

	((TextHolder)slide.Placeholders[1]).Text = "Slide Title Sub-Heading";

	//Write output to disk

	pres.Write("outAsposeSlides.ppt");

}

``` 
## **Скачать пример кода**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Create.a.New.Presentation.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20a%20New%20Presentation%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20a%20New%20Presentation/)