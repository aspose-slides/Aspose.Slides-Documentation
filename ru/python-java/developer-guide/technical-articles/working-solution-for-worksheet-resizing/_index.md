---
title: Рабочее решение проблемы изменения размера листа
type: docs
weight: 20
url: /ru/python-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- изображение предварительного просмотра
- изменение размера изображения
- Excel
- лист
- PowerPoint
- презентация
- Python
- Java
- Aspose.Slides
description: "Исправление масштабирования OLE-объекта листа Excel в презентациях: два способа сохранить одинаковый размер рамок объектов - масштабировать рамку или лист - для форматов PPT и PPTX."
---
{{% alert color="info" title="Примечание" %}}

Было обнаружено, что листы Excel, встроенные как OLE‑объекты в презентацию PowerPoint через компоненты Aspose, масштабируются до неопределённого масштаба после первой активации. Такое поведение создаёт заметную визуальную разницу в презентации между состояниями OLE‑объекта до и после активации. Мы подробно исследовали эту проблему и предложили решение, которое описано в этой статье.

{{% /alert %}}

## **Фон**

В статье [Manage OLE](/slides/ru/python-java/manage-ole/) мы объяснили, как добавить OLE‑рамку в презентацию PowerPoint с помощью Aspose.Slides for Python via Java. Чтобы решить проблему [object preview issue](/slides/ru/python-java/object-preview-issue-when-adding-oleobjectframe/), мы назначили изображение выбранной области листа OLE‑объекту. В полученной презентации, двойной клик по OLE‑рамке, отображающей изображение листа, активирует книгу Excel. Пользователь может вносить любые изменения в реальную книгу Excel, а затем вернуться к слайду, щёлкнув за пределами активированного Excel. Размер OLE‑рамки изменится, когда пользователь вернётся к слайду. Коэффициент масштабирования будет зависеть от размеров OLE‑рамки и встроенной книги Excel.

## **Причина масштабирования**

Поскольку у книги Excel есть собственный размер окна, при первой активации она пытается сохранить свой оригинальный размер. С другой стороны, OLE‑рамка имеет свой собственный размер. По данным Microsoft, когда книга Excel активируется, Excel и PowerPoint согласуют размер, чтобы обеспечить правильные пропорции в процессе внедрения. Масштабирование происходит из‑за различий между размером окна Excel и размерами и положением OLE‑рамки.

## **Рабочее решение**

Существует два возможных подхода, позволяющих избежать эффекта масштабирования.

- Масштабировать размер OLE‑рамки в презентации PowerPoint так, чтобы он соответствовал высоте и ширине нужного количества строк и столбцов в OLE‑рамке.
- Оставить размер OLE‑рамки постоянным и масштабировать размеры участвующих строк и столбцов, чтобы они помещались в выбранный размер OLE‑рамки.

### **Масштабировать размер OLE‑рамки**

В этом подходе мы узнаем, как задать размер OLE‑рамки встроенной книги Excel так, чтобы он соответствовал совокупному размеру участвующих строк и столбцов листа Excel.

Предположим, у нас есть шаблонный лист Excel, который нужно добавить в презентацию как OLE‑рамку. В этом случае размер OLE‑объекта сначала рассчитывается на основе совокупных высот строк и ширин столбцов, участвующих в книге. Затем мы задаём размер OLE‑рамки равным этому расчётному значению. Чтобы избавиться от красного сообщения «EMBEDDED OLE OBJECT» для OLE‑рамки в PowerPoint, мы также захватываем изображение нужных участков строк и столбцов книги и устанавливаем его как изображение OLE‑рамки.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, ImageOrPrintOptions, ImageType, SheetRender, CellsUnitType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import Presentation, OleEmbeddedDataInfo, SaveFormat

ByteArrayInputStream = jpype.JClass("java.io.ByteArrayInputStream")
ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")


def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.getWorksheet().getPageSetup()
    page_setup.setPrintArea(cell_range.getAddress())
    page_setup.setLeftMargin(0)
    page_setup.setRightMargin(0)
    page_setup.setTopMargin(0)
    page_setup.setBottomMargin(0)
    page_setup.clearHeaderFooter()

    image_options = ImageOrPrintOptions()
    image_options.setImageType(ImageType.PNG)
    image_options.setVerticalResolution(image_resolution)
    image_options.setHorizontalResolution(image_resolution)
    image_options.setOnePagePerSheet(True)
    image_options.setOnlyArea(True)

    sheet_render = SheetRender(cell_range.getWorksheet(), image_options)
    image_stream = ByteArrayOutputStream()
    try:
        sheet_render.toImage(0, image_stream)
        image_data = image_stream.toByteArray()
        return ByteArrayInputStream(image_data)
    finally:
        image_stream.close()


