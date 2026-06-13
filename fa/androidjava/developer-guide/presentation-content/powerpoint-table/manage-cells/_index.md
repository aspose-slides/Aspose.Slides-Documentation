---
title: مدیریت سلول‌های جدول در ارائه‌ها بر روی اندروید
linktitle: مدیریت سلول‌ها
type: docs
weight: 30
url: /fa/androidjava/manage-cells/
keywords:
- سلول جدول
- ادغام سلول‌ها
- حذف حاشیه
- تقسیم سلول
- تصویر در سلول
- رنگ پس‌زمینه
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "به‌راحتی سلول‌های جدول را در PowerPoint با Aspose.Slides برای اندروید از طریق Java مدیریت کنید. به سرعت به دسترسی، اصلاح و استایل‌دهی به سلول‌ها مسلط شوید تا خودکارسازی اسلایدها به‌صورت یکپارچه انجام شود."
---
## **نمای کلی**

Aspose.Slides به شما امکان می‌دهد سلول‌های جدول در ارائه‌های PowerPoint را دسترسی و اصلاح کنید. این مقاله توضیح می‌دهد چگونه سلول‌های جدول ادغام‌شده را شناسایی کنید، حاشیه‌های سلول‌ها را حذف کنید، پس از ادغام یا تقسیم سلول‌ها با شماره‌گذاری سلول‌ها کار کنید، رنگ پس‌زمینه یک سلول را تغییر دهید و تصویر را داخل یک سلول جدول اضافه کنید. مثال‌ها نشان می‌دهند چگونه یک ارائه را ایجاد یا باز کنید، جدول را از یک اسلاید دریافت کنید، قالب‌بندی سلول را از طریق ویژگی‌های سلول به‌روزرسانی کنید و ارائه اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

## **شناسایی یک سلول جدول ادغام‌شده**
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.  
2. جدول را از اولین اسلاید دریافت کنید.  
3. در ردیف‌ها و ستون‌های جدول پیمایش کنید تا سلول‌های ادغام‌شده را پیدا کنید.  
4. هنگام یافتن سلول‌های ادغام‌شده، پیام را چاپ کنید.  

این کد Java نشان می‌دهد چگونه سلول‌های جدول ادغام‌شده را در یک ارائه شناسایی کنید:

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

## **حذف حاشیه‌های سلول جدول**
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.  
2. مرجع یک اسلاید را با استفاده از ایندکس آن دریافت کنید.  
3. یک آرایه از ستون‌ها با عرض تعریف کنید.  
4. یک آرایه از ردیف‌ها با ارتفاع تعریف کنید.  
5. با استفاده از متد [addTable](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) یک جدول به اسلاید اضافه کنید.  
6. در هر سلول پیمایش کنید تا حاشیه‌های بالایی، پایینی، راست و چپ را پاک کنید.  
7. ارائه اصلاح‌شده را به‌صورت یک فایل PPTX ذخیره کنید.  

این کد Java نشان می‌دهد چگونه حاشیه‌های سلول‌های جدول را حذف کنید:

