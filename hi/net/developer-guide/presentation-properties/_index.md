---
title: .NET में प्रस्तुति गुणों का प्रबंधन
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
- दस्तावेज़ मेटाडाटा
- मेटाडाटा संपादित करें
- प्रूफिंग भाषा
- डिफ़ॉल्ट भाषा
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET में प्रस्तुति गुणों को प्रमुखता दें और अपने PowerPoint और OpenDocument फ़ाइलों में खोज, ब्रांडिंग और कार्यप्रवाह को सहज बनाएं।"
---
## **परिचय**

Aspose.Slides for .NET **बिल्ट‑इन** और **कस्टम** दस्तावेज़ गुणों का समर्थन करता है। इन गुणों का उपयोग प्रस्तुति मेटाडाटा पढ़ने और अपडेट करने के लिए किया जाता है, जैसे लेखक, शीर्षक, और उपयोगकर्ता‑परिभाषित मान।

Aspose.Slides आपको प्रस्तुति दस्तावेज़ गुणों के साथ काम करने की अनुमति देता है [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/) इंटरफ़ेस के माध्यम से। इस इंटरफ़ेस का एक इंस्टेंस [IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/) द्वारा लौटाया जाता है। नीचे के उदाहरण दिखाते हैं कि इन गुणों को कैसे पढ़ें, संशोधित करें और प्रबंधित करें।

{{% alert color="info" title="Note" %}}
Aspose.Slides प्रस्तुतियों को सहेजते समय एप्लिकेशन और उत्पादक मेटाडाटा को प्रबंधित करता है; ये फ़ील्ड उस सॉफ़्टवेयर की पहचान करती हैं जिसने आउटपुट बनाया।
{{% /alert %}}

## **प्रस्तुति गुणों को प्रबंधित करें**

दस्तावेज़ गुण प्रस्तुति सामग्री के साथ वर्णनात्मक जानकारी संग्रहीत करते हैं। वे दो श्रेणियों में आते हैं:

- **बिल्ट‑इन गुण** मानक मेटाडाटा रखते हैं, जैसे शीर्षक, लेखक, और दस्तावेज़ सांख्यिकी।
- **कस्टम गुण** उपयोगकर्ता‑परिभाषित नाम/मान युग्म संग्रहीत करते हैं।

Aspose.Slides for .NET दोनों श्रेणियों तक पहुँच प्रदान करता है। PowerPoint में, दस्तावेज़ मेटाडाटा निरीक्षण करने के लिए **File → Info → Properties → Advanced Properties** चुनें। संवाद जानकारी को टैब में समूहित करता है जैसे **Summary**, **Statistics**, **Contents**, और **Custom**। उपयोगकर्ता‑परिभाषित गुणों को प्रबंधित करने के लिए **Custom** टैब उपयोग करें।

## **एक एन्क्रिप्टेड प्रस्तुति से सार्वजनिक गुण पढ़ें**

एक खोलने वाला पासवर्ड सामान्यतः प्रस्तुति सामग्री और दस्तावेज़ गुणों दोनों की सुरक्षा करता है। जब प्रस्तुति को [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) `false` पर सेट करके एन्क्रिप्ट किया जाता है, तो उसके दस्तावेज़ गुण सार्वजनिक रह जाते हैं। तब एप्लिकेशन [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) को `true` सेट कर सकता है और खोलने वाला पासवर्ड दिए बिना सार्वजनिक मेटाडाटा पढ़ सकता है।

[LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) यह नियंत्रित करता है कि Aspose.Slides क्या लोड करता है; यह कुछ भी डिक्रिप्ट नहीं करता। यदि गुण एन्क्रिप्शन में शामिल थे, तो पासवर्ड के बिना उन्हें लोड करना विफल होगा। यदि प्रस्तुति एन्क्रिप्ट नहीं है, तो विकल्प को नजरअंदाज किया जाता है और पूरी प्रस्तुति लोड होती है।

उदाहरण को सार्वजनिक गुणों वाले एन्क्रिप्टेड प्रस्तुति की आवश्यकता होती है। यह लोडिंग मोड को [IProtectionManager.IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/isonlydocumentpropertiesloaded/) द्वारा सत्यापित करता है और फिर [IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/) के माध्यम से बिल्ट‑इन गुण पढ़ता है:

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

इस मोड में, स्लाइड सामग्री लोड नहीं होती। स्लाइड, मास्टर, लेआउट, शैलियां, मीडिया, और अन्य प्रस्तुति ऑब्जेक्ट उपलब्ध नहीं होते। एप्लिकेशन को हमेशा [IProtectionManager.IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/isonlydocumentpropertiesloaded/) की जाँच करनी चाहिए इससे पहले कि वह ऐसी क्रिया करे जिसके लिए पूरी प्रस्तुति ऑब्जेक्ट मॉडल आवश्यक हो।

