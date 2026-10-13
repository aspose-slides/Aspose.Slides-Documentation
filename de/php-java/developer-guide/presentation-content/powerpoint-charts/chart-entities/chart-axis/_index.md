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
- maximaler Wert
- minimaler Wert
- Achsenlinie
- Datumsformat
- Achsentitel
- Achsenposition
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Sie Aspose.Slides für PHP via Java einsetzen können, um Diagrammachsen in PowerPoint‑Präsentationen für Berichte und Visualisierungen anzupassen."
---
## **Übersicht**

Dieser Artikel erklärt, wie Diagrammachsen mit Aspose.Slides für PHP via Java angepasst werden können. Er behandelt berechnete Achsenwerte, das Vertauschen von Diagrammreihen und -spalten, Achsensichtbarkeit, Kategorienbeschriftungs‑ und Tick‑Mark‑Intervalle, Datums­kategorien und -formatierung, Titelrotation, Achsenpositionierung, Anzeige­einheiten und logarithmische Skalierung.

## **Maximalwerte auf der vertikalen Achse von Diagrammen ermitteln**

Erstellen Sie eine [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) und fügen Sie ein Flächendiagramm mit Standarddaten hinzu. Rufen Sie [validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) auf, bevor Sie berechnete Achsenwerte lesen, damit das Diagrammlayout aktuell ist.

Lesen Sie [getActualMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmaxvalue/) und [getActualMinValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminvalue/) für die Achsenbegrenzungen sowie [getActualMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunit/) und [getActualMinorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunit/) für die Tick‑Intervalle. [getActualMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunitscale/) und [getActualMinorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunitscale/) liefern Zeiteinheitsskalen, die für Datums­achsen relevant sind. Das Beispiel speichert diese Werte in lokalen Variablen und speichert das Diagramm.

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

## **Daten zwischen Achsen austauschen**

Verwenden Sie [switchRowColumn](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/switchrowcolumn/), um die Rollen von Reihen und Kategorien in den Diagrammdaten zu vertauschen. Jede frühere Kategorie wird zu einer Reihe und jede frühere Reihe zu einer Kategorie. Dies ändert die Gruppierung der Daten; es vertauscht nicht die horizontale und vertikale Achse. Das Beispiel verwendet [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) , um die Standarddaten an `Sheet1!A1:D5` zu binden, einschließlich der Kopfzeile und der Kategorie­spalte, bevor Reihen und Spalten vertauscht werden. Es speichert ein Diagramm mit vier Reihen und drei Kategorien.

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

## **Vertikale Achse für Liniendiagramme deaktivieren**

Rufen Sie [setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/) mit `false` für die vertikale Achse auf, um sie auszublenden. Das Beispiel erstellt ein Liniendiagramm mit Standarddaten und speichert es mit ausgeblendeter vertikaler Achse.

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

Rufen Sie [setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/) mit `false` für die horizontale Achse auf, um sie auszublenden. Das Beispiel erstellt ein Liniendiagramm mit Standarddaten und speichert es mit ausgeblendeter horizontaler Achse.

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

## **Eine Kategorienachse ändern**

Verwenden Sie [setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/), um eine Datums‑ oder Text‑Kategorienachse auszuwählen. Dieses Beispiel erfordert `ExistingChart.pptx`, wobei das Diagramm die erste Form auf der ersten Folie ist und die Kategoriezellen numerische Excel‑Datumswerte enthalten. Es ändert die horizontale Achse zu einer Datumsachse. Der Aufruf von [setAutomaticMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticmajorunit/) mit `false`, [setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/) mit `1` und [setMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunitscale/) mit `TimeUnitType::Months` legt Hauptticks im Abstand von einem Monat fest.

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

## **Kategorienachsen‑Beschriftungs‑Intervalle steuern**

Wenn ein Diagramm viele Kategorien hat, reduzieren Sie die Anzahl sichtbarer Achsenbeschriftungen, ohne Kategorien oder Datenpunkte zu entfernen. Rufen Sie [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticticklabelspacing/) mit `false` auf und übergeben Sie das gewünschte Kategorienintervall an [setTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelspacing/). Für Textkategorien in ihrer normalen Reihenfolge beginnt die Zählung bei der ersten Kategorie:

