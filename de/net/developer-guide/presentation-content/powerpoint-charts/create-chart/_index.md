---
title: PowerPoint-Präsentationsdiagramme in .NET erstellen oder aktualisieren
linktitle: Diagramme erstellen oder aktualisieren
type: docs
weight: 10
url: /de/net/create-chart/
keywords:
- Diagramm hinzufügen
- Diagramm erstellen
- Diagramm bearbeiten
- Diagramm ändern
- Diagramm aktualisieren
- Punktdiagramm
- Kreisdiagramm
- Liniendiagramm
- Baumdiagramm
- Börsendiagramm
- Box‑Und‑Whisker‑Diagramm
- Trichterdiagramm
- Sunburst‑Diagramm
- Histogramm
- Radardiagramm
- Mehrkategorien‑Diagramm
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erstellen und anpassen von Diagrammen in PowerPoint‑Präsentationen mit Aspose.Slides für .NET. Diagramme hinzufügen, formatieren und bearbeiten mit praktischen Code‑Beispielen in C#."
---
## **Überblick**

Dieser Artikel bietet eine umfassende Anleitung zum Erstellen und Anpassen von Diagrammen mit Aspose.Slides für .NET. Sie lernen, wie Sie programmgesteuert ein Diagramm zu einer Folie hinzufügen, es mit Daten füllen und verschiedene Formatierungsoptionen anwenden, um Ihren spezifischen Designanforderungen zu entsprechen. Im gesamten Artikel veranschaulichen detaillierte Codebeispiele jeden Schritt, vom Initialisieren der Präsentation und des Diagrammobjekts bis hin zur Konfiguration von Reihen, Achsen und Legenden. Wenn Sie dieser Anleitung folgen, erhalten Sie ein fundiertes Verständnis dafür, wie Sie die dynamische Diagrammerstellung in Ihre .NET‑Anwendungen integrieren und den Prozess der Erstellung datenbasierter Präsentationen optimieren.

## **Diagramm erstellen**

Diagramme helfen Menschen, Daten schnell zu visualisieren und Erkenntnisse zu gewinnen, die aus einer Tabelle oder einem Arbeitsblatt nicht sofort ersichtlich sind.

**Warum Diagramme erstellen?**

Mit Diagrammen können Sie:

* große Datenmengen auf einer einzigen Folie einer Präsentation aggregieren, kondensieren oder zusammenfassen;
* Muster und Trends in Daten aufdecken;
* die Richtung und das Momentum von Daten im Zeitverlauf oder in Bezug auf eine bestimmte Maßeinheit ableiten;
* Ausreißer, Aberrationen, Abweichungen, Fehler und unsinnige Daten erkennen;
* komplexe Daten kommunizieren oder präsentieren.

In PowerPoint können Sie Diagramme über die *Einfügen*-Funktion erstellen, die Vorlagen für viele Diagrammtypen bereitstellt. Mit Aspose.Slides können Sie sowohl reguläre Diagramme (basierend auf gängigen Diagrammtypen) als auch benutzerdefinierte Diagramme erstellen.

{{% alert color="info" title="Note" %}}

Verwenden Sie die [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/)‑Aufzählung im [Aspose.Slides.Charts](https://reference.aspose.com/slides/net/aspose.slides.charts/)-Namensraum. Die Werte dieser Aufzählung entsprechen verschiedenen Diagrammtypen.

{{% /alert %}}

### **Gruppierte Säulendiagramme erstellen**

Dieses Beispiel verwendet [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/), um ein gruppiertes Säulendiagramm zu erzeugen, das zwei Reihen über drei Kategorien vergleicht. Die Reihen verwenden rote bzw. grüne Füllungen, und einzelne Beschriftungen zeigen Kategorienamen, Reihen‑Namen und Werte an. Arbeitsblatt‑Index 0 bezieht sich auf das erste Blatt im eingebetteten Diagramm‑Arbeitsbuch.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 1, "Series 1");
chart.ChartData.Series.Add(seriesNameCell, chart.Type);
seriesNameCell = workbook.GetCell(worksheetIndex, 0, 2, "Series 2");
chart.ChartData.Series.Add(seriesNameCell, chart.Type);

var categoryCell = workbook.GetCell(worksheetIndex, 1, 0, "Category 1");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(worksheetIndex, 2, 0, "Category 2");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(worksheetIndex, 3, 0, "Category 3");
chart.ChartData.Categories.Add(categoryCell);

var series = chart.ChartData.Series[0];

var valueCell = workbook.GetCell(worksheetIndex, 1, 1, 20);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, 2, 1, 50);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, 3, 1, 30);
series.DataPoints.AddDataPointForBarSeries(valueCell);

series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;

series = chart.ChartData.Series[1];

valueCell = workbook.GetCell(worksheetIndex, 1, 2, 30);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, 2, 2, 10);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, 3, 2, 60);
series.DataPoints.AddDataPointForBarSeries(valueCell);

series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Green;

var label = series.DataPoints[0].Label;
label.DataLabelFormat.ShowCategoryName = true;

label = series.DataPoints[1].Label;
label.DataLabelFormat.ShowSeriesName = true;

label = series.DataPoints[2].Label;
label.DataLabelFormat.ShowValue = true;
label.DataLabelFormat.ShowSeriesName = true;
label.DataLabelFormat.Separator = "/";

presentation.Save("AsposeChart.pptx", SaveFormat.Pptx);
```

Das Ergebnis:

![Das gruppierte Säulendiagramm](clustered_column_chart.png)

### **Punkt­diagramme erstellen**

Punkt‑Diagramme (auch Scatter‑Plots oder X‑Y‑Diagramme genannt) werden häufig verwendet, um Muster zu prüfen oder Korrelationen zwischen zwei Variablen zu demonstrieren.

Verwenden Sie ein Punkt‑Diagramm, wenn:

* Sie gepaarte numerische Daten haben.
* Sie zwei Variablen besitzen, die gut zueinander passen.
* Sie bestimmen möchten, ob die beiden Variablen zusammenhängen.
* Sie eine unabhängige Variable haben, die für eine abhängige Variable mehrere Werte besitzt.

Dieses Beispiel zeichnet zwei Sätze von X‑Y‑Werten. Die erste Reihe verwendet gerade Linien mit Stern‑Markern, während die zweite glatte Linien mit Kreis‑Markern nutzt; beide verwenden eine [Size](https://reference.aspose.com/slides/net/aspose.slides.charts/imarker/size/) von 10. Die [Symbol](https://reference.aspose.com/slides/net/aspose.slides.charts/imarker/symbol/)-Eigenschaft steuert die Form des Markers.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 20, 20, 500, 300);

var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;

chart.ChartData.Series.Clear();

var seriesNameCell = workbook.GetCell(worksheetIndex, 1, 1, "Series 1");
chart.ChartData.Series.Add(seriesNameCell, chart.Type);
seriesNameCell = workbook.GetCell(worksheetIndex, 1, 3, "Series 2");
chart.ChartData.Series.Add(seriesNameCell, chart.Type);

var series = chart.ChartData.Series[0];

var xValueCell = workbook.GetCell(worksheetIndex, 2, 1, 1);
var yValueCell = workbook.GetCell(worksheetIndex, 2, 2, 3);
series.DataPoints.AddDataPointForScatterSeries(xValueCell, yValueCell);

xValueCell = workbook.GetCell(worksheetIndex, 3, 1, 2);
yValueCell = workbook.GetCell(worksheetIndex, 3, 2, 10);
series.DataPoints.AddDataPointForScatterSeries(xValueCell, yValueCell);

series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Star;

series = chart.ChartData.Series[1];

xValueCell = workbook.GetCell(worksheetIndex, 2, 3, 5);
yValueCell = workbook.GetCell(worksheetIndex, 2, 4, 2);
series.DataPoints.AddDataPointForScatterSeries(xValueCell, yValueCell);

xValueCell = workbook.GetCell(worksheetIndex, 3, 3, 3);
yValueCell = workbook.GetCell(worksheetIndex, 3, 4, 1);
series.DataPoints.AddDataPointForScatterSeries(xValueCell, yValueCell);

xValueCell = workbook.GetCell(worksheetIndex, 4, 3, 2);
yValueCell = workbook.GetCell(worksheetIndex, 4, 4, 2);
series.DataPoints.AddDataPointForScatterSeries(xValueCell, yValueCell);

xValueCell = workbook.GetCell(worksheetIndex, 5, 3, 5);
yValueCell = workbook.GetCell(worksheetIndex, 5, 4, 1);
series.DataPoints.AddDataPointForScatterSeries(xValueCell, yValueCell);

series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Circle;

presentation.Save("AsposeChart.pptx", SaveFormat.Pptx);
```

