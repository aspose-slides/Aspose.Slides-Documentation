---
title: C++ में प्रस्तुतियों में आयतें जोड़ें
linktitle: आयत
type: docs
weight: 80
url: /hi/cpp/rectangle/
keywords:
- आयत जोड़ें
- आयत बनाएं
- आयत आकार
- साधारण आयत
- फ़ॉर्मेटेड आयत
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ अपनी PowerPoint प्रस्तुतियों में आयतें जोड़कर उन्हें आसानी से प्रोग्रामेटिक तौर पर डिजाइन और संशोधित करें।"
---
## **Overview**

यह लेख Aspose.Slides का उपयोग करके PowerPoint स्लाइड्स में आयत आकार जोड़ने का तरीका दिखाता है। इसमें एक साधारण आयत बनाना, एक फ़ॉर्मेटेड आयत बनाना, और अद्यतन प्रस्तुति को PPTX फ़ाइल के रूप में सहेजना शामिल है।

## **Create a Simple Rectangle**
पहले के विषयों की तरह, यह भी आकार जोड़ने के बारे में है और इस बार हम जिस आकार पर चर्चा करेंगे वह Rectangle है। इस विषय में हमने बताया है कि डेवलपर Aspose.Slides for C++ का उपयोग करके अपनी स्लाइड्स में सरल या फ़ॉर्मेटेड आयतें कैसे जोड़ सकते हैं। प्रस्तुतिकरण की चयनित स्लाइड में एक साधारण आयत जोड़ने के लिए, नीचे दिए गए चरणों का पालन करें:

1. Create an instance of [Presentation class](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/).
2. Obtain the reference of a slide by using its Index.
3. Add an IAutoShape of Rectangle type using AddAutoShape method exposed by IShapes object.
4. Write the modified presentation as a PPTX file.

नीचे दिए गए उदाहरण में, हमने प्रस्तुति की पहली स्लाइड में एक साधारण आयत जोड़ी है।

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SimpleRectangle-SimpleRectangle.cpp" >}}

## **Create a Formatted Rectangle**
किसी स्लाइड में फ़ॉर्मेटेड आयत जोड़ने के लिए, नीचे दिए गए चरणों का पालन करें:

1. Create an instance of [Presentation class](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/).
2. Obtain the reference of a slide by using its Index.
3. Add an IAutoShape of Rectangle type using AddAutoShape method exposed by IShapes object.
4. Set the Fill Type of the Rectangle to Solid.
5. Set the Color of the Rectangle using SolidFillColor.Color property as exposed by FillFormat object associated with the IShape object.
6. Set the Color of the lines of the Rectangle.
7. Set the Width of the lines of the Rectangle.
8. Write the modified presentation as PPTX file.
   उपरोक्त चरण नीचे दिए गए उदाहरण में लागू किए गए हैं।

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FormattedRectangle-FormattedRectangle.cpp" >}}

## **FAQ**

**How do I add a rectangle with rounded corners?**

राउंडेड‑कोर्नर [shape type](https://reference.aspose.com/slides/hi/cpp/aspose.slides/shapetype/) का उपयोग करें और आकार की प्रॉपर्टीज़ में कॉर्नर रेडियस समायोजित करें; ज्यामिति समायोजन के द्वारा प्रत्येक कोर्नर पर भी राउंडिंग लागू की जा सकती है।

**How do I fill a rectangle with an image (texture)?**

पिक्चर [fill type](https://reference.aspose.com/slides/hi/cpp/aspose.slides/filltype/) चुनें, इमेज स्रोत प्रदान करें, और [stretching/tiling modes](https://reference.aspose.com/slides/hi/cpp/aspose.slides/picturefillmode/) को कॉन्फ़िगर करें।

**Can a rectangle have shadow and glow?**

हां। [Outer/inner shadow, glow, and soft edges](/slides/hi/cpp/shape-effect/) उपलब्ध हैं और उनके पैरामीटर समायोज्य हैं।

**Can I turn a rectangle into a button with a hyperlink?**

हां। आकार पर क्लिक (स्लाइड, फ़ाइल, वेब पता, या ई‑मेल पर जाएं) के लिए [Assign a hyperlink](/slides/hi/cpp/manage-hyperlinks/) जोड़ सकते हैं।

**How can I protect a rectangle from moving and changes?**

[Use shape locks](/slides/hi/cpp/applying-protection-to-presentation/): आप मूविंग, रिसाइज़िंग, चयन, या टेक्स्ट एडिटिंग को रोक सकते हैं ताकि लेआउट बना रहे।

**Can I convert a rectangle to a raster image or SVG?**

हां। आप आकार को निर्दिष्ट आकार/स्केल के साथ इमेज में [render the shape](http://reference.aspose.com/slides/hi/cpp/aspose.slides/shape/getimage/) कर सकते हैं या [export it as SVG](https://reference.aspose.com/slides/hi/cpp/aspose.slides/shape/writeassvg/) करके वेक्टर रूप में उपयोग कर सकते हैं।

**How do I quickly get the actual (effective) properties of a rectangle considering theme and inheritance?**

[Use the shape’s effective properties](/slides/hi/cpp/shape-effective-properties/): API गणना किए गए मान लौटाता है जो थीम स्टाइल, लेआउट, और स्थानीय सेटिंग्स को ध्यान में रखता है, जिससे फॉर्मेटिंग विश्लेषण सरल हो जाता है।