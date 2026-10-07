---
title: Python ile Sunumlarda Grafik Veri Serilerini Yönetme
linktitle: Veri Serileri
type: docs
url: /tr/python-net/chart-series/
keywords:
- grafik serisi
- seri çakışması
- seri rengi
- kategori rengi
- seri adı
- veri noktası
- seri boşluğu
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Python ile sunumlarda grafik serileri, veri noktaları, çalışma kitabı hücreleri, biçimlendirme, çakışma, boşluk genişliği ve negatif değerleri nasıl yöneteceğinizi öğrenin."
---
## **Genel Bakış**

Bir grafik, çizilen verilerini bir grafik veri çalışma kitabında saklar. Bir [ChartSeries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/) bir dizi ilişkili değer kümesini temsil eder ve serideki her [ChartDataPoint](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/) bir veya daha fazla çalışma kitabı hücresine başvurur. [ChartCategory](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategory/) nesneleri, seriler tarafından paylaşılan etiketleri veya gruplanma değerlerini sağlar. Bu nedenle seri adı, kategoriler ve nokta değerleri yalnızca gösterim metni olarak saklanmak yerine [ChartDataCell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/) nesnelerine bağlanır.

Tipik bir kategori grafiği için, varsayılan çalışma kitabı seri adları için satır 0, kategori adları için sütun 0 ve kalan hücreler seri değerleri için kullanır. [ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) yöntemine geçirilen çalışma sayfası, satır ve sütun indeksleri sıfır‑tabanlıdır. Bu düzen, varsayılan verilerle bir grafik oluştururken yararlıdır, ancak mevcut her grafiğin bunu kullandığını varsaymayın. Yüklenmiş bir sunumda, çalışma kitabı değerlerini değiştirmeden önce seriler, kategoriler ve veri noktaları tarafından başvurulan hücreleri inceleyin.

Grafik ayarlarının üç farklı kapsamı vardır:

- Seri‑düzeyi ayarlar, örneğin [ChartSeries.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/format/), bir serideki tüm noktalar için varsayılan görünümü sağlar.
- Veri‑nokta ayarları, örneğin [ChartDataPoint.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/format/), bir nokta için seri görünümünü geçersiz kılar.
- Grup ayarları, aynı [ChartSeriesGroup](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/) içinde yer alan uyumlu serilere uygulanır. Çakışma veya boşluk genişliği gibi seçenekleri ayarlamanız gerektiğinde gruba [ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/) üzerinden erişin.

Açıkça bir nokta veya seri dolgu ayarı belirlenmemişse, grafik stili ve teması otomatik görünümü belirler. Hem seri hem de nokta biçimlendirmesi mevcutsa, nokta biçimlendirmesi o nokta için önceliklidir.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Grafik Serisi Çakışmasını Ayarla**

[ChartSeries.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/overlap/) 2D bir grafikte çubukların veya sütunların ne kadar çakıştığını %-100’dan %-100’e kadar raporlar. Bu, üst seri grubundaki ayarın yalnızca okunabilir bir yansımasıdır. İlgili gruptaki tüm uyumlu serileri güncellemek için [ChartSeriesGroup.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/overlap/) ayarlayın. Bu seçenek, gruplanmış çubuk veya sütun gösteren grafik türlerine uygulanır; birleşik bir grafikte ilgisiz seri gruplarını etkilemez.

Aşağıdaki örnek, ilk seriyi içeren grup için çakışmayı ayarlar:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    # Yeni grafik, örnek serileri, kategorileri ve değerleri içerir.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.overlap = overlap_percent

    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Seri çakışması](series_overlap.png)

## **Seri Dolgu Rengini Değiştir**

[ChartSeries.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/format/) kullanarak bir bütün serinin varsayılan dolgusunu ayarlayabilirsiniz. Bir noktanın zaten açık bir dolgu ayarı varsa, o noktanın [ChartDataPoint.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/format/) ayarı seri dolgusunu geçersiz kılar.

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

![Serinin rengi](series_color.png)

## **Seri Adını Değiştir**

Bir seri adı grafik veri çalışma kitabında saklanır ve normalde lejende görüntülenir. Küme sütun grafiği için oluşturulan varsayılan çalışma kitabında B1 hücresi (satır 0, sütun 1) ilk serinin adını içerir. Aşağıdaki örnekteki adlandırılmış sabitler bu yapıyı açıkça gösterir:

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

