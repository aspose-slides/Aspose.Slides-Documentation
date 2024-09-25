```
title: Создание или обновление диаграмм в PowerPoint презентациях на C# или .NET
linktitle: Создать или обновить диаграмму
type: docs
weight: 10
url: /net/create-chart/
keywords: "Создание диаграммы, разбросанная диаграмма, круговая диаграмма, диаграмма деревоподобной карты, фондовая диаграмма, диаграмма с усами, гистограмма, воронкообразная диаграмма, солнечная диаграмма, многокатегорийная диаграмма, PowerPoint презентация, C#, Csharp, Aspose.Slides для .NET"
description: "Создание диаграммы в PowerPoint презентации на C# или .NET"
---

## **Создание диаграммы**
Диаграммы помогают быстро визуализировать данные и получить инсайты, которые могут быть не очевидны сразу из таблицы или электронной таблицы. 

**Почему стоит создавать диаграммы?**

Используя диаграммы, вы можете

* агрегировать, обобщать или резюмировать большие объемы данных на одном слайде презентации
* выявлять шаблоны и тренды в данных
* делать выводы о направлении и динамике данных со временем или относительно конкретной единицы измерения 
* выявлять выбросы, аномалии, отклонения, ошибки, бессмысленные данные и т.д. 
* сообщать или представлять сложные данные

В PowerPoint вы можете создавать диаграммы через функцию вставки, которая предоставляет шаблоны для проектирования различных типов диаграмм. Используя Aspose.Slides, вы можете создавать обычные диаграммы (на основе популярных типов диаграмм) и настраиваемые диаграммы. 

{{% alert color="primary" %}} 

Чтобы позволить вам создавать диаграммы, Aspose.Slides предоставляет перечисление [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) в пространстве имен [Aspose.Slides.Charts](https://reference.aspose.com/slides/net/aspose.slides.charts/). Значения в этом перечислении соответствуют различным типам диаграмм. 

{{% /alert %}} 

### **Создание обычных диаграмм**
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Получите ссылку на слайд по его индексу.
1. Добавьте диаграмму с некоторыми данными и укажите предпочтительный тип диаграммы. 
1. Добавьте заголовок для диаграммы. 
1. Получите доступ к рабочему листу данных диаграммы.
1. Очистите все стандартные серии и категории.
1. Добавьте новые серии и категории.
1. Добавьте новые данные диаграммы для серий диаграммы.
1. Добавьте цвет заливки для серий диаграмм.
1. Добавьте метки для серий диаграмм. 
1. Запишите модифицированную презентацию в файл PPTX.

Этот код C# показывает, как создать обычную диаграмму:

```c#
// Создает экземпляр класса Presentation, который представляет файл PPTX
Presentation pres = new Presentation();

// Получает первый слайд
ISlide sld = pres.Slides[0];

// Добавляет диаграмму с ее стандартными данными
IChart chart = sld.Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 500);

// Устанавливает заголовок диаграммы
chart.ChartTitle.AddTextFrameForOverriding("Пример заголовка");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

// Устанавливает первую серию для отображения значений
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

// Устанавливает индекс для листа данных диаграммы
int defaultWorksheetIndex = 0;

// Получает рабочий лист данных диаграммы
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// Удаляет стандартные сгенерированные серии и категории
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
int s = chart.ChartData.Series.Count;
s = chart.ChartData.Categories.Count;

// Добавляет новые серии
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Серия 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Серия 2"), chart.Type);

// Добавляет новые категории
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Категория 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Категория 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Категория 3"));

// Берет первую серию диаграммы
IChartSeries series = chart.ChartData.Series[0];

// Заполняет данные серий
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

// Устанавливает цвет заливки для серии
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;

// Берет вторую серию диаграммы
series = chart.ChartData.Series[1];

// Заполняет данные серий
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

// Устанавливает цвет заливки для серии
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Green;

// Устанавливает первую метку для отображения имени категории
IDataLabel lbl = series.DataPoints[0].Label;
lbl.DataLabelFormat.ShowCategoryName = true;

lbl = series.DataPoints[1].Label;
lbl.DataLabelFormat.ShowSeriesName = true;

// Устанавливает серию для отображения значения для третьей метки
lbl = series.DataPoints[2].Label;
lbl.DataLabelFormat.ShowValue = true;
lbl.DataLabelFormat.ShowSeriesName = true;
lbl.DataLabelFormat.Separator = "/";
            
// Сохраняет файл PPTX на диск
pres.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
```


### **Создание разбросанных диаграмм**
Разбросанные диаграммы (также известные как диаграммы разброса или x-y графики) часто используются для проверки шаблонов или демонстрации корреляций между двумя переменными. 

Вам может понадобиться использовать разбросанную диаграмму, когда 

* у вас есть парные числовые данные
* у вас есть 2 переменные, которые хорошо связаны
* вы хотите определить, связаны ли 2 переменные
* у вас есть независимая переменная, которая имеет несколько значений для зависимой переменной

Этот код C# показывает, как создать разбросанную диаграмму с различными маркерами: 

```c#
Presentation pres = new Presentation();

