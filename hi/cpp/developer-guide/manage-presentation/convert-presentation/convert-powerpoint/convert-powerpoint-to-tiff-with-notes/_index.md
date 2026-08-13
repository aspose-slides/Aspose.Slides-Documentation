---
title: C++ में नोट्स के साथ PowerPoint प्रस्तुतियों को TIFF में बदलें
linktitle: PowerPoint से नोट्स के साथ TIFF
type: docs
weight: 100
url: /hi/cpp/convert-powerpoint-to-tiff-with-notes/
keywords:
- PowerPoint परिवर्तित करें
- प्रेजेंटेशन परिवर्तित करें
- स्लाइड परिवर्तित करें
- PPT परिवर्तित करें
- PPTX परिवर्तित करें
- PowerPoint से TIFF
- प्रेजेंटेशन से TIFF
- स्लाइड से TIFF
- PPT से TIFF
- PPTX से TIFF
- PPT को TIFF के रूप में सहेजें
- PPTX को TIFF के रूप में सहेजें
- PPT को TIFF में निर्यात करें
- PPTX को TIFF में निर्यात करें
- नोट्स के साथ PowerPoint
- नोट्स के साथ प्रेजेंटेशन
- नोट्स के साथ स्लाइड
- नोट्स के साथ PPT
- नोट्स के साथ PPTX
- नोट्स के साथ TIFF
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ का उपयोग करके PowerPoint प्रस्तुतियों को नोट्स के साथ TIFF में बदलें। स्लाइड्स को स्पीकर नोट्स के साथ प्रभावी ढंग से निर्यात करना सीखें।"
---
## **परिचय**

Aspose.Slides for C++ PowerPoint और OpenDocument प्रस्तुतियों (PPT, PPTX, और ODP) को नोट्स सहित TIFF फ़ॉर्मेट में बदलने के लिए एक सरल समाधान प्रदान करता है। यह फ़ॉर्मेट उच्च‑गुणवत्ता वाली छवि संग्रहण, प्रिंटिंग और दस्तावेज़ अभिलेखीयक के लिए व्यापक रूप से उपयोग किया जाता है। Aspose.Slides के साथ आप न केवल पूरे प्रस्तुतियों को स्पीकर नोट्स के साथ निर्यात कर सकते हैं, बल्कि नोट्स स्लाइड दृश्य में स्लाइड थंबनेल भी उत्पन्न कर सकते हैं। रूपांतरण प्रक्रिया सरल और प्रभावी है, जो पूरी प्रस्तुति को कई TIFF छवियों में परिवर्तित करने के लिए [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) वर्ग की `Save` विधि का उपयोग करता है, जबकि नोट्स और लेआउट बरकरार रहते हैं।

## **नोट्स के साथ एक प्रस्तुति को TIFF में बदलें**

Aspose.Slides for C++ का उपयोग करके नोट्स सहित PowerPoint या OpenDocument प्रस्तुति को TIFF में सहेजने के लिए निम्नलिखित चरणों का पालन किया जाता है:

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) वर्ग का उदाहरण बनाएं: PowerPoint या OpenDocument फ़ाइल लोड करें।
1. आउटपुट लेआउट विकल्प कॉन्फ़िगर करें: नोट्स और टिप्पणियों को कैसे प्रदर्शित किया जाए, यह निर्दिष्ट करने के लिए [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/notescommentslayoutingoptions/) वर्ग का उपयोग करें।
1. प्रस्तुति को TIFF में सहेजें: कॉन्फ़िगर किए गए विकल्पों को [Save](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/save/) विधि में पास करें।

मान लीजिए हमारे पास "speaker_notes.pptx" फ़ाइल है जिसमें निम्नलिखित स्लाइड है:

![स्पीकर नोट्स के साथ प्रस्तुति स्लाइड](slide_with_notes.png)

नीचे दिया गया कोड स्निपेट दिखाता है कि कैसे [set_SlidesLayoutOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/) विधि का उपयोग करके नोट्स स्लाइड दृश्य में प्रस्तुति को TIFF छवि में बदला जा सकता है।

```cpp
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/SaveFormat.h>
#include <Export/TiffOptions.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास का उदाहरण बनाएं।
auto presentation = MakeObject<Presentation>(u"speaker_notes.pptx");

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // स्लाइड के नीचे नोट्स दिखाएँ।

// नोट्स लेआउटिंग के साथ TIFF विकल्प कॉन्फ़िगर करें।
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_DpiX(300);
tiffOptions->set_DpiY(300);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// स्पीकर नोट्स के साथ प्रस्तुति को TIFF में सहेजें।
presentation->Save(u"TIFF_with_notes.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

परिणाम:

![स्पीकर नोट्स के साथ TIFF छवि](TIFF_with_notes.png)

{{% alert title="Tip" color="info" %}}
Aspose का [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/hi/conversion/convert-ppt-to-poster-online) देखें।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

### क्या मैं उत्पन्न TIFF में नोट्स क्षेत्र की स्थिति को नियंत्रित कर सकता हूँ?

हाँ। नोट्स लेआउट सेटिंग्स [set_SlidesLayoutOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/) का उपयोग करके `None`, `BottomTruncated` या `BottomFull` जैसे विकल्पों में से चुन सकते हैं, जो क्रमशः नोट्स को छुपाते हैं, उन्हें एक पृष्ठ में फिट करते हैं, या अतिरिक्त पृष्ठों पर बहने की अनुमति देते हैं।

### नोट्स के साथ TIFF फ़ाइल का आकार गुणवत्ता में स्पष्ट कमी के बिना कैसे कम करें?

एक [कुशल संपीड़न](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) (जैसे `LZW` या `RLE`) चुनें, उचित DPI सेट करें, और यदि स्वीकार्य हो तो लोयर [pixel format](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) (जैसे 8 bpp या 1 bpp मोनोक्रोम के लिए) उपयोग करें। छवि आयामों को थोड़ा कम करने से भी पठनीयता पर अत्यधिक प्रभाव डाले बिना मदद मिल सकती है।

### यदि सिस्टम में मूल फ़ॉन्ट अनुपलब्ध हों तो नोट्स में फ़ॉन्ट परिणाम को प्रभावित करता है क्या?

हाँ। अनुपलब्ध फ़ॉन्ट्स [substitution](/slides/hi/cpp/font-selection-sequence/) को ट्रिगर करते हैं, जो टेक्स्ट मेट्रिक्स और रूपरंग बदल सकते हैं। इसे रोकने के लिए आवश्यक फ़ॉन्ट्स [provide](/slides/hi/cpp/custom-font/) करें या एक डिफ़ॉल्ट [fallback font](/slides/hi/cpp/fallback-font/) सेट करें ताकि इच्छित टाइपफ़ेस उपयोग किए जा सकें।