---
title: Публичный API и изменения, несовместимые с предыдущими версиями в Aspose.Slides для .NET 14.10.0
type: docs
weight: 120
url: /net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/
---

{{% alert color="primary" %}} 

Эта страница содержит список всех [добавленных](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) или [удаленных](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) классов, методов, свойств и так далее, а также других изменений, внесенных в API Aspose.Slides для .NET 14.10.0.

{{% /alert %}} 
## **Изменения публичного API**
#### **Тип поля Aspose.Slides.FieldType.Footer был добавлен**
Тип поля Footer был добавлен для реализации возможности создания полей этого типа и для корректной сериализации презентаций.
#### **Элемент перечисления ShapeElementFillSource.Own был удален**
Элемент перечисления ShapeElementFillSource.Own был удален как дублирующий. Используйте ShapeElementFillSource.Shape вместо ShapeElementFillSource.Own.
#### **Добавлены методы для удаления данных точек графика и категорий**
Добавлены следующие методы, которые позволяют удалять точки данных графика из коллекции точек данных графика:

IChartDataPointCollection.Remove(IChartDataPoint)
IChartDataPoint.Report()

Добавлен следующий метод, который позволяет удалить категорию графика из содержащей коллекции:

IChartCategory.Remove()

``` csharp

 using (Presentation pres = new Presentation())

{

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 400, true);

    chart.ChartData.Categories[0].Remove(); //удалить с ChartCategory.Remove()

    chart.ChartData.Categories.Remove(chart.ChartData.Categories[0]); //удалить с ChartCategoryCollection.Remove()

    foreach (var ser in chart.ChartData.Series)

    {

        ser.DataPoints[0].Remove();//удалить с ChartDataPoint.Remove()

        ser.DataPoints.Remove(ser.DataPoints[0]);//ChartDataPointCollection.Remove()

    }

    pres.Save(outPath, SaveFormat.Pptx);

}

``` 
#### **Устаревшие свойства Aspose.Slides.ParagraphFormat были удалены**
Свойства BulletChar, BulletColor, BulletColorFormat, BulletFont, BulletHeight, BulletType, IsBulletHardColor, IsBulletHardFont, NumberedBulletStartWith, NumberedBulletStyle были удалены. Они были отмечены как устаревшие давно.
#### **Удалены ненужные и устаревшие конструкторы**
Удалены следующие конструкторы:

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