---
title: "تخصيص نقاط البيانات في مخططات Treemap و Sunburst باستخدام PHP"
linktitle: "نقاط البيانات في مخططات Treemap و Sunburst"
type: docs
url: /ar/php-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- "مخطط treemap"
- "مخطط sunburst"
- "نقطة بيانات"
- "لون التسمية"
- "لون الفرع"
- "PowerPoint"
- "عرض تقديمي"
- "PHP"
- "Aspose.Slides"
description: "تعرّف على كيفية إدارة نقاط البيانات في مخططات treemap و sunburst باستخدام Aspose.Slides للـ PHP عبر Java، مع توافق مع صيغ PowerPoint."
---

إلى جانب أنواع أخرى من مخططات PowerPoint، هناك نوعان "هرميان" - مخطط **Treemap** ومخطط **Sunburst** (المعروف أيضًا باسم مخطط Sunburst Graph أو Sunburst Diagram أو Radial Chart أو Radial Graph أو Multi Level Pie Chart). تعرض هذه المخططات بيانات هرمية منظمة كشجرة - من الأوراق إلى أعلى الفرع. تُعرّف الأوراق بنقاط بيانات السلسلة، ويُعرّف كل مستوى تجميع متداخل لاحقًا بالفئة المقابلة. يتيح Aspose.Slides for PHP عبر Java تنسيق نقاط بيانات مخطط Sunburst و Treemap.

فيما يلي مخطط Sunburst، حيث تُعرّف البيانات في عمود Series1 عقد الأوراق، بينما تحدد الأعمدة الأخرى نقاط البيانات الهرمية:

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
- [**إنشاء مخطط Sunburst**](/slides/ar/php-java/adding-charts/#addingcharts-creatingsunburstchart)
{{% /alert %}}

إذا كان هناك حاجة لتنسيق نقاط بيانات المخطط، يجب علينا استخدام ما يلي:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataPointLevelsManager),  
فئات [IChartDataPointLevel](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataPointLevel)  
وطريقة [**IChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataPoint#getDataPointLevels--)  
توفر الوصول إلى تنسيق نقاط بيانات مخططي Treemap و Sunburst.  

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataPointLevelsManager) يُستخدم للوصول إلى الفئات متعددة المستويات - وهو يمثل حاوية كائنات [**IChartDataPointLevel**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataPointLevel).  
في الأساس هو غلاف لـ [**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartCategoryLevelsManager) مع الخصائص المضافة المحددة لنقاط البيانات.  
فئة [**IChartDataPointLevel**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataPointLevel) تحتوي على طريقتين: [**getFormat**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataPointLevel#getFormat--) و[**getDataLabel**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataPointLevel#getLabel--) التي توفر الوصول إلى الإعدادات المقابلة.

## **إظهار قيمة نقطة البيانات**
عرض قيمة نقطة البيانات "Leaf 4":
```php
  $dataPoints = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints();
  $dataPoints->get_Item(3)->getDataPointLevels()->get_Item(0)->getLabel()->getDataLabelFormat()->setShowValue(true);

```


![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **تعيين تسمية ولون نقطة البيانات**
اجعل تسمية البيانات "Branch 1" تُظهر اسم السلسلة ("Series1") بدلاً من اسم الفئة. ثم اضبط لون النص إلى الأصفر:
```php
  $branch1Label = $dataPoints->get_Item(0)->getDataPointLevels()->get_Item(0)->getLabel();
  $branch1Label->getDataLabelFormat()->setShowCategoryName(false);
  $branch1Label->getDataLabelFormat()->setShowSeriesName(true);
  $branch1Label->getDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
  $branch1Label->getDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
```


![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **تعيين لون فرع نقطة البيانات**
غيّر لون فرع "Steam 4":
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

**هل يمكنني تغيير ترتيب (الفرز) الشرائح في مخطط Sunburst/Treemap؟**

لا. يقوم PowerPoint بفرز الشرائح تلقائيًا (عادةً حسب القيم تنازليًا، باتجاه عقارب الساعة). ينسخ Aspose.Slides هذا السلوك: لا يمكنك تغيير الترتيب مباشرةً؛ بل يمكنك تحقيق ذلك عبر معالجة البيانات مسبقًا.

**كيف يؤثر سمة العرض التقديمي على ألوان الشرائح والتسميات؟**

ألوان المخطط ترث سمة/لوحة ألوان العرض التقديمي [theme/palette](/slides/ar/php-java/presentation-theme/) ما لم تقم بتعيين التعبئة/الخطوط صراحةً. للحصول على نتائج متسقة، قم بتثبيت التعبئات الصلبة وتنسيق النص في المستويات المطلوبة.

**هل سيحافظ التصدير إلى PDF/PNG على ألوان الفروع المخصصة وإعدادات التسميات؟**

نعم. عند تصدير العرض التقديمي، يتم الحفاظ على إعدادات المخطط (التعبئات، التسميات) في صيغ الإخراج لأن Aspose.Slides يقوم بإنتاج المخطط بتنسيقه المطبق.

**هل يمكنني حساب الإحداثيات الفعلية لتسمية/عنصر لوضع طبقة مخصصة فوق المخطط؟**

نعم. بعد التحقق من تخطيط المخطط، تتوفر قيم *x* و*y* الفعليتين للعناصر (على سبيل المثال، [DataLabel](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/))، مما يساعد في وضع الطبقات فوق المخطط بدقة.