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
- बिल्ट‑इन गुण
- कस्टम गुण
- उन्नत गुण
- गुणों का प्रबंधन
- गुणों को संशोधित करें
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
description: "Aspose.Slides for .NET में प्रस्तुति गुणों को मास्टर करें और अपने PowerPoint व OpenDocument फ़ाइलों में खोज, ब्रांडिंग और कार्यप्रवाह को सहज बनाएं।"
---
## **परिचय**

Aspose.Slides for .NET दो प्रकार की दस्तावेज़ गुणों का समर्थन करता है: **Built-in** और **Custom**। इन दोनों प्रकार के गुणों को आसानी से Aspose.Slides for .NET API का उपयोग करके पहुंचा और प्रबंधित किया जा सकता है।

Aspose.Slides आपको प्रस्तुति दस्तावेज़ गुणों के साथ काम करने की अनुमति देता है [IDocumentProperties](https://reference.aspose.com/slides/hi/net/aspose.slides/idocumentproperties/) इंटरफ़ेस के माध्यम से। इस इंटरफ़ेस का एक उदाहरण [Presentation.DocumentProperties](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/documentproperties/) गुण द्वारा लौटाया जाता है। निम्नलिखित उदाहरण दिखाते हैं कि इन गुणों को कैसे पढ़ा, संशोधित और प्रबंधित किया जा सकता है।

{{% alert color="info" title="Note" %}}
कृपया ध्यान दें कि **Application** और **Producer** फ़ील्ड को संशोधित नहीं किया जा सकता है, क्योंकि ये फ़ील्ड हमेशा "Aspose Ltd." और "Aspose.Slides for .NET x.x.x" प्रदर्शित करेंगे।
{{% /alert %}} 

## **प्रेजेंटेशन गुणों का प्रबंधन**

Microsoft PowerPoint प्रस्तुति फ़ाइलों में गुण जोड़ने की सुविधा प्रदान करता है। ये दस्तावेज़ गुण फ़ाइलों के साथ उपयोगी जानकारी संग्रहित करने की अनुमति देते हैं। दस्तावेज़ गुणों के दो प्रकार होते हैं:

- सिस्टम-परिभाषित (built-in) गुण
- उपयोगकर्ता-परिभाषित (custom) गुण

**Built-in** गुण दस्तावेज़ की सामान्य जानकारी रखते हैं, जैसे दस्तावेज़ शीर्षक, लेखक का नाम, दस्तावेज़ आँकड़े, आदि।

**Custom** गुण उपयोगकर्ताओं द्वारा **Name/Value** युग्म के रूप में परिभाषित होते हैं, जहाँ नाम और मान दोनों उपयोगकर्ता द्वारा निर्दिष्ट होते हैं।

Aspose.Slides for .NET का उपयोग करके, डेवलपर्स दोनों built-in और custom गुणों तक पहुंच सकते हैं और उन्हें संशोधित कर सकते हैं।

Microsoft PowerPoint उपयोगकर्ताओं को ऑफिस आइकन पर क्लिक करके, फिर **File → Info → Properties** चुनकर दस्तावेज़ गुणों का प्रबंधन करने की अनुमति देता है। **Advanced Properties** चुनने के बाद, एक संवाद बॉक्स प्रदर्शित होता है जहाँ आप प्रस्तुति फ़ाइल के सभी दस्तावेज़ गुणों का प्रबंधन कर सकते हैं।

**Properties** संवाद में कई टैब होते हैं, जैसे **General**, **Summary**, **Statistics**, **Contents**, और **Custom**। प्रत्येक टैब PowerPoint फ़ाइल से संबंधित विशिष्ट प्रकार की जानकारी को कॉन्फ़िगर करने के विकल्प प्रदान करता है। **Custom** टैब का उपयोग उपयोगकर्ता‑परिभाषित गुणों को प्रबंधित करने के लिए किया जाता है।

## **Built-in गुणों तक पहुंच**

इन गुणों को, [IDocumentProperties](https://reference.aspose.com/slides/hi/net/aspose.slides/idocumentproperties/) इंटरफ़ेस द्वारा उजागर किया गया है, जिसमें शामिल हैं: **Creator** (Author), **Description**, **Keywords**, **Created** (Creation Date), **Modified** (Modification Date), **Printed** (Last Print Date), **LastModifiedBy**, **SharedDoc** (यह दर्शाता है कि दस्तावेज़ विभिन्न निर्माताओं के बीच साझा किया गया है या नहीं), **PresentationFormat**, **Subject**, **Title**, और अधिक।

```cs
using Aspose.Slides;

// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का निर्माण करें।
using Presentation presentation = new Presentation("AccessBuiltInProperties.pptx");

// प्रस्तुति से जुड़े IDocumentProperties प्रकार के ऑब्जेक्ट का संदर्भ प्राप्त करें।
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Built-in गुणों को प्रदर्शित करें।
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

## **Built-in गुणों को संशोधित करें**

प्रेजेंटेशन फ़ाइलों के built-in गुणों को संशोधित करना उतना ही आसान है जितना कि उन्हें पहुंचना। आप बस किसी भी इच्छित गुण को एक स्ट्रिंग मान असाइन कर सकते हैं, और गुण का मान अपडेट हो जाएगा। नीचे दिए गए उदाहरण में, हम दिखाते हैं कि प्रेजेंटेशन फ़ाइल के built-in दस्तावेज़ गुणों को कैसे संशोधित किया जा सकता है।

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// एक Presentation वर्ग का उदाहरण बनाएं जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है।
using Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");

// प्रस्तुति से जुड़े IDocumentProperties प्रकार के वस्तु का संदर्भ प्राप्त करें.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Built-in गुण सेट करें.
documentProperties.Author = "Aspose.Slides for .NET";
documentProperties.Title = "Manage PowerPoint Presentation Properties";
documentProperties.Subject = "Modify Built-in Properties";
documentProperties.Comments = "Aspose description";
documentProperties.Manager = "Aspose manager";

// प्रस्तुति को एक फ़ाइल में सहेजें.
presentation.Save("DocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **कस्टम प्रेजेंटेशन गुण जोड़ें**

कस्टम प्रेजेंटेशन गुण डेवलपर्स को प्रेजेंटेशन फ़ाइल में अतिरिक्त मेटाडेटा या विशिष्ट जानकारी संग्रहित करने में सक्षम बनाते हैं। Aspose.Slides प्रोग्रामेटिकली इन कस्टम गुणों को बनाने और प्रबंधित करने को आसान बनाता है। निम्नलिखित उदाहरण दर्शाते हैं कि आपके प्रेजेंटेशन में कस्टम गुणों को कैसे जोड़ा जाए।

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Presentation वर्ग का उदाहरण बनाएं।
using Presentation presentation = new Presentation();

// प्रेजेंटेशन से जुड़े IDocumentProperties प्रकार की वस्तु का संदर्भ प्राप्त करें।
IDocumentProperties documentProperties = presentation.DocumentProperties;

// कस्टम गुण जोड़ें।
documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

// प्रेजेंटेशन को फ़ाइल में सहेजें।
presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **कस्टम गुणों तक पहुंच और संशोधित करें**

Aspose.Slides डेवलपर्स को मौजूदा कस्टम गुणों तक आसानी से पहुंचने और उनके मानों को संशोधित करने की भी अनुमति देता है। यह कार्यक्षमता सटीक मेटाडेटा बनाए रखने में मदद करती है और उपयोगकर्ता इनपुट या व्यावसायिक लॉजिक के आधार पर गतिशील अपडेट को समर्थन देती है। नीचे दिए गए उदाहरण दिखाते हैं कि प्रेजेंटेशन के भीतर कस्टम गुणों के मानों को कैसे प्राप्त और अपडेट किया जाए।

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// एक PPTX फ़ाइल का प्रतिनिधित्व करने वाले Presentation वर्ग का उदाहरण बनाएं।
using Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");

// प्रेजेंटेशन से जुड़े IDocumentProperties प्रकार की वस्तु का संदर्भ प्राप्त करें।
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Access and modify the custom properties.
for (int i = 0; i < documentProperties.CountOfCustomProperties; i++)
{
    string propertyName = documentProperties.GetCustomPropertyName(i);
    object propertyValue = documentProperties[propertyName];

    // कस्टम गुण का नाम और मान प्रदर्शित करें।
    Console.WriteLine("Custom property name : " + propertyName);
    Console.WriteLine("Custom property value : " + propertyValue);

    // कस्टम गुण का मान संशोधित करें।
    documentProperties[propertyName] = "New Value " + (i + 1);
}

// प्रेजेंटेशन को फ़ाइल में सहेजें।
presentation.Save("CustomProperties_output.pptx", SaveFormat.Pptx);
```

## **लाइव उदाहरण**

Aspose.Slides API का उपयोग करके दस्तावेज़ गुणों के साथ कैसे काम करें, यह देखने के लिए ऑनलाइन ऐप [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/hi/metadata) आज़माएँ:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/hi/metadata)

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं प्रेजेंटेशन से एक built-in गुण कैसे हटा सकता हूँ?**

Built-in गुण प्रेजेंटेशन का अभिन्न हिस्सा होते हैं और उन्हें पूरी तरह से हटाया नहीं जा सकता। हालांकि, आप उनके मान बदल सकते हैं या यदि विशेष गुण द्वारा अनुमति हो तो उन्हें खाली सेट कर सकते हैं।

**यदि मैं एक मौजूदा कस्टम गुण जोड़ूँ तो क्या होता है?**

यदि आप एक कस्टम गुण जोड़ते हैं जो पहले से मौजूद है, तो उसकी मौजूदा मान नई मान से ओवरराइट हो जाएगी। आपको पहले से गुण को हटाने या जांचने की जरूरत नहीं है, क्योंकि Aspose.Slides स्वचालित रूप से गुण के मान को अपडेट करता है।

**क्या मैं प्रेजेंटेशन को पूरी तरह लोड किए बिना प्रेजेंटेशन गुणों तक पहुंच सकता हूँ?**

हां। [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/hi/net/aspose.slides/presentationfactory/getpresentationinfo/) का उपयोग करें और फिर [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/hi/net/aspose.slides/ipresentationinfo/readdocumentproperties/) का उपयोग करके संग्रहीत दस्तावेज़ मेटाडाटा को बिना [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) इंस्टेंस बनाए पढ़ें। पूर्ण रिपोर्टिंग उदाहरण और फ़ॉर्मेट‑विशिष्ट सीमाओं के लिए देखें [Build a Lightweight Presentation Inventory](/slides/hi/net/examine-presentation/)।