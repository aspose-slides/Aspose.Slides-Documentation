---
title: مدیریت سلول‌های جدول در ارائه‌ها در اندروید
linktitle: مدیریت سلول‌ها
type: docs
weight: 30
url: /fa/androidjava/manage-cells/
keywords:
- سلول جدول
- ادغام سلول‌ها
- حذف حاشیه
- جداسازی سلول
- تصویر در سلول
- رنگ پس‌زمینه
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "مدیریت سلول‌های جدول PowerPoint در اندروید: شناسایی سلول‌های ادغام‌شده، حذف حاشیه‌ها، جداسازی سلول‌ها، و تنظیم رنگ‌های پس‌زمینه و تصاویر با Aspose.Slides برای اندروید از طریق Java."
---
## **نمای کلی**

Aspose.Slides به شما اجازه می‌دهد تا به سلول‌های جدول در ارائه‌های PowerPoint دسترسی داشته و آنها را تغییر دهید. این مقاله توضیح می‌دهد چگونه سلول‌های جدول ادغام‌شده را شناسایی کنید، حاشیه‌های سلول را حذف کنید، پس از ادغام یا جداسازی سلول‌ها با شماره‌گذاری سلول کار کنید، رنگ پس‌زمینه یک سلول را تغییر دهید و تصویری را داخل یک سلول جدول اضافه کنید. مثال‌ها نشان می‌دهند چگونه یک ارائه ایجاد یا باز کنید، جدول را از یک اسلاید دریافت کنید، قالب‌بندی سلول را از طریق خصوصیات سلول به‌روزرسانی کنید و ارائه تغییر یافته را به صورت فایل PPTX ذخیره کنید.

Aspose.Slides از ایندکس‌های صفر‑مبنا برای دسترسی به سلول‌های جدول به ترتیب `(column, row)` استفاده می‌کند.

## **شناسایی سلول جدول ادغام‌شده**