Das Ergebnis:

![Das Punktdiagramm](scatter_chart.png)

### **Kreis‑Diagramme erstellen**

Kreis‑Diagramme eignen sich am besten, um das Verhältnis von Teil zu Ganzem darzustellen, besonders wenn die Daten kategoriale Beschriftungen mit numerischen Werten enthalten. Enthält Ihre Datenmenge jedoch viele Teile oder Beschriftungen, sollten Sie ein Balken‑Diagramm in Betracht ziehen.

Dieses Beispiel erzeugt ein Kreis‑Diagramm mit drei Quartalswerten. Jeder Sektor hat eine benutzerdefinierte Füllung und Kontur, und die Beschriftungen zeigen verschiedene Kombinationen aus Werten, Prozentwerten und Reihen‑Informationen. Die [FirstSliceAngle](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/firstsliceangle/)-Eigenschaft legt fest, dass der erste Sektor bei 180 Grad beginnt.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 20, 20, 500, 300);

chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var categoryCell = workbook.GetCell(0, 1, 0, "1st Qtr");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, 2, 0, "2nd Qtr");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, 3, 0, "3rd Qtr");
chart.ChartData.Categories.Add(categoryCell);

var seriesNameCell = workbook.GetCell(0, 0, 1, "Series 1");
var series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

var valueCell = workbook.GetCell(worksheetIndex, 1, 1, 20);
series.DataPoints.AddDataPointForPieSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, 2, 1, 50);
series.DataPoints.AddDataPointForPieSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, 3, 1, 30);
series.DataPoints.AddDataPointForPieSeries(valueCell);

chart.ChartData.SeriesGroups[0].IsColorVaried = true;

var firstSlice = series.DataPoints[0];
firstSlice.Format.Fill.FillType = FillType.Solid;
firstSlice.Format.Fill.SolidFillColor.Color = Color.Cyan;

firstSlice.Format.Line.FillFormat.FillType = FillType.Solid;
firstSlice.Format.Line.FillFormat.SolidFillColor.Color = Color.Gray;
firstSlice.Format.Line.Width = 3.0;
firstSlice.Format.Line.Style = LineStyle.ThinThick;
firstSlice.Format.Line.DashStyle = LineDashStyle.LargeDash;

var secondSlice = series.DataPoints[1];
secondSlice.Format.Fill.FillType = FillType.Solid;
secondSlice.Format.Fill.SolidFillColor.Color = Color.Brown;

secondSlice.Format.Line.FillFormat.FillType = FillType.Solid;
secondSlice.Format.Line.FillFormat.SolidFillColor.Color = Color.Blue;
secondSlice.Format.Line.Width = 3.0;
secondSlice.Format.Line.Style = LineStyle.Single;
secondSlice.Format.Line.DashStyle = LineDashStyle.LargeDashDot;

var thirdSlice = series.DataPoints[2];
thirdSlice.Format.Fill.FillType = FillType.Solid;
thirdSlice.Format.Fill.SolidFillColor.Color = Color.Coral;

thirdSlice.Format.Line.FillFormat.FillType = FillType.Solid;
thirdSlice.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;
thirdSlice.Format.Line.Width = 2.0;
thirdSlice.Format.Line.Style = LineStyle.ThinThin;
thirdSlice.Format.Line.DashStyle = LineDashStyle.LargeDashDotDot;

var firstLabel = series.DataPoints[0].Label;
firstLabel.DataLabelFormat.ShowValue = true;

var secondLabel = series.DataPoints[1].Label;
secondLabel.DataLabelFormat.ShowValue = true;
secondLabel.DataLabelFormat.ShowLegendKey = true;
secondLabel.DataLabelFormat.ShowPercentage = true;

var thirdLabel = series.DataPoints[2].Label;
thirdLabel.DataLabelFormat.ShowSeriesName = true;
thirdLabel.DataLabelFormat.ShowPercentage = true;

series.Labels.DefaultDataLabelFormat.ShowLeaderLines = true;

chart.ChartData.SeriesGroups[0].FirstSliceAngle = 180;

presentation.Save("PieChart.pptx", SaveFormat.Pptx);
```

Das Ergebnis:

![Das Kreisdiagramm](pie_chart.png)

Um die Lesbarkeit von Beschriftungen außerhalb des Kreises zu verbessern, siehe [Format Leader Lines](/slides/de/net/chart-data-label/#format-leader-lines) für ein Beispiel, das Beschriftungen positioniert und die Linienfarbe, -breite, -transparenz und Strichart anpasst.

### **Liniendiagramme erstellen**

Liniendiagramme (auch Liniendiagramme genannt) eignen sich am besten, wenn Sie Änderungen von Werten über die Zeit hinweg darstellen möchten. Mit einem Liniendiagramm können Sie große Datenmengen gleichzeitig vergleichen, Änderungen und Trends im Zeitverlauf verfolgen, Anomalien in Datenreihen hervorheben und vieles mehr.

Dieses Beispiel verwendet [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/), um ein Liniendiagramm mit den Standard‑Reihen und -Kategorien zu erstellen und speichert die Präsentation als PPTX.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var lineChart = slide.Shapes.AddChart(ChartType.Line, 20, 20, 500, 300);

presentation.Save("lineChart.pptx", SaveFormat.Pptx);
```

Standardmäßig werden Punkte in einem Liniendiagramm durch gerade durchgehende Linien verbunden. Wenn Sie die Punkte stattdessen durch Striche verbinden möchten, setzen Sie [DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) auf einen Wert aus [LineDashStyle](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/):

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var lineChart = slide.Shapes.AddChart(ChartType.Line, 20, 20, 500, 300);

