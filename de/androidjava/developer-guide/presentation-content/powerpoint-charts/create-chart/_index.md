---
title: PowerPoint-Präsentationsdiagramme auf Android erstellen oder aktualisieren
linktitle: Diagramme erstellen oder aktualisieren
type: docs
weight: 10
url: /de/androidjava/create-chart/
keywords:
- Diagramm hinzufügen
- Diagramm erstellen
- Diagramm bearbeiten
- Diagramm ändern
- Diagramm aktualisieren
- Streudiagramm
- Kreisdiagramm
- Liniendiagramm
- Tree‑Map‑Diagramm
- Aktien‑Diagramm
- Box‑Und‑Whisker‑Diagramm
- Trichter‑Diagramm
- Sunburst‑Diagramm
- Histogramm‑Diagramm
- Radar‑Diagramm
- Mehrkategorie‑Diagramm
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Erstellen und anpassen von Diagrammen in PowerPoint‑Präsentationen mit Aspose.Slides für Android. Diagramme hinzufügen, formatieren und bearbeiten mit praktischen Java‑Code‑Beispielen."
---
## **Übersicht**

Dieser Artikel bietet eine umfassende Anleitung, wie Diagramme mit Aspose.Slides erstellt und angepasst werden. Sie erfahren, wie Sie programmgesteuert ein Diagramm zu einer Folie hinzufügen, es mit Daten füllen und verschiedene Formatierungsoptionen anwenden, um Ihren spezifischen Designanforderungen zu entsprechen. Im gesamten Artikel veranschaulichen detaillierte Code‑Beispiele jeden Schritt, vom Initialisieren der Präsentation und des Diagrammobjekts bis hin zur Konfiguration von Reihen, Achsen und Legenden. Wenn Sie dieser Anleitung folgen, erhalten Sie ein solides Verständnis dafür, wie Sie die dynamische Diagrammerstellung in Ihre Anwendungen integrieren und den Prozess der Erstellung datenbasierter Präsentationen optimieren.

## **Diagramm erstellen**

Diagramme helfen, Daten schnell zu visualisieren und Erkenntnisse zu gewinnen, die aus einer Tabelle oder Kalkulationstabelle nicht sofort ersichtlich sind.

**Warum Diagramme erstellen?**

* große Datenmengen auf einer einzigen Folie in einer Präsentation aggregieren, komprimieren oder zusammenfassen  
* Muster und Trends in Daten sichtbar machen  
* die Richtung und das Momentum von Daten im Zeitverlauf oder in Bezug auf eine bestimmte Maßeinheit ableiten  
* Ausreißer, Aberrationen, Abweichungen, Fehler, unsinnige Daten usw. erkennen  
* komplexe Daten kommunizieren oder präsentieren  

In PowerPoint können Sie Diagramme über die Einfügefunktion erstellen, die Vorlagen für die Gestaltung vieler Diagrammtypen bereitstellt. Mit Aspose.Slides können Sie reguläre Diagramme (basierend auf gängigen Diagrammtypen) und benutzerdefinierte Diagramme erstellen.

{{% alert color="info" %}} 
Um Diagramme zu erstellen, stellt Aspose.Slides die Klasse [ChartType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ChartType) bereit. Die Felder dieser Klasse entsprechen verschiedenen Diagrammtypen. 
{{% /alert %}} 

### **Normale Diagramme erstellen**

_Schritte: Diagramm erstellen_
- <a name="java-create-powerpoint-chart" id="java-create-powerpoint-chart"><strong><em>Schritte:</em> PowerPoint‑Diagramm in Java erstellen</strong></a>
- <a name="java-create-presentation-chart" id="java-create-presentation-chart"><strong><em>Schritte:</em> Präsentations‑Diagramm in Java erstellen</strong></a>
- <a name="java-create-powerpoint-presentation-chart" id="java-create-powerpoint-presentation-chart"><strong><em>Schritte:</em> PowerPoint‑Präsentations‑Diagramm in Java erstellen</strong></a>

