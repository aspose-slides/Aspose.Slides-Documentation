---
title: Personalizza i grafici a ciambella nelle presentazioni in .NET
linktitle: Grafico a ciambella
type: docs
weight: 30
url: /it/net/doughnut-chart/
keywords:
- grafico a ciambella
- spazio centrale
- dimensione del foro
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Scopri come creare e personalizzare i grafici a ciambella in Aspose.Slides per .NET, supportando i formati PowerPoint per presentazioni dinamiche."
---
## **Panoramica**

Questo articolo mostra come lavorare con un grafico a ciambella in Aspose.Slides aggiungendo il grafico a una diapositiva, impostando la dimensione del foro centrale e salvando la presentazione. Si concentra sull’impostazione `DoughnutHoleSize` e dimostra i passaggi di base necessari per personalizzare questo tipo di grafico nel codice.

Include anche una breve FAQ che copre scenari correlati ai grafici a ciambella, come l’utilizzo di più serie per creare più anelli, la gestione di grafici a ciambella “esplosi” e l’esportazione di un grafico come immagine raster o SVG.

## **Specificare lo spazio centrale in un grafico a ciambella**
Per specificare la dimensione del foro in un grafico a ciambella, segui i passaggi seguenti:

- Instanziare la classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation).
- Aggiungere un grafico a ciambella alla diapositiva.
- Specificare la dimensione del foro nel grafico a ciambella.
- Scrivere la presentazione su disco.

Nell’esempio mostrato di seguito, abbiamo impostato la dimensione del foro in un grafico a ciambella.

```c#
// Crea un'istanza della classe Presentation
Presentation presentation = new Presentation();

IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);
chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;

// Scrivi la presentazione su disco
presentation.Save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Posso creare una ciambella a più livelli con più anelli?**

Sì. Aggiungi più serie a un unico grafico a ciambella: ogni serie diventa un anello separato. L’ordine degli anelli è determinato dall’ordine delle serie nella collezione.

**È supportato un grafico a ciambella “esploso” (fette separate)?**

Sì. Esiste un [Tipo di grafico](https://reference.aspose.com/slides/it/net/aspose.slides.charts/charttype/) a ciambella esplosa e una proprietà di esplosione sui punti dati; è possibile separare le singole fette.

**Come posso ottenere un’immagine di un grafico a ciambella (PNG/SVG) per un report?**

Un grafico è una forma; puoi renderizzarlo in un [immagine raster](https://reference.aspose.com/slides/it/net/aspose.slides/shape/getimage/) o esportare il grafico in un [immagine SVG](https://reference.aspose.com/slides/it/net/aspose.slides/shape/writeassvg/).