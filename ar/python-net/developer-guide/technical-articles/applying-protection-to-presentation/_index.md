---
title: قصر تحرير العروض التقديمية بأقفال الأشكال في بايثون
linktitle: قصر تحرير العروض
type: docs
weight: 70
url: /ar/python-net/applying-protection-to-presentation/
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
- العرض التقديمي
- Python
- Aspose.Slides
description: "تعرف على كيفية قفل وإلغاء قفل الأشكال في عروض PPTX باستخدام Aspose.Slides للبايثون عبر .NET لتقييد الاختيار والحركة وتغيير الحجم والتجميع."
---
## **الخلفية**

استخدام شائع لـ Aspose.Slides for Python via .NET هو إنشاء وتحديث وحفظ عروض PowerPoint (PPTX) كجزء من سير عمل مؤتمت. عندما يتلقى المستخدمون هذه العروض، يمكن أن يساعد تقييد التغييرات على الأشكال في الحفاظ على التخطيط والمحتوى المقصود.

توضح هذه المقالة كيف يتم تنظيم الأشكال على الشرائح وكيفية تطبيق وإزالة أقفال الأشكال في عرض PPTX. تتيح لك هذه الأقفال تقييد عمليات تحرير محددة على الأشكال الفردية.

## **تكوين الشريحة**

تتكون شريحة العرض من مكونات مثل الأشكال التلقائية، الجداول، كائنات OLE، الأشكال المجمعة، إطارات الصور، إطارات الفيديو، الموصلات، وعناصر أخرى تُستخدم لإنشاء عرض تقديمي. في Aspose.Slides for Python via .NET، يُمثَّل كل عنصر على الشريحة ككائن يرث من الفئة [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) .

أنواع الأشكال المختلفة تكشف عن خيارات قفل مختلفة. الفئة [BaseShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/) هي الفئة الأساسية لأقفال الأشكال. توفر Aspose.Slides for Python via .NET الفئات القفلية التالية:

- [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/) يقفل الأشكال التلقائية.  
- [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) يقفل أشكال الموصلات.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/) يقفل الكائنات الرسومية.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/) يقفل الأشكال المجمعة.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) يقفل إطارات الصور.  

لتطبيق أقفال عبر [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)، قم بالتكرار عبر الشرائح واضبط الأقفال المناسبة على كل شكل مدعوم.

## **تطبيق وإزالة الحماية**

تستخدم محررات العروض التقديمية المتوافقة أقفال الأشكال لتقييد عمليات التحرير الفردية. التشفير وحماية الكتابة على مستوى المستند هي إعدادات [presentation protection settings](/slides/ar/python-net/password-protected-presentation/) منفصلة.

### **تطبيق الحماية على أشكال PPTX**

توفر Aspose.Slides for Python via .NET الفئة [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) للعمل مع الأ أشكال على الشريحة.

يضبط المثال [select_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/select_locked/), [position_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/position_locked/), و [size_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/size_locked/) على `True` للأشكال التلقائية، مع أقفال مكافئة لأشكال المجموعات، الموصلات، وإطارات الصور. تستخدم الموصلات [position_move](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/position_move/) للتحريك؛ وتستخدم المجموعات أيضًا [grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) لتقييد التجميع.

يقوم المثال بتحميل عرض PPTX موجود، يفحص الأشكال في مجموعة الأشكال لكل شريحة، ويحفظ نسخة مع تطبيق هذه القيود. تُترك الأشكال خارج الأنواع الأربعة المتعامل معها دون تعديل. لا يتجول الحلقة عبر الأشكال الفرعية داخل مجموعة.

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

لإزالة قفل الشكل، اضبط قيمته على `False`. يقوم المثال التالي بتحميل عرض يحتوي على أقفال الأشكال ويزيل قيود الاختيار، التحريك، وتغيير الحجم عبر [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/), و [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/). كما يزيل [GroupShapeLock.grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) ويحفظ نسخة من العرض. تُترك إعدادات الأقفال الأخرى دون تغيير.

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

ضع صورة باسم `photo.jpg` في دليل العمل. يقوم المثال بقص 12% من اليسار و8% من اليمين، ثم يضبط [crop_locked](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/crop_locked/) على إطار الصورة. هذا العلم يقيّد قصًا إضافيًا ويحافظ على القص الحالي.

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

`PictureLocked.pptx` يخزن قفل القص كـ `True`. في PowerPoint، يتم تعطيل أمر **Crop** عندما تكون الصورة محددة.

