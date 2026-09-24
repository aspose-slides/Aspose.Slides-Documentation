---
title: Python ile Sunumlarda Grafik Veri Tablolarını Özelleştirme
linktitle: Veri Tablosu
type: docs
url: /tr/python-net/chart-data-table/
keywords:
- grafik verisi
- veri tablosu
- yazı tipi özellikleri
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "PowerPoint sunumlarında Aspose.Slides for Python via .NET kullanarak grafik veri tablosu yazı tiplerini, kenarlıklarını ve gösterge anahtarlarını özelleştirin."
---
## **Genel Bakış**

Aspose.Slides for Python via .NET, bir grafiğin veri tablosunu görüntülemenizi ve metin biçimlendirmesini, kenarlıkları ve gösterge anahtarlarını özelleştirmenizi sağlar. Bu makale, tabloyu nasıl etkinleştireceğinizi, metnini nasıl biçimlendireceğinizi, her kenarlık tipini nasıl kontrol edeceğinizi ve gösterge anahtarlarını nasıl göstereceğinizi ya da gizleyeceğinizi açıklar. Örnekler, yapılandırılmış grafikleri PPTX dosyalarına kaydeder.

## **Yazı Tipi Özelliklerini Ayarla**

Bir grafiğin veri tablosunu görüntülemek için [has_data_table](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chart/has_data_table/) `True` olarak ayarlayın. Tabloya erişmek ve metin biçimlendirmesini yapılandırmak için [chart_data_table](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chart/chart_data_table/) kullanın.

