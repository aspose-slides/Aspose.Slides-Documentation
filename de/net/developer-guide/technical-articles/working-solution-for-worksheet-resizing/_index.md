---
title: Lösungsansatz für die Größenanpassung von Arbeitsblättern
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
description: "Beheben Sie die OLE-Größenänderung von Excel-Arbeitsblättern in Präsentationen: zwei Möglichkeiten, Objekt-Frames konsistent zu halten – entweder den Frame oder das Blatt skalieren – in den PPT- und PPTX-Formaten."
---

{{% alert color="primary" %}} 

Es wurde beobachtet, dass in einer PowerPoint‑Präsentation über Aspose‑Komponenten eingebettete Excel‑Arbeitsblätter als OLE‑Objekte nach der ersten Aktivierung auf einen nicht ermittelten Maßstab skaliert werden. Dieses Verhalten führt zu einem sichtbaren Unterschied in der Präsentation zwischen dem Zustand des OLE‑Objekts vor und nach der Aktivierung. Wir haben dieses Problem ausführlich untersucht und eine Lösung bereitgestellt, die in diesem Artikel beschrieben wird.

{{% /alert %}} 

## **Hintergrund**

Im Artikel [Manage OLE](/slides/de/net/manage-ole/) haben wir erklärt, wie man mit Aspose.Slides für .NET einen OLE‑Frame zu einer PowerPoint‑Präsentation hinzufügt. Um das [object preview issue](/slides/de/net/object-preview-issue-when-adding-oleobjectframe/) zu beheben, haben wir dem OLE‑Objekt‑Frame ein Bild des ausgewählten Arbeitsblattbereichs zugewiesen. In der Ergebnispräsentation wird das Excel‑Arbeitsbuch aktiviert, wenn Sie das OLE‑Objekt‑Frame, das das Arbeitsblatt‑Bild anzeigt, doppelklicken. Endbenutzer können beliebige Änderungen am eigentlichen Excel‑Arbeitsbuch vornehmen und dann zur Folie zurückkehren, indem sie außerhalb des aktivierten Excel‑Arbeitsbuchs klicken. Die Größe des OLE‑Objekt‑Frames ändert sich, wenn der Benutzer zur Folie zurückkehrt. Der Skalierungsfaktor variiert je nach Größe des OLE‑Objekt‑Frames und des eingebetteten Excel‑Arbeitsbuchs.

## **Ursache der Skalierung**

Da das Excel‑Arbeitsbuch über eine eigene Fenstergröße verfügt, versucht es, bei der ersten Aktivierung seine ursprüngliche Größe beizubehalten. Andererseits hat der OLE‑Objekt‑Frame seine eigene Größe. Laut Microsoft verhandeln Excel und PowerPoint bei der Aktivierung des Excel‑Arbeitsbuchs die Größe, um sicherzustellen, dass die korrekten Proportionen im Einbettungsprozess erhalten bleiben. Die Größenänderung entsteht aufgrund der Unterschiede zwischen der Fenstergröße von Excel und der Größe sowie Position des OLE‑Objekt‑Frames.

## **Lösungsansatz**

Es gibt zwei mögliche Lösungen, um den Skalierungseffekt zu vermeiden.

- Skalieren Sie die Größe des OLE‑Frames in der PowerPoint‑Präsentation, sodass Höhe und Breite der gewünschten Anzahl von Zeilen und Spalten im OLE‑Frame entsprechen.
- Behalten Sie die Größe des OLE‑Frames konstant und skalieren Sie die Größe der beteiligten Zeilen und Spalten, damit sie in die gewählte OLE‑Frame‑Größe passen.

### **Skalieren der OLE‑Frame‑Größe**

In diesem Ansatz lernen wir, wie man die OLE‑Frame‑Größe des eingebetteten Excel‑Arbeitsbuchs so festlegt, dass sie der kumulierten Größe der beteiligten Zeilen und Spalten im Excel‑Arbeitsblatt entspricht.

