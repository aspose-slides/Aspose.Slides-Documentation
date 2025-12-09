---
title: Общедоступный API и обратные несовместимые изменения в Aspose.Slides для .NET 15.2.0
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
description: "Обзор обновлений публичного API и разрушающих изменений в Aspose.Slides для .NET, позволяющий плавно мигрировать решения презентаций PowerPoint PPT, PPTX и ODP."
---

{{% alert color="primary" %}} 

Эта страница перечисляет все [добавленные](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) или [удалённые](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) классы, методы, свойства и т.д., а также другие изменения, введённые в API Aspose.Slides for .NET 15.2.0.

{{% /alert %}} 
## **Изменения публичного API**
#### **Методы AddDataPointForDoughnutSeries добавлены**
Были добавлены две перегрузки метода IChartDataPointCollection.AddDataPointForDoughnutSeries() для добавления точек данных в серии типа диаграммы «Кольцевая».
#### **Класс Aspose.Slides.SmartArt.SmartArtShape унаследован от класса Aspose.Slides.GeometryShape**
Класс Aspose.Slides.SmartArt.SmartArtShape унаследован от класса Aspose.Slides.GeometryShape. Это изменение улучшает объектную модель Aspose.Slides и добавляет новые возможности классу SmartArtShape.
#### **Методы для удаления точки данных диаграммы и категории диаграммы по индексу добавлены**
Метод IChartDataPointCollection.RemoveAt(int index) добавлен для удаления точки данных диаграммы по её индексу.
Метод IChartCategoryCollection.RemoveAt(int index) добавлен для удаления категории диаграммы по её индексу.
#### **Значение PptXPptY добавлено в перечисление Aspose.Slides.Animation.PropertyType**
Значение PptXPptY было добавлено в перечисление Aspose.Slides.Animation.PropertyType в рамках исправления проблемы сериализации.
#### **Метод System.Drawing.Color GetAutomaticSeriesColor() добавлен в Aspose.Slides.Charts.IChartSeries**
Метод GetAutomaticSeriesColor возвращает автоматический цвет серии на основе индекса серии и стиля диаграммы. Этот цвет используется по умолчанию, если FillType равно NotDefined.

```csharp
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 50, 600, 400);
    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        chart.ChartData.Series[i].GetAutomaticSeriesColor();
    }
}
```