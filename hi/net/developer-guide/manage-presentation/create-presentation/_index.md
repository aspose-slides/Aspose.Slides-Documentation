---
title: .NET में प्रस्तुतियों को बनाएं
linktitle: प्रस्तुति बनाएं
type: docs
weight: 10
url: /hi/net/create-presentation/
keywords:
- प्रस्तुति बनाएं
- नई प्रस्तुति
- PPT बनाएं
- नया PPT
- PPTX बनाएं
- नया PPTX
- ODP बनाएं
- नया ODP
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: ".NET में Aspose.Slides का उपयोग करके प्रस्तुतियों को बनाएं—PPT, PPTX, और ODP फ़ाइलें बनाएं, OpenDocument समर्थन का लाभ उठाएँ, और विश्वसनीय परिणामों के लिए उन्हें प्रोग्रामेटिकली सहेजें।"
---
## **समीक्षा**

यह लेख Aspose.Slides में प्रस्तुति बनाना, उसकी पहली स्लाइड पर टेक्स्ट बॉक्स जोड़ना, और परिणाम को फ़ाइल के रूप में सहेजना दिखाता है। इसमें ख़ाली प्रस्तुति बनाना और सहेजना, तथा समर्थित प्रारूप में मौजूदा प्रस्तुति खोलना और उसे दूसरे प्रारूप में सहेजना भी दिखाया गया है। अंत में एक छोटा FAQ सामान्य प्रश्नों को कवर करता है, जैसे प्रारूप, टेम्प्लेट, स्लाइड आकार, इकाइयाँ, मेमोरी उपयोग, थ्रेडिंग, लाइसेंसिंग, डिजिटल हस्ताक्षर, और VBA समर्थन।

शुरू करने से पहले, NuGet से Aspose.Slides को अपने प्रोजेक्ट में जोड़ें। पैकेज के बारे में जानकारी के लिए देखें [स्थापना](/slides/hi/net/installation/)।

## **PowerPoint प्रस्तुति बनाएं**

एक प्रस्तुति बनाने और उसकी पहली स्लाइड पर टेक्स्ट बॉक्स रखने के लिए, निम्न चरणों का पालन करें:

1. एक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास की नई instance बनाएँ। नई प्रस्तुति में पहले से ही एक खाली स्लाइड होती है।
1. उस स्लाइड को [Slides](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/slides/hi/) संग्रह से उसके इंडेक्स 0 द्वारा प्राप्त करें।
1. [AddAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/ishapecollection/addautoshape/) मेथड के साथ एक आयत जोड़ें और उसके [text](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/text/) को सेट करें।
1. [Save](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/save/) मेथड का उपयोग करके प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello, Aspose.Slides!";
presentation.Save("hello.pptx", SaveFormat.Pptx);
```

आयत का शीर्ष-बायाँ कोना स्लाइड के बाएँ किनारे से 50 पॉइंट और शीर्ष किनारे से 50 पॉइंट दूर है, और आयत की चौड़ाई 400 पॉइंट तथा ऊँचाई 100 पॉइंट है। सहेजी गई फ़ाइल में एक स्लाइड है जिसमें वह आयत और उसका टेक्स्ट है। बिना लाइसेंस के, Aspose.Slides प्रत्येक सहेजी गई स्लाइड में एक मूल्यांकन वॉटरमार्क भी जोड़ता है; देखें [लाइसेंसिंग](/slides/hi/net/licensing/)।

## **प्रस्तुति बनाएं और सहेजें**

<a name="csharp-create-save-presentation"></a>

एक खाली प्रस्तुति बनाने और उसे सहेजने के लिए, [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास की instance बनाएं और उसे [SaveFormat](https://reference.aspose.com/slides/hi/net/aspose.slides.export/saveformat/) enumeration के किसी भी फ़ॉर्मेट में सहेजें। परिणामस्वरूप एक खाली स्लाइड वाली प्रस्तुति बनती है।

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.Save("OutputPresentation.pptx", SaveFormat.Pptx);
```

## **प्रस्तुति खोलें और सहेजें**

<a name="csharp-open-save-presentation"></a>

