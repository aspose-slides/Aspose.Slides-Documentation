---
title: بهبود ارائه‌های PowerPoint با انیمیشن‌ها در جاوااسکریپت
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
- Node.js
- جاوااسکریپت
- Aspose.Slides
description: "از Aspose.Slides برای Node.js از طریق Java برای مدیریت انیمیشن‌های PowerPoint استفاده کنید. این مرور کلی ویژگی‌های کلیدی را برجسته می‌کند و بینش‌هایی برای بهبود ارائه‌های شما ارائه می‌دهد."
---
## **مقدمه**

از آنجا که ارائه‌ها برای نمایش چیزی ایجاد می‌شوند، ظاهر بصری و رفتار تعاملی آن‌ها همواره در زمان ساخت در نظر گرفته می‌شود.

**انیمیشن PowerPoint** نقش مهمی در جذاب و گیرای کردن ارائه برای مخاطبان ایفا می‌کند. Aspose.Slides for Node.js via Java گزینه‌های گسترده‌ای برای افزودن انیمیشن به ارائه‌های PowerPoint فراهم می‌کند:

- اعمال انواع مختلف افکت‌های انیمیشن PowerPoint روی اشکال، نمودارها، جدول‌ها، اشیای OLE و سایر عناصر ارائه.
- استفاده از چندین افکت انیمیشن PowerPoint بر روی یک شکل.
- بهره‌گیری از جدول زمان‌بندی انیمیشن برای کنترل افکت‌های انیمیشن.
- ایجاد انیمیشن‌های سفارشی.

در Aspose.Slides for Node.js via Java، می‌توان انواع مختلف افکت‌های انیمیشن را بر روی اشکال اعمال کرد. چون هر عنصر در یک اسلاید، از جمله متن، تصاویر، اشیای OLE و جدول‌ها، به عنوان یک شکل در نظر گرفته می‌شود، می‌توان افکت‌های انیمیشن را بر روی هر عنصر در اسلاید اعمال کرد.

## **افکت‌های انیمیشن**
Aspose.Slides از **بیش از 150 افکت انیمیشن** پشتیبانی می‌کند، از جمله افکت‌های پایه‌ای مانند Bounce، PathFootball و Zoom، و افکت‌های خاصی مانند OLEObjectShow و OLEObjectOpen. می‌توانید فهرست کامل را در شمارش‌گر [EffectType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/effecttype/) پیدا کنید.

علاوه بر این، این افکت‌های انیمیشن می‌توانند همراه با رفتارهای زیر استفاده شوند:

- [ColorEffect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SetEffect)

## **انیمیشن سفارشی**

برای مثال‌های کامل JavaScript که رفتارها و مسیرهای حرکتی قابل ویرایش را ایجاد، بررسی و اصلاح می‌کنند، به [Custom Animation](/slides/fa/nodejs-java/custom-animation/) مراجعه کنید.

در Aspose.Slides می‌توان **انیمیشن‌های سفارشی** خود را ایجاد کرد. این کار با ترکیب چندین رفتار در یک انیمیشن سفارشی جدید امکان‌پذیر است.

[Behavior](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/behavior/) بلوکی سازنده یک افکت انیمیشن PowerPoint است. برای سفارشی‌سازی یک افکت، رفتارها را ترکیب کنید یا یک رفتار اضافه کنید تا یک افکت از پیش تعریف شده را گسترش دهید. تکرار از طریق تنظیمات زمان‌بندی پیکربندی می‌شود نه از طریق یک رفتار تکرار جداگانه.

[Animation Point](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/point/) نقطه‌ای است که در آن یک رفتار باید اعمال شود.

## **جدول زمان‌بندی انیمیشن**
[Sequence](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/sequence/) مجموعه‌ای از افکت‌های انیمیشن است که می‌تواند به اشکال مختلف هدف‌گذاری شود.

