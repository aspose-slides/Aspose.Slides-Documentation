---
title: Форматирование диаграмм презентации в .NET
linktitle: Форматирование диаграмм
type: docs
weight: 60
url: /ru/net/chart-formatting/
keywords:
- формат диаграммы
- форматирование диаграммы
- элемент диаграммы
- свойства диаграммы
- настройки диаграммы
- опции диаграммы
- свойства шрифта
- скруглённая граница
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Узнайте о форматировании диаграмм в Aspose.Slides для .NET и сделайте вашу презентацию PowerPoint профессиональной и привлекающей внимание."
---

## **Форматирование элементов диаграммы**
Aspose.Slides for .NET позволяет разработчикам добавлять пользовательские диаграммы на слайды с нуля. Эта статья объясняет, как форматировать различные элементы диаграммы, включая оси категорий и значений.

Aspose.Slides for .NET предоставляет простой API для управления различными элементами диаграммы и их форматирования с использованием пользовательских значений:

1. Создайте экземпляр класса **Presentation**.
1. Получите ссылку на слайд по его индексу.
1. Добавьте диаграмму с данными по умолчанию любого желаемого типа (в этом примере мы используем ChartType.LineWithMarkers).
1. Получите доступ к оси значений диаграммы и установите следующие свойства:
   1. Установка **Line format** для основных линий сетки оси значений
   1. Установка **Line format** для вспомогательных линий сетки оси значений
   1. Установка **Number Format** для оси значений
   1. Установка **Min, Max, Major and Minor units** для оси значений
   1. Установка **Text Properties** для данных оси значений
   1. Установка **Title** для оси значений
   1. Установка **Line Format** для оси значений
1. Получите доступ к оси категорий диаграммы и установите следующие свойства:
   1. Установка **Line format** для основных линий сетки оси категорий
   1. Установка **Line format** для вспомогательных линий сетки оси категорий
   1. Установка **Text Properties** для данных оси категорий
   1. Установка **Title** для оси категорий
   1. Установка **Label Positioning** для оси категорий
   1. Установка **Rotation Angle** для подписей оси категорий
1. Получите доступ к легенде диаграммы и установите для неё **Text Properties**
1. Отобразите легенды диаграммы без наложения на диаграмму
1. Получите доступ к **Secondary Value Axis** диаграммы и установите следующие свойства:
   1. Включите вторичную **Value Axis**
   1. Установка **Line Format** для вторичной оси значений
   1. Установка **Number Format** для вторичной оси значений
   1. Установка **Min, Max, Major and Minor units** для вторичной оси значений
