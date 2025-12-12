---
title: Diagrammberechnungen für Präsentationen auf Android optimieren
linktitle: Diagrammberechnungen
type: docs
weight: 50
url: /de/androidjava/chart-calculations/
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
- Android
- Java
- Aspose.Slides
description: "Verstehen Sie Diagrammberechnungen, Datenaktualisierungen und Präzisionssteuerung in Aspose.Slides für Android für PPT und PPTX, mit praktischen Java-Codebeispielen."
---

## **Tatsächliche Werte von Diagrammelementen berechnen**
Aspose.Slides for Android via Java stellt eine einfache API zum Abrufen dieser Eigenschaften bereit. Eigenschaften des Interfaces [IAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAxis) liefern Informationen über die tatsächliche Position des Achsen‑Diagrammelements ([IAxis.getActualMaxValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAxis#getActualMaxValue--), [IAxis.getActualMinValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAxis#getActualMinValue--), [IAxis.getActualMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAxis#getActualMajorUnit--), [IAxis.getActualMinorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAxis#getActualMinorUnit--), [IAxis.getActualMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAxis#getActualMajorUnitScale--), [IAxis.getActualMinorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAxis#getActualMinorUnitScale--)). Es ist erforderlich, vorher die Methode [IChart.validateChartLayout()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChart#validateChartLayout--) aufzurufen, damit die Eigenschaften mit tatsächlichen Werten gefüllt werden.
```java
Presentation pres = new Presentation();
try {
    Chart chart = (Chart)pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();
    
    double maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    double minValue = chart.getAxes().getVerticalAxis().getActualMinValue();
    
    double majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
    double minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();
} finally {
    if (pres != null) pres.dispose();
}
```


## **Tatsächliche Position von übergeordneten Diagrammelementen ermitteln**
Aspose.Slides for Android via Java stellt eine einfache API zum Abrufen dieser Eigenschaften bereit. Eigenschaften des Interfaces [IActualLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IActualLayout) liefern Informationen über die tatsächliche Position des übergeordneten Diagrammelements ([IActualLayout.getActualX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IActualLayout#getActualX--), [IActualLayout.getActualY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IActualLayout#getActualY--), [IActualLayout.getActualWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IActualLayout#getActualWidth--), [IActualLayout.getActualHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IActualLayout#getActualHeight--)). Es ist erforderlich, vorher die Methode [IChart.validateChartLayout()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChart#validateChartLayout--) aufzurufen, damit die Eigenschaften mit tatsächlichen Werten gefüllt werden.
```java
Presentation pres = new Presentation();
try {
    Chart chart = (Chart) pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();

    double x = chart.getPlotArea().getActualX();
    double y = chart.getPlotArea().getActualY();
    double w = chart.getPlotArea().getActualWidth();
    double h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) pres.dispose();
}
```


## **Diagrammelemente ausblenden**
Dieses Thema erklärt, wie Sie Informationen im Diagramm ausblenden können. Mit Aspose.Slides for Android via Java können Sie **Titel**, **Vertikale Achse**, **Horizontale Achse** und **Gitternetzlinien** im Diagramm ausblenden. Das nachstehende Codebeispiel zeigt, wie diese Eigenschaften verwendet werden.
```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 140, 118, 320, 370);

    //Diagrammtitel ausblenden
    chart.setTitle(false);

    ///Werte-Achse ausblenden
    chart.getAxes().getVerticalAxis().setVisible(false);

    //Kategorie-Achsen Sichtbarkeit
    chart.getAxes().getHorizontalAxis().setVisible(false);

    //Legende ausblenden
    chart.setLegend(false);

    //Hauptgitterlinien ausblenden
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    for (int i = 0; i < chart.getChartData().getSeries().size(); i++)
    {
        chart.getChartData().getSeries().removeAt(i);
    }

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    series.getMarker().setSymbol(MarkerStyleType.Circle);
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.Top);
    series.getMarker().setSize(15);

    //Festlegen der Serienlinienfarbe
    series.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);
    series.getFormat().getLine().setDashStyle(LineDashStyle.Solid);

    pres.save("HideInformationFromChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Funktionieren externe Excel‑Arbeitsmappen als Datenquelle und wie wirkt sich das auf die Neuberechnung aus?**

Ja. Ein Diagramm kann auf eine externe Arbeitsmappe verweisen: Wenn Sie die externe Quelle verbinden oder aktualisieren, werden Formeln und Werte aus dieser Arbeitsmappe übernommen, und das Diagramm spiegelt die Änderungen während Öffnen/Bearbeiten wider. Die API ermöglicht es Ihnen, den Pfad zur [externen Arbeitsmappe](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#setExternalWorkbook-java.lang.String-boolean-) anzugeben und die verknüpften Daten zu verwalten.

**Kann ich Trendlinien berechnen und anzeigen, ohne die Regression selbst zu implementieren?**

Ja. [Trendlines](/slides/de/androidjava/trend-line/) (linear, exponentiell und weitere) werden von Aspose.Slides hinzugefügt und aktualisiert; ihre Parameter werden automatisch aus den Seriendaten neu berechnet, sodass Sie keine eigenen Berechnungen implementieren müssen.

**Wenn eine Präsentation mehrere Diagramme mit externen Verknüpfungen enthält, kann ich steuern, welche Arbeitsmappe jedes Diagramm für berechnete Werte verwendet?**

Ja. Jedes Diagramm kann auf seine eigene [externe Arbeitsmappe](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#setExternalWorkbook-java.lang.String-boolean-) verweisen, oder Sie können pro Diagramm unabhängig von den anderen eine externe Arbeitsmappe erstellen/ersetzen.