ISlide slide = pres.Slides[0];

// Создает стандартную диаграмму
IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);

// Получает индекс рабочего листа данных диаграммы по умолчанию
int defaultWorksheetIndex = 0;

// Получает рабочий лист данных диаграммы
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// Удаляет демонстрационные серии
chart.ChartData.Series.Clear();

// Добавляет новые серии
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Серия 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Серия 2"), chart.Type);

// Берет первую серию диаграммы
IChartSeries series = chart.ChartData.Series[0];

// Добавляет новую точку (1:3) в серию
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 1), fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

// Добавляет новую точку (2:10)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 2), fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

// Изменяет тип серии
series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

// Изменяет маркер серии диаграмм
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Star;

// Берет вторую серию диаграммы
series = chart.ChartData.Series[1];

// Добавляет новую точку (5:2) в серию диаграммы
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 3, 5), fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

// Добавляет новую точку (3:1)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 3, 3), fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

// Добавляет новую точку (2:2)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 4, 3, 2), fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

// Добавляет новую точку (5:1)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 5, 3, 5), fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

// Изменяет маркер серии диаграммы
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Circle;

// Сохраняет файл PPTX на диск
pres.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
```

### **Создание круговых диаграмм**

Круговые диаграммы лучше всего используются для отображения соотношения частей к целому в данных, особенно когда данные содержат категориальные метки с числовыми значениями. Однако, если ваши данные содержат много частей или меток, вам может быть полезно рассмотреть возможность использования столбчатой диаграммы вместо этого. 

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Получите ссылку на слайд по его индексу.
1. Добавьте диаграмму с данными по умолчанию вместе с желаемым типом (в данном случае, `ChartType.Pie`).
1. Получите доступ к данным диаграммы IChartDataWorkbook.
1. Очистите стандартные серии и категории.
1. Добавьте новые серии и категории.
1. Добавьте новые данные для серий диаграммы.
1. Добавьте новые точки для диаграмм и задайте пользовательские цвета для секторов круговой диаграммы.
1. Установите метки для серий.
1. Установите ведущие линии для меток серий.
1. Установите угол поворота для слайдов круговой диаграммы.
1. Запишите модифицированную презентацию в файл PPTX.

Этот код C# показывает, как создать круговую диаграмму:

```c#
// Создает экземпляр класса Presentation, который представляет файл PPTX
Presentation presentation = new Presentation();

// Получает первый слайд
ISlide slides = presentation.Slides[0];

// Добавляет диаграмму с ее стандартными данными
IChart chart = slides.Shapes.AddChart(ChartType.Pie, 100, 100, 400, 400);

// Устанавливает заголовок диаграммы
chart.ChartTitle.AddTextFrameForOverriding("Пример заголовка");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

// Устанавливает первую серию для отображения значений
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

// Устанавливает индекс для листа данных диаграммы
int defaultWorksheetIndex = 0;

// Получает рабочий лист данных диаграммы
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// Удаляет стандартные сгенерированные серии и категории
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

// Добавляет новые категории
chart.ChartData.Categories.Add(fact.GetCell(0, 1, 0, "Первый квартал"));
chart.ChartData.Categories.Add(fact.GetCell(0, 2, 0, "Второй квартал"));
chart.ChartData.Categories.Add(fact.GetCell(0, 3, 0, "Третий квартал"));

// Добавляет новые серии
IChartSeries series = chart.ChartData.Series.Add(fact.GetCell(0, 0, 1, "Серия 1"), chart.Type);

// Заполняет данные серий
series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

// Не работает в новой версии 
// Добавление новых точек и установка цвета сектора
// series.IsColorVaried = true;
chart.ChartData.SeriesGroups[0].IsColorVaried = true;

IChartDataPoint point = series.DataPoints[0];
point.Format.Fill.FillType = FillType.Solid;
point.Format.Fill.SolidFillColor.Color = Color.Cyan;
// Устанавливает границу сектора
point.Format.Line.FillFormat.FillType = FillType.Solid;
point.Format.Line.FillFormat.SolidFillColor.Color = Color.Gray;
point.Format.Line.Width = 3.0;
point.Format.Line.Style = LineStyle.ThinThick;
point.Format.Line.DashStyle = LineDashStyle.DashDot;

IChartDataPoint point1 = series.DataPoints[1];
point1.Format.Fill.FillType = FillType.Solid;
point1.Format.Fill.SolidFillColor.Color = Color.Brown;

// Устанавливает границу сектора
point1.Format.Line.FillFormat.FillType = FillType.Solid;
point1.Format.Line.FillFormat.SolidFillColor.Color = Color.Blue;
point1.Format.Line.Width = 3.0;
point1.Format.Line.Style = LineStyle.Single;
point1.Format.Line.DashStyle = LineDashStyle.LargeDashDot;

