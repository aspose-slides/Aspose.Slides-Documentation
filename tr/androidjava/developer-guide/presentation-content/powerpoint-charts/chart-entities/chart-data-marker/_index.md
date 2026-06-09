---
title: Android'de Sunumlarda Grafik Veri İşaretçilerini Yönet
linktitle: Veri İşaretçisi
type: docs
url: /tr/androidjava/chart-data-marker/
keywords:
- grafik
- veri noktası
- işaretçi
- işaretçi seçenekleri
- işaretçi boyutu
- dolgu tipi
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android'de grafik veri işaretçilerini özelleştirerek, PPT ve PPTX formatlarında sunum etkisini açık Java kod örnekleriyle artırın."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde grafik veri işaretçileriyle nasıl çalışılacağını açıklar. Bir grafik oluşturmayı, bir seriye ve veri noktalarına erişmeyi, veri noktası seviyesinde işaretçilere resim doldurması uygulamayı, işaretçi boyutunu ayarlamayı ve güncellenmiş sunumu kaydetmeyi gösterir. Ayrıca standart işaretçi şekillerinin `MarkerStyleType` sayımı aracılığıyla mevcut olduğu ve grafikler raster formatlarına veya SVG'ye dışa aktarılırken işaretçi görünümünün korunduğu da belirtilir.

## **Grafik İşaretçi Seçeneklerini Ayarla**

İşaretçiler, belirli seriler içindeki grafik veri noktalarına ayarlanabilir. Grafik işaretçi seçeneklerini ayarlamak için aşağıdaki adımları izleyin:

- [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfını örnekleyin.
- Varsayılan grafiği oluşturun.
- Resmi ayarlayın.
- İlk grafik serisini alın.
- Yeni veri noktası ekleyin.
- Sunumu diske yazın.

Aşağıda verilen örnekte, grafik işaretçi seçeneklerini veri noktası seviyesinde ayarladık.

```java
// Boş sunum oluşturuluyor
Presentation pres = new Presentation();
try {
    // İlk slayta eriş
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Varsayılan grafik oluşturuluyor
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 0, 0, 400, 400);
    
    // Varsayılan grafik veri ÇalışmaSayfası dizini alınıyor
    int defaultWorksheetIndex = 0;
    
    // Grafik veri ÇalışmaSayfası alınıyor
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Demo serisi sil
    chart.getChartData().getSeries().clear();
    
    // Yeni seri ekle
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());

    // Resim 1 yükleniyor
    IPPImage imgx1 = pres.getImages().addImage(new FileInputStream(new File("Desert.jpg")));
    
    // Resim 2 yükleniyor
    IPPImage imgx2 = pres.getImages().addImage(new FileInputStream(new File("Tulips.jpg")));
    
    // İlk grafik serisini al
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // Oraya yeni nokta (1:3) ekle.
    IChartDataPoint point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 1, 1, (double) 4.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 2, 1, (double) 2.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 3, 1, (double) 3.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 4, 1, (double) 4.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    
    // Grafik serisi işaretçisini değiştir
    series.getMarker().setSize(15);
    
    // Grafikli sunumu kaydet
    pres.save("ScatterChart.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **SSS**

**Varsayılan olarak hangi işaretçi şekilleri mevcuttur?**

Standart şekiller (daire, kare, elmas, üçgen vb.) mevcuttur; liste [MarkerStyleType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/markerstyletype/) sınıfı tarafından tanımlanır. Standart dışı bir şekle ihtiyacınız varsa, özel görselleri taklit etmek için resim doldurmalı bir işaretçi kullanın.

**Grafiği bir görüntüye veya SVG'ye dışa aktarırken işaretçiler korunur mu?**

Evet. Grafikler [raster formatlarına](/slides/tr/androidjava/convert-powerpoint-to-png/) render edildiğinde veya [şekiller SVG olarak kaydedildiğinde](/slides/tr/androidjava/render-a-slide-as-an-svg-image/), işaretçiler boyut, doldurma ve kontur dahil olmak üzere görünümlerini ve ayarlarını korur.