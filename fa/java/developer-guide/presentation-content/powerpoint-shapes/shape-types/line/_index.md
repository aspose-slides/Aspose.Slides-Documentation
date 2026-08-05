---
title: افزودن اشکال خط به ارائه‌ها در جاوا
linktitle: خط
type: docs
weight: 50
url: /fa/java/line/
keywords:
- خط
- ایجاد خط
- افزودن خط
- خط ساده
- پیکربندی خط
- سفارشی‌سازی خط
- سبک خط تیره
- سر پیکان
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "یادگیری نحوه دستکاری قالب‌بندی خط در ارائه‌های PowerPoint با Aspose.Slides برای Java. کشف ویژگی‌ها، متدها و مثال‌ها."
---
## **مروری کلی**

Aspose.Slides به شما امکان می‌دهد تا اشکال خط را به طور برنامه‌نویسی به اسلایدهای PowerPoint اضافه کنید. این مقاله نشان می‌دهد چگونه یک خط ساده ایجاد کنید و چگونه یک خط را طوری سفارشی کنید که به شکل یک پیکان ظاهر شود.

شما یاد خواهید گرفت چگونه یک شکل خط را به اسلاید اضافه کنید، ظاهر آن را تنظیم کنید و ارائه به‌روز شده را ذخیره کنید. مثال‌ها بر تنظیمات عملی قالب‌بندی خط مانند سبک، عرض، الگوی خط تیره، گزینه‌های سرپیکان و رنگ پر کردن متمرکز هستند.

## **ایجاد یک خط ساده**

برای افزودن یک خط ساده به اسلاید منتخب ارائه، مراحل زیر را دنبال کنید:

- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.
- با استفاده از Index آن، مرجع یک اسلاید را دریافت کنید.
- با استفاده از متد [addAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) که توسط شیء [IShapeCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IShapeCollection) در دسترس است، یک AutoShape از نوع Line اضافه کنید.
- ارائه‌ی تغییر یافته را به صورت فایل PPTX بنویسید.

در مثال زیر، یک خط را به اولین اسلاید ارائه اضافه کرده‌ایم.

```java
// نمونه‌سازی کلاس PresentationEx که نمایانگر فایل PPTX است
Presentation pres = new Presentation();
try {
    // دریافت اولین اسلاید
    ISlide sld = pres.getSlides().get_Item(0);
    
    // افزودن AutoShape از نوع خط
    sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // نوشتن فایل PPTX بر روی دیسک
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ایجاد یک خط شبیه پیکان**

Aspose.Slides for Java همچنین به توسعه‌دهندگان اجازه می‌دهد برخی از ویژگی‌های خط را پیکربندی کنند تا ظاهر جذاب‌تری داشته باشد. بیایید چند ویژگی خط را طوری تنظیم کنیم که شبیه یک پیکان باشد. برای این کار مراحل زیر را دنبال کنید:

- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.
- با استفاده از Index آن، مرجع یک اسلاید را دریافت کنید.
- با استفاده از متد [addAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) که توسط شیء [IShapeCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IShapeCollection) در دسترس است، یک AutoShape از نوع Line اضافه کنید.
- [Line Style](https://reference.aspose.com/slides/fa/java/com.aspose.slides/LineStyle) را به یکی از سبک‌های ارائه‌شده توسط Aspose.Slides for Java تنظیم کنید.
- عرض خط را تنظیم کنید.
- [Dash Style](https://reference.aspose.com/slides/fa/java/com.aspose.slides/LineDashStyle) خط را به یکی از سبک‌های ارائه‌شده توسط Aspose.Slides for Java تنظیم کنید.
- [Arrow Head Style](https://reference.aspose.com/slides/fa/java/com.aspose.slides/LineArrowheadStyle) و [Length](https://reference.aspose.com/slides/fa/java/com.aspose.slides/LineArrowheadLength) نقطه شروع خط را تنظیم کنید.
- [Arrow Head Style](https://reference.aspose.com/slides/fa/java/com.aspose.slides/LineArrowheadStyle) و [Length](https://reference.aspose.com/slides/fa/java/com.aspose.slides/LineArrowheadLength) نقطه انتهای خط را تنظیم کنید.
- ارائه‌ی تغییر یافته را به صورت فایل PPTX بنویسید.

```java
// نمونه‌سازی کلاس PresentationEx که نمایانگر فایل PPTX است
Presentation pres = new Presentation();
try {
    // دریافت اولین اسلاید
    ISlide sld = pres.getSlides().get_Item(0);

    // افزودن AutoShape از نوع خط
    IAutoShape shp = sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // اعمال برخی قالب‌بندی‌ها روی خط
    shp.getLineFormat().setStyle(LineStyle.ThickBetweenThin);
    shp.getLineFormat().setWidth(10);

    shp.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    shp.getLineFormat().setBeginArrowheadLength(LineArrowheadLength.Short);
    shp.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.Oval);

    shp.getLineFormat().setEndArrowheadLength(LineArrowheadLength.Long);
    shp.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);

    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Maroon));

    // نوشتن فایل PPTX بر روی دیسک
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **پرسش‌های متداول**

**آیا می‌توانم یک خط عادی را به اتصال‌کن تبدیل کنم تا به اشکال «چسبیده»؟**

خیر. یک خط عادی (یک [AutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/autoshape/) از نوع [Line](https://reference.aspose.com/slides/fa/java/com.aspose.slides/shapetype/)) به طور خودکار تبدیل به اتصال‌کن نمی‌شود. برای چسباندن به اشکال، از نوع اختصاصی [Connector](https://reference.aspose.com/slides/fa/java/com.aspose.slides/connector/) و APIهای مربوطه](/slides/fa/java/connector/) استفاده کنید.

**اگر ویژگی‌های یک خط از تم ارث‌بری شده باشد و تعیین مقدار نهایی دشوار باشد، چه کار باید بکنم؟**

[ویژگی‌های مؤثر را مطالعه کنید](/slides/fa/java/shape-effective-properties/) از طریق رابط‌های [ILineFormatEffectiveData](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilinefillformateffectivedata/). این رابط‌ها قبلاً ارث‌بری و سبک‌های تم را در نظر گرفته‌اند.

**آیا می‌توانم یک خط را در برابر ویرایش (جابجایی، تغییر اندازه) قفل کنم؟**

بله. اشکال دارای [lock objects](https://reference.aspose.com/slides/fa/java/com.aspose.slides/autoshape/#getAutoShapeLock--) هستند که به شما امکان می‌دهد [عملیات ویرایشی را غیرفعال کنید](/slides/fa/java/applying-protection-to-presentation/).