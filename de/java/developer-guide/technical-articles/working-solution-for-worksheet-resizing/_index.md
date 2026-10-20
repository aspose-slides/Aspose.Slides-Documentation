---
title: Lösung für die Größenänderung von Arbeitsblättern
type: docs
weight: 20
url: /de/java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- Vorschau-Bild
- Bildgrößenanpassung
- Excel
- Arbeitsblatt
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Beheben Sie die OLE-Größenänderung von Excel-Arbeitsblättern in Präsentationen: zwei Möglichkeiten, Objektrahmen konsistent zu halten - entweder den Rahmen oder das Blatt skalieren - in den Formaten PPT und PPTX."
---
{{% alert color="info" title="Note" %}}
Excel-Arbeitsblätter, die als OLE-Objekte in einer PowerPoint-Präsentation mit Aspose-Komponenten eingebettet sind, können sich nach der ersten Aktivierung unerwartet in der Größe verändern. Dieses Verhalten erzeugt einen deutlichen visuellen Unterschied zwischen dem OLE-Objekt vor und nach der Aktivierung. Dieser Artikel erklärt das Problem und beschreibt zwei Möglichkeiten, es zu beheben.
{{% /alert %}}

## **Hintergrund**

Im Artikel [Manage OLE](/slides/de/java/manage-ole/) haben wir erklärt, wie man mit Aspose.Slides für Java einen OLE‑Rahmen zu einer PowerPoint‑Präsentation hinzufügt. Um das [object preview issue](/slides/de/java/object-preview-issue-when-adding-oleobjectframe/) zu beheben, haben wir dem OLE‑Objektrahmen ein Bild des ausgewählten Arbeitsblattbereichs zugewiesen. In der ausgegebenen Präsentation wird das Excel‑Arbeitsbuch aktiviert, wenn Sie den OLE‑Objektrahmen, der das Arbeitsblattbild zeigt, doppelklicken. Endbenutzer können beliebige Änderungen am eigentlichen Excel‑Arbeitsbuch vornehmen und dann zur Folie zurückkehren, indem sie außerhalb des aktivierten Excel‑Arbeitsbuchs klicken. Die Größe des OLE‑Objektrahmens ändert sich, wenn der Benutzer zur Folie zurückkehrt. Der Skalierungsfaktor variiert je nach Größe des OLE‑Objektrahmens und des eingebetteten Excel‑Arbeitsbuchs.

## **Ursache der Größenänderung**

Da das Excel‑Arbeitsbuch seine eigene Fenstergröße hat, versucht es, nach der ersten Aktivierung seine ursprüngliche Größe beizubehalten. Andererseits hat der OLE‑Objektrahmen seine eigene Größe. Laut Microsoft verhandeln Excel und PowerPoint bei der Aktivierung des Excel‑Arbeitsbuchs die Größe, um die korrekten Proportionen im Einbettungsprozess sicherzustellen. Die Größenänderung entsteht durch die Unterschiede zwischen der Fenstergröße von Excel und der Größe sowie Position des OLE‑Objektrahmens.

## **Lösungsansatz**

Es gibt zwei mögliche Lösungen, um den Größenänderungseffekt zu vermeiden.

- Skalieren Sie den OLE‑Rahmen in der PowerPoint‑Präsentation, damit er der Gesamthöhe und -breite der ausgewählten Zeilen und Spalten entspricht.
- Halten Sie die Größe des OLE‑Rahmens konstant und skalieren Sie die ausgewählten Zeilen und Spalten, damit sie hinein passen.

### **OLE-Rahmengröße skalieren**

Dieser Ansatz setzt die OLE‑Rahmengröße so, dass sie der Gesamthöhe und -breite der ausgewählten Zeilen und Spalten im eingebetteten Excel‑Arbeitsblatt entspricht.

Das Beispiel lädt ein vorhandenes Excel‑Arbeitsbuch und wählt die ersten 10 Zeilen und 13 Spalten des ersten Arbeitsblatts über nullbasierte Indizes aus. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) definiert den angezeigten Bereich. Die Vorschau wird mit 96 DPI gerendert und ihre Pixelabmessungen mithilfe von 72 Punkten pro Zoll in Punkte umgerechnet. [IShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) bettet das modifizierte Arbeitsbuch in einen Rahmen mit diesen Abmessungen ein. Die Vorschau wird über [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) zugewiesen, um den Platzhalter „EMBEDDED OLE OBJECT“ in der gespeicherten Präsentation zu ersetzen.
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

// Setzen Sie die angezeigte Größe, wenn die Arbeitsbuchdatei als OLE-Objekt in PowerPoint verwendet wird.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Get the width and height of the OLE image in points.
Image image = ImageIO.read(imageStream);
float imageWidth = image.getWidth(null) * 72f / imageResolution;
float imageHeight = image.getHeight(null) * 72f / imageResolution;

// Wir müssen das modifizierte Arbeitsbuch verwenden.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Add the OLE image to the presentation resources.
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

