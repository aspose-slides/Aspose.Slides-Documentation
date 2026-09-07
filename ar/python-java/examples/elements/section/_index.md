---
title: قسم
type: docs
weight: 90
url: /ar/python-java/examples/elements/section/
keywords:
- مثال على الكود
- قسم
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "إدارة أقسام العروض التقديمية في Aspose.Slides for Python via Java: إضافة، وصول، إزالة وإعادة تسمية الأقسام باستخدام أمثلة كود Python."
---
أمثلة لإدارة أقسام العرض التقديمي—الإضافة، والوصول، والإزالة، وإعادة تسمية هذه الأقسام برمجياً باستخدام **Aspose.Slides for Python via Java**.

قم بتثبيت الحزمة كما هو موضح في [Installation](/slides/ar/python-java/installation/). كل مثال يستورد `asposeslides` قبل بدء تشغيل JVM، ثم يستورد الـ API بعد تشغيل الـ JVM.

## **إضافة قسم**

إنشاء قسم يبدأ من شريحة محددة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # حدد الشريحة التي تمثل بداية القسم.
    presentation.getSections().addSection("New Section", slide)
finally:
    presentation.dispose()
```

## **الوصول إلى قسم**

قراءة معلومات القسم من عرض تقديمي.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    presentation.getSections().addSection("My Section", slide)

    # الوصول إلى قسم حسب الفهرس.
    section = presentation.getSections().get_Item(0)
    section_name = section.getName()
    print(section_name)
finally:
    presentation.dispose()
```

## **إزالة قسم**

حذف قسم تم إضافته مسبقًا.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    section = presentation.getSections().addSection("Temporary Section", slide)

    # إزالة القسم الأول.
    presentation.getSections().removeSection(section)
finally:
    presentation.dispose()
```

## **إعادة تسمية قسم**

تغيير اسم قسم موجود.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    presentation.getSections().addSection("Old Name", slide)

    section = presentation.getSections().get_Item(0)
    section.setName("New Name")
finally:
    presentation.dispose()
```