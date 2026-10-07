---
title: مدیریت سلول‌های جدول در ارائه‌ها با استفاده از پایتون
linktitle: مدیریت سلول‌ها
type: docs
weight: 30
url: /fa/python-java/manage-cells/
keywords:
- سلول جدول
- ادغام سلول‌ها
- حذف حاشیه
- تقسیم سلول
- تصویر در سلول
- رنگ پس‌زمینه
- PowerPoint
- ارائه
- Python
- Aspose.Slides
description: "مدیریت سلول‌های جدول PowerPoint در پایتون: شناسایی سلول‌های ادغام‌شده، حذف حاشیه‌ها، تقسیم سلول‌ها و تنظیم رنگ‌های پس‌زمینه و تصاویر با Aspose.Slides برای پایتون از طریق جاوا."
---
## **بررسی کلی**

Aspose.Slides به شما امکان دسترسی و تغییر سلول‌های جدول در ارائه‌های پاورپوینت را می‌دهد. این مقاله توضیح می‌دهد چگونه سلول‌های جدول ادغام‌شده را شناسایی کنید، مرزهای سلول را حذف کنید، پس از ادغام یا تقسیم سلول‌ها با شماره‌گذاری سلول کار کنید، رنگ پس‌زمینه یک سلول را تغییر دهید و یک تصویر را داخل سلول جدول اضافه کنید. نمونه‌ها نشان می‌دهند چگونه یک ارائه را ایجاد یا باز کنید، جدول را از یک اسلاید دریافت کنید، قالب‌بندی سلول را از طریق ویژگی‌های سلول به‌روز کنید و ارائه تغییر یافته را به عنوان فایل PPTX ذخیره کنید.

Aspose.Slides از شاخص‌های صفر-پایه برای دسترسی به سلول‌های جدول به ترتیب `(column, row)` استفاده می‌کند.

## **شناسایی سلول جدول ادغام‌شده**

مثال یک ارائه موجود را باز می‌کند و به اولین شکل در اولین اسلاید به عنوان جدول دسترسی پیدا می‌کند. فرض می‌کند که اسلاید و شکل وجود دارند و شکل یک جدول است. سپس از تمام سطرها و ستون‌ها عبور می‌کند و از [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) برای شناسایی سلول‌های در نواحی ادغام‌شده استفاده می‌کند. برای هر تطابق، مختصات سلول را به ترتیب `row;column` چاپ می‌کند، [getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan)، [getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan)، و مختصات شروع ناحیه را که شامل [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) و [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex) می‌شود.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation_with_table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    row_count = table.getRows().size()
    for row_index in range(row_count):
        column_count = table.getColumns().size()
        for column_index in range(column_count):
            cell = table.get_Item(column_index, row_index)
            if cell.isMergedCell():
                print(f"Cell {row_index};{column_index} belongs to a merged region with RowSpan={cell.getRowSpan()} and ColSpan={cell.getColSpan()} starting at {cell.getFirstRowIndex()};{cell.getFirstColumnIndex()}.")
finally:
    presentation.dispose()
