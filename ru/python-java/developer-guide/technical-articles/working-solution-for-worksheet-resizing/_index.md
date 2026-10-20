---
title: Рабочее решение для изменения размера листов
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
description: "Исправьте изменение размера OLE листа Excel в презентациях: два способа сохранить согласованность кадров объектов — масштабировать кадр или лист — для форматов PPT и PPTX."
---
{{% alert color="info" title="Примечание" %}}

Excel‑листы, внедрённые в презентацию PowerPoint в виде OLE‑объектов с помощью компонентов Aspose, могут неожиданно изменять размер после первой активации. Такое поведение создаёт заметную визуальную разницу между OLE‑объектом до и после активации. В этой статье описывается проблема и два способа её решения.

{{% /alert %}}

## **Предыстория**

В статье [Управление OLE](/slides/ru/python-java/manage-ole/) мы объяснили, как добавить OLE‑кадр в презентацию PowerPoint с помощью Aspose.Slides for Python via Java. Чтобы решить [проблему предварительного просмотра объекта](/slides/ru/python-java/object-preview-issue-when-adding-oleobjectframe/), мы присвоили изображение выбранной области листа OLE‑объекту. В полученной презентации при двойном щелчке по OLE‑кадру, отображающему изображение листа, активируется рабочая книга Excel. Пользователи могут вносить любые изменения в реальную рабочую книгу Excel, а затем возвращаться к слайду, щёлкнув вне активированной книги. Размер OLE‑кадра изменится, когда пользователь вернётся к слайду. Коэффициент изменения размера будет зависеть от размеров OLE‑кадра и внедрённой рабочей книги Excel.

## **Причина изменения размера**

Поскольку у рабочей книги Excel собственный размер окна, при первой активации она пытается сохранить свой исходный размер. С другой стороны, OLE‑кадр имеет собственные размеры. По данным Microsoft, когда активируется рабочая книга Excel, Excel и PowerPoint согласовывают размер, чтобы сохранить правильные пропорции в процессе внедрения. Изменение размера происходит из‑за различий между размером окна Excel и размером и положением OLE‑кадра.

## **Рабочее решение**

Существует два возможных способа избежать эффекта изменения размера.

- Масштабировать OLE‑кадр в презентации PowerPoint так, чтобы он соответствовал общей высоте и ширине выбранных строк и столбцов.  
- Сохранить постоянный размер OLE‑кадра и масштабировать выбранные строки и столбцы, чтобы они поместились в нём.

### **Масштабировать размер OLE‑кадра**

Этот подход задаёт размер OLE‑кадра, соответствующий общей высоте и ширине выбранных строк и столбцов во внедрённом листе Excel.

Пример загружает существующую рабочую книгу Excel и выбирает первые 10 строк и 13 столбцов её первого листа, используя индексы, начинающиеся с нуля. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/python-java/asposecells.api/worksheetcollection/#setolesize) определяет отображаемый диапазон. Предпросмотр рендерится с плотностью 96 DPI, а его пиксельные размеры преобразуются в пункты с учётом 72 пунктов на дюйм. [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addOleObjectFrame) внедряет изменённую рабочую книгу в кадр с этими размерами. Предпросмотр задаётся через [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) для замены заполнителя «EMBEDDED OLE OBJECT» в сохранённой презентации.

