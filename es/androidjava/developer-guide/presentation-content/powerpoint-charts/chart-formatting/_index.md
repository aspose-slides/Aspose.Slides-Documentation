---
title: Formato de Gráficos
type: docs
weight: 60
url: /androidjava/chart-formatting/
---

## **Formatear Entidades de Gráficos**
Aspose.Slides para Android a través de Java permite a los desarrolladores agregar gráficos personalizados a sus diapositivas desde cero. Este artículo explica cómo formatear diferentes entidades de gráficos, incluyendo el eje de categoría y el eje de valores.

Aspose.Slides para Android a través de Java proporciona una API simple para gestionar diferentes entidades de gráficos y formatearlas utilizando valores personalizados:

1. Crear una instancia de la clase [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtener una referencia de la diapositiva por su índice.
1. Agregar un gráfico con datos predeterminados junto con cualquiera de los tipos deseados (en este ejemplo utilizaremos ChartType.LineWithMarkers).
1. Acceder al Eje de Valores del gráfico y establecer las siguientes propiedades:
   1. Establecer **Formato de Línea** para las líneas de cuadrícula principales del Eje de Valores
   1. Establecer **Formato de Línea** para las líneas de cuadrícula menores del Eje de Valores
   1. Establecer **Formato de Número** para el Eje de Valores
   1. Establecer **Valores Mínimos, Máximos, Mayores y Menores** para el Eje de Valores
   1. Establecer **Propiedades de Texto** para los datos del Eje de Valores
   1. Establecer **Título** para el Eje de Valores
   1. Establecer **Formato de Línea** para el Eje de Valores
1. Acceder al Eje de Categoría del gráfico y establecer las siguientes propiedades:
   1. Establecer **Formato de Línea** para las líneas de cuadrícula principales del Eje de Categoría
   1. Establecer **Formato de Línea** para las líneas de cuadrícula menores del Eje de Categoría
   1. Establecer **Propiedades de Texto** para los datos del Eje de Categoría
   1. Establecer **Título** para el Eje de Categoría
   1. Establecer **Posicionamiento de Etiquetas** para el Eje de Categoría
   1. Establecer **Ángulo de Rotación** para las etiquetas del Eje de Categoría
1. Acceder a la Leyenda del gráfico y establecer las **Propiedades de Texto** para ellas
1. Establecer la visualización de las Leyendas del gráfico sin sobreponerse al gráfico
1. Acceder al **Eje de Valores Secundario** del gráfico y establecer las siguientes propiedades:
   1. Habilitar el **Eje de Valores Secundario**
   1. Establecer **Formato de Línea** para el Eje de Valores Secundario
   1. Establecer **Formato de Número** para el Eje de Valores Secundario
   1. Establecer **Valores Mínimos, Máximos, Mayores y Menores** para el Eje de Valores Secundario
1. Ahora trazar la primera serie de gráficos en el Eje de Valores Secundario
1. Establecer el color de relleno de la pared trasera del gráfico
1. Establecer el color de relleno del área de trazado del gráfico
1. Escribir la presentación modificada en un archivo PPTX

```java
// Crear una instancia de la clase Presentation
Presentation pres = new Presentation();
try {
    // Accediendo a la primera diapositiva
    ISlide slide = pres.getSlides().get_Item(0);

    // Agregando el gráfico de ejemplo
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

    // Estableciendo el Título del Gráfico
    chart.hasTitle();
    chart.getChartTitle().addTextFrameForOverriding("");
    IPortion chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Gráfico de Ejemplo");
    chartTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // Estableciendo formato de líneas de cuadrícula principales para el eje de valores
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot);

    // Estableciendo formato de líneas de cuadrícula menores para el eje de valores
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // Estableciendo formato de número del eje de valores
    chart.getAxes().getVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");

    // Estableciendo valores máximos y mínimos del gráfico
    chart.getAxes().getVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMinValue();

    chart.getAxes().getVerticalAxis().setMaxValue(15f);
    chart.getAxes().getVerticalAxis().setMinValue(-2f);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0f);

    // Estableciendo Propiedades de Texto del Eje de Valores
    IChartPortionFormat txtVal = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    txtVal.setFontBold(NullableBool.True);
    txtVal.setFontHeight(16);
    txtVal.setFontItalic(NullableBool.True);
    txtVal.getFillFormat().setFillType(FillType.Solid);
    txtVal.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkGreen));
    txtVal.setLatinFont(new FontData("Times New Roman"));

    // Estableciendo título del eje de valores
    chart.getAxes().getVerticalAxis().hasTitle();
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    IPortion valtitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valtitle.setText("Eje Primario");
    valtitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    valtitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    valtitle.getPortionFormat().setFontHeight(20);
    valtitle.getPortionFormat().setFontBold(NullableBool.True);
    valtitle.getPortionFormat().setFontItalic(NullableBool.True);

    // Estableciendo formato de líneas de cuadrícula principales para el eje de categoría
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);

    // Estableciendo formato de líneas de cuadrícula menores para el eje de categoría
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // Estableciendo Propiedades de Texto del Eje de Categoría
    IChartPortionFormat txtCat = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    txtCat.setFontBold(NullableBool.True);
    txtCat.setFontHeight(16);
    txtCat.setFontItalic(NullableBool.True);
    txtCat.getFillFormat().setFillType(FillType.Solid);
    txtCat.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    txtCat.setLatinFont(new FontData("Arial"));

    // Estableciendo Título de Categoría
    chart.getAxes().getHorizontalAxis().hasTitle();
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");

    IPortion catTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    catTitle.setText("Categoría de Ejemplo");
    catTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    catTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    catTitle.getPortionFormat().setFontHeight(20);
    catTitle.getPortionFormat().setFontBold(NullableBool.True);
    catTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // Estableciendo posición de etiquetas del eje de categoría
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low);

    // Estableciendo ángulo de rotación de las etiquetas del eje de categoría
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);

    // Estableciendo Propiedades de Texto de las Leyendas
    IChartPortionFormat txtleg = chart.getLegend().getTextFormat().getPortionFormat();
    txtleg.setFontBold(NullableBool.True);
    txtleg.setFontHeight(16);
    txtleg.setFontItalic(NullableBool.True);
    txtleg.getFillFormat().setFillType(FillType.Solid);
    txtleg.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkRed));

    // Establecer la visualización de leyendas del gráfico sin superponerse al gráfico

    chart.getLegend().setOverlay(true);
    // chart.ChartData.Series[0].PlotOnSecondAxis=true;

    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(true);
    // Estableciendo el eje de valores secundario
    chart.getAxes().getSecondaryVerticalAxis().isVisible();
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(LineStyle.ThickBetweenThin);
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20);

    // Estableciendo Formato de Número para el Eje de Valores Secundario
    chart.getAxes().getSecondaryVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(DisplayUnitType.Hundreds);
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%");

    // Estableciendo valores máximos y mínimos para el gráfico
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinValue();

    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20f);
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5f);
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0f);

    // Estableciendo color de la pared trasera del gráfico
    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid);
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE);

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid);
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    // Estableciendo el color del área de trazado
    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid);
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setColor(new Color(PresetColor.LightCyan));

    // Guardar Presentación
    pres.save("FormattedChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Establecer Propiedades de Fuente para el Gráfico**
Aspose.Slides para Android a través de Java proporciona soporte para establecer las propiedades relacionadas con la fuente para el gráfico. Por favor, siga los pasos a continuación para establecer las propiedades de la fuente para el gráfico.

- Instanciar el objeto de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Agregar el gráfico en la diapositiva.
- Establecer la altura de la fuente.
- Guardar la presentación modificada.

A continuación se presenta un ejemplo de muestra.

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
Aspose.Slides para Android a través de Java proporciona una API simple para gestionar el formato de datos de gráficos:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Obtener una referencia de la diapositiva por su índice.
1. Agregar un gráfico con datos predeterminados junto con cualquiera de los tipos deseados (este ejemplo utiliza **ChartType.ClusteredColumn**).
1. Establecer el formato de número preestablecido a partir de los posibles valores preestablecidos.
1. Recorrer la celda de datos del gráfico en cada serie de gráficos y establecer el formato de número de datos del gráfico.
1. Guardar la presentación.
1. Establecer el formato de número personalizado.
1. Recorrer la celda de datos del gráfico dentro de cada serie de gráficos y establecer un formato de número de datos de gráfico diferente.
1. Guardar la presentación.

```java
// Crear una instancia de la clase Presentation
Presentation pres = new Presentation();
try {
    // Accediendo a la primera diapositiva de la presentación
    ISlide slide = pres.getSlides().get_Item(0);

    // Agregando un gráfico de columnas agrupadas predeterminado
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

    // Accediendo a la colección de series del gráfico
    IChartSeriesCollection series = chart.getChartData().getSeries();
    
    // Recorrer cada serie de gráficos
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

Los posibles valores de formato de número preestablecido junto con su índice preestablecido que se pueden utilizar se presentan a continuación:

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
Aspose.Slides para Android a través de Java proporciona soporte para establecer el área del gráfico. Se han agregado los métodos [**hasRoundedCorners**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChart#hasRoundedCorners--) y [**setRoundedCorners**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChart#setRoundedCorners-boolean-) a la interfaz [IChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChart) y a la clase [Chart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Chart).

1. Instanciar el objeto de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Agregar el gráfico en la diapositiva.
1. Establecer el tipo de relleno y el color de relleno del gráfico.
1. Establecer la propiedad de bordes redondeados a Verdadero.
1. Guardar la presentación modificada.

A continuación se presenta un ejemplo de muestra.

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