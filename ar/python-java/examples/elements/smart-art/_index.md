---
title: SmartArt
type: docs
weight: 140
url: /ar/python-java/examples/elements/smart-art/
keywords:
- مثال على الكود
- SmartArt
- إضافة SmartArt
- الوصول إلى SmartArt
- إزالة SmartArt
- تخطيط SmartArt
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "العمل مع SmartArt في Aspose.Slides للـ Python عبر Java: إضافة، وصول، إزالة، وتغيير تخطيطات المخططات في عروض PowerPoint وOpenDocument التقديمية."
---
يوضح هذا المقال كيفية إضافة رسومات SmartArt، الوصول إليها، إزالتها، وتغيير التخطيطات باستخدام **Aspose.Slides for Python via Java**.

قم بتثبيت الحزمة كما هو موضح في [Installation](/slides/ar/python-java/installation/). كل مثال يستورد `asposeslides` قبل بدء الـ JVM، ثم يستورد الـ API بعد تشغيل الـ JVM.

## **إضافة SmartArt**

أدرج رسمة SmartArt باستخدام أحد التخطيطات المدمجة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess)
finally:
    presentation.dispose()
```

## **الوصول إلى SmartArt**

استرجع أول كائن SmartArt في الشريحة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess)

    first_smart_art = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, SmartArt):
            first_smart_art = shape
            break
finally:
    presentation.dispose()
```

## **إزالة SmartArt**

احذف شكل SmartArt من الشريحة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess)

    slide.getShapes().remove(smart_art)
finally:
    presentation.dispose()
```

## **تغيير تخطيط SmartArt**

قم بتحديث نوع التخطيط لرسمة SmartArt الموجودة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicBlockList)
    smart_art.setLayout(SmartArtLayoutType.VerticalPictureList)
finally:
    presentation.dispose()
```