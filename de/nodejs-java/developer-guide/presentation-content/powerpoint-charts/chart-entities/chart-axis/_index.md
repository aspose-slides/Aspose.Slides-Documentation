---
title: Diagrammachsen in Präsentationen mit JavaScript anpassen
linktitle: Diagrammachse
type: docs
url: /de/nodejs-java/chart-axis/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Erfahren Sie, wie Sie JavaScript mit Aspose.Slides für Node.js über Java einsetzen, um Diagrammachsen in PowerPoint-Präsentationen für Berichte und Visualisierungen anzupassen."
---
## **Übersicht**

Dieser Artikel erklärt, wie Diagrammachsen mit Aspose.Slides für Node.js über Java angepasst werden können. Er behandelt berechnete Achsenwerte, das Vertauschen von Diagrammreihen und -spalten, Achsensichtbarkeit, Kategorienbeschriftungs‑ und Tick‑Mark‑Intervalle, Datums‑kategorien und -formatierung, Titel‑rotation, Achsenpositionierung, Anzeige‑einheiten und logarithmische Skalierung.

## **Ermitteln der Maximalwerte auf der vertikalen Achse in Diagrammen**

Erstellen Sie eine [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) und fügen Sie ein Flächendiagramm mit Standarddaten hinzu. Rufen Sie [validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) auf, bevor Sie berechnete Achsenwerte auslesen, damit das Diagrammlayout aktuell ist.