Ayrıca [ChartSeries.name](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/name/) tarafından zaten başvurulan hücreyi güncelleyebilirsiniz. Bu yaklaşım, mevcut bir grafikte belirli bir satır ve sütun varsayımından kaçınır:

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

### **Birden Çok Hücreden Oluşan Bir Seri Adı Oluştur**

Birleştirilmiş seri adı, ürün adı ve raporlama döneminin ayrı hücrelerde saklandığı durumlarda faydalıdır. Örneğin, B1 hücresindeki `Product A` ve C1 hücresindeki `2026` değerlerini tek bir seri adı olarak birleştirirken her iki kısmın da kaynak hücrelerine bağlı kalabilirsiniz.

[ChartDataWorkbook.get_cell_collection](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell_collection/) kullanarak ad aralığını alın, ardından bu koleksiyonu [ChartSeriesCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriescollection/add/) yöntemine geçirin. `skip_hidden_cells` bağımsız değişkeni gizli hücrelerin dahil edilip edilmemesini kontrol eder: `True` hariç tutar, `False` dahil eder. Bu örnek adı aralığındaki tüm hücreleri dahil etmek için `False` kullanır.

Aşağıdaki örnek, bir seri ve iki veri noktası içeren bir sunum oluşturur. B1:C1 hücreleri yalnızca seri adını sağlar; A2:A3 kategori etiketlerini, B2:B3 ise sayısal değerleri sağlar.

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

    # Bu iki hücre serinin adını sağlar.
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

Oluşturulan seri adı `Product A 2026` olup iki hücre değerinin arasında bir boşluk bulunur. Leğende bu, iki sütun için tek bir giriş olarak gösterilir. Aşağıdaki görsel kaydedilen sunumdan oluşturulmuştur:

![Kuzey ve Güney değerleri ve birleşik seri adı Product A 2026 içeren sütun grafiği (leğende)](composite_series_name.png)

## **Otomatik Seri Dolgu Rengini Al**

[ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/) seri indeksine ve grafik stiline göre hesaplanan rengi döndürür. Bu, seri dolgusu açıkça tanımlanmamışken kullanılan renktir. Yöntem, hesaplanan rengi okur; yeni bir dolgu atamaz.

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

Tam renkler grafik stiline ve temaya bağlıdır.

## **Grafik Serisi için Ters Dolgu Rengini Ayarla**

Çubuk, sütun ve baloncuk serileri için [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/invert_if_negative/) negatif değerleri farklı bir dolgu ile gösterir. Normal seri dolgusunu katı bir renkle ayarlayın, ters çevirmeyi etkinleştirin ve negatif‑değer rengini [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/) üzerinden atayın. Negatif sayılar çalışma kitabında değişmeden kalır; yalnızca görüntü rengi değişir.

Aşağıdaki örnek, varsayılan grafik verisini tek bir seriyle değiştirir. Çalışma sayfası satırı 0 seri adını, sütun 0 kategori adlarını ve sütun 1 değerleri içerir:

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

Bir nokta için ters çevirmeyi [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/) ile etkinleştirebilirsiniz. Aşağıdaki örnekte, seri için ters çevrim devre dışı bırakılmış, yalnızca seçili nokta için etkinleştirilmiştir. Etkiyi göstermek için nokta aynı zamanda negatif bir değere atanmıştır:

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

## **Belirli Bir Veri Noktası Değerini Temizle**

Bir noktayı diğer noktaları kaldırmadan boş yapmak için, arka plan hücresini `None` olarak ayarlayın. Sütun grafiği için çizilen değer, [ChartDataPoint.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/value/) aracılığıyla elde edilir. Veri noktası aynı kategori konumunda kalır, ancak grafik değeri boş olarak değerlendirir ve grafiğin boş‑değer ayarlarına göre işler.

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

Saçılma grafikleri ayrı X ve Y hücreleri kullanır, baloncuk grafikleri ayrıca bir boyut hücresi kullanır. Kaldırmak istediğiniz değeri temsil eden hücreyi yalnızca temizleyin. Diğer noktaları tutmak istiyorsanız [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/clear/) yöntemini çağırmayın; bu yöntem serideki tüm veri noktalarını siler.

