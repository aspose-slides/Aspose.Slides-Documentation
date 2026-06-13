---
title: استخراج اشیای Flash از ارائه‌ها در JavaScript
linktitle: فلش
type: docs
weight: 10
url: /fa/nodejs-java/flash/
keywords:
- استخراج flash
- شیء flash
- پاورپوینت
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "چگونه می‌توانید اشیای Flash را از اسلایدهای PowerPoint و OpenDocument در JavaScript با Aspose.Slides استخراج کنید، نمونه‌های کد کامل و بهترین روش‌ها را بیاموزید."
---
## **نمای کلی**

این مقاله توضیح می‌دهد چگونه می‌توان اشیای Flash را از ارائه‌ها با استفاده از Aspose.Slides استخراج کرد. نشان می‌دهد چگونه می‌توان یک کنترل Flash را بر اساس نام در مجموعه کنترل‌های یک اسلاید پیدا کرد و با داده‌های شیء SWF جاسازی‌شده کار کرد.

## **استخراج اشیای Flash از ارائه**

Aspose.Slides برای Node.js از طریق Java امکان استخراج اشیای flash را از یک ارائه فراهم می‌کند. می‌توانید کنترل flash را بر اساس نام دسترسی پیدا کنید و آن را همراه با ذخیره داده‌های شیء SWF از ارائه استخراج کنید.

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var controls = pres.getSlides().get_Item(0).getControls();
    var flashControl = null;
    for (var i = 0; i < controls.size(); i++) {
        var control = controls.get_Item(i);
        console.log(control.getName() === "ShockwaveFlash1");
        if (control.getName() === "ShockwaveFlash1") {
            flashControl = control;
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **سوالات متداول**

**چه فرمت‌های ارائه‌ای هنگام استخراج محتوای Flash پشتیبانی می‌شوند؟**

[Aspose.Slides پشتیبانی می‌کند](/slides/fa/nodejs-java/supported-file-formats/) قالب‌های اصلی PowerPoint مانند PPT و PPTX، زیرا می‌تواند این کانتینرها را بارگذاری کرده و به کنترل‌هایشان دسترسی پیدا کند، از جمله عناصر ActiveX مربوط به Flash.

**آیا می‌توانم ارائه‌ای حاوی Flash را به HTML5 تبدیل کنم و تعاملات Flash را حفظ کنم؟**

خیر. Aspose.Slides محتوا یا تعاملات SWF را اجرا یا تبدیل نمی‌کند. اگرچه خروجی به [HTML](/slides/fa/nodejs-java/convert-powerpoint-to-html/)/[HTML5](/slides/fa/nodejs-java/export-to-html5/) پشتیبانی می‌شود، Flash در مرورگرهای مدرن به دلیل پایان پشتیبانی اجرا نمی‌شود. روش پیشنهادی این است که قبل از خروجی، Flash را با جایگزین‌هایی مانند ویدئو یا انیمیشن‌های HTML5 جایگزین کنید.

**از نظر امنیتی، آیا Aspose.Slides هنگام خواندن یک ارائه فایل‌های SWF را اجرا می‌کند؟**

خیر. Aspose.Slides Flash را به عنوان داده‌های باینری جاسازی‌شده در فایل در نظر می‌گیرد و در طول پردازش محتوا یا فایل‌های SWF را اجرا نمی‌کند.

**چگونه باید ارائه‌هایی که شامل Flash به همراه فایل‌های جاسازی‌شده دیگر از طریق OLE هستند را مدیریت کنم؟**

Aspose.Slides از [استخراج اشیای OLE جاسازی‌شده](/slides/fa/nodejs-java/manage-ole/) پشتیبانی می‌کند، بنابراین می‌توانید تمام محتوای جاسازی‌شده مربوطه را در یک مرحله پردازش کنید و کنترل‌های Flash و سایر اسناد جاسازی‌شده OLE را به‌طور همزمان مدیریت کنید.