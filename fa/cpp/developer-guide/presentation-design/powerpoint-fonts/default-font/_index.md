---
title: مشخص کردن فونت‌های پیش‌فرض ارائه در C++
linktitle: فونت پیش‌فرض
type: docs
weight: 30
url: /fa/cpp/default-font/
keywords:
- فونت پیش‌فرض
- فونت معمولی
- فونت عادی
- فونت آسیایی
- خروجی PDF
- خروجی XPS
- خروجی تصویر
- پاورپوینت
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "تنظیم فونت‌های پیش‌فرض در Aspose.Slides برای C++ جهت اطمینان از تبدیل صحیح PowerPoint (PPT, PPTX) و OpenDocument (ODP) به PDF، XPS و تصاویر."
---
## **Overview**

Aspose.Slides به شما امکان می‌دهد فونت‌های پیش‌فرض را که هنگام رندر ارائه استفاده می‌شوند، مشخص کنید. این برای تولید تصویرهای کوچک اسلاید یا خروجی ارائه به قالب‌های مانند PDF و XPS مفید است. فونت‌های پیش‌فرض از طریق `LoadOptions` قبل از بارگذاری ارائه تنظیم می‌شوند.

متد `set_DefaultRegularFont` فونت پیش‌فرض برای متن معمولی را تعریف می‌کند، در حالی که `set_DefaultAsianFont` فونت پیش‌فرض برای متن آسیایی را تعریف می‌کند. پس از تنظیم این گزینه‌ها، می‌توان ارائه را بارگیری و با استفاده از فونت‌های مشخص شده رندر کرد.

## **Use Default Fonts for Rendering a Presentation**
Aspose.Slides به شما اجازه می‌دهد فونت پیش‌فرض را برای رندر ارائه به PDF، XPS یا تصویرهای کوچک تنظیم کنید. این مقاله نشان می‌دهد چگونه DefaultRegular Font و DefaultAsian Font را به عنوان فونت پیش‌فرض تعریف کنید. لطفاً مراحل زیر را برای بارگذاری فونت‌ها از پوشه‌های خارجی با استفاده از API Aspose.Slides برای C++ دنبال کنید:

1. یک نمونه از LoadOptions ایجاد کنید.
1. DefaultRegularFont را به فونت دلخواه خود تنظیم کنید. در مثال زیر از Wingdings استفاده کرده‌ام.
1. DefaultAsianFont را به فونت دلخواه خود تنظیم کنید. در نمونه زیر از Wingdings استفاده کرده‌ام.
1. ارائه را با استفاده از Presentation بارگیری کنید و گزینه‌های بارگذاری را تنظیم کنید.
1. حالا تصویر کوچک اسلاید، PDF و XPS را تولید کنید تا نتایج را بررسی کنید.

پیاده‌سازی موارد فوق در زیر آمده است.

```cpp
// از گزینه‌های بارگذاری برای تعیین فونت‌های پیش‌فرض معمولی و آسیایی استفاده کنید
auto loadOptions = MakeObject<LoadOptions>(LoadFormat::Auto);
loadOptions->set_DefaultRegularFont(u"Wingdings");
loadOptions->set_DefaultAsianFont(u"Wingdings");

auto pptx = MakeObject<Presentation>(u"DefaultFonts.pptx", loadOptions);

auto image = pptx->get_Slide(0)->GetImage(1, 1);
image->Save(u"DefaultFonts_out.png", ImageFormat::Png);
image->Dispose();

pptx->Save(u"DefaultFonts_out.pdf", SaveFormat::Pdf);
pptx->Save(u"DefaultFonts_out.xps", SaveFormat::Xps);

pptx->Dispose();
```

## **FAQ**

**دقیقا DefaultRegularFont و DefaultAsianFont چه تأثیری دارند—فقط خروجی یا همچنین تصویرهای کوچک، PDF، XPS، HTML و SVG؟**

آنها در خط لوله رندر برای تمام خروجی‌های پشتیبانی‌شده شرکت می‌کنند. این شامل تصویرهای کوچک اسلاید، [PDF](/slides/fa/cpp/convert-powerpoint-to-pdf/)، [XPS](/slides/fa/cpp/convert-powerpoint-to-xps/)، [raster images](/slides/fa/cpp/convert-powerpoint-to-png/), [HTML](/slides/fa/cpp/convert-powerpoint-to-html/)، و [SVG](/slides/fa/cpp/render-a-slide-as-an-svg-image/) هستند، زیرا Aspose.Slides از همان منطق چیدمان و حل گلیف در این هدف‌ها استفاده می‌کند.

**آیا فونت‌های پیش‌فرض هنگام فقط خواندن و ذخیره یک PPTX بدون رندر اعمال می‌شوند؟**

خیر. فونت‌های پیش‌فرض زمانی مهم هستند که متن باید اندازه‌گیری و رسم شود. یک ذخیره‌سازی باز‑باز مستقیم ارائه تغییری در فونت‌های ذخیره‌شده یا ساختار فایل ایجاد نمی‌کند. فونت‌های پیش‌فرض در عملیات‌هایی که متن را رندر یا بازچیدمان می‌کنند به کار می‌روند.

**اگر پوشه‌های فونت خود را اضافه کنم یا فونت‌ها را از حافظه تامین کنم، آیا در انتخاب فونت‌های پیش‌فرض در نظر گرفته می‌شوند؟**

بله. [Custom font sources](/slides/fa/cpp/custom-font/) فهرست خانواده‌ها و گلیف‌های موجود را که موتور می‌تواند استفاده کند، گسترش می‌دهند. فونت‌های پیش‌فرض و هر [fallback rules](/slides/fa/cpp/fallback-font/) ابتدا نسبت به این منابع حل می‌شوند و پوشش قابل‌اعتمادتری را در سرورها و کانتینرها فراهم می‌سازند.

**آیا فونت‌های پیش‌فرض بر معیارهای متن (کرنینگ، پیشروی) و در نتیجه شکست خطوط و پیچش تأثیر می‌گذارند؟**

بله. تغییر فونت معیارهای گلیف را تغییر می‌دهد و می‌تواند شکست خطوط، پیچش و صفحه‌بندی را در هنگام رندر تغییر دهد. برای پایداری چیدمان، [embed the original fonts](/slides/fa/cpp/embedded-font/) یا خانواده‌های پیش‌فرض و fallback متریکاً سازگار را انتخاب کنید.

**آیا تنظیم فونت‌های پیش‌فرض معنایی دارد اگر تمام فونت‌های استفاده‌شده در ارائه جاسازی شده باشند؟**

اغلب لازم نیست، زیرا [embedded fonts](/slides/fa/cpp/embedded-font/) از ظاهر یکسان اطمینان می‌دهند. فونت‌های پیش‌فرض همچنان به عنوان یک شبکه ایمنی برای کاراکترهایی که تحت پوشش زیرمجموعه جاسازی‌شده نیستند یا وقتی فایلی ترکیبی از متن جاسازی‌شده و غیرجاسازی دارد، مفید هستند.