---
title: مدیریت ردیف‌ها و ستون‌ها در جداول PowerPoint در .NET
linktitle: ردیف‌ها و ستون‌ها
type: docs
weight: 20
url: /fa/net/manage-rows-and-columns/
keywords:
- ردیف جدول
- ستون جدول
- اولین ردیف
- سرصفحه جدول
- کلون ردیف
- کلون ستون
- کپی ردیف
- کپی ستون
- حذف ردیف
- حذف ستون
- قالب‌بندی متن ردیف
- قالب‌بندی متن ستون
- سبک جدول
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "مدیریت ردیف‌ها و ستون‌های جدول در PowerPoint با Aspose.Slides برای .NET و تسریع ویرایش ارائه و به‌روزرسانی داده‌ها."
---
## **معرفی**

Aspose.Slides برای .NET به شما امکان می‌دهد ساختار و قالب‌بندی جدول‌ها را در ارائه‌های PowerPoint از طریق کلاس [Table](https://reference.aspose.com/slides/net/aspose.slides/table/) و رابط [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) مدیریت کنید. می‌توانید یک ردیف سرصفحه تعیین کنید، ردیف‌ها و ستون‌ها را کلون یا حذف کنید و قالب‌بندی متن را بر روی یک ردیف یا ستون کامل اعمال کنید.

این مقاله این عملیات را با مثال‌های C# توضیح می‌دهد. همچنین نشان می‌دهد چگونه پیش تنظیم سبک جدول را بازیابی کنید تا بتوانید دوباره از آن استفاده کنید. ایندکس‌های ردیف و ستون جدول از صفر شروع می‌شوند.

## **کنترل ارتفاع ردیف**

از [IRow.MinimalHeight](https://reference.aspose.com/slides/net/aspose.slides/irow/minimalheight/) برای تنظیم حداقل ارتفاع ردیف بر حسب پوینت استفاده کنید. این یک حد پایین است، نه ارتفاع ثابت. [IRow.Height](https://reference.aspose.com/slides/net/aspose.slides/irow/height/) ارتفاع واقعی را بازمی‌گرداند و فقط‑خواندنی است. برای دسترسی به ردیف از [ITable.Rows](https://reference.aspose.com/slides/net/aspose.slides/itable/rows/) استفاده کنید.

مثال فایل [row-height-input.pptx](row-height-input.pptx) را بارگذاری می‌کند که جدولی به عنوان شکل اول در اسلاید اول دارد. ردیف اول آن از ۷۰ پوینت شروع می‌شود. سلول‌ها از متن Arial با اندازه ۱۸ پوینت، بسته شدن خطوط و حاشیه‌های بالا و پایین ۶ پوینت استفاده می‌کنند؛ متن طولانی‌تر در ستون دوم به خطوط متعدد می‌پیچد. مثال حداقل را به ۱۰۰ پوینت افزایش می‌دهد، سپس به ۲۰ پوینت کاهش می‌دهد، پس از هر تغییر ارتفاع واقعی را چاپ می‌کند و هر دو نتیجه را ذخیره می‌کند.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("row-height-input.pptx");
var table = (ITable)presentation.Slides[0].Shapes[0];
var row = table.Rows[0];

row.MinimalHeight = 100;
Console.WriteLine($"Increased: minimum = {row.MinimalHeight:F1}, actual = {row.Height:F1} pt");
presentation.Save("row-height-increased.pptx", SaveFormat.Pptx);

row.MinimalHeight = 20;
Console.WriteLine($"Decreased: minimum = {row.MinimalHeight:F1}, actual = {row.Height:F1} pt");
presentation.Save("row-height-decreased.pptx", SaveFormat.Pptx);
```

با ارائهٔ ارائه‌شده، افزایش حداقل فضای بیشتری به ردیف اضافه می‌کند. کاهش آن آن فضای اضافه را حذف می‌کند، اما ارتفاع واقعی بزرگ‌تر از ۲۰ پوینت باقی می‌ماند زیرا متن و حاشیه‌های سلول به فضای بیشتری نیاز دارند. صرفاً کاهش حداقل نمی‌تواند ردیف را زیر فضایی که محتویاتش می‌خواهند، نگه دارد.

چند عامل بر ارتفاع واقعی تأثیر می‌گذارند:

- **متن و اندازهٔ قلم:** متن طولانی‌تر، شکست‌خط‌های صریح یا قلم بزرگ‌تر می‌تواند فضای عمودی بیشتری نیاز داشته باشد.
- **بسته شدن خطوط و عرض ستون:** با فعال بودن بسته شدن خطوط، عرض باریک‌تر [IColumn.Width](https://reference.aspose.com/slides/net/aspose.slides/icolumn/width/) می‌تواند خطوط بیشتری ایجاد کند. ستون عریض‌تر می‌تواند فضای عمودی مورد نیاز را کاهش دهد.
- **حاشیه‌های سلول:** [ICell.MarginTop](https://reference.aspose.com/slides/net/aspose.slides/icell/margintop/) و [ICell.MarginBottom](https://reference.aspose.com/slides/net/aspose.slides/icell/marginbottom/) فضای عمودی اضافه می‌کنند. [ICell.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/icell/marginleft/) و [ICell.MarginRight](https://reference.aspose.com/slides/net/aspose.slides/icell/marginright/) عرض متن را کاهش می‌دهند و می‌توانند بسته شدن خطوط بیشتری ایجاد کنند.

در این جدول بدون سلول‌های ادغام‌شده، سلولی که بیشترین فضای عمودی را نیاز دارد، حد پایین مبتنی بر محتوا را برای کل ردیف تعیین می‌کند. برای کوتاه‌تر کردن ردیف ممکن است نیاز باشد متن را کوتاه کنید، اندازهٔ قلم یا حاشیه‌ها را کاهش دهید یا ستونی را عریض‌تر کنید.

تصاویر زیر همان جدول را در همان مقیاس نشان می‌دهند. در این اجرا، ارتفاع‌های واقعی ۷۰، ۱۰۰ و ۵۵.۲ پوینت بودند: ردیف نهایی بزرگ‌تر از حداقل ۲۰ پوینت باقی ماند. اندازه‌گیری‌های دقیق متن می‌تواند بسته به قلم‌های موجود در محیط شما متفاوت باشد. نتایج ذخیره‌شده را دانلود کنید: [increased minimum](row-height-increased.pptx) و [decreased minimum](row-height-decreased.pptx).

| اصلی: حداقل ۷۰ پوینت، واقعی ۷۰ پوینت | افزایش یافته: حداقل ۱۰۰ پوینت، واقعی ۱۰۰ پوینت | کاهش یافته: حداقل ۲۰ پوینت، واقعی ۵۵.۲ پوینت |
| --- | --- | --- |
| ![جدول اصلی با ردیف اول ۷۰ پوینت.](row-height-before.png) | ![جدول پس از افزایش حداقل ردیف اول به ۱۰۰ پوینت.](row-height-increased.png) | ![جدول پس از کاهش حداقل ردیف اول به ۲۰ پوینت؛ متن بسته‌شده ردیف را بزرگ‌تر از حداقل نگه می‌دارد.](row-height-decreased.png) |

## **تنظیم ردیف اول به عنوان سرصفحه**

از ویژگی [FirstRow](https://reference.aspose.com/slides/net/aspose.slides/itable/firstrow/) برای علامت‌گذاری ردیف اول به‌منظور قالب‌بندی سرصفحه استفاده کنید. ظاهر آن به سبک جدولی که بر روی جدول اعمال شده بستگی دارد.

1. ارائه را با کلاس [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) بارگذاری کنید.
2. به اسلاید اول دسترسی پیدا کنید.
3. به جدول که به‌عنوان شکل اول در اسلاید ذخیره شده است دسترسی پیدا کنید.
4. قالب‌بندی سرصفحه را برای ردیف اول فعال کنید.
5. ارائهٔ تغییر یافته را ذخیره کنید.

این مثال به فایل `table.pptx` نیاز دارد که جدول به‌عنوان شکل اول در اسلاید اول دارد. قالب‌بندی سرصفحه برای ردیف اول فعال می‌شود و `First_row_header.pptx` ذخیره می‌شود.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];
table.FirstRow = true;

presentation.Save("First_row_header.pptx", SaveFormat.Pptx);
```

## **کلون کردن ردیف یا ستون جدول**

ردیف‌ها یا ستون‌ها را کلون کنید تا محتوا و قالب‌بندی آن‌ها را مجدداً استفاده کنید. می‌توانید یک نسخه را به انتهای جدول اضافه کنید یا در موقعیتی خاص وارد کنید.

1. ارائه را با کلاس [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) بارگذاری کنید.
2. به اسلاید اول دسترسی پیدا کنید.
3. عرض ستون‌ها و ارتفاع ردیف‌ها را تعریف کنید.
4. جدول را با متد [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/) اضافه کنید.
5. ردیف‌های مورد نیاز را کلون کنید.
6. ستون‌های مورد نیاز را کلون کنید.
7. ارائهٔ تغییر یافته را ذخیره کنید.

این مثال به `Test.pptx` نیاز دارد که حداقل یک اسلاید داشته باشد. جدول با سه ستون و پنج ردیف ایجاد می‌شود، ابعاد آن‌ها بر حسب پوینت مشخص می‌شود. نسخ‌های ردیف و ستون اول اضافه می‌شوند، سپس نسخ‌های ردیف و ستون دوم در ایندکس ۳ (موقعیت چهارم) وارد می‌شوند. جدول نهایی دارای هفت ردیف و پنج ستون است. آرگومان `false` از کلون شدن به‌سوی ردیف‌ها یا ستون‌های ادغام‌شده مجاور جلوگیری می‌کند؛ این جدول سلول‌های ادغام‌شده‌ای ندارد.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Test.pptx");
var slide = presentation.Slides[0];

var columnWidths = new double[] { 50, 50, 50 };
var rowHeights = new double[] { 50, 30, 30, 30, 30 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

table[0, 0].TextFrame.Text = "Row 1 Cell 1";
table[1, 0].TextFrame.Text = "Row 1 Cell 2";
table.Rows.AddClone(table.Rows[0], false);

table[0, 1].TextFrame.Text = "Row 2 Cell 1";
table[1, 1].TextFrame.Text = "Row 2 Cell 2";
table.Rows.InsertClone(3, table.Rows[1], false);

table.Columns.AddClone(table.Columns[0], false);
table.Columns.InsertClone(3, table.Columns[1], false);

presentation.Save("table_out.pptx", SaveFormat.Pptx);
```

## **حذف ردیف یا ستون از جدول**

ردیف‌ها یا ستون‌هایی که دیگر نیازی به آن‌ها ندارید را حذف کنید. حذف یک مورد ایندکس‌های ردیف‌ها یا ستون‌های بعدی را جابه‌جا می‌کند.

1. یک ارائه با کلاس [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) ایجاد کنید.
2. به اسلاید اول دسترسی پیدا کنید.
3. عرض ستون‌ها و ارتفاع ردیف‌ها را تعریف کنید.
4. جدول را با متد [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/) اضافه کنید.
5. ردیف دوم و ستون دوم را حذف کنید.
6. ارائهٔ تغییر یافته را ذخیره کنید.

این مثال یک جدول سه‌در‑سه ایجاد می‌کند و ردیف و ستون با ایندکس ۱ را حذف می‌کند و جدول دو‑در‑دو در `TestTable_out.pptx` باقی می‌ماند. ابعاد بر حسب پوینت هستند. آرگومان `false` حذف ردیف‌ها یا ستون‌های ادغام‌شدهٔ مجاور را غیرفعال می‌کند؛ این جدول سلول‌های ادغام‌شده‌ای ندارد.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 100, 50, 30 };
var rowHeights = new double[] { 30, 50, 30 };
var table = slide.Shapes.AddTable(100, 100, columnWidths, rowHeights);

table.Rows.RemoveAt(1, false);
table.Columns.RemoveAt(1, false);

presentation.Save("TestTable_out.pptx", SaveFormat.Pptx);
```

## **تنظیم قالب‌بندی متن در سطح ردیف جدول**

قالب‌بندی متن را بر روی یک ردیف کامل اعمال کنید تا سلول‌های آن یکدست باشند. می‌توانید ویژگی‌های قلم، قالب‌بندی پاراگراف و جهت متن را بدون قالب‌بندی هر سلول به‌صورت جداگانه تنظیم کنید.

1. ارائه را با کلاس [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) بارگذاری کنید.
2. به جدول در اسلاید اول دسترسی پیدا کنید.
3. برای ردیف اول [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) را تنظیم کنید.
4. برای ردیف اول [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) و [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) را تنظیم کنید.
5. برای ردیف دوم [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) را تنظیم کنید.
6. ارائهٔ تغییر یافته را ذخیره کنید.

این مثال به `table.pptx` نیاز دارد که جدول به‌عنوان شکل اول در اسلاید اول دارد و حداقل دو ردیف دارد. متن ۲۵ پوینت، تراز راست و حاشیهٔ پاراگراف راست ۲۰ پوینت برای ردیف اول اعمال می‌شود، سپس متن عمودی برای ردیف دوم تنظیم می‌شود.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

var portionFormat = new PortionFormat { FontHeight = 25 };
table.Rows[0].SetTextFormat(portionFormat);

var paragraphFormat = new ParagraphFormat { Alignment = TextAlignment.Right, MarginRight = 20 };
table.Rows[0].SetTextFormat(paragraphFormat);

var textFrameFormat = new TextFrameFormat { TextVerticalType = TextVerticalType.Vertical };
table.Rows[1].SetTextFormat(textFrameFormat);

presentation.Save("row_formatting.pptx", SaveFormat.Pptx);
```

## **تنظیم قالب‌بندی متن در سطح ستون جدول**

قالب‌بندی متن را بر روی یک ستون کامل اعمال کنید تا سلول‌های آن یکدست باشند. می‌توانید ویژگی‌های قلم، قالب‌بندی پاراگراف و جهت متن را بدون قالب‌بندی هر سلول به‌صورت جداگانه تنظیم کنید.

1. ارائه را با کلاس [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) بارگذاری کنید.
2. به جدول در اسلاید اول دسترسی پیدا کنید.
3. برای ستون اول [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) را تنظیم کنید.
4. برای ستون اول [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) و [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) را تنظیم کنید.
5. برای ستون دوم [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) را تنظیم کنید.
6. ارائهٔ تغییر یافته را ذخیره کنید.

این مثال به `table.pptx` نیاز دارد که جدول به‌عنوان شکل اول در اسلاید اول دارد و حداقل دو ستون دارد. متن ۲۵ پوینت، تراز راست و حاشیهٔ پاراگراف راست ۲۰ پوینت برای ستون اول اعمال می‌شود، سپس متن عمودی برای ستون دوم تنظیم می‌شود.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

var portionFormat = new PortionFormat { FontHeight = 25 };
table.Columns[0].SetTextFormat(portionFormat);

var paragraphFormat = new ParagraphFormat { Alignment = TextAlignment.Right, MarginRight = 20 };
table.Columns[0].SetTextFormat(paragraphFormat);

var textFrameFormat = new TextFrameFormat { TextVerticalType = TextVerticalType.Vertical };
table.Columns[1].SetTextFormat(textFrameFormat);

presentation.Save("column_formatting.pptx", SaveFormat.Pptx);
```

## **دریافت ویژگی‌های سبک جدول**

از ویژگی [StylePreset](https://reference.aspose.com/slides/net/aspose.slides/itable/stylepreset/) برای بازیابی پیش تنظیمی که بر روی جدول اعمال شده استفاده کنید و آن را روی جدول دیگر دوباره به‌کار ببرید. این پیش تنظیم را شناسایی می‌کند نه بازنویسی‌های قالب‌بندی سلول‌های منفرد.

مثال یک جدول ایجاد می‌کند، [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/net/aspose.slides/tablestylepreset/) را اعمال می‌کند و پیش تنظیم را دوباره می‌خواند. `DarkStyle1` چاپ می‌شود و جدول در `table.pptx` ذخیره می‌شود.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 100, 150 };
var rowHeights = new double[] { 5, 5, 5 };
var table = slide.Shapes.AddTable(10, 10, columnWidths, rowHeights);
table.StylePreset = TableStylePreset.DarkStyle1;

Console.WriteLine(table.StylePreset);

presentation.Save("table.pptx", SaveFormat.Pptx);
```

## **FAQ**

**آیا می‌توانم تم/سبک‌های PowerPoint را به جدول از پیش ساخته شده اعمال کنم؟**

بله. جدول تم اسلاید/چیدمان/مستر را به ارث می‌برد و هنوز می‌توانید پرکننده‌ها، حاشیه‌ها و رنگ‌های متن را بر روی آن بازنویسی کنید.

**آیا می‌توانم ردیف‌های جدول را همانند Excel مرتب کنم؟**

خیر، جدول‌های Aspose.Slides قابلیت مرتب‌سازی یا فیلترهای داخلی را ندارند. ابتدا داده‌ها را در حافظه مرتب کنید، سپس ردیف‌های جدول را به ترتیب آن بازپر کنید.

**آیا می‌توانم ستون‌های راه‌راه (banded) داشته باشم در حالی که رنگ‌های سفارشی را برای سلول‌های خاص حفظ می‌کنم؟**

بله. ستون‌های راه‌راه را فعال کنید، سپس سلول‌های خاص را با قالب‌بندی محلی بازنویسی کنید؛ قالب‌بندی سطح سلول بر استایل جدول اولویت دارد.