Помощник предварительного просмотра устанавливает [PageSetup.setPrintArea](https://reference.aspose.com/cells/python-java/asposecells.api/pagesetup/#printarea) на выбранный диапазон и удаляет поля, колонтитулы и нижние колонтитулы. При включённом [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/python-java/asposecells.api/imageorprintoptions/#onlyarea) [SheetRender.toImage](https://reference.aspose.com/cells/python-java/asposecells.api/sheetrender/#toimage) рендерит диапазон как PNG‑изображение. Помощник возвращает новый входной поток, содержащий PNG‑изображение, позиционированный в начале для использования в презентации.

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

    # Установить отображаемый размер, когда рабочая книга используется как OLE‑объект в PowerPoint.
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

        # Использовать изменённую рабочую книгу.
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

### **Масштабировать размер диапазона ячеек**

Этот подход масштабирует высоту выбранных строк и ширину выбранных столбцов, чтобы они соответствовали пользовательскому размеру OLE‑кадра.

Пример загружает существующую рабочую книгу Excel и выбирает первые 10 строк и 13 столбцов её первого листа, используя индексы, начинающиеся с нуля. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/python-java/asposecells.api/worksheetcollection/#setolesize) определяет отображаемый диапазон, а вспомогательная функция scale_cell_range масштабирует этот диапазон до кадра шириной 400 пунктов и высотой 100 пунктов. После сохранения изменённой рабочей книги в поток, [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addOleObjectFrame) внедряет её с указанными размерами. Предпросмотр, отрисованный с плотностью 96 DPI, задаётся через [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat), поэтому сохранённая презентация показывает выбранные ячейки вместо стандартного заполнителя.

Вспомогательная функция масштабирования вычисляет отдельные коэффициенты ширины и высоты для выбранного диапазона, сохраняя относительные ширины столбцов и относительные высоты строк. Она преобразует полученные размеры из пунктов в дюймы перед применением их через [Cells.setColumnWidthInch](https://reference.aspose.com/cells/python-java/asposecells.api/cells/#setcolumnwidthinch) и [Cells.setRowHeightInch](https://reference.aspose.com/cells/python-java/asposecells.api/cells/#setrowheightinch). Выбранный диапазон должен иметь ненулевую ширину и высоту.

Этот вспомогательный элемент предварительного просмотра рендерит изменённый диапазон с помощью [SheetRender.toImage](https://reference.aspose.com/cells/python-java/asposecells.api/sheetrender/#toimage). Он ограничивает [PageSetup.setPrintArea](https://reference.aspose.com/cells/python-java/asposecells.api/pagesetup/#printarea) этим диапазоном, удаляет поля, колонтитулы и нижние колонтитулы и возвращает PNG‑поток, позиционированный в начале.

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

    # Установить отображаемый размер, когда рабочая книга используется как OLE‑объект в PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.getWorksheets().setOleSize(start_row, last_row, start_column, last_column)

    cell_range = worksheet.getCells().createRange(start_row, start_column, row_count, column_count)
    # Масштабировать диапазон ячеек под размер кадра.
    scale_cell_range(cell_range, frame_width, frame_height)
    image_stream = create_ole_image(cell_range, image_resolution)
    try:

        # Использовать изменённую рабочую книгу.
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

Существует два подхода для устранения проблемы изменения размера листа. Выберите тот, который лучше соответствует вашим требованиям и сценариям использования. Оба подхода работают одинаково, независимо от того, создаются ли презентации из шаблона или с нуля. Кроме того, в этом решении отсутствуют ограничения по размеру OLE‑кадра.

{{% /alert %}}

## **Часто задаваемые вопросы**

**Почему внедрённый лист Excel меняет размер при первой активации в PowerPoint?**

Это происходит потому, что Excel пытается сохранить исходный размер окна при активации, тогда как OLE‑кадр в PowerPoint имеет собственные размеры. PowerPoint и Excel согласовывают размер, чтобы сохранить соотношение сторон, что может привести к изменению размеров.

**Можно ли полностью предотвратить эту проблему изменения размера?**

Да. Масштабируя OLE‑кадр под размер диапазона ячеек Excel или масштабируя диапазон ячеек под нужный размер OLE‑кадра, можно избежать нежелательного изменения размеров.

**Какой метод масштабирования использовать: масштабирование OLE‑кадра или диапазона ячеек?**

Выберите **масштабирование OLE‑кадра**, если нужно сохранить исходные размеры строк и столбцов Excel. Выберите **масштабирование диапазона ячеек**, если требуется фиксированный размер OLE‑кадра в презентации.

**Будут ли эти решения работать, если моя презентация основана на шаблоне?**

Да. Оба решения работают как для презентаций, созданных из шаблонов, так и для созданных с нуля.

**Существует ли ограничение размера OLE‑кадра при использовании этих методов?**

Нет. Вы можете задать любой размер OLE‑кадра, если правильно установите масштаб.

**Можно ли избавиться от текста‑заполнителя «EMBEDDED OLE OBJECT» в PowerPoint?**

Да. Сделав снимок целевого диапазона ячеек Excel и установив его в качестве изображения‑заполнителя OLE‑кадра, можно отобразить собственное изображение‑предпросмотр вместо стандартного заполнителя.

## **Связанные статьи**

[Создание диаграммы Excel и встраивание её в презентацию как OLE‑объект](/slides/ru/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Автоматическое обновление OLE‑объектов с помощью надстройки MS PowerPoint](/slides/ru/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)