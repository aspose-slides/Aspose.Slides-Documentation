---
title: Python के साथ हैंडआउट मोड में प्रस्तुतियों को परिवर्तित करें
linktitle: हैंडआउट मोड
type: docs
weight: 150
url: /hi/python-net/convert-powerpoint-in-handout-mode/
keywords:
- PowerPoint को परिवर्तित करें
- प्रस्तुति को परिवर्तित करें
- हैंडआउट मोड
- हैंडआउट
- PowerPoint
- प्रस्तुति
- PPT
- PPTX
- Python
- Aspose.Slides
description: "Python में प्रस्तुतियों को हैंडआउट में परिवर्तित करें। प्रति पृष्ठ स्लाइड सेट करें, नोट्स रखें, Aspose.Slides के साथ PDF या इमेज में निर्यात करें, साथ में नमूना कोड। इसे मुफ्त आज़माएँ।"
---
## **परिचय**

Aspose.Slides प्रस्तुतियों को विभिन्न स्वरूपों में रूपांतरित करने की क्षमता प्रदान करता है, जिसमें Handout मोड में प्रिंटिंग के लिए हैंडआउट बनाना भी शामिल है। यह मोड आपको कई स्लाइड्स को एक पृष्ठ पर कैसे प्रदर्शित किया जाए, इसे कॉन्फ़िगर करने की अनुमति देता है, जिससे यह सम्मेलनों, सेमिनारों और अन्य कार्यक्रमों के लिए उपयोगी है। आप `slides_layout_options` प्रॉपर्टी को सेट करके इस मोड को सक्षम कर सकते हैं, चाहे वह [PdfOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/htmloptions/), या [TiffOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/tiffoptions/) क्लासेस में हो।

निर्यात से पहले हैंडआउट पृष्ठ के आयाम और अभिविन्यास सेट करने के लिए, देखें [नोट्स पेज आकार](/slides/hi/python-net/notes-size/)।

## **हैंडआउट मोड निर्यात**

हैंडआउट मोड को कॉन्फ़िगर करने के लिए, [HandoutLayoutingOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/handoutlayoutingoptions/) ऑब्जेक्ट का उपयोग करें, जो निर्धारित करता है कि एक पृष्ठ पर कितनी स्लाइड्स रखी जाती हैं और अन्य प्रदर्शन पैरामीटर।

नीचे एक कोड उदाहरण है जो दिखाता है कि कैसे एक प्रस्तुति को Handout मोड में PDF में परिवर्तित किया जाए।

```py
import aspose.slides as slides

# प्रस्तुति लोड करें.
with slides.Presentation("sample.pptx") as presentation:

    # निर्यात विकल्प सेट करें.
    slides_layout_options = slides.export.HandoutLayoutingOptions()
    slides_layout_options.handout = slides.export.HandoutType.HANDOUTS_4_HORIZONTAL  # एक पृष्ठ पर क्षैतिज रूप से 4 स्लाइड्स
    slides_layout_options.print_slide_numbers = True                                 # स्लाइड नंबर प्रिंट करें
    slides_layout_options.print_frame_slide = True                                   # स्लाइड्स के चारों ओर फ्रेम प्रिंट करें
    slides_layout_options.print_comments = False                                     # कोई टिप्पणी नहीं

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = slides_layout_options

    # चुने गए लेआउट के साथ प्रस्तुति को PDF में निर्यात करें.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

{{% alert color="warning" title="Warning" %}}
ध्यान रखें कि `slides_layout_options` प्रॉपर्टी केवल कुछ आउटपुट फ़ॉर्मैट्स के लिए उपलब्ध है, जैसे PDF, HTML, TIFF, और जब इमेज के रूप में रेंडर किया जाता है।
{{% /alert %}} 

## **अक्सर पूछे जाने वाले प्रश्न**

**हैंडआउट मोड में प्रति पृष्ठ अधिकतम स्लाइड थंबनेल की संख्या क्या है?**

Aspose.Slides [presets](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/handouttype/) का समर्थन करता है जो प्रति पृष्ठ अधिकतम 9 थंबनेल तक हो सकते हैं, क्षैतिज या लंबवत क्रम में: 1, 2, 3, 4 (horizontal/vertical), 6 (horizontal/vertical), और 9 (horizontal/vertical)।

**क्या मैं एक कस्टम ग्रिड, जैसे 5 या 8 स्लाइड्स प्रति पृष्ठ, परिभाषित कर सकता हूँ?**

नहीं। थंबनेल की संख्या और क्रम पूरी तरह से [HandoutType](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/handouttype/) एन्यूमरेशन द्वारा नियंत्रित होते हैं; मनमाना लेआउट समर्थित नहीं है।

**क्या मैं Handout आउटपुट में छिपी हुई स्लाइड्स शामिल कर सकता हूँ?**

हां। लक्ष्य फ़ॉर्मैट के निर्यात सेटिंग्स में `show_hidden_slides` विकल्प को सक्षम करें, जैसे [PdfOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/htmloptions/), या [TiffOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/tiffoptions/)।