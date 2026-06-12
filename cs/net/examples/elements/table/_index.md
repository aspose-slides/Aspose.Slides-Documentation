---
title: Tabulka
type: docs
weight: 120
url: /cs/net/examples/elements/table/
keywords:
- tabulka
- přidat tabulku
- přístup k tabulce
- odstranit tabulku
- sloučit buňky
- ukázka kódu
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Pracujte s tabulkami v Aspose.Slides pro .NET: vytvářejte, formátujte, sloučujte buňky, aplikujte styly, importujte data a exportujte s ukázkami v C# pro PPT, PPTX a ODP."
---
Příklady přidávání tabulek, přístupu k nim, odstraňování a slučování buněk pomocí **Aspose.Slides for .NET**.

## **Přidat tabulku**

Vytvořte jednoduchou tabulku se dvěma řádky a dvěma sloupci.

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

## **Přístup k tabulce**

Získejte první tvar tabulky na snímku.

```csharp
static void AccessTable()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);

    // Přístup k první tabulce na snímku.
    var firstTable = slide.Shapes.OfType<ITable>().First();
}
```

## **Odstranit tabulku**

Odstraňte tabulku ze snímku.

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

## **Sloučit buňky tabulky**

Sloučte sousední buňky tabulky do jedné buňky.

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