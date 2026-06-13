---
title: افزودن بیضی‌ها به ارائه‌ها در جاوااسکریپت
linktitle: بیضی
type: docs
weight: 30
url: /fa/nodejs-java/ellipse/
keywords:
- بیضی
- شکل
- افزودن بیضی
- ایجاد بیضی
- رسم بیضی
- بیضی قالب‌بندی‌شده
- پاورپوینت
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "نحوهٔ ایجاد، قالب‌بندی و دستکاری اشکال بیضی در Aspose.Slides برای Node.js در ارائه‌های PPT و PPTX را بیاموزید — شامل مثال‌های کد JavaScript."
---
## **بررسی کلی**

این مقاله نشان می‌دهد چگونه با استفاده از Aspose.Slides به اسلایدهای PowerPoint اشکال بیضی اضافه کنید. این شامل ایجاد یک بیضی ساده، ایجاد یک بیضی قالب‌بندی‌شده، و ذخیره ارائه به‌روز شده به صورت فایل PPTX است. همچنین به سؤال‌های مرتبط مانند کار با موقعیت و اندازهٔ بیضی، کنترل ترتیب قرارگیری، و اعمال افکت‌های انیمیشن می‌پردازد.

## **ایجاد بیضی**
برای افزودن یک بیضی ساده به اسلاید انتخاب‌شدهٔ ارائه، مراحل زیر را دنبال کنید:

- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation) ایجاد کنید.
- مرجع یک اسلاید را با استفاده از Index آن به دست آورید.
- یک AutoShape از نوع Ellipse را با استفاده از متد [addAutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) که توسط شیء [ShapeCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ShapeCollection) ارائه می‌شود، اضافه کنید.
- ارائهٔ تغییر یافته را به صورت فایل PPTX بنویسید.

در مثال زیر، یک بیضی را به اولین اسلاید اضافه کرده‌ایم

```javascript
// نمونه‌سازی کلاس Presentation که نمایانگر PPTX است
var pres = new aspose.slides.Presentation();
try {
    // دریافت اولین اسلاید
    var sld = pres.getSlides().get_Item(0);
    // اضافه کردن AutoShape از نوع بیضی
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 150, 150, 50);
    // نوشتن فایل PPTX در دیسک
    pres.save("EllipseShp1.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **ایجاد بیضی قالب‌بندی‌شده**
برای افزودن یک بیضی بهتر قالب‌بندی‌شده به اسلاید، مراحل زیر را دنبال کنید:

- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation) ایجاد کنید.
- مرجع یک اسلاید را با استفاده از Index آن به دست آورید.
- یک AutoShape از نوع Ellipse را با استفاده از متد [addAutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) که توسط شیء [ShapeCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ShapeCollection) ارائه می‌شود، اضافه کنید.
- نوع پر کردن بیضی را به Solid تنظیم کنید.
- رنگ بیضی را با استفاده از ویژگی SolidFillColor.Color که توسط شیء [FillFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/FillFormat) مرتبط با شیء [Shape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Shape) ارائه می‌شود، تنظیم کنید.
- رنگ خطوط بیضی را تنظیم کنید.
- عرض خطوط بیضی را تنظیم کنید.
- ارائهٔ تغییر یافته را به صورت فایل PPTX بنویسید.

در مثال زیر، یک بیضی قالب‌بندی‌شده را به اولین اسلاید ارائه افزوده‌ایم.

```javascript
// نمونه‌سازی کلاس Presentation که نمایانگر PPTX است
var pres = new aspose.slides.Presentation();
try {
    // دریافت اولین اسلاید
    var sld = pres.getSlides().get_Item(0);
    // اضافه کردن AutoShape از نوع بیضی
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 150, 150, 50);
    // اعمال برخی قالب‌بندی‌ها به شکل بیضی
    shp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.Chocolate));
    // اعمال برخی قالب‌بندی‌ها به خط بیضی
    shp.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shp.getLineFormat().setWidth(5);
    // نوشتن فایل PPTX در دیسک
    pres.save("EllipseShp1.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
 
## **پرسش‌های متداول**

**چگونه موقعیت و اندازه دقیق یک بیضی را نسبت به واحدهای اسلاید تنظیم کنم؟**

مختصات و اندازه‌ها معمولاً بر حسب point مشخص می‌شوند. برای نتایج پیش‌بینی‌پذیر، محاسبات خود را بر پایهٔ اندازه اسلاید انجام دهید و میلی‌متر یا اینچ مورد نیاز را پیش از اختصاص مقادیر به point تبدیل کنید.

**چگونه می‌توانم یک بیضی را بالای یا زیر اشیاء دیگر قرار دهم (کنترل ترتیب قرارگیری)؟**

با تغییر ترتیب رسم شیء، آن را به جلو یا به عقب بفرستید. این کار به بیضی اجازه می‌دهد تا بر سایر اشیاء هم‌پوشانی کرده یا اشیاء زیرین را نمایش دهد.

**چگونه می‌توانم ظاهر یا تأکید یک بیضی را انیمیشن کنم؟**

[اعمال](/slides/fa/nodejs-java/shape-animation/) افکت‌های ورود، تأکید یا خروج به شکل، و پیکربندی محرک‌ها و زمان‌بندی برای تنظیم زمان و نحوهٔ پخش انیمیشن.