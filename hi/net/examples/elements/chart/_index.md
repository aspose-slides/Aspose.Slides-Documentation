---
title: चार्ट
type: docs
weight: 60
url: /hi/net/examples/elements/chart/
keywords:
- चार्ट
- चार्ट जोड़ें
- चार्ट तक पहुँचें
- चार्ट हटाएँ
- चार्ट अपडेट करें
- कोड उदाहरण
- पावरपॉइंट
- ओपनडॉक्यूमेंट
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ चार्टों में मास्टर बनें: बनाएं, स्वरूपित करें, डेटा बाइंड करें, और C# उदाहरणों के साथ PPT, PPTX और ODP में चार्ट निर्यात करें।"
---
विभिन्न चार्ट प्रकारों को जोड़ने, एक्सेस करने, हटाने और अपडेट करने के उदाहरण **Aspose.Slides for .NET** के साथ। नीचे दिए गए स्निपेट्स बुनियादी चार्ट संचालन दर्शाते हैं।

## **एक चार्ट जोड़ें**

यह मेथड पहले स्लाइड में एक साधारण एरिया चार्ट जोड़ता है।

```csharp
static void AddChart()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // पहले स्लाइड में एक साधारण एरिया चार्ट जोड़ें।
    var chart = slide.Shapes.AddChart(ChartType.Area, 50, 50, 400, 300);
}
```

## **एक चार्ट तक पहुँचें**

एक चार्ट बनाने के बाद, आप इसे शेप कलेक्शन के माध्यम से प्राप्त कर सकते हैं।

```csharp
static void AccessChart()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 400, 300);

    // स्लाइड पर पहला चार्ट एक्सेस करें।
    var firstChart = slide.Shapes.OfType<IChart>().First();
}
```

## **एक चार्ट हटाएँ**

निम्नलिखित कोड एक स्लाइड से चार्ट हटाता है।

```csharp
static void RemoveChart()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 300);

    // चार्ट हटाएँ।
    slide.Shapes.Remove(chart);
}
```

## **चार्ट डेटा अपडेट करें**

आप चार्ट गुणों को बदल सकते हैं, जैसे शीर्षक।

```csharp
static void UpdateChartData()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    var chart = slide.Shapes.AddChart(ChartType.Column3D, 50, 50, 400, 300);

    // चार्ट शीर्षक बदलें।
    chart.ChartTitle.AddTextFrameForOverriding("Sales Report");
}
```