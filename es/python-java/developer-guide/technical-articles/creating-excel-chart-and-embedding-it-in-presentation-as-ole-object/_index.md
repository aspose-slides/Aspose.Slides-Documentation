---
title: Crear gráficos de Excel e incrustarlos en presentaciones como objetos OLE
type: docs
weight: 30
url: /es/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Gráfico de Excel
- incrustar gráfico
- objeto OLE
- PowerPoint
- presentación
- Python
- Java
- Aspose.Slides
description: "Crear un gráfico de Excel con Aspose.Cells para Python a través de Java e incrustar el libro de trabajo en una presentación de PowerPoint con Aspose.Slides, incluida una vista previa del gráfico."
---
## **Descripción general**

Este artículo muestra cómo crear un gráfico de columnas de Excel con Aspose.Cells para Python a través de Java e incrustar su libro de trabajo en una presentación de PowerPoint con Aspose.Slides para Python a través de Java. El libro de trabajo incrustado contiene tanto los datos origen como el gráfico. Una vista previa PNG independiente muestra el gráfico en la diapositiva antes de que se active el objeto OLE.

El resultado es un objeto Excel incrustado, no un gráfico nativo de PowerPoint. Editar el libro de trabajo mediante OLE requiere una aplicación de escritorio que admita la activación OLE y una instalación compatible de Excel.

## **Requisitos previos**

Instale los paquetes Python `aspose-cells` y `aspose-slides-java` y un runtime de Java compatible. Importe ambos paquetes antes de iniciar la JVM para que sus bibliotecas Java estén disponibles para JPype. No se requiere Microsoft Office para generar la presentación con estas librerías.

No se necesitan archivos de entrada: el ejemplo crea los datos y el gráfico en memoria, luego escribe `OutputChart.pptx` en el directorio de trabajo actual. Aplique licencias para ambos productos cuando se ejecute fuera del modo de evaluación.

## **Cómo funciona la incrustación**

1. Crear un libro de trabajo con una hoja de datos y una hoja de gráfico.  
2. Hacer que la hoja de gráfico esté activa para que el libro de trabajo se abra en el gráfico.  
3. Establecer el rango de visualización OLE del libro de trabajo y renderizar el gráfico a PNG.  
4. Guardar el libro de trabajo como XLSX en memoria e incrustar esos bytes en una diapositiva.  
5. Asignar el PNG como vista previa del objeto OLE y guardar la presentación como PPTX.

El rango de visualización del libro de trabajo y el marco en la diapositiva tienen roles diferentes. [setOleSize](https://reference.aspose.com/cells/python-java/asposecells.api/worksheetcollection/#setolesize) toma índices de fila y columna de inicio/fin basados en cero. [ChartCollection.add](https://reference.aspose.com/cells/python-java/asposecells.api/chartcollection/#add) en su lugar recibe la fila superior, columna izquierda, fila inferior y columna derecha. El ejemplo usa el índice de fila 55 y el índice de columna 25 como límites inferiores derechos; estos valores son decisiones de diseño, no el número de filas o columnas de datos.

El marco de la diapositiva usa puntos. El ejemplo lo ajusta dentro de la diapositiva y lo centra mientras preserva la proporción del PNG, en lugar de estirar la vista previa para llenar la diapositiva.

## **Crear e incrustar el gráfico**

El siguiente ejemplo completo rellena `DataSheet` con cuatro filas y cinco columnas de valores. Cada fila se convierte en una serie del gráfico. `ChartSheet` se selecciona como la hoja activa antes de guardar el libro de trabajo.

El libro de trabajo se guarda explícitamente como XLSX, coincidiendo con la extensión `xlsx` pasada a [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-java/aspose.slides/oleembeddeddatainfo/). Los flujos de matriz de bytes de Java mantienen el libro de trabajo y la imagen en memoria y proporcionan los arrays de bytes requeridos por las API de Java. El PNG se carga directamente desde sus bytes sin una conversión intermedia a bitmap. Asignarlo mediante [getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) sustituye el marcador de posición OLE predeterminado.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, ChartType, SheetType, ImageOrPrintOptions, ImageType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import Images, OleEmbeddedDataInfo, Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

workbook = Workbook()
try:
    data_sheet = workbook.getWorksheets().get(0)
    data_sheet.setName("DataSheet")

    values = [
        [67, 44, 46, 43, 24],
        [86, 64, 97, 29, 40],
        [68, 89, 78, 69, 38],
        [91, 48, 60, 26, 25],
    ]
    for row, row_values in enumerate(values):
        for column, value in enumerate(row_values):
            data_sheet.getCells().get(row, column).putValue(jpype.JInt(value))

    chart_sheet_index = workbook.getWorksheets().add(SheetType.CHART)
    chart_sheet = workbook.getWorksheets().get(chart_sheet_index)
    chart_sheet.setName("ChartSheet")

    last_chart_row = 55
    last_chart_column = 25
    chart_index = chart_sheet.getCharts().add(ChartType.COLUMN, 0, 0, last_chart_row, last_chart_column)
    chart = chart_sheet.getCharts().get(chart_index)
    for row in range(1, len(values) + 1):
        chart.getNSeries().add(f"DataSheet!A{row}:E{row}", False)

    workbook.getWorksheets().setActiveSheetIndex(chart_sheet_index)
    workbook.getWorksheets().setOleSize(0, last_chart_row, 0, last_chart_column)

    # Renderizar la vista previa del gráfico y serializar el libro de trabajo editable por separado.
    image_options = ImageOrPrintOptions()
    image_options.setImageType(ImageType.PNG)
    chart_image_stream = ByteArrayOutputStream()
    chart.toImage(chart_image_stream, image_options)
    chart_image_bytes = chart_image_stream.toByteArray()

    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.XLSX)
    workbook_bytes = workbook_stream.toByteArray()

    chart_image = Images.fromData(chart_image_bytes)
    try:
        presentation = Presentation()
        try:
            slide = presentation.getSlides().get_Item(0)
            slide_width = presentation.getSlideSize().getSize().getWidth()
            slide_height = presentation.getSlideSize().getSize().getHeight()

            # Ajustar la vista previa dentro de la diapositiva sin cambiar su proporción.
            scale = min(slide_width / chart_image.getWidth(), slide_height / chart_image.getHeight())
            frame_width = chart_image.getWidth() * scale
            frame_height = chart_image.getHeight() * scale
            frame_x = (slide_width - frame_width) / 2
            frame_y = (slide_height - frame_height) / 2

            embedded_data = OleEmbeddedDataInfo(workbook_bytes, "xlsx")
            ole_frame = slide.getShapes().addOleObjectFrame(frame_x, frame_y, frame_width, frame_height, embedded_data)
            preview_image = presentation.getImages().addImage(chart_image)
            ole_frame.getSubstitutePictureFormat().getPicture().setImage(preview_image)

            presentation.save("OutputChart.pptx", SaveFormat.Pptx)
        finally:
            presentation.dispose()
    finally:
        chart_image.dispose()
