---
title: دریافت و به‌روزرسانی خصوصیات نمای ارائه در .NET
linktitle: خصوصیات نمای
type: docs
weight: 80
url: /fa/net/presentation-view-properties/
keywords:
- خصوصیات نمای
- نمای عادی
- محتوای طرح کلی
- آیکون‌های طرح کلی
- قفل تقسیم‌گر عمودی
- نمای تک‌پنجره‌ای
- وضعیت نوار
- اندازه بُعد
- تنظیم خودکار
- بزرگنمایی پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "ویژگی‌های نمای Aspose.Slides برای .NET را کشف کنید تا فرمت‌های اسلاید PPT، PPTX و ODP را سفارشی‌سازی کنید—چیدمان‌ها، سطوح بزرگنمایی و تنظیمات نمایش را تنظیم کنید."
---
## **مقدمه**

نمای عادی شامل سه ناحیهٔ محتوا است: اسلاید خودش، ناحیهٔ محتوا در سمت و ناحیهٔ محتوا در پایین. خصوصیات مربوط به موقعیت دهی این نواحی محتوا. این اطلاعات به برنامه اجازه می‌دهد حالت نمای خود را در فایل ذخیره کند، به‌طوری که هنگام باز کردن دوباره، نمای همان حالت را داشته باشد که آخرین بار ذخیره شده بود.

خاصیت [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/fa/net/aspose.slides/iviewproperties/properties/normalviewproperties) برای دسترسی به خصوصیات نمای عادی ارائه شده است.  

[INormalViewProperties](https://reference.aspose.com/slides/fa/net/aspose.slides/inormalviewproperties)، [INormalViewRestoredProperties](https://reference.aspose.com/slides/fa/net/aspose.slides/inormalviewrestoredproperties) و انواع مشتق‌شدهٔ آن‌ها، همچنین شمارندهٔ [SplitterBarStateType](https://reference.aspose.com/slides/fa/net/aspose.slides/splitterbarstatetype) اضافه شده‌اند.

## **درباره INormalViewProperties**

نمایش‌دهندهٔ ویژگی‌های نمای عادی است.

خاصیت **ShowOutlineIcons** تعیین می‌کند که آیا برنامه باید در حالت نمای عادی، اگر محتوای طرح کلی در هر یک از نواحی محتوا نمایش داده شود، آیکون‌ها را نشان دهد یا نه.

خاصیت **SnapVerticalSplitter** تعیین می‌کند که آیا تقسیم‌گر عمودی هنگام کوچک شدن کافی ناحیهٔ جانبی به حالت کمینه «سنب» شود یا خیر.

خاصیت **PreferSingleView** مشخص می‌کند که آیا کاربر ترجیح می‌دهد یک ناحیهٔ محتوای تک‌پنجره‌ای تمام‑صفحه را به جای نمای عادی استاندارد با سه ناحیه محتوا ببیند. اگر فعال باشد، برنامه می‌تواند یک ناحیهٔ محتوا را در تمام پنجره نمایش دهد.

خاصیت‌های **VerticalBarState** و **HorizontalBarState** تعیین می‌کنند که نوار تقسیم‌گر عمودی یا افقی در چه وضعیتی نشان داده شود. نوار تقسیم‌گر افقی اسلاید را از ناحیهٔ محتوا زیر اسلاید جدا می‌کند، نوار تقسیم‌گر عمودی اسلاید را از ناحیهٔ محتوا جانبی جدا می‌کند. مقادیر ممکن عبارتند از: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** و **SplitterBarStateType.Restored**.

خاصیت‌های **RestoredLeft** و **RestoredTop** اندازه‌گیری ناحیهٔ بالایی یا جانبی اسلاید در نمای عادی را مشخص می‌کنند، هنگامی که مقدار **SplitterBarStateType.Restored** برای **VerticalBarState** و **HorizontalBarState** به‌طور مقتضی اعمال شده باشد.

## **درباره بازگردانی INormalViewProperties**

اندازه‌گیری ناحیهٔ اسلاید (عرض وقتی فرزند RestoredTop باشد، ارتفاع وقتی فرزند RestoredLeft باشد) در نمای عادی را زمانی که ناحیه دارای اندازهٔ متغیر بازگردانی (نه کمینه نه حداکثر) باشد، مشخص می‌کند.

خاصیت **DimensionSize** اندازهٔ ناحیهٔ اسلاید (عرض وقتی فرزند restoredTop باشد، ارتفاع وقتی فرزند restoredLeft باشد) را تعیین می‌کند.

خاصیت **AutoAdjust** مشخص می‌کند که آیا ناحیهٔ محتوا جانبی باید برای اندازهٔ جدید هنگام تغییر اندازهٔ پنجرهٔ حاوی نمای داخل برنامه جبران کند یا نه.

یک مثال در زیر نشان می‌دهد چگونه می‌توانید به خصوصیات **ViewProperties.NormalViewProperties** برای یک ارائه دسترسی پیدا کنید.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("demo.pptx"))
{
    pres.ViewProperties.NormalViewProperties.HorizontalBarState = SplitterBarStateType.Restored;
    pres.ViewProperties.NormalViewProperties.VerticalBarState = SplitterBarStateType.Maximized;

    // بازگرداندن خصوصیات نمای ارائه
    pres.ViewProperties.NormalViewProperties.RestoredTop.AutoAdjust = true;
    pres.ViewProperties.NormalViewProperties.RestoredTop.DimensionSize = 80;
    pres.ViewProperties.NormalViewProperties.ShowOutlineIcons = true;

    pres.Save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
}
```

## **تنظیم مقدار پیش‌فرض بزرگنمایی**

Aspose.Slides برای .NET هم‌اکنون از تنظیم مقدار پیش‌فرض بزرگنمایی برای ارائه پشتیبانی می‌کند به‌طوری که هنگام باز کردن ارائه، بزرگنمایی قبلاً تنظیم شده باشد. این کار می‌تواند با تنظیم [ViewProperties](https://reference.aspose.com/slides/fa/net/aspose.slides/viewproperties) یک ارائه انجام شود. خصوصیات نمای اسلاید و همچنین [NotesViewProperties](https://reference.aspose.com/slides/fa/net/aspose.slides/viewproperties/properties/notesviewproperties) می‌توانند برنامه‌نویسی شوند. در این بخش، با یک مثال می‌بینیم چگونه خصوصیات نمای یک ارائه را در Aspose.Slides تنظیم کنیم.

برای تنظیم خصوصیات نمای، مراحل زیر را دنبال کنید:

1. ایجاد یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation)
1. تنظیم [Properties](https://reference.aspose.com/slides/fa/net/aspose.slides/viewproperties) نمای ارائه
1. نوشتن ارائه به‌صورت فایل PPTX

در مثال زیر، مقدار بزرگنمایی برای نمای اسلاید و همچنین نمای یادداشت‌ها تنظیم شده است.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("demo.pptx"))
{
    // تنظیم خصوصیات نمای ارائه
    presentation.ViewProperties.SlideViewProperties.Scale = 100; // مقدار بزرگنمایی به درصد برای نمای اسلاید
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // مقدار بزرگنمایی به درصد برای نمای یادداشت‌ها 

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```

