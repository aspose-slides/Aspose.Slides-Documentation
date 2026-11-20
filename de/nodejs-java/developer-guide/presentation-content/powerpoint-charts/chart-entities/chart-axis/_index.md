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
- maximaler Wert
- minimaler Wert
- Achsenlinie
- Datumsformat
- Achsentitel
- Achsenposition
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Entdecken Sie, wie Sie JavaScript mit Aspose.Slides für Node.js über Java verwenden, um Diagrammachsen in PowerPoint-Präsentationen für Berichte und Visualisierungen anzupassen."
---
## **Übersicht**

Dieser Artikel erklärt, wie man Diagrammachsen mit Aspose.Slides für Node.js über Java anpasst. Er behandelt berechnete Achsenwerte, das Vertauschen von Diagrammzeilen und -spalten, die Sichtbarkeit von Achsen, Intervall für Kategorie‑Beschriftungen und Teilstrich‑Markierungen, Datums‑Kategorien und -Formatierung, Drehung des Titels, Positionierung der Achsen, Anzeige­einheiten und logarithmische Skalierung.

## **Maximale Werte auf der vertikalen Achse von Diagrammen erhalten**

Erstellen Sie eine [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) und fügen Sie ein Flächendiagramm mit Standarddaten hinzu. Rufen Sie [validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) auf, bevor Sie berechnete Achsenwerte lesen, damit das Diagrammlayout aktuell ist.

Lesen Sie [getActualMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmaxvalue/) und [getActualMinValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminvalue/) für die Achsenbegrenzungen und [getActualMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunit/) sowie [getActualMinorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunit/) für die Teilstrich‑Intervalle. [getActualMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunitscale/) und [getActualMinorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunitscale/) liefern zeiteinheitsbasierte Skalen, die für Datumsachsen relevant sind. Das Beispiel speichert diese Werte in lokalen Variablen und speichert das Diagramm.

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

Verwenden Sie [switchRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/), um die Rollen von Reihen und Spalten in den Diagrammdaten zu vertauschen. Jede ehemalige Kategorie wird zu einer Reihe und jede ehemalige Reihe zu einer Kategorie. Dies ändert die Gruppierung der Daten; es vertauscht nicht die horizontale und vertikale Achse. Das Beispiel nutzt [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/), um die Standarddaten an `Sheet1!A1:D5` zu binden, einschließlich der Kopfzeile und der Kategoriespalte, bevor Zeilen und Spalten gewechselt werden. Es speichert ein Diagramm mit vier Reihen und drei Kategorien.

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

## **Reihenfolge der Diagrammdarstellung einer Achse umkehren**

Verwenden Sie [setPlotOrderReversed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setplotorderreversed/), um eine Kategorie‑ oder Werteachse umzukehren. Beispielsweise kann ein horizontales Balkendiagramm Projektphasen von oben nach unten in derselben Reihenfolge wie das Arbeitsblatt anzeigen: Planung, Entwicklung, Test. Das Umkehren einer Achse ändert die Darstellungsrichtung; es sortiert oder ordnet die Arbeitsblattdaten nicht neu. Im Vergleich dazu vertauscht [switchRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/) die Rollen von Reihen und Kategorien.

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
    // Die horizontale Werteachse unten belassen.
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

Das Umkehren einer Achse kann auch die senkrechte Achse auf die gegenüberliegende Seite des Plots verschieben. [setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/) steuert, wo die andere Achse die konfigurierte Achse kreuzt. In Folie 2 wird sie mit `aspose.slides.CrossesType.Maximum` auf der umgekehrten Kategorien‑Achse aufgerufen, wodurch die horizontale Werteachse unten bleibt. Für einen bestimmten Kreuzungspunkt verwenden Sie [setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/). Prüfen Sie die Kreuzungseinstellungen beim Richtungswechsel, besonders wenn das Diagramm bereits einen benutzerdefinierten Kreuzungspunkt hat. Rufen Sie `setPlotOrderReversed` mit `false` auf, um die normale Darstellungsrichtung wiederherzustellen; Kreuzungseinstellungen sind separat.

