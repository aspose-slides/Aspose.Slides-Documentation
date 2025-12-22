---
title: Lösungsansatz für die Größenänderung von Arbeitsblättern
type: docs
weight: 20
url: /de/androidjava/working-solution-for-worksheet-resizing/
keywords:
- OLE
- Vorschaubild
- Bildgrößenanpassung
- Excel
- Arbeitsblatt
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Behebt die OLE‑Größenänderung von Excel‑Arbeitsblättern in Präsentationen: zwei Methoden, um Objektrahmen konsistent zu halten – den Rahmen oder das Blatt skalieren – in den PPT‑ und PPTX‑Formaten."
---

{{% alert color="primary" %}}

Es wurde beobachtet, dass Excel‑Arbeitsblätter, die als OLE‑Objekte in einer PowerPoint‑Präsentation über Aspose‑Komponenten eingebettet sind, nach der ersten Aktivierung auf eine nicht identifizierte Skalierung skaliert werden. Dieses Verhalten erzeugt einen deutlich sichtbaren Unterschied in der Präsentation zwischen den Vor‑ und Nachaktivierungs‑Zuständen des OLE‑Objekts. Wir haben das Problem eingehend untersucht und eine Lösung bereitgestellt, die in diesem Artikel behandelt wird.

{{% /alert %}}

## **Hintergrund**

Im Artikel [Manage OLE](/slides/de/androidjava/manage-ole/) erklärten wir, wie man mit Aspose.Slides für Android via Java einen OLE‑Rahmen zu einer PowerPoint‑Präsentation hinzufügt. Um das [object preview issue](/slides/de/androidjava/object-preview-issue-when-adding-oleobjectframe/) zu beheben, haben wir ein Bild des ausgewählten Arbeitsblattbereichs dem OLE‑Objekt‑Rahmen zugeordnet. In der erzeugten Präsentation wird das Excel‑Arbeitsbuch aktiviert, wenn Sie den OLE‑Objekt‑Rahmen, der das Arbeitsblatt‑Bild anzeigt, doppelklicken. Endbenutzer können beliebige Änderungen am eigentlichen Excel‑Arbeitsbuch vornehmen und dann zur Folie zurückkehren, indem sie außerhalb des aktivierten Excel‑Arbeitsbuchs klicken. Die Größe des OLE‑Objekt‑Rahmens ändert sich, wenn der Benutzer zur Folie zurückkehrt. Der Skalierungsfaktor variiert je nach Größe des OLE‑Objekt‑Rahmens und des eingebetteten Excel‑Arbeitsbuchs.

## **Ursache der Größenänderung**

Da das Excel‑Arbeitsbuch eine eigene Fenstergröße hat, versucht es, seine ursprüngliche Größe bei der ersten Aktivierung beizubehalten. Der OLE‑Objekt‑Rahmen hingegen hat seine eigene Größe. Laut Microsoft verhandeln Excel und PowerPoint bei der Aktivierung des Arbeitsbuchs die Größe, um sicherzustellen, dass die korrekten Proportionen im Einbettungsprozess erhalten bleiben. Die Größenänderung entsteht aufgrund der Unterschiede zwischen der Excel‑Fenstergröße und der Größe und Position des OLE‑Objekt‑Rahmens.

## **Lösungsansatz**

Es gibt zwei mögliche Lösungen, um den Skalierungseffekt zu vermeiden.

- Skalieren Sie die OLE‑Rahmengröße in der PowerPoint‑Präsentation, um die Höhe und Breite der gewünschten Anzahl von Zeilen und Spalten im OLE‑Rahmen zu erreichen.
- Behalten Sie die OLE‑Rahmengröße konstant und skalieren Sie die Größe der beteiligten Zeilen und Spalten, damit sie in die ausgewählte OLE‑Rahmengröße passen.

### **Skalieren der OLE‑Rahmengröße**

In diesem Ansatz lernen wir, wie man die OLE‑Rahmengröße des eingebetteten Excel‑Arbeitsbuchs so einstellt, dass sie der kumulierten Größe der beteiligten Zeilen und Spalten im Excel‑Arbeitsblatt entspricht.

Nehmen wir an, wir haben ein Excel‑Vorlagensheet und möchten es als OLE‑Rahmen zu einer Präsentation hinzufügen. In diesem Szenario wird die Größe des OLE‑Objekt‑Rahmens zunächst anhand der kumulierten Zeilenhöhen und Spaltenbreiten der beteiligten Zeilen und Spalten im Arbeitsbuch berechnet. Anschließend setzen wir die OLE‑Rahmengröße auf diesen berechneten Wert. Um die rote Meldung „EMBEDDED OLE OBJECT“ für den OLE‑Rahmen in PowerPoint zu vermeiden, erfassen wir außerdem ein Bild der gewünschten Zeilen‑ und Spaltenbereiche im Arbeitsbuch und setzen es als OLE‑Rahmen‑Bild.

