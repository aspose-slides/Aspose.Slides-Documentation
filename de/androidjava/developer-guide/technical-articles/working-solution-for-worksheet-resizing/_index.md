---
title: Lösungsansatz für Arbeitsblattgrößenänderung
type: docs
weight: 20
url: /de/androidjava/working-solution-for-worksheet-resizing/
keywords:
- OLE
- Vorschaubild
- Bildgrößenänderung
- Excel
- Arbeitsblatt
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Beheben Sie die OLE‑Größenänderung von Excel‑Arbeitsblättern in Präsentationen: zwei Möglichkeiten, Objekt‑Frames konsistent zu halten — den Frame oder das Blatt skalieren — für PPT‑ und PPTX‑Formate."
---
{{% alert color="info" title="Note" %}}

Excel‑Arbeitsblätter, die als OLE‑Objekte in einer PowerPoint‑Präsentation mit Aspose‑Komponenten eingebettet sind, können nach ihrer ersten Aktivierung unerwartet ihre Größe ändern. Dieses Verhalten erzeugt einen sichtbaren Unterschied zwischen dem OLE‑Objekt vor und nach der Aktivierung. Dieser Artikel erklärt das Problem und beschreibt zwei Möglichkeiten, es zu beheben.

{{% /alert %}}

## **Hintergrund**

Im Artikel [OLE verwalten](/slides/de/androidjava/manage-ole/) haben wir erklärt, wie man mit Aspose.Slides für Android via Java einen OLE‑Rahmen zu einer PowerPoint‑Präsentation hinzufügt. Um das [object preview issue](/slides/de/androidjava/object-preview-issue-when-adding-oleobjectframe/) zu beheben, haben wir dem OLE‑Objekt‑Rahmen ein Bild des ausgewählten Arbeitsblattbereichs zugewiesen. In der Ausgabepäsentation wird beim Doppelklick auf den OLE‑Objekt‑Rahmen, der das Arbeitsblatt‑Bild zeigt, die Excel‑Arbeitsmappe aktiviert. Endbenutzer können beliebige Änderungen an der tatsächlichen Excel‑Arbeitsmappe vornehmen und dann zur Folie zurückkehren, indem sie außerhalb der aktivierten Excel‑Arbeitsmappe klicken. Die Größe des OLE‑Objekt‑Rahmens ändert sich, wenn der Benutzer zur Folie zurückkehrt. Der Vergrößerungs‑ bzw. Verkleinerungsfaktor variiert je nach Größe des OLE‑Objekt‑Rahmens und der eingebetteten Excel‑Arbeitsmappe.

## **Ursache der Größenänderung**

Da die Excel‑Arbeitsmappe ihr eigenes Fenster hat, versucht sie, bei der ersten Aktivierung ihre ursprüngliche Größe beizubehalten. Der OLE‑Objekt‑Rahmen hat hingegen seine eigene Größe. Laut Microsoft verhandeln Excel und PowerPoint bei der Aktivierung der Arbeitsmappe die Größe, um das korrekte Seitenverhältnis im Einbettungsprozess sicherzustellen. Die Größenänderung entsteht durch die Unterschiede zwischen der Excel‑Fenstergröße und der Größe bzw. Position des OLE‑Objekt‑Rahmens.

## **Lösungsansatz**

Es gibt zwei mögliche Lösungen, um den Größenänderungseffekt zu vermeiden.

- Skalieren Sie den OLE‑Rahmen in der PowerPoint‑Präsentation, sodass er die gesamte Höhe und Breite der ausgewählten Zeilen und Spalten abdeckt.
- Halten Sie die Größe des OLE‑Rahmens konstant und skalieren Sie die ausgewählten Zeilen und Spalten, damit sie darin passen.

### **OLE‑Rahmengröße skalieren**

Dieser Ansatz setzt die OLE‑Rahmengröße so, dass sie die gesamte Höhe und Breite der ausgewählten Zeilen und Spalten im eingebetteten Excel‑Arbeitsblatt entspricht.