| Intervall | Im Beispiel angezeigte Beschriftungen |
| --- | --- |
| `1` | Kategorie 1, Kategorie 2, Kategorie 3, ... Kategorie 24 |
| `2` | Kategorie 1, Kategorie 3, Kategorie 5, ... Kategorie 23 |
| `3` | Kategorie 1, Kategorie 4, Kategorie 7, ... Kategorie 22 |

Ein Intervall von `3` zeigt jede dritte Beschriftung an, wobei zwischen den angezeigten Beschriftungen zwei ausgeblendet bleiben. Es entfernt nicht die entsprechenden Spalten. Automatischer Abstand wählt ein Intervall basierend auf dem verfügbaren Platz; es zeigt nicht zwangsläufig jede Beschriftung an.

Tick‑Marken haben separate Steuerungen. Rufen Sie [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomatictickmarksspacing/) mit `false` auf und verwenden Sie [setTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settickmarksspacing/), um deren Intervall festzulegen. Zum Beispiel sorgt `1` dafür, dass bei jedem Kategorienintervall ein Tick‑Mark platziert wird, während Beschriftungen nur bei jeder dritten Kategorie angezeigt werden. Verwenden Sie [setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) mit einem sichtbaren Stil, damit Sie das Ergebnis sehen können. Wenn Sie einen der automatischen Abstand‑Setter erneut mit `true` aufrufen, lässt das Diagramm das Intervall wieder automatisch wählen.

