---
title: .NET में प्रस्तुति प्रॉपर्टीज़ प्रबंधित करें
linktitle: प्रस्तुति प्रॉपर्टीज़
type: docs
weight: 70
url: /hi/net/presentation-properties/
keywords:
- PowerPoint प्रॉपर्टीज़
- प्रस्तुति प्रॉपर्टीज़
- दस्तावेज़ प्रॉपर्टीज़
- बिल्ट-इन प्रॉपर्टीज़
- कस्टम प्रॉपर्टीज़
- एडवांस्ड प्रॉपर्टीज़
- प्रॉपर्टीज़ प्रबंधित करें
- प्रॉपर्टीज़ संशोधित करें
- दस्तावेज़ मेटाडेटा
- मेटाडेटा संपादित करें
- प्रूफिंग भाषा
- डिफॉल्ट भाषा
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET में प्रस्तुति प्रॉपर्टीज़ को मास्टर करें और अपने PowerPoint तथा OpenDocument फ़ाइलों में खोज, ब्रांडिंग और कार्यप्रवाह को सरल बनाएं।"
---
## **परिचय**

Aspose.Slides for .NET दो प्रकार की दस्तावेज़ प्रॉपर्टीज़ को समर्थन देता है: **Built-in** और **Custom**। इन दोनों प्रॉपर्टी प्रकारों को Aspose.Slides for .NET API का उपयोग करके आसानी से एक्सेस और प्रबंधित किया जा सकता है।

