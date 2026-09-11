---
title: مدیریت سلول‌های جدول در ارائه‌ها با استفاده از Python
linktitle: مدیریت سلول‌ها
type: docs
weight: 30
url: /fa/python-java/manage-cells/
keywords:
- سلول جدول
- ترکیب سلول‌ها
- حذف حاشیه
- تقسیم سلول
- تصویر در سلول
- رنگ پس‌زمینه
- PowerPoint
- ارائه
- Python
- Aspose.Slides
description: "به راحتی سلول‌های جدول را در PowerPoint با Aspose.Slides برای Python via Java مدیریت کنید. دسترسی، اصلاح و سبک‌دهی به سلول‌ها را سریعاً برای خودکارسازی اسلایدها به‌دست آورید."
---
## **مروری**

Aspose.Slides به شما امکان دسترسی و اصلاح سلول‌های جدول در ارائه‌های PowerPoint را می‌دهد. این مقاله توضیح می‌دهد که چگونه سلول‌های جدول ترکیبی را شناسایی کنید، حاشیه‌های سلول‌ها را حذف کنید، با شماره‌گذاری سلول‌ها پس از ترکیب یا تقسیم سلول‌ها کار کنید، رنگ پس‌زمینه یک سلول را تغییر دهید و یک تصویر را داخل یک سلول جدول اضافه کنید. مثال‌ها نشان می‌دهند چگونه یک ارائه را ایجاد یا باز کنید، یک جدول را از یک اسلاید دریافت کنید، قالب‌بندی سلول را از طریق ویژگی‌های سلول به‌روز کنید و ارائه اصلاح‌شده را به عنوان فایل PPTX ذخیره کنید.

## **شناسایی یک سلول جدول ترکیبی**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.  
2. جدول را از اولین اسلاید دریافت کنید.  
3. در سطرها و ستون‌های جدول پیمایش کنید تا سلول‌های ترکیبی را پیدا کنید.  
4. زمانی که سلول‌های ترکیبی پیدا شدند، یک پیام چاپ کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Table

