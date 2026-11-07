---
title: Gestire le etichette dati del grafico nelle presentazioni in .NET
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
description: "Impara a aggiungere e formattare le etichette dati dei grafici nelle presentazioni PowerPoint utilizzando Aspose.Slides per .NET per diapositive più coinvolgenti."
---
## **Introduzione**

Le etichette dati mostrano informazioni sulle serie del grafico e sui singoli punti dati, aiutando i lettori a identificare i valori e a comprendere il grafico. Questo articolo spiega come formattare i valori, visualizzare le percentuali, leggere il testo delle etichette, controllare le etichette oltre il valore massimo dell’asse, regolare la spaziatura delle etichette dell’asse delle categorie e posizionare le etichette di un grafico a torta.

## **Conteggio delle etichette dati visibili**

Usa [CountOfVisibleDataLabels](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelcollection/countofvisibledatalabels/) per verificare quante etichette dati sono abilitate per la visualizzazione prima di pubblicare una presentazione. A differenza di [Count](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelcollection/count/), che restituisce il numero totale di etichette nella collezione, tiene conto delle impostazioni predefinite della serie e di quelle delle singole etichette.

Questo esempio crea un grafico a colonne con una serie e tre punti dati. Accede alla collezione [Labels](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/labels/) della serie e stampa il conteggio visibile man mano che le impostazioni cambiano: **0, 3, 2, 3**. Il conteggio totale rimane **3**.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
var seriesCell = workbook.GetCell(0, 0, 1, "Values");
var series = chart.ChartData.Series.Add(seriesCell, chart.Type);

for (int i = 0; i < 3; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, $"Category {i + 1}");
    chart.ChartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(0, i + 1, 1, (i + 1) * 10);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

var labels = series.Labels;
Console.WriteLine($"Total: {labels.Count}; visible: {labels.CountOfVisibleDataLabels}"); // Totale: 3; visibili: 0

labels.DefaultDataLabelFormat.ShowValue = true;
Console.WriteLine($"Visible: {labels.CountOfVisibleDataLabels}"); // Visibili: 3

labels[1].DataLabelFormat.ShowValue = false;
Console.WriteLine($"Visible: {labels.CountOfVisibleDataLabels}"); // Visibili: 2

labels[1].DataLabelFormat.ShowLegendKey = true;
Console.WriteLine($"Visible: {labels.CountOfVisibleDataLabels}"); // Visibili: 3
```

Le impostazioni predefinite della serie sono fornite da [DefaultDataLabelFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelcollection/defaultdatalabelformat/). Abilitare [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) lì visualizza i valori per tutte e tre le etichette. Impostarlo su `false` tramite il [DataLabelFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/datalabelformat/) di un’etichetta sovrascrive tale impostazione per l’etichetta selezionata. Abilitare [ShowLegendKey](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showlegendkey/) fa sì che quell’etichetta conti nuovamente come visibile, anche se il suo valore rimane nascosto.

Il conteggio visibile riflette le impostazioni di visibilità. Non misura se le etichette si sovrappongono, vengono ritagliate o sono leggibili nel grafico renderizzato.

## **Imposta la precisione dei valori nelle etichette dati del grafico**

Usa [NumberFormatOfValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/numberformatofvalues/) per formattare i valori della serie. Questo esempio crea un grafico a linee con dati predefiniti, visualizza la sua tabella dati e abilita le etichette valore per la prima serie. Il formato `#,##0.00` mostra il separatore delle migliaia e due cifre decimali senza modificare i valori sottostanti.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 450, 300);
chart.HasDataTable = true;

var series = chart.ChartData.Series[0];
series.NumberFormatOfValues = "#,##0.00";
series.Labels.DefaultDataLabelFormat.ShowValue = true;