Der Vorschau‑Hilfswrapper setzt [PageSetup.setPrintArea](https://reference.aspose.com/cells/java/com.aspose.cells/pagesetup/#setPrintArea-java.lang.String-) auf den ausgewählten Bereich und entfernt Ränder, Kopf‑ und Fußzeilen. Mit aktiviertem [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/java/com.aspose.cells/imageorprintoptions/#setOnlyArea-boolean-) rendert [SheetRender.toImage](https://reference.aspose.com/cells/java/com.aspose.cells/sheetrender/#toImage-int-java.io.OutputStream-) den Bereich als PNG‑Bild. Der Helfer gibt einen neuen Input‑Stream zurück, der das PNG‑Bild enthält und am Anfang positioniert ist, um ihn in der Präsentation zu verwenden.
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

Dieser Ansatz skaliert die Höhen der ausgewählten Zeilen und die Breiten der ausgewählten Spalten, um eine benutzerdefinierte OLE‑Rahmengröße zu erreichen.

Das Beispiel lädt ein vorhandenes Excel‑Arbeitsbuch und wählt die ersten 10 Zeilen und 13 Spalten des ersten Arbeitsblatts über nullbasierte Indizes aus. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) definiert den angezeigten Bereich, und der untenstehende Helfer skaliert diesen Bereich, sodass er in einen Rahmen von 400 Punkten Breite und 100 Punkten Höhe passt. Nach dem Speichern des modifizierten Arbeitsbuchs in einen Stream bettet [IShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) es mit der angegebenen Größe ein. Eine mit 96 DPI gerenderte Vorschau wird über [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) zugewiesen, sodass die gespeicherte Präsentation die ausgewählten Zellen anstelle des Standard‑Platzhalters zeigt.
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

// Setzen Sie die angezeigte Größe, wenn die Arbeitsbuchdatei als OLE-Objekt in PowerPoint verwendet wird.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

// Skalieren Sie den Zellbereich, damit er in die Rahmengröße passt.
com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Wir müssen das modifizierte Arbeitsbuch verwenden.
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

Der Skalierungs‑Helfer berechnet separate Breiten‑ und Höhenverhältnisse für den ausgewählten Bereich und bewahrt dabei die relativen Spaltenbreiten sowie die relativen Zeilenhöhen. Er wandelt die berechneten Abmessungen von Punkten in Zoll um, bevor er sie mit [Cells.setColumnWidthInch](https://reference.aspose.com/cells/java/com.aspose.cells/cells/#setColumnWidthInch-int-double-) und [Cells.setRowHeightInch](https://reference.aspose.com/cells/java/com.aspose.cells/cells/#setRowHeightInch-int-double-) anwendet. Der ausgewählte Bereich muss eine von Null verschiedene Breite und Höhe besitzen.
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

Dieser Vorschau‑Helfer rendert den skalierten Bereich mit [SheetRender.toImage](https://reference.aspose.com/cells/java/com.aspose.cells/sheetrender/#toImage-int-java.io.OutputStream-). Er begrenzt [PageSetup.setPrintArea](https://reference.aspose.com/cells/java/com.aspose.cells/pagesetup/#setPrintArea-java.lang.String-) auf diesen Bereich, entfernt Ränder, Kopf‑ und Fußzeilen und gibt einen PNG‑Stream zurück, der am Anfang positioniert ist.
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
{{% alert color="info" title="Note" %}}
Es gibt zwei Ansätze, um das Problem der Größenänderung des Arbeitsblatts zu beheben. Wählen Sie den Ansatz, der am besten zu Ihren Anforderungen und Anwendungsfällen passt. Beide Ansätze funktionieren identisch, egal ob die Präsentationen aus einer Vorlage oder von Grund auf erstellt werden. Zusätzlich gibt es in dieser Lösung keine Begrenzung für die Größe des OLE‑Objektrahmens.
{{% /alert %}}

## **FAQ**

**Warum ändert ein eingebettetes Excel‑Arbeitsblatt seine Größe, wenn es in PowerPoint erstmals aktiviert wird?**  
Dies geschieht, weil Excel bei der Aktivierung versucht, die ursprüngliche Fenstergröße beizubehalten, während der OLE‑Objektrahmen in PowerPoint seine eigenen Abmessungen hat. PowerPoint und Excel verhandeln die Größe, um das Seitenverhältnis zu erhalten, was zu einer Größenänderung führen kann.

**Ist es möglich, dieses Größenänderungsproblem vollständig zu verhindern?**  
Ja. Durch Skalieren des OLE‑Rahmens, sodass er der Größe des Excel‑Zellbereichs entspricht, oder durch Skalieren des Zellbereichs, sodass er in die gewünschte OLE‑Rahmengröße passt, können Sie unerwünschte Größenänderungen verhindern.

**Welche Skalierungsmethode sollte ich verwenden, OLE‑Rahmen‑Skalierung oder Zellbereichs‑Skalierung?**  
Wählen Sie **OLE‑Rahmen‑Skalierung**, wenn Sie die ursprünglichen Zeilen‑ und Spaltengrößen von Excel beibehalten möchten. Wählen Sie **Zellbereichs‑Skalierung**, wenn Sie eine feste Größe für den OLE‑Rahmen in Ihrer Präsentation wünschen.

**Funktionieren diese Lösungen, wenn meine Präsentation auf einer Vorlage basiert?**  
Ja. Beide Lösungen funktionieren sowohl für aus Vorlagen erstellte als auch für von Grund auf erstellte Präsentationen.

**Gibt es eine Begrenzung für die Größe des OLE‑Rahmens bei Verwendung dieser Methoden?**  
Nein. Sie können den OLE‑Objektrahmen beliebig groß machen, solange Sie die Skalierung entsprechend einstellen.

**Gibt es eine Möglichkeit, den Platzhaltertext „EMBEDDED OLE OBJECT“ in PowerPoint zu vermeiden?**  
Ja. Indem Sie ein Schnappschuss des gewünschten Excel‑Zellbereichs erstellen und ihn als Platzhalterbild für den OLE‑Rahmen festlegen, können Sie ein benutzerdefiniertes Vorschau‑Bild anstelle des Standard‑Platzhalters anzeigen.

## **Verwandte Artikel**

[Erstellen eines Excel‑Diagramms und Einbetten in eine Präsentation als OLE‑Objekt](/slides/de/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[OLE‑Objekte automatisch mit einem MS PowerPoint‑Add‑In aktualisieren](/slides/de/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)