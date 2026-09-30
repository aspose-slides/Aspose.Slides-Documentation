---
title: Personalizza le legende dei grafici nelle presentazioni in .NET
linktitle: Legenda del grafico
type: docs
url: /it/net/chart-legend/
keywords:
- legenda del grafico
- posizione della legenda
- dimensione del carattere
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Personalizza le legende dei grafici con Aspose.Slides per .NET per ottimizzare le presentazioni PowerPoint con una formattazione della legenda su misura."
---
## **Panoramica**

Aspose.Slides per .NET offre opzioni per personalizzare le legende dei grafici nelle presentazioni PowerPoint. Questo articolo mostra come posizionare e dimensionare una legenda, impostare la dimensione del carattere per l'intera legenda, formattare una voce di legenda individuale e nascondere o ripristinare le voci selezionate.

Le FAQ coprono comportamenti correlati, inclusa la riserva di spazio per la legenda, la visualizzazione di etichette multilinea e l'ereditarietà della formattazione dal tema della presentazione.

## **Posizionamento della Legenda**

Utilizza le proprietà [X](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/x/), [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/y/), [Width](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/width/) e [Height](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/height/) della legenda per specificarne la posizione e le dimensioni come frazioni delle dimensioni del grafico.

Questo esempio crea una presentazione e aggiunge un grafico a colonne raggruppate con dati predefiniti alla prima diapositiva. Dividendo gli offset e le dimensioni desiderate della legenda per la larghezza e l'altezza del grafico si ottengono valori relativi: la legenda è spostata di 50 punti dall'angolo in alto a sinistra del grafico e ha dimensioni di 100 per 100 punti.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

// Express the legend's position and size relative to the chart.
chart.Legend.X = 50 / chart.Width;
chart.Legend.Y = 50 / chart.Height;
chart.Legend.Width = 100 / chart.Width;
chart.Legend.Height = 100 / chart.Height;

presentation.Save("legend_position.pptx", SaveFormat.Pptx);
```

## **Imposta la dimensione del carattere di una legenda**

Utilizza il [TextFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/textformat/) della legenda per accedere alla formattazione del testo e impostare [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) in punti.

Questo esempio crea un grafico con dati predefiniti e imposta il testo della legenda a 20 punti. Disabilita inoltre i limiti automatici per l'asse verticale e ne imposta l'intervallo da -5 a 10.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

chart.Legend.TextFormat.PortionFormat.FontHeight = 20;
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
chart.Axes.VerticalAxis.MinValue = -5;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.MaxValue = 10;

presentation.Save("legend_font_size.pptx", SaveFormat.Pptx);
```

## **Imposta la dimensione del carattere di una voce di legenda individuale**

Utilizza la collezione [Entries](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/entries/) della legenda per accedere alla formattazione di una voce specifica. Gli indici delle voci sono a base zero, quindi l'indice `1` si riferisce alla seconda voce.

Questo esempio crea un grafico a colonne raggruppate i cui dati predefiniti includono almeno due serie. Formatta la seconda voce della legenda con testo grassetto, corsivo e di colore blu a 20 punti.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
var textFormat = chart.Legend.Entries[1].TextFormat;

textFormat.PortionFormat.FontBold = NullableBool.True;
textFormat.PortionFormat.FontHeight = 20;
textFormat.PortionFormat.FontItalic = NullableBool.True;
textFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
textFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;

presentation.Save("legend_entry_format.pptx", SaveFormat.Pptx);
```

## **Nascondi voci di legenda individuali**

Per escludere una serie ausiliaria dalla legenda mantenendo i suoi dati visibili, imposta [ILegendEntryProperties.Hide](https://reference.aspose.com/slides/net/aspose.slides.charts/ilegendentryproperties/hide/) su `true` tramite [IChartSeries.RelatedLegendEntry](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/relatedlegendentry/). Questo nasconde solo la voce di legenda selezionata; non rimuove la serie né i suoi punti dati. Impostare [IChart.HasLegend](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/haslegend/) su `false`, al contrario, nasconde l'intera legenda.

L'esempio seguente crea un grafico a colonne raggruppate con più serie usando dati predefiniti. Nasconde la voce di legenda della seconda serie (indice `1`) e salva la presentazione. Successivamente ripristina la voce impostando `Hide` su `false` e salva una seconda copia. Le colonne restano visibili in entrambi i file.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 200);
chart.HasLegend = true;

var legendEntry = chart.ChartData.Series[1].RelatedLegendEntry;

legendEntry.Hide = true;
presentation.Save("hidden_legend_entry.pptx", SaveFormat.Pptx);

// Ripristina la stessa voce senza modificare i dati del grafico.
legendEntry.Hide = false;
presentation.Save("restored_legend_entry.pptx", SaveFormat.Pptx);
```

Il confronto qui sotto mostra lo stesso grafico con tutte le voci della legenda visibili e con la seconda voce nascosta. Le colonne della seconda serie rimangono inalterate.

![Confronto di un grafico con tutte le voci della legenda visibili e con la Serie 2 nascosta nella legenda; tutte le colonne rimangono visibili.](hide-legend-entry.png)

Nei grafici a colonne, a barre e a linee, le voci della legenda identificano le serie. Per i grafici a torta, identificano i singoli punti dati (fette), quindi utilizza [IChartDataPoint.RelatedLegendEntry](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/relatedlegendentry/) sulla fetta selezionata. L'API documenta questa proprietà del punto dati per i tipi di grafico `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` e `BarOfPie`. Non presumere che si applichi ai grafici a ciambella, che non sono inclusi in quell'elenco.

## **FAQ**

**Posso fare in modo che il grafico riservi spazio per la legenda invece di sovrapporla?**  
Sì. Imposta [Overlay](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/overlay/) su `false` per riservare spazio alla legenda invece di consentirne la sovrapposizione all'area del grafico.

**Posso creare etichette della legenda multilinea?**  
Sì. Le etichette lunghe possono andare a capo quando la larghezza disponibile è insufficiente. È inoltre possibile utilizzare caratteri di newline nei nomi delle serie per richiedere interruzioni di riga.

**Come posso fare in modo che la legenda segua lo schema di colori del tema della presentazione?**  
Lascia le impostazioni di colori, riempimenti e caratteri della legenda non definite in modo che possa ereditare la formattazione del tema. La formattazione esplicita sovrascrive le impostazioni corrispondenti del tema.