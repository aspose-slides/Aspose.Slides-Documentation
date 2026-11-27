---
title: Formatear gráficos de presentación en Android
linktitle: Formato de gráficos
type: docs
weight: 60
url: /es/androidjava/chart-formatting/
keywords:
- formato de gráfico
- formato de gráfico
- entidad de gráfico
- propiedades de gráfico
- configuración de gráfico
- opciones de gráfico
- propiedades de fuente
- borde redondeado
- PowerPoint
- presentación
- Android
- Java
- Aspose.Slides
description: "Aprenda el formato de gráficos en Aspose.Slides para Android mediante Java y mejore su presentación de PowerPoint con ejes personalizados, fuentes, formatos numéricos y bordes de gráfico redondeados."
---
## **Visión general**

Este artículo explica cómo dar formato a los gráficos en presentaciones de PowerPoint utilizando Aspose.Slides. Muestra cómo personalizar elementos clave del gráfico como ejes, líneas de cuadrícula, títulos, leyendas, el área de trazado y los rellenos de paredes para mejorar la apariencia y la legibilidad de los datos del gráfico.

También demuestra cómo establecer propiedades de fuente para el texto del gráfico, aplicar formatos numéricos predefinidos a los datos del gráfico y habilitar esquinas redondeadas para el área del gráfico. En conjunto, estos ejemplos muestran cómo controlar tanto el estilo visual como la presentación de datos de los gráficos en una presentación.

