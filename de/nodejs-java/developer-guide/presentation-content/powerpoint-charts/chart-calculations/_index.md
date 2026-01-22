---
title: Diagrammberechnungen für Präsentationen in JavaScript optimieren
linktitle: Diagrammberechnungen
type: docs
weight: 50
url: /de/nodejs-java/chart-calculations/
keywords:
- Diagrammberechnungen
- Diagrammelemente
- Elementposition
- tatsächliche Position
- Kindelement
- Elternelement
- Diagrammwerte
- tatsächlicher Wert
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Verstehen Sie Diagrammberechnungen, Datenaktualisierungen und Präzisionskontrolle in Aspose.Slides für Node.js für PPT und PPTX, mit praktischen JavaScript-Codebeispielen."
---

## **Tatsächliche Werte von Diagrammelementen berechnen**

Aspose.Slides for Node.js via Java bietet eine einfache API zum Abrufen dieser Eigenschaften. Eigenschaften der [Axis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Axis) Klasse liefern Informationen über die tatsächliche Position des Achsdiagrammelements ([Axis.getActualMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Axis#getActualMaxValue--), [Axis.getActualMinValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Axis#getActualMinValue--), [Axis.getActualMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Axis#getActualMajorUnit--), [Axis.getActualMinorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Axis#getActualMinorUnit--), [Axis.getActualMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Axis#getActualMajorUnitScale--), [Axis.getActualMinorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Axis#getActualMinorUnitScale--)). Es ist notwendig, die Methode [Chart.validateChartLayout()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Chart#validateChartLayout--) vorher aufzurufen, um die Eigenschaften mit den tatsächlichen Werten zu füllen.
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

Aspose.Slides for Node.js via Java bietet eine einfache API zum Abrufen dieser Eigenschaften. Eigenschaften der `ActualLayout` Klasse liefern Informationen über die tatsächliche Position des übergeordneten Diagrammelements `ActualLayout.getActualX`, `ActualLayout.getActualY`, `ActualLayout.getActualWidth`, `ActualLayout.getActualHeight`. Es ist notwendig, die Methode [Chart.validateChartLayout()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Chart#validateChartLayout--) vorher aufzurufen, um die Eigenschaften mit den tatsächlichen Werten zu füllen.
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


## **Informationen aus Diagramm ausblenden**

Dieses Thema hilft Ihnen zu verstehen, wie Informationen aus einem Diagramm ausgeblendet werden können. Mit Aspose.Slides for Node.js via Java können Sie **Titel, Vertikale Achse, Horizontale Achse** und **Gitternetzlinien** aus dem Diagramm ausblenden. Das nachstehende Codebeispiel zeigt, wie diese Eigenschaften verwendet werden.
```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 140, 118, 320, 370);
    // Diagrammtitel ausblenden
    chart.setTitle(false);
    // /Werte-Achse ausblenden
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
    // Festlegen der Serienlinienfarbe
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

**Unterstützen externe Excel‑Arbeitsmappen eine Datenquelle, und wie wirkt sich das auf die Neuberechnung aus?**

Ja. Ein Diagramm kann auf eine externe Arbeitsmappe verweisen: Wenn Sie die externe Quelle verbinden oder aktualisieren, werden Formeln und Werte aus dieser Arbeitsmappe übernommen, und das Diagramm spiegelt die Änderungen während der Öffnungs‑/Bearbeitungsvorgänge wider. Die API ermöglicht das [Festlegen des Pfads zur externen Arbeitsmappe](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) und die Verwaltung der verknüpften Daten.

**Kann ich Trendlinien berechnen und anzeigen, ohne die Regression selbst zu implementieren?**

Ja. [Trendlinien](/slides/de/nodejs-java/trend-line/) (linear, exponentiell und andere) werden von Aspose.Slides hinzugefügt und automatisch aktualisiert; ihre Parameter werden aus den Seriendaten neu berechnet, sodass Sie keine eigenen Berechnungen durchführen müssen.

**Wenn eine Präsentation mehrere Diagramme mit externen Verknüpfungen enthält, kann ich steuern, welche Arbeitsmappe jedes Diagramm für berechnete Werte verwendet?**

Ja. Jedes Diagramm kann auf seine eigene [externe Arbeitsmappe](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) verweisen, oder Sie können für jedes Diagramm unabhängig voneinander eine externe Arbeitsmappe erstellen/ersetzen.