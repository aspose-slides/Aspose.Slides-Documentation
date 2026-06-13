---
title: بهبود ارائه‌های PowerPoint با انیمیشن‌ها در PHP
linktitle: انیمیشن PowerPoint
type: docs
weight: 150
url: /fa/php-java/powerpoint-animation/
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
- نمودار انیمیشن‌دار
- متن انیمیشن‌دار
- شکل انیمیشن‌دار
- شی OLE انیمیشن‌دار
- تصویر انیمیشن‌دار
- جدول انیمیشن‌دار
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "قابلیت‌های Aspose.Slides برای PHP از طریق Java در مدیریت انیمیشن‌های PowerPoint را بررسی کنید. ویژگی‌ها و نکات کلیدی برای بهبود ارائه‌های شما."
---
## **مقدمه**

از آنجا که ارائه‌ها برای نمایش چیزی ساخته می‌شوند، ظاهر بصری و رفتار تعاملی آن‌ها همواره در هنگام ایجاد لحاظ می‌شود.

**انیمیشن PowerPoint** نقش مهمی در جذاب و دیدنی کردن ارائه برای بینندگان دارد. Aspose.Slides برای PHP از طریق Java گزینه‌های گسترده‌ای برای افزودن انیمیشن به ارائه PowerPoint ارائه می‌دهد:

- اعمال انواع مختلف افکت‌های انیمیشن PowerPoint روی اشکال، نمودارها، جداول، اشیای OLE و سایر عناصر ارائه.
- استفاده از چندین افکت انیمیشن PowerPoint بر روی یک شکل.
- استفاده از جدول زمان‌بندی انیمیشن برای کنترل افکت‌های انیمیشن.
- ایجاد انیمیشن سفارشی.

در Aspose.Slides برای PHP از طریق Java، می‌توان انواع افکت‌های انیمیشن را بر روی اشکال اعمال کرد. از آنجا که هر عنصر در اسلاید شامل متن، تصویر، شی OLE، جدول و غیره به عنوان یک شکل در نظر گرفته می‌شود، می‌توانیم افکت انیمیشن را بر روی هر عنصر اسلاید اعمال کنیم.

## **افکت‌های انیمیشن**

Aspose.Slides از **150+ افکت انیمیشن** پشتیبانی می‌کند، از جمله افکت‌های پایه مانند Bounce، PathFootball، افکت Zoom و افکت‌های خاص مانند OLEObjectShow، OLEObjectOpen. می‌توانید فهرست کامل افکت‌های انیمیشن را در شمارش [**EffectType**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/effecttype/) پیدا کنید.

علاوه بر این، می‌توان این افکت‌های انیمیشن را با موارد زیر ترکیب کرد:

