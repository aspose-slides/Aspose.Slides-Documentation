---
title: Java में नोट्स के साथ PowerPoint प्रस्तुतियों को TIFF में बदलें
linktitle: नोट्स के साथ PowerPoint से TIFF
type: docs
weight: 100
url: /hi/java/convert-powerpoint-to-tiff-with-notes/
keywords:
- PowerPoint को बदलें
- प्रस्तुति को बदलें
- स्लाइड को बदलें
- PPT को बदलें
- PPTX को बदलें
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java का उपयोग करके नोट्स के साथ PowerPoint प्रस्तुतियों को TIFF में बदलें। स्लाइड्स को स्पीकर नोट्स के साथ कुशलतापूर्वक निर्यात करने का तरीका जानें।"
---
## **परिचय**

Aspose.Slides for Java एक सरल समाधान प्रदान करता है जो PowerPoint और OpenDocument प्रस्तुतियों (PPT, PPTX, और ODP) को नोट्स के साथ TIFF प्रारूप में बदलता है। यह प्रारूप उच्च‑गुणवत्ता वाली छवि संग्रह, प्रिंटिंग और दस्तावेज़ अभिलेखन के लिए व्यापक रूप से उपयोग किया जाता है। Aspose.Slides के साथ, आप न केवल पूरे प्रस्तुतियों को स्पीकर नोट्स के साथ निर्यात कर सकते हैं बल्कि नोट्स स्लाइड दृश्य में स्लाइड थंबनेल भी जनरेट कर सकते हैं। रूपांतरण प्रक्रिया सरल और कुशल है, जो पूरी प्रस्तुति को नोट्स और लेआउट को संरक्षित रखते हुए TIFF छवियों की श्रृंखला में बदलने के लिए [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास के `save` मेथड का उपयोग करता है।

## **प्रेजेंटेशन को नोट्स के साथ TIFF में बदलें**

Aspose.Slides for Java का उपयोग करके नोट्स के साथ PowerPoint या OpenDocument प्रेजेंटेशन को TIFF में सेव करने के लिए निम्नलिखित चरणों का पालन किया जाता है:

1. Presentation क्लास का इंस्टेंशिएट करें: PowerPoint या OpenDocument फ़ाइल लोड करें।  
   [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/)
2. आउटपुट लेआउट विकल्प कॉन्फ़िगर करें: नोट्स और कमेंट्स को कैसे प्रदर्शित किया जाए, यह निर्दिष्ट करने के लिए [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/notescommentslayoutingoptions/) क्लास का उपयोग करें।  
3. प्रेजेंटेशन को TIFF में सेव करें: कॉन्फ़िगर किए हुए विकल्पों को [save](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) मेथड में पास करें।

मान लीजिए हमारे पास "speaker_notes.pptx" फ़ाइल है जिसमें निम्नलिखित स्लाइड है:

![स्पीकर नोट्स वाली प्रस्तुति स्लाइड](slide_with_notes.png)

```java
import com.aspose.slides.*;

// Instantiate the Presentation class that represents a presentation file.
Presentation presentation = new Presentation("speaker_notes.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull); // Display the notes below the slide.

    // Configure the TIFF options with Notes layouting.
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setDpiX(300);
    tiffOptions.setDpiY(300);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // Save the presentation to TIFF with the speaker notes.
    presentation.save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

परिणाम:

![स्पीकर नोट्स वाला TIFF इमेज](TIFF_with_notes.png)

{{% alert title="Tip" color="info" %}}
Aspose के [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/hi/conversion/convert-ppt-to-poster-online) को देखें।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

### क्या मैं उत्पन्न TIFF में नोट्स क्षेत्र की स्थिति नियंत्रित कर सकता हूँ?

हाँ। परिणामस्वरूप TIFF में नोट्स की स्थिति चुनने के लिए आप [notes layout settings](https://reference.aspose.com/slides/hi/java/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) का उपयोग कर सकते हैं, जहाँ आप `None`, `BottomTruncated`, या `BottomFull` जैसे विकल्प चुन सकते हैं, जो क्रमशः नोट्स को छुपाते हैं, एक ही पृष्ठ में फिट करते हैं, या अतिरिक्त पृष्ठों पर फैलने की अनुमति देते हैं।

### कैसे मैं नोट्स वाले TIFF फ़ाइल का आकार गुणवत्ता में दृश्यात्मक नुकसान के बिना घटा सकता हूँ?

एक [efficient compression](https://reference.aspose.com/slides/hi/java/com.aspose.slides/tiffoptions/#setCompressionType-int-) चुनें (जैसे `LZW` या `RLE`), उचित DPI सेट करें, और यदि स्वीकार्य हो तो एक निम्न [pixel format](https://reference.aspose.com/slides/hi/java/com.aspose.slides/tiffoptions/#setPixelFormat-int-) (जैसे मोनोक्रोम के लिए 8 bpp या 1 bpp) का उपयोग करें। थोड़ी सी [image dimensions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-) कम करना भी मददगार हो सकता है, बिना पठनीयता पर स्पष्ट प्रभाव डाले।

### यदि सिस्टम में मूल फ़ॉन्ट उपलब्ध नहीं हैं तो नोट्स में फ़ॉन्ट परिणाम को प्रभावित करता है क्या?

हाँ। यदि सिस्टम में मूल फ़ॉन्ट उपलब्ध नहीं हैं तो गुम फ़ॉन्ट्स [substitution](/slides/hi/java/font-selection-sequence/) को ट्रिगर करते हैं, जिससे टेक्स्ट मेट्रिक्स और स्वरूप बदल सकता है। इसे रोकने के लिए, [आवश्यक फ़ॉन्ट्स प्रदान करें](/slides/hi/java/custom-font/) या एक डिफ़ॉल्ट [fallback font](/slides/hi/java/fallback-font/) सेट करें ताकि इच्छित टाइपफ़ेस उपयोग हों।