presentation.Save("PrecisionOfDatalabels_out.pptx", SaveFormat.Pptx);
```

Per formattare le celle numeriche nella cartella di lavoro incorporata di un grafico, vedi [Imposta formati numerici personalizzati per le celle della cartella di lavoro](/slides/it/net/chart-workbook/#set-custom-number-formats-for-workbook-cells). Quell’esempio mostra anche le etichette valore che seguono i formati delle celle di origine, preservando i valori numerici memorizzati.

## **Visualizza la percentuale come etichette**

Per un grafico a colonne impilate, calcola ogni valore come percentuale del totale della sua categoria e assegna il testo a [TextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/). Questo esempio utilizza i dati predefiniti del grafico e visualizza le percentuali con due decimali in un carattere da 8 pt. Le categorie con un totale pari a zero vengono saltate per evitare divisioni per zero. Ricalcola il testo personalizzato dell’etichetta se i dati del grafico cambiano.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.StackedColumn, 20, 20, 400, 400);

var categoryTotals = new double[chart.ChartData.Categories.Count];
for (int k = 0; k < chart.ChartData.Categories.Count; k++)
{
    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        var series = chart.ChartData.Series[i];
        var pointValue = Convert.ToDouble(series.DataPoints[k].Value.Data);
        categoryTotals[k] += pointValue;
    }
}

for (int x = 0; x < chart.ChartData.Series.Count; x++)
{
    var series = chart.ChartData.Series[x];
    series.Labels.DefaultDataLabelFormat.ShowLegendKey = false;

    for (int j = 0; j < series.DataPoints.Count; j++)
    {
        var label = series.DataPoints[j].Label;
        if (categoryTotals[j] == 0)
        {
            continue;
        }

        var pointValue = Convert.ToDouble(series.DataPoints[j].Value.Data);
        var dataPointPercent = (pointValue / categoryTotals[j]) * 100;

        var portion = new Portion();
        portion.Text = string.Format("{0:F2} %", dataPointPercent);
        portion.PortionFormat.FontHeight = 8f;

        label.TextFrameForOverriding.Text = "";

        var paragraph = label.TextFrameForOverriding.Paragraphs[0];
        paragraph.Portions.Add(portion);

        label.DataLabelFormat.ShowValue = true;
        label.DataLabelFormat.ShowSeriesName = false;
        label.DataLabelFormat.ShowPercentage = false;
        label.DataLabelFormat.ShowLegendKey = false;
        label.DataLabelFormat.ShowCategoryName = false;
        label.DataLabelFormat.ShowBubbleSize = false;
    }
}

presentation.Save("DisplayPercentageAsLabels_out.pptx", SaveFormat.Pptx);
```

## **Imposta il segno percentuale con le etichette dei dati del grafico**

Quando i valori sono memorizzati come frazioni, usa [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/numberformat/) per visualizzare le percentuali. Imposta [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) su `false` per applicare il formato dell’etichetta in modo indipendente dalle celle di origine.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400);

chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.NumberFormat = "0.00%";

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
int worksheetIndex = 0;
for (int i = 0; i < 4; i++)
{
    var categoryCell = workbook.GetCell(worksheetIndex, i + 1, 0, $"Category {i + 1}");
    chart.ChartData.Categories.Add(categoryCell);
}

string[] seriesNames = { "Reds", "Blues" };
Color[] seriesColors = { Color.Red, Color.Blue };
double[,] values = { { 0.30, 0.50, 0.80, 0.65 }, { 0.70, 0.50, 0.20, 0.35 } };

for (int i = 0; i < seriesNames.Length; i++)
{
    var seriesCell = workbook.GetCell(worksheetIndex, 0, i + 1, seriesNames[i]);
    var series = chart.ChartData.Series.Add(seriesCell, chart.Type);
    for (int j = 0; j < 4; j++)
    {
        var valueCell = workbook.GetCell(worksheetIndex, j + 1, i + 1, values[i, j]);
        series.DataPoints.AddDataPointForBarSeries(valueCell);
    }

    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = seriesColors[i];

    var labelFormat = series.Labels.DefaultDataLabelFormat;
    labelFormat.ShowValue = true;
    labelFormat.IsNumberFormatLinkedToSource = false;
    labelFormat.NumberFormat = "0.0%";
    labelFormat.TextFormat.PortionFormat.FontHeight = 10;
    labelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
    labelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.White;
}

