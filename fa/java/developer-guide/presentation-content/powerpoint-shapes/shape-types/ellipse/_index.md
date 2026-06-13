---
title: افزودن بیضی‌ها به ارائه‌ها در جاوا
linktitle: بیضی
type: docs
weight: 30
url: /fa/java/ellipse/
keywords:
- بیضی
- شکل
- افزودن بیضی
- ایجاد بیضی
- رسم بیضی
- بیضی قالب‌بندی‌شده
- پاورپوینت
- ارائه
- جاوا
- Aspose.Slides
description: "چگونه شکل‌های بیضی را در Aspose.Slides برای جاوا در ارائه‌های PPT و PPTX ایجاد، قالب‌بندی و دستکاری کنید—نمونه‌کدهای جاوا هم گنجانده شده است."
---
## **Overview**

این مقاله نشان می‌دهد که چگونه می‌توان اشکال بیضی را به اسلایدهای PowerPoint با استفاده از Aspose.Slides اضافه کرد. این مقاله شامل ایجاد یک بیضی ساده، ایجاد یک بیضی قالب‌بندی‌شده و ذخیرهٔ ارائه به‌روزرسانی‌شده به‌صورت فایل PPTX است. همچنین به سؤالات مرتبط مانند کار با موقعیت و اندازهٔ بیضی، کنترل ترتیب لایه‌ها و اعمال افکت‌های انیمیشنی می‌پردازد.

## **Create an Ellipse**
برای افزودن یک بیضی ساده به اسلاید انتخاب‌شدهٔ ارائه، لطفاً مراحل زیر را دنبال کنید:

- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation) ایجاد کنید.
- مرجع یک اسلاید را با استفاده از شاخص آن (Index) به‌دست آورید.
- یک AutoShape از نوع Ellipse را با استفاده از متد [addAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) که توسط شیء [IShapeCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IShapeCollection) ارائه می‌شود، اضافه کنید.
- ارائهٔ تغییر یافته را به‌عنوان یک فایل PPTX بنویسید.

در مثال زیر، یک بیضی به اسلاید اول اضافه کرده‌ایم

```java
// نمونه‌سازی کلاس Presentation که نمایانگر فایل PPTX است
Presentation pres = new Presentation();
try {
    // دریافت اولین اسلاید
    ISlide sld = pres.getSlides().get_Item(0);
    
    // افزودن AutoShape از نوع بیضی
    sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);
    
    // نوشتن فایل PPTX بر روی دیسک
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Create a Formatted Ellipse**
برای افزودن یک بیضی قالب‌بندی‌شده به اسلاید، لطفاً مراحل زیر را دنبال کنید:

- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation) ایجاد کنید.
- مرجع یک اسلاید را با استفاده از شاخص آن (Index) به‌دست آورید.
- یک AutoShape از نوع Ellipse را با استفاده از متد [addAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) که توسط شیء [IShapeCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IShapeCollection) ارائه می‌شود، اضافه کنید.
- نوع پر کردن (Fill Type) بیضی را به Solid تنظیم کنید.
- رنگ بیضی را با استفاده از ویژگی SolidFillColor.Color که توسط شیء [FillFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IFillFormat) مرتبط با شیء [IShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IShape) ارائه می‌شود، تنظیم کنید.
- رنگ خطوط بیضی را تنظیم کنید.
- عرض خطوط بیضی را تنظیم کنید.
- ارائهٔ تغییر یافته را به‌عنوان یک فایل PPTX بنویسید.

در مثال زیر، یک بیضی قالب‌بندی‌شده به اسلاید اول ارائه اضافه کرده‌ایم.

```java
// نمونه‌سازی کلاس Presentation که نمایانگر فایل PPTX است
Presentation pres = new Presentation();
try {
    // دریافت اولین اسلاید
    ISlide sld = pres.getSlides().get_Item(0);

    // افزودن AutoShape از نوع بیضی
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // اعمال برخی قالب‌بندی‌ها به شکل بیضی
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Chocolate));

    // اعمال برخی قالب‌بندی‌ها به خط بیضی
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // نوشتن فایل PPTX بر روی دیسک
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**چگونه موقعیت و اندازه دقیق یک بیضی را نسبت به واحدهای اسلاید تنظیم کنم؟**

مختصات و اندازه‌ها معمولاً در **نقطه** (points) مشخص می‌شوند. برای نتایج پیش‌بینی‌شدنی، محاسبات خود را بر مبنای اندازهٔ اسلاید انجام داده و میلی‌مترها یا اینچ‌های مورد نیاز را قبل از اختصاص مقادیر به نقاط تبدیل کنید.

**چگونه می‌توانم یک بیضی را بالاتر یا پایین‌تر از سایر اشیاء قرار دهم (کنترل ترتیب لایه‌ها)؟**

ترتیب رسم شیء را با بردن به جلو (bring to front) یا ارسال به پشت (send to back) تنظیم کنید. این کار به بیضی امکان می‌دهد که سایر اشیاء را پوشش دهد یا اشیائی که زیر آن هستند را نشان دهد.

**چگونه می‌توانم ظاهر یا تأکید بر یک بیضی را انیمیشن کنم؟**

[Apply](/slides/fa/java/shape-animation/) افکت‌های ورود، تأکید یا خروج را به شکل اعمال کنید و با تنظیم محرک‌ها و زمان‌بندی، زمان و نحوهٔ اجرای انیمیشن را سازماندهی کنید.