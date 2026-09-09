---
title: الرأس والتذييل
type: docs
weight: 220
url: /ar/python-java/examples/elements/header-footer/
keywords:
- مثال برمجي
- رأس
- تذييل
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "تحكم في رؤوس وتذييلات الشرائح باستخدام Aspose.Slides للـ Python عبر Java: أضف التواريخ، أرقام الشرائح، ونصًا مخصصًا في عروض PPT و PPTX و ODP."
---
توضح هذه المقالة كيفية إضافة تذييلات وتحديث عناصر النائب للتاريخ والوقت باستخدام **Aspose.Slides for Python via Java**.

قم بتثبيت الحزمة كما هو موضح في [Installation](/slides/ar/python-java/installation/). يستورد كل مثال `asposeslides` قبل بدء تشغيل JVM، ثم يستورد الـ API بعد تشغيل JVM.

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

قم بتعديل عنصر النائب للتاريخ والوقت في الشريحة.

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