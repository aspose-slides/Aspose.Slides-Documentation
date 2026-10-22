---
title: Управление данными серии диаграммы в презентациях с помощью JavaScript
linktitle: Серии данных
type: docs
url: /ru/nodejs-java/chart-series/
keywords:
- серия диаграммы
- перекрытие серии
- цвет серии
- имя серии
- точка данных
- ячейка книги
- зазор серии
- отрицательное значение
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Узнайте, как управлять сериями диаграмм, точками данных, ячейками книги, форматированием, перекрытием, шириной зазора и отрицательными значениями в презентациях с помощью JavaScript."
---
## **Обзор**

Диаграмма может хранить построенные значения в ячейках книги или непосредственно как числовые литералы. [ChartSeries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/) представляет один набор связанных значений, а каждый [ChartDataPoint](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/) представляет точку в этом наборе. Объекты [ChartCategory](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartcategory/) предоставляют метки или группирующие значения, общие для серий. В диаграммах, созданных с данными по умолчанию, имена серий, категории и значения точек используют объекты [ChartDataCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/) из книги диаграммы.

Для типичной диаграммы категорий рабочая книга по умолчанию использует строку 0 для имён серий, столбец 0 для имён категорий и оставшиеся ячейки — для значений серий. Индексы листа, строки и столбца, передаваемые в [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/getcell/), являются нулевыми. Такой макет удобен, когда вы создаёте диаграмму с данными по умолчанию, но не следует считать, что каждый существующий график использует его. Для загруженной презентации сначала проверьте ячейки, на которые ссылаются серии, категории и точки данных, прежде чем менять значения книги.

Параметры диаграммы имеют три разных уровня области действия:

- Параметры уровня серии, такие как [ChartSeries.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getformat/), задают внешний вид по умолчанию для всех точек в одной серии.
- Параметры точки данных, такие как [ChartDataPoint.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getformat/), переопределяют внешний вид серии для одной точки.
- Параметры группы применяются к совместимым сериям, принадлежащим одному [ChartSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/). Получите доступ к группе через [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getparentseriesgroup/), когда необходимо задать параметры, такие как перекрытие или ширина зазора.

Если явно не задано заполнение точки или серии, стиль и тема диаграммы определяют автоматический вид. Когда присутствует как форматирование серии, так и точечной настройки, приоритет имеет форматирование точки.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Установка значений серии с помощью числовых литералов**

