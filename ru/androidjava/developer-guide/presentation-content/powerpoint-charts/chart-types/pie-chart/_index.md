---
title: Настройка круговых диаграмм в презентациях на Android
linktitle: Круговая диаграмма
type: docs
url: /ru/androidjava/pie-chart/
keywords:
- круговая диаграмма
- управление диаграммой
- настройка диаграммы
- опции диаграммы
- настройки диаграммы
- параметры построения
- цвет секторов
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Создавайте и настраивайте круговые диаграммы на Android с помощью Aspose.Slides for Android via Java. Настраивайте вторичные графики, отображайте метки данных и применяйте автоматические цвета секторов в PowerPoint."
---
## **Обзор**

Эта статья объясняет, как работать с круговыми диаграммами в Aspose.Slides. Показано, как настроить параметры вторичного графика для диаграмм "Круг в круге" и "Бар в круге", а также как включить автоматическую раскраску секторов для обычной круговой диаграммы.

В примерах сосредоточено внимание на задачах настройки диаграммы, таких как добавление диаграммы на слайд, настройка параметров серии и меток, замена данных диаграммы по умолчанию на пользовательские категории и значения, а также сохранение обновлённой презентации.

## **Параметры вторичного графика для диаграмм "Круг в круге" и "Бар в круге"**

Aspose.Slides for Android via Java поддерживает параметры вторичного графика для диаграмм "Круг в круге" и "Бар в круге". Эти параметры управляют размером вторичного графика и тем, как точки данных распределяются между двумя графиками.

В следующем примере создаётся диаграмма "Круг в круге" в новой презентации и отображаются значения точек данных в виде меток. Метод [setSecondPieSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setSecondPieSize-int-) устанавливает размер вторичного графика в 149% от основного графика. [setPieSplitBy](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setPieSplitBy-int-) выбирает разбиение по процентам, а [setPieSplitPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setPieSplitPosition-double-) задаёт порог в 53%.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    // Отобразить значения и настроить вторичный график.
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

Используйте пользовательское разбиение, когда нужно сгруппировать определённые категории во вторичном графике независимо от их процентных значений. Например, в отчёте о продажах можно показать Online и Events вместе, чтобы читатели могли сравнить эти два канала, хотя они составляют 35% и 10% от общих продаж.

Вызовите [setPieSplitBy](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setPieSplitBy-int-) с параметром [PieSplitType.Custom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/piesplittype/#Custom) и выберите точки через [getPieSplitCustomPoints](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#getPieSplitCustomPoints--). Метод коллекции [add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/piesplitcustompointcollection/#add-int-) принимает нулевой индекс в серии; используйте [addItem](https://reference.aspose.com/slides/androidjava/com.aspose.slides/piesplitcustompointcollection/#addItem-com.aspose.slides.IChartDataPoint-) для добавления объекта точки данных. В этом примере индекс 1 выбирает Online, а точка с индексом 3 выбирает Events. Partners также временно добавляется, затем исключается с помощью [removeItem](https://reference.aspose.com/slides/androidjava/com.aspose.slides/piesplitcustompointcollection/#removeItem-com.aspose.slides.IChartDataPoint-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 600, 200);

    // Заменить данные по умолчанию данными о продажах по каналам.
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

    // Выбрать Online по нулевому индексу и Events по объекту точки данных.
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

Online (35) и Events (10) отображаются как отдельные сектора во вторичном графике. В основном графике они представлены одним объединённым сектором со значением 45, наряду с Retail (40) и Partners (15). Удаление Partners из пользовательского выбора оставляет его в основном графике; это не удаляет категорию и её значение из исходных данных диаграммы.

Следующее изображение показывает сохранённую презентацию в PowerPoint:

![Диаграмма "Круг в круге" с Online и Events во вторичном графике и их объединённым значением 45 в основном графике](pie_of_pie_custom.png)

## **Установка автоматических цветов секторов круговой диаграммы**

Aspose.Slides for Android via Java может автоматически назначать разные цвета секторам круговой диаграммы. В следующем примере создаётся круговая диаграмма с заголовком по центру и заменяются данные по умолчанию на три квартальных категории и их значения. Метод [setShowValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) отображает значения 20, 50 и 30 в виде меток, а [setColorVaried](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setColorVaried-boolean-) включает различный цвет для каждого сектора.

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

    // Заменить данные по умолчанию, используя первый лист рабочей книги.
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

    // Отобразить значения и назначить разные цвета секторам.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getParentSeriesGroup().setColorVaried(true);

    presentation.save("pie.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Поддерживаются ли варианты "Круг в круге" и "Бар в круге"?**

Да, библиотека [поддерживает](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) вторичный график для круговых диаграмм, включая типы Pie of Pie и Bar of Pie.

**Можно ли экспортировать только диаграмму как изображение (например, PNG)?**

Да, вы можете [экспортировать саму диаграмму как изображение](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage--) (например, PNG) без экспорта всей презентации.