```

## **حذف حاشیه‌های سلول جدول**

یک [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) ایجاد کنید و یک جدول را به اولین اسلاید آن با [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable) اضافه کنید. عرض ستون‌ها، ارتفاع سطرها و موقعیت جدول بر حسب پوینت تعیین شده‌اند. مثال تمام چهار حاشیه سلول را به [FillType.NoFill](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) تنظیم می‌کند تا نامرئی شوند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill)

    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ادغام سلول‌های جدول**

از [mergeCells](https://reference.aspose.com/slides/python-java/aspose.slides/table/#mergeCells) برای ترکیب یک بازه مستطیلی از سلول‌های جدول به یک سلول استفاده کنید. سلول‌های گوشه بالا‑چپ و پایین‑راست بازه را مشخص کنید. آرگومان نهایی تعیین می‌کند که آیا ادغام می‌تواند شامل سلول‌های خارج از بازه مشخص شود یا نه؛ `False` ادغام را درون همان بازه نگه می‌دارد.

مثال یک جدول ۴x۴ با ستون‌ها و سطرهای ۷۰ پوینت ایجاد می‌کند، سپس چهار سلول مرکزی را از `(1, 1)` تا `(2, 2)` ادغام می‌کند. سلول حاصل دو ستون و دو سطر را در بر می‌گیرد، در حالی که شبکه زیرین جدول همچنان چهار ستون و چهار سطر دارد. برای دسترسی به محتوا یا قالب‌بندی سلول ادغام‌شده، از موقعیت بالا‑چپ آن استفاده کنید: `table.get_Item(1, 1)` در این مثال. سایر موقعیت‌های در بازه ادغام‌شده بخشی از شبکه جدول باقی می‌مانند، بنابراین شاخص‌های سلول‌های خارج از بازه تغییر نمی‌کنند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 2), False)

    presentation.save("merged_cells.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تقسیم سلول‌های جدول**

ادغام سلول‌ها در مثال قبلی ساختار شبکه جدول را حفظ می‌کند. تقسیم یک سلول می‌تواند یک ستون جدید در شبکه ایجاد کند و شاخص‌های ستون سلول‌های سمت راست آن را تغییر دهد. Aspose.Slides مدل شبکه جدول پاورپوینت را دنبال می‌کند.

این مثال یک جدول ۴x۴ با ستون‌ها و سطرهای ۷۰ پوینت ایجاد می‌کند و روی سلول `(1, 1)` متد [splitByWidth](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByWidth) را فراخوانی می‌کند. نصف عرض ۷۰ پوینت سلول برای ایجاد دو سلول با عرض برابر استفاده می‌شود.

پس از این تقسیم، دو نیمه به صورت `table.get_Item(1, 1)` و `table.get_Item(2, 1)` دسترسی پیدا می‌کنند. شبکه جدول الآن پنج ستون دارد: سلول‌هایی که در ابتدا در ستون‌های ۲ و ۳ بودند به ستون‌های ۳ و ۴ منتقل می‌شوند. شاخص‌های سطر تغییر نمی‌کنند. هنگام دسترسی به سلول‌ها پس از تقسیم، از این شاخص‌های ستون به‌روز شده استفاده کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    table.get_Item(1, 1).splitByWidth(table.get_Item(1, 1).getWidth() / 2)

    presentation.save("split_cells.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **تقسیم سلول‌های ادغام‌شده بر اساس ردیف یا ستون**

برای آماده‌سازی سلول‌های قالب ادغام‌شده برای پر کردن داده‌ها، از [splitByRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByRowSpan) برای تقسیم بر اساس مرز ردیف موجود، یا از [splitByColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByColSpan) برای تقسیم بر اساس مرز ستون استفاده کنید.

آرگومان `index` ردیف‌ها را در بخش بالایی یا ستون‌ها را در بخش چپ تقسیم می‌شمارد؛ این مقدار نسبت به ناحیه ادغام‌شده است:

- تقسیم ردیف: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan).
- تقسیم ستون: `0 < index <` [getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan).

این مثال انتظار دارد که ارائه دارای جدولی به عنوان اولین شکل در اولین اسلاید باشد، به‌طوری‌که سلول‌های `(1, 2)` و `(1, 3)` به صورت عمودی ادغام شده‌اند. با شروع از موقعیت پایین، از [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex) و [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) برای یافتن مبدأ استفاده می‌کند و هر دو بازه را بررسی می‌کند. سپس `splitByRowSpan(1)` ردیف‌های ۲ و ۳ را برای نام محصولات جدا می‌کند. برای ادغام افقی دو ستونی، به‌جای آن از `splitByColSpan(1)` استفاده کنید.

```python
import jpide
import asposeslides

