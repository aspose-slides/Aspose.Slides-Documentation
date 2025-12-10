---
title: Funktionsfähige Lösung für die Größenänderung von Arbeitsblättern
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
description: "Behebe die OLE-Größenänderung von Excel-Arbeitsblättern in Präsentationen: zwei Methoden, um Objekt‑Frames konsistent zu halten – den Frame oder das Blatt skalieren – in den Formaten PPT und PPTX."
---

{{% alert color="primary" %}} 

Es wurde beobachtet, dass in PowerPoint‑Präsentationen eingebettete Excel‑Arbeitsblätter als OLE‑Objekte durch Aspose‑Komponenten nach der ersten Aktivierung auf eine nicht erkennbare Skalierung geändert werden. Dieses Verhalten führt zu einem auffälligen visuellen Unterschied in der Präsentation zwischen dem Zustand vor und nach der Aktivierung des OLE‑Objekts. Wir haben das Problem ausführlich untersucht und eine Lösung bereitgestellt, die in diesem Artikel behandelt wird.

{{% /alert %}} 

## **Hintergrund**

Im Artikel [OLE verwalten](/slides/de/net/manage-ole/) haben wir erklärt, wie man mit Aspose.Slides für .NET einen OLE‑Rahmen zu einer PowerPoint‑Präsentation hinzufügt. Um das [Objekt‑Vorschauproblem](/slides/de/net/object-preview-issue-when-adding-oleobjectframe/) zu lösen, haben wir dem OLE‑Objektrahmen ein Bild des ausgewählten Arbeitsblattbereichs zugewiesen. Im ausgegebenen Präsentationsdokument wird beim Doppelklick auf den OLE‑Objektrahmen, der das Arbeitsblatt‑Bild anzeigt, die Excel‑Arbeitsmappe aktiviert. Endbenutzer können beliebige Änderungen an der eigentlichen Excel‑Arbeitsmappe vornehmen und dann zur Folie zurückkehren, indem sie außerhalb der aktivierten Excel‑Arbeitsmappe klicken. Beim Zurückkehren zur Folie ändert sich die Größe des OLE‑Objektrahmens. Der Skalierungsfaktor variiert je nach Größe des OLE‑Objektrahmens und der eingebetteten Excel‑Arbeitsmappe. 

## **Ursache der Größenänderung**

Da die Excel‑Arbeitsmappe ihr eigenes Fenster hat, versucht sie, bei der ersten Aktivierung ihre ursprüngliche Größe beizubehalten. Der OLE‑Objektrahmen hingegen besitzt eine eigene Größe. Laut Microsoft verhandeln Excel und PowerPoint beim Aktivieren der Arbeitsmappe die Größe, um die korrekten Proportionen im Einbettungsprozess sicherzustellen. Die Größenänderung entsteht durch die Unterschiede zwischen der Fenstergröße von Excel und der Größe bzw. Position des OLE‑Objektrahmens. 

## **Funktionsfähige Lösung**

Es gibt zwei mögliche Ansätze, um den Skalierungseffekt zu vermeiden.

- Skalieren Sie die Größe des OLE‑Rahmens in der PowerPoint‑Präsentation, sodass sie der gewünschten Anzahl von Zeilen und Spalten im OLE‑Rahmen entspricht.  
- Halten Sie die Größe des OLE‑Rahmens konstant und skalieren Sie die Größe der beteiligten Zeilen und Spalten, sodass sie in die festgelegte OLE‑Rahmengröße passen.  

### **OLE‑Rahmengröße skalieren**

In diesem Ansatz lernen wir, wie man die OLE‑Rahmengröße der eingebetteten Excel‑Arbeitsmappe so einstellt, dass sie der kumulierten Größe der beteiligten Zeilen und Spalten im Excel‑Arbeitsblatt entspricht.

Angenommen, wir haben ein Excel‑Vorlagenblatt und möchten es als OLE‑Rahmen zu einer Präsentation hinzufügen. In diesem Szenario wird die Größe des OLE‑Objektrahmens zunächst basierend auf den kumulierten Zeilenhöhen und Spaltenbreiten der beteiligten Zeilen und Spalten der Arbeitsmappe berechnet. Anschließend setzen wir die Größe des OLE‑Rahmens auf diesen berechneten Wert. Um die rote Meldung „EMBEDDED OLE OBJECT“ für den OLE‑Rahmen in PowerPoint zu vermeiden, erfassen wir zudem ein Bild der gewünschten Zeilen‑ und Spaltenanteile der Arbeitsmappe und verwenden es als OLE‑Rahmenbild.
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


