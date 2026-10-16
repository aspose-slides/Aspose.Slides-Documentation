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
description: "Aspose.Slides for Python via .NET kullanarak PowerPoint sunumlarına grafik veri etiketleri eklemeyi ve biçimlendirmeyi öğrenin, böylece daha etkileyici slaytlar oluşturabilirsiniz."
---
## **Giriş**

Veri etiketleri, grafik serileri ve bireysel veri noktaları hakkında bilgi gösterir, okuyucuların değerleri tanımlamasına ve grafiği anlamasına yardımcı olur. Bu makale, değerlerin biçimlendirilmesi, yüzdelerin gösterilmesi, etiket metninin okunması, eksen maksimumunun ötesindeki etiketlerin kontrol edilmesi, kategori ekseni etiketi aralığının ayarlanması ve pasta grafik etiketlerinin konumlandırılması konularını açıklar.

## **Grafik Veri Etiketlerinde Veri Hassasiyetini Ayarlama**

Seri değerlerini biçimlendirmek için [number_format_of_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/number_format_of_values/) kullanın. Bu örnek, varsayılan veriyle bir çizgi grafiği oluşturur, veri tablosunu gösterir ve ilk seri için değer etiketlerini etkinleştirir. `#,##0.00` biçimi, binlik ayırıcı ve iki ondalık basamak gösterir, temel değerleri değiştirmez.

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

## **Yüzdeleri Etiket Olarak Göster**

Yığılmış bir sütun grafik için, her değeri kategori toplamının yüzde değeri olarak hesaplayın ve metni [text_frame_for_overriding](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/) atayın. Bu örnek varsayılan grafik verilerini kullanır ve yüzdeyi iki ondalık basamakla 8 punto yazı tipinde gösterir. Toplamı sıfır olan kategoriler bölme hatasından kaçınmak için atlanır. Grafik verileri değişirse özel etiket metnini yeniden hesaplayın.

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

## **Grafik Veri Etiketlerinde Yüzde İşaretini Ayarla**

Değerler kesir olarak saklandığında, yüzde göstermek için [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/number_format/) kullanın. Etiket biçimini kaynak hücrelerden bağımsız olarak uygulamak için [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) `False` olarak ayarlayın.

Bu örnek, dört kategori boyunca kırmızı ve mavi seriler içeren %100 yığılmış bir sütun grafik oluşturur. Her değer çifti 1’e eşittir. Etiket biçimi `0.0%`, 0.30’u 30.0% olarak gösterirken, dikey eksen iki ondalık basamak kullanır. Her iki seri de beyaz, 10 punto etiket metni kullanır.

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

## **Veri Etiketlerinin Gerçek Metnini Oku**

[get_actual_label_text](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) kullanarak bir veri etiketinin ayarlarıyla üretilen metni alın. Bu, raporlar için etiket çıkarmada, sunum içeriğinde arama yapmada veya üretilen grafikleri doğrulamada faydalıdır. Aşağıdaki örnekte, varsayılan [data label format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/) her kategori adı, seri adı ve değeri birleştirir. Bir nokta değerini yüzde olarak biçimler, diğeri ise [text_frame_for_overriding](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/) üzerinden özel metin kullanır.

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

Veri noktasında depolanan sayı `0.75` olarak kalır, etiket ise `75%` ve kategori ve seri adlarıyla gösterilir. Özel metin, oluşturulan etiket metninin yerini alır. [get_actual_label_text](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) her iki durumda da sonuç etiket dizesini döndürür. Görünür etiketleri yalnızca çıkarmak istediğinizde, yukarıda gösterildiği gibi [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/is_visible/) ayrı olarak kontrol edin.

## **Ekseni Maksimumunun Ötesindeki Veri Etiketlerini Kontrol Et**

Bir eksen aralığını manuel olarak sınırladığınızda, bazı veri noktaları maksimumu aşabilir. Bu durumlarda etiketlerin gösterilip gösterilmeyeceğini kontrol etmek için [show_data_labels_over_maximum](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/show_data_labels_over_maximum/) kullanın. Bu ayar etiket görünürlüğünü değiştirir; eksen aralığını veya temel veri değerlerini değiştirmez.

Aşağıdaki örnek, 60 ve 120 değerlerine sahip 2D küme sütun grafiği oluşturur. Dikey eksende [is_automatic_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_max_value/) `False` ve [max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/max_value/) 100 olarak ayarlanır. İlk slayt, maksimumun ötesindeki etiketlere izin verir; bir kopyası onları devre dışı bırakır. Her iki slayt da `DataLabelsOverMaximum.pptx` içinde kaydedilir.

Değer etiketlerini [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) ile etkinleştirin. Grafik düzeyindeki bu ayar, tek başına değer gösterimini sağlamaz veya bireysel bir etiketin devre dışı bırakılmış değer görüntüsünü geçersiz kılmaz. Bu örnek, tüm seri için değerleri etkinleştirir ve [position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/position/) kullanarak etiketleri her sütunun dış ucuna yerleştirir.

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

