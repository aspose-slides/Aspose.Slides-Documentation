---
title: Tabla
type: docs
weight: 120
url: /es/net/examples/elements/table/
keywords:
- tabla
- añadir tabla
- acceder tabla
- eliminar tabla
- combinar celdas
- ejemplo de código
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Trabaje con tablas en Aspose.Slides for .NET: cree, formatee, combine celdas, aplique estilos, importe datos y exporte con ejemplos en C# para PPT, PPTX y ODP."
---
Ejemplos de cómo añadir tablas, acceder a ellas, eliminarlas y combinar celdas usando **Aspose.Slides for .NET**.

## **Añadir una tabla**

Crea una tabla sencilla con dos filas y dos columnas.

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

## **Acceder a una tabla**

Obtén la primera forma de tabla en la diapositiva.

```csharp
static void AccessTable()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);

    // Acceder a la primera tabla de la diapositiva.
    var firstTable = slide.Shapes.OfType<ITable>().First();
}
```

## **Eliminar una tabla**

Elimina una tabla de una diapositiva.

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

## **Combinar celdas de tabla**

Combina celdas adyacentes de una tabla en una sola celda.

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