1. Теперь построьте первую серию диаграммы на вторичной оси значений
1. Установите цвет заливки задней стенки диаграммы
1. Установите цвет заливки области построения диаграммы
1. Запишите изменённую презентацию в файл PPTX
```c#
// Создание презентации// Создание презентации
Presentation pres = new Presentation();

// Доступ к первому слайду
ISlide slide = pres.Slides[0];

// Добавление примерной диаграммы
IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

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

// Установка формата основных линий сетки для оси значений
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Blue;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.Width = 5;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.DashStyle = LineDashStyle.DashDot;

// Установка формата вспомогательных линий сетки для оси значений
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Red;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.Width = 3;

// Установка числового формата оси значений
chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Thousands;
chart.Axes.VerticalAxis.NumberFormat = "0.0%";

// Установка максимальных и минимальных значений диаграммы
chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;

chart.Axes.VerticalAxis.MaxValue = 15f;
chart.Axes.VerticalAxis.MinValue = -2f;
chart.Axes.VerticalAxis.MinorUnit = 0.5f;
chart.Axes.VerticalAxis.MajorUnit = 2.0f;

// Установка текстовых свойств оси значений
IChartPortionFormat txtVal = chart.Axes.VerticalAxis.TextFormat.PortionFormat;
txtVal.FontBold = NullableBool.True;
txtVal.FontHeight = 16;
txtVal.FontItalic = NullableBool.True;
txtVal.FillFormat.FillType = FillType.Solid; ;
txtVal.FillFormat.SolidFillColor.Color = Color.DarkGreen;
txtVal.LatinFont = new FontData("Times New Roman");

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

// Установка формата линии оси значений : теперь устарело
// chart.Axes.VerticalAxis.aVerticalAxis.l.AxisLine.Width = 10;
// chart.Axes.VerticalAxis.AxisLine.FillFormat.FillType = FillType.Solid;
// Chart.Axes.VerticalAxis.AxisLine.FillFormat.SolidFillColor.Color = Color.Red;

// Установка формата основных линий сетки для оси категорий
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Green;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.Width = 5;

// Установка формата вспомогательных линий сетки для оси категорий
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Yellow;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.Width = 3;

// Установка текстовых свойств оси категорий
IChartPortionFormat txtCat = chart.Axes.HorizontalAxis.TextFormat.PortionFormat;
txtCat.FontBold = NullableBool.True;
txtCat.FontHeight = 16;
txtCat.FontItalic = NullableBool.True;
txtCat.FillFormat.FillType = FillType.Solid; ;
txtCat.FillFormat.SolidFillColor.Color = Color.Blue;
txtCat.LatinFont = new FontData("Arial");

// Установка заголовка оси категорий
chart.Axes.HorizontalAxis.HasTitle = true;
chart.Axes.HorizontalAxis.Title.AddTextFrameForOverriding("");

IPortion catTitle = chart.Axes.HorizontalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
catTitle.Text = "Sample Category";
catTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
catTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
catTitle.PortionFormat.FontHeight = 20;
catTitle.PortionFormat.FontBold = NullableBool.True;
catTitle.PortionFormat.FontItalic = NullableBool.True;

// Установка позиции подписи оси категорий
chart.Axes.HorizontalAxis.TickLabelPosition = TickLabelPositionType.Low;

// Установка угла поворота подписи оси категорий
chart.Axes.HorizontalAxis.TickLabelRotationAngle = 45;

// Установка текстовых свойств легенд
IChartPortionFormat txtleg = chart.Legend.TextFormat.PortionFormat;
txtleg.FontBold = NullableBool.True;
txtleg.FontHeight = 16;
txtleg.FontItalic = NullableBool.True;
txtleg.FillFormat.FillType = FillType.Solid; ;
txtleg.FillFormat.SolidFillColor.Color = Color.DarkRed;

// Настройка отображения легенд без наложения на диаграмму

chart.Legend.Overlay = true;
            
// Построение первой серии на вторичной оси значений
// Chart.ChartData.Series[0].PlotOnSecondAxis = true;

// Установка цвета задней стенки диаграммы
chart.BackWall.Thickness = 1;
chart.BackWall.Format.Fill.FillType = FillType.Solid;
chart.BackWall.Format.Fill.SolidFillColor.Color = Color.Orange;

chart.Floor.Format.Fill.FillType = FillType.Solid;
chart.Floor.Format.Fill.SolidFillColor.Color = Color.Red;
// Установка цвета области построения
chart.PlotArea.Format.Fill.FillType = FillType.Solid;
chart.PlotArea.Format.Fill.SolidFillColor.Color = Color.LightCyan;

// Сохранение презентации
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


## **Установка формата числовых данных**
Aspose.Slides for .NET предоставляет простой API для управления форматом данных диаграммы:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the any of desired type (this example uses **ChartType.ClusteredColumn**).
1. Set the preset number format from the possible preset values.
1. Traverse through the chart data cell in every chart series and set the chart data number format.
1. Save the presentation.
1. Set the custom number format.
1. Traverse through chart data cell inside every chart series and setting a different chart data number format.
1. Save the presentation.
```c#
// Создать презентацию// Создать презентацию
Presentation pres = new Presentation();

// Получить первый слайд презентации
ISlide slide = pres.Slides[0];

// Добавление кластеризованной столбчатой диаграммы
IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

// Получение коллекции серий диаграммы
IChartSeriesCollection series = chart.ChartData.Series;

// Установка предустановленного числового формата
// Перебор всех серий диаграммы
foreach (ChartSeries ser in series)
{
    // Перебор всех ячеек данных в серии
    foreach (IChartDataPoint cell in ser.DataPoints)
    {
        // Установка числового формата
        cell.Value.AsCell.PresetNumberFormat = 10; //0,00%
    }
}

// Сохранение презентации
pres.Save("PresetNumberFormat_out.pptx", SaveFormat.Pptx);
```


Ниже приведены возможные значения предустановленных числовых форматов вместе с их индексами, которые можно использовать:

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
Aspose.Slides for .NET поддерживает настройку области диаграммы. Свойства **IChart.HasRoundedCorners** и **Chart.HasRoundedCorners** были добавлены в Aspose.Slides.

1. Создайте объект класса `Presentation`.
1. Добавьте диаграмму на слайд.
1. Установите тип заливки и цвет заливки диаграммы
1. Установите свойство скруглённых углов в значение True.
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

**Могу ли я задать полупрозрачные заливки для столбцов/областей, оставив контур непрозрачным?**

Да. Прозрачность заливки и контур настраиваются отдельно. Это полезно для улучшения читаемости сетки и данных в плотных визуализациях.

**Как справиться с наложением подписей данных?**

Уменьшите размер шрифта, отключите несущественные компоненты подписи (например, категории), задайте смещение/позицию подписи, при необходимости показывайте подписи только для выбранных точек или переключите формат на «значение + легенда».

**Могу ли я применить градиентные или шаблонные заливки к сериям?**

Да. Как сплошные, так и градиентные/шаблонные заливки обычно доступны. На практике используйте градиенты умеренно и избегайте комбинаций, снижающих контрастность с сеткой и текстом.