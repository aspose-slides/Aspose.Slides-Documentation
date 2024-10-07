---
title: إدارة الخلايا
type: docs
weight: 30
url: /php-java/manage-cells/
keywords: "جدول، خلايا مدمجة، خلايا مقسمة، صورة في خلية جدول، Java، Aspose.Slides لـ PHP عبر Java"
description: "خلايا الجدول في العروض التقديمية PowerPoint"
---

## **تحديد خلية جدول مدمجة**
1. قم بإنشاء مثيل من فئة  [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. احصل على الجدول من الشريحة الأولى.
3. قم بالتكرار عبر صفوف وأعمدة الجدول للعثور على الخلايا المدمجة.
4. اطبع رسالة عند العثور على خلايا مدمجة.

هذا الكود PHP يوضح لك كيفية تحديد خلايا الجدول المدمجة في عرض تقديمي:

```php
  $pres = new Presentation("SomePresentationWithTable.pptx");
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);// نفترض أن Slide#0.Shape#0 هو جدول

    for($i = 0; $i < java_values($table->getRows()->size()) ; $i++) {
      for($j = 0; $j < java_values($table->getColumns()->size()) ; $j++) {
        $currentCell = $table->getRows()->get_Item($i)->get_Item($j);
        if ($currentCell->isMergedCell()) {
          echo(sprintf("الخلية %d;%d هي جزء من خلية مدمجة مع RowSpan=%d و ColSpan=%d بدءًا من الخلية %d;%d.", $i, $j, $currentCell->getRowSpan(), $currentCell->getColSpan(), $currentCell->getFirstRowIndex(), $currentCell->getFirstColumnIndex()));
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **إزالة حدود خلايا الجدول**
1. قم بإنشاء مثيل من فئة  [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. احصل على مرجع الشريحة من خلال فهرسها.
3. عرّف مصفوفة من الأعمدة بعرض.
4. عرّف مصفوفة من الصفوف ارتفاع.
5. أضف جدولًا إلى الشريحة من خلال طريقة [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-).
6. تكرر عبر كل خلية لمسح الحدود العليا والسفلى واليمنى واليسرى.
7. احفظ العرض التقديمي المعدل كملف PPTX.

هذا الكود PHP يوضح لك كيفية إزالة الحدود من خلايا الجدول:

```php
  # ينشئ مثيل من فئة Presentation تمثل ملف PPTX
  $pres = new Presentation();
  try {
    # الوصول إلى الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # يعرّف أعمدة بعرض و صفوف بارتفاع
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

## **ترقيم في الخلايا المدمجة**
إذا قمنا بدمج زوجين من الخلايا (1، 1) × (2، 1) و(1، 2) × (2، 2)، سيكون الجدول الناتج مرقمًا. هذا الكود PHP يوضح العملية:

```php
  # ينشئ مثيل من فئة Presentation تمثل ملف PPTX
  $pres = new Presentation();
  try {
    # الوصول إلى الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # يعرّف أعمدة بعرض و صفوف بارتفاع
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
    # يدمج الخلايا (1، 1) × (2، 1)
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);
    # يدمج الخلايا (1، 2) × (2، 2)
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);
    $pres->save("MergeCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

نقوم بعد ذلك بدمج الخلايا بشكل أكبر عن طريق دمج (1، 1) و (1، 2). النتيجة هي جدول يحتوي على خلية مدمجة كبيرة في وسطه: 

```php
  # ينشئ مثيل من فئة Presentation تمثل ملف PPTX
  $pres = new Presentation();
  try {
    # الوصول إلى الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # يعرّف أعمدة بعرض و صفوف بارتفاع
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
    # يدمج الخلايا (1، 1) × (2، 1)
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);
    # يدمج الخلايا (1، 2) × (2، 2)
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);
    # يدمج الخلايا (1، 1) × (1، 2)
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(1, 2), true);
    # يكتب ملف PPTX إلى القرص
    $pres->save("MergeCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ترقيم في الخلية المقسمة**
في الأمثلة السابقة، عندما تم دمج خلايا الجدول، لم يتغير الترقيم أو نظام الأرقام في الخلايا الأخرى.

هذه المرة، نأخذ جدولًا عاديًا (جدول بدون خلايا مدمجة) ثم نحاول تقسيم الخلية (1،1) للحصول على جدول خاص. قد ترغب في الانتباه إلى ترقيم هذا الجدول، والذي قد يعتبر غريبًا. ومع ذلك، هذه هي الطريقة التي ترقم بها Microsoft PowerPoint خلايا الجدول و Aspose.Slides تفعل نفس الشيء. 

هذا الكود PHP يوضح العملية التي وصفناها:

```php
  # ينشئ مثيل من فئة Presentation تمثل ملف PPTX
  $pres = new Presentation();
  try {
    # الوصول إلى الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # يعرّف أعمدة بعرض و صفوف بارتفاع
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
    # يدمج الخلايا (1، 1) × (2، 1)
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);
    # يدمج الخلايا (1، 2) × (2، 2)
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);
    # تقسيم الخلية (1، 1)
    $tbl->get_Item(1, 1)->splitByWidth($tbl->get_Item(2, 1)->getWidth() / 2);
    # يكتب ملف PPTX إلى القرص
    $pres->save("SplitCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تغيير لون خلفية خلية الجدول**

هذا الكود PHP يوضح لك كيفية تغيير لون خلفية خلية الجدول:

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

## **إضافة صورة داخل خلية جدول**

1. قم بإنشاء مثيل من فئة  [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. احصل على مرجع الشريحة من خلال فهرسها.
3. عرّف مصفوفة من الأعمدة بعرض.
4. عرّف مصفوفة من الصفوف بارتفاع.
5. أضف جدولًا إلى الشريحة من خلال طريقة [AddTable](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-).
6. قم بإنشاء كائن `Images` للإحتفاظ بملف الصورة.
7. أضف الصورة `IImage` إلى كائن `IPPImage`.
8. قم بتعيين `FillFormat` لخلية الجدول إلى `Picture`.
9. أضف الصورة إلى الخلية الأولى في الجدول.
10. احفظ العرض التقديمي المعدل كملف PPTX.

هذا الكود PHP يوضح لك كيفية وضع صورة داخل خلية جدول عند إنشاء جدول:

```php
  # ينشئ مثيل من فئة Presentation تمثل ملف PPTX
  $pres = new Presentation();
  try {
    # الوصول إلى الشريحة الأولى
    $islide = $pres->getSlides()->get_Item(0);
    # يعرّف أعمدة بعرض و صفوف بارتفاع
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