presentation.Save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx);
```

## **Leggi il testo effettivo delle etichette dei dati**

Usa [GetActualLabelText](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/getactuallabeltext/) per recuperare il testo prodotto dalle impostazioni di un’etichetta dati. Questo è utile quando si estraggono le etichette per report, si ricerca il contenuto di una presentazione o si convalidano i grafici generati. Nell’esempio seguente, il formato predefinito delle [etichette dati](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/) combina il nome di ogni categoria, il nome della serie e il valore. Un punto formatta il suo valore come percentuale, e un altro utilizza testo personalizzato da [TextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/).

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Q1"));
chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Q2"));

var north = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "North"), chart.Type);
north.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 1, 0.25));
north.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 1, 0.75));

var south = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "South"), chart.Type);
south.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 2, 0.40));
south.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 2, 0.60));

foreach (var series in chart.ChartData.Series)
{
    var format = series.Labels.DefaultDataLabelFormat;
    format.ShowCategoryName = true;
    format.ShowSeriesName = true;
    format.ShowValue = true;
}

north.Labels[1].DataLabelFormat.IsNumberFormatLinkedToSource = false;
north.Labels[1].DataLabelFormat.NumberFormat = "0%";
south.Labels[0].TextFrameForOverriding.Text = "Reviewed";

foreach (var series in chart.ChartData.Series)
{
    foreach (var point in series.DataPoints)
    {
        var label = point.Label;
        if (!label.IsVisible)
        {
            continue;
        }

        Console.WriteLine($"Value: {point.Value.Data}; label: {label.GetActualLabelText()}");
    }
}
```

Il numero memorizzato in un punto dati rimane `0.75`, anche quando la sua etichetta mostra `75%` insieme ai nomi di categoria e di serie. Il testo personalizzato sostituisce il testo generato dell’etichetta. [GetActualLabelText](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/getactuallabeltext/) restituisce la stringa finale dell’etichetta in entrambi i casi. Controlla [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/isvisible/) separatamente, come mostrato sopra, quando vuoi estrarre solo le etichette visibili.

## **Controlla le etichette dei dati oltre il valore massimo dell'asse**

Quando limiti manualmente l’intervallo di un asse, alcuni punti dati possono superare il valore massimo. Usa [ShowDataLabelsOverMaximum](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/showdatalabelsovermaximum/) per controllare se le loro etichette dati vengono mostrate. Questa impostazione modifica la visibilità delle etichette; non cambia l’intervallo dell’asse né i valori dei dati sottostanti.

L’esempio seguente crea un grafico a colonne raggruppate 2D con valori 60 e 120. Imposta [IsAutomaticMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticmaxvalue/) su `false` e [MaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/maxvalue/) a 100 sull’asse verticale. La prima diapositiva consente etichette oltre il massimo; una copia di quella diapositiva le disabilita. Entrambe le diapositive sono salvate in `DataLabelsOverMaximum.pptx`.

Abilita le etichette valore con [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/). L’impostazione a livello di grafico non abilita la visualizzazione dei valori di per sé né sovrascrive la visualizzazione disabilitata di un’etichetta individuale. Questo esempio abilita i valori per l’intera serie e usa [Position](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/position/) per posizionare le etichette all’estremità esterna di ogni colonna.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
chart.HasLegend = false;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;

var firstCategory = workbook.GetCell(0, 1, 0, "Within range");
var secondCategory = workbook.GetCell(0, 2, 0, "Above maximum");

chart.ChartData.Categories.Add(firstCategory);
chart.ChartData.Categories.Add(secondCategory);

var seriesName = workbook.GetCell(0, 0, 1, "Values");
var series = chart.ChartData.Series.Add(seriesName, chart.Type);

var firstValue = workbook.GetCell(0, 1, 1, 60);
var secondValue = workbook.GetCell(0, 2, 1, 120);

series.DataPoints.AddDataPointForBarSeries(firstValue);
series.DataPoints.AddDataPointForBarSeries(secondValue);

series.Labels.DefaultDataLabelFormat.ShowValue = true;
series.Labels.DefaultDataLabelFormat.Position = LegendDataLabelPosition.OutsideEnd;

chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.MaxValue = 100;
chart.ShowDataLabelsOverMaximum = true;

var secondSlide = presentation.Slides.AddClone(slide);
var secondChart = (IChart)secondSlide.Shapes[0];
secondChart.ShowDataLabelsOverMaximum = false;

