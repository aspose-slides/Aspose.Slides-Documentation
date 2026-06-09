---
title: Sunumlarda JavaScript Kullanarak Grafik Veri Tablolarını Özelleştirme
linktitle: Veri Tablosu
type: docs
url: /tr/nodejs-java/chart-data-table/
keywords:
- grafik verisi
- veri tablosu
- yazı tipi özellikleri
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java ile PPT ve PPTX için JavaScript kullanarak grafik veri tablolarını özelleştirerek sunumlarda verimliliği ve çekiciliği artırın."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde grafik veri tablolarıyla nasıl çalışılacağını açıklar. Bir grafik için veri tablosunun nasıl görüntüleneceğini ve kalın stil ve yazı yüksekliği gibi yazı tipi özelliklerini ayarlayarak metin biçimlendirmesinin nasıl özelleştirileceğini gösterir. Örnek, bir sunumu yüklemeyi, bir grafik eklemeyi, grafik veri tablosunu etkinleştirmeyi, yazı tipi ayarlarını uygulamayı ve güncellenen sunumu kaydetmeyi gösterir.

Ayrıca, grafik veri tablosunda gösterge anahtarlarını gösterme, dışa aktarım sırasında veri tablosunu koruma, mevcut sunumlardan veya şablonlardan yüklenen grafiklerle çalışma ve veri tablosunun etkin olduğu grafikleri belirleme gibi yaygın sorulara kısa yanıtlar içerir.

## **Grafik Veri Tablosu için Yazı Tipi Özelliklerini Ayarlama**

Aspose.Slides for Node.js via Java, bir seri rengindeki kategorilerin rengini değiştirme desteği sağlar.

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfı nesnesi oluşturun.
1. Slayta bir grafik ekleyin.
1. Grafik tablosunu ayarlayın.
1. Yazı tipi yüksekliğini ayarlayın.
1. Değiştirilmiş sunumu kaydedin.

Aşağıda örnek bir örnek verilmiştir.

```javascript
// Boş sunum oluşturma
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);
    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontHeight(20);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **SSS**

**Grafiğin veri tablosundaki değerlerin yanında küçük gösterge anahtarlarını gösterebilir miyim?**

Evet. Veri tablosu [gösterge anahtarlarını](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/datatable/setshowlegendkey/) destekler ve bunları açıp kapatabilirsiniz.

**Sunumu PDF, HTML veya görüntülere dışa aktarırken veri tablosu korunur mu?**

Evet. Aspose.Slides, grafiği slaytın bir parçası olarak işler, bu nedenle dışa aktarılan [PDF](/slides/tr/nodejs-java/convert-powerpoint-to-pdf/)/[HTML](/slides/tr/nodejs-java/convert-powerpoint-to-html/)/[image](/slides/tr/nodejs-java/convert-powerpoint-to-png/) grafiği veri tablosuyla birlikte içerir.

**Şablon dosyasından gelen grafikler için veri tabloları destekleniyor mu?**

Evet. Mevcut bir sunumdan veya şablondan yüklenen herhangi bir grafik için, grafik özelliklerini kullanarak bir veri tablosunun [gösterilip gösterilmediğini](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chart/hasdatatable/) kontrol edebilir ve değiştirebilirsiniz.

**Bir dosyada hangi grafiklerin veri tablosunun etkin olduğunu hızlıca nasıl bulabilirim?**

Veri tablosunun [gösterilip gösterilmediğini](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chart/hasdatatable/) gösteren her bir grafik özelliğini inceleyin ve slaytlar arasında gezerek etkin olan grafikleri belirleyin.