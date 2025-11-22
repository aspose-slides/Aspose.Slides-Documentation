---
title: Erstellen oder Aktualisieren von PowerPoint‑Präsentationsdiagrammen in JavaScript
linktitle: Diagramm erstellen
type: docs
weight: 10
url: /de/nodejs-java/create-chart/
keywords: "Diagramm erstellen, Streudiagramm, Kreisdiagramm, Tree‑Map‑Diagramm, Aktienkursdiagramm, Box‑und‑Whisker‑Diagramm, Histogramm‑Diagramm, Trichter‑Diagramm, Sunburst‑Diagramm, Mehrkategorie‑Diagramm, PowerPoint‑Präsentation, Java, Aspose.Slides für Node.js via Java"
description: "Diagramm in PowerPoint‑Präsentation in JavaScript erstellen"
---

## Übersicht

Dieser Artikel beschreibt, wie man **PowerPoint-Präsentationsdiagramme in Java** erstellt. Sie können die Diagramme auch **in JavaScript aktualisieren**. Er behandelt folgende Themen.

_Diagramm_: **Normal**
- [Java PowerPoint-Diagramm erstellen](#java-create-powerpoint-chart)
- [Java Präsentationsdiagramm erstellen](#java-create-presentation-chart)
- [Java PowerPoint-Präsentationsdiagramm erstellen](#java-create-powerpoint-presentation-chart)

_Diagramm_: **Streudiagramm**
- [Java Streudiagramm erstellen](#java-create-scattered-chart)
- [Java PowerPoint-Streudiagramm erstellen](#java-create-powerpoint-scattered-chart)
- [Java PowerPoint-Präsentationsstreudiagramm erstellen](#java-create-powerpoint-presentation-scattered-chart)

_Diagramm_: **Kreisdiagramm**
- [Java Kreisdiagramm erstellen](#java-create-pie-chart)
- [Java PowerPoint-Kreisdiagramm erstellen](#java-create-powerpoint-pie-chart)
- [Java PowerPoint-Präsentationskreisdiagramm erstellen](#java-create-powerpoint-presentation-pie-chart)

_Diagramm_: **Tree Map**
- [Java Tree‑Map‑Diagramm erstellen](#java-create-tree-map-chart)
- [Java PowerPoint‑Tree‑Map‑Diagramm erstellen](#java-create-powerpoint-tree-map-chart)
- [Java PowerPoint‑Präsentations‑Tree‑Map‑Diagramm erstellen](#java-create-powerpoint-presentation-tree-map-chart)

_Diagramm_: **Aktienkurs**
- [Java Aktienkurs‑Diagramm erstellen](#java-create-stock-chart)
- [Java PowerPoint‑Aktienkurs‑Diagramm erstellen](#java-create-powerpoint-stock-chart)
- [Java PowerPoint‑Präsentations‑Aktienkurs‑Diagramm erstellen](#java-create-powerpoint-presentation-stock-chart)

_Diagramm_: **Box‑und‑Whisker**
- [Java Box‑und‑Whisker‑Diagramm erstellen](#java-create-box-and-whisker-chart)
- [Java PowerPoint‑Box‑und‑Whisker‑Diagramm erstellen](#java-create-powerpoint-box-and-whisker-chart)
- [Java PowerPoint‑Präsentations‑Box‑und‑Whisker‑Diagramm erstellen](#java-create-powerpoint-presentation-box-and-whisker-chart)

_Diagramm_: **Trichter**
- [Java Trichter‑Diagramm erstellen](#java-create-funnel-chart)
- [Java PowerPoint‑Trichter‑Diagramm erstellen](#java-create-powerpoint-funnel-chart)
- [Java PowerPoint‑Präsentations‑Trichter‑Diagramm erstellen](#java-create-powerpoint-presentation-funnel-chart)

_Diagramm_: **Sunburst**
- [Java Sunburst‑Diagramm erstellen](#java-create-sunburst-chart)
- [Java PowerPoint‑Sunburst‑Diagramm erstellen](#java-create-powerpoint-sunburst-chart)
- [Java PowerPoint‑Präsentations‑Sunburst‑Diagramm erstellen](#java-create-powerpoint-presentation-sunburst-chart)

_Diagramm_: **Histogramm**
- [Java Histogramm‑Diagramm erstellen](#java-create-histogram-chart)
- [Java PowerPoint‑Histogramm‑Diagramm erstellen](#java-create-powerpoint-histogram-chart)
- [Java PowerPoint‑Präsentations‑Histogramm‑Diagramm erstellen](#java-create-powerpoint-presentation-histogram-chart)

_Diagramm_: **Radar**
- [Java Radar‑Diagramm erstellen](#java-create-radar-chart)
- [Java PowerPoint‑Radar‑Diagramm erstellen](#java-create-powerpoint-radar-chart)
- [Java PowerPoint‑Präsentations‑Radar‑Diagramm erstellen](#java-create-powerpoint-presentation-radar-chart)

_Diagramm_: **Mehrkategorie**
- [Java Mehrkategorie‑Diagramm erstellen](#java-create-multi-category-chart)
- [Java PowerPoint‑Mehrkategorie‑Diagramm erstellen](#java-create-powerpoint-multi-category-chart)
- [Java PowerPoint‑Präsentations‑Mehrkategorie‑Diagramm erstellen](#java-create-powerpoint-presentation-multi-category-chart)

_Diagramm_: **Karte**
- [Java Karten‑Diagramm erstellen](#java-create-map-chart)
- [Java PowerPoint‑Karten‑Diagramm erstellen](#java-create-powerpoint-map-chart)
- [Java PowerPoint‑Präsentations‑Karten‑Diagramm erstellen](#java-create-powerpoint-presentation-map-chart)

_Aktion_: **Diagramm aktualisieren**
- [Java PowerPoint‑Diagramm aktualisieren](#java-update-powerpoint-chart)
- [Java Präsentations‑Diagramm aktualisieren](#java-update-presentation-chart)
- [Java PowerPoint‑Präsentations‑Diagramm aktualisieren](#java-update-powerpoint-presentation-chart)


## **Diagramm erstellen**
Diagramme helfen, Daten schnell zu visualisieren und Erkenntnisse zu gewinnen, die aus einer Tabelle oder einem Arbeitsblatt nicht sofort ersichtlich sind. 


**Warum Diagramme erstellen?**

Mit Diagrammen können Sie

* große Datenmengen auf einer Folie einer Präsentation aggregieren, verdichten oder zusammenfassen
* Muster und Trends in Daten aufzeigen
* die Richtung und das Momentum von Daten über die Zeit oder bezogen auf eine bestimmte Maßeinheit ableiten
* Ausreißer, Abweichungen, Fehler, unsinnige Daten usw. erkennen
* komplexe Daten kommunizieren oder präsentieren

In PowerPoint können Sie Diagramme über die Einfügefunktion erstellen, die Vorlagen für viele Diagrammtypen bereitstellt. Mit Aspose.Slides können Sie reguläre Diagramme (basierend auf gängigen Diagrammtypen) und benutzerdefinierte Diagramme erzeugen. 

{{% alert color="primary" %}} 

Um Diagramme zu erstellen, stellt Aspose.Slides die Klasse [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartType) bereit. Die Felder dieser Klasse entsprechen den verschiedenen Diagrammtypen.

{{% /alert %}} 

### **Normale Diagramme erstellen**

_Schritte: Diagramm erstellen_
- <a name="java-create-powerpoint-chart" id="java-create-powerpoint-chart"><strong><em>Schritte:</em> PowerPoint‑Diagramm in JavaScript erstellen</strong></a>
- <a name="java-create-presentation-chart" id="java-create-presentation-chart"><strong><em>Schritte:</em> Präsentations‑Diagramm in JavaScript erstellen</strong></a>
- <a name="java-create-powerpoint-presentation-chart" id="java-create-powerpoint-presentation-chart"><strong><em>Schritte:</em> PowerPoint‑Präsentations‑Diagramm in JavaScript erstellen</strong></a>

_Code‑Schritte:_

1. Erzeugen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Holen Sie sich die Referenz einer Folie über ihren Index.
3. Fügen Sie ein Diagramm mit Daten hinzu und geben Sie den gewünschten Diagrammtyp an. 
4. Fügen Sie dem Diagramm einen Titel hinzu. 
5. Greifen Sie auf das Daten‑Arbeitsblatt des Diagramms zu.
6. Entfernen Sie alle Standard‑Serien und -Kategorien.
7. Fügen Sie neue Serien und Kategorien hinzu.
8. Ergänzen Sie neue Diagrammdaten für die Diagramm‑Serien.
9. Legen Sie eine Füllfarbe für die Diagramm‑Serien fest.
10. Fügen Sie Beschriftungen für die Diagramm‑Serien hinzu. 
11. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser JavaScript‑Code zeigt, wie ein normales Diagramm erstellt wird:
```javascript
// Instanziiert eine Präsentationsklasse, die eine PPTX-Datei repräsentiert
var pres = new aspose.slides.Presentation();
try {
    // Greift auf die erste Folie zu
    var sld = pres.getSlides().get_Item(0);
    // Fügt ein Diagramm mit den Standarddaten hinzu
    var chart = sld.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 0, 0, 500, 500);
    // Setzt den Diagrammtitel
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(aspose.slides.NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.hasTitle();
    // Setzt die erste Serie, um Werte anzuzeigen
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // Setzt den Index für das Diagrammdatensheet
    var defaultWorksheetIndex = 0;
    // Ermittelt das Diagramm-Daten-Worksheet
    var fact = chart.getChartData().getChartDataWorkbook();
    // Löscht die standardmäßig generierten Serien und Kategorien
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    var s = chart.getChartData().getSeries().size();
    s = chart.getChartData().getCategories().size();
    // Fügt neue Serien hinzu
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    // Fügt neue Kategorien hinzu
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    // Nimmt die erste Diagrammserie
    var series = chart.getChartData().getSeries().get_Item(0);
    // Füllt nun die Daten der Serie
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    // Setzt die Füllfarbe für die Serie
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // Nimmt die zweite Diagrammserie
    series = chart.getChartData().getSeries().get_Item(1);
    // Füllt die Seriendaten
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    // Setzt die Füllfarbe für die Serie
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    // Erstelle benutzerdefinierte Beschriftungen für jede Kategorie der neuen Serie
    // Setzt die erste Beschriftung, um den Kategorienamen anzuzeigen
    var lbl = series.getDataPoints().get_Item(0).getLabel();
    lbl.getDataLabelFormat().setShowCategoryName(true);
    lbl = series.getDataPoints().get_Item(1).getLabel();
    lbl.getDataLabelFormat().setShowSeriesName(true);
    // Zeigt den Wert für die dritte Beschriftung
    lbl = series.getDataPoints().get_Item(2).getLabel();
    lbl.getDataLabelFormat().setShowValue(true);
    lbl.getDataLabelFormat().setShowSeriesName(true);
    lbl.getDataLabelFormat().setSeparator("/");
    // Speichert die Präsentation mit Diagramm
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **Streudiagramme erstellen**
Streudiagramme (auch Scatter‑Plots oder X‑Y‑Grafiken genannt) werden häufig verwendet, um Muster zu prüfen oder Korrelationen zwischen zwei Variablen zu demonstrieren. 

Sie sollten ein Streudiagramm verwenden, wenn 

* Sie gepaarte numerische Daten besitzen
* Sie zwei Variablen haben, die gut zusammenpassen
* Sie feststellen wollen, ob zwei Variablen miteinander in Beziehung stehen
* Sie eine unabhängige Variable mit mehreren Werten für eine abhängige Variable haben

<a name="java-create-scattered-chart" id="java-create-scattered-chart"><strong><em>Schritte:</em> Streudiagramm in JavaScript erstellen</strong></a> |
<a name="java-create-powerpoint-scattered-chart" id="java-create-powerpoint-scattered-chart"><strong><em>Schritte:</em> PowerPoint‑Streudiagramm in JavaScript erstellen</strong></a> |
<a name="java-create-powerpoint-presentation-scattered-chart" id="java-create-powerpoint-presentation-scattered-chart"><strong><em>Schritte:</em> PowerPoint‑Präsentations‑Streudiagramm in JavaScript erstellen</strong></a>

1. Folgen Sie den oben beschriebenen Schritten unter [Normale Diagramme erstellen](#creating-normal-charts)
2. Für den dritten Schritt fügen Sie ein Diagramm mit Daten hinzu und wählen als Diagrammtyp einen der folgenden aus
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/#ScatterWithMarkers) - _Streudiagramm mit Markern._
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Streudiagramm mit glatten Linien und Markern._
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/#ScatterWithSmoothLines) - _Streudiagramm mit glatten Linien ohne Marker._
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Streudiagramm mit geraden Linien und Markern._
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/#ScatterWithStraightLines) - _Streudiagramm mit geraden Linien ohne Marker._

Dieser JavaScript‑Code demonstriert das Erstellen von Streudiagrammen mit unterschiedlichen Markertypen:
```javascript
// Instanziert eine Präsentationsklasse, die eine PPTX-Datei repräsentiert
var pres = new aspose.slides.Presentation();
try {
    // Greift auf die erste Folie zu
    var slide = pres.getSlides().get_Item(0);
    // Erstellt das Standarddiagramm
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);
    // Holt den Index des standardmäßigen Diagrammdaten-Worksheets
    var defaultWorksheetIndex = 0;
    // Holt das Diagrammdaten-Worksheet
    var fact = chart.getChartData().getChartDataWorkbook();
    // Löscht die Demo-Serien
    chart.getChartData().getSeries().clear();
    // Fügt neue Serien hinzu
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.getType());
    // Nimmt die erste Diagrammserie
    var series = chart.getChartData().getSeries().get_Item(0);
    // Fügt der Serie einen neuen Punkt (1:3) hinzu
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 1), fact.getCell(defaultWorksheetIndex, 2, 2, 3));
    // Fügt einen neuen Punkt (2:10) hinzu
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 2), fact.getCell(defaultWorksheetIndex, 3, 2, 10));
    // Ändert den Seriotyp
    series.setType(aspose.slides.ChartType.ScatterWithStraightLinesAndMarkers);
    // Ändert den Marker der Diagrammserie
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Star);
    // Nimmt die zweite Diagrammserie
    series = chart.getChartData().getSeries().get_Item(1);
    // Fügt dort einen neuen Punkt (5:2) hinzu
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 5), fact.getCell(defaultWorksheetIndex, 2, 4, 2));
    // Fügt einen neuen Punkt (3:1) hinzu
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 3), fact.getCell(defaultWorksheetIndex, 3, 4, 1));
    // Fügt einen neuen Punkt (2:2) hinzu
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 4, 3, 2), fact.getCell(defaultWorksheetIndex, 4, 4, 2));
    // Fügt einen neuen Punkt (5:1) hinzu
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 5, 3, 5), fact.getCell(defaultWorksheetIndex, 5, 4, 1));
    // Ändert den Marker der Diagrammserie
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Circle);
    pres.save("AsposeChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **Kreisdiagramme erstellen**

Kreisdiagramme eignen sich am besten, um das Verhältnis eines Teils zum Ganzen darzustellen, insbesondere wenn die Daten kategoriale Beschriftungen mit numerischen Werten enthalten. Enthält Ihre Datenmenge jedoch zu viele Teile oder Beschriftungen, sollten Sie stattdessen ein Balkendiagramm in Betracht ziehen.

<a name="java-create-pie-chart" id="java-create-pie-chart"><strong><em>Schritte:</em> Kreisdiagramm in JavaScript erstellen</strong></a> |
<a name="java-create-powerpoint-pie-chart" id="java-create-powerpoint-pie-chart"><strong><em>Schritte:</em> PowerPoint‑Kreisdiagramm in JavaScript erstellen</strong></a> |
<a name="java-create-powerpoint-presentation-pie-chart" id="java-create-powerpoint-presentation-pie-chart"><strong><em>Schritte:</em> PowerPoint‑Präsentations‑Kreisdiagramm in JavaScript erstellen</strong></a>

1. Erzeugen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Holen Sie sich die Referenz einer Folie über ihren Index.
3. Fügen Sie ein Diagramm mit Standarddaten und dem gewünschten Typ (hier [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartType).Pie) hinzu.
4. Greifen Sie auf die Diagrammdaten‑Klasse [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataWorkbook) zu.
5. Entfernen Sie die Standard‑Serien und -Kategorien.
6. Fügen Sie neue Serien und Kategorien hinzu.
7. Ergänzen Sie neue Diagrammdaten für die Serien.
8. Fügen Sie neue Punkte hinzu und definieren Sie individuelle Farben für die Segmente des Kreisdiagramms.
9. Legen Sie Beschriftungen für die Serien fest.
10. Definieren Sie Führungs‑ (Leader‑) Linien für die Serienbeschriftungen.
11. Setzen Sie den Rotationswinkel für das Kreisdiagramm.
12. Schreiben Sie die geänderte Präsentation in eine PPTX‑Datei.

Dieser JavaScript‑Code zeigt, wie ein Kreisdiagramm erstellt wird:
```javascript
// Instanziert eine Präsentationsklasse, die eine PPTX-Datei darstellt
var pres = new aspose.slides.Presentation();
try {
    // Greift auf die erste Folie zu
    var slides = pres.getSlides().get_Item(0);
    // Fügt ein Diagramm mit Standarddaten hinzu
    var chart = slides.getShapes().addChart(aspose.slides.ChartType.Pie, 100, 100, 400, 400);
    // Setzt den Diagrammtitel
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(aspose.slides.NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    // Setzt die erste Serie, um Werte anzuzeigen
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // Setzt den Index für das Diagrammdatenblatt
    var defaultWorksheetIndex = 0;
    // Holt das Diagrammdaten-Worksheet
    var fact = chart.getChartData().getChartDataWorkbook();
    // Löscht die standardmäßig generierten Serien und Kategorien
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    // Fügt neue Kategorien hinzu
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    // Fügt neue Serien hinzu
    var series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    // Füllt die Seriendaten
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    // Funktioniert in neuer Version nicht
    // Fügt neue Punkte hinzu und setzt die Sektorenfarbe
    // series.IsColorVaried = true;
    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(true);
    var point = series.getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));
    // Setzt den Sektorenrand
    point.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    point.getFormat().getLine().setWidth(3.0);
    point.getFormat().getLine().setStyle(aspose.slides.LineStyle.ThinThick);
    point.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    var point1 = series.getDataPoints().get_Item(1);
    point1.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point1.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    // Setzt den Sektorenrand
    point1.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point1.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    point1.getFormat().getLine().setWidth(3.0);
    point1.getFormat().getLine().setStyle(aspose.slides.LineStyle.Single);
    point1.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.LargeDashDot);
    var point2 = series.getDataPoints().get_Item(2);
    point2.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point2.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
    // Setzt den Sektorenrand
    point2.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point2.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    point2.getFormat().getLine().setWidth(2.0);
    point2.getFormat().getLine().setStyle(aspose.slides.LineStyle.ThinThin);
    point2.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.LargeDashDotDot);
    // Erstellt benutzerdefinierte Beschriftungen für jede Kategorie der neuen Serie
    var lbl1 = series.getDataPoints().get_Item(0).getLabel();
    // lbl.ShowCategoryName = true;
    lbl1.getDataLabelFormat().setShowValue(true);
    var lbl2 = series.getDataPoints().get_Item(1).getLabel();
    lbl2.getDataLabelFormat().setShowValue(true);
    lbl2.getDataLabelFormat().setShowLegendKey(true);
    lbl2.getDataLabelFormat().setShowPercentage(true);
    var lbl3 = series.getDataPoints().get_Item(2).getLabel();
    lbl3.getDataLabelFormat().setShowSeriesName(true);
    lbl3.getDataLabelFormat().setShowPercentage(true);
    // Zeigt Führungs­linien für das Diagramm
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(true);
    // Setzt den Rotationswinkel für die Kreisdiagramm‑Sektoren
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);
    // Speichert die Präsentation mit einem Diagramm
    pres.save("PieChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **Liniendiagramme erstellen**

Liniendiagramme (auch Liniendiagramme genannt) eignen sich besonders, wenn Sie Änderungen von Werten über die Zeit darstellen möchten. Mit einem Liniendiagramm können Sie viele Daten gleichzeitig vergleichen, Trends verfolgen, Anomalien hervorheben usw.

1. Erzeugen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Holen Sie sich die Referenz einer Folie über ihren Index.
1. Fügen Sie ein Diagramm mit Standarddaten und dem gewünschten Typ (hier `ChartType.Line`) hinzu.
1. Greifen Sie auf das Daten‑Workbook IChartDataWorkbook zu.
1. Entfernen Sie die Standard‑Serien und -Kategorien.
1. Fügen Sie neue Serien und Kategorien hinzu.
1. Ergänzen Sie neue Diagrammdaten für die Serien.
1. Schreiben Sie die geänderte Präsentation in eine PPTX‑Datei.

Dieser JavaScript‑Code demonstriert das Erstellen eines Liniendiagramms:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var lineChart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 10, 50, 600, 350);
    pres.save("lineChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


Standardmäßig werden die Punkte in einem Liniendiagramm durch gerade, durchgehende Linien verbunden. Möchten Sie stattdessen gestrichelte Linien, können Sie den gewünschten Strichtyp wie folgt angeben:
```javascript
var lineChart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 10, 50, 600, 350);
for (let i = 0; i < lineChart.getChartData().getSeries().size(); i++) {
    let series = lineChart.getChartData().getSeries().get_Item(i);
    series.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.Dash);
});
```


### **Tree‑Map‑Diagramme erstellen**

Tree‑Map‑Diagramme eignen sich besonders für Verkaufsdaten, wenn Sie die relative Größe von Datenkategorien zeigen und gleichzeitig schnell die Kategorien mit dem größten Beitrag hervorheben wollen. 

<a name="java-create-tree-map-chart" id="java-create-tree-map-chart"><strong><em>Schritte:</em> Tree‑Map‑Diagramm in JavaScript erstellen</strong></a> |
<a name="java-create-powerpoint-tree-map-chart" id="java-create-powerpoint-tree-map-chart"><strong><em>Schritte:</em> PowerPoint‑Tree‑Map‑Diagramm in JavaScript erstellen</strong></a> |
<a name="java-create-powerpoint-presentation-tree-map-chart" id="java-create-powerpoint-presentation-tree-map-chart"><strong><em>Schritte:</em> PowerPoint‑Präsentations‑Tree‑Map‑Diagramm in JavaScript erstellen</strong></a>

1. Erzeugen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) Klasse.
2. Holen Sie sich die Referenz einer Folie über ihren Index.
3. Fügen Sie ein Diagramm mit Standarddaten und dem gewünschten Typ (hier [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartType).TreeMap) hinzu.
4. Greifen Sie auf das Daten‑Workbook [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataWorkbook) zu.
5. Entfernen Sie die Standard‑Serien und -Kategorien.
6. Fügen Sie neue Serien und Kategorien hinzu.
7. Ergänzen Sie neue Diagrammdaten für die Serien.
8. Schreiben Sie die geänderte Präsentation in eine PPTX‑Datei.

Dieser JavaScript‑Code zeigt, wie ein Tree‑Map‑Diagramm erstellt wird:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Treemap, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    // Zweig 1
    var leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");
    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));
    // Zweig 2
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C5", "Leaf5"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C6", "Leaf6"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C7", "Leaf7"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");
    chart.getChartData().getCategories().add(wb.getCell(0, "C8", "Leaf8"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Treemap);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D8", 3));
    series.setParentLabelLayout(aspose.slides.ParentLabelLayoutType.Overlapping);
    pres.save("Treemap.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **Aktienkurs‑Diagramme erstellen**

<a name="java-create-stock-chart" id="java-create-stock-chart"><strong><em>Schritte:</em> Aktienkurs‑Diagramm in JavaScript erstellen</strong></a> |
<a name="java-create-powerpoint-stock-chart" id="java-powerpoint-stock-chart"><strong><em>Schritte:</em> PowerPoint‑Aktienkurs‑Diagramm in JavaScript erstellen</strong></a> |
<a name="java-create-powerpoint-presentation-stock-chart" id="java-create-powerpoint-presentation-stock-chart"><strong><em>Schritte:</em> PowerPoint‑Präsentations‑Aktienkurs‑Diagramm in JavaScript erstellen</strong></a>

1. Erzeugen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) Klasse.
2. Holen Sie sich die Referenz einer Folie über ihren Index.
3. Fügen Sie ein Diagramm mit Standarddaten und dem gewünschten Typ ([ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartType).OpenHighLowClose) hinzu.
4. Greifen Sie auf das Daten‑Workbook [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataWorkbook) zu.
5. Entfernen Sie die Standard‑Serien und -Kategorien.
6. Fügen Sie neue Serien und Kategorien hinzu.
7. Ergänzen Sie neue Diagrammdaten für die Serien.
8. Definieren Sie das Format für HiLowLines.
9. Schreiben Sie die geänderte Präsentation in eine PPTX‑Datei.

Beispiel‑JavaScript‑Code zum Erstellen eines Aktienkurs‑Diagramms:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.OpenHighLowClose, 50, 50, 600, 400);
  
    var wb = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getCategories().add(wb.getCell(0, 1, 0, "A"));
    chart.getChartData().getCategories().add(wb.getCell(0, 2, 0, "B"));
    chart.getChartData().getCategories().add(wb.getCell(0, 3, 0, "C"));
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 1, "Open"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 2, "High"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 3, "Low"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 4, "Close"), chart.getType());
    var series = chart.getChartData().getSeries().get_Item(0);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 1, 72));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 1, 25));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 1, 38));
    series = chart.getChartData().getSeries().get_Item(1);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 2, 172));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 2, 57));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 2, 57));
    series = chart.getChartData().getSeries().get_Item(2);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 3, 12));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 3, 12));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 3, 13));
    series = chart.getChartData().getSeries().get_Item(3);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 4, 25));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 4, 38));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 4, 50));
    chart.getChartData().getSeriesGroups().get_Item(0).getUpDownBars().setUpDownBars(true);
    chart.getChartData().getSeriesGroups().get_Item(0).getHiLowLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    for (let i = 0; i < chart.getChartData().getSeries().size(); i++) {
        let ser = chart.getChartData().getSeries().get_Item(i);
        ser.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    }
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **Box‑und‑Whisker‑Diagramme erstellen**

<a name="java-create-box-and-whisker-chart" id="java-create-box-and-whisker-chart"><strong><em>Schritte:</em> Box‑und‑Whisker‑Diagramm in JavaScript erstellen</strong></a> |
<a name="java-create-powerpoint-box-and-whisker-chart" id="java-powerpoint-box-and-whisker-chart"><strong><em>Schritte:</em> PowerPoint‑Box‑und‑Whisker‑Diagramm in JavaScript erstellen</strong></a> |
<a name="java-create-powerpoint-presentation-box-and-whisker-chart" id="java-create-powerpoint-presentation-box-and-whisker-chart"><strong><em>Schritte:</em> PowerPoint‑Präsentations‑Box‑und‑Whisker‑Diagramm in JavaScript erstellen</strong></a>

1. Erzeugen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) Klasse.
2. Holen Sie sich die Referenz einer Folie über ihren Index.
3. Fügen Sie ein Diagramm mit Standarddaten und dem gewünschten Typ ([ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartType).BoxAndWhisker) hinzu.
4. Greifen Sie auf das Daten‑Workbook [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataWorkbook) zu.
5. Entfernen Sie die Standard‑Serien und -Kategorien.
6. Fügen Sie neue Serien und Kategorien hinzu.
7. Ergänzen Sie neue Diagrammdaten für die Serien.
8. Schreiben Sie die geänderte Präsentation in eine PPTX‑Datei.

Dieser JavaScript‑Code demonstriert das Erstellen eines Box‑und‑Whisker‑Diagramms:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.BoxAndWhisker, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 1"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.BoxAndWhisker);
    series.setQuartileMethod(aspose.slides.QuartileMethodType.Exclusive);
    series.setShowMeanLine(true);
    series.setShowMeanMarkers(true);
    series.setShowInnerPoints(true);
    series.setShowOutlierPoints(true);
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B1", 15));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B2", 41));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B3", 16));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B4", 10));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B5", 23));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B6", 16));
    pres.save("BoxAndWhisker.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **Trichter‑Diagramme erstellen**

<a name="java-create-funnel-chart" id="java-create-funnel-chart"><strong><em>Schritte:</em> Trichter‑Diagramm in JavaScript erstellen</strong></a> |
<a name="java-create-powerpoint-funnel-chart" id="java-create-powerpoint-funnel-chart"><strong><em>Schritte:</em> PowerPoint‑Trichter‑Diagramm in JavaScript erstellen</strong></a> |
<a name="java-create-powerpoint-presentation-funnel-chart" id="java-create-powerpoint-presentation-funnel-chart"><strong><em>Schritte:</em> PowerPoint‑Präsentations‑Trichter‑Diagramm in JavaScript erstellen</strong></a>


1. Erzeugen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) Klasse.
2. Holen Sie sich die Referenz einer Folie über ihren Index.
3. Fügen Sie ein Diagramm mit Standarddaten und dem gewünschten Typ ([ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartType).Funnel) hinzu.
4. Schreiben Sie die geänderte Präsentation in eine PPTX‑Datei.

Der JavaScript‑Code demonstriert das Erstellen eines Trichter‑Diagramms:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Funnel, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 2"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 3"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 4"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 5"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 6"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Funnel);
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B1", 50));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B2", 100));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B3", 200));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B4", 300));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B5", 400));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B6", 500));
    pres.save("Funnel.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **Sunburst‑Diagramme erstellen**

<a name="java-create-sunburst-chart" id="java-create-sunburst-chart"><strong><em>Schritte:</em> Sunburst‑Diagramm in JavaScript erstellen</strong></a> |
<a name="java-create-powerpoint-sunburst-chart" id="java-create-powerpoint-sunburst-chart"><strong><em>Schritte:</em> PowerPoint‑Sunburst‑Diagramm in JavaScript erstellen</strong></a> |
<a name="java-create-powerpoint-presentation-sunburst-chart" id="java-create-powerpoint-presentation-sunburst-chart"><strong><em>Schritte:</em> PowerPoint‑Präsentations‑Sunburst‑Diagramm in JavaScript erstellen</strong></a>

1. Erzeugen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) Klasse.
2. Holen Sie sich die Referenz einer Folie über ihren Index.
3. Fügen Sie ein Diagramm mit Standarddaten und dem gewünschten Typ (hier [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartType).sunburst) hinzu.
4. Schreiben Sie die geänderte Präsentation in eine PPTX‑Datei.

Dieser JavaScript‑Code zeigt das Erstellen eines Sunburst‑Diagramms:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Sunburst, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    // Zweig 1
    var leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");
    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));
    // Zweig 2
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C5", "Leaf5"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C6", "Leaf6"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C7", "Leaf7"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");
    chart.getChartData().getCategories().add(wb.getCell(0, "C8", "Leaf8"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Sunburst);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D8", 3));
    pres.save("Sunburst.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **Histogramm‑Diagramme erstellen**

<a name="java-create-histogram-chart" id="java-create-histogram-chart"><strong><em>Schritte:</em> Histogramm‑Diagramm in JavaScript erstellen</strong></a> |
<a name="java-create-powerpoint-histogram-chart" id="java-create-powerpoint-histogram-chart"><strong><em>Schritte:</em> PowerPoint‑Histogramm‑Diagramm in JavaScript erstellen</strong></a> |
<a name="java-create-powerpoint-presentation-histogram-chart" id="java-create-powerpoint-presentation-histogram-chart"><strong><em>Schritte:</em> PowerPoint‑Präsentations‑Histogramm‑Diagramm in JavaScript erstellen</strong></a>

1. Erzeugen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) Klasse.
2. Holen Sie sich die Referenz einer Folie über ihren Index.
3. Fügen Sie ein Diagramm mit Standarddaten und dem gewünschten Typ ([ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartType).Histogram) hinzu.
4. Greifen Sie auf das Daten‑Workbook [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataWorkbook) zu.
5. Entfernen Sie die Standard‑Serien und -Kategorien.
6. Fügen Sie neue Serien und Kategorien hinzu.
7. Schreiben Sie die geänderte Präsentation in eine PPTX‑Datei.

Dieser JavaScript‑Code demonstriert das Erstellen eines Histogramm‑Diagramms:
```javascript
var pres = new aspose.slides.Presentation();
var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Histogram, 50, 50, 500, 400);
chart.getChartData().getCategories().clear();
chart.getChartData().getSeries().clear();
var wb = chart.getChartData().getChartDataWorkbook();
wb.clear(0);
var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Histogram);
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A1", 15));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A2", -41));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A3", 16));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A4", 10));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A5", -23));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A6", 16));
chart.getAxes().getHorizontalAxis().setAggregationType(aspose.slides.AxisAggregationType.Automatic);
```


### **Radar‑Diagramme erstellen**

<a name="java-create-radar-chart" id="java-create-radar-chart"><strong><em>Schritte:</em> Radar‑Diagramm in JavaScript erstellen</strong></a> |
<a name="java-create-powerpoint-radar-chart" id="java-create-powerpoint-radar-chart"><strong><em>Schritte:</em> PowerPoint‑Radar‑Diagramm in JavaScript erstellen</strong></a> |
<a name="java-create-powerpoint-presentation-radar-chart" id="java-create-powerpoint-presentation-radar-chart"><strong><em>Schritte:</em> PowerPoint‑Präsentations‑Radar‑Diagramm in JavaScript erstellen</strong></a>

1. Erzeugen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) Klasse.
2. Holen Sie sich die Referenz einer Folie über ihren Index. 
3. Fügen Sie ein Diagramm mit Daten und dem gewünschten Typ (`ChartType.Radar`) hinzu.
4. Schreiben Sie die geänderte Präsentation in eine PPTX‑Datei.

Dieser JavaScript‑Code zeigt das Erstellen eines Radar‑Diagramms:
```javascript
var pres = new aspose.slides.Presentation();
try {
    pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Radar, 20, 20, 400, 300);
    pres.save("Radar-chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **Mehrkategorie‑Diagramme erstellen**

<a name="java-create-multi-category-chart" id="java-create-multi-category-chart"><strong><em>Schritte:</em> Mehrkategorie‑Diagramm in JavaScript erstellen</strong></a> |
<a name="java-create-powerpoint-multi-category-chart" id="java-create-powerpoint-multi-category-chart"><strong><em>Schritte:</em> PowerPoint‑Mehrkategorie‑Diagramm in JavaScript erstellen</strong></a> |
<a name="java-create-powerpoint-presentation-multi-category-chart" id="java-create-powerpoint-presentation-multi-category-chart"><strong><em>Schritte:</em> PowerPoint‑Präsentations‑Mehrkategorie‑Diagramm in JavaScript erstellen</strong></a>

1. Erzeugen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) Klasse.
2. Holen Sie sich die Referenz einer Folie über ihren Index. 
3. Fügen Sie ein Diagramm mit Standarddaten und dem gewünschten Typ ([ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartType).ClusteredColumn) hinzu.
4. Greifen Sie auf das Daten‑Workbook [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataWorkbook) zu.
5. Entfernen Sie die Standard‑Serien und -Kategorien.
6. Fügen Sie neue Serien und Kategorien hinzu.
7. Ergänzen Sie neue Diagrammdaten für die Serien.
8. Schreiben Sie die geänderte Präsentation in eine PPTX‑Datei.

Dieser JavaScript‑Code demonstriert das Erstellen eines Mehrkategorie‑Diagramms:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var ch = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 600, 450);
    ch.getChartData().getSeries().clear();
    ch.getChartData().getCategories().clear();
    var fact = ch.getChartData().getChartDataWorkbook();
    fact.clear(0);
    var defaultWorksheetIndex = 0;
    var category = ch.getChartData().getCategories().add(fact.getCell(0, "c2", "A"));
    category.getGroupingLevels().setGroupingItem(1, "Group1");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c3", "B"));
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c4", "C"));
    category.getGroupingLevels().setGroupingItem(1, "Group2");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c5", "D"));
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c6", "E"));
    category.getGroupingLevels().setGroupingItem(1, "Group3");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c7", "F"));
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c8", "G"));
    category.getGroupingLevels().setGroupingItem(1, "Group4");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c9", "H"));
    // Serien hinzufügen
    var series = ch.getChartData().getSeries().add(fact.getCell(0, "D1", "Series 1"), aspose.slides.ChartType.ClusteredColumn);
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D2", 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D3", 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D4", 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D5", 40));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D6", 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D7", 60));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D8", 70));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D9", 80));
    // Präsentation mit Diagramm speichern
    pres.save("AsposeChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **Karten‑Diagramme erstellen**

Ein Karten‑Diagramm visualisiert ein Gebiet, das Daten enthält. Karten‑Diagramme eignen sich besonders zum Vergleich von Daten oder Werten über geografische Regionen hinweg.

<a name="java-create-map-chart" id="java-create-map-chart"><strong><em>Schritte:</em> Karten‑Diagramm in JavaScript erstellen</strong></a> |
<a name="java-create-powerpoint-map-chart" id="java-create-powerpoint-map-chart"><strong><em>Schritte:</em> PowerPoint‑Karten‑Diagramm in JavaScript erstellen</strong></a> |
<a name="java-create-powerpoint-presentation-map-chart" id="java-create-powerpoint-presentation-map-chart"><strong><em>Schritte:</em> PowerPoint‑Präsentations‑Karten‑Diagramm in JavaScript erstellen</strong></a>

Dieser JavaScript‑Code zeigt das Erstellen eines Karten‑Diagramms:
```javascript
let pres = new aspose.slides.Presentation();
try {
    let chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Map, 50, 50, 500, 400);
    pres.save("mapChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **Kombinations‑Diagramme erstellen**

Ein Kombinations‑Diagramm (oder Combo‑Diagramm) kombiniert zwei oder mehr Diagrammtypen in einem einzigen Diagramm. Mit einem Kombinations‑Diagramm können Sie Unterschiede zwischen Datenreihen hervorheben, vergleichen oder untersuchen und Beziehungen zwischen ihnen erkennen.

![Das Kombinations‑Diagramm](combination_chart.png)

Der folgende JavaScript‑Code zeigt, wie das oben dargestellte Kombinations‑Diagramm in einer PowerPoint‑Präsentation erzeugt wird:
```js
function createComboChart() {
    let presentation = new aspose.slides.Presentation();
    let slide = presentation.getSlides().get_Item(0);
    try {
        let chart = createChartWithFirstSeries(slide);

        addSecondSeriesToChart(chart);
        addThirdSeriesToChart(chart);

        setPrimaryAxesFormat(chart);
        setSecondaryAxesFormat(chart);

        presentation.save("combo-chart.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}

function createChartWithFirstSeries(slide) {
    let chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);

    // Diagrammtitel festlegen.
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Chart Title");
    chart.getChartTitle().setOverlay(false);
    let titleParagraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0);
    let titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(java.newByte(aspose.slides.NullableBool.False));
    titleFormat.setFontHeight(18);

    // Diagrammlegende festlegen.
    chart.getLegend().setPosition(aspose.slides.LegendPositionType.Bottom);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12);

    // Standardgenerierte Serien und Kategorien löschen.
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const worksheetIndex = 0;
    let workbook = chart.getChartData().getChartDataWorkbook();

    // Neue Kategorien hinzufügen.
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 3, 0, "Category 3"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 4, 0, "Category 4"));

    // Erste Serie hinzufügen.
    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    let series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    series.getParentSeriesGroup().setOverlap(java.newByte(-25));
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 1, 4.3));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 1, 2.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 1, 3.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 1, 4.5));

    return chart;
}

function addSecondSeriesToChart(chart) {
    let workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 2, "Series 2");
    let series = chart.getChartData().getSeries().add(seriesNameCell, aspose.slides.ChartType.ClusteredColumn);

    series.getParentSeriesGroup().setOverlap(java.newByte(-25));
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 2, 2.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 2, 4.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 2, 1.8));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 2, 2.8));
}

