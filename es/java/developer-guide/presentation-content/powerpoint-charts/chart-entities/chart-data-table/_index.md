---
title: Tabla de Datos del Gráfico
type: docs
url: /es/java/chart-data-table/
---

## **Establecer Propiedades de Fuente para la Tabla de Datos del Gráfico**
Aspose.Slides para Java proporciona soporte para cambiar el color de las categorías en el color de una serie.

1. Instanciar el objeto de clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Agregar gráfico en la diapositiva.
1. Establecer la tabla del gráfico.
1. Establecer la altura de la fuente.
1. Guardar la presentación modificada.

 A continuación se presenta un ejemplo de muestra.

```java
// Crear presentación vacía
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