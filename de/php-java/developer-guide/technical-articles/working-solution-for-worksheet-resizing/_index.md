---
title: Lösungsansatz für die Größenänderung von Arbeitsblättern
type: docs
weight: 20
url: /de/php-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- Vorschau-Bild
- Bildgrößenanpassung
- Excel
- Arbeitsblatt
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Beheben Sie die OLE‑Größenänderung von Excel‑Arbeitsblättern in Präsentationen: zwei Möglichkeiten, Objekt‑Frames konsistent zu halten – entweder den Frame oder das Blatt skalieren – für PPT‑ und PPTX‑Formate."
---
{{% alert color="info" title="Note" %}}
Excel-Arbeitsblätter, die als OLE-Objekte in einer PowerPoint-Präsentation mit Aspose-Komponenten eingebettet sind, können sich nach ihrer ersten Aktivierung unerwartet in der Größe ändern. Dieses Verhalten erzeugt einen wahrnehmbaren visuellen Unterschied zwischen dem OLE-Objekt vor und nach der Aktivierung. Dieser Artikel erklärt das Problem und beschreibt zwei Möglichkeiten, es zu beheben.
{{% /alert %}}

## **Hintergrund**

Im Artikel [OLE verwalten](/slides/de/php-java/manage-ole/) erklärten wir, wie man mit Aspose.Slides für PHP via Java einen OLE‑Rahmen zu einer PowerPoint‑Präsentation hinzufügt. Um das [Problem mit der Objektvorschau](/slides/de/php-java/object-preview-issue-when-adding-oleobjectframe/) zu beheben, haben wir dem OLE‑Objektrahmen ein Bild des ausgewählten Arbeitsblattbereichs zugewiesen. In der ausgegebenen Präsentation wird das OLE‑Objektrahmen, das das Arbeitsblattbild zeigt, bei Doppelklick aktiviert und die Excel‑Arbeitsmappe geöffnet. Endbenutzer können beliebige Änderungen an der tatsächlichen Excel‑Arbeitsmappe vornehmen und anschließend zur Folie zurückkehren, indem sie außerhalb der aktivierten Excel‑Arbeitsmappe klicken. Die Größe des OLE‑Objektrahmens ändert sich, wenn der Benutzer zur Folie zurückkehrt. Der Skalierungsfaktor variiert je nach Größe des OLE‑Objektrahmens und der eingebetteten Excel‑Arbeitsmappe.

## **Ursache der Größenänderung**

Da die Excel‑Arbeitsmappe ihre eigene Fenstergröße hat, versucht sie, bei der ersten Aktivierung ihre ursprüngliche Größe beizubehalten. Der OLE‑Objektrahmen hat hingegen seine eigene Größe. Laut Microsoft verhandeln Excel und PowerPoint bei der Aktivierung der Arbeitsmappe die Größe, um sicherzustellen, dass das richtige Seitenverhältnis im Einbettungsprozess erhalten bleibt. Die Größenänderung entsteht durch die Unterschiede zwischen der Fenstergröße von Excel und der Größe sowie Position des OLE‑Objektrahmens.

## **Lösungsansatz**

Es gibt zwei mögliche Lösungen, um den Skalierungseffekt zu vermeiden.

- Skalieren Sie den OLE‑Rahmen in der PowerPoint‑Präsentation, sodass er die Gesamthöhe und -breite der ausgewählten Zeilen und Spalten entspricht.
- Behalten Sie die Größe des OLE‑Rahmens konstant und skalieren Sie die ausgewählten Zeilen und Spalten, um darin zu passen.

### **OLE‑Rahmengröße skalieren**

Dieser Ansatz setzt die OLE‑Rahmengröße so, dass sie der Gesamthöhe und -breite der ausgewählten Zeilen und Spalten im eingebetteten Excel‑Arbeitsblatt entspricht.

