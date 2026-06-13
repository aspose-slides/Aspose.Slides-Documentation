---
title: سرصفحه و پاورقی
type: docs
weight: 220
url: /fa/python-net/examples/elements/header-footer/
keywords:
- سرصفحه و پاورقی
- افزودن سرصفحه و پاورقی
- به‌روزرسانی سرصفحه و پاورقی
- تنظیم تاریخ و زمان
- نمونه‌های کد
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "کنترل سرصفحه‌ها و پاورقی‌ها در پایتون با Aspose.Slides: افزودن یا ویرایش تاریخ/زمان، شماره اسلایدها و متن پاورقی، نمایش یا پنهان‌سازی جای‌نگهدارها در فرمت‌های PPT، PPTX و ODP."
---
نحوهٔ افزودن پاورقی‌ها و به‌روزرسانی جای‌نگهدارهای تاریخ و زمان را با استفاده از **Aspose.Slides for Python via .NET** نشان می‌دهد.

## **افزودن پاورقی**
متن را به ناحیهٔ پاورقی یک اسلاید اضافه کنید و آن را قابل مشاهده کنید.

```py
def add_footer():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        slide.header_footer_manager.set_footer_text("My footer")
        slide.header_footer_manager.set_footer_visibility(True)

        presentation.save("footer.pptx", slides.export.SaveFormat.PPTX)
```

## **به‌روزرسانی تاریخ و زمان**
جای‌نگهدار تاریخ و زمان را در یک اسلاید تغییر دهید.

```py
def add_date_time():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        slide.header_footer_manager.set_date_time_text("01/01/2024")
        slide.header_footer_manager.set_date_time_visibility(True)

        presentation.save("date_time.pptx", slides.export.SaveFormat.PPTX)
```