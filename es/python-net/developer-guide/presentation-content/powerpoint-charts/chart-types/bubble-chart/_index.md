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
description: "Cree y personalice potentes gráficos de burbujas en PowerPoint y OpenDocument con Aspose.Slides para Python via .NET para mejorar su visualización de datos fácilmente."
---

## **Escalado de tamaño del gráfico de burbujas**
Aspose.Slides para Python a través de .NET ofrece soporte para el escalado del tamaño de los gráficos de burbujas. En Aspose.Slides para Python a través de .NET se han añadido las propiedades **ChartSeries.bubble_size_scale** y **ChartSeriesGroup.bubble_size_scale**. A continuación se muestra un ejemplo de muestra.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 100, 100, 400, 300)
	chart.chart_data.series_groups[0].bubble_size_scale = 150
	pres.save("Result.pptx", slides.export.SaveFormat.PPTX)
```




## **Representar datos como tamaños de burbujas**
Se ha añadido la propiedad **bubble_size_representation** a las clases ChartSeries y ChartSeriesGroup. **bubble_size_representation** especifica cómo se representan los valores de tamaño de burbuja en el gráfico de burbujas. Los valores posibles son: **BubbleSizeRepresentationType.AREA** y **BubbleSizeRepresentationType.WIDTH**. En consecuencia, se ha añadido el enum **BubbleSizeRepresentationType** para especificar las formas posibles de representar los datos como tamaños de gráficos de burbujas. A continuación se muestra el código de ejemplo.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)
    chart.chart_data.series_groups[0].bubble_size_representation = charts.BubbleSizeRepresentationType.WIDTH
    pres.save("Presentation_BubbleSizeRepresentation.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**¿Se admite un \"gráfico de burbujas con efecto 3‑D\" y en qué se diferencia de uno normal?**

Sí. Existe un tipo de gráfico separado, \"Bubble with 3‑D\". Aplica estilo 3‑D a las burbujas pero no añade un eje adicional; los datos siguen siendo X‑Y‑S (tamaño). El tipo está disponible en la enumeración [chart type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/).

**¿Hay un límite en la cantidad de series y puntos en un gráfico de burbujas?**

No hay un límite estricto a nivel de API; las restricciones dependen del rendimiento y de la versión de PowerPoint de destino. Se recomienda mantener un número razonable de puntos para facilitar la legibilidad y la velocidad de renderizado.

**¿Cómo afecta la exportación a la apariencia de un gráfico de burbujas (PDF, imágenes)?**

La exportación a los formatos compatibles conserva la apariencia del gráfico; el renderizado lo realiza el motor de Aspose.Slides. Para formatos raster/vector, se aplican las reglas generales de renderizado de gráficos (resolución, antialiasing), por lo que debe elegirse un DPI suficiente para la impresión.