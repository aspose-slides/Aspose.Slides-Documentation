---
title: Grafik
type: docs
weight: 60
url: /tr/python-net/examples/elements/chart/
keywords:
- grafik
- grafik ekle
- grafiğe eriş
- grafiği kaldır
- grafiği güncelle
- kod örnekleri
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides ile Python'da grafik oluşturun ve özelleştirin: veri ekleyin, serileri, eksenleri ve etiketleri biçimlendirin, türleri değiştirin ve dışa aktarın—PPT, PPTX ve ODP ile çalışır."
---
Farklı grafik türlerini ekleme, erişme, kaldırma ve güncelleme örnekleri **Aspose.Slides for Python via .NET** ile. Aşağıdaki kod parçacıkları temel grafik işlemlerini göstermektedir.

## **Grafik Ekle**

Bu yöntem, ilk slayta basit bir alan grafiği ekler.

```py
def add_chart():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # İlk slayta basit bir sütun grafiği ekleyin.
        chart = slide.shapes.add_chart(slides.charts.ChartType.AREA, 50, 50, 400, 300)

        presentation.save("chart.pptx", slides.export.SaveFormat.PPTX)
```

## **Grafiğe Eriş**

Aşağıdaki kod, şekil koleksiyonundan bir grafik alır.

```py
def access_chart():
    with slides.Presentation("chart.pptx") as presentation:
        slide = presentation.slides[0]

        # Slayttaki ilk grafiğe erişin.
        first_chart = None
        for shape in slide.shapes:
            if isinstance(shape, slides.charts.Chart):
                first_chart = shape
                break
```

## **Grafiği Kaldır**

Aşağıdaki kod, bir slayttan grafiği kaldırır.

```py
def remove_chart():
    with slides.Presentation("chart.pptx") as presentation:
        slide = presentation.slides[0]

        # İlk şeklin bir grafik olduğunu varsayarak.
        chart = slide.shapes[0]

        # Grafiği kaldır.
        slide.shapes.remove(chart)

        presentation.save("chart_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Grafik Verilerini Güncelle**

Grafik özelliklerini, örneğin başlığı, değiştirebilirsiniz.

```py
def update_chart_data():
    with slides.Presentation("chart.pptx") as presentation:
        slide = presentation.slides[0]

        # İlk şeklin bir grafik olduğunu varsayarak.
        chart = slide.shapes[0]

        # Grafik başlığını değiştir.
        chart.chart_title.add_text_frame_for_overriding("Sales Report")

        presentation.save("chart_updated.pptx", slides.export.SaveFormat.PPTX)
```