---
title: Arbeitslösung für die Skalierung von Arbeitsblättern
type: docs
weight: 20
url: /de/java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- Vorschaubild
- Bildskalierung
- Excel
- Arbeitsblatt
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Excel-Arbeitsblatt-OLE-Skalierung in Präsentationen beheben: zwei Wege, um Objektrahmen konsistent zu halten – Rahmen oder Blatt skalieren – für PPT- und PPTX-Formate."
---

{{% alert color="primary" %}}

Es wurde beobachtet, dass in PowerPoint‑Präsentationen eingebettete Excel‑Arbeitsblätter, die als OLE‑Objekte über Aspose‑Komponenten eingefügt werden, nach der ersten Aktivierung auf einen unbekannten Maßstab skaliert werden. Dieses Verhalten führt zu einem deutlich sichtbaren Unterschied zwischen dem Zustand vor und nach der Aktivierung des OLE‑Objekts. Wir haben das Problem eingehend untersucht und eine Lösung bereitgestellt, die in diesem Artikel erläutert wird.

{{% /alert %}}

## **Hintergrund**

Im Artikel [OLE verwalten](/slides/de/java/manage-ole/) haben wir erklärt, wie man mit Aspose.Slides für Java einen OLE‑Rahmen zu einer PowerPoint‑Präsentation hinzufügt. Um das [Problem mit der Objektvorschau](/slides/de/java/object-preview-issue-when-adding-oleobjectframe/) zu beheben, haben wir dem OLE‑Rahmen ein Bild des ausgewählten Arbeitsblattbereichs zugewiesen. Im Ergebnis‑Deckblatt wird bei einem Doppelklick auf den OLE‑Rahmen, der das Arbeitsblatt‑Bild zeigt, die Excel‑Arbeitsmappe aktiviert. Endbenutzer können Änderungen an der eigentlichen Excel‑Arbeitsmappe vornehmen und anschließend zur Folie zurückkehren, indem sie außerhalb der aktivierten Excel‑Arbeitsmappe klicken. Beim Zurückwechseln zur Folie ändert sich die Größe des OLE‑Rahmens. Der Skalierungsfaktor variiert je nach Größe des OLE‑Rahmens und der eingebetteten Excel‑Arbeitsmappe.

## **Ursache der Skalierung**

Da die Excel‑Arbeitsmappe ihr eigenes Fenster hat, versucht sie, beim ersten Aktivieren ihre ursprüngliche Größe beizubehalten. Der OLE‑Rahmen besitzt hingegen seine eigene Größe. Laut Microsoft verhandeln Excel und PowerPoint beim Aktivieren der Arbeitsmappe die Größe, um das korrekte Seitenverhältnis im Einbettungsprozess sicherzustellen. Die Skalierung entsteht durch die Unterschiede zwischen der Fenstergröße von Excel und der Größe sowie Position des OLE‑Rahmens.

## **Funktionsfähige Lösung**

Es gibt zwei mögliche Ansätze, um den Skalierungseffekt zu vermeiden.

- Skalieren Sie die OLE‑Rahmengröße in der PowerPoint‑Präsentation, sodass sie der Höhe und Breite der gewünschten Anzahl von Zeilen und Spalten im OLE‑Rahmen entspricht.
- Halten Sie die OLE‑Rahmengröße konstant und skalieren Sie die Größe der beteiligten Zeilen und Spalten, sodass sie in die festgelegte OLE‑Rahmengröße passen.

### **OLE‑Rahmengröße skalieren**

In diesem Ansatz lernen wir, wie die OLE‑Rahmengröße der eingebetteten Excel‑Arbeitsmappe so eingestellt wird, dass sie der kumulierten Größe der beteiligten Zeilen und Spalten im Excel‑Arbeitsblatt entspricht.

