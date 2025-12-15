---
title: Настройка круговых диаграмм в презентациях на Android
linktitle: Круговая диаграмма
type: docs
url: /ru/androidjava/pie-chart/
keywords:
- круговая диаграмма
- управление диаграммой
- настройка диаграммы
- параметры диаграммы
- настройки диаграммы
- параметры построения
- цвет среза
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Узнайте, как создавать и настраивать круговые диаграммы в Java с помощью Aspose.Slides для Android, экспортировать их в PowerPoint, ускоряя рассказ о данных за секунды."
---

## **Параметры вторичного построения для диаграмм «Круг в круге» и «Полоса в круге»**
Aspose.Slides for Android via Java теперь поддерживает параметры вторичного построения для диаграмм «Круг в круге» или «Полоса в круге». В этой статье мы покажем, как указать эти параметры с помощью Aspose.Slides. Чтобы задать свойства, выполните следующее:

1. Создайте объект класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Добавьте диаграмму на слайд.
3. Укажите параметры вторичного построения диаграммы.
4. Запишите презентацию на диск.

В приведённом ниже примере мы задали различные свойства диаграммы «Круг в круге».
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
Aspose.Slides for Android via Java предоставляет простой API для установки автоматических цветов секторов круговой диаграммы. Пример кода применяет указанные выше параметры.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Получите первый слайд.
3. Добавьте диаграмму с данными по умолчанию.
4. Установите заголовок диаграммы.
5. Установите для первого ряда отображение значений.
6. Установите индекс листа данных диаграммы.
7. Получите лист данных диаграммы.
8. Удалите сгенерированные по умолчанию ряды и категории.
9. Добавьте новые категории.
10. Добавьте новый ряд.

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

    // Удалить автоматически созданные ряды и категории
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

**Поддерживаются ли варианты «Круг в круге» и «Полоса в круге»?**

Да, библиотека [поддерживает](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) вторичное построение для круговых диаграмм, включая типы «Круг в круге» и «Полоса в круге».

**Могу ли я экспортировать только диаграмму как изображение (например, PNG)?**

Да, вы можете [экспортировать саму диаграмму как изображение](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) (например, PNG) без полной презентации.