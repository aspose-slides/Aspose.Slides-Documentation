---
title: افزودن اشکال خط به ارائه‌ها در اندروید
linktitle: خط
type: docs
weight: 50
url: /fa/androidjava/line/
keywords:
- خط
- ایجاد خط
- افزودن خط
- خط ساده
- پیکربندی خط
- سفارشی‌سازی خط
- سبک خط چین
- سر پیکان
- پاورپوینت
- ارائه
- اندروید
- جاوا
- Aspose.Slides
description: "یاد بگیرید چگونه قالب‌بندی خطوط را در ارائه‌های پاورپوینت با Aspose.Slides برای اندروید مدیریت کنید. ویژگی‌ها، روش‌ها و مثال‌های جاوا را کشف کنید."
---
## **مرور کلی**

Aspose.Slides به شما اجازه می‌دهد تا اشکال خط را به‌صورت برنامه‌نویسی به اسلایدهای PowerPoint اضافه کنید. این مقاله نشان می‌دهد چگونه یک خط ساده ایجاد کنید و چگونه خط را طوری تنظیم کنید که به شکل یک پیکان نمایش داده شود.

شما یاد خواهید گرفت چگونه یک شکل خط را به اسلاید اضافه کنید، ظاهر بصری آن را تنظیم کنید و ارائه به‌روزشده را ذخیره کنید. مثال‌ها بر روی تنظیمات کاربردی قالب‌بندی خط مانند سبک، عرض، الگوی خط چین، گزینه‌های سرپیکان و رنگ پر تمرکز دارند.

## **ایجاد خط ساده**

برای افزودن یک خط ساده به اسلاید انتخابی ارائه، مراحل زیر را دنبال کنید:

- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.
- مرجع یک اسلاید را با استفاده از Index آن به دست آورید.
- یک AutoShape از نوع Line را با استفاده از متد [addAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) که توسط شیء [IShapeCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IShapeCollection) فراهم شده، اضافه کنید.
- ارائه تغییر یافته را به صورت فایل PPTX ذخیره کنید.

در مثال زیر، یک خط به اولین اسلاید ارائه اضافه کرده‌ایم.

```java
// نمونه‌سازی کلاس PresentationEx که فایل PPTX را نمایندگی می‌کند
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

## **ایجاد خط به شکل پیکان**

Aspose.Slides for Android via Java همچنین به توسعه‌دهندگان امکان می‌دهد تا برخی ویژگی‌های خط را برای جذاب‌تر شدن تنظیم کنند. بیایید چند ویژگی خط را طوری پیکربندی کنیم که شبیه یک پیکان به نظر برسد. برای انجام این کار، مراحل زیر را دنبال کنید:

- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.
- مرجع یک اسلاید را با استفاده از Index آن به دست آورید.
- یک AutoShape از نوع Line را با استفاده از متد [addAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) که توسط شیء [IShapeCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IShapeCollection) فراهم شده، اضافه کنید.
- استایل [Line Style](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/LineStyle) را به یکی از سبک‌های ارائه شده توسط Aspose.Slides for Android via Java تنظیم کنید.
- عرض خط را تنظیم کنید.
- استایل [Dash Style](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/LineDashStyle) خط را به یکی از سبک‌های ارائه شده توسط Aspose.Slides for Android via Java تنظیم کنید.
- استایل [Arrow Head Style](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/LineArrowheadStyle) و [Length](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/LineArrowheadLength) نقطه شروع خط را تنظیم کنید.
- استایل [Arrow Head Style](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/LineArrowheadStyle) و [Length](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/LineArrowheadLength) نقطه انتهای خط را تنظیم کنید.
- ارائه تغییر یافته را به صورت فایل PPTX ذخیره کنید.

```java
// نمونه‌سازی کلاس PresentationEx که فایل PPTX را نمایندگی می‌کند
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

## **سوالات متداول**

**آیا می‌توانم یک خط عادی را به یک Connector تبدیل کنم تا به اشکال «چسبیده» شود؟**

خیر. یک خط عادی ( یک [AutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/autoshape/) از نوع [Line](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/shapetype/) ) به‌صورت خودکار به Connector تبدیل نمی‌شود. برای چسباندن به اشکال، از نوع [Connector](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/connector/) مخصوص و APIهای مربوطه (/slides/fa/androidjava/connector/) استفاده کنید.

**اگر ویژگی‌های یک خط از تم ارث‌بری شده باشد و تعیین مقادیر نهایی دشوار باشد، باید چه کاری انجام دهم؟**

[ویژگی‌های مؤثر](/slides/fa/androidjava/shape-effective-properties/) را از طریق اینترفیس‌های [ILineFormatEffectiveData](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ilinefillformateffectivedata/) بخوانید — این‌ها قبلاً ارث‌بری و سبک‌های تم را در نظر گرفته‌اند.

**آیا می‌توانم یک خط را در برابر ویرایش (جابه‌جایی، تغییر اندازه) قفل کنم؟**

بله. اشکال، [قفل‌کننده‌ها](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/autoshape/#getAutoShapeLock--) را فراهم می‌کنند که به شما اجازه می‌دهد عملیات ویرایشی را غیرفعال کنید.