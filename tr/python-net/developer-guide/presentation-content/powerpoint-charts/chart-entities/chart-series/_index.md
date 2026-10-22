---
title: Python ile Sunumlarda Grafik Veri Serilerini Yönetme
linktitle: Veri Serileri
type: docs
url: /tr/python-net/chart-series/
keywords:
- grafik serileri
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

Bir grafik, çizilen değerlerini çalışma sayfası hücrelerinde veya doğrudan sayısal sabitler olarak depolayabilir. Bir [ChartSeries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/) bir dizi ilgili değeri, her bir [ChartDataPoint](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/) ise o serideki bir noktayı temsil eder. [ChartCategory](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategory/) nesneleri, seriler tarafından paylaşılan etiketleri veya gruplama değerlerini sağlar. Varsayılan veriyle oluşturulan grafiklerde, seri adları, kategoriler ve nokta değerleri, grafik çalışma kitabındaki [ChartDataCell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/) nesneleri kullanılarak tutulur.

Tipik bir kategori grafiği için varsayılan çalışma kitabı, seri adları için satır 0, kategori adları için sütun 0 ve kalan hücreleri seri değerleri için kullanır. [ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) metoduna geçirilen çalışma sayfası, satır ve sütun indeksleri sıfır‑tabanlıdır. Bu düzen, varsayılan veriyle bir grafik oluşturduğunuzda faydalıdır, ancak mevcut her grafiğin bunu kullandığını varsaymayın. Yüklenmiş bir sunumda, çalışma kitabı değerlerini değiştirmeden önce seriler, kategoriler ve veri noktaları tarafından başvurulan hücreleri inceleyin.

Grafik ayarlarının üç farklı kapsamı vardır:

- Seri‑seviyesi ayarlar, örneğin [ChartSeries.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/format/) tüm noktalara varsayılan görünümü sağlar.
- Veri‑nokta ayarları, örneğin [ChartDataPoint.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/format/) bir noktanın seri görünümünü geçersiz kılar.
- Grup ayarları, aynı [ChartSeriesGroup](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/) içinde bulunan uyumlu serilere uygulanır. [ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/) üzerinden gruba erişerek örtüşme veya boşluk genişliği gibi seçenekleri ayarlayabilirsiniz.

Herhangi bir nokta ya da seri dolgu tanımlanmadığında, grafik stili ve teması otomatik görünümü belirler. Hem seri hem de nokta biçimlendirmesi mevcutsa, nokta biçimlendirmesi önceliklidir.

![grafik-seri-powerpoint](chart-series-powerpoint.png)

## **Sayısal Sabitler Kullanarak Seri Değerlerini Ayarlama**

Seri değerleri uygulama verilerinden ya da hesaplamalardan geliyorsa ve çalışma sayfası hücre referanslarına ihtiyaç duymuyorsa sayısal sabitler kullanın. Her bir noktanın [value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/value/) özelliğini [as_literal_double](https://reference.aspose.com/slides/python-net/aspose.slides.charts/doublechartvalue/as_literal_double/) aracılığıyla atamadan önce [data_source_type_for_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_values/) değerini [DataSourceType.DOUBLE_LITERALS](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datasourcetype/) olarak ayarlayın.

Koleksiyon ayarı, aynı serideki tüm nokta değerlerinin kaynak tipini kontrol eder. Her noktanın [value.data_source_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/basechartvalue/data_source_type/) seçilen tipi raporlar; bu tip koleksiyon ayarıyla değiştirilir. `WORKSHEET` ile başvurulan hücreye erişmek için [as_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/doublechartvalue/as_cell/) kullanın. `DOUBLE_LITERALS` ile doğrudan sayıyı okumak ya da yazmak için `as_literal_double` kullanın.

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

Nokta değer kaynak tipi, grafiğin iç ya da dış çalışma kitabı yapılandırmasını belirleyen [ChartData.data_source_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/) öğesinden ayrı bir özelliktir. Sayısal sabitler kullanmak, gömülü çalışma kitabını otomatik olarak kaldırmaz. Bu örnekte, çalışma kitabı hâlâ kategori etiketleri, seri adları ve diğer seriler için kullanılabilir. Çalışma kitabı yönetimi hakkında daha fazla bilgi için [Chart Workbook](/slides/tr/python-net/chart-workbook/) bölümüne bakın.

Dağılım (scatter) ve balon grafiklerinde, [data_source_type_for_x_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_x_values/) ve [data_source_type_for_y_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_y_values/) ayarlarıyla sırasıyla [x_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/x_value/) ve [y_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/y_value/) kaynakları seçilir. Balon grafiklerinde ayrıca [data_source_type_for_bubble_sizes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_bubble_sizes/) ile [bubble_size](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/bubble_size/) kaynağı belirlenir. Sayıları doğrudan atamak için ilgili kaynağı `DOUBLE_LITERALS` yapıp `as_literal_double` özelliğini kullanın.

## **Grafik Serisi Örtüşmesini Ayarlama**

[ChartSeries.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/overlap/) 2D bir grafikte çubuk ya da sütunların ne kadar örtüştüğünü –100 ile 100 yüzde arasında – gösterir. Bu, ebeveyn seri grubundaki ayarın yalnızca okunabilir bir yansımasıdır. Tüm uyumlu serileri güncellemek için [ChartSeriesGroup.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/overlap/) ayarlayın. Bu seçenek, gruplanmış çubuk ya da sütun gösteren grafik tiplerinde etkilidir; kombinasyon grafiklerinde ilgisiz seri gruplarını etkilemez.

Aşağıdaki örnek, ilk seriyi içeren grubun örtüşmesini ayarlar:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    # Yeni grafik, örnek seriler, kategoriler ve değerler içerir.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.overlap = overlap_percent

    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Seri örtüşmesi](series_overlap.png)

