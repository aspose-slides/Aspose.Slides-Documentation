---
title: Линия тренда
type: docs
url: /ru/net/trend-line/
keywords: "Линия тренда, пользовательская линия презентации PowerPoint, C#, Csharp, Aspose.Slides для .NET"
description: "Добавьте линию тренда и пользовательскую линию в презентации PowerPoint на C# или .NET"
---

## **Добавить линию тренда**
Aspose.Slides для .NET предоставляет простой API для управления различными линиями тренда графиков:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Получите ссылку на слайд по его индексу.
1. Добавьте график с данными по умолчанию и любым желаемым типом (в этом примере используется ChartType.ClusteredColumn).
1. Добавление экспоненциальной линии тренда для серии графика 1.
1. Добавление линейной линии тренда для серии графика 1.
1. Добавление логарифмической линии тренда для серии графика 2.
1. Добавление линии тренда скользящего среднего для серии графика 2.
1. Добавление полиномиальной линии тренда для серии графика 3.
1. Добавление степенной линии тренда для серии графика 3.
1. Запишите измененную презентацию в файл PPTX.

Следующий код используется для создания графика с линиями тренда.

```c#
// Создание пустой презентации
Presentation pres = new Presentation();

// Создание графика с группированными столбцами
IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 400);

// Добавление экспоненциальной линии тренда для серии графика 1
ITrendline tredLinep = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Exponential);
tredLinep.DisplayEquation = false;
tredLinep.DisplayRSquaredValue = false;

// Добавление линейной линии тренда для серии графика 1
ITrendline tredLineLin = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Linear);
tredLineLin.TrendlineType = TrendlineType.Linear;
tredLineLin.Format.Line.FillFormat.FillType = FillType.Solid;
tredLineLin.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;


// Добавление логарифмической линии тренда для серии графика 2
ITrendline tredLineLog = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.Logarithmic);
tredLineLog.TrendlineType = TrendlineType.Logarithmic;
tredLineLog.AddTextFrameForOverriding("Новая логарифмическая линия тренда");

// Добавление линии тренда скользящего среднего для серии графика 2
ITrendline tredLineMovAvg = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.MovingAverage);
tredLineMovAvg.TrendlineType = TrendlineType.MovingAverage;
tredLineMovAvg.Period = 3;
tredLineMovAvg.TrendlineName = "Новое имя линии тренда";

// Добавление полиномиальной линии тренда для серии графика 3
ITrendline tredLinePol = chart.ChartData.Series[2].TrendLines.Add(TrendlineType.Polynomial);
tredLinePol.TrendlineType = TrendlineType.Polynomial;
tredLinePol.Forward = 1;
tredLinePol.Order = 3;

// Добавление степенной линии тренда для серии графика 3
ITrendline tredLinePower = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.Power);
tredLinePower.TrendlineType = TrendlineType.Power;
tredLinePower.Backward = 1;

// Сохранение презентации
pres.Save("ChartTrendLines_out.pptx", SaveFormat.Pptx);
```



## **Добавить пользовательскую линию**
Aspose.Slides для .NET предоставляет простой API для добавления пользовательских линий в график. Чтобы добавить простую линию на выбранный слайд презентации, выполните следующие шаги:

- Создайте экземпляр класса Presentation
- Получите ссылку на слайд, используя его индекс
- Создайте новый график, используя метод AddChart, предоставленный объектом Shapes
- Добавьте автопередвижку типа линии, используя метод AddAutoShape, предоставленный объектом Shapes
- Установите цвет линий формы.
- Запишите измененную презентацию в файл PPTX

Следующий код используется для создания графика с пользовательскими линиями.

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    IAutoShape shape = chart.UserShapes.Shapes.AddAutoShape(ShapeType.Line, 0, chart.Height / 2, chart.Width, 0);
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;
    pres.Save("AddCustomLines.pptx", SaveFormat.Pptx);
}
```