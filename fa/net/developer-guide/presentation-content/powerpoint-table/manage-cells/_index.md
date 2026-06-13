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
description: "به راحتی سلول‌های جدول را در PowerPoint با Aspose.Slides برای .NET مدیریت کنید. دسترسی، اصلاح و استایل‌دهی سریع به سلول‌ها را برای خودکارسازی یکپارچه اسلایدها فراگیرید."
---
## **نمای کلی**

Aspose.Slides به شما امکان دسترسی و اصلاح سلول‌های جدول در ارائه‌های PowerPoint را می‌دهد. این مقاله نحوه شناسایی سلول‌های ترکیب‌شده در جدول، حذف حاشیه‌های سلول، کار با شماره‌گذاری سلول پس از ترکیب یا تقسیم سلول‌ها، تغییر رنگ پس‌زمینهٔ سلول و افزودن تصویر داخل سلول جدول را توضیح می‌دهد. مثال‌ها نشان می‌دهند چگونه یک ارائه را ایجاد یا باز کنید، جدول را از یک اسلاید دریافت کنید، قالب‌بندی سلول را از طریق ویژگی‌های سلول به‌روزرسانی کنید و ارائهٔ اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

## **شناسایی سلول ترکیب‌شده در جدول**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.  
2. جدول را از اولین اسلاید دریافت کنید.  
3. از ردیف‌ها و ستون‌های جدول عبور کنید تا سلول‌های ترکیب‌شده را پیدا کنید.  
4. زمانی که سلول‌های ترکیب‌شده پیدا شد پیام چاپ کنید.

```c#
using (Presentation pres = new Presentation("SomePresentationWithTable.pptx"))
{
    ITable table = pres.Slides[0].Shapes[0] as ITable; // با فرض اینکه Slide#0.Shape#0 یک جدول است
    for (int i = 0; i < table.Rows.Count; i++)
    {
        for (int j = 0; j < table.Columns.Count; j++)
        {
            ICell currentCell = table.Rows[i][j];
            if (currentCell.IsMergedCell)
            {
                Console.WriteLine(string.Format("Cell {0};{1} is a part of merged cell with RowSpan={2} and ColSpan={3} starting from Cell {4};{5}.",
                                  i, j, currentCell.RowSpan, currentCell.ColSpan, currentCell.FirstRowIndex, currentCell.FirstColumnIndex));


            }
        }
    }
}
```

## **حذف حاشیه‌های سلول جدول**

1. یک نمونه از کلاس `Presentation` ایجاد کنید.  
2. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.  
3. یک آرایه از ستون‌ها با عرض تعریف کنید.  
4. یک آرایه از ردیف‌ها با ارتفاع تعریف کنید.  
5. از متد `AddTable` برای افزودن جدول به اسلاید استفاده کنید.  
6. از هر سلول عبور کنید تا حاشیه‌های بالا، پایین، راست و چپ را پاک کنید.  
7. ارائهٔ اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

```c#
// یک شی از کلاس Presentation که نمایانگر یک فایل PPTX است را ایجاد می‌کند
using (Presentation pres = new Presentation())
{
   // دسترسی به اسلاید اول
    Slide sld = (Slide)pres.Slides[0];

    // ستون‌ها را با عرض‌ها و ردیف‌ها را با ارتفاع‌ها تعریف می‌کند
    double[] dblCols = { 50, 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // شکل جدول را به اسلاید اضافه می‌کند
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // قالب حاشیه را برای هر سلول تنظیم می‌کند
    foreach (IRow row in tbl.Rows)
        foreach (ICell cell in row)
        {
            cell.CellFormat.BorderTop.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderRight.FillFormat.FillType = FillType.NoFill;
        }

    // فایل PPTX را بر روی دیسک می‌نویسد
    pres.Save("table_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **شماره‌گذاری در سلول‌های ترکیب‌شده**

اگر دو جفت سلول (1, 1) × (2, 1) و (1, 2) × (2, 2) را ترکیب کنیم، جدول حاصل شماره‌گذاری می‌شود. این کد C# فرایند را نشان می‌دهد:

```c#
// یک شی از کلاس Presentation که نمایانگر یک فایل PPTX است را ایجاد می‌کند
using (Presentation presentation = new Presentation())
{
    // به اولین اسلاید دسترسی می‌یابد
    ISlide sld = presentation.Slides[0];

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

    // سلول‌های (1, 1) × (2, 1) را ترکیب می‌کند
    tbl.MergeCells(tbl[1, 1], tbl[2, 1], false);

    // سلول‌های (1, 2) × (2, 2) را ترکیب می‌کند
    tbl.MergeCells(tbl[1, 2], tbl[2, 2], false);

    presentation.Save("MergeCells_out.pptx", SaveFormat.Pptx);
}
```

سپس سلول‌ها را بیشتر ترکیب می‌کنیم با ترکیب (1, 1) و (1, 2). نتیجه جدولی است که یک سلول بزرگ ترکیب‌شده در مرکز دارد:

```c#
 // یک شی از کلاس Presentation که نمایانگر یک فایل PPTX است را ایجاد می‌کند
