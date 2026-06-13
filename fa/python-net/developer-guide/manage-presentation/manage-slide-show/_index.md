---
title: مدیریت نمایش اسلاید در پایتون
linktitle: نمایش اسلاید
type: docs
weight: 90
url: /fa/python-net/manage-slide-show/
keywords:
- نوع نمایش
- ارائه‌شده توسط سخنران
- مرور شده توسط فرد
- مرور شده در کیوسک
- گزینه‌های نمایش
- حلقه مداوم
- نمایش بدون روایت
- نمایش بدون انیمیشن
- رنگ قلم
- نمایش اسلایدها
- نمایش سفارشی
- پیشروی اسلایدها
- به‌صورت دستی
- استفاده از زمان‌بندی‌ها
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "یاد بگیرید چگونه نمایش اسلایدها را در Aspose.Slides برای پایتون از طریق .NET مدیریت کنید. انتقال‌های اسلاید، زمان‌بندی‌ها و موارد دیگر را به‌راحتی در فرمت‌های PPT، PPTX و ODP کنترل کنید."
---
## **مقدمه**

در مایکروسافت پاورپوینت، تنظیمات **نمایش اسلاید** ابزاری کلیدی برای آماده‌سازی و ارائهٔ حرفه‌ای ارائه‌ها هستند. یکی از مهم‌ترین ویژگی‌های این بخش، **Set Up Show** است که به شما امکان می‌دهد ارائه‌تان را برای شرایط و مخاطبان خاص تنظیم کنید و انعطاف‌پذیری و راحتی را تضمین کنید. با این ویژگی می‌توانید نوع نمایش (مثلاً ارائه‌شده توسط سخنران، مرور شده توسط یک فرد، یا مرور شده در کیوسک)، فعال یا غیرفعال کردن حلقه، انتخاب اسلایدهای خاص برای نمایش و استفاده از زمان‌بندی‌ها را انتخاب کنید. این گام در تهیهٔ ارائه برای مؤثرتر و حرفه‌ای‌تر شدن آن حیاتی است.

`slide_show_settings` یک ویژگی از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) است که از نوع [SlideShowSettings](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slideshowsettings/) می‌باشد و به شما اجازه می‌دهد تنظیمات نمایش اسلاید را در یک ارائهٔ پاورپوینت مدیریت کنید. در این مقاله نحوهٔ استفاده از این ویژگی برای پیکربندی و کنترل جنبه‌های مختلف تنظیمات نمایش اسلاید بررسی می‌شود. 

## **انتخاب نوع نمایش**

