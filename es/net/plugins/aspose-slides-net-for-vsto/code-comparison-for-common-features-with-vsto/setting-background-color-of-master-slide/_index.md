---
title: Establecer Color de Fondo de la Diapositiva Maestra
type: docs
weight: 140
url: /net/setting-background-color-of-master-slide/
---

## **VSTO**
``` csharp

 PowerPoint.Presentation presentation =

                Globals.ThisAddIn.Application.Presentations.Open("Establecer Color de Fondo de la Diapositiva Maestra.ppt", Office.MsoTriState.msoFalse, Office.MsoTriState.msoFalse, Office.MsoTriState.msoTrue);

            presentation.SlideMaster.Background.Fill.ForeColor.RGB = -654262273;

``` 
## **Aspose.Slides**
``` csharp

 //Instanciar la clase Presentation que representa el archivo de presentación

using (PresentationEx pres = new PresentationEx())

{

	//Establecer el color de fondo de la Diapositiva Maestra ISlide a Verde Bosque

	pres.Masters[0].Background.Type = BackgroundTypeEx.OwnBackground;

	pres.Masters[0].Background.FillFormat.FillType = FillTypeEx.Solid;

	pres.Masters[0].Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

	//Guardar la presentación en el disco

	pres.Save("Establecer Color de Fondo de la Diapositiva Maestra.pptx", SaveFormat.Pptx);

``` 
## **Descargar Código de Ejemplo**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/787342)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Setting.Background.color.of.Master.Slide.Aspose.Slides.zip)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Setting%20Background%20color%20of%20Master%20Slide%20\(Asose.Slides\).zip)