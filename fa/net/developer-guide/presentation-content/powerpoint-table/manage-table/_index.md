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
- نسبت ابعاد
- هم‌ترازی متن
- قالب‌بندی متن
- سبک جدول
- پاورپوینت
- ارائه
- .NET
- C#
- Aspose.Slides
description: "ایجاد و ویرایش جداول در اسلایدهای PowerPoint با Aspose.Slides برای .NET. مثال‌های ساده کد C# را برای بهینه‌سازی روند کار با جداول کشف کنید."
---
## **مقدمه**

یک جدول در PowerPoint یک روش کارآمد برای نمایش و بیان اطلاعات است. اطلاعات در یک شبکه از سلول‌ها (مرتب شده در سطرها و ستون‌ها) ساده و به راحتی قابل درک است.

Aspose.Slides کلاس [Table](https://reference.aspose.com/slides/fa/net/aspose.slides/table/)، اینترفیس [ITable](https://reference.aspose.com/slides/fa/net/aspose.slides/itable/)، کلاس [Cell](https://reference.aspose.com/slides/fa/net/aspose.slides/cell/)، اینترفیس [ICell](https://reference.aspose.com/slides/fa/net/aspose.slides/icell/) و انواع دیگر را فراهم می‌کند تا بتوانید جداول را در انواع ارائه‌ها ایجاد، به‌روزرسانی و مدیریت کنید.

## **ایجاد جدول از صفر**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.  
2. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.  
3. یک آرایه از `columnWidth` تعریف کنید.  
4. یک آرایه از `rowHeight` تعریف کنید.  
5. یک شیء [ITable](https://reference.aspose.com/slides/fa/net/aspose.slides/itable/) را از طریق متد [AddTable](https://reference.aspose.com/slides/fa/net/aspose.slides/ishapecollection/addtable/) به اسلاید اضافه کنید.  
6. از طریق هر [ICell](https://reference.aspose.com/slides/fa/net/aspose.slides/icell/) پیمایش کنید تا قالب‌بندی را بر روی حاشیه‌های بالا، پایین، راست و چپ اعمال کنید.  
7. دو سلول اول ردیف اول جدول را ادغام کنید.  
8. به [TextFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/textframe/) یک [ICell](https://reference.aspose.com/slides/fa/net/aspose.slides/icell/) دسترسی پیدا کنید.  
9. متنی به [TextFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/textframe/) اضافه کنید.  
10. ارائه اصلاح‌شده را ذخیره کنید.

این کد C# نشان می‌دهد چگونه یک جدول را در یک ارائه ایجاد کنید:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// نمونه‌سازی یک کلاس Presentation که فایل PPTX را نمایش می‌دهد
Presentation pres = new Presentation();

// به اولین اسلاید دسترسی پیدا می‌کند
ISlide sld = pres.Slides[0];

// ستون‌ها را با عرض و ردیف‌ها را با ارتفاع تعریف می‌کند
double[] dblCols = { 50, 50, 50 };
double[] dblRows = { 50, 30, 30, 30, 30 };

// یک شکل جدول را به اسلاید اضافه می‌کند
ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

// قالب حاشیه را برای هر سلول تنظیم می‌کند
for (int row = 0; row < tbl.Rows.Count; row++)
{
	for (int cell = 0; cell < tbl.Rows[row].Count; cell++)
	{
		tbl.Rows[row][cell].CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
		tbl.Rows[row][cell].CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderTop.Width = 5;

		tbl.Rows[row][cell].CellFormat.BorderBottom.FillFormat.FillType = (FillType.Solid);
		tbl.Rows[row][cell].CellFormat.BorderBottom.FillFormat.SolidFillColor.Color= Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderBottom.Width =5;

		tbl.Rows[row][cell].CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
		tbl.Rows[row][cell].CellFormat.BorderLeft.FillFormat.SolidFillColor.Color =Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderLeft.Width = 5;

		tbl.Rows[row][cell].CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
		tbl.Rows[row][cell].CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderRight.Width = 5;
	}
}
// سلول‌های 1 و 2 ردیف 1 را ادغام می‌کند
tbl.MergeCells(tbl.Rows[0][0], tbl.Rows[0][1], false);

// متنی به سلول ادغام‌شده اضافه می‌کند
tbl.Rows[0][0].TextFrame.Text = "Merged Cells";

// ارائه را در دیسک ذخیره می‌کند
pres.Save("table.pptx", SaveFormat.Pptx);
```

## **شماره‌گذاری در جدول استاندارد**

در یک جدول استاندارد، شماره‌گذاری سلول‌ها ساده و صفر مبنا است. اولین سلول در جدول با اندیس 0,0 (ستون 0، سطر 0) مشخص می‌شود.

به عنوان مثال، سلول‌های یک جدول با 4 ستون و 4 سطر به این صورت شماره‌گذاری می‌شوند:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

این کد C# جدول استاندارد 4 × 4 شماره‌گذاری شده در بالا را ایجاد می‌کند و قالب حاشیه هر یک از سلول‌های آن را تنظیم می‌نماید:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// یک شیء از کلاس Presentation ایجاد می‌کند که فایل PPTX را نمایندگی می‌کند
using (Presentation pres = new Presentation())
{

    // به اولین اسلاید دسترسی می‌یابد
    ISlide sld = pres.Slides[0];

    // ستون‌ها را با عرض‌ها و ردیف‌ها را با ارتفاع‌ها تعریف می‌کند
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // یک شکل جدول را به اسلاید اضافه می‌کند
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // قالب حاشیه را برای هر سلول تنظیم می‌کند
    foreach (IRow row in tbl.Rows)
    {
        foreach (ICell cell in row)
        {
			cell.CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
			cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
			cell.CellFormat.BorderTop.Width = 5;

			cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
			cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
			cell.CellFormat.BorderBottom.Width = 5;

			cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
			cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
			cell.CellFormat.BorderLeft.Width = 5;

			cell.CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
			cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
			cell.CellFormat.BorderRight.Width = 5;
        }
    }

    // ارائه را در دیسک ذخیره می‌کند
    pres.Save("StandardTables_out.pptx", SaveFormat.Pptx);
}
```

## **دسترسی به جدول موجود**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.  
2. مرجع اسلایدی که حاوی جدول است را از طریق ایندکس آن دریافت کنید.  
3. یک شیء [ITable](https://reference.aspose.com/slides/fa/net/aspose.slides/itable/) ایجاد کنید و آن را `null` کنید.  
4. تا پیدا شدن جدول، از تمام اشیاء [IShape](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/) پیمایش کنید.  

   اگر گمان می‌کنید اسلاید مورد نظر تنها یک جدول دارد، می‌توانید تمام اشکالی که شامل آن می‌شود را بررسی کنید. وقتی یک شکل به عنوان جدول شناسایی شد، می‌توانید آن را به شیء [Table](https://reference.aspose.com/slides/fa/net/aspose.slides/table/) تبدیل کنید. اما اگر اسلاید چندین جدول داشته باشد، بهتر است جدول مورد نیاز را از طریق ویژگی [AlternativeText](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/alternativetext/) جستجو کنید.  

5. از شیء [ITable](https://reference.aspose.com/slides/fa/net/aspose.slides/itable/) برای کار با جدول استفاده کنید. در مثال زیر یک ردیف جدید به جدول اضافه شد.  
6. ارائه اصلاح‌شده را ذخیره کنید.

این کد C# نشان می‌دهد چگونه به یک جدول موجود دسترسی پیدا کنید و با آن کار کنید:

```c#
using Aspose.Slides;

// یک شیء از کلاس Presentation ایجاد می‌کند که فایل PPTX را نمایندگی می‌کند
using (Presentation pres = new Presentation("UpdateExistingTable.pptx"))
{

    // به اولین اسلاید دسترسی می‌یابد
    ISlide sld = pres.Slides[0];

    // متغیر TableEx را به null مقداردهی می‌کند
    ITable tbl = null;

    // از طریق اشکال پیمایش می‌کند و مرجع جدول یافت‌شده را تنظیم می‌نماید
    foreach (IShape shp in sld.Shapes)
        if (shp is ITable)
            tbl = (ITable)shp;

    // متن را برای ستون اول ردیف دوم تنظیم می‌کند
    tbl[0, 1].TextFrame.Text = "New";

    // ارائه‌ اصلاح‌شده را بر روی دیسک ذخیره می‌کند
    pres.Save("table1_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **یافتن سلولی که مالک یک قاب متن است**

هنگامی که کد عمومی پردازش متن یک [ITextFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/) را از یک جدول دریافت می‌کند، از ویژگی [ITextFrame.ParentCell](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/parentcell/) برای بازیابی [ICell](https://reference.aspose.com/slides/fa/net/aspose.slides/icell/) صاحب استفاده کنید. برای یک قاب متن سلول‑جدول، [ITextFrame.ParentCell](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/parentcell/) تنظیم شده و [ITextFrame.ParentShape](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/parentshape/) مقدار `null` دارد، حتی اگر خود جدول یک شکل باشد.

مختصات سلول از طریق ویژگی‌های فقط‑خواندنی [ICell.FirstColumnIndex](https://reference.aspose.com/slides/fa/net/aspose.slides/icell/firstcolumnindex/) و [ICell.FirstRowIndex](https://reference.aspose.com/slides/fa/net/aspose.slides/icell/firstrowindex/) در دسترس است. [ITextFrame.ParentCell](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/parentcell/) نیز فقط‑خواندنی است: مسیریابی به مالک را فراهم می‌کند اما مالکیت را تغییر نمی‌دهد. همیشه قبل از استفاده مقدار برگشتی را برای `null` بررسی کنید.

برای یک مثال کامل که مالکین سلول‑جدول و شکل را شناسایی می‌کند، از جمله شکل‌های مرتبط با گره‌های SmartArt، به صفحه [Search and Replace Text](/slides/fa/net/search-and-replace-text/) مراجعه کنید.

## **هم‌ترازی متن در جدول**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.  
2. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.  
3. یک شیء [ITable](https://reference.aspose.com/slides/fa/net/aspose.slides/itable/) را به اسلاید اضافه کنید.  
4. یک شیء [ITextFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/) را از جدول به دست آورید.  
5. به [IParagraph](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraph/) موجود در [ITextFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/) دسترسی پیدا کنید.  
6. متن را به صورت عمودی هم‌تراز کنید.  
7. ارائه اصلاح‌شده را ذخیره کنید.

این کد C# نشان می‌دهد چگونه متن را در یک جدول هم‌تراز کنید:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Creates an instance of the Presentation class
Presentation presentation = new Presentation();

// Gets the first slide 
ISlide slide = presentation.Slides[0];

// Defines columns with widths and rows with heights
double[] dblCols = { 120, 120, 120, 120 };
double[] dblRows = { 100, 100, 100, 100 };

// Adds the table shape to the slide
ITable tbl = slide.Shapes.AddTable(100, 50, dblCols, dblRows);
tbl[1, 0].TextFrame.Text = "10";
tbl[2, 0].TextFrame.Text = "20";
tbl[3, 0].TextFrame.Text = "30";

// Accesses the text frame
ITextFrame txtFrame = tbl[0, 0].TextFrame;

// Creates the Paragraph object for the text frame
IParagraph paragraph = txtFrame.Paragraphs[0];

// Creates the Portion object for paragraph
IPortion portion = paragraph.Portions[0];
portion.Text = "Text here";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Aligns the text vertically
ICell cell = tbl[0, 0];
cell.TextAnchorType = TextAnchorType.Center;
cell.TextVerticalType = TextVerticalType.Vertical270;

// Saves the presentation to disk
presentation.Save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
```

## **تنظیم قالب‌بندی متن در سطح جدول**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) ایجاد کنید.  
2. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.  
3. یک شیء [ITable](https://reference.aspose.com/slides/fa/net/aspose.slides/itable/) را از اسلاید به دست آورید.  
4. ارتفاع فونت ([FontHeight](https://reference.aspose.com/slides/fa/net/aspose.slides/baseportionformat/fontheight/)) را برای متن تنظیم کنید.  
5. ویژگی‌های [Alignment](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraphformat/alignment/) و [MarginRight](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraphformat/marginright/) را تنظیم کنید.  
6. [TextVerticalType](https://reference.aspose.com/slides/fa/net/aspose.slides/textframeformat/textverticaltype/) را تعیین کنید.  
7. ارائه اصلاح‌شده را ذخیره کنید.

این کد C# نشان می‌دهد چگونه گزینه‌های قالب‌بندی دلخواه خود را بر متن در یک جدول اعمال کنید:

```c#
using Aspose.Slides;

// یک نمونه از کلاس Presentation ایجاد می‌کند
Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // فرض می‌کنیم اولین شکل در اسلاید اول یک جدول است

// ارتفاع قلم سلول‌های جدول را تنظیم می‌کند
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.SetTextFormat(portionFormat);

// ترازبندی متن سلول‌های جدول و حاشیه راست را در یک فراخوانی تنظیم می‌کند
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.SetTextFormat(paragraphFormat);

// نوع عمودی متن سلول‌های جدول را تنظیم می‌کند
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.SetTextFormat(textFrameFormat);


presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **دریافت ویژگی‌های سبک جدول**

Aspose.Slides به شما اجازه می‌دهد ویژگی‌های سبک یک جدول را دریافت کنید تا بتوانید این جزئیات را برای جدول دیگری یا در مکان دیگری استفاده کنید. این کد C# نشان می‌دهد چگونه ویژگی‌های سبک را از یک سبک پیش‌تنظیم شده جدول دریافت کنید:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // تغییر تم پیش‌تنظیم پیش‌فرض سبک

    // دریافت پیش‌تنظیم سبک جدول.
    TableStylePreset stylePreset = table.StylePreset;
    Console.WriteLine($"Table style preset: {stylePreset}");

    // اعمال پیش‌تنظیم سبک بازیابی‌شده به جدول دیگری.
    ITable anotherTable = pres.Slides[0].Shapes.AddTable(10, 100, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    anotherTable.StylePreset = stylePreset;

    pres.Save("table.pptx", SaveFormat.Pptx);
}
```

## **قفل کردن نسبت ابعاد جدول**

نسبت ابعاد یک شکل هندسی نسبت اندازه‌های آن در ابعاد مختلف است. Aspose.Slides ویژگی `AspectRatioLocked` را فراهم کرده تا بتوانید تنظیم قفل نسبت ابعاد را برای جدول‌ها و سایر اشکال اعمال کنید.

این کد C# نشان می‌دهد چگونه نسبت ابعاد یک جدول را قفل کنید:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
    ITable table = (ITable)pres.Slides[0].Shapes[0];
    Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

    table.ShapeLock.AspectRatioLocked = !table.ShapeLock.AspectRatioLocked; // معکوس

    Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**آیا می‌توان جهت‌خوانی راست به چپ (RTL) را برای کل جدول و متن داخل سلول‌های آن فعال کرد؟**

بله. جدول ویژگی [RightToLeft](https://reference.aspose.com/slides/fa/net/aspose.slides/table/righttoleft/) را در اختیار می‌گذارد و پاراگراف‌ها نیز ویژگی [ParagraphFormat.RightToLeft](https://reference.aspose.com/slides/fa/net/aspose.slides/paragraphformat/righttoleft/) دارند. استفاده همزمان از هر دو، ترتیب و رندرینگ صحیح RTL را داخل سلول‌ها تضمین می‌کند.

**چگونه می‌توانم جلوگیری کنم که کاربران جدول را در فایل نهایی جابجا یا اندازه‌اش را تغییر دهند؟**

از [قفل‌های شکل](/slides/fa/net/applying-protection-to-presentation/) استفاده کنید تا جابجا کردن، تغییر اندازه، انتخاب و … غیر فعال شوند. این قفل‌ها بر روی جداول نیز اعمال می‌شوند.

**آیا قرار دادن تصویر به عنوان پس‌زمینه داخل سلول پشتیبانی می‌شود؟**

بله. می‌توانید برای یک سلول [picture fill](https://reference.aspose.com/slides/fa/net/aspose.slides/picturefillformat/) تنظیم کنید؛ تصویر بر اساس حالت انتخابی (کشسان یا کاشی) ناحیه سلول را پوشش می‌دهد.