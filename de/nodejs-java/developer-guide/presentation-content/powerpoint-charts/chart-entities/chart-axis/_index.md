---
title: Diagrammachse
type: docs
url: /de/nodejs-java/chart-axis/
keywords: "PowerPoint Diagrammachse, Präsentationsdiagramme, Java, Diagrammachse manipulieren, Diagrammdaten"
description: "Wie man die PowerPoint-Diagrammachse in JavaScript bearbeitet"
---

## **Ermitteln der Maximalwerte auf der vertikalen Achse in Diagrammen**

Aspose.Slides für Node.js über Java ermöglicht es Ihnen, die minimalen und maximalen Werte einer vertikalen Achse zu erhalten. Führen Sie die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) Klasse.
2. Greifen Sie auf die erste Folie zu.
3. Fügen Sie ein Diagramm mit Standarddaten hinzu.
4. Ermitteln Sie den tatsächlichen Maximalwert der Achse.
5. Ermitteln Sie den tatsächlichen Minimalwert der Achse.
6. Ermitteln Sie die tatsächliche Haupteinheit der Achse.
7. Ermitteln Sie die tatsächliche Nebeneinheit der Achse.
8. Ermitteln Sie die tatsächliche Skala der Haupteinheit der Achse.
9. Ermitteln Sie die tatsächliche Skala der Nebeneinheit der Achse.

Dieser Beispielcode – eine Umsetzung der oben genannten Schritte – zeigt Ihnen, wie Sie die erforderlichen Werte in JavaScript erhalten:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();
    var maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    var minValue = chart.getAxes().getVerticalAxis().getActualMinValue();
    var majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
    var minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();
    // Speichert die Präsentation
    pres.save("MaxValuesVerticalAxis_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Daten zwischen Achsen austauschen**

Aspose.Slides ermöglicht es Ihnen, die Daten zwischen den Achsen schnell zu vertauschen – die auf der vertikalen Achse (y‑Achse) dargestellten Daten werden zur horizontalen Achse (x‑Achse) und umgekehrt verschoben.

Dieser JavaScript‑Code zeigt Ihnen, wie Sie den Datentausch zwischen den Achsen in einem Diagramm durchführen:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 400, 300);
    // Wechselt Zeilen und Spalten
    chart.getChartData().switchRowColumn();
    // Speichert die Präsentation
    pres.save("SwitchChartRowColumns_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Vertikale Achse für Liniendiagramme deaktivieren**

Dieser JavaScript‑Code zeigt Ihnen, wie Sie die vertikale Achse für ein Liniendiagramm ausblenden:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getVerticalAxis().setVisible(false);
    pres.save("chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Horizontale Achse für Liniendiagramme deaktivieren**

Dieser Code zeigt Ihnen, wie Sie die horizontale Achse für ein Liniendiagramm ausblenden:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getHorizontalAxis().setVisible(false);
    pres.save("chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Kategorienachse ändern**

Mit der Eigenschaft **CategoryAxisType** können Sie Ihren bevorzugten Kategorienachsentyp (**date** oder **text**) festlegen. Dieser JavaScript‑Code demonstriert die Vorgehensweise:
```javascript
var presentation = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    var chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(aspose.slides.CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getHorizontalAxis().setMajorUnit(1);
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(aspose.slides.TimeUnitType.Months);
    presentation.save("ChangeChartCategoryAxis_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **Datumsformat für den Wert der Kategorienachse festlegen**

Aspose.Slides für Node.js über Java ermöglicht es Ihnen, das Datumsformat für einen Wert der Kategorienachse festzulegen. Die Vorgehensweise wird in diesem JavaScript‑Code gezeigt:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Area, 50, 50, 450, 300);
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", convertToOADate(java.newInstanceSync("GregorianCalendar", 2015, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", convertToOADate(java.newInstanceSync("GregorianCalendar", 2016, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", convertToOADate(java.newInstanceSync("GregorianCalendar", 2017, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", convertToOADate(java.newInstanceSync("GregorianCalendar", 2018, 1, 1))));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Line);
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B2", 1));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B3", 2));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B4", 3));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B5", 4));
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(aspose.slides.CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy");
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

```javascript
const dayjs = require('dayjs');

function convertToOADate(date) {
    const baseDate = dayjs('1899-12-30');

    const days = date.diff(baseDate, 'day');

    const fractionalDay = (date.hour() / 24) +
                          (date.minute() / (60 * 24)) +
                          (date.second() / (60 * 24 * 60));

    const oaDate = days + fractionalDay;

    return String(oaDate);
}
```


## **Drehwinkel für Diagrammachsentitel festlegen**

Aspose.Slides für Node.js über Java ermöglicht es Ihnen, den Drehwinkel für einen Diagrammachsentitel festzulegen. Dieser JavaScript‑Code demonstriert die Vorgehensweise:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Positionsachse in einer Kategorien‑ oder Werteachse festlegen**

Aspose.Slides für Node.js über Java ermöglicht es Ihnen, die Positionsachse in einer Kategorien‑ oder Werteachse festzulegen. Dieser JavaScript‑Code zeigt, wie die Aufgabe durchgeführt wird:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(true);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Anzeigeeinheits‑Label auf der Werteachse des Diagramms aktivieren**

Aspose.Slides für Node.js über Java ermöglicht es Ihnen, ein Diagramm so zu konfigurieren, dass ein Einheit‑Label auf seiner Werteachse angezeigt wird. Dieser JavaScript‑Code demonstriert die Vorgehensweise:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Millions);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Wie lege ich den Wert fest, an dem eine Achse die andere schneidet (Achsenschnitt)?**

Achsen bieten eine [crossing setting](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/)‑Einstellung: Sie können wählen, ob sie bei Null, beim maximalen Kategorien‑/Wert oder bei einem bestimmten numerischen Wert schneiden. Das ist nützlich, um die X‑Achse nach oben oder unten zu verschieben oder um eine Basislinie hervorzuheben.

**Wie kann ich die Tick‑Beschriftungen relativ zur Achse positionieren (neben, außen, innen)?**

Stellen Sie die [label position](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) auf "cross", "outside" oder "inside" ein. Dadurch wird die Lesbarkeit beeinflusst und insbesondere bei kleinen Diagrammen Platz gespart.