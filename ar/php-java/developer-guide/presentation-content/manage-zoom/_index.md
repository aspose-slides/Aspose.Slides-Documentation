---
title: إدارة تكبير العرض التقديمي في PHP
linktitle: إدارة التكبير
type: docs
weight: 60
url: /ar/php-java/manage-zoom/
keywords:
- تكبير
- إطار التكبير
- تكبير الشريحة
- تكبير القسم
- تكبير الملخص
- إضافة تكبير
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "إنشاء وتخصيص التكبير باستخدام Aspose.Slides لـ PHP عبر Java — الانتقال بين الأقسام، إضافة صور مصغرة وانتقالات عبر عروض PPT و PPTX و ODP."
---

## **نظرة عامة**
تسمح لك خاصية التكبير في PowerPoint بالقفز إلى ومن الشرائح، الأقسام، والأجزاء المحددة من العرض التقديمي. عند تقديمك، قد تكون هذه القدرة على التنقل السريع عبر المحتوى مفيدة جدًا. 

![overview_image](overview.png)

* لتلخيص العرض التقديمي بأكمله على شريحة واحدة، استخدم [Summary Zoom](#Summary-Zoom).
* لعرض الشرائح المحددة فقط، استخدم [Slide Zoom](#Slide-Zoom).
* لعرض قسم واحد فقط، استخدم [Section Zoom](#Section-Zoom).

## **تكبير الشريحة**
يمكن لتكبير الشريحة أن يجعل عرضك التقديمي أكثر ديناميكية، ويسمح لك بالتنقل بحرية بين الشرائح بأي ترتيب تختاره دون إيقاف سير العرض. تكبيرات الشرائح مفيدة للعروض القصيرة التي لا تحتوي على أقسام كثيرة، ولكن يمكنك أيضًا استخدامها في سيناريوهات عرض مختلفة.

تساعدك تكبيرات الشرائح على الغوص في عدة أجزاء من المعلومات بينما تشعر وكأنك على لوحة واحدة. 

![overview_image](slidezoomsel.png)

للكائنات الخاصة بتكبير الشرائح، توفر Aspose.Slides تعداد [ZoomImageType](https://reference.aspose.com/slides/php-java/aspose.slides/ZoomImageType) والواجهة [IZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IZoomFrame) وبعض الطرق داخل الواجهة [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection).

### **إنشاء إطارات التكبير**
يمكنك إضافة إطار تكبير إلى شريحة بهذه الطريقة:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. إنشاء شرائح جديدة تريد ربط إطارات التكبير بها.
3. إضافة نص تعريف وخلفية إلى الشرائح التي تم إنشاؤها.
4. إضافة إطارات تكبير (تحتوي على مراجع إلى الشرائح التي تم إنشاؤها) إلى الشريحة الأولى.
5. حفظ العرض التقديمي المعدل كملف PPTX.

يعرض لك هذا الكود PHP كيفية إنشاء إطار تكبير على شريحة:
```php
  $pres = new Presentation();
  try {
    # يضيف شرائح جديدة إلى العرض التقديمي
    $slide2 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide3 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    # ينشئ خلفية للشريحة الثانية
    $slide2->getBackground()->setType(BackgroundType::OwnBackground);
    $slide2->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide2->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    # ينشئ مربع نص للشريحة الثانية
    $autoshape = $slide2->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Second Slide");
    # ينشئ خلفية للشريحة الثالثة
    $slide3->getBackground()->setType(BackgroundType::OwnBackground);
    $slide3->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide3->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->darkGray);
    # ينشئ مربع نص للشريحة الثالثة
    $autoshape = $slide3->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Trird Slide");
    # يضيف كائنات ZoomFrame
    $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(20, 20, 250, 200, $slide2);
    $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(200, 250, 250, 200, $slide3);
    # يحفظ العرض التقديمي
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **إنشاء إطارات تكبير بصور مخصصة**
باستخدام Aspose.Slides لـ PHP عبر Java، يمكنك إنشاء إطار تكبير بصورة معاينة شريحة مختلفة بهذه الطريقة:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. إنشاء شريحة جديدة تريد ربط إطار التكبير بها.
3. إضافة نص تعريف وخلفية إلى الشريحة.
4. إنشاء كائن [IPPImage] عن طريق إضافة صورة إلى مجموعة Images المرتبطة بكائن [Presentation] الذي سيُستخدم لتعبئة الإطار.
5. إضافة إطارات تكبير (تحتوي على مرجع إلى الشريحة التي تم إنشاؤها) إلى الشريحة الأولى.
6. حفظ العرض التقديمي المعدل كملف PPTX.

يعرض لك هذا الكود PHP كيفية إنشاء إطار تكبير بصورة مختلفة:
```php
  $pres = new Presentation();
  try {
    # يضيف شريحة جديدة إلى العرض التقديمي
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    # ينشئ خلفية للشريحة الثانية
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    # ينشئ مربع نص للشريحة الثالثة
    $autoshape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Second Slide");
    # ينشئ صورة جديدة لكائن التكبير
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # يضيف كائن ZoomFrame
    $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(20, 20, 300, 200, $slide, $picture);
    # يحفظ العرض التقديمي
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **تنسيق إطارات التكبير**
في الأقسام السابقة، أظهرنا لك كيفية إنشاء إطارات تكبير بسيطة. لإنشاء إطارات تكبير أكثر تعقيدًا، عليك تعديل تنسيق الإطار البسيط. هناك عدة خيارات تنسيق يمكنك تطبيقها على إطار التكبير.

يمكنك التحكم في تنسيق إطار التكبير على شريحة بهذه الطريقة:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. إنشاء شرائح جديدة لربط إطار التكبير بها.
3. إضافة بعض نصوص التعريف وخلفية إلى الشرائح التي تم إنشاؤها.
4. إضافة إطارات تكبير (تحتوي على المراجع إلى الشرائح التي تم إنشاؤها) إلى الشريحة الأولى.
5. إنشاء كائن [IPPImage] عن طريق إضافة صورة إلى مجموعة Images المرتبطة بكائن [Presentation] الذي سيُستخدم لتعبئة الإطار.
6. تعيين صورة مخصصة لكائن إطار التكبير الأول.
7. تغيير تنسيق الخط لكائن إطار التكبير الثاني.
8. إزالة الخلفية من صورة كائن إطار التكبير الثاني.
9. حفظ العرض التقديمي المعدل كملف PPTX.

يعرض لك هذا الكود PHP كيفية تغيير تنسيق إطار التكبير على شريحة:
```php
  $pres = new Presentation();
  try {
    # يضيف شرائح جديدة إلى العرض التقديمي
    $slide2 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide3 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    # ينشئ خلفية للشريحة الثانية
    $slide2->getBackground()->setType(BackgroundType::OwnBackground);
    $slide2->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide2->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    # ينشئ مربع نص للشريحة الثانية
    $autoshape = $slide2->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Second Slide");
    # ينشئ خلفية للشريحة الثالثة
    $slide3->getBackground()->setType(BackgroundType::OwnBackground);
    $slide3->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide3->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->darkGray);
    # ينشئ مربع نص للشريحة الثالثة
    $autoshape = $slide3->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Trird Slide");
    # يضيف كائنات ZoomFrame
    $zoomFrame1 = $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(20, 20, 250, 200, $slide2);
    $zoomFrame2 = $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(200, 250, 250, 200, $slide3);
    # ينشئ صورة جديدة لكائن التكبير
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # يضبط صورة مخصصة لكائن zoomFrame1
    $zoomFrame1->setImage($picture);
    # يضبط تنسيق إطار التكبير لكائن zoomFrame2
    $zoomFrame2->getLineFormat()->setWidth(5);
    $zoomFrame2->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $zoomFrame2->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->pink);
    $zoomFrame2->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    # إعداد عدم إظهار الخلفية لكائن zoomFrame2
    $zoomFrame2->setShowBackground(false);
    # يحفظ العرض التقديمي
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **تكبير القسم**
تكبير القسم هو رابط إلى قسم في عرضك التقديمي. يمكنك استخدام تكبيرات الأقسام للعودة إلى الأقسام التي تريد التأكيد عليها بقوة. أو يمكنك استخدامها لتسليط الضوء على كيفية ارتباط أجزاء معينة من عرضك.

![overview_image](seczoomsel.png)

للكائنات الخاصة بتكبير الأقسام، توفر Aspose.Slides الواجهة [ISectionZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ISectionZoomFrame) وبعض الطرق داخل الواجهة [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection).

### **إنشاء إطارات تكبير القسم**
يمكنك إضافة إطار تكبير قسم إلى شريحة بهذه الطريقة:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. إنشاء شريحة جديدة.
3. إضافة خلفية تعريفية إلى الشريحة التي تم إنشاؤها.
4. إنشاء قسم جديد تريد ربط إطار التكبير به.
5. إضافة إطار تكبير قسم (يحتوي على مراجع إلى القسم الذي تم إنشاؤه) إلى الشريحة الأولى.
6. حفظ العرض التقديمي المعدل كملف PPTX.

يعرض لك هذا الكود PHP كيفية إنشاء إطار تكبير على شريحة:
```php
  $pres = new Presentation();
  try {
    # يضيف شريحة جديدة إلى العرض التقديمي
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # يضيف قسمًا جديدًا إلى العرض التقديمي
    $pres->getSections()->addSection("Section 1", $slide);
    # يضيف كائن SectionZoomFrame
    $sectionZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $pres->getSections()->get_Item(1));
    # يحفظ العرض التقديمي
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **إنشاء إطارات تكبير القسم بصور مخصصة**
باستخدام Aspose.Slides لـ PHP عبر Java، يمكنك إنشاء إطار تكبير قسم بصورة معاينة شريحة مختلفة بهذه الطريقة:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. إنشاء شريحة جديدة.
3. إضافة خلفية تعريفية إلى الشريحة التي تم إنشاؤها.
4. إنشاء قسم جديد تريد ربط إطار التكبير به.
5. إنشاء كائن [IPPImage] عن طريق إضافة صورة إلى مجموعة Images المرتبطة بكائن [Presentation] الذي سيُستخدم لتعبئة الإطار.
6. إضافة إطار تكبير قسم (يحتوي على مرجع إلى القسم الذي تم إنشاؤه) إلى الشريحة الأولى.
7. حفظ العرض التقديمي المعدل كملف PPTX.

يعرض لك هذا الكود PHP كيفية إنشاء إطار تكبير بصورة مختلفة:
```php
  $pres = new Presentation();
  try {
    # يضيف شريحة جديدة إلى العرض التقديمي
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # يضيف قسمًا جديدًا إلى العرض التقديمي
    $pres->getSections()->addSection("Section 1", $slide);
    # ينشئ صورة جديدة لكائن التكبير
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # يضيف كائن SectionZoomFrame
    $sectionZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $pres->getSections()->get_Item(1), $picture);
    # يحفظ العرض التقديمي
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **تنسيق إطارات تكبير القسم**
لإنشاء إطارات تكبير قسم أكثر تعقيدًا، عليك تعديل تنسيق الإطار البسيط. هناك عدة خيارات تنسيق يمكنك تطبيقها على إطار تكبير القسم.

يمكنك التحكم في تنسيق إطار تكبير القسم على شريحة بهذه الطريقة:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. إنشاء شريحة جديدة.
3. إضافة خلفية تعريفية إلى الشريحة التي تم إنشاؤها.
4. إنشاء قسم جديد تريد ربط إطار التكبير به.
5. إضافة إطار تكبير قسم (يحتوي على مراجع إلى القسم الذي تم إنشاؤه) إلى الشريحة الأولى.
6. تغيير حجم وموقع كائن تكبير القسم الذي تم إنشاؤه.
7. إنشاء كائن [IPPImage] عن طريق إضافة صورة إلى مجموعة Images المرتبطة بكائن [Presentation] الذي سيُستخدم لتعبئة الإطار.
8. تعيين صورة مخصصة لكائن إطار تكبير القسم الذي تم إنشاؤه.
9. تعيين قدرة *العودة إلى الشريحة الأصلية من القسم المرتبط*.
10. إزالة الخلفية من صورة كائن إطار تكبير القسم.
11. تغيير تنسيق الخط لكائن إطار التكبير الثاني.
12. تغيير مدة الانتقال.
13. حفظ العرض التقديمي المعدل كملف PPTX.

يعرض لك هذا الكود PHP كيفية تغيير تنسيق إطار تكبير القسم:
```php
  $pres = new Presentation();
  try {
    # يضيف شريحة جديدة إلى العرض التقديمي
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # يضيف قسمًا جديدًا إلى العرض التقديمي
    $pres->getSections()->addSection("Section 1", $slide);
    # يضيف كائن SectionZoomFrame
    $sectionZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $pres->getSections()->get_Item(1));
    # تنسيق كائن SectionZoomFrame
    $sectionZoomFrame->setX(100);
    $sectionZoomFrame->setY(300);
    $sectionZoomFrame->setWidth(100);
    $sectionZoomFrame->setHeight(75);
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $sectionZoomFrame->setImage($picture);
    $sectionZoomFrame->setReturnToParent(true);
    $sectionZoomFrame->setShowBackground(false);
    $sectionZoomFrame->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $sectionZoomFrame->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $sectionZoomFrame->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    $sectionZoomFrame->getLineFormat()->setWidth(2.5);
    $sectionZoomFrame->setTransitionDuration(1.5);
    # يحفظ العرض التقديمي
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **تكبير الملخص**
تكبير الملخص يشبه صفحة هبوط حيث يتم عرض جميع أجزاء عرضك التقديمي مرة واحدة. عند تقديمك، يمكنك استخدام التكبير للانتقال من مكان إلى آخر في عرضك بأي ترتيب ترغب به. يمكنك الإبداع، التخطي إلى الأمام، أو الرجوع إلى أجزاء من عرض الشرائح دون إيقاف تدفق العرض.

![overview_image](sumzoomsel.png)

للكائنات الخاصة بتكبير الملخص، توفر Aspose.Slides الواجهات [ISummaryZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ISummaryZoomFrame)، [ISummaryZoomSection](https://reference.aspose.com/slides/php-java/aspose.slides/ISummaryZoomSection)، و[ISummaryZoomSectionCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISummaryZoomSectionCollection) وبعض الطرق داخل الواجهة [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection).

### **إنشاء تكبير ملخص**
يمكنك إضافة إطار تكبير ملخص إلى شريحة بهذه الطريقة:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. إنشاء شرائح جديدة مع خلفية تعريفية وأقسام جديدة للشرائح التي تم إنشاؤها.
3. إضافة إطار تكبير الملخص إلى الشريحة الأولى.
4. حفظ العرض التقديمي المعدل كملف PPTX.

يعرض لك هذا الكود PHP كيفية إنشاء إطار تكبير ملخص على شريحة:
```php
  $pres = new Presentation();
  try {
    # يضيف شريحة جديدة إلى العرض التقديمي
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # يضيف قسمًا جديدًا إلى العرض التقديمي
    $pres->getSections()->addSection("Section 1", $slide);
    # يضيف شريحة جديدة إلى العرض التقديمي
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # يضيف قسمًا جديدًا إلى العرض التقديمي
    $pres->getSections()->addSection("Section 2", $slide);
    # يضيف شريحة جديدة إلى العرض التقديمي
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->magenta);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # يضيف قسمًا جديدًا إلى العرض التقديمي
    $pres->getSections()->addSection("Section 3", $slide);
    # يضيف شريحة جديدة إلى العرض التقديمي
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->green);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # يضيف قسمًا جديدًا إلى العرض التقديمي
    $pres->getSections()->addSection("Section 4", $slide);
    # يضيف كائن SummaryZoomFrame
    $summaryZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);
    # يحفظ العرض التقديمي
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **إضافة وإزالة قسم تكبير ملخص**
جميع الأقسام في إطار تكبير الملخص ممثلة بكائنات [ISummaryZoomSection](https://reference.aspose.com/slides/php-java/aspose.slides/ISummaryZoomSection) المخزنة في كائن [ISummaryZoomSectionCollection]. يمكنك إضافة أو إزالة كائن قسم تكبير ملخص عبر الواجهة [ISummaryZoomSectionCollection] بهذه الطريقة:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. إنشاء شرائح جديدة مع خلفية تعريفية وأقسام جديدة للشرائح التي تم إنشاؤها.
3. إضافة إطار تكبير الملخص إلى الشريحة الأولى.
4. إضافة شريحة وقسم جديدين إلى العرض.
5. إضافة القسم الذي تم إنشاؤه إلى إطار تكبير الملخص.
6. إزالة القسم الأول من إطار تكبير الملخص.
7. حفظ العرض التقديمي المعدل كملف PPTX.

يعرض لك هذا الكود PHP كيفية إضافة وإزالة أقسام في إطار تكبير ملخص:
```php
  $pres = new Presentation();
  try {
    # يضيف شريحة جديدة إلى العرض التقديمي
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # يضيف قسمًا جديدًا إلى العرض التقديمي
    $pres->getSections()->addSection("Section 1", $slide);
    # يضيف شريحة جديدة إلى العرض التقديمي
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # يضيف قسمًا جديدًا إلى العرض التقديمي
    $pres->getSections()->addSection("Section 2", $slide);
    # يضيف كائن SummaryZoomFrame
    $summaryZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);
    # يضيف شريحة جديدة إلى العرض التقديمي
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->magenta);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # يضيف قسمًا جديدًا إلى العرض التقديمي
    $section3 = $pres->getSections()->addSection("Section 3", $slide);
    # يضيف قسمًا إلى ملخص التكبير
    $summaryZoomFrame->getSummaryZoomCollection()->addSummaryZoomSection($section3);
    # يزيل القسم من ملخص التكبير
    $summaryZoomFrame->getSummaryZoomCollection()->removeSummaryZoomSection($pres->getSections()->get_Item(1));
    # يحفظ العرض التقديمي
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **تنسيق أقسام تكبير الملخص**
لإنشاء كائنات أقسام تكبير ملخص أكثر تعقيدًا، عليك تعديل تنسيق الإطار البسيط. هناك عدة خيارات تنسيق يمكنك تطبيقها على كائن قسم تكبير الملخص.

يمكنك التحكم في تنسيق كائن قسم تكبير ملخص داخل إطار التكبير بهذه الطريقة:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. إنشاء شرائح جديدة مع خلفية تعريفية وأقسام جديدة للشرائح التي تم إنشاؤها.
3. إضافة إطار تكبير الملخص إلى الشريحة الأولى.
4. الحصول على كائن قسم تكبير ملخص من `ISummaryZoomSectionCollection` للعنصر الأول.
5. إنشاء كائن [IPPImage] عن طريق إضافة صورة إلى مجموعة الصور المرتبطة بكائن [Presentation] الذي سيُستخدم لتعبئة الإطار.
6. تعيين صورة مخصصة لكائن إطار تكبير القسم الذي تم إنشاؤه.
7. تعيين قدرة *العودة إلى الشريحة الأصلية من القسم المرتبط*.
8. تغيير تنسيق الخط لكائن إطار التكبير الثاني.
9. تغيير مدة الانتقال.
10. حفظ العرض التقديمي المعدل كملف PPTX.

يعرض لك هذا الكود PHP كيفية تغيير تنسيق كائن قسم تكبير ملخص:
```php
  $pres = new Presentation();
  try {
    # يضيف شريحة جديدة إلى العرض التقديمي
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # يضيف قسمًا جديدًا إلى العرض التقديمي
    $pres->getSections()->addSection("Section 1", $slide);
    # يضيف شريحة جديدة إلى العرض التقديمي
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # يضيف قسمًا جديدًا إلى العرض التقديمي
    $pres->getSections()->addSection("Section 2", $slide);
    # يضيف كائن SummaryZoomFrame
    $summaryZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);
    # يحصل على أول كائن SummaryZoomSection
    $summarySection = $summaryZoomFrame->getSummaryZoomCollection()->get_Item(0);
    # تنسيق كائن SummaryZoomSection
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($picture);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $summarySection->setImage($picture);
    $summarySection->setReturnToParent(false);
    $summarySection->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $summarySection->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->black);
    $summarySection->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    $summarySection->getLineFormat()->setWidth(1.5);
    $summarySection->setTransitionDuration(1.5);
    # يحفظ العرض التقديمي
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **الأسئلة الشائعة**

**هل يمكنني التحكم في العودة إلى الشريحة 'الأصلية' بعد عرض الهدف؟**

نعم. تحتوي إطارات [Zoom frame](https://reference.aspose.com/slides/php-java/aspose.slides/zoomframe/) أو [section](https://reference.aspose.com/slides/php-java/aspose.slides/sectionzoomframe/) على سلوك `ReturnToParent`، والذي عند تفعيله يعيد المشاهدين إلى الشريحة الأصلية بعد زيارة المحتوى المستهدف.

**هل يمكنني ضبط 'السرعة' أو مدة انتقال التكبير؟**

نعم. يدعم التكبير ضبط `TransitionDuration` بحيث يمكنك التحكم في مدة حركة القفزة.

**هل هناك حدود لعدد كائنات التكبير التي يمكن أن يحتويها العرض التقديمي؟**

لا يوجد حد صريح موثق في الـ API. تعتمد الحدود العملية على تعقيد العرض التقديمي العام وأداء المشاهد. يمكنك إضافة العديد من إطارات التكبير، لكن ينبغي مراعاة حجم الملف ووقت التحميل.