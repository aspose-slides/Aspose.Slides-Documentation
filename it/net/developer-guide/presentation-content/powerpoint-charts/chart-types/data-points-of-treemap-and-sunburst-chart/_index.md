---
title: Personalizza i punti dati nei grafici Treemap e Sunburst in .NET
linktitle: Punti dati nei grafici Treemap e Sunburst
type: docs
url: /it/net/data-points-of-treemap-and-sunburst-chart/
keywords:
- grafico treemap
- grafico sunburst
- punto dati
- colore etichetta
- colore ramo
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Scopri come gestire i punti dati nei grafici treemap e sunburst con Aspose.Slides per .NET, compatibile con i formati PowerPoint."
---
## **Introduzione**

Tra gli altri tipi di grafici PowerPoint, esistono due tipi "gerarchici" - **Treemap** e **Sunburst** (conosciuti anche come Sunburst Graph, Sunburst Diagram, Radial Chart, Radial Graph o Multi Level Pie Chart). Questi grafici visualizzano dati gerarchici organizzati come un albero - dalle foglie fino alla cima del ramo. Le foglie sono definite dai punti dati della serie, e ogni livello di raggruppamento annidato successivo è definito dalla categoria corrispondente. Aspose.Slides per .NET consente di formattare i punti dati dei grafici Sunburst e Treemap in C#.

Ecco un grafico Sunburst, in cui i dati nella colonna Series1 definiscono i nodi foglia, mentre le altre colonne definiscono i punti dati gerarchici:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Iniziamo aggiungendo un nuovo grafico Sunburst alla presentazione:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Sunburst, 100, 100, 450, 400);
    // ...
}
```

{{% alert color="primary" title="Vedi anche" %}} 
- [**Creare grafico Sunburst**](/slides/it/net/adding-charts/#addingcharts-creatingsunburstchart)
{{% /alert %}}

Se è necessario formattare i punti dati del grafico, dovremmo utilizzare i seguenti:

Le classi [**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/it/net/aspose.slides.charts/IChartDataPointLevelsManager), [IChartDataPointLevel](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartdatapointlevel) e la proprietà [**IChartDataPoint.DataPointLevels**](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartdatapoint/properties/datapointlevels) forniscono l'accesso per formattare i punti dati dei grafici Treemap e Sunburst. 
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/it/net/aspose.slides.charts/IChartDataPointLevelsManager) è usato per accedere alle categorie a più livelli - rappresenta il contenitore degli oggetti [**IChartDataPointLevel**](https://reference.aspose.com/slides/it/net/aspose.slides.charts/IChartDataPointLevel). 
In pratica è un wrapper per [**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/it/net/aspose.slides.charts/IChartCategoryLevelsManager) con le proprietà aggiunte specifiche per i punti dati. 
La classe [**IChartDataPointLevel**](https://reference.aspose.com/slides/it/net/aspose.slides.charts/IChartDataPointLevel) ha due proprietà: [**Format**](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartdatapointlevel/properties/format) e [**DataLabel**](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartdatapointlevel/properties/label) che forniscono l'accesso alle impostazioni corrispondenti.

## **Mostra valore di un punto dati**
Mostra il valore del punto dati "Leaf 4":

```c#
IChartDataPointCollection dataPoints = chart.ChartData.Series[0].DataPoints;
dataPoints[3].DataPointLevels[0].Label.DataLabelFormat.ShowValue = true;
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Imposta etichetta e colore del punto dati**
Imposta l'etichetta del punto dati "Branch 1" per mostrare il nome della serie ("Series1") invece del nome della categoria. Quindi imposta il colore del testo su giallo:

```c#
IDataLabel branch1Label = dataPoints[0].DataPointLevels[2].Label;
branch1Label.DataLabelFormat.ShowCategoryName = false;
branch1Label.DataLabelFormat.ShowSeriesName = true;

branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Yellow;
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Imposta colore del ramo del punto dati**
Modifica il colore del ramo "Stem 4":

```csharp
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Sunburst, 100, 100, 450, 400);
    
    IChartDataPointCollection dataPoints = chart.ChartData.Series[0].DataPoints;

    IChartDataPointLevel stem4branch = dataPoints[9].DataPointLevels[1];
    
    stem4branch.Format.Fill.FillType = FillType.Solid;
    stem4branch.Format.Fill.SolidFillColor.Color = Color.Red;
      
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **FAQ**

**Posso modificare l'ordine (ordinamento) dei segmenti in Sunburst/Treemap?**

No. PowerPoint ordina i segmenti automaticamente (tipicamente per valori decrescenti, in senso orario). Aspose.Slides rispecchia questo comportamento: non è possibile modificare l'ordine direttamente; è necessario farlo preelaborando i dati.

**In che modo il tema della presentazione influisce sui colori dei segmenti e delle etichette?**

I colori del grafico ereditano il [tema/palette](/slides/it/net/presentation-theme/) della presentazione, a meno che non vengano impostati esplicitamente riempimenti/fonti. Per risultati coerenti, fissare riempimenti solidi e la formattazione del testo nei livelli appropriati.

**L'esportazione in PDF/PNG conserverà i colori personalizzati dei rami e le impostazioni delle etichette?**

Sì. Durante l'esportazione della presentazione, le impostazioni del grafico (riempimenti, etichette) vengono conservate nei formati di output perché Aspose.Slides rende il grafico con la formattazione applicata.

**Posso calcolare le coordinate effettive di un'etichetta/elemento per posizionare sovrapposizioni personalizzate sopra al grafico?**

Sì. Dopo che il layout del grafico è stato validato, `ActualX`/`ActualY` sono disponibili per gli elementi (ad esempio, un [DataLabel](https://reference.aspose.com/slides/it/net/aspose.slides.charts/datalabel/)), il che aiuta a posizionare con precisione le sovrapposizioni.