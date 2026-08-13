---
title: Arbeitslösung für die Größenanpassung von Arbeitsblättern
type: docs
weight: 20
url: /de/androidjava/working-solution-for-worksheet-resizing/
keywords:
- OLE
- Vorschaubild
- Bildskalierung
- Excel
- Arbeitsblatt
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Beheben Sie die OLE‑Größenänderung von Excel‑Arbeitsblättern in Präsentationen: zwei Möglichkeiten, Objektrahmen konsistent zu halten – den Rahmen oder das Blatt skalieren – für PPT‑ und PPTX‑Formate."
---
{{% alert color="info" %}}

Es wurde beobachtet, dass Excel‑Arbeitsblätter, die als OLE‑Objekte über Aspose‑Komponenten in eine PowerPoint‑Präsentation eingebettet werden, nach der ersten Aktivierung auf eine nicht identifizierbare Skalierung angepasst werden. Dieses Verhalten führt zu einem sichtbaren Unterschied zwischen dem Vor‑ und Nach‑Aktivierungszustand des OLE‑Objekts. Wir haben das Problem detailliert untersucht und eine Lösung bereitgestellt, die in diesem Artikel beschrieben wird.

{{% /alert %}}

## **Hintergrund**

Im Artikel [Manage OLE](/slides/de/androidjava/manage-ole/) haben wir erklärt, wie man mit Aspose.Slides für Android via Java ein OLE‑Rahmen zu einer PowerPoint‑Präsentation hinzufügt. Um das [object preview issue](/slides/de/androidjava/object-preview-issue-when-adding-oleobjectframe/) zu beheben, haben wir dem OLE‑Objekt‑Rahmen ein Bild des ausgewählten Arbeitsblattbereichs zugewiesen. In der erzeugten Präsentation wird das Excel‑Arbeitsbuch aktiviert, wenn Sie den OLE‑Objekt‑Rahmen, der das Arbeitsblattbild zeigt, doppelklicken. Endbenutzer können beliebige Änderungen am eigentlichen Excel‑Arbeitsbuch vornehmen und dann durch Klicken außerhalb des aktivierten Excel‑Arbeitsbuchs zur Folie zurückkehren. Beim Zurückkehren ändert sich die Größe des OLE‑Objekt‑Rahmens. Der Skalierungsfaktor variiert in Abhängigkeit von der Größe des OLE‑Objekt‑Rahmens und des eingebetteten Excel‑Arbeitsbuchs.

## **Ursache der Größenänderung**

Da das Excel‑Arbeitsbuch ein eigenes Fenster hat, versucht es beim ersten Aktivieren, seine ursprüngliche Größe beizubehalten. Der OLE‑Objekt‑Rahmen dagegen hat seine eigene Größe. Laut Microsoft verhandeln Excel und PowerPoint bei der Aktivierung des Arbeitsbuchs die Größe, um die korrekten Proportionen im Einbettungsprozess sicherzustellen. Die Größenänderung entsteht durch die Differenzen zwischen der Excel‑Fenstergröße und der Größe sowie Position des OLE‑Objekt‑Rahmens.

## **Lösungsansatz**

Es gibt zwei mögliche Lösungen, um den Skalierungseffekt zu vermeiden.

- Die Größe des OLE‑Rahmens in der PowerPoint‑Präsentation so skalieren, dass sie der Höhe und Breite der gewünschten Anzahl von Zeilen und Spalten im OLE‑Rahmen entspricht.
- Den OLE‑Rahmen unverändert lassen und die Größe der beteiligten Zeilen und Spalten skalieren, damit sie in die ausgewählte OLE‑Rahmengröße passen.

### **OLE‑Rahmengröße skalieren**

In diesem Ansatz lernen wir, wie man die OLE‑Rahmengröße der eingebetteten Excel‑Arbeitsmappe so einstellt, dass sie der kumulierten Größe der beteiligten Zeilen und Spalten im Excel‑Arbeitsblatt entspricht.

Angenommen, wir haben ein Vorlagen‑Excel‑Sheet und möchten es als OLE‑Rahmen zu einer Präsentation hinzufügen. In diesem Szenario wird die Größe des OLE‑Objekt‑Rahmens zunächst anhand der kumulierten Zeilenhöhen und Spaltenbreiten der entsprechenden Zeilen und Spalten im Arbeitsbuch berechnet. Anschließend setzen wir die Größe des OLE‑Rahmens auf diesen berechneten Wert. Um die rote Meldung „EMBEDDED OLE OBJECT“ für den OLE‑Rahmen in PowerPoint zu vermeiden, erfassen wir zudem ein Bild der gewünschten Zeilen‑ und Spaltenbereiche im Arbeitsbuch und setzen es als OLE‑Rahmen‑Bild.

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