function addThirdSeriesToChart(chart) {
    let workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Series 3");
    let series = chart.getChartData().getSeries().add(seriesNameCell, aspose.slides.ChartType.Line);

    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 1, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 2, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 3, 3, 3.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 4, 3, 5.0));

    series.setPlotOnSecondAxis(true);
}

function setPrimaryAxesFormat(chart) {
    // Horizontale Achse festlegen.
    let horizontalAxis = chart.getAxes().getHorizontalAxis();
    horizontalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    horizontalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(horizontalAxis, "X Axis");

    // Vertikale Achse festlegen.
    let verticalAxis = chart.getAxes().getVerticalAxis();
    verticalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    verticalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(verticalAxis, "Y Axis 1");

    // Farbe der vertikalen Hauptgitterlinien festlegen.
    let majorGridLinesFormat = verticalAxis.getMajorGridLinesFormat().getLine().getFillFormat();
    majorGridLinesFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
    majorGridLinesFormat.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 217, 217, 217));
}

function setSecondaryAxesFormat(chart) {
    // Sekundäre horizontale Achse festlegen.
    let secondaryHorizontalAxis = chart.getAxes().getSecondaryHorizontalAxis();
    secondaryHorizontalAxis.setPosition(aspose.slides.AxisPositionType.Bottom);
    secondaryHorizontalAxis.setCrossType(aspose.slides.CrossesType.Maximum);
    secondaryHorizontalAxis.setVisible(false);
    secondaryHorizontalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryHorizontalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    // Sekundäre vertikale Achse festlegen.
    let secondaryVerticalAxis = chart.getAxes().getSecondaryVerticalAxis();
    secondaryVerticalAxis.setPosition(aspose.slides.AxisPositionType.Right);
    secondaryVerticalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    secondaryVerticalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryVerticalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryVerticalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(secondaryVerticalAxis, "Y Axis 2");
}

