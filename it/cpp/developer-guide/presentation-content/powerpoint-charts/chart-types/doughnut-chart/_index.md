---
title: Personalizza i grafici a ciambella nelle presentazioni usando C++
linktitle: Grafico a ciambella
type: docs
weight: 30
url: /it/cpp/doughnut-chart/
keywords:
- grafico a ciambella
- spazio centrale
- dimensione del foro
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Scopri come creare e personalizzare i grafici a ciambella in Aspose.Slides per C++, supportando i formati PowerPoint per presentazioni dinamiche."
---
## **Panoramica**

Questo articolo mostra come lavorare con un grafico a ciambella in Aspose.Slides aggiungendo il grafico a una diapositiva, impostando la dimensione del foro centrale e salvando la presentazione. Si concentra sul metodo `set_DoughnutHoleSize` e dimostra i passaggi di base necessari per personalizzare questo tipo di grafico nel codice.

## **Specificare lo Spazio Centrale in un Grafico a Ciambella**
Per specificare la dimensione del foro in un grafico a ciambella, seguire i passaggi seguenti:

- Istanziare la classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
- Aggiungere un grafico a ciambella alla diapositiva.
- Specificare la dimensione del foro in un grafico a ciambella.
- Scrivere la presentazione su disco.

Nell'esempio riportato di seguito, abbiamo impostato la dimensione del foro in un grafico a ciambella.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DoughnutChartHole-DoughnutChartHole.cpp" >}}

## **Domande frequenti**

**Posso creare una ciambella a più livelli con più anelli?**

Sì. Aggiungere più serie a un unico grafico a ciambella—ogni serie diventa un anello separato. L'ordine degli anelli è determinato dall'ordine delle serie nella collezione.

**È supportata una ciambella "esplosa" (fette separate)?**

Sì. Esiste un tipo di grafico Exploded Doughnut [chart type](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/charttype/) e una proprietà di esplosione sui punti dati; è possibile separare fette individuali.

**Come posso ottenere un'immagine di un grafico a ciambella (PNG/SVG) per un report?**

Un grafico è una forma; è possibile renderizzarlo in un [raster image](https://reference.aspose.com/slides/it/cpp/aspose.slides/shape/getimage/) o esportare il grafico in un [SVG image](https://reference.aspose.com/slides/it/cpp/aspose.slides/shape/writeassvg/).