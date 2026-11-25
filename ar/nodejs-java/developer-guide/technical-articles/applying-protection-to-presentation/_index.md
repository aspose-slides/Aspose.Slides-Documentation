---
title: تقييد تحرير العروض باستخدام أقفال الشكل في Node.js
linktitle: تقييد تحرير العرض
type: docs
weight: 60
url: /ar/nodejs-java/applying-protection-to-presentation/
keywords:
- منع التحرير
- حماية من التحرير
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
description: "تعرّف على كيفية قفل وإلغاء قفل الأشكال في عروض PPTX باستخدام Aspose.Slides for Node.js عبر Java لتقييد الاختيار والحركة وتغيير الحجم والتجميع."
---
## **نظرة عامة**

استخدام شائع لـ Aspose.Slides for Node.js via Java هو إنشاء وتحديث وحفظ عروض PowerPoint (PPTX) كجزء من سير عمل آلي. عندما يتلقى المستخدمون هذه العروض، يمكن أن يساعد تقييد التغييرات على الأشكال في الحفاظ على التخطيط والمحتوى المقصود.

تشرح هذه المقالة كيفية تنظيم الأشكال على الشرائح وكيفية تطبيق وإزالة أقفال الأشكال في عرض PPTX. تسمح لك هذه الأقفال بتقييد عمليات تحرير محددة على كل شكل على حدة.

## **تركيب الشريحة**

تتكون شريحة العرض من مكونات مثل الأشكال التلقائية، الجداول، كائنات OLE، الأشكال المجمعة، إطارات الصور، إطارات الفيديو، الموصلات، وعناصر أخرى تُستخدم لبناء العرض. في Aspose.Slides for Node.js via Java، يُمثَّل كل عنصر على الشريحة ككائن يرث من الفئة [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) .

تكشف أنواع الأشكال المختلفة عن خيارات قفل مختلفة. الفئة [BaseShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseshapelock/) هي الفئة الأساسية لأقفال الأشكال. توفر Aspose.Slides for Node.js via Java الفئات القفلية التالية:

- [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/) يقفل الأشكال التلقائية.  
- [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/) يقفل أشكال الموصل.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/) يقفل الكائنات الرسومية.  
- [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/) يقفل الأشكال المجمعة.  
- [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/) يقفل إطارات الصور.  

لتطبيق الأقفال عبر الـ [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)، قم بالتكرار عبر شرائحه واضبط الأقفال المناسبة على كل شكل مدعوم.

## **تطبيق وإزالة الحماية**

تستخدم محررات العروض المتوافقة أقفال الأشكال لتقييد عمليات التحرير الفردية. تشفير الملفات وحماية الكتابة على مستوى المستند هي إعدادات [presentation protection settings](/slides/ar/nodejs-java/password-protected-presentation/) منفصلة.

### **تطبيق الحماية على أشكال PPTX**

توفر Aspose.Slides for Node.js via Java الفئة [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) للعمل مع الأشكال على الشريحة.

