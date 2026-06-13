---
title: Android पर प्रस्तुतियों में सुपरसक्रिप्ट और सबस्क्रिप्ट को प्रबंधित करें
linktitle: सुपरसक्रिप्ट और सबस्क्रिप्ट
type: docs
weight: 80
url: /hi/androidjava/superscript-and-subscript/
keywords:
- सुपरसक्रिप्ट
- सबस्क्रिप्ट
- सुपरसक्रिप्ट जोड़ें
- सबस्क्रिप्ट जोड़ें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Java के माध्यम से Android के लिये Aspose.Slides में सुपरसक्रिप्ट और सबस्क्रिप्ट में महारत हासिल करें और अपने प्रस्तुतियों को पेशेवर टेक्स्ट फ़ॉर्मेटिंग के साथ अधिकतम प्रभाव के लिए उन्नत बनाएं।"
---
## **सारांश**

Aspose.Slides आपके PowerPoint (PPT, PPTX) और OpenDocument (ODP) प्रस्तुतियों में सुपरसक्रिप्ट और सबस्क्रिप्ट टेक्स्ट को एकीकृत करने के लिए सुविधाएँ प्रदान करता है। चाहे आपको रासायनिक सूत्र, गणितीय समीकरण हाइलाइट करने हों, या फुटनोट के साथ सामग्री का उल्लेख करना हो, ये विशेष फ़ॉर्मेटिंग विकल्प स्पष्टता और सटीकता बनाए रखने में मदद करते हैं। इस लेख में, आप सीखेंगे कि कैसे सहजता से सुपरसक्रिप्ट और सबस्क्रिप्ट शैली लागू की जाए और प्रत्येक स्लाइड में पेशेवर परिणाम सुनिश्चित किया जाए।

