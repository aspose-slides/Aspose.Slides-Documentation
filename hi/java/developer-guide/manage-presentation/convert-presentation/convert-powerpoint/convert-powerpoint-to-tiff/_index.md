---
title: Java में PowerPoint प्रस्तुतियों को TIFF में बदलें
titlelink: PowerPoint से TIFF
type: docs
weight: 90
url: /hi/java/convert-powerpoint-to-tiff/
keywords:
- PowerPoint को बदलें
- OpenDocument को बदलें
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java का उपयोग करके PowerPoint (PPT, PPTX) प्रस्तुतियों को उच्च गुणवत्ता वाले TIFF चित्रों में आसानी से बदलना सीखें, साथ में कोड उदाहरण।"
---
## **परिचय**

TIFF (**Tagged Image File Format**) एक व्यापक रूप से उपयोग किया जाने वाला, लॉसलैस रास्टर इमेज फॉर्मेट है जो अपनी अत्युत्तम गुणवत्ता और ग्राफिक्स के विस्तृत संरक्षण के लिए जाना जाता है। डिजाइनर, फोटोग्राफर, और डेस्कटॉप पब्लिशर अक्सर TIFF को लेयर्स, रंग की शुद्धता, और अपनी इमेज में मूल सेटिंग्स को बनाए रखने के लिए चुनते हैं।

Aspose.Slides का उपयोग करके आप अपने PowerPoint स्लाइड्स (PPT, PPTX) और OpenDocument स्लाइड्स (ODP) को सीधे उच्च‑गुणवत्ता वाले TIFF इमेज में आसानी से बदल सकते हैं, जिससे आपके प्रस्तुतियों में अधिकतम दृश्य सत्यता बनी रहती है।

## **प्रेजेंटेशन को TIFF में बदलें**

