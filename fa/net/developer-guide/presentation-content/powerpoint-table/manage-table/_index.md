---
title: مدیریت جداول ارائه در .NET
linktitle: مدیریت جدول
type: docs
weight: 10
url: /fa/net/manage-table/
keywords:
- افزودن جدول
- ایجاد جدول
- دسترسی به جدول
- نسبت عرض به ارتفاع
- هم‌ترازی متن
- قالب‌بندی متن
- سبک جدول
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "ایجاد و ویرایش جداول در اسلایدهای PowerPoint با Aspose.Slides برای .NET. مثال‌های ساده کد C# را برای ساده‌سازی جریان کار جداول خود کشف کنید."
---
## **مقدمه**

جداول در پاورپوینت اطلاعات را به صورت سطر و ستون سازماندهی می‌کنند و خواندن و مقایسه مقادیر را آسان‌تر می‌سازند.

Aspose.Slides کلاس [Table](https://reference.aspose.com/slides/net/aspose.slides/table/) ، رابط [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) ، کلاس [Cell](https://reference.aspose.com/slides/net/aspose.slides/cell/) ، رابط [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) و انواع دیگر را فراهم می‌کند تا بتوانید جداول را در ارائه‌ها ایجاد، به‌روزرسانی و مدیریت کنید.

## **ایجاد جدول از ابتدا**

یک جدول را با تعیین موقعیت، عرض ستون‌ها و ارتفاع سطرها ایجاد کنید. پس از افزودن آن به اسلاید، می‌توانید حاشیه‌های سلول‌ها را قالب‌بندی کنید، سلول‌ها را ادغام کنید و متن وارد کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) ایجاد کنید.  
2. یک ارجاع به اسلاید را بر اساس ایندکس آن به‌دست آورید.  
3. یک آرایه از عرض ستون‌ها بر حسب پوینت تعریف کنید.  
4. یک آرایه از ارتفاع سطرها بر حسب پوینت تعریف کنید.  
5. یک شیء [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) را با استفاده از متد [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/) به اسلاید اضافه کنید.  
6. از هر [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) عبور کنید تا قالب‌بندی حاشیه‌های بالا، پایین، راست و چپ را اعمال کنید.  
7. دو سلول اول ردیف اول جدول را ادغام کنید.  
8. از سلول ادغام‌شده از طریق ویژگی [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/) آن دسترسی پیدا کنید.  
9. متن را در سلول ادغام‌شده تنظیم کنید.  
10. ارائه اصلاح‌شده را ذخیره کنید.