function setAxisTitle(axis, axisTitle) {
    axis.setTitle(true);
    axis.getTitle().setOverlay(false);
    let titleParagraph = axis.getTitle().addTextFrameForOverriding(axisTitle).getParagraphs().get_Item(0);
    let titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(java.newByte(aspose.slides.NullableBool.False));
    titleFormat.setFontHeight(12);
}
```


## **Diagramme aktualisieren**

<a name="java-update-powerpoint-chart" id="java-update-powerpoint-chart"><strong><em>Schritte:</em> PowerPoint‑Diagramm in JavaScript aktualisieren</strong></a> |
<a name="java-update-presentation-chart" id="java-update-presentation-chart"><strong><em>Schritte:</em> Präsentations‑Diagramm in JavaScript aktualisieren</strong></a> |
<a name="java-update-powerpoint-presentation-chart" id="java-update-powerpoint-presentation-chart"><strong><em>Schritte:</em> PowerPoint‑Präsentations‑Diagramm in JavaScript aktualisieren</strong></a>

1. Instanziieren Sie eine Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation), die die Präsentation mit dem zu aktualisierenden Diagramm repräsentiert.
2. Holen Sie sich die Referenz einer Folie über ihren Index.
3. Durchsuchen Sie alle Shapes, um das gewünschte Diagramm zu finden.
4. Greifen Sie auf das Daten‑Worksheet des Diagramms zu.
5. Ändern Sie die Daten der Diagramm‑Serien, indem Sie die Serienwerte anpassen.
6. Fügen Sie eine neue Serie hinzu und befüllen Sie die Daten.
7. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser JavaScript‑Code demonstriert das Aktualisieren eines Diagramms:
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Zugriff auf den ersten Folienmarker
    var sld = pres.getSlides().get_Item(0);
    // Diagramm mit Standarddaten abrufen
    var chart = sld.getShapes().get_Item(0);
    // Festlegen des Index des Diagrammdatenblatts
    var defaultWorksheetIndex = 0;
    // Abrufen des Diagrammdaten-Arbeitsblatts
    var fact = chart.getChartData().getChartDataWorkbook();
    // Ändern des Diagramm-Kategorienamens
    fact.getCell(defaultWorksheetIndex, 1, 0, "Modified Category 1");
    fact.getCell(defaultWorksheetIndex, 2, 0, "Modified Category 2");
    // Erste Diagrammserie auswählen
    var series = chart.getChartData().getSeries().get_Item(0);
    // Jetzt werden die Seriendaten aktualisiert
    fact.getCell(defaultWorksheetIndex, 0, 1, "New_Series1");// Seriennamen ändern
    series.getDataPoints().get_Item(0).getValue().setData(90);
    series.getDataPoints().get_Item(1).getValue().setData(123);
    series.getDataPoints().get_Item(2).getValue().setData(44);
    // Zweite Diagrammserie holen
    series = chart.getChartData().getSeries().get_Item(1);
    // Jetzt werden die Seriendaten aktualisiert
    fact.getCell(defaultWorksheetIndex, 0, 2, "New_Series2");// Seriennamen ändern
    series.getDataPoints().get_Item(0).getValue().setData(23);
    series.getDataPoints().get_Item(1).getValue().setData(67);
    series.getDataPoints().get_Item(2).getValue().setData(99);
    // Jetzt eine neue Serie hinzufügen
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "Series 3"), chart.getType());
    // Dritte Diagrammserie auswählen
    series = chart.getChartData().getSeries().get_Item(2);
    // Jetzt werden die Seriendaten befüllt
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 3, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 30));
    chart.setType(aspose.slides.ChartType.ClusteredCylinder);
    // Präsentation mit Diagramm speichern
    pres.save("AsposeChartModified_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Datenbereich für Diagramme festlegen**

So legen Sie den Datenbereich für ein Diagramm fest:

1. Instanziieren Sie eine Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation), die die Präsentation mit dem Diagramm repräsentiert.
2. Holen Sie sich die Referenz einer Folie über ihren Index.
3. Durchsuchen Sie alle Shapes, um das gewünschte Diagramm zu finden.
4. Greifen Sie auf die Diagrammdaten zu und setzen Sie den Bereich.
5. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser JavaScript‑Code zeigt, wie Sie den Datenbereich für ein Diagramm festlegen:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().get_Item(0);
    chart.getChartData().setRange("Sheet1!A1:B4");
    pres.save("SetDataRange_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Standard‑Marker in Diagrammen verwenden**
Wenn Sie einen Standard‑Marker in Diagrammen verwenden, erhält jede Diagramm‑Serie automatisch ein unterschiedliches Standardsymbol.

Dieser JavaScript‑Code zeigt, wie ein Diagramm‑Serien‑Marker automatisch gesetzt wird:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 10, 10, 400, 400);
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    var fact = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    var series = chart.getChartData().getSeries().get_Item(0);
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "C1"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 1, 1, 24));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "C2"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 2, 1, 23));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "C3"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 3, 1, -10));
    chart.getChartData().getCategories().add(fact.getCell(0, 4, 0, "C4"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 4, 1, null));
    chart.getChartData().getSeries().add(fact.getCell(0, 0, 2, "Series 2"), chart.getType());
    // Zweite Diagrammserie holen
    var series2 = chart.getChartData().getSeries().get_Item(1);
    // Jetzt werden die Seriendaten gefüllt
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 1, 2, 30));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 2, 2, 10));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 3, 2, 60));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 4, 2, 40));
    chart.setLegend(true);
    chart.getLegend().setOverlay(false);
    pres.save("DefaultMarkersInChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
