---
title: تقویت ارائه‌های پاورپوینت با انیمیشن‌ها در پایتون
linktitle: انیمیشن پاورپوینت
type: docs
weight: 150
url: /fa/python-net/powerpoint-animation/
keywords:
- افزودن انیمیشن
- به‌روزرسانی انیمیشن
- تغییر انیمیشن
- حذف انیمیشن
- مدیریت انیمیشن
- کنترل انیمیشن
- اثر انیمیشن
- انیمیشن پاورپوینت
- خط زمانی انیمیشن
- انیمیشن تعاملی
- انیمیشن سفارشی
- انیمیشن شکل
- نمودار انیمیشنی
- متن انیمیشنی
- شکل انیمیشنی
- شیء OLE انیمیشنی
- تصویر انیمیشنی
- جدول انیمیشنی
- ارائه پاورپوینت
- پایتون
- Aspose.Slides
description: "قابلیت‌های Aspose.Slides برای پایتون از طریق .NET در مدیریت انیمیشن‌های پاورپوینت را بررسی کنید. این مرور کلی ویژگی‌های کلیدی را برجسته می‌سازد و بینش‌هایی برای بهبود ارائه‌های شما ارائه می‌دهد."
---
## **معرفی**

ارائه‌ها برای انتقال اطلاعات طراحی شده‌اند، بنابراین ظاهر بصری و رفتار تعاملی آنها از ملاحظات کلیدی هنگام ایجاد هستند.

**انیمیشن PowerPoint** نقش مهمی در جذاب و جلب توجه بینندگان به ارائه دارد. Aspose.Slides برای Python از طریق .NET گزینه‌های متنوعی برای افزودن انیمیشن به یک ارائه PowerPoint فراهم می‌کند. شما می‌توانید:
- اعمال انواع مختلف افکت‌های انیمیشن به اشکال، نمودارها، جداول، اشیای OLE و سایر عناصر.
- استفاده از چندین افکت انیمیشن بر روی یک شکل.
- کنترل افکت‌ها از طریق خط زمان انیمیشن.
- ایجاد انیمیشن‌های سفارشی.

در Aspose.Slides برای Python از طریق .NET، می‌توان افکت‌های انیمیشن را به اشکال اعمال کرد. از آنجا که هر عنصر در اسلاید—از جمله متن، تصاویر، اشیای OLE و جداول—به عنوان یک شکل در نظر گرفته می‌شود، می‌توانید افکت‌های انیمیشن را به هر عنصر در اسلاید اعمال کنید.

فضای نامی [aspose.slides.animation](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/) کلاس‌های مورد نیاز برای کار با انیمیشن‌های PowerPoint را فراهم می‌کند.

## **نصب**

```bash
pip install aspose.slides
```

## **افزودن افکت انیمیشن به یک شکل در Python**

افکت‌های انیمیشن در توالی اصلی اسلاید قرار می‌گیرند. یک شکل اضافه کنید، سپس `add_effect` را بر روی `slide.timeline.main_sequence` صدا بزنید و نوع افکت، زیرنوع آن و ماشینی که آن را شروع می‌کند را به عنوان پارامتر پاس کنید.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 100)
    shape.text_frame.text = "Animated shape"

    sequence = slide.timeline.main_sequence
    effect = sequence.add_effect(
        shape,
        slides.animation.EffectType.FLY,
        slides.animation.EffectSubtype.LEFT,
        slides.animation.EffectTriggerType.ON_CLICK,
    )
    effect.timing.duration = 2.0

    presentation.save("animated.pptx", slides.export.SaveFormat.PPTX)
