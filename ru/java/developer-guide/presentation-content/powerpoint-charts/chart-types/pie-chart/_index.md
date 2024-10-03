---
title: Круговая диаграмма
type: docs
url: /ru/java/pie-chart/
---

## **Вторые параметры построения для Круговой или Столбчатой диаграммы с круговой вставкой**
Aspose.Slides для Java теперь поддерживает вторые параметры построения для круговой диаграммы с круговой вставкой или столбчатой диаграммы с круговой вставкой. В этой теме мы покажем вам, как указать эти параметры с помощью Aspose.Slides. Чтобы задать свойства, выполните следующие действия:

1. Создайте объект класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Добавьте диаграмму на слайд.
1. Укажите вторые параметры построения диаграммы.
1. Запишите презентацию на диск.

В приведенном ниже примере мы установили различные свойства круговой диаграммы с круговой вставкой.

```java
// Создайте экземпляр класса Presentation
Presentation pres = new Presentation();
try {
    // Добавьте диаграмму на слайд
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400);
    
    // Установите различные свойства
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setSecondPieSize(149);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitBy(PieSplitType.ByPercentage);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitPosition(53);
    
    // Запишите презентацию на диск
    pres.save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Установка цветов сегментов круговой диаграммы автоматически**
Aspose.Slides для Java предоставляет простой API для автоматической установки цветов сегментов круговой диаграммы. Пример кода применяет установку вышеуказанных свойств.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Получите первый слайд.
1. Добавьте диаграмму с данными по умолчанию.
1. Установите заголовок диаграммы.
1. Установите первую серию для отображения значений.
1. Установите индекс таблицы данных диаграммы.
1. Получите рабочий лист данных диаграммы.
1. Удалите автоматически созданные серии и категории.
1. Добавьте новые категории.
1. Добавьте новые серии.

Запишите измененную презентацию в файл PPTX.

```java
// Создайте экземпляр класса Presentation
Presentation pres = new Presentation();
try {
    // Добавьте диаграмму с данными по умолчанию
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);

    // Установка заголовка диаграммы
    chart.getChartTitle().addTextFrameForOverriding("Пример заголовка");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // Установите первую серию для отображения значений
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    // Установка индекса таблицы данных диаграммы
    int defaultWorksheetIndex = 0;

    // Получение рабочего листа данных диаграммы
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // Удаление автоматически созданных серий и категорий
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // Добавление новых категорий
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "1-й квартал"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2-й квартал"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3-й квартал"));

    // Добавление новых серий
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Серия 1"), chart.getType());

    // Теперь заполняем данные серии
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));

    series.getParentSeriesGroup().setColorVaried(true);
    pres.save("Pie.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```