---
title: تقویت ارائه‌های PowerPoint با انیمیشن‌ها در Android
linktitle: انیمیشن PowerPoint
type: docs
weight: 150
url: /fa/androidjava/powerpoint-animation/
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
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "قابلیت‌های Aspose.Slides برای Android از طریق Java در مدیریت انیمیشن‌های PowerPoint را بررسی کنید. این مرور کلی ویژگی‌های کلیدی را برجسته می‌کند."
---
## **مقدمه**

از آنجا که ارائه‌ها برای نمایش چیزی ساخته می‌شوند، ظاهر بصری و رفتار تعاملی آن‌ها همیشه هنگام ایجاد در نظر گرفته می‌شود.

**PowerPoint animation** نقش مهمی در جذاب و جلب توجه بینندگان برای ارائه ایفا می‌کند. Aspose.Slides for Android via Java گزینه‌های گسترده‌ای برای افزودن انیمیشن به ارائه PowerPoint ارائه می‌دهد:

- انواع مختلف اثرهای انیمیشن PowerPoint را بر روی اشکال، نمودارها، جدول‌ها، اشیاء OLE و سایر عناصر ارائه اعمال کنید.
- بر روی یک شکل از چندین اثر انیمیشن PowerPoint استفاده کنید.
- از جدول زمان‌بندی انیمیشن برای کنترل اثرهای انیمیشن استفاده کنید.
- انیمیشن سفارشی ایجاد کنید.

در Aspose.Slides for Android via Java، اثرهای مختلف انیمیشن می‌توانند بر روی اشکال اعمال شوند. از آنجا که هر عنصر روی اسلاید شامل متن، تصویر، شیء OLE، جدول و غیره به‌عنوان یک شکل در نظر گرفته می‌شود، یعنی می‌توانیم اثر انیمیشن را بر روی هر عنصر یک اسلاید اعمال کنیم.

## **اثرات انیمیشن**
Aspose.Slides از **150+ animation effects** پشتیبانی می‌کند، شامل اثرهای پایه‌ای مانند Bounce، PathFootball، Zoom و اثرهای خاصی مانند OLEObjectShow، OLEObjectOpen. می‌توانید فهرست کامل اثرهای انیمیشن را در **[EffectType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/effecttype/)**‌ enumeration پیدا کنید.

علاوه بر این، این اثرهای انیمیشن می‌توانند به‌صورت ترکیبی با موارد زیر استفاده شوند:

- [ColorEffect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/SetEffect)

## **انیمیشن سفارشی**
امکان ایجاد **custom animations** خودتان در Aspose.Slides وجود دارد. این کار با ترکیب چند رفتار در یک انیمیشن سفارشی جدید حاصل می‌شود.

**[Behavior](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Behavior)** یک واحد ساختاری هر اثر انیمیشن PowerPoint است. تمام اثرهای انیمیشن در حقیقت مجموعه‌ای از رفتارها هستند که در یک استراتژی ترکیب می‌شوند. می‌توانید رفتارها را در یک انیمیشن سفارشی ترکیب کنید و سپس آن را در ارائه‌های دیگر باز استفاده کنید. اگر یک رفتار جدید به یک اثر انیمیشن استاندارد PowerPoint اضافه کنید، آن به‌عنوان یک انیمیشن سفارشی دیگر محسوب می‌شود. به‌عنوان مثال، می‌توانید رفتار تکرار را به یک انیمیشن اضافه کنید تا چندین بار تکرار شود.

**[Animation Point](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Point)** نقطه‌ای است که رفتار باید بر روی آن اعمال شود.

## **خط زمان انیمیشن**
**[Sequence](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Sequence)** مجموعه‌ای از اثرهای انیمیشن است که بر روی یک شکل خاص اعمال می‌شود.

