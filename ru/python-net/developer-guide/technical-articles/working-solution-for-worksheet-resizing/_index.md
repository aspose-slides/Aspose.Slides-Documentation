---
title: Рабочее решение проблемы изменения размеров листа
type: docs
weight: 40
url: /ru/python-net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- изображение предварительного просмотра
- изменение размера изображения
- Excel
- лист
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Исправьте изменение размера OLE листа Excel в презентациях: два способа поддерживать согласованность рамок объектов — масштабировать рамку или лист — в форматах PPT и PPTX."
---

{{% alert color="primary" %}} 
Было замечено, что листы Excel, встроенные как OLE‑объекты в презентацию PowerPoint через компоненты Aspose, изменяют размер до неопределённого масштаба после первой активации. Такое поведение создает заметную визуальную разницу в презентации между состоянием OLE‑объекта до и после активации. Мы подробно исследовали эту проблему и предложили решение, описанное в этой статье.
{{% /alert %}} 

## **Предыстория**

В статье [Manage OLE](/slides/ru/python-net/manage-ole/) мы объяснили, как добавить OLE‑кадр в презентацию PowerPoint с помощью Aspose.Slides for Python via .NET. Чтобы решить проблему [object preview issue](/slides/ru/python-net/object-preview-issue-when-adding-oleobjectframe/), мы присвоили изображение выбранной области листа OLE‑объекта. В готовой презентации, когда вы дважды щёлкаете по OLE‑кадру, отображающему изображение листа, активируется рабочая книга Excel. Пользователи могут вносить любые необходимые изменения в реальную рабочую книгу Excel, а затем вернуться к слайду, щёлкнув за пределами активированной рабочей книги. Размер OLE‑кадра изменится, когда пользователь вернётся к слайду. Коэффициент изменения размера будет зависеть от размеров OLE‑кадра и встроенной рабочей книги Excel.

## **Причина изменения размера**

Поскольку у рабочей книги Excel собственный размер окна, при первой активации она пытается сохранить свой исходный размер. С другой стороны, OLE‑кадр имеет свой размер. По данным Microsoft, когда рабочая книга Excel активируется, Excel и PowerPoint согласовывают размер, чтобы обеспечить сохранение правильных пропорций в процессе встраивания. Изменение размера происходит из‑за различий между размером окна Excel и размером и положением OLE‑кадра.

## **Рабочее решение**

Существует два возможных решения, позволяющих избежать эффекта изменения размера.

- Изменить масштаб размера OLE‑кадра в презентации PowerPoint так, чтобы он соответствовал высоте и ширине требуемого количества строк и столбцов в OLE‑кадре.
- Сохранить постоянный размер OLE‑кадра и масштабировать размер участвующих строк и столбцов, чтобы они вписались в выбранный размер OLE‑кадра.

### **Масштабировать размер OLE‑кадра**

В этом подходе мы узнаем, как установить размер OLE‑кадра встроенной рабочей книги Excel так, чтобы он соответствовал суммарному размеру участвующих строк и столбцов в листе Excel.

Предположим, у нас есть шаблон листа Excel, который нужно добавить в презентацию в виде OLE‑кадра. В этом случае размер OLE‑кадра сначала будет рассчитан на основе суммарных высот строк и ширин столбцов участвующих в рабочей книге. Затем мы установим размер OLE‑кадра в это вычисленное значение. Чтобы избежать красного сообщения «EMBEDDED OLE OBJECT» для OLE‑кадра в PowerPoint, мы также создадим изображение нужных участков строк и столбцов в рабочей книге и зададим его как изображение OLE‑кадра.
```py
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

```py
start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0

image_resolution = 96

with cells.Workbook("sample.xlsx") as workbook:
    worksheet = workbook.worksheets[worksheet_index]

    # Установить отображаемый размер, когда файл рабочей книги используется как OLE-объект в PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    image_stream = create_ole_image(cell_range, image_resolution)

    # Получить ширину и высоту OLE-изображения в пунктах.
    with slides.Images.from_stream(image_stream) as image:
        image_width = image.width * 72 / image_resolution
        image_height = image.height * 72 / image_resolution

    # Нужно использовать изменённую рабочую книгу.
    with io.BytesIO() as ole_stream:
        workbook.save(ole_stream, cells.SaveFormat.XLSX)

        with slides.Presentation() as presentation:
            slide = presentation.slides[0]

            # Добавить OLE-изображение в ресурсы презентации.
            image_stream.seek(0)
            ole_image = presentation.images.add_image(image_stream)

            # Создать кадр OLE-объекта.
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, image_width, image_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


### **Масштабировать размер диапазона ячеек**

В этом подходе мы узнаем, как масштабировать высоту участвующих строк и ширину участвующих столбцов, чтобы они соответствовали пользовательскому размеру OLE‑кадра.

Предположим, у нас есть шаблон листа Excel, который нужно добавить в презентацию в виде OLE‑кадра. В этом случае мы установим размер OLE‑кадра и масштабируем размеры строк и столбцов, участвующих в области OLE‑кадра. Затем сохраним рабочую книгу в поток, чтобы применить изменения, и преобразуем её в массив байтов для добавления в OLE‑кадр. Чтобы избежать красного сообщения «EMBEDDED OLE OBJECT» для OLE‑кадра в PowerPoint, мы также создадим изображение нужных участков строк и столбцов в рабочей книге и зададим его как изображение OLE‑кадра.
```py
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

```py
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

```py
start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0

image_resolution = 96
frame_width, frame_height = 400.0, 100.0

with cells.Workbook("sample.xlsx") as workbook:
    worksheet = workbook.worksheets[worksheet_index]

    # Установить отображаемый размер, когда файл рабочей книги используется как OLE-объект в PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    # Масштабировать диапазон ячеек, чтобы он вписался в размер кадра.
    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    scale_cell_range(cell_range, frame_width, frame_height)

    image_stream = create_ole_image(cell_range, image_resolution)

    # Нужно использовать изменённую рабочую книгу.
    with io.BytesIO() as ole_stream:
        workbook.save(ole_stream, cells.SaveFormat.XLSX)

        with slides.Presentation() as presentation:
            slide = presentation.slides[0]

            # Добавить OLE-изображение в ресурсы презентации.
            ole_image = presentation.images.add_image(image_stream)

            # Создать кадр OLE-объекта.
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, frame_width, frame_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Заключение**
{{% alert color="primary" %}}
Существует два подхода для устранения проблемы изменения размера листа. Выбор подходящего подхода зависит от конкретных требований и сценария использования. Оба подхода работают одинаково, независимо от того, создаются ли презентации из шаблона или с нуля. Кроме того, в этом решении нет ограничения на размер OLE‑кадра.
{{% /alert %}}