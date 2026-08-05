---
title: Personalizar puntos de datos en gráficos Treemap y Sunburst en Python
linktitle: Puntos de datos en gráficos Treemap y Sunburst
type: docs
url: /es/python-net/data-points-of-treemap-and-sunburst-chart/
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
- Aspose.Slides
description: "Aprenda cómo crear datos jerárquicos y personalizar niveles, etiquetas y colores en gráficos Treemap y Sunburst con Aspose.Slides para Python mediante .NET."
---
## **Descripción general**

Los gráficos Treemap y Sunburst muestran el mismo tipo de datos jerárquicos, pero utilizan disposiciones diferentes. Un Treemap representa la jerarquía mediante rectángulos anidados cuyo área representa los valores de las hojas. Un Sunburst la muestra como anillos concéntricos: los grupos de nivel superior están cerca del centro y las categorías de hoja están en el anillo exterior.

En Aspose.Slides for Python via .NET, cada valor numérico es un [ChartDataPoint](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartdatapoint/). Su colección [ChartDataPoint.data_point_levels](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartdatapoint/data_point_levels/) permite acceder a la hoja y a sus grupos padre. Este artículo explica esa asignación y muestra cómo crear y dar formato a ambos tipos de gráfico a partir de los mismos datos de ejemplo.

![Gráfico de Treemap con ramas Consumer y Business](treemap-hierarchy.png)

![Gráfico de Sunburst con la misma jerarquía Consumer y Business](sunburst-hierarchy.png)

## **Comprender categorías, puntos de datos y niveles**

El ejemplo utilizado a continuación tiene tres niveles de categoría y una serie numérica:

| Rama | Eje | Hoja | Ingresos |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

Cada fila crea una categoría hoja y un punto de datos. Los niveles de agrupación de la categoría describen la ruta desde esa hoja hasta sus padres. Para la primera fila, la ruta es `Consumer > Computers > Laptops`.

Los índices en [ChartDataPoint.data_point_levels](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartdatapoint/data_point_levels/) se cuentan desde la hoja hacia arriba:

| Índice de `data_point_levels` | Nivel lógico | Representación en Treemap | Representación en Sunburst |
| ---: | --- | --- | --- |
| `0` | Hoja | Rectángulo de valor | Segmento del anillo exterior |
| `1` | Eje | Rectángulo o encabezado padre | Segmento del anillo medio |
| `2` | Rama | Rectángulo o encabezado de nivel superior | Segmento del anillo interno |

Este orden es el mismo para ambos tipos de gráfico aunque sus disposiciones visuales difieran. Un segmento padre es compartido por varias hojas. Para formatearlo, utilice el nivel correspondiente del primer punto de datos del grupo. Por ejemplo, la rama `Consumer` comienza con el punto `Laptops`, mientras que el eje `Software` comienza con el punto `Licenses`. Mantener referencias a esos puntos es más claro y seguro que usar expresiones sin explicación como `data_points[0]` o `data_points[6]`.

## **Crear y personalizar ambos tipos de gráfico**

El siguiente ejemplo completo crea un Treemap en la primera diapositiva y un Sunburst en la segunda diapositiva. Construye la jerarquía, muestra el valor de `Tablets`, aplica colores fijos a niveles seleccionados, da formato a una etiqueta de rama y guarda la presentación.

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts


def set_solid_fill(fill_format, color):
    fill_format.fill_type = slides.FillType.SOLID
    fill_format.solid_fill_color.color = color


