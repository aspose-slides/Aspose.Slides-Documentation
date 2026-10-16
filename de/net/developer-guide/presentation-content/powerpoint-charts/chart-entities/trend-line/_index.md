---
title: Trendlinien zu Präsentationsdiagrammen in .NET hinzufügen
linktitle: Trendlinie
type: docs
url: /de/net/trend-line/
keywords:
- Diagramm
- Trendlinie
- exponentielle Trendlinie
- lineare Trendlinie
- logarithmische Trendlinie
- Trendlinie für gleitenden Mittelwert
- polynomiale Trendlinie
- Potenztrendlinie
- benutzerdefinierte Trendlinie
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Fügen Sie Trendlinien in PowerPoint‑Diagrammen mit Aspose.Slides für .NET schnell hinzu und passen Sie sie an – ein praktischer Leitfaden, um Ihr Publikum zu begeistern."
---
## **Übersicht**

Dieser Artikel erklärt, wie man Trendlinien zu Präsentationsdiagrammen mit Aspose.Slides hinzufügt. Er zeigt, wie man ein Diagramm erstellt, Trendlinien zu Diagrammserien hinzufügt und mit verschiedenen Trendlinientypen arbeitet, darunter exponentiell, linear, logarithmisch, gleitender Mittelwert, polynomial und potenz.

Außerdem beschreibt es, wie man einer Grafik eine benutzerdefinierte Linie hinzufügt, indem man eine Linienform einfügt, und enthält ein kurzes FAQ zu den Vorwärts‑ und Rückwärtsprojektionen von Trendlinien sowie zur Frage, ob Trendlinien beim Exportieren nach PDF oder SVG und beim Rendern von Diagrammen als Bilder erhalten bleiben.

## **Trendlinie hinzufügen**

Verwenden Sie [ITrendlineCollection.Add](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendlinecollection/add/), um einer Diagrammserie eine Trendlinie hinzuzufügen, wobei Sie den Typ mit [TrendlineType](https://reference.aspose.com/slides/net/aspose.slides.charts/trendlinetype/) auswählen. Das Beispiel erstellt ein gruppiertes Säulendiagramm mit Standarddaten und fügt jeder seiner drei Serien zwei Trendlinien hinzu.

Die exponentielle Trendlinie blendet ihre Gleichung und den R‑Quadrat‑Wert über [DisplayEquation](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/displayequation/) bzw. [DisplayRSquaredValue](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/displayrsquaredvalue/) aus, während die lineare Trendlinie rot ist. Die logarithmische Trendlinie verwendet [AddTextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/trendline/addtextframeforoverriding/) für ein benutzerdefiniertes Etikett. Der gleitende Mittelwert verwendet ein [Period](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/period/) von drei Datenpunkten und einen benutzerdefinierten [TrendlineName](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/trendlinename/).

Die polynomiale Trendlinie hat einen [Order](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/order/) von drei und erstreckt sich eine Kategorie nach vorne über [Forward](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/forward/). Die Potenz‑Trendlinie erstreckt sich eine Kategorie nach hinten über [Backward](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/backward/).

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 400);

var firstSeries = chart.ChartData.Series[0];

var exponentialTrendline = firstSeries.TrendLines.Add(TrendlineType.Exponential);
exponentialTrendline.DisplayEquation = false;
exponentialTrendline.DisplayRSquaredValue = false;

var linearTrendline = firstSeries.TrendLines.Add(TrendlineType.Linear);
linearTrendline.Format.Line.FillFormat.FillType = FillType.Solid;
linearTrendline.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;

var secondSeries = chart.ChartData.Series[1];

var logarithmicTrendline = secondSeries.TrendLines.Add(TrendlineType.Logarithmic);
logarithmicTrendline.AddTextFrameForOverriding("New log trend line");

var movingAverageTrendline = secondSeries.TrendLines.Add(TrendlineType.MovingAverage);
movingAverageTrendline.Period = 3;
movingAverageTrendline.TrendlineName = "New TrendLine Name";

var thirdSeries = chart.ChartData.Series[2];

var polynomialTrendline = thirdSeries.TrendLines.Add(TrendlineType.Polynomial);
polynomialTrendline.Forward = 1;
polynomialTrendline.Order = 3;

var powerTrendline = thirdSeries.TrendLines.Add(TrendlineType.Power);
powerTrendline.Backward = 1;

