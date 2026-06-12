---
title: Správa popisků dat v grafech v prezentacích v .NET
linktitle: Popisek dat
type: docs
url: /cs/net/chart-data-label/
keywords:
- graf
- popisek dat
- přesnost dat
- procento
- vzdálenost popisku
- umístění popisku
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Naučte se přidávat a formátovat popisky dat v grafech v prezentacích PowerPoint pomocí Aspose.Slides pro .NET pro poutavější snímky."
---
## **Úvod**

Popisky dat v grafu zobrazují podrobnosti o datových sériích grafu nebo jednotlivých bodech. Umožňují čtenářům rychle identifikovat datové řady a také usnadňují pochopení grafů.

## **Nastavení přesnosti dat v popiscích grafu**

Tento C# kód ukazuje, jak nastavit přesnost dat v popisku grafu:

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 50, 50, 450, 300);
	chart.HasDataTable = true;
	chart.ChartData.Series[0].NumberFormatOfValues = "#,##0.00";

	pres.Save("PrecisionOfDatalabels_out.pptx", SaveFormat.Pptx);
}
```

## **Zobrazení procent jako popisků**
Aspose.Slides pro .NET umožňuje nastavit procentuální popisky v zobrazených grafech. Tento C# kód demonstruje operaci:

```c#
// Vytvoří instanci třídy Presentation
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

// Uloží prezentaci obsahující graf
presentation.Save("DisplayPercentageAsLabels_out.pptx", SaveFormat.Pptx);
```

## **Nastavení procentuálního znaku v popiscích grafu**
Tento C# kód ukazuje, jak nastavit procentuální znak pro popisek grafu:

```c#
// Vytvoří instanci třídy Presentation
Presentation presentation = new Presentation();

// Získá referenci na snímek přes jeho index
ISlide slide = presentation.Slides[0];

// Vytvoří graf PercentsStackedColumn na snímku
IChart chart = slide.Shapes.AddChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400);

// Nastaví NumberFormatLinkedToSource na false
chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.NumberFormat = "0.00%";

chart.ChartData.Series.Clear();
int defaultWorksheetIndex = 0;

// Gets the chart data worksheet
IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

// Přidá novou sérii
IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Reds"), chart.Type);
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 0.30));
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 0.50));
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 0.80));
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 4, 1, 0.65));

// Nastaví výplňovou barvu série
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;

// Nastaví vlastnosti LabelFormat
series.Labels.DefaultDataLabelFormat.ShowValue = true;
series.Labels.DefaultDataLabelFormat.IsNumberFormatLinkedToSource = false;
series.Labels.DefaultDataLabelFormat.NumberFormat = "0.0%";
series.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FontHeight = 10;
series.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
series.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.White;
series.Labels.DefaultDataLabelFormat.ShowValue = true;

// Přidá novou sérii
IChartSeries series2 = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 2, "Blues"), chart.Type);
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 2, 0.70));
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 2, 0.50));
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 2, 0.20));
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 4, 2, 0.35));

// Nastaví typ výplně a barvu
series2.Format.Fill.FillType = FillType.Solid;
series2.Format.Fill.SolidFillColor.Color = Color.Blue;
series2.Labels.DefaultDataLabelFormat.ShowValue = true;
series2.Labels.DefaultDataLabelFormat.IsNumberFormatLinkedToSource = false;
series2.Labels.DefaultDataLabelFormat.NumberFormat = "0.0%";
series2.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FontHeight = 10;
series2.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
series2.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.White;

// Zapíše prezentaci na disk
presentation.Save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx);
```

## **Nastavení vzdálenosti popisku od osy**
Tento C# kód ukazuje, jak nastavit vzdálenost popisku od kategoriové osy při práci s grafem vykresleným podle os:

```c#
// Vytvoří instanci třídy Presentation
Presentation presentation = new Presentation();

// Získá referenci na snímek
ISlide sld = presentation.Slides[0];

// Vytvoří graf na snímku
IChart ch = sld.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

// Nastaví vzdálenost popisku od osy
ch.Axes.HorizontalAxis.LabelOffset = 500;

// Zapíše prezentaci na disk
presentation.Save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat.Pptx);
```

## **Úprava umístění popisku**

Když vytvoříte graf, který nespoléhá na žádnou osu, například koláčový graf, mohou být popisky dat příliš blízko okraji grafu. V takovém případě musíte upravit umístění popisku, aby byly vodící čáry zobrazeny jasně.

Tento C# kód ukazuje, jak upravit umístění popisku v koláčovém grafu: 

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

**Jak mohu zabránit překrývání popisků dat v hustých grafech?**

Kombinujte automatické umístění popisků, vodící čáry a zmenšení velikosti písma; v případě potřeby skryjte některá pole (například kategorii) nebo zobrazte popisky jen pro extrémní/klíčové body.

**Jak mohu zakázat popisky pouze pro nulové, záporné nebo prázdné hodnoty?**

Filtrujte datové body před povolením popisků a vypněte jejich zobrazování pro hodnoty 0, záporné hodnoty nebo chybějící hodnoty podle definovaného pravidla.

**Jak zajistit jednotný styl popisků při exportu do PDF/obrázků?**

Explicitně nastavte písma (rodinu, velikost) a ověřte, že písmo je k dispozici na straně vykreslování, aby se předešlo náhradnímu fontu.