start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0
image_resolution = 96

workbook = Workbook("sample.xlsx")
try:
    worksheet = workbook.getWorksheets().get(worksheet_index)

    # Установить отображаемый размер, когда книга используется как OLE‑объект в PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.getWorksheets().setOleSize(start_row, last_row, start_column, last_column)

    cell_range = worksheet.getCells().createRange(start_row, start_column, row_count, column_count)

    image_stream = create_ole_image(cell_range, image_resolution)
    try:
        # Получить ширину и высоту OLE‑изображения в пунктах.
        image_io = jpype.JClass("javax.imageio.ImageIO")
        image = image_io.read(image_stream)
        frame_width = image.getWidth() * 72.0 / image_resolution
        frame_height = image.getHeight() * 72.0 / image_resolution

        # Использовать изменённую книгу.
        ole_stream = ByteArrayOutputStream()
        try:
            workbook.save(ole_stream, CellsSaveFormat.XLSX)
            workbook_data = ole_stream.toByteArray()
        finally:
            ole_stream.close()

        presentation = Presentation()
        try:
            slide = presentation.getSlides().get_Item(0)

            # Добавить OLE‑изображение в ресурсы презентации.
            image_stream.reset()
            ole_image = presentation.getImages().addImage(image_stream)

            # Создать кадр OLE‑объекта.
            data_info = OleEmbeddedDataInfo(workbook_data, "xlsx")
            ole_frame = slide.getShapes().addOleObjectFrame(10.0, 10.0, frame_width, frame_height, data_info)
            ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
            ole_frame.setObjectIcon(False)

            presentation.save("output.pptx", SaveFormat.Pptx)
        finally:
            presentation.dispose()
    finally:
        image_stream.close()
finally:
    workbook.dispose()
```

### **Масштабировать диапазон ячеек**

В этом подходе мы узнаем, как масштабировать высоты участвующих строк и ширины участвующих столбцов, чтобы они соответствовали пользовательскому размеру OLE‑рамки.

Предположим, у нас есть шаблонный лист Excel, который нужно добавить в презентацию как OLE‑рамку. В этом случае мы задаём размер OLE‑рамки и масштабируем размеры строк и столбцов, входящих в область OLE‑рамки. Затем сохраняем книгу в поток, чтобы применить изменения, и преобразуем её в массив байтов для добавления в OLE‑рамку. Чтобы избавиться от красного сообщения «EMBEDDED OLE OBJECT», мы также захватываем изображение нужных участков строк и столбцов книги и устанавливаем его как изображение OLE‑рамки.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, ImageOrPrintOptions, ImageType, SheetRender, CellsUnitType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import Presentation, OleEmbeddedDataInfo, SaveFormat

ByteArrayInputStream = jpype.JClass("java.io.ByteArrayInputStream")
ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")


def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.getWorksheet().getPageSetup()
    page_setup.setPrintArea(cell_range.getAddress())
    page_setup.setLeftMargin(0)
    page_setup.setRightMargin(0)
    page_setup.setTopMargin(0)
    page_setup.setBottomMargin(0)
    page_setup.clearHeaderFooter()

    image_options = ImageOrPrintOptions()
    image_options.setImageType(ImageType.PNG)
    image_options.setVerticalResolution(image_resolution)
    image_options.setHorizontalResolution(image_resolution)
    image_options.setOnePagePerSheet(True)
    image_options.setOnlyArea(True)

    sheet_render = SheetRender(cell_range.getWorksheet(), image_options)
    image_stream = ByteArrayOutputStream()
    try:
        sheet_render.toImage(0, image_stream)
        image_data = image_stream.toByteArray()
        return ByteArrayInputStream(image_data)
    finally:
        image_stream.close()


def scale_cell_range(cell_range, width, height):
    # Ожидаемая ширина и высота диапазона ячеек указаны в пунктах.
    range_width = cell_range.getWidth()
    range_height = cell_range.getHeight()
    cells = cell_range.getWorksheet().getCells()

    for i in range(cell_range.getColumnCount()):
        column_index = cell_range.getFirstColumn() + i
        column_width = cells.getColumnWidth(column_index, False, CellsUnitType.POINT)
        new_column_width = column_width * width / range_width
        width_in_inches = new_column_width / 72.0
        cells.setColumnWidthInch(column_index, width_in_inches)

    for i in range(cell_range.getRowCount()):
        row_index = cell_range.getFirstRow() + i
        row_height = cells.getRowHeight(row_index, False, CellsUnitType.POINT)
        new_row_height = row_height * height / range_height
        height_in_inches = new_row_height / 72.0
        cells.setRowHeightInch(row_index, height_in_inches)


start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0
image_resolution = 96
frame_width, frame_height = 400.0, 100.0
workbook = Workbook("sample.xlsx")
try:
    worksheet = workbook.getWorksheets().get(worksheet_index)

    # Установить отображаемый размер, когда книга используется как OLE‑объект в PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.getWorksheets().setOleSize(start_row, last_row, start_column, last_column)

    cell_range = worksheet.getCells().createRange(start_row, start_column, row_count, column_count)
    # Масштабировать диапазон ячеек, чтобы соответствовать размеру кадра.
    scale_cell_range(cell_range, frame_width, frame_height)
    image_stream = create_ole_image(cell_range, image_resolution)
    try:

        # Использовать изменённую книгу.
        ole_stream = ByteArrayOutputStream()
        try:
            workbook.save(ole_stream, CellsSaveFormat.XLSX)
            workbook_data = ole_stream.toByteArray()
        finally:
            ole_stream.close()

        presentation = Presentation()
        try:
            slide = presentation.getSlides().get_Item(0)

            # Добавить OLE‑изображение в ресурсы презентации.
            image_stream.reset()
            ole_image = presentation.getImages().addImage(image_stream)

            # Создать кадр OLE‑объекта.
            data_info = OleEmbeddedDataInfo(workbook_data, "xlsx")
            ole_frame = slide.getShapes().addOleObjectFrame(10.0, 10.0, frame_width, frame_height, data_info)
            ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
            ole_frame.setObjectIcon(False)

            presentation.save("output.pptx", SaveFormat.Pptx)
        finally:
            presentation.dispose()
    finally:
        image_stream.close()
finally:
    workbook.dispose()
```

