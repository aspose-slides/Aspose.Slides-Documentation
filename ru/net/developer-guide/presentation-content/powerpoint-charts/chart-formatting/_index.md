---
title: Форматирование диаграмм презентации в .NET
linktitle: Форматирование диаграмм
type: docs
weight: 60
url: /ru/net/chart-formatting/
keywords:
- формат диаграммы
- форматирование диаграмм
- элемент диаграммы
- свойства диаграммы
- настройки диаграммы
- параметры диаграммы
- свойства шрифта
- скруглённая граница
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Узнайте о форматировании диаграмм в Aspose.Slides для .NET и улучшите свою презентацию PowerPoint с профессиональным, привлекающим внимание оформлением."
---

## **Форматирование элементов диаграммы**
Aspose.Slides for .NET позволяет разработчикам добавлять пользовательские диаграммы на слайды с нуля. В этой статье объясняется, как форматировать различные элементы диаграммы, включая оси категорий и значений.

Aspose.Slides for .NET предоставляет простой API для управления различными элементами диаграммы и их форматирования с помощью пользовательских значений:

1. Создайте экземпляр класса **Presentation**.
1. Получите ссылку на слайд по его индексу.
1. Добавьте диаграмму с данными по умолчанию и выбранным типом (в этом примере будем использовать ChartType.LineWithMarkers).
1. Получите доступ к оси значений диаграммы и задайте следующие свойства:
   1. Установка **Line format** для основных линий сетки оси значений
   1. Установка **Line format** для вспомогательных линий сетки оси значений
   1. Установка **Number Format** для оси значений
   1. Установка **Min, Max, Major and Minor units** для оси значений
   1. Установка **Text Properties** для данных оси значений
   1. Установка **Title** для оси значений
   1. Установка **Line Format** для оси значений
1. Получите доступ к оси категорий диаграммы и задайте следующие свойства:
   1. Установка **Line format** для основных линий сетки оси категорий
   1. Установка **Line format** для вспомогательных линий сетки оси категорий
   1. Установка **Text Properties** для данных оси категорий
   1. Установка **Title** для оси категорий
   1. Установка **Label Positioning** для оси категорий
   1. Установка **Rotation Angle** для подписей оси категорий
1. Получите доступ к легенде диаграммы и задайте **Text Properties** для нее
1. Настройте отображение легенд диаграммы без наложения на диаграмму
1. Получите доступ к **Secondary Value Axis** диаграммы и задайте следующие свойства:
   1. Включите вторичную **Value Axis**
   1. Установка **Line Format** для вторичной оси значений
   1. Установка **Number Format** для вторичной оси значений
   1. Установка **Min, Max, Major and Minor units** для вторичной оси значений
