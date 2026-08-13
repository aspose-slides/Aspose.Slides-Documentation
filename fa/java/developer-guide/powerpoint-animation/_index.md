---
title: بهبود ارائه‌های PowerPoint با انیمیشن‌ها در جاوا
linktitle: انیمیشن PowerPoint
type: docs
weight: 150
url: /fa/java/powerpoint-animation/
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
- نمودار انیمیشنی
- متن انیمیشنی
- شکل انیمیشنی
- شیء OLE انیمیشنی
- تصویر انیمیشنی
- جدول انیمیشنی
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "قابلیت‌های Aspose.Slides برای جاوا در مدیریت انیمیشن‌های PowerPoint را کشف کنید. این مرور کلی ویژگی‌های کلیدی را برجسته می‌کند و بینش‌هایی برای بهبود ارائه‌های شما ارائه می‌دهد."
---
## **مقدمه**

از آنجا که ارائه‌ها برای نشان دادن موضوعی طراحی شده‌اند، ظاهر بصری و رفتار تعاملی آن‌ها همواره در زمان ایجاد در نظر گرفته می‌شود.

**PowerPoint animation** نقش مهمی در جذاب و جلب توجه بینندگان به ارائه ایفا می‌کند. Aspose.Slides مجموعه‌ای گسترده از گزینه‌ها را برای افزودن انیمیشن به ارائه‌های PowerPoint فراهم می‌کند:

- انواع مختلفی از افکت‌های انیمیشن PowerPoint را روی اشکال، نمودارها، جدول‌ها، اشیاء OLE و سایر عناصر ارائه اعمال کنید.
- از چندین افکت انیمیشن PowerPoint بر روی یک شکل استفاده کنید.
- از خط زمان انیمیشن برای کنترل افکت‌های انیمیشن استفاده کنید.
- ایجاد انیمیشن‌های سفارشی.

## **افکت‌های انیمیشن**
Aspose.Slides از **بیش از 150 افکت انیمیشن** پشتیبانی می‌کند، از جمله افکت‌های اصلی مانند Bounce، PathFootball، افکت Zoom و افکت‌های خاصی مانند OLEObjectShow، OLEObjectOpen. می‌توانید فهرست کامل افکت‌های انیمیشن را در enumeration [**EffectType**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/effecttype/) پیدا کنید.

علاوه بر این، می‌توانید این افکت‌های انیمیشن را با یکدیگر ترکیب کنید:

- [ColorEffect](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/fa/java/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/fa/java/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/fa/java/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/fa/java/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/fa/java/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/fa/java/com.aspose.slides/SetEffect)

## **انیمیشن سفارشی**
ایجاد **انیمیشن‌های سفارشی** خود در Aspose.Slides امکان‌پذیر است. این کار با ترکیب چند رفتار در یک انیمیشن سفارشی جدید میسر می‌شود.

[**Behavior**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Behavior) واحد ساختاری هر افکت انیمیشن PowerPoint است. تمام افکت‌های انیمیشن در واقع مجموعه‌ای از رفتارها هستند که در یک استراتژی ترکیب شده‌اند. می‌توانید رفتارها را یک بار در یک انیمیشن سفارشی ترکیب کنید و دوباره در ارائه‌های دیگر از آن استفاده کنید. اگر یک رفتار جدید به یک افکت انیمیشن استاندارد PowerPoint اضافه کنید، یک انیمیشن سفارشی دیگر ایجاد می‌شود. برای مثال، می‌توانید رفتار تکرار را به یک انیمیشن اضافه کنید تا چند بار تکرار شود.

[**Animation Point**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Point) نقطه‌ای است که رفتار باید در آن اعمال شود.

## **خط زمان انیمیشن**
[**Sequence**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Sequence) مجموعه‌ای از افکت‌های انیمیشن است که بر روی یک شکل خاص اعمال می‌شود.

