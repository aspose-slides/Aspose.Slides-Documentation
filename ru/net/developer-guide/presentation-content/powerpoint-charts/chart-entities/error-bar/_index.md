---
title: Полоса ошибок
type: docs
url: /ru/net/error-bar/
keywords: "Полоса ошибок, значения полос ошибок в презентации PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "Добавить полосу ошибок в презентации PowerPoint на C# или .NET"
---

## **Добавить полосу ошибок**
Aspose.Slides for .NET предоставляет простой API для управления значениями полос ошибок. Пример кода применяется при использовании пользовательского типа значения. Чтобы указать значение, используйте свойство **ErrorBarCustomValues** конкретной точки данных в коллекции **DataPoints** серии:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Добавьте пузырчатую диаграмму на нужный слайд.
1. Получите первую серию диаграммы и задайте формат полосы ошибок X.
1. Получите первую серию диаграммы и задайте формат полосы ошибок Y.
1. Установите значения полос и их формат.
1. Запишите изменённую презентацию в файл PPTX.
```c#
// Creating empty presentation
using (Presentation presentation = new Presentation())
{
    // Creating a bubble chart
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Adding Error bars and setting its format
    IErrorBarsFormat errBarX = chart.ChartData.Series[0].ErrorBarsXFormat;
    IErrorBarsFormat errBarY = chart.ChartData.Series[0].ErrorBarsYFormat;
    errBarX.IsVisible = true;
    errBarY.IsVisible = true;
    errBarX.ValueType = ErrorBarValueType.Fixed;
    errBarX.Value = 0.1f;
    errBarY.ValueType = ErrorBarValueType.Percentage;
    errBarY.Value = 5;
    errBarX.Type = ErrorBarType.Plus;
    errBarY.Format.Line.Width = 2;
    errBarX.HasEndCap = true;

    // Saving presentation
    presentation.Save("ErrorBars_out.pptx", SaveFormat.Pptx);
}
```




## **Добавить пользовательское значение полосы ошибок**
Aspose.Slides for .NET предоставляет простой API для управления пользовательскими значениями полос ошибок. Пример кода применяется, когда свойство **IErrorBarsFormat.ValueType** равно **Custom**. Чтобы указать значение, используйте свойство **ErrorBarCustomValues** конкретной точки данных в коллекции **DataPoints** серии:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Добавьте пузырчатую диаграмму на нужный слайд.
1. Получите первую серию диаграммы и задайте формат полосы ошибок X.
1. Получите первую серию диаграммы и задайте формат полосы ошибок Y.
1. Получите отдельные точки данных серии диаграммы и задайте значения полос ошибки для каждой точки данных.
1. Установите значения полос и их формат.
1. Запишите изменённую презентацию в файл PPTX.
```c#
// Создание пустой презентации
using (Presentation presentation = new Presentation())
{
    // Создание пузырчатой диаграммы
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Добавление пользовательских полос ошибок и установка их формата
    IChartSeries series = chart.ChartData.Series[0];
    IErrorBarsFormat errBarX = series.ErrorBarsXFormat;
    IErrorBarsFormat errBarY = series.ErrorBarsYFormat;
    errBarX.IsVisible = true;
    errBarY.IsVisible = true;
    errBarX.ValueType = ErrorBarValueType.Custom;
    errBarY.ValueType = ErrorBarValueType.Custom;

    // Доступ к точке данных серии диаграммы и установка значений полос ошибок для отдельной точки
    IChartDataPointCollection points = series.DataPoints;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXPlusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXMinusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYPlusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYMinusValues = DataSourceType.DoubleLiterals;

    // Установка полос ошибок для точек серии диаграммы
    for (int i = 0; i < points.Count; i++)
    {
        points[i].ErrorBarsCustomValues.XMinus.AsLiteralDouble = i + 1;
        points[i].ErrorBarsCustomValues.XPlus.AsLiteralDouble = i + 1;
        points[i].ErrorBarsCustomValues.YMinus.AsLiteralDouble = i + 1;
        points[i].ErrorBarsCustomValues.YPlus.AsLiteralDouble = i + 1;
    }

    // Сохранение презентации
    presentation.Save("ErrorBarsCustomValues_out.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Что происходит с полосами ошибок при экспорте презентации в PDF или изображения?**

Они отрисовываются как часть диаграммы и сохраняются при конвертации вместе с остальными настройками диаграммы, при условии совместимой версии или рендерера.

**Можно ли комбинировать полосы ошибок с маркерами и подписью данных?**

Да. Полосы ошибок являются отдельным элементом и совместимы с маркерами и подписью данных; если элементы перекрываются, возможно потребуется скорректировать форматирование.

**Где можно найти список свойств и перечислений для работы с полосами ошибок в API?**

В справочнике API: класс [ErrorBarsFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/errorbarsformat/) и связанные перечисления [ErrorBarType](https://reference.aspose.com/slides/net/aspose.slides.charts/errorbartype/) и [ErrorBarValueType](https://reference.aspose.com/slides/net/aspose.slides.charts/errorbarvaluetype/).