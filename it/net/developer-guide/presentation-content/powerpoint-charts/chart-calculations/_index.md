---
title: Ottimizzare i calcoli dei grafici per le presentazioni in .NET
linktitle: Calcoli dei grafici
type: docs
weight: 50
url: /it/net/chart-calculations/
keywords:
- calcoli dei grafici
- elementi del grafico
- posizione dell'elemento
- posizione reale
- elemento figlio
- elemento genitore
- valori del grafico
- valore reale
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Comprendere i calcoli dei grafici, gli aggiornamenti dei dati e il controllo della precisione in Aspose.Slides per .NET per PPT e PPTX, con esempi pratici di codice C#."
---
## **Panoramica**

Aspose.Slides fornisce API per lavorare con i calcoli dei grafici e i dati di layout nelle presentazioni. Questo articolo mostra come recuperare i valori effettivi degli elementi del grafico, inclusa la posizione reale e le dimensioni degli elementi che implementano `IActualLayout` e i valori effettivi degli assi del grafico. Spiega inoltre che questi valori vengono popolati dopo la convalida del layout del grafico.

Inoltre, l'articolo dimostra come ottenere la posizione effettiva degli elementi padre del grafico e come nascondere componenti del grafico come il titolo, gli assi, la legenda e le linee della griglia. Insieme, questi esempi ti aiutano a ispezionare le informazioni di layout del grafico e a controllare la visibilità degli elementi del grafico nelle presentazioni PowerPoint in modo programmatico.

## **Calcolare i valori effettivi degli elementi del grafico**
Aspose.Slides per .NET fornisce un'API semplice per ottenere queste proprietà. Questo ti aiuterà a calcolare i valori effettivi degli elementi del grafico. I valori effettivi includono la posizione degli elementi che implementano l'interfaccia IActualLayout (IActualLayout.ActualX, IActualLayout.ActualY, IActualLayout.ActualWidth, IActualLayout.ActualHeight) e i valori effettivi degli assi (IAxis.ActualMaxValue, IAxis.ActualMinValue, IAxis.ActualMajorUnit, IAxis.ActualMinorUnit, IAxis.ActualMajorUnitScale, IAxis.ActualMinorUnitScale).

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
    Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.ValidateChartLayout();
    double x = chart.PlotArea.ActualX;
    double y = chart.PlotArea.ActualY;
    double w = chart.PlotArea.ActualWidth;
    double h = chart.PlotArea.ActualHeight;
	
	// Salvataggio della presentazione
	pres.Save("Result.pptx", SaveFormat.Pptx);
}
```



## **Calcolare la posizione effettiva degli elementi padre del grafico**
Aspose.Slides per .NET fornisce un'API semplice per ottenere queste proprietà. Le proprietà di IActualLayout forniscono informazioni sulla posizione effettiva dell'elemento padre del grafico. È necessario chiamare in precedenza il metodo IChart.ValidateChartLayout() per popolare le proprietà con i valori effettivi.

```c#
// Creazione di una presentazione vuota
using (Presentation pres = new Presentation())
{
   Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
   chart.ValidateChartLayout();

   double x = chart.PlotArea.ActualX;
   double y = chart.PlotArea.ActualY;
   double w = chart.PlotArea.ActualWidth;
   double h = chart.PlotArea.ActualHeight;
}
```



## **Nascondere gli elementi del grafico**
Questo argomento ti aiuta a comprendere come nascondere informazioni dal grafico. Usando Aspose.Slides per .NET puoi nascondere **Titolo, Asse verticale, Asse orizzontale** e **Linee della griglia** dal grafico. Il seguente esempio di codice mostra come utilizzare queste proprietà.

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 140, 118, 320, 370);

    // Nascondere il titolo del grafico
    chart.HasTitle = false;

    /// Nascondere l'asse dei valori
    chart.Axes.VerticalAxis.IsVisible = false;

    // Visibilità dell'asse delle categorie
    chart.Axes.HorizontalAxis.IsVisible = false;

    // Nascondere la leggenda
    chart.HasLegend = false;

    // Nascondere le linee della griglia principale
    chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        chart.ChartData.Series.RemoveAt(i);
    }

    IChartSeries series = chart.ChartData.Series[0];

    series.Marker.Symbol = MarkerStyleType.Circle;
    series.Labels.DefaultDataLabelFormat.ShowValue = true;
    series.Labels.DefaultDataLabelFormat.Position = LegendDataLabelPosition.Top;
    series.Marker.Size = 15;

    // Impostare il colore della linea della serie
    series.Format.Line.FillFormat.FillType = FillType.Solid;
    series.Format.Line.FillFormat.SolidFillColor.Color = Color.Purple;
    series.Format.Line.DashStyle = LineDashStyle.Solid;

    pres.Save("HideInformationFromChart.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**I libri di lavoro Excel esterni funzionano come fonte di dati e come influisce sulla ricalcolazione?**

Sì. Un grafico può fare riferimento a un libro di lavoro esterno: quando si collega o si aggiorna la fonte esterna, le formule e i valori vengono prelevati da quel libro e il grafico riflette gli aggiornamenti durante le operazioni di apertura/modifica. L'API consente di [specificare il percorso del libro di lavoro esterno](https://reference.aspose.com/slides/it/net/aspose.slides.charts/chartdata/setexternalworkbook/) e gestire i dati collegati.

**Posso calcolare e visualizzare le linee di tendenza senza implementare io stesso la regressione?**

Sì. Le [linee di tendenza](/slides/it/net/trend-line/) (lineari, esponenziali e altre) vengono aggiunte e aggiornate da Aspose.Slides; i loro parametri vengono ricalcolati automaticamente dai dati della serie, quindi non è necessario implementare i propri calcoli.

**Se una presentazione contiene più grafici con collegamenti esterni, posso controllare quale libro di lavoro utilizza ciascun grafico per i valori calcolati?**

Sì. Ogni grafico può puntare al proprio [libro di lavoro esterno](https://reference.aspose.com/slides/it/net/aspose.slides.charts/chartdata/setexternalworkbook/), oppure è possibile creare/sostituire un libro di lavoro esterno per ciascun grafico in modo indipendente dagli altri.