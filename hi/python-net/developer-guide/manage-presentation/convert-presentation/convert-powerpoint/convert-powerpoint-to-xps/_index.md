---
title: Python में PowerPoint प्रस्तुतियों को XPS में बदलें
linktitle: PowerPoint से XPS
type: docs
weight: 70
url: /hi/python-net/convert-powerpoint-to-xps/
keywords:
- PowerPoint रूपांतरित करें
- प्रस्तुति रूपांतरित करें
- PowerPoint से XPS
- प्रस्तुति से XPS
- PPT से XPS
- PPTX से XPS
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides का उपयोग करके Python में PowerPoint PPT/PPTX को उच्च गुणवत्ता वाला, प्लेटफ़ॉर्म‑स्वतंत्र XPS में बदलें। चरण‑दर‑चरण मार्गदर्शिका और नमूना कोड प्राप्त करें।"
---
## **अवलोकन**

Aspose.Slides आपको PPT या PPTX फ़ाइल को XPS प्रारूप में सहेजकर PowerPoint प्रस्तुतियों को XPS में परिवर्तित करने की सुविधा देता है। यह लेख बताता है कि XPS प्रारूप कब उपयोगी हो सकता है और Aspose.Slides का उपयोग करके डिफ़ॉल्ट सेटिंग्स या कस्टम [XpsOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/xpsoptions/) सेटिंग्स के साथ रूपांतरण कैसे किया जाता है।

