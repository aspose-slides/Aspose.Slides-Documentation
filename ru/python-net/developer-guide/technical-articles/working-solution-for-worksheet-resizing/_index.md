---
title: Рабочее решение проблемы изменения размера листа
type: docs
weight: 40
url: /ru/python-net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- изображение предпросмотра
- изменение размера изображения
- Excel
- лист
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Исправьте изменение размера OLE‑объекта листа Excel в презентациях: два способа сохранить согласованность кадров объекта — масштабировать кадр или лист — в форматах PPT и PPTX."
---
{{% alert color="info" title="Note" %}}

В листы Excel, встроенные в презентацию PowerPoint как OLE‑объекты с использованием компонентов Aspose, может происходить неожиданное изменение размера после их первой активации. Такое поведение создаёт заметную визуальную разницу между OLE‑объектом до и после активации. В этой статье объясняется проблема и описываются два способа её решения.

{{% /alert %}} 

## **Фон**

В статье [Manage OLE](/slides/ru/python-net/manage-ole/) мы объяснили, как добавить OLE‑кадр в презентацию PowerPoint с помощью Aspose.Slides for Python via .NET. Чтобы решить [object preview issue](/slides/ru/python-net/object-preview-issue-when-adding-oleobjectframe/), мы назначили изображение выбранной области листа OLE‑объекту. В получившейся презентации при двойном щелчке по OLE‑кадру, отображающему изображение листа, активируется рабочая книга Excel. Пользователи могут вносить любые изменения в реальную рабочую книгу Excel, а затем возвращаться к слайду, щёлкнув вне активированной книги. Размер OLE‑кадра изменится, когда пользователь вернётся к слайду. Коэффициент изменения размера будет варьироваться в зависимости от размеров OLE‑кадра и встроенной рабочей книги Excel. 

## **Причина изменения размера**

Поскольку у рабочей книги Excel собственный размер окна, при первой активации она пытается сохранить исходный размер. С другой стороны, OLE‑кадр имеет свои собственные размеры. По данным Microsoft, когда рабочая книга Excel активируется, Excel и PowerPoint согласуют размер, чтобы сохранить правильные пропорции в процессе встраивания. Изменение размера происходит из‑за различий между размером окна Excel и размерами и положением OLE‑кадра. 

## **Рабочее решение**

Существует два возможных способа избежать эффекта изменения размера.

- Масштабировать OLE‑кадр в презентации PowerPoint, чтобы он соответствовал общей высоте и ширине выбранных строк и столбцов.  
- Оставить размер OLE‑кадра постоянным и масштабировать выбранные строки и столбцы, чтобы они вписались в него.  

### **Масштабировать размер OLE‑кадра**

Этот подход устанавливает размер OLE‑кадра, соответствующий общей высоте и ширине выбранных строк и столбцов во вложенном листе Excel.

