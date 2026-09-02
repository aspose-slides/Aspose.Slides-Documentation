---
title: Android पर PowerPoint प्रस्तुतियों को TIFF में बदलें
titlelink: PowerPoint से TIFF
type: docs
weight: 90
url: /hi/androidjava/convert-powerpoint-to-tiff/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android का उपयोग करके, Java कोड उदाहरणों के साथ, PowerPoint (PPT, PPTX) प्रस्तुतियों को उच्च‑गुणवत्ता वाले TIFF छवियों में आसानी से कैसे बदलें, सीखें।"
---
## **परिचय**

TIFF (**Tagged Image File Format**) एक व्यापक रूप से उपयोग किया जाने वाला, लॉसलेस रास्टर इमेज फॉर्मेट है, जिसे अपनी उत्कृष्ट गुणवत्ता और ग्राफ़िक्स के विस्तृत संरक्षण के लिए जाना जाता है। डिजाइनर, फ़ोटोग्राफ़र और डेस्कटॉप पब्लिशर अक्सर TIFF चुनते हैं ताकि अपनी छवियों में लेयर्स, रंग की शुद्धता और मूल सेटिंग्स को बरकरार रखा जा सके।

Aspose.Slides का उपयोग करके आप अपने PowerPoint स्लाइड्स (PPT, PPTX) और OpenDocument स्लाइड्स (ODP) को सीधे उच्च‑गुणवत्ता वाले TIFF इमेज में सहजता से बदल सकते हैं, जिससे आपकी प्रस्तुतियों में अधिकतम दृश्य सटीकता बनी रहे।

## **प्रेज़ेंटेशन को TIFF में बदलें**

