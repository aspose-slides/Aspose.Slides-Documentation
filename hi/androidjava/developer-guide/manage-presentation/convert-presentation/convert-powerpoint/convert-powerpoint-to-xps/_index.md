---
title: Android पर PowerPoint प्रस्तुतियों को XPS में बदलें
linktitle: PowerPoint से XPS
type: docs
weight: 70
url: /hi/androidjava/convert-powerpoint-to-xps/
keywords:
- PowerPoint को बदलें
- प्रस्तुति को बदलें
- स्लाइड को बदलें
- PPT को बदलें
- PPTX को बदलें
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
description: "Aspose.Slides for Android का उपयोग करके Java में PowerPoint PPT/PPTX को उच्च-गुणवत्ता, प्लेटफ़ॉर्म-स्वतंत्र XPS में परिवर्तित करें। चरण-दर-चरण मार्गदर्शिका और नमूना कोड प्राप्त करें।"
---
## **सारांश**

Aspose.Slides आपको PowerPoint प्रस्तुतियों को XPS में परिवर्तित करने देता है, PPT या PPTX फ़ाइल को XPS फ़ॉर्मेट में सहेजकर। यह लेख बताता है कि XPS फ़ॉर्मेट कब उपयोगी हो सकता है और Aspose.Slides का उपयोग करके डिफ़ॉल्ट सेटिंग्स या कस्टम [XpsOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/xpsoptions/) सेटिंग्स के साथ परिवर्तन कैसे किया जाए।

## **XPS के बारे में**

