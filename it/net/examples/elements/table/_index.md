---
title: Tabella
type: docs
weight: 120
url: /it/net/examples/elements/table/
keywords:
- tabella
- aggiungere tabella
- accedere alla tabella
- rimuovere tabella
- unire celle
- esempio di codice
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Lavora con le tabelle in Aspose.Slides per .NET: crea, formatta, unisci celle, applica stili, importa dati e esporta con esempi C# per PPT, PPTX e ODP."
---
Esempi per aggiungere tabelle, accedervi, rimuoverle e unire le celle usando **Aspose.Slides per .NET**.

## **Aggiungere una tabella**

Crea una tabella semplice con due righe e due colonne.

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

## **Accedere a una tabella**

Recupera la prima forma tabella nella diapositiva.

```csharp
static void AccessTable()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);

    // Accedi alla prima tabella sulla diapositiva.
    var firstTable = slide.Shapes.OfType<ITable>().First();
}
```

## **Rimuovere una tabella**

Elimina una tabella da una diapositiva.

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

## **Unire le celle della tabella**

Unisci celle adiacenti di una tabella in un’unica cella.

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