---
title: افزودن اشکال خط به ارائه‌ها در Java
linktitle: خط
type: docs
weight: 50
url: /fa/java/Line/
keywords:
- خط
- ایجاد خط
- افزودن خط
- خط ساده
- پیکربندی خط
- سفارشی‌سازی خط
- سبک خط نقطه‌دار
- سر پیکان
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه قالب‌بندی خطوط را در ارائه‌های PowerPoint با Aspose.Slides برای Java مدیریت کنید. ویژگی‌ها، متدها و مثال‌ها را کشف کنید."
---
## **بررسی کلی**

Aspose.Slides به شما امکان می‌دهد اشکال خط را به اسلایدهای PowerPoint به‌صورت برنامه‌ای اضافه کنید. این مقاله نشان می‌دهد چگونه یک خط ساده ایجاد شود و چگونه خطی را سفارشی کنیم تا به‌صورت یک پیکان ظاهر شود.

شما می‌آموزید که چگونه یک شکل خط را به اسلاید اضافه کنید، ظاهر بصری آن را تنظیم کنید و ارائه به‌روزشده را ذخیره کنید. مثال‌ها بر تنظیمات عملی قالب‌بندی خط مانند سبک، عرض، الگوی نقطه‌خط، گزینه‌های سرپیکان و رنگ پر تمرکز دارند.

## **ایجاد یک خط ساده**

برای اضافه کردن یک خط ساده به اسلاید انتخاب‌شده ارائه، مراحل زیر را دنبال کنید:

- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.
- با استفاده از Index آن، مرجع یک اسلاید را به دست آورید.
- با استفاده از متد [addAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) که توسط شیء [IShapeCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IShapeCollection) ارائه می‌شود، یک AutoShape از نوع Line اضافه کنید.
- ارائهٔ تغییر یافته را به‌عنوان فایل PPTX بنویسید.

در مثال زیر، یک خط به اسلاید اول ارائه افزوده‌ایم.

```java
// نمونه‌سازی کلاس PresentationEx که فایل PPTX را نمایندگی می‌کند
Presentation pres = new Presentation();
try {
    // دریافت اولین اسلاید
    ISlide sld = pres.getSlides().get_Item(0);
    
    // افزودن AutoShape از نوع خط
    sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // نوشتن PPTX بر روی دیسک
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ایجاد یک خط شبیه پیکان**

Aspose.Slides برای Java همچنین به توسعه‌دهندگان امکان می‌دهد برخی از ویژگی‌های خط را تنظیم کنند تا ظاهر جذاب‌تری داشته باشد. بیایید چند ویژگی خط را طوری تنظیم کنیم که شبیه یک پیکان شود. برای انجام این کار مراحل زیر را دنبال کنید:

- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.
- با استفاده از Index آن، مرجع یک اسلاید را به دست آورید.
- با استفاده از متد [addAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) که توسط شیء [IShapeCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IShapeCollection) ارائه می‌شود، یک AutoShape از نوع Line اضافه کنید.
- [Line Style](https://reference.aspose.com/slides/fa/java/com.aspose.slides/LineStyle) را به یکی از سبک‌های ارائه‌شده توسط Aspose.Slides برای Java تنظیم کنید.
- عرض خط را تنظیم کنید.
- [Dash Style](https://reference.aspose.com/slides/fa/java/com.aspose.slides/LineDashStyle) خط را به یکی از سبک‌های ارائه‌شده توسط Aspose.Slides برای Java تنظیم کنید.
- [Arrow Head Style](https://reference.aspose.com/slides/fa/java/com.aspose.slides/LineArrowheadStyle) و [Length](https://reference.aspose.com/slides/fa/java/com.aspose.slides/LineArrowheadLength) نقطهٔ شروع خط را تنظیم کنید.
- [Arrow Head Style](https://reference.aspose.com/slides/fa/java/com.aspose.slides/LineArrowheadStyle) و [Length](https://reference.aspose.com/slides/fa/java/com.aspose.slides/LineArrowheadLength) نقطهٔ پایان خط را تنظیم کنید.
- ارائهٔ تغییر یافته را به‌عنوان فایل PPTX بنویسید.

```java
// نمونه‌سازی کلاس PresentationEx که فایل PPTX را نمایندگی می‌کند
Presentation pres = new Presentation();
try {
    // دریافت اولین اسلاید
    ISlide sld = pres.getSlides().get_Item(0);

    // افزودن AutoShape از نوع خط
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

    // نوشتن PPTX بر روی دیسک
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **سؤالات متداول**

**آیا می‌توانم یک خط معمولی را به یک Connector تبدیل کنم تا به اشکال "چسبانده" شود؟**

خیر. یک خط معمولی (یک [AutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/autoshape/) از نوع [Line](https://reference.aspose.com/slides/fa/java/com.aspose.slides/shapetype/)) به‌صورت خودکار به یک Connector تبدیل نمی‌شود. برای چسباندن به اشکال، از نوع ویژهٔ [Connector](https://reference.aspose.com/slides/fa/java/com.aspose.slides/connector/) و APIهای مرتبط [/slides/fa/java/connector/] استفاده کنید.

**اگر ویژگی‌های یک خط از تم به ارث برده شده باشند و تعیین مقادیر نهایی دشوار باشد، باید چه کاری انجام دهم؟**

[خواندن ویژگی‌های مؤثر](/slides/fa/java/shape-effective-properties/) را از طریق رابط‌های [ILineFormatEffectiveData](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilinefillformateffectivedata/) بخوانید—این‌ها پیشاپیش ارث‌بری و سبک‌های تم را در نظر می‌گیرند.

**آیا می‌توانم یک خط را در مقابل ویرایش (جابه‌جایی، تغییر اندازه) قفل کنم؟**

بله. اشکال [lock objects](https://reference.aspose.com/slides/fa/java/com.aspose.slides/autoshape/#getAutoShapeLock--) را فراهم می‌کنند که به شما اجازه می‌دهد [ممنوع کردن عملیات ویرایشی](/slides/fa/java/applying-protection-to-presentation/) را اعمال کنید.