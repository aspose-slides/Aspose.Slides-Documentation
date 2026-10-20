---
title: Arbeitslösung für die Größenanpassung von Arbeitsblättern
type: docs
weight: 20
url: /de/nodejs-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- Vorschaubild
- Bildskalierung
- Excel
- Arbeitsblatt
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Excel-Arbeitsblatt-OLE-Größenänderung in Präsentationen beheben: zwei Methoden, um Objekt‑Frames konsistent zu halten – den Frame oder das Blatt skalieren – für PPT‑ und PPTX‑Formate."
---
{{% alert color="info" title="Note" %}}

Excel‑Arbeitsblätter, die als OLE‑Objekte in einer PowerPoint‑Präsentation mithilfe von Aspose‑Komponenten eingebettet sind, können nach ihrer ersten Aktivierung unerwartet die Größe ändern. Dieses Verhalten erzeugt einen auffälligen visuellen Unterschied zwischen dem OLE‑Objekt vor und nach der Aktivierung. Dieser Artikel erklärt das Problem und beschreibt zwei Möglichkeiten, es zu beheben.

{{% /alert %}}

## **Hintergrund**

Im Artikel [OLE verwalten](/slides/de/nodejs-java/manage-ole/) haben wir erklärt, wie man mit Aspose.Slides für Node.js via Java einen OLE‑Frame zu einer PowerPoint‑Präsentation hinzufügt. Um das [Objekt‑Vorschau‑Problem](/slides/de/nodejs-java/object-preview-issue-when-adding-oleobjectframe/) zu lösen, haben wir dem OLE‑Object‑Frame ein Bild des ausgewählten Arbeitsblattbereichs zugewiesen. In der Ergebnis‑Präsentation wird beim Doppelklick auf den OLE‑Object‑Frame, der das Arbeitsblatt‑Bild anzeigt, die Excel‑Arbeitsmappe aktiviert. Endbenutzer können beliebige Änderungen an der eigentlichen Excel‑Arbeitsmappe vornehmen und dann durch Klicken außerhalb der aktivierten Excel‑Arbeitsmappe zur Folie zurückkehren. Die Größe des OLE‑Object‑Frames ändert sich, wenn der Benutzer zur Folie zurückkehrt. Der Skalierungsfaktor variiert je nach Größe des OLE‑Object‑Frames und der eingebetteten Excel‑Arbeitsmappe.

## **Ursache der Größenänderung**

Da die Excel‑Arbeitsmappe ihr eigenes Fenster hat, versucht sie bei der ersten Aktivierung ihre ursprüngliche Größe beizubehalten. Der OLE‑Object‑Frame hat hingegen seine eigene Größe. Laut Microsoft verhandeln Excel und PowerPoint bei der Aktivierung der Arbeitsmappe die Größe, um das korrekte Seitenverhältnis im Einbettungsprozess zu erhalten. Die Größenänderung entsteht durch die Unterschiede zwischen der Excel‑Fenstergröße und der Größe bzw. Position des OLE‑Object‑Frames.

## **Funktionsfähige Lösung**

Es gibt zwei mögliche Lösungen, um den Größenänderungseffekt zu vermeiden.

- Skalieren Sie den OLE‑Frame in der PowerPoint‑Präsentation, sodass er die Gesamthöhe und -breite der ausgewählten Zeilen und Spalten abdeckt.
- Halten Sie die Größe des OLE‑Frames konstant und skalieren Sie die ausgewählten Zeilen und Spalten, sodass sie hinein passen.

### **OLE‑Frame‑Größe skalieren**

Dieser Ansatz setzt die OLE‑Frame‑Größe so, dass sie der Gesamthöhe und -breite der ausgewählten Zeilen und Spalten im eingebetteten Excel‑Arbeitsblatt entspricht.

