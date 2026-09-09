---
title: Python के माध्यम से Java का उपयोग करके प्रस्तुतियों में सुपर्सक्रिप्ट और सबस्क्रिप्ट प्रबंधन
linktitle: सुपर्सक्रिप्ट और सबस्क्रिप्ट
type: docs
weight: 80
url: /hi/python-java/superscript-and-subscript/
keywords:
- सुपर्सक्रिप्ट
- सबस्क्रिप्ट
- सुपर्सक्रिप्ट जोड़ें
- सबस्क्रिप्ट जोड़ें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Python के लिए Java के माध्यम से Aspose.Slides में सुपर्सक्रिप्ट और सबस्क्रिप्ट को मास्टर करें और अधिकतम प्रभाव के लिए पेशेवर टेक्स्ट फ़ॉर्मेटिंग के साथ अपनी प्रस्तुतियों को उन्नत बनाएं।"
---
## **अवलोकन**

Aspose.Slides आपके PowerPoint (PPT, PPTX) और OpenDocument (ODP) प्रस्तुतियों में सुपर्सक्रिप्ट और सबस्क्रिप्ट टेक्स्ट को एकीकृत करने के लिए सुविधाएँ प्रदान करता है। चाहे आपको रासायनिक सूत्र, गणितीय समीकरण को हाईलाइट करना हो या फुटनोट के साथ सामग्री में टिप्पणी करनी हो, ये विशिष्ट फ़ॉर्मेटिंग विकल्प स्पष्टता और सटीकता बनाए रखने में मदद करते हैं। इस लेख में, आप सीखेंगे कि कैसे सुपर्सक्रिप्ट और सबस्क्रिप्ट शैलियों को सुगमता से लागू करें और प्रत्येक स्लाइड में पेशेवर परिणाम सुनिश्चित करें।

## **सुपर्सक्रिप्ट और सबस्क्रिप्ट टेक्स्ट प्रबंधन**

