---
title: Python ile Sunumlarda Pasta Grafiklerini Özelleştirme
linktitle: Pasta Grafik
type: docs
url: /tr/python-net/pie-chart/
keywords:
- pasta grafik
- grafik yönetimi
- grafik özelleştirme
- grafik seçenekleri
- grafik ayarları
- çizim seçenekleri
- dilim rengi
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides ile Python’da pasta grafikler oluşturun ve özelleştirin. İkincil çizimleri yapılandırın, veri etiketlerini gösterin ve PowerPoint’te otomatik dilim renkleri uygulayın."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde pasta grafikleriyle nasıl çalışılacağını açıklar. Pie of Pie ve Bar of Pie grafikleri için ikincil çizim seçeneklerinin nasıl yapılandırılacağını ve standart bir pasta grafiği için otomatik dilim renklendirmesinin nasıl etkinleştirileceğini gösterir.

Örnekler, bir slayta grafik ekleme, seri ve etiket ayarlarını ayarlama, varsayılan grafik verilerini özel kategoriler ve değerlerle değiştirme ve güncellenen sunumu kaydetme gibi grafik özelleştirme görevlerine odaklanır.

## **Pie of Pie ve Bar of Pie Grafikleri için İkincil Çizim Seçenekleri**

Aspose.Slides for Python via .NET, Pie of Pie ve Bar of Pie grafikleri için ikincil çizim seçeneklerini destekler. Bu seçenekler, ikincil çizimin boyutunu ve veri noktalarının iki çizim arasında nasıl bölündüğünü kontrol eder.

Aşağıdaki örnek, yeni bir sunumda Pie of Pie grafiği oluşturur ve veri noktası değerlerini etiket olarak gösterir. [second_pie_size](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/second_pie_size/) özelliği, ikincil çizim boyutunu ana çizimin %149'una ayarlar. [pie_split_by](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_by/) yüzde temelli bölmeyi seçer ve [pie_split_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_position/) eşik değerini %53 olarak ayarlar.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 500, 400)
    series = chart.chart_data.series[0]

    # Değerleri göster ve ikincil çizimi yapılandır.
    series.labels.default_data_label_format.show_value = True
    series_group = series.parent_series_group
    series_group.second_pie_size = 149
    series_group.pie_split_by = charts.PieSplitType.BY_PERCENTAGE
    series_group.pie_split_position = 53

    presentation.save("pie_of_pie.pptx", slides.export.SaveFormat.PPTX)
```

### **İkincil Çizim için Kategorileri Seçin**

Özel bölme, belirli kategorileri yüzde değerlerinden bağımsız olarak ikincil çizimde gruplamak istediğinizde kullanılır. Örneğin, bir satış raporu Online ve Events'i birlikte gösterebilir, böylece okuyucular bu iki kanalı karşılaştırabilir; toplam satışın %35 ve %10'undan sorumlu olmalarına rağmen.

[pie_split_by](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_by/) özelliğini [PieSplitType.CUSTOM](https://reference.aspose.com/slides/python-net/aspose.slides.charts/piesplittype/) olarak ayarlayın ve noktaları [pie_split_custom_points](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_custom_points/) aracılığıyla seçin. Koleksiyonun [add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/piesplitcustompointcollection/add/) yöntemi, serideki sıfır‑tabanlı bir indeks ya da bir veri noktası nesnesi kabul eder. Bu örnekte, indeks 1 Online'ı, indeks 3'teki nokta Events'i seçer. Partners da geçici olarak eklenir ve ardından [remove](https://reference.aspose.com/slides/python-net/aspose.slides.charts/piesplitcustompointcollection/) ile çıkarılır.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 600, 200)

    # Varsayılan verileri kanal bazında satışlarla değiştir.
    workbook = chart.chart_data.chart_data_workbook
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    category_names = ["Retail", "Online", "Partners", "Events"]
    values = [40, 35, 15, 10]
    series_name_cell = workbook.get_cell(0, 0, 1, "Sales")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    for i, category_name in enumerate(category_names):
        category_cell = workbook.get_cell(0, i + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, values[i])
        series.data_points.add_data_point_for_pie_series(value_cell)

    series.labels.default_data_label_format.show_value = True
    series_group = series.parent_series_group
    series_group.pie_split_by = charts.PieSplitType.CUSTOM
    series_group.is_color_varied = True

    # Online'ı sıfır tabanlı indeksiyle ve Events'i veri noktası nesnesiyle seç.
    series_group.pie_split_custom_points.add(1)
    series_group.pie_split_custom_points.add(series.data_points[3])

    # Partners'ı kaynağındaki veriyi silmeden seçim dışı bırak.
    series_group.pie_split_custom_points.add(2)
    series_group.pie_split_custom_points.remove(series.data_points[2])

    presentation.save("pie_of_pie_custom.pptx", slides.export.SaveFormat.PPTX)
```

Online (35) ve Events (10) ikincil çizimde ayrı dilimler olarak görünür. Birincil çizimde, Retail (40) ve Partners (15) ile birlikte, 45 değerinde tek bir birleşik dilimle temsil edilirler. Partners'ı özel seçimden kaldırmak, onu birincil çizimde tutar; kategori ya da değeri grafik kaynak verilerinden silmez.

Aşağıdaki resim, kaydedilmiş sunumu PowerPoint'te gösterir:

![İkincil çizimde Online ve Events içeren Pie of Pie grafiği ve birincil çizimde birleşik değeri 45](pie_of_pie_custom.png)

## **Otomatik Pasta Grafiği Dilim Renklerini Ayarlama**

Aspose.Slides for Python via .NET, pasta grafik dilimlerine otomatik olarak farklı renkler atayabilir. Aşağıdaki örnek, ortalanmış bir başlıkla bir pasta grafiği oluşturur ve varsayılan verileri üç çeyrek kategori ve değerleriyle değiştirir. [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) özelliği 20, 50 ve 30 değerlerini etiket olarak gösterirken, [is_color_varied](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/is_color_varied/) her dilim için ayrı bir renk etkinleştirir.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 100, 100, 400, 400)

    # Ortalanmış bir grafik başlığı ekle.
    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    # İlk çalışma sayfasını kullanarak varsayılan verileri değiştir.
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    category_names = ["First Qtr", "2nd Qtr", "3rd Qtr"]
    values = [20, 50, 30]
    series_name_cell = workbook.get_cell(worksheet_index, 0, 1, "Series 1")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    for i, category_name in enumerate(category_names):
        category_cell = workbook.get_cell(worksheet_index, i + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(worksheet_index, i + 1, 1, values[i])
        series.data_points.add_data_point_for_pie_series(value_cell)

    # Değerleri göster ve dilimlere farklı renkler ata.
    series.labels.default_data_label_format.show_value = True
    series.parent_series_group.is_color_varied = True

    presentation.save("pie.pptx", slides.export.SaveFormat.PPTX)
```

## **SSS**

**Pie of Pie ve Bar of Pie varyasyonları destekleniyor mu?**

Evet, kütüphane [destekler](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) pasta grafikler için bir ikincil çizim sağlar; bu, Pie of Pie ve Bar of Pie türlerini içerir.

**Sadece grafiği bir görüntü olarak (örneğin, PNG) dışa aktarabilir miyim?**

Evet, [grafiği doğrudan bir görüntü olarak dışa aktarabilirsiniz](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/get_image/) (örneğin PNG) tüm sunumu dışa aktarmadan.