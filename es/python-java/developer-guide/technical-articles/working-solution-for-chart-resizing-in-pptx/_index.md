---
title: Solución funcional para el redimensionado de gráficos en PPTX
type: docs
weight: 40
url: /es/python-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- redimensionado de gráficos
- gráfico de Excel
- objeto OLE
- incrustar gráfico
- PowerPoint
- presentación
- Python
- Java
- Aspose.Slides
description: "Corrija el redimensionado inesperado de gráficos en PPTX al usar objetos OLE de Excel incrustados con Aspose.Slides para Python a través de Java. Establezca dimensiones fijas del gráfico para mantener coherentes los tamaños del gráfico y del marco OLE."
---
## **Contexto**

Los gráficos de Excel incrustados como objetos OLE en presentaciones de PowerPoint mediante los componentes Aspose pueden cambiar de tamaño después de su primera activación. Esto puede provocar una diferencia notable en la apariencia del gráfico antes y después de la activación. Este artículo explica por qué ocurre el redimensionado y muestra cómo evitarlo haciendo coincidir las dimensiones fijas del gráfico con el marco OLE.

En [Crear gráficos de Excel e incrustarlos como objetos OLE en presentaciones](/slides/es/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), explicamos cómo crear un gráfico de Excel con Aspose.Cells for Python via Java e incrustarlo en una presentación de PowerPoint usando Aspose.Slides for Python via Java. Para abordar el [problema de vista previa del objeto](/slides/es/python-java/object-preview-issue-when-adding-oleobjectframe/), asignamos la imagen del gráfico al marco del objeto OLE del gráfico. En la presentación resultante, cuando hace doble clic en el marco del objeto OLE que muestra la imagen del gráfico, el gráfico de Excel se activa. Los usuarios pueden editar el libro de trabajo de Excel incrustado y luego volver a la diapositiva haciendo clic fuera del libro activado. El tamaño del marco del objeto OLE cambia cuando el usuario vuelve a la diapositiva, y el factor de redimensionado varía según los tamaños originales tanto del marco OLE como del libro de trabajo de Excel incrustado.

## **Causa del redimensionado**

El libro de trabajo de Excel incrustado tiene sus propias dimensiones de ventana, que Excel intenta conservar cuando el objeto se activa por primera vez. El marco OLE en la diapositiva tiene dimensiones definidas de forma independiente. Cuando el libro de trabajo se activa, Excel y PowerPoint negocian el tamaño del objeto para mantener sus proporciones como parte del proceso de incrustado. Las diferencias entre la ventana del libro y el marco OLE pueden, por tanto, provocar el redimensionado del objeto.

## **Solución funcional**

Haga coincidir el tamaño del gráfico con el marco OLE de la diapositiva y mantenga las dimensiones del gráfico independientes de la ventana del libro de trabajo. Esta solución funciona con una presentación nueva o con una plantilla existente.

El ejemplo requiere Aspose.Cells for Python via Java y Aspose.Slides for Python via Java. Crea un gráfico de columnas simple en una hoja de gráfico activa e incrusta el libro de trabajo en formato XLS. No se asigna una imagen de vista previa del gráfico; el gráfico se vuelve visible cuando el objeto OLE se activa en PowerPoint.

