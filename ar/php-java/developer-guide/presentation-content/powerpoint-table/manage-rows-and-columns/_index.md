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
- عنوان الجدول
- استنساخ الصف
- استنساخ العمود
- نسخ الصف
- نسخ العمود
- إزالة الصف
- إزالة العمود
- تنسيق نص الصف
- تنسيق نص العمود
- نمط الجدول
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "إدارة صفوف وأعمدة الجدول في PowerPoint باستخدام Aspose.Slides للـ PHP عبر Java وتسريع تحرير العروض التقديمية وتحديث البيانات."
---

لتمكينك من إدارة صفوف وأعمدة الجدول في عرض تقديمي PowerPoint، توفر Aspose.Slides الفئة [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) والعديد من الأنواع الأخرى.

## **ضبط الصف الأول كعنوان**

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) وتحميل العرض التقديمي.  
2. الحصول على مرجع الشريحة عبر فهرستها.  
3. إنشاء كائن [Table](https://reference.aspose.com/slides/php-java/aspose.slides/Table) وتعيينه إلى null.  
4. التكرار عبر جميع كائنات [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) للعثور على الجدول المناسب.  
5. تعيين الصف الأول للجدول كعنوان.  

يظهر لك هذا الكود PHP كيفية تعيين الصف الأول للجدول كعنوان:
```php
  # إنشاء كائن من فئة Presentation
  $pres = new Presentation("table.pptx");
  try {
    # الوصول إلى الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # تهيئة TableEx إلى null
    $tbl = null;
    # التكرار عبر الأشكال وتعيين مرجع إلى الجدول
    foreach($sld->getShapes() as $shp) {
      if (java_instanceof($shp, new JavaClass("com.aspose.slides.Table"))) {
        $tbl = $shp;
        # تعيين الصف الأول من الجدول كعنوان
        $tbl->setFirstRow(true);
      }
    }
    # حفظ العرض التقديمي إلى القرص
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **استنساخ صف أو عمود من جدول**

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) وتحميل العرض التقديمي،  
2. الحصول على مرجع الشريحة عبر فهرستها.  
3. تعريف مصفوفة `columnWidth`.  
4. تعريف مصفوفة `rowHeight`.  
5. إضافة كائن [Table](https://reference.aspose.com/slides/php-java/aspose.slides/Table) إلى الشريحة عبر الطريقة [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/).  
6. استنساخ صف الجدول.  
7. استنساخ عمود الجدول.  
8. حفظ العرض التقديمي المعدل.  

يظهر لك هذا الكود PHP كيفية استنساخ صف أو عمود من جدول PowerPoint:
```php
  # إنشاء كائن من فئة Presentation
  $pres = new Presentation("Test.pptx");
  try {
    # الوصول إلى الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # تعريف الأعمدة بعروضها والصفوف بارتفاعاتها
    $dblCols = array(50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # إضافة شكل جدول إلى الشريحة
    $table = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # إضافة بعض النص إلى الصف 1 الخلية 1
    $table->get_Item(0, 0)->getTextFrame()->setText("Row 1 Cell 1");
    # إضافة بعض النص إلى الصف 1 الخلية 2
    $table->get_Item(1, 0)->getTextFrame()->setText("Row 1 Cell 2");
    # استنساخ الصف 1 في نهاية الجدول
    $table->getRows()->addClone($table->getRows()->get_Item(0), false);
    # إضافة بعض النص إلى الصف 2 الخلية 1
    $table->get_Item(0, 1)->getTextFrame()->setText("Row 2 Cell 1");
    # إضافة بعض النص إلى الصف 2 الخلية 2
    $table->get_Item(1, 1)->getTextFrame()->setText("Row 2 Cell 2");
    # استنساخ الصف 2 كصف رابع في الجدول
    $table->getRows()->insertClone(3, $table->getRows()->get_Item(1), false);
    # استنساخ العمود الأول في النهاية
    $table->getColumns()->addClone($table->getColumns()->get_Item(0), false);
    # استنساخ العمود الثاني عند الفهرس الرابع للعمود
    $table->getColumns()->insertClone(3, $table->getColumns()->get_Item(1), false);
    # حفظ العرض التقديمي إلى القرص
    $pres->save("table_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **إزالة صف أو عمود من جدول**

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) وتحميل العرض التقديمي،  
2. الحصول على مرجع الشريحة عبر فهرستها.  
3. تعريف مصفوفة `columnWidth`.  
4. تعريف مصفوفة `rowHeight`.  
5. إضافة كائن [Table](https://reference.aspose.com/slides/php-java/aspose.slides/Table) إلى الشريحة عبر الطريقة [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/).  
6. إزالة صف الجدول.  
7. إزالة عمود الجدول.  
8. حفظ العرض التقديمي المعدل.  

يظهر لك هذا الكود PHP كيفية إزالة صف أو عمود من جدول:
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

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) وتحميل العرض التقديمي،  
2. الحصول على مرجع الشريحة عبر فهرستها.  
3. الوصول إلى كائن [Table](https://reference.aspose.com/slides/php-java/aspose.slides/Table) المناسب من الشريحة.  
4. تعيين ارتفاع الخط للخلية في الصف الأول عبر [setFontHeight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight).  
5. تعيين محاذاة الخلايا في الصف الأول عبر [setAlignment(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) و [setMarginRight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/).  
6. تعيين نوع النص العمودي للخلية في الصف الثاني عبر [setTextVerticalType(byte value)](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/).  
7. حفظ العرض التقديمي المعدل.  

هذا الكود PHP يوضح العملية.
```php
  # إنشاء كائن من فئة Presentation
  $pres = new Presentation();
  try {
    # نفترض أن الشكل الأول في الشريحة الأولى هو جدول
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # تعيين ارتفاع الخط لخلية الصف الأول
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->getRows()->get_Item(0)->setTextFormat($portionFormat);
    # تعيين محاذاة النص وهوامش اليمين لخلايا الصف الأول
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->getRows()->get_Item(0)->setTextFormat($paragraphFormat);
    # تعيين نوع الاتجاه العمودي للنص في خلايا الصف الثاني
    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat::setTextVerticalType(TextVerticalType::Vertical);
    $someTable->getRows()->get_Item(1)->setTextFormat($textFrameFormat);
    # حفظ العرض التقديمي إلى القرص
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **ضبط تنسيق النص على مستوى عمود الجدول**

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) وتحميل العرض التقديمي،  
2. الحصول على مرجع الشريحة عبر فهرستها.  
3. الوصول إلى كائن [Table](https://reference.aspose.com/slides/php-java/aspose.slides/Table) المناسب من الشريحة.  
4. تعيين ارتفاع الخط للخلية في العمود الأول عبر [setFontHeight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight).  
5. تعيين محاذاة الخلايا في العمود الأول عبر [setAlignment(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) و [setMarginRight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/).  
6. تعيين نوع النص العمودي للخلية في العمود الثاني عبر [setTextVerticalType(byte value)](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/).  
7. حفظ العرض التقديمي المعدل.  

هذا الكود PHP يوضح العملية:
```php
  # إنشاء كائن من فئة Presentation
  $pres = new Presentation();
  try {
    # لنفترض أن الشكل الأول في الشريحة الأولى هو جدول
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # تعيين ارتفاع الخط لخلايا العمود الأول
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->getColumns()->get_Item(0)->setTextFormat($portionFormat);
    # تعيين محاذاة النص وهوامش اليمين لخلايا العمود الأول في استدعاء واحد
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->getColumns()->get_Item(0)->setTextFormat($paragraphFormat);
    # تعيين نوع الاتجاه العمودي للنص في خلايا العمود الثاني
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

يسمح لك Aspose.Slides باسترجاع خصائص النمط لجدول بحيث يمكنك استخدام هذه التفاصيل لجدول آخر أو في مكان آخر. يُظهر لك هذا الكود PHP كيفية الحصول على خصائص النمط من نمط جدول مسبق:
```php
  $pres = new Presentation();
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->addTable(10, 10, array(100, 150 ), array(5, 5, 5 ));
    $table->setStylePreset(TableStylePreset->DarkStyle1);// تغيير نمط الإعداد المسبق الافتراضي

    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **الأسئلة الشائعة**

**هل يمكنني تطبيق سمات/أنماط PowerPoint على جدول تم إنشاءه بالفعل؟**

نعم. الجدول يرث سمة الشريحة/التخطيط/الماستر، ولا يزال بإمكانك تجاوز التعبئات والحدود وألوان النص فوق تلك السمة.

**هل يمكنني فرز صفوف الجدول كما في Excel؟**

لا، جداول Aspose.Slides لا تحتوي على فرز أو فلاتر مدمجة. قم بفرز البيانات في الذاكرة أولاً، ثم أعد ملء صفوف الجدول وفق ذلك الترتيب.

**هل يمكنني الحصول على أعمدة متناوبة (مخططة) مع الحفاظ على ألوان مخصصة لخلايا محددة؟**

نعم. فعّل الأعمدة المتناوبة، ثم تجاوز الخلايا المحددة بالتنسيق المحلي؛ تنسيق الخلية على مستوى الخلية يتفوق على نمط الجدول.