Das Beispiel lädt eine vorhandene Excel‑Arbeitsmappe und wählt die ersten 10 Zeilen und 13 Spalten ihres ersten Arbeitsblatts anhand von nullbasierten Indizes aus. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) definiert den angezeigten Bereich. Die Vorschau wird mit 96 DPI gerendert und ihre Pixelabmessungen werden mit 72 Punkten pro Zoll in Punkte umgerechnet. [IShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) bettet die modifizierte Arbeitsmappe in einen Rahmen mit diesen Abmessungen ein. Die Vorschau wird über [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) zugewiesen, um den Platzhalter „EMBEDDED OLE OBJECT“ in der gespeicherten Präsentation zu ersetzen.

```java
import com.aspose.slides.*;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook( "sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// Festlegen der angezeigten Größe, wenn die Arbeitsmappendatei als OLE-Objekt in PowerPoint verwendet wird.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Breite und Höhe des OLE-Bildes in Punkten ermitteln.
Bitmap image = BitmapFactory.decodeStream(imageStream);
float imageWidth = image.getWidth() * 72f / imageResolution;
float imageHeight = image.getHeight() * 72f / imageResolution;

// Wir müssen die modifizierte Arbeitsmappe verwenden.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// OLE-Bild zu den Präsentationsressourcen hinzufügen.
imageStream.reset();
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// OLE-Objekt-Rahmen erstellen.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

Der Vorschau‑Helper setzt [PageSetup.setPrintArea](https://reference.aspose.com/cells/java/com.aspose.cells/pagesetup/#setPrintArea-java.lang.String-) auf den ausgewählten Bereich und entfernt Ränder, Kopf‑ und Fußzeilen. Mit aktiviertem [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/java/com.aspose.cells/imageorprintoptions/#setOnlyArea-boolean-) rendert [SheetRender.toImage](https://reference.aspose.com/cells/java/com.aspose.cells/sheetrender/#toImage-int-java.io.OutputStream-) den Bereich als PNG‑Bild. Der Helper gibt einen neuen Input‑Stream zurück, der das PNG‑Bild enthält und am Anfang positioniert ist, um ihn in der Präsentation zu verwenden.

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

Dieser Ansatz skaliert die Höhen der ausgewählten Zeilen und die Breiten der ausgewählten Spalten, sodass sie zu einer benutzerdefinierten OLE‑Rahmengröße passen.

Das Beispiel lädt eine vorhandene Excel‑Arbeitsmappe und wählt die ersten 10 Zeilen und 13 Spalten ihres ersten Arbeitsblatts anhand von nullbasierten Indizes aus. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) definiert den angezeigten Bereich, und der nachfolgende Helper skaliert diesen Bereich, damit er in einen Rahmen von 400 Punkten Breite und 100 Punkten Höhe passt. Nach dem Speichern der modifizierten Arbeitsmappe in einen Stream bettet [IShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) ihn mit der angegebenen Größe ein. Eine bei 96 DPI gerenderte Vorschau wird über [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) zugewiesen, sodass die gespeicherte Präsentation die ausgewählten Zellen anstelle des Standard‑Platzhalters anzeigt.

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

// Festlegen der angezeigten Größe, wenn die Arbeitsmappendatei als OLE-Objekt in PowerPoint verwendet wird.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

// Den Zellbereich skalieren, damit er in die Rahmengröße passt.
com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Wir müssen die modifizierte Arbeitsmappe verwenden.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// OLE-Bild zu den Präsentationsressourcen hinzufügen.
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// OLE-Objekt-Rahmen erstellen.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

Der Skalierungs‑Helper berechnet separate Breiten‑ und Höhenverhältnisse für den ausgewählten Bereich und erhält dabei die relativen Breiten seiner Spalten sowie die relativen Höhen seiner Zeilen. Die berechneten Abmessungen werden von Punkten in Zoll umgerechnet, bevor sie mit [Cells.setColumnWidthInch](https://reference.aspose.com/cells/java/com.aspose.cells/cells/#setColumnWidthInch-int-double-) und [Cells.setRowHeightInch](https://reference.aspose.com/cells/java/com.aspose.cells/cells/#setRowHeightInch-int-double-) angewendet. Der ausgewählte Bereich muss eine Breite und Höhe ungleich null aufweisen.

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

Dieser Vorschau‑Helper rendert den skalierten Bereich mithilfe von [SheetRender.toImage](https://reference.aspose.com/cells/java/com.aspose.cells/sheetrender/#toImage-int-java.io.OutputStream-). Er begrenzt [PageSetup.setPrintArea](https://reference.aspose.com/cells/java/com.aspose.cells/pagesetup/#setPrintArea-java.lang.String-) auf diesen Bereich, entfernt Ränder, Kopf‑ und Fußzeilen und gibt einen PNG‑Stream zurück, der am Anfang positioniert ist.

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

Es gibt zwei Ansätze, um das Problem der Arbeitsblatt‑Größenänderung zu beheben. Wählen Sie den Ansatz, der Ihren Anforderungen und Ihrem Anwendungsfall am besten entspricht. Beide Ansätze funktionieren gleich, unabhängig davon, ob die Präsentationen aus einer Vorlage oder von Grund auf erstellt werden. Zusätzlich gibt es in dieser Lösung keine Begrenzung der Größe des OLE‑Objekt‑Rahmens.

{{% /alert %}}

## **FAQ**

**Warum ändert ein eingebettetes Excel‑Arbeitsblatt seine Größe, wenn es in PowerPoint zum ersten Mal aktiviert wird?**

Das passiert, weil Excel versucht, bei der Aktivierung die ursprüngliche Fenstergröße beizubehalten, während der OLE‑Objekt‑Rahmen in PowerPoint eigene Abmessungen hat. PowerPoint und Excel verhandeln die Größe, um das Seitenverhältnis zu erhalten, was zu einer Größenänderung führen kann.

**Lässt sich dieses Größenproblem vollständig verhindern?**

Ja. Durch Skalieren des OLE‑Rahmens auf die Größe des Excel‑Zellbereichs oder durch Skalieren des Zellbereichs auf die gewünschte OLE‑Rahmengröße können unerwünschte Größenänderungen vermieden werden.

**Welche Skalierungsmethode sollte ich verwenden, OLE‑Rahmenskalierung oder Zellbereichskalierung?**

Wählen Sie **OLE‑Rahmenskalierung**, wenn Sie die ursprünglichen Zeilen‑ und Spaltengrößen von Excel beibehalten möchten. Wählen Sie **Zellbereichskalierung**, wenn Sie eine feste Größe für den OLE‑Rahmen in Ihrer Präsentation benötigen.

**Werden diese Lösungen funktionieren, wenn meine Präsentation auf einer Vorlage basiert?**

Ja. Beide Lösungen funktionieren für Präsentationen, die aus Vorlagen sowie von Grund auf erstellt wurden.

**Gibt es eine Begrenzung für die Größe des OLE‑Rahmens bei Verwendung dieser Methoden?**

Nein. Sie können den OLE‑Objekt‑Rahmen beliebig groß machen, solange Sie die Skalierung entsprechend einstellen.

**Gibt es eine Möglichkeit, den Platzhalter‑Text „EMBEDDED OLE OBJECT“ in PowerPoint zu vermeiden?**

Ja. Indem Sie einen Schnappschuss des gewünschten Excel‑Zellbereichs erstellen und ihn als Platzhalterbild des OLE‑Rahmens festlegen, können Sie ein individuelles Vorschau‑Bild anstelle des Standard‑Platzhalters anzeigen.

## **Verwandte Artikel**

[Erstellen eines Excel‑Diagramms und Einbetten in eine Präsentation als OLE‑Objekt](/slides/de/androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Aktualisieren von OLE‑Objekten automatisch mithilfe eines MS PowerPoint‑Add‑Ins](/slides/de/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)