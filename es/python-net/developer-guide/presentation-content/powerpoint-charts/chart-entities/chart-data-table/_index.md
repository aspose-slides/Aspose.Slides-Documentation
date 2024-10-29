---
title: Tabla de Datos del Gráfico
type: docs
url: /es/python-net/chart-data-table/
keywords: "Propiedades de fuente, tabla de datos del gráfico, presentación de PowerPoint, Python, Aspose.Slides para Python a través de .NET"
description: "Establecer propiedades de fuente para la tabla de datos del gráfico en presentaciones de PowerPoint en Python"
---

## **Establecer Propiedades de Fuente para la Tabla de Datos del Gráfico**
Aspose.Slides para Python a través de .NET proporciona soporte para cambiar el color de las categorías en una serie de colores.

1. Instanciar [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) como objeto de clase.
1. Agregar gráfico en la diapositiva.
1. Establecer tabla de gráfico.
1. Establecer altura de fuente.
1. Guardar presentación modificada.

A continuación se presenta un ejemplo de muestra.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

	chart.has_data_table = True

	chart.chart_data_table.text_format.portion_format.font_bold = 1
	chart.chart_data_table.text_format.portion_format.font_height = 20

	pres.save("output.pptx", slides.export.SaveFormat.PPTX)
```