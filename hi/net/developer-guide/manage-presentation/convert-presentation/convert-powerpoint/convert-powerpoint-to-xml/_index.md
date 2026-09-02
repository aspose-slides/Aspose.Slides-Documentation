---
title: PowerPoint प्रस्तुतियों को .NET में XML में बदलें
linktitle: PowerPoint से XML
type: docs
weight: 145
url: /hi/net/convert-powerpoint-to-xml/
keywords:
- PowerPoint को XML में बदलें
- प्रस्तुति को XML में बदलें
- PPT को XML में
- PPTX को XML में
- ODP को XML में
- PowerPoint XML प्रस्तुति
- SaveFormat.Xml
- प्रस्तुति को XML के रूप में सहेजें
- प्रस्तुति को XML में निर्यात करें
- XML स्ट्रीम
- .NET
- C#
- Aspose.Slides
description: "PowerPoint और OpenDocument प्रस्तुतियों को C# के साथ Aspose.Slides for .NET का उपयोग करके PowerPoint XML फ़ाइलों या स्ट्रीम्स में बदलें।"
---
## **सारांश**

Aspose.Slides for .NET PowerPoint प्रस्तुतियों को PowerPoint XML Presentation फ़ॉर्मेट में बदल सकता है। XML आउटपुट उपयोगी होता है जब आपको प्रस्तुति संरचना की जाँच, उत्पन्न दस्तावेज़ों की समस्या निवारण, स्वचालित परीक्षणों में आउटपुट की तुलना, या ऐसी कार्यप्रवाह के साथ एकीकरण करने के लिए एक टेक्स्ट-आधारित प्रतिनिधित्व चाहिए जो प्रस्तुति पैकेज के बजाय XML का उपयोग करता है।

