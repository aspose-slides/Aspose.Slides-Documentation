---
title: الحبر
type: docs
weight: 180
url: /ar/python-java/examples/elements/ink/
keywords:
- مثال على الكود
- حبر
- الوصول إلى الحبر
- إزالة الحبر
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "الوصول إلى أشكال الحبر وإزالتها في عروض Aspose.Slides للـ Python عبر Java، بما في ذلك ملفات PPT و PPTX و ODP."
---
توفر هذه المقالة أمثلة على الوصول إلى أشكال الحبر الموجودة وإزالتها باستخدام **Aspose.Slides for Python via Java**.

قم بتثبيت الحزمة كما هو موضح في [Installation](/slides/ar/python-java/installation/). كل مثال يستورد `asposeslides` قبل تشغيل JVM، ثم يستورد API بعد تشغيل JVM.

{{% alert color="info" title="Note" %}}
تمثل أشكال الحبر مدخلات المستخدم من أجهزة متخصصة. لا يمكن لـ Aspose.Slides إنشاء ضربات حبر جديدة برمجيًا، ولكن يمكنك قراءة الحبر الموجود وتعديله.
{{% /alert %}}

## **الوصول إلى الحبر**

اقرأ العلامات من أول شكل حبر في الشريحة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Ink, Presentation

presentation = Presentation("ink.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().get_Item(0)
    if isinstance(shape, Ink):
        tags = shape.getCustomData().getTags()
        if tags.size() > 0:
            tag_name = tags.getNameByIndex(0)
            # استخدم tag_name حسب الحاجة.
finally:
    presentation.dispose()
```

## **إزالة الحبر**

احذف شكل حبر من الشريحة إذا كان موجودًا.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Ink, Presentation

presentation = Presentation("ink.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    ink = None
    for shape in slide.getShapes():
        if isinstance(shape, Ink):
            ink = shape
            break

    if ink is not None:
        slide.getShapes().remove(ink)
finally:
    presentation.dispose()
```