presentation.Save("DataLabelsOverMaximum.pptx", SaveFormat.Pptx);
```

Le immagini seguenti mostrano le diapositive salvate renderizzate da Microsoft PowerPoint. Con `true`, l’etichetta **120** è visibile al limite superiore; con `false`, è nascosta. L’etichetta **60** rimane visibile, il valore massimo dell’asse resta **100** e il secondo punto dati rimane **120** in entrambi i casi.

| ShowDataLabelsOverMaximum = true | ShowDataLabelsOverMaximum = false |
| --- | --- |
| ![Grafico PowerPoint che mostra l'etichetta valore 120 con un valore massimo dell'asse di 100](data-labels-over-maximum-true.png) | ![Grafico PowerPoint che nasconde l'etichetta valore 120 con un valore massimo dell'asse di 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Tipo di grafico" %}}
Questo esempio utilizza un grafico a colonne 2D con un asse dei valori. I grafici senza asse dei valori, come i grafici a torta e a ciambella, non hanno un valore massimo dell’asse da limitare in questo modo.
{{% /alert %}}

## **Imposta la distanza dell'etichetta da un asse**

Usa [LabelOffset](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/labeloffset/) per controllare la distanza tra le etichette dell’asse delle categorie e l’asse stesso. Il valore è una percentuale della dimensione massima del carattere delle etichette dell’asse. Questo esempio crea un grafico a colonne raggruppate e imposta lo spostamento delle etichette dell’asse orizzontale a 500. Questa impostazione influisce sulle etichette dell’asse delle categorie anziché su quelle associate ai singoli punti dati.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
chart.Axes.HorizontalAxis.LabelOffset = 500;

presentation.Save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat.Pptx);
```

## **Regola la posizione dell'etichetta**

Su un grafico a torta, regola le posizioni delle etichette dati per migliorare la spaziatura e creare spazio per le linee guida.

Questo esempio visualizza il valore del primo punto dati, posiziona la sua etichetta all’esterno della fetta e regola gli spostamenti [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) e [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/). Questi spostamenti sono relativi alla larghezza e all’altezza del grafico, rispettivamente.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 200, 200);
var series = chart.ChartData.Series;

var label = series[0].Labels[0];
label.DataLabelFormat.ShowValue = true;
label.DataLabelFormat.Position = LegendDataLabelPosition.OutsideEnd;
label.X = 0.71f;
label.Y = 0.04f;

presentation.Save("presentation.pptx", SaveFormat.Pptx);
```

![Grafico a torta con una posizione dell'etichetta dati regolata](pie-chart-adjusted-label.png)

## **Formatta le linee leader**

Quando le etichette di un grafico a torta si trovano all’esterno delle fette, le linee leader aiutano i lettori a corrispondere ogni valore alla fetta corretta. Un colore di contrasto e una linea leggermente più spessa possono rendere queste connessioni più facili da seguire, mentre la trasparenza e uno stile tratteggiato mantengono le linee visivamente poco invasive.

Usa [LeaderLinesFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/datalabelcollection/leaderlinesformat/) per formattare le linee leader a livello della collezione di etichette dati della serie. Le impostazioni in `series.Labels.LeaderLinesFormat.Line` si applicano all’intera collezione, non a un’etichetta singola.

Questo esempio crea un grafico a torta con dati predefiniti, visualizza i valori all’esterno delle fette e abilita [ShowLeaderLines](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showleaderlines/). Sposta due etichette più lontano dalle loro fette usando gli spostamenti [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) e [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/), espressi come frazioni della larghezza e dell’altezza del grafico. Non è necessaria alcuna presentazione di input.

Il [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/fillformat/) della linea imposta un colore blu solido con un valore alpha di 191 su 255, fornendo circa il 25 % di trasparenza. [Width](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/width/) imposta lo spessore a 2 pt, e [DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) rende la linea tratteggiata.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 80, 50, 560, 400);
chart.HasLegend = false;

var series = chart.ChartData.Series[0];

var labelFormat = series.Labels.DefaultDataLabelFormat;
labelFormat.ShowValue = true;
labelFormat.Position = LegendDataLabelPosition.OutsideEnd;
labelFormat.ShowLeaderLines = true;

// Sposta due etichette più lontano dalle loro fette.
series.Labels[0].X = 0.10f;
series.Labels[0].Y = -0.05f;
series.Labels[1].X = -0.10f;
series.Labels[1].Y = 0.05f;

var line = series.Labels.LeaderLinesFormat.Line;
line.FillFormat.FillType = FillType.Solid;
line.FillFormat.SolidFillColor.Color = Color.FromArgb(191, 30, 90, 160);
line.Width = 2;
line.DashStyle = LineDashStyle.Dash;

presentation.Save("FormattedLeaderLines.pptx", SaveFormat.Pptx);
```

Abilitare le linee leader non garantisce che una linea compaia per ogni etichetta. La visibilità dipende dal posizionamento delle etichette e dal comportamento di layout del grafico. In questo esempio, le due etichette spostate hanno linee leader visibili; le etichette rimaste vicine alle loro fette non ne hanno bisogno.

