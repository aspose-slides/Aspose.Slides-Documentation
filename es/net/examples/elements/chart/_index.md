---
title: Gráfico
type: docs
weight: 60
url: /es/net/examples/elements/chart/
keywords:
- ejemplo de gráfico
- agregar gráfico
- acceder al gráfico
- eliminar gráfico
- actualizar gráfico
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Cree y personalice gráficos en C# con Aspose.Slides: añada datos, formatee series, ejes y etiquetas, cambie tipos y exporte—compatible con PPT, PPTX y ODP."
---

Ejemplos de cómo agregar, acceder, eliminar y actualizar diferentes tipos de gráficos con **Aspose.Slides for .NET**. Los fragmentos a continuación demuestran operaciones básicas con gráficos.

## **Agregar un gráfico**

Este método añade un gráfico de área sencillo a la primera diapositiva.
```csharp
static void Add_Chart()
{
    using var pres = new Presentation();

    // Añadir un gráfico de columnas simple a la primera diapositiva
    var slide = pres.Slides[0];
    var chart = slide.Shapes.AddChart(ChartType.Area, 50, 50, 400, 300);
}
```


## **Acceder a un gráfico**

Después de crear un gráfico, puedes recuperarlo a través de la colección de formas.
```csharp
static void Access_Chart()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 400, 300);

    // Acceder al primer gráfico en la diapositiva
    var firstChart = slide.Shapes.OfType<IChart>().First();
}
```


## **Eliminar un gráfico**

El siguiente código elimina un gráfico de una diapositiva.
```csharp
static void Remove_Chart()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 300);

    // Eliminar el gráfico
    slide.Shapes.Remove(chart);
}
```


## **Actualizar datos del gráfico**

Puedes cambiar propiedades del gráfico, como el título.
```csharp
static void Update_Chart_Data()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var chart = slide.Shapes.AddChart(ChartType.Column3D, 50, 50, 400, 300);

    // Cambiar el título del gráfico
    chart.ChartTitle.AddTextFrameForOverriding("Sales Report");
}
```
