---
title: Skapa en ny presentation i VSTO och Aspose.Slides
type: docs
weight: 80
url: /sv/net/create-a-new-presentation-in-vsto-and-aspose-slides/
---
Nedan följer två kodexempel som illustrerar hur VSTO och Aspose.Slides för .NET kan användas för att uppnå samma mål.
## **VSTO**
``` csharp

 private void CreatePresentation()

{

PowerPoint.Presentation pres = Globals.ThisAddIn.Application

	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Hämta layouten för titelsliden

PowerPoint.CustomLayout layout = pres.SlideMaster.

	CustomLayouts[PowerPoint.PpSlideLayout.ppLayoutTitle];

//Lägg till en titelslide.

PowerPoint.Slide slide=pres.Slides.AddSlide(1, layout);

//Ställ in titeltexten

slide.Shapes.Title.TextFrame.TextRange.Text = "Slide Title Heading";

//Ställ in undertexten

slide.Shapes[2].TextFrame.TextRange.Text = "Slide Title Sub-Heading";

//Skriv utdata till disk

pres.SaveAs("outVSTO.ppt",

	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

	Microsoft.Office.Core.MsoTriState.msoFalse);

}
``` 
## **Aspose.Slides**
``` csharp

 private static void CreatePresentation()

{

	//Skapa en presentation

	Presentation pres = new Presentation();

	//Lägg till titelsliden

	Slide slide = pres.AddTitleSlide();

	//Ställ in titeltexten

	((TextHolder)slide.Placeholders[0]).Text = "Slide Title Heading";

	//Ställ in undertexten

	((TextHolder)slide.Placeholders[1]).Text = "Slide Title Sub-Heading";

	//Skriv utdata till disk

	pres.Write("outAsposeSlides.ppt");

}
``` 
## **Ladda ner exempel på kod**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Create.a.New.Presentation.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20a%20New%20Presentation%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20a%20New%20Presentation/)