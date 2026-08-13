---
title: بهبود ارائه‌های PowerPoint با انیمیشن‌ها در C++
linktitle: انیمیشن PowerPoint
type: docs
weight: 150
url: /fa/cpp/powerpoint-animation/
keywords:
- افزودن انیمیشن
- به‌روزرسانی انیمیشن
- تغییر انیمیشن
- حذف انیمیشن
- مدیریت انیمیشن
- کنترل انیمیشن
- افکت انیمیشن
- انیمیشن PowerPoint
- خط زمان انیمیشن
- انیمیشن تعاملی
- انیمیشن سفارشی
- انیمیشن شکل
- نمودار انیمیشنی
- متن انیمیشنی
- شکل انیمیشنی
- شیء OLE انیمیشنی
- تصویر انیمیشنی
- جدول انیمیشنی
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "یاد بگیرید چگونه افکت‌های پیشرفته انیمیشن را در Aspose.Slides برای C++ اضافه و کنترل کنید تا ارائه‌های پویا در PowerPoint و OpenDocument ایجاد کنید."
---
## **معرفی**

از آنجا که ارائه‌ها برای نمایش چیزی طراحی شده‌اند، ظاهر بصری و رفتار تعاملی آن‌ها همواره در حین ایجاد مورد توجه قرار می‌گیرد.

**PowerPoint animation** نقش مهمی در جذاب و جلب توجه مخاطبان به ارائه ایفا می‌کند. Aspose.Slides برای C++ گزینه‌های متعددی برای افزودن انیمیشن به ارائه PowerPoint فراهم می‌کند:

- اعمال انواع مختلف افکت‌های انیمیشن PowerPoint بر روی اشکال، نمودارها، جدول‌ها، اشیاء OLE و سایر عناصر ارائه.
- استفاده از چندین افکت انیمیشن PowerPoint بر روی یک شکل.
- استفاده از جدول زمانی انیمیشن برای کنترل افکت‌های انیمیشن.
- ایجاد انیمیشن سفارشی.

در Aspose.Slides برای C++، می‌توان انواع مختلف افکت‌های انیمیشن را بر روی اشکال اعمال کرد. از آنجا که هر عنصر در اسلاید از جمله متن، تصاویر، شیء OLE، جدول و غیره به عنوان یک شکل در نظر گرفته می‌شود، یعنی می‌توانیم افکت انیمیشن را بر روی هر عنصر اسلاید اعمال کنیم.

