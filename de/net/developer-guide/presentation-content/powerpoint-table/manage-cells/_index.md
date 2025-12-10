---
title: Tabellenzellen in Präsentationen in .NET verwalten
linktitle: Zellen verwalten
type: docs
weight: 30
url: /de/net/manage-cells/
keywords:
- Tabellenzelle
- Zellen zusammenführen
- Rand entfernen
- Zelle teilen
- Bild in Zelle
- Hintergrundfarbe
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Verwalten Sie mühelos Tabellenzellen in PowerPoint mit Aspose.Slides für .NET. Beherrschen Sie den schnellen Zugriff, die Modifikation und das Styling von Zellen für nahtlose Folienautomatisierung."
---

## **Zusammengeführte Tabellenzelle identifizieren**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.  
2. Holen Sie die Tabelle von der ersten Folie.  
3. Iterieren Sie durch die Zeilen und Spalten der Tabelle, um zusammengeführte Zellen zu finden.  
4. Geben Sie eine Meldung aus, wenn zusammengeführte Zellen gefunden werden.

Dieser C#‑Code zeigt, wie Sie zusammengeführte Tabellenzellen in einer Präsentation identifizieren können:
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


## **Tabellenzellenränder entfernen**
1. Erstellen Sie eine Instanz der `Presentation`‑Klasse.  
2. Holen Sie die Referenz einer Folie über ihren Index.  
3. Definieren Sie ein Array von Spalten mit Breite.  
4. Definieren Sie ein Array von Zeilen mit Höhe.  
5. Fügen Sie der Folie über die Methode `AddTable` eine Tabelle hinzu.  
6. Iterieren Sie durch jede Zelle, um die oberen, unteren, rechten und linken Ränder zu entfernen.  
7. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser C#‑Code zeigt, wie Sie die Ränder von Tabellenzellen entfernen:
```c#
// Instanziiert die Presentation-Klasse, die eine PPTX-Datei darstellt
using (Presentation pres = new Presentation())
{
   // Greift auf die erste Folie zu
    Slide sld = (Slide)pres.Slides[0];

    // Definiert Spalten mit Breiten und Zeilen mit Höhen
    double[] dblCols = { 50, 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Fügt der Folie ein Tabellenelement hinzu
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Legt das Randformat für jede Zelle fest
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
Wenn wir zwei Zellpaare (1, 1) × (2, 1) und (1, 2) × (2, 2) zusammenführen, wird die resultierende Tabelle nummeriert. Dieser C#‑Code demonstriert den Vorgang:
```c#
// Instanziiert die Presentation-Klasse, die eine PPTX-Datei darstellt
using (Presentation presentation = new Presentation())
{
    // Greift auf die erste Folie zu
    ISlide sld = presentation.Slides[0];

    // Definiert Spalten mit Breiten und Zeilen mit Höhen
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Fügt der Folie ein Tabellenelement hinzu
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Legt das Randformat für jede Zelle fest
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

    // Führt die Zellen (1, 1) x (2, 1) zusammen
    tbl.MergeCells(tbl[1, 1], tbl[2, 1], false);

    // Führt die Zellen (1, 2) x (2, 2) zusammen
    tbl.MergeCells(tbl[1, 2], tbl[2, 2], false);

    presentation.Save("MergeCells_out.pptx", SaveFormat.Pptx);
}
```


Wir führen anschließend die Zellen weiter zusammen, indem wir (1, 1) und (1, 2) zusammenführen. Das Ergebnis ist eine Tabelle mit einer großen zusammengeführten Zelle in der Mitte:
```c#
// Instanziert die Presentation‑Klasse, die eine PPTX‑Datei darstellt
using (Presentation presentation = new Presentation())
{
    // Greift auf die erste Folie zu
    ISlide slide = presentation.Slides[0];

    // Definiert Spalten mit Breiten und Zeilen mit Höhen
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Fügt der Folie ein Tabellenelement hinzu
    ITable table = slide.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Legt das Randformat für jede Zelle fest
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

    // Führt die Zellen (1, 1) x (2, 1) zusammen
    table.MergeCells(table[1, 1], table[2, 1], false);

    // Führt die Zellen (1, 2) x (2, 2) zusammen
    table.MergeCells(table[1, 2], table[2, 2], false);

    // Führt die Zellen (1, 1) x (1, 2) zusammen
    table.MergeCells(table[1, 1], table[1, 2], true);

    // Schreibt die PPTX‑Datei auf die Festplatte
    presentation.Save("MergeCells1_out.pptx", SaveFormat.Pptx);
}
```


## **Nummerierung in einer geteilten Zelle**
In früheren Beispielen änderte sich die Numerierung oder das Nummerierungsschema in den anderen Zellen nicht, wenn Tabellenzellen zusammengeführt wurden.  

Dieses Mal nehmen wir eine reguläre Tabelle (eine Tabelle ohne zusammengeführte Zellen) und versuchen, Zelle (1,1) zu teilen, um eine spezielle Tabelle zu erhalten. Achten Sie auf die Numerierung dieser Tabelle, die möglicherweise ungewöhnlich erscheint. Das ist jedoch die Art und Weise, wie Microsoft PowerPoint Tabellenzellen nummeriert, und Aspose.Slides tut dasselbe.  

Dieser C#‑Code demonstriert den beschriebenen Vorgang:
```c#
// Instanziert die Presentation-Klasse, die eine PPTX-Datei darstellt
using (Presentation presentation = new Presentation())
{
    // Greift auf die erste Folie zu
    ISlide slide = presentation.Slides[0];

    // Definiert Spalten mit Breiten und Zeilen mit Höhen
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Fügt der Folie ein Tabellenelement hinzu
    ITable table = slide.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Legt das Randformat für jede Zelle fest
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

    // Führt die Zellen (1, 1) x (2, 1) zusammen
    table.MergeCells(table[1, 1], table[2, 1], false);

    // Führt die Zellen (1, 2) x (2, 2) zusammen
    table.MergeCells(table[1, 2], table[2, 2], false);

    // Teilt die Zelle (1, 1) auf.
    table[1, 1].SplitByWidth(table[2, 1].Width / 2);

    //Schreibt die PPTX-Datei auf die Festplatte
    presentation.Save("CellSplit_out.pptx", SaveFormat.Pptx);
}
```


## **Hintergrundfarbe der Tabellenzelle ändern**

Dieser C#‑Code zeigt, wie Sie die Hintergrundfarbe einer Tabellenzelle ändern:
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


## **Bild in einer Tabellenzelle hinzufügen**

1. Erstellen Sie eine Instanz der `Presentation`‑Klasse.  
2. Holen Sie die Referenz einer Folie über ihren Index.  
3. Definieren Sie ein Array von Spalten mit Breite.  
4. Definieren Sie ein Array von Zeilen mit Höhe.  
5. Fügen Sie der Folie über die Methode `AddTable` eine Tabelle hinzu.  
6. Erstellen Sie ein `Bitmap`‑Objekt, um die Bilddatei zu halten.  
7. Fügen Sie das Bitmap‑Bild dem `IPPImage`‑Objekt hinzu.  
8. Setzen Sie das `FillFormat` der Tabellenzelle auf `Picture`.  
9. Fügen Sie das Bild der ersten Zelle der Tabelle hinzu.  
10. Speichern Sie die geänderte Präsentation als PPTX‑Datei  

Dieser C#‑Code zeigt, wie Sie beim Erstellen einer Tabelle ein Bild in einer Tabellenzelle platzieren:
```c#
// Instanziiert die Presentation-Klasse, die eine PPTX-Datei darstellt
using (Presentation presentation = new Presentation())
{
    // Greift auf die erste Folie zu
    ISlide slide = presentation.Slides[0];

    // Definiert Spalten mit Breiten und Zeilen mit Höhen
    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 100, 100, 100, 100, 90 };

    // Fügt der Folie ein Tabellenelement hinzu
    ITable table = slide.Shapes.AddTable(50, 50, dblCols, dblRows);

    // Ladet ein Bild aus einer Datei und fügt es den Präsentationsressourcen hinzu
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