## **Seri Dolgu Rengini Değiştirme**

Tüm bir seri için varsayılan dolgu ayarlamak amacıyla [ChartSeries.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/format/) kullanın. Bir noktanın kendine özgü bir dolgu tanımlıysa, o nokta için [ChartDataPoint.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/format/) ayarı serinin dolgusunu geçersiz kılar.

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

Seri adı grafik veri çalışma kitabında saklanır ve genellikle lejanda gösterilir. Küme sütun grafiği için oluşturulan varsayılan çalışma kitabında B1 hücresi (satır 0, sütun 1) ilk serinin adını içerir. Aşağıdaki örnekte adlandırılmış sabitler bu yapıyı açıkça ortaya koyar:

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

Ayrıca [ChartSeries.name](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/name/) tarafından zaten başvurulan hücreyi güncelleyebilirsiniz. Bu yaklaşım, mevcut bir grafikte belirli bir satır ve sütun varsayımını ortadan kaldırır:

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

### **Birden Fazla Hücreden Ad Oluşturma**

Ürün adı ve raporlama dönemi ayrı hücrelerde tutulduğunda birleşik bir seri adı faydalı olur. Örneğin, B1 hücresindeki `Product A` ile C1 hücresindeki `2026` değerlerini birleştirerek hem iki kısmın kaynağa bağlı kalmasını sağlayabilir hem de tek bir seri adı elde edebilirsiniz.

[ChartDataWorkbook.get_cell_collection](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell_collection/) ile ad aralığını alın, ardından bu koleksiyonu [ChartSeriesCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriescollection/add/) metoduna geçirin. `skip_hidden_cells` argümanı gizli hücrelerin dahil edilip edilmemesini kontrol eder: `True` gizli hücreleri dışlar, `False` ise dahil eder. Bu örnek tüm hücreleri dahil etmek için `False` kullanır.

Aşağıdaki örnek, bir seri ve iki veri noktası içeren bir sunum oluşturur. B1:C1 aralığı yalnızca seri adını, A2:A3 aralığı kategori etiketlerini, B2:B3 ise sayısal değerleri sağlar.

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

Elde edilen seri adı, iki hücre değeri arasına boşluk koyularak `Product A 2026` olur. Lejanda bu, iki sütun için tek bir giriş olarak gösterilir. Aşağıdaki görsel, kaydedilen sunumdan oluşturulmuştur:

![Kuzey ve Güney değerleriyle sütun grafiği ve birleşik seri adı Product A 2026 lejanda](composite_series_name.png)

## **Otomatik Seri Dolgu Rengini Alma**

[ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/) metodu, seri indeksi ve grafik stilinden hesaplanan rengi döndürür. Bu renk, seri dolgu explicit olarak tanımlanmadığında kullanılır. Metod çağrısı sadece hesaplanan rengi okur; yeni bir dolgu atamaz.

Aşağıdaki örnek, varsayılan serilerin otomatik renklerini yazdırır:

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

## **Bir Grafik Serisi için Ters Dolgu Rengini Ayarlama**

Çubuk, sütun ve balon serileri için negatif değerleri farklı bir dolgu ile göstermek amacıyla [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/invert_if_negative/) kullanılabilir. Normal seri dolgusunu katı bir renk yapın, tersleme özelliğini etkinleştirin ve negatif değer rengi için [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/) ayarlayın. Negatif sayılar çalışma kitabında değişmeden kalır; yalnızca gösterim rengi değişir.

Aşağıdaki örnek, varsayılan grafik verisini tek bir seriye dönüştürür. Çalışma sayfası satır 0 seri adını, sütun 0 kategori adlarını, sütun 1 ise değerleri içerir:

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

![Ters katı dolgu rengi](inverted_solid_fill_color.png)