مثال یک ارائه موجود را باز می‌کند و اولین شکل در اولین اسلاید را به عنوان جدول دسترسی می‌یابد. فرض می‌کند که اسلاید و شکل وجود دارند و شکل یک جدول است. سپس تمام ردیف‌ها و ستون‌ها را پیمایش می‌کند و از [isMergedCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#isMergedCell--) برای شناسایی سلول‌های در نواحی ادغام‌شده استفاده می‌کند. برای هر مطابقت، مختصات سلول را به ترتیب `row;column` چاپ می‌کند، [getRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getRowSpan--)، [getColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getColSpan--) و مختصات شروع ناحیه را، [getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) و [getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--) ارائه می‌دهد.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation_with_table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);

    int rowCount = table.getRows().size();
    for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
    {
        int columnCount = table.getColumns().size();
        for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
        {
            ICell cell = table.get_Item(columnIndex, rowIndex);
            if (cell.isMergedCell())
            {
                System.out.printf("Cell %d;%d belongs to a merged region with RowSpan=%d and ColSpan=%d starting at %d;%d.%n", rowIndex, columnIndex, cell.getRowSpan(), cell.getColSpan(), cell.getFirstRowIndex(), cell.getFirstColumnIndex());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **حذف حاشیه‌های سلول جدول**

یک [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) ایجاد کنید و با [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) یک جدول به اولین اسلاید اضافه کنید. عرض ستون‌ها، ارتفاع ردیف‌ها و موقعیت جدول بر حسب نقاط (points) مشخص می‌شود. مثال همه چهار حاشیه سلول را به [FillType.NoFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) تنظیم می‌کند تا نامرئی شوند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 50, 50, 50, 50 };
    double[] rowHeights = { 50, 30, 30, 30, 30 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (IRow row : table.getRows())
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill);
        }

    presentation.save("table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **افزودن حاشیه‌های قطری سلول**

از [getBorderDiagonalDown](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icellformat/#getBorderDiagonalDown--) برای رسم خطی از گوشه بالا‑چپ به گوشه پایین‑راست و از [getBorderDiagonalUp](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icellformat/#getBorderDiagonalUp--) برای رسم خطی از گوشه پایین‑چپ به گوشه بالا‑راست استفاده کنید. یک قطر می‌تواند سرعنوان گوشه باشد؛ هر دو قطر می‌توانند یک X تشکیل دهند تا سلول به عنوان «قابل اعمال نیست» علامت‌گذاری شود.

هر قطر یک [ILineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/) است. در [getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#getFillFormat--) از [setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) برای انتخاب [FillType.Solid](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) و از طریق [getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--) یک رنگ انتخاب کنید. عرض خط را با [setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setWidth-double-) به نقاط تنظیم کنید.

مثال سه سلول در یک ردیف ایجاد می‌کند: یک قطر نزولی قرمز، یک قطر صعودی آبی و هر دو قطر. حاشیه‌های بالا، پایین، چپ و راست سلول دست‌نخورده می‌مانند.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 210, 210, 210 };
    double[] rowHeights = { 160 };
    ITable table = slide.getShapes().addTable(45, 130, columnWidths, rowHeights);

    ILineFormat downwardBorder = table.get_Item(0, 0).getCellFormat().getBorderDiagonalDown();
    downwardBorder.getFillFormat().setFillType(FillType.Solid);
    downwardBorder.getFillFormat().getSolidFillColor().setColor(Color.RED);
    downwardBorder.setWidth(3);

    ILineFormat upwardBorder = table.get_Item(1, 0).getCellFormat().getBorderDiagonalUp();
    upwardBorder.getFillFormat().setFillType(FillType.Solid);
    upwardBorder.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    upwardBorder.setWidth(5);

    ILineFormat crossDownwardBorder = table.get_Item(2, 0).getCellFormat().getBorderDiagonalDown();
    crossDownwardBorder.getFillFormat().setFillType(FillType.Solid);
    crossDownwardBorder.getFillFormat().getSolidFillColor().setColor(Color.RED);
    crossDownwardBorder.setWidth(3);

    ILineFormat crossUpwardBorder = table.get_Item(2, 0).getCellFormat().getBorderDiagonalUp();
    crossUpwardBorder.getFillFormat().setFillType(FillType.Solid);
    crossUpwardBorder.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    crossUpwardBorder.setWidth(5);

    presentation.save("diagonal_cell_borders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

یک قطر یک ویژگی قالب‌بندی است، نه جداسازی سلول. هر سلول یک فریم متن منفرد دارد که از طریق [getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getTextFrame--) قابل دسترسی است؛ نواحی هر دو طرف یک قطر نمی‌توانند به‌صورت مستقل ویرایش شوند.

جدولی که ذخیره شده و در Microsoft PowerPoint رندر می‌شود:

![Three table cells showing a red diagonal from top-left to bottom-right, a blue diagonal from bottom-left to top-right, and both diagonals forming an X.](diagonal-cell-borders.png)

*از چپ به راست: قطر نزولی (قرمز، 3 pt)، قطر صعودی (آبی، 5 pt) و هر دو قطر.*

## **ادغام سلول‌های جدول**

از [mergeCells](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#mergeCells-com.aspose.slides.ICell-com.aspose.slides.ICell-boolean-) برای ترکیب یک بازه مستطیلی از سلول‌های جدول به یک سلول واحد استفاده کنید. سلول‌های گوشهٔ بالا‑چپ و پایین‑راست بازه را مشخص کنید. آرگومان نهایی تعیین می‌کند آیا ادغام می‌تواند شامل سلول‌های خارج از بازه مشخص شده باشد؛ `false` ادغام را داخل همان بازه نگه می‌دارد.

مثال یک جدول 4 در 4 با ستون‌ها و ردیف‌های 70 نقطه‌ای ایجاد می‌کند و سپس چهار سلول مرکزی را از `(1, 1)` تا `(2, 2)` ادغام می‌کند. سلول حاصل دو ستون و دو ردیف را اشغال می‌کند، در حالی که شبکهٔ زیرین جدول هنوز چهار ستون و چهار ردیف دارد. برای دسترسی به محتوا یا قالب‌بندی سلول ادغام‌شده، از موقعیت بالا‑چپ آن استفاده کنید: `table.get_Item(1, 1)` در این مثال. سایر موقعیت‌ها در بازهٔ ادغام همچنان جزئی از شبکهٔ جدول باقی می‌مانند، بنابراین ایندکس‌های سلول‌های خارج از بازه تغییر نمی‌کنند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 70, 70, 70, 70 };
    double[] rowHeights = { 70, 70, 70, 70 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 2), false);

    presentation.save("merged_cells.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **جداسازی سلول‌های جدول**

ادغام سلول‌ها در مثال قبلی شبکهٔ جدول را حفظ می‌کند. جداسازی یک سلول می‌تواند یک ستون جدید به شبکه اضافه کند و ایندکس‌های ستون سلول‌های سمت راست آن را تغییر دهد. Aspose.Slides مدل شبکهٔ جدول PowerPoint را دنبال می‌کند.

این مثال یک جدول 4 در 4 با ستون‌ها و ردیف‌های 70 نقطه‌ای ایجاد می‌کند و بر روی سلول `(1, 1)` از [splitByWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByWidth-double-) فراخوانی می‌کند. نصف عرض 70 نقطه‌ای سلول به‌عنوان مقدار برای ایجاد دو سلول با عرض برابر پاس داده می‌شود.

پس از این جداسازی، دو نیم به عنوان `table.get_Item(1, 1)` و `table.get_Item(2, 1)` قابل دسترس هستند. شبکهٔ جدول اکنون پنج ستون دارد: سلول‌های اصلی در ستون‌های 2 و 3 به ترتیب به ستون‌های 3 و 4 منتقل می‌شوند. ایندکس‌های ردیف بدون تغییر می‌مانند. هنگام دسترسی به سلول‌ها پس از جداسازی از این ایندکس‌های ستون به‌روز شده استفاده کنید.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 70, 70, 70, 70 };
    double[] rowHeights = { 70, 70, 70, 70 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 1).splitByWidth(table.get_Item(1, 1).getWidth() / 2);

    presentation.save("split_cells.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

<!-- visual-explanation:manage-cells:start -->
[![An unmerged 70-point cell splits into two 35-point cells, adding a fifth grid column and shifting the indices to its right.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*تقسیم عرض بر روی سلول (1, 1) که 70‑نقطه است باعث ایجاد دو سلول 35‑نقطه‌ای می‌شود، یک ستون پنجم به شبکه اضافه می‌کند و ایندکس‌های سمت راست آن را جابه‌جا می‌کند. سایر ردیف‌ها سلولی با پوشش دو موقعیت جدید ستون دارند.*
<!-- visual-explanation:manage-cells:end -->

### **جداسازی سلول‌های ادغام‌شده بر اساس ردیف یا ستون**

برای آماده‌سازی سلول‌های قالب ادغام‌شده برای پر کردن داده‌ها، از [splitByRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByRowSpan-int-) برای جداسازی بر روی مرز ردیف موجود یا از [splitByColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByColSpan-int-) برای جداسازی بر روی مرز ستون استفاده کنید.

آرگومان `index` تعداد ردیف‌های در بخش بالا یا تعداد ستون‌های در بخش چپ جداسازی را می‌شمارد؛ این مقدار نسبت به ناحیهٔ ادغام‌شده است:

- جداسازی ردیف: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getRowSpan--).
- جداسازی ستون: `0 < index <` [getColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getColSpan--).

مثال فرض می‌کند یک ارائه جدول به‌عنوان اولین شکل در اولین اسلاید دارد که سلول‌های `(1, 2)` و `(1, 3)` به صورت عمودی ادغام شده‌اند. از موقعیت پایین شروع می‌کند، از [getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--) و [getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) برای یافتن مبدأ استفاده می‌کند و هر دو بازه را بررسی می‌کند. سپس `splitByRowSpan(1)` ردیف‌های 2 و 3 را برای نام محصول جدا می‌کند. برای ادغام افقی دو ستونی، به‌جای آن از `splitByColSpan(1)` استفاده کنید.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table_template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);

    ICell selectedCell = table.get_Item(1, 3);
    int firstColumnIndex = selectedCell.getFirstColumnIndex();
    int firstRowIndex = selectedCell.getFirstRowIndex();
    ICell mergedCell = table.get_Item(firstColumnIndex, firstRowIndex);

    if (mergedCell.isMergedCell() && mergedCell.getRowSpan() == 2 && mergedCell.getColSpan() == 1)
    {
        mergedCell.splitByRowSpan(1);

        // سلول‌های حاصل پس از جداسازی را از جدول بازیابی کنید.
        ICell upperCell = table.get_Item(firstColumnIndex, firstRowIndex);
        ICell lowerCell = table.get_Item(firstColumnIndex, firstRowIndex + 1);
        System.out.println("Upper cell merged: " + upperCell.isMergedCell());
        System.out.println("Lower cell merged: " + lowerCell.isMergedCell());

        upperCell.getTextFrame().setText("Product A");
        lowerCell.getTextFrame().setText("Product B");

        presentation.save("split_template.pptx", SaveFormat.Pptx);
    }
    else
    {
        System.out.println("Select a merged region spanning exactly two rows and one column.");
    }
} finally {
    presentation.dispose();
}
```

شبکهٔ جدول و ایندکس‌های سلول‌های اطراف بدون تغییر باقی می‌مانند. سلول‌های حاصل را با مختصاتشان بازیابی کنید؛ در اینجا هر دو بازهٔ 1 دارند و [isMergedCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#isMergedCell--) `false` چاپ می‌شود. نواحی بزرگ‌تر می‌توانند پس از یک جداسازی جزئی ادغام باقی بمانند.

متن اصلی و قالب‌بندی آن در سلول بالایی (یا چپ) باقی می‌ماند؛ سلول جدید خالی است اما قالب‌بندی سلول مانند پرکن، حاشیه و حاشیه داخلی را به ارث می‌برد. پس از جداسازی سلول‌ها را پر کنید و هر قالب‌بندی متنی مورد نیاز را به‌صورت صریح تنظیم کنید.

ارائهٔ ذخیره‌شده شامل سلول‌های جداگانه «Product A» و «Product B» است که قالب‌بندی سلول قالب اصلی حفظ شده است. برای جزئیات بیشتر به [Cell API Reference](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cell/) مراجعه کنید.

### **جداسازی سلول بر اساس ارتفاع مشخص**

[splitByHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByHeight-double-) ارتفاع بخش بالایی را بر حسب نقاط می‌گیرد. [splitByRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByRowSpan-int-) تعداد ردیف‌های موجود در بخش بالایی را می‌گیرد. برای مرکز کردن یک سلول 40‑نقطه‌ای در ستون راست، 40 را از ارتفاع واقعی سلول کم کنید و فضای باقی‌مانده را به‌صورت مساوی بالا و پایین تقسیم کنید.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 160, 160 };
    double[] rowHeights = { 140 };

    ITable table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);
    table.get_Item(0, 0).getTextFrame().setText("Left");

    double height = table.get_Item(1, 0).getHeight();
    double margin = (height - 40) / 2;

    table.get_Item(1, 0).splitByHeight(margin);
    table.get_Item(1, 1).splitByHeight(40);
    table.get_Item(1, 1).getTextFrame().setText("Middle");

    presentation.save("split_by_height.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

جداسازی اول یک ردیف شبکه اضافه می‌کند و 90‑نقطهٔ پایین را در سلول `(1, 1)` می‌گذارد. جداسازی دوم آن سلول را به یک سلول میانی 40‑نقطه‌ای و یک سلول پایینی 50‑نقطه‌ای تقسیم می‌کند. ستون راست اکنون سه سلول با ارتفاع‌های 50، 40 و 50 نقطه از بالا به پایین دارد. سلول چپ تمام سه ردیف را شامل می‌شود و ارتفاع اصلی 140 نقطه‌ای خود را حفظ می‌کند.

![The left cell spans the full table height beside three cells with Middle in the center.](split-by-height.png)

## **تغییر رنگ پس‌زمینه سلول جدول**

این مثال جدولی با ستون‌های 150‑نقطه‌ای و ردیف‌های 50‑نقطه‌ای ایجاد می‌کند. از [setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) برای انتخاب پرکن جامد استفاده می‌کند و رنگ بازگردانده شده توسط [getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--) را به قرمز برای سلول `(2, 3)` (ستون سوم، ردیف چهارم) تنظیم می‌سازد.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 150, 150, 150, 150 };
    double[] rowHeights = { 50, 50, 50, 50, 50 };
    ITable table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    ICell cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid);
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

    presentation.save("cell_background_color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **افزودن تصویر داخل سلول جدول**

تصویر ورودی را قبل از اجرای این مثال در پوشهٔ کاری قرار دهید. تصویر را با [Images.fromFile](https://reference.aspose.com/slides/androidjava/com.aspose.slides/images/#fromFile-java.lang.String-) بارگذاری می‌کند و با [addImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagecollection/#addImage-com.aspose.slides.IImage-) به مجموعهٔ تصاویر ارائه اضافه می‌نماید. سپس تصویر را به پرکن تصویر سلول `(0, 0)` (اولین سلول جدول) اختصاص می‌دهد.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillmode/) تصویر را برای پر کردن سلول کشیده می‌کند که ممکن است نسبت ابعاد آن را تغییر دهد. عرض ستون‌ها و ارتفاع ردیف‌ها بر حسب نقاط است. تصویر بارگذاری‌شده پس از افزودن به ارائه در یک بلوک `finally` آزاد می‌شود.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 150, 150, 150, 150 };
    double[] rowHeights = { 100, 100, 100, 100, 90 };
    ITable table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    IPPImage ppImage;
    IImage image = Images.fromFile("aspose_logo.jpg");
    try {
        ppImage = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }

    table.get_Item(0, 0).getCellFormat().getFillFormat().setFillType(FillType.Picture);
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);

    presentation.save("table_cell_with_image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **سوالات متداول**

**آیا می‌توانم ضخامت و سبک خطوط متفاوتی برای طرف‌های مختلف یک سلول تنظیم کنم؟**

بله. حاشیه‌های [top](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderTop--)/[bottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderBottom--)/[left](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderLeft--)/[right](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderRight--) دارای ویژگی‌های جداگانه‌ای هستند، بنابراین ضخامت و سبک هر طرف می‌تواند متفاوت باشد.

**اگر پس از تنظیم تصویر به‌عنوان پس‌زمینه سلول، اندازهٔ ستون/ردیف را تغییر دهم، چه اتفاقی برای تصویر می‌افتد؟**

رفتار بستگی به [fill mode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillmode/) (stretch/tile) دارد. در حالت کشیده شدن (stretch)، تصویر با سلول جدید سازگار می‌شود؛ در حالت کاشی (tile) کاشی‌ها مجدداً محاسبه می‌شوند.

**آیا می‌توانم یک پیوند را به تمام محتوای یک سلول اختصاص دهم؟**

[Hyperlinks](/slides/fa/androidjava/manage-hyperlinks/) در سطح بخش متن (portion) داخل فریم متن سلول یا در سطح کل جدول/شکل تنظیم می‌شوند. در عمل، پیوند را به یک بخش یا به تمام متن سلول اختصاص می‌دهید.

**آیا می‌توانم قلم‌های متفاوتی را در یک سلول استفاده کنم؟**

بله. فریم متن یک سلول از [portions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/) (بخش‌ها) با قالب‌بندی مستقل—خانواده قلم، سبک، اندازه و رنگ—پشتیبانی می‌کند.