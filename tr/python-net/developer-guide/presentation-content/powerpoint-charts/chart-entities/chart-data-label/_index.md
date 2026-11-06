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
description: "Aspose.Slides for Python via .NET kullanarak PowerPoint sunumlarına grafik veri etiketleri eklemeyi ve biçimlendirmeyi öğrenerek daha etkileyici slaytlar oluşturun."
---
## **Giriş**

Veri etiketleri, grafik serileri ve tek tek veri noktaları hakkında bilgi gösterir, okuyucuların değerleri tanımlamasına ve grafiği anlamasına yardımcı olur. Bu makale, değerleri biçimlendirme, yüzde görüntüleme, etiket metnini okuma, eksen maksimumunun ötesinde etiketleri kontrol etme, kategori ekseni etiketi aralığını ayarlama ve pasta grafik etiketlerini konumlandırma konularını açıklar.

## **Görünür Veri Etiketlerini Sayma**

Sunum yayımlamadan önce kaç veri etiketinin görüntülenmek üzere etkinleştirildiğini kontrol etmek için [count_of_visible_data_labels](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelcollection/count_of_visible_data_labels/) kullanın. Koleksiyondaki etiketlerin toplam sayısını döndüren `len(labels)`'ın aksine, seri varsayılanlarını ve tek tek etiket ayarlarını dikkate alır.

Bu örnek, bir seriye ve üç veri noktasına sahip bir sütun grafiği oluşturur. Serinin [labels](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/labels/) koleksiyonuna erişir ve ayarlar değiştikçe görünür sayıyı **0, 3, 2, 3** olarak yazdırır. Toplam sayısı **3** olarak kalır.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    series_cell = workbook.get_cell(0, 0, 1, "Values")
    series = chart.chart_data.series.add(series_cell, chart.type)

    for i in range(3):
        category_cell = workbook.get_cell(0, i + 1, 0, f"Category {i + 1}")
        chart.chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(0, i + 1, 1, (i + 1) * 10)
        series.data_points.add_data_point_for_bar_series(value_cell)

    labels = series.labels
    print(f"Total: {len(labels)}; visible: {labels.count_of_visible_data_labels}")  # Toplam: 3; görünür: 0

    labels.default_data_label_format.show_value = True
    print(f"Visible: {labels.count_of_visible_data_labels}")  # Görünür: 3

    labels[1].data_label_format.show_value = False
    print(f"Visible: {labels.count_of_visible_data_labels}")  # Görünür: 2

    labels[1].data_label_format.show_legend_key = True
    print(f"Visible: {labels.count_of_visible_data_labels}")  # Görünür: 3
```

Serinin [default_data_label_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelcollection/default_data_label_format/) varsayılan ayarları sağlar. Burada [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) etkinleştirildiğinde üç etiketin de değerleri görüntülenir. Bir etiketin [data_label_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/data_label_format/) üzerinden `False` olarak ayarlanması, seçilen etiket için bu ayarı geçersiz kılar. [show_legend_key](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_legend_key/) etkinleştirildiğinde, değeri gizli kalsa bile, o etiket tekrar görünür sayılır.

Görünür sayım, görünürlük ayarlarını yansıtır. Etiketlerin çakışıp çakışmadığını, kesilip kesilmediğini veya render edilen grafikte okunabilir olup olmadığını ölçmez.

## **Grafik Veri Etiketlerinde Veri Hassasiyetini Ayarlama**

[number_format_of_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/number_format_of_values/) kullanarak seri değerlerini biçimlendirin. Bu örnek, varsayılan verilere sahip bir çizgi grafiği oluşturur, veri tablosunu gösterir ve ilk seri için değer etiketlerini etkinleştirir. `#,##0.00` biçimi, binlik ayırıcı ve iki ondalık basamak gösterir; temel değerleri değiştirmez.

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

