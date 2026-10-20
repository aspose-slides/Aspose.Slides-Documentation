---
title: Arbeitsfähige Lösung für Diagrammgrößenanpassung in PPTX
type: docs
weight: 40
url: /de/php-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- Diagrammgrößenanpassung
- Excel-Diagramm
- OLE-Objekt
- Diagramm einbetten
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Behebt unerwartete Diagrammgrößenänderungen in PPTX beim Einsatz eingebetteter Excel-OLE-Objekte mit Aspose.Slides für PHP via Java. Legen Sie feste Diagrammabmessungen fest, um die Größen von Diagramm und OLE‑Rahmen konsistent zu halten."
---
## **Übersicht**

Excel-Diagramme, die als OLE-Objekte in PowerPoint-Präsentationen mit Aspose-Komponenten eingebettet sind, können nach ihrer ersten Aktivierung die Größe ändern. Dies kann zu einem deutlichen Unterschied im Aussehen des Diagramms vor und nach der Aktivierung führen. Dieser Artikel erklärt, warum die Größenänderung auftritt, und zeigt, wie man sie verhindert, indem man feste Diagrammgrößen an den OLE‑Rahmen anpasst.

In [Excel-Diagramme erstellen und als OLE-Objekte in Präsentationen einbetten](/slides/de/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) haben wir erklärt, wie man ein Excel-Diagramm mit Aspose.Cells für PHP via Java erstellt und es in einer PowerPoint‑Präsentation mit Aspose.Slides für PHP via Java einbettet. Um das [Objektvorschauproblem](/slides/de/php-java/object-preview-issue-when-adding-oleobjectframe/) zu beheben, haben wir das Diagrammbild dem OLE‑Objekt‑Rahmen des Diagramms zugewiesen. In der ausgegebenen Präsentation wird das OLE‑Objekt‑Rahmen, das das Diagrammbild anzeigt, bei einem Doppelklick aktiviert und das Excel‑Diagramm öffnet sich. Benutzer können die eingebettete Excel‑Arbeitsmappe bearbeiten und anschließend zur Folie zurückkehren, indem sie außerhalb der aktivierten Arbeitsmappe klicken. Die Größe des OLE‑Objekt‑Rahmens ändert sich, wenn der Benutzer zur Folie zurückkehrt, und der Größenänderungsfaktor variiert je nach den ursprünglichen Größen sowohl des OLE‑Objekt‑Rahmens als auch der eingebetteten Excel‑Arbeitsmappe.

## **Ursache der Größenänderung**

Die eingebettete Excel‑Arbeitsmappe hat eigene Fensterabmessungen, die Excel beim ersten Aktivieren des Objekts beizubehalten versucht. Der OLE‑Rahmen auf der Folie hat unabhängige Abmessungen. Wenn die Excel‑Arbeitsmappe aktiviert wird, verhandeln Excel und PowerPoint die Größe des Objekts, um dessen Proportionen im Einbettungsprozess beizubehalten. Unterschiede zwischen dem Arbeitsmappen‑Fenster und dem OLE‑Rahmen können daher das Objekt vergrößern oder verkleinern.

## **Funktionsfähige Lösung**

Passen Sie die Diagrammgröße an den OLE‑Rahmen auf der Folie an und halten Sie die Diagrammabmessungen unabhängig vom Arbeitsmappen‑Fenster. Diese Lösung funktioniert sowohl mit einer neuen Präsentation als auch mit einer vorhandenen Vorlage.

Das Beispiel erfordert Aspose.Cells für PHP via Java und Aspose.Slides für PHP via Java. Konfigurieren Sie beide Produkte mit derselben PHP/Java‑Bridge‑Instanz, laden Sie beide PHP‑Wrapper und stellen Sie beide Java‑Bibliotheken der Bridge zur Verfügung. Es werden keine Eingabedateien benötigt. Es erstellt ein einfaches Säulendiagramm auf einem aktiven Diagrammblatt und bettet die Arbeitsmappe im XLS‑Format ein. Es wird kein Diagrammvorschau‑Bild zugewiesen; das Diagramm wird sichtbar, wenn das OLE‑Objekt in PowerPoint aktiviert wird.

