---
title: اضافه کردن شکل‌های خط به ارائه‌ها در .NET
linktitle: خط
type: docs
weight: 50
url: /fa/net/line/
keywords:
- خط
- ایجاد خط
- اضافه کردن خط
- خط ساده
- پیکربندی خط
- سفارشی‌سازی خط
- سبک خط‌چکدار
- سر پیکان
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "یاد بگیرید چگونه قالب‌بندی خطوط را در ارائه‌های PowerPoint با Aspose.Slides برای .NET دستکاری کنید. ویژگی‌ها، متدها و مثال‌ها را کشف کنید."
---
## **بررسی کلی**

Aspose.Slides به شما اجازه می‌دهد تا شکل‌های خط را به صورت برنامه‌نویسی به اسلایدهای PowerPoint اضافه کنید. این مقاله نشان می‌دهد چگونه یک خط ساده ایجاد کرده و چگونه یک خط را سفارشی کنید تا به صورت یک پیکان ظاهر شود.

شما یاد خواهید گرفت چگونه یک شکل خط را به یک اسلاید اضافه کنید، ظاهر بصری آن را تنظیم کنید و ارائه به‌روز شده را ذخیره نمایید. مثال‌ها بر تنظیمات کاربردی قالب‌بندی خط مانند سبک، عرض، الگوی خط‌شکسته، گزینه‌های سر پیکان و رنگ پرکردن متمرکز هستند.

## **ایجاد یک خط ساده**

برای اضافه کردن یک خط ساده ساده به اسلاید انتخاب‌شده‌ای از ارائه، لطفاً مراحل زیر را دنبال کنید:

- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.
- با استفاده از Index اسلاید، ارجاع آن را به دست آورید.
- با استفاده از متد [AddAutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/ishapecollection/methods/addautoshape/index) که توسط شی Shapes ارائه می‌شود، یک AutoShape از نوع Line اضافه کنید.
- ارائهٔ تغییر یافته را به‌صورت فایل PPTX ذخیره کنید.

در مثال زیر، ما یک خط را به اولین اسلاید ارائه اضافه کرده‌ایم.

```c#
// نمونه‌سازی کلاس PresentationEx که نمایانگر فایل PPTX است
using (Presentation pres = new Presentation())
{
    // دریافت اولین اسلاید
    ISlide sld = pres.Slides[0];

    // افزودن یک autoshape از نوع خط
    sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    //نوشتن فایل PPTX به دیسک
    pres.Save("LineShape1_out.pptx", SaveFormat.Pptx);
}
```

## **ایجاد خط به شکل پیکان**

Aspose.Slides برای .NET همچنین به توسعه‌دهندگان امکان می‌دهد تا برخی از خصوصیات خط را تنظیم کنند تا ظاهر جذاب‌تری داشته باشد. بیایید چند خصوصیت خط را تنظیم کنیم تا شبیه یک پیکان باشد. لطفاً مراحل زیر را برای انجام این کار دنبال کنید:

- یک نمونه از [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation)class[] (http://www.aspose.com/api/net/slides/fa/aspose.slides/)[] (http://www.aspose.com/api/net/slides/fa/aspose.slides/).
- با استفاده از Index اسلاید، ارجاع آن را به دست آورید.
- با استفاده از متد AddAutoShape که توسط شی Shapes ارائه می‌شود، یک AutoShape از نوع Line اضافه کنید.
- سبک Line را به یکی از سبک‌هایی که توسط Aspose.Slides برای .NET ارائه می‌شود تنظیم کنید.
- عرض خط را تنظیم کنید.
- [Dash Style](https://reference.aspose.com/slides/fa/net/aspose.slides/linedashstyle) خط را به یکی از سبک‌های ارائه‌شده توسط Aspose.Slides برای .NET تنظیم کنید.
- [Arrow Head Style](https://reference.aspose.com/slides/fa/net/aspose.slides/linearrowheadstyle) و طول نقطهٔ شروع خط را تنظیم کنید.
- سبک سر پیکان و طول نقطهٔ انتهای خط را تنظیم کنید.
- ارائهٔ تغییر یافته را به‌صورت فایل PPTX ذخیره کنید.

```c#
// نمونه‌سازی کلاس PresentationEx که نمایانگر فایل PPTX است
using (Presentation pres = new Presentation())
{

    // دریافت اولین اسلاید
    ISlide sld = pres.Slides[0];

    // افزودن یک autoshape از نوع خط
    IAutoShape shp = sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // اعمال برخی قالب‌بندی‌ها بر روی خط
    shp.LineFormat.Style = LineStyle.ThickBetweenThin;
    shp.LineFormat.Width = 10;

    shp.LineFormat.DashStyle = LineDashStyle.DashDot;

    shp.LineFormat.BeginArrowheadLength = LineArrowheadLength.Short;
    shp.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.Oval;

    shp.LineFormat.EndArrowheadLength = LineArrowheadLength.Long;
    shp.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;

    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Maroon;

    // نوشتن فایل PPTX به دیسک
    pres.Save("LineShape2_out.pptx", SaveFormat.Pptx);
}
```

## **پرسش‌های متداول**

**آیا می‌توانم یک خط معمولی را به یک کانکتور تبدیل کنم تا به اشکال «چسبیده» باشد؟**

خیر. یک خط معمولی (یک [AutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/autoshape/) از نوع [Line](https://reference.aspose.com/slides/fa/net/aspose.slides/shapetype/)) به‌طور خودکار به یک connector تبدیل نمی‌شود. برای این‌که به اشکال چسبیده شود، از نوع اختصاصی [Connector](https://reference.aspose.com/slides/fa/net/aspose.slides/connector/) و [APIهای مربوطه](/slides/fa/net/connector/) برای اتصال‌ها استفاده کنید.

**اگر خصوصیات یک خط از تم ارث‌بری شود و تعیین مقادیر نهایی دشوار باشد، چه کاری باید انجام دهم؟**

[خواندن خصوصیات مؤثر](/slides/fa/net/shape-effective-properties/) از طریق رابط‌های [ILineFormatEffectiveData](https://reference.aspose.com/slides/fa/net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/fa/net/aspose.slides/ilinefillformateffectivedata/) بخوانید — این‌ها پیش از پیش وراثت و سبک‌های تم را در نظر می‌گیرند.

**آیا می‌توانم یک خط را علیه ویرایش (جابه‌جایی، تغییر اندازه) قفل کنم؟**

بله. Shapes [قفل‌شی‌ها](https://reference.aspose.com/slides/fa/net/aspose.slides/autoshape/autoshapelock/) را ارائه می‌دهند که به شما امکان [ممنوع کردن عملیات ویرایشی](/slides/fa/net/applying-protection-to-presentation/) را می‌دهد.