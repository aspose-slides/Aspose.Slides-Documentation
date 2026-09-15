---
title: ایجاد نمودارهای Excel و جاسازی آن‌ها در ارائه‌ها به عنوان شیء OLE
type: docs
weight: 30
url: /fa/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- نمودار Excel
- جاسازی نمودار
- شیء OLE
- PowerPoint
- OpenDocument
- ارائه
- Python
- Java
- Aspose.Slides
description: "نمودارهای Excel را ایجاد کنید و به‌عنوان شیء OLE در ارائه‌های PowerPoint و OpenDocument با Python جاسازی کنید. راهنمای گام‌به‌گام با نمونه کدها."
---
## **پیش‌زمینه**

در PowerPoint، استفاده از نمودارهای قابل ویرایش برای نمایش گرافیکی داده‌ها رایج است. Aspose امکان ایجاد نمودارهای Excel را با Aspose.Cells for Python via Java فراهم می‌کند و این نمودارها می‌توانند به عنوان اشیاء OLE در اسلایدهای PowerPoint از طریق Aspose.Slides for Python via Java جاسازی شوند. این مقاله مراحل لازم را پوشش می‌دهد و نمونه کد پایتون برای ایجاد یک نمودار Excel و جاسازی آن به عنوان شیء OLE در یک ارائه PowerPoint با استفاده از Aspose.Cells و Aspose.Slides ارائه می‌دهد.

## **مراحل مورد نیاز**

1. یک نمودار Excel را با استفاده از Aspose.Cells ایجاد کنید.
1. اندازه OLE نمودار Excel را با Aspose.Cells تنظیم کنید.
1. یک تصویر از نمودار Excel با Aspose.Cells دریافت کنید.
1. نمودار Excel را به عنوان یک شیء OLE در ارائه PPTX با استفاده از Aspose.Slides جاسازی کنید.
1. تصویر «EMBEDDED OLE OBJECT» را با تصویری که در مرحله 3 به دست آمده است، جایگزین کنید تا مشکل [object preview issue](/slides/fa/python-java/object-preview-issue-when-adding-oleobjectframe/) رفع شود.
1. ارائه را در فرمت PPTX روی دیسک ذخیره کنید.

## **پیاده‌سازی مراحل مورد نیاز**

پیاده‌سازی پایتون مراحل فوق به شکل زیر است:

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, ChartType, SheetType, ImageOrPrintOptions, ImageType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")


def add_excel_chart_in_workbook(workbook, chart_rows, chart_columns):
    # یک آرایه از نام‌های سلول.
    cell_names = [
        "A1", "A2", "A3", "A4",
        "B1", "B2", "B3", "B4",
        "C1", "C2", "C3", "C4",
        "D1", "D2", "D3", "D4",
        "E1", "E2", "E3", "E4",
    ]

    # یک آرایه از داده‌های سلول.
    cell_values = [
        67, 86, 68, 91,
        44, 64, 89, 48,
        46, 97, 78, 60,
        43, 29, 69, 26,
        24, 40, 38, 25,
    ]

    # یک Worksheet جدید اضافه کنید تا سلول‌ها را با داده‌ها پر کند.
    data_sheet_index = workbook.getWorksheets().add()
    data_sheet = workbook.getWorksheets().get(data_sheet_index)
    sheet_name = "DataSheet"
    data_sheet.setName(sheet_name)

    # Sheet داده را با داده‌ها پر کنید.
    for cell_name, cell_value in zip(cell_names, cell_values):
        data_sheet.getCells().get(cell_name).setValue(jpype.JInt(cell_value))

    # یک sheet نمودار اضافه کنید.
    worksheet_index = workbook.getWorksheets().add(SheetType.CHART)
    chart_sheet = workbook.getWorksheets().get(worksheet_index)
    chart_sheet.setName("ChartSheet")
    chart_sheet_index = chart_sheet.getIndex()

    # یک نمودار به sheet نمودار اضافه کنید با سری‌های داده از sheet داده.
    chart_index = chart_sheet.getCharts().add(ChartType.COLUMN, 0, chart_rows, 0, chart_columns)
    chart = chart_sheet.getCharts().get(chart_index)
    chart.getNSeries().add(sheet_name + "!A1:E1", False)
    chart.getNSeries().add(sheet_name + "!A2:E2", False)
    chart.getNSeries().add(sheet_name + "!A3:E3", False)
    chart.getNSeries().add(sheet_name + "!A4:E4", False)

    # Sheet نمودار را به عنوان sheet فعال تنظیم کنید.
    workbook.getWorksheets().setActiveSheetIndex(chart_sheet_index)
    return chart_sheet_index


