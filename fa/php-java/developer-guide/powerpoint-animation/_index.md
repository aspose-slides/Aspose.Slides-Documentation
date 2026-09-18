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
- اثر انیمیشن
- انیمیشن PowerPoint
- خط زمان انیمیشن
- انیمیشن تعاملی
- انیمیشن سفارشی
- انیمیشن شکل
- نمودار متحرک
- متن متحرک
- شکل متحرک
- شی OLE متحرک
- تصویر متحرک
- جدول متحرک
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "قابلیت‌های Aspose.Slides برای PHP از طریق Java را در مدیریت انیمیشن‌های PowerPoint بررسی کنید. ویژگی‌ها و نکات کلیدی برای بهبود ارائه‌های شما."
---
## **مقدمه**

از آنجا که ارائه‌ها برای نمایش چیزی ساخته می‌شوند، ظاهر بصری و رفتار تعاملی آن‌ها همیشه در هنگام ایجاد در نظر گرفته می‌شود.

**انیمیشن PowerPoint** نقش مهمی در جذاب و گیراتر کردن ارائه برای بینندگان ایفا می‌کند. Aspose.Slides for PHP via Java گزینه‌های متعددی برای افزودن انیمیشن به ارائه‌های PowerPoint فراهم می‌کند:

- اعمال انواع مختلف اثرات انیمیشن PowerPoint بر اشکال، نمودارها، جداول، اشیاء OLE و سایر عناصر ارائه.
- استفاده از چندین اثر انیمیشن PowerPoint بر یک شکل.
- استفاده از خط زمان انیمیشن برای کنترل اثرات انیمیشن.
- ایجاد انیمیشن‌های سفارشی.

در Aspose.Slides for PHP via Java می‌توان اثرات انیمیشن مختلفی را بر شکل‌ها اعمال کرد. از آنجا که هر عنصری در یک اسلاید، شامل متن، تصاویر، اشیاء OLE و جداول، به عنوان یک شکل در نظر گرفته می‌شود، اثرات انیمیشن می‌تواند بر هر عنصر در اسلاید اعمال شود.

## **اثرهای انیمیشن**
Aspose.Slides از **بیش از 150 اثر انیمیشن** پشتیبانی می‌کند، از جمله اثرات پایه‌ای مانند Bounce، PathFootball و Zoom، و اثرات خاصی مانند OLEObjectShow و OLEObjectOpen. می‌توانید فهرست کامل را در کلاس [EffectType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/effecttype/) پیدا کنید.