foreach (var series in lineChart.ChartData.Series)
{
    series.Format.Line.DashStyle = LineDashStyle.Dash;
}
```

Das Ergebnis:

![Das Liniendiagramm](line_chart.png)

### **Baum‑Diagramme erstellen**

Baum‑Diagramme eignen sich am besten für Verkaufsdaten, wenn Sie die relative Größe von Datenkategorien anzeigen und schnell auf besonders große Beiträge innerhalb jeder Kategorie aufmerksam machen wollen.

Dieses Beispiel erstellt ein Baum‑Diagramm mit acht Blättern, die in vier Stämmen und zwei Zweigen gruppiert sind. Die Methode [SetGroupingItem](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategorylevelsmanager/setgroupingitem/) ordnet Stämme auf Gruppierungsebene 1 und Zweige auf Ebene 2 zu. Werte bestimmen die relative Rechteckgröße, während Kategorien‑Beschriftungen und überlappende Eltern‑Beschriftungen die Hierarchie kennzeichnen.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Treemap, 20, 20, 500, 300);

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

// Zweig 1
var categoryCell = workbook.GetCell(0, "C1", "Leaf1");
var leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem1");
leaf.GroupingLevels.SetGroupingItem(2, "Branch1");

categoryCell = workbook.GetCell(0, "C2", "Leaf2");
chart.ChartData.Categories.Add(categoryCell);

categoryCell = workbook.GetCell(0, "C3", "Leaf3");
leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem2");

categoryCell = workbook.GetCell(0, "C4", "Leaf4");
chart.ChartData.Categories.Add(categoryCell);

// Zweig 2
categoryCell = workbook.GetCell(0, "C5", "Leaf5");
leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem3");
leaf.GroupingLevels.SetGroupingItem(2, "Branch2");

categoryCell = workbook.GetCell(0, "C6", "Leaf6");
chart.ChartData.Categories.Add(categoryCell);

categoryCell = workbook.GetCell(0, "C7", "Leaf7");
leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem4");

categoryCell = workbook.GetCell(0, "C8", "Leaf8");
chart.ChartData.Categories.Add(categoryCell);

var series = chart.ChartData.Series.Add(ChartType.Treemap);
series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
var valueCell = workbook.GetCell(0, "D1", 4);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);
valueCell = workbook.GetCell(0, "D2", 5);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);
valueCell = workbook.GetCell(0, "D3", 3);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);
valueCell = workbook.GetCell(0, "D4", 6);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);
valueCell = workbook.GetCell(0, "D5", 9);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);
valueCell = workbook.GetCell(0, "D6", 9);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);
valueCell = workbook.GetCell(0, "D7", 4);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);
valueCell = workbook.GetCell(0, "D8", 3);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);

series.ParentLabelLayout = ParentLabelLayoutType.Overlapping;

presentation.Save("Treemap.pptx", SaveFormat.Pptx);
```

Das Ergebnis:

![Das Baumdiagramm](treemap_chart.png)

### **Wasserfall‑Diagramme erstellen**

Ein Wasserfall‑Diagramm zeigt, wie positive und negative Veränderungen zu einem Endwert beitragen. Beispielsweise kann eine Gewinn‑Aufschlüsselung mit Umsatz beginnen, Kosten abziehen und sonstige Erträge hinzufügen. Änderungs‑Spalten schweben zwischen den vorherigen und den neuen Laufwerten, während Gesamtsäulen von 0 bis zum akkumulierten Wert reichen.

Das folgende Beispiel verwendet Beträge in Tausend US‑Dollar:

| Kategorie | Arbeitsblattwert | Spaltentyp |
| --- | ---: | --- |
| Umsatz | 1000 | Zunahme |
| Herstellungskosten | -400 | Abnahme |
| Bruttogewinn | 600 | Zwischensumme |
| Betriebskosten | -200 | Abnahme |
| Sonstige Erträge | 50 | Zunahme |
| Nettogewinn | 450 | Endsumme |

Um einen Punkt als Zwischensumme oder Endsumme zu kennzeichnen, setzen Sie dessen [SetAsTotal](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatapoint/setastotal/)‑Eigenschaft auf `true`. Geben Sie den tatsächlichen akkumulierten Betrag in der entsprechenden Arbeitsblatt‑Zelle an: `600` für den Bruttogewinn (`1000 - 400`) und `450` für den Nettogewinn (`600 - 200 + 50`). Die Eigenschaft markiert die Spalte als Summe; sie berechnet den Zellenwert nicht. Verwenden Sie nicht 0 als Platzhalter und geben Sie keinen anderen Änderungswert für einen Summen‑Punkt an. Eine Gesamtsäule zeigt den akkumulierten Wert, ohne ihn erneut zum Laufwert hinzuzufügen.

Dieses vollständige C#‑Beispiel erstellt ein Diagramm mit dem `Waterfall`‑Mitglied von [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/), löscht die Standarddaten und füllt das eingebettete Arbeitsbuch. Arbeitsblatt‑Index `0` wählt das erste Arbeitsblatt; Spalte A enthält Kategorienamen und Spalte B die Werte. Jeder Werte‑Zelle wird über [AddDataPointForWaterfallSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/adddatapointforwaterfallseries/) hinzugefügt. Die null‑basierten Punkt‑Indizes `2` und `5` identifizieren die Zwischensumme bzw. die Endsumme. Das Aktivieren von [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) zeigt die Beträge auf den Säulen an. Es wird keine Eingabe‑Präsentation oder Arbeitsbuch benötigt.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Waterfall, 20, 20, 680, 200);

chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("Profit breakdown (USD thousands)");
chart.ChartTitle.Overlay = false;
chart.HasLegend = false;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;

workbook.Clear(worksheetIndex);

var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 1, "Profit");
var series = chart.ChartData.Series.Add(seriesNameCell, ChartType.Waterfall);
var categories = new[] { "Revenue", "Cost of sales", "Gross profit", "Operating expenses", "Other income", "Net profit" };
var values = new double[] { 1000, -400, 600, -200, 50, 450 };

