---
title: Python ile Sunumlarda Grafik Veri Serilerini Yönetme
linktitle: Veri Serileri
type: docs
url: /tr/python-net/chart-series/
keywords:
- grafik serisi
- seri örtüşmesi
- seri rengi
- kategori rengi
- seri adı
- veri noktası
- seri boşluğu
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Python ile sunumlarda grafik serilerini, veri noktalarını, çalışma kitabı hücrelerini, biçimlendirmeyi, örtüşmeyi, boşluk genişliğini ve negatif değerleri nasıl yöneteceğinizi öğrenin."
---
## **Genel Bakış**

Bir grafik, çizilen değerlerini çalışma kitabı hücrelerinde veya doğrudan sayısal sabitler olarak depolayabilir. Bir [ChartSeries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/) bir değer kümesini temsil eder ve her bir [ChartDataPoint](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/) bu kümedeki bir noktayı temsil eder. [ChartCategory](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategory/) nesneleri, seriler tarafından paylaşılan etiketleri veya gruplama değerlerini sağlar. Varsayılan verilerle oluşturulan grafiklerde, seri adları, kategoriler ve nokta değerleri, grafik çalışma kitabındaki [ChartDataCell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/) nesnelerini kullanır.

Tipik bir kategori grafiği için, varsayılan çalışma kitabı seri adları için satır 0, kategori adları için sütun 0 ve geri kalan hücreleri seri değerleri için kullanır. [ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) yöntemine geçirilen çalışma sayfası, satır ve sütun indisleri sıfır‑tabanlıdır. Bu düzen, varsayılan veri ile bir grafik oluştururken kullanışlıdır, ancak mevcut her grafiğin bunu kullandığını varsaymayın. Yüklenmiş bir sunumda, çalışma kitabı değerlerini değiştirmeden önce seriler, kategoriler ve veri noktaları tarafından başvurulan hücreleri inceleyin.

Grafik ayarlarının üç farklı kapsamı vardır:

- Seri‑seviyesi ayarlar, örneğin [ChartSeries.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/format/) bir serideki tüm noktalar için varsayılan görünümü sağlar.
- Veri‑noktası ayarları, örneğin [ChartDataPoint.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/format/) bir nokta için serinin görünümünü geçersiz kılar.
- Grup ayarları, aynı [ChartSeriesGroup](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/) içinde bulunan uyumlu serilere uygulanır. Örtüşme veya boşluk genişliği gibi seçenekleri ayarlamanız gerektiğinde, grup özelliğine [ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/) üzerinden erişin.

Açıkça bir nokta veya seri dolgu ayarı yapılmadığında, grafik stili ve teması otomatik görünümü belirler. Hem seri hem de nokta biçimlendirmesi mevcutsa, nokta biçimlendirmesi o nokta için önceliklidir.

![grafik-seri-powerpoint](chart-series-powerpoint.png)

