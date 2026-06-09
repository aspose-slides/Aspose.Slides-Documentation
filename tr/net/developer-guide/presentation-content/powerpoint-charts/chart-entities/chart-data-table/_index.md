---
title: Sunumlarda .NET ile Grafik Veri Tablolarını Özelleştirme
linktitle: Veri Tablosu
type: docs
url: /tr/net/chart-data-table/
keywords:
- grafik verileri
- veri tablosu
- yazı tipi özellikleri
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides ile .NET'te PPT ve PPTX için grafik veri tablolarını özelleştirerek sunumlarda verimliliği ve çekiciliği artırın."
---
## **Overview**

Bu makale, Aspose.Slides içinde grafik veri tablolarıyla nasıl çalışılacağını açıklar. Bir grafik için veri tablosunu nasıl görüntüleyeceğinizi ve kalın stil ve yazı tipi yüksekliği gibi font özelliklerini ayarlayarak metin biçimlendirmesini nasıl özelleştireceğinizi gösterir. Örnek, bir sunumu yüklemeyi, bir grafik eklemeyi, grafik veri tablosunu etkinleştirmeyi, font ayarlarını uygulamayı ve güncellenmiş sunumu kaydetmeyi göstermektedir.

Ayrıca, bir grafik veri tablosunda lejand anahtarlarının gösterilmesi, veri tablosunun dışa aktarma sırasında korunması, mevcut sunumlardan veya şablonlardan yüklenen grafiklerle çalışma ve veri tablosu etkinleştirilmiş grafiklerin belirlenmesi gibi yaygın sorulara kısa yanıtlar da içerir.

## **Set Font Properties for a Chart Data Table**
Aspose.Slides for .NET, bir serinin rengindeki kategorilerin rengini değiştirme desteği sağlar.

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıf nesnesini örnekleyin.
1. Slayta bir grafik ekleyin.
1. Grafik tablosunu ayarlayın.
1. Yazı tipi yüksekliğini ayarlayın.
1. Değiştirilmiş sunumu kaydedin.

Aşağıda örnek bir kod verilmiştir.

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

	chart.HasDataTable = true;

	chart.ChartDataTable.TextFormat.PortionFormat.FontBold = NullableBool.True;
	chart.ChartDataTable.TextFormat.PortionFormat.FontHeight = 20;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Grafiğin veri tablosundaki değerlerin yanına küçük lejand anahtarları gösterebilir miyim?**

Evet. Veri tablosu [legend keys](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/datatable/showlegendkey/) desteği sağlar ve bunları açıp kapatabilirsiniz.

**Sunumu PDF, HTML veya görüntülere dışa aktarırken veri tablosu korunacak mı?**

Evet. Aspose.Slides, grafiği slaytın bir parçası olarak render eder, böylece dışa aktarılan [PDF](/slides/tr/net/convert-powerpoint-to-pdf/)/[HTML](/slides/tr/net/convert-powerpoint-to-html/)/[image](/slides/tr/net/convert-powerpoint-to-png/) grafiği veri tablosu ile birlikte içerir.

**Şablon dosyasından gelen grafikler için veri tabloları destekleniyor mu?**

Evet. Mevcut bir sunum veya şablondan yüklenen herhangi bir grafik için, grafik özelliklerini kullanarak veri tablosunun [is shown](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/chart/hasdatatable/) olup olmadığını kontrol edebilir ve değiştirebilirsiniz.

**Bir dosyadaki hangi grafiklerde veri tablosunun etkin olduğunu hızlıca nasıl bulabilirim?**

Veri tablosunun [is shown](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/chart/hasdatatable/) gösterilip gösterilmediğini belirten her bir grafik özelliğini inceleyin ve slaytlar arasında dolaşarak etkin olan grafikleri tespit edin.