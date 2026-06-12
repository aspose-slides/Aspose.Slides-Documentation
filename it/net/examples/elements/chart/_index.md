---
title: Grafico
type: docs
weight: 60
url: /it/net/examples/elements/chart/
keywords:
- grafico
- aggiungi grafico
- accedi al grafico
- rimuovi grafico
- aggiorna grafico
- esempio di codice
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Domina i grafici con Aspose.Slides per .NET: crea, formatta, collega i dati ed esporta i grafici in PPT, PPTX e ODP con esempi C#."
---
Esempi di aggiunta, accesso, rimozione e aggiornamento di diversi tipi di grafico con **Aspose.Slides for .NET**. Gli snippet seguenti mostrano le operazioni di base sui grafici.

## **Aggiungi un grafico**

Questo metodo aggiunge un semplice grafico ad area alla prima diapositiva.

```csharp
static void AddChart()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Aggiungi un semplice grafico ad area alla prima diapositiva.
    var chart = slide.Shapes.AddChart(ChartType.Area, 50, 50, 400, 300);
}
```

## **Accedi a un grafico**

Dopo aver creato un grafico, è possibile recuperarlo tramite la collezione di forme.

```csharp
static void AccessChart()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 400, 300);

    // Accedi al primo grafico sulla diapositiva.
    var firstChart = slide.Shapes.OfType<IChart>().First();
}
```

## **Rimuovi un grafico**

Il codice seguente rimuove un grafico da una diapositiva.

```csharp
static void RemoveChart()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 300);

    // Rimuovi il grafico.
    slide.Shapes.Remove(chart);
}
```

## **Aggiorna i dati del grafico**

È possibile modificare le proprietà del grafico, come il titolo.

```csharp
static void UpdateChartData()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    var chart = slide.Shapes.AddChart(ChartType.Column3D, 50, 50, 400, 300);

    // Modifica il titolo del grafico.
    chart.ChartTitle.AddTextFrameForOverriding("Sales Report");
}
```