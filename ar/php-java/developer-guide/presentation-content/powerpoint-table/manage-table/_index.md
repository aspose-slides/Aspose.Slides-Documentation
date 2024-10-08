---
title: إدارة الجدول
type: docs
weight: 10
url: /ar/php-java/manage-table/
keywords: "جدول، إنشاء جدول، الوصول إلى الجدول، نسبة عرض إلى ارتفاع الجدول، عرض تقديمي لـ PowerPoint، Java، Aspose.Slides لـ PHP عبر Java"
description: "إنشاء وإدارة الجدول في عروض PowerPoint"
---

الجدول في PowerPoint هو وسيلة فعّالة لعرض وتقديم المعلومات. المعلومات الموجودة في شبكة من الخلايا (مرتبة في صفوف وأعمدة) بسيطة وسهلة الفهم.

تقدم Aspose.Slides فئة [Table](https://reference.aspose.com/slides/php-java/aspose.slides/Table) وواجهة [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) وفئة [Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) وواجهة [ICell](https://reference.aspose.com/slides/php-java/aspose.slides/icell/) وأنواع أخرى لتمكينك من إنشاء وتحديث وإدارة الجداول في جميع أنواع العروض التقديمية.

## **إنشاء جدول من الصفر**

1. إنشاء مثيل لفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. الحصول على مرجع الشريحة من خلال مؤشرها.
3. تعريف مصفوفة من `columnWidth`.
4. تعريف مصفوفة من `rowHeight`.
5. إضافة كائن [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) إلى الشريحة من خلال طريقة [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-).
6. التكرار عبر كل [ICell](https://reference.aspose.com/slides/php-java/aspose.slides/icell/) لتطبيق التنسيق على الحدود العلوية والسفلية واليمنى واليسرى.
7. دمج أول خليتين من الصف الأول للجدول.
8. الوصول إلى [ICell](https://reference.aspose.com/slides/php-java/aspose.slides/icell/)'s [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/).
9. إضافة بعض النص إلى [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/).
10. حفظ العرض التقديمي المعدل.

هذا الكود PHP يوضح لك كيفية إنشاء جدول في عرض تقديمي:

```php
  # Instantiate a Presentation class that represents a PPTX file
  $pres = new Presentation();
  try {
    # Accesses the first slide
    $sld = $pres->getSlides()->get_Item(0);
    # Defines columns with widths and rows with heights
    $dblCols = array(50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # Adds a table shape to slide
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Sets the border format for each cell
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
    # Merges cells 1 & 2 of row 1
    $tbl->mergeCells($tbl->getRows()->get_Item(0)->get_Item(0), $tbl->getRows()->get_Item(1)->get_Item(1), false);
    # Adds some text to the merged cell
    $tbl->getRows()->get_Item(0)->get_Item(0)->getTextFrame()->setText("Merged Cells");
    # Saves the presentation to Disk
    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **الترقيم في الجدول القياسي**

في الجدول القياسي، يكون ترقيم الخلايا بسيطًا وبدون أساس. يتم فهرسة أول خلية في الجدول على أنها 0,0 (عمود 0، صف 0). 

على سبيل المثال، يتم ترقيم الخلايا في جدول يحتوي على 4 أعمدة و 4 صفوف بهذه الطريقة:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

هذا الكود PHP يوضح لك كيفية تحديد الترقيم للخلايا في جدول:

```php
  # Instantiate a Presentation class that represents a PPTX file
  $pres = new Presentation();
  try {
    # Accesses first slide
    $sld = $pres->getSlides()->get_Item(0);
    # Defines columns with widths and rows with heights
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # Adds a table shape to slide
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Sets the border format for each cell
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
    # Saves presentation to disk
    $pres->save("StandardTables_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **الوصول إلى جدول موجود**

1. إنشاء مثيل لفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).

2. الحصول على مرجع للشريحة التي تحتوي على الجدول من خلال مؤشرها. 

3. إنشاء كائن [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) وتعيينه إلى null.

4. التكرار عبر جميع كائنات [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/ishape/) حتى يتم العثور على الجدول.

   إذا كنت تشك في أن الشريحة التي تتعامل معها تحتوي على جدول واحد فقط، يمكنك ببساطة التحقق من جميع الأشكال التي تحتوي عليها. عندما يتم تحديد شكل كجدول، يمكنك تحويله إلى كائن [Table](https://reference.aspose.com/slides/php-java/aspose.slides/Table). ولكن إذا كانت الشريحة التي تتعامل معها تحتوي على عدة جداول، فمن الأفضل البحث عن الجدول الذي تحتاجه من خلال [setAlternativeText(String value)](https://reference.aspose.com/slides/php-java/aspose.slides/ishape/#setAlternativeText-java.lang.String-).

5. استخدام كائن [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) للعمل مع الجدول. في المثال أدناه، أضفنا صفًا جديدًا إلى الجدول.

6. حفظ العرض التقديمي المعدل.

هذا الكود PHP يوضح لك كيفية الوصول إلى جدول موجود والعمل معه:

```php
  # Instantiates the Presentation class that represents a PPTX file
  $pres = new Presentation("UpdateExistingTable.pptx");
  try {
    # Accesses the first slide
    $sld = $pres->getSlides()->get_Item(0);
    # Initializes null TableEx
    $tbl = null;
    # Iterates through the shapes and sets a reference to the table found
    foreach($sld->getShapes() as $shp) {
      if (java_instanceof($shp, new JavaClass("com.aspose.slides.Table"))) {
        $tbl = $shp;
        # Sets the text for the first column of the second row
        $tbl->get_Item(0, 1)->getTextFrame()->setText("New");
      }
    }
    # Saves the modified presentation to disk
    $pres->save("table1_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **محاذاة النص في الجدول**

1. إنشاء مثيل لفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. الحصول على مرجع الشريحة من خلال مؤشرها. 
3. إضافة كائن [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) إلى الشريحة.
4. الوصول إلى كائن [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) من الجدول.
5. الوصول إلى [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) [IParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraph/).
6. محاذاة النص عموديًا.
7. حفظ العرض التقديمي المعدل.

هذا الكود PHP يوضح لك كيفية محاذاة النص في جدول:

```php
  # Creates an instance of the Presentation class
  $pres = new Presentation();
  try {
    # Gets the first slide
    $slide = $pres->getSlides()->get_Item(0);
    # Defines columns with widths and rows with heights
    $dblCols = array(120, 120, 120, 120 );
    $dblRows = array(100, 100, 100, 100 );
    # Adds the table shape to the slide
    $tbl = $slide->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    $tbl->get_Item(1, 0)->getTextFrame()->setText("10");
    $tbl->get_Item(2, 0)->getTextFrame()->setText("20");
    $tbl->get_Item(3, 0)->getTextFrame()->setText("30");
    # Accesses the text frame
    $txtFrame = $tbl->get_Item(0, 0)->getTextFrame();
    # Creates the Paragraph object for the text frame
    $paragraph = $txtFrame->getParagraphs()->get_Item(0);
    # Creates the Portion object for paragraph
    $portion = $paragraph->getPortions()->get_Item(0);
    $portion->setText("Text here");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Aligns the text vertically
    $cell = $tbl->get_Item(0, 0);
    $cell->setTextAnchorType(TextAnchorType::Center);
    $cell->setTextVerticalType(TextVerticalType::Vertical270);
    # Saves the presentation to disk
    $pres->save("Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تعيين تنسيق النص على مستوى الجدول**

1. إنشاء مثيل لفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. الحصول على مرجع الشريحة من خلال مؤشرها. 
3. الوصول إلى كائن [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) من الشريحة.
4. تعيين [setFontHeight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight-float-) للنص.
5. تعيين [setAlignment(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraphformat/#setAlignment-int-) و [setMarginRight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraphformat/#setMarginRight-float-).
6. تعيين [setTextVerticalType(byte value)](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. حفظ العرض التقديمي المعدل. 

هذا الكود PHP يوضح لك كيفية تطبيق خيارات التنسيق المفضلة لديك على النص في جدول:

```php
  # Creates an instance of the Presentation class
  $pres = new Presentation("simpletable.pptx");
  try {
    # Let's assume that the first shape on the first slide is a table
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Sets the table cells' font height
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->setTextFormat($portionFormat);
    # Sets the table cells' text alignment and right margin in one call
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->setTextFormat($paragraphFormat);
    # Sets the table cells' text vertical type
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

تتيح لك Aspose.Slides استرداد خصائص النمط لجدول بحيث يمكنك استخدام تلك التفاصيل لجدول آخر أو في مكان آخر. هذا الكود PHP يوضح لك كيفية الحصول على خصائص النمط من نمط جدول محدد مسبقًا:

```php
  $pres = new Presentation();
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->addTable(10, 10, array(100, 150 ), array(5, 5, 5 ));
    $table->setStylePreset(TableStylePreset->DarkStyle1);// تغيير نمط السمة الافتراضية

    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **قفل نسبة عرض إلى ارتفاع الجدول**

نسبة العرض إلى الارتفاع لشكل هندسي هي نسبة أحجامه في أبعاد مختلفة. تقدم Aspose.Slides خاصية [**setAspectRatioLocked**](https://reference.aspose.com/slides/php-java/aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) للسماح لك بقفل إعداد نسبة العرض إلى الارتفاع للجداول والأشكال الأخرى.

هذا الكود PHP يوضح لك كيفية قفل نسبة العرض إلى الارتفاع لجدول:

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