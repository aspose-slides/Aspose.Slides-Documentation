---
title: Come creare grafici nelle presentazioni in .NET
linktitle: Crea grafico
type: docs
weight: 30
url: /it/net/how-to-create-charts-in-a-presentation/
keywords:
- migrazione
- creare grafico
- codice legacy
- codice moderno
- approccio legacy
- approccio moderno
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Scopri come creare grafici nelle presentazioni PowerPoint PPT, PPTX e ODP in .NET con Aspose.Slides utilizzando sia le API di grafici legacy sia quelle moderne."
---
{{% alert color="primary" %}} 
È stata rilasciata una nuova [Aspose.Slides for .NET API](/slides/it/net/) ed ora questo unico prodotto supporta la capacità di generare documenti PowerPoint da zero e modificare quelli esistenti.
{{% /alert %}} 
## **Supporto per il codice legacy**
Per utilizzare il codice legacy sviluppato con Aspose.Slides per .NET nelle versioni precedenti alla 13.x, è necessario apportare alcune piccole modifiche al proprio codice affinché continui a funzionare come prima. Tutte le classi presenti nella vecchia versione di Aspose.Slides per .NET nei namespace Aspose.Slide e Aspose.Slides.Pptx sono ora unite in un unico namespace Aspose.Slides. Si prega di dare un'occhiata al seguente semplice frammento di codice per creare un grafico normale da zero in una presentazione utilizzando l'API legacy di Aspose.Slides e di seguire i passaggi che descrivono come migrare verso la nuova API unificata.
## **Approccio Legacy di Aspose.Slides per .NET**
```c#
//Istanzia la classe PresentationEx che rappresenta il file PPTX
using (PresentationEx pres = new PresentationEx())
{
	//Accedi alla prima slide
	SlideEx sld = pres.Slides[0];

	// Aggiungi grafico con dati predefiniti
	ChartEx chart = sld.Shapes.AddChart(ChartTypeEx.ClusteredColumn, 0, 0, 500, 500);

	//Imposta il titolo del grafico
	chart.ChartTitle.Text.Text = "Sample Title";
	chart.ChartTitle.Text.CenterText = true;
	chart.ChartTitle.Height = 20;
	chart.HasTitle = true;

	//Imposta la prima serie per mostrare i valori
	chart.ChartData.Series[0].Labels.ShowValue = true;

	//Imposta l'indice del foglio dati del grafico 
	int defaultWorksheetIndex = 0;

	//Ottieni il foglio dati del grafico
	ChartDataCellFactory fact = chart.ChartData.ChartDataCellFactory;

	//Elimina le serie e le categorie generate di default
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Clear();
	int s = chart.ChartData.Series.Count;
	s = chart.ChartData.Categories.Count;

	//Aggiungi nuove serie
	chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
	chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

	//Aggiungi nuove categorie
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

	//Prendi la prima serie del grafico
	ChartSeriesEx series = chart.ChartData.Series[0];

	//Ora popoliamo i dati della serie
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

	//Imposta il colore di riempimento per la serie
	series.Format.Fill.FillType = FillTypeEx.Solid;
	series.Format.Fill.SolidFillColor.Color = Color.Red;


	//Prendi la seconda serie del grafico
	series = chart.ChartData.Series[1];

	//Ora popoliamo i dati della serie
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

	//Imposta il colore di riempimento per la serie
	series.Format.Fill.FillType = FillTypeEx.Solid;
	series.Format.Fill.SolidFillColor.Color = Color.Green;


	//Crea etichette personalizzate per ciascuna categoria per la nuova serie

	//La prima etichetta mostrerà il nome della categoria
	DataLabelEx lbl = new DataLabelEx(series);
	lbl.ShowCategoryName = true;
	lbl.Id = 0;
	series.Labels.Add(lbl);

	//Mostra il nome della serie per la seconda etichetta
	lbl = new DataLabelEx(series);
	lbl.ShowSeriesName = true;
	lbl.Id = 1;
	series.Labels.Add(lbl);

	//Mostra il valore per la terza etichetta
	lbl = new DataLabelEx(series);
	lbl.ShowValue = true;
	lbl.ShowSeriesName = true;
	lbl.Separator = "/";
	lbl.Id = 2;
	series.Labels.Add(lbl);

	//Mostra valore e testo personalizzato
	lbl = new DataLabelEx(series);
	lbl.TextFrame.Text = "My text";
	lbl.Id = 3;
	series.Labels.Add(lbl);

	//Salva la presentazione con il grafico
	pres.Write(@"D:\AsposeChart.pptx");
}
```

