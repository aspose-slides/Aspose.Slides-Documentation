---
title: Puntos de Datos del Gráfico Treemap y Sunburst
type: docs
url: /es/python-net/data-points-of-treemap-and-sunburst-chart/
keywords: "Gráfico Sunburst, presentación de PowerPoint, Python, Aspose.Slides para Python a través de .NET"
description: "Agregar gráfico Sunburst en presentación de PowerPoint en Python"
---

Entre otros tipos de gráficos de PowerPoint, hay dos tipos "jerárquicos": **Treemap** y **Sunburst** (gráfico también conocido como Gráfico Sunburst, Diagrama Sunburst, Gráfico Radial o Gráfico Circular de Múltiples Niveles). Estos gráficos muestran datos jerárquicos organizados como un árbol - desde las hojas hasta la parte superior de la rama. Las hojas están definidas por los puntos de datos de la serie, y cada nivel de agrupación anidada subsiguiente está definido por la categoría correspondiente. Aspose.Slides para Python a través de .NET permite formatear los puntos de datos de los gráficos Sunburst y Treemap en Python.

Aquí hay un gráfico Sunburst, donde los datos en la columna Series1 definen los nodos hoja, mientras que otras columnas definen los puntos de datos jerárquicos:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Comencemos añadiendo un nuevo gráfico Sunburst a la presentación:



```py
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.SUNBURST, 100, 100, 450, 400)
```

{{% alert color="primary" title="Ver también" %}} 
- [**Creando Gráfico Sunburst**](/slides/es/python-net/adding-charts/#addingcharts-creatingsunburstchart)
{{% /alert %}}


Si hay necesidad de formatear los puntos de datos del gráfico, debemos usar lo siguiente:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/IChartDataPointLevelsManager/), 
[IChartDataPointLevel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatapointlevel/) clases 
y [**IChartDataPoint.DataPointLevels**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatapoint/) propiedad 
proporcionan acceso para formatear los puntos de datos de los gráficos Treemap y Sunburst. 
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/IChartDataPointLevelsManager/) 
se usa para acceder a categorías de múltiples niveles - representa el contenedor de 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/IChartDataPointLevel/) objetos. 
Básicamente, es un envoltorio para 
[**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/IChartCategoryLevelsManager/) con 
las propiedades añadidas específicas para los puntos de datos. 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/IChartDataPointLevel/) clase tiene 
dos propiedades: [**Format**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatapointlevel/) y 
[**DataLabel** ](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatapointlevel/)que 
proporcionan acceso a los ajustes correspondientes.
## **Mostrar Valor del Punto de Datos**
Mostrar el valor del punto de datos "Hoja 4":



```py
    dataPoints = chart.chart_data.series[0].data_points
    dataPoints[3].data_point_levels[0].label.data_label_format.show_value = True
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)
## **Establecer Etiqueta y Color del Punto de Datos**
Establecer la etiqueta de datos "Rama 1" para mostrar el nombre de la serie ("Series1") en lugar del nombre de la categoría. Luego, establecer el color del texto en amarillo:



```py
    branch1Label = dataPoints[0].data_point_levels[2].label
    branch1Label.data_label_format.show_category_name = False
    branch1Label.data_label_format.show_series_name = True

    branch1Label.data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    branch1Label.data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.yellow
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)
## **Establecer Color de Rama del Punto de Datos**

Cambiar el color de la rama "Tallo 4":

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.SUNBURST, 100, 100, 450, 400)
    dataPoints = chart.chart_data.series[0].data_points

    stem4branch = dataPoints[9].data_point_levels[1]
    
    stem4branch.format.fill.fill_type = slides.FillType.SOLID
    stem4branch.format.fill.solid_fill_color.color = draw.Color.red
      
    pres.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)
