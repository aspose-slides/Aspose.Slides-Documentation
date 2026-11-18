---
title: PowerPoint-Präsentationsdiagramme in JavaScript erstellen oder aktualisieren
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
- Tree‑Map‑Diagramm
- Börsendiagramm
- Box‑Und‑Whisker‑Diagramm
- Trichterdiagramm
- Sunburst‑Diagramm
- Histogramm
- Radar‑Diagramm
- Mehrkategorie‑Diagramm
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Erstellen und anpassen von Diagrammen in PowerPoint‑Präsentationen mit Aspose.Slides für Node.js über Java. Diagramme hinzufügen, formatieren und bearbeiten mit praktischen Codebeispielen in JavaScript."
---
## **Übersicht**

Dieser Artikel bietet eine umfassende Anleitung, wie man Diagramme mit Aspose.Slides für Node.js über Java erstellt und anpasst. Sie lernen, wie man programmgesteuert ein Diagramm zu einer Folie hinzufügt, es mit Daten füllt und verschiedene Formatierungsoptionen anwendet, um Ihren spezifischen Designanforderungen zu entsprechen. Im gesamten Artikel veranschaulichen ausführliche Codebeispiele jeden Schritt, von der Initialisierung der Präsentation und des Diagrammobjekts bis zur Konfiguration von Serien, Achsen und Legenden. Wenn Sie dieser Anleitung folgen, erhalten Sie ein fundiertes Verständnis dafür, wie Sie die dynamische Diagrammerstellung in Ihre Node.js‑Anwendungen integrieren und den Prozess der Erstellung datengetriebener Präsentationen optimieren.

## **Diagramm erstellen**

Diagramme helfen dabei, Daten schnell zu visualisieren und Erkenntnisse zu gewinnen, die aus einer Tabelle oder einem Tabellenblatt nicht sofort ersichtlich sind.

**Warum Diagramme erstellen?**

* große Datenmengen auf einer einzigen Folie einer Präsentation aggregieren, verdichten oder zusammenfassen;
* Muster und Trends in den Daten aufzeigen;
* die Richtung und das Momentum der Daten über die Zeit oder in Bezug auf eine spezifische Maßeinheit ableiten;
* Ausreißer, Abweichungen, Anomalien, Fehler und unsinnige Daten erkennen;
* komplexe Daten kommunizieren oder präsentieren.

In PowerPoint können Sie Diagramme über die *Einfügen*-Funktion erstellen, die Vorlagen für die Gestaltung vieler Diagrammtypen bereitstellt. Mit Aspose.Slides können Sie sowohl reguläre Diagramme (basierend auf gängigen Diagrammtypen) als auch benutzerdefinierte Diagramme erstellen.

{{% alert color="info" title="Note" %}}
Verwenden Sie die [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) Aufzählung im [aspose.slides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/) Modul. Die Werte dieser Aufzählung entsprechen verschiedenen Diagrammtypen.
{{% /alert %}}

### **Clustered Column-Diagramme erstellen**