El ejemplo crea una nueva presentación con un marco OLE de 9,5 × 4 pulgadas situado a 0,5 pulgadas del borde izquierdo y a 1 pulgada de la parte superior. Las coordenadas y dimensiones de la diapositiva están en puntos (72 puntos por pulgada). Para una presentación existente, vea [Usar una plantilla](#use-a-template).

## **Establecer un tamaño fijo para el gráfico**

Establezca [setSizeWithWindow](https://reference.aspose.com/cells/python-java/asposecells.api/chart/#sizewithwindow) a false para que las dimensiones del gráfico sean independientes de la ventana del libro de trabajo. Establezca las dimensiones del [getChartObject](https://reference.aspose.com/cells/python-java/asposecells.api/chart/#chartobject) a través de [setWidth](https://reference.aspose.com/cells/python-java/asposecells.api/shape/#width) y [setHeight](https://reference.aspose.com/cells/python-java/asposecells.api/shape/#height), convirtiendo puntos a píxeles usando 96 píxeles por pulgada: un marco que mide 684 × 288 puntos corresponde a un gráfico que mide 912 × 384 píxeles. Establezca [setPrintSize](https://reference.aspose.com/cells/python-java/asposecells.api/chart/#printsize) al valor CUSTOM de [PrintSizeType](https://reference.aspose.com/cells/python-java/asposecells.api/printsizetype/). El ejemplo incrusta el libro de trabajo con [addOleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addOleObjectFrame) y guarda una presentación con un marco OLE de 9,5 × 4 pulgadas.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import ChartType, FileFormatType, PrintSizeType, SheetType, Workbook
from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

workbook = Workbook()
try:
    data_sheet = workbook.getWorksheets().get(0)
    data_sheet.setName("Data")
    data_sheet.getCells().get("A1").putValue(10)
    data_sheet.getCells().get("A2").putValue(20)

    chart_sheet_index = workbook.getWorksheets().add(SheetType.CHART)
    chart_sheet = workbook.getWorksheets().get(chart_sheet_index)
    chart_index = chart_sheet.getCharts().add(ChartType.COLUMN, 0, 0, 20, 10)
    chart = chart_sheet.getCharts().get(chart_index)
    chart.getNSeries().add("Data!A1:A2", True)
    workbook.getWorksheets().setActiveSheetIndex(chart_sheet_index)

    presentation = Presentation()
    try:
        slide = presentation.getSlides().get_Item(0)

        # Las coordenadas y dimensiones de la diapositiva están en puntos (72 puntos por pulgada).
        width = 684.0  # 9,5 pulgadas.
        height = 288.0  # 4 pulgadas.

        chart.setSizeWithWindow(False)
        # Convertir puntos a píxeles del gráfico usando 96 píxeles por pulgada.
        chart.getChartObject().setWidth(int(width / 72.0 * 96.0))
        chart.getChartObject().setHeight(int(height / 72.0 * 96.0))
        chart.setPrintSize(PrintSizeType.CUSTOM)

        workbook_stream = ByteArrayOutputStream()
        workbook.save(workbook_stream, FileFormatType.EXCEL_97_TO_2003)
        workbook_data = workbook_stream.toByteArray()
        data_info = OleEmbeddedDataInfo(workbook_data, "xls")
        slide.getShapes().addOleObjectFrame(36.0, 72.0, width, height, data_info)

        presentation.save("chart-fixed-size.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    workbook.dispose()
```

## **Usar una plantilla**

La lógica de dimensionado es la misma para una presentación existente. Para adaptar el ejemplo:

1. Cargue la presentación de plantilla en lugar de crear una presentación vacía.  
1. Verifique que la primera diapositiva contenga al menos tres formas y utilice la forma en el índice 2 como marcador de posición.  
1. Obtenga el ancho y alto del marco de esa forma en lugar de usar los valores fijos 684 y 288. Mantenga los cálculos de dimensiones sin cambios.  
1. Añada el marco OLE en la posición del marcador de posición en lugar de las coordenadas fijas 36 y 72.  
1. Elimine el marcador de posición antes de guardar la presentación.

## **Preguntas frecuentes**

**¿Por qué mi gráfico de Excel incrustado cambia de tamaño después de activarlo en PowerPoint?**

Esto ocurre porque Excel intenta restaurar el tamaño original de la ventana cuando se activa por primera vez, mientras que el marco del objeto OLE en PowerPoint tiene sus propias dimensiones. PowerPoint y Excel negocian el tamaño para mantener la relación de aspecto, lo que puede provocar el redimensionado.

**¿Cómo puedo mantener consistentes los tamaños del gráfico y del marco OLE?**

Establezca dimensiones fijas para el gráfico que coincidan con el marco OLE y use un tamaño de impresión de gráfico personalizado antes de incrustar el libro de trabajo. El ejemplo anterior muestra la configuración requerida y las conversiones de unidades.

**¿Es suficiente igualar el tamaño de la ventana del libro de trabajo?**

Igualar únicamente el tamaño de la ventana del libro de trabajo no evita de forma fiable que el marco OLE cambie de tamaño después de la activación. Utilice dimensiones fijas del gráfico como se muestra en el ejemplo.

**¿Funciona esta solución tanto con presentaciones basadas en plantillas como con presentaciones nuevas?**

Sí. Para una plantilla, use las dimensiones y la posición del marcador de posición. Para una presentación nueva, especifique directamente las dimensiones y la posición del marco.

**¿Puedo usar este ejemplo con gráficos creados en otros programas de hoja de cálculo?**

El ejemplo utiliza un libro de trabajo de Excel creado con Aspose.Cells. No muestra el comportamiento de activación para otros programas de hoja de cálculo.

## **Secciones relacionadas**

- [Crear gráficos de Excel e incrustarlos como objetos OLE en presentaciones](/slides/es/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)