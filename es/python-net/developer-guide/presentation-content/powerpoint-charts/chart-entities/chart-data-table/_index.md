---
title: Personalizar tablas de datos de gráficos en Python
linktitle: Tabla de datos
type: docs
url: /es/python-net/chart-data-table/
keywords:
- datos de gráfico
- tabla de datos
- propiedades de fuente
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Personaliza tablas de datos de gráficos en Python para PPT, PPTX y ODP con Aspose.Slides para mejorar la eficiencia y el atractivo de las presentaciones."
---

## **Establecer propiedades de fuente para la tabla de datos del gráfico**
Aspose.Slides para Python a través de .NET ofrece soporte para cambiar el color de las categorías en el color de una serie. 

1. Instanciar el objeto de clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Agregar un gráfico en la diapositiva.
3. Establecer la tabla del gráfico.
4. Establecer la altura de la fuente.
5. Guardar la presentación modificada.

A continuación se muestra un ejemplo. 
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


## **Preguntas frecuentes**

**¿Puedo mostrar pequeñas claves de leyenda junto a los valores en la tabla de datos del gráfico?**

Sí. La tabla de datos admite [claves de leyenda](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datatable/show_legend_key/), y puedes activarlas o desactivarlas.

**¿Se conservará la tabla de datos al exportar la presentación a PDF, HTML o imágenes?**

Sí. Aspose.Slides renderiza el gráfico como parte de la diapositiva, por lo que el [PDF](/slides/es/python-net/convert-powerpoint-to-pdf/)/[HTML](/slides/es/python-net/convert-powerpoint-to-html/)/[image](/slides/es/python-net/convert-powerpoint-to-png/) exportado incluye el gráfico con su tabla de datos.

**¿Se admiten tablas de datos para los gráficos que provienen de un archivo de plantilla?**

Sí. Para cualquier gráfico cargado desde una presentación o plantilla existente, puedes comprobar y cambiar si una tabla de datos [se muestra](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/has_data_table/) usando las propiedades del gráfico.

**¿Cómo puedo encontrar rápidamente qué gráficos en un archivo tienen habilitada la tabla de datos?**

Inspecciona la propiedad de cada gráfico que indica si la tabla de datos [se muestra](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/has_data_table/) e itera a través de las diapositivas para identificar los gráficos donde está habilitada.