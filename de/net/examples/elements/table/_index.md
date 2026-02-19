---
title: Tabelle
type: docs
weight: 120
url: /de/net/examples/elements/table/
keywords:
- Tabelle
- Tabelle hinzufügen
- Tabelle zugreifen
- Tabelle entfernen
- Zellen zusammenführen
- Codebeispiel
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Arbeiten mit Tabellen in Aspose.Slides für .NET: Erstellen, formatieren, Zellen zusammenführen, Stile anwenden, Daten importieren und exportieren mit C#‑Beispielen für PPT, PPTX und ODP."
---
Beispiele zum Hinzufügen von Tabellen, zum Zugriff darauf, zum Entfernen und zum Zusammenführen von Zellen mit **Aspose.Slides for .NET**.

## **Tabelle hinzufügen**

Erstellen Sie eine einfache Tabelle mit zwei Zeilen und zwei Spalten.

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

## **Zugriff auf eine Tabelle**

Rufen Sie das erste Tabell-Shape auf der Folie ab.

```csharp
static void AccessTable()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);

    // Zugriff auf die erste Tabelle auf der Folie.
    var firstTable = slide.Shapes.OfType<ITable>().First();
}
```

## **Tabelle entfernen**

Löschen Sie eine Tabelle von einer Folie.

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

## **Tabellenzellen zusammenführen**

Führen Sie benachbarte Zellen einer Tabelle zu einer einzigen Zelle zusammen.

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