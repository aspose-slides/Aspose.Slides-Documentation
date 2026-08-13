---
title: "Lösungsansatz für das Skalieren von Arbeitsblättern"
type: docs
weight: 40
url: /de/net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- Vorschaubild
- Bildskalierung
- Excel
- Arbeitsblatt
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Beheben Sie das OLE‑Skalierungsproblem von Excel‑Arbeitsblättern in Präsentationen: zwei Methoden, um Objektrahmen konsistent zu halten – den Rahmen oder das Blatt skalieren – in den PPT‑ und PPTX‑Formaten."
---
{{% alert color="info" %}}

Es wurde beobachtet, dass Excel‑Arbeitsblätter, die als OLE‑Objekte in einer PowerPoint‑Präsentation über Aspose‑Komponenten eingebettet sind, nach der ersten Aktivierung auf eine nicht eindeutig bestimmte Skalierung geändert werden. Dieses Verhalten erzeugt einen deutlich sichtbaren visuellen Unterschied in der Präsentation zwischen dem Zustand des OLE‑Objekts vor und nach der Aktivierung. Wir haben dieses Problem im Detail untersucht und eine Lösung bereitgestellt, die in diesem Artikel behandelt wird.

{{% /alert %}}

## **Hintergrund**

Im Artikel [Manage OLE](/slides/de/net/manage-ole/) haben wir erklärt, wie man mit Aspose.Slides für .NET einen OLE‑Rahmen zu einer PowerPoint‑Präsentation hinzufügt.  
Um das [object preview issue](/slides/de/net/object-preview-issue-when-adding-oleobjectframe/) zu beheben, haben wir dem OLE‑Objekt‑Rahmen ein Bild des ausgewählten Arbeitsblattbereichs zugewiesen.  
In der resultierenden Präsentation wird beim Doppelklick auf den OLE‑Objekt‑Rahmen, der das Arbeitsblatt‑Bild anzeigt, die Excel‑Arbeitsmappe aktiviert.  
Endbenutzer können beliebige Änderungen an der tatsächlichen Excel‑Arbeitsmappe vornehmen und anschließend zur Folie zurückkehren, indem sie außerhalb der aktivierten Excel‑Arbeitsmappe klicken.  
Die Größe des OLE‑Objekt‑Rahmens ändert sich, wenn der Benutzer zur Folie zurückkehrt.  
Der Skalierungsfaktor variiert je nach Größe des OLE‑Objekt‑Rahmens und der eingebetteten Excel‑Arbeitsmappe.

## **Ursache der Skalierung**

Da die Excel‑Arbeitsmappe über eine eigene Fenstergröße verfügt, versucht sie, bei der ersten Aktivierung ihre ursprüngliche Größe beizubehalten.  
Andererseits hat der OLE‑Objekt‑Rahmen eine eigene Größe.  
Laut Microsoft verhandeln Excel und PowerPoint bei der Aktivierung der Excel‑Arbeitsmappe die Größe, um sicherzustellen, dass die korrekten Proportionen im Rahmen des Einbettungsprozesses beibehalten werden.  
Die Skalierung erfolgt basierend auf den Unterschieden zwischen der Excel‑Fenstergröße und der Größe sowie Position des OLE‑Objekt‑Rahmens.

## **Lösungsansatz**

Es gibt zwei mögliche Lösungen, um den Skalierungseffekt zu vermeiden.

- Skalieren Sie die Größe des OLE‑Rahmens in der PowerPoint‑Präsentation, sodass sie der Höhe und Breite der gewünschten Anzahl von Zeilen und Spalten im OLE‑Rahmen entspricht.  
- Lassen Sie die Größe des OLE‑Rahmens konstant und skalieren Sie die Größe der beteiligten Zeilen und Spalten, um in die ausgewählte OLE‑Rahmengröße zu passen.

### **Skalieren der OLE‑Rahmengröße**

In diesem Ansatz lernen wir, wie man die OLE‑Rahmengröße der eingebetteten Excel‑Arbeitsmappe so einstellt, dass sie der kumulativen Größe der beteiligten Zeilen und Spalten im Excel‑Arbeitsblatt entspricht.  
Angenommen, wir haben ein Excel‑Vorlagenblatt und möchten es als OLE‑Rahmen zu einer Präsentation hinzufügen.  
In diesem Szenario wird die Größe des OLE‑Objekt‑Rahmens zunächst basierend auf den kumulierten Zeilenhöhen und Spaltenbreiten der beteiligten Zeilen und Spalten in der Arbeitsmappe berechnet.  
Anschließend setzen wir die Größe des OLE‑Rahmens auf diesen berechneten Wert.  
Um die rote Meldung „EMBEDDED OLE OBJECT“ für den OLE‑Rahmen in PowerPoint zu vermeiden, erfassen wir außerdem ein Bild der gewünschten Abschnitte der Zeilen und Spalten in der Arbeitsmappe und setzen es als OLE‑Rahmen‑Bild.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// Legen Sie die angezeigte Größe fest, wenn die Arbeitsmappendatei als OLE‑Objekt in PowerPoint verwendet wird.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
var imageStream = CreateOleImage(cellRange, imageResolution);

