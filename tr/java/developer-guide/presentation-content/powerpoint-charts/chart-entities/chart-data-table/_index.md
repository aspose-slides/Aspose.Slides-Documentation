---
title: Java Kullanarak Sunumlarda Grafik Veri Tablolarını Özelleştirme
linktitle: Veri Tablosu
type: docs
url: /tr/java/chart-data-table/
keywords:
- grafik verisi
- veri tablosu
- yazı tipi özellikleri
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides ile PPT ve PPTX için Java’da grafik veri tablolarını özelleştirerek sunumlarda verimliliği ve çekiciliği artırın."
---
## **Genel Bakış**

Bu makale Aspose.Slides içinde grafik veri tabloları ile nasıl çalışılacağını açıklar. Bir grafik için veri tablosunun nasıl görüntüleneceğini ve kalın stil ve yazı tipi yüksekliği gibi yazı tipi özelliklerini ayarlayarak metin biçimlendirmesinin nasıl özelleştirileceğini gösterir. Örnek, bir sunumu yüklemeyi, bir grafik eklemeyi, grafik veri tablosunu etkinleştirmeyi, yazı tipi ayarlarını uygulamayı ve güncellenmiş sunumu kaydetmeyi göstermektedir.

Ayrıca, bir grafik veri tablosunda lejand anahtarlarını gösterme, dışa aktarma sırasında veri tablosunu koruma, mevcut sunumlardan veya şablonlardan yüklenen grafiklerle çalışma ve veri tablosunun etkin olduğu grafikleri belirleme konularında yaygın sorulara kısa cevaplar da içerir.

## **Bir Grafik Veri Tablosu için Yazı Tipi Özelliklerini Ayarlama**
Aspose.Slides for Java, bir serideki kategori renklerini değiştirme desteği sağlar.  

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıf nesnesini oluşturun.  
1. Slayta bir grafik ekleyin.  
1. Grafik tablosunu ayarlayın.  
1. Yazı tipi yüksekliğini ayarlayın.  
1. Değiştirilmiş sunumu kaydedin.  

Aşağıda örnek bir örnek verilmiştir.  

```java
// Boş bir sunum oluşturma
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.setDataTable(true);

    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontBold(NullableBool.True);
    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontHeight(20);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SSS**

**Grafiğin veri tablosundaki değerlerin yanına küçük lejand anahtarları gösterebilir miyim?**

Evet. Veri tablosu [lejant anahtarları](https://reference.aspose.com/slides/tr/java/com.aspose.slides/datatable/#setShowLegendKey-boolean-) destekler ve bunları açıp kapatabilirsiniz.

**Sunumu PDF, HTML veya görüntülere dışa aktarırken veri tablosu korunacak mı?**

Evet. Aspose.Slides, grafiği slaytın bir parçası olarak işler, bu nedenle dışa aktarılan [PDF](/slides/tr/java/convert-powerpoint-to-pdf/)/[HTML](/slides/tr/java/convert-powerpoint-to-html/)/[image](/slides/tr/java/convert-powerpoint-to-png/) grafiği veri tablosu ile birlikte içerir.

**Şablon dosyasından gelen grafikler için veri tabloları destekleniyor mu?**

Evet. Mevcut bir sunumdan veya şablondan yüklenen herhangi bir grafik için, grafik özelliklerini kullanarak veri tablosunun [gösterilip gösterilmediğini] kontrol edebilir ve değiştirebilirsiniz.

**Bir dosyadaki hangi grafiklerin veri tablosunun etkin olduğunu hızlıca nasıl bulabilirim?**

Veri tablosunun [gösterilip gösterilmediğini] belirten her bir grafiğin özelliğini inceleyin ve slaytlar arasında dolaşarak veri tablosunun etkin olduğu grafikleri belirleyin.