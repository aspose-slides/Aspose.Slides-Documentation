---
title: Formato de Gráficos
type: docs
weight: 60
url: /java/chart-formatting/
---

## **Formatear Entidades de Gráficos**
Aspose.Slides para Java permite a los desarrolladores agregar gráficos personalizados a sus diapositivas desde cero. Este artículo explica cómo formatear diferentes entidades de gráficos, incluyendo el eje de categoría y el eje de valores.

Aspose.Slides para Java proporciona una API simple para gestionar diferentes entidades de gráficos y formatearlas utilizando valores personalizados:

1. Cree una instancia de la clase [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtenga una referencia de la diapositiva por su índice.
1. Agregue un gráfico con datos predeterminados junto con el tipo deseado (en este ejemplo utilizaremos ChartType.LineWithMarkers).
1. Acceda al Eje de Valores del gráfico y configure las siguientes propiedades:
   1. Estableciendo **Formato de Línea** para las Líneas de Cuadrícula Mayores del Eje de Valores
   1. Estableciendo **Formato de Línea** para las Líneas de Cuadrícula Menores del Eje de Valores
   1. Estableciendo **Formato de Número** para el Eje de Valores
   1. Estableciendo **Mínimo, Máximo, Unidades Mayores y Menores** para el Eje de Valores
   1. Estableciendo **Propiedades de Texto** para los datos del Eje de Valores
   1. Estableciendo **Título** para el Eje de Valores
   1. Estableciendo **Formato de Línea** para el Eje de Valores
1. Acceda al Eje de Categoría del gráfico y configure las siguientes propiedades:
   1. Estableciendo **Formato de Línea** para las Líneas de Cuadrícula Mayores del Eje de Categoría
   1. Estableciendo **Formato de Línea** para las Líneas de Cuadrícula Menores del Eje de Categoría
   1. Estableciendo **Propiedades de Texto** para los datos del Eje de Categoría
   1. Estableciendo **Título** para el Eje de Categoría
   1. Estableciendo **Posicionamiento de Etiquetas** para el Eje de Categoría
   1. Estableciendo **Ángulo de Rotación** para las etiquetas del Eje de Categoría
1. Acceda a la Leyenda del gráfico y configure las **Propiedades de Texto** para ellas
1. Establezca mostrar las Leyendas de gráficos sin superponerse al gráfico
1. Acceda al **Eje Secundario de Valores** del gráfico y configure las siguientes propiedades:
   1. Habilitar el **Eje Secundario de Valores**
   1. Estableciendo **Formato de Línea** para el Eje Secundario de Valores
   1. Estableciendo **Formato de Número** para el Eje Secundario de Valores
   1. Estableciendo **Mínimo, Máximo, Unidades Mayores y Menores** para el Eje Secundario de Valores
1. Ahora trace la primera serie de gráficos en el Eje Secundario de Valores
1. Establezca el color de relleno de la pared trasera del gráfico
1. Establezca el color de relleno del área de trama del gráfico
1. Escriba la presentación modificada en un archivo PPTX

```java
// Crear una instancia de la clase Presentation
Presentation pres = new Presentation();
try {
    // Accediendo a la primera diapositiva
    ISlide slide = pres.getSlides().get_Item(0);

    // Agregando el gráfico de muestra
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

    // Estableciendo el Título del Gráfico
    chart.hasTitle();
    chart.getChartTitle().addTextFrameForOverriding("");
    IPortion chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Gráfico de Muestra");
    chartTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // Estableciendo el formato de las líneas de cuadrícula mayores para el eje de valores
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot);

    // Estableciendo el formato de las líneas de cuadrícula menores para el eje de valores
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // Estableciendo el formato de número del eje de valores
    chart.getAxes().getVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");

    // Estableciendo los valores máximos y mínimos del gráfico
    chart.getAxes().getVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMinValue();

    chart.getAxes().getVerticalAxis().setMaxValue(15f);
    chart.getAxes().getVerticalAxis().setMinValue(-2f);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0f);

    // Estableciendo las Propiedades de Texto del Eje de Valores
    IChartPortionFormat txtVal = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    txtVal.setFontBold(NullableBool.True);
    txtVal.setFontHeight(16);
    txtVal.setFontItalic(NullableBool.True);
    txtVal.getFillFormat().setFillType(FillType.Solid);
    txtVal.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkGreen));
    txtVal.setLatinFont(new FontData("Times New Roman"));

    // Estableciendo el título del eje de valores
    chart.getAxes().getVerticalAxis().hasTitle();
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    IPortion valtitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valtitle.setText("Eje Primario");
    valtitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    valtitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    valtitle.getPortionFormat().setFontHeight(20);
    valtitle.getPortionFormat().setFontBold(NullableBool.True);
    valtitle.getPortionFormat().setFontItalic(NullableBool.True);

    // Estableciendo el formato de las líneas de cuadrícula mayores para el eje de categoría
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);

    // Estableciendo el formato de las líneas de cuadrícula menores para el eje de categoría
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // Estableciendo las Propiedades de Texto del Eje de Categoría
    IChartPortionFormat txtCat = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    txtCat.setFontBold(NullableBool.True);
    txtCat.setFontHeight(16);
    txtCat.setFontItalic(NullableBool.True);
    txtCat.getFillFormat().setFillType(FillType.Solid);
    txtCat.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    txtCat.setLatinFont(new FontData("Arial"));

    // Estableciendo el Título de la Categoría
    chart.getAxes().getHorizontalAxis().hasTitle();
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");

    IPortion catTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    catTitle.setText("Categoría de Muestra");
    catTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    catTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    catTitle.getPortionFormat().setFontHeight(20);
    catTitle.getPortionFormat().setFontBold(NullableBool.True);
    catTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // Estableciendo la posición de las etiquetas del eje de categoría
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low);

    // Estableciendo el ángulo de rotación de las etiquetas del eje de categoría
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);

    // Estableciendo las Propiedades de Texto de las Leyendas
    IChartPortionFormat txtleg = chart.getLegend().getTextFormat().getPortionFormat();
    txtleg.setFontBold(NullableBool.True);
    txtleg.setFontHeight(16);
    txtleg.setFontItalic(NullableBool.True);
    txtleg.getFillFormat().setFillType(FillType.Solid);
    txtleg.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkRed));

    // Establecer mostrar leyendas de gráficos sin superponerse al gráfico

    chart.getLegend().setOverlay(true);
    // chart.ChartData.Series[0].PlotOnSecondAxis=true;

    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(true);
    // Estableciendo el eje secundario de valores
    chart.getAxes().getSecondaryVerticalAxis().isVisible();
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(LineStyle.ThickBetweenThin);
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20);

    // Estableciendo el formato de número del eje secundario de valores
    chart.getAxes().getSecondaryVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(DisplayUnitType.Hundreds);
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%");

    // Estableciendo los valores máximos y mínimos del gráfico
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinValue();

    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20f);
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5f);
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0f);

    // Estableciendo el color de la pared trasera del gráfico
    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid);
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE);

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid);
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    // Estableciendo el color del área de trazo
    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid);
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setColor(new Color(PresetColor.LightCyan));

    // Guardar la Presentación
    pres.save("FormattedChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Establecer Propiedades de Fuente para el Gráfico**
Aspose.Slides para Java proporciona soporte para establecer las propiedades relacionadas con la fuente para el gráfico. Siga los pasos a continuación para establecer las propiedades de la fuente para el gráfico.

- Instanciar el objeto de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Agregue un gráfico en la diapositiva.
- Establezca la altura de la fuente.
- Guarde la presentación modificada.

A continuación se muestra un ejemplo de muestra.

```java
// Crear una instancia de la clase Presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    
    chart.getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    
    pres.save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Establecer Formato de Números**
Aspose.Slides para Java proporciona una API simple para gestionar el formato de datos de gráficos:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Obtenga una referencia de la diapositiva por su índice.
1. Agregue un gráfico con datos predeterminados junto con el tipo deseado (este ejemplo utiliza **ChartType.ClusteredColumn**).
1. Establezca el formato de número preestablecido de los posibles valores preestablecidos.
1. Recorra cada celda de datos del gráfico en cada serie del gráfico y establezca el formato de número de los datos del gráfico.
1. Guarde la presentación.
1. Establezca el formato de número personalizado.
1. Recorra cada celda de datos dentro de cada serie de gráficos y establezca un formato de número de datos de gráfico diferente.
1. Guarde la presentación.

```java
// Crear una instancia de la clase Presentation
Presentation pres = new Presentation();
try {
    // Accediendo a la primera diapositiva de la presentación
    ISlide slide = pres.getSlides().get_Item(0);

    // Agregando un gráfico de columnas agrupadas por defecto
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

    // Accediendo a la colección de series del gráfico
    IChartSeriesCollection series = chart.getChartData().getSeries();
    
    // Recorrer cada serie del gráfico
    for (IChartSeries ser : series) 
    {
        // Recorrer cada celda de datos en la serie
        for (IChartDataPoint cell : ser.getDataPoints()) 
        {
            // Estableciendo el formato de número
            cell.getValue().getAsCell().setPresetNumberFormat((byte) 10); // 0.00%
        }
    }

    // Guardando la presentación
    pres.save("PresetNumberFormat.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}

```

Los posibles valores de formato de número preestablecidos, junto con su índice preestablecido que se puede utilizar, se indican a continuación:

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
|**46**|h :mm:ss|
|**47**|[mm:ss.0](http://mmss.0)|
|**48**|##0.0E+00|
|**49**|@|

## **Establecer Bordes Redondeados en el Área del Gráfico**
Aspose.Slides para Java proporciona soporte para establecer el área del gráfico. Los métodos [**hasRoundedCorners**](https://reference.aspose.com/slides/java/com.aspose.slides/IChart#hasRoundedCorners--) y [**setRoundedCorners**](https://reference.aspose.com/slides/java/com.aspose.slides/IChart#setRoundedCorners-boolean-) se han añadido a la interfaz [IChart](https://reference.aspose.com/slides/java/com.aspose.slides/IChart) y a la clase [Chart](https://reference.aspose.com/slides/java/com.aspose.slides/Chart). 

1. Instanciar el objeto de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Agregar un gráfico en la diapositiva.
1. Establecer el tipo de relleno y el color de relleno del gráfico.
1. Establecer la propiedad de borde redondeado en Verdadero.
1. Guardar la presentación modificada.

A continuación se muestra un ejemplo de muestra. 

```java
// Crear una instancia de la clase Presentation
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    chart.getLineFormat().setStyle(LineStyle.Single);
    chart.setRoundedCorners(true);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```