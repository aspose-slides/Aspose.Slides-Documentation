---
title: Personalizza i grafici a ciambella nelle presentazioni con Python
linktitle: Grafico a ciambella
type: docs
weight: 30
url: /it/python-net/doughnut-chart/
keywords:
- grafico a ciambella
- vuoto centrale
- dimensione del foro
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Scopri come creare e personalizzare i grafici a ciambella in Aspose.Slides per Python tramite .NET, supportando i formati PowerPoint e OpenDocument per presentazioni dinamiche."
---
## **Panoramica**

Questo articolo mostra come lavorare con un grafico a ciambella in Aspose.Slides aggiungendo il grafico a una diapositiva, impostando la dimensione del foro centrale e salvando la presentazione. Si concentra sull'impostazione `doughnut_hole_size` e dimostra i passaggi di base necessari per personalizzare questo tipo di grafico nel codice.

Include anche una breve FAQ che copre scenari correlati ai grafici a ciambella, come l'uso di più serie per creare più anelli, il lavoro con grafici a ciambella “esplosi” e l'esportazione di un grafico come immagine raster o SVG.

## **Specificare il vuoto centrale nel grafico a ciambella**
Per specificare la dimensione del foro in un grafico a ciambella, segui i passaggi seguenti:

- Istanziare la classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
- Aggiungere un grafico a ciambella alla diapositiva.
- Specificare la dimensione del foro in un grafico a ciambella.
- Scrivere la presentazione su disco.

Nell'esempio mostrato di seguito, abbiamo impostato la dimensione del foro in un grafico a ciambella.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Crea un'istanza della classe Presentation
with slides.Presentation() as presentation:

    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.DOUGHNUT, 50, 50, 400, 400)
    chart.chart_data.series_groups[0].doughnut_hole_size = 90

    # Scrivi la presentazione su disco
    presentation.save("DoughnutHoleSize_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Posso creare una ciambella a più livelli con più anelli?**

Sì. Aggiungi più serie a un singolo grafico a ciambella — ogni serie diventa un anello separato. L'ordine degli anelli è determinato dall'ordine delle serie nella raccolta.

**È supportata una ciambella "esplosa" (fette separate)?**

Sì. Esiste un tipo di grafico Exploded Doughnut [chart type](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/charttype/) e una proprietà di esplosione sui punti dati; è possibile separare le singole fette.

**Come posso ottenere un'immagine di un grafico a ciambella (PNG/SVG) per un report?**

Un grafico è una forma; è possibile renderizzarlo in una [immagine raster](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/get_image/) o esportare il grafico in un [immagine SVG](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/write_as_svg/).