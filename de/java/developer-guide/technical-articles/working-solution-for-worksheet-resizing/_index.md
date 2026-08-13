---
title: Arbeitslösung für die Größenanpassung von Arbeitsblättern
type: docs
weight: 20
url: /de/java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- Vorschau-Bild
- Bildskalierung
- Excel
- Arbeitsblatt
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Beheben Sie die OLE-Skalierung von Excel-Arbeitsblättern in Präsentationen: zwei Methoden, um Objektrahmen konsistent zu halten - den Rahmen oder das Blatt skalieren - in den Formaten PPT und PPTX."
---
{{% alert color="info" %}}
Es wurde beobachtet, dass in einer PowerPoint‑Präsentation über Aspose‑Komponenten eingebettete Excel‑Arbeitsblätter als OLE‑Objekte nach der ersten Aktivierung auf einen nicht identifizierten Maßstab skaliert werden. Dieses Verhalten führt zu einem deutlich sichtbaren Unterschied in der Präsentation zwischen dem Zustand vor und nach der Aktivierung des OLE‑Objekts. Wir haben das Problem eingehend untersucht und eine Lösung bereitgestellt, die in diesem Artikel behandelt wird.
{{% /alert %}}

## **Hintergrund**

In dem Artikel [Manage OLE](/slides/de/java/manage-ole/) haben wir erklärt, wie man mit Aspose.Slides for Java einen OLE‑Rahmen zu einer PowerPoint‑Präsentation hinzufügt. Um das [object preview issue](/slides/de/java/object-preview-issue-when-adding-oleobjectframe/) zu beheben, haben wir dem OLE‑Objekt‑Rahmen ein Bild des ausgewählten Arbeitsblattbereichs zugewiesen. In der ausgegebenen Präsentation wird beim Doppelklick auf den OLE‑Objekt‑Rahmen, der das Arbeitsblattbild anzeigt, die Excel‑Arbeitsmappe aktiviert. Endbenutzer können beliebige Änderungen an der eigentlichen Excel‑Arbeitsmappe vornehmen und dann zur Folie zurückkehren, indem sie außerhalb der aktivierten Excel‑Arbeitsmappe klicken. Die Größe des OLE‑Objekt‑Rahmens ändert sich, wenn der Benutzer zur Folie zurückkehrt. Der Skalierungsfaktor variiert je nach Größe des OLE‑Objekt‑Rahmens und der eingebetteten Excel‑Arbeitsmappe.

## **Ursache der Skalierung**

Da die Excel‑Arbeitsmappe ihre eigene Fenstergröße hat, versucht sie, nach der ersten Aktivierung ihre ursprüngliche Größe beizubehalten. Der OLE‑Objekt‑Rahmen hat dagegen seine eigene Größe. Laut Microsoft verhandeln Excel und PowerPoint beim Aktivieren der Excel‑Arbeitsmappe die Größe, um sicherzustellen, dass die korrekten Proportionen im Einbettungsprozess erhalten bleiben. Die Skalierung erfolgt basierend auf den Unterschieden zwischen der Excel‑Fenstergröße und der Größe sowie Position des OLE‑Objekt‑Rahmens.

## **Lösungsansatz**

Es gibt zwei mögliche Lösungen, um den Skalierungseffekt zu vermeiden.

- Skalieren Sie die Größe des OLE‑Rahmens in der PowerPoint‑Präsentation, sodass sie der Höhe und Breite der gewünschten Anzahl von Zeilen und Spalten im OLE‑Rahmen entspricht.
- Behalten Sie die Größe des OLE‑Rahmens konstant und skalieren Sie die Größe der teilnehmenden Zeilen und Spalten, sodass sie in die ausgewählte OLE‑Rahmengröße passen.

### **OLE‑Rahmengröße skalieren**

In diesem Ansatz lernen wir, wie man die Größe des OLE‑Rahmens der eingebetteten Excel‑Arbeitsmappe so festlegt, dass sie der kumulierten Größe der teilnehmenden Zeilen und Spalten im Excel‑Arbeitsblatt entspricht.

Angenommen, wir haben ein Excel‑Vorlagenblatt und möchten es als OLE‑Rahmen zu einer Präsentation hinzufügen. In diesem Szenario wird die Größe des OLE‑Objekt‑Rahmens zunächst basierend auf den kumulierten Zeilenhöhen und Spaltenbreiten der teilnehmenden Zeilen und Spalten in der Arbeitsmappe berechnet. Anschließend setzen wir die Größe des OLE‑Rahmens auf diesen berechneten Wert. Um die rote Meldung „EMBEDDED OLE OBJECT“ für den OLE‑Rahmen in PowerPoint zu vermeiden, erfassen wir zudem ein Bild der gewünschten Bereiche der Zeilen und Spalten in der Arbeitsmappe und setzen es als OLE‑Rahmen‑Bild.

