---
title: Hantera diagramdataetiketter i presentationer i .NET
linktitle: Dataetikett
type: docs
url: /sv/net/chart-data-label/
keywords:
- diagram
- dataetikett
- dataprecision
- procent
- etikettavstånd
- etikettposition
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Lär dig att lägga till och formatera diagramdataetiketter i PowerPoint-presentationer med Aspose.Slides för .NET för mer engagerande bildspel."
---
## **Introduktion**

Dataetiketter på ett diagram visar detaljer om diagrammets dataserier eller enskilda datapunkter. De låter läsare snabbt identifiera dataserier och gör diagrammen också lättare att förstå.

## **Ställ in dataprecision i diagrammets dataetiketter**

Den här C#-koden visar hur du ställer in dataprecisionen i en diagramdataetikett:

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 50, 50, 450, 300);
	chart.HasDataTable = true;
	chart.ChartData.Series[0].NumberFormatOfValues = "#,##0.00";

	pres.Save("PrecisionOfDatalabels_out.pptx", SaveFormat.Pptx);
}
```

## **Visa procent som etiketter**
Aspose.Slides för .NET låter dig ange procentetiketter på visade diagram. Den här C#-koden demonstrerar funktionen:

```c#
// Skapar en instans av Presentation-klassen
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

// Sparar presentationen som innehåller diagrammet
presentation.Save("DisplayPercentageAsLabels_out.pptx", SaveFormat.Pptx);
```

## **Ange procenttecken med diagrammets dataetiketter**
Den här C#-koden visar hur du anger procenttecknet för en diagramdataetikett:

```c#
// Skapar en instans av Presentation-klassen
Presentation presentation = new Presentation();

// Hämtar en slieds referens via dess index
ISlide slide = presentation.Slides[0];

// Skapar diagrammet PercentsStackedColumn på en slide
IChart chart = slide.Shapes.AddChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400);

// Ställer in NumberFormatLinkedToSource till false
chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.NumberFormat = "0.00%";

chart.ChartData.Series.Clear();
int defaultWorksheetIndex = 0;

// Hämtar diagrammets dataarbetsbok
IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

// Lägger till en ny serie
IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Reds"), chart.Type);
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 0.30));
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 0.50));
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 0.80));
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 4, 1, 0.65));

// Ställer in fyllnadsfärgen för serien
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;

// Ställer in egenskaperna för LabelFormat
series.Labels.DefaultDataLabelFormat.ShowValue = true;
series.Labels.DefaultDataLabelFormat.IsNumberFormatLinkedToSource = false;
series.Labels.DefaultDataLabelFormat.NumberFormat = "0.0%";
series.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FontHeight = 10;
series.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
series.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.White;
series.Labels.DefaultDataLabelFormat.ShowValue = true;

// Lägger till en ny serie
IChartSeries series2 = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 2, "Blues"), chart.Type);
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 2, 0.70));
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 2, 0.50));
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 2, 0.20));
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 4, 2, 0.35));

// Ställer in fyllnadstyp och färg
series2.Format.Fill.FillType = FillType.Solid;
series2.Format.Fill.SolidFillColor.Color = Color.Blue;
series2.Labels.DefaultDataLabelFormat.ShowValue = true;
series2.Labels.DefaultDataLabelFormat.IsNumberFormatLinkedToSource = false;
series2.Labels.DefaultDataLabelFormat.NumberFormat = "0.0%";
series2.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FontHeight = 10;
series2.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
series2.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.White;

// Skriver presentationen till disk
presentation.Save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx);
```

## **Ställ in etikettavstånd från en axel**
Den här C#-koden visar hur du ställer in etikettavståndet från en kategoriaxel när du arbetar med ett diagram som ritas från axlar:

```c#
// Skapar en instans av Presentation-klassen
Presentation presentation = new Presentation();

// Hämtar en slids referens
ISlide sld = presentation.Slides[0];

// Skapar ett diagram på sliden
IChart ch = sld.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

// Ställer in etikettavståndet från en axel
ch.Axes.HorizontalAxis.LabelOffset = 500;

// Skriver presentationen till disk
presentation.Save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat.Pptx);
```

## **Justera etikettposition**

När du skapar ett diagram som inte bygger på någon axel, såsom ett cirkeldiagram, kan diagrammets dataetiketter hamna för nära kanten. I så fall måste du justera etikettens position så att förbindelselinjterna visas tydligt.

Den här C#-koden visar hur du justerar etikettpositionen i ett cirkeldiagram: 

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

## **Vanliga frågor**

**Hur kan jag förhindra att dataetiketter överlappar i täta diagram?**

Kombinera automatisk etikettplacering, förbindelselinjner och minskad teckenstorlek; om nödvändigt, dölj vissa fält (t.ex. kategorin) eller visa etiketter endast för extrema/nyckelpunkter.

**Hur kan jag inaktivera etiketter endast för noll-, negativa eller tomma värden?**

Filtrera datapunkter innan du aktiverar etiketter och stäng av visning för värden som är 0, negativa värden eller saknade värden enligt en definierad regel.

**Hur kan jag säkerställa en konsekvent etikettstil vid export till PDF/bilder?**

Ange explicit typsnitt (familj, storlek) och verifiera att typsnittet är tillgängligt på renderingssidan för att undvika reservtypsnitt.