Das folgende eigenständige Beispiel erstellt 24 Kategorien und eine Reihe, speichert dann drei Folien in `CategoryAxisIntervals.pptx`: automatische Abstände, manuelle Beschriftungsabstände mit unabhängigen Tick‑Marken und wiederhergestellte automatische Abstände. Die beiden Kopien behalten die ursprünglichen Diagrammdaten bei. Es ist keine Eingabepräsentation erforderlich. Horizontaler Beschriftungstext macht den Unterschied in der Dichte leicht erkennbar.

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

    // Folie 2: jede dritte Beschriftung anzeigen, aber für jede Kategorie ein Tick-Mark behalten.
    $manualSlide = $presentation->getSlides()->addClone($slide);
    $manualChart = $manualSlide->getShapes()->get_Item(0);
    $manualAxis = $manualChart->getAxes()->getHorizontalAxis();
    $manualAxis->setAutomaticTickLabelSpacing(false);
    $manualAxis->setTickLabelSpacing(3);
    $manualAxis->setAutomaticTickMarksSpacing(false);
    $manualAxis->setTickMarksSpacing(1);

    // Folie 3: das Diagramm wählt beide Intervalle erneut.
    $restoredSlide = $presentation->getSlides()->addClone($manualSlide);
    $restoredChart = $restoredSlide->getShapes()->get_Item(0);
    $restoredChart->getAxes()->getHorizontalAxis()->setAutomaticTickLabelSpacing(true);
    $restoredChart->getAxes()->getHorizontalAxis()->setAutomaticTickMarksSpacing(true);

    $presentation->save("CategoryAxisIntervals.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**Automatischer Abstand (Folie 1):** In dieser Darstellung wird jedes zweite Kategorien‑Label angezeigt und auf zwei Zeilen umbrochen. Das automatische Ergebnis kann je nach Diagrammgröße, Schriftarten und Renderer variieren.

![Automatischer Kategorienbeschriftungsabstand mit allen 24 Spalten sichtbar](category-axis-automatic.png)

**Manueller Abstand (Folie 2):** Jede dritte Beschriftung wird in einer Zeile angezeigt, während Tick‑Marken bei jedem Kategorienintervall bleiben. Alle 24 Spalten, einschließlich derjenigen ohne Beschriftungen, bleiben mit denselben Werten sichtbar. Folie 3 stellt das obige automatische Aussehen wieder her.

![Manuelles Kategorienbeschriftungsintervall von drei mit allen 24 Spalten sichtbar](category-axis-manual.png)

### **Den richtigen Achsen‑ und Intervalltyp wählen**

Verwenden Sie dieses Kategorien‑Zähl‑Intervall für eine Text‑Kategorienachse, etwa die Kategorienachse eines Säulen‑, Linien‑, Flächen‑ oder Balkendiagramms. In einem Säulendiagramm ist es die horizontale Achse. In einem horizontalen Balkendiagramm ist die Kategorienachse vertikal, daher wenden Sie diese Einstellungen auf die Achse an, die von [getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/) zurückgegeben wird. Der Abstand der Tick‑Marken gilt auch für eine Reihen‑Achse in Diagrammen, die eine solche besitzen.

Verwenden Sie die Kategorien‑Beschriftungs‑Abstände nicht, um die numerische Skala einer Werteachse festzulegen. Auf einer Werteachse bestimmt [setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/) eine Differenz der Werte: ein Hauptintervall von `10` erzeugt Ticks bei 0, 10, 20 usw., wenn die Achse bei Null beginnt. Ein Kategorien‑Beschriftungs‑Intervall von `3` zählt stattdessen die Kategorienpositionen, unabhängig von deren Werte. Streu‑ und Blasendiagramme verwenden Werteachsen statt einer Text‑Kategorienachse. Für eine Datumsachse verwenden Sie zeitbasierte Hauptintervalle und Skalen wie in [Kategorieachse ändern](#change-a-category-axis) beschrieben.

## **Datumsformat für Kategorienachsen‑Werte festlegen**

Das Beispiel ersetzt die Standarddiagrammdaten durch vier Jahreswerte. Daten werden als OLE‑Automation‑Seriennummern im ersten Arbeitsblatt (Index `0`) gespeichert, berechnet als die Anzahl der Tage seit dem 30. Dezember 1899 für diese Daten. Verwenden Sie [setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) mit `CategoryAxisType::Date`, rufen Sie [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformatlinkedtosource/) mit `false` auf und übergeben Sie `yyyy` an [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformat/), damit die Kategoriebeschriftungen vierstellige Jahreszahlen unabhängig von der Zellformatierung anzeigen.

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

## **Drehwinkel für einen Diagrammachsentitel festlegen**

Rufen Sie [setTitle](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settitle/) mit `true` für die vertikale Achse auf, geben Sie den Titeltext an und verwenden Sie [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) , um den Titel zu drehen. Der Winkel wird in Grad gemessen; dieses Beispiel speichert ein Säulendiagramm mit um 90 Grad gedrehtem Werte‑Achsentitel.

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

## **Achsenposition auf einer Kategorien‑ oder Werteachse festlegen**

Verwenden Sie [setAxisBetweenCategories](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setaxisbetweencategories/), um zu steuern, ob die Werteachse die Kategorienachse zwischen Kategorien oder an den Kategorien‑Tick‑Marken kreuzt. Diese Einstellung gilt für Kategorienachsen. Das Beispiel setzt sie auf `true` für die horizontale Kategorienachse eines Säulendiagramms und speichert das Ergebnis.

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

## **Anzeigeeinheit auf einer Diagramm‑Werteachse festlegen**

Verwenden Sie [setDisplayUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setdisplayunit/), um die Beschriftungen einer Werteachse zu skalieren, ohne die zugrunde liegenden Daten zu ändern. Mit [DisplayUnitType](https://reference.aspose.com/slides/php-java/aspose.slides/displayunittype/) auf `Millions` eingestellt wird ein Wert von 60 000 000 als 60 angezeigt. Das Beispiel erstellt ein Säulendiagramm und wendet die Millionen‑Anzeigeeinheit auf seine vertikale Achse an.

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

## **Logarithmische Werteachse konfigurieren**

Eine logarithmische Werteachse ist nützlich, wenn positive Werte mehrere Größenordnungen umfassen. Beispielsweise könnte ein Dienst 10, 100, 1 000, 10 000 und 100 000 Anfragen über fünf Zeiträume erhalten. Auf einer linearen Skala erscheinen die kleineren Werte dicht beieinander nahe Null. Eine logarithmische Skala erleichtert den Vergleich ihres relativen Wachstums: gleiche Abstände entsprechen gleichen Verhältnissen statt gleichen Differenzen.

Rufen Sie [setLogarithmic](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogarithmic/) mit `true` für die Werteachse auf und verwenden Sie [setLogBase](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogbase/), um die Basis zu wählen. Dies ändert die Darstellung der vorhandenen Werte; es ändert nicht die Daten und fügt keine logarithmische Trendlinie hinzu. Eine Trendlinie stellt eine angepasste Beziehung in den Daten dar und ist ein separates Feature.

### **Werteachse und Basis wählen**

Bei einem Linien‑ oder Säulendiagramm wird die Werteachse von [getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/) zurückgegeben. Bei einem horizontalen Balkendiagramm von [getHorizontalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/gethorizontalaxis/). Streu‑ und Blasendiagramme besitzen zwei Werteachsen, sodass Sie die horizontale Achse für X‑Werte, die vertikale Achse für Y‑Werte oder beide wählen. Wenden Sie keine logarithmische Skalierung auf eine Kategorienachse an.

Die Standard‑Logarithmus‑Basis ist `10`. Für PPTX‑Diagramme kann eine Basis von `2` bis `1000` (einschließlich) verwendet werden; Bruchbasen wie `2,5` werden ebenfalls unterstützt. Bei Basis `10` sind aufeinanderfolgende Potenzen wie 10, 100, 1 000 und 10 000 gleichmäßig verteilt.

### **Lineare und logarithmische Skalierung vergleichen**

Das folgende eigenständige Beispiel erstellt ein Liniendiagramm mit den fünf Anfragenzahlen auf der ersten Folie, dupliziert diese Folie und aktiviert auf der zweiten eine logarithmische Werteachse zur Basis 10. Beide Folien behalten dieselben Daten.

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

    // Behalte die erste Folie linear und ändere nur die Skala der Werteachse der Kopie.
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

**Lineare Skala (Folie 1):** Gleiche vertikale Abstände entsprechen gleichen Unterschieden in den Anfragenzahlen. Der höchste Wert dominiert das Diagramm, sodass die kleineren Werte schwer zu unterscheiden sind.

![Liniendiagramm in PowerPoint mit fünf Anfragenzahlen auf einer linearen Werteachse](value-axis-linear.png)

**Logarithmische Skala (Folie 2):** Gleiche vertikale Abstände entsprechen gleichen Verhältnissen. Jeder Zeitraum hat zehnmal so viele Anfragen wie der vorherige, sodass die Punkte auf der Basis‑10‑Skala eine gerade steigende Linie bilden. Die Achsenbeschriftungen zeigen weiterhin die ursprünglichen Anfragenzahlen.

![Die selben fünf Anfragenzahlen in PowerPoint auf einer logarithmischen Werteachse zur Basis 10](value-axis-logarithmic.png)

### **Umgang mit Null‑ und Negativwerten**

Eine logarithmische Skala kann nur strikt positive Werte darstellen. Prüfen Sie die Daten, bevor Sie sie aktivieren. Wenn Null‑ oder Negativwerte eine Bedeutung haben, behalten Sie eine lineare Skala bei oder zeigen Sie sie separat an. Wenn das Ausschließen dieser Werte für die Analyse sinnvoll ist, erklären Sie die Auslassung. Ersetzen Sie sie nicht stillschweigend durch kleine positive Zahlen, da dies die Bedeutung der Daten verändert. Jeder manuell konfigurierte Minimal‑ oder Maximalwert für eine logarithmische Achse muss ebenfalls positiv sein.

## **FAQ**

**Wie lege ich den Wert fest, an dem eine Achse die andere schneidet (Achsenkreuzung)?**

Verwenden Sie [setCrossType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrosstype/) , um das Kreuzungsverhalten auszuwählen. Um einen numerischen Kreuzungswert anzugeben, verwenden Sie [setCrossAt](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrossat/). Diese Einstellungen ermöglichen es Ihnen, den Achsenkreuzpunkt zu einer geeigneten Referenzlinie zu verschieben.

**Wie kann ich Tick‑Beschriftungen relativ zur Achse positionieren?**

Rufen Sie [setTickLabelPosition](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelposition/) mit [TickLabelPositionType](https://reference.aspose.com/slides/php-java/aspose.slides/ticklabelpositiontype/) : `Low`, `High`, `NextTo` oder `None` auf. Um die Tick‑Marken selbst zu steuern, verwenden Sie [setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) oder [setMinorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setminortickmark/); diese sind von der Beschriftungspositionierung getrennt.