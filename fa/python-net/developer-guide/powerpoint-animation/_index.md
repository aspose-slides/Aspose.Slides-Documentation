---
title: بهبود ارائه‌های PowerPoint با انیمیشن‌ها در Python
linktitle: انیمیشن PowerPoint
type: docs
weight: 150
url: /fa/python-net/powerpoint-animation/
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
- نمودار انیمیشن‌دار
- متن انیمیشن‌دار
- شکل انیمیشن‌دار
- شیء OLE انیمیشن‌دار
- تصویر انیمیشن‌دار
- جدول انیمیشن‌دار
- ارائه PowerPoint
- Python
- Aspose.Slides
description: "قابلیت‌های Aspose.Slides برای Python via .NET در مدیریت انیمیشن‌های PowerPoint را کشف کنید. این مرور کلی ویژگی‌های کلیدی را برجسته می‌کند و بینش‌هایی برای ارتقا ارائه‌های شما ارائه می‌دهد."
---
## **مقدمه**

ارائه‌ها برای انتقال اطلاعات طراحی می‌شوند، بنابراین ظاهر بصری و رفتار تعاملی آن‌ها در هنگام ایجاد، ملاحظات کلیدی هستند.

**انیمیشن PowerPoint** نقش مهمی در جلب توجه و جذابیت برای بینندگان دارد. Aspose.Slides for Python via .NET گزینه‌های گسترده‌ای برای افزودن انیمیشن به یک ارائه PowerPoint فراهم می‌کند. می‌توانید:

- اثرات انیمیشن مختلفی را بر روی اشکال، نمودارها، جداول، اشیاء OLE و سایر عناصر اعمال کنید.
- از چندین اثر انیمیشن روی یک شکل استفاده کنید.
- اثرات را از طریق خط زمان انیمیشن کنترل کنید.
- انیمیشن‌های سفارشی ایجاد کنید.

در Aspose.Slides for Python via .NET، می‌توان اثرات انیمیشن را بر روی اشکال اعمال کرد. چون هر عنصر روی اسلاید—از جمله متن، تصاویر، اشیاء OLE و جداول—به‌عنوان یک شکل در نظر گرفته می‌شود، می‌توانید اثرات انیمیشن را بر هر عنصر روی اسلاید اعمال کنید.

[aspose.slides.animation](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/) نام‌فضایی است که کلاس‌های مربوط به کار با انیمیشن‌های PowerPoint را فراهم می‌کند.

## **اثرهای انیمیشن**

Aspose.Slides از **بیش از 150 اثر انیمیشن** پشتیبانی می‌کند، از جمله اثرهای پایه‌ای مانند Bounce، PathFootball و Zoom، و همچنین اثرهای تخصصی مانند OLEObjectShow و OLEObjectOpen. فهرست کامل را می‌توانید در شمارش‌گر [EffectType](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/effecttype/) بیابید.

علاوه بر این، این اثرهای انیمیشن می‌توانند با اثرهای زیر ترکیب شوند:

- [ColorEffect](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/seteffect/)

## **انیمیشن سفارشی**

می‌توانید **انیمیشن‌های سفارشی** خود را در Aspose.Slides با ترکیب چند رفتار در یک اثر ایجاد کنید.

[Behavior](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/behavior/) بلوک سازنده اصلی هر اثر انیمیشن PowerPoint است. هر اثر انیمیشن اساساً مجموعه‌ای از رفتارهاست که به‌صورت یک استراتژی یا خط زمان مرتب شده‌اند. می‌توانید رفتارها را در یک انیمیشن سفارشی ترکیب کنید و سپس آن را در ارائه‌های دیگر دوباره استفاده کنید. اگر یک رفتار جدید به یک اثر انیمیشن استاندارد PowerPoint اضافه کنید، به یک انیمیشن سفارشی تبدیل می‌شود—به‌عنوان مثال، افزودن رفتار تکرار برای پخش چندبار انیمیشن.

[Animation Point](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/point/) لحظه یا موقعیتی را که یک رفتار اعمال می‌شود (یک فریم کلیدی) مشخص می‌کند.

## **خط زمان انیمیشن**

[Sequence](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/sequence/) مجموعه‌ای از اثرهای انیمیشن است که بر روی یک شکل خاص اعمال می‌شود.

