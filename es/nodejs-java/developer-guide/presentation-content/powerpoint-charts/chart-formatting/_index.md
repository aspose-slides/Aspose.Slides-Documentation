---
title: Formato de gráficos de presentación en JavaScript
linktitle: Formateo de gráficos
type: docs
weight: 60
url: /es/nodejs-java/chart-formatting/
keywords:
- formato de gráfico
- formateo de gráficos
- entidad de gráfico
- propiedades del gráfico
- configuración del gráfico
- opciones del gráfico
- propiedades de fuente
- borde redondeado
- PowerPoint
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Aprenda a formatear gráficos en Aspose.Slides para Node.js en JavaScript y mejore su presentación de PowerPoint con un estilo profesional y llamativo."
---

## **Formato de entidades de gráfico**

Aspose.Slides for Node.js via Java permite a los desarrolladores añadir gráficos personalizados a sus diapositivas desde cero. Este artículo explica cómo dar formato a diferentes entidades de gráficos, incluidas la categoría del gráfico y el eje de valores.

Aspose.Slides for Node.js via Java ofrece una API sencilla para gestionar diferentes entidades de gráficos y darles formato utilizando valores personalizados:

1. Cree una instancia de la clase [**Presentation**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) .
1. Obtenga una referencia a la diapositiva mediante su índice.
1. Añada un gráfico con datos predeterminados junto con cualquiera de los tipos deseados (en este ejemplo utilizaremos ChartType.LineWithMarkers).
1. Acceda al eje de valores del gráfico y establezca las siguientes propiedades:
   1. Establecer **Line format** para las líneas de la cuadrícula mayor del eje de valores
   1. Establecer **Line format** para las líneas de la cuadrícula menor del eje de valores
   1. Establecer **Number Format** para el eje de valores
   1. Establecer **Min, Max, Major and Minor units** para el eje de valores
   1. Establecer **Text Properties** para los datos del eje de valores
   1. Establecer **Title** para el eje de valores
   1. Establecer **Line Format** para el eje de valores
1. Acceda al eje de categoría del gráfico y establezca las siguientes propiedades:
   1. Establecer **Line format** para las líneas de la cuadrícula mayor del eje de categoría
   1. Establecer **Line format** para las líneas de la cuadrícula menor del eje de categoría
   1. Establecer **Text Properties** para los datos del eje de categoría
   1. Establecer **Title** para el eje de categoría
   1. Establecer **Label Positioning** para el eje de categoría
   1. Establecer **Rotation Angle** para las etiquetas del eje de categoría
1. Acceda a la leyenda del gráfico y establezca las **Text Properties** para ella
1. Configure la visualización de leyendas del gráfico sin que se superpongan al gráfico
1. Acceda al **Secondary Value Axis** del gráfico y establezca las siguientes propiedades:
   1. Habilite el **Value Axis** secundario
   1. Establecer **Line Format** para el eje de valores secundario
   1. Establecer **Number Format** para el eje de valores secundario
   1. Establecer **Min, Max, Major and Minor units** para el eje de valores secundario
