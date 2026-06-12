---
title: Personalizza i grafici a bolle nelle presentazioni su Android
linktitle: Grafico a bolle
type: docs
url: /it/androidjava/bubble-chart/
keywords:
- grafico a bolle
- dimensione della bolla
- scalatura della dimensione
- rappresentazione della dimensione
- PowerPoint
- presentazione
- Android
- Java
- Aspose.Slides
description: "Crea e personalizza potenti grafici a bolle in PowerPoint con Aspose.Slides per Android via Java per migliorare facilmente la visualizzazione dei dati."
---
## **Panoramica**

Questo articolo mostra come utilizzare i grafici a bolle in Aspose.Slides. Copre due opzioni di personalizzazione specifiche: la scalatura delle dimensioni delle bolle tramite il metodo `setBubbleSizeScale` e il controllo di come i valori delle dimensioni delle bolle sono rappresentati tramite il metodo `setBubbleSizeRepresentation`.

Gli esempi dimostrano come creare un grafico a bolle, regolare la sua scalatura delle dimensioni e cambiare la rappresentazione delle dimensioni delle bolle per utilizzare la larghezza. L'articolo include anche una breve sezione FAQ che chiarisce il supporto per il tipo di grafico “Bubble with 3-D”, osserva che i limiti pratici dei grafici dipendono dalle prestazioni e dalla versione di PowerPoint di destinazione, e spiega che l'esportazione preserva l'aspetto del grafico tramite il motore di rendering di Aspose.Slides.

## **Scalatura delle dimensioni del grafico a bolle**
Aspose.Slides for Android via Java offre supporto per la scalatura delle dimensioni dei grafici a bolle. In Aspose.Slides for Android via Java [**IChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IChartSeries#getBubbleSizeScale--), [**IChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IChartSeriesGroup#getBubbleSizeScale--) e [**IChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IChartSeriesGroup#setBubbleSizeScale-int-) sono stati aggiunti. Di seguito è riportato un esempio.

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 100, 100, 400, 300);

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeScale(150);

    pres.save("Result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Rappresentare i dati come dimensioni del grafico a bolle**
I metodi [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IChartSeriesGroup#setBubbleSizeRepresentation-int-) e [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IChartSeriesGroup#getBubbleSizeRepresentation--) sono stati aggiunti alle interfacce [IChartSeries](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IChartSeries), [IChartSeriesGroup](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IChartSeriesGroup) e alle classi correlate. **BubbleSizeRepresentation** specifica come i valori delle dimensioni delle bolle sono rappresentati nel grafico a bolle. I valori possibili sono: [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/BubbleSizeRepresentationType#Area) e [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/BubbleSizeRepresentationType#Width). Di conseguenza, l'enumerazione [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/BubbleSizeRepresentationType) è stata aggiunta per specificare i possibili modi di rappresentare i dati come dimensioni del grafico a bolle. Il codice di esempio è mostrato di seguito.

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, true);

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeRepresentation(BubbleSizeRepresentationType.Width);

    pres.save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**È supportato un "grafico a bolle con effetto 3‑D" e in che modo differisce da uno normale?**

Sì. Esiste un tipo di grafico separato, "Bubble with 3-D". Applica uno stile 3‑D alle bolle ma non aggiunge un asse aggiuntivo; i dati rimangono X‑Y‑S (dimensione). Il tipo è disponibile nella classe [chart type](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/charttype/).

**Esiste un limite al numero di serie e punti in un grafico a bolle?**

Non esiste un limite rigido a livello di API; le restrizioni sono determinate dalle prestazioni e dalla versione di PowerPoint di destinazione. Si consiglia di mantenere il numero di punti ragionevole per la leggibilità e la velocità di rendering.

**Come influenzerà l'esportazione l'aspetto di un grafico a bolle (PDF, immagini)?**

L'esportazione nei formati supportati preserva l'aspetto del grafico; il rendering è eseguito dal motore di Aspose.Slides. Per i formati raster/vector, si applicano le regole generali di rendering dei grafici (risoluzione, anti-aliasing), quindi è consigliabile scegliere una DPI sufficiente per la stampa.