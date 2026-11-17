---
title: مدیریت سلول‌های جدول در ارائه‌ها در .NET
linktitle: مدیریت سلول‌ها
type: docs
weight: 30
url: /fa/net/manage-cells/
keywords:
- سلول جدول
- ترکیب سلول‌ها
- حذف حاشیه
- تقسیم سلول
- تصویر در سلول
- رنگ پس‌زمینه
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "مدیریت سلول‌های جدول PowerPoint در C#: شناسایی سلول‌های ترکیب‌شده، حذف حاشیه‌ها، تقسیم سلول‌ها و تنظیم رنگ‌های پس‌زمینه و تصاویر با Aspose.Slides برای .NET."
---
## **بررسی کلی**

Aspose.Slides به شما امکان دسترسی و تغییر سلول‌های جدول در ارائه‌های PowerPoint را می‌دهد. این مقاله توضیح می‌دهد چگونه سلول‌های جدول ترکیب‌شده را شناسایی کنید، حاشیه‌های سلول را حذف کنید، پس از ترکیب یا تقسیم سلول‌ها با شماره‌گذاری سلول کار کنید، رنگ پس‌زمینه یک سلول را تغییر دهید و تصویری را در داخل یک سلول جدول اضافه کنید. مثال‌ها نشان می‌دهند چگونه یک ارائه را ایجاد یا باز کنید، جدول را از اسلاید دریافت کنید، قالب‌بندی سلول را از طریق خصوصیات سلول به‌روزرسانی کنید و ارائهٔ اصلاح‌شده را به صورت فایل PPTX ذخیره کنید.

Aspose.Slides از اندیس‌های صفر-پایه برای دسترسی به سلول‌های جدول به ترتیب `(column, row)` استفاده می‌کند.

## **شناسایی یک سلول جدول ترکیب‌شده**

مثال یک ارائهٔ موجود را باز می‌کند و اولین شکل در اولین اسلاید را به‌عنوان جدول دسترسی می‌دهد. فرض می‌کند که اسلاید و شکل موجود هستند و شکل یک جدول است. سپس تمام ردیف‌ها و ستون‌ها را پیمایش می‌کند و از [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) برای شناسایی سلول‌های در ناحیه‌های ترکیب‌شده استفاده می‌کند. برای هر تطابق، مختصات سلول را به ترتیب `row;column`، [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/)، [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/)، و مختصات شروع ناحیه را با [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) و [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/) چاپ می‌کند.

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

