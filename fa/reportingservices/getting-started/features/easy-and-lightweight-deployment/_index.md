---
title: استقرار آسان و سبک
type: docs
weight: 50
url: /fa/reportingservices/easy-and-lightweight-deployment/
description: "یاد بگیرید چگونه Aspose.Slides for Reporting Services مستقر می‌شود: یک اسمبلی در پوشه bin سرور گزارش، در پیکربندی سرور گزارش ثبت می‌شود."
---
{{% alert color="info" title="Note" %}}

Aspose.Slides for Reporting Services یک افزونه رندرینگ برای Microsoft SQL Server Reporting Services و Power BI Report Server است.
Aspose.Slides for Reporting Services به‌صورت یک نصب‌کننده MSI تک‌منظوره ارائه می‌شود که می‌تواند بر روی رایانه‌هایی که سرور گزارش پشتیبانی‌شده‌ای (32 بیتی یا 64 بیتی) اجرا می‌کنند نصب شود؛ برای اطلاعات بیشتر به [System Requirements](/slides/fa/reportingservices/system-requirements/) مراجعه کنید.

هم‌چنین استقرار و مدیریت Aspose.Slides for Reporting Services به‌صورت دستی آسان است، زیرا این محصول تنها از یک اسمبلی .NET به نام *Aspose.Slides* *.ReportingServices.dll* تشکیل شده است، که کاملاً به زبان C# نوشته شده، با CLS سازگاری دارد و فقط شامل کد مدیریت‌شده‌ای امن می‌باشد.

{{% /alert %}}

فایل ZIP شامل دو بیلد از Aspose.Slides.ReportingServices.dll برای سرورهای گزارش است:

- Bin\SSRS2005\Aspose.Slides.ReportingServices.dll – ساخته‌شده برای Microsoft SQL Server 2005 و .NET Framework 2.0 (قابل استفاده برای x86 و x64)
- Bin\Universal\Aspose.Slides.ReportingServices.dll – ساخته‌شده برای Microsoft SQL Server 2008 و نسخه‌های بعدی، Power BI Report Server و .NET Framework 2.0 (قابل استفاده برای x86 و x64)

نصب‌کننده MSI همان دو بیلد را نصب می‌کند و برای هر نمونه سرور گزارش، نسخه مناسب را انتخاب می‌نماید. [Install Manually](/slides/fa/reportingservices/install-manually/) تمام فایل‌های موجود در دانلود ZIP را فهرست می‌کند.

در هنگام نصب، Aspose.Slides.ReportingServices.dll به پوشه ReportServer\bin کپی می‌شود و فایل پیکربندی به‌روزرسانی می‌گردد تا Reporting Services از افزونه رندرینگ جدید آگاه شود. این مراحل توسط نصب‌کننده Aspose.Slides for Reporting Services انجام می‌شود، اما می‌توانید همان‌طور که در ادامه این مستندات توضیح داده شده، به‌صورت دستی آن‌ها را اجرا کنید.

![todo:image_alt_text](easy-and-lightweight-deployment_1.png)

**شکل**: Aspose.Slides.ReportingServices.dll به پوشه **ReportServer\bin** کپی می‌شود.