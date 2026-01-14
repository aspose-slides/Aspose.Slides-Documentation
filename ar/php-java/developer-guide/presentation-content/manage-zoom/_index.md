---
title: إدارة تكبير العرض التقديمي في PHP
linktitle: إدارة التكبير
type: docs
weight: 60
url: /ar/php-java/manage-zoom/
keywords:
- تكبير
- إطار تكبير
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
Zooms in PowerPoint allow you to jump to and from specific slides, sections, and portions of a presentation. When you are presenting, this ability to navigate quickly across content might prove very useful. 

![overview_image](overview.png)

* لتلخص عرض تقديمي كامل على شريحة واحدة، استخدم [Summary Zoom](#Summary-Zoom).
* لعرض الشرائح المحددة فقط، استخدم [Slide Zoom](#Slide-Zoom).
* لعرض قسم واحد فقط، استخدم [Section Zoom](#Section-Zoom).

## **تكبير الشريحة**
يمكن لتكبير الشريحة أن يجعل عرضك التقديمي أكثر ديناميكية، مما يسمح لك بالانتقال بحرية بين الشرائح بأي ترتيب تختاره دون إيقاف تدفق العرض. تكبيرات الشرائح رائعة للعروض القصيرة التي لا تحتوي على أقسام كثيرة، ولكن يمكنك أيضًا استخدامها في سيناريوهات عرض مختلفة.

تساعدك تكبيرات الشرائح على التعمق في معلومات متعددة بينما تشعر وكأنك على لوحة واحدة. 

![overview_image](slidezoomsel.png)

بالنسبة لكائنات تكبير الشريحة، توفر Aspose.Slides تعداد [ZoomImageType](https://reference.aspose.com/slides/php-java/aspose.slides/zoomimagetype/)، فئة [ZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/zoomframe/)، وبعض الأساليب تحت فئة [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/).

### **إنشاء إطارات التكبير**
يمكنك إضافة إطار تكبير إلى شريحة بهذه الطريقة:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. إنشاء شرائح جديدة التي تنوي ربط إطارات التكبير بها. 
3. إضافة نص تعريف وخلفية إلى الشرائح التي تم إنشاؤها.
4. إضافة إطارات التكبير (التي تحتوي على مراجع الشرائح التي تم إنشاؤها) إلى الشريحة الأولى.
5. كتابة العرض المعدل كملف PPTX.

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
    # ينشئ صندوق نص للشريحة الثانية
    $autoshape = $slide2->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Second Slide");
    # ينشئ خلفية للشريحة الثالثة
    $slide3->getBackground()->setType(BackgroundType::OwnBackground);
    $slide3->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide3->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->darkGray);
    # ينشئ صندوق نص للشريحة الثالثة
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
باستخدام Aspose.Slides ل PHP عبر Java، يمكنك إنشاء إطار تكبير بصورة معاينة شريحة مختلفة بهذه الطريقة:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. إنشاء شريحة جديدة التي تنوي ربط إطار التكبير بها. 
3. إضافة نص تعريف وخلفية إلى الشريحة.
4. إنشاء كائن [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) عن طريق إضافة صورة إلى مجموعة Images المرتبطة بكائن [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) الذي سيُستخدم لملء الإطار.
5. إضافة إطارات التكبير (التي تحتوي على مرجع الشريحة التي تم إنشاؤها) إلى الشريحة الأولى.
6. كتابة العرض المعدل كملف PPTX.

```php
  $pres = new Presentation();
  try {
    # يضيف شريحة جديدة إلى العرض التقديمي
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    # ينشئ خلفية للشريحة الثانية
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    # ينشئ صندوق نص للشريحة الثالثة
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

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. إنشاء شرائح جديدة للربط والتي تنوي ربط إطار التكبير بها. 
3. إضافة بعض نصوص التعريف وخلفية إلى الشرائح التي تم إنشاؤها.
4. إضافة إطارات التكبير (التي تحتوي على مراجع الشرائح التي تم إنشاؤها) إلى الشريحة الأولى.
5. إنشاء كائن [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) عن طريق إضافة صورة إلى مجموعة Images المرتبطة بكائن [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) الذي سيُستخدم لملء الإطار.
6. تعيين صورة مخصصة لكائن إطار التكبير الأول.
7. تغيير تنسيق الخط لكائن إطار التكبير الثاني.
8. إزالة الخلفية من صورة كائن إطار التكبير الثاني.
5. كتابة العرض المعدل كملف PPTX.

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
    # ينشئ صندوق نص للشريحة الثانية
    $autoshape = $slide2->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Second Slide");
    # ينشئ خلفية للشريحة الثالثة
    $slide3->getBackground()->setType(BackgroundType::OwnBackground);
    $slide3->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide3->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->darkGray);
    # ينشئ صندوق نص للشريحة الثالثة
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
    # يحدد صورة مخصصة لكائن zoomFrame1
    $zoomFrame1->setImage($picture);
    # يحدد تنسيق إطار التكبير لكائن zoomFrame2
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
تكبير القسم هو رابط إلى قسم في عرضك التقديمي. يمكنك استخدام تكبيرات الأقسام للعودة إلى الأقسام التي تريد التأكيد عليها. أو يمكنك استخدامها لتسليط الضوء على كيفية ارتباط أجزاء معينة من عرضك التقديمي. 

![overview_image](seczoomsel.png)

بالنسبة لكائنات تكبير القسم، توفر Aspose.Slides فئة [SectionZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/sectionzoomframe/) وبعض الأساليب تحت فئة [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/).

### **إنشاء إطارات تكبير القسم**
يمكنك إضافة إطار تكبير القسم إلى شريحة بهذه الطريقة:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. إنشاء شريحة جديدة. 
3. إضافة خلفية تعريفية إلى الشريحة التي تم إنشاؤها.
4. إنشاء قسم جديد ترغب في ربط إطار التكبير به. 
5. إضافة إطار تكبير القسم (الذي يحتوي على مراجع للقسم الذي تم إنشاؤه) إلى الشريحة الأولى.
6. كتابة العرض المعدل كملف PPTX.

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
باستخدام Aspose.Slides ل PHP عبر Java، يمكنك إنشاء إطار تكبير القسم بصورة معاينة شريحة مختلفة بهذه الطريقة:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. إنشاء شريحة جديدة.
3. إضافة خلفية تعريفية إلى الشريحة التي تم إنشاؤها.
4. إنشاء قسم جديد ترغب في ربط إطار التكبير به. 
5. إنشاء كائن [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) عن طريق إضافة صورة إلى مجموعة Images المرتبطة بكائن [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) الذي سيُستخدم لملء الإطار.
5. إضافة إطار تكبير القسم (الذي يحتوي على مرجع للقسم الذي تم إنشاؤه) إلى الشريحة الأولى.
6. كتابة العرض المعدل كملف PPTX.

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
لإنشاء إطارات تكبير قسم أكثر تعقيدًا، عليك تعديل تنسيق إطار بسيط. هناك عدة خيارات تنسيق يمكنك تطبيقها على إطار تكبير القسم. 

يمكنك التحكم في تنسيق إطار تكبير القسم على شريحة بهذه الطريقة:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. إنشاء شريحة جديدة.
3. إضافة خلفية تعريفية إلى الشريحة التي تم إنشاؤها.
4. إنشاء قسم جديد ترغب في ربط إطار التكبير به. 
5. إضافة إطار تكبير القسم (الذي يحتوي على مراجع للقسم الذي تم إنشاؤه) إلى الشريحة الأولى.
6. تغيير الحجم والموقع لكائن تكبير القسم الذي تم إنشاؤه.
7. إنشاء كائن [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) عن طريق إضافة صورة إلى مجموعة Images المرتبطة بكائن [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) الذي سيُستخدم لملء الإطار.
8. تعيين صورة مخصصة لكائن إطار تكبير القسم الذي تم إنشاؤه.
9. تعيين قدرة *العودة إلى الشريحة الأصلية من القسم المرتبط*.
10. إزالة الخلفية من صورة كائن إطار تكبير القسم.
11. تغيير تنسيق الخط لكائن إطار التكبير الثاني.
12. تغيير مدة الانتقال.
13. كتابة العرض المعدل كملف PPTX.

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
تكبير الملخص يشبه صفحة هبوط يتم فيها عرض جميع أجزاء العرض التقديمي دفعة واحدة. عند تقديمك، يمكنك استخدام التكبير للانتقال من مكان إلى آخر في عرضك بأي ترتيب ترغب فيه. يمكنك الإبداع، الانتقال إلى الأمام، أو مراجعة أجزاء من الشرائح دون إيقاف تدفق العرض. 

![overview_image](sumzoomsel.png)

بالنسبة لكائنات تكبير الملخص، توفر Aspose.Slides الفئات [SummaryZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomframe/)، [SummaryZoomSection](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomsection/)، و[SummaryZoomSectionCollection](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomsectioncollection/) وبعض الأساليب تحت فئة [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/).

### **إنشاء تكبير ملخص**
يمكنك إضافة إطار تكبير ملخص إلى شريحة بهذه الطريقة:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. إنشاء شرائح جديدة مع خلفية تعريفية وأقسام جديدة للشرائح التي تم إنشاؤها.
3. إضافة إطار تكبير الملخص إلى الشريحة الأولى.
4. كتابة العرض المعدل كملف PPTX.

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


### **إضافة وإزالة قسم تكبير الملخص**
جميع الأقسام في إطار تكبير الملخص تمثلها كائنات [SummaryZoomSection]، والتي تُخزن في كائن [SummaryZoomSectionCollection]. يمكنك إضافة أو إزالة كائن قسم تكبير ملخص عبر فئة [SummaryZoomSectionCollection] بهذه الطريقة:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. إنشاء شرائح جديدة مع خلفية تعريفية وأقسام جديدة للشرائح التي تم إنشاؤها.
3. إضافة إطار تكبير الملخص إلى الشريحة الأولى.
4. إضافة شريحة جديدة وقسم إلى العرض.
5. إضافة القسم الذي تم إنشاؤه إلى إطار تكبير الملخص.
6. إزالة القسم الأول من إطار تكبير الملخص.
7. كتابة العرض المعدل كملف PPTX.

```php
  $pres = new Presentation();
  try {
    # يضيف شريحة جديدة إلى العرض التقديمي
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # يضيف قسماً جديدًا إلى العرض التقديمي
    $pres->getSections()->addSection("Section 1", $slide);
    # يضيف شريحة جديدة إلى العرض التقديمي
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # يضيف قسماً جديدًا إلى العرض التقديمي
    $pres->getSections()->addSection("Section 2", $slide);
    # يضيف كائن SummaryZoomFrame
    $summaryZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);
    # يضيف شريحة جديدة إلى العرض التقديمي
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->magenta);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # يضيف قسماً جديدًا إلى العرض التقديمي
    $section3 = $pres->getSections()->addSection("Section 3", $slide);
    # يضيف قسماً إلى Summary Zoom
    $summaryZoomFrame->getSummaryZoomCollection()->addSummaryZoomSection($section3);
    # يزيل قسماً من Summary Zoom
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
لإنشاء كائنات أقسام تكبير ملخص أكثر تعقيدًا، عليك تعديل تنسيق إطار بسيط. هناك عدة خيارات تنسيق يمكنك تطبيقها على كائن قسم تكبير الملخص. 

يمكنك التحكم في تنسيق كائن قسم تكبير الملخص داخل إطار تكبير الملخص بهذه الطريقة:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. إنشاء شرائح جديدة مع خلفية تعريفية وأقسام جديدة للشرائح التي تم إنشاؤها.
3. إضافة إطار تكبير الملخص إلى الشريحة الأولى.
4. احصل على كائن قسم تكبير الملخص للعنصر الأول من `SummaryZoomSectionCollection`.
7. إنشاء كائن [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) عن طريق إضافة صورة إلى مجموعة images المرتبطة بكائن [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) الذي سيُستخدم لملء الإطار.
8. تعيين صورة مخصصة لكائن إطار تكبير القسم الذي تم إنشاؤه.
9. تعيين قدرة *العودة إلى الشريحة الأصلية من القسم المرتبط*.
11. تغيير تنسيق الخط لكائن إطار التكبير الثاني.
12. تغيير مدة الانتقال.
13. كتابة العرض المعدل كملف PPTX.

```php
  $pres = new Presentation();
  try {
    # يضيف شريحة جديدة إلى العرض التقديمي
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # يضيف قسماً جديدًا إلى العرض التقديمي
    $pres->getSections()->addSection("Section 1", $slide);
    # يضيف شريحة جديدة إلى العرض التقديمي
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # يضيف قسماً جديدًا إلى العرض التقديمي
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
**هل يمكنني التحكم في العودة إلى الشريحة "الأصل" بعد عرض الهدف؟**  
نعم. يحتوي كل من [Zoom frame](https://reference.aspose.com/slides/php-java/aspose.slides/zoomframe/) أو [section](https://reference.aspose.com/slides/php-java/aspose.slides/sectionzoomframe/) على سلوك `ReturnToParent`، وعند تفعيله يُعيد المشاهدين إلى الشريحة الأصلية بعد زيارة المحتوى المستهدف.

**هل يمكنني ضبط "السرعة" أو مدة انتقال التكبير؟**  
نعم. يدعم Zoom ضبط خاصية `TransitionDuration` لتحديد مدة الحركة الانتقالية.

**هل هناك حدود لعدد كائنات Zoom التي يمكن أن يحتويها عرض تقديمي؟**  
لا يوجد حد ثابت موثّق في الـ API. تعتمد الحدود العملية على تعقّـي العرض وأداء المشاهد. يمكنك إضافة العديد من إطارات Zoom، لكن يجدر الانتباه إلى حجم الملف ووقت التقديم.