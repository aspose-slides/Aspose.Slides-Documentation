---
title: مقایسه اسلایدهای ارائه در اندروید
linktitle: مقایسه اسلایدها
type: docs
weight: 50
url: /fa/androidjava/compare-slides/
keywords:
- مقایسه اسلایدها
- مقایسه اسلاید
- پاورپوینت
- اسناد باز
- ارائه
- اندروید
- جاوا
- Aspose.Slides
description: اسلایدهای پاورپوینت و اسناد باز را به صورت برنامه نویسی با Aspose.Slides برای اندروید مقایسه کنید. تفاوت های اسلایدها را در کد جاوا به سرعت شناسایی کنید.
---
## **بررسی کلی**

Aspose.Slides به شما امکان مقایسه اسلایدها، اسلایدهای طرح‌بندی و اسلایدهای اصلی را با استفاده از متد `equals` که توسط رابط `IBaseSlide` و کلاس `BaseSlide` ارائه شده است، می‌دهد. این متد وقتی که اسلایدهای مقایسه‌شده از نظر ساختار و محتوای ثابت یکسان باشند، `true` بر می‌گرداند.

## **مقایسه دو اسلاید**

Equals method has been added to [IBaseSlide](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IBaseSlide) interface and [BaseSlide](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/BaseSlide) class. It returns true for the slides/layout and slides/master slides which identical by its structure and static content. 

دو اسلاید برابرند اگر همه اشکال، سبک‌ها، متن‌ها، انیمیشن و سایر تنظیمات و غیره برابر باشند. مقایسه مقادیر شناسه‌های یکتا مانند SlideId و محتوای پویا مانند مقدار تاریخ جاری در مکان‌دار تاریخ را در نظر نمی‌گیرد.

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

**آیا مخفی بودن یک اسلاید بر مقایسه خودش تأثیر دارد؟**

[Hidden status](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/slide/#getHidden--) یک ویژگی سطح ارائه/پخش است، نه محتوای بصری. برابر بودن دو اسلاید خاص توسط ساختار و محتوای ثابت آنها تعیین می‌شود؛ فقط به‌خاطر مخفی بودن یک اسلاید، اسلایدها متفاوت نمی‌شوند.

**آیا پیوندهای فراخوانی (hyperlinks) و پارامترهای آن‌ها در نظر گرفته می‌شوند؟**

بله. پیوندها بخشی از محتوای ثابت اسلاید هستند. اگر URL یا عمل پیوند متفاوت باشد، معمولاً به عنوان اختلاف در محتوای ثابت در نظر گرفته می‌شود.

**اگر نمودار به یک فایل Excel خارجی ارجاع دهد، محتوای آن فایل در نظر گرفته می‌شود؟**

خیر. مقایسه بر پایه خود اسلایدها انجام می‌شود. منابع داده خارجی به‌طور کلی در زمان مقایسه خوانده نمی‌شوند؛ فقط آنچه در ساختار و حالت ثابت اسلاید وجود دارد در نظر گرفته می‌شود.