[Timeline](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/animationtimeline/) مجموعه‌ای از توالی‌هاست که در یک اسلاید خاص استفاده می‌شود. این مفهوم در PowerPoint 2002 معرفی شد. در نسخه‌های قبلی PowerPoint افزودن اثرهای انیمیشن دشوار بود و اغلب نیاز به راه‌حل‌های обход داشت. Timeline جایگزین کلاس قدیمی `AnimationSettings` شده و مدل شیء واضح‌تری برای انیمیشن PowerPoint فراهم می‌کند. هر اسلاید تنها می‌تواند یک خط زمان انیمیشن داشته باشد.

## **انیمیشن تعاملی**

[Trigger](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/effecttriggertype/) به شما امکان می‌دهد اقدامات کاربر (مثل کلیک روی دکمه) را تعریف کنید که یک انیمیشن خاص را آغاز می‌کند. Triggerها فقط در آخرین نسخه‌های PowerPoint اضافه شده‌اند.

## **انیمیشن شکل‌ها**

Aspose.Slides به شما اجازه می‌دهد انیمیشن‌ها را بر روی شکل‌ها—مانند متن، مستطیل‌ها، خطوط، قاب‌ها، اشیاء OLE و غیره—اعمال کنید.

{{% alert color="primary" %}}

بیشتر بخوانید [**درباره انیمیشن شکل‌ها**](/slides/fa/python-net/shape-animation/).

{{% /alert %}}

## **نمودارهای انیمیشن‌دار**

برای ایجاد نمودارهای انیمیشن‌دار، از همان کلاس‌هایی استفاده کنید که برای شکل‌ها به کار می‌برید. با این حال، انیمیشن‌های PowerPoint فقط می‌توانند بر روی دسته‌های نمودار یا سری‌های نمودار اعمال شوند. همچنین می‌توانید یک اثر انیمیشن را بر روی یک عنصر دسته‌ای یا یک عنصر سری به‌صورت جداگانه اعمال کنید.

{{% alert color="primary" %}}

بیشتر بخوانید [**درباره نمودارهای انیمیشن‌دار**](/slides/fa/python-net/animated-charts/).

{{% /alert %}}

## **متن انیمیشن‌دار**

علاوه بر انیمیشن متن، می‌توانید انیمیشن را بر روی یک پاراگراف نیز اعمال کنید.

{{% alert color="primary" %}}

بیشتر بخوانید [**درباره متن انیمیشن‌دار**](/slides/fa/python-net/animated-text/).

{{% /alert %}}

## **سوالات متداول**

**آیا انیمیشن‌ها هنگام خروجی به PDF حفظ می‌شوند؟**

خیر. PDF یک فرمت ایستا است، بنابراین انیمیشن‌ها و [انتقالات اسلاید](/slides/fa/python-net/slide-transition/) اجرا نمی‌شوند. اگر به حرکت نیاز دارید، به جای آن به [HTML5](/slides/fa/python-net/export-to-html5/)، [GIF متحرک](/slides/fa/python-net/convert-powerpoint-to-animated-gif/) یا [ویدیو](/slides/fa/python-net/convert-powerpoint-to-video/) خروجی بگیرید.

**آیا می‌توانم یک ارائه انیمیشن‌دار را به ویدیو تبدیل کنم و نرخ فریم و اندازه فریم را کنترل کنم؟**

بله. می‌توانید [ارائه را به فریم‌ها رندر کنید](/slides/fa/python-net/convert-powerpoint-to-video/) و آن‌ها را به یک ویدیو (مثلاً با ffmpeg) رمزگذاری کنید، با انتخاب FPS و وضوح مورد نظر. انیمیشن‌ها و انتقالات اسلاید در زمان رندر پخش می‌شوند.

**آیا انیمیشن‌ها هنگام کار با ODP (نه فقط PPTX) دست نخورده می‌مانند؟**

فرمت‌های PPT، PPTX و ODP برای [خواندن](/slides/fa/python-net/open-presentation/) و [نوشتن](/slides/fa/python-net/save-presentation/) پشتیبانی می‌شوند، اما اختلافات فرمت ممکن است باعث شود برخی اثرها کمی متفاوت ظاهر یا رفتار کنند. موارد بحرانی را با نمونه‌های واقعی اعتبارسنجی کنید.