---
title: Android पर नोट्स के साथ PowerPoint प्रस्तुतियों को TIFF में परिवर्तित करें
linktitle: नोट्स के साथ PowerPoint से TIFF
type: docs
weight: 100
url: /hi/androidjava/convert-powerpoint-to-tiff-with-notes/
keywords:
- PowerPoint रूपांतरण
- प्रस्तुति रूपांतरण
- स्लाइड रूपांतरण
- PPT रूपांतरण
- PPTX रूपांतरण
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java का उपयोग करके PowerPoint प्रस्तुतियों को नोट्स के साथ TIFF में परिवर्तित करें। जानें कि कैसे स्पीकर नोट्स के साथ स्लाइड्स को कुशलता से निर्यात किया जा सकता है।"
---
## **परिचय**

Aspose.Slides for Android via Java PowerPoint और OpenDocument प्रस्तुतियों (PPT, PPTX, और ODP) को नोट्स के साथ TIFF फ़ॉर्मेट में परिवर्तित करने के लिए एक सरल समाधान प्रदान करता है। यह फ़ॉर्मेट उच्च गुणवत्ता वाली छवि संग्रहण, प्रिंटिंग और दस्तावेज़ अभिलेखांकन के लिए व्यापक रूप से उपयोग किया जाता है। Aspose.Slides के साथ, आप न केवल संपूर्ण प्रस्तुतियों को स्पीकर नोट्स के साथ निर्यात कर सकते हैं बल्कि नोट्स स्लाइड व्यू में स्लाइड थंबनेल भी उत्पन्न कर सकते हैं। रूपांतरण प्रक्रिया सरल और कुशल है, यह `save` मेथड का उपयोग करता है [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का, जिससे संपूर्ण प्रस्तुति को नोट्स और लेआउट को बनाए रखते हुए कई TIFF छवियों में बदला जाता है।

## **प्रस्तुति को नोट्स के साथ TIFF में परिवर्तित करें**

PowerPoint या OpenDocument प्रस्तुति को नोट्स के साथ TIFF में सेव करने के लिए Aspose.Slides for Android via Java निम्नलिखित चरणों में शामिल है:

1. Presentation क्लास का एक उदाहरण बनाएँ: PowerPoint या OpenDocument फ़ाइल लोड करें।  
2. आउटपुट लेआउट विकल्प कॉन्फ़िगर करें: नोट्स और कमेंट्स को कैसे प्रदर्शित करना है, इसे निर्दिष्ट करने के लिए [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/notescommentslayoutingoptions/) क्लास का उपयोग करें।  
3. प्रस्तुति को TIFF में सहेजें: कॉन्फ़िगर किए गए विकल्पों को [save](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) मेथड में पास करें।

मान लीजिए हमारे पास एक "speaker_notes.pptx" फ़ाइल है जिसमें निम्नलिखित स्लाइड है:

![स्पीकर नोट्स वाला प्रस्तुति स्लाइड](slide_with_notes.png)

नीचे दिया गया कोड स्निपेट दर्शाता है कि कैसे प्रस्तुति को नोट्स स्लाइड व्यू में TIFF छवि में परिवर्तित किया जाए, इसके लिए [setSlidesLayoutOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) मेथड का उपयोग किया जाता है।

```java
// प्रस्तुत फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास का उदाहरण बनाएं।
Presentation presentation = new Presentation("speaker_notes.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull); // स्लाइड के नीचे नोट्स प्रदर्शित करें।

    // नोट्स लेआउटिंग के साथ TIFF विकल्प कॉन्फ़िगर करें।
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setDpiX(300);
    tiffOptions.setDpiY(300);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // प्रस्तुति को स्पीकर नोट्स के साथ TIFF में सहेजें।
    presentation.save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

परिणाम:

![स्पीकर नोट्स के साथ TIFF छवि](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
Aspose का [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/hi/conversion/convert-ppt-to-poster-online) देखें।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं परिणामस्वरूप TIFF में नोट्स क्षेत्र की स्थिति को नियंत्रित कर सकता हूँ?**

हां। [notes layout settings](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) का उपयोग करके आप `None`, `BottomTruncated`, या `BottomFull` जैसे विकल्पों में से चुन सकते हैं, जो क्रमशः नोट्स को छिपाते हैं, उन्हें एक पृष्ठ में फिट करते हैं, या अतिरिक्त पृष्ठों पर विस्तार करने देते हैं।

**मैं नोट्स के साथ TIFF फ़ाइल का आकार दृश्य गुणवत्ता हानि के बिना कैसे कम कर सकता हूँ?**

एक [efficient compression](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/tiffoptions/#setCompressionType-int-) चुनें (उदा., `LZW` या `RLE`), उचित DPI सेट करें, और यदि स्वीकार्य हो तो कम [pixel format](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/tiffoptions/#setPixelFormat-int-) (जैसे मोनोक्रोम के लिए 8 bpp या 1 bpp) का उपयोग करें। हल्का [image dimensions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-) घटाने से भी बिना उल्लेखनीय पठनीयता हानि के मदद मिल सकती है।

**क्या नोट्स में फ़ॉन्ट का परिणाम पर प्रभाव पड़ता है यदि मूल फ़ॉन्ट सिस्टम में अनुपलब्ध हैं?**

हां। अनुपलब्ध फ़ॉन्ट [substitution](/slides/hi/androidjava/font-selection-sequence/) को ट्रिगर करते हैं, जिससे टेक्स्ट मेट्रिक्स और रूप बदल सकते हैं। इसे रोकने के लिए, आवश्यक फ़ॉन्ट [supply the required fonts](/slides/hi/androidjava/custom-font/) प्रदान करें या डिफॉल्ट [fallback font](/slides/hi/androidjava/fallback-font/) सेट करें ताकि इच्छित टाइपफ़ेसेस उपयोग हों।