Bir nokta için terslemeyi yalnızca [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/) ile etkinleştirebilirsiniz. Aşağıdaki örnekte seri için tersleme devre dışı bırakılmış, yalnızca seçili nokta için etkinleştirilmiş ve negatif değer atanmıştır:

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

Diğer noktaları kaldırmadan bir noktayı boş bırakmak için ilgili çalışma kitabı hücresini `None` olarak ayarlayın. Sütun grafiğinde çizilen değer, [ChartDataPoint.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/value/) üzerinden elde edilebilir. Veri noktası aynı kategori konumunda kalır, ancak grafik, değerini boş olarak değerlendirir.

Aşağıdaki örnek, ilk serideki yalnızca ikinci noktayı temizler:

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

Dağılım grafiklerinde X ve Y hücreleri ayrı, balon grafiklerinde ayrıca bir boyut hücresi bulunur. Silmek istediğiniz değeri temsil eden hücreyi yalnızca temizleyin. Diğer noktaları korumak istiyorsanız [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/clear/) metodunu çağırmayın; bu metod tüm veri noktalarını koleksiyondan kaldırır.

## **Boş Hücrelerin Görüntülenmesini Kontrol Etme**

Değer içeren gizli hücreler, boş hücrelerden ayrı bir durumdur. Gizli çalışma sayfası satır ve sütunlarındaki verileri dahil edip etmeyeceğinizi öğrenmek için [Include Data from Hidden Rows and Columns](/slides/tr/python-net/chart-workbook/#include-data-from-hidden-rows-and-columns) bölümüne bakın.

Boş bir çalışma kitabı hücresi eksik veriyi temsil eder; `0` içeren bir hücre ise bilinen bir sayısal değeri temsil eder. Hücreyi boş yapmak için [ChartDataCell.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/value/) özelliğini `None` olarak ayarlayın. Sayısal sıfır, boş‑hücre ayarından bağımsız olarak sıfır olarak kalır.

Grafiğin boş hücreleri nasıl göstereceğini belirlemek için [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) kullanılabilir. Bu ayar tüm grafik için geçerlidir ve boş hücrelerin nasıl çizileceğini değiştirir; hücreyi sıfır ya da interpolasyonla doldurmaz.

Aşağıdaki bağımsız örnek, bir satır grafiği oluşturur, 3. Gün için değeri temizler ve aynı grafiği her bir modda kaydeder. Giriş dosyasına ihtiyaç yoktur. [ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/) çalışma sayfası 0, kategori etiketleri için sütun 0, değerler için sütun 1 kullanır; satır 0 seri adını tutar. Son veri `10, 20, boş, 30, 40` şeklindedir.

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

    # 3. günü gerçekten boş bırakın, ancak kategori ve veri noktasını koruyun.
    workbook.get_cell(0, 3, 1).value = None

    modes = [("Gap", charts.DisplayBlanksAsType.GAP), ("Zero", charts.DisplayBlanksAsType.ZERO), ("Span", charts.DisplayBlanksAsType.SPAN)]
    for mode_name, mode in modes:
        chart.display_blanks_as = mode
        presentation.save(f"empty_cells_{mode_name}.pptx", slides.export.SaveFormat.PPTX)
```

Her çıktı dosyası, kaydetmeden önce atanan modu içerir: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` ve `empty_cells_Span.pptx`. Tek bir sürüm kaydetmek isterseniz istediğiniz modu atayın ve sunumu yalnızca bir kez kaydedin.

Aşağıdaki karşılaştırma, aynı verinin üç dosyadaki görünümünü gösterir. 3. Gün çalışma kitabında her durumda boştur:

![Boş hücrelerin gösterimi: Gap çizgiyi 3. Gün’de keser, Zero çizgiyi sıfıra indirir, Span 2. Gün ile 4. Gün arasını bağlar.](display_blanks_as.png)

Görünüm etkisi grafik tipine bağlıdır. Satır grafiği üç modu da karşılaştırmayı kolaylaştırır. Çubuk ve sütun grafiklerinde eksik bir kategori olduğunda bağlayıcı bir çizgi olmayacağı için `SPAN` yukarıdaki gibi bir segment üretemez; eksik bir sütun ile sıfır‑yüksekliğinde bir sütun da benzer görünebilir. Benzer şekilde sadece işaretleyicileri olan dağılım grafiğinde de bağlayıcı bir çizgi yoktur. Her grafik tipinde üç ayrı sonuç beklemeyin; kullandığınız tip için çıktıyı kontrol edin.

## **Seri Boşluk Genişliğini Ayarlama**

Boşluk genişliği, yan yana çubuk ya da sütun kümeleri arasındaki boşluk olup, çubuk ya da sütun genişliğinin yüzdesi olarak ifade edilir. Örtüşme gibi, bu ayar da bireysel bir seriye değil ebeveyn seri grubuna aittir. Grup için bir kez [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) ayarlayın. Daha yüksek bir değer kümeler arasındaki boşluğu artırır; daha düşük bir değer onları daha sıkı hâle getirir.

Aşağıdaki örnek boşluk genişliğini değiştirir ve sadece son sunumu kaydeder:

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

## **SSS**

**Hangi grafik tipleri veri serilerini destekler?**

[ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) enum’u tarafından temsil edilen tüm grafik tipleri veri kullanır, ancak serilerin değer yapısı ve ayarları farklılık gösterir. Örneğin kategori grafiklerinde kategori ve değerler, dağılım grafiklerinde X ve Y değerleri, balon grafiklerinde ise balon boyutları kullanılır. Seri tipine uygun veri‑nokta oluşturma metodunu seçin. Örtüşme ve boşluk genişliği gibi seçenekler yalnızca uyumlu çubuk ya da sütun grupları için geçerlidir.

**Grafik serisi grubu nedir?**

[ChartSeriesGroup](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/) aynı grup‑seviyesi çizim ayarlarını paylaşan uyumlu serileri içerir. Kombinasyon grafiği birden fazla grup barındırabilir; bir seri üzerinden erişilen grup ayarını değiştirmek, grafikteki tüm serileri zorunlu olarak etkilemez.

**Yeni oluşturulan bir grafik varsayılan veri içerir mi?**

Evet. Varsayılan olarak, [ShapeCollection.add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) örnek seriler, kategoriler ve değerler oluşturur. Bu hücreleri düzenleyebilir ya da tamamen özel bir veri kümesi eklemeden önce serileri ve kategori koleksiyonlarını temizleyebilirsiniz. Aşırı yüklemelerle varsayılan veri olmadan da grafik oluşturulabilir.

**Grafik nesneleri çalışma kitabı hücreleriyle nasıl ilişkilendirilir?**

Seri adları, kategori etiketleri ve veri‑nokta değerleri bir [ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/) içindeki hücrelere başvurur. Başvurulan hücre değiştirildiğinde ilgili grafik öğesi güncellenir. Özel veri oluştururken, her noktanın istenen kategori altında çizildiğinden emin olmak için kategori satırları ile seri‑değer satırlarını hizalı tutun.

**Bir serinin tamamı yerine tek bir noktayı nasıl temizlerim?**

İlgili değer hücresini `None` yaparak noktayı boş bırakın; kategori konumu korunur. [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/clear/) metodunu yalnızca tüm noktaları kaldırmak istediğinizde kullanın. Kategorileri de kaldırıyorsanız, tüm serileri güncelleyerek değerlerin kategori koleksiyonuyla hizalı kalmasını sağlayın.

**Boş noktalar nasıl gösterilir?**

Görünüm, grafik türüne ve [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) ayarına bağlıdır. Desteklenen grafikler, boşluklar, sıfır değerler ya da komşu noktaların bağlanması şeklinde boşları gösterebilir. Sunumunuzdaki eksik verinin anlamına en uygun seçeneği belirleyin. Tam bir örnek ve görsel karşılaştırma için [Control the Display of Empty Cells](#control-the-display-of-empty-cells) bölümüne bakın.

**Negatif değerler nasıl biçimlendirilir?**

Desteklenen çubuk, sütun ve balon serileri için [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/invert_if_negative/) etkinleştirildikten sonra [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/) ile negatif değer rengi ayarlanır. Bireysel bir nokta için davranışı [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/) ile geçersiz kılabilirsiniz. Bu özellikler yalnızca biçimlendirmeyi etkiler; saklanan sayısal değerleri değiştirmez.

**Seri ve nokta aynı anda biçimlendirilirse hangi format kazanır?**

Açık veri‑nokta biçimlendirmesi, o nokta için önceliklidir. Diğer noktalar açık seri formatını ya da seri formatı tanımlı değilse otomatik grafik stilini ve temayı kullanmaya devam eder. Örtüşme ve boşluk genişliği gibi grup özellikleri düzeni kontrol eder ve nokta‑seviyesi biçimlendirme geçersiz kılmaz.

**Bir grafik kaç seri içerebilir?**

Aspose.Slides ayrı bir sabit seri sayısı sınırlaması getirmez. Pratikte, sunum dosyası kısıtlamaları, kullanılabilir bellek, işleme süresi ve grafik okunabilirliği etkili bir sınır belirler.

**Sütunlar çok yakın ya da çok uzak olduğunda ne yapmalıyım?**

Uygun ebeveyn seri grubunda [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) ayarını değiştirin. Değeri artırarak kümeler arasındaki boşluğu genişletebilir, azaltarak kümeleri birbirine yaklaştırabilirsiniz.