---
title: Gestire le serie di dati dei grafici nelle presentazioni in .NET
linktitle: Serie di dati
type: docs
url: /it/net/chart-series/
keywords:
- serie di grafico
- sovrapposizione delle serie
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
description: "Scopri come gestire le serie di grafici in C# per PowerPoint (PPT/PPTX) con esempi di codice pratici e le migliori pratiche per migliorare le tue presentazioni dati."
---
## **Panoramica**

Questo articolo descrive il ruolo di [ChartSeries](https://reference.aspose.com/slides/it/net/aspose.slides.charts/chartseries/) in Aspose.Slides per .NET, concentrandosi su come i dati sono strutturati e visualizzati nelle presentazioni. Questi oggetti forniscono gli elementi fondamentali che definiscono insiemi individuali di punti dati, categorie e parametri di aspetto in un grafico. Lavorando con [ChartSeries](https://reference.aspose.com/slides/it/net/aspose.slides.charts/chartseries/), gli sviluppatori possono integrare senza sforzo le fonti dati sottostanti e mantenere il pieno controllo su come le informazioni sono visualizzate, ottenendo presentazioni dinamiche basate sui dati che comunicano chiaramente approfondimenti e analisi.

Una serie è una riga o colonna di numeri tracciata in un grafico.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Imposta la Sovrapposizione della Serie del Grafico**

La proprietà [IChartSeriesOverlap](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartseries/properties/overlap) controlla come barre e colonne si sovrappongono in un grafico 2D specificando un intervallo da -100 a 100. Poiché questa proprietà è associata al gruppo di serie piuttosto che a una singola serie del grafico, è di sola lettura a livello di serie. Per configurare i valori di sovrapposizione, utilizzare la proprietà `ParentSeriesGroup.Overlap` in lettura/scrittura, che applica la sovrapposizione specificata a tutte le serie in quel gruppo.

Di seguito è riportato un esempio C# che mostra come creare una presentazione, aggiungere un grafico a colonne raggruppate, accedere alla prima serie del grafico, configurare l’impostazione di sovrapposizione e quindi salvare il risultato come file PPTX:

```cs
sbyte overlap = 30;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Aggiungi un grafico a colonne raggruppate con dati predefiniti.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.ChartData.Series[0];
    if (series.Overlap == 0)
    {
        // Imposta la sovrapposizione della serie.
        series.ParentSeriesGroup.Overlap = overlap;
    }

    // Salva il file della presentazione su disco.
    presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
}
```

Il risultato:

![The series overlap](series_overlap.png)

## **Modifica il Colore di Riempimento della Serie**

Aspose.Slides rende semplice personalizzare i colori di riempimento delle serie di un grafico, consentendo di evidenziare punti dati specifici e creare grafici visivamente accattivanti. Questo è ottenuto tramite l’oggetto [IFormat](https://reference.aspose.com/slides/it/net/aspose.slides.charts/iformat/), che supporta vari tipi di riempimento, configurazioni di colore e altre opzioni di stile avanzate. Dopo aver aggiunto un grafico a una diapositiva e aver accesso alla serie desiderata, basta ottenere la serie e applicare il colore di riempimento appropriato. Oltre ai riempimenti solidi, è possibile utilizzare riempimenti a gradiente o a motivo per una maggiore flessibilità di design. Una volta impostati i colori secondo le proprie esigenze, salvare la presentazione per finalizzare l’aspetto aggiornato.

Il seguente esempio di codice C# mostra come cambiare il colore della prima serie:

```cs
Color seriesColor = Color.Blue;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Aggiungi un grafico a colonne raggruppate con dati predefiniti.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // Imposta il colore della prima serie.
    IChartSeries series = chart.ChartData.Series[0];
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = seriesColor;

    // Salva il file della presentazione su disco.
    presentation.Save("series_color.pptx", SaveFormat.Pptx);
}
```

Il risultato:

![The color of the series](series_color.png)

## **Modifica il Nome della Serie** 

Aspose.Slides offre un modo semplice per modificare i nomi delle serie di un grafico, facilitando l’etichettatura dei dati in maniera chiara e significativa. Accedendo alla cella del foglio di lavoro pertinente nei dati del grafico, gli sviluppatori possono personalizzare la presentazione dei dati. Questa modifica è particolarmente utile quando è necessario aggiornare o chiarire i nomi delle serie in base al contesto dei dati. Dopo aver rinominato la serie, la presentazione può essere salvata per rendere permanenti le modifiche. 

Di seguito è riportato uno snippet di codice C# che dimostra questo processo in azione.

```cs
string seriesName = "New name";

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Aggiungi un grafico a colonne raggruppate con dati predefiniti.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // Imposta il nome della prima serie.
    IChartDataCell seriesCell = chart.ChartData.ChartDataWorkbook.GetCell(0, 0, 1);
    seriesCell.Value = seriesName;

    // Salva il file della presentazione su disco.
    presentation.Save("series_name.pptx", SaveFormat.Pptx);
}
```

Il seguente codice C# mostra un modo alternativo per cambiare il nome della serie:

```cs
string seriesName = "New name";

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Aggiungi un grafico a colonne raggruppate con dati predefiniti.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // Imposta il nome della prima serie.
    IChartSeries series = chart.ChartData.Series[0];
    series.Name.AsCells[0].Value = seriesName;

    // Salva il file della presentazione su disco.
    presentation.Save("series_name.pptx", SaveFormat.Pptx);
}
```

Il risultato:

![The series name](series_name.png)

## **Ottieni il Colore di Riempimento Automatico della Serie**

Aspose.Slides per .NET consente di ottenere il colore di riempimento automatico per le serie di un grafico all’interno di un’area di tracciamento. Dopo aver creato un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/), è possibile ottenere un riferimento alla diapositiva desiderata per indice, quindi aggiungere un grafico usando il tipo preferito (ad esempio `ChartType.ClusteredColumn`). Accedendo alle serie del grafico, si può ottenere il colore di riempimento automatico.

Il codice C# seguente dimostra questo processo in dettaglio.

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Aggiungi un grafico a colonne raggruppate con dati predefiniti.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        // Ottieni il colore di riempimento della serie.
        Color color = chart.ChartData.Series[i].GetAutomaticSeriesColor();
        Console.WriteLine($"Series {i} color: {color.Name}");
    }
}
```

Output:
```text
Series 0 color: ff4f81bd
Series 1 color: ffc0504d
Series 2 color: ff9bbb59
```

## **Imposta il Colore di Riempimento Invertito per una Serie di Grafico**

Quando la serie di dati contiene sia valori positivi sia negativi, colorare tutte le colonne o barre allo stesso modo può rendere il grafico difficile da leggere. Aspose.Slides per .NET permette di assegnare un colore di riempimento invertito — un riempimento separato applicato automaticamente ai punti dati che risultano al di sotto dello zero — così i valori negativi emergono a colpo d’occhio. In questa sezione imparerai come abilitare questa opzione, scegliere un colore appropriato e salvare la presentazione aggiornata.

Il seguente esempio di codice dimostra l’operazione:

```cs
Color inverColor = Color.Red;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);
    IChartDataWorkbook workBook = chart.ChartData.ChartDataWorkbook;

    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // Aggiungi nuove categorie.
    chart.ChartData.Categories.Add(workBook.GetCell(0, 1, 0, "Category 1"));
    chart.ChartData.Categories.Add(workBook.GetCell(0, 2, 0, "Category 2"));
    chart.ChartData.Categories.Add(workBook.GetCell(0, 3, 0, "Category 3"));

    // Aggiungi una nuova serie.
    IChartSeries series = chart.ChartData.Series.Add(workBook.GetCell(0, 0, 1, "Series 1"), chart.Type);

    // Popola i dati della serie.
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 1, 1, -20));
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 2, 1, 50));
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 3, 1, -30));

    // Imposta le impostazioni di colore per la serie.
    var seriesColor = series.GetAutomaticSeriesColor();
    series.InvertIfNegative = true;
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = seriesColor;
    series.InvertedSolidFillColor.Color = inverColor;

    presentation.Save("inverted_solid_fill_color.pptx", SaveFormat.Pptx);
}
```

Il risultato:

![The inverted solid fill color](inverted_solid_fill_color.png)

È possibile invertire il colore di riempimento per un singolo punto dati anziché per l’intera serie. Basta accedere al `IChartDataPoint` desiderato e impostare la proprietà `InvertIfNegative` su true.

Il seguente esempio di codice mostra come fare:

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200, true);

    chart.ChartData.Series.Clear();
    IChartSeries series = chart.ChartData.Series.Add(chart.ChartData.ChartDataWorkbook.GetCell(0, "B1"), chart.Type);

    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B2", -5));
    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B3", 3));
    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B4", -3));
    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B5", 1));

    // Inverti il colore se il punto dati all indice 2 è negativo.
    series.InvertIfNegative = false;
    series.DataPoints[2].InvertIfNegative = true;
                
    presentation.Save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx);
}
```