1. Теперь построьте первый ряд диаграммы на вторичной оси значений
1. Установите цвет заливки задней стены диаграммы
1. Установите цвет заливки области построения диаграммы
1. Сохраните изменённую презентацию в файл PPTX
```c#
// Создание презентации// Создание презентации
Presentation pres = new Presentation();

// Accessing the first slide
// Получение первого слайда
ISlide slide = pres.Slides[0];

// Adding the sample chart
// Добавление образцовой диаграммы
IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

// Setting Chart Titile
// Установка заголовка диаграммы
chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("");
IPortion chartTitle = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0];
chartTitle.Text = "Sample Chart";
chartTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
chartTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
chartTitle.PortionFormat.FontHeight = 20;
chartTitle.PortionFormat.FontBold = NullableBool.True;
chartTitle.PortionFormat.FontItalic = NullableBool.True;

// Setting Major grid lines format for value axis
// Установка формата основных линий сетки для оси значений
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Blue;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.Width = 5;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.DashStyle = LineDashStyle.DashDot;

// Setting Minor grid lines format for value axis
// Установка формата вспомогательных линий сетки для оси значений
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Red;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.Width = 3;

// Setting value axis number format
// Установка числового формата оси значений
chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Thousands;
chart.Axes.VerticalAxis.NumberFormat = "0.0%";

// Setting chart maximum, minimum values
// Установка максимальных и минимальных значений диаграммы
chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;

chart.Axes.VerticalAxis.MaxValue = 15f;
chart.Axes.VerticalAxis.MinValue = -2f;
chart.Axes.VerticalAxis.MinorUnit = 0.5f;
chart.Axes.VerticalAxis.MajorUnit = 2.0f;

// Setting Value Axis Text Properties
// Установка свойств текста оси значений
IChartPortionFormat txtVal = chart.Axes.VerticalAxis.TextFormat.PortionFormat;
txtVal.FontBold = NullableBool.True;
txtVal.FontHeight = 16;
txtVal.FontItalic = NullableBool.True;
txtVal.FillFormat.FillType = FillType.Solid; ;
txtVal.FillFormat.SolidFillColor.Color = Color.DarkGreen;
txtVal.LatinFont = new FontData("Times New Roman");

// Setting value axis title
// Установка заголовка оси значений
chart.Axes.VerticalAxis.HasTitle = true;
chart.Axes.VerticalAxis.Title.AddTextFrameForOverriding("");
IPortion valtitle = chart.Axes.VerticalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
valtitle.Text = "Primary Axis";
valtitle.PortionFormat.FillFormat.FillType = FillType.Solid;
valtitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
valtitle.PortionFormat.FontHeight = 20;
valtitle.PortionFormat.FontBold = NullableBool.True;
valtitle.PortionFormat.FontItalic = NullableBool.True;

// Setting value axis line format : Now Obselete
// Установка формата линии оси значений: теперь устарело
// chart.Axes.VerticalAxis.aVerticalAxis.l.AxisLine.Width = 10;
// chart.Axes.VerticalAxis.AxisLine.FillFormat.FillType = FillType.Solid;
// Chart.Axes.VerticalAxis.AxisLine.FillFormat.SolidFillColor.Color = Color.Red;

// Setting Major grid lines format for Category axis
// Установка формата основных линий сетки для оси категорий
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Green;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.Width = 5;

// Setting Minor grid lines format for Category axis
// Установка формата вспомогательных линий сетки для оси категорий
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Yellow;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.Width = 3;

// Setting Category Axis Text Properties
// Установка свойств текста оси категорий
IChartPortionFormat txtCat = chart.Axes.HorizontalAxis.TextFormat.PortionFormat;
txtCat.FontBold = NullableBool.True;
txtCat.FontHeight = 16;
txtCat.FontItalic = NullableBool.True;
txtCat.FillFormat.FillType = FillType.Solid; ;
txtCat.FillFormat.SolidFillColor.Color = Color.Blue;
txtCat.LatinFont = new FontData("Arial");

// Setting Category Titile
// Установка заголовка категории
chart.Axes.HorizontalAxis.HasTitle = true;
chart.Axes.HorizontalAxis.Title.AddTextFrameForOverriding("");

IPortion catTitle = chart.Axes.HorizontalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
catTitle.Text = "Sample Category";
catTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
catTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
catTitle.PortionFormat.FontHeight = 20;
catTitle.PortionFormat.FontBold = NullableBool.True;
catTitle.PortionFormat.FontItalic = NullableBool.True;

// Setting category axis lable position
// Установка позиции подписи оси категорий
chart.Axes.HorizontalAxis.TickLabelPosition = TickLabelPositionType.Low;

// Setting category axis lable rotation angle
// Установка угла поворота подписи оси категорий
chart.Axes.HorizontalAxis.TickLabelRotationAngle = 45;

// Setting Legends Text Properties
// Установка свойств текста легенды
IChartPortionFormat txtleg = chart.Legend.TextFormat.PortionFormat;
txtleg.FontBold = NullableBool.True;
txtleg.FontHeight = 16;
txtleg.FontItalic = NullableBool.True;
txtleg.FillFormat.FillType = FillType.Solid; ;
txtleg.FillFormat.SolidFillColor.Color = Color.DarkRed;

// Set show chart legends without overlapping chart
// Установить отображение легенд диаграммы без наложения на диаграмму

chart.Legend.Overlay = true;
            
// Ploting first series on secondary value axis
// Построение первого ряда на вторичной оси значений
// Chart.ChartData.Series[0].PlotOnSecondAxis = true;

// Setting chart back wall color
// Установка цвета задней стены диаграммы
chart.BackWall.Thickness = 1;
chart.BackWall.Format.Fill.FillType = FillType.Solid;
chart.BackWall.Format.Fill.SolidFillColor.Color = Color.Orange;

chart.Floor.Format.Fill.FillType = FillType.Solid;
chart.Floor.Format.Fill.SolidFillColor.Color = Color.Red;
// Setting Plot area color
// Установка цвета области построения
chart.PlotArea.Format.Fill.FillType = FillType.Solid;
chart.PlotArea.Format.Fill.SolidFillColor.Color = Color.LightCyan;

// Save Presentation
// Сохранить презентацию
pres.Save("FormattedChart_out.pptx", SaveFormat.Pptx);
```


