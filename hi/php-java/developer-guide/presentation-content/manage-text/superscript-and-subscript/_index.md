---
title: PHP का उपयोग करके प्रस्तुतियों में सुपरसक्रिप्ट और सबसक्रिप्ट प्रबंधित करें
linktitle: सुपरसक्रिप्ट और सबसक्रिप्ट
type: docs
weight: 80
url: /hi/php-java/superscript-and-subscript/
keywords:
- सुपरसक्रिप्ट
- सबसक्रिप्ट
- सुपरसक्रिप्ट जोड़ें
- सबसक्रिप्ट जोड़ें
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Java के माध्यम से PHP के लिए Aspose.Slides में सुपरसक्रिप्ट और सबसक्रिप्ट में महारत हासिल करें और पेशेवर टेक्स्ट फॉर्मेटिंग के साथ अपनी प्रस्तुतियों को अधिकतम प्रभाव के लिए उन्नत बनाएं।"
---
## **अवलोकन**

Aspose.Slides आपको अपने PowerPoint (PPT, PPTX) और OpenDocument (ODP) प्रस्तुतियों में सुपरसक्रिप्ट एवं सबसक्रिप्ट टेक्स्ट को एकीकृत करने की सुविधाएँ प्रदान करता है। चाहे आपको रासायनिक सूत्र, गणितीय समीकरण को उजागर करना हो, या फुटनोट के साथ सामग्री को वर्णित करना हो, ये विशेष फॉर्मेटिंग विकल्प स्पष्टता और शुद्धता बनाए रखने में मदद करते हैं। इस लेख में, आप सीखेंगे कि सुपरसक्रिप्ट और सबसक्रिप्ट शैलियों को सहजता से कैसे लागू करें और प्रत्येक स्लाइड में पेशेवर परिणाम सुनिश्चित करें।