def add_hierarchy_chart(slide, chart_type):
    worksheet_index = 0
    leaf_level_index = 0
    stem_level_index = 1
    branch_level_index = 2

    chart = slide.shapes.add_chart(chart_type, 40, 40, 640, 440)
    chart.has_title = False
    chart.has_legend = False
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(worksheet_index)

    def add_category(row_index, leaf_name):
        category_cell = workbook.get_cell(worksheet_index, row_index, 2, leaf_name)
        return chart.chart_data.categories.add(category_cell)

    # Añadir las categorías hoja. Un elemento de agrupación se establece solo cuando comienza un nuevo grupo;
    # las categorías siguientes permanecen en ese grupo hasta que se establezca otro elemento.
    laptops_category = add_category(1, "Laptops")
    laptops_category.grouping_levels.set_grouping_item(stem_level_index, "Computers")
    laptops_category.grouping_levels.set_grouping_item(branch_level_index, "Consumer")

    add_category(2, "Desktops")

    phones_category = add_category(3, "Phones")
    phones_category.grouping_levels.set_grouping_item(stem_level_index, "Mobile")

    add_category(4, "Tablets")

    consulting_category = add_category(5, "Consulting")
    consulting_category.grouping_levels.set_grouping_item(stem_level_index, "Services")
    consulting_category.grouping_levels.set_grouping_item(branch_level_index, "Business")

    add_category(6, "Support")

    licenses_category = add_category(7, "Licenses")
    licenses_category.grouping_levels.set_grouping_item(stem_level_index, "Software")

    add_category(8, "Subscriptions")

    series_name_cell = workbook.get_cell(worksheet_index, 0, 3, "Revenue")
    series = chart.chart_data.series.add(series_name_cell, chart_type)
    series.labels.default_data_label_format.show_category_name = True

    def add_data_point(row_index, value):
        value_cell = workbook.get_cell(worksheet_index, row_index, 3, value)

        if chart_type == charts.ChartType.TREEMAP:
            return series.data_points.add_data_point_for_treemap_series(value_cell)

        return series.data_points.add_data_point_for_sunburst_series(value_cell)

    laptops_data_point = add_data_point(1, 12)
    add_data_point(2, 8)
    add_data_point(3, 15)
    tablets_data_point = add_data_point(4, 6)
    add_data_point(5, 10)
    add_data_point(6, 7)
    licenses_data_point = add_data_point(7, 11)
    add_data_point(8, 14)

    # Mostrar la categoría y el valor en la hoja Tablets.
    tablets_label_format = tablets_data_point.data_point_levels[leaf_level_index].label.data_label_format
    tablets_label_format.show_category_name = True
    tablets_label_format.show_value = True
    tablets_label_format.separator = "\n"
    tablets_label_format.number_format = "$0"

    # Formatear la rama Consumer a través de la primera hoja de esa rama.
    consumer_branch_level = laptops_data_point.data_point_levels[branch_level_index]
    consumer_branch_fill = consumer_branch_level.format.fill
    consumer_branch_color = drawing.Color.from_argb(31, 78, 121)
    set_solid_fill(consumer_branch_fill, consumer_branch_color)

    consumer_label_format = consumer_branch_level.label.data_label_format
    consumer_label_format.show_category_name = True
    consumer_label_format.show_series_name = False
    consumer_label_text_fill = consumer_label_format.text_format.portion_format.fill_format
    set_solid_fill(consumer_label_text_fill, drawing.Color.white)

    # Formatear el eje Software a través de la primera hoja de ese eje.
    software_stem_level = licenses_data_point.data_point_levels[stem_level_index]
    software_stem_fill = software_stem_level.format.fill
    software_stem_color = drawing.Color.from_argb(112, 173, 71)
    set_solid_fill(software_stem_fill, software_stem_color)

    # parent_label_layout afecta a las etiquetas de los padres en Treemap; Sunburst usa segmentos de anillo.
    if chart_type == charts.ChartType.TREEMAP:
        series.parent_label_layout = charts.ParentLabelLayoutType.OVERLAPPING


with slides.Presentation() as presentation:
    treemap_slide = presentation.slides[0]
    add_hierarchy_chart(treemap_slide, charts.ChartType.TREEMAP)

    layout_slide = presentation.layout_slides[0]
    sunburst_slide = presentation.slides.add_empty_slide(layout_slide)
    add_hierarchy_chart(sunburst_slide, charts.ChartType.SUNBURST)

    presentation.save("hierarchical-charts.pptx", slides.export.SaveFormat.PPTX)
