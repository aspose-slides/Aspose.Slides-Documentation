---
title: Personalizza i grafici a bolle nelle presentazioni con Python
linktitle: Grafico a bolle
type: docs
url: /it/python-net/bubble-chart/
keywords:
- grafico a bolle
- dimensione della bolla
- scalatura delle dimensioni
- rappresentazione della dimensione
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Crea e personalizza potenti grafici a bolle in PowerPoint e OpenDocument con Aspose.Slides per Python tramite .NET per migliorare facilmente la visualizzazione dei dati."
---
## **Panoramica**

Questo articolo mostra come lavorare con i grafici a bolle in Aspose.Slides. Copre due specifiche opzioni di personalizzazione: la scalatura delle dimensioni delle bolle tramite la proprietà `bubble_size_scale` e il controllo di come i valori delle dimensioni delle bolle sono rappresentati tramite la proprietà `bubble_size_representation`.

Gli esempi dimostrano come creare un grafico a bolle, regolare la sua scalatura delle dimensioni e passare alla rappresentazione della dimensione della bolla usando la larghezza. L'articolo include anche una breve sezione FAQ che chiarisce il supporto per il tipo di grafico “Bubble with 3-D”, nota che i limiti pratici del grafico dipendono dalle prestazioni e dalla versione di PowerPoint di destinazione, e spiega che l'esportazione conserva l'aspetto del grafico tramite il motore di rendering di Aspose.Slides.

## **Scalatura della dimensione del grafico a bolle**
Aspose.Slides per Python tramite .NET fornisce il supporto per la scalatura della dimensione del grafico a bolle. In Aspose.Slides per Python tramite .NET sono state aggiunte le proprietà **ChartSeries.bubble_size_scale** e **ChartSeriesGroup.bubble_size_scale**. Di seguito è riportato un esempio di codice.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 100, 100, 400, 300)
	chart.chart_data.series_groups[0].bubble_size_scale = 150
	pres.save("Result.pptx", slides.export.SaveFormat.PPTX)
```




## **Rappresentare i dati come dimensioni del grafico a bolle**
È stata aggiunta la proprietà **bubble_size_representation** alle classi ChartSeries, ChartSeriesGroup. **bubble_size_representation** specifica come i valori della dimensione della bolla sono rappresentati nel grafico a bolle. I valori possibili sono: **BubbleSizeRepresentationType.AREA** e **BubbleSizeRepresentationType.WIDTH**. Di conseguenza, è stato aggiunto l'enumerazione **BubbleSizeRepresentationType** per specificare i possibili modi di rappresentare i dati come dimensioni dei grafici a bolle. Il codice di esempio è riportato di seguito.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)
    chart.chart_data.series_groups[0].bubble_size_representation = charts.BubbleSizeRepresentationType.WIDTH
    pres.save("Presentation_BubbleSizeRepresentation.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Il grafico a bolle con effetto 3-D è supportato e in che modo differisce da uno normale?**

Sì. Esiste un tipo di grafico separato, "Bubble with 3-D". Applica uno stile 3-D alle bolle ma non aggiunge un asse aggiuntivo; i dati rimangono X-Y-S (dimensione). Il tipo è disponibile nell'enumerazione [chart type](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/charttype/).

**Esiste un limite al numero di serie e punti in un grafico a bolle?**

Non esiste un limite rigoroso a livello di API; le limitazioni sono determinate dalle prestazioni e dalla versione di PowerPoint di destinazione. Si consiglia di mantenere il numero di punti ragionevole per leggibilità e velocità di rendering.

**Come influisce l'esportazione sull'aspetto di un grafico a bolle (PDF, immagini)?**

L'esportazione nei formati supportati conserva l'aspetto del grafico; il rendering è eseguito dal motore Aspose.Slides. Per i formati raster/vettoriali si applicano le regole generali di rendering della grafica dei grafici (risoluzione, anti-aliasing), quindi scegliere una DPI adeguata per la stampa.