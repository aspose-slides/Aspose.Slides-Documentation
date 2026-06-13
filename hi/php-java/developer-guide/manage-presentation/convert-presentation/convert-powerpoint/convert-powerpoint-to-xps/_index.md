---
title: PHP में PowerPoint प्रस्तुतियों को XPS में परिवर्तित करें
linktitle: PowerPoint से XPS
type: docs
weight: 70
url: /hi/php-java/convert-powerpoint-to-xps/
keywords:
- PowerPoint रूपांतरित करें
- प्रस्तुति रूपांतरित करें
- स्लाइड रूपांतरित करें
- PPT रूपांतरित करें
- PPTX रूपांतरित करें
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
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java का उपयोग करके PowerPoint PPT/PPTX को उच्च-गुणवत्ता, प्लेटफ़ॉर्म-स्वतंत्र XPS में परिवर्तित करें। चरण-दर-चरण मार्गदर्शन और नमूना कोड प्राप्त करें।"
---
## **अवलोकन**

Aspose.Slides आपको PowerPoint प्रस्तुतियों को XPS में परिवर्तित करने की सुविधा देता है, PPT या PPTX फ़ाइल को XPS प्रारूप में सहेजकर। यह लेख बताता है कि XPS प्रारूप कब उपयोगी हो सकता है और Aspose.Slides का उपयोग करके डिफ़ॉल्ट सेटिंग्स या कस्टम [XpsOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/xpsoptions/) सेटिंग्स के साथ रूपांतरण कैसे करें।

## **XPS के बारे में**

