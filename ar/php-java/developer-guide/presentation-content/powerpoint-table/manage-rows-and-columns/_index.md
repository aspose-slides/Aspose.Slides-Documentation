---
title: إدارة الصفوف والأعمدة في جداول PowerPoint باستخدام PHP
linktitle: الصفوف والأعمدة
type: docs
weight: 20
url: /ar/php-java/manage-rows-and-columns/
keywords:
- صف الجدول
- عمود الجدول
- الصف الأول
- رأس الجدول
- استنساخ صف
- استنساخ عمود
- نسخ صف
- نسخ عمود
- إزالة صف
- إزالة عمود
- تنسيق نص الصف
- تنسيق نص العمود
- نمط الجدول
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "إدارة صفوف وأعمدة الجداول في PowerPoint باستخدام Aspose.Slides للغة PHP عبر Java وتسريع تحرير العروض التقديمية وتحديث البيانات."
---

لتمكينك من إدارة صفوف وأعمدة الجدول في عرض تقديمي PowerPoint، توفر Aspose.Slides فئة [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) ،واجهة [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) والعديد من الأنواع الأخرى.

## **ضبط الصف الأول كعنوان**

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) ثم تحميل العرض التقديمي.  
2. الحصول على مرجع الشريحة عبر فهرستها.  
3. إنشاء كائن [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) وتعيينه إلى null.  
4. التنقل عبر جميع كائنات [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/ishape/) للعثور على الجدول المناسب.  
5. تعيين الصف الأول للجدول كعنوان.  

