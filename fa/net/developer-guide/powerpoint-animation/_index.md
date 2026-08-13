---
title: بهبود ارائه‌های PowerPoint با انیمیشن‌ها در .NET
linktitle: انیمیشن PowerPoint
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
- اثر انیمیشن
- انیمیشن PowerPoint
- جدول زمانی انیمیشن
- انیمیشن تعاملی
- انیمیشن سفارشی
- انیمیشن شکل
- نمودار متحرک
- متن متحرک
- شکل متحرک
- شیء OLE متحرک
- تصویر متحرک
- جدول متحرک
- ارائه PowerPoint
- .NET
- C#
- Aspose.Slides
description: "قابلیت‌های Aspose.Slides برای .NET در پردازش انیمیشن‌های PowerPoint را بررسی کنید. این مرور کلی ویژگی‌های کلیدی را برجسته می‌کند و بینش‌هایی برای بهبود ارائه‌های شما ارائه می‌دهد."
---
## **معرفی**

از آنجا که ارائه‌ها برای نمایش چیزی ساخته می‌شوند، ظاهر بصری و رفتار تعاملی آن‌ها همواره در طول ایجاد در نظر گرفته می‌شود.

**انیمیشن PowerPoint** نقش مهمی در جذاب و گیرایی یک ارائه برای بینندگان دارد. Aspose.Slides for .NET گزینه‌های متنوعی برای افزودن انیمیشن به ارائه‌های PowerPoint فراهم می‌کند:

- انواع مختلفی از افکت‌های انیمیشن PowerPoint را روی اشکال، نمودارها، جدول‌ها، اشیای OLE و سایر عناصر ارائه اعمال کنید.
- چندین افکت انیمیشن PowerPoint را بر روی یک شکل به‌کار ببرید.
- از جدول زمانی انیمیشن برای کنترل افکت‌های انیمیشن استفاده کنید.
- ایجاد انیمیشن‌های سفارشی.

در Aspose.Slides for .NET می‌توان انواع مختلفی از افکت‌های انیمیشن را بر روی اشکال اعمال کرد. از آنجا که هر عنصر روی اسلاید، شامل متن، تصویر، اشیای OLE و جدول‌ها، به‌عنوان یک شکل در نظر گرفته می‌شود، افکت‌های انیمیشن می‌توانند بر روی هر عنصر روی اسلاید اعمال شوند.

[Aspose.Slides.Animation](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/) namespace کلاس‌هایی را برای کار با انیمیشن‌های PowerPoint فراهم می‌کند.

## **افکت‌های انیمیشن**

Aspose.Slides از **بیش از 150 افکت انیمیشن** پشتیبانی می‌کند، از جمله افکت‌های پایه‌ای مانند Bounce، PathFootball و Zoom، و همچنین افکت‌های خاص مانند OLEObjectShow و OLEObjectOpen. می‌توانید فهرست کامل افکت‌های انیمیشن را در شمارش‌نامه [EffectType](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/effecttype) بیابید.

علاوه بر این، این افکت‌های انیمیشن می‌توانند همراه با موارد زیر استفاده شوند:
- [ColorEffect](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/coloreffect)
- [CommandEffect](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/commandeffect)
- [FilterEffect](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/filtereffect)
- [MotionEffect](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/motioneffect)
- [PropertyEffect](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/propertyeffect)
- [RotationEffect](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/scaleeffect)
- [SetEffect](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/seteffect)

## **انیمیشن سفارشی**

در Aspose.Slides می‌توانید **انیمیشن‌های سفارشی** خود را ایجاد کنید. این کار با ترکیب چند رفتار در یک انیمیشن سفارشی جدید امکان‌پذیر است.

[Behaviour](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/behavior) یک بلوک سازنده برای هر افکت انیمیشن PowerPoint است. تمام افکت‌های انیمیشن در واقع مجموعه‌ای از رفتارها هستند که در یک استراتژی ترکیب می‌شوند. می‌توانید رفتارها را یک‌بار در یک انیمیشن سفارشی ترکیب کنید و سپس در ارائه‌های دیگر دوباره استفاده کنید. اگر یک رفتار جدید به یک افکت انیمیشن استاندارد PowerPoint اضافه کنید، آن تبدیل به یک انیمیشن سفارشی دیگر می‌شود. به‌عنوان مثال، می‌توانید یک رفتار تکرار به یک انیمیشن اضافه کنید تا چند بار تکرار شود.

[Animation Point](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/point) نقطه‌ای است که رفتار باید در آن اعمال شود.

