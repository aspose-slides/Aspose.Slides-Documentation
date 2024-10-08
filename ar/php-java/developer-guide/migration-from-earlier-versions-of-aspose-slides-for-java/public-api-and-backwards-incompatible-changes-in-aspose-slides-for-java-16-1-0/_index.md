---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides لـ PHP عبر Java 16.1.0
type: docs
weight: 200
url: /ar/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/
---

{{% alert color="primary" %}} 

تسرد هذه الصفحة جميع [الفئات المضافة](/slides/ar/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/) أو [المزالة](/slides/ar/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/) والطرق والخصائص وما إلى ذلك، والتغييرات الأخرى التي تم تقديمها مع واجهة برمجة التطبيقات Aspose.Slides لـ PHP عبر Java 16.1.0.

{{% /alert %}} 
## **تغييرات واجهة برمجة التطبيقات العامة**


#### **تمت إضافة الطريقتين getRotationAngle() و setRotationAngle() إلى واجهتي IChartTextBlockFormat و ITextFrameFormat**
تمت إضافة الطريقتين getRotationAngle() و setRotationAngle() إلى واجهات com.aspose.slides.IChartTextBlockFormat و com.aspose.slides.ITextFrameFormat.
تقدمان وصولًا إلى دوران مخصص يتم تطبيقه على النص داخل صندوق التقييد.

```php
  $pres = new Presentation();
  $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
  $series = $chart->getChartData()->getSeries()->get_Item(0);
  $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
  $series->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getTextBlockFormat()->setRotationAngle(65);
  $chart->setTitle(true);
  $chart->getChartTitle()->addTextFrameForOverriding("عنوان مخصص")->getTextFrameFormat()->setRotationAngle(-30);
  $pres->save("out.pptx", SaveFormat::Pptx);

```