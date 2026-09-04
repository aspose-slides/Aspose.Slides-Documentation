---
title: شريحة رئيسية
type: docs
weight: 30
url: /ar/python-java/examples/elements/master-slide/
keywords:
- مثال على الكود
- شريحة رئيسية
- إضافة شريحة رئيسية
- الوصول إلى شريحة رئيسية
- إزالة شريحة رئيسية
- شريحة رئيسية غير مستخدمة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "إدارة الشرائح الرئيسية باستخدام Aspose.Slides للبايثون عبر جافا: إنشاء، وصول، إزالة، وتنظيف الشرائح الرئيسية في عروض PowerPoint و OpenDocument التقديمية."
---
تشكل الشرائح الرئيسية المستوى الأعلى في تسلسل وراثة الشرائح في PowerPoint. **الشريحة الرئيسية** تُعرِّف عناصر التصميم المشتركة مثل الخلفيات، الشعارات، وتنسيق النص. **شرائح التخطيط** ترث من الشرائح الرئيسية، و**الشرائح العادية** ترث من شرائح التخطيط.

توضح هذه المقالة كيفية إنشاء الشرائح الرئيسية وتعديلها وإدارتها باستخدام **Aspose.Slides for Python via Java**.

Install the package as described in [Installation](/slides/ar/python-java/installation/). Each example imports `asposeslides` before starting the JVM, then imports the API after the JVM is running.

## **إضافة شريحة رئيسية**

يوضح هذا المثال كيفية إنشاء شريحة رئيسية جديدة عن طريق استنساخ الشريحة الافتراضية. ثم يضيف شريطًا يحمل اسم الشركة إلى جميع الشرائح عبر وراثة التخطيط.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    # استنساخ الشريحة الرئيسية الافتراضية.
    default_master_slide = presentation.getMasters().get_Item(0)
    new_master_slide = presentation.getMasters().addClone(default_master_slide)

    # إضافة شريط يحمل اسم الشركة إلى أعلى الشريحة الرئيسية.
    text_box = new_master_slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 720, 25)
    text_box.getTextFrame().setText("Company Name")
    paragraph = text_box.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    text_box.getFillFormat().setFillType(FillType.NoFill)

    # تعيين الشريحة الرئيسية الجديدة إلى شريحة تخطيط.
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    layout_slide.setMasterSlide(new_master_slide)

    # تعيين شريحة التخطيط إلى الشريحة الأولى في العرض التقديمي.
    presentation.getSlides().get_Item(0).setLayoutSlide(layout_slide)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
توفر الشرائح الرئيسية وسيلة لتطبيق علامة تجارية متسقة أو عناصر تصميم مشتركة عبر جميع الشرائح. يتم عكس أي تغييرات تُجرَى على الشريحة الرئيسية تلقائيًا على شرائح التخطيط والشرائح العادية التابعة.
{{% /alert %}}

{{% alert color="info" title="Note" %}}
الأشكال والتنسيق المضاف إلى شريحة رئيسية تُورَث إلى شرائح التخطيط، ومن ثم إلى جميع الشرائح العادية التي تستخدم تلك التخطيطات. توضح الصورة أدناه كيف يتم تلقائيًا عرض مربع نص مضاف إلى شريحة رئيسية على الشريحة النهائية.
{{% /alert %}}

![مثال على وراثة الشريحة الرئيسية](master-slide-banner.png)

## **الوصول إلى شريحة رئيسية**

يمكنك الوصول إلى الشرائح الرئيسية عبر مجموعة الشرائح الرئيسية للعرض التقديمي. يسترجع هذا المثال الشريحة الرئيسية الأولى ويغيّر نوع خلفيتها.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, Presentation

presentation = Presentation()
try:
    first_master_slide = presentation.getMasters().get_Item(0)
    first_master_slide.getBackground().setType(BackgroundType.OwnBackground)
finally:
    presentation.dispose()
```

## **إزالة شريحة رئيسية**

يمكن إزالة شريحة رئيسية إما حسب الفهرس أو بالمرجع بعد عدم استخدامها. يخصص هذا المثال شريحة رئيسية مستنسخة للعرض التقديمي ثم يزيل الشريحة الرئيسية الأصلية حسب الفهرس.

```python
import jpide
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    default_master_slide = presentation.getMasters().get_Item(0)
    new_master_slide = presentation.getMasters().addClone(default_master_slide)

    layout_slide = presentation.getLayoutSlides().get_Item(0)
    layout_slide.setMasterSlide(new_master_slide)
    presentation.getSlides().get_Item(0).setLayoutSlide(layout_slide)

    # إزالة الشريحة الرئيسية الأصلية غير المستخدمة حسب الفهرس.
    # بدلاً من ذلك، إزالة شريحة رئيسية غير مستخدمة بالمرجع:
    # presentation.getMasters().remove(unused_master_slide)
finally:
    presentation.dispose()
```

## **إزالة الشرائح الرئيسية غير المستخدمة**

تحتوي بعض العروض التقديمية على شرائح رئيسية غير مستخدمة. يمكن لإزالة هذه الشرائح المساعدة في تقليل حجم الملف.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    default_master_slide = presentation.getMasters().get_Item(0)
    presentation.getMasters().addClone(default_master_slide)

    # إزالة جميع الشرائح الرئيسية غير المستخدمة، بما في ذلك تلك التي تم وضع علامة Preserve عليها.
    presentation.getMasters().removeUnused(True)
finally:
    presentation.dispose()
```