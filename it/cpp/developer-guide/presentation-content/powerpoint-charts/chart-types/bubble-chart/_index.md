---
title: Personalizza i grafici a bolle nelle presentazioni usando C++
linktitle: Grafico a bolle
type: docs
url: /it/cpp/bubble-chart/
keywords:
- grafico a bolle
- dimensione della bolla
- scalatura della dimensione
- rappresentazione della dimensione
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Crea e personalizza potenti grafici a bolle in PowerPoint con Aspose.Slides per C++ per migliorare facilmente la visualizzazione dei tuoi dati."
---
## **Panoramica**

Questo articolo mostra come lavorare con i grafici a bolle in Aspose.Slides. Copre due specifiche opzioni di personalizzazione: la scala delle dimensioni delle bolle tramite il metodo `set_BubbleSizeScale` e il controllo di come i valori delle dimensioni delle bolle sono rappresentati tramite il metodo `set_BubbleSizeRepresentation`.  
Gli esempi dimostrano come creare un grafico a bolle, regolare la scala delle dimensioni e passare alla rappresentazione della dimensione della bolla usando la larghezza. L'articolo include anche una breve sezione FAQ che chiarisce il supporto per il tipo di grafico “Bubble with 3-D”, segnala che i limiti pratici del grafico dipendono dalle prestazioni e dalla versione di PowerPoint di destinazione, ed esplica che l'esportazione preserva l'aspetto del grafico tramite il motore di rendering di Aspose.Slides.

## **Scalatura delle dimensioni del grafico a bolle**
Aspose.Slides per C++ fornisce il supporto alla scalatura delle dimensioni del grafico a bolle. In Aspose.Slides per **C++ IChartSeries.BubbleSizeScale** e **IChartSeriesGroup.BubbleSizeScale** sono state aggiunte le proprietà. Di seguito è riportato un esempio.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingBubbleChartScaling-SettingBubbleChartScaling.cpp" >}}

## **Rappresentare i dati come dimensioni del grafico a bolle**
È stato aggiunto il nuovo metodo **get_BubbleSizeRepresentation()** alle classi **IChartSeries** e **ChartSeries**. **BubbleSizeRepresentation** specifica come i valori delle dimensioni delle bolle sono rappresentati nel grafico a bolle. I valori possibili sono: **BubbleSizeRepresentationType.Area** e **BubbleSizeRepresentationType.Width**. Di conseguenza, è stato aggiunto l’enumerazione **BubbleSizeRepresentationType** per specificare i possibili modi di rappresentare i dati come dimensioni del grafico a bolle. Di seguito è riportato il codice di esempio.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SupportOfBubbleSizeRepresentation-SupportOfBubbleSizeRepresentation.cpp" >}}

## **FAQ**

**È supportato un "grafico a bolle con effetto 3-D" e in che cosa differisce da uno normale?**

Sì. Esiste un tipo di grafico separato, "Bubble with 3-D". Applica uno stile 3-D alle bolle ma non aggiunge assi aggiuntivi; i dati rimangono X-Y-S (dimensione). Il tipo è disponibile nell'enumerazione [chart type](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/charttype/).

**Esiste un limite al numero di serie e punti in un grafico a bolle?**

Non esiste un limite rigido a livello di API; le restrizioni sono determinate dalle prestazioni e dalla versione di PowerPoint di destinazione. Si consiglia di mantenere un numero ragionevole di punti per garantire leggibilità e velocità di rendering.

**Come influisce l'esportazione sull'aspetto di un grafico a bolle (PDF, immagini)?**

L'esportazione nei formati supportati preserva l'aspetto del grafico; il rendering è eseguito dal motore di Aspose.Slides. Per i formati raster/vettoriali si applicano le regole generali di rendering della grafica dei grafici (risoluzione, anti-aliasing), quindi è consigliato scegliere una DPI adeguata per la stampa.