---
title: استخراج اشیای Flash از ارائه‌ها در اندروید
linktitle: فلش
type: docs
weight: 10
url: /fa/androidjava/flash/
keywords:
- استخراج فلش
- شیء فلش
- پاورپوینت
- اسناد باز
- ارائه
- اندروید
- جاوا
- Aspose.Slides
description: "چگونگی استخراج اشیای Flash از اسلایدهای PowerPoint و OpenDocument با استفاده از Aspose.Slides برای اندروید در جاوا، نمونه‌های کامل کد و بهترین شیوه‌ها."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد چگونه اشیای Flash را از ارائه‌ها با استفاده از Aspose.Slides استخراج کنیم. این نشان می‌دهد چگونه یک کنترل Flash را بر اساس نام در مجموعه کنترل‌های اسلاید پیدا کرده و با داده‌های شیء SWF جاسازی‌شده کار کنیم.

## **استخراج اشیای Flash از ارائه‌ها**

Aspose.Slides for Android via Java قابلیتی برای استخراج اشیای Flash از یک ارائه فراهم می‌کند. می‌توانید کنترل Flash را بر اساس نام دسترسی پیدا کنید و آن را از ارائه استخراج کنید و داده‌های شیء SWF را ذخیره کنید.

```java
// نمونه‌سازی کلاس Presentation که نمایانگر فایل PPTX است
Presentation pres = new Presentation();
try {
    IControlCollection controls = pres.getSlides().get_Item(0).getControls();
    Control flashControl = null;
    for (IControl control : controls)
    {
        if (control.getName() == "ShockwaveFlash1")
        {
            flashControl = (Control)control;
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **سوالات متداول**

**چه فرمت‌های ارائه‌ای هنگام استخراج محتوای Flash پشتیبانی می‌شوند؟**

[Aspose.Slides supports](/slides/fa/androidjava/supported-file-formats/) قالب‌های اصلی PowerPoint مانند PPT و PPTX را پشتیبانی می‌کند، چرا که می‌تواند این بسته‌ها را بارگذاری کرده و به کنترل‌های آنها دسترسی پیدا کند، از جمله عناصر ActiveX مرتبط با Flash.

**آیا می‌توانم ارائه‌ای که شامل Flash است را به HTML5 تبدیل کنم و تعاملات Flash را حفظ کنم؟**

No. Aspose.Slides محتوای SWF را اجرا یا تعاملات آن را تبدیل نمی‌کند. در حالی که خروجی به [HTML](/slides/fa/androidjava/convert-powerpoint-to-html/)/[HTML5](/slides/fa/androidjava/export-to-html5/) پشتیبانی می‌شود، Flash در مرورگرهای مدرن به دلیل پایان پشتیبانی پخش نمی‌شود. مسیر پیشنهادی این است که پیش از خروجی، Flash را با گزینه‌های جایگزین مانند ویدئو یا انیمیشن‌های HTML5 جایگزین کنید.

**از منظر امنیتی، آیا Aspose.Slides هنگام خواندن یک ارائه فایل‌های SWF را اجرا می‌کند؟**

No. Aspose.Slides Flash را به عنوان دادهٔ باینری جاسازی‌شده در فایل در نظر می‌گیرد و محتوای SWF را در حین پردازش اجرا نمی‌کند.

**چگونه باید ارائه‌هایی را که Flash را به‌همراه فایل‌های جاسازی‌شدهٔ دیگر از طریق OLE شامل می‌شوند، مدیریت کنم؟**

Aspose.Slides [extracting embedded OLE objects](/slides/fa/androidjava/manage-ole/) را پشتیبانی می‌کند، بنابراین می‌توانید تمام محتوای جاسازی‌شده مرتبط را در یک گذر پردازش کنید و کنترل‌های Flash و سایر اسناد جاسازی‌شدهٔ OLE را به‌صورت مشترک مدیریت نمایید.