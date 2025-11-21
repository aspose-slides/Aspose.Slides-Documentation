---
title: Полоса ошибок
type: docs
url: /ru/nodejs-java/error-bar/
---

## **Добавить полосу ошибок**

Aspose.Slides for Node.js via Java предоставляет простой API для управления значениями полос ошибок. Пример кода применяется при использовании пользовательского типа значения. Чтобы задать значение, используйте свойство **ErrorBarCustomValues** конкретной точки данных в коллекции [**DataPoints**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartSeriesCollection) серии:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Добавьте пузырчатую диаграмму на нужный слайд.
1. Получите первую серию диаграммы и установите формат X для полосы ошибок.
1. Получите первую серию диаграммы и установите формат Y для полосы ошибок.
1. Установите значения полос и их формат.
1. Запишите изменённую презентацию в файл PPTX.
```javascript
// Создать экземпляр класса Presentation
var pres = new aspose.slides.Presentation();
try {
    // Создание пузырчатой диаграммы
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 400, 300, true);
    // Добавление полос ошибок и установка их формата
    var errBarX = chart.getChartData().getSeries().get_Item(0).getErrorBarsXFormat();
    var errBarY = chart.getChartData().getSeries().get_Item(0).getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType(aspose.slides.ErrorBarValueType.Fixed);
    errBarX.setValue(0.1);
    errBarY.setValueType(aspose.slides.ErrorBarValueType.Percentage);
    errBarY.setValue(5);
    errBarX.setType(aspose.slides.ErrorBarType.Plus);
    errBarY.getFormat().getLine().setWidth(2.0);
    errBarX.hasEndCap();
    // Сохранение презентации
    pres.save("ErrorBars.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Добавить пользовательское значение полосы ошибок**

Aspose.Slides for Node.js via Java предоставляет простой API для управления пользовательскими значениями полос ошибок. Пример кода применяется, когда свойство [**ErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ErrorBarsFormat#getValue--) равно **Custom**. Чтобы задать значение, используйте свойство **ErrorBarCustomValues** конкретной точки данных в коллекции [**DataPoints**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartSeriesCollection) серии:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Добавьте пузырчатую диаграмму на нужный слайд.
1. Получите первую серию диаграммы и установите формат X для полосы ошибок.
1. Получите первую серию диаграммы и установите формат Y для полосы ошибок.
1. Получите отдельные точки данных серии диаграммы и установите значения полос ошибок для каждой точки данных серии.
1. Установите значения полос и их формат.
1. Запишите изменённую презентацию в файл PPTX.
```javascript
// Создать экземпляр класса Presentation
var pres = new aspose.slides.Presentation();
try {
    // Создание пузырчатой диаграммы
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 400, 300, true);
    // Добавление пользовательских полос ошибок и установка их формата
    var series = chart.getChartData().getSeries().get_Item(0);
    var errBarX = series.getErrorBarsXFormat();
    var errBarY = series.getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType(aspose.slides.ErrorBarValueType.Custom);
    errBarY.setValueType(aspose.slides.ErrorBarValueType.Custom);
    // Получение точки данных серии диаграммы и установка значений полос ошибок для
    // отдельной точки
    var points = series.getDataPoints();
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXPlusValues(aspose.slides.DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXMinusValues(aspose.slides.DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYPlusValues(aspose.slides.DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYMinusValues(aspose.slides.DataSourceType.DoubleLiterals);
    // Установка полос ошибок для точек серии диаграммы
    for (var i = 0; i < points.size(); i++) {
        points.get_Item(i).getErrorBarsCustomValues().getXMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getXPlus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYPlus().setAsLiteralDouble(i + 1);
    }
    // Сохранение презентации
    pres.save("ErrorBarsCustomValues.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Что происходит с полосами ошибок при экспорте презентации в PDF или изображения?**

Они отображаются как часть диаграммы и сохраняются при конвертации вместе с остальным форматированием диаграммы, при условии совместимой версии или рендерера.

**Можно ли комбинировать полосы ошибок с маркерами и метками данных?**

Да. Полосы ошибок являются отдельным элементом и совместимы с маркерами и метками данных; если элементы перекрываются, может потребоваться корректировка форматирования.

**Где можно найти список свойств и перечислений для работы с полосами ошибок в API?**

В справочнике API: класс [ErrorBarsFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/errorbarsformat/) и связанные перечисления [ErrorBarType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/errorbartype/) и [ErrorBarValueType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/errorbarvaluetype/).