## **Установка свойств шрифта для диаграммы**
Aspose.Slides for .NET поддерживает настройку свойств шрифта для диаграммы. Пожалуйста, выполните следующие шаги для установки свойств шрифта диаграммы.

- Создайте объект класса Presentation.
- Добавьте диаграмму на слайд.
- Установите высоту шрифта.
- Сохраните изменённую презентацию.

Ниже приведён пример.
```c#
using (Presentation pres = new Presentation())
{               
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    chart.TextFormat.PortionFormat.FontHeight = 20;
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
    pres.Save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
}
```


## **Установка числового формата**
Aspose.Slides for .NET предоставляет простой API для управления форматом данных диаграммы:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Получите ссылку на слайд по его индексу.
1. Добавьте диаграмму с данными по умолчанию и выбранным типом (в этом примере используется **ChartType.ClusteredColumn**).
1. Установите предустановленный числовой формат из возможных предустановленных значений.
1. Пройдитесь по ячейкам данных диаграммы в каждом ряду и задайте числовой формат данных.
1. Сохраните презентацию.
1. Установите пользовательский числовой формат.
1. Пройдитесь по ячейкам данных диаграммы в каждом ряду и задайте другой числовой формат данных.
1. Сохраните презентацию.
```c#
// Создать презентацию// Создать презентацию
Presentation pres = new Presentation();

// Получить первый слайд презентации
ISlide slide = pres.Slides[0];

// Добавление диаграммы кластерных столбцов по умолчанию
IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

// Доступ к коллекции рядов диаграммы
IChartSeriesCollection series = chart.ChartData.Series;

// Установка предустановленного числового формата
// Перебор всех рядов диаграммы
foreach (ChartSeries ser in series)
{
    // Перебор всех ячеек данных в ряду
    foreach (IChartDataPoint cell in ser.DataPoints)
    {
        // Установка числового формата
        cell.Value.AsCell.PresetNumberFormat = 10; //0.00%
    }
}

// Сохранение презентации
pres.Save("PresetNumberFormat_out.pptx", SaveFormat.Pptx);
```


Возможные предустановленные числовые форматы, их индексы и назначение представлены ниже:

|**0**|General|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h :mm:ss|
|**47**|[mm:ss.0](http://mmss.0)|
|**48**|##0.0E+00|
|**49**|@|

## **Установка скруглённых границ области диаграммы**
Aspose.Slides for .NET поддерживает настройку области диаграммы. Свойства **IChart.HasRoundedCorners** и **Chart.HasRoundedCorners** добавлены в Aspose.Slides.

1. Создайте объект класса `Presentation`.
1. Добавьте диаграмму на слайд.
1. Установите тип заливки и цвет заливки диаграммы.
1. Установите значение свойства скруглённых углов в True.
1. Сохраните изменённую презентацию.

Ниже приведён пример.
```c#
using (Presentation presentation = new Presentation())
{
	ISlide slide = presentation.Slides[0];
	IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
	chart.LineFormat.FillFormat.FillType = FillType.Solid;
	chart.LineFormat.Style = LineStyle.Single;
	chart.HasRoundedCorners = true;

	presentation.Save("out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **FAQ**

**Можно ли задать полупрозрачные заливки для столбцов/областей, оставив границу непрозрачной?**

Да. Прозрачность заливки и контур задаются отдельно. Это полезно для улучшения читаемости сетки и данных в плотных визуализациях.

**Как справиться с подписью данных, когда они перекрываются?**

Уменьшите размер шрифта, отключите необязательные компоненты подписи (например, категории), измените смещение/позицию подписи, показывайте подписи только для выбранных точек при необходимости или переключите формат на «значение + легенда».

**Можно ли применять градиентные или шаблонные заливки к рядам?**

Да. Обычно доступны как сплошные, так и градиентные/шаблонные заливки. На практике используйте градиенты экономно и избегайте комбинаций, снижающих контрастность с сеткой и текстом.