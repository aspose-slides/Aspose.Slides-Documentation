---
title: OLE ऑब्जेक्ट
type: docs
weight: 210
url: /hi/net/examples/elements/ole-object/
keywords:
- OLE ऑब्जेक्ट
- OLE ऑब्जेक्ट जोड़ें
- OLE ऑब्जेक्ट एक्सेस करें
- OLE ऑब्जेक्ट हटाएँ
- OLE ऑब्जेक्ट अपडेट करें
- कोड उदाहरण
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET में OLE ऑब्जेक्ट को संभालें: PPT, PPTX और ODP प्रस्तुति में C# के साथ एम्बेडेड सामग्री को सम्मिलित करें, लिंक करें, अपडेट करें और निकालें।"
---
यह लेख फ़ाइल को OLE ऑब्जेक्ट के रूप में एम्बेड करने और **Aspose.Slides for .NET** का उपयोग करके उसके डेटा को अपडेट करने का प्रदर्शन करता है।

## **OLE ऑब्जेक्ट जोड़ें**

प्रेजेंटेशन में एक PDF फ़ाइल एम्बेड करें।

```csharp
static void AddOleObject()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var pdfData = File.ReadAllBytes("doc.pdf");
    var dataInfo = new OleEmbeddedDataInfo(pdfData, "pdf");
    var oleFrame = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, dataInfo);
}
```

## **OLE ऑब्जेक्ट एक्सेस करें**

स्लाइड पर पहला OLE ऑब्जेक्ट फ़्रेम प्राप्त करें।

```csharp
static void AccessOleObject()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var pdfData = File.ReadAllBytes("doc.pdf");
    var dataInfo = new OleEmbeddedDataInfo(pdfData, "pdf");
    var oleFrame = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, dataInfo);

    var firstOleFrame = slide.Shapes.OfType<IOleObjectFrame>().First();
}
```

## **OLE ऑब्जेक्ट हटाएँ**

स्लाइड से एम्बेडेड OLE ऑब्जेक्ट हटाएँ।

```csharp
static void RemoveOleObject()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var pdfData = File.ReadAllBytes("doc.pdf");
    var dataInfo = new OleEmbeddedDataInfo(pdfData, "pdf");
    var oleFrame = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, dataInfo);

    slide.Shapes.Remove(oleFrame);
}
```

## **OLE ऑब्जेक्ट डेटा अपडेट करें**

मौजूदा OLE ऑब्जेक्ट में एम्बेडेड डेटा को बदलें।

```csharp
static void UpdateOleObjectData()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var pdfData = File.ReadAllBytes("doc.pdf");
    var dataInfo = new OleEmbeddedDataInfo(pdfData, "pdf");
    var oleFrame = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, dataInfo);

    var newData = File.ReadAllBytes("Picture.png");
    var newDataInfo = new OleEmbeddedDataInfo(newData, "png");
    oleFrame.SetEmbeddedData(newDataInfo);
}
```