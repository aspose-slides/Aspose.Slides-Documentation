---
title: Impostare il colore di sfondo della diapositiva master
type: docs
weight: 140
url: /it/net/setting-background-color-of-master-slide/
---
## **VSTO**
``` csharp

 PowerPoint.Presentation presentation =

                Globals.ThisAddIn.Application.Presentations.Open("Setting Background Color of Master Slide.ppt", Office.MsoTriState.msoFalse, Office.MsoTriState.msoFalse, Office.MsoTriState.msoTrue);

            presentation.SlideMaster.Background.Fill.ForeColor.RGB = -654262273;

``` 
## **Aspose.Slides**
``` csharp

 //Istanzia la classe Presentation che rappresenta il file della presentazione

using (PresentationEx pres = new PresentationEx())

{

	//Imposta il colore di sfondo del Master ISlide a Verde foresta

	pres.Masters[0].Background.Type = BackgroundTypeEx.OwnBackground;

	pres.Masters[0].Background.FillFormat.FillType = FillTypeEx.Solid;

	pres.Masters[0].Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

	//Scrivi la presentazione su disco

	pres.Save("Setting Background Color of Master Slide.pptx", SaveFormat.Pptx);

``` 
## **Scarica il codice di esempio**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Setting.Background.color.of.Master.Slide.Aspose.Slides.zip)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Setting%20Background%20color%20of%20Master%20Slide/)