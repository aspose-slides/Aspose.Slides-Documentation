---
title: Gestisci le etichette dei dati del grafico nelle presentazioni in .NET
linktitle: Etichetta dati
type: docs
url: /it/net/chart-data-label/
keywords:
- grafico
- etichetta dati
- precisione dati
- percentuale
- distanza etichetta
- posizione etichetta
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Scopri come aggiungere e formattare le etichette dei dati dei grafici nelle presentazioni PowerPoint usando Aspose.Slides per .NET per diapositive più coinvolgenti."
---
## **Introduzione**

Le etichette dei dati su un grafico mostrano i dettagli sulla serie di dati del grafico o sui singoli punti dati. Consentono ai lettori di identificare rapidamente le serie di dati e rendono i grafici più facili da comprendere.

## **Imposta la precisione dei dati nelle etichette dei grafici**

Questo codice C# mostra come impostare la precisione dei dati in un'etichetta di un grafico:

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 50, 50, 450, 300);
	chart.HasDataTable = true;
	chart.ChartData.Series[0].NumberFormatOfValues = "#,##0.00";

	pres.Save("PrecisionOfDatalabels_out.pptx", SaveFormat.Pptx);
}
```

## **Visualizza la percentuale come etichette**
Aspose.Slides per .NET consente di impostare etichette percentuali sui grafici visualizzati. Questo codice C# dimostra l'operazione:

```c#
// Crea un'istanza della classe Presentation
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

// Salva la presentazione contenente il grafico
presentation.Save("DisplayPercentageAsLabels_out.pptx", SaveFormat.Pptx);
```

## **Imposta il simbolo percentuale con le etichette dei dati del grafico**
Questo codice C# mostra come impostare il simbolo di percentuale per un'etichetta di un grafico:

```c#
// Crea un'istanza della classe Presentation
Presentation presentation = new Presentation();

// Ottiene il riferimento di una diapositiva tramite il suo indice
ISlide slide = presentation.Slides[0];

// Crea il grafico PercentsStackedColumn su una diapositiva
IChart chart = slide.Shapes.AddChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400);

// Imposta NumberFormatLinkedToSource su false
chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.NumberFormat = "0.00%";

chart.ChartData.Series.Clear();
int defaultWorksheetIndex = 0;

// Ottiene il foglio di lavoro dei dati del grafico
IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

// Aggiunge una nuova serie
IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Reds"), chart.Type);
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 0.30));
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 0.50));
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 0.80));
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 4, 1, 0.65));

// Imposta il colore di riempimento della serie
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;

// Imposta le proprietà di LabelFormat
series.Labels.DefaultDataLabelFormat.ShowValue = true;
series.Labels.DefaultDataLabelFormat.IsNumberFormatLinkedToSource = false;
series.Labels.DefaultDataLabelFormat.NumberFormat = "0.0%";
series.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FontHeight = 10;
series.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
series.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.White;
series.Labels.DefaultDataLabelFormat.ShowValue = true;

// Aggiunge una nuova serie
IChartSeries series2 = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 2, "Blues"), chart.Type);
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 2, 0.70));
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 2, 0.50));
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 2, 0.20));
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 4, 2, 0.35));

// Imposta il tipo di riempimento e il colore
series2.Format.Fill.FillType = FillType.Solid;
series2.Format.Fill.SolidFillColor.Color = Color.Blue;
series2.Labels.DefaultDataLabelFormat.ShowValue = true;
series2.Labels.DefaultDataLabelFormat.IsNumberFormatLinkedToSource = false;
series2.Labels.DefaultDataLabelFormat.NumberFormat = "0.0%";
series2.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FontHeight = 10;
series2.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
series2.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.White;

// Scrive la presentazione su disco
presentation.Save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx);
```

## **Imposta la distanza dell'etichetta da un asse**
Questo codice C# mostra come impostare la distanza dell'etichetta da un asse di categoria quando si lavora con un grafico tracciato da assi:

```c#
// Crea un'istanza della classe Presentation
Presentation presentation = new Presentation();

// Ottiene il riferimento di una diapositiva
ISlide sld = presentation.Slides[0];

// Crea un grafico sulla diapositiva
IChart ch = sld.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

// Imposta la distanza dell'etichetta da un asse
ch.Axes.HorizontalAxis.LabelOffset = 500;

// Scrive la presentazione su disco
presentation.Save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat.Pptx);
```

## **Regola la posizione dell'etichetta**

Quando crei un grafico che non si basa su alcun asse, come un grafico a torta, le etichette dei dati del grafico possono risultare troppo vicine al bordo. In tal caso, è necessario regolare la posizione dell'etichetta in modo che le linee guida vengano visualizzate chiaramente.

Questo codice C# mostra come regolare la posizione dell'etichetta su un grafico a torta:

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

**Come posso impedire che le etichette dei dati si sovrappongano su grafici densi?**

Combina il posizionamento automatico delle etichette, le linee guida e la riduzione della dimensione del carattere; se necessario, nascondi alcuni campi (ad esempio, la categoria) o mostra le etichette solo per i punti estremi/chiave.

**Come posso disattivare le etichette solo per valori zero, negativi o vuoti?**

Filtra i punti dati prima di abilitare le etichette e disattiva la visualizzazione per i valori pari a 0, i valori negativi o i valori mancanti secondo una regola definita.

**Come posso garantire uno stile di etichetta coerente durante l'esportazione in PDF/immagini?**

Imposta esplicitamente i caratteri (famiglia, dimensione) e verifica che il carattere sia disponibile sul lato di rendering per evitare il fallback.