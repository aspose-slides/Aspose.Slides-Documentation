---
title: Zellen verwalten
type: docs
weight: 30
url: /de/net/manage-cells/
keywords:
- Tabelle
- zusammengeführte Zellen
- geteilte Zellen
- Bild in Tabellenzelle
- C#
- Csharp
- Aspose.Slides für .NET
description: "Tabellenzellen in PowerPoint-Präsentationen in C# oder .NET"
---

## **Zusammengeführte Tabellenzelle identifizieren**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
2. Holen Sie die Tabelle von der ersten Folie. 
3. Durchlaufen Sie die Zeilen und Spalten der Tabelle, um zusammengeführte Zellen zu finden.
4. Geben Sie eine Nachricht aus, wenn zusammengeführte Zellen gefunden werden.

Dieser C#-Code zeigt Ihnen, wie Sie zusammengeführte Tabellenzellen in einer Präsentation identifizieren:

```c#
using (Presentation pres = new Presentation("SomePresentationWithTable.pptx"))
{
    ITable table = pres.Slides[0].Shapes[0] as ITable; // vorausgesetzt, dass Slide#0.Shape#0 eine Tabelle ist
    for (int i = 0; i < table.Rows.Count; i++)
    {
        for (int j = 0; j < table.Columns.Count; j++)
        {
            ICell currentCell = table.Rows[i][j];
            if (currentCell.IsMergedCell)
            {
                Console.WriteLine(string.Format("Zelle {0};{1} ist Teil einer zusammengeführten Zelle mit RowSpan={2} und ColSpan={3}, die von Zelle {4};{5} ausgeht.",
                                  i, j, currentCell.RowSpan, currentCell.ColSpan, currentCell.FirstRowIndex, currentCell.FirstColumnIndex));
            }
        }
    }
}
```

## **Rand der Tabellenzellen entfernen**
1. Erstellen Sie eine Instanz der `Presentation`-Klasse.
2. Holen Sie sich den Verweis auf eine Folie über ihren Index. 
3. Definieren Sie ein Array von Spalten mit Breite.
4. Definieren Sie ein Array von Zeilen mit Höhe.
5. Fügen Sie der Folie über die Methode `AddTable` eine Tabelle hinzu.
6. Durchlaufen Sie jede Zelle, um die oberen, unteren, rechten und linken Ränder zu löschen.
7. Speichern Sie die modifizierte Präsentation als PPTX-Datei.

Dieser C#-Code zeigt Ihnen, wie Sie die Ränder von Tabellenzellen entfernen:

