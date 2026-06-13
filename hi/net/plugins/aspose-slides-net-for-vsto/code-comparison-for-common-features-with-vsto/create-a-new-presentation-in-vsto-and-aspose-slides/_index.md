---
title: VSTO और Aspose.Slides में नई प्रस्तुति बनाएं
type: docs
weight: 80
url: /hi/net/create-a-new-presentation-in-vsto-and-aspose-slides/
---
नीचे दो कोड उदाहरण दिए गए हैं जो दिखाते हैं कि VSTO और Aspose.Slides for .NET को समान लक्ष्य प्राप्त करने के लिए कैसे उपयोग किया जा सकता है।
## **VSTO**
``` csharp

 private void CreatePresentation()

{

PowerPoint.Presentation pres = Globals.ThisAddIn.Application

	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Get the title slide layout
//शीर्षक स्लाइड लेआउट प्राप्त करें

PowerPoint.CustomLayout layout = pres.SlideMaster.

	CustomLayouts[PowerPoint.PpSlideLayout.ppLayoutTitle];

//Add a title slide.
 //एक शीर्षक स्लाइड जोड़ें।

PowerPoint.Slide slide=pres.Slides.AddSlide(1, layout);

//Set the title text
 //शीर्षक पाठ सेट करें

slide.Shapes.Title.TextFrame.TextRange.Text = "Slide Title Heading";

//Set the sub title text
 //उपशीर्षक पाठ सेट करें

slide.Shapes[2].TextFrame.TextRange.Text = "Slide Title Sub-Heading";

//Write the output to disk
 //आउटपुट को डिस्क पर लिखें

pres.SaveAs("outVSTO.ppt",

	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

	Microsoft.Office.Core.MsoTriState.msoFalse);

}

``` 
## **Aspose.Slides**
``` csharp

 private static void CreatePresentation()

{

	//एक प्रस्तुति बनाएं

	Presentation pres = new Presentation();

	//शीर्षक स्लाइड जोड़ें

	Slide slide = pres.AddTitleSlide();

	//शीर्षक पाठ सेट करें

	((TextHolder)slide.Placeholders[0]).Text = "Slide Title Heading";

	//उपशीर्षक पाठ सेट करें

	((TextHolder)slide.Placeholders[1]).Text = "Slide Title Sub-Heading";

	//आउटपुट को डिस्क पर लिखें

	pres.Write("outAsposeSlides.ppt");

}

``` 
## **नमूना कोड डाउनलोड करें**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Create.a.New.Presentation.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20a%20New%20Presentation%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20a%20New%20Presentation/)