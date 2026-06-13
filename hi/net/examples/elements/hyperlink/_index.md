---
title: हाइपरलिंक
type: docs
weight: 130
url: /hi/net/examples/elements/hyperlink/
keywords:
- हाइपरलिंक
- हाइपरलिंक जोड़ें
- हाइपरलिंक प्राप्त करें
- हाइपरलिंक हटाएं
- हाइपरलिंक अपडेट करें
- कोड उदाहरण
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET में हाइपरलिंक जोड़ें और प्रबंधित करें: टेक्स्ट, आकार और चित्रों को लिंक करें, PPT, PPTX और ODP के लिए लक्ष्यों और कार्यों को सेट करें, C# उदाहरणों के साथ।"
---
यह लेख आकारों पर हाइपरलिंक जोड़ने, प्राप्त करने, हटाने और अद्यतन करने को **Aspose.Slides for .NET** के उपयोग से प्रदर्शित करता है।

## **हाइपरलिंक जोड़ें**

एक आयताकार आकार बनाएं जिसमें एक हाइपरलिंक बाहरी वेबसाइट की ओर संकेत करता हो।

```csharp
static void AddHyperlink()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";

    var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
    textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");
}
```

## **हाइपरलिंक तक पहुंचें**

एक आकार के टेक्स्ट भाग से हाइपरलिंक सूचना पढ़ें।

```csharp
static void AccessHyperlink()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";

    var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
    textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");

    var hyperlink = shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick;
}
```

## **हाइपरलिंक हटाएं**

एक आकार के टेक्स्ट से हाइपरलिंक साफ़ करें।

```csharp
static void RemoveHyperlink()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";

    var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
    textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");

    textPortion.PortionFormat.HyperlinkClick = null;
}
```

## **हाइपरलिंक अपडेट करें**

मौजूदा हाइपरलिंक के लक्ष्य को बदलें। `HyperlinkManager` का उपयोग करके ऐसे टेक्स्ट को संशोधित करें जिसमें पहले से हाइपरलिंक मौजूद हो, जो दर्शाता है कि PowerPoint सुरक्षित रूप से हाइपरलिंक को कैसे अपडेट करता है।

```csharp
static void UpdateHyperlink()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";

    var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
    textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://old.example.com");

    // मौजूदा टेक्स्ट के भीतर हाइपरलिंक को बदलने के लिए इसे उपयोग किया जाना चाहिए
    // HyperlinkManager का उपयोग करके, सीधे प्रॉपर्टी सेट करने के बजाय।
    // यह दिखाता है कि PowerPoint हाइपरलिंक को सुरक्षित रूप से कैसे अपडेट करता है।
    textPortion.PortionFormat.HyperlinkManager.SetExternalHyperlinkClick("https://new.example.com");
}
```