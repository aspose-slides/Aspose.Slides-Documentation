---
title: 3D-Diagramme in Präsentationen mit PHP anpassen
linktitle: 3D-Diagramm
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
description: "Erstellen Sie 3D-Diagramme in PowerPoint-Präsentationen mit Aspose.Slides für PHP via Java. Passen Sie Drehung, Höhenverhältnisse, Diagrammtiefe und den Abstand zwischen Serien mit PHP-Beispielen an."
---
## **Übersicht**

Aspose.Slides für PHP via Java ermöglicht es Ihnen, die Ansicht eines 3D‑Diagramms über die Methode [Chart::getRotation3D](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getRotation3D) anzupassen. Dieser Artikel demonstriert, wie man Rotation, Höhenverhältnisse, Tiefe, rechtwinklige Achsen und den Abstand zwischen Datenreihen einstellt und die Präsentation anschließend im PPTX‑Format speichert.

## **Rotation und Tiefe eines 3D‑Diagramms festlegen**

Das nachfolgende Beispiel erstellt eine [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) und verwendet [ShapeCollection::addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addChart), um ein gestapeltes 3D‑Säulendiagramm auf der ersten Folie hinzuzufügen. Es ersetzt die Standardserien und -kategorien durch zwei Serien mit jeweils drei Werten. Der Arbeitsblatt‑Index `0` identifiziert das erste Datenarbeitsblatt des Diagramms; Zeile `0` enthält die Seriennamen und Spalte `0` die Kategorienamen.

Die Methoden [setRotationX](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRotationX) und [setRotationY](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRotationY) setzen die Diagrammrotation auf 40 bzw. 270 Grad. [setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) legt die Tiefe auf 150 % seiner Breite fest, während [setRightAngleAxes](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRightAngleAxes) rechte Winkel‑Achsen anstelle von Perspektive aktiviert. Die resultierende Präsentation enthält das ausgefüllte Diagramm mit diesen 3D‑Ansichtseinstellungen.

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

## **Bildfüllung auf einer 3D‑Diagrammoberfläche anwenden**

