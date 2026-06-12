---
title: Graf
type: docs
weight: 60
url: /cs/net/examples/elements/chart/
keywords:
- graf
- přidat graf
- přístup k grafu
- odstranit graf
- aktualizovat graf
- ukázka kódu
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Ovládněte grafy s Aspose.Slides pro .NET: vytvářejte, formátujte, vázat data a exportujte grafy do PPT, PPTX a ODP s příklady v C#."
---
Příklady přidávání, přístupu, odstraňování a aktualizace různých typů grafů pomocí **Aspose.Slides for .NET**. Níže uvedené úryvky ukazují základní operace s grafy.

## **Přidat graf**

Tato metoda přidá jednoduchý plošný graf na první snímek.

```csharp
static void AddChart()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Přidá jednoduchý plošný graf na první snímek.
    var chart = slide.Shapes.AddChart(ChartType.Area, 50, 50, 400, 300);
}
```

## **Přístup k grafu**

Po vytvoření grafu jej můžete získat prostřednictvím kolekce tvarů.

```csharp
static void AccessChart()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 400, 300);

    // Přístup k prvnímu grafu na snímku.
    var firstChart = slide.Shapes.OfType<IChart>().First();
}
```

## **Odstranit graf**

Následující kód odstraní graf ze snímku.

```csharp
static void RemoveChart()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 300);

    // Odstranit graf.
    slide.Shapes.Remove(chart);
}
```

## **Aktualizovat data grafu**

Můžete změnit vlastnosti grafu, například název.

```csharp
static void UpdateChartData()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    var chart = slide.Shapes.AddChart(ChartType.Column3D, 50, 50, 400, 300);

    // Změnit název grafu.
    chart.ChartTitle.AddTextFrameForOverriding("Sales Report");
}
```