Grafiğin gömülü çalışma kitabındaki sayısal hücreleri biçimlendirmek için [Set Custom Number Formats for Workbook Cells](/slides/tr/python-net/chart-workbook/#set-custom-number-formats-for-workbook-cells) bölümüne bakın. Bu örnek ayrıca, değer etiketlerinin kaynak hücre biçimlerini takip ettiğini ve depolanan sayısal değerlerin korunduğunu gösterir.

## **Yüzdeyi Etiket Olarak Görüntüleme**

Yığılmış sütun grafik için, her değeri kategori toplamının yüzde olarak hesaplayın ve metni [text_frame_for_overriding](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/) öğesine atayın. Bu örnek varsayılan grafik verilerini kullanır ve yüzde değerlerini 8 puan boyutunda, iki ondalık basamakla gösterir. Toplamı sıfır olan kategoriler, bölme hatasını önlemek için atlanır. Grafik verileri değişirse, özel etiket metnini yeniden hesaplayın.

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

Değerler kesir olarak depolandığında, yüzde göstermek için [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/number_format/) kullanın. Etiket biçimini kaynak hücrelerden bağımsız uygulamak için [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) özelliğini `False` olarak ayarlayın.

Bu örnek, dört kategoriye yayılmış kırmızı ve mavi serilerle %100 yığılmış bir sütun grafiği oluşturur. Her değer çifti 1’e toplanır. Etiket biçimi `0.0%`, 0.30 değerini %30.0 olarak gösterirken, dikey eksen iki ondalık basamak kullanır. Her iki seri de beyaz, 10 puan boyutunda etiket metni kullanır.

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

[get_actual_label_text](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) kullanarak bir veri etiketinin ayarları tarafından üretilen metni alın. Bu, raporlar için etiketleri çıkarmak, sunum içeriğinde arama yapmak veya oluşturulan grafikleri doğrulamak gerektiğinde yararlıdır. Aşağıdaki örnekte, varsayılan [data label format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/) her kategori adını, seri adını ve değeri birleştirir. Bir nokta değerini yüzde olarak biçimler, diğeri ise [text_frame_for_overriding](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/) üzerinden özel metin kullanır.

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

Bir veri noktasında saklanan sayı `0.75` olarak kalır, etiketinde kategori ve seri adlarıyla birlikte `%75` gösterilsede. Özel metin, oluşturulan etiket metninin yerini alır. [get_actual_label_text](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) her iki durumda da oluşan etiket dizesini döndürür. Yalnızca görünür etiketleri çıkarmak istediğinizde, yukarıda gösterildiği gibi, [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/is_visible/) ayrı olarak kontrol edin.

## **Eksen Maksimumunun Ötesinde Veri Etiketlerini Kontrol Etme**

Eksen aralığını manuel olarak sınırladığınızda, bazı veri noktaları maksimumu aşabilir. Bu veri noktalarının etiketlerinin gösterilip gösterilmeyeceğini kontrol etmek için [show_data_labels_over_maximum](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/show_data_labels_over_maximum/) kullanın. Bu ayar etiket görünürlüğünü değiştirir; eksen aralığını veya temel veri değerlerini değiştirmez.

Aşağıdaki örnek, 60 ve 120 değerlerine sahip 2B gruplanmış bir sütun grafiği oluşturur. Dikey eksende [is_automatic_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_max_value/) özelliğini `False` ve [max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/max_value/) özelliğini 100 olarak ayarlar. İlk slayt maksimumun ötesinde etiketlere izin verir; bu slaydın bir kopyası ise onları devre dışı bırakır. Her iki slayt da `DataLabelsOverMaximum.pptx` dosyasına kaydedilir.

[show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) ile değer etiketlerini etkinleştirin. Grafik düzeyindeki ayar, yalnızca değer görüntülemeyi etkinleştirmez veya bireysel bir etiketin devre dışı bırakılmış değer görüntülemesini geçersiz kılmaz. Bu örnek, tüm seri için değerleri etkinleştirir ve [position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/position/) kullanarak etiketleri her sütunun dış ucuna yerleştirir.

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

Aşağıdaki görseller, Microsoft PowerPoint tarafından render edilen kaydedilmiş slaytları gösterir. `True` ile **120** etiketi üst sınırda görünür; `False` ile gizlenir. **60** etiketi görünür kalır, eksen maksimumu **100** olarak kalır ve ikinci veri noktası her iki durumda da **120** olarak kalır.

| show_data_labels_over_maximum = True | show_data_labels_over_maximum = False |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
Bu örnek, değer ekseni olan 2B sütun grafiği kullanır. Pasta ve halka grafikleri gibi değer ekseni olmayan grafikler, bu şekilde sınırlanabilecek bir eksen maksimumuna sahip değildir.
{{% /alert %}}

## **Etiket Mesafesini Eksen'den Ayarlama**

[label_offset](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/label_offset/) kullanarak kategori ekseni etiketleri ile eksen arasındaki mesafeyi kontrol edin. Değer, eksen etiketlerinin maksimum yazı tipi boyutunun bir yüzdesidir. Bu örnek, gruplanmış bir sütun grafiği oluşturur ve yatay eksen etiketi kaydırmasını 500 olarak ayarlar. Bu ayar, bireysel veri noktalarına bağlı etiketler yerine kategori ekseni etiketlerini etkiler.

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

Bir pasta grafiğinde, veri etiketi konumlarını ayarlayarak boşlukları iyileştirin ve lider çizgileri için alan oluşturun.

Bu örnek, ilk veri noktasının değerini gösterir, etiketini dilimin dışına yerleştirir ve [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/x/) ve [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/y/) kaydırmalarını ayarlar. Bu kaydırmalar, sırasıyla grafiğin genişliği ve yüksekliğine göre relasyondur.

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

![Pie chart with an adjusted data label position](pie-chart-adjusted-label.png)

## **Lider Çizgileri Biçimlendirme**

Pasta grafiği etiketleri dilimlerin dışına çıktığında, lider çizgileri okuyucuların her değeri doğru dilime eşleştirmesine yardımcı olur. Zıt bir renk ve biraz daha kalın bir çizgi bu bağlantıları takip etmeyi kolaylaştırırken, şeffaflık ve kesikli stil çizgileri görsel olarak müdahaleci olmaktan uzak tutar.

[leader_lines_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelcollection/leader_lines_format/) kullanarak serinin veri etiketi koleksiyonu seviyesinde lider çizgileri biçimlendirin. `series.labels.leader_lines_format.line` içindeki ayarlar, bireysel bir etikete değil koleksiyona uygulanır.

Bu örnek, varsayılan verilerle bir pasta grafiği oluşturur, değerleri dilimlerin dışına gösterir ve [show_leader_lines](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_leader_lines/) etkinleştirir. [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/x/) ve [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/y/) kaydırmalarıyla iki etiketi dilimlerinden daha uzağa taşır; bu kaydırmalar grafik genişliği ve yüksekliğinin kesirleri olarak ifade edilir. Giriş sunumu gerektirmez.

Çizginin [fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/fill_format/) özelliği, 255 üzerinden 191 alfa değerine sahip katı mavi bir renk ayarlar; bu yaklaşık %25 şeffaflık verir. [width](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/width/) kalınlığı 2 puan olarak belirler ve [dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/) çizgiyi kesikli yapar.

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

    # İki etiketi dilimlerinden daha uzakta taşı.
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

Lider çizgileri etkinleştirmek, her etiket için bir çizgi belireceği anlamına gelmez. Görünürlük, etiket konumlandırmasına ve grafiğin yerleşim davranışına bağlıdır. Bu örnekte, iki kaydırılmış etiketin görünür lider çizgileri vardır; dilimlerine yakın kalan etiketlerin ise buna ihtiyacı yoktur.

Aşağıdaki görsel, Aspose.Slides ile render edilen kaydedilmiş `FormattedLeaderLines.pptx` dosyasını gösterir:

![Pie chart with blue, semitransparent dashed leader lines connecting two outside labels to their slices](formatted-leader-lines.png)

## **Bir Sütun Grafiğinin Üstüne Birden Çok Satır Veri Etiketi Ekleme**

Bu örnek, çizim alanının üstünde iki satır veri etiketi bulunan bir sütun grafiği oluşturur. Seri A görünür sütunları gösterirken, Seri B ve Seri C ek etiketleri sağlar. Bu serilerin sütunları, dolgu ve kenar çizgisi kaldırılarak gizlenir. [overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/overlap/) özelliği, üç seriyi aynı kategori merkezleriyle hizalar.

[plot_area](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/plot_area/) ayarları, etiket satırları için alan ayırır. [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) varsayılan konumları hesapladıktan sonra, [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/x/) ve [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/y/) yatay hizalamayı korur ve etiketi iki satıra düzenlemek için dikey kaydırmalar uygular. Sayılar, serilerin değerlerine bağlı veri etiketleri olarak kalır; sadece satır başlıkları ayrı metin şekilleridir.

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
            # B ve C sütunlarını gizle, ancak veri etiketlerini koru.
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

    # Çizim alanının üstünde iki satır veri etiketi için boşluk ayır.
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
            # varsayılan etiket konumundan bir kaymadır ve grafik yüksekliği oranı olarak ifade edilir.
            data_label.x = 0
            data_label.y = row_top - data_label.actual_y / chart.height

        # Satır başlığı sadece ayrı bir metin şeklidir.
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

![Column chart with two rows of data labels above the plot area](multiple-rows-of-labels.png)

## **SSS**

**Yoğun grafiklerde veri etiketlerinin çakışmasını nasıl önleyebilirim?**  
Otomatik etiket yerleşimini, lider çizgilerini ve küçültülmüş yazı tipini birleştirin; gerekirse bazı alanları (örneğin, kategori) gizleyin veya sadece uç değerler veya ana noktalar için etiket gösterin.

**Sıfır, negatif veya boş değerler için etiketleri yalnızca nasıl devre dışı bırakabilirim?**  
Etiketleri etkinleştirmeden önce veri noktalarını filtreleyin ve tanımlı bir kurala göre 0, negatif değerler veya eksik değerler için görüntülemeyi kapatın.

**PDF/görsellere dışa aktarırken tutarlı bir etiket stili nasıl sağlanır?**  
Yazı tipi ailesini ve boyutunu açıkça ayarlayın ve yedekleme olmaması için yazı tipinin render ortamında bulunabilir olduğunu doğrulayın.