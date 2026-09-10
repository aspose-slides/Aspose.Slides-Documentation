---
title: Sunumlarda Python Kullanarak Grafik Veri İşaretçilerini Yönetme
linktitle: Veri İşaretçisi
type: docs
url: /tr/python-java/chart-data-marker/
keywords:
- grafik
- veri noktası
- işaretçi
- işaretçi seçenekleri
- işaretçi boyutu
- doldurma türü
- PowerPoint
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java'da grafik veri işaretçilerini nasıl özelleştireceğinizi öğrenin, PPT ve PPTX formatlarında sunum etkisini artıran net Python kod örnekleriyle."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde grafik veri işaretçileriyle nasıl çalışılacağını açıklar. Bir grafik oluşturmayı, bir seriye ve onun veri noktalarına erişmeyi, veri noktası seviyesinde işaretçilere resim doldurması uygulamayı, işaretçi boyutunu ayarlamayı ve güncellenen sunumu kaydetmeyi gösterir. Ayrıca, standart işaretçi şekillerinin [MarkerStyleType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/markerstyletype/) sayımı aracılığıyla mevcut olduğu ve grafikler raster formatlara veya SVG'ye dışa aktarılırken işaretçi görünümünün korunduğu belirtilir.

## **Grafik İşaretçi Seçeneklerini Ayarlama**
İşaretçiler belirli bir serideki grafik veri noktalarına ayarlanabilir. Grafik işaretçi seçeneklerini ayarlamak için şu adımları izleyin:

- Presentation sınıfının bir örneğini oluşturun.
- Varsayılan grafiği oluşturun.
- Resimleri ayarlayın.
- İlk grafik serisine erişin.
- Yeni veri noktaları ekleyin.
- Sunumu diske yazın.

Aşağıdaki örnek, veri noktası seviyesinde grafik işaretçi seçeneklerini ayarlar.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

# Boş bir sunum oluştur.
presentation = Presentation()
try:
    # İlk slayta eriş
    slide = presentation.getSlides().get_Item(0)

    # Varsayılan grafiği oluşturma
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 0, 0, 400, 400)

    # Varsayılan grafik veri çalışma sayfası dizinini al.
    default_worksheet_index = 0

    # Grafik veri çalışma kitabını al.
    workbook = chart.getChartData().getChartDataWorkbook()

    # Demo serisini sil
    chart.getChartData().getSeries().clear()

    # Yeni seri ekle
    series_name_cell = workbook.getCell(default_worksheet_index, 1, 1, "Series 1")
    chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    # İlk fotoğrafı yükle.
    desert_bytes = Path("Desert.jpg").read_bytes()
    desert_image = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(desert_bytes))

    # İkinci fotoğrafı yükle.
    tulips_bytes = Path("Tulips.jpg").read_bytes()
    tulips_image = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(tulips_bytes))

    # İlk grafik serisine eriş.
    series = chart.getChartData().getSeries().get_Item(0)

    # Veri noktaları ekle.
    value_cell = workbook.getCell(default_worksheet_index, 1, 1, 4.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(desert_image)

    value_cell = workbook.getCell(default_worksheet_index, 2, 1, 2.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(tulips_image)

    value_cell = workbook.getCell(default_worksheet_index, 3, 1, 3.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(desert_image)

    value_cell = workbook.getCell(default_worksheet_index, 4, 1, 4.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(tulips_image)

    # Grafik serisi işaretçi boyutunu değiştir.
    series.getMarker().setSize(15)

    # Grafikli sunumu kaydet
    presentation.save("MarkOptions_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **SSS**

**Kutudan çıktığı gibi hangi işaretçi şekilleri mevcuttur?**

Standart şekiller mevcuttur (daire, kare, elmas, üçgen vb.); liste [MarkerStyleType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/markerstyletype/) sınıfı tarafından tanımlanmıştır. Standart olmayan bir şekle ihtiyacınız varsa, özel görselleri taklit etmek için resim doldurmalı bir işaretçi kullanın.

**Bir grafiği görüntü veya SVG olarak dışa aktarırken işaretçiler korunur mu?**

Evet. Grafikleri [raster formatlarda](/slides/tr/python-java/convert-powerpoint-to-png/) işlediğinizde veya [şekilleri SVG olarak kaydederken](/slides/tr/python-java/render-a-slide-as-an-svg-image/), işaretçiler boyut, doldurma ve dış hat dahil görünüm ve ayarlarını korur.