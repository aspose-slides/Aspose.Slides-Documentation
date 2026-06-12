---
title: Personalizza le aree di tracciato dei grafici di presentazione in .NET
linktitle: Area del tracciato
type: docs
url: /it/net/chart-plot-area/
keywords:
- grafico
- area di tracciato
- larghezza area di tracciato
- altezza area di tracciato
- dimensione area di tracciato
- modalità di layout
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Scopri come personalizzare le aree di tracciato dei grafici nelle presentazioni PowerPoint con Aspose.Slides per .NET. Migliora facilmente l'aspetto delle tue diapositive."
---
## **Panoramica**

Questo articolo mostra come lavorare con l'area del tracciato di un grafico in Aspose.Slides. Spiega come ottenere la posizione e le dimensioni effettive dell'area del tracciato convalidando il layout del grafico e poi leggendo i valori X, Y, larghezza e altezza.

Mostra inoltre come configurare la modalità di layout dell'area del tracciato quando il layout è impostato manualmente, usando `LayoutTargetType` per definire se l'area del tracciato è calcolata dalla sua regione interna o dalla regione esterna insieme a assi ed etichette degli assi.

## **Ottenere larghezza e altezza di un'area del tracciato di un grafico**
Aspose.Slides per .NET fornisce un'API semplice per .

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation).
2. Accedi alla prima diapositiva.
3. Aggiungi un grafico con i dati predefiniti.
4. Chiama il metodo IChart.ValidateChartLayout() prima per ottenere i valori reali.
5. Ottiene la posizione X effettiva (sinistra) dell'elemento del grafico rispetto all'angolo superiore sinistro del grafico.
6. Ottiene la parte superiore effettiva dell'elemento del grafico rispetto all'angolo superiore sinistro del grafico.
7. Ottiene la larghezza effettiva dell'elemento del grafico.
8. Ottiene l'altezza effettiva dell'elemento del grafico.

```c#
using (Presentation pres = new Presentation("test.Pptx"))
{
    Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.ValidateChartLayout();

    double x = chart.PlotArea.ActualX;
    double y = chart.PlotArea.ActualY;
    double w = chart.PlotArea.ActualWidth;
    double h = chart.PlotArea.ActualHeight;
	
	// Salva la presentazione con il grafico
	pres.Save("Chart_out.pptx", SaveFormat.Pptx);
}
```

## **Impostare la modalità di layout di un'area del tracciato di un grafico**
Aspose.Slides per .NET fornisce un'API semplice per impostare la modalità di layout dell'area del tracciato del grafico. La proprietà **LayoutTargetType** è stata aggiunta alle classi **ChartPlotArea** e **IChartPlotArea**. Se il layout dell'area del tracciato è definito manualmente, questa proprietà specifica se il layout dell'area del tracciato deve essere effettuato internamente (escludendo assi ed etichette degli assi) o esternamente (includendo assi ed etichette degli assi). Sono disponibili due valori possibili, definiti nell'enumerazione **LayoutTargetType**.

- **LayoutTargetType.Inner** - specifica che la dimensione dell'area del tracciato determina la dimensione dell'area del tracciato, escludendo i segni di graduazione e le etichette degli assi.
- **LayoutTargetType.Outer** - specifica che la dimensione dell'area del tracciato determina la dimensione dell'area del tracciato, i segni di graduazione e le etichette degli assi.

Il codice di esempio è fornito di seguito.

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.PlotArea.AsILayoutable.X = 0.2f;
    chart.PlotArea.AsILayoutable.Y = 0.2f;
    chart.PlotArea.AsILayoutable.Width = 0.7f;
    chart.PlotArea.AsILayoutable.Height = 0.7f;
    chart.PlotArea.LayoutTargetType = LayoutTargetType.Inner;

    presentation.Save("SetLayoutMode_outer.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**In quali unità vengono restituiti ActualX, ActualY, ActualWidth e ActualHeight?**

In punti; 1 pollice = 72 punti. Queste sono le unità di coordinate di Aspose.Slides.

**Qual è la differenza tra l'area del tracciato e l'area del grafico in termini di contenuto?**

L'area del tracciato è la regione di disegno dei dati (serie, linee di griglia, linee di tendenza, ecc.); l'area del grafico comprende gli elementi circostanti (titolo, legenda, ecc.). Nei grafici 3D, l'area del tracciato include anche le pareti/pavimento e gli assi.

**Come vengono interpretati X, Y, Larghezza e Altezza dell'area del tracciato quando il layout è manuale?**

Sono frazioni (0‑1) della dimensione complessiva del grafico; in questa modalità, il posizionamento automatico è disabilitato e vengono utilizzate le frazioni impostate.

**Perché la posizione dell'area del tracciato è cambiata dopo aver aggiunto/spostato la legenda?**

La legenda si trova nell'area del grafico al di fuori dell'area del tracciato, ma influisce sul layout e sullo spazio disponibile, perciò l'area del tracciato può spostarsi quando è attivo il posizionamento automatico. (Questo è il comportamento standard per i grafici di PowerPoint.)