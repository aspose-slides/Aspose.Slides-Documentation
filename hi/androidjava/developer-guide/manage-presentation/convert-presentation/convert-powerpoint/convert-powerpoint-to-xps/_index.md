---
title: Android पर PowerPoint प्रस्तुतियों को XPS में बदलें
linktitle: PowerPoint से XPS
type: docs
weight: 70
url: /hi/androidjava/convert-powerpoint-to-xps/
keywords:
- PowerPoint बदलें
- प्रस्तुति बदलें
- स्लाइड बदलें
- PPT बदलें
- PPTX बदलें
- PowerPoint से XPS
- प्रस्तुति से XPS
- स्लाइड से XPS
- PPT से XPS
- PPTX से XPS
- PPT को XPS के रूप में सहेजें
- PPTX को XPS के रूप में सहेजें
- PPT को XPS में निर्यात करें
- PPTX को XPS में निर्यात करें
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android का उपयोग करके Java में PowerPoint PPT/PPTX को उच्च-गुणवत्ता, प्लेटफ़ॉर्म-निर्भरता रहित XPS में बदलें। चरण-दर-चरण मार्गदर्शिका और नमूना कोड प्राप्त करें।"
---
## **अवलोकन**

Aspose.Slides आपको PowerPoint प्रस्तुतियों को XPS में बदलने की सुविधा देता है, PPT या PPTX फ़ाइल को XPS स्वरूप में सहेजकर। यह लेख बताता है कि XPS स्वरूप कब उपयोगी हो सकता है और Aspose.Slides का उपयोग करके डिफॉ़ल्ट सेटिंग्स या कस्टम [XpsOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/xpsoptions/) सेटिंग्स के साथ रूपांतरण कैसे किया जाता है।

