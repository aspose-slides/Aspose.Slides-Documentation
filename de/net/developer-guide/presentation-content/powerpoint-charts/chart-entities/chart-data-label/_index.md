---
title: Diagrammbeschriftungen in Präsentationen in .NET verwalten
linktitle: Datenbeschriftung
type: docs
url: /de/net/chart-data-label/
keywords:
- Diagramm
- Datenbeschriftung
- Datenpräzision
- Prozent
- Beschriftungsabstand
- Beschriftungsposition
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie Diagrammbeschriftungen in PowerPoint-Präsentationen mit Aspose.Slides für .NET hinzufügen und formatieren, um ansprechendere Folien zu erstellen."
---

Datenbeschriftungen in einem Diagramm zeigen Details zur Datenreihe oder zu einzelnen Datenpunkten. Sie ermöglichen es dem Leser, Datenreihen schnell zu identifizieren, und machen Diagramme leichter verständlich.

## **Genauigkeit der Daten in Diagrammbeschriftungen festlegen**

Dieser C#‑Code zeigt, wie Sie die Datenpräzision in einer Diagrammbeschriftung festlegen:
```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 50, 50, 450, 300);
	chart.HasDataTable = true;
	chart.ChartData.Series[0].NumberFormatOfValues = "#,##0.00";

	pres.Save("PrecisionOfDatalabels_out.pptx", SaveFormat.Pptx);
}
```


## **Prozentwerte als Beschriftungen anzeigen**
Aspose.Slides for .NET ermöglicht das Setzen von Prozentbeschriftungen in angezeigten Diagrammen. Dieser C#‑Code demonstriert die Vorgehensweise:
```c#
// Erstellt eine Instanz der Presentation-Klasse
Presentation presentation = new Presentation();

ISlide slide = presentation.Slides[0];
IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn, 20, 20, 400, 400);
IChartSeries series = chart.ChartData.Series[0];
IChartCategory cat;
double[] total_for_Cat = new double[chart.ChartData.Categories.Count];
for (int k = 0; k < chart.ChartData.Categories.Count; k++)
{
    cat = chart.ChartData.Categories[k];

    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        total_for_Cat[k] = total_for_Cat[k] + Convert.ToDouble(chart.ChartData.Series[i].DataPoints[k].Value.Data);
    }
}

double dataPontPercent = 0f;

for (int x = 0; x < chart.ChartData.Series.Count; x++)
{
    series = chart.ChartData.Series[x];
    series.Labels.DefaultDataLabelFormat.ShowLegendKey = false;

    for (int j = 0; j < series.DataPoints.Count; j++)
    {
        IDataLabel lbl = series.DataPoints[j].Label;
        dataPontPercent = (Convert.ToDouble(series.DataPoints[j].Value.Data) / total_for_Cat[j]) * 100;

        IPortion port = new Portion();
        port.Text = String.Format("{0:F2} %", dataPontPercent);
        port.PortionFormat.FontHeight = 8f;
        lbl.TextFrameForOverriding.Text = "";
        IParagraph para = lbl.TextFrameForOverriding.Paragraphs[0];
        para.Portions.Add(port);

        lbl.DataLabelFormat.ShowSeriesName = false;
        lbl.DataLabelFormat.ShowPercentage = false;
        lbl.DataLabelFormat.ShowLegendKey = false;
        lbl.DataLabelFormat.ShowCategoryName = false;
        lbl.DataLabelFormat.ShowBubbleSize = false;
    }
}

// Speichert die Präsentation, die das Diagramm enthält
presentation.Save("DisplayPercentageAsLabels_out.pptx", SaveFormat.Pptx);
```



