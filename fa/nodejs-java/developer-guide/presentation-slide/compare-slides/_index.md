---
title: مقایسه اسلایدهای ارائه در جاوااسکریپت
linktitle: مقایسه اسلایدها
type: docs
weight: 50
url: /fa/nodejs-java/compare-slides/
keywords:
- مقایسه اسلایدها
- مقایسه اسلاید
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- جاوااسکریپت
- Aspose.Slides
description: "به‌صورت برنامه‌نویسی PowerPoint و ارائه‌های OpenDocument را با Aspose.Slides برای Node.js از طریق Java مقایسه کنید. تفاوت‌های اسلاید را به‌سرعت در کد شناسایی کنید."
---
## **نمای کلی**

Aspose.Slides به شما امکان مقایسه اسلایدها، اسلایدهای چیدمان و اسلایدهای اصلی را با استفاده از متد `equals` که توسط کلاس `BaseSlide` ارائه شده است، می‌دهد. این متد زمانی که اسلایدهای مقایسه‌شده از نظر ساختار و محتوای ثابت کاملاً یکسان باشند، `true` برمی‌گرداند.

## **مقایسه دو اسلاید**

متد Equals به کلاس [BaseSlide](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/BaseSlide) و کلاس [BaseSlide](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/BaseSlide) اضافه شده است. این متد برای اسلایدهای چیدمان و اسلایدهای اصلی که از نظر ساختار و محتوای ثابت یکسان هستند، `true` برمی‌گرداند.

دو اسلاید زمانی برابر هستند که تمام اشکال، سبک‌ها، متن‌ها، انیمیشن‌ها و سایر تنظیمات و غیره یکسان باشند. مقایسه مقادیر شناسهٔ یکتا مانند SlideId یا محتویات دینامیک مانند مقدار تاریخ جاری در نگهدارندهٔ تاریخ را در نظر نمی‌گیرد.

```javascript
var presentation1 = new aspose.slides.Presentation("AccessSlides.pptx");
try {
    var presentation2 = new aspose.slides.Presentation("HelloWorld.pptx");
    try {
        for (var i = 0; i < presentation1.getMasters().size(); i++) {
            for (var j = 0; j < presentation2.getMasters().size(); j++) {
                if (presentation1.getMasters().get_Item(i).equals(presentation2.getMasters().get_Item(j))) {
                    console.log(java.callStaticMethodSync("java.lang.String", "format", "SomePresentation1 MasterSlide#%d is equal to SomePresentation2 MasterSlide#%d", i, j));
                }
            }
        }
    } finally {
        presentation2.dispose();
    }
} finally {
    presentation1.dispose();
}
```

## **سوالات متداول**

**آیا وضعیت مخفی بودن یک اسلاید بر مقایسهٔ خود اسلایدها تأثیر دارد؟**

[Hidden status](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slide/gethidden/) یک ویژگی در سطح ارائه/پخش است، نه محتوای بصری. برابری دو اسلاید خاص بر اساس ساختار و محتوای ثابت آن‌ها تعیین می‌شود؛ صرفاً این واقعیت که یک اسلاید مخفی است، باعث متفاوت شدن اسلایدها نمی‌شود.

**آیا پیوندهای فرامتن و پارامترهای آن‌ها در نظر گرفته می‌شوند؟**

بله. پیوندها بخشی از محتوای ثابت یک اسلاید هستند. اگر URL یا عمل پیوند فرامتن متفاوت باشد، معمولاً به عنوان اختلاف در محتوای ثابت در نظر گرفته می‌شود.

**اگر یک نمودار به فایل Excel خارجی ارجاع دهد، آیا محتوای آن فایل در نظر گرفته می‌شود؟**

خیر. مقایسه بر پایهٔ خود اسلایدها انجام می‌شود. منابع دادهٔ خارجی معمولاً در زمان مقایسه خوانده نمی‌شوند؛ فقط آنچه در ساختار و وضعیت ثابت اسلاید وجود دارد مورد توجه قرار می‌گیرد.