Küme silindir grafiği için, [3D seri tipini veya çubuk şekli değiştirme](/slides/tr/python-net/3d-chart/#change-the-3d-series-type-and-bar-shape) ilk seriyi nasıl etkilediğine bakın.

## **Sayısal Sabitler Kullanarak Seri Değerlerini Ayarlama**

Seri değerleri uygulama verileri veya hesaplamalarından geliyorsa ve çalışma sayfası hücre referansları gerektirmiyorsa sayısal sabitler kullanın. Her bir noktanın [value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/value/) özelliğine [as_literal_double](https://reference.aspose.com/slides/python-net/aspose.slides.charts/doublechartvalue/as_literal_double/) üzerinden atamadan önce [data_source_type_for_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_values/) özelliğini [DataSourceType.DOUBLE_LITERALS](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datasourcetype/) olarak ayarlayın.

Koleksiyon ayarı, o serideki tüm nokta değerlerinin kaynak tipini kontrol eder. Her bir noktanın [value.data_source_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/basechartvalue/data_source_type/) seçili tipi raporlar; koleksiyon ayarıyla değiştirin. `WORKSHEET` kullanıyorsanız, başvurulan hücreye erişmek için [as_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/doublechartvalue/as_cell/) kullanın. `DOUBLE_LITERALS` kullanıyorsanız, sayıyı doğrudan okumak veya yazmak için `as_literal_double` kullanın.

Aşağıdaki örnek, varsayılan seriler ve kategorilerle bir sütun grafiği oluşturur, ardından ilk serisinin mevcut noktalarına 10, 20 vb. hesaplanmış değerleri atar. Sunumu kaydeder, yeniden açar ve saklanan değerleri yazdırır.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)
    series = chart.chart_data.series[0]

    series.data_points.data_source_type_for_values = charts.DataSourceType.DOUBLE_LITERALS
    for i in range(len(series.data_points)):
        series.data_points[i].value.as_literal_double = (i + 1) * 10

    presentation.save("numeric_literals.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("numeric_literals.pptx") as reopened_presentation:
    reopened_slide = reopened_presentation.slides[0]
    reopened_chart = reopened_slide.shapes[0]
    reopened_series = reopened_chart.chart_data.series[0]
    for point in reopened_series.data_points:
        print(point.value.as_literal_double)
```

Nokta değeri kaynak türü, grafik iç veya dış çalışma kitabı yapılandırmasını belirten [ChartData.data_source_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/) öğesinden ayrı bir özelliktir. Sayısal sabitleri kullanmak, gömülü çalışma kitabını otomatik olarak kaldırmaz. Bu örnekte, çalışma kitabı kategori etiketleri, seri adları ve diğer seriler için kullanılabilir halde kalır. Çalışma kitabı yönetimi için [Chart Workbook](/slides/tr/python-net/chart-workbook/) bölümüne bakın.

Dağılım (scatter) ve balon grafiklerinde, [x_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/x_value/) ve [y_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/y_value/) kaynaklarını seçmek üzere sırasıyla [data_source_type_for_x_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_x_values/) ve [data_source_type_for_y_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_y_values/) ayarlayın. Balon grafikleri ayrıca [bubble_size](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/bubble_size/) için [data_source_type_for_bubble_sizes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_bubble_sizes/) kullanır. Her uygulanabilir kaynağı `DOUBLE_LITERALS` olarak ayarlayın, ardından o değerin `as_literal_double` özelliği üzerinden sayıları atayın.

## **Grafik Serisi Örtüşmesini Ayarlama**

[ChartSeries.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/overlap/) 2D bir grafikte çubukların veya sütunların ne kadar örtüştüğünü -%100’dan +%100’e kadar raporlar. Bu, üst grup üzerindeki ayarın yalnızca bir okuma yansımasıdır. Tüm uyumlu serileri güncellemek için [ChartSeriesGroup.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/overlap/) ayarlayın. Bu seçenek, gruplanmış çubuk veya sütun gösteren grafik tiplerine uygulanır; bir kombinasyon grafiğindeki bağımsız seri gruplarını etkilemez.

Aşağıdaki örnek, ilk seriyi içeren grup için örtüşmeyi ayarlar:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    # Yeni grafik örnek seriler, kategoriler ve değerler içerir.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.overlap = overlap_percent

    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Seri örtüşmesi](series_overlap.png)

## **Seri Dolgu Rengini Değiştirme**

Tüm bir seri için varsayılan dolguyu ayarlamak üzere [ChartSeries.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/format/) kullanın. Bir noktanın açık bir dolgusu zaten varsa, onun [ChartDataPoint.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/format/) ayarı o nokta için seri dolgusunu geçersiz kılar.

Aşağıdaki örnek, ilk seriye katı mavi bir dolgu uygular:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = drawing.Color.blue

    presentation.save("series_color.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Seri rengi](series_color.png)

## **Seri Adını Değiştirme**

Seri adı grafik veri çalışma kitabında depolanır ve genellikle lejende görüntülenir. Küme sütun grafiği için oluşturulan varsayılan çalışma kitabında, B1 hücresi (satır 0, sütun 1) ilk serinin adını içerir. Aşağıdaki örnekteki adlandırılmış sabitler bu yapıyı açıklar:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
worksheet_index = 0
series_name_row_index = 0
first_series_column_index = 1

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    workbook = chart.chart_data.chart_data_workbook
    series_name_cell = workbook.get_cell(worksheet_index, series_name_row_index, first_series_column_index)
    series_name_cell.value = "Revenue"

    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX)
```

Ayrıca [ChartSeries.name](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/name/) tarafından zaten referans verilen hücreyi güncelleyebilirsiniz. Bu yaklaşım, mevcut bir grafikte belirli bir satır ve sütun varsayımından kaçınır:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
first_name_cell_index = 0

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series_name_cell = series.name.as_cells[first_name_cell_index]
    series_name_cell.value = "Revenue"

    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Seri adı](series_name.png)

### **Birden Çok Hücreden Adı Olan Seri Oluşturma**

Bir ürün adı ve raporlama dönemi ayrı hücrelerde tutuluyorsa birleşik bir seri adı faydalı olabilir. Örneğin, B1 hücresindeki `Product A` ile C1 hücresindeki `2026` değerlerini birleştirerek tek bir seri adı elde edebilir, her iki kısmın da kaynak hücrelerine bağlı kalmasını sağlayabilirsiniz.

İsim aralığını elde etmek için [ChartDataWorkbook.get_cell_collection](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell_collection/) kullanın, ardından bu koleksiyonu [ChartSeriesCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriescollection/add/) metoduna aktarın. `skip_hidden_cells` argümanı gizli hücrelerin dahil edilip edilmeyeceğini denetler: `True` dışlar, `False` dahil eder. Bu örnek `False` kullanarak isim aralığındaki tüm hücreleri dahil eder.

Aşağıdaki örnek, bir sunumda bir seri ve iki veri noktası oluşturur. B1:C1 hücreleri yalnızca seri adını, A2:A3 hücreleri kategori etiketlerini, B2:B3 hücreleri ise sayısal değerleri sağlar.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 620, 180)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    chart.has_legend = True

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    # Bu iki hücre seri adını sağlar.
    workbook.get_cell(0, 0, 1, "Product A")
    workbook.get_cell(0, 0, 2, "2026")
    name_cells = workbook.get_cell_collection("Sheet1!$B$1:$C$1", False)
    series = chart.chart_data.series.add(name_cells, charts.ChartType.CLUSTERED_COLUMN)

    # Ayrı hücreler kategorileri ve sayısal veri noktalarını sağlar.
    north_category = workbook.get_cell(0, 1, 0, "North")
    south_category = workbook.get_cell(0, 2, 0, "South")
    chart.chart_data.categories.add(north_category)
    chart.chart_data.categories.add(south_category)
    north_value = workbook.get_cell(0, 1, 1, 120)
    south_value = workbook.get_cell(0, 2, 1, 150)
    series.data_points.add_data_point_for_bar_series(north_value)
    series.data_points.add_data_point_for_bar_series(south_value)

    presentation.save("composite_series_name.pptx", slides.export.SaveFormat.PPTX)
