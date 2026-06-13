---
title: .NET में प्रेजेंटेशन प्रॉपर्टीज़ का प्रबंधन
linktitle: प्रेजेंटेशन प्रॉपर्टीज़
type: docs
weight: 70
url: /hi/net/presentation-properties/
keywords:
- PowerPoint प्रॉपर्टीज़
- प्रेजेंटेशन प्रॉपर्टीज़
- दस्तावेज़ प्रॉपर्टीज़
- बिल्ट-इन प्रॉपर्टीज़
- कस्टम प्रॉपर्टीज़
- एडवांस्ड प्रॉपर्टीज़
- प्रॉपर्टीज़ प्रबंधित करें
- प्रॉपर्टीज़ संशोधित करें
- दस्तावेज़ मेटाडाटा
- मेटाडाटा संपादित करें
- प्रूफिंग भाषा
- डिफ़ॉल्ट भाषा
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET में प्रेजेंटेशन प्रॉपर्टीज़ को मास्टर करें और अपने PowerPoint और OpenDocument फ़ाइलों में खोज, ब्रांडिंग और वर्कफ़्लो को सरल बनाएं।"
---
## **परिचय**

Aspose.Slides for .NET दो प्रकार की दस्तावेज़ प्रॉपर्टीज़ को समर्थन देता है: **Built-in** और **Custom**। इन दोनों प्रकार की प्रॉपर्टीज़ को Aspose.Slides for .NET API का उपयोग करके आसानी से एक्सेस और प्रबंधित किया जा सकता है।

