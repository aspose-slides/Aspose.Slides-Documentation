---
title: Personalizza i grafici a torta nelle presentazioni in .NET
linktitle: Grafico a torta
type: docs
url: /it/net/pie-chart/
keywords:
- grafico a torta
- gestire il grafico
- personalizzare il grafico
- opzioni del grafico
- impostazioni del grafico
- opzioni di tracciato
- colore della sezione
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Scopri come creare e personalizzare grafici a torta in .NET con Aspose.Slides, esportabili in PowerPoint, migliorando la narrazione dei tuoi dati in pochi secondi."
---
## **Panoramica**

Questo articolo spiega come lavorare con i grafici a torta in Aspose.Slides. Mostra come configurare le opzioni di tracciato secondario per i grafici Pie of Pie e Bar of Pie, e come abilitare la colorazione automatica delle sezioni per un grafico a torta standard.

Gli esempi si concentrano su passaggi pratici di personalizzazione del grafico, come aggiungere un grafico alla diapositiva, regolare le impostazioni delle serie e delle etichette, sostituire i dati di default del grafico con categorie e valori personalizzati, e salvare la presentazione aggiornata.

## **Opzioni di Tracciato Secondario per i Grafici Pie of Pie e Bar of Pie**

Aspose.Slides per .NET ora supporta le opzioni di tracciato secondario per i grafici Pie of Pie o Bar of Pie. In questo argomento vedremo, con un esempio, come specificare queste opzioni utilizzando Aspose.Slides. Per specificare le proprietà, segui i passaggi seguenti:

1. Istanziare l'oggetto della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation).
1. Aggiungere un grafico alla diapositiva.
1. Specificare le opzioni di tracciato secondario del grafico.
1. Scrivere la presentazione su disco.

Nell'esempio mostrato di seguito, abbiamo impostato diverse proprietà del grafico Pie of Pie.

```c#
// Crea un'istanza della classe Presentation
Presentation presentation = new Presentation();

// Aggiungi un grafico alla diapositiva
IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.PieOfPie, 50, 50, 500, 400);
     
// Imposta diverse proprietà
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
chart.ChartData.Series[0].ParentSeriesGroup.SecondPieSize = 149;
chart.ChartData.Series[0].ParentSeriesGroup.PieSplitBy = Aspose.Slides.Charts.PieSplitType.ByPercentage;
chart.ChartData.Series[0].ParentSeriesGroup.PieSplitPosition = 53;

// Scrivi la presentazione su disco
presentation.Save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx);
```

## **Imposta i Colori Automatici delle Sezioni del Grafico a Torta**

Aspose.Slides per .NET fornisce un'API semplice per impostare i colori automatici delle sezioni del grafico a torta. Il codice di esempio applica le impostazioni delle proprietà sopra menzionate.

1. Creare un'istanza della classe Presentation.
1. Accedere alla prima diapositiva.
1. Aggiungere un grafico con dati predefiniti.
1. Impostare il titolo del grafico.
1. Impostare la prima serie per mostrare i valori.
1. Impostare l'indice del foglio dati del grafico.
1. Ottenere il foglio di lavoro dei dati del grafico.
1. Eliminare le serie e le categorie generate di default.
1. Aggiungere nuove categorie.
1. Aggiungere nuove serie.

Scrivere la presentazione modificata in un file PPTX.

```c#
// Istanzia la classe Presentation che rappresenta un file PPTX
using (Presentation presentation = new Presentation())
{
	// Istanzia la classe Presentation che rappresenta un file PPTX
	Presentation presentation = new Presentation();

	// Accedi alla prima diapositiva
	ISlide slides = presentation.Slides[0];

	// Aggiungi un grafico con dati predefiniti
	IChart chart = slides.Shapes.AddChart(ChartType.Pie, 100, 100, 400, 400);

	// Impostazione del titolo del grafico
	chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
	chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
	chart.ChartTitle.Height = 20;
	chart.HasTitle = true;

	// Imposta la prima serie per mostrare i valori
	chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

	// Impostazione dell'indice del foglio dati del grafico
	int defaultWorksheetIndex = 0;

	// Ottenimento del foglio di lavoro dei dati del grafico
	IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

	// Elimina le serie e le categorie generate di default
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Clear();

	// Aggiunta di nuove categorie
	chart.ChartData.Categories.Add(fact.GetCell(0, 1, 0, "First Qtr"));
	chart.ChartData.Categories.Add(fact.GetCell(0, 2, 0, "2nd Qtr"));
	chart.ChartData.Categories.Add(fact.GetCell(0, 3, 0, "3rd Qtr"));

	// Aggiunta di nuove serie
	IChartSeries series = chart.ChartData.Series.Add(fact.GetCell(0, 0, 1, "Series 1"), chart.Type);

	// Ora si popolano i dati della serie
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

	series.ParentSeriesGroup.IsColorVaried = true;
	presentation.Save("C:\\Aspose Data\\Pie.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```
## **FAQ**

**Le varianti 'Pie of Pie' e 'Bar of Pie' sono supportate?**

Sì, la libreria [supporta](https://reference.aspose.com/slides/it/net/aspose.slides.charts/charttype/) un tracciato secondario per i grafici a torta, incluse le tipologie 'Pie of Pie' e 'Bar of Pie'.

**Posso esportare solo il grafico come immagine (ad esempio, PNG)?**

Sì, è possibile [esportare il grafico stesso come immagine](https://reference.aspose.com/slides/it/net/aspose.slides/shape/getimage/) (ad esempio PNG) senza l'intera presentazione.