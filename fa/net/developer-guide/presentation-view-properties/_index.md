---
title: دریافت و به‌روزرسانی ویژگی‌های نمای ارائه در .NET
linktitle: ویژگی‌های نمای
type: docs
weight: 80
url: /fa/net/presentation-view-properties/
keywords:
- ویژگی‌های نمای
- نمای معمولی
- محتوای طرح کلی
- آیکون‌های طرح کلی
- قفل‌سازی تقسیم‌کنندهٔ عمودی
- نمای تک
- وضعیت نوار
- اندازهٔ بُعد
- تنظیم خودکار
- زوم پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "ویژگی‌های نمای Aspose.Slides برای .NET را کشف کنید تا فرمت‌های اسلایدهای PPT، PPTX و ODP را سفارشی‌سازی کنید — چیدمان‌ها، سطوح زوم و تنظیمات نمایش را تنظیم نمایید."
---
## **مقدمه**

نمای معمولی شامل سه ناحیهٔ محتوا است: اسلاید خود، یک ناحیهٔ محتوای جانبی، و یک ناحیهٔ محتوای پایین. ویژگی‌هایی که به موقعیت‌گذاری نواحی مختلف محتوا مربوط می‌شوند. این اطلاعات به برنامه امکان می‌دهد وضعیت نمای خود را در فایل ذخیره کند، به‌طوری‌که هنگام بازگشت، نمایی در همان وضعیت که آخرین بار ارائه ذخیره شده بود داشته باشد.

ویژگی [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/fa/net/aspose.slides/iviewproperties/properties/normalviewproperties) برای دسترسی به ویژگی‌های نمای معمولی ارائه اضافه شده است.

