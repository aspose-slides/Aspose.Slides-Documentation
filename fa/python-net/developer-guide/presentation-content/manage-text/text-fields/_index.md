---
title: مدیریت میدانی‌های متنی در ارائه‌های PowerPoint در Python
linktitle: میدانی‌های متنی
type: docs
weight: 52
url: /fa/python-net/text-fields/
keywords:
- فیلد متنی
- متن خودکار
- شماره اسلاید
- تاریخ و زمان
- سربرگ
- پاورقی
- بخش متنی
- PowerPoint
- PPT
- PPTX
- Python
- Aspose.Slides
description: "ایجاد، بازبینی، تغییر و حذف میدانی‌های متنی در ارائه‌های PowerPoint با Aspose.Slides برای Python از طریق .NET. حفظ قالب‌بندی و تأیید فایل‌های PPTX و PPT ذخیره‌شده."
---
## **بررسی کلی**

یک پاراگراف متنی از بخش‌ها تشکیل شده است. یک [Portion](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portion/) عادی شامل متن واقعی است؛ یک بخش میدانی همچنین دارای یک [Field](https://reference.aspose.com/slides/fa/python-net/aspose.slides/field/) است که نوع آن مقدار خودکار به‌روز شده‌ای مانند شماره اسلاید یا تاریخ را شناسایی می‌کند. دو بخش می‌توانند همان کاراکترها را نمایش دهند در حالی که فقط یکی شامل یک میدانی است.

از [Portion.field](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portion/field/) برای تمایز آن‌ها استفاده کنید: برای متن عادی مقدار `None` است. [Portion.add_field](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portion/add_field/) یک بخش موجود را به میدانی تبدیل می‌کند. یک برچسب و مقدار پویا آن را در بخش‌های جداگانه نگه دارید تا تبدیل مقدار باعث جایگزینی برچسب نشود.

این راهنما به میدانی‌های داخل متن، قالب‌بندی آن‌ها و ذخیره‌سازی در قالب‌های PPTX و PPT می‌پردازد. برای فریم‌ها و پاراگراف‌های متنی، به صفحه [Manage Text](/slides/fa/python-net/manage-text/) مراجعه کنید.

## **ایجاد میدانی شماره اسلاید**

مثال کامل زیر یک جعبه متن ایجاد می‌کند که شامل یک برچسب واقعی `Slide ` و سپس یک شماره به‌روز شده خودکار است. قبل از افزودن میدانی، اندازه، وزن و رنگ عدد تنظیم می‌شود، سپس ارائهٔ ذخیره‌ شده بازخوانی می‌شود و نوع میدانی، متن و قالب‌بندی آن بررسی می‌گردد. هیچ فایل ورودی‌ای لازم نیست.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 240, 50)
    shape.add_text_frame("Slide ")
    paragraph = shape.text_frame.paragraphs[0]

    number_portion = slides.Portion()
    number_portion.portion_format.font_height = 24
    number_portion.portion_format.font_bold = slides.NullableBool.TRUE
    number_portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    number_portion.portion_format.fill_format.solid_fill_color.color = draw.Color.dark_blue
    paragraph.portions.add(number_portion)
    number_portion.add_field(slides.FieldType.slide_number)

    presentation.save("slide_number.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("slide_number.pptx") as reopened:
    saved_shape = reopened.slides[0].shapes[0]
    saved_number = saved_shape.text_frame.paragraphs[0].portions[1]
    has_number_field = saved_number.field is not None and saved_number.field.type.internal_string == slides.FieldType.slide_number.internal_string
    portion_format = saved_number.portion_format
    formatting_preserved = portion_format.font_height == 24 and portion_format.font_bold == slides.NullableBool.TRUE
    formatting_preserved &= portion_format.fill_format.solid_fill_color.color.to_argb() == draw.Color.dark_blue.to_argb()

    print(f"Text: {saved_shape.text_frame.text}")
    print(f"Slide number field: {has_number_field}")
    print(f"Formatting preserved: {formatting_preserved}")
```

ارائهٔ جدید با شماره اسلاید 1 شروع می‌شود، بنابراین متن `Slide 1` است و هر دو بررسی مقدار `True` را چاپ می‌کنند. بعد از بازخوانی، شماره به عنوان میدانی باقی می‌ماند؛ این یک `1` واقعی نیست. ایندکس‌های موجود در تأیید به شکل و بخش‌های ایجاد شده توسط این مثال اشاره دارند.

## **انتخاب نوع میدانی**

[FieldType](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fieldtype/) مقادیر پیش‌تعریف‌شده زیر را ارائه می‌دهد. مقدار مناسب را به [add_field](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portion/add_field/) پاس دهید.

| مقدار | هدف |
|---|---|
| [slide_number](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fieldtype/slide_number/) | شمارهٔ فعلی اسلاید. |
| [date_time](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fieldtype/date_time/) | تاریخ/زمان در قالب پیش‌فرض برنامهٔ رندرکننده. |
| [date_time1](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fieldtype/date_time1/)–[date_time9](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fieldtype/date_time9/) | قالب‌های پیش‌تعریف‌شدهٔ تاریخ یا ترکیب تاریخ/زمان. |
| [date_time10](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fieldtype/date_time10/)–[date_time13](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fieldtype/date_time13/) | قالب‌های پیش‌تعریف‌شدهٔ زمان، با گزینه‌های ثانیه و ساعت 12 ساعته. |
| [header](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fieldtype/header/) | میدانی هدر؛ محدودیت‌های جایگزین‌کننده و قالب در زیر را ببینید. |
| [footer](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fieldtype/footer/) | میدانی فوتر. |

به عنوان مثال، [date_time3](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fieldtype/date_time3/) نمایانگر روز، نام کامل ماه و سال به زبان انگلیسی است. این‌ها قالب‌های میدانی پیش‌تعریف‌شده هستند، نه رشته‌های دلخواه فرمت تاریخ پایتون. [language_id](https://reference.aspose.com/slides/fa/python-net/aspose.slides/baseportionformat/language_id/) بخش و برنامهٔ پردازش‌کنندهٔ ارائه می‌توانند بر نتیجهٔ نمایش‌شده تأثیر بگذارند.

## **ایجاد میدانی از یک رشته داخلی**

بارگذاری رشته‌ای [add_field](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portion/add_field/) یک شناسهٔ میدانی داخلی را می‌پذیرد. وقتی می‌خواهید شناسه‌ای را که توسط برنامهٔ دیگری ارائه شده و مقدار پیش‌تعریف‌شده‌ای ندارد حفظ کنید، از آن استفاده کنید. همچنین می‌توانید یک [FieldType](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fieldtype/__init__) از این شناسه بسازید. [FieldType.internal_string](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fieldtype/internal_string/) آن شناسه را برای بررسی در دسترس می‌گذارد.

این مثال یک میدانی `custom-report-id` مخصوص برنامه را همراه با متن پیش‌فرض `Report-042` ذخیره می‌کند. این شناسه محاسبه‌ای را ثبت نمی‌کند: Aspose.Slides برای نوع ناشناخته شناسه‌های گزارش تولید نمی‌کند. برنامه‌ای که این شناسه را می‌داند باید معنای آن را ارائه داده و مقدارش را به‌روز کند.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 300, 50)
    shape.add_text_frame("Report-042")
    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.add_field("custom-report-id")

    presentation.save("custom_field.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("custom_field.pptx") as reopened:
    saved_shape = reopened.slides[0].shapes[0]
    saved_portion = saved_shape.text_frame.paragraphs[0].portions[0]
    type_name = saved_portion.field.type.internal_string if saved_portion.field is not None else "ordinary text"
    print(f"Type: {type_name}")
    print(f"Text: {saved_portion.text}")
```

پس از این دوراندازی PPTX، نوع میدانی `custom-report-id` و متن `Report-042` باقی می‌مانند. ارسال رشته‌ای مانند `%Y-%m-%d` یک نوع میدانی را نام‌گذاری می‌کند؛ این یک قالب تاریخ سفارشی تنظیم نمی‌کند. برای تاریخ ثابت در قالب دلخواه، از متن عادی استفاده کنید.

## **بازبینی، تغییر و حذف میدانی‌های تاریخ/زمان**

یک میدانی موجود را از طریق [Field.type](https://reference.aspose.com/slides/fa/python-net/aspose.slides/field/type/) خوانده و تغییر دهید. قبل از دسترسی به نوع، وجود میدانی را بررسی کنید. برای متوقف کردن به‌روزرسانی‌های خودکار، [Portion.remove_field](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portion/remove_field/) را فراخوانی کنید. این کار بخش و متن فعلی آن را حفظ می‌کند در حالی که ارتباط میدانی را حذف می‌نماید. اگر به مقدار ثابت خاصی نیاز دارید، پس از حذف میدانی، متن را اختصاص دهید.

برای تنظیمات API مرتبط با پردازش میدانی‌های تاریخ/زمان، به [Presentation.current_date_time](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/current_date_time/) مراجعه کنید. مثال زیر از تاریخ تأیید صریح هنگام تبدیل میدانی به متن عادی استفاده می‌کند. یک تاپل نام ماه‌های انگلیسی تاریخ ثابت را مستقل از بومی‌سازی سیستم نگه می‌دارد.

فایل [sample.pptx](sample.pptx) را دانلود کرده و در پوشهٔ کاری قرار دهید. این فایل شامل دو شکل متنی با نام‌های `UpdatedAt` و `ApprovedDate` است که هر کدام یک میدانی تاریخ/زمان دارند، به‌علاوه برچسب‌های متن عادی. مثال زیر به شکل‌های متنی سطح بالا در اسلایدهای معمولی می‌پردازد. میدانی‌های تاریخ/زمان را به قالب تاریخ‑طویل تغییر داده و ایتالیک می‌کند، در حالی که دیگر قالب‌بندی‌هایشان حفظ می‌شود. تنها میدانی‌های موجود در `ApprovedDate` به متن ثابت تبدیل می‌گردند.

نمونه، شناسه‌های داخلی پیش‌ساختهٔ `datetime` تا `datetime13` را تشخیص می‌دهد. گروه‌ها، جدول‌ها، یادداشت‌ها، چیدمان‌ها و مسترها نیاز به پیمایش محفظه‌های متنی خود دارند و در محدودهٔ این مثال قرار ندارند.

```python
from datetime import date

import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    approval_date = date(2030, 4, 5)
    english_months = ("January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December")
    approval_text = f"{approval_date.day:02d} {english_months[approval_date.month - 1]} {approval_date.year}"
    date_time_types = {"datetime"} | {f"datetime{index}" for index in range(1, 14)}

    for slide in presentation.slides:
        for shape in slide.shapes:
            if not isinstance(shape, slides.AutoShape) or shape.text_frame is None:
                continue

            for paragraph in shape.text_frame.paragraphs:
                for portion in paragraph.portions:
                    field = portion.field
                    if field is None:
                        continue

                    if field.type.internal_string not in date_time_types:
                        continue

                    field.type = slides.FieldType.date_time3
                    portion.portion_format.language_id = "en-US"
                    portion.portion_format.font_italic = slides.NullableBool.TRUE

                    if shape.name == "ApprovedDate":
                        portion.remove_field()
                        portion.text = approval_text

    presentation.save("updated_dates.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("updated_dates.pptx") as reopened:
    for shape in reopened.slides[0].shapes:
        if not isinstance(shape, slides.AutoShape) or shape.text_frame is None:
            continue
        if shape.name not in {"UpdatedAt", "ApprovedDate"}:
            continue

        portion = shape.text_frame.paragraphs[0].portions[0]
        type_name = portion.field.type.internal_string if portion.field is not None else "ordinary text"
        print(f"{shape.name}: {type_name}; {portion.text}")
        print(f"Italic: {portion.portion_format.font_italic == slides.NullableBool.TRUE}")
```

بعد از بازخوانی، `UpdatedAt` نوع `datetime3` دارد و پویا می‌ماند. `ApprovedDate` میدانی ندارد و شامل `05 April 2030` است. هر دو بخش تاریخ ایتالیک هستند و اندازهٔ قلم، تنظیم bold و رنگ اصلی‌شان دست‌نخورده باقی می‌ماند. برچسب‌های متن عادی تغییری نکرده‌اند. تأیید، اولین بخش از دو شکل شناخته‌شده در نمونهٔ ارائه‌شده را می‌خواند.

## **حفظ قالب‌بندی متن**

در هنگام افزودن میدانی، تغییر نوع آن یا حذف، با بخش موجود کار کنید. این عملیات قالب‌بندی آن بخش را حفظ می‌کند. برای تغییر تنها خصوصیات مورد نیاز، مانند رنگ یا ایتالیک، از [Portion.portion_format](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portion/portion_format/) استفاده کنید، همان‌طور که مثال‌ها نشان می‌دهند.

از بازساخت یک فریم متنی کامل فقط برای به‌روزرسانی یک میدانی خودداری کنید: این کار می‌تواند مرزهای بخش‌های اصلی و قالب‌بندی فردی آن‌ها را از بین ببرد. همچنین قالب‌بندی صریحاً تنظیم‌شده را از قالب‌بندی به‌دست آمده از پاراگراف، چیدمان یا تم تمییز دهید. برای گزینه‌های گسترده‌تر قالب‌بندی به صفحهٔ [Text Formatting](/slides/fa/python-net/text-formatting/) مراجعه کنید.

## **میدانی‌ها و متغیرهای جایگزین هدر/فوتر**

یک میدانی بخشی از یک بخش متنی است. یک جایگزین (placeholder) یک شکل با نقش ارائه مثل فوتر یا شماره اسلاید است. افزودن میدانی به یک جعبه متن عادی، آن شکل را به جایگزین تبدیل نمی‌کند.

مدیران هدر/فوتر متن جایگزین و نمایش آن را در اسلایدها، چیدمان‌ها و مسترها، شامل انتشار به اسلایدهای وابسته، کنترل می‌کند. بنابراین یک میدانی عددی در یک جعبه متن سفارشی می‌تواند حتی زمانی که از جایگزین شماره اسلاید استفاده نمی‌کنید مفید باشد. برعکس، تغییر نمایش جایگزین میدانی را از یک جعبه متن نامرتبط حذف نمی‌کند.

انواع پیش‌تعریف‌شدهٔ هدر و فوتر، جایگزین‌های مربوطه را ایجاد یا محتوای آن‌ها را فراهم نمی‌کنند. به‌ویژه، یک اسلاید پاورپوینت معمولی جایگزین هدر ندارد؛ هدرها به صفحات یادداشت و جزوات تعلق دارند. فرض نکنید میدانی هدر یا فوتر در یک شکل دلخواه به‌طور خودکار متن تنظیم‌شده از طریق مدیر جایگزین را دریافت می‌کند. برای این جریان کاری، به صفحهٔ [Presentation Headers and Footers](/slides/fa/python-net/presentation-header-and-footer/) مراجعه کنید.

## **محدودیت‌های PPTX و PPT**

پس از ذخیره و بازخوانی، هر دو نوع میدانی و متن حاصل آن را بررسی کنید. حفظ یک شناسه نشان نمی‌دهد برنامه می‌تواند مقدار آن را محاسبه یا نمایش دهد.

| قالب | رفتار میدانی و محدودیت‌ها |
|---|---|
| PPTX | شناسه‌های میدانی داخلی را همراه با متن میدانی ذخیره می‌کند. در بررسی‌های دوراندازی، انواع پیش‌تعریف‌شده و شناسهٔ سفارشی استفاده‌شده در بالا پس از ذخیره و بازخوانی زنده ماندند. نوع سفارشی ناشناخته متن پیش‌فرض خود را حفظ کرد؛ منطق محاسبهٔ خودکار دریافت نکرد. برنامهٔ دیگری ممکن است شناسه‌های پشتیبانی‌نشده را به‌طرز متفاوتی مدیریت کند. |
| PPT | از نمایش‌های میدانی قدیمی استفاده می‌کند و سازگاری محدودتری دارد. در بررسی‌های دوراندازی، میدانی‌های شماره اسلاید و تاریخ/زمان پیش‌تعریف‌شده پس از ذخیره و بازخوانی زنده ماندند. یک میدانی سفارشی در جعبه متن اسلاید عادی با شناسه‌اش باز شد اما متن آن `*` بود؛ میدانی هدر در همان زمینه نیز `*` تولید کرد. به نگه داشتن متن قابل مشاهدهٔ میدانی‌های سفارشی یا زمینه‌های میدانی پشتیبانی‌نشده اعتماد نکنید. |

برای خروجی قابل حمل و ثابت، میدانی‌های پشتیبانی‌نشده را به متن عادی تبدیل کرده و پیش از ذخیره مقدار مورد نظر را به‌وضوح اختصاص دهید. این کار متن انتخاب‌شده را حفظ می‌کند اما به‌صورت عمدی به‌روزرسانی خودکار را متوقف می‌نماید. همچنین هنگامیکه بازمحاسبهٔ میدانی توسط برنامه هدف بخشی از جریان کاری شماست، برنامه هدف را آزمایش کنید.

## **سوالات متداول**

**چگونه می‌توانم تشخیص دهم که یک عدد یا تاریخ نمایش داده‌شده میدانی است؟**  
به [Portion.field](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portion/field/) نگاه کنید. مقداری غیر از `None` یک میدانی را شناسایی می‌کند؛ فقط متن نمایش داده‌شده به تنهایی نمی‌تواند این را بگوید.

**آیا حذف میدانی متن یا قالب‌بندی آن را نیز حذف می‌کند؟**  
خیر. [remove_field](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portion/remove_field/) بخش موجود را به متن عادی تبدیل می‌کند. اگر به مقدار ثابت خاصی نیاز دارید، پس از حذف میدانی، یک مقدار واضح اختصاص دهید.

**آیا یک رشته داخلی می‌تواند قالب تاریخ یا فرمول جدیدی تعریف کند؟**  
خیر. این رشته تنها نوع میدانی را شناسایی می‌کند. شناسهٔ ناشناخته ارزیاب یا الگوی فرمت تاریخ پایتون ارائه نمی‌دهد. از یک نوع پیش‌تعریف‌شدهٔ پشتیبانی‌شده استفاده کنید یا مقدار را خودتان به‌عنوان متن عادی قالب‌بندی کنید.

**چرا پس از ذخیره‌سازی ارائه را دوباره بررسی می‌کنیم؟**  
شناسه‌های میدانی، متن محاسبه‌شده و قالب‌بندی موارد جداگانه‌ای برای تأیید هستند. تبدیل قالب می‌تواند نتیجهٔ قابل مشاهده را تغییر دهد حتی اگر شناسه میدانی هنوز موجود باشد.