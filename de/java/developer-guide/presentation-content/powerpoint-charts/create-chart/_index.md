---
title: Erstellen oder Aktualisieren von PowerPoint-Präsentationsdiagrammen in Java
linktitle: Diagramme erstellen oder aktualisieren
type: docs
weight: 10
url: /de/java/create-chart/
keywords:
- Diagramm hinzufügen
- Diagramm erstellen
- Diagramm bearbeiten
- Diagramm ändern
- Diagramm aktualisieren
- Streudiagramm
- Kreisdiagramm
- Liniendiagramm
- Baumkarten-Diagramm
- Aktienchart
- Box‑Und‑Whisker‑Diagramm
- Trichterdiagramm
- Sunburst‑Diagramm
- Histogramm-Diagramm
- Radar‑Diagramm
- Mehrkategorie‑Diagramm
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Erstellen und Anpassen von Diagrammen in PowerPoint-Präsentationen mit Aspose.Slides für Java. Diagramme hinzufügen, formatieren und bearbeiten mit praktischen Codebeispielen in Java."
---
## **Übersicht**

Dieser Artikel bietet eine umfassende Anleitung, wie man Diagramme mit Aspose.Slides erstellt und anpasst. Sie lernen, wie man programmgesteuert ein Diagramm zu einer Folie hinzufügt, es mit Daten befüllt und verschiedene Formatierungsoptionen anwendet, um Ihren spezifischen Designanforderungen zu entsprechen. Im gesamten Artikel veranschaulichen detaillierte Codebeispiele jeden Schritt, von der Initialisierung der Präsentation und des Diagrammobjekts bis zur Konfiguration von Serien, Achsen und Legenden. Wenn Sie dieser Anleitung folgen, erhalten Sie ein fundiertes Verständnis dafür, wie Sie die dynamische Diagrammerstellung in Ihre Anwendungen integrieren und den Prozess der Erstellung datenbasierter Präsentationen optimieren.

## **Diagramm erstellen**

Diagramme helfen, Daten schnell zu visualisieren und Erkenntnisse zu gewinnen, die aus einer Tabelle oder Kalkulationstabelle nicht sofort ersichtlich sind.

**Warum Diagramme erstellen?**

- große Datenmengen auf einer einzelnen Folie einer Präsentation aggregieren, verdichten oder zusammenfassen  
- Muster und Trends in den Daten aufzeigen  
- die Richtung und das Momentum der Daten im Zeitverlauf oder bezogen auf eine bestimmte Maßeinheit ableiten  
- Ausreißer, Aberrationen, Abweichungen, Fehler, unsinnige Daten usw. erkennen  
- komplexe Daten kommunizieren oder präsentieren  

In PowerPoint können Sie Diagramme über die *Einfügen*-Funktion erstellen, die Vorlagen für die Gestaltung vieler Diagrammtypen bereitstellt. Mit Aspose.Slides können Sie sowohl reguläre Diagramme (basierend auf gängigen Diagrammtypen) als auch benutzerdefinierte Diagramme erstellen.

{{% alert color="info" title="Note" %}}
Um Diagramme zu erstellen, verwenden Sie die Klasse [ChartType](https://reference.aspose.com/slides/de/java/com.aspose.slides/charttype/). Die Felder in dieser Klasse entsprechen verschiedenen Diagrammtypen.
{{% /alert %}}

### **Erstellen von gruppierten Säulendiagrammen**

Dieser Abschnitt erklärt, wie man gruppierte Säulendiagramme mit Aspose.Slides erstellt. Sie lernen, eine Präsentation zu initialisieren, ein Diagramm hinzuzufügen und dessen Elemente wie Titel, Daten, Serien, Kategorien und Styling anzupassen. Folgen Sie den untenstehenden Schritten, um zu sehen, wie ein standardmäßiges gruppiertes Säulendiagramm erzeugt wird:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation).
2. Holen Sie eine Referenz zu einer Folie über deren Index.
3. Fügen Sie ein Diagramm mit einigen Daten hinzu und geben Sie den Typ `ChartType.ClusteredColumn` an.
4. Fügen Sie dem Diagramm einen Titel hinzu.
5. Greifen Sie auf das Datenarbeitsblatt des Diagramms zu.
6. Löschen Sie alle Standardserien und -kategorien.
7. Fügen Sie neue Serien und Kategorien hinzu.
8. Fügen Sie neue Diagrammdaten für die Diagrammserien hinzu.
9. Wenden Sie eine Füllfarbe auf die Diagrammserien an.
10. Fügen Sie der Diagrammserie Beschriftungen hinzu.
11. Speichern Sie die modifizierte Präsentation als PPTX-Datei.

