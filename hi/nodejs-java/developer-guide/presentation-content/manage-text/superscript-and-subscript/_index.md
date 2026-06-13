---
title: जावास्क्रिप्ट का उपयोग करके प्रस्तुतियों में सुपरस्क्रिप्ट और सबस्क्रिप्ट प्रबंधित करें
linktitle: सुपरस्क्रिप्ट और सबस्क्रिप्ट
type: docs
weight: 80
url: /hi/nodejs-java/superscript-and-subscript/
keywords:
- सुपरस्क्रिप्ट
- सबस्क्रिप्ट
- सुपरस्क्रिप्ट जोड़ें
- सबस्क्रिप्ट जोड़ें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js में Java के माध्यम से सुपरस्क्रिप्ट और सबस्क्रिप्ट में महारत हासिल करें और अपने प्रस्तुतियों को पेशेवर टेक्स्ट फ़ॉर्मेटिंग के साथ अधिकतम प्रभाव के लिए ऊँचा उठाएँ।"
---
## **अवलोकन**

Aspose.Slides आपके PowerPoint (PPT, PPTX) और OpenDocument (ODP) प्रस्तुतियों में सुपरस्क्रिप्ट और सबस्क्रिप्ट टेक्स्ट को सम्मिलित करने के लिए सुविधाएँ प्रदान करता है। चाहे आपको रासायनिक सूत्रों, गणितीय समीकरणों को उजागर करना हो, या फुटनोट के साथ सामग्री का उल्लेख करना हो, ये विशेष फ़ॉर्मेटिंग विकल्प स्पष्टता और सटीकता बनाए रखने में मदद करते हैं। इस लेख में, आप सीखेंगे कि कैसे सुपरस्क्रिप्ट और सबस्क्रिप्ट शैलियों को सहजता से लागू करें और प्रत्येक स्लाइड में प्रोफ़ेशनल परिणाम सुनिश्चित करें।

## **सुपरस्क्रिप्ट और सबस्क्रिप्ट टेक्स्ट को प्रबंधित करें**