1. Ahora traza la primera serie del gráfico en el eje de valores secundario
1. Establezca el color de relleno de la pared trasera del gráfico
1. Establezca el color de relleno del área de trazado del gráfico
1. Guarde la presentación modificada en un archivo PPTX
```javascript
// Crear una instancia de la clase Presentation
var pres = new aspose.slides.Presentation();
try {
    // Accediendo a la primera diapositiva
    var slide = pres.getSlides().get_Item(0);
    // Añadiendo el gráfico de ejemplo
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 50, 50, 500, 400);
    // Estableciendo el título del gráfico
    chart.hasTitle();
    chart.getChartTitle().addTextFrameForOverriding("");
    var chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Sample Chart");
    chartTitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Estableciendo el formato de las líneas de cuadrícula principales para el eje de valores
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    // Estableciendo el formato de las líneas de cuadrícula menores para el eje de valores
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);
    // Estableciendo el formato numérico del eje de valores
    chart.getAxes().getVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");
    // Estableciendo los valores máximos y mínimos del gráfico
    chart.getAxes().getVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMinValue();
    chart.getAxes().getVerticalAxis().setMaxValue(15.0);
    chart.getAxes().getVerticalAxis().setMinValue(-2.0);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0);
    // Estableciendo propiedades de texto del eje de valores
    var txtVal = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    txtVal.setFontBold(aspose.slides.NullableBool.True);
    txtVal.setFontHeight(16);
    txtVal.setFontItalic(aspose.slides.NullableBool.True);
    txtVal.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    txtVal.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.DarkGreen));
    txtVal.setLatinFont(new aspose.slides.FontData("Times New Roman"));
    // Estableciendo el título del eje de valores
    chart.getAxes().getVerticalAxis().hasTitle();
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    var valtitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valtitle.setText("Primary Axis");
    valtitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    valtitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    valtitle.getPortionFormat().setFontHeight(20);
    valtitle.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    valtitle.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Estableciendo el formato de las líneas de cuadrícula principales para el eje de categoría
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    // Estableciendo el formato de las líneas de cuadrícula menores para el eje de categoría
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);
    // Estableciendo propiedades de texto del eje de categoría
    var txtCat = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    txtCat.setFontBold(aspose.slides.NullableBool.True);
    txtCat.setFontHeight(16);
    txtCat.setFontItalic(aspose.slides.NullableBool.True);
    txtCat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    txtCat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    txtCat.setLatinFont(new aspose.slides.FontData("Arial"));
    // Estableciendo el título de la categoría
    chart.getAxes().getHorizontalAxis().hasTitle();
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");
    var catTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    catTitle.setText("Sample Category");
    catTitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    catTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    catTitle.getPortionFormat().setFontHeight(20);
    catTitle.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    catTitle.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Estableciendo la posición de la etiqueta del eje de categoría
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(aspose.slides.TickLabelPositionType.Low);
    // Estableciendo el ángulo de rotación de la etiqueta del eje de categoría
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);
    // Estableciendo propiedades de texto de las leyendas
    var txtleg = chart.getLegend().getTextFormat().getPortionFormat();
    txtleg.setFontBold(aspose.slides.NullableBool.True);
    txtleg.setFontHeight(16);
    txtleg.setFontItalic(aspose.slides.NullableBool.True);
    txtleg.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    txtleg.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.DarkRed));
    // Configurar la visualización de leyendas del gráfico sin superposición
    chart.getLegend().setOverlay(true);
    // chart.ChartData.Series[0].PlotOnSecondAxis=true;
    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(true);
    // Estableciendo el eje de valores secundario
    chart.getAxes().getSecondaryVerticalAxis().isVisible();
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(aspose.slides.LineStyle.ThickBetweenThin);
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20);
    // Estableciendo el formato numérico del eje de valores secundario
    chart.getAxes().getSecondaryVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Hundreds);
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%");
    // Estableciendo los valores máximos y mínimos del gráfico
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinValue();
    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20.0);
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5.0);
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5);
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0);
    // Estableciendo el color de la pared trasera del gráfico
    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    chart.getFloor().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // Estableciendo el color del área de trazado
    chart.getPlotArea().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.LightCyan));
    // Guardar la presentación
    pres.save("FormattedChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Establecer propiedades de fuente para el gráfico**

Aspose.Slides for Node.js via Java ofrece soporte para establecer las propiedades relacionadas con la fuente del gráfico. Siga los pasos a continuación para configurar las propiedades de fuente del gráfico.

- Instancie un objeto de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) .
- Añada un gráfico en la diapositiva.
- Establezca la altura de la fuente.
- Guarde la presentación modificada.

```javascript
// Crear una instancia de la clase Presentation
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 400);
    chart.getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    pres.save("FontPropertiesForChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Establecer formato de números**

Aspose.Slides for Node.js via Java proporciona una API sencilla para gestionar el formato de datos del gráfico:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) .
1. Obtenga una referencia a la diapositiva mediante su índice.
1. Añada un gráfico con datos predeterminados junto con cualquiera de los tipos deseados (este ejemplo utiliza **ChartType.ClusteredColumn**).
1. Establezca el formato numérico predefinido a partir de los valores predefinidos posibles.
1. Recorra la celda de datos del gráfico en cada serie del gráfico y establezca el formato numérico de los datos del gráfico.
1. Guarde la presentación.
1. Establezca el formato numérico personalizado.
1. Recorra la celda de datos del gráfico dentro de cada serie del gráfico y establezca un formato numérico de datos del gráfico diferente.
1. Guarde la presentación.
```javascript
// Crear una instancia de la clase Presentation
var pres = new aspose.slides.Presentation();
try {
    // Acceder a la primera diapositiva de la presentación
    var slide = pres.getSlides().get_Item(0);
    // Añadir un gráfico de columnas agrupadas predeterminado
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 400);
    // Acceder a la colección de series del gráfico
    var series = chart.getChartData().getSeries();
    // Recorrer todas las series del gráfico
    for (var i = 0; i < series.size(); i++) {
        var ser = series.get_Item(i);
        // Recorrer cada celda de datos en la serie
        for (var j = 0; j < ser.getDataPoints().size(); j++) {
            var cell = ser.getDataPoints().get_Item(j);
            // Establecer el formato numérico
            cell.getValue().getAsCell().setPresetNumberFormat(java.newByte(10));// 0.00%
        }
    }
    // Guardar la presentación
    pres.save("PresetNumberFormat.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


Los posibles valores de formato numérico predefinidos junto con su índice predefinido y que pueden utilizarse se presentan a continuación:

|**0**|General|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h:mm:ss|
|**47**mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **Establecer bordes redondeados del área del gráfico**

Aspose.Slides for Node.js via Java ofrece soporte para configurar el área del gráfico. Los métodos [**hasRoundedCorners**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Chart#hasRoundedCorners--) y [**setRoundedCorners**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Chart#setRoundedCorners-boolean-) se han añadido a la clase [Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Chart) .

1. Instancie un objeto de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) .
1. Añada un gráfico en la diapositiva.
1. Establezca el tipo de relleno y el color de relleno del gráfico
1. Establezca la propiedad de esquina redondeada en True.
1. Guarde la presentación modificada.

```javascript
// Crear una instancia de la clase Presentation
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getLineFormat().setStyle(aspose.slides.LineStyle.Single);
    chart.setRoundedCorners(true);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Preguntas frecuentes**

**¿Puedo establecer rellenos semitransparentes para columnas/áreas manteniendo el borde opaco?**

Sí. La transparencia del relleno y el contorno se configuran por separado. Esto es útil para mejorar la legibilidad de la cuadrícula y los datos en visualizaciones densas.

**¿Cómo puedo manejar las etiquetas de datos cuando se superponen?**

Reduzca el tamaño de la fuente, desactive los componentes de etiqueta no esenciales (por ejemplo, categorías), establezca el desplazamiento/posición de la etiqueta, muestre etiquetas solo para los puntos seleccionados si es necesario, o cambie el formato a "valor + leyenda".

**¿Puedo aplicar rellenos de degradado o patrón a las series?**

Sí. Tanto los rellenos sólidos como los de degradado/patrón suelen estar disponibles. En la práctica, utilice degradados con moderación y evite combinaciones que reduzcan el contraste con la cuadrícula y el texto.