---
title: Tabell
type: docs
weight: 120
url: /sv/net/examples/elements/table/
keywords:
- tabell
- lägg till tabell
- åtkomst till tabell
- ta bort tabell
- slå ihop celler
- kodexempel
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Arbeta med tabeller i Aspose.Slides för .NET: skapa, formatera, slå ihop celler, tillämpa stilar, importera data och exportera med C#-exempel för PPT, PPTX och ODP."
---
Exempel på att lägga till tabeller, komma åt dem, ta bort dem och slå samman celler med hjälp av **Aspose.Slides for .NET**.

## **Lägg till en tabell**

Skapa en enkel tabell med två rader och två kolumner.

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

## **Kom åt en tabell**

Hämta den första tabellformen på bilden.

```csharp
static void AccessTable()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);

    // Hämta den första tabellen på bilden.
    var firstTable = slide.Shapes.OfType<ITable>().First();
}
```

## **Ta bort en tabell**

Ta bort en tabell från en bild.

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

## **Slå ihop tabellceller**

Slå ihop intilliggande celler i en tabell till en enda cell.

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