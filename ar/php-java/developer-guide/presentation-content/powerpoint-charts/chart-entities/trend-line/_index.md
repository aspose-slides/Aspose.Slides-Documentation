---
title: إضافة خطوط الاتجاه إلى المخططات في العروض التقديمية بـ PHP
linktitle: خط الاتجاه
type: docs
url: /ar/php-java/trend-line/
keywords:
- مخطط
- خط الاتجاه
- خط الاتجاه الأسي
- خط الاتجاه الخطي
- خط الاتجاه اللوغاريتمي
- خط الاتجاه المتوسط المتحرك
- خط الاتجاه متعدد الحدود
- خط الاتجاه القوي
- خط الاتجاه المخصص
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "أضف خطوط الاتجاه بسرعة وقم بتخصيصها في مخططات PowerPoint باستخدام Aspose.Slides لـ PHP عبر Java — دليل عملي لجذب جمهورك."
---

## **إضافة خط الاتجاه**
Aspose.Slides for PHP via Java توفر واجهة برمجة تطبيقات بسيطة لإدارة خطوط الاتجاه المختلفة للمخططات:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. الحصول على مرجع الشريحة باستخدام رقمها.
1. إضافة مخطط مع بيانات افتراضية بالإضافة إلى أي نوع مطلوب (هذا المثال يستخدم ChartType::ClusteredColumn).
1. إضافة خط اتجاه أسي لسلسلة المخطط 1.
1. إضافة خط اتجاه خطي لسلسلة المخطط 1.
1. إضافة خط اتجاه لوغاريتمي لسلسلة المخطط 2.
1. إضافة خط اتجاه المتوسط المتحرك لسلسلة المخطط 2.
1. إضافة خط اتجاه متعدد الحدود لسلسلة المخطط 3.
1. إضافة خط اتجاه أساسي لسلسلة المخطط 3.
1. كتابة العرض التقديمي المعدل إلى ملف PPTX.

الشفرة التالية تُستخدم لإنشاء مخطط مع خطوط الاتجاه.
```php
  # إنشاء مثيل من فئة Presentation
  $pres = new Presentation();
  try {
    # إنشاء مخطط عمودي مجمع
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 400);
    # إضافة خط اتجاه أسي لسلسلة المخطط 1
    $tredLinep = $chart->getChartData()->getSeries()->get_Item(0)->getTrendLines()->add(TrendlineType::Exponential);
    $tredLinep->setDisplayEquation(false);
    $tredLinep->setDisplayRSquaredValue(false);
    # إضافة خط اتجاه خطي لسلسلة المخطط 1
    $tredLineLin = $chart->getChartData()->getSeries()->get_Item(0)->getTrendLines()->add(TrendlineType::Linear);
    $tredLineLin->setTrendlineType(TrendlineType::Linear);
    $tredLineLin->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $tredLineLin->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # إضافة خط اتجاه لوغاريتمي لسلسلة المخطط 2
    $tredLineLog = $chart->getChartData()->getSeries()->get_Item(1)->getTrendLines()->add(TrendlineType::Logarithmic);
    $tredLineLog->setTrendlineType(TrendlineType::Logarithmic);
    $tredLineLog->addTextFrameForOverriding("New log trend line");
    # إضافة خط اتجاه متوسط متحرك لسلسلة المخطط 2
    $tredLineMovAvg = $chart->getChartData()->getSeries()->get_Item(1)->getTrendLines()->add(TrendlineType::MovingAverage);
    $tredLineMovAvg->setTrendlineType(TrendlineType::MovingAverage);
    $tredLineMovAvg->setPeriod(3);
    $tredLineMovAvg->setTrendlineName("New TrendLine Name");
    # إضافة خط اتجاه متعدد الحدود لسلسلة المخطط 3
    $tredLinePol = $chart->getChartData()->getSeries()->get_Item(2)->getTrendLines()->add(TrendlineType::Polynomial);
    $tredLinePol->setTrendlineType(TrendlineType::Polynomial);
    $tredLinePol->setForward(1);
    $tredLinePol->setOrder(3);
    # إضافة خط اتجاه قوة لسلسلة المخطط 3
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
Aspose.Slides for PHP via Java توفر واجهة برمجة تطبيقات بسيطة لإضافة خطوط مخصصة في مخطط. لإضافة خط بسيط إلى شريحة مختارة من العرض التقديمي، يرجى اتباع الخطوات أدناه:

- إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 
- الحصول على مرجع شريحة باستخدام رقمها
- إنشاء مخطط جديد باستخدام طريقة AddChart المتاحة عبر كائن Shapes
- إضافة AutoShape من نوع خط باستخدام طريقة AddAutoShape المتاحة عبر كائن Shapes
- تعيين لون خطوط الشكل.
- كتابة العرض التقديمي المعدل كملف PPTX

الشفرة التالية تُستخدم لإنشاء مخطط مع خطوط مخصصة.
```php
  # إنشاء مثيل من فئة Presentation class
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


## **الأسئلة الشائعة**

**ماذا يعني 'forward' و 'backward' لخط الاتجاه؟**

هي أطوال خط الاتجاه المتجهة للأمام أو للخلف: في المخططات النقطية (XY) — بوحدات المحور؛ في المخططات غير النقطية — بعدد الفئات. يُسمح فقط بالقيم غير السلبية.

**هل سيُحافظ على خط الاتجاه عند تصدير العرض التقديمي إلى PDF أو SVG، أو عند تحويل الشريحة إلى صورة؟**

نعم. Aspose.Slides يحول العروض التقديمية إلى [PDF](/slides/ar/php-java/convert-powerpoint-to-pdf/)/[SVG](/slides/ar/php-java/render-a-slide-as-an-svg-image/) ويقوم برسم المخططات كصور؛ خطوط الاتجاه، كجزء من المخطط، تُحافظ عليها هذه العمليات. كما تتوفر طريقة لـ [تصدير صورة للمخطط](/slides/ar/php-java/create-shape-thumbnails/) نفسها.