تستدعي العينة الدوال [setSelectLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSelectLocked)، [setPositionLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setPositionLocked)، و[setSizeLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSizeLocked) مع `true` للأشكال التلقائية، مع أقفال مكافئة لأشكال المجموعات، الموصلات، وإطارات الصور. تستخدم الموصلات [setPositionMove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/#setPositionMove) للحركة؛ المجموعات تستخدم أيضًا [setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked) لتقييد التجميع.

تقوم العينة بتحميل عرض PPTX موجود، وتفحص الأشكال في مجموعة أشكال كل شريحة، وتحفظ نسخة مع تطبيق هذه القيود. تُترك الأشكال خارج الأنواع الأربعة المعالجة دون تغيير. لا يتجول الحلقة عبر الأشكال الفرعية داخل مجموعة.

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

لإزالة قفل الشكل، اضبط قيمته إلى `false`. تقوم العينة التالية بتحميل عرض يحتوي على أقفال أشكال وتزيل قيود الاختيار والحركة وتغيير الحجم عبر [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/)، [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/)، [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/)، و[PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/). كما أنها تزيل قيد التجميع بتمرير `false` إلى [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked)، وتحفظ نسخة من العرض. تظل إعدادات الأقفال الأخرى دون تغيير.

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

### **الحفاظ على قص الصورة**

ضع صورة باسم `photo.jpg` في دليل العمل. تقص العينة 12% من اليسار و8% من اليمين، ثم تستدعي [setCropLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/#setCropLocked) على قفل إطار الصورة. تمرير `true` يقيّد القص الإضافي ويحافظ على القص الحالي.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();

    const photoStream = java.newInstanceSync("java.io.FileInputStream", "photo.jpg");
    let photo;
    try {
        photo = presentation.getImages().addImage(photoStream);
    } finally {
        photoStream.close();
    }

    const pictureFrame = shapes.addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 30, 270, 160, photo);
    pictureFrame.getPictureFormat().setCropLeft(12);
    pictureFrame.getPictureFormat().setCropRight(8);

    const pictureFrameLock = pictureFrame.getPictureFrameLock();
    pictureFrameLock.setAspectRatioLocked(false);
    pictureFrameLock.setCropLocked(true);

    presentation.save("PictureLocked.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`PictureLocked.pptx` يخزن قفل القص كـ `true`. في PowerPoint، يُعطَّل أمر **Crop** عند تحديد الصورة.

### **إبقاء المخطط مجمعًا**

تقوم العينة بتجميع مستطيل وسهم، ثم تستدعي [setUngroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setUngroupingLocked) على قفل المجموعة للحفاظ على مكونات المخطط معًا. تظل التعديلات الأخرى، مثل نقل المجموعة أو تغيير تعبئة مكون، متاحة.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();
    
    const groupShape = shapes.addGroupShape();
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 70, 90, 50);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.RightArrow, 190, 80, 60, 30);
    groupShape.getGroupShapeLock().setUngroupingLocked(true);

    presentation.save("DiagramLocked.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`DiagramLocked.pptx` يخزن قفل فك التجميع كـ `true`. في PowerPoint، يُعطَّل أمر **Ungroup** عند تحديد المخطط بالكامل.

### **تقرير أقفال الأشكال الموجودة**

لمراجعة قالب، افتحه واقرأ كائن القفل لكل شكل. تُعيد الطريقة [getNoLocks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseshapelock/#getNoLocks) القيمة `true` عندما تكون جميع العلامات على ذلك الكائن غير مفعَّلة و`false` عندما يكون على الأقل واحدة مفعَّلة. للمجموعة وأطفاله كائنات قفل منفصلة، لذا افحص الأطفال حتى عندما لا تحتوي المجموعة على أقفال.

تتحقق هذه العينة من الحركة للأشكال التلقائية، إطارات الصور، والمجموعات. كما تتحقق من القص للصور وفك التجميع للمجموعات. يسرد التقرير العلامات المفعَّلة التي يتعرف عليها ويُعلِّم أنواع الأشكال التي لا يفحصها.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function inspectShapes(shapes, slideNumber, prefix) {
    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const path = prefix + shape.getName();
        const type = shape.getClass().getSimpleName();
        const label = `Slide ${slideNumber} | ${path} | ${type}`;
        const flags = [];
        const isGroup = java.instanceOf(shape, "com.aspose.slides.IGroupShape");
        let shapeLock;

        if (isGroup) {
            shapeLock = shape.getGroupShapeLock();
            if (shapeLock.getUngroupingLocked()) flags.push("UngroupingLocked");
        } else if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            shapeLock = shape.getPictureFrameLock();
            if (shapeLock.getCropLocked()) flags.push("CropLocked");
        } else if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            shapeLock = shape.getAutoShapeLock();
        } else {
            console.log(`${label} | Uninspected`);
            continue;
        }

        if (!shapeLock.getNoLocks()) {
            if (shapeLock.getPositionLocked()) flags.push("PositionLocked");
            const restrictions = flags.length ? flags.join(", ") : "Active flag not identified";
            console.log(`${label} | ${restrictions}`);
        }

        if (isGroup) {
            inspectShapes(shape.getShapes(), slideNumber, path + "/");
        }
    }
}

const presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    const slides = presentation.getSlides();
    for (let i = 0; i < slides.size(); i++) {
        const slide = slides.get_Item(i);
        inspectShapes(slide.getShapes(), slide.getSlideNumber(), "");
    }
} finally {
    presentation.dispose();
}
```

افترض أن الشريحة 1 من `Sample.pptx` تحتوي على مجموعة تسمى `Layout` بقفل فك التجميع، وصورة تسمى `Photo` داخلها بقفل القص، ومستطيل غير مقفل باسم `Free`. يتخطى التقرير `Free` ويطبع هذين السطرين:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

يقرأ التقرير العلامات التحريرية على مستوى الشكل المخزنة دون تغييرها أو حفظ العرض. حماية الكتابة على مستوى المستند هي إعداد منفصل، وتعتمد فرضية كل علامة على المحرر.

### **الخلاصة**

تُتيح لك Aspose.Slides for Node.js via Java تقييد عمليات تحرير محددة على أشكال فردية أو تطبيق نفس القيود عبر الشرائح. اختر الأقفال المدعومة من كل نوع شكل، واضبط قيمتها إلى `false` عندما تحتاج إلى إزالة تلك القيود.

## **الأسئلة المتكررة**

**هل يمكنني دمج أقفال الأشكال وحماية كلمة المرور في نفس العرض؟**

نعم. تقيد أقفال الأشكال عمليات تحرير محددة، بينما يمكن لحماية [password protection](/slides/ar/nodejs-java/password-protected-presentation/) تقييد فتح أو تعديل العرض. يمكنك استخدام كليهما في نفس الملف.

**هل يمكنني تقييد التحرير على شرائح محددة دون التأثير على غيرها؟**

نعم. قم بتطبيق الأقفال فقط على الأشكال في الشرائح المختارة. هذا لا يغيّر إعدادات الأقفال في الشرائح الأخرى.

**كيف يمكنني تطبيق الأقفال على الأشكال الفردية داخل مجموعة؟**

قم بالتكرار عبر المجموعة التي تُرجعها طريقة [getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/#getShapes) للمجموعة وطبق الأقفال المناسبة على كل شكل فرعي. كرّر ذلك لأي مجموعات متداخلة، متبعًا عملية التجوال في مثال التقرير.