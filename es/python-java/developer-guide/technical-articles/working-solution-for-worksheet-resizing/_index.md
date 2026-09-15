---
title: Solución práctica para el redimensionado de hojas de cálculo
type: docs
weight: 20
url: /es/python-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- imagen de vista previa
- redimensionado de imagen
- Excel
- hoja de cálculo
- PowerPoint
- presentación
- Python
- Java
- Aspose.Slides
description: "Corrige el redimensionado OLE de hojas de cálculo de Excel en presentaciones: dos maneras de mantener los marcos de objetos coherentes—escalar el marco o la hoja—en los formatos PPT y PPTX."
---
{{% alert color="info" title="Note" %}}

Se ha observado que las hojas de cálculo de Excel incrustadas como objetos OLE en una presentación de PowerPoint a través de los componentes Aspose se redimensionan a una escala no especificada después de la primera activación. Este comportamiento crea una diferencia visual notable en la presentación entre los estados antes y después de la activación del objeto OLE. Hemos investigado este problema en detalle y proporcionado una solución, que se describe en este artículo.

{{% /alert %}}

## **Antecedentes**

En el artículo [Manage OLE](/slides/es/python-java/manage-ole/), explicamos cómo añadir un marco OLE a una presentación de PowerPoint usando Aspose.Slides for Python via Java. Para abordar el [object preview issue](/slides/es/python-java/object-preview-issue-when-adding-oleobjectframe/), asignamos una imagen del área de la hoja de cálculo seleccionada al marco del objeto OLE. En la presentación resultante, cuando haces doble clic en el marco del objeto OLE que muestra la imagen de la hoja, se activa el libro de Excel. Los usuarios finales pueden realizar cualquier cambio deseado en el libro de Excel real y luego volver a la diapositiva haciendo clic fuera del libro de Excel activado. El tamaño del marco del objeto OLE cambiará cuando el usuario vuelva a la diapositiva. El factor de redimensionado variará según el tamaño del marco del objeto OLE y del libro de Excel incrustado.

## **Causa del redimensionado**

Dado que el libro de Excel tiene su propio tamaño de ventana, intenta conservar su tamaño original al activarse por primera vez. Por otro lado, el marco del objeto OLE tiene su propio tamaño. Según Microsoft, cuando se activa el libro de Excel, Excel y PowerPoint negocian el tamaño para garantizar que mantenga las proporciones correctas como parte del proceso de incrustación. El redimensionado ocurre en función de las diferencias entre el tamaño de la ventana de Excel y el tamaño y posición del marco del objeto OLE.

## **Solución funcional**

Existen dos posibles soluciones para evitar el efecto de redimensionado.

- Escalar el tamaño del marco OLE en la presentación de PowerPoint para que coincida con la altura y anchura del número deseado de filas y columnas en el marco OLE.
- Mantener constante el tamaño del marco OLE y escalar el tamaño de las filas y columnas participantes para que se ajusten al tamaño del marco OLE seleccionado.

### **Escalar el tamaño del marco OLE**

En este enfoque, aprenderemos cómo establecer el tamaño del marco OLE del libro de Excel incrustado para que coincida con el tamaño acumulado de las filas y columnas participantes en la hoja de cálculo de Excel.

Supongamos que tenemos una hoja de cálculo de Excel plantilla y queremos añadirla a una presentación como un marco OLE. En este escenario, el tamaño del marco del objeto OLE se calculará primero en función de la altura acumulada de las filas y el ancho acumulado de las columnas de las filas y columnas participantes en el libro. Luego, estableceremos el tamaño del marco OLE a este valor calculado. Para evitar el mensaje rojo "EMBEDDED OLE OBJECT" del marco OLE en PowerPoint, también capturaremos una imagen de las porciones deseadas de las filas y columnas del libro y la estableceremos como imagen del marco OLE.

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

    # Establecer el tamaño mostrado cuando el libro de trabajo se usa como objeto OLE en PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.getWorksheets().setOleSize(start_row, last_row, start_column, last_column)

    cell_range = worksheet.getCells().createRange(start_row, start_column, row_count, column_count)

    image_stream = create_ole_image(cell_range, image_resolution)
    try:
        # Obtener el ancho y alto de la imagen OLE en puntos.
        image_io = jpype.JClass("javax.imageio.ImageIO")
        image = image_io.read(image_stream)
        frame_width = image.getWidth() * 72.0 / image_resolution
        frame_height = image.getHeight() * 72.0 / image_resolution

        # Usar el libro de trabajo modificado.
        ole_stream = ByteArrayOutputStream()
        try:
            workbook.save(ole_stream, CellsSaveFormat.XLSX)
            workbook_data = ole_stream.toByteArray()
        finally:
            ole_stream.close()

        presentation = Presentation()
        try:
            slide = presentation.getSlides().get_Item(0)

            # Añadir la imagen OLE a los recursos de la presentación.
            image_stream.reset()
            ole_image = presentation.getImages().addImage(image_stream)

            # Crear el marco del objeto OLE.
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

