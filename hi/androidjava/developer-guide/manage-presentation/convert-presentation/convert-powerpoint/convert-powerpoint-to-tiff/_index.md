---
title: Android पर PowerPoint प्रस्तुतियों को TIFF में बदलें
titlelink: PowerPoint से TIFF
type: docs
weight: 90
url: /hi/androidjava/convert-powerpoint-to-tiff/
keywords:
- PowerPoint रूपांतरण
- OpenDocument रूपांतरण
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android का उपयोग करके जावा कोड उदाहरणों के साथ PowerPoint (PPT, PPTX) प्रस्तुतियों को उच्च-गुणवत्ता वाले TIFF इमेज में आसानी से कैसे बदलें, सीखें।"
---
## **परिचय**

TIFF (**Tagged Image File Format**) एक व्यापक रूप से उपयोग किया जाने वाला, लॉसलेस रास्टर इमेज फ़ॉर्मेट है जो अपनी असाधारण गुणवत्ता और ग्राफिक्स के विस्तृत संरक्षण के लिए जाना जाता है। डिज़ाइनर, फ़ोटोग्राफ़र, और डेस्कटॉप प्रकाशक अक्सर TIFF को अपनी छवियों में लेयर्स, रंग की शुद्धता, और मूल सेटिंग्स बनाए रखने के लिए चुनते हैं।

Aspose.Slides का उपयोग करके, आप अपने PowerPoint स्लाइड्स (PPT, PPTX) और OpenDocument स्लाइड्स (ODP) को सीधे उच्च-गुणवत्ता वाले TIFF इमेज में बिना किसी प्रयास के परिवर्तित कर सकते हैं, जिससे आपका प्रेज़ेंटेशन अधिकतम विज़ुअल फिडेलिटी बनाए रखता है।

## **प्रेज़ेंटेशन को TIFF में परिवर्तित करें**