using (Presentation presentation = new Presentation())
{
    // به اسلاید اول دسترسی می‌یابد
    ISlide slide = presentation.Slides[0];

    // ستون‌ها را با عرض‌ها و ردیف‌ها را با ارتفاع‌ها تعریف می‌کند
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // یک شکل جدول را به اسلاید اضافه می‌کند
    ITable table = slide.Shapes.AddTable(100, 50, dblCols, dblRows);

    // قالب حاشیه را برای هر سلول تنظیم می‌کند
    foreach (IRow row in table.Rows)
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

    // سلول‌های (1, 1) × (2, 1) را ترکیب می‌کند
    table.MergeCells(table[1, 1], table[2, 1], false);

    // سلول‌های (1, 2) × (2, 2) را ترکیب می‌کند
    table.MergeCells(table[1, 2], table[2, 2], false);

    // سلول‌های (1, 2) × (2, 2) را ترکیب می‌کند
    table.MergeCells(table[1, 1], table[1, 2], true);

    // فایل PPTX را بر روی دیسک می‌نویسد
    presentation.Save("MergeCells1_out.pptx", SaveFormat.Pptx);
}
```

## **شماره‌گذاری در سلول تقسیم‌شده**

در مثال‌های قبلی، زمانی که سلول‌های جدول ترکیب شدند، شماره‌گذاری یا سیستم عددی در سلول‌های دیگر تغییر نکرد.

این بار، یک جدول معمولی (جدولی بدون سلول‌های ترکیب‌شده) می‌گیریم و سپس سعی می‌کنیم سلول (1,1) را تقسیم کنیم تا جدولی ویژه به دست آوریم. شاید به شماره‌گذاری این جدول توجه کنید که ممکن است عجیب به نظر برسد. با این حال، این همان روشی است که Microsoft PowerPoint سلول‌های جدول را شماره‌گذاری می‌کند و Aspose.Slides نیز به همین شکل عمل می‌کند.

```c#
// یک شی از کلاس Presentation که نمایانگر یک فایل PPTX است را ایجاد می‌کند
using (Presentation presentation = new Presentation())
{
    // به اسلاید اول دسترسی می‌یابد
    ISlide slide = presentation.Slides[0];

    // ستون‌ها را با عرض‌ها و ردیف‌ها را با ارتفاع‌ها تعریف می‌کند
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // یک شکل جدول را به اسلاید اضافه می‌کند
    ITable table = slide.Shapes.AddTable(100, 50, dblCols, dblRows);

    // قالب حاشیه را برای هر سلول تنظیم می‌کند
    foreach (IRow row in table.Rows)
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

    // سلول‌های (1, 1) × (2, 1) را ترکیب می‌کند
    table.MergeCells(table[1, 1], table[2, 1], false);

    // سلول‌های (1, 2) × (2, 2) را ترکیب می‌کند
    table.MergeCells(table[1, 2], table[2, 2], false);

    // سلول (1, 1) را تقسیم می‌کند.
    table[1, 1].SplitByWidth(table[2, 1].Width / 2);

    // فایل PPTX را بر روی دیسک می‌نویسد
    presentation.Save("CellSplit_out.pptx", SaveFormat.Pptx);
}
```

## **تغییر رنگ پس‌زمینهٔ سلول جدول**

این کد C# نشان می‌دهد چگونه رنگ پس‌زمینهٔ یک سلول جدول را تغییر دهید:

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 50, 50, 50, 50, 50 };

    // یک جدول جدید ایجاد می‌کند
    ITable table = slide.Shapes.AddTable(50, 50, dblCols, dblRows);

    // رنگ پس‌زمینه را برای یک سلول تنظیم می‌کند
    ICell cell = table[2, 3];
    cell.CellFormat.FillFormat.FillType = FillType.Solid;
    cell.CellFormat.FillFormat.SolidFillColor.Color = Color.Red;

    presentation.Save("cell_background_color.pptx", SaveFormat.Pptx);
}
```