[Timeline](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/animationtimeline/) مجموعه‌ای از توالی‌ها است که در یک اسلاید خاص استفاده می‌شود. این موتور انیمیشن در PowerPoint 2002 معرفی شد. در نسخه‌های قبلی PowerPoint، افزودن افکت‌های انیمیشن به ارائه‌ها چالش‌برانگیز بود و فقط می‌توانست با راه‌حل‌های مختلف انجام شود. جدول زمان‌بندی مدلی واضح‌تر از اشیاء برای انیمیشن‌های PowerPoint فراهم می‌کند. یک اسلاید فقط می‌تواند یک جدول زمان‌بندی انیمیشن داشته باشد.

## **انیمیشن تعاملی**
[Trigger](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/effecttriggertype/) به شما امکان می‌دهد اقدام کاربر، مانند کلیک روی دکمه، را تعریف کنید که یک انیمیشن خاص را آغاز می‌کند.

## **انیمیشن شکل**
Aspose.Slides به شما امکان می‌دهد انیمیشن‌ها را بر روی اشکال اعمال کنید که می‌توانند شامل متن، مستطیل‌ها، خطوط، فریم‌ها، اشیای OLE و موارد دیگر باشند.

{{% alert color="info" title="Note" %}}
بیشتر بخوانید [**درباره انیمیشن شکل**](/slides/fa/nodejs-java/shape-animation/).
{{% /alert %}}

## **نمودارهای انیمیشنی**
برای ایجاد نمودارهای انیمیشنی، باید از همان کلاس‌هایی که برای اشکال استفاده می‌شود، بهره ببرید. با این حال، انیمیشن‌های PowerPoint فقط می‌توانند بر روی دسته‌های نمودار یا سری‌های نمودار اعمال شوند. می‌توانید افکت‌های انیمیشن را بر روی یک عنصر دسته یا یک عنصر سری نیز اعمال کنید.

{{% alert color="info" title="Note" %}}
بیشتر بخوانید [**درباره نمودارهای انیمیشنی**](/slides/fa/nodejs-java/animated-charts/).
{{% /alert %}}

## **متن انیمیشنی**
علاوه بر انیمیشن متن، می‌توانید انیمیشن را بر روی یک پاراگراف نیز اعمال کنید.

{{% alert color="info" title="Note" %}}
بیشتر بخوانید [**درباره متن انیمیشنی**](/slides/fa/nodejs-java/animated-text/).
{{% /alert %}}

## **سؤالات متداول**

**آیا انیمیشن‌ها هنگام export به PDF حفظ می‌شوند؟**

خیر. PDF یک فرمت ثابت است، بنابراین انیمیشن‌ها و [انتقال اسلاید](/slides/fa/nodejs-java/slide-transition/) اجرا نمی‌شوند. اگر به حرکت نیاز دارید، به جای آن به [HTML5](/slides/fa/nodejs-java/export-to-html5/)، [GIF متحرک](/slides/fa/nodejs-java/convert-powerpoint-to-animated-gif/) یا [ویدیو](/slides/fa/nodejs-java/convert-powerpoint-to-video/) export کنید.

**آیا می‌توانم یک ارائه انیمیشنی را به ویدیو تبدیل کنم و نرخ فریم و اندازه فریم را کنترل کنم؟**

بله. می‌توانید [ارائه را به‌صورت فریم‌ها رندر کنید](/slides/fa/nodejs-java/convert-powerpoint-to-video/) را انجام دهید و آن‌ها را به یک ویدیو (مثلاً با ffmpeg) کدگذاری کنید، با انتخاب FPS و رزولوشن. انیمیشن‌ها و انتقال اسلایدها در طول رندر اجرا می‌شوند.

**آیا انیمیشن‌ها هنگام کار با ODP (نه فقط PPTX) دست نخواهند خورد؟**

فرمت‌های PPT، PPTX و ODP برای [خواندن](/slides/fa/nodejs-java/open-presentation/) و [نوشتن](/slides/fa/nodejs-java/save-presentation/) پشتیبانی می‌شوند، اما این تضمین‌کننده حفظ انیمیشن‌ها نیست. داده‌های انیمیشن سفارشی ممکن است هنگام تبدیل به ODP از دست بروند. برای مثال‌ها و راهنمایی درباره بررسی سازگاری فرمت، به [انیمیشن سفارشی](/slides/fa/nodejs-java/custom-animation/) مراجعه کنید.