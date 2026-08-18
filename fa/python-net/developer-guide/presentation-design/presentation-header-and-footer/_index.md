---
title: مدیریت سرصفحه‌ها و پاورقی‌های ارائه با پایتون
linktitle: سرصفحه و پاورقی
type: docs
weight: 140
url: /fa/python-net/presentation-header-and-footer/
keywords:
- سرصفحه
- متن سرصفحه
- پاورقی
- متن پاورقی
- تنظیم سرصفحه
- تنظیم پاورقی
- جزوه
- یادداشت‌ها
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "یاد بگیرید چگونه مکان‌نگهدارهای پاورقی، تاریخ‑زمان، شماره اسلاید و سرصفحه را بر روی اسلایدها، صفحات یادداشت و جزوه‌ها با Aspose.Slides برای پایتون از طریق .NET مدیریت کنید."
---
## **بررسی کلی**

PowerPoint بسته به نوع صفحه از مکان‌نگهدارهای متفاوت سرصفحه و پاورقی استفاده می‌کند. Aspose.Slides برای Python از طریق .NET به شما امکان می‌دهد متن و قابلیت نمایش این مکان‌نگهدارها را از طریق کلاس‌های مدیر سرصفحه/پاورقی کنترل کنید.

مکان‌نگهدارهای در دسترس بستگی به دامنه دارند:

| دامنه | سرصفحه | پاورقی | تاریخ/زمان | شماره اسلاید/صفحه |
|---|---|---|---|---|
| اسلاید عادی | خیر | بله | بله | بله |
| قالب یادداشت‌ها | بله | بله | بله | بله |
| اسلاید یادداشت | بله | بله | بله | بله |
| قالب توزیع | بله | بله | بله | بله |

یک اسلاید عادی ارائه سرصفحه‌ای ندارد. سرصفحه‌ها در صفحات یادداشت و توزیع موجود هستند. برای اسلایدهای عادی، به‌جای سرصفحه از مکان‌نگهدارهای پاورقی، تاریخ/زمان و شماره اسلاید استفاده کنید.

دامنهٔ تغییر به مدیری که به کار می‌برید بستگی دارد. کلاس [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slideheaderfootermanager/) یک اسلاید عادی را کنترل می‌کند. کلاس [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/python-net/aspose.slides/notesslideheaderfootermanager/) یک اسلاید یادداشت را کنترل می‌کند. مدیران قالب و چیده‌سازی می‌توانند تنظیمات را به اسلایدهای وابسته انتقال دهند، در حالی که کلاس [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/python-net/aspose.slides/masterhandoutslideheaderfootermanager/) قالب توزیع را کنترل می‌کند.

## **تنظیم پاورقی، تاریخ/زمان و شماره اسلاید در اسلایدهای عادی**

برای اسلایدهای عادی، جریان کار پایه این است که مدیر سرصفحه/پاورقی هر اسلاید را بازیابی کنید، متن پاورقی و تاریخ/زمان را تنظیم کنید، مکان‌نگهدارهای مورد نیاز را فعال کنید و سپس ارائه را ذخیره کنید. شماره اسلایدها توسط ارائه تولید می‌شوند، بنابراین فقط کافی است نمایش آن‌ها را کنترل کنید.