presentation = Presentation("SomePresentationWithTable.pptx")
try:
    # فرض کنید که اولین شکل در اولین اسلاید یک جدول است.
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
        for i in range(table.getRows().size()):
            for j in range(table.getColumns().size()):
                current_cell = table.getRows().get_Item(i).get_Item(j)
                if current_cell.isMergedCell():
                    print(f"Cell {i};{j} is part of a merged cell with RowSpan={current_cell.getRowSpan()} and ColSpan={current_cell.getColSpan()} starting from Cell {current_cell.getFirstRowIndex()};{current_cell.getFirstColumnIndex()}.")
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **حذف حاشیه‌های سلول جدول**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.  
2. یک مرجع به اسلاید را بر اساس ایندکس آن دریافت کنید.  
3. یک لیست از عرض ستون‌ها را تعریف کنید.  
4. یک لیست از ارتفاع ردیف‌ها را تعریف کنید.  
5. یک جدول را به اسلاید از طریق متد [addTable](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shapecollection/#addTable) اضافه کنید.  
6. در هر سلول پیمایش کنید تا حاشیه‌های بالا، پایین، راست و چپ را پاک کنید.  
7. ارائه اصلاح‌شده را به عنوان فایل PPTX ذخیره کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat

presentation = Presentation()
try:
    # دسترسی به اولین اسلاید.
    slide = presentation.getSlides().get_Item(0)

    # تعریف عرض ستون‌ها و ارتفاع ردیف‌ها.
    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # افزودن جدول به اسلاید.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # تنظیم قالب حاشیه برای هر سلول.
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill)

    # ذخیره ارائه به صورت فایل PPTX.
    presentation.save("table_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **شماره‌گذاری در سلول‌های ترکیبی**

اگر دو جفت سلول، (1, 1) و (2, 1) و (1, 2) و (2, 2) را ترکیب کنیم، جدول حاصل شماره‌گذاری سلول‌های خود را حفظ می‌کند. این کد پایتون فرآیند را نشان می‌دهد:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # دسترسی به اولین اسلاید.
    slide = presentation.getSlides().get_Item(0)

    # تعریف عرض ستون‌ها و ارتفاع ردیف‌ها.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # افزودن جدول به اسلاید.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # تنظیم قالب حاشیه برای هر سلول.
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderTop().setWidth(5)

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderBottom().setWidth(5)

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderLeft().setWidth(5)

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderRight().setWidth(5)


    # ترکیب سلول‌های (1, 1) و (2, 1).
    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 1), False)

    # ترکیب سلول‌های (1, 2) و (2, 2).
    table.mergeCells(table.get_Item(1, 2), table.get_Item(2, 2), False)

    # ذخیره ارائه به صورت فایل PPTX.
    presentation.save("MergeCells_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

سپس سلول‌ها را بیشتر ترکیب می‌کنیم با ترکیب (1, 1) و (1, 2). نتیجه جدولی است که یک سلول بزرگ ترکیبی در مرکز خود دارد:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # دسترسی به اولین اسلاید.
    slide = presentation.getSlides().get_Item(0)

    # تعریف عرض ستون‌ها و ارتفاع ردیف‌ها.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # افزودن جدول به اسلاید.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # تنظیم قالب حاشیه برای هر سلول.
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderTop().setWidth(5)

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderBottom().setWidth(5)

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderLeft().setWidth(5)

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderRight().setWidth(5)


    # ترکیب سلول‌های (1, 1) و (2, 1).
    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 1), False)

    # ترکیب سلول‌های (1, 2) و (2, 2).
    table.mergeCells(table.get_Item(1, 2), table.get_Item(2, 2), False)

    # ترکیب سلول‌های (1, 1) و (1, 2).
    table.mergeCells(table.get_Item(1, 1), table.get_Item(1, 2), True)

    # ذخیره ارائه به صورت فایل PPTX.
    presentation.save("MergeCells_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **شماره‌گذاری در یک سلول تقسیم شده**

در مثال‌های قبلی، ترکیب سلول‌های جدول شماره‌گذاری سایر سلول‌ها را تغییر نمی‌داد.

این بار، یک جدول عادی (جدولی بدون سلول‌های ترکیبی) را می‌گیریم و سپس سعی می‌کنیم سلول (1, 1) را تقسیم کنیم تا جدولی خاص به دست آوریم. ممکن است بخواهید به شماره‌گذاری این جدول توجه کنید که ممکن است عجیب به نظر برسد. اما این همان روشی است که Microsoft PowerPoint سلول‌های جدول را شماره‌گذاری می‌کند و Aspose.Slides نیز همین کار را انجام می‌دهد.

این کد پایتون فرآیندی که توصیف کردیم را نشان می‌دهد:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # دسترسی به اولین اسلاید.
    slide = presentation.getSlides().get_Item(0)

    # تعریف عرض ستون‌ها و ارتفاع ردیف‌ها.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # افزودن جدول به اسلاید.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # تنظیم قالب حاشیه برای هر سلول.
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderTop().setWidth(5)

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderBottom().setWidth(5)

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderLeft().setWidth(5)

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderRight().setWidth(5)


    # تقسیم سلول (1, 1).
    table.get_Item(1, 1).splitByWidth(table.get_Item(2, 1).getWidth() / 2)

    # ذخیره ارائه به صورت فایل PPTX.
    presentation.save("SplitCells_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تغییر رنگ پس‌زمینه سلول جدول**

این کد پایتون نشان می‌دهد چگونه رنگ پس‌زمینه یک سلول جدول را تغییر دهید:

```python
import jpype
import asposeslides

if not jpame.isJVMStarted():
    jpame.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # دسترسی به اولین اسلاید.
    slide = presentation.getSlides().get_Item(0)

    # تعریف عرض ستون‌ها و ارتفاع ردیف‌ها.
    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]

    # افزودن جدول به اسلاید.
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    # تنظیم رنگ پس‌زمینه برای یک سلول.
    cell = table.get_Item(2, 3)
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid)
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    # ذخیره ارائه به صورت فایل PPTX.
    presentation.save("cell_background_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **افزودن تصویر داخل یک سلول جدول**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.  
2. یک مرجع به اسلاید را بر اساس ایندکس آن دریافت کنید.  
3. یک لیست از عرض ستون‌ها را تعریف کنید.  
4. یک لیست از ارتفاع ردیف‌ها را تعریف کنید.  
5. یک جدول را به اسلاید از طریق متد [addTable](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shapecollection/#addTable) اضافه کنید.  
6. فایل تصویر را با استفاده از [Images.fromFile](https://reference.aspose.com/slides/fa/python-java/aspose.slides/images/#fromFile) بارگذاری کنید.  
7. تصویر را به ارائه اضافه کنید تا یک شیء [PPImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/ppimage/) ایجاد شود.  
8. نوع پر کردن سلول جدول را با استفاده از [FillFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fillformat/) به [FillType.Picture](https://reference.aspose.com/slides/fa/python-java/aspose.slides/filltype/#Picture) تنظیم کنید.  
9. تصویر را به اولین سلول جدول اضافه کنید.  
10. ارائه اصلاح‌شده را به عنوان فایل PPTX ذخیره کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Images, FillType, PictureFillMode, SaveFormat

presentation = Presentation()
try:
    # دسترسی به اولین اسلاید.
    slide = presentation.getSlides().get_Item(0)

    # تعریف عرض ستون‌ها و ارتفاع ردیف‌ها.
    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100, 90]

    # افزودن جدول به اسلاید.
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    # ایجاد تصویر ارائه از فایل تصویر.
    image = Images.fromFile("image.jpg")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    # افزودن تصویر به اولین سلول جدول.
    cell_format = table.get_Item(0, 0).getCellFormat()
    cell_format.getFillFormat().setFillType(FillType.Picture)
    cell_format.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
    cell_format.getFillFormat().getPictureFillFormat().getPicture().setImage(picture)

    # ذخیره ارائه به صورت فایل PPTX.
    presentation.save("Image_In_TableCell_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **سوالات متداول**

**آیا می‌توانم ضخامت‌ها و سبک‌های خطوط متفاوتی برای سمت‌های مختلف یک سلول تنظیم کنم؟**

بله. حاشیه‌های [top](https://reference.aspose.com/slides/fa/python-java/aspose.slides/cellformat/#getBorderTop)/[bottom](https://reference.aspose.com/slides/fa/python-java/aspose.slides/cellformat/#getBorderBottom)/[left](https://reference.aspose.com/slides/fa/python-java/aspose.slides/cellformat/#getBorderLeft)/[right](https://reference.aspose.com/slides/fa/python-java/aspose.slides/cellformat/#getBorderRight) دارای ویژگی‌های جداگانه‌ای هستند، بنابراین ضخامت و سبک هر سمت می‌تواند متفاوت باشد. این به‌طور منطقی از کنترل حاشیه بر پایه هر سمت برای یک سلول که در مقاله نشان داده شده است، پیروی می‌کند.

**چه اتفاقی برای تصویر می‌افتد اگر پس از تنظیم یک تصویر به‌عنوان پس‌زمینه سلول، اندازه ستون/ردیف را تغییر دهم؟**

رفتار بستگی به [fill mode](https://reference.aspose.com/slides/fa/python-java/aspose.slides/picturefillmode/) (کشیده شدن/کاشی) دارد. با کشیدن، تصویر با سلول جدید منطبق می‌شود؛ با کاشی، کاشی‌ها مجدداً محاسبه می‌شوند. مقاله به حالت‌های نمایش تصویر در یک سلول اشاره می‌کند.

**آیا می‌توانم یک پیوند (hyperlink) را به تمام محتوای یک سلول اختصاص دهم؟**

[Hyperlinks](/slides/fa/python-java/manage-hyperlinks/) در سطح متن (بخش) داخل قاب متن سلول یا در سطح کل جدول/شکل تنظیم می‌شوند. در عمل، پیوند را به یک بخش یا به تمام متن داخل سلول اختصاص می‌دهید.

**آیا می‌توانم فونت‌های مختلفی را داخل یک سلول تنظیم کنم؟**

بله. قاب متن یک سلول از [portions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/portion/) (بخش‌ها) با قالب‌بندی مستقل—خانواده فونت، سبک، اندازه و رنگ—پشتیبانی می‌کند.