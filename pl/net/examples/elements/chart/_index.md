---
title: Wykres
type: docs
weight: 60
url: /pl/net/examples/elements/chart/
keywords:
- wykres
- dodaj wykres
- uzyskaj dostęp do wykresu
- usuń wykres
- zaktualizuj wykres
- przykład kodu
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Opanuj wykresy z Aspose.Slides for .NET: twórz, formatuj, powiązuj dane i eksportuj wykresy w formatach PPT, PPTX i ODP przy użyciu przykładów w C#."
---
Przykłady dodawania, uzyskiwania dostępu, usuwania i aktualizacji różnych typów wykresów przy użyciu **Aspose.Slides for .NET**. Poniższe fragmenty kodu demonstrują podstawowe operacje na wykresach.

## **Dodaj wykres**
Ta metoda dodaje prosty wykres warstwowy do pierwszego slajdu.

```csharp
static void AddChart()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Dodaj prosty wykres warstwowy do pierwszego slajdu.
    var chart = slide.Shapes.AddChart(ChartType.Area, 50, 50, 400, 300);
}
```

## **Uzyskaj dostęp do wykresu**
Po utworzeniu wykresu możesz go pobrać z kolekcji kształtów.

```csharp
static void AccessChart()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 400, 300);

    // Uzyskaj dostęp do pierwszego wykresu na slajdzie.
    var firstChart = slide.Shapes.OfType<IChart>().First();
}
```

## **Usuń wykres**
Poniższy kod usuwa wykres ze slajdu.

```csharp
static void RemoveChart()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 300);

    // Usuń wykres.
    slide.Shapes.Remove(chart);
}
```

## **Aktualizuj dane wykresu**
Możesz zmienić właściwości wykresu, takie jak tytuł.

```csharp
static void UpdateChartData()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    var chart = slide.Shapes.AddChart(ChartType.Column3D, 50, 50, 400, 300);

    // Zmień tytuł wykresu.
    chart.ChartTitle.AddTextFrameForOverriding("Sales Report");
}
```