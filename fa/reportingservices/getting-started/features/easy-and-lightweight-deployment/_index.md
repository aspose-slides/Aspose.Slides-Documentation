---
title: استقرار آسان و سبک
type: docs
weight: 50
url: /fa/reportingservices/easy-and-lightweight-deployment/
---
{{% alert color="primary" %}} 

Aspose.Slides for Reporting Services یک افزونه رندرینگ برای Microsoft SQL Server Reporting Services است.  
Aspose.Slides for Reporting Services به صورت یک نصب‌کننده MSI تک ارائه می‌شود که می‌تواند روی کامپیوترهایی که یکی از موارد زیر را اجرا می‌کنند نصب شود: 

- Microsoft SQL Server 2005 Reporting Services (32-bit and 64-bit)  
- Microsoft SQL Server 2008 Reporting Services (32-bit and 64-bit)

همچنین استقرار و مدیریت Aspose.Slides for Reporting Services به صورت دستی آسان است، زیرا این محصول فقط از یک اسمبلی .NET به نام *Aspose.Slides* *.ReportingServices.dll* تشکیل شده است که کاملاً به زبان C# نوشته شده، با استاندارد CLS سازگار است و فقط شامل کد مدیریت‌شده ایمن می‌باشد.  

{{% /alert %}} 

نصب‌کننده MSI و دانلود ZIP شامل Aspose.Slides for ReportingServices هستند: 

- Bin\SSRS2005\Aspose.Slides.ReportingServices.dll – ساخته شده برای Microsoft SQL Server 2005 و .NET Framework 2.0 (برای x86 و x64 استفاده شود)  
- Bin\SSRS2008\Aspose.Slides.ReportingServices.dll – ساخته شده برای Microsoft SQL Server 2008 و .NET Framework 2.0 (برای x86 و x64 استفاده شود)

در هنگام نصب، Aspose.Slides.ReportingServices.dll به پوشه ReportServer\bin کپی می‌شود و فایل پیکربندی به‌روزرسانی می‌شود تا Reporting Services از افزونه رندرینگ جدید آگاه شود. این مراحل توسط نصب‌کننده Aspose.Slides for Reporting Services انجام می‌شود، اما می‌توانید آنها را به‌صورت دستی همان‌طور که در ادامه این مستندات توضیح داده شده است، انجام دهید.  

![todo:image_alt_text](easy-and-lightweight-deployment_1.png)

**Figure**: فایل Aspose.Slides.ReportingServices.dll به پوشه **ReportServer\bin** کپی می‌شود.