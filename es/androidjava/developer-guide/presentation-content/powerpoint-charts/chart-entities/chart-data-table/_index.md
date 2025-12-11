---
title: Personalizar tablas de datos de gráficos en presentaciones en Android
linktitle: Tabla de datos
type: docs
url: /es/androidjava/chart-data-table/
keywords:
- datos de gráfico
- tabla de datos
- propiedades de fuente
- PowerPoint
- presentación
- Android
- Java
- Aspose.Slides
description: "Personaliza las tablas de datos de gráficos en Java para PPT y PPTX con Aspose.Slides para Android para aumentar la eficiencia y el atractivo en las presentaciones."
---

## **Establecer propiedades de fuente para una tabla de datos de gráfico**
Aspose.Slides for Android a través de Java proporciona soporte para cambiar el color de las categorías en el color de una serie.  

1. Instanciar el objeto de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Agregar un gráfico en la diapositiva.
1. Establecer la tabla del gráfico.
1. Establecer la altura de la fuente.
1. Guardar la presentación modificada.  

A continuación se muestra un ejemplo.  
```java
// Creando una presentación vacía
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

Sí. La tabla de datos admite [claves de leyenda](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datatable/#setShowLegendKey-boolean-), y puedes activarlas o desactivarlas.

**¿Se conservará la tabla de datos al exportar la presentación a PDF, HTML o imágenes?**

Sí. Aspose.Slides renderiza el gráfico como parte de la diapositiva, por lo que el exportado [PDF](/slides/es/androidjava/convert-powerpoint-to-pdf/)/[HTML](/slides/es/androidjava/convert-powerpoint-to-html/)/[imagen](/slides/es/androidjava/convert-powerpoint-to-png/) incluye el gráfico con su tabla de datos.

**¿Se admiten tablas de datos para gráficos que provienen de un archivo de plantilla?**

Sí. Para cualquier gráfico cargado desde una presentación o plantilla existente, puedes verificar y cambiar si una tabla de datos [se muestra](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#hasDataTable--) usando las propiedades del gráfico.

**¿Cómo puedo encontrar rápidamente qué gráficos en un archivo tienen la tabla de datos habilitada?**

Inspecciona la propiedad de cada gráfico que indica si la tabla de datos [se muestra](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#hasDataTable--) e itera a través de las diapositivas para identificar los gráficos donde está habilitada.