Пример загружает существующую рабочую книгу Excel и выбирает первые 10 строк и 13 столбцов её первого листа, используя индексы, начинающиеся с нуля. [WorksheetCollection.set_ole_size](https://reference.aspose.com/cells/python-net/aspose.cells/worksheetcollection/set_ole_size/) определяет отображаемый диапазон. Предпросмотр рендерится с разрешением 96 DPI, а его пиксельные размеры преобразуются в пункты, используя 72 пункта на дюйм. [ShapeCollection.add_ole_object_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_ole_object_frame/) встраивает изменённую рабочую книгу в кадр с этими размерами. Предпросмотр назначается через [OleObjectFrame.substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/substitute_picture_format/) для замены заполнителя «EMBEDDED OLE OBJECT» в сохранённой презентации.

Помощник предварительного просмотра устанавливает [PageSetup.print_area](https://reference.aspose.com/cells/python-net/aspose.cells/pagesetup/print_area/) в выбранный диапазон и удаляет поля, верхние и нижние колонтитулы. При включённом [ImageOrPrintOptions.only_area](https://reference.aspose.com/cells/python-net/aspose.cells.rendering/imageorprintoptions/only_area/) [SheetRender.to_image](https://reference.aspose.com/cells/python-net/aspose.cells.rendering/sheetrender/to_image/) рендерит диапазон как PNG‑изображение. Помощник переустанавливает позицию потока изображения перед возвратом его для использования в презентации.

```py
import io
import aspose.cells as cells

def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.worksheet.page_setup
    page_setup.print_area = cell_range.address
    page_setup.left_margin = 0.0
    page_setup.right_margin = 0.0
    page_setup.top_margin = 0.0
    page_setup.bottom_margin = 0.0
    page_setup.clear_header_footer()

    image_options = cells.rendering.ImageOrPrintOptions()
    image_options.image_type = cells.drawing.ImageType.PNG
    image_options.vertical_resolution = image_resolution
    image_options.horizontal_resolution = image_resolution
    image_options.one_page_per_sheet = True
    image_options.only_area = True

    sheet_render = cells.rendering.SheetRender(cell_range.worksheet, image_options)
    image_data = io.BytesIO()

    sheet_render.to_image(0, image_data)
    image_data.seek(0)

    return image_data
```

Полный пример ниже объединяет вспомогательные функции с встраиванием рабочей книги и сохраняет презентацию как `output.pptx`.

```py
import io
import aspose.slides as slides
import aspose.cells as cells

def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.worksheet.page_setup
    page_setup.print_area = cell_range.address
    page_setup.left_margin = 0.0
    page_setup.right_margin = 0.0
    page_setup.top_margin = 0.0
    page_setup.bottom_margin = 0.0
    page_setup.clear_header_footer()

    image_options = cells.rendering.ImageOrPrintOptions()
    image_options.image_type = cells.drawing.ImageType.PNG
    image_options.vertical_resolution = image_resolution
    image_options.horizontal_resolution = image_resolution
    image_options.one_page_per_sheet = True
    image_options.only_area = True

    sheet_render = cells.rendering.SheetRender(cell_range.worksheet, image_options)
    image_data = io.BytesIO()

    sheet_render.to_image(0, image_data)
    image_data.seek(0)

    return image_data

start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0

image_resolution = 96

with cells.Workbook("sample.xlsx") as workbook:
    worksheet = workbook.worksheets[worksheet_index]

    # Установите отображаемый размер, когда файл рабочей книги используется как OLE‑объект в PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    image_stream = create_ole_image(cell_range, image_resolution)

    # Получите ширину и высоту OLE‑изображения в пунктах.
    with slides.Images.from_stream(image_stream) as image:
        image_width = image.width * 72 / image_resolution
        image_height = image.height * 72 / image_resolution

    # Нужно использовать изменённую рабочую книгу.
    with io.BytesIO() as ole_stream:
        workbook.save(ole_stream, cells.SaveFormat.XLSX)

        with slides.Presentation() as presentation:
            slide = presentation.slides[0]

            # Добавьте OLE‑изображение в ресурсы презентации.
            image_stream.seek(0)
            ole_image = presentation.images.add_image(image_stream)

            # Создайте кадр OLE‑объекта.
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, image_width, image_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Масштабировать размер диапазона ячеек**

Этот подход масштабирует высоты выбранных строк и ширины выбранных столбцов, чтобы они соответствовали пользовательскому размеру OLE‑кадра.

Пример загружает существующую рабочую книгу Excel и выбирает первые 10 строк и 13 столбцов её первого листа, используя индексы, начинающиеся с нуля. [WorksheetCollection.set_ole_size](https://reference.aspose.com/cells/python-net/aspose.cells/worksheetcollection/set_ole_size/) определяет отображаемый диапазон, а вспомогательная функция ниже масштабирует этот диапазон, чтобы он помещался в кадр шириной 400 пунктов и высотой 100 пунктов. После сохранения изменённой рабочей книги в поток, [ShapeCollection.add_ole_object_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_ole_object_frame/) встраивает её с указанным размером. Предпросмотр, отрендеренный с 96 DPI, назначается через [OleObjectFrame.substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/substitute_picture_format/), поэтому сохранённая презентация отображает выбранные ячейки вместо стандартного заполнителя.

Вспомогательная функция масштабирования вычисляет отдельные коэффициенты ширины и высоты для выбранного диапазона, сохраняя относительные ширины его столбцов и относительные высоты его строк. Она преобразует вычисленные размеры из пунктов в дюймы перед применением их через [Cells.set_column_width_inch](https://reference.aspose.com/cells/python-net/aspose.cells/cells/set_column_width_inch/) и [Cells.set_row_height_inch](https://reference.aspose.com/cells/python-net/aspose.cells/cells/set_row_height_inch/). Выбранный диапазон должен иметь ненулевую ширину и высоту.

```py
import aspose.cells as cells

# <param name="width">Ожидаемая ширина диапазона ячеек в пунктах.</param>
# <param name="height">Ожидаемая высота диапазона ячеек в пунктах.</param>
def scale_cell_range(cell_range, width, height):
    range_width = cell_range.width
    range_height = cell_range.height

    for i in range(cell_range.column_count):
        column_index = cell_range.first_column + i
        column_width = cell_range.worksheet.cells.get_column_width(column_index, False, cells.CellsUnitType.POINT)

        new_column_width = column_width * width / range_width
        width_in_inches = new_column_width / 72
        cell_range.worksheet.cells.set_column_width_inch(column_index, width_in_inches)

    for i in range(cell_range.row_count):
        row_index = cell_range.first_row + i
        row_height = cell_range.worksheet.cells.get_row_height(row_index, False, cells.CellsUnitType.POINT)

        new_row_height = row_height * height / range_height
        height_in_inches = new_row_height / 72
        cell_range.worksheet.cells.set_row_height_inch(row_index, height_in_inches)
```

Этот помощник предварительного просмотра рендерит изменённый диапазон, используя [SheetRender.to_image](https://reference.aspose.com/cells/python-net/aspose.cells.rendering/sheetrender/to_image/). Он ограничивает [PageSetup.print_area](https://reference.aspose.com/cells/python-net/aspose.cells/pagesetup/print_area/) этим диапазоном, удаляет поля, верхние и нижние колонтитулы и возвращает PNG‑поток, позиционированный в начале.

```py
import io
import aspose.cells as cells

def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.worksheet.page_setup
    page_setup.print_area = cell_range.address
    page_setup.left_margin = 0.0
    page_setup.right_margin = 0.0
    page_setup.top_margin = 0.0
    page_setup.bottom_margin = 0.0
    page_setup.clear_header_footer()

    image_options = cells.rendering.ImageOrPrintOptions()
    image_options.image_type = cells.drawing.ImageType.PNG
    image_options.vertical_resolution = image_resolution
    image_options.horizontal_resolution = image_resolution
    image_options.one_page_per_sheet = True
    image_options.only_area = True

    sheet_render = cells.rendering.SheetRender(cell_range.worksheet, image_options)
    image_data = io.BytesIO()

    sheet_render.to_image(0, image_data)
    image_data.seek(0)

    return image_data
```

Полный пример ниже объединяет вспомогательные функции с встраиванием рабочей книги и сохраняет презентацию как `output.pptx`.

```py
import io
import aspose.slides as slides
import aspose.cells as cells

# <param name="width">Ожидаемая ширина диапазона ячеек в пунктах.</param>
# <param name="height">Ожидаемая высота диапазона ячеек в пунктах.</param>
def scale_cell_range(cell_range, width, height):
    range_width = cell_range.width
    range_height = cell_range.height

    for i in range(cell_range.column_count):
        column_index = cell_range.first_column + i
        column_width = cell_range.worksheet.cells.get_column_width(column_index, False, cells.CellsUnitType.POINT)

        new_column_width = column_width * width / range_width
        width_in_inches = new_column_width / 72
        cell_range.worksheet.cells.set_column_width_inch(column_index, width_in_inches)

    for i in range(cell_range.row_count):
        row_index = cell_range.first_row + i
        row_height = cell_range.worksheet.cells.get_row_height(row_index, False, cells.CellsUnitType.POINT)

        new_row_height = row_height * height / range_height
        height_in_inches = new_row_height / 72
        cell_range.worksheet.cells.set_row_height_inch(row_index, height_in_inches)

def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.worksheet.page_setup
    page_setup.print_area = cell_range.address
    page_setup.left_margin = 0.0
    page_setup.right_margin = 0.0
    page_setup.top_margin = 0.0
    page_setup.bottom_margin = 0.0
    page_setup.clear_header_footer()

    image_options = cells.rendering.ImageOrPrintOptions()
    image_options.image_type = cells.drawing.ImageType.PNG
    image_options.vertical_resolution = image_resolution
    image_options.horizontal_resolution = image_resolution
    image_options.one_page_per_sheet = True
    image_options.only_area = True

    sheet_render = cells.rendering.SheetRender(cell_range.worksheet, image_options)
    image_data = io.BytesIO()

    sheet_render.to_image(0, image_data)
    image_data.seek(0)

    return image_data

start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0

image_resolution = 96
frame_width, frame_height = 400.0, 100.0

with cells.Workbook("sample.xlsx") as workbook:
    worksheet = workbook.worksheets[worksheet_index]

    # Установите отображаемый размер, когда файл рабочей книги используется как OLE-объект в PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    # Масштабировать диапазон ячеек, чтобы он соответствовал размеру кадра.
    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    scale_cell_range(cell_range, frame_width, frame_height)

    image_stream = create_ole_image(cell_range, image_resolution)

    # Нужно использовать изменённую рабочую книгу.
    with io.BytesIO() as ole_stream:
        workbook.save(ole_stream, cells.SaveFormat.XLSX)

        with slides.Presentation() as presentation:
            slide = presentation.slides[0]

            # Добавьте OLE-изображение в ресурсы презентации.
            ole_image = presentation.images.add_image(image_stream)

            # Создайте кадр OLE-объекта.
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, frame_width, frame_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Заключение**

{{% alert color="info" title="Note" %}}

Существует два подхода к исправлению проблемы изменения размера листа. Выберите подход, который лучше всего соответствует вашим требованиям и сценариям использования. Оба подхода работают одинаково, независимо от того, создаются ли презентации из шаблона или с нуля. Кроме того, в этом решении нет ограничений по размеру OLE‑кадра.

{{% /alert %}}

## **Вопросы и ответы**

**Почему при первой активации встроенного листа Excel его размер меняется в PowerPoint?**

Это происходит потому, что Excel пытается сохранить исходный размер окна при активации, тогда как OLE‑кадр в PowerPoint имеет собственные размеры. PowerPoint и Excel согласуют размер, чтобы сохранить соотношение сторон, что может вызвать изменение размера.

**Можно ли полностью предотвратить эту проблему с изменением размера?**

Да. Масштабируя OLE‑кадр так, чтобы он соответствовал размеру диапазона ячеек Excel, либо масштабируя диапазон ячеек до желаемого размера OLE‑кадра, вы можете избежать нежелательного изменения размера.

**Какой метод масштабирования следует использовать: масштабирование OLE‑кадра или масштабирование диапазона ячеек?**

Выберите **OLE frame scaling**, если хотите сохранить оригинальные размеры строк и столбцов Excel. Выберите **cell range scaling**, если вам нужен фиксированный размер OLE‑кадра в презентации.

**Будут ли эти решения работать, если моя презентация основана на шаблоне?**

Да. Оба решения работают как для презентаций, созданных из шаблонов, так и для созданных с нуля.

**Есть ли ограничение по размеру OLE‑кадра при использовании этих методов?**

Нет. Вы можете задать любой размер OLE‑объекта, при условии корректной настройки масштаба.

**Можно ли избавиться от текста‑заполнителя «EMBEDDED OLE OBJECT» в PowerPoint?**

Да. Сделав снимок целевого диапазона ячеек Excel и установив его в качестве изображения‑заполнителя OLE‑кадра, вы можете отображать пользовательское изображение вместо стандартного заполнителя.