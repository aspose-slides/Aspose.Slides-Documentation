---
title: "مدیریت سلول‌های جدول در ارائه‌های اندروید"
linktitle: "مدیریت سلول‌ها"
type: docs
weight: 30
url: /fa/androidjava/manage-cells/
keywords:
- "سلول جدول"
- "ادغام سلول‌ها"
- "حذف حاشیه"
- "تقسیم سلول"
- "تصویر در سلول"
- "رنگ پس‌زمینه"
- "PowerPoint"
- "ارائه"
- "اندروید"
- "جاوا"
- "Aspose.Slides"
description: "مدیریت سلول‌های جدول PowerPoint در اندروید: شناسایی سلول‌های ادغام‌شده، حذف حاشیه‌ها، تقسیم سلول‌ها، و تنظیم رنگ‌های پس‌زمینه و تصاویر با Aspose.Slides برای اندروید از طریق جاوا."
---
## **بررسی کلی**

Aspose.Slides به شما امکان دسترسی و اصلاح سلول‌های جدول در ارائه‌های PowerPoint را می‌دهد. این مقاله توضیح می‌دهد چگونه سلول‌های جدول ادغام‌شده را شناسایی کنید، مرزهای سلول را حذف کنید، با شماره‌گذاری سلول پس از ادغام یا تقسیم سلول‌ها کار کنید، رنگ پس‌زمینه یک سلول را تغییر دهید و تصویر را درون یک سلول جدول اضافه کنید. مثال‌ها نشان می‌دهند چگونه یک ارائه را ایجاد یا باز کنید، جدول را از یک اسلاید دریافت کنید، قالب‌بندی سلول را از طریق ویژگی‌های سلول به‌روزرسانی کنید و ارائه اصلاح‌شده را به‌صورت فایل PPTX ذخیره نمایید.

Aspose.Slides از شاخص‌های صفر‑پایه برای دسترسی به سلول‌های جدول به ترتیب `(column, row)` استفاده می‌کند.

## **شناسایی یک سلول جدول ادغام‌شده**

