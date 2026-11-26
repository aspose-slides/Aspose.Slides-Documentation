---
title: .NET में प्रस्तुति गुण प्रबंधित करें
linktitle: प्रस्तुति गुण
type: docs
weight: 70
url: /hi/net/presentation-properties/
keywords:
- PowerPoint गुण
- प्रस्तुति गुण
- दस्तावेज़ गुण
- बिल्ट-इन गुण
- कस्टम गुण
- उन्नत गुण
- गुण प्रबंधित करें
- गुण संशोधित करें
- दस्तावेज़ मेटाडेटा
- मेटाडेटा संपादित करें
- प्रूफ़िंग भाषा
- डिफ़ॉल्ट भाषा
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET में प्रस्तुति गुणों पर पूर्ण नियंत्रण प्राप्त करें और अपने PowerPoint और OpenDocument फ़ाइलों में खोज, ब्रांडिंग और कार्यप्रवाह को सरल बनाएं।"
---
## **परिचय**

Aspose.Slides for .NET **बिल्ट-इन** और **कस्टम** दस्तावेज़ गुणों का समर्थन करता है। इन गुणों का उपयोग करके आप प्रस्तुति मेटाडेटा पढ़ और अपडेट कर सकते हैं, जैसे लेखक, शीर्षक, और उपयोगकर्ता‑परिभाषित मान।

Aspose.Slides आपको प्रस्तुति दस्तावेज़ गुणों के साथ काम करने की अनुमति देता है [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/) इंटरफ़ेस के माध्यम से। इस इंटरफ़ेस का एक उदाहरण [IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/) द्वारा लौटाया जाता है। निम्न उदाहरण दिखाते हैं कि इन गुणों को कैसे पढ़ें, संशोधित करें और प्रबंधित करें।

{{% alert color="info" title="Note" %}}
Aspose.Slides प्रस्तुतियों को सहेजते समय एप्लिकेशन और निर्माता मेटाडेटा को प्रबंधित करता है; ये फ़ील्ड उस सॉफ़्टवेयर को पहचानते हैं जिसने आउटपुट बनाया है।
{{% /alert %}}

## **प्रेज़ेंटेशन गुण प्रबंधित करें**

दस्तावेज़ गुण प्रस्तुति सामग्री के साथ वर्णनात्मक जानकारी संग्रहीत करते हैं। वे दो श्रेणियों में आते हैं:

- **बिल्ट-इन गुण** मानक मेटाडेटा रखते हैं, जैसे शीर्षक, लेखक, और दस्तावेज़ आँकड़े।
- **कस्टम गुण** उपयोगकर्ता‑परिभाषित नाम/मान जोड़े संग्रहीत करते हैं।

Aspose.Slides for .NET दोनों श्रेणियों तक पहुँच प्रदान करता है। PowerPoint में, **File → Info → Properties → Advanced Properties** चुनें ताकि दस्तावेज़ मेटाडेटा निरीक्षण किया जा सके। संवाद जानकारी को टैब में समूहित करता है जैसे **Summary**, **Statistics**, **Contents**, और **Custom**। उपयोगकर्ता‑परिभाषित गुणों को प्रबंधित करने के लिए **Custom** टैब का उपयोग करें।

## **एन्क्रिप्टेड प्रस्तुति से सार्वजनिक गुण पढ़ें**

एक खोलने वाला पासवर्ड सामान्यतः प्रस्तुति सामग्री और दस्तावेज़ गुणों दोनों की रक्षा करता है। जब प्रस्तुति को [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) को `false` पर सेट करके एन्क्रिप्ट किया जाता है, तो उसके दस्तावेज़ गुण सार्वजनिक रहते हैं। तब एप्लिकेशन [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) को `true` पर सेट करके बिना खोलने वाले पासवर्ड के सार्वजनिक मेटाडेटा पढ़ सकता है।

[LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) नियंत्रित करता है कि Aspose.Slides क्या लोड करता है; यह कुछ भी डीक्रिप्ट नहीं करता। यदि गुण एन्क्रिप्शन में शामिल थे, तो पासवर्ड के बिना उन्हें लोड करना विफल हो जाएगा। यदि प्रस्तुति एन्क्रिप्टेड नहीं है, तो यह विकल्प नजरअंदाज किया जाता है और पूरी प्रस्तुति लोड की जाती है।

