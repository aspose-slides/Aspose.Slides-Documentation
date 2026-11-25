---
title: تقييد تعديل العروض باستخدام أقفال الأشكال في بايثون
linktitle: تقييد تعديل العروض
type: docs
weight: 60
url: /ar/python-java/applying-protection-to-presentation/
keywords:
- منع التعديلات
- الحماية من التحرير
- قفل الشكل
- قفل الموضع
- قفل الاختيار
- قفل إعادة التحجيم
- قفل التجميع
- PowerPoint
- PPTX
- عرض
- Python
- Java
- Aspose.Slides
description: "تعرف على كيفية قفل وإلغاء قفل الأشكال في عروض PPTX باستخدام Aspose.Slides for Python عبر Java لتقييد الاختيار، والتحريك، وإعادة التحجيم، والتجميع."
---
## **الخلفية**

استخدام شائع لـ Aspose.Slides for Python عبر Java هو إنشاء وتحديث وحفظ عروض PowerPoint (PPTX) كجزء من سير عمل آلي. عندما يتلقى المستخدمون هذه العروض، فإن تقييد التغييرات على الأشكال يمكن أن يساعد في الحفاظ على التخطيط والمحتوى المقصود.

تشرح هذه المقالة كيف يتم تنظيم الأشكال على الشرائح وكيفية تطبيق وإزالة أقفال الأشكال في عرض PPTX. تسمح لك هذه الأقفال بتقييد عمليات التحرير المحددة على الأشكال الفردية.

## **تكوين الشريحة**

تتكون شريحة العرض من مكونات مثل الأشكال التلقائية، الجداول، كائنات OLE، الأشكال المجمعة، إطارات الصور، إطارات الفيديو، الموصلات، وعناصر أخرى تُستخدم لبناء العرض. في Aspose.Slides for Python عبر Java، يُمثَّل كل عنصر على الشريحة ككائن يرث من فئة [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) .

أنواع الأشكال المختلفة تُظهر خيارات قفل مختلفة. فئة [BaseShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/baseshapelock/) هي الفئة الأساسية لأقفال الأشكال. توفر Aspose.Slides for Python عبر Java فئات القفل التالية:

- [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/) يقفل الأشكال التلقائية.  
- [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) يقفل أشكال الموصلات.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobjectlock/) يقفل الكائنات الرسومية.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/) يقفل الأشكال المجمعة.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/) يقفل إطارات الصور.  

لتطبيق الأقفال عبر [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)، قم بالتكرار عبر شرائحه وضبط الأقفال المناسبة على كل شكل مدعوم.

## **تطبيق وإزالة الحماية**

تستخدم محررات العروض المتوافقة أقفال الأشكال لتقييد عمليات التحرير الفردية. تشفير الملفات وحماية الكتابة على مستوى المستند هي إعدادات [إعدادات حماية العرض](/slides/ar/python-java/password-protected-presentation/) منفصلة.

### **تطبيق الحماية على أشكال PPTX**

توفر Aspose.Slides for Python عبر Java فئة [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) للعمل مع الأشكال على الشريحة.

