---
title: Ошибочная линия
type: документация
url: /net/error-bar/
keywords: "Ошибочная линия, значения ошибочной линии, презентация PowerPoint, C#, Csharp, Aspose.Slides для .NET"
description: "Добавление ошибочной линии в презентации PowerPoint на C# или .NET"
---

## **Добавить ошибочную линию**
Aspose.Slides для .NET предоставляет простой API для управления значениями ошибочной линии. Пример кода применяется при использовании пользовательского типа значения. Чтобы указать значение, используйте свойство **ErrorBarCustomValues** конкретной точки данных в коллекции **DataPoints** серии:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Добавьте диаграмму с пузырьками на нужный слайд.
1. Получите первую серию диаграммы и установите формат ошибочной линии X.
1. Получите первую серию диаграммы и установите формат ошибочной линии Y.
1. Установите значения и формат линий.
1. Запишите измененную презентацию в файл PPTX.

```c#
// Создание пустой презентации
using (Presentation presentation = new Presentation())
{
    // Создание диаграммы с пузырьками
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Добавление ошибочных линий и установка их формата
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

    // Сохранение презентации
    presentation.Save("ErrorBars_out.pptx", SaveFormat.Pptx);
}
```



## **Добавить пользовательское значение ошибочной линии**
Aspose.Slides для .NET предоставляет простой API для управления пользовательскими значениями ошибочной линии. Пример кода применяется, когда свойство **IErrorBarsFormat.ValueType** равно **Custom**. Чтобы указать значение, используйте свойство **ErrorBarCustomValues** конкретной точки данных в коллекции **DataPoints** серии:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Добавьте диаграмму с пузырьками на нужный слайд.
1. Получите первую серию диаграммы и установите формат ошибочной линии X.
1. Получите первую серию диаграммы и установите формат ошибочной линии Y.
1. Получите индивидуальные точки данных серии диаграммы и установите значения ошибочной линии для индивидуальной точки данных серии.
1. Установите значения и формат линий.
1. Запишите измененную презентацию в файл PPTX.

```c#
// Создание пустой презентации
using (Presentation presentation = new Presentation())
{
    // Создание диаграммы с пузырьками
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Добавление пользовательских ошибочных линий и установка их формата
    IChartSeries series = chart.ChartData.Series[0];
    IErrorBarsFormat errBarX = series.ErrorBarsXFormat;
    IErrorBarsFormat errBarY = series.ErrorBarsYFormat;
    errBarX.IsVisible = true;
    errBarY.IsVisible = true;
    errBarX.ValueType = ErrorBarValueType.Custom;
    errBarY.ValueType = ErrorBarValueType.Custom;

    // Получение точки данных серии диаграммы и установка значений ошибочных линий для индивидуальной точки
    IChartDataPointCollection points = series.DataPoints;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXPlusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXMinusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYPlusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYMinusValues = DataSourceType.DoubleLiterals;

    // Установка ошибочных линий для точек серии диаграммы
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