{{% alert color="warning" title="Security" %}}
सार्वजनिक मेटाडाटा लेखक के नाम, शीर्षक, विषय, कुंजी शब्द, कंपनी सूचना, टिप्पणियां, और कस्टम मान उजागर कर सकता है। संवेदनशील गुणों को प्रस्तुति के साथ एन्क्रिप्ट करें। उन्हें सार्वजनिक तभी रखें जब इंडेक्सिंग, वर्गीकरण, खोज, या दस्तावेज़‑प्रबंधन प्रणालियों को पासवर्ड के बिना पहुँच की विशिष्ट आवश्यकता हो।
{{% /alert %}}

## **एक एन्क्रिप्टेड प्रस्तुति के गुण अपडेट करें**

एक एन्क्रिप्टेड PPTX फ़ाइल के लिए, [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) के साथ लोड की गई प्रस्तुति सार्वजनिक मेटाडाटा पढ़ने के लिए है। Aspose.Slides उस मेटाडाटा‑केवल ऑब्जेक्ट से बदलें हुए गुणों को सहेज नहीं सकता क्योंकि सार्वजनिक गुणों को एन्क्रिप्टेड प्रस्तुति के भीतर संबंधित डेटा के साथ सुसंगत रहना चाहिए। इसलिए अपडेट करने के लिए सही खोलने वाला पासवर्ड और पूरी लोड आवश्यक है।

उदाहरण को सार्वजनिक दस्तावेज़ गुणों वाले एन्क्रिप्टेड PPTX प्रस्तुति और ज्ञात खोलने वाले पासवर्ड की आवश्यकता होती है। यह पूरी प्रस्तुति को [LoadOptions.Password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/) के साथ खोलता है, सार्वजनिक बिल्ट‑इन गुण अपडेट करता है, और परिणाम सहेजता है। फिर यह [IPresentationInfo.IsEncrypted](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/isencrypted/) का उपयोग करके एन्क्रिप्शन बनी रहने की जाँच करता है और पासवर्ड के बिना सार्वजनिक मेटाडाटा फिर से खोलकर नए मानों की पुष्टि करता है:

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

यदि एप्लिकेशन को प्रस्तुति सामग्री को डिक्रिप्ट या लोड करने की अनुमति नहीं है, तो उसे एन्क्रिप्टेड PPTX फ़ाइल के सार्वजनिक गुणों को केवल‑पढ़ने योग्य मानना चाहिए।

## **बिल्ट‑इन गुणों तक पहुंचें**

[IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/) इंटरफ़ेस टाइप्ड गुणों के माध्यम से बिल्ट‑इन मेटाडाटा उजागर करता है, जिसमें [Author](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/author/), [Title](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/title/), और [CreatedTime](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/createdtime/) शामिल हैं। यह उदाहरण मौजूदा प्रस्तुति खोलता है और उसके संग्रहीत मेटाडाटा को कंसोल पर प्रिंट करता है। मान इनपुट प्रस्तुति पर निर्भर करते हैं; कुछ फ़ील्ड खाली हो सकते हैं।

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

## **बिल्ट‑इन गुणों को संशोधित करें**

बिल्ट‑इन मेटाडाटा अपडेट करने के लिए, [IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/) द्वारा उजागर लिखने योग्य गुणों को मान असाइन करें। यह उदाहरण मौजूदा प्रस्तुति खोलता है, [Author](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/author/), [Title](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/title/), [Subject](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/subject/), [Comments](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/comments/), और [Manager](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/manager/) सेट करता है, फिर [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) के साथ अपडेटेड प्रस्तुति सहेजता है। सहेजा गया PPTX नए मेटाडाटा को शामिल करता है।

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

## **हाइपरलिंक बेस को प्रबंधित करें**

[IDocumentProperties.HyperlinkBase](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/hyperlinkbase/) सापेक्ष हाइपरलिंक के लिए दस्तावेज़‑स्तर आधार को संग्रहीत करता है। यह प्रस्तुति और उसकी लिंक्ड फ़ाइलों को दूसरे स्थान पर ले जाने पर उपयोगी होता है। यह व्यक्तिगत हाइपरलिंक के [IHyperlink.ExternalUrl](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurl/) से अलग है: आधार बदलने से संग्रहीत लिंक पते नहीं बदलते और निरपेक्ष गंतव्य नहीं बदलते।

उदाहरण को एक प्रस्तुति की आवश्यकता है जिसमें एक सापेक्ष लिंक, जैसे `target.html`, और एक निरपेक्ष लिंक, जैसे `https://example.org/absolute.html` दोनों हों। यह मौजूदा आधार पढ़ता है, नया आधार पता असाइन करता है, और मान की जांच के लिए प्रस्तुति को सहेजता और पुनः खोलता है। फिर यह `string.Empty` के साथ आधार को साफ़ करता है और अलग फ़ाइल में खाली मान की पुष्टि करता है। उदाहरण आधार पते को अपने लिंक्ड फ़ाइलों के स्थान से बदलें।

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