Dieses Beispiel verwendet [addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/), um ein Clustered‑Column‑Diagramm zu erstellen, das zwei Serien in drei Kategorien vergleicht. Die Serien verwenden rote bzw. grüne Füllungen, und einzelne Beschriftungen zeigen Kategorienamen, Seriennamen und Werte an. Der Arbeitsblatt‑Index 0 bezieht sich auf das erste Blatt im eingebetteten Diagramm‑Arbeitsbuch.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try
{
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 300);

    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(java.newByte(aspose.slides.NullableBool.True));
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    let workbook = chart.getChartData().getChartDataWorkbook();
    let worksheetIndex = 0;

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    chart.getChartData().getSeries().add(seriesNameCell, chart.getType());
    seriesNameCell = workbook.getCell(worksheetIndex, 0, 2, "Series 2");
    chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    let categoryCell = workbook.getCell(worksheetIndex, 1, 0, "Category 1");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(worksheetIndex, 2, 0, "Category 2");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(worksheetIndex, 3, 0, "Category 3");
    chart.getChartData().getCategories().add(categoryCell);

    let series = chart.getChartData().getSeries().get_Item(0);

    let valueCell = workbook.getCell(worksheetIndex, 1, 1, 20);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 2, 1, 50);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 3, 1, 30);
    series.getDataPoints().addDataPointForBarSeries(valueCell);

    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));

    series = chart.getChartData().getSeries().get_Item(1);

    valueCell = workbook.getCell(worksheetIndex, 1, 2, 30);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 2, 2, 10);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 3, 2, 60);
    series.getDataPoints().addDataPointForBarSeries(valueCell);

    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 0, 128, 0));

    let label = series.getDataPoints().get_Item(0).getLabel();
    label.getDataLabelFormat().setShowCategoryName(true);

    label = series.getDataPoints().get_Item(1).getLabel();
    label.getDataLabelFormat().setShowSeriesName(true);

    label = series.getDataPoints().get_Item(2).getLabel();
    label.getDataLabelFormat().setShowValue(true);
    label.getDataLabelFormat().setShowSeriesName(true);
    label.getDataLabelFormat().setSeparator("/");

    presentation.save("AsposeChart.pptx", aspose.slides.SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

Das Ergebnis:

![Das Clustered Column Diagramm](clustered_column_chart.png)

### **Scatter-Diagramme erstellen**

Scatter-Diagramme (auch als Streudiagramme oder x‑y‑Grafiken bezeichnet) werden häufig verwendet, um Muster zu prüfen oder Korrelationen zwischen zwei Variablen zu demonstrieren.

Verwenden Sie ein Scatter‑Diagramm, wenn:

* Sie numerische Datenpaare haben.
* Sie zwei Variablen besitzen, die gut zusammenpassen.
* Sie feststellen möchten, ob die beiden Variablen miteinander verbunden sind.
* Sie eine unabhängige Variable haben, die mehrere Werte für eine abhängige Variable hat.

Dieses Beispiel erzeugt zwei Sätze von x‑y‑Werten. Die erste Serie verwendet gerade Linien mit Stern‑Markierungen, während die zweite glatte Linien mit Kreis‑Markierungen nutzt; beide verwenden eine Markierungsgröße von 10, konfiguriert mit [setSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/marker/setsize/). Die [setSymbol](https://reference.aspose.com/slides/nodejs-java/aspose.slides/marker/setsymbol/) Methode steuert die Form der Markierung.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try
{
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.ScatterWithSmoothLines, 20, 20, 500, 300);

    let workbook = chart.getChartData().getChartDataWorkbook();
    let worksheetIndex = 0;

    chart.getChartData().getSeries().clear();

    let seriesNameCell = workbook.getCell(worksheetIndex, 1, 1, "Series 1");
    chart.getChartData().getSeries().add(seriesNameCell, chart.getType());
    seriesNameCell = workbook.getCell(worksheetIndex, 1, 3, "Series 2");
    chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    let series = chart.getChartData().getSeries().get_Item(0);

    let xValueCell = workbook.getCell(worksheetIndex, 2, 1, 1);
    let yValueCell = workbook.getCell(worksheetIndex, 2, 2, 3);
    series.getDataPoints().addDataPointForScatterSeries(xValueCell, yValueCell);

    xValueCell = workbook.getCell(worksheetIndex, 3, 1, 2);
    yValueCell = workbook.getCell(worksheetIndex, 3, 2, 10);
    series.getDataPoints().addDataPointForScatterSeries(xValueCell, yValueCell);

    series.setType(aspose.slides.ChartType.ScatterWithStraightLinesAndMarkers);

    series.getMarker().setSize(10);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Star);

    series = chart.getChartData().getSeries().get_Item(1);

    xValueCell = workbook.getCell(worksheetIndex, 2, 3, 5);
    yValueCell = workbook.getCell(worksheetIndex, 2, 4, 2);
    series.getDataPoints().addDataPointForScatterSeries(xValueCell, yValueCell);

    xValueCell = workbook.getCell(worksheetIndex, 3, 3, 3);
    yValueCell = workbook.getCell(worksheetIndex, 3, 4, 1);
    series.getDataPoints().addDataPointForScatterSeries(xValueCell, yValueCell);

    xValueCell = workbook.getCell(worksheetIndex, 4, 3, 2);
    yValueCell = workbook.getCell(worksheetIndex, 4, 4, 2);
    series.getDataPoints().addDataPointForScatterSeries(xValueCell, yValueCell);

    xValueCell = workbook.getCell(worksheetIndex, 5, 3, 5);
    yValueCell = workbook.getCell(worksheetIndex, 5, 4, 1);
    series.getDataPoints().addDataPointForScatterSeries(xValueCell, yValueCell);

    series.getMarker().setSize(10);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Circle);

    presentation.save("AsposeChart.pptx", aspose.slides.SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

Das Ergebnis:

![Das Scatter‑Diagramm](scatter_chart.png)

### **Kreisdiagramme erstellen**

Kreisdiagramme eignen sich am besten, um das Verhältnis von Teil zu Ganzem in Daten darzustellen, insbesondere wenn die Daten kategoriale Beschriftungen mit numerischen Werten enthalten. Wenn Ihre Daten jedoch viele Teile oder Beschriftungen enthalten, sollten Sie stattdessen ein Balkendiagramm in Betracht ziehen.

Dieses Beispiel erstellt ein Kreisdiagramm mit drei Quartalswerten. Jeder Abschnitt hat eine benutzerdefinierte Füllung und Rahmen, und die Beschriftungen zeigen verschiedene Kombinationen von Werten, Prozentwerten und Serieninformationen an. Die Methode [setFirstSliceAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setfirstsliceangle/) legt fest, dass das erste Segment bei 180 Grad beginnt.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try
{
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 20, 20, 500, 300);

    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(java.newByte(aspose.slides.NullableBool.True));
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    let workbook = chart.getChartData().getChartDataWorkbook();
    let worksheetIndex = 0;

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    let categoryCell = workbook.getCell(0, 1, 0, "1st Qtr");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, 2, 0, "2nd Qtr");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, 3, 0, "3rd Qtr");
    chart.getChartData().getCategories().add(categoryCell);

    let seriesNameCell = workbook.getCell(0, 0, 1, "Series 1");
    let series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    let valueCell = workbook.getCell(worksheetIndex, 1, 1, 20);
    series.getDataPoints().addDataPointForPieSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 2, 1, 50);
    series.getDataPoints().addDataPointForPieSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 3, 1, 30);
    series.getDataPoints().addDataPointForPieSeries(valueCell);

    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(true);

    let firstSlice = series.getDataPoints().get_Item(0);
    firstSlice.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstSlice.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));

    firstSlice.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstSlice.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    firstSlice.getFormat().getLine().setWidth(3.0);
    firstSlice.getFormat().getLine().setStyle(java.newByte(aspose.slides.LineStyle.ThinThick));
    firstSlice.getFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.LargeDash));

    let secondSlice = series.getDataPoints().get_Item(1);
    secondSlice.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondSlice.getFormat().getFill().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 165, 42, 42));

    secondSlice.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondSlice.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    secondSlice.getFormat().getLine().setWidth(3.0);
    secondSlice.getFormat().getLine().setStyle(java.newByte(aspose.slides.LineStyle.Single));
    secondSlice.getFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.LargeDashDot));

    let thirdSlice = series.getDataPoints().get_Item(2);
    thirdSlice.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdSlice.getFormat().getFill().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 127, 80));

    thirdSlice.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdSlice.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    thirdSlice.getFormat().getLine().setWidth(2.0);
    thirdSlice.getFormat().getLine().setStyle(java.newByte(aspose.slides.LineStyle.ThinThin));
    thirdSlice.getFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.LargeDashDotDot));

    let firstLabel = series.getDataPoints().get_Item(0).getLabel();
    firstLabel.getDataLabelFormat().setShowValue(true);

    let secondLabel = series.getDataPoints().get_Item(1).getLabel();
    secondLabel.getDataLabelFormat().setShowValue(true);
    secondLabel.getDataLabelFormat().setShowLegendKey(true);
    secondLabel.getDataLabelFormat().setShowPercentage(true);

    let thirdLabel = series.getDataPoints().get_Item(2).getLabel();
    thirdLabel.getDataLabelFormat().setShowSeriesName(true);
    thirdLabel.getDataLabelFormat().setShowPercentage(true);

    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(true);

    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);

    presentation.save("PieChart.pptx", aspose.slides.SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

Das Ergebnis:

![Das Kreisdiagramm](pie_chart.png)

Um die Lesbarkeit von Beschriftungen außerhalb des Kreises zu verbessern, siehe [Formatierung von Führungs‑linien](/slides/de/nodejs-java/chart-data-label/#format-leader-lines) für ein Beispiel, das Beschriftungen positioniert und die Linienfarbe, -breite, -transparenz und den Strichstil anpasst.

### **Liniendiagramme erstellen**

Liniendiagramme (auch als Liniendiagramme bezeichnet) eignen sich am besten für Situationen, in denen Sie Änderungen von Werten im Zeitverlauf darstellen möchten. Mit einem Liniendiagramm können Sie große Datenmengen auf einmal vergleichen, Änderungen und Trends über die Zeit verfolgen, Anomalien in Datenserien hervorheben und mehr.

Dieses Beispiel verwendet [addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/), um ein Liniendiagramm mit den Standardserien und -kategorien zu erstellen, und speichert die Präsentation als PPTX.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try
{
    let slide = presentation.getSlides().get_Item(0);

    let lineChart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 20, 20, 500, 300);

    presentation.save("lineChart.pptx", aspose.slides.SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

Standardmäßig werden Punkte in einem Liniendiagramm durch gerade, kontinuierliche Linien verbunden. Wenn Sie die Punkte stattdessen mit Strichen verbinden möchten, rufen Sie [setDashStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/setdashstyle/) mit einem Wert aus [LineDashStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linedashstyle/) auf:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try
{
    let slide = presentation.getSlides().get_Item(0);

    let lineChart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 20, 20, 500, 300);

    for (let i = 0; i < lineChart.getChartData().getSeries().size(); i++)
    {
        let series = lineChart.getChartData().getSeries().get_Item(i);
        series.getFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));
    }
}
finally
{
    presentation.dispose();
}
```

Das Ergebnis:

![Das Liniendiagramm](line_chart.png)

### **Tree‑Map‑Diagramme erstellen**

Tree‑Map‑Diagramme eignen sich am besten für Verkaufsdaten, wenn Sie die relative Größe von Datenkategorien zeigen und schnell die Aufmerksamkeit auf Elemente lenken möchten, die große Beiträge innerhalb jeder Kategorie leisten.

Dieses Beispiel erstellt eine Tree‑Map mit acht Blättern, gruppiert in vier Stämmen und zwei Zweigen. Die Methode [setGroupingItem](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartcategorylevelsmanager/setgroupingitem/) weist Stämme auf Gruppierungsebene 1 und Zweige auf Ebene 2 zu. Werte bestimmen die relative Rechtecksgröße, während Kategoriebeschriftungen und überlappende Elternbeschriftungen die Hierarchie identifizieren.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try
{
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.Treemap, 20, 20, 500, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    let workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    // Zweig 1
    let categoryCell = workbook.getCell(0, "C1", "Leaf1");
    let leaf = chart.getChartData().getCategories().add(categoryCell);
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");

    categoryCell = workbook.getCell(0, "C2", "Leaf2");
    chart.getChartData().getCategories().add(categoryCell);

    categoryCell = workbook.getCell(0, "C3", "Leaf3");
    leaf = chart.getChartData().getCategories().add(categoryCell);
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");

    categoryCell = workbook.getCell(0, "C4", "Leaf4");
    chart.getChartData().getCategories().add(categoryCell);

    // Zweig 2
    categoryCell = workbook.getCell(0, "C5", "Leaf5");
    leaf = chart.getChartData().getCategories().add(categoryCell);
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");

    categoryCell = workbook.getCell(0, "C6", "Leaf6");
    chart.getChartData().getCategories().add(categoryCell);

    categoryCell = workbook.getCell(0, "C7", "Leaf7");
    leaf = chart.getChartData().getCategories().add(categoryCell);
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");

    categoryCell = workbook.getCell(0, "C8", "Leaf8");
    chart.getChartData().getCategories().add(categoryCell);

    let series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Treemap);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    let valueCell = workbook.getCell(0, "D1", 4);
    series.getDataPoints().addDataPointForTreemapSeries(valueCell);
    valueCell = workbook.getCell(0, "D2", 5);
    series.getDataPoints().addDataPointForTreemapSeries(valueCell);
    valueCell = workbook.getCell(0, "D3", 3);
    series.getDataPoints().addDataPointForTreemapSeries(valueCell);
    valueCell = workbook.getCell(0, "D4", 6);
    series.getDataPoints().addDataPointForTreemapSeries(valueCell);
    valueCell = workbook.getCell(0, "D5", 9);
    series.getDataPoints().addDataPointForTreemapSeries(valueCell);
    valueCell = workbook.getCell(0, "D6", 9);
    series.getDataPoints().addDataPointForTreemapSeries(valueCell);
    valueCell = workbook.getCell(0, "D7", 4);
    series.getDataPoints().addDataPointForTreemapSeries(valueCell);
    valueCell = workbook.getCell(0, "D8", 3);
    series.getDataPoints().addDataPointForTreemapSeries(valueCell);

    series.setParentLabelLayout(aspose.slides.ParentLabelLayoutType.Overlapping);

    presentation.save("Treemap.pptx", aspose.slides.SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

Das Ergebnis:

![Das Tree‑Map‑Diagramm](treemap_chart.png)

### **Wasserfalldiagramme erstellen**

Ein Wasserfalldiagramm zeigt, wie positive und negative Änderungen zu einem Endwert beitragen. Zum Beispiel kann eine Gewinnaufschlüsselung mit Umsatz beginnen, Kosten abziehen und weitere Einnahmen hinzufügen. Änderungs‑Spalten schweben zwischen dem vorherigen und dem neuen laufenden Wert, während Gesamtsäulen vom Nullpunkt bis zum kumulierten Wert reichen.

| Kategorie | Arbeitsblattwert | Spaltentyp |
| --- | ---: | --- |
| Revenue | 1000 | Zunahme |
| Cost of sales | -400 | Abnahme |
| Gross profit | 600 | Zwischensumme |
| Operating expenses | -200 | Abnahme |
| Other income | 50 | Zunahme |
| Net profit | 450 | Endsumme |

Um einen Punkt als Zwischensumme oder Endsumme zu kennzeichnen, rufen Sie dessen [setSetAsTotal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/setsetastotal/) Methode mit `true` auf. Geben Sie den tatsächlichen kumulierten Betrag in der Arbeitsblattzelle dieses Punktes an: `600` für Bruttogewinn (`1000 - 400`) und `450` für Nettogewinn (`600 - 200 + 50`). Die Methode markiert die Spalte als Summe; sie berechnet oder füllt den Zellenwert nicht. Verwenden Sie nicht Null als Platzhalter oder geben Sie keinen anderen Änderungswert für einen Summenpunkt an. Eine Summenspalte zeigt den kumulierten Wert an, ohne ihn erneut zum laufenden Wert hinzuzufügen.

Dieses vollständige JavaScript‑Beispiel erstellt ein Diagramm mit dem `Waterfall`‑Mitglied von [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/), leert die Standarddaten und füllt das eingebettete Arbeitsbuch. Der Arbeitsblatt‑Index `0` wählt das erste Arbeitsblatt; Spalte A enthält Kategorienamen und Spalte B enthält Werte. Jeder Werte‑Zelle wird mit [addDataPointForWaterfallSeries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/adddatapointforwaterfallseries/) hinzugefügt. Die nullbasierten Punkt‑Indizes `2` und `5` bezeichnen die Zwischensummen‑ bzw. Endsummen. Durch Aufruf von [setShowValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setshowvalue/) mit `true` werden die Beträge auf den Spalten angezeigt. Keine Eingabepräsentation oder Arbeitsbuch ist erforderlich.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try
{
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.Waterfall, 20, 20, 680, 200);

    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Profit breakdown (USD thousands)");
    chart.getChartTitle().setOverlay(false);
    chart.setLegend(false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    let workbook = chart.getChartData().getChartDataWorkbook();
    let worksheetIndex = 0;

    workbook.clear(worksheetIndex);

    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Profit");
    let series = chart.getChartData().getSeries().add(seriesNameCell, aspose.slides.ChartType.Waterfall);
    let categories = [ "Revenue", "Cost of sales", "Gross profit", "Operating expenses", "Other income", "Net profit" ];
    let values = [ 1000, -400, 600, -200, 50, 450 ];

    for (let i = 0; i < categories.length; i++)
    {
        let categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, categories[i]);
        chart.getChartData().getCategories().add(categoryCell);
        let valueCell = workbook.getCell(worksheetIndex, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForWaterfallSeries(valueCell);
    }

    // Der dritte und der sechste Punkt stellen Gesamtsummen dar, nicht zusätzliche Änderungen.
    series.getDataPoints().get_Item(2).setSetAsTotal(true);
    series.getDataPoints().get_Item(5).setSetAsTotal(true);
    series.setShowConnectorLines(true);
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("WaterfallChart.pptx", aspose.slides.SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

Rufen Sie die Serien‑Level‑Methode [setShowConnectorLines](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/setshowconnectorlines/) mit `true` auf, um Linien anzuzeigen, die aufeinanderfolgende Spalten verbinden und den laufenden Wert leichter nachvollziehbar machen. Um diese Linien auszublenden, ersetzen Sie den Methodenaufruf im Beispiel durch `series.setShowConnectorLines(false);` vor dem Speichern. Dies ändert nur die Sichtbarkeit der Linien, nicht die Daten oder Summen.

Die gespeicherte Präsentation zeigt einen Bruttogewinn von 600 und einen Nettogewinn von 450, wobei beide Summen vom Nullpunkt ausgehen:

![Wasserfalldiagramm, das Umsatz, Kosten, Bruttogewinn von 600 und Nettogewinn von 450 zeigt, mit Wertebeschriftungen und Verbindungslinien](waterfall_chart.png)

### **Börsendiagramme erstellen**

Börsendiagramme werden verwendet, um Finanzdaten wie Eröffnungs-, Hoch‑, Tief‑ und Schlusskurse darzustellen und helfen, Markttrends und Volatilität zu analysieren. Sie bieten wesentliche Einblicke in die Aktienperformance und unterstützen Investoren und Analysten bei fundierten Entscheidungen.

Dieses Beispiel erstellt ein Open‑High‑Low‑Close‑Diagramm mit vier Serien in dieser Reihenfolge und drei Kategorien. Die Methode [setUpDownBars](https://reference.aspose.com/slides/nodejs-java/aspose.slides/updownbarsmanager/setupdownbars/) aktiviert Aufwärts‑/Abwärts‑Balken, und [getHiLowLinesFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/gethilowlinesformat/) steuert die Hoch‑Tief‑Linien, die die Preisspannen anzeigen, während die einzelnen Serien‑Linien und die kleinen horizontalen Gitterlinien ausgeblendet sind.

Der von [getUpDownBars](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/getupdownbars/) zurückgegebene Manager stellt separate Formatierungsobjekte über [getUpBarsFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/updownbarsmanager/getupbarsformat/) und [getDownBarsFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/updownbarsmanager/getdownbarsformat/) bereit. Verwenden Sie die Methoden [getFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/format/getfill/) und [getLine](https://reference.aspose.com/slides/nodejs-java/aspose.slides/format/getline/) jedes Objekts, um dessen Füllung und Kontur unabhängig zu setzen. Dieses Beispiel verwendet grüne Balken mit dunkelgrünen Konturen für steigende Intervalle und orange‑rote Balken mit dunkelroten Konturen für fallende Intervalle.

Stellen Sie numerische Werte für alle vier Serien in jeder Kategorie bereit, wobei Hoch und Tief die Öffnungs‑ und Schlusskurse einschließen. Die Balken vergleichen den Schlusskurs mit dem Eröffnungskurs **innerhalb derselben Kategorie**, nicht mit der vorherigen Kategorie: A fällt von 72 auf 25, während B von 25 auf 38 steigt und C von 38 auf 50 steigt. Gleiche Öffnungs‑ und Schlusskurse erzeugen kein sichtbares gefülltes Intervall. Auf‑/Abwärts‑Balken erstrecken sich über Öffnung‑Schluss, Hoch‑Tief‑Linien über Tief‑Hoch. Diese Balken gehören zur Seriengruppe und sind keine normalen Balkendiagramm‑Serien.

Diese Formatierung funktioniert auch mit [Line‑ und LineWithMarkers](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/)‑Diagrammen, die mindestens zwei Serien in derselben Gruppe und entsprechende numerische Werte für jede Kategorie enthalten. Für diese nicht‑gestapelten Liniendiagramme vergleichen Auf‑/Abwärts‑Balken die erste und die letzte Serie: ein höherer letzter Wert erzeugt einen Auf‑Balken, ein niedrigerer letzter Wert einen Ab‑Balken. Das Umkehren dieser Serien kehrt die Klassifizierung um. Das nachfolgende Beispiel verwendet [OpenHighLowClose](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/); gehen Sie nicht davon aus, dass andere Börsen‑, gestapelten Linien‑ oder 3D‑Varianten dieselbe Datenanordnung oder Intervallinterpretation nutzen.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try
{
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.OpenHighLowClose, 20, 20, 500, 150, false);

    let workbook = chart.getChartData().getChartDataWorkbook();

    let categoryCell = workbook.getCell(0, 1, 0, "A");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, 2, 0, "B");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, 3, 0, "C");
    chart.getChartData().getCategories().add(categoryCell);

    let seriesNameCell = workbook.getCell(0, 0, 1, "Open");
    chart.getChartData().getSeries().add(seriesNameCell, aspose.slides.ChartType.OpenHighLowClose);
    seriesNameCell = workbook.getCell(0, 0, 2, "High");
    chart.getChartData().getSeries().add(seriesNameCell, aspose.slides.ChartType.OpenHighLowClose);
    seriesNameCell = workbook.getCell(0, 0, 3, "Low");
    chart.getChartData().getSeries().add(seriesNameCell, aspose.slides.ChartType.OpenHighLowClose);
    seriesNameCell = workbook.getCell(0, 0, 4, "Close");
    chart.getChartData().getSeries().add(seriesNameCell, aspose.slides.ChartType.OpenHighLowClose);

    let series = chart.getChartData().getSeries().get_Item(0);
    let valueCell = workbook.getCell(0, 1, 1, 72);
    series.getDataPoints().addDataPointForStockSeries(valueCell);
    valueCell = workbook.getCell(0, 2, 1, 25);
    series.getDataPoints().addDataPointForStockSeries(valueCell);
    valueCell = workbook.getCell(0, 3, 1, 38);
    series.getDataPoints().addDataPointForStockSeries(valueCell);

    series = chart.getChartData().getSeries().get_Item(1);
    valueCell = workbook.getCell(0, 1, 2, 172);
    series.getDataPoints().addDataPointForStockSeries(valueCell);
    valueCell = workbook.getCell(0, 2, 2, 57);
    series.getDataPoints().addDataPointForStockSeries(valueCell);
    valueCell = workbook.getCell(0, 3, 2, 57);
    series.getDataPoints().addDataPointForStockSeries(valueCell);

    series = chart.getChartData().getSeries().get_Item(2);
    valueCell = workbook.getCell(0, 1, 3, 12);
    series.getDataPoints().addDataPointForStockSeries(valueCell);
    valueCell = workbook.getCell(0, 2, 3, 12);
    series.getDataPoints().addDataPointForStockSeries(valueCell);
    valueCell = workbook.getCell(0, 3, 3, 13);
    series.getDataPoints().addDataPointForStockSeries(valueCell);

    series = chart.getChartData().getSeries().get_Item(3);
    valueCell = workbook.getCell(0, 1, 4, 25);
    series.getDataPoints().addDataPointForStockSeries(valueCell);
    valueCell = workbook.getCell(0, 2, 4, 38);
    series.getDataPoints().addDataPointForStockSeries(valueCell);
    valueCell = workbook.getCell(0, 3, 4, 50);
    series.getDataPoints().addDataPointForStockSeries(valueCell);

    let upDownBars = chart.getChartData().getSeriesGroups().get_Item(0).getUpDownBars();
    upDownBars.setUpDownBars(true);

    upDownBars.getUpBarsFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    upDownBars.getUpBarsFormat().getFill().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 50, 205, 50));
    upDownBars.getUpBarsFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    upDownBars.getUpBarsFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 0, 100, 0));
    upDownBars.getUpBarsFormat().getLine().setWidth(2);

    upDownBars.getDownBarsFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    upDownBars.getDownBarsFormat().getFill().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 69, 0));
    upDownBars.getDownBarsFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    upDownBars.getDownBarsFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 139, 0, 0));
    upDownBars.getDownBarsFormat().getLine().setWidth(2);
    chart.getChartData().getSeriesGroups().get_Item(0).getHiLowLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));

    for (let i = 0; i < chart.getChartData().getSeries().size(); i++)
    {
        let stockSeries = chart.getChartData().getSeries().get_Item(i);
        stockSeries.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    }

    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    presentation.save("Stock-chart.pptx", aspose.slides.SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

Das Ergebnis, aus PowerPoint exportiert:

![Börsendiagramm mit einem orange‑roten fallenden Intervall für A und grünen steigenden Intervallen für B und C](stock_chart.png)

### **Box‑Und‑Whisker‑Diagramme erstellen**

Box‑Und‑Whisker‑Diagramme werden verwendet, um die Verteilung von Daten darzustellen, indem wichtige statistische Kennzahlen wie Median, Quartile und mögliche Ausreißer zusammengefasst werden. Sie sind besonders nützlich in der explorativen Datenanalyse und statistischen Studien, um schnell die Datenvariabilität zu verstehen und Anomalien zu identifizieren.

Dieses Beispiel erstellt ein Box‑Und‑Whisker‑Diagramm aus sechs Werten. Die Methode [setQuartileMethod](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/setquartilemethod/) wählt die exklusive Quartilberechnung. Das Beispiel aktiviert zudem Mittelwertlinien, Mittelwert‑Markierungen, innere Punkte und Ausreißer‑Punkte.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try
{
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.BoxAndWhisker, 20, 20, 500, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    let workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    let categoryCell = workbook.getCell(0, "A1", "Category 1");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, "A2", "Category 2");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, "A3", "Category 3");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, "A4", "Category 4");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, "A5", "Category 5");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, "A6", "Category 6");
    chart.getChartData().getCategories().add(categoryCell);

    let series = chart.getChartData().getSeries().add(aspose.slides.ChartType.BoxAndWhisker);

    series.setQuartileMethod(aspose.slides.QuartileMethodType.Exclusive);
    series.setShowMeanLine(true);
    series.setShowMeanMarkers(true);
    series.setShowInnerPoints(true);
    series.setShowOutlierPoints(true);

    let valueCell = workbook.getCell(0, "B1", 15);
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(valueCell);
    valueCell = workbook.getCell(0, "B2", 41);
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(valueCell);
    valueCell = workbook.getCell(0, "B3", 16);
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(valueCell);
    valueCell = workbook.getCell(0, "B4", 10);
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(valueCell);
    valueCell = workbook.getCell(0, "B5", 23);
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(valueCell);
    valueCell = workbook.getCell(0, "B6", 16);
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(valueCell);

    presentation.save("BoxAndWhisker.pptx", aspose.slides.SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

### **Trichterdiagramme erstellen**

Trichterdiagramme werden verwendet, um Prozesse zu visualisieren, die sequenzielle Stufen umfassen, wobei das Datenvolumen von einem Schritt zum nächsten abnimmt. Sie sind besonders hilfreich, um Konversionsraten zu analysieren, Engpässe zu identifizieren und die Effizienz von Vertriebs‑ oder Marketingprozessen zu verfolgen.

Dieses Beispiel verwendet [addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/), um ein Trichterdiagramm zur ersten Folie einer bestehenden Präsentation hinzuzufügen. Es ersetzt die Standarddaten durch sechs Kategorien und Werte von 50 bis 500 und speichert die aktualisierte Präsentation. Die Eingabepäsentation muss mindestens eine Folie enthalten.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation("test.pptx");
try
{
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.Funnel, 50, 50, 500, 400);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    let workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    let categoryCell = workbook.getCell(0, "A1", "Category 1");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, "A2", "Category 2");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, "A3", "Category 3");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, "A4", "Category 4");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, "A5", "Category 5");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, "A6", "Category 6");
    chart.getChartData().getCategories().add(categoryCell);

    let series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Funnel);

    let valueCell = workbook.getCell(0, "B1", 50);
    series.getDataPoints().addDataPointForFunnelSeries(valueCell);
    valueCell = workbook.getCell(0, "B2", 100);
    series.getDataPoints().addDataPointForFunnelSeries(valueCell);
    valueCell = workbook.getCell(0, "B3", 200);
    series.getDataPoints().addDataPointForFunnelSeries(valueCell);
    valueCell = workbook.getCell(0, "B4", 300);
    series.getDataPoints().addDataPointForFunnelSeries(valueCell);
    valueCell = workbook.getCell(0, "B5", 400);
    series.getDataPoints().addDataPointForFunnelSeries(valueCell);
    valueCell = workbook.getCell(0, "B6", 500);
    series.getDataPoints().addDataPointForFunnelSeries(valueCell);

    presentation.save("Funnel.pptx", aspose.slides.SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

Das Ergebnis:

![Das Trichterdiagramm](funnel_chart.png)

### **Sunburst‑Diagramme erstellen**

Sunburst‑Diagramme werden verwendet, um hierarchische Daten zu visualisieren, wobei Ebenen als konzentrische Ringe dargestellt werden. Sie veranschaulichen Teil‑zu‑Ganz‑Beziehungen und eignen sich ideal für die Darstellung verschachtelter Kategorien und Unterkategorien in einem klaren, kompakten Format.

Dieses Beispiel erstellt ein Sunburst‑Diagramm mit acht Blättern, gruppiert in vier Stämmen und zwei Zweigen. Die Methode [setGroupingItem](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartcategorylevelsmanager/setgroupingitem/) weist Stämme auf Gruppierungsebene 1 und Zweige auf Ebene 2 zu. Kategorienamen identifizieren die Segmente, und die Werte bestimmen ihre relative Größe.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try
{
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.Sunburst, 20, 20, 500, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    let workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    // Zweig 1
    let categoryCell = workbook.getCell(0, "C1", "Leaf1");
    let leaf = chart.getChartData().getCategories().add(categoryCell);
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");

    categoryCell = workbook.getCell(0, "C2", "Leaf2");
    chart.getChartData().getCategories().add(categoryCell);

    categoryCell = workbook.getCell(0, "C3", "Leaf3");
    leaf = chart.getChartData().getCategories().add(categoryCell);
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");

    categoryCell = workbook.getCell(0, "C4", "Leaf4");
    chart.getChartData().getCategories().add(categoryCell);

    // Zweig 2
    categoryCell = workbook.getCell(0, "C5", "Leaf5");
    leaf = chart.getChartData().getCategories().add(categoryCell);
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");

    categoryCell = workbook.getCell(0, "C6", "Leaf6");
    chart.getChartData().getCategories().add(categoryCell);

    categoryCell = workbook.getCell(0, "C7", "Leaf7");
    leaf = chart.getChartData().getCategories().add(categoryCell);
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");

    categoryCell = workbook.getCell(0, "C8", "Leaf8");
    chart.getChartData().getCategories().add(categoryCell);

    let series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Sunburst);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    let valueCell = workbook.getCell(0, "D1", 4);
    series.getDataPoints().addDataPointForSunburstSeries(valueCell);
    valueCell = workbook.getCell(0, "D2", 5);
    series.getDataPoints().addDataPointForSunburstSeries(valueCell);
    valueCell = workbook.getCell(0, "D3", 3);
    series.getDataPoints().addDataPointForSunburstSeries(valueCell);
    valueCell = workbook.getCell(0, "D4", 6);
    series.getDataPoints().addDataPointForSunburstSeries(valueCell);
    valueCell = workbook.getCell(0, "D5", 9);
    series.getDataPoints().addDataPointForSunburstSeries(valueCell);
    valueCell = workbook.getCell(0, "D6", 9);
    series.getDataPoints().addDataPointForSunburstSeries(valueCell);
    valueCell = workbook.getCell(0, "D7", 4);
    series.getDataPoints().addDataPointForSunburstSeries(valueCell);
    valueCell = workbook.getCell(0, "D8", 3);
    series.getDataPoints().addDataPointForSunburstSeries(valueCell);

    presentation.save("Sunburst.pptx", aspose.slides.SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

Das Ergebnis:

![Das Sunburst‑Diagramm](sunburst_chart.png)

### **Histogramm‑Diagramme erstellen**

Histogramm‑Diagramme zeigen, wie numerische Werte über Intervalle (Bins) verteilt sind.

Für Monatsberichte über Auftragsbearbeitungszeiten verwenden Sie dieselbe Bin‑Breite und Schwellen, um die Intervalle konsistent zu halten und Vergleiche zu erleichtern.

Rufen Sie [setAggregationType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setaggregationtype/) auf der horizontalen Achse mit einem Modus aus [AxisAggregationType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axisaggregationtype/) auf. [setBinWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setbinwidth/) gilt nur für `ByBinWidth`; [setNumberOfBins](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberofbins/) gilt nur für `ByNumberOfBins`. Verwenden Sie `Automatic`, um das Diagramm die Bins selbst wählen zu lassen.

#### **Feste Bin‑Breite verwenden**

Dieses Beispiel gruppiert Bearbeitungszeiten in 10‑Minuten‑Intervalle, mit separaten Bins für Zeiten ≤ 10 Minuten und > 40 Minuten. Aktivieren Sie diese Bins mit [setUnderflowBin](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setunderflowbin/) und [setOverflowBin](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setoverflowbin/). Wenn Sie explizite Schwellenwerte über [setUnderflowBin](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setunderflowbin/) und [setOverflowBin](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setoverflowbin/) angeben, rufen Sie [setAutomaticUnderflowBin](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticunderflowbin/) und [setAutomaticOverflowBin](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticoverflowbin/) mit `false` auf.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try
{
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.Histogram, 20, 20, 680, 200);

    chart.setLegend(false);
    chart.setTitle(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    let workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    let series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Histogram);
    let values = [ 5, 10, 10, 11, 15, 20, 20, 21, 25, 30, 30, 31, 35, 40, 40, 41, 50 ];
    for (let i = 0; i < values.length; i++)
    {
        let valueCell = workbook.getCell(0, i, 0, values[i]);
        series.getDataPoints().addDataPointForHistogramSeries(valueCell);
    }

    let axis = chart.getAxes().getHorizontalAxis();
    axis.setAggregationType(aspose.slides.AxisAggregationType.ByBinWidth);
    axis.setBinWidth(10);
    axis.setUnderflowBin(true);
    axis.setAutomaticUnderflowBin(false);
    axis.setUnderflowBin(10);
    axis.setOverflowBin(true);
    axis.setAutomaticOverflowBin(false);
    axis.setOverflowBin(40);

    presentation.save("Histogram-bin-width.pptx", aspose.slides.SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

Die in PowerPoint angezeigte Präsentation weist Bin‑Zählungen von **3, 4, 4, 4 und 2** auf. Der Unterlauf‑Bin enthält `5, 10, 10`, sodass seine Schwelle inklusiv ist. Der Überlauf‑Bin enthält nur `41, 50`, sodass seine Schwelle exklusiv ist; beide Werte gleich `40` verbleiben im vorherigen Intervall. Die inneren Bins enthalten Werte größer als ihre untere Grenze und kleiner oder gleich ihrer oberen Grenze.

![Histogramm mit 10‑Minute‑Bins und expliziten Unterlauf‑ und Überlauf‑Schwellenwerten](histogram_bin_width.png)

#### **Anzahl der Bins angeben**

Für ein fixes Detailniveau anstelle fester Intervalle fordern Sie fünf Bins für dieselben Daten an. Dieses Beispiel lässt Unterlauf‑ und Überlauf‑Bins deaktiviert. Das Diagramm ermittelt die Breite aus dem Datenbereich, sodass die Grenzen zwischen Berichten variieren können.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try
{
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.Histogram, 20, 20, 680, 200);

    chart.setLegend(false);
    chart.setTitle(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    let workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    let series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Histogram);
    let values = [ 5, 10, 10, 11, 15, 20, 20, 21, 25, 30, 30, 31, 35, 40, 40, 41, 50 ];
    for (let i = 0; i < values.length; i++)
    {
        let valueCell = workbook.getCell(0, i, 0, values[i]);
        series.getDataPoints().addDataPointForHistogramSeries(valueCell);
    }

    let axis = chart.getAxes().getHorizontalAxis();
    axis.setAggregationType(aspose.slides.AxisAggregationType.ByNumberOfBins);
    axis.setNumberOfBins(5);

    presentation.save("Histogram-bin-count.pptx", aspose.slides.SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

Die fünf Bins haben Zählungen von **4, 4, 4, 4 und 1**. Vergleichen Sie diese Verteilung mit dem Ergebnis der festen Breite oben: die Eingabewerte sind identisch, aber die Grenzen unterscheiden sich.

![Histogramm mit fünf Bins, berechnet aus denselben Daten](histogram_bin_count.png)

### **Radar‑Diagramme erstellen**

Radar‑Diagramme werden verwendet, um multivariate Daten in einem zweidimensionalen Format darzustellen, wodurch ein einfacher Vergleich mehrerer Variablen gleichzeitig ermöglicht wird. Sie sind besonders nützlich, um Muster, Stärken und Schwächen über mehrere Leistungsmetriken oder Attribute hinweg zu identifizieren.

Dieses Beispiel verwendet [addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/), um ein Radar‑Diagramm mit den Standardserien und -kategorien zu erstellen, und speichert die Präsentation als PPTX.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try
{
    let slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addChart(aspose.slides.ChartType.Radar, 20, 20, 500, 300);

    presentation.save("Radar-chart.pptx", aspose.slides.SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

Das Ergebnis:

![Das Radar‑Diagramm](radar_chart.png)

### **Mehrkategorie‑Diagramme erstellen**

Mehrkategorie‑Diagramme werden verwendet, um Daten anzuzeigen, die mehr als eine kategoriale Gruppierung umfassen, sodass Sie Werte über mehrere Dimensionen gleichzeitig vergleichen können. Sie sind besonders hilfreich, wenn Sie Trends und Beziehungen innerhalb komplexer, mehrschichtiger Datensätze analysieren müssen.

Dieses Beispiel erstellt ein Clustered‑Column‑Diagramm mit acht Kategorien, die in vier Paare angeordnet sind. Die Methode [setGroupingItem](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartcategorylevelsmanager/setgroupingitem/) gibt jedem Paar eine gemeinsame Beschriftung auf Gruppierungsebene 1, wodurch eine Kategorie‑Achse mit sowohl einzelnen als auch Gruppen‑Beschriftungen entsteht.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try
{
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 300);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    let workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    let worksheetIndex = 0;

    let categoryCell = workbook.getCell(0, "c2", "A");
    let category = chart.getChartData().getCategories().add(categoryCell);
    category.getGroupingLevels().setGroupingItem(1, "Group1");
    categoryCell = workbook.getCell(0, "c3", "B");
    category = chart.getChartData().getCategories().add(categoryCell);

    categoryCell = workbook.getCell(0, "c4", "C");
    category = chart.getChartData().getCategories().add(categoryCell);
    category.getGroupingLevels().setGroupingItem(1, "Group2");
    categoryCell = workbook.getCell(0, "c5", "D");
    category = chart.getChartData().getCategories().add(categoryCell);

    categoryCell = workbook.getCell(0, "c6", "E");
    category = chart.getChartData().getCategories().add(categoryCell);
    category.getGroupingLevels().setGroupingItem(1, "Group3");
    categoryCell = workbook.getCell(0, "c7", "F");
    category = chart.getChartData().getCategories().add(categoryCell);

    categoryCell = workbook.getCell(0, "c8", "G");
    category = chart.getChartData().getCategories().add(categoryCell);
    category.getGroupingLevels().setGroupingItem(1, "Group4");
    categoryCell = workbook.getCell(0, "c9", "H");
    category = chart.getChartData().getCategories().add(categoryCell);

    let seriesNameCell = workbook.getCell(0, "D1", "Series 1");
    let series = chart.getChartData().getSeries().add(seriesNameCell, aspose.slides.ChartType.ClusteredColumn);

    let valueCell = workbook.getCell(worksheetIndex, "D2", 10);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, "D3", 20);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, "D4", 30);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, "D5", 40);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, "D6", 50);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, "D7", 60);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, "D8", 70);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, "D9", 80);
    series.getDataPoints().addDataPointForBarSeries(valueCell);

    presentation.save("AsposeChart.pptx", aspose.slides.SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

Das Ergebnis:

![Das Mehrkategorie‑Diagramm](multi_category_chart.png)

#### **Ein Quartals‑Label entfernen**

Downloaden Sie [quarters.pptx](quarters.pptx) und legen Sie die Datei im Arbeitsverzeichnis ab. Das Diagramm enthält neun Monate und eine einzelne Verkaufsserie mit Werten von 10 bis 18. Auf der Kategorie‑Achse erstreckt sich Q1 über Januar bis März, Q2 über April bis Juni und Q3 über Juli bis September.

April ist die vierte Kategorie (Index 3) und enthält das Q2‑Label. Verwenden Sie [getGroupingLevels](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartcategory/getgroupinglevels/), um Aprils Gruppierungsebenen abzurufen, und rufen Sie dann [deleteGroupingItem](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartcategorylevelsmanager/deletegroupingitem/) mit Ebene 1 auf, um sein Quartals‑Label zu entfernen. Ebene 0 repräsentiert den Monat selbst und kann mit dieser Methode nicht entfernt werden.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("quarters.pptx");
try {
    const chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const april = chart.getChartData().getCategories().get_Item(3);
    april.getGroupingLevels().deleteGroupingItem(1);

    presentation.save("quarters-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const reopened = new aspose.slides.Presentation("quarters-updated.pptx");
try {
    const chart = reopened.getSlides().get_Item(0).getShapes().get_Item(0);
    const data = chart.getChartData();

    const categories = data.getCategories();
    const months = [];
    
    for (let i = 0; i < categories.size(); i++) {
        months.push(categories.get_Item(i).getAsCell().getValue());
    }
    const points = data.getSeries().get_Item(0).getDataPoints();
    const sales = [];
    for (let i = 0; i < points.size(); i++) {
        sales.push(points.get_Item(i).getValue().getData());
    }
    console.log(months.join(", "));
    console.log(sales.join(", "));
} finally {
    reopened.dispose();
}
```