## **خط زمانی انیمیشن**

[Sequence](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/sequence) مجموعه‌ای از افکت‌های انیمیشن است که بر روی یک شکل خاص اعمال می‌شوند.

[Timeline](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/animationtimeline) مجموعه‌ای از توالی‌هاست که در یک اسلاید خاص استفاده می‌شود. این یک موتور انیمیشن است که در PowerPoint 2002 معرفی شد. در نسخه‌های قبلی PowerPoint، افزودن افکت‌های انیمیشن به ارائه‌ها دشوار بود و تنها با راه‌حل‌های مختلف می‌توانست انجام شود. جدول زمانی جایگزین کلاس AnimationSettings قدیمی شده و مدل شیء واضح‌تری برای انیمیشن‌های PowerPoint فراهم می‌کند. یک اسلاید فقط می‌تواند یک جدول زمانی انیمیشن داشته باشد.

## **انیمیشن تعاملی**

[Trigger](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/effecttriggertype) به شما امکان می‌دهد اقدامات کاربر (مثلاً کلیک یک دکمه) را تعریف کنید که یک انیمیشن خاص را آغاز می‌کند. Triggerها در جدیدترین نسخه PowerPoint معرفی شده‌اند.

## **انیمیشن شکل**

Aspose.Slides به شما امکان می‌دهد انیمیشن‌ها را بر روی اشکال اعمال کنید؛ این اشکال می‌توانند شامل متن، مستطیل‌ها، خطوط، فریم‌ها، اشیای OLE و موارد دیگر باشند.

{{% alert color="info" %}} 
بیشتر بخوانید [**درباره انیمیشن شکل**](/slides/fa/net/shape-animation/).
{{% /alert %}}

## **نمودارهای متحرک**

برای ایجاد نمودارهای متحرک، باید از همان کلاس‌هایی که برای اشکال استفاده می‌شود، بهره ببرید. با این حال، انیمیشن‌های PowerPoint فقط می‌توانند بر روی دسته‌های نمودار یا سری‌های نمودار اعمال شوند. می‌توانید افکت‌های انیمیشن را نیز بر روی عنصر یک دسته یا عنصر یک سری اعمال کنید.

{{% alert color="info" %}} 
بیشتر بخوانید [**درباره نمودارهای متحرک**](/slides/fa/net/animated-charts/).
{{% /alert %}}

## **متن متحرک**

علاوه بر متن متحرک، می‌توانید انیمیشن را بر روی یک پاراگراف نیز اعمال کنید.

{{% alert color="info" %}} 
بیشتر بخوانید [**درباره متن متحرک**](/slides/fa/net/animated-text/).
{{% /alert %}}

## **پرسش‌های متداول**

### آیا انیمیشن‌ها در زمان خروجی به PDF حفظ می‌شوند؟

خیر. PDF یک فرمت ساکن است، بنابراین انیمیشن‌ها و [انتقالات اسلاید](/slides/fa/net/slide-transition/) پخش نمی‌شوند. اگر به حرکت نیاز دارید، به‌جای آن به [HTML5](/slides/fa/net/export-to-html5/)، [GIF متحرک](/slides/fa/net/convert-powerpoint-to-animated-gif/) یا [ویدیو](/slides/fa/net/convert-powerpoint-to-video/) خروجی بدهید.

### آیا می‌توانم یک ارائه متحرک را به ویدیو تبدیل کنم و نرخ فریم و اندازه فریم را کنترل کنم؟

بله. می‌توانید [ارائه را به‌صورت فریم‌ها رندر کنید](/slides/fa/net/convert-powerpoint-to-video/) و آن‌ها را به یک ویدیو (مثلاً با ffmpeg) رمزگذاری کنید، به‌طوری که FPS و وضوح تصویر را انتخاب کنید. انیمیشن‌ها و انتقالات اسلاید در هنگام رندر پخش می‌شوند.

### آیا انیمیشن‌ها هنگام کار با ODP (نه فقط PPTX) به همان صورت باقی می‌مانند؟

قالب‌های PPT، PPTX و ODP برای [خواندن](/slides/fa/net/open-presentation/) و [نوشتن](/slides/fa/net/save-presentation/) پشتیبانی می‌شوند، اما تفاوت‌های فرمت ممکن است باعث شود برخی افکت‌ها کمی متفاوت ظاهر یا رفتار کنند. موارد مهم را با نمونه‌های واقعی اعتبارسنجی کنید.