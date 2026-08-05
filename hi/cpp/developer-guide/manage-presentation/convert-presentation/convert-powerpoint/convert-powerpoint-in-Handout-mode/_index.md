---
title: C++ का उपयोग करके हैंडआउट मोड में PowerPoint प्रस्तुतियों को बदलें
linktitle: हैंडआउट मोड
type: docs
weight: 150
url: /hi/cpp/convert-powerpoint-in-handout-mode/
keywords:
- PowerPoint परिवर्तित करें
- प्रस्तुति रूपांतरित करें
- हैंडआउट मोड
- हैंडआउट
- PPT
- PPTX
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "C++ में प्रस्तुतियों को हैंडआउट में बदलें। प्रति पृष्ठ स्लाइड सेट करें, नोट्स रखें, Aspose.Slides के साथ PDF या छवियों में निर्यात करें, नमूना कोड सहित। इसे मुफ्त में आज़माएँ।"
---
## **परिचय**

Aspose.Slides विभिन्न स्वरूपों में प्रस्तुतियों को परिवर्तित करने की क्षमता प्रदान करता है, जिसमें Handout मोड में प्रिंटिंग के लिए हैंडआउट बनाना भी शामिल है। यह मोड आपको यह कॉन्फ़िगर करने की अनुमति देता है कि कई स्लाइडें एक पृष्ठ पर कैसे दिखें, जो सम्मेलनों, सेमिनारों और अन्य आयोजनों के लिए उपयोगी है। आप इस मोड को `set_SlidesLayoutOptions` मेथड को सेट करके सक्षम कर सकते हैं, यह मेथड [IPdfOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/ihtmloptions/), और [ITiffOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/itiffoptions/) इंटरफ़ेस में उपलब्ध है।

## **हैंडआउट मोड निर्यात**

हैंडआउट मोड को कॉन्फ़िगर करने के लिए, आप [HandoutLayoutingOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/handoutlayoutingoptions/) ऑब्जेक्ट का उपयोग करें, जो निर्धारित करता है कि एक पृष्ठ पर कितनी स्लाइडें रखी जाएँगी और अन्य प्रदर्शन पैरामीटर।

नीचे एक कोड उदाहरण दिया गया है जो दिखाता है कि कैसे एक प्रस्तुति को Handout मोड में PDF में परिवर्तित किया जाए।

```cpp
// एक प्रस्तुति लोड करें।
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// निर्यात विकल्प सेट करें।
auto slidesLayoutOptions = MakeObject<HandoutLayoutingOptions>();
slidesLayoutOptions->set_Handout(HandoutType::Handouts4Horizontal);  // एक पृष्ठ पर 4 स्लाइडें क्षैतिज रूप से
slidesLayoutOptions->set_PrintSlideNumbers(true);                    // स्लाइड नंबर प्रिंट करें
slidesLayoutOptions->set_PrintFrameSlide(true);                      // स्लाइडों के चारों ओर एक फ्रेम प्रिंट करें
slidesLayoutOptions->set_PrintComments(false);                       // कोई टिप्पणी नहीं

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(slidesLayoutOptions);

// चयनित लेआउट के साथ प्रस्तुति को PDF में निर्यात करें।
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

{{% alert color="warning" %}} 
ध्यान रखें कि `set_SlidesLayoutOptions` मेथड केवल कुछ आउटपुट फ़ॉर्मेट्स के लिए उपलब्ध है, जैसे PDF, HTML, TIFF, और जब छवियों के रूप में रेंडर किया जाता है।
{{% /alert %}} 

## **अक्सर पूछे जाने वाले प्रश्न**

**हैंडआउट मोड में प्रति पृष्ठ अधिकतम स्लाइड थंबनेल की संख्या क्या है?**

Aspose.Slides [presets](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/handouttype/) का समर्थन करता है, जो एक पृष्ठ पर अधिकतम 9 थंबनेल तक होते हैं और क्षैतिज या लंबवत क्रम में व्यवस्थित होते हैं: 1, 2, 3, 4 (horizontal/vertical), 6 (horizontal/vertical), और 9 (horizontal/vertical)。

**क्या मैं एक कस्टम ग्रिड, जैसे 5 या 8 स्लाइडें प्रति पृष्ठ, निर्धारित कर सकता हूँ?**

नहीं। थंबनेल की संख्या और क्रम को केवल [HandoutType](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/handouttype/) एनेमरेशन द्वारा सख्ती से नियंत्रित किया जाता है; मनमाने लेआउट समर्थित नहीं हैं।

**क्या मैं Handout आउटपुट में छिपी हुई स्लाइडें शामिल कर सकता हूँ?**

हाँ। लक्ष्य फ़ॉर्मेट के निर्यात सेटिंग्स में `set_ShowHiddenSlides` मेथड का उपयोग करें, जैसे कि [PdfOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/htmloptions/), या [TiffOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/tiffoptions/)।