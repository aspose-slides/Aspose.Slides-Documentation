---
title: Настройка полос ошибок в диаграммах презентаций с использованием Java
linktitle: Полоса ошибок
type: docs
url: /ru/java/error-bar/
keywords:
- полоса ошибок
- пользовательское значение
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Узнайте, как добавить и настроить полосы ошибок в диаграммах с Aspose.Slides для Java — оптимизируйте визуализацию данных в презентациях PowerPoint."
---

## **Добавить полосы ошибок**
Aspose.Slides for Java предоставляет простой API для управления значениями полос ошибок. Пример кода применяется при использовании пользовательского типа значений. Чтобы указать значение, используйте свойство **ErrorBarCustomValues** конкретной точки данных в коллекции [**DataPoints**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartSeriesCollection) серии:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Добавьте пузырчатую диаграмму на нужный слайд.
1. Получите первую серию диаграммы и задайте формат полосы ошибок по оси X.
1. Получите первую серию диаграммы и задайте формат полосы ошибок по оси Y.
1. Установите значения и формат полос.
1. Запишите изменённую презентацию в файл PPTX.
```java
// Создать экземпляр класса Presentation
Presentation pres = new Presentation();
try {
    // Создание пузырчатой диаграммы
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Добавление полос ошибок и установка их формата
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


## **Добавить пользовательские значения полос ошибок**
Aspose.Slides for Java предоставляет простой API для управления пользовательскими значениями полос ошибок. Пример кода применяется, когда свойство [**IErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/java/com.aspose.slides/IErrorBarsFormat#getValue--) равно **Custom**. Чтобы указать значение, используйте свойство **ErrorBarCustomValues** конкретной точки данных в коллекции [**DataPoints**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartSeriesCollection) серии:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Добавьте пузырчатую диаграмму на нужный слайд.
1. Получите первую серию диаграммы и задайте формат полосы ошибок по оси X.
1. Получите первую серию диаграммы и задайте формат полосы ошибок по оси Y.
1. Получите отдельные точки данных серии диаграммы и задайте значения полос ошибок для каждой точки.
1. Установите значения и формат полос.
1. Запишите изменённую презентацию в файл PPTX.
```java
    // Создать экземпляр класса Presentation
    Presentation pres = new Presentation();
    try {
        // Создание пузырчатой диаграммы
        IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

        // Добавление пользовательских полос ошибок и установка их формата
        IChartSeries series = chart.getChartData().getSeries().get_Item(0);
        IErrorBarsFormat errBarX = series.getErrorBarsXFormat();
        IErrorBarsFormat errBarY = series.getErrorBarsYFormat();
        errBarX.isVisible();
        errBarY.isVisible();
        errBarX.setValueType((byte) ErrorBarValueType.Custom);
        errBarY.setValueType((byte) ErrorBarValueType.Custom);

        // Доступ к точке данных серии диаграммы и установка значений полос ошибок для
        // отдельной точки
        IChartDataPointCollection points = series.getDataPoints();
        points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXPlusValues((byte) DataSourceType.DoubleLiterals);
        points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXMinusValues((byte) DataSourceType.DoubleLiterals);
        points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYPlusValues((byte) DataSourceType.DoubleLiterals);
        points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYMinusValues((byte) DataSourceType.DoubleLiterals);

        // Установка полос ошибок для точек серии диаграммы
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


## **FAQ**

**Что происходит с полосами ошибок при экспорте презентации в PDF или изображения?**

Они отображаются как часть диаграммы и сохраняются при конвертации вместе с остальным форматированием диаграммы, при условии совместимой версии или рендерера.

**Можно ли комбинировать полосы ошибок с маркерами и метками данных?**

Да. Полосы ошибок являются отдельным элементом и совместимы с маркерами и метками данных; если элементы перекрываются, может потребоваться корректировка форматирования.

**Где можно найти список свойств и классов для работы с полосами ошибок в API?**

В справочнике API: класс [ErrorBarsFormat](https://reference.aspose.com/slides/java/com.aspose.slides/errorbarsformat/) и связанные классы [ErrorBarType](https://reference.aspose.com/slides/java/com.aspose.slides/errorbartype/) и [ErrorBarValueType](https://reference.aspose.com/slides/java/com.aspose.slides/errorbarvaluetype/).