## **Prozentzeichen bei Diagrammbeschriftungen setzen**
Dieser C#‑Code zeigt, wie Sie das Prozentzeichen für eine Diagrammbeschriftung festlegen:
```c#
// Erstellt eine Instanz der Presentation-Klasse
Presentation presentation = new Presentation();

// Holt eine Referenz auf die Folie über ihren Index
ISlide slide = presentation.Slides[0];

// Erstellt das PercentsStackedColumn-Diagramm auf einer Folie
IChart chart = slide.Shapes.AddChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400);

// Setzt NumberFormatLinkedToSource auf false
chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.NumberFormat = "0.00%";

chart.ChartData.Series.Clear();
int defaultWorksheetIndex = 0;

// Holt das Diagrammdaten-Arbeitsblatt
IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

// Fügt neue Serie hinzu
IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Reds"), chart.Type);
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 0.30));
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 0.50));
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 0.80));
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 4, 1, 0.65));

// Setzt die Füllfarbe der Serie
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;

// Setzt die Eigenschaften des LabelFormats
series.Labels.DefaultDataLabelFormat.ShowValue = true;
series.Labels.DefaultDataLabelFormat.IsNumberFormatLinkedToSource = false;
series.Labels.DefaultDataLabelFormat.NumberFormat = "0.0%";
series.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FontHeight = 10;
series.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
series.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.White;
series.Labels.DefaultDataLabelFormat.ShowValue = true;

// Fügt neue Serie hinzu
IChartSeries series2 = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 2, "Blues"), chart.Type);
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 2, 0.70));
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 2, 0.50));
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 2, 0.20));
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 4, 2, 0.35));

// Setzt den Fülltyp und die Farbe
series2.Format.Fill.FillType = FillType.Solid;
series2.Format.Fill.SolidFillColor.Color = Color.Blue;
series2.Labels.DefaultDataLabelFormat.ShowValue = true;
series2.Labels.DefaultDataLabelFormat.IsNumberFormatLinkedToSource = false;
series2.Labels.DefaultDataLabelFormat.NumberFormat = "0.0%";
series2.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FontHeight = 10;
series2.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
series2.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.White;

// Schreibt die Präsentation auf die Festplatte
presentation.Save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx);
```


## **Abstand der Beschriftung von der Achse festlegen**
Dieser C#‑Code zeigt, wie Sie den Beschriftungsabstand von einer Kategorienachse festlegen, wenn Sie ein Diagramm aus Achsen plotten:
```c#
// Erstellt eine Instanz der Presentation-Klasse
Presentation presentation = new Presentation();

// Holt eine Referenz auf die Folie
ISlide sld = presentation.Slides[0];

// Erstellt ein Diagramm auf der Folie
IChart ch = sld.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

// Setzt den Beschriftungsabstand von einer Achse
ch.Axes.HorizontalAxis.LabelOffset = 500;

// Schreibt die Präsentation auf die Festplatte
presentation.Save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat.Pptx);
```


## **Beschriftungsposition anpassen**

Wenn Sie ein Diagramm erstellen, das keine Achsen verwendet, z. B. ein Kreisdiagramm, können die Datenbeschriftungen zu nahe am Rand liegen. In diesem Fall müssen Sie die Position der Beschriftung anpassen, damit die Hilfslinien deutlich dargestellt werden.

Dieser C#‑Code zeigt, wie Sie die Beschriftungsposition in einem Kreisdiagramm anpassen:
```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 200, 200);

    IChartSeriesCollection series = chart.ChartData.Series;
    IDataLabel label = series[0].Labels[0];

    label.DataLabelFormat.ShowValue = true;
    label.DataLabelFormat.Position = LegendDataLabelPosition.OutsideEnd;
    label.X = 0.71f;
    label.Y = 0.04f;

    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


![pie-chart-adjusted-label](pie-chart-adjusted-label.png)

## **FAQ**

**Wie kann ich verhindern, dass sich Datenbeschriftungen bei dichten Diagrammen überlappen?**

Kombinieren Sie automatische Beschriftungsplatzierung, Hilfslinien und reduzierte Schriftgröße; bei Bedarf können Sie einige Felder (z. B. die Kategorie) ausblenden oder Beschriftungen nur für extreme bzw. Schlüssel­punkte anzeigen.

**Wie kann ich Beschriftungen nur für Null‑, Negative‑ oder Leere‑Werte deaktivieren?**

Filtern Sie Datenpunkte, bevor Sie Beschriftungen aktivieren, und schalten Sie die Anzeige für Werte von 0, negative Werte oder fehlende Werte gemäß einer definierten Regel aus.

**Wie kann ich einen konsistenten Beschriftungsstil beim Exportieren in PDF/Bilder sicherstellen?**

Setzen Sie Schriftart, Schriftfamilie und Schriftgröße explizit und prüfen Sie, dass die Schriftart auf der Renderseite verfügbar ist, um ein Zurückgreifen auf Ersatzschriften zu vermeiden.