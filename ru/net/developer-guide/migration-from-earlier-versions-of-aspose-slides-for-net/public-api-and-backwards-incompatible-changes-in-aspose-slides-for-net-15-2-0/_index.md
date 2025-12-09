---
title: Публичный API и несовместимые изменения в Aspose.Slides for .NET 15.2.0
linktitle: Aspose.Slides for .NET 15.2.0
type: docs
weight: 140
url: /ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/
keywords:
- миграция
- устаревший код
- современный код
- устаревший подход
- современный подход
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Обзор обновлений публичного API и несовместимых изменений в Aspose.Slides for .NET, позволяющий плавно мигрировать ваши решения для презентаций PowerPoint PPT, PPTX и ODP."
---

{{% alert color="primary" %}} 
Эта страница перечисляет все [added](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) или [removed](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) классы, методы, свойства и т.п., а также другие изменения, введённые в API Aspose.Slides for .NET 15.2.0.
{{% /alert %}} 
## **Изменения публичного API**
#### **Добавлены методы AddDataPointForDoughnutSeries**
В класс IChartDataPointCollection добавлены два перегруженных метода AddDataPointForDoughnutSeries() для добавления точек данных в серии типа диаграммы «Кольцевая».
#### **Класс Aspose.Slides.SmartArt.SmartArtShape теперь наследуется от Aspose.Slides.GeometryShape**
Класс Aspose.Slides.SmartArt.SmartArtShape теперь наследуется от Aspose.Slides.GeometryShape. Это улучшает объектную модель Aspose.Slides и добавляет новые возможности классу SmartArtShape.
#### **Добавлены методы для удаления точки данных и категории диаграммы по индексу**
В класс IChartDataPointCollection добавлен метод RemoveAt(int index) для удаления точки данных диаграммы по её индексу.  
В класс IChartCategoryCollection добавлен метод RemoveAt(int index) для удаления категории диаграммы по её индексу.
#### **В перечисление Aspose.Slides.Animation.PropertyType добавлено значение PptXPptY**
В перечисление Aspose.Slides.Animation.PropertyType добавлено значение PptXPptY в рамках исправления проблемы сериализации.
#### **В интерфейс Aspose.Slides.Charts.IChartSeries добавлен метод System.Drawing.Color GetAutomaticSeriesColor()**
Метод GetAutomaticSeriesColor возвращает автоматический цвет серии на основе индекса серии и стиля диаграммы. Этот цвет используется по умолчанию, если FillType равно NotDefined.

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