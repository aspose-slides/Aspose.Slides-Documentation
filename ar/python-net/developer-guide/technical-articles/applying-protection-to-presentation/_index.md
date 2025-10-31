---
title: منع تعديل العروض التقديمية باستخدام أقفال الأشكال في بايثون
linktitle: منع تعديل العرض التقديمي
type: docs
weight: 70
url: /ar/python-net/applying-protection-to-presentation/
keywords:
- منع التعديلات
- حماية من التحرير
- قفل الشكل
- قفل الموضع
- قفل الاختيار
- قفل الحجم
- قفل التجميع
- باوربوينت
- أوپن دوكومنت
- عرض تقديمي
- بايثون
- Aspose.Slides
description: "اكتشف كيف تقوم Aspose.Slides لبايثون عبر .NET بقفل أو إلغاء قفل الأشكال في ملفات PPT و PPTX و ODP، مما يؤمن العروض التقديمية مع السماح بتعديلات متحكم بها وتسليم أسرع."
---

## **الخلفية**

استخدام شائع لـ Aspose.Slides هو إنشاء وتحديث وحفظ عروض Microsoft PowerPoint (PPTX) كجزء من سير عمل آلي. يحصل مستخدمو التطبيقات التي تستخدم Aspose.Slides بهذه الطريقة على العروض التي تم توليدها، لذا فإن حمايتها من التعديل يُعد مصدر قلق شائع. من المهم أن تحتفظ العروض التي تُنشئ آليًا بتنسيقها ومحتواها الأصلي.

تشرح هذه المقالة كيف يتم تنظيم العروض والشرائح وكيف يمكن لـ Aspose.Slides لبايثون تطبيق الحماية على عرض تقديمي وإزالتها لاحقًا. تُوفر للمطورين طريقة للتحكم في كيفية استخدام العروض التي تُنشئها تطبيقاتهم.

## **تركيب الشريحة**

تتكون شريحة العرض من مكوّنات مثل الأشكال التلقائية، الجداول، كائنات OLE، الأشكال المجمّعة، إطارات الصور، إطارات الفيديو، الموصلات، وعناصر أخرى تُستخدم لبناء العرض. في Aspose.Slides لبايثون، يُمثَّل كل عنصر على الشريحة ككائن يرث من فئة [الشكل](https://reference.aspose.com/slides/python-net/aspose.slides/shape/).

بنية PPTX معقّدة، لذا على عكس PPT حيث يمكن استخدام قفل عام لجميع أنواع الأشكال، تحتاج أنواع الأشكال المختلفة إلى أقفال مختلفة. فئة [BaseShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/) هي الفئة العامة للأقفال في PPTX. الأنواع التالية من الأقفال مدعومة في Aspose.Slides لبايثون لـ PPTX:

- [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/) يقفل الأشكال التلقائية.  
- [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) يقفل أشكال الموصلات.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/) يقفل الكائنات الرسومية.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/) يقفل الأشكال المجمّعة.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) يقفل إطارات الصور.  

أي إجراء يُجرى على جميع كائنات الشكل في كائن [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) يُطبق على العرض بالكامل.

## **تطبيق وإزالة الحماية**

تطبيق الحماية يضمن عدم إمكانية تعديل العرض. إنها تقنية مفيدة لحماية محتوى العرض.

### **تطبيق الحماية على أشكال PPTX**

توفر Aspose.Slides لبايثون فئة [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) للعمل مع الأشكال على الشريحة.

كما ذُكر سابقًا، كل فئة شكل لها فئة قفل شكل مرتبطة بها للحماية. تركز هذه المقالة على أقفال NoSelect و NoMove و NoResize. تضمن هذه الأقفال عدم إمكانية اختيار الأشكال (من خلال النقر بالفأرة أو طرق اختيار أخرى) وعدم إمكانية تحريكها أو تغيير حجمها.

العينة البرمجية التالية تطبق الحماية على جميع أنواع الأشكال في عرض تقديمي.

```py
import aspose.slides as slides

# إنشاء كائن من فئة Presentation الذي يمثل ملف PPTX.
with slides.Presentation("Sample.pptx") as presentation:
    # التجوال عبر جميع الشرائح في العرض التقديمي.
    for slide in presentation.slides:
        # التجوال عبر جميع الأشكال في الشريحة.
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
    # حفظ ملف العرض التقديمي.
    presentation.save("ProtectedSample.pptx", slides.export.SaveFormat.PPTX)
```

### **إزالة الحماية**

لإلغاء قفل شكل، اضبط قيمة القفل المُطبّق إلى `False`. تُظهر العينة البرمجية التالية كيفية إلغاء قفل الأشكال في عرض مؤمّن.

```py
import aspose.slides as slides

# إنشاء كائن من فئة Presentation الذي يمثل ملف PPTX.
with slides.Presentation("ProtectedSample.pptx") as presentation:
    # التجوال عبر جميع الشرائح في العرض التقديمي.
    for slide in presentation.slides:
        # التجوال عبر جميع الأشكال في الشريحة.
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
    # حفظ ملف العرض التقديمي.
    presentation.save("RemovedProtectionSample.pptx", slides.export.SaveFormat.PPTX)
```

### **الخلاصة**

توفر Aspose.Slides عدة خيارات لحماية الأشكال في العرض. يمكنك قفل شكل فردي أو التكرار عبر جميع الأشكال في العرض وقفل كل منها لتأمين الملف بالكامل بفعالية. يمكنك إزالة الحماية بضبط قيمة القفل إلى `False`.

## **الأسئلة المتكررة**

**هل يمكنني دمج أقفال الأشكال وحماية كلمة المرور في نفس العرض؟**

نعم. تقيد الأقفال تعديل الكائنات داخل الملف، بينما تتحكم [حماية كلمة المرور](/slides/ar/python-net/password-protected-presentation/) في إمكانية فتح الملف و/أو حفظ التغييرات. تكمل هذه الآليات بعضها البعض وتعمل معًا.

**هل يمكنني تقييد التعديل على شرائح معينة دون التأثير على غيرها؟**

نعم. طبّق الأقفال على الأشكال في الشرائح المختارة؛ ستظل الشرائح المتبقية قابلة للتحرير.

**هل تنطبق أقفال الأشكال على الكائنات المجمّعة والموصلات؟**

نعم. تُدعم أنواع الأقفال المخصصة للمجموعات، والموصلات، والكائنات الرسومية، وأنواع الأشكال الأخرى.