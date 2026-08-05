---
title: "हैंडआउट मोड में Python के साथ प्रस्तुतियों को रूपांतरित करें"
linktitle: "हैंडआउट मोड"
type: docs
weight: 150
url: /hi/python-net/convert-powerpoint-in-handout-mode/
keywords:
- "PowerPoint रूपांतरित करें"
- "प्रस्तुति रूपांतरित करें"
- "हैंडआउट मोड"
- "हैंडआउट"
- "PowerPoint"
- "प्रस्तुति"
- "PPT"
- "PPTX"
- "Python"
- "Aspose.Slides"
description: "Python में प्रस्तुतियों को हैंडआउट में रूपांतरित करें। स्लाइड्स प्रति पृष्ठ सेट करें, नोट्स रखें, Aspose.Slides के साथ PDF या इमेज़ में निर्यात करें, नमूना कोड सहित। मुफ्त में आज़माएँ।"
---
## **परिचय**

Aspose.Slides विभिन्न फ़ॉर्मेट में प्रस्तुतियों को रूपांतरित करने की सुविधा प्रदान करता है, जिसमें Handout मोड में प्रिंटिंग के लिए हैंडआउट बनाना शामिल है। यह मोड आपको यह कॉन्फ़िगर करने देता है कि कई स्लाइड्स एक पेज पर कैसे दिखें, जिससे यह सम्मेलनों, सेमिनारों और अन्य आयोजनों के लिए उपयोगी बनता है। आप इस मोड को `slides_layout_options` प्रॉपर्टी को निम्न क्लासों में सेट करके सक्षम कर सकते हैं: [PdfOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/htmloptions/), और [TiffOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/tiffoptions/) क्लासेस।

## **हैंडआउट मोड निर्यात**

हैंडआउट मोड को कॉन्फ़िगर करने के लिए, आप [HandoutLayoutingOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/handoutlayoutingoptions/) ऑब्जेक्ट का उपयोग करें, जो निर्धारित करता है कि एक पेज पर कितनी स्लाइड्स रखी जाएँगी और अन्य डिस्प्ले पैरामीटर।

नीचे एक कोड उदाहरण दिया गया है जो दिखाता है कि प्रस्तुति को हैंडआउट मोड में PDF में कैसे रूपांतरित किया जाए।

```py
# प्रस्तुति लोड करें।
with slides.Presentation("sample.pptx") as presentation:

    # निर्यात विकल्प सेट करें।
    slides_layout_options = slides.export.HandoutLayoutingOptions()
    slides_layout_options.handout = slides.export.HandoutType.HANDOUTS_4_HORIZONTAL  # एक पृष्ठ पर 4 स्लाइड्स क्षैतिज रूप से
    slides_layout_options.print_slide_numbers = True                                 # स्लाइड नंबर प्रिंट करें
    slides_layout_options.print_frame_slide = True                                   # स्लाइड्स के चारों ओर फ्रेम प्रिंट करें
    slides_layout_options.print_comments = False                                     # कोई टिप्पणी नहीं

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = slides_layout_options

    # चुनी हुई लेआउट के साथ प्रस्तुति को PDF में निर्यात करें।
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

{{% alert color="warning" %}} 
ध्यान रखें कि `slides_layout_options` प्रॉपर्टी केवल कुछ आउटपुट फ़ॉर्मेट्स के लिए उपलब्ध है, जैसे PDF, HTML, TIFF, और जब इमेज़ के रूप में रेंडर किया जाता है। 
{{% /alert %}} 

## **अक्सर पूछे जाने वाले प्रश्न**

**हैंडआउट मोड में प्रति पृष्ठ अधिकतम स्लाइड थंबनेल की संख्या क्या है?**

Aspose.Slides [presets](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/handouttype/) का समर्थन करता है, जो क्षैतिज या लंबवत क्रम में प्रति पृष्ठ अधिकतम 9 थंबनेल तक प्रदान करते हैं: 1, 2, 3, 4 (horizontal/vertical), 6 (horizontal/vertical), और 9 (horizontal/vertical)।

**क्या मैं 5 या 8 स्लाइड्स प्रति पृष्ठ जैसे कस्टम ग्रिड को परिभाषित कर सकता/सकती हूँ?**

नहीं। थंबनेल की संख्या और क्रम पूरी तरह से [HandoutType](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/handouttype/) एन्युमरेशन द्वारा नियंत्रित होते हैं; मनमाने लेआउट समर्थित नहीं हैं।

**क्या मैं हैंडआउट आउटपुट में छुपी हुई स्लाइड्स शामिल कर सकता/सकती हूँ?**

हां। लक्ष्य फ़ॉर्मेट के निर्यात सेटिंग्स में `show_hidden_slides` विकल्प को सक्षम करें, जैसे कि [PdfOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/htmloptions/), या [TiffOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/tiffoptions/)।