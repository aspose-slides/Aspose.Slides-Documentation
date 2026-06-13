---
title: افزودن اشکال خط به ارائه‌ها در جاوااسکریپت
linktitle: خط
type: docs
weight: 50
url: /fa/nodejs-java/line/
keywords:
- خط
- ایجاد خط
- افزودن خط
- خط ساده
- پیکربندی خط
- سفارشی‌سازی خط
- سبک خط‌چین
- سر پیکان
- پاورپوینت
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "یادگیری دستکاری فرمت‌بندی خط در ارائه‌های پاورپوینت با جاوااسکریپت و Aspose.Slides برای Node.js. کشف ویژگی‌ها، متدها و مثال‌ها."
---
## **بررسی اجمالی**

Aspose.Slides به شما امکان می‌دهد تا اشکال خطی را به صورت برنامه‌نویسی به اسلایدهای PowerPoint اضافه کنید. این مقاله نشان می‌دهد چگونه یک خط ساده ایجاد کنید و چگونه یک خط را سفارشی کنید تا به شکل پیکان ظاهر شود.

شما یاد خواهید گرفت چگونه یک شکل خطی را به یک اسلاید اضافه کنید، ظاهر بصری آن را تنظیم کنید و ارائه به‌روز شده را ذخیره کنید. مثال‌ها بر تنظیمات کاربردی فرمت‌بندی خط مانند سبک، عرض، الگوی خط‌چین، گزینه‌های سرپیکان و رنگ پر تمرکز دارند.

## **ایجاد خط ساده**

برای اضافه کردن یک خط ساده به اسلاید انتخاب‌شدهٔ ارائه، لطفاً مراحل زیر را دنبال کنید:

- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.
- با استفاده از اندیس آن، مرجع یک اسلاید را به دست آورید.
- یک AutoShape از نوع Line را با استفاده از متد [addAutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) که توسط شیء [ShapeCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ShapeCollection) فراهم شده، اضافه کنید.
- ارائهٔ اصلاح‌شده را به‌صورت فایل PPTX بنویسید.

در مثال زیر، ما یک خط به اولین اسلاید ارائه اضافه کرده‌ایم.

```javascript
// یک نمونه از کلاس PresentationEx که نمایانگر فایل PPTX است
var pres = new aspose.slides.Presentation();
try {
    // دریافت اولین اسلاید
    var sld = pres.getSlides().get_Item(0);
    // افزودن AutoShape از نوع خط
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    // نوشتن فایل PPTX بر روی دیسک
    pres.save("LineShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **ایجاد خط به شکل پیکان**

Aspose.Slides برای Node.js از طریق Java همچنین به توسعه‌دهندگان امکان می‌دهد برخی از خصوصیات خط را تنظیم کنند تا ظاهر جذاب‌تری داشته باشد. بیایید چند ویژگی از خط را تنظیم کنیم تا به شکل پیکان درآید. لطفاً برای این کار مراحل زیر را دنبال کنید:

- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.
- با استفاده از اندیس آن، مرجع یک اسلاید را به دست آورید.
- یک AutoShape از نوع Line را با استفاده از متد [addAutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) که توسط شیء [ShapeCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ShapeCollection) فراهم شده، اضافه کنید.
- سبک [Line Style](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/LineStyle) را به یکی از سبک‌هایی که Aspose.Slides برای Node.js از طریق Java ارائه می‌دهد، تنظیم کنید.
- عرض خط را تنظیم کنید.
- سبک [Dash Style](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/LineDashStyle) خط را به یکی از سبک‌هایی که Aspose.Slides برای Node.js از طریق Java ارائه می‌دهد، تنظیم کنید.
- سبک [Arrow Head Style](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/LineArrowheadStyle) و [Length](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/LineArrowheadLength) نقطهٔ شروع خط را تنظیم کنید.
- سبک [Arrow Head Style](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/LineArrowheadStyle) و [Length](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/LineArrowheadLength) نقطهٔ انتهای خط را تنظیم کنید.
- ارائهٔ اصلاح‌شده را به‌صورت فایل PPTX بنویسید.

```javascript
// یک نمونه از کلاس PresentationEx که نمایانگر فایل PPTX است
var pres = new aspose.slides.Presentation();
try {
    // دریافت اولین اسلاید
    var sld = pres.getSlides().get_Item(0);
    // افزودن AutoShape از نوع خط
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    // اعمال برخی فرمت‌بندی‌ها بر روی خط
    shp.getLineFormat().setStyle(aspose.slides.LineStyle.ThickBetweenThin);
    shp.getLineFormat().setWidth(10);
    shp.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    shp.getLineFormat().setBeginArrowheadLength(aspose.slides.LineArrowheadLength.Short);
    shp.getLineFormat().setBeginArrowheadStyle(aspose.slides.LineArrowheadStyle.Oval);
    shp.getLineFormat().setEndArrowheadLength(aspose.slides.LineArrowheadLength.Long);
    shp.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
    shp.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.Maroon));
    // نوشتن فایل PPTX بر روی دیسک
    pres.save("LineShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **سؤالات متداول**

**آیا می‌توانم یک خط معمولی را به کانکتور تبدیل کنم تا به اشکال «چسبیده» شود؟**

خیر. یک خط معمولی (یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) از نوع [Line](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shapetype/)) به طور خودکار به کانکتور تبدیل نمی‌شود. برای چسباندن آن به اشکال، از نوع اختصاصی [Connector](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/connector/) و [corresponding APIs](/slides/fa/nodejs-java/connector/) استفاده کنید.

**اگر ویژگی‌های یک خط از تم به ارث برده شده باشد و تعیین مقادیر نهایی دشوار باشد، چه کاری باید انجام دهم؟**

[Read the effective properties](/slides/fa/nodejs-java/shape-effective-properties/) از طریق کلاس‌های `ILineFormatEffectiveData`/`ILineFillFormatEffectiveData`—این کلاس‌ها پیشاپیش ارث‌بری و سبک‌های تم را در نظر می‌گیرند.

**آیا می‌توانم خط را در برابر ویرایش (جابه‌جایی، تغییر اندازه) قفل کنم؟**

بله. اشکال [lock objects](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/getautoshapelock/) ارائه می‌دهند که امکان جلوگیری از عملیات ویرایشی را به شما می‌دهند.