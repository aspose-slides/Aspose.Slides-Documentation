---
title: Solución práctica para el redimensionamiento de la hoja de cálculo
type: docs
weight: 40
url: /es/python-net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- imagen de vista previa
- redimensionamiento de imagen
- Excel
- hoja de cálculo
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Soluciona el redimensionamiento de OLE de hojas de cálculo de Excel en presentaciones: dos formas de mantener los marcos de objetos consistentes—escalar el marco o la hoja—en los formatos PPT y PPTX."
---

{{% alert color="primary" %}} 

Se ha observado que las hojas de cálculo de Excel incrustadas como objetos OLE en una presentación de PowerPoint a través de los componentes Aspose se redimensionan a una escala no identificada después de la primera activación. Este comportamiento crea una diferencia visual notable en la presentación entre los estados previo y posterior a la activación del objeto OLE. Hemos investigado este problema en detalle y proporcionado una solución, que se cubre en este artículo.

{{% /alert %}} 

## **Antecedentes**

En el artículo [Manage OLE](/slides/es/python-net/manage-ole/), explicamos cómo agregar un marco OLE a una presentación de PowerPoint usando Aspose.Slides for Python a través de .NET. Para abordar el [object preview issue](/slides/es/python-net/object-preview-issue-when-adding-oleobjectframe/), asignamos una imagen del área de la hoja de cálculo seleccionada al marco del objeto OLE. En la presentación resultante, cuando haces doble clic en el marco del objeto OLE que muestra la imagen de la hoja de cálculo, se activa el libro de Excel. Los usuarios finales pueden realizar cualquier cambio deseado en el libro de Excel real y luego volver a la diapositiva haciendo clic fuera del libro de Excel activado. El tamaño del marco del objeto OLE cambiará cuando el usuario regrese a la diapositiva. El factor de redimensionamiento variará según el tamaño del marco del objeto OLE y el libro de Excel incrustado. 

## **Causa del redimensionamiento**

Como el libro de Excel tiene su propio tamaño de ventana, intenta conservar su tamaño original al activarse por primera vez. Por otro lado, el marco del objeto OLE tiene su propio tamaño. Según Microsoft, cuando se activa el libro de Excel, Excel y PowerPoint negocian el tamaño para asegurarse de que mantenga las proporciones correctas como parte del proceso de incrustación. El redimensionamiento ocurre en función de las diferencias entre el tamaño de la ventana de Excel y el tamaño y posición del marco del objeto OLE. 

## **Solución práctica**

Existen dos soluciones posibles para evitar el efecto de redimensionamiento.

- Escalar el tamaño del marco OLE en la presentación de PowerPoint para que coincida con la altura y el ancho del número deseado de filas y columnas en el marco OLE.  
- Mantener el tamaño del marco OLE constante y escalar el tamaño de las filas y columnas participantes para que se ajusten al tamaño seleccionado del marco OLE.  

### **Escalar el tamaño del marco OLE**

En este enfoque, aprenderemos cómo establecer el tamaño del marco OLE del libro de Excel incrustado para que coincida con el tamaño acumulado de las filas y columnas participantes en la hoja de cálculo de Excel.

Supongamos que tenemos una hoja de Excel plantilla y queremos agregarla a una presentación como un marco OLE. En este escenario, el tamaño del marco del objeto OLE se calculará primero en función de la altura acumulada de las filas y el ancho acumulado de las columnas de las filas y columnas participantes en el libro. Luego, estableceremos el tamaño del marco OLE a este valor calculado. Para evitar el mensaje rojo \"EMBEDDED OLE OBJECT\" del marco OLE en PowerPoint, también capturaremos una imagen de las porciones deseadas de las filas y columnas en el libro y la estableceremos como imagen del marco OLE.  
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

    # Establecer el tamaño mostrado cuando el archivo del libro de trabajo se usa como objeto OLE en PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    image_stream = create_ole_image(cell_range, image_resolution)

    # Obtener el ancho y la altura de la imagen OLE en puntos.
    with slides.Images.from_stream(image_stream) as image:
        image_width = image.width * 72 / image_resolution
        image_height = image.height * 72 / image_resolution

    # Necesitamos usar el libro de trabajo modificado.
    with io.BytesIO() as ole_stream:
        workbook.save(ole_stream, cells.SaveFormat.XLSX)

        with slides.Presentation() as presentation:
            slide = presentation.slides[0]

            # Agregar la imagen OLE a los recursos de la presentación.
            image_stream.seek(0)
            ole_image = presentation.images.add_image(image_stream)

            # Crear el marco del objeto OLE.
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, image_width, image_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


### **Escalar el tamaño del rango de celdas**

En este enfoque, aprenderemos cómo escalar las alturas de las filas participantes y el ancho de las columnas participantes para que coincidan con un tamaño de marco OLE personalizado.

Supongamos que tenemos una hoja de Excel plantilla y queremos agregarla a una presentación como un marco OLE. En este escenario, estableceremos el tamaño del marco OLE y escalaremos el tamaño de las filas y columnas que participan en el área del marco OLE. Luego guardaremos el libro en un flujo para aplicar los cambios y lo convertiremos en una matriz de bytes para agregarlo al marco OLE. Para evitar el mensaje rojo \"EMBEDDED OLE OBJECT\" del marco OLE en PowerPoint, también capturaremos una imagen de las porciones deseadas de las filas y columnas en el libro y la estableceremos como imagen del marco OLE.  
```py
# <param name="width">El ancho esperado del rango de celdas en puntos.</param>
# <param name="height">La altura esperada del rango de celdas en puntos.</param>
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

    # Establecer el tamaño mostrado cuando el archivo del libro de trabajo se usa como objeto OLE en PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    # Escalar el rango de celdas para que se ajuste al tamaño del marco.
    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    scale_cell_range(cell_range, frame_width, frame_height)

    image_stream = create_ole_image(cell_range, image_resolution)

    # Necesitamos usar el libro de trabajo modificado.
    with io.BytesIO() as ole_stream:
        workbook.save(ole_stream, cells.SaveFormat.XLSX)

        with slides.Presentation() as presentation:
            slide = presentation.slides[0]

            # Agregar la imagen OLE a los recursos de la presentación.
            ole_image = presentation.images.add_image(image_stream)

            # Crear el marco del objeto OLE.
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, frame_width, frame_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Conclusión**

{{% alert color="primary" %}}

Existen dos enfoques para solucionar el problema de redimensionamiento de la hoja de cálculo. La selección del enfoque apropiado depende de los requisitos específicos y del caso de uso. Ambos enfoques funcionan de la misma manera, ya sea que las presentaciones se creen a partir de una plantilla o desde cero. Además, no hay límite en el tamaño del marco del objeto OLE en esta solución.

{{% /alert %}}