Aspose.Slides आपको [IDocumentProperties](https://reference.aspose.com/slides/hi/net/aspose.slides/idocumentproperties/) इंटरफ़ेस के माध्यम से प्रेजेंटेशन दस्तावेज़ प्रॉपर्टीज़ के साथ काम करने की अनुमति देता है। इस इंटरफ़ेस का एक उदाहरण [Presentation.DocumentProperties](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/documentproperties/) प्रॉपर्टी द्वारा लौटाया जाता है। निम्नलिखित उदाहरण दिखाते हैं कि इन प्रॉपर्टीज़ को कैसे पढ़ा, संशोधित और प्रबंधित किया जाए।

{{% alert color="primary" %}} 
कृपया ध्यान दें कि **Application** और **Producer** फ़ील्ड को संशोधित नहीं किया जा सकता है, क्योंकि ये फ़ील्ड हमेशा “Aspose Ltd.” और “Aspose.Slides for .NET x.x.x” प्रदर्शित करेंगे।
{{% /alert %}} 

## **प्रेजेंटेशन प्रॉपर्टीज़ प्रबंधित करें**

Microsoft PowerPoint प्रेजेंटेशन फ़ाइलों में प्रॉपर्टीज़ जोड़ने की सुविधा प्रदान करता है। ये दस्तावेज़ प्रॉपर्टीज़ फ़ाइलों के साथ उपयोगी जानकारी संग्रहीत करने की अनुमति देती हैं। दो प्रकार की दस्तावेज़ प्रॉपर्टीज़ होती हैं:

- सिस्टम-परिभाषित (built-in) प्रॉपर्टीज़
- उपयोगकर्ता-परिभाषित (custom) प्रॉपर्टीज़

**Built-in** प्रॉपर्टीज़ में दस्तावेज़ के बारे में सामान्य जानकारी होती है, जैसे दस्तावेज़ शीर्षक, लेखक का नाम, दस्तावेज़ आँकड़े, आदि।

**Custom** प्रॉपर्टीज़ को उपयोगकर्ता **नाम/मूल्य** जोड़े के रूप में परिभाषित करते हैं, जहाँ दोनों नाम और मूल्य उपयोगकर्ता द्वारा निर्दिष्ट होते हैं।

Aspose.Slides for .NET का उपयोग करके, डेवलपर दोनों built-in और custom प्रॉपर्टीज़ तक पहुँच और संशोधन कर सकते हैं।

Microsoft PowerPoint उपयोगकर्ताओं को Office आइकन पर क्लिक करके, फिर **File → Info → Properties** चुनने से दस्तावेज़ प्रॉपर्टीज़ प्रबंधित करने की अनुमति देता है। **Advanced Properties** चुनने के बाद, एक डायलॉग दिखाई देता है जहाँ आप प्रेजेंटेशन फ़ाइल की सभी दस्तावेज़ प्रॉपर्टीज़ को प्रबंधित कर सकते हैं।

**Properties** डायलॉग में कई टैब होते हैं, जैसे **General**, **Summary**, **Statistics**, **Contents**, और **Custom**। प्रत्येक टैब PowerPoint फ़ाइल से संबंधित विशिष्ट प्रकार की जानकारी को कॉन्फ़िगर करने के विकल्प प्रदान करता है। **Custom** टैब का उपयोग उपयोगकर्ता‑परिभाषित प्रॉपर्टीज़ को प्रबंधित करने के लिए किया जाता है।

## **Built-in प्रॉपर्टीज़ तक पहुँच**

इन प्रॉपर्टीज़ को, जो [IDocumentProperties](https://reference.aspose.com/slides/hi/net/aspose.slides/idocumentproperties/) इंटरफ़ेस द्वारा उजागर की गई हैं, में शामिल हैं: **Creator** (Author), **Description**, **Keywords**, **Created** (Creation Date), **Modified** (Modification Date), **Printed** (Last Print Date), **LastModifiedBy**, **SharedDoc** (दस्तावेज़ विभिन्न निर्माताओं के बीच साझा किया गया है या नहीं दर्शाता है), **PresentationFormat**, **Subject**, **Title**, आदि।

```cs
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास का उदाहरण बनाएं।
using Presentation presentation = new Presentation("AccessBuiltInProperties.pptx");

// Get a reference to the object of type IDocumentProperties associated with the presentation.
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

## **Built-in प्रॉपर्टीज़ संशोधित करें**

प्रेजेंटेशन फ़ाइलों की built-in प्रॉपर्टीज़ को संशोधित करना उन्हें एक्सेस करने जितना ही आसान है। आप बस किसी भी इच्छित प्रॉपर्टी को एक स्ट्रिंग मान असाइन कर सकते हैं, और प्रॉपर्टी का मान अपडेट हो जाएगा। नीचे के उदाहरण में, हम दर्शाते हैं कि कैसे प्रेजेंटेशन फ़ाइल की built-in दस्तावेज़ प्रॉपर्टीज़ को संशोधित किया जाए।

```cs
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास का उदाहरण बनाएं।
using Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");

// प्रस्तुति से जुड़ा IDocumentProperties प्रकार का ऑब्जेक्ट संदर्भ प्राप्त करें।
IDocumentProperties documentProperties = presentation.DocumentProperties;

// बिल्ट-इन प्रॉपर्टीज़ सेट करें।
documentProperties.Author = "Aspose.Slides for .NET";
documentProperties.Title = "Manage PowerPoint Presentation Properties";
documentProperties.Subject = "Modify Built-in Properties";
documentProperties.Comments = "Aspose description";
documentProperties.Manager = "Aspose manager";

// प्रस्तुति को फ़ाइल में सहेजें।
presentation.Save("DocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **कस्टम प्रेजेंटेशन प्रॉपर्टीज़ जोड़ें**

कस्टम प्रेजेंटेशन प्रॉपर्टीज़ डेवलपर्स को प्रेजेंटेशन फ़ाइल में अतिरिक्त मेटाडाटा या विशिष्ट जानकारी संग्रहीत करने की क्षमता देती हैं। Aspose.Slides प्रोग्रामेटिकली इन कस्टम प्रॉपर्टीज़ को बनाने और प्रबंधित करने में सहायता करता है। निम्नलिखित उदाहरण दिखाते हैं कि कैसे अपनी प्रेजेंटेशन्स में कस्टम प्रॉपर्टीज़ जोड़ी जाएँ।

```cs
// Presentation क्लास का उदाहरण बनाएं।
using Presentation presentation = new Presentation();

// प्रेजेंटेशन से जुड़े IDocumentProperties प्रकार के ऑब्जेक्ट का संदर्भ प्राप्त करें।
IDocumentProperties documentProperties = presentation.DocumentProperties;

// कस्टम प्रॉपर्टीज़ जोड़ें।
documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

// प्रेजेंटेशन को फ़ाइल में सहेजें।
presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **कस्टम प्रॉपर्टीज़ तक पहुँच और संशोधित करें**

Aspose.Slides डेवलपर्स को मौजूदा कस्टम प्रॉपर्टीज़ तक पहुँचने और उनके मानों को आसानी से संशोधित करने की भी अनुमति देता है। यह कार्यक्षमता सटीक मेटाडाटा बनाए रखने और उपयोगकर्ता इनपुट या व्यावसायिक लॉजिक के आधार पर गतिशील अपडेट को समर्थन देती है। नीचे के उदाहरण दर्शाते हैं कि कैसे प्रेजेंटेशन के भीतर कस्टम प्रॉपर्टी मानों को प्राप्त और अपडेट किया जाए।

```cs
// PPTX फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास का उदाहरण बनाएं।
using Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");

// प्रेजेंटेशन से जुड़े IDocumentProperties प्रकार के ऑब्जेक्ट का संदर्भ प्राप्त करें।
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Access and modify the custom properties.
for (int i = 0; i < documentProperties.CountOfCustomProperties; i++)
{
    string propertyName = documentProperties.GetCustomPropertyName(i);
    object propertyValue = documentProperties[propertyName];

    // कस्टम प्रॉपर्टी का नाम और मूल्य प्रदर्शित करें।
    Console.WriteLine("Custom property name : " + propertyName);
    Console.WriteLine("Custom property value : " + propertyValue);

    // कस्टम प्रॉपर्टी का मूल्य संशोधित करें।
    documentProperties[propertyName] = "New Value " + (i + 1);
}

// प्रेजेंटेशन को फ़ाइल में सहेजें।
presentation.Save("CustomProperties_output.pptx", SaveFormat.Pptx);
```

## **लाइव उदाहरण**

Aspose.Slides API का उपयोग करके दस्तावेज़ प्रॉपर्टीज़ के साथ काम करने का तरीका देखने के लिए ऑनलाइन ऐप **[View & Edit PowerPoint Metadata](https://products.aspose.app/slides/hi/metadata)** आज़माएँ:

[![PowerPoint मेटाडाटा देखें और संपादित करें](slides-metadata.png)](https://products.aspose.app/slides/hi/metadata)

## ***अक्सर पूछे जाने वाले प्रश्न**

**मैं प्रेजेंटेशन से एक built-in प्रॉपर्टी कैसे हटा सकता हूँ?**

Built-in प्रॉपर्टीज़ प्रेजेंटेशन का अभिन्न हिस्सा हैं और उन्हें पूरी तरह से हटाया नहीं जा सकता। हालांकि, आप उनके मान को बदल सकते हैं या यदि विशिष्ट प्रॉपर्टी अनुमति देती है तो उसे खाली सेट कर सकते हैं।

**यदि मैं एक कस्टम प्रॉपर्टी जोड़ता हूँ जो पहले से मौजूद है तो क्या होता है?**

यदि आप एक कस्टम प्रॉपर्टी जोड़ते हैं जो पहले से मौजूद है, तो उसका मौजूदा मान नए मान से अधिलेखित हो जाएगा। आपको प्रॉपर्टी को हटाने या पहले से जाँचने की आवश्यकता नहीं है, क्योंकि Aspose.Slides स्वचालित रूप से प्रॉपर्टी के मान को अपडेट कर देता है।

**क्या मैं प्रेजेंटेशन को पूरी तरह लोड किए बिना प्रेजेंटेशन प्रॉपर्टीज़ तक पहुँच सकता हूँ?**

हाँ, आप प्रेजेंटेशन को पूरी तरह लोड किए बिना [PresentationFactory](https://reference.aspose.com/slides/hi/net/aspose.slides/presentationfactory/) क्लास की `GetPresentationInfo` मेथड का उपयोग करके प्रेजेंटेशन प्रॉपर्टीज़ तक पहुँच सकते हैं। फिर, [IPresentationInfo](https://reference.aspose.com/slides/hi/net/aspose.slides/ipresentationinfo/) इंटरफ़ेस द्वारा प्रदान की गई `ReadDocumentProperties` मेथड का उपयोग करके प्रॉपर्टीज़ को कुशलतापूर्वक पढ़ें, जिससे मेमोरी बचती है और प्रदर्शन में सुधार होता है।