| Normale Reihenfolge (Folie 1) | Umgekehrte Kategorien (Folie 2) | Umgekehrte Werte (Folie 3) |
| --- | --- | --- |
| ![horizontaler Balkendiagramm mit normaler Reihenfolge von Kategorie‑ und Werteachse](axis-order-normal.png) | ![horizontaler Balkendiagramm mit von oben nach unten angezeigten Kategorien](axis-order-categories-reversed.png) | ![horizontaler Balkendiagramm mit umgekehrter Werteachse und Null rechts](axis-order-values-reversed.png) |
| Kategorien laufen von unten nach oben; Werte steigen von links nach rechts. | Planung, Entwicklung und Test laufen von oben nach unten. Werte und Zeilenreihenfolge im Arbeitsbuch bleiben unverändert. | Kategorien behalten ihre normale Reihenfolge; Werte steigen von rechts nach links. Die Kategorienachse kreuzt bei Null rechts. |

## **Vertikale Achse für Liniendiagramme deaktivieren**

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

## **Horizontale Achse für Liniendiagramme deaktivieren**

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

## **Diagramm‑Gitternetzlinien anzeigen oder ausblenden**

Rufen Sie [getShowMajorGridLines](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getshowmajorgridlines/) und [getShowMinorGridLines](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getshowminorgridlines/) auf, um zu prüfen, welche Gitternetzlinien eine Achse anzeigt. Um kleine Gitternetzlinien anzuzeigen, verwenden Sie [getMinorGridLinesFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getminorgridlinesformat/) und setzen die Linienfüllung auf eine solide, sichtbare Farbe. Um sie auszublenden, setzen Sie die Füllung auf [FillType.NoFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/). Verwenden Sie [getMajorGridLinesFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getmajorgridlinesformat/), um die Linienfüllung für große Gitternetzlinien auf die gleiche Weise zu ändern. Das Ändern der Füllung erhält die Sichtbarkeit der Achse und der Teilstriche.

