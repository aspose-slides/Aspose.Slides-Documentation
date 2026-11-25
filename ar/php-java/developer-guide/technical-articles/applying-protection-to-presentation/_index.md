---
title: تقييد تحرير العروض باستخدام أقفال الأشكال في PHP
linktitle: تقييد تحرير العروض
type: docs
weight: 60
url: /ar/php-java/applying-protection-to-presentation/
keywords:
- منع التعديلات
- الحماية من التحرير
- قفل الشكل
- قفل الموضع
- قفل الاختيار
- قفل إعادة الحجم
- قفل التجميع
- PowerPoint
- PPTX
- العرض
- PHP
- Aspose.Slides
description: "تعلم كيفية قفل وإلغاء قفل الأشكال في عروض PPTX باستخدام Aspose.Slides لـ PHP عبر Java لتقييد الاختيار والحركة وإعادة الحجم والتجميع."
---
## **نظرة عامة**

استخدام شائع لـ Aspose.Slides for PHP عبر Java هو إنشاء وتحديث وحفظ عروض PowerPoint (PPTX) كجزء من سير عمل آلي. عندما يستلم المستخدمون هذه العروض، فإن تقييد التغييرات على الأشكال يمكن أن يساعد في الحفاظ على التخطيط والمحتوى المقصود.

تشرح هذه المقالة كيفية تنظيم الأشكال على الشرائح وكيفية تطبيق وإزالة أقفال الأشكال في عرض PPTX. تتيح لك هذه الأقفال تقييد عمليات تحرير معينة على أشكال فردية.

## **تكوين الشريحة**

تتكون شريحة العرض من مكونات مثل الأشكال التلقائية، الجداول، كائنات OLE، الأشكال المجمعّة، إطارات الصور، إطارات الفيديو، الموصلات، وعناصر أخرى تُستخدم لبناء العرض. في Aspose.Slides for PHP عبر Java، يُمثَّل كل عنصر على الشريحة بكمية ترث من الفئة [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) .

أنواع الأشكال المختلفة تكشف عن خيارات قفل مختلفة. الفئة [BaseShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/baseshapelock/) هي الفئة الأساسية لأقفال الأشكال. توفر Aspose.Slides for PHP عبر Java الفئات القابلة للقفل التالية:

- [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/) يقفل الأشكال التلقائية.  
- [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) يقفل أشكال الموصل.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/) يقفل الكائنات الرسومية.  
- [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/) يقفل الأشكال المجمعّة.  
- [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/) يقفل إطارات الصور.  

لتطبيق الأقفال على مستوى [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)، قم بالتكرار عبر الشرائح وضع الأقفال المناسبة على كل شكل مدعوم.

## **تطبيق وإزالة الحماية**

تستخدم محررات العروض المتوافقة أقفال الأشكال لتقييد عمليات التحرير الفردية. تشفير الملفات وحماية الكتابة على مستوى المستند هي إعدادات [إعدادات حماية العرض](/slides/ar/php-java/password-protected-presentation/) منفصلة.

### **تطبيق الحماية على أشكال PPTX**

توفر Aspose.Slides for PHP عبر Java الفئة [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) للعمل مع الأشكال على الشريحة.

