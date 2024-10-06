---
title: API Public et Changements Incompatibles avec les Versions Précédentes dans Aspose.Slides pour Java 16.1.0
type: docs
weight: 200
url: /androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/
---

{{% alert color="primary" %}} 

Cette page répertorie toutes les classes, méthodes, propriétés, etc., [ajoutées](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/) ou [supprimées](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/), ainsi que d'autres changements introduits avec l'API Aspose.Slides pour Java 16.1.0.

{{% /alert %}} 
## **Changements de l'API Public**


#### **Les méthodes getRotationAngle() et setRotationAngle() ont été ajoutées aux interfaces IChartTextBlockFormat et ITextFrameFormat**
Les méthodes getRotationAngle() et setRotationAngle() ont été ajoutées aux interfaces com.aspose.slides.IChartTextBlockFormat et com.aspose.slides.ITextFrameFormat.
Elles permettent d'accéder à la rotation personnalisée appliquée au texte dans la zone délimitée.

``` java



Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);

IChartSeries series = chart.getChartData().getSeries().get_Item(0);

series.getLabels().getDefaultDataLabelFormat().setShowValue (true);

series.getLabels().getDefaultDataLabelFormat().getTextFormat ().getTextBlockFormat().setRotationAngle(65);

chart.setTitle(true);

chart.getChartTitle().addTextFrameForOverriding("Titre personnalisé").getTextFrameFormat().setRotationAngle(-30);

pres.save("out.pptx", SaveFormat.Pptx);


```