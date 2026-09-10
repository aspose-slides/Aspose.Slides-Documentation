---
title: Personalizar puntos de datos en gráficos Treemap y Sunburst en Python
linktitle: Puntos de datos en gráficos Treemap y Sunburst
type: docs
url: /es/python-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- gráfico treemap
- gráfico sunburst
- gráfico jerárquico
- punto de datos
- etiqueta de datos
- color de rama
- PowerPoint
- presentación
- Python
- Java
- Aspose.Slides
description: "Aprenda a crear datos jerárquicos y personalizar niveles, etiquetas y colores en gráficos Treemap y Sunburst con Aspose.Slides para Python vía Java."
---
## **Resumen**

Los gráficos de Treemap y Sunburst muestran el mismo tipo de datos jerárquicos, pero utilizan disposiciones diferentes. Un Treemap dibuja la jerarquía como rectángulos anidados cuyo área representa los valores de hoja. Un Sunburst la representa como anillos concéntricos: los grupos de nivel superior están cerca del centro y las categorías de hoja están en el anillo exterior.

En Aspose.Slides for Python vía Java, cada valor numérico es un [ChartDataPoint](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartdatapoint/). Su método [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartdatapoint/#getDataPointLevels) permite acceder a la hoja y a sus grupos padre. Este artículo explica ese mapeo y muestra cómo crear y dar formato a ambos tipos de gráfico a partir de los mismos datos de ejemplo.

![Un gráfico Treemap con ramas Consumidor y Negocio](treemap-hierarchy.png)

![Un gráfico Sunburst con la misma jerarquía Consumidor y Negocio](sunburst-hierarchy.png)

## **Entender categorías, puntos de datos y niveles**

El ejemplo utilizado a continuación tiene tres niveles de categoría y una serie numérica:

| Rama | Tronco | Hoja | Ingresos |
| --- | --- | --- | ---: |
| Consumidor | Ordenadores | Portátiles | 12 |
| Consumidor | Ordenadores | Sobremesas | 8 |
| Consumidor | Móvil | Teléfonos | 15 |
| Consumidor | Móvil | Tabletas | 6 |
| Negocio | Servicios | Consultoría | 10 |
| Negocio | Servicios | Soporte | 7 |
| Negocio | Software | Licencias | 11 |
| Negocio | Software | Suscripciones | 14 |

Cada fila crea una categoría de hoja y un punto de datos. Los niveles de agrupación de categoría describen la ruta desde esa hoja hasta sus padres. Para la primera fila, la ruta es `Consumer > Computers > Laptops`.

Los índices devueltos por [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartdatapoint/#getDataPointLevels) se cuentan desde la hoja hacia arriba:

| Índice de `getDataPointLevels()` | Nivel lógico | Representación en Treemap | Representación en Sunburst |
| ---: | --- | --- | --- |
| `0` | Hoja | Rectángulo de valor | Segmento del anillo exterior |
| `1` | Tronco | Rectángulo o encabezado padre | Segmento del anillo medio |
| `2` | Rama | Rectángulo o encabezado de nivel superior | Segmento del anillo interno |

Este orden es el mismo para ambos tipos de gráfico aunque sus disposiciones visuales difieran. Un segmento padre es compartido por varias hojas. Para formatearlo, utilice el nivel correspondiente del primer punto de datos del grupo. Por ejemplo, la rama `Consumer` comienza con el punto `Laptops`, mientras que el tronco `Software` comienza con el punto `Licenses`. Mantener referencias a esos puntos es más claro y seguro que usar expresiones sin explicación como `data_points.get_Item(0)` o `data_points.get_Item(6)`.

## **Crear y personalizar ambos tipos de gráfico**

El siguiente ejemplo completo crea un Treemap en la primera diapositiva y un Sunburst en la segunda diapositiva. Construye la jerarquía, muestra el valor para `Tablets`, aplica colores fijos a niveles seleccionados, da formato a la etiqueta de una rama y guarda la presentación.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, ParentLabelLayoutType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    worksheet_index = 0
    leaf_level_index = 0
    stem_level_index = 1
    branch_level_index = 2

    branch_names = [
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    ]
    stem_names = [
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    ]
    leaf_names = [
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    ]
    revenues = [12, 8, 15, 6, 10, 7, 11, 14]
    data_point_count = len(leaf_names)

    chart_types = [ChartType.Treemap, ChartType.Sunburst]
    layout_slide = presentation.getLayoutSlides().get_Item(0)

    for chart_index, chart_type in enumerate(chart_types):
        if chart_index == 0:
            slide = presentation.getSlides().get_Item(0)
        else:
            slide = presentation.getSlides().addEmptySlide(layout_slide)

        chart = slide.getShapes().addChart(chart_type, 40, 40, 640, 440)
        chart.setTitle(False)
        chart.setLegend(False)

        chart_data = chart.getChartData()
        chart_data.getCategories().clear()
        chart_data.getSeries().clear()

        workbook = chart_data.getChartDataWorkbook()
        workbook.clear(worksheet_index)

        # Añadir las categorías de hoja. Se establece un elemento de agrupación solo cuando comienza un nuevo grupo;
        # las categorías siguientes permanecen en ese grupo hasta que se establezca otro elemento.
        for data_index in range(data_point_count):
            row_index = data_index + 1
            leaf_name = leaf_names[data_index]
            category_cell = workbook.getCell(worksheet_index, row_index, 2, leaf_name)
            category = chart_data.getCategories().add(category_cell)

            stem_name = stem_names[data_index]
            starts_new_stem = data_index == 0
            if data_index > 0:
                previous_stem_name = stem_names[data_index - 1]
                starts_new_stem = stem_name != previous_stem_name
            if starts_new_stem:
                category.getGroupingLevels().setGroupingItem(stem_level_index, stem_name)

            branch_name = branch_names[data_index]
            starts_new_branch = data_index == 0
            if data_index > 0:
                previous_branch_name = branch_names[data_index - 1]
                starts_new_branch = branch_name != previous_branch_name
            if starts_new_branch:
                category.getGroupingLevels().setGroupingItem(branch_level_index, branch_name)

        series_name_cell = workbook.getCell(worksheet_index, 0, 3, "Revenue")
        series = chart_data.getSeries().add(series_name_cell, chart_type)
        series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(True)

        laptops_data_point = None
        tablets_data_point = None
        licenses_data_point = None

        for data_index in range(data_point_count):
            row_index = data_index + 1
            leaf_name = leaf_names[data_index]
            revenue = revenues[data_index]
            value_cell = workbook.getCell(worksheet_index, row_index, 3, jpype.JDouble(revenue))

            if chart_type == ChartType.Treemap:
                data_point = series.getDataPoints().addDataPointForTreemapSeries(value_cell)
            else:
                data_point = series.getDataPoints().addDataPointForSunburstSeries(value_cell)

            if leaf_name == "Laptops":
                laptops_data_point = data_point
            elif leaf_name == "Tablets":
                tablets_data_point = data_point
            elif leaf_name == "Licenses":
                licenses_data_point = data_point

        # Mostrar la categoría y el valor en la hoja Tablets.
        tablets_leaf_level = tablets_data_point.getDataPointLevels().get_Item(leaf_level_index)
        tablets_label_format = tablets_leaf_level.getLabel().getDataLabelFormat()
        tablets_label_format.setShowCategoryName(True)
        tablets_label_format.setShowValue(True)
        tablets_label_format.setSeparator("\n")
        tablets_label_format.setNumberFormat("$0")

        # Dar formato a la rama Consumer a través de la primera hoja de esa rama.
        consumer_branch_level = laptops_data_point.getDataPointLevels().get_Item(branch_level_index)
        consumer_branch_fill = consumer_branch_level.getFormat().getFill()
        consumer_branch_color = Color(31, 78, 121)
        consumer_branch_fill.setFillType(FillType.Solid)
        consumer_branch_fill.getSolidFillColor().setColor(consumer_branch_color)

        consumer_label_format = consumer_branch_level.getLabel().getDataLabelFormat()
        consumer_label_format.setShowCategoryName(True)
        consumer_label_format.setShowSeriesName(False)
        consumer_label_text_fill = consumer_label_format.getTextFormat().getPortionFormat().getFillFormat()
        consumer_label_text_fill.setFillType(FillType.Solid)
        consumer_label_text_fill.getSolidFillColor().setColor(Color.WHITE)

        # Dar formato al tronco Software a través de la primera hoja de ese tronco.
        software_stem_level = licenses_data_point.getDataPointLevels().get_Item(stem_level_index)
        software_stem_fill = software_stem_level.getFormat().getFill()
        software_stem_color = Color(112, 173, 71)
        software_stem_fill.setFillType(FillType.Solid)
        software_stem_fill.getSolidFillColor().setColor(software_stem_color)

        # ParentLabelLayout afecta a las etiquetas de los padres en Treemap; Sunburst utiliza segmentos de anillo.
        if chart_type == ChartType.Treemap:
            series.setParentLabelLayout(ParentLabelLayoutType.Overlapping)

    presentation.save("hierarchical-charts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Las celdas de categoría y las celdas de valor utilizan la misma fila de hoja de cálculo, por lo que sus posiciones en la colección permanecen alineadas. Cuando trabaje con un gráfico existente en lugar de crear uno, inspeccione primero las filas de categoría y almacene referencias nombradas a los puntos de datos y niveles que pretenda formatear.

## **Comportamiento y consideraciones prácticas**

### **Diferencias entre Treemap y Sunburst**

- Un Treemap utiliza el área para comunicar el valor y rectángulos anidados para comunicar la jerarquía. El método [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartseries/#setParentLabelLayout) controla cómo aparecen las etiquetas de los padres en este tipo de gráfico.
- Un Sunburst utiliza el ángulo para comunicar el valor y la profundidad del anillo para comunicar la jerarquía. [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartseries/#setParentLabelLayout) no controla sus etiquetas de anillo.
- Ambos tipos de gráfico usan los mismos niveles de agrupación de categoría y el mismo orden hoja‑padre devuelto por [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartdatapoint/#getDataPointLevels), por lo que el código de construcción de datos y de formato de niveles puede compartirse.
- Los valores de los padres se calculan a partir de sus hojas descendientes. No añada puntos numéricos separados para ramas o troncos.

### **Ordenación y orden de los segmentos**

El motor de disposición del gráfico determina la ubicación final de los rectángulos y segmentos del anillo. Agrupe filas de categoría relacionadas antes de añadirlas, pero no confíe en una posición de rectángulo o ángulo de inicio específico. Si la secuencia lleva significado, inclúyala en las etiquetas o utilice un tipo de gráfico con eje de categoría explícito.

### **Tema y colores fijos**

Los niveles de gráfico sin formato heredan colores del tema de la presentación. El ejemplo usa rellenos RGB explícitos para obtener una salida predecible. Si el gráfico debe seguir los cambios de tema, use colores de esquema en lugar de valores RGB fijos y evite sobrescribir cada nivel. También revise el contraste de la etiqueta tras cambiar el relleno de una rama o tronco.

### **Etiquetas y espacio disponible**

PowerPoint puede ocultar o truncar etiquetas cuando un segmento es demasiado pequeño. Aumentar el tamaño del gráfico, acortar los nombres de categoría o mostrar menos campos de etiqueta suele producir un resultado más claro. Una etiqueta puede combinar el nombre de la categoría, el nombre de la serie y el valor mediante [DataLabelFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/datalabelformat/), pero habilitar todos los campos a menudo dificulta la lectura de los gráficos jerárquicos.

### **Exportación y renderizado**

Guardar en PPTX mantiene el gráfico editable. Cuando Aspose.Slides renderiza la presentación a PDF o a una imagen, los rellenos y ajustes de etiqueta compatibles se renderizan con el gráfico. La sustitución de fuentes y pequeñas diferencias en el espacio disponible pueden alterar el ajuste de líneas o la visibilidad de las etiquetas, por lo que debe instalar las fuentes requeridas y verificar los destinos de exportación importantes.

## **Preguntas frecuentes**

**¿Por qué al cambiar un nivel padre afecta a varias hojas?**

Una rama o tronco es un segmento visual compartido. Su [ChartDataPointLevel](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartdatapointlevel/) puede alcanzarse a través de una hoja descendiente, pero el formato pertenece al segmento padre compartido y no solo a esa hoja.

**¿Por qué falta una etiqueta de datos?**

Primero active los campos necesarios en el objeto [DataLabelFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/datalabelformat/) de la etiqueta. Luego compruebe que el segmento tenga suficiente espacio. El diseño de etiquetas de padres en Treemap, las dimensiones del gráfico, la longitud de la etiqueta, el tamaño de la fuente y el número de campos activados influyen en si una etiqueta puede mostrarse.

**¿Puedo establecer el orden o las coordenadas exactas de los segmentos?**

Puede controlar el orden de las filas de origen y mantener cada grupo contiguo, pero no puede asignar rectángulos de Treemap o ángulos de Sunburst exactos. El motor de disposición calcula esos valores a partir de la jerarquía, los valores y el espacio disponible.

**¿Por qué los colores cambian después de modificar el tema de la presentación?**

Los rellenos basados en el tema están diseñados para seguir la paleta de la presentación. Aplique colores RGB explícitos a los niveles que deben permanecer fijos, o conserve los colores de esquema cuando prefiera adaptar el gráfico a un nuevo tema.

**¿Se preservará el formato personalizado en exportaciones a PDF e imagen?**

Sí, los rellenos y ajustes de etiqueta compatibles se incluyen durante el renderizado. Para obtener resultados consistentes entre sistemas, haga que las fuentes requeridas estén disponibles y pruebe el tamaño final de exportación, ya que el ajuste de etiquetas depende de la disposición.

## **Véase también**

- [Create Treemap charts](/slides/es/python-java/create-chart/#create-tree-map-charts)
- [Create Sunburst charts](/slides/es/python-java/create-chart/#create-sunburst-charts)
- [Export presentation charts](/slides/es/python-java/export-chart/)
- [Manage presentation themes](/slides/es/python-java/presentation-theme/)