_Code‑Schritte:_

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation).
2. Rufen Sie die Referenz einer Folie über ihren Index ab.
3. Fügen Sie ein Diagramm mit einigen Daten hinzu und geben Sie Ihren bevorzugten Diagrammtyp an. 
4. Fügen Sie dem Diagramm einen Titel hinzu. 
5. Greifen Sie auf das Daten‑Worksheet des Diagramms zu.
6. Löschen Sie alle Standard‑Reihen und -Kategorien.
7. Fügen Sie neue Reihen und Kategorien hinzu.
8. Fügen Sie neue Diagrammdaten für die Diagrammreihen hinzu.
9. Fügen Sie eine Füllfarbe für Diagrammreihen hinzu.
10. Fügen Sie Beschriftungen für die Diagrammreihen hinzu. 
11. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser Java‑Code zeigt, wie Sie ein normales Diagramm erstellen:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instanziiert eine Präsentationsklasse, die eine PPTX-Datei darstellt
Presentation pres = new Presentation();
try {
    // Greift auf die erste Folie zu
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Fügt ein Diagramm mit den Standarddaten hinzu
    IChart chart = sld.getShapes().addChart(ChartType.ClusteredColumn, 0, 0, 500, 500);
    
    // Setzt den Diagrammtitel
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    
    // Setzt den Index für das Diagrammdatenblatt
    int defaultWorksheetIndex = 0;
    
    // Holt das Diagrammdaten-Worksheet
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Löscht die standardmäßig generierten Reihen und Kategorien
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    int s = chart.getChartData().getSeries().size();
    s = chart.getChartData().getCategories().size();
    
    // Fügt neue Reihen hinzu
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"),chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"),chart.getType());
    
    // Fügt neue Kategorien hinzu
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // Nimmt die erste Diagrammreihe
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // Befüllt nun die Daten der Reihe
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // Setzt die Füllfarbe für die Reihe
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    
    // Nimmt die zweite Diagrammreihe
    series = chart.getChartData().getSeries().get_Item(1);
    
    // Befüllt die Daten der Reihe
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // Setzt die Füllfarbe für die Reihe
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.GREEN);
    
    //Erstelle benutzerdefinierte Beschriftungen für jede Kategorie der neuen Reihe
    // Setzt die erste Beschriftung, um den Kategorienamen anzuzeigen
    IDataLabel lbl = series.getDataPoints().get_Item(0).getLabel();
    lbl.getDataLabelFormat().setShowCategoryName(true);
    
    lbl = series.getDataPoints().get_Item(1).getLabel();
    lbl.getDataLabelFormat().setShowSeriesName(true);
    
    // Zeigt den Wert für die dritte Beschriftung an
    lbl = series.getDataPoints().get_Item(2).getLabel();
    lbl.getDataLabelFormat().setShowValue(true);
    lbl.getDataLabelFormat().setShowSeriesName(true);
    lbl.getDataLabelFormat().setSeparator("/");
    
    // Speichert die Präsentation mit Diagramm
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Streudiagramme erstellen**

Streudiagramme (auch als Streudiagramme oder x‑y‑Diagramme bezeichnet) werden häufig verwendet, um Muster zu überprüfen oder Korrelationen zwischen zwei Variablen darzustellen. 

Sie können ein Streudiagramm verwenden, wenn  

* Sie über ein gepaartes numerisches Datenpaar verfügen  
* Sie zwei Variablen haben, die gut zusammenpassen  
* Sie bestimmen möchten, ob zwei Variablen miteinander verbunden sind  
* Sie eine unabhängige Variable haben, die mehrere Werte für eine abhängige Variable besitzt  

<a name="java-create-scattered-chart" id="java-create-scattered-chart"><strong><em>Schritte:</em> Streudiagramm in Java erstellen</strong></a> |
<a name="java-create-powerpoint-scattered-chart" id="java-create-powerpoint-scattered-chart"><strong><em>Schritte:</em> PowerPoint‑Streudiagramm in Java erstellen</strong></a> |
<a name="java-create-powerpoint-presentation-scattered-chart" id="java-create-powerpoint-presentation-scattered-chart"><strong><em>Schritte:</em> PowerPoint‑Präsentations‑Streudiagramm in Java erstellen</strong></a>

