---
title: JavaScript Kullanarak Sunumlarda Grafik Veri İşaretçilerini Yönetme
linktitle: Veri İşaretçisi
type: docs
url: /tr/nodejs-java/chart-data-marker/
keywords:
- grafik
- veri noktası
- işaretçi
- işaretçi seçenekleri
- işaretçi boyutu
- doldurma tipi
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js içinde grafik veri işaretçilerini nasıl özelleştireceğinizi öğrenin, net kod örnekleriyle PPT ve PPTX formatlarında sunum etkisini artırın."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'te grafik veri işaretçileriyle nasıl çalışılacağını açıklar. Bir grafik oluşturmayı, bir seriye ve veri noktalarına erişmeyi, veri noktası seviyesinde işaretçilere resim doldurması uygulamayı, işaretçi boyutunu ayarlamayı ve güncellenmiş sunumu kaydetmeyi gösterir. Ayrıca, standart işaretçi şekillerinin `MarkerStyleType` enumarasyonu aracılığıyla mevcut olduğunu ve işaretçi görünümünün grafiklerin raster formatlarına veya SVG'ye dışa aktarılırken korunduğunu belirtir.

## **Grafik İşaretçi Seçeneklerini Ayarlama**

İşaretçiler, belirli seriler içinde grafik veri noktalarına ayarlanabilir. Grafik işaretçi seçeneklerini ayarlamak için lütfen aşağıdaki adımları izleyin:

- Bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfı örnekleyin.
- Varsayılan grafiği oluşturun.
- Resmi ayarlayın.
- İlk grafik serisini alın.
- Yeni bir veri noktası ekleyin.
- Sunumu diske yazın.

Aşağıda verilen örnekte, grafik işaretçi seçeneklerini veri noktası seviyesinde ayarladık.

```javascript
// Boş sunum oluşturma
var pres = new aspose.slides.Presentation();
try {
    // İlk slayta eriş
    var slide = pres.getSlides().get_Item(0);
    // Varsayılan grafiği oluşturma
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 0, 0, 400, 400);
    // Varsayılan grafik veri Çalışma Sayfası dizinini alma
    var defaultWorksheetIndex = 0;
    // Grafik veri Çalışma Sayfasını alma
    var fact = chart.getChartData().getChartDataWorkbook();
    // Demo serisini sil
    chart.getChartData().getSeries().clear();
    // Yeni seri ekle
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    // Resim 1'i yükle
    var imgx1 = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "Desert.jpg")));
    // Resim 2'yi yükle
    var imgx2 = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "Tulips.jpg")));
    // İlk grafik serisini al
    var series = chart.getChartData().getSeries().get_Item(0);
    // Orada yeni nokta ekle (1:3).
    var point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 4.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 2.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 3.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 4, 1, 4.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    // Grafik serisi işaretçisini değiştir
    series.getMarker().setSize(15);
    // Grafikli sunumu kaydet
    pres.save("ScatterChart.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **SSS**

**Varsayılan olarak hangi işaretçi şekilleri mevcuttur?**

Standart şekiller mevcuttur (daire, kare, elmas, üçgen vb.); liste [MarkerStyleType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/markerstyletype/) enumarasyonu ile tanımlanır. Standart olmayan bir şekle ihtiyacınız varsa, özel görselleri taklit etmek için resim doldurmalı bir işaretçi kullanın.

**Bir grafiği resim veya SVG olarak dışa aktarırken işaretçiler korunur mu?**

Evet. Grafikler [raster formatlarına](/slides/tr/nodejs-java/convert-powerpoint-to-png/) render edildiğinde veya [şekiller SVG olarak kaydedildiğinde](/slides/tr/nodejs-java/render-a-slide-as-an-svg-image/), işaretçiler boyut, dolgu ve kenar gibi görünüm ve ayarlarını korur.