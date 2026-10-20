---
title: Crear gráficos de Excel e incrustarlos en presentaciones como objetos OLE
type: docs
weight: 50
url: /es/python-net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- gráfico de Excel
- incrustar gráfico
- objeto OLE
- PowerPoint
- presentación
- Python
- Python a través de .NET
- Aspose.Slides
description: "Crear un gráfico de Excel con Aspose.Cells para Python a través de .NET e incrustar el libro de trabajo en una presentación de PowerPoint con Aspose.Slides, incluyendo una vista previa del gráfico."
---
## **Resumen**

Este artículo muestra cómo crear un gráfico de columnas de Excel con Aspose.Cells para Python a través de .NET e incrustar su libro de trabajo en una presentación de PowerPoint con Aspose.Slides para Python a través de .NET. El libro de trabajo incrustado contiene tanto los datos de origen como el gráfico. Una vista previa PNG independiente muestra el gráfico en la diapositiva antes de que se active el objeto OLE.

El resultado es un objeto de Excel incrustado, no un gráfico nativo de PowerPoint. Editar el libro de trabajo a través de OLE requiere una aplicación de escritorio que admita la activación de OLE y una instalación de Excel compatible.

## **Requisitos previos**

Instale los paquetes `aspose-cells-python` y `aspose-slides` en su entorno de Python. No se requiere Microsoft Office para generar la presentación con estas bibliotecas.

No se requieren archivos de entrada: el ejemplo crea los datos y el gráfico en memoria, luego escribe `OutputChart.pptx` en el directorio de trabajo actual. Aplique licencias para ambos productos cuando se ejecute fuera del modo de evaluación.

## **Cómo funciona la incrustación**

1. Cree un libro de trabajo con una hoja de datos y una hoja de gráfico.
1. Active la hoja de gráfico para que el libro de trabajo se abra en el gráfico.
1. Establezca el rango de visualización OLE del libro de trabajo y renderice el gráfico a PNG.
1. Guarde el libro de trabajo como XLSX en memoria e incruste esos bytes en una diapositiva.
1. Asigne el PNG como vista previa del objeto OLE y guarde la presentación como PPTX.

