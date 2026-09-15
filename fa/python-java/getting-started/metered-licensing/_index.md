---
title: مجوز متری
type: docs
weight: 100
url: /fa/python-java/metered-licensing/
keywords:
- مجوز
- مجوز متری
- کلیدهای مجوز
- کلید عمومی
- کلید خصوصی
- مقدار مصرف
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "یاد بگیرید چگونه Aspose.Slides برای Python از طریق Java با مجوز متری به شما امکان پردازش انعطاف‌پذیر فایل‌های PowerPoint و OpenDocument را می‌دهد و فقط به ازای استفاده پرداخت می‌کنید."
---
## **معرفی**

مجوز متری یک مکانیزم مجوزدهی است که می‌تواند همراه با روش‌های مجوزدهی موجود استفاده شود. اگر می‌خواهید بر اساس استفادهٔ خود از ویژگی‌های Aspose.Slides API هزینه دریافت کنید، مجوز متری را انتخاب کنید.

## **اعمال کلیدهای متری**

{{% alert color="info" title="Note" %}}
مجوز متری یک مکانیزم جدید مجوزدهی است که می‌تواند همراه با روش‌های مجوزدهی موجود استفاده شود. اگر می‌خواهید بر اساس استفادهٔ خود از ویژگی‌های Aspose.Slides API هزینه دریافت کنید، مجوز متری را انتخاب کنید.

هنگامی که یک مجوز متری خریداری می‌کنید، کلیدهای آن را دریافت می‌کنید (و نه یک فایل لایسنس). این کلید متری می‌تواند با استفاده از کلاس [Metered](https://reference.aspose.com/slides/fa/python-java/aspose.slides/metered/) که توسط Aspose برای عملیات متری ارائه شده است، اعمال شود. برای جزئیات بیشتر، به [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered) مراجعه کنید.
{{% /alert %}}

1. یک نمونه از کلاس [Metered](https://reference.aspose.com/slides/fa/python-java/aspose.slides/metered/) ایجاد کنید.

1. کلیدهای عمومی و خصوصی خود را به متد [setMeteredKey](https://reference.aspose.com/slides/fa/python-java/aspose.slides/metered/#setMeteredKey) پاس کنید.

1. برخی پردازش‌ها (انجام وظایف) را انجام دهید.

1. متد [getConsumptionQuantity](https://reference.aspose.com/slides/fa/python-java/aspose.slides/metered/#getConsumptionQuantity) از کلاس [Metered](https://reference.aspose.com/slides/fa/python-java/aspose.slides/metered/) را صدا بزنید.

شما باید مقدار/تعداد درخواست‌های API که تا کنون مصرف کرده‌اید را مشاهده کنید.

این کد نمونه نشان می‌دهد چگونه از مجوز متری استفاده کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Metered

# یک نمونه از کلاس Metered ایجاد کنید.
metered = Metered()

try:
    # کلیدهای عمومی و خصوصی را به شیء Metered پاس دهید.
    metered.setMeteredKey("<valid public key>", "<valid private key>")

    # مقدار مصرف شده را قبل از فراخوانی‌های API دریافت کنید.
    amount_before = Metered.getConsumptionQuantity()
    print("Amount consumed before:", amount_before)

    # در اینجا کاری با API Aspose.Slides انجام دهید.
    # ...

    # مقدار مصرف شده را پس از فراخوانی‌های API دریافت کنید.
    amount_after = Metered.getConsumptionQuantity()
    print("Amount consumed after:", amount_after)
except Exception as error:
    print(error)
```

{{% alert color="warning" title="Warning"  %}}
برای استفاده از مجوز متری، به یک اتصال اینترنتی پایدار نیاز دارید زیرا مکانیزم مجوزدهی از اینترنت برای تعامل مستمر با سرویس‌های ما و انجام محاسبات استفاده می‌کند.
{{% /alert %}}

## **سوالات متداول**

**آیا می‌توانم یک مجوز متری را همراه با یک مجوز معمولی (پایدار یا موقت) در یک برنامه استفاده کنم؟**

بله. متری یک مکانیزم مجوزدهی اضافی است که می‌تواند همراه با [روش‌های مجوزدهی](/slides/fa/python-java/licensing/) موجود استفاده شود. شما هنگام راه‌اندازی برنامه، مکانیزم مورد نظر را انتخاب می‌کنید.

**دقیقاً چه چیزی به عنوان مصرف تحت یک مجوز متری محاسبه می‌شود: عملیات‌ها یا فایل‌ها؟**

مصرف بر پایهٔ استفاده از API شمارش می‌شود، به این معنی که تعداد درخواست‌ها یا عملیات‌ها. شما می‌توانید مصرف فعلی را از طریق [روش‌های ردیابی مصرف](https://reference.aspose.com/slides/fa/python-java/aspose.slides/metered/) به دست آورید.

**آیا متری برای میکروسرویس‌ها و محیط‌های سرورless که نمونه‌ها به‌طور مکرر ریستارت می‌شوند مناسب است؟**

بله. از آنجا که حسابداری در سطح فراخوانی API انجام می‌شود، سناریوهای دارای راه‌اندازی سرد مکرر سازگار هستند، به شرطی که دسترسی شبکه‌ای پایدار برای محاسبات متری موجود باشد.

**آیا عملکرد کتابخانه در هنگام استفاده از مجوز متری نسبت به مجوز دائم متفاوت است؟**

خیر. این فقط در مورد مکانیزم مجوزدهی و صدور صورتحساب است؛ قابلیت‌های محصول یکسان هستند.

**متری چگونه با نسخه آزمایشی و مجوز موقت ارتباط دارد؟**

نسخه آزمایشی دارای محدودیت‌ها و واترمارک است، [مجوز موقت](https://purchase.aspose.com/temporary-license/) محدودیت‌ها را برای ۳۰ روز برطرف می‌کند، و متری نیز محدودیت‌ها را حذف می‌کند و براساس استفادهٔ واقعی هزینه‌گیری می‌کند.

**آیا می‌توانم با واکنش خودکار هنگام عبور از آستانهٔ مصرف، بودجه را کنترل کنم؟**

بله. یک روش رایج این است که به‌صورت دوره‌ای مصرف فعلی را از طریق [روش‌های ردیابی](https://reference.aspose.com/slides/fa/python-java/aspose.slides/metered/) بخوانید و محدودیت‌ها یا هشدارهای خود را در سطح برنامه یا نظارت پیاده کنید.