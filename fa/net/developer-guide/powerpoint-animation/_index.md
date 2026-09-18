---
title: بهبود ارائه‌های پاورپوینت با انیمیشن‌ها در .NET
linktitle: انیمیشن پاورپوینت
type: docs
weight: 150
url: /fa/net/powerpoint-animation/
keywords:
- افزودن انیمیشن
- به‌روزرسانی انیمیشن
- تغییر انیمیشن
- حذف انیمیشن
- مدیریت انیمیشن
- کنترل انیمیشن
- افکت انیمیشن
- انیمیشن PowerPoint
- جدول زمانی انیمیشن
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
- .NET
- C#
- Aspose.Slides
description: "قابلیت‌های Aspose.Slides برای .NET در مدیریت انیمیشن‌های PowerPoint را بررسی کنید. این مرور کلی ویژگی‌های کلیدی را برجسته می‌کند و بینش‌هایی برای بهبود ارائه‌های شما ارائه می‌دهد."
---
## **معرفی**

چون ارائه‌ها برای نشان دادن چیزی ساخته می‌شوند، ظاهر بصری و رفتار تعاملی آن‌ها همیشه در حین ایجاد در نظر گرفته می‌شود.

**PowerPoint animation** نقش مهمی در جذاب و جلب توجه مخاطبان به ارائه دارد. Aspose.Slides برای .NET مجموعه وسیعی از گزینه‌ها را برای افزودن انیمیشن‌ها به ارائه‌های PowerPoint فراهم می‌کند:
- انواع مختلفی از افکت‌های انیمیشن PowerPoint را بر روی اشکال، نمودارها، جداول، اشیاء OLE و سایر عناصر ارائه اعمال کنید.
- چندین افکت انیمیشن PowerPoint را بر روی یک شکل استفاده کنید.
- از جدول زمانی انیمیشن برای کنترل افکت‌های انیمیشن استفاده کنید.
- انیمیشن‌های سفارشی ایجاد کنید.

در Aspose.Slides برای .NET، می‌توان انواع مختلفی از افکت‌های انیمیشن را بر روی اشکال اعمال کرد. از آنجا که هر عنصری روی یک اسلاید، شامل متن، تصاویر, اشیاء OLE و جداول، به‌عنوان یک شکل در نظر گرفته می‌شود، می‌توان افکت‌های انیمیشن را بر روی هر عنصر اسلاید اعمال کرد.

[Aspose.Slides.Animation](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/) namespace کلاس‌هایی را برای کار با انیمیشن‌های PowerPoint فراهم می‌کند.

## **افکت‌های انیمیشن**

Aspose.Slides از **بیش از 150 افکت انیمیشن** پشتیبانی می‌کند، از جمله افکت‌های پایه مانند Bounce، PathFootball و Zoom، و همچنین افکت‌های خاص مانند OLEObjectShow و OLEObjectOpen. می‌توانید فهرست کامل افکت‌های انیمیشن را در شمارش‌گر [EffectType](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/effecttype) پیدا کنید.

علاوه بر این، می‌توان این افکت‌های انیمیشن را همراه با موارد زیر ترکیب کرد:
- [ColorEffect](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/coloreffect)
- [CommandEffect](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/commandeffect)
- [FilterEffect](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/filtereffect)
- [MotionEffect](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/motioneffect)
- [PropertyEffect](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/propertyeffect)
- [RotationEffect](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/scaleeffect)
- [SetEffect](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/seteffect)

## **انیمیشن سفارشی**

برای مثال‌های کامل C# که ایجاد، بازرسی و تغییر رفتارها و مسیرهای حرکتی قابل ویرایش را نشان می‌دهند، به [انیمیشن سفارشی](/slides/fa/net/custom-animation/) مراجعه کنید.

در Aspose.Slides می‌توانید **انیمیشن‌های سفارشی** خود را ایجاد کنید. این کار با ترکیب چند رفتار در یک انیمیشن سفارشی جدید امکان‌پذیر است.

[Behavior](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/behavior) یک بلوک سازندهٔ افکت انیمیشن PowerPoint است. با ترکیب رفتارها می‌توانید افکتی را سفارشی کنید، یا یک رفتار اضافه کنید تا افکت از پیش تعریف‌شده را گسترش دهید. تکرار از طریق تنظیمات زمان‌بندی پیکربندی می‌شود نه از طریق رفتار تکرار جداگانه.

[Animation Point](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/point) نقطه‌ای است که در آن یک رفتار باید اعمال شود.

## **خط زمان انیمیشن**

