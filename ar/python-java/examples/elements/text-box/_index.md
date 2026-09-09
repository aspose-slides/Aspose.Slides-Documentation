---
title: مربع نص
type: docs
weight: 40
url: /ar/python-java/examples/elements/text-box/
keywords:
- مثال على الكود
- مربع نص
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "العمل مع مربعات النص في Aspose.Slides for Python via Java: إضافة، تنسيق، بحث، وإزالة النص في عروض PowerPoint و OpenDocument التقديمية."
---
في **Aspose.Slides for Python via Java**، مربع النص هو شكل تلقائي يحتوي على نص. يمكن لأي شكل تقريبًا أن يحتوي على نص، لكن مربع النص النموذجي لا يحتوي على تعبئة أو حد ويعرض النص فقط.

يوضح هذا الدليل كيفية إضافة مربعات النص والوصول إليها وإزالتها برمجيًا.

قم بتثبيت الحزمة كما هو موضح في [التثبيت](/slides/ar/python-java/installation/). كل مثال يستورد `asposeslides` قبل بدء الـ JVM، ثم يستورد الـ API بعد تشغيل الـ JVM.

## **إضافة مربع نص**

أنشئ مستطيلاً، أزل تعبئته وحدوده، وقم بإسناد نص منسق.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # إنشاء شكل مستطيل.
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100)

    # إزالة التعبئة والحد لتظهر النص فقط.
    text_box.getFillFormat().setFillType(FillType.NoFill)
    text_box.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    # تعيين تنسيق النص الافتراضي.
    paragraph = text_box.getTextFrame().getParagraphs().get_Item(0)
    text_format = paragraph.getParagraphFormat().getDefaultPortionFormat()
    text_format.getFillFormat().setFillType(FillType.Solid)
    text_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    text_box.getTextFrame().setText("Some text...")
finally:
    presentation.dispose()
```

## **الوصول إلى مربعات النص حسب المحتوى**

أضف مربع نص تجريبي، ثم ابحث عن الأشكال التي يحتوي نصها على الكلمة المفتاحية "Slide".

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType, AutoShape

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100)
    text_box.getFillFormat().setFillType(FillType.NoFill)
    text_box.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    text_box.getTextFrame().setText("Slide notes")

    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, AutoShape):
            text_frame = shape.getTextFrame()
            if text_frame is not None and "Slide" in str(text_frame.getText()):
                # استخدم مربع النص المتطابق.
                print(text_frame.getText())
finally:
    presentation.dispose()
```

## **إزالة مربعات النص حسب المحتوى**

ابحث واحذف مربعات النص في الشريحة الأولى التي تحتوي على كلمة مفتاحية محددة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType, AutoShape

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100)
    text_box.getFillFormat().setFillType(FillType.NoFill)
    text_box.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    text_box.getTextFrame().setText("Slide notes")

    shapes_to_remove = []
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, AutoShape):
            text_frame = shape.getTextFrame()
            if text_frame is not None and "Slide" in str(text_frame.getText()):
                shapes_to_remove.append(shape)

    for shape in shapes_to_remove:
        slide.getShapes().remove(shape)
finally:
    presentation.dispose()
```

{{% alert color="success" title="نصيحة" %}}
قُم بجمع الأشكال المطابقة في قائمة منفصلة قبل إزالتها لتجنب تعديل مجموعة الأشكال أثناء التكرار.
{{% /alert %}}