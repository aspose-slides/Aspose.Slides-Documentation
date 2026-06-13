---
title: ".NET में प्रस्तुतियाँ बनाएं"
linktitle: "प्रस्तुति बनाएं"
type: docs
weight: 10
url: /hi/net/create-presentation/
keywords:
- "प्रस्तुति बनाएं"
- "नयी प्रस्तुति"
- "PPT बनाएं"
- "नया PPT"
- "PPTX बनाएं"
- "नया PPTX"
- "ODP बनाएं"
- "नया ODP"
- "PowerPoint"
- "OpenDocument"
- "प्रस्तुति"
- ".NET"
- "C#"
- "Aspose.Slides"
description: " .NET में Aspose.Slides के साथ प्रस्तुतियों को बनाएं—PPT, PPTX और ODP फ़ाइलें बनाएं, OpenDocument समर्थन का लाभ उठाएँ, और विश्वसनीय परिणामों के लिए प्रोग्रामेटिक रूप से सहेजें।"
---
## **परिचय**

यह लेख दर्शाता है कि Aspose.Slides में प्रस्तुति कैसे बनायें, स्लाइड में सरल सामग्री जोड़ें, और परिणाम को फ़ाइल के रूप में सहेजें। यह यह भी प्रदर्शित करता है कि नई प्रस्तुति कैसे बनायें और सहेजें, समर्थित फ़ॉर्मेट में मौजूदा प्रस्तुति खोलें, और उसे किसी अन्य फ़ॉर्मेट में सहेजें। अतिरिक्त रूप से, इस लेख में फ़ॉर्मेट, टेम्प्लेट, स्लाइड आकार, इकाइयाँ, मेमोरी उपयोग, थ्रेडिंग, लाइसेंसिंग, डिजिटल हस्ताक्षर, और VBA समर्थन से संबंधित सामान्य प्रश्नों को कवर करने वाला एक छोटा FAQ शामिल है।

## **PowerPoint प्रस्तुति बनाएं**
प्रस्तुति की चयनित स्लाइड में सरल सीधी रेखा जोड़ने के लिए, नीचे दिए गए चरणों का पालन करें:

1. Presentation वर्ग का एक उदाहरण बनाएं।
2. इंडेक्स का उपयोग करके स्लाइड का संदर्भ प्राप्त करें।
3. Shapes ऑब्जेक्ट द्वारा उजागर AddAutoShape मेथड का उपयोग करके Line प्रकार का AutoShape जोड़ें।
4. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

नीचे दिए गए उदाहरण में, हमने प्रस्तुति की पहली स्लाइड में एक रेखा जोड़ी है।

```c#
// एक Presentation ऑब्जेक्ट बनाएं जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
using (Presentation presentation = new Presentation())
{
    // पहली स्लाइड प्राप्त करें
    ISlide slide = presentation.Slides[0];

    // लाइन प्रकार का ऑटोषेप जोड़ें
    slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);
    presentation.Save("NewPresentation_out.pptx", SaveFormat.Pptx);
}
```

## **प्रस्तुति बनाएं और सहेजें**