IChartDataPoint point2 = series.DataPoints[2];
point2.Format.Fill.FillType = FillType.Solid;
point2.Format.Fill.SolidFillColor.Color = Color.Coral;

// Устанавливает границу сектора
point2.Format.Line.FillFormat.FillType = FillType.Solid;
point2.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;
point2.Format.Line.Width = 2.0;
point2.Format.Line.Style = LineStyle.ThinThin;
point2.Format.Line.DashStyle = LineDashStyle.LargeDashDotDot;

// Создает пользовательские метки для каждой из категорий для новой серии
IDataLabel lbl1 = series.DataPoints[0].Label;

// lbl.ShowCategoryName = true;
lbl1.DataLabelFormat.ShowValue = true;

IDataLabel lbl2 = series.DataPoints[1].Label;
lbl2.DataLabelFormat.ShowValue = true;
lbl2.DataLabelFormat.ShowLegendKey = true;
lbl2.DataLabelFormat.ShowPercentage = true;

IDataLabel lbl3 = series.DataPoints[2].Label;
lbl3.DataLabelFormat.ShowSeriesName = true;
lbl3.DataLabelFormat.ShowPercentage = true;

// Устанавливает серию для отображения ведущих линий для диаграммы
series.Labels.DefaultDataLabelFormat.ShowLeaderLines = true;

// Устанавливает угол поворота для секторов круговой диаграммы
chart.ChartData.SeriesGroups[0].FirstSliceAngle = 180;

// Сохраняет файл PPTX на диск
presentation.Save("PieChart_out.pptx", SaveFormat.Pptx);
```

### **Создание линейных диаграмм**

Линейные диаграммы (также известные как линейные графики) лучше всего использовать в ситуациях, когда вы хотите показать изменения значений со временем. Используя линейную диаграмму, вы можете сравнивать много данных одновременно, отслеживать изменения и тенденции со временем, выделять аномалии в сериалах данных и т.д.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Получите ссылку на слайд через его индекс.
1. Добавьте диаграмму с данными по умолчанию вместе с желаемым типом (в данном случае, `ChartType.Line`).
1. Получите доступ к данным диаграммы, IChartDataWorkbook.
1. Очистите стандартные серии и категории.
1. Добавьте новые серии и категории.
1. Добавьте новые данные диаграммы для серий диаграммы.
1. Запишите модифицированную презентацию в файл PPTX.

Этот код C# показывает, как создать линейную диаграмму:

```c#
using (Presentation pres = new Presentation())
{
    IChart lineChart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 10, 50, 600, 350);
    
    pres.Save("lineChart.pptx", SaveFormat.Pptx);
}
```

По умолчанию точки на линейной диаграмме соединены прямыми непрерывными линиями. Если вы хотите, чтобы точки были соединены тире, вы можете указать предпочитаемый тип тире следующим образом: xxx

```c#
IChart lineChart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 10, 50, 600, 350);