## **सुपरसक्रिप्ट व सबसक्रिप्ट पाठ का प्रबंधन**
आप किसी भी पैराग्राफ भाग के भीतर सुपरसक्रिप्ट और सबसक्रिप्ट पाठ जोड़ सकते हैं। Aspose.Slides टेक्स्ट फ्रेम में सुपरसक्रिप्ट या सबसक्रिप्ट पाठ जोड़ने के लिए आपको [**setEscapement**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseportionformat/#setEscapement) मेथड का उपयोग करना होगा, जो [PortionFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/PortionFormat) क्लास का है।

यह प्रॉपर्टी सुपरसक्रिप्ट या सबसक्रिप्ट टेक्स्ट को रिटर्न या सेट करती है (मान -100% (सबस्क्रिप्ट) से 100% (सुपरसक्रिप्ट) तक)। उदाहरण के लिए:

- [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएं।
- उसके Index का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।
- स्लाइड में [Rectangle](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ShapeType#Rectangle) प्रकार की एक [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) जोड़ें।
- उस [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) से जुड़ा [TextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/) प्राप्त करें।
- मौजूद Paragraphs को साफ़ करें।
- सुपरसक्रिप्ट टेक्स्ट रखने के लिए एक नया पैराग्राफ ऑब्जेक्ट बनाएं और उसे [TextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/) के IParagraphs कलेक्शन में जोड़ें।
- एक नया Portion ऑब्जेक्ट बनाएं।
- Portion के लिए Escapement प्रॉपर्टी को 0 से 100 के बीच सेट करें (0 का अर्थ कोई सुपरसक्रिप्ट नहीं)।
- [Portion](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Portion) में कुछ टेक्स्ट सेट करें और फिर उसे पैराग्राफ की Portion कलेक्शन में जोड़ें।
- सबसक्रिप्ट टेक्स्ट रखने के लिए एक नया पैराग्राफ ऑब्जेक्ट बनाएं और उसे ITextFrame के IParagraphs कलेक्शन में जोड़ें।
- एक नया Portion ऑब्जेक्ट बनाएं।
- Portion के लिए Escapement प्रॉपर्टी को 0 से -100 के बीच सेट करें (0 का अर्थ कोई सबसक्रिप्ट नहीं)।
- [Portion](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Portion) में कुछ टेक्स्ट सेट करें और फिर उसे पैराग्राफ की Portion कलेक्शन में जोड़ें।
- प्रस्तुतीकरण को PPTX फ़ाइल के रूप में सहेजें।

ऊपर दिए गए चरणों का कार्यान्वयन नीचे दिया गया है।

```php
  # एक Presentation क्लास का इंस्टेंस बनाएं जो PPTX को दर्शाता है
  # स्लाइड प्राप्त करें
  # टेक्स्ट बॉक्स बनाएं
  $pres = new Presentation();
  try {
    # स्लाइड प्राप्त करें
    $slide = $pres->getSlides()->get_Item(0);
    # टेक्स्ट बॉक्स बनाएं
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();
    # सुपरसक्रिप्ट टेक्स्ट के लिए पैराग्राफ बनाएं
    $superPar = new Paragraph();
    # सामान्य टेक्स्ट के साथ Portion बनाएं
    $portion1 = new Portion();
    $portion1->setText("SlideTitle");
    $superPar->getPortions()->add($portion1);
    # सुपरसक्रिप्ट टेक्स्ट के साथ Portion बनाएं
    $superPortion = new Portion();
    $superPortion->getPortionFormat()->setEscapement(30);
    $superPortion->setText("TM");
    $superPar->getPortions()->add($superPortion);
    # सबस्क्रिप्ट टेक्स्ट के लिए पैराग्राफ बनाएं
    $paragraph2 = new Paragraph();
    # सामान्य टेक्स्ट के साथ Portion बनाएं
    $portion2 = new Portion();
    $portion2->setText("a");
    $paragraph2->getPortions()->add($portion2);
    # सबस्क्रिप्ट टेक्स्ट के साथ Portion बनाएं
    $subPortion = new Portion();
    $subPortion->getPortionFormat()->setEscapement(-25);
    $subPortion->setText("i");
    $paragraph2->getPortions()->add($subPortion);
    # पैराग्राफ को टेक्स्ट बॉक्स में जोड़ें
    $textFrame->getParagraphs()->add($superPar);
    $textFrame->getParagraphs()->add($paragraph2);
    $pres->save("formatText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या PDF या अन्य फ़ॉर्मेट में एक्सपोर्ट करने पर सुपरसक्रिप्ट और सबसक्रिप्ट संरक्षित रहते हैं?**

हाँ, Aspose.Slides प्रस्तुतियों को PDF, PPT/PPTX, इमेज और अन्य सपोर्टेड फ़ॉर्मेट में एक्सपोर्ट करने पर सुपरसक्रिप्ट और सबसक्रिप्ट फॉर्मेटिंग को सही तरीके से बनाए रखता है। विशेष फॉर्मेटिंग सभी आउटपुट फ़ाइलों में अपरिवर्तित रहती है।

**क्या सुपरसक्रिप्ट और सबसक्रिप्ट को बोल्ड या इटैलिक जैसे अन्य फॉर्मेटिंग स्टाइल्स के साथ मिलाया जा सकता है?**

हाँ, Aspose.Slides आपको एक ही Portion के भीतर विभिन्न टेक्स्ट स्टाइल्स को मिलाने की अनुमति देता है। आप बोल्ड, इटैलिक, अंडरलाइन को सक्षम कर सकते हैं और साथ ही [PortionFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/portionformat/) में संबंधित प्रॉपर्टीज़ को सेट करके सुपरसक्रिप्ट या सबसक्रिप्ट लागू कर सकते हैं।

**क्या सुपरसक्रिप्ट और सबसक्रिप्ट फ़ॉर्मेटिंग तालिकाओं, चार्ट्स या SmartArt के अंदर टेक्स्ट पर काम करती है?**

हाँ, Aspose.Slides अधिकांश ऑब्जेक्ट्स, जिसमें तालिकाएँ और चार्ट एलिमेंट्स शामिल हैं, के भीतर फ़ॉर्मेटिंग को सपोर्ट करता है। SmartArt के साथ काम करते समय आपको उपयुक्त एलिमेंट्स (जैसे [SmartArtNode](https://reference.aspose.com/slides/hi/php-java/aspose.slides/smartartnode/)) और उनके टेक्स्ट कंटेनर तक पहुँचनी होगी, और फिर समान तरीके से [PortionFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/portionformat/) प्रॉपर्टीज़ को कॉन्फ़िगर करना होगा।