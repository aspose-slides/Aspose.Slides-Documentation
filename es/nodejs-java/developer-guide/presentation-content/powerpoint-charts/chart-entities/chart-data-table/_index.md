---
title: Personalizar tablas de datos de gráficos en presentaciones usando JavaScript
linktitle: Tabla de datos
type: docs
url: /es/nodejs-java/chart-data-table/
keywords:
- datos de gráfico
- tabla de datos
- propiedades de fuente
- PowerPoint
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Personaliza fuentes, bordes y claves de leyenda de la tabla de datos de gráficos en presentaciones de PowerPoint utilizando Aspose.Slides for Node.js via Java."
---
## **Resumen**

Aspose.Slides for Node.js via Java le permite mostrar la tabla de datos de un gráfico y personalizar su formato de texto, bordes y claves de leyenda. Este artículo explica cómo habilitar la tabla, dar formato a su texto, controlar cada tipo de borde y mostrar u ocultar las claves de leyenda. Los ejemplos guardan los gráficos configurados en archivos PPTX.

## **Establecer propiedades de fuente**

Para mostrar la tabla de datos de un gráfico, pase `true` a [setDataTable](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chart/setdatatable/). Use [getChartDataTable](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chart/getchartdatatable/) para acceder a la tabla y configurar su formato de texto.

1. Cargue la presentación usando la clase [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/).
2. Añada un gráfico de columnas agrupadas a la primera diapositiva.
3. Habilite la tabla de datos del gráfico.
4. Active el texto en negrita con [setFontBold](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/baseportionformat/#setfontbold) y pase `20` a [setFontHeight](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/baseportionformat/#setfontheight) para texto de 20 puntos.
5. Guarde la presentación modificada.

El siguiente ejemplo requiere `input.pptx` en el directorio de trabajo con al menos una diapositiva. Añade un gráfico con datos predeterminados en la posición (50, 50), con un ancho de 600 puntos y una altura de 400 puntos. El `output.pptx` guardado contiene el gráfico con su tabla de datos habilitada y los ajustes de fuente especificados aplicados.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    const portionFormat = chart.getChartDataTable().getTextFormat().getPortionFormat();
    portionFormat.setFontBold(java.newByte(aspose.slides.NullableBool.True));
    portionFormat.setFontHeight(20);

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Personalizar bordes de la tabla de datos**

Habilite la tabla con [Chart.setDataTable](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chart/setdatatable/) y acceda a ella mediante [Chart.getChartDataTable](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chart/getchartdatatable/). Puede controlar tres tipos de bordes de forma independiente:

- [setBorderHorizontal](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/datatable/setborderhorizontal/) controla los bordes horizontales de celdas.
- [setBorderVertical](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/datatable/setbordervertical/) controla los bordes verticales de celdas.
- [setBorderOutline](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/datatable/setborderoutline/) controla el borde exterior de la tabla.

Pase `true` a cada método para mostrar sus bordes o `false` para ocultarlos. El siguiente ejemplo crea un gráfico de columnas agrupadas con datos predeterminados, muestra los bordes horizontales y el borde exterior, y oculta los bordes verticales. No requiere archivo de entrada. La posición y el tamaño del gráfico se especifican en puntos.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    const dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(false);
    dataTable.setBorderOutline(true);

    presentation.save("data-table-borders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La comparación a continuación utiliza los mismos datos del gráfico y la configuración de la clave de leyenda en los cuatro casos. Partiendo de todos los bordes habilitados, cada variante restante deshabilita solo una configuración de borde. La variante inferior izquierda coincide con la configuración de bordes del ejemplo.

![Tablas de datos del gráfico con todos los bordes habilitados, sin bordes horizontales, sin bordes verticales y sin borde exterior](data-table-borders.png)

## **Mostrar u ocultar claves de leyenda**

Las claves de leyenda son pequeños marcadores coloreados junto a los nombres de series en la tabla de datos. Ayudan a los lectores a relacionar cada fila de la tabla con una serie del gráfico. Pase `true` a [setShowLegendKey](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/datatable/setshowlegendkey/) para mostrar estos marcadores o `false` para ocultarlos.

La leyenda separada del gráfico se controla mediante [Chart.setLegend](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chart/setlegend/). Estas configuraciones son independientes: ocultar la leyenda separada no oculta las claves dentro de la tabla de datos, y ocultar las claves de la tabla no oculta la leyenda separada.

El siguiente ejemplo crea un gráfico con datos predeterminados, habilita su tabla de datos y muestra las claves de leyenda dentro de ella mientras oculta la leyenda separada. Todos los bordes de la tabla están explícitamente habilitados. No se requiere una presentación de entrada. Para ocultar solo las claves de la tabla, pase `false` a [setShowLegendKey](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/datatable/setshowlegendkey/).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);
    chart.setLegend(false);

    const dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(true);
    dataTable.setBorderOutline(true);
    dataTable.setShowLegendKey(true);

    presentation.save("data-table-legend-keys.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La comparación a continuación muestra la misma tabla con las claves de leyenda habilitadas y deshabilitadas. Todos los bordes permanecen habilitados, y la leyenda del gráfico está oculta en ambos casos.

![Tablas de datos del gráfico con claves de leyenda mostradas a la izquierda y ocultas a la derecha](data-table-legend-keys.png)

## **FAQ**

**¿Puedo mostrar claves de leyenda en la tabla de datos de un gráfico?**

Sí. Pase `true` a [setShowLegendKey](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/datatable/setshowlegendkey/) para mostrar las claves de leyenda o `false` para ocultarlas.

**¿Se conservará la tabla de datos al exportar la presentación a PDF, HTML o imágenes?**

Sí. Aspose.Slides renderiza el gráfico y su tabla de datos mostrada como parte de la diapositiva al exportar a [PDF](/slides/es/nodejs-java/convert-powerpoint-to-pdf/), [HTML](/slides/es/nodejs-java/convert-powerpoint-to-html/), o [imágenes](/slides/es/nodejs-java/convert-powerpoint-to-png/).

**¿Puedo trabajar con tablas de datos en gráficos cargados desde una plantilla?**

Sí. Para un gráfico cargado desde una presentación o plantilla existente, use [hasDataTable](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chart/hasdatatable/) y [setDataTable](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chart/setdatatable/) para comprobar o cambiar si su tabla de datos se muestra.

**¿Cómo puedo encontrar gráficos que tengan la tabla de datos habilitada?**

Itere a través de las formas en cada diapositiva, identifique los gráficos y llame a su método [hasDataTable](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chart/hasdatatable/). Un valor de `true` indica que la tabla de datos está habilitada.