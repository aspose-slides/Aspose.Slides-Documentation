---
title: Android पर PowerPoint प्रस्तुतियों को TIFF में बदलें
titlelink: PowerPoint से TIFF
type: docs
weight: 90
url: /hi/androidjava/convert-powerpoint-to-tiff/
keywords:
- PowerPoint बदलें
- OpenDocument बदलें
- प्रस्तुति बदलें
- स्लाइड बदलें
- PPT बदलें
- PPTX बदलें
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
description: "Aspose.Slides for Android का उपयोग करके, Java कोड उदाहरणों के साथ, PowerPoint (PPT, PPTX) प्रस्तुतियों को उच्च गुणवत्ता वाली TIFF छवियों में आसानी से कैसे बदलें, सीखें।"
---
## **परिचय**

TIFF (**Tagged Image File Format**) एक व्यापक रूप से उपयोग किया जाने वाला, लॉसलेस रास्टर इमेज फॉर्मेट है जो अपनी उत्कृष्ट गुणवत्ता और ग्राफिक्स के विस्तृत संरक्षण के लिए जाना जाता है। डिज़ाइनर, फ़ोटोग्राफ़र, और डेस्कटॉप प्रकाशक अक्सर TIFF का चयन अपनी छवियों में लेयर, रंग की शुद्धता, और मूल सेटिंग्स बनाए रखने के लिए करते हैं।

Aspose.Slides का उपयोग करके, आप अपने PowerPoint स्लाइड्स (PPT, PPTX) और OpenDocument स्लाइड्स (ODP) को सीधे उच्च गुणवत्ता वाली TIFF छवियों में आसानी से बदल सकते हैं, जिससे आपके प्रस्तुतियों में अधिकतम दृश्य स्पष्टता बनी रहती है।

## **प्रेजेंटेशन को TIFF में परिवर्तित करें**

Using the [save](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) method provided by the [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) class, आप जल्दी से एक पूर्ण PowerPoint प्रेजेंटेशन को TIFF में बदल सकते हैं। परिणामी TIFF छवियां डिफ़ॉल्ट स्लाइड आकार के अनुरूप होती हैं।

यह कोड दिखाता है कि PowerPoint प्रेजेंटेशन को TIFF में कैसे परिवर्तित किया जाए:

```java
import com.aspose.slides.*;

// एक Presentation क्लास का इंस्टैंस बनाएं जो एक प्रस्तुति फ़ाइल (PPT, PPTX, ODP, आदि) को दर्शाती है।
Presentation presentation = new Presentation("presentation.pptx");
try {
    // प्रेज़ेंटेशन को TIFF के रूप में सहेजें।
    presentation.save("output.tiff", SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **प्रेजेंटेशन को ब्लैक-एंड-व्हाइट TIFF में परिवर्तित करें**

[setBwConversionMode] मेथड [TiffOptions] क्लास में आपको यह बताने की अनुमति देता है कि रंगीन स्लाइड या इमेज को ब्लैक-एंड-व्हाइट TIFF में बदलते समय कौन सा एल्गोरिद्म उपयोग किया जाए। ध्यान दें कि यह सेटिंग केवल तब लागू होती है जब [setCompressionType] मेथड `CCITT4` या `CCITT3` पर सेट हो।

मान लीजिए हमारे पास "sample.pptx" फ़ाइल है जिसमें निम्नलिखित स्लाइड है:

![एक प्रेजेंटेशन स्लाइड](slide_black_and_white.png)

यह कोड दिखाता है कि रंगीन स्लाइड को ब्लैक-एंड-व्हाइट TIFF में कैसे बदलें:

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

## **कस्टम आकार के साथ प्रेजेंटेशन को TIFF में परिवर्तित करें**

यदि आपको विशिष्ट आयामों वाली TIFF छवि चाहिए, तो आप [TiffOptions] में उपलब्ध मेथड्स का उपयोग करके अपनी इच्छित मान सेट कर सकते हैं। उदाहरण के लिए, [setImageSize] मेथड आपको परिणामी छवि का आकार निर्धारित करने की अनुमति देता है।

यह कोड दिखाता है कि PowerPoint प्रेजेंटेशन को कस्टम आकार वाली TIFF छवियों में कैसे बदलें:

```java
import com.aspose.slides.*;
import com.aspose.slides.android.Size;