<a name="csharp-create-save-presentation"><strong>चरण: C# में प्रस्तुति बनाएं और सहेजें</strong></a>

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) वर्ग का एक उदाहरण बनाएं।
2. _Presentation_ को किसी भी फ़ॉर्मेट में सहेजें जो [SaveFormat](https://reference.aspose.com/slides/hi/net/aspose.slides.export/saveformat/) द्वारा समर्थित हो।

```c#
Presentation presentation = new Presentation();

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```

## **प्रस्तुति खोलें और सहेजें**

<a name="csharp-open-save-presentation"><strong>चरण: C# में प्रस्तुति खोलें और सहेजें</strong></a>

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) वर्ग का एक उदाहरण बनाएं किसी भी फ़ॉर्मेट के साथ, जैसे PPT, PPTX, ODP आदि।
2. _Presentation_ को किसी भी फ़ॉर्मेट में सहेजें जो [SaveFormat](https://reference.aspose.com/slides/hi/net/aspose.slides.export/saveformat/) द्वारा समर्थित हो।

```c#
// Presentation में कोई भी समर्थित फ़ाइल लोड करें, जैसे ppt, pptx, odp आदि।
Presentation presentation = new Presentation("Sample.odp");

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं नई प्रस्तुति को किन फॉर्मेट में सहेज सकता हूँ?**

आप नई प्रस्तुति को [PPTX, PPT, and ODP](/slides/hi/net/save-presentation/) में सहेज सकते हैं, और इसे [PDF](/slides/hi/net/convert-powerpoint-to-pdf/), [XPS](/slides/hi/net/convert-powerpoint-to-xps/), [HTML](/slides/hi/net/convert-powerpoint-to-html/), [SVG](/slides/hi/net/convert-powerpoint-to-png/), और [images](/slides/hi/net/convert-powerpoint-to-png/) जैसे फॉर्मेट में निर्यात कर सकते हैं।

**क्या मैं टेम्प्लेट (POTX/POTM) से शुरू कर सकता हूँ और नियमित PPTX के रूप में सहेज सकता हूँ?**

हाँ। टेम्प्लेट लोड करें और इच्छित फ़ॉर्मेट में सहेजें; POTX/POTM/PPTM और समान फ़ॉर्मेट [are supported](/slides/hi/net/supported-file-formats/)।

**मैं प्रस्तुति बनाते समय स्लाइड आकार/आस्पेक्ट अनुपात को कैसे नियंत्रित करूँ?**

स्लाइड आकार को सेट करें ([slide size](/slides/hi/net/slide-size/)) (जैसे 4:3 और 16:9 जैसी प्रीसेट्स या कस्टम आयाम) और चुनें कि सामग्री कैसे स्केल होनी चाहिए।

**आकार और निर्देशांक किस इकाइयों में मापे जाते हैं?**

प्वाइंट्स में: 1 इंच बराबर 72 इकाइयों के।

**बहुत बड़ी प्रस्तुतियों (जिनमें कई मीडिया फ़ाइलें हों) को मेमोरी उपयोग कम करने के लिए मैं कैसे संभालूँ?**

[BLOB management strategies](/slides/hi/net/manage-blob/) का उपयोग करें, अस्थायी फ़ाइलों का उपयोग करके in-memory संग्रहण को सीमित करें, और शुद्ध in-memory स्ट्रीम्स की बजाय फ़ाइल-आधारित कार्यप्रवाह को प्राथमिकता दें।

**क्या मैं समानांतर में प्रस्तुतियों को बनाकर/सहेज सकता हूँ?**

आप समान [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) इंस्टेंस को [multiple threads](/slides/hi/net/multithreading/) से संचालित नहीं कर सकते। प्रत्येक थ्रेड या प्रक्रिया के लिए अलग, अलग इंस्टेंस चलाएँ।

**मैं ट्रायल वॉटरमार्क और सीमाओं को कैसे हटाऊँ?**

[Apply a license](/slides/hi/net/licensing/) प्रक्रिया में एक बार लागू करें। लाइसेंस XML को अपरिवर्तित रहना चाहिए, और यदि कई थ्रेड शामिल हों तो लाइसेंस सेटअप को समकालिक किया जाना चाहिए।

**क्या मैं बनायी गई PPTX को डिजिटल रूप से साइन कर सकता हूँ?**

हाँ। प्रस्तुतियों के लिए [Digital signatures](/slides/hi/net/digital-signature-in-powerpoint/) (जोड़ना और सत्यापित करना) समर्थित हैं।

**क्या बनाई गई प्रस्तुतियों में मैक्रो (VBA) समर्थित हैं?**

हाँ। आप [create/edit VBA projects](/slides/hi/net/presentation-via-vba/) कर सकते हैं और PPTM/PPSM जैसी मैक्रो‑सक्षम फ़ाइलें सहेज सकते हैं।