---
title: Gráfico de Pastel
type: docs
url: /python-net/pie-chart/
keywords: "Gráfico de pastel, opciones de gráfico, colores de rebanadas, presentación de PowerPoint, Python, Aspose.Slides para Python a través de .NET"
description: "Opciones de gráfico de pastel y colores de rebanadas en la presentación de PowerPoint en Python"
---

## **Segundas Opciones de Gráfico para Gráfico de Pastel de Pastel y Gráfico de Pastel de Barra**
Aspose.Slides para Python a través de .NET ahora admite segundas opciones de gráfico para el gráfico de Pastel de Pastel o Gráfico de Pastel de Barra. En este tema, veremos con un ejemplo cómo especificar estas opciones utilizando Aspose.Slides. Para especificar las propiedades, siga los pasos a continuación:

1. Instancie el objeto de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Agregue un gráfico en la diapositiva.
1. Especifique las segundas opciones de gráfico.
1. Escriba la presentación en el disco.

En el ejemplo dado a continuación, hemos establecido diferentes propiedades del gráfico de Pastel de Pastel.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Crear una instancia de la clase Presentation
with slides.Presentation() as presentation:
    # Agregar gráfico en la diapositiva
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 500, 400)
        
    # Establecer diferentes propiedades
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True
    chart.chart_data.series[0].parent_series_group.second_pie_size = 149
    chart.chart_data.series[0].parent_series_group.pie_split_by = charts.PieSplitType.BY_PERCENTAGE
    chart.chart_data.series[0].parent_series_group.pie_split_position = 53

    # Escribir la presentación en el disco
    presentation.save("SegundasOpcionesDeGráfico.pptx", slides.export.SaveFormat.PPTX)
```

## **Establecer Colores de Rebanadas de Gráfico de Pastel Automáticos**
Aspose.Slides para Python a través de .NET proporciona una API simple para establecer colores de rebanadas de gráfico de pastel automáticos. El código de muestra aplica el establecimiento de las propiedades mencionadas anteriormente.

1. Crear una instancia de la clase Presentation.
1. Acceder a la primera diapositiva.
1. Agregar gráfico con datos predeterminados.
1. Establecer el Título del gráfico.
1. Establecer la primera serie para Mostrar Valores.
1. Establecer el índice de la hoja de datos del gráfico.
1. Obtener la hoja de trabajo de datos del gráfico.
1. Eliminar series y categorías generadas por defecto.
1. Agregar nuevas categorías.
1. Agregar nuevas series.

Escriba la presentación modificada en un archivo PPTX.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanciar la clase Presentation que representa el archivo PPTX
with slides.Presentation() as presentation:
	# Acceder a la primera diapositiva
	slide = presentation.slides[0]

	# Agregar gráfico con datos predeterminados
	chart = slide.shapes.add_chart(charts.ChartType.PIE, 100, 100, 400, 400)

	# Estableciendo el Título del gráfico
	chart.chart_title.add_text_frame_for_overriding("Título de Ejemplo")
	chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = 1
	chart.chart_title.height = 20
	chart.has_title = True

	# Establecer la primera serie para Mostrar Valores
	chart.chart_data.series[0].labels.default_data_label_format.show_value = True

	# Estableciendo el índice de la hoja de datos del gráfico
	defaultWorksheetIndex = 0

	# Obteniendo la hoja de trabajo de datos del gráfico
	fact = chart.chart_data.chart_data_workbook

	# Eliminar series y categorías generadas por defecto
	chart.chart_data.series.clear()
	chart.chart_data.categories.clear()

	# Agregar nuevas categorías
	chart.chart_data.categories.add(fact.get_cell(0, 1, 0, "Primer Trimestre"))
	chart.chart_data.categories.add(fact.get_cell(0, 2, 0, "Segundo Trimestre"))
	chart.chart_data.categories.add(fact.get_cell(0, 3, 0, "Tercer Trimestre"))

	# Agregar nuevas series
	series = chart.chart_data.series.add(fact.get_cell(0, 0, 1, "Serie 1"), chart.type)

	# Ahora poblando los datos de la serie
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))

	series.parent_series_group.is_color_varied = True
	presentation.save("Pastel.pptx", slides.export.SaveFormat.PPTX)
```