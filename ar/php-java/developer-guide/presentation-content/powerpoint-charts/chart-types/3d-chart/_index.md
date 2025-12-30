---
title: تخصيص المخططات ثلاثية الأبعاد في العروض التقديمية باستخدام PHP
linktitle: مخطط ثلاثي الأبعاد
type: docs
url: /ar/php-java/3d-chart/
keywords:
- مخطط ثلاثي الأبعاد
- دوران
- عمق
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تعرف على كيفية إنشاء وتخصيص المخططات ثلاثية الأبعاد في Aspose.Slides للـ PHP عبر Java، مع دعم ملفات PPT و PPTX — حسّن عروضك التقديمية اليوم."
---

## **تعيين خصائص RotationX و RotationY و DepthPercents لمخطط ثلاثي الأبعاد**
توفر Aspose.Slides for PHP عبر Java واجهة برمجة تطبيقات بسيطة لتعيين هذه الخصائص. سيساعدك المقال التالي في كيفية تعيين خصائص مختلفة مثل **X,Y Rotation، DepthPercents** وغيرها. يُظهر رمز العينة كيفية تعيين الخصائص المذكورة أعلاه.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. الوصول إلى الشريحة الأولى.
1. إضافة مخطط بالبيانات الافتراضية.
1. تعيين خصائص Rotation3D.
1. كتابة العرض التقديمي المعدل إلى ملف PPTX.
```php
  $pres = new Presentation();
  try {
    # الوصول إلى الشريحة الأولى
    $slide = $pres->getSlides()->get_Item(0);
    # إضافة مخطط بالبيانات الافتراضية
    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn3D, 0, 0, 500, 500);
    # تعيين فهرس ورقة بيانات المخطط
    $defaultWorksheetIndex = 0;
    # الحصول على ورقة عمل بيانات المخطط
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # إضافة سلسلة
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 2, "Series 2"), $chart->getType());
    # إضافة الفئات
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    # تعيين خصائص Rotation3D
    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setRotationX(40);
    $chart->getRotation3D()->setRotationY(270);
    $chart->getRotation3D()->setDepthPercents(150);
    # أخذ السلسلة الثانية للمخطط
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # الآن يتم تعبئة بيانات السلسلة
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));
    # تعيين قيمة OverLap
    $series->getParentSeriesGroup()->setOverlap(100);
    # كتابة العرض التقديمي إلى القرص
    $pres->save("Rotation3D_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**ما أنواع المخططات التي تدعم وضع 3D في Aspose.Slides؟**

يدعم Aspose.Slides الأشكال الثلاثية الأبعاد للمخططات العمودية، بما في ذلك Column 3D و Clustered Column 3D و Stacked Column 3D و 100% Stacked Column 3D، إلى جانب الأنواع الثلاثية الأبعاد ذات الصلة التي يتم الكشف عنها من خلال فئة [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/). للحصول على قائمة دقيقة ومحدثة، راجع أعضاء [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) في مرجع API للإصدار المثبت لديك.

**هل يمكنني الحصول على صورة نقطية لمخطط ثلاثي الأبعاد لتقرير أو للويب؟**

نعم. يمكنك تصدير المخطط إلى صورة عبر [chart API](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) أو [render the entire slide](/slides/ar/php-java/convert-powerpoint-to-png/) إلى صيغ مثل PNG أو JPEG. هذا مفيد عندما تحتاج إلى معاينة دقيقة بالبكسل أو تريد تضمين المخطط في مستندات أو لوحات معلومات أو صفحات ويب دون الحاجة إلى PowerPoint.

**ما مدى كفاءة بناء وعرض المخططات الثلاثية الأبعاد الكبيرة؟**

يعتمد الأداء على حجم البيانات وتعقيد العرض. للحصول على أفضل النتائج، حافظ على الحد الأدنى من التأثيرات ثلاثية الأبعاد، وتجنب القوام الثقيلة على الجدران ومنطقتي المخطط، وحدّ عدد نقاط البيانات لكل سلسلة عندما يكون ذلك ممكنًا، وقم بالعرض بدقة وأبعاد مناسبة لتتناسب مع شاشة العرض أو احتياجات الطباعة المستهدفة.