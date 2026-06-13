---
title: .NET में प्रेज़ेंटेशन में आयत जोड़ें
linktitle: आयत
type: docs
weight: 80
url: /hi/net/rectangle/
keywords:
- आयत जोड़ें
- आयत बनाएं
- आयत आकार
- सरल आयत
- स्वरूपित आयत
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET का उपयोग करके अपनी PowerPoint प्रस्तुतियों में आयत जोड़ें—आसानी से प्रोग्रामेटिकली आकारों को डिजाइन और संशोधित करें।"
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके PowerPoint स्लाइड्स में आयताकार आकार जोड़ने का तरीका दिखाता है। इसमें एक साधारण आयत बनाना, स्वरूपित आयत बनाना, और अपडेटेड प्रेज़ेंटेशन को PPTX फ़ाइल के रूप में सहेजना शामिल है।

आप बुनियादी आयत फ़ॉर्मेटिंग, जैसे ठोस भराव रंग, लाइन रंग, और लाइन चौड़ाई लागू करना भी देखेंगे। अतिरिक्त रूप से, लेख के FAQ में गोल कोने, चित्र भराव, विज़ुअल इफ़ेक्ट, हाइपरलिंक, शेप लॉक, निर्यात विकल्प, और प्रभावी प्रॉपर्टीज़ जैसे संबंधित आयत कार्यों की ओर इशारा किया गया है।

## **एक साधारण आयत बनाएं**
पिछले विषयों की तरह, यह भी एक आकार जोड़ने के बारे में है और इस बार हम जिस आकार पर चर्चा करेंगे वह Rectangle है। इस विषय में हमने बताया है कि डेवलपर्स Aspose.Slides for .NET का उपयोग करके अपनी स्लाइड्स में साधारण या स्वरूपित आयतें कैसे जोड़ सकते हैं। प्रस्तुति की किसी चयनित स्लाइड में एक साधारण आयत जोड़ने के लिए, नीचे दिए गए चरणों का पालन करें:

1. एक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक उदाहरण बनाएं।
1. उसके Index का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।
1. IShapes ऑब्जेक्ट द्वारा प्रदान किए गए AddAutoShape मेथड का उपयोग करके Rectangle प्रकार का IAutoShape जोड़ें।
1. संशोधित प्रेज़ेंटेशन को PPTX फ़ाइल के रूप में लिखें।

नीचे दिए गए उदाहरण में, हमने प्रस्तुति की पहली स्लाइड में एक साधारण आयत जोड़ी है।

```c#
// PPTX का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं
using (Presentation pres = new Presentation())
{

    // पहली स्लाइड प्राप्त करें
    ISlide sld = pres.Slides[0];

    // Rectangle प्रकार का ऑटोशेप जोड़ें
    sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // PPTX फ़ाइल को डिस्क पर लिखें
    pres.Save("RectShp1_out.pptx", SaveFormat.Pptx);
}
```

## **एक स्वरूपित आयत बनाएं**
स्लाइड में एक स्वरूपित आयत जोड़ने के लिए, नीचे दिए गए चरणों का पालन करें:

1. एक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक उदाहरण बनाएं।
1. उसके Index का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।
1. IShapes ऑब्जेक्ट द्वारा प्रदान किए गए AddAutoShape मेथड का उपयोग करके Rectangle प्रकार का IAutoShape जोड़ें।
1. आयत का Fill Type ठोस सेट करें।
1. IShape ऑब्जेक्ट से जुड़े FillFormat ऑब्जेक्ट द्वारा प्रदर्शित SolidFillColor.Color प्रॉपर्टी का उपयोग करके आयत का रंग सेट करें।
1. आयत की लाइनों का रंग सेट करें।
1. आयत की लाइनों की चौड़ाई सेट करें।
1. संशोधित प्रेज़ेंटेशन को PPTX फ़ाइल के रूप में लिखें।
   उपरोक्त चरण नीचे दिए गए उदाहरण में लागू किए गए हैं।

```c#
// PPTX का प्रतिनिधित्व करने वाली Presentation क्लास का एक उदाहरण बनाएं
using (Presentation pres = new Presentation())
{

    // पहली स्लाइड प्राप्त करें
    ISlide sld = pres.Slides[0];

    // Rectangle प्रकार का ऑटोशेप जोड़ें
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // आयत आकार पर कुछ फ़ॉर्मेटिंग लागू करें
    shp.FillFormat.FillType = FillType.Solid;
    shp.FillFormat.SolidFillColor.Color = Color.Chocolate;

    // आयत की रेखा पर कुछ फ़ॉर्मेटिंग लागू करें
    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    shp.LineFormat.Width = 5;

    //PPTX फ़ाइल को डिस्क पर लिखें
    pres.Save("RectShp2_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं आयत को गोल कोनों के साथ कैसे जोड़ूँ?**

गोल-कोना [shape type](https://reference.aspose.com/slides/hi/net/aspose.slides/shapetype/) का उपयोग करें और शेप की प्रॉपर्टी में कोने का त्रिज्या समायोजित करें; ज्यामिति समायोजनों के माध्यम से प्रत्येक कोने पर भी गोलाई लागू की जा सकती है।

**मैं आयत को छवि (टेक्सचर) से कैसे भरूँ?**

[fill type](https://reference.aspose.com/slides/hi/net/aspose.slides/filltype/) चुनें, चित्र स्रोत प्रदान करें, और [stretching/tiling modes](https://reference.aspose.com/slides/hi/net/aspose.slides/picturefillmode/) कॉन्फ़िगर करें।

**क्या आयत में शैडो और ग्लो हो सकता है?**

हाँ। [Outer/inner shadow, glow, and soft edges](/slides/hi/net/shape-effect/) उपलब्ध हैं और इन्हें समायोज्य पैरामीटरों के साथ उपयोग किया जा सकता है।

**क्या मैं आयत को हाइपरलिंक के साथ बटन में बदल सकता हूँ?**

हाँ। शेप क्लिक पर [Assign a hyperlink](/slides/hi/net/manage-hyperlinks/) जोड़ें (स्लाइड, फ़ाइल, वेब पता, या ई‑मेल पर जाएँ)।

**मैं आयत को स्थानांतरण और परिवर्तन से कैसे सुरक्षित कर सकता हूँ?**

[Use shape locks](/slides/hi/net/applying-protection-to-presentation/): आप लेआउट को संरक्षित रखने के लिए स्थानांतरित, आकार बदलने, चयन या टेक्स्ट संपादन को प्रतिबंधित कर सकते हैं।

**क्या मैं आयत को रास्टर इमेज या SVG में बदल सकता हूँ?**

हाँ। आप शेप को निर्दिष्ट आकार/स्केल के साथ इमेज में [render the shape](http://reference.aspose.com/slides/hi/net/aspose.slides/shape/getimage/) कर सकते हैं या वेक्टर उपयोग के लिए इसे [export it as SVG](https://reference.aspose.com/slides/hi/net/aspose.slides/shape/writeassvg/) कर सकते हैं।

**थीम और विरासत को ध्यान में रखते हुए आयत के वास्तविक (effective) प्रॉपर्टीज़ जल्दी से कैसे प्राप्त करूँ?**

[Use the shape’s effective properties](/slides/hi/net/shape-effective-properties/): API ऐसे मूल्य लौटाता है जो थीम स्टाइल, लेआउट, और स्थानीय सेटिंग्स को ध्यान में रखते हुए गणना किए गए होते हैं, जिससे फ़ॉर्मेटिंग विश्लेषण सरल हो जाता है।