---
title: Java में प्रस्तुतियों में आयतें जोड़ें
linktitle: आयत
type: docs
weight: 80
url: /hi/java/rectangle/
keywords:
- आयत जोड़ें
- आयत बनाएं
- आयत आकार
- सरल आयत
- स्वरूपित आयत
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ आयतें जोड़कर अपने PowerPoint प्रस्तुतियों को उन्नत करें—आकारों को प्रोग्रामेटिक रूप से आसानी से डिज़ाइन और संशोधित करें।"
---
## **समीक्षा**

यह लेख Aspose.Slides का उपयोग करके PowerPoint स्लाइड्स में आयताकार आकृतियों को जोड़ने का तरीका दर्शाता है। यह एक साधारण आयत बनाना, एक स्वरूपित आयत बनाना, और अद्यतन प्रस्तुति को PPTX फ़ाइल के रूप में सहेजना शामिल करता है।

आप यह भी देखेंगे कि मूल आयत स्वरूपण कैसे लागू करें, जैसे ठोस भराव रंग, रेखा रंग, और रेखा की चौड़ाई। इसके अलावा, लेख के FAQ में संबंधित आयत कार्यों की ओर संकेत किया गया है, जैसे गोल कोने, चित्र भराव, दृश्य प्रभाव, हाइपरलिंक्स, shape locks, निर्यात विकल्प, और प्रभावी गुण।

## **स्लाइड में आयत जोड़ें**
एक चयनित स्लाइड में साधारण आयत जोड़ने के लिए, कृपया नीचे दिए गए चरणों का पालन करें:

- [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएं।
- इंडेक्स का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।
- [IAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IAutoShape) के Rectangle प्रकार को [addAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) मेथड का उपयोग करके, जो [IShapeCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IShapeCollection) ऑब्जेक्ट द्वारा प्रदान किया गया है, जोड़ें।
- परिवर्तित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

नीचे दिए गए उदाहरण में हमने प्रस्तुति की पहली स्लाइड में साधारण आयत जोड़ी है।

```java
// PPTX का प्रतिनिधित्व करने वाले Prseetation क्लास को instantiate करें
Presentation pres = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें
    ISlide sld = pres.getSlides().get_Item(0);

    // ellipse प्रकार का AutoShape जोड़ें
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // PPTX फ़ाइल को डिस्क पर लिखें
    pres.save("RecShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **स्लाइड में स्वरूपित आयत जोड़ें**
स्लाइड में स्वरूपित आयत जोड़ने के लिए, कृपया नीचे दिए गए चरणों का पालन करें:

- [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएं।
- इंडेक्स का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।
- [IAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IAutoShape) के Rectangle प्रकार को [addAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) मेथड का उपयोग करके, जो [IShapeCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IShapeCollection) ऑब्जेक्ट द्वारा प्रदान किया गया है, जोड़ें।
- आयत का [Fill Type](https://reference.aspose.com/slides/hi/java/com.aspose.slides/FillType) Solid पर सेट करें।
- आयत का रंग [SolidFillColor.setColor](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IColorFormat#setColor-java.awt.Color-) मेथड का उपयोग करके सेट करें, जो [IFillFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IFillFormat) ऑब्जेक्ट द्वारा प्रदान किया गया है और [IShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IShape) ऑब्जेक्ट से जुड़ा है।
- आयत की रेखाओं का रंग सेट करें।
- आयत की रेखाओं की चौड़ाई सेट करें।
- परिवर्तित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

ऊपर दिए गए चरण नीचे दिए गए उदाहरण में लागू किए गए हैं।

```java
// PPTX का प्रतिनिधित्व करने वाले Prseetation क्लास को instantiate करें
Presentation pres = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें
    ISlide sld = pres.getSlides().get_Item(0);

    // ellipse प्रकार का AutoShape जोड़ें
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // ellipse आकार पर कुछ स्वरूपण लागू करें
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    // ellipse की रेखा पर कुछ स्वरूपण लागू करें
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // PPTX फ़ाइल को डिस्क पर लिखें
    pres.save("RecShp2.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**मैं कैसे एक गोल कोनों वाली आयत जोड़ूँ?**

गोल-कोने वाले [shape type](https://reference.aspose.com/slides/hi/java/com.aspose.slides/shapetype/) का उपयोग करें और आकार की प्रॉपर्टीज़ में कोने का त्रिज्या समायोजित करें; गोलाई को जियोमेट्री समायोजनों के द्वारा प्रत्येक कोने पर भी लागू किया जा सकता है।

**मैं कैसे आयत को छवि (टेक्सचर) से भरूँ?**

चित्र [fill type](https://reference.aspose.com/slides/hi/java/com.aspose.slides/filltype/) चुनें, छवि स्रोत प्रदान करें, और [stretching/tiling modes](https://reference.aspose.com/slides/hi/java/com.aspose.slides/picturefillmode/) कॉन्फ़िगर करें।

**क्या आयत में छाया और चमक हो सकती है?**

हां। [Outer/inner shadow, glow, and soft edges](/slides/hi/java/shape-effect/) उपलब्ध हैं और पैरामीटर्स समायोज्य हैं।

**क्या मैं आयत को हाइपरलिंक के साथ बटन बना सकता हूँ?**

हां। [Assign a hyperlink](/slides/hi/java/manage-hyperlinks/) को आकार पर क्लिक करने पर सेट करें (स्लाइड, फ़ाइल, वेब पता, या ईमेल पर जाएँ)।

**मैं कैसे आयत को स्थानांतरण और परिवर्तन से सुरक्षित रख सकता हूँ?**

[Use shape locks](/slides/hi/java/applying-protection-to-presentation/): आप लेआउट को सुरक्षित रखने के लिए स्थानांतरण, आकार बदलना, चयन, या टेक्स्ट संपादन को रोक सकते हैं।

**क्या मैं आयत को रास्टर छवि या SVG में बदल सकता हूँ?**

हां। आप आकार को निर्दिष्ट आकार/स्केल के साथ छवि में [render the shape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/shape/#getImage-int-float-float-) कर सकते हैं या वेक्टर उपयोग के लिए इसे [export it as SVG](https://reference.aspose.com/slides/hi/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) कर सकते हैं।

**थीम और विरासत को ध्यान में रखते हुए आयत की वास्तविक (प्रभावी) गुण जल्दी कैसे प्राप्त करूँ?**

[Use the shape’s effective properties](/slides/hi/java/shape-effective-properties/): API ऐसे गणना किए हुए मान लौटाता है जो थीम शैलियों, लेआउट और स्थानीय सेटिंग्स को ध्यान में रखते हैं, जिससे स्वरूपण विश्लेषण सरल हो जाता है।