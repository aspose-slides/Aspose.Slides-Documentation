---
title: Grafik
type: docs
weight: 60
url: /tr/cpp/examples/elements/chart/
keywords:
- kod örneği
- grafik
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile grafikleri ustalaştırın: oluşturun, biçimlendirin, veri bağlayın ve grafikleri C++ örnekleriyle PPT, PPTX ve ODP formatlarına dışa aktarın."
---
Aspose.Slides for C++ ile farklı grafik türlerini ekleme, erişme, kaldırma ve güncelleme örnekleri. Aşağıdaki kod parçacıkları temel grafik işlemlerini göstermektedir.

## **Grafik Ekle**

Bu yöntem, ilk slayta basit bir alan grafiği ekler.

```cpp
static void AddChart()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // İlk slayta basit bir alan grafiği ekle.
    auto chart = slide->get_Shapes()->AddChart(ChartType::Area, 50, 50, 400, 300);

    presentation->Dispose();
}
```

## **Grafiğe Eriş**

Bir grafik oluşturduktan sonra, şekil koleksiyonundan onu alabilirsiniz.

```cpp
static void AccessChart()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 50, 50, 400, 300);

    // Slayttaki ilk grafiğe eriş.
    auto firstChart = SharedPtr<IChart>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IChart>(shape))
        {
            firstChart = ExplicitCast<IChart>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```

## **Grafiği Kaldır**

Aşağıdaki kod, bir slayttan grafiği kaldırır.

```cpp
static void RemoveChart()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50, 50, 400, 300);

    // Grafiği kaldır.
    slide->get_Shapes()->Remove(chart);

    presentation->Dispose();
}
```

## **Grafik Verilerini Güncelle**

Başlık gibi grafik özelliklerini değiştirebilirsiniz.

```cpp
static void UpdateChartData()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto chart = slide->get_Shapes()->AddChart(ChartType::Column3D, 50, 50, 400, 300);

    // Grafik başlığını değiştir.
    chart->get_ChartTitle()->AddTextFrameForOverriding(u"Sales Report");

    presentation->Dispose();
}
```