---
title: VSTO और Aspose.Slides for .NET का उपयोग करके नई प्रस्तुतियाँ बनाना
linktitle: नई प्रस्तुति बनाना
type: docs
weight: 10
url: /hi/net/create-a-new-presentation/
keywords:
- प्रस्तुति बनाना
- नई प्रस्तुति
- माइग्रेशन
- VSTO
- ऑफिस ऑटोमेशन
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Microsoft Office ऑटोमेशन से Aspose.Slides for .NET में माइग्रेट करें और C# में साफ़, भरोसेमंद कोड के साथ नई PowerPoint (PPT, PPTX) प्रस्तुतियाँ बनाएं।"
---
{{% alert color="info" %}} 

VSTO को इस तरह विकसित किया गया था कि डेवलपर्स ऐसे अनुप्रयोग बना सकें जो Microsoft Office के भीतर चल सकें। VSTO COM-आधारित है लेकिन इसे .NET ऑब्जेक्ट में लपेटा गया है ताकि इसे .NET अनुप्रयोगों में उपयोग किया जा सके। VSTO को .NET फ्रेमवर्क समर्थन के साथ-साथ Microsoft Office CLR-आधारित रनटाइम की आवश्यकता होती है। जबकि इसे Microsoft Office ऐड‑इन बनाने के लिए उपयोग किया जा सकता है, इसे सर्वर‑साइड घटक के रूप में लगभग असंभव है। इसमें गंभीर डिप्लॉयमेंट समस्याएँ भी हैं।

Aspose.Slides for .NET एक घटक है जिसे Microsoft PowerPoint प्रस्तुतियों को संभालने के लिए उपयोग किया जा सकता है, ठीक VSTO की तरह, लेकिन इसमें कई लाभ हैं:

- Aspose.Slides में केवल प्रबंधित कोड होता है और इसे Microsoft Office रनटाइम स्थापित करने की आवश्यकता नहीं होती।
- इसे क्लाइंट‑साइड घटक या सर्वर‑साइड घटक दोनों रूप में उपयोग किया जा सकता है।
- डिप्लॉयमेंट आसान है क्योंकि Aspose.Slides एक ही DLL में संलग्न है।

{{% /alert %}} 
## **प्रस्तुति बनाना**
नीचे दो उदाहरण कोड हैं जो दर्शाते हैं कि VSTO और Aspose.Slides for .NET को समान लक्ष्य हासिल करने के लिए कैसे उपयोग किया जा सकता है। पहला उदाहरण है [VSTO](/slides/hi/net/create-a-new-presentation/); [दूसरा उदाहरण](/slides/hi/net/create-a-new-presentation/) Aspose.Slides का उपयोग करता है।
### **VSTO उदाहरण**
**VSTO आउटपुट** 

![todo:image_alt_text](create-a-new-presentation_1.png)



```c#
//नोट: PowerPoint एक नेमस्पेस है जिसे ऊपर इस तरह परिभाषित किया गया है
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;

//Create a presentation
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Get the title slide layout
PowerPoint.CustomLayout layout = pres.SlideMaster.
	CustomLayouts[PowerPoint.PpSlideLayout.ppLayoutTitle];

//Add a title slide.
PowerPoint.Slide slide = pres.Slides.AddSlide(1, layout);

//Set the title text
slide.Shapes.Title.TextFrame.TextRange.Text = "Slide Title Heading";

//Set the sub title text
slide.Shapes[2].TextFrame.TextRange.Text = "Slide Title Sub-Heading";

//Write the output to disk
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```


### **Aspose.Slides for .NET उदाहरण**
**Aspose.Slides का आउटपुट** 

![todo:image_alt_text](create-a-new-presentation_2.png)



```c#
using Aspose.Slides;
using Aspose.Slides.Export;

//एक प्रस्तुति बनाएं
Presentation pres = new Presentation();

//शीर्षक स्लाइड जोड़ें
ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);


//शीर्षक पाठ सेट करें
((IAutoShape)slide.Shapes[0]).TextFrame.Text = "Slide Title Heading";

//उपशीर्षक पाठ सेट करें
((IAutoShape)slide.Shapes[1]).TextFrame.Text = "Slide Title Sub-Heading";

//आउटपुट को डिस्क पर लिखें
pres.Save("outAsposeSlides.pptx", SaveFormat.Ppt);
```