// Setze die angezeigte Größe, wenn die Arbeitsbuchdatei als OLE-Objekt in PowerPoint verwendet wird.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Erhalte die Breite und Höhe des OLE-Bildes in Punkten.
Bitmap image = BitmapFactory.decodeStream(imageStream);
float imageWidth = image.getWidth() * 72f / imageResolution;
float imageHeight = image.getHeight() * 72f / imageResolution;

// Wir müssen das modifizierte Arbeitsbuch verwenden.
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

In diesem Ansatz lernen wir, wie man die Höhen der beteiligten Zeilen und die Breite der beteiligten Spalten so skaliert, dass sie einer benutzerdefinierten OLE‑Rahmengröße entsprechen.

Angenommen, wir haben ein Vorlagen‑Excel‑Sheet und möchten es als OLE‑Rahmen zu einer Präsentation hinzufügen. In diesem Szenario setzen wir die Größe des OLE‑Rahmens und skalieren die Größe der Zeilen und Spalten, die im OLE‑Rahmenbereich enthalten sind. Anschließend speichern wir das Arbeitsbuch in einen Stream, um die Änderungen anzuwenden, und konvertieren es in ein Byte‑Array, das dem OLE‑Rahmen hinzugefügt wird. Um die rote Meldung „EMBEDDED OLE OBJECT“ für den OLE‑Rahmen in PowerPoint zu vermeiden, erfassen wir zudem ein Bild der gewünschten Zeilen‑ und Spaltenbereiche im Arbeitsbuch und setzen es als OLE‑Rahmen‑Bild.

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

// Setze die angezeigte Größe, wenn die Arbeitsbuchdatei als OLE-Objekt in PowerPoint verwendet wird.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

// Skaliere den Zellbereich, damit er zur Rahmengröße passt.
com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Wir müssen das modifizierte Arbeitsbuch verwenden.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Füge das OLE-Bild zu den Präsentationsressourcen hinzu.
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// Erstelle den OLE-Objektrahmen.
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

Es gibt zwei Ansätze, um das Problem der Größenänderung des Arbeitsblatts zu beheben. Die Wahl des geeigneten Ansatzes hängt von den konkreten Anforderungen und dem Anwendungsfall ab. Beide Ansätze funktionieren gleich, egal ob die Präsentationen aus einer Vorlage oder von Grund auf erstellt werden. Zusätzlich gibt es in dieser Lösung keine Beschränkung für die Größe des OLE‑Objekt‑Rahmens.

{{% /alert %}}

## **FAQ**

### Warum ändert ein eingebettetes Excel‑Arbeitsblatt seine Größe, wenn es in PowerPoint zum ersten Mal aktiviert wird?

Das passiert, weil Excel versucht, bei der Aktivierung die ursprüngliche Fenstergröße beizubehalten, während der OLE‑Objekt‑Rahmen in PowerPoint eigene Abmessungen hat. PowerPoint und Excel verhandeln die Größe, um das Seitenverhältnis zu erhalten, was zu einer Größenänderung führen kann.

### Ist es möglich, dieses Größenänderungsproblem vollständig zu verhindern?

Ja. Durch Skalieren des OLE‑Rahmens auf die Größe des Excel‑Zellbereichs oder durch Skalieren des Zellbereichs auf die gewünschte OLE‑Rahmengröße können unerwünschte Größenänderungen vermieden werden.

### Welche Skalierungsmethode sollte ich verwenden, OLE‑Rahmenskalierung oder Zellbereichskalierung?

Wählen Sie **OLE‑Rahmenskalierung**, wenn Sie die ursprünglichen Excel‑Zeilen‑ und Spaltengrößen beibehalten möchten. Wählen Sie **Zellbereichskalierung**, wenn Sie eine feste Größe für den OLE‑Rahmen in Ihrer Präsentation benötigen.

### Funktionieren diese Lösungen, wenn meine Präsentation auf einer Vorlage basiert?

Ja. Beide Lösungen funktionieren sowohl für Präsentationen, die aus Vorlagen als auch von Grund auf erstellt wurden.

### Gibt es eine Größenbeschränkung für den OLE‑Rahmen bei Verwendung dieser Methoden?

Nein. Sie können den OLE‑Objekt‑Rahmen beliebig groß machen, solange Sie die Skalierung entsprechend einstellen.

### Gibt es eine Möglichkeit, den Platzhaltertext „EMBEDDED OLE OBJECT“ in PowerPoint zu vermeiden?

Ja. Indem Sie einen Schnappschuss des gewünschten Excel‑Zellbereichs erstellen und ihn als Platzhalter‑Bild des OLE‑Rahmens festlegen, können Sie ein benutzerdefiniertes Vorschaubild anstelle des Standard‑Platzhalters anzeigen.