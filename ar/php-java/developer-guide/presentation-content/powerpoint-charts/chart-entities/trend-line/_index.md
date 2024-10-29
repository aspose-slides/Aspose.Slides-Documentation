---
title: خط الاتجاه
type: docs
url: /ar/php-java/trend-line/
---

## **إضافة خط اتجاه**
يوفر Aspose.Slides لـ PHP عبر Java واجهة برمجة تطبيقات بسيطة لإدارة خطوط الاتجاه المختلفة في الرسوم البيانية:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. الحصول على مرجع الشريحة بواسطة فهرسها.
1. إضافة رسم بياني ببيانات افتراضية مع أي نوع مرغوب (يستخدم هذا المثال ChartType::ClusteredColumn).
1. إضافة خط اتجاه أسي لسلسلة الرسم البياني 1.
1. إضافة خط اتجاه خطي لسلسلة الرسم البياني 1.
1. إضافة خط اتجاه لوغاريتمي لسلسلة الرسم البياني 2.
1. إضافة خط اتجاه متوسط متحرك لسلسلة الرسم البياني 2.
1. إضافة خط اتجاه متعدد الحدود لسلسلة الرسم البياني 3.
1. إضافة خط اتجاه قوى لسلسلة الرسم البياني 3.
1. كتابة العرض التقديمي المعدل إلى ملف PPTX.

يتم استخدام الشيفرة التالية لإنشاء رسم بياني مع خطوط الاتجاه.

```php
  # إنشاء مثيل من فئة Presentation
  $pres = new Presentation();
  try {
    # إنشاء رسم بياني عمودي متراص
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 400);
    # إضافة خط اتجاه أسي لسلسلة الرسم البياني 1
    $tredLinep = $chart->getChartData()->getSeries()->get_Item(0)->getTrendLines()->add(TrendlineType::Exponential);
    $tredLinep->setDisplayEquation(false);
    $tredLinep->setDisplayRSquaredValue(false);
    # إضافة خط اتجاه خطي لسلسلة الرسم البياني 1
    $tredLineLin = $chart->getChartData()->getSeries()->get_Item(0)->getTrendLines()->add(TrendlineType::Linear);
    $tredLineLin->setTrendlineType(TrendlineType::Linear);
    $tredLineLin->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $tredLineLin->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # إضافة خط اتجاه لوغاريتمي لسلسلة الرسم البياني 2
    $tredLineLog = $chart->getChartData()->getSeries()->get_Item(1)->getTrendLines()->add(TrendlineType::Logarithmic);
    $tredLineLog->setTrendlineType(TrendlineType::Logarithmic);
    $tredLineLog->addTextFrameForOverriding("خط اتجاه لوغاريتمي جديد");
    # إضافة خط اتجاه متوسط متحرك لسلسلة الرسم البياني 2
    $tredLineMovAvg = $chart->getChartData()->getSeries()->get_Item(1)->getTrendLines()->add(TrendlineType::MovingAverage);
    $tredLineMovAvg->setTrendlineType(TrendlineType::MovingAverage);
    $tredLineMovAvg->setPeriod(3);
    $tredLineMovAvg->setTrendlineName("اسم خط الاتجاه الجديد");
    # إضافة خط اتجاه متعدد الحدود لسلسلة الرسم البياني 3
    $tredLinePol = $chart->getChartData()->getSeries()->get_Item(2)->getTrendLines()->add(TrendlineType::Polynomial);
    $tredLinePol->setTrendlineType(TrendlineType::Polynomial);
    $tredLinePol->setForward(1);
    $tredLinePol->setOrder(3);
    # إضافة خط اتجاه قوى لسلسلة الرسم البياني 3
    $tredLinePower = $chart->getChartData()->getSeries()->get_Item(1)->getTrendLines()->add(TrendlineType::Power);
    $tredLinePower->setTrendlineType(TrendlineType::Power);
    $tredLinePower->setBackward(1);
    # حفظ العرض التقديمي
    $pres->save("ChartTrendLines_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **إضافة خط مخصص**
يوفر Aspose.Slides لـ PHP عبر Java واجهة برمجة تطبيقات بسيطة لإضافة خطوط مخصصة في الرسم البياني. لإضافة خط بسيط إلى شريحة محددة من العرض التقديمي، يرجى اتباع الخطوات أدناه:

- إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)
- الحصول على مرجع شريحة باستخدام فهرسها
- إنشاء رسم بياني جديد باستخدام طريقة AddChart المعرضة بواسطة كائن Shapes
- إضافة شكل آلي من نوع خط باستخدام طريقة AddAutoShape المعرضة بواسطة كائن Shapes
- تعيين لون خطوط الشكل.
- كتابة العرض التقديمي المعدل كملف PPTX

يتم استخدام الشيفرة التالية لإنشاء رسم بياني مع خطوط مخصصة.

```php
  # إنشاء مثيل من فئة Presentation
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 400);
    $shape = $chart->getUserShapes()->getShapes()->addAutoShape(ShapeType::Line, 0, $chart->getHeight() / 2, $chart->getWidth(), 0);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $pres->save("Presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```