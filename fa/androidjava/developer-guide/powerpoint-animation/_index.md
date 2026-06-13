---
title: بهبود ارائه‌های PowerPoint با انیمیشن‌ها در Android
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
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "قابلیت‌های Aspose.Slides برای Android از طریق Java در مدیریت انیمیشن‌های PowerPoint را بررسی کنید. این مرور کلی ویژگی‌های کلیدی را برجسته می‌کند."
---
## **مقدمه**

از آنجا که ارائه‌ها برای نمایش چیزی ساخته می‌شوند، ظاهر بصری و رفتار تعاملی آن‌ها همیشه در حین ایجاد در نظر گرفته می‌شود.

**انیمیشن PowerPoint** نقش مهمی در جذاب و دیدنی کردن ارائه برای بینندگان ایفا می‌کند. Aspose.Slides for Android via Java گزینه‌های متنوعی برای افزودن انیمیشن به ارائه PowerPoint ارائه می‌دهد:

- اعمال انواع مختلف افکت‌های انیمیشن PowerPoint بر روی اشکال، نمودارها، جداول، اشیای OLE و سایر عناصر ارائه.
- استفاده از چندین افکت انیمیشن PowerPoint بر یک شکل.
- استفاده از جدول زمانی انیمیشن برای کنترل افکت‌های انیمیشن.
- ایجاد انیمیشن سفارشی.

در Aspose.Slides for Android via Java، می‌توان انواع مختلف افکت‌های انیمیشن را بر روی اشکال اعمال کرد. از آنجا که هر عنصر روی اسلاید شامل متن، تصویر، شیء OLE، جدول و غیره به عنوان یک شکل در نظر گرفته می‌شود، یعنی می‌توانیم افکت انیمیشن را بر روی هر عنصر اسلاید اعمال کنیم.

## **افکت‌های انیمیشن**
Aspose.Slides از **بیش از 150 افکت انیمیشن** پشتیبانی می‌کند، از جمله افکت‌های پایه‌ای مانند Bounce، PathFootball، افکت Zoom و افکت‌های خاص مانند OLEObjectShow، OLEObjectOpen. می‌توانید فہرست کامل افکت‌های انیمیشن را در enumeration [**EffectType**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/effecttype/) پیدا کنید.

علاوه بر این، این افکت‌های انیمیشن می‌توانند به‌صورت ترکیبی استفاده شوند:
- [ColorEffect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/SetEffect)

## **انیمیشن سفارشی**
امکان ایجاد **انیمیشن‌های سفارشی** خود در Aspose.Slides وجود دارد. این کار با ترکیب چند رفتار به یک انیمیشن سفارشی جدید قابل انجام است.

[**Behavior**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Behavior) یک واحد ساختمانی هر افکت انیمیشن PowerPoint است. تمام افکت‌های انیمیشن در واقع مجموعه‌ای از رفتارها هستند که در یک استراتژی ترکیب می‌شوند. می‌توانید رفتارها را یک‌بار در یک انیمیشن سفارشی ترکیب کنید و در ارائه‌های دیگر دوباره استفاده نمایید. اگر یک رفتار جدید به یک افکت انیمیشن استاندارد PowerPoint اضافه کنید – یک انیمیشن سفارشی دیگر به‌دست می‌آید. به عنوان مثال، می‌توانید رفتار تکرار را به یک انیمیشن اضافه کنید تا چند بار تکرار شود.

[**Animation Point**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Point) نقطه‌ای است که رفتار باید در آن اعمال شود.

## **خط زمان انیمیشن**
[**Sequence**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Sequence) مجموعه‌ای از افکت‌های انیمیشن است که بر روی یک شکل مشخص اعمال می‌شود.

