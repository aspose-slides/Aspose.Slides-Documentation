---
title: "C++ का उपयोग करके Handout मोड में PowerPoint प्रस्तुतियों को बदलें"
linktitle: "हैंडआउट मोड"
type: docs
weight: 150
url: /hi/cpp/convert-powerpoint-in-Handout-mode/
keywords:
  - "PowerPoint बदलें"
  - "प्रस्तुति रूपांतरित करें"
  - "हैंडआउट मोड"
  - "हैंडआउट"
  - PPT
  - PPTX
  - PowerPoint
  - प्रस्तुति
  - C++
  - Aspose.Slides
description: "C++ में प्रस्तुतियों को हैंडआउट में बदलें। प्रति पृष्ठ स्लाइड सेट करें, नोट्स रखें, Aspose.Slides के साथ PDF या छवियों में निर्यात करें, नमूना कोड सहित। इसे मुफ्त में आज़माएँ।"
---
## **परिचय**

Aspose.Slides विभिन्न प्रारूपों में प्रस्तुतियों को बदलने की क्षमता प्रदान करता है, जिसमें Handout मोड में प्रिंटिंग के लिए हैंडआउट बनाना शामिल है। यह मोड आपको निर्धारित करने की अनुमति देता है कि एक पृष्ठ पर कई स्लाइड कैसे दिखें, जो सम्मेलन, सेमिनार और अन्य आयोजनों के लिए उपयोगी है। आप इस मोड को सक्षम कर सकते हैं `set_SlidesLayoutOptions` मेथड को [IPdfOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/ihtmloptions/), और [ITiffOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/itiffoptions/) इंटरफेस में सेट करके।

## **हैंडआउट मोड निर्यात**

हैंडआउट मोड को कॉन्फ़िगर करने के लिए, आप [HandoutLayoutingOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/handoutlayoutingoptions/) ऑब्जेक्ट का उपयोग करें, जो निर्धारित करता है कि एक पृष्ठ पर कितनी स्लाइड रखी जाएँगी और अन्य प्रदर्शन पैरामिटर।

नीचे एक कोड उदाहरण दिया गया है जो दिखाता है कि कैसे एक प्रस्तुति को Handout मोड में PDF में बदलें।

```cpp
// प्रस्तुति लोड करें।
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Set the export options.
auto slidesLayoutOptions = MakeObject<HandoutLayoutingOptions>();
slidesLayoutOptions->set_Handout(HandoutType::Handouts4Horizontal);  // एक पृष्ठ पर 4 स्लाइड क्षैतिज रूप में
slidesLayoutOptions->set_PrintSlideNumbers(true);                    // स्लाइड नंबर प्रिंट करें
slidesLayoutOptions->set_PrintFrameSlide(true);                      // स्लाइडों के आसपास फ्रेम प्रिंट करें
slidesLayoutOptions->set_PrintComments(false);                       // कोई टिप्पणी नहीं

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(slidesLayoutOptions);

// Export the presentation to PDF with the chosen layout.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

{{% alert color="warning" %}} 

ध्यान रखें कि `set_SlidesLayoutOptions` मेथड केवल कुछ आउटपुट प्रारूपों के लिए उपलब्ध है, जैसे PDF, HTML, TIFF, और जब इमेज के रूप में रेंडर किया जाता है।

{{% /alert %}} 

## **अक्सर पूछे जाने वाले प्रश्न**

**हैंडआउट मोड में प्रति पृष्ठ अधिकतम स्लाइड थंबनेल की संख्या क्या है?**

Aspose.Slides [presets](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/handouttype/) का समर्थन करता है जो अधिकतम 9 थंबनेल प्रति पृष्ठ तक होते हैं, क्षैतिज या लंबवत क्रम में: 1, 2, 3, 4 (क्षैतिज/लंबवत), 6 (क्षैतिज/लंबवत), और 9 (क्षैतिज/लंबवत)।

**क्या मैं कस्टम ग्रिड, जैसे 5 या 8 स्लाइड प्रति पृष्ठ, परिभाषित कर सकता हूँ?**

नहीं। थंबनेल की संख्या और क्रम को सख्ती से [HandoutType](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/handouttype/) एन्यूमरेशन द्वारा नियंत्रित किया जाता है; मनमाने लेआउट समर्थित नहीं हैं।

**क्या मैं Handout आउटपुट में छिपी हुई स्लाइड शामिल कर सकता हूँ?**

हाँ। लक्ष्य प्रारूप के निर्यात सेटिंग्स में `set_ShowHiddenSlides` मेथड का उपयोग करें, जैसे कि [PdfOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/htmloptions/), या [TiffOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/tiffoptions/)।