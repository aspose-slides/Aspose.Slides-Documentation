---
title: ذخیره ارائه‌ها در پایتون
linktitle: ذخیره ارائه‌ها
type: docs
weight: 80
url: /fa/python-net/save-presentation/
keywords:
- ذخیره پاورپوینت
- ذخیره OpenDocument
- ذخیره ارائه
- ذخیره اسلاید
- ذخیره PPT
- ذخیره PPTX
- ذخیره ODP
- ارائه به فایل
- ارائه به جریان
- نوع نمای پیش‌تعریف‌شده
- قالب Strict Office Open XML
- حالت Zip64
- تازه‌سازی تصویر بندانگشتی
- پیشرفت ذخیره‌سازی
- پایتون
- Aspose.Slides
description: "کشف کنید چگونه می‌توانید ارائه‌ها را در پایتون با استفاده از Aspose.Slides ذخیره کنید—به PowerPoint یا OpenDocument صادر کنید در حالی که طرح‌بندی‌ها، قلم‌ها و افکت‌ها حفظ می‌شوند."
---
## **بررسی کلی**

[باز کردن یک ارائه در پایتون](/slides/fa/python-net/open-presentation/) توضیح داد که چگونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) برای باز کردن یک ارائه استفاده شود. این مقاله نحوه ایجاد و ذخیره ارائه‌ها را شرح می‌دهد. کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) شامل محتوای یک ارائه است. چه از صفر ارائه‌ای را ایجاد کنید و چه یک ارائه موجود را اصلاح کنید، پس از اتمام می‌خواهید آن را ذخیره کنید. با Aspose.Slides for Python می‌توانید به **فایل** یا **جریان** ذخیره کنید. این مقاله روش‌های مختلف ذخیره یک ارائه را توضیح می‌دهد.

## **ذخیره ارائه‌ها به فایل‌ها**

برای ذخیره یک ارائه در یک فایل، متد `save` کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) را فراخوانی کنید. نام فایل و قالب ذخیره را به متد پاس دهید. مثال زیر نحوه ذخیره یک ارائه با Aspose.Slides for Python را نشان می‌دهد.

```py
import aspose.slides as slides

# یک شیء از کلاس Presentation که نمایانگر یک فایل ارائه است را ایجاد کنید.
with slides.Presentation() as presentation:
    
    # کاری را اینجا انجام دهید...

    # ارائه را در یک فایل ذخیره کنید.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **ذخیره ارائه‌ها به جریان‌ها**

می‌توانید یک ارائه را به یک جریان ذخیره کنید با پاس دادن جریان خروجی به متد `save` کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/). یک ارائه می‌تواند به انواع مختلفی از جریان‌ها نوشته شود. در مثال زیر، یک ارائه جدید ایجاد می‌کنیم و آن را به یک جریان فایل ذخیره می‌کنیم.

```py
import aspose.slides as slides

# یک شیء از کلاس Presentation که نمایانگر یک فایل ارائه است را ایجاد کنید.
with slides.Presentation() as presentation:
    with open("output.pptx", "bw") as file_stream:
        # ارائه را در جریان ذخیره کنید.
        presentation.save(file_stream, slides.export.SaveFormat.PPTX)
```

## **ذخیره ارائه‌ها با نوع نمای پیش‌تعریف‌شده**

Aspose.Slides for Python به شما امکان می‌دهد نمای اولیه‌ای که PowerPoint هنگام باز شدن ارائه تولید شده استفاده می‌کند، از طریق کلاس [ViewProperties](https://reference.aspose.com/slides/fa/python-net/aspose.slides/viewproperties/) تنظیم کنید. ویژگی `last_view` را به مقداری از شمارش [ViewType](https://reference.aspose.com/slides/fa/python-net/aspose.slides/viewtype/) تنظیم کنید.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("slide_master_view.pptx", slides.export.SaveFormat.PPTX)
```

## **ذخیره ارائه‌ها در قالب Strict Office Open XML**

Aspose.Slides به شما اجازه می‌دهد ارائه‌ای را در قالب Strict Office Open XML ذخیره کنید. از کلاس [PptxOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/pptxoptions/) استفاده کنید و هنگام ذخیره ویژگی conformance آن را تنظیم کنید. اگر `Conformance.ISO_29500_2008_STRICT` را تنظیم کنید، فایل خروجی در قالب Strict Office Open XML ذخیره می‌شود.