1. Bitte folgen Sie den oben genannten Schritten in [Normale Diagramme erstellen](#creating-normal-charts)
2. Für den dritten Schritt, fügen Sie ein Diagramm mit einigen Daten hinzu und geben Sie Ihren Diagrammtyp als einen der folgenden an  
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/charttype/#ScatterWithMarkers) - _Stellt ein Streudiagramm dar._  
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Stellt ein Streudiagramm dar, das durch Kurven verbunden ist, mit Daten‑Markern._  
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/charttype/#ScatterWithSmoothLines) - _Stellt ein Streudiagramm dar, das durch Kurven verbunden ist, ohne Daten‑Marker._  
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Stellt ein Streudiagramm dar, das durch gerade Linien verbunden ist, mit Daten‑Markern._  
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/charttype/#ScatterWithStraightLines) - _Stellt ein Streudiagramm dar, das durch gerade Linien verbunden ist, ohne Daten‑Marker._

Dieser Java‑Code zeigt, wie Sie Streudiagramme mit unterschiedlichen Markerserien erstellen: 

```java
import com.aspose.slides.*;

// Instanziert eine Präsentationsklasse, die eine PPTX-Datei darstellt
Presentation pres = new Presentation();
try {
    // Greift auf die erste Folie zu
    ISlide slide = pres.getSlides().get_Item(0);

    // Erstellt das Standarddiagramm
    IChart chart = slide.getShapes().addChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);
    
    // Holt den Index des Standard‑Diagrammdaten‑Worksheets
    int defaultWorksheetIndex = 0;
    
    // Holt das Diagrammdaten‑Worksheet
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Löscht die Demo‑Reihen
    chart.getChartData().getSeries().clear();
    
    // Fügt neue Reihen hinzu
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.getType());
    
    // Nimmt die erste Diagrammreihe
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // Fügt der Reihe einen neuen Punkt (1:3) hinzu
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 1), fact.getCell(defaultWorksheetIndex, 2, 2, 3));
    
    // Fügt einen neuen Punkt (2:10) hinzu
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 2), fact.getCell(defaultWorksheetIndex, 3, 2, 10));
    
    // Ändert den Reihen‑Typ
    series.setType(ChartType.ScatterWithStraightLinesAndMarkers);
    
    // Ändert den Diagrammreihen‑Marker
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
    
    // Ändert den Diagrammreihen‑Marker
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(MarkerStyleType.Circle);
    
    pres.save("AsposeChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Kreisdiagramme erstellen**

Kreisdiagramme eignen sich am besten, um das Verhältnis von Teil zu Ganzem in Daten darzustellen, insbesondere wenn die Daten kategoriale Beschriftungen mit numerischen Werten enthalten. Wenn Ihre Daten jedoch viele Teile oder Beschriftungen enthalten, sollten Sie stattdessen ein Balkendiagramm in Betracht ziehen.

<a name="java-create-pie-chart" id="java-create-pie-chart"><strong><em>Schritte:</em> Kreisdiagramm in Java erstellen</strong></a> |
<a name="java-create-powerpoint-pie-chart" id="java-create-powerpoint-pie-chart"><strong><em>Schritte:</em> PowerPoint‑Kreisdiagramm in Java erstellen</strong></a> |
<a name="java-create-powerpoint-presentation-pie-chart" id="java-create-powerpoint-presentation-pie-chart"><strong><em>Schritte:</em> PowerPoint‑Präsentations‑Kreisdiagramm in Java erstellen</strong></a>

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation).
2. Rufen Sie die Referenz einer Folie über ihren Index ab.
3. Fügen Sie ein Diagramm mit Standarddaten und dem gewünschten Typ hinzu (in diesem Fall [ChartType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ChartType).Pie).
4. Greifen Sie auf das Diagramm‑Daten‑[IChartDataWorkbook](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IChartDataWorkbook) zu.
5. Löschen Sie die Standard‑Reihen und -Kategorien.
6. Fügen Sie neue Reihen und Kategorien hinzu.
7. Fügen Sie neue Diagrammdaten für die Diagrammreihen hinzu.
8. Fügen Sie neue Punkte für das Diagramm hinzu und setzen Sie benutzerdefinierte Farben für die Sektoren des Kreisdiagramms.
9. Setzen Sie Beschriftungen für die Reihen.
10. Setzen Sie Führungs‑Linien für Reihen‑Beschriftungen.
11. Setzen Sie den Drehwinkel für Kreisdiagramm‑Folien.
12. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser Java‑Code zeigt, wie Sie ein Kreisdiagramm erstellen:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instanziert eine Präsentationsklasse, die eine PPTX-Datei darstellt
Presentation pres = new Presentation();
try {
    // Greift auf die erste Folie zu
    ISlide slides = pres.getSlides().get_Item(0);
    
    // Fügt ein Diagramm mit Standarddaten hinzu
    IChart chart = slides.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);
    
    // Setzt den Diagrammtitel
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    
    // Setzt den Index für das Diagrammdatenblatt
    int defaultWorksheetIndex = 0;
    
    // Holt das Diagrammdaten-Worksheet
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Löscht die standardmäßig generierten Reihen und Kategorien
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    
    // Fügt neue Kategorien hinzu
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    
    // Fügt neue Reihen hinzu
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    
    //Populates the series data
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // Not working in new version
    // Adding new points and setting sector color
    // series.IsColorVaried = true;
    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(true);
    
    IChartDataPoint point = series.getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(FillType.Solid);
    point.getFormat().getFill().getSolidFillColor().setColor(Color.CYAN);
	
    // Setzt die Sektor‑Umrandung
    point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    point.getFormat().getLine().setWidth(3.0);
    point.getFormat().getLine().setStyle(LineStyle.ThinThick);
    point.getFormat().getLine().setDashStyle(LineDashStyle.DashDot);
    
    IChartDataPoint point1 = series.getDataPoints().get_Item(1);
    point1.getFormat().getFill().setFillType(FillType.Solid);
    point1.getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE);
    
    // Setzt die Sektor‑Umrandung
    point1.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point1.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    point1.getFormat().getLine().setWidth(3.0);
    point1.getFormat().getLine().setStyle(LineStyle.Single);
    point1.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDot);
    
    IChartDataPoint point2 = series.getDataPoints().get_Item(2);
    point2.getFormat().getFill().setFillType(FillType.Solid);
    point2.getFormat().getFill().getSolidFillColor().setColor(Color.YELLOW);
    
    // Setzt die Sektor‑Umrandung
    point2.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point2.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    point2.getFormat().getLine().setWidth(2.0);
    point2.getFormat().getLine().setStyle(LineStyle.ThinThin);
    point2.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDotDot);
    
    // Erstellt benutzerdefinierte Beschriftungen für jede der Kategorien der neuen Reihe
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
    
    // Zeigt Führungs­linien für das Diagramm an
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(true);
    
    // Setzt den Drehwinkel für die Sektoren des Kreisdiagramms
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);
    
    // Speichert die Präsentation mit einem Diagramm
    pres.save("PieChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Liniendiagramme erstellen**

Liniendiagramme (auch als Liniendiagramme bezeichnet) eignen sich am besten, wenn Sie Änderungen von Werten im Zeitverlauf demonstrieren möchten. Mit einem Liniendiagramm können Sie viele Daten gleichzeitig vergleichen, Änderungen und Trends im Zeitverlauf verfolgen, Anomalien in Datenreihen hervorheben usw.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation).
1. Rufen Sie die Referenz einer Folie über ihren Index ab.
1. Fügen Sie ein Diagramm mit Standarddaten und dem gewünschten Typ hinzu (in diesem Fall `ChartType.Line`).
1. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser Java‑Code zeigt, wie Sie ein Liniendiagramm erstellen:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart lineChart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350);

    pres.save("lineChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Standardmäßig sind die Punkte eines Liniendiagramms durch durchgehende gerade Linien verbunden. Wenn Sie die Punkte stattdessen durch Striche verbinden möchten, können Sie Ihren bevorzugten Strich‑Typ wie folgt angeben:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart lineChart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350);

    for (IChartSeries series : lineChart.getChartData().getSeries())
    {
        series.getFormat().getLine().setDashStyle(LineDashStyle.Dash);
    }
} finally {
    if (pres != null) pres.dispose();
}
```

### **Tree‑Map‑Diagramme erstellen**

Tree‑Map‑Diagramme eignen sich am besten für Verkaufsdaten, wenn Sie die relative Größe von Datenkategorien zeigen und gleichzeitig schnell Aufmerksamkeit auf Elemente lenken wollen, die große Beiträge zu jeder Kategorie leisten. 

<a name="java-create-tree-map-chart" id="java-create-tree-map-chart"><strong><em>Schritte:</em> Tree‑Map‑Diagramm in Java erstellen</strong></a> |
<a name="java-create-powerpoint-tree-map-chart" id="java-create-powerpoint-tree-map-chart"><strong><em>Schritte:</em> PowerPoint‑Tree‑Map‑Diagramm in Java erstellen</strong></a> |
<a name="java-create-powerpoint-presentation-tree-map-chart" id="java-create-powerpoint-presentation-tree-map-chart"><strong><em>Schritte:</em> PowerPoint‑Präsentations‑Tree‑Map‑Diagramm in Java erstellen</strong></a>

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation) Klasse.
2. Rufen Sie die Referenz einer Folie über ihren Index ab.
3. Fügen Sie ein Diagramm mit Standarddaten und dem gewünschten Typ hinzu (in diesem Fall [ChartType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ChartType).TreeMap).
4. Greifen Sie auf das Diagramm‑Daten‑[IChartDataWorkbook](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IChartDataWorkbook) zu.
5. Löschen Sie die Standard‑Reihen und -Kategorien.
6. Fügen Sie neue Reihen und Kategorien hinzu.
7. Fügen Sie neue Diagrammdaten für die Diagrammreihen hinzu.
8. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser Java‑Code zeigt, wie Sie ein Tree‑Map‑Diagramm erstellen:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Treemap, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    //Zweig 1
    IChartCategory leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");

    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));

    //Zweig 2
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C5", "Leaf5"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C6", "Leaf6"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C7", "Leaf7"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");

    chart.getChartData().getCategories().add(wb.getCell(0, "C8", "Leaf8"));

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

