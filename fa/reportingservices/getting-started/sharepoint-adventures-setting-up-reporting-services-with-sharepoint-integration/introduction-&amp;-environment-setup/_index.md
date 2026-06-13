---
title: معرفی و تنظیم محیط
type: docs
weight: 10
url: /fa/reportingservices/introduction-&amp;-environment-setup/
---
{{% alert color="primary" %}} 

در گذشته پرسش‌هایی در مورد Aspose.Slides برای ادغام Reporting Services با SharePoint وجود داشته است. در این مقاله، بر روی SharePoint 2010 تمرکز خواهیم کرد. فرض می‌شود که شما قبلاً محیط SharePoint Farm را راه‌اندازی کرده‌اید. مثال‌هایی که در این مقاله دنبال می‌کنیم یک SharePoint Cloud کامل خواهد بود، اما مراحل برای سرور SharePoint Foundation نیز مشابه هستند. پیش از ادامه، اجازه دهید با برخی مستندات کلیدی که می‌توانید برای مرجع استفاده کنید، شروع کنیم: 

- [نمای کلی سرویس‌های گزارش‌گیری و ادغام فناوری SharePoint](https://docs.microsoft.com/en-us/previous-versions/sql/sql-server-2008-r2/bb326358(v=sql.105))
- [پیکربندی سرویس‌های گزارش‌گیری برای ادغام SharePoint 2010](https://docs.microsoft.com/en-us/previous-versions/sql/)

{{% /alert %}} 
#### **راه‌اندازی محیط**
پیکربندی که خواهیم داشت شامل **۴ سرور** است. این شامل یک **Domain Controller**، یک **SQL Server**، یک **SharePoint Server** و یک سرور برای **Reporting Services** می‌شود. می‌توانید انتخاب کنید که SharePoint و Reporting Services را بر روی همان دستگاه قرار دهید.