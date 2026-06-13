---
title: مقایسه اسلایدهای ارائه در جاوا
linktitle: مقایسه اسلایدها
type: docs
weight: 50
url: /fa/java/compare-slides/
keywords:
- مقایسه اسلایدها
- مقایسه اسلاید
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "مقایسه ارائه‌های PowerPoint و OpenDocument به‌صورت برنامه‌نویسی با Aspose.Slides برای جاوا. به‌سرعت تفاوت‌های اسلایدها را در کد شناسایی کنید."
---
## **بررسی کلی**

آسپوز.Slides به شما امکان مقایسه اسلایدها، اسلایدهای چیدمان و اسلایدهای قالب اصلی را با استفاده از متد `equals` که توسط رابط `IBaseSlide` و کلاس `BaseSlide` ارائه شده است، می‌دهد. این متد وقتی اسلایدهای مقایسه‌شده از نظر ساختار و محتوای ثابت یکسان باشند، مقدار `true` برمی‌گرداند.

## **مقایسه دو اسلاید**
متد Equals به رابط [IBaseSlide](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IBaseSlide) و کلاس [BaseSlide](https://reference.aspose.com/slides/fa/java/com.aspose.slides/BaseSlide) اضافه شده است. این متد برای اسلایدهای چیدمان و اسلایدهای قالب اصلی که از نظر ساختار و محتوای ثابت یکسان هستند، مقدار true را برمی‌گرداند.

دو اسلاید برابر هستند اگر تمام اشکال، سبک‌ها، متن‌ها، انیمیشن و سایر تنظیمات و غیره برابر باشند. مقایسه مقادیر شناسه‌های منحصر به فرد مانند SlideId و محتویات پویا مانند مقدار تاریخ فعلی در جای‌نگهدار تاریخ را در نظر نمی‌گیرد.

```java
Presentation presentation1 = new Presentation("AccessSlides.pptx");
try {
    Presentation presentation2 = new Presentation("HelloWorld.pptx");
    try {
        for (int i = 0; i < presentation1.getMasters().size(); i++)
        {
            for (int j = 0; j < presentation2.getMasters().size(); j++)
            {
                if (presentation1.getMasters().get_Item(i).equals(presentation2.getMasters().get_Item(j)))
                    System.out.println(String.format("SomePresentation1 MasterSlide#%d is equal to SomePresentation2 MasterSlide#%d", i, j));
            }
        }
    } finally {
        presentation2.dispose();
    }
} finally {
    presentation1.dispose();
}
```

## **پرسش‌های متداول**

**آیا مخفی بودن اسلاید بر مقایسهٔ خود اسلایدها تأثیر دارد؟**

[Hidden status](https://reference.aspose.com/slides/fa/java/com.aspose.slides/slide/#getHidden--) یک ویژگی در سطح ارائه/پخش است، نه محتوای بصری. برابری دو اسلاید خاص بر اساس ساختار و محتوای ثابت آن‌ها تعیین می‌شود؛ صرفاً مخفی بودن یک اسلاید باعث متفاوت بودن اسلایدها نمی‌شود.

**آیا لینک‌های فراخوانی و پارامترهای آن‌ها در نظر گرفته می‌شوند؟**

بله. لینک‌ها بخشی از محتوای ثابت یک اسلاید هستند. اگر URL یا اقدام لینک متفاوت باشد، معمولاً به‌عنوان تفاوتی در محتوای ثابت در نظر گرفته می‌شود.

**اگر یک نمودار به یک فایل اکسل خارجی ارجاع دهد، آیا محتویات آن فایل در نظر گرفته می‌شود؟**

خیر. مقایسه بر اساس خود اسلایدها انجام می‌شود. منابع دادهٔ خارجی معمولاً در زمان مقایسه خوانده نمی‌شوند؛ تنها آنچه در ساختار و وضعیت ثابت اسلاید وجود دارد در نظر گرفته می‌شود.