`SlideShowSettings.slide_show_type` نوع نمایش اسلاید را تعریف می‌کند که می‌تواند نمونه‌ای از کلاس‌های زیر باشد: [PresentedBySpeaker](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentedbyspeaker/)، [BrowsedByIndividual](https://reference.aspose.com/slides/fa/python-net/aspose.slides/browsedbyindividual/)، یا [BrowsedAtKiosk](https://reference.aspose.com/slides/fa/python-net/aspose.slides/browsedatkiosk/). استفاده از این ویژگی به شما امکان می‌دهد ارائه را برای سناریوهای مختلف استفاده، مانند کیوسک‌های خودکار یا ارائه‌های دستی، تنظیم کنید.

کد نمونهٔ زیر یک ارائهٔ جدید ایجاد می‌کند و نوع نمایش را به «Browsed by an individual» تنظیم می‌کند بدون نمایش نوار اسکرول.

```py
with slides.Presentation() as presentation:

    show_type = slides.BrowsedByIndividual()
    show_type.show_scrollbar = False

    presentation.slide_show_settings.slide_show_type = show_type

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **فعال‌سازی گزینه‌های نمایش**

`SlideShowSettings.loop` تعیین می‌کند که آیا نمایش اسلاید باید تا توقف دستی به صورت حلقه تکرار شود یا خیر. این گزینه برای ارائه‌های خودکاری که باید به طور مداوم اجرا شوند مفید است. `SlideShowSettings.show_narration` مشخص می‌کند که آیا روایت صوتی باید در طول نمایش اسلاید پخش شود یا نه. این برای ارائه‌های خودکاری که شامل راهنمای صوتی برای مخاطب هستند کاربرد دارد. `SlideShowSettings.show_animation` تعیین می‌کند که آیا انیمیشن‌های اضافه‌شده به اشیای اسلاید باید پخش شوند یا خیر. این گزینه برای ارائهٔ کامل اثرات بصری مفید است.

کد نمونهٔ زیر یک ارائهٔ جدید ایجاد می‌کند و نمایش اسلاید را به صورت حلقه‌ای تنظیم می‌کند.

```py
with slides.Presentation() as presentation:

    presentation.slide_show_settings.loop = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **انتخاب اسلایدهای نمایشی**

ویژگی `SlideShowSettings.slides` به شما امکان می‌دهد بازه‌ای از اسلایدها را برای نمایش در طول ارائه انتخاب کنید. این گزینه زمانی مفید است که بخواهید تنها بخشی از ارائه را نمایش دهید و نه تمام اسلایدها. کد نمونهٔ زیر یک ارائهٔ جدید ایجاد می‌کند و بازهٔ اسلاید را از اسلایدهای `2` تا `9` تنظیم می‌کند.

```py
with slides.Presentation() as presentation:
    
    slide_range = slides.SlidesRange()
    slide_range.start = 2
    slide_range.end = 9

    presentation.slide_show_settings.slides = slide_range

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **استفاده از زمان‌بندی اسلایدها**

ویژگی `SlideShowSettings.use_timings` به شما اجازه می‌دهد استفاده از زمان‌بندی‌های پیش‌تنظیم شده برای هر اسلاید را فعال یا غیرفعال کنید. این گزینه برای نمایش خودکار اسلایدها با مدت زمان نمایش پیش‌تعریف‌شده مفید است. کد نمونهٔ زیر یک ارائهٔ جدید ایجاد می‌کند و استفاده از زمان‌بندی‌ها را غیرفعال می‌کند.

```py
with slides.Presentation() as presentation:

    presentation.slide_show_settings.use_timings = False

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **نمایش کنترل‌های رسانه‌ای**

ویژگی `SlideShowSettings.show_media_controls` تعیین می‌کند که آیا کنترل‌های رسانه‌ای (مانند پخش، توقف، و ایست) باید در طول نمایش اسلاید هنگام پخش محتوای چندرسانه‌ای (مثلاً ویدئو یا صدا) نمایش داده شوند یا خیر. این گزینه زمانی مفید است که بخواهید به ارائه‌دهنده امکان کنترل پخش رسانه‌ها را در طول ارائه بدهید.

کد نمونهٔ زیر یک ارائهٔ جدید ایجاد می‌کند و نمایش کنترل‌های رسانه‌ای را فعال می‌سازد.

```py
with slides.Presentation() as presentation:

    presentation.slide_show_settings.show_media_controls = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **سؤالات متداول**

**آیا می‌توانم یک ارائه را ذخیره کنم به‌طوری که مستقیماً در حالت نمایش اسلاید باز شود؟**

بله. فایل را به‌صورت PPSX یا PPSM ذخیره کنید؛ این فرمت‌ها هنگام باز شدن در پاورپوینت مستقیماً در حالت نمایش اسلاید اجرا می‌شوند. در Aspose.Slides، فرمت ذخیره‌سازی متناسب را در [during export](/slides/fa/python-net/save-presentation/) انتخاب کنید.

**آیا می‌توانم اسلایدهای فردی را از نمایش حذف کنم بدون اینکه آن‌ها را از فایل حذف کنم؟**

بله. یک اسلاید را به‌عنوان [hidden](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slide/hidden/) علامت‌گذاری کنید. اسلایدهای مخفی در ارائه باقی می‌مانند اما در طول نمایش اسلاید نمایش داده نمی‌شوند.

**آیا Aspose.Slides می‌تواند یک نمایش اسلاید را پخش کند یا یک ارائهٔ زنده را بر روی صفحه کنترل کند؟**

نه. Aspose.Slides فایل‌های ارائه را ویرایش، تجزیه و تحلیل و تبدیل می‌کند؛ پخش واقعی توسط برنامه‌ای همچون پاورپوینت انجام می‌شود.