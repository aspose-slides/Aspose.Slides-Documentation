---
title: منطقة رسم الرسم البياني
type: docs
url: /php-java/chart-plot-area/
---


## **الحصول على عرض وارتفاع منطقة رسم الرسم البياني**
توفر Aspose.Slides لـ PHP عبر Java واجهة برمجة تطبيقات بسيطة لـ.

1. إنشاء مثيل من فصل [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. الوصول إلى الشريحة الأولى.
1. إضافة مخطط مع بيانات افتراضية.
1. استدعاء الطريقة [IChart.validateChartLayout()](https://reference.aspose.com/slides/php-java/aspose.slides/IChart#validateChartLayout--) للحصول على القيم الفعلية.
1. الحصول على الموقع الفعلي لـ X (الأيسر) لعنصر الرسم البياني بالنسبة للزاوية العلوية اليسرى للرسم البياني.
1. الحصول على الجزء العلوي الفعلي لعنصر الرسم البياني بالنسبة للزاوية العلوية اليسرى للرسم البياني.
1. الحصول على العرض الفعلي لعنصر الرسم البياني.
1. الحصول على الارتفاع الفعلي لعنصر الرسم البياني.

```php
  # إنشاء مثيل من فصل Presentation
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

## **تعيين وضع التخطيط لمنطقة رسم الرسم البياني**
توفر Aspose.Slides لـ PHP عبر Java واجهة برمجة تطبيقات بسيطة لتعيين وضع التخطيط لمنطقة رسم الرسم البياني. تم إضافة الطرق [**setLayoutTargetType**](https://reference.aspose.com/slides/php-java/aspose.slides/ChartPlotArea#setLayoutTargetType-int-) و[**getLayoutTargetType**](https://reference.aspose.com/slides/php-java/aspose.slides/ChartPlotArea#getLayoutTargetType--) إلى فصل [**ChartPlotArea**](https://reference.aspose.com/slides/php-java/aspose.slides/ChartPlotArea) وواجهة [**IChartPlotArea**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartPlotArea). إذا تم تعريف تخطيط منطقة الرسم يدوياً، فهذا الخصائص تحدد ما إذا كان يجب تخطيط منطقة الرسم من الداخل (لا تشمل المحاور ووسوم المحاور) أو من الخارج (تشمل المحاور ووسوم المحاور). هناك قيمتان محتملتان تم تعريفهما في تعداد [**LayoutTargetType**](https://reference.aspose.com/slides/php-java/aspose.slides/LayoutTargetType).

- [**LayoutTargetType::Inner**](https://reference.aspose.com/slides/php-java/aspose.slides/LayoutTargetType#Inner) - يحدد أن حجم منطقة الرسم يجب أن يحدد حجم منطقة الرسم، دون تضمين علامات التوقف ووسوم المحاور.
- [**LayoutTargetType::Outer**](https://reference.aspose.com/slides/php-java/aspose.slides/LayoutTargetType#Outer) - يحدد أن حجم منطقة الرسم يجب أن يحدد حجم منطقة الرسم وعلامات التوقف ووسوم المحاور.

الكود النموذجي موضح أدناه.

```php
  # إنشاء مثيل من فصل Presentation
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