### **Aktien‑Diagramme erstellen**

<a name="java-create-stock-chart" id="java-create-stock-chart"><strong><em>Schritte:</em> Aktien‑Diagramm in Java erstellen</strong></a> |
<a name="java-create-powerpoint-stock-chart" id="java-powerpoint-stock-chart"><strong><em>Schritte:</em> PowerPoint‑Aktien‑Diagramm in Java erstellen</strong></a> |
<a name="java-create-powerpoint-presentation-stock-chart" id="java-create-powerpoint-presentation-stock-chart"><strong><em>Schritte:</em> PowerPoint‑Präsentations‑Aktien‑Diagramm in Java erstellen</strong></a>

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation) Klasse.
2. Rufen Sie die Referenz einer Folie über ihren Index ab.
3. Fügen Sie ein Diagramm mit Standarddaten und dem gewünschten Typ ([ChartType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ChartType).OpenHighLowClose) hinzu.
4. Greifen Sie auf das Diagramm‑Daten‑[IChartDataWorkbook](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IChartDataWorkbook) zu.
5. Löschen Sie die Standard‑Reihen und -Kategorien.
6. Fügen Sie neue Reihen und Kategorien hinzu.
7. Fügen Sie neue Diagrammdaten für die Diagrammreihen hinzu.
8. Legen Sie das Format für HiLowLines fest.
9. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Beispiel‑Java‑Code zum Erstellen eines Aktien‑Diagramms:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.OpenHighLowClose, 50, 50, 600, 400, false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();

    chart.getChartData().getCategories().add(wb.getCell(0, 1, 0, "A"));
    chart.getChartData().getCategories().add(wb.getCell(0, 2, 0, "B"));
    chart.getChartData().getCategories().add(wb.getCell(0, 3, 0, "C"));

    chart.getChartData().getSeries().add(wb.getCell(0, 0, 1, "Open"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 2, "High"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 3, "Low"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 4, "Close"), chart.getType());

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

### **Box‑Und‑Whisker‑Diagramme erstellen**

