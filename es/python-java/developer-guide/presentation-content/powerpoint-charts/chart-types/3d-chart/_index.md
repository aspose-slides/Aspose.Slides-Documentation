---
title: Personalizar gráficos 3D en presentaciones usando Python
linktitle: Gráfico 3D
type: docs
url: /es/python-java/3d-chart/
keywords:
- gráfico 3D
- rotación
- profundidad
- PowerPoint
- presentación
- Python
- Java
- Aspose.Slides
description: "Crear gráficos 3D en presentaciones de PowerPoint con Aspose.Slides for Python via Java. Ajuste la rotación, las proporciones de altura, la profundidad del gráfico y el espaciado entre series con ejemplos en Python."
---
## **Visión general**

Aspose.Slides for Python via Java le permite personalizar la vista de un gráfico 3D mediante el método [Chart.getRotation3D](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getRotation3D). Este artículo muestra cómo ajustar la rotación, las proporciones de altura, la profundidad, los ejes de ángulo recto y el espaciado entre series, y luego guardar la presentación en formato PPTX.

## **Establecer la rotación y la profundidad de un gráfico 3D**

El ejemplo a continuación crea una [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) y utiliza [ShapeCollection.addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) para añadir un gráfico de columnas 3D apilado a su primera diapositiva. Sustituye las series y categorías predeterminadas por dos series que contienen tres valores cada una. El índice de hoja de cálculo `0` identifica la primera hoja de datos del gráfico; la fila `0` contiene los nombres de las series y la columna `0` contiene las etiquetas de categoría.

Los métodos [setRotationX](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRotationX) y [setRotationY](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRotationY) establecen la rotación del gráfico en 40 y 270 grados, respectivamente. [setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) define su profundidad al 150 % de su ancho, mientras que [setRightAngleAxes](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRightAngleAxes) habilita ejes de ángulo recto en lugar de perspectiva. La presentación resultante contiene el gráfico poblado con estas configuraciones de vista 3D.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    values = [[20, 50, 30], [30, 10, 60]]

    for category_index in range(3):
        category_cell = workbook.getCell(worksheet_index, category_index + 1, 0, f"Category {category_index + 1}")
        chart.getChartData().getCategories().add(category_cell)

    for series_index in range(2):
        series_cell = workbook.getCell(worksheet_index, 0, series_index + 1, f"Series {series_index + 1}")
        series = chart.getChartData().getSeries().add(series_cell, chart.getType())

        for category_index in range(3):
            value_cell = workbook.getCell(worksheet_index, category_index + 1, series_index + 1, jpype.JDouble(values[series_index][category_index]))
            series.getDataPoints().addDataPointForBarSeries(value_cell)

    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setRotationX(jpype.JByte(40))
    chart.getRotation3D().setRotationY(270)
    chart.getRotation3D().setDepthPercents(150)

    presentation.save("Rotation3D_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ajustar las proporciones de altura de un gráfico 3D**

Utilice [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setHeightPercents) para definir la altura de un gráfico 3D como porcentaje de su ancho. Esto cambia las proporciones de la escena 3D sin redimensionar el objeto del gráfico en la diapositiva.

El siguiente ejemplo crea un gráfico [Column3D](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) con los datos predeterminados: tres series y cuatro categorías. Guarda tres presentaciones con proporciones de altura del 50 %, 100 % y 200 %. La posición, el ancho y la altura del gráfico permanecen fijos. Los datos, la rotación, la profundidad, el espaciado de series y el formato son idénticos en los tres archivos; solo varía el porcentaje de altura.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 460)
    chart.getRotation3D().setRotationX(jpype.JByte(20))
    chart.getRotation3D().setRotationY(30)
    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setDepthPercents(100)
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setGapDepth(150)

    for height_percent in [50, 100, 200]:
        chart.getRotation3D().setHeightPercents(height_percent)
        presentation.save(f"chart_height_{height_percent}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Las imágenes siguientes ilustran los mismos ajustes de altura en el ejemplo equivalente en .NET y fueron exportadas con Microsoft PowerPoint. Un porcentaje menor produce una escena más plana, mientras que un porcentaje mayor produce una escena más alta dentro del mismo objeto del gráfico. PowerPoint también puede ajustar los intervalos de marcas de los ejes y la colocación de etiquetas para adaptarse a la escena.

| Altura: 50% | Altura: 100% | Altura: 200% |
| --- | --- | --- |
| ![Gráfico de columnas 3D con altura establecida al 50 % de su ancho](height_percent_50.png) | ![Gráfico de columnas 3D con altura establecida al 100 % de su ancho](height_percent_100.png) | ![Gráfico de columnas 3D con altura establecida al 200 % de su ancho](height_percent_200.png) |

Estos métodos controlan diferentes aspectos del gráfico:

| Método | Efecto |
| --- | --- |
| [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setHeightPercents) | Altura de la escena 3D como porcentaje de su ancho. |
| [Chart.setHeight](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setHeight) | Altura del objeto del gráfico en la diapositiva, en puntos. |
| [Rotation3D.setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) | Profundidad de la escena 3D como porcentaje de su ancho. |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) | Espaciado entre series a lo largo del eje de profundidad, como porcentaje del ancho del marcador. |