उपयोग करें [Presentation.Save](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/save/) मेथड को `Xml` मान के साथ जो [SaveFormat](https://reference.aspose.com/slides/hi/net/aspose.slides.export/saveformat/) एन्उमरेशन से प्राप्त होता है। आप परिणाम को सीधे फ़ाइल या स्ट्रीम में लिख सकते हैं।

{{% alert color="info" title="Note" %}}
`SaveFormat.Xml` एक PowerPoint XML Presentation बनाता है। यह PPTX पैकेज के भीतर संग्रहित व्यक्तिगत Office Open XML भागों को निकालता नहीं है। यदि आपको सटीक PPTX पैकेज भागों की आवश्यकता है, जैसे `ppt/presentation.xml` या व्यक्तिगत स्लाइड XML फ़ाइलें, तो PPTX पैकेज को स्वयं जांचें।
{{% /alert %}}

## **एक प्रस्तुति को XML फ़ाइल में परिवर्तित करें**

स्रोत प्रस्तुति को [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास से लोड करें, और फिर आउटपुट पथ और `SaveFormat.Xml` को [Presentation.Save](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/save/) में पास करें। स्रोत कोई भी प्रस्तुति फ़ॉर्मेट हो सकता है जो लोडिंग के लिए समर्थित है, जैसे PPT, PPTX, या ODP।

निम्न उदाहरण PPTX प्रस्तुति को XML फ़ाइल में बदलता है:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.xml", SaveFormat.Xml);
```

## **XML आउटपुट को स्ट्रीम में लिखें**

जब XML को स्मृति में रखना हो या किसी अन्य घटक को पास करना हो, जैसे वेब सेवा, स्टोरेज प्रोवाइडर, या XML प्रोसेसिंग पाइपलाइन, तो [Presentation.Save](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/save/) की स्ट्रीम ओवरलोड का उपयोग करें। निम्न उदाहरण परिणाम को एक [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream) में लिखता है और आगे पढ़ने के लिए इसे रीवाइंड करता है:

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
using var xmlStream = new MemoryStream();

presentation.Save(xmlStream, SaveFormat.Xml);
xmlStream.Position = 0;

// कार्यप्रवाह में अगले घटक को xmlStream पास करें।
```

## **XML की तुलना प्रस्तुति और एक्सपोर्ट फ़ॉर्मेट्स से करें**

परिणाम के उपयोग के अनुसार आउटपुट फ़ॉर्मेट चुनें:

| फ़ॉर्मेट | आउटपुट | सामान्य उपयोग |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | एक PowerPoint XML Presentation | संरचनात्मक निरीक्षण, समस्या निवारण, उत्पन्न आउटपुट की तुलना, और XML-आधारित एकीकरण |
| PPT (`.ppt`) | एक लिगेसी बाइनरी प्रस्तुति फ़ाइल | पुराने PowerPoint कार्यप्रवाहों के साथ संगतता |
| PPTX (`.pptx`) | कई भागों वाला Office Open XML पैकेज | सामान्य PowerPoint संपादन और प्रस्तुति विनिमय |
| PDF or TIFF | स्थिर लेआउट पृष्ठ या बहु-पृष्ठ छवि | देखना, प्रिंटिंग, और अभिलेख़ीकरण |
| PNG, JPEG, or SVG | एक व्यक्तिगत स्लाइड का रेंडर किया हुआ प्रतिनिधित्व | थंबनेल, प्रीव्यू, और इमेज एसेट्स |
| HTML or HTML5 | वेब-उन्मुख प्रस्तुति आउटपुट | ब्राउज़र में देखना और वेब प्रकाशन |

PPT और PPTX के विपरीत, XML आउटपुट मुख्यतः निरीक्षण और डेटा-उन्मुख कार्यप्रवाहों के लिए होता है। PDF, TIFF, HTML, और स्लाइड इमेज फ़ॉर्मेट्स के विपरीत, यह प्रस्तुति डेटा को दर्शाता है न कि स्लाइड को पृष्ठों या दृश्य एसेट्स के रूप में रेंडर करता है। [supported file formats](/slides/hi/net/supported-file-formats/) तालिका PowerPoint XML Presentation को केवल-सेव फ़ॉर्मेट के रूप में सूचीबद्ध करती है, इसलिए जब किसी कार्यप्रवाह को निर्यातित फ़ाइल को फिर से Aspose.Slides में लोड करके आगे संपादन करना हो, तो इसका उपयोग न करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या `SaveFormat.Xml` PPTX फ़ाइल को सेव करने के समान है?**

नहीं। PPTX एक पैकेज है जिसमें कई Office Open XML भाग होते हैं, जबकि `SaveFormat.Xml` एक PowerPoint XML Presentation फ़ाइल बनाता है।

**क्या मैं XML आउटपुट को डिस्क पर फ़ाइल बनाए बिना सेव कर सकता हूँ?**

हां। एक लिखने योग्य स्ट्रीम को [Presentation.Save](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/save/) में पास करें। उदाहरण के लिए, इन‑मेमारी प्रोसेसिंग के लिए एक [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream) का उपयोग करें।

**क्या Aspose.Slides निर्यातित XML फ़ाइल को फिर से लोड कर सकता है?**

नहीं। PowerPoint XML Presentation वर्तमान में केवल सेव करने के लिए समर्थित है, लोड करने के लिए नहीं। जब राउंड‑ट्रिप एडिटिंग की आवश्यकता हो, तो PPTX या कोई अन्य समर्थित प्रस्तुति फ़ॉर्मेट उपयोग करें।

**क्या XML रूपांतरण प्रत्येक स्लाइड को पृष्ठ या छवि के रूप में रेंडर करता है?**

नहीं। XML रूपांतरण संरचित प्रस्तुति डेटा लिखता है। पेज‑उन्मुख आउटपुट के लिए PDF या TIFF का उपयोग करें, या व्यक्तिगत स्लाइड छवियों के लिए PNG, JPEG, और SVG का प्रयोग करें।