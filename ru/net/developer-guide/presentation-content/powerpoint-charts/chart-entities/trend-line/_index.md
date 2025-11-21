---
title: Добавление линий тренда к диаграммам презентаций в .NET
linktitle: Линия тренда
type: docs
url: /ru/net/trend-line/
keywords:
- диаграмма
- линия тренда
- экспоненциальная линия тренда
- линейная линия тренда
- логарифмическая линия тренда
- линия тренда скользящей средней
- полиномиальная линия тренда
- линия тренда степени
- пользовательская линия тренда
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Быстро добавляйте и настраивайте линии тренда в диаграммах PowerPoint с помощью Aspose.Slides для .NET — практическое руководство для привлечения вашей аудитории."
---

## **Добавить линию тренда**
Aspose.Slides for .NET предоставляет простой API для управления различными линиями тренда в диаграммах:

1. Создать экземпляр класса [Презентация](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Получить ссылку на слайд по его индексу.
1. Добавить диаграмму с данными по умолчанию и желаемым типом (в этом примере используется ChartType.ClusteredColumn).
1. Добавить экспоненциальную линию тренда для серии диаграммы 1.
1. Добавить линейную линию тренда для серии диаграммы 1.
1. Добавить логарифмическую линию тренда для серии диаграммы 2.
1. Добавить скользящую среднюю линию тренда для серии диаграммы 2.
1. Добавить полиномиальную линию тренда для серии диаграммы 3.
1. Добавить степень (power) линию тренда для серии диаграммы 3.
1. Записать изменённую презентацию в файл PPTX.

Следующий код используется для создания диаграммы с линиями тренда.
```c#
// Создание пустой презентации
Presentation pres = new Presentation();

// Создание кластеризованной столбчатой диаграммы
IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 400);

// Добавление экспоненциальной линии тренда для серии диаграммы 1
ITrendline tredLinep = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Exponential);
tredLinep.DisplayEquation = false;
tredLinep.DisplayRSquaredValue = false;

// Добавление линейной линии тренда для серии диаграммы 1
ITrendline tredLineLin = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Linear);
tredLineLin.TrendlineType = TrendlineType.Linear;
tredLineLin.Format.Line.FillFormat.FillType = FillType.Solid;
tredLineLin.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;


// Добавление логарифмической линии тренда для серии диаграммы 2
ITrendline tredLineLog = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.Logarithmic);
tredLineLog.TrendlineType = TrendlineType.Logarithmic;
tredLineLog.AddTextFrameForOverriding("New log trend line");

// Добавление линии тренда скользящей средней для серии диаграммы 2
ITrendline tredLineMovAvg = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.MovingAverage);
tredLineMovAvg.TrendlineType = TrendlineType.MovingAverage;
tredLineMovAvg.Period = 3;
tredLineMovAvg.TrendlineName = "New TrendLine Name";

// Добавление полиномиальной линии тренда для серии диаграммы 3
ITrendline tredLinePol = chart.ChartData.Series[2].TrendLines.Add(TrendlineType.Polynomial);
tredLinePol.TrendlineType = TrendlineType.Polynomial;
tredLinePol.Forward = 1;
tredLinePol.Order = 3;

// Добавление степенной линии тренда для серии диаграммы 3
ITrendline tredLinePower = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.Power);
tredLinePower.TrendlineType = TrendlineType.Power;
tredLinePower.Backward = 1;

// Сохранение презентации
pres.Save("ChartTrendLines_out.pptx", SaveFormat.Pptx);
```




## **Добавить пользовательскую линию**
Aspose.Slides for .NET предоставляет простой API для добавления пользовательских линий в диаграмму. Чтобы добавить простую обычную линию на выбранный слайд презентации, выполните следующие шаги:

- Создать экземпляр класса Presentation
- Получить ссылку на слайд, используя его Index
- Создать новую диаграмму с помощью метода AddChart, предоставленного объектом Shapes
- Добавить AutoShape типа Line с помощью метода AddAutoShape, предоставленного объектом Shapes
- Установить цвет линий фигуры.
- Записать изменённую презентацию в файл PPTX

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

**Что означают «вперёд» и «назад» для линии тренда?**

Это длина линии тренда, проецируемой вперёд/назад: для точечных (XY) диаграмм — в единицах осей; для недиаграмм точек — в количестве категорий. Допускаются только неотрицательные значения.

**Сохранится ли линия тренда при экспорте презентации в PDF или SVG, или при рендеринге слайда в изображение?**

Да. Aspose.Slides конвертирует презентации в [PDF](/slides/ru/net/convert-powerpoint-to-pdf/)/[SVG](/slides/ru/net/render-a-slide-as-an-svg-image/) и рендерит диаграммы в изображения; линии тренда, как часть диаграммы, сохраняются при этих операциях. Также доступен метод для [экспорта изображения диаграммы](/slides/ru/net/create-shape-thumbnails/).