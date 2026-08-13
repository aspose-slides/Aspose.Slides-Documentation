---
title: مجوز متری
type: docs
weight: 100
url: /fa/java/metered-licensing/
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
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه مجوز متری Aspose.Slides برای Java به شما امکان پردازش انعطاف‌پذیر فایل‌های PowerPoint و OpenDocument را می‌دهد و تنها به‌ازای استفاده‌تان هزینه می‌کنید."
---
## **معرفی**

مجوز متری (Metered licensing) یک مکانیزم صدور مجوز است که می‌تواند همراه با روش‌های موجود صدور مجوز استفاده شود. اگر می‌خواهید بر پایهٔ استفاده‌تان از ویژگی‌های Aspose.Slides API هزینه‌گیری شوید، مجوز متری را انتخاب می‌کنید.

## **اعمال کلیدهای متری**

{{% alert color="info" %}} 

مجوز متری یک مکانیزم جدید صدور مجوز است که می‌تواند همراه با روش‌های موجود صدور مجوز استفاده شود. اگر می‌خواهید بر پایهٔ استفاده‌تان از ویژگی‌های Aspose.Slides API هزینه‌گیری شوید، مجوز متری را انتخاب می‌کنید.

زمانی که یک مجوز متری خریداری می‌کنید، کلیدها (نه یک فایل مجوز) دریافت می‌کنید. این کلید متری می‌تواند با استفاده از کلاس [Metered](https://reference.aspose.com/slides/fa/java/com.aspose.slides/metered/) که Aspose برای عملیات متری فراهم کرده است، اعمال گردد. برای جزئیات بیشتر، به [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered) مراجعه کنید.

{{% /alert %}} 

1. یک نمونه از کلاس [Metered](https://reference.aspose.com/slides/fa/java/com.aspose.slides/metered/) ایجاد کنید.

2. کلیدهای عمومی و خصوصی خود را به متد [setMeteredKey](https://reference.aspose.com/slides/fa/java/com.aspose.slides/metered/#setMeteredKey-java.lang.String-java.lang.String-) پاس دهید.

3. برخی پردازش‌ها (وظایف) را انجام دهید.

4. متد [getConsumptionQuantity](https://reference.aspose.com/slides/fa/java/com.aspose.slides/metered/#getConsumptionQuantity--) از کلاس `Metered` را فراخوانی کنید.

باید مقدار/تعداد درخواست‌های API که تا کنون مصرف کرده‌اید را مشاهده کنید.

این کد نمونه نشان می‌دهد چگونه از مجوز متری استفاده کنید:

```java
// یک نمونه از کلاس Metered ایجاد می‌کند
com.aspose.slides.Metered metered = new com.aspose.slides.Metered();

try {
    // کلید عمومی و خصوصی را به شی Metered می‌گذارد
    metered.setMeteredKey("<valid public key>", "<valid private key>");

    // مقدار مصرف شده را قبل از فراخوانی API دریافت می‌کند
    double amountBefore = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Amount consumed before: " + amountBefore);

    // کاری با API Aspose.Slides در اینجا انجام دهید
    // ...

    // مقدار مصرف شده را پس از فراخوانی API دریافت می‌کند
    double amountAfter = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Amount consumed after: " + amountAfter);
} catch (Exception ex) {
    ex.printStackTrace();
}
```

{{% alert color="warning" title="NOTE"  %}} 

برای استفاده از مجوز متری، به یک اتصال اینترنتی پایدار نیاز دارید زیرا مکانیزم صدور مجوز برای تعامل مستمر با سرویس‌های ما و انجام محاسبات از اینترنت استفاده می‌کند.

{{% /alert %}} 

## **سؤالات متداول**

### آیا می‌توانم یک مجوز متری را به همراه یک مجوز عادی (دائم یا موقت) در یک برنامه استفاده کنم؟

بله. مجوز متری یک مکانیزم اضافه‌ای است که می‌تواند همراه با روش‌های [صدور مجوز](/slides/fa/java/licensing/) موجود به کار رود. شما می‌توانید در زمان شروع برنامه، مکانیزم مورد نظر را انتخاب کنید.

### دقیقاً چه چیزی تحت یک مجوز متری به عنوان مصرف درنظر گرفته می‌شود: عملیات‌ها یا فایل‌ها؟

مصرف بر پایهٔ استفاده از API شمارش می‌شود، یعنی تعداد درخواست‌ها یا عملیات‌ها. می‌توانید مصرف فعلی را از طریق [روش‌های ردیابی مصرف](https://reference.aspose.com/slides/fa/java/com.aspose.slides/metered/) به دست آورید.

### آیا مجوز متری برای میکروسرویس‌ها و محیط‌های بدون‌سرور که نمونه‌ها به‌طور مکرر راه‌اندازی می‌شوند مناسب است؟

بله. از آنجا که حساب‌گذاری در سطح فراخوانی API انجام می‌شود، سناریوهای با شروع سرد مکرر سازگار هستند، به شرطی که دسترسی شبکه‌ای پایدار برای محاسبات متری موجود باشد.

### آیا عملکرد کتابخانه هنگام استفاده از مجوز متری نسبت به مجوز دائمی متفاوت است؟

خیر. این فقط مربوط به مکانیزم صدور مجوز و هزینه‌گیری است؛ قابلیت‌های محصول همانند قبل می‌ماند.

### مجوز متری چه ارتباطی با نسخه آزمایشی و مجوز موقت دارد؟

نسخه آزمایشی محدودیت‌ها و واترمارک دارد، [مجوز موقت](https://purchase.aspose.com/temporary-license/) محدودیت‌ها را برای ۳۰ روز حذف می‌کند و مجوز متری نیز محدودیت‌ها را حذف کرده و بر پایهٔ استفاده واقعی هزینه می‌گیرد.

### آیا می‌توانم بودجه را با واکنش خودکار وقتی آستانه مصرف عبور کرد، کنترل کنم؟

بله. یک روش رایج این است که به‌طور دوره‌ای مصرف فعلی را از طریق [روش‌های ردیابی](https://reference.aspose.com/slides/fa/java/com.aspose.slides/metered/) بخوانید و محدودیت‌ها یا هشدارهای خود را در سطح برنامه یا نظارت پیاده‌سازی کنید.