[**Aspose.Slides.Animation**](https://reference.aspose.com/slides/fa/cpp/namespace/aspose.slides.animation) **namespace** کلاس‌هایی را برای کار با انیمیشن‌های PowerPoint فراهم می‌کند.

## **افکت‌های انیمیشن**

Aspose.Slides از **بیش از 150 افکت انیمیشن** پشتیبانی می‌کند، از جمله افکت‌های پایه مانند Bounce، PathFootball، افکت Zoom و افکت‌های خاص مانند OLEObjectShow، OLEObjectOpen. می‌توانید فهرست کامل افکت‌های انیمیشن را در [**EffectType**](https://reference.aspose.com/slides/fa/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31) enumeration بیابید.

علاوه بر این، این افکت‌های انیمیشن می‌توانند به ترکیب با یکدیگر استفاده شوند:

- [ColorEffect](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.animation.command_effect)
- [FilterEffect](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.animation.filter_effect)
- [MotionEffect](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.animation.motion_effect)
- [PropertyEffect](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.animation.property_effect)
- [RotationEffect](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.animation.rotation_effect)
- [ScaleEffect](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.animation.scale_effect)
- [SetEffect](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.animation.set_effect)

## **انیمیشن سفارشی**

در Aspose.Slides امکان ایجاد **انیمیشن‌های سفارشی** خود وجود دارد. این کار با ترکیب چند رفتار در یک انیمیشن سفارشی جدید قابل‌تحقق است.

[**Behavior**](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.animation.behavior) یک واحد سازنده هر افکت انیمیشن PowerPoint است. تمام افکت‌های انیمیشن در واقع مجموعه‌ای از رفتارها هستند که در یک استراتژی ترکیب شده‌اند. می‌توانید رفتارها را یک‌بار در یک انیمیشن سفارشی ترکیب کنید و آن را در ارائه‌های دیگر دوباره استفاده کنید. اگر رفتار جدیدی را به یک افکت انیمیشن استاندارد PowerPoint اضافه کنید – آن یک انیمیشن سفارشی دیگر خواهد شد. به عنوان مثال، می‌توانید رفتار تکرار را به یک انیمیشن اضافه کنید تا چند بار تکرار شود.

[**Animation Point**](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.animation.point) نقطه‌ای است که رفتار باید در آن اعمال شود.

## **خط زمان انیمیشن**

[**Sequence**](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.animation.sequence) مجموعه‌ای از افکت‌های انیمیشن است که بر روی یک شکل خاص اعمال می‌شود.

[**AnimationTimeLine**](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.animation.animation_time_line) یک مجموعه از Sequence‌ها است که در یک اسلاید خاص استفاده می‌شود. این یک موتور انیمیشن است که از PowerPoint 2002 به بعد موجود است. در نسخه‌های قبلی PowerPoint اضافه کردن افکت‌های انیمیشن به ارائه دشوار بود و فقط با روش‌های مختلف می‌شد انجام داد. Timeline جایگزین کلاس قدیمی AnimationSettings شده و مدل شیء واضح‌تری برای انیمیشن PowerPoint ارائه می‌دهد. یک اسلاید می‌تواند تنها یک خط زمان انیمیشن داشته باشد.

## **انیمیشن تعاملی**

[**EffectTriggerType**](https://reference.aspose.com/slides/fa/cpp/namespace/aspose.slides.animation#add24fb49dd44eb3227aeeb3641fd2e81) امکان تعریف اعمال کاربر (مثلاً کلیک دکمه) را فراهم می‌کند که منجر به شروع یک انیمیشن خاص می‌شود. تریگرها فقط در آخرین نسخه PowerPoint اضافه شده‌اند.

## **انیمیشن اشکال**

Aspose.Slides امکان اعمال انیمیشن بر روی اشکال را می‌دهد؛ این اشکال می‌توانند در واقع متن، مستطیل، خط، قاب، شیء OLE و غیره باشند.

{{% alert color="info" %}} 
اطلاع بیشتر [**درباره انیمیشن اشکال**](/slides/fa/cpp/shape-animation/).
{{% /alert %}}

## **نمودارهای انیمیشنی**

برای ایجاد نمودارهای انیمیشنی، باید از همان کلاس‌هایی که برای اشکال استفاده می‌شود، بهره ببرید. با این حال، می‌توان فقط بر روی دسته‌های نمودار یا سری‌های نمودار از انیمیشن PowerPoint استفاده کرد. همچنین می‌توانید افکت انیمیشن را بر روی یک عنصر دسته یا عنصر سری اعمال کنید.

{{% alert color="info" %}} 
اطلاع بیشتر [**درباره نمودارهای انیمیشنی**](/slides/fa/cpp/animated-charts/).
{{% /alert %}}

## **متن انیمیشنی**

به جز متن انیمیشنی، امکان اعمال انیمیشن بر روی یک پاراگراف نیز وجود دارد.

{{% alert color="info" %}} 
اطلاع بیشتر [**درباره متن انیمیشنی**](/slides/fa/cpp/animated-text/).
{{% /alert %}}

## **سوالات متداول**

### آیا انیمیشن‌ها هنگام خروجی به PDF حفظ می‌شوند؟

خیر. PDF یک فرمت ثابت است، بنابراین انیمیشن‌ها و [انتقالات اسلاید](/slides/fa/cpp/slide-transition/) اجرا نمی‌شوند. اگر به حرکت نیاز دارید، به جای آن به [HTML5](/slides/fa/cpp/export-to-html5/)، [GIF متحرک](/slides/fa/cpp/convert-powerpoint-to-animated-gif/) یا [ویدیو](/slides/fa/cpp/convert-powerpoint-to-video/) خروجی بگیرید.

### آیا می‌توانم یک ارائه انیمیشنی را به ویدیو تبدیل کنم و نرخ فریم و اندازه فریم را کنترل کنم؟

بله. می‌توانید [ارائه را به عنوان فریم‌ها رندر کنید](/slides/fa/cpp/convert-powerpoint-to-video/) و آن‌ها را به یک ویدیو (مثلاً با ffmpeg) رمزگذاری کنید، با انتخاب FPS و وضوح تصویر. انیمیشن‌ها و انتقالات اسلاید در هنگام رندر اجرا می‌شوند.

### آیا انیمیشن‌ها هنگام کار با ODP (نه فقط PPTX) به همان شکل باقی می‌مانند؟

قالب‌های PPT، PPTX و ODP برای [خواندن](/slides/fa/cpp/open-presentation/) و [نوشتن](/slides/fa/cpp/save-presentation/) پشتیبانی می‌شوند، اما تفاوت‌های فرمت به این معناست که برخی افکت‌ها ممکن است کمی متفاوت نمایش داده شوند یا رفتار داشته باشند. موارد مهم را با نمونه‌های واقعی اعتبارسنجی کنید.