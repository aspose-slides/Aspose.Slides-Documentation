---
title: مقایسه اسلایدهای ارائه در .NET
linktitle: مقایسه اسلایدها
type: docs
weight: 50
url: /fa/net/compare-slides/
keywords:
- مقایسه اسلایدها
- مقایسه اسلاید
- پاورپوینت
- سند باز
- ارائه
- .NET
- C#
- Aspose.Slides
description: "به‌صورت برنامه‌ای اسلایدهای PowerPoint و OpenDocument را با Aspose.Slides برای .NET مقایسه کنید. به‌سرعت تفاوت‌های اسلاید را در کد شناسایی کنید."
---
## **مرور کلی**

Aspose.Slides به شما امکان می‌دهد اسلایدها، اسلایدهای طرح‌ بندی و اسلایدهای مستر را با استفاده از متد `Equals` ارائه‌شده توسط اینترفیس `IBaseSlide` و کلاس `BaseSlide` مقایسه کنید. این متد زمانی که اسلایدهای مقایسه‌شده از نظر ساختار و محتوای ثابت یکسان باشند، `true` برمی‌گرداند.

## **مقایسه دو اسلاید**

متد `Equals` به اینترفیس [IBaseSlide](https://reference.aspose.com/slides/fa/net/aspose.slides/ibaseslide) و کلاس [BaseSlide](https://reference.aspose.com/slides/fa/net/aspose.slides/baseslide) اضافه شده است. این متد برای اسلایدهای طرح‌ بندی/اسلایدهای مستر که از نظر ساختار و محتوای ثابت یکسان هستند، `true` برمی‌گرداند.

دو اسلاید زمانی برابر هستند که تمام اشکال، سبک‌ها، متن‌ها، انیمیشن‌ها و سایر تنظیمات آنها یکسان باشد. مقایسه مقادیر شناسه‌های منحصر به فرد مانند SlideId و محتوای پویا مانند مقدار تاریخ فعلی در Date Placeholder را در نظر نمی‌گیرد.

```c#
using (Presentation presentation1 = new Presentation("AccessSlides.pptx"))
using (Presentation presentation2 = new Presentation("HelloWorld.pptx"))
{
    for (int i = 0; i < presentation1.Masters.Count; i++)
    {
        for (int j = 0; j < presentation2.Masters.Count; j++)
        {
            if (presentation1.Masters[i].Equals(presentation2.Masters[j]))
                Console.WriteLine(string.Format("SomePresentation1 MasterSlide#{0} is equal to SomePresentation2 MasterSlide#{1}", i, j));
        }
    }
}
```

## **سوالات متداول**

**آیا مخفی بودن یک اسلاید بر مقایسه خود اسلایدها تأثیر دارد؟**

[Hidden status](https://reference.aspose.com/slides/fa/net/aspose.slides/slide/hidden/) یک ویژگی در سطح ارائه/پخش است، نه محتوای بصری. برابری دو اسلاید خاص بر اساس ساختار و محتوای ثابت آنها تعیین می‌شود؛ تنها به این دلیل که یک اسلاید مخفی باشد، اسلایدها متفاوت نمی‌شوند.

**آیا پیوندهای ابرمتنی و پارامترهای آنها در نظر گرفته می‌شوند؟**

بله. پیوندها بخشی از محتوای ثابت اسلاید هستند. اگر URL یا عمل پیوند ابرمتنی متفاوت باشد، معمولاً به عنوان تفاوت در محتوای ثابت در نظر گرفته می‌شود.

**اگر یک نمودار به یک فایل اکسل خارجی ارجاع دهد، آیا محتوای آن فایل در نظر گرفته می‌شود؟**

خیر. مقایسه بر پایه خود اسلایدها انجام می‌شود. منابع داده خارجی معمولاً در زمان مقایسه خوانده نمی‌شوند؛ تنها آنچه در ساختار و وضعیت ثابت اسلاید وجود دارد، در نظر گرفته می‌شود.