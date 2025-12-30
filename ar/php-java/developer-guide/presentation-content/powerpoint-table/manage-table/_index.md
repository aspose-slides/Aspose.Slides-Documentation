---
title: إدارة جداول العروض التقديمية في PHP
linktitle: إدارة الجدول
type: docs
weight: 10
url: /ar/php-java/manage-table/
keywords:
- إضافة جدول
- إنشاء جدول
- الوصول إلى الجدول
- نسبة العرض إلى الارتفاع
- محاذاة النص
- تنسيق النص
- نمط الجدول
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "إنشاء وتعديل الجداول في شرائح PowerPoint باستخدام Aspose.Slides للـ PHP عبر Java. اكتشف أمثلة رموز بسيطة لتبسيط سير عمل الجداول الخاص بك."
---

جدول في PowerPoint هو وسيلة فعّالة لعرض وتصوير المعلومات. المعلومات في شبكة من الخلايا (المرتبة في صفوف وأعمدة) تكون واضحة وسهلة الفهم.

Aspose.Slides يوفر الفئة [Table](https://reference.aspose.com/slides/php-java/aspose.slides/Table) والواجهة [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) والفئة [Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) والواجهة [ICell](https://reference.aspose.com/slides/php-java/aspose.slides/icell/) وأنواع أخرى للسماح لك بإنشاء وتحديث وإدارة الجداول في جميع أنواع العروض التقديمية.

## **إنشاء جدول من الصفر**

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. الحصول على مرجع الشريحة عبر فهرستها. 
3. تعريف مصفوفة `columnWidth`.
4. تعريف مصفوفة `rowHeight`.
5. إضافة كائن [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) إلى الشريحة عبر طريقة [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-).
6. التجول عبر كل [ICell](https://reference.aspose.com/slides/php-java/aspose.slides/icell/) لتطبيق التنسيق على الحدود العلوية والسفلية واليمينية واليسارية.
7. دمج أول خليتين في الصف الأول للجدول. 
8. الوصول إلى [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) الخاص بـ [ICell](https://reference.aspose.com/slides/php-java/aspose.slides/icell/).
9. إضافة بعض النص إلى [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/).
10. حفظ العرض التقديمي المعدل.

```php
  # ينشئ كائنًا من فئة Presentation تمثل ملف PPTX
  $pres = new Presentation();
  try {
    # ويصل إلى الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # يحدد الأعمدة بعرضها والصفوف بارتفاعها
    $dblCols = array(50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # يضيف شكل جدول إلى الشريحة
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # يضبط تنسيق الحدود لكل خلية
    for($row = 0; $row < java_values($tbl->getRows()->size()) ; $row++) {
      for($cell = 0; $cell < java_values($tbl->getRows()->get_Item($row)->size()) ; $cell++) {
        $cellFormat = $tbl->getRows()->get_Item($row)->get_Item($cell)->getCellFormat();
        $cellFormat::getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderTop()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderTop()->setWidth(5);
        $cellFormat::getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderBottom()->setWidth(5);
        $cellFormat::getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderLeft()->setWidth(5);
        $cellFormat::getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderRight()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderRight()->setWidth(5);
      }
    }
    # يدمج الخلايا 1 و 2 في الصف 1
    $tbl->mergeCells($tbl->getRows()->get_Item(0)->get_Item(0), $tbl->getRows()->get_Item(1)->get_Item(1), false);
    # يضيف بعض النص إلى الخلية المدمجة
    $tbl->getRows()->get_Item(0)->get_Item(0)->getTextFrame()->setText("Merged Cells");
    # يحفظ العرض التقديمي على القرص
    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **الترقيم في جدول قياسي**

في جدول قياسي، ترقيم الخلايا بسيط ويبدأ من الصفر. الخلية الأولى في الجدول تكون مؤشرة كـ 0,0 (العمود 0، الصف 0). 

على سبيل المثال، الخلايا في جدول يحتوي على 4 أعمدة و4 صفوف تُرقَّم بهذه الطريقة:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

```php
  # ينشئ فئة Presentation تمثل ملف PPTX
  $pres = new Presentation();
  try {
    # يصل إلى الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # يعرف الأعمدة بعرضها والصفوف بارتفاعها
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # يضيف شكل جدول إلى الشريحة
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # يضبط تنسيق الحدود لكل خلية
    foreach($tbl->getRows() as $row) {
      foreach($row as $cell) {
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderTop()->setWidth(5);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderBottom()->setWidth(5);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderLeft()->setWidth(5);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderRight()->setWidth(5);
      }
    }
    # يحفظ العرض التقديمي إلى القرص
    $pres->save("StandardTables_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **الوصول إلى جدول موجود**

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).

2. الحصول على مرجع الشريحة التي تحتوي على الجدول عبر فهرستها. 

3. إنشاء كائن [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) وتعيينه إلى null.

4. التجول عبر جميع كائنات [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/ishape/) حتى يتم العثور على الجدول.

   إذا كنت تشك أن الشريحة التي تتعامل معها تحتوي على جدول واحد فقط، يمكنك ببساطة فحص جميع الأشكال التي تحتويها. عندما يتم التعرف على الشكل كجدول، يمكنك تحويله إلى كائن [Table](https://reference.aspose.com/slides/php-java/aspose.slides/Table). ولكن إذا كانت الشريحة تحتوي على عدة جداول، فمن الأفضل البحث عن الجدول المطلوب عبر الخاصية [setAlternativeText(String value)](https://reference.aspose.com/slides/php-java/aspose.slides/ishape/#setAlternativeText-java.lang.String-).

5. استخدام كائن [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) للعمل مع الجدول. في المثال أدناه، قمنا بإضافة صف جديد إلى الجدول.

6. حفظ العرض التقديمي المعدل.

```php
  # ينشئ فئة Presentation التي تمثل ملف PPTX
  $pres = new Presentation("UpdateExistingTable.pptx");
  try {
    # يصل إلى الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # يهيئ TableEx فارغًا
    $tbl = null;
    # يتنقل عبر الأشكال ويحدد مرجعًا للجدول الموجود
    foreach($sld->getShapes() as $shp) {
      if (java_instanceof($shp, new JavaClass("com.aspose.slides.Table"))) {
        $tbl = $shp;
        # يضع النص للعمود الأول من الصف الثاني
        $tbl->get_Item(0, 1)->getTextFrame()->setText("New");
      }
    }
    # يحفظ العرض التقديمي المعدل على القرص
    $pres->save("table1_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **محاذاة النص في جدول**

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. الحصول على مرجع الشريحة عبر فهرستها. 
3. إضافة كائن [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) إلى الشريحة.
4. الوصول إلى كائن [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) من الجدول.
5. الوصول إلى [IParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraph/) الخاص بـ [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/).
6. محاذاة النص عمودياً.
7. حفظ العرض التقديمي المعدل.

```php
  # ينشئ مثيلاً من فئة Presentation
  $pres = new Presentation();
  try {
    # يحصل على الشريحة الأولى
    $slide = $pres->getSlides()->get_Item(0);
    # يحدد الأعمدة بعروضها والصفوف بارتفاعها
    $dblCols = array(120, 120, 120, 120 );
    $dblRows = array(100, 100, 100, 100 );
    # يضيف شكل جدول إلى الشريحة
    $tbl = $slide->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    $tbl->get_Item(1, 0)->getTextFrame()->setText("10");
    $tbl->get_Item(2, 0)->getTextFrame()->setText("20");
    $tbl->get_Item(3, 0)->getTextFrame()->setText("30");
    # يصل إلى إطار النص
    $txtFrame = $tbl->get_Item(0, 0)->getTextFrame();
    # ينشئ كائن Paragraph لإطار النص
    $paragraph = $txtFrame->getParagraphs()->get_Item(0);
    # ينشئ كائن Portion للفقرة
    $portion = $paragraph->getPortions()->get_Item(0);
    $portion->setText("Text here");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # يضبط محاذاة النص عمودياً
    $cell = $tbl->get_Item(0, 0);
    $cell->setTextAnchorType(TextAnchorType::Center);
    $cell->setTextVerticalType(TextVerticalType::Vertical270);
    # يحفظ العرض التقديمي على القرص
    $pres->save("Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **تعيين تنسيق النص على مستوى الجدول**

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. الحصول على مرجع الشريحة عبر فهرستها. 
3. الوصول إلى كائن [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) من الشريحة.
4. تعيين [setFontHeight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight-float-) للنص.
5. تعيين [setAlignment(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraphformat/#setAlignment-int-) و [setMarginRight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraphformat/#setMarginRight-float-).
6. تعيين [setTextVerticalType(byte value)](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. حفظ العرض التقديمي المعدل. 

```php
  # ينشئ مثيلاً من فئة Presentation
  $pres = new Presentation("simpletable.pptx");
  try {
    # لنفترض أن الشكل الأول في الشريحة الأولى هو جدول
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # يضبط ارتفاع خط خلايا الجدول
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->setTextFormat($portionFormat);
    # يضبط محاذاة نص خلايا الجدول والهامش الأيمن في استدعاء واحد
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->setTextFormat($paragraphFormat);
    # يضبط نوع النص العمودي لخلايا الجدول
    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat::setTextVerticalType(TextVerticalType::Vertical);
    $someTable->setTextFormat($textFrameFormat);
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **الحصول على خصائص نمط الجدول**

Aspose.Slides يتيح لك استرجاع خصائص النمط للجدول بحيث يمكنك استخدام هذه التفاصيل لجدول آخر أو في مكان آخر. يُظهر هذا الكود PHP كيفية الحصول على خصائص النمط من نمط جدول مسبق:

```php
  $pres = new Presentation();
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->addTable(10, 10, array(100, 150 ), array(5, 5, 5 ));
    $table->setStylePreset(TableStylePreset->DarkStyle1);// تغيير سمة النمط الافتراضية

    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **قفل نسبة العرض إلى الارتفاع للجدول**

نسبة العرض إلى الارتفاع لشكل هندسي هي نسبة أبعاده في الأبعاد المختلفة. Aspose.Slides يوفر الخاصية [**setAspectRatioLocked**](https://reference.aspose.com/slides/php-java/aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) للسماح لك بقفل إعداد نسبة العرض إلى الارتفاع للجداول والأشكال الأخرى.

```php
  $pres = new Presentation("pres.pptx");
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    echo("Lock aspect ratio set: " . $table->getGraphicalObjectLock()->getAspectRatioLocked());
    $table->getGraphicalObjectLock()->setAspectRatioLocked(!$table->getGraphicalObjectLock()->getAspectRatioLocked());// عكس

    echo("Lock aspect ratio set: " . $table->getGraphicalObjectLock()->getAspectRatioLocked());
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **الأسئلة الشائعة**

**هل يمكنني تمكين اتجاه القراءة من اليمين إلى اليسار (RTL) لجدول كامل والنص داخل خلاياه؟**

نعم. الجدول يوفّر طريقة [setRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/table/setrighttoleft/)، والفقرات لديها [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setrighttoleft/). استخدامهما معًا يضمن الترتيب الصحيح للـ RTL وعرضه داخل الخلايا.

**كيف يمكنني منع المستخدمين من نقل أو تغيير حجم الجدول في الملف النهائي؟**

استخدم [قفل الأشكال](/slides/ar/php-java/applying-protection-to-presentation/) لتعطيل النقل، تغيير الحجم، التحديد، وغيرها. هذه الأقفال تُطبّق على الجداول أيضاً.

**هل دعم إدراج صورة داخل خلية كخلفية متاح؟**

نعم. يمكنك تعيين [ملء صورة](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/) للخلية؛ الصورة ستغطي مساحة الخلية وفق الوضع المختار (تمدد أو تمهيد).