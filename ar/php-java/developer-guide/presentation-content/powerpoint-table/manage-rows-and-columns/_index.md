---
title: إدارة الصفوف والأعمدة
type: docs
weight: 20
url: /php-java/manage-rows-and-columns/
keywords: "جدول، صفوف وأعمدة الجدول، عرض PowerPoint، Java، Aspose.Slides لـ PHP عبر Java"
description: "إدارة صفوف وأعمدة الجدول في عروض PowerPoint"
---

لتمكينك من إدارة صفوف وأعمدة جدول في عرض PowerPoint، توفر Aspose.Slides فئة [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) وواجهة [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) والعديد من الأنواع الأخرى.

## **تحديد الصف الأول كعنوان**

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) وقم بتحميل العرض التقديمي.
2. احصل على مرجع للشريحة من خلال فهرسها.
3. أنشئ كائن [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) وقم بتعيينه-null.
4. تكرر عبر جميع كائنات [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/ishape/) للعثور على الجدول المعني.
5. عيّن الصف الأول من الجدول كعنوان له.

يعرض هذا الكود PHP كيفية تعيين الصف الأول لجدول كعنوان له:

```php
  # يقوم بإنشاء مثيل من فئة Presentation
  $pres = new Presentation("table.pptx");
  try {
    # يصل إلى الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # يهيء TableEx إلى null
    $tbl = null;
    # يتكرر عبر الأشكال ويعين مرجعًا للجدول
    foreach($sld->getShapes() as $shp) {
      if (java_instanceof($shp, new JavaClass("com.aspose.slides.Table"))) {
        $tbl = $shp;
        # يعين الصف الأول كعنوان للجدول
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


## **نسخ صف أو عمود من الجدول**

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) وقم بتحميل العرض التقديمي،
2. احصل على مرجع للشريحة من خلال فهرسها.
3. عرّف مصفوفة من `columnWidth`.
4. عرّف مصفوفة من `rowHeight`.
5. أضف كائن [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) إلى الشريحة من خلال طريقة [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/ishapecollection/#addTable-float-float-double---double---).
6. انسخ صف الجدول.
7. انسخ عمود الجدول.
8. احفظ العرض التقديمي المعدل.

يعرض هذا الكود PHP كيفية نسخ صف أو عمود من جدول PowerPoint:

```php
  # يقوم بإنشاء مثيل من فئة Presentation
  $pres = new Presentation("Test.pptx");
  try {
    # يصل إلى الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # يحدد أعمدة بعرض وصفوف بارتفاع
    $dblCols = array(50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # يضيف شكل جدول إلى الشريحة
    $table = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # يضيف بعض النصوص إلى الخلية 1 في الصف 1
    $table->get_Item(0, 0)->getTextFrame()->setText("الصف 1 الخلية 1");
    # يضيف بعض النصوص إلى الخلية 2 في الصف 1
    $table->get_Item(1, 0)->getTextFrame()->setText("الصف 1 الخلية 2");
    # ينسخ الصف 1 في نهاية الجدول
    $table->getRows()->addClone($table->getRows()->get_Item(0), false);
    # يضيف بعض النصوص إلى الخلية 1 في الصف 2
    $table->get_Item(0, 1)->getTextFrame()->setText("الصف 2 الخلية 1");
    # يضيف بعض النصوص إلى الخلية 2 في الصف 2
    $table->get_Item(1, 1)->getTextFrame()->setText("الصف 2 الخلية 2");
    # ينسخ الصف 2 كصف رابع من الجدول
    $table->getRows()->insertClone(3, $table->getRows()->get_Item(1), false);
    # ينسخ العمود الأول في النهاية
    $table->getColumns()->addClone($table->getColumns()->get_Item(0), false);
    # ينسخ العمود الثاني في فهرس العمود الرابع
    $table->getColumns()->insertClone(3, $table->getColumns()->get_Item(1), false);
    # يحفظ العرض التقديمي على القرص
    $pres->save("table_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **إزالة صف أو عمود من الجدول**

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) وقم بتحميل العرض التقديمي،
2. احصل على مرجع للشريحة من خلال فهرسها.
3. عرّف مصفوفة من `columnWidth`.
4. عرّف مصفوفة من `rowHeight`.
5. أضف كائن [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) إلى الشريحة من خلال طريقة [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/ishapecollection/#addTable-float-float-double---double---).
6. أزل صف الجدول.
7. أزل عمود الجدول.
8. احفظ العرض التقديمي المعدل.

يعرض هذا الكود PHP كيفية إزالة صف أو عمود من جدول:

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

## **تعيين تنسيق النص على مستوى صف الجدول**

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) وقم بتحميل العرض التقديمي،
2. احصل على مرجع للشريحة من خلال فهرسها.
3. الوصول إلى كائن [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) المعني من الشريحة.
4. عيّن خلايا الصف الأول [setFontHeight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight-float-).
5. عيّن خلايا الصف الأول [setAlignment(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraphformat/#setAlignment-int-) و [setMarginRight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraphformat/#setMarginRight-float-).
6. عيّن خلايا الصف الثاني [setTextVerticalType(byte value)](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. احفظ العرض التقديمي المعدل.

يعرض هذا الكود PHP العملية.

```php
  # يقوم بإنشاء مثيل من فئة Presentation
  $pres = new Presentation();
  try {
    # لنفترض أن الشكل الأول على الشريحة الأولى هو جدول
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # تعيين ارتفاع خط خلايا الصف الأول
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->getRows()->get_Item(0)->setTextFormat($portionFormat);
    # تعيين محاذاة النص في خلايا الصف الأول والهامش الأيمن
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->getRows()->get_Item(0)->setTextFormat($paragraphFormat);
    # تعيين نوع النص العمودي لخلايا الصف الثاني
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

## **تعيين تنسيق النص على مستوى عمود الجدول**

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) وقم بتحميل العرض التقديمي،
2. احصل على مرجع للشريحة من خلال فهرسها.
3. الوصول إلى كائن [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) المعني من الشريحة.
4. عيّن خلايا العمود الأول [setFontHeight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight-float-).
5. عيّن خلايا العمود الأول [setAlignment(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraphformat/#setAlignment-int-) و [setMarginRight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraphformat/#setMarginRight-float-).
6. عيّن خلايا العمود الثاني [setTextVerticalType(byte value)](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. احفظ العرض التقديمي المعدل.

يعرض هذا الكود PHP العملية:

```php
  # يقوم بإنشاء مثيل من فئة Presentation
  $pres = new Presentation();
  try {
    # لنفترض أن الشكل الأول على الشريحة الأولى هو جدول
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # تعيين ارتفاع خط خلايا العمود الأول
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->getColumns()->get_Item(0)->setTextFormat($portionFormat);
    # تعيين محاذاة النص للهامش الأيمن لخلايا العمود الأول في استدعاء واحد
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->getColumns()->get_Item(0)->setTextFormat($paragraphFormat);
    # تعيين نوع النص العمودي لخلايا العمود الثاني
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

تتيح لك Aspose.Slides استرداد خصائص النمط لجدول بحيث يمكنك استخدام هذه التفاصيل لجدول آخر أو في مكان آخر. يعرض هذا الكود PHP كيفية الحصول على خصائص النمط من نمط جدول مُعد مسبقًا:

```php
  $pres = new Presentation();
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->addTable(10, 10, array(100, 150 ), array(5, 5, 5 ));
    $table->setStylePreset(TableStylePreset->DarkStyle1);// تغيير نمط الأساس الافتراضي

    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```