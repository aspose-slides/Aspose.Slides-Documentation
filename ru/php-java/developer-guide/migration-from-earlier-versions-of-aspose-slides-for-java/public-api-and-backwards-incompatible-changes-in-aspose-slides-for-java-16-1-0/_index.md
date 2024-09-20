---
title: Общественный API и несовместимые изменения в Aspose.Slides для PHP через Java 16.1.0
type: docs
weight: 200
url: /php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/
---

{{% alert color="primary" %}} 

Эта страница содержит все [добавленные](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/) или [удаленные](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/) классы, методы, свойства и так далее, а также другие изменения, введенные в API Aspose.Slides для PHP через Java 16.1.0.

{{% /alert %}} 
## **Изменения в общественном API**


#### **Методы getRotationAngle() и setRotationAngle() были добавлены в интерфейсы IChartTextBlockFormat и ITextFrameFormat**
Методы getRotationAngle() и setRotationAngle() были добавлены в интерфейсы com.aspose.slides.IChartTextBlockFormat и com.aspose.slides.ITextFrameFormat.
Они предоставляют доступ к пользовательской ротации, которая применяется к тексту в пределах ограничивающего прямоугольника.

```php
  $pres = new Presentation();
  $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
  $series = $chart->getChartData()->getSeries()->get_Item(0);
  $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
  $series->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getTextBlockFormat()->setRotationAngle(65);
  $chart->setTitle(true);
  $chart->getChartTitle()->addTextFrameForOverriding("Пользовательский заголовок")->getTextFrameFormat()->setRotationAngle(-30);
  $pres->save("out.pptx", SaveFormat::Pptx);

```