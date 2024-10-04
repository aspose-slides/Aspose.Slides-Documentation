---
title: API pública y cambios incompatibles hacia atrás en Aspose.Slides para PHP a través de Java 16.1.0
type: docs
weight: 200
url: /php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/
---

{{% alert color="primary" %}} 

Esta página lista todas las [clases añadidas](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/) o [eliminadas](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/), métodos, propiedades, etc., y otros cambios introducidos con la API de Aspose.Slides para PHP a través de Java 16.1.0.

{{% /alert %}} 
## **Cambios en la API Pública**


#### **Se han añadido los métodos getRotationAngle() y setRotationAngle() a las interfaces IChartTextBlockFormat e ITextFrameFormat**
Se han añadido los métodos getRotationAngle() y setRotationAngle() a las interfaces com.aspose.slides.IChartTextBlockFormat y com.aspose.slides.ITextFrameFormat.
Proporcionan acceso a la rotación personalizada que se aplica al texto dentro del cuadro delimitador.

```php
  $pres = new Presentation();
  $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
  $series = $chart->getChartData()->getSeries()->get_Item(0);
  $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
  $series->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getTextBlockFormat()->setRotationAngle(65);
  $chart->setTitle(true);
  $chart->getChartTitle()->addTextFrameForOverriding("Título personalizado")->getTextFrameFormat()->setRotationAngle(-30);
  $pres->save("out.pptx", SaveFormat::Pptx);

```