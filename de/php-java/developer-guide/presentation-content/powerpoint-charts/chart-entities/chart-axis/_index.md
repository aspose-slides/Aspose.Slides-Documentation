---
title: Diagrammachsen in Präsentationen mit PHP anpassen
linktitle: Diagrammachse
type: docs
url: /de/php-java/chart-axis/
keywords:
- Diagrammachse
- vertikale Achse
- horizontale Achse
- Achse anpassen
- Achse manipulieren
- Achse verwalten
- Achseneigenschaften
- Maximalwert
- Minimalwert
- Achsenlinie
- Datumsformat
- Achsentitel
- Achsenposition
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Sie Aspose.Slides für PHP via Java nutzen können, um Diagrammachsen in PowerPoint-Präsentationen für Berichte und Visualisierungen anzupassen."
---
## **Übersicht**

Dieser Artikel erklärt, wie Sie Diagrammachsen mit Aspose.Slides für PHP via Java anpassen. Er behandelt berechnete Achsenwerte, das Vertauschen von Diagrammzeilen und -spalten, Achsensichtbarkeit, Intervall für Kategorienamen und Teilstrich‑Markierungen, Datums‑Kategorien und -Formatierung, Titelrotation, Achsenpositionierung, Anzeige‑Einheiten und logarithmische Skalierung.

## **Maximale Werte auf der vertikalen Achse von Diagrammen abrufen**

Erstellen Sie eine [Präsentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) und fügen Sie ein Flächendiagramm mit Standarddaten hinzu. Rufen Sie [validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) auf, bevor Sie berechnete Achsenwerte lesen, damit das Diagrammlayout aktuell ist.

