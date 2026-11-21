---
title: Python का उपयोग करके हैंडआउट मोड में PowerPoint प्रस्तुतियों को रूपांतरित करें
linktitle: हैंडआउट मोड
type: docs
weight: 150
url: /hi/python-java/convert-powerpoint-in-handout-mode/
keywords:
- PowerPoint रूपांतरण
- प्रस्तुति रूपांतरण
- हैंडआउट मोड
- हैंडआउट
- PPT
- PPTX
- PowerPoint
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Python के माध्यम से Java में PowerPoint प्रस्तुतियों को हैंडआउट में परिवर्तित करें। कई स्लाइड्स को एक पृष्ठ पर व्यवस्थित करें और Aspose.Slides के साथ PDF में निर्यात करें।"
---
## **परिचय**

Aspose.Slides for Python via Java आपको हैंडआउट मोड में प्रेज़ेंटेशन निर्यात करने की सुविधा देता है, जिससे कई स्लाइड्स को एक पृष्ठ पर व्यवस्थित किया जा सकता है। यह सम्मेलनों, सेमिनारों और समान कार्यक्रमों के लिए प्रेज़ेंटेशन सामग्री प्रिंट करने में उपयोगी है।

लेआउट को [setSlidesLayoutOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) मेथड के द्वारा कॉन्फ़िगर करें। हैंडआउट लेआउट [PdfOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/htmloptions/) और [TiffOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/tiffoptions/) द्वारा समर्थित हैं। लेआउट और डिस्प्ले सेटिंग्स निर्दिष्ट करने के लिए एक [HandoutLayoutingOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/handoutlayoutingoptions/) ऑब्जेक्ट का उपयोग करें।

हैंडआउट पृष्ठ के आयाम और अभिविन्यास निर्यात से पहले सेट करने के लिए, देखें [नोट्स पेज आकार](/slides/hi/python-java/notes-size/)।

## **हैंडआउट मोड निर्यात**

हैंडआउट मोड में प्रेज़ेंटेशन निर्यात करने के लिए, एक [HandoutLayoutingOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/handoutlayoutingoptions/) इंस्टेंस बनाएँ और उसे लक्ष्य निर्यात विकल्पों में [setSlidesLayoutOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) का उपयोग करके असाइन करें।

निम्नलिखित उदाहरण `sample.pptx` को लोड करता है और इसे PDF में निर्यात करता है जिसमें प्रति पृष्ठ चार स्लाइड्स क्षैतिज क्रम में होंगी। यह स्लाइड नंबर और स्लाइड्स के चारों ओर फ्रेम शामिल करता है, और टिप्पणियों को बाहर रखता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HandoutLayoutingOptions, HandoutType, PdfOptions, Presentation, SaveFormat

# एक प्रस्तुति लोड करें।
presentation = Presentation("sample.pptx")
try:
    # हैंडआउट लेआउट कॉन्फ़िगर करें।
    slides_layout_options = HandoutLayoutingOptions()
    slides_layout_options.setHandout(HandoutType.Handouts4Horizontal)
    slides_layout_options.setPrintSlideNumbers(True)
    slides_layout_options.setPrintFrameSlide(True)
    slides_layout_options.setPrintComments(False)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(slides_layout_options)

    # चुने हुए लेआउट के साथ प्रस्तुति को PDF में निर्यात करें।
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="Warning" %}}
हैंडआउट लेआउट सेटिंग्स समर्थित आउटपुट फ़ॉर्मैट्स जैसे PDF, HTML, TIFF, और रेंडर की गई इमेजेज पर लागू होती हैं। वे स्रोत प्रेज़ेंटेशन में स्लाइड्स को पुनः व्यवस्थित नहीं करतीं।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**हैंडआउट मोड में प्रति पृष्ठ अधिकतम स्लाइड थंबनेल की संख्या क्या है?**

Aspose.Slides प्रति पृष्ठ अधिकतम नौ थंबनेल का समर्थन करता है। [HandoutType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/handouttype/) प्रीसेट एक, दो, तीन, चार, छह, या नौ स्लाइड्स प्रति पृष्ठ प्रदान करते हैं। चार, छह, और नौ-स्लाइड प्रीसेट क्षैतिज और लंबवत क्रम दोनों प्रदान करते हैं।

**क्या मैं पाँच या आठ स्लाइड्स प्रति पृष्ठ जैसे कस्टम ग्रिड को परिभाषित कर सकता हूँ?**

नहीं। थंबनेल की संख्या और क्रम पूर्वनिर्धारित [HandoutType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/handouttype/) मानों द्वारा नियंत्रित होते हैं। इन हैंडआउट लेआउट सेटिंग्स द्वारा मनमाना ग्रिड समर्थित नहीं है।

**क्या मैं हैंडआउट आउटपुट में छिपी हुई स्लाइड्स शामिल कर सकता हूँ?**

हाँ। लक्ष्य फ़ॉर्मेट के निर्यात सेटिंग्स में छिपी हुई स्लाइड्स को सक्षम करें। PDF के लिए, प्रेज़ेंटेशन को सहेजने से पहले [PdfOptions.setShowHiddenSlides](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) को `True` के साथ कॉल करें।