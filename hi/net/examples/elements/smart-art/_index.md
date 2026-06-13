---
title: SmartArt
type: docs
weight: 140
url: /hi/net/examples/elements/smart-art/
keywords:
- SmartArt
- SmartArt जोड़ें
- SmartArt तक पहुँचें
- SmartArt हटाएँ
- SmartArt लेआउट
- कोड उदाहरण
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET में SmartArt के साथ काम करें: PowerPoint और OpenDocument प्रस्तुतियों के लिए C# में आरेख बनाएं, संपादित करें, बदलें और शैली दें।"
---
यह लेख **Aspose.Slides for .NET** का उपयोग करके SmartArt ग्राफ़िक्स को जोड़ने, उनका अभिगम करने, उन्हें हटाने, और लेआउट बदलने के तरीके दर्शाता है।

## **SmartArt जोड़ें**

निर्मित लेआउट्स में से किसी एक का उपयोग करके SmartArt ग्राफ़िक सम्मिलित करें।

```csharp
static void AddSmartArt()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);
}
```

## **SmartArt तक पहुँचें**

स्लाइड पर पहला SmartArt ऑब्जेक्ट प्राप्त करें।

```csharp
static void AccessSmartArt()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

    var firstSmartArt = slide.Shapes.OfType<ISmartArt>().First();
}
```

## **SmartArt हटाएँ**

स्लाइड से SmartArt आकार को हटाएँ।

```csharp
static void RemoveSmartArt()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

    slide.Shapes.Remove(smartArt);
}
```

## **SmartArt लेआउट बदलें**

मौजूदा SmartArt ग्राफ़िक का लेआउट प्रकार अपडेट करें।

```csharp
static void ChangeSmartArtLayout()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicBlockList);

    smartArt.Layout = SmartArtLayoutType.VerticalPictureList;
}
```