### **الحفاظ على تجميع المخطط**

يقوم المثال بتجميع مستطيل وسهم، ثم يضبط [ungrouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/ungrouping_locked/) على المجموعة نفسها للحفاظ على مكوّنات المخطط معًا. تظل التعديلات الأخرى، مثل تحريك المجموعة أو تغيير تعبئة مكوّن، متاحة.

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

### **الإبلاغ عن أقفال الأشكال الموجودة**

لمراجعة قالب، افتحه واقرأ كائن القفل لكل شكل. [no_locks](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/no_locks/) يكون `True` عندما تكون جميع العلامات على ذلك الكائن معطلة و`False` عندما يكون على الأقل واحدة مفعلة. للمجموعة وأطفالها كائنات قفل منفصلة، لذا افحص الأطفال حتى عندما لا تحتوي المجموعة على أقفال.

يفحص هذا المثال التحريك للأشكال التلقائية، إطارات الصور، والمجموعات، والقص للصور، وفك التجميع للمجموعات. يبلغ عن العلامات التي يتعرف عليها ويحدد أنواع الأشكال التي لا يفحصها.

```python
import aspose.slides as slides


def inspect_shapes(shapes, slide_number, prefix=""):
    for shape in shapes:
        path = prefix + shape.name
        label = f"Slide {slide_number} | {path} | {type(shape).__name__}"
        if not isinstance(shape, (slides.GroupShape, slides.PictureFrame, slides.AutoShape)):
            print(f"{label} | Uninspected")
            continue

        shape_lock = shape.shape_lock
        if not shape_lock.no_locks:
            flags = []
            if isinstance(shape, slides.GroupShape) and shape_lock.ungrouping_locked:
                flags.append("ungrouping_locked")
            if isinstance(shape, slides.PictureFrame) and shape_lock.crop_locked:
                flags.append("crop_locked")
            if shape_lock.position_locked:
                flags.append("position_locked")
            restrictions = ", ".join(flags) if flags else "Active flag not identified"
            print(f"{label} | {restrictions}")

        if isinstance(shape, slides.GroupShape):
            inspect_shapes(shape.shapes, slide_number, path + "/")


with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        inspect_shapes(slide.shapes, slide.slide_number)
```

لنفترض أن الشريحة 1 من `Sample.pptx` تحتوي على مجموعة باسم `Layout` مع قفل فك التجميع، وصورة باسم `Photo` داخلها مع قفل القص، ومستطيل غير مقفل باسم `Free`. يتخطى التقرير `Free` ويطبع السطرين التاليين:

```text
Slide 1 | Layout | GroupShape | ungrouping_locked
Slide 1 | Layout/Photo | PictureFrame | crop_locked
```

يقرأ التقرير العلامات المخزنة على مستوى الشكل دون تغييرها أو حفظ العرض. حماية الكتابة على مستوى المستند هي إعداد منفصل، ويعتمد تطبيق كل علامة على المحرر.

### **الخلاصة**

يسمح لك Aspose.Slides for Python via .NET بتقييد عمليات تحرير محددة على الأشكال الفردية أو تطبيق نفس القيود عبر الشرائح. اختر الأقفال المدعومة من كل نوع شكل، واضبط قيمها على `False` عندما تحتاج إلى إزالة تلك القيود.

## **الأسئلة الشائعة**

**هل يمكنني دمج أقفال الأشكال والحماية بكلمة مرور في نفس العرض التقديمي؟**

نعم. تقيد أقفال الأشكال عمليات تحرير معينة، بينما يمكن لـ [password protection](/slides/ar/python-net/password-protected-presentation/) تقييد فتح أو تعديل العرض التقديمي. يمكنك استخدام كلاهما في نفس الملف.

**هل يمكنني تقييد التحرير على شرائح محددة دون التأثير على الأخريات؟**

نعم. طبّق الأقفال فقط على الأشكال في الشرائح المختارة. هذا لا يغيّر إعدادات القفل على الشرائح الأخرى.

**كيف يمكنني تطبيق أقفال على الأشكال الفردية داخل مجموعة؟**

قم بالتكرار عبر مجموعة [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) الخاصة بالمجموعة وطبق الأقفال المناسبة على كل شكل فرعي. كرّر ذلك لأي مجموعات متداخلة، متبعًا طريقة الاستعراض في مثال التقرير.