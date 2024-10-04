---
title: Crear una Nueva Presentación en VSTO y Aspose.Slides
type: docs
weight: 80
url: /net/create-a-new-presentation-in-vsto-and-aspose-slides/
---

A continuación se presentan dos ejemplos de código que ilustran cómo se pueden utilizar VSTO y Aspose.Slides para .NET para lograr el mismo objetivo.
## **VSTO**
``` csharp

 private void CreatePresentation()

{

PowerPoint.Presentation pres = Globals.ThisAddIn.Application

	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Obtener el diseño de la diapositiva de título

PowerPoint.CustomLayout layout = pres.SlideMaster.

	CustomLayouts[PowerPoint.PpSlideLayout.ppLayoutTitle];

//Agregar una diapositiva de título.

PowerPoint.Slide slide=pres.Slides.AddSlide(1, layout);

//Establecer el texto del título

slide.Shapes.Title.TextFrame.TextRange.Text = "Título de la Diapositiva";

//Establecer el texto del subtítulo

slide.Shapes[2].TextFrame.TextRange.Text = "Subtítulo de la Diapositiva";

//Escribir la salida en el disco

pres.SaveAs("outVSTO.ppt",

	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

	Microsoft.Office.Core.MsoTriState.msoFalse);

}

``` 
## **Aspose.Slides**
``` csharp

 private static void CreatePresentation()

{

	//Crear una presentación

	Presentation pres = new Presentation();

	//Agregar la diapositiva de título

	Slide slide = pres.AddTitleSlide();

	//Establecer el texto del título

	((TextHolder)slide.Placeholders[0]).Text = "Título de la Diapositiva";

	//Establecer el texto del subtítulo

	((TextHolder)slide.Placeholders[1]).Text = "Subtítulo de la Diapositiva";

	//Escribir salida en el disco

	pres.Write("outAsposeSlides.ppt");

}

``` 
## **Descargar Código de Ejemplo**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/772949)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Create.a.New.Presentation.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20a%20New%20Presentation%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Create%20a%20New%20Presentation%20\(Aspose.Slides\).zip)