```

Ortaya çıkan seri adı `Product A 2026` olur; iki hücre değeri arasında bir boşluk bulunur. Lejende her iki sütun için tek bir giriş olarak gösterilir. Aşağıdaki görsel, kaydedilen sunumdan render edilmiştir:

![Kuzey ve Güney değerli sütun grafiği; bileşik seri adı Product A 2026 lejende yer alıyor](composite_series_name.png)

## **Otomatik Seri Dolgu Rengini Alma**

[ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/) yöntemi, seri indeksine ve grafik stiline göre hesaplanan rengi döndürür. Bu renk, seri dolgu açıkça tanımlanmadığında kullanılır. Yöntem rengi okur; yeni bir dolgu atamaz.

Aşağıdaki örnek, her varsayılan serinin otomatik rengini yazdırır:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series_count = len(chart.chart_data.series)
    for series_index in range(series_count):
        series = chart.chart_data.series[series_index]
        automatic_color = series.get_automatic_series_color()
        print(f"Series {series_index}: {automatic_color.name}")
```

Varsayılan grafik stili için örnek çıktı:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

Kesin renkler grafik stiline ve temaya bağlıdır.

## **Bir Grafik Serisi İçin Negatif Dolgu Rengini Ters Çevirme**

Çubuk, sütun ve balon serileri için, negatif değerleri farklı bir dolgu ile göstermek amacıyla [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/invert_if_negative/) kullanılabilir. Normal seri dolgusunu katı olarak ayarlayın, ters çevirme özelliğini etkinleştirin ve negatif değer rengine [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/) üzerinden atayın. Negatif sayılar çalışma kitabında değişmeden kalır; yalnızca gösterim rengi değişir.

