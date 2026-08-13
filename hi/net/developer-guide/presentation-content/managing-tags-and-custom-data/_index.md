---
title: .NET में प्रस्तुतियों में टैग और कस्टम डेटा का प्रबंधन
linktitle: टैग और कस्टम डेटा
type: docs
weight: 300
url: /hi/net/managing-tags-and-custom-data/
keywords:
- दस्तावेज़ गुण
- टैग
- कस्टम डेटा
- कस्टम XML
- कस्टम XML भाग
- XML मेटाडाटा
- ItemId
- टैग जोड़ें
- युग्म मान
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ PowerPoint प्रस्तुतियों में टैग और कस्टम XML डेटा का प्रबंधन कैसे करें, जिसमें कस्टम XML भाग जोड़ना, पढ़ना, अपडेट करना, ऑडिट करना और हटाना शामिल है।"
---
## **अवलोकन**

यह लेख समझाता है कि Aspose.Slides PowerPoint प्रस्तुतियों में टैग और कस्टम डेटा के साथ कैसे काम करता है। प्रस्तुति‑विशिष्ट डेटा को टैग या कस्टम XML भागों के रूप में संग्रहीत किया जा सकता है। टैग साधारण कुंजी‑मान स्ट्रिंग जोड़े होते हैं, जबकि कस्टम XML भाग संरचित मेटाडाटा और एप्लिकेशन‑विशिष्ट XML पेलोड संग्रहीत कर सकते हैं।

Aspose.Slides प्रस्तुति, स्लाइड और आकार स्तर पर कस्टम XML भागों को जोड़ने, पढ़ने, अपडेट करने, ऑडिट करने और हटाने के लिए API प्रदान करता है। कस्टम XML भाग उन एकीकरणों के लिए उपयोगी होते हैं जो दस्तावेज‑प्रबंधन पहचानकर्ता, कार्य‑प्रवाह स्थिति, अनुपालन मेटाडाटा, टेम्पलेट‑बाइंडिंग डेटा या अन्य संरचित एप्लिकेशन डेटा को प्रस्तुति के भीतर संग्रहीत करते हैं।

## **प्रेज़ेंटेशन फ़ाइलों में डेटा संग्रहण**

PPTX फ़ाइलें — `.pptx` विस्तार वाली फ़ाइलें — PresentationML स्वरूप में संग्रहीत होती हैं, जो Office Open XML विनिर्देशन का हिस्सा है। Office Open XML पैकेज संरचना और संबंधों को परिभाषित करता है जो प्रस्तुति सामग्री और संबंधित डेटा को संग्रहीत करने के लिए उपयोग होते हैं।

एक प्रस्तुति कई भागों से मिलकर बनती है जो संबंधों द्वारा जुड़े होते हैं। उदाहरण के लिए, एक स्लाइड भाग एकल स्लाइड की सामग्री रखता है और ISO/IEC 29500 द्वारा परिभाषित अन्य भागों के साथ स्पष्ट संबंध रख सकता है।

