---
title: Gestionar etiquetas de datos de gráficos en presentaciones usando Java
linktitle: Etiqueta de datos
type: docs
url: /es/java/chart-data-label/
keywords:
- gráfico
- etiqueta de datos
- precisión de datos
- porcentaje
- distancia de etiqueta
- ubicación de etiqueta
- PowerPoint
- presentación
- Java
- Aspose.Slides
description: "Aprenda a agregar y dar formato a las etiquetas de datos de gráficos en presentaciones de PowerPoint usando Aspose.Slides para Java para diapositivas más atractivas."
---
## **Introducción**

Las etiquetas de datos muestran información sobre las series del gráfico y los puntos de datos individuales, ayudando a los lectores a identificar valores y comprender el gráfico. Este artículo explica cómo dar formato a los valores, mostrar porcentajes, leer el texto de las etiquetas, ajustar el espaciado de las etiquetas del eje de categorías y posicionar las etiquetas de los gráficos de sectores.

## **Establecer la precisión de los datos en las etiquetas de datos del gráfico**

Utilice [setNumberFormatOfValues](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartseries/#setNumberFormatOfValues-java.lang.String-) para dar formato a los valores de la serie. Este ejemplo crea un gráfico de líneas con datos predeterminados, muestra su tabla de datos y habilita las etiquetas de valor para la primera serie. El formato `#,##0.00` muestra un separador de miles y dos decimales sin modificar los valores subyacentes.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300);
    chart.setDataTable(true);

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    series.setNumberFormatOfValues("#,##0.00");
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("PrecisionOfDatalabels_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Mostrar porcentaje como etiquetas**

Para un gráfico de columnas apiladas, calcule cada valor como un porcentaje del total de su categoría y asigne el texto al marco de texto devuelto por [getTextFrameForOverriding](https://reference.aspose.com/slides/es/java/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--). Este ejemplo utiliza los datos predeterminados del gráfico y muestra los porcentajes con dos decimales en una fuente de 8 puntos. Las categorías con un total cero se omiten para evitar la división por cero. Recalcule el texto de la etiqueta personalizada si los datos del gráfico cambian.

```java
import com.aspose.slides.*;
import java.util.Locale;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 400, 400);

    double[] categoryTotals = new double[chart.getChartData().getCategories().size()];
    for (int k = 0; k < chart.getChartData().getCategories().size(); k++) {
        for (int i = 0; i < chart.getChartData().getSeries().size(); i++) {
            IChartSeries series = chart.getChartData().getSeries().get_Item(i);
            Number pointValue = (Number) series.getDataPoints().get_Item(k).getValue().getData();
            categoryTotals[k] += pointValue.doubleValue();
        }
    }

    for (int x = 0; x < chart.getChartData().getSeries().size(); x++) {
        IChartSeries series = chart.getChartData().getSeries().get_Item(x);
        series.getLabels().getDefaultDataLabelFormat().setShowLegendKey(false);

        for (int j = 0; j < series.getDataPoints().size(); j++) {
            IDataLabel label = series.getDataPoints().get_Item(j).getLabel();
            if (categoryTotals[j] == 0) {
                continue;
            }

            Number pointValue = (Number) series.getDataPoints().get_Item(j).getValue().getData();
            double dataPointPercent = (pointValue.doubleValue() / categoryTotals[j]) * 100;

            IPortion portion = new Portion();
            portion.setText(String.format(Locale.US, "%.2f %%", dataPointPercent));
            portion.getPortionFormat().setFontHeight(8f);

            label.getTextFrameForOverriding().setText("");
            IParagraph paragraph = label.getTextFrameForOverriding().getParagraphs().get_Item(0);
            paragraph.getPortions().add(portion);

            label.getDataLabelFormat().setShowValue(true);
            label.getDataLabelFormat().setShowSeriesName(false);
            label.getDataLabelFormat().setShowPercentage(false);
            label.getDataLabelFormat().setShowLegendKey(false);
            label.getDataLabelFormat().setShowCategoryName(false);
            label.getDataLabelFormat().setShowBubbleSize(false);
        }
    }

    presentation.save("DisplayPercentageAsLabels_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Establecer el signo de porcentaje en las etiquetas de datos del gráfico**

Cuando los valores se almacenan como fracciones, utilice [setNumberFormat](https://reference.aspose.com/slides/es/java/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-). Pase `false` a [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/es/java/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) para aplicar el formato de la etiqueta de forma independiente de las celdas de origen.

Este ejemplo crea un gráfico de columnas apiladas al 100% con series roja y azul en cuatro categorías. Cada pareja de valores suma 1. El formato de etiqueta `0.0%` muestra 0.30 como 30.0%, mientras que el eje vertical usa dos decimales. Ambas series utilizan texto de etiqueta blanco de 10 puntos.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%");

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;
    for (int i = 0; i < 4; i++) {
        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
    }

    String[] seriesNames = { "Reds", "Blues" };
    Color[] seriesColors = { Color.RED, Color.BLUE };
    double[][] values = { { 0.30, 0.50, 0.80, 0.65 }, { 0.70, 0.50, 0.20, 0.35 } };

    for (int i = 0; i < seriesNames.length; i++) {
        IChartDataCell seriesCell = workbook.getCell(worksheetIndex, 0, i + 1, seriesNames[i]);
        IChartSeries series = chart.getChartData().getSeries().add(seriesCell, chart.getType());
        for (int j = 0; j < 4; j++) {
            IChartDataCell valueCell = workbook.getCell(worksheetIndex, j + 1, i + 1, values[i][j]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }

        series.getFormat().getFill().setFillType(FillType.Solid);
        series.getFormat().getFill().getSolidFillColor().setColor(seriesColors[i]);

        IDataLabelFormat labelFormat = series.getLabels().getDefaultDataLabelFormat();
        labelFormat.setShowValue(true);
        labelFormat.setNumberFormatLinkedToSource(false);
        labelFormat.setNumberFormat("0.0%");
        labelFormat.getTextFormat().getPortionFormat().setFontHeight(10);
        labelFormat.getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
        labelFormat.getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.WHITE);
    }

    presentation.save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Leer el texto real de las etiquetas de datos**

Utilice [getActualLabelText](https://reference.aspose.com/slides/es/java/com.aspose.slides/idatalabel/#getActualLabelText--) para recuperar el texto producido por la configuración de una etiqueta de datos. Esto es útil al extraer etiquetas para informes, buscar contenido en presentaciones o validar gráficos generados. En el ejemplo a continuación, el [formato de etiqueta de datos](https://reference.aspose.com/slides/es/java/com.aspose.slides/idatalabelformat/) predeterminado combina el nombre de cada categoría, el nombre de la serie y el valor. Un punto formatea su valor como porcentaje y otro utiliza texto personalizado de [getTextFrameForOverriding](https://reference.aspose.com/slides/es/java/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    IChartDataCell firstCategoryCell = workbook.getCell(0, 1, 0, "Q1");
    chart.getChartData().getCategories().add(firstCategoryCell);
    IChartDataCell secondCategoryCell = workbook.getCell(0, 2, 0, "Q2");
    chart.getChartData().getCategories().add(secondCategoryCell);

    IChartDataCell northSeriesCell = workbook.getCell(0, 0, 1, "North");
    IChartSeries north = chart.getChartData().getSeries().add(northSeriesCell, chart.getType());
    IChartDataCell northFirstValueCell = workbook.getCell(0, 1, 1, 0.25);
    north.getDataPoints().addDataPointForBarSeries(northFirstValueCell);
    IChartDataCell northSecondValueCell = workbook.getCell(0, 2, 1, 0.75);
    north.getDataPoints().addDataPointForBarSeries(northSecondValueCell);

    IChartDataCell southSeriesCell = workbook.getCell(0, 0, 2, "South");
    IChartSeries south = chart.getChartData().getSeries().add(southSeriesCell, chart.getType());
    IChartDataCell southFirstValueCell = workbook.getCell(0, 1, 2, 0.40);
    south.getDataPoints().addDataPointForBarSeries(southFirstValueCell);
    IChartDataCell southSecondValueCell = workbook.getCell(0, 2, 2, 0.60);
    south.getDataPoints().addDataPointForBarSeries(southSecondValueCell);

    for (IChartSeries series : chart.getChartData().getSeries()) {
        IDataLabelFormat format = series.getLabels().getDefaultDataLabelFormat();
        format.setShowCategoryName(true);
        format.setShowSeriesName(true);
        format.setShowValue(true);
    }

    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormatLinkedToSource(false);
    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormat("0%");
    south.getLabels().get_Item(0).getTextFrameForOverriding().setText("Reviewed");

    for (IChartSeries series : chart.getChartData().getSeries()) {
        for (IChartDataPoint point : series.getDataPoints()) {
            IDataLabel label = point.getLabel();
            if (!label.isVisible()) {
                continue;
            }

            System.out.println("Value: " + point.getValue().getData() + "; label: " + label.getActualLabelText());
        }
    }
} finally {
    presentation.dispose();
}
```

El número almacenado en un punto de datos sigue siendo `0.75`, incluso cuando su etiqueta muestra `75%` junto con los nombres de categoría y serie. El texto personalizado reemplaza el texto generado de la etiqueta. [getActualLabelText](https://reference.aspose.com/slides/es/java/com.aspose.slides/idatalabel/#getActualLabelText--) devuelve la cadena de etiqueta resultante en ambos casos. Compruebe [isVisible](https://reference.aspose.com/slides/es/java/com.aspose.slides/idatalabel/#isVisible--) por separado, como se muestra arriba, cuando quiera extraer solo las etiquetas visibles.

## **Establecer la distancia de la etiqueta desde un eje**

Utilice [setLabelOffset](https://reference.aspose.com/slides/es/java/com.aspose.slides/iaxis/#setLabelOffset-int-) para controlar la distancia entre las etiquetas del eje de categorías y el eje. El valor es un porcentaje del tamaño máximo de fuente de las etiquetas del eje. Este ejemplo crea un gráfico de columnas agrupadas y establece el desplazamiento de etiqueta del eje horizontal en 500. Esta configuración afecta a las etiquetas del eje de categorías más que a las etiquetas adjuntas a puntos de datos individuales.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
    chart.getAxes().getHorizontalAxis().setLabelOffset(500);

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ajustar la ubicación de la etiqueta**

En un gráfico de sectores, ajuste la posición de las etiquetas de datos para mejorar el espaciado y dejar espacio a las líneas guía.

Este ejemplo muestra el valor del primer punto de datos, coloca su etiqueta fuera del sector y ajusta sus desplazamientos horizontal y vertical usando [setX](https://reference.aspose.com/slides/es/java/com.aspose.slides/ilayoutable/#setX-float-) y [setY](https://reference.aspose.com/slides/es/java/com.aspose.slides/ilayoutable/#setY-float-). Estos desplazamientos son relativos al ancho y alto del gráfico, respectivamente.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 200, 200);
    IChartSeriesCollection series = chart.getChartData().getSeries();

    IDataLabel label = series.get_Item(0).getLabels().get_Item(0);
    label.getDataLabelFormat().setShowValue(true);
    label.getDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd);
    label.setX(0.71f);
    label.setY(0.04f);

    presentation.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Gráfico de sectores con una posición de etiqueta de datos ajustada](pie-chart-adjusted-label.png)

## **Preguntas frecuentes**

**¿Cómo puedo evitar que las etiquetas de datos se solapen en gráficos densos?**

Combine la colocación automática de etiquetas, líneas guía y reducción del tamaño de fuente; si es necesario, oculte algunos campos (por ejemplo, la categoría) o muestre etiquetas solo para valores extremos o puntos clave.

**¿Cómo puedo desactivar las etiquetas solo para valores cero, negativos o vacíos?**

Filtre los puntos de datos antes de habilitar las etiquetas y desactive la visualización para valores de 0, valores negativos o valores ausentes según una regla definida.

**¿Cómo puedo garantizar un estilo de etiqueta coherente al exportar a PDF/imagenes?**

Establezca explícitamente la familia y el tamaño de fuente y verifique que la tipografía esté disponible en el entorno de renderizado para evitar sustituciones.