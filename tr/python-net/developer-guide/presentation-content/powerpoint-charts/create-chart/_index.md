---
title: PowerPoint Sunum Grafiklerini Python'da Oluşturma veya Güncelleme
linktitle: Bir Grafik Oluşturma veya Güncelleme
type: docs
weight: 10
url: /tr/python-net/create-chart/
keywords:
- grafik ekle
- grafik oluştur
- grafik düzenle
- grafiği değiştir
- grafiği güncelle
- dağılım grafiği
- pasta grafiği
- çizgi grafiği
- ağaç haritası grafiği
- stok grafiği
- kutu ve bıyık grafiği
- huni grafiği
- güneş patlaması grafiği
- histogram grafiği
- radar grafiği
- çoklu kategori grafiği
- PowerPoint sunumu
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET kullanarak PowerPoint ve OpenDocument sunumlarında grafiklerin nasıl oluşturulacağını ve özelleştirileceğini öğrenin. Sunumlarda grafik ekleme, biçimlendirme ve düzenleme konularını, Python'da pratik kod örnekleriyle kapsar."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for Python via .NET kullanarak grafiklerin nasıl oluşturulacağını ve özelleştirileceğini kapsamlı bir şekilde anlatır. Bir slayda programlı olarak grafik eklemeyi, verilerle doldurmayı ve belirli tasarım gereksinimlerinize uygun çeşitli biçimlendirme seçeneklerini uygulamayı öğreneceksiniz. Makale boyunca, sunumu ve grafik nesnesini başlatmadan serileri, eksenleri ve açıklamaları yapılandırmaya kadar her adımı gösteren ayrıntılı kod örnekleri bulunur. Bu rehberi izleyerek, dinamik grafik oluşturmayı uygulamalarınıza entegre etme konusunda sağlam bir anlayış kazanacak ve veri odaklı sunumlar oluşturma sürecini hızlandıracaksınız.

## **Grafik Oluşturma**

Grafikler, verileri hızlı bir şekilde görselleştirerek, bir tablo veya elektronik tablodan hemen anlaşılmayan içgörüleri elde etmeye yardımcı olur.

**Neden Grafik Oluşturmalısınız?**

Grafikleri kullanarak:

* bir sunumdaki tek bir slaytta büyük miktarda veriyi toplamak, sıkıştırmak veya özetlemek;
* veri içerisindeki desen ve eğilimleri ortaya çıkarmak;
* verinin zaman içinde ya da belirli bir ölçüm birimiyle ilişkili yön ve ivmesini çıkarmak;
* aykırı değerleri, sapmaları, hataları ve mantıksız verileri tespit etmek;
* karmaşık verileri iletmek veya sunmak.

PowerPoint'te, *Insert* (Ekle) işlevi aracılığıyla, birçok grafik türü tasarlamak için şablonlar sunan grafikler oluşturabilirsiniz. Aspose.Slides kullanarak, popüler grafik türlerine dayalı normal grafiklerin yanı sıra özel grafikler de oluşturabilirsiniz.

{{% alert color="primary" %}} 
Bu bildiride, [ChartType](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/charttype/) enumerasyonunu, [Aspose.Slides.Charts](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/) ad alanı altında kullanın. Bu enumerasyondaki değerler farklı grafik türlerine karşılık gelir.
{{% /alert %}} 

### **Küme Sütun Grafiklerini Oluşturma**

Bu bölüm, Aspose.Slides for Python via .NET kullanarak küme sütun grafiği oluşturmayı açıklar. Sunumu başlatmayı, bir grafik eklemeyi ve başlık, veri, seriler, kategoriler ve stil gibi öğelerini özelleştirmeyi öğreneceksiniz. Aşağıdaki adımları izleyerek standart bir küme sütun grafiğinin nasıl oluşturulduğunu görebilirsiniz:

1. [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksi kullanarak bir slayta referans alın.
1. `ChartType.CLUSTERED_COLUMN` tipini belirterek bazı veriyle bir grafik ekleyin.
1. Grafiğe bir başlık ekleyin.
1. Grafiğin veri çalışma sayfasına erişin.
1. Tüm varsayılan serileri ve kategorileri temizleyin.
1. Yeni seriler ve kategoriler ekleyin.
1. Grafik serileri için yeni grafik verileri ekleyin.
1. Grafik serilerine bir dolgu rengi uygulayın.
1. Grafik serilerine etiketler ekleyin.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu Python kodu, bir küme sütun grafiği oluşturmayı gösterir:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# PPTX dosyasını temsil eden Presentation sınıfını örnekleyin.
with slides.Presentation() as presentation:

    # İlk slayta erişin.
    slide = presentation.slides[0]

    # Varsayılan verileri ile bir küme sütun grafiği ekleyin.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    # Grafik başlığını ayarlayın.
    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    # İlk seriyi değerleri gösterecek şekilde ayarlayın.
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    # Grafik veri sayfasının dizinini ayarlayın.
    worksheet_index = 0

    # Grafik veri çalışma kitabını alın.
    workbook = chart.chart_data.chart_data_workbook

    # Varsayılan oluşturulan serileri ve kategorileri silin.
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    # Yeni seriler ekleyin.
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 1, "Series 1"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 2, "Series 2"), chart.type)

    # Yeni kategoriler ekleyin.
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 1, 0, "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 2, 0, "Category 2"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 3, 0, "Category 3"))

    # İlk grafik serisini alın.
    series = chart.chart_data.series[0]

    # Seri verilerini doldurun.
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 1, 20))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 1, 30))

    # Seri için doldurma rengini ayarlayın.
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.red

    # İkinci grafik serisini alın.
    series = chart.chart_data.series[1]

    # Seri verilerini doldurun.
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 2, 30))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 2, 10))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 2, 60))

    # Seri için doldurma rengini ayarlayın.
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.green

    # İlk etiketi kategori adını gösterecek şekilde ayarlayın.
    label = series.data_points[0].label
    label.data_label_format.show_category_name = True

    label = series.data_points[1].label
    label.data_label_format.show_series_name = True

    # Üçüncü etiket için seriyi değeri gösterecek şekilde ayarlayın.
    label = series.data_points[2].label
    label.data_label_format.show_value = True
    label.data_label_format.show_series_name = True
    label.data_label_format.separator = "/"
                
    # Sunumu bir PPTX dosyası olarak diske kaydedin.
    presentation.save("ClusteredColumnChart.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Küme Sütun Grafiği](clustered_column_chart.png)

### **Saçılım Grafiklerini Oluşturma**

Saçılım grafikleri (scatter plot veya x-y grafiği olarak da bilinir) genellikle iki değişken arasındaki desenleri kontrol etmek veya korelasyonları göstermek için kullanılır.

Bir saçılım grafiği şu durumlarda kullanılır:

* Sayısal çift veri setiniz vardır.
* Birlikte iyi eşleşen iki değişkeniniz vardır.
* İki değişkenin ilişkili olup olmadığını belirlemek istersiniz.
* Bağımlı bir değişken için birden çok değere sahip bağımsız bir değişkeniniz vardır.

Bu Python kodu, farklı işaretleyicilere sahip bir saçılım grafiği oluşturmayı gösterir:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Presentation sınıfını örnekleyin.
with slides.Presentation() as presentation:

    # İlk slayta erişin.
    slide = presentation.slides[0]

    # Varsayılan saçılım grafiğini oluşturun.
    chart = slide.shapes.add_chart(charts.ChartType.SCATTER_WITH_SMOOTH_LINES, 20, 20, 500, 300)

    # Grafik veri sayfasının dizinini ayarlayın.
    worksheet_index = 0

    # Grafik veri çalışma kitabını alın.
    workbook = chart.chart_data.chart_data_workbook

    # Varsayılan seriyi silin.
    chart.chart_data.series.clear()

    # Yeni seriler ekleyin.
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 1, 1, "Series 1"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 1, 3, "Series 2"), chart.type)

    # İlk grafik serisini alın.
    series = chart.chart_data.series[0]

    # Seriye yeni bir nokta (1:3) ekleyin.
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 2, 1, 1), workbook.get_cell(worksheet_index, 2, 2, 3))

    # Yeni bir nokta (2:10) ekleyin.
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 3, 1, 2), workbook.get_cell(worksheet_index, 3, 2, 10))

    # Serinin türünü değiştirin.
    series.type = charts.ChartType.SCATTER_WITH_STRAIGHT_LINES_AND_MARKERS

    # Grafik serisi işaretleyicisini değiştirin.
    series.marker.size = 10
    series.marker.symbol = charts.MarkerStyleType.STAR

    # İkinci grafik serisini alın.
    series = chart.chart_data.series[1]

    # Grafik serisine yeni bir nokta (5:2) ekleyin.
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 2, 3, 5), workbook.get_cell(worksheet_index, 2, 4, 2))

    # Yeni bir nokta (3:1) ekleyin.
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 3, 3, 3), workbook.get_cell(worksheet_index, 3, 4, 1))

    # Yeni bir nokta (2:2) ekleyin.
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 4, 3, 2), workbook.get_cell(worksheet_index, 4, 4, 2))

    # Yeni bir nokta (5:1) ekleyin.
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 5, 3, 5), workbook.get_cell(worksheet_index, 5, 4, 1))

    # Grafik serisi işaretleyicisini değiştirin.
    series.marker.size = 10
    series.marker.symbol = charts.MarkerStyleType.CIRCLE

    presentation.save("ScatterChart.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Saçılım Grafiği](scatter_chart.png)

### **Pasta Grafiklerini Oluşturma**

Pasta grafikleri, özellikle veriler sayısal değerlerle birlikte kategorik etiketler içerdiğinde, bölümler arasındaki bütün ilişkisini göstermek için en uygundur. Ancak, verinizde çok fazla bölüm veya etiket varsa, çubuk grafiği kullanmayı düşünebilirsiniz.

1. [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksi kullanarak bir slayta referans alın.
1. `ChartType.PIE` tipini belirterek varsayılan veriyle bir grafik ekleyin.
1. Grafiğin veri çalışma kitabına ([ChartDataWorkbook](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdataworkbook/)) erişin.
1. Varsayılan serileri ve kategorileri temizleyin.
1. Yeni seriler ve kategoriler ekleyin.
1. Grafik serileri için yeni veri ekleyin.
1. Pasta grafiğinin dilimlerine özel renkler uygulayın.
1. Seriler için etiketleri ayarlayın.
1. Seri etiketleri için lider çizgileri etkinleştirin.
1. Pasta grafiği için dönüş açısını ayarlayın.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu Python kodu, bir pasta grafiği oluşturmayı gösterir:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# PPTX dosyasını temsil eden Presentation sınıfını örnekleyin.
with slides.Presentation() as presentation:

    # İlk slayta erişin.
    slide = presentation.slides[0]

    # Varsayılan verileriyle bir grafik ekleyin.
    chart = slide.shapes.add_chart(charts.ChartType.PIE, 20, 20, 500, 300)

    # Grafik başlığını ayarlayın.
    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    # İlk seriyi değerleri gösterecek şekilde ayarlayın.
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    # Grafik veri sayfasının dizinini ayarlayın.
    worksheet_index = 0

    # Grafik veri çalışma kitabını alın.
    workbook = chart.chart_data.chart_data_workbook

    # Varsayılan oluşturulan serileri ve kategorileri silin.
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    # Yeni kategoriler ekleyin.
    chart.chart_data.categories.add(workbook.get_cell(0, 1, 0, "First Qtr"))
    chart.chart_data.categories.add(workbook.get_cell(0, 2, 0, "2nd Qtr"))
    chart.chart_data.categories.add(workbook.get_cell(0, 3, 0, "3rd Qtr"))

    # Yeni seriler ekleyin.
    series = chart.chart_data.series.add(workbook.get_cell(0, 0, 1, "Series 1"), chart.type)

    # Seri verilerini doldurun.
    series.data_points.add_data_point_for_pie_series(workbook.get_cell(worksheet_index, 1, 1, 20))
    series.data_points.add_data_point_for_pie_series(workbook.get_cell(worksheet_index, 2, 1, 50))
    series.data_points.add_data_point_for_pie_series(workbook.get_cell(worksheet_index, 3, 1, 30))

    # Sektör rengini ayarlayın.
    chart.chart_data.series_groups[0].is_color_varied = True

    point = series.data_points[0]
    point.format.fill.fill_type = slides.FillType.SOLID
    point.format.fill.solid_fill_color.color = draw.Color.cyan

    # Sektör kenarlığını ayarlayın.
    point.format.line.fill_format.fill_type = slides.FillType.SOLID
    point.format.line.fill_format.solid_fill_color.color = draw.Color.gray
    point.format.line.width = 3.0
    point.format.line.style = slides.LineStyle.THIN_THICK
    point.format.line.dash_style = slides.LineDashStyle.DASH_DOT

    point1 = series.data_points[1]
    point1.format.fill.fill_type = slides.FillType.SOLID
    point1.format.fill.solid_fill_color.color = draw.Color.brown

    # Sektör kenarlığını ayarlayın.
    point1.format.line.fill_format.fill_type = slides.FillType.SOLID
    point1.format.line.fill_format.solid_fill_color.color = draw.Color.blue
    point1.format.line.width = 3.0
    point1.format.line.style = slides.LineStyle.SINGLE
    point1.format.line.dash_style = slides.LineDashStyle.LARGE_DASH_DOT

    point2 = series.data_points[2]
    point2.format.fill.fill_type = slides.FillType.SOLID
    point2.format.fill.solid_fill_color.color = draw.Color.coral

    # Sektör kenarlığını ayarlayın.
    point2.format.line.fill_format.fill_type = slides.FillType.SOLID
    point2.format.line.fill_format.solid_fill_color.color = draw.Color.red
    point2.format.line.width = 2.0
    point2.format.line.style = slides.LineStyle.THIN_THIN
    point2.format.line.dash_style = slides.LineDashStyle.LARGE_DASH_DOT_DOT

    # Yeni serideki her kategori için özel etiketler oluşturun.
    label1 = series.data_points[0].label

    label1.data_label_format.show_value = True

    label2 = series.data_points[1].label
    label2.data_label_format.show_value = True
    label2.data_label_format.show_legend_key = True
    label2.data_label_format.show_percentage = True

    label3 = series.data_points[2].label
    label3.data_label_format.show_series_name = True
    label3.data_label_format.show_percentage = True

    # Grafiğin serisini lider çizgileri gösterecek şekilde ayarlayın.
    series.labels.default_data_label_format.show_leader_lines = True

    # Pasta grafik dilimlerinin dönüş açısını ayarlayın.
    chart.chart_data.series_groups[0].first_slice_angle = 180

    # Sunumu bir PPTX dosyası olarak diske kaydedin.
    presentation.save("PieChart.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Pasta Grafiği](pie_chart.png)

### **Çizgi Grafiklerini Oluşturma**

Çizgi grafikleri (line graph olarak da bilinir) değerlerin zaman içindeki değişimini göstermek istediğiniz durumlarda en uygundur. Çizgi grafiği kullanarak büyük veri setlerini aynı anda karşılaştırabilir, zaman içinde değişim ve eğilimleri izleyebilir, veri serilerindeki anomalileri vurgulayabilirsiniz.

1. [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksi kullanarak bir slayta referans alın.
1. `ChartType.LINE` tipini belirterek varsayılan veriyle bir grafik ekleyin.
1. Grafiğin veri çalışma kitabına ([ChartDataWorkbook](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdataworkbook/)) erişin.
1. Varsayılan serileri ve kategorileri temizleyin.
1. Yeni seriler ve kategoriler ekleyin.
1. Grafik serileri için yeni veri ekleyin.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu Python kodu, bir çizgi grafiği oluşturmayı gösterir:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    line_chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.LINE, 20, 20, 500, 300)
    
    presentation.save("LineChart.pptx", slides.export.SaveFormat.PPTX)
```

Varsayılan olarak, bir çizgi grafiğindeki noktalar düz, kesintisiz çizgilerle bağlanır. Noktaları tirelerle bağlamak isterseniz, tercih ettiğiniz tire tipini aşağıdaki gibi belirtebilirsiniz:

```python
line_chart = pres.slides[0].shapes.add_chart(slides.charts.ChartType.LINE, 10, 50, 600, 350)

for series in line_chart.chart_data.series:
    series.format.line.dash_style = slides.charts.LineDashStyle.DASH
```

Sonuç:

![Çizgi Grafiği](line_chart.png)

### **Ağaç Haritası Grafiklerini Oluşturma**

Ağaç haritası grafikleri, veri kategorilerinin göreceli boyutlarını göstermek ve her kategori içinde büyük katkıda bulunan öğelere hızlıca dikkat çekmek için en uygundur.

1. [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksi kullanarak bir slayta referans alın.
1. `ChartType.TREEMAP` tipini belirterek varsayılan veriyle bir grafik ekleyin.
1. Grafiğin veri çalışma kitabına ([ChartDataWorkbook](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdataworkbook/)) erişin.
1. Varsayılan serileri ve kategorileri temizleyin.
1. Yeni seriler ve kategoriler ekleyin.
1. Grafik serileri için yeni veri ekleyin.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu Python kodu, bir ağaç haritası grafiği oluşturmayı gösterir:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.TREEMAP, 20, 20, 500, 300)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    # Şube 1
    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C1", "Leaf1"))
    leaf.grouping_levels.set_grouping_item(1, "Stem1")
    leaf.grouping_levels.set_grouping_item(2, "Branch1")

    chart.chart_data.categories.add(workbook.get_cell(0, "C2", "Leaf2"))

    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C3", "Leaf3"))
    leaf.grouping_levels.set_grouping_item(1, "Stem2")

    chart.chart_data.categories.add(workbook.get_cell(0, "C4", "Leaf4"))

    # Şube 2
    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C5", "Leaf5"))
    leaf.grouping_levels.set_grouping_item(1, "Stem3")
    leaf.grouping_levels.set_grouping_item(2, "Branch2")

    chart.chart_data.categories.add(workbook.get_cell(0, "C6", "Leaf6"))

    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C7", "Leaf7"))
    leaf.grouping_levels.set_grouping_item(1, "Stem4")

    chart.chart_data.categories.add(workbook.get_cell(0, "C8", "Leaf8"))

    series = chart.chart_data.series.add(charts.ChartType.TREEMAP)
    series.labels.default_data_label_format.show_category_name = True
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D1", 4))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D2", 5))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D3", 3))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D4", 6))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D5", 9))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D6", 9))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D7", 4))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D8", 3))

    series.parent_label_layout = charts.ParentLabelLayoutType.OVERLAPPING

    presentation.save("TreeMap.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Ağaç Haritası Grafiği](treemap_chart.png)

### **Stok Grafiklerini Oluşturma**

Stok grafikleri, açılış, en yüksek, en düşük ve kapanış fiyatları gibi finansal verileri göstermek için kullanılır; piyasa eğilimlerini ve volatiliteyi analiz etmeye yardımcı olur. Bu grafikler, yatırımcılara ve analistlere bilinçli kararlar almaları için kritik bilgiler sunar.

1. [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksi kullanarak bir slayta referans alın.
1. `ChartType.OPEN_HIGH_LOW_CLOSE` tipini belirterek varsayılan veriyle bir grafik ekleyin.
1. Grafiğin veri çalışma kitabına ([ChartDataWorkbook](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdataworkbook/)) erişin.
1. Varsayılan serileri ve kategorileri temizleyin.
1. Yeni seriler ve kategoriler ekleyin.
1. Grafik serileri için yeni veri ekleyin.
1. HiLowLines formatını belirtin.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu Python kodu, bir stok grafiği oluşturmayı gösterir:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.OPEN_HIGH_LOW_CLOSE, 20, 20, 500, 300, False)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook

    chart.chart_data.categories.add(workbook.get_cell(0, 1, 0, "A"))
    chart.chart_data.categories.add(workbook.get_cell(0, 2, 0, "B"))
    chart.chart_data.categories.add(workbook.get_cell(0, 3, 0, "C"))

    chart.chart_data.series.add(workbook.get_cell(0, 0, 1, "Open"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(0, 0, 2, "High"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(0, 0, 3, "Low"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(0, 0, 4, "Close"), chart.type)

    series = chart.chart_data.series[0]

    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 1, 1, 72))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 2, 1, 25))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 3, 1, 38))

    series = chart.chart_data.series[1]
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 1, 2, 172))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 2, 2, 57))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 3, 2, 57))

    series = chart.chart_data.series[2]
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 1, 3, 12))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 2, 3, 12))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 3, 3, 13))

    series = chart.chart_data.series[3]
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 1, 4, 25))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 2, 4, 38))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 3, 4, 50))

    chart.chart_data.series_groups[0].up_down_bars.has_up_down_bars = True
    chart.chart_data.series_groups[0].hi_low_lines_format.line.fill_format.fill_type = slides.FillType.SOLID

    for ser in chart.chart_data.series:
        ser.format.line.fill_format.fill_type = slides.FillType.NO_FILL

    presentation.save("StockChart.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Stok Grafiği](stock_chart.png)

### **Kutu ve Bıyık Grafiklerini Oluşturma**

Kutu ve bıyık grafikleri, medyan, çeyrekler ve potansiyel aykırı değerler gibi temel istatistiksel ölçümleri özetleyerek veri dağılımını göstermeye yarar. Keşifsel veri analizi ve istatistiksel çalışmalarda veri değişkenliğini hızlıca anlamak ve anormallikleri tespit etmek için özellikle faydalıdır.

1. [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksi kullanarak bir slayta referans alın.
1. `ChartType.BOX_AND_WHISKER` tipini belirterek varsayılan veriyle bir grafik ekleyin.
1. Grafiğin veri çalışma kitabına ([ChartDataWorkbook](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdataworkbook/)) erişin.
1. Varsayılan serileri ve kategorileri temizleyin.
1. Yeni seriler ve kategoriler ekleyin.
1. Grafik serileri için yeni veri ekleyin.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu Python kodu, bir kutu ve bıyık grafiği oluşturmayı gösterir:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.BOX_AND_WHISKER, 20, 20, 500, 300)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    chart.chart_data.categories.add(workbook.get_cell(0, "A1", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A2", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A3", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A4", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A5", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A6", "Category 1"))

    series = chart.chart_data.series.add(charts.ChartType.BOX_AND_WHISKER)

    series.quartile_method = charts.QuartileMethodType.EXCLUSIVE
    series.show_mean_line = True
    series.show_mean_markers = True
    series.show_inner_points = True
    series.show_outlier_points = True

    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B1", 15))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B2", 41))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B3", 16))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B4", 10))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B5", 23))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B6", 16))

    presentation.save("BoxAndWhiskerChart.pptx", slides.export.SaveFormat.PPTX)
```

### **Huni Grafiklerini Oluşturma**

Huni grafikler, veri hacminin bir adımdan diğerine geçerken azaldığı sıralı aşamaları görselleştirmek için kullanılır. Dönüşüm oranlarını analiz etmek, darboğazları belirlemek ve satış ya da pazarlama süreçlerinin verimliliğini izlemek için özellikle faydalıdır.

1. [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksi kullanarak bir slayta referans alın.
1. `ChartType.FUNNEL` tipini belirterek varsayılan veriyle bir grafik ekleyin.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu Python kodu, bir huni grafiği oluşturmayı gösterir:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.FUNNEL, 50, 50, 500, 400)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    chart.chart_data.categories.add(workbook.get_cell(0, "A1", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A2", "Category 2"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A3", "Category 3"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A4", "Category 4"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A5", "Category 5"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A6", "Category 6"))

    series = chart.chart_data.series.add(charts.ChartType.FUNNEL)

    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B1", 50))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B2", 100))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B3", 200))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B4", 300))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B5", 400))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B6", 500))

    presentation.save("FunnelChart.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Huni Grafiği](funnel_chart.png)

### **Güneş Patlaması Grafiklerini Oluşturma**

Güneş patlaması grafikleri, katman katman dairesel halkalar şeklinde seviyeleri göstererek hiyerarşik verileri görselleştirir. Bölüm‑bölüm ilişkilerini açıklamaya yardımcı olur ve iç içe geçmiş kategorileri net ve kompakt bir formatta temsil etmek için idealdir.

1. [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksi kullanarak bir slayta referans alın.
1. `ChartType.SUNBURST` tipini belirterek varsayılan veriyle bir grafik ekleyin.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu Python kodu, bir güneş patlaması grafiği oluşturmayı gösterir:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.SUNBURST, 20, 20, 500, 300)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    # Şube 1
    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C1", "Leaf1"))
    leaf.grouping_levels.set_grouping_item(1, "Stem1")
    leaf.grouping_levels.set_grouping_item(2, "Branch1")

    chart.chart_data.categories.add(workbook.get_cell(0, "C2", "Leaf2"))

    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C3", "Leaf3"))
    leaf.grouping_levels.set_grouping_item(1, "Stem2")

    chart.chart_data.categories.add(workbook.get_cell(0, "C4", "Leaf4"))

    # Şube 2
    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C5", "Leaf5"))
    leaf.grouping_levels.set_grouping_item(1, "Stem3")
    leaf.grouping_levels.set_grouping_item(2, "Branch2")

    chart.chart_data.categories.add(workbook.get_cell(0, "C6", "Leaf6"))

    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C7", "Leaf7"))
    leaf.grouping_levels.set_grouping_item(1, "Stem4")

    chart.chart_data.categories.add(workbook.get_cell(0, "C8", "Leaf8"))

    series = chart.chart_data.series.add(charts.ChartType.SUNBURST)
    series.labels.default_data_label_format.show_category_name = True
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D1", 4))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D2", 5))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D3", 3))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D4", 6))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D5", 9))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D6", 9))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D7", 4))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D8", 3))

    presentation.save("SunburstChart.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Güneş Patlaması Grafiği](sunburst_chart.png)

### **Histogram Grafiklerini Oluşturma**

Histogram grafikleri, sayısal verilerin dağılımını değer aralıklarına (bin) göre gruplandırarak temsil eder. Frekans, çarpıklık ve yayılım gibi veri desenlerini belirlemekte ve veri setindeki aykırı değerleri tespit etmede özellikle faydalıdır.

1. [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksi kullanarak bir slayta referans alın.
1. `ChartType.HISTOGRAM` tipini belirterek bazı veriyle bir grafik ekleyin.
1. Grafiğin veri çalışma kitabına ([ChartDataWorkbook](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdataworkbook/)) erişin.
1. Varsayılan serileri ve kategorileri temizleyin.
1. Yeni seriler ve kategoriler ekleyin.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu Python kodu, bir histogram grafiği oluşturmayı gösterir:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.HISTOGRAM, 20, 20, 500, 300)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.HISTOGRAM)
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A1", 15))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A2", -41))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A3", 16))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A4", 10))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A5", -23))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A6", 16))

    chart.axes.horizontal_axis.aggregation_type = charts.AxisAggregationType.AUTOMATIC

    presentation.save("HistogramChart.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Histogram Grafiği](histogram_chart.png)

### **Radar Grafiklerini Oluşturma**

Radar grafikleri, birden çok değişkeni iki boyutlu bir formatta göstererek aynı anda karşılaştırmayı kolaylaştırır. Performans ölçütleri ya da özellikler arasında desenler, güçlü yanlar ve zayıf yönleri tanımlamak için özellikle yararlıdır.

1. [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksi kullanarak bir slayta referans alın.
1. `ChartType.RADAR` tipini belirterek bazı veriyle bir grafik ekleyin.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu Python kodu, bir radar grafiği oluşturmayı gösterir:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides[0].shapes.add_chart(slides.charts.ChartType.RADAR, 20, 20, 500, 300)
    presentation.save("RadarСhart.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Radar Grafiği](radar_chart.png)

### **Çok Kategorili Grafikler Oluşturma**

Çok kategorili grafikler, birden fazla kategorik gruplamayı içeren verileri göstermek için kullanılır; böylece birden çok boyutta aynı anda değerleri karşılaştırabilirsiniz. Karmaşık, çok katmanlı veri setlerinde eğilimleri ve ilişkileri analiz etmek istediğinizde özellikle yardımcıdır.

1. [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksi kullanarak bir slayta referans alın.
1. `ChartType.CLUSTERED_COLUMN` tipini belirterek varsayılan veriyle bir grafik ekleyin.
1. Grafiğin veri çalışma kitabına ([ChartDataWorkbook](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdataworkbook/)) erişin.
1. Varsayılan serileri ve kategorileri temizleyin.
1. Yeni seriler ve kategoriler ekleyin.
1. Grafik serileri için yeni veri ekleyin.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu Python kodu, çok kategorili bir grafik oluşturmayı gösterir:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    worksheet_index = 0

    category = chart.chart_data.categories.add(workbook.get_cell(0, "c2", "A"))
    category.grouping_levels.set_grouping_item(1, "Group1")
    category = chart.chart_data.categories.add(workbook.get_cell(0, "c3", "B"))

    category = chart.chart_data.categories.add(workbook.get_cell(0, "c4", "C"))
    category.grouping_levels.set_grouping_item(1, "Group2")
    category = chart.chart_data.categories.add(workbook.get_cell(0, "c5", "D"))

    category = chart.chart_data.categories.add(workbook.get_cell(0, "c6", "E"))
    category.grouping_levels.set_grouping_item(1, "Group3")
    category = chart.chart_data.categories.add(workbook.get_cell(0, "c7", "F"))

    category = chart.chart_data.categories.add(workbook.get_cell(0, "c8", "G"))
    category.grouping_levels.set_grouping_item(1, "Group4")
    category = chart.chart_data.categories.add(workbook.get_cell(0, "c9", "H"))

    # Bir seri ekleyin.
    series = chart.chart_data.series.add(workbook.get_cell(0, "D1", "Series 1"), charts.ChartType.CLUSTERED_COLUMN)

    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D2", 10))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D3", 20))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D4", 30))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D5", 40))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D6", 50))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D7", 60))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D8", 70))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D9", 80))

    # Sunumu grafiğiyle kaydedin.
    presentation.save("MultiCategoryChart.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Çok Kategorili Grafik](multi_category_chart.png)

### **Harita Grafiklerini Oluşturma**

Harita grafikleri, coğrafi verileri ülke, eyalet veya şehir gibi belirli konumlara eşleyerek görselleştirir. Bölgesel eğilimleri, demografik verileri ve mekânsal dağılımları net ve görsel açıdan çekici bir biçimde analiz etmeye özellikle yararlıdır.

Bu Python kodu, bir harita grafiği oluşturmayı gösterir:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.MAP, 20, 20, 500, 300)
    presentation.save("mapChart.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Harita Grafiği](map_chart.png)

### **Kombinasyon Grafiklerini Oluşturma**

Kombinasyon grafiği (veya combo grafiği), tek bir grafikte iki veya daha fazla grafik türünü birleştirir. Bu grafik, birden çok veri seti arasındaki ilişkileri belirlemenize, karşılaştırmanıza veya farklılıkları incelemenize olanak tanır.

![Kombinasyon Grafiği](combination_chart.png)

Aşağıdaki Python kodu, yukarıda gösterilen kombinasyon grafiğini bir PowerPoint sunumunda oluşturmayı gösterir:

```python
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

    # Grafiğin başlığını ayarlayın.
    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("Chart Title")
    chart.chart_title.overlay = False
    title_paragraph = chart.chart_title.text_frame_for_overriding.paragraphs[0]
    title_format = title_paragraph.paragraph_format.default_portion_format

    title_format.font_bold = slides.NullableBool.FALSE
    title_format.font_height = 18

    # Grafiğin açıklamasını ayarlayın.
    chart.legend.position = charts.LegendPositionType.BOTTOM
    chart.legend.text_format.portion_format.font_height = 12

    # Varsayılan oluşturulan serileri ve kategorileri sil.
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    worksheet_index = 0
    workbook = chart.chart_data.chart_data_workbook

    # Yeni kategoriler ekleyin.
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 1, 0, "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 2, 0, "Category 2"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 3, 0, "Category 3"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 4, 0, "Category 4"))

    # İlk seriyi ekleyin.
    series_name_cell = workbook.get_cell(worksheet_index, 0, 1, "Series 1")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    series.parent_series_group.overlap = -25
    series.parent_series_group.gap_width = 220

    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 1, 4.3))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 1, 2.5))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 1, 3.5))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 1, 4.5))

    return chart


def add_second_series_to_chart(chart):
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    series_name_cell = workbook.get_cell(worksheet_index, 0, 2, "Series 2")
    series = chart.chart_data.series.add(series_name_cell, charts.ChartType.CLUSTERED_COLUMN)

    series.parent_series_group.overlap = -25
    series.parent_series_group.gap_width = 220

    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 2, 2.4))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 2, 4.4))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 2, 1.8))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 2, 2.8))


def add_third_series_to_chart(chart):
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    series_name_cell = workbook.get_cell(worksheet_index, 0, 3, "Series 3")
    series = chart.chart_data.series.add(series_name_cell, charts.ChartType.LINE)

    series.data_points.add_data_point_for_line_series(workbook.get_cell(worksheet_index, 1, 3, 2.0))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(worksheet_index, 2, 3, 2.0))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(worksheet_index, 3, 3, 3.0))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(worksheet_index, 4, 3, 5.0))

    series.plot_on_second_axis = True


def set_primary_axes_format(chart):
    # Yatay ekseni ayarla.
    horizontal_axis = chart.axes.horizontal_axis
    horizontal_axis.text_format.portion_format.font_height = 12.0
    horizontal_axis.format.line.fill_format.fill_type = slides.FillType.NO_FILL

    set_axis_title(horizontal_axis, "X Axis")

    # Dikey ekseni ayarla.
    vertical_axis = chart.axes.vertical_axis
    vertical_axis.text_format.portion_format.font_height = 12.0
    vertical_axis.format.line.fill_format.fill_type = slides.FillType.NO_FILL

    set_axis_title(vertical_axis, "Y Axis 1")

    # Dikey ana ızgara çizgileri rengini ayarla.
    major_grid_lines_format = vertical_axis.major_grid_lines_format.line.fill_format
    major_grid_lines_format.fill_type = slides.FillType.SOLID
    major_grid_lines_format.solid_fill_color.color = draw.Color.from_argb(217, 217, 217)


def set_secondary_axes_format(chart):
    # İkincil yatay ekseni ayarla.
    secondary_horizontal_axis = chart.axes.secondary_horizontal_axis
    secondary_horizontal_axis.position = charts.AxisPositionType.BOTTOM
    secondary_horizontal_axis.cross_type = charts.CrossesType.MAXIMUM
    secondary_horizontal_axis.is_visible = False
    secondary_horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL
    secondary_horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    # İkincil dikey ekseni ayarla.
    secondary_vertical_axis = chart.axes.secondary_vertical_axis
    secondary_vertical_axis.position = charts.AxisPositionType.RIGHT
    secondary_vertical_axis.text_format.portion_format.font_height = 12.0
    secondary_vertical_axis.format.line.fill_format.fill_type = slides.FillType.NO_FILL
    secondary_vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL
    secondary_vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    set_axis_title(secondary_vertical_axis, "Y Axis 2")


def set_axis_title(axis, axis_title):
    axis.has_title = True
    axis.title.overlay = False
    title_portion_format = axis.title.add_text_frame_for_overriding(axis_title).paragraphs[0].paragraph_format.default_portion_format
    title_portion_format.font_bold = slides.NullableBool.FALSE
    title_portion_format.font_height = 12.0
```

## **Grafikleri Güncelleme**

Aspose.Slides for Python via .NET, grafik verilerini, biçimlendirmesini ve stilini değiştirerek PowerPoint grafiklerini güncellemenizi sağlar. Bu özellik, sunumları dinamik içerikle güncel tutmayı kolaylaştırır ve grafiklerin mevcut veri ve görsel standartları doğru yansıtmasını sağlar.

1. Grafik içeren sunumu temsil eden [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksi kullanarak bir slayta referans alın.
1. Tüm şekilleri dolaşarak grafiği bulun.
1. Grafiğin veri çalışma sayfasına erişin.
1. Seri değerlerini değiştirerek grafik veri serilerini düzenleyin.
1. Yeni bir seri ekleyin ve verilerini doldurun.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu Python kodu, bir grafiği güncellemeyi gösterir:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

chart_name = "My chart"

# PPTX dosyasını temsil eden Presentation sınıfını örnekleyin.
with slides.Presentation("ExistingChart.pptx") as presentation:

    # İlk slayta erişin.
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, charts.Chart) and shape.name == chart_name:
            chart = shape

            # Grafik veri sayfasının dizinini ayarlayın.
            worksheet_index = 0

            # Grafik veri çalışma kitabını alın.
            workbook = chart.chart_data.chart_data_workbook

            # Grafik kategori adlarını değiştirin.
            workbook.get_cell(worksheet_index, 1, 0, "Modified Category 1")
            workbook.get_cell(worksheet_index, 2, 0, "Modified Category 2")

            # İlk grafik serisini alın.
            series = chart.chart_data.series[0]

            # Seri verilerini güncelleyin.
            workbook.get_cell(worksheet_index, 0, 1, "New_Series1")  # Seri adını değiştiriliyor.
            series.data_points[0].value.data = 90
            series.data_points[1].value.data = 123
            series.data_points[2].value.data = 44

            # İkinci grafik serisini alın.
            series = chart.chart_data.series[1]

            # Seri verilerini güncelleyin.
            workbook.get_cell(worksheet_index, 0, 2, "New_Series2")  # Seri adını değiştiriliyor.
            series.data_points[0].value.data = 23
            series.data_points[1].value.data = 67
            series.data_points[2].value.data = 99

            # Yeni bir seri ekleyin.
            series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 3, "Series 3"), chart.type)

            # Seri verilerini doldurun.
            series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 3, 20))
            series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 3, 50))
            series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 3, 30))

            chart.type = charts.ChartType.CLUSTERED_CYLINDER

            # Grafiği içeren sunumu kaydedin.
            presentation.save("ModifiedChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Grafikler İçin Veri Aralığını Ayarlama**

Aspose.Slides for Python via .NET, bir çalışma sayfasındaki belirli bir veri aralığını grafiğinizin veri kaynağı olarak tanımlamanıza esneklik sağlar. Bu sayede, çalışma sayfasının yalnızca bir kısmını grafiğe eşleyebilir, seriler ve kategoriler için hangi hücrelerin katkıda bulunacağını kontrol edebilirsiniz. Sonuç olarak, grafiklerinizi çalışma sayfanızdaki en son veri değişiklikleriyle kolayca güncelleyebilir ve senkronize edebilir, PowerPoint sunumlarınızın güncel ve doğru bilgiler içermesini sağlayabilirsiniz.

1. Grafik içeren sunumu temsil eden [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksi kullanarak bir slayta referans alın.
1. Tüm şekilleri dolaşarak grafiği bulun.
1. Grafik verisine erişin ve aralığı ayarlayın.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu Python kodu, bir grafik için veri aralığını ayarlamayı gösterir:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

chart_name = "My chart"

# PPTX dosyasını temsil eden Presentation sınıfını örnekleyin.
with slides.Presentation("ExistingChart.pptx") as presentation:

    # İlk slayta erişin.
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, charts.Chart) and shape.name == chart_name:
            chart = shape
            chart.chart_data.set_range("Sheet1!A1:B4")

    presentation.save("DataRange.pptx", slides.export.SaveFormat.PPTX)
```

## **Grafiklerde Varsayılan İşaretleyicileri Kullanma**

Grafiklerde varsayılan işaretleyicileri kullandığınızda, her grafik serisi otomatik olarak farklı bir varsayılan işaretleyici sembolü alır.

Bu Python kodu, bir grafik serisi işaretleyicisini otomatik olarak ayarlamayı gösterir:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 10, 10, 400, 400)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook

    series = chart.chart_data.series.add(workbook.get_cell(0, 0, 1, "Series 1"), chart.type)

    chart.chart_data.categories.add(workbook.get_cell(0, 1, 0, "C1"))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(0, 1, 1, 24))

    chart.chart_data.categories.add(workbook.get_cell(0, 2, 0, "C2"))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(0, 2, 1, 23))

    chart.chart_data.categories.add(workbook.get_cell(0, 3, 0, "C3"))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(0, 3, 1, -10))

    chart.chart_data.categories.add(workbook.get_cell(0, 4, 0, "C4"))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(0, 4, 1, None))

    series2 = chart.chart_data.series.add(workbook.get_cell(0, 0, 2, "Series 2"), chart.type)

    # Serinin verilerini doldurun.
    series2.data_points.add_data_point_for_line_series(workbook.get_cell(0, 1, 2, 30))
    series2.data_points.add_data_point_for_line_series(workbook.get_cell(0, 2, 2, 10))
    series2.data_points.add_data_point_for_line_series(workbook.get_cell(0, 3, 2, 60))
    series2.data_points.add_data_point_for_line_series(workbook.get_cell(0, 4, 2, 40))

    chart.has_legend = True
    chart.legend.overlay = False

    presentation.save("DefaultMarkersInChart.pptx", slides.export.SaveFormat.PPTX)
```

## **SSS**

**Aspose.Slides for Python via .NET tarafından hangi grafik türleri destekleniyor?**

Aspose.Slides for Python via .NET, çubuk, çizgi, pasta, alan, saçılım, histogram, radar ve daha birçok grafik türünü destekler. Bu esneklik, veri görselleştirme ihtiyaçlarınıza en uygun grafik türünü seçmenizi sağlar.

**Bir slayta yeni bir grafik nasıl eklenir?**

Yeni bir grafik eklemek için önce [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturur, istenen slayta indeksle erişir ve ardından grafik türü ve başlangıç verilerini belirterek grafik ekleme metodunu çağırırsınız. Bu işlem, grafiği doğrudan sunumunuza entegre eder.

**Grafiğin gösterdiği veri nasıl güncellenir?**

Grafiğin verisini, veri çalışma kitabına ([ChartDataWorkbook](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdataworkbook/)) erişerek, varsayılan serileri ve kategorileri temizleyip, kendi özel verilerinizi ekleyerek güncelleyebilirsiniz. Bu sayede grafik, en son verileri yansıtacak şekilde programlı olarak yenilenir.

**Grafiğin görünümü özelleştirilebilir mi?**

Evet, Aspose.Slides for Python via .NET kapsamlı özelleştirme seçenekleri sunar. Renkler, yazı tipleri, etiketler, açıklamalar ve diğer biçimlendirme öğelerini değiştirerek grafiğin görünümünü tasarım gereksinimlerinize göre şekillendirebilirsiniz.