**[Timeline](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/AnimationTimeLine)** مجموعه‌ای از Sequence‌هاست که در یک اسلاید خاص استفاده می‌شود. این یک موتور انیمیشن است که از PowerPoint 2002 به بعد موجود است. در نسخه‌های قبلی PowerPoint افزودن اثرهای انیمیشن به ارائه کار دشواری بود که فقط با راه‌حل‌های مختلف ممکن می‌شد. Timeline جایگزین کلاس قدیمی AnimationSettings شده و مدل شیء واضح‌تری برای انیمیشن PowerPoint فراهم می‌کند. یک اسلاید می‌تواند فقط یک خط زمان انیمیشن داشته باشد.

## **انیمیشن تعاملی**
**[Trigger](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/EffectTriggerType)** امکان تعریف اقدامات کاربری (مثلاً کلیک دکمه) را می‌دهد که باعث شروع یک انیمیشن خاص می‌شود. Triggerها فقط در آخرین نسخه PowerPoint اضافه شده‌اند.

## **انیمیشن شکل**
Aspose.Slides امکان اعمال انیمیشن بر روی اشکال را فراهم می‌کند؛ این اشکال می‌توانند در واقع متن، مستطیل، خط، فریم، شیء OLE و غیره باشند.

{{% alert color="info" %}} 
Read more [**درباره انیمیشن شکل**](/slides/fa/androidjava/shape-animation/).
{{% /alert %}}

## **نمودارهای انیمیشنی**
برای ایجاد نمودارهای انیمیشنی باید از همان کلاس‌هایی که برای اشکال استفاده می‌کنید، بهره ببرید. با این حال، امکان استفاده از انیمیشن PowerPoint فقط بر روی دسته‌بندی‌های نمودار یا سری‌های نمودار وجود دارد. همچنین می‌توانید اثر انیمیشن را بر روی یک عنصر دسته‌بندی یا یک عنصر سری اعمال کنید.

{{% alert color="info" %}} 
Read more [**درباره نمودارهای انیمیشنی**](/slides/fa/androidjava/animated-charts/).
{{% /alert %}}

## **متن انیمیشنی**
به‌جز متن انیمیشنی، امکان اعمال انیمیشن بر روی یک پاراگراف نیز وجود دارد.

{{% alert color="info" %}} 
Read more [**درباره متن انیمیشنی**](/slides/fa/androidjava/animated-text/).
{{% /alert %}}

## **سوالات متداول**

### آیا انیمیشن‌ها هنگام صادرات به PDF حفظ می‌شوند؟

نه. PDF یک فرمت استاتیک است، بنابراین انیمیشن‌ها و [slide transitions](/slides/fa/androidjava/slide-transition/) اجرا نمی‌شوند. اگر به حرکت نیاز دارید، به جای آن به [HTML5](/slides/fa/androidjava/export-to-html5/)، [animated GIF](/slides/fa/androidjava/convert-powerpoint-to-animated-gif/) یا [video](/slides/fa/androidjava/convert-powerpoint-to-video/) صادر کنید.

### آیا می‌توانم یک ارائه انیمیشنی را به ویدیو تبدیل کنم و نرخ فریم و اندازه فریم را کنترل کنم؟

بله. می‌توانید [presentation as frames](/slides/fa/androidjava/convert-powerpoint-to-video/) رندر کنید و آن‌ها را به یک ویدیو (مثلاً با ffmpeg) تبدیل کنید، با انتخاب FPS و رزولوشن. انیمیشن‌ها و انتقالات اسلاید در هنگام رندر پخش می‌شوند.

### آیا انیمیشن‌ها هنگام کار با ODP (نه فقط PPTX) دست نخورده می‌مانند؟

PPT، PPTX و ODP برای [reading](/slides/fa/androidjava/open-presentation/) و [writing](/slides/fa/androidjava/save-presentation/) پشتیبانی می‌شوند، اما تفاوت‌های فرمت ممکن است باعث شود برخی اثرها کمی متفاوت ظاهر یا رفتار کنند. موارد مهم را با نمونه‌های واقعی اعتبارسنجی کنید.