Используйте числовые литералы, когда значения серии берутся из данных приложения или расчётов и не требуют ссылок на ячейки листа. Вызовите [setDataSourceTypeForValues](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforvalues/) с [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datasourcetype/) до назначения результата [getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getvalue/) каждой точки через [setAsLiteralDouble](https://reference.aspose.com/slides/nodejs-java/aspose.slides/doublechartvalue/setasliteraldouble/).

Параметр коллекции управляет типом источника всех значений точек в этой серии. Метод [getDataSourceType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/basechartvalue/) каждой точки возвращает выбранный тип; изменить его можно через параметр коллекции. С `Worksheet` используйте [getAsCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/doublechartvalue/getascell/) для доступа к ссылочной ячейке. С `DoubleLiterals` используйте [getAsLiteralDouble](https://reference.aspose.com/slides/nodejs-java/aspose.slides/doublechartvalue/getasliteraldouble/) или `setAsLiteralDouble` для прямого чтения или записи числа.

Следующий пример создаёт столбчатую диаграмму с сериями и категориями по умолчанию, затем назначает рассчитанные значения 10, 20 и т.д. существующим точкам первой серии. Он сохраняет презентацию, открывает её снова и выводит сохранённые значения.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 300);
    const series = chart.getChartData().getSeries().get_Item(0);

    series.getDataPoints().setDataSourceTypeForValues(aspose.slides.DataSourceType.DoubleLiterals);
    for (let i = 0; i < series.getDataPoints().size(); i++) {
        series.getDataPoints().get_Item(i).getValue().setAsLiteralDouble((i + 1) * 10);
    }

    presentation.save("numeric_literals.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const reopenedPresentation = new aspose.slides.Presentation("numeric_literals.pptx");
try {
    const reopenedSlide = reopenedPresentation.getSlides().get_Item(0);
    const reopenedChart = reopenedSlide.getShapes().get_Item(0);
    const reopenedSeries = reopenedChart.getChartData().getSeries().get_Item(0);
    for (let i = 0; i < reopenedSeries.getDataPoints().size(); i++) {
        const point = reopenedSeries.getDataPoints().get_Item(i);
        console.log(point.getValue().getAsLiteralDouble());
    }
} finally {
    reopenedPresentation.dispose();
}
```

Тип источника значения точки отделён от [ChartData.getDataSourceType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getdatasourcetype/), который указывает внутреннюю или внешнюю конфигурацию книги диаграммы. Использование числовых литералов само по себе не удаляет встроенную книгу. В этом примере книга остаётся доступной для меток категорий, имён серий и остальных серий. См. [Chart Workbook](/slides/ru/nodejs-java/chart-workbook/) для управления книгой.

Для точечных и пузырьковых диаграмм используйте [setDataSourceTypeForXValues](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforxvalues/) и [setDataSourceTypeForYValues](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforyvalues/) для выбора источников [getXValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getxvalue/) и [getYValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getyvalue/). Для пузырьковых диаграмм также используется [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforbubblesizes/) для [getBubbleSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getbubblesize/). Установите каждый применимый источник в `DoubleLiterals` перед назначением чисел через метод `setAsLiteralDouble` соответствующего значения.

## **Установка перекрытия серий диаграммы**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getoverlap/) сообщает, насколько бары или столбцы перекрываются в 2D‑диаграмме, от -100 % до 100 %. Это только чтение проекции настройки в родительской группе серий. Используйте [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setoverlap/) для обновления всех совместимых серий в этой группе. Параметр применяется к типам диаграмм, отображающим сгруппированные бары или столбцы; он не влияет на несвязанные группы серий в составной диаграмме.

Следующий пример задаёт перекрытие для группы, содержащей первую серию:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const overlapPercent = java.newByte(30);

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    // Новая диаграмма содержит примерные серии, категории и значения.
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![The series overlap](series_overlap.png)

## **Изменение цвета заполнения серии**

Используйте [ChartSeries.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getformat/) для задания заполнения по умолчанию всей серии. Если у точки уже задано явное заполнение, её настройка [ChartDataPoint.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getformat/) переопределяет заполнение серии для этой точки.

Следующий пример применяет сплошное синее заполнение к первой серии:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const solidFillType = java.newByte(aspose.slides.FillType.Solid);
const blueColor = java.getStaticFieldValue("java.awt.Color", "BLUE");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getFormat().getFill().setFillType(solidFillType);
    series.getFormat().getFill().getSolidFillColor().setColor(blueColor);

    presentation.save("series_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![The color of the series](series_color.png)

## **Изменение имени серии**

Имя серии хранится в книге данных диаграммы и обычно отображается в легенде. В книге по умолчанию для сгруппированной столбчатой диаграммы ячейка B1 находится в строке 0, столбце 1 и содержит имя первой серии. Именованные константы в следующем примере делают эту структуру явной:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const worksheetIndex = 0;
const seriesNameRowIndex = 0;
const firstSeriesColumnIndex = 1;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const workbook = chart.getChartData().getChartDataWorkbook();
    const seriesNameCell = workbook.getCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Вы также можете обновить ячейку, уже используемую в [ChartSeries.getName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getname/). Этот подход избавляет от предположений о конкретной строке и столбце в существующей диаграмме:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const firstNameCellIndex = 0;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    const seriesNameCell = series.getName().getAsCells().get_Item(firstNameCellIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![The series name](series_name.png)

### **Создание серии с именем из нескольких ячеек**

Составное имя серии полезно, когда название продукта и период отчёта хранятся в разных ячейках книги. Например, можно объединить `Product A` из B1 и `2026` из C1 в одно имя серии, при этом оба элемента остаются связанными со своими исходными ячейками.

Используйте [ChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/getcellcollection/) для получения диапазона имён, затем передайте эту коллекцию в [ChartSeriesCollection.add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriescollection/add/). Параметр `skipHiddenCells` управляет включением скрытых ячеек: `true` — исключает, `false` — включает. В примере используется `false`, чтобы включить каждую ячейку диапазона имён.

Следующий пример создаёт презентацию с одной серией и двумя точками данных. Ячейки B1:C1 содержат только имя серии; A2:A3 — метки категорий, а B2:B3 — числовые значения.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 620, 180);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    chart.setLegend(true);

    const workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    // Эти две ячейки задают имя серии.
    workbook.getCell(0, 0, 1, "Product A");
    workbook.getCell(0, 0, 2, "2026");
    const nameCells = workbook.getCellCollection("Sheet1!$B$1:$C$1", false);
    const series = chart.getChartData().getSeries().add(nameCells, aspose.slides.ChartType.ClusteredColumn);

    // Отдельные ячейки задают категории и числовые точки данных.
    const northCategory = workbook.getCell(0, 1, 0, "North");
    const southCategory = workbook.getCell(0, 2, 0, "South");
    chart.getChartData().getCategories().add(northCategory);
    chart.getChartData().getCategories().add(southCategory);
    const northValue = workbook.getCell(0, 1, 1, 120);
    const southValue = workbook.getCell(0, 2, 1, 150);
    series.getDataPoints().addDataPointForBarSeries(northValue);
    series.getDataPoints().addDataPointForBarSeries(southValue);

    presentation.save("composite_series_name.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Полученное имя серии — `Product A 2026`, между двумя значениями ячеек пробел. Легенда отображает его как одну запись для обоих столбцов. Ниже изображён результат:

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **Получение автоматического цвета заполнения серии**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getautomaticseriescolor/) возвращает цвет, рассчитанный на основе индекса серии и стиля диаграммы. Это цвет, используемый, когда заполнение серии не определено явно. Вызов метода только считывает рассчитанный цвет; он не задаёт новое заполнение.

Следующий пример выводит автоматический цвет каждой серии по умолчанию:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const seriesCount = chart.getChartData().getSeries().size();
    for (let seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++) {
        const series = chart.getChartData().getSeries().get_Item(seriesIndex);
        const automaticColor = series.getAutomaticSeriesColor();
        const automaticColorText = automaticColor.toString();
        console.log("Series " + seriesIndex + ": " + automaticColorText);
    }
} finally {
    presentation.dispose();
}
```

Пример вывода для стиля диаграммы по умолчанию:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

Точные цвета зависят от стиля и темы диаграммы.

## **Установка инверсного цвета заполнения для серии диаграммы**

Для серий типа бар, столбец и пузырёк [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/setinvertifnegative/) позволяет отображать отрицательные значения другим заполнением. Задайте обычное заполнение серии сплошным, включите инверсию и задайте цвет отрицательного значения через [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getinvertedsolidfillcolor/). Отрицательные числа остаются без изменений в книге; меняется только их отображаемый цвет.

Следующий пример заменяет данные диаграммы одной серией. Строка 0 листа содержит имя серии, столбец 0 — имена категорий, столбец 1 — значения:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const worksheetIndex = 0;
const headerRowIndex = 0;
const categoryColumnIndex = 0;
const firstSeriesColumnIndex = 1;
const firstDataRowIndex = 1;
const solidFillType = java.newByte(aspose.slides.FillType.Solid);
const redColor = java.getStaticFieldValue("java.awt.Color", "RED");

const categoryNames = ["Category 1", "Category 2", "Category 3"];
const seriesValues = [-20, 50, -30];

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);
    const chartData = chart.getChartData();
    const workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    const seriesNameCell = workbook.getCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, "Series 1");
    const chartType = chart.getType();
    const series = chartData.getSeries().add(seriesNameCell, chartType);

    for (let categoryIndex = 0; categoryIndex < categoryNames.length; categoryIndex++) {
        const dataRowIndex = firstDataRowIndex + categoryIndex;
        const categoryName = categoryNames[categoryIndex];
        const seriesValue = seriesValues[categoryIndex];

        const categoryCell = workbook.getCell(worksheetIndex, dataRowIndex, categoryColumnIndex, categoryName);
        chartData.getCategories().add(categoryCell);

        const valueCell = workbook.getCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, seriesValue);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    const automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(solidFillType);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.setInvertIfNegative(true);
    series.getInvertedSolidFillColor().setColor(redColor);

    presentation.save("inverted_solid_fill_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![The inverted solid fill color](inverted_solid_fill_color.png)

Вы можете включить инверсию для отдельной точки через [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/setinvertifnegative/). В следующем примере инверсия отключена для серии и включена только для выбранной точки. Точке также присвоено отрицательное значение, чтобы эффект был виден:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const targetDataPointIndex = 2;
const negativeValue = -30;
const solidFillType = java.newByte(aspose.slides.FillType.Solid);
const redColor = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    const automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(solidFillType);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.getInvertedSolidFillColor().setColor(redColor);
    series.setInvertIfNegative(false);

    const dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(negativeValue);
    dataPoint.setInvertIfNegative(true);

    presentation.save("data_point_invert_color_if_negative.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Очистка конкретного значения точки данных**

Чтобы сделать одну точку пустой, не удаляя остальные, задайте её ячейке книги значение `null`. Для столбчатой диаграммы построенное значение доступно через [ChartDataPoint.getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getvalue/). Точка остаётся на том же месте категории, но диаграмма рассматривает её значение как пустое в соответствии с настройками пустых значений.

Следующий пример очищает только вторую точку первой серии:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const targetDataPointIndex = 1;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    const dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(null);

    presentation.save("clear_data_point_value.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Точечные диаграммы используют отдельные ячейки X и Y, а пузырьковые — ещё и ячейку размера. Очищайте только ту ячейку, которая представляет значение, которое нужно удалить. Не вызывайте [ChartDataPointCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/clear/) если хотите оставить остальные точки, поскольку этот метод удаляет все точки из коллекции.

## **Управление отображением пустых ячеек**

Скрытые ячейки с данными — отдельный случай от пустых ячеек. Чтобы включать или исключать данные из скрытых строк и столбцов листа, см. [Include Data from Hidden Rows and Columns](/slides/ru/nodejs-java/chart-workbook/#include-data-from-hidden-rows-and-columns).

Пустая ячейка книги представляет отсутствующие данные; ячейка, содержащая `0`, — известное числовое значение. Вызовите [ChartDataCell.setValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/setvalue/) с `null`, чтобы сделать ячейку пустой. Числовой ноль остаётся нулем независимо от настройки пустой ячейки.

Используйте [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setdisplayblanksas/) для выбора способа отображения пустых ячеек в диаграмме. Этот параметр применяется ко всей диаграмме. Он изменяет способ построения пустот, не заполняя пустую ячейку нулём или интерполированным значением.

Следующий автономный пример создаёт линейную диаграмму с одной серией, очищает значение для Day 3 и сохраняет одну и ту же диаграмму в каждом режиме. Входной файл не требуется. [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/) использует лист 0, столбец 0 — метки категорий, столбец 1 — значения; строка 0 — имя серии. Итоговые данные: `10, 20, empty, 30, 40`.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 40, 40, 640, 400);
    const chartData = chart.getChartData();
    const workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    const seriesNameCell = workbook.getCell(0, 0, 1, "Measurements");
    const series = chartData.getSeries().add(seriesNameCell, chart.getType());
    const values = [10, 20, 25, 30, 40];

    for (let i = 0; i < values.length; i++) {
        const categoryCell = workbook.getCell(0, i + 1, 0, "Day " + (i + 1));
        chartData.getCategories().add(categoryCell);
        const valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // Оставить день 3 действительно пустым, при этом сохранив его категорию и точку данных.
    workbook.getCell(0, 3, 1).setValue(null);

    const modes = [aspose.slides.DisplayBlanksAsType.Gap, aspose.slides.DisplayBlanksAsType.Zero, aspose.slides.DisplayBlanksAsType.Span];
    const modeNames = ["Gap", "Zero", "Span"];
    for (let i = 0; i < modes.length; i++) {
        chart.setDisplayBlanksAs(modes[i]);
        presentation.save("empty_cells_" + modeNames[i] + ".pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Каждый выходной файл сохраняет режим, выбранный перед сохранением: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` и `empty_cells_Span.pptx`. Чтобы сохранить только одну версию, задайте нужный режим и сохраните презентацию один раз вместо итераций по режимам.

Сравнение ниже показывает одинаковые данные во всех трёх файлах. Day 3 пустой в книге в любом случае:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Видимый эффект зависит от типа диаграммы. Линейная диаграмма позволяет легко сравнить все три режима. Для бар- и столбчатых диаграмм нет линии, соединяющей пропущенную категорию, поэтому `Span` не может создать соединительный сегмент, показанный выше; отсутствующий столбец и столбец нулевой высоты также могут выглядеть одинаково. Аналогично, точечная диаграмма только с маркерами не имеет соединительной линии. Не ожидайте трех разных результатов для каждого типа диаграммы; проверьте вывод для используемого типа.

## **Установка ширины зазора между сериями**

Ширина зазора — пространство между соседними кластерами баров или столбцов, выраженное в процентах от их ширины. Как и перекрытие, она относится к родительской группе серий, а не к отдельной серии. Вызовите [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/) один раз для группы. Большее значение создаёт больше пространства между кластерами; меньшее — делает их плотнее.

Следующий пример меняет ширину зазора и сохраняет только финальную презентацию:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const gapWidthPercent = 30;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setGapWidth(gapWidthPercent);

    presentation.save("gap_width_30.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![The gap width](gap_width.png)

## **FAQ**

**Какие типы диаграмм поддерживают серии данных?**

Все типы диаграмм, представленные перечислением [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/), используют данные диаграммы, но их серии не всегда имеют одинаковую структуру значений или параметры. Например, диаграммы категорий используют категории и значения, точечные — X и Y, а пузырьковые — добавляют размеры пузырей. Используйте метод создания точек данных, соответствующий типу серии. Параметры, такие как перекрытие и ширина зазора, применимы только к совместимым группам баров или столбцов.

**Что такое группа серии диаграммы?**

[ChartSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/) содержит совместимые серии, использующие общие параметры построения на уровне группы. Составная диаграмма может иметь более одной группы, поэтому изменение группы через одну серию не обязательно изменит каждую серию в диаграмме.

**Создаётся ли в новой диаграмме набор данных по умолчанию?**

Да. По умолчанию [ShapeCollection.addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/) создаёт образцы серий, категорий и значений. Вы можете изменить эти ячейки или очистить как серии, так и коллекции категорий перед добавлением полностью пользовательского набора данных. Есть перегрузка, позволяющая создать диаграмму без данных по умолчанию.

**Как объекты диаграммы связаны с ячейками книги?**

Имена серий, метки категорий и значения точек данных ссылаются на ячейки в [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/). Изменение ссылки ячейки обновляет соответствующий элемент диаграммы. При построении пользовательских данных держите строки категорий и строки значений серий согласованными, чтобы каждая точка отображалась под нужной категорией.

**Как очистить одну точку, а не всю серию?**

Установите соответствующую ячейку значения в `null`, чтобы точка оставалась на месте категории как пустая. Используйте [ChartDataPointCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/clear/) только тогда, когда хотите удалить все точки из серии. Если вы также удаляете категории, обновите каждую серию, чтобы их значения оставались выровненными с коллекцией категорий.

**Как отображаются пустые точки?**

Результат зависит от типа диаграммы и значения, установленного через [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setdisplayblanksas/). Поддерживаемые диаграммы могут отображать пустоты как разрывы, как нулевые значения или соединяя соседние точки. Выберите параметр, соответствующий смыслу отсутствующих данных в вашей презентации. См. [Control the Display of Empty Cells](#control-the-display-of-empty-cells) для полного примера и визуального сравнения.

**Как форматируются отрицательные значения?**

Для поддерживаемых серий баров, столбцов и пузырей вызовите [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/setinvertifnegative/) и задайте цвет, возвращаемый [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getinvertedsolidfillcolor/). Для отдельной точки можете переопределить поведение через [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/setinvertifnegative/). Эти методы влияют на форматирование, а не на хранимые числовые значения.

**Какой формат имеет приоритет, когда форматированы и серия, и точка?**

Явное форматирование точки данных имеет приоритет для этой точки. Другие точки продолжают использовать явный формат серии или, если формат серии не определён, автоматический стиль и тему диаграммы. Параметры группы, такие как перекрытие и ширина зазора, управляют расположением и не переопределяют точечное форматирование.

**Есть ли ограничение на количество серий в диаграмме?**

Aspose.Slides не накладывает отдельного фиксированного ограничения на количество серий. На практике ограничения задают размер файла презентации, доступная память, время рендеринга и читаемость диаграммы.

**Что менять, если столбцы слишком близко или слишком далеко друг от друга?**

Вызовите [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/) для соответствующей родительской группы серий. Увеличьте значение, чтобы расширить пространство между кластерами, или уменьшите, чтобы сблизить их.