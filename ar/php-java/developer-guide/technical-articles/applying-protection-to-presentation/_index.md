---
title: "تقييد تحرير العروض باستخدام أقفال الأشكال في PHP"
linktitle: "تقييد تحرير العروض"
type: docs
weight: 60
url: /ar/php-java/applying-protection-to-presentation/
keywords:
- "منع التعديلات"
- "حماية من التحرير"
- "قفل الشكل"
- "قفل الموضع"
- "قفل الاختيار"
- "قفل تغيير الحجم"
- "قفل التجميع"
- "PowerPoint"
- "PPTX"
- "العرض"
- "PHP"
- "Aspose.Slides"
description: "تعلم كيفية قفل وفتح قفل الأشكال في عروض PPTX باستخدام Aspose.Slides for PHP عبر Java لتقييد الاختيار، والتحريك، وتغيير الحجم، والتجميع."
---
## **نظرة عامة**

استخدام شائع لـ Aspose.Slides for PHP عبر Java هو إنشاء وتحديث وحفظ عروض PowerPoint (PPTX) كجزء من سير عمل آلي. عندما يتلقى المستخدمون هذه العروض، يمكن أن يساعد تقييد التغييرات على الأشكال في الحفاظ على التخطيط والمحتوى المقصود.

توضح هذه المقالة كيفية تنظيم الأشكال على الشرائح وكيفية تطبيق وإزالة قفل الأشكال في عرض PPTX. تسمح لك هذه الأقفال بتقييد عمليات تحرير محددة على الأشكال الفردية.

## **مكونات الشريحة**

تتكون شريحة العرض من مكونات مثل الأشكال التلقائية، الجداول، كائنات OLE، الأشكال المجمعة، إطارات الصور، إطارات الفيديو، الموصلات، وعناصر أخرى تُستخدم لبناء العرض. في Aspose.Slides for PHP عبر Java، يُمثَّل كل عنصر على الشريحة ككائن يرث من الفئة [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) .

تُظهر أنواع الأشكال المختلفة خيارات قفل مختلفة. الفئة [BaseShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/baseshapelock/) هي الفئة الأساسية لأقفال الأشكال. يوفر Aspose.Slides for PHP عبر Java الفئات القفلية التالية:

- [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/) يقفل الأشكال التلقائية.  
- [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) يقفل أشكال الموصل.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/) يقفل الكائنات الرسومية.  
- [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/) يقفل الأشكال المجمعة.  
- [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/) يقفل إطارات الصور.  

لتطبيق الأقفال عبر [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)، قم بالتكرار عبر شرائحه واضبط الأقفال المناسبة على كل شكل مدعوم.

## **تطبيق وإزالة الحماية**

تستخدم محررات العروض المتوافقة أقفال الأشكال لتقييد عمليات التحرير الفردية. تشفير الملفات وحماية الكتابة على مستوى المستند هي إعدادات [إعدادات حماية العرض](/slides/ar/php-java/password-protected-presentation/) منفصلة.

### **تطبيق الحماية على أشكال PPTX**

يوفر Aspose.Slides for PHP عبر Java الفئة [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) للعمل مع الأشكال على الشريحة.

تستدعي العينة الدوال [setSelectLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSelectLocked)، [setPositionLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setPositionLocked)، و [setSizeLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSizeLocked) بالقيمة `true` للأشكال التلقائية، مع أقفال مماثلة للأشكال المجمعة، الموصلات، وإطارات الصور. تستخدم الموصلات الدالة [setPositionMove](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/#setPositionMove) للتحريك؛ كما تستخدم المجموعات الدالة [setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) لتقييد التجميع.

تحمّل العينة عرض PPTX موجود، تتحقق من الأشكال في مجموعة أشكال كل شريحة، وتحفظ نسخة مع تطبيق هذه القيود. تُترك الأشكال خارج الأنواع الأربعة التي تمت معالجتها دون تغيير. لا يتجول الحلقة عبر الأشكال الفرعية داخل مجموعة.

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

لإزالة قفل الشكل، اضبط قيمته إلى `false`. تقوم العينة التالية بتحميل عرض يحتوي على أقفال الأشكال وتزيل قيود الاختيار، التحريك، وتغيير الحجم عبر [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/)، [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/)، [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/)، و [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/). كما تُزيل قيود التجميع بتمرير `false` إلى [GroupShapeLock::setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked)، وتحفظ نسخة من العرض. تُترك إعدادات الأقفال الأخرى دون تغيير.

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

ضع صورة باسم `photo.jpg` في دليل العمل. تقوم العينة بقص 12% من اليسار و8% من اليمين، ثم تستدعي الدالة [setCropLocked](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/#setCropLocked) على قفل إطار الصورة. تمرير `true` يقيد المزيد من القص ويحافظ على القص الحالي.

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

`PictureLocked.pptx` يخزن قفل القص كـ `true`. في PowerPoint، يتم تعطيل أمر **Crop** عندما يتم اختيار الصورة.

### **الحفاظ على تجميع المخطط**

تقوم العينة بتجميع مستطيل وسهم، ثم تستدعي الدالة [setUngroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setUngroupingLocked) على قفل المجموعة للحفاظ على مكونات المخطط معًا. تظل التعديلات الأخرى، مثل تحريك المجموعة أو تغيير تعبئة أحد المكونات، متاحة.

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

`DiagramLocked.pptx` يخزن قفل فك التجميع كـ `true`. في PowerPoint، يتم تعطيل أمر **Ungroup** عندما يتم اختيار المخطط بالكامل.

### **الخلاصة**

يوفر Aspose.Slides for PHP عبر Java إمكانية تقييد عمليات تحرير محددة على الأشكال الفردية أو تطبيق نفس القيود عبر الشرائح. اختر الأقفال المدعومة لكل نوع من الأشكال، واضبط قيمها إلى `false` عندما تحتاج إلى إزالة تلك القيود.

## **الأسئلة الشائعة**

**هل يمكنني دمج أقفال الأشكال وحماية كلمة المرور في نفس العرض؟**

نعم. أقفال الأشكال تقيد عمليات تحرير محددة، بينما [حماية كلمة المرور](/slides/ar/php-java/password-protected-presentation/) يمكن أن تقيد فتح أو تعديل العرض. يمكنك استخدام كلاهما في نفس الملف.

**هل يمكنني تقييد التحرير على شرائح محددة دون التأثير على غيرها؟**

نعم. قم بتطبيق الأقفال فقط على الأشكال في الشرائح المحددة. هذا لا يغيّر إعدادات الأقفال في الشرائح الأخرى.

**كيف يمكنني تطبيق أقفال على الأشكال الفردية داخل مجموعة؟**

قم بالتكرار عبر المجموعة التي تُرجعها طريقة [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/#getShapes) الخاصة بالمجموعة وطبق الأقفال المناسبة على كل شكل فرعي. كرّر ذلك لأي مجموعات متداخلة. الأمثلة أعلاه تعالج فقط مجموعة أشكال الشريحة، لذا لا تقوم بتعيين أقفال على أعضاء المجموعة الفرديين.