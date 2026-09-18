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
description: "یاد بگیرید چگونه اثرهای پیشرفته انیمیشن را در Aspose.Slides برای C++ اضافه و کنترل کنید تا ارائه‌های پویا در PowerPoint و OpenDocument بسازید."
---
## **مقدمه**

از آنجا که ارائه‌ها برای نمایش چیزی ساخته می‌شوند، ظاهر بصری و رفتار تعاملی آن‌ها همواره در هنگام ایجاد در نظر گرفته می‌شود.

**PowerPoint animation** نقش مهمی در جذاب و جلب توجه بینندگان برای ارائه دارد. Aspose.Slides گزینه‌های متعددی برای افزودن انیمیشن به ارائه‌های پاورپوینت فراهم می‌کند:

- اعمال انواع مختلفی از اثرهای انیمیشن پاورپوینت بر اشکال، نمودارها، جداول، اشیاء OLE و سایر عناصر ارائه.
- استفاده از چندین اثر انیمیشن پاورپوینت بر یک شکل.
- استفاده از جدول زمانی انیمیشن برای کنترل اثرهای انیمیشن.
- ایجاد انیمیشن‌های سفارشی.

در Aspose.Slides می‌توان انواع مختلفی از اثرهای انیمیشن را بر اشکال اعمال کرد. از آنجا که هر عنصر در یک اسلاید، از جمله متن، تصویر، اشیاء OLE و جداول، به‌عنوان یک شکل در نظر گرفته می‌شود، می‌توان اثرهای انیمیشن را بر هر عنصر در اسلاید اعمال کرد.

فضای نام [Aspose::Slides::Animation](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/) کلاس‌هایی را برای کار با انیمیشن‌های پاورپوینت فراهم می‌کند.

## **اثرهای انیمیشن**
Aspose.Slides از **بیش از 150 اثر انیمیشن** پشتیبانی می‌کند، از جمله اثرهای پایه‌ای مانند Bounce، PathFootball و Zoom، و اثرهای خاص مانند OLEObjectShow و OLEObjectOpen. می‌توانید فهرست کامل را در شمارش‌گر [EffectType](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/effecttype/) بیابید.

علاوه بر این، این اثرهای انیمیشن می‌توانند در ترکیب با رفتارهای زیر استفاده شوند:

- [ColorEffect](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/rotationeffect/)
- [ScaleEffect](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/seteffect/)

## **انیمیشن سفارشی**

برای مثال‌های کامل C++ که رفتارها و مسیرهای حرکتی قابل ویرایش را ایجاد، بررسی و اصلاح می‌کند، به [Custom Animation](/slides/fa/cpp/custom-animation/) مراجعه کنید.

امکان ایجاد **انیمیشن‌های سفارشی** خود در Aspose.Slides وجود دارد. این کار می‌تواند با ترکیب چندین رفتار در یک انیمیشن سفارشی جدید انجام شود.

[Behavior](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/behavior/) یک بلوک ساختاری اثر انیمیشن پاورپوینت است. برای سفارشی‌سازی یک اثر، رفتارها را ترکیب کنید یا برای گسترش یک اثر پیش تعریف شده، رفتار اضافه کنید. تکرار از طریق تنظیمات زمان‌بندی پیکربندی می‌شود نه از طریق رفتار تکرار جداگانه.

[Animation Point](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/point/) نقطه‌ای است که در آن باید یک رفتار اعمال شود.

## **خط زمان انیمیشن**
[Sequence](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/sequence/) مجموعه‌ای از اثرهای انیمیشن است که می‌تواند به اشکال مختلف هدف‌گذاری شود.

