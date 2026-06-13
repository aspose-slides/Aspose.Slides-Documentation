---
title: بهبود ارائه‌های PowerPoint با انیمیشن‌ها در .NET
linktitle: انیمیشن PowerPoint
type: docs
weight: 150
url: /fa/net/powerpoint-animation/
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
- ارائه PowerPoint
- .NET
- C#
- Aspose.Slides
description: "قابلیت‌های Aspose.Slides برای .NET در مدیریت انیمیشن‌های PowerPoint را بررسی کنید. این مرور کلی ویژگی‌های کلیدی را برجسته می‌کند و بینش‌هایی برای بهبود ارائه‌های شما ارائه می‌دهد."
---
## **مقدمه**

از آنجا که ارائه‌ها برای نمایش مطلبی ساخته می‌شوند، ظاهر بصری و رفتار تعاملی آنها همیشه در زمان ایجاد در نظر گرفته می‌شود.

**انیمیشن PowerPoint** نقش مهمی در جذاب‌ و درگیر کردن بینندگان دارد. Aspose.Slides برای .NET مجموعه گسترده‌ای از گزینه‌ها را برای افزودن انیمیشن به ارائه‌های PowerPoint فراهم می‌کند:

- اعمال انواع مختلف افکت‌های انیمیشن PowerPoint به اشکال، نمودارها، جدول‌ها، اشیاء OLE و سایر عناصر ارائه.
- استفاده از چندین افکت انیمیشن PowerPoint روی یک شکل.
- بهره‌گیری از خط زمان انیمیشن برای کنترل افکت‌های انیمیشن.
- ایجاد انیمیشن‌های سفارشی.

در Aspose.Slides برای .NET، می‌توان افکت‌های انیمیشن مختلفی را به اشکال اعمال کرد. از آنجا که هر عنصر روی اسلاید، از جمله متن، تصاویر، اشیاء OLE و جدول‌ها، به عنوان یک شکل محسوب می‌شود، می‌توان افکت‌های انیمیشن را به هر عنصر روی اسلاید اعمال کرد.

[Aspose.Slides.Animation](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/)namespace کلاس‌هایی را برای کار با انیمیشن‌های PowerPoint فراهم می‌کند.

## **افکت‌های انیمیشن**

Aspose.Slides از **بیش از 150 افکت انیمیشن** پشتیبانی می‌کند، شامل افکت‌های پایه‌ای مانند Bounce، PathFootball و Zoom، و همچنین افکت‌های خاصی مانند OLEObjectShow و OLEObjectOpen. می‌توانید فهرست کامل افکت‌های انیمیشن را در شمارش [EffectType](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/effecttype) بیابید.

علاوه بر این، می‌توان این افکت‌های انیمیشن را با موارد زیر ترکیب کرد:

- [ColorEffect](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/coloreffect)
- [CommandEffect](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/commandeffect)
- [FilterEffect](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/filtereffect)
- [MotionEffect](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/motioneffect)
- [PropertyEffect](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/propertyeffect)
- [RotationEffect](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/scaleeffect)
- [SetEffect](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/seteffect)

## **انیمیشن سفارشی**

می‌توانید **انیمیشن‌های سفارشی** خود را در Aspose.Slides ایجاد کنید. این کار با ترکیب چند رفتار (behavior) به یک انیمیشن سفارشی جدید امکان‌پذیر است.

[Behaviour](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/behavior) بلوک سازنده هر افکت انیمیشن PowerPoint است. تمام افکت‌های انیمیشن در اصل مجموعه‌ای از رفتارها هستند که در یک استراتژی ترکیب می‌شوند. می‌توانید رفتارها را به یک انیمیشن سفارشی ترکیب کنید و سپس آن را در ارائه‌های دیگر دوباره استفاده کنید. اگر یک رفتار جدید به یک افکت انیمیشن استاندارد PowerPoint اضافه کنید، تبدیل به یک انیمیشن سفارشی دیگر می‌شود. به‌عنوان مثال، می‌توانید یک رفتار تکرار را به یک انیمیشن اضافه کنید تا چند بار تکرار شود.

[Animation Point](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/point) نقطه‌ای است که در آن یک رفتار باید اعمال شود.

## **خط زمان انیمیشن**

