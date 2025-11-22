---
title: Линия тренда
type: docs
url: /ru/net/trend-line/
keywords: "Линия тренда, пользовательская линия PowerPoint презентация, C#, Csharp, Aspose.Slides for .NET"
description: "Добавьте линию тренда и пользовательскую линию в презентации PowerPoint на C# или .NET"
---

## **Добавить линию тренда**
Aspose.Slides for .NET предоставляет простой API для управления различными линиями тренда диаграмм:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Получите ссылку на слайд по его индексу.
3. Добавьте диаграмму с данными по умолчанию и любой желаемый тип (в этом примере используется ChartType.ClusteredColumn).
4. Добавление экспоненциальной линии тренда для серии 1 диаграммы.
5. Добавление линейной линии тренда для серии 1 диаграммы.
6. Добавление логарифмической линии тренда для серии 2 диаграммы.
7. Добавление скользящей средней линии тренда для серии 2 диаграммы.
8. Добавление полиномиальной линии тренда для серии 3 диаграммы.
9. Добавление степенной линии тренда для серии 3 диаграммы.
10. Запишите изменённую презентацию в файл PPTX.

Следующий код используется для создания диаграммы с линиями тренда.
```c#
// Создание пустой презентации
Presentation pres = new Presentation();

// Создание кластеризованной столбчатой диаграммы
IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 400);

// Добавление экспоненциальной линии тренда для серии 1
ITrendline tredLinep = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Exponential);
tredLinep.DisplayEquation = false;
tredLinep.DisplayRSquaredValue = false;

// Добавление линейной линии тренда для серии 1
ITrendline tredLineLin = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Linear);
tredLineLin.TrendlineType = TrendlineType.Linear;
tredLineLin.Format.Line.FillFormat.FillType = FillType.Solid;
tredLineLin.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;


// Добавление логарифмической линии тренда для серии 2
ITrendline tredLineLog = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.Logarithmic);
tredLineLog.TrendlineType = TrendlineType.Logarithmic;
tredLineLog.AddTextFrameForOverriding("New log trend line");

// Добавление линии тренда скользящей средней для серии 2
ITrendline tredLineMovAvg = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.MovingAverage);
tredLineMovAvg.TrendlineType = TrendlineType.MovingAverage;
tredLineMovAvg.Period = 3;
tredLineMovAvg.TrendlineName = "New TrendLine Name";

// Добавление полиномиальной линии тренда для серии 3
ITrendline tredLinePol = chart.ChartData.Series[2].TrendLines.Add(TrendlineType.Polynomial);
tredLinePol.TrendlineType = TrendlineType.Polynomial;
tredLinePol.Forward = 1;
tredLinePol.Order = 3;

// Добавление степенной линии тренда для серии 3
ITrendline tredLinePower = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.Power);
tredLinePower.TrendlineType = TrendlineType.Power;
tredLinePower.Backward = 1;

// Сохранение презентации
pres.Save("ChartTrendLines_out.pptx", SaveFormat.Pptx);
```


## **Добавить пользовательскую линию**
Aspose.Slides for .NET предоставляет простой API для добавления пользовательских линий в диаграмму. Чтобы добавить простую сплошную линию на выбранный слайд презентации, выполните следующие шаги:

- Создайте экземпляр класса Presentation
- Получите ссылку на слайд, используя его Index
- Создайте новую диаграмму, используя метод AddChart, предоставляемый объектом Shapes
- Добавьте AutoShape типа Line, используя метод AddAutoShape, предоставляемый объектом Shapes
- Задайте цвет линий фигуры.
- Запишите изменённую презентацию в файл PPTX

Следующий код используется для создания диаграммы с пользовательскими линиями.
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


## **FAQ**

**Что означают 'forward' и 'backward' для линии тренда?**

Это длина линии тренда, проецируемой вперёд/назад: для точечных (XY) диаграмм — в единицах осей; для нелинейных диаграмм — в количестве категорий. Допустимы только неотрицательные значения.

**Сохранится ли линия тренда при экспорте презентации в PDF или SVG, либо при рендеринге слайда в изображение?**

Да. Aspose.Slides преобразует презентации в [PDF](/slides/ru/net/convert-powerpoint-to-pdf/)/[SVG](/slides/ru/net/render-a-slide-as-an-svg-image/) и рендерит диаграммы в изображения; линии тренда, как часть диаграммы, сохраняются при этих операциях. Также доступен метод для [экспорта изображения диаграммы](/slides/ru/net/create-shape-thumbnails/).