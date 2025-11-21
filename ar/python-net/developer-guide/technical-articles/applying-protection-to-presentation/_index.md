---
title: منع تحرير العروض التقديمية باستخدام أقفال الأشكال في بايثون
linktitle: منع تحرير العروض التقديمية
type: docs
weight: 70
url: /ar/python-net/applying-protection-to-presentation/
keywords:
- منع التعديلات
- حماية من التحرير
- قفل الشكل
- قفل الموقع
- قفل الاختيار
- قفل الحجم
- قفل التجميع
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "اكتشف كيف تقوم Aspose.Slides for Python عبر .NET بقفل أو إلغاء قفل الأشكال في ملفات PPT و PPTX و ODP، مما يحافظ على أمان العروض التقديمية مع السماح بتحرير مُتحكم به وتسليم أسرع."
---

## **الخلفية**

استخدام شائع لـ Aspose.Slides هو إنشاء وتحديث وحفظ عروض Microsoft PowerPoint (PPTX) كجزء من سير عمل آلي. يحصل مستخدمو التطبيقات التي تستخدم Aspose.Slides بهذه الطريقة على الوصول إلى العروض المُنشأة، لذا حماية هذه العروض من التحرير هي مسألة شائعة. من المهم أن تحتفظ العروض التي تم إنشاؤها تلقائيًا بتنسيقها ومحتواها الأصلي.

تشرح هذه المقالة كيفية هيكلة العروض والشرائح وكيف يمكن لـ Aspose.Slides for Python تطبيق الحماية على عرض ثم إزالتها لاحقًا. وهي توفر للمطورين طريقة للتحكم في كيفية استخدام العروض التي تُنشئها تطبيقاتهم.

## **تكوين الشريحة**

تتكون شريحة العرض من مكونات مثل الأشكال التلقائية، الجداول، كائنات OLE، الأشكال المجمعة، إطارات الصور، إطارات الفيديو، الموصلات، وعناصر أخرى تُستخدم لبناء عرض. في Aspose.Slides for Python، يُمثَّل كل عنصر على الشريحة بواسطة كائن يُورث من الفئة [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) .

هيكل PPTX معقد، لذا على عكس PPT حيث يمكن استخدام قفل عام لجميع أنواع الأشكال، تتطلب أنواع الأشكال المختلفة أقفالًا مختلفة. الفئة [BaseShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/) هي الفئة العامة للقفل في PPTX. الأنواع التالية من الأقفال مدعومة في Aspose.Slides for Python لـ PPTX:

- [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/) يقفل الأشكال التلقائية.  
- [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) يقفل الأشكال الموصل.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/) يقفل الكائنات الرسومية.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/) يقفل الأشكال المجمعة.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) يقفل إطارات الصور.  

أي فعل يُجرى على جميع كائنات الشكل في كائن [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) يُطبق على كامل العرض.

## **تطبيق وإزالة الحماية**

تطبيق الحماية يضمن عدم إمكانية تحرير العرض. وهي تقنية مفيدة لحماية محتوى العرض.

### **تطبيق الحماية على أشكال PPTX**

توفر Aspose.Slides for Python الفئة [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) للعمل مع الأشكال على الشريحة.

كما ذكرنا سابقًا، كل فئة شكل لديها فئة قفل شكل مرتبطة للحماية. تركز هذه المقالة على أقفال NoSelect و NoMove و NoResize. هذه الأقفال تضمن عدم إمكانية تحديد الأشكال (من خلال نقرات الفأرة أو طرق اختيار أخرى) وعدم إمكانية نقلها أو تغيير حجمها.

عينة الشيفرة التالية تطبق الحماية على جميع أنواع الأشكال في عرض.
```py
import aspose.slides as slides

# إنشاء كائن Presentation الذي يمثل ملف PPTX.
with slides.Presentation("Sample.pptx") as presentation:
    # استعراض جميع الشرائح في العرض.
    for slide in presentation.slides:
        # استعراض جميع الأشكال في الشريحة.
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif type(shape) is slides.GroupShape:
                shape.shape_lock.grouping_locked = True
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif type(shape) is slides.Connector:
                shape.shape_lock.position_move = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif type(shape) is slides.PictureFrame:
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
    # حفظ ملف العرض.
    presentation.save("ProtectedSample.pptx", slides.export.SaveFormat.PPTX)
```


### **إزالة الحماية**

لإلغاء قفل شكل، اضبط قيمة القفل المطبق إلى `False`. تُظهر عينة الشيفرة التالية كيفية إلغاء قفل الأشكال في عرض مقفل.
```py
import aspose.slides as slides

# إنشاء كائن Presentation الذي يمثل ملف PPTX.
with slides.Presentation("ProtectedSample.pptx") as presentation:
    # استعراض جميع الشرائح في العرض.
    for slide in presentation.slides:
        # استعراض جميع الأشكال في الشريحة.
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif type(shape) is slides.GroupShape:
                shape.shape_lock.grouping_locked = False
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif type(shape) is slides.Connector:
                shape.shape_lock.position_move = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif type(shape) is slides.PictureFrame:
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
    # حفظ ملف العرض.
    presentation.save("RemovedProtectionSample.pptx", slides.export.SaveFormat.PPTX)
```


### **الخاتمة**

توفر Aspose.Slides عدة خيارات لحماية الأشكال في عرض. يمكنك قفل شكل فردي أو التجول عبر جميع الأشكال في عرض وقفل كل واحد لتأمين الملف بالكامل بفعالية. يمكنك إزالة الحماية بضبط قيمة القفل إلى `False`.

## **الأسئلة المتكررة**

**هل يمكنني الجمع بين أقفال الشكل وحماية كلمة المرور في نفس العرض؟**

نعم. الأقفال تحد من تحرير الكائنات داخل الملف، بينما [password protection](/slides/ar/python-net/password-protected-presentation/) يتحكم في الوصول إلى فتح وحفظ التغييرات. هذه الآليات تكمل بعضها وتعمل معًا.

**هل يمكنني تقييد التحرير على شرائح معينة دون التأثير على الأخريات؟**

نعم. طبق الأقفال على الأشكال في الشرائح المختارة؛ الشرائح المتبقية ستظل قابلة للتحرير.

**هل تنطبق أقفال الشكل على الكائنات المجمعة والموصلات؟**

نعم. يتم دعم أنواع أقفال مخصصة للمجموعات، الموصلات، الكائنات الرسومية، وغيرها من أنواع الأشكال.