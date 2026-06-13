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
- اثر انیمیشن
- انیمیشن PowerPoint
- خط زمان انیمیشن
- انیمیشن تعاملی
- انیمیشن سفارشی
- انیمیشن شکل
- نمودار انیمیشن‌دار
- متن انیمیشن‌دار
- شکل انیمیشن‌دار
- شیء OLE انیمیشن‌دار
- تصویر انیمیشن‌دار
- جدول انیمیشن‌دار
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "نحوه افزودن و کنترل افکت‌های پیشرفته انیمیشن در Aspose.Slides برای C++ را برای ساخت ارائه‌های پویا در PowerPoint و OpenDocument بیاموزید."
---
## **مقدمه**

از آنجا که ارائه‌ها برای نمایش چیزی طراحی شده‌اند، ظاهر بصری و رفتار تعاملی آن‌ها همواره در هنگام ایجادشان در نظر گرفته می‌شود.

**PowerPoint animation** نقش مهمی را برای جذاب و چشم‌نواز کردن ارائه برای بینندگان ایفا می‌کند. Aspose.Slides for C++ گزینه‌های گسترده‌ای برای افزودن انیمیشن به ارائه PowerPoint ارائه می‌دهد:

- انواع مختلف افکت‌های انیمیشن PowerPoint را بر روی اشکال، نمودارها، جداول، اشیای OLE و سایر عناصر ارائه اعمال کنید.
- از چندین افکت انیمیشن PowerPoint بر روی یک شکل استفاده کنید.
- از خط زمان انیمیشن برای کنترل افکت‌های انیمیشن استفاده کنید.
- انیمیشن سفارشی ایجاد کنید.

در Aspose.Slides for C++ می‌توان افکت‌های مختلف انیمیشن را بر روی اشکال اعمال کرد. از آنجا که هر عنصر در اسلاید شامل متن، تصویر، شیء OLE، جدول و غیره به عنوان یک شکل در نظر گرفته می‌شود، به این معنی است که می‌توانیم افکت انیمیشن را بر روی هر عنصر یک اسلاید اعمال کنیم.