مثال زیر یک ارائه ایجاد می‌کند و آن را در قالب Strict Office Open XML ذخیره می‌کند.

```py
import aspose.slides as slides

options = slides.export.PptxOptions()
options.conformance = slides.export.Conformance.ISO_29500_2008_STRICT

# یک شیء از کلاس Presentation که نمایانگر یک فایل ارائه است را ایجاد کنید.
with slides.Presentation() as presentation:
    # ارائه را در قالب Strict Office Open XML ذخیره کنید.
    presentation.save("strict_office_open_xml.pptx", slides.export.SaveFormat.PPTX, options)
```

## **ذخیره ارائه‌ها در قالب Office Open XML در حالت Zip64**

یک فایل Office Open XML یک آرشیو ZIP است که محدودیت ۴ گیگابایت (۲^۳۲ بایت) برای اندازهٔ فشرده‌نشده هر فایل، اندازهٔ فشرده هر فایل و مجموع اندازهٔ آرشیو اعمال می‌کند و همچنین تعداد فایل‌ها را به ۶۵٬۵۳۵ (۲^۱۶‑۱) محدود می‌سازد. افزونه‌های فرمت ZIP64 این محدودیت‌ها را به ۲^۶۴ افزایش می‌دهند.

ویژگی [PptxOptions.zip_64_mode](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/pptxoptions/zip_64_mode/) به شما اجازه می‌دهد هنگام ذخیرهٔ یک فایل Office Open XML تصمیم بگیرید که از افزونه‌های فرمت ZIP64 استفاده شود یا نه.

این ویژگی حالت‌های زیر را فراهم می‌کند:

- `IF_NECESSARY` فقط در صورتی که ارائه از محدودیت‌های فوق فراتر رود از افزونه‌های ZIP64 استفاده می‌کند. این حالت پیش‌فرض است.
- `NEVER` هرگز از افزونه‌های ZIP64 استفاده نمی‌کند.
- `ALWAYS` همیشه از افزونه‌های ZIP64 استفاده می‌کند.

کد زیر نشان می‌دهد چگونه یک ارائه را به صورت فایل PPTX با افزونه‌های ZIP64 ذخیره کنید:

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.zip_64_mode = slides.export.Zip64Mode.ALWAYS

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output_zip64.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

