---
title: PHP का उपयोग करके प्रस्तुतियों में फ़ॉन्ट प्रबंधित करें
linktitle: फ़ॉन्ट प्रबंधित करें
type: docs
weight: 10
url: /hi/php-java/manage-fonts/
keywords:
- फ़ॉन्ट प्रबंधित करें
- फ़ॉन्ट गुण
- पैराग्राफ
- टेक्स्ट फ़ॉर्मेटिंग
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- PHP
- Aspose.Slides
description: "Aspose.Slides के साथ PHP में फ़ॉन्ट नियंत्रित करें: कस्टम फ़ॉन्ट एम्बेड, प्रतिस्थापित और लोड करें ताकि PPT, PPTX और ODP प्रस्तुतियाँ स्पष्ट, ब्रांड-सेफ़ और सुसंगत रहें।"
---
## **फ़ॉन्ट संबंधित गुण प्रबंधित करें**
{{% alert color="primary" %}} 
प्रेजेंटेशन आमतौर पर टेक्स्ट और इमेज दोनों होते हैं। टेक्स्ट को विभिन्न तरीकों से फॉर्मेट किया जा सकता है, चाहे वह विशिष्ट अनुभागों और शब्दों को हाइलाइट करने के लिए हो या कॉर्पोरेट स्टाइल के अनुरूप बनाने के लिए। टेक्स्ट फ़ॉर्मेटिंग उपयोगकर्ताओं को प्रेजेंटेशन सामग्री की दिखावट और भाव को बदलने में मदद करती है। यह लेख दिखाता है कि Aspose.Slides for PHP via Java का उपयोग करके स्लाइड में टेक्स्ट पैराग्राफ की फ़ॉन्ट प्रॉपर्टीज़ को कैसे कॉन्फ़िगर करें।
{{% /alert %}} 

