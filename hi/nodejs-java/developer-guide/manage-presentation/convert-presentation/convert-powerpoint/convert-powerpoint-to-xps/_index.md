---
title: "JavaScript में PowerPoint प्रस्तुतियों को XPS में बदलें"
linktitle: "PowerPoint से XPS"
type: docs
weight: 70
url: /hi/nodejs-java/convert-powerpoint-to-xps/
keywords:
- "PowerPoint को बदलें"
- "प्रस्तुति को बदलें"
- "स्लाइड को बदलें"
- "PPT को बदलें"
- "PPTX को बदलें"
- "PowerPoint से XPS"
- "प्रस्तुति को XPS"
- "स्लाइड को XPS"
- "PPT को XPS"
- "PPTX को XPS"
- "PPT को XPS के रूप में सहेजें"
- "PPTX को XPS के रूप में सहेजें"
- "PPT को XPS में निर्यात करें"
- "PPTX को XPS में निर्यात करें"
- "PowerPoint"
- "प्रस्तुति"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Aspose.Slides for Node.js का उपयोग करके JavaScript में PowerPoint PPT/PPTX को उच्च‑गुणवत्ता, प्लेटफ़ॉर्म‑स्वतंत्र XPS में बदलें। चरण‑दर‑चरण मार्गदर्शिका और नमूना कोड प्राप्त करें।"
---
## **Overview**

Aspose.Slides आपको PPT या PPTX फ़ाइल को XPS प्रारूप में सहेज कर PowerPoint प्रस्तुतियों को XPS में परिवर्तित करने की अनुमति देता है। यह लेख बताता है कि XPS प्रारूप कब उपयोगी हो सकता है और Aspose.Slides का उपयोग करके डिफ़ॉल्ट सेटिंग्स या कस्टम [XpsOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/xpsoptions/) सेटिंग्स के साथ परिवर्तन कैसे किया जाता है।

## **About XPS**

