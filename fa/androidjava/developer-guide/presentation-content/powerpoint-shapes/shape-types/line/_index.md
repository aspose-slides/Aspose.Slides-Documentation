---
title: افزودن اشکال خط به ارائه‌ها در اندروید
linktitle: خط
type: docs
weight: 50
url: /fa/androidjava/Line/
keywords:
- خط
- ایجاد خط
- افزودن خط
- خط ساده
- پیکربندی خط
- سفارشی‌سازی خط
- سبک خط تیره
- سرپیکان
- پاورپوینت
- ارائه
- اندروید
- جاوا
- Aspose.Slides
description: "یاد بگیرید چگونه قالب‌بندی خطوط را در ارائه‌های پاورپوینت با Aspose.Slides برای اندروید دستکاری کنید. ویژگی‌ها، متدها و مثال‌های جاوا را کشف کنید."
---
## **بررسی اجمالی**

Aspose.Slides به شما امکان می‌دهد تا اشکال خط را به اسلایدهای PowerPoint به‌صورت برنامه‌نویسی اضافه کنید. این مقاله نشان می‌دهد چگونه یک خط ساده ایجاد کنید و چگونه یک خط را سفارشی کنید تا به شکل یک پیکان ظاهر شود.

شما می‌آموزید چگونه یک شکل خط را به اسلاید اضافه کنید، ظاهر بصری آن را تنظیم کنید و ارائه به‌روز شده را ذخیره کنید. مثال‌ها بر تنظیمات عملی قالب‌بندی خط مانند سبک، عرض، الگوی خط تیره، گزینه‌های سر پیکان و رنگ پرکر تمرکز دارند.

## **ایجاد خط ساده**

برای افزودن یک خط ساده به اسلاید انتخاب‌شده ارائه، مراحل زیر را دنبال کنید:

- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.
- با استفاده از Index آن، مرجع یک اسلاید را به‌دست آورید.
- با استفاده از متد [addAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) موجود در شیء [IShapeCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IShapeCollection)، یک AutoShape از نوع Line اضافه کنید.
- ارائه اصلاح‌شده را به صورت فایل PPTX بنویسید.

در مثال زیر، ما یک خط را به اولین اسلاید ارائه اضافه کرده‌ایم.

```java
// ایجاد نمونه از کلاس PresentationEx که فایل PPTX را نمایندگی می‌کند
Presentation pres = new Presentation();
try {
    // دریافت اولین اسلاید
    ISlide sld = pres.getSlides().get_Item(0);
    
    // اضافه کردن AutoShape از نوع خط
    sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // نوشتن فایل PPTX بر روی دیسک
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ایجاد خط به شکل پیکان**

Aspose.Slides for Android via Java همچنین به توسعه‌دهندگان امکان می‌دهد برخی از ویژگی‌های خط را تنظیم کنند تا ظاهر جذاب‌تری داشته باشد. بیایید چند ویژگی خط را تنظیم کنیم تا شبیه یک پیکان شود. برای این کار مراحل زیر را دنبال کنید:

- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.
- با استفاده از Index آن، مرجع یک اسلاید را به‌دست آورید.
- با استفاده از متد [addAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) موجود در شیء [IShapeCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IShapeCollection)، یک AutoShape از نوع Line اضافه کنید.
- [Line Style](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/LineStyle) را به یکی از سبک‌های ارائه‌شده توسط Aspose.Slides for Android via Java تنظیم کنید.
- عرض خط را تنظیم کنید.
- [Dash Style](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/LineDashStyle) خط را به یکی از سبک‌های ارائه‌شده توسط Aspose.Slides for Android via Java تنظیم کنید.
- [Arrow Head Style](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/LineArrowheadStyle) و [Length](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/LineArrowheadLength) نقطه شروع خط را تنظیم کنید.
- [Arrow Head Style](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/LineArrowheadStyle) و [Length](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/LineArrowheadLength) نقطه انتهای خط را تنظیم کنید.
- ارائه اصلاح‌شده را به صورت فایل PPTX بنویسید.

```java
// ایجاد نمونه از کلاس PresentationEx که فایل PPTX را نمایندگی می‌کند
Presentation pres = new Presentation();
try {
    // دریافت اولین اسلاید
    ISlide sld = pres.getSlides().get_Item(0);

    // اضافه کردن AutoShape از نوع خط
    IAutoShape shp = sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // اعمال برخی قالب‌بندی‌ها بر روی خط
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

**آیا می‌توانم یک خط معمولی را به کانکتور تبدیل کنم تا به شکل «چسبیدن» به اشکال باشد؟**

نه. یک خط معمولی (یک [AutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/autoshape/) از نوع [Line](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/shapetype/)) به‌صورت خودکار به کانکتور تبدیل نمی‌شود. برای چسباندن به اشکال، از نوع اختصاصی [Connector](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/connector/) و API‌های مربوطه (/slides/fa/androidjava/connector/) استفاده کنید.

**اگر ویژگی‌های یک خط از تم ارث‌بری شده باشد و تعیین مقادیر نهایی دشوار باشد، چه کار باید انجام دهم؟**

[ویژگی‌های مؤثر را بخوانید](/slides/fa/androidjava/shape-effective-properties/) از طریق اینترفیس‌های [ILineFormatEffectiveData](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ilinefillformateffectivedata/) — این اینترفیس‌ها پیش‌از پیش ارث‌بری و سبک‌های تم را در نظر می‌گیرند.

**آیا می‌توانم خط را در مقابل ویرایش (جابجایی، تغییر اندازه) قفل کنم؟**

بله. اشکال [قفل‌سازی شیء](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/autoshape/#getAutoShapeLock--) را فراهم می‌کنند که به شما امکان می‌دهد عملیات ویرایشی را غیرفعال کنید.