---
title: VSTO और Aspose.Slides for .NET का उपयोग करके नई प्रेजेंटेशन बनाएं
linktitle: नई प्रेजेंटेशन बनाएँ
type: docs
weight: 10
url: /hi/net/create-a-new-presentation/
keywords:
- प्रेजेंटेशन बनाएं
- नई प्रेजेंटेशन
- स्थांतरण
- VSTO
- ऑफिस ऑटोमेशन
- PowerPoint
- प्रेजेंटेशन
- .NET
- C#
- Aspose.Slides
description: "Microsoft Office ऑटोमेशन से Aspose.Slides for .NET में स्थानांतरित हों और C# में साफ़, विश्वसनीय कोड के साथ नए PowerPoint (PPT, PPTX) प्रेजेंटेशन बनाएं।"
---
{{% alert color="primary" %}} 

VSTO को इस तरह विकसित किया गया था कि डेवलपर्स माइक्रोसॉफ्ट ऑफिस के भीतर चलने वाले एप्लिकेशन बना सकें। VSTO COM‑आधारित है लेकिन इसे .NET ऑब्जेक्ट में रैप किया गया है ताकि इसे .NET एप्लिकेशन्स में इस्तेमाल किया जा सके। VSTO को .NET फ्रेमवर्क समर्थन के साथ-साथ माइक्रोसॉफ्ट ऑफिस CLR‑आधारित रनटाइम की आवश्यकता होती है। हालांकि इसे माइक्रोसॉफ्ट ऑफिस ऐड‑इन बनाने के लिए इस्तेमाल किया जा सकता है, इसे सर्वर‑साइड घटक के रूप में उपयोग करना लगभग असंभव है। इसमें गंभीर डिप्लॉयमेंट समस्याएँ भी होती हैं।

Aspose.Slides for .NET एक घटक है जिसका उपयोग माइक्रोसॉफ्ट पावरपॉइंट प्रेजेंटेशन को संभालने के लिए किया जा सकता है, ठीक VSTO की तरह, लेकिन इसके कई लाभ हैं:

- Aspose.Slides में केवल मैनेज्ड कोड होता है और इसे माइक्रोसॉफ्ट ऑफिस रनटाइम स्थापित करने की आवश्यकता नहीं होती।
- इसे क्लाइंट‑साइड घटक या सर्वर‑साइड घटक दोनों के रूप में इस्तेमाल किया जा सकता है।
- डिप्लॉयमेंट आसान है क्योंकि Aspose.Slides एक ही DLL में रहता है।

{{% /alert %}} 
## **एक प्रेजेंटेशन बनाना**
नीचे दो कोड उदाहरण दिए गए हैं जो दर्शाते हैं कि VSTO और Aspose.Slides for .NET का उपयोग करके समान लक्ष्य कैसे प्राप्त किया जा सकता है। पहला उदाहरण [VSTO](/slides/hi/net/create-a-new-presentation/); [दूसरा उदाहरण](/slides/hi/net/create-a-new-presentation/) Aspose.Slides का उपयोग करता है।
### **VSTO उदाहरण**
**VSTO आउटपुट** 

![todo:image_alt_text](create-a-new-presentation_1.png)



```c#
//ध्यान दें: PowerPoint एक नेमस्पेस है जिसे ऊपर इस प्रकार परिभाषित किया गया है
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;

//प्रेजेंटेशन बनाएँ
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
//एक प्रेजेंटेशन बनाएँ
Presentation pres = new Presentation();

//शीर्षक स्लाइड जोड़ें
ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);


//शीर्षक पाठ सेट करें
((IAutoShape)slide.Shapes[0]).TextFrame.Text = "Slide Title Heading";

//उपशीर्षक पाठ सेट करें
((IAutoShape)slide.Shapes[1]).TextFrame.Text = "Slide Title Sub-Heading";

//आउटपुट को डिस्क पर लिखें
pres.Save("c:\\data\\outAsposeSlides.pptx", SaveFormat.Ppt);
```