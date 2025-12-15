---
title: Настройка линий ошибок в диаграммах презентаций на Android
linktitle: Линия ошибок
type: docs
url: /ru/androidjava/error-bar/
keywords:
- линия ошибок
- пользовательское значение
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Узнайте, как добавлять и настраивать линии ошибок в диаграммах с помощью Aspose.Slides для Android через Java — оптимизируйте визуализацию данных в презентациях PowerPoint."
---

## **Добавить линии ошибок**
Aspose.Slides for Android via Java предоставляет простой API для управления значениями линий ошибок. Пример кода применим при использовании пользовательского типа значений. Чтобы задать значение, используйте свойство **ErrorBarCustomValues** конкретной точки данных в коллекции [**DataPoints**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeriesCollection) серии:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Добавьте пузырьковую диаграмму на нужный слайд.
1. Получите первый ряд диаграммы и установите формат линии ошибки X.
1. Получите первый ряд диаграммы и установите формат линии ошибки Y.
1. Установите значения и формат линий.
1. Запишите изменённую презентацию в файл PPTX.
```java
// Создать экземпляр класса Presentation
Presentation pres = new Presentation();
try {
    // Создание пузырьковой диаграммы
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Добавление линий ошибок и установка их формата
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


## **Добавить пользовательские значения линий ошибок**
Aspose.Slides for Android via Java предоставляет простой API для управления пользовательскими значениями линий ошибок. Пример кода применим, когда свойство [**IErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IErrorBarsFormat#getValue--) равно **Custom**. Чтобы задать значение, используйте свойство **ErrorBarCustomValues** конкретной точки данных в коллекции [**DataPoints**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeriesCollection) серии:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Добавьте пузырьковую диаграмму на нужный слайд.
1. Получите первый ряд диаграммы и установите формат линии ошибки X.
1. Получите первый ряд диаграммы и установите формат линии ошибки Y.
1. Получите отдельные точки данных ряда диаграммы и задайте значения линий ошибок для каждой точки.
1. Установите значения и формат линий.
1. Запишите изменённую презентацию в файл PPTX.
```java
// Создать экземпляр класса Presentation
Presentation pres = new Presentation();
try {
    // Создание пузырьковой диаграммы
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Добавление пользовательских линий ошибок и установка их формата
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IErrorBarsFormat errBarX = series.getErrorBarsXFormat();
    IErrorBarsFormat errBarY = series.getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType((byte) ErrorBarValueType.Custom);
    errBarY.setValueType((byte) ErrorBarValueType.Custom);

    // Доступ к точке данных ряда диаграммы и установка значений линий ошибок для
    // отдельной точки
    IChartDataPointCollection points = series.getDataPoints();
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXMinusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYMinusValues((byte) DataSourceType.DoubleLiterals);

    // Установка линий ошибок для точек ряда диаграммы
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

**Что происходит с линиями ошибок при экспорте презентации в PDF или изображения?**

Они отображаются как часть диаграммы и сохраняются при конвертации вместе с остальным форматированием диаграммы, при условии совместимой версии или движка рендеринга.

**Можно ли комбинировать линии ошибок с маркерами и подписью данных?**

Да. Линии ошибок являются отдельным элементом и совместимы с маркерами и подписью данных; если элементы перекрываются, возможно потребуется скорректировать их форматирование.

**Где можно найти список свойств и классов для работы с линиями ошибок в API?**

В справочнике API: класс [ErrorBarsFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/errorbarsformat/) и связанные классы [ErrorBarType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/errorbartype/) и [ErrorBarValueType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/errorbarvaluetype/).