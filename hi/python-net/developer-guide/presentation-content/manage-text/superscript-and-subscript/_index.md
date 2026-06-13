---
title: Python में सुपरस्क्रिप्ट और सबस्क्रिप्ट प्रबंधित करें
linktitle: सुपरस्क्रिप्ट और सबस्क्रिप्ट
type: docs
weight: 80
url: /hi/python-net/superscript-and-subscript/
keywords:
- सुपरस्क्रिप्ट
- सबस्क्रिप्ट
- सुपरस्क्रिप्ट जोड़ें
- सबस्क्रिप्ट जोड़ें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET में सुपरस्क्रिप्ट और सबस्क्रिप्ट को महारत हासिल करें और अधिकतम प्रभाव के लिए पेशेवर टेक्स्ट फ़ॉर्मेटिंग के साथ अपनी प्रस्तुतियों को ऊँचा उठाएँ।"
---
## **अवलोकन**

Aspose.Slides आपके PowerPoint (PPT, PPTX) और OpenDocument (ODP) प्रस्तुतियों में सुपरस्क्रिप्ट और सबस्क्रिप्ट टेक्स्ट को एकीकृत करने की सुविधाएँ प्रदान करता है। चाहे आपको रासायनिक सूत्र, गणितीय समीकरण को उजागर करना हो या फुटनोट के साथ सामग्री का annotation करना हो, ये विशेष फ़ॉर्मेटिंग विकल्प स्पष्टता और सटीकता बनाए रखने में मदद करते हैं। इस लेख में आप सीखेंगे कि सुपरस्क्रिप्ट और सबस्क्रिप्ट स्टाइल को सहजता से कैसे लागू किया जाए और प्रत्येक स्लाइड में पेशेवर परिणाम सुनिश्चित किया जाए।

## **Superscript और Subscript टेक्स्ट जोड़ें**

आप किसी भी पैराग्राफ भाग में सुपरस्क्रिप्ट या सबस्क्रिप्ट टेक्स्ट जोड़ सकते हैं। Aspose.Slides में, इसको नियंत्रित करने के लिए आप [PortionFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides/portionformat/) क्लास की `escapement` प्रॉपर्टी का उपयोग करते हैं।

`escapement` **-100% से 100%** तक का प्रतिशत है:

- **> 0** → सुपरस्क्रिप्ट (उदाहरण: 25% = हल्का उठाव; 100% = पूर्ण सुपरस्क्रिप्ट)
- **0** → बेसलाइन (कोई सुपर/सबस्क्रिप्ट नहीं)
- **< 0** → सबस्क्रिप्ट (उदाहरण: -25% = हल्का नीचे; -100% = पूर्ण सबस्क्रिप्ट)

Steps:

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) बनाएं और स्लाइड प्राप्त करें।
1. एक आयताकार [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) जोड़ें और उसके [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) तक पहुंचें।
1. मौजूदा पैराग्राफ साफ़ करें।
1. सुपरस्क्रिप्ट के लिए: एक पैराग्राफ और एक भाग बनाएं, `portion.portion_format.escapement` को **0 और 100** के बीच के मान पर सेट करें, टेक्स्ट सेट करें, और भाग जोड़ें।
1. सबस्क्रिप्ट के लिए:另 एक पैराग्राफ और भाग बनाएं, `escapement` को **-100 और 0** के बीच के मान पर सेट करें, टेक्स्ट सेट करें, और भाग जोड़ें।
1. प्रस्तुति को PPTX के रूप में सहेजें।

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    # स्लाइड प्राप्त करें।
    slide = presentation.slides[0]

    # एक टेक्स्ट बॉक्स बनाएं।
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)
    shape.text_frame.paragraphs.clear()

    # सुपरस्क्रिप्ट टेक्स्ट के लिए पैराग्राफ बनाएं।
    superscript_paragraph = slides.Paragraph()

    # नियमित टेक्स्ट के साथ एक टेक्स्ट भाग बनाएं।
    portion1 = slides.Portion()
    portion1.text = "SlideTitle"
    superscript_paragraph.portions.add(portion1)

    # सुपरस्क्रिप्ट टेक्स्ट के साथ एक टेक्स्ट भाग बनाएं।
    superscript_portion = slides.Portion()
    superscript_portion.portion_format.escapement = 30
    superscript_portion.text = "TM"
    superscript_paragraph.portions.add(superscript_portion)

    # सबस्क्रिप्ट टेक्स्ट के लिए पैराग्राफ बनाएं।
    subscript_paragraph = slides.Paragraph()

    # नियमित टेक्स्ट के साथ एक टेक्स्ट भाग बनाएं।
    portion2 = slides.Portion()
    portion2.text = "a"
    subscript_paragraph.portions.add(portion2)

    # सबस्क्रिप्ट टेक्स्ट के साथ एक टेक्स्ट भाग बनाएं।
    subscript_portion = slides.Portion()
    subscript_portion.portion_format.escapement = -25
    subscript_portion.text = "i"
    subscript_paragraph.portions.add(subscript_portion)

    # पैराग्राफ को टेक्स्ट बॉक्स में जोड़ें।
    shape.text_frame.paragraphs.add(superscript_paragraph)
    shape.text_frame.paragraphs.add(subscript_paragraph)

    presentation.save("TestOut.pptx", slides.export.SaveFormat.PPTX)
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं सुपरस्क्रिप्ट/सबस्क्रिप्ट को केवल सामान्य टेक्स्ट बॉक्स़ ही नहीं, बल्कि तालिकाओं और अन्य कंटेनरों में भी लागू कर सकता हूँ?**

हां। आप किसी भी ऑब्जेक्ट में, जो एक [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) प्रदान करता है (जिसमें तालिका सेल भी शामिल हैं), टेक्स्ट को सुपरस्क्रिप्ट या सबस्क्रिप्ट के रूप में फ़ॉर्मेट कर सकते हैं। फ़ॉर्मेटिंग उस फ़्रेम के भीतर के टेक्स्ट भागों पर लागू होती है।

**क्या सुपरस्क्रिप्ट/सबस्क्रिप्ट को PDF, HTML, या इमेज में एक्सपोर्ट करते समय संरक्षित रखा जाता है?**

हां। Aspose.Slides सामान्य फ़ॉर्मेट जैसे [PDF](/slides/hi/python-net/convert-powerpoint-to-pdf/), [HTML](/slides/hi/python-net/convert-powerpoint-to-html/), और [raster images](/slides/hi/python-net/convert-powerpoint-to-png/) में एक्सपोर्ट करने पर सुपरस्क्रिप्ट/सबस्क्रिप्ट फ़ॉर्मेटिंग को बनाए रखता है, क्योंकि रेंडरिंग पाइपलाइन भाग-स्तर की टेक्स्ट फ़ॉर्मेटिंग का सम्मान करती है।

**क्या मैं एक ही टेक्स्ट फ्रैगमेंट में सुपरस्क्रिप्ट/सबस्क्रिप्ट को हाइपरलिंक के साथ संयोजित कर सकता हूँ?**

हां। [Hyperlinks](/slides/hi/python-net/manage-hyperlinks/) भाग (फ़्रैगमेंट) स्तर पर असाइन किए जाते हैं, इसलिए एक भाग एक ही समय में हाइपरलिंक और सुपरस्क्रिप्ट या सबस्क्रिप्ट दोनों हो सकता है।