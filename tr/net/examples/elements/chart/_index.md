---
title: Grafik
type: docs
weight: 60
url: /tr/net/examples/elements/chart/
keywords:
- grafik
- grafik ekle
- grafiğe eriş
- grafiği kaldır
- grafiği güncelle
- kod örneği
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile grafiklerin ustası olun: grafik oluşturun, biçimlendirin, veri bağlayın ve PPT, PPTX ve ODP formatlarında grafikleri C# örnekleriyle dışa aktarın."
---
Aspose.Slides for .NET ile farklı grafik türlerini ekleme, erişme, kaldırma ve güncelleme örnekleri. Aşağıdaki kod parçacıkları temel grafik işlemlerini gösterir.

## **Grafik Ekle**

Bu yöntem, ilk slayta basit bir alan grafiği ekler.

```csharp
static void AddChart()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // İlk slayta basit bir alan grafiği ekle.
    var chart = slide.Shapes.AddChart(ChartType.Area, 50, 50, 400, 300);
}
```

## **Grafiğe Erişim**

Bir grafik oluşturduktan sonra, şekil koleksiyonu aracılığıyla onu alabilirsiniz.

```csharp
static void AccessChart()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 400, 300);

    // Slayttaki ilk grafiğe eriş.
    var firstChart = slide.Shapes.OfType<IChart>().First();
}
```

## **Grafiği Kaldır**

Aşağıdaki kod, bir slayttan grafiği kaldırır.

```csharp
static void RemoveChart()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 300);

    // Grafiği kaldır.
    slide.Shapes.Remove(chart);
}
```

## **Grafik Verilerini Güncelle**

Başlık gibi grafik özelliklerini değiştirebilirsiniz.

```csharp
static void UpdateChartData()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    var chart = slide.Shapes.AddChart(ChartType.Column3D, 50, 50, 400, 300);

    // Grafik başlığını değiştir.
    chart.ChartTitle.AddTextFrameForOverriding("Sales Report");
}
```