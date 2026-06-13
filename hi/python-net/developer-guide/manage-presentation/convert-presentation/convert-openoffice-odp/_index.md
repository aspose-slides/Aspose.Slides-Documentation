---
title: Python में OpenDocument प्रस्तुतियाँ परिवर्तित करें
linktitle: OpenDocument परिवर्तित करें
type: docs
weight: 10
url: /hi/python-net/convert-openoffice-odp/
keywords:
- OpenDocument परिवर्तित करें
- ODP परिवर्तित करें
- ODP से PDF
- ODP से PPT
- ODP से PPTX
- ODP से XPS
- ODP से HTML
- ODP से TIFF
- ODP से SWF
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Python में Aspose.Slides के साथ OpenDocument ODP को PDF, PPT, PPTX, XPS, HTML, TIFF या SWF में परिवर्तित करें: कोड उदाहरण, उच्च सटीकता, बैच रूपांतरण, और अनुकूलन।"
---
## **परिचय**

[**Aspose.Slides API**](https://products.aspose.com/slides/hi/python-net/) आपको OpenDocument (ODP) प्रस्तुतियों को कई फॉर्मैट (HTML, PDF, TIFF, SWF, XPS, आदि) में बदलने की अनुमति देता है। ODP फ़ाइलों को अन्य दस्तावेज़ फॉर्मैट में बदलने के लिए प्रयुक्त API वही है जो PowerPoint (PPT और PPTX) रूपांतरण संचालन के लिए उपयोग की जाती है।

उदाहरण के लिए, यदि आपको ODP प्रस्तुति को PDF में बदलना हो, तो आप इसे इस प्रकार कर सकते हैं:

```py
import aspose.slides as slides

with slides.Presentation("pres.odp") as presentation:
    presentation.save("pres.pdf", slides.export.SaveFormat.PDF)
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं LibreOffice या OpenOffice इंस्टॉल किए बिना ODP को PPTX में बदल सकता हूं?**

हाँ। Aspose.Slides एक पूरी तरह स्वतंत्र लाइब्रेरी है जो PowerPoint और OpenOffice फॉर्मैट दोनों को बिना किसी बाहरी अनुप्रयोग की आवश्यकता के संभालती है।

**क्या Aspose.Slides पासवर्ड-संरक्षित ODP/OTP फ़ाइलों को खोलता और सेव करता है?**

हाँ। यह जब आप पासवर्ड प्रदान करते हैं तो [एन्क्रिप्टेड प्रस्तुतियों को लोड करें](/slides/hi/python-net/password-protected-presentation/) सकता है और एन्क्रिप्शन एवं सुरक्षा सेटिंग्स के साथ प्रस्तुतियों को भी सेव कर सकता है।

**क्या मैं ODP को बदलने से पहले एम्बेडेड मीडिया फ़ाइलें (ऑडियो/वीडियो) निकाल सकता हूं?**

हाँ। Aspose.Slides आपको प्रस्तुतियों से एम्बेडेड [ऑडियो](/slides/hi/python-net/audio-frame/) और [वीडियो](/slides/hi/python-net/video-frame/) निकालने की अनुमति देता है, जो प्री‑कन्वर्ज़न प्रोसेसिंग या अलग‑अलग पुनः उपयोग के लिए उपयोगी है।

**क्या मैं बदले हुए ODP को स्ट्रिक्ट ऑफिस ओपन XML के रूप में सेव कर सकता हूं?**

हाँ। PPTX में सेव करते समय आप [सेव विकल्प](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/pptxoptions/) के माध्यम से स्ट्रिक्ट OOXML को सक्षम कर सकते हैं ताकि कड़े अनुपालन आवश्यकताओं को पूरा किया जा सके।