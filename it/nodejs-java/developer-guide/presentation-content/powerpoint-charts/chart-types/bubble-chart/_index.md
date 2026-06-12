---
title: Personalizza i diagrammi a bolle nelle presentazioni usando JavaScript
linktitle: Diagramma a bolle
type: docs
url: /it/nodejs-java/bubble-chart/
keywords:
- diagramma a bolle
- dimensione bolla
- scalatura dimensione
- rappresentazione dimensione
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Crea e personalizza potenti diagrammi a bolle in PowerPoint con JavaScript e Aspose.Slides per Node.js via Java per migliorare facilmente la visualizzazione dei dati."
---
## **Panoramica**

Questo articolo mostra come lavorare con i diagrammi a bolle in Aspose.Slides. Copre due opzioni di personalizzazione specifiche: la scalatura delle dimensioni delle bolle tramite il metodo `setBubbleSizeScale` e il controllo di come i valori delle dimensioni delle bolle sono rappresentati tramite il metodo `setBubbleSizeRepresentation`.

Gli esempi dimostrano come creare un diagramma a bolle, regolare la sua scalatura delle dimensioni e passare la rappresentazione delle dimensioni della bolla per utilizzare la larghezza. L'articolo include anche una breve sezione FAQ che chiarisce il supporto per il tipo di diagramma “Bubble with 3-D”, osserva che i limiti pratici del diagramma dipendono dalle prestazioni e dalla versione di PowerPoint di destinazione, e spiega che l'esportazione preserva l'aspetto del diagramma tramite il motore di rendering di Aspose.Slides.

## **Scalatura delle dimensioni del diagramma a bolle**
Aspose.Slides for Node.js via Java fornisce supporto per la scalatura delle dimensioni dei diagrammi a bolle. In Aspose.Slides for Node.js via Java [**ChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ChartSeries#getBubbleSizeScale--) , [**ChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ChartSeriesGroup#getBubbleSizeScale--) e [**ChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ChartSeriesGroup#setBubbleSizeScale-int-) sono stati aggiunti. Di seguito è riportato un esempio. 

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 100, 100, 400, 300);
    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeScale(150);
    pres.save("Result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Rappresentare i dati come dimensioni del diagramma a bolle**
Metodi [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ChartSeriesGroup#setBubbleSizeRepresentation-int-) e [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ChartSeriesGroup#getBubbleSizeRepresentation--) sono stati aggiunti a [ChartSeries](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ChartSeries), [ChartSeriesGroup](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ChartSeriesGroup) e classi correlate. **BubbleSizeRepresentation** specifica come i valori delle dimensioni delle bolle sono rappresentati nel diagramma a bolle. I valori possibili sono: [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/BubbleSizeRepresentationType#Area) e [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/BubbleSizeRepresentationType#Width). Di conseguenza, l'enumerazione [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/BubbleSizeRepresentationType) è stata aggiunta per specificare i possibili modi di rappresentare i dati come dimensioni del diagramma a bolle. Il codice di esempio è fornito di seguito.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 600, 400, true);
    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeRepresentation(aspose.slides.BubbleSizeRepresentationType.Width);
    pres.save("Presentation_BubbleSizeRepresentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**È supportato un "diagramma a bolle con effetto 3-D" e in che cosa differisce da uno normale?**

Sì. Esiste un tipo di diagramma separato, "Bubble with 3-D". Applica lo stile 3-D alle bolle ma non aggiunge un asse aggiuntivo; i dati rimangono X‑Y‑S (dimensione). Il tipo è disponibile nell'enumerazione [chart type](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/charttype/) .

**Esiste un limite al numero di serie e punti in un diagramma a bolle?**

Non c'è un limite rigido a livello di API; le restrizioni sono determinate dalle prestazioni e dalla versione di PowerPoint di destinazione. Si consiglia di mantenere il numero di punti ragionevole per leggibilità e velocità di rendering.

**Come influisce l'esportazione sull'aspetto di un diagramma a bolle (PDF, immagini)?**

L'esportazione nei formati supportati preserva l'aspetto del diagramma; il rendering è eseguito dal motore Aspose.Slides. Per i formati raster/vector, si applicano le regole generali di rendering dei grafici (risoluzione, anti-aliasing), quindi scegliere una DPI sufficiente per la stampa.