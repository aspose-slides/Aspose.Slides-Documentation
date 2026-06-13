---
title: कनेक्टर
type: docs
weight: 190
url: /hi/net/examples/elements/connector/
keywords:
- कनेक्टर
- कनेक्टर जोड़ें
- कनेक्टर तक पहुँचें
- कनेक्टर हटाएँ
- आकृतियों को पुनः कनेक्ट करें
- कोड उदाहरण
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET का उपयोग करके आकृतियों के बीच कनेक्टर जोड़ने, मार्ग निर्धारित करने और शैली सेट करने के बारे में सीखें, PPT, PPTX और ODP प्रस्तुतियों के लिए C# उदाहरणों के साथ।"
---
यह लेख दर्शाता है कि **Aspose.Slides for .NET** का उपयोग करके आकृतियों को कनेक्टरों से कैसे जोड़ा जाए और उनके लक्ष्य को कैसे बदला जाए।

## **एक कनेक्टर जोड़ें**
स्लाइड पर दो बिंदुओं के बीच एक कनेक्टर आकृति डालें।

```csharp
static void AddConnector()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);
}
```

## **एक कनेक्टर तक पहुँचें**
स्लाइड में जोड़ा गया पहला कनेक्टर आकृति प्राप्त करें।

```csharp
static void AccessConnector()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    var connector = slide.Shapes.OfType<IConnector>().First();
}
```

## **एक कनेक्टर हटाएँ**
स्लाइड से एक कनेक्टर हटाएँ।

```csharp
static void RemoveConnector()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    slide.Shapes.Remove(connector);
}
```

## **आकृतियों को पुनः कनेक्ट करें**
प्रारंभ और अंत लक्ष्य असाइन करके दो आकृतियों के साथ एक कनेक्टर संलग्न करें।

```csharp
static void ReconnectShapes()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);
    var shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 50, 50);
    var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    connector.StartShapeConnectedTo = shape1;
    connector.EndShapeConnectedTo = shape2;
}
```