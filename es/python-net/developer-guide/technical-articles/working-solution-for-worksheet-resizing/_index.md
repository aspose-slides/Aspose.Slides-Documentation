---
title: Solución práctica para el redimensionado de la hoja de cálculo
type: docs
weight: 40
url: /es/python-net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- imagen de vista previa
- redimensionado de imagen
- Excel
- hoja de cálculo
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Soluciona el redimensionado del OLE de la hoja de cálculo de Excel en presentaciones: dos formas de mantener los marcos de objeto consistentes—escalar el marco o la hoja—en los formatos PPT y PPTX."
---
{{% alert color="info" title="Note" %}}
Las hojas de cálculo de Excel incrustadas como objetos OLE en una presentación de PowerPoint mediante componentes Aspose pueden cambiar de tamaño de forma inesperada tras su primera activación. Este comportamiento crea una diferencia visual notable entre el objeto OLE antes y después de la activación. Este artículo explica el problema y describe dos formas de solucionarlo.
{{% /alert %}} 

## **Antecedentes**

En el artículo [Administrar OLE](/slides/es/python-net/manage-ole/), explicamos cómo añadir un marco OLE a una presentación de PowerPoint usando Aspose.Slides para Python a través de .NET. Para abordar el [problema de vista previa del objeto](/slides/es/python-net/object-preview-issue-when-adding-oleobjectframe/), asignamos una imagen del área seleccionada de la hoja de cálculo al marco del objeto OLE. En la presentación resultante, cuando haces doble clic en el marco del objeto OLE que muestra la imagen de la hoja, el libro de Excel se activa. Los usuarios pueden realizar los cambios que deseen en el libro de Excel real y luego volver a la diapositiva haciendo clic fuera del libro de Excel activado. El tamaño del marco del objeto OLE cambiará cuando el usuario vuelva a la diapositiva. El factor de redimensionado variará según el tamaño del marco del objeto OLE y del libro de Excel incrustado.

## **Causa del redimensionado**

Dado que el libro de Excel tiene su propio tamaño de ventana, intenta conservar su tamaño original al activarse por primera vez. Por otro lado, el marco del objeto OLE tiene su propio tamaño. Según Microsoft, cuando el libro de Excel se activa, Excel y PowerPoint negocian el tamaño para garantizar que mantenga las proporciones correctas como parte del proceso de incrustación. El redimensionado ocurre en función de las diferencias entre el tamaño de la ventana de Excel y el tamaño y posición del marco del objeto OLE.

## **Solución práctica**

Existen dos soluciones posibles para evitar el efecto de redimensionado.

- Escalar el marco OLE en la presentación de PowerPoint para que coincida con la altura y anchura total de las filas y columnas seleccionadas.
- Mantener constante el tamaño del marco OLE y escalar las filas y columnas seleccionadas para que encajen dentro de él.

### **Escalar el tamaño del marco OLE**

Este enfoque establece el tamaño del marco OLE para que coincida con la altura y anchura total de las filas y columnas seleccionadas en la hoja de cálculo de Excel incrustada.

