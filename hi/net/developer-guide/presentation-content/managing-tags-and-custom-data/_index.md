---
title: .NET में प्रस्तुतियों में टैग और कस्टम डेटा को प्रबंधित करें
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
- XML मेटाडेटा
- ItemId
- टैग जोड़ें
- युग्म मान
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ PowerPoint प्रस्तुतियों में टैग और कस्टम XML डेटा को प्रबंधित करना सीखें, जिसमें कस्टम XML भाग जोड़ना, पढ़ना, अपडेट करना, ऑडिट करना और हटाना शामिल है।"
---
## **अवलोकन**

यह लेख समझाता है कि Aspose.Slides PowerPoint प्रस्तुतियों में टैग और कस्टम डेटा के साथ कैसे कार्य करता है। प्रस्तुति-विशिष्ट डेटा को टैग या कस्टम XML भागों के रूप में संग्रहीत किया जा सकता है। टैग सरल कुंजी‑मूल्य स्ट्रिंग जोड़े होते हैं, जबकि कस्टम XML भाग संरचित मेटाडेटा और एप्लिकेशन‑विशिष्ट XML पेलोड संग्रहीत कर सकते हैं।

Aspose.Slides APIs प्रदान करता है ताकि कस्टम XML भागों को जोड़ना, पढ़ना, अपडेट करना, ऑडिट करना और हटाना संभव हो, चाहे वह प्रस्तुति स्तर, स्लाइड स्तर या आकार (shape) स्तर पर हो। कस्टम XML भाग उन इंटीग्रेशन के लिए उपयोगी होते हैं जो दस्तावेज‑प्रबंधन पहचानकर्ता, वर्कफ़्लो अवस्था, अनुपालन मेटाडेटा, टेम्पलेट‑बंधन डेटा, या अन्य संरचित एप्लिकेशन डेटा को प्रस्तुति के भीतर संग्रहीत करना चाहते हैं।

## **प्रेजेंटेशन फ़ाइलों में डेटा संग्रहीत करना**

`.pptx` एक्सटेंशन वाली फ़ाइलें PresentationML प्रारूप में संग्रहीत होती हैं, जो Office Open XML विनिर्देशन का हिस्सा है। Office Open XML पैकेज संरचना और रिश्ते (relationships) को परिभाषित करता है जिसका उपयोग प्रस्तुति सामग्री और संबंधित डेटा को संग्रहीत करने के लिए किया जाता है।

एक प्रस्तुति में कई भाग होते हैं जो रिश्तों द्वारा जुड़े होते हैं। उदाहरण के लिए, एक स्लाइड भाग में एकल स्लाइड की सामग्री होती है और इसके पास ISO/IEC 29500 द्वारा परिभाषित अन्य भागों के साथ स्पष्ट रिश्ते हो सकते हैं।