आप पैराग्राफ के किसी भी हिस्से में सुपर्सक्रिप्ट और सबस्क्रिप्ट टेक्स्ट जोड़ सकते हैं। Aspose.Slides टेक्स्ट फ़्रेम में इस फ़ॉर्मेटिंग को लागू करने के लिए, [PortionFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/portionformat/) क्लास की [setEscapement](https://reference.aspose.com/slides/hi/python-java/aspose.slides/portionformat/#setEscapement) मेथड का उपयोग करें।

escapement मान -100% (सबस्क्रिप्ट) से 100% (सुपर्सक्रिप्ट) तक हो सकता है। उदाहरण के तौर पर:

- [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का एक इंस्टैंस बनाएं।
- उसके इंडेक्स से एक स्लाइड प्राप्त करें।
- स्लाइड में [ShapeType.Rectangle](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapetype/#Rectangle) प्रकार का एक [AutoShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/autoshape/) जोड़ें।
- [AutoShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/autoshape/) से जुड़ा [TextFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframe/) एक्सेस करें।
- मौजूदा पैराग्राफ़ साफ़ करें।
- सुपर्सक्रिप्ट टेक्स्ट रखने के लिए एक पैराग्राफ बनाएं और उसे टेक्स्ट फ़्रेम की [paragraph collection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframe/#getParagraphs) में जोड़ें।
- एक portion बनाएं।
- सुपर्सक्रिप्ट के लिए 0 से 100 के बीच का मान सेट करने हेतु [setEscapement](https://reference.aspose.com/slides/hi/python-java/aspose.slides/portionformat/#setEscapement) का प्रयोग करें (0 का अर्थ कोई सुपर्सक्रिप्ट नहीं)।
- [Portion](https://reference.aspose.com/slides/hi/python-java/aspose.slides/portion/) का टेक्स्ट सेट करें और उसे पैराग्राफ की portion collection में जोड़ें।
- सबस्क्रिप्ट टेक्स्ट रखने के लिए एक पैराग्राफ बनाएं और उसे टेक्स्ट फ़्रेम की [paragraph collection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframe/#getParagraphs) में जोड़ें।
- एक portion बनाएं।
- सबस्क्रिप्ट के लिए -100 से 0 के बीच का मान सेट करने हेतु [setEscapement](https://reference.aspose.com/slides/hi/python-java/aspose.slides/portionformat/#setEscapement) का प्रयोग करें (0 का अर्थ कोई सबस्क्रिप्ट नहीं)।
- [Portion](https://reference.aspose.com/slides/hi/python-java/aspose.slides/portion/) का टेक्स्ट सेट करें और उसे पैराग्राफ की portion collection में जोड़ें।
- प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

निम्न उदाहरण इन चरणों को लागू करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Paragraph, Portion, Presentation, SaveFormat, ShapeType

    # एक प्रस्तुति बनाएं।
    presentation = Presentation()
    try:
        # स्लाइड प्राप्त करें।
        slide = presentation.getSlides().get_Item(0)

        # एक टेक्स्ट बॉक्स बनाएं।
        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)
        text_frame = shape.getTextFrame()
        text_frame.getParagraphs().clear()

        # सुपर्सक्रिप्ट टेक्स्ट के लिए एक पैराग्राफ बनाएं।
        superscript_paragraph = Paragraph()

        # सामान्य टेक्स्ट के साथ एक हिस्सा बनाएं।
        title_portion = Portion()
        title_portion.setText("SlideTitle")
        superscript_paragraph.getPortions().add(title_portion)

        # सुपर्सक्रिप्ट टेक्स्ट के साथ एक हिस्सा बनाएं।
        superscript_portion = Portion()
        superscript_portion.getPortionFormat().setEscapement(30)
        superscript_portion.setText("TM")
        superscript_paragraph.getPortions().add(superscript_portion)

        # सबस्क्रिप्ट टेक्स्ट के लिए एक पैराग्राफ बनाएं।
        subscript_paragraph = Paragraph()

        # सामान्य टेक्स्ट के साथ एक हिस्सा बनाएं।
        base_portion = Portion()
        base_portion.setText("a")
        subscript_paragraph.getPortions().add(base_portion)

        # सबस्क्रिप्ट टेक्स्ट के साथ एक हिस्सा बनाएं।
        subscript_portion = Portion()
        subscript_portion.getPortionFormat().setEscapement(-25)
        subscript_portion.setText("i")
        subscript_paragraph.getPortions().add(subscript_portion)

        # पैराग्राफ़ को टेक्स्ट बॉक्स में जोड़ें।
        text_frame.getParagraphs().add(superscript_paragraph)
        text_frame.getParagraphs().add(subscript_paragraph)

        presentation.save("formatText.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या PDF या अन्य फ़ॉर्मेट्स में एक्सपोर्ट करने पर सुपर्सक्रिप्ट और सबस्क्रिप्ट संरक्षित रहते हैं?**

हाँ, Aspose.Slides प्रस्तुतियों को PDF, PPT/PPTX, इमेजेज़ और अन्य समर्थित फ़ॉर्मेट्स में एक्सपोर्ट करते समय सुपर्सक्रिप्ट और सबस्क्रिप्ट फ़ॉर्मेटिंग को सही ढंग से बरकरार रखता है। विशेष फ़ॉर्मेटिंग सभी आउटपुट फ़ाइलों में अपरिवर्तित रहती है।

**क्या सुपर्सक्रिप्ट और सबस्क्रिप्ट को बोल्ड या इटैलिक जैसी अन्य फ़ॉर्मेटिंग शैलियों के साथ जोड़ा जा सकता है?**

हाँ, Aspose.Slides आपको एक ही टेक्स्ट portion में विभिन्न शैलियों को मिलाने की अनुमति देता है। आप [PortionFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/portionformat/) में संबंधित गुणों को कॉन्फ़िगर करके बोल्ड, इटैलिक, अंडरलाइन और साथ ही सुपर्सक्रिप्ट या सबस्क्रिप्ट को सक्षम कर सकते हैं।

**क्या टेबल, चार्ट या SmartArt के भीतर मौजूद टेक्स्ट के लिए भी सुपर्सक्रिप्ट और सबस्क्रिप्ट फ़ॉर्मेटिंग काम करती है?**

हाँ, Aspose.Slides अधिकांश ऑब्जेक्ट्स, जैसे टेबल और चार्ट एलिमेंट्स, के भीतर फ़ॉर्मेटिंग को सपोर्ट करता है। SmartArt के साथ काम करते समय, आपको उपयुक्त एलिमेंट्स (जैसे [SmartArtNode](https://reference.aspose.com/slides/hi/python-java/aspose.slides/smartartnode/)) और उनके टेक्स्ट कंटेनर्स तक पहुंचना होगा, फिर समान तरीके से [PortionFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/portionformat/) गुणों को कॉन्फ़िगर करें।