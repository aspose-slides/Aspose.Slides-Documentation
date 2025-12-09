---
title: Публичный API и несовместимые изменения в Aspose.Slides для .NET 14.10.0
linktitle: Aspose.Slides для .NET 14.10.0
type: docs
weight: 120
url: /ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/
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
description: "Обзор обновлений публичного API и несовместимых изменений в Aspose.Slides для .NET, позволяющий плавно перенести ваши решения презентаций PowerPoint PPT, PPTX и ODP."
---

{{% alert color="primary" %}} 

На этой странице перечислены все [добавленные](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) или [удалённые](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) классы, методы, свойства и т.д., а также другие изменения, внесённые в API Aspose.Slides для .NET 14.10.0.

{{% /alert %}} 
## **Изменения публичного API**
#### **Тип поля Aspose.Slides.FieldType.Footer был добавлен**
Тип поля Footer был добавлен для реализации возможности создавать поля этого типа и для корректной сериализации презентаций.
#### **Элемент перечисления ShapeElementFillSource.Own был удалён**
Элемент перечисления ShapeElementFillSource.Own был удалён как дублирующий. Вместо ShapeElementFillSource.Own используйте ShapeElementFillSource.Shape.
#### **Добавлены методы для удаления точек данных диаграммы и категорий**
Были добавлены следующие методы, позволяющие удалять точку данных диаграммы из коллекции точек данных:

IChartDataPointCollection.Remove(IChartDataPoint)
IChartDataPoint.Report()

Был добавлен следующий метод, позволяющий удалить категорию диаграммы из содержащей её коллекции:

IChartCategory.Remove()

``` csharp

 using (Presentation pres = new Presentation())

{

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 400, true);

    chart.ChartData.Categories[0].Remove(); //remove with ChartCategory.Remove()

    chart.ChartData.Categories.Remove(chart.ChartData.Categories[0]); //remove with ChartCategoryCollection.Remove()

    foreach (var ser in chart.ChartData.Series)

    {

        ser.DataPoints[0].Remove();//remove with ChartDataPoint.Remove()

        ser.DataPoints.Remove(ser.DataPoints[0]);//ChartDataPointCollection.Remove()

    }

    pres.Save(outPath, SaveFormat.Pptx);

}

``` 
#### **Устаревшие свойства Aspose.Slides.ParagraphFormat были удалены**
Свойства BulletChar, BulletColor, BulletColorFormat, BulletFont, BulletHeight, BulletType, IsBulletHardColor, IsBulletHardFont, NumberedBulletStartWith, NumberedBulletStyle были удалены. Они были помечены как устаревшие давно.
#### **Бесполезные и устаревшие конструкторы были удалены**
Были удалены следующие конструкторы:

- Aspose.Slides.Effects.AlphaBiLevel(System.Single)
- Aspose.Slides.Effects.AlphaModulateFixed(System.Single)
- Aspose.Slides.Effects.AlphaReplace(System.Single)
- Aspose.Slides.Effects.BiLevel(System.Single)
- Aspose.Slides.Effects.Blur(System.Double,System.Boolean)
- Aspose.Slides.Effects.HSL(System.Single,System.Single,System.Single)
- Aspose.Slides.Effects.ImageTransformOperation(Aspose.Slides.Effects.ImageTransformOperationCollection)
- Aspose.Slides.Effects.Luminance(System.Single,System.Single)
- Aspose.Slides.Effects.Tint(System.Single,System.Single)
- Aspose.Slides.PortionFormat(Aspose.Slides.ParagraphFormat)
- Aspose.Slides.PortionFormat(Aspose.Slides.Portion)
- Aspose.Slides.PortionFormat(Aspose.Slides.PortionFormat)