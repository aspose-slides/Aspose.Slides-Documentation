---
title: Crea una Nuova Presentazione in VSTO e Aspose.Slides
type: docs
weight: 80
url: /it/net/create-a-new-presentation-in-vsto-and-aspose-slides/
---
Di seguito sono due esempi di codice che illustrano come VSTO e Aspose.Slides per .NET possano essere utilizzati per raggiungere lo stesso obiettivo.
## **VSTO**
``` csharp

 private void CreatePresentation()

{

PowerPoint.Presentation pres = Globals.ThisAddIn.Application

	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Ottieni il layout della diapositiva titolo

PowerPoint.CustomLayout layout = pres.SlideMaster.

	CustomLayouts[PowerPoint.PpSlideLayout.ppLayoutTitle];

//Aggiungi una diapositiva titolo.

PowerPoint.Slide slide=pres.Slides.AddSlide(1, layout);

//Imposta il testo del titolo

slide.Shapes.Title.TextFrame.TextRange.Text = "Slide Title Heading";

//Imposta il testo del sottotitolo

slide.Shapes[2].TextFrame.TextRange.Text = "Slide Title Sub-Heading";

//Scrivi l'output su disco

pres.SaveAs("outVSTO.ppt",

	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

	Microsoft.Office.Core.MsoTriState.msoFalse);

}

``` 
## **Aspose.Slides**
``` csharp

 private static void CreatePresentation()

{

	//Crea una presentazione

	Presentation pres = new Presentation();

	//Aggiungi la diapositiva titolo

	Slide slide = pres.AddTitleSlide();

	//Imposta il testo del titolo

	((TextHolder)slide.Placeholders[0]).Text = "Slide Title Heading";

	//Imposta il testo del sottotitolo

	((TextHolder)slide.Placeholders[1]).Text = "Slide Title Sub-Heading";

	//Scrivi l'output su disco

	pres.Write("outAsposeSlides.ppt");

}

``` 
## **Scarica Codice di Esempio**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Create.a.New.Presentation.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20a%20New%20Presentation%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20a%20New%20Presentation/)