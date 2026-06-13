---
title: تبدیل ارائه‌های OpenDocument در جاوا
linktitle: تبدیل OpenDocument
type: docs
weight: 10
url: /fa/java/convert-openoffice-odp/
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
- ODP به ویدیو
- ODP به Word
- ODP به XPS
- OpenDocument
- ارائه
- جاوا
- Aspose.Slides
description: "Aspose.Slides برای جاوا به شما امکان می‌دهد ODP را به PDF، HTML و فرمت‌های تصویری به راحتی تبدیل کنید. برنامه‌های جاوای خود را با تبدیل سریع و دقیق ارائه‌ها تقویت کنید."
---
## **معرفی**

[**Aspose.Slides API**](https://products.aspose.com/slides/fa/java/) به شما امکان می‌دهد ارائه‌های OpenDocument (ODP) را به قالب‌های متعددی (HTML، PDF، TIFF، SWF، XPS و غیره) تبدیل کنید. API مورد استفاده برای تبدیل فایل‌های ODP به سایر قالب‌های سند، همان API است که برای عملیات تبدیل PowerPoint (PPT و PPTX) به‌کار می‌رود.

به‌عنوان مثال، اگر نیاز دارید یک ارائه ODP را به PDF تبدیل کنید، می‌توانید به‌صورت زیر عمل کنید:

```java
Presentation presentation = null;
try {
    presentation = new Presentation("pres.odp");
    presentation.save("pres.pdf", SaveFormat.Pdf);
    
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **ارائه OpenDocument در برنامه‌های مختلف**

هنگامی که یک فایل ارائه OpenDocument (ODP) در PowerPoint باز می‌شود، ممکن است قالب‌بندی اصلی آن را که در برنامه‌ای که ایجادشده است، حفظ نکند. این به این دلیل است که برنامه ارائه OpenDocument و برنامه PowerPoint ویژگی‌ها و رفتارهای رندرینگ متفاوتی دارند.

در ادامه برخی از تفاوت‌ها آمده است:

- در PowerPoint، جداول معمولاً در انتها رندر می‌شوند و ممکن است دیگر اشکال را پوشش دهند، بدون در نظر گرفتن ترتیب آنها در اسلاید ODP.
- پر کردن تصویر برای جداول ODP در PowerPoint پشتیبانی نمی‌شود.
- چرخش عمودی متن (۲۷۰°، پشته‌ای) و تراز توزیعی در LibreOffice/OpenOffice Impress پشتیبانی نمی‌شوند.
- پر کردن تصویر، پر کردن گرادیان و پر کردن الگو برای متن در LibreOffice/OpenOffice Impress پشتیبانی نمی‌شوند.

Microsoft PowerPoint و LibreOffice/OpenOffice Impress نیز فهرست‌ها را به‌صورت متفاوتی مدیریت می‌کنند. فایلی ODP که در PowerPoint ایجاد شده باشد ممکن است به‌درستی در LibreOffice/OpenOffice Impress نمایش داده نشود و بالعکس.

تصویر زیر نشان می‌دهد که یک فهرست چگونه وقتی در LibreOffice Impress ایجاد می‌شود به‌نظر می‌رسد:

![مثال فهرست ODP](odp-list-example.png)

Aspose.Slides فهرست‌های ODP را به‑گونه‌ای ذخیره می‌کند که اطمینان حاصل شود آنها به‌درستی در LibreOffice/OpenOffice Impress نمایش داده شوند.

[اطلاعات بیشتر در مورد فرمت OpenDocument و PowerPoint](https://support.microsoft.com/en-us/office/use-powerpoint-to-save-or-open-a-presentation-in-the-opendocument-presentation-odp-format-94805e84-1b09-4c98-a8b5-0da2a52242a0).

## **سوالات متداول**

**اگر پس از تبدیل، قالب‌بندی فایل ODP من تغییر کند چه می‌شود؟**

ODP و PowerPoint از مدل‌های ارائه متفاوتی استفاده می‌کنند و برخی عناصر—مانند جداول، قلم‌های سفارشی یا سبک‌های پر کردن—ممکن است دقیقاً به همان صورت رندر نشوند. توصیه می‌شود خروجی را بررسی کرده و در صورت نیاز، چیدمان یا قالب‌بندی را در کد تنظیم کنید.

**آیا برای استفاده از تبدیل ODP نیاز به نصب OpenOffice یا LibreOffice دارم؟**

نه، Aspose.Slides یک کتابخانه مستقل است و نیازی به نصب OpenOffice یا LibreOffice بر روی سیستم شما ندارد.

**آیا می‌توانم فرمت خروجی را هنگام تبدیل ODP سفارشی کنم (مثلاً تنظیم گزینه‌های PDF)؟**

بله، Aspose.Slides گزینه‌های غنی برای سفارشی‌سازی خروجی فراهم می‌کند. برای مثال، هنگام ذخیره به PDF، می‌توانید فشرده‌سازی، کیفیت تصویر، رندرینگ متن و موارد دیگر را از طریق کلاس [PdfOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pdfoptions/) کنترل کنید.

**آیا Aspose.Slides برای پردازش ODP در سمت سرور یا مبتنی بر ابر مناسب است؟**

به‌طور قطع. Aspose.Slides طوری طراحی شده است که در هر دو محیط دسکتاپ و سرور، از جمله پلتفرم‌های ابری مانند Azure، AWS و کانتینرهای Docker، بدون وابستگی به UI کار کند.