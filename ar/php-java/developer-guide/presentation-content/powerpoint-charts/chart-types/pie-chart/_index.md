---
title: رسم بياني دائري
type: docs
url: /php-java/pie-chart/
---

## **خيارات الرسم الثاني لرسم البياني الدائري أو الرسم الشريطي الدائري**
Aspose.Slides لـ PHP عبر Java يدعم الآن خيارات الرسم الثاني لرسم البياني الدائري أو الرسم الشريطي الدائري. في هذا الموضوع، سنوضح لك كيفية تحديد تلك الخيارات باستخدام Aspose.Slides. لتحديد الخصائص، قم بما يلي:

1. أنشئ كائن من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. أضف الرسم البياني على الشريحة.
1. حدد خيارات الرسم الثاني للرسم البياني.
1. اكتب العرض التقديمي على القرص.

في المثال الموضح أدناه، قمنا بتعيين خصائص مختلفة لرسم البياني الدائري.

```php
  # إنشاء مثيل من فئة Presentation
  $pres = new Presentation();
  try {
    # إضافة رسم بياني على الشريحة
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::PieOfPie, 50, 50, 500, 400);
    # تعيين خصائص مختلفة
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setSecondPieSize(149);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setPieSplitBy(PieSplitType::ByPercentage);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setPieSplitPosition(53);
    # كتابة العرض التقديمي على القرص
    $pres->save("SecondPlotOptionsforCharts_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تعيين ألوان شرائح الرسم البياني الدائري تلقائياً**
Aspose.Slides لـ PHP عبر Java يوفر واجهة برمجة تطبيقات بسيطة لتعيين ألوان شرائح الرسم البياني الدائري تلقائياً. الشيفرة العينة تطبق تعيين الخصائص المذكورة أعلاه.

1. أنشئ مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. الوصول إلى الشريحة الأولى.
1. أضف الرسم البياني باستخدام البيانات الافتراضية.
1. تعيين عنوان الرسم البياني.
1. تعيين السلسلة الأولى لعرض القيم.
1. تعيين مؤشر ورقة بيانات الرسم البياني.
1. الحصول على ورقة بيانات الرسم البياني.
1. حذف السلاسل والفئات المولدة افتراضياً.
1. إضافة فئات جديدة.
1. إضافة سلاسل جديدة.

اكتب العرض التقديمي المعدل إلى ملف PPTX.

```php
  # إنشاء مثيل من فئة Presentation
  $pres = new Presentation();
  try {
    # إضافة رسم بياني باستخدام البيانات الافتراضية
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 100, 100, 400, 400);
    # تعيين عنوان الرسم البياني
    $chart->getChartTitle()->addTextFrameForOverriding("عنوان عينة");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);
    # تعيين السلسلة الأولى لعرض القيم
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # تعيين مؤشر ورقة بيانات الرسم البياني
    $defaultWorksheetIndex = 0;
    # الحصول على ورقة بيانات الرسم البياني
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # حذف السلاسل والفئات المولدة افتراضياً
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # إضافة فئات جديدة
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 1, 0, "الربع الأول"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 2, 0, "الربع الثاني"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 3, 0, "الربع الثالث"));
    # إضافة سلاسل جديدة
    $series = $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 1, "السلسلة 1"), $chart->getType());
    # الآن تعبئة بيانات السلسلة
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    $series->getParentSeriesGroup()->setColorVaried(true);
    $pres->save("Pie.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```