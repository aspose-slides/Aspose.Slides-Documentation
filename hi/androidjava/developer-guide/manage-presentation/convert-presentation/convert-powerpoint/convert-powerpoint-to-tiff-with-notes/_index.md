---
title: "Android पर नोट्स के साथ PowerPoint प्रस्तुतियों को TIFF में बदलें"
linktitle: "PowerPoint को नोट्स के साथ TIFF में बदलें"
type: docs
weight: 100
url: /hi/androidjava/convert-powerpoint-to-tiff-with-notes/
keywords:
- "PowerPoint बदलें"
- "प्रस्तुति बदलें"
- "स्लाइड बदलें"
- "PPT बदलें"
- "PPTX बदलें"
- "PowerPoint को TIFF में बदलें"
- "प्रस्तुति को TIFF में बदलें"
- "स्लाइड को TIFF में बदलें"
- "PPT को TIFF में बदलें"
- "PPTX को TIFF में बदलें"
- "PPT को TIFF के रूप में सहेजें"
- "PPTX को TIFF के रूप में सहेजें"
- "PPT को TIFF में निर्यात करें"
- "PPTX को TIFF में निर्यात करें"
- "नोट्स के साथ PowerPoint"
- "नोट्स के साथ प्रस्तुति"
- "नोट्स के साथ स्लाइड"
- "नोट्स के साथ PPT"
- "नोट्स के साथ PPTX"
- "नोट्स के साथ TIFF"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Aspose.Slides for Android via Java का उपयोग करके नोट्स के साथ PowerPoint प्रस्तुतियों को TIFF में बदलें। स्लाइड्स को स्पीकर नोट्स के साथ कुशलता से निर्यात करना सीखें।"
---
## **परिचय**

Aspose.Slides for Android via Java एक सरल समाधान प्रदान करता है जिससे PowerPoint और OpenDocument प्रस्तुतियों (PPT, PPTX, और ODP) को नोट्स के साथ TIFF प्रारूप में परिवर्तित किया जा सकता है। यह प्रारूप उच्च‑गुणवत्ता वाली छवि संग्रहण, मुद्रण और दस्तावेज़ अभिलेखागारण के लिए व्यापक रूप से उपयोग किया जाता है। Aspose.Slides के साथ आप न केवल संपूर्ण प्रस्तुतियों को स्पीकर नोट्स के साथ निर्यात कर सकते हैं, बल्कि नोट्स स्लाइड व्यू में स्लाइड थंबनेल भी बना सकते हैं। परिवर्तनीय प्रक्रिया सरल और कुशल है, जो `save` मेथड का उपयोग करके [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास के माध्यम से पूरी प्रस्तुति को नोट्स और लेआउट बनाए रखते हुए TIFF छवियों की श्रृंखला में बदल देती है।

## **नोट्स के साथ प्रस्तुति को TIFF में परिवर्तित करें**

Aspose.Slides for Android via Java का उपयोग करके PowerPoint या OpenDocument प्रस्तुति को नोट्स के साथ TIFF में सहेजने के लिए निम्नलिखित चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का उदाहरण बनाएँ: PowerPoint या OpenDocument फ़ाइल लोड करें।
1. आउटपुट लेआउट विकल्प निर्धारित करें: नोट्स और टिप्पणियों को कैसे प्रदर्शित किया जाना चाहिए, यह निर्दिष्ट करने के लिए [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/notescommentslayoutingoptions/) क्लास का उपयोग करें।
1. प्रस्तुति को TIFF में सहेजें: कॉन्फ़िगर किए गए विकल्पों को [save](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) मेथड में पास करें।

मान लीजिए हमारे पास "speaker_notes.pptx" फ़ाइल है जिसमें निम्नलिखित स्लाइड है:

![The presentation slide with speaker notes](slide_with_notes.png)

नीचे दिया गया कोड स्निपेट प्रदर्शित करता है कि कैसे [setSlidesLayoutOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) मेथड का उपयोग करके नोट्स स्लाइड व्यू में प्रस्तुति को TIFF छवि में परिवर्तित किया जाए।

```java
import com.aspose.slides.*;

// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास का उदाहरण बनाएं।
Presentation presentation = new Presentation("speaker_notes.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull); // स्लाइड के नीचे नोट्स प्रदर्शित करें।

    // नोट्स लेआउटिंग के साथ TIFF विकल्प कॉन्फ़िगर करें।
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setDpiX(300);
    tiffOptions.setDpiY(300);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // स्पीकर नोट्स के साथ प्रस्तुति को TIFF में सहेजें।
    presentation.save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

परिणाम:

![The TIFF image with speaker notes](TIFF_with_notes.png)

{{% alert title="Tip" color="info" %}}
Aspose [फ़्री PowerPoint से पोस्टर कनवर्टर](https://products.aspose.app/slides/hi/conversion/convert-ppt-to-poster-online) देखें।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

### क्या मैं परिणामी TIFF में नोट्स क्षेत्र की स्थिति नियंत्रित कर सकता हूँ?

हाँ। नोट्स लेआउट सेटिंग्स ([notes layout settings](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-)) का उपयोग करके `None`, `BottomTruncated`, या `BottomFull` जैसे विकल्पों में से चुन सकते हैं, जो क्रमशः नोट्स को छिपाते हैं, एकल पृष्ठ में फिट करते हैं, या अतिरिक्त पृष्ठों पर जारी रखने की अनुमति देते हैं।

### नोट्स के साथ TIFF फ़ाइल का आकार कैसे कम किया जाए बिना स्पष्ट गुणवत्ता हानि के?

एक [प्रभावी संपीड़न](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/tiffoptions/#setCompressionType-int-) (जैसे `LZW` या `RLE`) चुनें, उचित DPI सेट करें, और यदि स्वीकार्य हो तो नीचे वाला [पिक्सेल फ़ॉर्मेट](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/tiffoptions/#setPixelFormat-int-) (जैसे मोनोक्रोम के लिए 8 bpp या 1 bpp) उपयोग करें। [छवि आयामों](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-) को थोड़ा घटाना भी बिना पढ़ने की क्षमता को स्पष्ट रूप से नुकसान पहुँचाए मदद कर सकता है।

### क्या नोट्स में फ़ॉन्ट का परिणाम प्रभावित होता है यदि मूल फ़ॉन्ट सिस्टम में उपलब्ध नहीं हैं?

हाँ। अनुपलब्ध फ़ॉन्ट्स [स्थानीय प्रतिस्थापन](/slides/hi/androidjava/font-selection-sequence/) को ट्रिगर करते हैं, जो टेक्स्ट मेट्रिक्स और स्वरूप को बदल सकता है। इसे रोकने के लिए आवश्यक फ़ॉन्ट्स [प्रदान करें](/slides/hi/androidjava/custom-font/) या एक डिफ़ॉल्ट [फॉलबैक फ़ॉन्ट](/slides/hi/androidjava/fallback-font/) सेट करें ताकि इच्छित टाइपफ़ेस उपयोग में आए।