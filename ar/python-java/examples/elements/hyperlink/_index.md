---
title: رابط تشعبي
type: docs
weight: 130
url: /ar/python-java/examples/elements/hyperlink/
keywords:
- مثال كود
- رابط تشعبي
- إضافة رابط تشعبي
- الوصول إلى رابط تشعبي
- إزالة رابط تشعبي
- تحديث رابط تشعبي
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "إضافة وإدارة الروابط التشعبية في Aspose.Slides للـ Python عبر Java: إنشاء، وصول، إزالة، وتحديث الروابط في عروض PPT، PPTX، و ODP."
---
توضح هذه المقالة إضافة، والوصول، وإزالة، وتحديث الروابط التشعبية على الأشكال باستخدام **Aspose.Slides for Python via Java**.

قم بتثبيت الحزمة كما هو موضح في [التثبيت](/slides/ar/python-java/installation/). كل مثال يستورد `asposeslides` قبل بدء تشغيل JVM، ثم يستورد API بعد تشغيل JVM.

## **إضافة رابط تشعبي**

أنشئ شكلًا مستطيلًا يحتوي على رابط تشعبي يشير إلى موقع ويب خارجي.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("Aspose")

    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    text_portion.getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com"))
finally:
    presentation.dispose()
```

## **الوصول إلى رابط تشعبي**

اقرأ معلومات الرابط التشعبي من جزء النص في الشكل.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("Aspose")

    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    text_portion.getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com"))

    hyperlink = text_portion.getPortionFormat().getHyperlinkClick()
finally:
    presentation.dispose()
```

## **إزالة رابط تشعبي**

إزالة الرابط التشعبي من نص الشكل.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("Aspose")

    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    text_portion.getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com"))

    text_portion.getPortionFormat().setHyperlinkClick(None)
finally:
    presentation.dispose()
```

## **تحديث رابط تشعبي**

قم بتغيير هدف رابط تشعبي موجود. استخدم [HyperlinkManager](https://reference.aspose.com/slides/ar/python-java/aspose.slides/hyperlinkmanager/) لتعديل النص الذي يحتوي بالفعل على رابط تشعبي، وهو ما يحاكي طريقة تحديث PowerPoint للروابط التشعبية بأمان.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("Aspose")

    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    text_portion.getPortionFormat().setHyperlinkClick(Hyperlink("https://old.example.com"))

    # يجب تغيير رابط تشعبي داخل نص موجود عبر
    # HyperlinkManager بدلاً من ضبط الخاصية مباشرةً.
    # هذا يحاكي طريقة تحديث PowerPoint للروابط التشعبية بأمان.
    text_portion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://new.example.com")
finally:
    presentation.dispose()
```