[**Timeline**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/AnimationTimeLine) مجموعه‌ای از Sequence‌هاست که در یک اسلاید مشخص استفاده می‌شود. این یک موتور انیمیشن است که از PowerPoint 2002 به بعد معرفی شده است. در نسخه‌های قبلی PowerPoint، افزودن افکت‌های انیمیشن به ارائه دشوار بود و فقط با روش‌های مختلفی می‌توانست انجام شود. Timeline جایگزین کلاس قدیمی AnimationSettings شده و مدل شیء واضح‌تری برای انیمیشن PowerPoint فراهم می‌کند. یک اسلاید می‌تواند فقط یک خط زمان انیمیشن داشته باشد.

## **انیمیشن تعاملی**
[**Trigger**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/EffectTriggerType) امکان تعریف اقدامات کاربر (مثلاً کلیک دکمه) را فراهم می‌کند که باعث شروع یک انیمیشن خاص می‌شود. Triggerها تنها در آخرین نسخه PowerPoint اضافه شده‌اند.

## **انیمیشن شکل**
Aspose.Slides امکان اعمال انیمیشن بر روی اشکال را فراهم می‌کند، که می‌توانند در واقع متن، مستطیل، خط، فریم، شیء OLE و غیره باشند.

{{% alert color="primary" %}} 
بیشتر بخوانید [**درباره انیمیشن شکل**](/slides/fa/androidjava/shape-animation/).
{{% /alert %}}

## **نمودارهای متحرک**
برای ایجاد نمودارهای متحرک، باید از همان کلاس‌هایی که برای اشکال استفاده می‌شود، استفاده کنید. با این حال، می‌توانید انیمیشن PowerPoint را فقط بر روی دسته‌های نمودار یا سری‌های نمودار به کار ببرید. همچنین می‌توانید افکت انیمیشن را بر روی یک عنصر دسته یا عنصر سری اعمال کنید.

{{% alert color="primary" %}} 
بیشتر بخوانید [**درباره نمودارهای متحرک**](/slides/fa/androidjava/animated-charts/).
{{% /alert %}}

## **متن متحرک**
علاوه بر متن متحرک، امکان اعمال انیمیشن بر روی یک پاراگراف نیز وجود دارد.

{{% alert color="primary" %}} 
بیشتر بخوانید [**درباره متن متحرک**](/slides/fa/androidjava/animated-text/).
{{% /alert %}}

## **پرسش‌های متداول**

**آیا انیمیشن‌ها هنگام صادرات به PDF حفظ می‌شوند؟**

خیر. PDF یک فرمت ثابت است، بنابراین انیمیشن‌ها و [slide transitions](/slides/fa/androidjava/slide-transition/) پخش نمی‌شوند. اگر به حرکت نیاز دارید، به جای آن به [HTML5](/slides/fa/androidjava/export-to-html5/)، [animated GIF](/slides/fa/androidjava/convert-powerpoint-to-animated-gif/)، یا [video](/slides/fa/androidjava/convert-powerpoint-to-video/) صادر کنید.

**آیا می‌توانم یک ارائه متحرک را به ویدئو تبدیل کنم و نرخ فریم و اندازه فریم را کنترل کنم؟**

بله. می‌توانید [render the presentation as frames](/slides/fa/androidjava/convert-powerpoint-to-video/) را انجام داده و آن‌ها را به یک ویدئو (مثلاً با ffmpeg) کدگذاری کنید، با انتخاب FPS و وضوح تصویر. انیمیشن‌ها و slide transitions هنگام رندر پخش می‌شوند.

**آیا انیمیشن‌ها هنگام کار با ODP (نه فقط PPTX) دست نخورده می‌مانند؟**

PPT، PPTX و ODP برای [reading](/slides/fa/androidjava/open-presentation/) و [writing](/slides/fa/androidjava/save-presentation/) پشتیبانی می‌شوند، اما تفاوت‌های فرمت به این معنی است که برخی افکت‌ها ممکن است کمی متفاوت ظاهر شوند یا رفتار کنند. موارد حیاتی را با نمونه‌های واقعی اعتبارسنجی کنید.