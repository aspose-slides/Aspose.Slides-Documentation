---
title: Настройка линий ошибок в диаграммах презентаций в .NET
linktitle: Линия ошибок
type: docs
url: /ru/net/error-bar/
keywords:
- линия ошибок
- пользовательское значение
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как добавлять и настраивать линии ошибок в диаграммах с помощью Aspose.Slides для .NET — оптимизируйте визуализацию данных в презентациях PowerPoint."
---

## **Добавить линии ошибок**
Aspose.Slides for .NET предоставляет простой API для управления значениями линий ошибок. Пример кода применяется при использовании пользовательского типа значений. Чтобы указать значение, используйте свойство **ErrorBarCustomValues** конкретной точки данных в коллекции **DataPoints** серии:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Добавьте пузырчатую диаграмму на нужный слайд.
1. Получите первую серию диаграммы и задайте формат линии ошибок по оси X.
1. Получите первую серию диаграммы и задайте формат линии ошибок по оси Y.
1. Установите значения линий и их формат.
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


## **Добавить пользовательские значения линии ошибок**
Aspose.Slides for .NET предоставляет простой API для управления пользовательскими значениями линии ошибок. Пример кода применяется, когда свойство **IErrorBarsFormat.ValueType** равно **Custom**. Чтобы указать значение, используйте свойство **ErrorBarCustomValues** конкретной точки данных в коллекции **DataPoints** серии:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Добавьте пузырчатую диаграмму на нужный слайд.
1. Получите первую серию диаграммы и задайте формат линии ошибок по оси X.
1. Получите первую серию диаграммы и задайте формат линии ошибок по оси Y.
1. Получите отдельные точки данных серии диаграммы и задайте значения линии ошибок для каждой отдельной точки данных серии.
1. Установите значения линий и их формат.
1. Запишите изменённую презентацию в файл PPTX.
```c#
// Создание пустой презентации
using (Presentation presentation = new Presentation())
{
    // Создание пузырчатой диаграммы
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Добавление пользовательских линий ошибок и установка их формата
    IChartSeries series = chart.ChartData.Series[0];
    IErrorBarsFormat errBarX = series.ErrorBarsXFormat;
    IErrorBarsFormat errBarY = series.ErrorBarsYFormat;
    errBarX.IsVisible = true;
    errBarY.IsVisible = true;
    errBarX.ValueType = ErrorBarValueType.Custom;
    errBarY.ValueType = ErrorBarValueType.Custom;

    // Доступ к точке данных серии диаграммы и установка значений линий ошибок для отдельной точки
    IChartDataPointCollection points = series.DataPoints;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXPlusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXMinusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYPlusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYMinusValues = DataSourceType.DoubleLiterals;

    // Установка линий ошибок для точек серии диаграммы
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


## **Часто задаваемые вопросы**

**Что происходит с линиями ошибок при экспорте презентации в PDF или изображения?**

Они отображаются как часть диаграммы и сохраняются при конвертации вместе с остальным форматированием диаграммы, при условии совместимой версии или рендерера.

**Можно ли сочетать линии ошибок с маркерами и подписью данных?**

Да. Линии ошибок являются отдельным элементом и совместимы с маркерами и подписью данных; если элементы перекрываются, возможно потребуется скорректировать форматирование.

**Где я могу найти список свойств и перечислений для работы с линиями ошибок в API?**

В справочнике API: класс [ErrorBarsFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/errorbarsformat/) и связанные перечисления [ErrorBarType](https://reference.aspose.com/slides/net/aspose.slides.charts/errorbartype/) и [ErrorBarValueType](https://reference.aspose.com/slides/net/aspose.slides.charts/errorbarvaluetype/).