foreach (IChartSeries series in lineChart.ChartData.Series)
{
    series.Format.Line.DashStyle = LineDashStyle.Dash;
}
```

### **Создание диаграмм деревоподобной карты**

Диаграммы деревоподобной карты лучше всего использовать для данных о продажах, когда вы хотите показать относительный размер категорий данных и (в то же время) быстро привлечь внимание к элементам, которые являются крупными вкладчиками в каждую категорию. 

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Получите ссылку на слайд по его индексу.
1. Добавьте диаграмму с данными по умолчанию вместе с желаемым типом (в данном случае, `ChartType.TreeMap`).
1. Получите доступ к данным диаграммы IChartDataWorkbook.
1. Очистите стандартные серии и категории.
1. Добавьте новые серии и категории.
1. Добавьте новые данные диаграммы для серий диаграммы.
1. Запишите модифицированную презентацию в файл PPTX.

Этот код C# показывает, как создать диаграмму деревоподобной карты:

```c#
using (Presentation presentation = new Presentation())
{
	IChart chart = presentation.Slides[0].Shapes.AddChart(Aspose.Slides.Charts.ChartType.Treemap, 50, 50, 500, 400);
	chart.ChartData.Categories.Clear();
	chart.ChartData.Series.Clear();

	IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

	wb.Clear(0);

	// Ветвь 1
	IChartCategory leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C1", "Лист1"));
	leaf.GroupingLevels.SetGroupingItem(1, "Стебель1");
	leaf.GroupingLevels.SetGroupingItem(2, "Ветвь1");

	chart.ChartData.Categories.Add(wb.GetCell(0, "C2", "Лист2"));

	leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C3", "Лист3"));
	leaf.GroupingLevels.SetGroupingItem(1, "Стебель2");

	chart.ChartData.Categories.Add(wb.GetCell(0, "C4", "Лист4"));


	// Ветвь 2
	leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C5", "Лист5"));
	leaf.GroupingLevels.SetGroupingItem(1, "Стебель3");
	leaf.GroupingLevels.SetGroupingItem(2, "Ветвь2");

	chart.ChartData.Categories.Add(wb.GetCell(0, "C6", "Лист6"));

	leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C7", "Лист7"));
	leaf.GroupingLevels.SetGroupingItem(1, "Стебель4");

	chart.ChartData.Categories.Add(wb.GetCell(0, "C8", "Лист8"));

	IChartSeries series = chart.ChartData.Series.Add(Aspose.Slides.Charts.ChartType.Treemap);
	series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
	series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D1", 4));
	series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D2", 5));
	series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D3", 3));
	series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D4", 6));
	series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D5", 9));
	series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D6", 9));
	series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D7", 4));
	series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D8", 3));

	series.ParentLabelLayout = ParentLabelLayoutType.Overlapping;

	presentation.Save("Treemap.pptx", SaveFormat.Pptx);
}
```

### **Создание фондовых диаграмм**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Получите ссылку на слайд по его индексу.
1. Добавьте диаграмму с данными по умолчанию вместе с желаемым типом (ChartType.OpenHighLowClose).
1. Получите доступ к данным диаграммы IChartDataWorkbook.
1. Очистите стандартные серии и категории.
1. Добавьте новые серии и категории.
1. Добавьте новые данные диаграммы для серий.
1. Укажите формат HiLowLines.
1. Запишите модифицированную презентацию в файл PPTX.

Пример кода C#, используемого для создания фондовой диаграммы:

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.OpenHighLowClose, 50, 50, 600, 400, false);
    
	IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

	chart.ChartData.Categories.Add(wb.GetCell(0, 1, 0, "A"));
	chart.ChartData.Categories.Add(wb.GetCell(0, 2, 0, "B"));
	chart.ChartData.Categories.Add(wb.GetCell(0, 3, 0, "C"));

	chart.ChartData.Series.Add(wb.GetCell(0, 0, 1, "Открытие"), chart.Type);
	chart.ChartData.Series.Add(wb.GetCell(0, 0, 2, "Максимум"), chart.Type);
	chart.ChartData.Series.Add(wb.GetCell(0, 0, 3, "Минимум"), chart.Type);
	chart.ChartData.Series.Add(wb.GetCell(0, 0, 4, "Закрытие"), chart.Type);

	IChartSeries series = chart.ChartData.Series[0];

	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 1, 1, 72));
	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 2, 1, 25));
	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 3, 1, 38));

	series = chart.ChartData.Series[1];
	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 1, 2, 172));
	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 2, 2, 57));
	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 3, 2, 57));

	series = chart.ChartData.Series[2];
	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 1, 3, 12));
	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 2, 3, 12));
	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 3, 3, 13));

	series = chart.ChartData.Series[3];
	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 1, 4, 25));
	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 2, 4, 38));
	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 3, 4, 50));

	chart.ChartData.SeriesGroups[0].UpDownBars.HasUpDownBars = true;
	chart.ChartData.SeriesGroups[0].HiLowLinesFormat.Line.FillFormat.FillType = FillType.Solid;

	foreach (IChartSeries ser in chart.ChartData.Series)
	{
		ser.Format.Line.FillFormat.FillType = FillType.NoFill;
	}

	pres.Save("Stock-chart.pptx", SaveFormat.Pptx);
}
```


### **Создание диаграмм с усами**
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Получите ссылку на слайд по его индексу.
1. Добавьте диаграмму с данными по умолчанию вместе с желаемым типом (ChartType.BoxAndWhisker).
1. Получите доступ к данным диаграммы IChartDataWorkbook.
1. Очистите стандартные серии и категории.
1. Добавьте новые серии и категории.
1. Добавьте новые данные диаграммы для серий.
1. Запишите модифицированную презентацию в файл PPTX.

Этот код C# показывает, как создать диаграмму с усами:

```c#
public static void Run()
{
	using (Presentation pres = new Presentation("test.pptx"))
	{
		IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.BoxAndWhisker, 50, 50, 500, 400);
		chart.ChartData.Categories.Clear();
		chart.ChartData.Series.Clear();

		IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

		wb.Clear(0);

		chart.ChartData.Categories.Add(wb.GetCell(0, "A1", "Категория 1"));
		chart.ChartData.Categories.Add(wb.GetCell(0, "A2", "Категория 1"));
		chart.ChartData.Categories.Add(wb.GetCell(0, "A3", "Категория 1"));
		chart.ChartData.Categories.Add(wb.GetCell(0, "A4", "Категория 1"));
		chart.ChartData.Categories.Add(wb.GetCell(0, "A5", "Категория 1"));
		chart.ChartData.Categories.Add(wb.GetCell(0, "A6", "Категория 1"));

		IChartSeries series = chart.ChartData.Series.Add(ChartType.BoxAndWhisker);

		series.QuartileMethod = QuartileMethodType.Exclusive;
		series.ShowMeanLine = true;
		series.ShowMeanMarkers = true;
		series.ShowInnerPoints = true;
		series.ShowOutlierPoints = true;

		series.DataPoints.AddDataPointForBoxAndWhiskerSeries(wb.GetCell(0, "B1", 15));
		series.DataPoints.AddDataPointForBoxAndWhiskerSeries(wb.GetCell(0, "B2", 41));
		series.DataPoints.AddDataPointForBoxAndWhiskerSeries(wb.GetCell(0, "B3", 16));
		series.DataPoints.AddDataPointForBoxAndWhiskerSeries(wb.GetCell(0, "B4", 10));
		series.DataPoints.AddDataPointForBoxAndWhiskerSeries(wb.GetCell(0, "B5", 23));
		series.DataPoints.AddDataPointForBoxAndWhiskerSeries(wb.GetCell(0, "B6", 16));


		pres.Save("BoxAndWhisker.pptx", SaveFormat.Pptx);
	}
}
```


### **Создание воронкообразных диаграмм**
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Получите ссылку на слайд по его индексу.
1. Добавьте диаграмму с данными по умолчанию вместе с желаемым типом (ChartType.Funnel).
1. Запишите модифицированную презентацию в файл PPTX.

Этот код C# показывает, как создать воронкообразную диаграмму:

```c#
public static void Run()
{
	using (Presentation pres = new Presentation("test.pptx"))
	{
		IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Funnel, 50, 50, 500, 400);
		chart.ChartData.Categories.Clear();
		chart.ChartData.Series.Clear();

		IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

		wb.Clear(0);

		chart.ChartData.Categories.Add(wb.GetCell(0, "A1", "Категория 1"));
		chart.ChartData.Categories.Add(wb.GetCell(0, "A2", "Категория 2"));
		chart.ChartData.Categories.Add(wb.GetCell(0, "A3", "Категория 3"));
		chart.ChartData.Categories.Add(wb.GetCell(0, "A4", "Категория 4"));
		chart.ChartData.Categories.Add(wb.GetCell(0, "A5", "Категория 5"));
		chart.ChartData.Categories.Add(wb.GetCell(0, "A6", "Категория 6"));

		IChartSeries series = chart.ChartData.Series.Add(ChartType.Funnel);

		series.DataPoints.AddDataPointForFunnelSeries(wb.GetCell(0, "B1", 50));
		series.DataPoints.AddDataPointForFunnelSeries(wb.GetCell(0, "B2", 100));
		series.DataPoints.AddDataPointForFunnelSeries(wb.GetCell(0, "B3", 200));
		series.DataPoints.AddDataPointForFunnelSeries(wb.GetCell(0, "B4", 300));
		series.DataPoints.AddDataPointForFunnelSeries(wb.GetCell(0, "B5", 400));
		series.DataPoints.AddDataPointForFunnelSeries(wb.GetCell(0, "B6", 500));

		pres.Save("Funnel.pptx", SaveFormat.Pptx);
	}
}
```

### **Создание солнечных диаграмм**
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Получите ссылку на слайд по его индексу.
1. Добавьте диаграмму с данными по умолчанию вместе с желаемым типом (в данном случае, `ChartType.sunburst`).
1. Запишите модифицированную презентацию в файл PPTX.

Этот код C# показывает, как создать солнечную диаграмму:

```c#
public static void Run()
{
	using (Presentation pres = new Presentation("test.pptx"))
	{
		IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Sunburst, 50, 50, 500, 400);
		chart.ChartData.Categories.Clear();
		chart.ChartData.Series.Clear();

		IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

		wb.Clear(0);

		// Ветвь 1
		IChartCategory leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C1", "Лист1"));
		leaf.GroupingLevels.SetGroupingItem(1, "Стебель1");
		leaf.GroupingLevels.SetGroupingItem(2, "Ветвь1");

		chart.ChartData.Categories.Add(wb.GetCell(0, "C2", "Лист2"));

		leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C3", "Лист3"));
		leaf.GroupingLevels.SetGroupingItem(1, "Стебель2");

		chart.ChartData.Categories.Add(wb.GetCell(0, "C4", "Лист4"));

		// Ветвь 2
		leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C5", "Лист5"));
		leaf.GroupingLevels.SetGroupingItem(1, "Стебель3");
		leaf.GroupingLevels.SetGroupingItem(2, "Ветвь2");

		chart.ChartData.Categories.Add(wb.GetCell(0, "C6", "Лист6"));

		leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C7", "Лист7"));
		leaf.GroupingLevels.SetGroupingItem(1, "Стебель4");

		chart.ChartData.Categories.Add(wb.GetCell(0, "C8", "Лист8"));

		IChartSeries series = chart.ChartData.Series.Add(ChartType.Sunburst);
		series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
		series.DataPoints.AddDataPointForSunburstSeries(wb.GetCell(0, "D1", 4));
		series.DataPoints.AddDataPointForSunburstSeries(wb.GetCell(0, "D2", 5));
		series.DataPoints.AddDataPointForSunburstSeries(wb.GetCell(0, "D3", 3));
		series.DataPoints.AddDataPointForSunburstSeries(wb.GetCell(0, "D4", 6));
		series.DataPoints.AddDataPointForSunburstSeries(wb.GetCell(0, "D5", 9));
		series.DataPoints.AddDataPointForSunburstSeries(wb.GetCell(0, "D6", 9));
		series.DataPoints.AddDataPointForSunburstSeries(wb.GetCell(0, "D7", 4));
		series.DataPoints.AddDataPointForSunburstSeries(wb.GetCell(0, "D8", 3));

		pres.Save("Sunburst.pptx", SaveFormat.Pptx);
	}
}
```