// Ermitteln Sie die Breite und Höhe des OLE‑Bildes in Punkten.
using var image = Image.FromStream(imageStream);
var imageWidth = image.Width * 72 / imageResolution;
var imageHeight = image.Height * 72 / imageResolution;

// Wir müssen die modifizierte Arbeitsmappe verwenden.
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// Fügen Sie das OLE‑Bild zu den Präsentationsressourcen hinzu.
imageStream.Seek(0, SeekOrigin.Begin);
var oleImage = presentation.Images.AddImage(imageStream);

// Erstellen Sie den OLE‑Objekt‑Rahmen.
var dataInfo = new OleEmbeddedDataInfo(oleStream.ToArray(), "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

```cs
static MemoryStream CreateOleImage(Aspose.Cells.Range cellRange, int imageResolution)
{
    var pageSetup = cellRange.Worksheet.PageSetup;
    pageSetup.PrintArea = cellRange.Address;
    pageSetup.LeftMargin = 0;
    pageSetup.RightMargin = 0;
    pageSetup.TopMargin = 0;
    pageSetup.BottomMargin = 0;
    pageSetup.ClearHeaderFooter();

    var imageOptions = new Aspose.Cells.Rendering.ImageOrPrintOptions
    {
        ImageType = Aspose.Cells.Drawing.ImageType.Png,
        VerticalResolution = imageResolution,
        HorizontalResolution = imageResolution,
        OnePagePerSheet = true,
        OnlyArea = true
    };

    var sheetRender = new Aspose.Cells.Rendering.SheetRender(cellRange.Worksheet, imageOptions);
    var imageStream = new MemoryStream();

    sheetRender.ToImage(0, imageStream);
    imageStream.Seek(0, SeekOrigin.Begin);

    return imageStream;
}
```

### **Skalieren der Zellbereichsgröße**

In diesem Ansatz lernen wir, wie man die Höhen der beteiligten Zeilen und die Breite der beteiligten Spalten skaliert, um eine benutzerdefinierte OLE‑Rahmengröße zu erreichen.  
Angenommen, wir haben ein Excel‑Vorlagenblatt und möchten es als OLE‑Rahmen zu einer Präsentation hinzufügen.  
In diesem Szenario setzen wir die Größe des OLE‑Rahmens und skalieren die Größe der Zeilen und Spalten, die im OLE‑Rahmenbereich beteiligt sind.  
Anschließend speichern wir die Arbeitsmappe in einen Stream, um die Änderungen anzuwenden, und konvertieren sie in ein Byte‑Array, um sie dem OLE‑Rahmen hinzuzufügen.  
Um die rote Meldung „EMBEDDED OLE OBJECT“ für den OLE‑Rahmen in PowerPoint zu vermeiden, erfassen wir außerdem ein Bild der gewünschten Abschnitte der Zeilen und Spalten in der Arbeitsmappe und setzen es als OLE‑Rahmen‑Bild.

```cs
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// Legen Sie die angezeigte Größe fest, wenn die Arbeitsmappendatei als OLE-Objekt in PowerPoint verwendet wird.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

// Skalieren Sie den Zellbereich, um die Rahmengröße anzupassen.
var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

var imageStream = CreateOleImage(cellRange, imageResolution);

// Wir müssen die modifizierte Arbeitsmappe verwenden.
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// Fügen Sie das OLE-Bild zu den Präsentations-Ressourcen hinzu.
var oleImage = presentation.Images.AddImage(imageStream);

// Erzeugen Sie den OLE-Objekt-Rahmen.
var dataInfo = new OleEmbeddedDataInfo(oleStream.ToArray(), "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

```cs
/// <param name="width">Die erwartete Breite des Zellbereichs in Punkten.</param>
/// <param name="height">Die erwartete Höhe des Zellbereichs in Punkten.</param>
static void ScaleCellRange(Aspose.Cells.Range cellRange, float width, float height)
{
    var rangeWidth = cellRange.Width;
    var rangeHeight = cellRange.Height;

    for (int i = 0; i < cellRange.ColumnCount; i++)
    {
        var columnIndex = cellRange.FirstColumn + i;
        var columnWidth = cellRange.Worksheet.Cells.GetColumnWidth(columnIndex, false, Aspose.Cells.CellsUnitType.Point);

        var newColumnWidth = columnWidth * width / rangeWidth;
        var widthInInches = newColumnWidth / 72;
        cellRange.Worksheet.Cells.SetColumnWidthInch(columnIndex, widthInInches);
    }

    for (int i = 0; i < cellRange.RowCount; i++)
    {
        var rowIndex = cellRange.FirstRow + i;
        var rowHeight = cellRange.Worksheet.Cells.GetRowHeight(rowIndex, false, Aspose.Cells.CellsUnitType.Point);

        var newRowHeight = rowHeight * height / rangeHeight;
        var heightInInches = newRowHeight / 72;
        cellRange.Worksheet.Cells.SetRowHeightInch(rowIndex, heightInInches);
    }
}
```

```cs
static Stream CreateOleImage(Aspose.Cells.Range cellRange, int imageResolution)
{
    var pageSetup = cellRange.Worksheet.PageSetup;
    pageSetup.PrintArea = cellRange.Address;
    pageSetup.LeftMargin = 0;
    pageSetup.RightMargin = 0;
    pageSetup.TopMargin = 0;
    pageSetup.BottomMargin = 0;
    pageSetup.ClearHeaderFooter();

    var imageOptions = new Aspose.Cells.Rendering.ImageOrPrintOptions
    {
        ImageType = Aspose.Cells.Drawing.ImageType.Png,
        VerticalResolution = imageResolution,
        HorizontalResolution = imageResolution,
        OnePagePerSheet = true,
        OnlyArea = true
    };

    var sheetRender = new Aspose.Cells.Rendering.SheetRender(cellRange.Worksheet, imageOptions);
    var imageStream = new MemoryStream();

    sheetRender.ToImage(0, imageStream);
    imageStream.Seek(0, SeekOrigin.Begin);

    return imageStream;
}
```

## **Fazit**

{{% alert color="info" %}}

Es gibt zwei Ansatzmöglichkeiten, um das Skalierungsproblem des Arbeitsblatts zu beheben. Die Wahl des geeigneten Ansatzes hängt von den konkreten Anforderungen und dem Anwendungsfall ab. Beide Ansätze funktionieren identisch, unabhängig davon, ob die Präsentationen aus einer Vorlage oder von Grund auf erstellt werden. Darüber hinaus gibt es in dieser Lösung keine Begrenzung der Größe des OLE‑Objekt‑Rahmens.

{{% /alert %}}

## **FAQ**

### Warum ändert ein eingebettetes Excel‑Arbeitsblatt seine Größe, wenn es in PowerPoint zum ersten Mal aktiviert wird?

Dies geschieht, weil Excel versucht, bei der Aktivierung die ursprüngliche Fenstergröße beizubehalten, während der OLE‑Objekt‑Rahmen in PowerPoint eigene Abmessungen hat. PowerPoint und Excel verhandeln die Größe, um das Seitenverhältnis zu wahren, was zu einer Skalierung führen kann.

### Ist es möglich, dieses Skalierungsproblem vollständig zu verhindern?

Ja. Durch das Skalieren des OLE‑Rahmens, um die Größe des Excel‑Zellbereichs anzupassen, oder durch das Skalieren des Zellbereichs, um die gewünschte OLE‑Rahmengröße zu erreichen, lässt sich ein unerwünschtes Skalieren verhindern.

### Welche Skalierungsmethode sollte ich verwenden, OLE‑Rahmen‑Skalierung oder Zellbereich‑Skalierung?

Wählen Sie **OLE frame scaling**, wenn Sie die ursprünglichen Excel‑Zeilen‑ und Spaltengrößen beibehalten möchten. Wählen Sie **cell range scaling**, wenn Sie eine feste Größe für den OLE‑Rahmen in Ihrer Präsentation wünschen.

### Funktionieren diese Lösungen, wenn meine Präsentation auf einer Vorlage basiert?

Ja. Beide Lösungen funktionieren für Präsentationen, die aus Vorlagen oder von Grund auf erstellt wurden.

### Gibt es eine Begrenzung der Größe des OLE‑Rahmens bei Verwendung dieser Methoden?

Nein. Der OLE‑Objekt‑Rahmen kann beliebig groß sein, solange die Skalierung korrekt eingestellt wird.

### Gibt es eine Möglichkeit, den Platzhaltertext „EMBEDDED OLE OBJECT“ in PowerPoint zu vermeiden?

Ja. Durch das Erstellen einer Momentaufnahme des gewünschten Excel‑Zellbereichs und das Festlegen als Platzhalter‑Bild des OLE‑Rahmens kann ein benutzerdefiniertes Vorschaubild anstelle des Standard‑Platzhalters angezeigt werden.

## **Verwandte Artikel**

[Erstellen eines Excel‑Diagramms und Einbetten in eine Präsentation als OLE‑Objekt](/slides/de/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Automatisches Aktualisieren von OLE‑Objekten mithilfe eines MS PowerPoint‑Add‑Ins](/slides/de/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)