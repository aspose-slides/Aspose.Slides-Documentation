---
title: Erstellen oder Aktualisieren von PowerPoint-Präsentationsdiagrammen in JavaScript
linktitle: Diagramme erstellen oder aktualisieren
type: docs
weight: 10
url: /de/nodejs-java/create-chart/
keywords:
- Diagramm hinzufügen
- Diagramm erstellen
- Diagramm bearbeiten
- Diagramm ändern
- Diagramm aktualisieren
- Streudiagramm
- Kreisdiagramm
- Liniendiagramm
- Baumkartendiagramm
- Börsendiagramm
- Box-und-Whisker-Diagramm
- Trichterdiagramm
- Sonnenstrahl-Diagramm
- Histogrammdiagramm
- Radardiagramm
- Mehrkategorien-Diagramm
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Erstellen und Anpassen von Diagrammen in PowerPoint‑Präsentationen mit Aspose.Slides für Node.js. Diagramme hinzufügen, formatieren und bearbeiten mit praktischen Code‑Beispielen in JavaScript."
---
## **Übersicht**

Dieser Artikel bietet eine umfassende Anleitung, wie Sie Diagramme mit Aspose.Slides erstellen und anpassen. Sie lernen, wie Sie programmgesteuert ein Diagramm zu einer Folie hinzufügen, es mit Daten füllen und verschiedene Formatierungsoptionen anwenden, um Ihren spezifischen Designanforderungen zu entsprechen. Im gesamten Artikel veranschaulichen detaillierte Codebeispiele jeden Schritt, vom Initialisieren der Präsentation und des Diagrammobjekts bis hin zur Konfiguration von Reihen, Achsen und Legenden. Wenn Sie dieser Anleitung folgen, erhalten Sie ein solides Verständnis dafür, wie Sie die dynamische Diagrammerstellung in Ihre Anwendungen integrieren und den Prozess der Erstellung datenbasierter Präsentationen rationalisieren.

## **Diagramm erstellen**

Diagramme helfen Menschen, Daten schnell zu visualisieren und Erkenntnisse zu gewinnen, die aus einer Tabelle oder einem Spreadsheet nicht sofort ersichtlich sind.

**Warum Diagramme erstellen?**

Mit Diagrammen können Sie:

* große Datenmengen auf einer einzigen Folie einer Präsentation aggregieren, kondensieren oder zusammenfassen
* Muster und Trends in Daten aufzeigen
* die Richtung und das Momentum von Daten über die Zeit oder in Bezug auf eine bestimmte Einheit ableiten
* Ausreißer, Abweichungen, Fehler, unsinnige Daten usw. erkennen
* komplexe Daten kommunizieren oder präsentieren

In PowerPoint können Sie Diagramme über die *Einfügen*-Funktion erstellen, die Vorlagen für viele Diagrammtypen bereitstellt. Mit Aspose.Slides können Sie sowohl reguläre Diagramme (basierend auf gängigen Diagrammtypen) als auch benutzerdefinierte Diagramme erstellen.

{{% alert color="info" title="Note" %}}
Um Diagramme zu erstellen, verwenden Sie die [ChartType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/charttype/)‑Klasse. Die Felder dieser Klasse entsprechen verschiedenen Diagrammtypen.
{{% /alert %}}

### **Erstellen von gruppierten Säulendiagrammen**

