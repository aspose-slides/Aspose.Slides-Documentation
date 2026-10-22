---
title: Diagrammdatenserien in Präsentationen in .NET verwalten
linktitle: Datenserien
type: docs
url: /de/net/chart-series/
keywords:
- Diagrammserie
- Serienüberlappung
- Serienfarbe
- Kategorienfarbe
- Serienname
- Datenpunkt
- Serienlücke
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie Diagrammserien, Datenpunkte, Arbeitsblattzellen, Formatierungen, Überlappung, Lückenbreite und negative Werte in Präsentationen mit C# verwalten."
---
## **Übersicht**

Ein Diagramm kann seine geplotteten Werte in Arbeitsmappezellen oder direkt als numerische Literale speichern. Ein [IChartSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/) stellt einen Satz zusammengehöriger Werte dar, und jeder [IChartDataPoint](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/) repräsentiert einen Punkt in dieser Serie. [IChartCategory](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategory/)-Objekte liefern die für die Serien gemeinsam genutzten Beschriftungen oder Gruppierungswerte. In Diagrammen, die mit Standarddaten erstellt wurden, verwenden Seriennamen, Kategorien und Punktwerte [IChartDataCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/)-Objekte aus der Diagramm‑Arbeitsmappe.

Für ein typisches Kategorien‑Diagramm verwendet die Standard‑Arbeitsmappe Zeile 0 für Seriennamen, Spalte 0 für Kategorienamen und die restlichen Zellen für Serienwerte. Arbeitsblatt‑, Zeilen‑ und Spaltenindizes, die an [IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcell/) übergeben werden, sind nullbasiert. Dieses Layout ist nützlich, wenn Sie ein Diagramm mit Standarddaten erstellen, aber gehen Sie nicht davon aus, dass jedes vorhandene Diagramm es verwendet. Für eine geladene Präsentation sollten Sie die von den Serien, Kategorien und Datenpunkten referenzierten Zellen prüfen, bevor Sie Arbeitsblattwerte ändern.

Diagrammeinstellungen haben drei verschiedene Geltungsbereiche:

- Einstellungen auf Serien‑Ebene, wie [IChartSeries.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/format/), liefern das Standard‑Aussehen für alle Punkte einer Serie.
- Einstellungen auf Daten‑Punkt‑Ebene, wie [IChartDataPoint.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/format/), überschreiben das Serien‑Aussehen für einen einzelnen Punkt.
- Gruppeneinstellungen gelten für kompatible Serien, die derselben [IChartSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/) angehören. Greifen Sie über [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/parentseriesgroup/) auf die Gruppe zu, wenn Sie Optionen wie Überlappung oder Lückenbreite festlegen müssen.

Wenn weder ein expliziter Punkt‑ noch ein Serien‑Füllwert festgelegt ist, bestimmen Diagrammstil und -thema das automatische Aussehen. Sind sowohl Serien‑ als auch Punkt‑Formatierungen vorhanden, hat die Punkt‑Formatierung für diesen Punkt Vorrang.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Serienwerte mit numerischen Literalen festlegen**