## **XPS के बारे में**
Microsoft ने [XPS](https://docs.fileformat.com/page-description-language/xps/) को [PDF](https://docs.fileformat.com/pdf/) का विकल्प बनाने के लिए विकसित किया। यह PDF के समान फ़ाइल को आउटपुट करके सामग्री को प्रिंट करने की अनुमति देता है। XPS स्वरूप XML पर आधारित है। XPS फ़ाइल की लेआउट या संरचना सभी ऑपरेटिंग सिस्टम और प्रिंटरों पर समान रहती है।

## **Microsoft XPS स्वरूप कब उपयोग करें**

{{% alert color="primary" %}} 

Aspose.Slides कैसे PPT या PPTX प्रस्तुति को XPS स्वरूप में बदलता है, यह देखने के लिए आप [this free online converter app](https://products.aspose.app/slides/hi/conversion) देख सकते हैं।

{{% /alert %}} 

यदि आप भंडारण लागत कम करना चाहते हैं, तो आप अपनी Microsoft PowerPoint प्रस्तुति को XPS स्वरूप में बदल सकते हैं। इस तरह आप अपने दस्तावेज़ों को सहेजना, साझा करना और प्रिंट करना आसान पाएँगे।

Microsoft Windows (Windows 10 सहित) में XPS के लिए मजबूत समर्थन जारी रखता है, इसलिए आपको फ़ाइलों को इस स्वरूप में सहेजने पर विचार करना चाहिए। यदि आप Windows 8.1, Windows 8, Windows 7 और Windows Vista के साथ काम कर रहे हैं, तो कुछ ऑपरेशन के लिए XPS वास्तव में आपका सबसे अच्छा विकल्प हो सकता है।

- **Windows 8** OXPS (Open XPS) स्वरूप का उपयोग करता है। OXPS मूल XPS स्वरूप का मानकीकृत संस्करण है। Windows 8 PDF फ़ाइलों की तुलना में XPS फ़ाइलों को बेहतर समर्थन प्रदान करता है।  
  - **XPS:** अंतर्निहित XPS व्यूअर/रीडर और XPS पर प्रिंट करने की सुविधा उपलब्ध।  
  - **PDF:** PDF रीडर उपलब्ध है लेकिन PDF पर प्रिंट करने की सुविधा नहीं।

- **Windows 7** और **Windows Vista** मूल XPS स्वरूप का उपयोग करते हैं। ये ऑपरेटिंग सिस्टम भी PDF की तुलना में XPS फ़ाइलों को बेहतर समर्थन देते हैं।  
  - **XPS:** अंतर्निहित XPS व्यूअर और XPS पर प्रिंट करने की सुविधा उपलब्ध।  
  - **PDF:** PDF रीडर नहीं। PDF पर प्रिंट करने की सुविधा नहीं।

|<p>**इनपुट PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**आउटपुट XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft ने अंततः Windows 10 में Print to PDF सुविधा के माध्यम से PDF में प्रिंट करने के समर्थन को लागू किया। पहले उपयोगकर्ता XPS स्वरूप के माध्यम से दस्तावेज़ प्रिंट करने की अपेक्षा करते थे।

## **Aspose.Slides के साथ XPS रूपांतरण**

[**Aspose.Slides**](https://products.aspose.com/slides/hi/androidjava/) for Java में, आप [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास द्वारा प्रदान किए गए [**Save**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) मेथड का उपयोग करके पूरी प्रस्तुति को XPS दस्तावेज़ में परिवर्तित कर सकते हैं।

जब आप प्रस्तुति को XPS में बदलते हैं, तो आपको प्रस्तुति को निम्न सेटिंग्स में से किसी एक के साथ सहेजना होगा:

- डिफ़ॉल्ट सेटिंग्स (बिना [**XPSOptions**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/xpsoptions) के)  
- कस्टम सेटिंग्स (के साथ [**XPSOptions**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/xpsoptions))

### **डिफ़ॉल्ट सेटिंग्स का उपयोग करके प्रस्तुतियों को XPS में बदलें**

यह Java नमूना कोड दर्शाता है कि कैसे मानक सेटिंग्स का उपयोग करके प्रस्तुति को XPS दस्तावेज़ में बदला जा सकता है:

```java
// एक Presentation ऑब्जेक्ट बनाता है जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
Presentation pres = new Presentation("Convert_XPS.pptx");
try {
    // प्रस्तुति को XPS दस्तावेज़ में सहेज रहा है
    pres.save("XPS_Output_Without_XPSOption.xps", SaveFormat.Xps);
} finally {
    if (pres != null) pres.dispose();
}
```

### **कस्टम सेटिंग्स का उपयोग करके प्रस्तुतियों को XPS में बदलें**
यह नमूना कोड दिखाता है कि कैसे कस्टम सेटिंग्स के साथ प्रस्तुति को XPS दस्तावेज़ में बदला जा सकता है Java में:

```java
// एक Presentation ऑब्जेक्ट बनाता है जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
Presentation pres = new Presentation("Convert_XPS_Options.pptx");
try {
    // TiffOptions क्लास का एक उदाहरण बनाता है
    XpsOptions options = new XpsOptions();

    // MetaFiles को PNG के रूप में सहेजें
    options.setSaveMetafilesAsPng(true);

    // प्रस्तुति को XPS दस्तावेज़ में सहेजें
    pres.save("XPS_Output_With_Options.xps", SaveFormat.Xps, options);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**क्या मैं XPS को फ़ाइल के बजाय स्ट्रीम में सहेज सकता हूँ?**

हाँ—Aspose.Slides आपको सीधे एक स्ट्रीम में एक्सपोर्ट करने देता है, जो वेब API, सर्वर‑साइड पाइपलाइन, या किसी भी परिदृश्य में उपयोगी है जहाँ आप XPS को फ़ाइल सिस्टम को छुए बिना भेजना चाहते हैं।

**क्या छिपी स्लाइड्स XPS में शामिल होती हैं, और क्या मैं उन्हें बाहर कर सकता हूँ?**

डिफ़ॉल्ट रूप से केवल नियमित (दृश्यमान) स्लाइड्स ही रेंडर होती हैं। आप [छिपी स्लाइड्स को शामिल या बाहर करें](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/xpsoptions/#setShowHiddenSlides-boolean-) को [एक्सपोर्ट सेटिंग्स](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/xpsoptions/) के माध्यम से XPS में सहेजने से पहले नियंत्रित कर सकते हैं, जिससे आउटपुट में ठीक वही पेज़ हों जो आप चाहते हैं।