```c#
// Instanziiert die Presentation-Klasse, die eine PPTX-Datei darstellt
using (Presentation pres = new Presentation())
{
   // Greift auf die erste Folie zu
    Slide sld = (Slide)pres.Slides[0];

    // Definiert Spalten mit Breiten und Zeilen mit Höhen
    double[] dblCols = { 50, 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Fügt der Folie eine Tabellenform hinzu
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Setzt das Randformat für jede Zelle
    foreach (IRow row in tbl.Rows)
        foreach (ICell cell in row)
        {
            cell.CellFormat.BorderTop.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderRight.FillFormat.FillType = FillType.NoFill;
        }

    // Schreibt die PPTX-Datei auf die Festplatte
    pres.Save("table_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Nummerierung in zusammengeführten Zellen**
Wenn wir 2 Paare von Zellen (1, 1) x (2, 1) und (1, 2) x (2, 2) zusammenführen, wird die resultierende Tabelle nummeriert. Dieser C#-Code demonstriert den Prozess:

```c#
// Instanziiert die Presentation-Klasse, die eine PPTX-Datei darstellt
using (Presentation presentation = new Presentation())
{
    // Greift auf die erste Folie zu
    ISlide sld = presentation.Slides[0];

    // Definiert Spalten mit Breiten und Zeilen mit Höhen
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Fügt der Folie eine Tabellenform hinzu
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Setzt das Randformat für jede Zelle
    foreach (IRow row in tbl.Rows)
    {
        foreach (ICell cell in row)
        {
            cell.CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderTop.Width = 5;

            cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderBottom.Width = 5;

            cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderLeft.Width = 5;

            cell.CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderRight.Width = 5;
        }
    }

    // Führt Zellen (1, 1) x (2, 1) zusammen
    tbl.MergeCells(tbl[1, 1], tbl[2, 1], false);

    // Führt Zellen (1, 2) x (2, 2) zusammen
    tbl.MergeCells(tbl[1, 2], tbl[2, 2], false);

    presentation.Save("MergeCells_out.pptx", SaveFormat.Pptx);
}
```

Wir führen dann die Zellen weiter zusammen, indem wir (1, 1) und (1, 2) zusammenführen. Das Ergebnis ist eine Tabelle mit einer großen zusammengeführten Zelle in der Mitte:

```c#
// Instanziiert die Presentation-Klasse, die eine PPTX-Datei darstellt
using (Presentation presentation = new Presentation())
{
    // Greift auf die erste Folie zu
    ISlide slide = presentation.Slides[0];

    // Definiert Spalten mit Breiten und Zeilen mit Höhen
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Fügt der Folie eine Tabellenform hinzu
    ITable table = slide.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Setzt das Randformat für jede Zelle
    foreach (IRow row in table.Rows)
    {
        foreach (ICell cell in row)
        {
            cell.CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderTop.Width = 5;

            cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderBottom.Width = 5;

            cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderLeft.Width = 5;

            cell.CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderRight.Width = 5;
        }
    }

    // Führt Zellen (1, 1) x (2, 1) zusammen
    table.MergeCells(table[1, 1], table[2, 1], false);

    // Führt Zellen (1, 2) x (2, 2) zusammen
    table.MergeCells(table[1, 2], table[2, 2], false);

    // Führt Zellen (1, 2) x (2, 2) zusammen
    table.MergeCells(table[1, 1], table[1, 2], true);

    // Schreibt die PPTX-Datei auf die Festplatte
    presentation.Save("MergeCells1_out.pptx", SaveFormat.Pptx);
}
```

## **Nummerierung in geteilten Zellen**
In den vorherigen Beispielen änderte sich die Nummerierung oder das Nummerierungssystem in anderen Zellen nicht, als Tabellenzellen zusammengeführt wurden. 

Dieses Mal nehmen wir eine reguläre Tabelle (eine Tabelle ohne zusammengeführte Zellen) und versuchen dann, die Zelle (1,1) zu teilen, um eine besondere Tabelle zu erhalten. Sie sollten auf die Nummerierung dieser Tabelle achten, die als seltsam angesehen werden kann. Dennoch ist das der Weg, wie Microsoft PowerPoint Tabellenzellen nummeriert, und Aspose.Slides macht es ebenso. 

Dieser C#-Code demonstriert den beschriebenen Prozess:

```c#
// Instanziiert die Presentation-Klasse, die eine PPTX-Datei darstellt
using (Presentation presentation = new Presentation())
{
    // Greift auf die erste Folie zu
    ISlide slide = presentation.Slides[0];

    // Definiert Spalten mit Breiten und Zeilen mit Höhen
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Fügt der Folie eine Tabellenform hinzu
    ITable table = slide.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Setzt das Randformat für jede Zelle
    foreach (IRow row in table.Rows)
    {
        foreach (ICell cell in row)
        {
            cell.CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderTop.Width = 5;

            cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderBottom.Width = 5;

            cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderLeft.Width = 5;

            cell.CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderRight.Width = 5;
        }
    }

    // Führt Zellen (1, 1) x (2, 1) zusammen
    table.MergeCells(table[1, 1], table[2, 1], false);

    // Führt Zellen (1, 2) x (2, 2) zusammen
    table.MergeCells(table[1, 2], table[2, 2], false);

    // Teilt die Zelle (1, 1). 
    table[1, 1].SplitByWidth(table[2, 1].Width / 2);

    // Schreibt die PPTX-Datei auf die Festplatte
    presentation.Save("CellSplit_out.pptx", SaveFormat.Pptx);
}
```

## **Hintergrundfarbe der Tabellenzelle ändern**

Dieser C#-Code zeigt Ihnen, wie Sie die Hintergrundfarbe einer Tabellenzelle ändern:

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 50, 50, 50, 50, 50 };

    // Erstellen Sie eine neue Tabelle
    ITable table = slide.Shapes.AddTable(50, 50, dblCols, dblRows);

    // Setzen Sie die Hintergrundfarbe für eine Zelle 
    ICell cell = table[2, 3];
    cell.CellFormat.FillFormat.FillType = FillType.Solid;
    cell.CellFormat.FillFormat.SolidFillColor.Color = Color.Red;

    presentation.Save("cell_background_color.pptx", SaveFormat.Pptx);
}
```

## **Bild innerhalb einer Tabellenzelle hinzufügen**

1. Erstellen Sie eine Instanz der `Presentation`-Klasse.
2. Holen Sie sich den Verweis auf eine Folie über ihren Index.
3. Definieren Sie ein Array von Spalten mit Breite.
4. Definieren Sie ein Array von Zeilen mit Höhe.
5. Fügen Sie der Folie über die Methode `AddTable` eine Tabelle hinzu. 
6. Erstellen Sie ein `Bitmap`-Objekt, um die Bilddatei zu halten.
7. Fügen Sie das Bitmap-Bild zum `IPPImage`-Objekt hinzu.
8. Setzen Sie das `FillFormat` für die Tabellenzelle auf `Picture`.
9. Fügen Sie das Bild zur ersten Zelle der Tabelle hinzu.
10. Speichern Sie die modifizierte Präsentation als PPTX-Datei.

Dieser C#-Code zeigt Ihnen, wie Sie ein Bild in einer Tabellenzelle platzieren, wenn Sie eine Tabelle erstellen:

```c#
// Instanziiert die Presentation-Klasse, die eine PPTX-Datei darstellt
using (Presentation presentation = new Presentation())
{
    // Greift auf die erste Folie zu
    ISlide slide = presentation.Slides[0];

    // Definiert Spalten mit Breiten und Zeilen mit Höhen
    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 100, 100, 100, 100, 90 };

    // Fügt der Folie eine Tabellenform hinzu
    ITable table = slide.Shapes.AddTable(50, 50, dblCols, dblRows);

    // Lädt ein Bild aus einer Datei und fügt es zu den Präsentationsressourcen hinzu
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Fügt das Bild zur ersten Tabellenzelle hinzu
    table[0, 0].CellFormat.FillFormat.FillType = FillType.Picture;
    table[0, 0].CellFormat.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
    table[0, 0].CellFormat.FillFormat.PictureFillFormat.Picture.Image = ppImage;

    // Speichert die PPTX-Datei auf der Festplatte
    presentation.Save("Image_In_TableCell_out.pptx", SaveFormat.Pptx);
}
```