[IAnimationTimeLine](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ianimationtimeline/) مجموعه‌ای از توالی‌هاست که در یک اسلاید خاص استفاده می‌شود. این یک موتور انیمیشن است که در پاورپوینت 2002 معرفی شد. در نسخه‌های قبلی پاورپوینت، افزودن اثرهای انیمیشن به ارائه‌ها دشوار بود و فقط با راه‌حل‌های مختلفی می‌توانست انجام شود. جدول زمان‌دار یک مدل شیء واضح‌تر برای انیمیشن‌های پاورپوینت ارائه می‌دهد. یک اسلاید می‌تواند تنها یک جدول زمان‌دار انیمیشن داشته باشد.

## **انیمیشن تعاملی**
[Trigger](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/effecttriggertype/) به شما اجازه می‌دهد اقدامات کاربر، مانند کلیک دکمه، را تعریف کنید که یک انیمیشن خاص را آغاز می‌کند.

## **انیمیشن شکل**
Aspose.Slides به شما اجازه می‌دهد انیمیشن‌ها را بر روی اشکال اعمال کنید، که می‌توانند شامل متن، مستطیل‌ها، خطوط، فریم‌ها، اشیاء OLE و موارد دیگر باشند.

{{% alert color="info" title="Note" %}}
بیشتر بخوانید [**درباره انیمیشن شکل**](/slides/fa/cpp/shape-animation/).
{{% /alert %}}

## **نمودارهای انیمیشنی**
برای ایجاد نمودارهای انیمیشنی، باید از همان کلاس‌ها همانند اشکال استفاده کنید. با این حال، انیمیشن‌های پاورپوینت تنها می‌توانند بر روی دسته‌های نمودار یا سری‌های نمودار اعمال شوند. همچنین می‌توانید اثرهای انیمیشن را بر یک عنصر دسته یا یک عنصر سری اعمال کنید.

{{% alert color="info" title="Note" %}}
بیشتر بخوانید [**درباره نمودارهای انیمیشنی**](/slides/fa/cpp/animated-charts/).
{{% /alert %}}

## **متن انیمیشنی**
علاوه بر انیمیشن متن، می‌توانید انیمیشن را بر یک پاراگراف اعمال کنید.

{{% alert color="info" title="Note" %}}
بیشتر بخوانید [**درباره متن انیمیشنی**](/slides/fa/cpp/animated-text/).
{{% /alert %}}

## **سوالات متداول**

**آیا انیمیشن‌ها هنگام خروجی گرفتن به PDF حفظ می‌شوند؟**

خیر. PDF یک قالب استاتیک است، بنابراین انیمیشن‌ها و [slide transitions](/slides/fa/cpp/slide-transition/) اجرا نمی‌شوند. اگر به حرکت نیاز دارید، به جای آن به [HTML5](/slides/fa/cpp/export-to-html5/)، [animated GIF](/slides/fa/cpp/convert-powerpoint-to-animated-gif/) یا [video](/slides/fa/cpp/convert-powerpoint-to-video/) خروجی بگیرید.

**آیا می‌توانم یک ارائهٔ انیمیشنی را به ویدئو تبدیل کنم و نرخ فریم و اندازه فریم را کنترل کنم؟**

بله. می‌توانید [ارائه را به‌عنوان فریم‌ها رندر کنید](/slides/fa/cpp/convert-powerpoint-to-video/) و آن‌ها را به یک ویدئو (مثلاً با ffmpeg) کدگذاری کنید، با انتخاب FPS و وضوح. انیمیشن‌ها و انتقالات اسلاید در هنگام رندر اجرا می‌شوند.

**آیا انیمیشن‌ها هنگام کار با ODP (نه فقط PPTX) دست نخورده می‌مانند؟**

PPT، PPTX و ODP برای [reading](/slides/fa/cpp/open-presentation/) و [writing](/slides/fa/cpp/save-presentation/) پشتیبانی می‌شوند، اما این تضمین‌کننده حفظ انیمیشن نیست. داده‌های انیمیشن سفارشی ممکن است هنگام تبدیل به ODP از دست بروند. برای مثال‌ها و راهنمایی در مورد بررسی سازگاری فرمت، به [Custom Animation](/slides/fa/cpp/custom-animation/) مراجعه کنید.