### **Создание гистограммных диаграмм**
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Получите ссылку на слайд по его индексу. 
1. Добавьте диаграмму с данными и укажите предпочитаемый тип диаграммы (`ChartType.Histogram` в этом случае).
1. Получите доступ к данным диаграммы `IChartDataWorkbook`.
1. Очистите стандартные серии и категории.
1. Добавьте новые серии и категории.
1. Запишите модифицированную презентацию в файл PPTX.

Этот код C# показывает, как создать гистограмму:

```c#
public static void Run()
{
	using (Presentation pres = new Presentation("test.pptx"))
	{
		IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Histogram, 50, 50, 500, 400);
		chart.ChartData.Categories.Clear();
		chart.ChartData.Series.Clear();

		IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

		wb.Clear(0);

		IChartSeries series = chart.ChartData.Series.Add(ChartType.Histogram);
		series.DataPoints.AddDataPointForHistogramSeries(wb.GetCell(0, "A1", 15));
		series.DataPoints.AddDataPointForHistogramSeries(wb.GetCell(0, "A2", -41));
		series.DataPoints.AddDataPointForHistogramSeries(wb.GetCell(0, "A3", 16));
		series.DataPoints.AddDataPointForHistogramSeries(wb.GetCell(0, "A4", 10));
		series.DataPoints.AddDataPointForHistogramSeries(wb.GetCell(0, "A5", -23));
		series.DataPoints.AddDataPointForHistogramSeries(wb.GetCell(0, "A6", 16));

		chart.Axes.HorizontalAxis.AggregationType = AxisAggregationType.Automatic;

		pres.Save("Histogram.pptx", SaveFormat.Pptx);
	}
}
```

### **Создание радиальных диаграмм**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation). 
1. Получите ссылку на слайд по его индексу. 
1. Добавьте диаграмму с данными и укажите предпочитаемый тип диаграммы (`ChartType.Radar` в этом случае).
1. Запишите модифицированную презентацию в файл PPTX.

Этот код C# показывает, как создать радиальную диаграмму:

```c#
using (Presentation presentation = new Presentation())
{
    presentation.Slides[0].Shapes.AddChart(ChartType.Radar, 20, 20, 400, 300);
    presentation.Save("Radar-chart.pptx", SaveFormat.Pptx);
}
```

### **Создание многокатегорийных диаграмм**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation). 
1. Получите ссылку на слайд по его индексу.
1. Добавьте диаграмму с данными по умолчанию вместе с желаемым типом (ChartType.ClusteredColumn).
1. Получите доступ к данным диаграммы IChartDataWorkbook.
1. Очистите стандартные серии и категории.
1. Добавьте новые серии и категории.
1. Добавьте новые данные диаграммы для серий диаграммы.
1. Запишите модифицированную презентацию в файл.

Этот код C# показывает, как создать многокатегорийную диаграмму:

