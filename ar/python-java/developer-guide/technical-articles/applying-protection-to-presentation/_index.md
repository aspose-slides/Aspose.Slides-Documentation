---
title: تقييد تحرير العروض باستخدام أقفال الأشكال في بايثون
linktitle: تقييد تحرير العرض
type: docs
weight: 60
url: /ar/python-java/applying-protection-to-presentation/
keywords:
- منع التحرير
- الحماية من التعديل
- قفل الشكل
- قفل الموقع
- قفل الاختيار
- قفل تغيير الحجم
- قفل التجميع
- PowerPoint
- PPTX
- العرض التقديمي
- Python
- Java
- Aspose.Slides
description: "تعلم كيفية قفل وإلغاء قفل الأشكال في عروض PPTX باستخدام Aspose.Slides for Python via Java لتقييد الاختيار والحركة وتغيير الحجم والتجميع."
---
## **الخلفية**

استخدام شائع لـ Aspose.Slides for Python via Java هو إنشاء وتحديث وحفظ عروض PowerPoint (PPTX) كجزء من تدفق عمل آلي. عندما يتلقى المستخدمون هذه العروض، يمكن أن يساعد تقييد التغييرات على الأشكال في الحفاظ على التخطيط والمحتوى المقصود.

تشرح هذه المقالة كيفية تنظيم الأشكال على الشرائح وكيفية تطبيق وإزالة أقفال الأشكال في عرض PPTX. تتيح لك هذه الأقفال تقييد عمليات التحرير المحددة على الأشكال الفردية.

## **تكوين شريحة**

تتكون شريحة العرض من مكونات مثل الأشكال التلقائية (autoshapes) والجداول وكائنات OLE والأشكال المجمعة وإطارات الصور وإطارات الفيديو والموصلات وغيرها من العناصر المستخدمة في بناء عرض تقديمي. في Aspose.Slides for Python via Java، يتم تمثيل كل عنصر على الشريحة ككائن يرث من الفئة [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) .

أنواع الأشكال المختلفة تكشف عن خيارات أقفال مختلفة. الفئة [BaseShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/baseshapelock/) هي الفئة الأساسية لأقفال الأشكال. يوفر Aspose.Slides for Python via Java الفئات القفلية التالية:

- [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/) يقفل الأشكال التلقائية.  
- [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) يقفل أشكال الموصل.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobjectlock/) يقفل الكائنات الرسومية.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/) يقفل الأشكال المجمعة.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/) يقفل إطارات الصور.  

لتطبيق الأقفال عبر الـ [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)، قم بالتجول عبر الشرائح الخاصة به واضبط الأقفال المناسبة على كل شكل مدعوم.

## **تطبيق وإزالة الحماية**

تستخدم محررات العروض التقديمية المتوافقة أقفال الأشكال لتقييد عمليات التحرير الفردية. تشفير الملف وحماية الكتابة على مستوى المستند هي إعدادات [إعدادات حماية العرض](/slides/ar/python-java/password-protected-presentation/) منفصلة.

### **تطبيق الحماية على أشكال PPTX**

يوفر Aspose.Slides for Python via Java الفئة [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) للعمل مع الأشكال على الشريحة.

تستدعي العينة الدوال [setSelectLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSelectLocked)، [setPositionLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setPositionLocked)، و[setSizeLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSizeLocked) بقيمة `True` للأشكال التلقائية، وبأقفال مكافئة لأشكال المجموعات والموصلات وإطارات الصور. تستخدم الموصلات الدالة [setPositionMove](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/#setPositionMove) للحركة؛ وتستخدم المجموعات الدالة [setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) لتقييد التجميع.

تقوم العينة بتحميل عرض PPTX موجود، وتفحص الأشكال في مجموعة الأشكال الخاصة بكل شريحة، وتحفظ نسخة مع تطبيق هذه القيود. تبقى الأشكال خارج الأنواع الأربعة المعالجة دون تغيير. لا يتجول الحلقة عبر الأشكال الفرعية داخل مجموعة.

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

لإزالة قفل الشكل، اضبط قيمته على `False`. تقوم العينة التالية بتحميل عرض يحتوي على أقفال الأشكال وتزيل قيود الاختيار والحركة وتغيير الحجم عبر [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/)، [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/)، [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/)، و[PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/). كما أنها تزيل قيد التجميع بتمرير `False` إلى [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) وتحفظ نسخة من العرض. تبقى إعدادات الأقفال الأخرى دون تغيير.

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

### **حفظ قص الصورة**

ضع صورة باسم `photo.jpg` في دليل العمل. تقوم العينة بقص 12٪ من اليسار و8٪ من اليمين، ثم تستدعي الدالة [setCropLocked](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/#setCropLocked) بقيمة `True` لحفظ القص.

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

في `PictureLocked.pptx`، يقوم PowerPoint بتعطيل أمر **Crop** عند اختيار الصورة.

### **الحفاظ على تجميع المخطط**

تقوم العينة بتجميع مستطيل وسهم، ثم تستدعي الدالة [setUngroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setUngroupingLocked) بقيمة `True` للحفاظ على الشكلين معًا. لا يزال بإمكانك تحريك المجموعة أو تغيير تعبئة أحد المكوّنات.

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

في `DiagramLocked.pptx`، يقوم PowerPoint بتعطيل أمر **Ungroup** عند اختيار المخطط بالكامل.

### **الخاتمة**

يوفر Aspose.Slides for Python via Java إمكانية تقييد عمليات التحرير المحددة على الأشكال الفردية أو تطبيق نفس القيود عبر الشرائح. اختر الأقفال المدعومة من كل نوع من الأشكال، واضبط قيمتها على `False` عندما تحتاج إلى إزالة تلك القيود.

## **الأسئلة المتكررة**

**هل يمكنني دمج أقفال الأشكال وحماية كلمة المرور في نفس العرض؟**

نعم. أقفال الأشكال تقيد عمليات التحرير المحددة، بينما [حماية كلمة المرور](/slides/ar/python-java/password-protected-presentation/) يمكن أن تقيد فتح العرض أو تعديله. يمكنك استخدام كلاهما في نفس الملف.

**هل يمكنني تقييد التحرير على شرائح محددة دون التأثير على الآخرين؟**

نعم. قم بتطبيق الأقفال فقط على الأشكال في الشرائح المحددة. هذا لا يغيّر إعدادات الأقفال في الشرائح الأخرى.

**كيف يمكنني تطبيق الأقفال على الأشكال الفردية داخل مجموعة؟**

قم بالتجول عبر المجموعة التي تُرجِعها طريقة [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes) الخاصة بالمجموعة وطبق الأقفال المناسبة على كل شكل فرعي. كرر ذلك لأي مجموعات متعشقة. الأمثلة أعلاه تعالج فقط مجموعة الأشكال الخاصة بالشريحة، لذا فهي لا تضبط أقفالًا على أعضاء المجموعة الفرديين.