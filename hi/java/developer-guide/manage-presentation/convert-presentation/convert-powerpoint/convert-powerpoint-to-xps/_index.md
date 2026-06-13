---
title: जावा में PowerPoint प्रस्तुतियों को XPS में बदलें
linktitle: PowerPoint से XPS
type: docs
weight: 70
url: /hi/java/convert-powerpoint-to-xps/
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
- Java
- Aspose.Slides
description: "Aspose.Slides का उपयोग करके जावा में PowerPoint PPT/PPTX को उच्च-गुणवत्ता, प्लेटफ़ॉर्म‑स्वतंत्र XPS में बदलें। चरण-दर-चरण गाइड और नमूना कोड प्राप्त करें।"
---
## **परिचय**

Aspose.Slides आपको PowerPoint प्रस्तुतियों को XPS में बदलने की सुविधा देता है, PPT या PPTX फ़ाइल को XPS प्रारूप में सहेजकर। यह लेख बताता है कि XPS प्रारूप कब उपयोगी हो सकता है और Aspose.Slides के साथ डिफ़ॉल्ट सेटिंग्स या कस्टम [XpsOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/xpsoptions/) सेटिंग्स का उपयोग करके रूपांतरण कैसे किया जाए।

## **XPS के बारे में**
Microsoft ने [XPS](https://docs.fileformat.com/page-description-language/xps/) को [PDF](https://docs.fileformat.com/pdf/) के विकल्प के रूप में विकसित किया। यह आपको PDF के बहुत समान फ़ाइल को आउटपुट करके सामग्री प्रिंट करने की अनुमति देता है। XPS प्रारूप XML पर आधारित है। XPS फ़ाइल की लेआउट या संरचना सभी ऑपरेटिंग सिस्टम और प्रिंटरों पर समान रहती है। 

## **Microsoft XPS फ़ॉर्मेट कब उपयोग करें**

{{% alert color="primary" %}} 

यह देखने के लिए कि Aspose.Slides PPT या PPTX प्रस्तुति को XPS फ़ॉर्मेट में कैसे बदलता है, आप इस मुफ्त ऑनलाइन कनवर्टर ऐप को देख सकते हैं: [this free online converter app](https://products.aspose.app/slides/hi/conversion)। 

{{% /alert %}} 

यदि आप स्टोरेज लागत कम करना चाहते हैं, तो आप अपनी Microsoft PowerPoint प्रस्तुति को XPS फ़ॉर्मेट में बदल सकते हैं। इस तरह, आपके दस्तावेज़ों को सहेजना, साझा करना और प्रिंट करना आसान हो जाएगा। 

Microsoft Windows (यहाँ तक कि Windows 10 में भी) में XPS के लिए मजबूत समर्थन लागू करता रहता है, इसलिए आप फ़ाइलों को इस फ़ॉर्मेट में सहेजने पर विचार कर सकते हैं। यदि आप Windows 8.1, Windows 8, Windows 7, और Windows Vista के साथ काम कर रहे हैं, तो XPS कुछ कार्यों के लिए आपका सबसे अच्छा विकल्प हो सकता है। 

- **Windows 8** XPS फ़ाइलों के लिए OXPS (Open XPS) फ़ॉर्मेट का उपयोग करता है। OXPS मूल XPS फ़ॉर्मेट का मानकीकृत संस्करण है। Windows 8 XPS फ़ाइलों के लिए PDF फ़ाइलों की तुलना में बेहतर समर्थन प्रदान करता है। 
  - **XPS:** अंतर्निहित XPS व्यूअर/रीडर और XPS पर प्रिंट करने की सुविधा उपलब्ध है। 
  - **PDF**: PDF रीडर उपलब्ध है लेकिन PDF पर प्रिंट करने की सुविधा नहीं है। 

- **Windows 7 और Windows Vista** मूल XPS फ़ॉर्मेट का उपयोग करते हैं। ये ऑपरेटिंग सिस्टम भी PDF की तुलना में XPS फ़ाइलों के लिए बेहतर समर्थन प्रदान करते हैं। 
  - **XPS**: अंतर्निहित XPS व्यूअर और XPS पर प्रिंट करने की सुविधा उपलब्ध है। 
  - **PDF**: PDF रीडर नहीं है। PDF पर प्रिंट करने की सुविधा नहीं है। 

|<p>**इनपुट PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**आउटपुट XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |



Microsoft ने अंततः Windows 10 में PDF पर प्रिंट करने की सुविधा के माध्यम से PDF में प्रिंट ऑपरेशन्स का समर्थन लागू किया। पहले, उपयोगकर्ताओं को दस्तावेज़ों को XPS फ़ॉर्मेट के माध्यम से प्रिंट करने की अपेक्षा की जाती थी। 

## **Aspose.Slides के साथ XPS रूपांतरण**

Java के लिए [**Aspose.Slides**](https://products.aspose.com/slides/hi/java/) में, आप [**Save**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) मेथड का उपयोग कर सकते हैं जो [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास द्वारा प्रदान किया गया है, ताकि पूरे प्रस्तुति को XPS दस्तावेज़ में बदल सकें। 

जब प्रस्तुति को XPS में रूपांतरित किया जाता है, तो आपको प्रस्तुति को निम्नलिखित सेटिंग्स में से किसी एक का उपयोग करके सहेजना होगा:

- डिफ़ॉल्ट सेटिंग्स (बिना [**XPSOptions**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/xpsoptions) के)
- कस्टम सेटिंग्स (साथ में [**XPSOptions**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/xpsoptions) के)

### **डिफ़ॉल्ट सेटिंग्स के साथ प्रस्तुति को XPS में बदलें**

यह जावा में नमूना कोड दिखाता है कि कैसे प्रस्तुति को मानक सेटिंग्स का उपयोग करके XPS दस्तावेज़ में बदला जा सकता है:

```java
// एक Presentation ऑब्जेक्ट बनाएं जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
Presentation pres = new Presentation("Convert_XPS.pptx");
try {
    // प्रस्तुति को XPS दस्तावेज़ में सहेज रहा है
    pres.save("XPS_Output_Without_XPSOption.xps", SaveFormat.Xps);
} finally {
    if (pres != null) pres.dispose();
}
```

### **कस्टम सेटिंग्स के साथ प्रस्तुति को XPS में बदलें**

यह नमूना कोड दिखाता है कि कैसे जावा में कस्टम सेटिंग्स का उपयोग करके प्रस्तुति को XPS दस्तावेज़ में बदला जा सकता है:

```java
// एक Presentation ऑब्जेक्ट बनाएं जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
Presentation pres = new Presentation("Convert_XPS_Options.pptx");
try {
    // TiffOptions क्लास का एक उदाहरण बनाएं
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

**क्या मैं फ़ाइल की बजाय XPS को स्ट्रीम में सहेज सकता हूँ?**

हाँ—Aspose.Slides आपको सीधे स्ट्रीम में एक्सपोर्ट करने की सुविधा देता है, जो वेब API, सर्वर‑साइड पाइपलाइन, या किसी भी स्थिति में उपयोगी है जहाँ आप फ़ाइल सिस्टम को छुए बिना XPS भेजना चाहते हैं।

**क्या छिपे हुए स्लाइड्स XPS में सम्मिलित होते हैं, और क्या मैं उन्हें बाहर रख सकता हूँ?**

डिफ़ॉल्ट रूप से, केवल सामान्य (दिखाई देने वाले) स्लाइड्स रेंडर होती हैं। आप [export settings](https://reference.aspose.com/slides/hi/java/com.aspose.slides/xpsoptions/) के माध्यम से [hidden slides को शामिल या बाहर रखना](https://reference.aspose.com/slides/hi/java/com.aspose.slides/xpsoptions/#setShowHiddenSlides-boolean-) कर सकते हैं, ताकि XPS में आउटपुट बिल्कुल वही पृष्ठ हों जो आप चाहते हैं।