```c#
Presentation pres = new Presentation();
ISlide slide = pres.Slides[0];

IChart ch = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 600, 450);
ch.ChartData.Series.Clear();
ch.ChartData.Categories.Clear();


IChartDataWorkbook fact = ch.ChartData.ChartDataWorkbook;
fact.Clear(0);
int defaultWorksheetIndex = 0;

IChartCategory category = ch.ChartData.Categories.Add(fact.GetCell(0, "c2", "A"));
category.GroupingLevels.SetGroupingItem(1, "Группа1");
category = ch.ChartData.Categories.Add(fact.GetCell(0, "c3", "B"));

category = ch.ChartData.Categories.Add(fact.GetCell(0, "c4", "C"));
category.GroupingLevels.SetGroupingItem(1, "Группа2");
category = ch.ChartData.Categories.Add(fact.GetCell(0, "c5", "D"));

category = ch.ChartData.Categories.Add(fact.GetCell(0, "c6", "E"));
category.GroupingLevels.SetGroupingItem(1, "Группа3");
category = ch.ChartData.Categories.Add(fact.GetCell(0, "c7", "F"));

category = ch.ChartData.Categories.Add(fact.GetCell(0, "c8", "G"));
category.GroupingLevels.SetGroupingItem(1, "Группа4");
category = ch.ChartData.Categories.Add(fact.GetCell(0, "c9", "H"));

// Добавляет серии
IChartSeries series = ch.ChartData.Series.Add(fact.GetCell(0, "D1", "Серия 1"),
    ChartType.ClusteredColumn);

series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, "D2", 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, "D3", 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, "D4", 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, "D5", 40));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, "D6", 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, "D7", 60));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, "D8", 70));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, "D9", 80));
// Сохраняет презентацию с диаграммой
pres.Save("AsposeChart_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

### **Создание картографических диаграмм**

Картографическая диаграмма — это визуализация области, содержащей данные. Картографические диаграммы лучше всего подходят для сравнения данных или значений по географическим регионам.

Этот код C# показывает, как создать картографическую диаграмму:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Map, 50, 50, 500, 400);
    pres.Save("mapChart.pptx", SaveFormat.Pptx);
}
```

### **Создание комбинированных диаграмм**

Комбинированная диаграмма (или комбо-диаграмма) — это диаграмма, которая объединяет два или более графиков на одном графике. Такая диаграмма позволяет выделить, сравнить или проанализировать различия между двумя (или более) наборами данных. Таким образом, вы видите взаимосвязь (если таковая имеется) между наборами данных. 

![combination-chart-ppt](combination-chart-ppt.png)

Этот код C# показывает, как создать комбинированную диаграмму в PowerPoint:

```c#
private static void CreateComboChart()
{
    using (Presentation pres = new Presentation())
    {
        IChart chart = CreateChart(pres.Slides[0]);
        AddFirstSeriesToChart(chart);
        AddSecondSeriesToChart(chart);
        pres.Save("combo-chart.pptx", SaveFormat.Pptx);
    }
}

private static IChart CreateChart(ISlide slide)
{
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    const int worksheetIndex = 0;
    
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 1, "Серия 1"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 2, "Серия 2"), chart.Type);
    
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 1, 0, "Категория 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 2, 0, "Категория 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 3, 0, "Категория 3"));

    IChartSeries series = chart.ChartData.Series[0];

    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 20));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 50));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 30));
    
    series = chart.ChartData.Series[1];
    
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 2, 30));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 2, 10));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 2, 60));

    return chart;
}

private static void AddFirstSeriesToChart(IChart chart)
{
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    const int worksheetIndex = 0;
    
    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 3, "Серия 3"), ChartType.ScatterWithSmoothLines);

    series.DataPoints.AddDataPointForScatterSeries(
        workbook.GetCell(worksheetIndex, 0, 1, 3),
        workbook.GetCell(worksheetIndex, 0, 2, 5));
    
    series.DataPoints.AddDataPointForScatterSeries(
        workbook.GetCell(worksheetIndex, 1, 3, 10),
        workbook.GetCell(worksheetIndex, 1, 4, 13));

    series.DataPoints.AddDataPointForScatterSeries(
        workbook.GetCell(worksheetIndex, 2, 3, 20),
        workbook.GetCell(worksheetIndex, 2, 4, 15));

    series.PlotOnSecondAxis = true;
}

private static void AddSecondSeriesToChart(IChart chart)
{
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    const int worksheetIndex = 0;
    
    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 5, "Серия 4"),
        ChartType.ScatterWithStraightLinesAndMarkers);

    series.DataPoints.AddDataPointForScatterSeries(
        workbook.GetCell(worksheetIndex, 1, 3, 5),
        workbook.GetCell(worksheetIndex, 1, 4, 2));
    
    series.DataPoints.AddDataPointForScatterSeries(
        workbook.GetCell(worksheetIndex, 1, 5, 10),
        workbook.GetCell(worksheetIndex, 1, 6, 7));

    series.DataPoints.AddDataPointForScatterSeries(
        workbook.GetCell(worksheetIndex, 2, 5, 15),
        workbook.GetCell(worksheetIndex, 2, 6, 12));

    series.DataPoints.AddDataPointForScatterSeries(
        workbook.GetCell(worksheetIndex, 3, 5, 12),
        workbook.GetCell(worksheetIndex, 3, 6, 9));
    
    series.PlotOnSecondAxis = true;
}
```

## **Обновление диаграмм**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), который представляет презентацию, содержащую диаграмму.
2. Получите ссылку на слайд по его индексу.
3. Пройдите через все формы, чтобы найти необходимую диаграмму.
4. Получите доступ к рабочему листу диаграммы.
5. Измените данные серии диаграммы, изменив значения серий.
6. Добавьте новую серию и заполните в ней данные.
7. Запишите модифицированную презентацию в файл PPTX.

Этот код C# показывает, как обновить диаграмму:

