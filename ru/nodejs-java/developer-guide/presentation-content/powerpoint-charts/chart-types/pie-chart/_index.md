---
title: Настройка круговых диаграмм в презентациях с использованием JavaScript
linktitle: Круговая диаграмма
type: docs
url: /ru/nodejs-java/pie-chart/
keywords:
- круговая диаграмма
- управление диаграммой
- настройка диаграммы
- параметры диаграммы
- настройки диаграммы
- параметры построения
- цвет секторов
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Создавайте и настраивайте круговые диаграммы в JavaScript с помощью Aspose.Slides для Node.js via Java. Настраивайте вторичные построения, отображайте подписи данных и применяйте автоматическое цветовое оформление секторов в PowerPoint."
---
## **Обзор**

Эта статья объясняет, как работать с круговыми диаграммами в Aspose.Slides. Она показывает, как настроить параметры вторичного построения для диаграмм Pie of Pie и Bar of Pie, а также как включить автоматическое присваивание цветов секторам стандартной круговой диаграммы.

Примеры сосредоточены на задачах настройки диаграмм, таких как добавление диаграммы на слайд, настройка параметров рядов и подписей, замена данных диаграммы по умолчанию на пользовательские категории и значения, а также сохранение обновлённой презентации.

## **Параметры вторичного построения для диаграмм Pie of Pie и Bar of Pie**

Aspose.Slides for Node.js via Java поддерживает параметры вторичного построения для диаграмм Pie of Pie и Bar of Pie. Эти параметры управляют размером вторичного построения и тем, как точки данных распределяются между двумя построениями.

В следующем примере создаётся диаграмма Pie of Pie в новой презентации и отображаются значения точек данных в виде подписей. Метод [setSecondPieSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setSecondPieSize) задаёт размер вторичного построения 149 % от основного. [setPieSplitBy](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setPieSplitBy) выбирает разбиение по процентам, а [setPieSplitPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setPieSplitPosition) устанавливает порог 53 %.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.PieOfPie, 50, 50, 500, 400);
    const series = chart.getChartData().getSeries().get_Item(0);

    // Отображать значения и настроить вторичное построение.
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

### **Выберите категории для вторичного построения**

Используйте пользовательское разбиение, когда необходимо сгруппировать определённые категории во вторичном построении независимо от их процентных значений. Например, в отчёте о продажах могут отображаться Online и Events вместе, чтобы читатели могли сравнить эти два канала, хотя они составляют 35 % и 10 % от общего объёма продаж.

Вызовите [setPieSplitBy](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setPieSplitBy) с параметром [PieSplitType.Custom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/piesplittype/#Custom) и выберите точки через [getPieSplitCustomPoints](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#getPieSplitCustomPoints). Метод коллекции [add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/piesplitcustompointcollection/#add) принимает нулевой индекс в ряду; используйте [addItem](https://reference.aspose.com/slides/nodejs-java/aspose.slides/piesplitcustompointcollection/#addItem) для добавления объекта точки данных. В этом примере индекс 1 выбирает Online, а точка с индексом 3 — Events. Partners также временно добавляется, затем исключается с помощью [removeItem](https://reference.aspose.com/slides/nodejs-java/aspose.slides/piesplitcustompointcollection/#removeItem).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.PieOfPie, 50, 50, 600, 200);

    // Заменить данные по умолчанию продажами по каналам.
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

    // Выбрать Online по его нулевому индексу и Events по объекту точки данных.
    seriesGroup.getPieSplitCustomPoints().add(1);
    seriesGroup.getPieSplitCustomPoints().addItem(series.getDataPoints().get_Item(3));

    // Исключить Partners из выбора без удаления его исходных данных.
    seriesGroup.getPieSplitCustomPoints().add(2);
    seriesGroup.getPieSplitCustomPoints().removeItem(series.getDataPoints().get_Item(2));

    presentation.save("pie_of_pie_custom.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Online (35) и Events (10) отображаются как отдельные сектора во вторичном построении. В основном построении они представлены одним объединённым сектором со значением 45, рядом с Retail (40) и Partners (15). Удаление Partners из пользовательского выбора сохраняет его в основном построении; категория и её значение не удаляются из исходных данных диаграммы.

Следующее изображение показывает сохранённую презентацию в PowerPoint:

![Диаграмма Pie of Pie с Online и Events во вторичном построении и их объединённым значением 45 в основном построении](pie_of_pie_custom.png)

## **Установить автоматическое окрашивание секторов круговой диаграммы**

Aspose.Slides for Node.js via Java может автоматически назначать разные цвета секторам круговой диаграммы. В следующем примере создаётся круговая диаграмма с центрированным заголовком и заменяется набор данных по умолчанию на три квартальных категории и их значения. Метод [setShowValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/#setShowValue) отображает значения 20, 50 и 30 в виде подписей, а [setColorVaried](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setColorVaried) включает различный цвет для каждого сектора.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 100, 100, 400, 400);

    // Добавить центрированный заголовок диаграммы.
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(java.newByte(aspose.slides.NullableBool.True));
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // Заменить данные по умолчанию, используя первый лист.
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

    // Отображать значения и назначать разные цвета секторам.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getParentSeriesGroup().setColorVaried(true);

    presentation.save("pie.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Часто задаваемые вопросы**

**Поддерживаются ли варианты Pie of Pie и Bar of Pie?**

Да, библиотека [поддерживает](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) вторичное построение для круговых диаграмм, включая типы Pie of Pie и Bar of Pie.

**Можно ли экспортировать только диаграмму как изображение (например, PNG)?**

Да, вы можете [экспортировать саму диаграмму как изображение](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage) (например, PNG) без экспорта всей презентации.