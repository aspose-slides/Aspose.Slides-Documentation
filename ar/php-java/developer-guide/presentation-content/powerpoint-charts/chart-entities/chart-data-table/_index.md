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
description: "خصص جداول بيانات المخططات لملفات PPT و PPTX باستخدام Aspose.Slides لـ PHP عبر Java لتعزيز الكفاءة والجاذبية في العروض التقديمية."
---

## **إعداد خصائص الخط لجدول بيانات المخطط**
توفر Aspose.Slides for PHP عبر Java دعمًا لتغيير لون الفئات في لون السلسلة.  

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. إضافة مخطط إلى الشريحة.
1. ضبط جدول المخطط.
1. تعيين ارتفاع الخط.
1. حفظ العرض التقديمي المعدل.

تم تقديم مثال عيني أدناه.  
```php
  # إنشاء عرض تقديمي فارغ
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);
    $chart->getChartDataTable()->getTextFormat()->getPortionFormat()->setFontBold(NullableBool::True);
    $chart->getChartDataTable()->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **الأسئلة الشائعة**

**هل يمكنني عرض مفاتيح وسيلة إيضاح صغيرة بجوار القيم في جدول بيانات المخطط؟**

نعم. يدعم جدول البيانات [مفاتيح وسيلة الإيضاح](https://reference.aspose.com/slides/php-java/aspose.slides/datatable/setshowlegendkey/)، ويمكنك تشغيلها أو إيقافها.

**هل سيظل جدول البيانات محفوظًا عند تصدير العرض التقديمي إلى PDF أو HTML أو صور؟**

نعم. تقوم Aspose.Slides برندرة المخطط كجزء من الشريحة، لذا فإن الـ[PDF](/slides/ar/php-java/convert-powerpoint-to-pdf/)/[HTML](/slides/ar/php-java/convert-powerpoint-to-html/)/[image](/slides/ar/php-java/convert-powerpoint-to-png/) المُصدّر يتضمن المخطط مع جدول البيانات الخاص به.

**هل يتم دعم جداول البيانات للمخططات التي تأتي من ملف قالب؟**

نعم. لأي مخطط تم تحميله من عرض تقديمي أو قالب موجود، يمكنك فحص وتغيير ما إذا كان جدول البيانات [معروضًا](https://reference.aspose.com/slides/php-java/aspose.slides/chart/hasdatatable/) باستخدام خصائص المخطط.

**كيف يمكنني بسرعة العثور على المخططات في ملف ما التي لديها جدول البيانات ممكّن؟**

قم بفحص خاصية كل مخطط تشير إلى ما إذا كان جدول البيانات [معروضًا](https://reference.aspose.com/slides/php-java/aspose.slides/chart/hasdatatable/) وتكرار المرور عبر الشرائح لتحديد المخططات التي يكون فيها مفعَّلًا.