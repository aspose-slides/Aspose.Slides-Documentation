---
title: API publique et changements incompatibles avec les versions antérieures dans Aspose.Slides pour Java 16.1.0
linktitle: Aspose.Slides pour Java 16.1.0
type: docs
weight: 200
url: /fr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/
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
description: "Passez en revue les mises à jour de l'API publique et les changements incompatibles dans Aspose.Slides pour Java afin de migrer en douceur vos solutions de présentation PowerPoint PPT, PPTX et ODP."
---
{{% alert color="info" %}} 

Cette page répertorie toutes les [ajoutées](/slides/fr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/) ou [supprimées](/slides/fr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/) classes, méthodes, propriétés, etc., ainsi que les autres changements introduits avec l'API Aspose.Slides for Java 16.1.0.
{{% /alert %}} 
## **Modifications de l'API publique**


#### **Les méthodes getRotationAngle() et setRotationAngle() ont été ajoutées aux interfaces IChartTextBlockFormat et ITextFrameFormat**
Les méthodes getRotationAngle() et setRotationAngle() ont été ajoutées aux interfaces com.aspose.slides.IChartTextBlockFormat et com.aspose.slides.ITextFrameFormat. Elles permettent d'accéder à la rotation personnalisée appliquée au texte à l'intérieur de la zone de délimitation.

``` java
import com.aspose.slides.*;




Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);

IChartSeries series = chart.getChartData().getSeries().get_Item(0);

series.getLabels().getDefaultDataLabelFormat().setShowValue (true);

series.getLabels().getDefaultDataLabelFormat().getTextFormat ().getTextBlockFormat().setRotationAngle(65);

chart.setTitle(true);

chart.getChartTitle().addTextFrameForOverriding("Custom title").getTextFrameFormat().setRotationAngle(-30);

pres.save("out.pptx", SaveFormat.Pptx);


```