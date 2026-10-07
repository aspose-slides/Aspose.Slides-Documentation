---
title: مدیریت سلول‌های جدول در ارائه‌ها در .NET
linktitle: مدیریت سلول‌ها
type: docs
weight: 30
url: /fa/net/manage-cells/
keywords:
- سلول جدول
- ادغام سلول‌ها
- حذف حاشیه
- تقسیم سلول
- تصویر در سلول
- رنگ پس‌زمینه
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "مدیریت سلول‌های جدول PowerPoint در C#: شناسایی سلول‌های ادغام‌شده، حذف حاشیه‌ها، تقسیم سلول‌ها، و تنظیم رنگ‌های پس‌زمینه و تصاویر با Aspose.Slides برای .NET."
---
## **نمای کلی**

Aspose.Slides به شما امکان می‌دهد تا به سلول‌های جدول در ارائه‌های PowerPoint دسترسی داشته باشید و آن‌ها را اصلاح کنید. این مقاله توضیح می‌دهد چگونه سلول‌های جدول ادغام‌شده را شناسایی کنید، مرزبندی سلول‌ها را حذف کنید، با شماره‌گذاری سلول پس از ادغام یا جداسازی سلول‌ها کار کنید، رنگ پس‌زمینه سلول را تغییر دهید و یک تصویر را داخل یک سلول جدول اضافه کنید. مثال‌ها نمایش می‌دهند چگونه یک ارائه را ایجاد یا باز کنید، جدول را از یک اسلاید دریافت کنید، قالب‌بندی سلول را از طریق ویژگی‌های سلول به‌روزرسانی کنید و ارائه اصلاح‌شده را به‌صورت فایل PPTX ذخیره نمایید.

Aspose.Slides از ایندکس‌های صفر‑پایه برای دسترسی به سلول‌های جدول به ترتیب `(column, row)` استفاده می‌کند.

## **شناسایی یک سلول جدول ادغام‌شده**

مثال یک ارائه موجود را باز می‌کند و اولین شکل روی اولین اسلاید را به عنوان جدول دسترسی می‌دهد. فرض می‌شود اسلاید و شکل وجود دارند و شکل یک جدول است. سپس از تمام ردیف‌ها و ستون‌ها عبور می‌کند و از [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) برای شناسایی سلول‌های موجود در نواحی ادغام‌شده استفاده می‌کند. برای هر تطابق، مختصات سلول را به ترتیب `row;column`، [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/)، [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/)، و مختصات شروع ناحیه، [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) و [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/) چاپ می‌کند.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("presentation_with_table.pptx");
var slide = presentation.Slides[0];
var table = (ITable) slide.Shapes[0];

var rowCount = table.Rows.Count;
for (var rowIndex = 0; rowIndex < rowCount; rowIndex++)
{
    var columnCount = table.Columns.Count;
    for (var columnIndex = 0; columnIndex < columnCount; columnIndex++)
    {
        var cell = table[columnIndex, rowIndex];
        if (cell.IsMergedCell)
        {
            Console.WriteLine($"Cell {rowIndex};{columnIndex} belongs to a merged region with RowSpan={cell.RowSpan} and ColSpan={cell.ColSpan} starting at {cell.FirstRowIndex};{cell.FirstColumnIndex}.");
        }
    }
}
```

## **حذف حاشیه‌های سلول جدول**

یک [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) ایجاد کنید و با استفاده از [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/) یک جدول را به اولین اسلاید آن اضافه کنید. عرض‌های ستون، ارتفاع‌های ردیف و موقعیت جدول بر حسب پوینت تعیین می‌شوند. مثال همه چهار حاشیه سلول را به [FillType.NoFill](https://reference.aspose.com/slides/net/aspose.slides/filltype/) تنظیم می‌کند تا نامرئی شوند.

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 50, 50, 50, 50 };
double[] rowHeights = { 50, 30, 30, 30, 30 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

foreach (var row in table.Rows)
    foreach (var cell in row)
    {
        cell.CellFormat.BorderTop.FillFormat.FillType = FillType.NoFill;
        cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.NoFill;
        cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.NoFill;
        cell.CellFormat.BorderRight.FillFormat.FillType = FillType.NoFill;
    }

presentation.Save("table.pptx", SaveFormat.Pptx);
```

## **ادغام سلول‌های جدول**

