---
title: जावा का उपयोग करके प्रस्तुतियों में सुपरस्क्रिप्ट और सबस्क्रिप्ट प्रबंधित करें
linktitle: सुपरस्क्रिप्ट और सबस्क्रिप्ट
type: docs
weight: 80
url: /hi/java/superscript-and-subscript/
keywords:
- सुपरस्क्रिप्ट
- सबस्क्रिप्ट
- सुपरस्क्रिप्ट जोड़ें
- सबस्क्रिप्ट जोड़ें
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- Java
- Aspose.Slides
description: "Aspose.Slides for Java में सुपरस्क्रिप्ट और सबस्क्रिप्ट का विशेषज्ञ बनें और पेशेवर टेक्स्ट फ़ॉर्मेटिंग के साथ अपने प्रस्तुतियों को अधिकतम प्रभाव के लिए उन्नत करें।"
---
## **अवलोकन**

Aspose.Slides आपके PowerPoint (PPT, PPTX) और OpenDocument (ODP) प्रस्तुतियों में superscript और subscript टेक्स्ट को एकीकृत करने की सुविधाएँ प्रदान करता है। चाहे आपको रासायनिक सूत्र, गणितीय समीकरणों को उजागर करने की आवश्यकता हो, या फुटनोट्स के साथ सामग्री को टिप्पणी करने की, ये विशेष फ़ॉर्मेटिंग विकल्प स्पष्टता और सटीकता बनाए रखने में मदद करते हैं। इस लेख में आप सीखेंगे कि superscript और subscript शैलियों को सहजता से कैसे लागू करें और प्रत्येक स्लाइड में पेशेवर परिणाम सुनिश्चित करें।

## **Super Script और Sub Script टेक्स्ट प्रबंधित करें**
आप किसी भी पैराग्राफ भाग के भीतर superscript और subscript टेक्स्ट जोड़ सकते हैं। Aspose.Slides टेक्स्ट फ्रेम में Superscript या Subscript टेक्स्ट जोड़ने के लिए आपको [**setEscapement**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IBasePortionFormat#setEscapement-float-) मेथड को [PortionFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/PortionFormat) क्लास से उपयोग करना होगा।

यह प्रॉपर्टी superscript या subscript टेक्स्ट को सेट या प्राप्त करती है (मान -100% (subscript) से 100% (superscript) तक)। उदाहरण के लिए:

- [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएँ।
- उसके Index का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।
- स्लाइड में [Rectangle](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ShapeType#Rectangle) प्रकार का एक [IAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IAutoShape) जोड़ें।
- [IAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IAutoShape) से जुड़ा हुआ [ITextFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ITextFrame) एक्सेस करें।
- मौजूदा Paragraphs को साफ़ करें।
- superscript टेक्स्ट रखने के लिए एक नया पैराग्राफ ऑब्जेक्ट बनाएँ और उसे [IParagraphs collection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ITextFrame#getParagraphs--) में जोड़ें।
- एक नया portion ऑब्जेक्ट बनाएं।
- superscript जोड़ने के लिए portion की Escapement प्रॉपर्टी को 0 से 100 के बीच सेट करें। (0 का अर्थ कोई superscript नहीं)
- [Portion](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Portion) के लिए कुछ टेक्स्ट सेट करें और फिर उसे पैराग्राफ की portion कलेक्शन में जोड़ें।
- subscript टेक्स्ट रखने के लिए एक नया पैराग्राफ ऑब्जेक्ट बनाकर उसे ITextFrame की IParagraphs कलेक्शन में जोड़ें।
- एक नया portion ऑब्जेक्ट बनाएं।
- subscript जोड़ने के लिए portion की Escapement प्रॉपर्टी को 0 से -100 के बीच सेट करें। (0 का अर्थ कोई subscript नहीं)
- [Portion](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Portion) के लिए कुछ टेक्स्ट सेट करें और फिर उसे पैराग्राफ की portion कलेक्शन में जोड़ें।
- प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

उपरोक्त चरणों का कार्यान्वयन नीचे दिया गया है।

```java
// एक Presentation क्लास का उदाहरण बनाएं जो PPTX का प्रतिनिधित्व करता है
Presentation pres = new Presentation();
try {
    // स्लाइड प्राप्त करें
    ISlide slide = pres.getSlides().get_Item(0);

    // टेक्स्ट बॉक्स बनाएं
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    // सुपरस्क्रिप्ट टेक्स्ट के लिए पैराग्राफ बनाएं
    IParagraph superPar = new Paragraph();

    // सामान्य टेक्स्ट के साथ एक पोर्शन बनाएं
    IPortion portion1 = new Portion();
    portion1.setText("SlideTitle");
    superPar.getPortions().add(portion1);

    // सुपरस्क्रिप्ट टेक्स्ट के साथ एक पोर्शन बनाएं
    IPortion superPortion = new Portion();
    superPortion.getPortionFormat().setEscapement(30);
    superPortion.setText("TM");
    superPar.getPortions().add(superPortion);

    // सबस्क्रिप्ट टेक्स्ट के लिए पैराग्राफ बनाएं
    IParagraph paragraph2 = new Paragraph();

    // सामान्य टेक्स्ट के साथ एक पोर्शन बनाएं
    IPortion portion2 = new Portion();
    portion2.setText("a");
    paragraph2.getPortions().add(portion2);

    // सबस्क्रिप्ट टेक्स्ट के साथ एक पोर्शन बनाएं
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

**क्या superscript और subscript को PDF या अन्य फ़ॉर्मेट्स में निर्यात करते समय संरक्षित किया जाता है?**

हाँ, Aspose.Slides प्रस्तुतियों को PDF, PPT/PPTX, इमेज़ और अन्य समर्थित फ़ॉर्मेट्स में निर्यात करते समय superscript और subscript फ़ॉर्मेटिंग को सही ढंग से बनाए रखता है। विशेष फ़ॉर्मेटिंग सभी आउटपुट फ़ाइलों में अपरिवर्तित रहती है।

**क्या superscript और subscript को बोल्ड या इटैलिक जैसे अन्य फ़ॉर्मेटिंग शैलियों के साथ मिलाया जा सकता है?**

हाँ, Aspose.Slides आपको एक ही portion के भीतर विभिन्न टेक्स्ट शैलियों को मिलाने की अनुमति देता है। आप [PortionFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/portionformat/) की संबंधित प्रॉपर्टी सेट करके बोल्ड, इटैलिक, अंडरलाइन और 동시에 superscript या subscript लागू कर सकते हैं।

**क्या superscript और subscript फ़ॉर्मेटिंग तालिकाओं, चार्ट्स या SmartArt के अंदर टेक्स्ट के लिए काम करती है?**

हाँ, Aspose.Slides अधिकांश ऑब्जेक्ट्स, जिसमें तालिकाएँ और चार्ट तत्व शामिल हैं, के भीतर फ़ॉर्मेटिंग को समर्थन देता है। SmartArt के साथ काम करते समय आपको उपयुक्त तत्वों (जैसे [SmartArtNode](https://reference.aspose.com/slides/hi/java/com.aspose.slides/smartartnode/)) और उनके टेक्स्ट कंटेनरों तक पहुंचना होगा, और फिर [PortionFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/portionformat/) प्रॉपर्टी को समान तरीके से कॉन्फ़िगर करना होगा।