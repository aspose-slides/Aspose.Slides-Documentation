---
title: Как создать графики в презентации
type: docs
weight: 30
url: /ru/net/how-to-create-charts-in-a-presentation/
---

{{% alert color="primary" %}} 

Выпущен новый [Aspose.Slides для .NET API](/slides/ru/net/), который теперь поддерживает возможность создания документов PowerPoint с нуля и редактирования существующих.

{{% /alert %}} 
## **Поддержка устаревшего кода**
Чтобы использовать устаревший код, разработанный с помощью Aspose.Slides для .NET версий ранее 13.x, вам нужно внести несколько небольших изменений в ваш код, и он будет работать, как раньше. Все классы, которые были представлены в старом Aspose.Slides для .NET в пространствах имен Aspose.Slide и Aspose.Slides.Pptx, теперь объединены в одно пространство имен Aspose.Slides. Пожалуйста, посмотрите следующий простой фрагмент кода для создания обычного графика с нуля в презентации с использованием устаревшего API Aspose.Slides и следуйте инструкциям по миграции на новый объединенный API.
## **Устаревший подход Aspose.Slides для .NET**
```c#
//Создаем экземпляр класса PresentationEx, который представляет файл PPTX
using (PresentationEx pres = new PresentationEx())
{
	//Получаем первый слайд
	SlideEx sld = pres.Slides[0];

	// Добавляем график с данными по умолчанию
	ChartEx chart = sld.Shapes.AddChart(ChartTypeEx.ClusteredColumn, 0, 0, 500, 500);

	//Устанавливаем заголовок графика
	chart.ChartTitle.Text.Text = "Пример заголовка";
	chart.ChartTitle.Text.CenterText = true;
	chart.ChartTitle.Height = 20;
	chart.HasTitle = true;

	//Установить значения для первой серии
	chart.ChartData.Series[0].Labels.ShowValue = true;

	//Устанавливаем индекс листа данных графика
	int defaultWorksheetIndex = 0;

	//Получаем лист данных графика
	ChartDataCellFactory fact = chart.ChartData.ChartDataCellFactory;

	//Удаляем сгенерированные по умолчанию серии и категории
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Clear();
	int s = chart.ChartData.Series.Count;
	s = chart.ChartData.Categories.Count;

	//Добавляем новые серии
	chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Серия 1"), chart.Type);
	chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Серия 2"), chart.Type);

	//Добавляем новые категории
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Категория 1"));
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Категория 2"));
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Категория 3"));

	//Берем первую серию графика
	ChartSeriesEx series = chart.ChartData.Series[0];

	//Теперь заполняем данные серии
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

	//Устанавливаем цвет заполнения для серии
	series.Format.Fill.FillType = FillTypeEx.Solid;
	series.Format.Fill.SolidFillColor.Color = Color.Red;


	//Берем вторую серию графика
	series = chart.ChartData.Series[1];

	//Теперь заполняем данные серии
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

	//Устанавливаем цвет заполнения для серии
	series.Format.Fill.FillType = FillTypeEx.Solid;
	series.Format.Fill.SolidFillColor.Color = Color.Green;


	//создаем пользовательские метки для каждой из категорий для новой серии

	//первая метка будет показывать имя категории
	DataLabelEx lbl = new DataLabelEx(series);
	lbl.ShowCategoryName = true;
	lbl.Id = 0;
	series.Labels.Add(lbl);

	//Показать имя серии для второй метки
	lbl = new DataLabelEx(series);
	lbl.ShowSeriesName = true;
	lbl.Id = 1;
	series.Labels.Add(lbl);

	//Показать значение для третьей метки
	lbl = new DataLabelEx(series);
	lbl.ShowValue = true;
	lbl.ShowSeriesName = true;
	lbl.Separator = "/";
	lbl.Id = 2;
	series.Labels.Add(lbl);

	//Показать значение и пользовательский текст
	lbl = new DataLabelEx(series);
	lbl.TextFrame.Text = "Мой текст";
	lbl.Id = 3;
	series.Labels.Add(lbl);

	//Сохранить презентацию с графиком
	pres.Write(@"D:\AsposeChart.pptx");
}
```