Nach dem erneuten Öffnen des Diagramms gibt das Beispiel die ursprünglichen Monate (`Jan, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep`) und Verkaufswerte (`10, 11, 12, 13, 14, 15, 16, 17, 18`) in derselben Reihenfolge aus. Öffnen Sie `quarters-updated.pptx` in PowerPoint, um die Achsenbeschriftungen zu vergleichen. Das Q2‑Label und die Gruppen‑grenze vor April verschwinden, sodass Q1 von Januar bis Juni reicht. Q3 beginnt weiterhin im Juli.

![Quartals‑Beschriftungen vor und nach dem Entfernen. Links erstreckt sich Q2 über April bis Juni. Rechts erstreckt sich Q1 über Januar bis Juni.](quarter-label-comparison.png)

### **Karten‑Diagramme erstellen**

Karten‑Diagramme werden verwendet, um geografische Daten zu visualisieren, indem Informationen bestimmten Orten wie Ländern, Staaten oder Städten zugeordnet werden. Sie sind besonders nützlich, um regionale Trends, demografische Daten und räumliche Verteilungen klar und ansprechend darzustellen.

Dieses Beispiel verwendet [addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/), um ein Karten‑Diagramm mit den Standard‑Geodaten zu erstellen und speichert es zur Ansicht in PowerPoint.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try
{
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.Map, 20, 20, 500, 300);

    presentation.save("mapChart.pptx", aspose.slides.SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

Das Ergebnis:

![Das Karten‑Diagramm](map_chart.png)

{{% alert color="info" title="Note" %}}
Das obige Bild zeigt die gespeicherte Präsentation, die in PowerPoint geöffnet ist. Aspose.Slides schreibt das Karten‑Diagramm und dessen Daten korrekt, zeichnet jedoch selbst keine Karten‑Diagramme: Wenn eine Folie, die ein solches Diagramm enthält, zu einem Bild gerendert oder in PDF oder SVG konvertiert wird, erscheint der Diagrammbereich leer. Andere Formen auf derselben Folie bleiben unverändert.
{{% /alert %}}

### **Kombinations‑Diagramme erstellen**

Ein Kombinations‑Diagramm (oder Combo‑Diagramm) kombiniert zwei oder mehr Diagrammtypen in einem einzigen Diagramm. Dieses Diagramm ermöglicht es Ihnen, Unterschiede zwischen zwei oder mehr Datensätzen hervorzuheben, zu vergleichen oder zu untersuchen, wodurch Beziehungen zwischen ihnen identifiziert werden können.

![Das Kombinations‑Diagramm](combination_chart.png)

Dieses Beispiel kombiniert zwei Clustered‑Column‑Serien mit einer Linien‑Serie über vier Kategorien. Die Spalten verwenden die primäre vertikale Achse, während [setPlotOnSecondAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/setplotonsecondaxis/) die Linie auf einer zweiten vertikalen Achse rechts platziert. Die Hilfsfunktionen konfigurieren Titel, Legende, Achsenbeschriftungen und Gitternetzlinien.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function createComboChart()
{
    let presentation = new aspose.slides.Presentation();
    try
    {
        let chart = createChartWithFirstSeries(presentation.getSlides().get_Item(0));

        addSecondSeriesToChart(chart);
        addThirdSeriesToChart(chart);

        setPrimaryAxesFormat(chart);
        setSecondaryAxesFormat(chart);

        presentation.save("combo-chart.pptx", aspose.slides.SaveFormat.Pptx);
    }
    finally
    {
        presentation.dispose();
    }
}

function createChartWithFirstSeries(slide)
{
    let chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Chart Title");
    chart.getChartTitle().setOverlay(false);
    let portionFormat = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
    portionFormat.setFontBold(java.newByte(aspose.slides.NullableBool.False));
    portionFormat.setFontHeight(18);

    chart.getLegend().setPosition(aspose.slides.LegendPositionType.Bottom);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    let workbook = chart.getChartData().getChartDataWorkbook();
    let worksheetIndex = 0;

    let categoryCell = workbook.getCell(worksheetIndex, 1, 0, "Category 1");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(worksheetIndex, 2, 0, "Category 2");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(worksheetIndex, 3, 0, "Category 3");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(worksheetIndex, 4, 0, "Category 4");
    chart.getChartData().getCategories().add(categoryCell);

    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    let series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    series.getParentSeriesGroup().setOverlap(java.newByte(-25));
    series.getParentSeriesGroup().setGapWidth(220);

    let valueCell = workbook.getCell(worksheetIndex, 1, 1, 4.3);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 2, 1, 2.5);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 3, 1, 3.5);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 4, 1, 4.5);
    series.getDataPoints().addDataPointForBarSeries(valueCell);

    return chart;
}

