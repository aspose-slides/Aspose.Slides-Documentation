---
title: Diagrammberechnungen
type: docs
weight: 50
url: /de/nodejs-java/chart-calculations/
---

## **Tatsächliche Werte der Diagrammelemente berechnen**

Aspose.Slides für Node.js über Java bietet eine einfache API zum Abrufen dieser Eigenschaften. Die Eigenschaften der Klasse [Axis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Axis) liefern Informationen über die tatsächliche Position des Achsen‑Diagrammelements ([Axis.getActualMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Axis#getActualMaxValue--), [Axis.getActualMinValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Axis#getActualMinValue--), [Axis.getActualMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Axis#getActualMajorUnit--), [Axis.getActualMinorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Axis#getActualMinorUnit--), [Axis.getActualMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Axis#getActualMajorUnitScale--), [Axis.getActualMinorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Axis#getActualMinorUnitScale--)). Es ist erforderlich, vorher die Methode [Chart.validateChartLayout()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Chart#validateChartLayout--) aufzurufen, um die Eigenschaften mit den tatsächlichen Werten zu füllen.
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();
    var maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    var minValue = chart.getAxes().getVerticalAxis().getActualMinValue();
    var majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
    var minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Tatsächliche Position von übergeordneten Diagrammelementen berechnen**

Aspose.Slides für Node.js über Java bietet eine einfache API zum Abrufen dieser Eigenschaften. Die Eigenschaften der Klasse [ActualLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ActualLayout) liefern Informationen über die tatsächliche Position des übergeordneten Diagrammelements ([ActualLayout.getActualX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ActualLayout#getActualX--), [ActualLayout.getActualY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ActualLayout#getActualY--), [ActualLayout.getActualWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ActualLayout#getActualWidth--), [ActualLayout.getActualHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ActualLayout#getActualHeight--)). Es ist erforderlich, vorher die Methode [Chart.validateChartLayout()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Chart#validateChartLayout--) aufzurufen, um die Eigenschaften mit den tatsächlichen Werten zu füllen.
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();
    var x = chart.getPlotArea().getActualX();
    var y = chart.getPlotArea().getActualY();
    var w = chart.getPlotArea().getActualWidth();
    var h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Informationen im Diagramm ausblenden**

Dieses Thema hilft Ihnen zu verstehen, wie Sie Informationen im Diagramm ausblenden können. Mit Aspose.Slides für Node.js über Java können Sie **Titel, Vertikale Achse, Horizontale Achse** und **Gitternetzlinien** im Diagramm ausblenden. Das nachstehende Code‑Beispiel zeigt, wie diese Eigenschaften verwendet werden.
```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 140, 118, 320, 370);
    // Diagrammtitel ausblenden
    chart.setTitle(false);
    // /Ausblenden der Werteachse
    chart.getAxes().getVerticalAxis().setVisible(false);
    // Sichtbarkeit der Kategorienachse
    chart.getAxes().getHorizontalAxis().setVisible(false);
    // Legende ausblenden
    chart.setLegend(false);
    // Hauptgitternetzlinien ausblenden
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    for (var i = 0; i < chart.getChartData().getSeries().size(); i++) {
        chart.getChartData().getSeries().removeAt(i);
    }
    var series = chart.getChartData().getSeries().get_Item(0);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Circle);
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.Top);
    series.getMarker().setSize(15);
    // Festlegen der Linienfarbe der Serie
    series.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
    series.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.Solid);
    pres.save("HideInformationFromChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Do external Excel workbooks work as a data source, and how does that affect recalculation?**

Ja. Ein Diagramm kann auf eine externe Arbeitsmappe verweisen: Wenn Sie die externe Quelle verbinden oder aktualisieren, werden Formeln und Werte aus dieser Arbeitsmappe übernommen, und das Diagramm spiegelt die Updates während Öffnen/Bearbeiten wider. Die API lässt Sie den [specify the external workbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) Pfad angeben und die verknüpften Daten verwalten.

**Can I compute and display trendlines without implementing regression myself?**

Ja. [Trendlines](/slides/de/nodejs-java/trend-line/) (linear, exponential und andere) werden von Aspose.Slides hinzugefügt und automatisch aus den Seriendaten neu berechnet, sodass Sie keine eigenen Berechnungen durchführen müssen.

**If a presentation has multiple charts with external links, can I control which workbook each chart uses for computed values?**

Ja. Jedes Diagramm kann auf seine eigene [external workbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) verweisen, oder Sie können pro Diagramm unabhängig von den anderen ein externes Arbeitsbuch erstellen/ersetzen.