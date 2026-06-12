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
description: "Crea e personalizza potenti grafici a bolle in PowerPoint con Aspose.Slides per C++ per migliorare facilmente la visualizzazione dei dati."
---
## **Panoramica**

Questo articolo mostra come lavorare con i grafici a bolle in Aspose.Slides. Copre due opzioni di personalizzazione specifiche: dimensionare le dimensioni delle bolle tramite il metodo `set_BubbleSizeScale` e controllare come i valori di dimensione delle bolle sono rappresentati tramite il metodo `set_BubbleSizeRepresentation`.

Gli esempi dimostrano come creare un grafico a bolle, regolare il suo dimensionamento e passare alla rappresentazione della dimensione della bolla usando la larghezza. L'articolo include anche una breve sezione FAQ che chiarisce il supporto per il tipo di grafico “Bubble with 3-D”, nota che i limiti pratici dei grafici dipendono dalle prestazioni e dalla versione target di PowerPoint, e spiega che l'esportazione preserva l'aspetto del grafico tramite il motore di rendering di Aspose.Slides.

## **Dimensionamento della dimensione del grafico a bolle**
Aspose.Slides per C++ fornisce il supporto per il dimensionamento della dimensione dei grafici a bolle. In Aspose.Slides per **C++ IChartSeries.BubbleSizeScale** e **IChartSeriesGroup.BubbleSizeScale** sono state aggiunte le proprietà. Di seguito è riportato un esempio. 

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingBubbleChartScaling-SettingBubbleChartScaling.cpp" >}}

## **Rappresentare i dati come dimensioni del grafico a bolle**
È stato aggiunto il nuovo metodo **get_BubbleSizeRepresentation()** alle classi **IChartSeries** e **ChartSeries**. **BubbleSizeRepresentation** specifica come i valori di dimensione della bolla sono rappresentati nel grafico a bolle. I valori possibili sono: **BubbleSizeRepresentationType.Area** e **BubbleSizeRepresentationType.Width**. Di conseguenza, è stato aggiunto l'enumerazione **BubbleSizeRepresentationType** per specificare i possibili modi di rappresentare i dati come dimensioni del grafico a bolle. Il codice di esempio è fornito di seguito.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SupportOfBubbleSizeRepresentation-SupportOfBubbleSizeRepresentation.cpp" >}}

## **FAQ**

**È supportato un "grafico a bolle con effetto 3-D" e in che modo differisce da uno normale?**

Sì. Esiste un tipo di grafico separato, "Bubble with 3-D". Applica uno stile 3-D alle bolle ma non aggiunge un asse aggiuntivo; i dati rimangono X-Y-S (dimensione). Il tipo è disponibile nell'enumerazione [tipo di grafico](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/charttype/).

**Esiste un limite al numero di serie e punti in un grafico a bolle?**

Non c'è un limite rigido a livello di API; le restrizioni sono determinate da prestazioni e dalla versione target di PowerPoint. Si consiglia di mantenere il numero di punti ragionevole per la leggibilità e la velocità di rendering.

**Come influenzerà l'esportazione l'aspetto di un grafico a bolle (PDF, immagini)?**

L'esportazione nei formati supportati preserva l'aspetto del grafico; il rendering è effettuato dal motore Aspose.Slides. Per i formati raster/vettoriali, si applicano le regole generali di rendering della grafica dei grafici (risoluzione, anti-aliasing), quindi è opportuno scegliere una DPI sufficiente per la stampa.