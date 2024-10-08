---
title: شريط الخطأ
type: docs
url: /ar/php-java/error-bar/
---

## **إضافة شريط خطأ**
توفر Aspose.Slides لـ PHP عبر Java واجهة برمجة تطبيقات بسيطة لإدارة قيم أشرطة الخطأ. ينطبق كود العينة عند استخدام نوع قيمة مخصص. لتحديد قيمة، استخدم خاصية **ErrorBarCustomValues** لنقطة بيانات محددة في مجموعة [**DataPoints**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartSeriesCollection):

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. أضف رسمًا بيانيًا من نوع فقاعي في الشريحة المرغوبة.
1. الوصول إلى السلسلة البيانية الأولى وضبط تنسيق شريط الخطأ X.
1. الوصول إلى السلسلة البيانية الأولى وضبط تنسيق شريط الخطأ Y.
1. ضبط قيم الأشرطة والتنسيق.
1. كتابة العرض المعدل إلى ملف PPTX.

```php
  # إنشاء مثيل لفئة Presentation
  $pres = new Presentation();
  try {
    # إنشاء رسم بياني فقاعي
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 400, 300, true);
    # إضافة أشرطة الخطأ وضبط تنسيقها
    $errBarX = $chart->getChartData()->getSeries()->get_Item(0)->getErrorBarsXFormat();
    $errBarY = $chart->getChartData()->getSeries()->get_Item(0)->getErrorBarsYFormat();
    $errBarX->isVisible();
    $errBarY->isVisible();
    $errBarX->setValueType(ErrorBarValueType::Fixed);
    $errBarX->setValue(0.1);
    $errBarY->setValueType(ErrorBarValueType::Percentage);
    $errBarY->setValue(5);
    $errBarX->setType(ErrorBarType::Plus);
    $errBarY->getFormat()->getLine()->setWidth(2.0);
    $errBarX->hasEndCap();
    # حفظ العرض
    $pres->save("ErrorBars.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **إضافة قيمة شريط خطأ مخصص**
توفر Aspose.Slides لـ PHP عبر Java واجهة برمجة تطبيقات بسيطة لإدارة قيم أشرطة الخطأ المخصصة. ينطبق كود العينة عندما تكون خاصية [**IErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/php-java/aspose.slides/IErrorBarsFormat#getValue--) تساوي **Custom**. لتحديد قيمة، استخدم خاصية **ErrorBarCustomValues** لنقطة بيانات محددة في مجموعة [**DataPoints**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartSeriesCollection):

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. أضف رسمًا بيانيًا من نوع فقاعي في الشريحة المرغوبة.
1. الوصول إلى السلسلة البيانية الأولى وضبط تنسيق شريط الخطأ X.
1. الوصول إلى السلسلة البيانية الأولى وضبط تنسيق شريط الخطأ Y.
1. الوصول إلى نقاط بيانات السلسلة البيانية الفردية وضبط قيم أشرطة الخطأ لكل نقطة بيانات فردية.
1. ضبط قيم الأشرطة والتنسيق.
1. كتابة العرض المعدل إلى ملف PPTX.

```php
  # إنشاء مثيل لفئة Presentation
  $pres = new Presentation();
  try {
    # إنشاء رسم بياني فقاعي
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 400, 300, true);
    # إضافة أشرطة خطأ مخصصة وضبط تنسيقها
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $errBarX = $series->getErrorBarsXFormat();
    $errBarY = $series->getErrorBarsYFormat();
    $errBarX->isVisible();
    $errBarY->isVisible();
    $errBarX->setValueType(ErrorBarValueType::Custom);
    $errBarY->setValueType(ErrorBarValueType::Custom);
    # الوصول إلى نقطة بيانات السلسلة البيانية وضبط قيم أشرطة الخطأ لكل نقطة فردية
    $points = $series->getDataPoints();
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForXPlusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForXMinusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForYPlusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForYMinusValues(DataSourceType::DoubleLiterals);
    # ضبط أشرطة الخطأ لنقاط السلسلة البيانية
    for($i = 0; $i < java_values($points->size()) ; $i++) {
      $points->get_Item($i)->getErrorBarsCustomValues()->getXMinus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getXPlus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getYMinus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getYPlus()->setAsLiteralDouble($i + 1);
    }
    # حفظ العرض
    $pres->save("ErrorBarsCustomValues.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```