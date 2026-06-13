---
title: हेडर फुटर
type: docs
weight: 220
url: /hi/net/examples/elements/header-footer/
keywords:
- हेडर फुटर
- हेडर फुटर जोड़ें
- हेडर फुटर अपडेट करें
- कोड उदाहरण
- पावरपॉइंट
- ओपनडॉक्यूमेंट
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ स्लाइड हेडर और फुटर को नियंत्रित करें: PPT, PPTX, और ODP में तिथियां, स्लाइड नंबर और कस्टम टेक्स्ट जोड़ें C# उदाहरणों के साथ."
---
यह लेख **Aspose.Slides for .NET** का उपयोग करके फ़ूटर जोड़ने तथा दिनांक और समय प्लेसहोल्डर को अपडेट करने का प्रदर्शन करता है।

## **फ़ूटर जोड़ें**

एक स्लाइड के फ़ूटर क्षेत्र में पाठ जोड़ें और उसे दृश्यमान बनाएं।

```csharp
static void AddHeaderFooter()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.HeaderFooterManager.SetFooterText("My footer");
    slide.HeaderFooterManager.SetFooterVisibility(isVisible: true);
}
```

## **तारीख और समय अपडेट करें**

स्लाइड पर दिनांक और समय प्लेसहोल्डर को संशोधित करें।

```csharp
static void UpdateDateTime()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.HeaderFooterManager.SetDateTimeText("01/01/2024");
    slide.HeaderFooterManager.SetDateTimeVisibility(isVisible: true);
}
```