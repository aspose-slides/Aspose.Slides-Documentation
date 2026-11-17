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
- پاورپوینت
- ارائه
- پایتون
- Aspose.Slides
description: "مدیریت سلول‌های جدول پاورپوینت در پایتون: شناسایی سلول‌های ادغام‌شده، حذف حاشیه‌ها، تقسیم سلول‌ها و تنظیم رنگ‌های پس‌زمینه و تصاویر با Aspose.Slides برای پایتون از طریق جاوا."
---
## **نمای کلی**

Aspose.Slides به شما امکان می‌دهد سلول‌های جدول در ارائه‌های PowerPoint را دسترسی و اصلاح کنید. این مقاله نحوه شناسایی سلول‌های ادغام‌شده جدول، حذف حاشیه‌های سلول، کار با شماره‌گذاری سلول پس از ادغام یا تقسیم سلول‌ها، تغییر رنگ پس‌زمینه سلول و افزودن تصویر داخل یک سلول جدول را توضیح می‌دهد. مثال‌ها نشان می‌دهند چگونه یک ارائه را ایجاد یا باز کنید، جدول را از یک اسلاید دریافت کنید، قالب‌بندی سلول را از طریق ویژگی‌های سلول به‌روزرسانی کنید و ارائه اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

Aspose.Slides از ایندکس‌های صفر‑پایه برای دسترسی به سلول‌های جدول به ترتیب `(column, row)` استفاده می‌کند.

## **شناسایی یک سلول جدول ادغام‌شده**

مثال یک ارائه موجود را باز می‌کند و اولین شکل در اولین اسلاید را به‌عنوان جدول دسترسی می‌یابد. فرض می‌شود اسلاید و شکل وجود دارند و شکل یک جدول است. سپس تمام ردیف‌ها و ستون‌ها را پیمایش می‌کند و از [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) برای شناسایی سلول‌ها در مناطق ادغام‌شده استفاده می‌کند. برای هر مطابقت، مختصات سلول را به ترتیب `row;column`، [getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan)، [getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan) و مختصات شروع منطقه را با استفاده از [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) و [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex) چاپ می‌کند.

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

یک [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) ایجاد کنید و با [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable) یک جدول به اسلاید اول آن اضافه کنید. عرض ستون‌ها، ارتفاع ردیف‌ها و موقعیت جدول بر حسب نقطه (point) مشخص می‌شود. مثال تمام چهار حاشیه سلول را به [FillType.NoFill](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) تنظیم می‌کند تا نامرئی شوند.

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

## **افزودن حاشیه‌های مورب سلول**

از [getBorderDiagonalDown](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderDiagonalDown) برای رسم خطی از گوشه بالا‑چپ به پایین‑راست و از [getBorderDiagonalUp](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderDiagonalUp) برای رسم خطی از گوشه پایین‑چپ به بالا‑راست استفاده کنید. یک مورب می‌تواند سرصفحه گوشه‌ای باشد. هر دو مورب می‌توانند یک X را تشکیل دهند تا نشان دهند سلول قابل اعمال نیست.

هر مورب یک [LineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/) است. در [getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getFillFormat) آن، با استفاده از [setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) مقدار [FillType.Solid](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) را انتخاب کنید و رنگ را با [getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor) تعیین کنید. عرض خط را با [setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setWidth) بر حسب نقطه تنظیم کنید.

مثال سه سلول در یک ردیف ایجاد می‌کند: یک مورب نزولی قرمز، یک مورب صعودی آبی و هر دو مورب. حاشیه‌های بالایی، پایینی، چپ و راست سلول‌ها تغییری نکرده‌اند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color


def format_border(border, color, width):
    fill = border.getFillFormat()
    fill.setFillType(FillType.Solid)
    fill.getSolidFillColor().setColor(color)
    border.setWidth(width)


presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().addTable(45, 130, [210, 210, 210], [160])

    left_cell = table.get_Item(0, 0).getCellFormat()
    middle_cell = table.get_Item(1, 0).getCellFormat()
    right_cell = table.get_Item(2, 0).getCellFormat()
    format_border(left_cell.getBorderDiagonalDown(), Color.RED, 3)
    format_border(middle_cell.getBorderDiagonalUp(), Color.BLUE, 5)
    format_border(right_cell.getBorderDiagonalDown(), Color.RED, 3)
    format_border(right_cell.getBorderDiagonalUp(), Color.BLUE, 5)

    presentation.save("diagonal_cell_borders.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

یک مورب یک ویژگی قالب‌بندی است، نه تقسیم سلول. هر سلول یک چارچوب متن (text frame) تک دارد که از طریق [getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getTextFrame) دسترسی پیدا می‌شود. مناطق در هر دو طرف یک مورب نمی‌توانند به‌صورت مستقل ویرایش شوند.

جدول ذخیره‌شده، در Microsoft PowerPoint رندر می‌شود:

![سه سلول جدول که یک مورب قرمز از بالا‑چپ به پایین‑راست، یک مورب آبی از پایین‑چپ به بالا‑راست و هر دو مورب forming an X را نشان می‌دهند.](diagonal-cell-borders.png)

*از چپ به راست: مورب نزولی (قرمز، 3 pt)، مورب صعودی (آبی، 5 pt) و هر دو مورب که یک X تشکیل می‌دهند.*

## **ادغام سلول‌های جدول**

از [mergeCells](https://reference.aspose.com/slides/python-java/aspose.slides/table/#mergeCells) برای ترکیب یک بازه مستطیلی از سلول‌های جدول به یک سلول استفاده کنید. سلول‌های گوشهٔ بالا‑چپ و پایین‑راست بازه را مشخص کنید. آرگومان نهایی تعیین می‌کند آیا ادغام می‌تواند شامل سلول‌های خارج از بازه تعیین‌شده باشد؛ `False` ادغام را درون همان بازه نگه می‌دارد.

مثال یک جدول 4×4 با ستون‌ها و ردیف‌های 70 نقطه‌ای ایجاد می‌کند و سپس چهار سلول مرکزی را از `(1, 1)` تا `(2, 2)` ادغام می‌کند. سلول حاصل دو ستون و دو ردیف را پوشش می‌دهد، در حالی که شبکه زیرین جدول همچنان چهار ستون و چهار ردیف را نگه می‌دارد. برای دسترسی به محتوای یا قالب‌بندی سلول ادغام‌شده، از موقعیت بالا‑چپ آن استفاده کنید: `table.get_Item(1, 1)` در این مثال. موقعیت‌های دیگر در بازه ادغام‌شده همچنان بخشی از شبکه جدول می‌مانند، بنابراین اندیس‌های سلول‌های خارج از بازه تغییر نمی‌کند.

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

در مثال قبلی ادغام سلول‌ها ساختار شبکه جدول را حفظ می‌کند. تقسیم یک سلول می‌تواند یک ستون جدید به شبکه اضافه کرده و اندیس‌های ستون‌های سمت راست را تغییر دهد. Aspose.Slides مدل شبکه جدول PowerPoint را پیروی می‌کند.

این مثال یک جدول 4×4 با ستون‌ها و ردیف‌های 70 نقطه‌ای می‌سازد و بر روی سلول `(1, 1)` متد [splitByWidth](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByWidth) را فراخوانی می‌کند. نصف عرض 70‑نقطه‌ای سلول به عنوان پارامتر پاس داده می‌شود تا دو سلول با عرض مساوی ایجاد شود.

پس از این تقسیم، دو نیمه به صورت `table.get_Item(1, 1)` و `table.get_Item(2, 1)` قابل دسترسی هستند. شبکه جدول اکنون پنج ستون دارد: سلول‌های اولیه در ستون‌های 2 و 3 به ستون‌های 3 و 4 منتقل می‌شوند. اندیس‌های ردیف ثابت می‌مانند. هنگام دسترسی به سلول‌ها پس از تقسیم، از این اندیس‌های به‌روز شدهٔ ستون استفاده کنید.

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

<!-- visual-explanation:manage-cells:start -->
[![یک سلول 70‑نقطه‌ای بدون ادغام به دو سلول 35‑نقطه‌ای تقسیم می‌شود، که ستون پنجم شبکه را اضافه کرده و اندیس‌های راست آن را جابجا می‌کند.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*تقسیم عرض بر سلول (1, 1) تأثیر می‌گذارد؛ سایر ردیف‌ها سلولی دارند که هر دو موقعیت ستون جدید را اشغال می‌کند.* 
<!-- visual-explanation:manage-cells:end -->

### **تقسیم سلول‌های ادغام‌شده بر پایهٔ ردیف یا ستون**

برای آماده‌سازی سلول‌های قالب ادغام‌شده جهت پر کردن داده، از [splitByRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByRowSpan) برای تقسیم بر پایهٔ مرز ردیف موجود یا از [splitByColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByColSpan) برای تقسیم بر پایهٔ مرز ستون استفاده کنید.

آرگومان `index` تعداد ردیف‌های بخش بالایی یا تعداد ستون‌های بخش چپ تقسیم را می‌شمارد؛ این مقدار نسبت به منطقهٔ ادغام‌شده است:

- تقسیم ردیف: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan).
- تقسیم ستون: `0 < index <` [getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan).

مثال انتظار دارد ارائه حاوی جدولی به عنوان اولین شکل در اولین اسلاید باشد، به‌طوری که سلول‌های `(1, 2)` و `(1, 3)` به صورت عمودی ادغام شده باشند. از [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex) و [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) برای یافتن مبدأ استفاده می‌کند و هر دو بازه را بررسی می‌کند. `splitByRowSpan(1)` سپس ردیف‌های 2 و 3 را برای نام‌های محصول جدا می‌کند. برای ادغام افقی دو ستونی، به‌جای آن از `splitByColSpan(1)` استفاده کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

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

        # سلول‌های حاصل از جدول پس از تقسیم را بازیابی کنید.
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

شبکه جدول و اندیس‌های سلول‌های اطراف بدون تغییر می‌مانند. سلول‌های حاصل را با مختصاتشان بازیابی کنید؛ در اینجا هر دو دارای بازهٔ 1 هستند و [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) مقدار `False` چاپ می‌کند. مناطق بزرگتر می‌توانند پس از یک تقسیم جزئی ادغام باقی بمانند.

متن اصلی و قالب‌بندی آن در سلول بالا (یا چپ) باقی می‌ماند؛ سلول جدید خالی است اما قالب‌بندی سلول مانند پرکردن، حاشیه‌ها و حاشیه‌های داخلی را به ارث می‌برد. پس از تقسیم، سلول‌ها را پر کنید و هر قالب‌بندی متنی لازم را به‌صورت صریح تنظیم کنید.

ارائهٔ ذخیره‌شده شامل سلول‌های جداگانهٔ «محصول A» و «محصول B» است که قالب‌بندی سلول قالب اصلی را حفظ کرده‌اند. برای جزئیات بیشتر به [Cell API Reference](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) مراجعه کنید.

### **تقسیم یک سلول بر پایهٔ ارتفاع مشخص**

[splitByHeight](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByHeight) ارتفاع بخش بالا را به‌صورت نقطه می‌گیرد. [splitByRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByRowSpan) تعداد ردیف‌های موجود در بخش بالا را می‌گیرد. برای مرکز‌گذاری یک سلول 40‑نقطه‌ای در ستون راست، 40 را از ارتفاع واقعی سلول کم کنید و فضای باقی‌مانده را به‌صورت مساوی بالای و پایین آن تقسیم کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().addTable(50, 50, [160, 160], [140])
    table.get_Item(0, 0).getTextFrame().setText("Left")

    height = table.get_Item(1, 0).getHeight()
    margin = (height - 40) / 2
    
    table.get_Item(1, 0).splitByHeight(margin)
    table.get_Item(1, 1).splitByHeight(40)
    table.get_Item(1, 1).getTextFrame().setText("Middle")

    presentation.save("split_by_height.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

تقسیم اول یک ردیف شبکه اضافه می‌کند و 90 نقطهٔ پایین را در سلول `(1, 1)` می‌گذارد. تقسیم دوم آن سلول را به یک سلول میانی 40‑نقطه‌ای و یک سلول پایینی 50‑نقطه‌ای تقسیم می‌کند. ستون راست اکنون سه سلول با ارتفاع‌های 50، 40 و 50 نقطه از بالا به پایین دارد. سلول چپ تمام سه ردیف را پوشش می‌دهد و ارتفاع اصلی 140 نقطه‌ای خود را حفظ می‌کند.

![سلول چپ تمام ارتفاع جدول را در کنار سه سلول با متن Middle در وسط پوشش می‌دهد.](split-by-height.png)

## **تغییر رنگ پس‌زمینهٔ سلول جدول**

این مثال جدولی با ستون‌های 150‑نقطه‌ای و ردیف‌های 50‑نقطه‌ای ایجاد می‌کند. از [setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) برای انتخاب پرکردن ثابت استفاده می‌کند و رنگی که توسط [getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor) بر می‌گردد را برای سلول `(2, 3)`، در ستون سوم و ردیف چهارم، به قرمز تنظیم می‌کند.

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

## **افزودن تصویر داخل یک سلول جدول**

قبل از اجرای این مثال، تصویر ورودی را در پوشهٔ کاری قرار دهید. تصویر را با [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile) بارگذاری می‌کند و با [addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage) به مجموعهٔ تصاویر ارائه اضافه می‌کند. سپس تصویر را به پرکردن تصویری (picture fill) سلول `(0, 0)`، اولین سلول جدول، اختصاص می‌دهد.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/) تصویر را برای پر کردن سلول کشیده (stretch) می‌کند، که ممکن است نسبت عرض به ارتفاع آن را تغییر دهد. عرض ستون‌ها و ارتفاع ردیف‌ها بر حسب نقطه است. تصویر بارگذاری‌شده پس از افزودن به ارائه در یک بلوک `finally` از بین می‌رود.

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

## **سؤالات متداول**

**آیا می‌توانم ضخامت و سبک خطوط متفاوتی برای هر طرف یک سلول تعیین کنم؟**

بله. حاشیه‌های [top](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderTop)/[bottom](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderBottom)/[left](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderLeft)/[right](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderRight) دارای ویژگی‌های جداگانه‌ای هستند، بنابراین ضخامت و سبک هر طرف می‌تواند متفاوت باشد.

**اگر پس از تنظیم تصویر به عنوان پس‌زمینهٔ سلول، اندازهٔ ستون/ردیف را تغییر دهم، چه اتفاقی می‌افتد؟**

رفتار بستگی به [fill mode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/) (stretch/tile) دارد. در حالت کشیدگی (stretch) تصویر با سلول جدید تنظیم می‌شود؛ در حالت کاشی (tile) کاشی‌ها مجدداً محاسبه می‌شوند.

**آیا می‌توانم یک پیوند (hyperlink) را به تمام محتوای یک سلول اختصاص دهم؟**

[Hyperlinks](/slides/fa/python-java/manage-hyperlinks/) در سطح متن (portion) داخل چارچوب متن سلول یا در سطح کل جدول/شکل تنظیم می‌شوند. در عمل، پیوند را به یک بخش یا به تمام متن سلول اختصاص می‌دهید.

**آیا می‌توانم فونت‌های متفاوتی داخل یک سلول داشته باشم؟**

بله. چارچوب متن سلول از [portions](https://reference.aspose.com/slides/python-java/aspose.slides/portion/) (بخش‌های متنی) با قالب‌بندی مستقل—خانوادهٔ قلم، سبک، اندازه و رنگ—پشتیبانی می‌کند.