This C# code demonstrates how to create a clustered column chart:

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
    
    // Liest das Diagrammdaten-Arbeitsblatt
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Löscht die standardmäßig erzeugten Serien und Kategorien
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    int s = chart.getChartData().getSeries().size();
    s = chart.getChartData().getCategories().size();
    
    // Fügt neue Serien hinzu
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"),chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"),chart.getType());
    
    // Fügt neue Kategorien hinzu
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // Nimmt die erste Diagrammserie
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // Füllt nun die Seriendaten
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // Setzt die Füllfarbe für die Serie
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    
    // Nimmt die zweite Diagrammserie
    series = chart.getChartData().getSeries().get_Item(1);
    
    // Füllt die Seriendaten
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // Setzt die Füllfarbe für die Serie
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.GREEN);
    
    //Erstellt benutzerdefinierte Beschriftungen für jede Kategorie der neuen Serie
    // Setzt die erste Beschriftung, um den Kategorienamen anzuzeigen
    IDataLabel lbl = series.getDataPoints().get_Item(0).getLabel();
    lbl.getDataLabelFormat().setShowCategoryName(true);
    
    lbl = series.getDataPoints().get_Item(1).getLabel();
    lbl.getDataLabelFormat().setShowSeriesName(true);
    
    // Zeigt den Wert für die dritte Beschriftung
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

Streudiagramme (auch als Scatterplots oder x‑y‑Diagramme bezeichnet) werden häufig verwendet, um Muster zu prüfen oder Korrelationen zwischen zwei Variablen darzustellen.

Verwenden Sie ein Streudiagramm, wenn:

- Sie über numerische Datenpaare verfügen  
- Sie zwei gut zusammenpassende Variablen haben  
- Sie feststellen möchten, ob zwei Variablen miteinander verbunden sind  
- Sie eine unabhängige Variable besitzen, die mehrere Werte für eine abhängige Variable hat  