از `set_footer_text`([مستندات](https://reference.aspose.com/slides/fa/python-net/aspose.slides/baseslideheaderfootermanager/set_footer_text/)) و `set_date_time_text`([مستندات](https://reference.aspose.com/slides/fa/python-net/aspose.slides/baseslideheaderfootermanager/set_date_time_text/)) برای تنظیم متن استفاده کنید و از `set_footer_visibility`([مستندات](https://reference.aspose.com/slides/fa/python-net/aspose.slides/baseslideheaderfootermanager/set_footer_visibility/))، `set_date_time_visibility`([مستندات](https://reference.aspose.com/slides/fa/python-net/aspose.slides/baseslideheaderfootermanager/set_date_time_visibility/)) و `set_slide_number_visibility`([مستندات](https://reference.aspose.com/slides/fa/python-net/aspose.slides/baseslideheaderfootermanager/set_slide_number_visibility/)) برای نمایش مکان‌نگهدارهای مربوطه استفاده کنید.

مثال کامل زیر همان پاورقی، متن تاریخ/زمان و نمایش شماره اسلاید را برای تمام اسلایدهای عادی اعمال می‌کند:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        header_footer_manager = slide.header_footer_manager

        header_footer_manager.set_footer_text("Company Confidential")
        header_footer_manager.set_footer_visibility(True)

        header_footer_manager.set_date_time_text("Date and time text")
        header_footer_manager.set_date_time_visibility(True)

        header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_slide_footers.pptx", slides.export.SaveFormat.PPTX)
```

اگر نیاز به به‌روزرسانی تنها یک اسلاید دارید، به‌جای پیمایش کل مجموعه، مستقیماً از مجموعه [`slides`](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/slides/fa/) آن اسلاید دسترسی بگیرید.

## **تنظیم سرصفحه و پاورقی در قالب یادداشت‌ها**

قالب یادداشت‌ها قالب‌بندی مشترک و رفتار مکان‌نگهدارهای صفحات یادداشت را تعریف می‌کند. هنگامیکه می‌خواهید فقط روی خود قالب یادداشت‌ها تغییر بدهید، از کلاس [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/python-net/aspose.slides/masternotesslideheaderfootermanager/) استفاده کنید.

مثال زیر سرصفحه، پاورقی و متن تاریخ/زمان را بر روی قالب یادداشت‌ها تنظیم می‌کند و تمام مکان‌نگهدارهای پشتیبانی‌شده را در آن قالب قابل مشاهده می‌سازد:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        header_footer_manager.set_header_text("Notes header")
        header_footer_manager.set_header_visibility(True)

        header_footer_manager.set_footer_text("Notes footer")
        header_footer_manager.set_footer_visibility(True)

        header_footer_manager.set_date_time_text("Date and time text")
        header_footer_manager.set_date_time_visibility(True)

        header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_notes_master_footers.pptx", slides.export.SaveFormat.PPTX)
```

یک ارائه ممکن است قالب یادداشت نداشته باشد، بنابراین قبل از تغییر آن مقدار برگشتی را برای `None` بررسی کنید.

## **اعمال تنظیمات قالب یادداشت‌ها بر اسلایدهای فرزند یادداشت‌ها**

یک قالب یادداشت می‌تواند تنظیمات سرصفحه و پاورقی را بر خود و تمام اسلایدهای یادداشت وابسته اعمال کند. هنگامی که همان تنظیمات باید در سرتاسر سلسله‌مراتب یادداشت‌ها اعمال شود، از متدهای انتشار اختصاصی روی [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/python-net/aspose.slides/masternotesslideheaderfootermanager/) استفاده کنید.

به‌عنوان مثال، `set_header_and_child_headers_text`([مستندات](https://reference.aspose.com/slides/fa/python-net/aspose.slides/masternotesslideheaderfootermanager/set_header_and_child_headers_text/)) و `set_header_and_child_headers_visibility`([مستندات](https://reference.aspose.com/slides/fa/python-net/aspose.slides/masternotesslideheaderfootermanager/set_header_and_child_headers_visibility/)) سرصفحه قالب یادداشت و تمام سرصفحه‌های فرزند را به‌روزرسانی می‌کند. متدهای معادلی برای پاورقی‌ها، تاریخ/زمان و شماره اسلاید موجود است.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        header_footer_manager.set_header_and_child_headers_text("Notes header")
        header_footer_manager.set_header_and_child_headers_visibility(True)

        header_footer_manager.set_footer_and_child_footers_text("Notes footer")
        header_footer_manager.set_footer_and_child_footers_visibility(True)

        header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")
        header_footer_manager.set_date_time_and_child_date_times_visibility(True)

        header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)

    presentation.save("presentation_with_child_notes_footers.pptx", slides.export.SaveFormat.PPTX)
```

متدهای انتشار استفاده‌شده در بالا عبارتند از `set_footer_and_child_footers_text`([مستندات](https://reference.aspose.com/slides/fa/python-net/aspose.slides/masternotesslideheaderfootermanager/set_footer_and_child_footers_text/)), `set_footer_and_child_footers_visibility`([مستندات](https://reference.aspose.com/slides/fa/python-net/aspose.slides/masternotesslideheaderfootermanager/set_footer_and_child_footers_visibility/)), `set_date_time_and_child_date_times_text`([مستندات](https://reference.aspose.com/slides/fa/python-net/aspose.slides/masternotesslideheaderfootermanager/set_date_time_and_child_date_times_text/)), `set_date_time_and_child_date_times_visibility`([مستندات](https://reference.aspose.com/slides/fa/python-net/aspose.slides/masternotesslideheaderfootermanager/set_date_time_and_child_date_times_visibility/)) و `set_slide_number_and_child_slide_numbers_visibility`([مستندات](https://reference.aspose.com/slides/fa/python-net/aspose.slides/masternotesslideheaderfootermanager/set_slide_number_and_child_slide_numbers_visibility/)).

## **تنظیم سرصفحه و پاورقی در یک اسلاید یادداشت فردی**

یک اسلاید یادداشت به یک اسلاید عادی خاص تعلق دارد. وقتی می‌خواهید فقط آن صفحه یادداشت را سفارشی کنید، از کلاس [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/python-net/aspose.slides/notesslideheaderfootermanager/) استفاده کنید.

متد `add_notes_slide`([مستندات](https://reference.aspose.com/slides/fa/python-net/aspose.slides/notesslidemanager/add_notes_slide/)) اسلاید یادداشت مربوط به اسلاید جاری را برمی‌گرداند و در صورت عدم وجود، آن را ایجاد می‌کند. مثال زیر صفحه یادداشت مرتبط با اولین اسلاید ارائه را پیکربندی می‌کند:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    notes_slide = presentation.slides[0].notes_slide_manager.add_notes_slide()
    header_footer_manager = notes_slide.header_footer_manager

    header_footer_manager.set_header_text("Header for the first notes page")
    header_footer_manager.set_header_visibility(True)

    header_footer_manager.set_footer_text("Footer for the first notes page")
    header_footer_manager.set_footer_visibility(True)

    header_footer_manager.set_date_time_text("Date and time text")
    header_footer_manager.set_date_time_visibility(True)

    header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_custom_notes_footers.pptx", slides.export.SaveFormat.PPTX)
```

اگر ابتدا تنظیمات را از قالب یادداشت‌ها انتشار دهید و سپس اسلاید یادداشت فردی را تغییر دهید، تنظیمات پسارنگ (per‑slide) به شما امکان می‌دهد آن صفحه یادداشت را به‌صورت مستقل سفارشی کنید.

## **تنظیم سرصفحه و پاورقی در قالب توزیع**

صفحات توزیع از قالب توزیع برای سرصفحه، پاورقی، تاریخ/زمان و مکان‌نگهدارهای شماره صفحه استفاده می‌کنند. برخلاف صفحات یادداشت، تنظیمات توزیع از طریق قالب توزیع مدیریت می‌شود نه از طریق اسلایدهای توزیع فردی.

از ویژگی `master_handout_slide`([مستندات](https://reference.aspose.com/slides/fa/python-net/aspose.slides/imasterhandoutslidemanager/master_handout_slide/)) برای دسترسی به قالب توزیع استفاده کنید. اگر موجود نیست، متد `set_default_master_handout_slide`([مستندات](https://reference.aspose.com/slides/fa/python-net/aspose.slides/imasterhandoutslidemanager/set_default_master_handout_slide/)) را فراخوانی کنید تا قالب توزیع پیش‌فرض ایجاد شود.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_handout_slide = presentation.master_handout_slide_manager.master_handout_slide

    if master_handout_slide is None:
        presentation.master_handout_slide_manager.set_default_master_handout_slide()
        master_handout_slide = presentation.master_handout_slide_manager.master_handout_slide

    if master_handout_slide is not None:
        header_footer_manager = master_handout_slide.header_footer_manager

        header_footer_manager.set_header_text("Handout header")
        header_footer_manager.set_header_visibility(True)

        header_footer_manager.set_footer_text("Handout footer")
        header_footer_manager.set_footer_visibility(True)

        header_footer_manager.set_date_time_text("Date and time text")
        header_footer_manager.set_date_time_visibility(True)

        header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_handout_footers.pptx", slides.export.SaveFormat.PPTX)
```

## **درک دامنه و وراثت**

مدیر سرصفحه/پاورقی مناسب را بر اساس دامنه‌ای که می‌خواهید تغییر دهید، انتخاب کنید:

- [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slideheaderfootermanager/) پاورقی، تاریخ/زمان و تنظیمات شماره اسلاید را برای یک اسلاید عادی تغییر می‌دهد.
- [`LayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/python-net/aspose.slides/layoutslideheaderfootermanager/) یک اسلاید چیده‌سازی را کنترل می‌کند و می‌تواند تنظیمات پشتیبانی‌شده را به اسلایدهای وابسته انتشار دهد.
- [`MasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/python-net/aspose.slides/masterslideheaderfootermanager/) یک قالب اسلاید عادی را کنترل می‌کند و می‌تواند تنظیمات پشتیبانی‌شده را به اسلایدهای وابسته انتشار دهد.
- [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/python-net/aspose.slides/masternotesslideheaderfootermanager/) قالب یادداشت‌ها را کنترل می‌کند و می‌تواند تنظیمات را به تمام اسلایدهای یادداشت وابسته انتشار دهد.
- [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/python-net/aspose.slides/notesslideheaderfootermanager/) یک اسلاید یادداشت را تغییر می‌دهد و علاوه بر پاورقی، تاریخ/زمان و شماره اسلاید، یک سرصفحه را نیز پشتیبانی می‌کند.
- [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/python-net/aspose.slides/masterhandoutslideheaderfootermanager/) قالب توزیع را تغییر می‌دهد و همهٔ چهار نوع مکان‌نگهدار را پشتیبانی می‌کند.

زمانی که یک تنظیم باید در تمام سلسله‌مراتب خود اعمال شود، از انتشار از یک قالب یا چیده‌سازی استفاده کنید. وقتی نیاز به تنظیم محلی برای یک صفحه دارید، از مدیر اسلاید فردی یا اسلاید‑یادداشت استفاده کنید.

## **پرسش‌های متداول**

**آیا می‌توانم سرصفحه‌ای به اسلاید عادی اضافه کنم؟**

خیر. PowerPoint برای اسلایدهای عادی سرصفحه‌ای تعریف نکرده است. در اسلایدهای عادی از مکان‌نگهدارهای پاورقی، تاریخ/زمان و شماره اسلاید استفاده کنید. سرصفحه‌ها در صفحات یادداشت و توزیع موجود هستند.

**اگر مکان‌نگهدار پاورقی، تاریخ/زمان یا شماره اسلاید قابل مشاهده نباشد چه کار کنم؟**

از مدیر سرصفحه/پاورقی مربوطه برای بررسی قابلیت مشاهده آن استفاده کنید و در صورت نیاز آن را فعال کنید. به‌عنوان مثال، `is_footer_visible`([مستندات](https://reference.aspose.com/slides/fa/python-net/aspose.slides/baseslideheaderfootermanager/is_footer_visible/)) گزارش می‌دهد آیا مکان‌نگهدار پاورقی موجود است یا خیر و `set_footer_visibility`([مستندات](https://reference.aspose.com/slides/fa/python-net/aspose.slides/baseslideheaderfootermanager/set_footer_visibility/)) نمایش آن را تغییر می‌دهد.

**چگونه می‌توانم شماره‌گذاری اسلایدها را از مقداری غیر از 1 آغاز کنم؟**

ویژگی `first_slide_number`([مستندات](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/first_slide_number/)) ارائه را تنظیم کنید. سپس مکان‌نگهدارهای شماره اسلاید از توالی به‌روز شده استفاده می‌کنند.

**زمانی که به PDF، تصویر یا HTML صادر می‌کنم، سرصفحه و پاورقی چه می‌شود؟**

عناصر قابل مشاهدهٔ سرصفحه و پاورقی همراه با بقیه محتوای ارائه در قالب خروجی رندر می‌شوند. ظاهر آن‌ها به نوع صفحه‌ای که صادر می‌شود و تنظیمات قابلیت مشاهدهٔ مکان‌نگهدار مربوطه بستگی دارد.