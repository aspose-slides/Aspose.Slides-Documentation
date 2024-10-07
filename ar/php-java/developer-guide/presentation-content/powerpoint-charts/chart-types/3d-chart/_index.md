---
title: رسم بياني ثلاثي الأبعاد
type: docs
url: /php-java/3d-chart/
---

## **تعيين خصائص RotationX و RotationY و DepthPercents للرسم البياني ثلاثي الأبعاد**
توفر Aspose.Slides لـ PHP عبر Java واجهة برمجة تطبيقات بسيطة لتعيين هذه الخصائص. سيساعدك هذا المقال التالي على كيفية تعيين خصائص مختلفة مثل **X, Y Rotation, DepthPercents** وما إلى ذلك. يقوم الكود النموذجي بتطبيق تعيين الخصائص المذكورة أعلاه.

1. أنشئ مثيلاً من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. الوصول إلى الشريحة الأولى.
1. إضافة رسم بياني مع بيانات افتراضية.
1. تعيين خصائص Rotation3D.
1. كتابة العرض التقديمي المعدل إلى ملف PPTX.

```php
  $pres = new Presentation();
  try {
    # الوصول إلى الشريحة الأولى
    $slide = $pres->getSlides()->get_Item(0);
    # إضافة رسم بياني مع بيانات افتراضية
    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn3D, 0, 0, 500, 500);
    # تعيين فهرس ورقة بيانات الرسم البياني
    $defaultWorksheetIndex = 0;
    # الحصول على ورقة بيانات الرسم البياني
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # إضافة السلاسل
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 1, "السلسلة 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 2, "السلسلة 2"), $chart->getType());
    # إضافة الفئات
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 1, 0, "الفئة 1"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 2, 0, "الفئة 2"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 3, 0, "الفئة 3"));
    # تعيين خصائص Rotation3D
    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setRotationX(40);
    $chart->getRotation3D()->setRotationY(270);
    $chart->getRotation3D()->setDepthPercents(150);
    # أخذ سلسلة الرسم البياني الثانية
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # الآن تعبئة بيانات السلسلة
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