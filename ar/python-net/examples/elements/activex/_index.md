---
title: ActiveX
type: docs
weight: 200
url: /ar/python-net/examples/elements/activex/
keywords:
- ActiveX
- التحكم ActiveX
- إضافة ActiveX
- الوصول إلى ActiveX
- إزالة ActiveX
- خصائص ActiveX
- أمثلة على الشيفرة
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعلم كيفية العثور على عناصر التحكم ActiveX وتعديلها وإزالتها في بايثون باستخدام Aspose.Slides، بما في ذلك تحديث الخصائص لعروض PowerPoint التقديمية."
---
يوضح كيفية إضافة، والوصول، وإزالة، وتكوين عناصر التحكم ActiveX في عرض تقديمي باستخدام **Aspose.Slides for Python via .NET**.

## **إضافة عنصر تحكم ActiveX**

إدراج عنصر تحكم ActiveX جديد.

```py
def add_activex():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # إضافة عنصر تحكم ActiveX جديد (TextBox).
        control = slide.controls.add_control(slides.ControlType.WINDOWS_MEDIA_PLAYER, 50, 50, 100, 50)

        presentation.save("activex.pptm", slides.export.SaveFormat.PPTM)
```

## **الوصول إلى عنصر تحكم ActiveX**

قراءة المعلومات من أول عنصر تحكم ActiveX على الشريحة.

```py
def access_activex():
    with slides.Presentation("activex.pptm") as presentation:
        slide = presentation.slides[0]

        # الوصول إلى أول عنصر تحكم ActiveX.
        control = slide.controls[0] if slide.controls else None
        if control is not None:
            # طباعة اسم العنصر التحكم.
            print(f"Control Name: {control.name}")
```

## **إزالة عنصر تحكم ActiveX**

حذف عنصر تحكم ActiveX موجود من الشريحة.

```py
def remove_activex():
    with slides.Presentation("activex.pptm") as presentation:
        slide = presentation.slides[0]

        if len(slide.controls) > 0:
            # إزالة أول عنصر تحكم ActiveX.
            slide.controls.remove_at(0)

        presentation.save("activex_removed.pptm", slides.export.SaveFormat.PPTM)
```

## **تعيين خصائص ActiveX**

تكوين عدة خصائص لـ ActiveX.

```py
def set_activex_properties():
    with slides.Presentation("activex.pptm") as presentation:
        slide = presentation.slides[0]

        # افتراض أن مجموعة العناصر تحتوي على عنصر واحد على الأقل.
        control = slide.controls[0]

        control.properties.add("Caption", "Click Me")
        control.properties.add("Enabled", "true")

        presentation.save("activex_properties.pptm", slides.export.SaveFormat.PPTM)
```