Microsoft ने [XPS](https://docs.fileformat.com/page-description-language/xps/) को [PDF](https://docs.fileformat.com/pdf/) का विकल्प के रूप में विकसित किया। यह आपको सामग्री को प्रिंट करने की अनुमति देता है, एक ऐसी फ़ाइल आउटपुट करके जो PDF के बहुत समान हो। XPS फ़ॉर्मेट XML पर आधारित है। XPS फ़ाइल का लेआउट या संरचना सभी ऑपरेटिंग सिस्टम और प्रिंटरों पर समान रहती है।

## **Microsoft XPS फ़ॉर्मेट कब उपयोग करें**

{{% alert color="info" %}} 
यह देखने के लिए कि Aspose.Slides PPT या PPTX प्रस्तुतियों को XPS फ़ॉर्मेट में कैसे बदलता है, आप [इस मुफ्त ऑनलाइन कन्वर्टर ऐप](https://products.aspose.app/slides/hi/conversion) देख सकते हैं। 
{{% /alert %}} 

यदि आप संग्रहण लागत को कम करना चाहते हैं, तो आप अपनी Microsoft PowerPoint प्रस्तुति को XPS फ़ॉर्मेट में बदल सकते हैं। इस तरह, आप अपने दस्तावेज़ों को सहेजना, साझा करना और प्रिंट करना आसान पाएँगे।

Microsoft Windows (यहाँ तक कि Windows 10 में भी) में XPS के लिए मजबूत समर्थन लागू करता रहता है, इसलिए आप फ़ाइलों को इस फ़ॉर्मेट में सहेजने पर विचार कर सकते हैं। यदि आप Windows 8.1, Windows 8, Windows 7 और Windows Vista के साथ काम कर रहे हैं, तो XPS कुछ कार्यों के लिए आपका सबसे अच्छा विकल्प हो सकता है।

- **Windows 8** XPS फ़ाइलों के लिए OXPS (Open XPS) फ़ॉर्मेट का उपयोग करता है। OXPS मूल XPS फ़ॉर्मेट का मानकीकृत संस्करण है। Windows 8 XPS फ़ाइलों के लिए PDF फ़ाइलों की तुलना में बेहतर समर्थन प्रदान करता है।  
  - **XPS:** अंतर्निर्मित XPS व्यूअर/रीडर और XPS पर प्रिंटिंग सुविधा उपलब्ध।  
  - **PDF:** PDF रीडर उपलब्ध है लेकिन PDF पर प्रिंटिंग सुविधा नहीं है।  

- **Windows 7** और **Windows Vista** मूल XPS फ़ॉर्मेट का उपयोग करते हैं। ये ऑपरेटिंग सिस्टम XPS फ़ाइलों के लिए PDF की तुलना में बेहतर समर्थन प्रदान करते हैं।  
  - **XPS:** अंतर्निर्मित XPS व्यूअर और XPS पर प्रिंटिंग सुविधा उपलब्ध।  
  - **PDF:** PDF रीडर नहीं। PDF पर प्रिंटिंग सुविधा नहीं।  

|<p>**इनपुट PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**आउटपुट XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft ने अंततः Windows 10 में Print to PDF सुविधा के माध्यम से PDF में प्रिंट करने का समर्थन लागू किया। पहले, उपयोगकर्ताओं को दस्तावेज़ों को XPS फ़ॉर्मेट के माध्यम से प्रिंट करने की अपेक्षा की जाती थी।

## **Aspose.Slides के साथ XPS रूपांतरण**

Java के लिए [**Aspose.Slides**](https://products.aspose.com/slides/hi/androidjava/) में, आप [**Save**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) मेथड, जो [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास द्वारा प्रदान किया गया है, का उपयोग करके पूरी प्रस्तुति को XPS दस्तावेज़ में बदल सकते हैं।

जब प्रस्तुति को XPS में बदलते हैं, तो आपको प्रस्तुति को इन सेटिंग्स में से किसी एक का उपयोग करके सहेजना होगा:

- डिफ़ॉल्ट सेटिंग्स (बिना [**XpsOptions**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/xpsoptions) के)  
- कस्टम सेटिंग्स (साथ में [**XpsOptions**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/xpsoptions) के)

### **डिफ़ॉल्ट सेटिंग्स का उपयोग करके प्रस्तुतियों को XPS में बदलें**

यह Java में नमूना कोड दिखाता है कि मानक सेटिंग्स का उपयोग करके प्रस्तुति को XPS दस्तावेज़ में कैसे परिवर्तित किया जाए:

```java
import com.aspose.slides.*;

// एक Presentation ऑब्जेक्ट बनाएँ जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
Presentation pres = new Presentation("Convert_XPS.pptx");
try {
    // प्रस्तुति को XPS दस्तावेज़ में सहेज रहा है
    pres.save("XPS_Output_Without_XPSOption.xps", SaveFormat.Xps);
} finally {
    if (pres != null) pres.dispose();
}
```

### **कस्टम सेटिंग्स का उपयोग करके प्रस्तुतियों को XPS में बदलें**

यह नमूना कोड दिखाता है कि Java में कस्टम सेटिंग्स का उपयोग करके प्रस्तुति को XPS दस्तावेज़ में कैसे परिवर्तित किया जाए:

```java
import com.aspose.slides.*;

// एक Presentation ऑब्जेक्ट बनाएं जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
Presentation pres = new Presentation("Convert_XPS_Options.pptx");
try {
    // XpsOptions क्लास को इंस्टैंशिएट करें
    XpsOptions options = new XpsOptions();

    // MetaFiles को PNG के रूप में सहेजें
    options.setSaveMetafilesAsPng(true);

    // प्रस्तुति को XPS दस्तावेज़ में सहेजें
    pres.save("XPS_Output_With_Options.xps", SaveFormat.Xps, options);
} finally {
    if (pres != null) pres.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

### क्या मैं XPS को फ़ाइल के बजाय स्ट्रीम में सहेज सकता हूँ?

हाँ—Aspose.Slides आपको सीधे स्ट्रीम में निर्यात करने की सुविधा देता है, जो वेब API, सर्वर‑साइड पाइपलाइन, या किसी भी स्थिति में उपयोगी है जहाँ आप फ़ाइल सिस्टम को छुए बिना XPS भेजना चाहते हैं।

### क्या छिपी हुई स्लाइड्स XPS में भी शामिल होती हैं, और क्या मैं उन्हें बाहर कर सकता हूँ?

डिफ़ॉल्ट रूप से केवल सामान्य (दृश्यमान) स्लाइड्स ही रेंडर होती हैं। आप [छिपी हुई स्लाइड्स को शामिल या बाहर करें](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/xpsoptions/#setShowHiddenSlides-boolean-) को [निर्यात सेटिंग्स](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/xpsoptions/) में बदलकर XPS में सहेजने से पहले सुनिश्चित कर सकते हैं कि आउटपुट में बिल्कुल वही पेज हों जो आप चाहते हैं।