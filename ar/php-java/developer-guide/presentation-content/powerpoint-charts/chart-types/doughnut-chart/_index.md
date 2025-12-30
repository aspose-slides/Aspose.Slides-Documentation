---
title: تخصيص مخططات الدونات في العروض التقديمية باستخدام PHP
linktitle: مخطط الدونات
type: docs
weight: 30
url: /ar/php-java/doughnut-chart/
keywords:
- مخطط دونات
- الفجوة المركزية
- حجم الفتحة
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "اكتشف كيفية إنشاء وتخصيص مخططات الدونات في Aspose.Slides للـ PHP عبر Java، مع دعم صيغ PowerPoint للعروض التقديمية الديناميكية."
---

## **تحديد الفجوة المركزية في مخطط الدونات**
{{% alert color="primary" %}} 
أصبح Aspose.Slides for PHP عبر Java يدعم الآن تحديد حجم الفتحة في مخطط الدونات. في هذا الموضوع، سنرى من خلال مثال كيفية تحديد حجم الفتحة في مخطط الدونات.
{{% /alert %}} 

لتحديد حجم الفتحة في مخطط الدونات، يرجى اتباع الخطوات أدناه:

1. إنشاء كائن [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. إضافة مخطط دونات إلى الشريحة.
1. تحديد حجم الفتحة في مخطط الدونات.
1. حفظ العرض التقديمي إلى القرص.

في المثال المذكور أدناه، قمنا بتعيين حجم الفتحة في مخطط الدونات.
```php
  # إنشاء كائن من فئة Presentation
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Doughnut, 50, 50, 400, 400);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setDoughnutHoleSize(90);
    # احفظ العرض التقديمي إلى القرص
    $pres->save("DoughnutHoleSize_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **الأسئلة الشائعة**

**هل يمكنني إنشاء دونات متعددة المستويات مع حلقات متعددة؟**

نعم. أضف عدة سلاسل إلى مخطط دونات واحد—كل سلسلة تصبح حلقة منفصلة. يتم تحديد ترتيب الحلقة بناءً على ترتيب السلاسل في المجموعة.

**هل يتم دعم دونات "منفجرة" (شرائح مفصولة)؟**

نعم. هناك نوع مخطط [chart type](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) Donut المتفجر وخصية الانفجار على نقاط البيانات؛ يمكنك فصل الشرائح الفردية.

**كيف يمكنني الحصول على صورة لمخطط الدونات (PNG/SVG) لتقرير؟**

المخطط هو شكل؛ يمكنك تصييره إلى [raster image](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) أو تصدير المخطط إلى [SVG image](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#writeAsSvg).