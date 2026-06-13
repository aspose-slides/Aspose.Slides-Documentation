---
title: Java में नोट्स के साथ PowerPoint प्रस्तुतियों को TIFF में परिवर्तित करें
linktitle: नोट्स के साथ PowerPoint से TIFF
type: docs
weight: 100
url: /hi/java/convert-powerpoint-to-tiff-with-notes/
keywords:
- PowerPoint रूपांतरण
- प्रेज़ेंटेशन रूपांतरण
- स्लाइड रूपांतरण
- PPT रूपांतरण
- PPTX रूपांतरण
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java का उपयोग करके नोट्स के साथ PowerPoint प्रस्तुतियों को TIFF में बदलें। स्लाइड्स को स्पीकर नोट्स के साथ कुशलतापूर्वक निर्यात करना सीखें।"
---
## **परिचय**

Aspose.Slides for Java PowerPoint और OpenDocument प्रेज़ेंटेशन (PPT, PPTX, और ODP) को नोट्स के साथ TIFF फ़ॉर्मेट में बदलने के लिए एक सरल समाधान प्रदान करता है। यह फ़ॉर्मेट उच्च‑गुणवत्ता वाली छवि संग्रहण, प्रिंटिंग और दस्तावेज़ अभिलेखागार के लिए व्यापक रूप से उपयोग किया जाता है। Aspose.Slides के साथ, आप न केवल पूरे प्रेज़ेंटेशन को स्पीकर नोट्स के साथ निर्यात कर सकते हैं बल्कि Notes Slide दृश्य में स्लाइड थंबनेल भी बना सकते हैं। रूपांतरण प्रक्रिया सरल और कुशल है, जो पूरे प्रेज़ेंटेशन को नोट्स और लेआउट को बनाए रखते हुए कई TIFF छवियों में बदलने के लिए [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास की `save` मेथड का उपयोग करती है।

## **नोट्स के साथ प्रेज़ेंटेशन को TIFF में परिवर्तित करें**

Aspose.Slides for Java का उपयोग करके नोट्स के साथ PowerPoint या OpenDocument प्रेज़ेंटेशन को TIFF में सेव करने के लिए निम्नलिखित चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास को इंस्टैंसिएट करें: PowerPoint या OpenDocument फ़ाइल लोड करें।
1. आउटपुट लेआउट विकल्प कॉन्फ़िगर करें: नोट्स और कॉमेंट्स को कैसे प्रदर्शित किया जाए, यह निर्दिष्ट करने के लिए [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/notescommentslayoutingoptions/) क्लास का उपयोग करें।
1. प्रेज़ेंटेशन को TIFF में सेव करें: कॉन्फ़िगर किए गए विकल्पों को [save](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) मेथड में पास करें।

मान लीजिए हमारे पास "speaker_notes.pptx" फ़ाइल है जिसमें निम्नलिखित स्लाइड है:

![स्पीकर नोट्स वाली प्रेज़ेंटेशन स्लाइड](slide_with_notes.png)

नीचे दिया गया कोड स्निपेट दिखाता है कि कैसे [setSlidesLayoutOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) मेथड का उपयोग करके Notes Slide दृश्य में प्रेज़ेंटेशन को TIFF छवि में परिवर्तित किया जाए।

```java
// प्रेज़ेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करें।
Presentation presentation = new Presentation("speaker_notes.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull); // स्लाइड के नीचे नोट्स प्रदर्शित करें।

    // नोट्स लेआउट के साथ TIFF विकल्प कॉन्फ़िगर करें।
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setDpiX(300);
    tiffOptions.setDpiY(300);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // स्पीकर नोट्स के साथ प्रेज़ेंटेशन को TIFF में सहेजें।
    presentation.save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

परिणाम:

![स्पीकर नोट्स के साथ TIFF चित्र](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
Aspose के [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/hi/conversion/convert-ppt-to-poster-online) देखें।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं परिणामस्वरूप TIFF में नोट्स क्षेत्र की स्थिति नियंत्रित कर सकता हूँ?**

Yes. Use the [notes layout settings](https://reference.aspose.com/slides/hi/java/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) to choose among options like `None`, `BottomTruncated`, or `BottomFull`, which respectively hide notes, fit them into a single page, or allow them to flow onto additional pages.

**नोट्स के साथ TIFF फ़ाइल का आकार बिना स्पष्ट गुणवत्ता हानि के कैसे घटा सकता हूँ?**

Pick an [efficient compression](https://reference.aspose.com/slides/hi/java/com.aspose.slides/tiffoptions/#setCompressionType-int-) (e.g., `LZW` or `RLE`), set a reasonable DPI, and, if acceptable, use a lower [pixel format](https://reference.aspose.com/slides/hi/java/com.aspose.slides/tiffoptions/#setPixelFormat-int-) (such as 8 bpp or 1 bpp for monochrome). Slightly reducing the [image dimensions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-) can also help without noticeably hurting readability.

**यदि सिस्टम में मूल फ़ॉन्ट उपलब्ध नहीं हैं तो नोट्स में फ़ॉन्ट परिणाम को प्रभावित करता है क्या?**

Yes. Missing fonts trigger [substitution](/slides/hi/java/font-selection-sequence/), which can change text metrics and appearance. To avoid this, [supply the required fonts](/slides/hi/java/custom-font/) or set a default [fallback font](/slides/hi/java/fallback-font/) so the intended typefaces are used।