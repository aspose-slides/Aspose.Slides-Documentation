---
title: Python’da PowerPoint Sunum Grafiklerini Oluşturma veya Güncelleme
linktitle: Grafiklerini Oluştur veya Güncelle
type: docs
weight: 10
url: /tr/python-net/create-chart/
keywords:
- grafik ekle
- grafik oluştur
- grafik düzenle
- grafik değiştir
- grafik güncelle
- dağınık grafik
- pasta grafik
- çizgi grafik
- ağaç haritası grafik
- stok grafik
- kutu ve whisker grafik
- huni grafik
- sunburst grafik
- histogram grafik
- radar grafik
- çok kategorili grafik
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET kullanarak PowerPoint sunumlarında grafik oluşturun ve özelleştirin. Grafikleri ekleyin, biçimlendirin ve Python’da pratik kod örnekleriyle düzenleyin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for Python via .NET kullanarak grafik oluşturma ve özelleştirme konusunda kapsamlı bir rehber sunar. Bir slayta programlı olarak grafik eklemeyi, verilerle doldurmayı ve belirli tasarım gereksinimlerinize uygun çeşitli biçimlendirme seçeneklerini uygulamayı öğreneceksiniz. Makale boyunca, sunumu ve grafik nesnesini başlatmadan seri, eksen ve lejandları yapılandırmaya kadar her adımı gösteren ayrıntılı kod örnekleri yer alır. Bu rehberi izleyerek, Python uygulamalarınıza dinamik grafik üretimini entegre etme konusunda sağlam bir anlayış kazanacak ve veri odaklı sunumlar oluşturma sürecini kolaylaştıracaksınız.

## **Grafik Oluşturma**

Grafikler, verileri hızlı bir şekilde görselleştirerek bir tablo veya elektronik tablodan hemen anlaşılmayabilecek içgörüler elde etmeye yardımcı olur.

**Grafik Neden Oluşturulur?**

Grafik kullanarak:

* büyük miktarda veriyi tek bir slayt içinde toplamak, sıkıştırmak veya özetlemek;
* verideki desen ve eğilimleri ortaya çıkarmak;
* zaman içinde ya da belirli bir ölçü birimine göre verinin yönünü ve ivmesini çıkarmak;
* aykırı değerleri, sapmaları, hataları ve mantıksız verileri tespit etmek;
* karmaşık verileri iletmek veya sunmak.

PowerPoint'te, *Insert* işlevi aracılığıyla birçok grafik tipi için şablonlar sağlayan grafikler oluşturabilirsiniz. Aspose.Slides kullanarak, hem düzenli grafikler (popüler grafik tiplerine dayalı) hem de özel grafikler oluşturabilirsiniz.

