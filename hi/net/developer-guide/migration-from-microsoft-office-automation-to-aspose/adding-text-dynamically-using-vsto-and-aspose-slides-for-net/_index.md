---
title: VSTO और Aspose.Slides for .NET का उपयोग करके डायनामिक रूप से टेक्स्ट जोड़ना
linktitle: डायनामिक रूप से टेक्स्ट जोड़ना
type: docs
weight: 20
url: /hi/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/
keywords:
- टेक्स्ट जोड़ें
- स्थानांतरण
- VSTO
- ऑफिस ऑटोमेशन
- PowerPoint
- प्रेजेंटेशन
- .NET
- C#
- Aspose.Slides
description: "Microsoft Office automation से Aspose.Slides for .NET में माइग्रेट करने और C# में PowerPoint (PPT, PPTX) प्रेजेंटेशन में डायनामिक टेक्स्ट जोड़ने का तरीका देखें।"
---
{{% alert color="info" %}} 

डेवलपर्स के लिए अक्सर जो सामान्य कार्य पूरा करना पड़ता है वह है स्लाइड्स में गतिशील रूप से टेक्स्ट जोड़ना। यह लेख VSTO और [Aspose.Slides for .NET](/slides/hi/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/) का उपयोग करके गतिशील रूप से टेक्स्ट जोड़ने के उदाहरण कोड दिखाता है।

{{% /alert %}} 
## **डायनामिक रूप से टेक्स्ट जोड़ना**
दोनों विधियाँ इन चरणों का पालन करती हैं:

1. एक प्रेजेंटेशन बनाएं।
1. एक खाली स्लाइड जोड़ें।
1. एक टेक्स्ट बॉक्स जोड़ें।
1. कुछ टेक्स्ट सेट करें।
1. प्रेजेंटेशन लिखें।
## **VSTO कोड उदाहरण**
नीचे दिए गए कोड स्निपेट्स एक साधारण स्लाइड और उसपर टेक्स्ट स्ट्रिंग के साथ प्रेजेंटेशन बनाते हैं।

**VSTO में निर्मित प्रेजेंटेशन** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_1.png)

```c#
//नोट: PowerPoint एक नेमस्पेस है जिसे ऊपर इस तरह परिभाषित किया गया है
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;

//प्रेजेंटेशन बनाएं
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//खाली स्लाइड लेआउट प्राप्त करें
PowerPoint.CustomLayout layout = pres.SlideMaster.
	CustomLayouts[7];

//खाली स्लाइड जोड़ें
PowerPoint.Slide sld = pres.Slides.AddSlide(1, layout);

//टेक्स्ट जोड़ें
PowerPoint.Shape shp = sld.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 150, 100, 400, 100);

//टेक्स्ट सेट करें
PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;
txtRange.Text = "Text added dynamically";
txtRange.Font.Name = "Arial";
txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoTrue;
txtRange.Font.Size = 32;

//आउटपुट को डिस्क पर लिखें
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);

```



## **Aspose.Slides for .NET उदाहरण**
नीचे दिए गए कोड स्निपेट्स Aspose.Slides का उपयोग करके एक साधारण स्लाइड और उसपर टेक्स्ट स्ट्रिंग के साथ प्रेजेंटेशन बनाते हैं।

**Aspose.Slides for .NET का उपयोग करके निर्मित प्रेजेंटेशन** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_2.png)

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

//प्रेजेंटेशन बनाएं
Presentation pres = new Presentation();

//डिफ़ॉल्ट रूप से खाली स्लाइड जोड़ी जाती है, जब आप बनाते हैं
//डिफ़ॉल्ट कंस्ट्रक्टर से प्रेजेंटेशन
//इसलिए, हमें कोई खाली स्लाइड जोड़ने की आवश्यकता नहीं है
ISlide sld = pres.Slides[1];

//एक टेक्स्टबॉक्स जोड़ें
//इसे जोड़ने के लिए, हम पहले एक आयत जोड़ेंगे
IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 1200, 800, 3200, 370);

//उसकी लाइन को छिपाएँ
shp.LineFormat.Style = LineStyle.NotDefined;

//फिर उसके भीतर एक टेक्स्टफ़्रेम जोड़ें
ITextFrame tf = ((IAutoShape)shp).TextFrame;

//टेक्स्ट सेट करें
tf.Text = "Text added dynamically";
IPortion port = tf.Paragraphs[0].Portions[0];

port.PortionFormat.FontBold = NullableBool.True;
port.PortionFormat.FontHeight = 32;

//आउटपुट को डिस्क पर लिखें
pres.Save("outAspose.ppt", SaveFormat.Ppt);
```