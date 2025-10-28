---
title: Personalizar gráficos de rosquilla en presentaciones con Python
linktitle: Gráfico de Rosquilla
type: docs
weight: 30
url: /es/python-net/doughnut-chart/
keywords:
- gráfico de rosquilla
- espacio central
- tamaño del agujero
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Descubra cómo crear y personalizar gráficos de rosquilla en Aspose.Slides para Python vía .NET, con compatibilidad con los formatos PowerPoint y OpenDocument para presentaciones dinámicas."
---

## **Especificar espacio central en el gráfico de rosquilla**
Para especificar el tamaño del agujero en un gráfico de rosquilla, siga los pasos a continuación:

- Instanciar la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
- Añadir un gráfico de rosquilla en la diapositiva.
- Especificar el tamaño del agujero en el gráfico de rosquilla.
- Guardar la presentación en disco.

En el ejemplo que se muestra a continuación, hemos establecido el tamaño del agujero en un gráfico de rosquilla.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Create an instance of Presentation class
with slides.Presentation() as presentation:

    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.DOUGHNUT, 50, 50, 400, 400)
    chart.chart_data.series_groups[0].doughnut_hole_size = 90

    # Write presentation to disk
    presentation.save("DoughnutHoleSize_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Preguntas frecuentes**

**¿Puedo crear una rosquilla multinivel con varios aros?**

Sí. Añada múltiples series a un único gráfico de rosquilla; cada serie se convierte en un aro separado. El orden de los aros se determina por el orden de las series en la colección.

**¿Se admite una rosquilla “explosiva” (rebanadas separadas)?**

Sí. Existe un tipo de gráfico [Exploded Doughnut](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) y una propiedad de explosión en los puntos de datos; puede separar rebanadas individuales.

**¿Cómo puedo obtener una imagen de un gráfico de rosquilla (PNG/SVG) para un informe?**

Un gráfico es una forma; puede renderizarlo a una [imagen rasterizada](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) o exportar el gráfico a una [imagen SVG](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/).