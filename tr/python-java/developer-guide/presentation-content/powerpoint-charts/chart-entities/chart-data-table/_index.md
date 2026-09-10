---
title: "Python Kullanarak Sunumlarda Grafik Veri Tablolarını Özelleştirme"
linktitle: "Veri Tablosu"
type: docs
url: /tr/python-java/chart-data-table/
keywords:
- grafik verisi
- veri tablosu
- yazı tipi özellikleri
- PowerPoint
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java ile PPT ve PPTX dosyalarında grafik veri tablolarını özelleştirerek sunumların verimliliğini ve çekiciliğini artırın."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde grafik veri tablolarıyla nasıl çalışılacağını açıklar. Bir grafik için veri tablosunun nasıl görüntüleneceğini ve kalın stil ve yazı tipi yüksekliği gibi yazı tipi özelliklerini ayarlayarak metin biçimlendirmesinin nasıl özelleştirileceğini gösterir. Örnek, bir sunum oluşturmayı, bir grafik eklemeyi, grafik veri tablosunu etkinleştirmeyi, yazı tipi ayarlarını uygulamayı ve güncellenmiş sunumu kaydetmeyi göstermektedir.

Ayrıca, bir grafik veri tablosunda lejand anahtarlarının gösterilmesi, veri tablosunun dışa aktarma sırasında korunması, mevcut sunumlardan veya şablonlardan yüklenen grafiklerle çalışma ve veri tablosunun etkin olduğu grafiklerin belirlenmesi gibi yaygın sorulara kısa yanıtlar da içerir.

## **Bir Grafik Veri Tablosu için Yazı Tipi Özelliklerini Ayarlama**

Aspose.Slides for Python via Java, bir grafiğin veri tablosunu göstermeyi ve metninin yazı tipi özelliklerini değiştirmeyi sağlar.

1. Sunum sınıfını [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) örnekleyin.  
2. Slayta bir grafik ekleyin.  
3. Grafik veri tablosunu gösterin.  
4. Veri tablosu metninin kalın stilini ve yazı tipi yüksekliğini ayarlayın.  
5. Değiştirilen sunumu kaydedin.  

Aşağıdaki örnek bu adımları gösterir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

# Boş bir sunum oluştur.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart.setDataTable(True)

    portion_format = chart.getChartDataTable().getTextFormat().getPortionFormat()
    portion_format.setFontBold(NullableBool.True_)
    portion_format.setFontHeight(20)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **SSS**

**Grafiğin veri tablosundaki değerlerin yanına küçük lejand anahtarları gösterebilir miyim?**  
Evet. Veri tablosu [legend keys](https://reference.aspose.com/slides/tr/python-java/aspose.slides/datatable/#setShowLegendKey) destekler ve bunları açıp kapatabilirsiniz.

**Sunumu PDF, HTML veya görüntülere dışa aktarırken veri tablosu korunacak mı?**  
Evet. Aspose.Slides, grafiği slayın bir parçası olarak işler, bu nedenle dışa aktarılan [PDF](/slides/tr/python-java/convert-powerpoint-to-pdf/)/[HTML](/slides/tr/python-java/convert-powerpoint-to-html/)/[image](/slides/tr/python-java/convert-powerpoint-to-png/) grafik ve veri tablosunu içerir.

**Şablon dosyasından gelen grafikler için veri tabloları destekleniyor mu?**  
Evet. Mevcut bir sunumdan veya şablondan yüklenen herhangi bir grafik için, grafik özelliklerini kullanarak veri tablosunun [gösterilip gösterilmediğini](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chart/#hasDataTable) kontrol edebilir ve değiştirebilirsiniz.

**Bir dosyada hangi grafiklerin veri tablosunun etkin olduğunu hızlıca nasıl bulabilirim?**  
Veri tablosunun [gösterilip gösterilmediğini](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chart/#hasDataTable) belirten her grafiğin özelliğini inceleyin ve slaytlar arasında dolaşarak etkin olan grafikleri tespit edin.