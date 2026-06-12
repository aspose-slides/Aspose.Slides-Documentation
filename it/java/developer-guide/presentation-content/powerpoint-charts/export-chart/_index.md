---
title: Esporta i grafici delle presentazioni in Java
linktitle: Esporta grafico
type: docs
weight: 90
url: /it/java/export-chart/
keywords:
- grafico
- grafico in immagine
- grafico come immagine
- estrarre immagine del grafico
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Scopri come esportare i grafici delle presentazioni con Aspose.Slides per Java, supportando i formati PPT e PPTX, e semplifica la generazione di report in qualsiasi flusso di lavoro."
---
## **Panoramica**

Aspose.Slides consente di esportare un grafico da una presentazione come immagine. Questo articolo mostra come ottenere un’immagine da un grafico e salvarla, utile quando è necessario riutilizzare i visual del grafico al di fuori di una presentazione PowerPoint.

Oltre al flusso di lavoro di esportazione di base dell’immagine, l’articolo affronta anche le domande comuni relative all’esportazione, includendo il salvataggio del contenuto del grafico in SVG, il controllo della dimensione dell’output tramite opzioni di rendering, il caricamento dei font per preservare l’aspetto di etichette e legenda, e il mantenimento della formattazione originale della presentazione come temi, stili, riempimenti ed effetti durante il rendering.

## **Ottieni un’immagine del grafico**
Aspose.Slides per Java fornisce il supporto per estrarre l’immagine di un grafico specifico. Di seguito è mostrato un esempio.

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

**Posso esportare un grafico come vettore (SVG) invece di un’immagine raster?**

Sì. Un grafico è una forma e il suo contenuto può essere salvato in SVG usando il [metodo di salvataggio shape-to-SVG](https://reference.aspose.com/slides/it/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).

**Come posso impostare la dimensione esatta del grafico esportato in pixel?**

Utilizza le sovrapposizioni di rendering dell’immagine che consentono di specificare dimensioni o scala: la libreria supporta il rendering degli oggetti con dimensioni/scala specificate.

**Cosa devo fare se i font in etichette e legenda appaiono errati dopo l’esportazione?**

[Carica i font richiesti](/slides/it/java/custom-font/) tramite [FontsLoader](https://reference.aspose.com/slides/it/java/com.aspose.slides/fontsloader/) così il rendering del grafico preserva metriche e aspetto del testo.

**L’esportazione rispetta il tema, gli stili e gli effetti di PowerPoint?**

Sì. Il renderer di Aspose.Slides segue la formattazione della presentazione (temi, stili, riempimenti, effetti), quindi l’aspetto del grafico viene preservato.

**Dove posso trovare le capacità di rendering/esportazione disponibili oltre alle immagini dei grafici?**

Consulta l’[API](https://reference.aspose.com/slides/it/java/com.aspose.slides/)/[documentazione](/slides/it/java/convert-powerpoint/) per i target di output ([PDF](/slides/it/java/convert-powerpoint-to-pdf/), [SVG](/slides/it/java/render-a-slide-as-an-svg-image/), [XPS](/slides/it/java/convert-powerpoint-to-xps/), [HTML](/slides/it/java/convert-powerpoint-to-html/), ecc.) e le relative opzioni di rendering.