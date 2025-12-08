---
title: Diagrammdatenbeschriftung
type: docs
url: /de/net/chart-data-label/
keywords: "Diagrammdatenbeschriftung,Beschriftungsabstand, C#, Csharp, Aspose.Slides for .NET"
description: "PowerPoint-Diagrammdatenbeschriftung und Abstand in C# oder .NET festlegen"
---

Datenbeschriftungen in einem Diagramm zeigen Details zu den Diagrammdatenreihen oder einzelnen Datenpunkten. Sie ermöglichen es den Lesern, Datenreihen schnell zu identifizieren, und sie machen Diagramme auch leichter verständlich.

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


## **Prozentsatz als Beschriftungen anzeigen**

Aspose.Slides for .NET ermöglicht das Festlegen von Prozentwerten als Beschriftungen in angezeigten Diagrammen. Dieser C#‑Code demonstriert die Vorgehensweise:
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


## **Prozentzeichen bei Diagrammbeschriftungen festlegen**

Dieser C#‑Code zeigt, wie Sie das Prozentzeichen für eine Diagrammbeschriftung festlegen:
```c#
// Erstellt eine Instanz der Presentation-Klasse
Presentation presentation = new Presentation();

// Holt die Referenz einer Folie über ihren Index
ISlide slide = presentation.Slides[0];

// Erstellt das PercentsStackedColumn-Diagramm auf einer Folie
IChart chart = slide.Shapes.AddChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400);

// Setzt NumberFormatLinkedToSource auf false
chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.NumberFormat = "0.00%";

chart.ChartData.Series.Clear();
int defaultWorksheetIndex = 0;

// Holt das Arbeitsblatt für die Diagrammdaten
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

// Setzt die Eigenschaften von LabelFormat
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


## **Beschriftungsabstand von der Achse festlegen**

Dieser C#‑Code zeigt, wie Sie den Beschriftungsabstand von einer Kategorienachse festlegen, wenn Sie ein Diagramm aus Achsen erstellen:
```c#
// Erstellt eine Instanz der Presentation-Klasse
Presentation presentation = new Presentation();

// Holt die Referenz einer Folie
ISlide sld = presentation.Slides[0];

// Erstellt ein Diagramm auf der Folie
IChart ch = sld.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

// Setzt den Beschriftungsabstand von einer Achse
ch.Axes.HorizontalAxis.LabelOffset = 500;

// Schreibt die Präsentation auf die Festplatte
presentation.Save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat.Pptx);
```


## **Beschriftungsposition anpassen**

Wenn Sie ein Diagramm erstellen, das keine Achse verwendet, wie ein Kreisdiagramm, können die Datenbeschriftungen des Diagramms zu nahe am Rand liegen. In einem solchen Fall müssen Sie die Position der Datenbeschriftung anpassen, damit die Führungslinien deutlich angezeigt werden.

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

**Wie kann ich verhindern, dass Datenbeschriftungen in dichten Diagrammen überlappen?**

Kombinieren Sie automatische Beschriftungsplatzierung, Führungslinien und reduzierte Schriftgröße; bei Bedarf können Sie einige Felder (z. B. die Kategorie) ausblenden oder Beschriftungen nur für extreme/Schlüsselpunkte anzeigen.

**Wie kann ich Beschriftungen nur für Null‑, Negative‑ oder Leere‑Werte deaktivieren?**

Filtern Sie Datenpunkte, bevor Sie Beschriftungen aktivieren, und schalten Sie die Anzeige für Werte von 0, negative Werte oder fehlende Werte gemäß einer definierten Regel aus.

**Wie kann ich einen konsistenten Beschriftungsstil beim Exportieren in PDF/Bilder sicherstellen?**

Legen Sie Schriftarten (Familie, Größe) explizit fest und prüfen Sie, dass die Schriftart auf der Renderseite verfügbar ist, um ein Zurückgreifen zu vermeiden.