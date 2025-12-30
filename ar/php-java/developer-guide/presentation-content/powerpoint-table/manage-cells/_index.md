---
title: إدارة خلايا الجدول في العروض التقديمية باستخدام PHP
linktitle: إدارة الخلايا
type: docs
weight: 30
url: /ar/php-java/manage-cells/
keywords:
- خلية جدول
- دمج الخلايا
- إزالة الحدود
- تقسيم الخلية
- صورة في الخلية
- لون الخلفية
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "إدارة خلايا الجدول في PowerPoint بسهولة باستخدام Aspose.Slides للـ PHP. إتقان الوصول إلى الخلايا وتعديلها وتنسيقها بسرعة لتحقيق أتمتة سلسة للشرائح."
---

## **تحديد خلية جدول مدمجة**
1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. الحصول على الجدول من الشريحة الأولى.
3. التنقل عبر صفوف وأعمدة الجدول للعثور على الخلايا المدمجة.
4. طباعة رسالة عند العثور على خلايا مدمجة.

يوضح لك هذا الكود PHP كيفية تحديد الخلايا المدمجة في جدول عرض تقديمي:
```php
  $pres = new Presentation("SomePresentationWithTable.pptx");
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);// بافتراض أن الشريحة #0.الشكل #0 هو جدول

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


## **إزالة حدود خلية الجدول**
1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. الحصول على مرجع الشريحة عبر فهرستها.
3. تعريف مصفوفة الأعمدة مع العرض.
4. تعريف مصفوفة الصفوف مع الارتفاع.
5. إضافة جدول إلى الشريحة عبر طريقة [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-).
6. التنقل عبر كل خلية لمسح الحدود العلوية والسفلية واليمين واليسار.
7. حفظ العرض التقديمي المعدل كملف PPTX.

يوضح لك هذا الكود PHP كيفية إزالة الحدود من خلايا الجدول:
```php
  # إنشاء كائن من فئة Presentation التي تمثل ملف PPTX
  $pres = new Presentation();
  try {
    # الوصول إلى الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # تعريف الأعمدة بعرضها والصفوف بارتفاعها
    $dblCols = array(50, 50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # إضافة شكل جدول إلى الشريحة
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # تعيين تنسيق الحدود لكل خلية
    foreach($tbl->getRows() as $row) {
      foreach($row as $cell) {
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::NoFill);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::NoFill);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::NoFill);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::NoFill);
      }
    }
    # حفظ ملف PPTX على القرص
    $pres->save("table_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **الترقيم في الخلايا المدمجة**
إذا دمجنا زوجين من الخلايا (1, 1) × (2, 1) و (1, 2) × (2, 2)، سيصبح الجدول الناتج مرقمًا. يوضح لك هذا الكود PHP العملية:
```php
  # يخلق كائن من فئة Presentation التي تمثل ملف PPTX
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
    $pres->save("MergeCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


ثم نقوم بدمج الخلايا أكثر بدمج (1, 1) و (1, 2). النتيجة هي جدول يحتوي على خلية مدمجة كبيرة في مركزه:
```php
  # ينشئ كائن من فئة Presentation التي تمثل ملف PPTX
  $pres = new Presentation();
  try {
    # الوصول إلى الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # تحديد الأعمدة بعرضها والصفوف بارتفاعها
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # إضافة شكل جدول إلى الشريحة
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # تعيين تنسيق الحدود لكل خلية
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
    # دمج الخلايا (1, 1) × (1, 2)
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(1, 2), true);
    # كتابة ملف PPTX إلى القرص
    $pres->save("MergeCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **الترقيم في خلية مقسمة**
في الأمثلة السابقة، عندما تم دمج خلايا الجدول، لم يتغير نظام الترقيم أو الأرقام في الخلايا الأخرى.

هذه المرة، نأخذ جدولًا عاديًا (جدول بدون خلايا مدمجة) ثم نحاول تقسيم الخلية (1,1) للحصول على جدول خاص. قد ترغب في إلقاء الانتباه على ترقيم هذا الجدول، والذي قد يبدو غريبًا. ومع ذلك، فهذا هو الطريقة التي يقوم بها Microsoft PowerPoint في ترقيم خلايا الجدول، وتقوم Aspose.Slides بنفس الشيء.

يوضح لك هذا الكود PHP العملية التي وصفناها:
```php
  # ينشئ كائن من فئة Presentation التي تمثل ملف PPTX
  $pres = new Presentation();
  try {
    # يصل إلى الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # يحدد الأعمدة بأعرضها والصفوف بأارتفاعها
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
    # يدعم الخلايا (1, 1) x (2, 1)
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);
    # يدعم الخلايا (1, 2) x (2, 2)
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);
    # يقسم الخلية (1, 1)
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
يوضح لك هذا الكود PHP كيفية تغيير لون خلفية خلية الجدول:
```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    $dblCols = array(150, 150, 150, 150 );
    $dblRows = array(50, 50, 50, 50, 50 );
    # إنشاء جدول جديد
    $table = $slide->getShapes()->addTable(50, 50, $dblCols, $dblRows);
    # تعيين لون الخلفية للخلية
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
1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. الحصول على مرجع الشريحة عبر فهرستها.
3. تعريف مصفوفة الأعمدة مع العرض.
4. تعريف مصفوفة الصفوف مع الارتفاع.
5. إضافة جدول إلى الشريحة عبر طريقة [AddTable](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-).
6. إنشاء كائن `Images` لحفظ ملف الصورة.
7. إضافة صورة `IImage` إلى كائن `IPPImage`.
8. تعيين `FillFormat` لخلية الجدول إلى `Picture`.
9. إضافة الصورة إلى الخلية الأولى للجدول.
10. حفظ العرض التقديمي المعدل كملف PPTX

يوضح لك هذا الكود PHP كيفية وضع صورة داخل خلية جدول عند إنشاء جدول:
```php
  # ينشئ كائن من فئة Presentation التي تمثل ملف PPTX
  $pres = new Presentation();
  try {
    # الوصول إلى الشريحة الأولى
    $islide = $pres->getSlides()->get_Item(0);
    # يحدد الأعمدة بأعرضها والصفوف بأارتفاعها
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
    # يضيف الصورة إلى خلية الجدول الأولى
    $cellFormat = $tbl->get_Item(0, 0)->getCellFormat();
    $cellFormat::getFillFormat()->setFillType(FillType::Picture);
    $cellFormat::getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    $cellFormat::getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # يحفظ ملف PPTX على القرص
    $pres->save("Image_In_TableCell_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **الأسئلة المتكررة**

**هل يمكنني ضبط سماكات الخطوط وأنماطها المختلفة لجوانب مختلفة من خلية واحدة؟**

نعم. الحدود [top](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderright/) لها خصائص منفصلة، لذا يمكن أن تختلف سماكة كل جانب ونمطه. يتبع هذا منطقياً من التحكم بالحدود لكل جانب كما هو موضح في المقال.

**ماذا يحدث للصورة إذا قمت بتغيير حجم العمود/الصف بعد تعيين صورة كخلفية للخلية؟**

السلوك يعتمد على [fill mode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/) (تمدد/بلاط). مع التمدد، تتكيف الصورة مع الخلية الجديدة؛ مع التبليط، تُعاد حساب البلاط. يذكر المقال أوضاع عرض الصورة في الخلية.

**هل يمكنني تعيين ارتباط تشعبي لكل محتوى الخلية؟**

يتم تعيين [Hyperlinks](/slides/ar/php-java/manage-hyperlinks/) على مستوى النص (الجزء) داخل إطار النص الخاص بالخلية أو على مستوى الجدول/الشكل بالكامل. عمليًا، تقوم بتعيين الرابط إلى جزء أو إلى كل النص في الخلية.

**هل يمكنني تعيين خطوط مختلفة داخل خلية واحدة؟**

نعم. يدعم إطار نص الخلية [portions](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) (تشغيلات) تنسيقًا مستقلاً—عائلة الخط، النمط، الحجم، واللون.