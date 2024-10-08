---
title: Définir la couleur d'arrière-plan de la diapositive maître
type: docs
weight: 140
url: /fr/net/setting-background-color-of-master-slide/
---

## **VSTO**
``` csharp

 PowerPoint.Presentation presentation =

                Globals.ThisAddIn.Application.Presentations.Open("Setting Background Color of Master Slide.ppt", Office.MsoTriState.msoFalse, Office.MsoTriState.msoFalse, Office.MsoTriState.msoTrue);

            presentation.SlideMaster.Background.Fill.ForeColor.RGB = -654262273;

``` 
## **Aspose.Slides**
``` csharp

 //Instancier la classe Presentation qui représente le fichier de présentation

using (PresentationEx pres = new PresentationEx())

{

	//Définir la couleur d'arrière-plan de la diapositive maître ISlide sur Vert Forêt

	pres.Masters[0].Background.Type = BackgroundTypeEx.OwnBackground;

	pres.Masters[0].Background.FillFormat.FillType = FillTypeEx.Solid;

	pres.Masters[0].Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

	//Écrire la présentation sur le disque

	pres.Save("Setting Background Color of Master Slide.pptx", SaveFormat.Pptx);

``` 
## **Télécharger le code exemple**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/787342)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Setting.Background.color.of.Master.Slide.Aspose.Slides.zip)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Setting%20Background%20color%20of%20Master%20Slide%20\(Asose.Slides\).zip)