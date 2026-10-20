---
title: "تقييد تعديلات العرض باستخدام أقفال الأشكال في PHP"
linktitle: "تقييد تعديلات العرض"
type: docs
weight: 60
url: /ar/php-java/applying-protection-to-presentation/
keywords:
- "منع التعديلات"
- "حماية من التحرير"
- "قفل الشكل"
- "قفل الموقع"
- "قفل الاختيار"
- "قفل تغيير الحجم"
- "قفل التجميع"
- "PowerPoint"
- "PPTX"
- "العرض"
- "PHP"
- "Aspose.Slides"
description: "تعلم كيفية قفل وإلغاء قفل الأشكال في عروض PPTX باستخدام Aspose.Slides for PHP عبر Java لتقييد الاختيار، الحركة، تغيير الحجم، والتجميع."
---
## **نظرة عامة**

الاستخدام الشائع لـ Aspose.Slides for PHP via Java هو إنشاء وتحديث وحفظ عروض PowerPoint (PPTX) كجزء من سير عمل آلي. عندما يتلقى المستخدمون هذه العروض، يمكن أن يساعد تقييد التغييرات على الأشكال في الحفاظ على التخطيط والمحتوى المقصود.

تشرح هذه المقالة كيفية تنظيم الأشكال على الشرائح وكيفية تطبيق وإزالة أقفال الأشكال في عرض PPTX. تتيح لك هذه الأقفال تقييد عمليات التحرير المحددة على الأشكال الفردية.

## **تكوين الشريحة**

تتكون شريحة العرض من مكونات مثل الأشكال التلقائية، الجداول، كائنات OLE، الأشكال المجمعة، إطارات الصور، إطارات الفيديو، الموصلات، وعناصر أخرى تُستخدم لبناء العرض. في Aspose.Slides for PHP via Java، يُمثَّل كل عنصر على الشريحة بكائن يرث من الفئة [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) .

تُظهر أنواع الأشكال المختلفة خيارات قفل مختلفة. الفئة [BaseShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/baseshapelock/) هي الفئة الأساسية لأقفال الأشكال. توفر Aspose.Slides for PHP via Java الفئات القفلية التالية:
- [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/) يقفل الأشكال التلقائية.  
- [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) يقفل أشكال الموصل.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/) يقفل الكائنات الرسومية.  
- [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/) يقفل الأشكال المجمعة.  
- [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/) يقفل إطارات الصور.  

لتطبيق الأقفال عبر [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)، قم بالتكرار عبر شرائحه واضبط الأقفال المناسبة على كل شكل مدعوم.

## **تطبيق وإزالة الحماية**

أقفال الأشكال تقيّد عمليات مثل اختيار الأشكال، نقلها، وتغيير حجمها. ولا تجعل العرض بالكامل غير قابل للتحرير.

### **تطبيق الحماية على أشكال PPTX**

توفر Aspose.Slides for PHP via Java الفئة [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) للعمل مع الأشكال على الشريحة.

تستدعي العينة الدوال [setSelectLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSelectLocked)، [setPositionLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setPositionLocked)، و[setSizeLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSizeLocked) بالقيمة `true` للأشكال التلقائية، مع أقفال مماثلة لأشكال المجموعات، الموصلات، وإطارات الصور. تستخدم الموصلات الدالة [setPositionMove](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/#setPositionMove) للحركة؛ وتستخدم المجموعات أيضًا الدالة [setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) لتقييد التجميع.

تحمّل العينة عرض PPTX موجود، وتفحص الأشكال في مجموعة الأشكال لكل شريحة، وتُحفظ نسخة مع تطبيق هذه القيود. تُترك الأشكال خارج الأنواع الأربعة المعالجة دون تعديل. لا يتجول الحلقة عبر الأشكال الفرعية داخل مجموعة.

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

لإزالة قفل الشكل، اضبط قيمته على `false`. تقوم العينة التالية بتحميل عرض يحتوي على أقفال الأشكال وتزيل قيود الاختيار، النقل، وتغيير الحجم عبر [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/)، [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/)، [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/)، و[PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/). كما أنها تزيل قيد التجميع بتمرير `false` إلى [GroupShapeLock::setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked)، وتحفظ نسخة من العرض. تُترك إعدادات الأقفال الأخرى دون تغيير.

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

### **الخلاصة**

تتيح لك Aspose.Slides for PHP via Java تقييد عمليات التحرير المحددة على الأشكال الفردية أو تطبيق نفس القيود عبر الشرائح. اختر الأقفال المدعومة من كل نوع شكل، واضبط قيمها على `false` عندما تحتاج إلى إزالة تلك القيود.

## **الأسئلة الشائعة**

**هل يمكنني الجمع بين أقفال الأشكال وحماية كلمة المرور في نفس العرض؟**

نعم. تقيد أقفال الأشكال عمليات التحرير المحددة، بينما [حماية كلمة المرور](/slides/ar/php-java/password-protected-presentation/) يمكنها تقييد فتح أو تعديل العرض. يمكنك استخدام كلاهما في نفس الملف.

**هل يمكنني تقييد التحرير على شرائح معينة دون التأثير على غيرها؟**

نعم. قم بتطبيق الأقفال فقط على الأشكال في الشرائح المختارة. هذا لا يغيّر إعدادات الأقفال في الشرائح الأخرى.

**كيف يمكنني تطبيق الأقفال على الأشكال الفردية داخل مجموعة؟**

قم بالتكرار عبر المجموعة التي تُرجعها طريقة [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/#getShapes) للمجموعة وطبق الأقفال المناسبة على كل شكل فرعي. كرر ذلك لأي مجموعات متداخلة. الأمثلة أعلاه تعالج فقط مجموعة الأشكال في الشريحة، لذلك لا تقوم بتعيين أقفال على أعضاء المجموعة الفرديين.