## **تنظیم فاصله‌بندی شبکه (Grid Spacing)**

از [Presentation.ViewProperties](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/viewproperties/) برای دسترسی به تنظیمات نمای سراسری ارائه استفاده کنید. خاصیت [IViewProperties.GridSpacing](https://reference.aspose.com/slides/fa/net/aspose.slides/iviewproperties/gridspacing/) فاصلهٔ شبکهٔ ویرایشی زیرین را می‌خواند یا تغییر می‌دهد. این تنظیم برای تمام ارائه اعمال می‌شود، نه برای یک اسلاید خاص. فاصلهٔ شبکه بر حسب نقطه (point) تعریف می‌شود، به‌طوری که ۷۲ نقطه برابر یک اینچ است. از مقدار مثبت استفاده کنید، همان‌طور که مستندات API درخواست می‌کند.

مثال زیر یک فایل `demo.pptx` موجود را باز می‌کند، فاصلهٔ فعلی شبکه را چاپ می‌کند، فاصلهٔ یک‌چهارم اینچ تنظیم می‌کند و سپس نتیجه را ذخیره می‌نماید.

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

شبکه متفاوت از [راهنماهای کشیدن (drawing guides)](/slides/fa/net/drawing-guides/) است. فاصلهٔ شبکه یک بازهٔ منظم را کنترل می‌کند، در حالی که راهنماهای کشیدن خطوط افقی یا عمودی موقعیتی جداگانه دارند. افزودن، جابجا یا حذف راهنماهای کشیدن فاصلهٔ شبکه را تغییر نمی‌دهد.

هر دو، شبکه و راهنماهای کشیدن، ابزارهای کمکی ویرایشی هستند. آنها به‌عنوان محتوای اسلاید در PDF، تصاویر، SVG یا نمایش اسلاید رندر نمی‌شوند. ذخیرهٔ فاصلهٔ شبکه تضمین نمی‌کند که ویرایشگر آن را نشان دهد: نمایش آن نیز به تنظیمات نمایشگر یا ویرایشگر بستگی دارد.

## **نمایش یا مخفی‌سازی نظرات هنگام باز کردن ارائه**

از [Presentation.ViewProperties](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/viewproperties/) برای دسترسی به تنظیمات نمای سراسری ارائه استفاده کنید. خاصیت [IViewProperties.ShowComments](https://reference.aspose.com/slides/fa/net/aspose.slides/iviewproperties/showcomments/) را بخوانید یا تغییر دهید تا ترجیح ذخیره شود که آیا نظرات هنگام باز شدن ارائه در PowerPoint یا ویرایشگر سازگار دیگر نشان داده شوند یا نه.

این تنظیم فقط ترجیح نمای ذخیره‌شده را کنترل می‌کند. این کار نظرات را اضافه، حذف، ویرایش یا حل نمی‌کند. مخفی‌سازی نظرات محتوای آن‌ها، نویسندگان، موقعیت‌ها، پاسخ‌ها و وضعیت‌ها را حفظ می‌کند. برای عملیات‌های تغییر نظرات به [نظرات ارائه](/slides/fa/net/presentation-comments/) مراجعه کنید.

مثال زیر به فایل `comments.pptx` موجود که شامل نظرات است نیاز دارد. تنظیمات فعلی قابلیت مشاهده نظرات را چاپ می‌کند، درخواست مخفی‌سازی نظرات را انجام می‌دهد و یک PPTX جدید بدون حذف نظرات ذخیره می‌کند. همچنین [IViewProperties.LastView](https://reference.aspose.com/slides/fa/net/aspose.slides/iviewproperties/lastview/) را به [ViewType.SlideView](https://reference.aspose.com/slides/fa/net/aspose.slides/viewtype/) تنظیم می‌کند تا نمای ویرایشی اولیه همراه با قابلیت مشاهده نظرات پیکربندی شود.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("comments.pptx");
var showComments = presentation.ViewProperties.ShowComments;
Console.WriteLine($"Current comment visibility: {showComments}");

presentation.ViewProperties.ShowComments = NullableBool.False;
presentation.ViewProperties.LastView = ViewType.SlideView;
presentation.Save("comments-hidden.pptx", SaveFormat.Pptx);
```

این تنظیم تعیین نمی‌کند که آیا نظرات در خروجی‌های PDF، HTML، تصویر، یادداشت یا برگه‌های چاپی گنجانده شوند. گزینه‌های مخصوص هر نوع خروجی را به‌صورت جداگانه پیکربندی کنید.

## **سوالات متداول**

**چرا پس از باز کردن دوبارهٔ ارائه، شبکه قابل مشاهده نیست؟**

فایل فاصلهٔ شبکه را ذخیره می‌کند، اما ویرایشگر تصمیم می‌گیرد که آیا شبکه نمایش داده شود یا نه. تنظیمات نمایش شبکه در ویرایشگر را بررسی کنید.

**آیا پاک کردن راهنماهای کشیدن، فاصلهٔ شبکه را تغییر می‌دهد؟**

نه. راهنماهای کشیدن و فاصلهٔ شبکه تنظیمات مستقلی هستند. حذف راهنماها فاصلهٔ ذخیره‌شدهٔ شبکه را تغییر نمی‌دهد.

**آیا می‌توان تنظیمات نمای متفاوتی برای بخش‌های مختلف یک ارائه تعیین کرد؟**

[تنظیمات نمای](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/viewproperties/) در سطح ارائه تعریف می‌شوند ([Normal View](https://reference.aspose.com/slides/fa/net/aspose.slides/viewproperties/normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/fa/net/aspose.slides/viewproperties/slideviewproperties/))، نه برای هر بخش. بنابراین یک مجموعهٔ پارامتر برای تمام سند هنگام باز شدن اعمال می‌شود.

**آیا می‌توان حالت‌های نمای مختلفی را برای کاربران مختلف از پیش تعریف کرد؟**

نه. این تنظیمات در فایل ذخیره می‌شوند و برای همهٔ کاربران یکسان هستند. برنامه‌های مشاهده ممکن است ترجیحات کاربر را اعمال کنند، اما خود فایل فقط یک مجموعهٔ خصوصیات نمای دارد.

**آیا می‌توان قالبی با خصوصیات نمای از پیش تعریف‌شده آماده کرد تا ارائه‌های جدید به همان شکل باز شوند؟**

بله. چون [خصوصیات نمای](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/viewproperties/) در سطح ارائه ذخیره می‌شوند، می‌توانید آن‌ها را در یک قالب بگنجانید و اسناد جدید را از آن قالب ایجاد کنید تا پیکربندی نمای اولیه یکسان باشد.