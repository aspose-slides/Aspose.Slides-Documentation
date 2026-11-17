---
title: "مدیریت سلول‌های جدول در ارائه‌ها با استفاده از جاوا"
linktitle: "مدیریت سلول‌ها"
type: docs
weight: 30
url: /fa/java/manage-cells/
keywords:
- "سلول جدول"
- "ادغام سلول‌ها"
- "حذف حاشیه"
- "تقسیم سلول"
- "تصویر در سلول"
- "رنگ پس‌زمینه"
- "PowerPoint"
- "ارائه"
- "Java"
- "Aspose.Slides"
description: "مدیریت سلول‌های جدول PowerPoint در جاوا: شناسایی سلول‌های ترکیب‌شده، حذف حواشی، تقسیم سلول‌ها و تنظیم رنگ پس‌زمینه و تصاویر با Aspose.Slides برای جاوا."
---
## **نمای کلی**

Aspose.Slides به شما امکان دسترسی و تغییر سلول‌های جدول در ارائه‌های PowerPoint را می‌دهد. این مقاله توضیح می‌دهد چگونه سلول‌های جدول ترکیب‌شده را شناسایی کنید، حواشی سلول‌ها را حذف کنید، پس از ترکیب یا تقسیم سلول‌ها با شماره‌گذاری سلول کار کنید، رنگ پس‌زمینه یک سلول را تغییر دهید و یک تصویر را داخل یک سلول جدول اضافه کنید. مثال‌ها نشان می‌دهند چگونه یک ارائه را ایجاد یا باز کنید، جدول را از یک اسلاید دریافت کنید، قالب‌بندی سلول را از طریق ویژگی‌های سلول به‌روزرسانی کنید و ارائه تغییر یافته را به‌صورت فایل PPTX ذخیره کنید.

Aspose.Slides از اندیس‌های صفر‑پایه برای دسترسی به سلول‌های جدول به ترتیب `(column, row)` استفاده می‌کند.

## **شناسایی یک سلول جدول ترکیب‌شده**

