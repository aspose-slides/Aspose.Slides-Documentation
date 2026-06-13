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
- تراز متن
- قالب‌بندی متن
- سبک جدول
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "ایجاد و ویرایش جداول در اسلایدهای PowerPoint با Aspose.Slides برای .NET. با مثال‌های ساده C#، جریان کار جداول خود را بهینه کنید."
---
## **مقدمه**

یک جدول در PowerPoint روشی کارآمد برای نمایش و ارائه اطلاعات است. اطلاعات در یک شبکهٔ سلول‌ها (که به صورت ردیف و ستون مرتب شده‌اند) ساده و به راحتی قابل درک است.

Aspose.Slides کلاس [Table](https://reference.aspose.com/slides/fa/net/aspose.slides/table/) ، اینترفیس [ITable](https://reference.aspose.com/slides/fa/net/aspose.slides/itable/) ، کلاس [Cell](https://reference.aspose.com/slides/fa/net/aspose.slides/cell/) ، اینترفیس [ICell](https://reference.aspose.com/slides/fa/net/aspose.slides/icell/) و سایر انواع را فراهم می‌کند تا بتوانید جداول را در تمام انواع ارائه‌ها ایجاد، به‌روزرسانی و مدیریت کنید. 

## **ایجاد جدول از ابتدا**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.  
2. با استفاده از ایندکس، مرجع اسلاید را دریافت کنید.  
3. آرایه‌ای از `columnWidth` تعریف کنید.  
4. آرایه‌ای از `rowHeight` تعریف کنید.  
5. یک شیء [ITable](https://reference.aspose.com/slides/fa/net/aspose.slides/itable/) را به اسلاید اضافه کنید با استفاده از متد [AddTable](https://reference.aspose.com/slides/fa/net/aspose.slides/ishapecollection/addtable/).  
6. بر روی هر [ICell](https://reference.aspose.com/slides/fa/net/aspose.slides/icell/) تکرار کنید تا قالب‌بندی مرزهای بالا، پایین، راست و چپ اعمال شود.  
7. دو سلول اول ردیف اول جدول را ادغام کنید.  
8. به [TextFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/textframe/) یک [ICell](https://reference.aspose.com/slides/fa/net/aspose.slides/icell/) دسترسی پیدا کنید.  
9. متنی به [TextFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/textframe/) اضافه کنید.  
10. ارائهٔ اصلاح‌شده را ذخیره کنید.

این کد C# نشان می‌دهد چگونه در یک ارائه جدول ایجاد کنید:

```c#
// یک شیء از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل PPTX است
Presentation pres = new Presentation();

// به اولین اسلاید دسترسی می‌یابد
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
tbl.MergeCells(tbl.Rows[0][0], tbl.Rows[1][1], false);

// متنی به سلول ادغام‌شده اضافه می‌کند
tbl.Rows[0][0].TextFrame.Text = "Merged Cells";

// ارائه را بر روی دیسک ذخیره می‌کند
pres.Save("table.pptx", SaveFormat.Pptx);
```

## **شماره‌گذاری در جدول استاندارد**

در یک جدول استاندارد، شماره‌گذاری سلول‌ها ساده و مبتنی بر صفر است. اولین سلول در جدول به صورت 0,0 (ستون 0، ردیف 0) ایندکس می‌شود.  

به عنوان مثال، سلول‌های یک جدول با 4 ستون و 4 ردیف به این شکل شماره‌گذاری می‌شوند:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

این کد C# نشان می‌دهد چگونه شماره‌گذاری سلول‌های یک جدول را مشخص کنید:

```c#
// یک شیء از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل PPTX است
using (Presentation pres = new Presentation())
{

    // به اولین اسلاید دسترسی می‌یابد
    ISlide sld = pres.Slides[0];

    // ستون‌ها را با عرض و ردیف‌ها را با ارتفاع تعریف می‌کند
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

    // ارائه را بر روی دیسک ذخیره می‌کند
    pres.Save("StandardTables_out.pptx", SaveFormat.Pptx);
}
```

## **دسترسی به جدول موجود**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.  

2. مرجع اسلاید حاوی جدول را از طریق ایندکس آن دریافت کنید.  

3. یک شیء [ITable](https://reference.aspose.com/slides/fa/net/aspose.slides/itable/) ایجاد کنید و مقدار آن را null تنظیم کنید.  

4. بر تمام اشیای [IShape](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/) تکرار کنید تا جدول پیدا شود.  

   اگر گمان می‌کنید اسلاید حاوی یک جدول است، می‌توانید به سادگی تمام شکل‌ها را بررسی کنید. زمانی که یک شکل به عنوان جدول شناسایی شد، می‌توانید آن را به شیء [Table](https://reference.aspose.com/slides/fa/net/aspose.slides/table/) تبدیل کنید. اما اگر اسلاید شامل چند جدول باشد، بهتر است جدول مورد نیاز خود را از طریق ویژگی [AlternativeText](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/alternativetext/) جستجو کنید.  

5. از شیء [ITable](https://reference.aspose.com/slides/fa/net/aspose.slides/itable/) برای کار با جدول استفاده کنید. در مثال زیر یک ردیف جدید به جدول اضافه کردیم.  

6. ارائهٔ اصلاح‌شده را ذخیره کنید.  

این کد C# نشان می‌دهد چگونه به جدول موجود دسترسی پیدا کنید و با آن کار کنید:

```c#
// یک شیء از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل PPTX است
using (Presentation pres = new Presentation("UpdateExistingTable.pptx"))
{

    // به اولین اسلاید دسترسی می‌یابد
    ISlide sld = pres.Slides[0];

    // مقدار اولیه TableEx را null می‌کند
    ITable tbl = null;

    // از اشکال عبور می‌کند و مرجع جدول یافت‌شده را تنظیم می‌نماید
    foreach (IShape shp in sld.Shapes)
        if (shp is ITable)
            tbl = (ITable)shp;

    // متن را برای ستون اول ردیف دوم تنظیم می‌کند
    tbl[0, 1].TextFrame.Text = "New";

    // ارائهٔ اصلاح‌شده را بر روی دیسک ذخیره می‌کند
    pres.Save("table1_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **تراز کردن متن در جدول**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.  
2. مرجع اسلاید را از طریق ایندکس دریافت کنید.  
3. یک شیء [ITable](https://reference.aspose.com/slides/fa/net/aspose.slides/itable/) را به اسلاید اضافه کنید.  
4. از جدول، یک شیء [ITextFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/) دریافت کنید.  
5. از [ITextFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/)، شیء [IParagraph](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraph/) دریافت کنید.  
6. متن را به صورت عمودی تراز کنید.  
7. ارائهٔ اصلاح‌شده را ذخیره کنید.  

این کد C# نشان می‌دهد چگونه متن را در یک جدول تراز کنید:

```c#
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
2. مرجع اسلاید را از طریق ایندکس دریافت کنید.  
3. از اسلاید، یک شیء [ITable](https://reference.aspose.com/slides/fa/net/aspose.slides/itable/) دریافت کنید.  
4. برای متن، مقدار [FontHeight](https://reference.aspose.com/slides/fa/net/aspose.slides/baseportionformat/fontheight/) را تنظیم کنید.  
5. [Alignment](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraphformat/alignment/) و [MarginRight](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraphformat/marginright/) را تنظیم کنید.  
6. [TextVerticalType](https://reference.aspose.com/slides/fa/net/aspose.slides/textframeformat/textverticaltype/) را تنظیم کنید.  
7. ارائهٔ اصلاح‌شده را ذخیره کنید.  

این کد C# نشان می‌دهد چگونه گزینه‌های قالب‌بندی دلخواه خود را بر روی متن در یک جدول اعمال کنید:

```c#
// یک نمونه از کلاس Presentation ایجاد می‌کند
Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // فرض می‌کنیم اولین شکل در اولین اسلاید یک جدول است

// ارتفاع قلم سلول‌های جدول را تنظیم می‌کند
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.SetTextFormat(portionFormat);

// تراز متن سلول‌های جدول و حاشیه راست را در یک فراخوانی تنظیم می‌کند
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.SetTextFormat(paragraphFormat);

// نوع متن عمودی سلول‌های جدول را تنظیم می‌کند
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.SetTextFormat(textFrameFormat);


presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **دریافت ویژگی‌های سبک جدول**

Aspose.Slides به شما امکان می‌دهد ویژگی‌های سبک یک جدول را دریافت کنید تا بتوانید این جزئیات را برای جدول دیگری یا مکان دیگری استفاده کنید. این کد C# نشان می‌دهد چگونه ویژگی‌های سبک را از یک سبک پیش‌فرض جدول دریافت کنید:

```c#
using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // تغییر تم پیش‌فرض پیش‌تنظیم سبک
    pres.Save("table.pptx", SaveFormat.Pptx);
}
```

## **قفل کردن نسبت ابعاد جدول**

نسبت ابعاد یک شکل هندسی، نسبت اندازه‌های آن در ابعاد مختلف است. Aspose.Slides ویژگی `AspectRatioLocked` را فراهم کرده تا بتوانید تنظیمات نسبت ابعاد را برای جداول و سایر اشکال قفل کنید.  

این کد C# نشان می‌دهد چگونه نسبت ابعاد یک جدول را قفل کنید:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ITable table = (ITable)pres.Slides[0].Shapes[0];
    Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

    table.ShapeLock.AspectRatioLocked = !table.ShapeLock.AspectRatioLocked; // معکوس

    Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **سوالات متداول**

**آیا می‌توانم جهت‌خوانی راست به چپ (RTL) را برای کل جدول و متن داخل سلول‌ها فعال کنم؟**  

بله. جدول ویژگی [RightToLeft](https://reference.aspose.com/slides/fa/net/aspose.slides/table/righttoleft/) را در دسترس دارد و پاراگراف‌ها دارای [ParagraphFormat.RightToLeft](https://reference.aspose.com/slides/fa/net/aspose.slides/paragraphformat/righttoleft/) هستند. استفاده از هر دو اطمینان می‌دهد که ترتیب RTL صحیح و رندرینگ داخل سلول‌ها برقرار باشد.

**چگونه می‌توانم جلوی جابجا یا تغییر اندازهٔ جدول را در فایل نهایی بگیرم؟**  

از [قفل‌های شکل](/slides/fa/net/applying-protection-to-presentation/) برای غیرفعال کردن جابجایی، تغییر اندازه، انتخاب و غیره استفاده کنید. این قفل‌ها برای جداول نیز اعمال می‌شوند.

**آیا درج تصویر درون یک سلول به‌عنوان پس‌زمینه پشتیبانی می‌شود؟**  

بله. می‌توانید برای یک سلول [پر کردن تصویر](https://reference.aspose.com/slides/fa/net/aspose.slides/picturefillformat/) تنظیم کنید؛ تصویر بر اساس حالت انتخابی (کشیدگی یا کاشی) کل ناحیهٔ سلول را پوشش خواهد داد.