- [ColorEffect](https://reference.aspose.com/slides/fa/php-java/aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/fa/php-java/aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/fa/php-java/aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/fa/php-java/aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/fa/php-java/aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/fa/php-java/aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/fa/php-java/aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/fa/php-java/aspose.slides/SetEffect)

## **انیمیشن سفارشی**

در Aspose.Slides می‌توانید **انیمیشن‌های سفارشی** خود را ایجاد کنید. این کار می‌تواند با ترکیب چند رفتار در یک انیمیشن سفارشی جدید به دست آید.

[**Behavior**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Behavior) یک واحد سازنده هر افکت انیمیشن PowerPoint است. تمام افکت‌های انیمیشن در واقع مجموعه‌ای از رفتارها هستند که در یک استراتژی ترکیب می‌شوند. می‌توانید رفتارها را یک بار در یک انیمیشن سفارشی ترکیب کنید و در ارائه‌های دیگر دوباره استفاده کنید. اگر یک رفتار جدید را به یک افکت انیمیشن استاندارد PowerPoint اضافه کنید، آن یک انیمیشن سفارشی دیگر خواهد شد. به عنوان مثال، می‌توانید رفتار تکرار را به یک انیمیشن اضافه کنید تا چند بار تکرار شود.

[**Animation Point**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Point) نقطه‌ای است که رفتار باید بر آن اعمال شود.

## **خط زمانی انیمیشن**

[**Sequence**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Sequence) مجموعه‌ای از افکت‌های انیمیشن است که بر روی یک شکل مشخص اعمال می‌شود.

[**Timeline**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/AnimationTimeLine) مجموعه‌ای از Sequenceهاست که در یک اسلاید خاص استفاده می‌شود. این یک موتور انیمیشن است که از PowerPoint 2002 به بعد موجود است. در نسخه‌های قبلی PowerPoint افزودن افکت‌های انیمیشن به ارائه چالش‌برانگیز بود و تنها با راه‌حل‌های مختلف امکان‌پذیر بود. Timeline جایگزین کلاس قدیمی AnimationSettings شده و مدل شیء واضح‌تری برای انیمیشن PowerPoint فراهم می‌کند. یک اسلاید می‌تواند تنها یک خط زمانی انیمیشن داشته باشد.

## **انیمیشن تعاملی**

[**Trigger**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/EffectTriggerType) امکان تعریف اقدامات کاربر (مانند کلیک دکمه) را می‌دهد که یک انیمیشن خاص را آغاز می‌کند. Triggerها تنها در جدیدترین نسخه PowerPoint اضافه شده‌اند.

## **انیمیشن شکل**

Aspose.Slides امکان اعمال انیمیشن بر روی شکل‌ها را می‌دهد؛ این شکل‌ها می‌توانند متن، مستطیل، خط، قاب، شی OLE و غیره باشند.

{{% alert color="primary" %}} 
Read more [**درباره انیمیشن شکل**](/slides/fa/php-java/shape-animation/).
{{% /alert %}}

## **نمودارهای انیمیشنی**

برای ایجاد نمودارهای انیمیشنی، باید از همان کلاس‌هایی که برای شکل‌ها استفاده می‌شود استفاده کنید. با این حال، می‌توان انیمیشن PowerPoint را فقط بر روی دسته‌های نمودار یا سری‌های نمودار اعمال کرد. همچنین می‌توانید افکت انیمیشن را بر روی یک عنصر دسته یا عنصر سری اعمال کنید.

{{% alert color="primary" %}} 
Read more [**درباره نمودارهای انیمیشنی**](/slides/fa/php-java/animated-charts/).
{{% /alert %}}

## **متن انیمیشنی**

به جز متن انیمیشنی، می‌توان انیمیشن را بر روی یک پاراگراف نیز اعمال کرد.

{{% alert color="primary" %}} 
Read more [**درباره متن انیمیشنی**](/slides/fa/php-java/animated-text/).
{{% /alert %}}

## **سوالات متداول**

**آیا انیمیشن‌ها هنگام استخراج به PDF حفظ می‌شوند؟**

خیر. PDF یک قالب ثابت است، بنابراین انیمیشن‌ها و [انتقال‌های اسلاید](/slides/fa/php-java/slide-transition/) اجرا نمی‌شوند. اگر به حرکت نیاز دارید، به‌جای آن به [HTML5](/slides/fa/php-java/export-to-html5/)، [GIF انیمیشنی](/slides/fa/php-java/convert-powerpoint-to-animated-gif/) یا [ویدئو](/slides/fa/php-java/convert-powerpoint-to-video/) استخراج کنید.

**آیا می‌توانم یک ارائه انیمیشنی را به ویدئو تبدیل کنم و نرخ فریم و اندازه فریم را کنترل کنم؟**

بله. می‌توانید [ارائه را به فرم فریم‌ها رندر کنید](/slides/fa/php-java/convert-powerpoint-to-video/) و آن‌ها را به یک ویدئو (مثلاً با ffmpeg) رمزنگاری کنید، FPS و وضوح را انتخاب نمایید. انیمیشن‌ها و انتقال‌های اسلاید در هنگام رندر اجرا می‌شوند.

**آیا انیمیشن‌ها هنگام کار با ODP (نه فقط PPTX) دست نخواهند داد؟**

فرمت‌های PPT، PPTX و ODP برای [خواندن](/slides/fa/php-java/open-presentation/) و [نوشتن](/slides/fa/php-java/save-presentation/) پشتیبانی می‌شوند، اما تفاوت‌های قالب ممکن است باعث شود برخی افکت‌ها کمی متفاوت ظاهر یا رفتار کنند. موارد حیاتی را با نمونه‌های واقعی اعتبارسنجی کنید.