Das Beispiel lädt eine vorhandene Excel‑Arbeitsmappe und wählt die ersten 10 Zeilen und 13 Spalten ihres ersten Arbeitsblatts mittels nullbasierter Indizes aus. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/nodejs/aspose.cells/worksheetcollection/#setolesize) definiert den angezeigten Bereich. Die Vorschau wird mit 96 DPI gerendert und ihre Pixelmaße werden mit 72 Punkten pro Zoll in Punkte umgerechnet. [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addOleObjectFrame) bettet die modifizierte Arbeitsmappe in einen Frame mit diesen Abmessungen ein. Die Vorschau wird über [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) zugewiesen, um den Platzhalter „EMBEDDED OLE OBJECT“ in der gespeicherten Präsentation zu ersetzen.

Installieren Sie die Pakete `aspose.cells`, `aspose.slides.via.java` und `java` und legen Sie `sample.xlsx` im Arbeitsverzeichnis ab. Für jeden Ansatz führen Sie zuerst das Vorbereitungsskript und anschließend das Einbettungsskript in einem separaten Node.js‑Prozess im selben Verzeichnis aus. Die beiden Aspose‑Pakete initialisieren die Java‑Brücke unabhängig voneinander.

Speichern Sie dieses Vorbereitungsskript als `prepare-frame-scaled.js` und führen Sie es mit `node prepare-frame-scaled.js` aus. Es erzeugt `frame-scaled.xlsx` und `frame-scaled.png`.

```javascript
const cells = require("aspose.cells");

function createOleImage(cellRange, imageResolution, imagePath) {
    const worksheet = cellRange.getWorksheet();
    const pageSetup = worksheet.getPageSetup();
    pageSetup.setPrintArea(cellRange.getAddress());
    pageSetup.setLeftMargin(0);
    pageSetup.setRightMargin(0);
    pageSetup.setTopMargin(0);
    pageSetup.setBottomMargin(0);
    pageSetup.clearHeaderFooter();

    const imageOptions = new cells.ImageOrPrintOptions();
    imageOptions.setImageType(cells.ImageType.PNG);
    imageOptions.setVerticalResolution(imageResolution);
    imageOptions.setHorizontalResolution(imageResolution);
    imageOptions.setOnePagePerSheet(true);
    imageOptions.setOnlyArea(true);

    const sheetRender = new cells.SheetRender(worksheet, imageOptions);
    sheetRender.toImage(0, imagePath);
}

function prepareWorkbook(outputName) {
    const workbook = new cells.Workbook("sample.xlsx");
    try {
        const startRow = 0;
        const rowCount = 10;
        const startColumn = 0;
        const columnCount = 13;
        const worksheet = workbook.getWorksheets().get(0);
        const lastRow = startRow + rowCount - 1;
        const lastColumn = startColumn + columnCount - 1;
        workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

        const cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);

        createOleImage(cellRange, 96, outputName + ".png");
        workbook.save(outputName + ".xlsx", cells.SaveFormat.XLSX);
        return true;
    } finally {
        workbook.dispose();
    }
}

prepareWorkbook("frame-scaled");

// Alle synchronen Arbeiten sind abgeschlossen; stoppen Sie den Java-Bridge-Prozess.
process.exit(0);
```

Speichern Sie dieses Einbettungsskript als `embed-frame-scaled.js` und führen Sie es mit `node embed-frame-scaled.js` aus. Es liest diese Dateien und erzeugt `frame-scaled.pptx`.

