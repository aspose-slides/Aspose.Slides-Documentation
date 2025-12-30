---
title: تخصيص مساحات الرسم للمخططات في العروض التقديمية بلغة PHP
linktitle: مساحة الرسم
type: docs
url: /ar/php-java/chart-plot-area/
keywords:
- مخطط
- مساحة الرسم
- عرض مساحة الرسم
- ارتفاع مساحة الرسم
- حجم مساحة الرسم
- وضع التخطيط
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "اكتشف كيفية تخصيص مساحات رسم المخططات في عروض PowerPoint التقديمية باستخدام Aspose.Slides للـ PHP عبر Java. حسّن مظهر شرائحك بسهولة."
---

## **الحصول على عرض وارتفاع مساحة رسم المخطط**
توفر Aspose.Slides لـ PHP عبر Java واجهة برمجة تطبيقات بسيطة لـ .

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) .
2. الوصول إلى الشريحة الأولى.
3. إضافة مخطط مع البيانات الافتراضية.
4. استدعاء الطريقة [IChart.validateChartLayout()](https://reference.aspose.com/slides/php-java/aspose.slides/IChart#validateChartLayout--) قبل الحصول على القيم الفعلية.
5. الحصول على الموقع الفعلي للمحور X (اليسار) لعنصر المخطط نسبةً إلى الزاوية اليسرى العليا للمخطط.
6. الحصول على أعلى العنصر الفعلي للمخطط نسبةً إلى الزاوية اليسرى العليا للمخطط.
7. الحصول على عرض العنصر الفعلي للمخطط.
8. الحصول على ارتفاع العنصر الفعلي للمخطط.
```php
  # إنشاء نسخة من فئة Presentation
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


## **ضبط وضع التخطيط لمساحة رسم المخطط**
توفر Aspose.Slides لـ PHP عبر Java واجهة برمجة تطبيقات بسيطة لضبط وضع التخطيط لمساحة رسم المخطط. تم إضافة الطريقتين [**setLayoutTargetType**](https://reference.aspose.com/slides/php-java/aspose.slides/ChartPlotArea#setLayoutTargetType-int-) و[**getLayoutTargetType**](https://reference.aspose.com/slides/php-java/aspose.slides/ChartPlotArea#getLayoutTargetType--) إلى الفئة [**ChartPlotArea**](https://reference.aspose.com/slides/php-java/aspose.slides/ChartPlotArea) والواجهة [**IChartPlotArea**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartPlotArea). إذا تم تعريف تخطيط مساحة الرسم يدويًا، فإن هذه الخاصية تحدد ما إذا كان يجب تخطيط مساحة الرسم من داخلها (دون تضمين المحاور وعناوين المحاور) أو من خارجها (بما في ذلك المحاور وعناوين المحاور). هناك قيمتان محتملتان معرفتان في تعداد [**LayoutTargetType**](https://reference.aspose.com/slides/php-java/aspose.slides/LayoutTargetType).

- [**LayoutTargetType::Inner**](https://reference.aspose.com/slides/php-java/aspose.slides/LayoutTargetType#Inner) - يحدد أن حجم مساحة الرسم يحدد حجم مساحة الرسم دون تضمين علامات التحديد وعناوين المحاور.
- [**LayoutTargetType::Outer**](https://reference.aspose.com/slides/php-java/aspose.slides/LayoutTargetType#Outer) - يحدد أن حجم مساحة الرسم يحدد حجم مساحة الرسم، وعلامات التحديد، وعناوين المحاور.

الكود النموذجي موضح أدناه.
```php
  # إنشاء نسخة من فئة Presentation
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


## **الأسئلة الشائعة**

**بأي وحدات يتم إرجاع قيم x الفعلية، y الفعلية، العرض الفعلي، والارتفاع الفعلي؟**

بالنقاط؛ 1 بوصة = 72 نقطة. هذه هي وحدات إحداثيات Aspose.Slides.

**كيف تختلف مساحة الرسم (Plot Area) عن مساحة المخطط (Chart Area) من حيث المحتوى؟**

مساحة الرسم هي منطقة رسم البيانات (السلاسل، خطوط الشبكة، خطوط الاتجاه، إلخ)؛ مساحة المخطط تشمل العناصر المحيطة (العنوان، المفتاح، إلخ). في المخططات ثلاثية الأبعاد، تشمل مساحة الرسم أيضًا الجدران/الأرضية والمحاور.

**كيف يتم تفسير قيم x و y والعرض والارتفاع لمساحة الرسم عندما يكون التخطيط يدويًا؟**

هي كسور (0–1) من الحجم الكلي للمخطط؛ في هذا الوضع يتم تعطيل التوضع التلقائي وتُستَخدم الكسور التي تحددها.

**لماذا تغير موقع مساحة الرسم بعد إضافة/نقل المفتاح؟**

المفتاح يقع في مساحة المخطط خارج مساحة الرسم لكنه يؤثر على التخطيط والمساحة المتاحة، لذا قد تتحرك مساحة الرسم عندما يكون التوضع التلقائي مفعلاً. (هذا سلوك قياسي لمخططات PowerPoint.)