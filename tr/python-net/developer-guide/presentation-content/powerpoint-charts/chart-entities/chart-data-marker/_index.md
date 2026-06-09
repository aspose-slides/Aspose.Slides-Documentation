---
title: Sunumlarda Python ile Grafik Veri İşaretçilerini Yönetme
linktitle: Veri İşaretçisi
type: docs
url: /tr/python-net/chart-data-marker/
keywords:
- grafik
- veri noktası
- işaretçi
- işaretçi seçenekleri
- işaretçi boyutu
- dolgu türü
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides içinde grafik veri işaretçilerini nasıl özelleştireceğinizi öğrenin, PPT, PPTX ve ODP formatlarında net kod örnekleriyle sunum etkisini artırın."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde grafik veri işaretçileriyle nasıl çalışılacağını açıklar. Bir grafik oluşturmayı, bir seriye ve onun veri noktalarına erişmeyi, veri noktası düzeyinde işaretçilere resim dolguları uygulamayı, işaretçi boyutunu ayarlamayı ve güncellenmiş sunumu kaydetmeyi gösterir. Ayrıca, standart işaretçi şekillerinin `MarkerStyleType` enum'ı aracılığıyla mevcut olduğunu ve işaretçi görünümünün grafiklerin raster formatlarına veya SVG'ye aktarılırken korunduğunu belirtir.

## **Grafik İşaretçi Seçeneklerini Ayarlama**
İşaretçiler, belirli bir serideki grafik veri noktalarına ayarlanabilir. Grafik işaretçi seçeneklerini ayarlamak için lütfen aşağıdaki adımları izleyin:

- Presentation sınıfını örnekleyin.
- Varsayılan grafiği oluşturun.
- Resmi ayarlayın.
- İlk grafik serisini alın.
- Yeni bir veri noktası ekleyin.
- Sunumu diske yazın.

Aşağıda verilen örnekte, grafik işaretçi seçeneklerini veri noktası seviyesinde ayarladık.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Presentation sınıfının bir örneğini oluştur
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    # Varsayılan grafiği oluşturma
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 0, 0, 400, 400)

    # Varsayılan grafik veri çalışma sayfası indeksini alma
    defaultWorksheetIndex = 0

    # Grafik veri çalışma sayfasını alma
    fact = chart.chart_data.chart_data_workbook

    # Demo serisini sil
    chart.chart_data.series.clear()

    # Yeni seri ekle
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.type)
            
    # Resmi ayarla
    image1 = draw.Bitmap(path + "aspose-logo.jpg")
    imgx1 = presentation.images.add_image(image1)

    # Resmi ayarla
    image2 = draw.Bitmap(path + "Tulips.jpg")
    imgx2 = presentation.images.add_image(image2)

    # İlk grafik serisini al
    series = chart.chart_data.series[0]

    # Oraya yeni nokta (1:3) ekle.
    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 4.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx1

    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 2.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx2

    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 3.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx1

    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 4, 1, 4.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx2

    # Grafik serisi işaretçisini değiştirme
    series.marker.size = 15

    # Sunumu diske kaydet
    presentation.save("MarkOptions_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Varsayılan olarak hangi işaretçi şekilleri mevcuttur?**

Standart şekiller (daire, kare, elmas, üçgen vb.) mevcuttur; liste [MarkerStyleType](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/markerstyletype/) enum'ı tarafından tanımlanır. Özel bir şekle ihtiyacınız varsa, özel görselleri taklit etmek için resim dolgulu bir işaretçi kullanın.

**Bir grafiği resim veya SVG olarak dışa aktarırken işaretçiler korunur mu?**

Evet. Grafikler [raster formatlarına](/slides/tr/python-net/convert-powerpoint-to-png/) render edildiğinde veya [şekiller SVG olarak kaydedildiğinde](/slides/tr/python-net/render-a-slide-as-an-svg-image/), işaretçiler boyut, dolgu ve kontur dahil görünüm ve ayarlarını korur.