---
title: Ошибочная Полоса
type: docs
url: /androidjava/error-bar/
---

## **Добавить Ошибочную Полосу**
Aspose.Slides для Android через Java предоставляет простой API для управления значениями ошибочных полос. Пример кода применяется при использовании пользовательского типа значений. Чтобы указать значение, используйте свойство **ErrorBarCustomValues** конкретной точки данных в коллекции [**DataPoints**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeriesCollection) серий:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Добавьте пузырьковую диаграмму на нужный слайд.
1. Получите доступ к первой серии диаграммы и установите формат ошибочной полосы по оси X.
1. Получите доступ к первой серии диаграммы и установите формат ошибочной полосы по оси Y.
1. Установите значения и формат полос.
1. Запишите измененную презентацию в файл PPTX.

```java
// Создание экземпляра класса Presentation
Presentation pres = new Presentation();
try {
    // Создание пузырьковой диаграммы
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Добавление ошибочных полос и установка их формата
    IErrorBarsFormat errBarX = chart.getChartData().getSeries().get_Item(0).getErrorBarsXFormat();
    IErrorBarsFormat errBarY = chart.getChartData().getSeries().get_Item(0).getErrorBarsYFormat();

    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType((byte) ErrorBarValueType.Fixed);
    errBarX.setValue(0.1f);
    errBarY.setValueType((byte) ErrorBarValueType.Percentage);
    errBarY.setValue(5);
    errBarX.setType((byte) ErrorBarType.Plus);
    errBarY.getFormat().getLine().setWidth(2.0f);
    errBarX.hasEndCap();

    // Сохранение презентации
    pres.save("ErrorBars.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Добавить Пользовательское Значение Ошибочной Полосы**
Aspose.Slides для Android через Java предоставляет простой API для управления пользовательскими значениями ошибочных полос. Пример кода применяется, когда свойство [**IErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IErrorBarsFormat#getValue--) равно **Custom**. Чтобы указать значение, используйте свойство **ErrorBarCustomValues** конкретной точки данных в коллекции [**DataPoints**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeriesCollection) серий:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Добавьте пузырьковую диаграмму на нужный слайд.
1. Получите доступ к первой серии диаграммы и установите формат ошибочной полосы по оси X.
1. Получите доступ к первой серии диаграммы и установите формат ошибочной полосы по оси Y.
1. Получите доступ к индивидуальным точкам данных серии и установите значения ошибочной полосы для индивидуальной точки данных серии.
1. Установите значения и формат полос.
1. Запишите измененную презентацию в файл PPTX.

```java
// Создание экземпляра класса Presentation
Presentation pres = new Presentation();
try {
    // Создание пузырьковой диаграммы
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Добавление пользовательских ошибочных полос и установка их формата
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IErrorBarsFormat errBarX = series.getErrorBarsXFormat();
    IErrorBarsFormat errBarY = series.getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType((byte) ErrorBarValueType.Custom);
    errBarY.setValueType((byte) ErrorBarValueType.Custom);

    // Доступ к точкам данных серии диаграммы и установка значений ошибочных полос для
    // индивидуальной точки
    IChartDataPointCollection points = series.getDataPoints();
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXMinusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYMinusValues((byte) DataSourceType.DoubleLiterals);

    // Установка значений ошибочных полос для точек серии диаграммы
    for (int i = 0; i < points.size(); i++) {
        points.get_Item(i).getErrorBarsCustomValues().getXMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getXPlus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYPlus().setAsLiteralDouble(i + 1);
    }

    // Сохранение презентации
    pres.save("ErrorBarsCustomValues.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```