L’immagine seguente mostra il file `FormattedLeaderLines.pptx` salvato e renderizzato con Aspose.Slides:

![Grafico a torta con linee leader blu, semitrasparenti e tratteggiate che collegano due etichette esterne alle loro fette](formatted-leader-lines.png)

## **Aggiungi più righe di etichette dati sopra un grafico a colonne**

Questo esempio crea un grafico a colonne con due righe di etichette dati sopra l’area del grafico. La Serie A visualizza le colonne visibili, mentre le Serie B e Serie C forniscono le etichette aggiuntive. Le loro colonne sono nascoste rimuovendo riempimento e contorno. La proprietà [Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/overlap/) allinea tutte e tre le serie con gli stessi centri di categoria.

Le impostazioni del [PlotArea](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotarea/) riservano spazio per le righe di etichette. Dopo che [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/) calcola le posizioni predefinite, [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) e [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/) mantengono l’allineamento orizzontale e applicano spostamenti verticali per disporre le etichette in due righe. I numeri rimangono etichette dati collegate ai valori della serie; solo le intestazioni delle righe sono forme di testo separate.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 40, 40, 640, 200);
chart.HasTitle = false;
chart.HasLegend = false;
chart.TextFormat.PortionFormat.FontHeight = 12;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

string[] categories = { "North", "South", "East", "West" };
string[] seriesNames = { "Series A", "Series B", "Series C" };
double[,] seriesValues = {
    { 35, 42, 28, 47 },
    { 22, 31, 19, 26 },
    { 12, 16, 14, 18 }
};

for (int categoryIndex = 0; categoryIndex < categories.Length; categoryIndex++)
{
    var categoryCell = workbook.GetCell(0, categoryIndex + 1, 0, categories[categoryIndex]);
    chart.ChartData.Categories.Add(categoryCell);
}

for (int seriesIndex = 0; seriesIndex < seriesNames.Length; seriesIndex++)
{
    var seriesCell = workbook.GetCell(0, 0, seriesIndex + 1, seriesNames[seriesIndex]);
    var series = chart.ChartData.Series.Add(seriesCell, ChartType.ClusteredColumn);

    for (int categoryIndex = 0; categoryIndex < categories.Length; categoryIndex++)
    {
        var valueCell = workbook.GetCell(0, categoryIndex + 1, seriesIndex + 1, seriesValues[seriesIndex, categoryIndex]);
        series.DataPoints.AddDataPointForBarSeries(valueCell);
    }

    if (seriesIndex > 0)
    {
        // Nascondi le colonne di B e C, ma mantieni le loro etichette dati.
        series.Format.Fill.FillType = FillType.NoFill;
        series.Format.Line.FillFormat.FillType = FillType.NoFill;
        var labelFormat = series.Labels.DefaultDataLabelFormat;
        labelFormat.ShowValue = true;
        labelFormat.TextFormat.PortionFormat.FontHeight = 12;
        var labelFill = labelFormat.TextFormat.PortionFormat.FillFormat;
        labelFill.FillType = FillType.Solid;
        labelFill.SolidFillColor.Color = Color.Black;
        labelFormat.Position = LegendDataLabelPosition.InsideBase;
    }
}

// Allinea le tre serie con gli stessi centri di categoria.
chart.ChartData.Series[0].ParentSeriesGroup.Overlap = 100;

// Usa meno linee di griglia per questo esempio compatto.
chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.MajorUnit = 10;

// Riserva spazio sopra il tracciato per due righe di etichette dati.
chart.PlotArea.LayoutTargetType = LayoutTargetType.Inner;
chart.PlotArea.X = 0.15f;
chart.PlotArea.Y = 0.32f;
chart.PlotArea.Width = 0.80f;
chart.PlotArea.Height = 0.48f;
chart.ValidateChartLayout();

