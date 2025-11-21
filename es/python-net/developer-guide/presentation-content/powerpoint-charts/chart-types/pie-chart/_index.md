---
title: Personalizar gráficos de pastel en presentaciones con Python
linktitle: Gráfico de pastel
type: docs
url: /es/python-net/pie-chart/
keywords:
- gráfico de pastel
- gestionar gráfico
- personalizar gráfico
- opciones de gráfico
- configuración de gráfico
- opciones de trazado
- color de porción
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Aprenda cómo crear y personalizar gráficos de pastel en Python con Aspose.Slides, exportables a PowerPoint y OpenDocument, impulsando su narrativa de datos en segundos."
---

## **Opciones de Segunda Serie para Gráficos de Pie de Pie y Barra de Pie**
Aspose.Slides para Python a través de .NET ahora admite las opciones de segunda serie para los gráficos Pie de Pie o Barra de Pie. En este tema, veremos con un ejemplo cómo especificar estas opciones usando Aspose.Slides. Para especificar las propiedades, siga los pasos a continuación:

1. Instanciar el objeto de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Agregar un gráfico en la diapositiva.
1. Especificar las opciones de segunda serie del gráfico.
1. Guardar la presentación en disco.

En el ejemplo que se muestra a continuación, hemos configurado diferentes propiedades del gráfico Pie de Pie.
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

    # Guardar la presentación en disco
    presentation.save("SecondPlotOptionsforCharts_out.pptx", slides.export.SaveFormat.PPTX)
```





## **Establecer Colores Automáticos de Rebanadas del Gráfico de Pie**
Aspose.Slides para Python a través de .NET proporciona una API simple para establecer colores automáticos de las rebanadas del gráfico de pie. El código de ejemplo aplica la configuración de las propiedades mencionadas.

1. Crear una instancia de la clase Presentation.
1. Acceder a la primera diapositiva.
1. Agregar un gráfico con datos predeterminados.
1. Establecer el título del gráfico.
1. Configurar la primera serie para Mostrar Valores.
1. Establecer el índice de la hoja de datos del gráfico.
1. Obtener la hoja de cálculo de datos del gráfico.
1. Eliminar las series y categorías generadas por defecto.
1. Agregar nuevas categorías.
1. Agregar una nueva serie.

Guardar la presentación modificada en un archivo PPTX.
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

	# Instanciar la clase Presentation que representa un archivo PPTX
with slides.Presentation() as presentation:
		# Acceder a la primera diapositiva
		slide = presentation.slides[0]

		# Añadir gráfico con datos predeterminados
		chart = slide.shapes.add_chart(charts.ChartType.PIE, 100, 100, 400, 400)

		# Configurar el título del gráfico
	(chart.chart_title.add_text_frame_for_overriding("Sample Title"))
	chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = 1
	chart.chart_title.height = 20
	chart.has_title = True

		# Establecer la primera serie para Mostrar Valores
		chart.chart_data.series[0].labels.default_data_label_format.show_value = True

		# Configurar el índice de la hoja de datos del gráfico
		defaultWorksheetIndex = 0

		# Obtener la hoja de cálculo de datos del gráfico
		fact = chart.chart_data.chart_data_workbook

		# Eliminar series y categorías generadas por defecto
		chart.chart_data.series.clear()
		chart.chart_data.categories.clear()

		# Añadir nuevas categorías
		chart.chart_data.categories.add(fact.get_cell(0, 1, 0, "First Qtr"))
		chart.chart_data.categories.add(fact.get_cell(0, 2, 0, "2nd Qtr"))
		chart.chart_data.categories.add(fact.get_cell(0, 3, 0, "3rd Qtr"))

		# Añadir nuevas series
		series = chart.chart_data.series.add(fact.get_cell(0, 0, 1, "Series 1"), chart.type)

		# Ahora poblar los datos de la serie
		series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
		series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
		series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))

		series.parent_series_group.is_color_varied = True
		presentation.save("Pie.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**¿Se admiten las variantes 'Pie of Pie' y 'Bar of Pie'?**

Sí, la biblioteca [admite](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) una segunda serie para gráficos de pastel, incluidas los tipos 'Pie of Pie' y 'Bar of Pie'.

**¿Puedo exportar solo el gráfico como una imagen (por ejemplo, PNG)?**

Sí, puede [exportar el propio gráfico como una imagen](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/get_image/) (por ejemplo PNG) sin toda la presentación.