یک [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) ایجاد کنید و با استفاده از [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/) یک جدول به اولین اسلاید آن اضافه کنید. عرض ستون‌ها، ارتفاع ردیف‌ها و موقعیت جدول برحسب نقطه تعیین می‌شود. مثال تمام چهار حاشیهٔ سلول را به [FillType.NoFill](https://reference.aspose.com/slides/net/aspose.slides/filltype/) تنظیم می‌کند تا نامرئی شوند.

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

## **افزودن حاشیه‌های مورب به سلول**

از [BorderDiagonalDown](https://reference.aspose.com/slides/net/aspose.slides/icellformat/borderdiagonaldown/) برای رسم خط از گوشهٔ بالا‑چپ به پایین‑راست و از [BorderDiagonalUp](https://reference.aspose.com/slides/net/aspose.slides/icellformat/borderdiagonalup/) برای رسم خط از گوشهٔ پایین‑چپ به بالا‑راست استفاده کنید. یک مورب می‌تواند سرصفحهٔ گوشه‌ای را مشخص کند؛ هر دو مورب می‌توانند یک حرف X تشکیل دهند تا سلول «غیرقابل اعمال» باشد.

هر مورب یک [ILineFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/) است. در [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/fillformat/) آن، [FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) را به [FillType.Solid](https://reference.aspose.com/slides/net/aspose.slides/filltype/) تنظیم کنید و یک [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/) انتخاب کنید. عرض خط را با [Width](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/width/) برحسب نقطه تنظیم کنید.

مثال سه سلول در یک ردیف ایجاد می‌کند: یک مورب نزولی قرمز، یک مورب صعودی آبی و هر دو مورب. حاشیه‌های بالا، پایین، چپ و راست سلول دست‌نخورده می‌مانند.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 210, 210, 210 };
double[] rowHeights = { 160 };
var table = slide.Shapes.AddTable(45, 130, columnWidths, rowHeights);

var downwardBorder = table[0, 0].CellFormat.BorderDiagonalDown;
downwardBorder.FillFormat.FillType = FillType.Solid;
downwardBorder.FillFormat.SolidFillColor.Color = Color.Red;
downwardBorder.Width = 3;

var upwardBorder = table[1, 0].CellFormat.BorderDiagonalUp;
upwardBorder.FillFormat.FillType = FillType.Solid;
upwardBorder.FillFormat.SolidFillColor.Color = Color.Blue;
upwardBorder.Width = 5;

var crossDownwardBorder = table[2, 0].CellFormat.BorderDiagonalDown;
crossDownwardBorder.FillFormat.FillType = FillType.Solid;
crossDownwardBorder.FillFormat.SolidFillColor.Color = Color.Red;
crossDownwardBorder.Width = 3;

var crossUpwardBorder = table[2, 0].CellFormat.BorderDiagonalUp;
crossUpwardBorder.FillFormat.FillType = FillType.Solid;
crossUpwardBorder.FillFormat.SolidFillColor.Color = Color.Blue;
crossUpwardBorder.Width = 5;

presentation.Save("diagonal_cell_borders.pptx", SaveFormat.Pptx);
```

یک مورب یک ویژگی قالب‌بندی است، نه تقسیم سلول. هر سلول یک [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/) واحد دارد؛ نواحی هر دو طرف یک مورب نمی‌توانند به‌صورت مستقل ویرایش شوند.

جدول ذخیره‌شده، در Microsoft PowerPoint رندر شده:

![سه سلول جدول که یک مورب قرمز از بالا‑چپ به پایین‑راست، یک مورب آبی از پایین‑چپ به بالا‑راست و هر دو مورب به شکل X را نشان می‌دهند.](diagonal-cell-borders.png)

*از چپ به راست: مورب نزولی (قرمز، 3 pt)، مورب صعودی (آبی، 5 pt) و هر دو مورب.*

## **ترکیب سلول‌های جدول**

از [MergeCells](https://reference.aspose.com/slides/net/aspose.slides/itable/mergecells/) برای ترکیب یک محدودهٔ مستطیلی از سلول‌های جدول به یک سلول استفاده کنید. سلول‌های گوشهٔ بالا‑چپ و پایین‑راست محدوده را مشخص کنید. آرگومان نهایی تعیین می‌کند که ترکیب آیا می‌تواند سلول‌های خارج از محدوده مشخص‌شده را شامل شود یا نه؛ `false` ترکیب را درون همان محدوده نگه می‌دارد.

مثال یک جدول 4×4 با ستون‌ها و ردیف‌های 70‑نقطه‌ای ایجاد می‌کند، سپس چهار سلول مرکزی را از `(1, 1)` تا `(2, 2)` ترکیب می‌کند. سلول حاصل دو ستون و دو ردیف را در بر می‌گیرد، در حالی که شبکهٔ پایه جدول همچنان چهار ستون و چهار ردیف را حفظ می‌کند. برای دسترسی به محتوا یا قالب‌بندی سلول ترکیب‌شده، از موقعیت بالا‑چپ آن استفاده کنید: `table[1, 1]` در این مثال. سایر موقعیت‌ها در محدودهٔ ترکیب‌شده همچنان بخشی از شبکه جدول می‌مانند، بنابراین اندیس‌های سلول‌های خارج از محدوده تغییر نمی‌کند.

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

در مثال قبلی ترکیب سلول‌ها شبکه جدول را حفظ می‌کند. تقسیم یک سلول می‌تواند یک ستون جدید در شبکه ایجاد کند و اندیس‌های ستون‌های سمت راست آن را تغییر دهد. Aspose.Slides مدل شبکهٔ جدول PowerPoint را دنبال می‌کند.

این مثال یک جدول 4×4 با ستون‌ها و ردیف‌های 70‑نقطه‌ای ایجاد می‌کند و بر روی سلول `(1, 1)` فراخوانی می‌کند [SplitByWidth](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbywidth/). نصف عرض 70‑نقطه‌ای سلول به‌کار می‌رود تا دو سلول با عرض مساوی ایجاد شود.

پس از این تقسیم، دو نیمه به عنوان `table[1, 1]` و `table[2, 1]` دسترسی پیدا می‌کنند. شبکه جدول اکنون پنج ستون دارد: سلول‌های اصلی در ستون‌های 2 و 3 به ستون‌های 3 و 4 منتقل می‌شوند. اندیس‌های ردیف بدون تغییر می‌مانند. هنگام دسترسی به سلول‌ها پس از تقسیم، از این اندیس‌های به‌روزشدهٔ ستون استفاده کنید.

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

### **تقسیم سلول‌های ترکیب‌شده بر اساس عرض یا ارتفاع ردیف**

برای آماده‌سازی سلول‌های قالب ترکیب‌شده برای پرکردن داده، از [SplitByRowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyrowspan/) برای تقسیم بر روی یک مرز ردیف موجود یا از [SplitByColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbycolspan/) برای تقسیم بر روی یک مرز ستون استفاده کنید.

آرگومان `index` ردیف‌ها را در بخش بالایی یا ستون‌ها را در بخش چپ تقسیم می‌شمارند و نسبت به ناحیهٔ ترکیب‌شده نسبت داده می‌شود:

- تقسیم ردیفی: `0 < index <` [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/).
- تقسیم ستونی: `0 < index <` [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/).

مثال انتظار دارد ارائه یک جدول به‌عنوان اولین شکل در اولین اسلاید داشته باشد، به‌طوری که سلول‌های `(1, 2)` و `(1, 3)` به‌صورت عمودی ترکیب شده باشند. شروع از موقعیت پایین، با استفاده از [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/) و [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) مبداء را پیدا می‌کند و هر دو ترکیب را بررسی می‌کند. سپس `SplitByRowSpan(1)` ردیف‌های 2 و 3 را برای نام‌های محصول جدا می‌کند. برای ترکیب افقی دو ستونی، به جای آن از `SplitByColSpan(1)` استفاده کنید.

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

    // سلول‌های حاصل از جدول پس از تقسیم را بازیابی کنید.
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

شبکه جدول و اندیس‌های سلول‌های اطراف بدون تغییر می‌مانند. سلول‌های حاصل را بر پایهٔ مختصاتشان بازیابی کنید؛ در اینجا هر دو یک ترکیب برابر 1 دارند و [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) مقدار `False` چاپ می‌کند. نواحی بزرگ‌تر می‌توانند پس از یک تقسیم به‌صورت جزئی ترکیب‌مانده باقی بمانند.

متن اصلی و قالب‌بندی آن در سلول بالایی (یا چپ) باقی می‌ماند؛ سلول جدید خالی است اما قالب‌بندی سلول مانند پرکننده، حاشیه‌ها و حاشیهٔ داخلی را به ارث می‌برد. پس از تقسیم، سلول‌ها را پر کنید و هر قالب‌بندی متنی موردنیاز را به‌طور صریح تنظیم کنید.

ارائهٔ ذخیره‌شده شامل سلول‌های جداگانهٔ «Product A» و «Product B» است که قالب‌بندی سلول قالب اصلی را حفظ کرده‌اند. برای جزئیات بیشتر به [Cell API Reference](https://reference.aspose.com/slides/net/aspose.slides/cell/) مراجعه کنید.


<!-- visual-explanation:manage-cells:start -->
[![سلول ترکیب‌شده در ستون 1، ردیف‌های 2 و 3 به سلول‌های Product A و Product B با همان اندیس‌های شبکه تقسیم می‌شود.](visual-manage-cells-62c80896698e.svg)](visual-manage-cells-62c80896698e.svg)

*تقسیم بر اساس عرض ردیف از مرز موجود استفاده می‌کند. Product A و Product B به ترتیب (1, 2) و (1, 3) را اشغال می‌کنند.*
<!-- visual-explanation:manage-cells:end -->

### **تقسیم یک سلول در ارتفاع خاص**

[SplitByHeight](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyheight/) ارتفاع بخش بالایی را به‌واحد نقطه می‌گیرد. [SplitByRowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyrowspan/) تعداد ردیف‌های موجود در بخش بالایی را می‌گیرد. برای مرکز کردن یک سلول 40‑نقطه‌ای در ستون راست، 40 را از ارتفاع واقعی سلول کم کنید و فضای باقی‌مانده را به‌صورت مساوی بالا و پایین تقسیم کنید.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 160, 160 };
double[] rowHeights = { 140 };

var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);
table[0, 0].TextFrame.Text = "Left";

var height = table[1, 0].Height;
var margin = (height - 40) / 2;

table[1, 0].SplitByHeight(margin);
table[1, 1].SplitByHeight(40);
table[1, 1].TextFrame.Text = "Middle";

presentation.Save("split_by_height.pptx", SaveFormat.Pptx);
```

اولین تقسیم یک ردیف شبکه اضافه می‌کند و پایین‌مستقیم 90 نقطه را در `[1, 1]` می‌گذارد. تقسیم دوم هدف آن سلول است و ردیف دیگری زیر آن اضافه می‌کند. ستون راست اکنون شامل `[1, 0]` با 50 نقطه (`margin`) ، `[1, 1]` با 40 نقطه و `[1, 2]` با 50 نقطه (`margin`) است. سلول چپ تمام سه ردیف را با ارتفاع اصلی 140 نقطه در بر می‌گیرد.

![سلول چپ ارتفاع کامل جدول را در کنار سه سلول با متن Middle در مرکز می‌پوشاند.](split-by-height.png)

## **تغییر رنگ پس‌زمینه سلول جدول**

این مثال جدولی با ستون‌های 150‑نقطه‌ای و ردیف‌های 50‑نقطه‌ای ایجاد می‌کند. برای سلول `(2, 3)` که در ستون سوم و ردیف چهارم قرار دارد، [FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) را به حالت solid تنظیم می‌کند و [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/) را به رنگ قرمز تنظیم می‌کند.

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

قبل از اجرای این مثال، تصویر ورودی را در پوشهٔ کاری قرار دهید. تصویر را با استفاده از [Images.FromFile](https://reference.aspose.com/slides/net/aspose.slides/images/fromfile/) بارگیری می‌کند و به مجموعهٔ تصاویر ارائه با [AddImage](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/addimage/) اضافه می‌کند. سپس تصویر را به پرکنندهٔ تصویر سلول `(0, 0)`، اولین سلول جدول، اختصاص می‌دهد.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) تصویر را برای پر کردن سلول کش می‌کند که ممکن است نسبت ابعاد آن را تغییر دهد. عرض ستون‌ها و ارتفاع ردیف‌ها برحسب نقطه است. تصویر بارگیری‌شده به‌صورت خودکار توسط عبارت `using` پاک می‌شود.

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

## **FAQ**

**آیا می‌توانم ضخامت و سبک خطوط مختلف را برای طرف‌های مختلف یک سلول تعیین کنم؟**

بله. حاشیه‌های [بالا](https://reference.aspose.com/slides/net/aspose.slides/cellformat/bordertop/)/[پایین](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderbottom/)/[چپ](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderleft/)/[右](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderright/) دارای ویژگی‌های جداگانه‌ای هستند، بنابراین ضخامت و سبک هر طرف می‌تواند متفاوت باشد.

**اگر پس از تنظیم یک تصویر به عنوان پس‌زمینه سلول، اندازهٔ ستون/ردیف را تغییر دهم چه اتفاقی می‌افتد؟**

رفتار بسته به [حالت پرکننده](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) (کشیدن/کاشی) است. در حالت کشیدن، تصویر با سلول جدید سازگار می‌شود؛ در حالت کاشی، کاشی‌ها مجدداً محاسبه می‌شوند.

**آیا می‌توانم یک پیوند را به تمام محتوای یک سلول اختصاص دهم؟**

[Hyperlinks](/slides/fa/net/manage-hyperlinks/) در سطح بخش متن (portion) داخل قاب متن سلول یا در سطح کل جدول/شکل تنظیم می‌شود. در عمل، پیوند را به یک بخش یا به تمام متن داخل سلول اختصاص می‌دهید.

**آیا می‌توانم فونت‌های متفاوتی داخل یک سلول داشته باشم؟**

بله. قاب متن سلول از [portions](https://reference.aspose.com/slides/net/aspose.slides/portion/) (بخش‌ها) با قالب‌بندی مستقل—خانوادهٔ قلم، سبک، اندازه و رنگ—پشتیبانی می‌کند.