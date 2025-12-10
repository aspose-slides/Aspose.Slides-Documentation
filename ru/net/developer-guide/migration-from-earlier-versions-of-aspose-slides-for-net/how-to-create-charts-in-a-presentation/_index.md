---
title: Как создавать диаграммы в презентациях в .NET
linktitle: Создать диаграмму
type: docs
weight: 30
url: /ru/net/how-to-create-charts-in-a-presentation/
keywords:
- миграция
- создание диаграммы
- старый код
- современный код
- старый подход
- современный подход
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как создавать диаграммы в презентациях PowerPoint PPT, PPTX и ODP в .NET с помощью Aspose.Slides, используя как устаревшие, так и современные методы API диаграмм."
---

{{% alert color="primary" %}} 

Выпущен новый [Aspose.Slides for .NET API](/slides/ru/net/), и теперь этот единый продукт поддерживает возможность создавать документы PowerPoint с нуля и редактировать существующие.

{{% /alert %}} 
## **Поддержка устаревшего кода**
Чтобы использовать устаревший код, разработанный для версий Aspose.Slides for .NET до 13.x, необходимо внести небольшие изменения в ваш код, после чего он будет работать так же, как и раньше. Все классы, которые ранее находились в пространствах имен Aspose.Slide и Aspose.Slides.Pptx, теперь объединены в едином пространстве имен Aspose.Slides. Ознакомьтесь с простым примером кода создания обычной диаграммы с нуля в презентации с использованием устаревшего API Aspose.Slides и следуйте инструкциям по миграции на новый объединённый API.
## **Подход к устаревшему Aspose.Slides for .NET**
```c#
//Создать экземпляр класса PresentationEx, представляющего файл PPTX
using (PresentationEx pres = new PresentationEx())
{
	//Получить первый слайд
	SlideEx sld = pres.Slides[0];

	// Добавить диаграмму с данными по умолчанию
	ChartEx chart = sld.Shapes.AddChart(ChartTypeEx.ClusteredColumn, 0, 0, 500, 500);

	//Установка заголовка диаграммы
	chart.ChartTitle.Text.Text = "Sample Title";
	chart.ChartTitle.Text.CenterText = true;
	chart.ChartTitle.Height = 20;
	chart.HasTitle = true;

	//Установить отображение значений для первой серии
	chart.ChartData.Series[0].Labels.ShowValue = true;

	//Установка индекса листа данных диаграммы 
	int defaultWorksheetIndex = 0;

	//Получение листа данных диаграммы
	ChartDataCellFactory fact = chart.ChartData.ChartDataCellFactory;

	//Удалить автоматически сгенерированные серии и категории
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Clear();
	int s = chart.ChartData.Series.Count;
	s = chart.ChartData.Categories.Count;

	//Добавление новых серий
	chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
	chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

	//Добавление новых категорий
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

	//Получить первую серию диаграммы
	ChartSeriesEx series = chart.ChartData.Series[0];

	//Заполняем данные серии
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

	//Установка цвета заливки для серии
	series.Format.Fill.FillType = FillTypeEx.Solid;
	series.Format.Fill.SolidFillColor.Color = Color.Red;


	//Получить вторую серию диаграммы
	series = chart.ChartData.Series[1];

	//Заполняем данные серии
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

	//Установка цвета заливки для серии
	series.Format.Fill.FillType = FillTypeEx.Solid;
	series.Format.Fill.SolidFillColor.Color = Color.Green;


	//Создать пользовательские подписи для каждой категории новой серии

	//Первая подпись будет отображать имя категории
	DataLabelEx lbl = new DataLabelEx(series);
	lbl.ShowCategoryName = true;
	lbl.Id = 0;
	series.Labels.Add(lbl);

	//Отображать имя серии во второй подписи
	lbl = new DataLabelEx(series);
	lbl.ShowSeriesName = true;
	lbl.Id = 1;
	series.Labels.Add(lbl);

	//Отображать значение в третьей подписи
	lbl = new DataLabelEx(series);
	lbl.ShowValue = true;
	lbl.ShowSeriesName = true;
	lbl.Separator = "/";
	lbl.Id = 2;
	series.Labels.Add(lbl);

	//Отображать значение и пользовательский текст
	lbl = new DataLabelEx(series);
	lbl.TextFrame.Text = "My text";
	lbl.Id = 3;
	series.Labels.Add(lbl);

	//Сохранить презентацию с диаграммой
	pres.Write(@"D:\AsposeChart.pptx");
}
```




