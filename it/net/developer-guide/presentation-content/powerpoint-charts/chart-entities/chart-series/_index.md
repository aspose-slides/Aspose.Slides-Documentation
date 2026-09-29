---
title: Gestire le serie di dati del grafico nelle presentazioni in .NET
linktitle: Serie di dati
type: docs
url: /it/net/chart-series/
keywords:
- serie di grafico
- sovrapposizione della serie
- colore della serie
- colore della categoria
- nome della serie
- punto dati
- spazio della serie
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Scopri come gestire le serie di grafico, i punti dati, le celle della cartella di lavoro, la formattazione, la sovrapposizione, la larghezza dello spazio e i valori negativi nelle presentazioni con C#."
---
## **Panoramica**

Un grafico memorizza i dati tracciati in una cartella di lavoro dei dati del grafico. Un [IChartSeries](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartseries/) rappresenta un insieme di valori correlati e ciascun [IChartDataPoint](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartdatapoint/) nella serie si riferisce a una o più celle della cartella di lavoro. Gli oggetti [IChartCategory](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartcategory/) forniscono le etichette o i valori di raggruppamento condivisi dalle serie. Pertanto il nome della serie, le categorie e i valori dei punti sono collegati a oggetti [IChartDataCell](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartdatacell/) anziché essere memorizzati solo come testo visualizzato.

Per un tipico grafico a categorie, la cartella di lavoro predefinita utilizza la riga 0 per i nomi delle serie, la colonna 0 per i nomi delle categorie e le celle rimanenti per i valori delle serie. Gli indici di foglio di lavoro, riga e colonna passati a [IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartdataworkbook/getcell/) sono basati su zero. Questo layout è utile quando si crea un grafico con dati predefiniti, ma non si deve presumere che ogni grafico esistente lo utilizzi. Per una presentazione caricata, ispezionare le celle a cui fanno riferimento le serie, le categorie e i punti dati prima di modificare i valori della cartella di lavoro.

Le impostazioni del grafico hanno tre ambiti diversi:

- Impostazioni a livello di serie, come [IChartSeries.Format](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartseries/format/), forniscono l’aspetto predefinito per tutti i punti di una serie.
- Impostazioni a livello di punto dati, come [IChartDataPoint.Format](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartdatapoint/format/), sovrascrivono l’aspetto della serie per un singolo punto.
- Le impostazioni di gruppo si applicano a serie compatibili che appartengono allo stesso [IChartSeriesGroup](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartseriesgroup/). Accedere al gruppo tramite [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartseries/parentseriesgroup/) quando si devono impostare opzioni come la sovrapposizione o la larghezza dello spazio.

Quando non è impostato esplicitamente un riempimento per il punto o la serie, lo stile e il tema del grafico determinano l’aspetto automatico. Quando sono presenti sia la formattazione della serie sia quella del punto, la formattazione del punto ha la precedenza per quel punto.

![serie-di-grafico-powerpoint](chart-series-powerpoint.png)

## **Imposta la sovrapposizione della serie del grafico**

[IChartSeries.Overlap](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartseries/overlap/) indica quanto le barre o le colonne si sovrappongono in un grafico 2D, da -100 a 100 percento. È una proiezione di sola lettura dell’impostazione sul gruppo di serie padre. Impostare [IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartseriesgroup/overlap/) per aggiornare tutte le serie compatibili in quel gruppo. Questa opzione si applica ai tipi di grafico che mostrano barre o colonne raggruppate; non influisce sui gruppi di serie non correlati in un grafico combinato.

L’esempio seguente imposta la sovrapposizione per il gruppo che contiene la prima serie:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const sbyte overlapPercent = 30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

// Il nuovo grafico contiene serie, categorie e valori di esempio.
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.ParentSeriesGroup.Overlap = overlapPercent;

presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
```

Il risultato:

![La sovrapposizione delle serie](series_overlap.png)

## **Modifica il colore di riempimento della serie**

Utilizzare [IChartSeries.Format](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartseries/format/) per impostare il riempimento predefinito per un’intera serie. Se un punto ha già un riempimento esplicito, la sua impostazione [IChartDataPoint.Format](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartdatapoint/format/) sovrascrive il riempimento della serie per quel punto.

L’esempio seguente applica un riempimento solido blu alla prima serie:

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

Il risultato:

![Il colore della serie](series_color.png)

## **Modifica il nome della serie**

Il nome di una serie è memorizzato nella cartella di lavoro dei dati del grafico ed è normalmente visualizzato nella legenda. Nella cartella di lavoro predefinita creata per un grafico a colonne raggruppate, la cella B1 si trova alla riga 0, colonna 1 e contiene il nome della prima serie. Le costanti nominate nell’esempio seguente rendono esplicita quella struttura:

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

È anche possibile aggiornare la cella già referenziata da [IChartSeries.Name](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartseries/name/). Questo approccio evita di presumere una riga e una colonna particolari in un grafico esistente:

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

Il risultato:

![Il nome della serie](series_name.png)

## **Ottieni il colore di riempimento automatico della serie**

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/) restituisce il colore calcolato dall’indice della serie e dallo stile del grafico. Questo è il colore usato quando il riempimento della serie non è stato definito esplicitamente. La chiamata al metodo legge il colore calcolato; non assegna un nuovo riempimento.

L’esempio seguente stampa il colore automatico di ciascuna serie predefinita:

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

Output di esempio per lo stile di grafico predefinito:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

I colori esatti dipendono dallo stile e dal tema del grafico.

## **Imposta il colore di riempimento invertito per una serie del grafico**

Per serie a barre, colonne e bolle, [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartseries/invertifnegative/) può visualizzare i valori negativi con un riempimento diverso. Impostare il riempimento regolare della serie su solido, abilitare l’inversione e assegnare il colore per valori negativi tramite [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). I numeri negativi rimangono invariati nella cartella di lavoro; cambia solo il colore di visualizzazione.

L’esempio seguente sostituisce i dati di grafico predefiniti con una singola serie. La riga 0 del foglio di lavoro contiene il nome della serie, la colonna 0 contiene i nomi delle categorie e la colonna 1 i valori:

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

Il risultato:

![Il colore di riempimento solido invertito](inverted_solid_fill_color.png)

È possibile abilitare l’inversione per un singolo punto tramite [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). Nell’esempio seguente l’inversione è disabilitata per la serie e abilitata solo per il punto selezionato. Al punto è anche assegnato un valore negativo in modo che l’effetto sia visibile:

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

## **Cancella un valore di punto dati specifico**

Per rendere vuoto un punto senza rimuovere gli altri punti, impostare la sua cella di supporto nella cartella di lavoro su `null`. Per un grafico a colonne, il valore tracciato è disponibile tramite [IChartDataPoint.YValue](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartdatapoint/yvalue/). Il punto dati rimane nella stessa posizione di categoria, ma il grafico tratta il suo valore come vuoto secondo le impostazioni dei valori vuoti del grafico.

L’esempio seguente cancella solo il secondo punto nella prima serie:

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

I grafici a dispersione utilizzano celle X e Y separate, e i grafici a bolle utilizzano anche una cella per la dimensione. Cancellare solo la cella che rappresenta il valore da rimuovere. Non chiamare [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartdatapointcollection/clear/) quando si desidera mantenere gli altri punti, poiché quel metodo rimuove tutti i punti dati dalla collezione.

## **Controlla la visualizzazione delle celle vuote**

Le celle nascoste che contengono valori sono un caso diverso dalle celle vuote. Per includere o escludere dati da righe e colonne nascoste del foglio di lavoro, vedere [Include Data from Hidden Rows and Columns](/slides/it/net/chart-workbook/#include-data-from-hidden-rows-and-columns).

Una cella vuota della cartella di lavoro rappresenta dati mancanti; una cella contenente `0` rappresenta un valore numerico noto. Impostare [IChartDataCell.Value](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartdatacell/value/) su `null` per rendere una cella vuota. Uno zero numerico rimane zero indipendentemente dall’impostazione delle celle vuote.

Usare [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichart/displayblanksas/) per scegliere come il grafico visualizza le celle vuote. Questa impostazione si applica all’intero grafico. Cambia il modo in cui i vuoti vengono tracciati, senza riempire la cella vuota con zero o un valore interpolato.

L’esempio autonomo seguente crea un grafico a linee con una serie, cancella il valore per il Giorno 3 e salva lo stesso grafico con ciascuna modalità. Non è necessario alcun file di input. Il [IChartDataWorkbook](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartdataworkbook/) utilizza il foglio 0, la colonna 0 per le etichette delle categorie e la colonna 1 per i valori; la riga 0 contiene il nome della serie. I dati finali sono `10, 20, empty, 30, 40`.

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

Ogni file di output memorizza la modalità assegnata prima del salvataggio: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` e `empty_cells_Span.pptx`. Per salvare una sola versione, assegnare la modalità desiderata e salvare la presentazione una volta, invece di iterare sulle modalità.

Il confronto sotto mostra gli stessi dati nei tre file. Il Giorno 3 è vuoto nella cartella di lavoro in tutti i casi:

![Grafici a linee con dati identici: Gap interrompe la linea al Giorno 3, Zero abbassa la linea a zero, e Span collega il Giorno 2 al Giorno 4.](display_blanks_as.png)

L’effetto visibile dipende dal tipo di grafico. Un grafico a linee rende facili i confronti tra le tre modalità. I grafici a barre e colonne non hanno una linea da collegare attraverso una categoria mancante, quindi `Span` non può produrre il segmento di collegamento mostrato sopra; una colonna mancante e una colonna di altezza zero possono anche apparire simili. Analogamente, un grafico a dispersione con soli marcatori non ha una linea di collegamento. Non aspettate tre risultati distinti per ogni tipo di grafico; verificate l’output per il tipo che utilizzate.

