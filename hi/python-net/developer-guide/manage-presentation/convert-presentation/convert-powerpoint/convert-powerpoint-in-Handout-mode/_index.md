---
title: Python के साथ Handout मोड में प्रस्तुतियों का रूपांतरण
linktitle: Handout मोड
type: docs
weight: 150
url: /hi/python-net/convert-powerpoint-in-Handout-mode/
keywords:
- PowerPoint को बदलें
- प्रस्तुति को बदलें
- Handout मोड
- Handout
- PowerPoint
- प्रस्तुति
- PPT
- PPTX
- Python
- Aspose.Slides
description: "Python में प्रस्तुतियों को Handout में बदलें। प्रति पृष्ठ स्लाइडें निर्धारित करें, नोट्स रखें, Aspose.Slides के साथ PDF या छवियों में निर्यात करें, नमूना कोड के साथ। इसे मुफ्त में आज़माएँ।"
---
## **परिचय**

Aspose.Slides विभिन्न प्रारूपों में प्रस्तुतियों को बदलने की सुविधा प्रदान करता है, जिसमें Handout मोड में प्रिंट करने के लिए हैंडआउट बनाना शामिल है। यह मोड आपको एक पृष्ठ पर कई स्लाइडों को कैसे प्रदर्शित किया जाए, इसे कॉन्फ़िगर करने की अनुमति देता है, जिससे यह सम्मेलनों, सेमिनारों और अन्य कार्यक्रमों के लिए उपयोगी होता है। आप इस मोड को `slides_layout_options` प्रॉपर्टी सेट करके सक्षम कर सकते हैं, जैसे कि [PdfOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/htmloptions/), और [TiffOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/tiffoptions/) क्लासों में।

## **हैंडआउट मोड निर्यात**

हैंडआउट मोड को कॉन्फ़िगर करने के लिए, आप [HandoutLayoutingOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/handoutlayoutingoptions/) ऑब्जेक्ट का उपयोग करें, जो निर्धारित करता है कि एक पृष्ठ पर कितनी स्लाइडें रखी जाएँगी और अन्य प्रदर्शनी पैरामीटर।

नीचे एक कोड उदाहरण दिया गया है जो दिखाता है कि Handout मोड में प्रस्तुति को PDF में कैसे परिवर्तित किया जाए।

```py
# एक प्रस्तुति लोड करें।
with slides.Presentation("sample.pptx") as presentation:

    # निर्यात विकल्प सेट करें।
    slides_layout_options = slides.export.HandoutLayoutingOptions()
    slides_layout_options.handout = slides.export.HandoutType.HANDOUTS_4_HORIZONTAL  # एक पृष्ठ पर क्षैतिज रूप में 4 स्लाइडें
    slides_layout_options.print_slide_numbers = True                                 # स्लाइड नंबर प्रिंट करें
    slides_layout_options.print_frame_slide = True                                   # स्लाइड के चारों ओर एक फ्रेम प्रिंट करें
    slides_layout_options.print_comments = False                                     # कोई टिप्पणी नहीं

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = slides_layout_options

    # चयनित लेआउट के साथ प्रस्तुति को PDF में निर्यात करें।
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

{{% alert color="warning" %}} 
ध्यान रखें कि `slides_layout_options` प्रॉपर्टी केवल कुछ आउटपुट फ़ॉर्मेट्स के लिए उपलब्ध है, जैसे PDF, HTML, TIFF, और जब छवियों के रूप में रेंडर किया जाता है। 
{{% /alert %}} 

## **अक्सर पूछे जाने वाले प्रश्न**

**हैंडआउट मोड में प्रति पृष्ठ अधिकतम कितनी स्लाइड थंबनेल हो सकती हैं?**

Aspose.Slides [presets](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/handouttype/) का समर्थन करता है जो प्रति पृष्ठ अधिकतम 9 थंबनेल तक हो सकते हैं, क्षैतिज या लंबवत क्रम में: 1, 2, 3, 4 (horizontal/vertical), 6 (horizontal/vertical), और 9 (horizontal/vertical)।

**क्या मैं 5 या 8 स्लाइड प्रति पृष्ठ जैसी कस्टम ग्रिड परिभाषित कर सकता/सकती हूँ?**

नहीं। थंबनेल की संख्या और क्रम को [HandoutType](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/handouttype/) एनेमरेशन द्वारा सख्ती से नियंत्रित किया जाता है; सामान्य लेआउट समर्थित नहीं हैं।

**क्या मैं Handout आउटपुट में छुपी हुई स्लाइडें शामिल कर सकता/सकती हूँ?**

हाँ। लक्ष्य फ़ॉर्मेट के लिए निर्यात सेटिंग्स में `show_hidden_slides` विकल्प को सक्षम करें, जैसे [PdfOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/htmloptions/), या [TiffOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/tiffoptions/)।