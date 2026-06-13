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
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "ایجاد ارائه‌های PowerPoint در پایتون با Aspose.Slides—تولید فایل‌های PPT، PPTX و ODP، بهره‌برداری از پشتیبانی OpenDocument و ذخیره برنامه‌ریزی‌شده آنها برای نتایج قابل‌اطمینان."
---
## **بررسی کلی**

Aspose.Slides for Python به شما امکان می‌دهد یک فایل ارائه کاملاً جدید را به‌صورت کامل با کد بسازید. این مقاله جریان کاری اصلی را نشان می‌دهد—ایجاد یک شیء [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ، دریافت اسلاید اول ، افزودن یک شکل ساده و ذخیره نتیجه—تا ببینید برای تولید یک ارائه بدون Microsoft Office چقدر تنظیمات کم‌تری نیاز است. چون همان API می‌تواند فایل‌های PPT، PPTX و ODP را بنویسد، می‌توانید هر دو فرمت سنتی PowerPoint و OpenDocument را از یک پایه کد هدف‌گذاری کنید. Aspose.Slides برای محیط‌های دسکتاپ، وب یا سرور مناسب است و نقطه شروع کارآمدی برای برنامه Python شما فراهم می‌آورد تا پس از داشتن اسلایدهای اولیه، محتواهای غنی‌تری مانند متن، تصویر یا نمودار اضافه کنید.

## **ایجاد یک ارائه**

ایجاد یک فایل PowerPoint از ابتدا در Aspose.Slides for Python به‌سادگی ایجاد یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) است. سازنده به‌طور خودکار یک صفحهٔ خالی با یک اسلاید واحد فراهم می‌کند تا بلافاصله بتوانید برای اشکال، متن، نمودار یا هر محتوای دیگری که برنامه‌تان نیاز دارد، بوم کاری داشته باشید. پس از ویرایش آن اسلاید یا افزودن اسلایدهای جدید، می‌توانید نتیجه را به‌صورت PPTX، PPT قدیمی یا حتی فرمت‌های OpenDocument ذخیره کنید. نمونه کد کوتاه زیر این جریان کاری را با افزودن یک شکل ساده به اسلاید اول نشان می‌دهد.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.  
1. با استفاده از شاخص، به اسلاید ارجاع دهید.  
1. یک شیء [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) از نوع `CLOUD` با استفاده از متد `add_auto_shape` که در مجموعه `shapes` قرار دارد، اضافه کنید.  
1. متن را به این auto‑shape اضافه کنید.  
1. ارائهٔ اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

در مثال زیر، یک شکل ابری به اسلاید اول ارائه اضافه می‌شود.

```py
import aspose.slides as slides

# یک نمونه از کلاس Presentation که یک فایل ارائه را نمایندگی می‌کند را ایجاد کنید.
with slides.Presentation() as presentation:
    # اسلاید اول را دریافت کنید.
    slide = presentation.slides[0]

    # یک auto‑shape از نوع CLOUD اضافه کنید.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.CLOUD, 20, 20, 200, 80)
    auto_shape.text_frame.text = "Hello, Aspose!"

    # ارائه را به‌عنوان فایل PPTX ذخیره کنید.
    presentation.save("new_presentation.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![ارائه جدید](new_presentation.png)

## **سوالات متداول**

**چه قالب‌هایی را می‌توانم برای ذخیره یک ارائه جدید استفاده کنم؟**

می‌توانید به صورت [PPTX، PPT و ODP](/slides/fa/python-net/save-presentation/) ذخیره کنید و به [PDF](/slides/fa/python-net/convert-powerpoint-to-pdf/)، [XPS](/slides/fa/python-net/convert-powerpoint-to-xps/)، [HTML](/slides/fa/python-net/convert-powerpoint-to-html/)، [SVG](/slides/fa/python-net/convert-powerpoint-to-png/) و [images](/slides/fa/python-net/convert-powerpoint-to-png/) صادر کنید، و غیره.

**آیا می‌توانم از یک الگو (POTX/POTM) شروع کنم و به‌عنوان PPTX معمولی ذخیره کنم؟**

بله. الگو را بارگیری کنید و به قالب مورد نظر ذخیره کنید؛ قالب‌های POTX/POTM/PPTM و مشابه آن‌ها [پشتیبانی می‌شوند](/slides/fa/python-net/supported-file-formats/).

**چگونه می‌توانم اندازه/نسبت ابعاد اسلاید را هنگام ایجاد یک ارائه کنترل کنم؟**

حجم [اندازه اسلاید](/slides/fa/python-net/slide-size/) را تنظیم کنید (از جمله پیش‌تنظیم‌ها مثل 4:3 و 16:9 یا ابعاد سفارشی) و نحوهٔ مقیاس‌بندی محتوا را انتخاب کنید.

**واحدهای اندازه‌ها و مختصات به چه صورت هستند؟**

در نقطه‌ها: 1 اینچ برابر با 72 واحد است.

**چگونه می‌توانم ارائه‌های بسیار بزرگ (با فایل‌های رسانه‌ای زیاد) را برای کاهش مصرف حافظه مدیریت کنم؟**

از [استراتژی‌های مدیریت BLOB](/slides/fa/python-net/manage-blob/) استفاده کنید، ذخیره‌سازی در حافظه را با بهره‌گیری از فایل‌های موقت محدود کنید و به جای جریان‌های صرفاً در‑حافظه، گردش کار مبتنی بر فایل را ترجیح دهید.

**آیا می‌توانم ارائه‌ها را به‌صورت همزمان ایجاد/ذخیره کنم؟**

نمی‌توانید بر روی یک نمونه‌ی [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) از [چندین رشته](/slides/fa/python-net/multithreading/) کار کنید. برای هر رشته یا فرایند یک نمونه جداگانه داشته باشید.

**چگونه می‌توانم واترمارک و محدودیت‌های نسخه آزمایشی را حذف کنم؟**

[اعمال یک لایسنس](/slides/fa/python-net/licensing/) یک‌بار برای هر فرایند. XML لایسنس باید بدون تغییر باقی بماند و تنظیم لایسنس در صورت وجود چندین رشته باید هماهنگ شود.

**آیا می‌توانم فایل PPTX که ایجاد می‌کنم را به‌صورت دیجیتال امضا کنم؟**

بله. [امضاهای دیجیتال](/slides/fa/python-net/digital-signature-in-powerpoint/) (اضافه کردن و تأیید) برای ارائه‌ها پشتیبانی می‌شوند.

**آیا ماکروها (VBA) در ارائه‌های ایجاد شده پشتیبانی می‌شوند؟**

بله. می‌توانید [پروژه‌های VBA](/slides/fa/python-net/presentation-via-vba/) را ایجاد/ویرایش کنید و فایل‌های فعال‌ماکرو مانند PPTM/PPSM را ذخیره کنید.