## **Boş Hücrelerin Görüntülenmesini Kontrol Et**

Değer içeren gizli hücreler, boş hücrelerden ayrı bir durumdur. Gizli satır ve sütunlardan veri eklemek için [Include Data from Hidden Rows and Columns](/slides/tr/python-net/chart-workbook/#include-data-from-hidden-rows-and-columns) bölümüne bakın.

Boş bir çalışma kitabı hücresi eksik veriyi temsil eder; `0` içeren bir hücre bilinen sayısal değeri temsil eder. Bir hücreyi boş yapmak için [ChartDataCell.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/value/) değerini `None` olarak ayarlayın. Sayısal sıfır, boş‑hücre ayarına bakılmaksızın sıfır olarak kalır.

[Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) kullanarak grafiğin boş hücreleri nasıl görüntüleyeceğini seçin. Bu ayar tüm grafik için geçerlidir. Boşlukların nasıl çizileceğini değiştirir; boş hücreyi sıfır ya da araştırılmış bir değerle doldurmaz.

Aşağıdaki bağımsız örnek, bir seri içeren bir çizgi grafiği oluşturur, Gün 3 için değeri temizler ve aynı grafiği her modda kaydeder. Girdi dosyası gerekmez. [ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/) çalışma sayfası 0, kategori etiketleri için sütun 0 ve değerler için sütun 1 kullanır; satır 0 seri adını tutar. Son veri `10, 20, empty, 30, 40` dır.

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

    # Gün 3'ü gerçekten boş bırak, ancak kategorisini ve veri noktasını koru.
    workbook.get_cell(0, 3, 1).value = None

    modes = [("Gap", charts.DisplayBlanksAsType.GAP), ("Zero", charts.DisplayBlanksAsType.ZERO), ("Span", charts.DisplayBlanksAsType.SPAN)]
    for mode_name, mode in modes:
        chart.display_blanks_as = mode
        presentation.save(f"empty_cells_{mode_name}.pptx", slides.export.SaveFormat.PPTX)
```

Her çıktı dosyası kaydetmeden önce atanan modu saklar: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` ve `empty_cells_Span.pptx`. Tek bir sürüm kaydetmek isterseniz istediğiniz modu atayın ve modları döngüye sokmak yerine sunumu bir kez kaydedin.

Aşağıdaki karşılaştırma, aynı veriyi üç dosyada gösterir. Gün 3 her durumda çalışma kitabında boştur:

![Aynı veriye sahip çizgi grafikleri: Boşluk, 3. günde çizgiyi keser; Sıfır, çizgiyi sıfıra düşürür; Aralık, 2. günü 4. günle birleştirir.](display_blanks_as.png)

Görünür etki grafik tipine bağlıdır. Bir çizgi grafiği, üç modu da karşılaştırmayı kolaylaştırır. Çubuk ve sütun grafiklerinde eksik bir kategori için bağlayıcı bir çizgi bulunmadığından `SPAN` yukarıdaki bağlayıcı segmenti üretemez; eksik bir sütun ve sıfır‑yüksekliğindeki bir sütun da benzer görünebilir. Benzer şekilde, yalnızca işaretçileri olan bir saçılma grafiğinde de bağlayıcı bir çizgi yoktur. Her grafik tipinde üç farklı sonuç beklemeyin; kullandığınız tip için çıktıyı kontrol edin.

## **Seri Boşluk Genişliğini Ayarla**

Boşluk genişliği, yan yana çubuk veya sütun kümeleri arasındaki boşluk olup, çubuk veya sütun genişliğinin yüzdesi olarak ifade edilir. Çakışma gibi, bu da tek bir seriye değil, üst seri grubuna aittir. Grup için bir kez [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) ayarlayın. Daha büyük bir değer kümeler arasındaki boşluğu artırır; daha küçük bir değer onları daha yoğun hâle getirir.

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

## **SSS**

**Hangi grafik türleri veri serilerini destekler?**

[ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) enum’u tarafından temsil edilen tüm grafik türleri veri kitaplığı kullanır, ancak serileri aynı değer yapısına veya ayarlara sahip olmayabilir. Örneğin, kategori grafiklerinde kategori ve değerler, saçılma grafiklerinde X ve Y değerleri, baloncuk grafiklerinde ise baloncuk boyutları bulunur. Seri tipine uygun veri‑nokta oluşturma yöntemini kullanın. Çakışma ve boşluk genişliği gibi seçenekler yalnızca uyumlu çubuk veya sütun gruplarına uygulanır.

**Bir grafik serisi grubu nedir?**

[ChartSeriesGroup](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/) aynı grup‑düzeyi çizin ayarlarını paylaşan uyumlu serileri içerir. Bir kombinasyon grafiği birden fazla grup barındırabilir; bir seriden erişilen grup ayarını değiştirmek, grafikteki tüm serileri zorunlu olarak etkilemez.

**Yeni oluşturulan bir grafik varsayılan veri içerir mi?**

Evet. Varsayılan olarak, [ShapeCollection.add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) örnek seriler, kategoriler ve değerler oluşturur. Bu hücreleri düzenleyebilir veya tamamen özel bir veri kümesi eklemeden önce serileri ve kategori koleksiyonlarını temizleyebilirsiniz. Bir aşırı yükleme, varsayılan veri olmadan da grafik oluşturabilir.

**Grafik nesneleri çalışma kitabı hücrelerine nasıl bağlanır?**

Seri adları, kategori etiketleri ve veri‑nokta değerleri bir [ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/) içindeki hücrelere başvurur. Başvurulan bir hücreyi değiştirmek, ilgili grafik öğesini günceller. Özel veri oluştururken, her noktanın istenen kategori altında çizildiğinden emin olmak için kategori satırları ve seri‑değer satırlarını hizalı tutun.

**Bir serinin tümünü değil, tek bir noktayı nasıl temizlerim?**

İlgili değer hücresini `None` olarak ayarlayın; böylece noktanın kategori konumu boş bir nokta olarak kalır. [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/clear/) yalnızca serideki tüm noktaları kaldırmak istediğinizde kullanın. Kategorileri de kaldırıyorsanız, her serinin değerlerini kategori koleksiyonuyla hizalı tutmak için güncelleyin.

**Boş noktalar nasıl görüntülenir?**

Sonuç, grafik tipi ve [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) ayarına bağlıdır. Desteklenen grafikler boşlukları boşluk, sıfır değerleri veya komşu noktaları bağlayarak gösterebilir. Sunumunuzdaki eksik verinin anlamına en uygun ayarı seçin. Tam örnek ve görsel karşılaştırma için [Boş Hücrelerin Görüntülenmesini Kontrol Et](#control-the-display-of-empty-cells) bölümüne bakın.

**Negatif değerler nasıl biçimlendirilir?**

Desteklenen çubuk, sütun ve baloncuk serileri için [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/invert_if_negative/) etkinleştirin ve [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/) aracılığıyla negatif‑değer rengini atayın. Tek bir nokta için davranışı [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/) ile geçersiz kılabilirsiniz. Bu özellikler biçimlendirmeyi etkiler; saklanan sayısal değerler değiştirilmez.

**Seri ve nokta ikisi de biçimlendirilmişse hangi biçimlendirme kazanır?**

Açık veri‑nokta biçimlendirmesi o nokta için önceliklidir. Diğer noktalar, seri biçimlendirmesi açık ise onu, açık değilse otomatik grafik stili ve temayı kullanır. Çakışma ve boşluk genişliği gibi grup özellikleri düzeni kontrol eder ve nokta‑düzeyi biçimlendirme geçersiz kılmaları değildir.

**Bir grafiğin içerebileceği seri sayısında bir sınır var mı?**

Aspose.Slides ayrı bir sabit seri‑sayısı sınırı koymaz. Pratikte, sunum dosyası kısıtlamaları, kullanılabilir bellek, render süresi ve grafik okunabilirliği faydalı bir sınırı belirler.

**Sütunlar çok yakın veya çok uzak olduğunda neyi değiştirmeliyim?**

Uygun üst seri grubunda [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) ayarını değiştirin. Değeri artırmak kümeler arasındaki boşluğu genişletir; azaltmak kümeleri birbirine yaklaştırır.