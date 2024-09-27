---
title: Круговая диаграмма
type: docs
url: /ru/androidjava/pie-chart/
---

## **Вторые параметры построения для круговой диаграммы и диаграммы "круг в круге"**
Aspose.Slides для Android на Java теперь поддерживает вторые параметры построения для диаграммы "круг в круге" или диаграммы "бар в круге". В этой теме мы покажем, как указать эти параметры с помощью Aspose.Slides. Чтобы указать свойства, выполните следующие действия:

1. Создайте объект класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Добавьте диаграмму на слайд.
1. Укажите вторые параметры построения диаграммы.
1. Запишите презентацию на диск.

В приведенном ниже примере мы задали разные свойства для диаграммы "круг в круге".

```java
// Создайте экземпляр класса Presentation
Presentation pres = new Presentation();
try {
    // Добавьте диаграмму на слайд
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400);
    
    // Установка различных свойств
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setSecondPieSize(149);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitBy(PieSplitType.ByPercentage);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitPosition(53);
    
    // Запишите презентацию на диск
    pres.save("ВторыеПараметрыПостроенияДляДиаграмм_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Установка автоматических цветов слайсов круговой диаграммы**
Aspose.Slides для Android на Java предоставляет простой API для установки автоматических цветов слайсов круговой диаграммы. Пример кода применяет установку вышеупомянутых свойств.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Получите первый слайд.
1. Добавьте диаграмму с начальными данными.
1. Установите заголовок диаграммы.
1. Установите первую серию на отображение значений.
1. Установите индекс рабочего листа данных диаграммы.
1. Получите рабочий лист данных диаграммы.
1. Удалите автоматически созданные серии и категории.
1. Добавьте новые категории.
1. Добавьте новые серии.

Запишите измененную презентацию в файл PPTX.

```java
// Создайте экземпляр класса Presentation
Presentation pres = new Presentation();
try {
    // Добавьте диаграмму с начальными данными
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);

    // Установка заголовка диаграммы
    chart.getChartTitle().addTextFrameForOverriding("Пример заголовка");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // Установка первой серии на отображение значений
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    // Установка индекса рабочего листа данных диаграммы
    int defaultWorksheetIndex = 0;

    // Получение рабочего листа данных диаграммы
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // Удалите автоматически созданные серии и категории
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // Добавление новых категорий
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "Первый квартал"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "Второй квартал"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "Третий квартал"));

    // Добавление новых серий
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Серия 1"), chart.getType());

    // Теперь заполняем данные серии
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));

    series.getParentSeriesGroup().setColorVaried(true);
    pres.save("Круговая диаграмма.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```