El ajuste de altura afecta a los gráficos de columnas y barras 3D, incluidas las variantes cilindro, cono y pirámide, así como a los gráficos 3D de línea, área, pastel y superficie. La comparativa anterior utiliza el tipo verificado `Column3D`. El ajuste no modifica la apariencia de un gráfico 2D `ClusteredColumn` ni de un gráfico `BubbleWith3D`; estos nombres son miembros de la clase [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/). Para otras configuraciones de apariencia del gráfico, consulte [Formato de gráfico](/slides/es/python-java/chart-formatting/).

## **Ajustar el hueco entre series**

Utilice [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) para controlar la distancia entre series de datos a lo largo del eje de profundidad de un gráfico 3D, expresada como porcentaje del ancho del marcador. Use valores de **0 a 500**, inclusive: `0` elimina el hueco, mientras que valores mayores aumentan el espaciado. Con una profundidad de gráfico fija, aumentar el hueco hace que los marcadores sean más delgados a lo largo del eje de profundidad.

Acceda al grupo mediante [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getParentSeriesGroup). La configuración se aplica a todas las series de ese grupo, no solo a la serie utilizada para acceder a él. [ChartSeries.getGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getGapDepth) devuelve el hueco de profundidad y refleja la configuración del grupo padre.

Este ajuste afecta a los gráficos de columnas y barras 3D, incluidas sus variantes cilindro, cono y pirámide, así como a los gráficos 3D de línea y área. La apariencia depende de si las series están dispuestas en profundidad, agrupadas o apiladas. Para una comparación clara de los huecos entre series distintas, utilice `ChartType.Column3D` de la clase [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/).

Estos métodos controlan diferentes aspectos del gráfico:

| Método | Efecto |
| --- | --- |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) | Espaciado entre series a lo largo del eje de profundidad, como porcentaje del ancho del marcador. |
| [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) | Espaciado entre grupos adyacentes de barras o columnas, como porcentaje del ancho de la barra o columna. |
| [setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) | Profundidad total del gráfico, como porcentaje del ancho del gráfico. |

