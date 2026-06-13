---
title: بهبود ارائه‌های PowerPoint با انیمیشن‌ها در JavaScript
linktitle: انیمیشن PowerPoint
type: docs
weight: 150
url: /fa/nodejs-java/powerpoint-animation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "از Aspose.Slides برای Node.js از طریق Java برای پردازش انیمیشن‌های PowerPoint استفاده کنید. این مرور نکات کلیدی را برجسته می‌کند و بینش‌هایی برای بهبود ارائه‌های شما ارائه می‌دهد."
---
## **معرفی**

از آنجا که ارائه‌ها برای نشان دادن چیزی ایجاد می‌شوند، ظاهر بصری و رفتار تعاملی آن‌ها همواره هنگام ساختن مورد توجه قرار می‌گیرد.

**PowerPoint animation** نقش مهمی در جذاب و چشم‌نواز کردن ارائه برای بینندگان ایفا می‌کند. Aspose.Slides for Node.js via Java گزینه‌های متنوعی برای افزودن انیمیشن به ارائه PowerPoint فراهم می‌کند:
- اعمال انواع مختلف افکت‌های انیمیشن PowerPoint روی اشکال، نمودارها، جداول، اشیای OLE و سایر عناصر ارائه.
- استفاده از چندین افکت انیمیشن PowerPoint روی یک شکل.
- استفاده از زمان‌بندی انیمیشن برای کنترل افکت‌های انیمیشن.
- ایجاد انیمیشن سفارشی.

در Aspose.Slides for Node.js via Java، می‌توان افکت‌های مختلف انیمیشن را بر روی اشکال اعمال کرد. چون هر عنصر در اسلاید شامل متن، تصویر، شیء OLE، جدول و غیره به‌عنوان یک شکل در نظر گرفته می‌شود، می‌توانیم افکت انیمیشن را بر روی هر عنصر اسلاید اعمال کنیم.

## **افکت‌های انیمیشن**
Aspose.Slides از **بیش از 150 افکت انیمیشن** پشتیبانی می‌کند، که شامل افکت‌های اساسی مانند Bounce، PathFootball، Zoom و افکت‌های خاصی مانند OLEObjectShow، OLEObjectOpen می‌شود. می‌توانید فهرست کامل افکت‌های انیمیشن را در شمارش‌گر [**EffectType**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/effecttype/) پیدا کنید.

علاوه بر این، می‌توان این افکت‌های انیمیشن را با یکدیگر ترکیب کرد:
- [ColorEffect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SetEffect)

## **انیمیشن سفارشی**
می‌توان **انیمیشن‌های سفارشی** خود را در Aspose.Slides ایجاد کرد. این کار با ترکیب چند رفتار به‌صورت یک انیمیشن سفارشی جدید امکان‌پذیر است.

[**Behavior**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Behavior) واحد ساختاری هر افکت انیمیشن PowerPoint است. تمام افکت‌های انیمیشن در واقع مجموعه‌ای از رفتارها هستند که در یک استراتژی ترکیب می‌شوند. می‌توانید رفتارها را در یک انیمیشن سفارشی ترکیب کنید و سپس در ارائه‌های دیگر دوباره استفاده کنید. اگر یک رفتار جدید به یک افکت انیمیشن استاندارد PowerPoint اضافه کنید، یک انیمیشن سفارشی دیگر ایجاد می‌شود. برای مثال، می‌توانید رفتار تکرار را به یک انیمیشن اضافه کنید تا چند بار تکرار شود.

[**Animation Point**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Point) نقطه‌ای است که رفتار باید در آن اعمال شود.

## **خط زمان انیمیشن**
[**Sequence**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Sequence) مجموعه‌ای از افکت‌های انیمیشن است که بر روی یک شکل خاص اعمال می‌شود.