```java
import com.aspose.slides.*;
import java.awt.Image;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;
import javax.imageio.ImageIO;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook( "sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// Legt die angezeigte Größe fest, wenn die Arbeitsmappendatei als OLE-Objekt in PowerPoint verwendet wird.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Ermittelt die Breite und Höhe des OLE-Bildes in Punkten.
Image image = ImageIO.read(imageStream);
float imageWidth = image.getWidth(null) * 72f / imageResolution;
float imageHeight = image.getHeight(null) * 72f / imageResolution;

// Wir müssen die modifizierte Arbeitsmappe verwenden.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Fügt das OLE-Bild zu den Präsentationsressourcen hinzu.
imageStream.reset();
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// Create the OLE object frame.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```
```java
import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;

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

In diesem Ansatz lernen wir, wie man die Höhen der teilnehmenden Zeilen und die Breite der teilnehmenden Spalten skaliert, um eine benutzerdefinierte OLE‑Rahmengröße zu erreichen.

Angenommen, wir haben ein Excel‑Vorlagenblatt und möchten es als OLE‑Rahmen zu einer Präsentation hinzufügen. In diesem Szenario setzen wir die Größe des OLE‑Rahmens und skalieren die Größe der Zeilen und Spalten, die im OLE‑Rahmenbereich enthalten sind. Anschließend speichern wir die Arbeitsmappe in einen Stream, um die Änderungen anzuwenden, und konvertieren sie in ein Byte‑Array, um sie dem OLE‑Rahmen hinzuzufügen. Um die rote Meldung „EMBEDDED OLE OBJECT“ für den OLE‑Rahmen in PowerPoint zu vermeiden, erfassen wir zudem ein Bild der gewünschten Teile der Zeilen und Spalten in der Arbeitsmappe und setzen es als OLE‑Rahmen‑Bild.

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook("sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// Legt die angezeigte Größe fest, wenn die Arbeitsmappendatei als OLE-Objekt in PowerPoint verwendet wird.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

// Skaliert den Zellbereich, um in die Rahmengröße zu passen.
com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Wir müssen die modifizierte Arbeitsmappe verwenden.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Fügt das OLE-Bild zu den Präsentationsressourcen hinzu.
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// Erstellt den OLE-Objektrahmen.
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
import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;

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
{{% alert color="info" %}} 
Es gibt zwei Ansätze, um das Problem der Arbeitsblatt‑Skalierung zu beheben. Die Auswahl des geeigneten Ansatzes hängt von den spezifischen Anforderungen und dem Anwendungsfall ab. Beide Ansätze funktionieren gleichermaßen, unabhängig davon, ob die Präsentationen aus einer Vorlage oder von Grund auf erstellt werden. Darüber hinaus gibt es in dieser Lösung keine Begrenzung der Größe des OLE‑Objekt‑Rahmens. 
{{% /alert %}}

## **FAQ**

### Warum ändert ein eingebettetes Excel‑Arbeitsblatt seine Größe, wenn es in PowerPoint zum ersten Mal aktiviert wird?
Dies geschieht, weil Excel beim Aktivieren versucht, die ursprüngliche Fenstergröße beizubehalten, während der OLE‑Objekt‑Rahmen in PowerPoint eigene Abmessungen hat. PowerPoint und Excel verhandeln die Größe, um das Seitenverhältnis zu erhalten, was zu einer Skalierung führen kann.

### Ist es möglich, dieses Skalierungsproblem vollständig zu verhindern?
Ja. Durch Skalieren des OLE‑Rahmens, um die Größe des Excel‑Zellbereichs anzupassen, oder durch Skalieren des Zellbereichs, um die gewünschte OLE‑Rahmengröße zu erreichen, kann die unerwünschte Skalierung vermieden werden.

### Welche Skalierungsmethode sollte ich verwenden, OLE‑Rahmen‑Skalierung oder Zellbereichs‑Skalierung?
Wählen Sie **OLE‑Rahmen‑Skalierung**, wenn Sie die ursprünglichen Excel‑Zeilen‑ und Spaltengrößen beibehalten möchten. Wählen Sie **Zellbereichs‑Skalierung**, wenn Sie eine feste Größe für den OLE‑Rahmen in Ihrer Präsentation wünschen.

### Werden diese Lösungen funktionieren, wenn meine Präsentation auf einer Vorlage basiert?
Ja. Beide Lösungen funktionieren sowohl für Präsentationen, die aus Vorlagen erstellt wurden, als auch für solche, die von Grund auf neu erstellt werden.

### Gibt es eine Begrenzung der Größe des OLE‑Rahmens bei Verwendung dieser Methoden?
Nein. Sie können den OLE‑Objekt‑Rahmen beliebig groß machen, solange Sie die Skalierung entsprechend einstellen.

### Gibt es eine Möglichkeit, den Platzhaltertext „EMBEDDED OLE OBJECT“ in PowerPoint zu vermeiden?
Ja. Indem Sie einen Schnappschuss des gewünschten Excel‑Zellbereichs erstellen und ihn als Platzhalterbild des OLE‑Rahmens festlegen, können Sie ein benutzerdefiniertes Vorschau‑Bild anstelle des Standard‑Platzhalters anzeigen.

## **Verwandte Artikel**

[Erstellen eines Excel‑Diagramms und Einbetten in eine Präsentation als OLE‑Objekt](/slides/de/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
[OLE‑Objekte automatisch mithilfe eines MS PowerPoint‑Add‑Ins aktualisieren](/slides/de/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)