<a name="java-create-box-and-whisker-chart" id="java-create-box-and-whisker-chart"><strong><em>Schritte:</em> Box‑Und‑Whisker‑Diagramm in Java erstellen</strong></a> |
<a name="java-create-powerpoint-box-and-whisker-chart" id="java-powerpoint-box-and-whisker-chart"><strong><em>Schritte:</em> PowerPoint‑Box‑Und‑Whisker‑Diagramm in Java erstellen</strong></a> |
<a name="java-create-powerpoint-presentation-box-and-whisker-chart" id="java-create-powerpoint-presentation-box-and-whisker-chart"><strong><em>Schritte:</em> PowerPoint‑Präsentations‑Box‑Und‑Whisker‑Diagramm in Java erstellen</strong></a>

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation) Klasse.
2. Rufen Sie die Referenz einer Folie über ihren Index ab.
3. Fügen Sie ein Diagramm mit Standarddaten und dem gewünschten Typ ([ChartType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ChartType).BoxAndWhisker) hinzu.
4. Greifen Sie auf das Diagramm‑Daten‑[IChartDataWorkbook](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IChartDataWorkbook) zu.
5. Löschen Sie die Standard‑Reihen und -Kategorien.
6. Fügen Sie neue Reihen und Kategorien hinzu.
7. Fügen Sie neue Diagrammdaten für die Diagrammreihen hinzu.
8. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser Java‑Code zeigt, wie Sie ein Box‑Und‑Whisker‑Diagramm erstellen:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.BoxAndWhisker, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 1"));

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

### **Trichter‑Diagramme erstellen**

<a name="java-create-funnel-chart" id="java-create-funnel-chart"><strong><em>Schritte:</em> Trichter‑Diagramm in Java erstellen</strong></a> |
<a name="java-create-powerpoint-funnel-chart" id="java-create-powerpoint-funnel-chart"><strong><em>Schritte:</em> PowerPoint‑Trichter‑Diagramm in Java erstellen</strong></a> |
<a name="java-create-powerpoint-presentation-funnel-chart" id="java-create-powerpoint-presentation-funnel-chart"><strong><em>Schritte:</em> PowerPoint‑Präsentations‑Trichter‑Diagramm in Java erstellen</strong></a>


1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation) Klasse.
2. Rufen Sie die Referenz einer Folie über ihren Index ab.
3. Fügen Sie ein Diagramm mit Standarddaten und dem gewünschten Typ ([ChartType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ChartType).Funnel) hinzu.
4. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Der Java‑Code zeigt, wie Sie ein Trichter‑Diagramm erstellen:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Funnel, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();

    wb.clear(0);

    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 2"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 3"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 4"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 5"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 6"));

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

### **Sunburst‑Diagramme erstellen**

<a name="java-create-sunburst-chart" id="java-create-sunburst-chart"><strong><em>Schritte:</em> Sunburst‑Diagramm in Java erstellen</strong></a> |
<a name="java-create-powerpoint-sunburst-chart" id="java-create-powerpoint-sunburst-chart"><strong><em>Schritte:</em> PowerPoint‑Sunburst‑Diagramm in Java erstellen</strong></a> |
<a name="java-create-powerpoint-presentation-sunburst-chart" id="java-create-powerpoint-presentation-sunburst-chart"><strong><em>Schritte:</em> PowerPoint‑Präsentations‑Sunburst‑Diagramm in Java erstellen</strong></a>

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation) Klasse.
2. Rufen Sie die Referenz einer Folie über ihren Index ab.
3. Fügen Sie ein Diagramm mit Standarddaten und dem gewünschten Typ (in diesem Fall [ChartType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ChartType).sunburst) hinzu.
4. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser Java‑Code zeigt, wie Sie ein Sunburst‑Diagramm erstellen:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    //Zweig 1
    IChartCategory leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");

    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));

    //Zweig 2
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C5", "Leaf5"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C6", "Leaf6"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C7", "Leaf7"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");

    chart.getChartData().getCategories().add(wb.getCell(0, "C8", "Leaf8"));

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

### **Histogramm‑Diagramme erstellen**

<a name="java-create-histogram-chart" id="java-create-histogram-chart"><strong><em>Schritte:</em> Histogramm‑Diagramm in Java erstellen</strong></a> |
<a name="java-create-powerpoint-histogram-chart" id="java-create-powerpoint-histogram-chart"><strong><em>Schritte:</em> PowerPoint‑Histogramm‑Diagramm in Java erstellen</strong></a> |
<a name="java-create-powerpoint-presentation-histogram-chart" id="java-create-powerpoint-presentation-histogram-chart"><strong><em>Schritte:</em> PowerPoint‑Präsentations‑Histogramm‑Diagramm in Java erstellen</strong></a>

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation) Klasse.
2. Rufen Sie die Referenz einer Folie über ihren Index ab.
3. Fügen Sie ein Diagramm mit Standarddaten und dem gewünschten Typ ([ChartType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ChartType).Histogram) hinzu.
4. Greifen Sie auf das Diagramm‑Daten‑[IChartDataWorkbook](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IChartDataWorkbook) zu.
5. Löschen Sie die Standard‑Reihen und -Kategorien.
6. Fügen Sie neue Reihen und Kategorien hinzu.
7. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser Java‑Code zeigt, wie Sie ein Histogramm‑Diagramm erstellen:

