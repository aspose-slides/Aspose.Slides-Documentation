---
title: تخصيص خطوط الأخطاء في مخططات العروض التقديمية باستخدام PHP
linktitle: خط الأخطاء
type: docs
url: /ar/php-java/error-bar/
keywords:
- خط الأخطاء
- قيمة مخصصة
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تعلم كيف تضيف وتخصص خطوط الأخطاء في المخططات باستخدام Aspose.Slides للـ PHP عبر Java — تحسين تصورات البيانات في عروض PowerPoint التقديمية."
---

## **إضافة خطوط الأخطاء**
Aspose.Slides for PHP via Java توفر واجهة برمجة تطبيقات بسيطة لإدارة قيم خطوط الأخطاء. يُطبق رمز العينة عند استخدام نوع قيمة مخصص. لتحديد قيمة، استخدم الخاصية **ErrorBarCustomValues** لنقطة بيانات محددة في مجموعة [**نقاط البيانات**](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriescollection/) للسلسلة:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. إضافة مخطط فقاعة إلى الشريحة المطلوبة.
1. الوصول إلى أول سلسلة مخطط وتعيين تنسيق خط الخطأ X.
1. الوصول إلى أول سلسلة مخطط وتعيين تنسيق خط الخطأ Y.
1. تعيين قيم الخطوط وتنسيقها.
1. حفظ العرض التقديمي المعدل إلى ملف PPTX.
```php
  # إنشاء مثيل من فئة Presentation
  $pres = new Presentation();
  try {
    # إنشاء مخطط فقاعة
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 400, 300, true);
    # إضافة خطوط الأخطاء وتعيين تنسيقها
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


## **إضافة قيم مخصصة لخطوط الأخطاء**
Aspose.Slides for PHP via Java توفر واجهة برمجة تطبيقات بسيطة لإدارة قيم خطوط الأخطاء المخصصة. يُطبق رمز العينة عندما تُعيد الطريقة [**ErrorBarsFormat::getValueType**](https://reference.aspose.com/slides/php-java/aspose.slides/errorbarsformat/#getValueType) القيمة **Custom**. لتحديد قيمة، استخدم الخاصية **ErrorBarCustomValues** لنقطة بيانات محددة في مجموعة [**نقاط البيانات**](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriescollection/) للسلسلة:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. إضافة مخطط فقاعة إلى الشريحة المطلوبة.
1. الوصول إلى أول سلسلة مخطط وتعيين تنسيق خط الخطأ X.
1. الوصول إلى أول سلسلة مخطط وتعيين تنسيق خط الخطأ Y.
1. الوصول إلى نقاط البيانات الفردية لسلسلة المخطط وتعيين قيم خط الخطأ لنقطة البيانات الفردية في السلسلة.
1. تعيين قيم الخطوط وتنسيقها.
1. حفظ العرض التقديمي المعدل إلى ملف PPTX.
```php
  # إنشاء مثيل من فئة Presentation
  $pres = new Presentation();
  try {
    # إنشاء مخطط فقاعة
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 400, 300, true);
    # إضافة خطوط خطأ مخصصة وتعيين تنسيقها
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $errBarX = $series->getErrorBarsXFormat();
    $errBarY = $series->getErrorBarsYFormat();
    $errBarX->isVisible();
    $errBarY->isVisible();
    $errBarX->setValueType(ErrorBarValueType::Custom);
    $errBarY->setValueType(ErrorBarValueType::Custom);
    # الوصول إلى نقطة بيانات سلسلة المخطط وتعيين قيم خطوط الخطأ لـ
    # نقطة فردية
    $points = $series->getDataPoints();
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForXPlusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForXMinusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForYPlusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForYMinusValues(DataSourceType::DoubleLiterals);
    # تعيين خطوط الخطأ لنقاط سلسلة المخطط
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


## **الأسئلة الشائعة**

**ماذا يحدث لخطوط الأخطاء عند تصدير عرض تقديمي إلى PDF أو صور؟**
يتم عرضها كجزء من المخطط وتُحفظ أثناء التحويل مع بقية تنسيق المخطط، بافتراض وجود نسخة أو معالج متوافق.

**هل يمكن دمج خطوط الأخطاء مع العلامات وملصقات البيانات؟**
نعم. خطوط الأخطاء عنصر منفصل ومتوافق مع العلامات وملصقات البيانات؛ إذا تداخلت العناصر، قد تحتاج إلى تعديل التنسيق.

**أين يمكنني العثور على قائمة الخصائص والفئات الخاصة بالتعامل مع خطوط الأخطاء في واجهة برمجة التطبيقات؟**
في مرجع واجهة برمجة التطبيقات: الفئة [ErrorBarsFormat](https://reference.aspose.com/slides/php-java/aspose.slides/errorbarsformat/) والفئات المرتبطة [ErrorBarType](https://reference.aspose.com/slides/php-java/aspose.slides/errorbartype/) و[ErrorBarValueType](https://reference.aspose.com/slides/php-java/aspose.slides/errorbarvaluetype/).