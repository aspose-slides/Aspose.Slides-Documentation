---
title: تقييد تعديل العروض باستخدام أقفال الأشكال في Python
linktitle: تقييد تعديل العروض
type: docs
weight: 70
url: /ar/python-net/applying-protection-to-presentation/
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
- Aspose.Slides
description: "تعلم كيفية قفل وإلغاء قفل الأشكال في عروض PPTX باستخدام Aspose.Slides for Python عبر .NET لتقييد الاختيار والحركة وتغيير الحجم والتجميع."
---
## **الخلفية**

استخدام شائع لـ Aspose.Slides for Python عبر .NET هو إنشاء وتحديث وحفظ عروض PowerPoint (PPTX) كجزء من سير عمل مؤتمت. عندما يتلقى المستخدمون هذه العروض، يمكن أن يساعد تقييد التغييرات على الأشكال في الحفاظ على التخطيط والمcontent المقصود.

تشرح هذه المقالة كيفية تنظيم الأشكال على الشرائح وكيفية تطبيق وإزالة أقفال الأشكال في عرض PPTX. تسمح لك هذه الأقفال بتقييد عمليات التحرير المحددة على كل شكل على حدة.

## **تكوين الشريحة**

تتكون شريحة العرض من مكوّنات مثل الأشكال التلقائية، الجداول، كائنات OLE، الأشكال المجمعة، إطارات الصور، إطارات الفيديو، الموصلات، وعناصر أخرى تُستخدم لإنشاء عرض تقديمي. في Aspose.Slides for Python عبر .NET، يتم تمثيل كل عنصر في الشريحة بكائن يرث من الفئة [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) .

أنواع الأشكال المختلفة تعرض خيارات قفل مختلفة. الفئة [BaseShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/) هي الفئة الأساسية لأقفال الأشكال. يوفر Aspose.Slides for Python عبر .NET الفئات القفل التالية:

- [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/) يقفل الأشكال التلقائية.  
- [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) يقفل أشكال الموصلات.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/) يقفل الكائنات الرسومية.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/) يقفل الأشكال المجمعة.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) يقفل إطارات الصور.  

لتطبيق الأقفال عبر [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)، قم بالتكرار عبر شرائحه واضبط الأقفال المناسبة على كل شكل مدعوم.

## **تطبيق وإزالة الحماية**

تقيد أقفال الأشكال عمليات مثل اختيار، نقل، وتغيير حجم الأشكال. لا تجعل هذه الأقفال العرض التقديمي بالكامل غير قابل للتحرير.

### **تطبيق الحماية على أشكال PPTX**

يوفر Aspose.Slides for Python عبر .NET الفئة [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) للعمل مع الأشكال على شريحة.

يقوم المثال بتعيين [select_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/select_locked/)، [position_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/position_locked/)، و[size_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/size_locked/) إلى `True` للأشكال التلقائية، مع أقفال مماثلة لأشكال المجموعات، الموصلات، وإطارات الصور. تستخدم الموصلات [position_move](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/position_move/) للحركة؛ وتستخدم المجموعات أيضًا [grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) لتقييد التجميع.

يقوم المثال بتحميل عرض PPTX موجود، يتحقق من الأشكال في مجموعة أشكال كل شريحة، ويحفظ نسخة مع تطبيق هذه القيود. تُترك الأشكال خارج الأنواع الأربعة المدارة دون تغيير. لا يتجول الحلقة عبر الأشكال الفرعية داخل مجموعة.

```python
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif isinstance(shape, slides.GroupShape):
                shape.shape_lock.grouping_locked = True
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif isinstance(shape, slides.Connector):
                shape.shape_lock.position_move = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif isinstance(shape, slides.PictureFrame):
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True

    presentation.save("ProtectedSample.pptx", slides.export.SaveFormat.PPTX)
```

### **إزالة الحماية**

لإزالة قفل الشكل، عيّن قيمته إلى `False`. يقوم المثال التالي بتحميل عرض يحتوي على أقفال الأشكال ويزيل قيود الاختيار، الحركة، وتغيير الحجم عبر [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/)، [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/)، [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/)، و[PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/). كما يزيل [GroupShapeLock.grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) ويحفظ نسخة من العرض. تُترك إعدادات الأقفال الأخرى دون تغيير.

```python
import aspose.slides as slides

with slides.Presentation("ProtectedSample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif isinstance(shape, slides.GroupShape):
                shape.shape_lock.grouping_locked = False
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif isinstance(shape, slides.Connector):
                shape.shape_lock.position_move = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif isinstance(shape, slides.PictureFrame):
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False

    presentation.save("RemovedProtectionSample.pptx", slides.export.SaveFormat.PPTX)
```

### **الاستنتاج**

يتيح لك Aspose.Slides for Python عبر .NET تقييد عمليات التحرير المحددة على الأشكال الفردية أو تطبيق نفس القيود عبر الشرائح. اختر الأقفال المدعومة من كل نوع شكل، وعين قيمها إلى `False` عندما تحتاج إلى إزالة تلك القيود.

## **الأسئلة الشائعة**

**هل يمكنني الجمع بين أقفال الأشكال وحماية كلمة المرور في نفس العرض التقديمي؟**

نعم. تُقيد أقفال الأشكال عمليات تحرير محددة، بينما [حماية كلمة المرور](/slides/ar/python-net/password-protected-presentation/) يمكن أن تقيد فتح أو تعديل العرض التقديمي. يمكنك استخدام كلاهما في نفس الملف.

**هل يمكنني تقييد التحرير على شرائح محددة دون التأثير على الأخرين؟**

نعم. طبّق الأقفال فقط على الأشكال في الشرائح المحددة. هذا لا يغيّر إعدادات الأقفال في الشرائح الأخرى.

**كيف يمكنني تطبيق الأقفال على الأشكال الفردية داخل مجموعة؟**

قم بالتكرار عبر مجموعة [الأشكال](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) وتطبيق الأقفال المناسبة على كل شكل فرعي. كرّر ذلك لأي مجموعات متداخلة. الأمثلة أعلاه تعالج فقط مجموعة أشكال الشريحة، لذا لا تقوم بتعيين أقفال على الأعضاء الفرديين في المجموعة.