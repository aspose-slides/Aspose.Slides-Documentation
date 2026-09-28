---
title: نیازهای سطح اعتماد
type: docs
weight: 190
url: /fa/net/declaration/
keywords:
- سطح اعتماد
- مجوز اعتماد کامل
- اعتماد جزئی
- اعتماد متوسط
- امنیت دسترسی به کد
- ASP.NET
- .NET Framework
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "سطح اعتماد امنیت دسترسی به کد که Aspose.Slides برای .NET نیاز دارد: اعتماد کامل بر روی .NET Framework و عدم وجود تنظیم سطح اعتماد در .NET 6 و نسخه‌های بعدی."
---
## **Overview**

سطوح اعتماد امنیت دسترسی به کد (CAS) فقط در .NET Framework وجود دارند. این مقاله توضیح می‌دهد که این سطوح برای Aspose.Slides for .NET چه معنایی دارند: کتابخانه به اعتماد کامل بر روی .NET Framework نیاز دارد، و در .NET 6 و نسخه‌های بعدی سطح اعتمادی برای پیکربندی وجود ندارد.

## **.NET Framework**

Aspose.Slides برای .NET Framework به اعتماد کامل نیاز دارد. این کتابخانه تحت اعتماد جزئی، مانند برنامه ASP.NET که برای Medium Trust (`<trust level="Medium" />`) پیکربندی شده است، اجرا نمی‌شود: ایجاد یک شیء [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) با خطای `SecurityException` مواجه می‌شود.

Microsoft دیگر اعتماد جزئی ASP.NET را به عنوان روشی برای جداسازی برنامه‌ها از یکدیگر در نظر نمی‌گیرد و به‌جای آن پیشنهاد می‌کند برنامه‌ها در استخرهای جداگانه اجرا شوند. ببینید [اعتماد جزئی ASP.NET تضمین‌کننده جداسازی برنامه‌ها نیست](https://support.microsoft.com/en-us/servicing/dotnetframework/troubleshooting/asp-net-partial-trust-does-not-guarantee-application-isolation).

## **.NET 6 and Later**

دسترسی کد امنیتی (CAS) در .NET 6 و نسخه‌های بعدی موجود نیست، بنابراین سطح اعتمادی برای اعطای آن وجود ندارد. Aspose.Slides با مجوزهای حسابی که برنامه شما را اجرا می‌کند، اجرا می‌شود. برای محدود کردن دسترسی برنامه، Microsoft مرزهای سیستم‌عامل مانند حساب‌های کاربری، کانتینرها یا ماشین‌های مجازی را توصیه می‌کند. ببینید [دسترسی کد امنیتی (CAS)](https://learn.microsoft.com/en-us/dotnet/core/porting/net-framework-tech-unavailable#code-access-security-cas).

## **FAQ**

**آیا می‌توانم از Aspose.Slides با ارائه‌دهنده میزبانی که برنامه‌های ASP.NET را در Medium Trust اجرا می‌کند، استفاده کنم؟**

در Medium Trust امکان‌پذیر نیست. در .NET Framework، برنامه‌ای که از Aspose.Slides استفاده می‌کند باید با اعتماد کامل اجرا شود.