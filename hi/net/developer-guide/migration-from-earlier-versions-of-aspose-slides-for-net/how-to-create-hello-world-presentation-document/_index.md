---
title: .NET में Hello World प्रेजेंटेशन कैसे बनाएं
linktitle: Hello World प्रेजेंटेशन
type: docs
weight: 10
url: /hi/net/how-to-create-hello-world-presentation-document/
keywords:
- माइग्रेशन
- हैलो वर्ल्ड
- लेगेसी कोड
- आधुनिक कोड
- लेगेसी दृष्टिकोण
- आधुनिक दृष्टिकोण
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- .NET
- C#
- Aspose.Slides
description: ".NET में Aspose.Slides के साथ Hello World PowerPoint PPT, PPTX और ODP प्रेजेंटेशन बनाएं, दोनों लेगेसी और आधुनिक APIs का उपयोग करके एक सरल मार्गदर्शिका में।"
---
{{% alert color="info" %}} 
एक नया [Aspose.Slides for .NET API](/slides/hi/net/) जारी किया गया है और अब यह एकल उत्पाद शुरू से PowerPoint दस्तावेज़ बनाने और मौजूदा दस्तावेज़ों को संपादित करने की क्षमता को समर्थन देता है।
{{% /alert %}} 
## **Legacy कोड के लिए समर्थन**
Aspose.Slides for .NET के 13.x से पहले के संस्करणों के साथ विकसित किए गए लेगेसी कोड का उपयोग करने के लिए, आपको अपने कोड में कुछ छोटे बदलाव करने होंगे और कोड पहले की तरह काम करेगा। पुरानी Aspose.Slides for .NET में Aspose.Slide और Aspose.Slides.Pptx नेमस्पेसेज़ के तहत मौजूद सभी क्लासेज अब एक ही Aspose.Slides नेमस्पेस में मिलाए गए हैं। कृपया नीचे दिए गए सरल कोड स्निपेट को देखें जो लेगेसी Aspose.Slides API में Hello World Presentation दस्तावेज़ बनाने के लिए है और उन चरणों का पालन करें जो नई मर्ज्ड API में माइग्रेट करने का वर्णन करते हैं।
## **Legacy Aspose.Slides for .NET दृष्टिकोण**
```c#
using System.Drawing;
using Aspose.Slides;

//एक Presentation ऑब्जेक्ट बनाएं जो PPT फ़ाइल का प्रतिनिधित्व करता है
Presentation pres = new Presentation();

//एक License ऑब्जेक्ट बनाएं
License license = new License();

//Evaluations सीमाओं से बचने के लिए Aspose.Slides for .NET का लाइसेंस सेट करें
license.SetLicense("Aspose.Slides.lic");

//प्रेजेंटेशन में एक खाली स्लाइड जोड़ें और उसका रेफ़रेंस प्राप्त करें
//वह खाली स्लाइड
Slide slide = pres.AddEmptySlide();

//स्लाइड में एक आयत (X=2400, Y=1800, Width=1000 & Height=500) जोड़ें
Aspose.Slides.Rectangle rect = slide.Shapes.AddRectangle(2400, 1800, 1000, 500);

//आयत की रेखाओं को छिपाएँ
rect.LineFormat.ShowLines = false;

//आयत में "Hello World" को डिफ़ॉल्ट टेक्स्ट के साथ एक टेक्स्ट फ़्रेम जोड़ें
rect.AddTextFrame("Hello World");

//प्रेजेंटेशन की पहली स्लाइड हटाएं जो हमेशा द्वारा जोड़ी जाती है
//डिफ़ॉल्ट रूप से Aspose.Slides for .NET द्वारा प्रेजेंटेशन बनाते समय
pres.Slides.RemoveAt(0);

//Writing the presentation as a PPT file
pres.Write("C:\\hello.ppt");
```



## **नया Aspose.Slides for .NET 13.x दृष्टिकोण**
```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Presentation को इंस्टैंशिएट करें
Presentation pres = new Presentation();

// Get the first slide
ISlide sld = (ISlide)pres.Slides[0];

// Add an AutoShape of Rectangle type
IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

// Add ITextFrame to the Rectangle
ashp.AddTextFrame("Hello World");

// Change the text color to Black (which is White by default)
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Change the line color of the rectangle to White
ashp.ShapeStyle.LineColor.Color = Color.White;

// Remove any fill formatting in the shape
ashp.FillFormat.FillType = FillType.NoFill;

// Save the presentation to disk
pres.Save("HelloWorld.pptx", SaveFormat.Pptx);
```