**Kann ich unterschiedliche Linienstärken und -stile für die verschiedenen Seiten einer einzelnen Zelle festlegen?**

Ja. Die [oben](https://reference.aspose.com/slides/net/aspose.slides/cellformat/bordertop/)/[unten](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderbottom/)/[links](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderleft/)/[rechts](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderright/) Ränder besitzen separate Eigenschaften, sodass die Dicke und der Stil jeder Seite unterschiedlich sein können. Dies ergibt sich logisch aus der im Artikel gezeigten per‑Seite‑Rand‑Steuerung für eine Zelle.

**Was passiert mit dem Bild, wenn ich die Spalten‑/Zeilengröße ändere, nachdem ich ein Bild als Hintergrund der Zelle festgelegt habe?**

Das Verhalten hängt vom [Füllmodus](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) (Dehnen/Kacheln) ab. Beim Dehnen passt sich das Bild an die neue Zelle an; beim Kacheln werden die Kacheln neu berechnet. Der Artikel erwähnt die Bildanzeigemodi in einer Zelle.

**Kann ich einem Zellinhalt einen Hyperlink zuweisen?**

[Hyperlinks](/slides/de/net/manage-hyperlinks/) werden auf Textebene (Portion) innerhalb des Textfelds der Zelle oder auf Ebene der gesamten Tabelle/Form festgelegt. In der Praxis weisen Sie den Link einer Portion oder dem gesamten Text in der Zelle zu.

**Kann ich in einer einzelnen Zelle unterschiedliche Schriftarten festlegen?**

Ja. Das Textfeld einer Zelle unterstützt [Portionen](https://reference.aspose.com/slides/net/aspose.slides/portion/) (Runs) mit unabhängiger Formatierung – Schriftfamilie, Stil, Größe und Farbe.