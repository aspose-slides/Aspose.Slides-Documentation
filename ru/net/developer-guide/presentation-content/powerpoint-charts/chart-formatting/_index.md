---
title: Форматирование диаграмм
type: docs
weight: 60
url: /net/chart-formatting/
keywords: "Сущности диаграмм, свойства диаграмм, презентация PowerPoint, C#, Csharp, Aspose.Slides для .NET"
description: "Форматируйте сущности диаграмм в презентациях PowerPoint на C# или .NET"
---

## **Форматирование сущностей диаграмм**
Aspose.Slides для .NET позволяет разработчикам добавлять пользовательские диаграммы на свои слайды с нуля. Эта статья объясняет, как форматировать различные сущности диаграмм, включая оси категорий и значений.

Aspose.Slides для .NET предоставляет простой API для управления различными сущностями диаграмм и их форматирования с использованием пользовательских значений:

1. Создайте экземпляр класса **Presentation**.
1. Получите ссылку на слайд по его индексу.
1. Добавьте диаграмму с данными по умолчанию любого желаемого типа (в этом примере мы используем ChartType.LineWithMarkers).
1. Получите доступ к оси значений диаграммы и установите следующие свойства:
   1. Установите **Формат линии** для основных сеток оси значений
   1. Установите **Формат линии** для вспомогательных сеток оси значений
   1. Установите **Формат числа** для оси значений
   1. Установите **Мин., Макс., Основные и Вспомогательные единицы** для оси значений
   1. Установите **Свойства текста** для данных оси значений
   1. Установите **Заголовок** для оси значений
   1. Установите **Формат линии** для оси значений
1. Получите доступ к оси категорий диаграммы и установите следующие свойства:
   1. Установите **Формат линии** для основных сеток оси категорий
   1. Установите **Формат линии** для вспомогательных сеток оси категорий
   1. Установите **Свойства текста** для данных оси категорий
   1. Установите **Заголовок** для оси категорий
   1. Установите **Позиционирование меток** для оси категорий
   1. Установите **Угол поворота** для меток оси категорий
1. Получите доступ к легенде диаграммы и установите **Свойства текста** для нее
1. Настройте отображение легенд диаграммы без наложения на диаграмму
1. Получите доступ к **Вторичной оси значений** диаграммы и установите следующие свойства:
   1. Включите вторичную **Ось значений**
   1. Установите **Формат линии** для вторичной оси значений
   1. Установите **Формат числа** для вторичной оси значений
   1. Установите **Мин., Макс., Основные и Вспомогательные единицы** для вторичной оси значений
1. Теперь постройте первую серию диаграммы на вторичной оси значений
1. Установите цвет заливки задней стенки диаграммы
1. Установите цвет заливки области диаграммы
1. Запишите изменённую презентацию в файл PPTX