رابط‌های [INormalViewProperties](https://reference.aspose.com/slides/fa/net/aspose.slides/inormalviewproperties)، [INormalViewRestoredProperties](https://reference.aspose.com/slides/fa/net/aspose.slides/inormalviewrestoredproperties) و فرزندان آن، enum [SplitterBarStateType](https://reference.aspose.com/slides/fa/net/aspose.slides/splitterbarstatetype) اضافه شده‌اند.

## **درباره INormalViewProperties**

نمایش‌گر ویژگی‌های نمای معمولی است.

ویژگی **ShowOutlineIcons** تعیین می‌کند آیا برنامه باید در صورت نمایش محتوای طرح کلی در هر یک از نواحی محتوا در حالت نمای معمولی، آیکون‌ها را نشان دهد یا نه.

ویژگی **SnapVerticalSplitter** تعیین می‌کند آیا تقسیم‌کنندهٔ عمودی باید هنگام کوچک بودن کافی ناحیهٔ جانبی به حالت کمینه بپیچد یا خیر.

ویژگی **PreferSingleView** تعیین می‌کند آیا کاربر ترجیح می‌دهد یک ناحیهٔ محتوای تک‌پنجرهٔ تمام‌صفحه را به‌جای نمای معمولی استاندارد با سه ناحیهٔ محتوا ببیند. اگر فعال باشد، برنامه ممکن است یکی از نواحی محتوا را در تمام پنجره نمایش دهد.

ویژگی‌های **VerticalBarState** و **HorizontalBarState** وضعیت نوار تقسیم‌کنندهٔ عمودی یا افقی را تعیین می‌کنند. نوار تقسیم‌کنندهٔ افقی اسلاید را از ناحیهٔ محتوا زیر اسلاید جدا می‌کند و نوار تقسیم‌کنندهٔ عمودی اسلاید را از ناحیهٔ محتوای جانبی جدا می‌کند. مقادیر ممکن عبارتند از: **SplitterBarStateType.Minimized**، **SplitterBarStateType.Maximized** و **SplitterBarStateType.Restored**.

ویژگی‌های **RestoredLeft** و **RestoredTop** اندازه‌گیری ناحیهٔ اسلاید بالایی یا جانبی نمای معمولی را زمانی که مقدار **SplitterBarStateType.Restored** برای **VerticalBarState** و **HorizontalBarState** به‌طور متقابل اعمال شده باشد، مشخص می‌کنند.

## **درباره بازیابی INormalViewProperties**

اندازه‌گیری ناحیهٔ اسلاید (عرض وقتی فرزند RestoredTop است، ارتفاع وقتی فرزند RestoredLeft است) را در نمای معمولی زمانی که ناحیه دارای اندازهٔ متغیر بازیابی شده (نه کمینه و نه بیشینه) باشد، مشخص می‌کند.

ویژگی **DimensionSize** اندازهٔ ناحیهٔ اسلاید (عرض وقتی فرزند restoredTop است، ارتفاع وقتی فرزند restoredLeft است) را تعیین می‌کند.

ویژگی **AutoAdjust** تعیین می‌کند آیا اندازهٔ ناحیهٔ محتوای جانبی باید برای اندازهٔ جدید هنگام تغییر اندازهٔ پنجرهٔ نمایش در برنامه جبران شود یا خیر.

در مثال زیر نحوه دسترسی به ویژگی‌های **ViewProperties.NormalViewProperties** برای یک ارائه نشان داده شده است.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("demo.pptx"))
{
    pres.ViewProperties.NormalViewProperties.HorizontalBarState = SplitterBarStateType.Restored;
    pres.ViewProperties.NormalViewProperties.VerticalBarState = SplitterBarStateType.Maximized;

    // بازگرداندن ویژگی‌های نمای ارائه
    pres.ViewProperties.NormalViewProperties.RestoredTop.AutoAdjust = true;
    pres.ViewProperties.NormalViewProperties.RestoredTop.DimensionSize = 80;
    pres.ViewProperties.NormalViewProperties.ShowOutlineIcons = true;

    pres.Save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
}
```

## **تنظیم مقدار پیش‌فرض زوم**

Aspose.Slides for .NET اکنون از تنظیم مقدار پیش‌فرض زوم برای ارائه پشتیبانی می‌کند به‌طوری‌که هنگام باز کردن ارائه، زوم از پیش تنظیم شده باشد. این کار می‌تواند با تنظیم [ViewProperties](https://reference.aspose.com/slides/fa/net/aspose.slides/viewproperties) یک ارائه انجام شود. ویژگی‌های نمای اسلاید و همچنین [NotesViewProperties](https://reference.aspose.com/slides/fa/net/aspose.slides/viewproperties/properties/notesviewproperties) می‌توانند به‌صورت برنامه‌نویسی تنظیم شوند. در این بخش، با یک مثال می‌بینیم چگونه ویژگی‌های نمای یک ارائه را در Aspose.Slides تنظیم کنیم.

برای تنظیم ویژگی‌های نمای، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید
2. ویژگی‌های نمای [Properties](https://reference.aspose.com/slides/fa/net/aspose.slides/viewproperties) ارائه را تنظیم کنید
3. ارائه را به عنوان فایل PPTX ذخیره کنید

در مثال زیر مقدار زوم برای نمای اسلاید و همچنین نمای یادداشت‌ها تنظیم شده است.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("demo.pptx"))
{
    // تنظیم ویژگی‌های نمای ارائه
    presentation.ViewProperties.SlideViewProperties.Scale = 100; // مقدار زوم بر حسب درصد برای نمای اسلاید
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // مقدار زوم بر حسب درصد برای نمای یادداشت 

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```

## **تنظیم فاصلهٔ شبکه**