Sie können die [Seitenwand](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getsidewall/), die [Rückwand](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getbackwall/) und den [Boden](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getfloor/) eines 3D‑Diagramms unabhängig voneinander füllen. Setzen Sie den [fill type](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/) der Oberfläche auf `Picture` und weisen Sie ein Bild zu. Setzen Sie sowohl den [picture fill mode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/setpicturefillmode/) als auch den [picture type](https://reference.aspose.com/slides/php-java/aspose.slides/chartwall/setpicturetype/) der Oberfläche auf `Stretch`, damit eine Kopie des Bildes über die gesamte Oberfläche gestreckt wird.

Speichern Sie [arrow.png](arrow.png) neben dem PHP‑Skript. Das Beispiel rotiert das Diagramm und erhöht den Maximalwert der vertikalen Achse, sodass der Boden zwischen den Säulen sichtbar ist. Anschließend wird die Folie zweimal geklont und der Pfeil auf jeweils einer anderen Oberfläche jeder Folie angewendet. Alle drei Diagramme behalten dieselben Daten, Blickwinkel und Hintergrund.

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\PictureType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 20, 30, 680, 480);
    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setRotationX(40);
    $chart->getRotation3D()->setRotationY(30);
    
    $verticalAxis = $chart->getAxes()->getVerticalAxis();
    $verticalAxis->setAutomaticMaxValue(false);
    $verticalAxis->setMaxValue(24);

    $backSlide = $presentation->getSlides()->addClone($slide);
    $floorSlide = $presentation->getSlides()->addClone($slide);
    $backChart = $backSlide->getShapes()->get_Item(0);
    $floorChart = $floorSlide->getShapes()->get_Item(0);

    $image = Images::fromFile(__DIR__ . "/arrow.png");
    try {
        $arrow = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $surfaces = [$chart->getSideWall(), $backChart->getBackWall(), $floorChart->getFloor()];
    foreach ($surfaces as $surface) {
        $fill = $surface->getFormat()->getFill();
        $fill->setFillType(FillType::Picture);
        $pictureFill = $fill->getPictureFillFormat();
        $pictureFill->getPicture()->setImage($arrow);
        $pictureFill->setPictureFillMode(PictureFillMode::Stretch);
        $surface->setPictureType(PictureType::Stretch);
    }

    $presentation->save(__DIR__ . "/chart-surfaces.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Microsoft PowerPoint zeigt die drei Folien wie folgt.

| Seitenwand | Rückwand | Boden |
| --- | --- | --- |
| ![Pfeil, der in das Diagramm entlang der Seitenwand zeigt](side-wall.png) | ![Pfeil, der nach rechts über die Rückwand zeigt](back-wall.png) | ![Pfeil, der nach rechts über den Boden zwischen den Säulen zeigt](floor.png) |

## **Höhenverhältnisse eines 3D‑Diagramms anpassen**

Verwenden Sie [Rotation3D::setHeightPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setHeightPercents), um die Höhe eines 3D‑Diagramms als Prozentsatz seiner Breite festzulegen. Damit ändern Sie die Proportionen der 3D‑Szene, ohne das Diagrammobjekt auf der Folie zu skalieren.

Das folgende Beispiel erstellt ein [Column3D](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/)‑Diagramm mit den Standarddaten: drei Serien und vier Kategorien. Es speichert drei Präsentationen mit Höhenverhältnissen von 50 %, 100 % und 200 %. Position, Breite und Höhe des Diagramms bleiben unverändert. Daten, Rotation, Tiefe, Serienabstand und Formatierung sind in allen drei Dateien identisch; nur das Höhen‑Prozent wird geändert.

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

Die folgenden Bilder zeigen dieselben Höheneinstellungen im entsprechenden .NET‑Beispiel und wurden mit Microsoft PowerPoint exportiert. Ein kleinerer Prozentsatz erzeugt eine flachere Szene, während ein größerer Prozentsatz eine höhere Szene innerhalb desselben Diagrammobjekts erzeugt. PowerPoint kann zudem die Achsen‑Tick‑Intervalle und die Beschriftungsposition anpassen, um die Szene zu passen.

| Höhe: 50 % | Höhe: 100 % | Höhe: 200 % |
| --- | --- | --- |
| ![3D‑Säulendiagramm mit einer Höhe von 50 % seiner Breite](height_percent_50.png) | ![3D‑Säulendiagramm mit einer Höhe von 100 % seiner Breite](height_percent_100.png) | ![3D‑Säulendiagramm mit einer Höhe von 200 % seiner Breite](height_percent_200.png) |

Diese Methoden steuern unterschiedliche Aspekte des Diagramms:

| Methode | Wirkung |
| --- | --- |
| [Rotation3D::setHeightPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setHeightPercents) | Höhe der 3D‑Szene als Prozentsatz ihrer Breite. |
| [Chart::setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setHeight) | Höhe des Diagrammobjekts auf der Folie, in Punkten. |
| [Rotation3D::setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) | Tiefe der 3D‑Szene als Prozentsatz ihrer Breite. |
| [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) | Abstand zwischen Serien entlang der Tiefenachse, als Prozentsatz der Markierungsbreite. |

Die Höheneinstellung wirkt sich auf 3D‑Säulen‑ und Balkendiagramme aus, einschließlich Zylinder‑, Kegel‑ und Pyramiden‑Varianten, sowie auf 3D‑Linien-, Flächen-, Kreis‑ und Oberflächendiagramme. Der obige Vergleich verwendet den verifizierten Typ `Column3D`. Die Einstellung ändert das Aussehen eines 2D‑`ClusteredColumn`‑Diagramms oder eines `BubbleWith3D`‑Diagramms nicht; diese Namen sind Mitglieder der Klasse [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/). Für weitere Diagramm‑Darstellungseinstellungen siehe [Diagrammformatierung](/slides/de/php-java/chart-formatting/).

## **Abstand zwischen Serien anpassen**

Verwenden Sie [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth), um den Abstand zwischen Datenserien entlang der Tiefenachse eines 3D‑Diagramms zu steuern, ausgedrückt als Prozentsatz der Markierungsbreite. Verwenden Sie Werte von **0 bis 500**, inklusiv: `0` entfernt den Abstand, während größere Werte den Abstand erhöhen. Bei einer festen Diagrammtiefe führt das Vergrößern des Abstands zu dünneren Markierungen entlang der Tiefenachse.

Greifen Sie über [ChartSeries::getParentSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getParentSeriesGroup) auf die Gruppe zu. Die Einstellung gilt für jede Serie in dieser Gruppe, nicht nur für die Serie, die zum Zugriff verwendet wurde. [ChartSeries::getGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getGapDepth) gibt den Tiefenabstand zurück und spiegelt die Einstellung der übergeordneten Gruppe wider.

Diese Einstellung wirkt sich auf 3D‑Säulen‑ und Balkendiagramme aus, einschließlich ihrer Zylinder‑, Kegel‑ und Pyramiden‑Varianten, sowie auf 3D‑Linien‑ und Flächendiagramme. Das Aussehen hängt davon ab, ob die Serien in die Tiefe angeordnet, gruppiert oder gestapelt sind. Für einen klaren Vergleich der Abstände zwischen einzelnen Serien verwenden Sie `ChartType::Column3D` aus der Klasse [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/).

Diese Methoden steuern unterschiedliche Aspekte des Diagramms:

| Methode | Wirkung |
| --- | --- |
| [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) | Abstand zwischen Serien entlang der Tiefenachse, als Prozentsatz der Markierungsbreite. |
| [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapWidth) | Abstand zwischen benachbarten Balken‑ oder Säulen‑Clustern, als Prozentsatz der Balken‑ oder Säulenbreite. |
| [setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) | Gesamttiefe des Diagramms, als Prozentsatz der Diagrammbreite. |

Das folgende eigenständige Beispiel verwendet die Standarddiagrammdaten, die drei Serien und vier Kategorien enthalten. Es speichert zwei Präsentationen mit identischen Daten, Rotation, Lückenbreite und Diagrammtiefe; nur die Lückentiefe ändert sich.

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

Die folgenden Bilder veranschaulichen dieselben Lückentiefe‑Einstellungen im entsprechenden .NET‑Beispiel und wurden mit Microsoft PowerPoint exportiert.

| Lückentiefe: 0 % | Lückentiefe: 500 % |
| --- | --- |
| ![3D‑Säulendiagramm ohne Abstand zwischen Serien entlang der Tiefenachse](gap_depth_0.png) | ![3D‑Säulendiagramm mit einem Abstand von 500 % zwischen Serien entlang der Tiefenachse](gap_depth_500.png) |

## **Ändern des 3D‑Serientyps und der Balkenform**

In einem gruppierten Zylinderdiagramm beginnt die erste Serie mit einer zylindrischen Balkenform. Das Beispiel gibt die ganzzahligen Werte aus, die von [ChartSeries::getType](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/gettype/) und [ChartSeries::getBar3DShape](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getbar3dshape/) vor und nach jeder Änderung zurückgegeben werden. Die Tabelle liefert die entsprechenden Konstantennamen.

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
| Serientyp auf `ClusteredCone` ändern | `ClusteredCone` | `Cone` |
| Balkenform auf `Box` ändern | `ClusteredColumn3D` | `Box` |

Das Setzen der Form auf `Box` ändert außerdem den Serientyp zu `ClusteredColumn3D`. Wenn Ihr Code Zweige basierend auf dem Serientyp verwendet, rufen Sie nach dem Ändern der Form [ChartSeries::getType](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/gettype/) auf. Ein zuvor gecachter Wert würde weiterhin den `ClusteredCone`‑Zweig auswählen.

![PowerPoint-Vergleich, der die erste Serie von links nach rechts als Zylinder, Kegel und rechteckige Säulen zeigt](series-shapes.png)

## **FAQ**

**Welche Diagrammtypen unterstützen den 3D‑Modus in Aspose.Slides?**

Aspose.Slides unterstützt 3D‑Varianten von Säulendiagrammen, einschließlich Column 3D, Clustered Column 3D, Stacked Column 3D und 100 % Stacked Column 3D, sowie verwandte 3D‑Typen, die über die Klasse [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) bereitgestellt werden. Für eine genaue, aktuelle Liste prüfen Sie die Mitglieder von [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) in der API‑Referenz Ihrer installierten Version.

**Kann ich ein Rasterbild eines 3D‑Diagramms für einen Bericht oder das Web erhalten?**

Ja. Sie können ein Diagramm mit [Shape::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) oder [die gesamte Folie rendern](/slides/de/php-java/convert-powerpoint-to-png/) zu Formaten wie PNG oder JPEG exportieren. Dies ist nützlich, wenn Sie eine Rastervorschau benötigen oder das Diagramm in Dokumente, Dashboards oder Webseiten einbetten möchten, ohne PowerPoint zu benötigen.

**Wie performant ist das Erstellen und Rendern großer 3D‑Diagramme?**

Die Leistung hängt vom Datenvolumen und der visuellen Komplexität ab. Für optimale Ergebnisse halten Sie 3D‑Effekte minimal, vermeiden schwere Texturen auf Wänden und Plot‑Bereichen, begrenzen Sie die Anzahl der Datenpunkte pro Serie, wenn möglich, und rendern Sie in einer angemessenen Ausgabegröße (Auflösung und Abmessungen), die den Zielgeräten oder Druckanforderungen entspricht.