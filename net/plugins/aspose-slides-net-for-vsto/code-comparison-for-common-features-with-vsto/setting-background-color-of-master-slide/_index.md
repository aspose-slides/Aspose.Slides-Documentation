---
title: Setting Background Color of Master Slide
type: docs
weight: 140
url: /net/setting-background-color-of-master-slide/
---

### **VSTO**
```

 PowerPoint.Presentation presentation =

                Globals.ThisAddIn.Application.Presentations.Open("Setting Background Color of Master Slide.ppt", Office.MsoTriState.msoFalse, Office.MsoTriState.msoFalse, Office.MsoTriState.msoTrue);

            presentation.SlideMaster.Background.Fill.ForeColor.RGB = -654262273;

```
### **Aspose.Slides**
```

 //Instantiate the Presentation class that represents the presentation file

using (PresentationEx pres = new PresentationEx())

{

	//Set the background color of the Master ISlide to Forest Green

	pres.Masters[0].Background.Type = BackgroundTypeEx.OwnBackground;

	pres.Masters[0].Background.FillFormat.FillType = FillTypeEx.Solid;

	pres.Masters[0].Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

	//Write the presentation to disk

	pres.Save("Setting Background Color of Master Slide.pptx", SaveFormat.Pptx);

```
## **Download Sample Code**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/787342)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Setting.Background.color.of.Master.Slide.Aspose.Slides.zip)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Setting%20Background%20color%20of%20Master%20Slide%20\(Asose.Slides\).zip)