## **Imposta la larghezza dello spazio tra le serie**

La larghezza dello spazio è lo spazio tra i gruppi adiacenti di barre o colonne, espresso come percentuale della larghezza della barra o della colonna. Come la sovrapposizione, appartiene al gruppo di serie padre piuttosto che a una singola serie. Impostare [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) una volta per il gruppo. Un valore più grande crea più spazio tra i gruppi; un valore più piccolo li rende più densi.

L’esempio seguente modifica la larghezza dello spazio e salva solo la presentazione finale:

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

Il risultato:

![La larghezza dello spazio](gap_width.png)

## **FAQ**

**Quali tipi di grafico supportano le serie di dati?**

Tutti i tipi di grafico rappresentati dall’enumerazione [ChartType](https://reference.aspose.com/slides/it/net/aspose.slides.charts/charttype/) utilizzano dati di grafico, ma le loro serie non hanno tutte la stessa struttura di valori o impostazioni. Ad esempio, i grafici a categorie usano categorie e valori, i grafici a dispersione usano valori X e Y, e i grafici a bolle aggiungono le dimensioni delle bolle. Utilizzare il metodo di creazione del punto dati che corrisponde al tipo di serie. Opzioni come sovrapposizione e larghezza dello spazio si applicano solo a gruppi di barre o colonne compatibili.

**Che cos’è un gruppo di serie di grafico?**

Un [IChartSeriesGroup](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartseriesgroup/) contiene serie compatibili che condividono impostazioni di tracciamento a livello di gruppo. Un grafico combinato può contenere più di un gruppo, quindi la modifica del gruppo raggiunta tramite una serie non cambia necessariamente tutte le serie nel grafico.

**Un grafico appena creato contiene dati predefiniti?**

Sì. Per impostazione predefinita, [IShapeCollection.AddChart](https://reference.aspose.com/slides/it/net/aspose.slides/ishapecollection/addchart/) crea serie, categorie e valori di esempio. È possibile modificare queste celle o cancellare sia le collezioni di serie che di categorie prima di aggiungere un set di dati completamente personalizzato. Un overload può anche creare un grafico senza dati predefiniti.

**Come sono collegati gli oggetti del grafico alle celle della cartella di lavoro?**

I nomi delle serie, le etichette delle categorie e i valori dei punti dati fanno riferimento a celle in un [IChartDataWorkbook](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartdataworkbook/). Modificare una cella referenziata aggiorna l’elemento del grafico corrispondente. Quando si costruiscono dati personalizzati, mantenere le righe delle categorie e le righe dei valori delle serie allineate in modo che ogni punto sia tracciato sotto la categoria prevista.

**Come posso cancellare un punto invece dell’intera serie?**

Impostare la cella di valore pertinente su `null` per mantenere la posizione di categoria del punto come punto vuoto. Utilizzare [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartdatapointcollection/clear/) solo quando si intende rimuovere tutti i punti da quella serie. Se si rimuovono anche le categorie, aggiornare tutte le serie affinché i loro valori rimangano allineati con la collezione delle categorie.

**Come vengono visualizzati i punti vuoti?**

Il risultato dipende dal tipo di grafico e da [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichart/displayblanksas/). I grafici supportati possono visualizzare i vuoti come spazi, come valori zero o collegando i punti vicini. Scegliere l’impostazione che corrisponde al significato dei dati mancanti nella propria presentazione. Vedere [Controlla la visualizzazione delle celle vuote](#control-the-display-of-empty-cells) per un esempio completo e un confronto visivo.

**Come vengono formattati i valori negativi?**

Per le serie a barre, colonne e bolle supportate, abilitare [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartseries/invertifnegative/) e impostare [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). È possibile sovrascrivere il comportamento per un singolo punto con [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). Queste proprietà influiscono sulla formattazione, non sui valori numerici memorizzati.

**Quale formattazione prevale quando sia una serie sia un punto sono formattati?**

La formattazione esplicita del punto dati ha la precedenza per quel punto. Gli altri punti continuano a utilizzare la formattazione esplicita della serie o, quando la formattazione della serie non è definita, lo stile e il tema automatici del grafico. Le proprietà di gruppo come sovrapposizione e larghezza dello spazio controllano il layout e non sono sovrascritture di formattazione a livello di punto.

**Esiste un limite al numero di serie che un grafico può contenere?**

Aspose.Slides non impone un limite fisso separato al numero di serie. In pratica, i vincoli del file di presentazione, la memoria disponibile, il tempo di rendering e la leggibilità del grafico determinano un limite pratico.

**Cosa devo modificare quando le colonne sono troppo vicine o troppo distanti?**

Impostare [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) sul gruppo di serie padre appropriato. Aumentare il valore per ampliare lo spazio tra i gruppi, o diminuirlo per avvicinare i gruppi.