for (var i = 0; i < categories.Length; i++)
{
    var categoryCell = workbook.GetCell(worksheetIndex, i + 1, 0, categories[i]);
    chart.ChartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(worksheetIndex, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForWaterfallSeries(valueCell);
}

// Die dritten und sechsten Punkte stellen Gesamtsummen dar, nicht zusätzliche Änderungen.
series.DataPoints[2].SetAsTotal = true;
series.DataPoints[5].SetAsTotal = true;
series.ShowConnectorLines = true;
series.Labels.DefaultDataLabelFormat.ShowValue = true;

presentation.Save("WaterfallChart.pptx", SaveFormat.Pptx);
```

Setzen Sie die Reihen‑Ebene‑Eigenschaft [ShowConnectorLines](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseries/showconnectorlines/) auf `true`, um Linien zwischen aufeinanderfolgenden Säulen anzuzeigen und den Laufwert leichter nachvollziehen zu können. Um diese Linien zu verbergen, ersetzen Sie die Zuweisung im Beispiel durch `series.ShowConnectorLines = false;` vor dem Speichern. Dies ändert nur die Sichtbarkeit der Linie, nicht die Daten oder Summen.

Die gespeicherte Präsentation zeigt einen Bruttogewinn von 600 und einen Nettogewinn von 450, wobei beide Summen von 0 ausgehend gezeichnet werden:

![Wasserfall‑Diagramm mit Umsatz, Kosten, Bruttogewinn 600 und Nettogewinn 450, mit Werte‑Beschriftungen und Verbindungs‑Linien](waterfall_chart.png)

### **Börsen‑Diagramme erstellen**

Börsen‑Diagramme werden verwendet, um Finanzdaten wie Eröffnungs‑, Hoch‑, Tief‑ und Schlusskurse darzustellen und so Markt‑Trends sowie Volatilität zu analysieren. Sie bieten wichtige Einblicke in die Kursentwicklung und unterstützen Investoren und Analysten bei fundierten Entscheidungen.

Dieses Beispiel erzeugt ein Open‑High‑Low‑Close‑Diagramm mit vier Reihen in dieser Reihenfolge und drei Kategorien. Die Eigenschaft [HasUpDownBars](https://reference.aspose.com/slides/net/aspose.slides.charts/iupdownbarsmanager/hasupdownbars/) aktiviert Auf‑/Ab‑Balken, und [HiLowLinesFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/hilowlinesformat/) steuert die Hoch‑Tief‑Linien, die die Kursbereiche anzeigen, während die einzelnen Reihen‑Linien und feine horizontale Gitternetzlinien ausgeblendet werden.

Der [UpDownBars](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/updownbars/)-Manager stellt separate [UpBarsFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iupdownbarsmanager/upbarsformat/)‑ und [DownBarsFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iupdownbarsmanager/downbarsformat/)‑Objekte bereit. Verwenden Sie die jeweiligen [Fill](https://reference.aspose.com/slides/net/aspose.slides.charts/iformat/fill/)‑ und [Line](https://reference.aspose.com/slides/net/aspose.slides.charts/iformat/line/)-Eigenschaften, um Füllung und Kontur unabhängig zu setzen. Dieses Beispiel nutzt grüne Balken mit dunkelgrünen Konturen für steigende Intervalle und orange‑rot für fallende Intervalle.

Geben Sie für jede Kategorie numerische Werte für alle vier Reihen an, wobei Hoch und Tief Open und Close umschließen. Die Balken vergleichen Close mit Open **innerhalb derselben Kategorie**, nicht mit der vorherigen Kategorie: A fällt von 72 auf 25, während B von 25 auf 38 und C von 38 auf 50 steigt. Gleiche Open‑ und Close‑Werte erzeugen keinen sichtbaren gefüllten Abschnitt. Auf‑/Ab‑Balken erstrecken sich über Open‑Close; Hoch‑Tief‑Linien über Low‑High. Diese Balken gehören zur Reihen‑Gruppe und sind keine normalen Balkendiagram‑Reihen.

Diese Formatierung funktioniert auch bei [Line und LineWithMarkers](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/)-Diagrammen, die mindestens zwei Reihen in derselben Gruppe besitzen und für jede Kategorie numerische Werte bereitstellen. Für diese nicht‑gestapelten Liniendiagramme vergleichen Auf‑/Ab‑Balken die erste und letzte Reihe: ein höherer letzter Wert erzeugt einen Auf‑Balken, ein niedrigerer einen Ab‑Balken. Das Umkehren der Reihen kehrt die Klassifizierung um. Das nachfolgende Beispiel verwendet [OpenHighLowClose](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/); gehen Sie nicht davon aus, dass andere Börsen‑, gestapelten‑Lini‑ oder 3D‑Varianten dieselbe Datenanordnung oder Intervallinterpretation verwenden.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.OpenHighLowClose, 20, 20, 500, 150, false);

var workbook = chart.ChartData.ChartDataWorkbook;

var categoryCell = workbook.GetCell(0, 1, 0, "A");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, 2, 0, "B");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, 3, 0, "C");
chart.ChartData.Categories.Add(categoryCell);

var seriesNameCell = workbook.GetCell(0, 0, 1, "Open");
chart.ChartData.Series.Add(seriesNameCell, ChartType.OpenHighLowClose);
seriesNameCell = workbook.GetCell(0, 0, 2, "High");
chart.ChartData.Series.Add(seriesNameCell, ChartType.OpenHighLowClose);
seriesNameCell = workbook.GetCell(0, 0, 3, "Low");
chart.ChartData.Series.Add(seriesNameCell, ChartType.OpenHighLowClose);
seriesNameCell = workbook.GetCell(0, 0, 4, "Close");
chart.ChartData.Series.Add(seriesNameCell, ChartType.OpenHighLowClose);

var series = chart.ChartData.Series[0];
var valueCell = workbook.GetCell(0, 1, 1, 72);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 2, 1, 25);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 3, 1, 38);
series.DataPoints.AddDataPointForStockSeries(valueCell);

series = chart.ChartData.Series[1];
valueCell = workbook.GetCell(0, 1, 2, 172);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 2, 2, 57);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 3, 2, 57);
series.DataPoints.AddDataPointForStockSeries(valueCell);

series = chart.ChartData.Series[2];
valueCell = workbook.GetCell(0, 1, 3, 12);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 2, 3, 12);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 3, 3, 13);
series.DataPoints.AddDataPointForStockSeries(valueCell);

series = chart.ChartData.Series[3];
valueCell = workbook.GetCell(0, 1, 4, 25);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 2, 4, 38);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 3, 4, 50);
series.DataPoints.AddDataPointForStockSeries(valueCell);

var upDownBars = chart.ChartData.SeriesGroups[0].UpDownBars;
upDownBars.HasUpDownBars = true;

upDownBars.UpBarsFormat.Fill.FillType = FillType.Solid;
upDownBars.UpBarsFormat.Fill.SolidFillColor.Color = Color.LimeGreen;
upDownBars.UpBarsFormat.Line.FillFormat.FillType = FillType.Solid;
upDownBars.UpBarsFormat.Line.FillFormat.SolidFillColor.Color = Color.DarkGreen;
upDownBars.UpBarsFormat.Line.Width = 2;

upDownBars.DownBarsFormat.Fill.FillType = FillType.Solid;
upDownBars.DownBarsFormat.Fill.SolidFillColor.Color = Color.OrangeRed;
upDownBars.DownBarsFormat.Line.FillFormat.FillType = FillType.Solid;
upDownBars.DownBarsFormat.Line.FillFormat.SolidFillColor.Color = Color.DarkRed;
upDownBars.DownBarsFormat.Line.Width = 2;

chart.ChartData.SeriesGroups[0].HiLowLinesFormat.Line.FillFormat.FillType = FillType.Solid;

foreach (var stockSeries in chart.ChartData.Series)
{
    stockSeries.Format.Line.FillFormat.FillType = FillType.NoFill;
}

chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

presentation.Save("Stock-chart.pptx", SaveFormat.Pptx);
```

Das Ergebnis, exportiert aus PowerPoint:

![Börsen‑Diagramm mit einem orange‑rot fallenden Intervall für A und grünen steigenden Intervallen für B und C](stock_chart.png)

### **Box‑Und‑Whisker‑Diagramme erstellen**

Box‑Und‑Whisker‑Diagramme werden verwendet, um die Verteilung von Daten darzustellen, indem zentrale statistische Kennzahlen wie Median, Quartile und mögliche Ausreißer zusammengefasst werden. Sie sind besonders nützlich in explorativer Datenanalyse und statistischen Studien, um Datenvariabilität schnell zu erfassen und Anomalien zu erkennen.

Dieses Beispiel erzeugt ein Box‑Und‑Whisker‑Diagramm aus sechs Werten. Die Eigenschaft [QuartileMethod](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/quartilemethod/) wählt die exklusive Quartilsberechnung. Das Beispiel aktiviert außerdem Mittelwert‑Linien, Mittelwert‑Marker, innere Punkte und Ausreißer‑Punkte.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.BoxAndWhisker, 20, 20, 500, 300);

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var categoryCell = workbook.GetCell(0, "A1", "Category 1");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A2", "Category 2");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A3", "Category 3");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A4", "Category 4");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A5", "Category 5");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A6", "Category 6");
chart.ChartData.Categories.Add(categoryCell);

var series = chart.ChartData.Series.Add(ChartType.BoxAndWhisker);

series.QuartileMethod = QuartileMethodType.Exclusive;
series.ShowMeanLine = true;
series.ShowMeanMarkers = true;
series.ShowInnerPoints = true;
series.ShowOutlierPoints = true;

var valueCell = workbook.GetCell(0, "B1", 15);
series.DataPoints.AddDataPointForBoxAndWhiskerSeries(valueCell);
valueCell = workbook.GetCell(0, "B2", 41);
series.DataPoints.AddDataPointForBoxAndWhiskerSeries(valueCell);
valueCell = workbook.GetCell(0, "B3", 16);
series.DataPoints.AddDataPointForBoxAndWhiskerSeries(valueCell);
valueCell = workbook.GetCell(0, "B4", 10);
series.DataPoints.AddDataPointForBoxAndWhiskerSeries(valueCell);
valueCell = workbook.GetCell(0, "B5", 23);
series.DataPoints.AddDataPointForBoxAndWhiskerSeries(valueCell);
valueCell = workbook.GetCell(0, "B6", 16);
series.DataPoints.AddDataPointForBoxAndWhiskerSeries(valueCell);

