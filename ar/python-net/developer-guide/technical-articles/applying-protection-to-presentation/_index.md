---
title: تقييد تعديل العرض باستخدام أقفال الأشكال في بايثون
linktitle: تقييد تعديل العرض
type: docs
weight: 70
url: /ar/python-net/applying-protection-to-presentation/
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
- Python
- Aspose.Slides
description: "تعلم كيفية قفل وإلغاء قفل الأشكال في عروض PPTX باستخدام Aspose.Slides for Python عبر .NET لتقييد الاختيار، الحركة، تغيير الحجم، والتجميع."
---
## **الخلفية**

استخدام شائع لـ Aspose.Slides for Python عبر .NET هو إنشاء وتحديث وحفظ عروض PowerPoint (PPTX) كجزء من سير عمل آلي. عندما يتلقى المستخدمون هذه العروض، يمكن أن يساعد تقييد التغييرات على الأشكال في الحفاظ على التخطيط والمحتوى المقصود.

تشرح هذه المقالة كيفية تنظيم الأشكال على الشرائح وكيفية تطبيق وإزالة أقفال الأشكال في عرض PPTX. تتيح لك هذه الأقفال تقييد عمليات تحرير معينة على الأشكال الفردية.

## **تركيب الشريحة**

تتكون شريحة العرض من مكونات مثل الأشكال التلقائية، الجداول، كائنات OLE، الأشكال المجمعة، إطارات الصور، إطارات الفيديو، الموصلات، وعناصر أخرى تُستخدم لبناء عرض تقديمي. في Aspose.Slides for Python عبر .NET، يُمثَّل كل عنصر في الشريحة ككائن يُورث من فئة [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) .

تُظهر أنواع الأشكال المختلفة خيارات قفل مختلفة. فئة [BaseShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/) هي الفئة الأساسية لأقفال الأشكال. توفر Aspose.Slides for Python عبر .NET الفئات القفلية التالية:

- [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/) تقفل الأشكال التلقائية.  
- [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) تقفل أشكال الموصل.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/) تقفل الكائنات الرسومية.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/) تقفل الأشكال المجمعة.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) تقفل إطارات الصور.  

لتطبيق الأقفال عبر [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)، قم بالتكرار عبر شرائحه وضع الأقفال المناسبة على كل شكل مدعوم.

## **تطبيق وإزالة الحماية**

تستخدم محررات العروض المتوافقة أقفال الأشكال لتقييد عمليات التحرير الفردية. تشفير الملفات وحماية الكتابة على مستوى المستند هي إعدادات [إعدادات حماية العرض](/slides/ar/python-net/password-protected-presentation/) منفصلة.

### **تطبيق الحماية على أشكال PPTX**

توفر Aspose.Slides for Python عبر .NET فئة [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) للعمل مع الأشكال على الشريحة.

تُعيّن المثال الخصائص [select_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/select_locked/)، [position_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/position_locked/)، و[size_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/size_locked/) إلى `True` للأشكال التلقائية، مع أقفال مكافئة للأشكال المجمعة، الموصلات، وإطارات الصور. تستخدم الموصلات [position_move](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/position_move/) للحركة؛ وتستخدم المجموعات أيضًا [grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) لتقييد التجميع.

يقوم المثال بتحميل عرض PPTX موجود، يتحقق من الأشكال في مجموعة الأشكال لكل شريحة، ويحفظ نسخة مع تطبيق هذه القيود. تُترك الأشكال خارج الأنواع الأربعة المعالجة دون تعديل. لا يتجول الحلقة عبر الأشكال الفرعية داخل مجموعة.

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

لإزالة قفل الشكل، عيّن قيمته إلى `False`. يحمل المثال التالي عرضًا يحتوي على أقفال الأشكال ويزيل قيود الاختيار، الحركة، وتغيير الحجم من خلال [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/)، [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/)، [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/)، و[PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/). كما يزيل [GroupShapeLock.grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) ويحفظ نسخة من العرض. تُترك إعدادات الأقفال الأخرى دون تغيير.

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

### **الحفاظ على قص الصورة**

ضع صورة باسم `photo.jpg` في دليل العمل. يقص المثال 12% من اليسار و8% من اليمين، ثم يعيّن [crop_locked](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/crop_locked/) على إطار الصورة للحفاظ على القص.

```python
from pathlib import Path

import aspose.slides as slides

with slides.Presentation() as presentation:
    shapes = presentation.slides[0].shapes

    photo_bytes = Path("photo.jpg").read_bytes()
    photo = presentation.images.add_image(photo_bytes)

    picture_frame = shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 30, 270, 160, photo)
    picture_frame.picture_format.crop_left = 12
    picture_frame.picture_format.crop_right = 8
    picture_frame.shape_lock.aspect_ratio_locked = False
    picture_frame.shape_lock.crop_locked = True

    presentation.save("PictureLocked.pptx", slides.export.SaveFormat.PPTX)
```

`PictureLocked.pptx` يخزن قفل القص كـ `True`. في PowerPoint، يتم تعطيل أمر **Crop** عندما تكون الصورة مختارة.

### **إبقاء المخطط مجموعة**

يقوم المثال بتجميع مستطيل وسهم، ثم يعيّن [ungrouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/ungrouping_locked/) على المجموعة نفسها لإبقاء مكونات المخطط معًا. تظل التعديلات الأخرى، مثل تحريك المجموعة أو تغيير تعبئة مكون، متاحة.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shapes = presentation.slides[0].shapes
    
    group_shape = shapes.add_group_shape()
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 70, 90, 50)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RIGHT_ARROW, 190, 80, 60, 30)
    group_shape.shape_lock.ungrouping_locked = True

    presentation.save("DiagramLocked.pptx", slides.export.SaveFormat.PPTX)
```

`DiagramLocked.pptx` يخزن قفل فك التجميع كـ `True`. في PowerPoint، يتم تعطيل أمر **Ungroup** عندما يتم تحديد المخطط بالكامل.

### **الخلاصة**

تتيح لك Aspose.Slides for Python عبر .NET تقييد عمليات تحرير معينة على الأشكال الفردية أو تطبيق نفس القيود عبر الشرائح. اختر الأقفال المدعومة من كل نوع شكل، وعِد قيمها إلى `False` عندما تحتاج إلى إزالة تلك القيود.

## **الأسئلة الشائعة**

**هل يمكنني الجمع بين أقفال الأشكال وحماية كلمة المرور في نفس العرض؟**

نعم. أقفال الأشكال تُقيد عمليات تحرير معينة، بينما [حماية كلمة المرور](/slides/ar/python-net/password-protected-presentation/) يمكن أن تقيد فتح أو تعديل العرض. يمكنك استخدام كلاهما في نفس الملف.

**هل يمكنني تقييد التحرير على شرائح محددة دون التأثير على الأخرى؟**

نعم. قم بتطبيق الأقفال فقط على الأشكال في الشرائح المحددة. هذا لا يغيّر إعدادات الأقفال في الشرائح الأخرى.

**كيف يمكنني تطبيق الأقفال على الأشكال الفردية داخل مجموعة؟**

قم بالتكرار عبر مجموعة [الأشكال](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) الخاصة بالمجموعة وطبق الأقفال المناسبة على كل شكل فرعي. كرّر ذلك لأي مجموعات متداخلة. الأمثلة أعلاه تعالج مجموعة الأشكال الخاصة بالشريحة فقط، لذا لا تقوم بتعيين أقفال على أعضاء المجموعة الفرديين.