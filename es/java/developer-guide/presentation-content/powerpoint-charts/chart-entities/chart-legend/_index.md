---
title: Leyenda del Gráfico
type: docs
url: /es/java/chart-legend/
---

## **Posicionamiento de la Leyenda**
Para establecer las propiedades de la leyenda. Siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Obtenga referencia de la diapositiva.
- Agregue un gráfico en la diapositiva.
- Establezca las propiedades de la leyenda.
- Escriba la presentación como un archivo PPTX.

En el ejemplo dado a continuación, hemos establecido la posición y el tamaño para la leyenda del gráfico.

```java
// Crear una instancia de la clase Presentation
Presentation pres = new Presentation();
try {
    // Obtener referencia de la diapositiva
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Agregar un gráfico de columnas agrupadas en la diapositiva
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);
    
    // Establecer propiedades de la leyenda
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());
    
    // Escribir presentación en el disco
    pres.save("Legend_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Establecer Tamaño de Fuente de la Leyenda**
Aspose.Slides para Java permite a los desarrolladores establecer el tamaño de fuente de la leyenda. Por favor, siga los pasos a continuación:

- Instanciar la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Crear el gráfico predeterminado.
- Establecer el tamaño de fuente.
- Establecer el valor mínimo del eje.
- Establecer el valor máximo del eje.
- Escribir la presentación en el disco.

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

## **Establecer Tamaño de Fuente de la Leyenda Individual**
Aspose.Slides para Java permite a los desarrolladores establecer el tamaño de fuente de las entradas individuales de la leyenda. Por favor, siga los pasos a continuación: 

- Instanciar la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Crear el gráfico predeterminado.
- Acceder a la entrada de la leyenda.
- Establecer el tamaño de fuente.
- Establecer el valor mínimo del eje.
- Establecer el valor máximo del eje.
- Escribir la presentación en el disco.

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