presentation.Save("BoxAndWhisker.pptx", SaveFormat.Pptx);
```

### **Trichter‑Diagramme erstellen**

Trichter‑Diagramme visualisieren Prozesse mit aufeinanderfolgenden Stufen, bei denen das Datenvolumen von einer Stufe zur nächsten abnimmt. Sie eignen sich besonders zur Analyse von Konversionsraten, zur Identifizierung von Engpässen und zur Verfolgung der Effizienz von Vertriebs‑ oder Marketing‑Prozessen.

Dieses Beispiel verwendet [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/), um einem bestehenden Präsentations‑Slide ein Trichter‑Diagramm hinzuzufügen. Es ersetzt die Standarddaten durch sechs Kategorien mit Werten von 50 bis 500 und speichert die aktualisierte Präsentation. Die Eingabe‑Präsentation muss mindestens eine Folie enthalten.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("test.pptx");
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Funnel, 50, 50, 500, 400);

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var categoryCell = workbook.GetCell(0, "A1", "Category 1");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A2", "Category 2");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A3", "Category 3");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A4", "Category 4");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A5", "Category 5");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A6", "Category 6");
chart.ChartData.Categories.Add(categoryCell);

var series = chart.ChartData.Series.Add(ChartType.Funnel);

var valueCell = workbook.GetCell(0, "B1", 50);
series.DataPoints.AddDataPointForFunnelSeries(valueCell);
valueCell = workbook.GetCell(0, "B2", 100);
series.DataPoints.AddDataPointForFunnelSeries(valueCell);
valueCell = workbook.GetCell(0, "B3", 200);
series.DataPoints.AddDataPointForFunnelSeries(valueCell);
valueCell = workbook.GetCell(0, "B4", 300);
series.DataPoints.AddDataPointForFunnelSeries(valueCell);
valueCell = workbook.GetCell(0, "B5", 400);
series.DataPoints.AddDataPointForFunnelSeries(valueCell);
valueCell = workbook.GetCell(0, "B6", 500);
series.DataPoints.AddDataPointForFunnelSeries(valueCell);

presentation.Save("Funnel.pptx", SaveFormat.Pptx);
```

Das Ergebnis:

![Das Trichterdiagramm](funnel_chart.png)

### **Sunburst‑Diagramme erstellen**

Sunburst‑Diagramme visualisieren hierarchische Daten, wobei Ebenen als konzentrische Ringe dargestellt werden. Sie veranschaulichen Teil‑zu‑Ganz‑Beziehungen und eignen sich ideal für die kompakte Darstellung verschachtelter Kategorien und Unterkategorien.

Dieses Beispiel erzeugt ein Sunburst‑Diagramm mit acht Blättern, die in vier Stämmen und zwei Zweigen gruppiert sind. Die Methode [SetGroupingItem](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategorylevelsmanager/setgroupingitem/) ordnet Stämme auf Gruppierungsebene 1 und Zweige auf Ebene 2 zu. Kategorien‑Beschriftungen identifizieren die Segmente, und die Werte bestimmen die relative Größe.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Sunburst, 20, 20, 500, 300);

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

// Zweig 1
var categoryCell = workbook.GetCell(0, "C1", "Leaf1");
var leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem1");
leaf.GroupingLevels.SetGroupingItem(2, "Branch1");

categoryCell = workbook.GetCell(0, "C2", "Leaf2");
chart.ChartData.Categories.Add(categoryCell);

categoryCell = workbook.GetCell(0, "C3", "Leaf3");
leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem2");

categoryCell = workbook.GetCell(0, "C4", "Leaf4");
chart.ChartData.Categories.Add(categoryCell);

// Zweig 2
categoryCell = workbook.GetCell(0, "C5", "Leaf5");
leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem3");
leaf.GroupingLevels.SetGroupingItem(2, "Branch2");

categoryCell = workbook.GetCell(0, "C6", "Leaf6");
chart.ChartData.Categories.Add(categoryCell);

categoryCell = workbook.GetCell(0, "C7", "Leaf7");
leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem4");

categoryCell = workbook.GetCell(0, "C8", "Leaf8");
chart.ChartData.Categories.Add(categoryCell);

var series = chart.ChartData.Series.Add(ChartType.Sunburst);
series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
var valueCell = workbook.GetCell(0, "D1", 4);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);
valueCell = workbook.GetCell(0, "D2", 5);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);
valueCell = workbook.GetCell(0, "D3", 3);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);
valueCell = workbook.GetCell(0, "D4", 6);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);
valueCell = workbook.GetCell(0, "D5", 9);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);
valueCell = workbook.GetCell(0, "D6", 9);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);
valueCell = workbook.GetCell(0, "D7", 4);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);
valueCell = workbook.GetCell(0, "D8", 3);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);

presentation.Save("Sunburst.pptx", SaveFormat.Pptx);
```

Das Ergebnis:

![Das Sunburst‑Diagramm](sunburst_chart.png)

### **Histogramm‑Diagramme erstellen**

Histogramm‑Diagramme zeigen, wie numerische Werte über Intervalle (Bins) verteilt sind. Für monatliche Berichte zu Bestell‑Bearbeitungszeiten verwenden Sie dieselbe Bin‑Breite und dieselben Schwellenwerte, um Intervalle konsistent zu halten und Verteilungen leichter zu vergleichen.

Setzen Sie die horizontale Achsen‑[AggregationType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/aggregationtype/) auf einen Modus aus [AxisAggregationType](https://reference.aspose.com/slides/net/aspose.slides.charts/axisaggregationtype/). [BinWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/binwidth/) gilt nur für `ByBinWidth`; [NumberOfBins](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/numberofbins/) gilt nur für `ByNumberOfBins`. Verwenden Sie `Automatic`, damit das Diagramm die Bins selbst wählt.

#### **Feste Bin‑Breite verwenden**

Dieses Beispiel gruppiert Bearbeitungszeiten in 10‑Minute‑Intervalle, mit separaten Bins für Zeiten ≤ 10 Minuten und > 40 Minuten. Aktivieren Sie diese Bins mit [IsUnderflowBin](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isunderflowbin/) und [IsOverflowBin](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isoverflowbin/). Wenn Sie explizite Schwellenwerte für [UnderflowBin](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/underflowbin/) und [OverflowBin](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/overflowbin/) angeben, setzen Sie [IsAutomaticUnderflowBin](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticunderflowbin/) und [IsAutomaticOverflowBin](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticoverflowbin/) auf `false`.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Histogram, 20, 20, 680, 200);

chart.HasLegend = false;
chart.HasTitle = false;

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.Histogram);
double[] values = { 5, 10, 10, 11, 15, 20, 20, 21, 25, 30, 30, 31, 35, 40, 40, 41, 50 };
for (var i = 0; i < values.Length; i++)
{
    var valueCell = workbook.GetCell(0, i, 0, values[i]);
    series.DataPoints.AddDataPointForHistogramSeries(valueCell);
}

var axis = chart.Axes.HorizontalAxis;
axis.AggregationType = AxisAggregationType.ByBinWidth;
axis.BinWidth = 10;
axis.IsUnderflowBin = true;
axis.IsAutomaticUnderflowBin = false;
axis.UnderflowBin = 10;
axis.IsOverflowBin = true;
axis.IsAutomaticOverflowBin = false;
axis.OverflowBin = 40;

presentation.Save("Histogram-bin-width.pptx", SaveFormat.Pptx);
```

Die in PowerPoint angezeigte Präsentation zeigt Bin‑Anzahlen von **3, 4, 4, 4 und 2**. Der Unterlauf‑Bin enthält `5, 10, 10`, sodass seine Schwelle inklusiv ist. Der Überlauf‑Bin enthält nur `41, 50`, sodass seine Schwelle exklusiv ist; beide Werte gleich `40` bleiben im vorherigen Intervall. Die inneren Bins enthalten Werte > unterer Grenze und ≤ oberer Grenze.

![Histogramm mit 10‑Minute‑Bins und expliziten Unter‑ und Überlauf‑Schwellenwerten](histogram_bin_width.png)