Dieser Abschnitt erklärt, wie Sie gruppierte Säulendiagramme mit Aspose.Slides erstellen. Sie lernen, eine Präsentation zu initialisieren, ein Diagramm hinzuzufügen und Elemente wie Titel, Daten, Reihen, Kategorien und Stil anzupassen. Folgen Sie den Schritten unten, um zu sehen, wie ein Standard‑Gruppiertes‑Säulendiagramm erzeugt wird:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation)‑Klasse.
1. Rufen Sie über den Index eine Folie ab.
1. Fügen Sie ein Diagramm mit einigen Daten hinzu und geben Sie den Typ `ChartType.ClusteredColumn` an.
1. Fügen Sie dem Diagramm einen Titel hinzu.
1. Greifen Sie auf das Daten‑Worksheet des Diagramms zu.
1. Löschen Sie alle Standard‑Reihen und -Kategorien.
1. Fügen Sie neue Reihen und Kategorien hinzu.
1. Fügen Sie neue Diagrammdaten für die Diagrammreihen hinzu.
1. Wenden Sie eine Füllfarbe auf die Diagrammreihe an.
1. Fügen Sie Beschriftungen zur Diagrammreihe hinzu.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser C#‑Code demonstriert, wie ein gruppiertes Säulendiagramm erstellt wird:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instanziiert eine Präsentationsklasse, die eine PPTX‑Datei darstellt
var pres = new aspose.slides.Presentation();
try {
    // Greift auf die erste Folie zu
    var sld = pres.getSlides().get_Item(0);
    // Fügt ein Diagramm mit Standarddaten hinzu
    var chart = sld.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 0, 0, 500, 500);
    // Setzt den Diagrammtitel
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(java.newByte(aspose.slides.NullableBool.True));
    chart.getChartTitle().setHeight(20);
    // Setzt die erste Serie so, dass Werte angezeigt werden
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // Setzt den Index für das Diagrammdatenblatt
    var defaultWorksheetIndex = 0;
    // Holt das Diagrammdaten‑Worksheet
    var fact = chart.getChartData().getChartDataWorkbook();
    // Löscht die standardmäßig erzeugten Serien und Kategorien
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
    // Befüllt jetzt die Seriendaten
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    // Setzt die Füllfarbe für die Serie
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // Nimmt die zweite Diagrammserie
    series = chart.getChartData().getSeries().get_Item(1);
    // Befüllt die Seriendaten
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    // Setzt die Füllfarbe für die Serie
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    // Erstellt benutzerdefinierte Beschriftungen für jede Kategorie der neuen Serie
    // Setzt die erste Beschriftung, um den Kategorienamen anzuzeigen
    var lbl = series.getDataPoints().get_Item(0).getLabel();
    lbl.getDataLabelFormat().setShowCategoryName(true);
    lbl = series.getDataPoints().get_Item(1).getLabel();
    lbl.getDataLabelFormat().setShowSeriesName(true);
    // Zeigt den Wert für die dritte Beschriftung an
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

### **Erstellen von Streudiagrammen**

Streudiagramme (auch Scatter‑Plots oder X‑Y‑Diagramme genannt) werden häufig verwendet, um Muster zu prüfen oder Korrelationen zwischen zwei Variablen zu zeigen.

Verwenden Sie ein Streudiagramm, wenn:

* Sie gepaarte numerische Daten haben
* Sie zwei Variablen haben, die gut zusammenpassen
* Sie feststellen möchten, ob zwei Variablen miteinander verbunden sind
* Sie eine unabhängige Variable mit mehreren Werten für eine abhängige Variable besitzen

1. Folgen Sie den Schritten in [Erstellen von gruppierten Säulendiagrammen](#erstellen-von‑gruppen‑säulendiagrammen).
2. Für den dritten Schritt fügen Sie ein Diagramm mit Daten hinzu und wählen einen der folgenden Diagrammtypen:
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/charttype/#ScatterWithMarkers) – _Streudiagramm mit Markern._
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) – _Streudiagramm, das durch Kurven verbunden ist, mit Datenmarkern._
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/charttype/#ScatterWithSmoothLines) – _Streudiagramm, das durch Kurven verbunden ist, ohne Datenmarker._
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) – _Streudiagramm, das durch gerade Linien verbunden ist, mit Datenmarkern._
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/charttype/#ScatterWithStraightLines) – _Streudiagramm, das durch gerade Linien verbunden ist, ohne Datenmarker._