[Sequence](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/sequence) مجموعه‌ای از افکت‌های انیمیشن است که بر روی یک شکل خاص اعمال می‌شوند.

[Timeline](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/animationtimeline) مجموعه‌ای از توالی‌ها (sequences) است که در یک اسلاید خاص استفاده می‌شود. این موتور انیمیشن در PowerPoint 2002 معرفی شد. در نسخه‌های قبلی PowerPoint افزودن افکت‌های انیمیشن به ارائه‌ها دشوار بود و فقط با روش‌های دور‌زن ممکن بود. خط زمان جایگزین کلاس AnimationSettings قدیمی شد و مدل شیء واضح‌تری برای انیمیشن‌های PowerPoint فراهم می‌کند. یک اسلاید می‌تواند تنها یک خط زمان انیمیشن داشته باشد.

## **انیمیشن تعاملی**

[Trigger](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/effecttriggertype) به شما امکان می‌دهد عمل کاربری (مانند کلیک دکمه) را تعریف کنید که یک انیمیشن خاص را آغاز می‌کند. Triggerها در آخرین نسخه PowerPoint معرفی شدند.

## **انیمیشن شکل**

Aspose.Slides به شما اجازه می‌دهد انیمیشن‌ها را بر روی اشکال اعمال کنید؛ این اشکال می‌توانند شامل متن، مستطیل‌ها، خطوط، فریم‌ها، اشیاء OLE و موارد دیگر باشند.

{{% alert color="primary" %}} 
Read more[**درباره انیمیشن شکل**](/slides/fa/net/shape-animation/).
{{% /alert %}}

## **نمودارهای انیمیشنی**

برای ایجاد نمودارهای انیمیشنی، باید از همان کلاس‌ها همانند اشکال استفاده کنید. با این حال، انیمیشن‌های PowerPoint تنها می‌توانند بر روی دسته‌بندی‌های نمودار یا سری‌های نمودار اعمال شوند. همچنین می‌توانید افکت‌های انیمیشن را بر روی یک عنصر دسته یا یک عنصر سری اعمال کنید.

{{% alert color="primary" %}} 
Read more[**درباره نمودارهای انیمیشنی**](/slides/fa/net/animated-charts/).
{{% /alert %}}

## **متن انیمیشنی**

به‌جز متن انیمیشنی، امکان اعمال انیمیشن به یک پاراگراف نیز وجود دارد.

{{% alert color="primary" %}} 
Read more[**درباره متن انیمیشنی**](/slides/fa/net/animated-text/).
{{% /alert %}}

## **سوالات متداول**

**آیا انیمیشن‌ها هنگام خروجی به PDF حفظ می‌شوند؟**

نه. PDF فرمت استاتیک است، بنابراین انیمیشن‌ها و [انتقالات اسلاید](/slides/fa/net/slide-transition/) پخش نمی‌شوند. اگر به حرکت نیاز دارید، به‌جای آن به [HTML5](/slides/fa/net/export-to-html5/)، [GIF انیمیشنی](/slides/fa/net/convert-powerpoint-to-animated-gif/) یا [ویدئو](/slides/fa/net/convert-powerpoint-to-video/) خروجی بدهید.

**آیا می‌توانم یک ارائه انیمیشنی را به ویدئو تبدیل کنم و نرخ فریم و اندازه فریم را کنترل کنم؟**

بله. می‌توانید [ارائه را به فریم‌ها رندر کنید](/slides/fa/net/convert-powerpoint-to-video/) و آن‌ها را به یک ویدئو (مثلاً با ffmpeg) تبدیل کنید، به‌طوری که FPS و وضوح را انتخاب کنید. انیمیشن‌ها و انتقالات اسلاید هنگام رندر پخش می‌شوند.

**آیا انیمیشن‌ها هنگام کار با ODP (نه فقط PPTX) دست نخورده می‌مانند؟**

PPT، PPTX و ODP برای [خواندن](/slides/fa/net/open-presentation/) و [نوشتن](/slides/fa/net/save-presentation/) پشتیبانی می‌شوند، اما تفاوت‌های فرمت ممکن است باعث شود برخی افکت‌ها کمی متفاوت ظاهر شوند یا رفتار متفاوتی داشته باشند. موارد حساس را با نمونه‌های واقعی اعتبارسنجی کنید.