```java
import com.aspose.slides.*;

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

### **Radar‑Diagramme erstellen**

<a name="java-create-radar-chart" id="java-create-radar-chart"><strong><em>Schritte:</em> Radar‑Diagramm in Java erstellen</strong></a> |
<a name="java-create-powerpoint-radar-chart" id="java-create-powerpoint-radar-chart"><strong><em>Schritte:</em> PowerPoint‑Radar‑Diagramm in Java erstellen</strong></a> |
<a name="java-create-powerpoint-presentation-radar-chart" id="java-create-powerpoint-presentation-radar-chart"><strong><em>Schritte:</em> PowerPoint‑Präsentations‑Radar‑Diagramm in Java erstellen</strong></a>

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation) Klasse.
2. Rufen Sie die Referenz einer Folie über ihren Index ab. 
3. Fügen Sie ein Diagramm mit einigen Daten hinzu und geben Sie Ihren bevorzugten Diagrammtyp (`ChartType.Radar` in diesem Fall) an.
4. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser Java‑Code zeigt, wie Sie ein Radar‑Diagramm erstellen:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Radar, 20, 20, 400, 300);
    pres.save("Radar-chart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Mehrkategorie‑Diagramme erstellen**

<a name="java-create-multi-category-chart" id="java-create-multi-category-chart"><strong><em>Schritte:</em> Mehrkategorie‑Diagramm in Java erstellen</strong></a> |
<a name="java-create-powerpoint-multi-category-chart" id="java-create-powerpoint-multi-category-chart"><strong><em>Schritte:</em> PowerPoint‑Mehrkategorie‑Diagramm in Java erstellen</strong></a> |
<a name="java-create-powerpoint-presentation-multi-category-chart" id="java-create-powerpoint-presentation-multi-category-chart"><strong><em>Schritte:</em> PowerPoint‑Präsentations‑Mehrkategorie‑Diagramm in Java erstellen</strong></a>

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation) Klasse.
2. Rufen Sie die Referenz einer Folie über ihren Index ab. 
3. Fügen Sie ein Diagramm mit Standarddaten und dem gewünschten Typ ([ChartType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ChartType).ClusteredColumn) hinzu.
4. Greifen Sie auf das Diagramm‑Daten‑[IChartDataWorkbook](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IChartDataWorkbook) zu.
5. Löschen Sie die Standard‑Reihen und -Kategorien.
6. Fügen Sie neue Reihen und Kategorien hinzu.
7. Fügen Sie neue Diagrammdaten für die Diagrammreihen hinzu.
8. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser Java‑Code zeigt, wie Sie ein Mehrkategorie‑Diagramm erstellen:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart ch = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 600, 450);
    ch.getChartData().getSeries().clear();
    ch.getChartData().getCategories().clear();
    
    IChartDataWorkbook fact = ch.getChartData().getChartDataWorkbook();
    fact.clear(0);
    int defaultWorksheetIndex = 0;

    IChartCategory category = ch.getChartData().getCategories().add(fact.getCell(0, "c2", "A"));
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
    IChartSeries series = ch.getChartData().getSeries().add(fact.getCell(0, "D1", "Series 1"),
            ChartType.ClusteredColumn);

    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D2", 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D3", 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D4", 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D5", 40));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D6", 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D7", 60));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D8", 70));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D9", 80));
    
    // Präsentation mit Diagramm speichern
    pres.save("AsposeChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Karten‑Diagramme erstellen**

Ein Karten‑Diagramm visualisiert ein Gebiet, das Daten enthält. Karten‑Diagramme eignen sich am besten, um Daten oder Werte über geografische Regionen hinweg zu vergleichen.

<a name="java-create-map-chart" id="java-create-map-chart"><strong><em>Schritte:</em> Karten‑Diagramm in Java erstellen</strong></a> |
<a name="java-create-powerpoint-map-chart" id="java-create-powerpoint-map-chart"><strong><em>Schritte:</em> PowerPoint‑Karten‑Diagramm in Java erstellen</strong></a> |
<a name="java-create-powerpoint-presentation-map-chart" id="java-create-powerpoint-presentation-map-chart"><strong><em>Schritte:</em> PowerPoint‑Präsentations‑Karten‑Diagramm in Java erstellen</strong></a>

Dieser Java‑Code zeigt, wie Sie ein Karten‑Diagramm erstellen:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Map, 50, 50, 500, 400);
    pres.save("mapChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Kombinations‑Diagramme erstellen**

Ein Kombinations‑Diagramm (oder Combo‑Diagramm) kombiniert zwei oder mehr Diagrammtypen in einem einzigen Graphen. Dieses Diagramm ermöglicht es Ihnen, Unterschiede zwischen mehreren Datensätzen hervorzuheben, zu vergleichen oder zu untersuchen und so Beziehungen zwischen ihnen zu erkennen.

![Das Kombinationsdiagramm](combination_chart.png)

Der folgende Java‑Code zeigt, wie Sie das obige Kombinations‑Diagramm in einer PowerPoint‑Präsentation erstellen:

```java
import com.aspose.slides.*;
import java.awt.Color;