## **Cancella Valori di Punti Dati Specifici**

A volte un grafico contiene valori di prova, outlier o voci obsolete che è necessario rimuovere senza ricostruire l’intera serie. Aspose.Slides per .NET consente di mirare a qualsiasi punto dati per indice, cancellarne il contenuto e aggiornare istantaneamente il tracciato in modo che i punti rimanenti si spostino e gli assi si ridimensionino automaticamente.

Il seguente esempio di codice dimostra l’operazione:

```cs
using (Presentation presentation = new Presentation("test_chart.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IChart chart = (IChart)slide.Shapes[0];
    IChartSeries series = chart.ChartData.Series[0];

    foreach (IChartDataPoint dataPoint in series.DataPoints)
    {
        dataPoint.XValue.AsCell.Value = null;
        dataPoint.YValue.AsCell.Value = null;
    }

    series.DataPoints.Clear();

    presentation.Save("clear_data_points.pptx", SaveFormat.Pptx);
}
```

## **Imposta la Larghezza dello Spazio della Serie**

La larghezza dello spazio controlla la quantità di spazio vuoto tra colonne o barre adiacenti — spazi più ampi enfatizzano le singole categorie, mentre spazi più stretti creano un aspetto più denso e compatto. Attraverso Aspose.Slides per .NET è possibile regolare finemente questo parametro per un’intera serie, ottenendo l’equilibrio visivo necessario nella presentazione senza alterare i dati sottostanti.