المثال يستدعي [setSelectLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSelectLocked)، [setPositionLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setPositionLocked)، و[setSizeLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSizeLocked) مع `true` للأشكال التلقائية، ومع أقفال مكافئة لأشكال المجموعات والموصلات وإطارات الصور. تستخدم الموصلات [setPositionMove](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/#setPositionMove) للتحرك؛ كما تستخدم المجموعات [setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) لتقييد التجميع.

المثال يحمل عرض PPTX موجود، يتحقق من الأشكال في مجموعة الأشكال لكل شريحة، ويحفظ نسخة مع تطبيق هذه القيود. الأشكال خارج الأنواع الأربعة المعالجة تُترك دون تغيير. الحلقة لا تتجول داخل الأشكال الفرعية داخل مجموعة.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    foreach ($presentation->getSlides()->toArray() as $slide) {
        foreach ($slide->getShapes()->toArray() as $shape) {
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionLocked(true);
                $shapeLock->setSelectLocked(true);
                $shapeLock->setSizeLocked(true);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setGroupingLocked(true);
                $shapeLock->setPositionLocked(true);
                $shapeLock->setSelectLocked(true);
                $shapeLock->setSizeLocked(true);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.Connector"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionMove(true);
                $shapeLock->setSelectLocked(true);
                $shapeLock->setSizeLocked(true);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionLocked(true);
                $shapeLock->setSelectLocked(true);
                $shapeLock->setSizeLocked(true);
            }
        }
    }

    $presentation->save("ProtectedSample.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **إزالة الحماية**

لإزالة قفل الشكل، ضع قيمته `false`. المثال التالي يحمل عرضًا يحتوي على أقفال أشكال ويزيل قيود الاختيار، التحرك، وتغيير الحجم عبر [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/)، [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/)، [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/)، و[PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/). كما يزيل قيد التجميع بتمرير `false` إلى [GroupShapeLock::setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) ويحفظ نسخة من العرض. تبقى إعدادات الأقفال الأخرى دون تغيير.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("ProtectedSample.pptx");
try {
    foreach ($presentation->getSlides()->toArray() as $slide) {
        foreach ($slide->getShapes()->toArray() as $shape) {
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionLocked(false);
                $shapeLock->setSelectLocked(false);
                $shapeLock->setSizeLocked(false);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setGroupingLocked(false);
                $shapeLock->setPositionLocked(false);
                $shapeLock->setSelectLocked(false);
                $shapeLock->setSizeLocked(false);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.Connector"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionMove(false);
                $shapeLock->setSelectLocked(false);
                $shapeLock->setSizeLocked(false);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionLocked(false);
                $shapeLock->setSelectLocked(false);
                $shapeLock->setSizeLocked(false);
            }
        }
    }

    $presentation->save("RemovedProtectionSample.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **الحفاظ على قص الصورة**

ضع صورة باسم `photo.jpg` في دليل العمل. المثال يقتطع 12% من اليسار و8% من اليمين، ثم يستدعي [setCropLocked](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/#setCropLocked) على قفل إطار الصورة. تمرير `true` يقيّد أي قص إضافي ويحافظ على القص الحالي.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();

    $image = Images::fromFile("photo.jpg");
    try {
        $photo = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $pictureFrame = $shapes->addPictureFrame(ShapeType::Rectangle, 20, 30, 270, 160, $photo);
    $pictureFrame->getPictureFormat()->setCropLeft(12);
    $pictureFrame->getPictureFormat()->setCropRight(8);

    $pictureFrameLock = $pictureFrame->getPictureFrameLock();
    $pictureFrameLock->setAspectRatioLocked(false);
    $pictureFrameLock->setCropLocked(true);

    $presentation->save("PictureLocked.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`PictureLocked.pptx` يخزن قفل القص كـ `true`. في PowerPoint، يصبح أمر **Crop** معطلاً عندما يتم اختيار الصورة.

### **الحفاظ على تجميع المخطط**

المثال يجمع مستطيل وسهم، ثم يستدعي [setUngroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setUngroupingLocked) على قفل المجموعة للحفاظ على مكوّنات المخطط معًا. تبقى التعديلات الأخرى، مثل تحريك المجموعة أو تغيير تعبئة مكوّن، متاحة.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();
    
    $groupShape = $shapes->addGroupShape();
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 70, 90, 50);
    $groupShape->getShapes()->addAutoShape(ShapeType::RightArrow, 190, 80, 60, 30);
    $groupShape->getGroupShapeLock()->setUngroupingLocked(true);

    $presentation->save("DiagramLocked.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`DiagramLocked.pptx` يخزن قفل فك التجميع كـ `true`. في PowerPoint، يصبح أمر **Ungroup** معطلاً عندما يتم اختيار المخطط بالكامل.

### **الإبلاغ عن أقفال الأشكال الحالية**

لمراجعة قالب، افتحه واقرأ كائن القفل لكل شكل. طريقة [getNoLocks](https://reference.aspose.com/slides/php-java/aspose.slides/baseshapelock/#getNoLocks) تُعيد `true` عندما تكون جميع العلامات على ذلك الكائن معطَّلة و`false` عندما يكون على الأقل واحدة مفعلة. للمجموعة وأبنائها كائنات قفل منفصلة، لذا فحص الأطفال حتى عندما لا تكون للمجموعة أقفال.

هذا المثال يتحقق من حركة الأشكال التلقائية، إطارات الصور، والمجموعات. كما يتحقق من قص الصور وفك تجميع المجموعات. التقرير يُدرج العلامات المفعلة التي يتعرف عليها ويُميز أنواع الأشكال التي لا يفحصها.

```php
use aspose\slides\Presentation;

function reportShapeLocks($shapes, $slideNumber, $prefix = "") {
    foreach ($shapes->toArray() as $shape) {
        $path = $prefix . java_values($shape->getName());
        $type = java_values($shape->getClass()->getSimpleName());
        $label = "Slide $slideNumber | $path | $type";
        $flags = [];
        $isGroup = java_instanceof($shape, java("com.aspose.slides.IGroupShape"));

        if ($isGroup) {
            $lock = $shape->getGroupShapeLock();
            if (java_values($lock->getUngroupingLocked())) {
                $flags[] = "UngroupingLocked";
            }
        } elseif (java_instanceof($shape, java("com.aspose.slides.IPictureFrame"))) {
            $lock = $shape->getPictureFrameLock();
            if (java_values($lock->getCropLocked())) {
                $flags[] = "CropLocked";
            }
        } elseif (java_instanceof($shape, java("com.aspose.slides.IAutoShape"))) {
            $lock = $shape->getAutoShapeLock();
        } else {
            echo "$label | Uninspected", PHP_EOL;
            continue;
        }

        if (java_values($lock->getPositionLocked())) {
            $flags[] = "PositionLocked";
        }
        if (!java_values($lock->getNoLocks())) {
            $restrictions = $flags ? implode(", ", $flags) : "Active flag not identified";
            echo "$label | $restrictions", PHP_EOL;
        }

        if ($isGroup) {
            reportShapeLocks($shape->getShapes(), $slideNumber, $path . "/");
        }
    }
}

$presentation = new Presentation("Sample.pptx");
try {
    foreach ($presentation->getSlides()->toArray() as $slide) {
        reportShapeLocks($slide->getShapes(), java_values($slide->getSlideNumber()));
    }
} finally {
    $presentation->dispose();
}
```

افترض أن الشريحة 1 من `Sample.pptx` تحتوي على مجموعة باسم `Layout` قُفل فك تجميعها، وصورة باسم `Photo` داخلها قُفل قصها، ومستطيل غير مقفل باسم `Free`. يتخطى التقرير `Free` ويطبع السطرين التاليين:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

يقرأ التقرير علامات تحرير المستوى الشكلية المخزنة دون تغييرها أو حفظ العرض. حماية الكتابة على مستوى المستند هي إعداد منفصل، وتطبيق كل علامة يعتمد على المحرر.

## **الخلاصة**

تتيح لك Aspose.Slides for PHP عبر Java تقييد عمليات تحرير محددة على أشكال فردية أو تطبيق نفس القيود عبر الشرائح. اختر الأقفال المدعومة من كل نوع شكل، واضبط قيمها إلى `false` عندما تحتاج إلى إزالة هذه القيود.

## **الأسئلة الشائعة**

**هل يمكنني دمج أقفال الأشكال وحماية كلمة المرور في نفس العرض؟**

نعم. أقفال الأشكال تقيد عمليات تحرير معينة، بينما [حماية كلمة المرور](/slides/ar/php-java/password-protected-presentation/) يمكنها تقييد فتح أو تعديل العرض. يمكنك استخدام كلاهما في نفس الملف.

**هل يمكنني تقييد التحرير على شرائح معينة دون التأثير على الأخرى؟**

نعم. قم بتطبيق الأقفال فقط على الأشكال الموجودة في الشرائح المحددة. هذا لا يغيّر إعدادات الأقفال في الشرائح الأخرى.

**كيف يمكنني تطبيق أقفال على أشكال فردية داخل مجموعة؟**

قم بالتكرار عبر المجموعة باستخدام الطريقة [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/#getShapes) وتطبيق الأقفال المناسبة على كل شكل فرعي. كرر ذلك لأي مجموعات متداخلة، متبعًا طريقة التجوال في مثال التقرير.