Para rellenos y contornos separados en intervalos ascendentes y descendentes, consulte el [ejemplo de gráfico de acciones](/slides/es/androidjava/create-chart/#create-stock-charts).

## **Formatear entidades del gráfico**

Utilice [IChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/) para dar formato a los títulos del gráfico, ejes, líneas de cuadrícula, leyendas y el área de trazado. Este ejemplo crea un gráfico de líneas con marcadores y datos predeterminados, y luego aplica estilos de texto y de línea separados a sus ejes de valores y de categorías. Los tamaños de fuente y los grosores de línea se especifican en puntos; las etiquetas de categoría se rotan 45 grados.

El eje de valores utiliza [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setNumberFormat-java.lang.String-) de forma independiente de las celdas de origen. Su escala va de -2 a 15, con intervalos mayores de 2 y menores de 0,5. El ejemplo también combina el formato de porcentaje con [setDisplayUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setDisplayUnit-int-) configurado en miles, así que adapte estos ajustes al significado y la magnitud de sus datos. La leyenda permanece fuera del área de trazado porque se llama a [setOverlay](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilegend/#setOverlay-boolean-) con `false`. Los rellenos de la pared trasera y del suelo se configuran mediante [getBackWall](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getBackWall--) y [getFloor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getFloor--), pero estas superficies solo son visibles en gráficos 3D.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("");
    IPortion chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Sample Chart");
    chartTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(NullableBool.True);

    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot);

    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");

    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setAutomaticMinorUnit(false);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);

    chart.getAxes().getVerticalAxis().setMaxValue(15f);
    chart.getAxes().getVerticalAxis().setMinValue(-2f);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0f);

    IChartPortionFormat valueAxisText = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    valueAxisText.setFontBold(NullableBool.True);
    valueAxisText.setFontHeight(16);
    valueAxisText.setFontItalic(NullableBool.True);
    valueAxisText.getFillFormat().setFillType(FillType.Solid);
    valueAxisText.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkGreen);
    valueAxisText.setLatinFont(new FontData("Times New Roman"));

    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    IPortion valueAxisTitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valueAxisTitle.setText("Primary Axis");
    valueAxisTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    valueAxisTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    valueAxisTitle.getPortionFormat().setFontHeight(20);
    valueAxisTitle.getPortionFormat().setFontBold(NullableBool.True);
    valueAxisTitle.getPortionFormat().setFontItalic(NullableBool.True);

    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 128, 0));
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);

    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    IChartPortionFormat categoryAxisText = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    categoryAxisText.setFontBold(NullableBool.True);
    categoryAxisText.setFontHeight(16);
    categoryAxisText.setFontItalic(NullableBool.True);
    categoryAxisText.getFillFormat().setFillType(FillType.Solid);
    categoryAxisText.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    categoryAxisText.setLatinFont(new FontData("Arial"));

    chart.getAxes().getHorizontalAxis().setTitle(true);
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");

    IPortion categoryAxisTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    categoryAxisTitle.setText("Sample Category");
    categoryAxisTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    categoryAxisTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    categoryAxisTitle.getPortionFormat().setFontHeight(20);
    categoryAxisTitle.getPortionFormat().setFontBold(NullableBool.True);
    categoryAxisTitle.getPortionFormat().setFontItalic(NullableBool.True);

    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low);
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);

    IChartPortionFormat legendText = chart.getLegend().getTextFormat().getPortionFormat();
    legendText.setFontBold(NullableBool.True);
    legendText.setFontHeight(16);
    legendText.setFontItalic(NullableBool.True);
    legendText.getFillFormat().setFillType(FillType.Solid);
    legendText.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkRed);

    chart.getLegend().setOverlay(false);

    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid);
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid);
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED);

    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid);
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setPresetColor(PresetColor.LightCyan);

    presentation.save("FormattedChart_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Establecer propiedades de fuente para un gráfico**

Establezca el tamaño de fuente predeterminado para el texto del gráfico a través de [Chart.getTextFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#getTextFormat--). El ejemplo crea un gráfico de columnas agrupadas con una fuente de 20 puntos y habilita las etiquetas de valor para la primera serie mediante [setShowValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setShowValue-boolean-). Los elementos de texto con sus propias configuraciones explícitas de fuente pueden sobrescribir el valor predeterminado del gráfico.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    chart.getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Reutilizar el formato de marco de texto para la leyenda de un gráfico**

Para que una leyenda coincida con el encabezado de una diapositiva, establezca la fuente del encabezado mediante [getDefaultPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) en el primer párrafo. Llame a [copyFrom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icharttextformat/#copyFrom-com.aspose.slides.ITextFrame-) sobre el formato devuelto por el [getTextFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformattedtextcontainer/#getTextFormat--) de la leyenda. Copia la configuración del marco de texto, el formato del primer párrafo y las propiedades de fuente predeterminadas de ese párrafo. El formato aplicado directamente a porciones individuales o a párrafos posteriores permanece local al origen.

El ejemplo utiliza un encabezado en Calibri de 26 puntos, negrita y color azul marino como plantilla. Después de dar estilo a la leyenda, llama a [copyTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icharttextformat/#copyTo-com.aspose.slides.ITextFrame-) para aplicar el mismo formato a una leyenda separada.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IAutoShape heading = shapes.addAutoShape(ShapeType.Rectangle, 40, 20, 640, 40, false);
    ITextFrame sourceTextFrame = heading.addTextFrame("Quarterly sales");
    IPortionFormat font = sourceTextFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
    font.setLatinFont(new FontData("Calibri"));
    font.setFontHeight(26);
    font.setFontBold(NullableBool.True);
    font.getFillFormat().setFillType(FillType.Solid);
    font.getFillFormat().getSolidFillColor().setColor(Color.rgb(32, 64, 96));

    IChart chart = shapes.addChart(ChartType.ClusteredColumn, 40, 75, 640, 360);
    chart.setStyle(StyleType.Style3);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.getCell(0, 0, 1).setValue("Retail");
    workbook.getCell(0, 0, 2).setValue("Online");
    workbook.getCell(0, 0, 3).setValue("Wholesale");
    for (int quarter = 1; quarter <= 4; quarter++) {
        workbook.getCell(0, quarter, 0).setValue("Q" + quarter);
    }

    chart.setLegend(true);
    chart.getLegend().setPosition(LegendPositionType.Bottom);
    IChartTextFormat legendFormat = chart.getLegend().getTextFormat();
    legendFormat.copyFrom(sourceTextFrame);

    IAutoShape caption = shapes.addAutoShape(ShapeType.Rectangle, 40, 460, 640, 40, false);
    ITextFrame captionTextFrame = caption.addTextFrame("Sales in millions of dollars");
    legendFormat.copyTo(captionTextFrame);

    presentation.save("legend-formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

En la presentación guardada, la leyenda y la leyenda secundaria coinciden con el encabezado en tamaño, peso y color. La leyenda sigue mostrando los nombres de las series y la leyenda secundaria conserva su propio texto. Si una porción en la leyenda secundaria ya tiene un tamaño de fuente explícito, ese tamaño prevalece sobre el párrafo predeterminado copiado.

| Antes de copiar | Después de copiar |
| --- | --- |
| ![Gráfico de ventas trimestrales con etiquetas de leyenda negras normales y una leyenda negra](legend-formatting-before.png) | ![El mismo gráfico con etiquetas de leyenda más grandes, en negrita y azul marino, y una leyenda coincidente](legend-formatting.png) |

## **Establecer el formato numérico**

Utilice [IChartDataCell.setPresetNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setPresetNumberFormat-byte-) para aplicar un formato numérico incorporado a las celdas del libro de trabajo del gráfico. Este ejemplo crea un gráfico de columnas agrupadas con datos predeterminados almacenados en celdas y aplica el índice de formato 10 (`0.00%`) a cada celda de valor de serie. Esto cambia la forma en que se muestran los valores en el libro sin modificar los números subyacentes; por ejemplo, 0,25 se muestra como 25,00 %. Los formatos del eje y de las etiquetas de datos pueden configurarse por separado.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400);
    IChartSeriesCollection series = chart.getChartData().getSeries();

    for (IChartSeries chartSeries : series)
    {
        for (IChartDataPoint dataPoint : chartSeries.getDataPoints())
        {
            dataPoint.getValue().getAsCell().setPresetNumberFormat((byte) 10); // 0.00%
        }
    }

    presentation.save("PresetNumberFormat_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La tabla siguiente enumera los índices de formatos numéricos incorporados con ejemplos representativos de formatos de Excel para la configuración regional inglés (Estados Unidos). Las cadenas de formato exactas y su visualización pueden variar según la aplicación y la configuración regional, particularmente para monedas y fechas. Algunos formatos de Excel también difieren de los valores predeterminados del estándar OOXML, como se describe en las [Notas de implementación del formato numérico de Microsoft](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528).

| Índice | Formato |
| --- | --- |
| 0 | `General` |
| 1 | `0` |
| 2 | `0.00` |
| 3 | `#,##0` |
| 4 | `#,##0.00` |
| 5 | `"$"#,##0_);("$"#,##0)` |
| 6 | `"$"#,##0_);[Red]("$"#,##0)` |
| 7 | `"$"#,##0.00_);("$"#,##0.00)` |
| 8 | `"$"#,##0.00_);[Red]("$"#,##0.00)` |
| 9 | `0%` |
| 10 | `0.00%` |
| 11 | `0.00E+00` |
| 12 | `# ?/?` |
| 13 | `# ??/??` |
| 14 | `m/d/yyyy` |
| 15 | `d-mmm-yy` |
| 16 | `d-mmm` |
| 17 | `mmm-yy` |
| 18 | `h:mm AM/PM` |
| 19 | `h:mm:ss AM/PM` |
| 20 | `h:mm` |
| 21 | `h:mm:ss` |
| 22 | `m/d/yyyy h:mm` |
| 37 | `#,##0_);(#,##0)` |
| 38 | `#,##0_);[Red](#,##0)` |
| 39 | `#,##0.00_);(#,##0.00)` |
| 40 | `#,##0.00_);[Red](#,##0.00)` |
| 41 | `_(* #,##0_);_(* (#,##0);_(* "-"_);_(@_)` |
| 42 | `_("$"* #,##0_);_("$"* (#,##0);_("$"* "-"_);_(@_)` |
| 43 | `_(* #,##0.00_);_(* (#,##0.00);_(* "-"??_);_(@_)` |
| 44 | `_("$"* #,##0.00_);_("$"* (#,##0.00);_("$"* "-"??_);_(@_)` |
| 45 | `mm:ss` |
| 46 | `[h]:mm:ss` |
| 47 | `mm:ss.0` |
| 48 | `##0.0E+0` |
| 49 | `@` |

## **Establecer bordes redondeados del área del gráfico**

Llame a [IChart.setRoundedCorners](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setRoundedCorners-boolean-) con `true` para redondear las esquinas del área del gráfico. El ejemplo crea un gráfico de columnas agrupadas y utiliza [getLineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getLineFormat--) para dar a su contorno un color gris sólido y un estilo de línea única antes de guardar la presentación.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    chart.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    chart.getLineFormat().setStyle(LineStyle.Single);
    chart.setRoundedCorners(true);

    presentation.save("out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Editar anotaciones de gráficos existentes**

Un gráfico puede contener formas personalizadas, como una anotación de texto que explique el estado de un informe. Acceda a estas formas mediante [IChart.getUserShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getUserShapes--), también enumeradas bajo [Chart.getUserShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#getUserShapes--) en la referencia de la API de Chart. La colección devuelta por [getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/#getShapes--) contiene las formas propietarias del gráfico.

Un cuadro de texto ordinario colocado sobre un gráfico pertenece a la diapositiva, aunque parezca parte del gráfico. Recorrer [Slide.getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseslide/#getShapes--) encuentra el gráfico y las formas normales de la diapositiva, pero no enumera las formas individuales dentro del gráfico. Los títulos del gráfico y las etiquetas de datos son elementos de gráfico independientes, no anotaciones personalizadas en esta colección.

Descargue [chart-annotations.pptx](chart-annotations.pptx) y colóquelo en el directorio de trabajo de la aplicación. Su primera diapositiva contiene un gráfico con una anotación desagrupada que dice "Preliminary results", una línea propietaria del gráfico y un cuadro de texto de diapositiva que dice "Slide overlay". El ejemplo encuentra el primer gráfico en esa diapositiva y cambia la anotación a "Final results" cuando el informe está listo para publicarse. Verifica que la colección no esté vacía y solo edita un [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) con un marco de texto no nulo devuelto por [getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/#getTextFrame--) y el texto esperado.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart-annotations.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = null;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IChart) {
            chart = (IChart) shape;
            break;
        }
    }

    if (chart == null || chart.getUserShapes().getShapes().size() == 0) {
        System.out.println("No chart or chart-owned shapes found.");
        return;
    }

    boolean updated = false;
    for (IShape shape : chart.getUserShapes().getShapes()) {
        if (shape instanceof IAutoShape) {
            IAutoShape annotation = (IAutoShape) shape;
            if (annotation.getTextFrame() != null && "Preliminary results".equals(annotation.getTextFrame().getText())) {
                annotation.getTextFrame().setText("Final results");
                updated = true;
                break;
            }
        }
    }

    if (updated) {
        presentation.save("chart-annotations-updated.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("No matching text annotation found.");
    }
} finally {
    presentation.dispose();
}
```

La línea y el cuadro de texto de la diapositiva permanecen sin cambios. Las siguientes imágenes muestran la entrada y el resultado guardado y reabierto:

| Antes de editar | Después de editar |
| --- | --- |
| ![Anotación del gráfico que muestra Resultados preliminares](chart-annotations-before.png) | ![Anotación del gráfico que muestra Resultados finales](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}

El ejemplo inspecciona solo las formas propietarias del gráfico de nivel superior. Si una anotación está dentro de un [IGroupShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/), inspeccione también la colección [getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/#getShapes--) de ese grupo. Repita esto de forma recursiva para grupos anidados, aplicando las mismas comprobaciones de texto a sus formas hijas. Un grupo en sí es un contenedor; no lo trate como un cuadro de texto.

{{% /alert %}}

## **Preguntas frecuentes**

**¿Puedo establecer rellenos semitransparentes para columnas/áreas manteniendo el contorno opaco?**

Sí. La transparencia del relleno y el contorno se configuran por separado. Esto es útil para mejorar la legibilidad de la cuadrícula y los datos en visualizaciones densas.

**¿Cómo puedo gestionar las etiquetas de datos cuando se solapan?**

Reduzca el tamaño de la fuente, desactive componentes de etiqueta no esenciales (por ejemplo, categorías), ajuste la posición de la etiqueta, muestre etiquetas solo para los puntos seleccionados si es necesario, o cambie el formato a "valor + leyenda".

**¿Puedo aplicar rellenos degradados o de patrón a las series?**

Sí. Las series admiten rellenos sólidos, degradados y de patrón. En la práctica, utilice degradados con moderación y evite combinaciones que reduzcan el contraste con la cuadrícula y el texto.