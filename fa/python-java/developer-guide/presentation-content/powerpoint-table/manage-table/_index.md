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
- استایل جدول
- PowerPoint
- ارائه
- Python
- Aspose.Slides
description: "ایجاد و ویرایش جداول در اسلایدهای PowerPoint با Aspose.Slides برای Python از طریق Java. مثال‌های کد ساده‌ای برای بهینه‌سازی جریان کار جداول خود کشف کنید."
---
## **مقدمه**

یک جدول در PowerPoint روشی کارآمد برای نمایش اطلاعات است. اطلاعات در یک شبکهٔ سلول‌ها (قابل ترتیب در سطرها و ستون‌ها) به‌صورت واضح و آسان قابل درک است.

Aspose.Slides کلاس [Table](https://reference.aspose.com/slides/fa/python-java/aspose.slides/table/) ، کلاس [Cell](https://reference.aspose.com/slides/fa/python-java/aspose.slides/cell/) و انواع دیگر را فراهم می‌کند تا بتوانید جداول را در انواع ارائه‌ها ایجاد، به‌روزرسانی و مدیریت کنید.

## **ایجاد جدول از ابتدا**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.
2. با استفاده از ایندکس، به اسلایدی که می‌خواهید دسترسی پیدا کنید.
3. لیستی از عرض‌های ستون‌ها را تعریف کنید.
4. لیستی از ارتفاع‌های سطرها را تعریف کنید.
5. با استفاده از متد [addTable](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shapecollection/#addTable) یک شیء [Table](https://reference.aspose.com/slides/fa/python-java/aspose.slides/table/) را به اسلاید اضافه کنید.
6. برای هر [Cell](https://reference.aspose.com/slides/fa/python-java/aspose.slides/cell/) به ترتیب، حاشیه‌های بالا، پایین، راست و چپ را قالب‌بندی کنید.
7. دو سلول اول سطر اول جدول را ترکیب (Merge) کنید.
8. به [TextFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframe/) یک [Cell](https://reference.aspose.com/slides/fa/python-java/aspose.slides/cell/) دسترسی پیدا کنید.
9. متنی به [TextFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframe/) اضافه کنید.
10. ارائه اصلاح‌شده را ذخیره کنید.

این کد Python نشان می‌دهد چگونه یک جدول در یک ارائه ایجاد کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

# نمونه‌ای از کلاس Presentation را که یک فایل PPTX را نشان می‌دهد، ایجاد می‌کند
presentation = Presentation()
try:

    # به اسلاید اول دسترسی پیدا می‌کند
    slide = presentation.getSlides().get_Item(0)

    # ستون‌ها را با عرض‌ها و سطرها را با ارتفاع‌ها تعریف می‌کند
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # یک شکل جدول را به اسلاید اضافه می‌کند
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # قالب حاشیه را برای هر سلول تنظیم می‌کند
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

    # سلول‌های 1 و 2 ردیف 1 را ترکیب می‌کند
    table.mergeCells(table.getRows().get_Item(0).get_Item(0), table.getRows().get_Item(0).get_Item(1), False)

    # متنی به سلول ترکیب‌شده اضافه می‌کند
    table.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells")

    # ارائه را روی دیسک ذخیره می‌کند
    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **شماره‌گذاری در جدول استاندارد**

در یک جدول استاندارد، شماره‌گذاری سلول‌ها به‌صورت ساده و مبتنی بر صفر است. اولین سلول جدول به عنوان 0,0 (ستون 0، سطر 0) ایندکس می‌شود.

به‌عنوان مثال، سلول‌های یک جدول با 4 ستون و 4 سطر به این شکل شماره‌گذاری می‌شوند:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

این کد Python نشان می‌دهد چگونه یک جدول با شماره‌گذاری استاندارد سلول‌ها ایجاد کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

# یک نمونه از کلاس Presentation را که یک فایل PPTX را نشان می‌دهد، ایجاد می‌کند
presentation = Presentation()
try:

    # به اسلاید اول دسترسی پیدا می‌کند
    slide = presentation.getSlides().get_Item(0)

    # ستون‌ها را با عرض‌ها و سطرها را با ارتفاع‌ها تعریف می‌کند
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # یک شکل جدول را به اسلاید اضافه می‌کند
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # قالب حاشیه را برای هر سلول تنظیم می‌کند
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

    # ارائه را روی دیسک ذخیره می‌کند
    presentation.save("StandardTables_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **دسترسی به جدول موجود**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.

2. با استفاده از ایندکس، به اسلاید حاوی جدول دسترسی پیدا کنید.

3. متغیری برای شیء [Table](https://reference.aspose.com/slides/fa/python-java/aspose.slides/table/) تعریف کنید و مقدار اولیه آن را `None` قرار دهید.

4. تمام اشیاء [Shape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/) را مرور کنید تا جدول پیدا شود.

   اگر گمان می‌کنید اسلاید مورد نظر فقط یک جدول دارد، می‌توانید تمام شکل‌های موجود را بررسی کنید. هنگامی که یک شکل به عنوان جدول تشخیص داده شد، می‌توانید از آن به عنوان شیء [Table](https://reference.aspose.com/slides/fa/python-java/aspose.slides/table/) استفاده کنید. اما اگر اسلاید شامل چندین جدول باشد، بهتر است جدول مورد نیاز را با استفاده از متد [getAlternativeText](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/#getAlternativeText) جستجو کنید.

5. از شیء [Table](https://reference.aspose.com/slides/fa/python-java/aspose.slides/table/) برای کار با جدول استفاده کنید. در مثال زیر، متن ستون اول سطر دوم به‌روزرسانی می‌شود.

6. ارائه اصلاح‌شده را ذخیره کنید.

این کد Python نشان می‌دهد چگونه به جدول موجود دسترسی پیدا کنید و با آن کار کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

# یک نمونه از کلاس Presentation که نمایانگر یک فایل PPTX است، ایجاد می‌کند
presentation = Presentation("UpdateExistingTable.pptx")
try:

    # به اولین اسلاید دسترسی پیدا می‌کند
    slide = presentation.getSlides().get_Item(0)

    # مرجع جدول را مقداردهی اولیه می‌کند.
    table = None

    # از اشکال عبور می‌کند و مرجعی به جدول پیدا شده تنظیم می‌کند
    for shape in slide.getShapes():
        if isinstance(shape, Table):
            table = shape

            # متن را برای ستون اول ردیف دوم تنظیم می‌کند
            table.get_Item(0, 1).getTextFrame().setText("New")

    # ارائه اصلاح‌شده را روی دیسک ذخیره می‌کند
    presentation.save("table1_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **یابی سلولی که یک TextFrame را در اختیار دارد**

هنگامی که کد عمومی پردازش متن یک [TextFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframe/) را از جدول دریافت می‌کند، از متد [TextFrame.getParentCell](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframe/#getParentCell) برای دریافت سلول مالک استفاده کنید. برای یک TextFrame سلول‑جدول، [TextFrame.getParentCell](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframe/#getParentCell) مالک را برمی‌گرداند و [TextFrame.getParentShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframe/#getParentShape) مقدار `None` می‌دهد، حتی اگر جدول خودش یک Shape باشد.

مختصات سلول‌ها از طریق متدهای فقط‌خواندنی [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/fa/python-java/aspose.slides/cell/#getFirstColumnIndex) و [Cell.getFirstRowIndex](https://reference.aspose.com/slides/fa/python-java/aspose.slides/cell/#getFirstRowIndex) در دسترس هستند. [TextFrame.getParentCell](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframe/#getParentCell) همچنین مسیریابی فقط‌خواندنی ارائه می‌دهد: مالک را برمی‌گرداند اما مالکیت را تغییر نمی‌دهد. همیشه قبل از استفاده، بررسی کنید که مقدار بازگردانده شده `None` نیست.

برای مثال کامل که مالکین سلول‑جدول و Shape را شامل اشکال مرتبط با گره‌های SmartArt شناسایی می‌کند، به بخش [Search and Replace Text](/slides/fa/python-java/search-and-replace-text/) مراجعه کنید.

## **تراز کردن متن در جدول**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.
2. با استفاده از ایندکس، به اسلایدی که می‌خواهید دسترسی پیدا کنید.
3. یک شیء [Table](https://reference.aspose.com/slides/fa/python-java/aspose.slides/table/) را به اسلاید اضافه کنید.
4. یک شیء [TextFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframe/) را از جدول استخراج کنید.
5. به شیء [Paragraph](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraph/) متعلق به [TextFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframe/) دسترسی پیدا کنید.
6. متن را به‌صورت عمودی تراز کنید.
7. ارائه اصلاح‌شده را ذخیره کنید.

این کد Python نشان می‌دهد چگونه متن را در یک جدول تراز کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, TextAnchorType, TextVerticalType
from java.awt import Color

# یک نمونه از کلاس Presentation ایجاد می‌کند
presentation = Presentation()
try:

    # اسلاید اول را دریافت می‌کند
    slide = presentation.getSlides().get_Item(0)

    # ستون‌ها را با عرض‌ها و سطرها را با ارتفاع‌ها تعریف می‌کند
    column_widths = [120, 120, 120, 120]
    row_heights = [100, 100, 100, 100]

    # شکل جدول را به اسلاید اضافه می‌کند
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)
    table.get_Item(1, 0).getTextFrame().setText("10")
    table.get_Item(2, 0).getTextFrame().setText("20")
    table.get_Item(3, 0).getTextFrame().setText("30")

    # به قاب متن دسترسی پیدا می‌کند
    text_frame = table.get_Item(0, 0).getTextFrame()

    # به اولین پاراگراف در قاب متن دسترسی می‌یابد.
    paragraph = text_frame.getParagraphs().get_Item(0)

    # به اولین بخش در پاراگراف دسترسی می‌یابد.
    portion = paragraph.getPortions().get_Item(0)
    portion.setText("Text here")
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    # متن را به صورت عمودی تراز می‌کند
    cell = table.get_Item(0, 0)
    cell.setTextAnchorType(TextAnchorType.Center)
    cell.setTextVerticalType(TextVerticalType.Vertical270)

    # پرزنتیشن را روی دیسک ذخیره می‌کند
    presentation.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تنظیم قالب‌بندی متن در سطح جدول**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.
2. با استفاده از ایندکس، به اسلایدی که می‌خواهید دسترسی پیدا کنید.
3. یک شیء [Table](https://reference.aspose.com/slides/fa/python-java/aspose.slides/table/) را از اسلاید دریافت کنید.
4. ارتفاع فونت متن را با [setFontHeight](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseportionformat/#setFontHeight) تنظیم کنید.
5. تراز و حاشیهٔ راست را با [setAlignment](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraphformat/#setAlignment) و [setMarginRight](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraphformat/#setMarginRight) تنظیم کنید.
6. نوع متن عمودی را با [setTextVerticalType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframeformat/#setTextVerticalType) تنظیم کنید.
7. ارائه اصلاح‌شده را ذخیره کنید.

این کد Python نشان می‌دهد چگونه گزینه‌های قالب‌بندی دلخواه خود را به متن جدول اعمال کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ParagraphFormat, PortionFormat, Presentation, SaveFormat, TextAlignment, TextFrameFormat, TextVerticalType, Table

# یک نمونه از کلاس Presentation ایجاد می‌کند
presentation = Presentation("simpletable.pptx")
try:

    # فرض می‌کنیم اولین شکل در اسلاید اول یک جدول است
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape

        # ارتفاع فونت سلول‌های جدول را تنظیم می‌کند
        portion_format = PortionFormat()
        portion_format.setFontHeight(25)
        table.setTextFormat(portion_format)

        # تراز متن سلول‌های جدول و حاشیهٔ راست را در یک فراخوانی تنظیم می‌کند
        paragraph_format = ParagraphFormat()
        paragraph_format.setAlignment(TextAlignment.Right)
        paragraph_format.setMarginRight(20)
        table.setTextFormat(paragraph_format)

        # نوع عمودی متن سلول‌های جدول را تنظیم می‌کند
        text_frame_format = TextFrameFormat()
        text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
        table.setTextFormat(text_frame_format)
        presentation.save("result.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **دریافت ویژگی‌های استایل جدول**

Aspose.Slides به شما امکان می‌دهد ویژگی‌های استایل یک جدول را دریافت کنید تا بتوانید این جزئیات را برای جدول دیگری یا در مکان دیگری استفاده کنید. این کد Python نشان می‌دهد چگونه ویژگی‌های استایل را از یک استایل پیش‌تنظیم جدول دریافت کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    table = presentation.getSlides().get_Item(0).getShapes().addTable(10, 10, [100, 150], [5, 5, 5])
    table.setStylePreset(TableStylePreset.DarkStyle1)  # تم پیش‌فرض پیش‌تنظیم استایل را تغییر می‌دهد

    # پیش‌تنظیم سبک جدول را دریافت می‌کند
    style_preset = table.getStylePreset()
    print("Table style preset: ", style_preset)

    # پیش‌تنظیم سبک بازیابی‌شده را به جدول دیگری اعمال می‌کند
    another_table = presentation.getSlides().get_Item(0).getShapes().addTable(10, 100, [100, 150], [5, 5, 5])
    another_table.setStylePreset(style_preset)
    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **قفل کردن نسبت ابعاد جدول**

نسبت ابعاد یک شکل هندسی، نسبت اندازه‌های آن در ابعاد مختلف است. Aspose.Slides متد [setAspectRatioLocked](https://reference.aspose.com/slides/fa/python-java/aspose.slides/graphicalobjectlock/#setAspectRatioLocked) را فراهم می‌کند تا بتوانید تنظیم قفل نسبت ابعاد را برای جدول‌ها و دیگر اشکال اعمال کنید.

این کد Python نشان می‌دهد چگونه نسبت ابعاد یک جدول را قفل کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("pres.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
        print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())
        table.getGraphicalObjectLock().setAspectRatioLocked(not table.getGraphicalObjectLock().getAspectRatioLocked())  # معکوس
        print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())
        presentation.save("pres-out.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **پرسش‌های متداول**

**آیا می‌توانم جهت خواندن راست به چپ (RTL) را برای کل جدول و متن در سلول‌های آن فعال کنم؟**

بله. جدول متد [setRightToLeft](https://reference.aspose.com/slides/fa/python-java/aspose.slides/table/#setRightToLeft) را در اختیار دارد و پاراگراف‌ها متد [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraphformat/#setRightToLeft) دارند. استفاده از هر دو اطمینان می‌دهد که ترتیب RTL صحیح و رندر مناسب در داخل سلول‌ها اعمال می‌شود.

**چگونه می‌توانم از جابجایی یا تغییر اندازه جدول توسط کاربران در فایل نهایی منع کنم؟**

از [قفل‌های شکل](/slides/fa/python-java/applying-protection-to-presentation/) استفاده کنید تا جابجایی، تغییر اندازه، انتخاب و غیره غیر فعال شود. این قفل‌ها بر روی جداول نیز اعمال می‌گردند.

**آیا درج تصویر داخل یک سلول به‌عنوان پس‌زمینه پشتیبانی می‌شود؟**

بله. می‌توانید برای یک سلول [picture fill](https://reference.aspose.com/slides/fa/python-java/aspose.slides/picturefillformat/) تنظیم کنید؛ تصویر بر اساس حالت انتخابی (کشیدگی یا کاشی) کل منطقهٔ سلول را پوشش می‌دهد.