---
title: समूह आकृति
type: docs
weight: 170
url: /hi/net/examples/elements/group-shape/
keywords:
- समूह
- समूह आकृति जोड़ें
- समूह आकृति तक पहुँचें
- समूह आकृति हटाएँ
- आकृतियों को अनग्रुप करें
- कोड उदाहरण
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET में समूहित आकृतियों को प्रबंधित करें: C# उदाहरणों के साथ PPT, PPTX, और ODP प्रस्तुतियों में समूह आकृतियों को बनाएं, नेस्ट करें, संरेखित करें, पुनः क्रमबद्ध करें, और स्टाइल करें।"
---
**Aspose.Slides for .NET** का उपयोग करके आकृतियों के समूह बनाने, उन्हें एक्सेस करने, अनग्रुप करने और हटाने के उदाहरण।

## **समूह आकृति जोड़ें**

दो बुनियादी आकृतियों वाला एक समूह बनाएँ।

```csharp
static void AddGroupShape()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var group = slide.Shapes.AddGroupShape();
    group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);
    group.Shapes.AddAutoShape(ShapeType.Ellipse, 60, 0, 50, 50);
}
```

## **समूह आकृति तक पहुँचें**

स्लाइड से पहली समूह आकृति प्राप्त करें।

```csharp
static void AccessGroupShape()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var group = slide.Shapes.AddGroupShape();
    group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

    var firstGroup = slide.Shapes.OfType<IGroupShape>().First();
}
```

## **समूह आकृति हटाएँ**

स्लाइड से एक समूह आकृति हटाएँ।

```csharp
static void RemoveGroupShape()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var group = slide.Shapes.AddGroupShape();

    slide.Shapes.Remove(group);
}
```

## **आकृतियों को अनग्रुप करें**

आकृतियों को समूह कंटेनर से बाहर ले जाएँ।

```csharp
static void UngroupShapes()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var group = slide.Shapes.AddGroupShape();
    var rect = group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

    // आकार को समूह से बाहर ले जाएँ।
    slide.Shapes.AddClone(rect);
    group.Shapes.Remove(rect);
}
```