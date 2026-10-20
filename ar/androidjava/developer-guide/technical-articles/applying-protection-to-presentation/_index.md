---
title: تقييد تحرير العروض التقديمية بأقفال الشكل على Android
linktitle: تقييد تحرير العروض التقديمية
type: docs
weight: 60
url: /ar/androidjava/applying-protection-to-presentation/
keywords:
- منع التعديلات
- الحماية من التحرير
- قفل الشكل
- قفل الموضع
- قفل التحديد
- قفل تغيير الحجم
- قفل التجميع
- PowerPoint
- PPTX
- العرض التقديمي
- Android
- Java
- Aspose.Slides
description: "تعرف على كيفية قفل وإلغاء قفل الأشكال في عروض PPTX باستخدام Aspose.Slides for Android عبر Java لتقييد التحديد، الحركة، تغيير الحجم، والتجميع."
---
## **نظرة عامة**

استخدام شائع لـ Aspose.Slides for Android via Java هو إنشاء وتحديث وحفظ عروض PowerPoint (PPTX) كجزء من سير عمل تلقائي. عندما يتلقى المستخدمون هذه العروض، يمكن أن يساعد تقييد التغييرات على الأشكال في الحفاظ على التخطيط والمحتوى المقصود.

توضح هذه المقالة كيف يتم تنظيم الأشكال على الشرائح وكيفية تطبيق وإزالة أقفال الأشكال في عرض PPTX. تتيح لك هذه الأقفال تقييد عمليات تحرير محددة على أشكال فردية.

## **تركيب الشريحة**

تتكون شريحة العرض من مكونات مثل الأشكال التلقائية والجداول وكائنات OLE والأشكال المجمعة وإطارات الصور وإطارات الفيديو والموصلات وعناصر أخرى تُستخدم لبناء العرض. في Aspose.Slides for Android via Java، يتم تمثيل كل عنصر على الشريحة بواسطة كائن ينفذ واجهة [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) أو يرث من فئة تقوم بذلك.

تُظهر أنواع الأشكال المختلفة خيارات قفل مختلفة. واجهة [IBaseShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseshapelock/) هي الواجهة الأساسية لأقفال الأشكال. توفر Aspose.Slides for Android via Java واجهات القفل التالية:

- [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/) يقفل الأشكال التلقائية.  
- [IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/) يقفل أشكال الموصلات.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobjectlock/) يقفل الكائنات الرسومية.  
- [IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/) يقفل الأشكال المجمعة.  
- [IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/) يقفل إطارات الصور.  

لتطبيق الأقفال عبر [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)، قم بالتكرار عبر شرائحه واضبط الأقفال المناسبة على كل شكل مدعوم.

## **تطبيق وإزالة الحماية**

تقيد أقفال الأشكال عمليات مثل تحديد الأشكال وتحريكها وتغيير حجمها. لا تجعل هذه الأقفال العرض بأكمله غير قابل للتحرير.

### **تطبيق الحماية على أشكال PPTX**

توفر Aspose.Slides for Android via Java واجهة [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) للعمل مع الأشكال على الشريحة.

تستدعي العينة [setSelectLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-)، [setPositionLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-)، و[setSizeLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-) مع `true` للأشكال التلقائية، مع أقفال مكافئة لأشكال المجموعات والموصلات وإطارات الصور. تستخدم الموصلات [setPositionMove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-) للحركة؛ وتستخدم المجموعات أيضًا [setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) لتقييد التجميع.

