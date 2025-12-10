---
title: Настройка круговых диаграмм в презентациях с использованием Java
linktitle: Круговая диаграмма
type: docs
url: /ru/java/pie-chart/
keywords:
- круговая диаграмма
- управление диаграммой
- кастомизация диаграммы
- параметры диаграммы
- настройки диаграммы
- параметры построения
- цвет сегмента
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Узнайте, как создавать и настраивать круговые диаграммы в Java с помощью Aspose.Slides, экспортировать их в PowerPoint и усиливать повествование данных за секунды."
---

## **Варианты второго построения для диаграмм «Кусок из кусочка» и «Столбец из кусочка»**
Aspose.Slides for Java теперь поддерживает параметры второго построения для диаграмм «Кусок из кусочка» и «Столбец из кусочка». В этой статье мы покажем, как задать эти параметры с помощью Aspose.Slides. Чтобы задать свойства, выполните следующее:

1. Создайте объект класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Добавьте диаграмму на слайд.
3. Укажите параметры второго построения диаграммы.
4. Запишите презентацию на диск.

В приведённом ниже примере мы задали различные свойства диаграммы «Кусок из кусочка».
```java
// Создать экземпляр класса Presentation
Presentation pres = new Presentation();
try {
    // Добавить диаграмму на слайд
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400);
    
    // Установить различные свойства
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setSecondPieSize(149);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitBy(PieSplitType.ByPercentage);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitPosition(53);
    
    // Записать презентацию на диск
    pres.save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Установить автоматические цвета секторов круговой диаграммы**
Aspose.Slides for Java предоставляет простой API для установки автоматических цветов секторов круговой диаграммы. Пример кода демонстрирует применение указанных выше свойств.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Получите первый слайд.
3. Добавьте диаграмму с данными по умолчанию.
4. Задайте заголовок диаграммы.
5. Установите для первой серии отображение значений.
6. Установите индекс листа данных диаграммы.
7. Получите лист данных диаграммы.
8. Удалите серии и категории, созданные по умолчанию.
9. Добавьте новые категории.
10. Добавьте новую серию.

Запишите изменённую презентацию в файл PPTX.
```java
// Создать экземпляр класса Presentation
Presentation pres = new Presentation();
try {
    // Добавить диаграмму с данными по умолчанию
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);

    // Установка заголовка диаграммы
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // Установить отображение значений для первой серии
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    // Установка индекса листа данных диаграммы
    int defaultWorksheetIndex = 0;

    // Получение листа данных диаграммы
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // Удалить автоматически созданные серии и категории
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // Добавление новых категорий
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));

    // Добавление новой серии
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());

    // Заполнение данных серии
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));

    series.getParentSeriesGroup().setColorVaried(true);
    pres.save("Pie.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Поддерживаются варианты 'Кусок из кусочка' и 'Столбец из кусочка'?**

Да, библиотека [поддерживает](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) вторичное построение для круговых диаграмм, включая варианты 'Кусок из кусочка' и 'Столбец из кусочка'.

**Могу ли я экспортировать только диаграмму как изображение (например, PNG)?**

Да, вы можете [экспортировать саму диаграмму как изображение](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage-int-float-float-) (например, PNG) без всей презентации.