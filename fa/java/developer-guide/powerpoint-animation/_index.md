---
title: ارتقاء ارائه‌های PowerPoint با انیمیشن‌ها در Java
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
- نمودار متحرک
- متن متحرک
- شکل متحرک
- شیء OLE متحرک
- تصویر متحرک
- جدول متحرک
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "قابلیت‌های Aspose.Slides برای Java را در پردازش انیمیشن‌های PowerPoint بررسی کنید. این مرور کلی ویژگی‌های کلیدی را برجسته می‌کند و بینش‌هایی برای بهبود ارائه‌های شما ارائه می‌دهد."
---
## **معرفی**

از آنجا که ارائه‌ها برای نمایش مطلبی ایجاد می‌شوند، ظاهر بصری و رفتار تعاملی آن‌ها همواره در هنگام ساخت مورد توجه قرار می‌گیرد.

**انیمیشن PowerPoint** نقش مهمی در جذاب‌سازی و درگیر کردن بینندگان دارد. Aspose.Slides مجموعه وسیعی از گزینه‌ها برای افزودن انیمیشن به ارائه‌های PowerPoint فراهم می‌کند:

- انواع مختلفی از اثرهای انیمیشن PowerPoint را بر اشکال، نمودارها، جداول، اشیای OLE و سایر عناصر ارائه اعمال کنید.
- از چندین اثر انیمیشن PowerPoint روی یک شکل استفاده کنید.
- از خط زمان انیمیشن برای کنترل اثرهای انیمیشن استفاده کنید.
- انیمیشن‌های سفارشی ایجاد کنید.

## **اثرهای انیمیشن**
Aspose.Slides از **بیش از 150 اثر انیمیشن** پشتیبانی می‌کند، از جمله اثرهای پایه‌ای مانند Bounce، PathFootball، Zoom و اثرهای خاص مانند OLEObjectShow، OLEObjectOpen. می‌توانید فهرست کامل اثرهای انیمیشن را در enumeration [**EffectType**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/effecttype/) بیابید.

علاوه بر این، می‌توانید این اثرهای انیمیشن را با موارد زیر ترکیب کنید:
- [ColorEffect](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/fa/java/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/fa/java/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/fa/java/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/fa/java/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/fa/java/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/fa/java/com.aspose.slides/SetEffect)

## **انیمیشن سفارشی**
امکان ایجاد **انیمیشن‌های سفارشی** خود در Aspose.Slides وجود دارد. این کار با ترکیب چند رفتار در یک انیمیشن سفارشی جدید قابل انجام است.

[**Behavior**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Behavior) یک واحد ساختمانی هر اثر انیمیشن PowerPoint است. تمام اثرهای انیمیشن در واقع مجموعه‌ای از رفتارها هستند که در یک استراتژی ترکیب می‌شوند. می‌توانید رفتارها را یک‌بار در یک انیمیشن سفارشی ترکیب کنید و آن را در ارائه‌های دیگر مجدداً استفاده کنید. اگر یک رفتار جدید به یک اثر انیمیشن استاندارد PowerPoint اضافه کنید، آن یک انیمیشن سفارشی دیگر خواهد شد. برای مثال، می‌توانید رفتار تکرار را به یک انیمیشن اضافه کنید تا چند بار تکرار شود.

[**Animation Point**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Point) نقطه‌ای است که رفتار باید در آن اعمال شود.

## **خط زمان انیمیشن**
[**Sequence**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Sequence) مجموعه‌ای از اثرهای انیمیشن است که بر روی یک شکل خاص اعمال می‌شود.

[**Timeline**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/AnimationTimeLine) مجموعه‌ای از Sequenceها است که در یک اسلاید خاص استفاده می‌شود. این یک موتور انیمیشن است که از PowerPoint 2002 به بعد وجود دارد. در نسخه‌های قبلی PowerPoint افزودن اثرهای انیمیشن به ارائه دشوار بود و فقط با راه‌حل‌های مختلف ممکن بود. Timeline جایگزین کلاس قدیمی AnimationSettings شده و مدل شیئ‌گرای واضح‌تری برای انیمیشن PowerPoint فراهم می‌کند. یک اسلاید می‌تواند فقط یک خط زمان انیمیشن داشته باشد.

## **انیمیشن تعاملی**
[**Trigger**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/EffectTriggerType) امکان تعریف اقدامات کاربر (مانند کلیک دکمه) را فراهم می‌کند که باعث شروع یک انیمیشن خاص می‌شود. Triggerها فقط در آخرین نسخه PowerPoint اضافه شده‌اند.

## **انیمیشن شکل**
Aspose.Slides امکان اعمال انیمیشن بر شکل‌ها را می‌دهد که می‌توانند شامل متن، مستطیل، خط، فریم، شیء OLE و غیره باشند.

{{% alert color="primary" %}} 
بیشتر بخوانید [**درباره انیمیشن شکل**](/slides/fa/java/shape-animation/).
{{% /alert %}}

## **نمودارهای متحرک**
برای ایجاد نمودارهای متحرک، باید از همان کلاس‌های استفاده شده برای شکل‌ها استفاده کنید. با این حال، می‌توانید انیمیشن PowerPoint را تنها بر روی دسته‌بندی‌های نمودار یا سری‌های نمودار اعمال کنید. همچنین می‌توانید اثر انیمیشن را بر روی یک عنصر دسته‌بندی یا عنصر سری اعمال کنید.

{{% alert color="primary" %}} 
بیشتر بخوانید [**درباره نمودارهای متحرک**](/slides/fa/java/animated-charts/).
{{% /alert %}}

## **متن متحرک**
علاوه بر متن متحرک، می‌توانید انیمیشن را بر روی یک پاراگراف نیز اعمال کنید.

{{% alert color="primary" %}} 
بیشتر بخوانید [**درباره متن متحرک**](/slides/fa/java/animated-text/).
{{% /alert %}}

## **سوالات متداول**

**آیا انیمیشن‌ها هنگام خروجی به PDF حفظ می‌شوند؟**

خیر. PDF یک فرمت استاتیک است، بنابراین انیمیشن‌ها و [انتقال‌های اسلاید](/slides/fa/java/slide-transition/) اجرا نمی‌شوند. اگر به حرکت نیاز دارید، به جای آن به [HTML5](/slides/fa/java/export-to-html5/)، [GIF متحرک](/slides/fa/java/convert-powerpoint-to-animated-gif/) یا [ویدئو](/slides/fa/java/convert-powerpoint-to-video/) خروجی بدهید.

**آیا می‌توانم یک ارائه متحرک را به ویدئو تبدیل کرده و نرخ فریم و اندازه فریم را کنترل کنم؟**

بله. می‌توانید [ارائه را به‌صورت فریم‌ها رندر کنید](/slides/fa/java/convert-powerpoint-to-video/) و آن‌ها را به یک ویدئو (مثلاً با ffmpeg) کدگذاری کنید، با انتخاب FPS و وضوح تصویر. انیمیشن‌ها و انتقال‌های اسلاید در طول رندر اجرا می‌شوند.

**آیا انیمیشن‌ها هنگام کار با ODP (نه فقط PPTX) به همان شکل باقی می‌مانند؟**

PPT، PPTX و ODP برای [خواندن](/slides/fa/java/open-presentation/) و [نوشتن](/slides/fa/java/save-presentation/) پشتیبانی می‌شوند، اما تفاوت‌های فرمت ممکن است باعث شود برخی اثرها کمی متفاوت ظاهر یا عمل کنند. موارد مهم را با نمونه‌های واقعی اعتبارسنجی کنید.