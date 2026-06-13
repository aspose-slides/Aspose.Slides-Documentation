---
title: ".NET में PowerPoint प्रस्तुतियों को XPS में बदलें"
linktitle: "PowerPoint से XPS"
type: docs
weight: 70
url: /hi/net/convert-powerpoint-to-xps/
keywords:
- "PowerPoint को परिवर्तित करें"
- "प्रस्तुति को परिवर्तित करें"
- "स्लाइड को परिवर्तित करें"
- "PPT को परिवर्तित करें"
- "PPTX को परिवर्तित करें"
- "PowerPoint से XPS"
- "प्रस्तुति से XPS"
- "स्लाइड से XPS"
- "PPT से XPS"
- "PPTX से XPS"
- "PPT को XPS के रूप में सहेजें"
- "PPTX को XPS के रूप में सहेजें"
- "PPT को XPS में निर्यात करें"
- "PPTX को XPS में निर्यात करें"
- "PowerPoint"
- "प्रस्तुति"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides का उपयोग करके .NET में PowerPoint PPT/PPTX को उच्च-गुणवत्ता, प्लेटफ़ॉर्म-स्वतंत्र XPS में बदलें। चरण-दर-चरण गाइड और नमूना C# कोड प्राप्त करें।"
---
## **परिचय**

Aspose.Slides आपको PowerPoint प्रस्तुतियों को XPS में बदलने की अनुमति देता है, PPT या PPTX फ़ाइल को XPS फ़ॉर्मेट में सहेजकर। यह लेख बताता है कि XPS फ़ॉर्मेट कब उपयोगी हो सकता है और Aspose.Slides के साथ डिफ़ॉल्ट सेटिंग्स या कस्टम [XpsOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/xpsoptions/) सेटिंग्स का उपयोग करके रूपांतरण कैसे किया जाए।

## **XPS के बारे में**

