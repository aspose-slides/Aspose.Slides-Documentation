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
- استایل جدول
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "مدیریت ردیف‌ها و ستون‌های جدول در PowerPoint با Aspose.Slides برای .NET و سرعت‌بخشی به ویرایش ارائه و به‌روزرسانی داده‌ها."
---
## **مقدمه**

برای این‌که بتوانید ردیف‌ها و ستون‌های جدول را در یک ارائه PowerPoint مدیریت کنید، Aspose.Slides کلاس [Table](https://reference.aspose.com/slides/fa/net/aspose.slides/table/)، رابط [ITable](https://reference.aspose.com/slides/fa/net/aspose.slides/itable/) و انواع دیگر بسیاری را فراهم می‌کند. 

## **تنظیم سطر اول به‌عنوان سرصفحه**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کرده و ارائه را بارگذاری کنید. 
2. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید. 
3. یک شیء [ITable](https://reference.aspose.com/slides/fa/net/aspose.slides/itable/) ایجاد کرده و آن را به null تنظیم کنید. 
4. از تمام اشیاء [IShape](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/) عبور کنید تا جدول مرتبط را پیدا کنید. 
5. سطر اول جدول را به‌عنوان سرصفحه تنظیم کنید. 

این کد C# نشان می‌دهد چگونه سطر اول جدول را به‌عنوان سرصفحه تنظیم کنید:

```c#
// یک نمونه از کلاس Presentation ایجاد می‌کند
Presentation pres = new Presentation("table.pptx");

// به اولین اسلاید دسترسی می‌یابد
ISlide sld = pres.Slides[0];

// متغیر TableEx را به null مقداردهی می‌کند
ITable tbl = null;

// از اشکال عبور می‌کند و یک مرجع به جدول تنظیم می‌کند
foreach (IShape shp in sld.Shapes)
{
    if (shp is ITable)
    {
        tbl = (ITable)shp;
    }
}

// سطر اول جدول را به‌عنوان سرصفحه تنظیم می‌کند
tbl.FirstRow = true;

// ارائه را روی دیسک ذخیره می‌کند
pres.Save("First_row_header.pptx", SaveFormat.Pptx);
```

## **کلون کردن سطر یا ستون جدول**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کرده و ارائه را بارگذاری کنید، 
2. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید. 
3. یک آرایه از `columnWidth` تعریف کنید. 
4. یک آرایه از `rowHeight` تعریف کنید. 
5. یک شیء [ITable](https://reference.aspose.com/slides/fa/net/aspose.slides/itable/) را به اسلاید اضافه کنید با استفاده از متد [AddTable](https://reference.aspose.com/slides/fa/net/aspose.slides/ishapecollection/addtable/). 
6. سطر جدول را کلون کنید. 
7. ستون جدول را کلون کنید. 
8. ارائه‌ی تغییر یافته را ذخیره کنید. 

این کد C# نشان می‌دهد چگونه سطر یا ستون یک جدول PowerPoint را کلون کنید:

```c#
 // یک نمونه از کلاس Presentation ایجاد می‌کند
using (Presentation presentation = new Presentation("Test.pptx"))
{
    // به اولین اسلاید دسترسی می‌یابد
    ISlide sld = presentation.Slides[0];

    // ستون‌ها را با عرض‌ها و ردیف‌ها را با ارتفاع‌ها تعریف می‌کند
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // یک شکل جدول را به اسلاید اضافه می‌کند
    ITable table = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // متن را به سلول 1 ردیف 1 اضافه می‌کند
    table[0, 0].TextFrame.Text = "Row 1 Cell 1";

    // متن را به سلول 2 ردیف 1 اضافه می‌کند
    table[1, 0].TextFrame.Text = "Row 1 Cell 2";

    // ردیف 1 را در انتهای جدول کلون می‌کند
    table.Rows.AddClone(table.Rows[0], false);

    // متن را به سلول 1 ردیف 2 اضافه می‌کند
    table[0, 1].TextFrame.Text = "Row 2 Cell 1";

    // متن را به سلول 2 ردیف 2 اضافه می‌کند
    table[1, 1].TextFrame.Text = "Row 2 Cell 2";

    // ردیف 2 را به عنوان ردیف چهارم جدول کلون می‌کند
    table.Rows.InsertClone(3,table.Rows[1], false);

    // ستون اول را در انتها کلون می‌کند
    table.Columns.AddClone(table.Columns[0], false);

    // ستون دوم را در ایندکس ستون چهارم کلون می‌کند
    table.Columns.InsertClone(3,table.Columns[1], false);
    
    // ارائه را روی دیسک ذخیره می‌کند 
    presentation.Save("table_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **حذف سطر یا ستون از جدول**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کرده و ارائه را بارگذاری کنید، 
2. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید. 
3. یک آرایه از `columnWidth` تعریف کنید. 
4. یک آرایه از `rowHeight` تعریف کنید. 
5. یک شیء [ITable](https://reference.aspose.com/slides/fa/net/aspose.slides/itable/) را به اسلاید اضافه کنید با استفاده از متد [AddTable](https://reference.aspose.com/slides/fa/net/aspose.slides/ishapecollection/addtable/). 
6. سطر جدول را حذف کنید. 
7. ستون جدول را حذف کنید. 
8. ارائه‌ی تغییر یافته را ذخیره کنید. 

این کد C# نشان می‌دهد چگونه سطر یا ستون را از یک جدول حذف کنید:

```c#
Presentation pres = new Presentation();

ISlide slide = pres.Slides[0];
double[] colWidth = { 100, 50, 30 };
double[] rowHeight = { 30, 50, 30 };

ITable table = slide.Shapes.AddTable(100, 100, colWidth, rowHeight);
table.Rows.RemoveAt(1, false);
table.Columns.RemoveAt(1, false);
pres.Save("TestTable_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **تنظیم قالب‌بندی متن در سطح سطر جدول**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کرده و ارائه را بارگذاری کنید، 
2. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید. 
3. به شیء [ITable](https://reference.aspose.com/slides/fa/net/aspose.slides/itable/) مربوطه از اسلاید دسترسی پیدا کنید. 
4. ارتفاع فونت سلول‌های سطر اول را تنظیم کنید با [FontHeight](https://reference.aspose.com/slides/fa/net/aspose.slides/baseportionformat/fontheight/). 
5. تراز [Alignment](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraphformat/alignment/) و [MarginRight](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraphformat/marginright/) سلول‌های سطر اول را تنظیم کنید. 
6. نوع عمودی متن [TextVerticalType](https://reference.aspose.com/slides/fa/net/aspose.slides/textframeformat/textverticaltype/) سلول‌های سطر دوم را تنظیم کنید. 
7. ارائه‌ی تغییر یافته را ذخیره کنید. 

این کد C# عملیات را نشان می‌دهد.

```c#
// یک نمونه از کلاس Presentation ایجاد می‌کند
Presentation presentation = new Presentation();
           
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // فرض می‌کنیم که اولین شکل در اولین اسلاید یک جدول است

// ارتفاع فونت سلول‌های سطر اول را تنظیم می‌کند
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.Rows[0].SetTextFormat(portionFormat);

// تراز متن سلول‌های سطر اول و حاشیه راست را تنظیم می‌کند
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.Rows[0].SetTextFormat(paragraphFormat);

// نوع عمودی متن سلول‌های سطر دوم را تنظیم می‌کند
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.Rows[1].SetTextFormat(textFrameFormat);

// ارائه را روی دیسک ذخیره می‌کند
presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **تنظیم قالب‌بندی متن در سطح ستون جدول**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کرده و ارائه را بارگذاری کنید، 
2. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید. 
3. به شیء [ITable](https://reference.aspose.com/slides/fa/net/aspose.slides/itable/) مربوطه از اسلاید دسترسی پیدا کنید. 
4. ارتفاع فونت سلول‌های ستون اول را تنظیم کنید با [FontHeight](https://reference.aspose.com/slides/fa/net/aspose.slides/baseportionformat/fontheight/). 
5. تراز [Alignment](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraphformat/alignment/) و [MarginRight](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraphformat/marginright/) سلول‌های ستون اول را تنظیم کنید. 
6. نوع عمودی متن [TextVerticalType](https://reference.aspose.com/slides/fa/net/aspose.slides/textframeformat/textverticaltype/) سلول‌های ستون دوم را تنظیم کنید. 
7. ارائه‌ی تغییر یافته را ذخیره کنید. 

این کد C# عملیات را نشان می‌دهد: 

```c#
// یک نمونه از کلاس Presentation ایجاد می‌کند
Presentation pres = new Presentation();
           
ISlide slide = pres.Slides[0];

ITable someTable = pres.Slides[0].Shapes[0] as ITable; // فرض می‌کنیم که اولین شکل در اولین اسلاید یک جدول است

// ارتفاع فونت سلول‌های ستون اول را تنظیم می‌کند
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.Columns[0].SetTextFormat(portionFormat);

// تنظیم تراز متن سلول‌های ستون اول و حاشیه راست در یک فراخوانی
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.Columns[0].SetTextFormat(paragraphFormat);

// تنظیم نوع عمودی متن سلول‌های ستون دوم
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.Columns[1].SetTextFormat(textFrameFormat);

// ارائه را روی دیسک ذخیره می‌کند
pres.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **دریافت ویژگی‌های سبک جدول**

Aspose.Slides به شما امکان می‌دهد ویژگی‌های سبک یک جدول را بازیابی کنید تا بتوانید آن جزئیات را برای جدول دیگری یا در مکان دیگری استفاده کنید. این کد C# نشان می‌دهد چگونه ویژگی‌های سبک را از یک سبک پیش‌تنظیم جدول دریافت کنید: 

```c#
using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // تم پیش‌تنظیم سبک پیش‌فرض را تغییر می‌دهد 
    pres.Save("table.pptx", SaveFormat.Pptx);
}
```

## **سوالات متداول**

**آیا می‌توانم تم/سبک‌های PowerPoint را به جدول‌ای که قبلاً ایجاد شده اعمال کنم؟**

بله. جدول تم اسلاید/چیدمان/مستر را به ارث می‌برد و همچنان می‌توانید پرکننده‌ها، حاشیه‌ها و رنگ‌های متن را بر روی آن تم بازنویسی کنید.

**آیا می‌توانم ردیف‌های جدول را همانند Excel مرتب کنم؟**

خیر، جدول‌های Aspose.Slides قابلیت مرتب‌سازی یا فیلتر داخلی ندارند. ابتدا داده‌ها را در حافظه‌تان مرتب کنید، سپس ردیف‌های جدول را به ترتیب آن بازپر کنید.

**آیا می‌توانم ستون‌های راه‌راه (banded) داشته باشم در حالی که رنگ‌های سفارشی برای سلول‌های خاص حفظ می‌شود؟**

بله. گزینه ستون‌های راه‌راه را فعال کنید، سپس سلول‌های خاص را با قالب‌بندی محلی بازنویسی کنید؛ قالب‌بندی سطح سلول بر سبک جدول اولویت دارد.