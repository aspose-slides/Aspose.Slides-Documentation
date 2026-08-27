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
description: "إنشاء وتعديل الجداول في شرائح PowerPoint باستخدام Aspose.Slides للغة PHP via Java. اكتشف أمثلة شفرة بسيطة لتبسيط سير عمل الجداول الخاص بك."
---
## **المقدمة**

الجدول في PowerPoint هو طريقة فعّالة لعرض وتوضيح المعلومات. المعلومات في شبكة من الخلايا (مرتبة في صفوف وأعمدة) بسيطة وسهلة الفهم.

توفر Aspose.Slides الفئة [Table](https://reference.aspose.com/slides/ar/php-java/aspose.slides/Table) والفئة [Cell](https://reference.aspose.com/slides/ar/php-java/aspose.slides/cell/) وأنواع أخرى لتتيح لك إنشاء وتحديث وإدارة الجداول في جميع أنواع العروض التقديمية.

## **إنشاء جدول من الصفر**

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/Presentation) .
2. احصل على مرجع الشريحة عبر فهرسها. 
3. عرّف مصفوفة `columnWidth`.
4. عرّف مصفوفة `rowHeight`.
5. أضف كائن [Table](https://reference.aspose.com/slides/ar/php-java/aspose.slides/table/) إلى الشريحة عبر الطريقة [addTable](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shapecollection/addtable/) .
6. تكرّر عبر كل [Cell](https://reference.aspose.com/slides/ar/php-java/aspose.slides/cell/) لتطبيق التنسيق على الحدود العليا والسفلية واليمنى واليسرى.
7. دمج أول خليتين في الصف الأول من الجدول. 
8. احصل على [TextFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/) الخاص بـ [Cell](https://reference.aspose.com/slides/ar/php-java/aspose.slides/cell/) .
9. أضف بعض النص إلى [TextFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/) .
10. احفظ العرض التقديمي المعدل.

يعرض لك هذا الكود PHP كيفية إنشاء جدول في عرض تقديمي:

```php
  # ينشئ كائن من فئة Presentation تمثل ملف PPTX
  $pres = new Presentation();
  try {
    # يَصل إلى الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # يحدد الأعمدة بعروضها والصفوف بارتفاعها
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
    # يدمج الخلايا 1 و 2 من الصف 1
    $tbl->mergeCells($tbl->getRows()->get_Item(0)->get_Item(0), $tbl->getRows()->get_Item(1)->get_Item(1), false);
    # يضيف بعض النص إلى الخلية المدمجة
    $tbl->getRows()->get_Item(0)->get_Item(0)->getTextFrame()->setText("Merged Cells");
    # يحفظ العرض التقديمي إلى القرص
    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **الترقيم في جدول قياسي**

في جدول قياسي، يكون ترقيم الخلايا مباشرًا ويبدأ من الصفر. يتم فهرسة الخلية الأولى في الجدول كـ 0,0 (العمود 0، الصف 0).

على سبيل المثال، تُرقم الخلايا في جدول يحتوي على 4 أعمدة و4 صفوف بهذه الطريقة:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

يعرض لك هذا الكود PHP كيفية تحديد ترقيم الخلايا في جدول:

```php
  # ينشئ كائن من فئة Presentation يمثل ملف PPTX
  $pres = new Presentation();
  try {
    # يصل إلى الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # يحدد الأعمدة بعرضها والصفوف بارتفاعها
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # يضيف شكل جدول إلى الشريحة
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # يضبط تنسيق الحدود لكل خلية
    $rows = $tbl->getRows();
    foreach($rows as $row) {
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

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/Presentation) .
2. احصل على مرجع الشريحة التي تحتوي على الجدول عبر فهرسها. 
3. أنشئ كائن [Table](https://reference.aspose.com/slides/ar/php-java/aspose.slides/Table) وضعه على null.
4. تكرّر عبر جميع كائنات [Shape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shape/) حتى يتم العثور على الجدول.

   إذا كنت تشكّ أن الشريحة التي تتعامل معها تحتوي على جدول واحد، يمكنك ببساطة فحص جميع الأشكال التي تحتويها. عندما يتم التعرف على الشكل كجدول، يمكنك تحويل نوعه إلى كائن [Table](https://reference.aspose.com/slides/ar/php-java/aspose.slides/Table). ولكن إذا كانت الشريحة التي تتعامل معها تحتوي على عدة جداول، فمن الأفضل البحث عن الجدول الذي تحتاجه عبر الخاصية [setAlternativeText(String value)](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shape/setalternativetext/) الخاصة به.
5. استخدم كائن [Table](https://reference.aspose.com/slides/ar/php-java/aspose.slides/Table) للعمل مع الجدول. في المثال أدناه، أضفنا صفًا جديدًا إلى الجدول.
6. احفظ العرض التقديمي المعدل.

يعرض لك هذا الكود PHP كيفية الوصول إلى جدول موجود والعمل معه:

```php
  # ينشئ كائن من فئة Presentation يمثل ملف PPTX
  $pres = new Presentation("UpdateExistingTable.pptx");
  try {
    # يصل إلى الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # يهيئ TableEx كقيمة null
    $tbl = null;
    # يتجول عبر الأشكال ويحدد مرجعًا للجدول الموجود
    $shapes = $sld->getShapes();
    foreach($shapes as $shp) {
      if (java_instanceof($shp, new JavaClass("com.aspose.slides.Table"))) {
        $tbl = $shp;
        # يحدد النص للعمود الأول من الصف الثاني
        $tbl->get_Item(0, 1)->getTextFrame()->setText("New");
      }
    }
    # يحفظ العرض التقديمي المعدل إلى القرص
    $pres->save("table1_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **العثور على الخلية التي تملك إطار نص**

عند استلام كود معالجة نص عام كائن [TextFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/) من جدول، استخدم الطريقة [TextFrame::getParentCell](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/#getParentCell) لاسترجاع [Cell](https://reference.aspose.com/slides/ar/php-java/aspose.slides/cell/) المالكة. بالنسبة لإطار نص خلية جدول، تُعيد [TextFrame::getParentCell](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/#getParentCell) المالك وتُعيد [TextFrame::getParentShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/#getParentShape) القيمة `null`، على الرغم من أن الجدول نفسه يُعتبر شكلاً.

تتوفر إحداثيات الخلية عبر الطريقتين القارئتين فقط [Cell::getFirstColumnIndex](https://reference.aspose.com/slides/ar/php-java/aspose.slides/cell/#getFirstColumnIndex) و[Cell::getFirstRowIndex](https://reference.aspose.com/slides/ar/php-java/aspose.slides/cell/#getFirstRowIndex). كما توفر [TextFrame::getParentCell](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/#getParentCell) تنقلاً للقراءة فقط: تُعيد المالك دون تغيير الملكية. تحقق دائمًا من أن الخلية المرتجعة ليست `java_is_null` قبل استخدامها.

للحصول على مثال كامل يحدد مالكي خلية الجدول والشكل، بما في ذلك الأشكال المرتبطة بعقد SmartArt، راجع [البحث واستبدال النص](/slides/ar/php-java/search-and-replace-text/).

## **محاذاة النص في جدول**

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/Presentation) .
2. احصل على مرجع الشريحة عبر فهرسها. 
3. أضف كائن [Table](https://reference.aspose.com/slides/ar/php-java/aspose.slides/Table) إلى الشريحة.
4. احصل على كائن [TextFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/) من الجدول.
5. احصل على الـ [Paragraph](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraph/) .
6. محاذاة النص عموديًا.
7. احفظ العرض التقديمي المعدل.

يعرض لك هذا الكود PHP كيفية محاذاة النص في جدول:

```php
  # ينشئ مثيلًا من فئة Presentation
  $pres = new Presentation();
  try {
    # يحصل على الشريحة الأولى
    $slide = $pres->getSlides()->get_Item(0);
    # يحدد الأعمدة بعرضها والصفوف بارتفاعها
    $dblCols = array(120, 120, 120, 120 );
    $dblRows = array(100, 100, 100, 100 );
    # يضيف شكل الجدول إلى الشريحة
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
    # يضبط محاذاة النص عموديًا
    $cell = $tbl->get_Item(0, 0);
    $cell->setTextAnchorType(TextAnchorType::Center);
    $cell->setTextVerticalType(TextVerticalType::Vertical270);
    # يحفظ العرض التقديمي إلى القرص
    $pres->save("Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تعيين تنسيق النص على مستوى الجدول**

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/Presentation) .
2. احصل على مرجع الشريحة عبر فهرسها. 
3. احصل على كائن [Table](https://reference.aspose.com/slides/ar/php-java/aspose.slides/Table) من الشريحة.
4. اضبط [setFontHeight(float value)](https://reference.aspose.com/slides/ar/php-java/aspose.slides/baseportionformat/#setFontHeight) للنص.
5. اضبط [setAlignment(int value)](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraphformat/setalignment/) و[setMarginRight(float value)](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraphformat/setmarginright/) .
6. اضبط [setTextVerticalType(byte value)](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframeformat/settextverticaltype/) .
7. احفظ العرض التقديمي المعدل. 

يعرض لك هذا الكود PHP كيفية تطبيق خيارات التنسيق المفضلة على النص في جدول:

```php
  # ينشئ مثيلًا من فئة Presentation
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
    # يضبط نوع اتجاه النص العمودي لخلايا الجدول
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

تمكنك Aspose.Slides من استرجاع خصائص النمط لجدول بحيث يمكنك استخدام هذه التفاصيل لجدول آخر أو في مكان آخر. يظهر لك هذا الكود PHP كيفية الحصول على خصائص النمط من نمط جدول مسبق التعيين:

```php
  $pres = new Presentation();
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->addTable(10, 10, array(100, 150 ), array(5, 5, 5 ));
    $table->setStylePreset(TableStylePreset->DarkStyle1);// تغيير سمة نمط الإعداد المسبق الافتراضي

    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **قفل نسبة العرض إلى الارتفاع للجدول**

نسبة العرض إلى الارتفاع لشكل هندسي هي نسبة أبعاده المختلفة. وفرت Aspose.Slides الطريقة [setAspectRatioLocked](https://reference.aspose.com/slides/ar/php-java/aspose.slides/graphicalobjectlock/setaspectratiolocked/) لتسمح لك بقفل إعداد نسبة العرض إلى الارتفاع للجداول والأشكال الأخرى.

يعرض لك هذا الكود PHP كيفية قفل نسبة العرض إلى الارتفاع لجدول:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    echo("Lock aspect ratio set: " . $table->getGraphicalObjectLock()->getAspectRatioLocked());
    $table->getGraphicalObjectLock()->setAspectRatioLocked(!$table->getGraphicalObjectLock()->getAspectRatioLocked());// invert

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

نعم. ي expose الجدول طريقة [setRightToLeft](https://reference.aspose.com/slides/ar/php-java/aspose.slides/table/setrighttoleft/) ، وتحتوي الفقرات على [ParagraphFormat::setRightToLeft](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraphformat/setrighttoleft/). يضمن استخدام الطريقتين ترتيب RTL الصحيح وعرضه داخل الخلايا.

**كيف يمكنني منع المستخدمين من نقل أو تعديل حجم الجدول في الملف النهائي؟**

استخدم أقفال الأشكال لتعطيل النقل، تعديل الحجم، التحديد، وما إلى ذلك. تُطبق هذه الأقفال على الجداول أيضًا.

**هل يدعم إدراج صورة داخل خلية كخلفية؟**

نعم. يمكنك تعيين [picture fill](https://reference.aspose.com/slides/ar/php-java/aspose.slides/picturefillformat/) لخلية؛ ستغطي الصورة مساحة الخلية وفقًا للوضع المختار (تمديد أو تكرار).