{{% alert title="توجه" color="warning" %}}
هنگامی که با `Zip64Mode.NEVER` ذخیره می‌کنید، اگر ارائه نتواند در فرمت ZIP32 ذخیره شود، یک [PptxException](https://reference.aspose.com/slides/fa/python-net/aspose.slides/pptxexception/) پرتاب می‌شود.
{{% /alert %}}

## **ذخیره ارائه‌ها در قالب Office Open XML با سطوح فشرده‌سازی**

هنگام کار با ارائه‌های بزرگ می‌توانید سطح فشرده‌سازی را تنظیم کنید تا تعادل بین حجم فایل و زمان پردازش حفظ شود. بسته به نیازهای شما ممکن است پردازش سریع‌تر یا فایل‌های خروجی کوچک‌تر ترجیح داده شود.

Aspose.Slides ویژگی [PptxOptions.compression_level](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/pptxoptions/compression_level/) را فراهم می‌کند که به شما اجازه می‌دهد سطح فشرده‌سازی مورد استفاده هنگام ذخیرهٔ یک ارائه در قالب Office Open XML را مشخص کنید.

سطوح فشرده‌سازی موجود عبارتند از:

- [**NONE**](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/compressionlevel/): هیچ فشرده‌سازی‌ای اعمال نمی‌شود. فایل‌ها به همان صورت ذخیره می‌شوند.
- [**LEVEL1**](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/compressionlevel/): سریع‌ترین فشرده‌سازی با کم‌ترین نسبت فشرده‌سازی.
- [**LEVEL2**](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/compressionlevel/): فشرده‌سازی سریع‌تر با نسبت فشرده‌سازی کمی بهتر نسبت به **LEVEL1**.
- [**LEVEL3**](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/compressionlevel/): فشرده‌سازی بهتر نسبت به **LEVEL2** با تأثیر متوسط بر زمان پردازش.
- [**LEVEL4**](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/compressionlevel/): فشرده‌سازی بهتر نسبت به **LEVEL3**.
- [**LEVEL5**](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/compressionlevel/): فشرده‌سازی بهبود یافته نسبت به **LEVEL4** با زمان پردازش اضافی.
- [**LEVEL6**](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/compressionlevel/): فشرده‌سازی استاندارد که تعادل خوبی بین سرعت پردازش و حجم فایل فراهم می‌کند. این **سطح فشرده‌سازی پیش‌فرض** است.
- [**LEVEL7**](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/compressionlevel/): فشرده‌سازی بهتر نسبت به **LEVEL6** با پردازش آهسته‌تر.
- [**LEVEL8**](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/compressionlevel/): فشرده‌سازی بهتر نسبت به **LEVEL7**.
- [**LEVEL9**](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/compressionlevel/): حداکثر فشرده‌سازی. کوچک‌ترین حجم فایل را تولید می‌کند ولی بیشترین زمان پردازش را می‌طلبد.

مثال زیر نشان می‌دهد چگونه یک ارائه را به صورت فایل PPTX *بدون فشرده‌سازی* ذخیره کنید:

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.compression_level = slides.export.CompressionLevel.NONE

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("sample_out.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

این مثال نشان می‌دهد چگونه یک ارائه را به صورت فایل PPTX با *حداکثر فشرده‌سازی* ذخیره کنید:

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.compression_level = slides.export.CompressionLevel.LEVEL9

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("sample_level9.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

## **ذخیره ارائه‌ها بدون تازه‌سازی تصویر بندانگشتی**

ویژگی [PptxOptions.refresh_thumbnail](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/pptxoptions/refresh_thumbnail/) کنترل می‌کند که تصویر بندانگشتی هنگام ذخیرهٔ یک ارائه به PPTX تولید شود یا نه:

- اگر به `True` تنظیم شود، تصویر بندانگشتی در طول ذخیره تازه‌سازی می‌شود. این حالت پیش‌فرض است.
- اگر به `False` تنظیم شود، تصویر بندانگشتی فعلی حفظ می‌شود. اگر ارائه تصویر بندانگشتی نداشته باشد، هیچ‌کدام تولید نمی‌شود.

در کد زیر، ارائه بدون تازه‌سازی تصویر بندانگشتی به PPTX ذخیره می‌شود.

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.refresh_thumbnail = False

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

{{% alert title="اطلاعات" color="info" %}}
این گزینه به کاهش زمان لازم برای ذخیرهٔ یک ارائه در قالب PPTX کمک می‌کند.
{{% /alert %}}

{{% alert title="اطلاعات" color="info" %}}
Aspose یک [برنامه رایگان تقسیم‌کننده پاورپوینت](https://products.aspose.app/slides/fa/splitter) با استفاده از API خود توسعه داده است. این برنامه به شما امکان می‌دهد یک ارائه را به چندین فایل تقسیم کنید با ذخیره اسلایدهای انتخابی به‌عنوان فایل‌های جدید PPTX یا PPT.
{{% /alert %}}

## **سوالات متداول**

**آیا «ذخیره سریع» (ذخیره افزایشی) پشتیبانی می‌شود به‌طوری‌که فقط تغییرات نوشته شوند؟**

خیر. ذخیره هر بار فایل هدف کامل را ایجاد می‌کند؛ «ذخیره سریع» افزایشی پشتیبانی نمی‌شود.

**آیا ذخیرهٔ یک نمونهٔ Presentation از چندین رشته همزمان ایمن است؟**

خیر. یک نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) **ایمن برای استفادهٔ همزمان نیست**؛ آن را فقط از یک رشته ذخیره کنید.

**هنگام ذخیره چه اتفاقی برای پیوندهای ابرمتنی و فایل‌های خارجی لینک‌شده می‌افتد؟**

[پیوندهای ابرمتنی](/slides/fa/python-net/manage-hyperlinks/) حفظ می‌شوند. فایل‌های خارجی لینک‌شده (مثلاً ویدیوها با مسیرهای نسبی) به‌صورت خودکار کپی نمی‌شوند، بنابراین مسیرهای مرجع باید در دسترس بمانند.

**آیا می‌توانم متادیتای سند (نویسنده، عنوان، شرکت، تاریخ) را تنظیم/ذخیره کنم؟**

بله. **ویژگی‌های مستند** استاندارد [/slides/fa/python-net/presentation-properties/] پشتیبانی می‌شوند و هنگام ذخیره به فایل نوشته می‌شوند.