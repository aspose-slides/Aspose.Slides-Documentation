---
title: تقویت ارائه‌های PowerPoint با انیمیشن‌ها در Java
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
- جلوه انیمیشن
- انیمیشن PowerPoint
- جدول زمانی انیمیشن
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
description: "قابلیت‌های Aspose.Slides برای Java در پردازش انیمیشن‌های PowerPoint را کشف کنید. این مرور کلی ویژگی‌های کلیدی را برجسته می‌کند و بینش‌هایی برای بهبود ارائه‌های شما ارائه می‌دهد."
---
## **مقدمه**

از آنجایی که ارائه‌ها برای نمایش چیزی ساخته می‌شوند، ظاهر بصری و رفتار تعاملی آن‌ها همواره در هنگام ایجاد مورد توجه قرار می‌گیرد.

**انیمیشن PowerPoint** نقش مهمی در جذاب و جلب توجه مخاطبان به ارائه دارد. Aspose.Slides گزینه‌های متنوعی برای افزودن انیمیشن به ارائه‌های PowerPoint فراهم می‌کند:

- اعمال انواع مختلف جلوه‌های انیمیشن PowerPoint بر شکل‌ها، نمودارها، جدول‌ها، اشیای OLE و سایر عناصر ارائه.
- استفاده از چندین جلوه انیمیشن PowerPoint بر یک شکل.
- بهره‌گیری از جدول زمانی انیمیشن برای کنترل جلوه‌های انیمیشن.
- ایجاد انیمیشن‌های سفارشی.

در Aspose.Slides می‌توان جلوه‌های انیمیشن مختلفی را بر شکل‌ها اعمال کرد. از آنجا که هر عنصر روی اسلاید، شامل متن، تصویر، اشیای OLE و جدول‌ها، به عنوان یک شکل در نظر گرفته می‌شود، می‌توان جلوه‌های انیمیشن را بر هر عنصر روی اسلاید اعمال کرد.

## **جلوه‌های انیمیشن**
Aspose.Slides از **بیش از 150 جلوه انیمیشن** پشتیبانی می‌کند، از جمله جلوه‌های پایه‌ای مانند Bounce، PathFootball و Zoom، و جلوه‌های خاصی مانند OLEObjectShow و OLEObjectOpen. فهرست کامل را می‌توانید در کلاس [EffectType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/effecttype/) پیدا کنید.

علاوه بر این، می‌توان این جلوه‌های انیمیشن را با رفتارهای زیر ترکیب کرد:

- [ColorEffect](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/fa/java/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/fa/java/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/fa/java/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/fa/java/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/fa/java/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/fa/java/com.aspose.slides/SetEffect)

## **انیمیشن سفارشی**

برای مثال‌های کامل Java که رفتارها و مسیرهای حرکتی قابل ویرایش را ایجاد، بررسی و اصلاح می‌کنند، به [Custom Animation](/slides/fa/java/custom-animation/) مراجعه کنید.

در Aspose.Slides می‌توانید **انیمیشن‌های سفارشی** خود را ایجاد کنید. این کار با ترکیب چندین رفتار در یک انیمیشن سفارشی جدید امکان‌پذیر است.

