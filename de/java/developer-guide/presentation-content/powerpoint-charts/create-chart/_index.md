---
title: Erstellen oder Aktualisieren von PowerPoint-Präsentationsdiagrammen in Java
linktitle: Diagramm erstellen
type: docs
weight: 10
url: /java/create-chart/
keywords: "Diagramm erstellen, Streudiagramm, Kreisdiagramm, Baumkarten-Diagramm, Aktien-Diagramm, Box- und Whisker-Diagramm, Histogramm-Diagramm, Trichterdiagramm, Sonnenblumen-Diagramm, Mehrkategorie-Diagramm, PowerPoint-Präsentation, Java, Aspose.Slides für Java"
description: "Diagramm in PowerPoint-Präsentation in Java erstellen"
---

## Übersicht

Dieser Artikel beschreibt, wie man **PowerPoint-Präsentationsdiagramme in Java erstellt**. Sie können auch **die Diagramme in Java aktualisieren**. Es werden folgende Themen behandelt:

_Diagramm_: **Normal**
- [Java PowerPoint-Diagramm erstellen](#java-create-powerpoint-chart)
- [Java Präsentationsdiagramm erstellen](#java-create-presentation-chart)
- [Java PowerPoint-Präsentationsdiagramm erstellen](#java-create-powerpoint-presentation-chart)

_Diagramm_: **Streudiagramm**
- [Java Streudiagramm erstellen](#java-create-scattered-chart)
- [Java PowerPoint-Streudiagramm erstellen](#java-create-powerpoint-scattered-chart)
- [Java PowerPoint-Präsentations-Streudiagramm erstellen](#java-create-powerpoint-presentation-scattered-chart)

_Diagramm_: **Kreis**
- [Java Kreisdiagramm erstellen](#java-create-pie-chart)
- [Java PowerPoint-Kreisdiagramm erstellen](#java-create-powerpoint-pie-chart)
- [Java PowerPoint-Präsentations-Kreisdiagramm erstellen](#java-create-powerpoint-presentation-pie-chart)

_Diagramm_: **Baumkarte**
- [Java Baumkarten-Diagramm erstellen](#java-create-tree-map-chart)
- [Java PowerPoint-Baumkarten-Diagramm erstellen](#java-create-powerpoint-tree-map-chart)
- [Java PowerPoint-Präsentations-Baumkarten-Diagramm erstellen](#java-create-powerpoint-presentation-tree-map-chart)

_Diagramm_: **Aktien**
- [Java Aktien-Diagramm erstellen](#java-create-stock-chart)
- [Java PowerPoint-Aktien-Diagramm erstellen](#java-create-powerpoint-stock-chart)
- [Java PowerPoint-Präsentations-Aktien-Diagramm erstellen](#java-create-powerpoint-presentation-stock-chart)

_Diagramm_: **Box und Whisker**
- [Java Box- und Whisker-Diagramm erstellen](#java-create-box-and-whisker-chart)
- [Java PowerPoint-Box- und Whisker-Diagramm erstellen](#java-create-powerpoint-box-and-whisker-chart)
- [Java PowerPoint-Präsentations-Box- und Whisker-Diagramm erstellen](#java-create-powerpoint-presentation-box-and-whisker-chart)

_Diagramm_: **Trichter**
- [Java Trichterdiagramm erstellen](#java-create-funnel-chart)
- [Java PowerPoint-Trichterdiagramm erstellen](#java-create-powerpoint-funnel-chart)
- [Java PowerPoint-Präsentations-Trichterdiagramm erstellen](#java-create-powerpoint-presentation-funnel-chart)

_Diagramm_: **Sonnenblume**
- [Java Sonnenblumen-Diagramm erstellen](#java-create-sunburst-chart)
- [Java PowerPoint-Sonnenblumen-Diagramm erstellen](#java-create-powerpoint-sunburst-chart)
- [Java PowerPoint-Präsentations-Sonnenblumen-Diagramm erstellen](#java-create-powerpoint-presentation-sunburst-chart)

_Diagramm_: **Histogramm**
- [Java Histogramm-Diagramm erstellen](#java-create-histogram-chart)
- [Java PowerPoint-Histogramm-Diagramm erstellen](#java-create-powerpoint-histogram-chart)
- [Java PowerPoint-Präsentations-Histogramm-Diagramm erstellen](#java-create-powerpoint-presentation-histogram-chart)

_Diagramm_: **Radar**
- [Java Radar-Diagramm erstellen](#java-create-radar-chart)
- [Java PowerPoint-Radar-Diagramm erstellen](#java-create-powerpoint-radar-chart)
- [Java PowerPoint-Präsentations-Radar-Diagramm erstellen](#java-create-powerpoint-presentation-radar-chart)

_Diagramm_: **Mehrkategorie**
- [Java Mehrkategorie-Diagramm erstellen](#java-create-multi-category-chart)
- [Java PowerPoint-Mehrkategorie-Diagramm erstellen](#java-create-powerpoint-multi-category-chart)
- [Java PowerPoint-Präsentations-Mehrkategorie-Diagramm erstellen](#java-create-powerpoint-presentation-multi-category-chart)

_Diagramm_: **Karte**
- [Java Karten-Diagramm erstellen](#java-create-map-chart)
- [Java PowerPoint-Karten-Diagramm erstellen](#java-create-powerpoint-map-chart)
- [Java PowerPoint-Präsentations-Karten-Diagramm erstellen](#java-create-powerpoint-presentation-map-chart)

_Aktion_: **Diagramm aktualisieren**
- [Java PowerPoint-Diagramm aktualisieren](#java-update-powerpoint-chart)
- [Java Präsentationsdiagramm aktualisieren](#java-update-presentation-chart)
- [Java PowerPoint-Präsentationsdiagramm aktualisieren](#java-update-powerpoint-presentation-chart)

## **Diagramm erstellen**
Diagramme helfen Menschen, Daten schnell zu visualisieren und Erkenntnisse zu gewinnen, die aus einer Tabelle oder einem Spreadsheet möglicherweise nicht sofort offensichtlich sind.

**Warum Diagramme erstellen?**

Durch die Verwendung von Diagrammen können Sie

* große Datenmengen auf einer einzigen Folie in einer Präsentation aggregieren, kondensieren oder zusammenfassen
* Muster und Trends in Daten aufdecken
* die Richtung und Dynamik von Daten über die Zeit oder in Bezug auf eine bestimmte Einheit der Messung ableiten 
* Ausreißer, Anomalien, Abweichungen, Fehler, unsinnige Daten usw. erkennen 
* komplexe Daten kommunizieren oder präsentieren

In PowerPoint können Sie Diagramme über die Funktion Einfügen erstellen, die Vorlagen bereitstellt, die zur Gestaltung vieler Arten von Diagrammen verwendet werden. Mithilfe von Aspose.Slides können Sie reguläre Diagramme (basierend auf beliebten Diagrammtypen) und benutzerdefinierte Diagramme erstellen.

{{% alert color="primary" %}} 

Um Ihnen das Erstellen von Diagrammen zu ermöglichen, stellt Aspose.Slides die [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/ChartType) Klasse zur Verfügung. Die Felder unter dieser Klasse entsprechen verschiedenen Diagrammtypen.

{{% /alert %}} 

### **Erstellen normaler Diagramme**

_Schritte: Diagramm erstellen_
- <a name="java-create-powerpoint-chart" id="java-create-powerpoint-chart"><strong><em>Schritte:</em> PowerPoint-Diagramm in Java erstellen</strong></a>
- <a name="java-create-presentation-chart" id="java-create-presentation-chart"><strong><em>Schritte:</em> Präsentationsdiagramm in Java erstellen</strong></a>
- <a name="java-create-powerpoint-presentation-chart" id="java-create-powerpoint-presentation-chart"><strong><em>Schritte:</em> PowerPoint-Präsentationsdiagramm in Java erstellen</strong></a>

_Schritt für Schritt:_

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
2. Holen Sie sich eine Referenz auf eine Folie über ihren Index.
3. Fügen Sie ein Diagramm mit einigen Daten hinzu und geben Sie Ihren bevorzugten Diagrammtyp an. 
4. Fügen Sie einen Titel für das Diagramm hinzu. 
5. Greifen Sie auf das Datenarbeitsblatt des Diagramms zu.
6. Löschen Sie alle Standardreihen und -kategorien.
7. Fügen Sie neue Reihen und Kategorien hinzu.
8. Fügen Sie einige neue Diagrammdaten für die Diagrammreihen hinzu.
9. Fügen Sie eine Füllfarbe für die Diagrammreihe hinzu.
10. Fügen Sie Beschriftungen für die Diagrammreihe hinzu. 
11. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser Java-Code zeigt Ihnen, wie Sie ein normales Diagramm erstellen:

```java
// Instanziiert eine Präsentationsklasse, die eine PPTX-Datei darstellt
Presentation pres = new Presentation();
try {
    // Greift auf die erste Folie zu
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Fügt ein Diagramm mit Standarddaten hinzu
    IChart chart = sld.getShapes().addChart(ChartType.ClusteredColumn, 0, 0, 500, 500);
    
    // Setzt den Diagrammtitel
    chart.getChartTitle().addTextFrameForOverriding("Beispiel Titel");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.hasTitle();
    
    // Setzt die erste Reihe auf Werte anzeigen
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    
    // Setzt den Index für das Diagrammdatentabelle
    int defaultWorksheetIndex = 0;
    
    // Holt das Datenarbeitsblatt des Diagramms
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Löscht die standardmäßig generierten Reihen und Kategorien
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    int s = chart.getChartData().getSeries().size();
    s = chart.getChartData().getCategories().size();
    
    // Fügt neue Reihen hinzu
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Reihe 1"),chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Reihe 2"),chart.getType());
    
    // Fügt neue Kategorien hinzu
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Kategorie 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Kategorie 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Kategorie 3"));
    
    // Nimmt die erste Diagrammreihe
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // Jetzt werden die Seriendaten ausgefüllt
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // Setzt die Füllfarbe für die Reihe
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    
    // Nimmt die zweite Diagrammreihe
    series = chart.getChartData().getSeries().get_Item(1);
    
    // Befüllt die Seriendaten
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // Setzt die Füllfarbe für die Reihe
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.GREEN);
    
    // Erstellt benutzerdefinierte Beschriftungen für jede Kategorie für die neue Reihe
    // Setzt die erste Beschriftung auf Kategoriename anzeigen
    IDataLabel lbl = series.getDataPoints().get_Item(0).getLabel();
    lbl.getDataLabelFormat().setShowCategoryName(true);
    
    lbl = series.getDataPoints().get_Item(1).getLabel();
    lbl.getDataLabelFormat().setShowSeriesName(true);
    
    // Zeigt Wert für die dritte Beschriftung an
    lbl = series.getDataPoints().get_Item(2).getLabel();
    lbl.getDataLabelFormat().setShowValue(true);
    lbl.getDataLabelFormat().setShowSeriesName(true);
    lbl.getDataLabelFormat().setSeparator("/");
    
    // Speichert die Präsentation mit dem Diagramm
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Erstellen von Streudiagrammen**
Streudiagramme (auch bekannt als Streudiagramme oder x-y-Diagramme) werden häufig verwendet, um Muster zu überprüfen oder Korrelationen zwischen zwei Variablen darzustellen.

Sie möchten möglicherweise ein Streudiagramm verwenden, wenn 

* Sie gepaarte numerische Daten haben
* Sie 2 Variablen haben, die gut zusammenpassen
* Sie bestimmen möchten, ob 2 Variablen miteinander verbunden sind
* Sie eine unabhängige Variable haben, die mehrere Werte für eine abhängige Variable hat

<a name="java-create-scattered-chart" id="java-create-scattered-chart"><strong><em>Schritte:</em> Streudiagramm in Java erstellen</strong></a> |
<a name="java-create-powerpoint-scattered-chart" id="java-create-powerpoint-scattered-chart"><strong><em>Schritte:</em> PowerPoint-Streudiagramm in Java erstellen</strong></a> |
<a name="java-create-powerpoint-presentation-scattered-chart" id="java-create-powerpoint-presentation-scattered-chart"><strong><em>Schritte:</em> PowerPoint-Präsentations-Streudiagramm in Java erstellen</strong></a>

1. Bitte befolgen Sie die oben genannten Schritte in [Erstellen normaler Diagramme](#creating-normal-charts)
2. Für den dritten Schritt, fügen Sie ein Diagramm mit einigen Daten hinzu und geben Sie Ihren Diagrammtyp als einen der folgenden an
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/#ScatterWithMarkers) - _Streudiagramm darstellen._
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Streudiagramm, das durch Kurven verbunden ist, mit Datenmarkierungen._
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/#ScatterWithSmoothLines) - _Streudiagramm, das durch Kurven verbunden ist, ohne Datenmarkierungen._
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Streudiagramm, das durch Linien verbunden ist, mit Datenmarkierungen._
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/#ScatterWithStraightLines) - _Streudiagramm, das durch Linien verbunden ist, ohne Datenmarkierungen._

Dieser Java-Code zeigt Ihnen, wie Sie ein Streudiagramm mit einer anderen Reihe von Markierungen erstellen:

```java
// Instanziiert eine Präsentationsklasse, die eine PPTX-Datei darstellt
Presentation pres = new Presentation();
try {
    // Greift auf die erste Folie zu
    ISlide slide = pres.getSlides().get_Item(0);

    // Erstellt das Standarddiagramm
    IChart chart = slide.getShapes().addChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);
    
    // Holt den Standardindex des Diagrammdatentabelle
    int defaultWorksheetIndex = 0;
    
    // Holt das Datenarbeitsblatt des Diagramms
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Löscht die Demo-Serie
    chart.getChartData().getSeries().clear();
    
    // Fügt neue Reihen hinzu
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Reihe 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 3, "Reihe 2"), chart.getType());
    
    // Nimmt die erste Diagrammreihe
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // Fügt einen neuen Punkt (1:3) zur Reihe hinzu
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 1), fact.getCell(defaultWorksheetIndex, 2, 2, 3));
    
    // Fügt einen neuen Punkt (2:10) hinzu
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 2), fact.getCell(defaultWorksheetIndex, 3, 2, 10));
    
    // Ändert den Typ der Reihe
    series.setType(ChartType.ScatterWithStraightLinesAndMarkers);
    
    // Ändert die Diagrammreihenmarkierung
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(MarkerStyleType.Star);
    
    // Nimmt die zweite Diagrammreihe
    series = chart.getChartData().getSeries().get_Item(1);
    
    // Fügt dort einen neuen Punkt (5:2) hinzu
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 5), fact.getCell(defaultWorksheetIndex, 2, 4, 2));
    
    // Fügt einen neuen Punkt (3:1) hinzu
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 3), fact.getCell(defaultWorksheetIndex, 3, 4, 1));
    
    // Fügt einen neuen Punkt (2:2) hinzu
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 4, 3, 2), fact.getCell(defaultWorksheetIndex, 4, 4, 2));
    
    // Fügt einen neuen Punkt (5:1) hinzu
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 5, 3, 5), fact.getCell(defaultWorksheetIndex, 5, 4, 1));
    
    // Ändert die Diagrammreihenmarkierung
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(MarkerStyleType.Circle);
    
    pres.save("AsposeChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Erstellen von Kreisdiagrammen**

Kreisdiagramme eignen sich am besten, um die Teil-zu-Ganz-Beziehung in Daten darzustellen, insbesondere wenn die Daten kategorische Bezeichnungen mit numerischen Werten enthalten. Wenn Ihre Daten jedoch viele Teile oder Bezeichnungen enthalten, sollten Sie stattdessen in Betracht ziehen, ein Balkendiagramm zu verwenden.

<a name="java-create-pie-chart" id="java-create-pie-chart"><strong><em>Schritte:</em> Kreisdiagramm in Java erstellen</strong></a> |
<a name="java-create-powerpoint-pie-chart" id="java-create-powerpoint-pie-chart"><strong><em>Schritte:</em> PowerPoint-Kreisdiagramm in Java erstellen</strong></a> |
<a name="java-create-powerpoint-presentation-pie-chart" id="java-create-powerpoint-presentation-pie-chart"><strong><em>Schritte:</em> PowerPoint-Präsentations-Kreisdiagramm in Java erstellen</strong></a>

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
2. Holen Sie sich eine Referenz auf eine Folie über ihren Index.
3. Fügen Sie ein Diagramm mit Standarddaten zusammen mit dem gewünschten Typ hinzu (in diesem Fall [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/ChartType).Pie).
4. Greifen Sie auf das Diagramm-Daten [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataWorkbook) zu.
5. Löschen Sie die Standardreihen und -kategorien.
6. Fügen Sie neue Reihen und Kategorien hinzu.
7. Fügen Sie neue Diagrammdaten für die Diagrammreihen hinzu.
8. Fügen Sie neue Punkte für die Diagramme hinzu und fügen Sie individuelle Farben für die Sektoren des Kreisdiagramms hinzu.
9. Setzen Sie Beschriftungen für die Reihen.
10. Setzen Sie Führungsleitungen für die Reihenbeschriftungen ein.
11. Setzen Sie den Rotationswinkel für die Folien des Kreisdiagramms.
12. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

Dieser Java-Code zeigt Ihnen, wie Sie ein Kreisdiagramm erstellen:

```java
// Instanziiert eine Präsentationsklasse, die eine PPTX-Datei darstellt
Presentation pres = new Presentation();
try {
    // Greift auf die erste Folie zu
    ISlide slides = pres.getSlides().get_Item(0);
    
    // Fügt ein Diagramm mit Standarddaten hinzu
    IChart chart = slides.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);
    
    // Setzt den Diagrammtitel
    chart.getChartTitle().addTextFrameForOverriding("Beispiel Titel");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    
    // Setzt die erste Reihe auf Werte anzeigen
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    
    // Setzt den Index für das Diagrammdatentabelle
    int defaultWorksheetIndex = 0;
    
    // Holt das Datenarbeitsblatt des Diagramms
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Löscht die standardmäßig generierten Reihen und Kategorien
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    
    // Fügt neue Kategorien hinzu
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "Erster Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2. Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3. Qtr"));
    
    // Fügt neue Reihen hinzu
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Reihe 1"), chart.getType());
    
    // Befüllt die Seriendaten
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // Funktioniert in der neuen Version nicht
    // Hinzufügen neuer Punkte und Festlegen der Sektorfarbe
    // series.IsColorVaried = true;
    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(true);
    
    IChartDataPoint point = series.getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(FillType.Solid);
    point.getFormat().getFill().getSolidFillColor().setColor(Color.CYAN);
	
    // Setzt den Sektorrahmen
    point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    point.getFormat().getLine().setWidth(3.0);
    point.getFormat().getLine().setStyle(LineStyle.ThinThick);
    point.getFormat().getLine().setDashStyle(LineDashStyle.DashDot);
    
    IChartDataPoint point1 = series.getDataPoints().get_Item(1);
    point1.getFormat().getFill().setFillType(FillType.Solid);
    point1.getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE);
    
    // Setzt den Sektorrahmen
    point1.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point1.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    point1.getFormat().getLine().setWidth(3.0);
    point1.getFormat().getLine().setStyle(LineStyle.Single);
    point1.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDot);
    
    IChartDataPoint point2 = series.getDataPoints().get_Item(2);
    point2.getFormat().getFill().setFillType(FillType.Solid);
    point2.getFormat().getFill().getSolidFillColor().setColor(Color.YELLOW);
    
    // Setzt den Sektorrahmen
    point2.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point2.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    point2.getFormat().getLine().setWidth(2.0);
    point2.getFormat().getLine().setStyle(LineStyle.ThinThin);
    point2.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDotDot);
    
    // Erstellt benutzerdefinierte Beschriftungen für jede Kategorie der neuen Reihe
    IDataLabel lbl1 = series.getDataPoints().get_Item(0).getLabel();
    
    // lbl.ShowCategoryName = true;
    lbl1.getDataLabelFormat().setShowValue(true);
    
    IDataLabel lbl2 = series.getDataPoints().get_Item(1).getLabel();
    lbl2.getDataLabelFormat().setShowValue(true);
    lbl2.getDataLabelFormat().setShowLegendKey(true);
    lbl2.getDataLabelFormat().setShowPercentage(true);
    
    IDataLabel lbl3 = series.getDataPoints().get_Item(2).getLabel();
    lbl3.getDataLabelFormat().setShowSeriesName(true);
    lbl3.getDataLabelFormat().setShowPercentage(true);
    
    // Zeigt Führungsleitungen für das Diagramm
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(true);
    
    // Setzt den Rotationswinkel für die Sektoren des Kreisdiagramms
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);
    
    // Speichert die Präsentation mit einem Diagramm
    pres.save("PieChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Erstellen von Liniendiagrammen**

Liniendiagramme (auch bekannt als Liniendiagramme) eignen sich am besten in Situationen, in denen Sie Änderungen des Wertes im Laufe der Zeit demonstrieren möchten. Mit einem Liniendiagramm können Sie viele Daten gleichzeitig vergleichen, Änderungen und Trends im Laufe der Zeit verfolgen, Anomalien in Datensätzen hervorheben usw.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
1. Holen Sie sich eine Referenz auf eine Folie über ihren Index.
1. Fügen Sie ein Diagramm mit Standarddaten zusammen mit dem gewünschten Typ hinzu (in diesem Fall `ChartType.Line`).
1. Greifen Sie auf das Datenarbeitsblatt IChartDataWorkbook zu.
1. Löschen Sie die Standardreihen und -kategorien.
1. Fügen Sie neue Reihen und Kategorien hinzu.
1. Fügen Sie neue Diagrammdaten für die Diagrammreihe hinzu.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

Dieser Java-Code zeigt Ihnen, wie Sie ein Liniendiagramm erstellen:

```java
Presentation pres = new Presentation();
try {
    IChart lineChart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350);

    pres.save("lineChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Standardmäßig werden Punkte in einem Liniendiagramm durch gerade durchgehende Linien verbunden. Wenn Sie möchten, dass die Punkte durch Striche verbunden werden, können Sie Ihren bevorzugten Linienstil auf folgende Weise angeben:

```java
IChart lineChart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350);

for (IChartSeries series : lineChart.getChartData().getSeries())
{
    series.getFormat().getLine().setDashStyle(LineDashStyle.Dash);
}
```

### **Erstellen von Baumkarten-Diagrammen**

Baumkarten-Diagramme eignen sich am besten für Verkaufsdaten, wenn Sie die relative Größe von Datenkategorien zeigen möchten und gleichzeitig schnell auf Artikel aufmerksam machen möchten, die große Beiträge zu jeder Kategorie leisten.

<a name="java-create-tree-map-chart" id="java-create-tree-map-chart"><strong><em>Schritte:</em> Baumkarten-Diagramm in Java erstellen</strong></a> |
<a name="java-create-powerpoint-tree-map-chart" id="java-create-powerpoint-tree-map-chart"><strong><em>Schritte:</em> PowerPoint-Baumkarten-Diagramm in Java erstellen</strong></a> |
<a name="java-create-powerpoint-presentation-tree-map-chart" id="java-create-powerpoint-presentation-tree-map-chart"><strong><em>Schritte:</em> PowerPoint-Präsentations-Baumkarten-Diagramm in Java erstellen</strong></a>

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
2. Holen Sie sich eine Referenz auf eine Folie über ihren Index.
3. Fügen Sie ein Diagramm mit Standarddaten zusammen mit dem gewünschten Typ hinzu (in diesem Fall [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/ChartType).TreeMap).
4. Greifen Sie auf das Diagramm-Daten [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataWorkbook) zu.
5. Löschen Sie die Standardreihen und -kategorien.
6. Fügen Sie neue Reihen und Kategorien hinzu.
7. Fügen Sie neue Diagrammdaten für die Diagrammreihe hinzu.
8. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

Dieser Java-Code zeigt Ihnen, wie Sie ein Baumkarten-Diagramm erstellen:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Treemap, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    //Zweig 1
    IChartCategory leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Blatt1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stamm1");
    leaf.getGroupingLevels().setGroupingItem(2, "Zweig1");

    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Blatt2"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Blatt3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stamm2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Blatt4"));

    //Zweig 2
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C5", "Blatt5"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stamm3");
    leaf.getGroupingLevels().setGroupingItem(2, "Zweig2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C6", "Blatt6"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C7", "Blatt7"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stamm4");

    chart.getChartData().getCategories().add(wb.getCell(0, "C8", "Blatt8"));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Treemap);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D8", 3));

    series.setParentLabelLayout(ParentLabelLayoutType.Overlapping);

    pres.save("Treemap.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Erstellen von Aktien-Diagrammen**

<a name="java-create-stock-chart" id="java-create-stock-chart"><strong><em>Schritte:</em> Aktien-Diagramm in Java erstellen</strong></a> |
<a name="java-create-powerpoint-stock-chart" id="java-create-powerpoint-stock-chart"><strong><em>Schritte:</em> PowerPoint-Aktien-Diagramm in Java erstellen</strong></a> |
<a name="java-create-powerpoint-presentation-stock-chart" id="java-create-powerpoint-presentation-stock-chart"><strong><em>Schritte:</em> PowerPoint-Präsentations-Aktien-Diagramm in Java erstellen</strong></a>

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
2. Holen Sie sich eine Referenz auf eine Folie über ihren Index.
3. Fügen Sie ein Diagramm mit Standarddaten zusammen mit dem gewünschten Typ hinzu ([ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/ChartType).OpenHighLowClose).
4. Greifen Sie auf das Diagramm-Daten [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataWorkbook) zu.
5. Löschen Sie die Standardreihen und -kategorien.
6. Fügen Sie neue Reihen und Kategorien hinzu.
7. Fügen Sie neue Diagrammdaten für die Diagrammreihe hinzu.
8. Geben Sie das Format HiLowLines an.
9. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

Dieser Beispiel-Java-Code zeigt, wie man ein Aktien-Diagramm erstellt:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.OpenHighLowClose, 50, 50, 600, 400, false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();

    chart.getChartData().getCategories().add(wb.getCell(0, 1, 0, "A"));
    chart.getChartData().getCategories().add(wb.getCell(0, 2, 0, "B"));
    chart.getChartData().getCategories().add(wb.getCell(0, 3, 0, "C"));

    chart.getChartData().getSeries().add(wb.getCell(0, 0, 1, "Öffnen"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 2, "Hoch"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 3, "Tief"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 4, "Schließen"), chart.getType());

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

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
    chart.getChartData().getSeriesGroups().get_Item(0).getHiLowLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);

    for (IChartSeries ser : chart.getChartData().getSeries())
    {
        ser.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    }

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Erstellen von Box- und Whisker-Diagrammen**

<a name="java-create-box-and-whisker-chart" id="java-create-box-and-whisker-chart"><strong><em>Schritte:</em> Box- und Whisker-Diagramm in Java erstellen</strong></a> |
<a name="java-create-powerpoint-box-and-whisker-chart" id="java-create-powerpoint-box-and-whisker-chart"><strong><em>Schritte:</em> PowerPoint-Box- und Whisker-Diagramm in Java erstellen</strong></a> |
<a name="java-create-powerpoint-presentation-box-and-whisker-chart" id="java-create-powerpoint-presentation-box-and-whisker-chart"><strong><em>Schritte:</em> PowerPoint-Präsentations-Box- und Whisker-Diagramm in Java erstellen</strong></a>

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
2. Holen Sie sich eine Referenz auf eine Folie über ihren Index.
3. Fügen Sie ein Diagramm mit Standarddaten zusammen mit dem gewünschten Typ hinzu ([ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/ChartType).BoxAndWhisker).
4. Greifen Sie auf das Diagramm-Daten [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataWorkbook) zu.
5. Löschen Sie die Standardreihen und -kategorien.
6. Fügen Sie neue Reihen und Kategorien hinzu.
7. Fügen Sie neue Diagrammdaten für die Diagrammreihe hinzu.
8. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

Dieser Java-Code zeigt Ihnen, wie Sie ein Box- und Whisker-Diagramm erstellen:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.BoxAndWhisker, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Kategorie 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Kategorie 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Kategorie 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Kategorie 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Kategorie 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Kategorie 1"));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.BoxAndWhisker);

    series.setQuartileMethod(QuartileMethodType.Exclusive);
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

    pres.save("BoxAndWhisker.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Erstellen von Trichterdiagrammen**

<a name="java-create-funnel-chart" id="java-create-funnel-chart"><strong><em>Schritte:</em> Trichterdiagramm in Java erstellen</strong></a> |
<a name="java-create-powerpoint-funnel-chart" id="java-create-powerpoint-funnel-chart"><strong><em>Schritte:</em> PowerPoint-Trichterdiagramm in Java erstellen</strong></a> |
<a name="java-create-powerpoint-presentation-funnel-chart" id="java-create-powerpoint-presentation-funnel-chart"><strong><em>Schritte:</em> PowerPoint-Präsentations-Trichterdiagramm in Java erstellen</strong></a>

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
2. Holen Sie sich eine Referenz auf eine Folie über ihren Index.
3. Fügen Sie ein Diagramm mit Standarddaten zusammen mit dem gewünschten Typ hinzu ([ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/ChartType).Funnel).
4. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

Dieser Java-Code zeigt Ihnen, wie Sie ein Trichterdiagramm erstellen:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Funnel, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();

    wb.clear(0);

    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Kategorie 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Kategorie 2"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Kategorie 3"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Kategorie 4"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Kategorie 5"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Kategorie 6"));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Funnel);

    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B1", 50));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B2", 100));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B3", 200));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B4", 300));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B5", 400));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B6", 500));

    pres.save("Funnel.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Erstellen von Sonnenblumen-Diagrammen**

<a name="java-create-sunburst-chart" id="java-create-sunburst-chart"><strong><em>Schritte:</em> Sonnenblumen-Diagramm in Java erstellen</strong></a> |
<a name="java-create-powerpoint-sunburst-chart" id="java-create-powerpoint-sunburst-chart"><strong><em>Schritte:</em> PowerPoint-Sonnenblumen-Diagramm in Java erstellen</strong></a> |
<a name="java-create-powerpoint-presentation-sunburst-chart" id="java-create-powerpoint-presentation-sunburst-chart"><strong><em>Schritte:</em> PowerPoint-Präsentations-Sonnenblumen-Diagramm in Java erstellen</strong></a>

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
2. Holen Sie sich eine Referenz auf eine Folie über ihren Index.
3. Fügen Sie ein Diagramm mit Standarddaten zusammen mit dem gewünschten Typ hinzu (in diesem Fall,[ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/ChartType).sunburst).
4. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

Dieser Java-Code zeigt Ihnen, wie Sie ein Sonnenblumen-Diagramm erstellen:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    //Zweig 1
    IChartCategory leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Blatt1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stamm1");
    leaf.getGroupingLevels().setGroupingItem(2, "Zweig1");

    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Blatt2"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Blatt3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stamm2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Blatt4"));

    //Zweig 2
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C5", "Blatt5"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stamm3");
    leaf.getGroupingLevels().setGroupingItem(2, "Zweig2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C6", "Blatt6"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C7", "Blatt7"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stamm4");

    chart.getChartData().getCategories().add(wb.getCell(0, "C8", "Blatt8"));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Sunburst);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D8", 3));
    
    pres.save("Sunburst.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Erstellen von Histogramm-Diagrammen**

<a name="java-create-histogram-chart" id="java-create-histogram-chart"><strong><em>Schritte:</em> Histogramm-Diagramm in Java erstellen</strong></a> |
<a name="java-create-powerpoint-histogram-chart" id="java-create-powerpoint-histogram-chart"><strong><em>Schritte:</em> PowerPoint-Histogramm-Diagramm in Java erstellen</strong></a> |
<a name="java-create-powerpoint-presentation-histogram-chart" id="java-create-powerpoint-presentation-histogram-chart"><strong><em>Schritte:</em> PowerPoint-Präsentations-Histogramm-Diagramm in Java erstellen</strong></a>

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
2. Holen Sie sich eine Referenz auf eine Folie über ihren Index.
3. Fügen Sie ein Diagramm mit Standarddaten zusammen mit dem gewünschten Typ hinzu ([ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/ChartType).Histogram).
4. Greifen Sie auf das Diagramm-Daten [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataWorkbook) zu.
5. Löschen Sie die Standardreihen und -kategorien.
6. Fügen Sie neue Reihen und Kategorien hinzu.
7. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

Dieser Java-Code zeigt Ihnen, wie Sie ein Histogramm-Diagramm erstellen:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Histogram, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Histogram);
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A1", 15));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A2", -41));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A3", 16));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A4", 10));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A5", -23));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A6", 16));

    chart.getAxes().getHorizontalAxis().setAggregationType(AxisAggregationType.Automatic);

    pres.save("Histogram.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Erstellen von Radar-Diagrammen**

<a name="java-create-radar-chart" id="java-create-radar-chart"><strong><em>Schritte:</em> Radar-Diagramm in Java erstellen</strong></a> |
<a name="java-create-powerpoint-radar-chart" id="java-create-powerpoint-radar-chart"><strong><em>Schritte:</em> PowerPoint-Radar-Diagramm in Java erstellen</strong></a> |
<a name="java-create-powerpoint-presentation-radar-chart" id="java-create-powerpoint-presentation-radar-chart"><strong><em>Schritte:</em> PowerPoint-Präsentations-Radar-Diagramm in Java erstellen</strong></a>

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
2. Holen Sie sich eine Referenz auf eine Folie über ihren Index. 
3. Fügen Sie ein Diagramm hinzu und geben Sie Ihren bevorzugten Diagrammtyp an (`ChartType.Radar` in diesem Fall).
4. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

Dieser Java-Code zeigt Ihnen, wie Sie ein Radar-Diagramm erstellen:

```java
Presentation pres = new Presentation();
try {
    pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Radar, 20, 20, 400, 300);
    pres.save("Radar-chart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Erstellen von Mehrkategorie-Diagrammen**

<a name="java-create-multi-category-chart" id="java-create-multi-category-chart"><strong><em>Schritte:</em> Mehrkategorie-Diagramm in Java erstellen</strong></a> |
<a name="java-create-powerpoint-multi-category-chart" id="java-create-powerpoint-multi-category-chart"><strong><em>Schritte:</em> PowerPoint-Mehrkategorie-Diagramm in Java erstellen</strong></a> |
<a name="java-create-powerpoint-presentation-multi-category-chart" id="java-create-powerpoint-presentation-multi-category-chart"><strong><em>Schritte:</em> PowerPoint-Präsentations-Mehrkategorie-Diagramm in Java erstellen</strong></a>

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
2. Holen Sie sich eine Referenz auf eine Folie über ihren Index. 
3. Fügen Sie ein Diagramm mit Standarddaten zusammen mit dem gewünschten Typ hinzu ([ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/ChartType).ClusteredColumn).
4. Greifen Sie auf das Diagramm-Daten [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataWorkbook) zu.
5. Löschen Sie die Standardreihen und -kategorien.
6. Fügen Sie neue Reihen und Kategorien hinzu.
7. Fügen Sie neue Diagrammdaten für die Diagrammreihe hinzu.
8. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

Dieser Java-Code zeigt Ihnen, wie Sie ein Mehrkategorie-Diagramm erstellen:

```java
Presentation pres = new Presentation();
try {
    IChart ch = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 600, 450);
    ch.getChartData().getSeries().clear();
    ch.getChartData().getCategories().clear();
    
    IChartDataWorkbook fact = ch.getChartData().getChartDataWorkbook();
    fact.clear(0);
    int defaultWorksheetIndex = 0;

    IChartCategory category = ch.getChartData().getCategories().add(fact.getCell(0, "c2", "A"));
    category.getGroupingLevels().setGroupingItem(1, "Gruppe1");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c3", "B"));

    category = ch.getChartData().getCategories().add(fact.getCell(0, "c4", "C"));
    category.getGroupingLevels().setGroupingItem(1, "Gruppe2");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c5", "D"));

    category = ch.getChartData().getCategories().add(fact.getCell(0, "c6", "E"));
    category.getGroupingLevels().setGroupingItem(1, "Gruppe3");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c7", "F"));

    category = ch.getChartData().getCategories().add(fact.getCell(0, "c8", "G"));
    category.getGroupingLevels().setGroupingItem(1, "Gruppe4");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c9", "H"));

    // Reihen hinzufügen
    IChartSeries series = ch.getChartData().getSeries().add(fact.getCell(0, "D1", "Reihe 1"),
            ChartType.ClusteredColumn);

    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D2", 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D3", 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D4", 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D5", 40));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D6", 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D7", 60));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D8", 70));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D9", 80));
    
    // Speichert die Präsentation mit dem Diagramm
    pres.save("AsposeChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Erstellen von Karten-Diagrammen**

Ein Karten-Diagramm ist eine Visualisierung eines Gebiets, das Daten enthält. Karten-Diagramme eignen sich am besten, um Daten oder Werte zwischen geografischen Regionen zu vergleichen.

<a name="java-create-map-chart" id="java-create-map-chart"><strong><em>Schritte:</em> Karten-Diagramm in Java erstellen</strong></a> |
<a name="java-create-powerpoint-map-chart" id="java-create-powerpoint-map-chart"><strong><em>Schritte:</em> PowerPoint-Karten-Diagramm in Java erstellen</strong></a> |
<a name="java-create-powerpoint-presentation-map-chart" id="java-create-powerpoint-presentation-map-chart"><strong><em>Schritte:</em> PowerPoint-Präsentations-Karten-Diagramm in Java erstellen</strong></a>

Dieser Java-Code zeigt Ihnen, wie Sie ein Karten-Diagramm erstellen:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Map, 50, 50, 500, 400);
    pres.save("mapChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Erstellen von Kombinationsdiagrammen**

Ein Kombinationsdiagramm (oder Kombodiagramm) ist ein Diagramm, das zwei oder mehr Diagramme in einem einzigen Diagramm kombiniert. Ein solches Diagramm ermöglicht es Ihnen, Unterschiede zwischen zwei (oder mehr) Datensätzen hervorzuheben, zu vergleichen oder zu überprüfen. So sehen Sie die Beziehung (falls vorhanden) zwischen den Datensätzen.

![kombinationsdiagramm-ppt](kombinationsdiagramm-ppt.png)

Dieser Java-Code zeigt Ihnen, wie Sie ein Kombinationsdiagramm in PowerPoint erstellen:

```java
private static void createComboChart()
{
    Presentation pres = new Presentation();
    {
        IChart chart = createChart(pres.getSlides().get_Item(0));
        addFirstSeriesToChart(chart);
        addSecondSeriesToChart(chart);
        pres.save("combo-chart.pptx", SaveFormat.Pptx);
    }
}

private static IChart createChart(ISlide slide)
{
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400);
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    final int worksheetIndex = 0;

    chart.getChartData().getSeries().add(workbook.getCell(worksheetIndex, 0, 1, "Reihe 1"), chart.getType());
    chart.getChartData().getSeries().add(workbook.getCell(worksheetIndex, 0, 2, "Reihe 2"), chart.getType());

    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 1, 0, "Kategorie 1"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 2, 0, "Kategorie 2"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 3, 0, "Kategorie 3"));

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 1, 30));

    series = chart.getChartData().getSeries().get_Item(1);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 2, 60));

    return chart;
}

private static void addFirstSeriesToChart(IChart chart)
{
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    final int worksheetIndex = 0;

    IChartSeries series = chart.getChartData().getSeries().add(workbook.getCell(worksheetIndex, 0, 3, "Reihe 3"), ChartType.ScatterWithSmoothLines);

    series.getDataPoints().addDataPointForScatterSeries(
            workbook.getCell(worksheetIndex, 0, 1, 3),
            workbook.getCell(worksheetIndex, 0, 2, 5));

    series.getDataPoints().addDataPointForScatterSeries(
            workbook.getCell(worksheetIndex, 1, 3, 10),
            workbook.getCell(worksheetIndex, 1, 4, 13));

    series.getDataPoints().addDataPointForScatterSeries(
            workbook.getCell(worksheetIndex, 2, 3, 20),
            workbook.getCell(worksheetIndex, 2, 4, 15));

    series.setPlotOnSecondAxis(true);
}

private static void addSecondSeriesToChart(IChart chart)
{
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    final int worksheetIndex = 0;

    IChartSeries series = chart.getChartData().getSeries().add(workbook.getCell(worksheetIndex, 0, 5, "Reihe 4"),
            ChartType.ScatterWithStraightLinesAndMarkers);

    series.getDataPoints().addDataPointForScatterSeries(
            workbook.getCell(worksheetIndex, 1, 3, 5),
            workbook.getCell(worksheetIndex, 1, 4, 2));

    series.getDataPoints().addDataPointForScatterSeries(
            workbook.getCell(worksheetIndex, 1, 5, 10),
            workbook.getCell(worksheetIndex, 1, 6, 7));

    series.getDataPoints().addDataPointForScatterSeries(
            workbook.getCell(worksheetIndex, 2, 5, 15),
            workbook.getCell(worksheetIndex, 2, 6, 12));

    series.getDataPoints().addDataPointForScatterSeries(
            workbook.getCell(worksheetIndex, 3, 5, 12),
            workbook.getCell(worksheetIndex, 3, 6, 9));

    series.setPlotOnSecondAxis(true);
}
```

## **Diagramme aktualisieren**

<a name="java-update-powerpoint-chart" id="java-update-powerpoint-chart"><strong><em>Schritte:</em> PowerPoint-Diagramm in Java aktualisieren</strong></a> |
<a name="java-update-presentation-chart" id="java-update-presentation-chart"><strong><em>Schritte:</em> Präsentationsdiagramm aktualisieren</strong></a> |
<a name="java-update-powerpoint-presentation-chart" id="java-update-powerpoint-presentation-chart"><strong><em>Schritte:</em> PowerPoint-Präsentationsdiagramm aktualisieren</strong></a>

1. Instanziieren Sie eine [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse, die die Präsentation enthält, deren Diagramm Sie aktualisieren möchten. 
2. Erhalten Sie die Referenz einer Folie über ihren Index.
3. Durchsuchen Sie alle Formen, um das gewünschte Diagramm zu finden.
4. Greifen Sie auf das Datenarbeitsblatt des Diagramms zu.
5. Ändern Sie die Datenserien des Diagramms, indem Sie die Werte der Serien ändern.
6. Fügen Sie eine neue Reihe hinzu und füllen Sie die Daten darin aus.
7. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser Java-Code zeigt Ihnen, wie Sie ein Diagramm aktualisieren:

```java
Presentation pres = new Presentation();
try {
    // Greift auf die erste Folie zu
    ISlide sld = pres.getSlides().get_Item(0);

    // Nimmt das Diagramm mit Standarddaten
    IChart chart = (IChart)sld.getShapes().get_Item(0);

    // Setzt den Index des Datenarbeitsblattes
    int defaultWorksheetIndex = 0;

    // Holt das Datenarbeitsblatt des Diagramms
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // Ändert den Kategorienamen des Diagramms
    fact.getCell(defaultWorksheetIndex, 1, 0, "Modifizierte Kategorie 1");
    fact.getCell(defaultWorksheetIndex, 2, 0, "Modifizierte Kategorie 2");

    // Nimmt die erste Diagrammreihe
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    // Jetzt die Seriendaten aktualisieren
    fact.getCell(defaultWorksheetIndex, 0, 1, "Neue_Reihe1"); // Serienname ändern
    series.getDataPoints().get_Item(0).getValue().setData(90);
    series.getDataPoints().get_Item(1).getValue().setData(123);
    series.getDataPoints().get_Item(2).getValue().setData(44);

    // Nimmt die zweite Diagrammreihe
    series = chart.getChartData().getSeries().get_Item(1);

    // Jetzt die Seriendaten aktualisieren
    fact.getCell(defaultWorksheetIndex, 0, 2, "Neue_Reihe2"); // Serienname ändern
    series.getDataPoints().get_Item(0).getValue().setData(23);
    series.getDataPoints().get_Item(1).getValue().setData(67);
    series.getDataPoints().get_Item(2).getValue().setData(99);

    // Jetzt hinzufügen einer neuen Reihe
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "Reihe 3"), chart.getType());

    // Nimmt die dritte Diagrammreihe
    series = chart.getChartData().getSeries().get_Item(2);

    // Jetzt die Seriendaten ausfüllen
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 3, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 30));

    chart.setType(ChartType.ClusteredCylinder);

    // Speichert die Präsentation mit dem Diagramm
    pres.save("AsposeChartModified_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Datenbereich für Diagramme festlegen**

Um den Datenbereich für ein Diagramm festzulegen, gehen Sie folgendermaßen vor:

1. Instanziieren Sie eine [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse, die die Präsentation enthält, die das Diagramm enthält.
2. Holen Sie sich eine Referenz auf eine Folie über ihren Index.
3. Durchsuchen Sie alle Formen, um das gewünschte Diagramm zu finden.
4. Greifen Sie auf die Diagrammdaten zu und setzen Sie den Bereich.
5. Speichern Sie die modifizierte Präsentation als PPTX-Datei.

Dieser Java-Code zeigt Ihnen, wie Sie den Datenbereich für ein Diagramm festlegen:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = (IChart)slide.getShapes().get_Item(0);
    
    chart.getChartData().setRange("Sheet1!A1:B4");
    
    pres.save("SetDataRange_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Standardmarkierungen in Diagrammen verwenden**
Wenn Sie eine Standardmarkierung in Diagrammen verwenden, erhalten jede Diagrammreihe automatisch unterschiedliche Standardmarkierungen.

Dieser Java-Code zeigt Ihnen, wie Sie eine Diagrammreihe automatisch markieren:

```java
