---
title: Tabla
type: docs
weight: 120
url: /es/net/examples/elements/table/
keywords:
- ejemplo de tabla
- agregar tabla
- acceder a la tabla
- eliminar tabla
- combinar celdas
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Cree y formatee tablas en C# con Aspose.Slides: inserte datos, combine celdas, estilice bordes, alinee contenido e importe/exporte para PPT, PPTX y ODP."
---

Ejemplos para agregar tablas, acceder a ellas, eliminarlas y combinar celdas usando **Aspose.Slides for .NET**.

## Agregar una tabla

Cree una tabla simple con dos filas y dos columnas.
```csharp
static void Add_Table()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);
}
```


## Acceder a una tabla

Recupere la primera forma de tabla en la diapositiva.
```csharp
static void Access_Table()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);

    // Acceder a la primera tabla en la diapositiva
    var firstTable = slide.Shapes.OfType<ITable>().First();
}
```


## Eliminar una tabla

Elimine una tabla de una diapositiva.
```csharp
static void Remove_Table()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);

    slide.Shapes.Remove(table);
}
```


## Combinar celdas de tabla

Combine celdas adyacentes de una tabla en una única celda.
```csharp
static void Merge_Table_Cells()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);

    table.MergeCells(table[0, 0], table[1, 1], false);
}
```
