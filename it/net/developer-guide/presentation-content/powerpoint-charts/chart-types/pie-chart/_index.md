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
- colore della fetta
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Crea e personalizza grafici a torta in .NET con Aspose.Slides. Configura tracciati secondari, visualizza le etichette dei dati e applica colori automatici alle fette in PowerPoint."
---
## **Panoramica**

Questo articolo spiega come lavorare con i grafici a torta in Aspose.Slides. Mostra come configurare le opzioni di tracciato secondario per i grafici Pie of Pie e Bar of Pie, e come abilitare la colorazione automatica delle fette per un grafico a torta standard.

Gli esempi si concentrano su attività di personalizzazione del grafico come aggiungere un grafico a una diapositiva, regolare le impostazioni delle serie e delle etichette, sostituire i dati predefiniti del grafico con categorie e valori personalizzati e salvare la presentazione aggiornata.

## **Opzioni di Tracciato Secondario per i Grafici Pie of Pie e Bar of Pie**

Aspose.Slides per .NET supporta le opzioni di tracciato secondario per i grafici Pie of Pie e Bar of Pie. Queste opzioni controllano la dimensione del tracciato secondario e come i punti dati vengono suddivisi tra i due tracciati.

Il seguente esempio crea un grafico Pie of Pie in una nuova presentazione e visualizza i valori dei punti dati come etichette. La proprietà [SecondPieSize](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/secondpiesize/) imposta la dimensione del tracciato secondario al 149% del tracciato principale. [PieSplitBy](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/piesplitby/) seleziona la divisione basata su percentuale e [PieSplitPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/piesplitposition/) imposta la soglia al 53%.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.PieOfPie, 50, 50, 500, 400);
var series = chart.ChartData.Series[0];

// Display values and configure the secondary plot.
series.Labels.DefaultDataLabelFormat.ShowValue = true;
var seriesGroup = series.ParentSeriesGroup;
seriesGroup.SecondPieSize = 149;
seriesGroup.PieSplitBy = PieSplitType.ByPercentage;
seriesGroup.PieSplitPosition = 53;

presentation.Save("pie_of_pie.pptx", SaveFormat.Pptx);
```

### **Seleziona le Categorie per il Tracciato Secondario**

Usa la suddivisione personalizzata quando desideri raggruppare categorie specifiche nel tracciato secondario indipendentemente dai loro valori percentuali. Ad esempio, un rapporto di vendite potrebbe mostrare Online e Eventi insieme così i lettori possono confrontare questi due canali, anche se rappresentano il 35% e il 10% delle vendite totali.

Imposta [PieSplitBy](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseriesgroup/piesplitby/) su [PieSplitType.Custom](https://reference.aspose.com/slides/net/aspose.slides.charts/piesplittype/) e seleziona i punti tramite [PieSplitCustomPoints](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseriesgroup/piesplitcustompoints/). Il metodo [Add](https://reference.aspose.com/slides/net/aspose.slides.charts/piesplitcustompointcollection/add/) della raccolta accetta un indice zero‑based nella serie o un oggetto punto dati. In questo esempio, l’indice 1 seleziona Online e il punto all’indice 3 seleziona Eventi. Partners viene anche aggiunto temporaneamente, poi escluso usando [Remove](https://reference.aspose.com/slides/net/aspose.slides.charts/piesplitcustompointcollection/remove/).

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.PieOfPie, 50, 50, 600, 200);

// Sostituisci i dati predefiniti con le vendite per canale.
var workbook = chart.ChartData.ChartDataWorkbook;
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
var categoryNames = new[] { "Retail", "Online", "Partners", "Events" };
var values = new[] { 40, 35, 15, 10 };
var seriesNameCell = workbook.GetCell(0, 0, 1, "Sales");
var series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

for (var i = 0; i < categoryNames.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, categoryNames[i]);
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForPieSeries(valueCell);
}

series.Labels.DefaultDataLabelFormat.ShowValue = true;
var seriesGroup = series.ParentSeriesGroup;
seriesGroup.PieSplitBy = PieSplitType.Custom;
seriesGroup.IsColorVaried = true;

// Seleziona Online tramite il suo indice a base zero e Events tramite il suo oggetto punto dati.
seriesGroup.PieSplitCustomPoints.Add(1);
seriesGroup.PieSplitCustomPoints.Add(series.DataPoints[3]);

// Escludi Partners dalla selezione senza eliminare i dati di origine.
seriesGroup.PieSplitCustomPoints.Add(2);
seriesGroup.PieSplitCustomPoints.Remove(series.DataPoints[2]);

presentation.Save("pie_of_pie_custom.pptx", SaveFormat.Pptx);
```

Online (35) e Eventi (10) compaiono come fette separate nel tracciato secondario. Nel tracciato principale, sono rappresentati da una singola fetta combinata con valore 45, insieme a Retail (40) e Partners (15). Rimuovere Partners dalla selezione personalizzata lo mantiene nel tracciato principale; non rimuove la categoria o il suo valore dai dati di origine del grafico.

Il seguente immagine mostra la presentazione salvata in PowerPoint:

![Grafico Pie of Pie con Online e Eventi nel tracciato secondario e il loro valore combinato di 45 nel tracciato principale](pie_of_pie_custom.png)

## **Imposta i Colori Automatici delle Fette del Grafico a Torta**

Aspose.Slides per .NET può assegnare automaticamente colori diversi alle fette del grafico a torta. Il seguente esempio crea un grafico a torta con un titolo centrato e sostituisce i dati predefiniti con tre categorie trimestrali e i loro valori. La proprietà [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) visualizza i valori 20, 50 e 30 come etichette, mentre [IsColorVaried](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/iscolorvaried/) abilita un colore distinto per ogni fetta.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 100, 100, 400, 400);

// Aggiungi un titolo del grafico centrato.
chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

// Sostituisci i dati predefiniti usando il primo foglio di lavoro.
var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
var categoryNames = new[] { "First Qtr", "2nd Qtr", "3rd Qtr" };
var values = new[] { 20, 50, 30 };
var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 1, "Series 1");
var series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

for (var i = 0; i < categoryNames.Length; i++)
{
    var categoryCell = workbook.GetCell(worksheetIndex, i + 1, 0, categoryNames[i]);
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(worksheetIndex, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForPieSeries(valueCell);
}

// Visualizza i valori e assegna colori diversi alle fette.
series.Labels.DefaultDataLabelFormat.ShowValue = true;
series.ParentSeriesGroup.IsColorVaried = true;

presentation.Save("pie.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Le varianti Pie of Pie e Bar of Pie sono supportate?**

Sì, la libreria [supporta](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) un tracciato secondario per i grafici a torta, inclusi i tipi Pie of Pie e Bar of Pie.

**Posso esportare solo il grafico come immagine (ad esempio PNG)?**

Sì, è possibile [esportare il grafico stesso come immagine](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) (ad esempio PNG) senza esportare l’intera presentazione.