---
title: API publique et modifications incompatibles rétroactives dans Aspose.Slides for Java 15.8.0
linktitle: Aspose.Slides for Java 15.8.0
type: docs
weight: 160
url: /fr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/
keywords:
- migration
- code hérité
- code moderne
- approche héritée
- approche moderne
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Passez en revue les mises à jour de l'API publique et les changements incompatibles dans Aspose.Slides for Java afin de migrer en douceur vos solutions de présentations PowerPoint PPT, PPTX et ODP."
---
{{% alert color="info" %}} 

Cette page répertorie tous les [ajoutés](/slides/fr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) ou [supprimés](/slides/fr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) classes, méthodes, propriétés, etc., ainsi que les autres modifications introduites avec l'API Aspose.Slides for Java 15.8.0.

{{% /alert %}} 
## **Modifications de l'API publique**
#### **Les méthodes getDoughnutHoleSize(), setDoughnutHoleSize(byte) ont été ajoutées à IChartSeries et ChartSeries**
Spécifie la taille du trou dans un diagramme en anneau.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);

chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);                   

pres.save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

```