---
title: PHP में प्रस्तुतियों में आयतें जोड़ें
linktitle: आयत
type: docs
weight: 80
url: /hi/php-java/rectangle/
keywords:
- आयत जोड़ें
- आयत बनाएं
- आयत आकार
- सरल आयत
- स्वरूपित आयत
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java के साथ आयतें जोड़कर अपने PowerPoint प्रस्तुतियों को बढ़ाएं — प्रोग्रामेटिकली आकारों को आसानी से डिजाइन और संशोधित करें।"
---
## **परिचय**

यह लेख Aspose.Slides का उपयोग करके PowerPoint स्लाइड्स में आयत आकार जोड़ने का तरीका दर्शाता है। यह एक साधारण आयत बनाने, एक स्वरूपित आयत बनाने, और अद्यतन प्रस्तुति को PPTX फ़ाइल के रूप में सहेजने को कवर करता है।

आप यह भी देखेंगे कि ठोस भराव रंग, रेखा रंग, और रेखा चौड़ाई जैसी बुनियादी आयत स्वरूपण कैसे लागू किया जाए। इसके अतिरिक्त, लेख की अक्सर पूछे जाने वाले प्रश्न (FAQ) में गोल कोनों, चित्र भराव, दृश्य प्रभाव, हाइपरलिंक, आकार लॉक, निर्यात विकल्प, और प्रभावी गुणों सहित संबंधित आयत कार्यों की ओर संकेत दिया गया है।

## **स्लाइड में आयत जोड़ें**
प्रस्तुति की चयनित स्लाइड में एक साधारण आयत जोड़ने के लिए, कृपया नीचे दिए गए चरणों का पालन करें:

- एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation) क्लास का उदाहरण बनाएँ।
- उसके इंडेक्स का उपयोग करके स्लाइड का संदर्भ प्राप्त करें.
- स्लाइड में [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) प्रकार की आयत जोड़ने के लिए [addAutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapecollection/#addAutoShape) मेथड का उपयोग करें, जो [ShapeCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapecollection/) ऑब्जेक्ट द्वारा प्रदान किया गया है।
- परिवर्तित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

नीचे दिए गए उदाहरण में, हमने प्रस्तुति की पहली स्लाइड में एक साधारण आयत जोड़ी है।

```php
  # PPTX को दर्शाने वाली Presentation क्लास का उदाहरण बनाएं
  $pres = new Presentation();
  try {
    # पहली स्लाइड प्राप्त करें
    $sld = $pres->getSlides()->get_Item(0);
    # ellipse प्रकार की AutoShape जोड़ें
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 50);
    # PPTX फ़ाइल को डिस्क पर लिखें
    $pres->save("RecShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **स्लाइड में स्वरूपित आयत जोड़ें**
स्लाइड में स्वरूपित आयत जोड़ने के लिए, कृपया नीचे दिए गए चरणों का पालन करें:

- एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation) क्लास का उदाहरण बनाएँ।
- उसके इंडेक्स का उपयोग करके स्लाइड का संदर्भ प्राप्त करें.
- स्लाइड में [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) प्रकार की आयत जोड़ने के लिए [addAutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapecollection/#addAutoShape) मेथड का उपयोग करें, जो [ShapeCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapecollection/) ऑब्जेक्ट द्वारा प्रदान किया गया है।
- आयत के [Fill Type](https://reference.aspose.com/slides/hi/php-java/aspose.slides/FillType) को Solid सेट करें।
- आयत का रंग [ColorFormat::setColor](https://reference.aspose.com/slides/hi/php-java/aspose.slides/colorformat/#setColor) मेथड का उपयोग करके सेट करें, जो [FillFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fillformat/) ऑब्जेक्ट द्वारा प्रदान किया गया है, जो [Shape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/) ऑब्जेक्ट से जुड़ा है।
- आयत की रेखाओं का रंग सेट करें।
- आयत की रेखाओं की चौड़ाई सेट करें।
- परिवर्तित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

उपर्युक्त चरण नीचे दिए गए उदाहरण में लागू किए गए हैं।

```php
  # PPTX का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं
  $pres = new Presentation();
  try {
    # पहली स्लाइड प्राप्त करें
    $sld = $pres->getSlides()->get_Item(0);
    # ellipse प्रकार की AutoShape जोड़ें
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 50);
    # ellipse आकार पर कुछ स्वरूपण लागू करें
    $shp->getFillFormat()->setFillType(FillType::Solid);
    $shp->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    # Ellipse की रेखा पर कुछ स्वरूपण लागू करें
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp->getLineFormat()->setWidth(5);
    # PPTX फ़ाइल को डिस्क पर लिखें
    $pres->save("RecShp2.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं गोल कोनों के साथ आयत कैसे जोड़ूँ?**  
गोल-कॉनर [shape type](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapetype/) का उपयोग करें और आकार की गुणधर्मों में कॉर्नर रेडियस को समायोजित करें; ज्यामिति समायोजन के माध्यम से प्रत्येक कोने पर भी गोलाई लागू की जा सकती है।

**मैं आयत को छवि (टेक्सचर) से कैसे भरूँ?**  
चित्र [fill type](https://reference.aspose.com/slides/hi/php-java/aspose.slides/filltype/) चुनें, छवि स्रोत प्रदान करें, और [stretching/tiling modes](https://reference.aspose.com/slides/hi/php-java/aspose.slides/picturefillmode/) को कॉन्फ़िगर करें।

**क्या आयत में छाया और चमक हो सकती है?**  
हाँ। [Outer/inner shadow, glow, and soft edges](/slides/hi/php-java/shape-effect/) उपलब्ध हैं और इन्हें समायोज्य पैरामीटरों के साथ उपयोग किया जा सकता है।

**क्या मैं आयत को हाइपरलिंक वाले बटन में बदल सकता हूँ?**  
हाँ। आकृति के क्लिक पर [Assign a hyperlink](/slides/hi/php-java/manage-hyperlinks/) असाइन करें (स्लाइड, फ़ाइल, वेब पता या ई‑मेल पर जाएँ)।

**मैं आयत को स्थानांतरित और बदलावों से कैसे सुरक्षित रखूँ?**  
shape locks का उपयोग करें: आप लेआउट को बनाए रखने के लिए स्थानांतरित करना, आकार बदलना, चयन या पाठ संपादन को प्रतिबंधित कर सकते हैं।

**क्या मैं आयत को रास्टर छवि या SVG में बदल सकता हूँ?**  
हाँ। आप [render the shape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/#getImage) को निर्दिष्ट आकार/स्केल के साथ छवि में रेंडर कर सकते हैं या वैक्टर उपयोग के लिए इसे [export it as SVG](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/writeassvg/) कर सकते हैं।

**थीम और विरासत को ध्यान में रखते हुए आयत की वास्तविक (effective) गुणधर्म तेजी से कैसे प्राप्त करें?**  
[Use the shape’s effective properties](/slides/hi/php-java/shape-effective-properties/): API गणना किए गए मान लौटाता है जो थीम शैली, लेआउट और स्थानीय सेटिंग्स को ध्यान में रखता है, जिससे स्वरूपण विश्लेषण सरल हो जाता है।