## **Новый подход Aspose.Slides для .NET 13.x**
``` csharp
//Создаем экземпляр класса Presentation, который представляет файл PPTX
Presentation pres = new Presentation();

//Получаем первый слайд
ISlide sld = pres.Slides[0];

// Добавляем график с данными по умолчанию
IChart chart = sld.Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 500);

//Устанавливаем заголовок графика
//chart.ChartTitle.TextFrameForOverriding.Text = "Пример заголовка";
chart.ChartTitle.AddTextFrameForOverriding("Пример заголовка");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

//Установить значения для первой серии
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

//Устанавливаем индекс листа данных графика
int defaultWorksheetIndex = 0;

//Получаем лист данных графика
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

//Удаляем сгенерированные по умолчанию серии и категории
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
int s = chart.ChartData.Series.Count;
s = chart.ChartData.Categories.Count;

//Добавляем новые серии
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Серия 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Серия 2"), chart.Type);

//Добавляем новые категории
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Категория 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Категория 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Категория 3"));

//Берем первую серию графика
IChartSeries series = chart.ChartData.Series[0];

//Теперь заполняем данные серии

series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

//Устанавливаем цвет заполнения для серии
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;


//Берем вторую серию графика
series = chart.ChartData.Series[1];

//Теперь заполняем данные серии
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

//Устанавливаем цвет заполнения для серии
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Green;


//создаем пользовательские метки для каждой из категорий для новой серии

//первая метка будет показывать имя категории
IDataLabel lbl = series.DataPoints[0].Label;
lbl.DataLabelFormat.ShowCategoryName = true;

lbl = series.DataPoints[1].Label;
lbl.DataLabelFormat.ShowSeriesName = true;

//Показать значение для третьей метки
lbl = series.DataPoints[2].Label;
lbl.DataLabelFormat.ShowValue = true;
lbl.DataLabelFormat.ShowSeriesName = true;
lbl.DataLabelFormat.Separator = "/";

//Сохранить презентацию с графиком
pres.Save("AsposeChart.pptx", SaveFormat.Pptx);
```

Пожалуйста, посмотрите следующий простой фрагмент кода для создания разбросанного графика с нуля в презентации с использованием устаревшего API Aspose.Slides и как достичь этого с новым объединенным API.

## **Устаревший подход Aspose.Slides для .NET**
```c#
using (PresentationEx pres = new PresentationEx())
{
    SlideEx slide = pres.Slides[0];

    //Создание графика по умолчанию
    ChartEx chart = slide.Shapes.AddChart(ChartTypeEx.ScatterWithSmoothLines, 0, 0, 400, 400);

    //Получаем индекс листа данных графика по умолчанию
    int defaultWorksheetIndex = 0;

    //Получаем доступ к листу данных графика
    ChartDataCellFactory fact = chart.ChartData.ChartDataCellFactory;

    //Удаляем демонстрационные серии
    chart.ChartData.Series.Clear();

    //Добавляем новые серии
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Серия 1"), chart.Type);
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Серия 2"), chart.Type);

    //Берем первую серию графика
    ChartSeriesEx series = chart.ChartData.Series[0];

    //Добавляем новую точку (1:3)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 1));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

    //Добавляем новую точку (2:10)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 2));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

    //Редактируем тип серии
    series.Type = ChartTypeEx.ScatterWithStraightLinesAndMarkers;

    //Изменяем маркер серии графика
    series.MarkerSize = 10;
    series.MarkerSymbol = MarkerStyleTypeEx.Star;

    //Берем вторую серию графика
    series = chart.ChartData.Series[1];

    //Добавляем новую точку (5:2)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 3, 5));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

    //Добавляем новую точку (3:1)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 3, 3));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

    //Добавляем новую точку (2:2)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 4, 3, 2));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

    //Добавляем новую точку (5:1)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 5, 3, 5));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

    //Изменяем маркер серии графика
    series.MarkerSize = 10;
    series.MarkerSymbol = MarkerStyleTypeEx.Circle;

    pres.Write("D:\\AsposeSeriesChart.pptx");
}
```


## **Новый подход Aspose.Slides для .NET 13.x**
``` csharp
Presentation pres = new Presentation();

ISlide slide = pres.Slides[0];

//Создание графика по умолчанию
IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);

//Получаем индекс листа данных графика по умолчанию
int defaultWorksheetIndex = 0;

//Получаем доступ к листу данных графика
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

//Удаляем демонстрационные серии
chart.ChartData.Series.Clear();

//Добавляем новые серии
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Серия 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Серия 2"), chart.Type);

//Берем первую серию графика
IChartSeries series = chart.ChartData.Series[0];

//Добавляем новую точку (1:3)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 1), fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

//Добавляем новую точку (2:10)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 2), fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

//Редактируем тип серии
series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

//Изменяем маркер серии графика
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Star;

//Берем вторую серию графика
series = chart.ChartData.Series[1];

//Добавляем новую точку (5:2)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 3, 5), fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

//Добавляем новую точку (3:1)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 3, 3), fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

//Добавляем новую точку (2:2)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 4, 3, 2), fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

//Добавляем новую точку (5:1)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 5, 3, 5), fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

//Изменяем маркер серии графика
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Circle;

pres.Save("AsposeScatterChart.pptx", SaveFormat.Pptx);
```