- [ColorEffect](https://reference.aspose.com/slides/fa/php-java/aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/fa/php-java/aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/fa/php-java/aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/fa/php-java/aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/fa/php-java/aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/fa/php-java/aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/fa/php-java/aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/fa/php-java/aspose.slides/SetEffect)

## **انیمیشن سفارشی**
برای مثال‌های کامل PHP که رفتارها و مسیرهای حرکتی قابل ویرایش را ایجاد، بررسی و تغییر می‌دهند، به [Custom Animation](/slides/fa/php-java/custom-animation/) مراجعه کنید.

در Aspose.Slides می‌توانید **انیمیشن‌های سفارشی** خود را ایجاد کنید. این کار با ترکیب چند رفتار در یک انیمیشن سفارشی جدید امکان‌پذیر است.

[Behavior](https://reference.aspose.com/slides/fa/php-java/aspose.slides/behavior/) یک بلوک سازندهٔ اثر انیمیشن PowerPoint است. برای سفارشی‌سازی یک اثر، رفتارها را ترکیب کنید یا برای گسترش یک اثر پیش‌تعریف‌شده، یک رفتار اضافه کنید. تکرار از طریق تنظیمات زمان‌بندی پیکربندی می‌شود نه با یک رفتار تکرار جداگانه.

[Animation Point](https://reference.aspose.com/slides/fa/php-java/aspose.slides/point/) نقطه‌ای است که در آن باید یک رفتار اعمال شود.

## **خط زمان انیمیشن**
[Sequence](https://reference.aspose.com/slides/fa/php-java/aspose.slides/sequence/) مجموعه‌ای از اثرات انیمیشن است که می‌تواند به شکل‌های مختلف هدف بگیرد.

[Timeline](https://reference.aspose.com/slides/fa/php-java/aspose.slides/animationtimeline/) مجموعه‌ای از توالی‌ها است که در یک اسلاید خاص استفاده می‌شود. این یک موتور انیمیشن است که در PowerPoint 2002 معرفی شد. در نسخه‌های قدیمی PowerPoint افزودن اثرات انیمیشن به ارائه‌ها دشوار بود و فقط با راه‌حل‌های مختلف ممکن بود. خط زمان مدل شیء واضح‌تری برای انیمیشن‌های PowerPoint ارائه می‌دهد. یک اسلاید می‌تواند تنها یک خط زمان انیمیشن داشته باشد.

## **انیمیشن تعاملی**
[Trigger](https://reference.aspose.com/slides/fa/php-java/aspose.slides/effecttriggertype/) به شما امکان می‌دهد تا اقدام کاربر، مانند کلیک روی دکمه، را تعریف کنید که یک انیمیشن خاص را شروع می‌کند.

## **انیمیشن اشکال**
Aspose.Slides به شما اجازه می‌دهد تا انیمیشن‌ها را بر اشکال اعمال کنید، که می‌تواند شامل متن، مستطیل‌ها، خطوط، قاب‌ها, اشیاء OLE و موارد دیگر باشد.

{{% alert color="info" title="Note" %}}
بیشتر بخوانید [**درباره انیمیشن اشکال**](/slides/fa/php-java/shape-animation/).
{{% /alert %}}

## **نمودارهای متحرک**
برای ایجاد نمودارهای متحرک، باید از همان کلاس‌ها که برای اشکال استفاده می‌شود، بهره ببرید. با این حال، انیمیشن‌های PowerPoint فقط می‌توانند بر دسته‌های نمودار یا سری‌های نمودار اعمال شوند. همچنین می‌توانید اثرات انیمیشن را بر یک عنصر دسته یا یک عنصر سری اعمال کنید.

{{% alert color="info" title="Note" %}}
بیشتر بخوانید [**درباره نمودارهای متحرک**](/slides/fa/php-java/animated-charts/).
{{% /alert %}}

## **متن متحرک**
علاوه بر انیمیشن متن، می‌توانید انیمیشن را بر یک پاراگراف نیز اعمال کنید.

{{% alert color="info" title="Note" %}}
بیشتر بخوانید [**درباره متن متحرک**](/slides/fa/php-java/animated-text/).
{{% /alert %}}

## **پرسش‌های متداول**

**آیا انیمیشن‌ها هنگام خروجی به PDF حفظ می‌شوند؟**

خیر. PDF یک فرمت استاتیک است، بنابراین انیمیشن‌ها و [slide transitions](/slides/fa/php-java/slide-transition/) اجرا نمی‌شوند. اگر به حرکت نیاز دارید، به جای آن به [HTML5](/slides/fa/php-java/export-to-html5/)، [animated GIF](/slides/fa/php-java/convert-powerpoint-to-animated-gif/)، یا [video](/slides/fa/php-java/convert-powerpoint-to-video/) خروجی دهید.

**آیا می‌توانم یک ارائه انیمیشنی را به ویدئو تبدیل کنم و نرخ فریم و اندازه فریم را کنترل کنم؟**

بله. می‌توانید [render the presentation as frames](/slides/fa/php-java/convert-powerpoint-to-video/) را اجرا کنید و آنها را به یک ویدئو (مثلاً با استفاده از ffmpeg) رمزگذاری کنید، با انتخاب FPS و رزولوشن. انیمیشن‌ها و انتقال‌های اسلاید در هنگام رندر پخش می‌شوند.

**آیا انیمیشن‌ها هنگام کار با ODP (نه فقط PPTX) سالم باقی می‌مانند؟**

قالب‌های PPT، PPTX و ODP برای [reading](/slides/fa/php-java/open-presentation/) و [writing](/slides/fa/php-java/save-presentation/) پشتیبانی می‌شوند، اما این تضمین نمی‌کند که انیمیشن‌ها حفظ شوند. داده‌های انیمیشن سفارشی ممکن است هنگام تبدیل به ODP از دست بروند. برای مثال‌ها و راهنمایی در مورد بررسی سازگاری فرمت، به [Custom Animation](/slides/fa/php-java/custom-animation/) مراجعه کنید.