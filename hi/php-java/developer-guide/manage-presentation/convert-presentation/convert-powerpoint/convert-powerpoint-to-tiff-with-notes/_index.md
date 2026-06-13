---
title: PHP में नोट्स के साथ PowerPoint प्रस्तुतियों को TIFF में बदलें
linktitle: नोट्स के साथ PowerPoint से TIFF
type: docs
weight: 100
url: /hi/php-java/convert-powerpoint-to-tiff-with-notes/
keywords:
- PowerPoint रूपांतरित करें
- प्रस्तुति रूपांतरित करें
- स्लाइड रूपांतरित करें
- PPT रूपांतरित करें
- PPTX रूपांतरित करें
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
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java का उपयोग करके नोट्स के साथ PowerPoint प्रस्तुतियों को TIFF में बदलें। स्पीकर नोट्स के साथ स्लाइड को कुशलतापूर्वक निर्यात करने का तरीका जानें।"
---
## **परिचय**

Aspose.Slides for PHP via Java PowerPoint और OpenDocument प्रस्तुतियों (PPT, PPTX, और ODP) को नोट्स के साथ TIFF फॉर्मेट में बदलने के लिए एक सरल समाधान प्रदान करता है। यह फॉर्मेट उच्च गुणवत्ता वाली इमेज स्टोरेज, प्रिंटिंग और दस्तावेज़ अभिलेखन के लिए व्यापक रूप से उपयोग होता है। Aspose.Slides के साथ आप न केवल संपूर्ण प्रस्तुतियों को स्पीकर नोट्स के साथ निर्यात कर सकते हैं बल्कि नोट्स स्लाइड दृश्य में स्लाइड थंबनेल भी बना सकते हैं। परिवर्तन प्रक्रिया सरल और कुशल है, जो संपूर्ण प्रस्तुति को नोट्स और लेआउट बनाए रखते हुए कई TIFF छवियों में बदलने के लिए [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास की `save` विधि का उपयोग करती है।

## **नोट्स के साथ प्रस्तुति को TIFF में बदलें**

Aspose.Slides for PHP via Java का उपयोग करके नोट्स के साथ PowerPoint या OpenDocument प्रस्तुति को TIFF में सहेजने के लिए निम्नलिखित चरणों का पालन करना होता है:

1. [Presentation] क्लास का उदाहरण बनाएं: PowerPoint या OpenDocument फ़ाइल लोड करें।  
1. आउटपुट लेआउट विकल्पों को कॉन्फ़िगर करें: नोट्स और कमेंट्स को कैसे प्रदर्शित करना है, इसके लिए [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/notescommentslayoutingoptions/) क्लास का उपयोग करें।  
1. प्रस्तुति को TIFF में सहेजें: कॉन्फ़िगर किए गए विकल्पों को [save](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#save) मेथड में पास करें।

मान लीजिए हमारे पास "speaker_notes.pptx" फ़ाइल है, जिसमें निम्नलिखित स्लाइड है:

![स्पीकर नोट्स वाली प्रस्तुतिकरण स्लाइड](slide_with_notes.png)

नीचे दिया गया कोड स्निपेट दर्शाता है कि कैसे [setSlidesLayoutOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions) मेथड का उपयोग करके प्रस्तुति को नोट्स स्लाइड दृश्य में TIFF छवि में बदल सकते हैं।

```php
// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं।
$presentation = new Presentation("speaker_notes.pptx");
try {
    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomFull); // स्लाइड के नीचे नोट्स प्रदर्शित करें।

    // Notes लेआउट के साथ TIFF विकल्प कॉन्फ़िगर करें।
    $tiffOptions = new TiffOptions();
    $tiffOptions->setDpiX(300);
    $tiffOptions->setDpiY(300);
    $tiffOptions->setSlidesLayoutOptions($notesOptions);

    // स्पीकर नोट्स के साथ प्रस्तुति को TIFF में सहेजें।
    $presentation->save("TIFF_with_notes.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```

परिणाम:

![नोट्स के साथ TIFF छवि](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
Aspose के [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/hi/conversion/convert-ppt-to-poster-online) को देखें।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं परिणामी TIFF में नोट्स क्षेत्र की स्थिति नियंत्रित कर सकता हूँ?**

हां। [notes layout settings](https://reference.aspose.com/slides/hi/php-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions) का उपयोग करके आप `None`, `BottomTruncated`, या `BottomFull` जैसे विकल्पों में से चुन सकते हैं, जो क्रमशः नोट्स को छिपाते हैं, उन्हें एक पृष्ठ में फिट करते हैं, या अतिरिक्त पृष्ठों पर फैलने की अनुमति देते हैं।

**मैं नोट्स के साथ TIFF फ़ाइल का आकार बिना स्पष्ट रूप से गुणवत्ता खोए कैसे कम कर सकता हूँ?**

एक [efficient compression](https://reference.aspose.com/slides/hi/php-java/aspose.slides/tiffoptions/setcompressiontype/) चुनें (जैसे `LZW` या `RTE`), उचित DPI सेट करें, और यदि स्वीकार्य हो तो एक कम [pixel format](https://reference.aspose.com/slides/hi/php-java/aspose.slides/tiffoptions/setpixelformat/) (जैसे मोनोक्रोम के लिए 8 bpp या 1 bpp) का उपयोग करें। थोड़ी सी [image dimensions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/tiffoptions/setimagesize/) को घटाना भी मददगार हो सकता है, बिना पढ़ने की स्पष्टता को प्रभावित किए।

**यदि सिस्टम में मूल फ़ॉन्ट नहीं हैं तो नोट्स में फ़ॉन्ट परिणाम को प्रभावित करता है क्या?**

हां। गायब फ़ॉन्ट [substitution](/slides/hi/php-java/font-selection-sequence/) को ट्रिगर करते हैं, जिससे टेक्स्ट मीट्रिक और दिखावट बदल सकती है। इसे रोकने के लिए, [supply the required fonts](/slides/hi/php-java/custom-font/) करें या डिफ़ॉल्ट [fallback font](/slides/hi/php-java/fallback-font/) सेट करें ताकि इच्छित टाइपफ़ेस उपयोग हों।