```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

function embedWorkbook(inputName, useFixedFrame) {
    const imageBuffer = fs.readFileSync(inputName + ".png");
    const imageBytes = java.newArray("byte", Array.from(imageBuffer));
    const workbookBuffer = fs.readFileSync(inputName + ".xlsx");
    const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));

    const image = slides.Images.fromData(imageBytes);
    try {
        const imageResolution = 96;
        const frameWidth = useFixedFrame ? 400 : image.getWidth() * 72 / imageResolution;
        const frameHeight = useFixedFrame ? 100 : image.getHeight() * 72 / imageResolution;

        const presentation = new slides.Presentation();
        try {
            const slide = presentation.getSlides().get_Item(0);
            const dataInfo = new slides.OleEmbeddedDataInfo(workbookBytes, "xlsx");
            const oleFrame = slide.getShapes().addOleObjectFrame(java.newFloat(10), java.newFloat(10), java.newFloat(frameWidth), java.newFloat(frameHeight), dataInfo);
            const previewImage = presentation.getImages().addImage(image);
            oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);
            oleFrame.setObjectIcon(false);

            presentation.save(inputName + ".pptx", slides.SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    } finally {
        image.dispose();
    }
}

embedWorkbook("frame-scaled", false);

// Alle synchronen Arbeiten sind abgeschlossen; stoppen Sie den Java-Bridge-Prozess.
process.exit(0);
```

