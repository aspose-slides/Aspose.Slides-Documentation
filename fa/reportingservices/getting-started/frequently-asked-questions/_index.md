---
title: سوالات متداول
type: docs
weight: 110
url: /fa/reportingservices/frequently-asked-questions/
---
{{% alert color="primary" %}} 

این صفحه مجموعه‌ای از سؤالات متداول دربارهٔ موارد زیر را جمع‌آوری می‌کند:

- [فرمت‌های پشتیبانی‌شده](#Supported-File-Formats).
- [پشتیبانی از سرویس‌های گزارش‌گیری Power BI](#Support-for-Power-BI-Reporting-services).
- [نصب](#Installation).
- [پیکربندی خروجی](#Export-Configuration).

{{% /alert %}} 
### **فرمت‌های پشتیبانی‌شده**
#### **س: چه فرمت‌هایی می‌توانید با استفاده از Aspose.Slides for Reporting Services گزارش‌ها را صادر کنید؟**
**پ**: Aspose.Slides for Reporting Services امکان صدور هر گزارشی را در قالب PPT، PPS، PPTX، PPSX، XPS یا RPL فراهم می‌کند.
### **پشتیبانی از سرویس‌های گزارش‌گیری Power BI**
#### **س: آیا Aspose.Slides for Reporting Services از Power BI پشتیبانی می‌کند؟**
**پ**: بله. Aspose.Slides for Reporting Services از صدور گزارش‌های صفحه‌بندی‌شده (RDL) در Power BI پشتیبانی می‌کند.
### **نصب**
#### **س: برنامه نصب آغاز نمی‌شود. نصب دستی به نتیجهٔ دلخواه نمی‌رسد.**
**پ** : مطمئن شوید که .NET Framework 3.5 بر روی سیستم شما نصب شده است.
#### **س: پس از نصب Aspose.Slides for Reporting Services گزینه‌های خروجی گم شده‌اند.**
**پ**: اگر هر CodeGroupی در rssrvpolicy.config به‌درستی کار نکند، تجزیه‌کنندهٔ فایل پیکربندی ممکن است بخش‌های آخر گروه را نادیده بگیرد. بنابراین تمام CodeGroupهای مرتبط با Aspose.Slides for Reporting Services را به بالای بلوکی که شامل CodeGroupهای Aspose.Slides for Reporting Services است منتقل کنید.
#### **س: نمی‌توان فایل یا اسمبلی Aspose.Slides.ReportingServices را بارگیری کرد (دسترسی اجرا نمی‌تواند به‌دست آید \ استثنا از HRESULT: 0x80131418).**
**پ**: کد خطا (0x80131418) نشان می‌دهد که ماژول dll دارای حقوق کافی نیست. این ممکن است به دلیل ویژگی امنیتی باشد که دسترسی کامل به فایل .dll را مسدود کرده است اگر از کامپیوتر دیگری دریافت شده باشد. می‌توانید با باز کردن پنجرهٔ ویژگی‌های فایل dll و کلیک بر دکمهٔ "Unblock" در پنل "Security" این مشکل را برطرف کنید.
#### **س: نمی‌توان فایل license 'Aspose.Slides.Reporting.Services.lic' را یافت.**
**پ**: فایل لایسنس باید در کنار فایل dll یا در مسیر Program Files(x86)\Aspose\Slides\ قرار گیرد.
### **پیکربندی خروجی**
#### **س: چگونه می‌توان رنگ هایپرلینک‌ها را در گزارشی که صادر شده، تغییر داد؟**
**پ**: هر افزونهٔ رندر Aspose.Slides for Reporting Services در rsreportserver.config پیکربندی خاص خود را دارد. برای تغییر رنگ هایپرلینک، مقدار مورد نیاز را در بخش <HyperlinkColor> تنظیم کنید.
#### **س: در ارائه‌های صادر شده، متن در جدول‌ها به صورت عمودی کشیده می‌شود.**
**پ**: این کار برای راحتی خواندن سند انجام می‌شود. برای نمایش متن جدول همان‌گونه که در گزارش ظاهر می‌شود، افزونهٔ Aspose.Slides for Reporting Services را در فایل پیکربندی rsreportserver.config به "Normal" تنظیم کنید.