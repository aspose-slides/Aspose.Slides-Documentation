---
title: Personalizar gráficos de dona en presentaciones con Python
linktitle: Gráfico de Dona
type: docs
weight: 30
url: /es/python-net/doughnut-chart/
keywords:
- gráfico de dona
- espacio central
- tamaño del hueco
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Descubra cómo crear y personalizar gráficos de dona en Aspose.Slides para Python mediante .NET, compatible con formatos PowerPoint y OpenDocument para presentaciones dinámicas."
---

## **Especificar el espacio central en el gráfico de dona**
Para especificar el tamaño del hueco en un gráfico de dona, siga los pasos a continuación:

- Instanciar la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
- Agregar un gráfico de dona en la diapositiva.
- Especificar el tamaño del hueco en un gráfico de dona.
- Guardar la presentación en disco.

En el ejemplo a continuación, hemos establecido el tamaño del hueco en un gráfico de dona.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Crear una instancia de la clase Presentation
with slides.Presentation() as presentation:

    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.DOUGHNUT, 50, 50, 400, 400)
    chart.chart_data.series_groups[0].doughnut_hole_size = 90

    # Guardar la presentación en disco
    presentation.save("DoughnutHoleSize_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Preguntas frecuentes**

**¿Puedo crear una dona de varios niveles con múltiples anillos?**

Sí. Añada varias series a un único gráfico de dona; cada serie se convierte en un anillo separado. El orden de los anillos se determina por el orden de las series en la colección.

**¿Se admite una dona "explosiva" (rebanadas separadas)?**

Sí. Existe un tipo de gráfico de Dona Explosiva [chart type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) y una propiedad de explosión en los puntos de datos; puede separar rebanadas individuales.

**¿Cómo puedo obtener una imagen de un gráfico de dona (PNG/SVG) para un informe?**

Un gráfico es una forma; puede renderizarlo a una [imagen rasterizada](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) o exportar el gráfico a una [imagen SVG](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/).