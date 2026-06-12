---
title: API Pubbliche e Modifiche Incompatibili con Versioni Precedenti in Aspose.Slides per Java 16.1.0
linktitle: Aspose.Slides per Java 16.1.0
type: docs
weight: 200
url: /it/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/
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
description: "Esamina gli aggiornamenti dell'API pubblica e le modifiche breaking in Aspose.Slides per Java per migrare agevolmente le tue soluzioni di presentazione PowerPoint PPT, PPTX e ODP."
---
{{% alert color="primary" %}}
Questa pagina elenca tutte le classi, i metodi, le proprietà [added](/slides/it/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/) o [removed](/slides/it/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/) e così via, nonché le altre modifiche introdotte con l'API Aspose.Slides per Java 16.1.0.
{{% /alert %}}
## **Modifiche all'API Pubblica**

#### **I metodi getRotationAngle() e setRotationAngle() sono stati aggiunti alle interfacce IChartTextBlockFormat e ITextFrameFormat**
I metodi getRotationAngle() e setRotationAngle() sono stati aggiunti alle interfacce com.aspose.slides.IChartTextBlockFormat e com.aspose.slides.ITextFrameFormat.
Essi consentono l'accesso alla rotazione personalizzata applicata al testo all'interno del riquadro di delimitazione.

``` java



Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);

IChartSeries series = chart.getChartData().getSeries().get_Item(0);

series.getLabels().getDefaultDataLabelFormat().setShowValue (true);

series.getLabels().getDefaultDataLabelFormat().getTextFormat ().getTextBlockFormat().setRotationAngle(65);

chart.setTitle(true);

chart.getChartTitle().addTextFrameForOverriding("Custom title").getTextFrameFormat().setRotationAngle(-30);

pres.save("out.pptx", SaveFormat.Pptx);


```