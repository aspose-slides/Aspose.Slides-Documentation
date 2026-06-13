---
title: "مجوز مترقی"
type: docs
weight: 100
url: /fa/nodejs-java/metered-licensing/
keywords:
- "مجوز"
- "مجوز مترقی"
- "کلیدهای مجوز"
- "کلید عمومی"
- "کلید خصوصی"
- "مقدار مصرف"
- "PowerPoint"
- "OpenDocument"
- "ارائه"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "یاد بگیرید چگونه Aspose.Slides برای Node.js از طریق مجوز مترقی جاوا به شما امکان پردازش انعطاف‌پذیر فایل‌های PowerPoint و OpenDocument را می‌دهد و تنها برای آنچه استفاده می‌کنید هزینه می‌پردازید."
---
## **مقدمه**

مجوز مترقی یک مکانیزم مجوزدهی است که می‌تواند همراه با روش‌های موجود مجوزدهی استفاده شود. اگر می‌خواهید براساس استفاده‌تان از ویژگی‌های API Aspose.Slides هزینه‌گیری شوید، مجوز مترقی را انتخاب می‌کنید.

## **اعمال کلیدهای مترقی**

هنگامی که یک مجوز مترقی خریداری می‌کنید، کلیدها (و نه یک فایل مجوز) دریافت می‌کنید. این کلید مترقی می‌تواند با استفاده از کلاس [Metered](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/metered/) که Aspose برای عملیات مترینگ فراهم کرده است، اعمال شود. برای جزئیات بیشتر، به [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered) مراجعه کنید.

1. یک نمونه از کلاس [Metered](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/metered/) ایجاد کنید.

1. کلیدهای عمومی و خصوصی خود را به متد [setMeteredKey](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/metered/#setMeteredKey) پاس بدهید.

1. برخی پردازش‌ها را انجام دهید (وظایف را اجرا کنید).

1. متد [getConsumptionQuantity](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/metered/#getConsumptionQuantity) کلاس `Metered` را فراخوانی کنید.

باید مقدار/تعداد درخواست‌های API که تا کنون مصرف کرده‌اید را مشاهده کنید.

این کد نمونه نشان می‌دهد چگونه از مجوز مترقی استفاده کنید:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// یک شیء از کلاس Metered ایجاد می‌کند
var metered = new aspose.slides.Metered();

// کلیدهای عمومی و خصوصی را به شیء Metered می‌سپارد
metered.setMeteredKey("<valid public key>", "<valid private key>");

// مقدار مقدار مصرف‌شده را قبل از فراخوانی‌های API دریافت می‌کند
var amountBefore = aspose.slides.Metered.getConsumptionQuantity();
console.log("Amount consumed before:", amountBefore);

// در اینجا کاری با API Aspose.Slides انجام دهید
// ...

// مقدار مقدار مصرف‌شده را پس از فراخوانی‌های API دریافت می‌کند
var amountAfter = aspose.slides.Metered.getConsumptionQuantity();
console.log("Amount consumed after:", amountAfter);
```

{{% alert color="warning" title="NOTE"  %}} 
برای استفاده از مجوز مترقی، به یک اتصال اینترنتی ثابت نیاز دارید زیرا مکانیزم مجوزدهی از اینترنت برای تعامل مستمر با سرویس‌های ما و انجام محاسبات استفاده می‌کند.
{{% /alert %}} 

## **سوالات متداول**

**آیا می‌توانم یک مجوز مترقی را همراه با یک مجوز معمولی (دائم یا موقت) در یک برنامه استفاده کنم؟**

بله. مجوز مترقی یک مکانیزم مجوزدهی اضافی است که می‌تواند همراه با [روش‌های مجوزدهی](/slides/fa/nodejs-java/licensing/) موجود استفاده شود. شما تصمیم می‌گیرید که هنگام شروع برنامه چه مکانیسمی را اعمال کنید.

**دقیقا چه چیزی تحت مجوز مترقی به عنوان مصرف محسوب می‌شود: عملیات‌ها یا فایل‌ها؟**

استفاده از API شمرده می‌شود، به این معنی که تعداد درخواست‌ها یا عملیات‌ها. می‌توانید مصرف فعلی را از طریق [متدهای ردیابی مصرف](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/metered/) به دست آورید.

**آیا مجوز مترگی برای میکروسرویس‌ها و محیط‌های سرورلس که نمونه‌ها به دفعات ریستارت می‌شوند مناسب است؟**

بله. چون حسابرسی در سطح فراخوانی API انجام می‌شود، سناریوهای دارای شروع سرد (cold start) مکرر سازگار هستند، به شرطی که دسترسی شبکه‌ای ثابت برای محاسبات مترگی وجود داشته باشد.

**آیا عملکرد کتابخانه هنگام استفاده از مجوز مترقی نسبت به مجوز دائمی متفاوت است؟**

خیر. این فقط دربارهٔ مکانیزم مجوزدهی و صورتحساب است؛ قابلیت‌های محصول همانند قبل هستند.

**مجوز مترگی چطور با نسخه آزمایشی و مجوز موقت مرتبط می‌شود؟**

نسخه آزمایشی محدودیت‌ها و واترمارک دارد، [مجوز موقت](https://purchase.aspose.com/temporary-license/) محدودیت‌ها را به مدت 30 روز برطرف می‌کند و مجوز مترگی هم محدودیت‌ها را برطرف می‌کند و بر اساس استفاده واقعی هزینه‌گیری می‌کند.

**آیا می‌توانم بودجه را با واکنش خودکار هنگام عبور از آستانه مصرف کنترل کنم؟**

بله. یک روش رایج این است که به‌صورت دوره‌ای مصرف فعلی را از طریق [متدهای ردیابی](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/metered/) بخوانید و محدودیت‌ها یا هشدارهای خود را در سطح برنامه یا نظارت پیاده‌سازی کنید.