function addSecondSeriesToChart(chart)
{
    let workbook = chart.getChartData().getChartDataWorkbook();
    let worksheetIndex = 0;

    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 2, "Series 2");
    let series = chart.getChartData().getSeries().add(seriesNameCell, aspose.slides.ChartType.ClusteredColumn);

    series.getParentSeriesGroup().setOverlap(java.newByte(-25));
    series.getParentSeriesGroup().setGapWidth(220);

    let valueCell = workbook.getCell(worksheetIndex, 1, 2, 2.4);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 2, 2, 4.4);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 3, 2, 1.8);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 4, 2, 2.8);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
}

function addThirdSeriesToChart(chart)
{
    let workbook = chart.getChartData().getChartDataWorkbook();
    let worksheetIndex = 0;

    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Series 3");
    let series = chart.getChartData().getSeries().add(seriesNameCell, aspose.slides.ChartType.Line);

    let valueCell = workbook.getCell(worksheetIndex, 1, 3, 2.0);
    series.getDataPoints().addDataPointForLineSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 2, 3, 2.0);
    series.getDataPoints().addDataPointForLineSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 3, 3, 3.0);
    series.getDataPoints().addDataPointForLineSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 4, 3, 5.0);
    series.getDataPoints().addDataPointForLineSeries(valueCell);

    series.setPlotOnSecondAxis(true);
}

