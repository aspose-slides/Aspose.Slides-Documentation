---
title: دریافت و به‌روزرسانی ویژگی‌های نمایش ارائه در .NET
linktitle: ویژگی‌های نمایش
type: docs
weight: 80
url: /fa/net/presentation-view-properties/
keywords:
- ویژگی‌های نمایش
- نمای عادی
- محتوای طرح کلی
- آیکون‌های طرح کلی
- قابلیت چسباندن تقسیم‌کننده عمودی
- نمای تک
- وضعیت نوار
- اندازهٔ بُعد
- تنظیم خودکار
- بزرگنمایی پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "ویژگی‌های نمایش Aspose.Slides برای .NET را کشف کنید تا فرمت‌های اسلاید PPT، PPTX و ODP را سفارشی کنید—چیدمان‌ها، سطوح بزرگنمایی و تنظیمات نمایش را تنظیم نمایید."
---
## **مقدمه**

نمای عادی شامل سه ناحیه محتوا است: خود اسلاید، یک ناحیه محتوا کناری، و یک ناحیه محتوا پایین. ویژگی‌هایی که مربوط به موقعیت‌گذاری نواحی مختلف محتوا هستند. این اطلاعات به برنامه اجازه می‌دهد حالت نمایش را در فایل ذخیره کند، به طوری که هنگام بازگشایی دوباره، نمایش در همان وضعیتی باشد که آخرین بار ارائه ذخیره شده بود.

ویژگی [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/fa/net/aspose.slides/iviewproperties/properties/normalviewproperties) اضافه شده است تا دسترسی به ویژگی‌های نمای عادی ارائه را فراهم کند.