if not jpide.isJVMStarted():
    jpide.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("table_template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    selected_cell = table.get_Item(1, 3)
    first_column_index = selected_cell.getFirstColumnIndex()
    first_row_index = selected_cell.getFirstRowIndex()
    merged_cell = table.get_Item(first_column_index, first_row_index)

    if merged_cell.isMergedCell() and merged_cell.getRowSpan() == 2 and merged_cell.getColSpan() == 1:
        merged_cell.splitByRowSpan(1)

        # دریافت سلول‌های حاصل از جدول پس از تقسیم.
        upper_cell = table.get_Item(first_column_index, first_row_index)
        lower_cell = table.get_Item(first_column_index, first_row_index + 1)
        print(f"Upper cell merged: {upper_cell.isMergedCell()}")
        print(f"Lower cell merged: {lower_cell.isMergedCell()}")

        upper_cell.getTextFrame().setText("Product A")
        lower_cell.getTextFrame().setText("Product B")

        presentation.save("split_template.pptx", SaveFormat.Pptx)
    else:
        print("Select a merged region spanning exactly two rows and one column.")
finally:
    presentation.dispose()
```

شبکه جدول و شاخص‌های سلول‌های اطراف بدون تغییر می‌مانند. سلول‌های حاصل را با استفاده از مختصاتشان بازیابی کنید؛ در اینجا هر دو بازه‌ای برابر ۱ دارند و [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) مقدار `False` را چاپ می‌کند. نواحی بزرگ‌تر می‌توانند پس از یک تقسیم به‌صورت جزئی ادغام‌شده باقی بمانند.

متن اصلی و قالب‌بندی آن در سلول بالایی (یا چپ) باقی می‌ماند؛ سلول جدید خالی است اما قالب‌بندی سلول مانند پر، حاشیه‌ها و حواشی را به ارث می‌برد. پس از تقسیم، سلول‌ها را پر کنید و هر قالب‌بندی متنی مورد نیاز را صراحتاً تنظیم کنید.

ارائه ذخیره‌شده شامل سلول‌های جداگانه «Product A» و «Product B» با حفظ قالب‌بندی سلول‌های قالب است. برای جزئیات به [Cell API Reference](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) مراجعه کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    cell = table.get_Item(2, 3)
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid)
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    presentation.save("cell_background_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تغییر رنگ پس‌زمینه سلول جدول**

این مثال یک جدول با ستون‌های ۱۵۰ پوینت و سطرهای ۵۰ پوینت ایجاد می‌کند. از [setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) برای انتخاب پرشدن یکنواخت استفاده می‌کند و رنگی که توسط [getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor) برگردانده می‌شود را برای سلول `(2, 3)` که در ستون سوم و ردیف چهارم قرار دارد، به قرمز تنظیم می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Images, FillType, PictureFillMode, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100, 90]
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    image = Images.fromFile("aspose_logo.jpg")
    try:
        presentation_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    table.get_Item(0, 0).getCellFormat().getFillFormat().setFillType(FillType.Picture)
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().getPicture().setImage(presentation_image)

    presentation.save("table_cell_with_image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **اضافه کردن تصویر داخل سلول جدول**

قبل از اجرای این مثال، تصویر ورودی را در پوشه کاری قرار دهید. تصویر را با [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile) بارگذاری می‌کند و با [addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage) به مجموعه تصاویر ارائه اضافه می‌کند. سپس تصویر را به پرشدن تصویری سلول `(0, 0)`، اولین سلول جدول، اختصاص می‌دهد.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/) تصویر را به‌گونه‌ای کش می‌دهد که تمام سلول را پر کند، که ممکن است نسبت ابعاد آن را تغییر دهد. عرض ستون‌ها و ارتفاع سطرها بر حسب پوینت است. تصویر بارگذاری‌شده پس از افزودن به ارائه در یک بلوک `finally` از بین می‌رود.

## **پرسش‌های متداول**

**آیا می‌توانم ضخامت و سبک خطوط متفاوتی برای سمت‌های مختلف یک سلول تنظیم کنم؟**

بله. حاشیه‌های [top](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderTop)/[bottom](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderBottom)/[left](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderLeft)/[right](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderRight) دارای ویژگی‌های جداگانه‌ای هستند، بنابراین ضخامت و سبک هر سمت می‌تواند متفاوت باشد.

**اگر پس از تنظیم یک تصویر به عنوان پس‌زمینه سلول، اندازه ستون/سطر را تغییر دهم، چه اتفاقی برای تصویر می‌افتد؟**

رفتار به [fill mode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/) وابسته است (کشیدن/کاشی). با حالت کشیده شدن، تصویر با سلول جدید سازگار می‌شود؛ با حالت کاشی، کاشی‌ها بازمحاسبه می‌شوند.

**آیا می‌توانم یک پیوندهای فراموشی (hyperlink) به تمام محتویات یک سلول اختصاص دهم؟**

[Hyperlinks](/slides/fa/python-java/manage-hyperlinks/) در سطح متن (بخش) داخل فریم متن سلول یا در سطح جدول/شکل کامل تنظیم می‌شوند. در عمل، پیوند را به یک بخش یا به تمام متن داخل سلول اختصاص می‌دهید.

**آیا می‌توانم فونت‌های متفاوتی داخل یک سلول تنظیم کنم؟**

بله. فریم متن یک سلول از [portions](https://reference.aspose.com/slides/python-java/aspose.slides/portion/) (بخش‌ها) با قالب‌بندی مستقل — خانواده‌ی فونت، سبک، اندازه و رنگ — پشتیبانی می‌کند.