```java
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook( "sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// Legen Sie die angezeigte Größe fest, wenn die Arbeitsmappendatei als OLE-Objekt in PowerPoint verwendet wird.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Ermitteln Sie die Breite und Höhe des OLE-Bildes in Punkten.
Bitmap image = BitmapFactory.decodeStream(imageStream);
float imageWidth = image.getWidth(null) * 72f / imageResolution;
float imageHeight = image.getHeight(null) * 72f / imageResolution;

// Wir müssen die modifizierte Arbeitsmappe verwenden.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Fügen Sie das OLE-Bild zu den Präsentationsressourcen hinzu.
imageStream.reset();
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// Erstellen Sie den OLE-Objektrahmen.
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


### **Skalieren der Zellbereichsgröße**

In diesem Ansatz lernen wir, wie man die Höhen der beteiligten Zeilen und die Breite der beteiligten Spalten so skaliert, dass sie einer benutzerdefinierten OLE‑Rahmengröße entsprechen.

Nehmen wir an, wir haben ein Excel‑Vorlagensheet und möchten es als OLE‑Rahmen zu einer Präsentation hinzufügen. In diesem Szenario setzen wir die Größe des OLE‑Rahmens und skalieren die Größe der Zeilen und Spalten, die im OLE‑Rahmen‑Bereich verwendet werden. Anschließend speichern wir das Arbeitsbuch in einen Stream, um die Änderungen zu übernehmen, und konvertieren es in ein Byte‑Array, um es dem OLE‑Rahmen hinzuzufügen. Um die rote Meldung „EMBEDDED OLE OBJECT“ für den OLE‑Rahmen in PowerPoint zu vermeiden, erfassen wir außerdem ein Bild der gewünschten Zeilen‑ und Spaltenbereiche im Arbeitsbuch und setzen es als OLE‑Rahmen‑Bild.

```java
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook("sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// Legen Sie die angezeigte Größe fest, wenn die Arbeitsmappendatei als OLE-Objekt in PowerPoint verwendet wird.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

// Skalieren Sie den Zellbereich, um die Rahmengröße anzupassen.
com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Wir müssen die modifizierte Arbeitsmappe verwenden.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Fügen Sie das OLE-Bild zu den Präsentationsressourcen hinzu.
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// Erstellen Sie den OLE-Objektrahmen.
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

Es gibt zwei Ansätze, um das Problem der Größenänderung des Arbeitsblatts zu beheben. Die Wahl des passenden Ansatzes hängt von den konkreten Anforderungen und dem Anwendungsfall ab. Beide Ansätze funktionieren gleich, unabhängig davon, ob die Präsentationen aus einer Vorlage oder von Grund auf erstellt werden. Zusätzlich gibt es in dieser Lösung keine Begrenzung für die Größe des OLE‑Objekt‑Rahmens.

{{% /alert %}}

## **FAQ**

**Warum ändert ein eingebettetes Excel‑Arbeitsblatt seine Größe, wenn es in PowerPoint zum ersten Mal aktiviert wird?**

Dies geschieht, weil Excel versucht, beim Aktivieren die ursprüngliche Fenstergröße beizubehalten, während der OLE‑Objekt‑Rahmen in PowerPoint eigene Abmessungen hat. PowerPoint und Excel verhandeln die Größe, um das Seitenverhältnis zu bewahren, was zu einer Größenänderung führen kann.

**Ist es möglich, dieses Skalierungsproblem vollständig zu verhindern?**

Ja. Durch das Skalieren des OLE‑Rahmens auf die Größe des Excel‑Zellbereichs oder das Skalieren des Zellbereichs auf die gewünschte OLE‑Rahmengröße können Sie unerwünschte Größenänderungen verhindern.

**Welche Skalierungsmethode sollte ich verwenden, OLE‑Rahmenskalierung oder Zellbereichsskalierung?**

Wählen Sie **OLE‑Rahmenskalierung**, wenn Sie die ursprünglichen Zeilen‑ und Spaltengrößen von Excel beibehalten wollen. Wählen Sie **Zellbereichsskalierung**, wenn Sie eine feste Größe für den OLE‑Rahmen in Ihrer Präsentation benötigen.

**Werden diese Lösungen funktionieren, wenn meine Präsentation auf einer Vorlage basiert?**

Ja. Beide Lösungen funktionieren für Präsentationen, die aus Vorlagen oder von Grund auf erstellt wurden.

**Gibt es eine Begrenzung für die Größe des OLE‑Rahmens bei Verwendung dieser Methoden?**

Nein. Sie können den OLE‑Objekt‑Rahmen beliebig groß machen, solange Sie die Skalierung entsprechend einstellen.

**Gibt es eine Möglichkeit, den Platzhaltertext „EMBEDDED OLE OBJECT“ in PowerPoint zu vermeiden?**

Ja. Indem Sie einen Schnappschuss des gewünschten Excel‑Zellbereichs aufnehmen und ihn als Platzhalter‑Bild des OLE‑Rahmens festlegen, können Sie ein benutzerdefiniertes Vorschaubild anstelle des Standard‑Platzhalters anzeigen.