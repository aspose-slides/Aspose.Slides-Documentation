---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides لـ PHP عبر Java 15.8.0
type: docs
weight: 160
url: /ar/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/
---

{{% alert color="primary" %}} 

تسرد هذه الصفحة جميع [الإضافات](/slides/ar/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) أو [الإزالات](/slides/ar/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) من الفئات، والأساليب، والخصائص وما إلى ذلك، والتغييرات الأخرى التي تم إدخالها مع واجهة برمجة التطبيقات Aspose.Slides لـ PHP عبر Java 15.8.0.

{{% /alert %}} 
## **تغييرات واجهة برمجة التطبيقات العامة**
#### **تم إضافة الأساليب getDoughnutHoleSize() و setDoughnutHoleSize(byte) إلى IChartSeries و ChartSeries**
يحدد حجم الفتحة في مخطط دائري.

```php
  $pres = new Presentation();
  $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Doughnut, 50, 50, 400, 400);
  $chart->getChartData()->getSeriesGroups()->get_Item(0)->setDoughnutHoleSize(90);
  $pres->save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat::Pptx);

```