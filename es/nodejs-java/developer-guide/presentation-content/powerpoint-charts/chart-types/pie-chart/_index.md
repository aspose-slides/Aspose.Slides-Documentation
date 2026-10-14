---
title: Personalizar gráficos de sectores en presentaciones usando JavaScript
linktitle: Gráfico de sectores
type: docs
url: /es/nodejs-java/pie-chart/
keywords:
- gráfico de sectores
- gestionar gráfico
- personalizar gráfico
- opciones del gráfico
- configuración del gráfico
- opciones de trazado
- color de la porción
- PowerPoint
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Cree y personalice gráficos de sectores en JavaScript con Aspose.Slides para Node.js a través de Java. Configure tramas secundarias, muestre etiquetas de datos y aplique colores automáticos a las porciones en PowerPoint."
---
## **Descripción general**

Este artículo explica cómo trabajar con gráficos de sectores en Aspose.Slides. Muestra cómo configurar opciones de trama secundaria para los gráficos Pie of Pie y Bar of Pie, y cómo habilitar el coloreado automático de las porciones para un gráfico de sectores estándar.

Los ejemplos se centran en tareas de personalización de gráficos, como añadir un gráfico a una diapositiva, ajustar la serie y la configuración de etiquetas, reemplazar los datos predeterminados del gráfico por categorías y valores personalizados, y guardar la presentación actualizada.

## **Opciones de trama secundaria para gráficos Pie of Pie y Bar of Pie**

Aspose.Slides for Node.js via Java admite opciones de trama secundaria para los gráficos Pie of Pie y Bar of Pie. Estas opciones controlan el tamaño de la trama secundaria y cómo se dividen los puntos de datos entre ambas tramas.

El siguiente ejemplo crea un gráfico Pie of Pie en una nueva presentación y muestra los valores de los puntos de datos como etiquetas. El método [setSecondPieSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setSecondPieSize) establece el tamaño de la trama secundaria en un 149% de la trama principal. [setPieSplitBy](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setPieSplitBy) selecciona la división basada en porcentajes, y [setPieSplitPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setPieSplitPosition) fija el umbral al 53%.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.PieOfPie, 50, 50, 500, 400);
    const series = chart.getChartData().getSeries().get_Item(0);

    // Mostrar valores y configurar la trama secundaria.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    const seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setSecondPieSize(149);
    seriesGroup.setPieSplitBy(aspose.slides.PieSplitType.ByPercentage);
    seriesGroup.setPieSplitPosition(53);

    presentation.save("pie_of_pie.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Seleccionar categorías para la trama secundaria**

Utilice la división personalizada cuando desee agrupar categorías específicas en la trama secundaria sin importar sus valores porcentuales. Por ejemplo, un informe de ventas podría mostrar Online y Events juntos para que los lectores puedan comparar estos dos canales, aunque representen el 35% y el 10% de las ventas totales.

Llame a [setPieSplitBy](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setPieSplitBy) con [PieSplitType.Custom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/piesplittype/#Custom) y seleccione los puntos mediante [getPieSplitCustomPoints](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#getPieSplitCustomPoints). El método [add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/piesplitcustompointcollection/#add) de la colección acepta un índice basado en cero en la serie; use [addItem](https://reference.aspose.com/slides/nodejs-java/aspose.slides/piesplitcustompointcollection/#addItem) para añadir un objeto de punto de datos. En este ejemplo, el índice 1 selecciona Online, y el punto en el índice 3 selecciona Events. Partners también se añade temporalmente, y luego se excluye usando [removeItem](https://reference.aspose.com/slides/nodejs-java/aspose.slides/piesplitcustompointcollection/#removeItem).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.PieOfPie, 50, 50, 600, 200);

    // Reemplazar los datos predeterminados con ventas por canal.
    const workbook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    const categoryNames = [ "Retail", "Online", "Partners", "Events" ];
    const values = [ 40, 35, 15, 10 ];
    const seriesNameCell = workbook.getCell(0, 0, 1, "Sales");
    const series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (let i = 0; i < categoryNames.length; i++) {
        const categoryCell = workbook.getCell(0, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        const valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    const seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setPieSplitBy(aspose.slides.PieSplitType.Custom);
    seriesGroup.setColorVaried(true);

    // Seleccionar Online por su índice basado en cero y Events por su objeto de punto de datos.
    seriesGroup.getPieSplitCustomPoints().add(1);
    seriesGroup.getPieSplitCustomPoints().addItem(series.getDataPoints().get_Item(3));

    // Excluir Partners de la selección sin eliminar sus datos de origen.
    seriesGroup.getPieSplitCustomPoints().add(2);
    seriesGroup.getPieSplitCustomPoints().removeItem(series.getDataPoints().get_Item(2));

    presentation.save("pie_of_pie_custom.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Online (35) y Events (10) aparecen como porciones separadas en la trama secundaria. En la trama principal, se representan mediante una única porción combinada con un valor de 45, junto a Retail (40) y Partners (15). Eliminar Partners de la selección personalizada lo mantiene en la trama principal; no elimina la categoría ni su valor de los datos de origen del gráfico.

La siguiente imagen muestra la presentación guardada en PowerPoint:

![Gráfico Pie of Pie con Online y Events en la trama secundaria y su valor combinado de 45 en la trama principal](pie_of_pie_custom.png)

## **Establecer colores automáticos de las porciones del gráfico de sectores**

Aspose.Slides for Node.js via Java puede asignar automáticamente colores diferentes a las porciones del gráfico de sectores. El siguiente ejemplo crea un gráfico de sectores con un título centrado y reemplaza los datos predeterminados por tres categorías trimestrales y sus valores. El método [setShowValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/#setShowValue) muestra los valores 20, 50 y 30 como etiquetas, mientras que [setColorVaried](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setColorVaried) habilita un color distinto para cada porción.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 100, 100, 400, 400);

    // Añadir un título centrado al gráfico.
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(java.newByte(aspose.slides.NullableBool.True));
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // Reemplazar los datos predeterminados usando la primera hoja de cálculo.
    const workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    const categoryNames = [ "First Qtr", "2nd Qtr", "3rd Qtr" ];
    const values = [ 20, 50, 30 ];
    const seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    const series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (let i = 0; i < categoryNames.length; i++) {
        const categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        const valueCell = workbook.getCell(worksheetIndex, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    // Mostrar valores y asignar colores diferentes a las porciones.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getParentSeriesGroup().setColorVaried(true);

    presentation.save("pie.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Preguntas frecuentes**

**¿Se admiten las variantes Pie of Pie y Bar of Pie?**

Sí, la biblioteca [admite](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) una trama secundaria para los gráficos de sectores, incluidas los tipos Pie of Pie y Bar of Pie.

**¿Puedo exportar solo el gráfico como una imagen (por ejemplo, PNG)?**

Sí, puede [exportar el gráfico como una imagen](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage) (por ejemplo, PNG) sin exportar toda la presentación.