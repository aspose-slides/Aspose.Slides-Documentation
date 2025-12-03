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
- параметры построения
- цвет сектора
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Узнайте, как создавать и настраивать круговые диаграммы в Java с помощью Aspose.Slides, экспортировать их в PowerPoint и быстро улучшать представление данных."
---

## **Вторичные параметры построения для диаграмм «Круг внутри круга» и «Столбец внутри круга»**
Aspose.Slides для Java теперь поддерживает вторичные параметры построения для диаграмм «Круг внутри круга» и «Столбец внутри круга». В этой статье мы покажем, как задать эти параметры с помощью Aspose.Slides. Чтобы задать свойства, выполните следующее:

1. Создайте объект класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Добавьте диаграмму на слайд.
1. Укажите вторичные параметры построения диаграммы.
1. Запишите презентацию на диск.

В приведённом ниже примере мы задали различные свойства диаграммы «Круг внутри круга».
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
Aspose.Slides для Java предоставляет простой API для установки автоматических цветов секторов круговой диаграммы. Пример кода демонстрирует настройку указанных выше свойств.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Получите доступ к первому слайду.
1. Добавьте диаграмму с данными по умолчанию.
1. Установите заголовок диаграммы.
1. Установите для первого ряда отображение значений.
1. Установите индекс листа данных диаграммы.
1. Получите лист данных диаграммы.
1. Удалите автоматически созданные ряды и категории.
1. Добавьте новые категории.
1. Добавьте новые ряды.

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

    // Установить отображение значений для первого ряда
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    // Установка индекса листа данных диаграммы
    int defaultWorksheetIndex = 0;

    // Получение листа данных диаграммы
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // Удалить автоматически сгенерированные ряды и категории
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // Добавление новых категорий
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));

    // Добавление нового ряда
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());

    // Заполнение данных ряда
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

**Поддерживаются ли варианты «Круг внутри круга» и «Столбец внутри круга»?**

Да, библиотека [поддерживает](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) вторичный график для круговых диаграмм, включая типы «Круг внутри круга» и «Столбец внутри круга».

**Можно ли экспортировать только диаграмму как изображение (например, PNG)?**

Да, вы можете [экспортировать саму диаграмму как изображение](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage-int-float-float-) (например, PNG) без всей презентации.