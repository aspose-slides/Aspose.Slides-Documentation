---
title: Публичный API и несовместимые изменения в Aspose.Slides для .NET 15.2.0
type: docs
weight: 140
url: /ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/
---

{{% alert color="primary" %}} 

Эта страница содержит список всех [добавленных](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) или [удалённых](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) классов, методов, свойств и так далее, а также других изменений, внесённых в API Aspose.Slides для .NET 15.2.0.

{{% /alert %}} 
## **Изменения публичного API**
#### **Добавлены методы AddDataPointForDoughnutSeries**
Добавлено два перегруженных метода IChartDataPointCollection.AddDataPointForDoughnutSeries() для добавления точек данных в серии типа круговой диаграммы.
#### **Класс Aspose.Slides.SmartArt.SmartArtShape наследуется от класса Aspose.Slides.GeometryShape**
Класс Aspose.Slides.SmartArt.SmartArtShape наследуется от класса Aspose.Slides.GeometryShape. Это изменение улучшает объектную модель Aspose.Slides и добавляет новые функции в класс SmartArtShape.
#### **Добавлены методы для удаления точек данных диаграммы и категорий диаграммы по индексу**
Метод IChartDataPointCollection.RemoveAt(int index) был добавлен для удаления точки данных диаграммы по её индексу.
Метод IChartCategoryCollection.RemoveAt(int index) был добавлен для удаления категории диаграммы по её индексу.
#### **Значение PptXPptY было добавлено в перечисление Aspose.Slides.Animation.PropertyType**
Значение PptXPptY было добавлено в перечисление Aspose.Slides.Animation.PropertyType в рамках исправления проблемы с сериализацией.
#### **Метод System.Drawing.Color GetAutomaticSeriesColor() был добавлен в Aspose.Slides.Charts.IChartSeries**
Метод GetAutomaticSeriesColor возвращает автоматический цвет серии на основе индекса серии и стиля диаграммы. Этот цвет используется по умолчанию, если FillType равен NotDefined.

``` csharp



using (Presentation pres = new Presentation())

{

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    for (int i = 0; i < chart.ChartData.Series.Count; i++)

    {

        chart.ChartData.Series[i].GetAutomaticSeriesColor();

    }

}

```