फ़ॉन्ट गुणों को प्रबंधित करने के लिए Aspose.Slides for PHP via Java का उपयोग करके:

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएँ।
1. इंडेक्स का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में [Placeholder](https://reference.aspose.com/slides/hi/php-java/aspose.slides/placeholder/) शेप्स को एक्सेस करें और उन्हें [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) में टाइपकास्ट करें।
1. [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) द्वारा एक्सपोज़ किए गए [TextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/) से [Paragraph](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraph/) प्राप्त करें।
1. पैराग्राफ को जस्टिफ़ाइ करें।
1. [Paragraph](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraph/) के टेक्स्ट [Portion](https://reference.aspose.com/slides/hi/php-java/aspose.slides/portion/) को एक्सेस करें।
1. [FontData](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fontdata/) का उपयोग करके फ़ॉन्ट परिभाषित करें और टेक्स्ट [Portion](https://reference.aspose.com/slides/hi/php-java/aspose.slides/portion/) की **Font** को उसी अनुसार सेट करें।
   1. फ़ॉन्ट को बोल्ड सेट करें।
   1. फ़ॉन्ट को इटैलिक सेट करें।
1. [Portion](https://reference.aspose.com/slides/hi/php-java/aspose.slides/portion/) ऑब्जेक्ट द्वारा एक्सपोज़ किए गए [FillFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fillformat/) का उपयोग करके फ़ॉन्ट रंग सेट करें।
1. संशोधित प्रेजेंटेशन को PPTX फ़ाइल के रूप में सेव करें।

ऊपर दिए गए चरणों का कार्यान्वयन नीचे दिया गया है। यह एक साधारण प्रेजेंटेशन लेता है और स्लाइड में फ़ॉन्ट को फॉर्मेट करता है। नीचे दर्शाए गए स्क्रीनशॉट इनपुट फ़ाइल और कोड स्निपेट द्वारा किए गए बदलावों को दिखाते हैं। कोड फ़ॉन्ट, रंग और फ़ॉन्ट शैली को बदलता है।

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**चित्र: इनपुट फ़ाइल में टेक्स्ट**|

|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**चित्र: अपडेटेड फ़ॉर्मैटिंग के साथ वही टेक्स्ट**|

```php
  # एक Presentation ऑब्जेक्ट बनाएँ जो PPTX फ़ाइल का प्रतिनिधित्व करता है
  $pres = new Presentation("FontProperties.pptx");
  try {
    # स्लाइड की स्थिति का उपयोग करके स्लाइड एक्सेस करना
    $slide = $pres->getSlides()->get_Item(0);
    # स्लाइड में पहले और दूसरे प्लेसहोल्डर को एक्सेस करना और उन्हें AutoShape में टाइपकास्ट करना
    $tf1 = $slide->getShapes()->get_Item(0)->getTextFrame();
    $tf2 = $slide->getShapes()->get_Item(1)->getTextFrame();
    # पहला पैराग्राफ एक्सेस करना
    $para1 = $tf1->getParagraphs()->get_Item(0);
    $para2 = $tf2->getParagraphs()->get_Item(0);
    # पैराग्राफ को जस्टिफ़ाइ करें
    $para2->getParagraphFormat()->setAlignment(TextAlignment->JustifyLow);
    # पहला भाग (portion) एक्सेस करना
    $port1 = $para1->getPortions()->get_Item(0);
    $port2 = $para2->getPortions()->get_Item(0);
    # नए फ़ॉन्ट परिभाषित करें
    $fd1 = new FontData("Elephant");
    $fd2 = new FontData("Castellar");
    # नए फ़ॉन्ट को भाग (portion) को असाइन करें
    $port1->getPortionFormat()->setLatinFont($fd1);
    $port2->getPortionFormat()->setLatinFont($fd2);
    # फ़ॉन्ट को बोल्ड सेट करें
    $port1->getPortionFormat()->setFontBold(NullableBool::True);
    $port2->getPortionFormat()->setFontBold(NullableBool::True);
    # फ़ॉन्ट को इटैलिक सेट करें
    $port1->getPortionFormat()->setFontItalic(NullableBool::True);
    $port2->getPortionFormat()->setFontItalic(NullableBool::True);
    # फ़ॉन्ट का रंग सेट करें
    $port1->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port1->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $port2->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port2->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    # PPTX को डिस्क पर सहेजें
    $pres->save("WelcomeFont.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **टेक्स्ट फ़ॉन्ट प्रॉपर्टीज़ सेट करें**
{{% alert color="primary" %}} 
**Managing Font Related Properties** में वर्णित अनुसार, एक [Portion](https://reference.aspose.com/slides/hi/php-java/aspose.slides/portion/) का उपयोग पैराग्राफ में समान फ़ॉर्मेटिंग स्टाइल वाले टेक्स्ट को रखने के लिए किया जाता है। यह लेख दिखाता है कि Aspose.Slides for PHP via Java का उपयोग करके कैसे एक टेक्स्टबॉक्स बनाएं जिसमें कुछ टेक्स्ट हो और फिर किसी विशिष्ट फ़ॉन्ट तथा फ़ॉन्ट फ़ैमिली श्रेणी की विभिन्न अन्य प्रॉपर्टीज़ को परिभाषित करें।
{{% /alert %}} 

टेक्स्टबॉक्स बनाने और उसके टेक्स्ट की फ़ॉन्ट प्रॉपर्टीज़ सेट करने के लिए:

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएँ।
1. इंडेक्स का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में **Rectangle** प्रकार का एक [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) जोड़ें।
1. [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) से जुड़ी fill स्टाइल हटाएँ।
1. [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) के [TextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/) को एक्सेस करें।
1. [TextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/) में कुछ टेक्स्ट जोड़ें।
1. [TextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/) से जुड़े [Portion](https://reference.aspose.com/slides/hi/php-java/aspose.slides/portion/) ऑब्जेक्ट को एक्सेस करें।
1. [Portion](https://reference.aspose.com/slides/hi/php-java/aspose.slides/portion/) के लिए उपयोग किया जाने वाला फ़ॉन्ट परिभाषित करें।
1. बोल्ड, इटैलिक, अंडरलाइन, रंग और हाइट जैसी अन्य फ़ॉन्ट प्रॉपर्टीज़ को [Portion](https://reference.aspose.com/slides/hi/php-java/aspose.slides/portion/) ऑब्जेक्ट द्वारा एक्सपोज़ किए गए संबंधित प्रॉपर्टीज़ का उपयोग करके सेट करें।
1. संशोधित प्रेजेंटेशन को PPTX फ़ाइल के रूप में लिखें।

ऊपर दिए गए चरणों का कार्यान्वयन नीचे दिया गया है।

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**चित्र: Aspose.Slides for PHP via Java द्वारा सेट किए गए कुछ फ़ॉन्ट प्रॉपर्टीज़ वाला टेक्स्ट**|

```php
  # एक Presentation ऑब्जेक्ट बनाएं जो PPTX फ़ाइल का प्रतिनिधित्व करता है
  $pres = new Presentation();
  try {
    # पहली स्लाइड प्राप्त करें
    $sld = $pres->getSlides()->get_Item(0);
    # Rectangle प्रकार का AutoShape जोड़ें
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 50);
    # AutoShape से जुड़ी सभी फ़िल स्टाइल हटाएँ
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # AutoShape से जुड़ा TextFrame एक्सेस करें
    $tf = $ashp->getTextFrame();
    $tf->setText("Aspose TextBox");
    # TextFrame से जुड़ा Portion एक्सेस करें
    $port = $tf->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    # Portion के लिए फ़ॉन्ट सेट करें
    $port->getPortionFormat()->setLatinFont(new FontData("Times New Roman"));
    # फ़ॉन्ट की बोल्ड प्रॉपर्टी सेट करें
    $port->getPortionFormat()->setFontBold(NullableBool::True);
    # फ़ॉन्ट की इटैलिक प्रॉपर्टी सेट करें
    $port->getPortionFormat()->setFontItalic(NullableBool::True);
    # फ़ॉन्ट की अंडरलाइन प्रॉपर्टी सेट करें
    $port->getPortionFormat()->setFontUnderline(TextUnderlineType::Single);
    # फ़ॉन्ट की ऊँचाई सेट करें
    $port->getPortionFormat()->setFontHeight(25);
    # फ़ॉन्ट का रंग सेट करें
    $port->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    # प्रेजेंटेशन को डिस्क पर सहेजें
    $pres->save("pptxFont.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```