El ejemplo carga un libro de Excel existente y selecciona las primeras 10 filas y 13 columnas de su primera hoja de cálculo mediante índices basados en cero. [WorksheetCollection.set_ole_size](https://reference.aspose.com/cells/python-net/aspose.cells/worksheetcollection/set_ole_size/) define el rango mostrado. La vista previa se renderiza a 96 DPI y sus dimensiones en píxeles se convierten a puntos usando 72 puntos por pulgada. [ShapeCollection.add_ole_object_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_ole_object_frame/) incrusta el libro modificado en un marco con esas dimensiones. La vista previa se asigna mediante [OleObjectFrame.substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/substitute_picture_format/) para sustituir el marcador de posición "EMBEDDED OLE OBJECT" en la presentación guardada.

El ayudante de vista previa establece [PageSetup.print_area](https://reference.aspose.com/cells/python-net/aspose.cells/pagesetup/print_area/) al rango seleccionado y elimina márgenes, encabezados y pies de página. Con [ImageOrPrintOptions.only_area](https://reference.aspose.com/cells/python-net/aspose.cells.rendering/imageorprintoptions/only_area/) habilitado, [SheetRender.to_image](https://reference.aspose.com/cells/python-net/aspose.cells.rendering/sheetrender/to_image/) renderiza el rango como una imagen PNG. El ayudante retrocede el flujo de la imagen antes de devolverlo para su uso en la presentación.

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

El ejemplo completo a continuación combina los ayudantes con la incrustación del libro y guarda la presentación como `output.pptx`.

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

    # Establecer el tamaño visible cuando el archivo del libro de trabajo se usa como objeto OLE en PowerPoint.
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

            # Añadir la imagen OLE a los recursos de la presentación.
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

Este enfoque escala las alturas de las filas seleccionadas y las anchuras de las columnas seleccionadas para que coincidan con un tamaño de marco OLE personalizado.

El ejemplo carga un libro de Excel existente y selecciona las primeras 10 filas y 13 columnas de su primera hoja de cálculo mediante índices basados en cero. [WorksheetCollection.set_ole_size](https://reference.aspose.com/cells/python-net/aspose.cells/worksheetcollection/set_ole_size/) define el rango mostrado, y el ayudante a continuación escala ese rango para ajustarse a un marco de 400 puntos de ancho y 100 puntos de alto. Después de guardar el libro modificado en un flujo, [ShapeCollection.add_ole_object_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_ole_object_frame/) lo incrusta con el tamaño especificado. Una vista previa renderizada a 96 DPI se asigna mediante [OleObjectFrame.substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/substitute_picture_format/), de modo que la presentación guardada muestra las celdas seleccionadas en lugar del marcador de posición predeterminado.

El ayudante de escalado calcula ratios de ancho y alto separados para el rango seleccionado, preservando las anchuras relativas de sus columnas y las alturas relativas de sus filas. Convierte las dimensiones calculadas de puntos a pulgadas antes de aplicarlas con [Cells.set_column_width_inch](https://reference.aspose.com/cells/python-net/aspose.cells/cells/set_column_width_inch/) y [Cells.set_row_height_inch](https://reference.aspose.com/cells/python-net/aspose.cells/cells/set_row_height_inch/). El rango seleccionado debe tener ancho y alto diferentes de cero.

```py
import aspose.cells as cells

# <param name="width">La anchura esperada del rango de celdas en puntos.</param>
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

Este ayudante de vista previa renderiza el rango redimensionado utilizando [SheetRender.to_image](https://reference.aspose.com/cells/python-net/aspose.cells.rendering/sheetrender/to_image/). Limita [PageSetup.print_area](https://reference.aspose.com/cells/python-net/aspose.cells/pagesetup/print_area/) a ese rango, elimina márgenes, encabezados y pies de página, y devuelve un flujo PNG situado al principio.

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

El ejemplo completo a continuación combina los ayudantes con la incrustación del libro y guarda la presentación como `output.pptx`.

```py
import io
import aspose.slides as slides
import aspose.cells as cells

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

    # Establecer el tamaño visible cuando el archivo del libro de trabajo se usa como objeto OLE en PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    # Escalar el rango de celdas para que encaje en el tamaño del marco.
    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    scale_cell_range(cell_range, frame_width, frame_height)

    image_stream = create_ole_image(cell_range, image_resolution)

    # Necesitamos usar el libro de trabajo modificado.
    with io.BytesIO() as ole_stream:
        workbook.save(ole_stream, cells.SaveFormat.XLSX)

        with slides.Presentation() as presentation:
            slide = presentation.slides[0]

            # Añadir la imagen OLE a los recursos de la presentación.
            ole_image = presentation.images.add_image(image_stream)

            # Crear el marco del objeto OLE.
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, frame_width, frame_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Conclusión**

{{% alert color="info" title="Note" %}}
Existen dos enfoques para resolver el problema de cambio de tamaño de la hoja de cálculo. Elige el enfoque que mejor se adapte a tus requisitos y caso de uso. Ambos enfoques funcionan de la misma manera, tanto si las presentaciones se crean a partir de una plantilla como desde cero. Además, no hay límite en el tamaño del marco del objeto OLE en esta solución.
{{% /alert %}}

## **Preguntas frecuentes**

**¿Por qué una hoja de Excel incrustada cambia de tamaño al activarse por primera vez en PowerPoint?**

Ocurre porque Excel intenta conservar el tamaño original de la ventana al activarse, mientras que el marco del objeto OLE en PowerPoint tiene sus propias dimensiones. PowerPoint y Excel negocian el tamaño para mantener la relación de aspecto, lo que puede provocar el redimensionado.

**¿Es posible evitar este problema de redimensionado por completo?**

Sí. Escalando el marco OLE para que se ajuste al tamaño del rango de celdas de Excel o escalando el rango de celdas para que se ajuste al tamaño deseado del marco OLE, puedes evitar el redimensionado no deseado.

**¿Qué método de escalado debo usar, escalar el marco OLE o escalar el rango de celdas?**

Selecciona **OLE frame scaling** si deseas mantener los tamaños originales de filas y columnas de Excel. Selecciona **cell range scaling** si deseas un tamaño fijo para el marco OLE en tu presentación.

**¿Funcionarán estas soluciones si mi presentación se basa en una plantilla?**

Sí. Ambas soluciones funcionan para presentaciones creadas a partir de plantillas y desde cero.

**¿Existe un límite en el tamaño del marco OLE al usar estos métodos?**

No. Puedes establecer el marco del objeto OLE en cualquier tamaño siempre que ajustes la escala adecuadamente.

**¿Hay alguna forma de evitar el texto del marcador de posición "EMBEDDED OLE OBJECT" en PowerPoint?**

Sí. Capturando una instantánea del rango de celdas de Excel objetivo y estableciéndola como la imagen del marcador de posición del marco OLE, puedes mostrar una imagen de vista previa personalizada en lugar del marcador de posición predeterminado.