{{% alert color="info" title="Note" %}}
Bu kodlamada, [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) sayımını, [aspose.slides.charts](https://reference.aspose.com/slides/python-net/aspose.slides.charts/) modülü altında kullanın. Bu sayımdaki değerler farklı grafik türlerine karşılık gelir.
{{% /alert %}}

### **Küme Sütun Grafikleri Oluşturma**

Bu örnek, iki seriyi üç kategori boyunca karşılaştıran bir küme sütun grafiği oluşturmak için [add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) yöntemini kullanır. Seriler kırmızı ve yeşil dolgu renkleri kullanır ve bireysel etiketler kategori adlarını, seri adlarını ve değerleri gösterir. Çalışma sayfası indeksi 0, gömülü grafik çalışma kitabındaki ilk sayfayı ifade eder.

```python
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    series_name_cell = workbook.get_cell(worksheet_index, 0, 1, "Series 1")
    chart.chart_data.series.add(series_name_cell, chart.type)
    series_name_cell = workbook.get_cell(worksheet_index, 0, 2, "Series 2")
    chart.chart_data.series.add(series_name_cell, chart.type)

    category_cell = workbook.get_cell(worksheet_index, 1, 0, "Category 1")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(worksheet_index, 2, 0, "Category 2")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(worksheet_index, 3, 0, "Category 3")
    chart.chart_data.categories.add(category_cell)

    series = chart.chart_data.series[0]

    value_cell = workbook.get_cell(worksheet_index, 1, 1, 20)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 2, 1, 50)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 3, 1, 30)
    series.data_points.add_data_point_for_bar_series(value_cell)

    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.red

    series = chart.chart_data.series[1]

    value_cell = workbook.get_cell(worksheet_index, 1, 2, 30)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 2, 2, 10)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 3, 2, 60)
    series.data_points.add_data_point_for_bar_series(value_cell)

    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.green

    label = series.data_points[0].label
    label.data_label_format.show_category_name = True

    label = series.data_points[1].label
    label.data_label_format.show_series_name = True

    label = series.data_points[2].label
    label.data_label_format.show_value = True
    label.data_label_format.show_series_name = True
    label.data_label_format.separator = "/"

    presentation.save("AsposeChart.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Küme Sütun Grafiği](clustered_column_chart.png)

### **Saçılım Grafikleri Oluşturma**

Saçılım grafikleri (saçılım diyagramları veya x-y grafikleri olarak da bilinir) genellikle iki değişken arasındaki desenleri kontrol etmek veya korelasyonları göstermek için kullanılır.

Aşağıdaki durumlarda bir saçılım grafiği kullanın:

* Eşlenmiş sayısal verileriniz var.
* Birlikte iyi eşleşen iki değişkeniniz var.
* İki değişkenin ilişkili olup olmadığını belirlemek istiyorsunuz.
* Bağımlı bir değişken için birden fazla değere sahip bağımsız bir değişkeniniz var.

Bu örnek iki x-y değeri kümesini çizer. İlk seri yıldız işaretçileriyle düz çizgiler kullanırken, ikinci seri dairesel işaretçileriyle yumuşak çizgeler kullanır; her ikisi de 10 [size](https://reference.aspose.com/slides/python-net/aspose.slides.charts/marker/size/) değerini kullanır. [symbol](https://reference.aspose.com/slides/python-net/aspose.slides.charts/marker/symbol/) özelliği işaretçi şeklinin kontrolünü sağlar.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.SCATTER_WITH_SMOOTH_LINES, 20, 20, 500, 300)

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    chart.chart_data.series.clear()

    series_name_cell = workbook.get_cell(worksheet_index, 1, 1, "Series 1")
    chart.chart_data.series.add(series_name_cell, chart.type)
    series_name_cell = workbook.get_cell(worksheet_index, 1, 3, "Series 2")
    chart.chart_data.series.add(series_name_cell, chart.type)

    series = chart.chart_data.series[0]

    x_value_cell = workbook.get_cell(worksheet_index, 2, 1, 1)
    y_value_cell = workbook.get_cell(worksheet_index, 2, 2, 3)
    series.data_points.add_data_point_for_scatter_series(x_value_cell, y_value_cell)

    x_value_cell = workbook.get_cell(worksheet_index, 3, 1, 2)
    y_value_cell = workbook.get_cell(worksheet_index, 3, 2, 10)
    series.data_points.add_data_point_for_scatter_series(x_value_cell, y_value_cell)

    series.type = charts.ChartType.SCATTER_WITH_STRAIGHT_LINES_AND_MARKERS

    series.marker.size = 10
    series.marker.symbol = charts.MarkerStyleType.STAR

    series = chart.chart_data.series[1]

    x_value_cell = workbook.get_cell(worksheet_index, 2, 3, 5)
    y_value_cell = workbook.get_cell(worksheet_index, 2, 4, 2)
    series.data_points.add_data_point_for_scatter_series(x_value_cell, y_value_cell)

    x_value_cell = workbook.get_cell(worksheet_index, 3, 3, 3)
    y_value_cell = workbook.get_cell(worksheet_index, 3, 4, 1)
    series.data_points.add_data_point_for_scatter_series(x_value_cell, y_value_cell)

    x_value_cell = workbook.get_cell(worksheet_index, 4, 3, 2)
    y_value_cell = workbook.get_cell(worksheet_index, 4, 4, 2)
    series.data_points.add_data_point_for_scatter_series(x_value_cell, y_value_cell)

    x_value_cell = workbook.get_cell(worksheet_index, 5, 3, 5)
    y_value_cell = workbook.get_cell(worksheet_index, 5, 4, 1)
    series.data_points.add_data_point_for_scatter_series(x_value_cell, y_value_cell)

    series.marker.size = 10
    series.marker.symbol = charts.MarkerStyleType.CIRCLE

    presentation.save("AsposeChart.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Saçılım Grafiği](scatter_chart.png)

### **Pasta Grafikleri Oluşturma**

Pasta grafikleri, özellikle veri kategorik etiketlere sayısal değerlerle eşlik ettiğinde, parçanın bütünle olan ilişkisini göstermek için en uygundur. Ancak veri çok sayıda parça veya etiket içeriyorsa, çubuk grafik kullanmayı düşünebilirsiniz.

Bu örnek, üç çeyrek değeri içeren bir pasta grafiği oluşturur. Her dilim özel dolgu ve kenarlık ile tasarlanmıştır ve etiketler değer, yüzde ve seri bilgilerini farklı kombinasyonlarda gösterir. [first_slice_angle](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/first_slice_angle/) özelliği ilk dilimi 180 derecede başlatır.

```python
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 20, 20, 500, 300)

    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    category_cell = workbook.get_cell(0, 1, 0, "1st Qtr")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, 2, 0, "2nd Qtr")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, 3, 0, "3rd Qtr")
    chart.chart_data.categories.add(category_cell)

    series_name_cell = workbook.get_cell(0, 0, 1, "Series 1")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    value_cell = workbook.get_cell(worksheet_index, 1, 1, 20)
    series.data_points.add_data_point_for_pie_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 2, 1, 50)
    series.data_points.add_data_point_for_pie_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 3, 1, 30)
    series.data_points.add_data_point_for_pie_series(value_cell)

    chart.chart_data.series_groups[0].is_color_varied = True

    first_slice = series.data_points[0]
    first_slice.format.fill.fill_type = slides.FillType.SOLID
    first_slice.format.fill.solid_fill_color.color = draw.Color.cyan

    first_slice.format.line.fill_format.fill_type = slides.FillType.SOLID
    first_slice.format.line.fill_format.solid_fill_color.color = draw.Color.gray
    first_slice.format.line.width = 3.0
    first_slice.format.line.style = slides.LineStyle.THIN_THICK
    first_slice.format.line.dash_style = slides.LineDashStyle.LARGE_DASH

    second_slice = series.data_points[1]
    second_slice.format.fill.fill_type = slides.FillType.SOLID
    second_slice.format.fill.solid_fill_color.color = draw.Color.brown

    second_slice.format.line.fill_format.fill_type = slides.FillType.SOLID
    second_slice.format.line.fill_format.solid_fill_color.color = draw.Color.blue
    second_slice.format.line.width = 3.0
    second_slice.format.line.style = slides.LineStyle.SINGLE
    second_slice.format.line.dash_style = slides.LineDashStyle.LARGE_DASH_DOT

    third_slice = series.data_points[2]
    third_slice.format.fill.fill_type = slides.FillType.SOLID
    third_slice.format.fill.solid_fill_color.color = draw.Color.coral

    third_slice.format.line.fill_format.fill_type = slides.FillType.SOLID
    third_slice.format.line.fill_format.solid_fill_color.color = draw.Color.red
    third_slice.format.line.width = 2.0
    third_slice.format.line.style = slides.LineStyle.THIN_THIN
    third_slice.format.line.dash_style = slides.LineDashStyle.LARGE_DASH_DOT_DOT

    first_label = series.data_points[0].label
    first_label.data_label_format.show_value = True

    second_label = series.data_points[1].label
    second_label.data_label_format.show_value = True
    second_label.data_label_format.show_legend_key = True
    second_label.data_label_format.show_percentage = True

    third_label = series.data_points[2].label
    third_label.data_label_format.show_series_name = True
    third_label.data_label_format.show_percentage = True

    series.labels.default_data_label_format.show_leader_lines = True

    chart.chart_data.series_groups[0].first_slice_angle = 180

    presentation.save("PieChart.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Pasta Grafiği](pie_chart.png)

### **Çizgi Grafikleri Oluşturma**

Çizgi grafikleri (çizgi diyagramları olarak da bilinir), değerlerin zaman içindeki değişimini göstermek istediğiniz durumlarda en uygunudur. Çizgi grafiği kullanarak büyük miktarda veriyi aynı anda karşılaştırabilir, zaman içinde değişim ve eğilimleri izleyebilir, veri serilerindeki anormallikleri vurgulayabilirsiniz.

Bu örnek, varsayılan seri ve kategorilerle bir çizgi grafiği oluşturmak için [add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) yöntemini kullanır ve ardından sunumu PPTX olarak kaydeder.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    line_chart = slide.shapes.add_chart(charts.ChartType.LINE, 20, 20, 500, 300)

    presentation.save("lineChart.pptx", slides.export.SaveFormat.PPTX)
```

Varsayılan olarak, bir çizgi grafiğindeki noktalar düz sürekli çizgilerle birleştirilir. Noktaların tireli bir çizgiyle birleştirilmesini istiyorsanız, [dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/) özelliğini [LineDashStyle](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/) içindeki bir değere ayarlayın:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    line_chart = slide.shapes.add_chart(charts.ChartType.LINE, 20, 20, 500, 300)

    for series in line_chart.chart_data.series:
        series.format.line.dash_style = slides.LineDashStyle.DASH
```

Sonuç:

![Çizgi Grafiği](line_chart.png)

### **Ağaç Haritası Grafikleri Oluşturma**

Ağaç haritası grafikleri, satış verileri gibi kategorilerin göreceli boyutlarını göstermek ve her kategori içinde büyük katkı sağlayan öğelere dikkat çekmek için en uygundur.

Bu örnek, dört gövde ve iki dal içinde gruplanmış sekiz yapraktan oluşan bir ağaç haritası oluşturur. [set_grouping_item](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategorylevelsmanager/set_grouping_item/) yöntemi, 1. grup seviyesinde gövdeleri ve 2. seviyede dalları atar. Değerler, dikdörtgenin göreceli boyutlarını belirler, kategori etiketleri ve üst etiketlerin örtüşmesi hiyerarşiyi tanımlar.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.TREEMAP, 20, 20, 500, 300)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    # Şube 1
    category_cell = workbook.get_cell(0, "C1", "Leaf1")
    leaf = chart.chart_data.categories.add(category_cell)
    leaf.grouping_levels.set_grouping_item(1, "Stem1")
    leaf.grouping_levels.set_grouping_item(2, "Branch1")

    category_cell = workbook.get_cell(0, "C2", "Leaf2")
    chart.chart_data.categories.add(category_cell)

    category_cell = workbook.get_cell(0, "C3", "Leaf3")
    leaf = chart.chart_data.categories.add(category_cell)
    leaf.grouping_levels.set_grouping_item(1, "Stem2")

    category_cell = workbook.get_cell(0, "C4", "Leaf4")
    chart.chart_data.categories.add(category_cell)

    # Şube 2
    category_cell = workbook.get_cell(0, "C5", "Leaf5")
    leaf = chart.chart_data.categories.add(category_cell)
    leaf.grouping_levels.set_grouping_item(1, "Stem3")
    leaf.grouping_levels.set_grouping_item(2, "Branch2")

    category_cell = workbook.get_cell(0, "C6", "Leaf6")
    chart.chart_data.categories.add(category_cell)

    category_cell = workbook.get_cell(0, "C7", "Leaf7")
    leaf = chart.chart_data.categories.add(category_cell)
    leaf.grouping_levels.set_grouping_item(1, "Stem4")

    category_cell = workbook.get_cell(0, "C8", "Leaf8")
    chart.chart_data.categories.add(category_cell)

    series = chart.chart_data.series.add(charts.ChartType.TREEMAP)
    series.labels.default_data_label_format.show_category_name = True
    value_cell = workbook.get_cell(0, "D1", 4)
    series.data_points.add_data_point_for_treemap_series(value_cell)
    value_cell = workbook.get_cell(0, "D2", 5)
    series.data_points.add_data_point_for_treemap_series(value_cell)
    value_cell = workbook.get_cell(0, "D3", 3)
    series.data_points.add_data_point_for_treemap_series(value_cell)
    value_cell = workbook.get_cell(0, "D4", 6)
    series.data_points.add_data_point_for_treemap_series(value_cell)
    value_cell = workbook.get_cell(0, "D5", 9)
    series.data_points.add_data_point_for_treemap_series(value_cell)
    value_cell = workbook.get_cell(0, "D6", 9)
    series.data_points.add_data_point_for_treemap_series(value_cell)
    value_cell = workbook.get_cell(0, "D7", 4)
    series.data_points.add_data_point_for_treemap_series(value_cell)
    value_cell = workbook.get_cell(0, "D8", 3)
    series.data_points.add_data_point_for_treemap_series(value_cell)

    series.parent_label_layout = charts.ParentLabelLayoutType.OVERLAPPING

    presentation.save("Treemap.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Ağaç Haritası Grafiği](treemap_chart.png)

### **Şelale Grafikleri Oluşturma**

Şelale grafiği, pozitif ve negatif değişikliklerin nihai değere nasıl katkıda bulunduğunu gösterir. Örneğin, bir kar hesabı gelirle başlayıp maliyetleri çıkarır ve diğer gelirleri ekler. Değişim sütunları önceki ve yeni birikimli değerler arasında süzülürken, toplam sütunlar sıfırdan birikimli değere uzanır.

Aşağıdaki örnek, bin ABD doları cinsinden tutarları kullanır:

| Kategori | Çalışma kitabı değeri | Sütun tipi |
| --- | ---: | --- |
| Revenue | 1000 | Artış |
| Cost of sales | -400 | Azalış |
| Gross profit | 600 | Ara toplam |
| Operating expenses | -200 | Azalış |
| Other income | 50 | Artış |
| Net profit | 450 | Son toplam |

Bir noktayı ara toplam veya son toplam olarak işaretlemek için [set_as_total](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/set_as_total/) özelliğini `True` olarak ayarlayın. O noktanın çalışma kitabı hücresine gerçek birikmiş tutarı yerleştirin: brüt kar için `600` (`1000 - 400`) ve net kar için `450` (`600 - 200 + 50`). Özellik sütunu toplam olarak işaretler; hücre değerini hesaplamaz veya doldurmaz. Sıfırı yer tutucu olarak kullanmayın ve toplam nokta için başka bir değişim sağlamayın. Toplam sütun, birikmiş değeri bir kez daha eklemeden gösterir.

Bu tam C# örneği, [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) içinde `Waterfall` üyesini kullanarak bir grafik oluşturur, varsayılan verileri temizler ve gömülü çalışma kitabını doldurur. Çalışma sayfası indeksi `0` ilk sayfayı seçer; A sütunu kategori adlarını, B sütunu değerleri içerir. Her değer hücresi, [add_data_point_for_waterfall_series](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/add_data_point_for_waterfall_series/) yöntemiyle eklenir. Sıfır‑tabanlı nokta indeksleri `2` ve `5` ara ve son toplamları tanımlar. [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) etkinleştirildiğinde tutarlar sütunlarda gösterilir. Giriş sunumu veya çalışma kitabı gerekli değildir.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.WATERFALL, 20, 20, 680, 200)

    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("Profit breakdown (USD thousands)")
    chart.chart_title.overlay = False
    chart.has_legend = False

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    workbook.clear(worksheet_index)

    series_name_cell = workbook.get_cell(worksheet_index, 0, 1, "Profit")
    series = chart.chart_data.series.add(series_name_cell, charts.ChartType.WATERFALL)
    categories = ["Revenue", "Cost of sales", "Gross profit", "Operating expenses", "Other income", "Net profit"]
    values = [1000, -400, 600, -200, 50, 450]

    for i in range(len(categories)):
        category_cell = workbook.get_cell(worksheet_index, i + 1, 0, categories[i])
        chart.chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(worksheet_index, i + 1, 1, values[i])
        series.data_points.add_data_point_for_waterfall_series(value_cell)

    # Üçüncü ve altıncı noktalar toplamları temsil eder, ek değişiklikler değildir.
    series.data_points[2].set_as_total = True
    series.data_points[5].set_as_total = True
    series.show_connector_lines = True
    series.labels.default_data_label_format.show_value = True

    presentation.save("WaterfallChart.pptx", slides.export.SaveFormat.PPTX)
```

Seri seviyesindeki [show_connector_lines](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/show_connector_lines/) özelliğini `True` yaparak ardışık sütunları bağlayan çizgileri gösterin ve birikimli değeri daha kolay takip edin. Bu çizgileri gizlemek için örnekteki atamayı `series.show_connector_lines = False` ile değiştirip kaydedin. Bu sadece çizgi görünürlüğünü etkiler, veri veya toplamları etkilemez.

Sonuç:

![Gelir, maliyetler, 600 brüt kar ve 450 net karı gösteren şelale grafiği, değer etiketleri ve bağlayıcı çizgilerle](waterfall_chart.png)

### **Stok Grafikleri Oluşturma**

Stok grafikleri, açılış, en yüksek, en düşük ve kapanış fiyatları gibi finansal verileri göstererek piyasa eğilimlerini ve volatiliteyi analiz etmeye yardımcı olur. Bu grafikler, hisse performansına dair temel içgörüler sunarak yatırımcılara ve analistlere bilinçli kararlar almada destek olur.

Bu örnek, dört seriyi sırasıyla açık‑yüksek‑düşük‑kapanış (OHLC) düzeninde ve üç kategoriyle bir stok grafiği oluşturur. [has_up_down_bars](https://reference.aspose.com/slides/python-net/aspose.slides.charts/updownbarsmanager/has_up_down_bars/) özelliği yukarı/aşağı çubukları etkinleştirir ve [hi_low_lines_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/hi_low_lines_format/) yüksek-düşük çizgileri kontrol eder; bireysel seri çizgileri ve ince yatay ızgaralar gizlenir.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.OPEN_HIGH_LOW_CLOSE, 20, 20, 500, 300, False)

    workbook = chart.chart_data.chart_data_workbook

    category_cell = workbook.get_cell(0, 1, 0, "A")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, 2, 0, "B")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, 3, 0, "C")
    chart.chart_data.categories.add(category_cell)

    series_name_cell = workbook.get_cell(0, 0, 1, "Open")
    chart.chart_data.series.add(series_name_cell, charts.ChartType.OPEN_HIGH_LOW_CLOSE)
    series_name_cell = workbook.get_cell(0, 0, 2, "High")
    chart.chart_data.series.add(series_name_cell, charts.ChartType.OPEN_HIGH_LOW_CLOSE)
    series_name_cell = workbook.get_cell(0, 0, 3, "Low")
    chart.chart_data.series.add(series_name_cell, charts.ChartType.OPEN_HIGH_LOW_CLOSE)
    series_name_cell = workbook.get_cell(0, 0, 4, "Close")
    chart.chart_data.series.add(series_name_cell, charts.ChartType.OPEN_HIGH_LOW_CLOSE)

    series = chart.chart_data.series[0]
    value_cell = workbook.get_cell(0, 1, 1, 72)
    series.data_points.add_data_point_for_stock_series(value_cell)
    value_cell = workbook.get_cell(0, 2, 1, 25)
    series.data_points.add_data_point_for_stock_series(value_cell)
    value_cell = workbook.get_cell(0, 3, 1, 38)
    series.data_points.add_data_point_for_stock_series(value_cell)

    series = chart.chart_data.series[1]
    value_cell = workbook.get_cell(0, 1, 2, 172)
    series.data_points.add_data_point_for_stock_series(value_cell)
    value_cell = workbook.get_cell(0, 2, 2, 57)
    series.data_points.add_data_point_for_stock_series(value_cell)
    value_cell = workbook.get_cell(0, 3, 2, 57)
    series.data_points.add_data_point_for_stock_series(value_cell)

    series = chart.chart_data.series[2]
    value_cell = workbook.get_cell(0, 1, 3, 12)
    series.data_points.add_data_point_for_stock_series(value_cell)
    value_cell = workbook.get_cell(0, 2, 3, 12)
    series.data_points.add_data_point_for_stock_series(value_cell)
    value_cell = workbook.get_cell(0, 3, 3, 13)
    series.data_points.add_data_point_for_stock_series(value_cell)

    series = chart.chart_data.series[3]
    value_cell = workbook.get_cell(0, 1, 4, 25)
    series.data_points.add_data_point_for_stock_series(value_cell)
    value_cell = workbook.get_cell(0, 2, 4, 38)
    series.data_points.add_data_point_for_stock_series(value_cell)
    value_cell = workbook.get_cell(0, 3, 4, 50)
    series.data_points.add_data_point_for_stock_series(value_cell)

    chart.chart_data.series_groups[0].up_down_bars.has_up_down_bars = True
    chart.chart_data.series_groups[0].hi_low_lines_format.line.fill_format.fill_type = slides.FillType.SOLID

    for stock_series in chart.chart_data.series:
        stock_series.format.line.fill_format.fill_type = slides.FillType.NO_FILL

    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    presentation.save("Stock-chart.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Stok Grafiği](stock_chart.png)

### **Kutu ve Whisker Grafikleri Oluşturma**

Kutu ve whisker grafikleri, medyan, çeyrekler ve olası aykırı değerler gibi temel istatistiksel ölçüleri özetleyerek verinin dağılımını göstermek için kullanılır. Keşifsel veri analizi ve istatistiksel çalışmalar sırasında veri değişkenliğini hızlıca anlamak ve anormallikleri tanımlamak için özellikle faydalıdır.

Bu örnek, altı değerden oluşan bir kutu ve whisker grafiği oluşturur. [quartile_method](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/quartile_method/) özelliği dışsal çeyrek hesaplamasını seçer. Örnek ayrıca ortalama çizgileri, ortalama işaretçileri, iç noktalar ve aykırı noktaları etkinleştirir.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.BOX_AND_WHISKER, 20, 20, 500, 300)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    category_cell = workbook.get_cell(0, "A1", "Category 1")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, "A2", "Category 2")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, "A3", "Category 3")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, "A4", "Category 4")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, "A5", "Category 5")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, "A6", "Category 6")
    chart.chart_data.categories.add(category_cell)

    series = chart.chart_data.series.add(charts.ChartType.BOX_AND_WHISKER)

    series.quartile_method = charts.QuartileMethodType.EXCLUSIVE
    series.show_mean_line = True
    series.show_mean_markers = True
    series.show_inner_points = True
    series.show_outlier_points = True

    value_cell = workbook.get_cell(0, "B1", 15)
    series.data_points.add_data_point_for_box_and_whisker_series(value_cell)
    value_cell = workbook.get_cell(0, "B2", 41)
    series.data_points.add_data_point_for_box_and_whisker_series(value_cell)
    value_cell = workbook.get_cell(0, "B3", 16)
    series.data_points.add_data_point_for_box_and_whisker_series(value_cell)
    value_cell = workbook.get_cell(0, "B4", 10)
    series.data_points.add_data_point_for_box_and_whisker_series(value_cell)
    value_cell = workbook.get_cell(0, "B5", 23)
    series.data_points.add_data_point_for_box_and_whisker_series(value_cell)
    value_cell = workbook.get_cell(0, "B6", 16)
    series.data_points.add_data_point_for_box_and_whisker_series(value_cell)

    presentation.save("BoxAndWhisker.pptx", slides.export.SaveFormat.PPTX)
```

### **Huni Grafikleri Oluşturma**

Huni grafikleri, bir süreçteki ardışık aşamaları görselleştirirken veri hacminin her adımda azaldığı durumları göstermek için kullanılır. Dönüşüm oranlarını analiz etmek, darboğazları belirlemek ve satış veya pazarlama süreçlerinin verimliliğini izlemek için özellikle yararlıdır.

Bu örnek, mevcut bir sunumun ilk slaytına bir huni grafiği eklemek için [add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) yöntemini kullanır. Varsayılan verileri altı kategori ve 50‑500 arası değerlerle değiştirir, ardından güncellenmiş sunumu kaydeder. Giriş sunumu en az bir slayt içermelidir.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("test.pptx") as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.FUNNEL, 50, 50, 500, 400)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    category_cell = workbook.get_cell(0, "A1", "Category 1")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, "A2", "Category 2")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, "A3", "Category 3")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, "A4", "Category 4")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, "A5", "Category 5")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, "A6", "Category 6")
    chart.chart_data.categories.add(category_cell)

    series = chart.chart_data.series.add(charts.ChartType.FUNNEL)

    value_cell = workbook.get_cell(0, "B1", 50)
    series.data_points.add_data_point_for_funnel_series(value_cell)
    value_cell = workbook.get_cell(0, "B2", 100)
    series.data_points.add_data_point_for_funnel_series(value_cell)
    value_cell = workbook.get_cell(0, "B3", 200)
    series.data_points.add_data_point_for_funnel_series(value_cell)
    value_cell = workbook.get_cell(0, "B4", 300)
    series.data_points.add_data_point_for_funnel_series(value_cell)
    value_cell = workbook.get_cell(0, "B5", 400)
    series.data_points.add_data_point_for_funnel_series(value_cell)
    value_cell = workbook.get_cell(0, "B6", 500)
    series.data_points.add_data_point_for_funnel_series(value_cell)

    presentation.save("Funnel.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Huni Grafiği](funnel_chart.png)

### **Sunburst Grafikleri Oluşturma**

Sunburst grafikleri, hiyerarşik verileri dairesel halkalar şeklinde göstererek seviyeleri görselleştirir. Parçanın bütünle ilişkisinin açıklanmasına yardımcı olur ve iç içe geçmiş kategorileri net ve kompakt bir formatta temsil etmek için idealdir.

Bu örnek, dört gövde ve iki dal içinde gruplanmış sekiz yapraktan oluşan bir sunburst grafiği oluşturur. [set_grouping_item](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategorylevelsmanager/set_grouping_item/) yöntemi, 1. grup seviyesinde gövdeleri ve 2. seviyede dalları atar. Kategori etiketleri segmentleri tanımlar, değerler ise göreceli boyutlarını belirler.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.SUNBURST, 20, 20, 500, 300)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    # Şube 1
    category_cell = workbook.get_cell(0, "C1", "Leaf1")
    leaf = chart.chart_data.categories.add(category_cell)
    leaf.grouping_levels.set_grouping_item(1, "Stem1")
    leaf.grouping_levels.set_grouping_item(2, "Branch1")

    category_cell = workbook.get_cell(0, "C2", "Leaf2")
    chart.chart_data.categories.add(category_cell)

    category_cell = workbook.get_cell(0, "C3", "Leaf3")
    leaf = chart.chart_data.categories.add(category_cell)
    leaf.grouping_levels.set_grouping_item(1, "Stem2")

    category_cell = workbook.get_cell(0, "C4", "Leaf4")
    chart.chart_data.categories.add(category_cell)

    # Şube 2
    category_cell = workbook.get_cell(0, "C5", "Leaf5")
    leaf = chart.chart_data.categories.add(category_cell)
    leaf.grouping_levels.set_grouping_item(1, "Stem3")
    leaf.grouping_levels.set_grouping_item(2, "Branch2")

    category_cell = workbook.get_cell(0, "C6", "Leaf6")
    chart.chart_data.categories.add(category_cell)

    category_cell = workbook.get_cell(0, "C7", "Leaf7")
    leaf = chart.chart_data.categories.add(category_cell)
    leaf.grouping_levels.set_grouping_item(1, "Stem4")

    category_cell = workbook.get_cell(0, "C8", "Leaf8")
    chart.chart_data.categories.add(category_cell)

    series = chart.chart_data.series.add(charts.ChartType.SUNBURST)
    series.labels.default_data_label_format.show_category_name = True
    value_cell = workbook.get_cell(0, "D1", 4)
    series.data_points.add_data_point_for_sunburst_series(value_cell)
    value_cell = workbook.get_cell(0, "D2", 5)
    series.data_points.add_data_point_for_sunburst_series(value_cell)
    value_cell = workbook.get_cell(0, "D3", 3)
    series.data_points.add_data_point_for_sunburst_series(value_cell)
    value_cell = workbook.get_cell(0, "D4", 6)
    series.data_points.add_data_point_for_sunburst_series(value_cell)
    value_cell = workbook.get_cell(0, "D5", 9)
    series.data_points.add_data_point_for_sunburst_series(value_cell)
    value_cell = workbook.get_cell(0, "D6", 9)
    series.data_points.add_data_point_for_sunburst_series(value_cell)
    value_cell = workbook.get_cell(0, "D7", 4)
    series.data_points.add_data_point_for_sunburst_series(value_cell)
    value_cell = workbook.get_cell(0, "D8", 3)
    series.data_points.add_data_point_for_sunburst_series(value_cell)

    presentation.save("Sunburst.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Sunburst Grafiği](sunburst_chart.png)

### **Histogram Grafikleri Oluşturma**

Histogram grafikleri, sayısal verileri aralıklara (bin) gruplandırarak dağılımı temsil eder. Frekans, çarpıklık, yayılım gibi veri motiflerini tanımlamak ve veri setindeki aykırı değerleri tespit etmek için özellikle yararlıdır.

Bu örnek, negatif değerler dahil altı sayısal değerden bir histogram oluşturur. [aggregation_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/aggregation_type/) özelliğini otomatik olarak ayarlamak, grafiğin dağılımı göstermek için kullanılacak binleri kendisinin belirlemesini sağlar.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.HISTOGRAM, 20, 20, 500, 300)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.HISTOGRAM)
    value_cell = workbook.get_cell(0, "A1", 15)
    series.data_points.add_data_point_for_histogram_series(value_cell)
    value_cell = workbook.get_cell(0, "A2", -41)
    series.data_points.add_data_point_for_histogram_series(value_cell)
    value_cell = workbook.get_cell(0, "A3", 16)
    series.data_points.add_data_point_for_histogram_series(value_cell)
    value_cell = workbook.get_cell(0, "A4", 10)
    series.data_points.add_data_point_for_histogram_series(value_cell)
    value_cell = workbook.get_cell(0, "A5", -23)
    series.data_points.add_data_point_for_histogram_series(value_cell)
    value_cell = workbook.get_cell(0, "A6", 16)
    series.data_points.add_data_point_for_histogram_series(value_cell)

    chart.axes.horizontal_axis.aggregation_type = charts.AxisAggregationType.AUTOMATIC

    presentation.save("Histogram.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Histogram Grafiği](histogram_chart.png)

### **Radar Grafikleri Oluşturma**

Radar grafikleri, çok değişkenli verileri iki boyutlu bir formatta göstererek birkaç değişkeni aynı anda kolayca karşılaştırmayı sağlar. Performans metriği veya özellikler gibi çoklu ölçütlerde desen, güçlü ve zayıf yönleri tanımlamak için özellikle faydalıdır.

Bu örnek, varsayılan seri ve kategorilerle bir radar grafiği oluşturmak için [add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) yöntemini kullanır ve ardından sunumu PPTX olarak kaydeder.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.shapes.add_chart(charts.ChartType.RADAR, 20, 20, 500, 300)

    presentation.save("Radar-chart.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Radar Grafiği](radar_chart.png)

### **Çok Kategorili Grafikler Oluşturma**

Çok kategorili grafikler, birden fazla kategorik gruplamayı içeren verileri göstermek ve değerleri aynı anda birden fazla boyutta karşılaştırmak için kullanılır. Karmaşık, çok katmanlı veri setlerinde trend ve ilişki analizini kolaylaştırır.

Bu örnek, dört çift halinde sekiz kategori içeren bir küme sütun grafiği oluşturur. [set_grouping_item](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategorylevelsmanager/set_grouping_item/) yöntemi, her çifte grup seviyesi 1’de ortak bir etiket atar ve bireysel ve grup etiketleri içeren bir kategori ekseni üretir.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    worksheet_index = 0

    category_cell = workbook.get_cell(0, "c2", "A")
    category = chart.chart_data.categories.add(category_cell)
    category.grouping_levels.set_grouping_item(1, "Group1")
    category_cell = workbook.get_cell(0, "c3", "B")
    category = chart.chart_data.categories.add(category_cell)

    category_cell = workbook.get_cell(0, "c4", "C")
    category = chart.chart_data.categories.add(category_cell)
    category.grouping_levels.set_grouping_item(1, "Group2")
    category_cell = workbook.get_cell(0, "c5", "D")
    category = chart.chart_data.categories.add(category_cell)

    category_cell = workbook.get_cell(0, "c6", "E")
    category = chart.chart_data.categories.add(category_cell)
    category.grouping_levels.set_grouping_item(1, "Group3")
    category_cell = workbook.get_cell(0, "c7", "F")
    category = chart.chart_data.categories.add(category_cell)

    category_cell = workbook.get_cell(0, "c8", "G")
    category = chart.chart_data.categories.add(category_cell)
    category.grouping_levels.set_grouping_item(1, "Group4")
    category_cell = workbook.get_cell(0, "c9", "H")
    category = chart.chart_data.categories.add(category_cell)

    series_name_cell = workbook.get_cell(0, "D1", "Series 1")
    series = chart.chart_data.series.add(series_name_cell, charts.ChartType.CLUSTERED_COLUMN)

    value_cell = workbook.get_cell(worksheet_index, "D2", 10)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, "D3", 20)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, "D4", 30)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, "D5", 40)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, "D6", 50)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, "D7", 60)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, "D8", 70)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, "D9", 80)
    series.data_points.add_data_point_for_bar_series(value_cell)

    presentation.save("AsposeChart.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Çok Kategorili Grafik](multi_category_chart.png)

### **Harita Grafikleri Oluşturma**

Harita grafikleri, ülkeler, eyaletler veya şehirler gibi belirli konumlara bilgi eşleştirerek coğrafi verileri görselleştirir. Bölgesel trendleri, demografik verileri ve mekânsal dağılımları net ve görsel olarak çekici bir şekilde analiz etmek için özellikle kullanışlıdır.

Bu örnek, varsayılan coğrafi verilerle bir harita grafiği oluşturmak için [add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) yöntemini kullanır ve PowerPoint'te görüntülenmek üzere kaydeder.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.MAP, 20, 20, 500, 300)

    presentation.save("mapChart.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Harita Grafiği](map_chart.png)

{{% alert color="info" title="Note" %}}
Yukarıdaki resim, kaydedilen sunumun PowerPoint'te açık olarak gösterilmesini sağlar. Aspose.Slides harita grafiğini ve verilerini doğru bir şekilde yazar, ancak harita grafiklerini kendisi çizmeyi desteklemez: bir slayt harita grafiği içeriyorken görüntüye render edildiğinde veya PDF ya da SVG'ye dönüştürüldüğünde grafik alanı boş çıkar. Aynı slaydın diğer biçimleri etkilenmez.
{{% /alert %}}

### **Kombinasyon Grafikleri Oluşturma**

Kombinasyon grafiği (veya combo grafiği), tek bir grafik içinde iki veya daha fazla grafik tipini birleştirir. Bu grafik, iki ya da daha fazla veri seti arasındaki farkları vurgulamak, karşılaştırmak veya incelemek için kullanılır ve ilişkileri ortaya çıkarmaya yardımcı olur.

![Kombinasyon Grafiği](combination_chart.png)

Bu örnek, dört kategori boyunca iki küme sütun serisini bir çizgi serisiyle birleştirir. Sütunlar birincil dikey ekseni, [plot_on_second_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/plot_on_second_axis/) ise çizgiyi sağdaki ikincil dikey eksene yerleştirir. Yardımcı işlevler başlığı, lejandı, eksen etiketlerini ve ızgaraları yapılandırır.

```python
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.charts as charts

def create_combo_chart():
    with slides.Presentation() as presentation:
        chart = create_chart_with_first_series(presentation.slides[0])

        add_second_series_to_chart(chart)
        add_third_series_to_chart(chart)

        set_primary_axes_format(chart)
        set_secondary_axes_format(chart)

        presentation.save("combo-chart.pptx", slides.export.SaveFormat.PPTX)

def create_chart_with_first_series(slide):
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("Chart Title")
    chart.chart_title.overlay = False
    portion_format = chart.chart_title.text_frame_for_overriding.paragraphs[0].paragraph_format.default_portion_format
    portion_format.font_bold = slides.NullableBool.FALSE
    portion_format.font_height = 18

    chart.legend.position = charts.LegendPositionType.BOTTOM
    chart.legend.text_format.portion_format.font_height = 12

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    category_cell = workbook.get_cell(worksheet_index, 1, 0, "Category 1")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(worksheet_index, 2, 0, "Category 2")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(worksheet_index, 3, 0, "Category 3")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(worksheet_index, 4, 0, "Category 4")
    chart.chart_data.categories.add(category_cell)

    series_name_cell = workbook.get_cell(worksheet_index, 0, 1, "Series 1")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    series.parent_series_group.overlap = -25
    series.parent_series_group.gap_width = 220

    value_cell = workbook.get_cell(worksheet_index, 1, 1, 4.3)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 2, 1, 2.5)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 3, 1, 3.5)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 4, 1, 4.5)
    series.data_points.add_data_point_for_bar_series(value_cell)

    return chart

def add_second_series_to_chart(chart):
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    series_name_cell = workbook.get_cell(worksheet_index, 0, 2, "Series 2")
    series = chart.chart_data.series.add(series_name_cell, charts.ChartType.CLUSTERED_COLUMN)

    series.parent_series_group.overlap = -25
    series.parent_series_group.gap_width = 220

    value_cell = workbook.get_cell(worksheet_index, 1, 2, 2.4)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 2, 2, 4.4)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 3, 2, 1.8)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 4, 2, 2.8)
    series.data_points.add_data_point_for_bar_series(value_cell)

def add_third_series_to_chart(chart):
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    series_name_cell = workbook.get_cell(worksheet_index, 0, 3, "Series 3")
    series = chart.chart_data.series.add(series_name_cell, charts.ChartType.LINE)

    value_cell = workbook.get_cell(worksheet_index, 1, 3, 2.0)
    series.data_points.add_data_point_for_line_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 2, 3, 2.0)
    series.data_points.add_data_point_for_line_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 3, 3, 3.0)
    series.data_points.add_data_point_for_line_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 4, 3, 5.0)
    series.data_points.add_data_point_for_line_series(value_cell)

    series.plot_on_second_axis = True

def set_primary_axes_format(chart):
    horizontal_axis = chart.axes.horizontal_axis
    horizontal_axis.text_format.portion_format.font_height = 12
    horizontal_axis.format.line.fill_format.fill_type = slides.FillType.NO_FILL

    set_axis_title(horizontal_axis, "X Axis")

    vertical_axis = chart.axes.vertical_axis
    vertical_axis.text_format.portion_format.font_height = 12
    vertical_axis.format.line.fill_format.fill_type = slides.FillType.NO_FILL

    set_axis_title(vertical_axis, "Y Axis 1")

    major_grid_lines_format = vertical_axis.major_grid_lines_format.line.fill_format
    major_grid_lines_format.fill_type = slides.FillType.SOLID
    major_grid_lines_format.solid_fill_color.color = draw.Color.from_argb(217, 217, 217)

def set_secondary_axes_format(chart):
    secondary_horizontal_axis = chart.axes.secondary_horizontal_axis
    secondary_horizontal_axis.position = charts.AxisPositionType.BOTTOM
    secondary_horizontal_axis.cross_type = charts.CrossesType.MAXIMUM
    secondary_horizontal_axis.is_visible = False
    secondary_horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL
    secondary_horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    secondary_vertical_axis = chart.axes.secondary_vertical_axis
    secondary_vertical_axis.position = charts.AxisPositionType.RIGHT
    secondary_vertical_axis.text_format.portion_format.font_height = 12
    secondary_vertical_axis.format.line.fill_format.fill_type = slides.FillType.NO_FILL
    secondary_vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL
    secondary_vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    set_axis_title(secondary_vertical_axis, "Y Axis 2")

def set_axis_title(axis, axis_title):
    axis.has_title = True
    axis.title.overlay = False
    title_portion_format = axis.title.add_text_frame_for_overriding(axis_title).paragraphs[0].paragraph_format.default_portion_format
    title_portion_format.font_bold = slides.NullableBool.FALSE
    title_portion_format.font_height = 12


create_combo_chart()
```

## **Grafikleri Güncelleme**

Aspose.Slides for Python via .NET, grafik verilerini, biçimlendirmesini ve stilini değiştirerek PowerPoint grafiklerini güncellemenizi sağlar. Bu özellik, sunumları dinamik içerikle güncel tutma sürecini basitleştirir ve grafiklerin mevcut verileri ve görsel standartları doğru yansıtmasını garanti eder.

Bu örnek, mevcut bir sunumun ilk slaydındaki "My chart" adlı grafiği günceller. Her biri üç veri noktasına sahip iki sütun serisi gerektirir; kategori etiketleri A sütununda, seri adları ise ilk çalışma sayfasının ilk satırında bulunur. Örnek, [get_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) kullanarak çalışma kitabı hücrelerini değiştirir, seri değerlerini günceller, üçüncü bir seri ekler ve [type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/type/) aracılığıyla grafik tipi küme silindirlerine dönüştürür.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

chart_name = "My chart"

with slides.Presentation("ExistingChart.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, charts.Chart) and shape.name == chart_name:
            chart = shape
            worksheet_index = 0

            workbook = chart.chart_data.chart_data_workbook

            workbook.get_cell(worksheet_index, 1, 0, "Modified Category 1")
            workbook.get_cell(worksheet_index, 2, 0, "Modified Category 2")

            series = chart.chart_data.series[0]

            workbook.get_cell(worksheet_index, 0, 1, "New_Series 1")
            series.data_points[0].value.data = 90
            series.data_points[1].value.data = 123
            series.data_points[2].value.data = 44

            series = chart.chart_data.series[1]

            workbook.get_cell(worksheet_index, 0, 2, "New_Series 2")
            series.data_points[0].value.data = 23
            series.data_points[1].value.data = 67
            series.data_points[2].value.data = 99

            series_name_cell = workbook.get_cell(worksheet_index, 0, 3, "Series 3")
            series = chart.chart_data.series.add(series_name_cell, chart.type)

            value_cell = workbook.get_cell(worksheet_index, 1, 3, 20)
            series.data_points.add_data_point_for_bar_series(value_cell)
            value_cell = workbook.get_cell(worksheet_index, 2, 3, 50)
            series.data_points.add_data_point_for_bar_series(value_cell)
            value_cell = workbook.get_cell(worksheet_index, 3, 3, 30)
            series.data_points.add_data_point_for_bar_series(value_cell)

            chart.type = charts.ChartType.CLUSTERED_CYLINDER

    presentation.save("AsposeChartModified.pptx", slides.export.SaveFormat.PPTX)
```

## **Bir Grafik için Veri Aralığını Ayarlama**

Mevcut bir grafiğin kullandığı aralığı incelemek için [Bir Grafiğin Veri Aralığını Al](/slides/tr/python-net/chart-workbook/#retrieve-a-charts-data-range) bölümüne bakın.

Aspose.Slides for Python via .NET, bir çalışma sayfasındaki belirli bir veri aralığını grafiğinizin veri kaynağı olarak tanımlama esnekliği sağlar. Bu, çalışma sayfanızın bir kısmını doğrudan grafiğe eşlemenize, hangi hücrelerin serilere ve kategorilere katkıda bulunduğunu kontrol etmenize olanak tanır. Sonuç olarak, grafiklerinizi çalışma sayfanızdaki en son veri değişiklikleriyle kolayca güncelleyebilir ve senkronize edebilirsiniz, böylece PowerPoint sunumlarınız güncel ve doğru bilgileri yansıtır.

Bu örnek, mevcut bir sunumun ilk slaydındaki "My chart" adlı grafiğin veri kaynağını `Sheet1!A1:B4` olarak ayarlamak için [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) yöntemini kullanır. Grafik çalışma kitabının bu çalışma sayfasını ve birinci satırda seri başlığı, A sütununda kategori etiketleri ve B sütununda üç değer içeren bir aralık barındırması gerekir.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

chart_name = "My chart"

with slides.Presentation("ExistingChart.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, charts.Chart) and shape.name == chart_name:
            chart = shape
            chart.chart_data.set_range("Sheet1!A1:B4")

    presentation.save("SetDataRange.pptx", slides.export.SaveFormat.PPTX)
```

## **Grafiklerde Varsayılan İşaretçileri Kullanma**

Grafiklerde varsayılan işaretçileri kullandığınızda, her grafik serisi otomatik olarak farklı bir varsayılan işaretçi sembolü alır.

Bu örnek, iki çizgi serisi ve bir lejand içeren bir grafik oluşturmak için [add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) yöntemini kullanır. [marker](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/marker/) ayarları, otomatik olarak atanan işaretçi sembollerini korur. İlk seri negatif bir değer ve eksik bir değer (`None`) içerirken, ikincisi her kategori için bir değer içerir.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 10, 10, 400, 400)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook

    series_name_cell = workbook.get_cell(0, 0, 1, "Series 1")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    category_cell = workbook.get_cell(0, 1, 0, "C1")
    chart.chart_data.categories.add(category_cell)
    value_cell = workbook.get_cell(0, 1, 1, 24)
    series.data_points.add_data_point_for_line_series(value_cell)

    category_cell = workbook.get_cell(0, 2, 0, "C2")
    chart.chart_data.categories.add(category_cell)
    value_cell = workbook.get_cell(0, 2, 1, 23)
    series.data_points.add_data_point_for_line_series(value_cell)

    category_cell = workbook.get_cell(0, 3, 0, "C3")
    chart.chart_data.categories.add(category_cell)
    value_cell = workbook.get_cell(0, 3, 1, -10)
    series.data_points.add_data_point_for_line_series(value_cell)

    category_cell = workbook.get_cell(0, 4, 0, "C4")
    chart.chart_data.categories.add(category_cell)
    value_cell = workbook.get_cell(0, 4, 1, None)
    series.data_points.add_data_point_for_line_series(value_cell)

    series_name_cell = workbook.get_cell(0, 0, 2, "Series 2")
    second_series = chart.chart_data.series.add(series_name_cell, chart.type)

    value_cell = workbook.get_cell(0, 1, 2, 30)
    second_series.data_points.add_data_point_for_line_series(value_cell)
    value_cell = workbook.get_cell(0, 2, 2, 10)
    second_series.data_points.add_data_point_for_line_series(value_cell)
    value_cell = workbook.get_cell(0, 3, 2, 60)
    second_series.data_points.add_data_point_for_line_series(value_cell)
    value_cell = workbook.get_cell(0, 4, 2, 40)
    second_series.data_points.add_data_point_for_line_series(value_cell)

    chart.has_legend = True
    chart.legend.overlay = False

    presentation.save("DefaultMarkersInChart.pptx", slides.export.SaveFormat.PPTX)
```

## **SSS**

**Aspose.Slides for Python via .NET hangi grafik türlerini destekliyor?**

Aspose.Slides for Python via .NET, çubuk, çizgi, pasta, alan, saçılım, histogram, radar ve daha birçok grafik türünü destekler. Bu esneklik, veri görselleştirme ihtiyacınıza en uygun grafik tipini seçmenizi sağlar.

**Bir slayta yeni bir grafik nasıl eklerim?**

Bir grafik eklemek için önce [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturur, istenen slaytı indeksine göre alır ve ardından grafik tipini ve başlangıç verilerini belirterek grafik ekleme metodunu çağırırsınız. Bu işlem, grafiği doğrudan sunumunuza entegre eder.

**Bir grafikte görüntülenen verileri nasıl güncelleyebilirim?**

Bir grafiğin verilerini güncellemek için veri çalışma kitabına ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)) erişir, varsayılan seri ve kategorileri temizler ve ardından özel verilerinizi ekleyebilirsiniz. Böylece grafiği programlı olarak en son verileri yansıtacak şekilde yenileyebilirsiniz.

**Grafiğin görünümünü özelleştirmek mümkün mü?**

Evet, Aspose.Slides for Python via .NET geniş özelleştirme seçenekleri sunar. Renkleri, yazı tiplerini, etiketleri, lejandları ve diğer biçimlendirme öğelerini, grafik tasarım gereksinimlerinize göre değiştirebilirsiniz.