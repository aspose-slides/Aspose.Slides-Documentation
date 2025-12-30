---
title: تخصيص وسائط إيضاح المخطط في العروض التقديمية باستخدام PHP
linktitle: وسيلة إيضاح المخطط
type: docs
url: /ar/php-java/chart-legend/
keywords:
- وسيلة إيضاح المخطط
- موضع وسيلة الإيضاح
- حجم الخط
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تخصيص وسائط إيضاح المخطط باستخدام Aspose.Slides for PHP عبر Java لتحسين عروض PowerPoint التقديمية مع تنسيق مخصص للوسائط."
---

## **تموضع وسيلة الإيضاح**
لضبط خصائص وسيلة الإيضاح. يرجى اتباع الخطوات التالية:

- إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- الحصول على مرجع الشريحة.
- إضافة مخطط إلى الشريحة.
- ضبط خصائص وسيلة الإيضاح.
- حفظ العرض التقديمي كملف PPTX.

في المثال أدناه، قمنا بتعيين الموضع والحجم لوسيلة إيضاح المخطط.
```php
  # إنشاء كائن من فئة Presentation
  $pres = new Presentation();
  try {
    # الحصول على مرجع الشريحة
    $slide = $pres->getSlides()->get_Item(0);
    # إضافة مخطط عمودي مجمع إلى الشريحة
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 500);
    # تعيين خصائص وسيلة الإيضاح
    $chart->getLegend()->setX(50 / $chart->getWidth());
    $chart->getLegend()->setY(50 / $chart->getHeight());
    $chart->getLegend()->setWidth(100 / $chart->getWidth());
    $chart->getLegend()->setHeight(100 / $chart->getHeight());
    # حفظ العرض التقديمي إلى القرص
    $pres->save("Legend_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **تحديد حجم الخط لوسيلة الإيضاح**
يتيح Aspose.Slides for PHP via Java للمطورين ضبط حجم الخط لوسيلة الإيضاح. يرجى اتباع الخطوات التالية:

- إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- إنشاء المخطط الافتراضي.
- ضبط حجم الخط.
- تعيين الحد الأدنى لقيمة المحور.
- تعيين الحد الأقصى لقيمة المحور.
- حفظ العرض التقديمي على القرص.
```php
  # إنشاء كائن من فئة Presentation
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


## **تحديد حجم الخط لوسيلة إيضاح فردية**
يتيح Aspose.Slides for PHP via Java للمطورين ضبط حجم الخط لعنصر وسيلة إيضاح منفرد. يرجى اتباع الخطوات التالية:

- إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- إنشاء المخطط الافتراضي.
- الوصول إلى عنصر وسيلة الإيضاح.
- ضبط حجم الخط.
- تعيين الحد الأدنى لقيمة المحور.
- تعيين الحد الأقصى لقيمة المحور.
- حفظ العرض التقديمي على القرص.
```php
  # إنشاء مثيل من فئة Presentation
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


## **الأسئلة المتكررة**

**هل يمكن تمكين وسيلة الإيضاح بحيث يخصص المخطط مساحة لها تلقائيًا بدلاً من تغطيتها؟**

نعم. استخدم وضع عدم التراكب ([setOverlay(false)](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setoverlay/)); في هذه الحالة سيصغر منطقة الرسم لتستوعب وسيلة الإيضاح.

**هل يمكن إنشاء تسميات وسيلة إيضاح متعددة الأسطر؟**

نعم. تسميات طويلة تُكسر تلقائيًا عندما تكون المساحة غير كافية؛ كما تدعم فواصل الأسطر القسرية عبر أحرف السطر الجديد في اسم السلسلة.

**كيف أجعل وسيلة الإيضاح تتبع مخطط ألوان ثيم العرض التقديمي؟**

لا تقم بتعيين ألوان/تعبئات/خطوط صريحة لوسيلة الإيضاح أو نصها. سيتوارث ذلك من الثيم وسيتم تحديثه بشكل صحيح عند تغيير التصميم.