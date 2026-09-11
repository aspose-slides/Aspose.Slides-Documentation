---
title: مشخص کردن قلم‌های پیش‌فرض ارائه در Python از طریق Java
linktitle: قلم پیش‌فرض
type: docs
weight: 30
url: /fa/python-java/default-font/
keywords:
- قلم پیش‌فرض
- قلم عادی
- قلم معمولی
- قلم آسیایی
- صدور PDF
- صدور XPS
- صدور تصویر
- PowerPoint
- OpenDocument
- ارائه
- Python
- Java
- Aspose.Slides
description: "قلم‌های پیش‌فرض را در Aspose.Slides برای Python از طریق Java تنظیم کنید تا تبدیل صحیح PowerPoint (PPT، PPTX) و OpenDocument (ODP) به PDF، XPS و تصاویر تضمین شود."
---
## **نمای کلی**

Aspose.Slides به شما امکان می‌دهد تا قلم‌های پیش‌فرضی را که هنگام رندر ارائه استفاده می‌شوند، مشخص کنید. این برای تولید تصویرهای کوچک اسلاید یا صادرات ارائه به قالب‌هایی مانند PDF و XPS مفید است. قلم‌های پیش‌فرض از طریق [LoadOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/loadoptions/) پیش از بارگذاری ارائه پیکربندی می‌شوند.