Lesen Sie [getActualMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmaxvalue/) und [getActualMinValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminvalue/) für die Achsenbegrenzungen sowie [getActualMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunit/) und [getActualMinorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunit/) für die Tick‑Intervalle. [getActualMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunitscale/) und [getActualMinorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunitscale/) liefern Zeiteinheiten‑Skalen, die für Datumsachsen relevant sind. Das Beispiel speichert diese Werte in lokalen Variablen und speichert das Diagramm.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();

    var maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    var minValue = chart.getAxes().getVerticalAxis().getActualMinValue();

    var majorUnit = chart.getAxes().getVerticalAxis().getActualMajorUnit();
    var minorUnit = chart.getAxes().getVerticalAxis().getActualMinorUnit();

    var majorUnitScale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale();
    var minorUnitScale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale();

    presentation.save("AxisValues_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Daten zwischen Achsen austauschen**

Verwenden Sie [switchRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/), um die Rollen von Reihen und Kategorien in den Diagrammdaten zu vertauschen. Jede frühere Kategorie wird zu einer Reihe und jede frühere Reihe zu einer Kategorie. Dies ändert, wie die Daten gruppiert werden; es tauscht nicht die horizontale und vertikale Achse aus. Das Beispiel verwendet [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/), um die Standarddaten an `Sheet1!A1:D5` zu binden, einschließlich der Kopfzeilen‑ und Kategoriespalte, bevor Reihen und Spalten getauscht werden. Es speichert ein Diagramm mit vier Reihen und drei Kategorien.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 400, 300);
    chart.getChartData().setRange("Sheet1!A1:D5");
    chart.getChartData().switchRowColumn();

    presentation.save("SwitchChartRowColumns_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Reihenfolge der Achsenzeichnung umkehren**

Verwenden Sie [setPlotOrderReversed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setplotorderreversed/), um eine Kategorie‑ oder Werteachse umzukehren. Beispielsweise kann ein horizontales Balkendiagramm Projektphasen von oben nach unten in derselben Reihenfolge wie das Arbeitsblatt anzeigen: Planung, Entwicklung, Test. Das Umkehren einer Achse ändert die Zeichen­richtung; es sortiert oder ordnet die Arbeitsblattformulardaten nicht neu. Im Vergleich dazu tauscht [switchRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/) die Rollen von Reihen und Kategorien.

Das folgende Beispiel erstellt ein horizontales Balkendiagramm mit drei Phasen und einer Reihe. Es speichert eine Präsentation mit drei Folien: normale Reihenfolge, umgekehrte Kategorien und umgekehrte Werte. Jede Kopie verwendet denselben Datensatz, und nur eine Achse ist in jeder Kopie umgekehrt.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredBar, 50, 40, 620, 320);
    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.ClusteredBar);
    var stages = ["Planning", "Development", "Testing"];
    var values = [10, 30, 20];
    for (var i = 0; i < stages.length; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0, stages[i]);
        chart.getChartData().getCategories().add(categoryCell);
        var valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    // Folie 2: die erste Kategorie oben anzeigen.
    var categorySlide = presentation.getSlides().addClone(slide);
    var categoryChart = categorySlide.getShapes().get_Item(0);
    categoryChart.getAxes().getVerticalAxis().setPlotOrderReversed(true);
    // Behalte die horizontale Werteachse am unteren Rand.
    categoryChart.getAxes().getVerticalAxis().setCrossType(aspose.slides.CrossesType.Maximum);

    // Folie 3: nur die horizontale numerische Skala umkehren.
    var valueSlide = presentation.getSlides().addClone(slide);
    var valueChart = valueSlide.getShapes().get_Item(0);
    valueChart.getAxes().getHorizontalAxis().setPlotOrderReversed(true);

    presentation.save("ReversedAxes.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Umkehren einer Achse kann auch die senkrechte Achse auf die gegenüber­liegende Seite des Diagramms verschieben. [setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/) steuert, wo die andere Achse die konfigurierte Achse kreuzt. In Folie 2 wird sie mit `aspose.slides.CrossesType.Maximum` auf der umgekehrten Kategorienachse aufgerufen, sodass die horizontale Werteachse unten bleibt. Für einen konkreten Kreuzungspunkt verwenden Sie [setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/). Überprüfen Sie die Kreuzungseinstellungen beim Ändern der Richtung, insbesondere wenn das Diagramm bereits einen benutzerdefinierten Kreuzungspunkt hat. Rufen Sie `setPlotOrderReversed` mit `false` auf, um die normale Zeichen­richtung wiederherzustellen; die Kreuzungseinstellungen sind separat.

| Normale Reihenfolge (Folie 1) | Umgekehrte Kategorien (Folie 2) | Umgekehrte Werte (Folie 3) |
| --- | --- | --- |
| ![Horizontales Balkendiagramm mit normaler Kategorie‑ und Werteachsenreihenfolge](axis-order-normal.png) | ![Horizontales Balkendiagramm mit von oben nach unten angezeigten Kategorien](axis-order-categories-reversed.png) | ![Horizontales Balkendiagramm mit umgekehrter Werteachse und Null rechts](axis-order-values-reversed.png) |
| Kategorien laufen von unten nach oben; Werte steigen von links nach rechts. | Planung, Entwicklung und Test laufen von oben nach unten. Werte und Arbeitsblatt‑Zeilenreihenfolge bleiben unverändert. | Kategorien behalten ihre normale Reihenfolge; Werte steigen von rechts nach links. Die Kategorienachse kreuzt bei Null auf der rechten Seite. |

## **Vertikale Achse in Liniendiagrammen deaktivieren**

Rufen Sie [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) mit `false` für die vertikale Achse auf, um sie auszublenden. Das Beispiel erstellt ein Liniendiagramm mit Standarddaten und speichert es mit ausgeblendeter vertikaler Achse.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getVerticalAxis().setVisible(false);

    presentation.save("HiddenVerticalAxis.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Horizontale Achse in Liniendiagrammen deaktivieren**

Rufen Sie [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) mit `false` für die horizontale Achse auf, um sie auszublenden. Das Beispiel erstellt ein Liniendiagramm mit Standarddaten und speichert es mit ausgeblendeter horizontaler Achse.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getHorizontalAxis().setVisible(false);

    presentation.save("HiddenHorizontalAxis.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Eine Kategorienachse ändern**

Verwenden Sie [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/), um eine Datums‑ oder Text‑Kategorienachse auszuwählen. Dieses Beispiel erfordert `ExistingChart.pptx`, wobei das Diagramm die erste Form auf der ersten Folie ist und die Kategoriezellen numerische Excel‑Datumswerte enthalten. Es ändert die horizontale Achse zu einer Datumsachse. Das Aufrufen von [setAutomaticMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticmajorunit/) mit `false`, [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) mit `1` und [setMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunitscale/) mit `TimeUnitType.Months` setzt Hauptticks im Abstand von einem Monat.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().get_Item(0);
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(aspose.slides.CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getHorizontalAxis().setMajorUnit(1);
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(aspose.slides.TimeUnitType.Months);

    presentation.save("ChangeChartCategoryAxis_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Intervall für Kategorienachsen‑Beschriftungen steuern**

Wenn ein Diagramm viele Kategorien hat, reduzieren Sie die Anzahl sichtbarer Achsenbeschriftungen, ohne Kategorien oder Datenpunkte zu entfernen. Rufen Sie [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticticklabelspacing/) mit `false` auf und übergeben Sie das gewünschte Kategorienintervall an [setTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelspacing/). Für Textkategorien in ihrer normalen Reihenfolge beginnt die Zählung beim ersten Element:

| Intervall | Im Beispiel angezeigte Beschriftungen |
| --- | --- |
| `1` | Kategorie 1, Kategorie 2, Kategorie 3, … Kategorie 24 |
| `2` | Kategorie 1, Kategorie 3, Kategorie 5, … Kategorie 23 |
| `3` | Kategorie 1, Kategorie 4, Kategorie 7, … Kategorie 22 |

Ein Intervall von `3` zeigt jede dritte Beschriftung an und lässt zwischen den angezeigten Beschriftungen zwei ausgeblendet. Es entfernt die entsprechenden Spalten nicht. Automatischer Abstand wählt ein Intervall basierend auf dem verfügbaren Platz; er zeigt nicht zwingend jede Beschriftung an.

Tick‑Marks haben separate Einstellungen. Rufen Sie [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomatictickmarksspacing/) mit `false` auf und verwenden Sie [setTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settickmarksspacing/) um ihr Intervall zu setzen. Beispiel: `1` lässt einen Tick‑Mark bei jedem Kategorienintervall, während Beschriftungen nur bei jeder dritten Kategorie erscheinen. Verwenden Sie [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) mit einem sichtbaren Stil, um das Ergebnis zu sehen. Wenn Sie einen automatischen Abstand‑Setter erneut mit `true` aufrufen, wählt das Diagramm das Intervall wieder automatisch.

Das folgende eigenständige Beispiel erstellt 24 Kategorien und eine Reihe, speichert dann drei Folien in `CategoryAxisIntervals.pptx`: automatischer Abstand, manueller Beschriftungsabstand mit unabhängigen Tick‑Marks und wiederhergestellter automatischer Abstand. Die beiden Kopien behalten die ursprünglichen Diagrammdaten. Keine Eingabe‑Präsentation ist erforderlich. Der horizontale Beschriftungstext verdeutlicht die Unterschiedlichkeit in der Dichte.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 30, 40, 660, 320);

    chart.setLegend(false);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.ClusteredColumn);
    for (var i = 0; i < 24; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
        var valueCell = workbook.getCell(0, i + 1, 1, 10 + i % 6 * 5);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    var axis = chart.getAxes().getHorizontalAxis();
    axis.setCategoryAxisType(aspose.slides.CategoryAxisType.Text);
    axis.getTextFormat().getTextBlockFormat().setRotationAngle(0);
    axis.getTextFormat().getPortionFormat().setFontHeight(12);
    axis.setMajorTickMark(aspose.slides.TickMarkType.Outside);
    axis.setAutomaticTickLabelSpacing(true);
    axis.setAutomaticTickMarksSpacing(true);

    // Folie 2: jede dritte Beschriftung anzeigen, aber für jede Kategorie einen Tick‑Mark beibehalten.
    var manualSlide = presentation.getSlides().addClone(slide);
    var manualChart = manualSlide.getShapes().get_Item(0);
    var manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // Folie 3: das Diagramm die beiden Intervalle erneut wählen lassen.
    var restoredSlide = presentation.getSlides().addClone(manualSlide);
    var restoredChart = restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Automatischer Abstand (Folie 1):** In dieser Darstellung wird jede zweite Kategorienbeschriftung angezeigt und auf zwei Zeilen umgebrochen. Das automatische Ergebnis kann je nach Diagrammgröße, Schriftarten und Renderer variieren.

![Automatischer Kategorienbeschriftungsabstand mit allen 24 Spalten sichtbar](category-axis-automatic.png)

**Manueller Abstand (Folie 2):** Jede dritte Beschriftung wird in einer Zeile angezeigt, während Tick‑Marks bei jedem Kategorienintervall bleiben. Alle 24 Spalten, auch jene ohne Beschriftungen, bleiben sichtbar mit denselben Werten. Folie 3 stellt das oben gezeigte automatische Erscheinungsbild wieder her.

![Manueller Kategorienbeschriftungsintervall von drei mit allen 24 Spalten sichtbar](category-axis-manual.png)

### **Wählen Sie die richtige Achse und das richtige Intervall**

Verwenden Sie dieses Kategoriezähl‑Intervall für eine Text‑Kategorienachse, z. B. die Kategorienachse eines Säulen‑, Linien‑, Flächen‑ oder Balkendiagramms. In einem Säulendiagramm ist es die horizontale Achse. In einem horizontalen Balkendiagramm ist die Kategorienachse vertikal, daher wenden Sie diese Einstellungen auf die Achse an, die von [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/) zurückgegeben wird. Die Tick‑Mark‑Abstände gelten ebenfalls für eine Serienachse in Diagrammen, die eine solche besitzen.

Verwenden Sie die Kategorienbeschriftungsabstände nicht, um die numerische Skala einer Werteachse festzulegen. Auf einer Werteachse gibt [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) eine Werte‑Differenz an: z. B. erzeugt ein Hauptintervall von `10` Ticks bei 0, 10, 20 usw., wenn die Achse bei Null startet. Ein Kategorienbeschriftungsintervall von `3` zählt stattdessen Kategorienpositionen, unabhängig von deren Datenwerten. Streu‑ und Blasendiagramme verwenden Werteachsen statt einer Text‑Kategorienachse. Für eine Datumsachse verwenden Sie zeitbasierte Haupteinheiten und Skalen wie in [Eine Kategorienachse ändern](#change-a-category-axis) beschrieben.

## **Datumsformat für Kategorienachswerte festlegen**

Das Beispiel ersetzt die Standarddiagrammdaten durch vier Jahreswerte. Daten werden als OLE‑Automation‑Seriennummern im ersten Arbeitsblatt (Index `0`) gespeichert, berechnet als Anzahl der Tage seit dem 30. Dezember 1899 für diese Daten. Die JavaScript‑Berechnung verwendet UTC‑Zeitstempel und teilt die Differenz durch 86 400 000 Millisekunden pro Tag. Verwenden Sie [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) mit `CategoryAxisType.Date`, rufen Sie [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformatlinkedtosource/) mit `false` auf und übergeben Sie `yyyy` an [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformat/), sodass die Kategorienbeschriftungen vierstellige Jahreszahlen unabhängig von der Zellenformatierung anzeigen.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 50, 50, 450, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var baseDate = Date.UTC(1899, 11, 30);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Line);
    for (var i = 0; i < 4; i++) {
        var date = Date.UTC(2015 + i, 0, 1);
        var categoryCell = workbook.getCell(0, i + 1, 0, (date - baseDate) / 86400000);
        chart.getChartData().getCategories().add(categoryCell);

        var valueCell = workbook.getCell(0, i + 1, 1, i + 1);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    chart.getAxes().getHorizontalAxis().setCategoryAxisType(aspose.slides.CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy");

    presentation.save("DateAxisFormat.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Drehwinkel für einen Diagrammachsentitel festlegen**

Rufen Sie [setTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settitle/) mit `true` für die vertikale Achse auf, geben Sie den Titeltext an und verwenden Sie [setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setrotationangle/), um den Titel zu drehen. Der Winkel wird in Grad gemessen; dieses Beispiel speichert ein Säulendiagramm mit um 90 Grad gedrehtem Werteachsentitel.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("Value");
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90);

    presentation.save("RotatedAxisTitle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Achsenposition bei einer Kategorien‑ oder Werteachse festlegen**

Verwenden Sie [setAxisBetweenCategories](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setaxisbetweencategories/), um zu steuern, ob die Werteachse die Kategorienachse zwischen den Kategorien oder an den Kategorien‑Tick‑Marks kreuzt. Diese Einstellung gilt für Kategorienachsen. Das Beispiel setzt sie auf `true` bei der horizontalen Kategorienachse eines Säulendiagramms und speichert das Ergebnis.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(true);

    presentation.save("AxisBetweenCategories.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Anzeige­einheit einer Diagramm‑Werteachse festlegen**

Verwenden Sie [setDisplayUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setdisplayunit/), um die Beschriftungen einer Werteachse zu skalieren, ohne die zugrunde liegenden Daten zu ändern. Mit [DisplayUnitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/displayunittype/) auf `Millions` angezeigt, wird ein Wert von 60 000 000 als 60 dargestellt. Das Beispiel erstellt ein Säulendiagramm und wendet die Millionen‑Anzeige‑Einheit auf seine vertikale Achse an.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Millions);

    presentation.save("Result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Logarithmische Werteachse konfigurieren**

Eine logarithmische Werteachse ist nützlich, wenn positive Werte mehrere Größenordnungen umfassen. Beispielsweise kann ein Dienst in fünf Zeiträumen 10, 100, 1 000, 10 000 und 100 000 Anfragen erhalten. Auf einer linearen Skala liegen die kleineren Werte nahe beieinander nahe Null. Eine logarithmische Skala macht ihr relatives Wachstum leichter vergleichbar: gleiche Abstände stehen für gleiche Verhältnisse statt gleicher Differenzen.

Rufen Sie [setLogarithmic](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogarithmic/) mit `true` für die Werteachse auf und verwenden Sie [setLogBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogbase/), um die Basis zu wählen. Dies ändert, wie die vorhandenen Werte angezeigt werden; es ändert nicht die Daten und fügt keine logarithmische Trendlinie hinzu. Eine Trendlinie stellt eine angepasste Beziehung in den Daten dar und ist eine separate Funktion.

### **Wertenachse und Basis auswählen**

Für ein Linien‑ oder Säulendiagramm wird die Werteachse über [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/) zurückgegeben. Für ein horizontales Balkendiagramm wird sie über [getHorizontalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/gethorizontalaxis/) zurückgegeben. Streu‑ und Blasendiagramme besitzen zwei Werteachsen; wählen Sie die horizontale Achse für X‑Werte, die vertikale Achse für Y‑Werte oder beide. Wenden Sie keine logarithmische Skalierung auf eine Kategorienachse an.

Die Standard‑Logarithmus‑Basis ist `10`. Für PPTX‑Diagramme ist eine Basis von `2` bis `1000` (inklusive) zulässig; Bruch‑Basen wie `2.5` werden ebenfalls unterstützt. Bei Basis `10` sind aufeinanderfolgende Potenzen wie 10, 100, 1 000 und 10 000 gleichmäßig verteilt.

### **Lineare und logarithmische Skalierung vergleichen**

Das folgende eigenständige Beispiel erstellt ein Liniendiagramm mit den fünf Anfragen‑Zahlen auf Folie 1, dupliziert dann diese Folie und aktiviert auf Folie 2 eine Basis‑10‑logarithmische Werteachse. Beide Folien behalten dieselben Daten.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 30, 40, 660, 200);

    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Line);
    var values = [10, 100, 1000, 10000, 100000];

    for (var i = 0; i < values.length; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0, "Period " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);

        var valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // Behalte die erste Folie linear und ändere nur die Werteachsen-Skala der Kopie.
    var logarithmicSlide = presentation.getSlides().addClone(slide);
    var logarithmicChart = logarithmicSlide.getShapes().get_Item(0);
    var valueAxis = logarithmicChart.getAxes().getVerticalAxis();
    valueAxis.setLogarithmic(true);
    valueAxis.setLogBase(10);

    presentation.save("LogarithmicAxis.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Lineare Skalierung (Folie 1):** Gleich große vertikale Abstände stehen für gleiche Unterschiede in den Anfragen‑Zahlen. Der größte Wert dominiert das Diagramm, sodass die kleineren Werte schwer zu unterscheiden sind.

![Liniendiagramm in PowerPoint, das fünf Anfragen‑Zahlen auf einer linearen Werteachse zeigt](value-axis-linear.png)

**Logarithmische Skalierung (Folie 2):** Gleich große vertikale Abstände stehen für gleiche Verhältnisse. Jeder Zeitraum hat zehnmal so viele Anfragen wie der vorherige, sodass die Punkte auf einer Basis‑10‑Skala eine gerade steigende Linie bilden. Die Achsenbeschriftungen zeigen weiterhin die ursprünglichen Anfragen‑Zahlen.

![Die gleichen fünf Anfragen‑Zahlen in PowerPoint auf einer Basis‑10‑logarithmischen Werteachse](value-axis-logarithmic.png)

### **Umgang mit Null‑ und Negativwerten**

Eine logarithmische Skala kann nur strikt positive Werte anzeigen. Überprüfen Sie die Daten, bevor Sie sie aktivieren. Wenn Null‑ oder Negativwerte eine Bedeutung haben, behalten Sie eine lineare Skala bei oder zeigen Sie sie separat an. Wenn das Ausschließen dieser Werte für die Analyse sinnvoll ist, erläutern Sie die Auslassung. Ersetzen Sie sie nicht stillschweigend durch kleine positive Zahlen, da dies die Bedeutung der Daten ändert. Jeder manuell konfigurierte Minimal‑ oder Maximalwert einer logarithmischen Achse muss ebenfalls positiv sein.

## **FAQ**

**Wie lege ich den Wert fest, an dem eine Achse die andere kreuzt (Achsenkreuzung)?**

Verwenden Sie [setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/), um das Kreuzungsverhalten auszuwählen. Um einen numerischen Kreuzungswert anzugeben, verwenden Sie [setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/). Diese Einstellungen ermöglichen es Ihnen, den Achsenkreuzungs‑Baseline verschieben.

**Wie kann ich Tick‑Beschriftungen relativ zur Achse positionieren?**

Rufen Sie [setTickLabelPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelposition/) mit einem [TickLabelPositionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ticklabelpositiontype/) auf: `Low`, `High`, `NextTo` oder `None`. Um die Tick‑Marks selbst zu steuern, verwenden Sie [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) oder [setMinorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setminortickmark/); diese sind unabhängig von der Beschriftungsposition.