---
title: Leyenda del Gráfico
type: docs
url: /es/python-net/chart-legend/
keywords: "Leyenda del gráfico, tamaño de fuente de la leyenda, presentación de PowerPoint, Python, Aspose.Slides para Python a través de .NET"
description: "Configurar la posición y el tamaño de fuente de la leyenda del gráfico en presentaciones de PowerPoint en Python"
---

## **Posicionamiento de la Leyenda**
Para establecer las propiedades de la leyenda. Por favor, siga los pasos a continuación:

- Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
- Obtener referencia de la diapositiva.
- Agregar un gráfico en la diapositiva.
- Configurar las propiedades de la leyenda.
- Escribir la presentación como un archivo PPTX.

En el ejemplo dado a continuación, hemos establecido la posición y el tamaño para la leyenda del gráfico.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Crear una instancia de la clase Presentation
with slides.Presentation() as presentation:

    # Obtener referencia de la diapositiva
    slide = presentation.slides[0]

    # Agregar un gráfico de columnas agrupadas en la diapositiva
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 500)

    # Configurar Propiedades de la Leyenda
    chart.legend.x = 50 / chart.width
    chart.legend.y = 50 / chart.height
    chart.legend.width = 100 / chart.width
    chart.legend.height = 100 / chart.height

    # Escribir la presentación en el disco
    presentation.save("Legend_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Configurar Tamaño de Fuente de la Leyenda**
Aspose.Slides para Python a través de .NET permite a los desarrolladores establecer el tamaño de fuente de la leyenda. Por favor, siga los pasos a continuación:

- Instanciar la clase `Presentation`.
- Crear el gráfico predeterminado.
- Establecer el Tamaño de Fuente.
- Establecer el valor mínimo del eje.
- Establecer el valor máximo del eje.
- Escribir la presentación en el disco.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

	chart.legend.text_format.portion_format.font_height = 20
	chart.axes.vertical_axis.is_automatic_min_value = False
	chart.axes.vertical_axis.min_value = -5
	chart.axes.vertical_axis.is_automatic_max_value = False
	chart.axes.vertical_axis.max_value = 10

	pres.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Configurar Tamaño de Fuente de la Leyenda Individual**
Aspose.Slides para Python a través de .NET permite a los desarrolladores establecer el tamaño de fuente de las entradas individuales de la leyenda. Por favor, siga los pasos a continuación:

- Instanciar la clase `Presentation`.
- Crear el gráfico predeterminado.
- Acceder a la entrada de la leyenda.
- Establecer el Tamaño de Fuente.
- Establecer el valor mínimo del eje.
- Establecer el valor máximo del eje.
- Escribir la presentación en el disco.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw
 
 
with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
	tf = chart.legend.entries[1].text_format

	tf.portion_format.font_bold = 1
	tf.portion_format.font_height = 20
	tf.portion_format.font_italic = 1
	tf.portion_format.fill_format.fill_type = slides.FillType.SOLID 
	tf.portion_format.fill_format.solid_fill_color.color = draw.Color.blue

	pres.save("output.pptx", slides.export.SaveFormat.PPTX)
```