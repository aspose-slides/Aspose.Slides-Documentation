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
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET kullanarak PowerPoint sunumlarında grafik veri etiketlerini eklemeyi ve biçimlendirmeyi öğrenin, daha etkileyici slaytlar için."
---
## **Giriş**

Veri etiketleri, grafik serileri ve tek tek veri noktaları hakkında bilgi gösterir, okuyucuların değerleri tanımlamasına ve grafiği anlamasına yardımcı olur. Bu makale, değerlerin biçimlendirilmesi, yüzde gösterimi, etiket metninin okunması, eksen maksimumunun ötesindeki etiketlerin kontrolü, kategori eksen etiket aralığının ayarlanması ve pasta grafiği etiketlerinin konumlandırılması konularını açıklar.

## **Grafik Veri Etiketlerinde Veri Hassasiyetini Ayarlama**

[ number_format_of_values](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartseries/number_format_of_values/) kullanarak seri değerlerini biçimlendirin. Bu örnek, varsayılan verilerle bir çizgi grafik oluşturur, veri tablosunu gösterir ve ilk seri için değer etiketlerini etkinleştirir. `#,##0.00` biçimi, binlik ayırıcı ve iki ondalık basamak gösterir; temel değerleri değiştirmez.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 50, 50, 450, 300)
    chart.has_data_table = True

    series = chart.chart_data.series[0]
    series.number_format_of_values = "#,##0.00"
    series.labels.default_data_label_format.show_value = True

    presentation.save("PrecisionOfDatalabels_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Yüzdeyi Etiket Olarak Görüntüleme**

Yığılmış sütun grafik için, her değeri kategori toplamının yüzde olarak hesaplayıp [text_frame_for_overriding](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/) üzerine metin atayın. Bu örnek, varsayılan grafik verilerini kullanır ve yüzde değerlerini iki ondalık basamakla 8 punto yazı tipinde gösterir. Toplamı sıfır olan kategoriler bölme hatasından kaçınmak için atlanır. Grafik verileri değiştiğinde özel etiket metnini yeniden hesaplayın.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 400, 400)

    category_totals = [0.0] * len(chart.chart_data.categories)
    for k in range(len(chart.chart_data.categories)):
        for series in chart.chart_data.series:
            point_value = float(series.data_points[k].value.data)
            category_totals[k] += point_value

    for series in chart.chart_data.series:
        series.labels.default_data_label_format.show_legend_key = False

        for j in range(len(series.data_points)):
            label = series.data_points[j].label
            if category_totals[j] == 0:
                continue

            point_value = float(series.data_points[j].value.data)
            data_point_percent = point_value / category_totals[j] * 100

            portion = slides.Portion()
            portion.text = f"{data_point_percent:.2f} %"
            portion.portion_format.font_height = 8

            label.text_frame_for_overriding.text = ""

            paragraph = label.text_frame_for_overriding.paragraphs[0]
            paragraph.portions.add(portion)

            label.data_label_format.show_value = True
            label.data_label_format.show_series_name = False
            label.data_label_format.show_percentage = False
            label.data_label_format.show_legend_key = False
            label.data_label_format.show_category_name = False
            label.data_label_format.show_bubble_size = False

    presentation.save("DisplayPercentageAsLabels_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Grafik Veri Etiketlerinde Yüzde İşaretini Ayarlama**

Değerler kesir olarak saklanıyorsa, yüzde göstermek için [number_format](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/datalabelformat/number_format/) kullanın. Etiket biçimini kaynak hücrelerden bağımsız uygulamak için [is_number_format_linked_to_source](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) özelliğini `False` yapın.

Bu örnek, dört kategori üzerinde kırmızı ve mavi serilere sahip %100 yığılmış sütun grafik oluşturur. Her değer çifti 1’e eşittir. `0.0%` biçimi, 0.30 sayısını 30.0% olarak gösterirken, dikey eksen iki ondalık basamak kullanır. Her iki seri de beyaz, 10 punto etiket metni kullanır.

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PERCENTS_STACKED_COLUMN, 20, 20, 500, 400)

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.number_format = "0.00%"

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0
    for i in range(4):
        category_cell = workbook.get_cell(worksheet_index, i + 1, 0, f"Category {i + 1}")
        chart.chart_data.categories.add(category_cell)

    series_names = ["Reds", "Blues"]
    series_colors = [drawing.Color.red, drawing.Color.blue]
    values = [[0.30, 0.50, 0.80, 0.65], [0.70, 0.50, 0.20, 0.35]]

    for i in range(len(series_names)):
        series_cell = workbook.get_cell(worksheet_index, 0, i + 1, series_names[i])
        series = chart.chart_data.series.add(series_cell, chart.type)
        for j in range(4):
            value_cell = workbook.get_cell(worksheet_index, j + 1, i + 1, values[i][j])
            series.data_points.add_data_point_for_bar_series(value_cell)

        series.format.fill.fill_type = slides.FillType.SOLID
        series.format.fill.solid_fill_color.color = series_colors[i]

        label_format = series.labels.default_data_label_format
        label_format.show_value = True
        label_format.is_number_format_linked_to_source = False
        label_format.number_format = "0.0%"
        label_format.text_format.portion_format.font_height = 10
        label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
        label_format.text_format.portion_format.fill_format.solid_fill_color.color = drawing.Color.white

    presentation.save("SetDataLabelsPercentageSign_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Veri Etiketlerinin Gerçek Metnini Okuma**

[get_actual_label_text](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) kullanarak bir veri etiketinin ayarlarından oluşturulan metni alın. Bu, raporlar için etiketleri çıkarmak, sunum içeriğini aramak veya oluşturulan grafikleri doğrulamak istediğinizde yararlıdır. Aşağıdaki örnekte, varsayılan [data label format](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/datalabelformat/) her kategori adını, seri adını ve değeri birleştirir. Bir nokta değeri yüzde olarak, bir diğeri ise [text_frame_for_overriding](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/) üzerinden özel metin olarak biçimlendirir.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    for i, category_name in enumerate(["Q1", "Q2"]):
        category_cell = workbook.get_cell(0, i + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

    north_cell = workbook.get_cell(0, 0, 1, "North")
    north = chart.chart_data.series.add(north_cell, chart.type)
    for i, value in enumerate([0.25, 0.75]):
        value_cell = workbook.get_cell(0, i + 1, 1, value)
        north.data_points.add_data_point_for_bar_series(value_cell)

    south_cell = workbook.get_cell(0, 0, 2, "South")
    south = chart.chart_data.series.add(south_cell, chart.type)
    for i, value in enumerate([0.40, 0.60]):
        value_cell = workbook.get_cell(0, i + 1, 2, value)
        south.data_points.add_data_point_for_bar_series(value_cell)

    for series in chart.chart_data.series:
        label_format = series.labels.default_data_label_format
        label_format.show_category_name = True
        label_format.show_series_name = True
        label_format.show_value = True

    north.labels[1].data_label_format.is_number_format_linked_to_source = False
    north.labels[1].data_label_format.number_format = "0%"
    south.labels[0].text_frame_for_overriding.text = "Reviewed"

    for series in chart.chart_data.series:
        for point in series.data_points:
            label = point.label
            if not label.is_visible:
                continue

            label_text = label.get_actual_label_text()
            print(f"Value: {point.value.data}; label: {label_text}")
```

Veri noktasında saklanan sayı `0.75` olarak kalır, etiketinde ise kategori ve seri adlarıyla birlikte `75%` gösterilir. Özel metin, oluşturulan etiket metninin yerine geçer. [get_actual_label_text](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) her iki durumda da sonuç etiket dizesini döndürür. Yalnızca görünen etiketleri çıkarmak istediğinizde, yukarıda gösterildiği gibi [is_visible](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/datalabel/is_visible/) ayrı ayrı kontrol edin.

## **Eksen Maksimumunun Ötesindeki Veri Etiketlerini Kontrol Etme**

Bir eksen aralığını manuel olarak sınırladığınızda, bazı veri noktaları maksimumu aşabilir. Bu veri etiketlerinin gösterilip gösterilmeyeceğini kontrol etmek için [show_data_labels_over_maximum](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chart/show_data_labels_over_maximum/) özelliğini kullanın. Bu ayar etiket görünürlüğünü değiştirir; eksen aralığını veya temel veri değerlerini değiştirmez.

Aşağıdaki örnek, 60 ve 120 değerlerine sahip 2D kümelenmiş sütun grafik oluşturur. Dikey eksende [is_automatic_max_value](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/axis/is_automatic_max_value/) `False` ve [max_value](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/axis/max_value/) 100 olarak ayarlanır. İlk slayt, maksimumun ötesindeki etiketlere izin verir; bu slaydın bir kopyası ise etiketleri devre dışı bırakır. Her iki slayt da `DataLabelsOverMaximum.pptx` dosyasına kaydedilir.

[show_value](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/datalabelformat/show_value/) ile değer etiketlerini etkinleştirin. Grafik düzeyindeki bu ayar, tek bir etiketin devre dışı bırakılmış değer gösterimini geçersiz kılmaz; tek başına değer gösterimini sağlamaz. Bu örnek, tüm seri için değerleri etkinleştirir ve [position](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/datalabelformat/position/) kullanarak etiketleri her sütunun dış ucuna yerleştirir.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_legend = False

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook

    first_category = workbook.get_cell(0, 1, 0, "Within range")
    second_category = workbook.get_cell(0, 2, 0, "Above maximum")

    chart.chart_data.categories.add(first_category)
    chart.chart_data.categories.add(second_category)

    series_name = workbook.get_cell(0, 0, 1, "Values")
    series = chart.chart_data.series.add(series_name, chart.type)

    first_value = workbook.get_cell(0, 1, 1, 60)
    second_value = workbook.get_cell(0, 2, 1, 120)

    series.data_points.add_data_point_for_bar_series(first_value)
    series.data_points.add_data_point_for_bar_series(second_value)

    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.position = charts.LegendDataLabelPosition.OUTSIDE_END

    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.max_value = 100
    chart.show_data_labels_over_maximum = True

    second_slide = presentation.slides.add_clone(slide)
    second_chart = second_slide.shapes[0]
    second_chart.show_data_labels_over_maximum = False

    presentation.save("DataLabelsOverMaximum.pptx", slides.export.SaveFormat.PPTX)
```

Aşağıdaki görseller, Microsoft PowerPoint tarafından render edilen kaydedilmiş slaytları gösterir. `True` ile etiket **120** üst sınırda görünür; `False` ile gizlenir. Etiket **60** görünür kalır, eksen maksimumu **100** olarak kalır ve ikinci veri noktası her iki durumda da **120** olarak kalır.

| show_data_labels_over_maximum = True | show_data_labels_over_maximum = False |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
Bu örnek, bir değer ekseni içeren 2D sütun grafik kullanır. Değer ekseni olmayan grafikler, örneğin pasta ve halka grafikler, bu şekilde sınırlanacak bir eksen maksimumuna sahip değildir.
{{% /alert %}}

## **Eksenden Etiket Mesafesini Ayarlama**

[label_offset](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/axis/label_offset/) kullanarak kategori eksen etiketleri ile eksen arasındaki mesafeyi kontrol edin. Değer, eksen etiketlerinin maksimum yazı tipi boyutunun bir yüzdesidir. Bu örnek, kümelenmiş bir sütun grafik oluşturur ve yatay eksen etiket ofsetini 500 olarak ayarlar. Bu ayar, bireysel veri noktalarına ekli etiketler yerine kategori eksen etiketlerini etkiler.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)
    chart.axes.horizontal_axis.label_offset = 500

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Etiket Konumunu Ayarlama**

Bir pasta grafiğinde, veri etiketi konumlarını ayarlayarak boşlukları iyileştirin ve yönlendirme çizgileri için yer açın.

Bu örnek, ilk veri noktasının değerini gösterir, etiketini dilimin dışına koyar ve [x](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/datalabel/x/) ve [y](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/datalabel/y/) ofsetlerini ayarlar. Bu ofsetler, sırasıyla grafik genişliği ve yüksekliğine göre görecelidir.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 200, 200)
    series = chart.chart_data.series

    label = series[0].labels[0]
    label.data_label_format.show_value = True
    label.data_label_format.position = charts.LegendDataLabelPosition.OUTSIDE_END
    label.x = 0.71
    label.y = 0.04

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

![Ayarlanmış veri etiketi konumuna sahip pasta grafiği](pie-chart-adjusted-label.png)

## **SSS**

**Yoğun grafiklerde veri etiketlerinin üst üste binmesini nasıl önleyebilirim?**  
Otomatik etiket yerleştirmeyi, yönlendirme çizgilerini ve daha küçük yazı tipi boyutunu birleştirin; gerekirse bazı alanları (örneğin kategori) gizleyin veya yalnızca uç değerler ya da ana noktalar için etiket gösterin.

**Sıfır, negatif veya boş değerler için yalnızca etiketleri nasıl devre dışı bırakabilirim?**  
Etiketleri etkinleştirmeden önce veri noktalarını filtreleyin ve tanımlı bir kurala göre 0, negatif veya eksik değerler için gösterimi kapatın.

**PDF/görsellere dışa aktarırken tutarlı bir etiket stilini nasıl sağlayabilirim?**  
Yazı tipi ailesini ve boyutunu açıkça ayarlayın ve render ortamında yazı tipinin mevcut olduğundan emin olun.