---
title: Android'de Sunumlarda Grafik Veri Tablolarını Özelleştirme
linktitle: Veri Tablosu
type: docs
url: /tr/androidjava/chart-data-table/
keywords:
- grafik veri
- veri tablosu
- yazı tipi özellikleri
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android ile Java'da PPT ve PPTX için grafik veri tablolarını özelleştirerek sunumların verimliliğini ve çekiciliğini artırın."
---
## **Genel Bakış**

Bu makale Aspose.Slides'te grafik veri tablolarıyla nasıl çalışılacağını açıklar. Bir grafik için veri tablosu nasıl görüntüleneceğini ve kalın stil ve yazı yüksekliği gibi yazı tipi özelliklerini ayarlayarak metin biçimlendirmesinin nasıl özelleştirileceğini gösterir. Örnek, bir sunumu yüklemeyi, bir grafik eklemeyi, grafik veri tablosunu etkinleştirmeyi, yazı tipi ayarlarını uygulamayı ve güncellenen sunumu kaydetmeyi gösterir.

## **Grafik Veri Tablosu için Yazı Tipi Özelliklerini Ayarlama**
Aspose.Slides for Android via Java, bir serinin renklerindeki kategorilerin rengini değiştirme desteği sağlar.

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıf nesnesini oluşturun.
1. Slayta bir grafik ekleyin.
1. Grafik tablosunu ayarlayın.
1. Yazı yüksekliğini ayarlayın.
1. Değiştirilmiş sunumu kaydedin.

Aşağıda örnek bir örnek verilmektedir.  

```java
// Boş sunum oluşturma
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

**Grafik veri tablosundaki değerlerin yanında küçük lejand anahtarları gösterebilir miyim?**

Evet. Veri tablosu [legend keys](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/datatable/#setShowLegendKey-boolean-) destekler ve bunları açıp kapatabilirsiniz.

**Sunumu PDF, HTML veya görsellere dışa aktarırken veri tablosu korunur mu?**

Evet. Aspose.Slides, grafiği slaytın bir parçası olarak işler, bu yüzden dışa aktarılan [PDF](/slides/tr/androidjava/convert-powerpoint-to-pdf/)/[HTML](/slides/tr/androidjava/convert-powerpoint-to-html/)/[image](/slides/tr/androidjava/convert-powerpoint-to-png/) grafik ve veri tablosunu içerir.

**Şablon dosyasından gelen grafikler için veri tabloları destekleniyor mu?**

Evet. Mevcut bir sunumdan veya şablondan yüklenen herhangi bir grafik için, grafik özelliklerini kullanarak bir veri tablosunun [gösterilip gösterilmediğini](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/chart/#hasDataTable--) kontrol edebilir ve değiştirebilirsiniz.

**Bir dosyadaki hangi grafiklerin veri tablosu etkin olduğunu hızlıca nasıl bulabilirim?**

Veri tablosunun [gösterilip gösterilmediğini](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/chart/#hasDataTable--) gösteren her grafik özelliğini inceleyin ve slaytlar arasında dolaşarak etkin olan grafikleri belirleyin.