एक प्रस्तुति को एक फ़ॉर्मेट से दूसरे में बदलने के लिए, उसके पथ को [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/presentation/) कंस्ट्रक्टर में पास करके इसे खोलें, फिर लक्ष्य फ़ॉर्मेट में सहेजें। Aspose.Slides फ़ाइल से स्वयं इनपुट फ़ॉर्मेट, जैसे PPT, PPTX, या ODP, का पता लगाता है।

निम्न उदाहरण कार्य निर्देशिका में *Sample.odp* नामक एक OpenDocument प्रस्तुति की अपेक्षा करता है और इसे PPTX के रूप में सहेजता है।

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.odp");
presentation.Save("OutputPresentation.pptx", SaveFormat.Pptx);
```

## **FAQ**

### मैं नई प्रस्तुति को किन फ़ॉर्मेट में सहेज सकता हूँ?

आप [PPTX, PPT, और ODP](/slides/hi/net/save-presentation/) में सहेज सकते हैं, और [PDF](/slides/hi/net/convert-powerpoint-to-pdf/), [XPS](/slides/hi/net/convert-powerpoint-to-xps/), [HTML](/slides/hi/net/convert-powerpoint-to-html/), [SVG](/slides/hi/net/render-a-slide-as-an-svg-image/), और [छवियाँ](/slides/hi/net/convert-powerpoint-to-png/) सहित अन्य फ़ॉर्मेट में निर्यात कर सकते हैं।

### क्या मैं टेम्प्लेट (POTX/POTM) से शुरू करके नियमित PPTX के रूप में सहेज सकता हूँ?

हाँ। टेम्प्लेट को लोड करें और इच्छित फ़ॉर्मेट में सहेजें; POTX/POTM/PPTM और समान फ़ॉर्मेट [समर्थित](/slides/hi/net/supported-file-formats/) हैं।

### प्रस्तुति बनाते समय स्लाइड आकार/अनुपात को कैसे नियंत्रित करूँ?

[स्लाइड आकार](/slides/hi/net/slide-size/) सेट करें (जैसे 4:3 और 16:9 प्रीसेट या कस्टम आयाम) और तय करें कि सामग्री कैसे स्केल होनी चाहिए।

### आकार और निर्देशांक किन इकाइयों में मापे जाते हैं?

पॉइंट में: 1 इंच के बराबर 72 इकाइयाँ हैं।

### बड़े पैमाने की प्रस्तुतियों (कई मीडिया फ़ाइलों के साथ) को मेमोरी उपयोग कम करने के लिए कैसे संभालूँ?

[BLOB management strategies](/slides/hi/net/manage-blob/) का उपयोग करें, अस्थायी फ़ाइलों के माध्यम से इन‑मेमोरी स्टोरेज को सीमित करें, और शुद्ध इन‑मेमोरी स्ट्रीम्स की बजाय फ़ाइल‑आधारित वर्कफ़्लो को प्राथमिकता दें।

### क्या मैं समानांतर रूप में प्रस्तुतियों को बना/सहेज सकता हूँ?

आप एक ही [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) instance को [एकाधिक थ्रेड](/slides/hi/net/multithreading/) से नहीं चला सकते। प्रत्येक थ्रेड या प्रक्रिया के लिए अलग, अलग-अलग instances चलाएँ।

### ट्रायल वॉटरमार्क और सीमाओं को कैसे हटाएँ?

[Apply a license](/slides/hi/net/licensing/) को प्रक्रिया के लिए एक बार लागू करें। लाइसेंस XML को अनबदला रखा जाना चाहिए, और यदि कई थ्रेड शामिल हों तो लाइसेंस सेटअप को समन्वित करना चाहिए।

### क्या मैं बनाई गई PPTX को डिजिटल रूप से साइन कर सकता हूँ?

हाँ। [Digital signatures](/slides/hi/net/digital-signature-in-powerpoint/) (जोड़ना और सत्यापित करना) प्रस्तुतियों के लिए समर्थित हैं।

### क्या निर्मित प्रस्तुतियों में मैक्रो (VBA) समर्थित हैं?

हाँ। आप [create/edit VBA projects](/slides/hi/net/presentation-via-vba/) कर सकते हैं और PPTM/PPSM जैसे मैक्रो‑सक्षम फ़ाइलें सहेज सकते हैं।