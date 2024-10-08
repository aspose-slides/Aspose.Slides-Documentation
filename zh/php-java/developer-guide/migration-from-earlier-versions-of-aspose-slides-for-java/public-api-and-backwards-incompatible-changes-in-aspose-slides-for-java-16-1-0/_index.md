---
title: Aspose.Slides for PHP via Java 16.1.0 的公共 API 和不向后兼容的更改
type: docs
weight: 200
url: /php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/
---

{{% alert color="primary" %}} 

本页面列出了 Aspose.Slides for PHP via Java 16.1.0 API 引入的所有 [新增](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/) 或 [删除](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/) 的类、方法、属性等以及其他更改。

{{% /alert %}} 
## **公共 API 更改**


#### **在 IChartTextBlockFormat 和 ITextFrameFormat 接口中添加了方法 getRotationAngle() 和 setRotationAngle()**
在接口 com.aspose.slides.IChartTextBlockFormat 和 com.aspose.slides.ITextFrameFormat 中添加了方法 getRotationAngle() 和 setRotationAngle()。
它们提供了对应用于边界框内文本的自定义旋转的访问。

```php
  $pres = new Presentation();
  $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
  $series = $chart->getChartData()->getSeries()->get_Item(0);
  $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
  $series->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getTextBlockFormat()->setRotationAngle(65);
  $chart->setTitle(true);
  $chart->getChartTitle()->addTextFrameForOverriding("自定义标题")->getTextFrameFormat()->setRotationAngle(-30);
  $pres->save("out.pptx", SaveFormat::Pptx);

```