---
title: PowerPoint प्रस्तुतियों को .NET में XML में बदलें
linktitle: PowerPoint से XML
type: docs
weight: 145
url: /hi/net/convert-powerpoint-to-xml/
keywords:
- PowerPoint को XML में बदलें
- प्रस्तुति को XML में बदलें
- PPT से XML
- PPTX से XML
- ODP से XML
- PowerPoint XML प्रस्तुति
- SaveFormat.Xml
- प्रस्तुति को XML के रूप में सहेजें
- प्रस्तुति को XML में निर्यात करें
- XML स्ट्रीम
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET का उपयोग करके C# में PowerPoint और OpenDocument प्रस्तुतियों को PowerPoint XML फ़ाइलों या स्ट्रीम में बदलें।"
---
## **अवलोकन**

Aspose.Slides for .NET PowerPoint प्रस्तुतियों को PowerPoint XML Presentation फॉर्मेट में बदल सकता है। XML आउटपुट उपयोगी होता है जब आपको प्रस्तुति संरचना का निरीक्षण करने, उत्पन्न दस्तावेज़ों کی समस्या निवारण करने, स्वचालित परीक्षणों में आउटपुट की तुलना करने, या ऐसा कार्यप्रवाह एकीकृत करने के लिए टेक्स्ट‑आधारित प्रतिनिधित्व चाहिए जो प्रस्तुति पैकेज के बजाय XML का उपभोग करता है।

आप [Presentation.Save](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/save/) मेथड को [SaveFormat](https://reference.aspose.com/slides/hi/net/aspose.slides.export/saveformat/) enumeration से `Xml` मान के साथ उपयोग कर सकते हैं। आप परिणाम को सीधे फ़ाइल या स्ट्रीम में लिख सकते हैं।

{{% alert color="info" title="Note" %}}
`SaveFormat.Xml` एक PowerPoint XML Presentation बनाता है। यह PPTX पैकेज के भीतर संग्रहीत व्यक्तिगत Office Open XML भागों को निकालता नहीं है। यदि आपको सटीक PPTX पैकेज भागों की आवश्यकता है, जैसे `ppt/presentation.xml` या व्यक्तिगत स्लाइड XML फ़ाइलें, तो PPTX पैकेज को स्वयं जांचें।
{{% /alert %}}

## **प्रेजेंटेशन को XML फ़ाइल में बदलें**

एक स्रोत प्रेजेंटेशन को [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास से लोड करें, और फिर आउटपुट पथ और `SaveFormat.Xml` को [Presentation.Save](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/save/) में पास करें। स्रोत कोई भी प्रेजेंटेशन फॉर्मेट हो सकता है जो लोडिंग के लिए समर्थित है, जैसे PPT, PPTX, या ODP।

निम्न उदाहरण PPTX प्रेजेंटेशन को XML फ़ाइल में बदलता है:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.xml", SaveFormat.Xml);
```

## **XML आउटपुट को स्ट्रीम में लिखें**

जब XML को मेमोरी में रखना हो या किसी अन्य घटक, जैसे वेब सेवा, स्टोरेज प्रोवाइडर, या XML प्रोसेसिंग पाइपलाइन, को पास करना हो, तब [Presentation.Save](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/save/) की स्ट्रीम ओवरलोड का उपयोग करें। निम्न उदाहरण परिणाम को एक [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream?view=net-10.0) में लिखता है और आगे पढ़ने के लिए उसे रीवाइंड करता है:

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
using var xmlStream = new MemoryStream();

presentation.Save(xmlStream, SaveFormat.Xml);
xmlStream.Position = 0;

// वर्कफ़्लो में अगले घटक को xmlStream पास करें।
```

## **XML की तुलना प्रेजेंटेशन और एक्सपोर्ट फॉर्मेट्स से**

परिणाम के उपयोग के अनुसार आउटपुट फॉर्मेट चुनें:

| Format | Output | Typical use |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | एक PowerPoint XML Presentation | संरचना का निरीक्षण, समस्या निवारण, उत्पन्न आउटपुट की तुलना, और XML‑आधारित एकीकरण |
| PPT (`.ppt`) | एक लेगसी बाइनरी प्रेजेंटेशन फ़ाइल | पुराने PowerPoint कार्यप्रवाहों के साथ संगतता |
| PPTX (`.pptx`) | एक Office Open XML पैकेज जिसमें कई भाग होते हैं | सामान्य PowerPoint संपादन और प्रेजेंटेशन आदान‑प्रदान |
| PDF or TIFF | स्थिर लेआउट पृष्ठ या TIFF छवियां | देखना, प्रिंटिंग, और आर्काइविंग |
| PNG, JPEG, or SVG | एक व्यक्तिगत स्लाइड का रेंडर किया गया प्रतिनिधित्व | थंबनेल, प्रीव्यू, और इमेज एसेट्स |
| HTML or HTML5 | वेब‑उन्मुख प्रेजेंटेशन आउटपुट | ब्राउज़र में देखना और वेब प्रकाशन |

PPT और PPTX के विपरीत, XML आउटपुट मुख्यतः निरीक्षण और डेटा‑उन्मुख कार्यप्रवाहों के लिए अभिप्रेत है। PDF, TIFF, HTML, और स्लाइड इमेज फॉर्मेट्स के विपरीत, यह स्लाइडों को पृष्ठों या दृश्य एसेट्स के रूप में रेंडर करने के बजाय प्रेजेंटेशन डेटा को दर्शाता है। [supported file formats](/slides/hi/net/supported-file-formats/) तालिका उन सभी फॉर्मेट्स की सूची देती है जिन्हें Aspose.Slides लोड, आयात, सहेज या रेंडर कर सकता है।

## **FAQ**

**क्या `SaveFormat.Xml` PPTX फ़ाइल को सहेजने के समान है?**

नहीं। PPTX कई Office Open XML भागों वाला एक पैकेज है, जबकि `SaveFormat.Xml` एक PowerPoint XML Presentation फ़ाइल बनाता है।

**क्या मैं XML आउटपुट को डिस्क पर फ़ाइल बनाए बिना सहेज सकता हूँ?**

हां। एक लिखने योग्य स्ट्रीम को [Presentation.Save](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/save/) में पास करें। उदाहरण के लिए, इन‑मेमोरी प्रोसेसिंग के लिए एक [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream?view=net-10.0) का उपयोग करें।

**क्या Aspose.Slides निर्यातित XML फ़ाइल को फिर से लोड कर सकता है?**

हां। XML फ़ाइल या स्ट्रीम को [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/presentation/) कंस्ट्रक्टर में पास करें। इसके बाद [Presentation.SourceFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/sourceformat/) `SourceFormat.Xml` लौटाता है। [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/hi/net/aspose.slides/presentationfactory/getpresentationinfo/) इस फॉर्मेट के लिए `LoadFormat.Unknown` रिपोर्ट करता है, इसलिए इसका उपयोग यह तय करने के लिए न करें कि कोई XML फ़ाइल खोली जा सकती है या नहीं।

**क्या XML रूपांतरण प्रत्येक स्लाइड को पृष्ठ या छवि के रूप में रेंडर करता है?**

नहीं। XML रूपांतरण संरचित प्रेजेंटेशन डेटा लिखता है। पृष्ठ‑उन्मुख आउटपुट के लिए PDF या TIFF का उपयोग करें, या व्यक्तिगत स्लाइड छवियों के लिए PNG, JPEG और SVG का प्रयोग करें।