مثال زیر جدولی با سه ستون و پنج ردیف در موقعیت (100, 50) پوینت ایجاد می‌کند. حاشیه‌های قرمز با عرض 5 پوینت اعمال می‌شود، دو سلول اول ردیف اول ادغام می‌شوند و نتیجه به صورت `table.pptx` ذخیره می‌شود.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 50, 50, 50 };
var rowHeights = new double[] { 50, 30, 30, 30, 30 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

foreach (var row in table.Rows)
{
    foreach (var cell in row)
    {
        var cellFormat = cell.CellFormat;
        cellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderTop.Width = 5;

        cellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderBottom.Width = 5;

        cellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderLeft.Width = 5;

        cellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderRight.Width = 5;
    }
}

table.MergeCells(table[0, 0], table[1, 0], false);
table[0, 0].TextFrame.Text = "Merged Cells";

presentation.Save("table.pptx", SaveFormat.Pptx);
```

## **شماره‌گذاری در جدول استاندارد**

در یک جدول استاندارد، شاخص‌های سلول‌ها از صفر شروع می‌شوند و به ترتیب (ستون، ردیف) استفاده می‌شوند. اولین سلول به صورت (0, 0) شماره‌گذاری می‌شود.

برای مثال، سلول‌های یک جدول با 4 ستون و 4 ردیف به این شکل شماره‌گذاری می‌شوند:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

این مثال جدول 4×4 نشان‌داده‌شده در بالا را ایجاد می‌کند، با عرض ستون‌ها و ارتفاع سطرها برابر 70 پوینت و حاشیه‌های سلول قرمز با عرض 5 پوینت. مختصات شاخص‌های سلول‌ها را نشان می‌دهند؛ این مثال سلول‌ها را خالی می‌گذارد و جدول را به صورت `StandardTables_out.pptx` ذخیره می‌کند.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 70, 70, 70, 70 };
var rowHeights = new double[] { 70, 70, 70, 70 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

foreach (var row in table.Rows)
{
    foreach (var cell in row)
    {
        var cellFormat = cell.CellFormat;
        cellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderTop.Width = 5;

        cellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderBottom.Width = 5;

        cellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderLeft.Width = 5;

        cellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderRight.Width = 5;
    }
}

presentation.Save("StandardTables_out.pptx", SaveFormat.Pptx);
```

## **دسترسی به جدول موجود**

جداول در مجموعه شکل‌های یک اسلاید ذخیره می‌شوند. با عبور از شکل‌ها جدول را پیدا کنید، سپس از رابط [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) برای خواندن یا به‌روزرسانی سلول‌های آن استفاده کنید.

1. ارائه را با استفاده از کلاس [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) بارگذاری کنید.  
2. یک ارجاع به اسلاید حاوی جدول را بر اساس ایندکس آن به دست آورید.  
3. از اشیاء [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) عبور کنید و وقتی جدول یافت شد متوقف شوید. اگر اسلاید شامل چندین جدول باشد، از [AlternativeText](https://reference.aspose.com/slides/net/aspose.slides/ishape/alternativetext/) برای شناسایی جدول مورد نیاز استفاده کنید.  
4. متن سلول هدف را به‌روزرسانی کنید.  
5. ارائه اصلاح‌شده را ذخیره کنید.

مثال زیر فایل `UpdateExistingTable.pptx` را باز می‌کند و اولین جدول در اولین اسلاید را پیدا می‌کند. سلول در ستون 0، ردیف 1 را به `New` تنظیم می‌کند و نتیجه را به صورت `table1_out.pptx` ذخیره می‌کند. ورودی باید حداقل یک اسلاید داشته باشد و اولین جدول در آن اسلاید باید حداقل یک ستون و دو ردیف داشته باشد.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("UpdateExistingTable.pptx");
var slide = presentation.Slides[0];
ITable? table = null;

foreach (var shape in slide.Shapes)
{
    if (shape is ITable candidateTable)
    {
        table = candidateTable;
        break;
    }
}

table![0, 1].TextFrame.Text = "New";

presentation.Save("table1_out.pptx", SaveFormat.Pptx);
```

برای تغییر اندازه یک ردیف در جدول موجود و درک اینکه چرا ارتفاع واقعی آن می‌تواند بیش از حداقل درخواست‌شده باشد، به [Control Row Height](/slides/fa/net/manage-rows-and-columns/#control-row-height) مراجعه کنید.

## **پیدا کردن سلولی که Text Frame را داراست**

زمانی که کد عمومی پردازش متن یک [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) را از جدول دریافت می‌کند، از ویژگی [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) برای دریافت [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) مالک استفاده کنید. برای یک فریم متن سلول جدول، [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) تنظیم شده و [ITextFrame.ParentShape](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentshape/) برابر `null` است، حتی اگر جدول خود یک شکل باشد.

مختصات سلول از طریق ویژگی‌های فقط‑خواندنی [ICell.FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/) و [ICell.FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) قابل دسترسی هستند. همچنین [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) فقط خواندنی است: ناوبری به مالک را فراهم می‌کند اما مالکیت را تغییر نمی‌دهد. همیشه قبل از استفاده از سلول، بررسی کنید که مقدار برگشتی `null` نیست.

برای یک مثال کامل که مالکان سلول جدول و شکل را شناسایی می‌کند، از جمله شکل‌های مرتبط با نودهای SmartArt، به [Search and Replace Text](/slides/fa/net/search-and-replace-text/) مراجعه کنید.

## **هم‌ترازی متن در جدول**

می‌توانید تثبیت عمودی و جهت متن سلول‌های منفرد جدول را کنترل کنید. مثال در این بخش متن را در داخل اولین سلول مرکز می‌کند و به اندازه 270 درجه می‌چرخاند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) ایجاد کنید.  
2. یک ارجاع به اسلاید را بر اساس ایندکس آن به‌دست آورید.  
3. یک شیء [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) را به اسلاید اضافه کنید.  
4. یک شیء [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) را از جدول دریافت کنید.  
5. اولین [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) را دریافت کنید و متن و رنگ آن را تنظیم کنید.  
6. ویژگی‌های [TextAnchorType](https://reference.aspose.com/slides/net/aspose.slides/icell/textanchortype/) و [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/icell/textverticaltype/) سلول را تنظیم کنید.  
7. ارائه اصلاح‌شده را ذخیره کنید.

این مثال جدولی 4×4 با عرض ستون 120 پوینت و ارتفاع سطر 100 پوینت ایجاد می‌کند. متن سلول (0, 0) را قالب‌بندی می‌کند، مقادیر را به سلول‌های باقی‌مانده در ردیف اول اضافه می‌نماید و نتیجه را به صورت `Vertical_Align_Text_out.pptx` ذخیره می‌کند.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 120, 120, 120, 120 };
var rowHeights = new double[] { 100, 100, 100, 100 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);
table[1, 0].TextFrame.Text = "10";
table[2, 0].TextFrame.Text = "20";
table[3, 0].TextFrame.Text = "30";

var cell = table[0, 0];
var paragraph = cell.TextFrame.Paragraphs[0];
var portion = paragraph.Portions[0];
portion.Text = "Text here";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

cell.TextAnchorType = TextAnchorType.Center;
cell.TextVerticalType = TextVerticalType.Vertical270;

presentation.Save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
```

## **تنظیم قالب‌بندی متن در سطح جدول**

از [SetTextFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulktextformattable/settextformat/) برای اعمال قالب‌بندی متن بر تمام سلول‌های یک جدول استفاده کنید. overloadهای آن می‌توانند قالب‌بندی بخش، پاراگراف و فریم متن را بپذیرند، بنابراین می‌توانید این ویژگی‌ها را بدون عبور از سلول‌های منفرد تنظیم کنید.

1. ارائه را با استفاده از کلاس [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) بارگذاری کنید.  
2. یک ارجاع به اسلاید را بر اساس ایندکس آن به دست آورید.  
3. یک شیء [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) را از اسلاید دریافت کنید.  
4. ارتفاع قلم [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) را برای متن تنظیم کنید.  
5. چیدمان [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) و حاشیه سمت راست [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) را تنظیم کنید.  
6. ویژگی [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) را تنظیم کنید.  
7. ارائه اصلاح‌شده را ذخیره کنید.

مثال زیر فایل `table.pptx` را باز می‌کند که باید حداقل یک اسلاید داشته باشد که جدول به عنوان اولین شکل آن باشد. اندازه قلم را به 25 پوینت تنظیم می‌کند، پاراگراف‌ها را به راست تراز می‌کند با حاشیه راست 20 پوینت، و متن را عمودی می‌کند. ارائه قالب‌بندی‌شده به صورت `result.pptx` ذخیره می‌شود.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

var portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
table.SetTextFormat(portionFormat);

var paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
table.SetTextFormat(paragraphFormat);

var textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
table.SetTextFormat(textFrameFormat);

presentation.Save("result.pptx", SaveFormat.Pptx);
```

## **دریافت ویژگی‌های سبک جدول**

از [StylePreset](https://reference.aspose.com/slides/net/aspose.slides/itable/stylepreset/) برای خواندن یا انتساب یک سبک پیش‌فرض به جدول استفاده کنید. این مثال [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/net/aspose.slides/tablestylepreset/) را به یک جدول اعمال می‌کند، نام پیش‌فرض را چاپ می‌کند و همان پیش‌فرض را به جدول دوم انتساب می‌دهد. هر دو جدول در `table-style.pptx` ذخیره می‌شوند.

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

var stylePreset = table.StylePreset;
Console.WriteLine($"Table style preset: {stylePreset}");

var anotherTable = slide.Shapes.AddTable(10, 100, columnWidths, rowHeights);
anotherTable.StylePreset = stylePreset;

presentation.Save("table-style.pptx", SaveFormat.Pptx);
```

## **قفل کردن نسبت عرض به ارتفاع جدول**

نسبت عرض به ارتفاع یک جدول، نسبت عرض آن به ارتفاع است. از [AspectRatioLocked](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/aspectratiolocked/) برای قفل کردن این نسبت برای یک جدول استفاده کنید.

مثال زیر فایل `pres.pptx` را باز می‌کند که باید حداقل یک اسلاید داشته باشد که جدول به عنوان اولین شکل آن باشد. وضعیت قفل فعلی را چاپ می‌کند، قفل نسبت عرض به ارتفاع را فعال می‌کند، وضعیت به‌روزرسانی‌شده (`True`) را چاپ می‌کند و نتیجه را به صورت `pres-out.pptx` ذخیره می‌کند.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

table.ShapeLock.AspectRatioLocked = true;
Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

presentation.Save("pres-out.pptx", SaveFormat.Pptx);
```

## **FAQ**

**آیا می‌توانم جهت خواندن راست به چپ (RTL) را برای کل جدول و متن در سلول‌های آن فعال کنم؟**

بله. جدول دارای ویژگی [RightToLeft](https://reference.aspose.com/slides/net/aspose.slides/table/righttoleft/) ، و پاراگراف‌ها دارای [ParagraphFormat.RightToLeft](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/righttoleft/) هستند. استفاده از هر دو تضمین می‌کند که ترتیب و رندر صحیح RTL داخل سلول‌ها برقرار باشد.

**چگونه می‌توانم مانع از جابجا یا تغییر اندازه جدول در فایل نهایی شوم؟**

از [shape locks](/slides/fa/net/applying-protection-to-presentation/) استفاده کنید تا جابجایی، تغییر اندازه، انتخاب و غیره را غیرفعال کنید. این قفل‌ها همچنین بر جداول اعمال می‌شوند.

**آیا درج تصویر به عنوان پس‌زمینه درون یک سلول پشتیبانی می‌شود؟**

بله. می‌توانید برای یک سلول [picture fill](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/) تنظیم کنید؛ تصویر بر اساس حالت انتخاب‌شده (کشیده یا کاشی) کل منطقه سلول را پوشش می‌دهد.