تستدعي العينة [setSelectLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSelectLocked)، [setPositionLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setPositionLocked) و[setSizeLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSizeLocked) بـ `True` للأشكال التلقائية، وتطبيق أقفال مكافئة على الأشكال المجمعة، الموصلات، وإطارات الصور. تستخدم الموصلات [setPositionMove](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/#setPositionMove) للتحريك؛ وتستخدم المجموعات أيضًا [setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) لتقييد التجميع.

تقوم العينة بتحميل عرض PPTX موجود، وتفحص الأشكال في مجموعة الأشكال لكل شريحة، ثم تحفظ نسخة مع تطبيق هذه القيود. تُترك الأشكال خارج الأنواع الأربعة المعالجة دون تغيير. لا تتجول الحلقة في الأشكال الفرعية داخل مجموعة.

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

لإزالة قفل الشكل، اضبط قيمته على `False`. العينة التالية تحمل عرضًا يحتوي على أقفال أشكال وتزيل قيود الاختيار، التحريك، وتغيير الحجم عبر [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/)، [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/)، [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/)، و[PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/). كما تُزيل قيد التجميع بتمرير `False` إلى [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) وتحفظ نسخة من العرض. تُترك إعدادات الأقفال الأخرى دون تغيير.

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

### **الحفاظ على قص الصورة**

ضع صورة باسم `photo.jpg` في دليل العمل. تقوم العينة بقص 12 % من الجانب الأيسر و8 % من الجانب الأيمن، ثم تستدعي [setCropLocked](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/#setCropLocked) بـ `True` للحفاظ على القص.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shapes = presentation.getSlides().get_Item(0).getShapes()

    photo_bytes = Path("photo.jpg").read_bytes()
    photo = presentation.getImages().addImage(photo_bytes)
    
    picture_frame = shapes.addPictureFrame(ShapeType.Rectangle, 20, 30, 270, 160, photo)
    picture_frame.getPictureFormat().setCropLeft(12)
    picture_frame.getPictureFormat().setCropRight(8)

    picture_lock = picture_frame.getPictureFrameLock()
    picture_lock.setAspectRatioLocked(False)
    picture_lock.setCropLocked(True)

    presentation.save("PictureLocked.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

في `PictureLocked.pptx`، يعطل PowerPoint أمر **اقتصاص** عندما تختار الصورة.

### **إبقاء المخطط مجمعًا**

تُجمّع العينة مستطيلًا وسهمًا، ثم تستدعي [setUngroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setUngroupingLocked) بـ `True` لإبقاء الشكلين معًا. لا يزال بإمكانك تحريك المجموعة أو تغيير تعبئة أحد المكوّنات.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shapes = presentation.getSlides().get_Item(0).getShapes()

    group = shapes.addGroupShape()
    group.getShapes().addAutoShape(ShapeType.Rectangle, 100, 70, 90, 50)
    group.getShapes().addAutoShape(ShapeType.RightArrow, 190, 80, 60, 30)
    group.getGroupShapeLock().setUngroupingLocked(True)

    presentation.save("DiagramLocked.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

في `DiagramLocked.pptx`، يعطل PowerPoint أمر **إلغاء التجميع** عندما تختار المخطط بالكامل.

### **الإبلاغ عن أقفال الأشكال الموجودة**

لمراجعة قالب، افتحه واقرأ كائن القفل لكل شكل. تُعيد الطريقة [getNoLocks](https://reference.aspose.com/slides/python-java/aspose.slides/baseshapelock/#getNoLocks) القيمة `True` عندما تُعطَّل جميع العلامات على ذلك الكائن و`False` عندما يُفعَّل أحدها على الأقل. للمجموعة وأطفاله كائنات قفل منفصلة، لذا افحص الأطفال حتى وإن لم تُفعَّل أقفال للمجموعة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, GroupShape, PictureFrame, Presentation


def inspect_shapes(shapes, slide_number, prefix=""):
    for shape in shapes:
        path = f"{prefix}{shape.getName()}"
        label = f"Slide {slide_number} | {path} | {shape.getClass().getSimpleName()}"
        flags = []

        if isinstance(shape, GroupShape):
            shape_lock = shape.getGroupShapeLock()
            if shape_lock.getUngroupingLocked():
                flags.append("UngroupingLocked")
        elif isinstance(shape, PictureFrame):
            shape_lock = shape.getPictureFrameLock()
            if shape_lock.getCropLocked():
                flags.append("CropLocked")
        elif isinstance(shape, AutoShape):
            shape_lock = shape.getAutoShapeLock()
        else:
            print(f"{label} | Uninspected")
            continue

        if shape_lock.getPositionLocked():
            flags.append("PositionLocked")
        if not shape_lock.getNoLocks():
            restrictions = ", ".join(flags) if flags else "Active flag not identified"
            print(f"{label} | {restrictions}")

        if isinstance(shape, GroupShape):
            inspect_shapes(shape.getShapes(), slide_number, f"{path}/")


presentation = Presentation("Sample.pptx")
try:
    for slide in presentation.getSlides():
        inspect_shapes(slide.getShapes(), slide.getSlideNumber())
finally:
    presentation.dispose()
```

تتحقق هذه العينة من التحريك للأشكال التلقائية، إطارات الصور، والمجموعات. كما تتحقق من القص للصور وإلغاء التجميع للمجموعات. تُدرِج التقارير العلامات المفعَّلة التي تتعرف عليها وتضع علامة على أنواع الأشكال التي لا تُفحص.

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

افترض أن الشريحة 1 من `Sample.pptx` تحتوي على مجموعة باسم `Layout` مقفلة إلغاء التجميع، وصورة باسم `Photo` داخلها مقفلة القص، ومستطيل غير مقفل باسم `Free`. يتخطى التقرير `Free` ويطبع السطرين التاليين:

{{...}}

يقراً التقرير علامات تحرير المستوى الشكلية المخزونة دون تغييرها أو حفظ العرض. حماية الكتابة على مستوى المستند هي إعداد منفصل، وتطبيق كل علامة يعتمد على المحرر.

## **الخلاصة**

تمكّنك Aspose.Slides for Python عبر Java من تقييد عمليات التحرير المحددة على الأشكال الفردية أو تطبيق نفس القيود عبر الشرائح. اختر الأقفال المدعومة من كل نوع شكل، واضبط قيمها على `False` عندما تحتاج إلى إزالة تلك القيود.

## **الأسئلة الشائعة**

**هل يمكنني دمج أقفال الأشكال وحماية كلمة المرور في نفس العرض؟**

نعم. أقفال الأشكال تُقيد عمليات التحرير المحددة، بينما [password protection](/slides/ar/python-java/password-protected-presentation/) يمكنها تقييد فتح أو تعديل العرض. يمكنك استخدام كليهما في نفس الملف.

**هل يمكنني تقييد التحرير على شرائح محددة دون التأثير على الأخريات؟**

نعم. طبّق الأقفال فقط على الأشكال في الشرائح المختارة. هذا لا يغيّر إعدادات الأقفال في الشرائح الأخرى.

**كيف يمكنني تطبيق أقفال على الأشكال الفردية داخل مجموعة؟**

قم بالتكرار عبر المجموعة التي تُعيدها طريقة [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes) وتطبيق الأقفال المناسبة على كل شكل فرعي. كرّر ذلك لأي مجموعات متداخلة، متبعًا طريقة الاستعراض في مثال التقرير.