El siguiente ejemplo autónomo utiliza los datos predeterminados del gráfico, que contienen tres series y cuatro categorías. Guarda dos presentaciones con datos, rotación, ancho de hueco y profundidad del gráfico idénticos; solo varía el hueco de profundidad.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 230)

    chart.getRotation3D().setRotationX(jpype.JByte(20))
    chart.getRotation3D().setRotationY(30)
    chart.getRotation3D().setDepthPercents(100)

    series = chart.getChartData().getSeries().get_Item(0)
    group = series.getParentSeriesGroup()
    group.setGapWidth(150)

    for gap_depth in [0, 500]:
        group.setGapDepth(gap_depth)

        file_name = f"series_gap_depth_{gap_depth}.pptx"
        presentation.save(file_name, SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Las imágenes siguientes ilustran los mismos ajustes de hueco de profundidad en el ejemplo equivalente en .NET y fueron exportadas con Microsoft PowerPoint.

| Hueco de profundidad: 0% | Hueco de profundidad: 500% |
| --- | --- |
| ![Gráfico de columnas 3D sin hueco entre series a lo largo del eje de profundidad](gap_depth_0.png) | ![Gráfico de columnas 3D con un hueco del 500 % entre series a lo largo del eje de profundidad](gap_depth_500.png) |

## **Cambiar el tipo de serie 3D y la forma de la barra**

En un gráfico de cilindros agrupados, la primera serie comienza con una forma de barra cilíndrica. El ejemplo muestra los valores enteros devueltos por [ChartSeries.getType](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getType) y [ChartSeries.getBar3DShape](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getBar3DShape) antes y después de cada cambio. La tabla muestra los nombres de constante correspondientes.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartShapeType, ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredCylinder, 20, 20, 500, 300)
    series = chart.getChartData().getSeries().get_Item(0)
    
    print(f"{series.getType()} | {series.getBar3DShape()}")

    series.setType(ChartType.ClusteredCone)
    print(f"{series.getType()} | {series.getBar3DShape()}")

    series.setBar3DShape(ChartShapeType.Box)
    print(f"{series.getType()} | {series.getBar3DShape()}")

    presentation.save("series_shape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

| Cambiar la primera serie | Tipo de serie | Forma de barra |
| --- | --- | --- |
| Crear el gráfico | `ClusteredCylinder` | `Cylinder` |
| Establecer el tipo de serie a `ClusteredCone` | `ClusteredCone` | `Cone` |
| Establecer la forma de barra a `Box` | `ClusteredColumn3D` | `Box` |

Establecer la forma a `Box` también cambia el tipo de serie a `ClusteredColumn3D`. Si su código ramifica según el tipo de serie, llame a `series.getType()` después de cambiar la forma. Un valor almacenado en caché antes de la asignación seguiría seleccionando la rama `ClusteredCone`.

![Comparación en PowerPoint que muestra la primera serie como cilindros, conos y columnas rectangulares de izquierda a derecha](series-shapes.png)

## **Preguntas frecuentes**

**¿Qué tipos de gráfico admiten modo 3D en Aspose.Slides?**

Aspose.Slides admite variantes 3D de gráficos de columnas, incluidas Column 3D, Clustered Column 3D, Stacked Column 3D y 100 % Stacked Column 3D, junto con los tipos 3D relacionados expuestos a través de la clase [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/). Para obtener una lista exacta y actualizada, consulte los miembros de [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) en la referencia de API de la versión instalada.

**¿Puedo obtener una imagen rasterizada de un gráfico 3D para un informe o la web?**

Sí. Puede exportar un gráfico a una imagen con [Shape.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) o [renderizar toda la diapositiva](/slides/es/python-java/convert-powerpoint-to-png/) a formatos como PNG o JPEG. Esto es útil cuando necesita una vista previa rasterizada o quiere incrustar el gráfico en documentos, paneles o páginas web sin requerir PowerPoint.

**¿Qué rendimiento tiene la creación y representación de gráficos 3D grandes?**

El rendimiento depende del volumen de datos y la complejidad visual. Para obtener los mejores resultados, mantenga los efectos 3D al mínimo, evite texturas pesadas en paredes y áreas de trazado, limite la cantidad de puntos de datos por serie cuando sea posible y renderice a una salida de tamaño adecuado (resolución y dimensiones) que coincida con la pantalla o los requisitos de impresión del destino.