### **Zellbereichsgröße skalieren**

In diesem Ansatz lernen wir, wie man die Höhen der beteiligten Zeilen und die Breite der beteiligten Spalten so skaliert, dass sie einer benutzerdefinierten OLE‑Rahmengröße entsprechen.

Angenommen, wir haben ein Excel‑Vorlagenblatt und möchten es als OLE‑Rahmen zu einer Präsentation hinzufügen. In diesem Szenario setzen wir die Größe des OLE‑Rahmens und skalieren die Größe der Zeilen und Spalten, die zum OLE‑Rahmenbereich gehören. Danach speichern wir die Arbeitsmappe in einen Stream, um die Änderungen anzuwenden, und konvertieren sie in ein Byte‑Array, um sie dem OLE‑Rahmen hinzuzufügen. Um die rote Meldung „EMBEDDED OLE OBJECT“ für den OLE‑Rahmen in PowerPoint zu vermeiden, erfassen wir zudem ein Bild der gewünschten Zeilen‑ und Spaltenanteile der Arbeitsmappe und setzen es als OLE‑Rahmenbild.
```cs
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

// Skaliere den Zellbereich, um in die Rahmengröße zu passen.
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

// Erstelle den OLE-Objektrahmen.
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

Es gibt zwei Ansätze, um das Problem mit der Größenänderung des Arbeitsblatts zu beheben. Die Wahl des geeigneten Ansatzes hängt von den jeweiligen Anforderungen und dem Anwendungsfall ab. Beide Ansätze funktionieren identisch, egal ob die Präsentationen aus einer Vorlage oder von Grund auf erstellt werden. Zusätzlich gibt es in dieser Lösung keine Begrenzung für die Größe des OLE‑Objektrahmens.

{{% /alert %}}

## **FAQ**

**Warum ändert ein eingebettetes Excel‑Arbeitsblatt nach der ersten Aktivierung in PowerPoint seine Größe?**  
Das passiert, weil Excel versucht, bei der Aktivierung die ursprüngliche Fenstergröße beizubehalten, während der OLE‑Objektrahmen in PowerPoint eigene Abmessungen hat. PowerPoint und Excel verhandeln die Größe, um das Seitenverhältnis zu erhalten, was zu einer Größenänderung führen kann.

**Lässt sich dieses Skalierungsproblem vollständig verhindern?**  
Ja. Durch Skalieren des OLE‑Rahmens an die Größe des Excel‑Zellbereichs oder durch Skalieren des Zellbereichs an die gewünschte OLE‑Rahmengröße kann eine ungewollte Skalierung vermieden werden.

**Welches Skalierungsverfahren sollte ich verwenden, OLE‑Rahmenskalierung oder Zellbereichskalierung?**  
Wählen Sie **OLE‑Rahmenskalierung**, wenn Sie die originalen Zeilen‑ und Spaltengrößen von Excel beibehalten möchten. Wählen Sie **Zellbereichskalierung**, wenn Sie eine feste Größe für den OLE‑Rahmen in Ihrer Präsentation benötigen.

**Funktionieren diese Lösungen, wenn meine Präsentation auf einer Vorlage basiert?**  
Ja. Beide Lösungen funktionieren sowohl für Präsentationen, die aus Vorlagen, als auch für solche, die von Grund auf erstellt wurden.

**Gibt es eine Obergrenze für die Größe des OLE‑Rahmens bei Verwendung dieser Methoden?**  
Nein. Der OLE‑Objektrahmen kann beliebig groß sein, solange die Skalierung entsprechend eingestellt wird.

**Wie kann man den Platzhaltertext „EMBEDDED OLE OBJECT“ in PowerPoint vermeiden?**  
Indem Sie einen Schnappschuss des gewünschten Excel‑Zellbereichs aufnehmen und diesen als Platzhalterbild des OLE‑Rahmens festlegen, können Sie ein benutzerdefiniertes Vorschaubild anstelle des Standard‑Platzhalters anzeigen.

## **Verwandte Artikel**

[Erstellen eines Excel‑Diagramms und Einbetten in eine Präsentation als OLE‑Objekt](/slides/de/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[OLE‑Objekte automatisch mit einem MS PowerPoint‑Add‑In aktualisieren](/slides/de/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)