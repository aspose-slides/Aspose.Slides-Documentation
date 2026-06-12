---
title: Esporta i grafici della presentazione in JavaScript
linktitle: Esporta grafico
type: docs
weight: 90
url: /it/nodejs-java/export-chart/
keywords:
- grafico
- grafico in immagine
- grafico come immagine
- estrai immagine del grafico
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Scopri come esportare i grafici delle presentazioni con Aspose.Slides per Node.js via Java, supportando i formati PPT e PPTX, e semplifica la generazione di report in qualsiasi flusso di lavoro."
---
## **Panoramica**

Aspose.Slides consente di esportare un grafico da una presentazione come immagine. Questo articolo mostra come ottenere un'immagine da un grafico e salvarla, utile quando è necessario riutilizzare i visual del grafico al di fuori di una presentazione PowerPoint.

## **Ottenere immagine del grafico**
Aspose.Slides per Node.js via Java fornisce il supporto per estrarre l'immagine di un grafico specifico. Di seguito è riportato un esempio.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var slideImage = chart.getImage();
    try {
        slideImage.save("image.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Posso esportare un grafico come vettoriale (SVG) anziché come immagine raster?**

Sì. Un grafico è una forma e il suo contenuto può essere salvato in SVG utilizzando il [metodo di salvataggio shape-to-SVG](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/writeassvg/).

**Come posso impostare la dimensione esatta del grafico esportato in pixel?**

Utilizza le sovraccarichi di rendering immagine che consentono di specificare dimensione o scala—la libreria supporta il rendering di oggetti con dimensioni/scala specificate.

**Cosa devo fare se i font nelle etichette e nella legenda appaiono errati dopo l'esportazione?**

[Carica i font richiesti](/slides/it/nodejs-java/custom-font/) tramite [FontsLoader](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fontsloader/) in modo che il rendering del grafico conservi metriche e aspetto del testo.

**L'esportazione rispetta il tema, gli stili e gli effetti di PowerPoint?**

Sì. Il renderer di Aspose.Slides segue la formattazione della presentazione (temi, stili, riempimenti, effetti), quindi l'aspetto del grafico viene preservato.

**Dove posso trovare le capacità di rendering/esportazione disponibili oltre le immagini dei grafici?**

Vedi l'[API](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/)/[documentazione](/slides/it/nodejs-java/convert-powerpoint/) per le destinazioni di output ([PDF](/slides/it/nodejs-java/convert-powerpoint-to-pdf/), [SVG](/slides/it/nodejs-java/render-a-slide-as-an-svg-image/), [XPS](/slides/it/nodejs-java/convert-powerpoint-to-xps/), [HTML](/slides/it/nodejs-java/convert-powerpoint-to-html/), ecc.) e le relative opzioni di rendering.