---
title: استخراج اشیاء Flash از ارائه‌ها در Java
linktitle: فلش
type: docs
weight: 10
url: /fa/java/flash/
keywords:
- استخراج فلش
- شیء فلش
- پاورپوینت
- سند باز
- ارائه
- جاوا
- Aspose.Slides
description: "یاد بگیرید چگونه اشیاء Flash را از اسلایدهای PowerPoint و OpenDocument در Java با Aspose.Slides استخراج کنید، نمونه‌های کامل کد و بهترین روش‌ها."
---
## **نمای کلی**

این مقاله توضیح می‌دهد چگونه می‌توان اشیاء Flash را از ارائه‌ها با استفاده از Aspose.Slides استخراج کرد. نشان می‌دهد چگونه یک کنترل Flash را بر اساس نام در مجموعهٔ کنترل‌های یک اسلاید پیدا کرده و با داده‌های شیء SWF جاسازی‌شده کار کنید.

## **استخراج اشیاء Flash از ارائه‌ها**

Aspose.Slides برای Java قابلیتی برای استخراج اشیاء flash از یک ارائه فراهم می‌کند. می‌توانید کنترل flash را بر اساس نام دسترسی پیدا کنید و آن را از ارائه استخراج کنید و داده‌های شیء SWF را ذخیره کنید.

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

## **پرسش‌های متداول**

**چه فرمت‌های ارائه‌ای هنگام استخراج محتوای Flash پشتیبانی می‌شوند؟**

[Aspose.Slides supports](/slides/fa/java/supported-file-formats/) فرمت‌های اصلی PowerPoint مانند PPT و PPTX را، زیرا می‌تواند این کانتینرها را بارگذاری کرده و به کنترل‌های آن‌ها، از جمله عناصر ActiveX مرتبط با Flash، دسترسی داشته باشد.

**آیا می‌توانم یک ارائه شامل Flash را به HTML5 تبدیل کنم و قابلیت تعاملی Flash را حفظ کنم؟**

نه. Aspose.Slides محتوای SWF را اجرا نمی‌کند و تعاملی آن را تبدیل نمی‌سازد. در حالی که خروجی به [HTML](/slides/fa/java/convert-powerpoint-to-html/)/[HTML5](/slides/fa/java/export-to-html5/) پشتیبانی می‌شود، Flash در مرورگرهای مدرن به دلیل پایان پشتیبانی اجرا نمی‌شود. مسیر پیشنهادی این است که قبل از خروجی، Flash را با گزینه‌هایی مانند ویدئو یا انیمیشن‌های HTML5 جایگزین کنید.

**از منظر امنیتی، آیا Aspose.Slides هنگام خواندن یک ارائه فایل‌های SWF را اجرا می‌کند؟**

نه. Aspose.Slides Flash را به عنوان دادهٔ باینری درون فایل در نظر می‌گیرد و در حین پردازش محتویات SWF را اجرا نمی‌کند.

**چگونه باید ارائه‌هایی که شامل Flash به همراه سایر فایل‌های جاسازی‌شده از طریق OLE هستند را مدیریت کنم؟**

Aspose.Slides از [extracting embedded OLE objects](/slides/fa/java/manage-ole/) پشتیبانی می‌کند، بنابراین می‌توانید تمام محتویات جاسازی‌شده مرتبط را در یک عبور پردازش کنید و کنترل‌های Flash و سایر اسناد جاسازی‌شده با OLE را به‌طور همزمان مدیریت کنید.