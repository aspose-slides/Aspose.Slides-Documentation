---
title: Java में PowerPoint प्रस्तुतियों को XPS में बदलें
linktitle: PowerPoint से XPS
type: docs
weight: 70
url: /hi/java/convert-powerpoint-to-xps/
keywords:
- PowerPoint को परिवर्तित करें
- प्रस्तुति को परिवर्तित करें
- स्लाइड को परिवर्तित करें
- PPT को परिवर्तित करें
- PPTX को परिवर्तित करें
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
- Java
- Aspose.Slides
description: "Java में Aspose.Slides का उपयोग करके PowerPoint PPT/PPTX को उच्च-गुणवत्ता, प्लेटफ़ॉर्म-स्वतंत्र XPS में बदलें। चरण-दर-चरण गाइड और नमूना कोड प्राप्त करें।"
---
## **अवलोकन**

Aspose.Slides आपको PowerPoint प्रस्तुतियों को XPS में बदलने की सुविधा देता है, यानी PPT या PPTX फ़ाइल को XPS प्रारूप में सहेजकर। यह लेख बताता है कि XPS प्रारूप कब उपयोगी हो सकता है और Aspose.Slides का उपयोग करके डिफ़ॉल्ट सेटिंग्स या कस्टम [XpsOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/xpsoptions/) सेटिंग्स के साथ रूपांतरण कैसे किया जाता है।

