---
title: تخصيص مناطق رسم المخططات في العروض التقديمية بلغة PHP
linktitle: منطقة الرسم
type: docs
url: /ar/php-java/chart-plot-area/
keywords:
- مخطط
- منطقة الرسم
- عرض منطقة الرسم
- ارتفاع منطقة الرسم
- حجم منطقة الرسم
- وضع التخطيط
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "اكتشف كيفية تخصيص مناطق رسم المخططات في عروض PowerPoint التقديمية باستخدام Aspose.Slides لـ PHP عبر Java. حسّن مظهر الشرائح بسهولة."
---

## **الحصول على العرض والارتفاع لمنطقة رسم المخطط**
Aspose.Slides for PHP عبر Java يوفر واجهة برمجية بسيطة لـ .

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) .
1. الوصول إلى الشريحة الأولى.
1. إضافة مخطط بالبيانات الافتراضية.
1. استدعاء الطريقة [Chart.validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) قبل ذلك للحصول على القيم الفعلية.
1. الحصول على الموقع الفعلي X (اليسار) لعنصر المخطط نسبة إلى الزاوية العلوية اليسرى للمخطط.
1. الحصول على أعلى العنصر الفعلي للمخطط نسبة إلى الزاوية العلوية اليسرى للمخطط.
1. الحصول على العرض الفعلي لعنصر المخطط.
1. الحصول على الارتفاع الفعلي لعنصر المخطط.
```php
  # إنشاء كائن من فئة Presentation
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 350);
    $chart->validateChartLayout();
    $x = $chart->getPlotArea()->getActualX();
    $y = $chart->getPlotArea()->getActualY();
    $w = $chart->getPlotArea()->getActualWidth();
    $h = $chart->getPlotArea()->getActualHeight();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **تعيين وضع تخطيط منطقة رسم المخطط**
Aspose.Slides for PHP عبر Java يوفر واجهة برمجية بسيطة لتعيين وضع تخطيط منطقة رسم المخطط. تم إضافة الطريقتين [**setLayoutTargetType**](https://reference.aspose.com/slides/php-java/aspose.slides/ChartPlotArea#setLayoutTargetType-int-) و[**getLayoutTargetType**](https://reference.aspose.com/slides/php-java/aspose.slides/ChartPlotArea#getLayoutTargetType--) إلى فئة [**ChartPlotArea**](https://reference.aspose.com/slides/php-java/aspose.slides/ChartPlotArea). إذا كان تخطيط منطقة الرسم محددًا يدويًا، تحدد هذه الخاصية ما إذا كان يجب تخطيط المنطقة من داخلها (دون تضمين المحاور وعناوين المحاور) أو من خارجها (مع المحاور وعناوين المحاور). هناك قيمتان محتملتان معرَّفتان في تعداد [**LayoutTargetType**](https://reference.aspose.com/slides/php-java/aspose.slides/LayoutTargetType) .

- [**LayoutTargetType::Inner**](https://reference.aspose.com/slides/php-java/aspose.slides/LayoutTargetType#Inner) - يحدد أن حجم منطقة الرسم يحدد حجم المنطقة، دون تضمين علامات الفواصل وعناوين المحاور.
- [**LayoutTargetType::Outer**](https://reference.aspose.com/slides/php-java/aspose.slides/LayoutTargetType#Outer) - يحدد أن حجم منطقة الرسم يحدد حجم المنطقة، علامات الفواصل، وعناوين المحاور.

الكود النموذجي موضح أدناه.
```php
  # إنشاء كائن من فئة Presentation
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 100, 600, 400);
    $chart->getPlotArea()->setX(0.2);
    $chart->getPlotArea()->setY(0.2);
    $chart->getPlotArea()->setWidth(0.7);
    $chart->getPlotArea()->setHeight(0.7);
    $chart->getPlotArea()->setLayoutTargetType(LayoutTargetType::Inner);
    $pres->save("SetLayoutMode_outer.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **الأسئلة المتكررة**
**في أي وحدات يتم إرجاع القيم الفعلية لـ x و y والعرض والارتفاع؟**

بالنقاط؛ 1 بوصة = 72 نقطة. هذه هي وحدات إحداثيات Aspose.Slides.

**كيف تختلف منطقة الرسم عن منطقة المخطط من حيث المحتوى؟**

منطقة الرسم هي منطقة رسم البيانات (السلاسل، خطوط الشبكة، خطوط الاتجاه، إلخ)؛ بينما تشمل منطقة المخطط العناصر المحيطة (العنوان، وسيلة الإيضاح، إلخ). في المخططات ثلاثية الأبعاد، تشمل منطقة الرسم أيضًا الجدران/الأرضية والمحاور.

**كيف يتم تفسير قيم x و y والعرض والارتفاع لمنطقة الرسم عندما يكون التخطيط يدويًا؟**

هي كسور (من 0 إلى 1) من الحجم الكلي للمخطط؛ في هذا الوضع يتم تعطيل التحديد الآلي وتُستخدم الكسور التي تحددها.

**لماذا تغير موقع منطقة الرسم بعد إضافة/تحريك وسيلة الإيضاح؟**

تقع وسيلة الإيضاح في منطقة المخطط خارج منطقة الرسم لكنها تؤثر على التخطيط والمساحة المتاحة، لذا قد تتحرك منطقة الرسم عندما يكون التحديد الآلي مفعلاً. (هذا سلوك قياسي لمخططات PowerPoint.)