Verwenden Sie numerische Literale, wenn Serienwerte aus Anwendungsdaten oder Berechnungen stammen und keine Arbeitsblatt‑Zellverweise benötigen. Setzen Sie [DataSourceTypeForValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforvalues/) auf [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/net/aspose.slides.charts/datasourcetype/) bevor Sie jedem Punkt über [AsLiteralDouble](https://reference.aspose.com/slides/net/aspose.slides.charts/idoublechartvalue/asliteraldouble/) den [Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/value/) zuweisen.

Die Einstellung der Sammlung steuert den Quelltyp aller Punktwerte in dieser Serie. Der [Value.DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/ibasechartvalue/datasourcetype/) jedes Punktes gibt den ausgewählten Typ an; ändern Sie ihn über die Sammlungs‑Einstellung. Mit `Worksheet` verwenden Sie [AsCell](https://reference.aspose.com/slides/net/aspose.slides.charts/isinglecellchartvalue/ascell/), um auf die referenzierte Zelle zuzugreifen. Mit `DoubleLiterals` verwenden Sie `AsLiteralDouble`, um die Zahl direkt zu lesen oder zu schreiben.

Das folgende Beispiel erstellt ein Säulendiagramm mit Standard‑Serien und -Kategorien und weist dann den bestehenden Punkten der ersten Serie berechnete Werte 10, 20 usw. zu. Es speichert die Präsentation, öffnet sie erneut und gibt die gespeicherten Werte aus.

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
var series = chart.ChartData.Series[0];

series.DataPoints.DataSourceTypeForValues = DataSourceType.DoubleLiterals;
for (var i = 0; i < series.DataPoints.Count; i++)
{
    series.DataPoints[i].Value.AsLiteralDouble = (i + 1) * 10;
}

presentation.Save("numeric_literals.pptx", SaveFormat.Pptx);

using var reopenedPresentation = new Presentation("numeric_literals.pptx");
var reopenedSlide = reopenedPresentation.Slides[0];
var reopenedChart = (IChart)reopenedSlide.Shapes[0];
var reopenedSeries = reopenedChart.ChartData.Series[0];
foreach (var point in reopenedSeries.DataPoints)
{
    Console.WriteLine(point.Value.AsLiteralDouble);
}
```

Der Quelltyp des Punktwerts ist getrennt von [IChartData.DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/datasourcetype/), das die interne oder externe Arbeitsmappen‑Konfiguration des Diagramms identifiziert. Die Verwendung numerischer Literale entfernt nicht automatisch die eingebettete Arbeitsmappe. In diesem Beispiel bleibt die Arbeitsmappe für Kategorienamen, Seriennamen und die anderen Serien verfügbar. Siehe [Chart Workbook](/slides/de/net/chart-workbook/) zur Arbeitsmappenverwaltung.

Für Streu‑ und Blasendiagramme setzen Sie [DataSourceTypeForXValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforxvalues/) und [DataSourceTypeForYValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforyvalues/) um die Quellen für [XValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/xvalue/) bzw. [YValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/yvalue/) zu wählen. Blasendiagramme verwenden zusätzlich [DataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforbubblesizes/) für [BubbleSize](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/bubblesize/). Setzen Sie jede zutreffende Quelle auf `DoubleLiterals`, bevor Sie Zahlen über die Eigenschaft `AsLiteralDouble` dieses Werts zuweisen.

## **Die Diagramm‑Serien‑Überlappung festlegen**

[IChartSeries.Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/overlap/) gibt an, wie stark Balken oder Säulen in einem 2D‑Diagramm überlappen, von -100 bis 100 Prozent. Es ist eine schreibgeschützte Projektion der Einstellung in der übergeordneten Seriengruppe. Setzen Sie [IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/overlap/), um jede kompatible Serie in dieser Gruppe zu aktualisieren. Diese Option gilt für Diagrammtypen, die gruppierte Balken oder Säulen anzeigen; sie wirkt sich nicht auf nicht verwandte Seriengruppen in einem Kombinationsdiagramm aus.

Das folgende Beispiel setzt die Überlappung für die Gruppe, die die erste Serie enthält:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const sbyte overlapPercent = 30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

// Das neue Diagramm enthält Beispielserien, Kategorien und Werte.
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.ParentSeriesGroup.Overlap = overlapPercent;

presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
```

Das Ergebnis:

![The series overlap](series_overlap.png)

## **Die Füllfarbe der Serie ändern**

Verwenden Sie [IChartSeries.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/format/), um die Standard‑Füllung für eine gesamte Serie festzulegen. Hat ein Punkt bereits eine explizite Füllung, überschreibt seine [IChartDataPoint.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/format/) Einstellung die Serien‑Füllung für diesen Punkt.

Das folgende Beispiel wendet eine solide blaue Füllung auf die erste Serie an:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Blue;

presentation.Save("series_color.pptx", SaveFormat.Pptx);
```

Das Ergebnis:

![The color of the series](series_color.png)

## **Den Seriennamen ändern**

Ein Serienname wird in der Diagramm‑Arbeitsmappe gespeichert und normalerweise in der Legende angezeigt. In der Standard‑Arbeitsmappe, die für ein gruppiertes Säulendiagramm erzeugt wird, befindet sich Zelle B1 in Zeile 0, Spalte 1 und enthält den Namen der ersten Serie. Die benannten Konstanten im folgenden Beispiel machen diese Struktur explizit:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int worksheetIndex = 0;
const int seriesNameRowIndex = 0;
const int firstSeriesColumnIndex = 1;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var workbook = chart.ChartData.ChartDataWorkbook;
var seriesNameCell = workbook.GetCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
seriesNameCell.Value = "Revenue";

presentation.Save("series_name.pptx", SaveFormat.Pptx);
```

Sie können auch die Zelle aktualisieren, die bereits von [IChartSeries.Name](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/name/) referenziert wird. Dieser Ansatz vermeidet Annahmen über bestimmte Zeilen‑ und Spaltenpositionen in einem bestehenden Diagramm:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int firstNameCellIndex = 0;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
var seriesNameCell = series.Name.AsCells[firstNameCellIndex];
seriesNameCell.Value = "Revenue";

presentation.Save("series_name.pptx", SaveFormat.Pptx);
```

Das Ergebnis:

![The series name](series_name.png)

### **Eine Serie mit einem Namen aus mehreren Zellen erstellen**

Ein zusammengesetzter Serienname ist nützlich, wenn ein Produktname und ein Berichtszeitraum in separaten Arbeitsmappezellen gespeichert sind. Beispielsweise können Sie `Product A` in B1 und `2026` in C1 zu einem einzigen Seriennamen kombinieren, während beide Teile mit ihren Quellzellen verknüpft bleiben.

Verwenden Sie [IChartDataWorkbook.GetCellCollection](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcellcollection/), um den Namensbereich abzurufen, und übergeben Sie diese Sammlung an [IChartSeriesCollection.Add](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriescollection/add/). Das Argument `skipHiddenCells` steuert, ob versteckte Zellen einbezogen werden: `true` schließt sie aus, `false` schließt sie ein. Dieses Beispiel verwendet `false`, um jede Zelle im Namensbereich einzubeziehen.

Das folgende Beispiel erstellt eine Präsentation mit einer Serie und zwei Datenpunkten. Zellen B1:C1 liefern nur den Seriennamen; A2:A3 liefern die Kategorienamen, und B2:B3 die numerischen Werte.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 620, 180);

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
chart.HasLegend = true;

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

// Diese beiden Zellen liefern den Seriennamen.
workbook.GetCell(0, 0, 1, "Product A");
workbook.GetCell(0, 0, 2, "2026");
var nameCells = workbook.GetCellCollection("Sheet1!$B$1:$C$1", skipHiddenCells: false);
var series = chart.ChartData.Series.Add(nameCells, ChartType.ClusteredColumn);

// Separate Zellen liefern die Kategorien und numerischen Datenpunkte.
var northCategory = workbook.GetCell(0, 1, 0, "North");
var southCategory = workbook.GetCell(0, 2, 0, "South");
chart.ChartData.Categories.Add(northCategory);
chart.ChartData.Categories.Add(southCategory);
var northValue = workbook.GetCell(0, 1, 1, 120);
var southValue = workbook.GetCell(0, 2, 1, 150);
series.DataPoints.AddDataPointForBarSeries(northValue);
series.DataPoints.AddDataPointForBarSeries(southValue);

presentation.Save("composite_series_name.pptx", SaveFormat.Pptx);
```

Der resultierende Serienname lautet `Product A 2026`, mit einem Leerzeichen zwischen den beiden Zellwerten. Die Legende zeigt dies als einen Eintrag für beide Spalten. Das untenstehende Bild wurde aus der gespeicherten Präsentation gerendert:

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **Die automatische Serien‑Füllfarbe ermitteln**

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/) gibt die aus dem Serien‑Index und dem Diagrammstil berechnete Farbe zurück. Dies ist die Farbe, die verwendet wird, wenn die Serien‑Füllung nicht explizit definiert wurde. Der Aufruf der Methode liest die berechnete Farbe; er weist keine neue Füllung zu.

Das folgende Beispiel gibt die automatische Farbe jeder Standardserie aus:

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

const int firstSlideIndex = 0;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var seriesCount = chart.ChartData.Series.Count;
for (var seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++)
{
    var series = chart.ChartData.Series[seriesIndex];
    var automaticColor = series.GetAutomaticSeriesColor();
    Console.WriteLine($"Series {seriesIndex}: {automaticColor.Name}");
}
```

Beispielausgabe für den Standard‑Diagrammstil:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

Die genauen Farben hängen vom Diagrammstil und -thema ab.

## **Invertierte Füllfarbe für eine Diagrammserie festlegen**

Für Balken‑, Säulen‑ und Blasensereien kann [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertifnegative/) negative Werte mit einer anderen Füllung anzeigen. Setzen Sie die reguläre Serien‑Füllung auf solid, aktivieren Sie die Invertierung und weisen Sie die Farbe für negative Werte über [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/) zu. Negative Zahlen bleiben in der Arbeitsmappe unverändert; nur ihre Anzeigefarbe ändert sich.

Das folgende Beispiel ersetzt die Standard‑Diagrammdaten durch eine Serie. Zeile 0 des Arbeitsblatts enthält den Seriennamen, Spalte 0 die Kategorienamen und Spalte 1 die Werte:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int worksheetIndex = 0;
const int headerRowIndex = 0;
const int categoryColumnIndex = 0;
const int firstSeriesColumnIndex = 1;
const int firstDataRowIndex = 1;

var categoryNames = new[] { "Category 1", "Category 2", "Category 3" };
var seriesValues = new[] { -20, 50, -30 };

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);
var chartData = chart.ChartData;
var workbook = chartData.ChartDataWorkbook;

chartData.Series.Clear();
chartData.Categories.Clear();

var seriesNameCell = workbook.GetCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, "Series 1");
var series = chartData.Series.Add(seriesNameCell, chart.Type);

for (var categoryIndex = 0; categoryIndex < categoryNames.Length; categoryIndex++)
{
    var dataRowIndex = firstDataRowIndex + categoryIndex;
    var categoryName = categoryNames[categoryIndex];
    var seriesValue = seriesValues[categoryIndex];

    var categoryCell = workbook.GetCell(worksheetIndex, dataRowIndex, categoryColumnIndex, categoryName);
    chartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, seriesValue);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

var automaticSeriesColor = series.GetAutomaticSeriesColor();
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = automaticSeriesColor;
series.InvertIfNegative = true;
series.InvertedSolidFillColor.Color = Color.Red;

presentation.Save("inverted_solid_fill_color.pptx", SaveFormat.Pptx);
```

Das Ergebnis:

![The inverted solid fill color](inverted_solid_fill_color.png)

Sie können die Invertierung für einen einzelnen Punkt über [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/invertifnegative/) aktivieren. Im folgenden Beispiel ist die Invertierung für die Serie deaktiviert und nur für den ausgewählten Punkt aktiviert. Dem Punkt wird zudem ein negativer Wert zugewiesen, damit der Effekt sichtbar wird:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int targetDataPointIndex = 2;
const int negativeValue = -30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
var automaticSeriesColor = series.GetAutomaticSeriesColor();
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = automaticSeriesColor;
series.InvertedSolidFillColor.Color = Color.Red;
series.InvertIfNegative = false;

var dataPoint = series.DataPoints[targetDataPointIndex];
dataPoint.YValue.AsCell.Value = negativeValue;
dataPoint.InvertIfNegative = true;

presentation.Save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx);
```

## **Einen konkreten Datenpunktwert leeren**

Um einen Punkt leer zu machen, ohne die anderen Punkte zu entfernen, setzen Sie dessen zugrundeliegende Arbeitsblattzelle auf `null`. Für ein Säulendiagramm ist der geplottete Wert über [IChartDataPoint.YValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/yvalue/) verfügbar. Der Datenpunkt bleibt an derselben Kategorienposition, das Diagramm behandelt den Wert jedoch als leer gemäß den Einstellungen für leere Werte im Diagramm.

Das folgende Beispiel löscht nur den zweiten Punkt in der ersten Serie:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int targetDataPointIndex = 1;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
var dataPoint = series.DataPoints[targetDataPointIndex];
dataPoint.YValue.AsCell.Value = null;

presentation.Save("clear_data_point_value.pptx", SaveFormat.Pptx);
```

