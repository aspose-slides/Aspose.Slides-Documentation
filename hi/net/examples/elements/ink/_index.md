---
title: इंक
type: docs
weight: 180
url: /hi/net/examples/elements/ink/
keywords:
- इंक
- इंक तक पहुँच
- इंक हटाएँ
- कोड उदाहरण
- PowerPoint
- OpenDocument
- प्रस्तुतीकरण
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET में इंक के साथ काम करें: ड्रॉ करें, आयात करें और स्ट्रोक को संपादित करें, रंग और चौड़ाई समायोजित करें, और C# उदाहरणों का उपयोग करके PPT, PPTX और ODP में निर्यात करें।"
---
यह लेख मौजूदा इंक शैलियों तक पहुँचने और उन्हें हटाने के उदाहरण **Aspose.Slides for .NET** का उपयोग करके प्रदान करता है।

> ❗ **ध्यान दें:** इंक शैलियां विशेष उपकरणों से उपयोगकर्ता इनपुट को दर्शाती हैं। Aspose.Slides प्रोग्रामेटिक रूप से नई इंक स्ट्रोक नहीं बना सकता, लेकिन आप मौजूदा इंक को पढ़ और संशोधित कर सकते हैं।

## **इंक तक पहुँच**

स्लाइड पर पहली इंक शैप से टैग पढ़ें।

```csharp
static void AccessInk()
{
    using var presentation = new Presentation("ink.pptx");
    var slide = presentation.Slides[0];

    if (slide.Shapes[0] is Ink inkShape)
    {
        var tags = inkShape.CustomData.Tags;
        if (tags.Count > 0)
        {
            var tagName = tags.GetNameByIndex(0);
            // आवश्यकतानुसार tagName का उपयोग करें।
        }
    }
}
```

## **इंक हटाएँ**

यदि मौजूद हो तो स्लाइड से इंक शैप को हटाएँ।

```csharp
static void RemoveInk()
{
    using var presentation = new Presentation("ink.pptx");
    var slide = presentation.Slides[0];

    if (slide.Shapes.FirstOrDefault(s => s is Ink) is Ink ink)
    {
        slide.Shapes.Remove(ink);
    }
}
```