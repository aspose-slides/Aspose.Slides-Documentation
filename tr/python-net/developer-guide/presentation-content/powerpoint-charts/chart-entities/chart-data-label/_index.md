---
title: Python ile Sunumlarda Grafik Veri Etiketlerini Yönetme
linktitle: Veri Etiketi
type: docs
url: /tr/python-net/chart-data-label/
keywords:
- grafik
- veri etiketi
- veri hassasiyeti
- yüzde
- etiket mesafesi
- etiket konumu
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET kullanarak PowerPoint ve OpenDocument sunumlarına grafik veri etiketleri eklemeyi ve biçimlendirmeyi öğrenin, böylece daha etkileyici slaytlar oluşturun."
---
## **Genel Bakış**

Bir grafikteki veri etiketleri, grafik veri serisi veya tek tek veri noktaları hakkında ayrıntılar gösterir. Okuyucuların veri serilerini hızlıca tanımlamasını sağlar ve grafiklerin anlaşılmasını kolaylaştırır. Aspose.Slides for Python’da, herhangi bir grafik için veri etiketlerini etkinleştirebilir, özelleştirebilir ve biçimlendirebilirsiniz—gösterilecek öğeyi (değerler, yüzde, seri veya kategori adları) seçebilir, etiketlerin konumunu belirleyebilir ve görünümünü (yazı tipi, sayı biçimi, ayırıcılar, lider çizgileri ve daha fazlası) ayarlayabilirsiniz. Bu makale, grafiklerinize net ve bilgilendirici etiketler eklemek için ihtiyaç duyacağınız temel API’leri ve örnekleri özetlemektedir.

## **Veri Etiketi Hassasiyetini Ayarlama**

Grafik veri etiketleri genellikle tutarlı hassasiyet gerektiren sayısal değerler gösterir. Bu bölüm, Aspose.Slides’da veri etiketleri için ondalık basamak sayısını uygun bir sayı biçimi uygulayarak nasıl kontrol edeceğinizi gösterir.

Aşağıdaki Python örneği, grafik veri etiketleri için sayısal hassasiyeti nasıl ayarlayacağınızı gösterir:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 50, 50, 500, 300)

    series = chart.chart_data.series[0]
    series.labels.default_data_label_format.show_value = True
    series.number_format_of_values = "#,##0.00"

    presentation.save("data_label_precision.pptx", slides.export.SaveFormat.PPTX)
```

## **Yüzdeleri Etiket Olarak Görüntüleme**

Aspose.Slides ile, grafiklerde yüzde değerlerini veri etiketi olarak gösterebilirsiniz. Aşağıdaki örnek, her noktanın kendi kategorisi içindeki payını hesaplar ve etiketi yüzde olarak biçimlendirir.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Presentation sınıfının bir örneğini oluştur.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 600, 400)
    series = chart.chart_data.series[0]

    total_for_categories = [0]*len(chart.chart_data.categories)
    for k in range(len(chart.chart_data.categories)):
        for i in range(len(chart.chart_data.series)):
            total_for_categories[k] += chart.chart_data.series[i].data_points[k].value.data

    for i in range(len(chart.chart_data.series)):
        series = chart.chart_data.series[i]
        series.labels.default_data_label_format.show_legend_key = False

        for j in range(len(series.data_points)):
            data_point_percent = series.data_points[j].value.data / total_for_categories[j] * 100

            text_portion = slides.Portion()
            text_portion.text = "{0:.2f} %".format(data_point_percent)
            text_portion.portion_format.font_height = 8

            label = series.data_points[j].label
            label.text_frame_for_overriding.text = ""

            paragraph = label.text_frame_for_overriding.paragraphs[0]
            paragraph.portions.add(text_portion)

            label.data_label_format.show_series_name = False
            label.data_label_format.show_percentage = False
            label.data_label_format.show_legend_key = False
            label.data_label_format.show_category_name = False
            label.data_label_format.show_bubble_size = False

    # Grafiği içeren sunumu kaydet.
    presentation.save("percentage_as_label.pptx", slides.export.SaveFormat.PPTX)
```

## **Grafik Veri Etiketleriyle Yüzde İşaretlerini Gösterme**

Bu bölüm, grafik veri etiketlerinde yüzde değerlerini gösterme ve yüzde işaretini ekleme yöntemlerini Aspose.Slides kullanarak anlatır. Tüm seri için veya belirli noktalar için yüzde değerlerini nasıl etkinleştireceğinizi (pie, doughnut ve %100 yığılmış grafikler için ideal) ve etiket seçenekleri ya da özel bir sayı biçimi aracılığıyla biçimlendirmeyi nasıl kontrol edeceğinizi öğreneceksiniz.

