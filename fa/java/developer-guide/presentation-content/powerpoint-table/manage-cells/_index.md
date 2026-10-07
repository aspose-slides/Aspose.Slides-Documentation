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
description: "مدیریت سلول‌های جدول PowerPoint در جاوا: شناسایی سلول‌های ادغام‌شده، حذف حاشیه‌ها، تقسیم سلول‌ها، و تنظیم رنگ‌های پس‌زمینه و تصاویر با Aspose.Slides برای جاوا."
---
## **نگاهی کلی**

Aspose.Slides به شما امکان دسترسی و اصلاح سلول‌های جدول در ارائه‌های PowerPoint را می‌دهد. این مقاله توضیح می‌دهد چگونه سلول‌های جدول ادغام‌شده را شناسایی کنید، خطوط مرزی سلول‌ها را حذف کنید، پس از ادغام یا تقسیم سلول‌ها با شماره‌گذاری سلول کار کنید، رنگ پس‌زمینه یک سلول را تغییر دهید و تصویری را داخل یک سلول جدول اضافه کنید. مثال‌ها نشان می‌دهند چگونه یک ارائه را ایجاد یا باز کنید، جدول را از یک اسلاید دریافت کنید، قالب‌بندی سلول را از طریق ویژگی‌های سلول به‌روزرسانی کنید و ارائهٔ اصلاح‌شده را به‌عنوان فایل PPTX ذخیره کنید.

Aspose.Slides از اندیس‌های صفر‑مبنای `(column, row)` برای دسترسی به سلول‌های جدول استفاده می‌کند.

## **شناسایی یک سلول جدول ادغام‌شده**

