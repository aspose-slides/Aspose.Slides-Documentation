---
title: منع تعديل العرض باستخدام أقفال الشكل
linktitle: منع تعديل العرض
type: docs
weight: 60
url: /ar/python-java/applying-protection-to-presentation/
keywords:
- منع التعديلات
- الحماية من التحرير
- قفل الشكل
- قفل الموقع
- قفل التحديد
- قفل الحجم
- قفل التجميع
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "اكتشف كيف يقوم Aspose.Slides for Python via Java بقفل أو إلغاء قفل الأشكال في ملفات PPT و PPTX و ODP، مما يحمي العروض التقديمية مع السماح بتحريرات مُتحكم فيها وتسليم أسرع."
---
## **الخلفية**

الاستخدام الشائع لـ Aspose.Slides هو إنشاء وتحديث وحفظ عروض Microsoft PowerPoint (PPTX) كجزء من سير عمل تلقائي. يحصل مستخدمو التطبيقات التي تستخدم Aspose.Slides بهذه الطريقة على العروض المولدة، لذا فإن حماية هذه العروض من التعديل تُعَدُّ مصدر قلق شائع. من المهم أن تحتفظ العروض التي تم إنشاؤها تلقائيًا بتنسيقها ومحتواها الأصلي.

توضح هذه المقالة كيفية هيكلة العروض والشرائح وكيف يمكن لـ Aspose.Slides for Python via Java تطبيق الحماية على عرض ثم إزالتها لاحقًا. وتوفر للمطورين طريقة للتحكم في كيفية استخدام العروض التي تُنشئها تطبيقاتهم.

## **تكوين الشريحة**

تتكون شريحة العرض من مكونات مثل الأشكال الذاتية، الجداول، كائنات OLE، الأشكال المجمعة، إطارات الصور، إطارات الفيديو، الموصلات، وعناصر أخرى تُستخدم لإنشاء عرض تقديمي. في Aspose.Slides for Python via Java، يُمثَّل كل عنصر في الشريحة ككائن يرث من فئة [Shape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/) .

بنية PPTX معقدة، وبالتالي على عكس PPT حيث يمكن استخدام قفل عام لجميع أنواع الأشكال، تتطلب أنواع الأشكال المختلفة أقفالًا مختلفة. تُعد فئة [BaseShapeLock](https://reference.aspose.com/slides/ar/python-java/aspose.slides/baseshapelock/) القفل العام لـ PPTX. الأنواع التالية من الأقفال مدعومة في Aspose.Slides for Python via Java لـ PPTX:

- [AutoShapeLock](https://reference.aspose.com/slides/ar/python-java/aspose.slides/autoshapelock/) يقفل الأشكال الذاتية.  
- [ConnectorLock](https://reference.aspose.com/slides/ar/python-java/aspose.slides/connectorlock/) يقفل أشكال الموصل.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/ar/python-java/aspose.slides/graphicalobjectlock/) يقفل الكائنات الرسومية.  
- [GroupShapeLock](https://reference.aspose.com/slides/ar/python-java/aspose.slides/groupshapelock/) يقفل الأشكال المجمعة.  
- [PictureFrameLock](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pictureframelock/) يقفل إطارات الصور.  

أي إجراء يُجرى على جميع كائنات الشكل في كائن [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) يُطبق على العرض بالكامل.

## **تطبيق وإزالة الحماية**

تطبيق الحماية يضمن عدم إمكانية تعديل العرض. إنها تقنية مفيدة لحماية محتوى العرض.

### **تطبيق الحماية على أشكال PPTX**

توفر Aspose.Slides for Python via Java الفئة [Shape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/) للعمل مع الأشكال في الشريحة.

كما ذكرنا سابقًا، كل فئة شكل لها فئة قفل شكل مرتبطة للحماية. تركز هذه المقالة على أقفال NoSelect و NoMove و NoResize. تضمن هذه الأقفال عدم إمكانية تحديد الأشكال (من خلال نقرات الفأرة أو طرق اختيار أخرى) وعدم إمكانية تحريكها أو تعديل حجمها.

يعرض مثال الشيفرة التالي تطبيق الحماية على جميع أنواع الأشكال في عرض تقديمي.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

# إنشاء مثال من فئة Presentation التي تمثل ملف PPTX.
presentation = Presentation("Sample.pptx")
try:
    # التنقل عبر جميع الشرائح في العرض.
    for slide in presentation.getSlides():
        # التنقل عبر جميع الأشكال في الشريحة.
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

    # حفظ ملف العرض.
    presentation.save("ProtectedSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **إزالة الحماية**

لإلغاء قفل شكل، عيّن قيمة القفل المطبق إلى `False`. يُظهر مثال الشيفرة التالي كيفية إلغاء قفل الأشكال في عرض مؤمن.

```python
import jpide
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

    # إنشاء مثال من فئة Presentation التي تمثل ملف PPTX.
presentation = Presentation("ProtectedSample.pptx")
try:
    # التنقل عبر جميع الشرائح في العرض.
    for slide in presentation.getSlides():
        # التنقل عبر جميع الأشكال في الشريحة.
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

    # حفظ ملف العرض.
    presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **الخلاصة**

توفر Aspose.Slides عدة خيارات لحماية الأشكال في عرض تقديمي. يمكنك قفل شكل فردي أو التنقل عبر جميع الأشكال في العرض وقفل كلٍ منها لتأمين الملف بالكامل بفعالية. يمكنك إزالة الحماية عن طريق تعيين قيمة القفل إلى `False`.

## **الأسئلة الشائعة**

**هل يمكنني دمج أقفال الأشكال وحماية كلمة المرور في نفس العرض؟**

نعم. تحدّ الأقفال من تحرير الكائنات داخل الملف، بينما تتحكم [حماية بكلمة مرور](/slides/ar/python-java/password-protected-presentation/) في الوصول إلى فتح الملف و/أو حفظ التغييرات. هذه الآليات تكمل بعضها البعض وتعمل معًا.

**هل يمكنني تقييد التحرير على شرائح محددة دون أن يؤثر ذلك على غيرها؟**

نعم. طبق الأقفال على الأشكال في الشرائح المختارة؛ ستبقى الشرائح المتبقية قابلة للتحرير.

**هل تنطبق أقفال الأشكال على الكائنات المجمعة والموصلات؟**

نعم. هناك أنواع أقفال مخصصة مدعومة للمجموعات، والموصلات، والكائنات الرسومية، وأنواع الأشكال الأخرى.