1. Befolgen Sie die Schritte in [Erstellen von gruppierten Säulendiagrammen](#create-clustered-column-charts).  
2. Für den dritten Schritt fügen Sie ein Diagramm mit einigen Daten hinzu und geben Ihren Diagrammtyp wie folgt an:  
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/de/java/com.aspose.slides/charttype/#ScatterWithMarkers) - _Stellt ein Streudiagramm dar._  
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/de/java/com.aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Stellt ein Streudiagramm dar, das durch Kurven verbunden ist und Datenmarker enthält._  
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/de/java/com.aspose.slides/charttype/#ScatterWithSmoothLines) - _Stellt ein Streudiagramm dar, das durch Kurven verbunden ist, jedoch keine Datenmarker enthält._  
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/de/java/com.aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Stellt ein Streudiagramm dar, das durch Linien verbunden ist und Datenmarker enthält._  
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/de/java/com.aspose.slides/charttype/#ScatterWithStraightLines) - _Stellt ein Streudiagramm dar, das durch Linien verbunden ist, jedoch keine Datenmarker enthält._

This Java code shows how to create a scatter chart with different markers for each series:

```java
import com.aspose.slides.*;

// Instanziert eine Präsentationsklasse, die eine PPTX-Datei darstellt
Presentation pres = new Presentation();
try {
    // Greift auf die erste Folie zu
    ISlide slide = pres.getSlides().get_Item(0);

    // Erstellt das Standarddiagramm
    IChart chart = slide.getShapes().addChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);
    
    // Ermittelt den Index des Standard‑Datenarbeitsblatts des Diagramms
    int defaultWorksheetIndex = 0;
    
    // Ermittelt das Diagramm‑Datenarbeitsblatt
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Löscht die Demo‑Serie
    chart.getChartData().getSeries().clear();
    
    // Fügt neue Serien hinzu
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.getType());
    
    // Nimmt die erste Diagrammserie
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // Fügt der Serie einen neuen Punkt (1:3) hinzu
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 1), fact.getCell(defaultWorksheetIndex, 2, 2, 3));
    
    // Fügt einen neuen Punkt (2:10) hinzu
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 2), fact.getCell(defaultWorksheetIndex, 3, 2, 10));
    
    // Ändert den Seriotyp
    series.setType(ChartType.ScatterWithStraightLinesAndMarkers);
    
    // Ändert den Diagrammserien‑Marker
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(MarkerStyleType.Star);
    
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
    
    // Ändert den Diagrammserien‑Marker
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(MarkerStyleType.Circle);
    
    pres.save("AsposeChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Erstellen von Kreisdiagrammen**

Kreisdiagramme eignen sich am besten, um das Verhältnis von Teil zu Ganzem in Daten darzustellen, besonders wenn die Daten kategoriale Beschriftungen mit numerischen Werten enthalten. Wenn Ihre Daten jedoch viele Teile oder Beschriftungen enthalten, sollten Sie stattdessen ein Balkendiagramm in Betracht ziehen.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/).
2. Holen Sie eine Referenz zu einer Folie über deren Index.
3. Fügen Sie ein Diagramm mit Standarddaten hinzu und geben Sie den Typ [ChartType.Pie](https://reference.aspose.com/slides/de/java/com.aspose.slides/charttype/#Pie) an.
4. Greifen Sie auf die Diagrammdaten‑Arbeitsmappe [IChartDataWorkbook](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichartdataworkbook/) zu.
5. Löschen Sie die Standardserien und -kategorien.
6. Fügen Sie neue Serien und Kategorien hinzu.
7. Fügen Sie neue Diagrammdaten für die Diagrammserien hinzu.
8. Fügen Sie neue Punkte zum Diagramm hinzu und wenden Sie benutzerdefinierte Farben für die Segmente des Kreisdiagramms an.
9. Setzen Sie Beschriftungen für die Serien.
10. Aktivieren Sie Führungslinien für die Serienbeschriftungen.
11. Legen Sie den Rotationswinkel für die Segmente des Kreisdiagramms fest.
12. Speichern Sie die modifizierte Präsentation als PPTX-Datei.

This Java code shows how to create a pie chart:

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
    
    // Ermittelt das Diagrammdaten-Arbeitsblatt
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Löscht die standardmäßig erzeugten Serien und Kategorien
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    
    // Fügt neue Kategorien hinzu
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    
    // Fügt neue Serien hinzu
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    
    // Befüllt die Seriendaten
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // Nicht funktionierend in neuer Version
    // Adding new points and setting sector color
    // series.IsColorVaried = true;
    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(true);
    
    IChartDataPoint point = series.getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(FillType.Solid);
    point.getFormat().getFill().getSolidFillColor().setColor(Color.CYAN);
    
    // Setzt den Sektorrand
    point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    point.getFormat().getLine().setWidth(3.0);
    point.getFormat().getLine().setStyle(LineStyle.ThinThick);
    point.getFormat().getLine().setDashStyle(LineDashStyle.DashDot);
    
    IChartDataPoint point1 = series.getDataPoints().get_Item(1);
    point1.getFormat().getFill().setFillType(FillType.Solid);
    point1.getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE);
    
    // Setzt den Sektorrand
    point1.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point1.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    point1.getFormat().getLine().setWidth(3.0);
    point1.getFormat().getLine().setStyle(LineStyle.Single);
    point1.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDot);
    
    IChartDataPoint point2 = series.getDataPoints().get_Item(2);
    point2.getFormat().getFill().setFillType(FillType.Solid);
    point2.getFormat().getFill().getSolidFillColor().setColor(Color.YELLOW);
    
    // Setzt den Sektorrand
    point2.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point2.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    point2.getFormat().getLine().setWidth(2.0);
    point2.getFormat().getLine().setStyle(LineStyle.ThinThin);
    point2.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDotDot);
    
    // Erstellt benutzerdefinierte Beschriftungen für jede Kategorie der neuen Serie
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

Liniendiagramme (auch als Liniendiagramme bezeichnet) eignen sich am besten für Situationen, in denen Sie Wertänderungen im Zeitverlauf darstellen möchten. Mit einem Liniendiagramm können Sie eine große Menge an Daten gleichzeitig vergleichen, Änderungen und Trends im Zeitverlauf verfolgen, Anomalien in Datenserien hervorheben und vieles mehr.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation).
2. Holen Sie eine Referenz zu einer Folie über deren Index.
3. Fügen Sie ein Diagramm mit Standarddaten hinzu und geben Sie den Typ [ChartType.Line](https://reference.aspose.com/slides/de/java/com.aspose.slides/charttype/#Line) an.
4. Speichern Sie die modifizierte Präsentation als PPTX-Datei.

This Java code shows how to create a line chart:

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

Standardmäßig werden die Punkte eines Liniendiagramms durch gerade kontinuierliche Linien verbunden. Wenn Sie die Punkte stattdessen durch Striche verbinden möchten, können Sie den gewünschten Strichtyp wie folgt angeben:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart lineChart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350);

    for (IChartSeries series : lineChart.getChartData().getSeries())
    {
        series.getFormat().getLine().setDashStyle(LineDashStyle.Dash);
    }

    pres.save("lineChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Erstellen von Baumkarten**

Baumkarten sind besonders geeignet für Verkaufsdaten, wenn Sie die relative Größe von Datenkategorien anzeigen und schnell die großen Beitragsleistenden innerhalb jeder Kategorie hervorheben möchten.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation).
2. Holen Sie eine Referenz zu einer Folie über deren Index.
3. Fügen Sie ein Diagramm mit Standarddaten hinzu und geben Sie den Typ [ChartType.Treemap](https://reference.aspose.com/slides/de/java/com.aspose.slides/charttype/#Treemap) an.
4. Greifen Sie auf die Diagrammdaten‑Arbeitsmappe [IChartDataWorkbook](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichartdataworkbook/) zu.
5. Löschen Sie die Standardserien und -kategorien.
6. Fügen Sie neue Serien und Kategorien hinzu.
7. Fügen Sie neue Diagrammdaten für die Diagrammserien hinzu.
8. Speichern Sie die modifizierte Präsentation als PPTX-Datei.

This Java code shows how to create a tree map chart:

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

### **Erstellen von Aktiencharts**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation).
2. Holen Sie eine Referenz zu einer Folie über deren Index.
3. Fügen Sie ein Diagramm mit Standarddaten hinzu und geben Sie den Typ [ChartType.OpenHighLowClose](https://reference.aspose.com/slides/de/java/com.aspose.slides/charttype/#OpenHighLowClose) an.
4. Greifen Sie auf die Diagrammdaten‑Arbeitsmappe [IChartDataWorkbook](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichartdataworkbook/) zu.
5. Löschen Sie die Standardserien und -kategorien.
6. Fügen Sie neue Serien und Kategorien hinzu.
7. Fügen Sie neue Diagrammdaten für die Diagrammserien hinzu.
8. Geben Sie das Format der Hoch‑Niedrig‑Linien an.
9. Speichern Sie die modifizierte Präsentation als PPTX-Datei.

This Java code shows how to create a stock chart:

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

### **Erstellen von Box‑Und‑Whisker‑Diagrammen**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation).
2. Holen Sie eine Referenz zu einer Folie über deren Index.
3. Fügen Sie ein Diagramm mit Standarddaten hinzu und geben Sie den Typ [ChartType.BoxAndWhisker](https://reference.aspose.com/slides/de/java/com.aspose.slides/charttype/#BoxAndWhisker) an.
4. Greifen Sie auf die Diagrammdaten‑Arbeitsmappe [IChartDataWorkbook](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichartdataworkbook/) zu.
5. Löschen Sie die Standardserien und -kategorien.
6. Fügen Sie neue Serien und Kategorien hinzu.
7. Fügen Sie neue Diagrammdaten für die Diagrammserien hinzu.
8. Speichern Sie die modifizierte Präsentation als PPTX-Datei.

This Java code shows how to create a box and whisker chart:

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

### **Erstellen von Trichterdiagrammen**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation).
2. Holen Sie eine Referenz zu einer Folie über deren Index.
3. Fügen Sie ein Diagramm mit Standarddaten hinzu und geben Sie den Typ [ChartType.Funnel](https://reference.aspose.com/slides/de/java/com.aspose.slides/charttype/#Funnel) an.
4. Speichern Sie die modifizierte Präsentation als PPTX-Datei.

This Java code shows how to create a funnel chart:

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

### **Erstellen von Sunburst‑Diagrammen**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation).
2. Holen Sie eine Referenz zu einer Folie über deren Index.
3. Fügen Sie ein Diagramm mit Standarddaten hinzu und geben Sie den Typ [ChartType.Sunburst](https://reference.aspose.com/slides/de/java/com.aspose.slides/charttype/#Sunburst) an.
4. Speichern Sie die modifizierte Präsentation als PPTX-Datei.

This Java code shows how to create a sunburst chart:

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

### **Erstellen von Histogrammdiagrammen**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation).
2. Holen Sie eine Referenz zu einer Folie über deren Index.
3. Fügen Sie ein Diagramm mit Standarddaten hinzu und geben Sie den Typ [ChartType.Histogram](https://reference.aspose.com/slides/de/java/com.aspose.slides/charttype/#Histogram) an.
4. Greifen Sie auf die Diagrammdaten‑Arbeitsmappe [IChartDataWorkbook](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichartdataworkbook/) zu.
5. Löschen Sie die Standardserien und -kategorien.
6. Fügen Sie neue Serien und Kategorien hinzu.
7. Speichern Sie die modifizierte Präsentation als PPTX-Datei.

This Java code shows how to create a histogram chart:

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

### **Erstellen von Radar‑Diagrammen**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation).
2. Holen Sie eine Referenz zu einer Folie über deren Index.
3. Fügen Sie ein Diagramm mit einigen Daten hinzu und geben Sie Ihren bevorzugten Diagrammtyp ([ChartType.Radar](https://reference.aspose.com/slides/de/java/com.aspose.slides/charttype/#Radar)) an.
4. Speichern Sie die modifizierte Präsentation als PPTX-Datei.

This Java code shows how to create a radar chart:

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

### **Erstellen von Mehrkategorie‑Diagrammen**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation).
2. Holen Sie eine Referenz zu einer Folie über deren Index.
3. Fügen Sie ein Diagramm mit Standarddaten hinzu und geben Sie den Typ [ChartType.ClusteredColumn](https://reference.aspose.com/slides/de/java/com.aspose.slides/charttype/#ClusteredColumn) an.
4. Greifen Sie auf die Diagrammdaten‑Arbeitsmappe [IChartDataWorkbook](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichartdataworkbook/) zu.
5. Löschen Sie die Standardserien und -kategorien.
6. Fügen Sie neue Serien und Kategorien hinzu.
7. Fügen Sie neue Diagrammdaten für die Diagrammserien hinzu.
8. Speichern Sie die modifizierte Präsentation als PPTX-Datei.

This Java code shows how to create a multicategory chart:

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

### **Erstellen von Karten‑Diagrammen**

Karten‑Diagramme visualisieren geografische Daten und helfen, Werte über Regionen hinweg zu vergleichen.

This Java code shows how to create a map chart:

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

### **Erstellen von Kombinationsdiagrammen**

Ein Kombinationsdiagramm (oder Combo‑Diagramm) kombiniert zwei oder mehr Diagrammtypen in einem einzigen Diagramm. Dieses Diagramm ermöglicht es Ihnen, Unterschiede zwischen zwei oder mehr Datensätzen hervorzuheben, zu vergleichen oder zu untersuchen und dadurch Beziehungen zwischen ihnen zu erkennen.

![The combination chart](combination_chart.png)

Der folgende Java‑Code zeigt, wie das oben gezeigte Kombinationsdiagramm in einer PowerPoint‑Präsentation erstellt wird:

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

    // Setzt den Diagrammtitel.
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Chart Title");
    chart.getChartTitle().setOverlay(false);
    IParagraph titleParagraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0);
    IPortionFormat titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(NullableBool.False);
    titleFormat.setFontHeight(18f);

    // Setzt die Diagrammlegende.
    chart.getLegend().setPosition(LegendPositionType.Bottom);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12f);

    // Löscht die standardmäßig erzeugten Serien und Kategorien.
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    int worksheetIndex = 0;
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    // Fügt neue Kategorien hinzu.
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 3, 0, "Category 3"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 4, 0, "Category 4"));

    // Fügt die erste Serie hinzu.
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
    // Setzt die horizontale Achse.
    IAxis horizontalAxis = chart.getAxes().getHorizontalAxis();
    horizontalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
    horizontalAxis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    setAxisTitle(horizontalAxis, "X Axis");

    // Setzt die vertikale Achse.
    IAxis verticalAxis = chart.getAxes().getVerticalAxis();
    verticalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
    verticalAxis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    setAxisTitle(verticalAxis, "Y Axis 1");

    // Setzt die Farbe der vertikalen Hauptgitternetzlinien.
    ILineFillFormat majorGridLinesFormat = verticalAxis.getMajorGridLinesFormat().getLine().getFillFormat();
    majorGridLinesFormat.setFillType(FillType.Solid);
    majorGridLinesFormat.getSolidFillColor().setColor(new Color(217, 217, 217));
}

static void setSecondaryAxesFormat(IChart chart) {
    // Setzt die sekundäre horizontale Achse.
    IAxis secondaryHorizontalAxis = chart.getAxes().getSecondaryHorizontalAxis();
    secondaryHorizontalAxis.setPosition(AxisPositionType.Bottom);
    secondaryHorizontalAxis.setCrossType(CrossesType.Maximum);
    secondaryHorizontalAxis.setVisible(false);
    secondaryHorizontalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    secondaryHorizontalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    // Setzt die sekundäre vertikale Achse.
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

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/) , die die Präsentation enthält, deren Diagramm Sie aktualisieren möchten.
2. Holen Sie eine Referenz zu einer Folie über deren Index.
3. Durchlaufen Sie alle Formen, um das gewünschte Diagramm zu finden.
4. Greifen Sie auf das Datenarbeitsblatt des Diagramms zu.
5. Ändern Sie die Diagrammserien, indem Sie die Serienwerte anpassen.
6. Fügen Sie eine neue Serie hinzu und befüllen Sie deren Daten.
7. Speichern Sie die modifizierte Präsentation als PPTX-Datei.

This Java code shows how to update a chart:

```java
import com.aspose.slides.*;

// Öffnet die Präsentation, die das zu aktualisierende Diagramm enthält
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // Greift auf die erste Folie zu
    ISlide sld = pres.getSlides().get_Item(0);

    // Holt das Diagramm von der Folie
    IChart chart = (IChart)sld.getShapes().get_Item(0);

    // Setzt den Index des Diagrammdatenblatts
    int defaultWorksheetIndex = 0;

    // Liest das Diagrammdaten‑Arbeitsblatt
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // Ändert den Diagramm‑Kategorienamen
    fact.getCell(defaultWorksheetIndex, 1, 0, "Modified Category 1");
    fact.getCell(defaultWorksheetIndex, 2, 0, "Modified Category 2");

    // Nimmt die erste Diagrammserie
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    // Aktualisiert jetzt die Seriendaten
    fact.getCell(defaultWorksheetIndex, 0, 1, "New_Series1");// Seriennamen wird geändert
    series.getDataPoints().get_Item(0).getValue().setData(90);
    series.getDataPoints().get_Item(1).getValue().setData(123);
    series.getDataPoints().get_Item(2).getValue().setData(44);

    // Nimmt die zweite Diagrammserie
    series = chart.getChartData().getSeries().get_Item(1);

    // Aktualisiert jetzt die Seriendaten
    fact.getCell(defaultWorksheetIndex, 0, 2, "New_Series2");// Seriennamen wird geändert
    series.getDataPoints().get_Item(0).getValue().setData(23);
    series.getDataPoints().get_Item(1).getValue().setData(67);
    series.getDataPoints().get_Item(2).getValue().setData(99);

    // Jetzt wird eine neue Serie hinzugefügt
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "Series 3"), chart.getType());

    // Nimmt die dritte Diagrammserie
    series = chart.getChartData().getSeries().get_Item(2);

    // Füllt jetzt die Seriendaten
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

