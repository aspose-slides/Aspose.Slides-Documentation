---
title: Personalizza i grafici a ciambella nelle presentazioni usando JavaScript
linktitle: Grafico a ciambella
type: docs
weight: 30
url: /it/nodejs-java/doughnut-chart/
keywords:
- grafico a ciambella
- spazio centrale
- dimensione foro
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Scopri come creare e personalizzare i grafici a ciambella con JavaScript e Aspose.Slides per Node.js, supportando i formati PowerPoint per presentazioni dinamiche."
---
## **Panoramica**

Questo articolo mostra come lavorare con un grafico a ciambella in Aspose.Slides aggiungendo il grafico a una diapositiva, impostando la dimensione del foro centrale e salvando la presentazione. Si concentra sul metodo `setDoughnutHoleSize` e dimostra i passaggi di base necessari per personalizzare questo tipo di grafico nel codice.

Include anche una breve FAQ che copre scenari correlati ai grafici a ciambella, come l'uso di più serie per creare più anelli, il lavoro con grafici a ciambella esplosi e l'esportazione di un grafico come immagine raster o SVG.

## **Modifica lo spazio centrale nel grafico a ciambella**

Per specificare la dimensione del foro in un grafico a ciambella, segui i passaggi seguenti:

1. Istanzia l'oggetto [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation).
1. Aggiungi un grafico a ciambella sulla diapositiva.
1. Specifica la dimensione del foro in un grafico a ciambella.
1. Scrivi la presentazione su disco.

Nell'esempio fornito di seguito, abbiamo impostato la dimensione del foro in un grafico a ciambella.

```javascript
// Crea un'istanza della classe Presentation
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Doughnut, 50, 50, 400, 400);
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize(90);
    // Scrivi la presentazione su disco
    pres.save("DoughnutHoleSize_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Posso creare una ciambella a più livelli con più anelli?**

Sì. Aggiungi più serie a un singolo grafico a ciambella—ogni serie diventa un anello separato. L'ordine degli anelli è determinato dall'ordine delle serie nella collezione.

**È supportata una ciambella "esplosa" (fette separate)?**

Sì. Esiste un tipo di grafico Exploded Doughnut[chart type](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/charttype/) e una proprietà di esplosione sui punti dati; puoi separare le singole fette.

**Come posso ottenere un'immagine di un grafico a ciambella (PNG/SVG) per un report?**

Un grafico è una forma; puoi renderizzarlo in un [immagine raster](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/#getImage) o esportare il grafico in un [immagine SVG](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/writeassvg/).