تقوم العينة بتحميل عرض PPTX موجود، تفحص الأشكال في مجموعة أشكال كل شريحة، وتحفظ نسخة مع تطبيق هذه القيود. تُترك الأشكال الخارجة عن الأنواع الأربعة المعالجة دون تغيير. لا يتجول الحلقة داخل الأشكال الفرعية داخل مجموعة.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();
                autoShapeLock.setPositionLocked(true);
                autoShapeLock.setSelectLocked(true);
                autoShapeLock.setSizeLocked(true);
            } else if (shape instanceof IGroupShape) {
                IGroupShape groupShape = (IGroupShape) shape;
                IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();
                groupShapeLock.setGroupingLocked(true);
                groupShapeLock.setPositionLocked(true);
                groupShapeLock.setSelectLocked(true);
                groupShapeLock.setSizeLocked(true);
            } else if (shape instanceof IConnector) {
                IConnector connectorShape = (IConnector) shape;
                IConnectorLock connectorShapeLock = connectorShape.getShapeLock();
                connectorShapeLock.setPositionMove(true);
                connectorShapeLock.setSelectLocked(true);
                connectorShapeLock.setSizeLocked(true);
            } else if (shape instanceof IPictureFrame) {
                IPictureFrame pictureFrame = (IPictureFrame) shape;
                IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();
                pictureFrameLock.setPositionLocked(true);
                pictureFrameLock.setSelectLocked(true);
                pictureFrameLock.setSizeLocked(true);
            }
        }
    }

    presentation.save("ProtectedSample.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **إزالة الحماية**

لإزالة قفل الشكل، اضبط قيمته إلى `false`. العينة التالية تقوم بتحميل عرض يحتوي على أقفال الأشكال وتزيل قيود التحديد والحركة وتغيير الحجم عبر [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/)، [IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/)، [IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/)، و[IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/). كما أنها تزيل قيود التجميع بتمرير `false` إلى [IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) وتحفظ نسخة من العرض. تُترك إعدادات القفل الأخرى دون تغيير.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("ProtectedSample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();
                autoShapeLock.setPositionLocked(false);
                autoShapeLock.setSelectLocked(false);
                autoShapeLock.setSizeLocked(false);
            } else if (shape instanceof IGroupShape) {
                IGroupShape groupShape = (IGroupShape) shape;
                IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();
                groupShapeLock.setGroupingLocked(false);
                groupShapeLock.setPositionLocked(false);
                groupShapeLock.setSelectLocked(false);
                groupShapeLock.setSizeLocked(false);
            } else if (shape instanceof IConnector) {
                IConnector connectorShape = (IConnector) shape;
                IConnectorLock connectorShapeLock = connectorShape.getShapeLock();
                connectorShapeLock.setPositionMove(false);
                connectorShapeLock.setSelectLocked(false);
                connectorShapeLock.setSizeLocked(false);
            } else if (shape instanceof IPictureFrame) {
                IPictureFrame pictureFrame = (IPictureFrame) shape;
                IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();
                pictureFrameLock.setPositionLocked(false);
                pictureFrameLock.setSelectLocked(false);
                pictureFrameLock.setSizeLocked(false);
            }
        }
    }

    presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **الخلاصة**

تمكنك Aspose.Slides for Android via Java من تقييد عمليات تحرير محددة على أشكال فردية أو تطبيق نفس القيود عبر الشرائح. اختر الأقفال المدعومة من كل نوع شكل، واضبط قيمها إلى `false` عندما تحتاج إلى إزالة تلك القيود.

## **الأسئلة الشائعة**

**هل يمكنني دمج أقفال الأشكال وحماية كلمة المرور في نفس العرض؟**

نعم. أقفال الأشكال تقيد عمليات تحرير محددة، بينما [password protection](/slides/ar/androidjava/password-protected-presentation/) يمكنها تقييد فتح أو تعديل العرض. يمكنك استخدام كلاهما في نفس الملف.

**هل يمكنني تقييد التحرير على شرائح محددة دون التأثير على الأخرى؟**

نعم. قم بتطبيق الأقفال فقط على الأشكال في الشرائح المحددة. هذا لا يغيّر إعدادات القفل على الشرائح الأخرى.

**كيف يمكنني تطبيق الأقفال على أشكال فردية داخل مجموعة؟**

قم بالتكرار عبر المجموعة باستخدام طريقة [getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/#getShapes--) ثم طبّق الأقفال المناسبة على كل شكل فرعي. كرّر ذلك لأي مجموعات متداخلة. الأمثلة أعلاه تعالج فقط مجموعة أشكال الشريحة، لذلك لا تقوم بتعيين أقفال على أعضاء المجموعة الفردية.