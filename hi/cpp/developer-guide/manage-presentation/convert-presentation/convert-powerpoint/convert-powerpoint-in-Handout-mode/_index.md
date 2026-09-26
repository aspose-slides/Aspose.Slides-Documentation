---
title: C++ का उपयोग करके हैंडआउट मोड में PowerPoint प्रस्तुतियों को बदलें
linktitle: हैंडआउट मोड
type: docs
weight: 150
url: /hi/cpp/convert-powerpoint-in-handout-mode/
keywords:
- PowerPoint बदलें
- प्रस्तुति बदलें
- हैंडआउट मोड
- हैंडआउट
- PPT
- PPTX
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "C++ में प्रस्तुतियों को हैंडआउट में बदलें। प्रति पृष्ठ स्लाइड्स सेट करें, नोट्स रखें, Aspose.Slides के साथ PDF या इमेजेज़ में निर्यात करें, साथ में नमूना कोड। इसे मुफ्त में आज़माएँ।"
---
## **परिचय**

Aspose.Slides विभिन्न स्वरूपों में प्रस्तुतियों को बदलने की क्षमता प्रदान करता है, जिसमें Handout मोड में प्रिंटिंग के लिए हैंडआउट बनाना शामिल है। यह मोड आपको यह विन्यस्त करने देता है कि कई स्लाइड एक पृष्ठ पर कैसे दिखाई दें, जिससे यह सम्मेलनों, सेमिनारों और अन्य कार्यक्रमों के लिए उपयोगी बनता है। आप इस मोड को `set_SlidesLayoutOptions` मेथड को निम्नलिखित इंटरफ़ेसेज़ में कॉल करके सक्रिय कर सकते हैं: [IPdfOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/ihtmloptions/), और [ITiffOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/itiffoptions/)।

निर्यात से पहले हैंडआउट पृष्ठ के आयाम और अभिविन्यास सेट करने के लिए, देखें [Notes Page Size](/slides/hi/cpp/notes-size/)।

## **हैंडआउट मोड निर्यात**

हैंडआउट मोड को कॉन्फ़िगर करने के लिए, आप [HandoutLayoutingOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/handoutlayoutingoptions/) ऑब्जेक्ट का उपयोग कर सकते हैं, जो निर्धारित करता है कि एक पृष्ठ पर कितनी स्लाइड्स रखी जाएँगी और अन्य प्रदर्शन पैरामीटर।

नीचे एक कोड उदाहरण दिया गया है जिसमें दिखाया गया है कि हैंडआउट मोड में प्रस्तुति को PDF में कैसे बदलें।

```cpp
#include <DOM/Presentation.h>
#include <Export/HandoutLayoutingOptions.h>
#include <Export/HandoutType.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Load a presentation.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Set the export options.
auto slidesLayoutOptions = MakeObject<HandoutLayoutingOptions>();
slidesLayoutOptions->set_Handout(HandoutType::Handouts4Horizontal);  // 4 स्लाइड्स एक पृष्ठ पर क्षैतिज रूप से
slidesLayoutOptions->set_PrintSlideNumbers(true);                    // स्लाइड नंबर प्रिंट करें
slidesLayoutOptions->set_PrintFrameSlide(true);                      // स्लाइड्स के चारों ओर एक फ्रेम प्रिंट करें
slidesLayoutOptions->set_PrintComments(false);                       // कोई टिप्पणी नहीं

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(slidesLayoutOptions);

// Export the presentation to PDF with the chosen layout.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

{{% alert color="warning" %}} 

ध्यान रखें कि `set_SlidesLayoutOptions` मेथड केवल कुछ आउटपुट फ़ॉर्मैट्स के लिए उपलब्ध है, जैसे PDF, HTML, TIFF, और जब इमेजेज़ के रूप में रेंडर किया जाए।

{{% /alert %}} 

## **अक्सर पूछे जाने वाले प्रश्न**

### हैंडआउट मोड में प्रति पृष्ठ अधिकतम कितनी स्लाइड थंबनेल हो सकती हैं?

Aspose.Slides [presets](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/handouttype/) का समर्थन करता है जो अधिकतम 9 थंबनेल प्रति पृष्ठ तक हो सकते हैं, क्षैतिज या लंबवत क्रम में: 1, 2, 3, 4 (क्षैतिज/लंबवत), 6 (क्षैतिज/लंबवत), और 9 (क्षैतिज/लंबवत)।

### क्या मैं 5 या 8 स्लाइड्स प्रति पृष्ठ जैसी कस्टम ग्रिड परिभाषित कर सकता हूँ?

नहीं। थंबनेल की संख्या और क्रम पूरी तरह से [HandoutType](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/handouttype/) एन्हूमरेशन द्वारा नियंत्रित होते हैं; मनमाने लेआउट समर्थित नहीं हैं।

### क्या मैं हैंडआउट आउटपुट में छिपी हुई स्लाइड्स शामिल कर सकता हूँ?

हां। लक्ष्य स्वरूप के निर्यात सेटिंग्स में `set_ShowHiddenSlides` मेथड का उपयोग करें, जैसे [PdfOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/htmloptions/), या [TiffOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/tiffoptions/)।