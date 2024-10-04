---
title: Gráfico de Dona
type: docs
weight: 30
url: /python-net/doughnut-chart/
keywords: "Gráfico de dona, agujero central, presentación de PowerPoint, Python, Aspose.Slides para Python a través de .NET"
description: "Especificar el agujero central en un gráfico de dona en una presentación de PowerPoint en Python"
---

## **Especificar el Agujero Central en un Gráfico de Dona**
Para especificar el tamaño del agujero en un gráfico de dona, siga los pasos a continuación:

- Instanciar la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
- Agregar un gráfico de dona en la diapositiva.
- Especificar el tamaño del agujero en un gráfico de dona.
- Guardar la presentación en el disco.

En el ejemplo dado a continuación, hemos establecido el tamaño del agujero en un gráfico de dona.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Crear una instancia de la clase Presentation
with slides.Presentation() as presentation:

    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.DOUGHNUT, 50, 50, 400, 400)
    chart.chart_data.series_groups[0].doughnut_hole_size = 90

    # Guardar la presentación en el disco
    presentation.save("DoughnutHoleSize_out.pptx", slides.export.SaveFormat.PPTX)
```