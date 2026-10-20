---
title: Arbeitslösung für die Größenänderung von Arbeitsblättern
type: docs
weight: 40
url: /de/net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- Vorschau‑Bild
- Bildgrößenänderung
- Excel
- Arbeitsblatt
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Excel‑Arbeitsblatt‑OLE‑Größenänderung in Präsentationen beheben: zwei Möglichkeiten, Objekt‑Frames konsistent zu halten — den Rahmen oder das Blatt skalieren — für PPT‑ und PPTX‑Formate."
---
{{% alert color="info" title="Note" %}}

Excel‑Arbeitsblätter, die als OLE‑Objekte in einer PowerPoint‑Präsentation mithilfe von Aspose‑Komponenten eingebettet sind, können sich nach ihrer ersten Aktivierung unerwartet in der Größe ändern. Dieses Verhalten führt zu einem deutlich sichtbaren Unterschied zwischen dem OLE‑Objekt vor und nach der Aktivierung. Dieser Artikel erklärt das Problem und beschreibt zwei Möglichkeiten, es zu beheben.

{{% /alert %}} 

## **Hintergrund**

In dem Artikel [OLE verwalten](/slides/de/net/manage-ole/) haben wir erklärt, wie man mit Aspose.Slides für .NET einen OLE‑Rahmen zu einer PowerPoint‑Präsentation hinzufügt. Um das [Objektvorschau‑Problem](/slides/de/net/object-preview-issue-when-adding-oleobjectframe/) zu beheben, haben wir dem OLE‑Objekt‑Rahmen ein Bild des ausgewählten Arbeitsblattbereichs zugewiesen. In der Ausgabepäsentation wird beim Doppelklick auf den OLE‑Objekt‑Rahmen, der das Arbeitsblatt‑Bild anzeigt, die Excel‑Arbeitsmappe aktiviert. Endbenutzer können beliebige Änderungen an der eigentlichen Excel‑Arbeitsmappe vornehmen und dann zur Folie zurückkehren, indem sie außerhalb der aktivierten Excel‑Arbeitsmappe klicken. Die Größe des OLE‑Objekt‑Rahmens ändert sich, wenn der Benutzer zur Folie zurückkehrt. Der Vergrößerungs‑ bzw. Verkleinerungsfaktor variiert je nach Größe des OLE‑Objekt‑Rahmens und der eingebetteten Excel‑Arbeitsmappe. 

## **Ursache der Größenänderung**

Da die Excel‑Arbeitsmappe ihr eigenes Fenster hat, versucht sie, beim ersten Aktivieren ihre ursprüngliche Fenstergröße beizubehalten. Der OLE‑Objekt‑Rahmen hat hingegen seine eigene Größe. Laut Microsoft verhandeln Excel und PowerPoint bei der Aktivierung der Arbeitsmappe die Größe, um das korrekte Seitenverhältnis im Einbettungsprozess zu erhalten. Die Größenänderung entsteht durch die Unterschiede zwischen der Excel‑Fenstergröße und der Größe sowie Position des OLE‑Objekt‑Rahmens. 

## **Lösungsansatz**

Es gibt zwei mögliche Lösungen, um den Größenänderungseffekt zu vermeiden.

- Skalieren Sie den OLE‑Rahmen in der PowerPoint‑Präsentation, sodass er der Gesamthöhe und -breite der ausgewählten Zeilen und Spalten entspricht.  
- Halten Sie die Größe des OLE‑Rahmens konstant und skalieren Sie die ausgewählten Zeilen und Spalten, damit sie hineinpassen.  

### **OLE‑Rahmengröße skalieren**

Dieser Ansatz setzt die Größe des OLE‑Rahmens so, dass sie der Gesamthöhe und -breite der ausgewählten Zeilen und Spalten im eingebetteten Excel‑Arbeitsblatt entspricht.

