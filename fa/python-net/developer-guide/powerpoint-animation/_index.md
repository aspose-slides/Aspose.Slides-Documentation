---
title: بهبود ارائه‌های PowerPoint با انیمیشن‌ها در Python
linktitle: انیمیشن PowerPoint
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
- انیمیشن PowerPoint
- جدول زمان‌بندی انیمیشن
- انیمیشن تعاملی
- انیمیشن سفارشی
- انیمیشن شکل
- نمودار انیمیشنی
- متن انیمیشنی
- شکل انیمیشنی
- شیء OLE انیمیشنی
- تصویر انیمیشنی
- جدول انیمیشنی
- ارائه PowerPoint
- Python
- Aspose.Slides
description: "قابلیت‌های Aspose.Slides برای Python از طریق .NET در پردازش انیمیشن‌های PowerPoint را بررسی کنید. این مرور کلی ویژگی‌های کلیدی را برجسته می‌کند و بینش‌هایی برای بهبود ارائه‌های شما ارائه می‌دهد."
---
## **مقدمه**

ارایه‌ها به‌منظور انتقال اطلاعات طراحی می‌شوند، بنابراین ظاهر بصری و رفتار تعاملی آن‌ها از نکات کلیدی در هنگام ایجاد هستند.

**انیمیشن PowerPoint** نقش مهمی در جذاب و جلب توجه بینندگان به ارائه دارد. Aspose.Slides for Python via .NET گزینه‌های گسترده‌ای برای افزودن انیمیشن به یک ارائه PowerPoint ارائه می‌دهد. شما می‌توانید:

- اعمال اثرات انیمیشن مختلف به اشکال، نمودارها، جدول‌ها، اشیای OLE و سایر عناصر.
- استفاده از چندین اثر انیمیشن روی یک شکل.
- کنترل اثرات از طریق جدول زمانبندی انیمیشن.
- ایجاد انیمیشن‌های سفارشی.

در Aspose.Slides for Python via .NET، می‌توان اثرات انیمیشن را بر روی اشکال اعمال کرد. چون هر عنصر در یک اسلاید — شامل متن، تصاویر، اشیای OLE و جدول‌ها — به‌عنوان یک شکل در نظر گرفته می‌شود، می‌توانید اثرات انیمیشن را بر روی هر عنصر در اسلاید اعمال کنید.

فضای‌نام [aspose.slides.animation](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/) کلاس‌هایی برای کار با انیمیشن‌های PowerPoint فراهم می‌کند.

## **نصب**

```bash
pip install aspose.slides
```

## **افزودن اثر انیمیشن به یک شکل در Python**

اثرهای انیمیشن در توالی اصلی یک اسلاید قرار می‌گیرند. یک شکل اضافه کنید، سپس `add_effect` را روی `slide.timeline.main_sequence` صدا بزنید و نوع اثر، زیرنوع آن و ماشقی که آن را شروع می‌کند را پاس بدهید.

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

فایل ذخیره‌شده شامل یک اثر در اسلاید اول است: مستطیل از سمت چپ پرواز می‌کند و در طول دو ثانیه هنگام کلیک ارائه‌دهنده ظاهر می‌شود. بازگشایی مجدد و خواندن `slide.timeline.main_sequence` همان اثر را برمی‌گرداند، بنابراین انیمیشن پس از رفت و آمد حفظ می‌شود و فقط در حافظه باقی نمی‌ماند.

## **اثرهای انیمیشن**

Aspose.Slides از **بیش از 150 اثر انیمیشن** پشتیبانی می‌کند، از جمله اثرات پایه‌ای مانند Bounce، PathFootball و Zoom، و همچنین اثرات تخصصی مانند OLEObjectShow و OLEObjectOpen. می‌توانید فهرست کامل را در شمارش [EffectType](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/effecttype/) بیابید.

علاوه بر این، این اثرهای انیمیشن می‌توانند با اثرهای زیر ترکیب شوند:

- [ColorEffect](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/seteffect/)

## **انیمیشن سفارشی**

می‌توانید **انیمیشن‌های سفارشی** خود را در Aspose.Slides با ترکیب چند رفتار در یک اثر ایجاد کنید.

[Behavior](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/behavior/) بلوک ساختاری پایه هر اثر انیمیشن PowerPoint است. هر اثر انیمیشن در اصل مجموعه‌ای از رفتارهاست که در یک استراتژی یا جدول زمان‌بندی چیدمان می‌شوند. می‌توانید رفتارها را یک‌بار در یک انیمیشن سفارشی ترکیب کنید و سپس در ارائه‌های دیگر باز استفاده کنید. اگر رفتار جدیدی به یک اثر انیمیشن استاندارد PowerPoint اضافه کنید، آن تبدیل به انیمیشن سفارشی می‌شود — برای مثال، افزودن رفتار تکرار برای پخش چندبارهٔ انیمیشن.

