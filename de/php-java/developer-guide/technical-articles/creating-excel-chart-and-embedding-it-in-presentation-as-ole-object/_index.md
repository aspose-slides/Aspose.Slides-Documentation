---
title: Excel-Diagramme erstellen und als OLE-Objekte in Präsentationen einbetten
type: docs
weight: 30
url: /de/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel-Diagramm
- Diagramm einbetten
- OLE-Objekt
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Erstellen Sie ein Excel-Diagramm mit Aspose.Cells für PHP via Java und betten Sie die Arbeitsmappe in eine PowerPoint-Präsentation mit Aspose.Slides für PHP via Java ein, einschließlich einer Diagramm-Vorschau."
---
## **Übersicht**

Dieser Artikel zeigt, wie man ein Excel‑Säulendiagramm mit Aspose.Cells for PHP via Java erstellt und die Arbeitsmappe in eine PowerPoint‑Präsentation mit Aspose.Slides for PHP via Java einbettet. Die eingebettete Arbeitsmappe enthält sowohl die Quelldaten als auch das Diagramm. Eine separate PNG‑Vorschau zeigt das Diagramm auf der Folie, bevor das OLE‑Objekt aktiviert wird.

Das Ergebnis ist ein eingebettetes Excel‑Objekt, kein nativer PowerPoint‑Diagramm. Das Bearbeiten der Arbeitsmappe über OLE erfordert eine Desktop‑Anwendung, die OLE‑Aktivierung unterstützt, und eine kompatible Excel‑Installation.

## **Voraussetzungen**

Konfigurieren Sie Aspose.Cells for PHP via Java und Aspose.Slides for PHP via Java mit derselben PHP/Java Bridge‑Instanz. Laden Sie beide PHP‑Wrapper und stellen Sie die Java‑Bibliotheken beider Produkte der Bridge zur Verfügung. Microsoft Office ist nicht erforderlich, um die Präsentation mit diesen Bibliotheken zu erzeugen.

Es werden keine Eingabedateien benötigt: Das Beispiel erstellt die Daten und das Diagramm im Speicher und schreibt anschließend `OutputChart.pptx` in das aktuelle Arbeitsverzeichnis. Wenden Sie Lizenzen für beide Produkte an, wenn Sie außerhalb des Evaluationsmodus arbeiten.

## **Wie das Einbetten funktioniert**

1. Erstellen Sie eine Arbeitsmappe mit einem Daten‑Arbeitsblatt und einem Diagrammblatt.
1. Setzen Sie das Diagrammblatt als aktiv, sodass die Arbeitsmappe mit dem Diagramm geöffnet wird.
1. Legen Sie den OLE‑Anzeigebereich der Arbeitsmappe fest und rendern Sie das Diagramm zu PNG.
1. Speichern Sie die Arbeitsmappe als XLSX im Speicher und betten Sie die Bytes in eine Folie ein.
1. Weisen Sie das PNG als Vorschau des OLE‑Objekts zu und speichern Sie die Präsentation als PPTX.