for (int seriesIndex = 1; seriesIndex < seriesNames.Length; seriesIndex++)
{
    var series = chart.ChartData.Series[seriesIndex];
    float rowTop = seriesIndex == 1 ? 0.15f : 0.03f;

    for (int categoryIndex = 0; categoryIndex < categories.Length; categoryIndex++)
    {
        var dataLabel = series.DataPoints[categoryIndex].Label;
        // Mantieni la posizione orizzontale predefinita. Y è uno spostamento da
        // la posizione predefinita dell'etichetta, espresso come frazione dell'altezza del grafico.
        dataLabel.X = 0;
        dataLabel.Y = rowTop - dataLabel.ActualY / chart.Height;
    }

    // Solo l'intestazione della riga è una forma di testo separata.
    var rowHeading = slide.Shapes.AddAutoShape(ShapeType.Rectangle, chart.X, chart.Y + rowTop * chart.Height, 85, 18);
    rowHeading.FillFormat.FillType = FillType.NoFill;
    rowHeading.LineFormat.FillFormat.FillType = FillType.NoFill;
    rowHeading.AddTextFrame(seriesNames[seriesIndex]);
    rowHeading.TextFrame.TextFrameFormat.MarginTop = 0;
    rowHeading.TextFrame.TextFrameFormat.MarginBottom = 0;
    var headingFormat = rowHeading.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
    headingFormat.FontHeight = 12;
    headingFormat.FillFormat.FillType = FillType.Solid;
    headingFormat.FillFormat.SolidFillColor.Color = Color.Black;
}

presentation.Save("multiple-rows-of-labels.pptx", SaveFormat.Pptx);
```

![Grafico a colonne con due righe di etichette dati sopra l'area del grafico](multiple-rows-of-labels.png)

## **Cambia la forma delle etichette dati**

Aspose.Slides per .NET 26.11 aggiunge [IDataLabel.LabelShapeType](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/labelshapetype/) per un’etichetta e [IDataLabelCollection.DefaultLabelShapeType](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelcollection/defaultlabelshapetype/) per tutte le etichette correnti di una serie. Queste modificano la forma dell’etichetta, non il marcatore del punto. Per l’impostazione di callout separata, vedi [Data Label Callouts](/slides/it/net/callout/).

L’assegnazione della collezione aggiorna le etichette esistenti, quindi applica le sovrascritture individuali **dopo** l’impostazione della collezione. Questo esempio completo richiede [Aspose.Slides per .NET](/slides/it/net/installation/) 26.11 o successiva. Crea etichette valore visibili, seleziona ellissi per la prima serie e poi rende la sua prima etichetta rettangolare.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 350);
var labels = chart.ChartData.Series[0].Labels;
labels.DefaultDataLabelFormat.ShowValue = true;
labels.DefaultLabelShapeType = ShapeType.Ellipse;
labels[0].LabelShapeType = ShapeType.Rectangle;

foreach (var label in labels)
{
    var format = label.DataLabelFormat.Format;
    format.Fill.FillType = FillType.Solid;
    format.Fill.SolidFillColor.Color = Color.LightYellow;
    format.Line.FillFormat.FillType = FillType.Solid;
    format.Line.FillFormat.SolidFillColor.Color = Color.DarkBlue;
}

presentation.Save("label-shapes.pptx", SaveFormat.Pptx);

// Reimposta le scelte di forma esplicite su tutte le etichette attuali.
labels.DefaultLabelShapeType = ShapeType.NotDefined;
presentation.Save("label-shapes-reset.pptx", SaveFormat.Pptx);
```

Riassegnare nuovamente la forma della collezione sostituisce anche le scelte di forma individuali precedenti. [NotDefined](https://reference.aspose.com/slides/net/aspose.slides/shapetype/) cancella la selezione esplicita della forma; non nasconde le etichette né cancella le altre formattazioni. Imposta le forme desiderate dopo aver popolato la serie anziché presumere che i punti aggiunti successivamente ereditino un’assegnazione precedente. In questo esempio vengono usati Rectangle ed Ellipse; ispeziona il risultato renderizzato scegliendo altri tipi di forma.

## **FAQ**

**Come posso impedire la sovrapposizione delle etichette dati su grafici densi?**

Combina il posizionamento automatico delle etichette, le linee leader e una riduzione della dimensione del carattere; se necessario, nascondi alcuni campi (ad esempio, la categoria) o mostra le etichette solo per valori estremi o punti chiave.

**Come posso disabilitare le etichette solo per valori zero, negativi o vuoti?**

Filtra i punti dati prima di abilitare le etichette e disattiva la visualizzazione per valori pari a 0, valori negativi o valori mancanti in base a una regola definita.

**Come posso garantire uno stile coerente delle etichette durante l'esportazione in PDF/immagini?**

Imposta esplicitamente la famiglia e la dimensione del carattere e verifica che il font sia disponibile nell’ambiente di rendering per evitare fallback.