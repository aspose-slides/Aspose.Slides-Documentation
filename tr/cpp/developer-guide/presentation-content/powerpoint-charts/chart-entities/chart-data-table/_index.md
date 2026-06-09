---
title: Sunumlarda С++ Kullanarak Grafik Veri Tablolarını Özelleştirme
linktitle: Veri Tablosu
type: docs
url: /tr/cpp/chart-data-table/
keywords:
- grafik verileri
- veri tablosu
- yazı tipi özellikleri
- PowerPoint
- sunum
- С++
- Aspose.Slides
description: "Aspose.Slides ile PPT ve PPTX için С++'da grafik veri tablolarını özelleştirerek sunumlarda verimliliği ve çekiciliği artırın."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'te grafik veri tabloları ile nasıl çalışılacağını açıklar. Bir grafik için veri tablosunun nasıl görüntüleneceğini ve kalın stil ve font yüksekliği gibi yazı tipi özelliklerini ayarlayarak metin biçimlendirmesinin nasıl özelleştirileceğini gösterir. Örnek, bir sunumu yüklemeyi, bir grafik eklemeyi, grafik veri tablosunu etkinleştirmeyi, yazı tipi ayarlarını uygulamayı ve güncellenmiş sunumu kaydetmeyi gösterir.

## **Bir Grafik Veri Tablosu için Yazı Tipi Özelliklerini Ayarlama**
Aspose.Slides for C++ bir grafik veri tablosu için yazı tipi özelliklerini değiştirmenize olanak tanır.  

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation) sınıfı nesnesini örnekleyin.  
1. Slayta bir grafik ekleyin.  
1. Grafik tablosunu ayarlayın.  
1. Yazı tipi yüksekliğini ayarlayın.  
1. Değiştirilmiş sunumu kaydedin.  

Aşağıda örnek bir kod verilmiştir.  

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
    
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);

chart->set_HasDataTable(true);

chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontBold(NullableBool::True);
chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontHeight(20.0f);

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **SSS**

**Grafiğin veri tablosundaki değerlerin yanında küçük lejant anahtarları gösterebilir miyim?**  
Evet. Veri tablosu [legend keys](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/datatable/set_showlegendkey/) destekler ve bunları açıp kapatabilirsiniz.

**Sunumu PDF, HTML veya görüntülere dışa aktarırken veri tablosu korunur mu?**  
Evet. Aspose.Slides, grafiği slaytın bir parçası olarak render eder, bu yüzden dışa aktarılan [PDF](/slides/tr/cpp/convert-powerpoint-to-pdf/)/[HTML](/slides/tr/cpp/convert-powerpoint-to-html/)/[image](/slides/tr/cpp/convert-powerpoint-to-png/) grafiği veri tablosu ile birlikte içerir.

**Şablon dosyasından gelen grafikler için veri tabloları destekleniyor mu?**  
Evet. Mevcut bir sunumdan veya şablondan yüklenen herhangi bir grafik için, grafik özelliklerini kullanarak veri tablosunun [görünüp görünmediğini](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/chart/set_hasdatatable/) kontrol edebilir ve değiştirebilirsiniz.

**Bir dosyadaki hangi grafiklerin veri tablosunun etkin olduğunu nasıl hızlıca bulabilirim?**  
Veri tablosunun [görünür olup olmadığını](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/chart/get_hasdatatable/) gösteren her bir grafik özelliğine bakın ve slaytlar arasında dolaşarak etkin olan grafikleri belirleyin.