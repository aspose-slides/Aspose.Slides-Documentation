---
title: تقييد تحرير العرض التقديمي باستخدام أقفال الأشكال في بايثون
linktitle: تقييد تحرير العرض التقديمي
type: docs
weight: 60
url: /ar/python-java/applying-protection-to-presentation/
keywords:
- منع التعديلات
- حماية من التحرير
- قفل الشكل
- قفل الموقع
- قفل الاختيار
- قفل تغيير الحجم
- قفل التجميع
- PowerPoint
- PPTX
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "تعرف على كيفية قفل وإلغاء قفل الأشكال في عروض PPTX باستخدام Aspose.Slides for Python عبر Java لتقييد الاختيار والحركة وتغيير الحجم والتجميع."
---
## **الخلفية**

استخدام شائع لـ Aspose.Slides for Python عبر Java هو إنشاء وتحديث وحفظ عروض PowerPoint (PPTX) كجزء من سير عمل آلي. عندما يتلقى المستخدمون هذه العروض، يمكن أن يساعد تقييد التعديلات على الأشكال في الحفاظ على التخطيط والمحتوى المقصود.

تشرح هذه المقالة كيفية تنظيم الأشكال على الشرائح وكيفية تطبيق وإزالة أقفال الأشكال في عرض PPTX. تتيح لك هذه الأقفال تقييد عمليات تحرير محددة على الأشكال الفردية.

## **تكوين الشريحة**

تتكون شريحة العرض من مكونات مثل الأشكال التلقائية والجداول وكائنات OLE والأشكال المجمعة وإطارات الصور وإطارات الفيديو والموصلات وعناصر أخرى تُستخدم لإنشاء عرض تقديمي. في Aspose.Slides for Python عبر Java، يتم تمثيل كل عنصر على الشريحة بواسطة كائن يرث من الفئة [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) .

تُظهر الأنواع المختلفة من الأشكال خيارات قفل مختلفة. الفئة [BaseShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/baseshapelock/) هي الفئة الأساسية لأقفال الأشكال. يوفر Aspose.Slides for Python عبر Java الفئات القفل التالية:

- [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/) يقفل الأشكال التلقائية.  
- [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) يقفل أشكال الموصل.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobjectlock/) يقفل الكائنات الرسومية.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/) يقفل الأشكال المجمعة.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/) يقفل إطارات الصور.  

لتطبيق الأقفال عبر [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)، قم بالتكرار عبر شرائحه وتعيين الأقفال المناسبة على كل شكل مدعوم.

## **تطبيق وإزالة الحماية**

أقفال الأشكال تقيد عمليات مثل اختيار الأشكال وتحريكها وتغيير حجمها. وهي لا تجعل العرض التقديمي بالكامل غير قابل للتحرير.

### **تطبيق الحماية على أشكال PPTX**

يوفر Aspose.Slides for Python عبر Java الفئة [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) للعمل مع الأشكال على الشريحة.

