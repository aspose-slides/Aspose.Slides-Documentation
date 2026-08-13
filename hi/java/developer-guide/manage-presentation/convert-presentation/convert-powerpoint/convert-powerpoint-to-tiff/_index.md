---
title: जावा में PowerPoint प्रेजेंटेशन को TIFF में बदलें
titlelink: PowerPoint को TIFF
type: docs
weight: 90
url: /hi/java/convert-powerpoint-to-tiff/
keywords:
- PowerPoint बदलें
- OpenDocument बदलें
- प्रेजेंटेशन बदलें
- स्लाइड बदलें
- PPT बदलें
- PPTX बदलें
- PowerPoint से TIFF
- प्रेजेंटेशन से TIFF
- स्लाइड से TIFF
- PPT से TIFF
- PPTX से TIFF
- PPT को TIFF के रूप में सहेजें
- PPTX को TIFF के रूप में सहेजें
- PPT को TIFF में निर्यात करें
- PPTX को TIFF में निर्यात करें
- Java
- Aspose.Slides
description: "जावा के लिए Aspose.Slides का उपयोग करके PowerPoint (PPT, PPTX) प्रेजेंटेशन को उच्च गुणवत्ता वाले TIFF छवियों में आसानी से बदलना सीखें, कोड उदाहरणों के साथ।"
---
## **परिचय**

TIFF (**Tagged Image File Format**) एक व्यापक रूप से प्रयुक्त, लॉसलेस रास्टर इमेज फ़ॉर्मेट है जो अपनी असाधारण गुणवत्ता और ग्राफ़िक्स के विस्तृत संरक्षण के लिए जाना जाता है। डिज़ाइनर, फ़ोटोग्राफ़र, और डेस्कटॉप पब्लिशर अक्सर अपने चित्रों में लेयर्स, रंग शुद्धता, और मूल सेटिंग्स को बनाए रखने के लिए TIFF को चुनते हैं।

Aspose.Slides का उपयोग करके, आप अपने PowerPoint स्लाइड्स (PPT, PPTX) और OpenDocument स्लाइड्स (ODP) को सीधे हाई‑क्वालिटी TIFF छवियों में आसानी से बदल सकते हैं, जिससे आपके प्रेजेंटेशन अधिकतम दृश्य समानता बनाए रखते हैं।

## **प्रेजेंटेशन को TIFF में परिवर्तित करें**

