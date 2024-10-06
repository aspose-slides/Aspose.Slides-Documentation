---
title: API public et changements incompatibles avec les versions précédentes dans Aspose.Slides pour PHP via Java 16.1.0
type: docs
weight: 200
url: /php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/
---

{{% alert color="primary" %}} 

Cette page liste toutes les classes, méthodes, propriétés, etc. [ajoutées](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/) ou [supprimées](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/), ainsi que d'autres changements introduits avec l'API Aspose.Slides pour PHP via Java 16.1.0.

{{% /alert %}} 
## **Changements de l'API publique**


#### **Les méthodes getRotationAngle() et setRotationAngle() ont été ajoutées aux interfaces IChartTextBlockFormat et ITextFrameFormat**
Les méthodes getRotationAngle() et setRotationAngle() ont été ajoutées aux interfaces com.aspose.slides.IChartTextBlockFormat et com.aspose.slides.ITextFrameFormat.
Elles fournissent un accès à la rotation personnalisée qui est appliquée au texte dans la boîte de délimitation.

```php
  $pres = new Presentation();
  $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
  $series = $chart->getChartData()->getSeries()->get_Item(0);
  $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
  $series->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getTextBlockFormat()->setRotationAngle(65);
  $chart->setTitle(true);
  $chart->getChartTitle()->addTextFrameForOverriding("Titre personnalisé")->getTextFrameFormat()->setRotationAngle(-30);
  $pres->save("out.pptx", SaveFormat::Pptx);

```