تستدعي العينة الدوال [setSelectLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSelectLocked) و[setPositionLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setPositionLocked) و[setSizeLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSizeLocked) مع القيمة `True` للأشكال التلقائية، مع أقفال مماثلة للأشكال المجمعة والموصلات وإطارات الصور. تستخدم الموصلات الدالة [setPositionMove](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/#setPositionMove) للتحريك؛ وتستخدم المجموعات أيضًا الدالة [setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) لتقييد التجميع.

تقوم العينة بتحميل عرض PPTX موجود، وتفحص الأشكال في مجموعة الأشكال لكل شريحة، وتحفظ نسخة مع تطبيق هذه القيود. تُترك الأشكال خارج الأنواع الأربعة المعالجة دون تغيير. لا يتجول الحلقة عبر الأشكال الفرعية داخل مجموعة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, AutoShape):
                auto_shape_lock = shape.getShapeLock()
                auto_shape_lock.setPositionLocked(True)
                auto_shape_lock.setSelectLocked(True)
                auto_shape_lock.setSizeLocked(True)
            elif isinstance(shape, GroupShape):
                group_shape_lock = shape.getShapeLock()
                group_shape_lock.setGroupingLocked(True)
                group_shape_lock.setPositionLocked(True)
                group_shape_lock.setSelectLocked(True)
                group_shape_lock.setSizeLocked(True)
            elif isinstance(shape, Connector):
                connector_shape_lock = shape.getShapeLock()
                connector_shape_lock.setPositionMove(True)
                connector_shape_lock.setSelectLocked(True)
                connector_shape_lock.setSizeLocked(True)
            elif isinstance(shape, PictureFrame):
                picture_frame_lock = shape.getShapeLock()
                picture_frame_lock.setPositionLocked(True)
                picture_frame_lock.setSelectLocked(True)
                picture_frame_lock.setSizeLocked(True)

    presentation.save("ProtectedSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **إزالة الحماية**

لإزالة قفل الشكل، اضبط قيمته على `False`. تقوم العينة التالية بتحميل عرض يحتوي على أقفال الأشكال وتزيل قيود الاختيار والتحريك وتغيير الحجم عبر [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/) و[GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/) و[ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) و[PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/). كما تُزيل قيود التجميع بتمرير `False` إلى [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) وتحفظ نسخة من العرض. تُترك إعدادات الأقفال الأخرى دون تغيير.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

presentation = Presentation("ProtectedSample.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, AutoShape):
                auto_shape_lock = shape.getShapeLock()
                auto_shape_lock.setPositionLocked(False)
                auto_shape_lock.setSelectLocked(False)
                auto_shape_lock.setSizeLocked(False)
            elif isinstance(shape, GroupShape):
                group_shape_lock = shape.getShapeLock()
                group_shape_lock.setGroupingLocked(False)
                group_shape_lock.setPositionLocked(False)
                group_shape_lock.setSelectLocked(False)
                group_shape_lock.setSizeLocked(False)
            elif isinstance(shape, Connector):
                connector_shape_lock = shape.getShapeLock()
                connector_shape_lock.setPositionMove(False)
                connector_shape_lock.setSelectLocked(False)
                connector_shape_lock.setSizeLocked(False)
            elif isinstance(shape, PictureFrame):
                picture_frame_lock = shape.getShapeLock()
                picture_frame_lock.setPositionLocked(False)
                picture_frame_lock.setSelectLocked(False)
                picture_frame_lock.setSizeLocked(False)

    presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **الخلاصة**

يتيح لك Aspose.Slides for Python عبر Java تقييد عمليات تحرير محددة على الأشكال الفردية أو تطبيق نفس القيود عبر الشرائح. اختر الأقفال المدعومة من كل نوع من الأشكال، وضبط قيمها على `False` عندما تحتاج إلى إزالة تلك القيود.

## **الأسئلة الشائعة**

**هل يمكنني دمج أقفال الأشكال وحماية كلمة المرور في نفس العرض؟**

نعم. تقيد أقفال الأشكال عمليات تحرير محددة، بينما [حماية كلمة المرور](/slides/ar/python-java/password-protected-presentation/) يمكنها تقييد فتح أو تعديل العرض. يمكنك استخدام كليهما في نفس الملف.

**هل يمكنني تقييد التحرير على شرائح معينة دون التأثير على الأخريات؟**

نعم. قم بتطبيق الأقفال فقط على الأشكال في الشرائح المحددة. هذا لا يغيّر إعدادات الأقفال في الشرائح الأخرى.

**كيف يمكنني تطبيق الأقفال على الأشكال الفردية داخل مجموعة؟**

قم بالتكرار عبر المجموعة التي تُعيدها طريقة [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes) للمجموعة وطبق الأقفال المناسبة على كل شكل فرعي. كرر ذلك لأي مجموعات متداخلة. الأمثلة أعلاه تعالج فقط مجموعة الأشكال في الشريحة، لذا لا تقوم بتعيين أقفال على أعضاء المجموعة الفردية.