---
title: Python'da PowerPoint Sunumu Grafiklerini Oluşturma veya Güncelleme
linktitle: Grafik Oluşturma veya Güncelleme
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
- ağaç harita grafik
- stok grafik
- kutu ve bıyık grafik
- huni grafik
- güneş patlaması grafik
- histogram grafik
- radar grafik
- çok kategorili grafik
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET kullanarak PowerPoint sunumlarında grafik oluşturun ve özelleştirin. Python’da pratik kod örnekleriyle grafik ekleyin, biçimlendirin ve düzenleyin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for Python via .NET kullanarak grafik oluşturma ve özelleştirme konusunda kapsamlı bir rehber sunar. Kaydırıcıya programlı olarak bir grafik eklemeyi, verilerle doldurmayı ve belirli tasarım gereksinimlerinize uymak için çeşitli biçimlendirme seçeneklerini uygulamayı öğreneceksiniz. Makale boyunca, sunumu ve grafik nesnesini başlatmadan serileri, eksenleri ve lejandları yapılandırmaya kadar her adımı gösteren ayrıntılı kod örnekleri bulunur. Bu rehberi izleyerek, Python uygulamalarınıza dinamik grafik oluşturmayı entegre etme konusunda sağlam bir anlayış kazanacak ve veri odaklı sunumlar oluşturma sürecini hızlandıracaksınız.

## **Grafik Oluşturma**

Grafikler, kişilerin verileri hızlı bir şekilde görselleştirmesine ve bir tablo veya elektronik tablodan hemen anlaşılmayabilecek içgörüler elde etmesine yardımcı olur.

**Neden Grafik Oluşturmalısınız?**

- Bir sunumdaki tek bir slaytta büyük miktarda veriyi toplamak, sıkıştırmak veya özetlemek;
- Verideki desenleri ve eğilimleri ortaya çıkarmak;
- Verinin zamanla veya belirli bir ölçü birimine göre yönünü ve momentumunu çıkarmak;
- Uç değerleri, sapmaları, hataları ve mantıksız verileri tespit etmek;
- Karmaşık verileri iletmek veya sunmak.

PowerPoint'te, birçok grafik türü tasarlamak için şablonlar sunan *Ekle* işlevi aracılığıyla grafikler oluşturabilirsiniz. Aspose.Slides kullanarak, hem sıradan grafikler (popüler grafik türlerine dayalı) hem de özel grafikler oluşturabilirsiniz.

{{% alert color="info" title="Note" %}}
Bu sayıda, [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) enum'ını [aspose.slides.charts](https://reference.aspose.com/slides/python-net/aspose.slides.charts/) modülü altında kullanın. Bu enum'daki değerler farklı grafik türlerine karşılık gelir.
{{% /alert %}}

### **Kümelenmiş Sütun Grafikleri Oluşturma**

Bu örnek, iki seriyi üç kategori üzerinden karşılaştıran bir kümelenmiş sütun grafiği oluşturmak için [add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) kullanır. Seriler kırmızı ve yeşil dolgu renkleri kullanır ve bireysel etiketler kategori adlarını, seri adlarını ve değerleri gösterir. Çalışma sayfası indeksi 0, gömülü grafik çalışma kitabındaki ilk sayfayı ifade eder.

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

![Kümelenmiş Sütun Grafiği](clustered_column_chart.png)

### **Saçılım Grafikleri Oluşturma**

Saçılım grafikler (saçılım diyagramları veya x-y grafikleri olarak da bilinir) genellikle iki değişken arasındaki desenleri kontrol etmek veya korelasyonları göstermek için kullanılır.

Saçılım grafiği şu durumlarda kullanılır:

* Eşlenmiş sayısal verileriniz varsa;
* Birlikte iyi eşleşen iki değişkeniniz varsa;
* İki değişkenin ilişkili olup olmadığını belirlemek istiyorsanız;
* Bağımlı bir değişken için birden çok değer içeren bağımsız bir değişkeniniz varsa;

