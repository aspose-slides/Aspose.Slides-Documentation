---
title: مدیریت سلول‌های جدول در ارائه‌ها با استفاده از جاوا
linktitle: مدیریت سلول‌ها
type: docs
weight: 30
url: /fa/java/manage-cells/
keywords:
- سلول جدول
- ادغام سلول‌ها
- حذف حاشیه
- تقسیم سلول
- تصویر در سلول
- رنگ پس‌زمینه
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "به‌راحتی سلول‌های جدول را در PowerPoint با Aspose.Slides برای جاوا مدیریت کنید. دسترسی، تغییر و استایل‌دهی به سلول‌ها را به‌سرعت یاد بگیرید برای خودکارسازی روان اسلایدها."
---
## **نمای کلی**

Aspose.Slides به شما امکان دسترسی و تغییر سلول‌های جدول در ارائه‌های PowerPoint را می‌دهد. این مقاله توضیح می‌دهد که چگونه سلول‌های ترکیبی جدول را شناسایی کنید، مرزهای سلول را حذف کنید، پس از ترکیب یا تقسیم سلول‌ها با شماره‌گذاری سلول کار کنید، رنگ پس‌زمینه یک سلول را تغییر دهید و یک تصویر را داخل سلول جدول اضافه کنید. مثال‌ها نشان می‌دهند که چگونه یک ارائه را ایجاد یا باز کنید، جدول را از یک اسلاید دریافت کنید، قالب‌بندی سلول را از طریق ویژگی‌های سلول به‌روزرسانی کنید و ارائه اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

## **شناسایی سلول ترکیبی جدول**
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.
2. جدول را از اولین اسلاید دریافت کنید.
3. در ردیف‌ها و ستون‌های جدول حلقه بزنید تا سلول‌های ترکیبی را پیدا کنید.
4. زمانی که سلول‌های ترکیبی یافت شد، پیام چاپ کنید.

این کد جاوا نشان می‌دهد که چگونه سلول‌های ترکیبی جدول را در یک ارائه شناسایی کنید:

```java
Presentation pres = new Presentation("SomePresentationWithTable.pptx");
try {
    ITable table = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0); // فرض بر این است که Slide#0.Shape#0 یک جدول است
    for (int i = 0; i < table.getRows().size(); i++)
    {
        for (int j = 0; j < table.getColumns().size(); j++)
        {
            ICell currentCell = table.getRows().get_Item(i).get_Item(j);
            if (currentCell.isMergedCell())
            {
                System.out.println(String.format("Cell %d;%d is a part of merged cell with RowSpan=%d and ColSpan=%d starting from Cell %d;%d.",
                        i, j, currentCell.getRowSpan(), currentCell.getColSpan(), currentCell.getFirstRowIndex(), currentCell.getFirstColumnIndex()));
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **حذف مرزهای سلول جدول**
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.
2. مرجع اسلاید را از طریق شاخص آن دریافت کنید.
3. یک آرایه از ستون‌ها با عرض تعریف کنید.
4. یک آرایه از ردیف‌ها با ارتفاع تعریف کنید.
5. با استفاده از متد [addTable](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) یک جدول به اسلاید اضافه کنید.
6. در هر سلول حلقه بزنید تا مرزهای بالا، پایین، راست و چپ را پاک کنید.
7. ارائه اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

این کد جاوا نشان می‌دهد که چگونه مرزهای سلول‌های جدول را حذف کنید:

```java
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل PPTX است
Presentation pres = new Presentation();
try {
    // دسترسی به اولین اسلاید
    Slide sld = (Slide)pres.getSlides().get_Item(0);

    // تعریف ستون‌ها با عرض‌ها و ردیف‌ها با ارتفاع‌ها
    double[] dblCols = { 50, 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // افزودن شکل جدول به اسلاید
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // تنظیم قالب مرز برای هر سلول
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill);
        }
    }

    // نوشتن فایل PPTX بر روی دیسک
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **شماره‌گذاری در سلول‌های ترکیبی**
اگر دو جفت سلول (1, 1) × (2, 1) و (1, 2) × (2, 2) را ترکیب کنیم، جدول حاصل شماره‌گذاری می‌شود. این کد جاوا فرآیند را نمایش می‌دهد:

```java
// یک شیء از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل PPTX است
Presentation pres = new Presentation();
try {
    // دسترسی به اولین اسلاید
    ISlide sld = pres.getSlides().get_Item(0);

    // تعریف ستون‌ها با عرض‌ها و ردیف‌ها با ارتفاع‌ها
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // افزودن شکل جدول به اسلاید
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // تنظیم قالب مرز برای هر سلول
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderTop().setWidth(5);

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderBottom().setWidth(5);

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderLeft().setWidth(5);

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }

    // ادغام سلول‌های (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // ادغام سلول‌های (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    pres.save("MergeCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

سپس سلول‌ها را بیشتر ترکیب می‌کنیم با ترکیب (1, 1) و (1, 2). نتیجه جدولی است که یک سلول ترکیبی بزرگ در مرکز دارد:

```java
// یک شیء از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل PPTX است
Presentation pres = new Presentation();
try {
    // دسترسی به اولین اسلاید
    ISlide sld = pres.getSlides().get_Item(0);

    // تعریف ستون‌ها با عرض‌ها و ردیف‌ها با ارتفاع‌ها
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // افزودن شکل جدول به اسلاید
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // تنظیم قالب مرز برای هر سلول
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderTop().setWidth(5);

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderBottom().setWidth(5);

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderLeft().setWidth(5);

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }

    // ادغام سلول‌های (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // ادغام سلول‌های (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    // ادغام سلول‌های (1, 1) x (1, 2)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(1, 2), true);
    
	//نوشتن فایل PPTX بر روی دیسک
    pres.save("MergeCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **شماره‌گذاری در یک سلول تقسیم‌شده**
در مثال‌های قبلی، وقتی سلول‌های جدول ترکیب شدند، سیستم شمارش یا شماره‌گذاری در سایر سلول‌ها تغییر نداد.

این بار یک جدول معمولی (بدون سلول ترکیبی) را می‌گیریم و سپس سعی می‌کنیم سلول (1,1) را تقسیم کنیم تا جدول خاصی به دست آید. شاید به شماره‌گذاری این جدول توجه کنید که ممکن است عجیب به‌نظر برسد. با این حال، این همان روشی است که Microsoft PowerPoint سلول‌های جدول را شماره‌گذاری می‌کند و Aspose.Slides همین کار را انجام می‌دهد.

این کد جاوا فرآیند توضیح‌شده را نشان می‌دهد:

```java
// یک شیء از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل PPTX است
Presentation pres = new Presentation();
try {
    // به اولین اسلاید دسترسی پیدا می‌کند
    ISlide sld = pres.getSlides().get_Item(0);

    // ستون‌ها را با عرض‌ها و ردیف‌ها را با ارتفاع‌ها تعریف می‌کند
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // یک شکل جدول را به اسلاید اضافه می‌کند
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // قالب مرز را برای هر سلول تنظیم می‌کند
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderTop().setWidth(5);

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderBottom().setWidth(5);

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderLeft().setWidth(5);

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }

    // سلول‌های (1, 1) × (2, 1) را ادغام می‌کند
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // سلول‌های (1, 2) × (2, 2) را ادغام می‌کند
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    // سلول (1, 1) را تقسیم می‌کند
    tbl.get_Item(1, 1).splitByWidth(tbl.get_Item(2, 1).getWidth() / 2);

    // فایل PPTX را بر روی دیسک می‌نویسد
    pres.save("SplitCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تغییر رنگ پس‌زمینه سلول جدول**

این کد جاوا نشان می‌دهد که چگونه رنگ پس‌زمینه یک سلول جدول را تغییر دهید:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 50, 50, 50, 50, 50 };

    // یک جدول جدید ایجاد می‌کند
    ITable table = slide.getShapes().addTable(50, 50, dblCols, dblRows);

    // رنگ پس‌زمینه یک سلول را تنظیم می‌کند 
    ICell cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid);
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

    presentation.save("cell_background_color.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **اضافه کردن تصویر داخل سلول جدول**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.
2. مرجع اسلاید را از طریق شاخص آن دریافت کنید.
3. یک آرایه از ستون‌ها با عرض تعریف کنید.
4. یک آرایه از ردیف‌ها با ارتفاع تعریف کنید.
5. با استفاده از متد [AddTable](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) یک جدول به اسلاید اضافه کنید.
6. یک شیء `Images` برای نگهداری فایل تصویر ایجاد کنید.
7. تصویر `IImage` را به شیء `IPPImage` اضافه کنید.
8. `FillFormat` سلول جدول را روی `Picture` تنظیم کنید.
9. تصویر را به اولین سلول جدول اضافه کنید.
10. ارائه اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

این کد جاوا نشان می‌دهد که چگونه هنگام ایجاد جدول، تصویر را داخل یک سلول جدول قرار دهید:

```java
// یک شیء از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل PPTX است
Presentation pres = new Presentation();
try {
    // به اولین اسلاید دسترسی پیدا می‌کند
    ISlide islide = pres.getSlides().get_Item(0);

    // ستون‌ها را با عرض‌ها و ردیف‌ها را با ارتفاع‌ها تعریف می‌کند
    double[] dblCols = {150, 150, 150, 150};
    double[] dblRows = {100, 100, 100, 100, 90};

    // یک شکل جدول را به اسلاید اضافه می‌کند
    ITable tbl = islide.getShapes().addTable(50, 50, dblCols, dblRows);

    // یک شیء IPPImage با استفاده از فایل تصویر ایجاد می‌کند
    IPPImage picture;
    IImage image = Images.fromFile("image.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // تصویر را به اولین سلول جدول اضافه می‌کند
    ICellFormat cellFormat = tbl.get_Item(0, 0).getCellFormat();
    cellFormat.getFillFormat().setFillType(FillType.Picture);
    cellFormat.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    cellFormat.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // فایل PPTX را بر روی دیسک ذخیره می‌کند
    pres.save("Image_In_TableCell_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **سوالات متداول**

**آیا می‌توانم ضخامت و سبک خطوط متفاوتی برای هر سمت یک سلول تعیین کنم؟**

بله. مرزهای [بالا](https://reference.aspose.com/slides/fa/java/com.aspose.slides/cellformat/#getBorderTop--)/[پایین](https://reference.aspose.com/slides/fa/java/com.aspose.slides/cellformat/#getBorderBottom--)/[چپ](https://reference.aspose.com/slides/fa/java/com.aspose.slides/cellformat/#getBorderLeft--)/[右](https://reference.aspose.com/slides/fa/java/com.aspose.slides/cellformat/#getBorderRight--) دارای ویژگی‌های جداگانه‌ای هستند، بنابراین ضخامت و سبک هر سمت می‌تواند متفاوت باشد. این به‌طور منطقی از کنترل مرزهای هر‑طرف برای یک سلول که در مقاله نشان داده شده است، ناشی می‌شود.

**اگر پس از تنظیم تصویر به‌عنوان پس‌زمینه سلول، اندازه ستون/ردیف را تغییر دهم، چه اتفاقی برای تصویر می‌افتد؟**

رفتار بستگی به [حالت پر کردن](https://reference.aspose.com/slides/fa/java/com.aspose.slides/picturefillmode/) (کشیدن/کاشی) دارد. در حالت کشیدن، تصویر با سلول جدید سازگار می‌شود؛ در حالت کاشی، کاشی‌ها مجدداً محاسبه می‌شوند. مقاله به حالت‌های نمایش تصویر در یک سلول اشاره دارد.

**آیا می‌توانم یک لینک‌فقط به تمام محتوای یک سلول اختصاص دهم؟**

[Hyperlinks](/slides/fa/java/manage-hyperlinks/) در سطح متن (بخش) داخل فریم متن سلول یا در سطح کل جدول/شکل تنظیم می‌شوند. در عمل، لینک را به یک بخش یا به تمام متن در سلول اختصاص می‌دهید.

**آیا می‌توانم قلم‌های متفاوتی داخل یک سلول استفاده کنم؟**

بله. فریم متن سلول از [portions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/portion/) (قطعات) با قالب‌بندی مستقل—خانواده قلم، سبک، اندازه و رنگ—پشتیبانی می‌کند.