[save](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#save-java.lang.String-int-) मेथड का उपयोग करके, जो कि [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास द्वारा प्रदान किया गया है, आप पूरी PowerPoint प्रेजेंटेशन को तुरंत TIFF में बदल सकते हैं। उत्पन्न TIFF छवियां डिफ़ॉल्ट स्लाइड आकार के अनुरूप होती हैं।

यह कोड दर्शाता है कि PowerPoint प्रेजेंटेशन को TIFF में कैसे बदलें:

```java
import com.aspose.slides.*;

// Presentation क्लास को इंस्‍टैंशिएट करें जो एक प्रेजेंटेशन फ़ाइल (PPT, PPTX, ODP, आदि) का प्रतिनिधित्व करता है।
Presentation presentation = new Presentation("presentation.pptx");
try {
    // प्रेजेंटेशन को TIFF के रूप में सहेजें।
    presentation.save("output.tiff", SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **प्रेजेंटेशन को ब्लैक-एंड-व्हाइट TIFF में परिवर्तित करें**

[TiffOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/tiffoptions/) क्लास में मौजूद [setBwConversionMode](https://reference.aspose.com/slides/hi/java/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) मेथड आपको रंगीन स्लाइड या छवि को ब्लैक‑एंड‑व्हाइट TIFF में बदलने के दौरान उपयोग किए जाने वाले एल्गोरिद्म को निर्दिष्ट करने की अनुमति देता है। ध्यान दें कि यह सेटिंग तभी लागू होती है जब [setCompressionType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/tiffoptions/#setCompressionType-int-) मेथड को `CCITT4` या `CCITT3` पर सेट किया गया हो।

मान लीजिए हमारे पास "sample.pptx" फ़ाइल है जिसमें निम्नलिखित स्लाइड है:

![एक प्रेजेंटेशन स्लाइड](slide_black_and_white.png)

यह कोड दर्शाता है कि रंगीन स्लाइड को ब्लैक‑एंड‑व्हाइट TIFF में कैसे बदलें:

```java
import com.aspose.slides.*;

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

## **कस्टम आकार के साथ TIFF में प्रेजेंटेशन को परिवर्तित करें**

यदि आपको विशिष्ट आयामों वाली TIFF छवि चाहिए, तो आप [TiffOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/tiffoptions/) में उपलब्ध मेथड्स का उपयोग करके वांछित मान सेट कर सकते हैं। उदाहरण के लिए, [setImageSize](https://reference.aspose.com/slides/hi/java/com.aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-) मेथड आपको परिणामी छवि का आकार निर्धारित करने की अनुमति देता है।

यह कोड दर्शाता है कि PowerPoint प्रेजेंटेशन को कस्टम आकार वाली TIFF छवियों में कैसे बदलें:

```java
import com.aspose.slides.*;
import java.awt.Dimension;

// प्रस्तुति फ़ाइल (PPT, PPTX, ODP, आदि) को दर्शाने वाले Presentation क्लास को इंस्टैंशिएट करें।
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    // कम्प्रेशन प्रकार सेट करें।
    tiffOptions.setCompressionType(TiffCompressionTypes.Default);
    /*
    कम्प्रेशन प्रकार:
        Default - डिफ़ॉल्ट कम्प्रेशन योजना (LZW) निर्दिष्ट करता है।
        None - कोई कम्प्रेशन नहीं निर्दिष्ट करता।
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // गहराई कम्प्रेशन प्रकार पर निर्भर करती है और इसे मैन्युअल रूप से सेट नहीं किया जा सकता।

    // छवि DPI सेट करें।
    tiffOptions.setDpiX(200);
    tiffOptions.setDpiY(200);

    // छवि आकार सेट करें।
    tiffOptions.setImageSize(new Dimension(1728, 1078));

    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // निर्दिष्ट आकार के साथ प्रस्तुति को TIFF के रूप में सहेजें।
    presentation.save("tiff-ImageSize.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

## **कस्टम इमेज पिक्सेल फॉर्मेट के साथ TIFF में प्रेजेंटेशन को परिवर्तित करें**

[TiffOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/tiffoptions/) क्लास के [setPixelFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/tiffoptions/#setPixelFormat-int-) मेथड का उपयोग करके आप परिणामी TIFF छवि के लिए अपना इच्छित पिक्सेल फॉर्मेट निर्दिष्ट कर सकते हैं।

यह कोड दर्शाता है कि PowerPoint प्रेजेंटेशन को कस्टम पिक्सेल फॉर्मेट वाली TIFF छवि में कैसे बदलें:

```java
import com.aspose.slides.*;

// Presentation क्लास को इंस्टैंशिएट करें जो एक प्रस्तुति फ़ाइल (PPT, PPTX, ODP, आदि) का प्रतिनिधित्व करता है।
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    tiffOptions.setPixelFormat(ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat में निम्नलिखित मान होते हैं (दस्तावेज़ में जैसा बताया गया है):
        Format1bppIndexed - 1 बिट प्रति पिक्सेल, सूचकांकित।
        Format4bppIndexed - 4 बिट प्रति पिक्सेल, सूचकांकित।
        Format8bppIndexed - 8 बिट प्रति पिक्सेल, सूचकांकित।
        Format24bppRgb    - 24 बिट प्रति पिक्सेल, RGB।
        Format32bppArgb   - 32 बिट प्रति पिक्सेल, ARGB।
    */
    
    // प्रेजेंटेशन को निर्दिष्ट पिक्सेल फॉर्मेट के साथ TIFF के रूप में सहेजें।
    presentation.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Tip" color="info" %}}
Aspose के [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/hi/conversion/convert-ppt-to-poster-online) को देखें।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

### क्या मैं पूरी PowerPoint प्रेजेंटेशन के बजाय एक व्यक्तिगत स्लाइड को TIFF में बदल सकता हूँ?

हाँ। Aspose.Slides आपको PowerPoint और OpenDocument प्रेजेंटेशन की व्यक्तिगत स्लाइडों को अलग‑अलग TIFF छवियों में बदलने की अनुमति देता है।

### प्रेजेंटेशन को TIFF में बदलते समय स्लाइडों की संख्या पर कोई सीमा है क्या?

नहीं, Aspose.Slides स्लाइडों की संख्या पर कोई प्रतिबंध नहीं लगाता। आप किसी भी आकार की प्रेजेंटेशन को TIFF फ़ॉर्मेट में बदल सकते हैं।

### क्या स्लाइडों को TIFF में बदलने पर PowerPoint एनीमेशन और ट्रांज़िशन इफ़ेक्ट्स संरक्षित रहते हैं?

नहीं, TIFF एक स्थैतिक इमेज फ़ॉर्मेट है। इसलिए एनीमेशन और ट्रांज़िशन इफ़ेक्ट्स संरक्षित नहीं रहते; केवल स्लाइडों के स्थायी स्नैपशॉट निर्यात किए जाते हैं।