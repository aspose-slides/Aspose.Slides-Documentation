---
title: تقييد تعديل العروض بأقفال الأشكال في Java
linktitle: تقييد تعديل العروض
type: docs
weight: 60
url: /ar/java/applying-protection-to-presentation/
keywords:
- منع التعديلات
- الحماية من التحرير
- قفل الشكل
- قفل الموضع
- قفل الاختيار
- قفل تغيير الحجم
- قفل التجميع
- PowerPoint
- PPTX
- عرض
- Java
- Aspose.Slides
description: "تعلم كيفية قفل وإلغاء قفل الأشكال في عروض PPTX باستخدام Aspose.Slides for Java لتقييد الاختيار، الحركة، تغيير الحجم، والتجميع."
---
## **الخلفية**

الاستخدام الشائع لـ Aspose.Slides for Java هو إنشاء وتحديث وحفظ عروض PowerPoint (PPTX) كجزء من سير عمل آلي. عندما يتلقى المستخدمون هذه العروض، يمكن أن يساعد تقييد التغييرات على الأشكال في الحفاظ على التخطيط والمحتوى المقصود.

تشرح هذه المقالة كيفية تنظيم الأشكال على الشرائح وكيفية تطبيق وإزالة أقفال الأشكال في عرض PPTX. تتيح لك هذه الأقفال تقييد عمليات تحرير محددة على كل شكل على حدة.

## **تركيب الشريحة**

تتكون شريحة العرض من مكونات مثل الأشكال التلقائية، الجداول، كائنات OLE، الأشكال المجمعة، إطارات الصور، إطارات الفيديو، الموصلات، وعناصر أخرى تُستخدم لبناء العرض. في Aspose.Slides for Java، كل عنصر على الشريحة يُمثل بكائن يطبق واجهة [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) أو يرث من فئة تقوم بذلك.

تكشف أنواع الأشكال المختلفة عن خيارات قفل مختلفة. واجهة [IBaseShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseshapelock/) هي الواجهة الأساسية لأقفال الأشكال. توفر Aspose.Slides for Java واجهات القفل التالية:

- [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/) يقفل الأشكال التلقائية.  
- [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/) يقفل أشكال الموصلات.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/java/com.aspose.slides/igraphicalobjectlock/) يقفل الكائنات الرسومية.  
- [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/) يقفل الأشكال المجمعة.  
- [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/) يقفل إطارات الصور.  

لتطبيق الأقفال عبر [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)، قم بالتكرار عبر شرائحه واضبط الأقفال المناسبة على كل شكل مدعوم.

## **تطبيق وإزالة الحماية**

أقفال الأشكال تقيد عمليات مثل اختيار الأشكال، تحريكها، وتغيير حجمها. وهي لا تجعل العرض بالكامل غير قابل للتحرير.

### **تطبيق الحماية على أشكال PPTX**

توفر Aspose.Slides for Java واجهة [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) للعمل مع الأشكال على الشريحة.

تستدعي العينة الدالة [setSelectLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-)، [setPositionLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-)، و [setSizeLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-) مع القيمة `true` للأشكال التلقائية، مع أقفال مكافئة لأشكال المجموعات، الموصلات، وإطارات الصور. تستخدم الموصلات الدالة [setPositionMove](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-) للتحرك؛ وتستخدم المجموعات أيضًا الدالة [setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) لتقييد التجميع.

تقوم العينة بتحميل عرض PPTX موجود، وتفحص الأشكال في مجموعة الأشكال لكل شريحة، وتحفظ نسخة مع تطبيق هذه القيود. تُترك الأشكال الخارجة عن الأنواع الأربعة المدعومة دون تغيير. لا يتجول الحلقة داخل الأشكال الفرعية داخل مجموعة.

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

لإزالة قفل الشكل، اضبط قيمته على `false`. تقوم العينة التالية بتحميل عرض يحتوي على أقفال الأشكال وتزيل قيود الاختيار، التحريك، وتغيير الحجم عبر [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/)، [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/)، [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/)، و [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/). كما تُزيل قيد التجميع بتمرير `false` إلى [IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) وتحفظ نسخة من العرض. تُترك إعدادات الأقفال الأخرى دون تغيير.

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

تسمح لك Aspose.Slides for Java بتقييد عمليات تحرير محددة على أشكال فردية أو تطبيق نفس القيود عبر الشرائح. اختر الأقفال المدعومة من كل نوع شكل، واضبط قيمها على `false` عندما تحتاج إلى إزالة تلك القيود.

## **الأسئلة الشائعة**

**هل يمكنني الجمع بين أقفال الأشكال وحماية كلمة المرور في نفس العرض؟**

نعم. أقفال الأشكال تقيد عمليات تحرير محددة، بينما يمكن لـ [password protection](/slides/ar/java/password-protected-presentation/) تقييد فتح أو تعديل العرض. يمكنك استخدامهما معًا في نفس الملف.

**هل يمكنني تقييد التحرير على شرائح معينة دون التأثير على غيرها؟**

نعم. قم بتطبيق الأقفال فقط على الأشكال في الشرائح المحددة. هذا لا يغيّر إعدادات الأقفال في الشرائح الأخرى.

**كيف يمكنني تطبيق أقفال على أشكال فردية داخل مجموعة؟**

قم بالتكرار عبر المجموعة باستخدام طريقة [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/#getShapes--) وتطبيق الأقفال المناسبة على كل شكل فرعي. كرر ذلك لأي مجموعات متداخلة. الأمثلة أعلاه تعالج فقط مجموعة الأشكال الخاصة بالشريحة، لذلك لا تقوم بتعيين أقفال لأعضاء المجموعة الفرديين.