```

Las celdas de categoría y las celdas de valor utilizan la misma fila de hoja de cálculo, por lo que sus posiciones en la colección permanecen alineadas. Cuando se trabaja con un gráfico existente en lugar de crear uno nuevo, inspeccione primero las filas de categoría y almacene referencias con nombre a los puntos de datos y niveles que pretende formatear.

## **Comportamiento y consideraciones prácticas**

### **Diferencias entre Treemap y Sunburst**

- Un Treemap usa el área para comunicar el valor y rectángulos anidados para comunicar la jerarquía. La propiedad [ChartSeries.parent_label_layout](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartseries/parent_label_layout/) controla cómo aparecen las etiquetas de los padres en este tipo de gráfico.
- Un Sunburst usa el ángulo para comunicar el valor y la profundidad del anillo para comunicar la jerarquía. [ChartSeries.parent_label_layout](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartseries/parent_label_layout/) no controla sus etiquetas de anillo.
- Ambos tipos de gráfico utilizan los mismos niveles de agrupación de categorías y el mismo orden hoja‑padre en `data_point_levels`, por lo que el código de construcción de datos y de formato de niveles puede compartirse.
- Los valores de los padres se calculan a partir de sus hojas descendientes. No añada puntos numéricos separados para ramas o ejes.

### **Ordenamiento y secuencia de segmentos**

El motor de disposición del gráfico determina la ubicación final de los rectángulos y los segmentos del anillo. Agrupe filas de categorías relacionadas antes de añadirlas, pero no confíe en una posición de rectángulo o ángulo de inicio específico. Si la secuencia tiene significado, inclúyala en las etiquetas o utilice un tipo de gráfico con un eje de categoría explícito.

### **Tema y colores fijos**

Los niveles de gráfico sin formato heredan colores del tema de la presentación. El ejemplo usa rellenos RGB explícitos para obtener una salida predecible. Si el gráfico debe seguir los cambios de tema, utilice colores de esquema en lugar de valores RGB fijos y evite sobrescribir cada nivel. También compruebe el contraste de la etiqueta después de cambiar el relleno de una rama o eje.

### **Etiquetas y espacio disponible**

PowerPoint puede ocultar o truncar etiquetas cuando un segmento es demasiado pequeño. Aumentar el tamaño del gráfico, acortar los nombres de categoría o mostrar menos campos de etiqueta suele producir un resultado más claro. Una etiqueta puede combinar el nombre de la categoría, el nombre de la serie y el valor mediante [DataLabelFormat](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/datalabelformat/), pero habilitar todos los campos a menudo dificulta la lectura de los gráficos jerárquicos.

### **Exportación y renderizado**

Guardar en PPTX mantiene el gráfico editable. Cuando Aspose.Slides renderiza la presentación a PDF o a una imagen, los rellenos y configuraciones de etiqueta compatibles se renderizan con el gráfico. La sustitución de fuentes y pequeñas diferencias en el espacio de disposición disponible pueden cambiar el ajuste de líneas o la visibilidad de las etiquetas, por lo que debe instalar las fuentes requeridas y verificar los destinos de exportación más importantes.

## **Preguntas frecuentes**

**¿Por qué al cambiar un nivel padre se afecta a varias hojas?**

Una rama o eje es un segmento visual compartido. Su [ChartDataPointLevel](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartdatapointlevel/) puede alcanzarse a través de una hoja descendiente, pero el formato pertenece al segmento padre compartido y no solo a esa hoja.

**¿Por qué falta una etiqueta de datos?**

Primero habilite los campos necesarios en el objeto [DataLabelFormat](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/datalabelformat/) de la etiqueta. Luego verifique que el segmento disponga de suficiente espacio. La disposición de etiquetas de padre en Treemap, las dimensiones del gráfico, la longitud de la etiqueta, el tamaño de fuente y el número de campos habilitados afectan si una etiqueta puede mostrarse.

**¿Puedo establecer el orden exacto o las coordenadas de los segmentos?**

Puede controlar el orden de las filas de origen y mantener cada grupo contiguo, pero no puede asignar rectángulos exactos de Treemap ni ángulos exactos de Sunburst. El motor de disposición del gráfico los calcula a partir de la jerarquía, los valores y el espacio disponible.

**¿Por qué los colores cambian después de modificar el tema de la presentación?**

Los rellenos basados en el tema están diseñados para seguir la paleta de la presentación. Aplique colores RGB explícitos a los niveles que deben permanecer fijos, o mantenga colores de esquema cuando prefiera adaptarse a un nuevo tema.

**¿Se preservará el formato personalizado en exportaciones a PDF e imágenes?**

Sí, los rellenos de gráfico y la configuración de etiquetas compatibles se incluyen durante el renderizado. Para obtener resultados consistentes entre sistemas, haga que las fuentes requeridas estén disponibles y pruebe el tamaño final de exportación, ya que el ajuste de etiquetas depende de la disposición.

## **Véase también**

- [Create Treemap charts](/slides/es/python-net/create-chart/#create-tree-map-charts)
- [Create Sunburst charts](/slides/es/python-net/create-chart/#create-sunburst-charts)
- [Export presentation charts](/slides/es/python-net/export-chart/)
- [Manage presentation themes](/slides/es/python-net/presentation-theme/)