```c#
// Создание экземпляра презентации
Presentation pres = new Presentation();

// Получение первого слайда
ISlide slide = pres.Slides[0];

// Добавление образца диаграммы
IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

// Установка заголовка диаграммы
chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("");
IPortion chartTitle = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0];
chartTitle.Text = "Образец диаграммы";
chartTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
chartTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
chartTitle.PortionFormat.FontHeight = 20;
chartTitle.PortionFormat.FontBold = NullableBool.True;
chartTitle.PortionFormat.FontItalic = NullableBool.True;

// Установка формата основных сеток для оси значений
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Blue;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.Width = 5;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.DashStyle = LineDashStyle.DashDot;

// Установка формата вспомогательных сеток для оси значений
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Red;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.Width = 3;

// Установка формата чисел оси значений
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

// Установка свойств текста оси значений
IChartPortionFormat txtVal = chart.Axes.VerticalAxis.TextFormat.PortionFormat;
txtVal.FontBold = NullableBool.True;
txtVal.FontHeight = 16;
txtVal.FontItalic = NullableBool.True;
txtVal.FillFormat.FillType = FillType.Solid;
txtVal.FillFormat.SolidFillColor.Color = Color.DarkGreen;
txtVal.LatinFont = new FontData("Times New Roman");

// Установка заголовка оси значений
chart.Axes.VerticalAxis.HasTitle = true;
chart.Axes.VerticalAxis.Title.AddTextFrameForOverriding("");
IPortion valtitle = chart.Axes.VerticalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
valtitle.Text = "Первичная ось";
valtitle.PortionFormat.FillFormat.FillType = FillType.Solid;
valtitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
valtitle.PortionFormat.FontHeight = 20;
valtitle.PortionFormat.FontBold = NullableBool.True;
valtitle.PortionFormat.FontItalic = NullableBool.True;

// Установка формата основных сеток для оси категорий
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Green;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.Width = 5;

// Установка формата вспомогательных сеток для оси категорий
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Yellow;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.Width = 3;

// Установка свойств текста оси категорий
IChartPortionFormat txtCat = chart.Axes.HorizontalAxis.TextFormat.PortionFormat;
txtCat.FontBold = NullableBool.True;
txtCat.FontHeight = 16;
txtCat.FontItalic = NullableBool.True;
txtCat.FillFormat.FillType = FillType.Solid;
txtCat.FillFormat.SolidFillColor.Color = Color.Blue;
txtCat.LatinFont = new FontData("Arial");

// Установка заголовка оси категорий
chart.Axes.HorizontalAxis.HasTitle = true;
chart.Axes.HorizontalAxis.Title.AddTextFrameForOverriding("");

IPortion catTitle = chart.Axes.HorizontalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
catTitle.Text = "Образец категории";
catTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
catTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
catTitle.PortionFormat.FontHeight = 20;
catTitle.PortionFormat.FontBold = NullableBool.True;
catTitle.PortionFormat.FontItalic = NullableBool.True;

// Установка положения меток оси категорий
chart.Axes.HorizontalAxis.TickLabelPosition = TickLabelPositionType.Low;

// Установка угла поворота меток оси категорий
chart.Axes.HorizontalAxis.TickLabelRotationAngle = 45;

// Установка свойств текста легенды
IChartPortionFormat txtleg = chart.Legend.TextFormat.PortionFormat;
txtleg.FontBold = NullableBool.True;
txtleg.FontHeight = 16;
txtleg.FontItalic = NullableBool.True;
txtleg.FillFormat.FillType = FillType.Solid;
txtleg.FillFormat.SolidFillColor.Color = Color.DarkRed;

// Установка отображения легенд диаграммы без наложения на диаграмму
chart.Legend.Overlay = true;
            
// Построение первой серии на вторичной оси значений

// Установка цвета заливки задней стенки диаграммы
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
Aspose.Slides для .NET поддерживает установку свойств, связанных со шрифтами, для диаграммы. Пожалуйста, следуйте ниже приведённым шагам для установки свойств шрифта для диаграммы.

- Создайте объект класса Presentation.
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




## **Установка формата чисел**
Aspose.Slides для .NET предоставляет простой API для управления форматом данных диаграммы:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Получите ссылку на слайд по его индексу.
1. Добавьте диаграмму с данными по умолчанию любого желаемого типа (в этом примере используется **ChartType.ClusteredColumn**).
1. Установите предустановленный формат числа из возможных предустановленных значений.
1. Пройдите через ячейки данных диаграммы в каждой серии диаграммы и установите формат числа данных диаграммы.
1. Сохраните презентацию.
1. Установите пользовательский формат числа.
1. Пройдите через ячейки данных диаграммы внутри каждой серии диаграммы и установите другой формат числа данных диаграммы.
1. Сохраните презентацию.

```c#
// Создание экземпляра презентации
Presentation pres = new Presentation();

// Получение первого слайда презентации
ISlide slide = pres.Slides[0];

// Добавление диаграммы столбчатой диаграммы
IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

// Получение коллекции серий диаграммы
IChartSeriesCollection series = chart.ChartData.Series;

// Установка предустановленного формата числа
// Пройдите через каждую серию диаграмм
foreach (ChartSeries ser in series)
{
    // Пройдите через каждую ячейку данных в серии
    foreach (IChartDataPoint cell in ser.DataPoints)
    {
        // Установка формата числа
        cell.Value.AsCell.PresetNumberFormat = 10; //0.00%
    }
}

// Сохранение презентации
pres.Save("PresetNumberFormat_out.pptx", SaveFormat.Pptx);
```

Возможные значения предустановленного формата чисел вместе с их предустановленным индексом, которые могут быть использованы, приведены ниже:

|**0**|Общий|
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

## **Установка закруглённых границ области диаграммы**
Aspose.Slides для .NET поддерживает установку области диаграммы. Свойства **IChart.HasRoundedCorners** и **Chart.HasRoundedCorners** были добавлены в Aspose.Slides.

1. Создайте объект класса `Presentation`.
1. Добавьте диаграмму на слайд.
1. Установите тип заливки и цвет заливки диаграммы
1. Установите свойство закруглённых углов в True.
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