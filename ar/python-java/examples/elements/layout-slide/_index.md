---
title: شريحة تخطيط
type: docs
weight: 20
url: /ar/python-java/examples/elements/layout-slide/
keywords:
- مثال على الكود
- شريحة تخطيط
- إضافة شريحة تخطيط
- الوصول إلى شريحة تخطيط
- إزالة شريحة تخطيط
- شريحة تخطيط غير مستخدمة
- استنساخ شريحة تخطيط
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "إدارة شرائح التخطيط باستخدام Aspose.Slides للغة Python عبر Java: إضافة، وصول، إزالة، تنظيف، واستنساخ التخطيطات في عروض PowerPoint وOpenDocument."
---
توضح هذه المقالة كيفية العمل مع **شرائح التخطيط** باستخدام Aspose.Slides للغة Python عبر Java. تُعرّف شريحة التخطيط التصميم والتنسيق الذي تُورثه الشرائح العادية. يمكنك إضافة، والوصول إلى، واستنساخ، وإزالة شرائح التخطيط، وكذلك تنظيف الشرائح غير المستخدمة لتقليل حجم العرض التقديمي.

ثبّتك الحزمة كما هو موضح في [Installation](/slides/ar/python-java/installation/). كل مثال يستورد `asposeslides` قبل بدء الـ JVM، ثم يستورد الـ API بعد تشغيل الـ JVM.

## **إضافة شريحة تخطيط**

أنشئ شريحة تخطيط مخصصة لتحديد تنسيق يُعاد استخدامه. المثال التالي يضيف مربع نص إلى تخطيط جديد ثم ينشئ شريحتين تستخدمان ذلك.

```python
import jpype
import asposeslides

if not jpipe.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SlideLayoutType

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)

    # إنشاء شريحة تخطيط بنوع تخطيط فارغ واسم مخصص.
    layout_slide = presentation.getLayoutSlides().add(master_slide, SlideLayoutType.Blank, "Main layout")

    # إضافة مربع نص إلى شريحة التخطيط.
    layout_text_box = layout_slide.getShapes().addAutoShape(ShapeType.Rectangle, 75, 75, 150, 150)
    layout_text_box.getTextFrame().setText("Layout Slide Text")

    # إضافة شريحتين ترث النص من التخطيط.
    presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)
finally:
    presentation.dispose()
```

> 💡 **ملاحظة 1:** تعمل شرائح التخطيط كقوالب للشرائح الفردية. يمكنك تعريف العناصر المشتركة مرة واحدة وإعادة استخدامها عبر العديد من الشرائح.

> 💡 **ملاحظة 2:** عند إضافة أشكال أو نص إلى شريحة التخطيط، جميع الشرائح المستندة إلى ذلك التخطيط تعرض المحتوى المشترك تلقائيًا.
> تبيّن الصورة أدناه شريحتين ترثان مربع نص من نفس شريحة التخطيط.

![شرائح ترث محتوى التخطيط](layout-slide-result.png)

## **الوصول إلى شريحة تخطيط**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    # الوصول إلى شريحة تخطيط حسب الفهرس.
    first_layout_slide = presentation.getLayoutSlides().get_Item(0)

    # الوصول إلى شريحة تخطيط حسب النوع.
    blank_layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
finally:
    presentation.dispose()
```

## **إزالة شريحة تخطيط**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    layout_slide = presentation.getLayoutSlides().add(master_slide, SlideLayoutType.Blank, "Temporary layout")

    presentation.getLayoutSlides().remove(layout_slide)
finally:
    presentation.dispose()
```

## **إزالة شرائح التخطيط غير المستخدمة**

```python
import jpype
import asposeslides

if not jpipe.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    presentation.getLayoutSlides().removeUnused()
finally:
    presentation.dispose()
```

## **استنساخ شريحة تخطيط**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    source_layout_slide = presentation.getLayoutSlides().add(master_slide, SlideLayoutType.Blank, "Source layout")

    cloned_layout_slide = presentation.getLayoutSlides().addClone(source_layout_slide)
finally:
    presentation.dispose()
```

✅ **الملخص:** تساعد شرائح التخطيط في الحفاظ على تنسيق موحد عبر العرض التقديمي. يتيح لك Aspose.Slides إنشاء، وإدارة، وإعادة استخدام، وتنظيف التخطيطات حسب الحاجة.