Das Beispiel lädt eine vorhandene Excel‑Arbeitsmappe und wählt die ersten 10 Zeilen und 13 Spalten des ersten Arbeitsblatts mithilfe nullbasierter Indizes aus. [WorksheetCollection::setOleSize](https://reference.aspose.com/cells/php/aspose.cells/worksheetcollection/#setolesize) definiert den angezeigten Bereich. Die Vorschau wird mit 96 DPI gerendert und ihre Pixeldimensionen werden mit 72 Punkten pro Zoll in Punkte umgerechnet. [ShapeCollection::addOleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addOleObjectFrame) bettet die modifizierte Arbeitsmappe in einen Rahmen mit diesen Abmessungen ein. Die Vorschau wird über [OleObjectFrame::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) zugewiesen, um den Platzhalter „EMBEDDED OLE OBJECT“ in der gespeicherten Präsentation zu ersetzen.

```php
use aspose\cells\SaveFormat as CellsSaveFormat;
use aspose\cells\Workbook;
use aspose\slides\Images;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook("sample.xlsx");
try {
    $worksheet = $workbook->getWorksheets()->get(0);
    $startRow = 0;
    $rowCount = 10;
    $startColumn = 0;
    $columnCount = 13;
    $lastRow = $startRow + $rowCount - 1;
    $lastColumn = $startColumn + $columnCount - 1;
    $workbook->getWorksheets()->setOleSize($startRow, $lastRow, $startColumn, $lastColumn);
    $cellRange = $worksheet->getCells()->createRange($startRow, $startColumn, $rowCount, $columnCount);

    $imageResolution = 96;
    $imageStream = CreateOleImage($cellRange, $imageResolution);

    // Betten Sie die modifizierte Arbeitsmappe ein und behalten Sie Binärdaten in Java-Byte-Arrays bei.
    $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
    $workbook->save($workbookStream, CellsSaveFormat::XLSX);
    $workbookBytes = $workbookStream->toByteArray();
    $image = Images::fromStream($imageStream);
    try {
        $frameWidth = java_values($image->getWidth()) * 72.0 / $imageResolution;
        $frameHeight = java_values($image->getHeight()) * 72.0 / $imageResolution;
        $presentation = new Presentation();
        try {
            $slide = $presentation->getSlides()->get_Item(0);
            $dataInfo = new OleEmbeddedDataInfo($workbookBytes, "xlsx");
            $oleFrame = $slide->getShapes()->addOleObjectFrame(10, 10, $frameWidth, $frameHeight, $dataInfo);
            $previewImage = $presentation->getImages()->addImage($image);
            $oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($previewImage);
            $oleFrame->setObjectIcon(false);
            $presentation->save("output.pptx", SaveFormat::Pptx);
        } finally {
            $presentation->dispose();
        }
    } finally {
        $image->dispose();
        $imageStream->close();
    }
} finally {
    $workbook->dispose();
}
```

Der Vorschau‑Helper setzt [PageSetup::setPrintArea](https://reference.aspose.com/cells/php/aspose.cells/pagesetup/#printarea) auf den ausgewählten Bereich und entfernt Ränder, Kopf‑ und Fußzeilen. Mit aktiviertem [ImageOrPrintOptions::setOnlyArea](https://reference.aspose.com/cells/php/aspose.cells/imageorprintoptions/#onlyarea) rendert [SheetRender::toImage](https://reference.aspose.com/cells/php/aspose.cells/sheetrender/#toimage) den Bereich als PNG‑Bild. Der Helper gibt einen neuen Input‑Stream zurück, der das PNG‑Bild enthält und zu Beginn positioniert ist, um in der Präsentation verwendet zu werden.

```php
use aspose\cells\ImageOrPrintOptions;
use aspose\cells\ImageType;
use aspose\cells\SheetRender;
use Java as JavaObject;

function CreateOleImage($cellRange, $imageResolution) {
    $pageSetup = $cellRange->getWorksheet()->getPageSetup();
    $pageSetup->setPrintArea($cellRange->getAddress());
    $pageSetup->setLeftMargin(0);
    $pageSetup->setRightMargin(0);
    $pageSetup->setTopMargin(0);
    $pageSetup->setBottomMargin(0);
    $pageSetup->clearHeaderFooter();

    $imageOptions = new ImageOrPrintOptions();
    $imageOptions->setImageType(ImageType::PNG);
    $imageOptions->setVerticalResolution($imageResolution);
    $imageOptions->setHorizontalResolution($imageResolution);
    $imageOptions->setOnePagePerSheet(true);
    $imageOptions->setOnlyArea(true);

    $worksheet = $cellRange->getWorksheet();
    $sheetRender = new SheetRender($worksheet, $imageOptions);
    $imageStream = new JavaObject("java.io.ByteArrayOutputStream");
    $sheetRender->toImage(0, $imageStream);
    $imageBytes = $imageStream->toByteArray();
    return new JavaObject("java.io.ByteArrayInputStream", $imageBytes);
}
```

### **Zellbereichsgröße skalieren**

Dieser Ansatz skaliert die Höhen der ausgewählten Zeilen und die Breiten der ausgewählten Spalten, um einer benutzerdefinierten OLE‑Rahmengröße zu entsprechen.

Das Beispiel lädt eine vorhandene Excel‑Arbeitsmappe und wählt die ersten 10 Zeilen und 13 Spalten des ersten Arbeitsblatts mithilfe nullbasierter Indizes aus. [WorksheetCollection::setOleSize](https://reference.aspose.com/cells/php/aspose.cells/worksheetcollection/#setolesize) definiert den angezeigten Bereich, und der untenstehende Helper skaliert diesen Bereich, sodass er in einen Rahmen von 400 Punkten Breite und 100 Punkten Höhe passt. Nach dem Speichern der modifizierten Arbeitsmappe in einen Stream bettet [ShapeCollection::addOleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addOleObjectFrame) sie mit der angegebenen Größe ein. Eine mit 96 DPI gerenderte Vorschau wird über [OleObjectFrame::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) zugewiesen, sodass die gespeicherte Präsentation die ausgewählten Zellen anstelle des Standard‑Platzhalters anzeigt.

```php
use aspose\cells\SaveFormat as CellsSaveFormat;
use aspose\cells\Workbook;
use aspose\slides\Images;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook("sample.xlsx");
try {
    $worksheet = $workbook->getWorksheets()->get(0);
    $startRow = 0;
    $rowCount = 10;
    $startColumn = 0;
    $columnCount = 13;
    $lastRow = $startRow + $rowCount - 1;
    $lastColumn = $startColumn + $columnCount - 1;
    $workbook->getWorksheets()->setOleSize($startRow, $lastRow, $startColumn, $lastColumn);
    $cellRange = $worksheet->getCells()->createRange($startRow, $startColumn, $rowCount, $columnCount);
    $frameWidth = 400;
    $frameHeight = 100;
    ScaleCellRange($cellRange, $frameWidth, $frameHeight);

    $imageResolution = 96;
    $imageStream = CreateOleImage($cellRange, $imageResolution);

    // Betten Sie die modifizierte Arbeitsmappe ein und behalten Sie Binärdaten in Java-Byte-Arrays bei.
    $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
    $workbook->save($workbookStream, CellsSaveFormat::XLSX);
    $workbookBytes = $workbookStream->toByteArray();
    $image = Images::fromStream($imageStream);
    try {
        $presentation = new Presentation();
        try {
            $slide = $presentation->getSlides()->get_Item(0);
            $dataInfo = new OleEmbeddedDataInfo($workbookBytes, "xlsx");
            $oleFrame = $slide->getShapes()->addOleObjectFrame(10, 10, $frameWidth, $frameHeight, $dataInfo);
            $previewImage = $presentation->getImages()->addImage($image);
            $oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($previewImage);
            $oleFrame->setObjectIcon(false);
            $presentation->save("output.pptx", SaveFormat::Pptx);
        } finally {
            $presentation->dispose();
        }
    } finally {
        $image->dispose();
        $imageStream->close();
    }
} finally {
    $workbook->dispose();
}
```

Der Skalierungs‑Helper berechnet separate Breiten‑ und Höhenverhältnisse für den ausgewählten Bereich und bewahrt die relativen Breiten seiner Spalten sowie die relativen Höhen seiner Zeilen. Er konvertiert die berechneten Abmessungen von Punkten in Zoll, bevor er sie mit [Cells::setColumnWidthInch](https://reference.aspose.com/cells/php/aspose.cells/cells/#setcolumnwidthinch) und [Cells::setRowHeightInch](https://reference.aspose.com/cells/php/aspose.cells/cells/#setrowheightinch) anwendet. Der ausgewählte Bereich muss eine nicht‑null Breite und Höhe besitzen.

```php
use aspose\cells\CellsUnitType;

// Breite und Höhe sind die erwarteten Abmessungen des Zellbereichs in Punkten.
function ScaleCellRange($cellRange, $width, $height) {
    $rangeWidth = java_values($cellRange->getWidth());
    $rangeHeight = java_values($cellRange->getHeight());
    $cells = $cellRange->getWorksheet()->getCells();
    $columnCount = java_values($cellRange->getColumnCount());
    $rowCount = java_values($cellRange->getRowCount());
    $firstColumn = java_values($cellRange->getFirstColumn());
    $firstRow = java_values($cellRange->getFirstRow());

    for ($i = 0; $i < $columnCount; $i++) {
        $columnIndex = $firstColumn + $i;
        $columnWidth = java_values($cells->getColumnWidth($columnIndex, false, CellsUnitType::POINT));
        $newColumnWidth = $columnWidth * $width / $rangeWidth;
        $widthInInches = $newColumnWidth / 72.0;
        $cells->setColumnWidthInch($columnIndex, $widthInInches);
    }

    for ($i = 0; $i < $rowCount; $i++) {
        $rowIndex = $firstRow + $i;
        $rowHeight = java_values($cells->getRowHeight($rowIndex, false, CellsUnitType::POINT));
        $newRowHeight = $rowHeight * $height / $rangeHeight;
        $heightInInches = $newRowHeight / 72.0;
        $cells->setRowHeightInch($rowIndex, $heightInInches);
    }
}
```

Dieser Vorschau‑Helper rendert den skalierten Bereich mithilfe von [SheetRender::toImage](https://reference.aspose.com/cells/php/aspose.cells/sheetrender/#toimage). Er begrenzt [PageSetup::setPrintArea](https://reference.aspose.com/cells/php/aspose.cells/pagesetup/#printarea) auf diesen Bereich, entfernt Ränder, Kopf‑ und Fußzeilen und gibt einen PNG‑Stream zurück, der zu Beginn positioniert ist.

```php
use aspose\cells\ImageOrPrintOptions;
use aspose\cells\ImageType;
use aspose\cells\SheetRender;
use Java as JavaObject;

function CreateOleImage($cellRange, $imageResolution) {
    $pageSetup = $cellRange->getWorksheet()->getPageSetup();
    $pageSetup->setPrintArea($cellRange->getAddress());
    $pageSetup->setLeftMargin(0);
    $pageSetup->setRightMargin(0);
    $pageSetup->setTopMargin(0);
    $pageSetup->setBottomMargin(0);
    $pageSetup->clearHeaderFooter();

    $imageOptions = new ImageOrPrintOptions();
    $imageOptions->setImageType(ImageType::PNG);
    $imageOptions->setVerticalResolution($imageResolution);
    $imageOptions->setHorizontalResolution($imageResolution);
    $imageOptions->setOnePagePerSheet(true);
    $imageOptions->setOnlyArea(true);

    $worksheet = $cellRange->getWorksheet();
    $sheetRender = new SheetRender($worksheet, $imageOptions);
    $imageStream = new JavaObject("java.io.ByteArrayOutputStream");
    $sheetRender->toImage(0, $imageStream);
    $imageBytes = $imageStream->toByteArray();
    return new JavaObject("java.io.ByteArrayInputStream", $imageBytes);
}
```

## **Fazit**

{{% alert color="info" title="Note" %}}
Es gibt zwei Ansätze, um das Problem der Größenänderung des Arbeitsblatts zu beheben. Wählen Sie den Ansatz, der am besten zu Ihren Anforderungen und Ihrem Anwendungsfall passt. Beide Ansätze funktionieren gleichermaßen, egal ob die Präsentationen aus einer Vorlage oder von Grund auf erstellt werden. Zusätzlich gibt es in dieser Lösung keine Begrenzung für die Größe des OLE‑Objektrahmens.
{{% /alert %}}

## **FAQ**

**Warum ändert ein eingebettetes Excel‑Arbeitsblatt seine Größe, wenn es in PowerPoint zum ersten Mal aktiviert wird?**  
Das passiert, weil Excel bei der Aktivierung versucht, die ursprüngliche Fenstergröße beizubehalten, während der OLE‑Objektrahmen in PowerPoint seine eigenen Abmessungen hat. PowerPoint und Excel verhandeln die Größe, um das Seitenverhältnis zu erhalten, was die Größenänderung verursachen kann.

**Lässt sich dieses Größenänderungsproblem vollständig verhindern?**  
Ja. Durch Skalieren des OLE‑Rahmens, sodass er zur Excel‑Zellbereichsgröße passt, oder durch Skalieren des Zellbereichs, um die gewünschte OLE‑Rahmengröße zu erreichen, kann eine unerwünschte Größenänderung verhindert werden.

**Welche Skalierungsmethode sollte ich verwenden, OLE‑Rahmenskalierung oder Zellbereichsskalierung?**  
Wählen Sie **OLE‑Rahmenskalierung**, wenn Sie die ursprünglichen Zeilen‑ und Spaltengrößen von Excel beibehalten möchten. Wählen Sie **Zellbereichsskalierung**, wenn Sie eine feste Größe für den OLE‑Rahmen in Ihrer Präsentation wünschen.

**Werden diese Lösungen funktionieren, wenn meine Präsentation auf einer Vorlage basiert?**  
Ja. Beide Lösungen funktionieren sowohl für aus Vorlagen erstellte Präsentationen als auch für solche, die von Grund auf neu erstellt werden.

**Gibt es eine Begrenzung für die Größe des OLE‑Rahmens bei Verwendung dieser Methoden?**  
Nein. Der OLE‑Objektrahmen kann beliebig groß sein, solange die Skalierung entsprechend eingestellt wird.

**Gibt es eine Möglichkeit, den Platzhaltertext „EMBEDDED OLE OBJECT“ in PowerPoint zu vermeiden?**  
Ja. Durch Aufnehmen eines Schnappschusses des gewünschten Excel‑Zellbereichs und Setzen dieses Bildes als Platzhalterbild des OLE‑Rahmens können Sie ein benutzerdefiniertes Vorschaubild anstelle des Standard‑Platzhalters anzeigen.

## **Verwandte Artikel**

[Erstellen eines Excel‑Diagramms und Einbetten in eine Präsentation als OLE‑Objekt](/slides/de/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[OLE‑Objekte automatisch mit einem MS PowerPoint‑Add‑In aktualisieren](/slides/de/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)