[**Aspose.Slides.Animation**](https://reference.aspose.com/slides/fa/cpp/namespace/aspose.slides.animation) **namespace** کلاس‌هایی را برای کار با انیمیشن‌های PowerPoint فراهم می‌کند.
## **افکت‌های انیمیشن**
Aspose.Slides از **بیش از 150 افکت انیمیشن** پشتیبانی می‌کند، از جمله افکت‌های پایه‌ای مانند Bounce، PathFootball، افکت Zoom و افکت‌های خاصی همچون OOLEObjectShow، OOLEObjectOpen. می‌توانید فهرست کامل افکت‌های انیمیشن را در شمارش [**EffectType**](https://reference.aspose.com/slides/fa/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31) پیدا کنید.

علاوه بر این، این افکت‌های انیمیشن می‌توانند به صورت ترکیبی با موارد زیر استفاده شوند:

- [ColorEffect](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.animation.command_effect)
- [FilterEffect](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.animation.filter_effect)
- [MotionEffect](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.animation.motion_effect)
- [PropertyEffect](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.animation.property_effect)
- [RotationEffect](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.animation.rotation_effect)
- [ScaleEffect](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.animation.scale_effect)
- [SetEffect](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.animation.set_effect)

## **انیمیشن سفارشی**
می‌توانید **انیمیشن‌های سفارشی** خود را در Aspose.Slides ایجاد کنید. این کار با ترکیب چند رفتار در یک انیمیشن سفارشی جدید امکان‌پذیر است.

[**Behavior**](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.animation.behavior) یک واحد سازنده برای هر افکت انیمیشن PowerPoint است. تمام افکت‌های انیمیشن در واقع مجموعه‌ای از رفتارها هستند که در یک استراتژی ترکیب می‌شوند. می‌توانید رفتارها را یک‌بار در یک انیمیشن سفارشی ترکیب کنید و در ارائه‌های دیگر دوباره استفاده کنید. اگر یک رفتار جدید را به یک افکت انیمیشن استاندارد PowerPoint اضافه کنید، آن یک انیمیشن سفارشی دیگر خواهد شد. برای مثال، می‌توانید رفتار تکرار را به یک انیمیشن اضافه کنید تا چند بار تکرار شود.

[**Animation Point**](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.animation.point) نقطه‌ای است که رفتار باید در آن اعمال شود.

## **خط زمان انیمیشن**
[**Sequence**](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.animation.sequence) مجموعه‌ای از افکت‌های انیمیشن است که بر روی یک شکل مشخص اعمال می‌شود.

[**AnimationTimeLine**](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.animation.animation_time_line) مجموعه‌ای از Sequence‌ها است که در یک اسلاید خاص استفاده می‌شوند. این یک موتور انیمیشن است که از PowerPoint 2002 به بعد معرفی شده است. در نسخه‌های قبلی PowerPoint افزودن افکت‌های انیمیشن به ارائه دشوار بود و فقط با روش‌های مختلفی قابل انجام بود. خط زمان به جای کلاس قدیمی AnimationSettings آمده و مدل شیء واضح‌تری برای انیمیشن PowerPoint فراهم می‌کند. یک اسلاید می‌تواند فقط یک خط زمان انیمیشن داشته باشد.

## **انیمیشن تعاملی**
[**EffectTriggerType**](https://reference.aspose.com/slides/fa/cpp/namespace/aspose.slides.animation#add24fb49dd44eb3227aeeb3641fd2e81) امکان تعریف اقدامات کاربر (مثلاً کلیک دکمه) را فراهم می‌کند که یک انیمیشن خاص را شروع می‌کند. محرک‌ها تنها در آخرین نسخه PowerPoint اضافه شده‌اند.

## **انیمیشن شکل**
Aspose.Slides امکان اعمال انیمیشن بر روی اشکال را می‌دهد که می‌توانند متن، مستطیل، خط، فریم، شیء OLE و غیره باشند.

{{% alert color="primary" %}} 
بیشتر بخوانید [**درباره انیمیشن شکل**](/slides/fa/cpp/shape-animation/).
{{% /alert %}}

## **نمودارهای انیمیشن‌دار**
برای ایجاد نمودارهای انیمیشن‌دار، باید همان کلاس‌های مورد استفاده برای اشکال را به کار ببرید. با این حال، می‌توان انیمیشن PowerPoint را تنها بر روی دسته‌های نمودار یا سری‌های نمودار به کار برد. همچنین می‌توانید افکت انیمیشن را بر روی یک عنصر دسته یا عنصر سری اعمال کنید.

{{% alert color="primary" %}} 
بیشتر بخوانید [**درباره نمودارهای انیمیشن‌دار**](/slides/fa/cpp/animated-charts/).
{{% /alert %}}

## **متن انیمیشن‌دار**
به‌جز متن انیمیشن‌دار، می‌توانید انیمیشن را بر روی یک پاراگراف نیز اعمال کنید.

{{% alert color="primary" %}} 
بیشتر بخوانید [**درباره متن انیمیشن‌دار**](/slides/fa/cpp/animated-text/).
{{% /alert %}}

## **سوالات متداول**

**آیا انیمیشن‌ها هنگام خروجی به PDF حفظ می‌شوند؟**

خیر. PDF یک قالب ثابت است، بنابراین انیمیشن‌ها و [slide transitions](/slides/fa/cpp/slide-transition/) اجرا نمی‌شوند. اگر به حرکت نیاز دارید، به جای آن به [HTML5](/slides/fa/cpp/export-to-html5/)، [animated GIF](/slides/fa/cpp/convert-powerpoint-to-animated-gif/)، یا [video](/slides/fa/cpp/convert-powerpoint-to-video/) خروجی دهید.

**آیا می‌توانم یک ارائه انیمیشن‌دار را به ویدئو تبدیل کنم و نرخ فریم و اندازه فریم را کنترل کنم؟**

بله. می‌توانید [presentation را به فریم‌ها رندر کنید](/slides/fa/cpp/convert-powerpoint-to-video/) و آن‌ها را به یک ویدئو (مثلاً با ffmpeg) تبدیل کنید و FPS و وضوح را انتخاب کنید. انیمیشن‌ها و انتقال اسلایدها در هنگام رندر اجرا می‌شوند.

**آیا انیمیشن‌ها هنگام کار با ODP (نه فقط PPTX) دست‌نخورده باقی می‌مانند؟**

قالب‌های PPT، PPTX و ODP برای [خواندن](/slides/fa/cpp/open-presentation/) و [نوشتن](/slides/fa/cpp/save-presentation/) پشتیبانی می‌شوند، اما تفاوت‌های قالب بدین معناست که برخی افکت‌ها ممکن است کمی متفاوت نمایش داده شوند یا رفتار داشته باشند. موارد مهم را با نمونه‌های واقعی اعتبارسنجی کنید.