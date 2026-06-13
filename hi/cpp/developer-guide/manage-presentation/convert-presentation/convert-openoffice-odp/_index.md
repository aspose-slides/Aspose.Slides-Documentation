---
title: C++ में OpenDocument प्रस्तुतियों को परिवर्तित करें
linktitle: OpenDocument परिवर्तित करें
type: docs
weight: 10
url: /hi/cpp/convert-openoffice-odp/
keywords:
- ODP को बदलें
- ODP से इमेज
- ODP से GIF
- ODP से HTML
- ODP से JPG
- ODP से MD
- ODP से PDF
- ODP से PNG
- ODP से PPT
- ODP से PPTX
- ODP से TIFF
- ODP से वीडियो
- ODP से Word
- ODP से XPS
- OpenDocument
- प्रेजेंटेशन
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ आपको ODP को PDF, HTML और इमेज फ़ॉर्मैट में आसानी से बदलने देता है। तेज़ और सटीक प्रेजेंटेशन रूपांतरण के साथ अपने C++ एप्लिकेशन को बढ़ाएँ।"
---
[**Aspose.Slides API**](https://products.aspose.com/slides/hi/cpp/) आपको OpenDocument (ODP) प्रस्तुतियों को कई फ़ॉर्मैट (HTML, PDF, TIFF, SWF, XPS, आदि) में बदलने की अनुमति देता है। ODP फ़ाइलों को अन्य दस्तावेज़ फ़ॉर्मैट में परिवर्तित करने के लिए उपयोग किया जाने वाला API PowerPoint (PPT और PPTX) रूपांतरण संचालन के लिए उपयोग किए जाने वाले API के समान है।

उदाहरण के लिए, यदि आपको ODP प्रस्तुति को PDF में बदलने की आवश्यकता है, तो आप इसे इस प्रकार कर सकते हैं:

```cpp
auto pres = MakeObject<Presentation>(u"pres.odp");
pres->Save(u"pres.pdf", SaveFormat::Pdf);
pres->Dispose();
```