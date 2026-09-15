---
title: Создание диаграмм Excel и их встраивание в презентации как OLE‑объекты
type: docs
weight: 30
url: /ru/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Диаграмма Excel
- Встроить диаграмму
- OLE‑объект
- PowerPoint
- OpenDocument
- Презентация
- Python
- Java
- Aspose.Slides
description: "Создавайте диаграммы Excel и встраивайте их как OLE‑объекты в презентации PowerPoint и OpenDocument с помощью Python. Пошаговое руководство с примерами кода."
---
## **Фон**

В PowerPoint использование редактируемых диаграмм для графического отображения данных является распространённой практикой. Aspose поддерживает создание диаграмм Excel с помощью Aspose.Cells for Python via Java, а затем эти диаграммы могут быть встроены как OLE‑объекты в слайды PowerPoint через Aspose.Slides for Python via Java. В этой статье описываются необходимые шаги и приводится пример кода на Python для создания диаграммы Excel и внедрения её в виде OLE‑объекта в презентацию PowerPoint с использованием Aspose.Cells и Aspose.Slides.

## **Необходимые шаги**

Для создания и внедрения диаграммы Excel в виде OLE‑объекта в слайд PowerPoint необходимо выполнить следующую последовательность шагов:

1. Создать диаграмму Excel с помощью Aspose.Cells.
1. Установить размер OLE‑объекта диаграммы Excel с помощью Aspose.Cells.
1. Получить изображение диаграммы Excel с помощью Aspose.Cells.
1. Встроить диаграмму Excel в виде OLE‑объекта в презентацию PPTX с помощью Aspose.Slides.
1. Заменить изображение «EMBEDDED OLE OBJECT» на изображение, полученное на шаге 3, чтобы решить проблему [object preview issue](/slides/ru/python-java/object-preview-issue-when-adding-oleobjectframe/).
1. Сохранить презентацию на диск в формате PPTX.

## **Реализация необходимых шагов**

Ниже приведена реализация вышеуказанных шагов на Python:

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
    # Массив имён ячеек.
    cell_names = [
        "A1", "A2", "A3", "A4",
        "B1", "B2", "B3", "B4",
        "C1", "C2", "C3", "C4",
        "D1", "D2", "D3", "D4",
        "E1", "E2", "E3", "E4",
    ]

    # Массив данных ячеек.
    cell_values = [
        67, 86, 68, 91,
        44, 64, 89, 48,
        46, 97, 78, 60,
        43, 29, 69, 26,
        24, 40, 38, 25,
    ]

    # Добавить новый лист для заполнения ячеек данными.
    data_sheet_index = workbook.getWorksheets().add()
    data_sheet = workbook.getWorksheets().get(data_sheet_index)
    sheet_name = "DataSheet"
    data_sheet.setName(sheet_name)

    # Заполнить лист данных данными.
    for cell_name, cell_value in zip(cell_names, cell_values):
        data_sheet.getCells().get(cell_name).setValue(jpype.JInt(cell_value))

    # Добавить лист с диаграммой.
    worksheet_index = workbook.getWorksheets().add(SheetType.CHART)
    chart_sheet = workbook.getWorksheets().get(worksheet_index)
    chart_sheet.setName("ChartSheet")
    chart_sheet_index = chart_sheet.getIndex()

    # Добавить диаграмму на лист диаграмм, используя серии данных с листа данных.
    chart_index = chart_sheet.getCharts().add(ChartType.COLUMN, 0, chart_rows, 0, chart_columns)
    chart = chart_sheet.getCharts().get(chart_index)
    chart.getNSeries().add(sheet_name + "!A1:E1", False)
    chart.getNSeries().add(sheet_name + "!A2:E2", False)
    chart.getNSeries().add(sheet_name + "!A3:E3", False)
    chart.getNSeries().add(sheet_name + "!A4:E4", False)

    # Установить лист диаграммы активным листом.
    workbook.getWorksheets().setActiveSheetIndex(chart_sheet_index)
    return chart_sheet_index


def add_excel_chart_in_presentation(presentation, slide, workbook_data, chart_image):
    ole_height = jpype.JFloat(presentation.getSlideSize().getSize().getHeight())
    ole_width = jpype.JFloat(presentation.getSlideSize().getSize().getWidth())

    # Описать рабочую книгу как вложенные OLE‑данные.
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(0.0, 0.0, ole_width, ole_height, data_info)
    image = presentation.getImages().addImage(chart_image)
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(image)


# Создать рабочую книгу.
workbook = Workbook()

# Добавить диаграмму Excel.
chart_rows = 55
chart_columns = 25
chart_sheet_index = add_excel_chart_in_workbook(workbook, chart_rows, chart_columns)

# Задать размер OLE‑объекта диаграммы.
workbook.getWorksheets().setOleSize(0, chart_rows, 0, chart_columns)

# Получить изображение диаграммы и сохранить его в поток.
print_options = ImageOrPrintOptions()
print_options.setImageType(ImageType.PNG)
image_stream = ByteArrayOutputStream()
workbook.getWorksheets().get(chart_sheet_index).getCharts().get(0).toImage(image_stream, print_options)
chart_image = image_stream.toByteArray()

# Сохранить рабочую книгу в поток.
workbook_stream = ByteArrayOutputStream()
workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)
workbook_data = workbook_stream.toByteArray()

# Создать презентацию.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Добавить рабочую книгу на слайд.
    add_excel_chart_in_presentation(presentation, slide, workbook_data, chart_image)

    # Сохранить презентацию на диск.
    presentation.save("OutputChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Презентация, созданная указанным способом, будет содержать диаграмму Excel в виде OLE‑объекта, который можно активировать двойным щелчком по кадру OLE‑объекта.

## **Заключение**

Используя Aspose.Cells for Python via Java вместе с Aspose.Slides for Python via Java, можно создать любую диаграмму Excel, поддерживаемую Aspose.Cells, и встроить её в виде OLE‑объекта в слайд PowerPoint. Размер OLE‑объекта диаграммы Excel также может быть задан. Конечные пользователи могут затем редактировать диаграмму Excel так же, как любой другой OLE‑объект.

## **Сопутствующие разделы**

- [Рабочее решение для изменения размера диаграмм в PPTX](/slides/ru/python-java/working-solution-for-chart-resizing-in-pptx/)
- [Проблема предварительного просмотра объекта при добавлении OleObjectFrame](/slides/ru/python-java/object-preview-issue-when-adding-oleobjectframe/)

## **FAQ**

**Какие библиотеки используются для создания и внедрения диаграммы Excel?**

Aspose.Cells for Python via Java создаёт диаграмму Excel, а Aspose.Slides for Python via Java встраивает её в виде OLE‑объекта в слайд PowerPoint.

**Как пользователи могут редактировать встроенную диаграмму Excel?**

Пользователи могут двойным щелчком по кадру OLE‑объекта активировать диаграмму и редактировать её, как любой другой OLE‑объект.

**Как заменяется предварительный просмотр OLE‑объекта по умолчанию?**

В примере изображение диаграммы Excel получено с помощью Aspose.Cells и используется для замены изображения «EMBEDDED OLE OBJECT».