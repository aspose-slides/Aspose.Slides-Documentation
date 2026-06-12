---
title: API pubbliche e modifiche incompatibili retroattive in Aspose.Slides per Java 15.8.0
linktitle: Aspose.Slides per Java 15.8.0
type: docs
weight: 160
url: /it/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/
keywords:
- migrazione
- codice legacy
- codice moderno
- approccio legacy
- approccio moderno
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Esamina gli aggiornamenti dell'API pubblica e le modifiche incompatibili in Aspose.Slides per Java per migrare agevolmente le tue soluzioni di presentazione PowerPoint PPT, PPTX e ODP."
---
{{% alert color="primary" %}} 

Questa pagina elenca tutte le classi, i metodi, le proprietà e così via [aggiunti](/slides/it/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) o [rimossi](/slides/it/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/), e le altre modifiche introdotte con l'API Aspose.Slides per Java 15.8.0.

{{% /alert %}} 
## **Modifiche dell'API pubblica**
#### **I metodi getDoughnutHoleSize(), setDoughnutHoleSize(byte) sono stati aggiunti a IChartSeries e ChartSeries**
Specifica la dimensione del foro in un grafico a ciambella.

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);

chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);                   

pres.save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

```