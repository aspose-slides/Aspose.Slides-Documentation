---
title: C++ में नोट्स के साथ PowerPoint प्रस्तुतियों को TIFF में परिवर्तित करें
linktitle: नोट्स के साथ PowerPoint से TIFF
type: docs
weight: 100
url: /hi/cpp/convert-powerpoint-to-tiff-with-notes/
keywords:
- PowerPoint परिवर्तित करें
- प्रस्तुति परिवर्तित करें
- स्लाइड परिवर्तित करें
- PPT परिवर्तित करें
- PPTX परिवर्तित करें
- PowerPoint से TIFF
- प्रस्तुति से TIFF
- स्लाइड से TIFF
- PPT से TIFF
- PPTX से TIFF
- PPT को TIFF के रूप में सहेजें
- PPTX को TIFF के रूप में सहेजें
- PPT को TIFF में निर्यात करें
- PPTX को TIFF में निर्यात करें
- नोट्स के साथ PowerPoint
- नोट्स के साथ प्रस्तुति
- नोट्स के साथ स्लाइड
- नोट्स के साथ PPT
- नोट्स के साथ PPTX
- नोट्स के साथ TIFF
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ का उपयोग करके PowerPoint प्रस्तुतियों को नोट्स के साथ TIFF में परिवर्तित करें। स्पीकर नोट्स के साथ स्लाइड्स को कुशलता से निर्यात करना सीखें।"
---
## **परिचय**

Aspose.Slides for C++ PowerPoint और OpenDocument प्रस्तुतियों (PPT, PPTX, और ODP) को नोट्स के साथ TIFF प्रारूप में परिवर्तित करने के लिए एक सरल समाधान प्रदान करता है। यह प्रारूप उच्च‑गुणवत्ता वाली छवि संग्रहण, प्रिंटिंग और दस्तावेज़ अभिलेखीयकरण के लिए व्यापक रूप से उपयोग किया जाता है। Aspose.Slides के साथ आप न केवल स्पीकर नोट्स के साथ पूरी प्रस्तुतियों को निर्यात कर सकते हैं, बल्कि नोट्स स्लाइड दृश्य में स्लाइड थंबनेल भी उत्पन्न कर सकते हैं। परिवर्तन प्रक्रिया सरल और कुशल है, जो पूरे प्रस्तुतिकरण को नोट्स और लेआउट को बनाए रखते हुए TIFF छवियों की श्रृंखला में बदलने के लिए `Save` मेथड का उपयोग करती है, जैसा कि [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास में दिखाया गया है।

## **प्रेजेंटेशन को नोट्स के साथ TIFF में बदलें**

Aspose.Slides for C++ का उपयोग करके PowerPoint या OpenDocument प्रस्तुति को नोट्स के साथ TIFF में सहेजने के लिए निम्नलिखित चरणों का पालन करना होता है:

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का उदाहरण बनाएँ: PowerPoint या OpenDocument फ़ाइल लोड करें।  
2. आउटपुट लेआउट विकल्पों को कॉन्फ़िगर करें: नोट्स और टिप्पणी को कैसे प्रदर्शित किया जाए, यह निर्धारित करने के लिए [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/notescommentslayoutingoptions/) क्लास का उपयोग करें।  
3. प्रस्तुति को TIFF में सहेजें: कॉन्फ़िगर किए गए विकल्पों को [Save](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/save/) मेथड में पास करें।

मान लीजिए हमारे पास "speaker_notes.pptx" फ़ाइल है जिसमें निम्नलिखित स्लाइड है:

![नोट्स के साथ प्रस्तुति स्लाइड](slide_with_notes.png)

नीचे दिया गया कोड स्निपेट दर्शाता है कि कैसे नोट्स स्लाइड दृश्य में [set_SlidesLayoutOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/) मेथड का उपयोग करके प्रस्तुति को TIFF छवि में परिवर्तित किया जा सकता है।

```cpp
// Presentation क्लास का एक उदाहरण बनाएं जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है।
auto presentation = MakeObject<Presentation>(u"speaker_notes.pptx");

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // स्लाइड के नीचे नोट्स प्रदर्शित करें।

// Notes लेआउट के साथ TIFF विकल्प कॉन्फ़िगर करें।
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_DpiX(300);
tiffOptions->set_DpiY(300);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// Save the presentation to TIFF with the speaker notes.
presentation->Save(u"TIFF_with_notes.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

परिणाम:

![नोट्स के साथ TIFF छवि](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
Aspose के [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/hi/conversion/convert-ppt-to-poster-online) को देखें।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं परिणामस्वरूप TIFF में नोट्स क्षेत्र की स्थिति को नियंत्रित कर सकता हूं?**

हाँ। नोट्स लेआउट सेटिंग्स का उपयोग करके आप `None`, `BottomTruncated`, या `BottomFull` जैसे विकल्पों में से चुन सकते हैं, जो क्रमशः नोट्स को छिपाते हैं, उन्हें एक पृष्ठ में फिट करते हैं, या अतिरिक्त पृष्ठों पर प्रवाहित होने की अनुमति देते हैं।  
[notes layout settings](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/)

**मैं नोट्स के साथ TIFF फ़ाइल का आकार बिना स्पष्ट गुणवत्ता हानि के कैसे घटा सकता हूं?**

एक प्रभावी संपीड़न चुनें (जैसे `LZW` या `RLE`), उचित DPI सेट करें, और यदि स्वीकार्य हो तो लोअर [pixel format](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) (जैसे 8 bpp या मोनोक्रोम के लिए 1 bpp) उपयोग करें। हल्का आकार घटाने के लिए [image dimensions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/tiffoptions/set_imagesize/) भी मदद कर सकते हैं, जिससे पठनीयता पर उल्लेखनीय असर नहीं पड़ता।  
[efficient compression](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/tiffoptions/set_compressiontype/)

**यदि मूल फ़ॉन्ट सिस्टम में उपलब्ध नहीं हैं तो नोट्स में फ़ॉन्ट परिणाम को प्रभावित करता है क्या?**

हाँ। गायब फ़ॉन्ट्स [substitution](/slides/hi/cpp/font-selection-sequence/) को ट्रिगर करते हैं, जिससे टेक्स्ट मीट्रिक और रूप बदल सकता है। इसे रोकने के लिए आवश्यक फ़ॉन्ट्स [सप्लाई](/slides/hi/cpp/custom-font/) करें या डिफ़ॉल्ट [fallback font](/slides/hi/cpp/fallback-font/) सेट करें, ताकि इच्छित टाइपफ़ेस उपयोग हो सकें।