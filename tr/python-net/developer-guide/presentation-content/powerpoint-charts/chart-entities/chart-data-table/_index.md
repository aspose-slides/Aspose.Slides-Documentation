---
title: Python'da Grafik Veri Tablolarını Özelleştirme
linktitle: Veri Tablosu
type: docs
url: /tr/python-net/chart-data-table/
keywords:
- grafik veri
- veri tablosu
- yazı tipi özellikleri
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides ile PPT, PPTX ve ODP için Python'da grafik veri tablolarını özelleştirerek sunumlarda verimliliği ve çekiciliği artırın."
---
## **Genel Bakış**

Bu makale Aspose.Slides'te grafik veri tabloları ile nasıl çalışılacağını açıklar. Bir grafik için veri tablosunun nasıl görüntüleneceğini ve kalın stil ile yazı tipi yüksekliği gibi yazı tipi özelliklerini ayarlayarak metin biçimlendirmesinin nasıl özelleştirileceğini gösterir. Örnek, bir sunumu yüklemeyi, bir grafik eklemeyi, grafik veri tablosunu etkinleştirmeyi, yazı tipi ayarlarını uygulamayı ve güncellenmiş sunumu kaydetmeyi göstermektedir.

Ayrıca, bir grafik veri tablosunda lejand anahtarlarının gösterilmesi, dışa aktarım sırasında veri tablosunun korunması, mevcut sunumlardan veya şablonlardan yüklenen grafiklerle çalışma ve veri tablosu etkin olan grafiklerin belirlenmesi gibi yaygın sorulara kısa yanıtlar içerir.

## **Grafik Veri Tablosu İçin Yazı Tipi Özelliklerini Ayarlama**
Aspose.Slides for Python via .NET, bir serideki kategorilerin rengini değiştirmeyi destekler.  

1. [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıf nesnesini oluşturun.  
1. Slayta bir grafik ekleyin.  
1. Grafik tablosunu ayarlayın.  
1. Yazı tipi yüksekliğini belirleyin.  
1. Değiştirilmiş sunumu kaydedin.  

Aşağıda örnek bir kod verilmiştir.  

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

	chart.has_data_table = True

	chart.chart_data_table.text_format.portion_format.font_bold = 1
	chart.chart_data_table.text_format.portion_format.font_height = 20

	pres.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **SSS**

**Grafiğin veri tablosundaki değerlerin yanında küçük lejand anahtarları gösterebilir miyim?**

Evet. Veri tablosu [legend anahtarları](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/datatable/show_legend_key/) destekler ve bunları açıp kapatabilirsiniz.

**Sunumu PDF, HTML veya görüntülere dışa aktarırken veri tablosu korunur mu?**

Evet. Aspose.Slides, grafiği slaytın bir parçası olarak işler, bu nedenle dışa aktarılan [PDF](/slides/tr/python-net/convert-powerpoint-to-pdf/)/[HTML](/slides/tr/python-net/convert-powerpoint-to-html/)/[image](/slides/tr/python-net/convert-powerpoint-to-png/) grafik veri tablosunu içerir.

**Şablon dosyasından gelen grafikler için veri tabloları destekleniyor mu?**

Evet. Mevcut bir sunumdan veya şablondan yüklenen herhangi bir grafik için, grafik özelliklerini kullanarak veri tablosunun [gösteriliyor](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chart/has_data_table/) olup olmadığını kontrol edebilir ve değiştirebilirsiniz.

**Bir dosyadaki hangi grafiklerde veri tablosunun etkin olduğunu hızlıca nasıl bulabilirim?**

Veri tablosunun [gösteriliyor](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chart/has_data_table/) olduğunu belirten her grafiğin özelliğini inceleyin ve slaytlar arasında döngü yaparak etkin olan grafikleri tespit edin.