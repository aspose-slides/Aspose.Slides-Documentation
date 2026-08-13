---
title: "C++ में PowerPoint प्रस्तुतियों को XPS में बदलें"
linktitle: "PowerPoint से XPS"
type: docs
weight: 70
url: /hi/cpp/convert-powerpoint-to-xps
keywords:
- PowerPoint बदलें
- प्रेजेंटेशन बदलें
- स्लाइड बदलें
- PPT बदलें
- PPTX बदलें
- PowerPoint से XPS
- प्रेजेंटेशन को XPS में बदलें
- स्लाइड को XPS में बदलें
- PPT को XPS में बदलें
- PPTX को XPS में बदलें
- PPT को XPS के रूप में सहेजें
- PPTX को XPS के रूप में सहेजें
- PPT को XPS में निर्यात करें
- PPTX को XPS में निर्यात करें
- PowerPoint
- प्रेजेंटेशन
- C++
- Aspose.Slides
description: "Aspose.Slides का उपयोग करके C++ में PowerPoint PPT/PPTX को उच्च गुणवत्ता, प्लेटफ़ॉर्म-स्वतंत्र XPS में बदलें। चरण-दर-चरण मार्गदर्शिका और नमूना कोड प्राप्त करें।"
---
## **अवलोकन**

Aspose.Slides आपको PowerPoint प्रस्तुतियों को XPS में बदलने की अनुमति देता है, PPT या PPTX फ़ाइल को XPS फ़ॉर्मेट में सहेजकर। यह लेख बताता है कि XPS फ़ॉर्मेट कब उपयोगी हो सकता है और Aspose.Slides के साथ डिफ़ॉल्ट सेटिंग्स या कस्टम [XpsOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/xpsoptions/) सेटिंग्स का उपयोग करके रूपांतरण कैसे किया जाए।

## **XPS के बारे में**

