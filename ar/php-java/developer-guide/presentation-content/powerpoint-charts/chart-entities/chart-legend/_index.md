---
title: أسطورة الرسم البياني
type: docs
url: /ar/php-java/chart-legend/
---

## **تحديد موضع الأسطورة**
لتعيين خصائص الأسطورة. يرجى اتباع الخطوات أدناه:

- إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- الحصول على مرجع الشريحة.
- إضافة رسم بياني على الشريحة.
- تعيين خصائص الأسطورة.
- كتابة العرض التقديمي كملف PPTX.

في المثال الموضح أدناه، قمنا بتعيين الموضع والحجم لأسطورة الرسم البياني.

```php
  # Create an instance of Presentation class
  $pres = new Presentation();
  try {
    # Get reference of the slide
    $slide = $pres->getSlides()->get_Item(0);
    # Add a clustered column chart on the slide
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 500);
    # Set Legend Properties
    $chart->getLegend()->setX(50 / $chart->getWidth());
    $chart->getLegend()->setY(50 / $chart->getHeight());
    $chart->getLegend()->setWidth(100 / $chart->getWidth());
    $chart->getLegend()->setHeight(100 / $chart->getHeight());
    # Write presentation to disk
    $pres->save("Legend_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تعيين حجم الخط للأسطورة**
تتيح Aspose.Slides لـ PHP عبر Java للمطورين تعيين حجم الخط للأسطورة. يرجى اتباع الخطوات أدناه:

- إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- إنشاء الرسم البياني الافتراضي.
- تعيين حجم الخط.
- تعيين قيمة المحور الدنيا.
- تعيين قيمة المحور القصوى.
- كتابة العرض التقديمي إلى القرص.

```php
  # Create an instance of Presentation class
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->getLegend()->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMinValue(false);
    $chart->getAxes()->getVerticalAxis()->setMinValue(-5);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMaxValue(false);
    $chart->getAxes()->getVerticalAxis()->setMaxValue(10);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تعيين حجم الخط لكل أسطورة فردية**
تتيح Aspose.Slides لـ PHP عبر Java للمطورين تعيين حجم الخط لمدخلات الأسطورة الفردية. يرجى اتباع الخطوات أدناه:

- إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- إنشاء الرسم البياني الافتراضي.
- الوصول إلى مدخل الأسطورة.
- تعيين حجم الخط.
- تعيين قيمة المحور الدنيا.
- تعيين قيمة المحور القصوى.
- كتابة العرض التقديمي إلى القرص.

```php
  # Create an instance of Presentation class
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $tf = $chart->getLegend()->getEntries()->get_Item(1)->getTextFormat();
    $tf->getPortionFormat()->setFontBold(NullableBool::True);
    $tf->getPortionFormat()->setFontHeight(20);
    $tf->getPortionFormat()->setFontItalic(NullableBool::True);
    $tf->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $tf->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```