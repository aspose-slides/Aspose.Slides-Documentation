---
title: Personalizza le tabelle dati dei grafici nelle presentazioni in .NET
linktitle: Tabella dati
type: docs
url: /it/net/chart-data-table/
keywords:
- dati del grafico
- tabella dati
- proprietà del carattere
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Personalizza i caratteri, i bordi e le chiavi della legenda delle tabelle dati dei grafici nelle presentazioni PowerPoint utilizzando Aspose.Slides per .NET e C#."
---
## **Panoramica**

Aspose.Slides per .NET consente di visualizzare la tabella dati di un grafico e di personalizzare la formattazione del testo, i bordi e le chiavi della legenda. Questo articolo spiega come abilitare la tabella, formattare il testo, controllare ciascun tipo di bordo e mostrare o nascondere le chiavi della legenda. Gli esempi salvano i grafici configurati in file PPTX.

## **Imposta le proprietà del carattere**

Per visualizzare la tabella dati di un grafico, impostare [HasDataTable](https://reference.aspose.com/slides/it/net/aspose.slides.charts/chart/hasdatatable/) su `true`. Utilizzare [ChartDataTable](https://reference.aspose.com/slides/it/net/aspose.slides.charts/chart/chartdatatable/) per accedere alla tabella e configurare la formattazione del testo.

1. Carica la presentazione usando la classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/).
1. Aggiungi un grafico a colonne raggruppate alla prima diapositiva.
1. Abilita la tabella dati del grafico.
1. Abilita il grassetto con [FontBold](https://reference.aspose.com/slides/it/net/aspose.slides/baseportionformat/fontbold/) e imposta [FontHeight](https://reference.aspose.com/slides/it/net/aspose.slides/baseportionformat/fontheight/) a `20` per un testo di 20 punti.
1. Salva la presentazione modificata.

L'esempio seguente richiede `test.pptx` nella directory di lavoro con almeno una diapositiva. Aggiunge un grafico con dati predefiniti nella posizione (50, 50), con una larghezza di 600 punti e un'altezza di 400 punti. Il file `output.pptx` salvato contiene il grafico con la tabella dati abilitata e le impostazioni del carattere specificate applicate.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("test.pptx");
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
chart.HasDataTable = true;

var portionFormat = chart.ChartDataTable.TextFormat.PortionFormat;
portionFormat.FontBold = NullableBool.True;
portionFormat.FontHeight = 20;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Personalizza i bordi della tabella dati**

Abilita la tabella con [IChart.HasDataTable](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichart/hasdatatable/) e accedila tramite [IChart.ChartDataTable](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichart/chartdatatable/). È possibile controllare tre tipologie di bordi in modo indipendente:

- [HasBorderHorizontal](https://reference.aspose.com/slides/it/net/aspose.slides.charts/idatatable/hasborderhorizontal/) controlla i bordi orizzontali delle celle.
- [HasBorderVertical](https://reference.aspose.com/slides/it/net/aspose.slides.charts/idatatable/hasbordervertical/) controlla i bordi verticali delle celle.
- [HasBorderOutline](https://reference.aspose.com/slides/it/net/aspose.slides.charts/idatatable/hasborderoutline/) controlla il bordo esterno della tabella.

Imposta ogni proprietà su `true` per visualizzare i bordi o su `false` per nasconderli. L'esempio seguente crea un grafico a colonne raggruppate con dati predefiniti, visualizza i bordi orizzontali e il bordo esterno e nasconde i bordi verticali. Non richiede alcun file di input. La posizione e le dimensioni del grafico sono specificate in punti.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
chart.HasDataTable = true;

var dataTable = chart.ChartDataTable;
dataTable.HasBorderHorizontal = true;
dataTable.HasBorderVertical = false;
dataTable.HasBorderOutline = true;

presentation.Save("data-table-borders.pptx", SaveFormat.Pptx);
```

Il confronto sotto utilizza gli stessi dati del grafico e l'impostazione della chiave della legenda in tutti e quattro i casi. Partendo da tutti i bordi abilitati, ogni variante rimanente disabilita una sola proprietà del bordo. La variante in basso a sinistra corrisponde alle impostazioni dei bordi dell'esempio.

![Tabelle dati del grafico con tutti i bordi abilitati, senza bordi orizzontali, senza bordi verticali e senza bordo esterno](data-table-borders.png)

## **Mostra o nascondi le chiavi della legenda**

Le chiavi della legenda sono piccoli marcatore colorati accanto ai nomi delle serie nella tabella dati. Aiutano i lettori a collegare ogni riga della tabella a una serie del grafico. Imposta [ShowLegendKey](https://reference.aspose.com/slides/it/net/aspose.slides.charts/idatatable/showlegendkey/) su `true` per mostrare questi marcatore o su `false` per nasconderli.

La legenda separata del grafico è controllata da [IChart.HasLegend](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichart/haslegend/). queste impostazioni sono indipendenti: nascondere la legenda separata non nasconde le chiavi all'interno della tabella dati, e nascondere le chiavi della tabella non nasconde la legenda separata.

L'esempio seguente crea un grafico con dati predefiniti, abilita la sua tabella dati e mostra le chiavi della legenda al suo interno mentre nasconde la legenda separata. Tutti i bordi della tabella sono esplicitamente abilitati. Non è richiesta alcuna presentazione di input. Per nascondere solo le chiavi della tabella, modifica `dataTable.ShowLegendKey` a `false`.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
chart.HasDataTable = true;
chart.HasLegend = false;

var dataTable = chart.ChartDataTable;
dataTable.HasBorderHorizontal = true;
dataTable.HasBorderVertical = true;
dataTable.HasBorderOutline = true;
dataTable.ShowLegendKey = true;

presentation.Save("data-table-legend-keys.pptx", SaveFormat.Pptx);
```

Il confronto sotto mostra la stessa tabella con le chiavi della legenda abilitate e disabilitate. Tutti i bordi rimangono abilitati e la legenda separata del grafico è nascosta in entrambi i casi.

![Tabelle dati del grafico con le chiavi della legenda mostrate a sinistra e nascoste a destra](data-table-legend-keys.png)

## **FAQ**

**Posso mostrare le chiavi della legenda nella tabella dati di un grafico?**

Sì. Imposta [ShowLegendKey](https://reference.aspose.com/slides/it/net/aspose.slides.charts/datatable/showlegendkey/) su `true` per visualizzare le chiavi della legenda o su `false` per nasconderle.

**La tabella dati verrà conservata durante l'esportazione della presentazione in PDF, HTML o immagini?**

Sì. Aspose.Slides rende il grafico e la sua tabella dati visualizzata come parte della diapositiva quando si esporta in [PDF](/slides/it/net/convert-powerpoint-to-pdf/), [HTML](/slides/it/net/convert-powerpoint-to-html/) o [immagini](/slides/it/net/convert-powerpoint-to-png/).

**Posso lavorare con le tabelle dati nei grafici caricati da un modello?**

Sì. Per un grafico caricato da una presentazione o da un modello esistente, utilizza [HasDataTable](https://reference.aspose.com/slides/it/net/aspose.slides.charts/chart/hasdatatable/) per verificare o modificare se la sua tabella dati è visualizzata.

**Come posso trovare i grafici che hanno la tabella dati abilitata?**

Itera attraverso le forme di ogni diapositiva, individua i grafici e controlla la loro proprietà [HasDataTable](https://reference.aspose.com/slides/it/net/aspose.slides.charts/chart/hasdatatable/). Un valore `true` indica che la tabella dati è abilitata.