Lesen Sie [getActualMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmaxvalue/) und [getActualMinValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminvalue/) für die Achsenbegrenzungen sowie [getActualMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunit/) und [getActualMinorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunit/) für die Teilstrich‑Intervalle. [getActualMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunitscale/) und [getActualMinorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunitscale/) liefern Zeiteinheiten‑Skalen, die für Datumsachsen relevant sind. Das Beispiel speichert diese Werte in lokalen Variablen und speichert das Diagramm.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Area, 100, 100, 500, 350);
    $chart->validateChartLayout();

    $maxValue = $chart->getAxes()->getVerticalAxis()->getActualMaxValue();
    $minValue = $chart->getAxes()->getVerticalAxis()->getActualMinValue();

    $majorUnit = $chart->getAxes()->getVerticalAxis()->getActualMajorUnit();
    $minorUnit = $chart->getAxes()->getVerticalAxis()->getActualMinorUnit();

    $majorUnitScale = $chart->getAxes()->getVerticalAxis()->getActualMajorUnitScale();
    $minorUnitScale = $chart->getAxes()->getVerticalAxis()->getActualMinorUnitScale();

    $presentation->save("AxisValues_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Daten zwischen Achsen vertauschen**

Verwenden Sie [switchRowColumn](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/switchrowcolumn/), um die Rollen von Reihen und Kategorien in Diagrammdaten zu vertauschen. Jede ehemalige Kategorie wird zu einer Reihe und jede ehemalige Reihe zu einer Kategorie. Dadurch ändert sich die Gruppierung der Daten; die horizontalen und vertikalen Achsen werden nicht ausgetauscht. Das Beispiel verwendet [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/), um die Standarddaten an `Sheet1!A1:D5` zu binden, einschließlich Kopf‑Zeile und Kategorien‑Spalte, bevor Zeilen und Spalten vertauscht werden. Es speichert ein Diagramm mit vier Reihen und drei Kategorien.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 400, 300);
    $chart->getChartData()->setRange("Sheet1!A1:D5");
    $chart->getChartData()->switchRowColumn();

    $presentation->save("SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Umkehrung der Plot‑Reihenfolge einer Achse**

Verwenden Sie [setPlotOrderReversed](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setplotorderreversed/), um eine Kategorien‑ oder Werte‑Achse umzukehren. Beispielsweise kann ein horizontales Balkendiagramm Projektphasen von oben nach unten in derselben Reihenfolge wie das Arbeitsblatt anzeigen: Planung, Entwicklung, Test. Das Umkehren einer Achse ändert die Plot‑Richtung; es sortiert oder reorganisiert die Arbeitsblattdaten nicht. Im Vergleich dazu tauscht [switchRowColumn](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/switchrowcolumn/) die Rollen von Reihen und Kategorien.

Das folgende Beispiel erstellt ein horizontales Balkendiagramm mit drei Phasen und einer Reihe. Es speichert eine Präsentation mit drei Folien: normale Reihenfolge, umgekehrte Kategorien und umgekehrte Werte. Jede Kopie verwendet denselben Datensatz, und nur eine Achse ist in jeder Kopie umgekehrt.

```php
use aspose\slides\ChartType;
use aspose\slides\CrossesType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredBar, 50, 40, 620, 320);
    $chart->setLegend(false);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $series = $chart->getChartData()->getSeries()->add(ChartType::ClusteredBar);
    $stages = ["Planning", "Development", "Testing"];
    $values = [10, 30, 20];
    for ($i = 0; $i < count($stages); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, $stages[$i]);
        $chart->getChartData()->getCategories()->add($categoryCell);
        $valueCell = $workbook->getCell(0, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    }

    // Folie 2: die erste Kategorie oben anzeigen.
    $categorySlide = $presentation->getSlides()->addClone($slide);
    $categoryChart = $categorySlide->getShapes()->get_Item(0);
    $categoryChart->getAxes()->getVerticalAxis()->setPlotOrderReversed(true);
    // Die horizontale Werte-Achse unten belassen.
    $categoryChart->getAxes()->getVerticalAxis()->setCrossType(CrossesType::Maximum);

    // Folie 3: nur die horizontale numerische Skala umkehren.
    $valueSlide = $presentation->getSlides()->addClone($slide);
    $valueChart = $valueSlide->getShapes()->get_Item(0);
    $valueChart->getAxes()->getHorizontalAxis()->setPlotOrderReversed(true);

    $presentation->save("ReversedAxes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Das Umkehren einer Achse kann außerdem die senkrechte Achse auf die gegenüberliegende Seite des Plots verschieben. [setCrossType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrosstype/) steuert, wo die andere Achse die konfigurierende Achse kreuzt. In Folie 2 wird sie mit `CrossesType::Maximum` auf der umgekehrten Kategorien‑Achse aufgerufen, wodurch die horizontale Werte‑Achse unten bleibt. Für einen konkreten Kreuzungs­punkt verwenden Sie [setCrossAt](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrossat/). Prüfen Sie die Kreuzungs‑Einstellungen, wenn Sie die Richtung ändern, besonders wenn das Diagramm bereits einen benutzerdefinierten Kreuzungs‑Punkt hat. Rufen Sie `setPlotOrderReversed` mit `false` auf, um die normale Plot‑Richtung wiederherzustellen; die Kreuzungs‑Einstellungen sind separiert.

| Normale Reihenfolge (Folie 1) | Umgekehrte Kategorien (Folie 2) | Umgekehrte Werte (Folie 3) |
| --- | --- | --- |
| ![Horizontales Balkendiagramm mit normaler Reihenfolge von Kategorien‑ und Werte‑Achse](axis-order-normal.png) | ![Horizontales Balkendiagramm mit von oben nach unten angezeigten Kategorien](axis-order-categories-reversed.png) | ![Horizontales Balkendiagramm mit umgekehrter Werte‑Achse und Null rechts](axis-order-values-reversed.png) |
| Kategorien verlaufen von unten nach oben; Werte steigen von links nach rechts. | Planung, Entwicklung und Test verlaufen von oben nach unten. Werte‑ und Arbeitsblatt‑Zeilenreihenfolge bleiben unverändert. | Kategorien behalten ihre normale Reihenfolge; Werte steigen von rechts nach links. Die Kategorien‑Achse kreuzt bei Null rechts. |

## **Vertikale Achse für Liniendiagramme deaktivieren**

Rufen Sie [setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/) mit `false` auf der vertikalen Achse auf, um sie auszublenden. Das Beispiel erstellt ein Liniendiagramm mit Standarddaten und speichert es mit ausgeblendeter vertikaler Achse.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 100, 100, 400, 300);
    $chart->getAxes()->getVerticalAxis()->setVisible(false);

    $presentation->save("HiddenVerticalAxis.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Horizontale Achse für Liniendiagramme deaktivieren**

Rufen Sie [setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/) mit `false` auf der horizontalen Achse auf, um sie auszublenden. Das Beispiel erstellt ein Liniendiagramm mit Standarddaten und speichert es mit ausgeblendeter horizontaler Achse.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 100, 100, 400, 300);
    $chart->getAxes()->getHorizontalAxis()->setVisible(false);

    $presentation->save("HiddenHorizontalAxis.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Kategorien‑Achse ändern**

Verwenden Sie [setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/), um eine Datums‑ oder Text‑Kategorien‑Achse auszuwählen. Dieses Beispiel erfordert `ExistingChart.pptx`, mit einem Diagramm als erstes Shape auf der ersten Folie und Kategoriespalten, die numerische Excel‑Datumswerte enthalten. Es ändert die horizontale Achse zu einer Datums‑Achse. Durch Aufrufen von [setAutomaticMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticmajorunit/) mit `false`, [setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/) mit `1` und [setMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunitscale/) mit `TimeUnitType::Months` werden Haupt‑Teilstriche im Abstand von einem Monat gesetzt.

```php
use aspose\slides\CategoryAxisType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TimeUnitType;

$presentation = new Presentation("ExistingChart.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->get_Item(0);
    $chart->getAxes()->getHorizontalAxis()->setCategoryAxisType(CategoryAxisType::Date);
    $chart->getAxes()->getHorizontalAxis()->setAutomaticMajorUnit(false);
    $chart->getAxes()->getHorizontalAxis()->setMajorUnit(1);
    $chart->getAxes()->getHorizontalAxis()->setMajorUnitScale(TimeUnitType::Months);

    $presentation->save("ChangeChartCategoryAxis_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Intervall für Kategorien‑Achsen‑Beschriftungen steuern**

Wenn ein Diagramm viele Kategorien hat, reduzieren Sie die Anzahl sichtbarer Achsenbeschriftungen, ohne Kategorien oder Datenpunkte zu entfernen. Rufen Sie [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticticklabelspacing/) mit `false` auf und übergeben Sie das gewünschte Kategorien‑Intervall an [setTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelspacing/). Für Text‑Kategorien in ihrer normalen Reihenfolge beginnt die Zählung bei der ersten Kategorie:

| Intervall | Im Beispiel angezeigte Beschriftungen |
| --- | --- |
| `1` | Kategorie 1, Kategorie 2, Kategorie 3, … Kategorie 24 |
| `2` | Kategorie 1, Kategorie 3, Kategorie 5, … Kategorie 23 |
| `3` | Kategorie 1, Kategorie 4, Kategorie 7, … Kategorie 22 |

Ein Intervall von `3` zeigt jede dritte Beschriftung an, wobei zwei Beschriftungen zwischen den angezeigten verborgen bleiben. Es werden nicht die zugehörigen Spalten entfernt. Automatisches Spacing wählt ein Intervall basierend auf dem verfügbaren Platz; es zeigt nicht zwingend jede Beschriftung an.

Teilstrich‑Markierungen haben eigene Einstellungen. Rufen Sie [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomatictickmarksspacing/) mit `false` auf und benutzen Sie [setTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settickmarksspacing/), um ihr Intervall festzulegen. Beispiel: `1` behält einen Teilstrich bei jedem Kategorien‑Intervall bei, während Beschriftungen nur bei jeder dritten Kategorie erscheinen. Verwenden Sie [setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) mit einem sichtbaren Stil, damit Sie das Ergebnis sehen. Durch erneutes Aufrufen eines automatischen Setters mit `true` lässt das Diagramm das Intervall wieder automatisch wählen.

Das nachfolgende, eigenständige Beispiel erstellt 24 Kategorien und eine Reihe und speichert drei Folien in `CategoryAxisIntervals.pptx`: automatisches Spacing, manuelles Beschriftungs‑Spacing mit unabhängigen Teilstrichen und wiederhergestelltes automatisches Spacing. Die beiden Kopien behalten die ursprünglichen Diagrammdaten. Keine Eingabe‑Präsentation ist erforderlich. Der horizontale Beschriftungstext erleichtert die Sichtbarkeit der Dichteunterschiede.

```php
use aspose\slides\CategoryAxisType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TickMarkType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 30, 40, 660, 320);

    $chart->setLegend(false);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $series = $chart->getChartData()->getSeries()->add(ChartType::ClusteredColumn);
    for ($i = 0; $i < 24; $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, "Category " . ($i + 1));
        $chart->getChartData()->getCategories()->add($categoryCell);
        $valueCell = $workbook->getCell(0, $i + 1, 1, 10 + $i % 6 * 5);
        $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    }

    $axis = $chart->getAxes()->getHorizontalAxis();
    $axis->setCategoryAxisType(CategoryAxisType::Text);
    $axis->getTextFormat()->getTextBlockFormat()->setRotationAngle(0);
    $axis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $axis->setMajorTickMark(TickMarkType::Outside);
    $axis->setAutomaticTickLabelSpacing(true);
    $axis->setAutomaticTickMarksSpacing(true);

    // Folie 2: jedes dritte Etikett anzeigen, aber für jede Kategorie einen Teilstrich beibehalten.
    $manualSlide = $presentation->getSlides()->addClone($slide);
    $manualChart = $manualSlide->getShapes()->get_Item(0);
    $manualAxis = $manualChart->getAxes()->getHorizontalAxis();
    $manualAxis->setAutomaticTickLabelSpacing(false);
    $manualAxis->setTickLabelSpacing(3);
    $manualAxis->setAutomaticTickMarksSpacing(false);
    $manualAxis->setTickMarksSpacing(1);

    // Folie 3: das Diagramm beide Intervalle erneut wählen lassen.
    $restoredSlide = $presentation->getSlides()->addClone($manualSlide);
    $restoredChart = $restoredSlide->getShapes()->get_Item(0);
    $restoredChart->getAxes()->getHorizontalAxis()->setAutomaticTickLabelSpacing(true);
    $restoredChart->getAxes()->getHorizontalAxis()->setAutomaticTickMarksSpacing(true);

    $presentation->save("CategoryAxisIntervals.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**Automatisches Spacing (Folie 1):** In dieser Darstellung wird jede zweite Kategorien‑Beschriftung angezeigt und auf zwei Zeilen umbrochen. Das automatische Ergebnis kann je nach Diagrammgröße, Schriftart und Renderer variieren.

![Automatischer Kategorien‑Beschriftungs‑Abstand mit allen 24 Spalten sichtbar](category-axis-automatic.png)

**Manuelles Spacing (Folie 2):** Jede dritte Beschriftung wird in einer Zeile angezeigt, während Teilstriche bei jedem Kategorien‑Intervall bleiben. Alle 24 Spalten, einschließlich der ohne Beschriftungen, bleiben mit gleichen Werten sichtbar. Folie 3 stellt das oben gezeigte automatische Aussehen wieder her.

![Manuelles Kategorien‑Beschriftungs‑Intervall von drei mit allen 24 Spalten sichtbar](category-axis-manual.png)

### **Den korrekten Achsentyp und das Intervall wählen**

Verwenden Sie dieses Kategorien‑Zähl‑Intervall für eine Text‑Kategorien‑Achse, etwa die Kategorien‑Achse eines Säulen‑, Linien‑, Flächen‑ oder Balkendiagramms. In einem Säulendiagramm ist es die horizontale Achse. In einem horizontalen Balkendiagramm ist die Kategorien‑Achse vertikal, also wenden Sie diese Einstellungen auf die Achse an, die von [getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/) zurückgegeben wird. Der Teilstrich‑Abstand gilt ebenfalls für eine Reihen‑Achse in Diagrammen, die eine solche besitzen.

Verwenden Sie das Beschriftungs‑Spacing nicht, um die numerische Skala einer Werte‑Achse festzulegen. Auf einer Werte‑Achse definiert [setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/) einen Werte‑Unterschied: ein Haupt‑Einheitswert von `10` erzeugt Teilstriche bei 0, 10, 20 usw., wenn die Achse bei Null beginnt. Ein Kategorien‑Beschriftungs‑Intervall von `3` zählt dagegen Positionen, unabhängig von den Datenwerten. Streu‑ und Blasendiagramme verwenden Werte‑Achsen statt einer Text‑Kategorien‑Achse. Für eine Datums‑Achse verwenden Sie zeitbasierte Haupteinheiten und Skalen wie im Abschnitt [Kategorien‑Achse ändern](#kategorien‑achse‑ändern).

## **Datumsformat für Kategorien‑Achsen‑Werte festlegen**

Das Beispiel ersetzt die Standard‑Diagrammdaten durch vier Jahreswerte. Daten werden als OLE‑Automation‑Seriennummern im ersten Arbeitsblatt (Index `0`) gespeichert und entsprechen der Anzahl der Tage seit dem 30. Dezember 1899. Verwenden Sie [setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) mit `CategoryAxisType::Date`, rufen Sie [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformatlinkedtosource/) mit `false` auf und übergeben Sie `yyyy` an [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformat/), damit die Kategorien‑Beschriftungen vierstellige Jahreszahlen unabhängig von der Zellenformatierung anzeigen.

```php
use aspose\slides\CategoryAxisType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 50, 50, 450, 300);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $baseDate = gmmktime(0, 0, 0, 12, 30, 1899);

    $series = $chart->getChartData()->getSeries()->add(ChartType::Line);
    for ($i = 0; $i < 4; $i++) {
        $date = gmmktime(0, 0, 0, 1, 1, 2015 + $i);
        $serialDate = ($date - $baseDate) / 86400;
        $categoryCell = $workbook->getCell(0, $i + 1, 0, $serialDate);
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell(0, $i + 1, 1, $i + 1);
        $series->getDataPoints()->addDataPointForLineSeries($valueCell);
    }

    $chart->getAxes()->getHorizontalAxis()->setCategoryAxisType(CategoryAxisType::Date);
    $chart->getAxes()->getHorizontalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getHorizontalAxis()->setNumberFormat("yyyy");

    $presentation->save("DateAxisFormat.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Drehwinkel für Diagrammachsentitel festlegen**

Rufen Sie [setTitle](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settitle/) mit `true` auf der vertikalen Achse auf, geben Sie den Titeltext an und verwenden Sie [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) zum Drehen des Titels. Der Winkel wird in Grad angegeben; dieses Beispiel speichert ein Säulendiagramm mit um 90 Grad gedrehtem Werte‑Achsentitel.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getVerticalAxis()->setTitle(true);
    $chart->getAxes()->getVerticalAxis()->getTitle()->addTextFrameForOverriding("Value");
    $chart->getAxes()->getVerticalAxis()->getTitle()->getTextFormat()->getTextBlockFormat()->setRotationAngle(90);

    $presentation->save("RotatedAxisTitle.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Achsenposition auf einer Kategorien‑ oder Werte‑Achse festlegen**

Verwenden Sie [setAxisBetweenCategories](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setaxisbetweencategories/), um zu steuern, ob die Werte‑Achse die Kategorien‑Achse zwischen Kategorien oder bei den Kategorien‑Teilstrichen kreuzt. Diese Einstellung gilt für Kategorien‑Achsen. Das Beispiel setzt sie auf `true` bei der horizontalen Kategorien‑Achse eines Säulendiagramms und speichert das Ergebnis.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getHorizontalAxis()->setAxisBetweenCategories(true);

    $presentation->save("AxisBetweenCategories.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Anzeige‑Einheit auf einer Diagramm‑Werte‑Achse festlegen**

Verwenden Sie [setDisplayUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setdisplayunit/), um die Beschriftungen einer Werte‑Achse zu skalieren, ohne die zugrunde liegenden Daten zu ändern. Mit [DisplayUnitType](https://reference.aspose.com/slides/php-java/aspose.slides/displayunittype/) auf `Millions` wird ein Wert von 60 000 000 als 60 angezeigt. Das Beispiel erstellt ein Säulendiagramm und wendet die Anzeige‑Einheit „Millionen“ auf die vertikale Achse an.

```php
use aspose\slides\ChartType;
use aspose\slides\DisplayUnitType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getVerticalAxis()->setDisplayUnit(DisplayUnitType::Millions);

    $presentation->save("Result.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Logarithmische Werte‑Achse konfigurieren**

Eine logarithmische Werte‑Achse ist sinnvoll, wenn positive Werte mehrere Größenordnungen umfassen. Beispiel: Ein Service erhält 10, 100, 1 000, 10 000 und 100 000 Anfragen über fünf Zeiträume. Auf einer linearen Skala liegen die kleineren Werte dicht beieinander nahe Null. Eine logarithmische Skala macht ihr relatives Wachstum leichter vergleichbar: gleiche Abstände entsprechen gleichen Verhältnissen statt gleichen Differenzen.

Rufen Sie [setLogarithmic](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogarithmic/) mit `true` auf der Werte‑Achse auf und verwenden Sie [setLogBase](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogbase/), um die Basis zu wählen. Dies ändert nur die Anzeige der vorhandenen Werte; die Daten bleiben unverändert und es wird keine logarithmische Trendlinie hinzugefügt. Eine Trendlinie stellt eine angepasste Beziehung in den Daten dar und ist ein separates Feature.

### **Werte‑Achse und Basis wählen**

Für ein Linien‑ oder Säulendiagramm wird die Werte‑Achse von [getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/) zurückgegeben. Für ein horizontales Balkendiagramm von [getHorizontalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/gethorizontalaxis/). Streu‑ und Blasendiagramme besitzen zwei Werte‑Achsen; wählen Sie die horizontale Achse für X‑Werte, die vertikale für Y‑Werte oder beide. Wenden Sie keine logarithmische Skalierung auf eine Kategorien‑Achse an.

Die Standard‑Logarithmus‑Basis ist `10`. Für PPTX‑Diagramme kann eine Basis von `2` bis `1000` (inklusive) verwendet werden; Bruch‑Basen wie `2.5` werden ebenfalls unterstützt. Bei Basis `10` sind aufeinanderfolgende Potenzen wie 10, 100, 1 000 und 10 000 gleichmäßig verteilt.

### **Linear vs. logarithmisch vergleichen**

Das nachfolgende, eigenständige Beispiel erstellt ein Liniendiagramm mit den fünf Anfragen‑Zahlen auf der ersten Folie, klont dann diese Folie und aktiviert auf der zweiten Folie eine Basis‑10‑logarithmische Werte‑Achse. Beide Folien behalten die gleichen Daten.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 30, 40, 660, 200);

    $chart->setLegend(false);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $series = $chart->getChartData()->getSeries()->add(ChartType::Line);
    $values = [10, 100, 1000, 10000, 100000];

    for ($i = 0; $i < count($values); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, "Period " . ($i + 1));
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell(0, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForLineSeries($valueCell);
    }

    // Behalte die erste Folie linear und ändere nur die Skala der Werte-Achse der Kopie.
    $logarithmicSlide = $presentation->getSlides()->addClone($slide);
    $logarithmicChart = $logarithmicSlide->getShapes()->get_Item(0);
    $valueAxis = $logarithmicChart->getAxes()->getVerticalAxis();
    $valueAxis->setLogarithmic(true);
    $valueAxis->setLogBase(10);

    $presentation->save("LogarithmicAxis.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**Lineare Skala (Folie 1):** Gleiche vertikale Abstände repräsentieren gleiche Unterschiede bei den Anfragen‑Zahlen. Der größte Wert dominiert das Diagramm, sodass die kleineren Werte schwer zu unterscheiden sind.

![Liniendiagramm in PowerPoint, das fünf Anfragen‑Zahlen auf einer linearen Werte‑Achse zeigt](value-axis-linear.png)

**Logarithmische Skala (Folie 2):** Gleiche vertikale Abstände repräsentieren gleiche Verhältnisse. Jeder Zeitraum hat zehnmal so viele Anfragen wie der vorherige, sodass die Punkte auf einer Basis‑10‑Skala eine gerade steigende Linie bilden. Die Achsen‑Beschriftungen zeigen weiterhin die ursprünglichen Anfragen‑Zahlen.

![Die gleichen fünf Anfragen‑Zahlen in PowerPoint auf einer Basis‑10‑logarithmischen Werte‑Achse](value-axis-logarithmic.png)

### **Null‑ und Negativwerte behandeln**

Eine logarithmische Skala kann nur strikt positive Werte anzeigen. Prüfen Sie die Daten, bevor Sie sie aktivieren. Wenn Null‑ oder Negativwerte eine Bedeutung haben, behalten Sie eine lineare Skala bei oder zeigen Sie sie separat. Wenn das Weglassen dieser Werte für die Analyse sinnvoll ist, erklären Sie die Auslassung. Ersetzen Sie sie nicht stillschweigend durch kleine positive Zahlen, da dies die Datenbedeutung ändert. Jede manuell konfigurierte Minimum‑ oder Maximum‑Einstellung einer logarithmischen Achse muss ebenfalls positiv sein.

## **FAQ**

**Wie lege ich den Wert fest, an dem eine Achse die andere schneidet (Achsenkreuz)?**

Verwenden Sie [setCrossType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrosstype/), um das Kreuz‑Verhalten auszuwählen. Um einen numerischen Kreuz‑Wert anzugeben, nutzen Sie [setCrossAt](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrossat/). Diese Einstellungen ermöglichen das Verschieben des Achsenkreuzes zu einer geeigneten Basislinie.

**Wie kann ich Teilstrich‑Beschriftungen relativ zur Achse positionieren?**

Rufen Sie [setTickLabelPosition](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelposition/) unter Verwendung von [TickLabelPositionType](https://reference.aspose.com/slides/php-java/aspose.slides/ticklabelpositiontype/) auf: `Low`, `High`, `NextTo` oder `None`. Um die Teilstriche selbst zu steuern, verwenden Sie [setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) oder [setMinorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setminortickmark/); diese sind separate Einstellungen zur Beschriftungs‑Positionierung.