---
title: ایجاد ارائه‌ها در پایتون
linktitle: ایجاد ارائه
type: docs
weight: 10
url: /fa/python-net/create-presentation/
keywords:
- ایجاد ارائه
- ارائه جدید
- ایجاد PPT
- PPT جدید
- ایجاد PPTX
- PPTX جدید
- ایجاد ODP
- ODP جدید
- پاورپوینت
- سند باز
- پایتون
- Aspose.Slides
description: "ایجاد ارائه‌های پاورپوینت در پایتون با Aspose.Slides — تولید فایل‌های PPT، PPTX و ODP، بهره‌مند شدن از پشتیبانی OpenDocument و ذخیره برنامه‌ای آن‌ها برای نتایج قابل اعتماد."
---
## **بررسی کلی**

این مقاله نشان می‌دهد چگونه با Aspose.Slides برای Python از طریق .NET یک ارائه ایجاد کنید، یک شکل متنی را به اسلاید اول آن اضافه کنید و نتیجه را به صورت فایل PPTX ذخیره نمایید. همان API همچنین ارائه‌ها را به‌صورت PPT و ODP ذخیره می‌کند، به‌طوری که می‌توانید هم قالب PowerPoint و هم OpenDocument را از یک پایه کد هدف‌گیری کنید، بدون نیاز به Microsoft Office. یک بخش پرسش‌های متداول کوتاه در انتها به سوالات رایج درباره فرمت‌ها، الگوها، اندازه‌گیری اسلاید، واحدها, مصرف حافظه, چندنخی, مجوزها, امضای دیجیتال و پشتیبانی VBA می‌پردازد.

قبل از شروع، بسته را از PyPI با `pip install aspose.slides` نصب کنید. برای کتابخانه‌هایی که لینوکس و macOS نیز به آن‌ها نیاز دارند و برای محیط مجازی که Python سیستمی توزیع‌های Debian و Ubuntu می‌طلبد، به بخش [Installation](/slides/fa/python-net/installation/) مراجعه کنید.

## **ایجاد یک ارائه**

برای ایجاد یک ارائه و قرار دادن یک شکل متنی روی اسلاید اول آن، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) ایجاد کنید. یک ارائه جدید از پیش شامل یک اسلاید خالی است.
2. آن اسلاید را از مجموعه [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/) با اندیس 0 دریافت کنید.
3. با استفاده از متد [add_auto_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_auto_shape/) مجموعهٔ [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/slide/shapes/) اسلاید، یک [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) به شکل ابر اضافه کنید و متن آن را با استفاده از [text](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/text/) تنظیم کنید.
4. ارائه را به عنوان فایل PPTX با متد [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) ذخیره کنید.

```py
import aspose.slides as slides

# یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است.
with slides.Presentation() as presentation:
    # دریافت اسلاید اول.
    slide = presentation.slides[0]

    # افزودن یک AutoShape از نوع CLOUD.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.CLOUD, 20, 20, 200, 80)
    auto_shape.text_frame.text = "Hello, Aspose!"

    # ذخیره ارائه به عنوان فایل PPTX.
    presentation.save("new_presentation.pptx", slides.export.SaveFormat.PPTX)
```

گوشهٔ بالای چپ ابر 20 پوینت از لبهٔ چپ و 20 پوینت از لبهٔ بالای اسلاید فاصله دارد و عرض ابر 200 پوینت و ارتفاع 80 پوینت است. عبارت `with` منابع ارائه را هنگام پایان بلوک آزاد می‌کند. اسکریپت *new_presentation.pptx* را در پوشهٔ جاری ذخیره می‌کند، با یک اسلاید که حاوی ابر و متن آن است. بدون داشتن لایسنس، Aspose.Slides همچنین یک واترمارک ارزیابی به هر اسلایدی که ذخیره می‌کند اضافه می‌نماید؛ برای جزئیات به بخش [Licensing](/slides/fa/python-net/licensing/) مراجعه کنید.

نتیجه:

![ارائه جدید](new_presentation.png)

## **پرسش‌های متداول**

### چه قالب‌هایی می‌توانم یک ارائه جدید را در آن ذخیره کنم؟

می‌توانید به فرمت‌های [PPTX, PPT و ODP](/slides/fa/python-net/save-presentation/) ذخیره کنید و به‌صورت [PDF](/slides/fa/python-net/convert-powerpoint-to-pdf/)، [XPS](/slides/fa/python-net/convert-powerpoint-to-xps/)، [HTML](/slides/fa/python-net/convert-powerpoint-to-html/)، [SVG](/slides/fa/python-net/render-a-slide-as-an-svg-image/) و [تصاویر](/slides/fa/python-net/convert-powerpoint-to-png/) نیز خروجی بگیرید، و غیره.

### آیا می‌توانم از یک الگو (POTX/POTM) شروع کنم و به‌صورت PPTX معمولی ذخیره کنم؟

بله. الگو را بارگذاری کنید و به فرمت موردنظر ذخیره کنید؛ قالب‌های POTX/POTM/PPTM و فرمت‌های مشابه [پشتیبانی می‌شوند](/slides/fa/python-net/supported-file-formats/).

### چگونه می‌توانم اندازه/نسبت تصویر اسلاید را هنگام ایجاد یک ارائه کنترل کنم؟

اندازهٔ [slide size](/slides/fa/python-net/slide-size/) را تنظیم کنید (از پیش‌تنظیم‌هایی مانند 4:3 و 16:9 یا ابعاد سفارشی) و نحوهٔ مقیاس‌گذاری محتوا را انتخاب کنید.

### اندازه‌ها و مختصات به چه واحدی اندازه‌گیری می‌شوند؟

به پوینت: 1 اینچ برابر 72 واحد است.

### چگونه می‌توانم ارائه‌های بسیار بزرگ (با تعداد زیادی فایل رسانه‌ای) را برای کاهش مصرف حافظه مدیریت کنم؟

از [BLOB management strategies](/slides/fa/python-net/manage-blob/) استفاده کنید، با بهره‌گیری از فایل‌های موقت ذخیره‌سازی در حافظه را محدود کنید و به‌جای جریان‌های صرفاً حافظه‌ای، گردش کارهای مبتنی بر فایل را ترجیح دهید.

### آیا می‌توانم ارائه‌ها را به‌صورت موازی ایجاد/ذخیره کنم؟

نمی‌توانید روی همان نمونهٔ [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) از [multiple threads](/slides/fa/python-net/multithreading/) کار کنید. برای هر ریسه یا فرآیند، نمونه‌های جداگانه و ایزوله اجرا کنید.

### چگونه می‌توانم واترمارک نسخه آزمایشی و محدودیت‌ها را حذف کنم؟

[Apply a license](/slides/fa/python-net/licensing/) را یک‌بار برای هر فرآیند اعمال کنید. XML لایسنس باید بدون تغییر باقی بماند و اگر ریسه‌های متعددی درگیر هستند، تنظیمات لایسنس باید همگام‌سازی شود.

### آیا می‌توانم فایل PPTX ایجاد شده را به‌صورت دیجیتال امضا کنم؟

بله. [Digital signatures](/slides/fa/python-net/digital-signature-in-powerpoint/) (اضافه کردن و تأیید) برای ارائه‌ها پشتیبانی می‌شوند.

### آیا ماکروها (VBA) در ارائه‌های ایجاد شده پشتیبانی می‌شوند؟

بله. می‌توانید [create/edit VBA projects](/slides/fa/python-net/presentation-via-vba/) کنید و فایل‌های فعال‌ماکرو مانند PPTM/PPSM را ذخیره کنید.