Microsoft ने [XPS](https://docs.fileformat.com/page-description-language/xps/) को [PDF](https://docs.fileformat.com/pdf/) का विकल्प के रूप में विकसित किया। यह आपको सामग्री को PDF के समान फ़ाइल आउटपुट करके प्रिंट करने की सुविधा देता है। XPS फ़ॉर्मेट XML पर आधारित है। XPS फ़ाइल की लेआउट या संरचना सभी ऑपरेटिंग सिस्टम और प्रिंटरों पर समान रहती है। 

## **Microsoft XPS फ़ॉर्मेट कब उपयोग करें**

{{% alert color="primary" %}} 

यह देखने के लिए कि Aspose.Slides PPT या PPTX प्रस्तुति को XPS फ़ॉर्मेट में कैसे बदलता है, आप [इस मुफ्त ऑनलाइन कनवर्टर एप्लिकेशन](https://products.aspose.app/slides/hi/conversion) को देख सकते हैं। 

{{% /alert %}} 

यदि आप संग्रहण लागत कम करना चाहते हैं, तो आप अपनी Microsoft PowerPoint प्रस्तुति को XPS फ़ॉर्मेट में बदल सकते हैं। इस तरह, दस्तावेज़ों को सहेजना, साझा करना और प्रिंट करना आसान हो जाएगा। 

Microsoft विंडोज (यहां तक कि Windows 10 में भी) में XPS के लिए मजबूत समर्थन लागू करता रहता है, इसलिए आप फ़ाइलों को इस फ़ॉर्मेट में सहेजने पर विचार कर सकते हैं। यदि आप Windows 8.1, Windows 8, Windows 7 और Windows Vista के साथ काम कर रहे हैं, तो कुछ संचालन के लिए XPS आपके लिए सबसे अच्छा विकल्प हो सकता है। 

- **Windows 8** XPS फ़ाइलों के लिए OXPS (Open XPS) फ़ॉर्मेट का उपयोग करता है। OXPS मूल XPS फ़ॉर्मेट का मानकीकृत संस्करण है। Windows 8 XPS फ़ाइलों के लिए PDF फ़ाइलों की तुलना में बेहतर समर्थन प्रदान करता है। 
  - **XPS:** अंतर्निहित XPS व्यूअर/रीडर और XPS में प्रिंट करने की सुविधा उपलब्ध है। 
  - **PDF**: PDF रीडर उपलब्ध है लेकिन PDF में प्रिंट करने की सुविधा नहीं है। 

- **Windows 7 और Windows Vista** मूल XPS फ़ॉर्मेट का उपयोग करते हैं। ये ऑपरेटिंग सिस्टम भी PDF की तुलना में XPS फ़ाइलों के लिए बेहतर समर्थन प्रदान करते हैं। 
  - **XPS**: अंतर्निहित XPS व्यूअर और XPS में प्रिंट करने की सुविधा उपलब्ध है। 
  - **PDF**: PDF रीडर नहीं है। PDF में प्रिंट करने की सुविधा नहीं है। 

|<p>**इनपुट PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**आउटपुट XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft ने अंततः Windows 10 में Print to PDF सुविधा के माध्यम से PDF में प्रिंटिंग संचालन का समर्थन लागू किया। पहले, उपयोगकर्ताओं को दस्तावेज़ों को XPS फ़ॉर्मेट के माध्यम से प्रिंट करना अपेक्षित था। 

## **Aspose.Slides के साथ XPS रूपांतरण**

.NET के लिए [**Aspose.Slides**](https://products.aspose.com/slides/hi/net/) में, आप [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास द्वारा उजागर किए गए [**Save**](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/methods/save/index) मेथड का उपयोग करके पूरी प्रस्तुति को XPS दस्तावेज़ में बदल सकते हैं। 

जब प्रस्तुति को XPS में रूपांतरित किया जाता है, तो आपको प्रस्तुति को इन सेटिंग्स में से किसी एक का उपयोग करके सहेजना होगा:
- डिफ़ॉल्ट सेटिंग्स (बिना [**XPSOptions**](https://reference.aspose.com/slides/hi/net/aspose.slides.export/xpsoptions) के)
- कस्टम सेटिंग्स (साथ में [**XPSOptions**](https://reference.aspose.com/slides/hi/net/aspose.slides.export/xpsoptions))

### **डिफ़ॉल्ट सेटिंग्स का उपयोग करके प्रस्तुतियों को XPS में बदलना**

यह C# नमूना कोड आपको दिखाता है कि मानक सेटिंग्स का उपयोग करके प्रस्तुति को XPS दस्तावेज़ में कैसे बदला जाए:

```c#
 // एक Presentation ऑब्जेक्ट बनाएं जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
using (Presentation pres = new Presentation("Convert_XPS.pptx"))
{
    // प्रस्तुति को XPS दस्तावेज़ में सहेजा जा रहा है
    pres.Save("XPS_Output_Without_XPSOption_out.xps", SaveFormat.Xps);
}
```

### **कस्टम सेटिंग्स का उपयोग करके प्रस्तुतियों को XPS में बदलना**

यह नमूना कोड आपको दिखाता है कि C# में कस्टम सेटिंग्स का उपयोग करके प्रस्तुति को XPS दस्तावेज़ में कैसे बदला जाए:

```c#
 // एक Presentation ऑब्जेक्ट बनाएं जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
using (Presentation pres = new Presentation("Convert_XPS_Options.pptx"))
{
    // TiffOptions क्लास को इनस्टैंशिएट करें
    XpsOptions options = new XpsOptions();

    // MetaFiles को PNG के रूप में सहेजें
    options.SaveMetafilesAsPng = true;

    // प्रस्तुति को XPS दस्तावेज़ में सहेजें
    pres.Save("XPS_With_Options_out.xps", SaveFormat.Xps, options);
}
```

## **FAQ**

**क्या मैं फ़ाइल के बजाय एक स्ट्रीम में XPS सहेज सकता हूँ?**

हाँ—Aspose.Slides आपको सीधे स्ट्रीम में निर्यात करने देता है, जो वेब API, सर्वर-साइड पाइपलाइन्स, या किसी भी स्थिति में आदर्श है जहाँ आप फ़ाइल सिस्टम को छुए बिना XPS भेजना चाहते हैं।

**क्या छिपी हुई स्लाइड्स XPS में भी शामिल होती हैं, और क्या मैं उन्हें बाहर रख सकता हूँ?**

डिफ़ॉल्ट रूप से, केवल सामान्य (दृश्यमान) स्लाइड्स रेंडर की जाती हैं। आप XPS में सहेजने से पहले [एक्सपोर्ट सेटिंग्स](https://reference.aspose.com/slides/hi/net/aspose.slides.export/xpsoptions/) के माध्यम से छिपी हुई स्लाइड्स को [शामिल या बाहर कर सकते हैं](https://reference.aspose.com/slides/hi/net/aspose.slides.export/xpsoptions/showhiddenslides/), जिससे आउटपुट में ठीक वही पृष्ठ हों जो आप चाहते हैं।