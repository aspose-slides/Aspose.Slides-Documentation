---
title: "Android पर PowerPoint प्रस्तुतियों को TIFF में बदलें"
titlelink: "PowerPoint से TIFF"
type: docs
weight: 90
url: /hi/androidjava/convert-powerpoint-to-tiff/
keywords:
- "PowerPoint को बदलें"
- "OpenDocument को बदलें"
- "प्रस्तुति को बदलें"
- "स्लाइड को बदलें"
- "PPT को बदलें"
- "PPTX को बदलें"
- "PowerPoint से TIFF"
- "प्रस्तुति से TIFF"
- "स्लाइड से TIFF"
- "PPT से TIFF"
- "PPTX से TIFF"
- "PPT को TIFF के रूप में सहेजें"
- "PPTX को TIFF के रूप में सहेजें"
- "PPT को TIFF में निर्यात करें"
- "PPTX को TIFF में निर्यात करें"
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android का उपयोग करके, Java कोड उदाहरणों के साथ, PowerPoint (PPT, PPTX) प्रस्तुतियों को उच्च-गुणवत्ता वाले TIFF इमेजेज़ में आसानी से कैसे बदलें, सीखें।"
---
## **परिचय**

TIFF (**Tagged Image File Format**) एक व्यापक रूप से उपयोग किया जाने वाला, लॉसलेस रास्टर इमेज फॉर्मेट है जिसे अपने उत्कृष्ट गुणवत्ता और ग्राफिक्स के विस्तृत संरक्षण के लिए जाना जाता है। डिजाइनर, फ़ोटोग्राफ़र और डेस्कटॉप पब्लिशर अक्सर अपने चित्रों में लेयर्स, रंग की शुद्धता और मूल सेटिंग्स को बनाए रखने के लिए TIFF का चयन करते हैं।

Aspose.Slides का उपयोग करके, आप अपने PowerPoint स्लाइड्स (PPT, PPTX) और OpenDocument स्लाइड्स (ODP) को सीधे उच्च‑गुणवत्ता वाले TIFF इमेजेज़ में आसानी से बदल सकते हैं, जिससे आपकी प्रस्तुतियों की दृश्य सटीकता अधिकतम बनी रहती है।

## **प्रेज़ेंटेशन को TIFF में बदलें**

