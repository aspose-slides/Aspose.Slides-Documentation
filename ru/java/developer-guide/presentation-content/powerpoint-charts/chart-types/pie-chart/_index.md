---
title: Настройка круговых диаграмм в презентациях с использованием Java
linktitle: Круговая диаграмма
type: docs
url: /ru/java/pie-chart/
keywords:
- круговая диаграмма
- управление диаграммой
- настройка диаграммы
- параметры диаграммы
- настройки диаграммы
- опции построения
- цвет сегмента
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Создавайте и настраивайте круговые диаграммы в Java с помощью Aspose.Slides. Настраивайте вторичные графики, отображайте подписи данных и применяйте автоматическую окраску сегментов в PowerPoint."
---
## **Обзор**

В этой статье объясняется, как работать с круговыми диаграммами в Aspose.Slides. Она показывает, как настроить параметры вторичного графика для диаграмм Pie of Pie и Bar of Pie, а также как включить автоматическую раскраску секторов для стандартной круговой диаграммы.

Примеры сосредоточены на задачах настройки диаграмм, таких как добавление диаграммы на слайд, настройка параметров рядов и подписей, замена стандартных данных диаграммы пользовательскими категориями и значениями, а также сохранение обновлённой презентации.

## **Параметры вторичного графика для диаграмм Pie of Pie и Bar of Pie**

Aspose.Slides for Java поддерживает параметры вторичного графика для диаграмм Pie of Pie и Bar of Pie. Эти параметры управляют размером вторичного графика и тем, как точки данных делятся между двумя графиками.

В следующем примере создаётся диаграмма Pie of Pie в новой презентации и отображаются значения точек данных в виде подписей. Метод [setSecondPieSize](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setSecondPieSize-int-) устанавливает размер вторичного графика равным 149% от основного графика. [setPieSplitBy](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setPieSplitBy-int-) выбирает разбиение по процентам, а [setPieSplitPosition](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setPieSplitPosition-double-) задаёт пороговое значение 53%.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    // Отображать значения и настраивать вторичный график.
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

### **Выбор категорий для вторичного графика**

Используйте пользовательское разбиение, когда необходимо сгруппировать определённые категории во вторичном графике независимо от их процентных значений. Например, в отчёте о продажах можно отобразить Online и Events вместе, чтобы читатели могли сравнить эти два канала, хотя они составляют 35% и 10% от общего объёма продаж.

Вызовите [setPieSplitBy](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setPieSplitBy-int-) с параметром [PieSplitType.Custom](https://reference.aspose.com/slides/java/com.aspose.slides/piesplittype/#Custom) и выберите точки через [getPieSplitCustomPoints](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#getPieSplitCustomPoints--). Метод [add](https://reference.aspose.com/slides/java/com.aspose.slides/piesplitcustompointcollection/#add-int-) коллекции принимает нулевой индекс в ряду; используйте [addItem](https://reference.aspose.com/slides/java/com.aspose.slides/piesplitcustompointcollection/#addItem-com.aspose.slides.IChartDataPoint-) для добавления объекта точки данных. В этом примере индекс 1 выбирает Online, а точка с индексом 3 выбирает Events. Partners также временно добавляется, а затем исключается с помощью [removeItem](https://reference.aspose.com/slides/java/com.aspose.slides/piesplitcustompointcollection/#removeItem-com.aspose.slides.IChartDataPoint-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 600, 200);

    // Заменить стандартные данные продажами по каналам.
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

    // Выбрать Online по его нулевому индексу и Events по объекту точки данных.
    seriesGroup.getPieSplitCustomPoints().add(1);
    seriesGroup.getPieSplitCustomPoints().addItem(series.getDataPoints().get_Item(3));

    // Исключить Partners из выбора без удаления его исходных данных.
    seriesGroup.getPieSplitCustomPoints().add(2);
    seriesGroup.getPieSplitCustomPoints().removeItem(series.getDataPoints().get_Item(2));

    presentation.save("pie_of_pie_custom.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Online (35) и Events (10) отображаются как отдельные сектора во вторичном графике. В основном графике они представлены одним объединённым сектором со значением 45, вместе с Retail (40) и Partners (15). Удаление Partners из пользовательского выбора сохраняет его в основном графике; это не удаляет категорию или её значение из исходных данных диаграммы.

На следующем изображении показана сохранённая презентация в PowerPoint:

![Диаграмма Pie of Pie с Online и Events во вторичном графике и их объединённым значением 45 в основном графике](pie_of_pie_custom.png)

## **Установить автоматическую раскраску секторов круговой диаграммы**

Aspose.Slides for Java может автоматически назначать разные цвета секторам круговой диаграммы. В следующем примере создаётся круговая диаграмма с заголовком по центру и заменяются стандартные данные на три квартальных категории и их значения. Метод [setShowValue](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) отображает значения 20, 50 и 30 в виде подписей, а [setColorVaried](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setColorVaried-boolean-) включает отдельный цвет для каждого сектора.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);

    // Добавить центрированный заголовок диаграммы.
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // Заменить стандартные данные, используя первый лист.
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

    // Отображать значения и назначать разные цвета секторам.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getParentSeriesGroup().setColorVaried(true);

    presentation.save("pie.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Вопросы и ответы**

**Поддерживаются ли варианты Pie of Pie и Bar of Pie?**

Да, библиотека [поддерживает](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) вторичный график для круговых диаграмм, включая типы Pie of Pie и Bar of Pie.

**Могу ли я экспортировать только диаграмму как изображение (например, PNG)?**

Да, вы можете [экспортировать саму диаграмму как изображение](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage--) (например, PNG) без экспорта всей презентации.