Aşağıdaki örnek, varsayılan grafik verisini tek bir seriyle değiştirir. Çalışma sayfası 0. satırı seri adını, 0. sütunu kategori adlarını, 1. sütunu ise değerleri içerir:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
worksheet_index = 0
header_row_index = 0
category_column_index = 0
first_series_column_index = 1
first_data_row_index = 1

category_names = ["Category 1", "Category 2", "Category 3"]
series_values = [-20, 50, -30]

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    chart_data = chart.chart_data
    workbook = chart_data.chart_data_workbook

    chart_data.series.clear()
    chart_data.categories.clear()

    series_name_cell = workbook.get_cell(worksheet_index, header_row_index, first_series_column_index, "Series 1")
    series = chart_data.series.add(series_name_cell, chart.type)

    category_count = len(category_names)
    for category_index in range(category_count):
        data_row_index = first_data_row_index + category_index
        category_name = category_names[category_index]
        series_value = series_values[category_index]

        category_cell = workbook.get_cell(worksheet_index, data_row_index, category_column_index, category_name)
        chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(worksheet_index, data_row_index, first_series_column_index, series_value)
        series.data_points.add_data_point_for_bar_series(value_cell)

    automatic_series_color = series.get_automatic_series_color()
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = automatic_series_color
    series.invert_if_negative = True
    series.inverted_solid_fill_color.color = drawing.Color.red

    presentation.save("inverted_solid_fill_color.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Ters çevrilmiş katı dolgu rengi](inverted_solid_fill_color.png)

Tek bir nokta için ters çevirme, [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/) ile etkinleştirilebilir. Aşağıdaki örnekte, seri için ters çevirme devre dışı bırakılır, yalnızca seçilen nokta için etkinleştirilir ve nokta negatif bir değer alarak etkisi gösterilir:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
target_data_point_index = 2
negative_value = -30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    automatic_series_color = series.get_automatic_series_color()
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = automatic_series_color
    series.inverted_solid_fill_color.color = drawing.Color.red
    series.invert_if_negative = False

    data_point = series.data_points[target_data_point_index]
    data_point.value.as_cell.value = negative_value
    data_point.invert_if_negative = True

    presentation.save("data_point_invert_color_if_negative.pptx", slides.export.SaveFormat.PPTX)
```

## **Belirli Bir Veri Noktasının Değerini Temizleme**

Diğer noktaları kaldırmadan bir noktayı boş bırakmak için, onun arka plan çalışma kitabı hücresini `None` yapın. Bir sütun grafiğinde, çizilen değer [ChartDataPoint.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/value/) üzerinden elde edilir. Veri noktası aynı kategori konumunda kalır, ancak grafik boş‑değer ayarlarına göre değeri boş olarak işler.

Aşağıdaki örnek, ilk seride sadece ikinci noktayı temizler:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
target_data_point_index = 1

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    data_point = series.data_points[target_data_point_index]
    data_point.value.as_cell.value = None

    presentation.save("clear_data_point_value.pptx", slides.export.SaveFormat.PPTX)
```

Dağılım (scatter) grafikleri ayrı X ve Y hücreleri kullanır, balon grafikleri ayrıca bir boyut hücresi kullanır. Silmek istediğiniz değeri temsil eden hücreyi yalnızca temizleyin. Diğer noktaları korumak istiyorsanız [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/clear/) çağırmayın; bu yöntem serideki tüm veri noktalarını kaldırır.

## **Boş Hücrelerin Görüntülenmesini Kontrol Etme**

Değer içeren gizli hücreler, boş hücrelerden ayrı bir durum oluşturur. Gizli satır ve sütunlardaki verileri dahil edip etmeyeceğinizi belirlemek için [Gizli Satır ve Sütunlardan Veri Dahil Etme](/slides/tr/python-net/chart-workbook/#include-data-from-hidden-rows-and-columns) bölümüne bakın.

Boş bir çalışma kitabı hücresi eksik veriyi temsil eder; `0` içeren bir hücre bilinen sayısal bir değeri temsil eder. Hücreyi boş yapmak için [ChartDataCell.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/value/) özelliğini `None` olarak ayarlayın. Sayısal sıfır, boş‑hücre ayarından bağımsız olarak sıfır kalır.

Boş hücrelerin grafiğe nasıl yansıtılacağını seçmek için [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) özelliğini kullanın. Bu ayar tüm grafik için geçerlidir ve boşlukların nasıl çizileceğini değiştirir; boş hücreyi sıfır ya da ara bir değerle doldurmaz.

Aşağıdaki bağımsız örnek, bir satır grafiği oluşturur, 3. Gün için değeri temizler ve her bir modu ile aynı grafiği kaydeder. Girdi dosyasına ihtiyaç yoktur. [ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/) 0‑ıncı çalışma sayfasını, 0‑ıncı sütunu kategori etiketlerini, 1‑inci sütunu değerleri; 0‑ıncı satır ise seri adını tutar. Son veri `10, 20, empty, 30, 40` şeklindedir.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 40, 40, 640, 400)
    chart_data = chart.chart_data
    workbook = chart_data.chart_data_workbook

    chart_data.series.clear()
    chart_data.categories.clear()

    series_name_cell = workbook.get_cell(0, 0, 1, "Measurements")
    series = chart_data.series.add(series_name_cell, chart.type)
    values = [10, 20, 25, 30, 40]

    for i, value in enumerate(values):
        category_cell = workbook.get_cell(0, i + 1, 0, f"Day {i + 1}")
        chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(0, i + 1, 1, value)
        series.data_points.add_data_point_for_line_series(value_cell)

    # 3. günü gerçekten boş bırak, ancak kategori ve veri noktasını koru.
    workbook.get_cell(0, 3, 1).value = None

    modes = [("Gap", charts.DisplayBlanksAsType.GAP), ("Zero", charts.DisplayBlanksAsType.ZERO), ("Span", charts.DisplayBlanksAsType.SPAN)]
    for mode_name, mode in modes:
        chart.display_blanks_as = mode
        presentation.save(f"empty_cells_{mode_name}.pptx", slides.export.SaveFormat.PPTX)
```

Her çıktı dosyası, kaydetmeden önce ayarlanan modu içerir: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` ve `empty_cells_Span.pptx`. Tek bir sürüm kaydetmek isterseniz, istediğiniz modu atayın ve sunumu bir kez kaydedin; modlar arasında döngü yapmayın.

Aşağıdaki karşılaştırma, üç dosyada aynı veriyi gösterir. 3. Gün her durumda çalışma kitabında boştur:

![Boş hücrelerin gösterimi: Gap satırı 3’te keser, Zero satırı sıfıra düşürür, Span ise 2. günden 4. güne bağlar.](display_blanks_as.png)

Görünüm, grafik tipine bağlıdır. Bir satır grafiği üç modu da karşılaştırmayı kolaylaştırır. Çubuk ve sütun grafiklerinde eksik bir kategori için bağlayıcı bir çizgi olmadığından `SPAN` yukarıdaki gibi bir bağlama segmenti üretmez; eksik bir sütun ve sıfır‑yüksekliğinde bir sütun da benzer görünebilir. Benzer şekilde, yalnızca işaretleyicileri olan dağılım grafiği de bağlayıcı çizgi içermez. Her grafik tipinde üç ayrı sonuç beklemeyin; kullandığınız tip için çıktıyı kontrol edin.

## **Seri Boşluk Genişliğini Ayarlama**

Boşluk genişliği, yan yana çubuk veya sütun kümeleri arasındaki boşluğu, çubuk veya sütun genişliğinin yüzde olarak ifadesini belirtir. Örtüşme gibi, bu ayar tek bir seriye değil, üst grup seviyesine aittir. Grup için bir kez [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) ayarlayın. Büyük bir değer kümeler arasındaki boşluğu artırırken, daha küçük bir değer onları daha sıklaştırır.

Aşağıdaki örnek boşluk genişliğini değiştirir ve yalnızca son sunumu kaydeder:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
gap_width_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.gap_width = gap_width_percent

    presentation.save("gap_width_30.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Boşluk genişliği](gap_width.png)

## **Seri Çizgilerini Gösterme veya Gizleme**

Seri çizgileri, bir grafiğin ilgili bölümlerini görsel olarak birbirine bağlar. Desteklenen birleşik çubuk ve OfPie grafiklerinde [ChartSeriesGroup.has_series_lines](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/has_series_lines/) kullanılarak gösterilip gizlenebilir. İki boyutlu birleşik çubuk ve sütun grafiklerinde, bu çizgiler kategori bazında karşılık gelen yığın sınırlarını bağlar. Pie of Pie ve Bar of Pie grafiklerinde ise ana grafiği ikincil grafiğe bağlar. Bu ayar diğer grafik tipleri için genel bir bağlayıcı değildir.

Gruba, [ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/) üzerinden erişin. Ayar, grup içindeki tüm serileri etkiler. [ChartSeries.has_series_lines](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/has_series_lines/) sadece okuma amaçlıdır ve üst grup ayarını yansıtır; güncellemek için grup özelliğini değiştirin.

Aşağıdaki örnek, varsayılan veri ile bir [ChartType.PIE_OF_PIE](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) grafiği oluşturur, ardından seri çizgileri etkinleştirilmiş ve devre dışı bırakılmış iki sunum kaydeder.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 600, 400)
    series = chart.chart_data.series[0]
    series_group = series.parent_series_group

    series_group.has_series_lines = True
    presentation.save("series_lines_enabled.pptx", slides.export.SaveFormat.PPTX)

    series_group.has_series_lines = False
    presentation.save("series_lines_disabled.pptx", slides.export.SaveFormat.PPTX)
```

| Seri çizgileri etkin | Seri çizgileri devre dışı |
| --- | --- |
| ![Seri çizgileri etkin Pie of Pie grafiği](series_lines_enabled.png) | ![Seri çizgileri devre dışı Pie of Pie grafiği](series_lines_disabled.png) |
| İki çizgi, ana pasta dilimini ikincil pasta dilimine bağlar. | Her iki pasta da görünür, ama bağlayıcı çizgiler gizlenir. |

Seri çizgileri, etiketleri veri noktalarına bağlayan lider çizgileri, eksenlerdeki aralıkları gösteren ızgara çizgileri ve veri değerlerini temsil eden satır grafiği çizgileri gibi öğelerden farklıdır. Bu ayar bu öğeleri kontrol etmez.

## **SSS**

**Hangi grafik tipleri veri serilerini destekler?**

[ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) enum’u tarafından temsil edilen tüm grafik tipleri veri kullanır, ancak serilerin değer yapısı ve ayarları tipten tipe aynı değildir. Örneğin, kategori grafiklerinde kategori ve değer, dağılım grafiklerinde X ve Y değerleri, balon grafiklerinde ise balon boyutları bulunur. Seri tipine uygun veri‑nokta oluşturma yöntemi kullanılmalıdır. Örtüşme ve boşluk genişliği gibi seçenekler yalnızca uyumlu çubuk veya sütun gruplarına uygulanır.

**Grafik serisi grubu nedir?**

[ChartSeriesGroup](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/) aynı grup seviyesinde çizim ayarlarını paylaşan uyumlu serileri içerir. Bir birleşim grafiği birden fazla grup barındırabilir; bir seri üzerinden erişilen grup ayarı, grafikteki tüm serileri zorunlu olarak değiştirmez.

**Yeni oluşturulan bir grafik varsayılan veri içerir mi?**

Evet. Varsayılan olarak, [ShapeCollection.add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) örnek seriler, kategoriler ve değerler oluşturur. Bu hücreleri düzenleyebilir veya tamamen özelleştirilmiş bir veri kümesi eklemeden önce serileri ve kategorileri temizleyebilirsiniz. Bir aşırı yük (overload) aynı zamanda varsayılan veri olmadan bir grafik oluşturabilir.

**Grafik nesneleri çalışma kitabı hücrelerine nasıl bağlanır?**

Seri adları, kategori etiketleri ve veri‑nokta değerleri bir [ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/) içindeki hücrelere referans verir. Referans verilen hücreyi değiştirmek ilgili grafik öğesini günceller. Özel veri oluştururken, her noktanın istenen kategori altında çizildiğinden emin olmak için kategori satırları ile seri‑değer satırlarını hizalı tutun.

**Tüm seriyi değil tek bir noktayı nasıl temizlerim?**

İlgili değer hücresini `None` yaparak noktanın kategori konumunu boş bir nokta olarak tutun. [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/clear/) yalnızca tüm noktaları kaldırmak istediğinizde kullanılmalıdır; aksi takdirde diğer noktalar da silinir. Kategorileri de kaldırıyorsanız, her serinin değerlerini kategori koleksiyonuyla hizalı kalacak şekilde güncelleyin.

**Boş noktalar nasıl gösterilir?**

Sonuç, grafik tipine ve [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) ayarına bağlıdır. Desteklenen grafikler boşlukları, sıfır değerleri olarak ya da komşu noktaları bağlayarak gösterebilir. Sunumunuzdaki eksik verinin anlamına en uygun ayarı seçin. Tam örnek ve görsel karşılaştırma için [Boş Hücrelerin Görüntülenmesini Kontrol Etme](#control-the-display-of-empty-cells) bölümüne bakın.

**Negatif değerler nasıl biçimlendirilir?**

Desteklenen çubuk, sütun ve balon serileri için [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/invert_if_negative/) etkinleştirildikten sonra [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/) ayarlanmalıdır. Tek bir nokta için davranışı [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/) ile geçersiz kılabilirsiniz. Bu özellikler yalnızca biçimlendirmeyi etkiler; saklanan sayısal değerleri değiştirmez.

**Seri ve nokta her ikisi de biçimlendirilmişse hangi biçimlendirme geçerli olur?**

Açık veri‑nokta biçimlendirmesi o nokta için önceliklidir. Diğer noktalar açık seri biçimlendirmesini veya seri biçimlendirmesi tanımlı değilse otomatik grafik stili ve temasını kullanmaya devam eder. Örtüşme ve boşluk genişliği gibi grup özellikleri düzeni kontrol eder ve nokta‑seviyesi biçimlendirme geçersizliği oluşturmaz.

**Bir grafiğin içerebileceği seri sayısı için bir limit var mı?**

Aspose.Slides, ayrı bir sabit seri sayısı sınırı getirmez. Pratikte, sunum dosyası kısıtlamaları, kullanılabilir bellek, işleme süresi ve grafik okunabilirliği faydalı bir sınırı belirler.

**Sütunlar çok yakın veya çok uzak olduğunda ne yapılmalı?**

İlgili üst seri grubunda [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) ayarını değiştirin. Değeri artırmak kümeler arasındaki boşluğu genişletir, azaltmak ise kümeleri birbirine yaklaştırır.