Dieser JavaScript‑Code zeigt, wie ein Streudiagramm mit unterschiedlichen Markern für jede Reihe erstellt wird:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instanziiert eine Präsentationsklasse, die eine PPTX‑Datei darstellt
var pres = new aspose.slides.Presentation();
try {
    // Greift auf die erste Folie zu
    var slide = pres.getSlides().get_Item(0);
    // Erstellt das Standarddiagramm
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);
    // Holt den Index des Standard‑Diagrammdaten‑Worksheets
    var defaultWorksheetIndex = 0;
    // Holt das Diagrammdaten‑Worksheet
    var fact = chart.getChartData().getChartDataWorkbook();
    // Löscht die Demo‑Serien
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
    // Ändert den Serientyp
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

### **Erstellen von Kreisdiagrammen**

Kreisdiagramme eignen sich am besten, um das Teil‑zu‑Ganz‑Verhältnis darzustellen, insbesondere wenn die Daten kategoriale Beschriftungen mit numerischen Werten enthalten. Enthält Ihre Datenbasis jedoch viele Teile oder Beschriftungen, sollten Sie eher ein Balkendiagramm in Betracht ziehen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/)‑Klasse.
2. Rufen Sie über den Index eine Folie ab.
3. Fügen Sie ein Diagramm mit Standarddaten hinzu und geben Sie den Typ [ChartType.Pie](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/charttype/#Pie) an.
4. Greifen Sie auf das Diagramm‑Daten‑Workbook [ChartDataWorkbook](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chartdataworkbook/) zu.
5. Löschen Sie die Standard‑Reihen und -Kategorien.
6. Fügen Sie neue Reihen und Kategorien hinzu.
7. Fügen Sie neue Diagrammdaten für die Diagrammreihen hinzu.
8. Fügen Sie neue Punkte für das Diagramm hinzu und wenden Sie benutzerdefinierte Farben für die Sektoren des Kreisdiagramms an.
9. Setzen Sie Beschriftungen für die Reihen.
10. Aktivieren Sie Führungs‑Linien für die Reihen‑Beschriftungen.
11. Legen Sie den Rotationswinkel für die Sektoren des Kreisdiagramms fest.
12. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser JavaScript‑Code zeigt, wie ein Kreisdiagramm erstellt wird:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instanziert eine Präsentationsklasse, die eine PPTX-Datei darstellt
var pres = new aspose.slides.Presentation();
try {
    // Greift auf die erste Folie zu
    var slides = pres.getSlides().get_Item(0);
    // Fügt ein Diagramm mit Standarddaten hinzu
    var chart = slides.getShapes().addChart(aspose.slides.ChartType.Pie, 100, 100, 400, 400);
    // Setzt den Diagrammtitel
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(java.newByte(aspose.slides.NullableBool.True));
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    // Setzt die erste Serie, um Werte anzuzeigen
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // Setzt den Index für das Diagrammdaten-Arbeitsblatt
    var defaultWorksheetIndex = 0;
    // Holt das Diagrammdaten-Worksheet
    var fact = chart.getChartData().getChartDataWorkbook();
    // Löscht die standardmäßig erzeugten Serien und Kategorien
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    // Fügt neue Kategorien hinzu
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    // Fügt neue Serien hinzu
    var series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    // Befüllt die Seriendaten
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    // Funktioniert in der neuen Version nicht
    // Hinzufügen neuer Punkte und Festlegen der Sektor-Farbe
    // series.IsColorVaried = true;
    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(true);
    var point = series.getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));
    // Setzt die Sektor-Randlinie
    point.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    point.getFormat().getLine().setWidth(3.0);
    point.getFormat().getLine().setStyle(java.newByte(aspose.slides.LineStyle.ThinThick));
    point.getFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.DashDot));
    var point1 = series.getDataPoints().get_Item(1);
    point1.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point1.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    // Setzt die Sektor-Randlinie
    point1.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point1.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    point1.getFormat().getLine().setWidth(3.0);
    point1.getFormat().getLine().setStyle(java.newByte(aspose.slides.LineStyle.Single));
    point1.getFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.LargeDashDot));
    var point2 = series.getDataPoints().get_Item(2);
    point2.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point2.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
    // Setzt die Sektor-Randlinie
    point2.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point2.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    point2.getFormat().getLine().setWidth(2.0);
    point2.getFormat().getLine().setStyle(java.newByte(aspose.slides.LineStyle.ThinThin));
    point2.getFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.LargeDashDotDot));
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
    // Zeigt Führungs-Linien für das Diagramm an
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(true);
    // Setzt den Rotationswinkel für die Sektoren des Kreisdiagramms
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);
    // Speichert die Präsentation mit einem Diagramm
    pres.save("PieChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Erstellen von Liniendiagrammen**

Liniendiagramme (auch Liniendiagramme genannt) eignen sich besonders, wenn Sie Änderungen von Werten über die Zeit demonstrieren möchten. Mit einem Liniendiagramm können Sie große Datenmengen gleichzeitig vergleichen, Veränderungen und Trends im Zeitverlauf verfolgen, Anomalien in Datenreihen hervorheben und mehr.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/)‑Klasse.
1. Rufen Sie über den Index eine Folie ab.
1. Fügen Sie ein Diagramm mit Standarddaten hinzu und geben Sie den Typ [ChartType.Line](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/charttype/#Line) an.
1. Greifen Sie auf das Diagramm‑Daten‑Workbook ([ChartDataWorkbook](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chartdataworkbook/)) zu.
1. Löschen Sie die Standard‑Reihen und -Kategorien.
1. Fügen Sie neue Reihen und Kategorien hinzu.
1. Fügen Sie neue Diagrammdaten für die Diagrammreihen hinzu.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser JavaScript‑Code zeigt, wie ein Liniendiagramm erstellt wird:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

Standardmäßig werden Punkte in einem Liniendiagramm durch gerade, durchgehende Linien verbunden. Wenn Sie die Punkte stattdessen mit Strichen verbinden möchten, können Sie den gewünschten Strichtyp wie folgt angeben:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var pres = new aspose.slides.Presentation();
try {
    var lineChart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 10, 50, 600, 350);
    for (let i = 0; i < lineChart.getChartData().getSeries().size(); i++) {
        let series = lineChart.getChartData().getSeries().get_Item(i);
        series.getFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));
    }
    pres.save("lineChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Erstellen von Baumkartendiagrammen**

Baumkartendiagramme eignen sich besonders für Verkaufsdaten, wenn Sie die relative Größe von Datenkategorien zeigen und schnell Aufmerksamkeit auf große Beitragsleister innerhalb jeder Kategorie lenken möchten.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/)‑Klasse.
2. Rufen Sie über den Index eine Folie ab.
3. Fügen Sie ein Diagramm mit Standarddaten hinzu und geben Sie den Typ [ChartType.Treemap](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/charttype/#Treemap) an.
4. Greifen Sie auf das Diagramm‑Daten‑Workbook [ChartDataWorkbook](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chartdataworkbook/) zu.
5. Löschen Sie die Standard‑Reihen und -Kategorien.
6. Fügen Sie neue Reihen und Kategorien hinzu.
7. Fügen Sie neue Diagrammdaten für die Diagrammreihen hinzu.
8. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser JavaScript‑Code zeigt, wie ein Baumkartendiagramm erstellt wird:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

### **Erstellen von Börsendiagrammen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/)‑Klasse.
2. Rufen Sie über den Index eine Folie ab.
3. Fügen Sie ein Diagramm mit Standarddaten hinzu und geben Sie den Typ [ChartType.OpenHighLowClose](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/charttype/#OpenHighLowClose) an.
4. Greifen Sie auf das Diagramm‑Daten‑Workbook [ChartDataWorkbook](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chartdataworkbook/) zu.
5. Löschen Sie die Standard‑Reihen und -Kategorien.
6. Fügen Sie neue Reihen und Kategorien hinzu.
7. Fügen Sie neue Diagrammdaten für die Diagrammreihen hinzu.
8. Legen Sie das Format für Hoch‑Niedrig‑Linien fest.
9. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser JavaScript‑Code zeigt, wie ein Börsendiagramm erstellt wird:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.OpenHighLowClose, 50, 50, 600, 400);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
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

### **Erstellen von Box‑und‑Whisker‑Diagrammen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/)‑Klasse.
2. Rufen Sie über den Index eine Folie ab.
3. Fügen Sie ein Diagramm mit Standarddaten hinzu und geben Sie den Typ [ChartType.BoxAndWhisker](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/charttype/#BoxAndWhisker) an.
4. Greifen Sie auf das Diagramm‑Daten‑Workbook [ChartDataWorkbook](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chartdataworkbook/) zu.
5. Löschen Sie die Standard‑Reihen und -Kategorien.
6. Fügen Sie neue Reihen und Kategorien hinzu.
7. Fügen Sie neue Diagrammdaten für die Diagrammreihen hinzu.
8. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser JavaScript‑Code zeigt, wie ein Box‑und‑Whisker‑Diagramm erstellt wird:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

### **Erstellen von Trichterdiagrammen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/)‑Klasse.
2. Rufen Sie über den Index eine Folie ab.
3. Fügen Sie ein Diagramm mit Standarddaten hinzu und geben Sie den Typ [ChartType.Funnel](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/charttype/#Funnel) an.
4. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser JavaScript‑Code zeigt, wie ein Trichterdiagramm erstellt wird:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

### **Erstellen von Sonnenstrahl‑Diagrammen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/)‑Klasse.
2. Rufen Sie über den Index eine Folie ab.
3. Fügen Sie ein Diagramm mit Standarddaten hinzu und geben Sie den Typ [ChartType.Sunburst](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/charttype/#Sunburst) an.
4. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser JavaScript‑Code zeigt, wie ein Sonnenstrahl‑Diagramm erstellt wird:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

### **Erstellen von Histogrammdiagrammen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/)‑Klasse.
2. Rufen Sie über den Index eine Folie ab.
3. Fügen Sie ein Diagramm mit Standarddaten hinzu und geben Sie den Typ [ChartType.Histogram](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/charttype/#Histogram) an.
4. Greifen Sie auf das Diagramm‑Daten‑Workbook [ChartDataWorkbook](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chartdataworkbook/) zu.
5. Löschen Sie die Standard‑Reihen und -Kategorien.
6. Fügen Sie neue Reihen und Kategorien hinzu.
7. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser JavaScript‑Code zeigt, wie ein Histogrammdiagramm erstellt wird:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

### **Erstellen von Radardiagrammen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/)‑Klasse.
2. Rufen Sie über den Index eine Folie ab.
3. Fügen Sie ein Diagramm mit Daten hinzu und geben Sie Ihren bevorzugten Diagrammtyp ([ChartType.Radar](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/charttype/#Radar)) an.
4. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser JavaScript‑Code zeigt, wie ein Radardiagramm erstellt wird:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

### **Erstellen von Mehrkategorien‑Diagrammen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/)‑Klasse.
2. Rufen Sie über den Index eine Folie ab.
3. Fügen Sie ein Diagramm mit Standarddaten hinzu und geben Sie den Typ [ChartType.ClusteredColumn](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/charttype/#ClusteredColumn) an.
4. Greifen Sie auf das Diagramm‑Daten‑Workbook [ChartDataWorkbook](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chartdataworkbook/) zu.
5. Löschen Sie die Standard‑Reihen und -Kategorien.
6. Fügen Sie neue Reihen und Kategorien hinzu.
7. Fügen Sie neue Diagrammdaten für die Diagrammreihen hinzu.
8. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser JavaScript‑Code zeigt, wie ein Mehrkategorien‑Diagramm erstellt wird:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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
    // Hinzufügen von Serien
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

### **Erstellen von Kartendiagrammen**

Kartendiagramme visualisieren geografische Daten und helfen, Werte über Regionen hinweg zu vergleichen.

Dieser JavaScript‑Code zeigt, wie ein Kartendiagramm erstellt wird:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

### **Erstellen von Kombinationsdiagrammen**

Ein Kombinationsdiagramm (oder Combo‑Diagramm) kombiniert zwei oder mehr Diagrammtypen in einem einzigen Diagramm. Dieses Diagramm ermöglicht es Ihnen, Unterschiede zwischen mehreren Datensätzen hervorzuheben, zu vergleichen oder zu untersuchen und so Beziehungen zwischen ihnen zu erkennen.

![Das Kombinationsdiagramm](combination_chart.png)

Der folgende JavaScript‑Code zeigt, wie das oben dargestellte Kombinationsdiagramm in einer PowerPoint‑Präsentation erstellt wird:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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

    // Setzt den Diagrammtitel.
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Chart Title");
    chart.getChartTitle().setOverlay(false);
    let titleParagraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0);
    let titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(java.newByte(aspose.slides.NullableBool.False));
    titleFormat.setFontHeight(18);

    // Setzt die Diagrammlegende.
    chart.getLegend().setPosition(aspose.slides.LegendPositionType.Bottom);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12);

    // Löscht die standardmäßig erzeugten Serien und Kategorien.
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const worksheetIndex = 0;
    let workbook = chart.getChartData().getChartDataWorkbook();

    // Fügt neue Kategorien hinzu.
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 3, 0, "Category 3"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 4, 0, "Category 4"));

    // Fügt die erste Serie hinzu.
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
    // Setzt die horizontale Achse.
    let horizontalAxis = chart.getAxes().getHorizontalAxis();
    horizontalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    horizontalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(horizontalAxis, "X Axis");

    // Setzt die vertikale Achse.
    let verticalAxis = chart.getAxes().getVerticalAxis();
    verticalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    verticalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(verticalAxis, "Y Axis 1");

    // Setzt die Farbe der vertikalen Hauptgitterlinien.
    let majorGridLinesFormat = verticalAxis.getMajorGridLinesFormat().getLine().getFillFormat();
    majorGridLinesFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
    majorGridLinesFormat.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 217, 217, 217));
}

function setSecondaryAxesFormat(chart) {
    // Setzt die sekundäre horizontale Achse.
    let secondaryHorizontalAxis = chart.getAxes().getSecondaryHorizontalAxis();
    secondaryHorizontalAxis.setPosition(aspose.slides.AxisPositionType.Bottom);
    secondaryHorizontalAxis.setCrossType(aspose.slides.CrossesType.Maximum);
    secondaryHorizontalAxis.setVisible(false);
    secondaryHorizontalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryHorizontalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    // Setzt die sekundäre vertikale Achse.
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

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/)‑Klasse, die die zu aktualisierende Diagramm‑Präsentation darstellt.
2. Rufen Sie über den Index eine Folie ab.
3. Durchsuchen Sie alle Formen, um das gewünschte Diagramm zu finden.
4. Greifen Sie auf das Diagramm‑Daten‑Worksheet zu.
5. Ändern Sie die Werte der Diagrammdaten‑Reihen.
6. Fügen Sie eine neue Reihe hinzu und füllen Sie deren Daten.
7. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser JavaScript‑Code zeigt, wie ein Diagramm aktualisiert wird:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    // Zugriff auf die erste Folie
    var sld = pres.getSlides().get_Item(0);
    // Diagramm mit Standarddaten abrufen
    var chart = sld.getShapes().get_Item(0);
    // Festlegen des Indexes des Diagramm‑Datenblatts
    var defaultWorksheetIndex = 0;
    // Abrufen des Diagrammdaten‑Worksheets
    var fact = chart.getChartData().getChartDataWorkbook();
    // Ändern des Diagramm‑Kategorienamens
    fact.getCell(defaultWorksheetIndex, 1, 0, "Modified Category 1");
    fact.getCell(defaultWorksheetIndex, 2, 0, "Modified Category 2");
    // Erste Diagrammserie auswählen
    var series = chart.getChartData().getSeries().get_Item(0);
    // Jetzt die Seriendaten aktualisieren
    fact.getCell(defaultWorksheetIndex, 0, 1, "New_Series1"); // Seriennamen ändern
    series.getDataPoints().get_Item(0).getValue().setData(90);
    series.getDataPoints().get_Item(1).getValue().setData(123);
    series.getDataPoints().get_Item(2).getValue().setData(44);
    // Zweite Diagrammserie auswählen
    series = chart.getChartData().getSeries().get_Item(1);
    // Jetzt die Seriendaten aktualisieren
    fact.getCell(defaultWorksheetIndex, 0, 2, "New_Series2"); // Seriennamen ändern
    series.getDataPoints().get_Item(0).getValue().setData(23);
    series.getDataPoints().get_Item(1).getValue().setData(67);
    series.getDataPoints().get_Item(2).getValue().setData(99);
    // Jetzt eine neue Serie hinzufügen
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "Series 3"), chart.getType());
    // Dritte Diagrammserie auswählen
    series = chart.getChartData().getSeries().get_Item(2);
    // Jetzt die Seriendaten füllen
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