presentation.Save("ChartTrendLines.pptx", SaveFormat.Pptx);
```

## **Trendlinien‑Achsenabschnitt festlegen**

Verwenden Sie [Intercept](https://reference.aspose.com/slides/net/aspose.slides.charts/trendline/intercept/), um den Y‑Wert einer Trendlinie bei X = 0 zu fixieren. Diese Einstellung wird für lineare, exponentielle und polynomiale Trendlinien unterstützt.

Beispielsweise kann ein Produktionskostenmodell bei bekannten Fixkosten von 100 beginnen, selbst wenn Messungen bei nicht‑null Produktionsmengen eine andere Basislinie nahelegen. Bei einer linearen Trendlinie zwingt das Fixieren des Achsenabschnitts die Gleichung `y = ax + b` zu `b = 100`; die Steigung wird dann anhand der Daten unter dieser Einschränkung angepasst. Es verschiebt nicht einfach eine bereits angepasste Linie. Die Einstellungen für den Achsenschnittpunkt bestimmen, wo die Diagrammachsen sich treffen, nicht die Koeffizienten der angepassten Trendlinie.

Das folgende Beispiel erstellt ein Streudiagramm (XY) mit Produktionsmengen von 1 bis 4 und Kosten von 170, 200, 230 und 260. Es speichert das Diagramm mit dem standardmäßigen automatischen Achsenabschnitt, setzt den Achsenabschnitt auf 100 und speichert ein zweites PPTX. Die beiden Dateien unterscheiden sich nur in der Achsenabschnitt‑Einstellung. Die Trendlinie zeigt ihre Gleichung an und erstreckt sich zurück zu X = 0.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ScatterWithMarkers, 20, 20, 480, 210);
chart.HasLegend = false;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var nameCell = workbook.GetCell(0, 0, 1, "Production cost");
var series = chart.ChartData.Series.Add(nameCell, ChartType.ScatterWithMarkers);
double[] costs = { 170, 200, 230, 260 };

for (var i = 0; i < costs.Length; i++)
{
    var xCell = workbook.GetCell(0, i + 1, 0, i + 1);
    var yCell = workbook.GetCell(0, i + 1, 1, costs[i]);
    series.DataPoints.AddDataPointForScatterSeries(xCell, yCell);
}

var trendline = series.TrendLines.Add(TrendlineType.Linear);
trendline.DisplayEquation = true;
trendline.Backward = 1;

presentation.Save("AutomaticIntercept.pptx", SaveFormat.Pptx);

trendline.Intercept = 100;
presentation.Save("FixedIntercept.pptx", SaveFormat.Pptx);
```

Mit automatischer Berechnung ergeben diese Daten `y = 30x + 140`. Das Festlegen des Achsenabschnitts auf 100 führt stattdessen zu etwa `y = 43.33x + 100`: Der angepasste Wert bei Null entspricht der bekannten Basislinie, während die Linie nicht mehr durch jeden Datenpunkt verläuft.

| Automatischer Achsenabschnitt | Fester Achsenabschnitt von 100 |
| --- | --- |
| ![Lineare Trendlinie mit automatisch berechnetem Achsenabschnitt von 140](intercept-automatic.png) | ![Lineare Trendlinie mit festem Achsenabschnitt von 100](intercept-fixed.png) |

Beide Bilder verwenden dieselben Daten und Achsenskalierungen. Die Trendlinien werden bis zu X = 0 zurückgereicht, um ihre Achsenabschnitte zu zeigen.

Standardmäßig enthält die Eigenschaft `double.NaN`, was einen nicht angegebenen Achsenabschnitt anstelle von Null darstellt. Der Achsenabschnitt wird dann automatisch aus den Daten berechnet.

## **Benutzerdefinierte Linie hinzufügen**

Eine benutzerdefinierte Linie ist eine Form, die über das Diagramm gezeichnet wird, anstatt eine Trendlinie, die aus den Seriendaten berechnet wird. Dieses Beispiel verwendet [IShapeCollection.AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addautoshape/), um dem Folieninhalt über dem Diagramm eine horizontale Linie hinzuzufügen. Die Position der Linie wird in Folienkoordinaten angegeben, gemessen in Punkten, sodass sie an der linken Kante des Diagramms beginnt und halbwegs in der Mitte des Diagramms liegt. Ihre Breite entspricht der Diagrammbreite. Das [LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) verleiht der Linie eine durchgezogene rote Farbe.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);

var line = slide.Shapes.AddAutoShape(ShapeType.Line, chart.X, chart.Y + chart.Height / 2, chart.Width, 0);
line.LineFormat.FillFormat.FillType = FillType.Solid;
line.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;

presentation.Save("AddCustomLines.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Was bedeuten „forward“ und „backward“ bei einer Trendlinie?**

Sie geben die Längen der Trendlinie an, die nach vorne bzw. nach hinten projiziert werden: für Streudiagramme (XY) – in Achseneinheiten; für Nicht‑Streudiagramme – in Anzahl der Kategorien. Es sind nur nicht‑negative Werte zulässig.

**Wird die Trendlinie beim Export der Präsentation nach PDF oder SVG bzw. beim Rendern einer Folie zu einem Bild erhalten bleiben?**

Ja. Aspose.Slides konvertiert Präsentationen zu [PDF](/slides/de/net/convert-powerpoint-to-pdf/) oder [SVG](/slides/de/net/render-a-slide-as-an-svg-image/) und rendert Diagramme zu Bildern; Trendlinien, als Teil des Diagramms, werden bei diesen Vorgängen beibehalten. Eine Methode steht zudem zur Verfügung, um ein Bild des Diagramms selbst zu [ein Bild des Diagramms exportieren](/slides/de/net/create-shape-thumbnails/).