आप किसी भी पैराग्राफ हिस्से के अंदर सुपरस्क्रिप्ट और सबस्क्रिप्ट टेक्स्ट जोड़ सकते हैं। Aspose.Slides के टेक्स्ट फ्रेम में सुपरस्क्रिप्ट या सबस्क्रिप्ट टेक्स्ट जोड़ने के लिए आपको [**setEscapement**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/BasePortionFormat#setEscapement-float-) मेथड का उपयोग करना होगा, जो कि [PortionFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/PortionFormat) क्लास का हिस्सा है।

यह प्रॉपर्टी सुपरस्क्रिप्ट या सबस्क्रिप्ट टेक्स्ट को प्राप्त या सेट करती है (मान -100% (सबस्क्रिप्ट) से 100% (सुपरस्क्रिप्ट) तक)। उदाहरण के लिए:

- एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास का इंस्टेंस बनाएं।
- उसके Index का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।
- स्लाइड में [Rectangle](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ShapeType#Rectangle) प्रकार का एक [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/AutoShape) जोड़ें।
- [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/AutoShape) से जुड़ा हुआ [TextFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/TextFrame) एक्सेस करें।
- मौजूदा पैराग्राफ़ साफ़ करें
- सुपरस्क्रिप्ट टेक्स्ट रखने के लिए एक नया पैराग्राफ ऑब्जेक्ट बनाएं और उसे [TextFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/TextFrame) के [Paragraphs collection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/TextFrame#getParagraphs--) में जोड़ें।
- एक नया Portion ऑब्जेक्ट बनाएं
- सुपरस्क्रिप्ट जोड़ने के लिए Portion की Escapement प्रॉपर्टी को 0 से 100 के बीच सेट करें। (0 का अर्थ कोई सुपरस्क्रिप्ट नहीं)
- [Portion](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Portion) के लिए कुछ टेक्स्ट सेट करें और फिर उसे पैराग्राफ की Portion कलेक्शन में जोड़ें।
- सबस्क्रिप्ट टेक्स्ट रखने के लिए एक नया पैराग्राफ ऑब्जेक्ट बनाएं और उसे ITextFrame के IParagraphs कलेक्शन में जोड़ें।
- एक नया Portion ऑब्जेक्ट बनाएं
- सबस्क्रिप्ट जोड़ने के लिए Portion की Escapement प्रॉपर्टी को 0 से -100 के बीच सेट करें। (0 का अर्थ कोई सबस्क्रिप्ट नहीं)
- [Portion](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Portion) के लिए कुछ टेक्स्ट सेट करें और फिर उसे पैराग्राफ की Portion कलेक्शन में जोड़ें।
- प्रेजेंटेशन को PPTX फ़ाइल के रूप में सहेजें।

उपर्युक्त कदमों का कार्यान्वयन नीचे दिया गया है।

```javascript
// एक Presentation क्लास का इंस्टैंस बनाएं जो PPTX को दर्शाती है
var pres = new aspose.slides.Presentation();
try {
    // स्लाइड प्राप्त करें
    var slide = pres.getSlides().get_Item(0);
    // टेक्स्ट बॉक्स बनाएं
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 200, 100);
    var textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();
    // सुपरस्क्रिप्ट टेक्स्ट के लिए पैराग्राफ बनाएं
    var superPar = new aspose.slides.Paragraph();
    // सामान्य टेक्स्ट के साथ एक Portion बनाएं
    var portion1 = new aspose.slides.Portion();
    portion1.setText("SlideTitle");
    superPar.getPortions().add(portion1);
    // सुपरस्क्रिप्ट टेक्स्ट के साथ एक Portion बनाएं
    var superPortion = new aspose.slides.Portion();
    superPortion.getPortionFormat().setEscapement(30);
    superPortion.setText("TM");
    superPar.getPortions().add(superPortion);
    // सबस्क्रिप्ट टेक्स्ट के लिए पैराग्राफ बनाएं
    var paragraph2 = new aspose.slides.Paragraph();
    // सामान्य टेक्स्ट के साथ एक Portion बनाएं
    var portion2 = new aspose.slides.Portion();
    portion2.setText("a");
    paragraph2.getPortions().add(portion2);
    // सबस्क्रिप्ट टेक्स्ट के साथ एक Portion बनाएं
    var subPortion = new aspose.slides.Portion();
    subPortion.getPortionFormat().setEscapement(-25);
    subPortion.setText("i");
    paragraph2.getPortions().add(subPortion);
    // टेक्स्ट बॉक्स में पैराग्राफ जोड़ें
    textFrame.getParagraphs().add(superPar);
    textFrame.getParagraphs().add(paragraph2);
    pres.save("formatText.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**Will superscript and subscript be preserved when exporting to PDF or other formats?**

हाँ, Aspose.Slides प्रेजेंटेशन को PDF, PPT/PPTX, इमेजेज और अन्य समर्थित फ़ॉर्मेट में निर्यात करते समय सुपरस्क्रिप्ट और सबस्क्रिप्ट फ़ॉर्मेटिंग को सही ढंग से बनाए रखता है। विशेष फ़ॉर्मेटिंग सभी आउटपुट फ़ाइलों में अपरिवर्तित रहती है।

**Can superscript and subscript be combined with other formatting styles such as bold or italics?**

हाँ, Aspose.Slides आपको एक ही Portion में विभिन्न टेक्स्ट स्टाइल को मिलाने की अनुमति देता है। आप बोल्ड, इटैलिक, अंडरलाइन को सक्रिय कर सकते हैं, और साथ ही PortionFormat की संबंधित प्रॉपर्टीज़ को सेट करके सुपरस्क्रिप्ट या सबस्क्रिप्ट को भी समानांतर लागू कर सकते हैं।

**Do superscript and subscript formatting work for text inside tables, charts, or SmartArt?**

हाँ, Aspose.Slides अधिकांश ऑब्जेक्ट्स, जिसमें टेबल और चार्ट एलिमेंट्स शामिल हैं, के भीतर फ़ॉर्मेटिंग का समर्थन करता है। SmartArt के साथ काम करते समय, आपको संबंधित तत्वों (जैसे [SmartArtNode](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/smartartnode/)) और उनके टेक्स्ट कंटेनर्स तक पहुंचना होगा, और फिर [PortionFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/portionformat/) प्रॉपर्टीज़ को इसी प्रकार कॉन्फ़िगर करना होगा।