आप [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास द्वारा प्रदान किए गए [save](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#save-java.lang.String-int-) मेथड का उपयोग करके पूरी PowerPoint प्रेजेंटेशन को जल्दी से TIFF में बदल सकते हैं। परिणामी TIFF इमेज डिफ़ॉल्ट स्लाइड आकार के अनुरूप होती हैं।

यह कोड दर्शाता है कि कैसे PowerPoint प्रेजेंटेशन को TIFF में बदला जा सकता है:

```java
import com.aspose.slides.*;

// Presentation क्लास का उदाहरण बनाएं जो एक प्रस्तुति फ़ाइल (PPT, PPTX, ODP, आदि) का प्रतिनिधित्व करती है।
Presentation presentation = new Presentation("presentation.pptx");
try {
    // प्रस्तुति को TIFF के रूप में सहेजें।
    presentation.save("output.tiff", SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **प्रेजेंटेशन को ब्लैक‑एंड‑व्हाइट TIFF में बदलें**

क्लास [TiffOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/tiffoptions/) में मेथड [setBwConversionMode](https://reference.aspose.com/slides/hi/java/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) आपको यह निर्दिष्ट करने की अनुमति देता है कि रंगीन स्लाइड या इमेज को ब्लैक‑एंड‑व्हाइट TIFF में बदलते समय कौन सा एल्गोरिद्म उपयोग किया जाएगा। ध्यान दें कि यह सेटिंग केवल तभी लागू होती है जब [setCompressionType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/tiffoptions/#setCompressionType-int-) मेथड `CCITT4` या `CCITT3` पर सेट हो।

{{% alert color="info" title="Note" %}}
[TiffOptions.setBwConversionMode]... एक एक्सपोर्ट‑लेवल सेटिंग है जो पूरे TIFF इमेज के लिए पिक्सेल‑कन्वर्ज़न एल्गोरिद्म चुनती है। यह निर्धारित करने के लिए कि एक व्यक्तिगत शैप ब्लैक‑एंड‑व्हाइट डिस्प्ले मोड सक्रिय होने पर कैसे दिखेगा, आप [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) का उपयोग करें। उदाहरणों के लिए देखें [Control Black-and-White Rendering for Shapes](/slides/hi/java/shape-formatting/#control-black-and-white-rendering-for-shapes)।
{{% /alert %}}

मान लीजिए हमारे पास एक "sample.pptx" फ़ाइल है जिसमें निम्नलिखित स्लाइड है:

![एक प्रेजेंटेशन स्लाइड](slide_black_and_white.png)

यह कोड दर्शाता है कि कैसे रंगीन स्लाइड को ब्लैक‑एंड‑व्हाइट TIFF में बदला जाए:

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

## **प्रेजेंटेशन को कस्टम साइज के साथ TIFF में बदलें**

यदि आपको विशिष्ट आयामों वाला TIFF इमेज चाहिए, तो आप [TiffOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/tiffoptions/) में उपलब्ध मेथड्स का उपयोग करके इच्छित मान सेट कर सकते हैं। उदाहरण के लिए, मेथड [setImageSize](https://reference.aspose.com/slides/hi/java/com.aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-) आपको परिणामी इमेज का आकार निर्धारित करने की अनुमति देती है।

यह कोड दर्शाता है कि कैसे PowerPoint प्रेजेंटेशन को कस्टम साइज वाले TIFF इमेज में बदला जाए:

```java
import com.aspose.slides.*;
import java.awt.Dimension;

// Presentation क्लास का उदाहरण बनाते हैं जो एक प्रस्तुति फ़ाइल (PPT, PPTX, ODP, आदि) का प्रतिनिधित्व करता है।
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    // कंप्रेशन प्रकार सेट करें।
    tiffOptions.setCompressionType(TiffCompressionTypes.Default);
    /*
    कंप्रेशन प्रकार:
        Default - डिफ़ॉल्ट कंप्रेशन स्कीम (LZW) निर्दिष्ट करता है।
        None - कोई कंप्रेशन नहीं निर्दिष्ट करता है।
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // गहराई कंप्रेशन प्रकार पर निर्भर करती है और मैन्युअल रूप से सेट नहीं की जा सकती।

    // इमेज DPI सेट करें।
    tiffOptions.setDpiX(200);
    tiffOptions.setDpiY(200);

    // इमेज आकार सेट करें।
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

## **कस्टम इमेज पिक्सेल फ़ॉर्मेट के साथ प्रेजेंटेशन को TIFF में बदलें**

[TiffOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/tiffoptions/) क्लास की [setPixelFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/tiffoptions/#setPixelFormat-int-) मेथड का उपयोग करके आप परिणामस्वरूप TIFF इमेज के लिए अपना पसंदीदा पिक्सेल फ़ॉर्मेट निर्दिष्ट कर सकते हैं।

यह कोड दर्शाता है कि कैसे PowerPoint प्रेजेंटेशन को कस्टम पिक्सेल फ़ॉर्मेट वाले TIFF इमेज में बदला जाए:

```java
import com.aspose.slides.*;

// Presentation क्लास का उदाहरण बनाते हैं जो एक प्रस्तुति फ़ाइल (PPT, PPTX, ODP, आदि) का प्रतिनिधित्व करता है।
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    tiffOptions.setPixelFormat(ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat में निम्नलिखित मान होते हैं (दस्तावेज़ में बताए अनुसार):
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

**क्या मैं पूरी PowerPoint प्रेजेंटेशन की बजाय व्यक्तिगत स्लाइड को TIFF में बदल सकता हूँ?**  
हाँ। Aspose.Slides आपको PowerPoint और OpenDocument प्रस्तुतियों से व्यक्तिगत स्लाइड को अलग‑अलग TIFF इमेज में बदलने की सुविधा देता है।

**क्या प्रेजेंटेशन को TIFF में बदलते समय स्लाइडों की संख्या पर कोई सीमा है?**  
नहीं, Aspose.Slides स्लाइडों की संख्या पर कोई प्रतिबंध नहीं लगाता। आप किसी भी आकार की प्रस्तुतियों को TIFF फ़ॉर्मेट में बदल सकते हैं।

**क्या PowerPoint एनिमेशन और ट्रांज़िशन इफ़ेक्ट्स स्लाइडों को TIFF में बदलने पर संरक्षित रहते हैं?**  
नहीं, TIFF एक स्थिर इमेज फ़ॉर्मेट है। इसलिए, एनिमेशन और ट्रांज़िशन इफ़ेक्ट्स संरक्षित नहीं रहेंगे; केवल स्लाइडों के स्थिर स्नैपशॉट निर्यात किए जाएंगे।