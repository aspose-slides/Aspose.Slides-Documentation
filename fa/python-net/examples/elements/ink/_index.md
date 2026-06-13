---
title: جوهر
type: docs
weight: 180
url: /fa/python-net/examples/elements/ink/
keywords:
- جوهر
- دسترسی به جوهر
- حذف جوهر
- مثال‌های کد
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "دست‌کاری جوهر دیجیتالی در اسلایدها با پایتون و Aspose.Slides: افزودن خطوط قلم، ویرایش مسیرها، تنظیم رنگ و عرض، و خروجی گرفتن نتایج برای PowerPoint و OpenDocument."
---
نمونه‌هایی از دسترسی به اشکال جوهری موجود و حذف آن‌ها با استفاده از **Aspose.Slides for Python via .NET** را فراهم می‌کند.

> ❗ **نکته:** اشکال جوهری نشان‌دهنده ورودی کاربر از دستگاه‌های تخصصی هستند. Aspose.Slides نمی‌تواند خطوط جوهری جدید را به‌صورت برنامه‌نویسی ایجاد کند، اما می‌توانید جوهر موجود را بخوانید و تغییر دهید.

## **دسترسی به جوهر**

اولین شکل جوهری را از یک اسلاید دریافت کنید.

```py
def access_ink():
    with slides.Presentation("ink.pptx") as presentation:
        slide = presentation.slides[0]

        first_ink = None
        for shape in slide.shapes:
            if isinstance(shape, slides.ink.Ink):
                first_ink = shape
                break
```

## **حذف جوهر**

یک شکل جوهری را از اسلاید حذف کنید.

```py
def remove_ink():
    with slides.Presentation("ink.pptx") as presentation:
        slide = presentation.slides[0]

        # فرض بر این است که اولین شکل یک شیء Ink است.
        ink = slide.shapes[0]

        slide.shapes.remove(ink)

        presentation.save("ink_removed.pptx", slides.export.SaveFormat.PPTX)
```