Der Vorschilfe‑Code setzt [PageSetup.setPrintArea](https://reference.aspose.com/cells/nodejs/aspose.cells/pagesetup/#setprintarea) auf den ausgewählten Bereich und entfernt Ränder, Kopf‑ und Fußzeilen. Mit aktiviertem [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/nodejs/aspose.cells/imageorprintoptions/#setonlyarea) rendert [SheetRender.toImage](https://reference.aspose.com/cells/nodejs/aspose.cells/sheetrender/#toimage) den Bereich als PNG‑Bild. Die Hilfsroutine speichert das PNG‑Bild in einer Datei zur Verwendung in der Präsentation.

### **Zellbereichsgröße skalieren**

Dieser Ansatz skaliert die Höhen der ausgewählten Zeilen und die Breiten der ausgewählten Spalten, sodass sie in eine benutzerdefinierte OLE‑Frame‑Größe passen.

Das Beispiel lädt eine vorhandene Excel‑Arbeitsmappe und wählt die ersten 10 Zeilen und 13 Spalten ihres ersten Arbeitsblatts mittels nullbasierter Indizes aus. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/nodejs/aspose.cells/worksheetcollection/#setolesize) definiert den angezeigten Bereich, und die Hilfsroutine skaliert diesen Bereich, sodass er in einen Frame von 400 Punkten Breite und 100 Punkten Höhe passt. Nach dem Speichern der modifizierten Arbeitsmappe in einer Datei bettet [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addOleObjectFrame) sie mit der angegebenen Größe ein. Eine mit 96 DPI gerenderte Vorschau wird über [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) zugewiesen, sodass die gespeicherte Präsentation die ausgewählten Zellen anstelle des Standard‑Platzhalters anzeigt.

Speichern Sie dieses Vorbereitungsskript als `prepare-cells-scaled.js` und führen Sie es mit `node prepare-cells-scaled.js` aus. Es erzeugt `cells-scaled.xlsx` und `cells-scaled.png`.

```javascript
const cells = require("aspose.cells");

function scaleCellRange(cellRange, width, height) {
    const rangeWidth = cellRange.getWidth();
    const rangeHeight = cellRange.getHeight();
    if (rangeWidth <= 0 || rangeHeight <= 0) {
        console.error("The selected range must have nonzero width and height.");
        return false;
    }

    const worksheetCells = cellRange.getWorksheet().getCells();
    for (let i = 0; i < cellRange.getColumnCount(); i++) {
        const columnIndex = cellRange.getFirstColumn() + i;
        const columnWidth = worksheetCells.getColumnWidth(columnIndex, false, cells.CellsUnitType.POINT);
        const widthInInches = columnWidth * width / rangeWidth / 72;
        worksheetCells.setColumnWidthInch(columnIndex, widthInInches);
    }
    for (let i = 0; i < cellRange.getRowCount(); i++) {
        const rowIndex = cellRange.getFirstRow() + i;
        const rowHeight = worksheetCells.getRowHeight(rowIndex, false, cells.CellsUnitType.POINT);
        const heightInInches = rowHeight * height / rangeHeight / 72;
        worksheetCells.setRowHeightInch(rowIndex, heightInInches);
    }
    return true;
}

function createOleImage(cellRange, imageResolution, imagePath) {
    const worksheet = cellRange.getWorksheet();
    const pageSetup = worksheet.getPageSetup();
    pageSetup.setPrintArea(cellRange.getAddress());
    pageSetup.setLeftMargin(0);
    pageSetup.setRightMargin(0);
    pageSetup.setTopMargin(0);
    pageSetup.setBottomMargin(0);
    pageSetup.clearHeaderFooter();

    const imageOptions = new cells.ImageOrPrintOptions();
    imageOptions.setImageType(cells.ImageType.PNG);
    imageOptions.setVerticalResolution(imageResolution);
    imageOptions.setHorizontalResolution(imageResolution);
    imageOptions.setOnePagePerSheet(true);
    imageOptions.setOnlyArea(true);

    const sheetRender = new cells.SheetRender(worksheet, imageOptions);
    sheetRender.toImage(0, imagePath);
}

function prepareWorkbook(outputName, scaleCells) {
    const workbook = new cells.Workbook("sample.xlsx");
    try {
        const startRow = 0;
        const rowCount = 10;
        const startColumn = 0;
        const columnCount = 13;
        const worksheet = workbook.getWorksheets().get(0);
        const lastRow = startRow + rowCount - 1;
        const lastColumn = startColumn + columnCount - 1;
        workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

        const cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
        if (scaleCells && !scaleCellRange(cellRange, 400, 100)) {
            return false;
        }

        createOleImage(cellRange, 96, outputName + ".png");
        workbook.save(outputName + ".xlsx", cells.SaveFormat.XLSX);
        return true;
    } finally {
        workbook.dispose();
    }
}

const cellsPrepared = prepareWorkbook("cells-scaled", true);

// Alle synchronen Arbeiten sind abgeschlossen; stoppen Sie den Java-Bridge-Prozess.
process.exit(cellsPrepared ? 0 : 1);
```

Speichern Sie dieses Einbettungsskript als `embed-cells-scaled.js` und führen Sie es mit `node embed-cells-scaled.js` aus. Es liest diese Dateien und erzeugt `cells-scaled.pptx`.

```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

function embedWorkbook(inputName, useFixedFrame) {
    const imageBuffer = fs.readFileSync(inputName + ".png");
    const imageBytes = java.newArray("byte", Array.from(imageBuffer));
    const workbookBuffer = fs.readFileSync(inputName + ".xlsx");
    const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));

    const image = slides.Images.fromData(imageBytes);
    try {
        const imageResolution = 96;
        const frameWidth = useFixedFrame ? 400 : image.getWidth() * 72 / imageResolution;
        const frameHeight = useFixedFrame ? 100 : image.getHeight() * 72 / imageResolution;

        const presentation = new slides.Presentation();
        try {
            const slide = presentation.getSlides().get_Item(0);
            const dataInfo = new slides.OleEmbeddedDataInfo(workbookBytes, "xlsx");
            const oleFrame = slide.getShapes().addOleObjectFrame(java.newFloat(10), java.newFloat(10), java.newFloat(frameWidth), java.newFloat(frameHeight), dataInfo);
            const previewImage = presentation.getImages().addImage(image);
            oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);
            oleFrame.setObjectIcon(false);

            presentation.save(inputName + ".pptx", slides.SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    } finally {
        image.dispose();
    }
}

embedWorkbook("cells-scaled", true);

// Alle synchronen Arbeiten sind abgeschlossen; stoppen Sie den Java-Bridge-Prozess.
process.exit(0);
```

Die Skalierungshilfe berechnet getrennte Breiten‑ und Höhenverhältnisse für den ausgewählten Bereich und bewahrt dabei die relativen Spaltenbreiten und Zeilenhöhen. Sie wandelt die berechneten Abmessungen von Punkten in Zoll um, bevor sie mit [Cells.setColumnWidthInch](https://reference.aspose.com/cells/nodejs/aspose.cells/cells/#setcolumnwidthinch) und [Cells.setRowHeightInch](https://reference.aspose.com/cells/nodejs/aspose.cells/cells/#setrowheightinch) angewendet werden. Der ausgewählte Bereich muss eine von Null verschiedene Breite und Höhe besitzen.

Diese Vorschilfe rendert den skalierten Bereich mit [SheetRender.toImage](https://reference.aspose.com/cells/nodejs/aspose.cells/sheetrender/#toimage). Sie beschränkt [PageSetup.setPrintArea](https://reference.aspose.com/cells/nodejs/aspose.cells/pagesetup/#setprintarea) auf diesen Bereich, entfernt Ränder, Kopf‑ und Fußzeilen und speichert das PNG‑Bild in einer Datei.

## **Fazit**

{{% alert color="info" title="Note" %}}

Es gibt zwei Ansätze, das Problem mit der Größenänderung des Arbeitsblatts zu beheben. Wählen Sie den Ansatz, der Ihren Anforderungen und Ihrem Anwendungsfall am besten entspricht. Beide Ansätze funktionieren gleich, egal ob die Präsentationen aus einer Vorlage oder von Grund auf erstellt werden. Zusätzlich gibt es in dieser Lösung keine Beschränkung der Größe des OLE‑Object‑Frames.

{{% /alert %}}

## **FAQ**

**Warum ändert ein eingebettetes Excel‑Arbeitsblatt seine Größe, wenn es in PowerPoint zum ersten Mal aktiviert wird?**

Dies geschieht, weil Excel versucht, bei der Aktivierung die ursprüngliche Fenstergröße beizubehalten, während der OLE‑Object‑Frame in PowerPoint eigene Abmessungen hat. PowerPoint und Excel verhandeln die Größe, um das Seitenverhältnis zu erhalten, was zu einer Skalierung führen kann.

**Lässt sich dieses Skalierungsproblem vollständig verhindern?**

Ja. Durch Skalieren des OLE‑Frames an die Größe des Excel‑Zellbereichs oder durch Skalieren des Zellbereichs an die gewünschte OLE‑Frame‑Größe können Sie unerwünschte Größenänderungen vermeiden.

**Welche Skalierungsmethode sollte ich verwenden, OLE‑Frame‑Skalierung oder Zellbereichs‑Skalierung?**

Wählen Sie **OLE‑Frame‑Skalierung**, wenn Sie die ursprünglichen Zeilen‑ und Spaltengrößen von Excel beibehalten möchten. Wählen Sie **Zellbereichs‑Skalierung**, wenn Sie eine feste Größe für den OLE‑Frame in Ihrer Präsentation benötigen.

**Funktionieren diese Lösungen, wenn meine Präsentation auf einer Vorlage basiert?**

Ja. Beide Lösungen funktionieren sowohl für aus Vorlagen erstellte als auch für von Grund auf neu erstellte Präsentationen.

**Gibt es eine Größenbeschränkung für den OLE‑Frame, wenn ich diese Methoden verwende?**

Nein. Sie können den OLE‑Object‑Frame beliebig groß machen, solange Sie die Skalierung entsprechend einstellen.

**Wie kann ich den Platzhaltertext „EMBEDDED OLE OBJECT“ in PowerPoint vermeiden?**

Ja. Indem Sie einen Screenshot des gewünschten Excel‑Zellbereichs aufnehmen und ihn als Platzhalterbild des OLE‑Frames festlegen, können Sie ein benutzerdefiniertes Vorschau‑Bild anstelle des Standard‑Platzhalters anzeigen.

## **Verwandte Artikel**

[Erstellen eines Excel‑Diagramms und Einbetten in eine Präsentation als OLE‑Objekt](/slides/de/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Automatisches Aktualisieren von OLE‑Objekten mithilfe eines MS PowerPoint‑Add‑Ins](/slides/de/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)