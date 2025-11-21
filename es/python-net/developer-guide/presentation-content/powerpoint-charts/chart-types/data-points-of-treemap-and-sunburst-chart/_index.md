---
title: Personalizar puntos de datos en gráficos de Treemap y Sunburst en Python
linktitle: Puntos de datos en gráficos de Treemap y Sunburst
type: docs
url: /es/python-net/data-points-of-treemap-and-sunburst-chart/
keywords:
- gráfico treemap
- gráfico sunburst
- punto de datos
- color de etiqueta
- color de rama
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Aprenda cómo administrar puntos de datos en gráficos de treemap y sunburst con Aspose.Slides for Python via .NET, compatible con los formatos PowerPoint y OpenDocument."
---

## **Introducción**

Entre los demás tipos de gráficos de PowerPoint, hay dos jerárquicos—**Treemap** y **Sunburst** (también conocido como Sunburst Graph, Sunburst Diagram, Radial Chart, Radial Graph o Multi-Level Pie Chart). Estos gráficos muestran datos jerárquicos organizados como un árbol, desde las hojas hasta la parte superior de una rama. Las hojas se definen por los puntos de datos de la serie, y cada nivel de agrupación anidado subsiguiente se define por la categoría correspondiente. Aspose.Slides for Python via .NET le permite dar formato a los puntos de datos de los gráficos Sunburst y Treemap en Python.

Aquí hay un gráfico Sunburst donde los datos en la columna Series1 definen los nodos hoja, mientras que las demás columnas definen los puntos de datos jerárquicos:

![Ejemplo de gráfico Sunburst](sunburst_example.png)

Comencemos agregando un nuevo gráfico Sunburst a la presentación:
```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.SUNBURST, 30, 30, 450, 400)
```


{{% alert color="primary" title="Ver también" %}}
- [**Crear gráficos Sunburst**](/slides/es/python-net/create-chart/#create-sunburst-charts)
{{% /alert %}}

Si necesita dar formato a los puntos de datos del gráfico, use las siguientes API:

[ChartDataPointLevelsManager](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevelsmanager/), [ChartDataPointLevel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/), y la propiedad [ChartDataPoint.data_point_levels](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/data_point_levels/). Proporcionan acceso al formato de los puntos de datos en gráficos Treemap y Sunburst. [ChartDataPointLevelsManager](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevelsmanager/) se usa para acceder a categorías de varios niveles; representa un contenedor de objetos [ChartDataPointLevel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/). Es esencialmente un contenedor alrededor de [ChartCategoryLevelsManager](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategorylevelsmanager/) con propiedades adicionales específicas para los puntos de datos. El tipo [ChartDataPointLevel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/) expone dos propiedades—[format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/format/) y [label](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/label/)—que proporcionan acceso a la configuración correspondiente.

## **Mostrar valores de los puntos de datos**

Esta sección muestra cómo mostrar el valor para puntos de datos individuales en gráficos Treemap y Sunburst. Verá cómo habilitar etiquetas de valor para puntos seleccionados.

Mostrar el valor del punto de datos "Leaf 4":
```py
data_points = chart.chart_data.series[0].data_points
data_points[3].data_point_levels[0].label.data_label_format.show_value = True
```


![Valor del punto de datos](data_point_value.png)

## **Establecer etiquetas y colores para los puntos de datos**

Esta sección muestra cómo establecer etiquetas y colores personalizados para puntos de datos individuales en gráficos Treemap y Sunburst. Aprenderá a acceder a un punto de datos específico, asignar una etiqueta y aplicar un relleno sólido para resaltar nodos importantes.

Establezca la etiqueta de datos "Branch 1" para que muestre el nombre de la serie ("Series1") en lugar del nombre de la categoría, y luego establezca el color del texto a amarillo:
```py
branch1_label = data_points[0].data_point_levels[2].label
branch1_label.data_label_format.show_category_name = False
branch1_label.data_label_format.show_series_name = True

branch1_label.data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
branch1_label.data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.yellow
```


![Etiqueta y color del punto de datos](data_point_color.png)

## **Establecer colores de rama para los puntos de datos**

Use colores de rama para controlar cómo se agrupan visualmente los nodos padre e hijo en gráficos Treemap y Sunburst. Esta sección muestra cómo establecer un color de rama personalizado para un punto de datos específico, de modo que pueda resaltar subárboles importantes y mejorar la legibilidad del gráfico.

Cambiar el color de la rama "Stem 4":
```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.SUNBURST, 30, 30, 450, 400)
    data_points = chart.chart_data.series[0].data_points

    stem4_branch = data_points[9].data_point_levels[1]
    
    stem4_branch.format.fill.fill_type = slides.FillType.SOLID
    stem4_branch.format.fill.solid_fill_color.color = draw.Color.red
      
    presentation.save("branch_color.pptx", slides.export.SaveFormat.PPTX)
```


![Color de rama](branch_color.png)

## **Preguntas frecuentes**

**¿Puedo cambiar el orden (clasificación) de los segmentos en Sunburst/Treemap?**

No. PowerPoint clasifica los segmentos automáticamente (normalmente por valores descendentes, en sentido horario). Aspose.Slides refleja este comportamiento: no puede cambiar el orden directamente; lo logra preprocesando los datos.

**¿Cómo afecta el tema de la presentación a los colores de los segmentos y etiquetas?**

Los colores del gráfico heredan el [tema/paleta](/slides/es/python-net/presentation-theme/) de la presentación a menos que establezca explícitamente rellenos/fuentes. Para obtener resultados consistentes, fije rellenos sólidos y formato de texto en los niveles requeridos.

**¿La exportación a PDF/PNG conservará los colores de rama personalizados y la configuración de etiquetas?**

Sí. Al exportar la presentación, la configuración del gráfico (rellenos, etiquetas) se conserva en los formatos de salida porque Aspose.Slides renderiza con el formato del gráfico aplicado.

**¿Puedo calcular las coordenadas reales de una etiqueta/elemento para colocar una superposición personalizada sobre el gráfico?**

Sí. Después de validar el diseño del gráfico, `actual_x`/`actual_y` están disponibles para los elementos (por ejemplo, un [DataLabel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/)), lo que ayuda con la posición precisa de superposiciones.