---
title: PHP ile Sunumlarda Grafik Veri Tablolarını Özelleştirme
linktitle: Veri Tablosu
type: docs
url: /tr/php-java/chart-data-table/
keywords:
- grafik veri
- veri tablosu
- yazı tipi özellikleri
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java ile PPT ve PPTX için grafik veri tablolarını özelleştirerek sunumlarda verimliliği ve çekiciliği artırın."
---
## **Genel Bakış**

Bu makale Aspose.Slides'te grafik veri tablolarıyla nasıl çalışılacağını açıklar. Bir grafik için veri tablosu nasıl görüntülenir ve kalın stil ve yazı yüksekliği gibi yazı tipi özellikleri ayarlanarak metin biçimlendirmesi nasıl özelleştirilir gösterir. Örnek, bir sunumu yüklemeyi, bir grafik eklemeyi, grafik veri tablosunu etkinleştirmeyi, yazı tipi ayarlarını uygulamayı ve güncellenmiş sunumu kaydetmeyi demonstr eder.

Ayrıca, bir grafik veri tablosunda gösterge anahtarlarını gösterme, veri tablosunun dışa aktarım sırasında korunması, mevcut bir sunumdan veya şablondan yüklenen grafiklerle çalışılması ve veri tablosu etkinleştirilmiş grafiklerin belirlenmesi konularında yaygın sorulara kısa yanıtlar içerir.

## **Bir Grafik Veri Tablosu İçin Yazı Tipi Özelliklerini Ayarlama**
Aspose.Slides for PHP via Java, bir serideki kategorilerin rengini değiştirme desteği sağlar. 

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfı nesnesini oluşturun.
1. Slayta bir grafik ekleyin.
1. grafik tablosunu ayarlayın.
1. Yazı tipi yüksekliğini belirleyin.
1. Değiştirilmiş sunumu kaydedin.

Aşağıda örnek bir örnek verilmiştir. 

```php
  # Boş sunum oluşturma
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);
    $chart->getChartDataTable()->getTextFormat()->getPortionFormat()->setFontBold(NullableBool::True);
    $chart->getChartDataTable()->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SSS**

**Grafiğin veri tablosundaki değerlerin yanında küçük gösterge anahtarları gösterebilir miyim?**

Evet. Veri tablosu [gösterge anahtarlarını](https://reference.aspose.com/slides/tr/php-java/aspose.slides/datatable/setshowlegendkey/) destekler ve bunları açıp kapatabilirsiniz.

**Sunum PDF, HTML veya görüntülere dışa aktarıldığında veri tablosu korunur mu?**

Evet. Aspose.Slides, grafiği slaytın bir parçası olarak işler; bu nedenle dışa aktarılan [PDF](/slides/tr/php-java/convert-powerpoint-to-pdf/)/[HTML](/slides/tr/php-java/convert-powerpoint-to-html/)/[görüntü](/slides/tr/php-java/convert-powerpoint-to-png/) içinde grafik ve veri tablosu yer alır.

**Şablon dosyasından gelen grafikler için veri tabloları destekleniyor mu?**

Evet. Mevcut bir sunumdan veya şablondan yüklenen herhangi bir grafik için, grafiğin özelliklerini kullanarak veri tablosunun [gösterilip gösterilmediğini](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chart/hasdatatable/) kontrol edebilir ve değiştirebilirsiniz.

**Bir dosyada hangi grafiklerin veri tablosunun etkin olduğunu nasıl hızlıca bulabilirim?**

Veri tablosunun [gösterilip gösterilmediğini](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chart/hasdatatable/) belirten her bir grafiğin özelliğini inceleyin ve slaytlar arasında döngü yaparak etkinleştirilmiş grafikleri tespit edin.