## **Datenbereich für ein Diagramm festlegen**

So legen Sie den Datenbereich für ein Diagramm fest:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/)‑Klasse, die die Präsentation mit dem Diagramm enthält.
2. Rufen Sie über den Index eine Folie ab.
3. Durchsuchen Sie alle Formen, um das gewünschte Diagramm zu finden.
4. Greifen Sie auf die Diagrammdaten zu und setzen Sie den Bereich.
5. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser JavaScript‑Code zeigt, wie der Datenbereich für ein Diagramm festgelegt wird:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("ExistingChart.pptx");
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

Wenn Sie Standard‑Marker in Diagrammen verwenden, erhält jede Diagrammreihe automatisch ein anderes Markersymbol.

Dieser JavaScript‑Code zeigt, wie ein Diagramm‑Reihen‑Marker automatisch gesetzt wird:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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
    // Nimm die zweite Diagrammserie
    var series2 = chart.getChartData().getSeries().get_Item(1);
    // Jetzt die Seriendaten befüllen
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

## **FAQ**

**Welche Diagrammtypen werden von Aspose.Slides unterstützt?**

Aspose.Slides unterstützt eine Vielzahl von [Diagrammtypen](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/charttype/), darunter Balken, Linien, Kreis, Flächen, Streu, Histogramm, Radar und viele mehr. Diese Flexibilität ermöglicht es Ihnen, den am besten geeigneten Diagrammtyp für Ihre Datenvisualisierung auszuwählen.

