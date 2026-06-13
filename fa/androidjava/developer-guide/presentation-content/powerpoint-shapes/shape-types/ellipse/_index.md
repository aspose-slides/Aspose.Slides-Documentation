---
title: افزودن بیضی‌ها به ارائه‌ها در اندروید
linktitle: بیضی
type: docs
weight: 30
url: /fa/androidjava/ellipse/
keywords:
  - بیضی
  - شکل
  - افزودن بیضی
  - ایجاد بیضی
  - کشیدن بیضی
  - بیضی قالب‌بندی‌شده
  - PowerPoint
  - ارائه
  - اندروید
  - جاوا
  - Aspose.Slides
description: "یاد بگیرید چگونه شکل‌های بیضی را در Aspose.Slides برای اندروید در ارائه‌های PPT و PPTX ایجاد، قالب‌بندی و دستکاری کنید — مثال‌های کد جاوا همراه است."
---
## **مرور کلی**

این مقاله نشان می‌دهد چگونه می‌توان با استفاده از Aspose.Slides به اسلایدهای PowerPoint اشکال بیضوی افزود. این مقاله ایجاد یک بیضی ساده، ایجاد یک بیضی قالب‌بندی‌شده و ذخیره ارائه به‌روز شده به صورت فایل PPTX را پوشش می‌دهد. همچنین به سؤالات مرتبطی مانند کار با موقعیت و اندازه بیضی، کنترل ترتیب لایه‌ها و اعمال افکت‌های انیمیشن می‌پردازد.

## **ایجاد یک بیضی**
برای افزودن یک بیضی ساده به اسلاید منتخب ارائه، لطفاً مراحل زیر را دنبال کنید:

- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation) ایجاد کنید.
- با استفاده از Index آن، مرجع یک اسلاید را به دست آورید.
- با استفاده از متد [addAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) که توسط شیء [IShapeCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IShapeCollection) ارائه می‌شود، یک AutoShape از نوع Ellipse اضافه کنید.
- ارائه تغییر یافته را به صورت فایل PPTX ذخیره کنید.

در مثال زیر، یک بیضی را به اسلاید اول اضافه کرده‌ایم

```java
// نمونه‌سازی کلاس Presentation که نمایانگر PPTX است
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

## **ایجاد یک بیضی قالب‌بندی‌شده**
برای افزودن یک بیضی بهتر قالب‌بندی‌شده به اسلاید، لطفاً مراحل زیر را دنبال کنید:

- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation) ایجاد کنید.
- با استفاده از Index آن، مرجع یک اسلاید را به دست آورید.
- با استفاده از متد [addAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) که توسط شیء [IShapeCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IShapeCollection) ارائه می‌شود، یک AutoShape از نوع Ellipse اضافه کنید.
- نوع پر کردن بیضی را به Solid تنظیم کنید.
- رنگ بیضی را با استفاده از ویژگی SolidFillColor.Color که توسط شیء [FillFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IFillFormat) مربوط به شیء [IShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IShape) ارائه می‌شود، تنظیم کنید.
- رنگ خطوط بیضی را تنظیم کنید.
- عرض خطوط بیضی را تنظیم کنید.
- ارائه تغییر یافته را به صورت فایل PPTX ذخیره کنید.

در مثال زیر، یک بیضی قالب‌بندی‌شده را به اسلاید اول ارائه اضافه کرده‌ایم.

```java
// نمونه‌سازی کلاس Presentation که نمایانگر PPTX است
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

## **سوالات متداول**

**How do I set the exact position and size of an ellipse with respect to the slide's units?**

مختصات و اندازه‌ها معمولاً به **نقطه** (points) مشخص می‌شوند. برای نتایج پیش‌بینی‌پذیر، محاسبات خود را بر پایهٔ اندازه اسلاید بنا کنید و قبل از اختصاص مقدار، میلی‌متر یا اینچ‌های مورد نیاز را به نقطه تبدیل کنید.

**How can I place an ellipse above or below other objects (control stacking order)?**

با تغییر ترتیب رسم شیء، می‌توانید آن را به جلو (Bring to Front) یا به عقب (Send to Back) منتقل کنید. این کار اجازه می‌دهد بیضی بر روی اشیای دیگر پوشانده شود یا اشیای زیرین را نشان دهد.

**How do I animate the appearance or emphasis of an ellipse?**

[اعمال](/slides/fa/androidjava/shape-animation/) افکت‌های ورود، تأکید یا خروج را به شکل اعمال کنید و تریگرها و زمان‌بندی را تنظیم کنید تا زمان و نحوه پخش انیمیشن تعیین شود.