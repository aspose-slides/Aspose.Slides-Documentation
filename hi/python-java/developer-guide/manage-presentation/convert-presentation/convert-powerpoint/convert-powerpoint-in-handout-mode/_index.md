---
title: Python का उपयोग करके हैंडआउट मोड में PowerPoint प्रस्तुतियों को रूपांतरित करें
linktitle: हैंडआउट मोड
type: docs
weight: 150
url: /hi/python-java/convert-powerpoint-in-handout-mode/
keywords:
- PowerPoint रूपांतरित करें
- प्रस्तुति रूपांतरित करें
- हैंडआउट मोड
- हैंडआउट
- PPT
- PPTX
- PowerPoint
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Python के माध्यम से Java में PowerPoint प्रस्तुतियों को हैंडआउट में रूपांतरित करें। कई स्लाइड्स को प्रत्येक पृष्ठ पर व्यवस्थित करें और Aspose.Slides के साथ PDF में निर्यात करें।"
---
## **परिचय**

Aspose.Slides for Python via Java आपको प्रस्तुति को हैंडआउट मोड में निर्यात करने की अनुमति देता है, जिसमें कई स्लाइड्स को एक पृष्ठ पर व्यवस्थित किया जाता है। यह सम्मेलनों, सेमिनारों और समान कार्यक्रमों के लिए प्रस्तुति सामग्री को प्रिंट करने में उपयोगी है।

लेआउट को कॉन्फ़िगर करने के लिए [setSlidesLayoutOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) मेथड का उपयोग करें। हैंडआउट लेआउट्स को [PdfOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/htmloptions/) और [TiffOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/tiffoptions/) द्वारा सपोर्ट किया जाता है। लेआउट और डिस्प्ले सेटिंग्स निर्दिष्ट करने के लिए एक [HandoutLayoutingOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/handoutlayoutingoptions/) ऑब्जेक्ट का उपयोग करें।

## **हैंडआउट मोड निर्यात**

एक प्रस्तुति को हैंडआउट मोड में निर्यात करने के लिए, एक [HandoutLayoutingOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/handoutlayoutingoptions/) इंस्टेंस बनाएं और इसे लक्ष्य निर्यात विकल्पों को [setSlidesLayoutOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) के माध्यम से असाइन करें।

निम्नलिखित उदाहरण `sample.pptx` को लोड करता है और इसे पीडीएफ में चार स्लाइड प्रति पृष्ठ के साथ क्षैतिज क्रम में निर्यात करता है। इसमें स्लाइड नंबर और स्लाइड के चारों ओर फ्रेम शामिल हैं, और टिप्पणियों को बाहर रखा गया है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HandoutLayoutingOptions, HandoutType, PdfOptions, Presentation, SaveFormat

# प्रस्तुति लोड करें.
presentation = Presentation("sample.pptx")
try:
    # हैंडआउट लेआउट को कॉन्फ़िगर करें.
    slides_layout_options = HandoutLayoutingOptions()
    slides_layout_options.setHandout(HandoutType.Handouts4Horizontal)
    slides_layout_options.setPrintSlideNumbers(True)
    slides_layout_options.setPrintFrameSlide(True)
    slides_layout_options.setPrintComments(False)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(slides_layout_options)

    # चयनित लेआउट के साथ प्रस्तुति को PDF में निर्यात करें.
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="Warning" %}}
हैंडआउट लेआउट सेटिंग्स समर्थित आउटपुट फ़ॉर्मैट्स जैसे पीडीएफ, एचटीएमएल, टीआईएफएफ और रेंडर की गई छवियों पर लागू होती हैं। ये स्रोत प्रस्तुति में स्लाइड्स को पुनः व्यवस्थित नहीं करती हैं।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**हैंडआउट मोड में प्रति पृष्ठ अधिकतम स्लाइड थंबनेल की संख्या क्या है?**

Aspose.Slides प्रति पृष्ठ अधिकतम नौ थंबनेल का समर्थन करता है। [HandoutType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/handouttype/) प्रीसेट्स एक, दो, तीन, चार, छह, या नौ स्लाइड प्रति पृष्ठ प्रदान करते हैं। चार, छह और नौ स्लाइड के प्रीसेट्स क्षैतिज और लंबवत क्रम दोनों प्रदान करते हैं।

**क्या मैं पाँच या आठ स्लाइड प्रति पृष्ठ जैसी कस्टम ग्रिड परिभाषित कर सकता हूँ?**

नहीं। थंबनेल की संख्या और क्रम पूर्वनिर्दिष्ट [HandoutType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/handouttype/) मानों द्वारा नियंत्रित होते हैं। इन हैंडआउट लेआउट सेटिंग्स द्वारा मनमानी ग्रिड्स समर्थित नहीं हैं।

**क्या मैं हैंडआउट आउटपुट में छिपी स्लाइड्स शामिल कर सकता हूँ?**

हां। लक्ष्य फ़ॉर्मैट के लिए निर्यात सेटिंग्स में छिपी स्लाइड्स को सक्षम करें। PDF के लिए, प्रस्तुति को सहेजने से पहले [PdfOptions.setShowHiddenSlides](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) को `True` के साथ कॉल करें।