[**Timeline**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/AnimationTimeLine) مجموعه‌ای از Sequenceها است که در یک اسلاید خاص استفاده می‌شود. این یک موتور انیمیشن است که از PowerPoint 2002 معرفی شده است. در نسخه‌های قبلی PowerPoint اضافه کردن افکت‌های انیمیشن به ارائه دشوار بود و فقط با روش‌های جایگزین می‌توانست انجام شود. Timeline جایگزین کلاس قدیمی AnimationSettings شده و مدل شیء واضح‌تری برای انیمیشن PowerPoint فراهم می‌کند. یک اسلاید فقط می‌تواند یک خط زمان انیمیشن داشته باشد.

## **انیمیشن تعاملی**
[**Trigger**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/EffectTriggerType) امکان تعریف اقدامات کاربر (مانند کلیک دکمه) را فراهم می‌کند که باعث شروع یک انیمیشن خاص می‌شود. Triggerها فقط در آخرین نسخه PowerPoint اضافه شده‌اند.

## **انیمیشن شکل**
Aspose.Slides امکان اعمال انیمیشن بر روی اشکال را می‌دهد؛ این اشکال می‌توانند متن، مستطیل، خط، فریم، شیء OLE و غیره باشند.

{{% alert color="primary" %}} 
بیشتر بخوانید [**درباره انیمیشن شکل**](/slides/fa/nodejs-java/shape-animation/).
{{% /alert %}}

## **نمودارهای انیمیشنی**
برای ایجاد نمودارهای انیمیشنی باید از همان کلاس‌های مورد استفاده برای اشکال بهره ببرید. با این حال، می‌توان انیمیشن PowerPoint را فقط بر روی دسته‌های نمودار یا سری‌های نمودار اعمال کرد. همچنین می‌توانید افکت انیمیشن را بر روی عنصر یک دسته یا یک سری اعمال کنید.

{{% alert color="primary" %}} 
بیشتر بخوانید [**درباره نمودارهای انیمیشنی**](/slides/fa/nodejs-java/animated-charts/).
{{% /alert %}}

## **متن انیمیشنی**
علاوه بر متن انیمیشنی، می‌توان انیمیشن را بر روی یک پاراگراف نیز اعمال کرد.

{{% alert color="primary" %}} 
بیشتر بخوانید [**درباره متن انیمیشنی**](/slides/fa/nodejs-java/animated-text/).
{{% /alert %}}

## **سؤال‌های متداول**

**آیا انیمیشن‌ها هنگام صادرات به PDF حفظ می‌شوند؟**

خیر. PDF یک فرمت ایستا است، بنابراین انیمیشن‌ها و [slide transitions](/slides/fa/nodejs-java/slide-transition/) اجرا نمی‌شوند. اگر به حرکت نیاز دارید، به‌جای آن به [HTML5](/slides/fa/nodejs-java/export-to-html5/)، [animated GIF](/slides/fa/nodejs-java/convert-powerpoint-to-animated-gif/) یا [video](/slides/fa/nodejs-java/convert-powerpoint-to-video/) صادر کنید.

**آیا می‌توانم یک ارائه انیمیشنی را به ویدیو تبدیل کنم و نرخ فریم و اندازه فریم را کنترل کنم؟**

بله. می‌توانید [رندر کردن ارائه به‌عنوان فریم‌ها](/slides/fa/nodejs-java/convert-powerpoint-to-video/) را انجام دهید و آنها را به یک ویدیو (مثلاً با ffmpeg) کدگذاری کنید، با انتخاب FPS و رزولوشن. انیمیشن‌ها و slide transitions در طول رندرینگ اجرا می‌شوند.

**آیا انیمیشن‌ها هنگام کار با ODP (نه فقط PPTX) دست نخورده می‌مانند؟**

PPT، PPTX و ODP برای [خواندن](/slides/fa/nodejs-java/open-presentation/) و [نوشتن](/slides/fa/nodejs-java/save-presentation/) پشتیبانی می‌شوند، اما تفاوت‌های فرمت ممکن است باعث شود برخی افکت‌ها کمی متفاوت ظاهر شوند یا رفتار کنند. موارد مهم را با نمونه‌های واقعی اعتبارسنجی کنید.