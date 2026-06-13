---
title: C++ में PowerPoint प्रस्तुतियों को XPS में बदलें
linktitle: PowerPoint से XPS
type: docs
weight: 70
url: /hi/cpp/convert-powerpoint-to-xps
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
- C++
- Aspose.Slides
description: "Aspose.Slides का उपयोग करके C++ में PowerPoint PPT/PPTX को उच्च गुणवत्ता, प्लेटफ़ॉर्म-स्वतंत्र XPS में बदलें। चरण-दर-चरण गाइड और नमूना कोड प्राप्त करें।"
---
## **अवलोकन**

Aspose.Slides आपको PowerPoint प्रस्तुतियों को XPS में बदलने की अनुमति देता है, PPT या PPTX फ़ाइल को XPS फ़ॉर्मेट में सहेजकर। यह लेख बताता है कि XPS फ़ॉर्मेट कब उपयोगी हो सकता है और दिखाता है कि Aspose.Slides का उपयोग करके डिफ़ॉल्ट सेटिंग्स या कस्टम [XpsOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/xpsoptions/) सेटिंग्स के साथ रूपांतरण कैसे किया जाए।

## **XPS के बारे में**

Microsoft ने [XPS](https://docs.fileformat.com/page-description-language/xps/) को [PDF](https://docs.fileformat.com/pdf/) के विकल्प के रूप में विकसित किया। यह आपको सामग्री को PDF के बहुत समान फ़ाइल के रूप में आउटपुट करके प्रिंट करने की सुविधा देता है। XPS फ़ॉर्मेट XML पर आधारित है। XPS फ़ाइल की लेआउट या संरचना सभी ऑपरेटिंग सिस्टम और प्रिंटरों पर समान रहती है।

## **Microsoft XPS फ़ॉर्मेट कब उपयोग करें**

{{% alert color="primary" %}} 

यह देखने के लिए कि Aspose.Slides PPT या PPTX प्रस्तुतियों को XPS फ़ॉर्मेट में कैसे परिवर्तित करता है, आप [यह मुफ्त ऑनलाइन परिवर्तक एप](https://products.aspose.app/slides/hi/conversion) को देख सकते हैं। 

{{% /alert %}} 

यदि आप संग्रहण लागत को कम करना चाहते हैं, तो आप अपनी Microsoft PowerPoint प्रस्तुति को XPS फ़ॉर्मेट में बदल सकते हैं। इस तरह, आपको दस्तावेज़ सहेजना, साझा करना और प्रिंट करना आसान लगेगा। 

Microsoft Windows (Windows 10 सहित) में XPS के लिए मजबूत समर्थन जारी रखता है, इसलिए आप फ़ाइलों को इस फ़ॉर्मेट में सहेजने पर विचार कर सकते हैं। यदि आप Windows 8.1, Windows 8, Windows 7 और Windows Vista के साथ काम कर रहे हैं, तो XPS कुछ कामों के लिए आपका सबसे अच्छा विकल्प हो सकता है। 

- **Windows 8** XPS फ़ाइलों के लिए OXPS (Open XPS) फ़ॉर्मेट का उपयोग करता है। OXPS मूल XPS फ़ॉर्मेट का मानकीकृत संस्करण है। Windows 8 XPS फ़ाइलों के लिए PDF फ़ाइलों की तुलना में बेहतर समर्थन प्रदान करता है। 
  - **XPS:** अंतर्निर्मित XPS व्यूअर/रीडर और XPS प्रिंट करने की सुविधा उपलब्ध है। 
  - **PDF:** PDF रीडर उपलब्ध है लेकिन PDF प्रिंट करने की सुविधा नहीं है। 

- **Windows 7 and Windows Vista** मूल XPS फ़ॉर्मेट का उपयोग करते हैं। ये ऑपरेटिंग सिस्टम भी PDF की तुलना में XPS फ़ाइलों के लिए बेहतर समर्थन देते हैं। 
  - **XPS:** अंतर्निर्मित XPS व्यूअर और XPS प्रिंट करने की सुविधा उपलब्ध है। 
  - **PDF:** कोई PDF रीडर नहीं। कोई PDF प्रिंट करने की सुविधा नहीं। 

|<p>**इनपुट PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**आउटपुट XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft ने अंततः Windows 10 में Print to PDF सुविधा के माध्यम से PDF में प्रिंट करने का समर्थन लागू किया। पहले उपयोगकर्ताओं को दस्तावेज़ों को XPS फ़ॉर्मेट के माध्यम से प्रिंट करने की अपेक्षा थी। 

## **Aspose.Slides के साथ XPS रूपांतरण**

C++ के लिए [**Aspose.Slides**](https://products.aspose.com/slides/hi/cpp/) में, आप [**Save**](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) मेथड को [Presentation](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation) क्लास से एक्सपोज़ करके पूरी प्रस्तुति को XPS दस्तावेज़ में बदल सकते हैं। 

जब आप प्रस्तुति को XPS में बदल रहे हों, तो आप इसे निम्नलिखित सेटिंग्स में से किसी एक के साथ सहेजना होगा:

- डिफ़ॉल्ट सेटिंग्स (बिना [**XPSOptions**](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.export.xps_options) के)
- कस्टम सेटिंग्स (के साथ [**XPSOptions**](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.export.xps_options))

### **डिफ़ॉल्ट सेटिंग्स का उपयोग करके प्रस्तुतियों को XPS में बदलें**

यह C++ में नमूना कोड दिखाता है कि मानक सेटिंग्स का उपयोग करके प्रस्तुति को XPS दस्तावेज़ में कैसे बदला जाता है:

``` cpp
// एक Presentation ऑब्जेक्ट को इंस्टैंशिएट करें जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
auto pres = System::MakeObject<Presentation>(u"Convert_XPS.pptx");
// प्रस्तुति को XPS दस्तावेज़ में सहेजना
pres->Save(u"XPS_Output_Without_XPSOption_out.xps", SaveFormat::Xps);
```

### **कस्टम सेटिंग्स का उपयोग करके प्रस्तुतियों को XPS में बदलें**

यह नमूना कोड दिखाता है कि C++ में कस्टम सेटिंग्स का उपयोग करके प्रस्तुति को XPS दस्तावेज़ में कैसे बदला जाता है:

``` cpp
// एक Presentation ऑब्जेक्ट को इंस्टैंशिएट करें जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
auto pres = System::MakeObject<Presentation>(u"Convert_XPS_Options.pptx");
// TiffOptions क्लास को इंस्टैंशिएट करें
auto options = System::MakeObject<XpsOptions>();

// MetaFiles को PNG के रूप में सहेजें
options->set_SaveMetafilesAsPng(true);

// प्रस्तुति को XPS दस्तावेज़ में सहेजें
pres->Save(u"XPS_With_Options_out.xps", SaveFormat::Xps, options);
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं फ़ाइल के बजाय स्ट्रीम में XPS सहेज सकता हूँ?**

हाँ—Aspose.Slides आपको सीधे स्ट्रीम में निर्यात करने की अनुमति देता है, जो वेब API, सर्वर‑साइड पाइपलाइन या किसी भी परिदृश्य के लिए आदर्श है जहाँ आप XPS को फ़ाइल सिस्टम को छुए बिना भेजना चाहते हैं।

**क्या छिपी स्लाइड्स XPS में शामिल होती हैं, और क्या मैं उन्हें बाहर रख सकता हूँ?**

डिफ़ॉल्ट रूप से केवल नियमित (दृश्यमान) स्लाइड्स रेंडर की जाती हैं। आप [छिपी स्लाइड्स को शामिल या बाहर रखें](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/xpsoptions/set_showhiddenslides/) को [निर्यात सेटिंग्स](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/xpsoptions/) के माध्यम से XPS में सहेजने से पहले उपयोग करके सुनिश्चित कर सकते हैं कि आउटपुट में ठीक वही पृष्ठ हों जो आप चाहते हैं।