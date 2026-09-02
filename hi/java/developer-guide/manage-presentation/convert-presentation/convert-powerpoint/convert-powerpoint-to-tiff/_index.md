---
title: Java में PowerPoint प्रस्तुतियों को TIFF में परिवर्तित करें
titlelink: PowerPoint से TIFF
type: docs
weight: 90
url: /hi/java/convert-powerpoint-to-tiff/
keywords:
- PowerPoint को परिवर्तित करें
- OpenDocument को परिवर्तित करें
- प्रस्तुति को परिवर्तित करें
- स्लाइड को परिवर्तित करें
- PPT को परिवर्तित करें
- PPTX को परिवर्तित करें
- PowerPoint से TIFF
- प्रस्तुति से TIFF
- स्लाइड से TIFF
- PPT से TIFF
- PPTX से TIFF
- PPT को TIFF के रूप में सहेजें
- PPTX को TIFF के रूप में सहेजें
- PPT को TIFF में निर्यात करें
- PPTX को TIFF में निर्यात करें
- Java
- Aspose.Slides
description: "Aspose.Slides for Java का उपयोग करके PowerPoint (PPT, PPTX) प्रस्तुतियों को उच्च गुणवत्ता वाले TIFF चित्रों में आसानी से परिवर्तित करना सीखें, कोड उदाहरणों सहित।"
---
## **परिचय**

TIFF (**Tagged Image File Format**) एक व्यापक रूप से उपयोग किया जाने वाला, लॉसलेस रास्टर इमेज फ़ॉर्मेट है जो अपनी असाधारण गुणवत्ता और ग्राफ़िक्स के विस्तृत संरक्षण के लिए जाना जाता है। डिजाइनर, फ़ोटोग्राफ़र, और डेस्कटॉप प्रकाशक अक्सर TIFF को अपनी छवियों में लेयर्स, रंग की सटीकता और मूल सेटिंग्स को बनाए रखने के लिए चुनते हैं।

Aspose.Slides का उपयोग करके आप अपनी PowerPoint स्लाइड्स (PPT, PPTX) और OpenDocument स्लाइड्स (ODP) को सीधे उच्च‑गुणवत्ता वाले TIFF छवियों में आसानी से परिवर्तित कर सकते हैं, जिससे आपके प्रस्तुतियों में अधिकतम दृश्य विश्वसनीयता बनी रहती है।

## **प्रेज़ेंटेशन को TIFF में परिवर्तित करें**

