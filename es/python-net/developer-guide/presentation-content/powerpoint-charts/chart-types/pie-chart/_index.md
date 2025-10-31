---
title: Personaliza gráficos de pastel en presentaciones con Python
linktitle: Gráfico de pastel
type: docs
url: /es/python-net/pie-chart/
keywords:
- gráfico de pastel
- gestionar gráfico
- personalizar gráfico
- opciones del gráfico
- configuración del gráfico
- opciones de trazado
- color de la porción
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Aprende cómo crear y personalizar gráficos de pastel en Python con Aspose.Slides, exportables a PowerPoint y OpenDocument, impulsando tu narración de datos en segundos."
---

## **Opciones de segunda trama para Pie of Pie y Bar of Pie Chart**
Aspose.Slides for Python via .NET ahora admite opciones de segunda trama para gráficos Pie of Pie o Bar of Pie. En este tema, veremos con un ejemplo cómo especificar estas opciones usando Aspose.Slides. Para especificar las propiedades, siga los pasos a continuación:

1. Instanciar el objeto de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Añadir un gráfico en la diapositiva.
1. Especificar las opciones de segunda trama del gráfico.
1. Guardar la presentación en disco.

En el ejemplo a continuación, hemos establecido diferentes propiedades del gráfico Pie of Pie.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Crea una instancia de la clase Presentation
with slides.Presentation() as presentation:
    # Agrega un gráfico en la diapositiva
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 500, 400)
        
    # Establece diferentes propiedades
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True
    chart.chart_data.series[0].parent_series_group.second_pie_size = 149
    chart.chart_data.series[0].parent_series_group.pie_split_by = charts.PieSplitType.BY_PERCENTAGE
    chart.chart_data.series[0].parent_series_group.pie_split_position = 53

    # Guarda la presentación en disco
    presentation.save("SecondPlotOptionsforCharts_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Establecer colores automáticos de las porciones del gráfico de pastel**
Aspose.Slides for Python via .NET proporciona una API sencilla para establecer colores automáticos de las porciones del gráfico de pastel. El código de ejemplo aplica la configuración de las propiedades mencionadas.

1. Crear una instancia de la clase Presentation.
1. Acceder a la primera diapositiva.
1. Añadir un gráfico con datos predeterminados.
1. Establecer el título del gráfico.
1. Configurar la primera serie para mostrar valores.
1. Establecer el índice de la hoja de datos del gráfico.
1. Obtener la hoja de datos del gráfico.
1. Eliminar las series y categorías generadas por defecto.
1. Añadir nuevas categorías.
1. Añadir una nueva serie.

Guardar la presentación modificada en un archivo PPTX.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Instancia la clase Presentation que representa un archivo PPTX
with slides.Presentation() as presentation:
	# Accede a la primera diapositiva
	slide = presentation.slides[0]

	# Añade un gráfico con datos predeterminados
	chart = slide.shapes.add_chart(charts.ChartType.PIE, 100, 100, 400, 400)

	# Configura el título del gráfico
	chart.chart_title.add_text_frame_for_overriding("Sample Title")
	chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = 1
	chart.chart_title.height = 20
	chart.has_title = True

	# Configura la primera serie para mostrar valores
	chart.chart_data.series[0].labels.default_data_label_format.show_value = True

	# Configura el índice de la hoja de datos del gráfico
	defaultWorksheetIndex = 0

	# Obtiene la hoja de datos del gráfico
	fact = chart.chart_data.chart_data_workbook

	# Elimina las series y categorías generadas por defecto
	chart.chart_data.series.clear()
	chart.chart_data.categories.clear()

	# Añadiendo nuevas categorías
	chart.chart_data.categories.add(fact.get_cell(0, 1, 0, "First Qtr"))
	chart.chart_data.categories.add(fact.get_cell(0, 2, 0, "2nd Qtr"))
	chart.chart_data.categories.add(fact.get_cell(0, 3, 0, "3rd Qtr"))

	# Añadiendo una nueva serie
	series = chart.chart_data.series.add(fact.get_cell(0, 0, 1, "Series 1"), chart.type)

	# Ahora rellenando los datos de la serie
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))

	series.parent_series_group.is_color_varied = True
	presentation.save("Pie.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**¿Se admiten las variaciones 'Pie of Pie' y 'Bar of Pie'?**

Sí, la biblioteca [soporta](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) una trama secundaria para gráficos de pastel, incluidos los tipos 'Pie of Pie' y 'Bar of Pie'.

**¿Puedo exportar solo el gráfico como imagen (por ejemplo, PNG)?**

Sí, puedes [exportar el propio gráfico como una imagen](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/get_image/) (como PNG) sin toda la presentación.