از [Presentation.ViewProperties](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/viewproperties/) برای دسترسی به تنظیمات نمای سراسری استفاده کنید. ویژگی [IViewProperties.GridSpacing](https://reference.aspose.com/slides/fa/net/aspose.slides/iviewproperties/gridspacing/) فاصلهٔ شبکهٔ ویرایشی زیرین را می‌خواند یا تغییر می‌دهد. این تنظیم برای کل ارائه اعمال می‌شود، نه برای اسلایدهای فردی. فاصلهٔ شبکه بر حسب پوینت تعیین می‌شود، به‌طوری‌که ۷۲ پوینت معادل یک اینچ است. همان‌طور که مستندات API می‌گوید، مقدار مثبت استفاده کنید.

مثال زیر یک فایل `demo.pptx` موجود را باز می‌کند، فاصلهٔ شبکه فعلی آن را چاپ می‌نماید، فاصلهٔ یک‌چهارم اینچ تنظیم می‌کند و نتیجه را ذخیره می‌کند.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");
var gridSpacing = presentation.ViewProperties.GridSpacing;
Console.WriteLine($"Current grid spacing: {gridSpacing} points");

presentation.ViewProperties.GridSpacing = 18f;
presentation.Save("grid-spacing.pptx", SaveFormat.Pptx);
```

شبکه متفاوت از [drawing guides](/slides/fa/net/drawing-guides/) است. فاصلهٔ شبکه یک بازهٔ منظم را کنترل می‌کند، در حالی که راهنمایی‌های رسم خطوط افقی یا عمودی به‌صورت جداگانه موقعیت‌یابی می‌شوند. افزودن، جابه‌جایی یا حذف راهنمایی‌های رسم، فاصلهٔ شبکه را تغییر نمی‌دهد.

هم شبکه و هم راهنمایی‌های رسم ابزارهای کمکی ویرایشی هستند. آن‌ها به‌عنوان محتوای اسلاید در PDF، تصاویر، SVG یا نمایش اسلاید رندر نمی‌شوند. ذخیرهٔ فاصلهٔ شبکه تضمین نمی‌کند که یک ویرایشگر آن را نمایش دهد: نمایش آن همچنین به تنظیمات نمایشگر یا ویرایشگر وابسته است.

## **سوالات متداول**

**چرا پس از باز کردن مجدد ارائه، شبکه قابل مشاهده نیست؟**

فایل فاصلهٔ شبکه را ذخیره می‌کند، اما ویرایشگر کنترل می‌کند که آیا شبکه نمایش داده شود یا نه. تنظیمات نمایش شبکهٔ ویرایشگر را بررسی کنید.

**آیا حذف راهنمایی‌های رسم فاصلهٔ شبکه را تغییر می‌دهد؟**

نه. راهنمایی‌های رسم و فاصلهٔ شبکه تنظیمات مستقل هستند. حذف راهنمایی‌ها فاصلهٔ شبکه ذخیره‌شده را تغییر نمی‌دهد.

**آیا می‌توان تنظیمات نمای متفاوتی برای بخش‌های مختلف یک ارائه تعریف کرد؟**

[View settings](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/viewproperties/) در سطح ارائه تعریف می‌شوند ([Normal View](https://reference.aspose.com/slides/fa/net/aspose.slides/viewproperties/normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/fa/net/aspose.slides/viewproperties/slideviewproperties/))، نه برای هر بخش. بنابراین یک مجموعهٔ پارامتر برای کل سند هنگام باز شدن اعمال می‌شود.

**آیا می‌توان وضعیت‌های نمای پیش‌تعریف‌شده‌ای برای کاربران مختلف داشته باشم؟**

نه. تنظیمات در فایل ذخیره می‌شوند و به‌صورت مشترک استفاده می‌شوند. برنامه‌های نمایش ممکن است ترجیحات کاربر را اعمال کنند، ولی خود فایل شامل تنها یک مجموعهٔ ویژگی‌های نمای است.

**آیا می‌توان یک قالب با ویژگی‌های نمای پیش‌تعریف‌شده آماده کرد تا ارائه‌های جدید به همان شکل باز شوند؟**

بله. چون [view properties](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/viewproperties/) در سطح ارائه ذخیره می‌شوند، می‌توانید آن‌ها را در یک قالب بگنجانید و اسناد جدید را از آن قالب با همان پیکربندی نمای اولیه ایجاد کنید.