Streudiagramme verwenden separate X‑ und Y‑Zellen, und Blasendiagramme nutzen zudem eine Größen‑Zelle. Leeren Sie nur die Zelle, die den zu entfernenden Wert darstellt. Rufen Sie nicht [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/clear/) auf, wenn Sie die anderen Punkte behalten möchten, da diese Methode alle Datenpunkte aus der Sammlung entfernt.

## **Anzeige leerer Zellen steuern**

Versteckte Zellen, die Werte enthalten, sind ein separater Fall zu leeren Zellen. Um Daten aus versteckten Zeilen und Spalten eines Arbeitsblatts ein‑ bzw. auszuschließen, siehe [Include Data from Hidden Rows and Columns](/slides/de/net/chart-workbook/#include-data-from-hidden-rows-and-columns).

Eine leere Arbeitsblattzelle stellt fehlende Daten dar; eine Zelle mit `0` stellt einen bekannten numerischen Wert dar. Setzen Sie [IChartDataCell.Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/value/) auf `null`, um die Zelle zu leeren. Eine numerische Null bleibt eine Null, unabhängig von der Einstellung für leere Zellen.

Verwenden Sie [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/), um zu wählen, wie das Diagramm leere Zellen darstellt. Diese Einstellung gilt für das gesamte Diagramm. Sie ändert, wie Lücken geplottet werden, ohne die leere Arbeitsblattzelle mit Null oder einem interpolierten Wert zu füllen.

Das folgende, eigenständige Beispiel erstellt ein Liniendiagramm mit einer Serie, löscht den Wert für Tag 3 und speichert das gleiche Diagramm für jeden Modus. Keine Eingabedatei ist erforderlich. Das [IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/) verwendet Arbeitsblatt 0, Spalte 0 für Kategorienamen und Spalte 1 für Werte; Zeile 0 enthält den Seriennamen. Die endgültigen Daten lauten `10, 20, empty, 30, 40`.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 40, 40, 640, 400);
var chartData = chart.ChartData;
var workbook = chartData.ChartDataWorkbook;

