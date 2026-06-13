---
title: مدیریت هدرها و فوترهای ارائه با پایتون
linktitle: هدر و فوتر
type: docs
weight: 140
url: /fa/python-net/presentation-header-and-footer/
keywords:
- هدر
- متن هدر
- فوتر
- متن فوتر
- تنظیم هدر
- تنظیم فوتر
- نسخه چاپی
- یادداشت‌ها
- PowerPoint
- ارائه
- Python
- Aspose.Slides
description: "از Aspose.Slides برای پایتون از طریق .NET برای افزودن و سفارشی‌سازی هدرها و فوترها در ارائه‌های PowerPoint و OpenDocument جهت داشتن ظاهری حرفه‌ای استفاده کنید."
---
## **نمای کلی**

Aspose.Slides for Python به شما امکان می‌دهد تا مکان‌دارهای header و footer را در سراسر یک ارائه با دامنه دقیق کنترل کنید. متن footer، تاریخ/زمان و شماره اسلایدها از سطح master مدیریت می‌شوند و می‌توانند به‌طور سراسری اعمال شوند یا برای هر اسلاید به‌صورت مجزا تنظیم شوند. Headerها در یادداشت‌ها و توزیعات پشتیبانی می‌شوند، جایی که می‌توانید قابلیت نمایش را به‌صورت روشن/خاموش تغییر داده و متن header، footer، تاریخ/زمان و شماره صفحه را از طریق مدیر اختصاصی header & footer در اسلاید master notes یا اسلایدهای یادداشت فردی تنظیم کنید. این مقاله الگوهای کلیدی برای به‌روزرسانی این مکان‌دارها و انتشار تغییرات به‌صورت یکنواخت در سراسر دک شما را شرح می‌دهد.

## **مدیریت متن Header و Footer**

در این بخش، یاد خواهید گرفت که چگونه محتوای header و footer را در یک ارائه مدیریت کنید—فعال یا اصلاح footer، تاریخ و زمان، و شماره اسلایدها. به‌صورت مختصر دامنه‌های اعمال این تنظیمات (تمام ارائه، اسلایدهای منفرد، و نمای یادداشت/توزیع) را شرح می‌دهیم و نشان می‌دهیم که چگونه با استفاده از Aspose.Slides API به‌سرعت و به‌صورت یکنواخت آن‌ها را به‌روزرسانی کنید.

مثال کد زیر یک ارائه را باز می‌کند، footer را فعال و متن آن را تنظیم می‌کند، متن header را در اسلاید master notes به‌روزرسانی می‌کند و فایل را ذخیره می‌نماید.

