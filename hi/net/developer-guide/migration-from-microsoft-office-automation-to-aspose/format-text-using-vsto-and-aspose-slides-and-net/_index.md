---
title: VSTO और Aspose.Slides for .NET का उपयोग करके टेक्स्ट फ़ॉर्मेट करें
linktitle: टेक्स्ट फ़ॉर्मेट
type: docs
weight: 30
url: /hi/net/format-text-using-vsto-and-aspose-slides-and-net/
keywords:
- टेक्स्ट फ़ॉर्मेट
- माइग्रेशन
- VSTO
- ऑफिस ऑटोमेशन
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Microsoft Office ऑटोमेशन से Aspose.Slides for .NET में माइग्रेट करें और PowerPoint (PPT, PPTX) प्रस्तुतियों में सटीक नियंत्रण के साथ टेक्स्ट फ़ॉर्मेट करें।"
---
{{% alert color="info" %}}

कभी‑कभी, आपको स्लाइड्स पर पाठ को प्रोग्रामेटिकली स्वरूपित करने की आवश्यकता होती है। यह लेख दिखाता है कि कैसे पहले स्लाइड पर कुछ पाठ वाले एक नमूना प्रस्तुति को पढ़ा जाए, चाहे आप [VSTO](/slides/hi/net/format-text-using-vsto-and-aspose-slides-and-net/) या [Aspose.Slides for .NET](/slides/hi/net/format-text-using-vsto-and-aspose-slides-and-net/) उपयोग करें। कोड स्लाइड के तीसरे टेक्स्टबॉक्स में पाठ को इस तरह स्वरूपित करता है कि वह अंतिम टेक्स्टबॉक्स के पाठ जैसा दिखे।

{{% /alert %}}
## **पाठ स्वरूपण**
VSTO और Aspose.Slides दोनों विधियाँ निम्नलिखित चरणों को अपनाती हैं:

1. स्रोत प्रस्तुति खोलें।
1. पहली स्लाइड तक पहुंचें।
1. तीसरे टेक्स्ट बॉक्स तक पहुंचें।
1. तीसरे टेक्स्ट बॉक्स में पाठ का स्वरूप बदलें।
1. प्रस्तुति को डिस्क पर सहेजें।

नीचे दिखाए गए स्क्रीनशॉट्स VSTO और Aspose.Slides for .NET कोड के निष्पादन से पहले और बाद की नमूना स्लाइड को दर्शाते हैं।

**इनपुट प्रस्तुति**

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_1.png)
### **VSTO कोड उदाहरण**
नीचे दिया गया कोड दिखाता है कि VSTO का उपयोग करके स्लाइड पर पाठ का स्वरूप कैसे बदलें।

**VSTO के साथ पुनः स्वरूपित पाठ**

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_2.png)



```c#
//नोट: PowerPoint एक नेमस्पेस है जिसे ऊपर इस तरह परिभाषित किया गया है
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;
PowerPoint.Presentation pres = null;

//Open the presentation
pres = Globals.ThisAddIn.Application.Presentations.Open("c:\\source.ppt",
	Microsoft.Office.Core.MsoTriState.msoFalse,
	Microsoft.Office.Core.MsoTriState.msoFalse,
	Microsoft.Office.Core.MsoTriState.msoTrue);

//Access the first slide
PowerPoint.Slide slide = pres.Slides[1];

//Access the third shape
PowerPoint.Shape shp = slide.Shapes[3];

//Change its text's font to Verdana and height to 32
PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;
txtRange.Font.Name = "Verdana";
txtRange.Font.Size = 32;

//Bolden it
txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoCTrue;

//Italicize it
txtRange.Font.Italic = Microsoft.Office.Core.MsoTriState.msoCTrue;

//Change text color
txtRange.Font.Color.RGB = 0x00CC3333;

//Change shape background color
shp.Fill.ForeColor.RGB = 0x00FFCCCC;

//Reposition it horizontally
shp.Left -= 70;

//Write the output to disk
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```




### **Aspose.Slides for .NET उदाहरण**
Aspose.Slides के साथ पाठ को स्वरूपित करने के लिए, पाठ को स्वरूपित करने से पहले फ़ॉन्ट जोड़ें।

**Aspose.Slides द्वारा निर्मित आउटपुट प्रस्तुति**

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_3.png)



```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

 //प्रस्तुति खोलें
Presentation pres = new Presentation("source.ppt");

//Access the first slide
ISlide slide = pres.Slides[0];

//Access the third shape
IShape shp = slide.Shapes[2];

//Change its text's font to Verdana and height to 32
ITextFrame tf = ((IAutoShape)shp).TextFrame;
IParagraph para = tf.Paragraphs[0];
IPortion port = para.Portions[0];
port.PortionFormat.LatinFont = new FontData("Verdana");

port.PortionFormat.FontHeight = 32;

//इसे बोल्ड बनाएं
port.PortionFormat.FontBold = NullableBool.True;

//इसे इटैलिक बनाएं
port.PortionFormat.FontItalic = NullableBool.True;

//पाठ का रंग बदलें
//फ़ॉन्ट का रंग सेट करें
port.PortionFormat.FillFormat.FillType = FillType.Solid;
port.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(0x33, 0x33, 0xCC);

//आकार की पृष्ठभूमि का रंग बदलें
shp.FillFormat.FillType = FillType.Solid;
shp.FillFormat.SolidFillColor.Color = Color.FromArgb(0xCC, 0xCC, 0xFF);

//आउटपुट को डिस्क पर लिखें
pres.Save("outAspose.ppt", SaveFormat.Ppt);
```