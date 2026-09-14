---
title: مقایسه اسلایدهای ارائه در پایتون
linktitle: مقایسه اسلایدها
type: docs
weight: 50
url: /fa/python-java/compare-slides/
keywords:
- مقایسه اسلایدها
- مقایسه اسلاید
- PowerPoint
- OpenDocument
- ارائه
- پایتون
- Aspose.Slides
description: "به‌صورت برنامه‌نویسی ارائه‌های PowerPoint و OpenDocument را با Aspose.Slides برای پایتون از طریق جاوا مقایسه کنید. تفاوت‌های اسلاید را در کد به‌سرعت شناسایی کنید."
---
## **مرور کلی**

Aspose.Slides به شما امکان مقایسه اسلایدها، اسلایدهای طرح‌بندی و اسلایدهای مستر را با استفاده از متد [equals](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseslide/#equals) که توسط کلاس [BaseSlide](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseslide/) ارائه شده، می‌دهد. این متد زمانی که اسلایدهای مقایسه‌شده از نظر ساختار و محتوای ثابت یکسان باشند، `True` برمی‌گرداند.

## **مقایسه دو اسلاید**

متد [equals](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseslide/#equals) در کلاس [BaseSlide](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseslide/) برای اسلایدها، اسلایدهای طرح‌بندی و اسلایدهای مستری که از نظر ساختار و محتوای ثابت یکسان هستند، `True` برمی‌گرداند.

دو اسلاید برابر هستند اگر تمام اشکال، سبک‌ها، متن، انیمیشن‌ها و سایر تنظیمات آن‌ها برابر باشند. مقایسه مقادیر شناسایی‌کننده منحصر به‌فرد مانند شناسه اسلاید یا محتوای پویا مانند تاریخ فعلی در یک جای‌دار تاریخ را در نظر نمی‌گیرد.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

source_presentation = Presentation("AccessSlides.pptx")
try:
    target_presentation = Presentation("HelloWorld.pptx")
    try:
        for i in range(source_presentation.getMasters().size()):
            for j in range(target_presentation.getMasters().size()):
                if source_presentation.getMasters().get_Item(i).equals(target_presentation.getMasters().get_Item(j)):
                    print(f"AccessSlides MasterSlide#{i} is equal to HelloWorld MasterSlide#{j}")
    finally:
        target_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **سوالات متداول**

**آیا مخفی بودن یک اسلاید بر مقایسه خود اسلایدها تأثیر می‌گذارد؟**

[Hidden status](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slide/#getHidden) یک ویژگی سطح ارائه/پخش است، نه محتوای بصری. برابری دو اسلاید خاص توسط ساختار و محتوای ثابت آن‌ها تعیین می‌شود؛ صرفاً مخفی بودن یک اسلاید باعث متفاوت شدن اسلایدها نمی‌شود.

**آیا پیوندهای ابرمتنی و پارامترهای آن‌ها در نظر گرفته می‌شوند؟**

بله. پیوندها بخشی از محتوای ثابت اسلاید هستند. اگر URL یا عمل پیوند ابرمتنی متفاوت باشد، این معمولاً به عنوان تفاوت در محتوای ثابت محسوب می‌شود.

**اگر یک نمودار به یک فایل Excel خارجی ارجاع دهد، آیا محتوای آن فایل در نظر گرفته می‌شود؟**

خیر. مقایسه بر پایه خود اسلایدها انجام می‌شود. منابع داده خارجی معمولاً در زمان مقایسه خوانده نمی‌شوند؛ فقط آنچه در ساختار و وضعیت ثابت اسلاید موجود است، در نظر گرفته می‌شود.