Der Anzeigebereich der Arbeitsmappe und der Rahmen auf der Folie haben unterschiedliche Rollen. [WorksheetCollection::setOleSize](https://reference.aspose.com/cells/php/aspose.cells/worksheetcollection/#setolesize) nimmt nullbasierte Start‑/End‑Zeilen‑ und Spaltenindizes. [ChartCollection::add](https://reference.aspose.com/cells/php/aspose.cells/chartcollection/#add) dagegen verwendet die obere Zeile, linke Spalte, untere Zeile und rechte Spalte. Das Beispiel verwendet Zeilenindex 55 und Spaltenindex 25 als untere‑rechte Grenzen; diese Werte sind Layout‑Entscheidungen, nicht die Anzahl der Datenzeilen oder -spalten.

Der Folienrahmen verwendet Punkte. Das Beispiel passt ihn innerhalb der Folie an und zentriert ihn, wobei das Seitenverhältnis des PNG beibehalten wird, anstatt die Vorschau zu strecken, um die Folie zu füllen.

## **Diagramm erstellen und einbetten**

Das nachfolgende vollständige Beispiel füllt `DataSheet` mit vier Zeilen und fünf Spalten von Werten. Jede Zeile wird zu einer Diagrammserie. `ChartSheet` wird als aktives Blatt ausgewählt, bevor die Arbeitsmappe gespeichert wird.

Die Arbeitsmappe wird ausdrücklich als XLSX gespeichert, passend zur `xlsx`‑Erweiterung, die an [OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/) übergeben wird. Java‑numerische Ergebnisse werden mit `java_values` in PHP umgewandelt, bevor arithmetische Operationen ausgeführt werden, während Binärdaten in Java‑Byte‑Arrays verbleiben. Das PNG wird direkt aus seinen Bytes geladen, ohne eine Zwischenumwandlung in ein Bitmap. Das Zuweisen über [OleObjectFrame::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) ersetzt den Standard‑OLE‑Platzhalter.

```php
<?php
use aspose\cells\ChartType;
use aspose\cells\ImageOrPrintOptions;
use aspose\cells\ImageType;
use aspose\cells\SaveFormat as CellsSaveFormat;
use aspose\cells\SheetType;
use aspose\cells\Workbook;
use aspose\slides\Images;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook();
try {
    $dataSheet = $workbook->getWorksheets()->get(0);
    $dataSheet->setName("DataSheet");
    $values = [
        [67, 44, 46, 43, 24],
        [86, 64, 97, 29, 40],
        [68, 89, 78, 69, 38],
        [91, 48, 60, 26, 25]
    ];
    foreach ($values as $row => $rowValues) {
        foreach ($rowValues as $column => $value) {
            $dataSheet->getCells()->get($row, $column)->putValue($value);
        }
    }

    $chartSheetIndex = java_values($workbook->getWorksheets()->add(SheetType::CHART));
    $chartSheet = $workbook->getWorksheets()->get($chartSheetIndex);
    $chartSheet->setName("ChartSheet");
    $lastChartRow = 55;
    $lastChartColumn = 25;
    $chartIndex = java_values($chartSheet->getCharts()->add(ChartType::COLUMN, 0, 0, $lastChartRow, $lastChartColumn));
    $chart = $chartSheet->getCharts()->get($chartIndex);
    for ($row = 1; $row <= count($values); $row++) {
        $chart->getNSeries()->add("DataSheet!A" . $row . ":E" . $row, false);
    }
    $workbook->getWorksheets()->setActiveSheetIndex($chartSheetIndex);
    $workbook->getWorksheets()->setOleSize(0, $lastChartRow, 0, $lastChartColumn);

    // Behalte das PNG und XLSX als Java-Byte-Arrays bei, wenn sie an Slides übergeben werden.
    $imageOptions = new ImageOrPrintOptions();
    $imageOptions->setImageType(ImageType::PNG);
    $chartImageStream = new JavaObject("java.io.ByteArrayOutputStream");
    $chart->toImage($chartImageStream, $imageOptions);
    $chartImageBytes = $chartImageStream->toByteArray();

    $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
    $workbook->save($workbookStream, CellsSaveFormat::XLSX);
    $workbookBytes = $workbookStream->toByteArray();

    $chartImage = Images::fromData($chartImageBytes);
    try {
        $presentation = new Presentation();
        try {
            $slide = $presentation->getSlides()->get_Item(0);
            $slideWidth = java_values($presentation->getSlideSize()->getSize()->getWidth());
            $slideHeight = java_values($presentation->getSlideSize()->getSize()->getHeight());
            $imageWidth = java_values($chartImage->getWidth());
            $imageHeight = java_values($chartImage->getHeight());

            // Passe die Vorschau an und zentriere sie, dabei das Seitenverhältnis beibehalten.
            $scale = min($slideWidth / $imageWidth, $slideHeight / $imageHeight);
            $frameWidth = $imageWidth * $scale;
            $frameHeight = $imageHeight * $scale;
            $frameX = ($slideWidth - $frameWidth) / 2;
            $frameY = ($slideHeight - $frameHeight) / 2;

            $embeddedData = new OleEmbeddedDataInfo($workbookBytes, "xlsx");
            $oleFrame = $slide->getShapes()->addOleObjectFrame($frameX, $frameY, $frameWidth, $frameHeight, $embeddedData);
            $previewImage = $presentation->getImages()->addImage($chartImage);
            $oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($previewImage);
            $presentation->save("OutputChart.pptx", SaveFormat::Pptx);
        } finally {
            $presentation->dispose();
        }
    } finally {
        $chartImage->dispose();
    }
} finally {
    $workbook->dispose();
}
```

## **Erwartetes Ergebnis**

`OutputChart.pptx` enthält eine Folie mit einer eingebetteten Excel‑Arbeitsmappe und einer Diagramm‑Vorschau. Die Arbeitsmappe enthält die Originaldaten und ein Säulendiagramm mit vier Serien. Die Vorschau ist auf der Folie zentriert und behält ihre Proportionen bei.

![Excel-Säulendiagramm als Vorschau einer eingebetteten Arbeitsmappe angezeigt](excel-chart-ole-preview.png)

In einer kompatiblen Desktop‑PowerPoint‑Umgebung mit verfügbarem Excel kann man durch Doppelklick das Objekt aktivieren und die eingebettete Arbeitsmappe bearbeiten. Aktivierung und Bearbeitung hängen von der OLE‑Unterstützung und den Sicherheitseinstellungen der Host‑Anwendung ab.

## **FAQ**

**Warum wird ein Vorschaubild benötigt?**

Die eingebettete Arbeitsmappe und ihre Folienvorschau sind separate Inhalte. Stellen Sie ein Diagrammbild bereit, damit die Folie das Diagramm anstelle des Standard‑„EMBEDDED OLE OBJECT“-Platzhalters anzeigt. Siehe [Object Preview Issue when Adding OleObjectFrame](/slides/de/php-java/object-preview-issue-when-adding-oleobjectframe/).

**Wird die Vorschau automatisch aktualisiert, wenn ich die Arbeitsmappe im Code ändere?**

Betrachten Sie die Vorschau als Schnappschuss. Wenn Sie Arbeitsmappendaten programmgesteuert ändern, erzeugen Sie das Diagrammbild erneut und ersetzen sowohl die Vorschau als auch die eingebetteten Arbeitsmappendaten.

**Kann ich XLS anstelle von XLSX verwenden?**

Ja. Speichern Sie die Arbeitsmappe im XLS‑Format und verwenden Sie `xls` als Erweiterung der eingebetteten Daten. Die Erweiterung muss dem tatsächlichen Arbeitsmappenformat entsprechen; das bloße Ändern der Erweiterung konvertiert die Daten nicht.

**Warum kann sich die Größe des Objekts nach der Aktivierung ändern?**

Die Host‑Anwendung kann die Darstellung des OLE‑Objekts aktualisieren, wenn sie die Arbeitsmappe aktiviert. Sowohl der OLE‑Anzeigebereich der Arbeitsmappe als auch die Abmessungen des Folienrahmens spielen eine Rolle. Siehe [Working Solution for Chart Resizing in PPTX](/slides/de/java/working-solution-for-chart-resizing-in-pptx/).

## **Verwandte Abschnitte**

- [Lösung für Diagrammgrößenanpassung in PPTX](/slides/de/java/working-solution-for-chart-resizing-in-pptx/)
- [Problem bei der Objektvorschau beim Hinzufügen von OleObjectFrame](/slides/de/php-java/object-preview-issue-when-adding-oleobjectframe/)
- [OLE‑Objekte verwalten](/slides/de/php-java/manage-ole/)