static void createComboChart() {
    Presentation presentation = new Presentation();
    ISlide slide = presentation.getSlides().get_Item(0);
    try {
        IChart chart = createChartWithFirstSeries(slide);

        addSecondSeriesToChart(chart);
        addThirdSeriesToChart(chart);

        setPrimaryAxesFormat(chart);
        setSecondaryAxesFormat(chart);

        presentation.save("combo-chart.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}

static IChart createChartWithFirstSeries(ISlide slide) {
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    // Diagrammtitel setzen.
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Chart Title");
    chart.getChartTitle().setOverlay(false);
    IParagraph titleParagraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0);
    IPortionFormat titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(NullableBool.False);
    titleFormat.setFontHeight(18f);

    // Diagrammlegende setzen.
    chart.getLegend().setPosition(LegendPositionType.Bottom);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12f);

    // Die standardmäßig generierten Reihen und Kategorien löschen.
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    int worksheetIndex = 0;
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    // Neue Kategorien hinzufügen.
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 3, 0, "Category 3"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 4, 0, "Category 4"));

    // Erste Reihe hinzufügen.
    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    series.getParentSeriesGroup().setOverlap((byte)-25);
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 1, 4.3));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 1, 2.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 1, 3.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 1, 4.5));

    return chart;
}

static void addSecondSeriesToChart(IChart chart) {
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    final int worksheetIndex = 0;

    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 2, "Series 2");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, ChartType.ClusteredColumn);

    series.getParentSeriesGroup().setOverlap((byte)-25);
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 2, 2.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 2, 4.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 2, 1.8));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 2, 2.8));
}

static void addThirdSeriesToChart(IChart chart) {
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    final int worksheetIndex = 0;

    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Series 3");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, ChartType.Line);

    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 1, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 2, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 3, 3, 3.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 4, 3, 5.0));

    series.setPlotOnSecondAxis(true);
}

static void setPrimaryAxesFormat(IChart chart) {
    // Horizontale Achse setzen.
    IAxis horizontalAxis = chart.getAxes().getHorizontalAxis();
    horizontalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
    horizontalAxis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    setAxisTitle(horizontalAxis, "X Axis");

    // Vertikale Achse setzen.
    IAxis verticalAxis = chart.getAxes().getVerticalAxis();
    verticalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
    verticalAxis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    setAxisTitle(verticalAxis, "Y Axis 1");

    // Farbe der vertikalen Hauptgitterlinien setzen.
    ILineFillFormat majorGridLinesFormat = verticalAxis.getMajorGridLinesFormat().getLine().getFillFormat();
    majorGridLinesFormat.setFillType(FillType.Solid);
    majorGridLinesFormat.getSolidFillColor().setColor(new Color(217, 217, 217));
}

static void setSecondaryAxesFormat(IChart chart) {
    // Sekundäre horizontale Achse setzen.
    IAxis secondaryHorizontalAxis = chart.getAxes().getSecondaryHorizontalAxis();
    secondaryHorizontalAxis.setPosition(AxisPositionType.Bottom);
    secondaryHorizontalAxis.setCrossType(CrossesType.Maximum);
    secondaryHorizontalAxis.setVisible(false);
    secondaryHorizontalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    secondaryHorizontalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    // Sekundäre vertikale Achse setzen.
    IAxis secondaryVerticalAxis = chart.getAxes().getSecondaryVerticalAxis();
    secondaryVerticalAxis.setPosition(AxisPositionType.Right);
    secondaryVerticalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
    secondaryVerticalAxis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    secondaryVerticalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    secondaryVerticalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    setAxisTitle(secondaryVerticalAxis, "Y Axis 2");
}

static void setAxisTitle(IAxis axis, String axisTitle) {
    axis.setTitle(true);
    axis.getTitle().setOverlay(false);
    IParagraph titleParagraph = axis.getTitle().addTextFrameForOverriding(axisTitle).getParagraphs().get_Item(0);
    IPortionFormat titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(NullableBool.False);
    titleFormat.setFontHeight(12f);
}
```

## **Diagramme aktualisieren**

<a name="java-update-powerpoint-chart" id="java-update-powerpoint-chart"><strong><em>Schritte:</em> PowerPoint‑Diagramm in Java aktualisieren</strong></a> |
<a name="java-update-presentation-chart" id="java-update-presentation-chart"><strong><em>Schritte:</em> Präsentations‑Diagramm in Java aktualisieren</strong></a> |
<a name="java-update-powerpoint-presentation-chart" id="java-update-powerpoint-presentation-chart"><strong><em>Schritte:</em> PowerPoint‑Präsentations‑Diagramm in Java aktualisieren</strong></a>

1. Instanziieren Sie eine [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation)‑Klasse, die die Präsentation mit dem zu aktualisierenden Diagramm darstellt.
2. Rufen Sie die Referenz einer Folie über ihren Index ab.
3. Durchlaufen Sie alle Formen, um das gewünschte Diagramm zu finden.
4. Greifen Sie auf das Diagramm‑Daten‑Worksheet zu.
5. Ändern Sie die Daten der Diagrammreihen, indem Sie Reihenwerte anpassen.
6. Fügen Sie eine neue Reihe hinzu und befüllen Sie die Daten.
7. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser Java‑Code zeigt, wie Sie ein Diagramm aktualisieren:

```java
import com.aspose.slides.*;