```c#
// Создает экземпляр класса Presentation, который представляет файл PPTX
Presentation pres = new Presentation("ExistingChart.pptx");

// Получает первый слайд
ISlide sld = pres.Slides[0];

// Добавляет диаграмму с стандартными данными
IChart chart = (IChart)sld.Shapes[0];

// Устанавливает индекс для листа данных диаграммы
int defaultWorksheetIndex = 0;

// Получает рабочий лист данных диаграммы
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;


// Изменяет имя категории диаграммы
fact.GetCell(defaultWorksheetIndex, 1, 0, "Измененная категория 1");
fact.GetCell(defaultWorksheetIndex, 2, 0, "Измененная категория 2");


// Берет первую серию диаграммы
IChartSeries series = chart.ChartData.Series[0];

// Обновляет данные серии
fact.GetCell(defaultWorksheetIndex, 0, 1, "Новая_Серия1"); // Изменение имени серии
series.DataPoints[0].Value.Data = 90;
series.DataPoints[1].Value.Data = 123;
series.DataPoints[2].Value.Data = 44;

// Берет вторую серию диаграммы
series = chart.ChartData.Series[1];

// Теперь обновляет данные серии
fact.GetCell(defaultWorksheetIndex, 0, 2, "Новая_Серия2"); // Изменение имени серии
series.DataPoints[0].Value.Data = 23;
series.DataPoints[1].Value.Data = 67;
series.DataPoints[2].Value.Data = 99;


// Теперь добавляем новую серию
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 3, "Серия 3"), chart.Type);

// Берет третью серию диаграммы
series = chart.ChartData.Series[2];

// Теперь заполняет данные серии
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 3, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 3, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 3, 30));

chart.Type = ChartType.ClusteredCylinder;

// Сохраняет презентацию с диаграммой
pres.Save("AsposeChartModified_out.pptx", SaveFormat.Pptx);
```

## **Установка диапазона данных для диаграмм**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), который представляет презентацию, содержащую диаграмму.
2. Получите ссылку на слайд по его индексу.
3. Пройдите через все формы, чтобы найти необходимую диаграмму.
4. Получите доступ к данным диаграммы и установите диапазон.
5. Сохраните модифицированную презентацию в файл PPTX.

Этот код C# показывает, как установить диапазон данных для диаграммы:

```c#
// Создает экземпляр класса Presentation, который представляет файл PPTX
Presentation presentation = new Presentation("ExistingChart.pptx");

// Получает первый слайд и добавляет диаграмму со стандартными данными
ISlide slide = presentation.Slides[0];
IChart chart = (IChart)slide.Shapes[0];
chart.ChartData.SetRange("Sheet1!A1:B4");
presentation.Save("SetDataRange_out.pptx", SaveFormat.Pptx);
```


## **Использование стандартных маркеров в диаграммах**
Когда вы используете стандартный маркер в диаграммах, каждой серии диаграммы автоматически назначаются различные стандартные символы маркеров.

Этот код C# показывает, как автоматически установить маркер серии диаграммы:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 10, 10, 400, 400);

    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;
    chart.ChartData.Series.Add(fact.GetCell(0, 0, 1, "Серия 1"), chart.Type);
    IChartSeries series = chart.ChartData.Series[0];

    chart.ChartData.Categories.Add(fact.GetCell(0, 1, 0, "C1"));
    series.DataPoints.AddDataPointForLineSeries(fact.GetCell(0, 1, 1, 24));
    chart.ChartData.Categories.Add(fact.GetCell(0, 2, 0, "C2"));
    series.DataPoints.AddDataPointForLineSeries(fact.GetCell(0, 2, 1, 23));
    chart.ChartData.Categories.Add(fact.GetCell(0, 3, 0, "C3"));
    series.DataPoints.AddDataPointForLineSeries(fact.GetCell(0, 3, 1, -10));
    chart.ChartData.Categories.Add(fact.GetCell(0, 4, 0, "C4"));
    series.DataPoints.AddDataPointForLineSeries(fact.GetCell(0, 4, 1, null));

    chart.ChartData.Series.Add(fact.GetCell(0, 0, 2, "Серия 2"), chart.Type);
    // Берет вторую серию диаграммы
    IChartSeries series2 = chart.ChartData.Series[1];

    // Заполняет данные серии
    series2.DataPoints.AddDataPointForLineSeries(fact.GetCell(0, 1, 2, 30));
    series2.DataPoints.AddDataPointForLineSeries(fact.GetCell(0, 2, 2, 10));
    series2.DataPoints.AddDataPointForLineSeries(fact.GetCell(0, 3, 2, 60));
    series2.DataPoints.AddDataPointForLineSeries(fact.GetCell(0, 4, 2, 40));

    chart.HasLegend = true;
    chart.Legend.Overlay = false;

    pres.Save("DefaultMarkersInChart.pptx", SaveFormat.Pptx);
}
```