مثال یک ارائه موجود را باز می‌کند و اولین شکل در اسلاید اول را به عنوان جدول دریافت می‌کند. فرض می‌شود اسلاید و شکل موجود باشند و شکل یک جدول باشد. سپس تمام ردیف‌ها و ستون‌ها را پیمایش می‌کند و از [isMergedCell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#isMergedCell--) برای شناسایی سلول‌های موجود در نواحی ادغام‌شده استفاده می‌کند. برای هر مورد مطابقت، مختصات سلول را به ترتیب `row;column`، [getRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getRowSpan--)، [getColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getColSpan--) و مختصات شروع ناحیه، [getFirstRowIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstRowIndex--) و [getFirstColumnIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstColumnIndex--) چاپ می‌کند.

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

## **حذف خطوط مرزی سلول جدول**

یک [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) ایجاد کنید و با استفاده از [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) جدولی را به اسلاید اول آن اضافه کنید. عرض ستون‌ها، ارتفاع ردیف‌ها و موقعیت جدول بر حسب نقطه تعیین می‌شود. مثال تمام چهار خط مرزی سلول را به [FillType.NoFill](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) تنظیم می‌کند تا نامرئی شوند.

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

از [mergeCells](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#mergeCells-com.aspose.slides.ICell-com.aspose.slides.ICell-boolean-) برای ترکیب یک بازهٔ مستطیلی از سلول‌های جدول به یک سلول استفاده کنید. سلول‌های گوشهٔ بالا‑چپ و پایین‑راست بازه را مشخص کنید. آرگومان نهایی کنترل می‌کند آیا ادغام می‌تواند شامل سلول‌های خارج از بازهٔ مشخص شده باشد؛ `false` ادغام را در همان بازه نگه می‌دارد.

مثال یک جدول ۴×۴ با ستون‌ها و ردیف‌های ۷۰‑نقطه‌ای ایجاد می‌کند، سپس چهار سلول مرکزی را از `(1, 1)` تا `(2, 2)` ادغام می‌کند. سلول حاصل دو ستون و دو ردیف را پوشش می‌دهد، در حالی‌که شبکهٔ پایهٔ جدول همچنان شامل چهار ستون و چهار ردیف می‌ماند. برای دسترسی به محتوای سلول ادغام‌شده یا قالب‌بندی آن، از موقعیت بالا‑چپ استفاده کنید: `table.get_Item(1, 1)` در این مثال. سایر موقعیت‌های بازهٔ ادغام‌شده همچنان بخشی از شبکهٔ جدول هستند، بنابراین اندیس‌های سلول‌های خارج از بازه تغییر نمی‌کنند.

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

ادغام سلول‌ها در مثال قبلی ساختار شبکهٔ جدول را حفظ می‌کند. تقسیم یک سلول می‌تواند ستون جدیدی به شبکه اضافه کند و اندیس‌های ستون‌های سمت راست آن را تغییر دهد. Aspose.Slides مدل شبکهٔ جدول PowerPoint را دنبال می‌کند.

این مثال یک جدول ۴×۴ با ستون‌ها و ردیف‌های ۷۰‑نقطه‌ای ایجاد می‌کند و بر روی سلول `(1, 1)` متد [splitByWidth](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByWidth-double-) را فراخوانی می‌کند. نصف عرض ۷۰‑نقطه‌ای سلول به‌عنوان پارامتر عبور داده می‌شود تا دو سلول با عرض مساوی ایجاد شوند.

پس از این تقسیم، دو نیمه به صورت `table.get_Item(1, 1)` و `table.get_Item(2, 1)` قابل دسترسی هستند. شبکهٔ جدول اکنون دارای پنج ستون است: سلول‌های اولیه در ستون‌های ۲ و ۳ به ترتیب به ستون‌های ۳ و ۴ منتقل می‌شوند. اندیس‌های ردیف ثابت می‌مانند. هنگام دسترسی به سلول‌ها پس از تقسیم، از این اندیس‌های به‌روز شدهٔ ستون استفاده کنید.

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

### **تقسیم سلول‌های ادغام‌شده بر اساس مقدار ردیف یا ستون**

برای آماده‌سازی سلول‌های قالب ادغام‌شده جهت پر‑کردن داده، از [splitByRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByRowSpan-int-) برای تقسیم بر اساس مرز ردیف موجود یا از [splitByColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByColSpan-int-) برای تقسیم بر اساس مرز ستون استفاده کنید.

آرگومان `index` ردیف‌های بخش بالایی یا ستون‌های بخش چپ تقسیم را می‌شمارد؛ این مقدار نسبت به ناحیهٔ ادغام‌شده نسبی است:

- تقسیم ردیف: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getRowSpan--).
- تقسیم ستون: `0 < index <` [getColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getColSpan--).

مثال انتظار دارد که ارائه دارای جدول به‌عنوان اولین شکل در اولین اسلاید باشد و سلول‌های `(1, 2)` و `(1, 3)` به‌صورت عمودی ادغام شده باشند. از [getFirstColumnIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstColumnIndex--) و [getFirstRowIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstRowIndex--) برای یافتن مبدأ استفاده می‌کند و هر دو بازه را بررسی می‌کند. `splitByRowSpan(1)` سپس ردیف‌های ۲ و ۳ را برای نام‌های محصولات جدا می‌کند. برای ادغام افقی دو ستونی، به‌جای آن از `splitByColSpan(1)` استفاده کنید.

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

        // دریافت سلول‌های حاصل از جدول پس از تقسیم.
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

شبکهٔ جدول و اندیس‌های سلول‌های اطراف بدون تغییر می‌مانند. سلول‌های حاصل را بر حسب مختصات‌شان بازیابی کنید؛ در اینجا هر دو دارای بازهٔ ۱ هستند و [isMergedCell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#isMergedCell--) مقدار `false` را برمی‌گرداند. نواحی بزرگتر می‌توانند پس از یک تقسیم جزئی ادغام‌شده بمانند.

متن اصلی و قالب‌بندی آن در سلول بالا (یا چپ) باقی می‌مانند؛ سلول جدید خالی است اما قالب‌بندی سلول مثل پر شدن، مرزها و حاشیه‌ها را به ارث می‌برد. پس از تقسیم سلول‌ها را پر کنید و هر قالب‌بندی متنی مورد نیاز را به‌صورت صریح تنظیم کنید.

ارائهٔ ذخیره‌شده شامل سلول‌های جداگانهٔ «Product A» و «Product B» است که قالب‌بندی سلول قالب حفظ شده است. برای جزئیات بیشتر به [Cell API Reference](https://reference.aspose.com/slides/java/com.aspose.slides/cell/) مراجعه کنید.

## **تغییر رنگ پس‌زمینه سلول جدول**

این مثال جدولی با ستون‌های ۱۵۰‑نقطه‌ای و ردیف‌های ۵۰‑نقطه‌ای ایجاد می‌کند. از [setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) برای انتخاب پر کردن صاف استفاده می‌کند و رنگی که توسط [getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--) برگردانده می‌شود را برای سلول `(2, 3)` (ستون سوم و ردیف چهارم) به قرمز تنظیم می‌کند.

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

## **افزودن تصویر داخل سلول جدول**

تصویر ورودی را پیش از اجرای این مثال در پوشهٔ کاری قرار دهید. تصویر را با استفاده از [Images.fromFile](https://reference.aspose.com/slides/java/com.aspose.slides/images/#fromFile-java.lang.String-) بارگذاری می‌کند و به مجموعهٔ تصاویر ارائه با [addImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimagecollection/#addImage-com.aspose.slides.IImage-) اضافه می‌نماید. سپس تصویر را به پر کردن تصویر سلول `(0, 0)`، اولین سلول جدول، اختصاص می‌دهد.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillmode/) تصویر را برای پر کردن سلول کش می‌دهد که ممکن است نسبت عرض‑به‑ارتفاع آن را تغییر دهد. عرض ستون‌ها و ارتفاع ردیف‌ها بر حسب نقطه هستند. تصویر بارگذاری شده پس از افزودن به ارائه در یک بلوک `finally` آزاد می‌شود.

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

**آیا می‌توانم ضخامت‌ها و سبک‌های خط متفاوتی برای طرف‌های مختلف یک سلول واحد تنظیم کنم؟**

بله. خطوط مرزی [top](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderTop--)/[bottom](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderBottom--)/[left](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderLeft--)/[right](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderRight--) دارای ویژگی‌های جداگانه‌ای هستند، بنابراین ضخامت و سبک هر سمت می‌تواند متفاوت باشد.

**اگر پس از تنظیم یک تصویر به‌عنوان پس‌زمینه سلول، اندازهٔ ستون/ردیف را تغییر دهم، چه اتفاقی برای تصویر می‌افتد؟**

رفتار به [fill mode](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillmode/) (کشیدن/کاشی) بستگی دارد. در حالت کشیدن، تصویر با سلول جدید سازگار می‌شود؛ در حالت کاشی، کاشی‌ها دوباره محاسبه می‌شوند.

**آیا می‌توانم یک پیوند را به تمام محتوای یک سلول اختصاص دهم؟**

[پیوندها](/slides/fa/java/manage-hyperlinks/) در سطح بخش (portion) متن داخل چارچوب متن سلول یا در سطح کل جدول/شکل تنظیم می‌شوند. در عمل، پیوند را به یک بخش یا به تمام متن سلول اختصاص می‌دهید.

**آیا می‌توانم فونت‌های متفاوتی داخل یک سلول واحد تنظیم کنم؟**

بله. چارچوب متن یک سلول از [portions](https://reference.aspose.com/slides/java/com.aspose.slides/portion/) (بخش‌ها) با قالب‌بندی مستقل—خانوادهٔ قلم، سبک، اندازه و رنگ—پشتیبانی می‌کند.