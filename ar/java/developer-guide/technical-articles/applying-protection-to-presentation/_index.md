---
title: منع تعديل العرض باستخدام أقفال الشكل
linktitle: منع تعديل العرض
type: docs
weight: 60
url: /ar/java/applying-protection-to-presentation/
keywords:
- منع التعديلات
- حماية من التحرير
- قفل الشكل
- قفل الموضع
- قفل الاختيار
- قفل الحجم
- قفل التجميع
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "اكتشف كيف تقوم Aspose.Slides for Java بقفل أو إلغاء قفل الأشكال في ملفات PPT و PPTX و ODP، مما يحمي العروض التقديمية مع إتاحة تحرير مضبوط وتسليم أسرع."
---

## **الخلفية**

استخدام شائع لـ Aspose.Slides هو إنشاء وتحديث وحفظ عروض Microsoft PowerPoint (PPTX) كجزء من سير عمل مؤتمت. يحصل مستخدمو التطبيقات التي تستخدم Aspose.Slides بهذه الطريقة على الوصول إلى العروض التي تم إنشاؤها، لذا فإن حماية هذه العروض من التحرير تشكل قلقًا شائعًا. من المهم أن تحتفظ العروض التي تم إنشاؤها تلقائيًا بالتنسيق والمحتوى الأصليين.

توضح هذه المقالة كيفية هيكلة العروض والشرائح وكيف يمكن لـ Aspose.Slides for Java تطبيق الحماية على عرض ثم إزالتها لاحقًا. فهي توفر للمطورين وسيلة للتحكم في كيفية استخدام العروض التي تولدها تطبيقاتهم.

## **تكوين الشريحة**

تتكون شريحة العرض من مكونات مثل الأشكال التلقائية، الجداول، كائنات OLE، الأشكال المجمعة، إطارات الصور، إطارات الفيديو، الموصلات، وعناصر أخرى تُستخدم لبناء عرض تقديمي. في Aspose.Slides for Java، يُمثَّل كل عنصر في الشريحة بكائن يُنفِّذ الواجهة [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) أو يرث من فئة تقوم بذلك.

هيكل PPTX معقد، لذا على عكس PPT حيث يمكن استخدام قفل عام لجميع أنواع الأشكال، تتطلب أنواع الأشكال المختلفة أقفالًا مختلفة. الواجهة [IBaseShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseshapelock/) هي الفئة العامة للقفل في PPTX. الأنواع التالية من الأقفال مدعومة في Aspose.Slides for Java لـ PPTX:

- [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/) يقفل الأشكال التلقائية.  
- [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/) يقفل أشكال الموصلات.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/java/com.aspose.slides/igraphicalobjectlock/) يقفل الكائنات الرسومية.  
- [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/) يقفل الأشكال المجمعة.  
- [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/) يقفل إطارات الصور.  

أي إجراء يُجرى على جميع كائنات الشكل في كائن [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) يُطبق على العرض بأكمله.

## **تطبيق وإزالة الحماية**

تطبيق الحماية يضمن عدم إمكانية تعديل العرض. وهي تقنية مفيدة لحماية محتوى العرض.

### **تطبيق الحماية على أشكال PPTX**

توفر Aspose.Slides for Java الواجهة [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) للعمل مع الأشكال على الشريحة.

كما ذُكر سابقًا، كل فئة شكل لها فئة قفل شكل مرتبطة للحماية. تركز هذه المقالة على أقفال NoSelect و NoMove و NoResize. هذه الأقفال تضمن عدم إمكانية اختيار الأشكال (من خلال نقرات الفأرة أو طرق اختيار أخرى) وعدم إمكانية نقلها أو تغيير حجمها.

