---
title: Personalizza gli assi dei grafici nelle presentazioni in .NET
linktitle: Asse del grafico
type: docs
url: /it/net/chart-axis/
keywords:
- asse del grafico
- asse verticale
- asse orizzontale
- personalizzare asse
- manipolare asse
- gestire asse
- proprietà dell'asse
- valore massimo
- valore minimo
- linea dell'asse
- formato data
- titolo dell'asse
- posizione dell'asse
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Scopri come utilizzare Aspose.Slides per .NET per personalizzare gli assi dei grafici nelle presentazioni PowerPoint per report e visualizzazioni."
---
## **Panoramica**

Questo articolo spiega come personalizzare gli assi di un grafico in Aspose.Slides. Mostra come ottenere i valori effettivi degli assi, scambiare i dati tra gli assi, nascondere l'asse verticale o orizzontale per i grafici a linee, modificare il tipo di asse di categoria, impostare il formato data per i valori dell'asse di categoria, ruotare il titolo di un asse, impostare la posizione dell'asse e visualizzare un'etichetta di unità sull'asse dei valori.

## **Ottieni i valori massimi sull'asse verticale nei grafici**
Aspose.Slides per .NET consente di ottenere i valori minimo e massimo su un asse verticale. Segui questi passaggi:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation).
1. Accedi alla prima diapositiva.
1. Aggiungi un grafico con dati predefiniti.
1. Ottieni il valore massimo effettivo sull'asse.
1. Ottieni il valore minimo effettivo sull'asse.
1. Ottieni l'unità principale effettiva dell'asse.
1. Ottieni l'unità secondaria effettiva dell'asse.
1. Ottieni la scala dell'unità principale effettiva dell'asse.
1. Ottieni la scala dell'unità secondaria effettiva dell'asse.

Questo codice di esempio—un'implementazione dei passaggi sopra—mostra come ottenere i valori richiesti in C#:

```c#
using (Presentation pres = new Presentation())
{
	Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.Area, 100, 100, 500, 350);
	chart.ValidateChartLayout();

	double maxValue = chart.Axes.VerticalAxis.ActualMaxValue;
	double minValue = chart.Axes.VerticalAxis.ActualMinValue;

	double majorUnit = chart.Axes.HorizontalAxis.ActualMajorUnit;
	double minorUnit = chart.Axes.HorizontalAxis.ActualMinorUnit;
	
	// Salva la presentazione
	presentation.Save("ErrorBars_out.pptx", SaveFormat.Pptx);
}
```

## **Scambia i dati tra gli assi**
Aspose.Slides consente di scambiare rapidamente i dati tra gli assi: i dati rappresentati sull'asse verticale (asse y) vengono spostati sull'asse orizzontale (asse x) e viceversa. 

Questo codice C# mostra come eseguire lo scambio di dati tra gli assi in un grafico:

```c#
// Crea presentazione vuota
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

	//Scambia righe e colonne
		   
	// Salva presentazione
	 pres.Save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
 }
```

## **Disabilita l'asse verticale per i grafici a linee**

Questo codice C# mostra come nascondere l'asse verticale in un grafico a linee:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
    chart.Axes.VerticalAxis.IsVisible = false; 
    
    pres.Save("chart.pptx", SaveFormat.Pptx);
}
```

## **Disabilita l'asse orizzontale per i grafici a linee**

Questo codice mostra come nascondere l'asse orizzontale in un grafico a linee:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
    chart.Axes.HorizontalAxis.IsVisible = false; 
    
    pres.Save("chart.pptx", SaveFormat.Pptx);
}
```

## **Modifica un asse di categoria**

Utilizzando la proprietà **CategoryAxisType**, è possibile specificare il tipo di asse di categoria preferito (**date** o **text**). Questo codice in C# dimostra l'operazione: 

```c#
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    IChart chart = presentation.Slides[0].Shapes[0] as IChart;
    chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
    chart.Axes.HorizontalAxis.IsAutomaticMajorUnit = false;
    chart.Axes.HorizontalAxis.MajorUnit = 1;
    chart.Axes.HorizontalAxis.MajorUnitScale = TimeUnitType.Months;
    presentation.Save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
}
```

## **Imposta il formato data per i valori dell'asse di categoria**
Aspose.Slides per .NET consente di impostare il formato data per un valore dell'asse di categoria. L'operazione è dimostrata in questo codice C#:

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Area, 50, 50, 450, 300);

	IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

	wb.Clear(0);

	chart.ChartData.Categories.Clear();
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Add(wb.GetCell(0, "A2", new DateTime(2015, 1, 1).ToOADate()));
	chart.ChartData.Categories.Add(wb.GetCell(0, "A3", new DateTime(2016, 1, 1).ToOADate()));
	chart.ChartData.Categories.Add(wb.GetCell(0, "A4", new DateTime(2017, 1, 1).ToOADate()));
	chart.ChartData.Categories.Add(wb.GetCell(0, "A5", new DateTime(2018, 1, 1).ToOADate()));

	IChartSeries series = chart.ChartData.Series.Add(ChartType.Line);
	series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B2", 1));
	series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B3", 2));
	series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B4", 3));
	series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B5", 4));
	chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
	chart.Axes.HorizontalAxis.IsNumberFormatLinkedToSource = false;
	chart.Axes.HorizontalAxis.NumberFormat = "yyyy";
	pres.Save("test.pptx", SaveFormat.Pptx);
}
```

## **Imposta un angolo di rotazione per il titolo di un asse del grafico**
Aspose.Slides per .NET consente di impostare l'angolo di rotazione per il titolo di un asse del grafico. Questo codice C# dimostra l'operazione:

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.VerticalAxis.HasTitle = true;
	         chart.Axes.VerticalAxis.Title.TextFormat.TextBlockFormat.RotationAngle = 90;

	pres.Save("test.pptx", SaveFormat.Pptx);
}
```

## **Imposta la posizione dell'asse su un asse di categoria o di valore**
Aspose.Slides per .NET consente di impostare la posizione dell'asse in un asse di categoria o di valore. Questo codice C# mostra come eseguire l'operazione:

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.HorizontalAxis.AxisBetweenCategories = true;

	pres.Save("AsposeScatterChart.pptx", SaveFormat.Pptx);
}
```

## **Abilita l'etichetta di unità di visualizzazione sull'asse valori del grafico**
Aspose.Slides per .NET consente di configurare un grafico per mostrare un'etichetta di unità sul suo asse dei valori. Questo codice C# dimostra l'operazione:

```c#
using (Presentation pres = new Presentation(dataDir+"Test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Millions;
	pres.Save("Result.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Come imposto il valore in cui un asse incrocia l'altro (incrocio degli assi)?**

Gli assi offrono un'impostazione di [incrocio](https://reference.aspose.com/slides/it/net/aspose.slides.charts/axis/crosstype/): è possibile scegliere di incrociare a zero, al valore massimo di categoria/valore o a un valore numerico specifico. Questo è utile per spostare l'asse X verso l'alto o verso il basso o per evidenziare una linea di base.

**Come posso posizionare le etichette dei tick rispetto all'asse (affianco, esterno, interno)?**

Imposta la [posizione dell'etichetta](https://reference.aspose.com/slides/it/net/aspose.slides.charts/axis/majortickmark/) su "cross", "outside" o "inside". Questo influisce sulla leggibilità e aiuta a risparmiare spazio, specialmente nei grafici ridotti.