## **Новый подход Aspose.Slides for .NET 13.x**
```csharp
//Создать экземпляр класса Presentation, представляющего файл PPTX//Создать экземпляр класса Presentation, представляющего файл PPTX
Presentation pres = new Presentation();

//Access first slide
ISlide sld = pres.Slides[0];

// Add chart with default data
IChart chart = sld.Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 500);

//Setting chart Title
//chart.ChartTitle.TextFrameForOverriding.Text = "Sample Title";
chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

//Set first series to Show Values
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

//Setting the index of chart data sheet
int defaultWorksheetIndex = 0;

//Getting the chart data worksheet
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

//Delete default generated series and categories
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
int s = chart.ChartData.Series.Count;
s = chart.ChartData.Categories.Count;

//Adding new series
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

//Adding new categories
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

//Take first chart series
IChartSeries series = chart.ChartData.Series[0];

//Now populating series data
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

//Setting fill color for series
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;


//Take second chart series
series = chart.ChartData.Series[1];

//Now populating series data
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

//Setting fill color for series
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Green;


//create custom labels for each of categories for new series
//first label will be show Category name
IDataLabel lbl = series.DataPoints[0].Label;
lbl.DataLabelFormat.ShowCategoryName = true;

lbl = series.DataPoints[1].Label;
lbl.DataLabelFormat.ShowSeriesName = true;

//Show value for third label
lbl = series.DataPoints[2].Label;
lbl.DataLabelFormat.ShowValue = true;
lbl.DataLabelFormat.ShowSeriesName = true;
lbl.DataLabelFormat.Separator = "/";

//Save presentation with chart
pres.Save("AsposeChart.pptx", SaveFormat.Pptx);
```


Ознакомьтесь с простым примером кода создания диаграммы рассеяния с нуля в презентации с использованием устаревшего API Aspose.Slides и тем, как реализовать её с помощью нового объединённого API.

## **Подход к устаревшему Aspose.Slides for .NET**
```c#
using (PresentationEx pres = new PresentationEx())
{
    SlideEx slide = pres.Slides[0];

    //Создание диаграммы по умолчанию
    ChartEx chart = slide.Shapes.AddChart(ChartTypeEx.ScatterWithSmoothLines, 0, 0, 400, 400);

    //Получение индекса листа данных диаграммы по умолчанию
    int defaultWorksheetIndex = 0;

    //Доступ к листу данных диаграммы
    ChartDataCellFactory fact = chart.ChartData.ChartDataCellFactory;

    //Удалить демо-серии
    chart.ChartData.Series.Clear();

    //Добавить новые серии
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.Type);

    //Получить первую серию диаграммы
    ChartSeriesEx series = chart.ChartData.Series[0];

    //Добавить новую точку (1:3) сюда.
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 1));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

    //Добавить новую точку (2:10)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 2));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

    //Изменить тип серии
    series.Type = ChartTypeEx.ScatterWithStraightLinesAndMarkers;

    //Изменение маркера серии диаграммы
    series.MarkerSize = 10;
    series.MarkerSymbol = MarkerStyleTypeEx.Star;

    //Получить вторую серию диаграммы
    series = chart.ChartData.Series[1];

    //Добавить новую точку (5:2) сюда.
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 3, 5));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

    //Добавить новую точку (3:1)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 3, 3));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

    //Добавить новую точку (2:2)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 4, 3, 2));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

    //Добавить новую точку (5:1)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 5, 3, 5));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

    //Изменение маркера серии диаграммы
    series.MarkerSize = 10;
    series.MarkerSymbol = MarkerStyleTypeEx.Circle;

    pres.Write("D:\\AsposeSeriesChart.pptx");
}
```



## **Новый подход Aspose.Slides for .NET 13.x**
``` csharp
Presentation pres = new Presentation();

ISlide slide = pres.Slides[0];

//Создание диаграммы по умолчанию
IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);

//Получение индекса листа данных диаграммы по умолчанию
int defaultWorksheetIndex = 0;

//Доступ к листу данных диаграммы
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

//Удалить демонстрационные серии
chart.ChartData.Series.Clear();

//Добавить новые серии
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.Type);

//Получить первую серию диаграммы
IChartSeries series = chart.ChartData.Series[0];

//Добавить новую точку (1:3) сюда.
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 1), fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

//Добавить новую точку (2:10)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 2), fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

//Изменить тип серии
series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

//Изменение маркера серии диаграммы
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Star;

//Получить вторую серию диаграммы
series = chart.ChartData.Series[1];

//Добавить новую точку (5:2) сюда.
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 3, 5), fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

//Добавить новую точку (3:1)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 3, 3), fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

//Добавить новую точку (2:2)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 4, 3, 2), fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

//Добавить новую точку (5:1)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 5, 3, 5), fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

//Изменение маркера серии диаграммы
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Circle;

pres.Save("AsposeScatterChart.pptx", SaveFormat.Pptx);
```
