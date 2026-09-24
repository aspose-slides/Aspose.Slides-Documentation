---
title: تخصيص جداول بيانات المخططات في العروض التقديمية باستخدام PHP
linktitle: جدول البيانات
type: docs
url: /ar/php-java/chart-data-table/
keywords:
- بيانات المخطط
- جدول البيانات
- خصائص الخط
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تخصيص خطوط جداول بيانات المخططات، والحدود، ومفاتيح الوسيلة في عروض PowerPoint التقديمية باستخدام Aspose.Slides للـ PHP عبر Java."
---
## **نظرة عامة**

تمكِّن Aspose.Slides for PHP via Java من عرض جدول بيانات المخطط وتخصيص تنسيق النص والحدود ومفاتيح الوسيلة. يوضح هذا المقال كيفية تمكين الجدول، تنسيق النص، التحكم في كل نوع من الحدود، وإظهار أو إخفاء مفاتيح الوسيلة. تحفظ الأمثلة المخططات المُكوَّنة في ملفات PPTX.

## **تعيين خصائص الخط**

لعرض جدول بيانات المخطط، مرّر `true` إلى [setDataTable](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chart/setdatatable/). استخدم [getChartDataTable](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chart/getchartdatatable/) للوصول إلى الجدول وتكوين تنسيق النص.

