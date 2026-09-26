---
title: .NET में Hello World प्रस्तुतियाँ कैसे बनाएं
linktitle: Hello World प्रस्तुति
type: docs
weight: 10
url: /hi/net/how-to-create-hello-world-presentation-document/
keywords:
- माइग्रेशन
- हैलो वर्ल्ड
- विरासत कोड
- आधुनिक कोड
- विरासत दृष्टिकोण
- आधुनिक दृष्टिकोण
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: ".NET में Aspose.Slides का उपयोग करके दोनों विरासत और आधुनिक APIs के साथ Hello World PowerPoint PPT, PPTX और ODP प्रस्तुति बनाएं, एक सरल गाइड में।"
---
{{% alert color="info" %}} 

एक नया [Aspose.Slides for .NET API](/slides/hi/net/) जारी किया गया है और अब यह एकल उत्पाद शुरुआती से PowerPoint दस्तावेज़ बनाने और मौजूदा दस्तावेज़ों को संपादित करने की क्षमता प्रदान करता है।

{{% /alert %}} 
## **पुराने कोड के लिए समर्थन**
13.x से पूर्व के Aspose.Slides for .NET संस्करणों के साथ विकसित किए गए पुराने कोड का उपयोग करने के लिए, आपको अपने कोड में कुछ छोटे परिवर्तन करने की आवश्यकता है और कोड पहले की तरह कार्य करेगा। पुराने Aspose.Slides for .NET में Aspose.Slide और Aspose.Slides.Pptx नामस्थान में मौजूद सभी क्लासेज अब एकल Aspose.Slides नामस्थान में मिल गई हैं। कृपया निम्नलिखित सरल कोड स्निपेट देखें जो पुरानी Aspose.Slides API में Hello World Presentation दस्तावेज़ बनाने के लिए है और नई मिलीजुली API में माइग्रेट करने के चरणों का पालन करें।

## **Legacy Aspose.Slides for .NET दृष्टिकोण**
```c#
using System.Drawing;
using Aspose.Slides;

//एक Presentation ऑब्जेक्ट बनाते हैं जो PPT फ़ाइल का प्रतिनिधित्व करता है
//एक License ऑब्जेक्ट बनाएं
//Aspose.Slides for .NET की लाइसेंस सेट करें ताकि मूल्यांकन प्रतिबंध न हों
//प्रस्तुति में एक खाली स्लाइड जोड़ रहे हैं और उसका संदर्भ प्राप्त कर रहे हैं
//उस खाली स्लाइड का
//स्लाइड में एक आयत (X=2400, Y=1800, चौड़ाई=1000 & Height=500) जोड़ रहे हैं
//आयत की लाइनों को छिपा रहे हैं
//आयत में एक टेक्स्ट फ्रेम जोड़ते हैं जिसमें डिफ़ॉल्ट टेक्स्ट "Hello World" है
//प्रस्तुति की पहली स्लाइड को हटा रहे हैं जो हमेशा द्वारा जोड़ी जाती है
//प्रस्तुति बनाते समय डिफ़ॉल्ट रूप से Aspose.Slides for .NET द्वारा
Presentation pres = new Presentation();

//Create a License object
License license = new License();

//Set the license of Aspose.Slides for .NET to avoid the evaluation limitations
license.SetLicense("Aspose.Slides.lic");

//Adding an empty slide to the presentation and getting the reference of
//that empty slide
Slide slide = pres.AddEmptySlide();

//Adding a rectangle (X=2400, Y=1800, Width=1000 & Height=500) to the slide
Aspose.Slides.Rectangle rect = slide.Shapes.AddRectangle(2400, 1800, 1000, 500);

//Hiding the lines of rectangle
rect.LineFormat.ShowLines = false;

//Adding a text frame to the rectangle with "Hello World" as a default text
rect.AddTextFrame("Hello World");

//Removing the first slide of the presentation which is always added by
//Aspose.Slides for .NET by default while creating the presentation
pres.Slides.RemoveAt(0);

//Writing the presentation as a PPT file
pres.Write("C:\\hello.ppt");
```



## **नया Aspose.Slides for .NET 13.x दृष्टिकोण**
```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Presentation बनाएं
Presentation pres = new Presentation();

// पहली स्लाइड प्राप्त करें
ISlide sld = (ISlide)pres.Slides[0];

// Rectangle प्रकार का AutoShape जोड़ें
IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

// Rectangle में ITextFrame जोड़ें
ashp.AddTextFrame("Hello World");

// टेक्स्ट का रंग काला बदलें (डिफ़ॉल्ट रूप से यह सफेद होता है)
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Rectangle की लाइन का रंग सफेद करें
ashp.ShapeStyle.LineColor.Color = Color.White;

// शेप में किसी भी फ़िल फ़ॉर्मेट को हटाएँ
ashp.FillFormat.FillType = FillType.NoFill;

// प्रेजेंटेशन को डिस्क पर सेव करें
pres.Save("HelloWorld.pptx", SaveFormat.Pptx);
```