Bu örnek, iki x‑y değer kümesini çizer. İlk seri yıldız işaretçileriyle düz çizgiler kullanırken, ikinci seri yuvarlak işaretçileriyle yumuşak çizgiler kullanır; her ikisi de 10 [ size](https://reference.aspose.com/slides/python-net/aspose.slides.charts/marker/size/) kullanır. [symbol](https://reference.aspose.com/slides/python-net/aspose.slides.charts/marker/symbol/) özelliği işaretçi şeklinin kontrolünü sağlar.

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

Pasta grafikler, özellikle veri sayısal değerlerle birlikte kategorik etiketler içerdiğinde, parçanın bütüne oranını göstermek için en uygunudur. Ancak verinizde çok fazla parça veya etiket varsa, bunun yerine çubuk grafik kullanmayı düşünebilirsiniz.

Bu örnek, üç çeyreklik değer içeren bir pasta grafik oluşturur. Her dilim özel bir dolgu ve kenarlık alır ve etiketler değer, yüzde ve seri bilgilerini farklı kombinasyonlarla gösterir. [first_slice_angle](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/first_slice_angle/) özelliği ilk dilimin 180 derecede başlamasını ayarlar.

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

Dış etiketlerin okunabilirliğini artırmak için, etiketleri konumlandıran ve çizgi rengi, kalınlığı, şeffaflığı ve kesikli stilini özelleştiren bir örnek için [Lider Çizgileri Biçimlendirme](/slides/tr/python-net/chart-data-label/#format-leader-lines) bölümüne bakın.

### **Çizgi Grafikleri Oluşturma**

Çizgi grafikler (çizgi diyagramları olarak da bilinir), değerin zaman içinde nasıl değiştiğini göstermek istediğiniz durumlarda en uygundur. Çizgi grafikle büyük miktarda veriyi aynı anda karşılaştırabilir, zaman içindeki değişimleri ve eğilimleri izleyebilir, veri serilerindeki anormallikleri vurgulayabilirsiniz.

Bu örnek, varsayılan seri ve kategorileriyle bir çizgi grafik oluşturmak için [add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) kullanır ve sunumu PPTX olarak kaydeder.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    line_chart = slide.shapes.add_chart(charts.ChartType.LINE, 20, 20, 500, 300)

    presentation.save("lineChart.pptx", slides.export.SaveFormat.PPTX)
```

Varsayılan olarak, çizgi grafik üzerindeki noktalar düz sürekli çizgilerle birleştirilir. Noktaların kesik çizgilerle birleştirilmesini istiyorsanız, [dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/) özelliğini [LineDashStyle](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/) içindeki bir değere ayarlayın:

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

Ağaç harita grafikleri, satış verileri gibi sınıfların göreceli boyutlarını göstermek ve her sınıf içinde büyük katkı sağlayan öğelere hızlıca dikkat çekmek için en uygunudur.

Bu örnek, dört sap ve iki dal içinde gruplandırılmış sekiz yapraklı bir ağaç harita oluşturur. [set_grouping_item](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategorylevelsmanager/set_grouping_item/) yöntemi sapları grup düzeyi 1, dalları ise düzey 2 olarak atar. Değerler görece dikdörtgen boyutlarını belirler, kategori etiketleri ve üst üste binen ana etiketler hiyerarşiyi tanımlar.

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

    # Dal 1
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

    # Dal 2
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

![Ağaç Haritası](treemap_chart.png)

### **Şelale Grafikleri Oluşturma**

Şelale grafik, pozitif ve negatif değişikliklerin nihai değere nasıl katkıda bulunduğunu gösterir. Örneğin, bir kar dökümü gelirle başlayıp maliyetleri çıkarır ve diğer gelirleri ekler. Değişim sütunları önceki ve yeni koşul değerleri arasında yüzerken, toplam sütunlar sıfırdan birikmiş değere uzanır.

Aşağıdaki örnek, tutarları ABD doları binleri cinsinden gösterir:

| Kategori | Çalışma Kitabı Değeri | Sütun Türü |
| --- | ---: | --- |
| Gelir | 1000 | Artış |
| Satış Maliyeti | -400 | Azalış |
| Brüt Kar | 600 | Ara Toplam |
| İşletme Giderleri | -200 | Azalış |
| Diğer Gelir | 50 | Artış |
| Net Kar | 450 | Final Toplam |

Ara veya final toplamı işaretlemek için, ilgili noktanın [set_as_total](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/set_as_total/) özelliğini `True` olarak ayarlayın. O noktanın çalışma kitabı hücresine gerçek birikmiş tutarı girin: brüt kar için `600` (`1000 - 400`), net kar için `450` (`600 - 200 + 50`). Özellik, sütunu toplam olarak işaretler; hücre değerini hesaplamaz veya doldurmaz. Sıfırı yer tutucu olarak kullanmayın ve toplam noktasına başka bir değişim eklemeyin. Toplam sütun, birikmiş değeri ek bir toplama gerek kalmadan gösterir.

Bu tam C# örneği, [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) üyesi **Waterfall** kullanarak bir grafik oluşturur, varsayılan verileri temizler ve gömülü çalışma kitabını doldurur. Çalışma sayfası indeksi `0` ilk çalışma sayfasını seçer; A sütunu kategori adlarını, B sütunu değerleri içerir. Her değer hücresi, [add_data_point_for_waterfall_series](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/add_data_point_for_waterfall_series/) ile eklenir. Sıfır‑tabanlı nokta indeksleri `2` ve `5` ara ve final toplamları belirler. [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) etkinleştirilirse tutarlar sütunlarda görüntülenir. Giriş sunumu veya çalışma kitabı gerektirmez.

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

    # Üçüncü ve altıncı noktalar ek değişiklikler değil, toplamları temsil eder.
    series.data_points[2].set_as_total = True
    series.data_points[5].set_as_total = True
    series.show_connector_lines = True
    series.labels.default_data_label_format.show_value = True

    presentation.save("WaterfallChart.pptx", slides.export.SaveFormat.PPTX)
```

Seri‑düzeyinde [show_connector_lines](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/show_connector_lines/) özelliğini `True` yaparak art arda gelen sütunları bağlayan çizgileri gösterin ve koşul değerinin izlenmesini kolaylaştırın. Bu çizgileri gizlemek için, örnekteki atamayı kaydetmeden önce `series.show_connector_lines = False` ile değiştirin. Bu yalnızca çizgi görünürlüğünü değiştirir, veri ya da toplamları etkilemez.

Kaydedilen sunum, 600 brüt kar ve 450 net karı sıfırdan çizer:

![Şelale grafiği, gelir, maliyetler, 600 brüt kar ve 450 net kar, değer etiketleri ve bağlayıcı çizgiler](waterfall_chart.png)

### **Stok Grafikleri Oluşturma**

Stok grafikler, açılış, en yüksek, en düşük ve kapanış fiyatları gibi finansal verileri göstererek piyasa eğilimlerini ve volatiliteyi analiz etmeye yardımcı olur. Bu grafikler, hisse performansı hakkında kritik içgörüler sunarak yatırımcıların ve analistlerin bilinçli kararlar almasını sağlar.

Bu örnek, dört seriyi bu sırayla ve üç kategoriyle bir açılış‑yüksek‑düşük‑kapanış (OHLC) grafiği oluşturur. [has_up_down_bars](https://reference.aspose.com/slides/python-net/aspose.slides.charts/updownbarsmanager/has_up_down_bars/) özelliği up/down çubuklarını etkinleştirir ve [hi_low_lines_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/hi_low_lines_format/) yüksek‑düşük çizgilerini kontrol eder; bireysel seri çizgileri ve ince yatay ızgara çizgileri gizlidir.

[up_down_bars](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/up_down_bars/) yöneticisi ayrı ayrı [up_bars_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/updownbarsmanager/up_bars_format/) ve [down_bars_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/updownbarsmanager/down_bars_format/) nesneleri sunar. Her nesnenin [fill](https://reference.aspose.com/slides/python-net/aspose.slides.charts/format/fill/) ve [line](https://reference.aspose.com/slides/python-net/aspose.slides.charts/format/line/) özellikleri bağımsız olarak ayarlanabilir. Bu örnek, yükselen aralıklar için koyu‑yeşil kenarlıklı yeşil çubuklar ve düşen aralıklar için koyu‑kırmızı kenarlıklı turuncu‑kırmızı çubuklar kullanır.

Her kategori için dört serinin sayısal değerleri sağlanır; Yüksek ve Düşük, Açılış ve Kapanış değerlerini kapsar. Çubuklar, aynı kategori içinde **Kapanış‑Açılış** karşılaştırması yapar, önceki kategori ile değil: A 72’den 25’e düşerken, B 25‑den 38’e ve C 38‑den 50’ye yükselir. Açılış ve Kapanış değerleri eşitse görünür bir dolu aralık oluşmaz. Up/down çubukları Açılış‑Kapanış arasını, yüksek‑düşük çizgileri Düşük‑Yüksek arasını kapsar. Bu çubuklar seri grubuna aittir, normal çubuk‑grafik serileri değildir.

Bu biçimlendirme, aynı grupta en az iki seri ve her kategori için sayısal değerler bulunan [LINE ve LINE_WITH_MARKERS](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) grafiklerinde de çalışır. Bu yığılmış olmayan çizgi grafiklerinde, up/down çubukları ilk ve son seriyi karşılaştırır: daha yüksek son değer bir up çubuğu, daha düşük son değer bir down çubuğu üretir. Serileri ters çevirmek sınıflandırmayı ters çevirir. Aşağıdaki örnek [OPEN_HIGH_LOW_CLOSE](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) kullanır; diğer stok, yığılmış‑çizgi veya 3D varyantların aynı veri düzeni veya aralık yorumlamasını kullandığını varsaymayın.

```python
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.OPEN_HIGH_LOW_CLOSE, 20, 20, 500, 150, False)

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

    up_down_bars = chart.chart_data.series_groups[0].up_down_bars
    up_down_bars.has_up_down_bars = True

    up_down_bars.up_bars_format.fill.fill_type = slides.FillType.SOLID
    up_down_bars.up_bars_format.fill.solid_fill_color.color = draw.Color.lime_green
    up_down_bars.up_bars_format.line.fill_format.fill_type = slides.FillType.SOLID
    up_down_bars.up_bars_format.line.fill_format.solid_fill_color.color = draw.Color.dark_green
    up_down_bars.up_bars_format.line.width = 2

    up_down_bars.down_bars_format.fill.fill_type = slides.FillType.SOLID
    up_down_bars.down_bars_format.fill.solid_fill_color.color = draw.Color.orange_red
    up_down_bars.down_bars_format.line.fill_format.fill_type = slides.FillType.SOLID
    up_down_bars.down_bars_format.line.fill_format.solid_fill_color.color = draw.Color.dark_red
    up_down_bars.down_bars_format.line.width = 2
    chart.chart_data.series_groups[0].hi_low_lines_format.line.fill_format.fill_type = slides.FillType.SOLID

    for stock_series in chart.chart_data.series:
        stock_series.format.line.fill_format.fill_type = slides.FillType.NO_FILL

    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    presentation.save("Stock-chart.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç, PowerPoint’ten dışa aktarılmış:

![A için turuncu‑kırmızı düşen aralık ve B ile C için yeşil yükselen aralıklar içeren stok grafiği](stock_chart.png)

### **Kutu ve Bıyık Grafikleri Oluşturma**

Kutu ve bıyık grafikler, medyan, çeyrek değerler ve olası uç değerler gibi temel istatistiksel ölçümleri özetleyerek verinin dağılımını göstermek için kullanılır. Keşifsel veri analizi ve istatistiksel çalışmalarta, veri değişkenliğini hızlıca anlamak ve anormallikleri tanımlamak için özellikle yararlıdır.

Bu örnek, altı değerden bir kutu‑bıyık grafik oluşturur. [quartile_method](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/quartile_method/) özelliği ayrı çeyrek hesabını seçer. Örnek ayrıca ortalama çizgileri, ortalama işaretçileri, iç noktalar ve uç değer noktalarını etkinleştirir.

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

Huni grafikler, bir sürecin ardışık aşamalarını görselleştirir; veri hacmi bir adımdan diğerine ilerledikçe azalır. Dönüşüm oranlarını analiz etmek, darboğazları tespit etmek ve satış ya da pazarlama süreçlerinin verimliliğini izlemek için özellikle yararlıdır.

Bu örnek, mevcut bir sunumun ilk slaytına bir huni grafik eklemek için [add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) kullanır. Varsayılan veriyi altı kategori ve 50‑500 arası değerle değiştirir, ardından güncellenmiş sunumu kaydeder. Giriş sunumu en az bir slayt içermelidir.

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

### **Güneş Patlaması Grafikleri Oluşturma**

Güneş patlaması grafikler, hiyerarşik verileri iç içe halkalarla gösterir. Parçanın bütüne oranını göstermeye yardımcı olur ve iç içe kategorileri net ve kompakt bir biçimde temsil etmek için idealdir.

Bu örnek, dört sap ve iki dal içinde gruplandırılmış sekiz yapraklı bir güneş patlaması grafiği oluşturur. [set_grouping_item](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategorylevelsmanager/set_grouping_item/) yöntemi sapları grup düzeyi 1, dalları ise düzey 2 olarak atar. Kategori etiketleri segmentleri tanımlar, değerler göreli boyutlarını belirler.

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

    # Dal 1
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

    # Dal 2
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

![Güneş Patlaması Grafiği](sunburst_chart.png)

### **Histogram Grafikleri Oluşturma**

Histogram grafikler, sayısal değerlerin aralıklara (kova) nasıl dağıldığını gösterir. Aylık sipariş işleme süresi raporlarında, aralıkları tutarlı tutmak ve dağılımları karşılaştırmak için aynı kova genişliği ve eşik değerleri kullanılmalıdır.

Yatay eksenin [aggregation_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/aggregation_type/) özelliğini [AxisAggregationType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axisaggregationtype/) içindeki bir moda ayarlayın. [bin_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/bin_width/) yalnızca `BY_BIN_WIDTH` için, [number_of_bins](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_of_bins/) yalnızca `BY_NUMBER_OF_BINS` için uygulanır. `AUTOMATIC` kullanarak grafiğin kovalara kendisi karar vermesini sağlayabilirsiniz.

#### **Sabitleştirilmiş Kova Genişliği Kullanma**

Bu örnek, işlem sürelerini 10‑dakikalık aralıklara gruplar; 10 dakikaya kadar ve 40 dakikadan üzeri için ayrı kovalar oluşturur. Bu kovaları [is_underflow_bin](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_underflow_bin/) ve [is_overflow_bin](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_overflow_bin/) ile etkinleştirin. Açık [underflow_bin](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/underflow_bin/) ve [overflow_bin](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/overflow_bin/) eşik değerleri sağlarken, [is_automatic_underflow_bin](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_underflow_bin/) ve [is_automatic_overflow_bin](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_overflow_bin/) özelliklerini `False` yapın.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.HISTOGRAM, 20, 20, 680, 200)

    chart.has_legend = False
    chart.has_title = False

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.HISTOGRAM)
    values = [5, 10, 10, 11, 15, 20, 20, 21, 25, 30, 30, 31, 35, 40, 40, 41, 50]
    for i, value in enumerate(values):
        value_cell = workbook.get_cell(0, i, 0, value)
        series.data_points.add_data_point_for_histogram_series(value_cell)

    axis = chart.axes.horizontal_axis
    axis.aggregation_type = charts.AxisAggregationType.BY_BIN_WIDTH
    axis.bin_width = 10
    axis.is_underflow_bin = True
    axis.is_automatic_underflow_bin = False
    axis.underflow_bin = 10
    axis.is_overflow_bin = True
    axis.is_automatic_overflow_bin = False
    axis.overflow_bin = 40

    presentation.save("Histogram-bin-width.pptx", slides.export.SaveFormat.PPTX)
```
PowerPoint’te gösterilen sunum, **3, 4, 4, 4 ve 2** kova sayısı gösterir. Alt kova `5, 10, 10` değerlerini içerdiği için eşik değeri dahil edicidir. Üst kova sadece `41, 50` değerlerini içerir; eşik değeri dışlayıcıdır; `40` değerleri önceki aralıkta kalır. İç kovalarda değerler alt sınırdan büyük ve üst sınırdan küçük veya eşit olarak yer alır.

![10 dakikalık aralıklarla histogram ve açık alt‑üst eşik değerleri](histogram_bin_width.png)

#### **Bin Sayısını Belirleme**

Sabit aralıklar yerine sabit ayrıntı seviyesi isteniyorsa, aynı veri için beş kova talep edin. Bu örnek, alt ve üst kovaları devre dışı bırakır. Grafik, veri aralığından genişliği belirler; bu nedenle sınırlar raporlar arasında değişebilir.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.HISTOGRAM, 20, 20, 680, 200)

    chart.has_legend = False
    chart.has_title = False

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.HISTOGRAM)
    values = [5, 10, 10, 11, 15, 20, 20, 21, 25, 30, 30, 31, 35, 40, 40, 41, 50]
    for i, value in enumerate(values):
        value_cell = workbook.get_cell(0, i, 0, value)
        series.data_points.add_data_point_for_histogram_series(value_cell)

    axis = chart.axes.horizontal_axis
    axis.aggregation_type = charts.AxisAggregationType.BY_NUMBER_OF_BINS
    axis.number_of_bins = 5

    presentation.save("Histogram-bin-count.pptx", slides.export.SaveFormat.PPTX)
```
Beş kova, **4, 4, 4, 4 ve 1** sayısına sahiptir. Yukarıdaki sabit‑genişlik sonucuyle karşılaştırın: giriş değerleri aynı, ancak sınırlar farklıdır.

![Aynı veriden hesaplanan beş kova histogramı](histogram_bin_count.png)

### **Radar Grafikleri Oluşturma**

Radar grafikler, çok değişkenli verileri iki boyutlu bir formatta göstererek birkaç değişkeni aynı anda karşılaştırmayı kolaylaştırır. Performans metrikleri veya özellikler arasında desenleri, güçlü ve zayıf yönleri tanımlamak için özellikle faydalıdır.

Bu örnek, varsayılan seri ve kategorileriyle bir radar grafik oluşturmak için [add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) kullanır ve sunumu PPTX olarak kaydeder.

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

Çok kategorili grafikler, birden fazla kategorik gruplamayı içeren verileri göstererek değerleri çoklu boyutlarda aynı anda karşılaştırmanıza olanak tanır. Karmaşık, çok katmanlı veri setlerinde eğilimleri ve ilişkileri analiz etmek gerektiğinde özellikle yardımcıdır.

Bu örnek, dört çift halinde düzenlenmiş sekiz kategoriye sahip bir kümelenmiş sütun grafik oluşturur. [set_grouping_item](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategorylevelsmanager/set_grouping_item/) yöntemi, her çifte grup düzeyi 1’de ortak bir etiket verir ve hem bireysel hem de grup etiketleri içeren bir kategori ekseni üretir.

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

#### **Bir Çeyrek Etiketini Kaldırma**

[quarters.pptx](quarters.pptx) dosyasını indirin ve çalışma dizinine koyun. Grafiği dokuz ay ve 10‑18 değerleri arasındaki tek bir satış serisini gösterir. Kategori ekseninde üç çeyrek etiketi vardır: Q1 Ocak‑Mart, Q2 Nisan‑Haziran, Q3 Temmuz‑Eylül.

Nisan dördüncü kategori olup Q2’nin açıkça ayarlandığı yerdir. Nisan’ın [grouping_levels](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategory/grouping_levels/) koleksiyonunda [delete_grouping_item](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategorylevelsmanager/delete_grouping_item/) yöntemini çağırın. Seviye, Nisan’a görerelidir: seviye 1 çeyreği, seviye 0 ayı temsil eder. Yöntem seviye 0’daki yaprak kategoriyi kaldıramaz.

```python
import aspose.slides as slides

with slides.Presentation("quarters.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    april = chart.chart_data.categories[3]
    april.grouping_levels.delete_grouping_item(1)
    
    presentation.save("quarters-updated.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("quarters-updated.pptx") as reopened:
    data = reopened.slides[0].shapes[0].chart_data
    print(", ".join(str(month.as_cell.value) for month in data.categories))
    print(", ".join(str(point.value.data) for point in data.series[0].data_points))
```
Açılan grafik, orijinal ayları (`Jan, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep`) ve satış değerlerini (`10, 11, 12, 13, 14, 15, 16, 17, 18`) aynı sırada yazdırır. `quarters-updated.pptx` dosyasını PowerPoint’te açarak eksen etiketlerini karşılaştırın. Q2 etiketi ve Nisan öncesi grup sınırı kaybolur, böylece Q1 Ocak‑Haziran kapsar. Q3 hâlâ Temmuz’da başlar.

![Kaldırmadan önce ve sonra çeyrek etiketleri. Solda Q2 Nisan‑Haziran, sağda Q1 Ocak‑Haziran](quarter-label-comparison.png)

### **Harita Grafikleri Oluşturma**

Harita grafikler, ülkeler, eyaletler veya şehirler gibi belirli konumlara bilgi haritalayarak coğrafi verileri görselleştirir. Bölgesel trendleri, demografik verileri ve mekânsal dağılımları net, görsel olarak çekici bir biçimde analiz etmek için özellikle yararlıdır.

Bu örnek, varsayılan coğrafi verilerle bir harita grafik oluşturmak için [add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) kullanır ve PowerPoint’te görüntülenmek üzere kaydeder.

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
Yukarıdaki resim, kaydedilen sunumun PowerPoint’te açılmış halini gösterir. Aspose.Slides harita grafiğini ve verilerini doğru yazar, ancak harita grafiklerini kendisi çizmez: bir slayt görüntüye render edildiğinde ya da PDF/SVG’ye dönüştürüldüğünde grafik alanı boş çıkar. Aynı slayttaki diğer şekiller etkilenmez.
{{% /alert %}}

### **Kombinasyon Grafikleri Oluşturma**

Bir kombinasyon grafiği (veya combo grafiği), tek bir grafikte iki veya daha fazla grafik türünü birleştirir. Bu grafik, iki ya da daha fazla veri seti arasındaki farkları vurgulamak, karşılaştırmak veya incelemek için kullanılır ve aralarındaki ilişkileri tanımlamaya yardımcı olur.

![Kombinasyon Grafiği](combination_chart.png)

Bu örnek, dört kategori boyunca iki kümelenmiş sütun serisini bir çizgi serisiyle birleştirir. Sütunlar birincil dikey ekseni, [plot_on_second_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/plot_on_second_axis/) ise çizgiyi sağdaki ikincil dikey eksene yerleştirir. Yardımcı işlevler başlık, lejand, eksen etiketleri ve ızgara çizgilerini yapılandırır.

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

Aspose.Slides for Python via .NET, grafik verilerini, biçimlendirmesini ve stilini değiştirerek PowerPoint grafiklerini güncellemenizi sağlar. Bu işlevsellik, dinamik içerikle sunumları güncel tutmayı kolaylaştırır ve grafiklerin mevcut veri ve görsel standartları doğru yansıtmasını sağlar.

Bu örnek, mevcut bir sunumun ilk slaydındaki "My chart" adlı grafiği günceller. Her biri üç veri noktasına sahip iki sütun serisi gerektirir; kategori etiketleri A sütununda, seri adları ise ilk çalışma sayfasının birinci satırında bulunur. Örnek, [get_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) kullanarak çalışma kitabı hücrelerini değiştirir, seri değerlerini günceller, üçüncü bir seri ekler ve grafiği [type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/type/) aracılığıyla kümelenmiş silindirlere dönüştürür.

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

## **Bir Grafik İçin Veri Aralığını Ayarlama**

Mevcut bir grafik tarafından zaten kullanılan aralığı incelemek için [Retrieve a Chart's Data Range](/slides/tr/python-net/chart-workbook/#retrieve-a-charts-data-range) bölümüne bakın.

Aspose.Slides for Python via .NET, bir çalışma sayfasındaki belirli bir veri aralığını grafik veri kaynağınız olarak tanımlamanıza esneklik sağlar. Bu, çalışma sayfanızın bir bölümünü doğrudan grafiğe eşlemenize, grafik serileri ve kategorileri hangi hücrelerin katkıda bulunacağını kontrol etmenize olanak tanır. Sonuç olarak, grafiklerinizi çalışma sayfanızdaki en son veri değişiklikleriyle kolayca güncelleyebilir ve senkronize edebilirsiniz; böylece PowerPoint sunumlarınız güncel ve doğru bilgiler içerir.

Bu örnek, mevcut bir sunumun ilk slaydındaki "My chart" adlı grafiğin veri kaynağını `Sheet1!A1:B4` olarak ayarlamak için [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) kullanır. Grafik çalışma kitabının bu çalışma sayfasını ve birincil satırda seri başlığı, A sütununda kategori etiketleri ve B sütununda üç değer içeren bir aralık barındırması gerekir.

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

Bu örnek, iki çizgi serisi ve bir lejand içeren bir grafik oluşturmak için [add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) kullanır. [marker](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/marker/) ayarları otomatik atanmış işaretçi sembollerini korur. İlk seri negatif bir değer ve `None` ile temsil edilen eksik bir değer içerirken, ikinci seri her kategori için bir değer sunar.

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

Aspose.Slides for Python via .NET, çubuk, çizgi, pasta, alan, saçılım, histogram, radar ve daha birçok grafik türünü destekler. Bu esneklik, veri görselleştirme ihtiyaçlarınıza en uygun grafik tipini seçmenizi sağlar.

**Bir slayta yeni bir grafik nasıl eklenir?**

Bir grafik eklemek için önce [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturur, istediğiniz slaytı indeksine göre alır ve ardından grafik türü ve başlangıç verilerini belirterek bir grafik ekleme yöntemini çağırırsınız. Bu işlem, grafiği doğrudan sunumunuza entegre eder.

**Bir grafikteki veriler nasıl güncellenir?**

Bir grafiğin verilerini, veri çalışma kitabına ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)) erişerek, varsayılan serileri ve kategorileri temizleyip, kendi özel verilerinizi ekleyerek güncelleyebilirsiniz. Böylece grafiği programlı olarak en son verileri yansıtacak şekilde yenileyebilirsiniz.

**Grafiğin görünümü özelleştirilebilir mi?**

Evet, Aspose.Slides for Python via .NET kapsamlı özelleştirme seçenekleri sunar. Renkleri, yazı tiplerini, etiketleri, lejandları ve diğer biçimlendirme öğelerini değiştirerek grafiğin görünümünü tasarım gereksinimlerinize göre uyarlayabilirsiniz.

Related feature: [Create editable charts](/slides/tr/features/create-charts/).