[**Timeline**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/AnimationTimeLine) مجموعه‌ای از Sequenceهاست که در یک اسلاید خاص استفاده می‌شود. این موتور انیمیشن از نسخه PowerPoint 2002 به بعد موجود است. در نسخه‌های قبلی PowerPoint، افزودن افکت‌های انیمیشن به ارائه دشوار بود و فقط با روش‌های مختلف می‌توانست انجام شود. Timeline جایگزین کلاس قدیمی AnimationSettings می‌شود و مدل شیء واضح‌تری برای انیمیشن PowerPoint فراهم می‌کند. یک اسلاید می‌تواند فقط یک خط زمان انیمیشن داشته باشد.

## **انیمیشن تعاملی**
[**Trigger**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/EffectTriggerType) امکان تعریف اقدامات کاربر (مثلاً کلیک دکمه) را فراهم می‌کند که باعث شروع یک انیمیشن خاص می‌شود. Triggerها فقط در آخرین نسخه PowerPoint اضافه شده‌اند.

## **انیمیشن شکل**
Aspose.Slides امکان اعمال انیمیشن بر روی اشکال را فراهم می‌کند، که می‌توانند متن، مستطیل، خط, قاب, شیء OLE و غیره باشند.

{{% alert color="info" %}} 
بیشتر بخوانید [**درباره انیمیشن شکل**](/slides/fa/java/shape-animation/).
{{% /alert %}}

## **نمودارهای انیمیشنی**
برای ایجاد نمودارهای انیمیشنی، باید از همان کلاس‌هایی که برای اشکال استفاده می‌شود بهره ببرید. اما می‌توانید انیمیشن PowerPoint را فقط بر روی دسته‌های نمودار یا سری‌های نمودار اعمال کنید. همچنین می‌توانید افکت انیمیشن را بر روی یک عنصر دسته یا یک عنصر سری اعمال کنید.

{{% alert color="info" %}} 
بیشتر بخوانید [**درباره نمودارهای انیمیشنی**](/slides/fa/java/animated-charts/).
{{% /alert %}}

## **متن انیمیشنی**
به جز متن انیمیشنی، می‌توانید انیمیشن را به یک پاراگراف نیز اعمال کنید.

{{% alert color="info" %}} 
بیشتر بخوانید [**درباره متن انیمیشنی**](/slides/fa/java/animated-text/).
{{% /alert %}}

## **سوالات متداول**

### آیا انیمیشن‌ها هنگام خروجی به PDF حفظ می‌شوند؟

خیر. PDF یک فرمت ثابت است، بنابراین انیمیشن‌ها و [انتقالات اسلاید](/slides/fa/java/slide-transition/) اجرا نمی‌شوند. اگر به حرکت نیاز دارید، به جای آن به [HTML5](/slides/fa/java/export-to-html5/)، [animated GIF](/slides/fa/java/convert-powerpoint-to-animated-gif/) یا [video](/slides/fa/java/convert-powerpoint-to-video/) خروجی دهید.

### آیا می‌توانم یک ارائه انیمیشنی را به ویدیو تبدیل کرده و نرخ فریم و اندازه فریم را کنترل کنم؟

بله. می‌توانید [ارائه را به‌صورت فریم رندر کنید](/slides/fa/java/convert-powerpoint-to-video/) و آن‌ها را به یک ویدیو (مثلاً با ffmpeg) رمزگذاری کنید و FPS و رزولوشن را انتخاب کنید. انیمیشن‌ها و انتقال‌های اسلاید در حین رندر اجرا می‌شوند.

### آیا انیمیشن‌ها هنگام کار با ODP (نه فقط PPTX) دست نخورده می‌مانند؟

فرمت‌های PPT، PPTX و ODP برای [خواندن](/slides/fa/java/open-presentation/) و [نوشتن](/slides/fa/java/save-presentation/) پشتیبانی می‌شوند، اما تفاوت‌های فرمت به این معناست که برخی افکت‌ها ممکن است کمی متفاوت ظاهر شوند یا رفتار داشته باشند. موارد بحرانی را با نمونه‌های واقعی اعتبارسنجی کنید.