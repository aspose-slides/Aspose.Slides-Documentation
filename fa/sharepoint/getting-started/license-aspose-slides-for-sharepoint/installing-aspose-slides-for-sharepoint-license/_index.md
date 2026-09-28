---
title: نصب لایسنس Aspose.Slides برای SharePoint
type: docs
weight: 10
url: /fa/sharepoint/installing-aspose-slides-for-sharepoint-license/
description: "لایسنس Aspose.Slides برای SharePoint را بر روی یک فارم SharePoint نصب کنید: راه‌حل لایسنس را به فروشگاه راه‌حل‌ها اضافه کنید، آن را استقرار دهید، و تأیید کنید که فایل‌های تبدیل‌شده دیگر واترمارک ارزیابی را نشان نمی‌دهند."
---
{{% alert color="info" title="Note" %}}

پس از اینکه از ارزیابی خود راضی شدید، می‌توانید [خرید یک لایسنس](https://purchase.aspose.com/pricing/slides/fa/sharepoint/). قبل از خرید، اطمینان حاصل کنید که شرایط اشتراک لایسنس را درک کرده و با آن موافقید. لایسنس پس از پرداخت سفارش برای شما ایمیل می‌شود.

لایسنس یک آرشیو ZIP است که شامل یک بسته راه‌حل معمولی SharePoint می‌باشد. این آرشیو شامل:

- Aspose.Slides.SharePoint.License.wsp – فایل بسته راه‌حل SharePoint. لایسنس به‌عنوان یک راه‌حل SharePoint بسته‌بندی شده است تا استقرار و بازپس‌گیری آن در سراسر یک فارم سرور به راحتی انجام شود.
- readme.txt – دستورالعمل‌های نصب لایسنس.

{{% /alert %}}

## **استقرار لایسنس**

نصب لایسنس از طریق کنسول سرور با استفاده از **stsadm.exe** انجام می‌شود.

{{% alert color="info" title="Note" %}}

مسیرها برای وضوح در بخش زیر حذف شده‌اند.

{{% /alert %}}

مراحل زیر را برای استقرار لایسنس Aspose.Slides برای SharePoint انجام دهید:

1. اجرای stsadm برای افزودن راه‌حل به فروشگاه راه‌حل‌های SharePoint:

   ```bat
   Stsadm.exe -o addsolution -filename Aspose.Slides.SharePoint.License.wsp
   ```

2. استقرار راه‌حل بر روی تمام سرورها در فارم:

   ```bat
   Stsadm.exe -o deploysolution -name Aspose.Slides.SharePoint.License.wsp -immediate -force
   ```

3. اجرای کارهای زمان‌دار اداری برای تکمیل فوری استقرار:

   ```bat
   Stsadm.exe -o execadmsvcjobs
   ```

عملیات `addsolution` مسیر فایل راه‌حل را در پارامتر `-filename` می‌گیرد؛ عملیات `deploysolution` نام راه‌حلی که قبلاً در فروشگاه راه‌حل موجود است را در پارامتر `-name` می‌گیرد.

{{% alert color="info" title="Note" %}}

اگر سرویس مدیریت SharePoint در حال اجرا نباشد، هنگام اجرای مرحله استقرار یک هشدار دریافت می‌کنید. **stsadm.exe** به این سرویس و سرویس تایمر SharePoint برای تکثیر داده‌های راه‌حل در سراسر فارم وابسته است. اگر این سرویس‌ها در فارم سرور شما فعال نباشند، ممکن است نیاز باشد لایسنس را بر روی هر سرور مستقر کنید.

{{% /alert %}}

{{% alert color="info" title="Note" %}}

در SharePoint 2010 و نسخه‌های بعدی، cmdletهای SharePoint Management Shell `Add-SPSolution`، `Install-SPSolution` و `Start-SPAdminJob` به عملیات‌های `addsolution`، `deploysolution` و `execadmsvcjobs` متناظر هستند. ببینید [Stsadm to Microsoft PowerShell mapping in SharePoint Server](https://learn.microsoft.com/en-us/sharepoint/technical-reference/stsadm-to-microsoft-powershell-mapping).

{{% /alert %}}

## **آزمون لایسنس**

برای آزمون اینکه لایسنس به‌درستی نصب شده است، هر ارائه‌ای را به قالب جدیدی تبدیل کنید. اگر در فایل تبدیل‌شده واترمارک ارزیابی وجود نداشته باشد، لایسنس فعال است.