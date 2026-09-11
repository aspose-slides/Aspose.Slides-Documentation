---
title: مدیریت سطرها و ستون‌ها در جداول PowerPoint با استفاده از Python
linktitle: سطرها و ستون‌ها
type: docs
weight: 20
url: /fa/python-java/manage-rows-and-columns/
keywords:
- سطر جدول
- ستون جدول
- سطر اول
- سرصفحه جدول
- تکثیر سطر
- تکثیر ستون
- کپی سطر
- کپی ستون
- حذف سطر
- حذف ستون
- قالب‌بندی متن سطر
- قالب‌بندی متن ستون
- سبک جدول
- PowerPoint
- ارائه
- پایتون
- Aspose.Slides
description: "مدیریت سطرها و ستون‌های جدول در PowerPoint با Aspose.Slides برای Python از طریق Java و تسریع ویرایش ارائه و به‌روزرسانی داده‌ها."
---
## **مقدمه**

برای این‌که بتوانید سطرها و ستون‌های یک جدول را در یک ارائه PowerPoint مدیریت کنید، Aspose.Slides کلاس [Table](https://reference.aspose.com/slides/fa/python-java/aspose.slides/table/) و بسیاری از انواع دیگر را فراهم می‌کند.

## **تنظیم اولین سطر به عنوان سرعنوان**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید و ارائه را بارگذاری کنید.
2. با استفاده از اندیس، به یک اسلاید ارجاع دریافت کنید.
3. یک مرجع [Table](https://reference.aspose.com/slides/fa/python-java/aspose.slides/table/) ایجاد کنید و آن را به `None` تنظیم کنید.
4. از میان تمام اشیای [Shape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/) عبور کنید تا جدول مورد نظر را پیدا کنید.
5. اولین سطر جدول را به عنوان سرعنوان آن تنظیم کنید.

این کد Python نشان می‌دهد که چگونه اولین سطر جدول را به عنوان سرعنوان تنظیم کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = None
    for shape in slide.getShapes():
        if isinstance(shape, Table):
            table = shape
            table.setFirstRow(True)
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **کپی یک سطر یا ستون جدول**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید و ارائه را بارگذاری کنید.
2. با استفاده از اندیس، به یک اسلاید ارجاع دریافت کنید.
3. یک لیست از عرض‌های ستون‌ها تعریف کنید.
4. یک لیست از ارتفاع‌های سطرها تعریف کنید.
5. از طریق روش [addTable](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shapecollection/#addTable)، یک شیء [Table](https://reference.aspose.com/slides/fa/python-java/aspose.slides/table/) را به اسلاید اضافه کنید.
6. سطر جدول را کپی کنید.
7. ستون جدول را کپی کنید.
8. ارائه اصلاح‌شده را ذخیره کنید.

این کد Python نشان می‌دهد که چگونه سطر یا ستون جدول PowerPoint را کپی کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("Test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)
    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1")
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2")
    table.getRows().addClone(table.getRows().get_Item(0), False)
    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1")
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2")
    table.getRows().insertClone(3, table.getRows().get_Item(1), False)
    table.getColumns().addClone(table.getColumns().get_Item(0), False)
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), False)
    presentation.save("table_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **حذف یک سطر یا ستون از جدول**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.
2. با استفاده از اندیس، به یک اسلاید ارجاع دریافت کنید.
3. یک لیست از عرض‌های ستون‌ها تعریف کنید.
4. یک لیست از ارتفاع‌های سطرها تعریف کنید.
5. از طریق روش [addTable](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shapecollection/#addTable)، یک شیء [Table](https://reference.aspose.com/slides/fa/python-java/aspose.slides/table/) را به اسلاید اضافه کنید.
6. سطر جدول را حذف کنید.
7. ستون جدول را حذف کنید.
8. ارائه اصلاح‌شده را ذخیره کنید.

این کد Python نشان می‌دهد که چگونه یک سطر یا ستون را از جدول حذف کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    column_widths = [100, 50, 30]
    row_heights = [30, 50, 30]
    table = slide.getShapes().addTable(100, 100, column_widths, row_heights)
    table.getRows().removeAt(1, False)
    table.getColumns().removeAt(1, False)
    presentation.save("TestTable_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تنظیم قالب‌بندی متن در سطح سطر جدول**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید و ارائه را بارگذاری کنید.
2. با استفاده از اندیس، به یک اسلاید ارجاع دریافت کنید.
3. شیء [Table](https://reference.aspose.com/slides/fa/python-java/aspose.slides/table/) مرتبط را از اسلاید دسترسی پیدا کنید.
4. ارتفاع فونت سلول‌های اولین سطر را با استفاده از [setFontHeight](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseportionformat/#setFontHeight) تنظیم کنید.
5. تراز متن و حاشیه راست سلول‌های اولین سطر را با استفاده از [setAlignment](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraphformat/#setAlignment) و [setMarginRight](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraphformat/#setMarginRight) تنظیم کنید.
6. نوع متن عمودی سلول‌های سطر دوم را با استفاده از [setTextVerticalType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframeformat/#setTextVerticalType) تنظیم کنید.
7. ارائه اصلاح‌شده را ذخیره کنید.

این کد Python عمل را نشان می‌دهد.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table, PortionFormat, ParagraphFormat, TextFrameFormat, TextAlignment, TextVerticalType

presentation = Presentation("table.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
        portion_format = PortionFormat()
        portion_format.setFontHeight(25)
        table.getRows().get_Item(0).setTextFormat(portion_format)
        paragraph_format = ParagraphFormat()
        paragraph_format.setAlignment(TextAlignment.Right)
        paragraph_format.setMarginRight(20)
        table.getRows().get_Item(0).setTextFormat(paragraph_format)
        text_frame_format = TextFrameFormat()
        text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
        table.getRows().get_Item(1).setTextFormat(text_frame_format)
        presentation.save("result.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **تنظیم قالب‌بندی متن در سطح ستون جدول**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید و ارائه را بارگذاری کنید.
2. با استفاده از اندیس، به یک اسلاید ارجاع دریافت کنید.
3. شیء [Table](https://reference.aspose.com/slides/fa/python-java/aspose.slides/table/) مرتبط را از اسلاید دسترسی پیدا کنید.
4. ارتفاع فونت سلول‌های اولین ستون را با استفاده از [setFontHeight](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseportionformat/#setFontHeight) تنظیم کنید.
5. تراز متن و حاشیه راست سلول‌های اولین ستون را با استفاده از [setAlignment](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraphformat/#setAlignment) و [setMarginRight](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraphformat/#setMarginRight) تنظیم کنید.
6. نوع متن عمودی سلول‌های ستون دوم را با استفاده از [setTextVerticalType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframeformat/#setTextVerticalType) تنظیم کنید.
7. ارائه اصلاح‌شده را ذخیره کنید.

این کد Python عمل را نشان می‌دهد:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table, PortionFormat, ParagraphFormat, TextFrameFormat, TextAlignment, TextVerticalType

presentation = Presentation("table.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
        portion_format = PortionFormat()
        portion_format.setFontHeight(25)
        table.getColumns().get_Item(0).setTextFormat(portion_format)
        paragraph_format = ParagraphFormat()
        paragraph_format.setAlignment(TextAlignment.Right)
        paragraph_format.setMarginRight(20)
        table.getColumns().get_Item(0).setTextFormat(paragraph_format)
        text_frame_format = TextFrameFormat()
        text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
        table.getColumns().get_Item(1).setTextFormat(text_frame_format)
        presentation.save("result.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **دریافت ویژگی‌های سبک جدول**

Aspose.Slides به شما امکان می‌دهد ویژگی‌های سبک یک جدول را استخراج کنید تا بتوانید این جزئیات را برای جدول دیگر یا جای دیگری استفاده کنید. این کد Python نشان می‌دهد که چگونه ویژگی‌های سبک را از یک سبک پیش‌فرض جدول دریافت کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = presentation.getSlides().get_Item(0).getShapes().addTable(10, 10, column_widths, row_heights)
    table.setStylePreset(TableStylePreset.DarkStyle1)
    style_preset = table.getStylePreset()
    print(style_preset)
    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **سوالات متداول**

**آیا می‌توانم تم/سبک‌های PowerPoint را به جدولی که قبلاً ایجاد شده اعمال کنم؟**

بله. جدول تم اسلاید/چیدمان/مستر را به ارث می‌برد و همچنان می‌توانید پرکردن‌ها، حاشیه‌ها و رنگ‌های متن را بر روی آن تم بازنویسی کنید.

**آیا می‌توانم سطرهای جدول را مثل Excel مرتب کنم؟**

خیر، جداول Aspose.Slides قابلیت مرتب‌سازی یا فیلتر داخلی ندارند. ابتدا داده‌های خود را در حافظه مرتب کنید، سپس سطرهای جدول را بر وفق آن ترتیب دوباره پر کنید.

**آیا می‌توانم ستون‌های نوار‌دار (راه‌راه) داشته باشم در حالی که رنگ‌های سفارشی را برای سلول‌های خاص حفظ کنم؟**

بله. ستون‌های نوار‌دار را فعال کنید، سپس سلول‌های خاص را با قالب‌بندی محلی بازنویسی کنید؛ قالب‌بندی سطح سلول بر استایل جدول اولویت دارد.