उदाहरण को एक एन्क्रिप्टेड प्रस्तुति की आवश्यकता है जिसकी दस्तावेज़ गुण सार्वजनिक रखी गई हों। यह लोड मोड को [IProtectionManager.IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/isonlydocumentpropertiesloaded/) से जाँचता है और फिर [IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/) के माध्यम से बिल्ट‑इन गुण पढ़ता है:

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { OnlyLoadDocumentProperties = true };
using var presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);

if (presentation.ProtectionManager.IsOnlyDocumentPropertiesLoaded)
{
    var documentProperties = presentation.DocumentProperties;

    Console.WriteLine("Author: " + documentProperties.Author);
    Console.WriteLine("Title: " + documentProperties.Title);
    Console.WriteLine("Keywords: " + documentProperties.Keywords);
}
else
{
    Console.WriteLine("The presentation was not loaded in document-properties-only mode.");
}
```

इस मोड में, स्लाइड सामग्री लोड नहीं होती। स्लाइड्स, मास्टर, लेआउट, शेप, मीडिया और अन्य प्रस्तुति वस्तुएँ उपलब्ध नहीं रहतीं। एप्लिकेशन को हमेशा [IProtectionManager.IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/isonlydocumentpropertiesloaded/) की जाँच करनी चाहिए इससे पहले कि वह ऐसी कार्रवाई करे जिसके लिए पूर्ण प्रस्तुति ऑब्जेक्ट मॉडल की आवश्यकता हो।

{{% alert color="warning" title="Security" %}}
सार्वजनिक मेटाडेटा लेखक नाम, शीर्षक, विषय, कुंजी‑शब्द, कंपनी जानकारी, टिप्पणी और कस्टम मान उजागर कर सकता है। संवेदनशील गुणों को प्रस्तुति के साथ एन्क्रिप्ट करें। केवल तब सार्वजनिक रखें जब इंडेक्सिंग, वर्गीकरण, खोज, या दस्तावेज़‑प्रबंधन प्रणालियों को पासवर्ड के बिना पहुँच की विशिष्ट आवश्यकता हो।
{{% /alert %}}

## **एन्क्रिप्टेड प्रस्तुति के गुण अपडेट करें**

एक एन्क्रिप्टेड PPTX फ़ाइल के लिए, [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) के साथ लोड की गई प्रस्तुति केवल सार्वजनिक मेटाडेटा पढ़ने के लिए होती है। Aspose.Slides उस मेटाडेटा‑केवल ऑब्जेक्ट से बदले हुए गुणों को सहेज नहीं सकता क्योंकि सार्वजनिक गुणों को एन्क्रिप्टेड प्रस्तुति के भीतर संबंधित डेटा के साथ सुसंगत रहना चाहिए। उन्हें अपडेट करने के लिए सही खोलने वाला पासवर्ड और पूर्ण लोड आवश्यक है।

उदाहरण को एक एन्क्रिप्टेड PPTX प्रस्तुति की आवश्यकता है जिसके सार्वजनिक दस्तावेज़ गुण हों और एक ज्ञात खोलने वाला पासवर्ड हो। यह पूर्ण प्रस्तुति को [LoadOptions.Password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/) से खोलता है, सार्वजनिक बिल्ट‑इन गुण अपडेट करता है, और परिणाम सहेजता है। फिर यह [IPresentationInfo.IsEncrypted](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/isencrypted/) का उपयोग करके एन्क्रिप्शन बरकरार है यह सत्यापित करता है और पासवर्ड के बिना सार्वजनिक मेटाडेटा फिर से खोलकर नई मानों की जाँच करता है:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

const string inputPath = "public-properties-encrypted.pptx";
const string outputPath = "updated-public-properties-encrypted.pptx";

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation(inputPath, loadOptions);

var documentProperties = presentation.DocumentProperties;
documentProperties.Title = "Updated Product Roadmap";
documentProperties.Keywords = "roadmap, planning, indexed";

presentation.Save(outputPath, SaveFormat.Pptx);

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(outputPath);
Console.WriteLine("The presentation is encrypted: " + presentationInfo.IsEncrypted);

var metadataLoadOptions = new LoadOptions { OnlyLoadDocumentProperties = true };
using var metadataPresentation = new Presentation(outputPath, metadataLoadOptions);

if (metadataPresentation.ProtectionManager.IsOnlyDocumentPropertiesLoaded)
{
    Console.WriteLine("Title: " + metadataPresentation.DocumentProperties.Title);
    Console.WriteLine("Keywords: " + metadataPresentation.DocumentProperties.Keywords);
}
else
{
    Console.WriteLine("The presentation was not loaded in document-properties-only mode.");
}
```

