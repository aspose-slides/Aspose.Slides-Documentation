---
title: Táblázat
type: docs
weight: 120
url: /hu/net/examples/elements/table/
keywords:
- táblázat
- táblázat hozzáadása
- táblázat elérése
- táblázat eltávolítása
- cellák egyesítése
- kódpélda
- PowerPoint
- OpenDocument
- bemutató
- .NET
- C#
- Aspose.Slides
description: "Táblázatok kezelése az Aspose.Slides for .NET segítségével: létrehozás, formázás, cellák egyesítése, stílusok alkalmazása, adatok importálása és exportálása C# példákkal PPT, PPTX és ODP formátumokhoz."
---
Példák táblák hozzáadására, elérésére, eltávolítására és a cellák egyesítésére a **Aspose.Slides for .NET** használatával.

## **Táblázat hozzáadása**

Hozzon létre egy egyszerű táblázatot két sorral és két oszloppal.

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

## **Táblázat elérése**

A dián található első táblázat alakzat lekérése.

```csharp
static void AccessTable()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);

    // Az első táblázat elérése a dián.
    var firstTable = slide.Shapes.OfType<ITable>().First();
}
```

## **Táblázat eltávolítása**

Táblázat törlése egy diáról.

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

## **Táblázatcellák egyesítése**

A táblázat szomszédos celláinak egyetlen cellává egyesítése.

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