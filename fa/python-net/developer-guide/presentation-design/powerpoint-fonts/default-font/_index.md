---
title: سفارشی‌سازی فونت‌های پیش‌فرض در ارائه‌ها با پایتون
linktitle: فونت پیش‌فرض
type: docs
weight: 30
url: /fa/python-net/default-font/
keywords:
- فونت پیش‌فرض
- فونت معمولی
- فونت عادی
- فونت آسیایی
- صادرات PDF
- صادرات XPS
- صادرات تصویر
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "فونت‌های پیش‌فرض را در Aspose.Slides برای پایتون تنظیم کنید تا تبدیل صحیح PowerPoint (PPT، PPTX) و OpenDocument (ODP) به PDF، XPS و تصاویر تضمین شود."
---
## **Overview**

Aspose.Slides به شما امکان می‌دهد فونت‌های پیش‌فرضی را که هنگام رندر ارائه استفاده می‌شوند، مشخص کنید. این برای تولید تصویر بندانگشتی اسلاید یا صادرات ارائه به فرمت‌هایی مانند PDF و XPS مفید است. فونت‌های پیش‌فرض از طریق `LoadOptions` قبل از بارگذاری ارائه پیکربندی می‌شوند.

خصوصیت `default_regular_font` فونت پیش‌فرض متن معمولی را تعریف می‌کند، در حالی که `default_asian_font` فونت پیش‌فرض متن آسیایی را تعیین می‌نماید. پس از تنظیم این گزینه‌ها، می‌توان ارائه را بارگذاری و با استفاده از فونت‌های مشخص شده رندر کرد.

## **Using Default Fonts for Rendering Presentation**
Aspose.Slides به شما اجازه می‌دهد فونت پیش‌فرض را برای رندر ارائه به PDF، XPS یا تصویرهای بندانگشتی تنظیم کنید. این مقاله نشان می‌دهد چگونه `DefaultRegularFont` و `DefaultAsianFont` را به‌عنوان فونت‌های پیش‌فرض تعریف کنید. لطفاً مراحل زیر را برای بارگذاری فونت‌ها از پوشه‌های خارجی با استفاده از Aspose.Slides for Python via .NET API دنبال کنید:

1. یک نمونه از LoadOptions ایجاد کنید.
1. `DefaultRegularFont` را به فونت مورد نظر خود تنظیم کنید. در مثال زیر از Wingdings استفاده شده است.
1. `DefaultAsianFont` را به فونت مورد نظر خود تنظیم کنید. در نمونه زیر نیز از Wingdings استفاده شده است.
1. ارائه را با استفاده از Presentation و تنظیم گزینه‌های بارگذاری بارگذاری کنید.
1. اکنون تصویر بندانگشتی اسلاید، PDF و XPS را تولید کنید تا نتایج را بررسی کنید.

پیاده‌سازی موارد فوق در زیر ارائه شده است.

```py
import aspose.slides as slides

# از گزینه‌های بارگذاری برای تعریف فونت‌های پیش‌فرض معمولی و آسیایی استفاده کنید# از گزینه‌های بارگذاری برای تعریف فونت‌های پیش‌فرض معمولی و آسیایی استفاده کنید
loadOptions = slides.LoadOptions(slides.LoadFormat.AUTO)
loadOptions.default_regular_font = "Wingdings"
loadOptions.default_asian_font = "Wingdings"

# ارائه را بارگذاری کنید
with slides.Presentation(path + "DefaultFonts.pptx", loadOptions) as pptx:
    # تصویر بندانگشتی اسلاید را تولید کنید
    with pptx.slides[0].get_image(1, 1) as img:
        img.save("output_out.png", slides.ImageFormat.PNG)

    # PDF را تولید کنید
    pptx.save("output_out.pdf", slides.export.SaveFormat.PDF)

    # XPS را تولید کنید
    pptx.save("output_out.xps", slides.export.SaveFormat.XPS)
```

## **FAQ**

**What exactly do default_regular_font and default_asian_font affect—only export, or also thumbnails, PDF, XPS, HTML, and SVG?**

آن‌ها در خط لوله رندر برای تمام خروجی‌های پشتیبانی‌شده شرکت می‌کنند. این شامل تصویر بندانگشتی اسلاید، [PDF](/slides/fa/python-net/convert-powerpoint-to-pdf/)، [XPS](/slides/fa/python-net/convert-powerpoint-to-xps/)، [raster images](/slides/fa/python-net/convert-powerpoint-to-png/)، [HTML](/slides/fa/python-net/convert-powerpoint-to-html/)، و [SVG](/slides/fa/python-net/render-a-slide-as-an-svg-image/) می‌شود، زیرا Aspose.Slides از منطق یکسان چیدمان و حل گلیف در این هدف‌ها استفاده می‌کند.

**Are default fonts applied when simply reading and saving a PPTX without any rendering?**

نه. فونت‌های پیش‌فرض زمانی مهم می‌شوند که متن باید اندازه‌گیری و رسم شود. یک باز‑ذخیره سادهٔ ارائه ساختار یا ران‌های فونت ذخیره‌شده را تغییر نمی‌دهد. فونت‌های پیش‌فرض در عملیات‌هایی که متن را رندر یا باز جریان می‌کنند، مؤثر می‌شوند.

**If I add my own font folders or supply fonts from memory, will they be considered when choosing default fonts?**

بله. [Custom font sources](/slides/fa/python-net/custom-font/) فهرست خانواده‌ها و گلیف‌های در دسترس را که موتور می‌تواند استفاده کند، گسترش می‌دهند. فونت‌های پیش‌فرض و هر [fallback rules](/slides/fa/python-net/fallback-font/) ابتدا نسبت به این منابع حل می‌شوند و پوشش قابل‌اعتماد‌تری در سرورها و کانتینرها فراهم می‌آورند.

**Will default fonts affect text metrics (kerning, advances) and therefore line breaks and wrapping?**

بله. تغییر فونت معیارهای گلیف را تغییر می‌دهد و می‌تواند شکست خطوط، بسته شدن متن و صفحه‌بندی را در هنگام رندر تحت تأثیر قرار دهد. برای پایداری چیدمان، [embed the original fonts](/slides/fa/python-net/embedded-font/) یا انتخاب خانواده‌های پیش‌فرض و فالو‌بکی که متریکاً سازگار هستند، توصیه می‌شود.

**Is there any point in setting default fonts if all fonts used in the presentation are embedded?**

اغلب نیازی به آن نیست، زیرا [embedded fonts](/slides/fa/python-net/embedded-font/) قبلاً ظاهر یکسان را تضمین می‌کنند. فونت‌های پیش‌فرض همچنان به‌عنوان یک شبکه ایمنی برای کاراکترهایی که توسط زیرمجموعهٔ جاسازی‌شده پوشش داده نمی‌شوند یا وقتی فایلی متن ترکیبی از متن جاسازی‌شده و غیرجاسازی دارد، مفید هستند.