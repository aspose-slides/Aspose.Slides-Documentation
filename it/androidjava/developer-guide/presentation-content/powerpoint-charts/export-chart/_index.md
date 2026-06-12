---
title: Esporta grafici di presentazione su Android
linktitle: Esporta grafico
type: docs
weight: 90
url: /it/androidjava/export-chart/
keywords:
- grafico
- grafico in immagine
- grafico come immagine
- estrai immagine del grafico
- PowerPoint
- presentazione
- Android
- Java
- Aspose.Slides
description: "Scopri come esportare i grafici delle presentazioni con Aspose.Slides per Android via Java, supportando i formati PPT e PPTX, e semplifica la generazione di report in qualsiasi flusso di lavoro."
---
## **Panoramica**

Aspose.Slides consente di esportare un grafico da una presentazione come immagine. Questo articolo mostra come ottenere un’immagine da un grafico e salvarla, utile quando è necessario riutilizzare i visual del grafico al di fuori di una presentazione PowerPoint.

Oltre al flusso di lavoro base per l’esportazione di immagini, l’articolo affronta anche le domande più comuni relative all’esportazione, inclusa la salvezza del contenuto del grafico in SVG, il controllo delle dimensioni di output tramite opzioni di rendering, il caricamento dei caratteri per preservare l’aspetto di etichette e legende, e il mantenimento della formattazione originale della presentazione, come temi, stili, riempimenti ed effetti durante il rendering.

## **Ottenere un’immagine del grafico**
Aspose.Slides per Android via Java fornisce il supporto per estrarre l’immagine di un grafico specifico. Di seguito è riportato un esempio.

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    IImage slideImage = chart.getImage();

    try {
          slideImage.save("image.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Posso esportare un grafico come vettoriale (SVG) invece che come immagine raster?**

Sì. Un grafico è una forma e il suo contenuto può essere salvato in SVG utilizzando il [metodo di salvataggio shape-to-SVG](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).

**Come posso impostare la dimensione esatta del grafico esportato in pixel?**

Utilizza le overload di rendering dell’immagine che consentono di specificare dimensioni o scala: la libreria supporta il rendering di oggetti con dimensioni/scala specificate.

** Cosa devo fare se i caratteri nelle etichette e nella legenda appaiono errati dopo l’esportazione?**

[Carica i caratteri richiesti](/slides/it/androidjava/custom-font/) tramite [FontsLoader](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/fontsloader/) in modo che il rendering del grafico preservi metriche e aspetto del testo.

**L’esportazione rispetta il tema, gli stili e gli effetti di PowerPoint?**

Sì. Il renderer di Aspose.Slides segue la formattazione della presentazione (temi, stili, riempimenti, effetti), così l’aspetto del grafico viene preservato.

**Dove posso trovare le capacità di rendering/esportazione disponibili oltre alle immagini dei grafici?**

Consulta l’[API](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/)/[documentazione](/slides/it/androidjava/convert-powerpoint/) per i target di output ([PDF](/slides/it/androidjava/convert-powerpoint-to-pdf/), [SVG](/slides/it/androidjava/render-a-slide-as-an-svg-image/), [XPS](/slides/it/androidjava/convert-powerpoint-to-xps/), [HTML](/slides/it/androidjava/convert-powerpoint-to-html/), ecc.) e le relative opzioni di rendering.