finally:
    workbook.dispose()
```

## **Resultado esperado**

`OutputChart.pptx` contiene una diapositiva con un libro de trabajo Excel incrustado y una vista previa del gráfico. El libro de trabajo contiene los datos originales y un gráfico de columnas con cuatro series. La vista previa está centrada en la diapositiva y conserva sus proporciones.

![Gráfico de columnas de Excel mostrado como vista previa de un libro de trabajo incrustado](excel-chart-ole-preview.png)

En un entorno de PowerPoint de escritorio compatible con Excel disponible, haga doble clic en el objeto para activarlo y editar el libro de trabajo incrustado. La activación y edición dependen del soporte OLE de la aplicación anfitriona y de la configuración de seguridad.

## **Preguntas frecuentes**

**¿Por qué se necesita una imagen de vista previa?**

El libro de trabajo incrustado y su vista previa en la diapositiva son contenidos separados. Proporcione una imagen del gráfico para que la diapositiva muestre el gráfico en lugar del marcador de posición predeterminado "EMBEDDED OLE OBJECT". Consulte [Problema de vista previa del objeto al añadir OleObjectFrame](/slides/es/python-java/object-preview-issue-when-adding-oleobjectframe/).

**¿Se actualiza automáticamente la vista previa cuando modifico el libro de trabajo en código?**

Considere la vista previa como una captura instantánea. Al actualizar los datos del libro de trabajo programáticamente, regenere la imagen del gráfico y reemplace la vista previa, así como los datos del libro de trabajo incrustado.

**¿Puedo usar XLS en lugar de XLSX?**

Sí. Guarde el libro de trabajo en formato XLS y use `xls` como la extensión de datos incrustados. La extensión debe coincidir con el formato real del libro de trabajo; cambiar solo la extensión no convierte los datos.

**¿Por qué el objeto podría cambiar de tamaño después de la activación?**

La aplicación anfitriona puede actualizar la presentación del objeto OLE cuando activa el libro de trabajo. Tanto el rango de visualización OLE del libro de trabajo como las dimensiones del marco de la diapositiva son importantes. Consulte [Solución funcional para el cambio de tamaño de gráficos en PPTX](/slides/es/python-java/working-solution-for-chart-resizing-in-pptx/).

## **Secciones relacionadas**

- [Solución funcional para el cambio de tamaño de gráficos en PPTX](/slides/es/python-java/working-solution-for-chart-resizing-in-pptx/)
- [Problema de vista previa del objeto al añadir OleObjectFrame](/slides/es/python-java/object-preview-issue-when-adding-oleobjectframe/)