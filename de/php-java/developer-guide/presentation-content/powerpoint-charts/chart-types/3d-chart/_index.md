---
title: Anpassen von 3D-Diagrammen in Präsentationen mit PHP
linktitle: 3D Diagramm
type: docs
url: /de/php-java/3d-chart/
keywords:
- 3D-Diagramm
- Drehung
- Tiefe
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Erstellen Sie 3D-Diagramme in PowerPoint-Präsentationen mit Aspose.Slides für PHP über Java. Passen Sie Drehung, Höhenverhältnisse, Diagrammtiefe und den Abstand zwischen Serien mit PHP-Beispielen an."
---
## **Übersicht**

Aspose.Slides for PHP via Java ermöglicht es Ihnen, die Ansicht eines 3D‑Diagramms über die [Chart::getRotation3D](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getRotation3D)‑Methode anzupassen. Dieser Artikel zeigt, wie man Drehung, Höhenverhältnisse, Tiefe, rechtwinklige Achsen und Abstände zwischen Reihen einstellt und die Präsentation anschließend im PPTX‑Format speichert.

## **Drehung und Tiefe eines 3D‑Diagramms festlegen**

Das nachfolgende Beispiel erstellt eine [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) und verwendet [ShapeCollection::addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addChart) um ein gestapeltes 3D‑Säulendiagramm auf die erste Folie zu setzen. Es ersetzt die Standardserien und -kategorien durch zwei Serien mit jeweils drei Werten. Der Arbeitsblatt‑Index `0` bezeichnet das erste Daten‑Arbeitsblatt des Diagramms; Zeile `0` enthält die Seriennamen und Spalte `0` die Kategorienbezeichnungen.

