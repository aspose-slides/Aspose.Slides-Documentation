---
title: C++ Kullanarak Sunumlarda Grafik Veri Tablolarını Özelleştirme
linktitle: Veri Tablosu
type: docs
url: /tr/cpp/chart-data-table/
keywords:
- grafik verisi
- veri tablosu
- yazı tipi özellikleri
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides ile PPT ve PPTX için C++ kullanarak grafik veri tablolarını özelleştirerek sunumlarda verimliliği ve çekiciliği artırın."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde grafik veri tabloları ile nasıl çalışılacağını açıklar. Bir grafik için veri tablosu nasıl görüntülenir ve kalın stil ve yazı yüksekliği gibi yazı tipi özellikleri ayarlanarak metin biçimlendirmesi nasıl özelleştirilir gösterir. Örnek, bir sunumun yüklenmesini, bir grafik eklenmesini, grafik veri tablosunun etkinleştirilmesini, yazı tipi ayarlarının uygulanmasını ve güncellenmiş sunumun kaydedilmesini gösterir.

## **Bir Grafik Veri Tablosu için Yazı Tipi Özelliklerini Ayarlama**
Aspose.Slides for C++ bir grafik veri tablosu için yazı tipi özelliklerini değiştirmenize izin verir.  

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation) sınıf nesnesi oluşturun.  
1. Slayta bir grafik ekleyin.  
1. Grafik tablosunu ayarlayın.  
1. Yazı tipi yüksekliğini ayarlayın.  
1. Değiştirilmiş sunumu kaydedin.  

Aşağıda örnek bir kod örneği verilmiştir.  

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
    
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);

chart->set_HasDataTable(true);

chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontBold(NullableBool::True);
chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontHeight(20.0f);

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **SSS**

**Grafiğin veri tablosundaki değerlere küçük gösterge anahtarları ekleyebilir miyim?**

Evet. Veri tablosu [gösterge anahtarlarını](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/datatable/set_showlegendkey/) destekler ve bunları açıp kapatabilirsiniz.

**Sunumu PDF, HTML veya görüntülere dışa aktarırken veri tablosu korunur mu?**

Evet. Aspose.Slides grafik’i slaytın bir parçası olarak işler, böylece dışa aktarılan [PDF](/slides/tr/cpp/convert-powerpoint-to-pdf/)/[HTML](/slides/tr/cpp/convert-powerpoint-to-html/)/[image](/slides/tr/cpp/convert-powerpoint-to-png/) grafiği veri tablosu ile birlikte içerir.

**Şablon dosyasından gelen grafikler için veri tabloları destekleniyor mu?**

Evet. Mevcut bir sunum veya şablondan yüklenen herhangi bir grafik için, grafik özelliklerini kullanarak bir veri tablosunun [gösterilip gösterilmediğini](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/chart/set_hasdatatable/) kontrol edebilir ve değiştirebilirsiniz.

**Bir dosyadaki hangi grafiklerin veri tablosu etkin olduğunu hızlıca nasıl bulabilirim?**

Veri tablosunun [gösterilip gösterilmediğini](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/chart/get_hasdatatable/) belirten her grafik özelliğine bakın ve slaytlar arasında dolaşarak etkin olan grafikleri tespit edin.