[Sequence](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/sequence) مجموعه‌ای از افکت‌های انیمیشن است که می‌تواند هدف‌گذاری متفاوتی بر روی اشکال داشته باشد.

[Timeline](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/animationtimeline) مجموعه‌ای از توالی‌ها (sequences) است که در یک اسلاید خاص استفاده می‌شود. این یک موتور انیمیشن است که در PowerPoint 2002 معرفی شد. در نسخه‌های قبلی PowerPoint، افزودن افکت‌های انیمیشن به ارائه‌ها دشوار بود و فقط با راه‌حل‌های مختلف ممکن بود. جدول زمان‌بندی (timeline) کلاس قدیمی AnimationSettings را جایگزین می‌کند و یک مدل شیء واضح‌تر برای انیمیشن‌های PowerPoint فراهم می‌آورد. یک اسلاید می‌تواند فقط یک جدول زمان‌بندی انیمیشن داشته باشد.

## **انیمیشن تعاملی**

[Trigger](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/effecttriggertype) به شما امکان تعریف اقدامات کاربر (مثلاً کلیک دکمه) را می‌دهد که یک انیمیشن خاص را آغاز می‌کند. تریگرها در آخرین نسخه PowerPoint معرفی شدند.

## **انیمیشن شکل**

Aspose.Slides به شما امکان می‌دهد انیمیشن‌ها را بر روی اشکال اعمال کنید، که می‌توانند شامل متن، مستطیل‌ها، خطوط, فریم‌ها, اشیاء OLE و موارد دیگر باشند.

{{% alert color="info" title="Note" %}}
بیشتر بخوانید [**درباره انیمیشن شکل**](/slides/fa/net/shape-animation/).
{{% /alert %}}

## **نمودارهای انیمیشنی**

برای ایجاد نمودارهای انیمیشنی، باید از همان کلاس‌ها که برای اشکال استفاده می‌شود، بهره ببرید. با این حال، انیمیشن‌های PowerPoint فقط می‌توانند بر روی دسته‌بندی‌های نمودار یا سری‌های نمودار اعمال شوند. همچنین می‌توانید افکت‌های انیمیشن را بر روی یک عنصر دسته‌بندی یا عنصر سری اعمال کنید.

{{% alert color="info" title="Note" %}}
بیشتر بخوانید [**درباره نمودارهای انیمیشنی**](/slides/fa/net/animated-charts/).
{{% /alert %}}

## **متن انیمیشنی**

علاوه بر انیمیشن متن، می‌توانید انیمیشن را بر روی یک پاراگراف اعمال کنید.

{{% alert color="info" title="Note" %}}
بیشتر بخوانید [**درباره متن انیمیشنی**](/slides/fa/net/animated-text/).
{{% /alert %}}

## **سوالات متداول**

**آیا انیمیشن‌ها هنگام خروجی به PDF حفظ می‌شوند؟**

خیر. PDF یک فرمت ثابت است، بنابراین انیمیشن‌ها و [slide transitions](/slides/fa/net/slide-transition/) اجرا نمی‌شوند. اگر به حرکت نیاز دارید، به جای آن به [HTML5](/slides/fa/net/export-to-html5/)، [animated GIF](/slides/fa/net/convert-powerpoint-to-animated-gif/) یا [video](/slides/fa/net/convert-powerpoint-to-video/) خروجی بدهید.

**آیا می‌توانم یک ارائه انیمیشنی را به ویدیو تبدیل کنم و نرخ فریم و اندازه فریم را کنترل کنم؟**

بله. می‌توانید [render the presentation as frames](/slides/fa/net/convert-powerpoint-to-video/) را انجام دهید و آن‌ها را به یک ویدیو (مثلاً با ffmpeg) رمزگذاری کنید، با انتخاب FPS و وضوح تصویر. انیمیشن‌ها و slide transitions در حین رندر پخش می‌شوند.

**آیا انیمیشن‌ها هنگام کار با ODP (نه فقط PPTX) دست نخورده می‌مانند؟**

PPT، PPTX و ODP برای [reading](/slides/fa/net/open-presentation/) و [writing](/slides/fa/net/save-presentation/) پشتیبانی می‌شوند، اما این تضمین نمی‌کند که انیمیشن‌ها حفظ شوند. داده‌های انیمیشن سفارشی ممکن است هنگام تبدیل به ODP از دست بروند. برای مثال آزمایشی و محدودیت‌های فرمت، به [Custom Animation](/slides/fa/net/custom-animation/) مراجعه کنید.