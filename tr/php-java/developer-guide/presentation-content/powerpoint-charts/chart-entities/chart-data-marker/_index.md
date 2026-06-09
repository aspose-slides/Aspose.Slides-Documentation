---
title: PHP Kullanarak Sunumlarda Grafik Veri İşaretçilerini Yönetme
linktitle: Veri İşaretçisi
type: docs
url: /tr/php-java/chart-data-marker/
keywords:
- grafik
- veri noktası
- işaretçi
- işaretçi seçenekleri
- işaretçi boyutu
- dolgu türü
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP'ta grafik veri işaretçilerini nasıl özelleştireceğinizi öğrenin, net kod örnekleriyle PPT ve PPTX formatlarında sunum etkisini artırın."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'te grafik veri işaretçileriyle nasıl çalışılacağını açıklar. Bir grafik oluşturmayı, bir seriye ve onun veri noktalarına erişmeyi, veri noktası seviyesinde işaretçilere resim doldurma uygulamayı, işaretçi boyutunu ayarlamayı ve güncellenen sunumu kaydetmeyi gösterir. Ayrıca, standart işaretçi şekillerinin `MarkerStyleType` enum aracılığıyla kullanılabilir olduğunu ve grafiklerin raster formatlara veya SVG'ye dışa aktarılırken işaretçi görünümünün korunduğunu belirtir.

## **Grafik İşaretçi Seçeneklerini Ayarlama**
İşaretçiler, belirli serilerdeki grafik veri noktalarına ayarlanabilir. Grafik işaretçi seçeneklerini ayarlamak için aşağıdaki adımları izleyin:

- [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
- Varsayılan grafiği oluşturun.
- Resmi ayarlayın.
- İlk grafik serisini alın.
- Yeni bir veri noktası ekleyin.
- Sunumu diske yazın.

Aşağıdaki örnekte, grafik işaretçi seçeneklerini veri noktası seviyesinde ayarladık.

```php
  # Boş sunum oluşturma
  $pres = new Presentation();
  try {
    # İlk slayta erişme
    $slide = $pres->getSlides()->get_Item(0);
    # Varsayılan grafiği oluşturma
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 0, 0, 400, 400);
    # Varsayılan grafik veri Çalışma Sayfası indeksini alma
    $defaultWorksheetIndex = 0;
    # Grafik veri Çalışma Sayfasını alma
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Demo serisini silme
    $chart->getChartData()->getSeries()->clear();
    # Yeni seri ekleme
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 1, "Series 1"), $chart->getType());
    # Resim 1'i yükleme
    $imgx1 = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "Desert.jpg")));
    # Resim 2'yi yükleme
    $imgx2 = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "Tulips.jpg")));
    # İlk grafik serisini alma
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # Orada yeni nokta (1:3) ekleme.
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 4.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx1);
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 2.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx2);
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 3.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx1);
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 4, 1, 4.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx2);
    # Grafik seri işaretçisini değiştirme
    $series->getMarker()->setSize(15);
    # Grafiği içeren sunumu kaydetme
    $pres->save("ScatterChart.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SSS**

**Hangi işaretçi şekilleri doğrudan mevcuttur?**

Standart şekiller mevcuttur (daire, kare, elmas, üçgen vb.); bu liste [MarkerStyleType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/markerstyletype/) sınıfı tarafından tanımlanır. Standart olmayan bir şekle ihtiyacınız varsa, özel görselleri taklit etmek için resim doldurmalı bir işaretçi kullanın.

**Bir grafik bir görüntüye veya SVG'ye dışa aktarıldığında işaretçiler korunur mu?**

Evet. Grafikler [raster formatlara](/slides/tr/php-java/convert-powerpoint-to-png/) işlenirken veya [şekiller SVG olarak kaydedilirken](/slides/tr/php-java/render-a-slide-as-an-svg-image/), işaretçiler boyut, dolgu ve kontur dahil olmak üzere görünüm ve ayarlarını korur.