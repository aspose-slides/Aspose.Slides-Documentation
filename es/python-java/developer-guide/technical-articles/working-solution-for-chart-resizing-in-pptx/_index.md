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
- OpenDocument
- presentación
- Python
- Java
- Aspose.Slides
description: "Corrige el redimensionado inesperado de gráficos en PPTX al usar objetos OLE de Excel incrustados con Aspose.Slides for Python via Java. Aprende dos métodos con código para mantener los tamaños consistentes."
---
## **Antecedentes**

Se ha observado que los gráficos de Excel incrustados como objetos OLE en una presentación de PowerPoint mediante los componentes de Aspose se redimensionan a una escala no especificada después de su primera activación. Este comportamiento produce una diferencia visual notable en la presentación entre los estados antes y después de activar el gráfico. El equipo de Aspose ha investigado el problema en detalle y ha encontrado una solución. Este artículo describe las causas del problema y la corrección correspondiente.

En el [artículo anterior](/slides/es/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), explicamos cómo crear un gráfico de Excel con Aspose.Cells for Python via Java e incrustarlo en una presentación de PowerPoint usando Aspose.Slides for Python via Java. Para abordar el [problema de vista previa del objeto](/slides/es/python-java/object-preview-issue-when-adding-oleobjectframe/), asignamos la imagen del gráfico al marco del objeto OLE del gráfico. En la presentación resultante, al hacer doble clic en el marco del objeto OLE que muestra la imagen del gráfico, se activa el gráfico de Excel. Los usuarios finales pueden realizar los cambios que deseen en el libro de Excel subyacente y luego volver a la diapositiva correspondiente haciendo clic fuera del libro activado. El tamaño del marco del objeto OLE cambia cuando el usuario regresa a la diapositiva, y el factor de redimensionado varía según los tamaños originales tanto del marco del objeto OLE como del libro de Excel incrustado.

## **Causa del redimensionado**

Como el libro de Excel tiene su propio tamaño de ventana, intenta conservar su tamaño original en su primera activación. El marco del objeto OLE, sin embargo, tiene su propio tamaño. Según Microsoft, cuando se activa el libro de Excel, Excel y PowerPoint negocian el tamaño y mantienen las proporciones correctas como parte del proceso de incrustación. Dependiendo de las diferencias entre el tamaño de la ventana de Excel y el tamaño o posición del marco del objeto OLE, se produce el redimensionado.

## **Solución funcional**

Existen dos escenarios posibles para crear presentaciones de PowerPoint usando Aspose.Slides for Python via Java.

**Escenario 1:** Crear una presentación a partir de una plantilla existente.

**Escenario 2:** Crear una presentación desde cero.

La solución que ofrecemos aquí se aplica a ambos escenarios. La base de todos los enfoques de solución es la misma: **el tamaño de ventana del objeto OLE incrustado debe coincidir con el marco del objeto OLE en la diapositiva de PowerPoint**. A continuación se describen los dos enfoques de esta solución.

## **Primer enfoque**

En este enfoque, aprenderemos cómo establecer el tamaño de ventana del libro de Excel incrustado para que coincida con el tamaño del marco del objeto OLE en la diapositiva de PowerPoint.

**Escenario 1**

Supongamos que hemos definido una plantilla y queremos crear presentaciones basadas en ella. Imaginemos que hay una forma en el índice 2 de la plantilla donde queremos colocar un marco OLE que contenga un libro de Excel incrustado. En este escenario, el tamaño del marco del objeto OLE está predefinido; coincide con el tamaño de la forma en el índice 2 de la plantilla. Todo lo que necesitamos es establecer el tamaño de ventana del libro de trabajo igual al tamaño de esa forma. El fragmento de código siguiente cumple este propósito:

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# Cargar el libro de Excel que contiene el gráfico.
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(2)

    # Establecer el tamaño de ventana del libro en pulgadas (PowerPoint usa 72 puntos por pulgada).
    workbook.getSettings().setWindowWidthInch(shape.getWidth() / 72.0)
    workbook.getSettings().setWindowHeightInch(shape.getHeight() / 72.0)

    # Guardar el libro en un flujo de memoria.
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # Crear un marco de objeto OLE con los datos de Excel incrustados.
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), data_info)
finally:
    presentation.dispose()
```

**Escenario 2**

Digamos que queremos crear una presentación desde cero e incluir un marco de objeto OLE de cualquier tamaño con un libro de Excel incrustado. En el fragmento de código siguiente, creamos un marco de objeto OLE de 4 pulgadas de alto y 9,5 pulgadas de ancho en x = 0,5 pulgadas e y = 1 pulgada en la diapositiva. Luego establecemos la ventana del libro de Excel al mismo tamaño: 4 pulgadas de alto y 9,5 pulgadas de ancho.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# Cargar el libro de Excel que contiene el gráfico.
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    desired_height = 288  # 4 pulgadas (4 * 72).
    desired_width = 684  # 9,5 pulgadas (9,5 * 72).

    # Definir el tamaño del gráfico con una ventana.
    chart.setSizeWithWindow(True)

    # Establecer el tamaño de ventana del libro en pulgadas (PowerPoint usa 72 puntos por pulgada).
    workbook.getSettings().setWindowWidthInch(desired_width / 72.0)
    workbook.getSettings().setWindowHeightInch(desired_height / 72.0)

    # Guardar el libro en un flujo de memoria.
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # Crear un marco de objeto OLE con los datos de Excel incrustados.
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(36.0, 72.0, desired_width, desired_height, data_info)
finally:
    presentation.dispose()
```