**Wie füge ich ein neues Diagramm zu einer Folie hinzu?**

Um ein Diagramm hinzuzufügen, erstellen Sie zunächst eine Instanz der [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/)‑Klasse, holen die gewünschte Folie über deren Index und rufen dann die Methode zum Hinzufügen eines Diagramms auf, wobei Sie den Diagrammtyp und die Anfangsdaten angeben. Dieser Vorgang integriert das Diagramm direkt in Ihre Präsentation.

**Wie kann ich die in einem Diagramm angezeigten Daten aktualisieren?**

Sie können die Daten eines Diagramms aktualisieren, indem Sie auf das zugehörige Daten‑Workbook ([ChartDataWorkbook](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chartdataworkbook/)) zugreifen, vorhandene Standard‑Reihen und -Kategorien entfernen und anschließend Ihre benutzerdefinierten Daten hinzufügen. So können Sie das Diagramm programmgesteuert aktualisieren, um die neuesten Daten wiederzugeben.

**Ist es möglich, das Aussehen des Diagramms anzupassen?**

Ja, Aspose.Slides bietet umfangreiche Anpassungsoptionen. Sie können Farben, Schriftarten, Beschriftungen, Legenden und andere [Formatierungselemente](/slides/de/nodejs-java/chart-entities/) ändern, um das Erscheinungsbild des Diagramms an Ihre spezifischen Designanforderungen anzupassen.