function setPrimaryAxesFormat(chart)
{
    let horizontalAxis = chart.getAxes().getHorizontalAxis();
    horizontalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    horizontalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(horizontalAxis, "X Axis");

    let verticalAxis = chart.getAxes().getVerticalAxis();
    verticalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    verticalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(verticalAxis, "Y Axis 1");

    let majorGridLinesFormat = verticalAxis.getMajorGridLinesFormat().getLine().getFillFormat();
    majorGridLinesFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
    majorGridLinesFormat.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 217, 217, 217));
}

function setSecondaryAxesFormat(chart)
{
    let secondaryHorizontalAxis = chart.getAxes().getSecondaryHorizontalAxis();
    secondaryHorizontalAxis.setPosition(aspose.slides.AxisPositionType.Bottom);
    secondaryHorizontalAxis.setCrossType(aspose.slides.CrossesType.Maximum);
    secondaryHorizontalAxis.setVisible(false);
    secondaryHorizontalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryHorizontalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    let secondaryVerticalAxis = chart.getAxes().getSecondaryVerticalAxis();
    secondaryVerticalAxis.setPosition(aspose.slides.AxisPositionType.Right);
    secondaryVerticalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    secondaryVerticalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryVerticalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryVerticalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(secondaryVerticalAxis, "Y Axis 2");
}

