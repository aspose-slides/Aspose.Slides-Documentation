---
title: टेबल
type: docs
weight: 120
url: /hi/net/examples/elements/table/
keywords:
- तालिका
- तालिका जोड़ें
- तालिका तक पहुँचें
- तालिका हटाएँ
- कोशिकाएँ मिलाएँ
- कोड उदाहरण
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET में तालिकाओं के साथ काम करें: बनाएँ, स्वरूपित करें, कोशिकाओं को मिलाएँ, शैलियों को लागू करें, डेटा आयात करें, और PPT, PPTX और ODP के लिए C# उदाहरणों के साथ निर्यात करें।"
---
Aspose.Slides for .NET का उपयोग करके टेबल जोड़ने, उन तक पहुँचने, हटाने और कोशिकाओं को मिलाने के उदाहरण।

## **टेबल जोड़ें**

दो पंक्तियों और दो स्तम्भों वाली एक सरल टेबल बनाएँ।

```csharp
static void AddTable()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);
}
```

## **टेबल तक पहुँचें**

स्लाइड पर पहली टेबल शेप प्राप्त करें।

```csharp
static void AccessTable()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);

    // स्लाइड पर पहली तालिका तक पहुँचें।
    var firstTable = slide.Shapes.OfType<ITable>().First();
}
```

## **टेबल हटाएँ**

स्लाइड से एक टेबल हटाएँ।

```csharp
static void RemoveTable()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);

    slide.Shapes.Remove(table);
}
```

## **टेबल कोशिकाओं को मिलाएँ**

टेबल की आसन्न कोशिकाओं को एकल कोशिका में मिलाएँ।

```csharp
static void MergeTableCells()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);

    table.MergeCells(table[0, 0], table[1, 1], false);
}
```