Das Beispiel erstellt eine neue Präsentation mit einem 9.5 × 4‑Zoll‑OLE‑Rahmen, der 0.5 Zoll vom linken Rand und 1 Zoll vom oberen Rand positioniert ist. Folienkoordinaten und -abmessungen werden in Punkten angegeben (72 Punkte pro Zoll). Für eine vorhandene Präsentation siehe [Verwenden einer Vorlage](#use-a-template).

## **Festgelegte Diagrammgröße festlegen**

Setzen Sie [Chart::setSizeWithWindow](https://reference.aspose.com/cells/php/aspose.cells/chart/#sizewithwindow) auf false, damit die Diagrammabmessungen unabhängig vom Arbeitsmappen‑Fenster sind. Setzen Sie die [Chart::getChartObject](https://reference.aspose.com/cells/php/aspose.cells/chart/#chartobject)‑Abmessungen mittels [Shape::setWidth](https://reference.aspose.com/cells/php/aspose.cells/shape/#width) und [Shape::setHeight](https://reference.aspose.com/cells/php/aspose.cells/shape/#height) fest, wobei Punkte mit 96 Pixel pro Zoll in Pixel umgerechnet werden: Ein Rahmen von 684 × 288 Punkten entspricht einem Diagramm von 912 × 384 Pixel. Setzen Sie [Chart::setPrintSize](https://reference.aspose.com/cells/php/aspose.cells/chart/#printsize) auf den CUSTOM‑Wert von [PrintSizeType](https://reference.aspose.com/cells/php/aspose.cells/printsizetype/). Das Beispiel bettet die Arbeitsmappe mit [ShapeCollection::addOleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addOleObjectFrame) ein und speichert eine Präsentation mit einem 9.5 × 4‑Zoll‑OLE‑Rahmen.

Java‑numerische Ergebnisse werden mit `java_values` konvertiert, bevor sie als PHP‑Indizes verwendet werden. Die Arbeitsmappen‑Bytes bleiben in einem Java‑Byte‑Array, wenn sie an [OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/) übergeben werden.

```php
<?php
use aspose\cells\ChartType;
use aspose\cells\FileFormatType;
use aspose\cells\PrintSizeType;
use aspose\cells\SheetType;
use aspose\cells\Workbook;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook();
try {
    $dataSheet = $workbook->getWorksheets()->get(0);
    $dataSheet->setName("Data");
    $dataSheet->getCells()->get("A1")->putValue(10);
    $dataSheet->getCells()->get("A2")->putValue(20);

    $chartSheetIndex = java_values($workbook->getWorksheets()->add(SheetType::CHART));
    $chartSheet = $workbook->getWorksheets()->get($chartSheetIndex);
    $chartIndex = java_values($chartSheet->getCharts()->add(ChartType::COLUMN, 0, 0, 20, 10));
    $chart = $chartSheet->getCharts()->get($chartIndex);
    $chart->getNSeries()->add("Data!A1:A2", true);
    $workbook->getWorksheets()->setActiveSheetIndex($chartSheetIndex);

    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Folienkoordinaten und -abmessungen sind in Punkten (72 Punkte pro Zoll).
        $width = 684; // 9,5 Zoll.
        $height = 288; // 4 Zoll.

        $chart->setSizeWithWindow(false);
        // Punkte in Diagrammpixel umrechnen mit 96 Pixel pro Zoll.
        $chart->getChartObject()->setWidth((int)($width / 72 * 96));
        $chart->getChartObject()->setHeight((int)($height / 72 * 96));
        $chart->setPrintSize(PrintSizeType::CUSTOM);

        $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
        $workbook->save($workbookStream, FileFormatType::EXCEL_97_TO_2003);
        $workbookBytes = $workbookStream->toByteArray();
        $dataInfo = new OleEmbeddedDataInfo($workbookBytes, "xls");
        $slide->getShapes()->addOleObjectFrame(36, 72, $width, $height, $dataInfo);

        $presentation->save("chart-fixed-size.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
} finally {
    $workbook->dispose();
}
```

## **Vorlage verwenden**

Die Größenlogik ist für eine vorhandene Präsentation identisch. Um das Beispiel anzupassen:

1. Laden Sie die Vorlagenpräsentation anstelle einer leeren Präsentation.
1. Prüfen Sie, ob die erste Folie mindestens drei Formen enthält, und verwenden Sie dann die Form mit Index 2 als Platzhalter.
1. Entnehmen Sie die Rahmenbreite und -höhe dieser Form anstelle der festen Werte 684 und 288. Lassen Sie die Berechnungen unverändert.
1. Fügen Sie den OLE‑Rahmen an der Position des Platzhalters ein, anstatt die festen Koordinaten 36 und 72 zu verwenden.
1. Entfernen Sie den Platzhalter, bevor Sie die Präsentation speichern.

## **FAQ**

**Warum ändert mein eingebettetes Excel‑Diagramm nach der Aktivierung in PowerPoint die Größe?**

Das passiert, weil Excel beim ersten Aktivieren versucht, die ursprüngliche Fenstergröße wiederherzustellen, während der OLE‑Objekt‑Rahmen in PowerPoint eigene Abmessungen hat. PowerPoint und Excel verhandeln die Größe, um das Seitenverhältnis beizubehalten, was die Größenänderung verursachen kann.

**Wie kann ich die Größen von Diagramm und OLE‑Rahmen konsistent halten?**

Legen Sie feste Diagrammabmessungen fest, die dem OLE‑Rahmen entsprechen, und verwenden Sie eine benutzerdefinierte Diagrammdruckgröße, bevor Sie die Arbeitsmappe einbetten. Das obige Beispiel zeigt die erforderlichen Einstellungen und Einheitumrechnungen.

**Reicht es aus, die Größe des Arbeitsmappen‑Fensters anzupassen?**

Allein die Anpassung der Arbeitsmappen‑Fenstergröße verhindert nicht zuverlässig, dass sich der OLE‑Rahmen nach der Aktivierung ändert. Verwenden Sie feste Diagrammabmessungen, wie im Beispiel gezeigt.

**Funktioniert diese Lösung sowohl für vorlagenbasierte Präsentationen als auch für neue Präsentationen?**

Ja. Bei einer Vorlage verwenden Sie die Abmessungen und die Position des Platzhalters. Bei einer neuen Präsentation geben Sie die Rahmenabmessungen und -position direkt an.

**Kann ich dieses Beispiel mit Diagrammen aus anderen Tabellenkalkulationsprogrammen verwenden?**

Das Beispiel verwendet eine Excel‑Arbeitsmappe, die mit Aspose.Cells erstellt wurde. Es zeigt das Aktivierungsverhalten anderer Tabellenkalkulationsprogramme nicht.

## **Verwandte Abschnitte**

- [Excel-Diagramme erstellen und als OLE-Objekte in Präsentationen einbetten](/slides/de/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)