Microsoft ने [XPS](https://docs.fileformat.com/page-description-language/xps/) को [PDF](https://docs.fileformat.com/pdf/) का विकल्प बनाकर विकसित किया। यह आपको PDF के समान फ़ाइल आउटपुट करके सामग्री को प्रिंट करने की सुविधा देता है। XPS फ़ॉर्मेट XML पर आधारित है। XPS फ़ाइल की लेआउट या संरचना सभी ऑपरेटिंग सिस्टम और प्रिंटरों पर समान रहती है।

## **Microsoft XPS फ़ॉर्मेट कब उपयोग करें**

{{% alert color="info" %}} 

Aspose.Slides कैसे PPT या PPTX प्रस्तुति को XPS फ़ॉर्मेट में बदलता है, यह देखने के लिए आप [this free online converter app](https://products.aspose.app/slides/hi/conversion) देख सकते हैं। 

{{% /alert %}} 

यदि आप संग्रहण लागत घटाना चाहते हैं, तो आप अपनी Microsoft PowerPoint प्रस्तुति को XPS फ़ॉर्मेट में बदल सकते हैं। इस प्रकार, फ़ाइलों को सहेजना, साझा करना और प्रिंट करना आसान हो जाता है। 

Microsoft Windows (Windows 10 में भी) में XPS के लिए मजबूत समर्थन लागू करता रहता है, इसलिए आप फ़ाइलों को इस फ़ॉर्मेट में सहेजने पर विचार कर सकते हैं। यदि आप Windows 8.1, Windows 8, Windows 7 और Windows Vista के साथ काम कर रहे हैं, तो कुछ कार्यों के लिए XPS वास्तव में आपका सबसे अच्छा विकल्प हो सकता है। 

- **Windows 8** XPS फ़ाइलों के लिए OXPS (Open XPS) फ़ॉर्मेट का उपयोग करता है। OXPS मूल XPS फ़ॉर्मेट का मानकीकृत संस्करण है। Windows 8 PDF फ़ाइलों की तुलना में XPS फ़ाइलों को बेहतर समर्थन देता है। 
  - **XPS:** बिल्ट‑इन XPS व्यूअर/रीडर और XPS पर प्रिंट करने की सुविधा उपलब्ध। 
  - **PDF:** PDF रीडर उपलब्ध है लेकिन PDF पर प्रिंट करने की सुविधा नहीं। 

- **Windows 7 और Windows Vista** मूल XPS फ़ॉर्मेट का उपयोग करते हैं। ये ऑपरेटिंग सिस्टम भी PDF की तुलना में XPS फ़ाइलों को बेहतर समर्थन देते हैं। 
  - **XPS:** बिल्ट‑इन XPS व्यूअर और XPS पर प्रिंट करने की सुविधा उपलब्ध। 
  - **PDF:** PDF रीडर नहीं। PDF पर प्रिंट करने की सुविधा नहीं। 

|<p>**इनपुट PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**आउटपुट XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft ने अंततः Windows 10 में Print to PDF सुविधा के माध्यम से PDF में प्रिंट करने का समर्थन लागू किया। पहले, उपयोगकर्ताओं को दस्तावेज़ों को XPS फ़ॉर्मेट के माध्यम से प्रिंट करने की अपेक्षा की जाती थी। 

## **Aspose.Slides के साथ XPS रूपांतरण**

C++ के लिए [**Aspose.Slides**](https://products.aspose.com/slides/hi/cpp/) में आप [**Save**](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) मेथड का उपयोग करके [Presentation](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation) क्लास से पूरी प्रस्तुति को XPS दस्तावेज़ में बदल सकते हैं। 

प्रस्तुति को XPS में बदलते समय, आपको प्रस्तुति को निम्नलिखित सेटिंग्स में से किसी एक के साथ सहेजना होगा:

- डिफ़ॉल्ट सेटिंग्स (बिना [**XPSOptions**](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.export.xps_options) के)
- कस्टम सेटिंग्स (के साथ [**XPSOptions**](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.export.xps_options))

### **डिफ़ॉल्ट सेटिंग्स का उपयोग करके प्रस्तुतियों को XPS में बदलें**

यह C++ नमूना कोड आपको बताता है कि मानक सेटिंग्स का उपयोग करके प्रस्तुति को XPS दस्तावेज़ में कैसे बदलें:

``` cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// एक Presentation ऑब्जेक्ट बनाएं जो प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करता है
auto pres = System::MakeObject<Presentation>(u"Convert_XPS.pptx");
// प्रेजेंटेशन को XPS दस्तावेज़ में सहेजें
pres->Save(u"XPS_Output_Without_XPSOption_out.xps", SaveFormat::Xps);
```


### **कस्टम सेटिंग्स का उपयोग करके प्रस्तुतियों को XPS में बदलें**
यह नमूना कोड आपको बताता है कि C++ में कस्टम सेटिंग्स का उपयोग करके प्रस्तुति को XPS दस्तावेज़ में कैसे बदलें:

``` cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Export/XpsOptions.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// एक Presentation ऑब्जेक्ट बनाएं जो प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करता है
auto pres = System::MakeObject<Presentation>(u"Convert_XPS_Options.pptx");
// TiffOptions क्लास का उदाहरण बनाएं
auto options = System::MakeObject<XpsOptions>();

// मेटा फ़ाइलें PNG के रूप में सहेजें
options->set_SaveMetafilesAsPng(true);

// प्रेजेंटेशन को XPS दस्तावेज़ में सहेजें
pres->Save(u"XPS_With_Options_out.xps", SaveFormat::Xps, options);
```

## **अक्सर पूछे जाने वाले प्रश्न**

### क्या मैं फ़ाइल के बजाय स्ट्रीम में XPS सहेज सकता हूँ?

Yes—Aspose.Slides आपको सीधे स्ट्रीम में निर्यात करने देता है, जो वेब API, सर्वर‑साइड पाइपलाइन या किसी भी स्थिति के लिए आदर्श है जहाँ आप फ़ाइल सिस्टम को छुए बिना XPS भेजना चाहते हैं।

### क्या छिपी स्लाइड्स XPS में स्थानांतरित होती हैं, और क्या मैं उन्हें बाहर रख सकता हूँ?

डिफ़ॉल्ट रूप से केवल नियमित (दिखाई देने वाली) स्लाइड्स ही रेंडर होती हैं। आप [include or exclude hidden slides](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/xpsoptions/set_showhiddenslides/) को [export settings](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/xpsoptions/) के माध्यम से XPS में सहेजने से पहले नियंत्रित कर सकते हैं, जिससे आउटपुट में ठीक वही पृष्ठ हों जो आप चाहते हैं।