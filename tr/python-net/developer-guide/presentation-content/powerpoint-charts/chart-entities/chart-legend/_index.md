---
title: Python ile Sunumlarda Grafik Açıklama Kutularını Özelleştirin
linktitle: Grafik Açıklama Kutusu
type: docs
url: /tr/python-net/chart-legend/
keywords:
- grafik açıklama kutusu
- açıklama kutusu konumu
- yazı tipi boyutu
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET ile grafik açıklama kutularını özelleştirerek PowerPoint sunumlarını hedef odaklı açıklama kutusu biçimlendirmesiyle optimize edin."
---
## **Genel Bakış**

Aspose.Slides for Python via .NET, PowerPoint sunumlarındaki grafik açıklama kutularını özelleştirme seçenekleri sunar. Bu makale, bir açıklama kutusunun konumunu ve boyutunu ayarlamayı, tüm açıklama kutusunun yazı tipi boyutunu belirlemeyi, tek bir açıklama girdisini biçimlendirmeyi ve seçilen girdileri gizlemeyi veya geri getirmeyi gösterir.

SSS, açıklama kutusu için alan ayırma, çok satırlı etiket gösterme ve biçimlendirmeyi sunum temasından devralma gibi ilgili davranışları kapsar.

## **Açıklama Kutusu Konumlandırma**

Açıklama kutusunun [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/x/), [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/y/), [width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/width/), ve [height](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/height/) özelliklerini kullanarak konumunu ve boyutunu grafiğin boyutlarının kesirleri olarak belirleyin.

Bu örnek bir sunum oluşturur ve ilk slayta varsayılan veriyle bir küme sütun grafiği ekler. İstenen açıklama kutusu ofsetleri ve boyutları grafiğin genişliği ve yüksekliğiyle bölerek göreli değerlere dönüştürülür: açıklama kutusu grafiğin sol üst köşesinden 50 puan uzaklıkta ve 100×100 puan boyutundadır.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 500)

    # Açıklama kutusunun konumunu ve boyutunu grafiğe göre ifade edin.
    chart.legend.x = 50 / chart.width
    chart.legend.y = 50 / chart.height
    chart.legend.width = 100 / chart.width
    chart.legend.height = 100 / chart.height

    presentation.save("legend_position.pptx", slides.export.SaveFormat.PPTX)
```

## **Açıklama Kutusunun Yazı Tipi Boyutunu Ayarlama**

Açıklama kutusunun [text_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/text_format/) özelliğini kullanarak metin biçimlendirmesine erişin ve [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) değerini puan olarak ayarlayın.

Bu örnek varsayılan veriyle bir grafik oluşturur ve açıklama kutusu metnini 20 puan olarak ayarlar. Ayrıca dikey eksen için otomatik sınırları devre dışı bırakır ve aralığını -5 ile 10 arasında belirler.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

    chart.legend.text_format.portion_format.font_height = 20
    chart.axes.vertical_axis.is_automatic_min_value = False
    chart.axes.vertical_axis.min_value = -5
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.max_value = 10

    presentation.save("legend_font_size.pptx", slides.export.SaveFormat.PPTX)
```

## **Tek Bir Açıklama Kutusu Girdisinin Yazı Tipi Boyutunu Ayarlama**

Belirli bir girdi için biçimlendirmeye erişmek üzere açıklama kutusunun [entries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/entries/) koleksiyonunu kullanın. Girdi dizinleri sıfır tabanlıdır, bu yüzden `1` indeksi ikinci girdiyi ifade eder.

Bu örnek, varsayılan verisi en az iki seriyi içeren bir küme sütun grafiği oluşturur. İkinci açıklama kutusu girdisini kalın, italik ve 20 puan mavi metinle biçimlendirir.

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

    text_format = chart.legend.entries[1].text_format
    text_format.portion_format.font_bold = slides.NullableBool.TRUE
    text_format.portion_format.font_height = 20
    text_format.portion_format.font_italic = slides.NullableBool.TRUE
    text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.blue

    presentation.save("legend_entry_format.pptx", slides.export.SaveFormat.PPTX)
```

## **Tek Tek Açıklama Kutusu Girdilerini Gizleme**

Bir yardımcı seriyi açıklama kutusundan dışlamak ancak verisini görünür tutmak için, [ILegendEntryProperties.hide](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ilegendentryproperties/hide/) özelliğini `True` olarak, [IChartSeries.related_legend_entry](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartseries/related_legend_entry/) aracılığıyla ayarlayın. Bu, yalnızca seçilen açıklama kutusu girdisini gizler; seriyi veya veri noktalarını kaldırmaz. Bunun aksine, [IChart.has_legend](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichart/has_legend/) özelliğini `False` olarak ayarlamak, tüm açıklama kutusunu gizler.

Aşağıdaki örnek, varsayılan veriyle birden çok seri içeren bir küme sütun grafiği oluşturur. İkinci serinin açıklama kutusu girdisini (indeks `1`) gizler ve sunumu kaydeder. Daha sonra [hide](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ilegendentryproperties/hide/) özelliğini `False` olarak ayarlayarak girdiyi geri getirir ve ikinci bir kopya kaydeder. Sütunlar her iki dosyada da görünür kalır.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_legend = True

    legend_entry = chart.chart_data.series[1].related_legend_entry
    legend_entry.hide = True

    presentation.save("hidden_legend_entry.pptx", slides.export.SaveFormat.PPTX)

    # Aynı girdiyi grafik verisini değiştirmeden geri yükleyin.
    legend_entry.hide = False

    presentation.save("restored_legend_entry.pptx", slides.export.SaveFormat.PPTX)
```

Aşağıdaki karşılaştırma, tüm girdileri görünür ve ikinci girdi gizli olan aynı grafiği gösterir. İkinci serinin sütunları değişmeden kalır.

![Tüm açıklama kutusu girdileri görünür ve Seri 2 açıklama kutusundan gizli olan bir grafiğin karşılaştırması; tüm sütunlar görünür kalır.](hide-legend-entry.png)

Sütun, çubuk ve çizgi grafiklerde, açıklama kutusu girdileri serileri tanımlar. Pasta grafiklerde ise tek tek veri noktalarını (dilimleri) tanımlar, bu yüzden seçilen dilim üzerinde [IChartDataPoint.related_legend_entry](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatapoint/related_legend_entry/) kullanın. API, bu veri noktası özelliğini `PIE`, `PIE3D`, `EXPLODED_PIE`, `EXPLODED_PIE3D`, `PIE_OF_PIE` ve `BAR_OF_PIE` grafik türleri için belgeler. Bu özelliğin, listede yer almayan halka grafiklerine uygulanacağını varsaymayın.

## **SSS**

**Grafiğin açıklama kutusu için alan ayırmasını, üzerine bindirmesini önleyebilir miyim?**

Evet. [overlay](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/overlay/) özelliğini `False` olarak ayarlayarak açıklama kutusu için alan ayırır ve grafik alanının üzerine binmesini engellersiniz.

**Çok satırlı açıklama kutusu etiketleri oluşturabilir miyim?**

Evet. Genişlik yetersiz olduğunda uzun etiketler otomatik olarak satır başına geçer. Ayrıca seri adlarında yeni satır karakterleri kullanarak satır sonu isteyebilirsiniz.

**Açıklama kutusunun sunum temasının renk şemasını takip etmesini nasıl sağlayabilirim?**

Açıklama kutusunun renklerini, dolgu ve yazı tiplerini ayarlamadan bırakın; böylece tema biçimlendirmesini devralır. Açıkça yapılan biçimlendirme, ilgili tema ayarlarını geçersiz kılar.