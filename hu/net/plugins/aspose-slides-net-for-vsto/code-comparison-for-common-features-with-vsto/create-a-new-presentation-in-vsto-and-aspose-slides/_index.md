---
title: Új prezentáció létrehozása VSTO-ban és az Aspose.Slides-ben
type: docs
weight: 80
url: /hu/net/create-a-new-presentation-in-vsto-and-aspose-slides/
---
Az alábbiakban két kódrészletet láthat, amelyek bemutatják, hogyan használhatók a VSTO és az Aspose.Slides for .NET a cél eléréséhez.
## **VSTO**
``` csharp

 private void CreatePresentation()

{

PowerPoint.Presentation pres = Globals.ThisAddIn.Application

	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//A cím dia elrendezésének lekérése

PowerPoint.CustomLayout layout = pres.SlideMaster.

	CustomLayouts[PowerPoint.PpSlideLayout.ppLayoutTitle];

//Címdiát hozzáadása.

PowerPoint.Slide slide=pres.Slides.AddSlide(1, layout);

//A cím szövegének beállítása

slide.Shapes.Title.TextFrame.TextRange.Text = "Slide Title Heading";

//Az alcím szövegének beállítása

slide.Shapes[2].TextFrame.TextRange.Text = "Slide Title Sub-Heading";

//Az eredmény írása lemezre

pres.SaveAs("outVSTO.ppt",

	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

	Microsoft.Office.Core.MsoTriState.msoFalse);

}
``` 
## **Aspose.Slides**
``` csharp

 private static void CreatePresentation()

{

	//Prezentáció létrehozása

	Presentation pres = new Presentation();

	//Címdiát hozzáadása

	Slide slide = pres.AddTitleSlide();

	//A cím szövegének beállítása

	((TextHolder)slide.Placeholders[0]).Text = "Slide Title Heading";

	//Az alcím szövegének beállítása

	((TextHolder)slide.Placeholders[1]).Text = "Slide Title Sub-Heading";

	//Az eredmény írása lemezre

	pres.Write("outAsposeSlides.ppt");

}

``` 
## **Mintakód letöltése**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Create.a.New.Presentation.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20a%20New%20Presentation%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20a%20New%20Presentation/)