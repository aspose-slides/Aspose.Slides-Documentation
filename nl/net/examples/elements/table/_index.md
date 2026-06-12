---
title: Tabel
type: docs
weight: 120
url: /nl/net/examples/elements/table/
keywords:
- tabel
- tabel toevoegen
- tabel benaderen
- tabel verwijderen
- cellen samenvoegen
- codevoorbeeld
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Werken met tabellen in Aspose.Slides voor .NET: maken, opmaken, cellen samenvoegen, stijlen toepassen, gegevens importeren en exporteren met C#-voorbeelden voor PPT, PPTX en ODP."
---
Voorbeelden voor het toevoegen van tabellen, het benaderen ervan, het verwijderen ervan en het samenvoegen van cellen met **Aspose.Slides for .NET**.

## **Tabel toevoegen**

Maak een eenvoudige tabel met twee rijen en twee kolommen.

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

## **Toegang tot een tabel**

Haal de eerste tabelvorm op de dia op.

```csharp
static void AccessTable()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);

    // Toegang tot de eerste tabel op de dia.
    var firstTable = slide.Shapes.OfType<ITable>().First();
}
```

## **Tabel verwijderen**

Verwijder een tabel van een dia.

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

## **Tabelcellen samenvoegen**

Voeg aangrenzende cellen van een tabel samen tot één enkele cel.

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