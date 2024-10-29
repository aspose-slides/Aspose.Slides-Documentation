---
title: Erstellen Sie eine neue Präsentation in VSTO und Aspose.Slides
type: docs
weight: 80
url: /de/net/create-a-new-presentation-in-vsto-and-aspose-slides/
---

Unten finden Sie zwei Codebeispiele, die zeigen, wie VSTO und Aspose.Slides für .NET verwendet werden können, um dasselbe Ziel zu erreichen.
## **VSTO**
``` csharp

 private void CreatePresentation()

{

PowerPoint.Presentation pres = Globals.ThisAddIn.Application

	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Holen Sie sich das Layout der Titelfolie

PowerPoint.CustomLayout layout = pres.SlideMaster.

	CustomLayouts[PowerPoint.PpSlideLayout.ppLayoutTitle];

//Fügen Sie eine Titelfolie hinzu.

PowerPoint.Slide slide=pres.Slides.AddSlide(1, layout);

//Setzen Sie den Titeltext

slide.Shapes.Title.TextFrame.TextRange.Text = "Folie Titelüberschrift";

//Setzen Sie den Untertiteltext

slide.Shapes[2].TextFrame.TextRange.Text = "Folie Titel Unterüberschrift";

//Schreiben Sie die Ausgabe auf die Festplatte

pres.SaveAs("outVSTO.ppt",

	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

	Microsoft.Office.Core.MsoTriState.msoFalse);

}

``` 
## **Aspose.Slides**
``` csharp

 private static void CreatePresentation()

{

	//Erstellen Sie eine Präsentation

	Presentation pres = new Presentation();

	//Fügen Sie die Titelfolie hinzu

	Slide slide = pres.AddTitleSlide();

	//Setzen Sie den Titeltext

	((TextHolder)slide.Placeholders[0]).Text = "Folie Titelüberschrift";

	//Setzen Sie den Untertiteltext

	((TextHolder)slide.Placeholders[1]).Text = "Folie Titel Unterüberschrift";

	//Schreiben Sie die Ausgabe auf die Festplatte

	pres.Write("outAsposeSlides.ppt");

}

``` 
## **Beispielcode herunterladen**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/772949)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Create.a.New.Presentation.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20a%20New%20Presentation%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Create%20a%20New%20Presentation%20\(Aspose.Slides\).zip)