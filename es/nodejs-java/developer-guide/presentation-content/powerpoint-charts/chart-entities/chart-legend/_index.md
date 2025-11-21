---
title: Leyenda del gráfico
type: docs
url: /es/nodejs-java/chart-legend/
---

## **Posicionamiento de la leyenda**

Para establecer las propiedades de la leyenda, siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
- Obtenga una referencia de la diapositiva.
- Agregue un gráfico a la diapositiva.
- Configure las propiedades de la leyenda.
- Guarde la presentación como un archivo PPTX.

En el ejemplo a continuación, hemos establecido la posición y el tamaño de la leyenda del gráfico.
```javascript
// Crear una instancia de la clase Presentation
var pres = new aspose.slides.Presentation();
try {
    // Obtener referencia de la diapositiva
    var slide = pres.getSlides().get_Item(0);
    // Añadir un gráfico de columnas agrupadas en la diapositiva
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 500);
    // Establecer propiedades de la leyenda
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());
    // Guardar la presentación en disco
    pres.save("Legend_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Establecer el tamaño de fuente de la leyenda**

Aspose.Slides para Node.js mediante Java permite a los desarrolladores establecer el tamaño de fuente de la leyenda. Siga los pasos a continuación:

- Instancie la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
- Cree el gráfico predeterminado.
- Establezca el tamaño de fuente.
- Establezca el valor mínimo del eje.
- Establezca el valor máximo del eje.
- Guarde la presentación en disco.
```javascript
// Crear una instancia de la clase Presentation
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Establecer el tamaño de fuente de la leyenda individual**

Aspose.Slides para Node.js mediante Java permite a los desarrolladores establecer el tamaño de fuente de las entradas individuales de la leyenda. Siga los pasos a continuación:

- Instancie la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
- Cree el gráfico predeterminado.
- Acceda a la entrada de la leyenda.
- Establezca el tamaño de fuente.
- Establezca el valor mínimo del eje.
- Establezca el valor máximo del eje.
- Guarde la presentación en disco.
```javascript
// Crear una instancia de la clase Presentation
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var tf = chart.getLegend().getEntries().get_Item(1).getTextFormat();
    tf.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    tf.getPortionFormat().setFontHeight(20);
    tf.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    tf.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    tf.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Preguntas frecuentes**

**¿Puedo habilitar la leyenda para que el gráfico reserve automáticamente espacio para ella en lugar de superponerse?**

Sí. Use el modo sin superposición ([setOverlay(false)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setoverlay/)); en este caso, el área del gráfico se reducirá para acomodar la leyenda.

**¿Puedo crear etiquetas de leyenda de varias líneas?**

Sí. Las etiquetas largas se ajustan automáticamente cuando el espacio es insuficiente; los saltos de línea forzados se admiten mediante caracteres de nueva línea en el nombre de la serie.

**¿Cómo hago que la leyenda siga el esquema de colores del tema de la presentación?**

No establezca colores, rellenos o fuentes explícitos para la leyenda o su texto. De ese modo heredarán del tema y se actualizarán correctamente cuando cambie el diseño.