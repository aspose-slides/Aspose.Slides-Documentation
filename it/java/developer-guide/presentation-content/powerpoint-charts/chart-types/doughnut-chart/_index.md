---
title: Personalizza i grafici a ciambella nelle presentazioni usando Java
linktitle: Grafico a ciambella
type: docs
weight: 30
url: /it/java/doughnut-chart/
keywords:
- grafico a ciambella
- spazio centrale
- dimensione del foro
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Scopri come creare e personalizzare i grafici a ciambella in Aspose.Slides per Java, con supporto ai formati PowerPoint per presentazioni dinamiche."
---
## **Panoramica**

Questo articolo mostra come utilizzare un grafico a ciambella in Aspose.Slides aggiungendo il grafico a una diapositiva, impostando la dimensione del foro centrale e salvando la presentazione. Si concentra sul metodo `setDoughnutHoleSize` e dimostra i passaggi base necessari per personalizzare questo tipo di grafico nel codice.

Include anche una breve FAQ che copre scenari correlati ai grafici a ciambella, come l'uso di più serie per creare più anelli, lavorare con grafici a ciambella esplosi e esportare un grafico come immagine raster o SVG.

## **Specificare lo spazio centrale in un grafico a ciambella**
{{% alert color="info" %}} 

Aspose.Slides per Java ora supporta la specifica della dimensione del foro in un grafico a ciambella. In questo argomento, vedremo con un esempio come specificare la dimensione del foro in un grafico a ciambella.

{{% /alert %}} 

Per specificare la dimensione del foro in un grafico a ciambella, seguire i passaggi seguenti:

1. Istanziare l'oggetto [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation) .
1. Aggiungere un grafico a ciambella alla diapositiva.
1. Specificare la dimensione del foro in un grafico a ciambella.
1. Scrivere la presentazione su disco.

Nell'esempio mostrato di seguito, abbiamo impostato la dimensione del foro in un grafico a ciambella.

```java
import com.aspose.slides.*;

// Crea un'istanza della classe Presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);
    
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);

    // Scrivi la presentazione su disco
    pres.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

### Posso creare una ciambella a più livelli con più anelli?

Sì. Aggiungi più serie a un unico grafico a ciambella—ogni serie diventa un anello separato. L'ordine degli anelli è determinato dall'ordine delle serie nella collezione.

### È supportata una ciambella "esplosa" (fette separate)?

Sì. Esiste un tipo di grafico Exploded Doughnut [chart type](https://reference.aspose.com/slides/it/java/com.aspose.slides/charttype/) e una proprietà di esplosione sui punti dati; è possibile separare singole fette.

### Come posso ottenere un'immagine di un grafico a ciambella (PNG/SVG) per un report?

Un grafico è una forma; è possibile renderizzarlo in un [raster image](https://reference.aspose.com/slides/it/java/com.aspose.slides/shape/#getImage-int-float-float-) o esportare il grafico in un [SVG image](https://reference.aspose.com/slides/it/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).