يوضح لك هذا الكود PHP كيفية تعيين الصف الأول للجدول كعنوان:
```php
  # يقوم بإنشاء كائن من فئة Presentation
  $pres = new Presentation("table.pptx");
  try {
    # الوصول إلى الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # تهيئة كائن TableEx كقيمة فارغة
    $tbl = null;
    # يتكرر عبر الأشكال ويحدد إشارة إلى الجدول
    foreach($sld->getShapes() as $shp) {
      if (java_instanceof($shp, new JavaClass("com.aspose.slides.Table"))) {
        $tbl = $shp;
        # يعين الصف الأول من الجدول كعنوان
        $tbl->setFirstRow(true);
      }
    }
    # يحفظ العرض التقديمي على القرص
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **استنساخ صف أو عمود من جدول**

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) وتحميل العرض التقديمي،  
2. الحصول على مرجع الشريحة عبر فهرستها.  
3. تعريف مصفوفة من `columnWidth`.  
4. تعريف مصفوفة من `rowHeight`.  
5. إضافة كائن [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) إلى الشريحة عبر طريقة [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/ishapecollection/#addTable-float-float-double---double---).  
6. استنساخ صف الجدول.  
7. استنساخ عمود الجدول.  
8. حفظ العرض التقديمي المعدل.  

يوضح لك هذا الكود PHP كيفية استنساخ صف أو عمود من جدول PowerPoint:
```php
  # ينشئ كائنًا من فئة Presentation
  $pres = new Presentation("Test.pptx");
  try {
    # يصل إلى الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # يحدد الأعمدة بعرضها والصفوف بارتفاعها
    $dblCols = array(50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # يضيف شكل جدول إلى الشريحة
    $table = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # يضيف نصًا إلى الصف 1 الخلية 1
    $table->get_Item(0, 0)->getTextFrame()->setText("Row 1 Cell 1");
    # يضيف نصًا إلى الصف 1 الخلية 2
    $table->get_Item(1, 0)->getTextFrame()->setText("Row 1 Cell 2");
    # ينسخ الصف 1 في نهاية الجدول
    $table->getRows()->addClone($table->getRows()->get_Item(0), false);
    # يضيف نصًا إلى الصف 2 الخلية 1
    $table->get_Item(0, 1)->getTextFrame()->setText("Row 2 Cell 1");
    # يضيف نصًا إلى الصف 2 الخلية 2
    $table->get_Item(1, 1)->getTextFrame()->setText("Row 2 Cell 2");
    # ينسخ الصف 2 كصف رابع في الجدول
    $table->getRows()->insertClone(3, $table->getRows()->get_Item(1), false);
    # ينسخ العمود الأول في النهاية
    $table->getColumns()->addClone($table->getColumns()->get_Item(0), false);
    # ينسخ العمود الثاني في الفهرس الرابع
    $table->getColumns()->insertClone(3, $table->getColumns()->get_Item(1), false);
    # يحفظ العرض التقديمي على القرص
    $pres->save("table_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **إزالة صف أو عمود من جدول**

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) وتحميل العرض التقديمي،  
2. الحصول على مرجع الشريحة عبر فهرستها.  
3. تعريف مصفوفة من `columnWidth`.  
4. تعريف مصفوفة من `rowHeight`.  
5. إضافة كائن [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) إلى الشريحة عبر طريقة [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/ishapecollection/#addTable-float-float-double---double---).  
6. إزالة صف الجدول.  
7. إزالة عمود الجدول.  
8. حفظ العرض التقديمي المعدل.  

يوضح لك هذا الكود PHP كيفية إزالة صف أو عمود من جدول:
```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $colWidth = array(100, 50, 30 );
    $rowHeight = array(30, 50, 30 );
    $table = $slide->getShapes()->addTable(100, 100, $colWidth, $rowHeight);
    $table->getRows()->removeAt(1, false);
    $table->getColumns()->removeAt(1, false);
    $pres->save("TestTable_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **ضبط تنسيق النص على مستوى صف الجدول**

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) وتحميل العرض التقديمي،  
2. الحصول على مرجع الشريحة عبر فهرستها.  
3. الوصول إلى كائن [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) المناسب من الشريحة.  
4. تعيين [setFontHeight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight-float-) لخلايا الصف الأول.  
5. تعيين [setAlignment(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraphformat/#setAlignment-int-) و[setMarginRight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraphformat/#setMarginRight-float-) لخلايا الصف الأول.  
6. تعيين [setTextVerticalType(byte value)](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) لخلايا الصف الثاني.  
7. حفظ العرض التقديمي المعدل.  

يوضح هذا الكود PHP العملية.
```php
  # ينشئ مثيلًا من فئة Presentation
  $pres = new Presentation();
  try {
    # لنفترض أن الشكل الأول في الشريحة الأولى هو جدول
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # يضبط ارتفاع الخط لخلايا الصف الأول
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->getRows()->get_Item(0)->setTextFormat($portionFormat);
    # يضبط محاذاة النص والهامش الأيمن لخلايا الصف الأول
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->getRows()->get_Item(0)->setTextFormat($paragraphFormat);
    # يضبط نوع النص العمودي لخلايا الصف الثاني
    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat::setTextVerticalType(TextVerticalType::Vertical);
    $someTable->getRows()->get_Item(1)->setTextFormat($textFrameFormat);
    # يحفظ العرض التقديمي على القرص
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **ضبط تنسيق النص على مستوى عمود الجدول**

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) وتحميل العرض التقديمي،  
2. الحصول على مرجع الشريحة عبر فهرستها.  
3. الوصول إلى كائن [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) المناسب من الشريحة.  
4. تعيين [setFontHeight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight-float-) لخلايا العمود الأول.  
5. تعيين [setAlignment(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraphformat/#setAlignment-int-) و[setMarginRight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraphformat/#setMarginRight-float-) لخلايا العمود الأول.  
6. تعيين [setTextVerticalType(byte value)](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) لخلايا العمود الثاني.  
7. حفظ العرض التقديمي المعدل.  

يوضح هذا الكود PHP العملية:
```php
  # ينشئ مثيلًا من فئة Presentation
  $pres = new Presentation();
  try {
    # لنفترض أن الشكل الأول في الشريحة الأولى هو جدول
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # يضبط ارتفاع الخط لخلايا العمود الأول
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->getColumns()->get_Item(0)->setTextFormat($portionFormat);
    # يضبط محاذاة النص والهامش الأيمن لخلايا العمود الأول في استدعاء واحد
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->getColumns()->get_Item(0)->setTextFormat($paragraphFormat);
    # يضبط نوع النص العمودي لخلايا العمود الثاني
    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat::setTextVerticalType(TextVerticalType::Vertical);
    $someTable->getColumns()->get_Item(1)->setTextFormat($textFrameFormat);
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **الحصول على خصائص نمط الجدول**

تتيح لك Aspose.Slides استرداد خصائص النمط لجدول بحيث يمكنك استخدام هذه التفاصيل لجدول آخر أو في مكان آخر. يوضح لك هذا الكود PHP كيفية الحصول على خصائص النمط من نمط جدول مسبق الإعداد:
```php
  $pres = new Presentation();
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->addTable(10, 10, array(100, 150 ), array(5, 5, 5 ));
    $table->setStylePreset(TableStylePreset->DarkStyle1);// تغيير النمط المسبق الافتراضي

    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **الأسئلة الشائعة**

**هل يمكنني تطبيق سمات/أنماط PowerPoint على جدول تم إنشاؤه بالفعل؟**

نعم. يرث الجدول سمة الشريحة/التخطيط/الماستر، ولا يزال بإمكانك تجاوز التعبئات والحدود وألوان النص فوق تلك السمة.

**هل يمكنني فرز صفوف الجدول كما في Excel؟**

لا، جداول Aspose.Slides لا تحتوي على فرز أو فلاتر مدمجة. قم بفرز البيانات في الذاكرة أولاً، ثم أعد ملء صفوف الجدول وفقًا لهذا الترتيب.

**هل يمكنني الحصول على أعمدة مخططة (متناوبة) مع الحفاظ على ألوان مخصصة لخلايا معينة؟**

نعم. قم بتفعيل الأعمدة المخططة، ثم تجاوز خلايا محددة بالتنسيق المحلي؛ تنسيق الخلية يتفوق على نمط الجدول.