[Behavior](https://reference.aspose.com/slides/fa/java/com.aspose.slides/behavior/) یک بلوک سازندهٔ جلوهٔ انیمیشن PowerPoint است. رفتارها را ترکیب کنید تا یک جلوه را سفارشی کنید یا یک رفتار اضافه کنید تا جلوهٔ از پیش تعریف‌شده را گسترش دهید. تکرار از طریق تنظیمات زمان‌بندی پیکربندی می‌شود نه از طریق رفتار تکرار جداگانه.

[Animation Point](https://reference.aspose.com/slides/fa/java/com.aspose.slides/point/) نقطه‌ای است که رفتار باید در آن اعمال شود.

## **جدول زمانی انیمیشن**
[Sequence](https://reference.aspose.com/slides/fa/java/com.aspose.slides/sequence/) مجموعه‌ای از جلوه‌های انیمیشن است که می‌توانند هدف‌گیری شکل‌های مختلفی داشته باشند.

[Timeline](https://reference.aspose.com/slides/fa/java/com.aspose.slides/animationtimeline/) مجموعه‌ای از توالی‌ها را که در یک اسلاید خاص استفاده می‌شوند، تعریف می‌کند. این یک موتور انیمیشن است که در PowerPoint 2002 معرفی شد. در نسخه‌های قبلی PowerPoint افزودن جلوه‌های انیمیشن به ارائه‌ها دشوار بود و تنها با راه‌حل‌های مختلفی می‌توانست انجام شود. جدول زمانی مدل شیء واضح‌تری برای انیمیشن‌های PowerPoint ارائه می‌دهد. یک اسلاید می‌تواند فقط یک جدول زمانی انیمیشن داشته باشد.

## **انیمیشن تعاملی**
[Trigger](https://reference.aspose.com/slides/fa/java/com.aspose.slides/effecttriggertype/) به شما امکان می‌دهد اقدامات کاربر، مانند کلیک دکمه، را که یک انیمیشن خاص را آغاز می‌کند، تعریف کنید.

## **انیمیشن شکل**
Aspose.Slides به شما این امکان را می‌دهد که انیمیشن‌ها را بر شکل‌ها اعمال کنید، که می‌توانند شامل متن، مستطیل، خطوط، قاب‌ها، اشیای OLE و موارد دیگر باشند.

{{% alert color="info" title="نکته" %}}
بیشتر بخوانید [**دربارهٔ انیمیشن شکل**](/slides/fa/java/shape-animation/).
{{% /alert %}}

## **نمودارهای انیمیشنی**
برای ایجاد نمودارهای انیمیشنی باید از همان کلاس‌ها همانند شکل‌ها استفاده کنید. با این حال، انیمیشن‌های PowerPoint فقط می‌توانند بر دسته‌های نمودار یا سری‌های نمودار اعمال شوند. همچنین می‌توانید جلوه‌های انیمیشن را بر یک عنصر دسته یا یک عنصر سری اعمال کنید.

{{% alert color="info" title="نکته" %}}
بیشتر بخوانید [**دربارهٔ نمودارهای انیمیشنی**](/slides/fa/java/animated-charts/).
{{% /alert %}}

## **متن انیمیشنی**
علاوه بر انیمیشن متن، می‌توانید انیمیشن را بر یک پاراگراف اعمال کنید.

{{% alert color="info" title="نکته" %}}
بیشتر بخوانید [**دربارهٔ متن انیمیشنی**](/slides/fa/java/animated-text/).
{{% /alert %}}

## **سؤالات متداول**

**آیا انیمیشن‌ها هنگام خروجی به PDF حفظ می‌شوند؟**

نه. PDF یک قالب ایستا است، بنابراین انیمیشن‌ها و [تبدیل اسلاید](/slides/fa/java/slide-transition/) اجرا نمی‌شوند. اگر به حرکت نیاز دارید، به جای آن به [HTML5](/slides/fa/java/export-to-html5/)، [GIF انیمیشنی](/slides/fa/java/convert-powerpoint-to-animated-gif/) یا [ویدئو](/slides/fa/java/convert-powerpoint-to-video/) خروجی بگیرید.

**آیا می‌توانم یک ارائهٔ انیمیشنی را به ویدئو تبدیل کنم و نرخ فریم و اندازه فریم را کنترل کنم؟**

بله. می‌توانید [ارائه را به فریم‌ها رندر کنید](/slides/fa/java/convert-powerpoint-to-video/) و آن‌ها را به یک ویدئو (مثلاً با ffmpeg) تبدیل کنید، با انتخاب FPS و وضوح. انیمیشن‌ها و تبدیل اسلایدها هنگام رندر پخش می‌شوند.

**آیا انیمیشن‌ها هنگام کار با ODP (نه فقط PPTX) دست نخورده می‌مانند؟**

پشتیبانی برای خواندن [/slides/fa/java/open-presentation/] و نوشتن [/slides/fa/java/save-presentation/] از فرمت‌های PPT، PPTX و ODP وجود دارد، اما این به معنای حفظ انیمیشن نیست. داده‌های انیمیشن سفارشی ممکن است هنگام تبدیل به ODP از دست بروند. برای مثال‌ها و راهنمایی دربارهٔ سازگاری فرمت به [Custom Animation](/slides/fa/java/custom-animation/) مراجعه کنید.