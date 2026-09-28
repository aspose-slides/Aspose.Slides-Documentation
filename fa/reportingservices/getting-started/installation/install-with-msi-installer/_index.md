---
title: نصب با MSI Installer
type: docs
weight: 20
url: /fa/reportingservices/install-with-msi-installer/
keywords:
- نصب‌کننده MSI
- نصب
- خدمات گزارش‌دهی سرور SQL
- سرور گزارش Power BI
- Aspose.Slides برای خدمات گزارش‌دهی
description: "Aspose.Slides برای خدمات گزارش‌دهی را با نصب‌کننده MSI آن نصب کنید: نیازهای نصب‌کننده، تغییراتی که در هر نمونه سرور گزارش اعمال می‌شود و روش بررسی نتایج."
---
## **نصب**

نصب‌کننده MSI ساده‌ترین راه برای نصب Aspose.Slides for Reporting Services است. این برنامه به .NET Framework 3.5 و حقوق مدیر بر روی سرور گزارش نیاز دارد؛ مراجعه کنید به [نیازمندی‌های سیستم](/slides/fa/reportingservices/system-requirements/).

1. نرم‌افزار نصب MSI، *Aspose.Slides for Reporting Services XX.XX* را از [صفحه دانلود](https://releases.aspose.com/slides/reportingservices/) دانلود کنید و آن را به سرور گزارش کپی کنید.
2. به عنوان کاربر مدیر اجرا کنید. اگر .NET Framework 3.5 موجود نباشد، نصب‌کننده با پیامی متوقف می‌شود؛ ویژگی‌های .NET Framework 3.5 را نصب کنید و دوباره اجرا کنید.
3. توافق‌نامهٔ مجوز را بپذیرید.
4. در صفحه **Custom Setup**، درخت ویژگی‌ها هر نمونهٔ SQL Server Reporting Services و Power BI Report Server را که نصب‌کننده روی ماشین شناسایی می‌کند لیست می‌کند. برای اینکه یک نمونه بدون تغییر بماند، روی آیکون آن کلیک کنید و **Entire feature will be unavailable** را انتخاب کنید. نسخه‌های Express از افزونه‌های رندرینگ پشتیبانی نمی‌کنند، بنابراین نمونهٔ Express را انتخاب نکنید. نصب‌کننده نمونه‌های Express سرور SQL Server 2016 و قبلی را مخفی می‌کند.
5. گزینه **Next** را انتخاب کنید، سپس **Install**.
6. ویژگی اختیاری **Rpl Export** به طور پیش‌فرض انتخاب نشده است. این ویژگی یک افزونهٔ مخفی اضافه می‌کند که گزارش‌ها را در قالب RPL ذخیره می‌کند؛ این برای ارسال گزارش مشکل به Aspose مفید است؛ مراجعه کنید به [صدور گزارش‌ها به قالب RPL](/slides/fa/reportingservices/exporting-reports-to-rpl-format/).

## **آنچه نصب‌کننده تغییر می‌دهد**

نصب‌کننده فایل‌های خود را در *Aspose\Aspose.Slides for Reporting Services* زیر پوشه Program Files — *Program Files (x86)* در ویندوز 64 بیتی — نگهداری می‌کند، زیرا این نصب‌کننده یک بسته 32 بیتی است. سپس برای هر نمونهٔ انتخاب‌شده، این کارها را انجام می‌دهد:

- فایل *Aspose.Slides.ReportingServices.dll* را به پوشه *ReportServer\bin* نمونه کپی می‌کند — نسخه برای SQL Server 2005، یا نسخه برای SQL Server 2008 به بعد و Power BI Report Server؛
- شش افزونهٔ رندرینگ — ASPPT, ASPPS, ASPPTX, ASPPSX, ASXPSS و ASODP — را به عنصر `<Render>` در فایل *rsreportserver.config* اضافه می‌کند؛
- یک گروه کد که به اسمبلی اعتماد کامل می‌دهد را به *rssrvpolicy.config* اضافه می‌کند؛
- یک نسخهٔ پشتیبان از هر فایل پیکربندی که تغییر می‌دهد ذخیره می‌کند که پسوند *.bak* به نام فایل اضافه می‌شود.

[نصب دستی](/slides/fa/reportingservices/install-manually/) این تغییرات را گام به گام نشان می‌دهد.

اگر یک نمونه قابل پیکربندی نباشد، نصب‌کننده نام آن را در پیامی نشان می‌دهد و جزئیات را در فایل *rserrors<date>.log* در پوشه نصب می‌نویسد. افزونه را بر روی آن نمونه به صورت دستی نصب کنید.

## **بررسی نصب**

یک گزارش صفحه‌بندی‌شده را در پورتال وب (Report Manager در SQL Server 2014 و نسخه‌های قبلی) باز کنید و لیست **Export** را باز کنید. اکنون این فرمت‌ها شامل می‌شود:

- PPT - ارائه PowerPoint از طریق Aspose.Slides
- PPS - اسلایدشو PowerPoint از طریق Aspose.Slides
- PPTX - ارائه PowerPoint 2007 از طریق Aspose.Slides
- PPSX - اسلایدشو PowerPoint 2007 از طریق Aspose.Slides
- ODP - ارائه OpenDocument از طریق Aspose.Slides
- XPS - از طریق Aspose.Slides

بدون داشتن لایسنس، فایل‌های صادرشده دارای نشان‌دار ارزیابی هستند؛ مراجعه کنید به [مجوزدهی](/slides/fa/reportingservices/license-aspose-slides-for-reporting-services/).

## **زمان نصب دستی**

به جای آن افزونه را [به صورت دستی](/slides/fa/reportingservices/install-manually/) نصب کنید زمانی که:

- نصب‌کننده نتواند یک نمونه را پیکربندی کند، برای مثال به دلیل تنظیمات امنیتی سرور؛
- پس از ارتقا، بخواهید فقط اسمبلی را جایگزین کنید به جای حذف نسخهٔ قدیمی و اجرای نصب‌کننده جدید.

حذف نصب محصول اسمبلی و ورودی‌های پیکربندی را از هر نمونه حذف می‌کند.