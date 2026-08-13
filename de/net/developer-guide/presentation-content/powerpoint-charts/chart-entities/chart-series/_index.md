---
title: Diagrammdatenserien in Präsentationen in .NET verwalten
linktitle: Datenserien
type: docs
url: /de/net/chart-series/
keywords:
- diagrammserie
- serienüberlappung
- serienfarbe
- kategorienfarbe
- serienname
- datenpunkt
- serienlücke
- PowerPoint
- präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie Diagrammserien, Datenpunkte, Arbeitsmappen‑Zellen, Formatierungen, Überlappungen, Lückenbreite und negative Werte in Präsentationen mit C# verwalten."
---
## **Übersicht**

Ein Diagramm speichert seine geplotteten Daten in einer Diagrammdaten‑Arbeitsmappe. Eine [IChartSeries](https://reference.aspose.com/slides/de/net/aspose.slides.charts/ichartseries/) stellt einen Satz zusammengehöriger Werte dar, und jeder [IChartDataPoint](https://reference.aspose.com/slides/de/net/aspose.slides.charts/ichartdatapoint/) in der Serie bezieht sich auf eine oder mehrere Zellen der Arbeitsmappe. [IChartCategory](https://reference.aspose.com/slides/de/net/aspose.slides.charts/ichartcategory/)‑Objekte liefern die Beschriftungen bzw. Gruppierungswerte, die von den Serien gemeinsam genutzt werden. Der Serienname, die Kategorien und die Punktwerte sind daher mit [IChartDataCell](https://reference.aspose.com/slides/de/net/aspose.slides.charts/ichartdatacell/)‑Objekten verknüpft und werden nicht nur als Anzeigetext gespeichert.

Für ein typisches Kategorien‑Diagramm verwendet die Standard‑Arbeitsmappe Zeile 0 für Seriennamen, Spalte 0 für Kategorienamen und die übrigen Zellen für Serienwerte. Arbeitsblatt‑, Zeilen‑ und Spaltenindizes, die an [IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/de/net/aspose.slides.charts/ichartdataworkbook/getcell/) übergeben werden, sind nullbasiert. Dieses Layout ist nützlich, wenn Sie ein Diagramm mit Standarddaten erstellen, aber Sie dürfen nicht davon ausgehen, dass jedes vorhandene Diagramm es verwendet. Bei einer geladenen Präsentation sollten Sie die von den Serien, Kategorien und Datenpunkten referenzierten Zellen prüfen, bevor Sie Arbeitsmappenwerte ändern.

Diagrammeinstellungen haben drei unterschiedliche Geltungsbereiche:

- Auf Serien‑Ebene, z. B. [IChartSeries.Format](https://reference.aspose.com/slides/de/net/aspose.slides.charts/ichartseries/format/), werden die Standard‑Darstellung für alle Punkte einer Serie festgelegt.
- Auf Datenpunkt‑Ebene, z. B. [IChartDataPoint.Format](https://reference.aspose.com/slides/de/net/aspose.slides.charts/ichartdatapoint/format/), überschreiben das Serien‑Design für einen einzelnen Punkt.
- Gruppeneinstellungen gelten für kompatible Serien, die derselben [IChartSeriesGroup](https://reference.aspose.com/slides/de/net/aspose.slides.charts/ichartseriesgroup/) angehören. Greifen Sie über [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/de/net/aspose.slides.charts/ichartseries/parentseriesgroup/) auf die Gruppe zu, wenn Sie Optionen wie Überlappung oder Lückenbreite festlegen müssen.

Wenn weder ein expliziter Punkt‑ noch ein Serien‑Füllstil gesetzt ist, bestimmen Diagramm‑Stil und -Thema das automatische Aussehen. Wenn sowohl Serien‑ als auch Punkt‑Formatierung vorhanden sind, hat die Punkt‑Formatierung für diesen Punkt Vorrang.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Überlappung der Diagramm‑Serien festlegen**

[IChartSeries.Overlap](https://reference.aspose.com/slides/de/net/aspose.slides.charts/ichartseries/overlap/) gibt an, wie stark Balken oder Säulen in einem 2D‑Diagramm überlappen, von ‑100 bis 100 Prozent. Es handelt sich um eine schreibgeschützte Projektion der Einstellung in der übergeordneten Seriengruppe. Setzen Sie [IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/de/net/aspose.slides.charts/ichartseriesgroup/overlap/), um alle kompatiblen Serien in dieser Gruppe zu aktualisieren. Diese Option gilt für Diagrammtypen, die gruppierte Balken oder Säulen anzeigen; sie beeinflusst keine nicht zugehörigen Seriengruppen in einem Kombinationsdiagramm.

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

## **Füllfarbe der Serie ändern**

Verwenden Sie [IChartSeries.Format](https://reference.aspose.com/slides/de/net/aspose.slides.charts/ichartseries/format/), um die Standard‑Füllung einer gesamten Serie festzulegen. Hat ein Punkt bereits eine explizite Füllung, überschreibt dessen [IChartDataPoint.Format](https://reference.aspose.com/slides/de/net/aspose.slides.charts/ichartdatapoint/format/) die Serien‑Füllung für diesen Punkt.

Das folgende Beispiel wendet eine einfarbige blaue Füllung auf die erste Serie an:

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

## **Seriennamen ändern**

Ein Serienname wird in der Diagrammdaten‑Arbeitsmappe gespeichert und normalerweise in der Legende angezeigt. In der Standard‑Arbeitsmappe, die für ein gruppiertes Säulendiagramm erstellt wird, befindet sich Zelle B1 in Zeile 0, Spalte 1 und enthält den Namen der ersten Serie. Die benannten Konstanten im folgenden Beispiel machen diese Struktur explizit:

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

Sie können auch die bereits von [IChartSeries.Name](https://reference.aspose.com/slides/de/net/aspose.slides.charts/ichartseries/name/) referenzierte Zelle aktualisieren. Dieser Ansatz vermeidet Annahmen über einzelne Zeilen und Spalten in einem bestehenden Diagramm:

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

## **Automatische Serien‑Füllfarbe abrufen**

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/de/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/) liefert die Farbe, die aus dem Serien‑Index und dem Diagramm‑Stil berechnet wird. Dies ist die Farbe, die verwendet wird, wenn die Serien‑Füllung nicht ausdrücklich definiert wurde. Der Aufruf der Methode liest die berechnete Farbe; er weist keine neue Füllung zu.

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

Beispielausgabe für den Standard‑Diagramm‑Stil:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

Die genauen Farben hängen vom Diagramm‑Stil und -Thema ab.

## **Invertierte Füllfarbe für eine Diagramm‑Serie festlegen**

Für Balken‑, Säulen‑ und Blasendiagramme kann [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/de/net/aspose.slides.charts/ichartseries/invertifnegative/) negative Werte mit einer anderen Füllung anzeigen. Setzen Sie die reguläre Serien‑Füllung auf einfarbig, aktivieren Sie die Invertierung und weisen Sie die Farbe für negative Werte über [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/de/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/) zu. Negative Zahlen bleiben in der Arbeitsmappe unverändert; nur ihre Anzeigefarbe ändert sich.

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

Sie können die Invertierung für einen einzelnen Punkt über [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/de/net/aspose.slides.charts/ichartdatapoint/invertifnegative/) aktivieren. Im folgenden Beispiel ist die Invertierung für die Serie deaktiviert und nur für den ausgewählten Punkt aktiviert. Der Punkt erhält außerdem einen negativen Wert, sodass der Effekt sichtbar wird:

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

## **Einen bestimmten Datenpunkt‑Wert löschen**

Um einen Punkt leer zu machen, ohne die anderen Punkte zu entfernen, setzen Sie die zugehörige Zelle der Arbeitsmappe auf `null`. Für ein Säulendiagramm steht der geplottete Wert über [IChartDataPoint.YValue](https://reference.aspose.com/slides/de/net/aspose.slides.charts/ichartdatapoint/yvalue/). Der Datenpunkt bleibt an derselben Kategorienposition, aber das Diagramm behandelt seinen Wert gemäß den Diagramm‑Einstellungen für leere Werte als leer.

Das folgende Beispiel löscht ausschließlich den zweiten Punkt in der ersten Serie:

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

Scatter‑Diagramme verwenden separate X‑ und Y‑Zellen, Blasendiagramme zusätzlich eine Größen‑Zelle. Löschen Sie nur die Zelle, die den zu entfernenden Wert darstellt. Rufen Sie nicht [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/de/net/aspose.slides.charts/ichartdatapointcollection/clear/) auf, wenn Sie die anderen Punkte behalten möchten, weil diese Methode alle Datenpunkte aus der Sammlung entfernt.

## **Lückenbreite der Serie festlegen**

Die Lückenbreite ist der Abstand zwischen benachbarten Balken‑ oder Säulen‑Clustern, angegeben als Prozentsatz der Balken‑ bzw. Säulenbreite. Wie die Überlappung gehört sie zur übergeordneten Seriengruppe und nicht zu einer einzelnen Serie. Setzen Sie [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/de/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) einmal für die Gruppe. Ein größerer Wert erzeugt mehr Abstand zwischen den Clustern; ein kleinerer Wert macht sie dichter.

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

Alle Diagrammtypen, die durch die Aufzählung [ChartType](https://reference.aspose.com/slides/de/net/aspose.slides.charts/charttype/) repräsentiert werden, verwenden Diagrammdaten, aber ihre Serien besitzen nicht alle dieselbe Werte‑Struktur oder dieselben Einstellungen. Beispielsweise benutzen Kategorie‑Diagramme Kategorien und Werte, Scatter‑Diagramme X‑ und Y‑Werte, und Blasendiagramme zusätzlich Bubble‑Größen. Verwenden Sie die Datenpunkt‑Erzeugungsmethode, die zum Serientyp passt. Optionen wie Überlappung und Lückenbreite gelten nur für kompatible Balken‑ bzw. Säulengruppen.

**Was ist eine Diagramm‑Seriengruppe?**

Eine [IChartSeriesGroup](https://reference.aspose.com/slides/de/net/aspose.slides.charts/ichartseriesgroup/) enthält kompatible Serien, die gruppenbezogene Plot‑Einstellungen gemeinsam nutzen. Ein Kombinationsdiagramm kann mehr als eine Gruppe enthalten, sodass das Ändern der Gruppe über eine Serie nicht zwangsläufig jede Serie im Diagramm beeinflusst.

**Enthält ein neu erstelltes Diagramm Standarddaten?**

Ja. Standardmäßig erzeugt [IShapeCollection.AddChart](https://reference.aspose.com/slides/de/net/aspose.slides/ishapecollection/addchart/) Beispieldaten für Serien, Kategorien und Werte. Sie können diese Zellen bearbeiten oder sowohl Serien‑ als auch Kategorien‑Sammlungen leeren, bevor Sie einen komplett benutzerdefinierten Datensatz hinzufügen. Eine Überladung kann ebenfalls ein Diagramm ohne Standarddaten erzeugen.

**Wie sind Diagrammobjekte mit Arbeitsmappenzellen verknüpft?**

Seriennamen, Kategorielabels und Datenpunkt‑Werte referenzieren Zellen in einem [IChartDataWorkbook](https://reference.aspose.com/slides/de/net/aspose.slides.charts/ichartdataworkbook/). Das Ändern einer referenzierten Zelle aktualisiert das entsprechende Diagrammelement. Beim Aufbau benutzerdefinierter Daten sollten Sie Kategorizeilen und Serien‑Wert‑Zeilen ausrichten, damit jeder Punkt unter der vorgesehenen Kategorie geplottet wird.

**Wie lösche ich nur einen Punkt statt der gesamten Serie?**

Setzen Sie die betreffende Wert‑Zelle auf `null`, um die Position des Punktes als leeren Punkt beizubehalten. Verwenden Sie [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/de/net/aspose.slides.charts/ichartdatapointcollection/clear/) nur, wenn Sie alle Punkte dieser Serie entfernen möchten. Entfernen Sie zudem Kategorien, aktualisieren Sie jede Serie, damit ihre Werte mit der Kategorien‑Sammlung synchron bleiben.

**Wie werden leere Punkte angezeigt?**

Das Ergebnis hängt vom Diagrammtyp und von [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/de/net/aspose.slides.charts/ichart/displayblanksas/) ab. Unterstützte Diagramme können leere Werte als Lücken, als Nullwerte oder durch Verbinden benachbarter Punkte darstellen. Wählen Sie die Einstellung, die der Bedeutung fehlender Daten in Ihrer Präsentation entspricht.

**Wie werden negative Werte formatiert?**

Für unterstützte Balken‑, Säulen‑ und Blasendiagramme aktivieren Sie [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/de/net/aspose.slides.charts/ichartseries/invertifnegative/) und setzen [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/de/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). Sie können das Verhalten für einen einzelnen Punkt mit [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/de/net/aspose.slides.charts/ichartdatapoint/invertifnegative/) überschreiben. Diese Eigenschaften beeinflussen die Formatierung, nicht die gespeicherten Zahlenwerte.

**Welche Formatierung hat Vorrang, wenn sowohl eine Serie als auch ein Punkt formatiert sind?**

Explizite Datenpunkt‑Formatierung hat für diesen Punkt Vorrang. Andere Punkte verwenden weiterhin das explizite Serien‑Format oder, wenn kein Serien‑Format definiert ist, den automatischen Diagramm‑Stil und das Theme. Gruppeneigenschaften wie Überlappung und Lückenbreite steuern das Layout und sind keine point‑level Format‑Überschreibungen.

**Gibt es ein Limit für die Anzahl der Serien in einem Diagramm?**

Aspose.Slides legt keine separate feste Obergrenze für die Serienanzahl fest. In der Praxis bestimmen Dateigrößen‑Beschränkungen, verfügbarer Speicher, Renderzeit und Lesbarkeit des Diagramms eine sinnvolle Grenze.

**Was sollte ich ändern, wenn Säulen zu eng oder zu weit auseinander liegen?**

Setzen Sie [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/de/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) in der entsprechenden übergeordneten Seriengruppe. Erhöhen Sie den Wert, um den Abstand zwischen den Clustern zu vergrößern, oder verringern Sie ihn, um die Cluster näher zusammenzubringen.