Aşağıdaki Python örneği, bir grafiğin veri etiketine yüzde işareti eklemenin nasıl yapılacağını gösterir:

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

# Presentation sınıfının bir örneğini oluştur.
with slides.Presentation() as presentation:

    # İndeksle bir slayt referansı al.
    slide = presentation.slides[0]

    # Slaytta bir PercentsStackedColumn grafik oluştur.
    chart = slide.shapes.add_chart(charts.ChartType.PERCENTS_STACKED_COLUMN, 20, 20, 600, 400)

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.number_format = "0.00%"

    chart.chart_data.series.clear()

    # Grafik veri çalışma kitabını al.
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    # Yeni bir seri ekle.
    series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 1, "Reds"), chart.type)
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 1, 0.30))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 1, 0.50))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 1, 0.80))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 1, 0.65))

    # Serinin dolgu rengini ayarla.
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.red

    # Etiket biçim özelliklerini ayarla.
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.is_number_format_linked_to_source = False
    series.labels.default_data_label_format.number_format = "0.0%"
    series.labels.default_data_label_format.text_format.portion_format.font_height = 10
    series.labels.default_data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    series.labels.default_data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.white
    series.labels.default_data_label_format.show_value = True

    # Yeni bir seri ekle.
    series2 = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 2, "Blues"), chart.type)
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 2, 0.70))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 2, 0.50))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 2, 0.20))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 2, 0.35))

    # Dolgu tipini ve rengini ayarla.
    series2.format.fill.fill_type = slides.FillType.SOLID
    series2.format.fill.solid_fill_color.color = draw.Color.blue
    series2.labels.default_data_label_format.show_value = True
    series2.labels.default_data_label_format.is_number_format_linked_to_source = False
    series2.labels.default_data_label_format.number_format = "0.0%"
    series2.labels.default_data_label_format.text_format.portion_format.font_height = 10
    series2.labels.default_data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    series2.labels.default_data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.white

    # Sunumu kaydet.
    presentation.save("percentage_sign.pptx", slides.export.SaveFormat.PPTX)
```

## **Etiket Mesafesini Eksen’den Ayarlama**

Bu bölüm, Aspose.Slides’da veri etiketleri ile grafik ekseni arasındaki mesafeyi nasıl kontrol edeceğinizi gösterir. Bu ofseti ayarlamak, çakışmaları önlemeye ve yoğun görsellerde okunabilirliği artırmaya yardımcı olur.

Aşağıdaki Python kodu, eksen tabanlı bir grafik ile çalışırken kategori ekseninden etiket mesafesini nasıl ayarlayacağınızı gösterir:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Presentation sınıfının bir örneğini oluştur.
with slides.Presentation() as presentation:
    # Bir slayt referansı al.
    slide = presentation.slides[0]

    # Slayta bir clustered column grafik oluştur.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    # Kategori (yatay) ekseninden etiket mesafesini ayarla.
    chart.axes.horizontal_axis.label_offset = 500

    # Sunumu kaydet.
    presentation.save("axis_label_distance.pptx", slides.export.SaveFormat.PPTX)
```

## **Etiket Konumunu Ayarlama**

Eksen kullanmayan bir grafik (örneğin pie grafiği) oluşturduğunuzda, veri etiketleri kenara çok yakın olabilir. Bu durumda, lider çizgilerin net görünmesi için etiket konumunu ayarlayın.

Aşağıdaki Python kodu, pie grafiğinde etiket konumunu nasıl ayarlayacağınızı gösterir:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 600, 300)

    series = chart.chart_data.series[0]
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.show_leader_lines = True

    label = series.labels[0]
    label.data_label_format.position = charts.LegendDataLabelPosition.OUTSIDE_END

    label.x = 0.05
    label.y = 0.1

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

![Etiket konumu değiştirildi](changed_label_position.png)

## **SSS**

**Yoğun grafiklerde veri etiketlerinin çakışmasını nasıl önleyebilirim?**  
Otomatik etiket yerleştirme, lider çizgileri ve daha küçük yazı tipi boyutunu birleştirin; gerekirse bazı alanları (örneğin kategoriyi) gizleyin veya yalnızca uç/anahtar noktalara etiket gösterin.

**Sıfır, negatif veya boş değerler için etiketleri yalnızca nasıl devre dışı bırakabilirim?**  
Etiketleri etkinleştirmeden önce veri noktalarını filtreleyin ve tanımlı bir kurala göre 0, negatif veya eksik değerlere sahip noktaların görüntülenmesini kapatın.

**PDF/görsellere dışa aktarırken tutarlı bir etiket stilini nasıl sağlayabilirim?**  
Yazı tiplerini (aile, boyut) açıkça ayarlayın ve yedekleme oluşmaması için render tarafında yazı tipinin mevcut olduğunu doğrulayın.