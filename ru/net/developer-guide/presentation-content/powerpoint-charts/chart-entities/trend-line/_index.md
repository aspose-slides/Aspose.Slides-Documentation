---
title: Добавить линии тренда к диаграммам презентации в .NET
linktitle: Линия тренда
type: docs
url: /ru/net/trend-line/
keywords:
- диаграмма
- линия тренда
- экспоненциальная линия тренда
- линейная линия тренда
- логарифмическая линия тренда
- линия тренда скользящего среднего
- полиномиальная линия тренда
- степенная линия тренда
- пользовательская линия тренда
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Быстро добавляйте и настраивайте линии тренда в диаграммах PowerPoint с помощью Aspose.Slides for .NET — практическое руководство по привлечению вашей аудитории."
---

## **Добавить линию тренда**
Aspose.Slides for .NET предоставляет простой API для управления различными линиями тренда диаграмм:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Получите ссылку на слайд по его индексу.
1. Добавьте диаграмму с данными по умолчанию любого требуемого типа (в этом примере используется ChartType.ClusteredColumn).
1. Добавление экспоненциальной линии тренда для серии 1 диаграммы.
1. Добавление линейной линии тренда для серии 1 диаграммы.
1. Добавление логарифмической линии тренда для серии 2 диаграммы.
1. Добавление линии тренда скользящего среднего для серии 2 диаграммы.
1. Добавление полиномиальной линии тренда для серии 3 диаграммы.
1. Добавление степенной линии тренда для серии 3 диаграммы.
1. Запишите изменённую презентацию в файл PPTX.

Следующий код используется для создания диаграммы с линиями тренда.
```c#
// Создание пустой презентации
Presentation pres = new Presentation();

// Создание кластерной столбчатой диаграммы
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

// Добавление линии тренда скользящего среднего для серии 2
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
- Получите ссылку на слайд, используя его индекс
- Создайте новую диаграмму, используя метод AddChart, доступный объекту Shapes
- Добавьте AutoShape типа Line, используя метод AddAutoShape, доступный объекту Shapes
- Установите цвет линий фигуры.
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

Это длина линии тренда, проецируемой вперёд/назад: для точечных (XY) диаграмм — в единицах осей; для недисперсионных диаграмм — в количестве категорий. Допустимы только неотрицательные значения.

**Будет ли линия тренда сохраняться при экспорте презентации в PDF или SVG, или при рендеринге слайда в изображение?**

Да. Aspose.Slides преобразует презентации в [PDF](/slides/ru/net/convert-powerpoint-to-pdf/)/[SVG](/slides/ru/net/render-a-slide-as-an-svg-image/) и рендерит диаграммы в изображения; линии тренда, как часть диаграммы, сохраняются во время этих операций. Также доступен метод для [экспорта изображения диаграммы](/slides/ru/net/create-shape-thumbnails/).