Aspose.Slides आपको प्रस्तुति दस्तावेज़ प्रॉपर्टीज़ के साथ काम करने की सुविधा देता है [IDocumentProperties](https://reference.aspose.com/slides/hi/net/aspose.slides/idocumentproperties/) इंटरफ़ेस के माध्यम से। इस इंटरफ़ेस का एक उदाहरण [IPresentation.DocumentProperties](https://reference.aspose.com/slides/hi/net/aspose.slides/ipresentation/documentproperties/) द्वारा लौटाया जाता है। नीचे दिए गए उदाहरण दिखाते हैं कि इन प्रॉपर्टीज़ को कैसे पढ़ा, संशोधित और प्रबंधित किया जाता है।

{{% alert color="info" title="Note" %}}
कृपया ध्यान दें कि **Application** और **Producer** फ़ील्ड को संशोधित नहीं किया जा सकता, क्योंकि ये फ़ील्ड हमेशा "Aspose Ltd." और "Aspose.Slides for .NET x.x.x" दिखाएंगे।
{{% /alert %}} 

## **प्रस्तुति प्रॉपर्टीज़ का प्रबंधन करें**

Microsoft PowerPoint प्रस्तुति फ़ाइलों में प्रॉपर्टीज़ जोड़ने की सुविधा प्रदान करता है। ये दस्तावेज़ प्रॉपर्टीज़ फ़ाइलों के साथ उपयोगी जानकारी संग्रहीत करने की अनुमति देती हैं। दो प्रकार की दस्तावेज़ प्रॉपर्टीज़ हैं:

- सिस्टम-परिभाषित (built-in) प्रॉपर्टीज़
- उपयोगकर्ता-परिभाषित (custom) प्रॉपर्टीज़

**Built-in** प्रॉपर्टीज़ दस्तावेज़ के सामान्य जानकारी रखती हैं, जैसे दस्तावेज़ शीर्षक, लेखक का नाम, दस्तावेज़ आँकड़े, आदि।

**Custom** प्रॉपर्टीज़ को उपयोगकर्ता द्वारा **Name/Value** युग्म के रूप में परिभाषित किया जाता है, जहाँ नाम और मान दोनों उपयोगकर्ता‑निर्धारित होते हैं।

Aspose.Slides for .NET का उपयोग करके, डेवलपर दोनों‑built‑in और custom प्रॉपर्टीज़ को एक्सेस और संशोधित कर सकते हैं।

Microsoft PowerPoint उपयोगकर्ताओं को Office आइकन पर क्लिक करके, फिर **File → Info → Properties** चुनकर दस्तावेज़ प्रॉपर्टीज़ प्रबंधित करने की अनुमति देता है। **Advanced Properties** चुनने पर एक संवाद बॉक्स खुलता है जहाँ आप प्रस्तुति फ़ाइल की सभी दस्तावेज़ प्रॉपर्टीज़ का प्रबंधन कर सकते हैं।

**Properties** संवाद में कई टैब होते हैं, जैसे **General**, **Summary**, **Statistics**, **Contents**, और **Custom**। प्रत्येक टैब PowerPoint फ़ाइल से संबंधित विशिष्ट प्रकार की जानकारी को कॉन्फ़िगर करने के विकल्प प्रदान करता है। **Custom** टैब उपयोगकर्ता‑परिभाषित प्रॉपर्टीज़ को प्रबंधित करने के लिए उपयोग किया जाता है।

## **एन्क्रिप्टेड प्रस्तुति से सार्वजनिक प्रॉपर्टीज़ पढ़ें**

एक खुलने वाला पासवर्ड सामान्यतः प्रस्तुति सामग्री और दस्तावेज़ प्रॉपर्टीज़ दोनों की रक्षा करता है। जब किसी प्रस्तुति को [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/hi/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) को `false` पर सेट करके एन्क्रिप्ट किया जाता है, तो उसकी दस्तावेज़ प्रॉपर्टीज़ सार्वजनिक रहती हैं। तब अनुप्रयोग [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/hi/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) को `true` पर सेट कर सार्वजनिक मेटाडेटा को बिना खुलने वाले पासवर्ड के पढ़ सकता है।

`OnlyLoadDocumentProperties` नियंत्रित करता है कि Aspose.Slides क्या लोड करता है; यह कुछ भी डिक्रिप्ट नहीं करता। यदि प्रॉपर्टीज़ एन्क्रिप्शन में शामिल थीं, तो पासवर्ड के बिना उन्हें लोड करना विफल होगा। यदि प्रस्तुति एन्क्रिप्टेड नहीं है, तो यह विकल्प अनदेखा किया जाता है और पूरी प्रस्तुति लोड होती है।

निम्न उदाहरण [IProtectionManager.IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/hi/net/aspose.slides/iprotectionmanager/isonlydocumentpropertiesloaded/) के माध्यम से लोड मोड की जाँच करता है और फिर [IPresentation.DocumentProperties](https://reference.aspose.com/slides/hi/net/aspose.slides/ipresentation/documentproperties/) के माध्यम से built‑in प्रॉपर्टीज़ पढ़ता है:

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { OnlyLoadDocumentProperties = true };
using var presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);

if (presentation.ProtectionManager.IsOnlyDocumentPropertiesLoaded)
{
    var properties = presentation.DocumentProperties;

    Console.WriteLine("Author: " + properties.Author);
    Console.WriteLine("Title: " + properties.Title);
    Console.WriteLine("Keywords: " + properties.Keywords);
}
else
{
    Console.WriteLine("The presentation was not loaded in document-properties-only mode.");
}
```

इस मोड में स्लाइड सामग्री लोड नहीं होती। स्लाइड्स, मास्टर्स, लेआउट्स, शैप्स, मीडिया और अन्य प्रस्तुति ऑब्जेक्ट उपलब्ध नहीं होते। अनुप्रयोग को हमेशा `IsOnlyDocumentPropertiesLoaded` की जाँच करनी चाहिए इससे पहले कि वह कोई ऐसी क्रिया करे जिसके लिए पूर्ण प्रस्तुति ऑब्जेक्ट मॉडल आवश्यक हो।

{{% alert color="warning" title="Security" %}}
सार्वजनिक मेटाडेटा से लेखक के नाम, शीर्षक, विषय, कीवर्ड, कंपनी जानकारी, टिप्पणियाँ और कस्टम मान उजागर हो सकते हैं। संवेदनशील प्रॉपर्टीज़ को प्रस्तुति के साथ एन्क्रिप्ट करें। उन्हें केवल तब सार्वजनिक रखें जब इंडेक्सिंग, वर्गीकरण, खोज, या दस्तावेज़‑प्रबंधन प्रणालियों को पासवर्ड के बिना पहुंच की विशिष्ट आवश्यकता हो।
{{% /alert %}}

## **एन्क्रिप्टेड प्रस्तुति की प्रॉपर्टीज़ अपडेट करें**

एन्क्रिप्टेड PPTX फ़ाइल के लिए, `OnlyLoadDocumentProperties` के साथ लोड की गई प्रस्तुति सार्वजनिक मेटाडेटा पढ़ने के लिए होती है। Aspose.Slides उस मेटाडेटा‑केवल ऑब्जेक्ट से बदलें हुए प्रॉपर्टीज़ को सहेज नहीं सकता क्योंकि सार्वजनिक प्रॉपर्टीज़ को एन्क्रिप्टेड प्रस्तुति के भीतर संबंधित डेटा के साथ सुसंगत रहना चाहिए। इसलिए इन्हें अपडेट करने के लिए सही खुलने वाला पासवर्ड और पूर्ण लोड आवश्यक है।

निम्न उदाहरण [LoadOptions.Password](https://reference.aspose.com/slides/hi/net/aspose.slides/loadoptions/password/) का उपयोग करके प्रस्तुति खोलता है, सार्वजनिक built‑in प्रॉपर्टीज़ को अपडेट करता है, और परिणाम सहेजता है। फिर यह [IPresentationInfo.IsEncrypted](https://reference.aspose.com/slides/hi/net/aspose.slides/ipresentationinfo/isencrypted/) का उपयोग करके एन्क्रिप्शन बनाए रखा गया है या नहीं जाँचता है और पासवर्ड के बिना सार्वजनिक मेटाडेटा को पुनः खोलकर नए मानों की पुष्टि करता है:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

const string inputPath = "public-properties-encrypted.pptx";
const string outputPath = "updated-public-properties-encrypted.pptx";

{
    var loadOptions = new LoadOptions { Password = "open_password" };
    using var presentation = new Presentation(inputPath, loadOptions);

    presentation.DocumentProperties.Title = "Updated Product Roadmap";
    presentation.DocumentProperties.Keywords = "roadmap, planning, indexed";
    presentation.Save(outputPath, SaveFormat.Pptx);
}

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

यदि किसी अनुप्रयोग को प्रस्तुति सामग्री को डिक्रिप्ट या लोड करने की अनुमति नहीं है, तो उसे एन्क्रिप्टेड PPTX फ़ाइल की सार्वजनिक प्रॉपर्टीज़ को केवल‑पढ़ने योग्य मानना चाहिए।

## **Built‑in प्रॉपर्टीज़ तक पहुँचें**

[IDocumentProperties](https://reference.aspose.com/slides/hi/net/aspose.slides/idocumentproperties/) इंटरफ़ेस द्वारा उजागर इन प्रॉपर्टीज़ में शामिल हैं: **Creator** (Author), **Description**, **Keywords**, **Created** (Creation Date), **Modified** (Modification Date), **Printed** (Last Print Date), **LastModifiedBy**, **SharedDoc** (दस्तावेज़ विभिन्न निर्माताओं के बीच साझा है या नहीं दर्शाता है), **PresentationFormat**, **Subject**, **Title**, आदि।

```cs
using Aspose.Slides;

// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टैंस बनाएं।
using Presentation presentation = new Presentation("AccessBuiltInProperties.pptx");

// प्रस्तुति से जुड़े IDocumentProperties प्रकार के ऑब्जेक्ट का संदर्भ प्राप्त करें।
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Display the Built-in properties.
Console.WriteLine("Category : " + documentProperties.Category);
Console.WriteLine("Content status : " + documentProperties.ContentStatus);
Console.WriteLine("Creation date : " + documentProperties.CreatedTime);
Console.WriteLine("Author : " + documentProperties.Author);
Console.WriteLine("Comments : " + documentProperties.Comments);
Console.WriteLine("Key words : " + documentProperties.Keywords);
Console.WriteLine("Last modified by : " + documentProperties.LastSavedBy);
Console.WriteLine("Manager : " + documentProperties.Manager);
Console.WriteLine("Modified date : " + documentProperties.LastSavedTime);
Console.WriteLine("Presentation format : " + documentProperties.PresentationFormat);
Console.WriteLine("Last print date : " + documentProperties.LastPrinted);
Console.WriteLine("Is shared between producers : " + documentProperties.SharedDoc);
Console.WriteLine("Subject : " + documentProperties.Subject);
Console.WriteLine("Title : " + documentProperties.Title);
```

## **Built‑in प्रॉपर्टीज़ संशोधित करें**

प्रस्तुति फ़ाइलों की built‑in प्रॉपर्टीज़ को संशोधित करना उतना ही सरल है जितना उन्हें एक्सेस करना। आप केवल वांछित प्रॉपर्टी को एक स्ट्रिंग मान असाइन कर सकते हैं, और प्रॉपर्टी का मान अपडेट हो जाएगा। नीचे दिए गए उदाहरण में हम प्रस्तुति फ़ाइल की built‑in दस्तावेज़ प्रॉपर्टीज़ को कैसे संशोधित किया जाए, दर्शाते हैं।

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Presentation क्लास का इंस्टैंस बनाएं जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है।
using Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");

// प्रेजेंटेशन से जुड़े IDocumentProperties प्रकार के ऑब्जेक्ट का रेफ़रेंस प्राप्त करें।
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Built-in प्रॉपर्टीज़ सेट करें।
documentProperties.Author = "Aspose.Slides for .NET";
documentProperties.Title = "Manage PowerPoint Presentation Properties";
documentProperties.Subject = "Modify Built-in Properties";
documentProperties.Comments = "Aspose description";
documentProperties.Manager = "Aspose manager";

// प्रेज़ेंटेशन को फ़ाइल में सहेजें।
presentation.Save("DocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **कस्टम प्रस्तुति प्रॉपर्टीज़ जोड़ें**

कस्टम प्रस्तुति प्रॉपर्टीज़ डेवलपर्स को प्रस्तुति फ़ाइल में अतिरिक्त मेटाडेटा या विशिष्ट जानकारी संग्रहीत करने की सुविधा देती हैं। Aspose.Slides प्रोग्रामेटिक रूप से इन कस्टम प्रॉपर्टीज़ को बनाने और प्रबंधित करने को सरल बनाता है। नीचे दिए गए उदाहरण दिखाते हैं कि अपनी प्रस्तुतियों में कस्टम प्रॉपर्टीज़ कैसे जोड़ें।

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Presentation क्लास का इंस्टैंस बनाएं।
using Presentation presentation = new Presentation();

// प्रस्तुति से जुड़े IDocumentProperties प्रकार के ऑब्जेक्ट का रेफ़रेंस प्राप्त करें।
IDocumentProperties documentProperties = presentation.DocumentProperties;

// कस्टम प्रॉपर्टीज़ जोड़ें।
documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

// प्रस्तुति को फ़ाइल में सहेजें।
presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **कस्टम प्रॉपर्टीज़ तक पहुँचें और संशोधित करें**

Aspose.Slides डेवलपर्स को मौजूदा कस्टम प्रॉपर्टीज़ को एक्सेस करने और उनके मानों को आसानी से संशोधित करने की अनुमति भी देता है। यह कार्यक्षमता सटीक मेटाडेटा बनाए रखने और उपयोगकर्ता इनपुट या व्यावसायिक तर्क के आधार पर गतिशील अपडेट को समर्थन देती है। नीचे के उदाहरण दर्शाते हैं कि प्रस्तुति में कस्टम प्रॉपर्टी मानों को कैसे प्राप्त और अपडेट करें।

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टैंस बनाएं।
using Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");

// प्रस्तुति से जुड़े IDocumentProperties प्रकार के ऑब्जेक्ट का रेफ़रेंस प्राप्त करें।
IDocumentProperties documentProperties = presentation.DocumentProperties;

// कस्टम प्रॉपर्टीज़ तक पहुँचें और उन्हें संशोधित करें।
for (int i = 0; i < documentProperties.CountOfCustomProperties; i++)
{
    string propertyName = documentProperties.GetCustomPropertyName(i);
    object propertyValue = documentProperties[propertyName];

    // कस्टम प्रॉपर्टी का नाम और मान प्रदर्शित करें।
    Console.WriteLine("Custom property name : " + propertyName);
    Console.WriteLine("Custom property value : " + propertyValue);

    // कस्टम प्रॉपर्टी का मान संशोधित करें।
    documentProperties[propertyName] = "New Value " + (i + 1);
}

// प्रस्तुति को फ़ाइल में सहेजें।
presentation.Save("CustomProperties_output.pptx", SaveFormat.Pptx);
```

## **लाइव उदाहरण**

Aspose.Slides API का उपयोग करके दस्तावेज़ प्रॉपर्टीज़ के साथ काम करने को देखने के लिए ऑनलाइन ऐप **[View & Edit PowerPoint Metadata](https://products.aspose.app/slides/hi/metadata)** आज़माएँ:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/hi/metadata)

## **FAQ**

**मैं प्रस्तुति से किसी built‑in प्रॉपर्टी को कैसे हटाऊँ?**

Built‑in प्रॉपर्टीज़ प्रस्तुति का अभिन्न हिस्सा होती हैं और उन्हें पूरी तरह से हटाया नहीं जा सकता। हालांकि, आप उनके मान बदल सकते हैं या यदि विशिष्ट प्रॉपर्टी अनुमति देती है तो उन्हें खाली सेट कर सकते हैं।

**यदि मैं ऐसी कस्टम प्रॉपर्टी जोड़ूँ जो पहले से मौजूद है तो क्या होगा?**

यदि आप किसी मौजूदा कस्टम प्रॉपर्टी को जोड़ते हैं, तो उसका मौजूदा मान नए मान से ओवरराइट हो जाएगा। प्रॉपर्टी को हटाने या पहले जाँचने की आवश्यकता नहीं है, क्योंकि Aspose.Slides स्वतः ही प्रॉपर्टी के मान को अपडेट कर देता है।

**क्या मैं प्रस्तुति को पूर्ण रूप से लोड किए बिना प्रस्तुति प्रॉपर्टीज़ तक पहुँच सकता हूँ?**

हाँ। [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/hi/net/aspose.slides/presentationfactory/getpresentationinfo/) का उपयोग करें और फिर [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/hi/net/aspose.slides/ipresentationinfo/readdocumentproperties/) के माध्यम से बिना [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) इंस्टेंस बनाए संग्रहित दस्तावेज़ मेटाडेटा पढ़ें। पूर्ण रिपोर्टिंग उदाहरण और फ़ॉर्मेट‑विशिष्ट सीमाओं के लिए देखें **[Build a Lightweight Presentation Inventory](/slides/hi/net/examine-presentation/)**।

**क्या मैं एन्क्रिप्टेड प्रस्तुति की सार्वजनिक प्रॉपर्टीज़ को उसके खुलने वाले पासवर्ड के बिना पढ़ सकता हूँ?**

हाँ। प्रस्तुति को `EncryptDocumentProperties` को `false` पर सेट करके एन्क्रिप्ट किया होना चाहिए, और इसे `OnlyLoadDocumentProperties` को `true` पर सेट करके लोड किया जाना चाहिए।

**क्या मैं दस्तावेज़‑प्रॉपर्टीज़‑केवल मोड में एन्क्रिप्टेड PPTX फ़ाइल को अपडेट कर सकता हूँ?**

नहीं। सार्वजनिक और एन्क्रिप्टेड प्रॉपर्टी डेटा को सुसंगत रहना चाहिए, इसलिए एन्क्रिप्टेड PPTX फ़ाइल को अपडेट करने के लिए सही खुलने वाले पासवर्ड के साथ पूर्ण प्रस्तुति लोड करना आवश्यक है।