[save](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) मेथड का उपयोग करके, जो कि [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास द्वारा प्रदान किया गया है, आप पूरी PowerPoint प्रस्तुति को जल्दी से TIFF में बदल सकते हैं। उत्पन्न TIFF इमेज डिफ़ॉल्ट स्लाइड आकार के अनुरूप होते हैं।

```java
import com.aspose.slides.*;

// Presentation क्लास को इंस्टैंशिएट करें जो प्रस्तुति फ़ाइल (PPT, PPTX, ODP, आदि) को दर्शाती है।
Presentation presentation = new Presentation("presentation.pptx");
try {
    // प्रस्तुति को TIFF के रूप में सहेजें।
    presentation.save("output.tiff", SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **प्रेज़ेंटेशन को काली‑और‑सफ़ेद TIFF में बदलें**

[TiffOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/tiffoptions/) क्लास में मौजूद मेथड [setBwConversionMode](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) आपको रंगीन स्लाइड या छवि को काली‑और‑सफ़ेद TIFF में बदलते समय प्रयोग किए जाने वाले एल्गोरिद्म को निर्दिष्ट करने की अनुमति देता है। ध्यान दें कि यह सेटिंग केवल तभी लागू होती है जब [setCompressionType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/tiffoptions/#setCompressionType-int-) मेथड को `CCITT4` या `CCITT3` पर सेट किया गया हो।

{{% alert color="info" title="नोट" %}}
[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) एक एक्सपोर्ट‑लेवल सेटिंग है जो पूरे TIFF इमेज के लिए पिक्सेल‑कन्वर्ज़न एल्गोरिद्म चुनती है। जब काली‑और‑सफ़ेद डिस्प्ले मोड सक्रिय हो, तब किसी व्यक्तिगत शैप के रूप को निर्धारित करने के लिए आप [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) का उपयोग कर सकते हैं। उदाहरणों के लिए देखें [आकृति के लिए काली‑और‑सफ़ेद रेंडरिंग को नियंत्रित करें](/androidjava/shape-formatting/#control-black-and-white-rendering-for-shapes)।
{{% /alert %}}

मान लीजिए हमारे पास "sample.pptx" फ़ाइल है जिसमें निम्नलिखित स्लाइड है:

![एक प्रस्तुति स्लाइड](slide_black_and_white.png)

यह कोड दिखाता है कि रंगीन स्लाइड को काली‑और‑सफ़ेद TIFF में कैसे बदला जाए:

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

![काली‑और‑सफ़ेद TIFF](TIFF_black_and_white.png)

## **कस्टम आकार के साथ TIFF में प्रेज़ेंटेशन बदलें**

यदि आपको विशिष्ट आयामों वाला TIFF इमेज चाहिए, तो आप [TiffOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/tiffoptions/) में उपलब्ध मेथड्स का उपयोग करके अपनी इच्छित मान सेट कर सकते हैं। उदाहरण के तौर पर, [setImageSize](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/tiffoptions/#setImageSize-com.aspose.slides.android.Size-) मेथड आपको उत्पन्न इमेज के आकार को परिभाषित करने की सुविधा देता है।

```java
import com.aspose.slides.*;
import com.aspose.slides.android.Size;

// Presentation वर्ग का उदाहरण बनाएं जो प्रस्तुति फ़ाइल (PPT, PPTX, ODP, आदि) का प्रतिनिधित्व करता है।
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    // संपीड़न प्रकार सेट करें।
    tiffOptions.setCompressionType(TiffCompressionTypes.Default);
    /*
    संपीड़न प्रकारः
        Default - डिफ़ॉल्ट संपीड़न योजना (LZW) को निर्दिष्ट करता है।
        None - कोई संपीड़न नहीं होने को निर्दिष्ट करता है।
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // गहराई संपीड़न प्रकार पर निर्भर करती है और इसे मैन्युअल रूप से सेट नहीं किया जा सकता।

    // छवि DPI सेट करें।
    tiffOptions.setDpiX(200);
    tiffOptions.setDpiY(200);

    // छवि आकार सेट करें।
    tiffOptions.setImageSize(new Size(1728, 1078));

    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // निर्दिष्ट आकार के साथ प्रस्तुति को TIFF के रूप में सहेजें।
    presentation.save("tiff-ImageSize.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}   
```

## **कस्टम इमेज पिक्सेल फॉर्मेट के साथ TIFF में प्रेज़ेंटेशन बदलें**

[TiffOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/tiffoptions/) क्लास के [setPixelFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/tiffoptions/#setPixelFormat-int-) मेथड का उपयोग करके आप उत्पन्न TIFF इमेज के लिए अपनी पसंदीदा पिक्सेल फॉर्मेट निर्धारित कर सकते हैं।

```java
import com.aspose.slides.*;

// Presentation क्लास को बनाएं जो प्रस्तुति फ़ाइल (PPT, PPTX, ODP, आदि) का प्रतिनिधित्व करता है।
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    tiffOptions.setPixelFormat(ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat में निम्नलिखित मान होते हैं (दस्तावेज़ में वर्णित अनुसार):
        Format1bppIndexed - 1 बिट प्रति पिक्सेल, अनुक्रमित।
        Format4bppIndexed - 4 बिट प्रति पिक्सेल, अनुक्रमित।
        Format8bppIndexed - 8 बिट प्रति पिक्सेल, अनुक्रमित।
        Format24bppRgb    - 24 बिट प्रति पिक्सेल, RGB।
        Format32bppArgb   - 32 बिट प्रति पिक्सेल, ARGB।
    */
    
    // निर्दिष्ट पिक्सेल फ़ॉर्मेट के साथ प्रस्तुति को TIFF के रूप में सहेजें।
    presentation.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="सलाह" color="info" %}}
Aspose के [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/hi/conversion/convert-ppt-to-poster-online) को देखें।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं पूरे PowerPoint प्रेज़ेंटेशन की बजाय व्यक्तिगत स्लाइड को TIFF में बदल सकता हूँ?**  
हाँ। Aspose.Slides आपको PowerPoint और OpenDocument प्रस्तुतियों से व्यक्तिगत स्लाइड्स को अलग‑अलग TIFF इमेज में बदलने की सुविधा देता है।

**प्रेज़ेंटेशन को TIFF में बदलते समय स्लाइड की संख्या पर कोई सीमा है क्या?**  
नहीं, Aspose.Slides स्लाइडों की संख्या पर कोई प्रतिबंध नहीं लगाता। आप किसी भी आकार की प्रस्तुतियों को TIFF फ़ॉर्मेट में बदल सकते हैं।

**TIFF में स्लाइड बदलते समय PowerPoint एनीमेशन और ट्रांज़िशन इफ़ेक्ट्स बरकरार रहते हैं क्या?**  
नहीं, TIFF एक स्थैतिक इमेज फ़ॉर्मेट है। इसलिए एनीमेशन और ट्रांज़िशन इफ़ेक्ट्स संरक्षित नहीं होते; केवल स्लाइड का स्थिर स्नैपशॉट निर्यात किया जाता है।