## **XPS के बारे में**
Microsoft ने [XPS](https://docs.fileformat.com/page-description-language/xps/) को [PDF](https://docs.fileformat.com/pdf/) का विकल्प बनाने के लिए विकसित किया। यह आपको PDF के समान फ़ाइल आउटपुट करके सामग्री को प्रिंट करने की अनुमति देता है। XPS प्रारूप XML पर आधारित है। XPS फ़ाइल की लेआउट या संरचना सभी ऑपरेटिंग सिस्टम और प्रिंटरों पर समान रहती है।

## **Microsoft XPS प्रारूप कब उपयोग करें**

{{% alert color="info" %}} 

Aspose.Slides यह दिखाने के लिए कि यह PPT या PPTX प्रस्तुतियों को XPS में कैसे बदलता है, आप [यह मुफ्त ऑनलाइन रूपांतरण ऐप](https://products.aspose.app/slides/hi/conversion) देख सकते हैं।

{{% /alert %}} 

यदि आप संग्रहण लागत कम करना चाहते हैं, तो आप अपनी Microsoft PowerPoint प्रस्तुति को XPS प्रारूप में बदल सकते हैं। इससे आप दस्तावेज़ को सहेजना, साझा करना और प्रिंट करना आसान पाएँगे।

Microsoft Windows (यहाँ तक कि Windows 10 में) में XPS के लिए मजबूत समर्थन जारी रखता है, इसलिए आप फ़ाइलों को इस प्रारूप में सहेजने पर विचार कर सकते हैं। यदि आप Windows 8.1, Windows 8, Windows 7 और Windows Vista के साथ काम कर रहे हैं, तो XPS कुछ कार्यों के लिए आपका सबसे अच्छा विकल्प हो सकता है।

- **Windows 8** XPS फ़ाइलों के लिए OXPS (Open XPS) प्रारूप का उपयोग करता है। OXPS मूल XPS प्रारूप का मानकीकृत संस्करण है। Windows 8 PDF फ़ाइलों की तुलना में XPS फ़ाइलों को बेहतर समर्थन देता है। 
  - **XPS:** अंतर्निहित XPS व्यूअर/रीडर और XPS में प्रिंट करने की सुविधा उपलब्ध है। 
  - **PDF:** PDF रीडर उपलब्ध है लेकिन PDF में प्रिंट करने की सुविधा नहीं है। 

- **Windows 7 और Windows Vista** मूल XPS प्रारूप का उपयोग करते हैं। ये ऑपरेटिंग सिस्टम भी PDF की तुलना में XPS फ़ाइलों को बेहतर समर्थन देते हैं। 
  - **XPS:** अंतर्निहित XPS व्यूअर और XPS में प्रिंट करने की सुविधा उपलब्ध है। 
  - **PDF:** PDF रीडर नहीं है। PDF में प्रिंट करने की सुविधा नहीं है। 

|<p>**इनपुट PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**आउटपुट XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft ने अंततः Windows 10 में Print to PDF सुविधा के माध्यम से PDF में प्रिंटिंग को समर्थन दिया। पहले उपयोगकर्ता को दस्तावेज़ प्रिंट करने के लिए XPS प्रारूप का उपयोग करना पड़ता था।

## **Aspose.Slides के साथ XPS रूपांतरण**

[**Aspose.Slides**](https://products.aspose.com/slides/hi/java/) for Java में, आप [**Save**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) मेथड का उपयोग करके, जिसे [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास में उजागर किया गया है, पूरे प्रस्तुति को एक XPS दस्तावेज़ में बदल सकते हैं।

जब आप प्रस्तुति को XPS में बदलते हैं, तो आपको प्रस्तुति को निम्न सेटिंग्स में से एक के साथ सहेजना होगा:

- डिफ़ॉल्ट सेटिंग्स (बिना [**XPSOptions**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/xpsoptions) के)
- कस्टम सेटिंग्स (साथ में [**XPSOptions**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/xpsoptions) के)

### **डिफ़ॉल्ट सेटिंग्स का उपयोग करके प्रस्तुतियों को XPS में बदलें**

Java में यह नमूना कोड दिखाता है कि आप मानक सेटिंग्स का उपयोग करके प्रस्तुति को XPS दस्तावेज़ में कैसे बदल सकते हैं:

```java
import com.aspose.slides.*;

// एक Presentation ऑब्जेक्ट बनाएं जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
Presentation pres = new Presentation("Convert_XPS.pptx");
try {
    // प्रस्तुति को XPS दस्तावेज़ में सहेजना
    pres.save("XPS_Output_Without_XPSOption.xps", SaveFormat.Xps);
} finally {
    if (pres != null) pres.dispose();
}
```

### **कस्टम सेटिंग्स का उपयोग करके प्रस्तुतियों को XPS में बदलें**
यह नमूना कोड दिखाता है कि आप Java में कस्टम सेटिंग्स का उपयोग करके प्रस्तुति को XPS दस्तावेज़ में कैसे बदल सकते हैं:

```java
import com.aspose.slides.*;

// एक Presentation ऑब्जेक्ट बनाएं जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
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

### क्या मैं फ़ाइल के बजाय स्ट्रीम में XPS सहेज सकता हूँ?

हाँ—Aspose.Slides आपको सीधे स्ट्रीम में निर्यात करने की अनुमति देता है, जो वेब API, सर्वर‑साइड पाइपलाइन, या किसी भी ऐसी स्थिति के लिए आदर्श है जहाँ आप फ़ाइल सिस्टम को छुए बिना XPS भेजना चाहते हैं।

### क्या छुपी हुई स्लाइड्स XPS में भी निर्यात होती हैं, और क्या मैं उन्हें बाहर रख सकता हूँ?

डिफ़ॉल्ट रूप से केवल सामान्य ( दिखाई देने वाली) स्लाइड्स ही रेंडर की जाती हैं। आप [एक्सपोर्ट सेटिंग्स](https://reference.aspose.com/slides/hi/java/com.aspose.slides/xpsoptions/) के माध्यम से [छुपी हुई स्लाइड्स को शामिल या बाहर करने](https://reference.aspose.com/slides/hi/java/com.aspose.slides/xpsoptions/#setShowHiddenSlides-boolean-) का चयन कर सकते हैं, जिससे आउटपुट में ठीक वही पृष्ठ हों जो आप चाहते हैं।