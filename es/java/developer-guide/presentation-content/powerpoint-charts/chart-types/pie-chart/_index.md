---
title: Personalizar gráficos circulares en presentaciones usando Java
linktitle: Gráfico circular
type: docs
url: /es/java/pie-chart/
keywords:
- gráfico circular
- gestionar gráfico
- personalizar gráfico
- opciones de gráfico
- configuración de gráfico
- opciones de trazado
- color de porción
- PowerPoint
- presentación
- Java
- Aspose.Slides
description: "Crear y personalizar gráficos circulares en Java con Aspose.Slides. Configurar gráficos secundarios, mostrar etiquetas de datos y aplicar colores automáticos a las porciones en PowerPoint."
---
## **Visión general**

Este artículo explica cómo trabajar con gráficos circulares en Aspose.Slides. Muestra cómo configurar las opciones de gráfico secundario para los gráficos Pie of Pie y Bar of Pie, y cómo habilitar el coloreado automático de las porciones en un gráfico circular estándar.

Los ejemplos se centran en tareas de personalización de gráficos, como añadir un gráfico a una diapositiva, ajustar la configuración de series y etiquetas, sustituir los datos predeterminados del gráfico por categorías y valores personalizados, y guardar la presentación actualizada.

## **Opciones de gráfico secundario para Pie of Pie y Bar of Pie**

Aspose.Slides for Java admite opciones de gráfico secundario para los gráficos Pie of Pie y Bar of Pie. Estas opciones controlan el tamaño del gráfico secundario y la forma en que los puntos de datos se dividen entre los dos gráficos.

El siguiente ejemplo crea un gráfico Pie of Pie en una nueva presentación y muestra los valores de los puntos de datos como etiquetas. El método [setSecondPieSize](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setSecondPieSize-int-) establece el tamaño del gráfico secundario al 149% del gráfico principal. [setPieSplitBy](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setPieSplitBy-int-) selecciona la división basada en porcentajes, y [setPieSplitPosition](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setPieSplitPosition-double-) establece el umbral al 53%.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    // Mostrar valores y configurar el gráfico secundario.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    IChartSeriesGroup seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setSecondPieSize(149);
    seriesGroup.setPieSplitBy(PieSplitType.ByPercentage);
    seriesGroup.setPieSplitPosition(53);

    presentation.save("pie_of_pie.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Seleccionar categorías para el gráfico secundario**

Utilice división personalizada cuando desee agrupar categorías específicas en el gráfico secundario sin importar sus valores porcentuales. Por ejemplo, un informe de ventas podría mostrar Online y Events juntos para que los lectores comparen estos dos canales, aun cuando representen el 35% y el 10% de las ventas totales.

Llame a [setPieSplitBy](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setPieSplitBy-int-) con [PieSplitType.Custom](https://reference.aspose.com/slides/java/com.aspose.slides/piesplittype/#Custom) y seleccione los puntos mediante [getPieSplitCustomPoints](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#getPieSplitCustomPoints--). El método [add](https://reference.aspose.com/slides/java/com.aspose.slides/piesplitcustompointcollection/#add-int-) de la colección acepta un índice basado en cero en la serie; utilice [addItem](https://reference.aspose.com/slides/java/com.aspose.slides/piesplitcustompointcollection/#addItem-com.aspose.slides.IChartDataPoint-) para añadir un objeto de punto de datos. En este ejemplo, el índice 1 selecciona Online, y el punto en el índice 3 selecciona Events. Partners también se añade temporalmente, y luego se excluye usando [removeItem](https://reference.aspose.com/slides/java/com.aspose.slides/piesplitcustompointcollection/#removeItem-com.aspose.slides.IChartDataPoint-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 600, 200);

    // Reemplazar los datos predeterminados con ventas por canal.
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    String[] categoryNames = { "Retail", "Online", "Partners", "Events" };
    int[] values = { 40, 35, 15, 10 };
    IChartDataCell seriesNameCell = workbook.getCell(0, 0, 1, "Sales");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (int i = 0; i < categoryNames.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    IChartSeriesGroup seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setPieSplitBy(PieSplitType.Custom);
    seriesGroup.setColorVaried(true);

    // Seleccionar Online por su índice base cero y Events por su objeto de punto de datos.
    seriesGroup.getPieSplitCustomPoints().add(1);
    seriesGroup.getPieSplitCustomPoints().addItem(series.getDataPoints().get_Item(3));

    // Excluir Partners de la selección sin eliminar sus datos de origen.
    seriesGroup.getPieSplitCustomPoints().add(2);
    seriesGroup.getPieSplitCustomPoints().removeItem(series.getDataPoints().get_Item(2));

    presentation.save("pie_of_pie_custom.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Online (35) y Events (10) aparecen como porciones separadas en el gráfico secundario. En el gráfico principal, se representan mediante una única porción combinada con un valor de 45, junto a Retail (40) y Partners (15). Eliminar Partners de la selección personalizada lo mantiene en el gráfico principal; no elimina la categoría ni su valor de los datos de origen del gráfico.

La siguiente imagen muestra la presentación guardada en PowerPoint:

![Gráfico Pie of Pie con Online y Events en el gráfico secundario y su valor combinado de 45 en el gráfico principal](pie_of_pie_custom.png)

## **Establecer colores automáticos para las porciones del gráfico circular**

Aspose.Slides for Java puede asignar automáticamente diferentes colores a las porciones de un gráfico circular. El siguiente ejemplo crea un gráfico circular con un título centrado y sustituye los datos predeterminados por tres categorías trimestrales y sus valores. El método [setShowValue](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) muestra los valores 20, 50 y 30 como etiquetas, mientras que [setColorVaried](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setColorVaried-boolean-) habilita un color distinto para cada porción.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);

    // Añadir un título centrado al gráfico.
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // Reemplazar los datos predeterminados usando la primera hoja de cálculo.
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    String[] categoryNames = { "First Qtr", "2nd Qtr", "3rd Qtr" };
    int[] values = { 20, 50, 30 };
    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (int i = 0; i < categoryNames.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(worksheetIndex, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    // Mostrar valores y asignar colores diferentes a las porciones.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getParentSeriesGroup().setColorVaried(true);

    presentation.save("pie.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Preguntas frecuentes**

**¿Se admiten las variaciones Pie of Pie y Bar of Pie?**

Sí, la biblioteca [supports](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) un gráfico secundario para los gráficos circulares, incluidos los tipos Pie of Pie y Bar of Pie.

**¿Puedo exportar solo el gráfico como una imagen (por ejemplo, PNG)?**

Sí, puede [export the chart itself as an image](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage--) (como PNG) sin exportar la presentación completa.