---
title: ماکرو VBA
type: docs
weight: 150
url: /fa/python-net/examples/elements/vba-macro/
keywords:
- ماکرو VBA
- افزودن ماکرو VBA
- دسترسی به ماکرو VBA
- حذف ماکرو VBA
- مثال‌های کد
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "کار با ماکروهای VBA در پایتون با استفاده از Aspose.Slides: افزودن یا ویرایش پروژه‌ها و ماژول‌ها، امضای یا حذف ماکروها، و ذخیره ارائه‌ها در قالب‌های PPT، PPTX و ODP."
---
نشان می‌دهد چگونه ماکروهای VBA را با استفاده از **Aspose.Slides for Python via .NET** اضافه، دسترسی پیدا کرده و حذف کنیم.

## **افزودن یک ماکرو VBA**

یک ارائه با یک پروژه VBA و یک ماژول ماکرو ساده ایجاد کنید.

```py
def add_vba_macro():
    with slides.Presentation() as presentation:
        # یک پروژه VBA را مقداردهی اولیه کنید.
        presentation.vba_project = slides.vba.VbaProject()

        # یک ماژول خالی به نام "Module" اضافه کنید.
        module = presentation.vba_project.modules.add_empty_module("Module")
        module.source_code = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub"

        presentation.save("vba_macro.pptm", slides.export.SaveFormat.PPTM)
```

## **دسترسی به یک ماکرو VBA**

اولین ماژول را از پروژه VBA بازیابی کنید.

```py
def access_vba_macro():
    with slides.Presentation("vba_macro.pptm") as presentation:
        first_module = presentation.vba_project.modules[0]
```

## **حذف یک ماکرو VBA**

یک ماژول را از پروژه VBA حذف کنید.

```py
def remove_vba_macro():
    with slides.Presentation("vba_macro.pptm") as presentation:

        # فرض می‌کنیم ارائه شامل یک پروژه VBA و حداقل یک ماژول است.
        module = presentation.vba_project.modules[0]

        # ماژول را از پروژه حذف کنید.
        presentation.vba_project.modules.remove(module)

        presentation.save("vba_macro_removed.pptx", slides.export.SaveFormat.PPTX)
```