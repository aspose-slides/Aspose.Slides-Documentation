---
title: تقييد تحرير العرض بأقفال الأشكال في Node.js
linktitle: تقييد تحرير العرض
type: docs
weight: 60
url: /ar/nodejs-java/applying-protection-to-presentation/
keywords:
- منع التعديلات
- الحماية من التحرير
- قفل الشكل
- قفل الموقع
- قفل الاختيار
- قفل تغيير الحجم
- قفل التجميع
- PowerPoint
- PPTX
- العرض
- Node.js
- JavaScript
- Aspose.Slides
description: "تعرف على كيفية قفل وإلغاء قفل الأشكال في عروض PPTX باستخدام Aspose.Slides for Node.js عبر Java لتقييد الاختيار، التحريك، تغيير الحجم، والتجميع."
---
## **نظرة عامة**

استخدام شائع لـ Aspose.Slides for Node.js عبر Java هو إنشاء وتحديث وحفظ عروض PowerPoint (PPTX) كجزء من سير عمل آلي. عندما يتلقى المستخدمون هذه العروض، يمكن أن يساعد تقييد التغييرات على الأشكال في الحفاظ على التخطيط والمحتوى المقصود.

تشرح هذه المقالة كيف يتم تنظيم الأشكال على الشرائح وكيفية تطبيق وإزالة أقفال الأشكال في عرض PPTX. تسمح لك هذه الأقفال بتقييد عمليات تحرير محددة على كل شكل على حدة.

## **تكوين الشريحة**

تتكون شريحة العرض من مكوّنات مثل الأشكال التلقائية، الجداول، كائنات OLE، الأشكال المجمعة، إطارات الصور، إطارات الفيديو، الموصلات، وعناصر أخرى تُستخدم لبناء العرض. في Aspose.Slides for Node.js عبر Java، يُمثل كل عنصر على الشريحة كائنًا يرث من الفئة [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) .

أنواع الأشكال المختلفة تعرض خيارات أقفال مختلفة. الفئة [BaseShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseshapelock/) هي الفئة الأساسية لأقفال الأشكال. Aspose.Slides for Node.js عبر Java يوفر الفئات القفلية التالية:

- [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/) يقفل الأشكال التلقائية.  
- [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/) يقفل أشكال الموصلات.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/) يقفل الكائنات الرسومية.  
- [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/) يقفل الأشكال المجمعة.  
- [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/) يقفل إطارات الصور.  

لتطبيق الأقفال عبر [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)، قم بالتكرار عبر شرائحه واضبط الأقفال المناسبة على كل شكل مدعوم.

## **تطبيق وإزالة الحماية**

أقفال الأشكال تقيد عمليات مثل اختيار الأشكال، تحريكها، وتغيير حجمها. لا تجعل هذه الأقفال العرض بأكمله غير قابل للتحرير.

### **تطبيق الحماية على أشكال PPTX**

Aspose.Slides for Node.js عبر Java يوفر الفئة [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) للعمل مع الأشكال على الشريحة.

