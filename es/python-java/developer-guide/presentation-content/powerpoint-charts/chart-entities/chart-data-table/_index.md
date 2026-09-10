---
title: Personalizar tablas de datos de gráficos en presentaciones usando Python
linktitle: Tabla de datos
type: docs
url: /es/python-java/chart-data-table/
keywords:
- datos de gráfico
- tabla de datos
- propiedades de fuente
- PowerPoint
- presentación
- Python
- Java
- Aspose.Slides
description: "Personaliza las tablas de datos de gráficos en Python para PPT y PPTX con Aspose.Slides for Python via Java para mejorar la eficiencia y el atractivo en las presentaciones."
---
## **Resumen**

Este artículo explica cómo trabajar con tablas de datos de gráficos en Aspose.Slides. Muestra cómo mostrar una tabla de datos para un gráfico y personalizar el formato del texto estableciendo propiedades de fuente como estilo negrita y altura de fuente. El ejemplo demuestra crear una presentación, añadir un gráfico, habilitar la tabla de datos del gráfico, aplicar la configuración de fuente y guardar la presentación actualizada.

También incluye respuestas breves a preguntas frecuentes sobre mostrar claves de leyenda en una tabla de datos de gráfico, conservar la tabla de datos durante la exportación, trabajar con gráficos cargados desde presentaciones o plantillas existentes e identificar los gráficos donde la tabla de datos está habilitada.

## **Establecer propiedades de fuente para una tabla de datos de gráfico**

Aspose.Slides for Python via Java permite mostrar la tabla de datos de un gráfico y cambiar las propiedades de fuente de su texto.

1. Instanciar la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
1. Añadir un gráfico a la diapositiva.
1. Mostrar la tabla de datos del gráfico.
1. Establecer el estilo negrita y la altura de fuente del texto de la tabla de datos.
1. Guardar la presentación modificada.

El siguiente ejemplo muestra estos pasos.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

# Crear una presentación vacía.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart.setDataTable(True)

    portion_format = chart.getChartDataTable().getTextFormat().getPortionFormat()
    portion_format.setFontBold(NullableBool.True_)
    portion_format.setFontHeight(20)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**¿Puedo mostrar pequeñas claves de leyenda junto a los valores en la tabla de datos del gráfico?**

Sí. La tabla de datos admite [claves de leyenda](https://reference.aspose.com/slides/es/python-java/aspose.slides/datatable/#setShowLegendKey) y puedes activarlas o desactivarlas.

**¿Se conservará la tabla de datos al exportar la presentación a PDF, HTML o imágenes?**

Sí. Aspose.Slides renderiza el gráfico como parte de la diapositiva, por lo que el [PDF](/slides/es/python-java/convert-powerpoint-to-pdf/)/[HTML](/slides/es/python-java/convert-powerpoint-to-html/)/[imagen](/slides/es/python-java/convert-powerpoint-to-png/) exportado incluye el gráfico con su tabla de datos.

**¿Se admiten tablas de datos para gráficos que provienen de un archivo de plantilla?**

Sí. Para cualquier gráfico cargado desde una presentación o plantilla existente, puedes comprobar y cambiar si la tabla de datos [se muestra](https://reference.aspose.com/slides/es/python-java/aspose.slides/chart/#hasDataTable) usando las propiedades del gráfico.

**¿Cómo puedo encontrar rápidamente qué gráficos en un archivo tienen la tabla de datos habilitada?**

Inspecciona la propiedad de cada gráfico que indica si la tabla de datos [se muestra](https://reference.aspose.com/slides/es/python-java/aspose.slides/chart/#hasDataTable) e itera a través de las diapositivas para identificar los gráficos donde está habilitada.