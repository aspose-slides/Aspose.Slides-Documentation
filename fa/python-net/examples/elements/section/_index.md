---
title: بخش
type: docs
weight: 90
url: /fa/python-net/examples/elements/section/
keywords:
- بخش
- بخش اسلاید
- افزودن بخش
- دسترسی به بخش
- حذف بخش
- تغییر نام بخش
- نمونه کد
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "مدیریت بخش‌های اسلاید در Python با Aspose.Slides: ایجاد، تغییر نام، ترتیب‌گذاری آسان، جابجایی اسلایدها بین بخش‌ها، و کنترل نمایش برای PPT، PPTX و ODP."
---
مثال‌هایی برای مدیریت بخش‌های ارائه—اضافه کردن، دسترسی، حذف و تغییر نام آن‌ها به صورت برنامه‌نویسی با استفاده از **Aspose.Slides for Python via .NET**.

## **افزودن یک بخش**

یک بخش ایجاد کنید که از یک اسلاید خاص آغاز می‌شود.

```py
def add_section():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # یک بخش جدید اضافه کنید و اسلایدی را که شروع بخش را مشخص می‌کند، تعیین کنید.
        presentation.sections.add_section("New Section", slide)

        presentation.save("section.pptx", slides.export.SaveFormat.PPTX)
```

## **دسترسی به یک بخش**

یک بخش را از یک ارائه دریافت کنید.

```py
def access_section():
    with slides.Presentation("section.pptx") as presentation:

        # دسترسی به یک بخش بر اساس اندیس.
        section = presentation.sections[0]
```

## **حذف یک بخش**

بخشی که قبلاً اضافه شده است را حذف کنید.

```py
def remove_section():
    with slides.Presentation("section.pptx") as presentation:
        section = presentation.sections[0]

        # حذف بخش.
        presentation.sections.remove_section(section)

        presentation.save("section_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **تغییر نام یک بخش**

نام یک بخش موجود را تغییر دهید.

```py
def rename_section():
    with slides.Presentation("section.pptx") as presentation:
        section = presentation.sections[0]

        # تغییر نام بخش.
        section.name = "New Name"

        presentation.save("section_renamed.pptx", slides.export.SaveFormat.PPTX)
```