1. Sunumu [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfını kullanarak yükleyin.  
1. İlk slayta bir gruplanmış sütun grafik ekleyin.  
1. Grafiğin veri tablosunu etkinleştirin.  
1. [font_bold](https://reference.aspose.com/slides/tr/python-net/aspose.slides/baseportionformat/font_bold/) ile kalın metni etkinleştirin ve 20 punto metin için [font_height](https://reference.aspose.com/slides/tr/python-net/aspose.slides/baseportionformat/font_height/) `20` olarak ayarlayın.  
1. Değiştirilmiş sunumu kaydedin.  

Aşağıdaki örnek, çalışma dizininde en az bir slayt içeren `test.pptx` dosyasını gerektirir. Varsayılan verilerle (50, 50) konumunda, genişliği 600 nokta ve yüksekliği 400 nokta olan bir grafik ekler. Kaydedilen `output.pptx`, veri tablosu etkinleştirilmiş ve belirtilen yazı tipi ayarları uygulanmış grafiği içerir.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("test.pptx") as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_data_table = True

    portion_format = chart.chart_data_table.text_format.portion_format
    portion_format.font_bold = slides.NullableBool.TRUE
    portion_format.font_height = 20

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Veri Tablosu Kenarlıklarını Özelleştirin**

Tabloyu [Chart.has_data_table](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chart/has_data_table/) ile etkinleştirin ve [Chart.chart_data_table](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chart/chart_data_table/) üzerinden erişin. Üç kenarlık tipini bağımsız olarak kontrol edebilirsiniz:

- [has_border_horizontal](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/datatable/has_border_horizontal/) yatay hücre kenarlıklarını kontrol eder.  
- [has_border_vertical](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/datatable/has_border_vertical/) dikey hücre kenarlıklarını kontrol eder.  
- [has_border_outline](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/datatable/has_border_outline/) tablonun dış kenarlığını kontrol eder.  

Her özelliği `True` olarak ayarlayarak kenarlıkları gösterin, `False` olarak ayarlayarak gizleyin. Aşağıdaki örnek, varsayılan verilerle bir gruplanmış sütun grafik oluşturur, yatay kenarlıkları ve dış kenarlığı gösterir, dikey kenarlıkları gizler. Giriş dosyası gerektirmez. Grafiğin konumu ve boyutu nokta biriminde belirtilir.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_data_table = True

    data_table = chart.chart_data_table
    data_table.has_border_horizontal = True
    data_table.has_border_vertical = False
    data_table.has_border_outline = True

    presentation.save("data-table-borders.pptx", slides.export.SaveFormat.PPTX)
```

Aşağıdaki karşılaştırma, dört durumda da aynı grafik verisi ve gösterge anahtarı ayarını kullanır. Tüm kenarlıklar etkinleştirilmiş olarak başlar, kalan her varyant yalnızca bir kenarlık özelliğini devre dışı bırakır. Sol alt varyant, örnekteki kenarlık ayarlarıyla eşleşir.

![Tüm kenarlıklar etkin, yatay kenarlık yok, dikey kenarlık yok ve dış kenarlık olmayan grafik veri tabloları](data-table-borders.png)

## **Gösterge Anahtarlarını Göster veya Gizle**

Gösterge anahtarları, veri tablosundaki seri adlarının yanında bulunan küçük renkli işaretlerdir. Okuyucuların her tablo satırını bir grafik serisine eşleştirmesine yardımcı olur. Bu işaretleri göstermek için [show_legend_key](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/datatable/show_legend_key/) `True`, gizlemek için `False` olarak ayarlayın.

Grafiğin ayrı gösterge, [Chart.has_legend](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chart/has_legend/) ile kontrol edilir. Bu ayarlar bağımsızdır: ayrı göstergeyi gizlemek, veri tablosundaki anahtarları gizlemez ve tablonun anahtarlarını gizlemek, ayrı göstergeyi gizlemez.

Aşağıdaki örnek, varsayılan verilerle bir grafik oluşturur, veri tablosunu etkinleştirir ve ayrı göstergeyi gizlerken içinde gösterge anahtarlarını gösterir. Tüm tablo kenarlıkları açıkça etkinleştirilir. Giriş sunumu gerekmez. Yalnızca tablonun anahtarlarını gizlemek için `data_table.show_legend_key` değerini `False` olarak değiştirin.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_data_table = True
    chart.has_legend = False

    data_table = chart.chart_data_table
    data_table.has_border_horizontal = True
    data_table.has_border_vertical = True
    data_table.has_border_outline = True
    data_table.show_legend_key = True

    presentation.save("data-table-legend-keys.pptx", slides.export.SaveFormat.PPTX)
```

Aşağıdaki karşılaştırma, aynı tabloyu gösterge anahtarları etkin ve devre dışı durumda gösterir. Tüm kenarlıklar etkin kalır ve ayrı grafik gösterge her iki durumda da gizlidir.

![Sol tarafta gösterge anahtarları gösterilen, sağ tarafta gizlenen grafik veri tabloları](data-table-legend-keys.png)

## **SSS**

**Grafiğin veri tablosunda gösterge anahtarlarını gösterebilir miyim?**  
Evet. Gösterge anahtarlarını göstermek için [show_legend_key](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/datatable/show_legend_key/) `True`, gizlemek için `False` olarak ayarlayın.

**Sunumu PDF, HTML veya görüntülere dışa aktarırken veri tablosu korunur mu?**  
Evet. Aspose.Slides, grafiği ve görüntülenen veri tablosunu, [PDF](/slides/tr/python-net/convert-powerpoint-to-pdf/), [HTML](/slides/tr/python-net/convert-powerpoint-to-html/) veya [görseller](/slides/tr/python-net/convert-powerpoint-to-png/) olarak dışa aktarırken slaytın bir parçası olarak render eder.

**Şablondan yüklenen grafikleri veri tablolarıyla çalışabilir miyim?**  
Evet. Mevcut bir sunumdan veya şablondan yüklenen bir grafik için, veri tablosunun görüntülenip görüntülenmediğini kontrol etmek veya değiştirmek amacıyla [has_data_table](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chart/has_data_table/) kullanın.

**Veri tablosu etkin olan grafikleri nasıl bulabilirim?**  
Her slayttaki şekilleri dolaşın, grafikleri belirleyin ve [has_data_table](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chart/has_data_table/) özelliklerini kontrol edin. `True` değeri, veri tablosunun etkin olduğunu gösterir.