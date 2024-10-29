---
title: Öffentliches API und rückwärts inkompatible Änderungen in Aspose.Slides für PHP via Java 16.1.0
type: docs
weight: 200
url: /de/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/
---

{{% alert color="primary" %}} 

Diese Seite listet alle [hinzugefügten](/slides/de/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/) oder [entfernten](/slides/de/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/) Klassen, Methoden, Eigenschaften usw. und andere Änderungen auf, die mit der Aspose.Slides für PHP via Java 16.1.0 API eingeführt wurden.

{{% /alert %}} 
## **Öffentliche API-Änderungen**


#### **Methoden getRotationAngle() und setRotationAngle() wurden zu den Schnittstellen IChartTextBlockFormat und ITextFrameFormat hinzugefügt**
Die Methoden getRotationAngle() und setRotationAngle() wurden zu den Schnittstellen com.aspose.slides.IChartTextBlockFormat und com.aspose.slides.ITextFrameFormat hinzugefügt.
Sie ermöglichen den Zugriff auf die benutzerdefinierte Drehung, die auf den Text innerhalb des Begrenzungsrahmens angewendet wird.

```php
  $pres = new Presentation();
  $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
  $series = $chart->getChartData()->getSeries()->get_Item(0);
  $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
  $series->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getTextBlockFormat()->setRotationAngle(65);
  $chart->setTitle(true);
  $chart->getChartTitle()->addTextFrameForOverriding("Benutzerdefinierter Titel")->getTextFrameFormat()->setRotationAngle(-30);
  $pres->save("out.pptx", SaveFormat::Pptx);

```