[Animation Point](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/point/) لحظه یا موقعیتی را نشان می‌دهد که در آن یک رفتار اعمال می‌شود (یک فریم کلیدی).

## **خط زمان انیمیشن**

[Sequence](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/sequence/) مجموعه‌ای از اثرهای انیمیشن است که بر روی یک شکل خاص اعمال می‌شوند.

[Timeline](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/animationtimeline/) مجموعه‌ای از توالی‌هاست که در یک اسلاید خاص استفاده می‌شود. این ویژگی در PowerPoint 2002 معرفی شد. در نسخه‌های قبلی PowerPoint، افزودن اثرهای انیمیشن دشوار بود و اغلب نیاز به راه‌حل‌های جایگزین داشت. Timeline جایگزین کلاس قدیمی `AnimationSettings` می‌شود و مدلی واضح‌تر از اشیاء انیمیشن PowerPoint ارائه می‌دهد. هر اسلاید می‌تواند فقط یک جدول زمانبندی انیمیشن داشته باشد.

## **انیمیشن تعاملی**

[Trigger](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/effecttriggertype/) به شما اجازه می‌دهد تا اقدامات کاربر (مانند کلیک روی یک دکمه) را که یک انیمیشن خاص را آغاز می‌کند، تعریف کنید. ماشه‌ها تنها در نسخه‌های جدید PowerPoint اضافه شده‌اند.

## **انیمیشن شکل‌ها**

Aspose.Slides به شما امکان می‌دهد انیمیشن‌ها را بر روی اشکال اعمال کنید — مانند متن، مستطیل‌ها، خطوط، فریم‌ها، اشیای OLE و غیره.

{{% alert color="primary" %}}
ادامه مطلب [**About Shape Animation**](/slides/fa/python-net/shape-animation/)
{{% /alert %}}

## **نمودارهای انیمیشنی**

برای ایجاد نمودارهای انیمیشنی، از همان کلاس‌هایی که برای اشکال استفاده می‌کنید بهره ببرید. اما انیمیشن‌های PowerPoint فقط می‌توانند بر روی دسته‌های نمودار یا سری‌های نمودار اعمال شوند. همچنین می‌توانید یک اثر انیمیشن را بر روی یک عنصر دسته‌ای یا عنصر سری‌ای به‌صورت جداگانه اعمال کنید.

{{% alert color="primary" %}}
ادامه مطلب [**About Animated Charts**](/slides/fa/python-net/animated-charts/)
{{% /alert %}}

## **متن انیمیشنی**

علاوه بر انیمیشن متن، می‌توانید انیمیشن را بر روی یک پاراگراف اعمال کنید.

{{% alert color="primary" %}}
ادامه مطلب [**About Animated Text**](/slides/fa/python-net/animated-text/)
{{% /alert %}}

## **سوالات متداول**

### آیا انیمیشن‌ها هنگام صادرات به PDF حفظ می‌شوند؟

خیر. PDF یک قالب ثابت است، بنابراین انیمیشن‌ها و [slide transitions](/slides/fa/python-net/slide-transition/) اجرا نمی‌شوند. اگر به حرکت نیاز دارید، به جای آن به [HTML5](/slides/fa/python-net/export-to-html5/)، [animated GIF](/slides/fa/python-net/convert-powerpoint-to-animated-gif/)، یا [video](/slides/fa/python-net/convert-powerpoint-to-video/) صادر کنید.

### آیا می‌توانم یک ارائه انیمیشنی را به ویدیو تبدیل کنم و نرخ فریم و اندازه فریم را کنترل کنم؟

بله. می‌توانید [render the presentation as frames](/slides/fa/python-net/convert-powerpoint-to-video/) را اجرا کنید و آنها را به یک ویدیو (مثلاً با ffmpeg) تبدیل کنید، ضمن انتخاب FPS و وضوح تصویر. در طول رندر، انیمیشن‌ها و انتقال اسلاید اجرا می‌شوند.

### آیا انیمیشن‌ها هنگام کار با ODP (نه فقط PPTX) دست نخورده می‌مانند؟

قالب‌های PPT، PPTX و ODP برای [reading](/slides/fa/python-net/open-presentation/) و [writing](/slides/fa/python-net/save-presentation/) پشتیبانی می‌شوند، اما تفاوت‌های قالب می‌تواند باعث شود برخی اثرها کمی متفاوت ظاهر شوند یا رفتار کنند. موارد بحرانی را با نمونه‌های واقعی اعتبارسنجی کنید.