مثال یک ارائه موجود را باز می‌کند و شکل اول در اسلاید اول را به‌عنوان جدول دسترسی می‌یابد. فرض می‌کند که اسلاید و شکل وجود دارند و شکل یک جدول است. سپس تمام ردیف‌ها و ستون‌ها را پیمایش می‌کند و از [isMergedCell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#isMergedCell--) برای شناسایی سلول‌های در نواحی ترکیب‌شده استفاده می‌کند. برای هر تطبیق، مختصات سلول را به ترتیب `row;column` چاپ می‌کند، [getRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getRowSpan--)، [getColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getColSpan--)، و مختصات شروع ناحیه، [getFirstRowIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstRowIndex--) و [getFirstColumnIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstColumnIndex--) را نیز نشان می‌دهد.

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

## **حذف حواشی سلول جدول**

یک [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) ایجاد کنید و یک جدول را به اسلاید اول آن با [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) اضافه کنید. عرض ستون‌ها، ارتفاع ردیف‌ها و موقعیت جدول بر حسب پوینت مشخص می‌شوند. مثال تمام چهار حاشیه سلول را به [FillType.NoFill](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) تنظیم می‌کند تا نامرئی شوند.

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

## **اضافه کردن حواشی مورب سلول**

از [getBorderDiagonalDown](https://reference.aspose.com/slides/java/com.aspose.slides/icellformat/#getBorderDiagonalDown--) برای رسم خطی از گوشهٔ بالا‑چپ به پایین‑راست و از [getBorderDiagonalUp](https://reference.aspose.com/slides/java/com.aspose.slides/icellformat/#getBorderDiagonalUp--) برای رسم خطی از گوشهٔ پایین‑چپ به بالا‑راست استفاده کنید. یک مورب می‌تواند سرصفحهٔ گوشه را علامت‌گذاری کند؛ هر دو مورب می‌توانند شکل X ایجاد کنند تا سلول را «نامعتبر» نشان دهند.

هر مورب یک [ILineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/) است. در [getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#getFillFormat--) آن، از [setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) برای انتخاب [FillType.Solid](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) استفاده کنید و رنگ را از طریق [getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--) انتخاب کنید. عرض خط را با [setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setWidth-double-) به پوینت تنظیم کنید.

مثال سه سلول در یک ردیف ایجاد می‌کند: یک مورب نزولی قرمز، یک مورب صعودی آبی، و هر دو مورب. حواشی بالا، پایین، چپ و راست سلول‌ها دست‌نخورده می‌مانند.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

یک مورب یک ویژگی قالب‌بندی است، نه تقسیم سلول. هر سلول یک چهارچوب متن واحد دارد که از طریق [getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getTextFrame--) دسترسی می‌شود؛ نواحی در هر دو طرف مورب را نمی‌توان به‌صورت مستقل ویرایش کرد.

![Three table cells showing a red diagonal from top-left to bottom-right, a blue diagonal from bottom-left to top-right, and both diagonals forming an X.](diagonal-cell-borders.png)

*از چپ به راست: خط مورب نزولی (قرمز، ۳ پوینت)، خط مورب صعودی (آبی، ۵ پوینت)، و هر دو خط مورب.*

## **ترکیب سلول‌های جدول**

از [mergeCells](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#mergeCells-com.aspose.slides.ICell-com.aspose.slides.ICell-boolean-) برای ترکیب یک بازهٔ مستطیل شکل از سلول‌های جدول به یک سلول استفاده کنید. سلول‌های گوشهٔ بالا‑چپ و پایین‑راست بازه را مشخص کنید. آرگومان نهایی کنترل می‌کند آیا ترکیب می‌تواند شامل سلول‌های خارج از بازه تعیین‌شده باشد؛ `false` ترکیب را محدود به همان بازه می‌کند.

مثال یک جدول ۴×۴ با ستون‌ها و ردیف‌های ۷۰ پوینتی ایجاد می‌کند، سپس چهار سلول مرکزی از `(1, 1)` تا `(2, 2)` را ترکیب می‌کند. سلول حاصل دو ستون و دو ردیف را پوشش می‌دهد، در حالی که شبکهٔ زیرین جدول هنوز چهار ستون و چهار ردیف دارد. برای دسترسی به محتوا یا قالب‌بندی سلول ترکیب‌شده، از موقعیت بالا‑چپ آن استفاده کنید: `table.get_Item(1, 1)` در این مثال. سایر موقعیت‌ها در بازه ترکیب‌شده همچنان بخشی از شبکه جدول هستند، بنابراین اندیس سلول‌های خارج از بازه تغییر نمی‌کند.

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

## **تقسیم سلول‌های جدول**

در مثال قبلی ترکیب سلول‌ها ساختار شبکهٔ جدول را حفظ می‌کند. تقسیم یک سلول می‌تواند یک ستون جدید به شبکه اضافه کند و اندیس ستون‌های سمت راست آن را تغییر دهد. Aspose.Slides مدل شبکهٔ جدول PowerPoint را دنبال می‌کند.

این مثال یک جدول ۴×۴ با ستون‌ها و ردیف‌های ۷۰ پوینتی ایجاد می‌کند و بر روی سلول `(1, 1)` از [splitByWidth](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByWidth-double-) استفاده می‌کند. نیمی از عرض ۷۰ پوینتی سلول به عنوان پارامتر پاس داده می‌شود تا دو سلول با عرض مساوی ایجاد شود.

پس از این تقسیم، دو نیمه به عنوان `table.get_Item(1, 1)` و `table.get_Item(2, 1)` دسترسی‌پذیر هستند. شبکهٔ جدول اکنون پنج ستون دارد: سلول‌های اولیه در ستون‌های ۲ و ۳ به ترتیب به ستون‌های ۳ و ۴ منتقل می‌شوند. اندیس ردیف‌ها بدون تغییر می‌مانند. هنگام دسترسی به سلول‌ها پس از تقسیم، از این اندیس‌های به‌روز شده استفاده کنید.

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

*تقسیم عرض بر روی سلول (1, 1) تاثیر می‌گذارد، با استفاده از اندیس‌های صفر‑پایه (column, row). سطرهای دیگر سلولی که هر دو موقعیت ستون جدید را پوشش می‌دهد حفظ می‌شوند.*
<!-- visual-explanation:manage-cells:end -->

### **تقسیم سلول‌های ترکیب‌شده بر اساس طول ردیف یا ستون**

برای آماده‌سازی سلول‌های قالب ترکیب‌شده برای پر کردن داده‌ها، از [splitByRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByRowSpan-int-) برای تقسیم بر اساس مرز موجود ردیف یا از [splitByColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByColSpan-int-) برای تقسیم بر اساس مرز ستون استفاده کنید.

آرگومان `index` ردیف‌های بخش بالایی یا ستون‌های بخش چپ تقسیم را می‌شمارد؛ نسبت به ناحیه ترکیب‌شده نسبی است:

- تقسیم ردیف: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getRowSpan--).
- تقسیم ستون: `0 < index <` [getColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getColSpan--).

مثال انتظار دارد که یک ارائه جدول را به‌عنوان شکل اول در اسلاید اول داشته باشد، به طوری که سلول‌های `(1, 2)` و `(1, 3)` به‌صورت عمودی ترکیب شده باشند. از موقعیت پایین شروع می‌کند، از [getFirstColumnIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstColumnIndex--) و [getFirstRowIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstRowIndex--) برای یافتن مبدأ استفاده می‌کند و هر دو طول را بررسی می‌کند. سپس `splitByRowSpan(1)` ردیف‌های ۲ و ۳ را برای نام‌های محصول جدا می‌کند. برای ترکیب افقی دو‑ستونی، به‌جای آن از `splitByColSpan(1)` استفاده کنید.

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

        // سلول‌های حاصل از جدول را پس از تقسیم بازیابی کنید.
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

شبکهٔ جدول و اندیس‌های سلول‌های اطراف بدون تغییر می‌مانند. سلول‌های حاصل را بر اساس مختصات آن‌ها بازیابی کنید؛ در اینجا هر دو طول ۱ دارند و [isMergedCell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#isMergedCell--) مقدار `false` را چاپ می‌کند. نواحی بزرگ‌تر می‌توانند پس از یک تقسیم به‌صورت جزئی ترکیب‌مانده باقی بمانند.

متن اصلی و قالب‌بندی آن در سلول بالایی (یا چپی) باقی می‌ماند؛ سلول جدید خالی است اما قالب بندی سلول مانند پرکننده، حواشی و حاشیه‌ها را به ارث می‌برد. پس از تقسیم سلول‌ها را پر کنید و هر قالب‌بندی متنی موردنیاز را به‌صورت صریح تنظیم کنید.

نمایش ذخیره‌شده شامل سلول‌های جداگانهٔ «محصول A» و «محصول B» با حفظ قالب‌بندی سلول قالب است. برای جزئیات بیشتر به [Cell API Reference](https://reference.aspose.com/slides/java/com.aspose.slides/cell/) مراجعه کنید.

### **تقسیم یک سلول با ارتفاع مشخص**

[splitByHeight](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByHeight-double-) ارتفاع بخش بالایی را بر حسب پوینت می‌گیرد. [splitByRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByRowSpan-int-) تعداد ردیف‌های موجود در بخش بالایی را می‌گیرد. برای مرکز کردن یک سلول ۴۰ پوینتی در ستون راست، ۴۰ را از ارتفاع واقعی سلول کم کنید و باقی‌مانده را به‌صورت مساوی بالاتر و پایین‌تر تقسیم کنید.

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

تقسیم اول یک ردیف شبکه اضافه می‌کند و ۹۰ پوینت پایین را در سلول `(1, 1)` می‌گذارد. تقسیم دوم آن سلول را به یک سلول میانی ۴۰ پوینتی و یک سلول پایینی ۵۰ پوینتی تقسیم می‌کند. ستون راست اکنون سه سلول با ارتفاع‌های ۵۰، ۴۰ و ۵۰ پوینت از بالا به پایین دارد. سلول چپ تمام سه ردیف را پوشش می‌دهد و ارتفاع اصلی ۱۴۰ پوینت خود را حفظ می‌کند.

![The left cell spans the full table height beside three cells with Middle in the center.](split-by-height.png)

## **تغییر رنگ پس‌زمینه سلول جدول**

این مثال جدولی با ستون‌های ۱۵۰ پوینتی و ردیف‌های ۵۰ پوینتی ایجاد می‌کند. از [setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) برای انتخاب پرکنندهٔ جامد استفاده می‌کند و رنگی که توسط [getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--) برگردانده می‌شود را برای سلول `(2, 3)` که در ستون سوم و ردیف چهارم قرار دارد، به رنگ قرمز تنظیم می‌کند.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

## **افزودن تصویر داخل یک سلول جدول**

تصویر ورودی را قبل از اجرای این مثال در پوشهٔ کاری قرار دهید. تصویر را با [Images.fromFile](https://reference.aspose.com/slides/java/com.aspose.slides/images/#fromFile-java.lang.String-) بارگیری می‌کند و با [addImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimagecollection/#addImage-com.aspose.slides.IImage-) به مجموعهٔ تصاویر ارائه اضافه می‌کند. سپس تصویر را به پرکنندهٔ تصویری سلول `(0, 0)`، اولین سلول جدول، اختصاص می‌دهد.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillmode/) تصویر را کشیده تا سلول را پر کند، که ممکن است نسبت عرض به ارتفاع آن را تغییر دهد. عرض ستون‌ها و ارتفاع ردیف‌ها بر حسب پوینت است. تصویر بارگیری‌شده پس از افزودن به ارائه در یک بلوک `finally` آزاد می‌شود.

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

## **پرسش‌های متداول**

**آیا می‌توانم ضخامت و سبک خطوط متفاوتی برای طرف‌های مختلف یک سلول تنظیم کنم؟**

بله. حواشی [بالا](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderTop--)/[پایین](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderBottom--)/[چپ](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderLeft--)/[راست](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderRight--) دارای ویژگی‌های جداگانه‌ای هستند، بنابراین ضخامت و سبک هر طرف می‌تواند متفاوت باشد.

**اگر پس از تنظیم تصویر به‌عنوان پس‌زمینه سلول، اندازهٔ ستون/ردیف را تغییر دهم، چه اتفاقی برای تصویر می‌افتد؟**

رفتار بر اساس [fill mode](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillmode/) (کشیده/کاشی) متفاوت است. با کشیده شدن، تصویر با سلول جدید سازگار می‌شود؛ با کاشی، کاشی‌ها مجدداً محاسبه می‌شوند.

**آیا می‌توانم یک ابرلینک را به تمام محتوای یک سلول اختصاص دهم؟**

[Hyperlinks](/slides/fa/java/manage-hyperlinks/) در سطح متن (بخش) داخل چهارچوب متن سلول یا در سطح کل جدول/شکل تنظیم می‌شوند. در عمل، لینک را به یک بخش یا به تمام متن داخل سلول اختصاص می‌دهید.

**آیا می‌توانم فونت‌های متفاوتی داخل یک سلول تنظیم کنم؟**

بله. چهارچوب متن یک سلول از [portions](https://reference.aspose.com/slides/java/com.aspose.slides/portion/) (بخش‌ها) با قالب‌بندی مستقل پشتیبانی می‌کند—خانوادهٔ قلم، سبک، اندازه و رنگ.