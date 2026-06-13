---
title: Java में PowerPoint प्रस्तुतियों को TIFF में परिवर्तित करें
titlelink: PowerPoint से TIFF
type: docs
weight: 90
url: /hi/java/convert-powerpoint-to-tiff/
keywords:
- PowerPoint परिवर्तित करें
- OpenDocument परिवर्तित करें
- प्रेज़ेंटेशन परिवर्तित करें
- स्लाइड परिवर्तित करें
- PPT परिवर्तित करें
- PPTX परिवर्तित करें
- PowerPoint से TIFF
- प्रेज़ेंटेशन से TIFF
- स्लाइड से TIFF
- PPT से TIFF
- PPTX से TIFF
- PPT को TIFF के रूप में सहेजें
- PPTX को TIFF के रूप में सहेजें
- PPT को TIFF में निर्यात करें
- PPTX को TIFF में निर्यात करें
- जावा
- Aspose.Slides
description: "Aspose.Slides for Java का उपयोग करके PowerPoint (PPT, PPTX) प्रस्तुतियों को उच्च-गुणवत्ता वाले TIFF चित्रों में आसानी से कैसे परिवर्तित करें, कोड उदाहरणों सहित सीखें।"
---
## **परिचय**

TIFF (**Tagged Image File Format**) एक व्यापक रूप से उपयोग किया जाने वाला, लॉसलेस रास्टर इमेज फ़ॉर्मेट है जो अपनी असाधारण गुणवत्ता और ग्राफिक्स के विस्तृत संरक्षण के लिए जाना जाता है। डिजाइनर, फ़ोटोग्राफ़र, और डेस्कटॉप प्रकाशक अक्सर TIFF का चयन अपने चित्रों में लेयर, रंग सटीकता और मूल सेटिंग्स को बनाए रखने के लिए करते हैं।

Aspose.Slides का उपयोग करके, आप अपने PowerPoint स्लाइड्स (PPT, PPTX) और OpenDocument स्लाइड्स (ODP) को सीधे उच्च-गुणवत्ता वाले TIFF छवियों में आसानी से परिवर्तित कर सकते हैं, जिससे आपकी प्रस्तुतियां अधिकतम दृश्य सटीकता बनाए रखें।

## **प्रेज़ेंटेशन को TIFF में परिवर्तित करें**

[Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास द्वारा प्रदान किए गए [save](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#save-java.lang.String-int-) मेथड का उपयोग करके, आप एक पूरी PowerPoint प्रेज़ेंटेशन को जल्दी से TIFF में परिवर्तित कर सकते हैं। परिणामस्वरूप TIFF छवियां डिफ़ॉल्ट स्लाइड आकार के अनुरूप होती हैं।

यह कोड दिखाता है कि PowerPoint प्रेज़ेंटेशन को TIFF में कैसे परिवर्तित किया जाए:

```java
// प्रेज़ेंटेशन फ़ाइल (PPT, PPTX, ODP आदि) को दर्शाने वाली Presentation क्लास का इंस्टेंस बनाएँ।
Presentation presentation = new Presentation("presentation.pptx");
try {
    // प्रेज़ेंटेशन को TIFF के रूप में सहेजें।
    presentation.save("output.tiff", SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **प्रेज़ेंटेशन को ब्लैक-एंड-व्हाइट TIFF में परिवर्तित करें**

[TiffOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/tiffoptions/) क्लास में मौजूद [setBwConversionMode](https://reference.aspose.com/slides/hi/java/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) मेथड आपको रंगीन स्लाइड या छवि को ब्लैक-एंड-व्हाइट TIFF में परिवर्तित करने के दौरान उपयोग किए जाने वाले एल्गोरिद्म को निर्दिष्ट करने की अनुमति देता है। ध्यान दें कि यह सेटिंग केवल तभी लागू होती है जब [setCompressionType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/tiffoptions/#setCompressionType-int-) मेथड `CCITT4` या `CCITT3` पर सेट हो।

मान लीजिए हमारे पास "sample.pptx" फ़ाइल है जिसमें निम्नलिखित स्लाइड है:

![एक प्रेज़ेंटेशन स्लाइड](slide_black_and_white.png)

यह कोड दिखाता है कि रंगीन स्लाइड को ब्लैक-एंड-व्हाइट TIFF में कैसे परिवर्तित किया जाए:

```java
TiffOptions tiffOptions = new TiffOptions();
tiffOptions.setCompressionType(TiffCompressionTypes.CCITT4);
tiffOptions.setBwConversionMode(BlackWhiteConversionMode.Dithering);

Presentation presentation = new Presentation("sample.pptx");
try {
    presentation.save("output.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

परिणाम:

![ब्लैक-एंड-व्हाइट TIFF](TIFF_black_and_white.png)

## **प्रेज़ेंटेशन को कस्टम साइज के साथ TIFF में परिवर्तित करें**

यदि आपको विशिष्ट आयामों के साथ TIFF छवि चाहिए, तो आप [TiffOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/tiffoptions/) में उपलब्ध मेथड्स का उपयोग करके अपनी इच्छित मान सेट कर सकते हैं। उदाहरण के तौर पर, [setImageSize](https://reference.aspose.com/slides/hi/java/com.aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-) मेथड आपको परिणामस्वरूप छवि का आकार निर्धारित करने की अनुमति देता है।

यह कोड दिखाता है कि PowerPoint प्रेज़ेंटेशन को कस्टम साइज के साथ TIFF छवियों में कैसे परिवर्तित किया जाए:

```java
// उस Presentation क्लास का इंस्टेंस बनाएं जो एक प्रस्तुतिकरण फ़ाइल (PPT, PPTX, ODP आदि) का प्रतिनिधित्व करता है।
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    // संपीड़न प्रकार सेट करें।
    tiffOptions.setCompressionType(TiffCompressionTypes.Default);
    /*
    संपीड़न प्रकार:
        Default - डिफ़ॉल्ट संपीड़न स्कीम (LZW) को निर्दिष्ट करता है।
        None - कोई संपीड़न नहीं दर्शाता।
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // गहराई संपीड़न प्रकार पर निर्भर करती है और इसे मैनुअल रूप से सेट नहीं किया जा सकता।

    // इमेज DPI सेट करें।
    tiffOptions.setDpiX(200);
    tiffOptions.setDpiY(200);

    // इमेज साइज सेट करें।
    tiffOptions.setImageSize(new Dimension(1728, 1078));

    INotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // निर्दिष्ट साइज के साथ प्रेज़ेंटेशन को TIFF के रूप में सहेजें।
    presentation.save("tiff-ImageSize.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

## **प्रेज़ेंटेशन को कस्टम इमेज पिक्सेल फॉर्मेट के साथ TIFF में परिवर्तित करें**

[TiffOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/tiffoptions/) क्लास से [setPixelFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/tiffoptions/#setPixelFormat-int-) मेथड का उपयोग करके, आप परिणामस्वरूप TIFF छवि के लिए अपनी पसंदीदा पिक्सेल फॉर्मेट निर्दिष्ट कर सकते हैं।

यह कोड दिखाता है कि PowerPoint प्रेज़ेंटेशन को कस्टम पिक्सेल फॉर्मेट के साथ TIFF छवि में कैसे परिवर्तित किया जाए:

```java
// वह Presentation क्लास का इंस्टेंस बनाएं जो एक प्रेज़ेंटेशन फ़ाइल (PPT, PPTX, ODP आदि) का प्रतिनिधित्व करता है।
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    tiffOptions.setPixelFormat(ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat में निम्नलिखित मान होते हैं (दस्तावेज़ में जैसा बताया गया है):
        Format1bppIndexed - प्रति पिक्सेल 1 बिट, अनुक्रमित।
        Format4bppIndexed - प्रति पिक्सेल 4 बिट, अनुक्रमित।
        Format8bppIndexed - प्रति पिक्सेल 8 बिट, अनुक्रमित।
        Format24bppRgb    - प्रति पिक्सेल 24 बिट, RGB।
        Format32bppArgb   - प्रति पिक्सेल 32 बिट, ARGB।
    */
    
    // निर्दिष्ट इमेज साइज के साथ प्रेज़ेंटेशन को TIFF के रूप में सहेजें।
    presentation.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Tip" color="primary" %}}
Aspose के [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/hi/conversion/convert-ppt-to-poster-online) को देखें।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं पूरे PowerPoint प्रेज़ेंटेशन के बजाय व्यक्तिगत स्लाइड को TIFF में बदल सकता हूँ?**

हाँ। Aspose.Slides आपको PowerPoint और OpenDocument प्रेज़ेंटेशन से व्यक्तिगत स्लाइड्स को अलग‑अलग TIFF छवियों में बदलने की अनुमति देता है।

**प्रेज़ेंटेशन को TIFF में बदलते समय स्लाइडों की संख्या पर कोई सीमा है क्या?**

नहीं, Aspose.Slides स्लाइडों की संख्या पर कोई प्रतिबंध नहीं लगाता। आप किसी भी आकार के प्रेज़ेंटेशन को TIFF फ़ॉर्मेट में बदल सकते हैं।

**क्या स्लाइड्स को TIFF में बदलते समय PowerPoint एनीमेशन और ट्रांज़िशन इफ़ेक्ट्स संरक्षित रहते हैं?**

नहीं, TIFF एक स्थैतिक छवि फ़ॉर्मेट है। इसलिए, एनीमेशन और ट्रांज़िशन इफ़ेक्ट्स संरक्षित नहीं होते; केवल स्लाइड के स्थिर स्नैपशॉट निर्यात किए जाते हैं।