## **XPS के बारे में**
Microsoft ने [XPS](https://docs.fileformat.com/page-description-language/xps/) को [PDF](https://docs.fileformat.com/pdf/) का विकल्प बनाने के लिए विकसित किया। यह PDF के समान एक फ़ाइल आउटपुट करके सामग्री को प्रिंट करने की अनुमति देता है। XPS प्रारूप XML पर आधारित है। XPS फ़ाइल का लेआउट या संरचना सभी ऑपरेटिंग सिस्टम और प्रिंटरों पर समान रहती है।

## Microsoft XPS प्रारूप कब उपयोग करें

{{% alert color="primary" %}} 

Aspose.Slides कैसे PPT या PPTX प्रस्तुति को XPS प्रारूप में बदलता है, यह देखने के लिए आप [इस मुफ्त ऑनलाइन कनवर्टर ऐप](https://products.aspose.app/slides/hi/conversion) की जाँच कर सकते हैं। 

{{% /alert %}} 

यदि आप स्टोरेज लागत को कम करना चाहते हैं, तो आप अपनी Microsoft PowerPoint प्रस्तुति को XPS प्रारूप में बदल सकते हैं। इस तरह, आप अपने दस्तावेज़ों को सहेजना, साझा करना और प्रिंट करना आसान पाएँगे।

Microsoft Windows (यहाँ तक कि Windows 10 में भी) में XPS के लिए मजबूत समर्थन जारी रखता है, इसलिए आप फ़ाइलों को इस प्रारूप में सहेजने पर विचार कर सकते हैं। यदि आप Windows 8.1, Windows 8, Windows 7, और Windows Vista के साथ काम कर रहे हैं, तो XPS कुछ कार्यों के लिए आपका श्रेष्ठ विकल्प हो सकता है।

- **Windows 8** XPS फ़ाइलों के लिए OXPS (Open XPS) प्रारूप का उपयोग करता है। OXPS मूल XPS प्रारूप का मानकीकृत संस्करण है। Windows 8 PDF फ़ाइलों की तुलना में XPS फ़ाइलों के लिए बेहतर समर्थन प्रदान करता है। 
  - **XPS:** बिल्ट‑इन XPS व्यूअर/रीडर और XPS पर प्रिंटिंग सुविधा उपलब्ध। 
  - **PDF:** PDF रीडर उपलब्ध है लेकिन PDF पर प्रिंटिंग सुविधा नहीं। 

- **Windows 7 और Windows Vista** मूल XPS प्रारूप का उपयोग करते हैं। ये ऑपरेटिंग सिस्टम भी PDF की तुलना में XPS फ़ाइलों के लिए बेहतर समर्थन प्रदान करते हैं। 
  - **XPS:** बिल्ट‑इन XPS व्यूअर और XPS पर प्रिंटिंग सुविधा उपलब्ध। 
  - **PDF:** PDF रीडर नहीं। PDF पर प्रिंटिंग सुविधा नहीं। 

|<p>**इनपुट PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**आउटपुट XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |



Microsoft ने अंततः Windows 10 में Print to PDF सुविधा के माध्यम से PDF में प्रिंटिंग संचालन के लिए समर्थन लागू किया। पहले, उपयोगकर्ताओं को दस्तावेज़ों को XPS प्रारूप के माध्यम से प्रिंट करने की अपेक्षा की जाती थी। 

## Aspose.Slides के साथ XPS रूपांतरण

.NET के लिए [**Aspose.Slides**](https://products.aspose.com/slides/hi/python-net/) में, आप [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) वर्ग द्वारा प्रदान किए गए [**Save**](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) मेथड का उपयोग करके पूरी प्रस्तुति को XPS दस्तावेज़ में बदल सकते हैं। 

जब आप प्रस्तुति को XPS में बदलते हैं, तो आपको प्रस्तुति को निम्नलिखित सेटिंग्स में से किसी एक का उपयोग करके सहेजना होगा:

- डिफ़ॉल्ट सेटिंग्स (बिना [**XPSOptions**](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/xpsoptions/) के)
- कस्टम सेटिंग्स (साथ में [**XPSOptions**](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/xpsoptions/))

### **डिफ़ॉल्ट सेटिंग्स का उपयोग करके प्रस्तुतियों को XPS में बदलना**

Python में यह उदाहरण कोड दर्शाता है कि कैसे मानक सेटिंग्स का उपयोग करके प्रस्तुति को XPS दस्तावेज़ में बदला जा सकता है:

```py
import aspose.slides as slides

# एक Presentation वस्तु बनाएं जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करती है
pres = slides.Presentation("Convert_XPS.pptx")

# प्रस्तुति को XPS दस्तावेज़ में सहेजा जा रहा है
pres.save("XPS_Output_Without_XPSOption_out.xps", slides.export.SaveFormat.XPS)
```


### **कस्टम सेटिंग्स का उपयोग करके प्रस्तुतियों को XPS में बदलना**
यह उदाहरण कोड दर्शाता है कि कैसे Python में कस्टम सेटिंग्स का उपयोग करके प्रस्तुति को XPS दस्तावेज़ में बदला जाए:

```py
import aspose.slides as slides

# एक Presentation वस्तु बनाएं जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करती है
pres = slides.Presentation("Convert_XPS_Options.pptx")

# TiffOptions क्लास का एक उदाहरण बनाएं
options = slides.export.XpsOptions()

# MetaFiles को PNG के रूप में सहेजें
options.save_metafiles_as_png = True

# प्रस्तुति को XPS दस्तावेज़ में सहेजें
pres.save("XPS_With_Options_out.xps", slides.export.SaveFormat.XPS, options)
```

## **FAQ**

**क्या मैं फ़ाइल की बजाय स्ट्रीम में XPS सहेज सकता हूँ?**

हाँ—Aspose.Slides आपको सीधे स्ट्रीम में निर्यात करने की अनुमति देता है, जो वेब API, सर्वर‑साइड पाइपलाइन, या किसी भी स्थिति के लिए आदर्श है जहाँ आपको फ़ाइल सिस्टम को छुए बिना XPS भेजना हो।

**क्या छिपी हुई स्लाइड्स XPS में शामिल होती हैं, और क्या मैं उन्हें बाहर रख सकता हूँ?**

डिफ़ॉल्ट रूप से केवल सामान्य (दृश्यमान) स्लाइड्स रेंडर होती हैं। आप [छिपी हुई स्लाइड्स को शामिल या बाहर रख सकते हैं](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/xpsoptions/show_hidden_slides/) [निर्यात सेटिंग्स](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/xpsoptions/) के माध्यम से XPS में सहेजने से पहले, जिससे आउटपुट में बिल्कुल वही पृष्ठ हों जो आप चाहते हैं।