आप [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास द्वारा प्रदान किए गए [save](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) मेथड का उपयोग करके जल्दी से पूरे PowerPoint प्रेज़ेंटेशन को TIFF में परिवर्तित कर सकते हैं। उत्पन्न हुए TIFF इमेज डिफ़ॉल्ट स्लाइड आकार के अनुरूप होते हैं।

```java
import com.aspose.slides.*;

// प्रेज़ेंटेशन फ़ाइल (PPT, PPTX, ODP, आदि) को दर्शाने वाले Presentation क्लास का एक उदाहरण बनाएं।
Presentation presentation = new Presentation("presentation.pptx");
try {
    // प्रेज़ेंटेशन को TIFF के रूप में सहेजें।
    presentation.save("output.tiff", SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **प्रेज़ेंटेशन को ब्लैक-एंड-व्हाइट TIFF में परिवर्तित करें**

[TiffOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/tiffoptions/) क्लास में मौजूद मेथड [setBwConversionMode](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) आपको रंगीन स्लाइड या इमेज को ब्लैक-एंड-व्हाइट TIFF में परिवर्तित करते समय उपयोग किए जाने वाले एल्गोरिद्म को निर्दिष्ट करने की अनुमति देता है। ध्यान दें कि यह सेटिंग केवल तभी लागू होती है जब [setCompressionType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/tiffoptions/#setCompressionType-int-) मेथड `CCITT4` या `CCITT3` पर सेट हो।

{{% alert color="info" title="Note" %}}
[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) एक निर्यात-स्तर की सेटिंग है जो संपूर्ण TIFF इमेज के लिए पिक्सेल-रूपांतरण एल्गोरिद्म चुनती है। जब ब्लैक-एंड-व्हाइट डिस्प्ले मोड सक्रिय हो, तो यह निर्धारित करने के लिए कि व्यक्तिगत शेप कैसे दिखेगा, आप [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) का उपयोग करें। उदाहरणों के लिए देखें [Control Black-and-White Rendering for Shapes](/slides/hi/androidjava/shape-formatting/#control-black-and-white-rendering-for-shapes)।
{{% /alert %}}

मान लीजिए हमारे पास "sample.pptx" फ़ाइल है जिसमें निम्नलिखित स्लाइड है:

![एक प्रेज़ेंटेशन स्लाइड](slide_black_and_white.png)

यह कोड दिखाता है कि रंगीन स्लाइड को ब्लैक-एंड-व्हाइट TIFF में कैसे परिवर्तित किया जाए:

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

## **कस्टम आकार के साथ प्रेज़ेंटेशन को TIFF में परिवर्तित करें**

यदि आपको विशिष्ट आयामों वाला TIFF इमेज चाहिए, तो आप [TiffOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/tiffoptions/) में उपलब्ध मेथड्स का उपयोग करके अपनी इच्छित मान सेट कर सकते हैं। उदाहरण के लिए, मेथड [setImageSize](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/tiffoptions/#setImageSize-com.aspose.slides.android.Size-) आपको उत्पन्न इमेज का आकार निर्धारित करने की अनुमति देता है।

```java
import com.aspose.slides.*;
import com.aspose.slides.android.Size;

// एक Presentation क्लास का उदाहरण बनाएं जो एक प्रेज़ेंटेशन फ़ाइल (PPT, PPTX, ODP, आदि) को दर्शाता है।
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    // कम्प्रेशन प्रकार सेट करें।
    tiffOptions.setCompressionType(TiffCompressionTypes.Default);
    /*
    कम्प्रेशन प्रकार:
        Default - डिफ़ॉल्ट कम्प्रेशन योजना (LZW) को निर्दिष्ट करता है।
        None - कोई कम्प्रेशन नहीं होने को निर्दिष्ट करता है।
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // गहराई कम्प्रेशन प्रकार पर निर्भर करती है और इसे मैन्युअल रूप से सेट नहीं किया जा सकता।

    // इमेज DPI सेट करें।
    tiffOptions.setDpiX(200);
    tiffOptions.setDpiY(200);

    // इमेज आकार सेट करें।
    tiffOptions.setImageSize(new Size(1728, 1078));

    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // निर्दिष्ट आकार के साथ प्रेज़ेंटेशन को TIFF के रूप में सहेजें।
    presentation.save("tiff-ImageSize.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}   
```

## **कस्टम इमेज पिक्सेल फॉर्मेट के साथ प्रेज़ेंटेशन को TIFF में परिवर्तित करें**

[TiffOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/tiffoptions/) क्लास के [setPixelFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/tiffoptions/#setPixelFormat-int-) मेथड का उपयोग करके आप उत्पन्न TIFF इमेज के लिए अपनी पसंदीदा पिक्सेल फॉर्मेट निर्दिष्ट कर सकते हैं।

यह कोड दर्शाता है कि PowerPoint प्रेज़ेंटेशन को कस्टम पिक्सेल फॉर्मेट वाले TIFF इमेज में कैसे परिवर्तित किया जाए:

```java
import com.aspose.slides.*;

// एक Presentation क्लास का उदाहरण बनाएं जो एक प्रेज़ेंटेशन फ़ाइल (PPT, PPTX, ODP, आदि) को दर्शाता है।
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    tiffOptions.setPixelFormat(ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat में निम्नलिखित मान होते हैं (दस्तावेज़ीकरण में उल्लेखित अनुसार):
        Format1bppIndexed - 1 बिट प्रति पिक्सेल, इंडेक्स्ड.
        Format4bppIndexed - 4 बिट प्रति पिक्सेल, इंडेक्स्ड.
        Format8bppIndexed - 8 बिट प्रति पिक्सेल, इंडेक्स्ड.
        Format24bppRgb    - 24 बिट प्रति पिक्सेल, RGB.
        Format32bppArgb   - 32 बिट प्रति पिक्सेल, ARGB.
    */
    
    // निर्दिष्ट पिक्सेल फॉर्मेट के साथ प्रेज़ेंटेशन को TIFF के रूप में सहेजें।
    presentation.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Tip" color="info" %}}
Aspose के [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/hi/conversion/convert-ppt-to-poster-online) को देखें।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं संपूर्ण PowerPoint प्रेज़ेंटेशन के बजाय व्यक्तिगत स्लाइड को TIFF में परिवर्तित कर सकता हूँ?**

हां। Aspose.Slides आपको PowerPoint और OpenDocument प्रेज़ेंटेशन से व्यक्तिगत स्लाइड्स को अलग‑अलग TIFF इमेज में परिवर्तित करने की अनुमति देता है।

**क्या प्रेज़ेंटेशन को TIFF में परिवर्तित करते समय स्लाइड की संख्या पर कोई सीमा है?**

नहीं, Aspose.Slides स्लाइड की संख्या पर कोई प्रतिबंध नहीं लगाता। आप किसी भी आकार के प्रेज़ेंटेशन को TIFF फ़ॉर्मेट में परिवर्तित कर सकते हैं।

**क्या स्लाइड्स को TIFF में बदलते समय PowerPoint एनिमेशन और ट्रांज़िशन इफ़ेक्ट्स संरक्षित रहते हैं?**

नहीं, TIFF एक स्थिर इमेज फ़ॉर्मेट है। इसलिए, एनिमेशन और ट्रांज़िशन इफ़ेक्ट्स संरक्षित नहीं होते; केवल स्लाइड्स के स्थिर स्नैपशॉट निर्यात किए जाते हैं।