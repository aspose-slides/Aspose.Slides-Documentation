---
title: مدیریت جداول ارائه در پایتون
linktitle: مدیریت جدول
type: docs
weight: 10
url: /fa/python-java/manage-table/
keywords:
- افزودن جدول
- ایجاد جدول
- دسترسی به جدول
- نسبت ابعاد
- تراز متن
- قالب‌بندی متن
- سبک جدول
- PowerPoint
- ارائه
- Python
- Aspose.Slides
description: "ایجاد و ویرایش جداول در اسلایدهای PowerPoint با Aspose.Slides برای پایتون از طریق Java. مثال‌های کد ساده‌ای را کشف کنید تا جریان کاری جداول خود را بهینه کنید."
---
## **معرفی**

جدول‌ها در پاورپوینت اطلاعات را به ردیف‌ها و ستون‌ها سازماندهی می‌کنند و خواندن و مقایسه مقادیر را آسان‌تر می‌سازند.

Aspose.Slides کلاس‌های [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) و [Cell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) و انواع دیگر را ارائه می‌دهد تا بتوانید جدول‌ها را در ارائه‌ها ایجاد، به‌روزرسانی و مدیریت کنید.

## **ایجاد جدول از ابتدا**

با تعیین موقعیت، عرض ستون‌ها و ارتفاع ردیف‌ها یک جدول ایجاد کنید. پس از افزودن آن به اسلاید، می‌توانید حاشیه‌های سلول را قالب‌بندی کنید، سلول‌ها را ادغام کنید و متن وارد کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) بسازید.
2. مرجع اسلاید را بر اساس اندیس آن به‌دست آورید.
3. فهرستی از عرض ستون‌ها بر حسب نقطه تعریف کنید.
4. فهرستی از ارتفاع ردیف‌ها بر حسب نقطه تعریف کنید.
5. از طریق متد [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable) یک شیء [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) به اسلاید اضافه کنید.
6. برای هر [Cell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) مرزبندی‌های بالا، پایین، راست و چپ را اعمال کنید.
7. دو سلول اول ردیف اول جدول را ادغام کنید.
8. از طریق متد [getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getTextFrame) به سلول ادغام‌شده دسترسی پیدا کنید.
9. متن را در سلول ادغام‌شده تنظیم کنید.
10. ارائه اصلاح‌شده را ذخیره کنید.

مثال زیر یک جدول با سه ستون و پنج ردیف در موقعیت (100, 50) نقطه ایجاد می‌کند. حاشیه‌های قرمز با عرض 5 نقطه اعمال می‌شوند، دو سلول اول ردیف اول ادغام می‌شوند و نتیجه به صورت `table.pptx` ذخیره می‌شود.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    for row in table.getRows():
        for cell in row:
            cell_format = cell.getCellFormat()
            cell_format.getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderTop().setWidth(5)
            cell_format.getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderBottom().setWidth(5)
            cell_format.getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderLeft().setWidth(5)
            cell_format.getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderRight().setWidth(5)

    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 0), False)
    table.get_Item(0, 0).getTextFrame().setText("Merged Cells")

    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **شماره‌گذاری در جدول استاندارد**

در یک جدول استاندارد، اندیس‌های سلول صفر‑پایه هستند و به ترتیب (ستون، ردیف) استفاده می‌شوند. اولین سلول به صورت (0, 0) شماره‌گذاری می‌شود.

به عنوان مثال، سلول‌های جدول ۴×۴ به این شکل شماره‌گذاری می‌شوند:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