متد [setDefaultRegularFont](https://reference.aspose.com/slides/fa/python-java/aspose.slides/loadoptions/#setDefaultRegularFont) قلم پیش‌فرض برای متن عادی را تعریف می‌کند، در حالی که [setDefaultAsianFont](https://reference.aspose.com/slides/fa/python-java/aspose.slides/loadoptions/#setDefaultAsianFont) قلم پیش‌فرض برای متن‌های آسیایی را تعیین می‌کند. پس از تنظیم این گزینه‌ها، ارائه می‌تواند بارگذاری و رندر شود با استفاده از قلم‌های مشخص‌شده.

## **استفاده از قلم‌های پیش‌فرض برای رندر یک ارائه**

Aspose.Slides امکان تنظیم قلم‌های پیش‌فرض برای رندر یک ارائه به PDF، XPS یا تصویرهای کوچک را می‌دهد. این بخش نشان می‌دهد چگونه قلم‌های پیش‌فرض برای متن عادی و آسیایی با استفاده از Aspose.Slides برای Python از طریق Java تعریف شوند:

1. یک نمونه از [LoadOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/loadoptions/) ایجاد کنید.
2. از [setDefaultRegularFont](https://reference.aspose.com/slides/fa/python-java/aspose.slides/loadoptions/#setDefaultRegularFont) برای مشخص کردن قلم مورد نظر خود استفاده کنید. مثال زیر از Wingdings استفاده می‌کند.
3. از [setDefaultAsianFont](https://reference.aspose.com/slides/fa/python-java/aspose.slides/loadoptions/#setDefaultAsianFont) برای مشخص کردن قلم مورد نظر خود استفاده کنید. مثال زیر نیز از Wingdings استفاده می‌کند.
4. ارائه را با استفاده از [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) و گزینه‌های بارگذاری بارگذاری کنید.
5. تصویر کوچک اسلاید، PDF و XPS را تولید کنید تا نتایج را تأیید کنید.

مثال زیر این مراحل را پیاده‌سازی می‌کند:

```python
from asposeslides.api import ImageFormat, LoadFormat, LoadOptions, Presentation, SaveFormat

# از گزینه‌های بارگذاری برای تعریف قلم‌های پیش‌فرض عادی و آسیایی استفاده کنید.
load_options = LoadOptions(LoadFormat.Auto)
load_options.setDefaultRegularFont("Wingdings")
load_options.setDefaultAsianFont("Wingdings")

# ارائه را بارگذاری کنید.
presentation = Presentation("DefaultFonts.pptx", load_options)
try:
    # یک تصویر کوچک اسلاید تولید کنید.
    slide_image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0)
    try:
        # تصویر را روی دیسک ذخیره کنید.
        slide_image.save("output.png", ImageFormat.Png)
    finally:
        slide_image.dispose()

    # یک PDF تولید کنید.
    presentation.save("output_out.pdf", SaveFormat.Pdf)

    # یک سند XPS تولید کنید.
    presentation.save("output_out.xps", SaveFormat.Xps)
finally:
    presentation.dispose()
```

## **FAQ**

**فونت‌های پیش‌فرض عادی و آسیایی دقیقاً چه چیزی را تحت تأثیر قرار می‌دهند—فقط صادرات یا همچنین تصویرهای کوچک، PDF، XPS، HTML و SVG؟**

آنها در زنجیره رندر برای تمام خروجی‌های پشتیبانی‌شده شرکت می‌کنند. این شامل تصویرهای کوچک اسلاید، [PDF](/slides/fa/python-java/convert-powerpoint-to-pdf/)، [XPS](/slides/fa/python-java/convert-powerpoint-to-xps/)، [تصاویر رستر](/slides/fa/python-java/convert-powerpoint-to-png/)، [HTML](/slides/fa/python-java/convert-powerpoint-to-html/)، و [SVG](/slides/fa/python-java/render-a-slide-as-an-svg-image/) هستند، زیرا Aspose.Slides از همان منطق چیدمان و حل گلیف در این اهداف استفاده می‌کند.

**آیا قلم‌های پیش‌فرض هنگام فقط خواندن و ذخیره یک فایل PPTX بدون هیچ رندری اعمال می‌شوند؟**

خیر. قلم‌های پیش‌فرض زمانی اهمیت می‌یابند که متن باید اندازه‌گیری و رسم شود. یک باز‑ذخیره مستقیم یک ارائه، خطوط قلم ذخیره‌شده یا ساختار فایل را تغییر نمی‌دهد. قلم‌های پیش‌فرض در عملیات‌هایی که متن را رندر یا بازآرایی می‌کنند، به کار می‌روند.

**اگر پوشه‌های قلم خودم را اضافه کنم یا قلم‌ها را از حافظه فراهم کنم، آیا در انتخاب قلم‌های پیش‌فرض مدنظر قرار می‌گیرند؟**

بله. [منابع قلم سفارشی](/slides/fa/python-java/custom-font/) فهرست خانواده‌ها و گلیف‌های در دسترس که موتور می‌تواند از آنها استفاده کند را گسترش می‌دهند. قلم‌های پیش‌فرض و هر [قواعد بازگشتی](/slides/fa/python-java/fallback-font/) ابتدا در برابر این منابع حل می‌شوند و پوشش قابل اطمینان‌تری را در سرورها و کانتینرها ارائه می‌دهند.

**آیا قلم‌های پیش‌فرض بر متریک‌های متن (کرنینگ، پیشروی) و در نتیجه شکست خطوط و بسته‌بندی تأثیر می‌گذارند؟**

بله. تغییر قلم متریک‌های گلیف را تغییر می‌دهد و می‌تواند شکست خطوط، بسته‌بندی و صفحه‌بندی را در هنگام رندر تغییر دهد. برای پایداری چیدمان، [قلم‌های اصلی را جاسازی کنید](/slides/fa/python-java/embedded-font/) یا خانواده‌های پیش‌فرض و بازگشتی متریکاً سازگار را انتخاب کنید.

**آیا تنظیم قلم‌های پیش‌فرض مفیدی دارد اگر تمام قلم‌های استفاده شده در ارائه جاسازی شده باشند؟**

اغلب لازم نیست، زیرا [قلم‌های جاسازی‌شده](/slides/fa/python-java/embedded-font/) از پیش ظاهر یکسانی را تضمین می‌کنند. قلم‌های پیش‌فرض همچنان به عنوان یک شبکه ایمنی برای کاراکترهایی که توسط زیرمجموعه جاسازی‌شده پوشش داده نشده‌اند یا زمانی که فایلی متن‌های جاسازی‌شده و غیرجاسازی‌شده را ترکیب می‌کند، مفید هستند.