---
title: Solución funcional para el cambio de tamaño de gráficos en PPTX
type: docs
weight: 60
url: /es/python-net/working-solution-for-chart-resizing-in-pptx/
keywords:
- redimensionado de gráfico
- gráfico de Excel
- objeto OLE
- incrustar gráfico
- PowerPoint
- presentación
- Python a través de .NET
- Python
- Aspose.Slides
description: "Corrija el inesperado cambio de tamaño de los gráficos en PPTX al usar objetos OLE de Excel incrustados con Aspose.Slides para Python a través de .NET. Establezca dimensiones fijas para el gráfico y mantenga coherentes los tamaños del gráfico y del marco OLE."
---
## **Resumen**

Los gráficos de Excel incrustados como objetos OLE en presentaciones de PowerPoint mediante componentes Aspose pueden cambiar de tamaño después de su primera activación. Esto puede provocar una diferencia observable en la apariencia del gráfico antes y después de la activación. Este artículo explica por qué ocurre el cambio de tamaño y muestra cómo evitarlo haciendo coincidir las dimensiones fijas del gráfico con el marco OLE.

En [Crear gráficos de Excel e incrustarlos como objetos OLE en presentaciones](/slides/es/python-net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), explicamos cómo crear un gráfico de Excel con Aspose.Cells para Python a través de .NET e incrustarlo en una presentación de PowerPoint usando Aspose.Slides para Python a través de .NET. Para abordar el [problema de vista previa del objeto](/slides/es/python-net/object-preview-issue-when-adding-oleobjectframe/), asignamos la imagen del gráfico al marco del objeto OLE del gráfico. En la presentación de salida, cuando se hace doble clic en el marco del objeto OLE que muestra la imagen del gráfico, se activa el gráfico de Excel. Los usuarios pueden editar el libro de Excel incrustado y luego volver a la diapositiva haciendo clic fuera del libro activado. El tamaño del marco del objeto OLE cambia cuando el usuario vuelve a la diapositiva, y el factor de cambio de tamaño varía según los tamaños originales tanto del marco del objeto OLE como del libro de Excel incrustado.

## **Causa del cambio de tamaño**

El libro de Excel incrustado tiene sus propias dimensiones de ventana, que Excel intenta conservar cuando el objeto se activa por primera vez. El marco OLE en la diapositiva tiene dimensiones definidas de forma independiente. Cuando se activa el libro de Excel, Excel y PowerPoint negocian el tamaño del objeto para mantener sus proporciones como parte del proceso de incrustación. Las diferencias entre la ventana del libro y el marco OLE pueden, por lo tanto, provocar que el objeto cambie de tamaño.

## **Solución funcional**

Haga coincidir el tamaño del gráfico con el marco OLE en la diapositiva y mantenga las dimensiones del gráfico independientes de la ventana del libro. Esta solución funciona con una presentación nueva o con una plantilla existente.

El ejemplo requiere Aspose.Cells para Python a través de .NET y Aspose.Slides para Python a través de .NET. Crea un gráfico de columnas sencillo en una hoja de gráficos activa e incrusta el libro en formato XLS. No se asigna ninguna imagen de vista previa del gráfico; el gráfico se vuelve visible cuando el objeto OLE se activa en PowerPoint.