Angenommen, wir haben ein Excel‑Vorlagenblatt und möchten es als OLE‑Frame zu einer Präsentation hinzufügen. In diesem Szenario wird die Größe des OLE‑Objekt‑Frames zunächst anhand der kumulierten Zeilenhöhen und Spaltenbreiten der beteiligten Zeilen und Spalten im Arbeitsbuch berechnet. Anschließend setzen wir die Größe des OLE‑Frames auf diesen berechneten Wert. Um die rote Meldung „EMBEDDED OLE OBJECT“ für den OLE‑Frame in PowerPoint zu vermeiden, erfassen wir außerdem ein Bild der gewünschten Zeilen‑ und Spaltenbereiche im Arbeitsbuch und verwenden es als OLE‑Frame‑Bild.
```cs
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// Set the displayed size when the workbook file is used as an OLE object in PowerPoint.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
var imageStream = CreateOleImage(cellRange, imageResolution);

// Get the width and height of the OLE image in points.
using var image = Image.FromStream(imageStream);
var imageWidth = image.Width * 72 / imageResolution;
var imageHeight = image.Height * 72 / imageResolution;

// We need to use the modified workbook.
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// Add the OLE image to the presentation resources.
imageStream.Seek(0, SeekOrigin.Begin);
var oleImage = presentation.Images.AddImage(imageStream);

// Create the OLE object frame.
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

In diesem Ansatz lernen wir, wie man die Höhen der beteiligten Zeilen und die Breite der beteiligten Spalten skaliert, um eine benutzerdefinierte OLE‑Frame‑Größe zu erreichen.

Angenommen, wir haben ein Excel‑Vorlagenblatt und möchten es als OLE‑Frame zu einer Präsentation hinzufügen. In diesem Szenario setzen wir die Größe des OLE‑Frames und skalieren die Größe der Zeilen und Spalten, die im OLE‑Frame‑Bereich beteiligt sind. Anschließend speichern wir das Arbeitsbuch in einen Stream, um die Änderungen anzuwenden, und konvertieren es in ein Byte‑Array, das dem OLE‑Frame hinzugefügt wird. Um die rote Meldung „EMBEDDED OLE OBJECT“ für den OLE‑Frame in PowerPoint zu vermeiden, erfassen wir außerdem ein Bild der gewünschten Zeilen‑ und Spaltenbereiche im Arbeitsbuch und verwenden es als OLE‑Frame‑Bild.
```cs
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// Legt die angezeigte Größe fest, wenn die Arbeitsbuchdatei als OLE-Objekt in PowerPoint verwendet wird.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

// Skaliert den Zellbereich, um zur Rahmengröße zu passen.
var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

var imageStream = CreateOleImage(cellRange, imageResolution);

// Wir müssen das modifizierte Arbeitsbuch verwenden.
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// Fügt das OLE-Bild zu den Präsentationsressourcen hinzu.
var oleImage = presentation.Images.AddImage(imageStream);

// Erzeugt den OLE-Objekt-Frame.
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

{{% alert color="primary" %}}

Es gibt zwei Ansätze, um das Problem der Arbeitsblattskalierung zu beheben. Die Wahl des geeigneten Ansatzes hängt von den konkreten Anforderungen und dem Anwendungsfall ab. Beide Ansätze funktionieren identisch, egal ob die Präsentationen aus einer Vorlage oder von Grund auf erstellt werden. Darüber hinaus gibt es in dieser Lösung keine Begrenzung für die Größe des OLE‑Objekt‑Frames.

{{% /alert %}}

## FAQ

**Q: Warum ändert ein eingebettetes Excel‑Arbeitsblatt seine Größe, wenn es in PowerPoint zum ersten Mal aktiviert wird?**  
Dies geschieht, weil Excel bei der Aktivierung versucht, die ursprüngliche Fenstergröße beizubehalten, während der OLE‑Objekt‑Frame in PowerPoint eigene Abmessungen hat. PowerPoint und Excel verhandeln die Größe, um das Seitenverhältnis zu erhalten, was zu einer Skalierung führen kann.

**Q: Ist es möglich, dieses Skalierungsproblem vollständig zu verhindern?**  
Ja. Durch Skalieren des OLE‑Frames, sodass er der Größe des Excel‑Zellbereichs entspricht, oder durch Skalieren des Zellbereichs, sodass er der gewünschten OLE‑Frame‑Größe entspricht, kann eine unerwünschte Skalierung verhindert werden.

**Q: Welche Skalierungsmethode sollte ich verwenden, OLE‑Frame‑Skalierung oder Zellbereichs‑Skalierung?**  
Wählen Sie **OLE‑Frame‑Skalierung**, wenn Sie die ursprünglichen Excel‑Zeilen- und Spaltengrößen beibehalten möchten. Wählen Sie **Zellbereichs‑Skalierung**, wenn Sie eine feste Größe für den OLE‑Frame in Ihrer Präsentation wünschen.

**Q: Funktionieren diese Lösungen, wenn meine Präsentation auf einer Vorlage basiert?**  
Ja. Beide Lösungen funktionieren sowohl für Präsentationen, die aus Vorlagen erstellt wurden, als auch für solche, die von Grund auf neu erstellt werden.

**Q: Gibt es eine Größenbeschränkung für den OLE‑Frame bei Verwendung dieser Methoden?**  
Nein. Der OLE‑Objekt‑Frame kann beliebig groß sein, solange die Skalierung korrekt eingestellt wird.

**Q: Gibt es eine Möglichkeit, den Platzhaltertext „EMBEDDED OLE OBJECT“ in PowerPoint zu vermeiden?**  
Ja. Indem Sie einen Schnappschuss des gewünschten Excel‑Zellbereichs aufnehmen und ihn als Platzhalterbild des OLE‑Frames festlegen, können Sie ein benutzerdefiniertes Vorschaubild anstelle des Standardplatzhalters anzeigen.

## **Verwandte Artikel**

[Erstellen eines Excel‑Diagramms und Einbetten in eine Präsentation als OLE‑Objekt](/slides/de/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[OLE‑Objekte automatisch aktualisieren mit einem MS‑PowerPoint‑Add‑In](/slides/de/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)