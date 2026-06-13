---
title: تبدیل OpenDocument Presentations در .NET
linktitle: تبدیل OpenDocument
type: docs
weight: 10
url: /fa/net/convert-openoffice-odp/
keywords:
- تبدیل ODP
- ODP به تصویر
- ODP به GIF
- ODP به HTML
- ODP به JPG
- ODP به MD
- ODP به PDF
- ODP به PNG
- ODP به PPT
- ODP به PPTX
- ODP به TIFF
- ODP به ویدئو
- ODP به Word
- ODP به XPS
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET به شما امکان تبدیل ODP به PDF، HTML و فرمت‌های تصویر را به آسانی می‌دهد. برنامه‌های .NET خود را با تبدیل سریع و دقیق ارائه‌ها ارتقا دهید."
---
## **مقدمه**

[**Aspose.Slides API**](https://products.aspose.com/slides/fa/net/) به شما امکان تبدیل ارائه‌های OpenDocument (ODP) به بسیاری از فرمت‌ها (HTML، PDF، TIFF، SWF، XPS و غیره) را می‌دهد. API مورد استفاده برای تبدیل فایل‌های ODP به سایر فرمت‌های سند همانند API مورد استفاده برای عملیات تبدیل PowerPoint (PPT و PPTX) است.

به عنوان مثال، اگر نیاز به تبدیل یک ارائه ODP به PDF داشته باشید، می‌توانید به شکل زیر عمل کنید:

```cs
using (Presentation presentation = new Presentation("presentation.odp"))
{
    presentation.Save("presentation.pdf", SaveFormat.Pdf);
}
```

## **ارائه OpenDocument در برنامه‌های مختلف**

وقتی یک فایل ارائه OpenDocument (ODP) در PowerPoint باز می‌شود، ممکن است قالب‌بندی اصلی که در برنامه‌ای که در آن ایجاد شده بود حفظ نشود. این به این دلیل است که برنامه ارائه OpenDocument و برنامه PowerPoint ویژگی‌ها و رفتارهای رندرینگ متفاوتی دارند.

در ادامه برخی از تفاوت‌ها آمده است:

- در PowerPoint، جداول معمولاً در انتها رندر می‌شوند و ممکن است سایر اشکال را پوشش دهند، صرف‌نظر از ترتیب آن‌ها در اسلاید ODP.
- پر کردن با تصویر برای جداول ODP در PowerPoint پشتیبانی نمی‌شود.
- چرخش عمودی متن (270°، چیده شده) و تراز توزیع‌شده در LibreOffice/OpenOffice Impress پشتیبانی نمی‌شود.
- پر کردن با تصویر، پر کردن براشواری و پر کردن الگو برای متن در LibreOffice/OpenOffice Impress پشتیبانی نمی‌شود.

PowerPoint مایکروسافت و LibreOffice/OpenOffice Impress همچنین لیست‌ها را به‌شکل متفاوتی مدیریت می‌کنند. فایلی ODP که در PowerPoint ایجاد شده است ممکن است به‌درستی در LibreOffice/OpenOffice Impress نمایش داده نشود و بالعکس.

تصویر زیر نشان می‌دهد که یک لیست چگونه هنگام ایجاد در LibreOffice Impress ظاهر می‌شود:

![مثال لیست ODP](odp-list-example.png)

Aspose.Slides لیست‌های ODP را به‌طوری ذخیره می‌کند که در LibreOffice/OpenOffice Impress به‌درستی نمایش داده شوند.

[اطلاع بیشتر درباره فرمت OpenDocument و PowerPoint](https://support.microsoft.com/en-us/office/use-powerpoint-to-save-or-open-a-presentation-in-the-opendocument-presentation-odp-format-94805e84-1b09-4c98-a8b5-0da2a52242a0).

## **پرسش‌های متداول**

**اگر قالب‌بندی فایل ODP من پس از تبدیل تغییر کند چه می‌شود؟**

ODP و PowerPoint از مدل‌های ارائه متفاوتی استفاده می‌کنند و برخی عناصر—مانند جداول، قلم‌های سفارشی یا سبک‌های پر کردن—ممکن است دقیقاً به‌همان‌صورت رندر نشوند. توصیه می‌شود خروجی را بررسی کنید و در صورت نیاز، چیدمان یا قالب‌بندی را در کد تنظیم کنید.

**آیا برای استفاده از تبدیل ODP به نصب OpenOffice یا LibreOffice نیاز دارم؟**

خیر، Aspose.Slides برای .NET یک کتابخانه مستقل است و نیازی به نصب OpenOffice یا LibreOffice روی سیستم شما ندارد.

**آیا می‌توانم فرمت خروجی را در حین تبدیل ODP سفارشی‌سازی کنم (مثلاً تنظیم گزینه‌های PDF)؟**

بله، Aspose.Slides گزینه‌های غنی برای سفارشی‌سازی خروجی ارائه می‌دهد. به‌عنوان مثال، هنگام ذخیره به PDF، می‌توانید فشرده‌سازی، کیفیت تصویر، رندر متن و موارد دیگر را از طریق کلاس [PdfOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/pdfoptions/) کنترل کنید.

**آیا Aspose.Slides برای پردازش ODP در سمت سرور یا مبتنی بر ابر مناسب است؟**

به‌طور قطعی. Aspose.Slides برای .NET به‌گونه‌ای طراحی شده است که در هر دو محیط دسکتاپ و سرور، از جمله پلتفرم‌های مبتنی بر ابر مانند Azure، AWS و کانتینرهای Docker، بدون وابستگی به UI کار کند.