مثال یک ارائه موجود را باز می‌کند و اولین شکل در اولین اسلاید را به عنوان جدول دسترسی می‌یابد. فرض می‌شود اسلاید و شکل وجود داشته باشند و شکل یک جدول باشد. سپس بر تمام ردیف‌ها و ستون‌ها تکرار می‌کند و از [isMergedCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#isMergedCell--) برای شناسایی سلول‌های در نواحی ادغام‌شده استفاده می‌نماید. برای هر مطابقت، مختصات سلول را به ترتیب `row;column` چاپ می‌کند، [getRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getRowSpan--)، [getColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getColSpan-- ) و مختصات شروع ناحیه، [getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) و [getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--) را چاپ می‌کند.

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

## **حذف مرزهای سلول جدول**

یک [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) ایجاد کنید و جدول را به اولین اسلاید آن با [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) اضافه کنید. عرض ستون‌ها، ارتفاع ردیف‌ها و موقعیت جدول به نقطه (points) مشخص می‌شوند. مثال تمام چهار مرز سلول را به [FillType.NoFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) تنظیم می‌کند تا نامرئی شوند.

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

## **ادغام سلول‌های جدول**

از [mergeCells](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#mergeCells-com.aspose.slides.ICell-com.aspose.slides.ICell-boolean-) برای ترکیب یک محدوده مستطیلی از سلول‌های جدول به یک سلول استفاده کنید. سلول‌های گوشه بالا‑چپ و پایین‑راست محدوده را مشخص کنید. آرگومان نهایی کنترل می‌کند که آیا ادغام می‌تواند شامل سلول‌های خارج از محدوده مشخص‌شده باشد یا نه؛ مقدار `false` ادغام را درون آن محدوده نگه می‌دارد.

مثال یک جدول ۴×۴ با ستون‌ها و ردیف‌های ۷۰ نقطه‌ای ایجاد می‌کند، سپس چهار سلول مرکزی را از `(1, 1)` تا `(2, 2)` ادغام می‌نماید. سلول حاصل به دو ستون و دو ردیف گسترش می‌یابد، در حالی که جدول زیرین همچنان چهار ستون و چهار ردیف را حفظ می‌کند. برای دسترسی به محتوای یا قالب‌بندی سلول ادغام‌شده، از موقعیت بالا‑چپ آن استفاده کنید: `table.get_Item(1, 1)` در این مثال. سایر موقعیت‌های درون محدوده ادغام‌شده همچنان جزئی از شبکه جدول هستند، بنابراین شاخص‌های سلول‌های خارج از محدوده تغییر نمی‌کند.

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

ادغام سلول‌ها در مثال قبلی ساختار شبکه جدول را حفظ می‌کند. تقسیم یک سلول می‌تواند یک ستون جدید به شبکه اضافه کند و شاخص‌های ستونی سلول‌های سمت راست آن را تغییر دهد. Aspose.Slides از مدل شبکه جدول PowerPoint پیروی می‌کند.

این مثال یک جدول ۴×۴ با ستون‌ها و ردیف‌های ۷۰ نقطه ایجاد می‌کند و به سلول `(1, 1)` متد [splitByWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByWidth-double-) را فراخوانی می‌کند. نیمی از عرض ۷۰ نقطه‌ای سلول برای ایجاد دو سلول با عرض مساوی استفاده می‌شود.

پس از این تقسیم، دو نیمه به صورت `table.get_Item(1, 1)` و `table.get_Item(2, 1)` دسترسی پیدا می‌کنند. شبکه جدول حالا پنج ستون دارد: سلول‌های اصلی در ستون‌های ۲ و ۳ به ستون‌های ۳ و ۴ منتقل می‌شوند. شاخص‌های ردیف‌ همانند قبلی می‌مانند. هنگام دسترسی به سلول‌ها بعد از تقسیم، از این شاخص‌های ستون به‌روز شده استفاده کنید.

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

### **تقسیم سلول‌های ادغام‌شده بر اساس محدوده‌ی ردیف یا ستون**

برای آماده‌سازی سلول‌های قالب ادغام‌شده برای پر کردن داده، از [splitByRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByRowSpan-int-) برای تقسیم بر اساس مرز ردیف موجود، یا از [splitByColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByColSpan-int-) برای تقسیم بر اساس مرز ستون استفاده کنید.

`آرگومان` `index` ردیف‌ها را در بخش بالایی یا ستون‌ها را در بخش چپ تقسیم می‌شمارد؛ نسبت به ناحیه‌ی ادغام‌شده است:

- تقسیم ردیف: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getRowSpan--).
- تقسیم ستون: `0 < index <` [getColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getColSpan--).

مثال انتظار دارد ارائه شامل جدول به عنوان اولین شکل در اولین اسلاید باشد، به‌طوری که `(1, 2)` و `(1, 3)` به صورت عمودی ادغام شده باشند. از موقعیت پایین شروع می‌شود و از [getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--) و [getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) برای یافتن مبدأ استفاده می‌کند و هر دو محدوده را بررسی می‌نماید. سپس `splitByRowSpan(1)` ردیف‌های ۲ و ۳ را برای نام محصولات جدا می‌کند. برای ادغام افقی دو ستونی، به‌جای آن از `splitByColSpan(1)` استفاده کنید.

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

شبکه جدول و شاخص‌های سلول‌های اطراف بدون تغییر باقی می‌مانند. سلول‌های حاصل را با مختصاتشان بازیابی کنید؛ در اینجا هر دو دارای محدوده ۱ هستند و [isMergedCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#isMergedCell--) `false` چاپ می‌کند. نواحی بزرگ‌تر می‌توانند پس از یک تقسیم جزئیاً ادغام‌شده بمانند.

متن اصلی و قالب‌بندی آن در سلول بالایی (یا چپ) باقی می‌ماند؛ سلول جدید خالی است اما قالب‌بندی سلول مانند پرکردن، مرزها و حاشیه‌ها را به ارث می‌برد. پس از تقسیم سلول‌ها را پر کنید و هر قالب‌بندی متنی لازم را به صورت صریح تنظیم کنید.

ارائه ذخیره‌شده شامل سلول‌های جداگانه‌ی «Product A» و «Product B» با حفظ قالب‌بندی سلول‌های قالب است. برای جزئیات، به [Cell API Reference](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cell/) مراجعه کنید.

## **تغییر رنگ پس‌زمینه سلول جدول**

این مثال جدولی با ستون‌های ۱۵۰ نقطه‌ای و ردیف‌های ۵۰ نقطه‌ای ایجاد می‌کند. از [setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) برای انتخاب پرکردن ثابت استفاده می‌کند و رنگ بازگردانده‌شده توسط [getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--) را برای سلول `(2, 3)` که در ستون سوم و ردیف چهارم است، به رنگ قرمز تنظیم می‌نماید.

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

## **اضافه کردن تصویر درون سلول جدول**

تصویر ورودی را قبل از اجرای این مثال در مسیر کاری قرار دهید. تصویر را با [Images.fromFile](https://reference.aspose.com/slides/androidjava/com.aspose.slides/images/#fromFile-java.lang.String-) بارگذاری می‌کند و به مجموعه تصویرهای ارائه با [addImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagecollection/#addImage-com.aspose.slides.IImage-) اضافه می‌نماید. سپس تصویر را به پرکردن تصویر سلول `(0, 0)`، اولین سلول جدول، اختصاص می‌دهد.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillmode/) تصویر را کشیده تا سلول را پر کند، که ممکن است نسبت تصویر را تغییر دهد. عرض ستون‌ها و ارتفاع ردیف‌ها به نقطه (points) هستند. تصویر بارگذاری‌شده پس از افزودن به ارائه در یک بلوک `finally` آزاد می‌شود.

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

## **پرسش‌وپاسخ**

**آیا می‌توانم ضخامت و سبک خطوط متفاوتی برای هر سمت یک سلول تعیین کنم؟**

بله. مرزهای [top](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderTop--)/[bottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderBottom--)/[left](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderLeft--)/[right](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderRight--) دارای ویژگی‌های جداگانه‌ای هستند، بنابراین ضخامت و سبک هر سمت می‌تواند متفاوت باشد.

**اگر پس از تنظیم تصویر به‌عنوان پس‌زمینه سلول، اندازه ستون/ردیف را تغییر دهم، چه اتفاقی برای تصویر می‌افتد؟**

رفتار بستگی به [fill mode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillmode/) دارد (stretch/tile). با کشش، تصویر با سلول جدید سازگار می‌شود؛ با کاشی‌گذاری، کاشی‌ها مجدداً محاسبه می‌شوند.

**آیا می‌توانم یک پیوند‌هایپرمتن به تمام محتوای یک سلول اختصاص دهم؟**

[Hyperlinks](/slides/fa/androidjava/manage-hyperlinks/) در سطح متن (بخش) داخل فریم متن سلول یا در سطح کل جدول/شکل تنظیم می‌شوند. در عمل، پیوند را به یک بخش یا به تمام متن داخل سلول اختصاص می‌دهید.

**آیا می‌توانم فونت‌های متفاوتی داخل یک سلول تنظیم کنم؟**

بله. فریم متن یک سلول از [portions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/) (بخش‌ها) با قالب‌بندی مستقل—خانواده فونت، سبک، اندازه و رنگ—پشتیبانی می‌کند.