function setAxisTitle(axis, axisTitle)
{
    axis.setTitle(true);
    axis.getTitle().setOverlay(false);
    let titlePortionFormat = axis.getTitle().addTextFrameForOverriding(axisTitle).getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
    titlePortionFormat.setFontBold(java.newByte(aspose.slides.NullableBool.False));
    titlePortionFormat.setFontHeight(12);
}

createComboChart();
```

## **Diagramme aktualisieren**

Aspose.Slides für Node.js über Java ermöglicht das Aktualisieren von PowerPoint‑Diagrammen durch Ändern von Diagrammdaten, Formatierungen und Stilen. Diese Funktionalität vereinfacht das Aktualisieren von Präsentationen mit dynamischem Inhalt und stellt sicher, dass Diagramme aktuelle Daten und visuelle Standards genau wiedergeben.

Dieses Beispiel aktualisiert das Diagramm mit dem Namen "My chart" auf der ersten Folie einer bestehenden Präsentation. Es erfordert zwei Spalten‑Serien mit je drei Datenpunkten, wobei Kategorienamen in Spalte A und Seriennamen in der ersten Zeile des ersten Arbeitsblatts stehen. Das Beispiel verwendet [getCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/getcell/) , um Arbeitsblatt‑Zellen zu ändern, aktualisiert Serienwerte, fügt eine dritte Serie hinzu und ändert das Diagramm zu gruppierten Zylindern über [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/settype/).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let chartName = "My chart";

let presentation = new aspose.slides.Presentation("ExistingChart.pptx");
try
{
    let slide = presentation.getSlides().get_Item(0);

    for (let i = 0; i < slide.getShapes().size(); i++)
    {
        let shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IChart") && chartName === shape.getName())
        {
            let chart = shape;
            let worksheetIndex = 0;

            let workbook = chart.getChartData().getChartDataWorkbook();

            workbook.getCell(worksheetIndex, 1, 0, "Modified Category 1");
            workbook.getCell(worksheetIndex, 2, 0, "Modified Category 2");

            let series = chart.getChartData().getSeries().get_Item(0);

            workbook.getCell(worksheetIndex, 0, 1, "New_Series 1");
            series.getDataPoints().get_Item(0).getValue().setData(90);
            series.getDataPoints().get_Item(1).getValue().setData(123);
            series.getDataPoints().get_Item(2).getValue().setData(44);

            series = chart.getChartData().getSeries().get_Item(1);

            workbook.getCell(worksheetIndex, 0, 2, "New_Series 2");
            series.getDataPoints().get_Item(0).getValue().setData(23);
            series.getDataPoints().get_Item(1).getValue().setData(67);
            series.getDataPoints().get_Item(2).getValue().setData(99);

            let seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Series 3");
            series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

            let valueCell = workbook.getCell(worksheetIndex, 1, 3, 20);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
            valueCell = workbook.getCell(worksheetIndex, 2, 3, 50);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
            valueCell = workbook.getCell(worksheetIndex, 3, 3, 30);
            series.getDataPoints().addDataPointForBarSeries(valueCell);

            chart.setType(aspose.slides.ChartType.ClusteredCylinder);
        }
    }

    presentation.save("AsposeChartModified.pptx", aspose.slides.SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

## **Datenbereich für ein Diagramm festlegen**

Um den bereits von einem bestehenden Diagramm genutzten Bereich zu prüfen, siehe [Retrieve a Chart's Data Range](/slides/de/nodejs-java/chart-workbook/#retrieve-a-charts-data-range).

Aspose.Slides für Node.js über Java bietet die Flexibilität, einen spezifischen Datenbereich aus einem Arbeitsblatt als Quelle für die Diagrammdaten festzulegen. Das bedeutet, dass Sie einen Teil Ihres Arbeitsblatts direkt dem Diagramm zuordnen können, wodurch Sie steuern, welche Zellen zu den Serien und Kategorien des Diagramms beitragen. Dadurch können Sie Diagramme leicht aktualisieren und mit den neuesten Datenänderungen in Ihrem Arbeitsblatt synchronisieren, sodass Ihre PowerPoint‑Präsentationen aktuelle und genaue Informationen widerspiegeln.

Dieses Beispiel verwendet [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/), um die Datenquelle des Diagramms mit dem Namen "My chart" auf der ersten Folie einer bestehenden Präsentation auf `Sheet1!A1:B4` zu setzen. Das Diagramm‑Arbeitsbuch muss dieses Arbeitsblatt und einen gefüllten Bereich mit einer Serien‑Überschrift in der ersten Zeile, Kategorienamen in Spalte A und drei Werten in Spalte B enthalten.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let chartName = "My chart";

let presentation = new aspose.slides.Presentation("ExistingChart.pptx");
try
{
    let slide = presentation.getSlides().get_Item(0);

    for (let i = 0; i < slide.getShapes().size(); i++)
    {
        let shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IChart") && chartName === shape.getName())
        {
            let chart = shape;
            chart.getChartData().setRange("Sheet1!A1:B4");
        }
    }

    presentation.save("SetDataRange.pptx", aspose.slides.SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

## **Standard‑Markierungen in Diagrammen verwenden**

Wenn Sie Standard‑Markierungen in Diagrammen verwenden, erhält jede Diagrammserie automatisch ein unterschiedliches Standard‑Markierungssymbol.

Dieses Beispiel verwendet [addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/), um ein Diagramm mit zwei Linien‑Serien und einer Legende zu erstellen. Die über [getMarker](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getmarker/) abgerufenen Markierungseinstellungen behalten die automatisch zugewiesenen Markierungssymbole. Die erste Serie enthält einen negativen Wert und einen fehlenden Wert, dargestellt durch `null`, während die zweite für jede Kategorie einen Wert hat.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try
{
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 10, 10, 400, 400);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    let workbook = chart.getChartData().getChartDataWorkbook();

    let seriesNameCell = workbook.getCell(0, 0, 1, "Series 1");
    let series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    let categoryCell = workbook.getCell(0, 1, 0, "C1");
    chart.getChartData().getCategories().add(categoryCell);
    let valueCell = workbook.getCell(0, 1, 1, 24);
    series.getDataPoints().addDataPointForLineSeries(valueCell);

    categoryCell = workbook.getCell(0, 2, 0, "C2");
    chart.getChartData().getCategories().add(categoryCell);
    valueCell = workbook.getCell(0, 2, 1, 23);
    series.getDataPoints().addDataPointForLineSeries(valueCell);

    categoryCell = workbook.getCell(0, 3, 0, "C3");
    chart.getChartData().getCategories().add(categoryCell);
    valueCell = workbook.getCell(0, 3, 1, -10);
    series.getDataPoints().addDataPointForLineSeries(valueCell);

    categoryCell = workbook.getCell(0, 4, 0, "C4");
    chart.getChartData().getCategories().add(categoryCell);
    valueCell = workbook.getCell(0, 4, 1, null);
    series.getDataPoints().addDataPointForLineSeries(valueCell);

    seriesNameCell = workbook.getCell(0, 0, 2, "Series 2");
    let secondSeries = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    valueCell = workbook.getCell(0, 1, 2, 30);
    secondSeries.getDataPoints().addDataPointForLineSeries(valueCell);
    valueCell = workbook.getCell(0, 2, 2, 10);
    secondSeries.getDataPoints().addDataPointForLineSeries(valueCell);
    valueCell = workbook.getCell(0, 3, 2, 60);
    secondSeries.getDataPoints().addDataPointForLineSeries(valueCell);
    valueCell = workbook.getCell(0, 4, 2, 40);
    secondSeries.getDataPoints().addDataPointForLineSeries(valueCell);

    chart.setLegend(true);
    chart.getLegend().setOverlay(false);

    presentation.save("DefaultMarkersInChart.pptx", aspose.slides.SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

## **FAQ**

**Welche Diagrammtypen werden von Aspose.Slides für Node.js über Java unterstützt?**

Aspose.Slides für Node.js über Java unterstützt eine breite Palette von Diagrammtypen, einschließlich Balken, Linie, Kreis, Fläche, Streu, Histogramm, Radar und vieler weiterer. Diese Flexibilität ermöglicht die Auswahl des am besten geeigneten Diagrammtyps für Ihre Datenvisualisierungs‑Bedürfnisse.

**Wie füge ich einer Folie ein neues Diagramm hinzu?**

Um ein Diagramm hinzuzufügen, erstellen Sie zunächst eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) , rufen die gewünschte Folie über ihren Index ab und rufen dann die Methode zum Hinzufügen eines Diagramms auf, wobei Sie den Diagrammtyp und die Anfangsdaten angeben. Dieser Vorgang integriert das Diagramm direkt in Ihre Präsentation.

**Wie kann ich die in einem Diagramm angezeigten Daten aktualisieren?**

Sie können die Daten eines Diagramms aktualisieren, indem Sie auf dessen Daten‑Arbeitsbuch ([ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/)) zugreifen, Standard‑Serien und -Kategorien löschen und anschließend Ihre benutzerdefinierten Daten hinzufügen. Dadurch können Sie das Diagramm programmgesteuert aktualisieren, um die neuesten Daten wiederzugeben.

**Ist es möglich, das Aussehen des Diagramms anzupassen?**

Ja, Aspose.Slides für Node.js über Java bietet umfangreiche Anpassungsoptionen. Sie können Farben, Schriftarten, Beschriftungen, Legenden und andere Formatierungselemente ändern, um das Aussehen des Diagramms an Ihre spezifischen Designanforderungen anzupassen.