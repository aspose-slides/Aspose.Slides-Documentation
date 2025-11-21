---
title: Tabellenzellen in Präsentationen in .NET verwalten
linktitle: Zellen verwalten
type: docs
weight: 30
url: /de/net/manage-cells/
keywords:
- Tabellenzelle
- Zellen zusammenführen
- Rahmen entfernen
- Zelle teilen
- Bild in Zelle
- Hintergrundfarbe
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Verwalten Sie Tabellenzellen in PowerPoint mühelos mit Aspose.Slides für .NET. Beherrschen Sie das schnelle Zugreifen, Ändern und Gestalten von Zellen für eine nahtlose Folienautomatisierung."
---

## **Zusammengeführte Tabellenzelle identifizieren**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.  
2. Holen Sie die Tabelle von der ersten Folie.  
3. Durchlaufen Sie die Zeilen und Spalten der Tabelle, um zusammengeführte Zellen zu finden.  
4. Geben Sie eine Meldung aus, wenn zusammengeführte Zellen gefunden werden.  

Dieser C#-Code zeigt Ihnen, wie Sie zusammengeführte Tabellenzellen in einer Präsentation identifizieren:
```c#
using (Presentation pres = new Presentation("SomePresentationWithTable.pptx"))
{
    ITable table = pres.Slides[0].Shapes[0] as ITable; // Annahme: Slide#0.Shape#0 ist eine Tabelle
    for (int i = 0; i < table.Rows.Count; i++)
    {
        for (int j = 0; j < table.Columns.Count; j++)
        {
            ICell currentCell = table.Rows[i][j];
            if (currentCell.IsMergedCell)
            {
                Console.WriteLine(string.Format("Cell {0};{1} is a part of merged cell with RowSpan={2} and ColSpan={3} starting from Cell {4};{5}.",
                                  i, j, currentCell.RowSpan, currentCell.ColSpan, currentCell.FirstRowIndex, currentCell.FirstColumnIndex));


            }
        }
    }
}
```


## **Tabellenzellenrahmen entfernen**

1. Erstellen Sie eine Instanz der `Presentation`-Klasse.  
2. Holen Sie die Referenz einer Folie über ihren Index.  
3. Definieren Sie ein Array von Spalten mit Breite.  
4. Definieren Sie ein Array von Zeilen mit Höhe.  
5. Fügen Sie der Folie über die `AddTable`-Methode eine Tabelle hinzu.  
6. Durchlaufen Sie jede Zelle, um die oberen, unteren, rechten und linken Rahmen zu entfernen.  
7. Speichern Sie die geänderte Präsentation als PPTX-Datei.  