## **Datenbereich für ein Diagramm festlegen**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/) , die die Präsentation enthält, deren Diagramm Sie bearbeiten möchten.
2. Holen Sie eine Referenz zu einer Folie über deren Index.
3. Durchlaufen Sie alle Formen, um das gewünschte Diagramm zu finden.
4. Greifen Sie auf die Diagrammdaten zu und setzen Sie den Bereich.
5. Speichern Sie die modifizierte Präsentation als PPTX-Datei.

This Java code shows how to set the data range for a chart:

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

Wenn Sie Standard‑Marker in Diagrammen verwenden, erhält jede Diagrammserie automatisch ein anderes Markersymbol.

This Java code shows how to set a chart series marker automatically:

```java
import com.aspose.slides.*;

// Öffnet die Präsentation, die das Diagramm enthält
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
//Nimmt die zweite Diagrammserie
    IChartSeries series2 = chart.getChartData().getSeries().get_Item(1);

//Jetzt werden die Seriendaten befüllt
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

**Welche Diagrammtypen werden von Aspose.Slides unterstützt?**

Aspose.Slides unterstützt eine breite Palette von [Diagrammtypen](https://reference.aspose.com/slides/de/java/com.aspose.slides/charttype/), einschließlich Balken, Linien, Kreis, Fläche, Streu, Histogramm, Radar und vielen mehr. Diese Flexibilität ermöglicht es Ihnen, den am besten geeigneten Diagrammtyp für Ihre Datenvisualisierungsanforderungen auszuwählen.

**Wie füge ich einer Folie ein neues Diagramm hinzu?**

Um ein Diagramm hinzuzufügen, erstellen Sie zunächst eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/) , rufen die gewünschte Folie über deren Index ab und rufen dann die Methode zum Hinzufügen eines Diagramms auf, wobei Sie den Diagrammtyp und die Anfangsdaten angeben. Dieser Vorgang integriert das Diagramm direkt in Ihre Präsentation.

**Wie kann ich die in einem Diagramm angezeigten Daten aktualisieren?**

Sie können die Daten eines Diagramms aktualisieren, indem Sie auf dessen Datenarbeitsmappe ([IChartDataWorkbook](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichartdataworkbook/)) zugreifen, alle Standardserien und -kategorien löschen und anschließend Ihre eigenen Daten hinzufügen. So können Sie das Diagramm aktualisieren, um die neuesten Daten widerzuspiegeln.

**Ist es möglich, das Aussehen des Diagramms anzupassen?**

Ja, Aspose.Slides bietet umfangreiche Anpassungsoptionen. Sie können Farben, Schriftarten, Beschriftungen, Legenden und andere [Formatierungselemente](/slides/de/java/chart-entities/) ändern, um das Aussehen des Diagramms an Ihre spezifischen Designanforderungen anzupassen.