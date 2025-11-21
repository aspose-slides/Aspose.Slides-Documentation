---
title: Exportar gráficos de presentación con Python
linktitle: Exportar gráfico
type: docs
weight: 90
url: /es/python-net/export-chart/
keywords:
- gráfico
- gráfico a imagen
- gráfico como imagen
- extraer imagen de gráfico
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Aprenda cómo exportar gráficos de presentación con Aspose.Slides para Python a través de .NET, compatible con los formatos PPT, PPTX y ODP, y agilice la generación de informes en cualquier flujo de trabajo."
---

## **Obtener imagen del gráfico**
Aspose.Slides for Python via .NET proporciona soporte para extraer la imagen de un gráfico específico. A continuación se muestra un ejemplo de muestra. 
```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("test.pptx") as presentation:
	slide = presentation.slides[0]
	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
	
	with chart.get_image() as image:
		image.save("image.png", slides.ImageFormat.PNG)
```


## **Preguntas frecuentes**

**¿Puedo exportar un gráfico como vector (SVG) en lugar de una imagen rasterizada?**

Sí. Un gráfico es una forma, y su contenido puede guardarse en SVG mediante el [método de guardado shape-to-SVG](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/write_as_svg/).

**¿Cómo puedo establecer el tamaño exacto del gráfico exportado en píxeles?**

Utilice las sobrecargas de renderizado de imagen que le permiten especificar el tamaño o la escala; la biblioteca admite renderizar objetos con dimensiones/escala dadas.

**¿Qué debo hacer si las fuentes en las etiquetas y la leyenda aparecen incorrectas después de la exportación?**

[Cargar las fuentes requeridas](/slides/es/python-net/custom-font/) mediante [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/) para que el renderizado del gráfico conserve las métricas y la apariencia del texto.

**¿La exportación respeta el tema, los estilos y los efectos de PowerPoint?**

Sí. El renderizador de Aspose.Slides sigue el formato de la presentación (temas, estilos, rellenos, efectos), por lo que se conserva la apariencia del gráfico.

**¿Dónde puedo encontrar capacidades de renderizado/exportación disponibles más allá de las imágenes de gráficos?**

Consulte la sección de exportación de la [API](https://reference.aspose.com/slides/python-net/aspose.slides.export/)/[documentación](/slides/es/python-net/convert-powerpoint/) para los destinos de salida ([PDF](/slides/es/python-net/convert-powerpoint-to-pdf/), [SVG](/slides/es/python-net/render-a-slide-as-an-svg-image/), [XPS](/slides/es/python-net/convert-powerpoint-to-xps/), [HTML](/slides/es/python-net/convert-powerpoint-to-html/), etc.) y las opciones de renderizado relacionadas.