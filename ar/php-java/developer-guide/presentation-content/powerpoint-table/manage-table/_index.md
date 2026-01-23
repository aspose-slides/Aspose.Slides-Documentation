---
title: إدارة جداول العروض التقديمية في PHP
linktitle: إدارة الجدول
type: docs
weight: 10
url: /ar/php-java/manage-table/
keywords:
- إضافة جدول
- إنشاء جدول
- الوصول إلى جدول
- نسبة الأبعاد
- محاذاة النص
- تنسيق النص
- نمط الجدول
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "إنشاء وتعديل الجداول في شرائح PowerPoint باستخدام Aspose.Slides لـ PHP عبر Java. اكتشف أمثلة كود بسيطة لتبسيط سير عمل الجداول الخاص بك."
---

الجدول في PowerPoint هو طريقة فعّالة لعرض وتوضيح المعلومات. تُعرض المعلومات في شبكة من الخلايا (مرتبة في صفوف وأعمدة) بشكل واضح وسهل الفهم.

Aspose.Slides يوفر الفئة [Table](https://reference.aspose.com/slides/php-java/aspose.slides/Table) والفئة [Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) وأنواع أخرى لتسمح لك بإنشاء وتحديث وإدارة الجداول في جميع أنواع العروض التقديمية.

## **Create a Table from Scratch**

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. الحصول على مرجع الشريحة عبر فهرسها. 
3. تعريف مصفوفة `columnWidth`.
4. تعريف مصفوفة `rowHeight`.
5. إضافة كائن [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) إلى الشريحة عبر الطريقة [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/).
6. التكرار عبر كل [Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) لتطبيق تنسيق الحدود العلوية والسفلية واليمنى واليسرى.
7. دمج الخليتين الأوليين في الصف الأول للجدول. 
8. الوصول إلى [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) الخاص بـ [Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/).
9. إضافة نص إلى [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/).
10. حفظ العرض التقديمي المعدل.

هذا الكود PHP يوضح لك كيفية إنشاء جدول في عرض تقديمي:
```php
  # ينشئ فئة Presentation التي تمثل ملف PPTX
  $pres = new Presentation();
  try {
    # يصل إلى الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # يعرف الأعمدة بعرضها والصفوف بارتفاعها
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


## **Numbering in a Standard Table**

في جدول قياسي، ترقيم الخلايا يكون بسيطًا ويبدأ من الصفر. يتم فهرسة الخلية الأولى في الجدول كـ 0,0 (العمود 0، الصف 0). 

على سبيل المثال، تُرقم الخلايا في جدول يحتوي على 4 أعمدة و4 صفوف بالشكل التالي:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

هذا الكود PHP يوضح لك كيفية تحديد ترقيم الخلايا في جدول:
```php
  # ينشئ فئة Presentation التي تمثل ملف PPTX
  $pres = new Presentation();
  try {
    # يصل إلى الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # يحدد الأعمدة بعرضها والصفوف بارتفاعها
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # يضيف شكل جدول إلى الشريحة
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # يحدد تنسيق الحدود لكل خلية
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


## **Access an Existing Table**

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).

2. الحصول على مرجع للشريحة التي تحتوي على الجدول عبر فهرسها. 

3. إنشاء كائن [Table](https://reference.aspose.com/slides/php-java/aspose.slides/Table) وتعيينه إلى null.

4. التكرار عبر جميع كائنات [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) حتى يتم العثور على الجدول.

   إذا كنت تشك أن الشريحة التي تتعامل معها تحتوي على جدول واحد فقط، يمكنك ببساطة فحص جميع الأشكال التي تحتويها. عندما يتم التعرف على شكل كجدول، يمكنك تحويله إلى كائن [Table](https://reference.aspose.com/slides/php-java/aspose.slides/Table). ولكن إذا كانت الشريحة تحتوي على عدة جداول، فإن البحث عن الجدول المطلوب عبر خاصية [setAlternativeText(String value)](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setalternativetext/) يكون أفضل.

5. استخدام كائن [Table](https://reference.aspose.com/slides/php-java/aspose.slides/Table) للعمل مع الجدول. في المثال أدناه، أضفنا صفًا جديدًا إلى الجدول.

6. حفظ العرض التقديمي المعدل.

هذا الكود PHP يوضح لك كيفية الوصول إلى جدول موجود والعمل معه:
```php
  # ينشئ فئة Presentation التي تمثل ملف PPTX
  $pres = new Presentation("UpdateExistingTable.pptx");
  try {
    # يصل إلى الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # يهيئ TableEx كقيمة null
    $tbl = null;
    # يتنقل عبر الأشكال ويحدد مرجعًا للجدول الموجود
    foreach($sld->getShapes() as $shp) {
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


## **Align Text in a Table**

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. الحصول على مرجع الشريحة عبر فهرسها. 
3. إضافة كائن [Table](https://reference.aspose.com/slides/php-java/aspose.slides/Table) إلى الشريحة.
4. الوصول إلى كائن [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) من الجدول.
5. الوصول إلى [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/).
6. محاذاة النص عموديًا.
7. حفظ العرض التقديمي المعدل.

هذا الكود PHP يوضح لك كيفية محاذاة النص في جدول:
```php
  # ينشئ مثالًا لفئة Presentation
  $pres = new Presentation();
  try {
    # يحصل على الشريحة الأولى
    $slide = $pres->getSlides()->get_Item(0);
    # يعرف الأعمدة بعروضها والصفوف بارتفاعها
    $dblCols = array(120, 120, 120, 120 );
    $dblRows = array(100, 100, 100, 100 );
    # يضيف شكل جدول إلى الشريحة
    $tbl = $slide->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    $tbl->get_Item(1, 0)->getTextFrame()->setText("10");
    $tbl->get_Item(2, 0)->getTextFrame()->setText("20");
    $tbl->get_Item(3, 0)->getTextFrame()->setText("30");
    # يصل إلى إطار النص
    $txtFrame = $tbl->get_Item(0, 0)->getTextFrame();
    # ينشئ كائن الفقرة لإطار النص
    $paragraph = $txtFrame->getParagraphs()->get_Item(0);
    # ينشئ كائن Portion للفقرة
    $portion = $paragraph->getPortions()->get_Item(0);
    $portion->setText("Text here");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # محاذاة النص عموديًا
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


## **Set Text Formatting on the Table Level**

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. الحصول على مرجع الشريحة عبر فهرسها. 
3. الوصول إلى كائن [Table](https://reference.aspose.com/slides/php-java/aspose.slides/Table) من الشريحة.
4. تعيين [setFontHeight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) للنص.
5. تعيين [setAlignment(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) و[setMarginRight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/).
6. تعيين [setTextVerticalType(byte value)](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/).
7. حفظ العرض التقديمي المعدل. 

هذا الكود PHP يوضح لك كيفية تطبيق خيارات التنسيق المفضلة على النص داخل جدول:
```php
  # ينشئ مثالًا لفئة Presentation
  $pres = new Presentation("simpletable.pptx");
  try {
    # لنفترض أن الشكل الأول في الشريحة الأولى هو جدول
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # يضبط ارتفاع خط خلايا الجدول
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->setTextFormat($portionFormat);
    # يضبط محاذاة نص خلايا الجدول والهامش الأيمن في خطوة واحدة
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->setTextFormat($paragraphFormat);
    # يضبط النوع العمودي للنص في خلايا الجدول
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


## **Get Table Style Properties**

Aspose.Slides يتيح لك استرجاع خصائص النمط لجدول حتى تتمكن من استخدامها في جدول آخر أو في مكان آخر. هذا الكود PHP يوضح لك كيفية الحصول على خصائص النمط من نمط جدول مسبق:
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


## **Lock Aspect Ratio of a Table**

نسبة الأبعاد لشكل هندسي هي نسبة أُحجامه في الأبعاد المختلفة. Aspose.Slides قدم الطريقة [setAspectRatioLocked](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/setaspectratiolocked/) للسماح لك بقفل إعداد نسبة الأبعاد للجداول وغيرها من الأشكال.

هذا الكود PHP يوضح لك كيفية قفل نسبة الأبعاد لجدول:
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


## **FAQ**

**هل يمكنني تمكين اتجاه القراءة من اليمين إلى اليسار (RTL) لجدول كامل والنص داخل خلاياه؟**

نعم. الجدول يتيح طريقة [setRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/table/setrighttoleft/)، والفقرات لديها [ParagraphFormat::setRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setrighttoleft/). استخدام الاثنين يضمن الترتيب الصحيح للـ RTL وعرضه داخل الخلايا.

**كيف يمكنني منع المستخدمين من تحريك أو تغيير حجم جدول في الملف النهائي؟**

استخدم أقفال الأشكال لتعطيل التحريك، وتغيير الحجم، والاختيار، وما إلى ذلك. هذه الأقفال تُطبق أيضًا على الجداول.

**هل دعم إدراج صورة داخل خلية كخلفية؟**

نعم. يمكنك تعيين [picture fill](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/) لخلية؛ ستغطي الصورة مساحة الخلية وفقًا للوضع المحدد (تمدد أو تجانب).