از [MergeCells](https://reference.aspose.com/slides/net/aspose.slides/itable/mergecells/) برای ترکیب یک بازه مستطیلی از سلول‌های جدول به یک سلول استفاده کنید. سلول‌های گوشه بالا‑چپ و پایین‑راست بازه را مشخص کنید. آرگومان نهایی تعیین می‌کند که آیا ادغام می‌تواند شامل سلول‌های خارج از بازه مشخص شده باشد یا نه؛ مقدار `false` ادغام را درون آن بازه نگه می‌دارد.

مثال یک جدول ۴×۴ با ستون‌ها و ردیف‌های ۷۰ پوینت ایجاد می‌کند، سپس چهار سلول مرکزی را از `(1, 1)` تا `(2, 2)` ادغام می‌کند. سلول حاصل دو ستون و دو ردیف را در بر می‌گیرد، در حالی که جدول پایه‌ای خود چهار ستون و چهار ردیف را حفظ می‌کند. برای دسترسی به محتوای یا قالب‌بندی سلول ادغام‌شده، از موقعیت بالا‑چپ آن استفاده کنید: `table[1, 1]` در این مثال. سایر موقعیت‌ها در بازه ادغام‌شده جزئی از شبکه جدول باقی می‌مانند، بنابراین ایندکس‌های سلول‌های خارج از بازه تغییر نمی‌کنند.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 70, 70, 70, 70 };
double[] rowHeights = { 70, 70, 70, 70 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

table.MergeCells(table[1, 1], table[2, 2], false);

presentation.Save("merged_cells.pptx", SaveFormat.Pptx);
```

## **تقسیم سلول‌های جدول**

ادغام سلول‌ها در مثال قبلی ساختار شبکه جدول را حفظ می‌کند. تقسیم یک سلول می‌تواند یک ستون جدید به شبکه اضافه کند و ایندکس ستون سلول‌های سمت راست آن را تغییر دهد. Aspose.Slides مدل شبکه جدول PowerPoint را دنبال می‌کند.

این مثال یک جدول ۴×۴ با ستون‌ها و ردیف‌های ۷۰ پوینت ایجاد می‌کند و بر روی سلول `(1, 1)` متد [SplitByWidth](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbywidth/) را فراخوانی می‌کند. نیمی از عرض ۷۰ پوینت سلول برای ایجاد دو سلول با عرض مساوی استفاده می‌شود.

پس از این تقسیم، دو نیمه به صورت `table[1, 1]` و `table[2, 1]` دسترسی می‌یابند. شبکه جدول اکنون پنج ستون دارد: سلول‌های اولیه در ستون‌های ۲ و ۳ به ستون‌های ۳ و ۴ منتقل می‌شوند. ایندکس‌های ردیف تغییر نمی‌کند. هنگام دسترسی به سلول‌ها پس از تقسیم، از این ایندکس‌های ستون به‌روز شده استفاده کنید.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 70, 70, 70, 70 };
double[] rowHeights = { 70, 70, 70, 70 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

table[1, 1].SplitByWidth(table[1, 1].Width / 2);

presentation.Save("split_cells.pptx", SaveFormat.Pptx);
```

### **تقسیم سلول‌های ادغام‌شده بر اساس گستردگی ردیف یا ستون**

برای آماده‌سازی سلول‌های قالب ادغام‌شده برای پرکردن داده، از [SplitByRowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyrowspan/) برای تقسیم بر مبنای مرز ردیف موجود، یا از [SplitByColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbycolspan/) برای تقسیم بر مبنای مرز ستون استفاده کنید.

آرگومان `index` ردیف‌ها را در بخش بالایی یا ستون‌ها را در بخش چپ تقسیم می‌شمارید؛ این مقدار نسبی به ناحیه ادغام‌شده است:

- تقسیم ردیف: `0 < index <` [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/).
- تقسیم ستون: `0 < index <` [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/).

مثال می‌پذیرد که یک ارائه جدولی را به عنوان اولین شکل در اولین اسلاید داشته باشد، به‌طوری که `(1, 2)` و `(1, 3)` به‌صورت عمودی ادغام شده باشند. از موقعیت پایین شروع می‌کند و از [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/) و [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) برای یافتن منبع استفاده می‌کند و هر دو گستردگی را بررسی می‌کند. `SplitByRowSpan(1)` سپس ردیف‌های ۲ و ۳ را برای نام محصولات جدا می‌کند. برای ادغام افقی دو ستون، به‌جای آن از `SplitByColSpan(1)` استفاده کنید.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table_template.pptx");
var slide = presentation.Slides[0];
var table = (ITable) slide.Shapes[0];

var selectedCell = table[1, 3];
var firstColumnIndex = selectedCell.FirstColumnIndex;
var firstRowIndex = selectedCell.FirstRowIndex;
var mergedCell = table[firstColumnIndex, firstRowIndex];

if (mergedCell.IsMergedCell && mergedCell.RowSpan == 2 && mergedCell.ColSpan == 1)
{
    mergedCell.SplitByRowSpan(1);

    // سلول‌های حاصل از جدول را پس از تقسیم دریافت کنید.
    var upperCell = table[firstColumnIndex, firstRowIndex];
    var lowerCell = table[firstColumnIndex, firstRowIndex + 1];
    Console.WriteLine($"Upper cell merged: {upperCell.IsMergedCell}");
    Console.WriteLine($"Lower cell merged: {lowerCell.IsMergedCell}");

    upperCell.TextFrame.Text = "Product A";
    lowerCell.TextFrame.Text = "Product B";

    presentation.Save("split_template.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("Select a merged region spanning exactly two rows and one column.");
}
```

شبکه جدول و ایندکس‌های سلول‌های اطراف بدون تغییر می‌مانند. سلول‌های حاصل را با مختصات آن‌ها بازیابی کنید؛ در اینجا هر دو دارای گستردگی ۱ هستند و [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) مقدار `False` را چاپ می‌کند. نواحی بزرگ‌تر می‌توانند پس از یک تقسیم به‌صورت جزئی ادغام باقی بمانند.

متن اصلی و قالب‌بندی آن در سلول بالا (یا چپ) باقی می‌ماند؛ سلول جدید خالی است اما قالب‌بندی سلول مانند پرکردن، حاشیه‌ها و حاشیه‌ها را به ارث می‌برد. پس از تقسیم سلول‌ها را پر کنید و هر قالب‌بندی متن مورد نیاز را به‌صورت صریح تنظیم کنید.

ارائه ذخیره‌شده شامل سلول‌های جداگانه «Product A» و «Product B» با حفظ قالب‌بندی سلول قالب است. برای جزئیات به [Cell API Reference](https://reference.aspose.com/slides/net/aspose.slides/cell/) مراجعه کنید.

## **تغییر رنگ پس‌زمینه سلول جدول**

این مثال یک جدول با ستون‌های ۱۵۰ پوینت و ردیف‌های ۵۰ پوینت ایجاد می‌کند. برای سلول `(2, 3)` که در ستون سوم و ردیف چهارم قرار دارد، [FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) را به solid و [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/) را به رنگ قرمز تنظیم می‌کند.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 150, 150, 150, 150 };
double[] rowHeights = { 50, 50, 50, 50, 50 };
var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

var cell = table[2, 3];
cell.CellFormat.FillFormat.FillType = FillType.Solid;
cell.CellFormat.FillFormat.SolidFillColor.Color = Color.Red;

presentation.Save("cell_background_color.pptx", SaveFormat.Pptx);
```

## **افزودن تصویر داخل سلول جدول**

قبل از اجرای این مثال، تصویر ورودی را در پوشه کاری قرار دهید. تصویر را با [Images.FromFile](https://reference.aspose.com/slides/net/aspose.slides/images/fromfile/) بارگیری می‌کند و با [AddImage](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/addimage/) به مجموعه تصویرهای ارائه اضافه می‌کند. سپس تصویر را به پرکردن تصویری سلول `(0, 0)`، اولین سلول جدول، اختصاص می‌دهد.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) تصویر را برای پر کردن سلول کش می‌دهد که ممکن است نسبت تصویر را تغییر دهد. عرض ستون‌ها و ارتفاع ردیف‌ها بر حسب پوینت است. تصویر بارگیری‌شده به‌صورت خودکار توسط دستور using حذف می‌شود.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 150, 150, 150, 150 };
double[] rowHeights = { 100, 100, 100, 100, 90 };
var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

using var image = Images.FromFile("aspose_logo.jpg");
var ppImage = presentation.Images.AddImage(image);

table[0, 0].CellFormat.FillFormat.FillType = FillType.Picture;
table[0, 0].CellFormat.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
table[0, 0].CellFormat.FillFormat.PictureFillFormat.Picture.Image = ppImage;

presentation.Save("table_cell_with_image.pptx", SaveFormat.Pptx);
```

## **سؤالات متداول**

**آیا می‌توانم ضخامت و سبک خطوط مختلف را برای طرف‌های متفاوت یک سلول تنظیم کنم؟**

بله. حاشیه‌های [top](https://reference.aspose.com/slides/net/aspose.slides/cellformat/bordertop/)/[bottom](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderbottom/)/[left](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderleft/)/[right](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderright/) دارای ویژگی‌های جداگانه‌ای هستند، بنابراین ضخامت و سبک هر طرف می‌تواند متفاوت باشد.

**چه اتفاقی برای تصویر می‌افتد اگر پس از تنظیم یک تصویر به‌عنوان پس‌زمینه سلول، اندازه ستون/ردیف را تغییر دهم؟**

رفتار بسته به [حالت پرکردن](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) متفاوت است. با کشش، تصویر با سلول جدید سازگار می‌شود؛ با tiling، کاشی‌ها دوباره محاسبه می‌شوند.

**آیا می‌توانم یک Hyperlink به تمام محتوای یک سلول اختصاص دهم؟**

[Hyperlinks](/slides/fa/net/manage-hyperlinks/) در سطح متن (بخش) داخل فریم متن سلول یا در سطح کل جدول/شکل تنظیم می‌شوند. در عمل، لینک را به یک بخش یا به تمام متن در سلول اختصاص می‌دهید.

**آیا می‌توانم قلم‌های مختلف را داخل یک سلول تنظیم کنم؟**

بله. چارچوب متن سلول از [portions](https://reference.aspose.com/slides/net/aspose.slides/portion/) (بخش‌ها) با قالب‌بندی مستقل—خانواده قلم، سبک، اندازه و رنگ—پشتیبانی می‌کند.