---
title: Gráfico
type: docs
weight: 60
url: /es/net/examples/elements/chart/
keywords:
- gráfico
- agregar gráfico
- acceder al gráfico
- eliminar gráfico
- actualizar gráfico
- ejemplo de código
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Domina los gráficos con Aspose.Slides for .NET: crea, da formato, enlaza datos y exporta gráficos en PPT, PPTX y ODP con ejemplos en C#."
---
Ejemplos de cómo agregar, acceder, eliminar y actualizar diferentes tipos de gráficos con **Aspose.Slides for .NET**. Los fragmentos a continuación demuestran operaciones básicas con gráficos.

## **Agregar un gráfico**

Este método agrega un gráfico de área simple a la primera diapositiva.

```csharp
static void AddChart()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Añade un gráfico de área simple a la primera diapositiva.
    var chart = slide.Shapes.AddChart(ChartType.Area, 50, 50, 400, 300);
}
```

## **Acceder a un gráfico**

Después de crear un gráfico, puedes obtenerlo a través de la colección de formas.

```csharp
static void AccessChart()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 400, 300);

    // Accede al primer gráfico en la diapositiva.
    var firstChart = slide.Shapes.OfType<IChart>().First();
}
```

## **Eliminar un gráfico**

El siguiente código elimina un gráfico de una diapositiva.

```csharp
static void RemoveChart()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 300);

    // Elimina el gráfico.
    slide.Shapes.Remove(chart);
}
```

## **Actualizar datos del gráfico**

Puedes cambiar las propiedades del gráfico, como el título.

```csharp
static void UpdateChartData()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    var chart = slide.Shapes.AddChart(ChartType.Column3D, 50, 50, 400, 300);

    // Cambia el título del gráfico.
    chart.ChartTitle.AddTextFrameForOverriding("Sales Report");
}
```