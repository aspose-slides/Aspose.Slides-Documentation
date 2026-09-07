---
title: صندوق نص
type: docs
weight: 40
url: /ar/python-java/examples/elements/text-box/
keywords:
- مثال على الكود
- صندوق نص
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "العمل مع صناديق النص في Aspose.Slides for Python عبر Java: إضافة، تنسيق، البحث، وإزالة النص في عروض PowerPoint و OpenDocument."
---
في **Aspose.Slides for Python via Java**، يُعتبر صندوق النص شكلاً تلقائيًا يحتوي على نص. يمكن لأي شكل تقريبًا أن يحتوي على نص، ولكن صندوق النص النموذجي لا يحتوي على تعبئة أو حد ويعرض النص فقط.

يشرح هذا الدليل كيفية إضافة، الوصول وإزالة صناديق النص برمجيًا.

قم بتثبيت الحزمة كما هو موضح في [Installation](/slides/ar/python-java/installation/). كل مثال يستورد `asposeslides` قبل بدء JVM، ثم يستورد API بعد تشغيل JVM.

## **إضافة صندوق نص**

أنشئ مستطيلًا، أزل تعبئته وحدوده، ثم عيّن نصًا منسقًا.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpause.startJVM()

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

## **الوصول إلى صناديق النص حسب المحتوى**

أضف صندوق نص تجريبي، ثم ابحث عن الأشكال التي يحتوي نصها على الكلمة المفتاحية "Slide".

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
                # استخدم صندوق النص المطابق.
                print(text_frame.getText())
finally:
    presentation.dispose()
```

## **إزالة صناديق النص حسب المحتوى**

ابحث واحذف صناديق النص في الشريحة الأولى التي تحتوي على كلمة مفتاحية محددة.

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

{{% alert color="success" title="Tip" %}}
قم بجمع الأشكال المطابقة في قائمة منفصلة قبل إزالتها لتجنب تعديل مجموعة الأشكال أثناء التكرار.
{{% /alert %}}