#### **Anzahl der Bins festlegen**

Für ein festes Detailniveau statt fester Intervalle fordern Sie fünf Bins für dieselben Daten an. Dieses Beispiel lässt Unter‑ und Überlauf‑Bins deaktiviert. Das Diagramm ermittelt die Breite aus dem Datenbereich, sodass Grenzen zwischen Berichten variieren können.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Histogram, 20, 20, 680, 200);

chart.HasLegend = false;
chart.HasTitle = false;

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.Histogram);
double[] values = { 5, 10, 10, 11, 15, 20, 20, 21, 25, 30, 30, 31, 35, 40, 40, 41, 50 };
for (var i = 0; i < values.Length; i++)
{
    var valueCell = workbook.GetCell(0, i, 0, values[i]);
    series.DataPoints.AddDataPointForHistogramSeries(valueCell);
}

var axis = chart.Axes.HorizontalAxis;
axis.AggregationType = AxisAggregationType.ByNumberOfBins;
axis.NumberOfBins = 5;

presentation.Save("Histogram-bin-count.pptx", SaveFormat.Pptx);
```

Die fünf Bins haben Anzahlen von **4, 4, 4, 4 und 1**. Vergleichen Sie diese Verteilung mit dem Ergebnis der festen Breite oben: Die Eingabewerte sind identisch, aber die Grenzen unterscheiden sich.

![Histogramm mit fünf Bins, berechnet aus denselben Daten](histogram_bin_count.png)

### **Radar‑Diagramme erstellen**

Radar‑Diagramme visualisieren multivariate Daten in einem zweidimensionalen Format und ermöglichen den einfachen Vergleich mehrerer Variablen gleichzeitig. Sie sind besonders nützlich, um Muster, Stärken und Schwächen über mehrere Leistungs‑Metriken oder Attribute hinweg zu erkennen.

Dieses Beispiel verwendet [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/), um ein Radar‑Diagramm mit den Standard‑Reihen und -Kategorien zu erzeugen und speichert die Präsentation als PPTX.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddChart(ChartType.Radar, 20, 20, 500, 300);

presentation.Save("Radar-chart.pptx", SaveFormat.Pptx);
```

Das Ergebnis:

![Das Radar‑Diagramm](radar_chart.png)

### **Mehrkategorien‑Diagramme erstellen**

Mehrkategorien‑Diagramme dienen zur Darstellung von Daten, die mehr als eine kategoriale Gruppierung enthalten, sodass Sie Werte über mehrere Dimensionen hinweg vergleichen können. Sie sind besonders hilfreich, wenn Sie Trends und Zusammenhänge innerhalb komplexer, mehrschichtiger Datensätze analysieren müssen.

Dieses Beispiel erzeugt ein gruppiertes Säulendiagramm mit acht Kategorien, die in vier Paare angeordnet sind. Die Methode [SetGroupingItem](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategorylevelsmanager/setgroupingitem/) gibt jedem Paar ein gemeinsames Label auf Gruppierungsebene 1, wodurch eine Kategorienachse mit einzelnen und Gruppen‑Labels entsteht.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var worksheetIndex = 0;

var categoryCell = workbook.GetCell(0, "c2", "A");
var category = chart.ChartData.Categories.Add(categoryCell);
category.GroupingLevels.SetGroupingItem(1, "Group1");
categoryCell = workbook.GetCell(0, "c3", "B");
category = chart.ChartData.Categories.Add(categoryCell);

categoryCell = workbook.GetCell(0, "c4", "C");
category = chart.ChartData.Categories.Add(categoryCell);
category.GroupingLevels.SetGroupingItem(1, "Group2");
categoryCell = workbook.GetCell(0, "c5", "D");
category = chart.ChartData.Categories.Add(categoryCell);

categoryCell = workbook.GetCell(0, "c6", "E");
category = chart.ChartData.Categories.Add(categoryCell);
category.GroupingLevels.SetGroupingItem(1, "Group3");
categoryCell = workbook.GetCell(0, "c7", "F");
category = chart.ChartData.Categories.Add(categoryCell);

categoryCell = workbook.GetCell(0, "c8", "G");
category = chart.ChartData.Categories.Add(categoryCell);
category.GroupingLevels.SetGroupingItem(1, "Group4");
categoryCell = workbook.GetCell(0, "c9", "H");
category = chart.ChartData.Categories.Add(categoryCell);

var seriesNameCell = workbook.GetCell(0, "D1", "Series 1");
var series = chart.ChartData.Series.Add(seriesNameCell, ChartType.ClusteredColumn);

var valueCell = workbook.GetCell(worksheetIndex, "D2", 10);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, "D3", 20);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, "D4", 30);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, "D5", 40);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, "D6", 50);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, "D7", 60);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, "D8", 70);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, "D9", 80);
series.DataPoints.AddDataPointForBarSeries(valueCell);

presentation.Save("AsposeChart.pptx", SaveFormat.Pptx);
```

Das Ergebnis:

![Das Mehrkategorien‑Diagramm](multi_category_chart.png)

#### **Ein Quartals‑Label entfernen**

Laden Sie [quarters.pptx](quarters.pptx) herunter und legen Sie die Datei im Arbeitsverzeichnis ab. Das Diagramm zeigt neun Monate und eine einzelne Verkaufs‑Reihe mit Werten von 10 bis 18. Die Kategorienachse hat drei Quartals‑Labels: Q1 deckt Jan‑Mär, Q2 Apr‑Jun und Q3 Jul‑Sep ab.

April ist die vierte Kategorie und wurde explizit für Q2 gesetzt. Rufen Sie [DeleteGroupingItem](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategorylevelsmanager/deletegroupingitem/) auf Aprils [GroupingLevels](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategory/groupinglevels/)-Sammlung auf. Die Ebene ist relativ zu April: Ebene 1 ist das Quartal, Ebene 0 der Monat selbst. Die Methode kann das Blatt‑Element auf Ebene 0 nicht entfernen.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (var presentation = new Presentation("quarters.pptx"))
{
    var chart = (IChart)presentation.Slides[0].Shapes[0];
    var april = chart.ChartData.Categories[3];
    april.GroupingLevels.DeleteGroupingItem(1);

    presentation.Save("quarters-updated.pptx", SaveFormat.Pptx);
}

using var reopened = new Presentation("quarters-updated.pptx");
var updatedChart = (IChart)reopened.Slides[0].Shapes[0];
var data = updatedChart.ChartData;

Console.WriteLine(string.Join(", ", data.Categories.Select(month => month.AsCell.Value)));
Console.WriteLine(string.Join(", ", data.Series[0].DataPoints.Select(point => point.Value.Data)));
```

Das erneut geöffnete Diagramm gibt die ursprünglichen Monate (`Jan, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep`) und Verkaufswerte (`10, 11, 12, 13, 14, 15, 16, 17, 18`) in derselben Reihenfolge aus. Öffnen Sie `quarters-updated.pptx` in PowerPoint, um die Achsen‑Beschriftungen zu vergleichen. Das Q2‑Label und die Gruppen‑Grenze vor April verschwinden, sodass Q1 von Januar bis Juni reicht. Q3 beginnt weiterhin im Juli.

![Quartals‑Labels vor und nach dem Entfernen. Links: Q2 erstreckt sich über April bis Juni. Rechts: Q1 erstreckt sich über Januar bis Juni.](quarter-label-comparison.png)

### **Karten‑Diagramme erstellen**

Karten‑Diagramme visualisieren geografische Daten, indem Informationen bestimmten Standorten wie Ländern, Bundesländern oder Städten zugeordnet werden. Sie sind besonders nützlich, um regionale Trends, demografische Daten und räumliche Verteilungen klar und ansprechend darzustellen.

