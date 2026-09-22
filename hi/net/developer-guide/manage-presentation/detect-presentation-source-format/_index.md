---
title: .NET में मूल प्रेजेंटेशन फ़ॉर्मेट निर्धारित करें
linktitle: स्रोत फ़ॉर्मेट
type: docs
weight: 35
url: /hi/net/detect-presentation-source-format/
keywords:
- स्रोत फ़ॉर्मेट
- प्रेजेंटेशन फ़ॉर्मेट पहचानें
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- PPT
- PPTX
- C#
- .NET
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ C# में लोड किए गए प्रेजेंटेशन का मूल फ़ॉर्मेट पढ़ें, पहचान API की तुलना करें, और फ़ाइलें, स्ट्रीम और लेगेसी फ़ॉर्मेट को संभालें।"
---
## **अवलोकन**

प्रेजेंटेशन लोड करने के बाद, उसकी मूल फ़ॉर्मेट निर्धारित करने के लिए रीड‑ऑनली [Presentation.SourceFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/sourceformat/) प्रॉपर्टी पढ़ें। यह प्रॉपर्टी [IPresentation.SourceFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/ipresentation/sourceformat/) के माध्यम से भी उपलब्ध है। इसका उपयोग तब करें जब बाद की प्रोसेसिंग वर्तमान इंस्टेंस द्वारा लोड किए गए फ़ॉर्मेट पर निर्भर करती हो।

