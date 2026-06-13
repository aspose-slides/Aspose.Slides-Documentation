---
title: تبدیل ارائه‌های OpenDocument در JavaScript
linktitle: تبدیل OpenDocument
type: docs
weight: 10
url: /fa/nodejs-java/convert-openoffice-odp/
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
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides برای Node.js به شما امکان تبدیل ODP به PDF، HTML و فرمت‌های تصویری را به سادگی می‌دهد. برنامه‌های خود را با تبدیل سریع و دقیق ارائه‌ها تقویت کنید."
---
[**API Aspose.Slides**](https://products.aspose.com/slides/fa/nodejs-java/) به شما امکان تبدیل ارائه‌های OpenDocument (ODP) به فرمت‌های متعدد (HTML، PDF، TIFF، SWF، XPS و غیره) را می‌دهد. API مورد استفاده برای تبدیل فایل‌های ODP به سایر فرمت‌های سند، همان API است که برای عملیات تبدیل PowerPoint (PPT و PPTX) به کار می‌رود.

به‌عنوان مثال، اگر نیاز به تبدیل یک ارائه ODP به PDF داشته باشید، می‌توانید به‌صورت زیر عمل کنید:

```js
let presentation = null;
try {
  presentation = new aspose.slides.Presentation("presentation.odp");
  presentation.save("presentation.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **FAQ**

**اگر پس از تبدیل، قالب‌بندی فایل ODP من تغییر کند چه؟**

ODP و PowerPoint از مدل‌های ارائه متفاوتی استفاده می‌کنند و برخی عناصر—مانند جدول‌ها، فونت‌های سفارشی یا سبک‌های پرکردن—ممکن است دقیقاً به همان شکل رندر نشوند. توصیه می‌شود خروجی را مرور کنید و در صورت نیاز، چینش یا قالب‌بندی را از طریق کد تنظیم کنید.

**آیا برای استفاده از تبدیل ODP نیاز به نصب OpenOffice یا LibreOffice دارم؟**

خیر، Aspose.Slides یک کتابخانه مستقل است و نیازی به نصب OpenOffice یا LibreOffice بر روی سیستم شما ندارد.

**آیا می‌توانم در حین تبدیل ODP فرمت خروجی را سفارشی کنم (مثلاً تنظیمات PDF)؟**

بله، Aspose.Slides گزینه‌های گسترده‌ای برای سفارشی‌سازی خروجی فراهم می‌کند. برای مثال، هنگام ذخیره به PDF می‌توانید از طریق کلاس [PdfOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pdfoptions/) فشرده‌سازی، کیفیت تصویر، رندر متن و موارد دیگر را کنترل کنید.

**آیا Aspose.Slides برای پردازش ODP در سمت سرور یا محیط‌های ابری مناسب است؟**

به‌طور قطع. Aspose.Slides برای کار در هر دو محیط دسکتاپ و سرور، از جمله پلتفرم‌های ابری مانند Azure، AWS و کانتینرهای Docker، بدون وابستگی به UI طراحی شده است.