---
title: إدارة خلايا الجدول في العروض التقديمية باستخدام PHP
linktitle: إدارة الخلايا
type: docs
weight: 30
url: /ar/php-java/manage-cells/
keywords:
- خلية جدول
- دمج خلايا
- إزالة الحد
- تقسيم خلية
- صورة داخل خلية
- لون الخلفية
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "إدارة خلايا الجدول في PowerPoint بسهولة باستخدام Aspose.Slides لـ PHP. اتقن الوصول إلى الخلايا وتعديلها وتنسيقها بسرعة لتحقيق أتمتة سلسة للشرائح."
---

## **Identify a Merged Table Cell**
1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) .
2. الحصول على الجدول من الشريحة الأولى. 
3. التكرار عبر صفوف وأعمدة الجدول للعثور على الخلايا المدمجة.
4. طباعة رسالة عندما يتم العثور على خلايا مدمجة.

يعرض لك هذا الكود PHP كيفية تحديد الخلايا المدمجة في جدول داخل عرض تقديمي:
```php
  $pres = new Presentation("SomePresentationWithTable.pptx");
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);// افتراض أن الشريحة#0.الشكل#0 هو جدول

    for($i = 0; $i < java_values($table->getRows()->size()) ; $i++) {
      for($j = 0; $j < java_values($table->getColumns()->size()) ; $j++) {
        $currentCell = $table->getRows()->get_Item($i)->get_Item($j);
        if ($currentCell->isMergedCell()) {
          echo(sprintf("Cell %d;%d is a part of merged cell with RowSpan=%d and ColSpan=%d starting from Cell %d;%d.", $i, $j, $currentCell->getRowSpan(), $currentCell->getColSpan(), $currentCell->getFirstRowIndex(), $currentCell->getFirstColumnIndex()));
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Remove Table Cell Borders**
1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) .
2. الحصول على مرجع الشريحة من خلال فهرستها. 
3. تحديد مصفوفة من الأعمدة مع العرض.
4. تحديد مصفوفة من الصفوف مع الارتفاع.
5. إضافة جدول إلى الشريحة عبر طريقة [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addTable) .
6. التكرار عبر كل خلية لإزالة الحدود العلوية والسفلية واليمين واليسار.
7. حفظ العرض التقديمي المعدل كملف PPTX.

يعرض لك هذا الكود PHP كيفية إزالة الحدود من خلايا الجدول:
```php
  # ينشئ فئة Presentation التي تمثل ملف PPTX
  $pres = new Presentation();
  try {
    # يصل إلى الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # يعرّف الأعمدة بعروضها والصفوف بارتفاعها
    $dblCols = array(50, 50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # يضيف شكل جدول إلى الشريحة
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # يحدد تنسيق الحدود لكل خلية
    foreach($tbl->getRows() as $row) {
      foreach($row as $cell) {
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::NoFill);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::NoFill);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::NoFill);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::NoFill);
      }
    }
    # يكتب ملف PPTX إلى القرص
    $pres->save("table_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Numbering in Merged Cells**
إذا دمجنا زوجين من الخلايا (1, 1) × (2, 1) و(1, 2) × (2, 2)، سيتم ترقيم الجدول الناتج. يوضح لك هذا الكود PHP العملية:
```php
  # ينشئ فئة Presentation التي تمثل ملف PPTX
  $pres = new Presentation();
  try {
    # يصل إلى الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # يعرّف الأعمدة بعروضها والصفوف بارتفاعها
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
    # دمج الخلايا (1, 1) × (2, 1)
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);
    # دمج الخلايا (1, 2) × (2, 2)
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);
    $pres->save("MergeCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


ثم نقوم بدمج الخلايا أكثر بدمج (1, 1) و(1, 2). النتيجة هي جدول يحتوي على خلية مدمجة كبيرة في مركزه: 
```php
  # ينشئ فئة Presentation التي تمثل ملف PPTX
  $pres = new Presentation();
  try {
    # يصل إلى الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # يعرّف الأعمدة بعروضها والصفوف بارتفاعها
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
    # يدمج الخلايا (1, 1) × (2, 1)
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);
    # يدمج الخلايا (1, 2) × (2, 2)
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);
    # يدمج الخلايا (1, 1) × (1, 2)
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(1, 2), true);
    # يكتب ملف PPTX إلى القرص
    $pres->save("MergeCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Numbering in a Splitted Cell**
في الأمثلة السابقة، عندما تم دمج خلايا الجدول، لم يتغير نظام الترقيم أو الأرقام في الخلايا الأخرى. 

هذه المرة، نأخذ جدولًا عاديًا (جدول بدون خلايا مدمجة) ثم نحاول تقسيم الخلية (1,1) للحصول على جدول خاص. قد ترغب في الانتباه إلى ترقيم هذا الجدول، الذي قد يُعتبر غريبًا. مع ذلك، هذه هي الطريقة التي يرقم بها Microsoft PowerPoint خلايا الجداول، وتقوم Aspose.Slides بنفس الأمر. 

يوضح لك هذا الكود PHP العملية التي وصفناها:
```php
  # ينشئ فئة Presentation التي تمثل ملف PPTX
  $pres = new Presentation();
  try {
    # يصل إلى الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # يعرّف الأعمدة بعروضها والصفوف بارتفاعها
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
    # يدمج الخلايا (1, 1) x (2, 1)
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);
    # يدمج الخلايا (1, 2) x (2, 2)
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);
    # يقسّم الخلية (1, 1)
    $tbl->get_Item(1, 1)->splitByWidth($tbl->get_Item(2, 1)->getWidth() / 2);
    # يكتب ملف PPTX إلى القرص
    $pres->save("SplitCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Change the Table Cell Background Color**
يعرض لك هذا الكود PHP كيفية تغيير لون خلفية خلية الجدول:
```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    $dblCols = array(150, 150, 150, 150 );
    $dblRows = array(50, 50, 50, 50, 50 );
    # إنشاء جدول جديد
    $table = $slide->getShapes()->addTable(50, 50, $dblCols, $dblRows);
    # تعيين لون الخلفية لخلية
    $cell = $table->get_Item(2, 3);
    $cell->getCellFormat()->getFillFormat()->setFillType(FillType::Solid);
    $cell->getCellFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $presentation->save("cell_background_color.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **Add an Image Inside a Table Cell**
1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) .
2. الحصول على مرجع الشريحة من خلال فهرستها.
3. تحديد مصفوفة من الأعمدة مع العرض.
4. تحديد مصفوفة من الصفوف مع الارتفاع.
5. إضافة جدول إلى الشريحة عبر طريقة [AddTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addTable) .
6. إنشاء كائن `Images` لحفظ ملف الصورة.
7. إضافة صورة `IImage` إلى كائن `IPPImage`.
8. تعيين `FillFormat` لخلية الجدول إلى `Picture`.
9. إضافة الصورة إلى الخلية الأولى في الجدول.
10. حفظ العرض التقديمي المعدل كملف PPTX

يعرض لك هذا الكود PHP كيفية وضع صورة داخل خلية جدول عند إنشاء جدول:
```php
  # ينشئ فئة Presentation التي تمثل ملف PPTX
  $pres = new Presentation();
  try {
    # يصل إلى الشريحة الأولى
    $islide = $pres->getSlides()->get_Item(0);
    # يحدد الأعمدة بعروضها والصفوف بارتفاعها
    $dblCols = array(150, 150, 150, 150 );
    $dblRows = array(100, 100, 100, 100, 90 );
    # يضيف شكل جدول إلى الشريحة
    $tbl = $islide->getShapes()->addTable(50, 50, $dblCols, $dblRows);
    # إنشاء كائن IPPImage باستخدام ملف الصورة
    $picture;
    $image = Images->fromFile("image.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # يضيف الصورة إلى الخلية الأولى في الجدول
    $cellFormat = $tbl->get_Item(0, 0)->getCellFormat();
    $cellFormat::getFillFormat()->setFillType(FillType::Picture);
    $cellFormat::getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    $cellFormat::getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # يحفظ ملف PPTX إلى القرص
    $pres->save("Image_In_TableCell_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Can I set different line thicknesses and styles for different sides of a single cell?**

نعم. حدود [top](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderright/) لها خصائص منفصلة، لذا يمكن أن تختلف السماكة والنمط لكل جانب. يتبع ذلك منطقيًا من التحكم بالحدود حسب الجانب للخلية كما هو موضح في المقال.

**What happens to the image if I change the column/row size after setting a picture as the cell’s background?**

السلوك يعتمد على [fill mode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/) (تمدد/تلبيس). عند التمدد، تتكيف الصورة مع الخلية الجديدة؛ عند التلبيس، يتم إعادة حساب البلاطات. يذكر المقال أوضاع عرض الصورة داخل الخلية.

**Can I assign a hyperlink to all the content of a cell?**

[Hyperlinks](/slides/ar/php-java/manage-hyperlinks/) يتم تعيينها على مستوى النص (القطعة) داخل إطار نص الخلية أو على مستوى الجدول/الشكل بأكمله. عمليًا، تقوم بتعيين الرابط إلى قطعة أو إلى كل النص داخل الخلية.

**Can I set different fonts within a single cell?**

نعم. إطار نص الخلية يدعم [portions](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) (تسلسلات) بحيث يمكن تنسيق كل منها بشكل مستقل—عائلة الخط، النمط، الحجم، واللون.