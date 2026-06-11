---
title: Utwórz nową prezentację w VSTO i Aspose.Slides
type: docs
weight: 80
url: /pl/net/create-a-new-presentation-in-vsto-and-aspose-slides/
---
Poniżej znajdują się dwa przykłady kodu, które ilustrują, jak VSTO i Aspose.Slides dla .NET mogą być użyte do osiągnięcia tego samego celu.
## **VSTO**
``` csharp

 private void CreatePresentation()

{

PowerPoint.Presentation pres = Globals.ThisAddIn.Application

	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Pobierz układ slajdu tytułowego

PowerPoint.CustomLayout layout = pres.SlideMaster.

	CustomLayouts[PowerPoint.PpSlideLayout.ppLayoutTitle];

//Dodaj slajd tytułowy.

PowerPoint.Slide slide=pres.Slides.AddSlide(1, layout);

//Ustaw tekst tytułu

slide.Shapes.Title.TextFrame.TextRange.Text = "Slide Title Heading";

//Ustaw tekst podtytułu

slide.Shapes[2].TextFrame.TextRange.Text = "Slide Title Sub-Heading";

//Zapisz wynik na dysku

pres.SaveAs("outVSTO.ppt",

	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

	Microsoft.Office.Core.MsoTriState.msoFalse);

}

``` 
## **Aspose.Slides**
``` csharp

 private static void CreatePresentation()

{

	//Utwórz prezentację

	Presentation pres = new Presentation();

	//Dodaj slajd tytułowy

	Slide slide = pres.AddTitleSlide();

	//Ustaw tekst tytułu

	((TextHolder)slide.Placeholders[0]).Text = "Slide Title Heading";

	//Ustaw tekst podtytułu

	((TextHolder)slide.Placeholders[1]).Text = "Slide Title Sub-Heading";

	//Zapisz wynik na dysku

	pres.Write("outAsposeSlides.ppt");

}

``` 
## **Pobierz przykładowy kod**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Create.a.New.Presentation.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20a%20New%20Presentation%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20a%20New%20Presentation/)