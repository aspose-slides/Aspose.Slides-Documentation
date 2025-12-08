---
title: Tabla de datos del gráfico
type: docs
url: /es/nodejs-java/chart-data-table/
---

## **Establecer propiedades de fuente para la tabla de datos del gráfico**

Aspose.Slides for Node.js a través de Java ofrece soporte para cambiar el color de las categorías en el color de una serie.

1. Instanciar el objeto de clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Añadir un gráfico en la diapositiva.
1. Establecer la tabla del gráfico.
1. Establecer la altura de la fuente.
1. Guardar la presentación modificada.

A continuación se muestra un ejemplo.
```javascript
// Creando una presentación vacía
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);
    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontHeight(20);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Preguntas frecuentes**

**¿Puedo mostrar pequeñas claves de leyenda junto a los valores en la tabla de datos del gráfico?**

Sí. La tabla de datos admite [claves de leyenda](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datatable/setshowlegendkey/), y puedes activarlas o desactivarlas.

**¿Se conservará la tabla de datos al exportar la presentación a PDF, HTML o imágenes?**

Sí. Aspose.Slides renderiza el gráfico como parte de la diapositiva, por lo que el [PDF](/slides/es/nodejs-java/convert-powerpoint-to-pdf/)/[HTML](/slides/es/nodejs-java/convert-powerpoint-to-html/)/[imagen](/slides/es/nodejs-java/convert-powerpoint-to-png/) exportado incluye el gráfico con su tabla de datos.

**¿Se admiten tablas de datos para gráficos que provienen de un archivo de plantilla?**

Sí. Para cualquier gráfico cargado desde una presentación o plantilla existente, puedes comprobar y cambiar si una tabla de datos [se muestra](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/hasdatatable/) usando las propiedades del gráfico.

**¿Cómo puedo encontrar rápidamente qué gráficos en un archivo tienen la tabla de datos habilitada?**

Examina la propiedad de cada gráfico que indica si la tabla de datos [se muestra](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/hasdatatable/) e itera a través de las diapositivas para identificar los gráficos donde está habilitada.