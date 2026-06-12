---
title: Vytvoření nové prezentace ve VSTO a Aspose.Slides
type: docs
weight: 80
url: /cs/net/create-a-new-presentation-in-vsto-and-aspose-slides/
---
Níže jsou dva ukázkové kódy, které ilustrují, jak lze VSTO a Aspose.Slides pro .NET použít k dosažení stejného cíle.
## **VSTO**
``` csharp

 private void CreatePresentation()

{

PowerPoint.Presentation pres = Globals.ThisAddIn.Application

	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Získat rozložení úvodního snímku

PowerPoint.CustomLayout layout = pres.SlideMaster.

	CustomLayouts[PowerPoint.PpSlideLayout.ppLayoutTitle];

//Přidat úvodní snímek.

PowerPoint.Slide slide=pres.Slides.AddSlide(1, layout);

//Nastavit text nadpisu

slide.Shapes.Title.TextFrame.TextRange.Text = "Slide Title Heading";

//Nastavit text podnadpisu

slide.Shapes[2].TextFrame.TextRange.Text = "Slide Title Sub-Heading";

//Zapsat výstup na disk

pres.SaveAs("outVSTO.ppt",

	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

	Microsoft.Office.Core.MsoTriState.msoFalse);

}

``` 
## **Aspose.Slides**
``` csharp

 private static void CreatePresentation()

{

	//Vytvořit prezentaci

	Presentation pres = new Presentation();

	//Přidat úvodní snímek

	Slide slide = pres.AddTitleSlide();

	//Nastavit text nadpisu

	((TextHolder)slide.Placeholders[0]).Text = "Slide Title Heading";

	//Nastavit text podnadpisu

	((TextHolder)slide.Placeholders[1]).Text = "Slide Title Sub-Heading";

	//Zapsat výstup na disk

	pres.Write("outAsposeSlides.ppt");

}

``` 
## **Stáhnout ukázkový kód**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Create.a.New.Presentation.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20a%20New%20Presentation%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20a%20New%20Presentation/)