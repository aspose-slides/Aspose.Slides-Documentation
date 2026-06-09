---
title: Ορισμός Χρώματος Υποβάθρου της Διαφάνειας Μάστερ
type: docs
weight: 140
url: /el/net/setting-background-color-of-master-slide/
---
## **VSTO**
``` csharp

 PowerPoint.Presentation presentation =

                Globals.ThisAddIn.Application.Presentations.Open("Setting Background Color of Master Slide.ppt", Office.MsoTriState.msoFalse, Office.MsoTriState.msoFalse, Office.MsoTriState.msoTrue);

            presentation.SlideMaster.Background.Fill.ForeColor.RGB = -654262273;

``` 
## **Aspose.Slides**
``` csharp

 //Δημιουργία της κλάσης Presentation που αντιπροσωπεύει το αρχείο παρουσίασης

using (PresentationEx pres = new PresentationEx())

{

	//Ορίστε το χρώμα φόντου του Master ISlide σε Πράσινο δάσους

	pres.Masters[0].Background.Type = BackgroundTypeEx.OwnBackground;

	pres.Masters[0].Background.FillFormat.FillType = FillTypeEx.Solid;

	pres.Masters[0].Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

	//Αποθήκευση της παρουσίασης στο δίσκο

	pres.Save("Setting Background Color of Master Slide.pptx", SaveFormat.Pptx);

``` 
## **Λήψη Δείγματος Κώδικα**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Setting.Background.color.of.Master.Slide.Aspose.Slides.zip)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Setting%20Background%20color%20of%20Master%20Slide/)