El ejemplo crea una presentación nueva con un marco OLE de 9,5 × 4 pulgadas situado a 0,5 pulgadas del borde izquierdo y a 1 pulgada de la parte superior. Las coordenadas y dimensiones de la diapositiva están en puntos (72 puntos por pulgada). Para una presentación existente, consulte [Usar una plantilla](#use-a-template).

## **Establecer un tamaño fijo para el gráfico**

Establezca [size_with_window](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chart/size_with_window/) a false para que las dimensiones del gráfico sean independientes de la ventana del libro. Establezca las dimensiones de [chart_object](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chart/chart_object/) mediante [width](https://reference.aspose.com/cells/python-net/aspose.cells.drawing/shape/width/) y [height](https://reference.aspose.com/cells/python-net/aspose.cells.drawing/shape/height/), convirtiendo puntos a píxeles usando 96 píxeles por pulgada: un marco de 684 × 288 puntos corresponde a un gráfico de 912 × 384 píxeles. Establezca [print_size](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chart/print_size/) al valor CUSTOM de [PrintSizeType](https://reference.aspose.com/cells/python-net/aspose.cells/printsizetype/). El ejemplo incrusta el libro con [add_ole_object_frame](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/add_ole_object_frame/) y guarda una presentación con un marco OLE de 9,5 × 4 pulgadas.

```python
import io
import aspose.cells as cells
import aspose.cells.charts as charts
import aspose.slides as slides

workbook = cells.Workbook()
data_sheet = workbook.worksheets[0]
data_sheet.name = "Data"
data_sheet.cells.get("A1").put_value(10)
data_sheet.cells.get("A2").put_value(20)

chart_sheet_index = workbook.worksheets.add(cells.SheetType.CHART)
chart_sheet = workbook.worksheets[chart_sheet_index]
chart_index = chart_sheet.charts.add(charts.ChartType.COLUMN, 0, 0, 20, 10)
chart = chart_sheet.charts[chart_index]
chart.n_series.add("Data!A1:A2", True)
workbook.worksheets.active_sheet_index = chart_sheet_index

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Las coordenadas y dimensiones de la diapositiva están en puntos (72 puntos por pulgada).
    width = 684.0  # 9.5 pulgadas.
    height = 288.0  # 4 pulgadas.

    chart.size_with_window = False
    # Convertir puntos a píxeles del gráfico usando 96 píxeles por pulgada.
    chart.chart_object.width = int(width / 72 * 96)
    chart.chart_object.height = int(height / 72 * 96)
    chart.print_size = cells.PrintSizeType.CUSTOM

    with io.BytesIO() as workbook_stream:
        workbook.save(workbook_stream, cells.SaveFormat.EXCEL_97_TO_2003)
        data_info = slides.dom.ole.OleEmbeddedDataInfo(workbook_stream.getvalue(), "xls")
        slide.shapes.add_ole_object_frame(36, 72, width, height, data_info)

    presentation.save("chart-fixed-size.pptx", slides.export.SaveFormat.PPTX)
```

## **Usar una plantilla**

La lógica de dimensionado es la misma para una presentación existente. Para adaptar el ejemplo:

1. Cargue la presentación de plantilla en lugar de crear una presentación vacía.  
2. Verifique que la primera diapositiva contenga al menos tres formas, luego utilice la forma en el índice 2 como marcador de posición.  
3. Obtenga el ancho y alto del marco de esa forma en lugar de usar los valores fijos 684 y 288. Mantenga los cálculos de tamaño sin cambios.  
4. Añada el marco OLE en la posición del marcador de posición en lugar de las coordenadas fijas 36 y 72.  
5. Elimine el marcador de posición antes de guardar la presentación.

## **Preguntas frecuentes**

**¿Por qué mi gráfico de Excel incrustado cambia de tamaño después de activarlo en PowerPoint?**

Esto ocurre porque Excel intenta restaurar el tamaño original de la ventana al activarse por primera vez, mientras que el marco del objeto OLE en PowerPoint tiene sus propias dimensiones. PowerPoint y Excel negocian el tamaño para mantener la relación de aspecto, lo que puede provocar el cambio de tamaño.

**¿Cómo puedo mantener consistentes los tamaños del gráfico y del marco OLE?**

Establezca dimensiones fijas para el gráfico que coincidan con el marco OLE y use un tamaño de impresión de gráfico personalizado antes de incrustar el libro. El ejemplo anterior muestra la configuración requerida y las conversiones de unidades.

**¿Es suficiente igualar el tamaño de la ventana del libro?**

Igualar únicamente el tamaño de la ventana del libro no evita de forma fiable que el marco OLE cambie de tamaño después de la activación. Utilice dimensiones fijas para el gráfico como se muestra en el ejemplo.

**¿Esta solución funciona tanto con presentaciones basadas en plantillas como con presentaciones nuevas?**

Sí. Para una plantilla, utilice las dimensiones y la posición del marcador de posición. Para una presentación nueva, indique directamente las dimensiones y la posición del marco.

**¿Puedo usar este ejemplo con gráficos creados en otros programas de hoja de cálculo?**

El ejemplo utiliza un libro de Excel creado con Aspose.Cells. No muestra el comportamiento de activación de otros programas de hoja de cálculo.

## **Secciones relacionadas**

- [Crear gráficos de Excel e incrustarlos como objetos OLE en presentaciones](/slides/es/python-net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [Actualizar objetos OLE automáticamente mediante un complemento de PowerPoint](/slides/es/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)