यदि कोई एप्लिकेशन प्रस्तुति सामग्री को डीक्रिप्ट या लोड करने की अनुमति नहीं रखता, तो उसे एन्क्रिप्टेड PPTX फ़ाइल के सार्वजनिक गुणों को केवल पढ़ने‑योग्य मानना चाहिए।

## **बिल्ट‑इन गुणों तक पहुँचें**

[IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/) इंटरफ़ेस टाइप्ड गुणों के माध्यम से बिल्ट‑इन मेटाडेटा उजागर करता है, जिसमें [Author](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/author/), [Title](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/title/), और [CreatedTime](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/createdtime/) शामिल हैं। यह उदाहरण मौजूदा प्रस्तुति को खोलता है और उसकी संग्रहीत मेटाडेटा को कंसोल पर प्रिंट करता है। मान इनपुट प्रस्तुति पर निर्भर करते हैं; कुछ फ़ील्ड ख़ाली हो सकती हैं।

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("AccessBuiltInProperties.pptx");

var documentProperties = presentation.DocumentProperties;

Console.WriteLine("Category: " + documentProperties.Category);
Console.WriteLine("Content status: " + documentProperties.ContentStatus);
Console.WriteLine("Creation date: " + documentProperties.CreatedTime);
Console.WriteLine("Author: " + documentProperties.Author);
Console.WriteLine("Comments: " + documentProperties.Comments);
Console.WriteLine("Keywords: " + documentProperties.Keywords);
Console.WriteLine("Last modified by: " + documentProperties.LastSavedBy);
Console.WriteLine("Manager: " + documentProperties.Manager);
Console.WriteLine("Modified date: " + documentProperties.LastSavedTime);
Console.WriteLine("Presentation format: " + documentProperties.PresentationFormat);
Console.WriteLine("Last print date: " + documentProperties.LastPrinted);
Console.WriteLine("Is shared between producers: " + documentProperties.SharedDoc);
Console.WriteLine("Subject: " + documentProperties.Subject);
Console.WriteLine("Title: " + documentProperties.Title);
```

### **संस्करण संख्या और संपादन समय रिपोर्ट करें**

`presentations` फ़ोल्डर में प्रत्येक PPTX फ़ाइल के लिए एक पंक्ति रिपोर्ट करने हेतु, स्लाइड्स को संपादन के लिये लोड किए बिना उसके [ReadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/readdocumentproperties/) को कॉल करके उसकी [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/) प्राप्त करें। `TimeSpan` की मानक `c` फ़ॉर्मेट में अवधि 24 घंटे पहुँचने पर दिन की संख्या शामिल होती है।

```csharp
using System;
using System.IO;
using Aspose.Slides;

