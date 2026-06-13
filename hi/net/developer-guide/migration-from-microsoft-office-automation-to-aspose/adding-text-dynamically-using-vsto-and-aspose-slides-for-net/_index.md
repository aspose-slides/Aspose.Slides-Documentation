---
title: VSTO और Aspose.Slides for .NET का उपयोग करके गतिशील रूप से पाठ जोड़ना
linktitle: गतिशील रूप से पाठ जोड़ना
type: docs
weight: 20
url: /hi/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/
keywords:
- पाठ जोड़ना
- स्थांतरण
- VSTO
- ऑफिस स्वचालन
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Microsoft Office स्वचालन से Aspose.Slides for .NET में माइग्रेट करने और C# में PowerPoint (PPT, PPTX) प्रस्तुतियों में गतिशील पाठ जोड़ने का तरीका देखें।"
---
{{% alert color="primary" %}} 

डेवलपर्स के लिए एक सामान्य कार्य है स्लाइड्स में गतिशील रूप से पाठ जोड़ना। यह लेख VSTO और Aspose.Slides for .NET का उपयोग करके गतिशील रूप से पाठ जोड़ने के कोड उदाहरण दिखाता है।[VSTO](/slides/hi/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/)[Aspose.Slides for .NET](/slides/hi/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/).

{{% /alert %}} 
## **गतिशील रूप से पाठ जोड़ना**
दोनों विधियाँ निम्नलिखित चरणों का पालन करती हैं:

1. एक प्रस्तुति बनाएं।
1. एक खाली स्लाइड जोड़ें।
1. एक टेक्स्ट बॉक्स जोड़ें।
1. कुछ पाठ सेट करें।
1. प्रस्तुति लिखें।
## **VSTO कोड उदाहरण**
नीचे दिए गए कोड स्निपेट्स एक साधारण स्लाइड और उस पर एक स्ट्रिंग पाठ के साथ एक प्रस्तुति बनाते हैं।

**VSTO में बनाई गई प्रस्तुति** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_1.png)

```c#
//ध्यान दें: PowerPoint एक नेमस्पेस है जिसे ऊपर इस प्रकार परिभाषित किया गया है
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;

//एक प्रस्तुति बनाएं
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//खाली स्लाइड लेआउट प्राप्त करें
PowerPoint.CustomLayout layout = pres.SlideMaster.
	CustomLayouts[7];

//एक खाली स्लाइड जोड़ें
PowerPoint.Slide sld = pres.Slides.AddSlide(1, layout);

//पाठ जोड़ें
PowerPoint.Shape shp = sld.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 150, 100, 400, 100);

//पाठ सेट करें
PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;
txtRange.Text = "Text added dynamically";
txtRange.Font.Name = "Arial";
txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoTrue;
txtRange.Font.Size = 32;

//आउटपुट को डिस्क पर सहेजें
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```



## **Aspose.Slides for .NET उदाहरण**
नीचे दिए गए कोड स्निपेट्स Aspose.Slides का उपयोग करके एक साधारण स्लाइड और उस पर एक स्ट्रिंग पाठ के साथ एक प्रस्तुति बनाते हैं।

**Aspose.Slides for .NET का उपयोग करके बनाई गई प्रस्तुति** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_2.png)

```c#
//एक प्रस्तुति बनाएं
Presentation pres = new Presentation();

//डिफ़ॉल्ट रूप से एक खाली स्लाइड जोड़ी जाती है, जब आप बनाते हैं
//डिफ़ॉल्ट कंस्ट्रक्टर से प्रस्तुति
//इसलिए, हमें कोई खाली स्लाइड जोड़ने की ज़रूरत नहीं है
ISlide sld = pres.Slides[1];

//एक टेक्स्टबॉक्स जोड़ें
//इसे जोड़ने के लिए, हम पहले एक आयत जोड़ेंगे
IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 1200, 800, 3200, 370);

//उसकी रेखा को छुपाएँ
shp.LineFormat.Style = LineStyle.NotDefined;

//फिर उसके अंदर एक टेक्स्टफ़्रेम जोड़ें
ITextFrame tf = ((IAutoShape)shp).TextFrame;

//पाठ सेट करें
tf.Text = "Text added dynamically";
IPortion port = tf.Paragraphs[0].Portions[0];

port.PortionFormat.FontBold = NullableBool.True;
port.PortionFormat.FontHeight = 32;

//आउटपुट को डिस्क पर सहेजें
pres.Save("c:\\outAspose.ppt", SaveFormat.Ppt);
```