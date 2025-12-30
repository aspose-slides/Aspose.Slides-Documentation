---
title: تخصيص أشرطة الخطأ في مخططات العروض التقديمية باستخدام PHP
linktitle: شريط الخطأ
type: docs
url: /ar/php-java/error-bar/
keywords:
- شريط الخطأ
- قيمة مخصصة
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تعلم كيفية إضافة وتخصيص أشرطة الخطأ في المخططات باستخدام Aspose.Slides لـ PHP عبر Java — تحسين عرض البيانات في عروض PowerPoint التقديمية."
---

## **إضافة أشرطة الخطأ**
توفر Aspose.Slides لـ PHP عبر Java واجهة برمجة تطبيقات بسيطة لإدارة قيم أشرطة الخطأ. ينطبق كود العينة عند استخدام نوع قيمة مخصص. لتحديد قيمة، استخدم الخاصية **ErrorBarCustomValues** لنقطة بيانات معينة في مجموعة [**DataPoints**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartSeriesCollection) الخاصة بالسلسلة:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. إضافة مخطط فقاعي إلى الشريحة المطلوبة.
1. الوصول إلى أول سلسلة مخطط وتعيين تنسيق شريط الخطأ X.
1. الوصول إلى أول سلسلة مخطط وتعيين تنسيق شريط الخطأ Y.
1. تعيين قيم الأشرطة وتنسيقها.
1. كتابة العرض التقديمي المعدل إلى ملف PPTX.
```php
  # إنشاء كائن من فئة Presentation
  $pres = new Presentation();
  try {
    # إنشاء مخطط فقاعة
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 400, 300, true);
    # إضافة أشرطة الخطأ وتعيين تنسيقها
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
    # حفظ العرض التقديمي
    $pres->save("ErrorBars.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **إضافة قيم أشرطة الخطأ المخصصة**
توفر Aspose.Slides لـ PHP عبر Java واجهة برمجة تطبيقات بسيطة لإدارة قيم أشرطة الخطأ المخصصة. ينطبق كود العينة عندما تكون خاصية [**IErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/php-java/aspose.slides/IErrorBarsFormat#getValue--) مساوية لـ **Custom**. لتحديد قيمة، استخدم الخاصية **ErrorBarCustomValues** لنقطة بيانات معينة في مجموعة [**DataPoints**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartSeriesCollection) الخاصة بالسلسلة:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. إضافة مخطط فقاعي إلى الشريحة المطلوبة.
1. الوصول إلى أول سلسلة مخطط وتعيين تنسيق شريط الخطأ X.
1. الوصول إلى أول سلسلة مخطط وتعيين تنسيق شريط الخطأ Y.
1. الوصول إلى نقاط البيانات الفردية لسلسلة المخطط وتعيين قيم شريط الخطأ لنقطة البيانات الفردية في السلسلة.
1. تعيين قيم الأشرطة وتنسيقها.
1. كتابة العرض التقديمي المعدل إلى ملف PPTX.
```php
  # إنشاء كائن من فئة Presentation
  $pres = new Presentation();
  try {
    # إنشاء مخطط فقاعة
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 400, 300, true);
    # إضافة أشرطة الخطأ المخصصة وتعيين تنسيقها
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $errBarX = $series->getErrorBarsXFormat();
    $errBarY = $series->getErrorBarsYFormat();
    $errBarX->isVisible();
    $errBarY->isVisible();
    $errBarX->setValueType(ErrorBarValueType::Custom);
    $errBarY->setValueType(ErrorBarValueType::Custom);
    # الوصول إلى نقطة بيانات سلسلة المخطط وتعيين قيم أشرطة الخطأ لـ
    # النقطة الفردية
    $points = $series->getDataPoints();
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForXPlusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForXMinusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForYPlusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForYMinusValues(DataSourceType::DoubleLiterals);
    # تعيين أشرطة الخطأ لنقاط سلسلة المخطط
    for($i = 0; $i < java_values($points->size()) ; $i++) {
      $points->get_Item($i)->getErrorBarsCustomValues()->getXMinus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getXPlus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getYMinus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getYPlus()->setAsLiteralDouble($i + 1);
    }
    # حفظ العرض التقديمي
    $pres->save("ErrorBarsCustomValues.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **الأسئلة المتكررة**

**ماذا يحدث لأشرطة الخطأ عند تصدير عرض تقديمي إلى PDF أو صور؟**

يتم رسمها كجزء من المخطط وتُحافظ عليها أثناء التحويل مع بقية تنسيقات المخطط، بشرط أن يكون الإصدار أو المُحرك متوافقًا.

**هل يمكن دمج أشرطة الخطأ مع العلامات وملصقات البيانات؟**

نعم. أشرطة الخطأ عنصر منفصل ومتوافق مع العلامات وملصقات البيانات؛ إذا تداخلت العناصر، قد تحتاج إلى تعديل التنسيق.

**أين يمكن العثور على قائمة الخصائص والفئات الخاصة بالعمل مع أشرطة الخطأ في واجهة برمجة التطبيقات؟**

في مرجع واجهة برمجة التطبيقات: الفئة [ErrorBarsFormat](https://reference.aspose.com/slides/php-java/aspose.slides/errorbarsformat/) والفئات المتعلقة [ErrorBarType](https://reference.aspose.com/slides/php-java/aspose.slides/errorbartype/) و[ErrorBarValueType](https://reference.aspose.com/slides/php-java/aspose.slides/errorbarvaluetype/).