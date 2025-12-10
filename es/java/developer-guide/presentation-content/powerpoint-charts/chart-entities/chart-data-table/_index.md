---
title: Personalizar tablas de datos de gráficos en presentaciones usando Java
linktitle: Tabla de datos
type: docs
url: /es/java/chart-data-table/
keywords:
- datos de gráfico
- tabla de datos
- propiedades de fuente
- PowerPoint
- presentación
- Java
- Aspose.Slides
description: "Personaliza las tablas de datos de gráficos en Java para PPT y PPTX con Aspose.Slides para mejorar la eficiencia y el atractivo en las presentaciones."
---

## **Establecer propiedades de fuente para una tabla de datos de gráfico**
Aspose.Slides para Java ofrece soporte para cambiar el color de las categorías en una serie.

1. Instanciar el objeto de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Agregar un gráfico en la diapositiva.
1. Establecer la tabla del gráfico.
1. Establecer la altura de la fuente.
1. Guardar la presentación modificada.

A continuación se muestra un ejemplo.
```java
// Creando presentación vacía
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.setDataTable(true);

    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontBold(NullableBool.True);
    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontHeight(20);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Preguntas frecuentes**

**¿Puedo mostrar pequeñas claves de leyenda junto a los valores en la tabla de datos del gráfico?**

Sí. La tabla de datos admite [legend keys](https://reference.aspose.com/slides/java/com.aspose.slides/datatable/#setShowLegendKey-boolean-), y puede activarlas o desactivarlas.

**¿Se conservará la tabla de datos al exportar la presentación a PDF, HTML o imágenes?**

Sí. Aspose.Slides renderiza el gráfico como parte de la diapositiva, por lo que el [PDF](/slides/es/java/convert-powerpoint-to-pdf)/[HTML](/slides/es/java/convert-powerpoint-to-html)/[image](/slides/es/java/convert-powerpoint-to-png) exportado incluye el gráfico con su tabla de datos.

**¿Se admiten tablas de datos para gráficos que provienen de un archivo de plantilla?**

Sí. Para cualquier gráfico cargado desde una presentación o plantilla existente, puede comprobar y cambiar si una tabla de datos [se muestra](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#hasDataTable--) usando las propiedades del gráfico.

**¿Cómo puedo encontrar rápidamente qué gráficos en un archivo tienen la tabla de datos habilitada?**

Inspeccione la propiedad de cada gráfico que indica si la tabla de datos [se muestra](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#hasDataTable--) y recorra las diapositivas para identificar los gráficos donde está habilitada.