Dieses Beispiel verwendet [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/), um ein Karten‑Diagramm mit den Standard‑Geodaten zu erzeugen und speichert es zur Ansicht in PowerPoint.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Map, 20, 20, 500, 300);

presentation.Save("mapChart.pptx", SaveFormat.Pptx);
```

Das Ergebnis:

![Das Karten‑Diagramm](map_chart.png)

{{% alert color="info" title="Note" %}}

Das obige Bild zeigt die gespeicherte Präsentation, geöffnet in PowerPoint. Aspose.Slides schreibt das Karten‑Diagramm und dessen Daten korrekt, zeichnet jedoch selbst keine Karten‑Diagramme: Wenn eine Folie mit einem solchen Diagramm zu einem Bild gerendert oder in PDF bzw. SVG konvertiert wird, erscheint der Diagrammbereich leer. Andere Formen auf derselben Folie bleiben unverändert.

{{% /alert %}}

### **Kombinations‑Diagramme erstellen**

Ein Kombinations‑Diagramm (oder Combo‑Diagramm) kombiniert zwei oder mehr Diagrammtypen in einem einzigen Diagramm. Dieses Diagramm ermöglicht es, Unterschiede zwischen zwei oder mehr Datensätzen hervorzuheben, zu vergleichen oder zu untersuchen und so Beziehungen zwischen ihnen zu erkennen.

![Das Kombinations‑Diagramm](combination_chart.png)

Dieses Beispiel kombiniert zwei gruppierte Säulen‑Reihen mit einer Linien‑Reihe über vier Kategorien. Die Säulen verwenden die primäre vertikale Achse, während [PlotOnSecondAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/plotonsecondaxis/) die Linie auf eine sekundäre vertikale Achse rechts legt. Hilfsfunktionen konfigurieren Titel, Legende, Achsen‑Beschriftungen und Gitternetzlinien.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

CreateComboChart();

static void CreateComboChart()
{
    using var presentation = new Presentation();
    var chart = CreateChartWithFirstSeries(presentation.Slides[0]);

    AddSecondSeriesToChart(chart);
    AddThirdSeriesToChart(chart);

    SetPrimaryAxesFormat(chart);
    SetSecondaryAxesFormat(chart);

    presentation.Save("combo-chart.pptx", SaveFormat.Pptx);
}

static IChart CreateChartWithFirstSeries(ISlide slide)
{
    var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.HasTitle = true;
    chart.ChartTitle.AddTextFrameForOverriding("Chart Title");
    chart.ChartTitle.Overlay = false;
    var portionFormat = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
    portionFormat.FontBold = NullableBool.False;
    portionFormat.FontHeight = 18f;

    chart.Legend.Position = LegendPositionType.Bottom;
    chart.Legend.TextFormat.PortionFormat.FontHeight = 12f;

    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    var workbook = chart.ChartData.ChartDataWorkbook;
    var worksheetIndex = 0;

    var categoryCell = workbook.GetCell(worksheetIndex, 1, 0, "Category 1");
    chart.ChartData.Categories.Add(categoryCell);
    categoryCell = workbook.GetCell(worksheetIndex, 2, 0, "Category 2");
    chart.ChartData.Categories.Add(categoryCell);
    categoryCell = workbook.GetCell(worksheetIndex, 3, 0, "Category 3");
    chart.ChartData.Categories.Add(categoryCell);
    categoryCell = workbook.GetCell(worksheetIndex, 4, 0, "Category 4");
    chart.ChartData.Categories.Add(categoryCell);

    var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 1, "Series 1");
    var series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

    series.ParentSeriesGroup.Overlap = -25;
    series.ParentSeriesGroup.GapWidth = 220;

    var valueCell = workbook.GetCell(worksheetIndex, 1, 1, 4.3);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 2, 1, 2.5);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 3, 1, 3.5);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 4, 1, 4.5);
    series.DataPoints.AddDataPointForBarSeries(valueCell);

    return chart;
}

static void AddSecondSeriesToChart(IChart chart)
{
    var workbook = chart.ChartData.ChartDataWorkbook;
    const int worksheetIndex = 0;

    var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 2, "Series 2");
    var series = chart.ChartData.Series.Add(seriesNameCell, ChartType.ClusteredColumn);

    series.ParentSeriesGroup.Overlap = -25;
    series.ParentSeriesGroup.GapWidth = 220;

    var valueCell = workbook.GetCell(worksheetIndex, 1, 2, 2.4);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 2, 2, 4.4);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 3, 2, 1.8);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 4, 2, 2.8);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

static void AddThirdSeriesToChart(IChart chart)
{
    var workbook = chart.ChartData.ChartDataWorkbook;
    const int worksheetIndex = 0;

    var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 3, "Series 3");
    var series = chart.ChartData.Series.Add(seriesNameCell, ChartType.Line);

    var valueCell = workbook.GetCell(worksheetIndex, 1, 3, 2.0);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 2, 3, 2.0);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 3, 3, 3.0);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 4, 3, 5.0);
    series.DataPoints.AddDataPointForLineSeries(valueCell);

    series.PlotOnSecondAxis = true;
}

static void SetPrimaryAxesFormat(IChart chart)
{
    var horizontalAxis = chart.Axes.HorizontalAxis;
    horizontalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    horizontalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(horizontalAxis, "X Axis");

    var verticalAxis = chart.Axes.VerticalAxis;
    verticalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    verticalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(verticalAxis, "Y Axis 1");

    var majorGridLinesFormat = verticalAxis.MajorGridLinesFormat.Line.FillFormat;
    majorGridLinesFormat.FillType = FillType.Solid;
    majorGridLinesFormat.SolidFillColor.Color = Color.FromArgb(217, 217, 217);
}

static void SetSecondaryAxesFormat(IChart chart)
{
    var secondaryHorizontalAxis = chart.Axes.SecondaryHorizontalAxis;
    secondaryHorizontalAxis.Position = AxisPositionType.Bottom;
    secondaryHorizontalAxis.CrossType = CrossesType.Maximum;
    secondaryHorizontalAxis.IsVisible = false;
    secondaryHorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;
    secondaryHorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    var secondaryVerticalAxis = chart.Axes.SecondaryVerticalAxis;
    secondaryVerticalAxis.Position = AxisPositionType.Right;
    secondaryVerticalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    secondaryVerticalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;
    secondaryVerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;
    secondaryVerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(secondaryVerticalAxis, "Y Axis 2");
}

static void SetAxisTitle(IAxis axis, string axisTitle)
{
    axis.HasTitle = true;
    axis.Title.Overlay = false;
    var titlePortionFormat = axis.Title.AddTextFrameForOverriding(axisTitle).Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
    titlePortionFormat.FontBold = NullableBool.False;
    titlePortionFormat.FontHeight = 12f;
}
```

## **Diagramme aktualisieren**

Aspose.Slides für .NET ermöglicht das Aktualisieren von PowerPoint‑Diagrammen durch Ändern von Diagrammdaten, Formatierung und Stil. Diese Funktionalität vereinfacht das Aktualisieren von Präsentationen mit dynamischem Inhalt und stellt sicher, dass Diagramme aktuelle Daten und gestalterische Standards genau wiedergeben.