def add_excel_chart_in_presentation(presentation, slide, workbook_data, chart_image):
    ole_height = jpype.JFloat(presentation.getSlideSize().getSize().getHeight())
    ole_width = jpype.JFloat(presentation.getSlideSize().getSize().getWidth())

    # Workbook را به‌عنوان داده OLE جاسازی‌شده توصیف کنید.
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(0.0, 0.0, ole_width, ole_height, data_info)
    image = presentation.getImages().addImage(chart_image)
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(image)


# یک Workbook ایجاد کنید.
workbook = Workbook()

# یک نمودار Excel اضافه کنید.
chart_rows = 55
chart_columns = 25
chart_sheet_index = add_excel_chart_in_workbook(workbook, chart_rows, chart_columns)

# اندازه OLE نمودار را تنظیم کنید.
workbook.getWorksheets().setOleSize(0, chart_rows, 0, chart_columns)

# تصویر نمودار را دریافت کنید و آن را در یک Stream ذخیره کنید.
print_options = ImageOrPrintOptions()
print_options.setImageType(ImageType.PNG)
image_stream = ByteArrayOutputStream()
workbook.getWorksheets().get(chart_sheet_index).getCharts().get(0).toImage(image_stream, print_options)
chart_image = image_stream.toByteArray()

# Workbook را در یک Stream ذخیره کنید.
workbook_stream = ByteArrayOutputStream()
workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)
workbook_data = workbook_stream.toByteArray()

# یک ارائه (Presentation) ایجاد کنید.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Workbook را به یک اسلاید اضافه کنید.
    add_excel_chart_in_presentation(presentation, slide, workbook_data, chart_image)

    # ارائه را روی دیسک ذخیره کنید.
    presentation.save("OutputChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ارائه‌ای که با روش بالا ایجاد می‌شود شامل نمودار Excel به عنوان یک شیء OLE خواهد بود که می‌توان آن را با دوبار کلیک بر روی فریم شیء OLE فعال و ویرایش کرد.

## **نتیجه‌گیری**

با استفاده از Aspose.Cells for Python via Java به همراه Aspose.Slides for Python via Java می‌توان هر نمودار Excelی که توسط Aspose.Cells پشتیبانی می‌شود ایجاد کرده و به عنوان شیء OLE در یک اسلاید PowerPoint جاسازی کرد. اندازه OLE نمودار Excel نیز قابل تعریف است. کاربران نهایی می‌توانند همانند هر شیء OLE دیگری نمودار Excel جاسازی‌شده را ویرایش کنند.

## **بخش‌های مرتبط**

- [راه‌حل کارآمد برای تغییر اندازه نمودار در PPTX](/slides/fa/python-java/working-solution-for-chart-resizing-in-pptx/)
- [مشکل پیش‌نمایش شیء هنگام افزودن OleObjectFrame](/slides/fa/python-java/object-preview-issue-when-adding-oleobjectframe/)

## **سوالات متداول**

**کدام کتابخانه‌ها برای ایجاد و جاسازی نمودار Excel استفاده می‌شوند؟**

Aspose.Cells for Python via Java نمودار Excel را ایجاد می‌کند و Aspose.Slides for Python via Java آن را به عنوان یک شیء OLE در اسلاید PowerPoint جاسازی می‌نماید.

**چگونه کاربران می‌توانند نمودار Excel جاسازی شده را ویرایش کنند؟**

کاربران می‌توانند با دوبار کلیک بر روی فریم شیء OLE، نمودار را فعال کرده و همانند هر شیء OLE دیگری آن را ویرایش کنند.

**پیش‌نمایش پیش‌فرض شیء OLE چگونه جایگزین می‌شود؟**

مثال با استفاده از Aspose.Cells یک تصویر از نمودار Excel دریافت می‌کند و از آن برای جایگزینی تصویر «EMBEDDED OLE OBJECT» استفاده می‌نماید.