Die vertikale Achse dieses gruppierten Säulendiagramms zeigt zunächst nur große Gitternetzlinien. Das Beispiel zeigt zuerst die kleinen Gitternetzlinien in dunklem Orange, blendet sie dann wieder aus, bevor die Präsentation gespeichert wird. Es gibt die Sichtbarkeit der Gitternetzlinien nach jedem Schritt aus.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
var java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 30, 30, 660, 230);
    var axis = chart.getAxes().getVerticalAxis();
    console.log("Initial: major=%s, minor=%s", axis.getShowMajorGridLines(), axis.getShowMinorGridLines());

    var minorFill = axis.getMinorGridLinesFormat().getLine().getFillFormat();
    minorFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
    var darkOrange = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    minorFill.getSolidFillColor().setColor(darkOrange);
    console.log("Enabled: minor=%s", axis.getShowMinorGridLines());

    minorFill.setFillType(java.newByte(aspose.slides.FillType.NoFill));
    console.log("Hidden: major=%s, minor=%s", axis.getShowMajorGridLines(), axis.getShowMinorGridLines());

    presentation.save("ChartGridlines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Kleine Gitternetzlinien aktiviert | Kleine Gitternetzlinien ausgeblendet |
| --- | --- |
| ![orangefarbene kleine Gitternetzlinien zwischen den großen Gitternetzlinien auf der vertikalen Achse](minor-gridlines-enabled.png) | ![Dasselbe Säulendiagramm mit nur sichtbaren großen Gitternetzlinien](minor-gridlines-hidden.png) |

## **Kategorie‑Achse ändern**

Verwenden Sie [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/), um eine Datums‑ oder Text‑Kategorie‑Achse auszuwählen. Dieses Beispiel erfordert `ExistingChart.pptx`, wobei das Diagramm das erste Shape auf der ersten Folie ist und die Kategoriezellen numerische Excel‑Datumswerte enthalten. Es ändert die horizontale Achse zu einer Datumsachse. Der Aufruf von [setAutomaticMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticmajorunit/) mit `false`, [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) mit `1` und [setMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunitscale/) mit `TimeUnitType.Months` platziert Hauptteilstriche im Abstand von einem Monat.

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

### **Den Typ der Kategorie‑Achse aus Daten bestimmen**

Rufen Sie nach dem Befüllen der Kategorien [setCategoryAxisTypeAutomatically](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistypeautomatically/) auf und lesen dann [getCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getcategoryaxistype/) aus, um die Auswahl zu prüfen. Dies ist nützlich, wenn dasselbe Diagramm entweder Textbeschriftungen oder numerische Datumswerte erhält. Die Methode bestimmt den Typ beim Aufruf; sie aktiviert keinen dauerhaften Modus, der spätere Datenänderungen erneut auswertet. Rufen Sie sie nach dem Ersetzen der Kategorien erneut auf.

Das folgende Beispiel erstellt ein Diagramm mit Textkategorien und gibt `true` aus, wenn der ausgewählte Typ `CategoryAxisType.Text` ist. Anschließend werden die Kategoriezellwerte durch Datumswerte ersetzt und die Methode erneut aufgerufen, wobei `true` ausgegeben wird, wenn der ausgewählte Typ `CategoryAxisType.Date` ist. Daten werden als numerische OLE‑Automation‑Werte gespeichert, berechnet als die Anzahl der Tage seit dem 30. Dezember 1899, nicht als Datumszeichenketten. Die JavaScript‑Berechnung verwendet UTC‑Zeitstempel und teilt die Differenz durch 86 400 000 Millisekunden pro Tag; Monatsindizes sind nullbasiert. Verwenden Sie `java.newDouble`, um jeden Datumswert als Double an Java zu übergeben. [setCustomNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/setcustomnumberformat/) steuert, wie diese Werte angezeigt werden; es wandelt keinen Text in numerische Datumswerte um. Weitere Informationen zu Kategoriezellen finden Sie unter [Chart Workbook](/slides/de/nodejs-java/chart-workbook/).

Verwenden Sie die automatische Bestimmung, wenn die Eingabe bekanntermaßen Textkategorien oder numerische Datumswerte enthält, wie in diesem Beispiel. Für gewöhnliche numerische Beschriftungen, gemischte Kategorien oder leere Daten rufen Sie explizit [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) auf, um die beabsichtigte Bedeutung zu treffen. Numerische Werte allein begründen nicht, dass die Kategorien Datumsangaben darstellen.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
var java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 30, 40, 660, 320);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var seriesName = workbook.getCell(0, 0, 1, "Sales");
    var series = chart.getChartData().getSeries().add(seriesName, chart.getType());
    var labels = ["First", "Second", "Third"];

    for (var i = 0; i < labels.length; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0, labels[i]);
        chart.getChartData().getCategories().add(categoryCell);

        var valueCell = workbook.getCell(0, i + 1, 1, (i + 1) * 10);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    var axis = chart.getAxes().getHorizontalAxis();
    axis.setCategoryAxisTypeAutomatically();
    console.log(axis.getCategoryAxisType() === aspose.slides.CategoryAxisType.Text); // wahr

    var baseDate = Date.UTC(1899, 11, 30);
    var dates = [Date.UTC(2026, 0, 1), Date.UTC(2026, 0, 2), Date.UTC(2026, 1, 1)];

    for (var i = 0; i < dates.length; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0);
        var dateValue = java.newDouble((dates[i] - baseDate) / 86400000);
        categoryCell.setValue(dateValue);
        categoryCell.setCustomNumberFormat("yyyy-mm-dd");
    }

    axis.setCategoryAxisTypeAutomatically();
    console.log(axis.getCategoryAxisType() === aspose.slides.CategoryAxisType.Date); // wahr

    presentation.save("AutomaticCategoryAxis.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Intervall für Kategorie‑Achsen‑Beschriftungen steuern**

Wenn ein Diagramm viele Kategorien enthält, reduzieren Sie die Anzahl sichtbarer Achsenbeschriftungen, ohne Kategorien oder Datenpunkte zu entfernen. Rufen Sie [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticticklabelspacing/) mit `false` auf und übergeben dann das gewünschte Kategorien‑Intervall an [setTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelspacing/). Für Textkategorien in ihrer normalen Reihenfolge beginnt die Zählung bei der ersten Kategorie:

| Intervall | Im Beispiel angezeigte Beschriftungen |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, … Category 24 |
| `2` | Category 1, Category 3, Category 5, … Category 23 |
| `3` | Category 1, Category 4, Category 7, … Category 22 |

Ein Intervall von `3` zeigt jede dritte Beschriftung an, wobei zwei Beschriftungen zwischen den angezeigten verborgen bleiben. Es entfernt nicht die entsprechenden Spalten. Automatisches Spacing wählt ein Intervall basierend auf dem verfügbaren Platz; es zeigt nicht zwingend jede Beschriftung an.

Teilstriche haben separate Einstellungen. Rufen Sie [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomatictickmarksspacing/) mit `false` auf und verwenden Sie [setTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settickmarksspacing/), um ihr Intervall festzulegen. Zum Beispiel lässt `1` einen Teilstrich bei jedem Kategorien‑Intervall stehen, während Beschriftungen nur bei jeder dritten Kategorie erscheinen. Verwenden Sie [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) mit einem sichtbaren Stil, um das Ergebnis zu sehen. Der erneute Aufruf eines automatischen Spacing‑Setzers mit `true` lässt das Diagramm das Intervall erneut wählen.

Das folgende eigenständige Beispiel erstellt 24 Kategorien und eine Reihe und speichert drei Folien in `CategoryAxisIntervals.pptx`: automatisches Spacing, manuelles Beschriftungs‑Spacing mit unabhängigen Teilstrichen und wiederhergestelltes automatisches Spacing. Die beiden Kopien behalten die ursprünglichen Diagrammdaten. Keine Eingabepräsentation ist erforderlich. Der horizontale Beschriftungstext macht den Unterschied in der Dichte leicht erkennbar.

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

    // Folie 2: jede dritte Beschriftung anzeigen, aber für jede Kategorie einen Teilstrich beibehalten.
    var manualSlide = presentation.getSlides().addClone(slide);
    var manualChart = manualSlide.getShapes().get_Item(0);
    var manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // Folie 3: das Diagramm wieder beide Intervalle wählen lassen.
    var restoredSlide = presentation.getSlides().addClone(manualSlide);
    var restoredChart = restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Automatisches Spacing (Folie 1):** In dieser Darstellung wird jede zweite Kategorien‑Beschriftung angezeigt und bricht in zwei Zeilen um. Das automatische Ergebnis kann je nach Diagrammgröße, Schriftarten und Renderer variieren.

![Automatisches Kategorien‑Beschriftungs‑Spacing mit allen 24 Spalten sichtbar](category-axis-automatic.png)

**Manuelles Spacing (Folie 2):** Jede dritte Beschriftung wird in einer Zeile angezeigt, während Teilstriche bei jedem Kategorien‑Intervall verbleiben. Alle 24 Spalten, einschließlich derer ohne Beschriftungen, bleiben sichtbar mit denselben Werten. Folie 3 stellt das oben gezeigte automatische Erscheinungsbild wieder her.

![Manuelles Kategorien‑Beschriftungs‑Intervall von drei mit allen 24 Spalten sichtbar](category-axis-manual.png)

### **Wähle die korrekte Achse und das Intervall**

Verwenden Sie dieses Kategorien‑Zähl‑Intervall für eine Text‑Kategorie‑Achse, wie die Kategorien‑Achse eines Säulen‑, Linien‑, Flächen‑ oder Balkendiagramms. In einem Säulendiagramm ist sie die horizontale Achse. In einem horizontalen Balkendiagramm ist die Kategorien‑Achse vertikal, sodass diese Einstellungen auf die Achse angewendet werden, die von [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/) zurückgegeben wird. Das Teilstrich‑Spacing gilt auch für eine Reihen‑Achse in Diagrammen, die eine solche besitzen.

Verwenden Sie das Kategorien‑Beschriftungs‑Spacing nicht, um die numerische Skala einer Werte‑Achse festzulegen. Auf einer Werte‑Achse legt [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) einen Unterschied in den Werten fest: Zum Beispiel erzeugt ein Haupteinheit von `10` Teilstriche bei 0, 10, 20 usw., wenn die Achse bei Null beginnt. Ein Kategorien‑Beschriftungs‑Intervall von `3` zählt dagegen Positionsschritte, unabhängig von deren Datenwerten. Streu‑ und Blasendiagramme verwenden Werte‑Achsen statt einer Text‑Kategorie‑Achse. Für eine Datums‑Achse verwenden Sie zeitbasierte Haupteinheiten und Skalen wie in [Kategorie‑Achse ändern](#kategorie‑achse-ändern).

## **Datumsformat für Kategorie‑Achsen‑Werte festlegen**

Das Beispiel ersetzt die Standard‑Diagrammdaten durch vier Jahreswerte. Daten werden als OLE‑Automation‑Seriennummern im ersten Arbeitsblatt (Index `0`) gespeichert, berechnet als die Anzahl der Tage seit dem 30. Dezember 1899 für diese Daten. Die JavaScript‑Berechnung nutzt UTC‑Zeitstempel und teilt die Differenz durch 86 400 000 Millisekunden pro Tag. Verwenden Sie [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) mit `CategoryAxisType.Date`, rufen Sie [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformatlinkedtosource/) mit `false` auf und übergeben Sie `yyyy` an [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformat/), sodass die Kategorien‑Beschriftungen vierstellige Jahreszahlen unabhängig von der Zellenformatierung anzeigen.

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

Rufen Sie [setTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settitle/) mit `true` für die vertikale Achse auf, geben Sie den Titeltext an und verwenden Sie [setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setrotationangle/), um den Titel zu drehen. Der Winkel wird in Grad gemessen; dieses Beispiel speichert ein Säulendiagramm, dessen Werte‑Achsentitel um 90 Grad gedreht ist.

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

## **Achsenposition auf einer Kategorie‑ oder Werteachse festlegen**

Verwenden Sie [setAxisBetweenCategories](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setaxisbetweencategories/), um zu steuern, ob die Werte‑Achse die Kategorien‑Achse zwischen Kategorien oder an den Kategorien‑Teilstrichen kreuzt. Diese Einstellung gilt für Kategorien‑Achsen. Das Beispiel setzt sie auf `true` für die horizontale Kategorien‑Achse eines Säulendiagramms und speichert das Ergebnis.

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

## **Anzeige­einheit auf einer Werteachse festlegen**

Verwenden Sie [setDisplayUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setdisplayunit/), um die Beschriftungen einer Werte‑Achse zu skalieren, ohne die zugrunde liegenden Daten zu ändern. Mit [DisplayUnitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/displayunittype/) auf `Millions` wird ein Wert von 60 000 000 als 60 angezeigt. Das Beispiel erstellt ein Säulendiagramm und wendet die Millionen‑Anzeige­einheit auf seine vertikale Achse an.

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

Eine logarithmische Werte‑Achse ist nützlich, wenn positive Werte mehrere Größenordnungen umfassen. Zum Beispiel könnte ein Dienst 10, 100, 1 000, 10 000 und 100 000 Anfragen über fünf Zeiträume erhalten. Auf einer linearen Skala liegen die kleineren Werte nahe beieinander bei Null. Eine logarithmische Skala macht ihr relatives Wachstum leichter vergleichbar: gleiche Abstände repräsentieren gleiche Verhältnisse statt gleicher Differenzen.

Rufen Sie [setLogarithmic](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogarithmic/) mit `true` für die Werte‑Achse auf und verwenden Sie [setLogBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogbase/), um die Basis zu wählen. Dies ändert, wie die vorhandenen Werte angezeigt werden; es ändert nicht die Daten oder fügt eine logarithmische Trendlinie hinzu. Eine Trendlinie stellt eine angepasste Beziehung in den Daten dar und ist ein separates Feature.

### **Werteachse und Basis auswählen**

Für ein Linien‑ oder Säulendiagramm wird die Werte‑Achse von [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/) zurückgegeben. Für ein horizontales Balkendiagramm von [getHorizontalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/gethorizontalaxis/). Streu‑ und Blasendiagramme besitzen zwei Werte‑Achsen, sodass Sie die horizontale Achse für X‑Werte, die vertikale Achse für Y‑Werte oder beide auswählen. Wenden Sie keine logarithmische Skalierung auf eine Kategorien‑Achse an.

Die Standard‑logarithmische Basis ist `10`. Für PPTX‑Diagramme ist jede Basis von `2` bis `1000` zulässig; Bruchbasen wie `2.5` werden ebenfalls unterstützt. Mit Basis `10` sind aufeinanderfolgende Potenzen wie 10, 100, 1 000 und 10 000 gleichmäßig verteilt.

### **Lineare und logarithmische Skalierung vergleichen**

Das folgende eigenständige Beispiel erstellt ein Liniendiagramm mit den fünf Anfragen‑Zahlen auf Folie 1, kopiert diese Folie und aktiviert auf Folie 2 eine logarithmische Werte‑Achse zur Basis 10. Beide Folien behalten dieselben Daten.

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

    // Behalte die erste Folie linear und ändere nur die Skala der Werteachse der Kopie.
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

**Lineare Skalierung (Folie 1):** Gleiche vertikale Abstände repräsentieren gleiche Unterschiede in den Anfragen‑Zahlen. Der größte Wert dominiert das Diagramm, sodass die kleineren Werte schwer zu unterscheiden sind.

![Liniendiagramm in PowerPoint, das fünf Anfragen‑Zahlen auf einer linearen Werte‑Achse zeigt](value-axis-linear.png)

**Logarithmische Skalierung (Folie 2):** Gleiche vertikale Abstände repräsentieren gleiche Verhältnisse. Jede Periode hat zehnmal so viele Anfragen wie die vorherige, sodass die Punkte auf einer Basis‑10‑Skala eine gerade steigende Linie bilden. Die Achsenbeschriftungen zeigen weiterhin die ursprünglichen Anfragen‑Zahlen.

![Dieselben fünf Anfragen‑Zahlen in PowerPoint auf einer logarithmischen Werte‑Achse zur Basis 10](value-axis-logarithmic.png)

### **Umgang mit Null- und Negativwerten**

Eine logarithmische Skala kann nur strikt positive Werte anzeigen. Prüfen Sie die Daten, bevor Sie sie aktivieren. Wenn Null‑ oder Negativwerte bedeutungsvoll sind, behalten Sie eine lineare Skala bei oder zeigen Sie sie separat. Wenn das Entfernen dieser Werte für die Analyse sinnvoll ist, erklären Sie das Weglassen. Ersetzen Sie sie nicht stillschweigend durch kleine positive Zahlen, da dies die Aussagekraft der Daten ändert. Jeder manuell konfigurierte Minimal‑ oder Maximalwert für eine logarithmische Achse muss ebenfalls positiv sein.

## **FAQ**

**Wie lege ich den Wert fest, an dem eine Achse die andere schneidet (Achsenkreuzung)?**

Verwenden Sie [setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/), um das Kreuzungsverhalten auszuwählen. Um einen numerischen Kreuzungswert anzugeben, nutzen Sie [setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/). Diese Einstellungen ermöglichen es Ihnen, die Achsenkreuzung an eine geeignete Basislinie zu verschieben.

**Wie kann ich Teilstrich‑Beschriftungen relativ zur Achse positionieren?**

Rufen Sie [setTickLabelPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelposition/) unter Verwendung von [TickLabelPositionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ticklabelpositiontype/) auf: `Low`, `High`, `NextTo` oder `None`. Um die Teilstriche selbst zu steuern, verwenden Sie [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) oder [setMinorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setminortickmark/); diese sind von der Beschriftungspositionierung getrennt.