رابط‌های [INormalViewProperties](https://reference.aspose.com/slides/fa/net/aspose.slides/inormalviewproperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/fa/net/aspose.slides/inormalviewrestoredproperties) و فرزندان آن‌ها، همچنین شمارش‌گر [SplitterBarStateType](https://reference.aspose.com/slides/fa/net/aspose.slides/splitterbarstatetype) اضافه شده‌اند.

## **درباره INormalViewProperties**

نمایانگر ویژگی‌های نمای عادی است.

ویژگی **ShowOutlineIcons** مشخص می‌کند که آیا برنامه باید هنگام نمایش محتوای طرح کلی در هر یک از نواحی محتوا در حالت نمای عادی، آیکون‌ها را نشان دهد یا نه.

ویژگی **SnapVerticalSplitter** مشخص می‌کند که آیا تقسیم‌کننده عمودی باید هنگامی که ناحیه کناری به اندازه‌ای کوچک باشد، به حالت کمینه (minimized) بچسبد یا نه.

ویژگی **PreferSingleView** مشخص می‌کند که آیا کاربر ترجیح می‌دهد یک ناحیه محتوا تک‌پنجره‌ای تمام‑پنجره نمایش داده شود به جای حالت نمای عادی استاندارد با سه ناحیه محتوا. اگر فعال باشد، برنامه می‌تواند یکی از نواحی محتوا را در کل پنجره نمایش دهد.

ویژگی‌های **VerticalBarState** و **HorizontalBarState** حالت نشان‌دادن نوار تقسیم‌کننده عمودی یا افقی را تعیین می‌کنند. یک نوار تقسیم‌کننده افقی اسلاید را از ناحیه محتوا زیر اسلاید جدا می‌کند، نوار تقسیم‌کننده عمودی اسلاید را از ناحیه محتوا کناری جدا می‌کند. مقادیر ممکن عبارتند از: **SplitterBarStateType.Minimized**, **SplitterBarStateType.Maximized** و **SplitterBarStateType.Restored**.

ویژگی‌های **RestoredLeft** و **RestoredTop** اندازه‌گذاری ناحیه اسلاید بالایی یا کناری نمای عادی را زمانی که مقدار **SplitterBarStateType.Restored** برای **VerticalBarState** و **HorizontalBarState** به‌صورت متقابل اعمال شده باشد، مشخص می‌کنند.

## **درباره بازیابی INormalViewProperties**

اندازه‌گذاری ناحیه اسلاید (عرض وقتی فرزند RestoredTop است، ارتفاع وقتی فرزند RestoredLeft است) در نمای عادی را زمانی که ناحیه دارای اندازه متغیر بازگردانده شده (نه کمینه نه بیشینه) باشد، مشخص می‌کند.

ویژگی **DimensionSize** اندازه ناحیه اسلاید (عرض وقتی فرزند restoredTop است، ارتفاع وقتی فرزند restoredLeft است) را تعیین می‌کند.

ویژگی **AutoAdjust** مشخص می‌کند که آیا اندازه ناحیه محتوای کناری باید برای اندازه جدید جبران شود وقتی که پنجره حاوی نمایش در برنامه تغییر اندازه می‌دهد.

مثالی که در زیر آورده شده است نشان می‌دهد چطور می‌توانید به ویژگی‌های **ViewProperties.NormalViewProperties** برای یک ارائه دسترسی پیدا کنید.

```c#
using (Presentation pres = new Presentation("demo.pptx"))
{
    pres.ViewProperties.NormalViewProperties.HorizontalBarState = SplitterBarStateType.Restored;
    pres.ViewProperties.NormalViewProperties.VerticalBarState = SplitterBarStateType.Maximized;

    // بازیابی ویژگی‌های نمایش ارائه
    pres.ViewProperties.NormalViewProperties.RestoredTop.AutoAdjust = true;
    pres.ViewProperties.NormalViewProperties.RestoredTop.DimensionSize = 80;
    pres.ViewProperties.NormalViewProperties.ShowOutlineIcons = true;

    pres.Save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
}
```

## **تنظیم مقدار بزرگنمایی پیش‌فرض**

Aspose.Slides برای .NET الآن از تنظیم مقدار بزرگنمایی پیش‌فرض برای ارائه پشتیبانی می‌کند به‌گونه‌ای که هنگام باز کردن ارائه، بزرگنمایی از پیش تنظیم باشد. این کار می‌تواند با تنظیم [ViewProperties](https://reference.aspose.com/slides/fa/net/aspose.slides/viewproperties) یک ارائه انجام شود. ویژگی‌های نمای اسلاید همان‌طور که [NotesViewProperties](https://reference.aspose.com/slides/fa/net/aspose.slides/viewproperties/properties/notesviewproperties) نیز می‌توانند برنامه‌نویسی شوند. در این موضوع، با یک مثال می‌بینیم چگونه ویژگی‌های نمایش یک ارائه را در Aspose.Slides تنظیم کنیم.

برای تنظیم ویژگی‌های نمایش، لطفاً مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید
1. ویژگی‌های [Properties](https://reference.aspose.com/slides/fa/net/aspose.slides/viewproperties) نمای ارائه را تنظیم کنید
1. ارائه را به صورت فایل PPTX ذخیره کنید

در مثال زیر، مقدار بزرگنمایی برای نمای اسلاید و نمای یادداشت‌ها تنظیم شده است.

```c#
using (Presentation presentation = new Presentation("demo.pptx"))
{
    // تنظیم ویژگی‌های نمایش ارائه
    presentation.ViewProperties.SlideViewProperties.Scale = 100; // مقدار بزرگنمایی به درصد برای نمای اسلاید
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // مقدار بزرگنمایی به درصد برای نمای یادداشت‌ها 

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```

## **سوالات متداول**

**آیا می‌توانم تنظیمات نمایش متفاوتی برای بخش‌های مختلف یک ارائه تعیین کنم؟**

[تنظیمات نمایش](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/viewproperties/) در سطح ارائه تعریف می‌شوند ([نمای عادی](https://reference.aspose.com/slides/fa/net/aspose.slides/viewproperties/normalviewproperties/)/[نمای اسلاید](https://reference.aspose.com/slides/fa/net/aspose.slides/viewproperties/slideviewproperties/))، نه برای هر بخش، بنابراین یک مجموعه پارامتر برای تمام سند هنگام باز شدن اعمال می‌شود.

**آیا می‌توانم حالت‌های نمایش متفاوتی برای کاربران مختلف پیش‌تعریف کنم؟**

نه. تنظیمات در فایل ذخیره می‌شوند و به‌اشتراک‌گذاری می‌شوند. برنامه‌های نمایش ممکن است ترجیحات کاربر را رعایت کنند، اما خود فایل تنها یک مجموعه ویژگی نمایش دارد.

**آیا می‌توانم قالبی با ویژگی‌های نمایش پیش‌تعریف‌شده آماده کنم تا ارائه‌های جدید به همان شکل باز شوند؟**

بله. از آنجا که [ویژگی‌های نمایش](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/viewproperties/) در سطح ارائه ذخیره می‌شوند، می‌توانید آن‌ها را در قالبی تعبیه کنید و اسناد جدید را از آن قالب ایجاد کنید تا همان پیکربندی نمای اولیه داشته باشند.