---
title: نیازهای سیستم
type: docs
weight: 15
url: /fa/reportingservices/system-requirements/
keywords:
- نیازهای سیستم
- SQL Server Reporting Services
- SSRS
- Power BI Report Server
- .NET Framework 3.5
- Aspose.Slides for Reporting Services
description: "قبل از نصب، بررسی کنید که Aspose.Slides for Reporting Services به چه سرورهای گزارش، نسخه‌ها و نسخهٔ .NET Framework نیاز دارد."
---
## **بررسی کلی**

Aspose.Slides for Reporting Services به‌عنوان یک افزونه رندرینگ در سرور گزارش اجرا می‌شود. این صفحه مواردی که ماشین سرور گزارش قبل از [نصب](/slides/fa/reportingservices/installing-aspose-slides-for-reporting-services/) نیاز دارد را فهرست می‌کند. Microsoft PowerPoint و Microsoft Office لازم نیستند.

## **سرورهای گزارش پشتیبانی‌شده**

- Microsoft SQL Server 2005 Reporting Services
- Microsoft SQL Server 2008 و 2008 R2 Reporting Services
- Microsoft SQL Server 2012 Reporting Services
- Microsoft SQL Server 2014 Reporting Services
- Microsoft SQL Server 2016 Reporting Services
- Microsoft SQL Server 2017 Reporting Services
- Microsoft SQL Server 2019 Reporting Services
- Power BI Report Server، برای گزارش‌های صفحه‌بندی‌شده (RDL)

هر دو سرور گزارش ۳۲‑بیتی و ۶۴‑بیتی پشتیبانی می‌شوند. SQL Server 2005 نسخهٔ اختصاصی خود را دارد؛ تمام نسخه‌های بعدی و Power BI Report Server از همان نسخه استفاده می‌کنند. [نصب به‌صورت دستی](/slides/fa/reportingservices/install-manually/) نشان می‌دهد چه فایلی را باید کپی کنید.

اگر نسخهٔ سرور گزارش شما در این فهرست نیست، پیش از استقرار در [انجمن پشتیبانی رایگان](https://forum.aspose.com/c/slides/11) بپرسید.

## **نسخه‌های سرور گزارش**

برای SQL Server 2016 Reporting Services و نسخه‌های بعدی و برای Power BI Report Server، مایکروسافت افزونه‌های رندرینگ را در نسخه‌های Enterprise, Standard, Developer و Evaluation پشتیبانی می‌کند؛ نسخه‌های Web و Express از آن‌ها پشتیبانی نمی‌کنند. به [قابلیت‌های Reporting Services بر حسب نسخه‌ها](https://learn.microsoft.com/en-us/sql/reporting-services/reporting-services-features-supported-by-the-editions-of-sql-server) مراجعه کنید. نصب‌کننده MSI نمونه‌های Express نسخه‌های SQL Server 2016 و پیشین را نادیده می‌گیرد.

## **.NET Framework**

.NET Framework 3.5 باید بر روی ماشین سرور گزارش نصب باشد. اسمبلی‌های افزونه برای زمان اجرای .NET Framework 2.0 ساخته شده‌اند و نصب‌کننده MSI در صورت عدم وجود .NET Framework 3.5 با پیامی متوقف می‌شود. در Windows Server، **.NET Framework 3.5 Features** را در ویزارد Add Roles and Features اضافه کنید؛ به [نصب .NET Framework 3.5 بر روی Windows](https://learn.microsoft.com/en-us/dotnet/framework/install/dotnet-35-windows) نگاه کنید.

## **مجوزها**

نصب افزونه فایل‌های پوشهٔ سرور گزارش را تغییر می‌دهد، بنابراین هر دو مسیر نصب به حقوق مدیر محلی نیاز دارند. اگر MSI را بدون این حقوق اجرا کنید، به شما امکان بازگرداندن به حالت مدیر را می‌دهد.

## **سؤالات متداول**

**آیا برای سرور گزارش به Microsoft PowerPoint نیاز دارم؟**

نه. افزونه خود مستندات را ایجاد می‌کند؛ نیازی به نصب PowerPoint یا Microsoft Office نیست.

**آیا می‌توانم افزونه را در نسخهٔ Express نصب کنم؟**

نه. نسخه‌های Express از افزونه‌های رندرینگ پشتیبانی نمی‌کنند. نصب‌کننده MSI نمونه‌های Express SQL Server 2016 و پیشین را مخفی می‌کند؛ در نسخه‌های بعدی، از انتخاب نمونهٔ Express خودداری کنید.

**کدام فرمت‌ها توسط افزونه به فهرست صادرات اضافه می‌شوند؟**

PPT، PPS، PPTX، PPSX، ODP و XPS. به [فرمت‌های فایل پشتیبانی‌شده](/slides/fa/reportingservices/supported-file-formats/) مراجعه کنید.