Angenommen, wir haben ein Vorlage‑Excel‑Sheet und möchten es als OLE‑Rahmen zu einer Präsentation hinzufügen. In diesem Szenario wird die Größe des OLE‑Objektrahmens zunächst anhand der kumulierten Zeilenhöhen und Spaltenbreiten der beteiligten Zeilen und Spalten in der Arbeitsmappe berechnet. Anschließend setzen wir die OLE‑Rahmengröße auf diesen berechneten Wert. Um die rote Meldung „EMBEDDED OLE OBJECT“ für den OLE‑Rahmen in PowerPoint zu vermeiden, erfassen wir außerdem ein Bild der gewünschten Zeilen‑ und Spaltenabschnitte in der Arbeitsmappe und verwenden es als OLE‑Rahmen‑Vorschaubild.
```java
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook( "sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// Setze die angezeigte Größe, wenn die Arbeitsmappendatei als OLE-Objekt in PowerPoint verwendet wird.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Erhalte die Breite und Höhe des OLE-Bildes in Punkten.
Image image = ImageIO.read(imageStream);
float imageWidth = image.getWidth(null) * 72f / imageResolution;
float imageHeight = image.getHeight(null) * 72f / imageResolution;

// Wir müssen die modifizierte Arbeitsmappe verwenden.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Füge das OLE-Bild zu den Präsentationsressourcen hinzu.
imageStream.reset();
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// Erstelle den OLE-Objektrahmen.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

```java
static InputStream CreateOleImage(com.aspose.cells.Range cellRange, int imageResolution) throws Exception {
    com.aspose.cells.PageSetup pageSetup = cellRange.getWorksheet().getPageSetup();
    pageSetup.setPrintArea(cellRange.getAddress());
    pageSetup.setLeftMargin(0);
    pageSetup.setRightMargin(0);
    pageSetup.setTopMargin(0);
    pageSetup.setBottomMargin(0);
    pageSetup.clearHeaderFooter();

    com.aspose.cells.ImageOrPrintOptions imageOptions = new com.aspose.cells.ImageOrPrintOptions();
    imageOptions.setImageType(com.aspose.cells.ImageType.PNG);
    imageOptions.setVerticalResolution(imageResolution);
    imageOptions.setHorizontalResolution(imageResolution);
    imageOptions.setOnePagePerSheet(true);
    imageOptions.setOnlyArea(true);

    com.aspose.cells.SheetRender sheetRender = new com.aspose.cells.SheetRender(cellRange.getWorksheet(), imageOptions);
    ByteArrayOutputStream imageStream = new ByteArrayOutputStream();

    sheetRender.toImage(0, imageStream);
    return new ByteArrayInputStream(imageStream.toByteArray());
}
```


### **Zellbereichsgröße skalieren**

In diesem Ansatz lernen wir, wie die Höhen der beteiligten Zeilen und die Breite der beteiligten Spalten so skaliert werden, dass sie zu einer benutzerdefinierten OLE‑Rahmengröße passen.

Angenommen, wir haben ein Vorlage‑Excel‑Sheet und möchten es als OLE‑Rahmen zu einer Präsentation hinzufügen. In diesem Szenario setzen wir die OLE‑Rahmengröße und skalieren die Größe der Zeilen und Spalten, die den OLE‑Rahmenbereich bilden. Anschließend speichern wir die Arbeitsmappe in einen Stream, um die Änderungen anzuwenden, und konvertieren sie in ein Byte‑Array, das dem OLE‑Rahmen hinzugefügt wird. Um die rote Meldung „EMBEDDED OLE OBJECT“ für den OLE‑Rahmen in PowerPoint zu vermeiden, erfassen wir außerdem ein Bild der gewünschten Zeilen‑ und Spaltenabschnitte in der Arbeitsmappe und verwenden es als OLE‑Rahmen‑Vorschaubild.
```java
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook("sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// Setze die angezeigte Größe, wenn die Arbeitsmappendatei als OLE‑Objekt in PowerPoint verwendet wird.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

// Skaliere den Zellbereich, damit er in die Rahmen­größe passt.
com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Wir müssen die modifizierte Arbeitsmappe verwenden.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Füge das OLE‑Bild zu den Präsentationsressourcen hinzu.
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// Erstelle den OLE‑Objektrahmen.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

```java
/**
 * @param width     Die erwartete Breite des Zellbereichs in Punkten.
 * @param height    Die erwartete Höhe des Zellbereichs in Punkten.
 */
static void ScaleCellRange(com.aspose.cells.Range cellRange, float width, float height) {
    double rangeWidth = cellRange.getWidth();
    double rangeHeight = cellRange.getHeight();

    for (int i = 0; i < cellRange.getColumnCount(); i++) {
        int columnIndex = cellRange.getFirstColumn() + i;
        double columnWidth = cellRange.getWorksheet()
                .getCells()
                .getColumnWidth(columnIndex, false, com.aspose.cells.CellsUnitType.POINT);

        double newColumnWidth = columnWidth * width / rangeWidth;
        double widthInInches = newColumnWidth / 72.0;
        cellRange.getWorksheet()
                .getCells()
                .setColumnWidthInch(columnIndex, widthInInches);
    }

    for (int i = 0; i < cellRange.getRowCount(); i++) {
        int rowIndex = cellRange.getFirstRow() + i;
        double rowHeight = cellRange.getWorksheet()
                .getCells()
                .getRowHeight(rowIndex, false, com.aspose.cells.CellsUnitType.POINT);

        double newRowHeight = rowHeight * height / rangeHeight;
        double heightInInches = newRowHeight / 72.0;
        cellRange.getWorksheet()
                .getCells()
                .setRowHeightInch(rowIndex, heightInInches);
    }
}
```

```java
static InputStream CreateOleImage(com.aspose.cells.Range cellRange, int imageResolution) throws Exception {
    com.aspose.cells.PageSetup pageSetup = cellRange.getWorksheet().getPageSetup();
    pageSetup.setPrintArea(cellRange.getAddress());
    pageSetup.setLeftMargin(0);
    pageSetup.setRightMargin(0);
    pageSetup.setTopMargin(0);
    pageSetup.setBottomMargin(0);
    pageSetup.clearHeaderFooter();

    com.aspose.cells.ImageOrPrintOptions imageOptions = new com.aspose.cells.ImageOrPrintOptions();
    imageOptions.setImageType(com.aspose.cells.ImageType.PNG);
    imageOptions.setVerticalResolution(imageResolution);
    imageOptions.setHorizontalResolution(imageResolution);
    imageOptions.setOnePagePerSheet(true);
    imageOptions.setOnlyArea(true);

    com.aspose.cells.SheetRender sheetRender = new com.aspose.cells.SheetRender(cellRange.getWorksheet(), imageOptions);
    ByteArrayOutputStream imageStream = new ByteArrayOutputStream();

    sheetRender.toImage(0, imageStream);
    return new ByteArrayInputStream(imageStream.toByteArray());
}
```


## **Fazit**

{{% alert color="primary" %}} 

Es gibt zwei Ansätze, um das Problem der Arbeitsblatt‑Skalierung zu beheben. Die Wahl des passenden Ansatzes hängt von den konkreten Anforderungen und dem Anwendungsfall ab. Beide Verfahren funktionieren gleichermaßen, egal ob die Präsentationen aus einer Vorlage oder von Grund auf erstellt werden. Darüber hinaus gibt es bei dieser Lösung keine Begrenzung für die Größe des OLE‑Objektrahmens.

{{% /alert %}}

## **FAQ**

**Warum ändert ein eingebettetes Excel‑Arbeitsblatt seine Größe, wenn es in PowerPoint zum ersten Mal aktiviert wird?**

Das passiert, weil Excel beim Aktivieren versucht, die ursprüngliche Fenstergröße beizubehalten, während der OLE‑Rahmen in PowerPoint eigene Abmessungen hat. PowerPoint und Excel verhandeln die Größe, um das Seitenverhältnis zu wahren, was zu einer Skalierung führen kann.

**Lässt sich das Skalierungsproblem vollständig verhindern?**

Ja. Durch Skalieren des OLE‑Rahmens, um die Größe des Excel‑Zellbereichs zu übernehmen, oder durch Skalieren des Zellbereichs, um die gewünschte OLE‑Rahmengröße zu erreichen, lässt sich ein unerwünschtes Skalieren vermeiden.

**Welche Skalierungsmethode soll ich verwenden, OLE‑Rahmenskalierung oder Zellbereichskalierung?**

Wählen Sie **OLE‑Rahmenskalierung**, wenn Sie die ursprünglichen Zeilen‑ und Spaltengrößen von Excel beibehalten möchten. Wählen Sie **Zellbereichskalierung**, wenn Sie eine feste Größe für den OLE‑Rahmen in Ihrer Präsentation benötigen.

**Funktionieren diese Lösungen auch, wenn meine Präsentation auf einer Vorlage basiert?**

Ja. Beide Lösungen funktionieren sowohl für Präsentationen, die aus Vorlagen als auch von Grund auf erstellt wurden.

**Gibt es eine Begrenzung für die Größe des OLE‑Rahmens bei Verwendung dieser Methoden?**

Nein. Der OLE‑Objektrahmen kann beliebig groß sein, solange Sie den Skalierungsfaktor entsprechend einstellen.

**Wie kann man den Platzhalter‑Text „EMBEDDED OLE OBJECT“ in PowerPoint vermeiden?**

Ja. Indem Sie einen Schnappschuss des gewünschten Excel‑Zellbereichs erstellen und diesen als Platzhalter‑Bild des OLE‑Rahmens setzen, können Sie ein benutzerdefiniertes Vorschau‑Bild anstelle des Standard‑Platzhalters anzeigen.

## **Verwandte Artikel**

[Ein Excel‑Diagramm erstellen und als OLE‑Objekt in einer Präsentation einbetten](/slides/de/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[OLE‑Objekte automatisch mit einem MS‑PowerPoint‑Add‑In aktualisieren](/slides/de/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)