### **Escalar el tamaño del rango de celdas**

En este enfoque, aprenderemos cómo escalar las alturas de las filas participantes y los anchos de las columnas participantes para que coincidan con un tamaño de marco OLE personalizado.

Supongamos que tenemos una hoja de cálculo de Excel plantilla y queremos añadirla a una presentación como un marco OLE. En este escenario, estableceremos el tamaño del marco OLE y escalaremos el tamaño de las filas y columnas que participan en el área del marco OLE. Luego guardaremos el libro en un flujo para aplicar los cambios y lo convertiremos en una matriz de bytes para añadirlo al marco OLE. Para evitar el mensaje rojo "EMBEDDED OLE OBJECT" del marco OLE en PowerPoint, también capturaremos una imagen de las porciones deseadas de las filas y columnas del libro y la estableceremos como imagen del marco OLE.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, ImageOrPrintOptions, ImageType, SheetRender, CellsUnitType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import Presentation, OleEmbeddedDataInfo, SaveFormat

ByteArrayInputStream = jpime.JClass("java.io.ByteArrayInputStream")
ByteArrayOutputStream = jpime.JClass("java.io.ByteArrayOutputStream")


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
    # El ancho y alto esperados del rango de celdas están en puntos.
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

    # Establecer el tamaño mostrado cuando el libro de trabajo se usa como objeto OLE en PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.getWorksheets().setOleSize(start_row, last_row, start_column, last_column)

    cell_range = worksheet.getCells().createRange(start_row, start_column, row_count, column_count)
    # Escalar el rango de celdas para ajustarlo al tamaño del marco.
    scale_cell_range(cell_range, frame_width, frame_height)
    image_stream = create_ole_image(cell_range, image_resolution)
    try:

        # Obtener el ancho y alto de la imagen OLE en puntos.
        image_io = jpype.JClass("javax.imageio.ImageIO")
        image = image_io.read(image_stream)
        frame_width = image.getWidth() * 72.0 / image_resolution
        frame_height = image.getHeight() * 72.0 / image_resolution

        # Usar el libro de trabajo modificado.
        ole_stream = ByteArrayOutputStream()
        try:
            workbook.save(ole_stream, CellsSaveFormat.XLSX)
            workbook_data = ole_stream.toByteArray()
        finally:
            ole_stream.close()

        presentation = Presentation()
        try:
            slide = presentation.getSlides().get_Item(0)

            # Añadir la imagen OLE a los recursos de la presentación.
            image_stream.reset()
            ole_image = presentation.getImages().addImage(image_stream)

            # Crear el marco del objeto OLE.
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

## **Conclusión**

{{% alert color="info" title="Note" %}} 

Existen dos enfoques para solucionar el problema de redimensionado de la hoja de cálculo. La elección del enfoque apropiado depende de los requisitos específicos y del caso de uso. Ambos enfoques funcionan de la misma manera, tanto si las presentaciones se crean a partir de una plantilla como si se crean desde cero. Además, no hay límite en el tamaño del marco del objeto OLE en esta solución.

{{% /alert %}}

## **Preguntas frecuentes**

**¿Por qué una hoja de cálculo de Excel incrustada cambia de tamaño al activarse por primera vez en PowerPoint?**

Esto ocurre porque Excel intenta mantener el tamaño original de la ventana al activarse, mientras que el marco del objeto OLE en PowerPoint tiene sus propias dimensiones. PowerPoint y Excel negocian el tamaño para mantener la proporción, lo que puede provocar el redimensionado.

**¿Es posible evitar este problema de redimensionado por completo?**

Sí. Escalando el marco OLE para que se ajuste al tamaño del rango de celdas de Excel o escalando el rango de celdas para que se ajuste al tamaño deseado del marco OLE, puedes evitar el redimensionado no deseado.

**¿Qué método de escalado debo usar, escalado del marco OLE o escalado del rango de celdas?**

Selecciona **escalado del marco OLE** si deseas mantener los tamaños originales de filas y columnas de Excel. Selecciona **escalado del rango de celdas** si deseas un tamaño fijo para el marco OLE en tu presentación.

**¿Funcionarán estas soluciones si mi presentación se basa en una plantilla?**

Sí. Ambas soluciones funcionan para presentaciones creadas a partir de plantillas y desde cero.

**¿Existe un límite en el tamaño del marco OLE al usar estos métodos?**

No. Puedes hacer que el marco del objeto OLE tenga cualquier tamaño siempre que establezcas la escala adecuadamente.

**¿Hay una forma de evitar el texto de marcador de posición "EMBEDDED OLE OBJECT" en PowerPoint?**

Sí. Capturando una captura del rango de celdas de Excel objetivo y estableciéndola como imagen del marcador de posición del marco OLE, puedes mostrar una imagen de vista previa personalizada en lugar del marcador de posición predeterminado.

## **Artículos relacionados**

[Crear un gráfico de Excel e incrustarlo en una presentación como objeto OLE](/slides/es/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)