## **افزودن تصویر داخل سلول جدول**

1. یک نمونه از کلاس `Presentation` ایجاد کنید.  
2. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.  
3. یک آرایه از ستون‌ها با عرض تعریف کنید.  
4. یک آرایه از ردیف‌ها با ارتفاع تعریف کنید.  
5. از متد `AddTable` برای افزودن جدول به اسلاید استفاده کنید.  
6. یک شیء `Bitmap` ایجاد کنید تا فایل تصویر را نگه دارد.  
7. تصویر bitmap را به شیء `IPPImage` اضافه کنید.  
8. `FillFormat` سلول جدول را به `Picture` تنظیم کنید.  
9. تصویر را به اولین سلول جدول اضافه کنید.  
10. ارائهٔ اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

```c#
// یک شی از کلاس Presentation که نمایانگر یک فایل PPTX است را ایجاد می‌کند
using (Presentation presentation = new Presentation())
{
    // به اسلاید اول دسترسی می‌یابد
    ISlide slide = presentation.Slides[0];

    // ستون‌ها را با عرض‌ها و ردیف‌ها را با ارتفاع‌ها تعریف می‌کند
    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 100, 100, 100, 100, 90 };

    // یک شکل جدول را به اسلاید اضافه می‌کند
    ITable table = slide.Shapes.AddTable(50, 50, dblCols, dblRows);

    // یک تصویر را از فایل بارگذاری می‌کند و به منابع ارائه اضافه می‌دارد
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // تصویر را به اولین سلول جدول اضافه می‌کند
    table[0, 0].CellFormat.FillFormat.FillType = FillType.Picture;
    table[0, 0].CellFormat.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
    table[0, 0].CellFormat.FillFormat.PictureFillFormat.Picture.Image = ppImage;

    // فایل PPTX را بر روی دیسک ذخیره می‌کند
    presentation.Save("Image_In_TableCell_out.pptx", SaveFormat.Pptx);
}
```

## **سؤالات متداول**

**آیا می‌توانم ضخامت و سبک خطوط مختلفی برای سمت‌های مختلف یک سلول تنظیم کنم؟**

بله. حاشیه‌های [بالا](https://reference.aspose.com/slides/fa/net/aspose.slides/cellformat/bordertop/)/[پایین](https://reference.aspose.com/slides/fa/net/aspose.slides/cellformat/borderbottom/)/[چپ](https://reference.aspose.com/slides/fa/net/aspose.slides/cellformat/borderleft/)/[راست](https://reference.aspose.com/slides/fa/net/aspose.slides/cellformat/borderright/) دارای ویژگی‌های جداگانه‌ای هستند، بنابراین ضخامت و سبک هر سمت می‌تواند متفاوت باشد. این منطق از کنترل حاشیه‌ به‌ازای هر سمت برای یک سلول که در مقاله نشان داده شد، ناشی می‌شود.

**اگر پس از تنظیم تصویر به‌عنوان پس‌زمینهٔ سلول، اندازهٔ ستون/ردیف را تغییر دهم، چه‌ اتفاقی برای تصویر می‌افتد؟**

رفتار به [حالت پر کردن](https://reference.aspose.com/slides/fa/net/aspose.slides/picturefillmode/) (کشیدگی/کاشی) بستگی دارد. در حالت کشیدگی، تصویر با سلول جدید سازگار می‌شود؛ در حالت کاشی، کاشی‌ها بازمحاسبه می‌شوند. مقاله به حالت‌های نمایش تصویر در یک سلول اشاره می‌کند.

**آیا می‌توانم یک پیوند (hyperlink) را به تمام محتوای یک سلول اختصاص دهم؟**

[Hyperlinks](/slides/fa/net/manage-hyperlinks/) در سطح متن (بخش) داخل چارچوب متن سلول یا در سطح کل جدول/شکل تنظیم می‌شوند. در عمل، پیوند را به یک بخش یا به تمام متن داخل سلول اختصاص می‌دهید.

**آیا می‌توانم فونت‌های مختلفی را در یک سلول استفاده کنم؟**

بله. چارچوب متن سلول از [بخش‌ها](https://reference.aspose.com/slides/fa/net/aspose.slides/portion/) (run) با قالب‌بندی مستقل—خانوادهٔ فونت، سبک، اندازه و رنگ—پشتیبانی می‌کند.