Die Methoden [setRotationX](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRotationX) und [setRotationY](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRotationY) setzen die Drehung des Diagramms auf 40 bzw. 270 Grad. [setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) legt die Tiefe auf 150 % seiner Breite fest, während [setRightAngleAxes](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRightAngleAxes) rechtwinklige Achsen statt Perspektive aktiviert. Die resultierende Präsentation enthält das gefüllte Diagramm mit diesen 3D‑Ansichtseinstellungen.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn3D, 0, 0, 500, 500);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $values = [[20, 50, 30], [30, 10, 60]];

    for ($categoryIndex = 0; $categoryIndex < 3; $categoryIndex++) {
        $categoryCell = $workbook->getCell($worksheetIndex, $categoryIndex + 1, 0, "Category " . ($categoryIndex + 1));
        $chart->getChartData()->getCategories()->add($categoryCell);
    }

    for ($seriesIndex = 0; $seriesIndex < 2; $seriesIndex++) {
        $seriesCell = $workbook->getCell($worksheetIndex, 0, $seriesIndex + 1, "Series " . ($seriesIndex + 1));
        $series = $chart->getChartData()->getSeries()->add($seriesCell, $chart->getType());

        for ($categoryIndex = 0; $categoryIndex < 3; $categoryIndex++) {
            $valueCell = $workbook->getCell($worksheetIndex, $categoryIndex + 1, $seriesIndex + 1, $values[$seriesIndex][$categoryIndex]);
            $series->getDataPoints()->addDataPointForBarSeries($valueCell);
        }
    }

    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setRotationX(40);
    $chart->getRotation3D()->setRotationY(270);
    $chart->getRotation3D()->setDepthPercents(150);

    $presentation->save("Rotation3D_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Höhenverhältnisse eines 3D‑Diagramms anpassen**

Verwenden Sie [Rotation3D::setHeightPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setHeightPercents), um die Höhe eines 3D‑Diagramms als Prozentsatz seiner Breite festzulegen. Dies ändert die Proportionen der 3D‑Szene, ohne das Diagrammobjekt auf der Folie zu skalieren.

Das folgende Beispiel erstellt ein [Column3D](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/)‑Diagramm mit den Standarddaten: drei Serien und vier Kategorien. Es speichert drei Präsentationen mit Höhenverhältnissen von 50 %, 100 % und 200 %. Position, Breite und Höhe des Diagramms bleiben unverändert. Daten, Drehung, Tiefe, Reihenabstand und Formatierung sind in allen drei Dateien identisch; nur das Höhen‑Prozent wird geändert.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 40, 30, 620, 460);
    $chart->getRotation3D()->setRotationX(20);
    $chart->getRotation3D()->setRotationY(30);
    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setDepthPercents(100);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setGapDepth(150);

    foreach ([50, 100, 200] as $heightPercent) {
        $chart->getRotation3D()->setHeightPercents($heightPercent);
        $presentation->save("chart_height_" . $heightPercent . ".pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Die folgenden Bilder zeigen die gleichen Höhe‑Einstellungen im entsprechenden .NET‑Beispiel und wurden mit Microsoft PowerPoint exportiert. Ein kleinerer Prozentsatz erzeugt eine flachere Szene, ein größerer Prozentsatz eine höhere Szene im selben Diagrammobjekt. PowerPoint kann zudem Achsen‑Tick‑Intervalle und Beschriftungspositionen an die Szene anpassen.

| Höhe: 50% | Höhe: 100% | Höhe: 200% |
| --- | --- | --- |
| ![3D‑Säulendiagramm mit einer Höhe von 50 % seiner Breite](height_percent_50.png) | ![3D‑Säulendiagramm mit einer Höhe von 100 % seiner Breite](height_percent_100.png) | ![3D‑Säulendiagramm mit einer Höhe von 200 % seiner Breite](height_percent_200.png) |

Diese Methoden steuern verschiedene Aspekte des Diagramms:

| Methode | Effekt |
| --- | --- |
| [Rotation3D::setHeightPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setHeightPercents) | Höhe der 3D‑Szene als Prozentsatz ihrer Breite. |
| [Chart::setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setHeight) | Höhe des Diagrammobjekts auf der Folie, in Punkt. |
| [Rotation3D::setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) | Tiefe der 3D‑Szene als Prozentsatz ihrer Breite. |
| [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) | Abstand zwischen Serien entlang der Tiefenachse, als Prozentsatz der Markierungsbreite. |

Die Höhen‑Einstellung wirkt sich auf 3D‑Säulen‑ und Balkendiagramme aus, einschließlich Zylinder‑, Kegel‑ und Pyramiden‑Varianten, sowie auf 3D‑Linien‑, Flächen‑, Kreis‑ und Oberflächendiagramme. Der obige Vergleich verwendet den geprüften Typ `Column3D`. Die Einstellung ändert das Aussehen eines 2D‑`ClusteredColumn`‑Diagramms oder eines `BubbleWith3D`‑Diagramms nicht; diese Namen sind Mitglieder der [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/)‑Klasse. Weitere Diagramm‑Darstellungseinstellungen finden Sie unter [Chart Formatting](/slides/de/php-java/chart-formatting/).

## **Lücken zwischen Reihen anpassen**

Verwenden Sie [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth), um den Abstand zwischen Datenreihen entlang der Tiefenachse eines 3D‑Diagramms zu steuern, angegeben als Prozentsatz der Markierungsbreite. Verwenden Sie Werte von **0 bis 500**, inklusiv: `0` entfernt die Lücke, größere Werte vergrößern den Abstand. Bei fester Diagrammtiefe führt eine Vergrößerung der Lücke zu dünneren Markern entlang der Tiefenachse.

Greifen Sie über [ChartSeries::getParentSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getParentSeriesGroup) auf die Gruppe zu. Die Einstellung gilt für jede Serie in dieser Gruppe, nicht nur für die Serie, über die zugegriffen wird. [ChartSeries::getGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getGapDepth) gibt die Tiefenlücke zurück und spiegelt die Einstellung der Elterngruppe wider.

Diese Einstellung wirkt sich auf 3D‑Säulen‑ und Balkendiagramme aus, einschließlich deren Zylinder‑, Kegel‑ und Pyramiden‑Varianten, sowie auf 3D‑Linien‑ und Flächendiagramme. Das Erscheinungsbild hängt davon ab, ob die Serien in der Tiefe, gruppiert oder gestapelt angeordnet sind. Für einen klaren Vergleich der Lücken zwischen einzelnen Serien verwenden Sie `ChartType::Column3D` aus der [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/)‑Klasse.

Diese Methoden steuern verschiedene Aspekte des Diagramms:

| Methode | Effekt |
| --- | --- |
| [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) | Abstand zwischen Serien entlang der Tiefenachse, als Prozentsatz der Markierungsbreite. |
| [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapWidth) | Abstand zwischen benachbarten Balken‑ oder Säulen‑Clustern, als Prozentsatz der Balken‑ bzw. Säulenbreite. |
| [setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) | Gesamttiefe des Diagramms, als Prozentsatz der Diagrammbreite. |

Das folgende eigenständige Beispiel verwendet die Standarddiagrammdaten, die drei Serien und vier Kategorien enthalten. Es speichert zwei Präsentationen mit identischen Daten, Drehung, Lückenbreite und Diagrammtiefe; nur die Lückentiefe wird geändert.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 40, 30, 620, 230);

    $chart->getRotation3D()->setRotationX(20);
    $chart->getRotation3D()->setRotationY(30);
    $chart->getRotation3D()->setDepthPercents(100);

    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $group = $series->getParentSeriesGroup();
    $group->setGapWidth(150);

    foreach ([0, 500] as $gapDepth) {
        $group->setGapDepth($gapDepth);

        $fileName = "series_gap_depth_" . $gapDepth . ".pptx";
        $presentation->save($fileName, SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Die folgenden Bilder zeigen die gleichen Lückentiefe‑Einstellungen im entsprechenden .NET‑Beispiel und wurden mit Microsoft PowerPoint exportiert.

| Lückentiefe: 0% | Lückentiefe: 500% |
| --- | --- |
| ![3D‑Säulendiagramm ohne Lücke zwischen Serien entlang der Tiefenachse](gap_depth_0.png) | ![3D‑Säulendiagramm mit einer 500‑Prozent‑Lücke zwischen Serien entlang der Tiefenachse](gap_depth_500.png) |

## **3D‑Serientyp und Balkenform ändern**

In einem gruppierten Zylinderdiagramm beginnt die erste Serie mit einer zylindrischen Balkenform. Das Beispiel gibt die Ganzzahlwerte aus, die von [ChartSeries::getType](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/gettype/) und [ChartSeries::getBar3DShape](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getbar3dshape/) vor und nach jeder Änderung zurückgegeben werden. Die Tabelle enthält die entsprechenden Konstantennamen.

```php
use aspose\slides\ChartShapeType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredCylinder, 20, 20, 500, 300);
    $series = $chart->getChartData()->getSeries()->get_Item(0);

    echo $series->getType(), " | ", $series->getBar3DShape(), PHP_EOL;

    $series->setType(ChartType::ClusteredCone);
    echo $series->getType(), " | ", $series->getBar3DShape(), PHP_EOL;

    $series->setBar3DShape(ChartShapeType::Box);
    echo $series->getType(), " | ", $series->getBar3DShape(), PHP_EOL;

    $presentation->save("series_shape.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

| Änderung der ersten Serie | Serientyp | Balkenform |
| --- | --- | --- |
| Diagramm erstellen | `ClusteredCylinder` | `Cylinder` |
| Serientyp auf `ClusteredCone` setzen | `ClusteredCone` | `Cone` |
| Balkenform auf `Box` setzen | `ClusteredColumn3D` | `Box` |

Das Setzen der Form auf `Box` ändert zudem den Serientyp zu `ClusteredColumn3D`. Wenn Ihr Code nach dem Serientyp verzweigt, rufen Sie nach dem Ändern der Form [ChartSeries::getType](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/gettype/) auf. Ein vorher zwischengespeicherter Wert würde weiterhin den `ClusteredCone`‑Zweig wählen.

![PowerPoint‑Vergleich, der die erste Serie von links nach rechts als Zylinder, Kegel und rechteckige Säulen zeigt](series-shapes.png)

## **FAQ**

**Welche Diagrammtypen unterstützen den 3D‑Modus in Aspose.Slides?**

Aspose.Slides unterstützt 3D‑Varianten von Säulendiagrammen, darunter Column 3D, Clustered Column 3D, Stacked Column 3D und 100 % Stacked Column 3D, sowie verwandte 3D‑Typen, die über die [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/)‑Klasse verfügbar sind. Für eine genaue, aktuelle Liste prüfen Sie die Mitglieder von [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) in der API‑Referenz Ihrer installierten Version.

**Kann ich ein Rasterbild eines 3D‑Diagramms für einen Bericht oder das Web erhalten?**

Ja. Sie können ein Diagramm mit [Shape::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) in ein Bild exportieren oder die gesamte Folie mit [die gesamte Folie rendern](/slides/de/php-java/convert-powerpoint-to-png/) in Formate wie PNG oder JPEG rendern. Das ist nützlich, wenn Sie eine Raster‑Vorschau benötigen oder das Diagramm in Dokumente, Dashboards oder Webseiten einbetten möchten, ohne PowerPoint zu benötigen.

**Wie leistungsfähig ist das Erstellen und Rendern großer 3D‑Diagramme?**

Die Leistung hängt vom Datenvolumen und der visuellen Komplexität ab. Für optimale Ergebnisse halten Sie 3D‑Effekte minimal, vermeiden schwere Texturen an Wänden und Plot‑Bereichen, begrenzen nach Möglichkeit die Anzahl der Datenpunkte pro Serie und rendern Sie in einer angemessenen Ausgabegröße (Auflösung und Abmessungen), die der Zielanzeige oder den Druckanforderungen entspricht.