कस्टम डेटा को टैग ([ITagCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/itagcollection)) या कस्टम XML भागों ([ICustomXmlPartCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/icustomxmlpartcollection)) के रूप में संग्रहीत किया जा सकता है। दोनों ही [`ICustomData`](https://reference.aspose.com/slides/hi/net/aspose.slides/icustomdata/) इंटरफ़ेस के माध्यम से उपलब्ध हैं।

{{% alert color="info" %}}
टैग साधारण स्ट्रिंग कुंजी‑मान जोड़े संग्रहीत करते हैं। कस्टम XML भाग संरचित XML डेटा संग्रहीत करते हैं और उन्हें प्रस्तुति, स्लाइड या आकार के साथ संबद्ध किया जा सकता है।
{{% /alert %}}

## **कस्टम XML भागों के साथ काम करना**

[`ICustomData.CustomXmlParts`](https://reference.aspose.com/slides/hi/net/aspose.slides/icustomdata/customxmlparts/) प्रॉपर्टी किसी विशिष्ट प्रस्तुति ऑब्जेक्ट से जुड़े कस्टम XML भागों का संग्रह लौटाती है। उदाहरण के लिए:

- `presentation.CustomData.CustomXmlParts` प्रस्तुति स्वयं से जुड़े कस्टम XML भागों को समेटे होते हैं।
- `slide.CustomData.CustomXmlParts` किसी विशेष स्लाइड से जुड़े कस्टम XML भागों को समेटे होते हैं।
- `shape.CustomData.CustomXmlParts` किसी विशेष आकार से जुड़े कस्टम XML भागों को समेटे होते हैं।

जब आपको सभी कस्टम XML भागों की जाँच करनी हो, चाहे वे कहीं भी जुड़े हों, तो [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/allcustomxmlparts/) का उपयोग करें।

### **प्रेज़ेंटेशन में एक कस्टम XML भाग जोड़ना**

[`ICustomXmlPartCollection.Add`](https://reference.aspose.com/slides/hi/net/aspose.slides/icustomxmlpartcollection/add/) का उपयोग करके XML डेटा को कस्टम XML भाग संग्रह में जोड़ें। XML मान्य और खाली नहीं होना चाहिए।

निम्न उदाहरण प्रस्तुति‑स्तर के कस्टम डेटा संग्रह में संरचित मेटाडाटा जोड़ता है:

```csharp
using System;
using Aspose.Slides;

var customXmlContent =
    "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
    "<metadata xmlns=\"urn:example:metadata\">" +
        "<documentId>DOC-1001</documentId>" +
        "<workflowState>Draft</workflowState>" +
    "</metadata>";

using var presentation = new Presentation();
var customXmlPart = presentation.CustomData.CustomXmlParts.Add(customXmlContent);

// Add स्वचालित रूप से एक पहचानकर्ता सौंपता है। केवल आवश्यक होने पर एक विशिष्ट GUID निर्धारित करें।
customXmlPart.ItemId = Guid.NewGuid();

presentation.Save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
```

`Add` मेथड XML को बाइट एरे या स्ट्रीम के रूप में भी स्वीकार कर सकता है, जो तब उपयोगी होता है जब XML सामग्री पहले से बाइनरी रूप में उपलब्ध हो।

### **स्लाइड या आकार में एक कस्टम XML भाग जोड़ना**

कस्टम XML डेटा को पूरी प्रस्तुति के बजाय किसी विशेष स्लाइड या आकार से जोड़ा जा सकता है। यह तब उपयोगी होता है जब मेटाडाटा केवल एक वस्तु, जैसे टेम्पलेट कुंजी, बाहरी रिकॉर्ड पहचानकर्ता या बाइंडिंग जानकारी का वर्णन करता है।

निम्न उदाहरण एक कस्टम XML भाग को स्लाइड में और दूसरा आकार में जोड़ता है:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.CustomData.CustomXmlParts.Add(
    "<slideMetadata xmlns=\"urn:example:slides\">" +
        "<templateKey>TitleSlide</templateKey>" +
    "</slideMetadata>");

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 250, 80);

shape.TextFrame.Text = "Customer data";
shape.CustomData.CustomXmlParts.Add(
    "<shapeMetadata xmlns=\"urn:example:shapes\">" +
        "<recordId>CRM-4281</recordId>" +
    "</shapeMetadata>");

presentation.Save("object_custom_xml.pptx", SaveFormat.Pptx);
```

जिस स्तर पर भाग जोड़ा जाता है, वह निर्धारित करता है कि किस ऑब्जेक्ट की `CustomData.CustomXmlParts` संग्रह में उस भाग का संबंध होगा। प्रस्तुति‑स्तर का डेटा दस्तावेज‑व्यापी मेटाडाटा के लिए, स्लाइड‑स्तर का डेटा विशेष स्लाइड की जानकारी के लिए, और आकार‑स्तर का डेटा व्यक्तिगत आकार से जुड़े मेटाडाटा के लिए उपयुक्त है।

### **सभी कस्टम XML भागों की सूची बनाना और ऑडिट करना**

[`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/allcustomxmlparts/) का उपयोग करके प्रस्तुति से सभी कस्टम XML भाग प्राप्त करें। प्रत्येक [`ICustomXmlPart`](https://reference.aspose.com/slides/hi/net/aspose.slides/icustomxmlpart/) अपने पहचानकर्ता, XML सामग्री और जुड़े नेमस्पेस स्कीमा को दर्शाता है।

निम्न उदाहरण सभी कस्टम XML भागों और उनके नेमस्पेस स्कीमा की सूची देता है:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var customXmlPart in presentation.AllCustomXmlParts)
{
    Console.WriteLine("ItemId: " + customXmlPart.ItemId);
    Console.WriteLine("XML:");
    Console.WriteLine(customXmlPart.XmlAsString);

    foreach (var namespaceSchema in customXmlPart.NamespaceSchemas)
    {
        Console.WriteLine("Namespace schema: " + namespaceSchema);
    }

    Console.WriteLine();
}
```

[`ICustomXmlPart.NamespaceSchemas`](https://reference.aspose.com/slides/hi/net/aspose.slides/icustomxmlpart/namespaceschemas/) कस्टम XML भाग से जुड़े XML स्कीमा लौटाता है। यह जानकारी उन प्रस्तुतियों के ऑडिट के समय उपयोगी हो सकती है जिनमें बाहरी सिस्टम द्वारा निर्मित XML शामिल है।

### **XML सामग्री और ItemId को पढ़ना और अपडेट करना**

[`ICustomXmlPart.XmlAsString`](https://reference.aspose.com/slides/hi/net/aspose.slides/icustomxmlpart/xmlasstring/) का उपयोग करके XML को UTF‑8 स्ट्रिंग के रूप में पढ़ें/अपडेट करें, या [`ICustomXmlPart.XmlData`](https://reference.aspose.com/slides/hi/net/aspose.slides/icustomxmlpart/xmldata/) का उपयोग करके कच्चे XML बाइट्स के रूप में काम करें। दोनों प्रॉपर्टी को पढ़ा और अपडेट किया जा सकता है।

[`ICustomXmlPart.ItemId`](https://reference.aspose.com/slides/hi/net/aspose.slides/icustomxmlpart/itemid/) प्रॉपर्टी वह GUID रखती है जो Office Open XML दस्तावेज़ में कस्टम XML भाग की पहचान करता है। इसे भी तब बदला जा सकता है जब एकीकरण को नया पहचानकर्ता चाहिए हो।

निम्न उदाहरण XML सामग्री और पहचानकर्ता को अपडेट करता है:

```csharp
using System;
using System.Text;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var customXmlPart = presentation.AllCustomXmlParts[0];

// वर्तमान XML को टेक्स्ट के रूप में पढ़ें।
var currentXmlContent = customXmlPart.XmlAsString;
Console.WriteLine(currentXmlContent);

// XML को UTF-8 स्ट्रिंग के रूप में अपडेट करें।
customXmlPart.XmlAsString =
    "<metadata xmlns=\"urn:example:metadata\">" +
        "<documentId>DOC-1001</documentId>" +
        "<workflowState>Approved</workflowState>" +
    "</metadata>";

// XmlData वही XML सामग्री कच्चे बाइट्स के रूप में प्रदान करता है।
var customXmlData = customXmlPart.XmlData;
Console.WriteLine(Encoding.UTF8.GetString(customXmlData));

// एकीकरण द्वारा आवश्यक होने पर पहचानकर्ता को बदलें।
customXmlPart.ItemId = Guid.NewGuid();

presentation.Save("updated_custom_xml.pptx", SaveFormat.Pptx);
```

`XmlAsString` या `XmlData` सेट करते समय वैध, खाली न हो ऐसा XML प्रदान करें। उस प्रतिनिधित्व का उपयोग करें जो एप्लिकेशन की प्राथमिकता के अनुरूप हो — स्ट्रिंग या बाइट डेटा।

### **कस्टम XML भाग को हटाना**

Aspose.Slides कस्टम XML डेटा हटाने के लिए कई तरीके प्रदान करता है:

- [`ICustomXmlPart.Remove`](https://reference.aspose.com/slides/hi/net/aspose.slides/icustomxmlpart/remove/) कस्टम XML भाग को प्रस्तुति से हटाता है।
- [`ICustomXmlPartCollection.Remove`](https://reference.aspose.com/slides/hi/net/aspose.slides/icustomxmlpartcollection/remove/) कस्टम XML भाग संग्रह से एक विशिष्ट भाग हटाता है।
- [`ICustomXmlPartCollection.RemoveAt`](https://reference.aspose.com/slides/hi/net/aspose.slides/icustomxmlpartcollection/removeat/) निर्दिष्ट संग्रह सूचकांक पर स्थित भाग को हटाता है।
- [`ICustomXmlPartCollection.Clear`](https://reference.aspose.com/slides/hi/net/aspose.slides/icustomxmlpartcollection/clear/) किसी विशिष्ट संग्रह से सभी भागों को हटाता है।

निम्न उदाहरण संदर्भ द्वारा एक प्रस्तुति‑स्तर का कस्टम XML भाग हटाता है:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var customXmlParts = presentation.CustomData.CustomXmlParts;

if (customXmlParts.Count > 0)
{
    var customXmlPart = customXmlParts[0];
    customXmlParts.Remove(customXmlPart);
}

presentation.Save("custom_xml_removed.pptx", SaveFormat.Pptx);
```

यदि आपके पास पहले से `ICustomXmlPart` है और आप उसे प्रस्तुति से हटाना चाहते हैं न कि किसी विशेष संग्रह से, तो `customXmlPart.Remove()` को कॉल करें।

आप सूचकांक द्वारा भी कोई आइटम हटाए सकते हैं:

```csharp
presentation.CustomData.CustomXmlParts.RemoveAt(0);
```

### **किसी संग्रह से सभी कस्टम XML भाग साफ़ करना**

जब किसी विशेष प्रस्तुति ऑब्जेक्ट से जुड़े सभी कस्टम XML भाग हटाने हों, तो `Clear` का उपयोग करें।

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
presentation.Slides[0].CustomData.CustomXmlParts.Clear();

presentation.Save("slide_custom_xml_cleared.pptx", SaveFormat.Pptx);
```

`Clear` केवल चयनित संग्रह को प्रभावित करता है। उदाहरण के लिए, स्लाइड की संग्रह को साफ़ करने से प्रस्तुति‑स्तर या आकार‑स्तर की संग्रह प्रभावित नहीं होती।

प्रस्तुति में सभी कस्टम XML भाग हटाने के लिए `AllCustomXmlParts` पर इटररेट करें और प्रत्येक भाग को हटाएँ:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var customXmlPart in presentation.AllCustomXmlParts)
{
    customXmlPart.Remove();
}

presentation.Save("all_custom_xml_removed.pptx", SaveFormat.Pptx);
```

### **लिंक्ड या शेयरड कस्टम XML भागों को संभालना**

Office Open XML प्रस्तुति में वही कस्टम XML भाग एक से अधिक प्रस्तुति ऑब्जेक्ट द्वारा संदर्भित हो सकता है। उदाहरण के लिए, एक मौजूदा फ़ाइल में कई स्लाइड या आकार एक ही कस्टम XML भाग की ओर संबंध रख सकते हैं।

एक शेयरड भाग को कई संदर्भों वाला एक डेटा ऑब्जेक्ट माना जाना चाहिए:

- उसके `XmlAsString`, `XmlData` या `ItemId` को अपडेट करने से मूल कस्टम XML भाग बदलता है, इसलिए परिवर्तन सभी संदर्भों में लागू होता है।
- `ItemId` का उपयोग करके आप ऑडिट के समय समान कस्टम XML भाग की पहचान कर सकते हैं।
- किसी विशेष `CustomXmlParts` संग्रह से भाग हटाने से वह केवल उसी संग्रह से हटता है। यदि भाग स्वयं प्रस्तुति से हटाना है तो `ICustomXmlPart.Remove()` उपयोग करें।
- शेयरड भाग को हटाने या बदलने से पहले ऑब्जेक्ट‑स्तर के संग्रह की जाँच करें कि क्या अन्य स्लाइड या आकार अभी भी उसका संदर्भ रखते हैं।

`Add` ओवरलोड नई XML सामग्री से नया कस्टम XML भाग बनाते हैं; वे मौजूदा `ICustomXmlPart` को स्वीकार नहीं करते। इसलिए शेयरड संबंध आमतौर पर उन प्रस्तुतियों को लोड करने पर मिलते हैं जिनमें पहले से ये संबंध मौजूद होते हैं।

निम्न उदाहरण `ItemId` द्वारा प्रस्तुति‑, स्लाइड‑ और आकार‑स्तर के संग्रह का ऑडिट करता है और उन भागों को रिपोर्ट करता है जो एक से अधिक स्थान से संदर्भित हैं:

```csharp
using System;
using System.Collections.Generic;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var referencesByItemId = new Dictionary<Guid, List<string>>();

var registerCustomXmlParts = (string ownerName, ICustomXmlPartCollection customXmlParts) =>
    {
        foreach (var customXmlPart in customXmlParts)
        {
            if (!referencesByItemId.ContainsKey(customXmlPart.ItemId))
            {
                referencesByItemId[customXmlPart.ItemId] = new List<string>();
            }

            referencesByItemId[customXmlPart.ItemId].Add(ownerName);
        }
    };

registerCustomXmlParts("Presentation", presentation.CustomData.CustomXmlParts);

for (var slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
{
    var slide = presentation.Slides[slideIndex];
    registerCustomXmlParts("Slide " + (slideIndex + 1), slide.CustomData.CustomXmlParts);

    for (var shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
    {
        var shape = slide.Shapes[shapeIndex];
        registerCustomXmlParts("Slide " + (slideIndex + 1) + ", shape " + shapeIndex, shape.CustomData.CustomXmlParts);
    }
}

foreach (var referenceEntry in referencesByItemId)
{
    if (referenceEntry.Value.Count > 1)
    {
        Console.WriteLine("Shared custom XML part: " + referenceEntry.Key);

        foreach (var ownerName in referenceEntry.Value)
        {
            Console.WriteLine("  Referenced by: " + ownerName);
        }
    }
}
```

ऐसे ऑडिट को कस्टम XML डेटा को संशोधित या हटाने से पहले करना उपयोगी होता है, विशेषकर जब प्रस्तुतियाँ बाहरी सिस्टम द्वारा निर्मित हों, क्योंकि वही मेटाडाटा भाग कई संबंधों में भाग ले सकता है।

## **टैग मूल्यों को प्राप्त करना**

स्लाइड्स में, टैग `IDocumentProperties.Keywords` प्रॉपर्टी के अनुरूप होता है। नीचे दिया गया नमूना कोड दिखाता है कि Aspose.Slides for .NET के साथ [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) से टैग का मान कैसे प्राप्त किया जाए:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var keywords = presentation.DocumentProperties.Keywords;
```

## **प्रेज़ेंटेशन में टैग जोड़ना**

Aspose.Slides आपको प्रस्तुतियों में टैग जोड़ने की अनुमति देता है। एक टैग आम तौर पर दो वस्तुओं से बना होता है:

- एक कस्टम प्रॉपर्टी का नाम, उदाहरण के लिए `MyTag`;
- कस्टम प्रॉपर्टी का मान, उदाहरण के लिए `My Tag Value`।

यदि आपको किसी विशेष नियम या प्रॉपर्टी के आधार पर प्रस्तुतियों को वर्गीकृत करना हो, तो आप उसके लिए टैग जोड़ सकते हैं। उदाहरण के लिए, यदि आप उत्तर अमेरिकी देशों की प्रस्तुतियों को वर्गीकृत करना चाहते हैं, तो आप एक "NorthAmerican" टैग बना सकते हैं और संबंधित देश को उसके मान के रूप में असाइन कर सकते हैं।

निम्न नमूना कोड Aspose.Slides for .NET का उपयोग करके एक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) में टैग जोड़ता है:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var tags = presentation.CustomData.Tags;
tags["MyTag"] = "My Tag Value";
```

टैग को किसी [Slide](https://reference.aspose.com/slides/hi/net/aspose.slides/slide) के लिए भी सेट किया जा सकता है:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
slide.CustomData.Tags["tag"] = "value";
```

या किसी व्यक्तिगत [Shape](https://reference.aspose.com/slides/hi/net/aspose.slides/shape) के लिए:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
shape.TextFrame.Text = "My text";
shape.CustomData.Tags["tag"] = "value";
```

### **सीमाएँ**

`CustomData.Tags` संग्रह के माध्यम से जोड़े गए टैग केवल PowerPoint फ़ाइल में संग्रहीत होते हैं। वे प्रस्तुति को PDF के रूप में निर्यात करने पर PDF टैग संरचना में **ट्रांसफ़र नहीं होते**। इसलिए, टैग के रूप में असाइन किया गया कस्टम पहचानकर्ता टैग्ड PDF से प्राप्त नहीं किया जा सकता।

**वर्कअराउंड**: आप कस्टम पहचानकर्ता को ऑब्जेक्ट के **Alt Text** में संग्रहीत कर सकते हैं (उदाहरण के लिए, `shape.AlternativeText = "MyId"`). PDF में निर्यात करने के बाद Alt Text PDF टैग संरचना में दिखाई दे सकता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं सभी टैग को एक ही ऑपरेशन में प्रस्तुति, स्लाइड या आकार से हटा सकता हूँ?**

हाँ। [tag collection](https://reference.aspose.com/slides/hi/net/aspose.slides/tagcollection/) में एक [Clear](https://reference.aspose.com/slides/hi/net/aspose.slides/tagcollection/clear/) ऑपरेशन उपलब्ध है जो सभी कुंजी‑मान जोड़ों को एक साथ हटाता है।

**मैं संपूर्ण संग्रह को इटरेट किए बिना किसी टैग को उसके नाम से कैसे हटाऊँ?**

[TagCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/tagcollection/) पर `Remove(name)` का उपयोग करके टैग को उसकी कुंजी से हटाएँ।

**मैं विश्लेषण या फ़िल्टरिंग के लिए टैग नामों की पूरी सूची कैसे प्राप्त करूँ?**

[tag collection](https://reference.aspose.com/slides/hi/net/aspose.slides/tagcollection/) पर `GetNamesOfTags` का उपयोग करें; यह सभी टैग नामों की एक एरे लौटाता है।

**मैं सभी कस्टम XML भागों को जहाँ भी संग्रहीत हों, कैसे ढूँढूँ?**

[`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/allcustomxmlparts/) का उपयोग करके प्रस्तुति में सभी कस्टम XML भाग प्राप्त करें।

**कस्टम XML भाग को अपडेट करने के लिए मुझे `XmlAsString` या `XmlData` में से कौनसा उपयोग करना चाहिए?**

जब एप्लिकेशन UTF‑8 XML टेक्स्ट के साथ काम करता है तो `XmlAsString` उपयोग करें। जब XML पहले से बाइट एरे के रूप में उपलब्ध हो या बाइनरी‑उन्मुख प्रोसेसिंग अधिक सुविधाजनक हो तो `XmlData` उपयोग करें। दोनों प्रॉपर्टी एक ही कस्टम XML भाग की XML सामग्री को दर्शाती हैं।