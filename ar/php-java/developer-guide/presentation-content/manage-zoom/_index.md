---
title: إدارة التكبير
type: docs
weight: 60
url: /php-java/manage-zoom/
keywords: "Zoom, إطار التكبير, إضافة تكبير, تنسيق إطار التكبير, ملخص التكبير, عرض PowerPoint, Java, Aspose.Slides لـ PHP عبر Java"
description: "إضافة تكبير أو إطارات تكبير إلى عروض PowerPoint"
---

## **نظرة عامة**
تسمح لك التكبيرات في PowerPoint بالانتقال إلى ومن شريحة محددة، أو قسم، أو جزء من العرض التقديمي. قد تكون هذه القدرة على التنقل بسرعة عبر المحتوى مفيدة جدًا عند تقديم العرض.

![overview_image](overview.png)

* لتلخيص عرض تقديمي كامل في شريحة واحدة، استخدم [ملخص التكبير](#Summary-Zoom).
* لإظهار الشرائح المحددة فقط، استخدم [تكبير الشريحة](#Slide-Zoom).
* لإظهار قسم واحد فقط، استخدم [تكبير القسم](#Section-Zoom).

## **تكبير الشريحة**
يمكن أن يجعل تكبير الشريحة العرض التقديمي أكثر ديناميكية، مما يسمح لك بالتنقل بحرية بين الشرائح بأي ترتيب تختاره دون انقطاع تدفق العرض التقديمي. تعتبر تكبيرات الشرائح رائعة للعروض القصيرة التي لا تحتوي على العديد من الأقسام، لكن يمكنك استخدامها أيضًا في سيناريوهات تقديم مختلفة.

تساعد تكبيرات الشرائح على الدخول في معلومات متعددة بينما تشعر وكأنك على قماش واحد.

![overview_image](slidezoomsel.png)

بالنسبة لكائنات تكبير الشريحة، توفر Aspose.Slides [ZoomImageType](https://reference.aspose.com/slides/php-java/aspose.slides/ZoomImageType) والإعداد [IZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IZoomFrame) وبعض الأساليب تحت واجهة [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection).

### **إنشاء إطارات تكبير**

يمكنك إضافة إطار تكبير على شريحة بهذه الطريقة:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. أنشئ شرائح جديدة تريد الربط بينها وبين إطارات التكبير.
3. أضف نص تعريف وخلفية للشرائح التي تم إنشاؤها.
4. أضف إطارات تكبير (تحتوي على المراجع إلى الشرائح التي تم إنشاؤها) إلى الشريحة الأولى.
5. اكتب العرض التقديمي المعدل كملف PPTX.

يوضح هذا كود PHP كيفية إنشاء إطار تكبير على شريحة:

```php
  $pres = new Presentation();
  try {
    # يضيف شرائح جديدة إلى العرض التقديمي
    $slide2 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide3 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    # ينشئ خلفية للشرائح الثانية
    $slide2->getBackground()->setType(BackgroundType::OwnBackground);
    $slide2->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide2->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    # ينشئ صندوق نص للشرائح الثانية
    $autoshape = $slide2->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("الشريحة الثانية");
    # ينشئ خلفية للشرائح الثالثة
    $slide3->getBackground()->setType(BackgroundType::OwnBackground);
    $slide3->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide3->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->darkGray);
    # ينشئ صندوق نص للشرائح الثالثة
    $autoshape = $slide3->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("الشريحة الثالثة");
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
### **إنشاء إطارات تكبير بأسطح صورية مخصصة**
باستخدام Aspose.Slides لـ PHP عبر Java، يمكنك إنشاء إطار تكبير بصورة المعاينة للشريحة المختلفة بهذه الطريقة:
1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. أنشئ شريحة جديدة تريد الربط بينها وبين إطار التكبير.
3. أضف نص تعريف وخلفية للشريحة.
4. أنشئ كائن [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage) عن طريق إضافة صورة إلى مجموعة الصور المرتبطة بكائن [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) الذي سيتم استخدامه لتعبئة الإطار.
5. أضف إطارات تكبير (تحتوي على مرجع إلى الشريحة التي تم إنشاؤها) إلى الشريحة الأولى.
6. اكتب العرض التقديمي المعدل كملف PPTX.

يوضح هذا كود PHP كيفية إنشاء إطار تكبير بصورة مختلفة:

```php
  $pres = new Presentation();
  try {
    # يضيف شريحة جديدة إلى العرض التقديمي
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    # ينشئ خلفية للشرائح الثانية
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    # ينشئ صندوق نص للشرائح الثالثة
    $autoshape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("الشريحة الثانية");
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
في الأقسام السابقة، أظهرنا لك كيفية إنشاء إطارات تكبير بسيطة. لإنشاء إطارات تكبير أكثر تعقيدًا، يجب عليك تعديل تنسيق إطار بسيط. هناك العديد من خيارات التنسيق التي يمكنك تطبيقها على إطار التكبير.

يمكنك التحكم في تنسيق إطار التكبير على شريحة بهذه الطريقة:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. أنشئ شرائح جديدة تريد الربط بينها وبين إطار التكبير.
3. أضف بعض النصوص التعريفية والخلفية إلى الشرائح التي تم إنشاؤها.
4. أضف إطارات تكبير (تحتوي على المراجع إلى الشرائح التي تم إنشاؤها) إلى الشريحة الأولى.
5. أنشئ كائن [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage) عن طريق إضافة صورة إلى مجموعة الصور المرتبطة بكائن [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) الذي سيتم استخدامه لتعبئة الإطار.
6. قم بتعيين صورة مخصصة لكائن إطار التكبير الأول.
7. قم بتغيير تنسيق الخط لكائن إطار التكبير الثاني.
8. قم بإزالة الخلفية من صورة لكائن إطار التكبير الثاني.
5. اكتب العرض التقديمي المعدل كملف PPTX.

يوضح هذا كود PHP كيفية تغيير تنسيق إطار التكبير على شريحة:

```php
  $pres = new Presentation();
  try {
    # يضيف شرائح جديدة إلى العرض التقديمي
    $slide2 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide3 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    # ينشئ خلفية للشرائح الثانية
    $slide2->getBackground()->setType(BackgroundType::OwnBackground);
    $slide2->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide2->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    # ينشئ صندوق نص للشرائح الثانية
    $autoshape = $slide2->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("الشريحة الثانية");
    # ينشئ خلفية للشرائح الثالثة
    $slide3->getBackground()->setType(BackgroundType::OwnBackground);
    $slide3->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide3->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->darkGray);
    # ينشئ صندوق نص للشرائح الثالثة
    $autoshape = $slide3->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("الشريحة الثالثة");
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
    # يعيّن صورة مخصصة لكائن zoomFrame1
    $zoomFrame1->setImage($picture);
    # يعيّن تنسيق إطار تكبير لكائن zoomFrame2
    $zoomFrame2->getLineFormat()->setWidth(5);
    $zoomFrame2->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $zoomFrame2->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->pink);
    $zoomFrame2->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    # إعداد عدم عرض الخلفية لكائن zoomFrame2
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

تكبير القسم هو رابط إلى قسم في العرض التقديمي الخاص بك. يمكنك استخدام تكبير الأقسام للعودة إلى الأقسام التي تريد التأكيد عليها حقًا. أو يمكنك استخدامها لتسليط الضوء على كيفية ارتباط بعض أجزاء العرض التقديمي الخاص بك.

![overview_image](seczoomsel.png)

بالنسبة لكائنات تكبير القسم، توفر Aspose.Slides واجهة [ISectionZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ISectionZoomFrame) وبعض الأساليب تحت واجهة [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection).

### **إنشاء إطارات تكبير أقسام**

يمكنك إضافة إطار تكبير قسم إلى شريحة بهذه الطريقة:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. أنشئ شريحة جديدة.
3. أضف خلفية تعريف للشريحة التي تم إنشاؤها.
4. أنشئ قسمًا جديدًا تريد الربط به مع إطار التكبير.
5. أضف إطار تكبير قسم (تحتوي على المراجع إلى القسم الذي تم إنشاؤه) إلى الشريحة الأولى.
6. اكتب العرض التقديمي المعدل كملف PPTX.

يوضح هذا كود PHP كيفية إنشاء إطار تكبير على شريحة:

```php
  $pres = new Presentation();
  try {
    # يضيف شريحة جديدة إلى العرض التقديمي
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # يضيف قسمًا جديدًا إلى العرض التقديمي
    $pres->getSections()->addSection("القسم 1", $slide);
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
### **إنشاء إطارات تكبير أقسام بأسطح صورية مخصصة**

باستخدام Aspose.Slides لـ PHP عبر Java، يمكنك إنشاء إطار تكبير قسم بصورة المعاينة للشريحة المختلفة بهذه الطريقة:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. أنشئ شريحة جديدة.
3. أضف خلفية تعريف للشريحة التي تم إنشاؤها.
4. أنشئ قسمًا جديدًا تريد الربط به مع إطار التكبير.
5. أنشئ كائن [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage) عن طريق إضافة صورة إلى مجموعة الصور المرتبطة بكائن [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) الذي سيتم استخدامه لتعبئة الإطار.
5. أضف إطار تكبير قسم (تحتوي على مرجع إلى القسم الذي تم إنشاؤه) إلى الشريحة الأولى.
6. اكتب العرض التقديمي المعدل كملف PPTX.

يوضح هذا كود PHP كيفية إنشاء إطار تكبير بصورة مختلفة:

```php
  $pres = new Presentation();
  try {
    # يضيف شريحة جديدة إلى العرض التقديمي
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # يضيف قسمًا جديدًا إلى العرض التقديمي
    $pres->getSections()->addSection("القسم 1", $slide);
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
### **تنسيق إطارات تكبير الأقسام**

لإنشاء إطارات تكبير أقسام أكثر تعقيدًا، يجب عليك تعديل تنسيق إطار بسيط. هناك عدة خيارات تنسيق يمكنك تطبيقها على إطار تكبير القسم.

يمكنك التحكم في تنسيق إطار تكبير القسم على شريحة بهذه الطريقة:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. أنشئ شريحة جديدة.
3. أضف خلفية تعريف للشريحة التي تم إنشاؤها.
4. أنشئ قسمًا جديدًا تريد الربط به مع إطار التكبير.
5. أضف إطار تكبير قسم (تحتوي على المراجع إلى القسم الذي تم إنشاؤه) إلى الشريحة الأولى.
6. غيّر الحجم والموقع لكائن تكبير القسم الذي تم إنشاؤه.
7. أنشئ كائن [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage) عن طريق إضافة صورة إلى مجموعة الصور المرتبطة بكائن [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) الذي سيتم استخدامه لتعبئة الإطار.
8. قم بتعيين صورة مخصصة لكائن إطار تكبير القسم الذي تم إنشاؤه.
9. قم بتعيين القدرة على *العودة إلى الشريحة الأصلية من القسم المرتبط*.
10. قم بإزالة الخلفية من صورة إطار تكبير القسم.
11. قم بتغيير تنسيق الخط لكائن إطار التكبير الثاني.
12. قم بتغيير مدة الانتقال.
13. اكتب العرض التقديمي المعدل كملف PPTX.

يوضح هذا كود PHP كيفية تغيير تنسيق إطار تكبير القسم:

```php
  $pres = new Presentation();
  try {
    # يضيف شريحة جديدة إلى العرض التقديمي
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # يضيف قسمًا جديدًا إلى العرض التقديمي
    $pres->getSections()->addSection("القسم 1", $slide);
    # يضيف كائن SectionZoomFrame
    $sectionZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $pres->getSections()->get_Item(1));
    # تنسيق لإطار تكبير القسم
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

## **ملخص التكبير**

ملخص التكبير يشبه صفحة الهبوط حيث يتم عرض جميع أجزاء العرض التقديمي الخاص بك في وقت واحد. عندما تقدم، يمكنك استخدام التكبير للانتقال من مكان في العرض التقديمي إلى آخر بأي ترتيب تفضله. يمكنك أن تكون خلاقًا، وتتخطى، أو تعيد زيارة أجزاء من عرض الشرائح الخاص بك دون انقطاع تدفق العرض التقديمي.

![overview_image](sumzoomsel.png)

بالنسبة لكائنات ملخص التكبير، توفر Aspose.Slides واجهتين [ISummaryZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ISummaryZoomFrame)، [ISummaryZoomSection](https://reference.aspose.com/slides/php-java/aspose.slides/ISummaryZoomSection)، و [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISummaryZoomSectionCollection) وبعض الأساليب تحت واجهة [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection).

### **إنشاء ملخص التكبير**

يمكنك إضافة إطار ملخص التكبير إلى شريحة بهذه الطريقة:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. أنشئ شرائح جديدة مع خلفية تعريف جديدة وأقسام جديدة للشرائح التي تم إنشاؤها.
3. أضف إطار ملخص التكبير إلى الشريحة الأولى.
4. اكتب العرض التقديمي المعدل كملف PPTX.

يوضح هذا كود PHP كيفية إنشاء إطار ملخص التكبير على شريحة:

```php
  $pres = new Presentation();
  try {
    # يضيف شريحة جديدة إلى العرض التقديمي
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # يضيف قسمًا جديدًا إلى العرض التقديمي
    $pres->getSections()->addSection("القسم 1", $slide);
    # يضيف شريحة جديدة إلى العرض التقديمي
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # يضيف قسمًا جديدًا إلى العرض التقديمي
    $pres->getSections()->addSection("القسم 2", $slide);
    # يضيف شريحة جديدة إلى العرض التقديمي
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->magenta);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # يضيف قسمًا جديدًا إلى العرض التقديمي
    $pres->getSections()->addSection("القسم 3", $slide);
    # يضيف شريحة جديدة إلى العرض التقديمي
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->green);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # يضيف قسمًا جديدًا إلى العرض التقديمي
    $pres->getSections()->addSection("القسم 4", $slide);
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

### **إضافة وإزالة قسم ملخص التكبير**

تمثل جميع الأقسام في إطار ملخص التكبير بواسطة كائنات [ISummaryZoomSection](https://reference.aspose.com/slides/php-java/aspose.slides/ISummaryZoomSection)، والتي يتم تخزينها في كائن [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISummaryZoomSectionCollection). يمكنك إضافة أو إزالة كائن قسم ملخص التكبير من خلال واجهة [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISummaryZoomSectionCollection) بهذه الطريقة:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. أنشئ شرائح جديدة مع خلفية تعريف جديدة وأقسام جديدة للشرائح التي تم إنشاؤها.
3. أضف إطار ملخص التكبير إلى الشريحة الأولى.
4. أضف شريحة وقسمًا جديدًا إلى العرض التقديمي.
5. أضف القسم الذي تم إنشاؤه إلى إطار ملخص التكبير.
6. أزل القسم الأول من إطار ملخص التكبير.
7. اكتب العرض التقديمي المعدل كملف PPTX.

يوضح هذا كود PHP كيفية إضافة وإزالة أقسام في إطار ملخص التكبير:

```php
  $pres = new Presentation();
  try {
    # يضيف شريحة جديدة إلى العرض التقديمي
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # يضيف قسمًا جديدًا إلى العرض التقديمي
    $pres->getSections()->addSection("القسم 1", $slide);
    # يضيف شريحة جديدة إلى العرض التقديمي
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # يضيف قسمًا جديدًا إلى العرض التقديمي
    $pres->getSections()->addSection("القسم 2", $slide);
    # يضيف كائن SummaryZoomFrame
    $summaryZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);
    # يضيف شريحة جديدة إلى العرض التقديمي
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->magenta);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # يضيف قسمًا جديدًا إلى العرض التقديمي
    $section3 = $pres->getSections()->addSection("القسم 3", $slide);
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

### **تنسيق أقسام ملخص التكبير**

لإنشاء كائنات قسم ملخص التكبير أكثر تعقيدًا، يجب عليك تعديل تنسيق إطار بسيط. هناك العديد من خيارات التنسيق التي يمكنك تطبيقها على كائن قسم ملخص التكبير.

يمكنك التحكم في تنسيق قسم ملخص التكبير في إطار ملخص التكبير بهذه الطريقة:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. أنشئ شرائح جديدة مع خلفية تعريف جديدة وأقسام جديدة للشرائح التي تم إنشاؤها.
3. أضف إطار ملخص التكبير إلى الشريحة الأولى.
4. احصل على كائن قسم ملخص التكبير الأول من `ISummaryZoomSectionCollection`.
7. أنشئ كائن [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage) عن طريق إضافة صورة إلى مجموعة الصور المرتبطة بكائن [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) الذي سيتم استخدامه لتعبئة الإطار.
8. قم بتعيين صورة مخصصة لكائن قسم ملخص التكبير الذي تم إنشاؤه.
9. قم بتعيين القدرة على *العودة إلى الشريحة الأصلية من القسم المرتبط*.
11. غيّر تنسيق الخط لكائن إطار التكبير الثاني.
12. غيّر مدة الانتقال.
13. اكتب العرض التقديمي المعدل كملف PPTX.

يوضح هذا كود PHP كيفية تغيير تنسيق كائن قسم ملخص التكبير:

```php
  $pres = new Presentation();
  try {
    # يضيف شريحة جديدة إلى العرض التقديمي
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # يضيف قسمًا جديدًا إلى العرض التقديمي
    $pres->getSections()->addSection("القسم 1", $slide);
    # يضيف شريحة جديدة إلى العرض التقديمي
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # يضيف قسمًا جديدًا إلى العرض التقديمي
    $pres->getSections()->addSection("القسم 2", $slide);
    # يضيف كائن SummaryZoomFrame
    $summaryZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);
    # يحصل على كائن قسم ملخص التكبير الأول
    $summarySection = $summaryZoomFrame->getSummaryZoomCollection()->get_Item(0);
    # تنسيق لكائن قسم ملخص التكبير
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
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