El rango de visualización del libro de trabajo y el marco en la diapositiva tienen roles diferentes. [set_ole_size](https://reference.aspose.com/cells/python-net/aspose.cells/worksheetcollection/set_ole_size/) recibe índices de fila y columna de inicio/fin basados en cero. [ChartCollection.add](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chartcollection/add/) en su lugar recibe la fila superior, columna izquierda, fila inferior y columna derecha. El ejemplo utiliza el índice de fila 55 y el índice de columna 25 como límite inferior derecho; estos valores son decisiones de diseño, no el número de filas o columnas de datos.

El marco de la diapositiva usa puntos. El ejemplo lo ajusta dentro de la diapositiva y lo centra mientras preserva la relación de aspecto del PNG, en lugar de estirar la vista previa para llenar la diapositiva.

## **Crear e incrustar el gráfico**

El siguiente ejemplo completo rellena `DataSheet` con cuatro filas y cinco columnas de valores. Cada fila se convierte en una serie del gráfico. `ChartSheet` se selecciona como la hoja activa antes de guardar el libro de trabajo.

El libro de trabajo se guarda explícitamente como XLSX, coincidiendo con la extensión `xlsx` que se pasa a [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-net/aspose.slides.dom.ole/oleembeddeddatainfo/). El PNG se carga directamente desde su flujo sin una conversión intermedia a bitmap. Asignarlo a través de [substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/ioleobjectframe/substitute_picture_format/) reemplaza el marcador de posición OLE predeterminado.

```python
import io
import aspose.cells as cells
import aspose.cells.charts as charts
import aspose.cells.drawing as drawing
import aspose.slides as slides

workbook = cells.Workbook()
data_sheet = workbook.worksheets[0]
data_sheet.name = "DataSheet"

values = [
    [67, 44, 46, 43, 24],
    [86, 64, 97, 29, 40],
    [68, 89, 78, 69, 38],
    [91, 48, 60, 26, 25],
]

for row, row_values in enumerate(values):
    for column, value in enumerate(row_values):
        data_sheet.cells.get(row, column).put_value(value)

chart_sheet_index = workbook.worksheets.add(cells.SheetType.CHART)
chart_sheet = workbook.worksheets[chart_sheet_index]
chart_sheet.name = "ChartSheet"

last_chart_row = 55
last_chart_column = 25
chart_index = chart_sheet.charts.add(charts.ChartType.COLUMN, 0, 0, last_chart_row, last_chart_column)
chart = chart_sheet.charts[chart_index]
for row in range(1, len(values) + 1):
    chart.n_series.add(f"DataSheet!A{row}:E{row}", False)

workbook.worksheets.active_sheet_index = chart_sheet_index
workbook.worksheets.set_ole_size(0, last_chart_row, 0, last_chart_column)

# Renderizar la vista previa del gráfico y serializar el libro de trabajo editable por separado.
with io.BytesIO() as chart_image_stream, io.BytesIO() as workbook_stream:
    chart.to_image(chart_image_stream, drawing.ImageType.PNG)
    chart_image_stream.seek(0)
    workbook.save(workbook_stream, cells.SaveFormat.XLSX)
    workbook_bytes = workbook_stream.getvalue()

    with slides.Images.from_stream(chart_image_stream) as chart_image:
        with slides.Presentation() as presentation:
            slide = presentation.slides[0]
            slide_size = presentation.slide_size.size

            # Ajustar la vista previa dentro de la diapositiva sin cambiar su relación de aspecto.
            scale = min(slide_size.width / chart_image.width, slide_size.height / chart_image.height)
            frame_width = chart_image.width * scale
            frame_height = chart_image.height * scale
            frame_x = (slide_size.width - frame_width) / 2
            frame_y = (slide_size.height - frame_height) / 2

            embedded_data = slides.dom.ole.OleEmbeddedDataInfo(workbook_bytes, "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(frame_x, frame_y, frame_width, frame_height, embedded_data)
            preview_image = presentation.images.add_image(chart_image)
            ole_frame.substitute_picture_format.picture.image = preview_image

            presentation.save("OutputChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Resultado esperado**

`OutputChart.pptx` contiene una diapositiva con un libro de trabajo de Excel incrustado y una vista previa del gráfico. El libro de trabajo contiene los datos originales y un gráfico de columnas con cuatro series. La vista previa está centrada en la diapositiva y conserva sus proporciones.

![Gráfico de columnas de Excel mostrado como vista previa de un libro de trabajo incrustado](excel-chart-ole-preview.png)

En un entorno de escritorio de PowerPoint compatible con Excel disponible, haga doble clic en el objeto para activar y editar el libro de trabajo incrustado. La activación y la edición dependen del soporte OLE de la aplicación anfitriona y de la configuración de seguridad.

## **Preguntas frecuentes**

**¿Por qué se necesita una imagen de vista previa?**

El libro de trabajo incrustado y su vista previa en la diapositiva son contenidos separados. Proporcione una imagen del gráfico para que la diapositiva muestre el gráfico en lugar del marcador de posición predeterminado "EMBEDDED OLE OBJECT". Vea [Object Preview Issue when Adding OleObjectFrame](/slides/es/python-net/object-preview-issue-when-adding-oleobjectframe/).

**¿Se actualiza automáticamente la vista previa cuando cambio el libro de trabajo en el código?**

Considere la vista previa como una instantánea. Al actualizar los datos del libro de trabajo programáticamente, regenere la imagen del gráfico y reemplace tanto la vista previa como los datos del libro de trabajo incrustado.

**¿Puedo usar XLS en lugar de XLSX?**

Sí. Guarde el libro de trabajo en formato XLS y use `xls` como la extensión de los datos incrustados. La extensión debe coincidir con el formato real del libro de trabajo; cambiar solo la extensión no convierte los datos.

**¿Por qué el objeto podría cambiar de tamaño después de la activación?**

La aplicación anfitriona puede actualizar la presentación del objeto OLE cuando activa el libro de trabajo. El rango de visualización OLE del libro de trabajo y las dimensiones del marco de la diapositiva son ambos importantes. Vea [Resize OLE Objects Automatically in PowerPoint Presentations](/slides/es/python-net/working-solution-for-worksheet-resizing/).

## **Secciones relacionadas**

- [Redimensionar objetos OLE automáticamente en presentaciones de PowerPoint](/slides/es/python-net/working-solution-for-worksheet-resizing/)
- [Problema de vista previa del objeto al añadir OleObjectFrame](/slides/es/python-net/object-preview-issue-when-adding-oleobjectframe/)
- [Gestionar objetos OLE](/slides/es/python-net/manage-ole/)