Dieses Beispiel aktualisiert das Diagramm mit dem Namen "My chart" auf der ersten Folie einer bestehenden Präsentation. Es erfordert zwei Spalten‑Reihen mit jeweils drei Datenpunkten, wobei Kategorienamen in Spalte A und Reihen‑Namen in der ersten Zeile des ersten Arbeitsblatts stehen. Das Beispiel verwendet [GetCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcell/), um Arbeitsblatt‑Zellen zu ändern, aktualisiert Reihen‑Werte, fügt eine dritte Reihe hinzu und ändert das Diagramm zu gruppierten Zylindern über [Type](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/type/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const string chartName = "My chart";

using var presentation = new Presentation("ExistingChart.pptx");
var slide = presentation.Slides[0];

foreach (IShape shape in slide.Shapes)
{
    if (shape is IChart chart && chart.Name == chartName)
    {
        var worksheetIndex = 0;

        var workbook = chart.ChartData.ChartDataWorkbook;

        workbook.GetCell(worksheetIndex, 1, 0, "Modified Category 1");
        workbook.GetCell(worksheetIndex, 2, 0, "Modified Category 2");

        var series = chart.ChartData.Series[0];

        workbook.GetCell(worksheetIndex, 0, 1, "New_Series 1");
        series.DataPoints[0].Value.Data = 90;
        series.DataPoints[1].Value.Data = 123;
        series.DataPoints[2].Value.Data = 44;

        series = chart.ChartData.Series[1];

        workbook.GetCell(worksheetIndex, 0, 2, "New_Series 2");
        series.DataPoints[0].Value.Data = 23;
        series.DataPoints[1].Value.Data = 67;
        series.DataPoints[2].Value.Data = 99;

        var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 3, "Series 3");
        series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

        var valueCell = workbook.GetCell(worksheetIndex, 1, 3, 20);
        series.DataPoints.AddDataPointForBarSeries(valueCell);
        valueCell = workbook.GetCell(worksheetIndex, 2, 3, 50);
        series.DataPoints.AddDataPointForBarSeries(valueCell);
        valueCell = workbook.GetCell(worksheetIndex, 3, 3, 30);
        series.DataPoints.AddDataPointForBarSeries(valueCell);

        chart.Type = ChartType.ClusteredCylinder;
    }
}

presentation.Save("AsposeChartModified.pptx", SaveFormat.Pptx);
```

## **Datenbereich für ein Diagramm festlegen**

Um den bereits von einem bestehenden Diagramm genutzten Bereich zu prüfen, siehe [Retrieve a Chart's Data Range](/slides/de/net/chart-workbook/#retrieve-a-charts-data-range).

Aspose.Slides für .NET bietet die Flexibilität, einen spezifischen Datenbereich aus einem Arbeitsblatt als Quelle für die Daten Ihres Diagramms zu definieren. Das bedeutet, Sie können direkt einen Teil Ihres Arbeitsblatts dem Diagramm zuordnen und so steuern, welche Zellen zu den Reihen und Kategorien des Diagramms beitragen. Dadurch können Sie Diagramme einfach aktualisieren und mit den neuesten Änderungen in Ihrem Arbeitsblatt synchronisieren, sodass Ihre PowerPoint‑Präsentationen aktuelle und korrekte Informationen widerspiegeln.

Dieses Beispiel verwendet [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/), um die Datenquelle des Diagramms mit dem Namen "My chart" auf der ersten Folie einer bestehenden Präsentation auf `Sheet1!A1:B4` zu setzen. Das Diagramm‑Arbeitsbuch muss dieses Arbeitsblatt und einen gefüllten Bereich enthalten, wobei die erste Zeile die Reihen‑Überschrift, Spalte A die Kategorienamen und Spalte B drei Werte enthält.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const string chartName = "My chart";

using var presentation = new Presentation("ExistingChart.pptx");
var slide = presentation.Slides[0];

foreach (IShape shape in slide.Shapes)
{
    if (shape is IChart chart && chart.Name == chartName)
    {
        chart.ChartData.SetRange("Sheet1!A1:B4");
    }
}

presentation.Save("SetDataRange.pptx", SaveFormat.Pptx);
```

## **Standard‑Marker in Diagrammen verwenden**

Wenn Sie Standard‑Marker in Diagrammen verwenden, erhält jede Diagramm‑Reihe automatisch ein unterschiedliches Standard‑Marker‑Symbol.

Dieses Beispiel nutzt [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/), um ein Diagramm mit zwei Linien‑Reihen und einer Legende zu erstellen. Die [Marker](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/marker/)-Einstellungen behalten die automatisch zugewiesenen Marker‑Symbole bei. Die erste Reihe enthält einen negativen Wert und einen fehlenden Wert, dargestellt durch `null`, während die zweite für jede Kategorie einen Wert besitzt.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 10, 10, 400, 400);

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;

var seriesNameCell = workbook.GetCell(0, 0, 1, "Series 1");
var series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

var categoryCell = workbook.GetCell(0, 1, 0, "C1");
chart.ChartData.Categories.Add(categoryCell);
var valueCell = workbook.GetCell(0, 1, 1, 24);
series.DataPoints.AddDataPointForLineSeries(valueCell);

categoryCell = workbook.GetCell(0, 2, 0, "C2");
chart.ChartData.Categories.Add(categoryCell);
valueCell = workbook.GetCell(0, 2, 1, 23);
series.DataPoints.AddDataPointForLineSeries(valueCell);

categoryCell = workbook.GetCell(0, 3, 0, "C3");
chart.ChartData.Categories.Add(categoryCell);
valueCell = workbook.GetCell(0, 3, 1, -10);
series.DataPoints.AddDataPointForLineSeries(valueCell);

categoryCell = workbook.GetCell(0, 4, 0, "C4");
chart.ChartData.Categories.Add(categoryCell);
valueCell = workbook.GetCell(0, 4, 1, null);
series.DataPoints.AddDataPointForLineSeries(valueCell);

seriesNameCell = workbook.GetCell(0, 0, 2, "Series 2");
var secondSeries = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

valueCell = workbook.GetCell(0, 1, 2, 30);
secondSeries.DataPoints.AddDataPointForLineSeries(valueCell);
valueCell = workbook.GetCell(0, 2, 2, 10);
secondSeries.DataPoints.AddDataPointForLineSeries(valueCell);
valueCell = workbook.GetCell(0, 3, 2, 60);
secondSeries.DataPoints.AddDataPointForLineSeries(valueCell);
valueCell = workbook.GetCell(0, 4, 2, 40);
secondSeries.DataPoints.AddDataPointForLineSeries(valueCell);

chart.HasLegend = true;
chart.Legend.Overlay = false;

presentation.Save("DefaultMarkersInChart.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Welche Diagrammtypen werden von Aspose.Slides für .NET unterstützt?**

Aspose.Slides für .NET unterstützt eine breite Palette von Diagrammtypen, darunter Balken, Linien, Kreis, Flächen, Punkt, Histogramm, Radar und viele mehr. Diese Flexibilität erlaubt Ihnen, den am besten geeigneten Diagrammtyp für Ihre Datenvisualisierung zu wählen.

**Wie füge ich einer Folie ein neues Diagramm hinzu?**

Um ein Diagramm hinzuzufügen, erstellen Sie zunächst eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse, rufen die gewünschte Folie über deren Index ab und rufen dann die Methode zum Hinzufügen eines Diagramms auf, wobei Sie den Diagrammtyp und die Initialdaten angeben. Dieser Vorgang integriert das Diagramm direkt in Ihre Präsentation.

**Wie kann ich die in einem Diagramm angezeigten Daten aktualisieren?**

Sie können die Daten eines Diagramms aktualisieren, indem Sie über dessen Daten‑Arbeitsbuch ([IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/)) auf die Standard‑Reihen und -Kategorien zugreifen, diese löschen und anschließend Ihre eigenen Daten hinzufügen. So können Sie das Diagramm programmgesteuert mit den neuesten Daten versehen.

**Ist es möglich, das Aussehen des Diagramms anzupassen?**

Ja, Aspose.Slides für .NET bietet umfangreiche Anpassungsoptionen. Sie können Farben, Schriftarten, Beschriftungen, Legenden und andere Formatierungselemente ändern, um das Erscheinungsbild des Diagramms an Ihre spezifischen Designanforderungen anzupassen.

Related feature: [Create editable charts](/slides/de/features/create-charts/).