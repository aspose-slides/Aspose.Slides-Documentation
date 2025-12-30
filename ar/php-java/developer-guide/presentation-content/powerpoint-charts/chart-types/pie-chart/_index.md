---
title: تخصيص مخططات الفطيرة في العروض التقديمية باستخدام PHP
linktitle: مخطط الفطيرة
type: docs
url: /ar/php-java/pie-chart/
keywords:
- مخطط الفطيرة
- إدارة المخطط
- تخصيص المخطط
- خيارات المخطط
- إعدادات المخطط
- خيارات الرسم
- لون الشريحة
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تعلم كيفية إنشاء وتخصيص مخططات الفطيرة باستخدام Aspose.Slides لـ PHP عبر Java، قابل للتصدير إلى PowerPoint، مما يعزز سرد البيانات الخاص بك في ثوانٍ."
---

## **خيارات الرسم الثانوي لمخططات الفطيرة داخل الفطيرة والشريط داخل الفطيرة**
Aspose.Slides for PHP via Java الآن يدعم خيارات الرسم الثانوي لمخطط الفطيرة داخل الفطيرة أو الشريط داخل الفطيرة. في هذا الموضوع، سنوضح لك كيفية تحديد هذه الخيارات باستخدام Aspose.Slides. لتحديد الخصائص، قم بما يلي:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. إضافة مخطط إلى الشريحة.
1. تحديد خيارات الرسم الثانوي للمخطط.
1. كتابة العرض التقديمي إلى القرص.

في المثال أدناه، قمنا بتعيين خصائص مختلفة لمخطط الفطيرة داخل الفطيرة.
```php
  # إنشاء نسخة من فئة Presentation
  $pres = new Presentation();
  try {
    # إضافة مخطط إلى الشريحة
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::PieOfPie, 50, 50, 500, 400);
    # تعيين خصائص مختلفة
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setSecondPieSize(149);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setPieSplitBy(PieSplitType::ByPercentage);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setPieSplitPosition(53);
    # كتابة العرض التقديمي إلى القرص
    $pres->save("SecondPlotOptionsforCharts_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **تعيين ألوان شرائح مخطط الفطيرة تلقائيًا**
Aspose.Slides for PHP via Java يوفر واجهة برمجة تطبيقات بسيطة لتعيين ألوان شرائح مخطط الفطيرة تلقائيًا. يطبق الكود النموذجي الإعدادات المذكورة أعلاه.

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. الوصول إلى الشريحة الأولى.
1. إضافة مخطط بالبيانات الافتراضية.
1. تعيين عنوان المخطط.
1. تعيين السلسلة الأولى لعرض القيم.
1. تعيين فهرس ورقة بيانات المخطط.
1. الحصول على ورقة عمل بيانات المخطط.
1. حذف السلاسل والفئات التي تم إنشاؤها افتراضيًا.
1. إضافة فئات جديدة.
1. إضافة سلاسل جديدة.

اكتب العرض التقديمي المعدل إلى ملف PPTX.
```php
  # إنشاء نسخة من فئة Presentation
  $pres = new Presentation();
  try {
    # إضافة مخطط بالبيانات الافتراضية
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 100, 100, 400, 400);
    # تعيين عنوان المخطط
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);
    # تعيين السلسلة الأولى لعرض القيم
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # تعيين فهرس ورقة بيانات المخطط
    $defaultWorksheetIndex = 0;
    # الحصول على ورقة عمل بيانات المخطط
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # حذف السلاسل والفئات التي تم إنشاؤها افتراضيًا
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # إضافة فئات جديدة
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 1, 0, "First Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 2, 0, "2nd Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 3, 0, "3rd Qtr"));
    # إضافة سلاسل جديدة
    $series = $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 1, "Series 1"), $chart->getType());
    # الآن يتم تعبئة بيانات السلسلة
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


## **الأسئلة المتكررة**

**هل يتم دعم أنواع 'Pie of Pie' و 'Bar of Pie'؟**

نعم، المكتبة [تدعم](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) مخططًا ثانويًا لمخططات الفطيرة، بما في ذلك نوعي 'Pie of Pie' و 'Bar of Pie'.

**هل يمكنني تصدير المخطط فقط كصورة (على سبيل المثال PNG)؟**

نعم، يمكنك [تصدير المخطط نفسه كصورة](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) (مثل PNG) دون الحاجة إلى تصدير العرض التقديمي بالكامل.