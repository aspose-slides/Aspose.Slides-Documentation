---
title: Настройка полос ошибок в диаграммах презентаций с помощью Java
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
description: "Узнайте, как добавлять и настраивать полосы ошибок в диаграммах с помощью Aspose.Slides для Java — оптимизируйте визуализацию данных в презентациях PowerPoint."
---

## **Добавить полосу ошибок**
Aspose.Slides for Java предоставляет простой API для управления значениями полос ошибок. Пример кода применяется при использовании пользовательского типа значения. Чтобы задать значение, используйте свойство **ErrorBarCustomValues** конкретной точки данных в коллекции [**DataPoints**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartSeriesCollection) серии:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Добавьте пузырчатую диаграмму на нужный слайд.
1. Получите первую серию диаграммы и задайте формат полосы ошибок X.
1. Получите первую серию диаграммы и задайте формат полосы ошибок Y.
1. Задайте значения полос и их формат.
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


## **Добавить пользовательское значение полосы ошибок**
Aspose.Slides for Java предоставляет простой API для управления пользовательскими значениями полос ошибок. Пример кода применяется, когда свойство [**IErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/java/com.aspose.slides/IErrorBarsFormat#getValue--) равно **Custom**. Чтобы задать значение, используйте свойство **ErrorBarCustomValues** конкретной точки данных в коллекции [**DataPoints**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartSeriesCollection) серии:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Добавьте пузырчатую диаграмму на нужный слайд.
1. Получите первую серию диаграммы и задайте формат полосы ошибок X.
1. Получите первую серию диаграммы и задайте формат полосы ошибок Y.
1. Получите отдельные точки данных серии диаграммы и задайте значения полосы ошибок для каждой точки.
1. Задайте значения полос и их формат.
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

    // Получение точки данных серии диаграммы и установка значений полос ошибок для
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


## **Часто задаваемые вопросы**

**Что происходит с полосами ошибок при экспорте презентации в PDF или изображения?**

Они рендерятся как часть диаграммы и сохраняются при конвертации вместе с остальным форматированием диаграммы, при условии совместимой версии или движка.

**Можно ли комбинировать полосы ошибок с маркерами и подписью данных?**

Да. Полосы ошибок являются отдельным элементом и совместимы с маркерами и подписью данных; если элементы перекрываются, возможно потребуется скорректировать форматирование.

**Где можно найти список свойств и классов для работы с полосами ошибок в API?**

В справочнике API: класс [ErrorBarsFormat](https://reference.aspose.com/slides/java/com.aspose.slides/errorbarsformat/) и связанные классы [ErrorBarType](https://reference.aspose.com/slides/java/com.aspose.slides/errorbartype/) и [ErrorBarValueType](https://reference.aspose.com/slides/java/com.aspose.slides/errorbarvaluetype/).