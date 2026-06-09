---
title: Java Kullanarak Sunumlarda Grafik Veri İşaretçilerini Yönetme
linktitle: Veri İşaretleyici
type: docs
url: /tr/java/chart-data-marker/
keywords:
- grafik
- veri noktası
- işaretçi
- işaretçi seçenekleri
- işaretçi boyutu
- dolgu türü
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java’da grafik veri işaretçilerini özelleştirmeyi öğrenin, net Java kod örnekleriyle PPT ve PPTX formatlarında sunum etkisini artırın."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'ta grafik veri işaretçileriyle nasıl çalışılacağını açıklar. Bir grafik oluşturmayı, bir seriye ve onun veri noktalarına erişmeyi, veri noktası seviyesinde işaretçilere resim dolgu uygulamayı, işaretçi boyutunu ayarlamayı ve güncellenmiş sunumu kaydetmeyi gösterir. Ayrıca, standart işaretçi biçimlerinin `MarkerStyleType` enum'ı aracılığıyla mevcut olduğu ve grafiklerin raster formatlarına veya SVG'ye dışa aktarılırken işaretçi görünümünün korunduğu belirtilir.

## **Grafik İşaretçi Seçeneklerini Ayarlama**
İşaretçiler, belirli serilerdeki grafik veri noktalarına ayarlanabilir. Grafik işaretçi seçeneklerini ayarlamak için aşağıdaki adımları izleyin:

- Presentation sınıfının bir örneğini oluşturun.  
- Varsayılan grafiği oluşturun.  
- Resmi ayarlayın.  
- İlk grafik serisini alın.  
- Yeni bir veri noktası ekleyin.  
- Sunumu diske yazın.

Aşağıda verilen örnekte, grafik işaretçi seçeneklerini veri noktası seviyesinde ayarladık.

```java
    // Boş sunum oluşturma
    Presentation pres = new Presentation();
    try {
        // İlk slayta eriş
        ISlide slide = pres.getSlides().get_Item(0);
        
        // Varsayılan grafik oluşturma
        IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 0, 0, 400, 400);
        
        // Varsayılan grafik veri Çalışma Sayfası indeksini alma
        int defaultWorksheetIndex = 0;
        
        // Grafik veri Çalışma Sayfasını alma
        IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
        
        // Demo serisini sil
        chart.getChartData().getSeries().clear();
        
        // Yeni seri ekle
        chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());

        // Resim 1'i yükle
        IPPImage imgx1 = pres.getImages().addImage(new FileInputStream(new File("Desert.jpg")));
        
        // Resim 2'yi yükle
        IPPImage imgx2 = pres.getImages().addImage(new FileInputStream(new File("Tulips.jpg")));
        
        // İlk grafik serisini al
        IChartSeries series = chart.getChartData().getSeries().get_Item(0);
        
        // Orada yeni nokta (1:3) ekle.
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
        
        // Grafik serisi işaretçisini değiştirme
        series.getMarker().setSize(15);
        
        // Grafikli sunumu kaydet
        pres.save("ScatterChart.pptx", SaveFormat.Pptx);
    } catch (IOException e) {
    } finally {
        if (pres != null) pres.dispose();
    }
```

## **SSS**

**Hangi işaretçi şekilleri kutudan çıktığı gibi mevcuttur?**

Standart şekiller mevcuttur (daire, kare, elmas, üçgen vb.); liste [MarkerStyleType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/markerstyletype/) sınıfı tarafından tanımlanır. Standart dışı bir şekle ihtiyacınız varsa, özel görselleri taklit etmek için resim dolgulu bir işaretçi kullanın.

**Bir grafiği görüntüye veya SVG'ye dışa aktarırken işaretçiler korunur mu?**

Evet. Grafikler [raster formatlarına](/slides/tr/java/convert-powerpoint-to-png/) işlenirken veya [şekiller SVG olarak kaydedilirken](/slides/tr/java/render-a-slide-as-an-svg-image/), işaretçiler boyut, dolgu ve kontur dahil olmak üzere görünüm ve ayarlarını korur.