```py
import aspose.slides as slides

# تابعی برای تنظیم متن هدر.
def update_header_footer_text(master):
    for shape in master.shapes:
        if shape.placeholder is not None:
            if shape.placeholder.type == slides.PlaceholderType.HEADER:
                shape.text_frame.text = "Hi, there is a header"


# Load the presentation.
with slides.Presentation("sample.pptx") as presentation:
    # تنظیم فوتر.
    presentation.header_footer_manager.set_all_footers_text("My Footer text")
    presentation.header_footer_manager.set_all_footers_visibility(True)

    # دسترسی و به‌روزرسانی هدر.
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide
    if master_notes_slide is not None:
        update_header_footer_text(master_notes_slide)

    # ذخیرهٔ ارائه.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **مدیریت Header و Footer در اسلایدهای یادداشت**

در این بخش، نحوه مدیریت headerها و footerها به‌ویژه برای اسلایدهای یادداشت در Aspose.Slides را یاد خواهید گرفت. ما به فعال‌سازی مکان‌دارهای مربوطه، تنظیم متن برای footerها، تاریخ/زمان و شماره صفحه پرداخته و اعمال این تغییرات را به‌صورت یکنواخت در سراسر notes master و صفحات یادداشت منفرد بررسی می‌کنیم.

مراحل زیر را دنبال کنید:

1. یک فایل ارائه را بارگذاری کنید.
2. اسلاید master notes و [مدیر header & footer](https://reference.aspose.com/slides/fa/python-net/aspose.slides/masternotesslideheaderfootermanager/) آن را دریافت کنید.
3. در اسلاید master notes، قابلیت نمایش Header، Footer، شماره اسلاید و Date-time را برای master و همه اسلایدهای یادداشت فرزند فعال کنید.
4. در اسلاید master notes، متن Header، Footer و Date-time را برای master و همه اسلایدهای یادداشت فرزند تنظیم کنید.
5. اسلاید یادداشت مربوط به اولین اسلاید ارائه و [مدیر header & footer](https://reference.aspose.com/slides/fa/python-net/aspose.slides/notesslideheaderfootermanager/) آن را دریافت کنید.
6. فقط برای این اولین اسلاید یادداشت، اطمینان حاصل کنید که Header، Footer، شماره اسلاید و Date-time قابل مشاهده باشند (هر کدام که خاموش هستند را روشن کنید).
7. فقط برای این اولین اسلاید یادداشت، متن Header، Footer و Date-time را تنظیم کنید.
8. ارائه را در قالب PPTX ذخیره کنید.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide
    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        # قابلیت مشاهده اسلاید master notes و تمام فرزندهای مکان‌دارهای header، footer، شماره اسلاید و تاریخ/زمان را فعال کنید.
        header_footer_manager.set_header_and_child_headers_visibility(True)
        header_footer_manager.set_footer_and_child_footers_visibility(True)
        header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
        header_footer_manager.set_date_time_and_child_date_times_visibility(True)

        # متن را در اسلاید master notes و تمام فرزندهای مکان‌دارهای header، footer و تاریخ/زمان تنظیم کنید.
        header_footer_manager.set_header_and_child_headers_text("Header text")
        header_footer_manager.set_footer_and_child_footers_text("Footer text")
        header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    # تنظیمات header، footer، شماره اسلاید و تاریخ/زمان را فقط برای اولین اسلاید یادداشت تغییر دهید.
    notesSlide = presentation.slides[0].notes_slide_manager.notes_slide
    if notesSlide is not None:
        header_footer_manager = notesSlide.header_footer_manager

        # اطمینان حاصل کنید که مکان‌دارهای header، footer، شماره اسلید و تاریخ/زمان قابل مشاهده هستند.
        if not header_footer_manager.is_header_visible:
            header_footer_manager.set_header_visibility(True)

        if not header_footer_manager.is_footer_visible:
            header_footer_manager.set_footer_visibility(True)

        if not header_footer_manager.is_slide_number_visible:
            header_footer_manager.set_slide_number_visibility(True)

        if not header_footer_manager.is_date_time_visible:
            header_footer_manager.set_date_time_visibility(True)

        # متن را در مکان‌دارهای header، footer و تاریخ/زمان اسلاید یادداشت تنظیم کنید.
        header_footer_manager.set_header_text("New header text")
        header_footer_manager.set_footer_text("New footer text")
        header_footer_manager.set_date_time_text("New date and time text")

    # ذخیرهٔ ارائه.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **پرسش‌های متداول**

**آیا می‌توانم "header" را به اسلایدهای عادی اضافه کنم؟**

در PowerPoint، «Header» تنها برای یادداشت‌ها و توزیعات وجود دارد؛ در اسلایدهای عادی، المان‌های پشتیبانی‌شده شامل footer، تاریخ/زمان و شماره اسلاید هستند. در Aspose.Slides این محدودیت‌ها همانند قبلی هستند: header فقط برای Notes/Handout، و در اسلایدها—Footer/DateTime/SlideNumber.

**اگر لایه شامل ناحیه footer نباشد—آیا می‌توانم قابلیت مشاهده آن را "turn on" کنم؟**

بله. با استفاده از مدیر header/footer وضعیت نمایش را بررسی کنید و در صورت نیاز آن را فعال کنید. این نشانگرها و متدهای API برای مواردی طراحی شده‌اند که مکان‌دار موجود نیست یا مخفی شده است.

**چگونه شماره اسلاید را از مقدار غیر از 1 شروع کنم؟**

عدد [first slide number](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/first_slide_number/) ارائه را تنظیم کنید؛ پس از آن، تمام شماره‌گذاری‌ها دوباره محاسبه می‌شوند. به‌عنوان مثال، می‌توانید از 0 یا 10 شروع کنید و شماره را در اسلاید عنوان مخفی کنید.

**هنگام خروجی به PDF/تصاویر/HTML چه اتفاقی برای headerها/footerها می‌افتد؟**

آنها به‌عنوان عناصر متن عادی ارائه رندر می‌شوند. به این معنا که اگر این عناصر در اسلایدها/صفحات یادداشت قابل مشاهده باشند، در قالب خروجی نیز همراه با سایر محتوا نمایش داده می‌شوند.