عينة الشيفرة التالية تطبق الحماية على جميع أنواع الأشكال في عرض تقديمي.
```java
// إنشاء كائن Presentation الذي يمثل ملف PPTX.
Presentation presentation = new Presentation("Sample.pptx");

// Traversing all the slides in the presentation.
for (ISlide slide : presentation.getSlides()) {

    // Traversing all the shapes in the slide.
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAutoShape) {
            // تحويل النوع إلى autoshape والحصول على قفل الشكل.
            IAutoShape autoShape = (IAutoShape) shape;
            IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();

            autoShapeLock.setPositionLocked(true);
            autoShapeLock.setSelectLocked(true);
            autoShapeLock.setSizeLocked(true);
        } else if (shape instanceof IGroupShape) {
            // تحويل النوع إلى شكل مجموعة والحصول على قفل الشكل.
            IGroupShape groupShape = (IGroupShape) shape;
            IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();

            groupShapeLock.setGroupingLocked(true);
            groupShapeLock.setPositionLocked(true);
            groupShapeLock.setSelectLocked(true);
            groupShapeLock.setSizeLocked(true);
        } else if (shape instanceof IConnector) {
            // تحويل النوع إلى شكل موصل والحصول على قفل الشكل.
            IConnector connectorShape = (IConnector) shape;
            IConnectorLock connectorShapeLock = connectorShape.getShapeLock();

            connectorShapeLock.setPositionMove(true);
            connectorShapeLock.setSelectLocked(true);
            connectorShapeLock.setSizeLocked(true);
        } else if (shape instanceof IPictureFrame) {
            // تحويل النوع إلى إطار صورة والحصول على قفل الشكل.
            IPictureFrame pictureFrame = (IPictureFrame) shape;
            IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();

            pictureFrameLock.setPositionLocked(true);
            pictureFrameLock.setSelectLocked(true);
            pictureFrameLock.setSizeLocked(true);
        }
    }
}

// حفظ ملف العرض.
presentation.save("ProtectedSample.pptx", SaveFormat.Pptx);
presentation.dispose();
```


### **إزالة الحماية**

لإلغاء قفل شكل، عيّن قيمة القفل المطبّق إلى `false`. تُظهر عينة الشيفرة التالية كيفية إلغاء قفل الأشكال في عرض مؤمَّن.
```java
// إنشاء كائن Presentation الذي يمثل ملف PPTX.
Presentation presentation = new Presentation("ProtectedSample.pptx");

// استعراض جميع الشرائح في العرض.
for (ISlide slide : presentation.getSlides()) {

    // استعراض جميع الأشكال في الشريحة.
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAutoShape) {
            // تحويل النوع إلى autoshape والحصول على قفل الشكل.
            IAutoShape autoShape = (IAutoShape) shape;
            IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();

            autoShapeLock.setPositionLocked(false);
            autoShapeLock.setSelectLocked(false);
            autoShapeLock.setSizeLocked(false);
        } else if (shape instanceof IGroupShape) {
            // تحويل النوع إلى شكل مجموعة والحصول على قفل الشكل.
            IGroupShape groupShape = (IGroupShape) shape;
            IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();

            groupShapeLock.setGroupingLocked(false);
            groupShapeLock.setPositionLocked(false);
            groupShapeLock.setSelectLocked(false);
            groupShapeLock.setSizeLocked(false);
        } else if (shape instanceof IConnector) {
            // تحويل النوع إلى شكل موصل والحصول على قفل الشكل.
            IConnector connectorShape = (IConnector) shape;
            IConnectorLock connectorShapeLock = connectorShape.getShapeLock();

            connectorShapeLock.setPositionMove(false);
            connectorShapeLock.setSelectLocked(false);
            connectorShapeLock.setSizeLocked(false);
        } else if (shape instanceof IPictureFrame) {
            // تحويل النوع إلى إطار صورة والحصول على قفل الشكل.
            IPictureFrame pictureFrame = (IPictureFrame) shape;
            IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();

            pictureFrameLock.setPositionLocked(false);
            pictureFrameLock.setSelectLocked(false);
            pictureFrameLock.setSizeLocked(false);
        }
    }
}

// حفظ ملف العرض.
presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **الخلاصة**

توفر Aspose.Slides عدة خيارات لحماية الأشكال في عرض تقديمي. يمكنك قفل شكل فردي أو المرور عبر جميع الأشكال في عرض وتطبيق القفل على كلٍ منها لتأمين الملف بالكامل بفعالية. يمكنك إزالة الحماية بتعيين قيمة القفل إلى `false`.

## **الأسئلة المتكررة**

**هل يمكنني دمج أقفال الأشكال وحماية كلمة المرور في نفس العرض؟**

نعم. تحدّ القفل من تحرير الكائنات داخل الملف، بينما [حماية كلمة المرور](/slides/ar/java/password-protected-presentation/) يتحكم في الوصول إلى فتح الملف و/أو حفظ التغييرات. تكمل هذه الآليات بعضها البعض وتعمل معاً.

**هل يمكنني تقييد التحرير على شرائح محددة دون تأثير على غيرها؟**

نعم. قم بتطبيق الأقفال على الأشكال في الشرائح المحددة؛ الشرائح المتبقية ستظل قابلة للتحرير.

**هل تنطبق أقفال الأشكال على الكائنات المجمعة والموصلات؟**

نعم. هناك أنواع أقفال مخصصة مدعومة للمجموعات، الموصلات، الكائنات الرسومية، وأنواع أخرى من الأشكال.