// एक Presentation क्लास का इंस्टैंस बनाएं जो एक प्रस्तुति फ़ाइल (PPT, PPTX, ODP, आदि) को दर्शाती है।
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    // कम्प्रेशन प्रकार सेट करें।
    tiffOptions.setCompressionType(TiffCompressionTypes.Default);
    /*
    कम्प्रेशन प्रकार:
        Default - डिफ़ॉल्ट कम्प्रेशन योजना (LZW) निर्दिष्ट करता है।
        None - कोई कम्प्रेशन नहीं निर्दिष्ट करता है।
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // गहराई कम्प्रेशन प्रकार पर निर्भर करती है और इसे मैन्युअली सेट नहीं किया जा सकता।

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

## **कस्टम इमेज पिक्सेल फ़ॉर्मेट के साथ प्रेजेंटेशन को TIFF में परिवर्तित करें**

[TiffOptions] क्लास की [setPixelFormat] मेथड का उपयोग करके, आप परिणामी TIFF छवि के लिए अपनी पसंदीदा पिक्सेल फ़ॉर्मेट निर्दिष्ट कर सकते हैं।

यह कोड दिखाता है कि PowerPoint प्रेजेंटेशन को कस्टम पिक्सेल फ़ॉर्मेट वाली TIFF छवि में कैसे बदलें:

```java
import com.aspose.slides.*;

// एक Presentation क्लास का इंस्टैंस बनाएं जो एक प्रस्तुति फ़ाइल (PPT, PPTX, ODP, आदि) को दर्शाता है।
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    tiffOptions.setPixelFormat(ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat में निम्नलिखित मान होते हैं (दस्तावेज़ में बताए अनुसार):
        Format1bppIndexed - 1 बिट प्रति पिक्सेल, इंडेक्स्ड।
        Format4bppIndexed - 4 बिट प्रति पिक्सेल, इंडेक्स्ड।
        Format8bppIndexed - 8 बिट प्रति पिक्सेल, इंडेक्स्ड।
        Format24bppRgb    - 24 बिट प्रति पिक्सेल, RGB।
        Format32bppArgb   - 32 बिट प्रति पिक्सेल, ARGB।
    */
    
    // निर्दिष्ट पिक्सेल फ़ॉर्मेट के साथ प्रेज़ेंटेशन को TIFF के रूप में सहेजें।
    presentation.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Tip" color="info" %}}
Aspose के [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/hi/conversion/convert-ppt-to-poster-online) को देखें।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

### क्या मैं पूरे PowerPoint प्रेजेंटेशन के बजाय व्यक्तिगत स्लाइड को TIFF में बदल सकता हूँ?

हाँ। Aspose.Slides आपको PowerPoint और OpenDocument प्रस्तुतियों से व्यक्तिगत स्लाइड को अलग‑अलग TIFF छवियों में बदलने की अनुमति देता है।

### क्या स्लाइडों की संख्या पर कोई सीमा है जब प्रेजेंटेशन को TIFF में परिवर्तित किया जाता है?

नहीं, Aspose.Slides स्लाइडों की संख्या पर कोई प्रतिबंध नहीं लगाता। आप किसी भी आकार की प्रस्तुतियों को TIFF फॉर्मेट में बदल सकते हैं।

### क्या स्लाइडों को TIFF में बदलते समय PowerPoint एनीमेशन और ट्रांज़िशन इफ़ेक्ट्स संरक्षित रहेंगे?

नहीं, TIFF एक स्थिर इमेज फॉर्मेट है। इसलिए, एनीमेशन और ट्रांज़िशन इफ़ेक्ट्स संरक्षित नहीं होते; केवल स्लाइडों के स्थिर स्नैपशॉट निर्यात किए जाते हैं।