// Öffnet die Präsentation, die das zu aktualisierende Diagramm enthält
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // Erste Folie zugreifen
    ISlide sld = pres.getSlides().get_Item(0);

    // Das Diagramm von der Folie holen
    IChart chart = (IChart)sld.getShapes().get_Item(0);

    // Index des Diagrammdatenblatts festlegen
    int defaultWorksheetIndex = 0;

    // Das Diagrammdaten-Worksheet holen
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // Diagramm-Kategorienamen ändern
    fact.getCell(defaultWorksheetIndex, 1, 0, "Modified Category 1");
    fact.getCell(defaultWorksheetIndex, 2, 0, "Modified Category 2");

    // Erste Diagrammreihe holen
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    // Jetzt werden die Reihen‑Daten aktualisiert
    fact.getCell(defaultWorksheetIndex, 0, 1, "New_Series1"); // Seriennamen ändern
    series.getDataPoints().get_Item(0).getValue().setData(90);
    series.getDataPoints().get_Item(1).getValue().setData(123);
    series.getDataPoints().get_Item(2).getValue().setData(44);

    // Zweite Diagrammreihe holen
    series = chart.getChartData().getSeries().get_Item(1);

    // Jetzt werden die Reihen‑Daten aktualisiert
    fact.getCell(defaultWorksheetIndex, 0, 2, "New_Series2"); // Seriennamen ändern
    series.getDataPoints().get_Item(0).getValue().setData(23);
    series.getDataPoints().get_Item(1).getValue().setData(67);
    series.getDataPoints().get_Item(2).getValue().setData(99);

    // Jetzt eine neue Reihe hinzufügen
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "Series 3"), chart.getType());

    // Dritte Diagrammreihe holen
    series = chart.getChartData().getSeries().get_Item(2);

    // Jetzt die Daten der Reihe füllen
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 3, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 30));

    chart.setType(ChartType.ClusteredCylinder);

    // Präsentation mit Diagramm speichern
    pres.save("AsposeChartModified_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Datenbereich für ein Diagramm festlegen**

Um den Datenbereich für ein Diagramm festzulegen, gehen Sie wie folgt vor:

1. Instanziieren Sie eine [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation)‑Klasse, die die Präsentation mit dem Diagramm darstellt.
2. Rufen Sie die Referenz einer Folie über ihren Index ab.
3. Durchlaufen Sie alle Formen, um das gewünschte Diagramm zu finden.
4. Greifen Sie auf die Diagrammdaten zu und setzen Sie den Bereich.
5. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser Java‑Code zeigt, wie Sie den Datenbereich für ein Diagramm festlegen:

```java
import com.aspose.slides.*;

// Öffnet die Präsentation, die das Diagramm enthält
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = (IChart)slide.getShapes().get_Item(0);
    
    chart.getChartData().setRange("Sheet1!A1:B4");
    
    pres.save("SetDataRange_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Standard‑Marker in Diagrammen verwenden**

Wenn Sie einen Standard‑Marker in Diagrammen verwenden, erhält jede Diagrammreihe automatisch ein unterschiedliches Standard‑Marker‑Symbol.

Dieser Java‑Code zeigt, wie Sie einen Diagrammreihen‑Marker automatisch festlegen:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 10, 10, 400, 400);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "C1"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 1, 1, 24));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "C2"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 2, 1, 23));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "C3"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 3, 1, -10));
    chart.getChartData().getCategories().add(fact.getCell(0, 4, 0, "C4"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 4, 1, null));

    chart.getChartData().getSeries().add(fact.getCell(0, 0, 2, "Series 2"), chart.getType());
    // Zweite Diagrammreihe holen
    IChartSeries series2 = chart.getChartData().getSeries().get_Item(1);

    // Jetzt werden die Daten der Reihe befüllt
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 1, 2, 30));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 2, 2, 10));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 3, 2, 60));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 4, 2, 40));

    chart.setLegend(true);
    chart.getLegend().setOverlay(false);

    pres.save("DefaultMarkersInChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

### Welche Diagrammtypen werden von Aspose.Slides unterstützt?

Aspose.Slides unterstützt eine Vielzahl von [Diagrammtypen](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/charttype/), darunter Balken, Linien, Kreis, Flächen, Scatter, Histogramm, Radar und viele mehr. Diese Flexibilität ermöglicht es Ihnen, den am besten geeigneten Diagrammtyp für Ihre Datenvisualisierung auszuwählen.

### Wie füge ich ein neues Diagramm zu einer Folie hinzu?

Um ein Diagramm hinzuzufügen, erstellen Sie zunächst eine Instanz der [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/)‑Klasse, rufen die gewünschte Folie über deren Index ab und rufen dann die Methode zum Hinzufügen eines Diagramms auf, wobei Sie den Diagrammtyp und die Anfangsdaten angeben. Dieser Vorgang integriert das Diagramm direkt in Ihre Präsentation.

### Wie kann ich die in einem Diagramm angezeigten Daten aktualisieren?

Sie können die Daten eines Diagramms aktualisieren, indem Sie auf dessen Daten‑Workbook ([IChartDataWorkbook](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartdataworkbook/)) zugreifen, alle Standard‑Reihen und -Kategorien löschen und dann Ihre eigenen Daten hinzufügen. So können Sie das Diagramm aktualisieren, um die neuesten Daten widerzuspiegeln.

### Ist es möglich, das Aussehen des Diagramms anzupassen?

Ja, Aspose.Slides bietet umfangreiche Anpassungsoptionen. Sie können Farben, Schriftarten, Beschriftungen, Legenden und andere [Formatierungselemente](/slides/de/androidjava/chart-entities/) ändern, um das Aussehen des Diagramms an Ihre spezifischen Designanforderungen anzupassen.