---
title: ActiveX
type: docs
weight: 200
url: /ar/python-java/examples/elements/activex/
keywords:
- مثال على الكود
- ActiveX
- تحكم ActiveX
- خصائص ActiveX
- PowerPoint
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "استخدم Aspose.Slides for Python via Java لإضافة والتحكم والوصول وإزالة وتكوين عناصر تحكم ActiveX في عروض PowerPoint التقديمية مع أمثلة عملية على الكود."
---
توضح هذه المقالة كيفية إضافة والتحكم والوصول وإزالة وتكوين عناصر تحكم ActiveX في عرض تقديمي باستخدام **Aspose.Slides for Python via Java**.

قم بتثبيت الحزمة كما هو موضح في [التثبيت](/slides/ar/python-java/installation/). يستورد كل مثال `asposeslides` قبل بدء الـ JVM، ثم يستورد الـ API بعد تشغيل الـ JVM. تستخدم أمثلة الوصول والإزالة الملف `add_activex.pptm`، الذي تم إنشاؤه بواسطة المثال الأول.

## **إضافة عنصر تحكم ActiveX**

أدرج عنصر تحكم Windows Media Player في الشريحة الأولى واحفظ العرض التقديمي كملف PPTM.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ControlType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # أضف عنصر تحكم Windows Media Player.
    control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50)
    control.getProperties().set_Item("autoStart", "false")

    presentation.save("add_activex.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

## **الوصول إلى عنصر تحكم ActiveX**

قراءة اسم وإعداد التشغيل التلقائي لأول عنصر تحكم ActiveX في الشريحة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("add_activex.pptm")
try:
    if presentation.getSlides().size() > 0:
        slide = presentation.getSlides().get_Item(0)
        if slide.getControls().size() > 0:
            # الوصول إلى أول عنصر تحكم ActiveX.
            control = slide.getControls().get_Item(0)
            print("Control Name:", control.getName())
            print("autoStart:", control.getProperties().get_Item("autoStart"))
        else:
            print("The first slide contains no ActiveX controls.")
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

## **إزالة عنصر تحكم ActiveX**

احذف أول عنصر تحكم ActiveX من الشريحة واحفظ العرض التقديمي المعدل.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("add_activex.pptm")
try:
    if presentation.getSlides().size() > 0:
        slide = presentation.getSlides().get_Item(0)
        if slide.getControls().size() > 0:
            # إزالة أول عنصر تحكم ActiveX.
            slide.getControls().removeAt(0)
        else:
            print("The first slide contains no ActiveX controls.")
    else:
        print("The presentation contains no slides.")

    presentation.save("removed_activex.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

## **تعيين خصائص ActiveX**

أضف عنصر تحكم Windows Media Player، عطل التشغيل التلقائي، وأخفِ أدوات التحكم في التشغيل. استخدم [ControlPropertiesCollection.set_Item](https://reference.aspose.com/slides/ar/python-java/aspose.slides/controlpropertiescollection/#set_Item) لتعيين قيم الخصائص كسلاسل نصية.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ControlType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # إضافة عنصر تحكم Windows Media Player وتكوين خصائصه.
    control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50)
    properties = control.getProperties()
    properties.set_Item("autoStart", "false")
    properties.set_Item("uiMode", "none")

    presentation.save("set_activex_props.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```