Il seguente esempio di codice mostra come impostare la larghezza dello spazio per una serie:

```cs
ushort gapWidth = 30;

// Crea una presentazione vuota.
using (Presentation presentation = new Presentation())
{
    // Accedi alla prima diapositiva.
    ISlide slide = presentation.Slides[0];

    // Aggiungi un grafico con dati predefiniti.
    IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn, 20, 20, 500, 200);

    // Salva la presentazione su disco.
    presentation.Save("default_gap_width.pptx", SaveFormat.Pptx);

    // Imposta il valore GapWidth.
    IChartSeries series = chart.ChartData.Series[0];
    series.ParentSeriesGroup.GapWidth = gapWidth;

    // Salva la presentazione su disco.
    presentation.Save("gap_width_30.pptx", SaveFormat.Pptx);
}
```

Il risultato:

![The gap width](gap_width.png)

## **FAQ**

**Esiste un limite al numero di serie che un singolo grafico può contenere?**

Aspose.Slides non impone un limite fisso al numero di serie che si aggiungono. Il limite pratico è determinato dalla leggibilità del grafico e dalla memoria disponibile per l’applicazione.

**Cosa succede se le colonne all'interno di un raggruppamento sono troppo vicine o troppo distanti?**

Regolare l’impostazione `GapWidth` per quella serie (o per il suo gruppo di serie genitore). Incrementare il valore allarga lo spazio tra le colonne, mentre diminuire lo valore le avvicina.