[save](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) मेथड का उपयोग करके, जो कि [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास द्वारा प्रदान किया गया है, आप पूरे PowerPoint प्रेज़ेंटेशन को शीघ्रता से TIFF में बदल सकते हैं। परिणामस्वरूप प्राप्त TIFF इमेजेज़ डिफ़ॉल्ट स्लाइड आकार के अनुरूप होती हैं।

यह कोड दर्शाता है कि PowerPoint प्रेज़ेंटेशन को TIFF में कैसे बदलें:

```java
// प्रस्तुति फ़ाइल (PPT, PPTX, ODP आदि) का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करें।
Presentation presentation = new Presentation("presentation.pptx");
try {
    // प्रस्तुति को TIFF के रूप में सहेजें।
    presentation.save("output.tiff", SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **प्रेज़ेंटेशन को ब्लैक‑एंड‑व्हाइट TIFF में बदलें**

[TiffOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/tiffoptions/) क्लास में [setBwConversionMode](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) मेथड आपको रंगीन स्लाइड या इमेज को ब्लैक‑एंड‑व्हाइट TIFF में बदलते समय उपयोग किए जाने वाले एल्गोरिथ्म को निर्दिष्ट करने की अनुमति देता है। ध्यान दें कि यह सेटिंग केवल तब लागू होती है जब [setCompressionType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/tiffoptions/#setCompressionType-int-) मेथड को `CCITT4` या `CCITT3` पर सेट किया गया हो।

मान लीजिए हमारे पास "sample.pptx" फ़ाइल है जिसमें निम्नलिखित स्लाइड है:

![एक प्रस्तुति स्लाइड](slide_black_and_white.png)

यह कोड रंगीन स्लाइड को ब्लैक‑एंड‑व्हाइट TIFF में बदलता है:

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

![ब्लैक‑एंड‑व्हाइट TIFF](TIFF_black_and_white.png)

## **कस्टम आकार के साथ प्रेज़ेंटेशन को TIFF में बदलें**

यदि आपको विशिष्ट आयामों वाला TIFF इमेज चाहिए, तो आप [TiffOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/tiffoptions/) में उपलब्ध मेथड्स का उपयोग करके अपनी इच्छित मान सेट कर सकते हैं। उदाहरण के लिए, [setImageSize](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/tiffoptions/#setImageSize-com.aspose.slides.android.Size-) मेथड आपको उत्पन्न इमेज का आकार निर्धारित करने की सुविधा देता है।

यह कोड दर्शाता है कि PowerPoint प्रेज़ेंटेशन को कस्टम आकार वाली TIFF इमेजेज़ में कैसे बदलें:

```java
// प्रस्तुति फ़ाइल (PPT, PPTX, ODP आदि) का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करें।
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    // कम्प्रेशन प्रकार सेट करें।
    tiffOptions.setCompressionType(TiffCompressionTypes.Default);
    /*
    कम्प्रेशन प्रकार:
        Default - डिफ़ॉल्ट कम्प्रेशन स्कीम (LZW) को निर्दिष्ट करता है।
        None - कोई कम्प्रेशन नहीं निर्दिष्ट करता।
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // गहराई (depth) कम्प्रेशन प्रकार पर निर्भर करती है और मैन्युअल रूप से सेट नहीं की जा सकती।

    // इमेज DPI सेट करें।
    tiffOptions.setDpiX(200);
    tiffOptions.setDpiY(200);

    // इमेज आकार सेट करें।
    tiffOptions.setImageSize(new Size(1728, 1078));

    INotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // निर्दिष्ट आकार के साथ प्रस्तुति को TIFF के रूप में सहेजें।
    presentation.save("tiff-ImageSize.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}   
```

## **कस्टम इमेज पिक्सेल फ़ॉर्मेट के साथ प्रेज़ेंटेशन को TIFF में बदलें**

[TiffOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/tiffoptions/) क्लास का [setPixelFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/tiffoptions/#setPixelFormat-int-) मेथड उपयोग करके आप परिणामस्वरूप TIFF इमेज के लिए अपनी पसंद का पिक्सेल फ़ॉर्मेट निर्दिष्ट कर सकते हैं।

यह कोड दर्शाता है कि PowerPoint प्रेज़ेंटेशन को कस्टम पिक्सेल फ़ॉर्मेट वाली TIFF इमेज में कैसे बदलें:

```java
// प्रस्तुति फ़ाइल (PPT, PPTX, ODP, आदि) का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करें।
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    tiffOptions.setPixelFormat(ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat में निम्नलिखित मान होते हैं (दस्तावेज़ में बताए अनुसार):
        Format1bppIndexed - प्रति पिक्सेल 1 बिट, इंडेक्स्ड।
        Format4bppIndexed - प्रति पिक्सेल 4 बिट, इंडेक्स्ड।
        Format8bppIndexed - प्रति पिक्सेल 8 बिट, इंडेक्स्ड।
        Format24bppRgb    - प्रति पिक्सेल 24 बिट, RGB।
        Format32bppArgb   - प्रति पिक्सेल 32 बिट, ARGB।
    */

    // निर्दिष्ट इमेज आकार के साथ प्रस्तुति को TIFF के रूप में सहेजें।
    presentation.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="सलाह" color="primary" %}}
Aspose के मुफ़्त PowerPoint से पोस्टर में बदलने वाले कनवर्टर को देखें।

{{% /alert %}}

## **सामान्य प्रश्न**

**क्या मैं पूरे PowerPoint प्रेज़ेंटेशन को TIFF में बदलने की बजाय व्यक्तिगत स्लाइड को TIFF में बदल सकता हूँ?**

हां। Aspose.Slides आपको PowerPoint और OpenDocument प्रेज़ेंटेशन से व्यक्तिगत स्लाइड्स को अलग‑अलग TIFF इमेजेज़ में बदलने की सुविधा देता है।

**प्रेज़ेंटेशन को TIFF में बदलते समय स्लाइड की संख्या पर कोई सीमा है क्या?**

नहीं, Aspose.Slides स्लाइड की संख्या पर कोई प्रतिबंध नहीं लगाता। आप किसी भी आकार की प्रेज़ेंटेशन को TIFF फॉर्मेट में बदल सकते हैं।

**स्लाइड्स को TIFF में बदलते समय PowerPoint एनिमेशन और ट्रांज़िशन प्रभाव संरक्षित रहते हैं क्या?**

नहीं, TIFF एक स्थैतिक इमेज फॉर्मेट है। इसलिए, एनिमेशन और ट्रांज़िशन प्रभाव संरक्षित नहीं होते; केवल स्लाइड की स्थिर तस्वीरें ही निर्यात की जाती हैं।