---
title: Personalizar tablas de datos de gráficos en presentaciones en Android
linktitle: Tabla de datos
type: docs
url: /es/androidjava/chart-data-table/
keywords:
- datos del gráfico
- tabla de datos
- propiedades de fuente
- PowerPoint
- presentación
- Android
- Java
- Aspose.Slides
description: "Personaliza las fuentes, bordes y claves de leyenda de la tabla de datos del gráfico en presentaciones de PowerPoint usando Aspose.Slides para Android a través de Java."
---
## **Visión general**

Aspose.Slides for Android via Java le permite mostrar la tabla de datos de un gráfico y personalizar el formato del texto, los bordes y las claves de leyenda. Este artículo explica cómo habilitar la tabla, dar formato al texto, controlar cada tipo de borde y mostrar u ocultar las claves de leyenda. Los ejemplos guardan los gráficos configurados en archivos PPTX.

## **Establecer propiedades de fuente**

Para mostrar la tabla de datos de un gráfico, pase `true` a [setDataTable](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/chart/#setDataTable-boolean-). Utilice [getChartDataTable](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/chart/#getChartDataTable--) para acceder a la tabla y configurar su formato de texto.

1. Cargue la presentación utilizando la clase [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/).
1. Añada un gráfico de columnas agrupadas a la primera diapositiva.
1. Habilite la tabla de datos del gráfico.
1. Active el texto en negrita con [setFontBold](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/baseportionformat/#setFontBold-byte-) y pase `20` a [setFontHeight](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) para un texto de 20 puntos.
1. Guarde la presentación modificada.

El siguiente ejemplo requiere `test.pptx` en el directorio de trabajo con al menos una diapositiva. Añade un gráfico con datos predeterminados en la posición (50, 50), con un ancho de 600 puntos y una altura de 400 puntos. El `output.pptx` guardado contiene el gráfico con su tabla de datos habilitada y los ajustes de fuente especificados aplicados.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("test.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    IChartPortionFormat portionFormat = chart.getChartDataTable().getTextFormat().getPortionFormat();
    portionFormat.setFontBold(NullableBool.True);
    portionFormat.setFontHeight(20);

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Personalizar bordes de la tabla de datos**

Habilite la tabla con [IChart.setDataTable](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ichart/#setDataTable-boolean-) y acceda a ella mediante [IChart.getChartDataTable](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ichart/#getChartDataTable--). Puede controlar tres tipos de bordes de forma independiente:

- [setBorderHorizontal](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/idatatable/#setBorderHorizontal-boolean-) controla los bordes horizontales de las celdas.
- [setBorderVertical](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/idatatable/#setBorderVertical-boolean-) controla los bordes verticales de las celdas.
- [setBorderOutline](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/idatatable/#setBorderOutline-boolean-) controla el borde exterior de la tabla.

Pase `true` a cada método para mostrar sus bordes o `false` para ocultarlos. El siguiente ejemplo crea un gráfico de columnas agrupadas con datos predeterminados, muestra los bordes horizontales y el borde exterior, y oculta los bordes verticales. No requiere archivo de entrada. La posición y el tamaño del gráfico se especifican en puntos.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    IDataTable dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(false);
    dataTable.setBorderOutline(true);

    presentation.save("data-table-borders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La comparación a continuación utiliza los mismos datos del gráfico y la configuración de la clave de leyenda en los cuatro casos. Comenzando con todos los bordes habilitados, cada variante restante desactiva solo una configuración de borde. La variante inferior izquierda coincide con la configuración de bordes del ejemplo.

![Tablas de datos del gráfico con todos los bordes habilitados, sin bordes horizontales, sin bordes verticales y sin borde exterior](data-table-borders.png)

## **Mostrar u ocultar claves de leyenda**

Las claves de leyenda son pequeños marcadores coloreados al lado de los nombres de las series en la tabla de datos. Ayudan a los lectores a asociar cada fila de la tabla con una serie del gráfico. Pase `true` a [setShowLegendKey](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/idatatable/#setShowLegendKey-boolean-) para mostrar estos marcadores o `false` para ocultarlos.

La leyenda separada del gráfico se controla con [IChart.setLegend](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ichart/#setLegend-boolean-). Estas configuraciones son independientes: ocultar la leyenda separada no oculta las claves dentro de la tabla de datos, y ocultar las claves de la tabla no oculta la leyenda separada.

El siguiente ejemplo crea un gráfico con datos predeterminados, habilita su tabla de datos y muestra las claves de leyenda dentro de ella mientras oculta la leyenda separada. Todos los bordes de la tabla están explícitamente habilitados. No se requiere una presentación de entrada. Para ocultar solo las claves de la tabla, pase `false` a [setShowLegendKey](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/idatatable/#setShowLegendKey-boolean-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);
    chart.setLegend(false);

    IDataTable dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(true);
    dataTable.setBorderOutline(true);
    dataTable.setShowLegendKey(true);

    presentation.save("data-table-legend-keys.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La comparación a continuación muestra la misma tabla con las claves de leyenda habilitadas y deshabilitadas. Todos los bordes continúan habilitados, y la leyenda separada del gráfico está oculta en ambos casos.

![Tablas de datos del gráfico con claves de leyenda mostradas a la izquierda y ocultas a la derecha](data-table-legend-keys.png)

## **Preguntas frecuentes**

**¿Puedo mostrar las claves de leyenda en la tabla de datos de un gráfico?**

Sí. Pase `true` a [setShowLegendKey](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/datatable/#setShowLegendKey-boolean-) para mostrar las claves de leyenda o `false` para ocultarlas.

**¿Se preservará la tabla de datos al exportar la presentación a PDF, HTML o imágenes?**

Sí. Aspose.Slides representa el gráfico y su tabla de datos mostrada como parte de la diapositiva al exportar a [PDF](/slides/es/androidjava/convert-powerpoint-to-pdf/), [HTML](/slides/es/androidjava/convert-powerpoint-to-html/), o [imágenes](/slides/es/androidjava/convert-powerpoint-to-png/).

**¿Puedo trabajar con tablas de datos en gráficos cargados desde una plantilla?**

Sí. Para un gráfico cargado desde una presentación o plantilla existente, use [hasDataTable](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/chart/#hasDataTable--) y [setDataTable](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/chart/#setDataTable-boolean-) para comprobar o cambiar si su tabla de datos se muestra.

**¿Cómo puedo encontrar gráficos que tengan la tabla de datos habilitada?**

Itere a través de las formas en cada diapositiva, identifique los gráficos y llame al método [hasDataTable](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/chart/#hasDataTable--). Un valor `true` indica que la tabla de datos está habilitada.