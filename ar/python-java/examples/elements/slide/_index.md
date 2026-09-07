---
title: شريحة
type: docs
weight: 10
url: /ar/python-java/examples/elements/slide/
keywords:
- مثال على الكود
- شريحة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "إدارة الشرائح في Aspose.Slides لـ Python عبر Java: إضافة، وصول، استنساخ، إعادة ترتيب، وإزالة الشرائح باستخدام أمثلة كود Python لعروض PowerPoint وOpenDocument."
---
توفر هذه المقالة أمثلة توضح كيفية إضافة، والوصول، والاستنساخ، وإعادة ترتيب، وإزالة الشرائح باستخدام **Aspose.Slides for Python via Java**.

قم بتثبيت الحزمة كما هو موضح في [Installation](/slides/ar/python-java/installation/). كل مثال يستورد `asposeslides` قبل بدء الـ JVM، ثم يستورد الـ API بعد تشغيل الـ JVM.

## **إضافة شريحة**

لإضافة شريحة جديدة، اختر تخطيطًا أولاً. يستخدم هذا المثال تخطيطًا فارغًا لإضافة شريحة فارغة إلى العرض التقديمي.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    presentation.getSlides().addEmptySlide(blank_layout)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
كل تخطيط شريحة مشتق من شريحة رئيسية، التي تحدد التصميم العام وهيكل العناصر النائبة. الصورة أدناه توضح كيف يتم تنظيم الشرائح الرئيسية وتخطيطاتها المرتبطة في PowerPoint.
{{% /alert %}}

![العلاقة بين الشريحة الرئيسية والتخطيط](master-layout-slide.png)

## **الوصول إلى الشرائح حسب الفهرس**

الوصول إلى الشرائح باستخدام فهرسها الذي يبدأ من الصفر، أو إيجاد فهرس شريحة بناءً على مرجع. هذا مفيد للتكرار عبر الشرائح أو تعديل شرائح محددة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    # أضف شريحة فارغة أخرى.
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
    presentation.getSlides().addEmptySlide(blank_layout)

    # الوصول إلى الشرائح حسب الفهرس.
    first_slide = presentation.getSlides().get_Item(0)
    second_slide = presentation.getSlides().get_Item(1)

    # احصل على فهرس شريحة من مرجع، ثم الوصول إليها حسب الفهرس.
    second_slide_index = presentation.getSlides().indexOf(second_slide)
    second_slide_by_index = presentation.getSlides().get_Item(second_slide_index)
finally:
    presentation.dispose()
```

## **استنساخ شريحة**

استنسخ شريحة موجودة. تُضاف الشريحة المستنسخة تلقائيًا إلى نهاية مجموعة الشرائح.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)

    cloned_slide = presentation.getSlides().addClone(first_slide)

    cloned_slide_index = presentation.getSlides().indexOf(cloned_slide)
finally:
    presentation.dispose()
```

## **إعادة ترتيب الشرائح**

قم بتغيير ترتيب الشرائح بنقل إحدى الشرائح إلى فهرس جديد. ينقل هذا المثال شريحة مستنسخة إلى الموضع الأول.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)

    cloned_slide = presentation.getSlides().addClone(first_slide)

    presentation.getSlides().reorder(0, cloned_slide)
finally:
    presentation.dispose()
```

## **إزالة شريحة**

أزل شريحة بتمرير مرجعها إلى مجموعة الشرائح. يضيف هذا المثال شريحة ثانية ثم يزيل الأصلية، تاركًا الشريحة الجديدة فقط.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
    second_slide = presentation.getSlides().addEmptySlide(blank_layout)

    first_slide = presentation.getSlides().get_Item(0)
    presentation.getSlides().remove(first_slide)
finally:
    presentation.dispose()
```