## **Segundo enfoque**

En este enfoque, aprenderemos cómo establecer el tamaño del gráfico en el libro de Excel incrustado para que coincida con el tamaño del marco del objeto OLE en la diapositiva de PowerPoint. Este enfoque es útil cuando el tamaño del gráfico se conoce de antemano y nunca cambiará.

**Escenario 1**

Supongamos que hemos definido una plantilla y queremos crear presentaciones basadas en ella. Imaginemos que hay una forma en el índice 2 de la plantilla donde pretendemos colocar un marco OLE que contenga un libro de Excel incrustado. En este escenario, el tamaño del marco OLE está predefinido; coincide con el tamaño de la forma en el índice 2 de la plantilla. Todo lo que necesitamos es establecer el tamaño del gráfico en el libro de trabajo igual al tamaño de esa forma. El fragmento de código siguiente cumple este propósito:

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# Cargar el libro de Excel que contiene el gráfico.
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(2)

    # Definir el tamaño del gráfico sin ventana.
    chart.setSizeWithWindow(False)

    # Establecer el tamaño del gráfico en píxeles (Excel usa 96 píxeles por pulgada).
    chart.getChartObject().setWidth(int((shape.getWidth() / 72.0) * 96.0))
    chart.getChartObject().setHeight(int((shape.getHeight() / 72.0) * 96.0))

    # Definir el tamaño de impresión del gráfico.
    chart.setPrintSize(PrintSizeType.CUSTOM)

    # Guardar el libro en un flujo de memoria.
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # Crear un marco de objeto OLE con los datos de Excel incrustados.
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), data_info)
finally:
    presentation.dispose()
```

**Escenario 2**:

Supongamos que queremos crear una presentación desde cero e incluir un marco de objeto OLE de cualquier tamaño con un libro de Excel incrustado. En el fragmento de código siguiente, creamos un marco de objeto OLE con una altura de 4 pulgadas y una anchura de 9,5 pulgadas en la diapositiva en x = 0,5 pulgadas e y = 1 pulgada. También establecemos el tamaño del gráfico correspondiente a las mismas dimensiones: una altura de 4 pulgadas y una anchura de 9,5 pulgadas.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# Cargar el libro de Excel que contiene el gráfico.
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    desired_height = 288  # 4 pulgadas (4 * 72).
    desired_width = 684  # 9.5 pulgadas (9.5 * 72).

    # Definir el tamaño del gráfico sin ventana.
    chart.setSizeWithWindow(False)

    # Establecer el tamaño del gráfico en píxeles (Excel usa 96 píxeles por pulgada).
    chart.getChartObject().setWidth(int((desired_width / 72.0) * 96.0))
    chart.getChartObject().setHeight(int((desired_height / 72.0) * 96.0))

    # Guardar el libro en un flujo de memoria.
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # Crear un marco de objeto OLE con los datos de Excel incrustados.
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(36.0, 72.0, desired_width, desired_height, data_info)
finally:
    presentation.dispose()
```

## **Conclusión**

Existen dos enfoques para solucionar el problema de redimensionado del gráfico. La elección del enfoque depende de los requisitos y del caso de uso. Ambos enfoques funcionan de la misma manera, ya sea que las presentaciones se creen a partir de una plantilla o desde cero. Además, no hay límite al tamaño del marco del objeto OLE en esta solución.

## **Preguntas frecuentes**

**¿Por qué mi gráfico de Excel incrustado cambia de tamaño después de activarlo en PowerPoint?**

Esto ocurre porque Excel intenta restaurar el tamaño original de la ventana al activarse por primera vez, mientras que el marco del objeto OLE en PowerPoint tiene sus propias dimensiones. PowerPoint y Excel negocian el tamaño para mantener la relación de aspecto, lo que puede provocar el redimensionado.

**¿Es posible prevenir este problema de redimensionado por completo?**

Sí. Igualando el tamaño de la ventana del libro de Excel o el tamaño del gráfico al del marco del objeto OLE antes de incrustarlo, se pueden mantener los tamaños del gráfico consistentes.

**¿Qué enfoque debo usar, establecer el tamaño de ventana del libro o establecer el tamaño del gráfico?**

Utilice **Enfoque 1 (tamaño de ventana)** si desea preservar la relación de aspecto del libro y permitir un posible redimensionado posterior.  
Utilice **Enfoque 2 (tamaño del gráfico)** si las dimensiones del gráfico son fijas y no cambiarán tras la incrustación.

**¿Funcionarán estos métodos tanto con presentaciones basadas en plantillas como con presentaciones nuevas?**

Sí. Ambos enfoques funcionan igual para presentaciones creadas a partir de plantillas y para presentaciones creadas desde cero.

**¿Existe un límite al tamaño del marco del objeto OLE?**

No. Puede establecer el marco OLE a cualquier tamaño siempre que se escale de forma adecuada al tamaño del libro o del gráfico.

**¿Puedo usar estos métodos con gráficos creados en otros programas de hojas de cálculo?**

Los ejemplos están diseñados para gráficos de Excel creados con Aspose.Cells, pero los principios se aplican a otros programas de hojas de cálculo compatibles con OLE siempre que soporten opciones de dimensionado similares.

## **Secciones relacionadas**

- [Create Excel Charts and Embed Them as OLE Objects in Presentations](/slides/es/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)