{{% alert color="info" title="Grafik Türü" %}}
Bu örnek, değer ekseni olan 2D sütun grafiği kullanır. Değer ekseni olmayan grafikler, örneğin pasta ve halka grafikler, bu şekilde sınırlanabilecek bir eksen maksimumuna sahip değildir.
{{% /alert %}}

## **Eksen İçinden Etiket Mesafesini Ayarla**

Kategori ekseni etiketleri ile eksen arasındaki mesafeyi kontrol etmek için [label_offset](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/label_offset/) kullanın. Değer, eksen etiketlerinin maksimum yazı tipi boyutunun bir yüzdesidir. Bu örnek, bir küme sütun grafiği oluşturur ve yatay eksen etiket offsetini 500 olarak ayarlar. Bu ayar, bireysel veri noktalarına eklenmiş etiketler yerine kategori ekseni etiketlerini etkiler.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)
    chart.axes.horizontal_axis.label_offset = 500

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Etiket Konumunu Ayarla**

Bir pasta grafiğinde, veri etiketi konumlarını ayarlayarak boşlukları iyileştirin ve lider çizgileri için yer açın.

Bu örnek, ilk veri noktasının değerini gösterir, etiketini dilimin dışına yerleştirir ve [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/x/) ve [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/y/) offsetlerini ayarlar. Bu offsetler, sırasıyla grafiğin genişliği ve yüksekliğine göre orantılıdır.

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

![Ayarlanmış veri etiketi konumlu pasta grafiği](pie-chart-adjusted-label.png)

## **Lider Çizgilerini Biçimlendir**

Pasta grafik etiketleri dilimlerin dışına konduğunda, lider çizgileri her değeri doğru dilime bağlamada okuyucuya yardımcı olur. Zıt bir renk ve biraz daha kalın bir çizgi bu bağlantıları takip etmeyi kolaylaştırırken, şeffaflık ve kesikli stil çizgileri görsel olarak az dikkat çeker hale getirir.

Seri veri etiketi koleksiyonu düzeyinde lider çizgilerini biçimlendirmek için [leader_lines_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelcollection/leader_lines_format/) kullanın. `series.labels.leader_lines_format.line` içindeki ayarlar koleksiyona, ayrı bir etikete değil, uygulanır.

Bu örnek, varsayılan veriyle bir pasta grafiği oluşturur, değerleri dilimlerin dışına gösterir ve [show_leader_lines](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_leader_lines/) etkinleştirir. İki etiketi, [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/x/) ve [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/y/) offsetlerini kullanarak dilimlerinden daha uzağa taşır; bu offsetler grafiğin genişliği ve yüksekliğinin kesirleri olarak ifade edilir. Giriş sunumu gerektirmez.

Çizginin [fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/fill_format/) alfa değeri 255 içinde 191 olan katı mavi bir renk ayarlar, yaklaşık %25 şeffaflık verir. [width](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/width/) kalınlığı 2 puan olarak ayarlar ve [dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/) çizgiyi kesikli yapar.

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 80, 50, 560, 400)
    chart.has_legend = False

    series = chart.chart_data.series[0]

    label_format = series.labels.default_data_label_format
    label_format.show_value = True
    label_format.position = charts.LegendDataLabelPosition.OUTSIDE_END
    label_format.show_leader_lines = True

    # İki etiketi dilimlerinden daha uzağa taşı.
    series.labels[0].x = 0.10
    series.labels[0].y = -0.05
    series.labels[1].x = -0.10
    series.labels[1].y = 0.05

    line = series.labels.leader_lines_format.line
    line.fill_format.fill_type = slides.FillType.SOLID
    line.fill_format.solid_fill_color.color = drawing.Color.from_argb(191, 30, 90, 160)
    line.width = 2
    line.dash_style = slides.LineDashStyle.DASH

    presentation.save("FormattedLeaderLines.pptx", slides.export.SaveFormat.PPTX)