[save](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#save-java.lang.String-int-) मेथड का उपयोग करके, जो कि [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास द्वारा प्रदान किया गया है, आप जल्दी से पूरी PowerPoint प्रेज़ेंटेशन को TIFF में परिवर्तित कर सकते हैं। परिणामस्वरूप TIFF छवियां डिफ़ॉल्ट स्लाइड आकार के अनुरूप होंगी।

यह कोड दिखाता है कि PowerPoint प्रेज़ेंटेशन को TIFF में कैसे परिवर्तित किया जाए:

```java
import com.aspose.slides.*;

// एक प्रस्तुति फ़ाइल (PPT, PPTX, ODP, आदि) का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं।
Presentation presentation = new Presentation("presentation.pptx");
try {
    //     प्रस्तुति को TIFF के रूप में सहेजें।
    presentation.save("output.tiff", SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **प्रेज़ेंटेशन को ब्लैक‑एंड‑व्हाइट TIFF में परिवर्तित करें**

[TiffOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/tiffoptions/) क्लास में [setBwConversionMode](https://reference.aspose.com/slides/hi/java/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) मेथड आपको रंगीन स्लाइड या छवि को ब्लैक‑एंड‑व्हाइट TIFF में परिवर्तित करने के लिए उपयोग किए जाने वाले एल्गोरिद्म को निर्दिष्ट करने की अनुमति देता है। ध्यान दें कि यह सेटिंग केवल तभी लागू होती है जब [setCompressionType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/tiffoptions/#setCompressionType-int-) मेथड `CCITT4` या `CCITT3` पर सेट हो।

{{% alert color="info" title="Note" %}}

[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/hi/java/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) एक एक्सपोर्ट‑लेवल सेटिंग है जो पूरे TIFF छवि के लिए पिक्सेल‑कन्वर्ज़न एल्गोरिद्म चुनती है। जब ब्लैक‑एंड‑व्हाइट डिस्प्ले मोड सक्रिय हो, तो किसी एकल आकार के दिखने के तरीके को निर्धारित करने के लिए, [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) का उपयोग करें। उदाहरणों के लिए देखें [Control Black-and-White Rendering for Shapes](/java/shape-formatting/#control-black-and-white-rendering-for-shapes)।

{{% /alert %}}

मान लीजिए हमारे पास "sample.pptx" फ़ाइल है जिसमें निम्नलिखित स्लाइड है:

![एक प्रस्तुति स्लाइड](slide_black_and_white.png)

यह कोड दिखाता है कि रंगीन स्लाइड को ब्लैक‑एंड‑व्हाइट TIFF में कैसे परिवर्तित किया जाए:

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

![ब्लैक‑एंड‑व्हाइट TIFF](TIFF_black_and_white.png)

## **कस्टम आकार के साथ प्रेज़ेंटेशन को TIFF में परिवर्तित करें**

यदि आपको विशिष्ट आयामों वाला TIFF चित्र चाहिए, तो आप [TiffOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/tiffoptions/) में उपलब्ध मेथड्स का उपयोग करके वांछित मान सेट कर सकते हैं। उदाहरण के लिए, [setImageSize](https://reference.aspose.com/slides/hi/java/com.aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-) मेथड आपको परिणामी छवि का आकार परिभाषित करने की अनुमति देता है।

यह कोड दिखाता है कि PowerPoint प्रेज़ेंटेशन को कस्टम आकार की TIFF छवियों में कैसे परिवर्तित किया जाए:

```java
import com.aspose.slides.*;
import java.awt.Dimension;

// प्रस्तुति फ़ाइल (PPT, PPTX, ODP, आदि) का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं।
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    // संपीड़न प्रकार सेट करें।
    tiffOptions.setCompressionType(TiffCompressionTypes.Default);
    /*
    संपीड़न प्रकार:
        Default - डिफ़ॉल्ट संपीड़न योजना (LZW) निर्दिष्ट करता है।
        None - कोई संपीड़न नहीं निर्दिष्ट करता।
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // गहराई संपीड़न प्रकार पर निर्भर करती है और मैन्युअली सेट नहीं की जा सकती।

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

## **कस्टम इमेज पिक्सेल फ़ॉर्मेट के साथ प्रेज़ेंटेशन को TIFF में परिवर्तित करें**

[TiffOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/tiffoptions/) क्लास से [setPixelFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/tiffoptions/#setPixelFormat-int-) मेथड का उपयोग करके आप परिणामी TIFF चित्र के लिए अपनी पसंद का पिक्सेल फ़ॉर्मेट निर्दिष्ट कर सकते हैं।

यह कोड दिखाता है कि PowerPoint प्रेज़ेंटेशन को कस्टम पिक्सेल फ़ॉर्मेट वाली TIFF छवि में कैसे परिवर्तित किया जाए:

```java
import com.aspose.slides.*;

// एक प्रस्तुति फ़ाइल (PPT, PPTX, ODP, आदि) का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं।
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    tiffOptions.setPixelFormat(ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat में निम्नलिखित मान होते हैं (प्रलेखन में उल्लेखित अनुसार):
        Format1bppIndexed - प्रति पिक्सेल 1 बिट, अनुक्रमित।
        Format4bppIndexed - प्रति पिक्सेल 4 बिट, अनुक्रमित।
        Format8bppIndexed - प्रति पिक्सेल 8 बिट, अनुक्रमित।
        Format24bppRgb    - प्रति पिक्सेल 24 बिट, RGB।
        Format32bppArgb   - प्रति पिक्सेल 32 बिट, ARGB।
    */
    
    // निर्दिष्ट पिक्सेल फ़ॉर्मेट के साथ प्रस्तुति को TIFF के रूप में सहेजें।
    presentation.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Tip" color="info" %}}

Aspose के [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/hi/conversion/convert-ppt-to-poster-online) को देखें।

{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं पूरी PowerPoint प्रेज़ेंटेशन के बजाय व्यक्तिगत स्लाइड को TIFF में परिवर्तित कर सकता हूँ?**

हाँ। Aspose.Slides आपको PowerPoint और OpenDocument प्रस्तुतियों की व्यक्तिगत स्लाइड्स को अलग‑अलग TIFF छवियों में परिवर्तित करने की अनुमति देता है।

**प्रेज़ेंटेशन को TIFF में परिवर्तित करते समय स्लाइडों की संख्या पर कोई सीमा है क्या?**

नहीं, Aspose.Slides स्लाइडों की संख्या पर कोई प्रतिबंध नहीं लगाता। आप किसी भी आकार की प्रेज़ेंटेशन को TIFF फ़ॉर्मेट में परिवर्तित कर सकते हैं।

**स्लाइड्स को TIFF में परिवर्तित करते समय PowerPoint एनीमेशन और ट्रांज़िशन प्रभाव संरक्षित रहते हैं क्या?**

नहीं, TIFF एक स्थैतिक चित्र फ़ॉर्मेट है। इसलिए एनीमेशन और ट्रांज़िशन प्रभाव संरक्षित नहीं रहते; केवल स्लाइड के स्थिर स्नैपशॉट निर्यात किए जाते हैं।