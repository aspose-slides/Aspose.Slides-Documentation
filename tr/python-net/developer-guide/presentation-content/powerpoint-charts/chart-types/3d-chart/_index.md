---
title: Python ile Sunumlarda 3D Grafikleri Özelleştirme
linktitle: 3D Grafik
type: docs
url: /tr/python-net/3d-chart/
keywords:
- 3D grafik
- döndürme
- derinlik
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET'te 3D grafikler oluşturmayı ve özelleştirmeyi öğrenin, PPT, PPTX ve ODP dosyalarını destekler—sunumlarınızı bugün güçlendirin."
---
## **Overview**

Bu makale, `rotation_3d` ayarları arasında `rotation_x`, `rotation_y`, `depth_percents` ve `right_angle_axes` gibi ayarları yapılandırarak Aspose.Slides içinde bir 3D grafik nasıl özelleştirileceğini açıklar. Bir sunum oluşturmayı, varsayılan veriyle bir 3D grafik eklemeyi, gerekli 3D görünüm ayarlarını uygulamayı ve değiştirilmiş sunumu PPTX dosyası olarak kaydetmeyi adım adım gösterir.

## **Set RotationX, RotationY and DepthPercents properties of 3D Chart**
Aspose.Slides for Python via .NET, bu özellikleri ayarlamak için basit bir API sağlar. Aşağıdaki makale, X,Y Rotasyonu, **DepthPercents** vb. gibi farklı özelliklerin nasıl ayarlanacağını size gösterecektir. Örnek kod, yukarıda belirtilen özelliklerin ayarlanmasını uygular.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının örneğini oluşturun.
1. İlk slayta erişin.
1. Varsayılan veriyle bir grafik ekleyin.
1. Rotation3D özelliklerini ayarlayın.
1. Değiştirilmiş sunumu bir PPTX dosyasına yazın.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Presentation sınıfının bir örneğini oluştur
with slides.Presentation() as presentation:
            
    # İlk slayta eriş
    slide = presentation.slides[0]

    # Varsayılan veriyle grafik ekle
    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN_3D, 0, 0, 500, 500)

    # Grafik veri sayfasının dizinini ayarla
    defaultWorksheetIndex = 0

    # Grafik veri çalışma sayfasını al
    fact = chart.chart_data.chart_data_workbook

    # Seri ekle
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.type)
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.type)

    # Kategorileri ekle
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"))

    # Rotation3D özelliklerini ayarla
    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.rotation_x = 40
    chart.rotation_3d.rotation_y = 270
    chart.rotation_3d.depth_percents = 150

    # İkinci grafik serisini al
    series = chart.chart_data.series[1]

    # Şimdi seri verilerini doldur
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 2, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 2, 10))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 2, 60))

    # Overlap değerini ayarla
    series.parent_series_group.overlap = 100         

    # Sunumu diske kaydet
    presentation.save("Rotation3D_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Aspose.Slides'de hangi grafik türleri 3D modunu destekler?**

Aspose.Slides, Column 3D, Clustered Column 3D, Stacked Column 3D ve %100 Stacked Column 3D gibi sütun grafiklerinin 3D varyantlarını ve [ChartType](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/charttype/) sınıflamasıyla sunulan ilgili 3D tiplerini destekler. Tam ve güncel liste için, yüklü sürümünüzün API referansındaki [ChartType](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/charttype/) üyelerine bakın.

**Bir rapor veya web için bir 3D grafiğin raster görüntüsünü alabilir miyim?**

Evet. Bir grafiği görüntüye [chart API](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chart/get_image/) üzerinden ya da tüm slaytı [render the entire slide](/slides/tr/python-net/convert-powerpoint-to-png/) gibi PNG veya JPEG formatlarına aktarabilirsiniz. Bu, pikselle tam eşleşen bir ön izleme gerektiğinde ya da grafiği PowerPoint gerektirmeden belgeler, gösterge tabloları veya web sayfalarına gömmek istediğinizde faydalıdır.

**Büyük 3D grafikler oluşturma ve renderleme performansı nasıldır?**

Performans, veri hacmi ve görsel karmaşıklığa bağlıdır. En iyi sonuçlar için 3D efektlerini mümkün olduğunca az tutun, duvar ve çizim alanlarında ağır dokulardan kaçının, mümkünse seri başına veri nokta sayısını sınırlayın ve hedef ekrana ya da baskıya uygun çözünürlük ve boyutlarda bir çıktı renderleyin.