कस्टम डेटा को टैग ([ITagCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/itagcollection)) या कस्टम XML भाग ([ICustomXmlPartCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/icustomxmlpartcollection)) के रूप में संग्रहीत किया जा सकता है। दोनों ही [`ICustomData`](https://reference.aspose.com/slides/hi/net/aspose.slides/icustomdata/) इंटरफ़ेस के माध्यम से उपलब्ध हैं।

{{% alert color="primary" %}}
टैग सरल स्ट्रिंग कुंजी‑मूल्य जोड़े संग्रहीत करते हैं। कस्टम XML भाग संरचित XML डेटा संग्रहीत करते हैं और उन्हें प्रस्तुति, स्लाइड या आकार के साथ जोड़ा जा सकता है।
{{% /alert %}}

## **कस्टम XML भागों के साथ कार्य करना**

[`ICustomData.CustomXmlParts`](https://reference.aspose.com/slides/hi/net/aspose.slides/icustomdata/customxmlparts/) प्रॉपर्टी उस कस्टम XML भागों के संग्रह को लौटाती है जो किसी विशिष्ट प्रस्तुति वस्तु से जुड़ा है। उदाहरण के लिए:

- `presentation.CustomData.CustomXmlParts` में उस प्रस्तुति से जुडे़ कस्टम XML भाग होते हैं।
- `slide.CustomData.CustomXmlParts` में किसी विशिष्ट स्लाइड से जुडे़ कस्टम XML भाग होते हैं।
- `shape.CustomData.CustomXmlParts` में किसी विशिष्ट आकार से जुडे़ कस्टम XML भाग होते हैं।

जब आप प्रस्तुति में सभी कस्टम XML भागों को देखना चाहते हैं, चाहे वे जहाँ भी जुड़े हों, तो [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/allcustomxmlparts/) का उपयोग करें।

### **प्रेजेंटेशन में कस्टम XML भाग जोड़ना**

[`ICustomXmlPartCollection.Add`](https://reference.aspose.com/slides/hi/net/aspose.slides/icustomxmlpartcollection/add/) का उपयोग करके XML डेटा को कस्टम XML भाग संग्रह में जोड़ें। XML मान्य और खाली नहीं होना चाहिए।

निम्न उदाहरण प्रस्तुति‑स्तर के कस्टम डेटा संग्रह में संरचित मेटाडेटा जोड़ता है:

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

// Add स्वचालित रूप से एक पहचानकर्ता निर्धारित करता है। केवल आवश्यकता होने पर विशिष्ट GUID सेट करें.
customXmlPart.ItemId = Guid.NewGuid();

presentation.Save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
```

`Add` मेथड XML को बाइट एरे या स्ट्रीम के रूप में भी स्वीकार कर सकता है, जो तब उपयोगी होता है जब XML सामग्री पहले से बाइनरी रूप में उपलब्ध हो।

### **स्लाइड या आकार में कस्टम XML भाग जोड़ना**

कस्टम XML डेटा को संपूर्ण प्रस्तुति के बजाय किसी विशिष्ट स्लाइड या आकार के साथ जोड़ा जा सकता है। यह तब उपयोगी होता है जब मेटाडेटा केवल एक वस्तु का वर्णन करता हो, जैसे टेम्पलेट कुंजी, बाहरी रिकॉर्ड पहचानकर्ता, या बाइंडिंग जानकारी।

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

जिस स्तर पर भाग जोड़ा जाता है, वह निर्धारित करता है कि किस वस्तु की `CustomData.CustomXmlParts` संग्रह में उस भाग का रिश्ता मौजूद होगा। प्रस्तुति‑स्तर का डेटा दस्तावेज‑व्यापी मेटाडेटा के लिए उपयुक्त है, स्लाइड‑स्तर का डेटा विशेष स्लाइड की जानकारी के लिए, और आकार‑स्तर का डेटा व्यक्तिगत आकार से जुड़े मेटाडेटा के लिए।

### **सभी कस्टम XML भागों की सूची बनाना और ऑडिट करना**

[`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/allcustomxmlparts/) का उपयोग करके प्रस्तुति से सभी कस्टम XML भाग प्राप्त करें। प्रत्येक [`ICustomXmlPart`](https://reference.aspose.com/slides/hi/net/aspose.slides/icustomxmlpart/) अपना पहचानकर्ता, XML सामग्री और संबंधित नेमस्पेस स्कीमा प्रदान करता है।

निम्न उदाहरण सभी कस्टम XML भागों और उनके नेमस्पेस स्कीमा को सूचीबद्ध करता है:

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

[`ICustomXmlPart.NamespaceSchemas`](https://reference.aspose.com/slides/hi/net/aspose.slides/icustomxmlpart/namespaceschemas/) कस्टम XML भाग से जुड़े XML स्कीमा लौटाता है। यह जानकारी उन प्रस्तुतियों को ऑडिट करते समय उपयोगी हो सकती है जिनमें बाहरी सिस्टम द्वारा निर्मित XML शामिल होता है।

### **XML सामग्री और ItemId पढ़ना और अपडेट करना**

[`ICustomXmlPart.XmlAsString`](https://reference.aspose.com/slides/hi/net/aspose.slides/icustomxmlpart/xmlasstring/) का उपयोग करके XML को UTF‑8 स्ट्रिंग के रूप में काम करें, या [`ICustomXmlPart.XmlData`](https://reference.aspose.com/slides/hi/net/aspose.slides/icustomxmlpart/xmldata/) का उपयोग करके कच्चे XML बाइट्स के साथ काम करें। दोनों प्रॉपर्टी पढ़ी और अपडेट की जा सकती हैं।

[`ICustomXmlPart.ItemId`](https://reference.aspose.com/slides/hi/net/aspose.slides/icustomxmlpart/itemid/) प्रॉपर्टी उस GUID को रखती है जो Office Open XML दस्तावेज़ में कस्टम XML भाग को पहचानता है। इसे तब बदला भी जा सकता है जब इंटीग्रेशन को नया पहचानकर्ता चाहिए हो।

निम्न उदाहरण XML सामग्री और पहचानकर्ता को अपडेट करता है:

```csharp
using System;
using System.Text;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var customXmlPart = presentation.AllCustomXmlParts[0];

// Read the current XML as text.
var currentXmlContent = customXmlPart.XmlAsString;
Console.WriteLine(currentXmlContent);

// Update the XML as a UTF-8 string.
customXmlPart.XmlAsString =
    "<metadata xmlns=\"urn:example:metadata\">" +
        "<documentId>DOC-1001</documentId>" +
        "<workflowState>Approved</workflowState>" +
    "</metadata>";

// XmlData provides the same XML content as raw bytes.
var customXmlData = customXmlPart.XmlData;
Console.WriteLine(Encoding.UTF8.GetString(customXmlData));

// Replace the identifier when required by the integration.
customXmlPart.ItemId = Guid.NewGuid();

presentation.Save("updated_custom_xml.pptx", SaveFormat.Pptx);
```

`XmlAsString` या `XmlData` सेट करते समय वैध, गैर‑खाली XML प्रदान करें। उपयोग के आधार पर स्ट्रिंग या बाइट प्रतिनिधित्व में से एक चुनें।

### **कस्टम XML भाग हटाना**

Aspose.Slides कस्टम XML डेटा को हटाने के कई तरीकों को समर्थन देता है:

- [`ICustomXmlPart.Remove`](https://reference.aspose.com/slides/hi/net/aspose.slides/icustomxmlpart/remove/) कस्टम XML भाग को प्रस्तुति से हटाता है।
- [`ICustomXmlPartCollection.Remove`](https://reference.aspose.com/slides/hi/net/aspose.slides/icustomxmlpartcollection/remove/) किसी विशिष्ट भाग को कस्टम XML भाग संग्रह से हटाता है।
- [`ICustomXmlPartCollection.RemoveAt`](https://reference.aspose.com/slides/hi/net/aspose.slides/icustomxmlpartcollection/removeat/) निर्दिष्ट संग्रह सूचकांक पर भाग को हटाता है।
- [`ICustomXmlPartCollection.Clear`](https://reference.aspose.com/slides/hi/net/aspose.slides/icustomxmlpartcollection/clear/) किसी विशिष्ट संग्रह से सभी भागों को हटाता है।

निम्न उदाहरण संदर्भ द्वारा एक प्रस्तुति‑स्तर कस्टम XML भाग हटाता है:

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

यदि आपके पास पहले से `ICustomXmlPart` है और आप इसे पूरे प्रस्तुति से हटाना चाहते हैं न कि किसी विशेष संग्रह से, तो `customXmlPart.Remove()` कॉल करें।

आप सूचकांक द्वारा भी भाग हटा सकते हैं:

```csharp
presentation.CustomData.CustomXmlParts.RemoveAt(0);
```

### **किसी संग्रह से सभी कस्टम XML भाग साफ़ करना**

जब किसी विशिष्ट प्रस्तुति वस्तु से जुड़े सभी कस्टम XML भाग हटाने हों, तो `Clear` का उपयोग करें।

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
presentation.Slides[0].CustomData.CustomXmlParts.Clear();

presentation.Save("slide_custom_xml_cleared.pptx", SaveFormat.Pptx);
```

`Clear` केवल चयनित संग्रह को प्रभावित करता है। उदाहरण के लिए, स्लाइड की संग्रह को साफ़ करने से प्रस्तुति‑स्तर या आकार‑स्तर की संग्रह साफ़ नहीं होगी।

हर कस्टम XML भाग को हटाने के लिए, `AllCustomXmlParts` पर इटेरेट करके प्रत्येक भाग को हटाएँ:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var customXmlPart in presentation.AllCustomXmlParts)
{
    customXmlPart.Remove();
}

presentation.Save("all_custom_xml_removed.pptx", SaveFormat.Pptx);
```

### **लिंक्ड या शेयर किए गए कस्टम XML भागों को संभालना**

Office Open XML प्रस्तुति में वही कस्टम XML भाग कई प्रस्तुति वस्तुओं से संदर्भित हो सकता है। उदाहरण के तौर पर, एक मौजूदा फ़ाइल में कई स्लाइड या आकार से उसी मूल कस्टम XML भाग के रिश्ते हो सकते हैं।

एक साझा भाग को कई संदर्भों वाले एक डेटा ऑब्जेक्ट के रूप में माना जाना चाहिए:

- उसके `XmlAsString`, `XmlData` या `ItemId` को अपडेट करने से मूल कस्टम XML भाग बदलता है, इसलिए परिवर्तन सभी स्थानों पर लागू होता है जहाँ वह भाग संदर्भित है।
- `ItemId` का उपयोग समान कस्टम XML भाग को पहचानने के लिए किया जा सकता है जबकि ऑब्जेक्ट‑स्तर के संग्रहों को ऑडिट किया जा रहा हो।
- किसी विशिष्ट `CustomXmlParts` संग्रह से भाग हटाने से वह केवल उस संग्रह से हटता है। यदि भाग स्वयं को पूरी प्रस्तुति से हटाना हो तो `ICustomXmlPart.Remove()` प्रयोग करें।
- साझा भाग को हटाने या बदलने से पहले ऑब्जेक्ट‑स्तर के संग्रहों की जाँच करें ताकि पता चल सके कि क्या अन्य स्लाइड या आकार अभी भी उसका संदर्भ रखते हैं।

`Add` ओवरलोड नए XML सामग्री से नया कस्टम XML भाग बनाते हैं; वे मौजूदा `ICustomXmlPart` को स्वीकार नहीं करते। इसलिए, साझा रिश्ते आम तौर पर उन प्रस्तुतियों को लोड करते समय मिलते हैं जिनमें पहले से ये हिस्से मौजूद होते हैं।

निम्न उदाहरण `ItemId` द्वारा प्रस्तुति‑, स्लाइड‑ और आकार‑स्तर के संग्रहों को ऑडिट करता है और उन भागों को रिपोर्ट करता है जो एक से अधिक स्थानों से संदर्भित हैं:

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

यह प्रकार का ऑडिट बाहरी सिस्टम द्वारा निर्मित प्रस्तुतियों में कस्टम XML डेटा को संशोधित या हटाने से पहले उपयोगी है, क्योंकि वही मेटाडेटा भाग कई रिश्तों में भाग ले सकता है।

## **टैग के मान प्राप्त करना**

स्लाइड्स में टैग `IDocumentProperties.Keywords` प्रॉपर्टी के समकक्ष होता है। यह नमूना कोड दिखाता है कि Aspose.Slides for .NET के साथ [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) में टैग मान कैसे प्राप्त किया जाए:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var keywords = presentation.DocumentProperties.Keywords;
```

## **प्रेजेंटेशन में टैग जोड़ना**

Aspose.Slides आपको प्रस्तुतियों में टैग जोड़ने की सुविधा देता है। एक टैग आम तौर पर दो आइटम से बना होता है:

- कस्टम प्रॉपर्टी का नाम, उदाहरण के लिए `MyTag`;
- कस्टम प्रॉपर्टी का मान, उदाहरण के लिए `My Tag Value`।

यदि आप किसी विशेष नियम या प्रॉपर्टी के आधार पर प्रस्तुतियों को वर्गीकृत करना चाहते हैं, तो आप इसके लिए टैग जोड़ सकते हैं। उदाहरण के लिए, यदि आप उत्तरी अमेरिकी देशों की प्रस्तुतियों को वर्गीकृत करना चाहते हैं, तो आप एक “North American” टैग बना सकते हैं और संबंधित देश को उसके मान के रूप में असाइन कर सकते हैं।

यह नमूना कोड Aspose.Slides for .NET का प्रयोग करके एक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) में टैग कैसे जोड़ें, दिखाता है:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var tags = presentation.CustomData.Tags;
tags["MyTag"] = "My Tag Value";
```

टैग को एक [Slide](https://reference.aspose.com/slides/hi/net/aspose.slides/slide) के लिए भी सेट किया जा सकता है:

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

`CustomData.Tags` संग्रह के माध्यम से जोड़े गए टैग केवल PowerPoint फ़ाइल में संग्रहीत होते हैं। इन्हें PDF टैग संरचना में निर्यात करने पर **स्थानांतरित नहीं** किया जाता। इसलिए, टैग के रूप में असाइन किया गया कस्टम पहचानकर्ता टैग किए गए PDF से प्राप्त नहीं किया जा सकता।

**उपाय**: आप किसी कस्टम पहचानकर्ता को ऑब्जेक्ट के **Alt Text** में संग्रहीत कर सकते हैं (उदाहरण के लिए, `shape.AlternativeText = "MyId"`). PDF निर्यात के बाद Alt Text PDF टैग संरचना में दिखाई दे सकता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक ही ऑपरेशन में प्रस्तुति, स्लाइड या आकार से सभी टैग हटा सकता हूँ?**

हां। [tag collection](https://reference.aspose.com/slides/hi/net/aspose.slides/tagcollection/) `Clear` ऑपरेशन का समर्थन करता है जो सभी कुंजी‑मूल्य जोड़ों को एक साथ हटाता है।

**मैं पूरे संग्रह पर इटरिटेट किए बिना किसी टैग को उसके नाम से कैसे हटाऊँ?**

`TagCollection` पर `Remove(name)` का उपयोग करके टैग को उसकी कुंजी से हटाएँ।

**मैं विश्लेषण या फ़िल्टरेशन के लिए टैग नामों की पूरी सूची कैसे प्राप्त कर सकता हूँ?**

[tag collection](https://reference.aspose.com/slides/hi/net/aspose.slides/tagcollection/) पर `GetNamesOfTags` का उपयोग करें; यह सभी टैग नामों की ऐरे लौटाता है।

**मैं सभी कस्टम XML भागों को कैसे पा सकता हूँ चाहे वे कहीं भी संग्रहीत हों?**

`Presentation.AllCustomXmlParts` का उपयोग करके प्रस्तुति में सभी कस्टम XML भागों को प्राप्त करें।

**कस्टम XML भाग को अपडेट करने के लिए मुझे `XmlAsString` या `XmlData` में से कौन सा उपयोग करना चाहिए?**

जब एप्लिकेशन UTF‑8 XML टेक्स्ट के साथ काम करता हो तो `XmlAsString` उपयोग करें। जब XML पहले से बाइट एरे में उपलब्ध हो या बाइनरी‑उन्मुख प्रोसेसिंग अधिक सुविधाजनक हो तो `XmlData` उपयोग करें। दोनों प्रॉपर्टी एक ही कस्टम XML भाग की XML सामग्री का प्रतिनिधित्व करती हैं।