## **सुपरसक्रिप्ट और सबस्क्रिप्ट टेक्स्ट का प्रबंधन**
आप किसी भी पैराग्राफ भाग के भीतर सुपरसक्रिप्ट और सबस्क्रिप्ट टेक्स्ट जोड़ सकते हैं। Aspose.Slides टेक्स्ट फ्रेम में सुपरसक्रिप्ट या सबस्क्रिप्ट टेक्स्ट जोड़ने के लिए आपको [**setEscapement**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IBasePortionFormat#setEscapement-float-) मेथड को [PortionFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/PortionFormat) क्लास का उपयोग करना होगा।

यह प्रॉपर्टी सुपरसक्रिप्ट या सबस्क्रिप्ट टेक्स्ट को लौटाती या सेट करती है (मान -100% (सबस्क्रिप्ट) से 100% (सुपरसक्रिप्ट) तक)। उदाहरण के लिए:

- एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का इंस्टैंस बनाएं।
- इंडेक्स का उपयोग करके स्लाइड के रेफ़रेंस प्राप्त करें।
- स्लाइड में [Rectangle](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ShapeType#Rectangle) प्रकार की एक [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IAutoShape) जोड़ें।
- [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IAutoShape) से जुड़ा [ITextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ITextFrame) एक्सेस करें।
- मौजूदा पैराग्राफ को साफ़ करें
- सुपरसक्रिप्ट टेक्स्ट रखने के लिए एक नया पैराग्राफ ऑब्जेक्ट बनाएं और इसे [ITextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ITextFrame) की [IParagraphs collection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ITextFrame#getParagraphs--) में जोड़ें।
- एक नया पोर्शन ऑब्जेक्ट बनाएं
- सुपरसक्रिप्ट जोड़ने के लिए पोर्शन की Escapement प्रॉपर्टी 0 से 100 के बीच सेट करें। (0 का मतलब कोई सुपरसक्रिप्ट नहीं)
- कुछ टेक्स्ट को [Portion](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Portion) में सेट करें और फिर उसे पैराग्राफ की पोर्शन कलेक्शन में जोड़ें।
- सबस्क्रिप्ट टेक्स्ट रखने के लिए एक नया पैराग्राफ ऑब्जेक्ट बनाएं और इसे ITextFrame की IParagraphs कलेक्शन में जोड़ें।
- एक नया पोर्शन ऑब्जेक्ट बनाएं
- सबस्क्रिप्ट जोड़ने के लिए पोर्शन की Escapement प्रॉपर्टी 0 से -100 के बीच सेट करें। (0 का मतलब कोई सबस्क्रिप्ट नहीं)
- कुछ टेक्स्ट को [Portion](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Portion) में सेट करें और फिर उसे पैराग्राफ की पोर्शन कलेक्शन में जोड़ें।
- प्रेज़ेंटेशन को PPTX फ़ाइल के रूप में सहेजें।

ऊपर बताए गए चरणों का कार्यान्वयन नीचे दिया गया है।

```java
// एक Presentation क्लास का इंस्टैंस बनाएं जो PPTX का प्रतिनिधित्व करती है
Presentation pres = new Presentation();
try {
    // स्लाइड प्राप्त करें
    ISlide slide = pres.getSlides().get_Item(0);

    // टेक्स्ट बॉक्स बनाएं
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    // सुपरसक्रिप्ट टेक्स्ट के लिए पैराग्राफ बनाएं
    IParagraph superPar = new Paragraph();

    // सामान्य टेक्स्ट के साथ पोर्शन बनाएं
    IPortion portion1 = new Portion();
    portion1.setText("SlideTitle");
    superPar.getPortions().add(portion1);

    // सुपरसक्रिप्ट टेक्स्ट के साथ पोर्शन बनाएं
    IPortion superPortion = new Portion();
    superPortion.getPortionFormat().setEscapement(30);
    superPortion.setText("TM");
    superPar.getPortions().add(superPortion);

    // सबस्क्रिप्ट टेक्स्ट के लिए पैराग्राफ बनाएं
    IParagraph paragraph2 = new Paragraph();

    // सामान्य टेक्स्ट के साथ पोर्शन बनाएं
    IPortion portion2 = new Portion();
    portion2.setText("a");
    paragraph2.getPortions().add(portion2);

    // सबस्क्रिप्ट टेक्स्ट के साथ पोर्शन बनाएं
    IPortion subPortion = new Portion();
    subPortion.getPortionFormat().setEscapement(-25);
    subPortion.setText("i");
    paragraph2.getPortions().add(subPortion);

    // पैराग्राफ को टेक्स्ट बॉक्स में जोड़ें
    textFrame.getParagraphs().add(superPar);
    textFrame.getParagraphs().add(paragraph2);

    pres.save("formatText.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या सुपरसक्रिप्ट और सबस्क्रिप्ट को PDF या अन्य फॉर्मैट्स में एक्सपोर्ट करने पर संरक्षित रखा जाएगा?**

हाँ, Aspose.Slides प्रेज़ेंटेशन को PDF, PPT/PPTX, इमेजेज़ और अन्य समर्थित फ़ॉर्मैट्स में एक्सपोर्ट करते समय सुपरसक्रिप्ट और सबस्क्रिप्ट फ़ॉर्मेटिंग को सही ढंग से बरकरार रखता है। यह विशेष फ़ॉर्मेटिंग सभी आउटपुट फ़ाइलों में अपरिवर्तित रहती है।

**क्या सुपरसक्रिप्ट और सबस्क्रिप्ट को बोल्ड या इटैलिक जैसे अन्य फ़ॉर्मेटिंग स्टाइल्स के साथ मिलाया जा सकता है?**

हाँ, Aspose.Slides आपको एक ही पोर्शन में विभिन्न टेक्स्ट स्टाइल्स को मिलाने की अनुमति देता है। आप बॉल्ड, इटैलिक, अंडरलाइन को सक्षम कर सकते हैं और साथ ही [PortionFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/portionformat/) में संबंधित प्रॉपर्टीज़ को कॉन्फ़िगर करके सुपरसक्रिप्ट या सबस्क्रिप्ट भी लागू कर सकते हैं।

**क्या सुपरसक्रिप्ट और सबस्क्रिप्ट फ़ॉर्मेटिंग टेबल्स, चार्ट्स या SmartArt के भीतर टेक्स्ट पर लागू होती है?**

हाँ, Aspose.Slides अधिकांश ऑब्जेक्ट्स, जैसे टेबल्स और चार्ट एलिमेंट्स, के भीतर फ़ॉर्मेटिंग को सपोर्ट करता है। SmartArt के साथ काम करते समय, आपको संबंधित एलिमेंट्स (जैसे [SmartArtNode](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/smartartnode/)) और उनके टेक्स्ट कंटेनर्स तक पहुँचने की आवश्यकता होगी, और फिर समान तरीके से [PortionFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/portionformat/) प्रॉपर्टीज़ को कॉन्फ़िगर करें।