این مثال جدول ۴×۴ نشان‌داده‌شده را با عرض ستون‌ها و ارتفاع ردیف‌ها برابر با ۷۰ نقطه و حاشیه‌های سلول قرمز با عرض ۵ نقطه ایجاد می‌کند. مختصات اندیس‌های سلول را نشان می‌دهند؛ مثال سلول‌ها را خالی می‌گذارد و جدول را به صورت `StandardTables_out.pptx` ذخیره می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    for row in table.getRows():
        for cell in row:
            cell_format = cell.getCellFormat()
            cell_format.getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderTop().setWidth(5)
            cell_format.getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderBottom().setWidth(5)
            cell_format.getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderLeft().setWidth(5)
            cell_format.getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderRight().setWidth(5)

    presentation.save("StandardTables_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **دسترسی به جدول موجود**

جداول در مجموعه شکل‌های یک اسلاید ذخیره می‌شوند. با مرور اشکال، جدول موردنظر را پیدا کنید و سپس از کلاس [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) برای خواندن یا به‌روزرسانی سلول‌ها استفاده کنید.

1. ارائه را با استفاده از کلاس [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) بارگذاری کنید.
2. مرجع اسلاید حاوی جدول را بر حسب اندیس آن به‌دست آورید.
3. از میان اشیاء [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) مرور کنید و زمانی که جدول یافت شد متوقف شوید. اگر اسلاید چند جدول داشته باشد، از [getAlternativeText](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getAlternativeText) برای شناسایی جدول موردنیاز استفاده کنید.
4. متن سلول هدف را به‌روزرسانی کنید.
5. ارائه اصلاح‌شده را ذخیره کنید.

مثال زیر فایل `UpdateExistingTable.pptx` را باز می‌کند و اولین جدول در اولین اسلاید را پیدا می‌نماید. سلول در ستون 0، ردیف 1 به مقدار `New` تنظیم می‌شود و نتیجه به صورت `table1_out.pptx` ذخیره می‌شود. ورودی باید حداقل یک اسلاید داشته باشد و اولین جدول آن اسلاید باید حداقل یک ستون و دو ردیف داشته باشد.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("UpdateExistingTable.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = None

    for shape in slide.getShapes():
        if isinstance(shape, Table):
            table = shape
            break

    if table is not None:
        table.get_Item(0, 1).getTextFrame().setText("New")
        presentation.save("table1_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

برای تغییر اندازهٔ ردیف در جدول موجود و درک اینکه چرا ارتفاع واقعی آن می‌تواند از حداقل درخواست‌شده بیشتر باشد، به بخش [Control Row Height](/slides/fa/python-java/manage-rows-and-columns/#control-row-height) مراجعه کنید.

## **یافتن سلولی که صاحب یک TextFrame است**

هنگامی که کد عمومی پردازش متن یک [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) را از جدولی دریافت می‌کند، از متد [TextFrame.getParentCell](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentCell) برای دریافت [Cell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) مالک استفاده کنید. برای یک TextFrame سلول‑جدول، [TextFrame.getParentCell](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentCell) مالک را برمی‌گرداند و [TextFrame.getParentShape](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentShape) مقدار `None` می‌دهد، حتی اگر جدول به‌عنوان یک شکل باشد.

مختصات سلول از طریق متدهای فقط‑خواندنی [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex) و [Cell.getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) در دسترس هستند. [TextFrame.getParentCell](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentCell) همچنین ناوبری فقط‑خواندنی فراهم می‌کند: مالک را برمی‌گرداند اما مالکیت را تغییر نمی‌دهد. همیشه قبل از استفاده مقدار برگشتی را برای `None` بررسی کنید.

برای مثال کامل که مالکین سلول‑جدول و شکل را شناسایی می‌کند، از جمله اشکال مرتبط با گره‌های SmartArt، به بخش [Search and Replace Text](/slides/fa/python-java/search-and-replace-text/) مراجعه کنید.

## **تراز کردن متن در جدول**

می‌توانید تکیه‌گیری عمودی و جهت متن سلول‌های جداگانه جدول را کنترل کنید. مثال این بخش متن را در اولین سلول مرکز می‌کند و آن را به‌صورت ۲۷۰ درجه می‌چرخاند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) بسازید.
2. مرجع اسلاید را بر حسب اندیس آن به‌دست آورید.
3. یک شیء [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) به اسلاید اضافه کنید.
4. از جدول، یک شیء [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) دریافت کنید.
5. اولین [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) را دریافت کرده و متن و رنگ آن را تنظیم کنید.
6. تکیه‌گیری عمودی سلول و جهت متن را با استفاده از [setTextAnchorType](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setTextAnchorType) و [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setTextVerticalType) تنظیم کنید.
7. ارائه اصلاح‌شده را ذخیره کنید.

این مثال جدول ۴×۴ با عرض ستون ۱۲۰ نقطه و ارتفاع ردیف ۱۰۰ نقطه ایجاد می‌کند. متن سلول (0, 0) قالب‌بندی می‌شود، مقادیر به سلول‌های باقی‌مانده در ردیف اول اضافه می‌شوند و نتیجه به صورت `Vertical_Align_Text_out.pptx` ذخیره می‌شود.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, TextAnchorType, TextVerticalType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [120, 120, 120, 120]
    row_heights = [100, 100, 100, 100]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)
    
    table.get_Item(1, 0).getTextFrame().setText("10")
    table.get_Item(2, 0).getTextFrame().setText("20")
    table.get_Item(3, 0).getTextFrame().setText("30")

    text_frame = table.get_Item(0, 0).getTextFrame()
    paragraph = text_frame.getParagraphs().get_Item(0)

    portion = paragraph.getPortions().get_Item(0)
    portion.setText("Text here")
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    cell = table.get_Item(0, 0)
    cell.setTextAnchorType(TextAnchorType.Center)
    cell.setTextVerticalType(TextVerticalType.Vertical270)

    presentation.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تنظیم قالب‌بندی متن در سطح جدول**

از [setTextFormat](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setTextFormat) برای اعمال قالب‌بندی متن به تمام سلول‌های یک جدول استفاده کنید. بارگذاری‌های آن می‌توانند بخشی، پاراگراف و قالب‌ بندی فریم متن را بپذیرند، بنابراین می‌توانید این ویژگی‌ها را بدون مرور سلول‌های جداگانه تنظیم کنید.

1. ارائه را با استفاده از کلاس [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) بارگذاری کنید.
2. مرجع اسلاید را بر حسب اندیس آن به‌دست آورید.
3. از اسلاید، یک شیء [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) دریافت کنید.
4. اندازهٔ قلم را با استفاده از [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) برای متن تنظیم کنید.
5. تراز پاراگراف و حاشیهٔ راست را با استفاده از [setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) و [setMarginRight](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginRight) تنظیم کنید.
6. جهت متن را با استفاده از [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType) تنظیم کنید.
7. ارائه اصلاح‌شده را ذخیره کنید.

مثال زیر فایل `table.pptx` را باز می‌کند که باید حداقل یک اسلاید با یک جدول به‌عنوان اولین شکل داشته باشد. اندازهٔ قلم به ۲۵ نقطه تنظیم می‌شود، پاراگراف‌ها راست‌تراز می‌شوند با حاشیهٔ راست ۲۰ نقطه و متن به صورت عمودی تنظیم می‌شود. ارائه قالب‌بندی‌شده به صورت `result.pptx` ذخیره می‌شود.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ParagraphFormat, PortionFormat, Presentation, SaveFormat, TextAlignment, TextFrameFormat, TextVerticalType, Table

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    portion_format = PortionFormat()
    portion_format.setFontHeight(25)
    table.setTextFormat(portion_format)

    paragraph_format = ParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Right)
    paragraph_format.setMarginRight(20)
    table.setTextFormat(paragraph_format)

    text_frame_format = TextFrameFormat()
    text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
    table.setTextFormat(text_frame_format)
    presentation.save("result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **دریافت ویژگی‌های سبک جدول**

از [getStylePreset](https://reference.aspose.com/slides/python-java/aspose.slides/table/#getStylePreset) برای خواندن سبک پیش‌فرض جدول و از [setStylePreset](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setStylePreset) برای اختصاص آن استفاده کنید. این مثال [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/python-java/aspose.slides/tablestylepreset/) را به یک جدول اعمال می‌کند، مقدار پیش‌فرض را چاپ می‌کند و همان پیش‌فرض را به جدول دوم اختصاص می‌دهد. هر دو جدول در `table-style.pptx` ذخیره می‌شوند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = slide.getShapes().addTable(10, 10, column_widths, row_heights)
    table.setStylePreset(TableStylePreset.DarkStyle1)

    style_preset = table.getStylePreset()
    print("Table style preset: ", style_preset)

    another_table = slide.getShapes().addTable(10, 100, column_widths, row_heights)
    another_table.setStylePreset(style_preset)

    presentation.save("table-style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **قفل کردن نسبت ابعاد جدول**

نسبت ابعاد یک جدول، نسبت عرض آن به ارتفاع است. از [setAspectRatioLocked](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobjectlock/#setAspectRatioLocked) برای قفل کردن این نسبت برای یک جدول استفاده کنید.

مثال زیر فایل `pres.pptx` را باز می‌کند که باید حداقل یک اسلاید با یک جدول به‌عنوان اولین شکل داشته باشد. وضعیت قفل فعلی چاپ می‌شود، قفل نسبت ابعاد فعال می‌شود، وضعیت به‌روزرسانی‌شده (`True`) چاپ می‌شود و نتیجه به صورت `pres-out.pptx` ذخیره می‌گردد.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("pres.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())

    table.getGraphicalObjectLock().setAspectRatioLocked(True)
    print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**آیا می‌توانم جهت خواندن راست‑به‑چپ (RTL) را برای کل جدول و متن داخل سلول‌های آن فعال کنم؟**

بله. جدول متد [setRightToLeft](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setRightToLeft) را عرضه می‌کند و پاراگراف‌ها دارای [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setRightToLeft) هستند. استفاده از هر دو تضمین می‌کند که ترتیب RTL درست باشد و داخل سلول‌ها به‌درستی رندر شود.

**چگونه می‌توانم از جابه‌جایی یا تغییر اندازه جدول در فایل نهایی توسط کاربران جلوگیری کنم؟**

از [قفل‌های شکل](/slides/fa/python-java/applying-protection-to-presentation/) برای غیرفعال کردن جابه‌جایی، تغییر اندازه، انتخاب و غیره استفاده کنید. این قفل‌ها روی جدول‌ها نیز اعمال می‌شوند.

**آیا درج تصویر به‌عنوان پس‌زمینه درون سلول پشتیبانی می‌شود؟**

بله. می‌توانید برای یک سلول [picture fill](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/) تنظیم کنید؛ تصویر برحسب حالت انتخابی (کشیده یا کاشی) پوشش سلول را خواهد داشت.