## **Nuovo Approccio Aspose.Slides per .NET 13.x**
``` csharp
//Istanzia la classe Presentation che rappresenta il file PPTX//Istanzia la classe Presentation che rappresenta il file PPTX
Presentation pres = new Presentation();

//Accedi alla prima slide
ISlide sld = pres.Slides[0];

// Aggiungi grafico con dati predefiniti
IChart chart = sld.Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 500);

//Imposta il titolo del grafico
//chart.ChartTitle.TextFrameForOverriding.Text = "Sample Title";
chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

//Imposta la prima serie per mostrare i valori
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

//Imposta l'indice del foglio dati del grafico
int defaultWorksheetIndex = 0;

//Ottieni il foglio dati del grafico
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

//Elimina le serie e le categorie generate di default
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
int s = chart.ChartData.Series.Count;
s = chart.ChartData.Categories.Count;

//Aggiungi nuove serie
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

//Aggiungi nuove categorie
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

//Prendi la prima serie del grafico
IChartSeries series = chart.ChartData.Series[0];

//Ora popoliamo i dati della serie

series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

//Imposta il colore di riempimento per la serie
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;


//Prendi la seconda serie del grafico
series = chart.ChartData.Series[1];

//Ora popoliamo i dati della serie
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

//Imposta il colore di riempimento per la serie
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Green;


//Crea etichette personalizzate per ciascuna categoria per la nuova serie

//La prima etichetta mostrerà il nome della categoria
IDataLabel lbl = series.DataPoints[0].Label;
lbl.DataLabelFormat.ShowCategoryName = true;

lbl = series.DataPoints[1].Label;
lbl.DataLabelFormat.ShowSeriesName = true;

//Mostra il valore per la terza etichetta
lbl = series.DataPoints[2].Label;
lbl.DataLabelFormat.ShowValue = true;
lbl.DataLabelFormat.ShowSeriesName = true;
lbl.DataLabelFormat.Separator = "/";

//Salva la presentazione con il grafico
pres.Save("AsposeChart.pptx", SaveFormat.Pptx);
```
Si prega di dare un'occhiata al seguente semplice frammento di codice per creare un grafico a dispersione da zero in una presentazione utilizzando l'API legacy di Aspose.Slides e di vedere come ottenerlo con la nuova API unificata.
## **Approccio Legacy di Aspose.Slides per .NET**
```c#
using (PresentationEx pres = new PresentationEx())
{
    SlideEx slide = pres.Slides[0];

    //Creazione del grafico predefinito
    ChartEx chart = slide.Shapes.AddChart(ChartTypeEx.ScatterWithSmoothLines, 0, 0, 400, 400);

    //Ottenimento dell'indice del foglio dati del grafico predefinito
    int defaultWorksheetIndex = 0;

    //Accesso al foglio dati del grafico
    ChartDataCellFactory fact = chart.ChartData.ChartDataCellFactory;

    //Elimina le serie demo
    chart.ChartData.Series.Clear();

    //Aggiungi nuove serie
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.Type);

    //Prendi la prima serie del grafico
    ChartSeriesEx series = chart.ChartData.Series[0];

    //Aggiungi nuovo punto (1:3) lì.
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 1));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

    //Aggiungi nuovo punto (2:10)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 2));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

    //Modifica il tipo della serie
    series.Type = ChartTypeEx.ScatterWithStraightLinesAndMarkers;

    //Modifica il marcatore della serie del grafico
    series.MarkerSize = 10;
    series.MarkerSymbol = MarkerStyleTypeEx.Star;

    //Prendi la seconda serie del grafico
    series = chart.ChartData.Series[1];

    //Aggiungi nuovo punto (5:2) lì.
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 3, 5));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

    //Aggiungi nuovo punto (3:1)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 3, 3));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

    //Aggiungi nuovo punto (2:2)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 4, 3, 2));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

    //Aggiungi nuovo punto (5:1)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 5, 3, 5));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

    //Modifica il marcatore della serie del grafico
    series.MarkerSize = 10;
    series.MarkerSymbol = MarkerStyleTypeEx.Circle;

    pres.Write("D:\\AsposeSeriesChart.pptx");
}
```

## **Nuovo Approccio Aspose.Slides per .NET 13.x**
``` csharp
Presentation pres = new Presentation();

ISlide slide = pres.Slides[0];

//Creazione del grafico predefinito
IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);

//Ottenimento dell'indice del foglio dati del grafico predefinito
int defaultWorksheetIndex = 0;

//Accesso al foglio dati del grafico
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

//Elimina le serie demo
chart.ChartData.Series.Clear();

//Aggiungi nuove serie
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.Type);

//Prendi la prima serie del grafico
IChartSeries series = chart.ChartData.Series[0];

//Aggiungi nuovo punto (1:3) lì.
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 1), fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

//Aggiungi nuovo punto (2:10)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 2), fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

//Modifica il tipo della serie
series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

//Modifica il marcatore della serie del grafico
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Star;

//Prendi la seconda serie del grafico
series = chart.ChartData.Series[1];

//Aggiungi nuovo punto (5:2) lì.
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 3, 5), fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

//Aggiungi nuovo punto (3:1)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 3, 3), fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

//Aggiungi nuovo punto (2:2)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 4, 3, 2), fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

//Aggiungi nuovo punto (5:1)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 5, 3, 5), fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

//Modifica il marcatore della serie del grafico
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Circle;

pres.Save("AsposeScatterChart.pptx", SaveFormat.Pptx);
```