chartData.Series.Clear();
chartData.Categories.Clear();

var seriesNameCell = workbook.GetCell(0, 0, 1, "Measurements");
var series = chartData.Series.Add(seriesNameCell, chart.Type);
var values = new[] { 10, 20, 25, 30, 40 };

for (var i = 0; i < values.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, $"Day {i + 1}");
    chartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
}

// Leave Day 3 genuinely empty, while retaining its category and data point.
workbook.GetCell(0, 3, 1).Value = null;

var modes = new[] { DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span };
foreach (var mode in modes)
{
    chart.DisplayBlanksAs = mode;
    presentation.Save($"empty_cells_{mode}.pptx", SaveFormat.Pptx);
}
```

Jede Ausgabedatei speichert den Modus, der vor dem Speichern festgelegt wurde: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` und `empty_cells_Span.pptx`. Um nur eine Version zu speichern, setzen Sie den gewünschten Modus und speichern die Präsentation ein einziges Mal, anstatt über die Modi zu iterieren.

Der Vergleich unten zeigt dieselben Daten in allen drei Dateien. Tag 3 ist in der Arbeitsmappe in jedem Fall leer:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Der sichtbare Effekt hängt vom Diagrammtyp ab. Ein Liniendiagramm macht alle drei Modi leicht vergleichbar. Balken‑ und Säulendiagramme besitzen keine Linie, die über eine fehlende Kategorie hinweg verbindet, sodass `Span` keine verbindende Strecke erzeugen kann; eine fehlende Säule und eine Säule mit Höhe 0 können ebenfalls ähnlich aussehen. Ebenso hat ein Streudiagramm nur Marker ohne verbindende Linie. Erwarten Sie also nicht für jeden Diagrammtyp drei unterschiedliche Ergebnisse; prüfen Sie die Ausgabe für den von Ihnen verwendeten Typ.

