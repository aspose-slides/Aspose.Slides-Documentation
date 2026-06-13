---
title: اضافه کردن اشکال خط به ارائه‌ها در .NET
linktitle: خط
type: docs
weight: 50
url: /fa/net/Line/
keywords:
- خط
- ایجاد خط
- افزودن خط
- خط ساده
- پیکربندی خط
- سفارشی‌سازی خط
- سبک خط تیره
- سرپیکان
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "یاد بگیرید چگونه قالب‌بندی خطوط را در ارائه‌های PowerPoint با Aspose.Slides برای .NET مدیریت کنید. ویژگی‌ها، متدها و نمونه‌ها را کشف کنید."
---
## **نمای کلی**

Aspose.Slides به شما امکان می‌دهد تا اشکال خطی را به صورت برنامه‌نویسی به اسلایدهای PowerPoint اضافه کنید. این مقاله نشان می‌دهد چگونه یک خط ساده ایجاد کنید و چگونه یک خط را سفارشی کنید تا به شکل یک پیکان ظاهر شود.

شما یاد خواهید گرفت چگونه یک شکل خطی را به یک اسلاید اضافه کنید، ظاهر بصری آن را تنظیم کنید و ارائه به‌روزشده را ذخیره کنید. مثال‌ها بر تنظیمات عملی فرمت‌گذاری خط مانند سبک، عرض، الگوی خط تیره، گزینه‌های سرپیکان و رنگ پرش تمرکز دارند.

## **ایجاد یک خط ساده**
برای افزودن یک خط ساده به اسلاید انتخابی ارائه، لطفاً مراحل زیر را دنبال کنید:

- یک نمونه از کلاس [Presentation ](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.
- با استفاده از اندیس (Index) آن، مرجع اسلاید را به دست آورید.
- با استفاده از متد [AddAutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/ishapecollection/methods/addautoshape/index) که توسط شیء Shapes ارائه می‌شود، یک AutoShape از نوع Line اضافه کنید.
- نمایش اصلاح‌شده را به صورت فایل PPTX ذخیره کنید.

در مثال زیر، ما یک خط به اولین اسلاید ارائه اضافه کرده‌ایم.

```c#
// ایجاد یک نمونه از کلاس PresentationEx که نمایانگر فایل PPTX است
using (Presentation pres = new Presentation())
{
    // دریافت اولین اسلاید
    ISlide sld = pres.Slides[0];

    // افزودن یک AutoShape از نوع خط
    sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // ذخیرهٔ PPTX در دیسک
    pres.Save("LineShape1_out.pptx", SaveFormat.Pptx);
}
```

## **ایجاد یک خط به شکل پیکان**
Aspose.Slides برای .NET همچنین به توسعه‌دهندگان امکان پیکربندی برخی از ویژگی‌های خط را می‌دهد تا ظاهر جذاب‌تری داشته باشد. بیایید چند ویژگی از خط را تنظیم کنیم تا شبیه یک پیکان باشد. لطفاً مراحل زیر را برای انجام این کار دنبال کنید:

- یک نمونه از [Presentation ](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation)class[](http://www.aspose.com/api/net/slides/fa/aspose.slides/)[](http://www.aspose.com/api/net/slides/fa/aspose.slides/).
- با استفاده از اندیس (Index) آن، مرجع اسلاید را به دست آورید.
- یک AutoShape از نوع Line را با استفاده از متد AddAutoShape که توسط شیء Shapes ارائه می‌شود، اضافه کنید.
- سبک خط (Line Style) را بر یکی از سبک‌های ارائه‌شده توسط Aspose.Slides برای .NET تنظیم کنید.
- عرض خط را تنظیم کنید.
- [Dash Style](https://reference.aspose.com/slides/fa/net/aspose.slides/linedashstyle) خط را بر یکی از سبک‌های ارائه‌شده توسط Aspose.Slides برای .NET تنظیم کنید.
- [Arrow Head Style](https://reference.aspose.com/slides/fa/net/aspose.slides/linearrowheadstyle) و طول نقطه شروع خط را تنظیم کنید.
- سبک سرپیکان (Arrow Head Style) و طول نقطه انتهایی خط را تنظیم کنید.
- نمایش اصلاح‌شده را به صورت فایل PPTX ذخیره کنید.

```c#
// ایجاد یک نمونه از کلاس PresentationEx که نمایانگر فایل PPTX است
using (Presentation pres = new Presentation())
{

    // دریافت اولین اسلاید
    ISlide sld = pres.Slides[0];

    // افزودن یک autoshape از نوع line
    IAutoShape shp = sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // اعمال برخی قالب‌بندی‌ها روی خط
    shp.LineFormat.Style = LineStyle.ThickBetweenThin;
    shp.LineFormat.Width = 10;

    shp.LineFormat.DashStyle = LineDashStyle.DashDot;

    shp.LineFormat.BeginArrowheadLength = LineArrowheadLength.Short;
    shp.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.Oval;

    shp.LineFormat.EndArrowheadLength = LineArrowheadLength.Long;
    shp.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;

    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Maroon;

    //ذخیرهٔ PPTX در دیسک
    pres.Save("LineShape2_out.pptx", SaveFormat.Pptx);
}
```

## **سوالات متداول**

**آیا می‌توانم یک خط معمولی را به یک اتصال کننده (Connector) تبدیل کنم تا به اشکال «چسبیده» شود؟**

خیر. یک خط معمولی (یک [AutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/autoshape/) از نوع [Line](https://reference.aspose.com/slides/fa/net/aspose.slides/shapetype/)) به‌صورت خودکار به یک اتصال کننده تبدیل نمی‌شود. برای اینکه به اشکال بچسبد، از نوع اختصاصی [Connector](https://reference.aspose.com/slides/fa/net/aspose.slides/connector/) و [APIهای مربوطه](/slides/fa/net/connector/) استفاده کنید.

**اگر خواص یک خط از تم به ارث برده شده باشد و تعیین مقادیر نهایی دشوار باشد، چه کاری باید انجام دهم؟**

[Read the effective properties](/slides/fa/net/shape-effective-properties/) از طریق اینترفیس‌های [ILineFormatEffectiveData](https://reference.aspose.com/slides/fa/net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/fa/net/aspose.slides/ilinefillformateffectivedata/) — اینها قبلاً ارث‌بری و سبک‌های تم را در نظر می‌گیرند.

**آیا می‌توانم یک خط را در مقابل ویرایش (جابه‌جایی، تغییر اندازه) قفل کنم؟**

بله. اشکال [lock objects](https://reference.aspose.com/slides/fa/net/aspose.slides/autoshape/autoshapelock/) ارائه می‌دهند که به شما اجازه می‌دهند [عملیات ویرایشی را ممنوع کنید](/slides/fa/net/applying-protection-to-presentation/).