Dieser C#-Code zeigt Ihnen, wie Sie die Rahmen von Tabellenzellen entfernen:
```c#
// Instanziiert die Presentation-Klasse, die eine PPTX-Datei darstellt
using (Presentation pres = new Presentation())
{
   // Greift auf die erste Folie zu
    Slide sld = (Slide)pres.Slides[0];

    // Definiert Spalten mit Breiten und Zeilen mit Höhen
    double[] dblCols = { 50, 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Fügt der Folie ein Tabellenshape hinzu
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Setzt das Rahmenformat für jede Zelle
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

Wenn wir 2 Zellpaare (1, 1) × (2, 1) und (1, 2) × (2, 2) zusammenführen, wird die resultierende Tabelle nummeriert. Dieser C#-Code demonstriert den Vorgang:
```c#
// Instanziiert die Presentation-Klasse, die eine PPTX-Datei darstellt
using (Presentation presentation = new Presentation())
{
    // Greift auf die erste Folie zu
    ISlide sld = presentation.Slides[0];

    // Definiert Spalten mit Breiten und Zeilen mit Höhen
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Fügt der Folie ein Tabellenshape hinzu
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Setzt das Rahmenformat für jede Zelle
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


Wir führen dann die Zellen weiter zusammen, indem wir (1, 1) und (1, 2) zusammenführen. Das Ergebnis ist eine Tabelle mit einer großen zusammengeführten Zelle in ihrer Mitte:
```c#
// Instanziiert die Presentation-Klasse, die eine PPTX-Datei darstellt
using (Presentation presentation = new Presentation())
{
    // Greift auf die erste Folie zu
    ISlide slide = presentation.Slides[0];

    // Definiert Spalten mit Breiten und Zeilen mit Höhen
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Fügt der Folie ein Tabellenshape hinzu
    ITable table = slide.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Setzt das Rahmenformat für jede Zelle
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

In vorherigen Beispielen änderte sich die Numerierung oder das Nummerierungssystem in anderen Zellen nicht, wenn Tabellenzellen zusammengeführt wurden.

Dieses Mal nehmen wir eine reguläre Tabelle (eine Tabelle ohne zusammengeführte Zellen) und versuchen dann, Zelle (1,1) zu teilen, um eine besondere Tabelle zu erhalten. Sie sollten auf die Nummerierung dieser Tabelle achten, die möglicherweise ungewöhnlich erscheint. Das ist jedoch die Art und Weise, wie Microsoft PowerPoint Tabellenzellen nummeriert, und Aspose.Slides verhält sich genauso.

Dieser C#-Code demonstriert den beschriebenen Vorgang:
```c#
// Instanziert die Presentation-Klasse, die eine PPTX-Datei darstellt
using (Presentation presentation = new Presentation())
{
    // Greift auf die erste Folie zu
    ISlide slide = presentation.Slides[0];

    // Definiert Spalten mit Breiten und Zeilen mit Höhen
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Fügt der Folie ein Tabellenshape hinzu
    ITable table = slide.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Setzt das Rahmenformat für jede Zelle
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

    // Teilt Zelle (1, 1).
    table[1, 1].SplitByWidth(table[2, 1].Width / 2);

    // Schreibt die PPTX-Datei auf die Festplatte
    presentation.Save("CellSplit_out.pptx", SaveFormat.Pptx);
}
```


## **Tabellenzellen-Hintergrundfarbe ändern**

Dieser C#-Code zeigt Ihnen, wie Sie die Hintergrundfarbe einer Tabellenzelle ändern:
```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 50, 50, 50, 50, 50 };

    // erstelle eine neue Tabelle
    ITable table = slide.Shapes.AddTable(50, 50, dblCols, dblRows);

    // setze die Hintergrundfarbe für eine Zelle
    ICell cell = table[2, 3];
    cell.CellFormat.FillFormat.FillType = FillType.Solid;
    cell.CellFormat.FillFormat.SolidFillColor.Color = Color.Red;

    presentation.Save("cell_background_color.pptx", SaveFormat.Pptx);
}
```


## **Bild in Tabellenzelle einfügen**

1. Erstellen Sie eine Instanz der `Presentation`-Klasse.  
2. Holen Sie die Referenz einer Folie über deren Index.  
3. Definieren Sie ein Array von Spalten mit Breite.  
4. Definieren Sie ein Array von Zeilen mit Höhe.  
5. Fügen Sie der Folie über die `AddTable`-Methode eine Tabelle hinzu.  
6. Erstellen Sie ein `Bitmap`-Objekt, um die Bilddatei zu halten.  
7. Fügen Sie das Bitmap-Bild dem `IPPImage`-Objekt hinzu.  
8. Setzen Sie das `FillFormat` der Tabellenzelle auf `Picture`.  
9. Fügen Sie das Bild der ersten Zelle der Tabelle hinzu.  
10. Speichern Sie die geänderte Präsentation als PPTX-Datei.  

Dieser C#-Code zeigt Ihnen, wie Sie beim Erstellen einer Tabelle ein Bild in einer Tabellenzelle platzieren:
```c#
// Instanziert die Presentation-Klasse, die eine PPTX-Datei darstellt
using (Presentation presentation = new Presentation())
{
    // Greift auf die erste Folie zu
    ISlide slide = presentation.Slides[0];

    // Definiert Spalten mit Breiten und Zeilen mit Höhen
    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 100, 100, 100, 100, 90 };

    // Fügt der Folie ein Tabellenshape hinzu
    ITable table = slide.Shapes.AddTable(50, 50, dblCols, dblRows);

    // Lädt ein Bild aus einer Datei und fügt es den Präsentationsressourcen hinzu
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Fügt das Bild der ersten Tabellenzelle hinzu
    table[0, 0].CellFormat.FillFormat.FillType = FillType.Picture;
    table[0, 0].CellFormat.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
    table[0, 0].CellFormat.FillFormat.PictureFillFormat.Picture.Image = ppImage;

    // Speichert die PPTX-Datei auf der Festplatte
    presentation.Save("Image_In_TableCell_out.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Kann ich für die einzelnen Seiten einer Zelle unterschiedliche Linienstärken und -stile festlegen?**

Ja. Die [oben](https://reference.aspose.com/slides/net/aspose.slides/cellformat/bordertop/)/[unten](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderbottom/)/[links](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderleft/)/[rechts](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderright/)-Ränder besitzen separate Eigenschaften, sodass die Dicke und der Stil jeder Seite unterschiedlich sein können. Das folgt logisch aus der pro‑Seiten‑Rand‑Steuerung für eine Zelle, die im Artikel demonstriert wird.

**Was passiert mit dem Bild, wenn ich die Spalten-/Zeilengröße ändere, nachdem ich ein Bild als Hintergrund der Zelle festgelegt habe?**

Das Verhalten hängt vom [Füllmodus](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) (Strecken/Kacheln) ab. Beim Strecken passt sich das Bild der neuen Zelle an; beim Kacheln werden die Kacheln neu berechnet. Der Artikel erwähnt die Bildanzeigemodi in einer Zelle.

**Kann ich einem Zellinhalt einen Hyperlink zuweisen?**

[Hyperlinks](/slides/de/net/manage-hyperlinks/) werden auf der Ebene des Textes (Abschnitt) im Textrahmen der Zelle oder auf Ebene der gesamten Tabelle/Form festgelegt. In der Praxis weisen Sie den Link einem Abschnitt oder dem gesamten Text in der Zelle zu.

**Kann ich innerhalb einer einzelnen Zelle verschiedene Schriftarten festlegen?**

Ja. Der Textrahmen einer Zelle unterstützt [Abschnitte](https://reference.aspose.com/slides/net/aspose.slides/portion/) (Runs) mit unabhängiger Formatierung — Schriftfamilie, Stil, Größe und Farbe.