## **Заключение**

{{% alert color="info" title="Примечание" %}} 

Существует два подхода к решению проблемы изменения размера листа. Выбор подходящего зависит от конкретных требований и сценария использования. Оба подхода работают одинаково, независимо от того, создаются ли презентации из шаблона или с нуля. Кроме того, в этом решении нет ограничений на размер OLE‑рамки.

{{% /alert %}}

## **FAQ**

**Почему встроенный лист Excel меняет размер при первой активации в PowerPoint?**

Это происходит потому, что Excel пытается сохранить исходный размер окна при активации, тогда как OLE‑рамка в PowerPoint имеет свои собственные размеры. PowerPoint и Excel согласуют размер, чтобы сохранить пропорции, что может вызвать изменение масштаба.

**Можно ли полностью избежать этой проблемы с масштабированием?**

Да. Масштабируя OLE‑рамку до размеров диапазона ячеек Excel или масштабируя диапазон ячеек до желаемого размера OLE‑рамки, можно предотвратить нежелательное изменение масштаба.

**Какой метод масштабирования выбрать: масштабирование OLE‑рамки или диапазона ячеек?**

Выберите **масштабирование OLE‑рамки**, если нужно сохранить оригинальные размеры строк и столбцов Excel. Выберите **масштабирование диапазона ячеек**, если требуется фиксированный размер OLE‑рамки в презентации.

**Работают ли эти решения, если моя презентация основана на шаблоне?**

Да. Оба решения работают как для презентаций, созданных из шаблонов, так и для созданных с нуля.

**Есть ли ограничение по размеру OLE‑рамки при использовании этих методов?**

Нет. Вы можете задать любой размер OLE‑объекта, если корректно зададите коэффициент масштабирования.

**Можно ли избавиться от текста‑заполнителя «EMBEDDED OLE OBJECT» в PowerPoint?**

Да. Сделав снимок целевого диапазона ячеек Excel и установив его как изображение‑заполнитель OLE‑рамки, можно отобразить собственное превью вместо стандартного заполнителя.

## **Связанные статьи**

[Creating an Excel Chart and Embedding It in a Presentation as an OLE Object](/slides/ru/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)