---
title: "نصب به صورت دستی"
type: docs
weight: 30
url: /fa/reportingservices/install-manually/
keywords:
- "نصب دستی"
- rsreportserver.config
- rssrvpolicy.config
- SQL Server Reporting Services
- Power BI Report Server
- Aspose.Slides for Reporting Services
description: "Aspose.Slides برای Reporting Services را به صورت دستی از بسته ZIP شامل فقط DLLها نصب کنید: تعیین کنید کدام اسمبلی را کپی کنید و چه مواردی را به فایل‌های rsreportserver.config و rssrvpolicy.config اضافه کنید."
---
## **نمای کلی**

برای نصب Aspose.Slides برای Reporting Services بدون استفاده از MSI installer، از بسته ZIP *Aspose.Slides for Reporting Services XX.XX (DLLs Only)* موجود در [صفحه دانلود](https://releases.aspose.com/slides/reportingservices/) پیروی کنید. این‌ها همان افزونه‌ها را همانند [MSI installer](/slides/fa/reportingservices/install-with-msi-installer/) ثبت می‌کنند. این مراحل را برای هر نمونه سرور گزارش تکرار کنید.

قبل از شروع، [نیازهای سیستم](/slides/fa/reportingservices/system-requirements/) را بررسی کنید. برای سرور گزارش نیاز به حقوق مدیر محلی دارید.

## **انتخاب اسمبلی**

بسته ZIP شامل چندین بیلد است. دقیقاً یک فایل *Aspose.Slides.ReportingServices.dll* را به سرور گزارش کپی کنید:

| فایل در بسته ZIP | موارد استفاده |
| :- | :- |
| *Bin\Universal\Aspose.Slides.ReportingServices.dll* | SQL Server 2008 و نسخه‌های بعدی Reporting Services، و Power BI Report Server |
| *Bin\SSRS2005\Aspose.Slides.ReportingServices.dll* | SQL Server 2005 Reporting Services |
| *Bin\ReportViewer2010\Aspose.Slides.ReportingServices.dll* | برای سرور گزارش نیست: برنامه‌هایی که از کنترل ReportViewer 2010 یا 2012 خروجی می‌گیرند، به [استفاده از Aspose.Slides با ReportViewer 2010 و 2012](/slides/fa/reportingservices/using-aspose-slides-with-reportviewer-2010-and-2012/) مراجعه کنید. |
| *Bin\RplExport\Aspose.ReportingServices.Debug.Rpl.dll* | اختیاری: گزارش‌ها را در قالب RPL برای گزارش‌های مشکل ذخیره می‌کند، به [صادرات گزارش‌ها به قالب RPL](/slides/fa/reportingservices/exporting-reports-to-rpl-format/) مراجعه کنید. |

## **یافتن پوشه سرور گزارش**

مراحل زیر به پوشه *ReportServer* سرور گزارش اشاره دارد که شامل *rsreportserver.config* و *rssrvpolicy.config* است. در یک نصب پیش‌فرض، این مسیر است:

| سرور گزارش | پوشه پیش‌فرض *ReportServer* |
| :- | :- |
| SQL Server 2017 و نسخه‌های بعدی Reporting Services | `C:\Program Files\Microsoft SQL Server Reporting Services\SSRS\ReportServer` |
| Power BI Report Server | `C:\Program Files\Microsoft Power BI Report Server\PBIRS\ReportServer` |
| SQL Server 2016 و نسخه‌های قبلی Reporting Services | `C:\Program Files\Microsoft SQL Server\<instance folder>\Reporting Services\ReportServer`، که پوشهٔ نمونه، برای مثال `MSRS13.MSSQLSERVER` برای SQL Server 2016 یا `MSSQL.x` برای SQL Server 2005 است. |

برای مکان‌های بیشتر، مقاله‌ی [فایل پیکربندی RsReportServer.config](https://learn.microsoft.com/en-us/sql/reporting-services/report-server/rsreportserver-config-configuration-file) مایکروسافت را مشاهده کنید.

## **نصب افزونه**

1. اسمبلی انتخابی خود را به زیرپوشه *bin* پوشه *ReportServer* کپی کنید.

   فایل کپی‌شده نباید دارای سطوح دسترسی NTFS به‌صورت صریح باشد، زیرا در این صورت سرور گزارش هنگام بارگذاری اسمبلی دسترسی دریافت نمی‌کند و فرمت‌های صادراتی جدید ظاهر نمی‌شوند. روی فایل کلیک راست کنید، **Properties** را انتخاب کنید و در برگه **Security** هر دسترسی صریحی را حذف کنید و فقط دسترسی‌های وراثت‌شده را بگذارید. اگر برگه **General** گزینه **Unblock** را نشان داد، آن را انتخاب کنید.

1. یک نسخه از *rsreportserver.config* ذخیره کنید، سپس فایل را در یک ویرایشگر متن باز کنید. این ورودی‌ها را داخل عنصر `<Render>` اضافه کنید:

   ```xml
   <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASXPSS" Type="Aspose.Slides.ReportingServices.XpsRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASODP" Type="Aspose.Slides.ReportingServices.OdpRenderer,Aspose.Slides.ReportingServices"/>
   ```

   هر ورودی یک فرمت خروجی را ثبت می‌کند؛ `Name` باید بین افزونه‌های رندرینگ یکتا باشد. MSI installer همان شش نام و نوع را ثبت می‌کند. اگر نمی‌خواهید آن فرمت در فهرست خروجی باشد، ورودی مربوطه را حذف کنید.

1. یک نسخه از *rssrvpolicy.config* ذخیره کنید، سپس فایل را در یک ویرایشگر متن باز کنید. گروه کدی که `Description` آن برابر با «This code group grants MyComputer code Execution permission.» است را پیدا کنید و این گروه کد را به عنوان آخرین فرزند آن اضافه کنید:

   ```xml
   <CodeGroup class="UnionCodeGroup" version="1" PermissionSetName="FullTrust" Name="Aspose.Slides_for_Reporting_Services" Description="This code group grants full trust to the Aspose.Slides.ReportingServices.dll assembly.">
       <IMembershipCondition class="StrongNameMembershipCondition" version="1" PublicKeyBlob="00240000048000009400000006020000002400005253413100040000010001005542e99cecd28842dad186257b2c7b6ae9b5947e51e0b17b4ac6d8cecd3e01c4d20658c5e4ea1b9a6c8f854b2d796c4fde740dac65e834167758cff283eed1be5c9a812022b015a902e0b97d4e95569eb8c0971834744e633d9cb4c4a6d8eda03c12f486e13a1a0cb1aa101ad94943236384cbbf5c679944b994de9546e493bf"/>
   </CodeGroup>
   ```

   `PublicKeyBlob` کلید عمومی اسمبلی Aspose.Slides.ReportingServices است. آن را در یک خط نگه دارید.

1. هر دو فایل را ذخیره کنید. سرور گزارش فایل‌های پیکربندی خود را هر بار که ذخیره می‌شوند دوباره می‌خواند. اگر فایلی شامل XML نامعتبر باشد، سرور گزارش آن را نادیده می‌گیرد یا راه‌اندازی نمی‌شود، بنابراین اگر مشکلی پیش آمد نسخهٔ خود را بازگردانید.

## **بررسی نصب**

یک گزارش صفحه‌بندی‌شده را در پورتال وب (Report Manager در SQL Server 2014 و قبل) باز کنید و فهرست **Export** را باز کنید. اکنون شامل این فرمت‌ها است:

- PPT - ارائه PowerPoint از طریق Aspose.Slides
- PPS - نمایش اسلاید PowerPoint از طریق Aspose.Slides
- PPTX - ارائه PowerPoint 2007 از طریق Aspose.Slides
- PPSX - نمایش اسلاید PowerPoint 2007 از طریق Aspose.Slides
- ODP - ارائه OpenDocument از طریق Aspose.Slides
- XPS - از طریق Aspose.Slides

یکی از آن‌ها را برای صادرات گزارش انتخاب کنید. فایل در برنامه مرتبط با فرمت آن باز می‌شود.

![گزارشی که توسط Aspose.Slides for Reporting Services به PowerPoint صادر شد](install-manually_2.png)

اگر فرمت‌ها ظاهر نشدند، سطوح دسترسی NTFS اسمبلی کپی‌شده را بررسی کنید. بدون لایسنس، فایل‌های صادرشده دارای واترمارک ارزیابی هستند؛ به [مجوزدهی](/slides/fa/reportingservices/license-aspose-slides-for-reporting-services/) مراجعه کنید.