Microsoft ने [XPS](https://docs.fileformat.com/page-description-language/xps/) को [PDF](https://docs.fileformat.com/pdf/) का विकल्प बनाकर विकसित किया। यह आपको PDF के समान फ़ाइल आउटपुट करके सामग्री को प्रिंट करने की अनुमति देता है। XPS प्रारूप XML पर आधारित है। XPS फ़ाइल की लेआउट या संरचना सभी ऑपरेटिंग सिस्टम और प्रिंटरों पर समान रहती है।

## **Microsoft XPS प्रारूप कब उपयोग करें**

{{% alert color="primary" %}} 

Aspose.Slides कैसे PPT या PPTX प्रस्तुति को XPS प्रारूप में बदलता है, यह देखने के लिए आप [इस मुफ्त ऑनलाइन कनवर्टर ऐप](https://products.aspose.app/slides/hi/conversion) को देख सकते हैं। 

{{% /alert %}} 

यदि आप स्टोरेज लागत कम करना चाहते हैं, तो आप अपनी Microsoft PowerPoint प्रस्तुति को XPS प्रारूप में बदल सकते हैं। इस तरह, आप अपने दस्तावेज़ों को सहेजना, साझा करना और प्रिंट करना आसान पाएँगे। 

Microsoft Windows (Windows 10 में भी) में XPS के लिए मजबूत समर्थन जारी रखता है, इसलिए आप फ़ाइलों को इस प्रारूप में सहेजने पर विचार कर सकते हैं। यदि आप Windows 8.1, Windows 8, Windows 7 और Windows Vista के साथ काम कर रहे हैं, तो कुछ कार्यों के लिए XPS वास्तव में आपका सबसे अच्छा विकल्प हो सकता है। 

- **Windows 8** OXPS (Open XPS) प्रारूप का उपयोग करता है। OXPS मूल XPS प्रारूप का मानकीकृत संस्करण है। Windows 8 XPS फ़ाइलों के लिए PDF फ़ाइलों की तुलना में बेहतर समर्थन प्रदान करता है। 
  - **XPS:** निर्मित XPS व्यूअर/रीडर और XPS पर प्रिंटिंग सुविधा उपलब्ध। 
  - **PDF:** PDF रीडर उपलब्ध है लेकिन PDF पर प्रिंटिंग सुविधा नहीं। 

- **Windows 7** और **Windows Vista** मूल XPS प्रारूप का उपयोग करते हैं। इन ऑपरेटिंग सिस्टम्स में भी PDF की तुलना में XPS फ़ाइलों के लिए बेहतर समर्थन है। 
  - **XPS:** निर्मित XPS व्यूअर और XPS पर प्रिंटिंग सुविधा उपलब्ध। 
  - **PDF:** कोई PDF रीडर नहीं। PDF पर प्रिंटिंग सुविधा नहीं। 

|<p>**इनपुट PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**आउटपुट XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |



Microsoft ने अंततः Windows 10 में Print to PDF सुविधा के माध्यम से PDF में प्रिंट करने की सुविधा लागू की। पहले, उपयोगकर्ताओं को दस्तावेज़ प्रिंट करने के लिए XPS प्रारूप का उपयोग करना पड़ता था। 

## **Aspose.Slides के साथ XPS रूपांतरण**

[**Aspose.Slides**](https://products.aspose.com/slides/hi/php-java/) for Java में, आप [**Save**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) मेथड का उपयोग कर सकते हैं, जो [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation) वर्ग द्वारा प्रदान किया गया है, ताकि पूरी प्रस्तुति को XPS दस्तावेज़ में बदल सकें।

एक प्रस्तुति को XPS में बदलते समय, आपको प्रस्तुति को निम्नलिखित सेटिंग्स में से किसी एक का उपयोग करके सहेजना होगा:

- डिफ़ॉल्ट सेटिंग्स (बिना [**XPSOptions**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/xpsoptions) के)
- कस्टम सेटिंग्स (साथ में [**XPSOptions**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/xpsoptions))

### **डिफ़ॉल्ट सेटिंग्स का उपयोग करके प्रस्तुतियों को XPS में परिवर्तित करें**

यह नमूना कोड दिखाता है कि मानक सेटिंग्स का उपयोग करके प्रस्तुति को XPS दस्तावेज़ में कैसे बदलें:

```php
  # एक Presentation ऑब्जेक्ट बनाएं जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
  $pres = new Presentation("Convert_XPS.pptx");
  try {
    # प्रस्तुति को XPS दस्तावेज़ में सहेजना
    $pres->save("XPS_Output_Without_XPSOption.xps", SaveFormat::Xps);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **कस्टम सेटिंग्स का उपयोग करके प्रस्तुतियों को XPS में परिवर्तित करें**

यह नमूना कोड दिखाता है कि कस्टम सेटिंग्स का उपयोग करके प्रस्तुति को XPS दस्तावेज़ में कैसे बदलें :

```php
  # एक Presentation ऑब्जेक्ट बनाएं जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
  $pres = new Presentation("Convert_XPS_Options.pptx");
  try {
    # TiffOptions क्लास का इंस्टैंस बनाएं
    $options = new XpsOptions();
    # MetaFiles को PNG के रूप में सहेजें
    $options->setSaveMetafilesAsPng(true);
    # प्रस्तुति को XPS दस्तावेज़ में सहेजें
    $pres->save("XPS_Output_With_Options.xps", SaveFormat::Xps, $options);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं XPS को फ़ाइल के बजाय स्ट्रीम में सहेज सकता हूँ?**

हां—Aspose.Slides आपको सीधे स्ट्रीम में निर्यात करने देता है, जो वेब API, सर्वर‑साइड पाइपलाइन या किसी भी परिस्थिति में उपयोगी है जहाँ आप फ़ाइल सिस्टम को छुए बिना XPS भेजना चाहते हैं।

**क्या छिपी स्लाइड्स XPS में ले जाई जाती हैं, और क्या मैं उन्हें बाहर कर सकता हूँ?**

डिफ़ॉल्ट रूप से केवल नियमित (दर्शनीय) स्लाइड्स ही रेंडर होती हैं। आप [छिपी स्लाइड्स को शामिल या बाहर करने](https://reference.aspose.com/slides/hi/php-java/aspose.slides/xpsoptions/setshowhiddenslides/) के लिए [निर्यात सेटिंग्स](https://reference.aspose.com/slides/hi/php-java/aspose.slides/xpsoptions/) का उपयोग करके XPS में सहेजने से पहले वांछित पृष्ठों को सुनिश्चित कर सकते हैं।