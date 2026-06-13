---
title: ActiveX
type: docs
weight: 200
url: /fa/python-net/examples/elements/activex/
keywords:
- ActiveX
- کنترل ActiveX
- افزودن ActiveX
- دسترسی به ActiveX
- حذف ActiveX
- ویژگی‌های ActiveX
- مثال‌های کد
- PowerPoint
- ارائه
- Python
- Aspose.Slides
description: "یاد بگیرید چگونه کنترل‌های ActiveX را در Python با Aspose.Slides پیدا کنید، ویرایش کنید و حذف کنید، به‌همراه به‌روزرسانی ویژگی‌ها برای ارائه‌های PowerPoint."
---
نحوه افزودن، دسترسی، حذف و پیکربندی کنترل‌های ActiveX در یک ارائه را با استفاده از **Aspose.Slides for Python via .NET** نشان می‌دهد.

## **افزودن یک کنترل ActiveX**

یک کنترل ActiveX جدید درج کنید.

```py
def add_activex():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # اضافه کردن یک کنترل ActiveX جدید (TextBox).
        control = slide.controls.add_control(slides.ControlType.WINDOWS_MEDIA_PLAYER, 50, 50, 100, 50)

        presentation.save("activex.pptm", slides.export.SaveFormat.PPTM)
```

## **دسترسی به یک کنترل ActiveX**

اطلاعات اولین کنترل ActiveX روی اسلاید را بخوانید.

```py
def access_activex():
    with slides.Presentation("activex.pptm") as presentation:
        slide = presentation.slides[0]

        # دسترسی به اولین کنترل ActiveX.
        control = slide.controls[0] if slide.controls else None
        if control is not None:
            # نمایش نام کنترل.
            print(f"Control Name: {control.name}")
```

## **حذف یک کنترل ActiveX**

یک کنترل ActiveX موجود را از اسلاید حذف کنید.

```py
def remove_activex():
    with slides.Presentation("activex.pptm") as presentation:
        slide = presentation.slides[0]

        if len(slide.controls) > 0:
            # حذف اولین کنترل ActiveX.
            slide.controls.remove_at(0)

        presentation.save("activex_removed.pptm", slides.export.SaveFormat.PPTM)
```

## **تنظیم ویژگی‌های ActiveX**

چندین ویژگی ActiveX را پیکربندی کنید.

```py
def set_activex_properties():
    with slides.Presentation("activex.pptm") as presentation:
        slide = presentation.slides[0]

        # فرض می‌کنیم مجموعه کنترل‌ها حداقل یک کنترل دارد.
        control = slide.controls[0]

        control.properties.add("Caption", "Click Me")
        control.properties.add("Enabled", "true")

        presentation.save("activex_properties.pptm", slides.export.SaveFormat.PPTM)
```