يستدعي المثال الدوال [setSelectLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSelectLocked)، [setPositionLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setPositionLocked)، و[setSizeLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSizeLocked) بقيمة `true` للأشكال التلقائية، مع أقفال مكافئة لأشكال المجموعات، الموصلات، وإطارات الصور. تستخدم الموصلات الدالة [setPositionMove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/#setPositionMove) للتحرك؛ وتستخدم المجموعات أيضًا الدالة [setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked) لتقييد التجميع.

يقوم المثال بتحميل عرض PPTX موجود، يفحص الأشكال في مجموعة الأشكال لكل شريحة، ويحفظ نسخة مع تطبيق هذه القيود. تُترك الأشكال خارج الأنواع الأربعة المعالجة دون تغيير. لا تتجول الحلقة داخل الأشكال الفرعية داخل مجموعة.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                const autoShapeLock = shape.getShapeLock();
                autoShapeLock.setPositionLocked(true);
                autoShapeLock.setSelectLocked(true);
                autoShapeLock.setSizeLocked(true);
            } else if (java.instanceOf(shape, "com.aspose.slides.IGroupShape")) {
                const groupShapeLock = shape.getShapeLock();
                groupShapeLock.setGroupingLocked(true);
                groupShapeLock.setPositionLocked(true);
                groupShapeLock.setSelectLocked(true);
                groupShapeLock.setSizeLocked(true);
            } else if (java.instanceOf(shape, "com.aspose.slides.IConnector")) {
                const connectorShapeLock = shape.getShapeLock();
                connectorShapeLock.setPositionMove(true);
                connectorShapeLock.setSelectLocked(true);
                connectorShapeLock.setSizeLocked(true);
            } else if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
                const pictureFrameLock = shape.getShapeLock();
                pictureFrameLock.setPositionLocked(true);
                pictureFrameLock.setSelectLocked(true);
                pictureFrameLock.setSizeLocked(true);
            }
        }
    }

    presentation.save("ProtectedSample.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **إزالة الحماية**

لإزالة قفل شكل، اضبط قيمته على `false`. المثال التالي يحمل عرضًا يحتوي على أقفال أشكال ويمسح قيود الاختيار، التحريك، وتغيير الحجم عبر [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/)، [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/)، [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/)، و[PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/). كما يزيل قيود التجميع بتمرير `false` إلى [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked) ويحفظ نسخة من العرض. تُترك إعدادات الأقفال الأخرى دون تغيير.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("ProtectedSample.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                const autoShapeLock = shape.getShapeLock();
                autoShapeLock.setPositionLocked(false);
                autoShapeLock.setSelectLocked(false);
                autoShapeLock.setSizeLocked(false);
            } else if (java.instanceOf(shape, "com.aspose.slides.IGroupShape")) {
                const groupShapeLock = shape.getShapeLock();
                groupShapeLock.setGroupingLocked(false);
                groupShapeLock.setPositionLocked(false);
                groupShapeLock.setSelectLocked(false);
                groupShapeLock.setSizeLocked(false);
            } else if (java.instanceOf(shape, "com.aspose.slides.IConnector")) {
                const connectorShapeLock = shape.getShapeLock();
                connectorShapeLock.setPositionMove(false);
                connectorShapeLock.setSelectLocked(false);
                connectorShapeLock.setSizeLocked(false);
            } else if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
                const pictureFrameLock = shape.getShapeLock();
                pictureFrameLock.setPositionLocked(false);
                pictureFrameLock.setSelectLocked(false);
                pictureFrameLock.setSizeLocked(false);
            }
        }
    }

    presentation.save("RemovedProtectionSample.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **الخلاصة**

Aspose.Slides for Node.js عبر Java يتيح لك تقييد عمليات تحرير محددة على أشكال فردية أو تطبيق نفس القيود عبر الشرائح. اختر الأقفال المدعومة من كل نوع شكل، واضبط قيمها على `false` عندما تحتاج إلى إزالة تلك القيود.

## **FAQ**

**هل يمكنني دمج أقفال الأشكال وحماية كلمة المرور في نفس العرض؟**

نعم. أقفال الأشكال تقيد عمليات تحرير محددة، بينما [password protection](/slides/ar/nodejs-java/password-protected-presentation/) يمكنها تقييد فتح أو تعديل العرض. يمكنك استخدام كلاهما في نفس الملف.

**هل يمكنني تقييد التحرير على شرائح معينة دون التأثير على غيرها؟**

نعم. طبّق الأقفال فقط على الأشكال في الشرائح المختارة. هذا لا يغيّر إعدادات الأقفال في الشرائح الأخرى.

**كيف يمكنني تطبيق أقفال على أشكال فردية داخل مجموعة؟**

قم بالتكرار عبر المجموعة التي تُرجعها طريقة [getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/#getShapes) للـ group وطبق الأقفال المناسبة على كل شكل فرعي. كرّر ذلك لأي مجموعات متداخلة. الأمثلة أعلاه تعالج فقط مجموعة الأشكال في الشريحة، ولذلك لا تقوم بتعيين أقفال على أعضاء المجموعة الفرديين.