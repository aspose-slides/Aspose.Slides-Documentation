---
title: .NET में नोट्स के साथ PowerPoint प्रस्तुतियों को TIFF में बदलें
linktitle: नोट्स के साथ PowerPoint से TIFF
type: docs
weight: 100
url: /hi/net/convert-powerpoint-to-tiff-with-notes/
keywords:
- PowerPoint को परिवर्तित करें
- प्रेज़ेंटेशन को परिवर्तित करें
- स्लाइड को परिवर्तित करें
- PPT को परिवर्तित करें
- PPTX को परिवर्तित करें
- PowerPoint से TIFF
- प्रेज़ेंटेशन से TIFF
- स्लाइड से TIFF
- PPT से TIFF
- PPTX से TIFF
- PPT को TIFF के रूप में सहेजें
- PPTX को TIFF के रूप में सहेजें
- PPT को TIFF में निर्यात करें
- PPTX को TIFF में निर्यात करें
- नोट्स के साथ PowerPoint
- नोट्स के साथ प्रेज़ेंटेशन
- नोट्स के साथ स्लाइड
- नोट्स के साथ PPT
- नोट्स के साथ PPTX
- नोट्स के साथ TIFF
- .NET
- C#
- Aspose.Slides
description: ".NET के लिए Aspose.Slides का उपयोग करके नोट्स के साथ PowerPoint प्रस्तुतियों को TIFF में बदलें। स्लाइड्स को स्पीकर नोट्स के साथ कुशलतापूर्वक निर्यात करना सीखें।"
---
## **परिचय**

Aspose.Slides for .NET PowerPoint और OpenDocument प्रस्तुतियों (PPT, PPTX, और ODP) को नोट्स के साथ TIFF फ़ॉर्मेट में बदलने के लिए एक सरल समाधान प्रदान करता है। यह फ़ॉर्मेट उच्च‑गुणवत्ता वाली छवि संग्रह, प्रिंटिंग और दस्तावेज़ अभिलेखन के लिए व्यापक रूप से उपयोग किया जाता है। Aspose.Slides के साथ, आप न केवल पूरी प्रस्तुतियों को स्पीकर नोट्स के साथ निर्यात कर सकते हैं बल्कि नोट्स स्लाइड दृश्य में स्लाइड थंबनेल भी बना सकते हैं। रूपांतरण प्रक्रिया सरल और कुशल है, जो सम्पूर्ण प्रस्तुति को नोट्स और लेआउट बनाए रखते हुए TIFF छवियों की श्रृंखला में बदलने के लिए [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास की `Save` मेथड का उपयोग करती है।

## **नोट्स के साथ एक प्रस्तुति को TIFF में बदलें**

Aspose.Slides for .NET का उपयोग करके नोट्स के साथ PowerPoint या OpenDocument प्रस्तुति को TIFF में सहेजने के लिए निम्नलिखित चरण शामिल हैं:

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास का उदाहरण बनाएं: PowerPoint या OpenDocument फ़ाइल लोड करें।  
2. आउटपुट लेआउट विकल्प कॉन्फ़िगर करें: नोट्स और टिप्पणियां कैसे प्रदर्शित हों, इसे निर्दिष्ट करने के लिए [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/notescommentslayoutingoptions/) क्लास का उपयोग करें।  
3. प्रस्तुति को TIFF में सहेजें: कॉन्फ़िगर किए गए विकल्पों को [Save](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/methods/save/index) मेथड में पास करें।

मान लें हमारे पास "speaker_notes.pptx" फ़ाइल है जिसमें निम्नलिखित स्लाइड है:

![प्रस्तुति स्लाइड जिसमें स्पीकर नोट्स हैं](slide_with_notes.png)

नीचे दिया गया कोड स्निपेट दर्शाता है कि कैसे [SlidesLayoutOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/tiffoptions/slideslayoutoptions/) प्रॉपर्टी का उपयोग करके नोट्स स्लाइड दृश्य में प्रस्तुति को TIFF छवि में बदल सकते हैं।

```c#
// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं।
using (Presentation presentation = new Presentation("speaker_notes.pptx"))
{
    // नोट्स लेआउटिंग के साथ TIFF विकल्पों को कॉन्फ़िगर करें।
    TiffOptions tiffOptions = new TiffOptions
    {
        DpiX = 300,
        DpiY = 300,

        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // स्लाइड के नीचे नोट्स प्रदर्शित करें।
        }
    };

    // स्पीकर नोट्स के साथ प्रस्तुति को TIFF में सहेजें।
    presentation.Save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
}
```

परिणाम:

![स्पीकर नोट्स के साथ TIFF छवि](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/hi/conversion/convert-ppt-to-poster-online) देखें।  
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं परिणामी TIFF में नोट्स क्षेत्र की स्थिति नियंत्रित कर सकता हूँ?**  
हाँ। [नोट्स लेआउट सेटिंग्स](https://reference.aspose.com/slides/hi/net/aspose.slides.export/tiffoptions/slideslayoutoptions/) का उपयोग करके `None`, `BottomTruncated` या `BottomFull` जैसे विकल्पों में से चुनें, जो क्रमशः नोट्स को छुपाते हैं, उन्हें एक पेज में फिट करते हैं, या अतिरिक्त पृष्ठों पर फैलने की अनुमति देते हैं।

**मैं नोट्स के साथ TIFF फ़ाइल का आकार कैसे घटा सकता हूँ बिना गुणवत्ता में स्पष्ट कमी के?**  
एक [कुशल संपीड़न](https://reference.aspose.com/slides/hi/net/aspose.slides.export/tiffoptions/compressiontype/) चुनें (जैसे `LZW` या `RLE`), उचित DPI सेट करें, और यदि स्वीकार्य हो तो कम [पिक्सेल फ़ॉर्मेट](https://reference.aspose.com/slides/hi/net/aspose.slides.export/tiffoptions/pixelformat/) (जैसे मोनोक्रोम के लिए 8 bpp या 1 bpp) का उपयोग करें। हल्का [छवि आयाम](https://reference.aspose.com/slides/hi/net/aspose.slides.export/tiffoptions/imagesize/) घटाना भी मददगार हो सकता है बिना पठनीयता पर स्पष्ट प्रभाव डाले।

**यदि सिस्टम में मूल फ़ॉन्ट उपलब्ध नहीं हैं तो नोट्स में फ़ॉन्ट परिणाम को प्रभावित करता है क्या?**  
हाँ। लापता फ़ॉन्ट्स [substitution](/slides/hi/net/font-selection-sequence/) को ट्रिगर करते हैं, जिससे टेक्स्ट मेट्रिक्स और रूप बदल सकता है। इसे रोकने के लिए, आवश्यक फ़ॉन्ट्स [supply the required fonts](/slides/hi/net/custom-font/) प्रदान करें या डिफ़ॉल्ट [fallback font](/slides/hi/net/fallback-font/) सेट करें ताकि इच्छित टाइपफ़ेस इस्तेमाल हों।