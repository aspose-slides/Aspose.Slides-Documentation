---
title: मास्टर स्लाइड की पृष्ठभूमि रंग सेट करना
type: docs
weight: 140
url: /hi/net/setting-background-color-of-master-slide/
---
## **VSTO**
``` csharp

 PowerPoint.Presentation presentation =

                Globals.ThisAddIn.Application.Presentations.Open("Setting Background Color of Master Slide.ppt", Office.MsoTriState.msoFalse, Office.MsoTriState.msoFalse, Office.MsoTriState.msoTrue);

            presentation.SlideMaster.Background.Fill.ForeColor.RGB = -654262273;

``` 
## **Aspose.Slides**
``` csharp

 //प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करें

using (PresentationEx pres = new PresentationEx())

{

	//मास्टर ISlide की पृष्ठभूमि रंग को फॉरेस्ट ग्रीन सेट करें

	pres.Masters[0].Background.Type = BackgroundTypeEx.OwnBackground;

	pres.Masters[0].Background.FillFormat.FillType = FillTypeEx.Solid;

	pres.Masters[0].Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

	//प्रेजेंटेशन को डिस्क पर लिखें

	pres.Save("Setting Background Color of Master Slide.pptx", SaveFormat.Pptx);

``` 
## **नमूना कोड डाउनलोड करें**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Setting.Background.color.of.Master.Slide.Aspose.Slides.zip)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Setting%20Background%20color%20of%20Master%20Slide/)