Microsoft ने [XPS](https://docs.fileformat.com/page-description-language/xps/) को [PDF](https://docs.fileformat.com/pdf/) का विकल्प बनाने के लिए विकसित किया। यह PDF के समान एक फ़ाइल आउटपुट करके सामग्री को प्रिंट करने की सुविधा देता है। XPS प्रारूप XML पर आधारित है। XPS फ़ाइल की लेआउट या संरचना सभी ऑपरेटिंग सिस्टम और प्रिंटरों पर समान रहती है।

## **When to Use Microsoft XPS Format**

{{% alert color="primary" %}} 

Aspose.Slides कैसे PPT या PPTX प्रस्तुति को XPS प्रारूप में बदलता है, इसे देखने के लिए आप [this free online converter app](https://products.aspose.app/slides/hi/conversion) पर जा सकते हैं। 

{{% /alert %}} 

यदि आप स्टोरेज लागत को कम करना चाहते हैं, तो आप अपनी Microsoft PowerPoint प्रस्तुति को XPS प्रारूप में बदल सकते हैं। इस तरह, आपके दस्तावेज़ों को सहेजना, साझा करना और प्रिंट करना आसान हो जाएगा।

Microsoft Windows (Windows 10 सहित) में XPS के लिए मजबूत समर्थन जारी रखता है, इसलिए आप फ़ाइलों को इस प्रारूप में सहेजने पर विचार कर सकते हैं। यदि आप Windows 8.1, Windows 8, Windows 7 और Windows Vista के साथ काम कर रहे हैं, तो XPS कुछ कार्यों के लिए आपका सबसे अच्छा विकल्प हो सकता है।

- **Windows 8** XPS फ़ाइलों के लिए OXPS (Open XPS) प्रारूप का उपयोग करता है। OXPS मूल XPS प्रारूप का मानकीकृत संस्करण है। Windows 8 XPS फ़ाइलों के लिए PDF फ़ाइलों की तुलना में बेहतर समर्थन प्रदान करता है। 
  - **XPS:** बिल्ट‑इन XPS व्यूअर/रीडर और XPS पर प्रिंट करने की सुविधा उपलब्ध। 
  - **PDF:** PDF रीडर उपलब्ध है लेकिन PDF पर प्रिंट करने की सुविधा नहीं। 

- **Windows 7 और Windows Vista** मूल XPS प्रारूप का उपयोग करते हैं। ये ऑपरेटिंग सिस्टम भी PDF की तुलना में XPS फ़ाइलों के लिए बेहतर समर्थन प्रदान करते हैं। 
  - **XPS:** बिल्ट‑इन XPS व्यूअर और XPS पर प्रिंट करने की सुविधा उपलब्ध। 
  - **PDF:** कोई PDF रीडर नहीं। PDF पर प्रिंट करने की सुविधा नहीं। 

|<p>**इनपुट PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**आउटपुट XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft ने Windows 10 में Print to PDF सुविधा के माध्यम से PDF में प्रिंट ऑपरेशनों के समर्थन को अंततः लागू किया। पहले, उपयोगकर्ताओं को दस्तावेज़ों को XPS प्रारूप के माध्यम से प्रिंट करने की अपेक्षा की जाती थी।

## **XPS Conversion with Aspose.Slides**

[**Aspose.Slides for Node.js via Java**](https://products.aspose.com/slides/hi/nodejs-java/) में आप [**save**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-) मेथड का उपयोग करके [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास से पूरी प्रस्तुति को XPS दस्तावेज़ में परिवर्तित कर सकते हैं।

जब आप प्रस्तुति को XPS में बदलते हैं, तो आपको प्रस्तुति को निम्नलिखित सेटिंग्स में से किसी एक के साथ सहेजना होगा:

- डिफ़ॉल्ट सेटिंग्स (बिना [**XPSOptions**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/xpsoptions) के)
- कस्टम सेटिंग्स (साथ में [**XPSOptions**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/xpsoptions))

### **Converting Presentations to XPS Using Default Settings**

यह JavaScript नमूना कोड आपको मानक सेटिंग्स का उपयोग करके प्रस्तुति को XPS दस्तावेज़ में बदलना दिखाता है:

```javascript
// एक Presentation ऑब्जेक्ट को इंस्टैंटिएट करें जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
var pres = new aspose.slides.Presentation("Convert_XPS.pptx");
try {
    // प्रस्तुति को XPS दस्तावेज़ में सहेज रहा है
    pres.save("XPS_Output_Without_XPSOption.xps", aspose.slides.SaveFormat.Xps);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Converting Presentations to XPS Using Custom Settings**

यह नमूना कोड आपको कस्टम सेटिंग्स के साथ JavaScript में प्रस्तुति को XPS दस्तावेज़ में बदलना दिखाता है:

```javascript
// एक Presentation ऑब्जेक्ट को इंस्टैंटिएट करें जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
var pres = new aspose.slides.Presentation("Convert_XPS_Options.pptx");
try {
    // TiffOptions क्लास को इंस्टैंटिएट करें
    var options = new aspose.slides.XpsOptions();
    // MetaFiles को PNG के रूप में सहेजें
    options.setSaveMetafilesAsPng(true);
    // प्रेजेंटेशन को XPS दस्तावेज़ में सहेजें
    pres.save("XPS_Output_With_Options.xps", aspose.slides.SaveFormat.Xps, options);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**क्या मैं फ़ाइल की बजाय स्ट्रीम में XPS सहेज सकता हूँ?**

हां—Aspose.Slides आपको सीधे स्ट्रीम में एक्सपोर्ट करने की अनुमति देता है, जो वेब API, सर्वर‑साइड पाइपलाइन या किसी भी परिदृश्य के लिए उपयुक्त है जहाँ आप फ़ाइल सिस्टम को छुए बिना XPS भेजना चाहते हैं।

**क्या छिपी हुई स्लाइड्स XPS में शामिल होती हैं, और क्या मैं उन्हें बाहर रख सकता हूँ?**

डिफ़ॉल्ट रूप से केवल नियमित (दृश्यमान) स्लाइड्स रेंडर की जाती हैं। आप [export settings](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/xpsoptions/) के माध्यम से [hidden slides को शामिल या बाहर रख सकते हैं](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/xpsoptions/setshowhiddenslides/), जिससे सहेजते समय आउटपुट में ठीक वही पृष्ठ हों जो आप चाहते हैं।