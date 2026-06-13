---
title: .NET में Hello World प्रेज़ेंटेशन कैसे बनाएं
linktitle: Hello World प्रेज़ेंटेशन
type: docs
weight: 10
url: /hi/net/how-to-create-hello-world-presentation-document/
keywords:
- माइग्रेशन
- हेलो वर्ल्ड
- लेगेसी कोड
- मॉडर्न कोड
- लेगेसी अप्रोच
- मॉडर्न अप्रोच
- पॉवरपॉइंट
- ओपनडॉक्यूमेंट
- प्रेज़ेंटेशन
- .NET
- C#
- Aspose.Slides
- description: "Aspose.Slides का उपयोग करके .NET में Hello World PowerPoint PPT, PPTX और ODP प्रेज़ेंटेशन बनाएं, जिसमें लेगेसी और मॉडर्न दोनों API का एक सरल गाइड शामिल है।"
---
{{% alert color="primary" %}} 
एक नया [Aspose.Slides for .NET API](/slides/hi/net/) जारी किया गया है और अब यह एकल उत्पाद स्क्रैच से PowerPoint दस्तावेज़ बनाने और मौजूदा दस्तावेज़ों को संपादित करने की क्षमता का समर्थन करता है।
{{% /alert %}} 
## **Legacy कोड के लिए समर्थन**
Aspose.Slides for .NET के 13.x से पहले के संस्करणों के साथ विकसित किए गए लेगेसी कोड को उपयोग करने के लिए आपको अपने कोड में कुछ छोटे परिवर्तन करने की आवश्यकता है और कोड पहले की तरह काम करेगा। पुराने Aspose.Slides for .NET में Aspose.Slide और Aspose.Slides.Pptx नेमस्पेसेज़ के अंतर्गत मौजूद सभी क्लासेज़ अब एकल Aspose.Slides नेमस्पेस में मिश्रित हो गई हैं। कृपया नीचे दिए गए सरल कोड स्निपेट को देखें जो लेगेसी Aspose.Slides API में एक Hello World प्रेज़ेंटेशन दस्तावेज़ बनाता है और नई मिश्रित API में माइग्रेट करने के चरणों का पालन करें।
## **Legacy Aspose.Slides for .NET दृष्टिकोण**
```c#
//एक Presentation ऑब्जेक्ट बनाएं जो PPT फ़ाइल का प्रतिनिधित्व करता है
Presentation pres = new Presentation();

//एक License ऑब्जेक्ट बनाएं
License license = new License();

//Aspose.Slides for .NET का लाइसेंस सेट करें ताकि मूल्यांकन सीमाओं से बचा जा सके
license.SetLicense("Aspose.Slides.lic");

//प्रेज़ेंटेशन में एक खाली स्लाइड जोड़ रहे हैं और उसका रेफ़रेंस प्राप्त कर रहे हैं
//उस खाली स्लाइड का
Slide slide = pres.AddEmptySlide();

//स्लाइड में एक आयत (X=2400, Y=1800, Width=1000 & Height=500) जोड़ रहे हैं
Aspose.Slides.Rectangle rect = slide.Shapes.AddRectangle(2400, 1800, 1000, 500);

//आयत की रेखाओं को छुपा रहे हैं
rect.LineFormat.ShowLines = false;

//आयत में एक टेक्स्ट फ्रेम जोड़ रहे हैं जिसमें डिफॉल्ट टेक्स्ट "Hello World" है
rect.AddTextFrame("Hello World");

//प्रेज़ेंटेशन की पहली स्लाइड हटाएं जो हमेशा जोड़ दी जाती है
//Aspose.Slides for .NET द्वारा डिफ़ॉल्ट रूप से प्रेज़ेंटेशन बनाने के समय
pres.Slides.RemoveAt(0);

//प्रेज़ेंटेशन को PPT फ़ाइल के रूप में लिख रहे हैं
pres.Write("C:\\hello.ppt");
```

## **नया Aspose.Slides for .NET 13.x दृष्टिकोण**
```c#
// Presentation को instantiate करें
Presentation pres = new Presentation();

// पहली स्लाइड प्राप्त करें
ISlide sld = (ISlide)pres.Slides[0];

// Rectangle प्रकार की AutoShape जोड़ें
IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

// Rectangle में ITextFrame जोड़ें
ashp.AddTextFrame("Hello World");

// Change the text color to Black (which is White by default)
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Change the line color of the rectangle to White
ashp.ShapeStyle.LineColor.Color = Color.White;

// Remove any fill formatting in the shape
ashp.FillFormat.FillType = FillType.NoFill;

// Save the presentation to disk
pres.Save("D:\\data\\HelloWorld.pptx", SaveFormat.Pptx);
```