## **Die Lückenbreite der Serie festlegen**

Die Lückenbreite ist der Abstand zwischen benachbarten Balken‑ oder Säulen‑Clustern, ausgedrückt als Prozentsatz der Balken‑ bzw. Säulenbreite. Wie die Überlappung gehört sie zur übergeordneten Seriengruppe und nicht zu einer einzelnen Serie. Setzen Sie [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) einmal für die Gruppe. Ein größerer Wert erzeugt mehr Abstand zwischen den Clustern; ein kleinerer Wert macht sie dichter.

Das folgende Beispiel ändert die Lückenbreite und speichert nur die finale Präsentation:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int gapWidthPercent = 30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.StackedColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.ParentSeriesGroup.GapWidth = gapWidthPercent;

presentation.Save("gap_width_30.pptx", SaveFormat.Pptx);
```

Das Ergebnis:

![The gap width](gap_width.png)

## **FAQ**

**Welche Diagrammtypen unterstützen Datenserien?**

Alle Diagrammtypen, die durch die [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/)‑Aufzählung repräsentiert werden, verwenden Diagrammdaten, jedoch haben ihre Serien nicht alle dieselbe Wertstruktur oder dieselben Einstellungen. Beispielsweise verwenden Kategorien‑Diagramme Kategorien und Werte, Streudiagramme X‑ und Y‑Werte und Blasendiagramme zusätzlich Blasengrößen. Verwenden Sie die Datenpunkt‑Erstellungsmethode, die zum Seriotyp passt. Optionen wie Überlappung und Lückenbreite gelten nur für kompatible Balken‑ oder Säulengruppen.

**Was ist eine Diagramm‑Serien‑Gruppe?**

Eine [IChartSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/) enthält kompatible Serien, die gruppenweite Plot‑Einstellungen teilen. Ein Kombinationsdiagramm kann mehr als eine Gruppe enthalten, sodass das Ändern der Gruppe, die über eine Serie erreicht wird, nicht zwangsläufig alle Serien im Diagramm beeinflusst.

**Enthält ein neu erstelltes Diagramm Standarddaten?**

Ja. Standardmäßig erzeugt [IShapeCollection.AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) Beispielserien, -kategorien und -werte. Sie können diese Zellen bearbeiten oder sowohl die Serien‑ als auch die Kategorien‑Sammlungen leeren, bevor Sie ein komplett benutzerdefiniertes Datenset hinzufügen. Eine Überladung kann außerdem ein Diagramm ohne Standarddaten erstellen.

**Wie sind Diagrammobjekte mit Arbeitsblattzellen verbunden?**

Seriennamen, Kategorienbeschriftungen und Datenpunktwerte referenzieren Zellen in einem [IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/). Das Ändern einer referenzierten Zelle aktualisiert das entsprechende Diagrammelement. Wenn Sie benutzerdefinierte Daten erstellen, halten Sie die Reihen für Kategorien und Serienwerte ausgerichtet, sodass jeder Punkt unter der vorgesehenen Kategorie geplottet wird.

**Wie kann ich einen einzelnen Punkt statt der gesamten Serie leeren?**

Setzen Sie die betreffende Wertzelle auf `null`, um die Position des Punktes als leeren Punkt zu behalten. Verwenden Sie [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/clear/) nur, wenn Sie alle Punkte dieser Serie entfernen möchten. Entfernen Sie außerdem keine Kategorien, ohne alle Serien so anzupassen, dass ihre Werte weiterhin zur Kategorien‑Sammlung passen.

**Wie werden leere Punkte dargestellt?**

Das Ergebnis hängt vom Diagrammtyp und von [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) ab. Unterstützte Diagramme können Lücken als Lücken, als Nullwerte oder durch Verknüpfen benachbarter Punkte anzeigen. Wählen Sie die Einstellung, die der Bedeutung von fehlenden Daten in Ihrer Präsentation entspricht. Siehe [Control the Display of Empty Cells](#control-the-display-of-empty-cells) für ein vollständiges Beispiel und einen visuellen Vergleich.

**Wie werden negative Werte formatiert?**

Für unterstützte Balken‑, Säulen‑ und Blasensereien aktivieren Sie [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertifnegative/) und setzen [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). Sie können das Verhalten für einen einzelnen Punkt mit [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/invertifnegative/) überschreiben. Diese Eigenschaften beeinflussen die Formatierung, nicht die im Arbeitsblatt gespeicherten numerischen Werte.

**Welche Formatierung gewinnt, wenn sowohl eine Serie als auch ein Punkt formatiert sind?**

Explizite Datenpunkt‑Formatierung hat für diesen Punkt Vorrang. Andere Punkte verwenden weiterhin die explizite Serien‑Formatierung oder, wenn keine Serien‑Formatierung definiert ist, den automatischen Diagrammstil und‑theme. Gruppeneigenschaften wie Überlappung und Lückenbreite steuern das Layout und sind keine punktbezogenen Formatierungsüberschreibungen.

**Gibt es ein Limit für die Anzahl der Serien in einem Diagramm?**

Aspose.Slides legt kein separates festes Limit für die Serienanzahl fest. In der Praxis bestimmen Dateigrößen‑beschränkungen, verfügbarer Arbeitsspeicher, Renderzeit und die Lesbarkeit des Diagramms ein sinnvolles Limit.

**Was sollte ich ändern, wenn Säulen zu eng oder zu weit auseinander liegen?**

Setzen Sie [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) in der entsprechenden übergeordneten Seriengruppe. Erhöhen Sie den Wert, um den Abstand zwischen den Clustern zu vergrößern, oder verringern Sie ihn, um die Cluster näher zusammenzubringen.