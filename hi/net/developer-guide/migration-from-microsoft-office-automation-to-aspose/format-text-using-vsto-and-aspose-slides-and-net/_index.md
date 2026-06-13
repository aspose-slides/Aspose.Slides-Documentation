---
title: VSTO और Aspose.Slides for .NET का उपयोग करके पाठ स्वरूपित करना
linktitle: पाठ स्वरूपित करना
type: docs
weight: 30
url: /hi/net/format-text-using-vsto-and-aspose-slides-and-net/
keywords:
- पाठ स्वरूपित करना
- स्थानांतरण
- VSTO
- ऑफिस ऑटोमेशन
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Microsoft Office ऑटोमेशन से Aspose.Slides for .NET में स्थानांतरित हों और PowerPoint (PPT, PPTX) प्रस्तुतियों में सटीक नियंत्रण के साथ पाठ को स्वरूपित करें।"
---
{{% alert color="primary" %}} 

कभी-कभी, आपको स्लाइड्स पर पाठ को प्रोग्रामेटिकली स्वरूपित करने की आवश्यकता होती है। यह लेख दिखाता है कि कैसे एक नमूना प्रस्तुति को पढ़ा जा सकता है जिसमें पहली स्लाइड पर कुछ पाठ है, चाहे आप [VSTO](/slides/hi/net/format-text-using-vsto-and-aspose-slides-and-net/) और [Aspose.Slides for .NET](/slides/hi/net/format-text-using-vsto-and-aspose-slides-and-net/) में से किसी का उपयोग करें। कोड स्लाइड पर तीसरे टेक्स्टबॉक्स में पाठ को इस प्रकार स्वरूपित करता है कि वह अंतिम टेक्स्टबॉक्स के पाठ जैसा दिखे।

{{% /alert %}} 
## **Formatting Text**
VSTO और Aspose.Slides दोनों विधियाँ निम्नलिखित कदमों का पालन करती हैं:

1. स्रोत प्रस्तुति खोलें।
1. पहली स्लाइड तक पहुँचें।
1. तीसरे टेक्स्टबॉक्स तक पहुँचें।
1. तीसरे टेक्स्टबॉक्स में पाठ के स्वरूप को बदलें।
1. प्रस्तुति को डिस्क पर सहेजें।

नीचे दिए गए स्क्रीनशॉट्स दिखाते हैं कि VSTO और Aspose.Slides for .NET कोड के निष्पादन से पहले और बाद में नमूना स्लाइड कैसी दिखती है।

**The input presentation** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_1.png)
### **VSTO Code Example**
नीचे दिया गया कोड दिखाता है कि VSTO का उपयोग करके एक स्लाइड पर पाठ को कैसे पुनः स्वरूपित किया जाए।

**The text reformatted with VSTO** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_2.png)



```c#
//Note: PowerPoint एक नेमस्पेस है जिसे ऊपर इस प्रकार परिभाषित किया गया है
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;
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




### **Aspose.Slides for .NET Example**
Aspose.Slides के साथ पाठ को स्वरूपित करने के लिए, पाठ को स्वरूपित करने से पहले फ़ॉन्ट जोड़ें।

**The output presentation created with Aspose.Slides** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_3.png)



```c#
 //प्रस्तुति खोलें
Presentation pres = new Presentation("c:\\source.ppt");

//पहली स्लाइड तक पहुँचें
ISlide slide = pres.Slides[0];

//तीसरे आकार तक पहुँचें
IShape shp = slide.Shapes[2];

//इसके पाठ का फ़ॉन्ट Verdana और आकार 32 में बदलें
ITextFrame tf = ((IAutoShape)shp).TextFrame;
IParagraph para = tf.Paragraphs[0];
IPortion port = para.Portions[0];
port.PortionFormat.LatinFont = new FontData("Verdana");

port.PortionFormat.FontHeight = 32;

//बोल्ड करें
port.PortionFormat.FontBold = NullableBool.True;

//इटैलिक करें
port.PortionFormat.FontItalic = NullableBool.True;

//पाठ का रंग बदलें
//फ़ॉन्ट रंग सेट करें
port.PortionFormat.FillFormat.FillType = FillType.Solid;
port.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(0x33, 0x33, 0xCC);

//आकार की पृष्ठभूमि का रंग बदलें
shp.FillFormat.FillType = FillType.Solid;
shp.FillFormat.SolidFillColor.Color = Color.FromArgb(0xCC, 0xCC, 0xFF);

//आउटपुट को डिस्क पर लिखें
pres.Save("c:\\outAspose.ppt", SaveFormat.Ppt);
```