---
title: Personalizar leyendas de gráficos en presentaciones en Android
linktitle: Leyenda del gráfico
type: docs
url: /es/androidjava/chart-legend/
keywords:
- leyenda de gráfico
- posición de la leyenda
- tamaño de fuente
- PowerPoint
- presentación
- Android
- Java
- Aspose.Slides
description: "Personaliza las leyendas de los gráficos con Aspose.Slides para Android mediante Java para optimizar presentaciones de PowerPoint con un formato de leyenda a medida."
---

## **Posicionamiento de la Leyenda**
Para establecer las propiedades de la leyenda, siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- Obtenga una referencia de la diapositiva.
- Agregue un gráfico a la diapositiva.
- Configure las propiedades de la leyenda.
- Guarde la presentación como un archivo PPTX.

En el ejemplo a continuación, hemos establecido la posición y el tamaño de la leyenda del gráfico.
```java
// Crear una instancia de la clase Presentation
Presentation pres = new Presentation();
try {
    // Obtener referencia de la diapositiva
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Añadir un gráfico de columnas agrupadas en la diapositiva
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);
    
    // Establecer propiedades de la leyenda
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());
    
    // Guardar la presentación en disco
    pres.save("Legend_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Establecer el tamaño de fuente de una leyenda**
Aspose.Slides para Android mediante Java permite a los desarrolladores establecer el tamaño de fuente de la leyenda. Siga los pasos a continuación:

- Instancie la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- Cree el gráfico predeterminado.
- Establezca el tamaño de fuente.
- Establezca el valor mínimo del eje.
- Establezca el valor máximo del eje.
- Guarde la presentación en el disco.
```java
// Crear una instancia de la clase Presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);

    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Establecer el tamaño de fuente de una leyenda individual**
Aspose.Slides para Android mediante Java permite a los desarrolladores establecer el tamaño de fuente de entradas individuales de la leyenda. Siga los pasos a continuación:

- Instancie la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- Cree el gráfico predeterminado.
- Acceda a la entrada de la leyenda.
- Establezca el tamaño de fuente.
- Establezca el valor mínimo del eje.
- Establezca el valor máximo del eje.
- Guarde la presentación en el disco.
```java
// Crear una instancia de la clase Presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    IChartTextFormat tf = chart.getLegend().getEntries().get_Item(1).getTextFormat();

    tf.getPortionFormat().setFontBold(NullableBool.True);
    tf.getPortionFormat().setFontHeight(20);
    tf.getPortionFormat().setFontItalic(NullableBool.True);
    tf.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    tf.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Preguntas frecuentes**

**¿Puedo habilitar la leyenda para que el gráfico asigne automáticamente espacio a ella en lugar de superponerse?**

Sí. Use el modo sin superposición ([setOverlay(false)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setOverlay-boolean-)); en este caso, el área del trazado se reducirá para acomodar la leyenda.

**¿Puedo crear etiquetas de leyenda de varias líneas?**

Sí. Las etiquetas largas se ajustan automáticamente cuando el espacio es insuficiente; los saltos de línea forzados se admiten mediante caracteres de nueva línea en el nombre de la serie.

**¿Cómo hago que la leyenda siga el esquema de colores del tema de la presentación?**

No establezca colores/rellenos/fuentes explícitos para la leyenda o su texto. Así heredarán del tema y se actualizarán correctamente cuando cambie el diseño.