Console.WriteLine("File | RevisionNumber | TotalEditingTime");
foreach (var path in Directory.EnumerateFiles("presentations", "*.pptx"))
{
    var info = PresentationFactory.Instance.GetPresentationInfo(path);
    var properties = info.ReadDocumentProperties();
    Console.WriteLine($"{Path.GetFileName(path)} | {properties.RevisionNumber} | {properties.TotalEditingTime:c}");
}
```

1 दिन, 2 घंटे, और 5 मिनट की रिकॉर्डेड संपादन समय वाले प्रस्तुति के लिए नमूना आउटपुट:

```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1.02:05:00
```

[RevisionNumber](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/revisionnumber/) लिखने योग्य मेटाडेटा है। उसका मान अकेले यह स्थापित नहीं कर सकता कि प्रस्तुति कितनी बार सहेजी गई या उसका संस्करण इतिहास कैसे रहा।

[TotalEditingTime](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/totaleditingtime/) फ़ाइल में रिकॉर्ड किया गया संपादन अवधि है। `00:00:00` का मान दर्शाता है कि संग्रहीत अवधि शून्य है। यह सिद्ध नहीं करता कि कोई प्रस्तुति को नहीं संपादित किया।

## **बिल्ट‑इन गुणों को संशोधित करें**

बिल्ट‑इन मेटाडेटा अपडेट करने के लिए, लिखने योग्य गुणों को मान असाइन करें जो [IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/) द्वारा उजागर किए गए हैं। यह उदाहरण मौजूदा प्रस्तुति को खोलता है, [Author](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/author/), [Title](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/title/), [Subject](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/subject/), [Comments](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/comments/), और [Manager](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/manager/) को सेट करता है, और फिर [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) के साथ अपडेटेड प्रस्तुति को सहेजता है। सहेजा गया PPTX नया मेटाडेटा रखेगा।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("ModifyBuiltInProperties.pptx");

var documentProperties = presentation.DocumentProperties;

documentProperties.Author = "Aspose.Slides for .NET";
documentProperties.Title = "Manage PowerPoint Presentation Properties";
documentProperties.Subject = "Modify Built-in Properties";
documentProperties.Comments = "Aspose description";
documentProperties.Manager = "Aspose manager";

presentation.Save("DocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **हायपरलिंक बेस प्रबंधित करें**

[IDocumentProperties.HyperlinkBase](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/hyperlinkbase/) दस्तावेज़‑स्तर का बेस रखता है जो रिलेटिव हायपरलिंक के लिए उपयोग होता है। यह तब उपयोगी होता है जब आप प्रस्तुति और उसकी लिंक फ़ाइलों को किसी अन्य स्थान पर ले जाते हैं। यह व्यक्तिगत हायपरलिंक के [IHyperlink.ExternalUrl](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurl/) से अलग है: बेस बदलने से संग्रहीत लिंक पते पुनः नहीं लिखे जाते और न ही निरपेक्ष गंतव्य बदलते हैं।

उदाहरण को ऐसी प्रस्तुति की आवश्यकता है जिसमें एक रिलेटिव लिंक (उदा., `target.html`) और एक निरपेक्ष लिंक (उदा., `https://example.org/absolute.html`) दोनों हों। यह मौजूदा बेस पढ़ता है, नया बेस पता असाइन करता है, और मूल्य जाँचने के लिए प्रस्तुति को सहेज कर पुनः खोलता है। फिर यह बेस को `string.Empty` से साफ़ करता है और अलग फ़ाइल में खाली मान की जाँच करता है। उदाहरण बेस पते को अपनी लिंक फ़ाइलों के स्थान से बदलें।

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("hyperlinks.pptx");
Console.WriteLine("Original base: " + presentation.DocumentProperties.HyperlinkBase);

const string newBase = "https://example.com/new/";
presentation.DocumentProperties.HyperlinkBase = newBase;
presentation.Save("hyperlinks-updated.pptx", SaveFormat.Pptx);

using var updatedPresentation = new Presentation("hyperlinks-updated.pptx");
Console.WriteLine("Base preserved: " + (updatedPresentation.DocumentProperties.HyperlinkBase == newBase));

updatedPresentation.DocumentProperties.HyperlinkBase = string.Empty;
updatedPresentation.Save("hyperlinks-cleared.pptx", SaveFormat.Pptx);

using var clearedPresentation = new Presentation("hyperlinks-cleared.pptx");
Console.WriteLine("Base cleared: " + (clearedPresentation.DocumentProperties.HyperlinkBase == string.Empty));
```

दोनों सत्यापन संदेश `True` प्रिंट करेंगे। बेस को साफ़ करने से व्यक्तिगत हायपरलिंक पते अपरिवर्तित रहते हैं।

`target.pptx` के लिए एक रिलेटिव लिंक `old/target.pptx` खोलता था जब बेस `old` फ़ोल्डर की ओर इंगित करता था। बेस को `new` फ़ोल्डर में बदलने, सहेजने, और प्रस्तुति को पुनः खोलने के बाद वही लिंक `new/target.pptx` खोलता है। निरपेक्ष लिंक वही फ़ाइल खोलता रहता है। प्रस्तुति को स्थानांतरित करने या बेस बदलने से पहले और बाद में PowerPoint में अपने रिलेटिव लिंक का परीक्षण करें।

## **कस्टम प्रस्तुति गुण जोड़ें**

कस्टम गुण उन मेटाडेटा को संग्रहीत करते हैं जिनके लिए कोई बिल्ट‑इन फ़ील्ड नहीं है। [IDocumentProperties indexer](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/item/) आपको गुण नाम के द्वारा मान असाइन करने की अनुमति देता है। यह उदाहरण एक प्रस्तुति बनाता है, दो पाठ मान और एक पूर्णांक संस्करण मान जोड़ता है, और [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) के साथ प्रस्तुति को सहेजता है। मौजूदा नाम को मान असाइन करने से वह गुण का मान बदल जाता है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var documentProperties = presentation.DocumentProperties;

documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **कस्टम गुणों तक पहुँचें और संशोधित करें**

यह उदाहरण कस्टम गुणों वाली प्रस्तुति को खोलता है और उन्हें इटररेट करने के लिए [CountOfCustomProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/countofcustomproperties/) का उपयोग करता है। [GetCustomPropertyName](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/getcustompropertyname/) शून्य‑आधारित इंडेक्स स्वीकार करता है और [IDocumentProperties indexer](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/item/) द्वारा उपयोग किया गया नाम लौटाता है। उदाहरण प्रत्येक मूल नाम और मान को प्रिंट करता है, सभी मानों को क्रमांकित स्ट्रिंग से बदल देता है चाहे उनका मूल प्रकार कुछ भी हो, और बदलाव सहेजता है। यदि कोई कस्टम गुण नहीं हैं, तो लूप कोई परिवर्तन नहीं करता।

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("AccessAndModifyProperties.pptx");

var documentProperties = presentation.DocumentProperties;

for (var i = 0; i < documentProperties.CountOfCustomProperties; i++)
{
    var propertyName = documentProperties.GetCustomPropertyName(i);
    var propertyValue = documentProperties[propertyName];

    Console.WriteLine("Custom property name: " + propertyName);
    Console.WriteLine("Custom property value: " + propertyValue);

    documentProperties[propertyName] = "New Value " + (i + 1);
}

presentation.Save("CustomProperties_output.pptx", SaveFormat.Pptx);
```

