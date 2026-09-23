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
description: "PowerPoint sunumlarına Aspose.Slides for Python via .NET kullanarak grafik veri etiketlerini eklemeyi ve biçimlendirmeyi öğrenin, daha etkileyici slaytlar için."
---
## **Giriş**

Veri etiketleri, grafik serileri ve tek tek veri noktaları hakkında bilgi gösterir ve okuyucuların değerleri tanımasına ve grafiği anlamasına yardımcı olur. Bu makale, değerleri biçimlendirme, yüzde gösterme, etiket metnini okuma, kategori ekseni etiketi aralığını ayarlama ve pasta grafiği etiketlerini konumlandırma konularını açıklar.

## **Grafik Veri Etiketlerinde Veri Hassasiyetini Ayarlama**

Seri değerlerini biçimlendirmek için [number_format_of_values](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartseries/number_format_of_values/) kullanın. Bu örnek, varsayılan verilerle bir çizgi grafiği oluşturur, veri tablosunu gösterir ve ilk seri için değer etiketlerini etkinleştirir. `#,##0.00` biçimi, binlik ayırıcı ve iki ondalık basamak gösterir ve temel değerleri değiştirmez.

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

Yığınlı bir sütun grafik için, her değeri kategori toplamının yüzdesi olarak hesaplayın ve metni [text_frame_for_overriding](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/) aracılığıyla atayın. Bu örnek, varsayılan grafik verilerini kullanır ve yüzdeyi 8 puanlık bir yazı tipinde iki ondalık basamakla gösterir. Toplamı sıfır olan kategoriler, bölme hatasından kaçınmak için atlanır. Grafik verileri değişirse özel etiket metnini yeniden hesaplayın.

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

Değerler kesir olarak depolandığında, yüzde göstermek için [number_format](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/datalabelformat/number_format/) kullanın. Etiket biçimini kaynak hücrelerden bağımsız olarak uygulamak için [is_number_format_linked_to_source](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) özelliğini `False` olarak ayarlayın.

Bu örnek, dört kategori boyunca kırmızı ve mavi serilerle %100 yığınlı bir sütun grafik oluşturur. Her değer çifti toplamı 1'dir. `0.0%` etiket biçimi, 0.30 değerini %30.0 olarak gösterir; dikey eksen iki ondalık basamak kullanır. Her iki seri de beyaz, 10 puanlık etiket metni kullanır.

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

[get_actual_label_text](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) kullanarak bir veri etiketinin ayarları tarafından üretilen metni alabilirsiniz. Bu, raporlar için etiketleri çıkarmak, sunum içeriğinde arama yapmak veya oluşturulan grafikleri doğrulamak için faydalıdır. Aşağıdaki örnekte, varsayılan [data label format](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/datalabelformat/) her kategori adını, seri adını ve değeri birleştirir. Bir nokta değerini yüzde olarak biçimler, bir diğeri ise [text_frame_for_overriding](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/) üzerinden özel metin kullanır.

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

Bir veri noktasında depolanan sayı `0.75` olarak kalır, etiketinde kategori ve seri adlarıyla birlikte `75%` gösterse bile. Özel metin, oluşturulan etiket metninin yerini alır. [get_actual_label_text](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) her iki durumda da sonuç etiket dizesini döndürür. Sadece görünen etiketleri çıkarmak istediğinizde, yukarıda gösterildiği gibi, [is_visible](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/datalabel/is_visible/) ayrı ayrı kontrol edin.

## **Etiketi Eksen’den Uzaklık Olarak Ayarlama**

[label_offset](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/axis/label_offset/) kullanarak kategori ekseni etiketleri ile eksen arasındaki mesafeyi kontrol edebilirsiniz. Değer, eksen etiketlerinin maksimum yazı tipi boyutunun bir yüzdesidir. Bu örnek, kümelenmiş bir sütun grafik oluşturur ve yatay eksen etiketi ofsetini 500 olarak ayarlar. Bu ayar, bireysel veri noktalarına eklenmiş etiketlerden ziyade kategori ekseni etiketlerini etkiler.

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

Bir pasta grafiğinde, veri etiketi konumlarını ayarlayarak boşlukları iyileştirin ve gösterge çizgileri için yer açın.

Bu örnek, ilk veri noktasının değerini gösterir, etiketini dilimin dışına konumlandırır ve [x](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/datalabel/x/) ve [y](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/datalabel/y/) ofsetlerini ayarlar. Bu ofsetler, sırasıyla grafik genişliği ve yüksekliğine göre relatifdir.

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

![Ayarlanmış veri etiketi konumu](pie-chart-adjusted-label.png)

## **SSS**

**Yoğun grafiklerde veri etiketlerinin üst üste binmesini nasıl önleyebilirim?**  
Otomatik etiket konumlandırma, gösterge çizgileri ve küçültülmüş yazı tipi boyutunu birleştirin; gerekirse bazı alanları (örneğin kategori) gizleyin veya yalnızca uç değerler veya ana noktalar için etiketleri gösterin.

**Sıfır, negatif veya boş değerler için yalnızca etiketleri nasıl devre dışı bırakabilirim?**  
Etiketleri etkinleştirmeden önce veri noktalarını filtreleyin ve tanımlı bir kurala göre 0, negatif veya eksik değerlerin gösterimini kapatın.

**PDF/görsellere dışa aktarırken tutarlı bir etiket stili nasıl sağlanır?**  
Yazı tipi ailesi ve boyutunu açıkça ayarlayın ve yedekleme (fallback) oluşmaması için yazı tipinin oluşturma ortamında mevcut olduğundan emin olun.