```java
// یک نمونه از کلاس Presentation که نشان‌دهنده یک فایل PPTX است
Presentation pres = new Presentation();
try {
    // به اولین اسلاید دسترسی می‌یابد
    Slide sld = (Slide)pres.getSlides().get_Item(0);

    // ستون‌ها را با عرض و ردیف‌ها را با ارتفاع تعریف می‌کند
    double[] dblCols = { 50, 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // شکل جدول را به اسلاید اضافه می‌کند
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // قالب حاشیه را برای هر سلول تنظیم می‌کند
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

    // فایل PPTX را روی دیسک می‌نویسد
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **شماره‌گذاری در سلول‌های ادغام‌شده**
اگر دو جفت سلول (1, 1) × (2, 1) و (1, 2) × (2, 2) را ادغام کنیم، جدول حاصل شماره‌گذاری می‌شود. این کد Java فرآیند را نشان می‌دهد:

```java
// یک نمونه از کلاس Presentation که نشان‌دهنده یک فایل PPTX است
Presentation pres = new Presentation();
try {
    // به اسلاید اول دسترسی می‌یابد
    ISlide sld = pres.getSlides().get_Item(0);

    // ستون‌ها را با عرض و ردیف‌ها را با ارتفاع تعریف می‌کند
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // یک شکل جدول را به اسلاید اضافه می‌کند
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // قالب حاشیه را برای هر سلول تنظیم می‌کند
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

    pres.save("MergeCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

سپس سلول‌ها را بیشتر ادغام می‌کنیم با ادغام (1, 1) و (1, 2). نتیجه جدولی است که یک سلول بزرگ ادغام‌شده در مرکز دارد:

```java
// یک نمونه از کلاس Presentation که نشان‌دهنده یک فایل PPTX است
Presentation pres = new Presentation();
try {
    // به اسلاید اول دسترسی می‌یابد
    ISlide sld = pres.getSlides().get_Item(0);

    // ستون‌ها را با عرض و ردیف‌ها را با ارتفاع تعریف می‌کند
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // یک شکل جدول را به اسلاید اضافه می‌کند
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // قالب حاشیه را برای هر سلول تنظیم می‌کند
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

    // سلول‌های (1, 1) × (1, 2) را ادغام می‌کند
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(1, 2), true);
	
	// فایل PPTX را روی دیسک می‌نویسد
    pres.save("MergeCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **شماره‌گذاری در یک سلول تقسیم‌شده**
در مثال‌های قبلی، زمانی که سلول‌های جدول ادغام شدند، نظام شماره‌گذاری در سایر سلول‌ها تغییر نکرد.  

این بار، یک جدول معمولی (جدولی بدون سلول‌های ادغام‌شده) را می‌گیریم و سپس سعی می‌کنیم سلول (1,1) را تقسیم کنیم تا یک جدول ویژه به‌دست آوریم. ممکن است به شماره‌گذاری این جدول توجه کنید که ممکن است عجیب به‌نظر برسد. اما این همان روشی است که Microsoft PowerPoint سلول‌های جدول را شماره‌گذاری می‌کند و Aspose.Slides نیز همین کار را انجام می‌دهد.  

این کد Java فرآیند توصیف‌شده را نشان می‌دهد:

```java
// یک نمونه از کلاس Presentation که نشان‌دهنده یک فایل PPTX است
Presentation pres = new Presentation();
try {
    // به اسلاید اول دسترسی می‌یابد
    ISlide sld = pres.getSlides().get_Item(0);

    // ستون‌ها را با عرض و ردیف‌ها را با ارتفاع تعریف می‌کند
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // یک شکل جدول را به اسلاید اضافه می‌کند
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // قالب حاشیه را برای هر سلول تنظیم می‌کند
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

    // فایل PPTX را روی دیسک می‌نویسد
    pres.save("SplitCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **تغییر رنگ پس‌زمینه سلول جدول**

این کد Java نشان می‌دهد چگونه رنگ پس‌زمینه یک سلول جدول را تغییر دهید:

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

## **اضافه کردن تصویر در داخل سلول جدول**
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.  
2. مرجع یک اسلاید را با استفاده از ایندکس آن دریافت کنید.  
3. یک آرایه از ستون‌ها با عرض تعریف کنید.  
4. یک آرایه از ردیف‌ها با ارتفاع تعریف کنید.  
5. با استفاده از متد [AddTable](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) یک جدول به اسلاید اضافه کنید.  
6. یک شیء `Images` ایجاد کنید تا فایل تصویر را نگه دارد.  
7. تصویر `IImage` را به شیء `IPPImage` اضافه کنید.  
8. `FillFormat` سلول جدول را روی `Picture` تنظیم کنید.  
9. تصویر را به اولین سلول جدول اضافه کنید.  
10. ارائه اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.  

این کد Java نشان می‌دهد چگونه هنگام ایجاد جدول، تصویر را داخل یک سلول جدول قرار دهید:

```java
// یک نمونه از کلاس Presentation که نمایانگر یک فایل PPTX است
Presentation pres = new Presentation();
try {
    // به اسلاید اول دسترسی می‌یابد
    ISlide islide = pres.getSlides().get_Item(0);

    // ستون‌ها را با عرض و ردیف‌ها را با ارتفاع تعریف می‌کند
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

    // فایل PPTX را روی دیسک ذخیره می‌کند
    pres.save("Image_In_TableCell_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**آیا می‌توانم ضخامت و سبک خطوط متفاوتی برای طرف‌های مختلف یک سلول تنظیم کنم؟**

بله. حاشیه‌های [بالا](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/cellformat/#getBorderTop--)/[پایین](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/cellformat/#getBorderBottom--)/[چپ](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/cellformat/#getBorderLeft--)/[右](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/cellformat/#getBorderRight--) دارای ویژگی‌های جداگانه‌ای هستند، بنابراین ضخامت و سبک هر طرف می‌تواند متفاوت باشد. این به‌طور منطقی از کنترل حاشیه‌های طرفی برای یک سلول که در مقاله نشان داده شد، ناشی می‌شود.

**اگر بعد از تنظیم تصویر به‌عنوان پس‌زمینه سلول، اندازه ستون/ردیف را تغییر دهم، چه اتفاقی برای تصویر می‌افتد؟**

رفتار بستگی به [حالت پر کردن](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/picturefillmode/) (کشیدگی/کاشی) دارد. در حالت کشیدگی، تصویر خود را با سلول جدید منطبق می‌کند؛ در حالت کاشی، کاشی‌ها دوباره محاسبه می‌شوند. مقاله حالت‌های نمایش تصویر در یک سلول را ذکر کرده است.

**آیا می‌توانم یک پیوندهای فراوانی به تمام محتوای یک سلول اختصاص دهم؟**

[Hyperlinks](/slides/fa/androidjava/manage-hyperlinks/) در سطح متن (قسمت) داخل چارچوب متن سلول یا در سطح کل جدول/شکل تنظیم می‌شوند. در عمل، پیوند را به یک قسمت یا به تمام متن داخل سلول اختصاص می‌دهید.

**آیا می‌توانم قلم‌های متفاوتی داخل یک سلول تنظیم کنم؟**

بله. چارچوب متن یک سلول از [قسمت‌ها](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/portion/) (رون‌ها) با قالب‌بندی مستقل—خانواده قلم، سبک، اندازه و رنگ—پشتیبانی می‌کند.