```

فایل ذخیره‌شده شامل یک افکت در اسلاید اول است: مستطیل از سمت چپ به مدت دو ثانیه پرواز می‌کند وقتی ارائه‌دهنده کلیک می‌کند. با باز کردن مجدد آن و خواندن `slide.timeline.main_sequence` همان افکت بازگردانده می‌شود، بنابراین انیمیشن پس از گذر دورانی در حافظه باقی می‌ماند و فقط در حافظه ذخیره نمی‌شود.

## **افکت‌های انیمیشن**

Aspose.Slides از **بیش از 150 افکت انیمیشن** پشتیبانی می‌کند، از جمله افکت‌های پایه‌ای همچون Bounce، PathFootball و Zoom، و همچنین افکت‌های تخصصی مانند OLEObjectShow و OLEObjectOpen. می‌توانید لیست کامل را در شمارش‌گر [EffectType](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/effecttype/) بیابید.

علاوه بر این، این افکت‌های انیمیشن می‌توانند با افکت‌های زیر ترکیب شوند:
- [ColorEffect](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/seteffect/)

## **انیمیشن سفارشی**

برای مثال‌های کامل Python که ایجاد، بررسی و تغییر رفتارها و مسیرهای حرکتی قابل ویرایش را نشان می‌دهند، به [انیمیشن سفارشی](/slides/fa/python-net/custom-animation/) مراجعه کنید.

شما می‌توانید **انیمیشن‌های سفارشی** خود را در Aspose.Slides با ترکیب چند رفتار در یک افکت ایجاد کنید.

`[Behavior](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/behavior/)` یک قسمت سازنده افکت انیمیشن PowerPoint است. با ترکیب رفتارها می‌توانید یک افکت را سفارشی کنید، یا یک رفتار اضافه کنید تا افکت از پیش تعریف‌شده را گسترش دهید. تکرار از طریق تنظیمات زمان‌بندی پیکربندی می‌شود نه از طریق رفتار جداگانه‌ی تکرار.

`[Animation Point](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/point/)` لحظه یا موقعیتی را که رفتار در آن اعمال می‌شود (یک فریم کلیدی) نشان می‌دهد.

## **خط زمانی انیمیشن**

`[Sequence](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/sequence/)` مجموعه‌ای از افکت‌های انیمیشن است که می‌توانند به اشکال مختلف هدف‌گذاری شوند.

`[Timeline](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/animationtimeline/)` مجموعه‌ای از توالی‌ها است که در یک اسلاید خاص استفاده می‌شود. این قابلیت در PowerPoint 2002 معرفی شد. در نسخه‌های قبلی PowerPoint، افزودن افکت‌های انیمیشن دشوار بود و اغلب نیاز به راه‌حل‌های جایگزین داشت. Timeline جایگزین کلاس `AnimationSettings` قدیمی شده و مدل شیء واضح‌تری برای انیمیشن PowerPoint فراهم می‌کند. هر اسلاید فقط می‌تواند یک خط زمانی انیمیشن داشته باشد.

## **انیمیشن تعاملی**

`[Trigger](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/effecttriggertype/)` به شما امکان می‌دهد اعمال کاربر (مانند کلیک یک دکمه) را که یک انیمیشن خاص را شروع می‌کند، تعریف کنید. Triggerها فقط در آخرین نسخه‌های PowerPoint اضافه شدند.

## **انیمیشن شکل**

Aspose.Slides به شما اجازه می‌دهد انیمیشن‌ها را به شکل‌ها—مانند متن، مستطیل‌ها، خطوط، قاب‌ها، اشیای OLE و موارد دیگر—اعمال کنید.

{{% alert color="info" title="Note" %}}
بیشتر بخوانید [**درباره انیمیشن شکل**](/slides/fa/python-net/shape-animation/).
{{% /alert %}}

## **نمودارهای انیمیشنی**

برای ایجاد نمودارهای انیمیشنی، از همان کلاس‌هایی که برای شکل‌ها استفاده می‌کنید، بهره بگیرید. با این حال، انیمیشن‌های PowerPoint فقط می‌توانند به دسته‌های نمودار یا سری‌های نمودار اعمال شوند. همچنین می‌توانید یک افکت انیمیشن را به عنصر دسته‌ای یا عنصر سری‌ای منفرد اعمال کنید.

{{% alert color="info" title="Note" %}}
بیشتر بخوانید [**درباره نمودارهای انیمیشنی**](/slides/fa/python-net/animated-charts/).
{{% /alert %}}

## **متن انیمیشنی**

علاوه بر انیمیشن متن، می‌توانید انیمیشن را به یک پاراگراف نیز اعمال کنید.

{{% alert color="info" title="Note" %}}
بیشتر بخوانید [**درباره متن انیمیشنی**](/slides/fa/python-net/animated-text/).
{{% /alert %}}

## **سوالات متداول**

**آیا انیمیشن‌ها هنگام صادرات به PDF حفظ می‌شوند؟**

خیر. PDF یک قالب ثابت است، بنابراین انیمیشن‌ها و [انتقالات اسلاید](/slides/fa/python-net/slide-transition/) پخش نمی‌شوند. اگر به حرکت نیاز دارید، به جای آن به [HTML5](/slides/fa/python-net/export-to-html5/)، [animated GIF](/slides/fa/python-net/convert-powerpoint-to-animated-gif/) یا [video](/slides/fa/python-net/convert-powerpoint-to-video/) صادر کنید.

**آیا می‌توانم یک ارائه انیمیشنی را به ویدئو تبدیل کنم و نرخ فریم و اندازه فریم را کنترل کنم؟**

بله. می‌توانید [رندر کردن ارائه به فریم‌ها](/slides/fa/python-net/convert-powerpoint-to-video/) را انجام داده و آنها را با استفاده از ابزارهایی مانند ffmpeg به یک ویدئو تبدیل کنید، در حالی که FPS و وضوح را تنظیم می‌کنید. انیمیشن‌ها و انتقال‌های اسلاید در طول رندر پخش می‌شوند.

**آیا انیمیشن‌ها هنگام کار با ODP (نه فقط PPTX) دست نخورده می‌مانند؟**

PPT، PPTX و ODP برای [خواندن](/slides/fa/python-net/open-presentation/) و [نوشتن](/slides/fa/python-net/save-presentation/) پشتیبانی می‌شوند، اما این به معنای حفظ انیمیشن‌ها نیست. داده‌های انیمیشن سفارشی ممکن است هنگام تبدیل به ODP از دست بروند. برای مثال‌ها و راهنمایی درباره‌ بررسی سازگاری فرمت، به [انیمیشن سفارشی](/slides/fa/python-net/custom-animation/) مراجعه کنید.