```

Lider çizgilerini etkinleştirmek, her etiket için bir çizgi çıkacağı garantisini vermez. Görünürlük, etiket yerleşimine ve grafiğin düzen davranışına bağlıdır. Bu örnekte, iki kaydırılmış etiketin görünür lider çizgileri vardır; dilimlerine yakın kalan etiketlerin ise çizgiye ihtiyacı yoktur.

Aşağıdaki görsel, Aspose.Slides ile render edilen kaydedilmiş `FormattedLeaderLines.pptx` dosyasını gösterir:

![İki dış etiketi dilimlerine bağlayan mavi, yarı saydam kesikli lider çizgili pasta grafiği](formatted-leader-lines.png)

## **Bir Sütun Grafiğinin Üstüne Birden Fazla Satır Veri Etiketi Ekle**

Bu örnek, çizim alanının üstünde iki satır veri etiketi bulunan bir sütun grafiği oluşturur. Seri A, görünür sütunları gösterirken, Seri B ve Seri C ek etiketleri sağlar. Sütunları, doldurma ve kenarlık kaldırılarak gizlenir. [overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/overlap/) özelliği, üç seriyi aynı kategori merkezleriyle hizalar.

[plot_area](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/plot_area/) ayarları etiket satırları için alan ayırır. [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) varsayılan konumları hesapladıktan sonra, [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/x/) ve [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/y/) yatay hizalamayı korur ve dikey offsetler uygulayarak etiketleri iki satırda düzenler. Sayılar, seri değerlerine bağlı veri etiketleri olarak kalır; sadece satır başlıkları ayrı metin şekilleridir.

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 40, 40, 640, 200)
    chart.has_title = False
    chart.has_legend = False
    chart.text_format.portion_format.font_height = 12

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    categories = ["North", "South", "East", "West"]
    series_names = ["Series A", "Series B", "Series C"]
    series_values = [
        [35, 42, 28, 47],
        [22, 31, 19, 26],
        [12, 16, 14, 18]
    ]

    for category_index, category_name in enumerate(categories):
        category_cell = workbook.get_cell(0, category_index + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

    for series_index, series_name in enumerate(series_names):
        series_cell = workbook.get_cell(0, 0, series_index + 1, series_name)
        series = chart.chart_data.series.add(series_cell, charts.ChartType.CLUSTERED_COLUMN)

        for category_index in range(len(categories)):
            value_cell = workbook.get_cell(0, category_index + 1, series_index + 1, series_values[series_index][category_index])
            series.data_points.add_data_point_for_bar_series(value_cell)

        if series_index > 0:
            # B ve C sütunlarını gizle, ancak veri etiketlerini tut.
            series.format.fill.fill_type = slides.FillType.NO_FILL
            series.format.line.fill_format.fill_type = slides.FillType.NO_FILL
            label_format = series.labels.default_data_label_format
            label_format.show_value = True
            label_format.text_format.portion_format.font_height = 12
            label_fill = label_format.text_format.portion_format.fill_format
            label_fill.fill_type = slides.FillType.SOLID
            label_fill.solid_fill_color.color = drawing.Color.black
            label_format.position = charts.LegendDataLabelPosition.INSIDE_BASE

    # Üç seriyi aynı kategori merkezleriyle hizala.
    chart.chart_data.series[0].parent_series_group.overlap = 100

    # Bu kompakt örnek için daha az ızgara çizgisi kullan.
    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.major_unit = 10

    # Veri etiketlerinin iki satırı için çizim alanının üstünde boşluk ayır.
    chart.plot_area.layout_target_type = charts.LayoutTargetType.INNER
    chart.plot_area.x = 0.15
    chart.plot_area.y = 0.32
    chart.plot_area.width = 0.80
    chart.plot_area.height = 0.48
    chart.validate_chart_layout()

    for series_index in range(1, len(series_names)):
        series = chart.chart_data.series[series_index]
        row_top = 0.15 if series_index == 1 else 0.03

        for category_index in range(len(categories)):
            data_label = series.data_points[category_index].label
            # Varsayılan yatay konumu koru. Y,
            # varsayılan etiket konumundan, grafik yüksekliğinin bir kesri olarak ifade edilen bir offsettir.
            data_label.x = 0
            data_label.y = row_top - data_label.actual_y / chart.height

        # Sadece satır başlığı ayrı bir metin şeklidir.
        row_heading = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, chart.x, chart.y + row_top * chart.height, 85, 18)
        row_heading.fill_format.fill_type = slides.FillType.NO_FILL
        row_heading.line_format.fill_format.fill_type = slides.FillType.NO_FILL
        row_heading.add_text_frame(series_names[series_index])
        row_heading.text_frame.text_frame_format.margin_top = 0
        row_heading.text_frame.text_frame_format.margin_bottom = 0
        heading_format = row_heading.text_frame.paragraphs[0].portions[0].portion_format
        heading_format.font_height = 12
        heading_format.fill_format.fill_type = slides.FillType.SOLID
        heading_format.fill_format.solid_fill_color.color = drawing.Color.black

    presentation.save("multiple-rows-of-labels.pptx", slides.export.SaveFormat.PPTX)
```

![Çizim alanının üstünde iki satır veri etiketi bulunan sütun grafiği](multiple-rows-of-labels.png)

## **FAQ**

**Yoğun grafiklerde veri etiketlerinin üst üste binmesini nasıl önleyebilirim?**

Otomatik etiket yerleştirmeyi, lider çizgilerini ve küçültülmüş yazı tipi boyutunu birleştirin; gerekirse bazı alanları (örneğin, kategori) gizleyin veya yalnızca uç değerler ya da ana noktalar için etiket gösterin.

**Sıfır, negatif veya boş değerler için etiketleri sadece nasıl devre dışı bırakabilirim?**

Etiketleri etkinleştirmeden önce veri noktalarını filtreleyin ve tanımlı bir kurala göre 0, negatif veya eksik değerler için gösterimi kapatın.

**PDF/görsellere dışa aktarırken tutarlı bir etiket stili nasıl sağlanır?**

Yazı tipi ailesini ve boyutunu açıkça ayarlayın ve fallback oluşmasını önlemek için render ortamında yazı tipinin mevcut olduğunu doğrulayın.