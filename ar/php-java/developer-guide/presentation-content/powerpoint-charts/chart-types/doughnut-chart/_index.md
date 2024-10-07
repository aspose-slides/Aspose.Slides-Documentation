---
title: مخطط الدونات
type: docs
weight: 30
url: /php-java/doughnut-chart/
---

## **تغيير الفجوة المركزية في مخطط الدونات**
{{% alert color="primary" %}} 

Aspose.Slides لـ PHP عبر Java تدعم الآن تحديد حجم الفتحة في مخطط الدونات. في هذا الموضوع، سنرى من خلال مثال كيفية تحديد حجم الفتحة في مخطط الدونات.

{{% /alert %}} 

لتحديد حجم الفتحة في مخطط الدونات، يرجى اتباع الخطوات أدناه:

1. أنشئ كائن [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. أضف مخطط الدونات على الشريحة.
1. حدد حجم الفتحة في مخطط الدونات.
1. اكتب العرض التقديمي إلى القرص.

في المثال المقدم أدناه، قمنا بتحديد حجم الفتحة في مخطط الدونات.

```php
  # إنشاء مثيل من فئة Presentation
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Doughnut, 50, 50, 400, 400);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setDoughnutHoleSize(90);
    # كتابة العرض التقديمي إلى القرص
    $pres->save("DoughnutHoleSize_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```