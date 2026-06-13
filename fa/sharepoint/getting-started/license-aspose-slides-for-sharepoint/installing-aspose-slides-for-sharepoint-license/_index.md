---
title: نصب لایسنس Aspose.Slides برای SharePoint
type: docs
weight: 10
url: /fa/sharepoint/installing-aspose-slides-for-sharepoint-license/
---
{{% alert color="primary" %}} 

پس از اینکه از ارزیابی خود راضی شدید، می‌توانید [خرید یک لایسنس](https://purchase.aspose.com/buy) کنید. قبل از خرید، مطمئن شوید که شرایط اشتراک لایسنس را درک کرده و با آن موافق هستید. لایسنس پس از پرداخت سفارش برای شما ایمیل می‌شود.

لایسنس یک بایگانی ZIP است که شامل یک بسته‌ راه‌حل SharePoint معمولی می‌باشد. این بایگانی شامل:

- Aspose.Slides.SharePoint.License.wsp – فایل بسته راه‌حل SharePoint. لایسنس به‌صورت یک راه‌حل SharePoint بسته‌بندی شده است تا استقرار و بازگشت آن در یک فارم سرور آسان باشد.
- readme.txt – دستورالعمل‌های نصب لایسنس.

{{% /alert %}} 
## **استقرار لایسنس**
نصب لایسنس از طریق کنسول سرور با استفاده از **stsadm.exe** انجام می‌شود.

{{% alert color="primary" %}} 

مسیرها برای وضوح در بخش زیر حذف شده‌اند.

{{% /alert %}} 

مراحل زیر را برای استقرار لایسنس Aspose.Slides برای SharePoint انجام دهید:

1. دستور stsadm را اجرا کنید تا راه‌حل را به فروشگاه راه‌حل‌های SharePoint اضافه کنید: 

``` xml

 Stsadm.exe -o deploysolution -name Aspose.Slides.SharePoint.License.wsp

```

2. راه‌حل را به تمام سرورهای فارم استقرار دهید: 

``` xml

 Stsadm.exe -o deploysolution -name Aspose.Slides.SharePoint.License.wsp -immediate -force

```

3. کارهای زمان‌دار مدیریتی را اجرا کنید تا استقرار بلافاصله تکمیل شود: 

``` xml

 Stsadm.exe -o execadmsvcjobs

```

{{% alert color="primary" %}} 

اگر سرویس مدیریت Windows SharePoint Services در حال اجرا نباشد، هنگام اجرای مرحله استقرار یک هشدار دریافت می‌کنید. **stsadm.exe** به این سرویس و سرویس Windows SharePoint Timer برای تکثیر داده‌های راه‌حل در سراسر فارم وابسته است. اگر این سرویس‌ها در فارم سرور شما اجرا نمی‌شوند، ممکن است لازم باشد لایسنس را بر روی هر سرور جداگانه استقرار دهید. 

{{% /alert %}} 
## **آزمایش لایسنس**
برای تست اینکه لایسنس به‌درستی نصب شده است، هر سندی را به قالب جدیدی تبدیل کنید. اگر در سند علامت آب‌نمای ارزیابی وجود نداشته باشد، لایسنس با موفقیت فعال شده است.