दोनों सत्यापन संदेश `True` प्रिंट करने चाहिए। आधार को साफ़ करने से व्यक्तिगत हाइपरलिंक पते अपरिवर्तित रहते हैं।

`target.pptx` के लिए सापेक्ष लिंक ने `old/target.pptx` खोला जब आधार `old` फ़ोल्डर की ओर इशारा कर रहा था। आधार को `new` फ़ोल्डर में बदलने, सहेजने और प्रस्तुति को पुनः खोलने के बाद वही लिंक `new/target.pptx` खोलता है। निरपेक्ष लिंक वही फ़ाइल खोलता रहा। प्रस्तुति को स्थानांतरित करने या आधार बदलने से पहले और बाद में PowerPoint में अपने सापेक्ष लिंक परीक्षण करें।

## **कस्टम प्रस्तुति गुण जोड़ें**

कस्टम गुण ऐसे मेटाडाटा संग्रहीत करते हैं जिनका कोई संबंधित बिल्ट‑इन फ़ील्ड नहीं होता। [IDocumentProperties indexer](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/item/) आपको गुण नाम द्वारा मान असाइन करने की अनुमति देता है। यह उदाहरण एक प्रस्तुति बनाता है, दो टेक्स्ट मान और एक पूर्णांक संस्करण मान जोड़ता है, और [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) के साथ प्रस्तुति सहेजता है। मौजूदा नाम को मान असाइन करने से उस गुण का मान बदल जाता है।

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

## **कस्टम गुणों तक पहुंचें और संशोधित करें**

यह उदाहरण कस्टम गुणों वाले प्रस्तुति को खोलता है और [CountOfCustomProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/countofcustomproperties/) का उपयोग करके उन पर इटरिट करता है। [GetCustomPropertyName](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/getcustompropertyname/) शून्य‑आधारित इंडेक्स लेता है और [IDocumentProperties indexer](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/item/) द्वारा उपयोग किया गया नाम वापस करता है। उदाहरण प्रत्येक मूल नाम और मान को प्रिंट करता है, प्रत्येक मान को क्रमांकित स्ट्रिंग से बदल देता है चाहे उसका मूल प्रकार कुछ भी हो, और बदलाव सहेजता है। यदि कोई कस्टम गुण नहीं हैं, तो लूप कोई परिवर्तन नहीं करता।

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

Aspose.Slides API का उपयोग करके दस्तावेज़ गुणों के साथ काम करने का तरीका देखने के लिए ऑनलाइन एप्लिकेशन [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) आज़माएँ:

[![PowerPoint मेटाडाटा देखें और संपादित करें](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं प्रस्तुति से बिल्ट‑इन गुण कैसे हटा सकता हूँ?**

बिल्ट‑इन गुण प्रस्तुति का अविभाज्य हिस्सा होते हैं और उन्हें पूरी तरह से हटाया नहीं जा सकता। हालांकि, आप उन्हें बदल सकते हैं या यदि विशिष्ट गुण अनुमति देता है तो खाली सेट कर सकते हैं।

**यदि मैं कोई कस्टम गुण जोड़ूँ जो पहले से मौजूद है तो क्या होता है?**

यदि आप मौजूद कस्टम गुण जोड़ते हैं, तो उसका मौजूदा मान नए मान से अधिलेखित हो जाएगा। आपको पहले से हटाने या जांचने की ज़रूरत नहीं है, क्योंकि Aspose.Slides स्वचालित रूप से गुण के मान को अपडेट कर देता है।

**क्या मैं प्रस्तुति को पूरी तरह लोड किए बिना उसके गुणों तक पहुंच सकता हूँ?**

हाँ। [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/) का उपयोग करके फिर [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/readdocumentproperties/) से बिना [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) इंस्टेंस बनाए संग्रहीत दस्तावेज़ मेटाडाटा पढ़ सकते हैं। पूर्ण रिपोर्ट उदाहरण और फ़ॉर्मेट‑विशिष्ट सीमाओं के लिए देखें [Build a Lightweight Presentation Inventory](/slides/hi/net/examine-presentation/)।

**क्या मैं एन्क्रिप्टेड प्रस्तुति के सार्वजनिक गुणों को उसके खोलने वाले पासवर्ड के बिना पढ़ सकता हूँ?**

हाँ। प्रस्तुति को [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) `false` पर सेट करके एन्क्रिप्ट किया गया होना चाहिए, और उसे [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) `true` के साथ लोड किया जाना चाहिए।

**क्या मैं डॉक्यूमेंट‑प्रॉपर्टीज‑ओनली मोड में एन्क्रिप्टेड PPTX फ़ाइल को अपडेट कर सकता हूँ?**

नहीं। सार्वजनिक और एन्क्रिप्टेड गुण डेटा को सुसंगत रहना चाहिए, इसलिए एन्क्रिप्टेड PPTX फ़ाइल को अपडेट करने के लिए सही खोलने वाले पासवर्ड के साथ पूरी प्रस्तुति लोड करनी पड़ती है।