## **लाइव उदाहरण**

ऑनलाइन ऐप **[View & Edit PowerPoint Metadata](https://products.aspose.app/slides/metadata)** आज़माएँ ताकि Aspose.Slides API का उपयोग करके दस्तावेज़ गुणों के साथ कैसे काम किया जाए देखें:

[![व्यू और एडिट पावरपॉइंट मेटाडेटा](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं प्रस्तुति से बिल्ट‑इन गुण को कैसे हटाऊँ?**

बिल्ट‑इन गुण प्रस्तुति का अभिन्न हिस्सा होते हैं और उन्हें पूरी तरह से हटाया नहीं जा सकता। हालांकि, आप उनके मान बदल सकते हैं या यदि विशिष्ट गुण की अनुमति देता है तो उन्हें खाली सेट कर सकते हैं।

**यदि मैं ऐसा कस्टम गुण जोड़ूँ जो पहले से मौजूद है तो क्या होगा?**

यदि आप ऐसा कस्टम गुण जोड़ते हैं जो पहले से मौजूद है, तो उसका मौजूदा मान नए मान से अधिलेखित हो जाएगा। आपको पहले से गुण को हटाने या जाँचने की आवश्यकता नहीं है, क्योंकि Aspose.Slides स्वचालित रूप से गुण के मान को अपडेट कर देता है।

**क्या मैं पूरी प्रस्तुति लोड किए बिना प्रस्तुति गुणों तक पहुँच सकता हूँ?**

हां। आप [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/) का उपयोग करके फिर [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/readdocumentproperties/) के साथ संग्रहीत दस्तावेज़ मेटाडेटा पढ़ सकते हैं बिना [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) इंस्टेंस बनाए। पूर्ण रिपोर्टिंग उदाहरण और फ़ॉर्मेट‑विशिष्ट सीमाओं के लिए देखें [Build a Lightweight Presentation Inventory](/slides/hi/net/examine-presentation/)।

**क्या मैं एन्क्रिप्टेड प्रस्तुति के सार्वजनिक गुण खोलने वाला पासवर्ड बिना पढ़ सकता हूँ?**

हां। प्रस्तुति को [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) को `false` पर सेट करके एन्क्रिप्ट किया गया होना चाहिए, और उसे [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) को `true` पर सेट करके लोड किया गया होना चाहिए।

**क्या मैं डॉक्यूमेंट‑प्रॉपर्टीज़‑ओनली मोड में एन्क्रिप्टेड PPTX फ़ाइल को अपडेट कर सकता हूँ?**

नहीं। सार्वजनिक और एन्क्रिप्टेड गुण डेटा को सुसंगत रहना चाहिए, इसलिए एन्क्रिप्टेड PPTX फ़ाइल को अपडेट करने के लिए सही खोलने वाले पासवर्ड के साथ पूरी प्रस्तुति लोड करनी आवश्यक है।