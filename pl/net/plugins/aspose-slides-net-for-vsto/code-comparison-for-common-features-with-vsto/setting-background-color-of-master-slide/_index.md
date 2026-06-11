---
title: Ustawianie koloru tła slajdu głównego
type: docs
weight: 140
url: /pl/net/setting-background-color-of-master-slide/
---
## **VSTO**
``` csharp

 PowerPoint.Presentation presentation =

                Globals.ThisAddIn.Application.Presentations.Open("Setting Background Color of Master Slide.ppt", Office.MsoTriState.msoFalse, Office.MsoTriState.msoFalse, Office.MsoTriState.msoTrue);

            presentation.SlideMaster.Background.Fill.ForeColor.RGB = -654262273;

``` 
## **Aspose.Slides**
``` csharp

 //Zainstancjonuj klasę Presentation, która reprezentuje plik prezentacji

using (PresentationEx pres = new PresentationEx())

{

	//Ustaw kolor tła Master ISlide na zielony leśny

	pres.Masters[0].Background.Type = BackgroundTypeEx.OwnBackground;

	pres.Masters[0].Background.FillFormat.FillType = FillTypeEx.Solid;

	pres.Masters[0].Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

	//Zapisz prezentację na dysku

	pres.Save("Setting Background Color of Master Slide.pptx", SaveFormat.Pptx);

``` 
## **Pobierz przykładowy kod**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Setting.Background.color.of.Master.Slide.Aspose.Slides.zip)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Setting%20Background%20color%20of%20Master%20Slide/)