स्रोत फ़ॉर्मेट उस [SaveFormat](https://reference.aspose.com/slides/hi/net/aspose.slides.export/saveformat/) से अलग है जिसे आउटपुट फ़ाइल के लिए चुना जाता है। किसी अन्य फ़ॉर्मेट में सहेजने से मौजूदा इंस्टेंस के स्रोत फ़ॉर्मेट में बदलाव नहीं होता।

## **फ़ाइल का स्रोत फ़ॉर्मेट पढ़ें**

यह उदाहरण एक मौजूदा `sample.pptx` फ़ाइल की आवश्यकता रखता है। यह फ़ाइल को लोड करता है और फ़ाइल नाम के बजाय [Presentation.SourceFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/sourceformat/) का उपयोग करके एप्लिकेशन प्रोसेसिंग नीति चुनता है। अन्य फ़ॉर्मेट आज़माने के लिए इनपुट पथ बदलें। उदाहरण चयनित नीति को प्रिंट करता है; अपने एप्लिकेशन लॉजिक के साथ संदेशों को बदलें।

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

switch (presentation.SourceFormat)
{
    case SourceFormat.Ppt:
    case SourceFormat.Pps:
    case SourceFormat.Pot:
        Console.WriteLine("Use the legacy PowerPoint processing policy.");
        break;
    case SourceFormat.Pptx:
        Console.WriteLine("Use the standard PPTX processing policy.");
        break;
    default:
        Console.WriteLine($"Use the general policy for {presentation.SourceFormat}.");
        break;
}
```

## **समर्थित मानों की पहचान करें**

[SourceFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/sourceformat/) एनीयेशन निम्नलिखित प्रेजेंटेशन फ़ॉर्मेट को अलग करता है। नीचे दिए गए एक्सटेंशन सामान्य एक्सटेंशन हैं, मूल फ़ाइलनाम के पुनर्निर्माण नहीं।

| SourceFormat मान | एक्सटेंशन | फ़ॉर्मेट |
| --- | --- | --- |
| `Ppt` | `.ppt` | PowerPoint 97–2003 प्रेजेंटेशन |
| `Pptx` | `.pptx` | Office Open XML प्रेजेंटेशन |
| `Pptm` | `.pptm` | मैक्रो‑सक्षम Office Open XML प्रेजेंटेशन |
| `Pps` | `.pps` | PowerPoint 97–2003 स्लाइड शो |
| `Ppsx` | `.ppsx` | Office Open XML स्लाइड शो |
| `Ppsm` | `.ppsm` | मैक्रो‑सक्षम Office Open XML स्लाइड शो |
| `Pot` | `.pot` | PowerPoint 97–2003 टेम्प्लेट |
| `Potx` | `.potx` | Office Open XML टेम्प्लेट |
| `Potm` | `.potm` | मैक्रो‑सक्षम Office Open XML टेम्प्लेट |
| `Odp` | `.odp` | OpenDocument प्रेजेंटेशन |
| `Otp` | `.otp` | OpenDocument प्रेजेंटेशन टेम्प्लेट |
| `Fodp` | `.fodp` | फ्लैट XML ODF प्रेजेंटेशन |
| `Xml` | `.xml` | PowerPoint XML प्रेजेंटेशन |

## **स्ट्रीम का स्रोत फ़ॉर्मेट पढ़ें**

यह उदाहरण एक मौजूदा `sample.pps` फ़ाइल की आवश्यकता रखता है। इसके बाइट्स को मेमोरी स्ट्रीम में पढ़ना उस इनपुट को मॉडल करता है जहाँ फ़ाइलनाम नहीं होता, जैसे डेटाबेस मान या अपलोडेड बाइट ऐरे। [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) कंस्ट्रक्टर केवल स्ट्रीम प्राप्त करता है।

```csharp
using System;
using System.IO;
using Aspose.Slides;

var bytes = File.ReadAllBytes("sample.pps");
using var stream = new MemoryStream(bytes);
using var presentation = new Presentation(stream);

Console.WriteLine($"Source format: {presentation.SourceFormat}");
```

PPT, PPS, और POT एक ही बाइनरी फ़ॉर्मेट साझा करते हैं। फ़ाइल पाथ से लोड करते समय, एक्सटेंशन स्लाइड शो या टेम्प्लेट पहचानने में मदद कर सकता है। बिना फ़ाइलनाम के, लेगेसी PPS और POT सामग्री को `SourceFormat.Ppt` के रूप में रिपोर्ट किया जा सकता है; उपरोक्त PPS उदाहरण `Ppt` रिपोर्ट करता है।

यदि आपके एप्लिकेशन को यह अंतर बनाए रखना आवश्यक है, तो मूल फ़ाइलनाम या उप‑टाइप मेटाडेटा को अलग से रखें। एक्सटेंशन इन लेगेसी उप‑टाइप के लिए एक उपयोगी संकेत है, परंतु इसे मनमाने प्रेजेंटेशन सामग्री की पहचान के एकमात्र आधार नहीं बनाना चाहिए।

## **लोड करने से पहले और बाद में पहचान की तुलना करें**

फ़ाइल को पूरी प्रेजेंटेशन ऑब्जेक्ट मॉडल में लोड किए बिना जांचने के लिए [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/hi/net/aspose.slides/presentationfactory/getpresentationinfo/) और [IPresentationInfo.LoadFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/ipresentationinfo/loadformat/) का उपयोग करें। जब इंस्टेंस पहले से मौजूद हो तो [Presentation.SourceFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/sourceformat/) का उपयोग करें।

यह उदाहरण `sample.pptx` की आवश्यकता रखता है और दोनों जांचों के लिए `Pptx` प्रिंट करता है। प्रोडक्शन में, अपने प्रोसेसिंग चरण के अनुसार उपयुक्त API चुनें; पहले से लोडेड प्रेजेंटेशन को उसके स्रोत फ़ॉर्मेट को प्राप्त करने के लिए दोबारा जांचने की आवश्यकता नहीं है।

```csharp
using System;
using Aspose.Slides;

var path = "sample.pptx";
var information = PresentationFactory.Instance.GetPresentationInfo(path);
Console.WriteLine($"Before loading: {information.LoadFormat}");

using var presentation = new Presentation(path);
Console.WriteLine($"After loading: {presentation.SourceFormat}");
```

परिणामों के एनीयेशन प्रकार अलग होते हैं: [LoadFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/loadformat/) और [SourceFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/sourceformat/)। उन्हें उनके संख्यात्मक मान कास्ट करके तुलना न करें या यह न मानें कि प्रत्येक फ़ॉर्मेट के लिए पहचान परिणाम समान होते हैं। नीचे वर्णित सहेज‑और‑फिर‑खोलें जांच में, PowerPoint XML लोड होने से पहले `LoadFormat.Unknown` और लोड होने के बाद `SourceFormat.Xml` के रूप में रिपोर्ट किया गया।

## **स्रोत और आउटपुट फ़ॉर्मेट को अलग रखें**

यह उदाहरण `sample.pptx` की आवश्यकता रखता है और `converted.odp` लिखता है। यह मूल इंस्टेंस को सहेजने से पहले और बाद दोनों में `Pptx` प्रिंट करता है। ODP आउटपुट से लोड किया गया नया इंस्टेंस केवल `Odp` रिपोर्ट करता है।

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
Console.WriteLine($"Before saving: {presentation.SourceFormat}");

presentation.Save("converted.odp", SaveFormat.Odp);
Console.WriteLine($"After saving: {presentation.SourceFormat}");

using var reopened = new Presentation("converted.odp");
Console.WriteLine($"Reopened output: {reopened.SourceFormat}");
```

`new Presentation()` से शून्य से बनाया गया प्रेजेंटेशन `SourceFormat.Pptx` रिपोर्ट करता है। इसमें कोई इनपुट फ़ाइल नहीं होती: यह नई बनाई गई इंस्टेंस का डिफ़ॉल्ट मान है, यह प्रमाण नहीं कि PPTX फ़ाइल लोड हुई थी। यदि यह अंतर आपके लिए महत्वपूर्ण है तो एप्लिकेशन ने इंस्टेंस बनाया या लोड किया, इसे अलग से ट्रैक करें।

## **स्रोत फ़ॉर्मेट को एक्सटेंशन में मैप करें**

नीचे का उदाहरण `sample.pptx` की आवश्यकता रखता है। यह प्रत्येक वर्तमान में समर्थित [SourceFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/sourceformat/) मान को सामान्य एक्सटेंशन में मैप करता है, बिना इनपुट फ़ाइलनाम को पार्स किए। फॉलबैक अनपहचाने मान के लिए चुपचाप एक्सटेंशन असाइन करने से बचाता है।

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var extension = presentation.SourceFormat switch
{
    SourceFormat.Ppt => ".ppt",
    SourceFormat.Pptx => ".pptx",
    SourceFormat.Pptm => ".pptm",
    SourceFormat.Pps => ".pps",
    SourceFormat.Ppsx => ".ppsx",
    SourceFormat.Ppsm => ".ppsm",
    SourceFormat.Pot => ".pot",
    SourceFormat.Potx => ".potx",
    SourceFormat.Potm => ".potm",
    SourceFormat.Odp => ".odp",
    SourceFormat.Otp => ".otp",
    SourceFormat.Fodp => ".fodp",
    SourceFormat.Xml => ".xml",
    _ => null
};

Console.WriteLine(extension ?? "No extension mapping is available.");
```

यह मैपिंग फ़ाइल को नहीं बदलती न ही स्ट्रीम लोडिंग के दौरान खोए लेगेसी PPS/POT उप‑टाइप को पुनः प्राप्त करती है। वास्तविक सहेजने के लिए, स्पष्ट रूप से एक [SaveFormat](https://reference.aspose.com/slides/hi/net/aspose.slides.export/saveformat/) चुनें, या [Save Presentations in Their Original Format](/slides/hi/net/save-presentation/#save-presentations-in-their-original-format) में दिखाए गए रूपांतरण का उपयोग करें।

## **सहेजने और फिर से खोलने से फ़ॉर्मेट सत्यापित करें**

यह स्वनिर्भर उदाहरण एक प्रेजेंटेशन बनाता है और कार्य निर्देशिका में तीन फ़ाइलें लिखता है, समान नाम वाली फ़ाइलों को ओवरराइट करता है। यह प्रत्येक आउटपुट को पाथ और मेमोरी स्ट्रीम दोनों के माध्यम से फिर से खोलता है। PPTX और ODP के लिए, दोनों मार्ग सहेजे गए फ़ॉर्मेट को रिपोर्ट करते हैं। PPS के लिए, पाथ से लोड करने पर `Pps` रिपोर्ट होता है, जबकि फ़ाइलनाम के बिना समान बाइट्स लोड करने पर `Ppt` रिपोर्ट होता है।

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var formats = new[] { SaveFormat.Pptx, SaveFormat.Odp, SaveFormat.Pps };

foreach (var format in formats)
{
    var path = $"roundtrip.{format.ToString().ToLowerInvariant()}";
    presentation.Save(path, format);

    using var fromFile = new Presentation(path);
    var bytes = File.ReadAllBytes(path);
    using var stream = new MemoryStream(bytes);
    using var fromStream = new Presentation(stream);

    Console.WriteLine($"{format}: file={fromFile.SourceFormat}, stream={fromStream.SourceFormat}");
}
```

उपर्युक्त सभी फ़ॉर्मेट के साथ किए गए समान जांच ने उत्पन्न प्रेजेंटेशन में मिलते‑जुलते एक्सटेंशन के साथ निम्नलिखित परिणाम दिखाए:

| सहेजा गया फ़ॉर्मेट | फ़ाइल पाथ से SourceFormat | नाम‑रहित स्ट्रीम से SourceFormat |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | क्रमशः `Pptx`, `Pptm` | फ़ाइल पाथ समान |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | क्रमशः `Ppsx`, `Ppsm` | फ़ाइल पाथ समान |
| POT | `Pot` | `Ppt` |
| POTX, POTM | क्रमशः `Potx`, `Potm` | फ़ाइल पाथ समान |
| ODP, OTP | क्रमशः `Odp`, `Otp` | फ़ाइल पाथ समान |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

इन जांचों में, नाम‑रहित स्ट्रीम के लिए केवल PPS/POT को `Ppt` में सामान्यीकृत किया गया। तालिका फ़ॉर्मेट पहचान को दर्शाती है, न कि रूपांतरण के दौरान हर प्रेजेंटेशन फीचर की सुरक्षा को।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या PPTX से लोड किए गए प्रेजेंटेशन को ODP में सहेजने से स्रोत फ़ॉर्मेट बदलता है?**

नहीं। मौजूदा इंस्टेंस अभी भी `Pptx` रिपोर्ट करता है। सहेजे गए ODP फ़ाइल से लोड किया गया इंस्टेंस `Odp` रिपोर्ट करता है।

**क्या स्ट्रीम हमेशा लेगेसी प्रेजेंटेशन, स्लाइड शो और टेम्प्लेट को अलग पहचान सकता है?**

नहीं। PPT, PPS, और POT एक ही बाइनरी फ़ॉर्मेट साझा करते हैं। जब यह अंतर आवश्यक हो, तो फ़ाइलनाम या उप‑टाइप मेटाडेटा को अलग से रखें।

**यदि प्रेजेंटेशन पहले से लोड हो चुका है तो मुझे कौन सा API उपयोग करना चाहिए?**

[Presentation.SourceFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/sourceformat/) पढ़ें। लोड करने से पहले निरीक्षण के लिए [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/hi/net/aspose.slides/presentationfactory/getpresentationinfo/) का उपयोग करें।