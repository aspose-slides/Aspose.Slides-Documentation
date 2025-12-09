---
title: Tabelle
type: docs
weight: 120
url: /de/net/examples/elements/table/
keywords:
- Tabellenbeispiel
- Tabelle hinzufügen
- Zugriff auf Tabelle
- Tabelle entfernen
- Zellen zusammenführen
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erstellen und formatieren Sie Tabellen in C# mit Aspose.Slides: Daten einfügen, Zellen zusammenführen, Rahmen gestalten, Inhalte ausrichten und für PPT, PPTX und ODP importieren/exportieren."
---

Beispiele zum Hinzufügen von Tabellen, zum Zugriff darauf, zum Entfernen und zum Zusammenführen von Zellen mithilfe von **Aspose.Slides for .NET**.

## Tabelle hinzufügen

Erstellen Sie eine einfache Tabelle mit zwei Zeilen und zwei Spalten.
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


## Zugriff auf eine Tabelle

Rufen Sie die erste Tabellengestalt auf der Folie ab.
```csharp
static void Access_Table()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);

    // Zugriff auf die erste Tabelle auf der Folie
    var firstTable = slide.Shapes.OfType<ITable>().First();
}
```


## Tabelle entfernen

Löschen Sie eine Tabelle von einer Folie.
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


## Tabellenzellen zusammenführen

Führen Sie benachbarte Zellen einer Tabelle zu einer einzigen Zelle zusammen.
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
