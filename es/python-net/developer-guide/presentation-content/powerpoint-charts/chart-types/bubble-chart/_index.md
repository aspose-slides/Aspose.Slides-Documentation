---
title: Personalizar gráficos de burbujas en presentaciones con Python
linktitle: Gráfico de burbujas
type: docs
url: /es/python-net/bubble-chart/
keywords:
- gráfico de burbujas
- tamaño de burbuja
- escalado de tamaño
- representación de tamaño
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Cree y personalice poderosos gráficos de burbujas en PowerPoint y OpenDocument con Aspose.Slides para Python a través de .NET para mejorar fácilmente la visualización de sus datos."
---

## **Escalado de Tamaño de Gráfica de Burbujas**
Aspose.Slides for Python a través de .NET ofrece soporte para el escalado del tamaño de las gráficas de burbujas. En Aspose.Slides for Python a través de .NET se han añadido las propiedades **ChartSeries.bubble_size_scale** y **ChartSeriesGroup.bubble_size_scale**. A continuación se muestra un ejemplo.
```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 100, 100, 400, 300)
	chart.chart_data.series_groups[0].bubble_size_scale = 150
	pres.save("Result.pptx", slides.export.SaveFormat.PPTX)
```





## **Representar Datos como Tamaños de Gráfica de Burbujas**
Se ha añadido la propiedad **bubble_size_representation** a las clases ChartSeries y ChartSeriesGroup. **bubble_size_representation** especifica cómo se representan los valores de tamaño de burbuja en la gráfica de burbujas. Los valores posibles son: **BubbleSizeRepresentationType.AREA** y **BubbleSizeRepresentationType.WIDTH**. En consecuencia, se ha añadido el enumerado **BubbleSizeRepresentationType** para especificar las formas posibles de representar datos como tamaños de gráfica de burbujas. A continuación se muestra el código de ejemplo.
```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)
    chart.chart_data.series_groups[0].bubble_size_representation = charts.BubbleSizeRepresentationType.WIDTH
    pres.save("Presentation_BubbleSizeRepresentation.pptx", slides.export.SaveFormat.PPTX)
```


## **Preguntas Frecuentes**

**¿Se admite una "gráfica de burbujas con efecto 3-D" y en qué se diferencia de una normal?**

Sí. Existe un tipo de gráfica separado, "Bubble with 3-D". Aplica estilo 3-D a las burbujas pero no añade un eje adicional; los datos siguen siendo X‑Y‑S (tamaño). El tipo está disponible en la enumeración [chart type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/).

**¿Existe un límite en la cantidad de series y puntos en una gráfica de burbujas?**

No hay un límite estricto a nivel de API; las restricciones dependen del rendimiento y de la versión de PowerPoint de destino. Se recomienda mantener un número razonable de puntos para asegurar la legibilidad y la velocidad de renderizado.

**¿Cómo afecta la exportación a la apariencia de una gráfica de burbujas (PDF, imágenes)?**

La exportación a los formatos compatibles preserva la apariencia de la gráfica; el renderizado lo realiza el motor de Aspose.Slides. Para formatos raster/vector, se aplican las reglas generales de renderizado de gráficos de gráficas (resolución, antialiasing), por lo que se debe elegir un DPI suficiente para la impresión.