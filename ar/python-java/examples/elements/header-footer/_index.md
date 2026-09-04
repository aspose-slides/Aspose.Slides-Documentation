---
title: الترويسة والتذييل
type: docs
weight: 220
url: /ar/python-java/examples/elements/header-footer/
keywords:
- مثال على الشيفرة
- الترويسة
- التذييل
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "التحكم في ترويسات وتذييلات الشرائح باستخدام Aspose.Slides for Python via Java: إضافة التواريخ وأرقام الشرائح والنص المخصص في عروض PPT و PPTX و ODP."
---
توضح هذه المقالة كيفية إضافة تذييلات وتحديث عناصر النائب للوقت والتاريخ باستخدام **Aspose.Slides for Python via Java**.

قم بتثبيت الحزمة كما هو موضح في [Installation](/slides/ar/python-java/installation/). يستورد كل مثال `asposeslides` قبل بدء الـ JVM، ثم يستورد الـ API بعد تشغيل الـ JVM.

## **إضافة تذييل**

أضف نصًا إلى منطقة التذييل في الشريحة واجعلها مرئية.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getHeaderFooterManager().setFooterText("My footer")
    slide.getHeaderFooterManager().setFooterVisibility(True)
finally:
    presentation.dispose()
```

## **تحديث التاريخ والوقت**

عدّل عنصر النائب للتاريخ والوقت في الشريحة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getHeaderFooterManager().setDateTimeText("01/01/2024")
    slide.getHeaderFooterManager().setDateTimeVisibility(True)
finally:
    presentation.dispose()
```