Das Beispiel lädt eine vorhandene Excel‑Arbeitsmappe und wählt die ersten 10 Zeilen und 13 Spalten des ersten Arbeitsblatts anhand von nullbasierten Indizes aus. [WorksheetCollection.SetOleSize](https://reference.aspose.com/cells/net/aspose.cells/worksheetcollection/setolesize/) definiert den angezeigten Bereich. Die Vorschau wird mit 96 DPI gerendert und ihre Pixeldimensionen werden mit 72 Punkten pro Zoll in Punkte umgerechnet. [ShapeCollection.AddOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addoleobjectframe/) bettet die modifizierte Arbeitsmappe in einen Rahmen mit diesen Abmessungen ein. Die Vorschau wird über [OleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe/substitutepictureformat/) zugewiesen, um den Platzhalter „EMBEDDED OLE OBJECT“ in der gespeicherten Präsentation zu ersetzen.

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

// Setze die angezeigte Größe, wenn die Arbeitsmappendatei als OLE-Objekt in PowerPoint verwendet wird.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
var imageStream = CreateOleImage(cellRange, imageResolution);

// Erhalte die Breite und Höhe des OLE-Bildes in Punkten.
using var image = Image.FromStream(imageStream);
var imageWidth = image.Width * 72 / imageResolution;
var imageHeight = image.Height * 72 / imageResolution;

// Wir müssen die modifizierte Arbeitsmappe verwenden.
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// Füge das OLE-Bild zu den Präsentationsressourcen hinzu.
imageStream.Seek(0, SeekOrigin.Begin);
var oleImage = presentation.Images.AddImage(imageStream);

// Erstelle den OLE-Objekt-Rahmen.
var dataInfo = new OleEmbeddedDataInfo(oleStream.ToArray(), "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

Der Vorschau‑Helper setzt [PageSetup.PrintArea](https://reference.aspose.com/cells/net/aspose.cells/pagesetup/printarea/) auf den ausgewählten Bereich und entfernt Ränder, Kopf‑ und Fußzeilen. Mit aktiviertem [ImageOrPrintOptions.OnlyArea](https://reference.aspose.com/cells/net/aspose.cells.rendering/imageorprintoptions/onlyarea/) rendert [SheetRender.ToImage](https://reference.aspose.com/cells/net/aspose.cells.rendering/sheetrender/toimage/) den Bereich als PNG‑Bild. Der Helper spult den Bild‑Stream zurück, bevor er ihn für die Verwendung in der Präsentation zurückgibt.

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

### **Zellbereichsgröße skalieren**

Dieser Ansatz skaliert die Höhen der ausgewählten Zeilen und die Breiten der ausgewählten Spalten, sodass sie zu einer benutzerdefinierten OLE‑Rahmengröße passen.

Das Beispiel lädt eine vorhandene Excel‑Arbeitsmappe und wählt die ersten 10 Zeilen und 13 Spalten des ersten Arbeitsblatts anhand von nullbasierten Indizes aus. [WorksheetCollection.SetOleSize](https://reference.aspose.com/cells/net/aspose.cells/worksheetcollection/setolesize/) definiert den angezeigten Bereich, und der untenstehende Helper skaliert diesen Bereich, sodass er in einen Rahmen von 400 Punkten Breite und 100 Punkten Höhe passt. Nach dem Speichern der modifizierten Arbeitsmappe in einen Stream bettet [ShapeCollection.AddOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addoleobjectframe/) sie mit der angegebenen Größe ein. Eine bei 96 DPI gerenderte Vorschau wird über [OleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe/substitutepictureformat/) zugewiesen, sodass die gespeicherte Präsentation die ausgewählten Zellen anstelle des Standard‑Platzhalters anzeigt.

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

// Setze die angezeigte Größe, wenn die Arbeitsmappendatei als OLE-Objekt in PowerPoint verwendet wird.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

// Skaliere den Zellbereich, damit er in die Rahmengröße passt.
var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

var imageStream = CreateOleImage(cellRange, imageResolution);

// Wir müssen die modifizierte Arbeitsmappe verwenden.
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// Füge das OLE-Bild zu den Präsentationsressourcen hinzu.
var oleImage = presentation.Images.AddImage(imageStream);

// Erstelle den OLE-Objekt-Rahmen.
var dataInfo = new OleEmbeddedDataInfo(oleStream.ToArray(), "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

Der Skalierungs‑Helper berechnet separate Breiten‑ und Höhen‑Verhältnisse für den ausgewählten Bereich und bewahrt dabei die relativen Spaltenbreiten und Zeilenhöhen. Die berechneten Abmessungen werden von Punkten in Zoll umgerechnet, bevor sie mit [Cells.SetColumnWidthInch](https://reference.aspose.com/cells/net/aspose.cells/cells/setcolumnwidthinch/) und [Cells.SetRowHeightInch](https://reference.aspose.com/cells/net/aspose.cells/cells/setrowheightinch/) angewendet werden. Der ausgewählte Bereich muss eine von null verschiedene Breite und Höhe besitzen.

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

Dieser Vorschau‑Helper rendert den skalierten Bereich mittels [SheetRender.ToImage](https://reference.aspose.com/cells/net/aspose.cells.rendering/sheetrender/toimage/). Er begrenzt [PageSetup.PrintArea](https://reference.aspose.com/cells/net/aspose.cells/pagesetup/printarea/) auf diesen Bereich, entfernt Ränder, Kopf‑ und Fußzeilen und gibt einen PNG‑Stream zurück, der am Anfang positioniert ist.

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

{{% alert color="info" title="Note" %}}

Es gibt zwei Ansätze, um das Problem der Größenänderung von Arbeitsblättern zu beheben. Wählen Sie den Ansatz, der am besten zu Ihren Anforderungen und Ihrem Anwendungsfall passt. Beide Ansätze funktionieren gleich, egal ob die Präsentationen aus einer Vorlage oder von Grund auf neu erstellt werden. Darüber hinaus gibt es in dieser Lösung keine Begrenzung für die Größe des OLE‑Objekt‑Rahmens.

{{% /alert %}}

## **FAQ**

**Warum ändert ein eingebettetes Excel‑Arbeitsblatt seine Größe, wenn es in PowerPoint zum ersten Mal aktiviert wird?**

Dies passiert, weil Excel versucht, bei der Aktivierung die ursprüngliche Fenstergröße beizubehalten, während der OLE‑Rahmen in PowerPoint eigene Abmessungen hat. PowerPoint und Excel verhandeln die Größe, um das Seitenverhältnis zu erhalten, was zu einer Größenänderung führen kann.

**Ist es möglich, dieses Größenänderungsproblem vollständig zu verhindern?**

Ja. Durch Skalieren des OLE‑Rahmens auf die Größe des Excel‑Zellbereichs oder durch Skalieren des Zellbereichs auf die gewünschte OLE‑Rahmengröße können unerwünschte Größenänderungen vermieden werden.

**Welche Skalierungsmethode sollte ich verwenden, OLE‑Rahmen‑Skalierung oder Zellbereichs‑Skalierung?**

Wählen Sie **OLE‑Rahmen‑Skalierung**, wenn Sie die ursprünglichen Zeilen‑ und Spaltengrößen von Excel beibehalten möchten. Wählen Sie **Zellbereichs‑Skalierung**, wenn Sie eine feste Größe für den OLE‑Rahmen in Ihrer Präsentation benötigen.

**Werden diese Lösungen funktionieren, wenn meine Präsentation auf einer Vorlage basiert?**

Ja. Beide Lösungen funktionieren sowohl für Präsentationen, die aus Vorlagen als auch für solche, die von Grund auf neu erstellt werden.

**Gibt es eine Begrenzung für die Größe des OLE‑Rahmens bei Verwendung dieser Methoden?**

Nein. Der OLE‑Objekt‑Rahmen kann beliebig groß sein, solange Sie die Skalierung entsprechend einstellen.

**Gibt es eine Möglichkeit, den Platzhaltertext „EMBEDDED OLE OBJECT“ in PowerPoint zu vermeiden?**

Ja. Indem Sie einen Schnappschuss des gewünschten Excel‑Zellbereichs erstellen und ihn als Platzhalterbild des OLE‑Rahmens festlegen, können Sie ein benutzerdefiniertes Vorschau­bild anstelle des Standard‑Platzhalters anzeigen.

## **Related Articles**

[Erstellen eines Excel‑Diagramms und Einbetten in eine Präsentation als OLE‑Objekt](/slides/de/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Automatisches Aktualisieren von OLE‑Objekten mit einem MS PowerPoint‑Add‑In](/slides/de/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)