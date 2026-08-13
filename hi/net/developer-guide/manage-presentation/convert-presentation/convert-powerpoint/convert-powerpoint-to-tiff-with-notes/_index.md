---
title: .NET में नोट्स के साथ PowerPoint प्रस्तुतियों को TIFF में बदलें
linktitle: नोट्स के साथ PowerPoint को TIFF में
type: docs
weight: 100
url: /hi/net/convert-powerpoint-to-tiff-with-notes/
keywords:
- PowerPoint परिवर्तित करें
- प्रस्तुति परिवर्तित करें
- स्लाइड परिवर्तित करें
- PPT परिवर्तित करें
- PPTX परिवर्तित करें
- PowerPoint से TIFF
- प्रस्तुति को TIFF में
- स्लाइड को TIFF में
- PPT को TIFF में
- PPTX को TIFF में
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET का उपयोग करके नोट्स के साथ PowerPoint प्रस्तुतियों को TIFF में बदलें। स्लाइड्स को स्पीकर नोट्स के साथ कुशलतापूर्वक निर्यात करना सीखें।"
---
## **परिचय**

Aspose.Slides for .NET एक सरल समाधान प्रदान करता है PowerPoint और OpenDocument प्रस्तुतियों (PPT, PPTX, और ODP) को नोट्स के साथ TIFF प्रारूप में बदलने के लिए। यह प्रारूप उच्च‑गुणवत्ता वाली छवि भंडारण, प्रिंटिंग और दस्तावेज़ अभिलेख संरक्षण के लिए व्यापक रूप से उपयोग किया जाता है। Aspose.Slides के साथ आप न केवल पूरी प्रस्तुतियों को स्पीकर नोट्स के साथ निर्यात कर सकते हैं बल्कि नोट्स स्लाइड व्यू में स्लाइड थंबनेल भी बना सकते हैं। रूपांतरण प्रक्रिया सरल और कुशल है, जो [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास की `Save` मेथड का उपयोग करके पूरी प्रस्तुति को नोट्स और लेआउट को संरक्षित रखते हुए TIFF छवियों की श्रृंखला में बदलती है।

## **एक प्रस्तुति को नोट्स के साथ TIFF में रूपांतरित करें**

Aspose.Slides for .NET का उपयोग करके PowerPoint या OpenDocument प्रस्तुति को नोट्स के साथ TIFF में सहेजने के लिए निम्नलिखित चरण शामिल हैं:

1. एक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास को इनस्टैंशिएट करें: PowerPoint या OpenDocument फ़ाइल को लोड करें।
1. आउटपुट लेआउट विकल्प कॉन्फ़िगर करें: नोट्स और कमेंट्स कैसे दिखाए जाएंगे यह निर्दिष्ट करने के लिए [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/notescommentslayoutingoptions/) क्लास का उपयोग करें।
1. प्रस्तुति को TIFF में सहेजें: कॉन्फ़िगर किए गए विकल्पों को [Save](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/methods/save/index) मेथड में पास करें।

मान लीजिए हमारे पास "speaker_notes.pptx" फ़ाइल है जिसमें निम्नलिखित स्लाइड है:

![The presentation slide with speaker notes](slide_with_notes.png)

नीचे दिया गया कोड स्निपेट यह दर्शाता है कि कैसे [SlidesLayoutOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/tiffoptions/slideslayoutoptions/) प्रॉपर्टी का उपयोग करके नोट्स स्लाइड व्यू में प्रस्तुति को TIFF छवि में बदल सकते हैं।

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// एक Presentation क्लास का इंस्टैंस बनाएं जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है।
using (Presentation presentation = new Presentation("speaker_notes.pptx"))
{
    // नोट्स लेआउटिंग के साथ TIFF विकल्पों को कॉन्फ़िगर करें।
    TiffOptions tiffOptions = new TiffOptions
    {
        DpiX = 300,
        DpiY = 300,

        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // नोट्स को स्लाइड के नीचे दिखाएँ.
        }
    };

    // स्पीकर नोट्स के साथ प्रस्तुति को TIFF में सहेजें.
    presentation.Save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
}
```

परिणाम:

![The TIFF image with speaker notes](TIFF_with_notes.png)

{{% alert title="Tip" color="info" %}}
Aspose के [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/hi/conversion/convert-ppt-to-poster-online) को देखें।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

### क्या मैं परिणामी TIFF में नोट्स क्षेत्र की स्थिति को नियंत्रित कर सकता हूँ?

हाँ। नोट्स लेआउट सेटिंग्स का उपयोग करके आप `None`, `BottomTruncated`, या `BottomFull` जैसे विकल्पों में से चुन सकते हैं, जो क्रमशः नोट्स को छिपाते हैं, उन्हें एक ही पृष्ठ में फिट करते हैं, या अतिरिक्त पृष्ठों पर प्रवाहित होने देते हैं।

### कैसे मैं नोट्स वाले TIFF फ़ाइल का आकार गुणवत्ता में स्पष्ट कमी के बिना घटा सकता हूँ?

एक [efficient compression](https://reference.aspose.com/slides/hi/net/aspose.slides.export/tiffoptions/compressiontype/) चुनें (जैसे `LZW` या `RLE`), उचित DPI सेट करें, और यदि स्वीकार्य हो तो कम [pixel format](https://reference.aspose.com/slides/hi/net/aspose.slides.export/tiffoptions/pixelformat/) (जैसे मोनोक्रोम के लिए 8 bpp या 1 bpp) उपयोग करें। थोड़ा सा [image dimensions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/tiffoptions/imagesize/) घटाना भी पठनीयता पर स्पष्ट प्रभाव डाले बिना मदद कर सकता है।

### यदि सिस्टम में मूल फ़ॉन्ट्स नहीं हैं तो नोट्स में फ़ॉन्ट परिणाम को प्रभावित करता है क्या?

हँ। अनुपलब्ध फ़ॉन्ट्स [substitution](/slides/hi/net/font-selection-sequence/) को ट्रिगर करते हैं, जिससे टेक्स्ट मेट्रिक्स और रूप बदल सकता है। इसे रोकने के लिए आवश्यक फ़ॉन्ट्स [supply the required fonts](/slides/hi/net/custom-font/) प्रदान करें या डिफ़ॉल्ट [fallback font](/slides/hi/net/fallback-font/) सेट करें ताकि इच्छित टाइपफ़ेस उपयोग हो सके।