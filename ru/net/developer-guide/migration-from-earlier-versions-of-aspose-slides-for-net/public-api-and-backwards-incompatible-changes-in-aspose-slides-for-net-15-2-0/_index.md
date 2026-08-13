---
title: Публичный API и несовместимые изменения в Aspose.Slides для .NET 15.2.0
linktitle: Aspose.Slides для .NET 15.2.0
type: docs
weight: 140
url: /ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/
keywords:
- миграция
- унаследованный код
- современный код
- унаследованный подход
- современный подход
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Обзор обновлений публичного API и разрушающих изменений в Aspose.Slides для .NET, чтобы плавно мигрировать решения презентаций PowerPoint PPT, PPTX и ODP."
---
{{% alert color="info" %}}

Эта страница перечисляет все [добавленные](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) или [удалённые](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) классы, методы, свойства и т.д., а также другие изменения, внесённые в API Aspose.Slides для .NET 15.2.0.

{{% /alert %}} 
## **Изменения публичного API**
#### **Методы AddDataPointForDoughnutSeries добавлены**
Были добавлены две перегрузки метода IChartDataPointCollection.AddDataPointForDoughnutSeries() для добавления точек данных в серии кольцевой диаграммы.
#### **Класс Aspose.Slides.SmartArt.SmartArtShape теперь наследуется от класса Aspose.Slides.GeometryShape**
Класс Aspose.Slides.SmartArt.SmartArtShape теперь наследуется от класса Aspose.Slides.GeometryShape. Это изменение улучшает объектную модель Aspose.Slides и добавляет новые возможности классу SmartArtShape.
#### **Методы для удаления точки данных графика и категории графика по индексу добавлены**
Метод IChartDataPointCollection.RemoveAt(int index) был добавлен для удаления точки данных графика по её индексу.
Метод IChartCategoryCollection.RemoveAt(int index) был добавлен для удаления категории графика по её индексу.
#### **Значение PptXPptY добавлено в перечисление Aspose.Slides.Animation.PropertyType**
Значение PptXPptY было добавлено в перечисление Aspose.Slides.Animation.PropertyType в рамках исправления проблемы сериализации.
#### **Метод System.Drawing.Color GetAutomaticSeriesColor() добавлен в Aspose.Slides.Charts.IChartSeries**
Метод GetAutomaticSeriesColor возвращает автоматический цвет серии на основе индекса серии и стиля диаграммы. Этот цвет используется по умолчанию, если FillType равно NotDefined.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;




using (Presentation pres = new Presentation())

{

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    for (int i = 0; i < chart.ChartData.Series.Count; i++)

    {

        chart.ChartData.Series[i].GetAutomaticSeriesColor();

    }

}
```