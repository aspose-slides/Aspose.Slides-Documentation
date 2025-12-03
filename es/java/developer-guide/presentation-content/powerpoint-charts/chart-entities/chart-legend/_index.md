---
title: Personalizar leyendas de gráficos en presentaciones usando Java
linktitle: Leyenda de gráfico
type: docs
url: /es/java/chart-legend/
keywords:
- leyenda de gráfico
- posición de la leyenda
- tamaño de fuente
- PowerPoint
- presentación
- Java
- Aspose.Slides
description: "Personaliza las leyendas de gráficos con Aspose.Slides para Java para optimizar presentaciones de PowerPoint con un formato de leyenda a medida."
---

## **Posicionamiento de la leyenda**
Para establecer las propiedades de la leyenda. Siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Obtenga la referencia de la diapositiva.
- Añada un gráfico en la diapositiva.
- Establezca las propiedades de la leyenda.
- Guarde la presentación como un archivo PPTX.

En el ejemplo que se muestra a continuación, hemos establecido la posición y el tamaño de la leyenda del gráfico.
```java
// Crear una instancia de la clase Presentation
Presentation pres = new Presentation();
try {
    // Obtener la referencia de la diapositiva
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


## **Establecer tamaño de fuente de la leyenda**
Aspose.Slides para Java permite a los desarrolladores establecer el tamaño de fuente de la leyenda. Siga los pasos a continuación:

- Instancie la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Cree el gráfico predeterminado.
- Establezca el tamaño de fuente.
- Establezca el valor mínimo del eje.
- Establezca el valor máximo del eje.
- Guarde la presentación en disco.
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


## **Establecer tamaño de fuente de la leyenda individual**
Aspose.Slides para Java permite a los desarrolladores establecer el tamaño de fuente de entradas individuales de la leyenda. Siga los pasos a continuación:

- Instancie la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Cree el gráfico predeterminado.
- Acceda a la entrada de la leyenda.
- Establezca el tamaño de fuente.
- Establezca el valor mínimo del eje.
- Establezca el valor máximo del eje.
- Guarde la presentación en disco.
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

**¿Puedo habilitar la leyenda para que el gráfico asigne automáticamente espacio para ella en lugar de superponerse?**

Sí. Use el modo sin superposición ([setOverlay(false)](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setOverlay-boolean-)); en este caso, el área del gráfico se reducirá para acomodar la leyenda.

**¿Puedo crear etiquetas de leyenda multilínea?**

Sí. Las etiquetas largas se ajustan automáticamente cuando el espacio es insuficiente; los saltos de línea forzados son compatibles mediante caracteres de nueva línea en el nombre de la serie.

**¿Cómo hago que la leyenda siga el esquema de colores del tema de la presentación?**

No establezca colores, rellenos o fuentes explícitos para la leyenda o su texto. Entonces heredarán del tema y se actualizarán correctamente cuando cambie el diseño.