1. حمّل العرض التقديمي باستخدام فئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/).
1. أضف مخطط أعمدة متجمع إلى الشريحة الأولى.
1. فعّل جدول بيانات المخطط.
1. فعّل النص العريض باستخدام [setFontBold](https://reference.aspose.com/slides/ar/php-java/aspose.slides/baseportionformat/#setFontBold) ومرّر `20` إلى [setFontHeight](https://reference.aspose.com/slides/ar/php-java/aspose.slides/baseportionformat/#setFontHeight) للحصول على نص بحجم 20 نقطة.
1. احفظ العرض التقديمي المعدَّل.

يتطلب المثال التالي وجود ملف `test.pptx` في الدليل العامل مع شريحة واحدة على الأقل. يضيف مخططًا ببيانات افتراضية في الموقع (50, 50)، بعرض 600 نقطة وارتفاع 400 نقطة. يحتوي الملف المحفوظ `output.pptx` على المخطط مع تمكين جدول البيانات وتطبيق إعدادات الخط المحددة.

```php
use aspose\slides\ChartType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("test.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);

    $portionFormat = $chart->getChartDataTable()->getTextFormat()->getPortionFormat();
    $portionFormat->setFontBold(NullableBool::True);
    $portionFormat->setFontHeight(20);

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **تخصيص حدود جدول البيانات**

فعّل الجدول باستخدام [Chart::setDataTable](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chart/setdatatable/) وواصله عبر [Chart::getChartDataTable](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chart/getchartdatatable/). يمكنك التحكم في ثلاثة أنواع من الحدود بشكل مستقل:

- [setBorderHorizontal](https://reference.aspose.com/slides/ar/php-java/aspose.slides/datatable/setborderhorizontal/) يتحكم في حدود الخلايا الأفقية.
- [setBorderVertical](https://reference.aspose.com/slides/ar/php-java/aspose.slides/datatable/setbordervertical/) يتحكم في حدود الخلايا العمودية.
- [setBorderOutline](https://reference.aspose.com/slides/ar/php-java/aspose.slides/datatable/setborderoutline/) يتحكم في الحدود الخارجية للجدول.

مرّر `true` إلى كل طريقة لعرض حدودها أو `false` لإخفائها. يُنشئ المثال التالي مخطط أعمدة متجمع ببيانات افتراضية، يعرض الحدود الأفقية والحد الخارجي، ويخفي الحدود العمودية. لا يتطلب أي ملف إدخال. يتم تحديد موقع وحجم المخطط بالنقاط.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);

    $dataTable = $chart->getChartDataTable();
    $dataTable->setBorderHorizontal(true);
    $dataTable->setBorderVertical(false);
    $dataTable->setBorderOutline(true);

    $presentation->save("data-table-borders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

المقارنة أدناه تستخدم نفس بيانات المخطط وإعداد مفتاح الوسيلة في جميع الحالات الأربعة. بدءًا من تمكين جميع الحدود، يعطل كل متغيّر باقيًا حدًا واحدًا فقط. المتغيّر في الزاوية السفلية اليسرى يطابق إعدادات الحدود في المثال.

![جداول بيانات المخطط مع تمكين جميع الحدود، بدون حدود أفقية، بدون حدود عمودية، وبدون حد خارجي](data-table-borders.png)

## **إظهار أو إخفاء مفاتيح الوسيلة**

مفاتيح الوسيلة هي علامات ملونة صغيرة بجانب أسماء السلاسل في جدول البيانات. تساعد القارئ على مطابقة كل صف من الجدول مع سلسلة المخطط. مرّر `true` إلى [setShowLegendKey](https://reference.aspose.com/slides/ar/php-java/aspose.slides/datatable/setshowlegendkey/) لإظهار هذه العلامات أو `false` لإخفائها.

يتم التحكم في الوسيلة المنفصلة للمخطط عبر [Chart::setLegend](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chart/setlegend/). هذه الإعدادات مستقلة: إخفاء الوسيلة المنفصلة لا يخفى المفاتيح داخل جدول البيانات، وإخفاء مفاتيح الجدول لا يخفى الوسيلة المنفصلة.

ينشئ المثال التالي مخططًا ببيانات افتراضية، يفعّل جدول البيانات، ويظهر مفاتيح الوسيلة داخله مع إخفاء الوسيلة المنفصلة. جميع حدود الجدول مفعَّلة صراحةً. لا يلزم أي عرض تقديمي إدخال. لإخفاء مفاتيح الجدول فقط، مرّر `false` إلى [setShowLegendKey](https://reference.aspose.com/slides/ar/php-java/aspose.slides/datatable/setshowlegendkey/).

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);
    $chart->setLegend(false);

    $dataTable = $chart->getChartDataTable();
    $dataTable->setBorderHorizontal(true);
    $dataTable->setBorderVertical(true);
    $dataTable->setBorderOutline(true);
    $dataTable->setShowLegendKey(true);

    $presentation->save("data-table-legend-keys.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

المقارنة أدناه تُظهر نفس الجدول مع تمكين مفاتيح الوسيلة وتعطيلها. تبقى جميع الحدود مفعَّلة، وتظل الوسيلة المنفصلة للمخطط مخفية في الحالتين.

![جداول بيانات المخطط مع مفاتيح الوسيلة معروضة على اليسار ومخفاة على اليمين](data-table-legend-keys.png)

## **الأسئلة المتكررة**

**هل يمكنني إظهار مفاتيح الوسيلة في جدول بيانات المخطط؟**

نعم. مرّر `true` إلى [setShowLegendKey](https://reference.aspose.com/slides/ar/php-java/aspose.slides/datatable/setshowlegendkey/) لعرض مفاتيح الوسيلة أو `false` لإخفائها.

**هل سيُحافظ على جدول البيانات عند تصدير العرض التقديمي إلى PDF أو HTML أو صور؟**

نعم. تقوم Aspose.Slides برسم المخطط وجدول البيانات المعروض كجزء من الشريحة عند التصدير إلى [PDF](/slides/ar/php-java/convert-powerpoint-to-pdf/)، [HTML](/slides/ar/php-java/convert-powerpoint-to-html/)، أو [الصور](/slides/ar/php-java/convert-powerpoint-to-png/).

**هل يمكنني التعامل مع جداول البيانات في المخططات التي تم تحميلها من قالب؟**

نعم. للمخطط المحمَّل من عرض تقديمي أو قالب موجود، استخدم [hasDataTable](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chart/hasdatatable/) و[setDataTable](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chart/setdatatable/) للتحقق أو تعديل ما إذا كان جدول البيانات معروضًا.

**كيف يمكنني العثور على المخططات التي تم تمكين جدول البيانات لها؟**

قم بالت iterating عبر الأشكال في كل شريحة، حدد المخططات، واستدعِ طريقة [hasDataTable](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chart/hasdatatable/) الخاصة بها. القيمة `true` تدل على أن جدول البيانات مفعَّل.