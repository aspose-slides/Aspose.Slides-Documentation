---
title: تخصيص نقاط البيانات في مخططات Treemap و Sunburst باستخدام PHP
linktitle: نقاط البيانات في مخططات Treemap و Sunburst
type: docs
url: /ar/php-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- مخطط Treemap
- مخطط Sunburst
- نقطة بيانات
- لون التسمية
- لون الفرع
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تعلم كيفية إدارة نقاط البيانات في مخططات Treemap و Sunburst باستخدام Aspose.Slides للـ PHP عبر Java، ومتوافق مع صيغ PowerPoint."
---


من بين الأنواع الأخرى لمخططات PowerPoint، هناك نوعان «هرميان» – **Treemap** و **Sunburst** (المعروفة أيضًا باسم Sunburst Graph أو Sunburst Diagram أو Radial Chart أو Radial Graph أو Multi Level Pie Chart). تُظهر هذه المخططات بيانات هرمية منظمة كشجرة – من الأوراق إلى أعلى الفرع. تُعرّف الأوراق بنقاط بيانات السلسلة، وكل مستوى تجميع متداخل لاحق يُعرّف بالفئة المقابلة. يتيح Aspose.Slides for PHP عبر Java تنسيق نقاط البيانات لمخطط Sunburst وTreemap.

إليك مخطط Sunburst، حيث تُعرّف البيانات في عمود Series1 عقد الأوراق، بينما تُعرّف الأعمدة الأخرى نقاط البيانات الهرمية:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

لنبدأ بإضافة مخطط Sunburst جديد إلى العرض التقديمي:
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Sunburst, 100, 100, 450, 400);
    # ...
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert color="primary" title="انظر أيضًا" %}} 
- [**Create or Update PowerPoint Presentation Charts in PHP**](/slides/ar/php-java/create-chart/)
{{% /alert %}}

إذا كان هناك حاجة لتنسيق نقاط بيانات المخطط، يجب استخدام ما يلي:

[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointlevelsmanager/)، [**ChartDataPointLevel**](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointlevel/) classes and [**ChartDataPoint::getDataPointLevels**](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/#getDataPointLevels) method provide access to format data points of Treemap and Sunburst charts. [**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointlevelsmanager/) is used for accessing multi-level categories - it represents the container of [**ChartDataPointLevel**](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointlevel/) objects. Basically it is a wrapper for [**ChartCategoryLevelsManager**](https://reference.aspose.com/slides/php-java/aspose.slides/chartcategorylevelsmanager/) with the properties added specific for data points. [**ChartDataPointLevel**](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointlevel/) class has two methods: [**getFormat**](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointlevel/#getFormat) and [**getDataLabel**](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointlevel/#getLabel) which provide access to corresponding settings.

## **إظهار قيمة نقطة البيانات**
إظهار قيمة نقطة البيانات "Leaf 4":
```php
  $dataPoints = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints();
  $dataPoints->get_Item(3)->getDataPointLevels()->get_Item(0)->getLabel()->getDataLabelFormat()->setShowValue(true);

```


![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **تعيين تسمية ولون نقطة البيانات**
عيّن تسمية البيانات "Branch 1" لعرض اسم السلسلة ("Series1") بدلاً من اسم الفئة. ثم عيّن لون النص إلى الأصفر:
```php
  $branch1Label = $dataPoints->get_Item(0)->getDataPointLevels()->get_Item(0)->getLabel();
  $branch1Label->getDataLabelFormat()->setShowCategoryName(false);
  $branch1Label->getDataLabelFormat()->setShowSeriesName(true);
  $branch1Label->getDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
  $branch1Label->getDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
```


![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **تعيين لون فرع نقطة البيانات**
غيّر لون الفرع "Steam 4":
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Sunburst, 100, 100, 450, 400);
    $dataPoints = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints();
    $stem4branch = $dataPoints->get_Item(9)->getDataPointLevels()->get_Item(1);
    $stem4branch->getFormat()->getFill()->setFillType(FillType::Solid);
    $stem4branch->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **الأسئلة المتكررة**

**هل يمكنني تغيير ترتيب (الفرز) القطاعات في Sunburst/Treemap؟**

لا. يقوم PowerPoint بفرز القطاعات تلقائيًا (عادةً حسب القيم المتناقصة باتجاه عقارب الساعة). يعكس Aspose.Slides هذا السلوك: لا يمكنك تغيير الترتيب مباشرةً؛ يمكنك تحقيق ذلك عبر معالجة البيانات مسبقًا.

**كيف يؤثر سمة/لوحة ألوان العرض التقديمي على ألوان القطاعات والتسميات؟**

تورث ألوان المخطط سمة العرض التقديمي [theme/palette](/slides/ar/php-java/presentation-theme/) ما لم تقم بتعيين تعبئات/خطوط صراحةً. للحصول على نتائج متسقة، قم بتثبيت تعبئات صلبة وتنسيق النص في المستويات المطلوبة.

**هل سيحتفظ التصدير إلى PDF/PNG بألوان الفروع المخصصة وإعدادات التسميات؟**

نعم. عند تصدير العرض التقديمي، تُحافظ إعدادات المخطط (التعبئات، التسميات) في صيغ الإخراج لأن Aspose.Slides يقوم بالعرض مع تطبيق تنسيق المخطط.

**هل يمكنني حساب الإحداثيات الفعلية لتسمية/عنصر لتحديد موضع تراكب مخصص فوق المخطط؟**

نعم. بعد التحقق من تخطيط المخطط، تكون قيم *x* الفعلية و*y* الفعلية متاحة للعناصر (على سبيل المثال، [DataLabel](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/))، مما يساعد في تحديد موضع التراكبات بدقة.